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
    typeof(JsonModelConverter<SubscriptionCreateResponse, SubscriptionCreateResponseFromRaw>)
)]
public sealed record class SubscriptionCreateResponse : JsonModel
{
    public required Data Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Data>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public SubscriptionCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionCreateResponse(SubscriptionCreateResponse subscriptionCreateResponse)
        : base(subscriptionCreateResponse) { }
#pragma warning restore CS8618

    public SubscriptionCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionCreateResponseFromRaw.FromRawUnchecked"/>
    public static SubscriptionCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SubscriptionCreateResponse(Data data)
        : this()
    {
        this.Data = data;
    }
}

class SubscriptionCreateResponseFromRaw : IFromRawJson<SubscriptionCreateResponse>
{
    /// <inheritdoc/>
    public SubscriptionCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionCreateResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// Unique identifier for the provisioned subscription
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
    /// Provision status: SUCCESS or PAYMENT_REQUIRED
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
    /// Checkout billing ID when payment is required
    /// </summary>
    public string? CheckoutBillingID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("checkoutBillingId");
        }
        init { this._rawData.Set("checkoutBillingId", value); }
    }

    /// <summary>
    /// URL to complete payment when PAYMENT_REQUIRED
    /// </summary>
    public string? CheckoutUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("checkoutUrl");
        }
        init { this._rawData.Set("checkoutUrl", value); }
    }

    /// <summary>
    /// Whether the subscription is scheduled for future activation
    /// </summary>
    public bool? IsScheduled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isScheduled");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isScheduled", value);
        }
    }

    public Subscription? Subscription
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Subscription>("subscription");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("subscription", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Status.Validate();
        _ = this.CheckoutBillingID;
        _ = this.CheckoutUrl;
        _ = this.IsScheduled;
        this.Subscription?.Validate();
    }

    public Data() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Data(Data data)
        : base(data) { }
#pragma warning restore CS8618

    public Data(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Data(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataFromRaw.FromRawUnchecked"/>
    public static Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Data.FromRawUnchecked(rawData);
}

/// <summary>
/// Provision status: SUCCESS or PAYMENT_REQUIRED
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Success,
    PaymentRequired,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SUCCESS" => Status.Success,
            "PAYMENT_REQUIRED" => Status.PaymentRequired,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Success => "SUCCESS",
                Status.PaymentRequired => "PAYMENT_REQUIRED",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<Subscription, SubscriptionFromRaw>))]
public sealed record class Subscription : JsonModel
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
    public required ApiEnum<string, PaymentCollection> PaymentCollection
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, PaymentCollection>>(
                "paymentCollection"
            );
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
    public required ApiEnum<string, PricingType> PricingType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, PricingType>>("pricingType");
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
    public required ApiEnum<string, SubscriptionStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, SubscriptionStatus>>("status");
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
    public ApiEnum<string, CancelReason>? CancelReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CancelReason>>("cancelReason");
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
    public ApiEnum<string, PaymentCollectionMethod>? PaymentCollectionMethod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PaymentCollectionMethod>>(
                "paymentCollectionMethod"
            );
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

    public Subscription() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Subscription(Subscription subscription)
        : base(subscription) { }
