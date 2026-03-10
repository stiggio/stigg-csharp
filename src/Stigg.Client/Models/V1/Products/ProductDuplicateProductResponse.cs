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
    typeof(JsonModelConverter<
        ProductDuplicateProductResponse,
        ProductDuplicateProductResponseFromRaw
    >)
)]
public sealed record class ProductDuplicateProductResponse : JsonModel
{
    /// <summary>
    /// Product configuration object
    /// </summary>
    public required ProductDuplicateProductResponseData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ProductDuplicateProductResponseData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public ProductDuplicateProductResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProductDuplicateProductResponse(
        ProductDuplicateProductResponse productDuplicateProductResponse
    )
        : base(productDuplicateProductResponse) { }
#pragma warning restore CS8618

    public ProductDuplicateProductResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductDuplicateProductResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProductDuplicateProductResponseFromRaw.FromRawUnchecked"/>
    public static ProductDuplicateProductResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ProductDuplicateProductResponse(ProductDuplicateProductResponseData data)
        : this()
    {
        this.Data = data;
    }
}

class ProductDuplicateProductResponseFromRaw : IFromRawJson<ProductDuplicateProductResponse>
{
    /// <inheritdoc/>
    public ProductDuplicateProductResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProductDuplicateProductResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Product configuration object
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ProductDuplicateProductResponseData,
        ProductDuplicateProductResponseDataFromRaw
    >)
)]
public sealed record class ProductDuplicateProductResponseData : JsonModel
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
    public required ApiEnum<string, ProductDuplicateProductResponseDataStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ProductDuplicateProductResponseDataStatus>
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
    public ProductDuplicateProductResponseDataProductSettings? ProductSettings
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ProductDuplicateProductResponseDataProductSettings>(
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

    public ProductDuplicateProductResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProductDuplicateProductResponseData(
        ProductDuplicateProductResponseData productDuplicateProductResponseData
    )
        : base(productDuplicateProductResponseData) { }
#pragma warning restore CS8618

    public ProductDuplicateProductResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductDuplicateProductResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProductDuplicateProductResponseDataFromRaw.FromRawUnchecked"/>
    public static ProductDuplicateProductResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProductDuplicateProductResponseDataFromRaw : IFromRawJson<ProductDuplicateProductResponseData>
{
    /// <inheritdoc/>
    public ProductDuplicateProductResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProductDuplicateProductResponseData.FromRawUnchecked(rawData);
}

/// <summary>
/// The status of the product
/// </summary>
[JsonConverter(typeof(ProductDuplicateProductResponseDataStatusConverter))]
public enum ProductDuplicateProductResponseDataStatus
{
    Published,
    Archived,
}

sealed class ProductDuplicateProductResponseDataStatusConverter
    : JsonConverter<ProductDuplicateProductResponseDataStatus>
{
    public override ProductDuplicateProductResponseDataStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PUBLISHED" => ProductDuplicateProductResponseDataStatus.Published,
            "ARCHIVED" => ProductDuplicateProductResponseDataStatus.Archived,
            _ => (ProductDuplicateProductResponseDataStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProductDuplicateProductResponseDataStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProductDuplicateProductResponseDataStatus.Published => "PUBLISHED",
                ProductDuplicateProductResponseDataStatus.Archived => "ARCHIVED",
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
        ProductDuplicateProductResponseDataProductSettings,
        ProductDuplicateProductResponseDataProductSettingsFromRaw
    >)
)]
public sealed record class ProductDuplicateProductResponseDataProductSettings : JsonModel
{
    /// <summary>
    /// Time when the subscription will be cancelled
    /// </summary>
    public required ApiEnum<
        string,
        ProductDuplicateProductResponseDataProductSettingsSubscriptionCancellationTime
    > SubscriptionCancellationTime
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    ProductDuplicateProductResponseDataProductSettingsSubscriptionCancellationTime
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
        ProductDuplicateProductResponseDataProductSettingsSubscriptionEndSetup
    > SubscriptionEndSetup
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    ProductDuplicateProductResponseDataProductSettingsSubscriptionEndSetup
                >
            >("subscriptionEndSetup");
        }
        init { this._rawData.Set("subscriptionEndSetup", value); }
    }

    /// <summary>
    /// Setup for the start of the subscription
    /// </summary>
    public required ApiEnum<
        string,
        ProductDuplicateProductResponseDataProductSettingsSubscriptionStartSetup
    > SubscriptionStartSetup
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    ProductDuplicateProductResponseDataProductSettingsSubscriptionStartSetup
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

    public ProductDuplicateProductResponseDataProductSettings() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProductDuplicateProductResponseDataProductSettings(
        ProductDuplicateProductResponseDataProductSettings productDuplicateProductResponseDataProductSettings
    )
        : base(productDuplicateProductResponseDataProductSettings) { }
