using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Core;
using Stigg.Exceptions;
using System = System;

namespace Stigg.Models.V1.Subscriptions;

[JsonConverter(
    typeof(JsonModelConverter<SubscriptionListResponse, SubscriptionListResponseFromRaw>)
)]
public sealed record class SubscriptionListResponse : JsonModel
{
    public required IReadOnlyList<SubscriptionListResponseData> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<SubscriptionListResponseData>>(
                "data"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<SubscriptionListResponseData>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
    }

    public SubscriptionListResponse() { }

    public SubscriptionListResponse(SubscriptionListResponse subscriptionListResponse)
        : base(subscriptionListResponse) { }

    public SubscriptionListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionListResponseFromRaw.FromRawUnchecked"/>
    public static SubscriptionListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SubscriptionListResponse(IReadOnlyList<SubscriptionListResponseData> data)
        : this()
    {
        this.Data = data;
    }
}

class SubscriptionListResponseFromRaw : IFromRawJson<SubscriptionListResponse>
{
    /// <inheritdoc/>
    public SubscriptionListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionListResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<SubscriptionListResponseData, SubscriptionListResponseDataFromRaw>)
)]
public sealed record class SubscriptionListResponseData : JsonModel
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
    /// Cursor ID for query pagination
    /// </summary>
    public required string CursorID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("cursorId");
        }
        init { this._rawData.Set("cursorId", value); }
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
    public required ApiEnum<string, SubscriptionListResponseDataPaymentCollection> PaymentCollection
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, SubscriptionListResponseDataPaymentCollection>
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
    public required ApiEnum<string, SubscriptionListResponseDataPricingType> PricingType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, SubscriptionListResponseDataPricingType>
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
    public required ApiEnum<string, SubscriptionListResponseDataStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, SubscriptionListResponseDataStatus>
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
    public ApiEnum<string, SubscriptionListResponseDataCancelReason>? CancelReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, SubscriptionListResponseDataCancelReason>
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
        SubscriptionListResponseDataPaymentCollectionMethod
    >? PaymentCollectionMethod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, SubscriptionListResponseDataPaymentCollectionMethod>
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
        _ = this.CursorID;
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

    public SubscriptionListResponseData() { }

    public SubscriptionListResponseData(SubscriptionListResponseData subscriptionListResponseData)
        : base(subscriptionListResponseData) { }

    public SubscriptionListResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionListResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionListResponseDataFromRaw.FromRawUnchecked"/>
    public static SubscriptionListResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionListResponseDataFromRaw : IFromRawJson<SubscriptionListResponseData>
{
    /// <inheritdoc/>
    public SubscriptionListResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionListResponseData.FromRawUnchecked(rawData);
}

/// <summary>
/// Payment collection
/// </summary>
[JsonConverter(typeof(SubscriptionListResponseDataPaymentCollectionConverter))]
public enum SubscriptionListResponseDataPaymentCollection
{
    NotRequired,
    Processing,
    Failed,
    ActionRequired,
}

