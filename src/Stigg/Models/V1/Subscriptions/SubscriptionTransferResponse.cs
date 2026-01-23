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
    typeof(JsonModelConverter<SubscriptionTransferResponse, SubscriptionTransferResponseFromRaw>)
)]
public sealed record class SubscriptionTransferResponse : JsonModel
{
    public required SubscriptionTransferResponseData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<SubscriptionTransferResponseData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public SubscriptionTransferResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionTransferResponse(SubscriptionTransferResponse subscriptionTransferResponse)
        : base(subscriptionTransferResponse) { }
#pragma warning restore CS8618

    public SubscriptionTransferResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionTransferResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionTransferResponseFromRaw.FromRawUnchecked"/>
    public static SubscriptionTransferResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SubscriptionTransferResponse(SubscriptionTransferResponseData data)
        : this()
    {
        this.Data = data;
    }
}

class SubscriptionTransferResponseFromRaw : IFromRawJson<SubscriptionTransferResponse>
{
    /// <inheritdoc/>
    public SubscriptionTransferResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionTransferResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionTransferResponseData,
        SubscriptionTransferResponseDataFromRaw
    >)
)]
public sealed record class SubscriptionTransferResponseData : JsonModel
{
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
        SubscriptionTransferResponseDataPaymentCollection
    > PaymentCollection
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, SubscriptionTransferResponseDataPaymentCollection>
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
    public required ApiEnum<string, SubscriptionTransferResponseDataPricingType> PricingType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, SubscriptionTransferResponseDataPricingType>
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
    public required ApiEnum<string, SubscriptionTransferResponseDataStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, SubscriptionTransferResponseDataStatus>
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
    public ApiEnum<string, SubscriptionTransferResponseDataCancelReason>? CancelReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, SubscriptionTransferResponseDataCancelReason>
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
        SubscriptionTransferResponseDataPaymentCollectionMethod
    >? PaymentCollectionMethod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, SubscriptionTransferResponseDataPaymentCollectionMethod>
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

    public SubscriptionTransferResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionTransferResponseData(
        SubscriptionTransferResponseData subscriptionTransferResponseData
    )
        : base(subscriptionTransferResponseData) { }
#pragma warning restore CS8618

