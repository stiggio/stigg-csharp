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

/// <summary>
/// Response object
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<SubscriptionMigrateResponse, SubscriptionMigrateResponseFromRaw>)
)]
public sealed record class SubscriptionMigrateResponse : JsonModel
{
    /// <summary>
    /// Customer subscription to a plan
    /// </summary>
    public required SubscriptionMigrateResponseData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<SubscriptionMigrateResponseData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public SubscriptionMigrateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionMigrateResponse(SubscriptionMigrateResponse subscriptionMigrateResponse)
        : base(subscriptionMigrateResponse) { }
#pragma warning restore CS8618

    public SubscriptionMigrateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionMigrateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionMigrateResponseFromRaw.FromRawUnchecked"/>
    public static SubscriptionMigrateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SubscriptionMigrateResponse(SubscriptionMigrateResponseData data)
        : this()
    {
        this.Data = data;
    }
}

class SubscriptionMigrateResponseFromRaw : IFromRawJson<SubscriptionMigrateResponse>
{
    /// <inheritdoc/>
    public SubscriptionMigrateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionMigrateResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Customer subscription to a plan
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionMigrateResponseData,
        SubscriptionMigrateResponseDataFromRaw
    >)
)]
public sealed record class SubscriptionMigrateResponseData : JsonModel
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
        SubscriptionMigrateResponseDataPaymentCollection
    > PaymentCollection
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, SubscriptionMigrateResponseDataPaymentCollection>
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
    public required ApiEnum<string, SubscriptionMigrateResponseDataPricingType> PricingType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, SubscriptionMigrateResponseDataPricingType>
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
    public required ApiEnum<string, SubscriptionMigrateResponseDataStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, SubscriptionMigrateResponseDataStatus>
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
    public ApiEnum<string, SubscriptionMigrateResponseDataCancelReason>? CancelReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, SubscriptionMigrateResponseDataCancelReason>
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
        SubscriptionMigrateResponseDataPaymentCollectionMethod
    >? PaymentCollectionMethod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, SubscriptionMigrateResponseDataPaymentCollectionMethod>
            >("paymentCollectionMethod");
        }
        init { this._rawData.Set("paymentCollectionMethod", value); }
    }

    public IReadOnlyList<SubscriptionMigrateResponseDataPrice>? Prices
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<SubscriptionMigrateResponseDataPrice>
            >("prices");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<SubscriptionMigrateResponseDataPrice>?>(
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
    }

    public SubscriptionMigrateResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionMigrateResponseData(
        SubscriptionMigrateResponseData subscriptionMigrateResponseData
    )
        : base(subscriptionMigrateResponseData) { }
#pragma warning restore CS8618

    public SubscriptionMigrateResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionMigrateResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionMigrateResponseDataFromRaw.FromRawUnchecked"/>
    public static SubscriptionMigrateResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionMigrateResponseDataFromRaw : IFromRawJson<SubscriptionMigrateResponseData>
{
    /// <inheritdoc/>
    public SubscriptionMigrateResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionMigrateResponseData.FromRawUnchecked(rawData);
}

/// <summary>
/// Payment collection
/// </summary>
[JsonConverter(typeof(SubscriptionMigrateResponseDataPaymentCollectionConverter))]
public enum SubscriptionMigrateResponseDataPaymentCollection
{
    NotRequired,
    Processing,
    Failed,
    ActionRequired,
}

