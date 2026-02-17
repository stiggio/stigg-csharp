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
/// Response object
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ProductUpdateProductResponse, ProductUpdateProductResponseFromRaw>)
)]
public sealed record class ProductUpdateProductResponse : JsonModel
{
    /// <summary>
    /// Product configuration object
    /// </summary>
    public required ProductUpdateProductResponseData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ProductUpdateProductResponseData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public ProductUpdateProductResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProductUpdateProductResponse(ProductUpdateProductResponse productUpdateProductResponse)
        : base(productUpdateProductResponse) { }
#pragma warning restore CS8618

    public ProductUpdateProductResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductUpdateProductResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProductUpdateProductResponseFromRaw.FromRawUnchecked"/>
    public static ProductUpdateProductResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ProductUpdateProductResponse(ProductUpdateProductResponseData data)
        : this()
    {
        this.Data = data;
    }
}

class ProductUpdateProductResponseFromRaw : IFromRawJson<ProductUpdateProductResponse>
{
    /// <inheritdoc/>
    public ProductUpdateProductResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProductUpdateProductResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Product configuration object
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ProductUpdateProductResponseData,
        ProductUpdateProductResponseDataFromRaw
    >)
)]
public sealed record class ProductUpdateProductResponseData : JsonModel
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
    public required ApiEnum<string, ProductUpdateProductResponseDataStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ProductUpdateProductResponseDataStatus>
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
    public ProductUpdateProductResponseDataProductSettings? ProductSettings
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ProductUpdateProductResponseDataProductSettings>(
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

    public ProductUpdateProductResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProductUpdateProductResponseData(
        ProductUpdateProductResponseData productUpdateProductResponseData
    )
        : base(productUpdateProductResponseData) { }
#pragma warning restore CS8618

    public ProductUpdateProductResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductUpdateProductResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProductUpdateProductResponseDataFromRaw.FromRawUnchecked"/>
    public static ProductUpdateProductResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProductUpdateProductResponseDataFromRaw : IFromRawJson<ProductUpdateProductResponseData>
{
    /// <inheritdoc/>
    public ProductUpdateProductResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProductUpdateProductResponseData.FromRawUnchecked(rawData);
}

/// <summary>
/// The status of the product
/// </summary>
[JsonConverter(typeof(ProductUpdateProductResponseDataStatusConverter))]
public enum ProductUpdateProductResponseDataStatus
{
    Published,
    Archived,
}

sealed class ProductUpdateProductResponseDataStatusConverter
    : JsonConverter<ProductUpdateProductResponseDataStatus>
{
    public override ProductUpdateProductResponseDataStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PUBLISHED" => ProductUpdateProductResponseDataStatus.Published,
            "ARCHIVED" => ProductUpdateProductResponseDataStatus.Archived,
            _ => (ProductUpdateProductResponseDataStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProductUpdateProductResponseDataStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProductUpdateProductResponseDataStatus.Published => "PUBLISHED",
                ProductUpdateProductResponseDataStatus.Archived => "ARCHIVED",
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
        ProductUpdateProductResponseDataProductSettings,
        ProductUpdateProductResponseDataProductSettingsFromRaw
    >)
)]
public sealed record class ProductUpdateProductResponseDataProductSettings : JsonModel
{
    /// <summary>
    /// Time when the subscription will be cancelled
    /// </summary>
    public required ApiEnum<
        string,
        ProductUpdateProductResponseDataProductSettingsSubscriptionCancellationTime
    > SubscriptionCancellationTime
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    ProductUpdateProductResponseDataProductSettingsSubscriptionCancellationTime
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
        ProductUpdateProductResponseDataProductSettingsSubscriptionEndSetup
    > SubscriptionEndSetup
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ProductUpdateProductResponseDataProductSettingsSubscriptionEndSetup>
            >("subscriptionEndSetup");
        }
        init { this._rawData.Set("subscriptionEndSetup", value); }
    }

    /// <summary>
    /// Setup for the start of the subscription
    /// </summary>
    public required ApiEnum<
        string,
        ProductUpdateProductResponseDataProductSettingsSubscriptionStartSetup
    > SubscriptionStartSetup
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    ProductUpdateProductResponseDataProductSettingsSubscriptionStartSetup
                >
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

    public ProductUpdateProductResponseDataProductSettings() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProductUpdateProductResponseDataProductSettings(
        ProductUpdateProductResponseDataProductSettings productUpdateProductResponseDataProductSettings
    )
        : base(productUpdateProductResponseDataProductSettings) { }
