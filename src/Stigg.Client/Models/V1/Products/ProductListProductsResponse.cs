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
    public required ApiEnum<string, Status> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Status>>("status");
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
    public ProductSettings? ProductSettings
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ProductSettings>("productSettings");
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
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Published,
    Archived,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PUBLISHED" => Status.Published,
            "ARCHIVED" => Status.Archived,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Published => "PUBLISHED",
                Status.Archived => "ARCHIVED",
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
[JsonConverter(typeof(JsonModelConverter<ProductSettings, ProductSettingsFromRaw>))]
public sealed record class ProductSettings : JsonModel
{
    /// <summary>
    /// Time when the subscription will be cancelled
    /// </summary>
    public required ApiEnum<string, SubscriptionCancellationTime> SubscriptionCancellationTime
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, SubscriptionCancellationTime>>(
                "subscriptionCancellationTime"
            );
        }
        init { this._rawData.Set("subscriptionCancellationTime", value); }
    }

    /// <summary>
    /// Setup for the end of the subscription
    /// </summary>
    public required ApiEnum<string, SubscriptionEndSetup> SubscriptionEndSetup
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, SubscriptionEndSetup>>(
                "subscriptionEndSetup"
            );
        }
        init { this._rawData.Set("subscriptionEndSetup", value); }
    }

    /// <summary>
    /// Setup for the start of the subscription
    /// </summary>
    public required ApiEnum<string, SubscriptionStartSetup> SubscriptionStartSetup
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, SubscriptionStartSetup>>(
                "subscriptionStartSetup"
            );
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

    public ProductSettings() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProductSettings(ProductSettings productSettings)
        : base(productSettings) { }
#pragma warning restore CS8618

    public ProductSettings(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductSettings(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProductSettingsFromRaw.FromRawUnchecked"/>
    public static ProductSettings FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProductSettingsFromRaw : IFromRawJson<ProductSettings>
{
    /// <inheritdoc/>
    public ProductSettings FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ProductSettings.FromRawUnchecked(rawData);
}

/// <summary>
/// Time when the subscription will be cancelled
/// </summary>
[JsonConverter(typeof(SubscriptionCancellationTimeConverter))]
public enum SubscriptionCancellationTime
{
    EndOfBillingPeriod,
    Immediate,
    SpecificDate,
}

sealed class SubscriptionCancellationTimeConverter : JsonConverter<SubscriptionCancellationTime>
{
    public override SubscriptionCancellationTime Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "END_OF_BILLING_PERIOD" => SubscriptionCancellationTime.EndOfBillingPeriod,
            "IMMEDIATE" => SubscriptionCancellationTime.Immediate,
            "SPECIFIC_DATE" => SubscriptionCancellationTime.SpecificDate,
            _ => (SubscriptionCancellationTime)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionCancellationTime value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionCancellationTime.EndOfBillingPeriod => "END_OF_BILLING_PERIOD",
                SubscriptionCancellationTime.Immediate => "IMMEDIATE",
                SubscriptionCancellationTime.SpecificDate => "SPECIFIC_DATE",
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
[JsonConverter(typeof(SubscriptionEndSetupConverter))]
public enum SubscriptionEndSetup
{
    DowngradeToFree,
    CancelSubscription,
}

sealed class SubscriptionEndSetupConverter : JsonConverter<SubscriptionEndSetup>
{
    public override SubscriptionEndSetup Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "DOWNGRADE_TO_FREE" => SubscriptionEndSetup.DowngradeToFree,
            "CANCEL_SUBSCRIPTION" => SubscriptionEndSetup.CancelSubscription,
            _ => (SubscriptionEndSetup)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionEndSetup value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionEndSetup.DowngradeToFree => "DOWNGRADE_TO_FREE",
                SubscriptionEndSetup.CancelSubscription => "CANCEL_SUBSCRIPTION",
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
[JsonConverter(typeof(SubscriptionStartSetupConverter))]
public enum SubscriptionStartSetup
{
    PlanSelection,
    TrialPeriod,
    FreePlan,
}

sealed class SubscriptionStartSetupConverter : JsonConverter<SubscriptionStartSetup>
{
    public override SubscriptionStartSetup Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PLAN_SELECTION" => SubscriptionStartSetup.PlanSelection,
            "TRIAL_PERIOD" => SubscriptionStartSetup.TrialPeriod,
            "FREE_PLAN" => SubscriptionStartSetup.FreePlan,
            _ => (SubscriptionStartSetup)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionStartSetup value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionStartSetup.PlanSelection => "PLAN_SELECTION",
                SubscriptionStartSetup.TrialPeriod => "TRIAL_PERIOD",
                SubscriptionStartSetup.FreePlan => "FREE_PLAN",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
