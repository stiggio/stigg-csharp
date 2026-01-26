using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Core;
using Stigg.Exceptions;
using System = System;

namespace Stigg.Models.V1.Subscriptions;

[JsonConverter(
    typeof(JsonModelConverter<SubscriptionDelegateResponse, SubscriptionDelegateResponseFromRaw>)
)]
public sealed record class SubscriptionDelegateResponse : JsonModel
{
    public required SubscriptionDelegateResponseData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<SubscriptionDelegateResponseData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public SubscriptionDelegateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionDelegateResponse(SubscriptionDelegateResponse subscriptionDelegateResponse)
        : base(subscriptionDelegateResponse) { }
#pragma warning restore CS8618

    public SubscriptionDelegateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionDelegateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionDelegateResponseFromRaw.FromRawUnchecked"/>
    public static SubscriptionDelegateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SubscriptionDelegateResponse(SubscriptionDelegateResponseData data)
        : this()
    {
        this.Data = data;
    }
}

class SubscriptionDelegateResponseFromRaw : IFromRawJson<SubscriptionDelegateResponse>
{
    /// <inheritdoc/>
    public SubscriptionDelegateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionDelegateResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionDelegateResponseData,
        SubscriptionDelegateResponseDataFromRaw
    >)
)]
public sealed record class SubscriptionDelegateResponseData : JsonModel
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
        SubscriptionDelegateResponseDataPaymentCollection
    > PaymentCollection
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, SubscriptionDelegateResponseDataPaymentCollection>
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
    public required ApiEnum<string, SubscriptionDelegateResponseDataPricingType> PricingType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, SubscriptionDelegateResponseDataPricingType>
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
    public required ApiEnum<string, SubscriptionDelegateResponseDataStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, SubscriptionDelegateResponseDataStatus>
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
    public ApiEnum<string, SubscriptionDelegateResponseDataCancelReason>? CancelReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, SubscriptionDelegateResponseDataCancelReason>
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
        SubscriptionDelegateResponseDataPaymentCollectionMethod
    >? PaymentCollectionMethod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, SubscriptionDelegateResponseDataPaymentCollectionMethod>
            >("paymentCollectionMethod");
        }
        init { this._rawData.Set("paymentCollectionMethod", value); }
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
        _ = this.ResourceID;
        _ = this.TrialEndDate;
    }

    public SubscriptionDelegateResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionDelegateResponseData(
        SubscriptionDelegateResponseData subscriptionDelegateResponseData
    )
        : base(subscriptionDelegateResponseData) { }
#pragma warning restore CS8618

    public SubscriptionDelegateResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionDelegateResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionDelegateResponseDataFromRaw.FromRawUnchecked"/>
    public static SubscriptionDelegateResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionDelegateResponseDataFromRaw : IFromRawJson<SubscriptionDelegateResponseData>
{
    /// <inheritdoc/>
    public SubscriptionDelegateResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionDelegateResponseData.FromRawUnchecked(rawData);
}

/// <summary>
/// Payment collection
/// </summary>
[JsonConverter(typeof(SubscriptionDelegateResponseDataPaymentCollectionConverter))]
public enum SubscriptionDelegateResponseDataPaymentCollection
{
    NotRequired,
    Processing,
    Failed,
    ActionRequired,
}