sealed class SubscriptionListResponseDataPaymentCollectionConverter
    : JsonConverter<SubscriptionListResponseDataPaymentCollection>
{
    public override SubscriptionListResponseDataPaymentCollection Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "NOT_REQUIRED" => SubscriptionListResponseDataPaymentCollection.NotRequired,
            "PROCESSING" => SubscriptionListResponseDataPaymentCollection.Processing,
            "FAILED" => SubscriptionListResponseDataPaymentCollection.Failed,
            "ACTION_REQUIRED" => SubscriptionListResponseDataPaymentCollection.ActionRequired,
            _ => (SubscriptionListResponseDataPaymentCollection)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionListResponseDataPaymentCollection value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionListResponseDataPaymentCollection.NotRequired => "NOT_REQUIRED",
                SubscriptionListResponseDataPaymentCollection.Processing => "PROCESSING",
                SubscriptionListResponseDataPaymentCollection.Failed => "FAILED",
                SubscriptionListResponseDataPaymentCollection.ActionRequired => "ACTION_REQUIRED",
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
[JsonConverter(typeof(SubscriptionListResponseDataPricingTypeConverter))]
public enum SubscriptionListResponseDataPricingType
{
    Free,
    Paid,
    Custom,
}

sealed class SubscriptionListResponseDataPricingTypeConverter
    : JsonConverter<SubscriptionListResponseDataPricingType>
{
    public override SubscriptionListResponseDataPricingType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FREE" => SubscriptionListResponseDataPricingType.Free,
            "PAID" => SubscriptionListResponseDataPricingType.Paid,
            "CUSTOM" => SubscriptionListResponseDataPricingType.Custom,
            _ => (SubscriptionListResponseDataPricingType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionListResponseDataPricingType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionListResponseDataPricingType.Free => "FREE",
                SubscriptionListResponseDataPricingType.Paid => "PAID",
                SubscriptionListResponseDataPricingType.Custom => "CUSTOM",
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
[JsonConverter(typeof(SubscriptionListResponseDataStatusConverter))]
public enum SubscriptionListResponseDataStatus
{
    PaymentPending,
    Active,
    Expired,
    InTrial,
    Canceled,
    NotStarted,
}

sealed class SubscriptionListResponseDataStatusConverter
    : JsonConverter<SubscriptionListResponseDataStatus>
{
    public override SubscriptionListResponseDataStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PAYMENT_PENDING" => SubscriptionListResponseDataStatus.PaymentPending,
            "ACTIVE" => SubscriptionListResponseDataStatus.Active,
            "EXPIRED" => SubscriptionListResponseDataStatus.Expired,
            "IN_TRIAL" => SubscriptionListResponseDataStatus.InTrial,
            "CANCELED" => SubscriptionListResponseDataStatus.Canceled,
            "NOT_STARTED" => SubscriptionListResponseDataStatus.NotStarted,
            _ => (SubscriptionListResponseDataStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionListResponseDataStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionListResponseDataStatus.PaymentPending => "PAYMENT_PENDING",
                SubscriptionListResponseDataStatus.Active => "ACTIVE",
                SubscriptionListResponseDataStatus.Expired => "EXPIRED",
                SubscriptionListResponseDataStatus.InTrial => "IN_TRIAL",
                SubscriptionListResponseDataStatus.Canceled => "CANCELED",
                SubscriptionListResponseDataStatus.NotStarted => "NOT_STARTED",
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
[JsonConverter(typeof(SubscriptionListResponseDataCancelReasonConverter))]
public enum SubscriptionListResponseDataCancelReason
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

sealed class SubscriptionListResponseDataCancelReasonConverter
    : JsonConverter<SubscriptionListResponseDataCancelReason>
{
    public override SubscriptionListResponseDataCancelReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "UPGRADE_OR_DOWNGRADE" => SubscriptionListResponseDataCancelReason.UpgradeOrDowngrade,
            "CANCELLED_BY_BILLING" => SubscriptionListResponseDataCancelReason.CancelledByBilling,
            "EXPIRED" => SubscriptionListResponseDataCancelReason.Expired,
            "DETACH_BILLING" => SubscriptionListResponseDataCancelReason.DetachBilling,
            "TRIAL_ENDED" => SubscriptionListResponseDataCancelReason.TrialEnded,
            "Immediate" => SubscriptionListResponseDataCancelReason.Immediate,
            "TRIAL_CONVERTED" => SubscriptionListResponseDataCancelReason.TrialConverted,
            "PENDING_PAYMENT_EXPIRED" =>
                SubscriptionListResponseDataCancelReason.PendingPaymentExpired,
            "ScheduledCancellation" =>
                SubscriptionListResponseDataCancelReason.ScheduledCancellation,
            "CustomerArchived" => SubscriptionListResponseDataCancelReason.CustomerArchived,
            "AutoCancellationRule" => SubscriptionListResponseDataCancelReason.AutoCancellationRule,
            _ => (SubscriptionListResponseDataCancelReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionListResponseDataCancelReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionListResponseDataCancelReason.UpgradeOrDowngrade =>
                    "UPGRADE_OR_DOWNGRADE",
                SubscriptionListResponseDataCancelReason.CancelledByBilling =>
                    "CANCELLED_BY_BILLING",
                SubscriptionListResponseDataCancelReason.Expired => "EXPIRED",
                SubscriptionListResponseDataCancelReason.DetachBilling => "DETACH_BILLING",
                SubscriptionListResponseDataCancelReason.TrialEnded => "TRIAL_ENDED",
                SubscriptionListResponseDataCancelReason.Immediate => "Immediate",
                SubscriptionListResponseDataCancelReason.TrialConverted => "TRIAL_CONVERTED",
                SubscriptionListResponseDataCancelReason.PendingPaymentExpired =>
                    "PENDING_PAYMENT_EXPIRED",
                SubscriptionListResponseDataCancelReason.ScheduledCancellation =>
                    "ScheduledCancellation",
                SubscriptionListResponseDataCancelReason.CustomerArchived => "CustomerArchived",
                SubscriptionListResponseDataCancelReason.AutoCancellationRule =>
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
[JsonConverter(typeof(SubscriptionListResponseDataPaymentCollectionMethodConverter))]
public enum SubscriptionListResponseDataPaymentCollectionMethod
{
    Charge,
    Invoice,
    None,
}

sealed class SubscriptionListResponseDataPaymentCollectionMethodConverter
    : JsonConverter<SubscriptionListResponseDataPaymentCollectionMethod>
{
    public override SubscriptionListResponseDataPaymentCollectionMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "CHARGE" => SubscriptionListResponseDataPaymentCollectionMethod.Charge,
            "INVOICE" => SubscriptionListResponseDataPaymentCollectionMethod.Invoice,
            "NONE" => SubscriptionListResponseDataPaymentCollectionMethod.None,
            _ => (SubscriptionListResponseDataPaymentCollectionMethod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionListResponseDataPaymentCollectionMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionListResponseDataPaymentCollectionMethod.Charge => "CHARGE",
                SubscriptionListResponseDataPaymentCollectionMethod.Invoice => "INVOICE",
                SubscriptionListResponseDataPaymentCollectionMethod.None => "NONE",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