sealed class SubscriptionMigrateResponseDataPaymentCollectionConverter
    : JsonConverter<SubscriptionMigrateResponseDataPaymentCollection>
{
    public override SubscriptionMigrateResponseDataPaymentCollection Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "NOT_REQUIRED" => SubscriptionMigrateResponseDataPaymentCollection.NotRequired,
            "PROCESSING" => SubscriptionMigrateResponseDataPaymentCollection.Processing,
            "FAILED" => SubscriptionMigrateResponseDataPaymentCollection.Failed,
            "ACTION_REQUIRED" => SubscriptionMigrateResponseDataPaymentCollection.ActionRequired,
            _ => (SubscriptionMigrateResponseDataPaymentCollection)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionMigrateResponseDataPaymentCollection value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionMigrateResponseDataPaymentCollection.NotRequired => "NOT_REQUIRED",
                SubscriptionMigrateResponseDataPaymentCollection.Processing => "PROCESSING",
                SubscriptionMigrateResponseDataPaymentCollection.Failed => "FAILED",
                SubscriptionMigrateResponseDataPaymentCollection.ActionRequired =>
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
[JsonConverter(typeof(SubscriptionMigrateResponseDataPricingTypeConverter))]
public enum SubscriptionMigrateResponseDataPricingType
{
    Free,
    Paid,
    Custom,
}

sealed class SubscriptionMigrateResponseDataPricingTypeConverter
    : JsonConverter<SubscriptionMigrateResponseDataPricingType>
{
    public override SubscriptionMigrateResponseDataPricingType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FREE" => SubscriptionMigrateResponseDataPricingType.Free,
            "PAID" => SubscriptionMigrateResponseDataPricingType.Paid,
            "CUSTOM" => SubscriptionMigrateResponseDataPricingType.Custom,
            _ => (SubscriptionMigrateResponseDataPricingType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionMigrateResponseDataPricingType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionMigrateResponseDataPricingType.Free => "FREE",
                SubscriptionMigrateResponseDataPricingType.Paid => "PAID",
                SubscriptionMigrateResponseDataPricingType.Custom => "CUSTOM",
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
[JsonConverter(typeof(SubscriptionMigrateResponseDataStatusConverter))]
public enum SubscriptionMigrateResponseDataStatus
{
    PaymentPending,
    Active,
    Expired,
    InTrial,
    Canceled,
    NotStarted,
}

sealed class SubscriptionMigrateResponseDataStatusConverter
    : JsonConverter<SubscriptionMigrateResponseDataStatus>
{
    public override SubscriptionMigrateResponseDataStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PAYMENT_PENDING" => SubscriptionMigrateResponseDataStatus.PaymentPending,
            "ACTIVE" => SubscriptionMigrateResponseDataStatus.Active,
            "EXPIRED" => SubscriptionMigrateResponseDataStatus.Expired,
            "IN_TRIAL" => SubscriptionMigrateResponseDataStatus.InTrial,
            "CANCELED" => SubscriptionMigrateResponseDataStatus.Canceled,
            "NOT_STARTED" => SubscriptionMigrateResponseDataStatus.NotStarted,
            _ => (SubscriptionMigrateResponseDataStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionMigrateResponseDataStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionMigrateResponseDataStatus.PaymentPending => "PAYMENT_PENDING",
                SubscriptionMigrateResponseDataStatus.Active => "ACTIVE",
                SubscriptionMigrateResponseDataStatus.Expired => "EXPIRED",
                SubscriptionMigrateResponseDataStatus.InTrial => "IN_TRIAL",
                SubscriptionMigrateResponseDataStatus.Canceled => "CANCELED",
                SubscriptionMigrateResponseDataStatus.NotStarted => "NOT_STARTED",
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
[JsonConverter(typeof(SubscriptionMigrateResponseDataCancelReasonConverter))]
public enum SubscriptionMigrateResponseDataCancelReason
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

sealed class SubscriptionMigrateResponseDataCancelReasonConverter
    : JsonConverter<SubscriptionMigrateResponseDataCancelReason>
{
    public override SubscriptionMigrateResponseDataCancelReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "UPGRADE_OR_DOWNGRADE" =>
                SubscriptionMigrateResponseDataCancelReason.UpgradeOrDowngrade,
            "CANCELLED_BY_BILLING" =>
                SubscriptionMigrateResponseDataCancelReason.CancelledByBilling,
            "EXPIRED" => SubscriptionMigrateResponseDataCancelReason.Expired,
            "DETACH_BILLING" => SubscriptionMigrateResponseDataCancelReason.DetachBilling,
            "TRIAL_ENDED" => SubscriptionMigrateResponseDataCancelReason.TrialEnded,
            "Immediate" => SubscriptionMigrateResponseDataCancelReason.Immediate,
            "TRIAL_CONVERTED" => SubscriptionMigrateResponseDataCancelReason.TrialConverted,
            "PENDING_PAYMENT_EXPIRED" =>
                SubscriptionMigrateResponseDataCancelReason.PendingPaymentExpired,
            "ScheduledCancellation" =>
                SubscriptionMigrateResponseDataCancelReason.ScheduledCancellation,
            "CustomerArchived" => SubscriptionMigrateResponseDataCancelReason.CustomerArchived,
            "AutoCancellationRule" =>
                SubscriptionMigrateResponseDataCancelReason.AutoCancellationRule,
            _ => (SubscriptionMigrateResponseDataCancelReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionMigrateResponseDataCancelReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionMigrateResponseDataCancelReason.UpgradeOrDowngrade =>
                    "UPGRADE_OR_DOWNGRADE",
                SubscriptionMigrateResponseDataCancelReason.CancelledByBilling =>
                    "CANCELLED_BY_BILLING",
                SubscriptionMigrateResponseDataCancelReason.Expired => "EXPIRED",
                SubscriptionMigrateResponseDataCancelReason.DetachBilling => "DETACH_BILLING",
                SubscriptionMigrateResponseDataCancelReason.TrialEnded => "TRIAL_ENDED",
                SubscriptionMigrateResponseDataCancelReason.Immediate => "Immediate",
                SubscriptionMigrateResponseDataCancelReason.TrialConverted => "TRIAL_CONVERTED",
                SubscriptionMigrateResponseDataCancelReason.PendingPaymentExpired =>
                    "PENDING_PAYMENT_EXPIRED",
                SubscriptionMigrateResponseDataCancelReason.ScheduledCancellation =>
                    "ScheduledCancellation",
                SubscriptionMigrateResponseDataCancelReason.CustomerArchived => "CustomerArchived",
                SubscriptionMigrateResponseDataCancelReason.AutoCancellationRule =>
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
[JsonConverter(typeof(SubscriptionMigrateResponseDataPaymentCollectionMethodConverter))]
public enum SubscriptionMigrateResponseDataPaymentCollectionMethod
{
    Charge,
    Invoice,
    None,
}

sealed class SubscriptionMigrateResponseDataPaymentCollectionMethodConverter
    : JsonConverter<SubscriptionMigrateResponseDataPaymentCollectionMethod>
{
    public override SubscriptionMigrateResponseDataPaymentCollectionMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "CHARGE" => SubscriptionMigrateResponseDataPaymentCollectionMethod.Charge,
            "INVOICE" => SubscriptionMigrateResponseDataPaymentCollectionMethod.Invoice,
            "NONE" => SubscriptionMigrateResponseDataPaymentCollectionMethod.None,
            _ => (SubscriptionMigrateResponseDataPaymentCollectionMethod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionMigrateResponseDataPaymentCollectionMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionMigrateResponseDataPaymentCollectionMethod.Charge => "CHARGE",
                SubscriptionMigrateResponseDataPaymentCollectionMethod.Invoice => "INVOICE",
                SubscriptionMigrateResponseDataPaymentCollectionMethod.None => "NONE",
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
        SubscriptionMigrateResponseDataPrice,
        SubscriptionMigrateResponseDataPriceFromRaw
    >)
)]
public sealed record class SubscriptionMigrateResponseDataPrice : JsonModel
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

    public SubscriptionMigrateResponseDataPrice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionMigrateResponseDataPrice(
        SubscriptionMigrateResponseDataPrice subscriptionMigrateResponseDataPrice
    )
        : base(subscriptionMigrateResponseDataPrice) { }
#pragma warning restore CS8618

    public SubscriptionMigrateResponseDataPrice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionMigrateResponseDataPrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionMigrateResponseDataPriceFromRaw.FromRawUnchecked"/>
    public static SubscriptionMigrateResponseDataPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionMigrateResponseDataPriceFromRaw
    : IFromRawJson<SubscriptionMigrateResponseDataPrice>
{
    /// <inheritdoc/>
    public SubscriptionMigrateResponseDataPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionMigrateResponseDataPrice.FromRawUnchecked(rawData);
}
