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
    typeof(JsonModelConverter<ProductCreateProductResponse, ProductCreateProductResponseFromRaw>)
)]
public sealed record class ProductCreateProductResponse : JsonModel
{
    /// <summary>
    /// Product configuration object
    /// </summary>
    public required ProductCreateProductResponseData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ProductCreateProductResponseData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public ProductCreateProductResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProductCreateProductResponse(ProductCreateProductResponse productCreateProductResponse)
        : base(productCreateProductResponse) { }
#pragma warning restore CS8618

    public ProductCreateProductResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductCreateProductResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProductCreateProductResponseFromRaw.FromRawUnchecked"/>
    public static ProductCreateProductResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ProductCreateProductResponse(ProductCreateProductResponseData data)
        : this()
    {
        this.Data = data;
    }
}

class ProductCreateProductResponseFromRaw : IFromRawJson<ProductCreateProductResponse>
{
    /// <inheritdoc/>
    public ProductCreateProductResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProductCreateProductResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Product configuration object
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ProductCreateProductResponseData,
        ProductCreateProductResponseDataFromRaw
    >)
)]
public sealed record class ProductCreateProductResponseData : JsonModel
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
    public required ApiEnum<string, ProductCreateProductResponseDataStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ProductCreateProductResponseDataStatus>
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
    public ProductCreateProductResponseDataProductSettings? ProductSettings
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ProductCreateProductResponseDataProductSettings>(
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

    public ProductCreateProductResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProductCreateProductResponseData(
        ProductCreateProductResponseData productCreateProductResponseData
    )
        : base(productCreateProductResponseData) { }
#pragma warning restore CS8618

    public ProductCreateProductResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductCreateProductResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProductCreateProductResponseDataFromRaw.FromRawUnchecked"/>
    public static ProductCreateProductResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProductCreateProductResponseDataFromRaw : IFromRawJson<ProductCreateProductResponseData>
{
    /// <inheritdoc/>
    public ProductCreateProductResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProductCreateProductResponseData.FromRawUnchecked(rawData);
}

/// <summary>
/// The status of the product
/// </summary>
[JsonConverter(typeof(ProductCreateProductResponseDataStatusConverter))]
public enum ProductCreateProductResponseDataStatus
{
    Published,
    Archived,
}

sealed class ProductCreateProductResponseDataStatusConverter
    : JsonConverter<ProductCreateProductResponseDataStatus>
{
    public override ProductCreateProductResponseDataStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PUBLISHED" => ProductCreateProductResponseDataStatus.Published,
            "ARCHIVED" => ProductCreateProductResponseDataStatus.Archived,
            _ => (ProductCreateProductResponseDataStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProductCreateProductResponseDataStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProductCreateProductResponseDataStatus.Published => "PUBLISHED",
                ProductCreateProductResponseDataStatus.Archived => "ARCHIVED",
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
        ProductCreateProductResponseDataProductSettings,
        ProductCreateProductResponseDataProductSettingsFromRaw
    >)
)]
public sealed record class ProductCreateProductResponseDataProductSettings : JsonModel
{
    /// <summary>
    /// Time when the subscription will be cancelled
    /// </summary>
    public required ApiEnum<
        string,
        ProductCreateProductResponseDataProductSettingsSubscriptionCancellationTime
    > SubscriptionCancellationTime
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    ProductCreateProductResponseDataProductSettingsSubscriptionCancellationTime
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
        ProductCreateProductResponseDataProductSettingsSubscriptionEndSetup
    > SubscriptionEndSetup
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ProductCreateProductResponseDataProductSettingsSubscriptionEndSetup>
            >("subscriptionEndSetup");
        }
        init { this._rawData.Set("subscriptionEndSetup", value); }
    }

    /// <summary>
    /// Setup for the start of the subscription
    /// </summary>
    public required ApiEnum<
        string,
        ProductCreateProductResponseDataProductSettingsSubscriptionStartSetup
    > SubscriptionStartSetup
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    ProductCreateProductResponseDataProductSettingsSubscriptionStartSetup
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

    public ProductCreateProductResponseDataProductSettings() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProductCreateProductResponseDataProductSettings(
        ProductCreateProductResponseDataProductSettings productCreateProductResponseDataProductSettings
    )
        : base(productCreateProductResponseDataProductSettings) { }