#pragma warning restore CS8618

    public ProductUpdateProductResponseDataProductSettings(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductUpdateProductResponseDataProductSettings(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProductUpdateProductResponseDataProductSettingsFromRaw.FromRawUnchecked"/>
    public static ProductUpdateProductResponseDataProductSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProductUpdateProductResponseDataProductSettingsFromRaw
    : IFromRawJson<ProductUpdateProductResponseDataProductSettings>
{
    /// <inheritdoc/>
    public ProductUpdateProductResponseDataProductSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProductUpdateProductResponseDataProductSettings.FromRawUnchecked(rawData);
}

/// <summary>
/// Time when the subscription will be cancelled
/// </summary>
[JsonConverter(
    typeof(ProductUpdateProductResponseDataProductSettingsSubscriptionCancellationTimeConverter)
)]
public enum ProductUpdateProductResponseDataProductSettingsSubscriptionCancellationTime
{
    EndOfBillingPeriod,
    Immediate,
    SpecificDate,
}

sealed class ProductUpdateProductResponseDataProductSettingsSubscriptionCancellationTimeConverter
    : JsonConverter<ProductUpdateProductResponseDataProductSettingsSubscriptionCancellationTime>
{
    public override ProductUpdateProductResponseDataProductSettingsSubscriptionCancellationTime Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "END_OF_BILLING_PERIOD" =>
                ProductUpdateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            "IMMEDIATE" =>
                ProductUpdateProductResponseDataProductSettingsSubscriptionCancellationTime.Immediate,
            "SPECIFIC_DATE" =>
                ProductUpdateProductResponseDataProductSettingsSubscriptionCancellationTime.SpecificDate,
            _ => (ProductUpdateProductResponseDataProductSettingsSubscriptionCancellationTime)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProductUpdateProductResponseDataProductSettingsSubscriptionCancellationTime value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProductUpdateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod =>
                    "END_OF_BILLING_PERIOD",
                ProductUpdateProductResponseDataProductSettingsSubscriptionCancellationTime.Immediate =>
                    "IMMEDIATE",
                ProductUpdateProductResponseDataProductSettingsSubscriptionCancellationTime.SpecificDate =>
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
[JsonConverter(
    typeof(ProductUpdateProductResponseDataProductSettingsSubscriptionEndSetupConverter)
)]
public enum ProductUpdateProductResponseDataProductSettingsSubscriptionEndSetup
{
    DowngradeToFree,
    CancelSubscription,
}

sealed class ProductUpdateProductResponseDataProductSettingsSubscriptionEndSetupConverter
    : JsonConverter<ProductUpdateProductResponseDataProductSettingsSubscriptionEndSetup>
{
    public override ProductUpdateProductResponseDataProductSettingsSubscriptionEndSetup Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "DOWNGRADE_TO_FREE" =>
                ProductUpdateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
            "CANCEL_SUBSCRIPTION" =>
                ProductUpdateProductResponseDataProductSettingsSubscriptionEndSetup.CancelSubscription,
            _ => (ProductUpdateProductResponseDataProductSettingsSubscriptionEndSetup)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProductUpdateProductResponseDataProductSettingsSubscriptionEndSetup value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProductUpdateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree =>
                    "DOWNGRADE_TO_FREE",
                ProductUpdateProductResponseDataProductSettingsSubscriptionEndSetup.CancelSubscription =>
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
[JsonConverter(
    typeof(ProductUpdateProductResponseDataProductSettingsSubscriptionStartSetupConverter)
)]
public enum ProductUpdateProductResponseDataProductSettingsSubscriptionStartSetup
{
    PlanSelection,
    TrialPeriod,
    FreePlan,
}

sealed class ProductUpdateProductResponseDataProductSettingsSubscriptionStartSetupConverter
    : JsonConverter<ProductUpdateProductResponseDataProductSettingsSubscriptionStartSetup>
{
    public override ProductUpdateProductResponseDataProductSettingsSubscriptionStartSetup Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PLAN_SELECTION" =>
                ProductUpdateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
            "TRIAL_PERIOD" =>
                ProductUpdateProductResponseDataProductSettingsSubscriptionStartSetup.TrialPeriod,
            "FREE_PLAN" =>
                ProductUpdateProductResponseDataProductSettingsSubscriptionStartSetup.FreePlan,
            _ => (ProductUpdateProductResponseDataProductSettingsSubscriptionStartSetup)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProductUpdateProductResponseDataProductSettingsSubscriptionStartSetup value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProductUpdateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection =>
                    "PLAN_SELECTION",
                ProductUpdateProductResponseDataProductSettingsSubscriptionStartSetup.TrialPeriod =>
                    "TRIAL_PERIOD",
                ProductUpdateProductResponseDataProductSettingsSubscriptionStartSetup.FreePlan =>
                    "FREE_PLAN",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
