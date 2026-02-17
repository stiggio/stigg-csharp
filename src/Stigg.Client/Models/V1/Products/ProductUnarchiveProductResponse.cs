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
        ProductUnarchiveProductResponse,
        ProductUnarchiveProductResponseFromRaw
    >)
)]
public sealed record class ProductUnarchiveProductResponse : JsonModel
{
    /// <summary>
    /// Product configuration object
    /// </summary>
    public required ProductUnarchiveProductResponseData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ProductUnarchiveProductResponseData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public ProductUnarchiveProductResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProductUnarchiveProductResponse(
        ProductUnarchiveProductResponse productUnarchiveProductResponse
    )
        : base(productUnarchiveProductResponse) { }
#pragma warning restore CS8618

    public ProductUnarchiveProductResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductUnarchiveProductResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProductUnarchiveProductResponseFromRaw.FromRawUnchecked"/>
    public static ProductUnarchiveProductResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ProductUnarchiveProductResponse(ProductUnarchiveProductResponseData data)
        : this()
    {
        this.Data = data;
    }
}

class ProductUnarchiveProductResponseFromRaw : IFromRawJson<ProductUnarchiveProductResponse>
{
    /// <inheritdoc/>
    public ProductUnarchiveProductResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProductUnarchiveProductResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Product configuration object
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ProductUnarchiveProductResponseData,
        ProductUnarchiveProductResponseDataFromRaw
    >)
)]
public sealed record class ProductUnarchiveProductResponseData : JsonModel
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
    public required ApiEnum<string, ProductUnarchiveProductResponseDataStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ProductUnarchiveProductResponseDataStatus>
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
    public ProductUnarchiveProductResponseDataProductSettings? ProductSettings
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ProductUnarchiveProductResponseDataProductSettings>(
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

    public ProductUnarchiveProductResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProductUnarchiveProductResponseData(
        ProductUnarchiveProductResponseData productUnarchiveProductResponseData
    )
        : base(productUnarchiveProductResponseData) { }
#pragma warning restore CS8618

    public ProductUnarchiveProductResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductUnarchiveProductResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProductUnarchiveProductResponseDataFromRaw.FromRawUnchecked"/>
    public static ProductUnarchiveProductResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProductUnarchiveProductResponseDataFromRaw : IFromRawJson<ProductUnarchiveProductResponseData>
{
    /// <inheritdoc/>
    public ProductUnarchiveProductResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProductUnarchiveProductResponseData.FromRawUnchecked(rawData);
}

/// <summary>
/// The status of the product
/// </summary>
[JsonConverter(typeof(ProductUnarchiveProductResponseDataStatusConverter))]
public enum ProductUnarchiveProductResponseDataStatus
{
    Published,
    Archived,
}

sealed class ProductUnarchiveProductResponseDataStatusConverter
    : JsonConverter<ProductUnarchiveProductResponseDataStatus>
{
    public override ProductUnarchiveProductResponseDataStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PUBLISHED" => ProductUnarchiveProductResponseDataStatus.Published,
            "ARCHIVED" => ProductUnarchiveProductResponseDataStatus.Archived,
            _ => (ProductUnarchiveProductResponseDataStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProductUnarchiveProductResponseDataStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProductUnarchiveProductResponseDataStatus.Published => "PUBLISHED",
                ProductUnarchiveProductResponseDataStatus.Archived => "ARCHIVED",
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
        ProductUnarchiveProductResponseDataProductSettings,
        ProductUnarchiveProductResponseDataProductSettingsFromRaw
    >)
)]
public sealed record class ProductUnarchiveProductResponseDataProductSettings : JsonModel
{
    /// <summary>
    /// Time when the subscription will be cancelled
    /// </summary>
    public required ApiEnum<
        string,
        ProductUnarchiveProductResponseDataProductSettingsSubscriptionCancellationTime
    > SubscriptionCancellationTime
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    ProductUnarchiveProductResponseDataProductSettingsSubscriptionCancellationTime
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
        ProductUnarchiveProductResponseDataProductSettingsSubscriptionEndSetup
    > SubscriptionEndSetup
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    ProductUnarchiveProductResponseDataProductSettingsSubscriptionEndSetup
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
        ProductUnarchiveProductResponseDataProductSettingsSubscriptionStartSetup
    > SubscriptionStartSetup
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    ProductUnarchiveProductResponseDataProductSettingsSubscriptionStartSetup
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

    public ProductUnarchiveProductResponseDataProductSettings() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProductUnarchiveProductResponseDataProductSettings(
        ProductUnarchiveProductResponseDataProductSettings productUnarchiveProductResponseDataProductSettings
    )
        : base(productUnarchiveProductResponseDataProductSettings) { }
#pragma warning restore CS8618

