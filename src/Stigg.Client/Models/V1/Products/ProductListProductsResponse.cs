using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;

namespace Stigg.Client.Models.V1.Products;

/// <summary>
/// Product configuration object
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ProductListProductsResponse, ProductListProductsResponseFromRaw>)
)]
public sealed record class ProductListProductsResponse : JsonModel
{
    /// <summary>
    /// The unique identifier for the entity
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Timestamp of when the record was created
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("createdAt");
        }
        init { this._rawData.Set("createdAt", value); }
    }

    /// <summary>
    /// Description of the product
    /// </summary>
    public required string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// Display name of the product
    /// </summary>
    public required string DisplayName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("displayName");
        }
        init { this._rawData.Set("displayName", value); }
    }

    /// <summary>
    /// Metadata associated with the entity
    /// </summary>
    public required IReadOnlyDictionary<string, string> Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string>>(
                "metadata",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Indicates if multiple subscriptions to this product are allowed
    /// </summary>
    public required bool MultipleSubscriptions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("multipleSubscriptions");
        }
        init { this._rawData.Set("multipleSubscriptions", value); }
    }

    /// <summary>
    /// The status of the product
    /// </summary>
    public required ApiEnum<string, ProductListProductsResponseStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ProductListProductsResponseStatus>
            >("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Timestamp of when the record was last updated
    /// </summary>
    public required DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("updatedAt");
        }
        init { this._rawData.Set("updatedAt", value); }
    }

    /// <summary>
    /// Product behavior settings for subscription lifecycle management.
    /// </summary>
    public ProductListProductsResponseProductSettings? ProductSettings
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ProductListProductsResponseProductSettings>(
                "productSettings"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("productSettings", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.Description;
        _ = this.DisplayName;
        _ = this.Metadata;
        _ = this.MultipleSubscriptions;
        this.Status.Validate();
        _ = this.UpdatedAt;
        this.ProductSettings?.Validate();
    }

    public ProductListProductsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProductListProductsResponse(ProductListProductsResponse productListProductsResponse)
        : base(productListProductsResponse) { }
#pragma warning restore CS8618

    public ProductListProductsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductListProductsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProductListProductsResponseFromRaw.FromRawUnchecked"/>
    public static ProductListProductsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProductListProductsResponseFromRaw : IFromRawJson<ProductListProductsResponse>
{
    /// <inheritdoc/>
    public ProductListProductsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProductListProductsResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// The status of the product
/// </summary>
[JsonConverter(typeof(ProductListProductsResponseStatusConverter))]
public enum ProductListProductsResponseStatus
{
    Published,
    Archived,
}

sealed class ProductListProductsResponseStatusConverter
    : JsonConverter<ProductListProductsResponseStatus>
{
    public override ProductListProductsResponseStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PUBLISHED" => ProductListProductsResponseStatus.Published,
            "ARCHIVED" => ProductListProductsResponseStatus.Archived,
            _ => (ProductListProductsResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProductListProductsResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProductListProductsResponseStatus.Published => "PUBLISHED",
                ProductListProductsResponseStatus.Archived => "ARCHIVED",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Product behavior settings for subscription lifecycle management.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ProductListProductsResponseProductSettings,
        ProductListProductsResponseProductSettingsFromRaw
    >)
)]
public sealed record class ProductListProductsResponseProductSettings : JsonModel
{
    /// <summary>
    /// Time when the subscription will be cancelled
    /// </summary>
    public required ApiEnum<
        string,
        ProductListProductsResponseProductSettingsSubscriptionCancellationTime
    > SubscriptionCancellationTime
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    ProductListProductsResponseProductSettingsSubscriptionCancellationTime
                >
            >("subscriptionCancellationTime");
        }
        init { this._rawData.Set("subscriptionCancellationTime", value); }
    }

    /// <summary>
    /// Setup for the end of the subscription
    /// </summary>
    public required ApiEnum<
        string,
        ProductListProductsResponseProductSettingsSubscriptionEndSetup
    > SubscriptionEndSetup
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ProductListProductsResponseProductSettingsSubscriptionEndSetup>
            >("subscriptionEndSetup");
        }
        init { this._rawData.Set("subscriptionEndSetup", value); }
    }

    /// <summary>
    /// Setup for the start of the subscription
    /// </summary>
    public required ApiEnum<
        string,
        ProductListProductsResponseProductSettingsSubscriptionStartSetup
    > SubscriptionStartSetup
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ProductListProductsResponseProductSettingsSubscriptionStartSetup>
            >("subscriptionStartSetup");
        }
        init { this._rawData.Set("subscriptionStartSetup", value); }
    }

    /// <summary>
    /// ID of the plan to downgrade to at the end of the billing period
    /// </summary>
    public string? DowngradePlanID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("downgradePlanId");
        }
        init { this._rawData.Set("downgradePlanId", value); }
    }

    /// <summary>
    /// Indicates if the subscription should be prorated at the end of the billing period
    /// </summary>
    public bool? ProrateAtEndOfBillingPeriod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("prorateAtEndOfBillingPeriod");
        }
        init { this._rawData.Set("prorateAtEndOfBillingPeriod", value); }
    }

    /// <summary>
    /// ID of the plan to start the subscription with
    /// </summary>
    public string? SubscriptionStartPlanID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("subscriptionStartPlanId");
        }
        init { this._rawData.Set("subscriptionStartPlanId", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.SubscriptionCancellationTime.Validate();
        this.SubscriptionEndSetup.Validate();
        this.SubscriptionStartSetup.Validate();
        _ = this.DowngradePlanID;
        _ = this.ProrateAtEndOfBillingPeriod;
        _ = this.SubscriptionStartPlanID;
    }

    public ProductListProductsResponseProductSettings() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProductListProductsResponseProductSettings(
        ProductListProductsResponseProductSettings productListProductsResponseProductSettings
    )
        : base(productListProductsResponseProductSettings) { }
#pragma warning restore CS8618

    public ProductListProductsResponseProductSettings(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductListProductsResponseProductSettings(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProductListProductsResponseProductSettingsFromRaw.FromRawUnchecked"/>
    public static ProductListProductsResponseProductSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProductListProductsResponseProductSettingsFromRaw
    : IFromRawJson<ProductListProductsResponseProductSettings>
{
    /// <inheritdoc/>
    public ProductListProductsResponseProductSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProductListProductsResponseProductSettings.FromRawUnchecked(rawData);
}

/// <summary>
/// Time when the subscription will be cancelled
/// </summary>
[JsonConverter(
    typeof(ProductListProductsResponseProductSettingsSubscriptionCancellationTimeConverter)
)]
public enum ProductListProductsResponseProductSettingsSubscriptionCancellationTime
{
    EndOfBillingPeriod,
    Immediate,
    SpecificDate,
}

sealed class ProductListProductsResponseProductSettingsSubscriptionCancellationTimeConverter
    : JsonConverter<ProductListProductsResponseProductSettingsSubscriptionCancellationTime>
{
    public override ProductListProductsResponseProductSettingsSubscriptionCancellationTime Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "END_OF_BILLING_PERIOD" =>
                ProductListProductsResponseProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            "IMMEDIATE" =>
                ProductListProductsResponseProductSettingsSubscriptionCancellationTime.Immediate,
            "SPECIFIC_DATE" =>
                ProductListProductsResponseProductSettingsSubscriptionCancellationTime.SpecificDate,
            _ => (ProductListProductsResponseProductSettingsSubscriptionCancellationTime)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProductListProductsResponseProductSettingsSubscriptionCancellationTime value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProductListProductsResponseProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod =>
                    "END_OF_BILLING_PERIOD",
                ProductListProductsResponseProductSettingsSubscriptionCancellationTime.Immediate =>
                    "IMMEDIATE",
                ProductListProductsResponseProductSettingsSubscriptionCancellationTime.SpecificDate =>
                    "SPECIFIC_DATE",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Setup for the end of the subscription
/// </summary>
[JsonConverter(typeof(ProductListProductsResponseProductSettingsSubscriptionEndSetupConverter))]
public enum ProductListProductsResponseProductSettingsSubscriptionEndSetup
{
    DowngradeToFree,
    CancelSubscription,
}

sealed class ProductListProductsResponseProductSettingsSubscriptionEndSetupConverter
    : JsonConverter<ProductListProductsResponseProductSettingsSubscriptionEndSetup>
{
    public override ProductListProductsResponseProductSettingsSubscriptionEndSetup Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "DOWNGRADE_TO_FREE" =>
                ProductListProductsResponseProductSettingsSubscriptionEndSetup.DowngradeToFree,
            "CANCEL_SUBSCRIPTION" =>
                ProductListProductsResponseProductSettingsSubscriptionEndSetup.CancelSubscription,
            _ => (ProductListProductsResponseProductSettingsSubscriptionEndSetup)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProductListProductsResponseProductSettingsSubscriptionEndSetup value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProductListProductsResponseProductSettingsSubscriptionEndSetup.DowngradeToFree =>
                    "DOWNGRADE_TO_FREE",
                ProductListProductsResponseProductSettingsSubscriptionEndSetup.CancelSubscription =>
                    "CANCEL_SUBSCRIPTION",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Setup for the start of the subscription
/// </summary>
[JsonConverter(typeof(ProductListProductsResponseProductSettingsSubscriptionStartSetupConverter))]
public enum ProductListProductsResponseProductSettingsSubscriptionStartSetup
{
    PlanSelection,
    TrialPeriod,
    FreePlan,
}

sealed class ProductListProductsResponseProductSettingsSubscriptionStartSetupConverter
    : JsonConverter<ProductListProductsResponseProductSettingsSubscriptionStartSetup>
{
    public override ProductListProductsResponseProductSettingsSubscriptionStartSetup Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PLAN_SELECTION" =>
                ProductListProductsResponseProductSettingsSubscriptionStartSetup.PlanSelection,
            "TRIAL_PERIOD" =>
                ProductListProductsResponseProductSettingsSubscriptionStartSetup.TrialPeriod,
            "FREE_PLAN" =>
                ProductListProductsResponseProductSettingsSubscriptionStartSetup.FreePlan,
            _ => (ProductListProductsResponseProductSettingsSubscriptionStartSetup)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProductListProductsResponseProductSettingsSubscriptionStartSetup value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProductListProductsResponseProductSettingsSubscriptionStartSetup.PlanSelection =>
                    "PLAN_SELECTION",
                ProductListProductsResponseProductSettingsSubscriptionStartSetup.TrialPeriod =>
                    "TRIAL_PERIOD",
                ProductListProductsResponseProductSettingsSubscriptionStartSetup.FreePlan =>
                    "FREE_PLAN",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