#pragma warning restore CS8618

    public ProductCreateProductResponseDataProductSettings(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductCreateProductResponseDataProductSettings(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProductCreateProductResponseDataProductSettingsFromRaw.FromRawUnchecked"/>
    public static ProductCreateProductResponseDataProductSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProductCreateProductResponseDataProductSettingsFromRaw
    : IFromRawJson<ProductCreateProductResponseDataProductSettings>
{
    /// <inheritdoc/>
    public ProductCreateProductResponseDataProductSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProductCreateProductResponseDataProductSettings.FromRawUnchecked(rawData);
}

/// <summary>
/// Time when the subscription will be cancelled
/// </summary>
[JsonConverter(
    typeof(ProductCreateProductResponseDataProductSettingsSubscriptionCancellationTimeConverter)
)]
public enum ProductCreateProductResponseDataProductSettingsSubscriptionCancellationTime
{
    EndOfBillingPeriod,
    Immediate,
    SpecificDate,
}

sealed class ProductCreateProductResponseDataProductSettingsSubscriptionCancellationTimeConverter
    : JsonConverter<ProductCreateProductResponseDataProductSettingsSubscriptionCancellationTime>
{
    public override ProductCreateProductResponseDataProductSettingsSubscriptionCancellationTime Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "END_OF_BILLING_PERIOD" =>
                ProductCreateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            "IMMEDIATE" =>
                ProductCreateProductResponseDataProductSettingsSubscriptionCancellationTime.Immediate,
            "SPECIFIC_DATE" =>
                ProductCreateProductResponseDataProductSettingsSubscriptionCancellationTime.SpecificDate,
            _ => (ProductCreateProductResponseDataProductSettingsSubscriptionCancellationTime)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProductCreateProductResponseDataProductSettingsSubscriptionCancellationTime value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProductCreateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod =>
                    "END_OF_BILLING_PERIOD",
                ProductCreateProductResponseDataProductSettingsSubscriptionCancellationTime.Immediate =>
                    "IMMEDIATE",
                ProductCreateProductResponseDataProductSettingsSubscriptionCancellationTime.SpecificDate =>
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
    typeof(ProductCreateProductResponseDataProductSettingsSubscriptionEndSetupConverter)
)]
public enum ProductCreateProductResponseDataProductSettingsSubscriptionEndSetup
{
    DowngradeToFree,
    CancelSubscription,
}

sealed class ProductCreateProductResponseDataProductSettingsSubscriptionEndSetupConverter
    : JsonConverter<ProductCreateProductResponseDataProductSettingsSubscriptionEndSetup>
{
    public override ProductCreateProductResponseDataProductSettingsSubscriptionEndSetup Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "DOWNGRADE_TO_FREE" =>
                ProductCreateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
            "CANCEL_SUBSCRIPTION" =>
                ProductCreateProductResponseDataProductSettingsSubscriptionEndSetup.CancelSubscription,
            _ => (ProductCreateProductResponseDataProductSettingsSubscriptionEndSetup)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProductCreateProductResponseDataProductSettingsSubscriptionEndSetup value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProductCreateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree =>
                    "DOWNGRADE_TO_FREE",
                ProductCreateProductResponseDataProductSettingsSubscriptionEndSetup.CancelSubscription =>
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
    typeof(ProductCreateProductResponseDataProductSettingsSubscriptionStartSetupConverter)
)]
public enum ProductCreateProductResponseDataProductSettingsSubscriptionStartSetup
{
    PlanSelection,
    TrialPeriod,
    FreePlan,
}

sealed class ProductCreateProductResponseDataProductSettingsSubscriptionStartSetupConverter
    : JsonConverter<ProductCreateProductResponseDataProductSettingsSubscriptionStartSetup>
{
    public override ProductCreateProductResponseDataProductSettingsSubscriptionStartSetup Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PLAN_SELECTION" =>
                ProductCreateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
            "TRIAL_PERIOD" =>
                ProductCreateProductResponseDataProductSettingsSubscriptionStartSetup.TrialPeriod,
            "FREE_PLAN" =>
                ProductCreateProductResponseDataProductSettingsSubscriptionStartSetup.FreePlan,
            _ => (ProductCreateProductResponseDataProductSettingsSubscriptionStartSetup)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProductCreateProductResponseDataProductSettingsSubscriptionStartSetup value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProductCreateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection =>
                    "PLAN_SELECTION",
                ProductCreateProductResponseDataProductSettingsSubscriptionStartSetup.TrialPeriod =>
                    "TRIAL_PERIOD",
                ProductCreateProductResponseDataProductSettingsSubscriptionStartSetup.FreePlan =>
                    "FREE_PLAN",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