    public ProductUnarchiveProductResponseDataProductSettings(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductUnarchiveProductResponseDataProductSettings(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProductUnarchiveProductResponseDataProductSettingsFromRaw.FromRawUnchecked"/>
    public static ProductUnarchiveProductResponseDataProductSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProductUnarchiveProductResponseDataProductSettingsFromRaw
    : IFromRawJson<ProductUnarchiveProductResponseDataProductSettings>
{
    /// <inheritdoc/>
    public ProductUnarchiveProductResponseDataProductSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProductUnarchiveProductResponseDataProductSettings.FromRawUnchecked(rawData);
}

/// <summary>
/// Time when the subscription will be cancelled
/// </summary>
[JsonConverter(
    typeof(ProductUnarchiveProductResponseDataProductSettingsSubscriptionCancellationTimeConverter)
)]
public enum ProductUnarchiveProductResponseDataProductSettingsSubscriptionCancellationTime
{
    EndOfBillingPeriod,
    Immediate,
    SpecificDate,
}

sealed class ProductUnarchiveProductResponseDataProductSettingsSubscriptionCancellationTimeConverter
    : JsonConverter<ProductUnarchiveProductResponseDataProductSettingsSubscriptionCancellationTime>
{
    public override ProductUnarchiveProductResponseDataProductSettingsSubscriptionCancellationTime Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "END_OF_BILLING_PERIOD" =>
                ProductUnarchiveProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            "IMMEDIATE" =>
                ProductUnarchiveProductResponseDataProductSettingsSubscriptionCancellationTime.Immediate,
            "SPECIFIC_DATE" =>
                ProductUnarchiveProductResponseDataProductSettingsSubscriptionCancellationTime.SpecificDate,
            _ => (ProductUnarchiveProductResponseDataProductSettingsSubscriptionCancellationTime)(
                -1
            ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProductUnarchiveProductResponseDataProductSettingsSubscriptionCancellationTime value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProductUnarchiveProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod =>
                    "END_OF_BILLING_PERIOD",
                ProductUnarchiveProductResponseDataProductSettingsSubscriptionCancellationTime.Immediate =>
                    "IMMEDIATE",
                ProductUnarchiveProductResponseDataProductSettingsSubscriptionCancellationTime.SpecificDate =>
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
    typeof(ProductUnarchiveProductResponseDataProductSettingsSubscriptionEndSetupConverter)
)]
public enum ProductUnarchiveProductResponseDataProductSettingsSubscriptionEndSetup
{
    DowngradeToFree,
    CancelSubscription,
}

sealed class ProductUnarchiveProductResponseDataProductSettingsSubscriptionEndSetupConverter
    : JsonConverter<ProductUnarchiveProductResponseDataProductSettingsSubscriptionEndSetup>
{
    public override ProductUnarchiveProductResponseDataProductSettingsSubscriptionEndSetup Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "DOWNGRADE_TO_FREE" =>
                ProductUnarchiveProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
            "CANCEL_SUBSCRIPTION" =>
                ProductUnarchiveProductResponseDataProductSettingsSubscriptionEndSetup.CancelSubscription,
            _ => (ProductUnarchiveProductResponseDataProductSettingsSubscriptionEndSetup)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProductUnarchiveProductResponseDataProductSettingsSubscriptionEndSetup value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProductUnarchiveProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree =>
                    "DOWNGRADE_TO_FREE",
                ProductUnarchiveProductResponseDataProductSettingsSubscriptionEndSetup.CancelSubscription =>
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
    typeof(ProductUnarchiveProductResponseDataProductSettingsSubscriptionStartSetupConverter)
)]
public enum ProductUnarchiveProductResponseDataProductSettingsSubscriptionStartSetup
{
    PlanSelection,
    TrialPeriod,
    FreePlan,
}

sealed class ProductUnarchiveProductResponseDataProductSettingsSubscriptionStartSetupConverter
    : JsonConverter<ProductUnarchiveProductResponseDataProductSettingsSubscriptionStartSetup>
{
    public override ProductUnarchiveProductResponseDataProductSettingsSubscriptionStartSetup Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PLAN_SELECTION" =>
                ProductUnarchiveProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
            "TRIAL_PERIOD" =>
                ProductUnarchiveProductResponseDataProductSettingsSubscriptionStartSetup.TrialPeriod,
            "FREE_PLAN" =>
                ProductUnarchiveProductResponseDataProductSettingsSubscriptionStartSetup.FreePlan,
            _ => (ProductUnarchiveProductResponseDataProductSettingsSubscriptionStartSetup)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProductUnarchiveProductResponseDataProductSettingsSubscriptionStartSetup value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProductUnarchiveProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection =>
                    "PLAN_SELECTION",
                ProductUnarchiveProductResponseDataProductSettingsSubscriptionStartSetup.TrialPeriod =>
                    "TRIAL_PERIOD",
                ProductUnarchiveProductResponseDataProductSettingsSubscriptionStartSetup.FreePlan =>
                    "FREE_PLAN",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