#pragma warning restore CS8618

    public Subscription(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Subscription(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionFromRaw.FromRawUnchecked"/>
    public static Subscription FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionFromRaw : IFromRawJson<Subscription>
{
    /// <inheritdoc/>
    public Subscription FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Subscription.FromRawUnchecked(rawData);
}

/// <summary>
/// Payment collection
/// </summary>
[JsonConverter(typeof(PaymentCollectionConverter))]
public enum PaymentCollection
{
    NotRequired,
    Processing,
    Failed,
    ActionRequired,
}

sealed class PaymentCollectionConverter : JsonConverter<PaymentCollection>
{
    public override PaymentCollection Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "NOT_REQUIRED" => PaymentCollection.NotRequired,
            "PROCESSING" => PaymentCollection.Processing,
            "FAILED" => PaymentCollection.Failed,
            "ACTION_REQUIRED" => PaymentCollection.ActionRequired,
            _ => (PaymentCollection)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PaymentCollection value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PaymentCollection.NotRequired => "NOT_REQUIRED",
                PaymentCollection.Processing => "PROCESSING",
                PaymentCollection.Failed => "FAILED",
                PaymentCollection.ActionRequired => "ACTION_REQUIRED",
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
[JsonConverter(typeof(PricingTypeConverter))]
public enum PricingType
{
    Free,
    Paid,
    Custom,
}

sealed class PricingTypeConverter : JsonConverter<PricingType>
{
    public override PricingType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FREE" => PricingType.Free,
            "PAID" => PricingType.Paid,
            "CUSTOM" => PricingType.Custom,
            _ => (PricingType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PricingType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PricingType.Free => "FREE",
                PricingType.Paid => "PAID",
                PricingType.Custom => "CUSTOM",
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
[JsonConverter(typeof(SubscriptionStatusConverter))]
public enum SubscriptionStatus
{
    PaymentPending,
    Active,
    Expired,
    InTrial,
    Canceled,
    NotStarted,
}

sealed class SubscriptionStatusConverter : JsonConverter<SubscriptionStatus>
{
    public override SubscriptionStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PAYMENT_PENDING" => SubscriptionStatus.PaymentPending,
            "ACTIVE" => SubscriptionStatus.Active,
            "EXPIRED" => SubscriptionStatus.Expired,
            "IN_TRIAL" => SubscriptionStatus.InTrial,
            "CANCELED" => SubscriptionStatus.Canceled,
            "NOT_STARTED" => SubscriptionStatus.NotStarted,
            _ => (SubscriptionStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionStatus.PaymentPending => "PAYMENT_PENDING",
                SubscriptionStatus.Active => "ACTIVE",
                SubscriptionStatus.Expired => "EXPIRED",
                SubscriptionStatus.InTrial => "IN_TRIAL",
                SubscriptionStatus.Canceled => "CANCELED",
                SubscriptionStatus.NotStarted => "NOT_STARTED",
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
[JsonConverter(typeof(CancelReasonConverter))]
public enum CancelReason
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

sealed class CancelReasonConverter : JsonConverter<CancelReason>
{
    public override CancelReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "UPGRADE_OR_DOWNGRADE" => CancelReason.UpgradeOrDowngrade,
            "CANCELLED_BY_BILLING" => CancelReason.CancelledByBilling,
            "EXPIRED" => CancelReason.Expired,
            "DETACH_BILLING" => CancelReason.DetachBilling,
            "TRIAL_ENDED" => CancelReason.TrialEnded,
            "Immediate" => CancelReason.Immediate,
            "TRIAL_CONVERTED" => CancelReason.TrialConverted,
            "PENDING_PAYMENT_EXPIRED" => CancelReason.PendingPaymentExpired,
            "ScheduledCancellation" => CancelReason.ScheduledCancellation,
            "CustomerArchived" => CancelReason.CustomerArchived,
            "AutoCancellationRule" => CancelReason.AutoCancellationRule,
            _ => (CancelReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CancelReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CancelReason.UpgradeOrDowngrade => "UPGRADE_OR_DOWNGRADE",
                CancelReason.CancelledByBilling => "CANCELLED_BY_BILLING",
                CancelReason.Expired => "EXPIRED",
                CancelReason.DetachBilling => "DETACH_BILLING",
                CancelReason.TrialEnded => "TRIAL_ENDED",
                CancelReason.Immediate => "Immediate",
                CancelReason.TrialConverted => "TRIAL_CONVERTED",
                CancelReason.PendingPaymentExpired => "PENDING_PAYMENT_EXPIRED",
                CancelReason.ScheduledCancellation => "ScheduledCancellation",
                CancelReason.CustomerArchived => "CustomerArchived",
                CancelReason.AutoCancellationRule => "AutoCancellationRule",
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
[JsonConverter(typeof(PaymentCollectionMethodConverter))]
public enum PaymentCollectionMethod
{
    Charge,
    Invoice,
    None,
}

sealed class PaymentCollectionMethodConverter : JsonConverter<PaymentCollectionMethod>
{
    public override PaymentCollectionMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "CHARGE" => PaymentCollectionMethod.Charge,
            "INVOICE" => PaymentCollectionMethod.Invoice,
            "NONE" => PaymentCollectionMethod.None,
            _ => (PaymentCollectionMethod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PaymentCollectionMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PaymentCollectionMethod.Charge => "CHARGE",
                PaymentCollectionMethod.Invoice => "INVOICE",
                PaymentCollectionMethod.None => "NONE",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
