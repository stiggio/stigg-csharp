using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using System = System;

namespace Stigg.Client.Models.V1.Subscriptions;

[JsonConverter(
    typeof(JsonModelConverter<SubscriptionRetrieveResponse, SubscriptionRetrieveResponseFromRaw>)
)]
public sealed record class SubscriptionRetrieveResponse : JsonModel
{
    public required SubscriptionRetrieveResponseData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<SubscriptionRetrieveResponseData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public SubscriptionRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionRetrieveResponse(SubscriptionRetrieveResponse subscriptionRetrieveResponse)
        : base(subscriptionRetrieveResponse) { }
#pragma warning restore CS8618

    public SubscriptionRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static SubscriptionRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SubscriptionRetrieveResponse(SubscriptionRetrieveResponseData data)
        : this()
    {
        this.Data = data;
    }
}

class SubscriptionRetrieveResponseFromRaw : IFromRawJson<SubscriptionRetrieveResponse>
{
    /// <inheritdoc/>
    public SubscriptionRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionRetrieveResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionRetrieveResponseData,
        SubscriptionRetrieveResponseDataFromRaw
    >)
)]
public sealed record class SubscriptionRetrieveResponseData : JsonModel
{
    /// <summary>
    /// Subscription ID
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
    /// Billing ID
    /// </summary>
    public required string? BillingID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billingId");
        }
        init { this._rawData.Set("billingId", value); }
    }

    /// <summary>
    /// Created at
    /// </summary>
    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("createdAt");
        }
        init { this._rawData.Set("createdAt", value); }
    }

    /// <summary>
    /// Customer ID
    /// </summary>
    public required string CustomerID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("customerId");
        }
        init { this._rawData.Set("customerId", value); }
    }

    /// <summary>
    /// Payment collection
    /// </summary>
    public required ApiEnum<
        string,
        SubscriptionRetrieveResponseDataPaymentCollection
    > PaymentCollection
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, SubscriptionRetrieveResponseDataPaymentCollection>
            >("paymentCollection");
        }
        init { this._rawData.Set("paymentCollection", value); }
    }

    /// <summary>
    /// Plan ID
    /// </summary>
    public required string PlanID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("planId");
        }
        init { this._rawData.Set("planId", value); }
    }

    /// <summary>
    /// Pricing type
    /// </summary>
    public required ApiEnum<string, SubscriptionRetrieveResponseDataPricingType> PricingType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, SubscriptionRetrieveResponseDataPricingType>
            >("pricingType");
        }
        init { this._rawData.Set("pricingType", value); }
    }

    /// <summary>
    /// Subscription start date
    /// </summary>
    public required System::DateTimeOffset StartDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("startDate");
        }
        init { this._rawData.Set("startDate", value); }
    }

    /// <summary>
    /// Subscription status
    /// </summary>
    public required ApiEnum<string, SubscriptionRetrieveResponseDataStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, SubscriptionRetrieveResponseDataStatus>
            >("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Subscription cancellation date
    /// </summary>
    public System::DateTimeOffset? CancellationDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("cancellationDate");
        }
        init { this._rawData.Set("cancellationDate", value); }
    }

    /// <summary>
    /// Subscription cancel reason
    /// </summary>
    public ApiEnum<string, SubscriptionRetrieveResponseDataCancelReason>? CancelReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, SubscriptionRetrieveResponseDataCancelReason>
            >("cancelReason");
        }
        init { this._rawData.Set("cancelReason", value); }
    }

    /// <summary>
    /// End of the current billing period
    /// </summary>
    public System::DateTimeOffset? CurrentBillingPeriodEnd
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "currentBillingPeriodEnd"
            );
        }
        init { this._rawData.Set("currentBillingPeriodEnd", value); }
    }

    /// <summary>
    /// Start of the current billing period
    /// </summary>
    public System::DateTimeOffset? CurrentBillingPeriodStart
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "currentBillingPeriodStart"
            );
        }
        init { this._rawData.Set("currentBillingPeriodStart", value); }
    }

    /// <summary>
    /// Subscription effective end date
    /// </summary>
    public System::DateTimeOffset? EffectiveEndDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("effectiveEndDate");
        }
        init { this._rawData.Set("effectiveEndDate", value); }
    }

    /// <summary>
    /// Subscription end date
    /// </summary>
    public System::DateTimeOffset? EndDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("endDate");
        }
        init { this._rawData.Set("endDate", value); }
    }

    /// <summary>
    /// Additional metadata for the subscription
    /// </summary>
    public IReadOnlyDictionary<string, string>? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, string>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Paying customer ID for delegated billing
    /// </summary>
    public string? PayingCustomerID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("payingCustomerId");
        }
        init { this._rawData.Set("payingCustomerId", value); }
    }

    /// <summary>
    /// The method used to collect payments for a subscription
    /// </summary>
    public ApiEnum<
        string,
        SubscriptionRetrieveResponseDataPaymentCollectionMethod
    >? PaymentCollectionMethod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, SubscriptionRetrieveResponseDataPaymentCollectionMethod>
            >("paymentCollectionMethod");
        }
        init { this._rawData.Set("paymentCollectionMethod", value); }
    }

    public IReadOnlyList<SubscriptionRetrieveResponseDataPrice>? Prices
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<SubscriptionRetrieveResponseDataPrice>
            >("prices");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<SubscriptionRetrieveResponseDataPrice>?>(
                "prices",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Resource ID
    /// </summary>
    public string? ResourceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("resourceId");
        }
        init { this._rawData.Set("resourceId", value); }
    }

    /// <summary>
    /// Subscription trial end date
    /// </summary>
    public System::DateTimeOffset? TrialEndDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("trialEndDate");
        }
        init { this._rawData.Set("trialEndDate", value); }
    }

    public double? UnitQuantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("unitQuantity");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("unitQuantity", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.BillingID;
        _ = this.CreatedAt;
        _ = this.CustomerID;
        this.PaymentCollection.Validate();
        _ = this.PlanID;
        this.PricingType.Validate();
        _ = this.StartDate;
        this.Status.Validate();
        _ = this.CancellationDate;
        this.CancelReason?.Validate();
        _ = this.CurrentBillingPeriodEnd;
        _ = this.CurrentBillingPeriodStart;
        _ = this.EffectiveEndDate;
        _ = this.EndDate;
        _ = this.Metadata;
        _ = this.PayingCustomerID;
        this.PaymentCollectionMethod?.Validate();
        foreach (var item in this.Prices ?? [])
        {
            item.Validate();
        }
        _ = this.ResourceID;
        _ = this.TrialEndDate;
        _ = this.UnitQuantity;
    }

    public SubscriptionRetrieveResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionRetrieveResponseData(
        SubscriptionRetrieveResponseData subscriptionRetrieveResponseData
    )
        : base(subscriptionRetrieveResponseData) { }