sealed class SubscriptionDelegateResponseDataPaymentCollectionConverter
    : JsonConverter<SubscriptionDelegateResponseDataPaymentCollection>
{
    public override SubscriptionDelegateResponseDataPaymentCollection Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "NOT_REQUIRED" => SubscriptionDelegateResponseDataPaymentCollection.NotRequired,
            "PROCESSING" => SubscriptionDelegateResponseDataPaymentCollection.Processing,
            "FAILED" => SubscriptionDelegateResponseDataPaymentCollection.Failed,
            "ACTION_REQUIRED" => SubscriptionDelegateResponseDataPaymentCollection.ActionRequired,
            _ => (SubscriptionDelegateResponseDataPaymentCollection)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionDelegateResponseDataPaymentCollection value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionDelegateResponseDataPaymentCollection.NotRequired => "NOT_REQUIRED",
                SubscriptionDelegateResponseDataPaymentCollection.Processing => "PROCESSING",
                SubscriptionDelegateResponseDataPaymentCollection.Failed => "FAILED",
                SubscriptionDelegateResponseDataPaymentCollection.ActionRequired =>
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
[JsonConverter(typeof(SubscriptionDelegateResponseDataPricingTypeConverter))]
public enum SubscriptionDelegateResponseDataPricingType
{
    Free,
    Paid,
    Custom,
}

sealed class SubscriptionDelegateResponseDataPricingTypeConverter
    : JsonConverter<SubscriptionDelegateResponseDataPricingType>
{
    public override SubscriptionDelegateResponseDataPricingType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FREE" => SubscriptionDelegateResponseDataPricingType.Free,
            "PAID" => SubscriptionDelegateResponseDataPricingType.Paid,
            "CUSTOM" => SubscriptionDelegateResponseDataPricingType.Custom,
            _ => (SubscriptionDelegateResponseDataPricingType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionDelegateResponseDataPricingType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionDelegateResponseDataPricingType.Free => "FREE",
                SubscriptionDelegateResponseDataPricingType.Paid => "PAID",
                SubscriptionDelegateResponseDataPricingType.Custom => "CUSTOM",
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
[JsonConverter(typeof(SubscriptionDelegateResponseDataStatusConverter))]
public enum SubscriptionDelegateResponseDataStatus
{
    PaymentPending,
    Active,
    Expired,
    InTrial,
    Canceled,
    NotStarted,
}

sealed class SubscriptionDelegateResponseDataStatusConverter
    : JsonConverter<SubscriptionDelegateResponseDataStatus>
{
    public override SubscriptionDelegateResponseDataStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PAYMENT_PENDING" => SubscriptionDelegateResponseDataStatus.PaymentPending,
            "ACTIVE" => SubscriptionDelegateResponseDataStatus.Active,
            "EXPIRED" => SubscriptionDelegateResponseDataStatus.Expired,
            "IN_TRIAL" => SubscriptionDelegateResponseDataStatus.InTrial,
            "CANCELED" => SubscriptionDelegateResponseDataStatus.Canceled,
            "NOT_STARTED" => SubscriptionDelegateResponseDataStatus.NotStarted,
            _ => (SubscriptionDelegateResponseDataStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionDelegateResponseDataStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionDelegateResponseDataStatus.PaymentPending => "PAYMENT_PENDING",
                SubscriptionDelegateResponseDataStatus.Active => "ACTIVE",
                SubscriptionDelegateResponseDataStatus.Expired => "EXPIRED",
                SubscriptionDelegateResponseDataStatus.InTrial => "IN_TRIAL",
                SubscriptionDelegateResponseDataStatus.Canceled => "CANCELED",
                SubscriptionDelegateResponseDataStatus.NotStarted => "NOT_STARTED",
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
[JsonConverter(typeof(SubscriptionDelegateResponseDataCancelReasonConverter))]
public enum SubscriptionDelegateResponseDataCancelReason
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

sealed class SubscriptionDelegateResponseDataCancelReasonConverter
    : JsonConverter<SubscriptionDelegateResponseDataCancelReason>
{
    public override SubscriptionDelegateResponseDataCancelReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "UPGRADE_OR_DOWNGRADE" =>
                SubscriptionDelegateResponseDataCancelReason.UpgradeOrDowngrade,
            "CANCELLED_BY_BILLING" =>
                SubscriptionDelegateResponseDataCancelReason.CancelledByBilling,
            "EXPIRED" => SubscriptionDelegateResponseDataCancelReason.Expired,
            "DETACH_BILLING" => SubscriptionDelegateResponseDataCancelReason.DetachBilling,
            "TRIAL_ENDED" => SubscriptionDelegateResponseDataCancelReason.TrialEnded,
            "Immediate" => SubscriptionDelegateResponseDataCancelReason.Immediate,
            "TRIAL_CONVERTED" => SubscriptionDelegateResponseDataCancelReason.TrialConverted,
            "PENDING_PAYMENT_EXPIRED" =>
                SubscriptionDelegateResponseDataCancelReason.PendingPaymentExpired,
            "ScheduledCancellation" =>
                SubscriptionDelegateResponseDataCancelReason.ScheduledCancellation,
            "CustomerArchived" => SubscriptionDelegateResponseDataCancelReason.CustomerArchived,
            "AutoCancellationRule" =>
                SubscriptionDelegateResponseDataCancelReason.AutoCancellationRule,
            _ => (SubscriptionDelegateResponseDataCancelReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionDelegateResponseDataCancelReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionDelegateResponseDataCancelReason.UpgradeOrDowngrade =>
                    "UPGRADE_OR_DOWNGRADE",
                SubscriptionDelegateResponseDataCancelReason.CancelledByBilling =>
                    "CANCELLED_BY_BILLING",
                SubscriptionDelegateResponseDataCancelReason.Expired => "EXPIRED",
                SubscriptionDelegateResponseDataCancelReason.DetachBilling => "DETACH_BILLING",
                SubscriptionDelegateResponseDataCancelReason.TrialEnded => "TRIAL_ENDED",
                SubscriptionDelegateResponseDataCancelReason.Immediate => "Immediate",
                SubscriptionDelegateResponseDataCancelReason.TrialConverted => "TRIAL_CONVERTED",
                SubscriptionDelegateResponseDataCancelReason.PendingPaymentExpired =>
                    "PENDING_PAYMENT_EXPIRED",
                SubscriptionDelegateResponseDataCancelReason.ScheduledCancellation =>
                    "ScheduledCancellation",
                SubscriptionDelegateResponseDataCancelReason.CustomerArchived => "CustomerArchived",
                SubscriptionDelegateResponseDataCancelReason.AutoCancellationRule =>
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
[JsonConverter(typeof(SubscriptionDelegateResponseDataPaymentCollectionMethodConverter))]
public enum SubscriptionDelegateResponseDataPaymentCollectionMethod
{
    Charge,
    Invoice,
    None,
}

sealed class SubscriptionDelegateResponseDataPaymentCollectionMethodConverter
    : JsonConverter<SubscriptionDelegateResponseDataPaymentCollectionMethod>
{
    public override SubscriptionDelegateResponseDataPaymentCollectionMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "CHARGE" => SubscriptionDelegateResponseDataPaymentCollectionMethod.Charge,
            "INVOICE" => SubscriptionDelegateResponseDataPaymentCollectionMethod.Invoice,
            "NONE" => SubscriptionDelegateResponseDataPaymentCollectionMethod.None,
            _ => (SubscriptionDelegateResponseDataPaymentCollectionMethod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionDelegateResponseDataPaymentCollectionMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionDelegateResponseDataPaymentCollectionMethod.Charge => "CHARGE",
                SubscriptionDelegateResponseDataPaymentCollectionMethod.Invoice => "INVOICE",
                SubscriptionDelegateResponseDataPaymentCollectionMethod.None => "NONE",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