    public SubscriptionTransferResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionTransferResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionTransferResponseDataFromRaw.FromRawUnchecked"/>
    public static SubscriptionTransferResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionTransferResponseDataFromRaw : IFromRawJson<SubscriptionTransferResponseData>
{
    /// <inheritdoc/>
    public SubscriptionTransferResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionTransferResponseData.FromRawUnchecked(rawData);
}

/// <summary>
/// Payment collection
/// </summary>
[JsonConverter(typeof(SubscriptionTransferResponseDataPaymentCollectionConverter))]
public enum SubscriptionTransferResponseDataPaymentCollection
{
    NotRequired,
    Processing,
    Failed,
    ActionRequired,
}

sealed class SubscriptionTransferResponseDataPaymentCollectionConverter
    : JsonConverter<SubscriptionTransferResponseDataPaymentCollection>
{
    public override SubscriptionTransferResponseDataPaymentCollection Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "NOT_REQUIRED" => SubscriptionTransferResponseDataPaymentCollection.NotRequired,
            "PROCESSING" => SubscriptionTransferResponseDataPaymentCollection.Processing,
            "FAILED" => SubscriptionTransferResponseDataPaymentCollection.Failed,
            "ACTION_REQUIRED" => SubscriptionTransferResponseDataPaymentCollection.ActionRequired,
            _ => (SubscriptionTransferResponseDataPaymentCollection)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionTransferResponseDataPaymentCollection value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionTransferResponseDataPaymentCollection.NotRequired => "NOT_REQUIRED",
                SubscriptionTransferResponseDataPaymentCollection.Processing => "PROCESSING",
                SubscriptionTransferResponseDataPaymentCollection.Failed => "FAILED",
                SubscriptionTransferResponseDataPaymentCollection.ActionRequired =>
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
[JsonConverter(typeof(SubscriptionTransferResponseDataPricingTypeConverter))]
public enum SubscriptionTransferResponseDataPricingType
{
    Free,
    Paid,
    Custom,
}

sealed class SubscriptionTransferResponseDataPricingTypeConverter
    : JsonConverter<SubscriptionTransferResponseDataPricingType>
{
    public override SubscriptionTransferResponseDataPricingType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FREE" => SubscriptionTransferResponseDataPricingType.Free,
            "PAID" => SubscriptionTransferResponseDataPricingType.Paid,
            "CUSTOM" => SubscriptionTransferResponseDataPricingType.Custom,
            _ => (SubscriptionTransferResponseDataPricingType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionTransferResponseDataPricingType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionTransferResponseDataPricingType.Free => "FREE",
                SubscriptionTransferResponseDataPricingType.Paid => "PAID",
                SubscriptionTransferResponseDataPricingType.Custom => "CUSTOM",
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
[JsonConverter(typeof(SubscriptionTransferResponseDataStatusConverter))]
public enum SubscriptionTransferResponseDataStatus
{
    PaymentPending,
    Active,
    Expired,
    InTrial,
    Canceled,
    NotStarted,
}

sealed class SubscriptionTransferResponseDataStatusConverter
    : JsonConverter<SubscriptionTransferResponseDataStatus>
{
    public override SubscriptionTransferResponseDataStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PAYMENT_PENDING" => SubscriptionTransferResponseDataStatus.PaymentPending,
            "ACTIVE" => SubscriptionTransferResponseDataStatus.Active,
            "EXPIRED" => SubscriptionTransferResponseDataStatus.Expired,
            "IN_TRIAL" => SubscriptionTransferResponseDataStatus.InTrial,
            "CANCELED" => SubscriptionTransferResponseDataStatus.Canceled,
            "NOT_STARTED" => SubscriptionTransferResponseDataStatus.NotStarted,
            _ => (SubscriptionTransferResponseDataStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionTransferResponseDataStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionTransferResponseDataStatus.PaymentPending => "PAYMENT_PENDING",
                SubscriptionTransferResponseDataStatus.Active => "ACTIVE",
                SubscriptionTransferResponseDataStatus.Expired => "EXPIRED",
                SubscriptionTransferResponseDataStatus.InTrial => "IN_TRIAL",
                SubscriptionTransferResponseDataStatus.Canceled => "CANCELED",
                SubscriptionTransferResponseDataStatus.NotStarted => "NOT_STARTED",
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
[JsonConverter(typeof(SubscriptionTransferResponseDataCancelReasonConverter))]
public enum SubscriptionTransferResponseDataCancelReason
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

sealed class SubscriptionTransferResponseDataCancelReasonConverter
    : JsonConverter<SubscriptionTransferResponseDataCancelReason>
{
    public override SubscriptionTransferResponseDataCancelReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "UPGRADE_OR_DOWNGRADE" =>
                SubscriptionTransferResponseDataCancelReason.UpgradeOrDowngrade,
            "CANCELLED_BY_BILLING" =>
                SubscriptionTransferResponseDataCancelReason.CancelledByBilling,
            "EXPIRED" => SubscriptionTransferResponseDataCancelReason.Expired,
            "DETACH_BILLING" => SubscriptionTransferResponseDataCancelReason.DetachBilling,
            "TRIAL_ENDED" => SubscriptionTransferResponseDataCancelReason.TrialEnded,
            "Immediate" => SubscriptionTransferResponseDataCancelReason.Immediate,
            "TRIAL_CONVERTED" => SubscriptionTransferResponseDataCancelReason.TrialConverted,
            "PENDING_PAYMENT_EXPIRED" =>
                SubscriptionTransferResponseDataCancelReason.PendingPaymentExpired,
            "ScheduledCancellation" =>
                SubscriptionTransferResponseDataCancelReason.ScheduledCancellation,
            "CustomerArchived" => SubscriptionTransferResponseDataCancelReason.CustomerArchived,
            "AutoCancellationRule" =>
                SubscriptionTransferResponseDataCancelReason.AutoCancellationRule,
            _ => (SubscriptionTransferResponseDataCancelReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionTransferResponseDataCancelReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionTransferResponseDataCancelReason.UpgradeOrDowngrade =>
                    "UPGRADE_OR_DOWNGRADE",
                SubscriptionTransferResponseDataCancelReason.CancelledByBilling =>
                    "CANCELLED_BY_BILLING",
                SubscriptionTransferResponseDataCancelReason.Expired => "EXPIRED",
                SubscriptionTransferResponseDataCancelReason.DetachBilling => "DETACH_BILLING",
                SubscriptionTransferResponseDataCancelReason.TrialEnded => "TRIAL_ENDED",
                SubscriptionTransferResponseDataCancelReason.Immediate => "Immediate",
                SubscriptionTransferResponseDataCancelReason.TrialConverted => "TRIAL_CONVERTED",
                SubscriptionTransferResponseDataCancelReason.PendingPaymentExpired =>
                    "PENDING_PAYMENT_EXPIRED",
                SubscriptionTransferResponseDataCancelReason.ScheduledCancellation =>
                    "ScheduledCancellation",
                SubscriptionTransferResponseDataCancelReason.CustomerArchived => "CustomerArchived",
                SubscriptionTransferResponseDataCancelReason.AutoCancellationRule =>
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
[JsonConverter(typeof(SubscriptionTransferResponseDataPaymentCollectionMethodConverter))]
public enum SubscriptionTransferResponseDataPaymentCollectionMethod
{
    Charge,
    Invoice,
    None,
}

sealed class SubscriptionTransferResponseDataPaymentCollectionMethodConverter
    : JsonConverter<SubscriptionTransferResponseDataPaymentCollectionMethod>
{
    public override SubscriptionTransferResponseDataPaymentCollectionMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "CHARGE" => SubscriptionTransferResponseDataPaymentCollectionMethod.Charge,
            "INVOICE" => SubscriptionTransferResponseDataPaymentCollectionMethod.Invoice,
            "NONE" => SubscriptionTransferResponseDataPaymentCollectionMethod.None,
            _ => (SubscriptionTransferResponseDataPaymentCollectionMethod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionTransferResponseDataPaymentCollectionMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionTransferResponseDataPaymentCollectionMethod.Charge => "CHARGE",
                SubscriptionTransferResponseDataPaymentCollectionMethod.Invoice => "INVOICE",
                SubscriptionTransferResponseDataPaymentCollectionMethod.None => "NONE",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