#pragma warning restore CS8618

    public SubscriptionRetrieveResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionRetrieveResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionRetrieveResponseDataFromRaw.FromRawUnchecked"/>
    public static SubscriptionRetrieveResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionRetrieveResponseDataFromRaw : IFromRawJson<SubscriptionRetrieveResponseData>
{
    /// <inheritdoc/>
    public SubscriptionRetrieveResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionRetrieveResponseData.FromRawUnchecked(rawData);
}

/// <summary>
/// Payment collection
/// </summary>
[JsonConverter(typeof(SubscriptionRetrieveResponseDataPaymentCollectionConverter))]
public enum SubscriptionRetrieveResponseDataPaymentCollection
{
    NotRequired,
    Processing,
    Failed,
    ActionRequired,
}

sealed class SubscriptionRetrieveResponseDataPaymentCollectionConverter
    : JsonConverter<SubscriptionRetrieveResponseDataPaymentCollection>
{
    public override SubscriptionRetrieveResponseDataPaymentCollection Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "NOT_REQUIRED" => SubscriptionRetrieveResponseDataPaymentCollection.NotRequired,
            "PROCESSING" => SubscriptionRetrieveResponseDataPaymentCollection.Processing,
            "FAILED" => SubscriptionRetrieveResponseDataPaymentCollection.Failed,
            "ACTION_REQUIRED" => SubscriptionRetrieveResponseDataPaymentCollection.ActionRequired,
            _ => (SubscriptionRetrieveResponseDataPaymentCollection)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionRetrieveResponseDataPaymentCollection value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionRetrieveResponseDataPaymentCollection.NotRequired => "NOT_REQUIRED",
                SubscriptionRetrieveResponseDataPaymentCollection.Processing => "PROCESSING",
                SubscriptionRetrieveResponseDataPaymentCollection.Failed => "FAILED",
                SubscriptionRetrieveResponseDataPaymentCollection.ActionRequired =>
                    "ACTION_REQUIRED",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Pricing type
/// </summary>
[JsonConverter(typeof(SubscriptionRetrieveResponseDataPricingTypeConverter))]
public enum SubscriptionRetrieveResponseDataPricingType
{
    Free,
    Paid,
    Custom,
}

sealed class SubscriptionRetrieveResponseDataPricingTypeConverter
    : JsonConverter<SubscriptionRetrieveResponseDataPricingType>
{
    public override SubscriptionRetrieveResponseDataPricingType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FREE" => SubscriptionRetrieveResponseDataPricingType.Free,
            "PAID" => SubscriptionRetrieveResponseDataPricingType.Paid,
            "CUSTOM" => SubscriptionRetrieveResponseDataPricingType.Custom,
            _ => (SubscriptionRetrieveResponseDataPricingType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionRetrieveResponseDataPricingType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionRetrieveResponseDataPricingType.Free => "FREE",
                SubscriptionRetrieveResponseDataPricingType.Paid => "PAID",
                SubscriptionRetrieveResponseDataPricingType.Custom => "CUSTOM",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Subscription status
/// </summary>
[JsonConverter(typeof(SubscriptionRetrieveResponseDataStatusConverter))]
public enum SubscriptionRetrieveResponseDataStatus
{
    PaymentPending,
    Active,
    Expired,
    InTrial,
    Canceled,
    NotStarted,
}

sealed class SubscriptionRetrieveResponseDataStatusConverter
    : JsonConverter<SubscriptionRetrieveResponseDataStatus>
{
    public override SubscriptionRetrieveResponseDataStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PAYMENT_PENDING" => SubscriptionRetrieveResponseDataStatus.PaymentPending,
            "ACTIVE" => SubscriptionRetrieveResponseDataStatus.Active,
            "EXPIRED" => SubscriptionRetrieveResponseDataStatus.Expired,
            "IN_TRIAL" => SubscriptionRetrieveResponseDataStatus.InTrial,
            "CANCELED" => SubscriptionRetrieveResponseDataStatus.Canceled,
            "NOT_STARTED" => SubscriptionRetrieveResponseDataStatus.NotStarted,
            _ => (SubscriptionRetrieveResponseDataStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionRetrieveResponseDataStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionRetrieveResponseDataStatus.PaymentPending => "PAYMENT_PENDING",
                SubscriptionRetrieveResponseDataStatus.Active => "ACTIVE",
                SubscriptionRetrieveResponseDataStatus.Expired => "EXPIRED",
                SubscriptionRetrieveResponseDataStatus.InTrial => "IN_TRIAL",
                SubscriptionRetrieveResponseDataStatus.Canceled => "CANCELED",
                SubscriptionRetrieveResponseDataStatus.NotStarted => "NOT_STARTED",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Subscription cancel reason
/// </summary>
[JsonConverter(typeof(SubscriptionRetrieveResponseDataCancelReasonConverter))]
public enum SubscriptionRetrieveResponseDataCancelReason
{
    UpgradeOrDowngrade,
    CancelledByBilling,
    Expired,
    DetachBilling,
    TrialEnded,
    Immediate,
    TrialConverted,
    PendingPaymentExpired,
    ScheduledCancellation,
    CustomerArchived,
    AutoCancellationRule,
}

sealed class SubscriptionRetrieveResponseDataCancelReasonConverter
    : JsonConverter<SubscriptionRetrieveResponseDataCancelReason>
{
    public override SubscriptionRetrieveResponseDataCancelReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "UPGRADE_OR_DOWNGRADE" =>
                SubscriptionRetrieveResponseDataCancelReason.UpgradeOrDowngrade,
            "CANCELLED_BY_BILLING" =>
                SubscriptionRetrieveResponseDataCancelReason.CancelledByBilling,
            "EXPIRED" => SubscriptionRetrieveResponseDataCancelReason.Expired,
            "DETACH_BILLING" => SubscriptionRetrieveResponseDataCancelReason.DetachBilling,
            "TRIAL_ENDED" => SubscriptionRetrieveResponseDataCancelReason.TrialEnded,
            "Immediate" => SubscriptionRetrieveResponseDataCancelReason.Immediate,
            "TRIAL_CONVERTED" => SubscriptionRetrieveResponseDataCancelReason.TrialConverted,
            "PENDING_PAYMENT_EXPIRED" =>
                SubscriptionRetrieveResponseDataCancelReason.PendingPaymentExpired,
            "ScheduledCancellation" =>
                SubscriptionRetrieveResponseDataCancelReason.ScheduledCancellation,
            "CustomerArchived" => SubscriptionRetrieveResponseDataCancelReason.CustomerArchived,
            "AutoCancellationRule" =>
                SubscriptionRetrieveResponseDataCancelReason.AutoCancellationRule,
            _ => (SubscriptionRetrieveResponseDataCancelReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionRetrieveResponseDataCancelReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionRetrieveResponseDataCancelReason.UpgradeOrDowngrade =>
                    "UPGRADE_OR_DOWNGRADE",
                SubscriptionRetrieveResponseDataCancelReason.CancelledByBilling =>
                    "CANCELLED_BY_BILLING",
                SubscriptionRetrieveResponseDataCancelReason.Expired => "EXPIRED",
                SubscriptionRetrieveResponseDataCancelReason.DetachBilling => "DETACH_BILLING",
                SubscriptionRetrieveResponseDataCancelReason.TrialEnded => "TRIAL_ENDED",
                SubscriptionRetrieveResponseDataCancelReason.Immediate => "Immediate",
                SubscriptionRetrieveResponseDataCancelReason.TrialConverted => "TRIAL_CONVERTED",
                SubscriptionRetrieveResponseDataCancelReason.PendingPaymentExpired =>
                    "PENDING_PAYMENT_EXPIRED",
                SubscriptionRetrieveResponseDataCancelReason.ScheduledCancellation =>
                    "ScheduledCancellation",
                SubscriptionRetrieveResponseDataCancelReason.CustomerArchived => "CustomerArchived",
                SubscriptionRetrieveResponseDataCancelReason.AutoCancellationRule =>
                    "AutoCancellationRule",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The method used to collect payments for a subscription
/// </summary>
[JsonConverter(typeof(SubscriptionRetrieveResponseDataPaymentCollectionMethodConverter))]
public enum SubscriptionRetrieveResponseDataPaymentCollectionMethod
{
    Charge,
    Invoice,
    None,
}

sealed class SubscriptionRetrieveResponseDataPaymentCollectionMethodConverter
    : JsonConverter<SubscriptionRetrieveResponseDataPaymentCollectionMethod>
{
    public override SubscriptionRetrieveResponseDataPaymentCollectionMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "CHARGE" => SubscriptionRetrieveResponseDataPaymentCollectionMethod.Charge,
            "INVOICE" => SubscriptionRetrieveResponseDataPaymentCollectionMethod.Invoice,
            "NONE" => SubscriptionRetrieveResponseDataPaymentCollectionMethod.None,
            _ => (SubscriptionRetrieveResponseDataPaymentCollectionMethod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionRetrieveResponseDataPaymentCollectionMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionRetrieveResponseDataPaymentCollectionMethod.Charge => "CHARGE",
                SubscriptionRetrieveResponseDataPaymentCollectionMethod.Invoice => "INVOICE",
                SubscriptionRetrieveResponseDataPaymentCollectionMethod.None => "NONE",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionRetrieveResponseDataPrice,
        SubscriptionRetrieveResponseDataPriceFromRaw
    >)
)]
public sealed record class SubscriptionRetrieveResponseDataPrice : JsonModel
{
    /// <summary>
    /// Price ID
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
    /// Creation timestamp
    /// </summary>
    public required string CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("createdAt");
        }
        init { this._rawData.Set("createdAt", value); }
    }

    /// <summary>
    /// Last update timestamp
    /// </summary>
    public required string UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("updatedAt");
        }
        init { this._rawData.Set("updatedAt", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.UpdatedAt;
    }

    public SubscriptionRetrieveResponseDataPrice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionRetrieveResponseDataPrice(
        SubscriptionRetrieveResponseDataPrice subscriptionRetrieveResponseDataPrice
    )
        : base(subscriptionRetrieveResponseDataPrice) { }
#pragma warning restore CS8618

    public SubscriptionRetrieveResponseDataPrice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionRetrieveResponseDataPrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionRetrieveResponseDataPriceFromRaw.FromRawUnchecked"/>
    public static SubscriptionRetrieveResponseDataPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionRetrieveResponseDataPriceFromRaw
    : IFromRawJson<SubscriptionRetrieveResponseDataPrice>
{
    /// <inheritdoc/>
    public SubscriptionRetrieveResponseDataPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionRetrieveResponseDataPrice.FromRawUnchecked(rawData);
}