#pragma warning restore CS8618

    public ProductDuplicateProductResponseDataProductSettings(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductDuplicateProductResponseDataProductSettings(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProductDuplicateProductResponseDataProductSettingsFromRaw.FromRawUnchecked"/>
    public static ProductDuplicateProductResponseDataProductSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProductDuplicateProductResponseDataProductSettingsFromRaw
    : IFromRawJson<ProductDuplicateProductResponseDataProductSettings>
{
    /// <inheritdoc/>
    public ProductDuplicateProductResponseDataProductSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProductDuplicateProductResponseDataProductSettings.FromRawUnchecked(rawData);
}

/// <summary>
/// Time when the subscription will be cancelled
/// </summary>
[JsonConverter(
    typeof(ProductDuplicateProductResponseDataProductSettingsSubscriptionCancellationTimeConverter)
)]
public enum ProductDuplicateProductResponseDataProductSettingsSubscriptionCancellationTime
{
    EndOfBillingPeriod,
    Immediate,
    SpecificDate,
}

sealed class ProductDuplicateProductResponseDataProductSettingsSubscriptionCancellationTimeConverter
    : JsonConverter<ProductDuplicateProductResponseDataProductSettingsSubscriptionCancellationTime>
{
    public override ProductDuplicateProductResponseDataProductSettingsSubscriptionCancellationTime Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "END_OF_BILLING_PERIOD" =>
                ProductDuplicateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            "IMMEDIATE" =>
                ProductDuplicateProductResponseDataProductSettingsSubscriptionCancellationTime.Immediate,
            "SPECIFIC_DATE" =>
                ProductDuplicateProductResponseDataProductSettingsSubscriptionCancellationTime.SpecificDate,
            _ => (ProductDuplicateProductResponseDataProductSettingsSubscriptionCancellationTime)(
                -1
            ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProductDuplicateProductResponseDataProductSettingsSubscriptionCancellationTime value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProductDuplicateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod =>
                    "END_OF_BILLING_PERIOD",
                ProductDuplicateProductResponseDataProductSettingsSubscriptionCancellationTime.Immediate =>
                    "IMMEDIATE",
                ProductDuplicateProductResponseDataProductSettingsSubscriptionCancellationTime.SpecificDate =>
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
    typeof(ProductDuplicateProductResponseDataProductSettingsSubscriptionEndSetupConverter)
)]
public enum ProductDuplicateProductResponseDataProductSettingsSubscriptionEndSetup
{
    DowngradeToFree,
    CancelSubscription,
}

sealed class ProductDuplicateProductResponseDataProductSettingsSubscriptionEndSetupConverter
    : JsonConverter<ProductDuplicateProductResponseDataProductSettingsSubscriptionEndSetup>
{
    public override ProductDuplicateProductResponseDataProductSettingsSubscriptionEndSetup Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "DOWNGRADE_TO_FREE" =>
                ProductDuplicateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
            "CANCEL_SUBSCRIPTION" =>
                ProductDuplicateProductResponseDataProductSettingsSubscriptionEndSetup.CancelSubscription,
            _ => (ProductDuplicateProductResponseDataProductSettingsSubscriptionEndSetup)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProductDuplicateProductResponseDataProductSettingsSubscriptionEndSetup value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProductDuplicateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree =>
                    "DOWNGRADE_TO_FREE",
                ProductDuplicateProductResponseDataProductSettingsSubscriptionEndSetup.CancelSubscription =>
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
    typeof(ProductDuplicateProductResponseDataProductSettingsSubscriptionStartSetupConverter)
)]
public enum ProductDuplicateProductResponseDataProductSettingsSubscriptionStartSetup
{
    PlanSelection,
    TrialPeriod,
    FreePlan,
}

sealed class ProductDuplicateProductResponseDataProductSettingsSubscriptionStartSetupConverter
    : JsonConverter<ProductDuplicateProductResponseDataProductSettingsSubscriptionStartSetup>
{
    public override ProductDuplicateProductResponseDataProductSettingsSubscriptionStartSetup Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PLAN_SELECTION" =>
                ProductDuplicateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
            "TRIAL_PERIOD" =>
                ProductDuplicateProductResponseDataProductSettingsSubscriptionStartSetup.TrialPeriod,
            "FREE_PLAN" =>
                ProductDuplicateProductResponseDataProductSettingsSubscriptionStartSetup.FreePlan,
            _ => (ProductDuplicateProductResponseDataProductSettingsSubscriptionStartSetup)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProductDuplicateProductResponseDataProductSettingsSubscriptionStartSetup value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProductDuplicateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection =>
                    "PLAN_SELECTION",
                ProductDuplicateProductResponseDataProductSettingsSubscriptionStartSetup.TrialPeriod =>
                    "TRIAL_PERIOD",
                ProductDuplicateProductResponseDataProductSettingsSubscriptionStartSetup.FreePlan =>
                    "FREE_PLAN",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
