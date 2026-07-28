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
    typeof(JsonModelConverter<SubscriptionSubscription, SubscriptionSubscriptionFromRaw>)
)]
public sealed record class SubscriptionSubscription : JsonModel
{
    /// <summary>
    /// Customer subscription to a plan
    /// </summary>
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

    public SubscriptionSubscription() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionSubscription(SubscriptionSubscription subscriptionSubscription)
        : base(subscriptionSubscription) { }
#pragma warning restore CS8618

    public SubscriptionSubscription(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionSubscription(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionSubscriptionFromRaw.FromRawUnchecked"/>
    public static SubscriptionSubscription FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SubscriptionSubscription(Data data)
        : this()
    {
        this.Data = data;
    }
}

class SubscriptionSubscriptionFromRaw : IFromRawJson<SubscriptionSubscription>
{
    /// <inheritdoc/>
    public SubscriptionSubscription FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionSubscription.FromRawUnchecked(rawData);
}

/// <summary>
/// Customer subscription to a plan
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
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
    public required ApiEnum<string, DataPricingType> PricingType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, DataPricingType>>("pricingType");
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
    public required ApiEnum<string, DataStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, DataStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    public IReadOnlyList<DataAddon>? Addons
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<DataAddon>>("addons");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<DataAddon>?>(
                "addons",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Billing cycle anchor date
    /// </summary>
    public System::DateTimeOffset? BillingCycleAnchor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("billingCycleAnchor");
        }
        init { this._rawData.Set("billingCycleAnchor", value); }
    }

    /// <summary>
    /// Budget configuration
    /// </summary>
    public DataBudget? Budget
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<DataBudget>("budget");
        }
        init { this._rawData.Set("budget", value); }
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
    /// The Stigg contract this subscription is linked to, when any
    /// </summary>
    public string? ContractID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("contractId");
        }
        init { this._rawData.Set("contractId", value); }
    }

    /// <summary>
    /// Coupons applied to the subscription
    /// </summary>
    public IReadOnlyList<Coupon>? Coupons
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Coupon>>("coupons");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Coupon>?>(
                "coupons",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
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
    /// Scheduled future updates for the subscription
    /// </summary>
    public IReadOnlyList<DataFutureUpdate>? FutureUpdates
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<DataFutureUpdate>>(
                "futureUpdates"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<DataFutureUpdate>?>(
                "futureUpdates",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Latest invoice for the subscription
    /// </summary>
    public LatestInvoice? LatestInvoice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<LatestInvoice>("latestInvoice");
        }
        init { this._rawData.Set("latestInvoice", value); }
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
    /// Minimum spend configuration
    /// </summary>
    public DataMinimumSpend? MinimumSpend
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<DataMinimumSpend>("minimumSpend");
        }
        init { this._rawData.Set("minimumSpend", value); }
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
    public ApiEnum<string, DataPaymentCollectionMethod>? PaymentCollectionMethod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, DataPaymentCollectionMethod>>(
                "paymentCollectionMethod"
            );
        }
        init { this._rawData.Set("paymentCollectionMethod", value); }
    }

    public IReadOnlyList<Price>? Prices
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Price>>("prices");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Price>?>(
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
    /// Entitlements associated with the subscription
    /// </summary>
    public IReadOnlyList<SubscriptionEntitlement>? SubscriptionEntitlements
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<SubscriptionEntitlement>>(
                "subscriptionEntitlements"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<SubscriptionEntitlement>?>(
                "subscriptionEntitlements",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Trial configuration
    /// </summary>
    public Trial? Trial
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Trial>("trial");
        }
        init { this._rawData.Set("trial", value); }
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
        foreach (var item in this.Addons ?? [])
        {
            item.Validate();
        }
        _ = this.BillingCycleAnchor;
        this.Budget?.Validate();
        _ = this.CancellationDate;
        this.CancelReason?.Validate();
        _ = this.ContractID;
        foreach (var item in this.Coupons ?? [])
        {
            item.Validate();
        }
        _ = this.CurrentBillingPeriodEnd;
        _ = this.CurrentBillingPeriodStart;
        _ = this.EffectiveEndDate;
        _ = this.EndDate;
        foreach (var item in this.FutureUpdates ?? [])
        {
            item.Validate();
        }
        this.LatestInvoice?.Validate();
        _ = this.Metadata;
        this.MinimumSpend?.Validate();
        _ = this.PayingCustomerID;
        this.PaymentCollectionMethod?.Validate();
        foreach (var item in this.Prices ?? [])
        {
            item.Validate();
        }
        _ = this.ResourceID;
        foreach (var item in this.SubscriptionEntitlements ?? [])
        {
            item.Validate();
        }
        this.Trial?.Validate();
        _ = this.TrialEndDate;
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
[JsonConverter(typeof(DataPricingTypeConverter))]
public enum DataPricingType
{
    Free,
    Paid,
    Custom,
}

sealed class DataPricingTypeConverter : JsonConverter<DataPricingType>
{
    public override DataPricingType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FREE" => DataPricingType.Free,
            "PAID" => DataPricingType.Paid,
            "CUSTOM" => DataPricingType.Custom,
            _ => (DataPricingType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DataPricingType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DataPricingType.Free => "FREE",
                DataPricingType.Paid => "PAID",
                DataPricingType.Custom => "CUSTOM",
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
[JsonConverter(typeof(DataStatusConverter))]
public enum DataStatus
{
    PaymentPending,
    Active,
    Expired,
    InTrial,
    Canceled,
    NotStarted,
}

sealed class DataStatusConverter : JsonConverter<DataStatus>
{
    public override DataStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PAYMENT_PENDING" => DataStatus.PaymentPending,
            "ACTIVE" => DataStatus.Active,
            "EXPIRED" => DataStatus.Expired,
            "IN_TRIAL" => DataStatus.InTrial,
            "CANCELED" => DataStatus.Canceled,
            "NOT_STARTED" => DataStatus.NotStarted,
            _ => (DataStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DataStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DataStatus.PaymentPending => "PAYMENT_PENDING",
                DataStatus.Active => "ACTIVE",
                DataStatus.Expired => "EXPIRED",
                DataStatus.InTrial => "IN_TRIAL",
                DataStatus.Canceled => "CANCELED",
                DataStatus.NotStarted => "NOT_STARTED",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Addon configuration
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DataAddon, DataAddonFromRaw>))]
public sealed record class DataAddon : JsonModel
{
    /// <summary>
    /// Addon ID
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
    /// Number of addon instances
    /// </summary>
    public required long Quantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("quantity");
        }
        init { this._rawData.Set("quantity", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Quantity;
    }

    public DataAddon() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DataAddon(DataAddon dataAddon)
        : base(dataAddon) { }
#pragma warning restore CS8618

    public DataAddon(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DataAddon(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataAddonFromRaw.FromRawUnchecked"/>
    public static DataAddon FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataAddonFromRaw : IFromRawJson<DataAddon>
{
    /// <inheritdoc/>
    public DataAddon FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DataAddon.FromRawUnchecked(rawData);
}

/// <summary>
/// Budget configuration
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DataBudget, DataBudgetFromRaw>))]
public sealed record class DataBudget : JsonModel
{
    /// <summary>
    /// Whether the budget is a soft limit
    /// </summary>
    public required bool HasSoftLimit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("hasSoftLimit");
        }
        init { this._rawData.Set("hasSoftLimit", value); }
    }

    /// <summary>
    /// Maximum spending limit
    /// </summary>
    public required double Limit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("limit");
        }
        init { this._rawData.Set("limit", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.HasSoftLimit;
        _ = this.Limit;
    }

    public DataBudget() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DataBudget(DataBudget dataBudget)
        : base(dataBudget) { }
#pragma warning restore CS8618

    public DataBudget(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DataBudget(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataBudgetFromRaw.FromRawUnchecked"/>
    public static DataBudget FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataBudgetFromRaw : IFromRawJson<DataBudget>
{
    /// <inheritdoc/>
    public DataBudget FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DataBudget.FromRawUnchecked(rawData);
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
/// Coupon applied to a subscription
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Coupon, CouponFromRaw>))]
public sealed record class Coupon : JsonModel
{
    /// <summary>
    /// Coupon ID
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
    /// Coupon name
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Coupon status
    /// </summary>
    public required ApiEnum<string, CouponStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CouponStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Fixed amount discounts by currency
    /// </summary>
    public IReadOnlyList<CouponAmountsOff>? AmountsOff
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<CouponAmountsOff>>("amountsOff");
        }
        init
        {
            this._rawData.Set<ImmutableArray<CouponAmountsOff>?>(
                "amountsOff",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Percentage discount
    /// </summary>
    public double? PercentOff
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("percentOff");
        }
        init { this._rawData.Set("percentOff", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
        this.Status.Validate();
        foreach (var item in this.AmountsOff ?? [])
        {
            item.Validate();
        }
        _ = this.PercentOff;
    }

    public Coupon() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Coupon(Coupon coupon)
        : base(coupon) { }
#pragma warning restore CS8618

    public Coupon(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Coupon(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CouponFromRaw.FromRawUnchecked"/>
    public static Coupon FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CouponFromRaw : IFromRawJson<Coupon>
{
    /// <inheritdoc/>
    public Coupon FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Coupon.FromRawUnchecked(rawData);
}

/// <summary>
/// Coupon status
/// </summary>
[JsonConverter(typeof(CouponStatusConverter))]
public enum CouponStatus
{
    Active,
    Expired,
    Removed,
}

sealed class CouponStatusConverter : JsonConverter<CouponStatus>
{
    public override CouponStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ACTIVE" => CouponStatus.Active,
            "EXPIRED" => CouponStatus.Expired,
            "REMOVED" => CouponStatus.Removed,
            _ => (CouponStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CouponStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CouponStatus.Active => "ACTIVE",
                CouponStatus.Expired => "EXPIRED",
                CouponStatus.Removed => "REMOVED",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<CouponAmountsOff, CouponAmountsOffFromRaw>))]
public sealed record class CouponAmountsOff : JsonModel
{
    /// <summary>
    /// The price amount
    /// </summary>
    public double? Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("amount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("amount", value);
        }
    }

    /// <summary>
    /// The price currency
    /// </summary>
    public ApiEnum<string, CouponAmountsOffCurrency>? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CouponAmountsOffCurrency>>(
                "currency"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("currency", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        this.Currency?.Validate();
    }

    public CouponAmountsOff() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CouponAmountsOff(CouponAmountsOff couponAmountsOff)
        : base(couponAmountsOff) { }
#pragma warning restore CS8618

    public CouponAmountsOff(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CouponAmountsOff(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CouponAmountsOffFromRaw.FromRawUnchecked"/>
    public static CouponAmountsOff FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CouponAmountsOffFromRaw : IFromRawJson<CouponAmountsOff>
{
    /// <inheritdoc/>
    public CouponAmountsOff FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CouponAmountsOff.FromRawUnchecked(rawData);
}

/// <summary>
/// The price currency
/// </summary>
[JsonConverter(typeof(CouponAmountsOffCurrencyConverter))]
public enum CouponAmountsOffCurrency
{
    Usd,
    Aed,
    All,
    Amd,
    Ang,
    Aud,
    Awg,
    Azn,
    Bam,
    Bbd,
    Bdt,
    Bgn,
    Bif,
    Bmd,
    Bnd,
    Bsd,
    Bwp,
    Byn,
    Bzd,
    Brl,
    Cad,
    Cdf,
    Chf,
    Cny,
    Czk,
    Dkk,
    Dop,
    Dzd,
    Egp,
    Etb,
    Eur,
    Fjd,
    Gbp,
    Gel,
    Gip,
    Gmd,
    Gyd,
    Hkd,
    Hrk,
    Htg,
    Idr,
    Ils,
    Inr,
    Isk,
    Jmd,
    Jpy,
    Kes,
    Kgs,
    Khr,
    Kmf,
    Krw,
    Kyd,
    Kzt,
    Lbp,
    Lkr,
    Lrd,
    Lsl,
    Mad,
    Mdl,
    Mga,
    Mkd,
    Mmk,
    Mnt,
    Mop,
    Mro,
    Mvr,
    Mwk,
    Mxn,
    Myr,
    Mzn,
    Nad,
    Ngn,
    Nok,
    Npr,
    Nzd,
    Pgk,
    Php,
    Pkr,
    Pln,
    Qar,
    Ron,
    Rsd,
    Rub,
    Rwf,
    Sar,
    Sbd,
    Scr,
    Sek,
    Sgd,
    Sle,
    Sll,
    Sos,
    Szl,
    Thb,
    Tjs,
    Top,
    Try,
    Ttd,
    Tzs,
    Uah,
    Uzs,
    Vnd,
    Vuv,
    Wst,
    Xaf,
    Xcd,
    Yer,
    Zar,
    Zmw,
    Clp,
    Djf,
    Gnf,
    Ugx,
    Pyg,
    Xof,
    Xpf,
}

sealed class CouponAmountsOffCurrencyConverter : JsonConverter<CouponAmountsOffCurrency>
{
    public override CouponAmountsOffCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => CouponAmountsOffCurrency.Usd,
            "aed" => CouponAmountsOffCurrency.Aed,
            "all" => CouponAmountsOffCurrency.All,
            "amd" => CouponAmountsOffCurrency.Amd,
            "ang" => CouponAmountsOffCurrency.Ang,
            "aud" => CouponAmountsOffCurrency.Aud,
            "awg" => CouponAmountsOffCurrency.Awg,
            "azn" => CouponAmountsOffCurrency.Azn,
            "bam" => CouponAmountsOffCurrency.Bam,
            "bbd" => CouponAmountsOffCurrency.Bbd,
            "bdt" => CouponAmountsOffCurrency.Bdt,
            "bgn" => CouponAmountsOffCurrency.Bgn,
            "bif" => CouponAmountsOffCurrency.Bif,
            "bmd" => CouponAmountsOffCurrency.Bmd,
            "bnd" => CouponAmountsOffCurrency.Bnd,
            "bsd" => CouponAmountsOffCurrency.Bsd,
            "bwp" => CouponAmountsOffCurrency.Bwp,
            "byn" => CouponAmountsOffCurrency.Byn,
            "bzd" => CouponAmountsOffCurrency.Bzd,
            "brl" => CouponAmountsOffCurrency.Brl,
            "cad" => CouponAmountsOffCurrency.Cad,
            "cdf" => CouponAmountsOffCurrency.Cdf,
            "chf" => CouponAmountsOffCurrency.Chf,
            "cny" => CouponAmountsOffCurrency.Cny,
            "czk" => CouponAmountsOffCurrency.Czk,
            "dkk" => CouponAmountsOffCurrency.Dkk,
            "dop" => CouponAmountsOffCurrency.Dop,
            "dzd" => CouponAmountsOffCurrency.Dzd,
            "egp" => CouponAmountsOffCurrency.Egp,
            "etb" => CouponAmountsOffCurrency.Etb,
            "eur" => CouponAmountsOffCurrency.Eur,
            "fjd" => CouponAmountsOffCurrency.Fjd,
            "gbp" => CouponAmountsOffCurrency.Gbp,
            "gel" => CouponAmountsOffCurrency.Gel,
            "gip" => CouponAmountsOffCurrency.Gip,
            "gmd" => CouponAmountsOffCurrency.Gmd,
            "gyd" => CouponAmountsOffCurrency.Gyd,
            "hkd" => CouponAmountsOffCurrency.Hkd,
            "hrk" => CouponAmountsOffCurrency.Hrk,
            "htg" => CouponAmountsOffCurrency.Htg,
            "idr" => CouponAmountsOffCurrency.Idr,
            "ils" => CouponAmountsOffCurrency.Ils,
            "inr" => CouponAmountsOffCurrency.Inr,
            "isk" => CouponAmountsOffCurrency.Isk,
            "jmd" => CouponAmountsOffCurrency.Jmd,
            "jpy" => CouponAmountsOffCurrency.Jpy,
            "kes" => CouponAmountsOffCurrency.Kes,
            "kgs" => CouponAmountsOffCurrency.Kgs,
            "khr" => CouponAmountsOffCurrency.Khr,
            "kmf" => CouponAmountsOffCurrency.Kmf,
            "krw" => CouponAmountsOffCurrency.Krw,
            "kyd" => CouponAmountsOffCurrency.Kyd,
            "kzt" => CouponAmountsOffCurrency.Kzt,
            "lbp" => CouponAmountsOffCurrency.Lbp,
            "lkr" => CouponAmountsOffCurrency.Lkr,
            "lrd" => CouponAmountsOffCurrency.Lrd,
            "lsl" => CouponAmountsOffCurrency.Lsl,
            "mad" => CouponAmountsOffCurrency.Mad,
            "mdl" => CouponAmountsOffCurrency.Mdl,
            "mga" => CouponAmountsOffCurrency.Mga,
            "mkd" => CouponAmountsOffCurrency.Mkd,
            "mmk" => CouponAmountsOffCurrency.Mmk,
            "mnt" => CouponAmountsOffCurrency.Mnt,
            "mop" => CouponAmountsOffCurrency.Mop,
            "mro" => CouponAmountsOffCurrency.Mro,
            "mvr" => CouponAmountsOffCurrency.Mvr,
            "mwk" => CouponAmountsOffCurrency.Mwk,
            "mxn" => CouponAmountsOffCurrency.Mxn,
            "myr" => CouponAmountsOffCurrency.Myr,
            "mzn" => CouponAmountsOffCurrency.Mzn,
            "nad" => CouponAmountsOffCurrency.Nad,
            "ngn" => CouponAmountsOffCurrency.Ngn,
            "nok" => CouponAmountsOffCurrency.Nok,
            "npr" => CouponAmountsOffCurrency.Npr,
            "nzd" => CouponAmountsOffCurrency.Nzd,
            "pgk" => CouponAmountsOffCurrency.Pgk,
            "php" => CouponAmountsOffCurrency.Php,
            "pkr" => CouponAmountsOffCurrency.Pkr,
            "pln" => CouponAmountsOffCurrency.Pln,
            "qar" => CouponAmountsOffCurrency.Qar,
            "ron" => CouponAmountsOffCurrency.Ron,
            "rsd" => CouponAmountsOffCurrency.Rsd,
            "rub" => CouponAmountsOffCurrency.Rub,
            "rwf" => CouponAmountsOffCurrency.Rwf,
            "sar" => CouponAmountsOffCurrency.Sar,
            "sbd" => CouponAmountsOffCurrency.Sbd,
            "scr" => CouponAmountsOffCurrency.Scr,
            "sek" => CouponAmountsOffCurrency.Sek,
            "sgd" => CouponAmountsOffCurrency.Sgd,
            "sle" => CouponAmountsOffCurrency.Sle,
            "sll" => CouponAmountsOffCurrency.Sll,
            "sos" => CouponAmountsOffCurrency.Sos,
            "szl" => CouponAmountsOffCurrency.Szl,
            "thb" => CouponAmountsOffCurrency.Thb,
            "tjs" => CouponAmountsOffCurrency.Tjs,
            "top" => CouponAmountsOffCurrency.Top,
            "try" => CouponAmountsOffCurrency.Try,
            "ttd" => CouponAmountsOffCurrency.Ttd,
            "tzs" => CouponAmountsOffCurrency.Tzs,
            "uah" => CouponAmountsOffCurrency.Uah,
            "uzs" => CouponAmountsOffCurrency.Uzs,
            "vnd" => CouponAmountsOffCurrency.Vnd,
            "vuv" => CouponAmountsOffCurrency.Vuv,
            "wst" => CouponAmountsOffCurrency.Wst,
            "xaf" => CouponAmountsOffCurrency.Xaf,
            "xcd" => CouponAmountsOffCurrency.Xcd,
            "yer" => CouponAmountsOffCurrency.Yer,
            "zar" => CouponAmountsOffCurrency.Zar,
            "zmw" => CouponAmountsOffCurrency.Zmw,
            "clp" => CouponAmountsOffCurrency.Clp,
            "djf" => CouponAmountsOffCurrency.Djf,
            "gnf" => CouponAmountsOffCurrency.Gnf,
            "ugx" => CouponAmountsOffCurrency.Ugx,
            "pyg" => CouponAmountsOffCurrency.Pyg,
            "xof" => CouponAmountsOffCurrency.Xof,
            "xpf" => CouponAmountsOffCurrency.Xpf,
            _ => (CouponAmountsOffCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CouponAmountsOffCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CouponAmountsOffCurrency.Usd => "usd",
                CouponAmountsOffCurrency.Aed => "aed",
                CouponAmountsOffCurrency.All => "all",
                CouponAmountsOffCurrency.Amd => "amd",
                CouponAmountsOffCurrency.Ang => "ang",
                CouponAmountsOffCurrency.Aud => "aud",
                CouponAmountsOffCurrency.Awg => "awg",
                CouponAmountsOffCurrency.Azn => "azn",
                CouponAmountsOffCurrency.Bam => "bam",
                CouponAmountsOffCurrency.Bbd => "bbd",
                CouponAmountsOffCurrency.Bdt => "bdt",
                CouponAmountsOffCurrency.Bgn => "bgn",
                CouponAmountsOffCurrency.Bif => "bif",
                CouponAmountsOffCurrency.Bmd => "bmd",
                CouponAmountsOffCurrency.Bnd => "bnd",
                CouponAmountsOffCurrency.Bsd => "bsd",
                CouponAmountsOffCurrency.Bwp => "bwp",
                CouponAmountsOffCurrency.Byn => "byn",
                CouponAmountsOffCurrency.Bzd => "bzd",
                CouponAmountsOffCurrency.Brl => "brl",
                CouponAmountsOffCurrency.Cad => "cad",
                CouponAmountsOffCurrency.Cdf => "cdf",
                CouponAmountsOffCurrency.Chf => "chf",
                CouponAmountsOffCurrency.Cny => "cny",
                CouponAmountsOffCurrency.Czk => "czk",
                CouponAmountsOffCurrency.Dkk => "dkk",
                CouponAmountsOffCurrency.Dop => "dop",
                CouponAmountsOffCurrency.Dzd => "dzd",
                CouponAmountsOffCurrency.Egp => "egp",
                CouponAmountsOffCurrency.Etb => "etb",
                CouponAmountsOffCurrency.Eur => "eur",
                CouponAmountsOffCurrency.Fjd => "fjd",
                CouponAmountsOffCurrency.Gbp => "gbp",
                CouponAmountsOffCurrency.Gel => "gel",
                CouponAmountsOffCurrency.Gip => "gip",
                CouponAmountsOffCurrency.Gmd => "gmd",
                CouponAmountsOffCurrency.Gyd => "gyd",
                CouponAmountsOffCurrency.Hkd => "hkd",
                CouponAmountsOffCurrency.Hrk => "hrk",
                CouponAmountsOffCurrency.Htg => "htg",
                CouponAmountsOffCurrency.Idr => "idr",
                CouponAmountsOffCurrency.Ils => "ils",
                CouponAmountsOffCurrency.Inr => "inr",
                CouponAmountsOffCurrency.Isk => "isk",
                CouponAmountsOffCurrency.Jmd => "jmd",
                CouponAmountsOffCurrency.Jpy => "jpy",
                CouponAmountsOffCurrency.Kes => "kes",
                CouponAmountsOffCurrency.Kgs => "kgs",
                CouponAmountsOffCurrency.Khr => "khr",
                CouponAmountsOffCurrency.Kmf => "kmf",
                CouponAmountsOffCurrency.Krw => "krw",
                CouponAmountsOffCurrency.Kyd => "kyd",
                CouponAmountsOffCurrency.Kzt => "kzt",
                CouponAmountsOffCurrency.Lbp => "lbp",
                CouponAmountsOffCurrency.Lkr => "lkr",
                CouponAmountsOffCurrency.Lrd => "lrd",
                CouponAmountsOffCurrency.Lsl => "lsl",
                CouponAmountsOffCurrency.Mad => "mad",
                CouponAmountsOffCurrency.Mdl => "mdl",
                CouponAmountsOffCurrency.Mga => "mga",
                CouponAmountsOffCurrency.Mkd => "mkd",
                CouponAmountsOffCurrency.Mmk => "mmk",
                CouponAmountsOffCurrency.Mnt => "mnt",
                CouponAmountsOffCurrency.Mop => "mop",
                CouponAmountsOffCurrency.Mro => "mro",
                CouponAmountsOffCurrency.Mvr => "mvr",
                CouponAmountsOffCurrency.Mwk => "mwk",
                CouponAmountsOffCurrency.Mxn => "mxn",
                CouponAmountsOffCurrency.Myr => "myr",
                CouponAmountsOffCurrency.Mzn => "mzn",
                CouponAmountsOffCurrency.Nad => "nad",
                CouponAmountsOffCurrency.Ngn => "ngn",
                CouponAmountsOffCurrency.Nok => "nok",
                CouponAmountsOffCurrency.Npr => "npr",
                CouponAmountsOffCurrency.Nzd => "nzd",
                CouponAmountsOffCurrency.Pgk => "pgk",
                CouponAmountsOffCurrency.Php => "php",
                CouponAmountsOffCurrency.Pkr => "pkr",
                CouponAmountsOffCurrency.Pln => "pln",
                CouponAmountsOffCurrency.Qar => "qar",
                CouponAmountsOffCurrency.Ron => "ron",
                CouponAmountsOffCurrency.Rsd => "rsd",
                CouponAmountsOffCurrency.Rub => "rub",
                CouponAmountsOffCurrency.Rwf => "rwf",
                CouponAmountsOffCurrency.Sar => "sar",
                CouponAmountsOffCurrency.Sbd => "sbd",
                CouponAmountsOffCurrency.Scr => "scr",
                CouponAmountsOffCurrency.Sek => "sek",
                CouponAmountsOffCurrency.Sgd => "sgd",
                CouponAmountsOffCurrency.Sle => "sle",
                CouponAmountsOffCurrency.Sll => "sll",
                CouponAmountsOffCurrency.Sos => "sos",
                CouponAmountsOffCurrency.Szl => "szl",
                CouponAmountsOffCurrency.Thb => "thb",
                CouponAmountsOffCurrency.Tjs => "tjs",
                CouponAmountsOffCurrency.Top => "top",
                CouponAmountsOffCurrency.Try => "try",
                CouponAmountsOffCurrency.Ttd => "ttd",
                CouponAmountsOffCurrency.Tzs => "tzs",
                CouponAmountsOffCurrency.Uah => "uah",
                CouponAmountsOffCurrency.Uzs => "uzs",
                CouponAmountsOffCurrency.Vnd => "vnd",
                CouponAmountsOffCurrency.Vuv => "vuv",
                CouponAmountsOffCurrency.Wst => "wst",
                CouponAmountsOffCurrency.Xaf => "xaf",
                CouponAmountsOffCurrency.Xcd => "xcd",
                CouponAmountsOffCurrency.Yer => "yer",
                CouponAmountsOffCurrency.Zar => "zar",
                CouponAmountsOffCurrency.Zmw => "zmw",
                CouponAmountsOffCurrency.Clp => "clp",
                CouponAmountsOffCurrency.Djf => "djf",
                CouponAmountsOffCurrency.Gnf => "gnf",
                CouponAmountsOffCurrency.Ugx => "ugx",
                CouponAmountsOffCurrency.Pyg => "pyg",
                CouponAmountsOffCurrency.Xof => "xof",
                CouponAmountsOffCurrency.Xpf => "xpf",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Scheduled subscription update
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DataFutureUpdate, DataFutureUpdateFromRaw>))]
public sealed record class DataFutureUpdate : JsonModel
{
    /// <summary>
    /// Scheduled execution time
    /// </summary>
    public required System::DateTimeOffset ScheduledExecutionTime
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("scheduledExecutionTime");
        }
        init { this._rawData.Set("scheduledExecutionTime", value); }
    }

    /// <summary>
    /// Status of the scheduled update
    /// </summary>
    public required ApiEnum<string, ScheduleStatus> ScheduleStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ScheduleStatus>>("scheduleStatus");
        }
        init { this._rawData.Set("scheduleStatus", value); }
    }

    /// <summary>
    /// Type of scheduled change
    /// </summary>
    public required ApiEnum<string, SubscriptionScheduleType> SubscriptionScheduleType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, SubscriptionScheduleType>>(
                "subscriptionScheduleType"
            );
        }
        init { this._rawData.Set("subscriptionScheduleType", value); }
    }

    /// <summary>
    /// Target package for the update
    /// </summary>
    public TargetPackage? TargetPackage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TargetPackage>("targetPackage");
        }
        init { this._rawData.Set("targetPackage", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ScheduledExecutionTime;
        this.ScheduleStatus.Validate();
        this.SubscriptionScheduleType.Validate();
        this.TargetPackage?.Validate();
    }

    public DataFutureUpdate() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DataFutureUpdate(DataFutureUpdate dataFutureUpdate)
        : base(dataFutureUpdate) { }
#pragma warning restore CS8618

    public DataFutureUpdate(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DataFutureUpdate(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataFutureUpdateFromRaw.FromRawUnchecked"/>
    public static DataFutureUpdate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataFutureUpdateFromRaw : IFromRawJson<DataFutureUpdate>
{
    /// <inheritdoc/>
    public DataFutureUpdate FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DataFutureUpdate.FromRawUnchecked(rawData);
}

/// <summary>
/// Status of the scheduled update
/// </summary>
[JsonConverter(typeof(ScheduleStatusConverter))]
public enum ScheduleStatus
{
    PendingPayment,
    Scheduled,
    Canceled,
    Done,
    Failed,
}

sealed class ScheduleStatusConverter : JsonConverter<ScheduleStatus>
{
    public override ScheduleStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PENDING_PAYMENT" => ScheduleStatus.PendingPayment,
            "SCHEDULED" => ScheduleStatus.Scheduled,
            "CANCELED" => ScheduleStatus.Canceled,
            "DONE" => ScheduleStatus.Done,
            "FAILED" => ScheduleStatus.Failed,
            _ => (ScheduleStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ScheduleStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ScheduleStatus.PendingPayment => "PENDING_PAYMENT",
                ScheduleStatus.Scheduled => "SCHEDULED",
                ScheduleStatus.Canceled => "CANCELED",
                ScheduleStatus.Done => "DONE",
                ScheduleStatus.Failed => "FAILED",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Type of scheduled change
/// </summary>
[JsonConverter(typeof(SubscriptionScheduleTypeConverter))]
public enum SubscriptionScheduleType
{
    Downgrade,
    Plan,
    BillingPeriod,
    UnitAmount,
    RecurringCredits,
    PriceOverride,
    Addon,
    Coupon,
    MigrateToLatest,
    AdditionalMetaData,
    BillingInfoMetadata,
}

sealed class SubscriptionScheduleTypeConverter : JsonConverter<SubscriptionScheduleType>
{
    public override SubscriptionScheduleType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "DOWNGRADE" => SubscriptionScheduleType.Downgrade,
            "PLAN" => SubscriptionScheduleType.Plan,
            "BILLING_PERIOD" => SubscriptionScheduleType.BillingPeriod,
            "UNIT_AMOUNT" => SubscriptionScheduleType.UnitAmount,
            "RECURRING_CREDITS" => SubscriptionScheduleType.RecurringCredits,
            "PRICE_OVERRIDE" => SubscriptionScheduleType.PriceOverride,
            "ADDON" => SubscriptionScheduleType.Addon,
            "COUPON" => SubscriptionScheduleType.Coupon,
            "MIGRATE_TO_LATEST" => SubscriptionScheduleType.MigrateToLatest,
            "ADDITIONAL_META_DATA" => SubscriptionScheduleType.AdditionalMetaData,
            "BILLING_INFO_METADATA" => SubscriptionScheduleType.BillingInfoMetadata,
            _ => (SubscriptionScheduleType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionScheduleType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionScheduleType.Downgrade => "DOWNGRADE",
                SubscriptionScheduleType.Plan => "PLAN",
                SubscriptionScheduleType.BillingPeriod => "BILLING_PERIOD",
                SubscriptionScheduleType.UnitAmount => "UNIT_AMOUNT",
                SubscriptionScheduleType.RecurringCredits => "RECURRING_CREDITS",
                SubscriptionScheduleType.PriceOverride => "PRICE_OVERRIDE",
                SubscriptionScheduleType.Addon => "ADDON",
                SubscriptionScheduleType.Coupon => "COUPON",
                SubscriptionScheduleType.MigrateToLatest => "MIGRATE_TO_LATEST",
                SubscriptionScheduleType.AdditionalMetaData => "ADDITIONAL_META_DATA",
                SubscriptionScheduleType.BillingInfoMetadata => "BILLING_INFO_METADATA",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Target package for the update
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TargetPackage, TargetPackageFromRaw>))]
public sealed record class TargetPackage : JsonModel
{
    /// <summary>
    /// Target package for the update
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
    }

    public TargetPackage() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TargetPackage(TargetPackage targetPackage)
        : base(targetPackage) { }
#pragma warning restore CS8618

    public TargetPackage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TargetPackage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TargetPackageFromRaw.FromRawUnchecked"/>
    public static TargetPackage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TargetPackage(string id)
        : this()
    {
        this.ID = id;
    }
}

class TargetPackageFromRaw : IFromRawJson<TargetPackage>
{
    /// <inheritdoc/>
    public TargetPackage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TargetPackage.FromRawUnchecked(rawData);
}

/// <summary>
/// Latest invoice for the subscription
/// </summary>
[JsonConverter(typeof(JsonModelConverter<LatestInvoice, LatestInvoiceFromRaw>))]
public sealed record class LatestInvoice : JsonModel
{
    /// <summary>
    /// Invoice billing ID
    /// </summary>
    public required string BillingID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("billingId");
        }
        init { this._rawData.Set("billingId", value); }
    }

    /// <summary>
    /// Invoice creation date
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
    /// Whether payment requires action
    /// </summary>
    public required bool RequiresAction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("requiresAction");
        }
        init { this._rawData.Set("requiresAction", value); }
    }

    /// <summary>
    /// Invoice status
    /// </summary>
    public required ApiEnum<string, LatestInvoiceStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, LatestInvoiceStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Amount due
    /// </summary>
    public double? AmountDue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("amountDue");
        }
        init { this._rawData.Set("amountDue", value); }
    }

    /// <summary>
    /// Billing reason
    /// </summary>
    public ApiEnum<string, BillingReason>? BillingReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, BillingReason>>("billingReason");
        }
        init { this._rawData.Set("billingReason", value); }
    }

    /// <summary>
    /// Invoice currency
    /// </summary>
    public string? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// Invoice PDF URL
    /// </summary>
    public string? PdfUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("pdfUrl");
        }
        init { this._rawData.Set("pdfUrl", value); }
    }

    /// <summary>
    /// Total amount
    /// </summary>
    public double? Total
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("total");
        }
        init { this._rawData.Set("total", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BillingID;
        _ = this.CreatedAt;
        _ = this.RequiresAction;
        this.Status.Validate();
        _ = this.AmountDue;
        this.BillingReason?.Validate();
        _ = this.Currency;
        _ = this.PdfUrl;
        _ = this.Total;
    }

    public LatestInvoice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LatestInvoice(LatestInvoice latestInvoice)
        : base(latestInvoice) { }
#pragma warning restore CS8618

    public LatestInvoice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LatestInvoice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LatestInvoiceFromRaw.FromRawUnchecked"/>
    public static LatestInvoice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LatestInvoiceFromRaw : IFromRawJson<LatestInvoice>
{
    /// <inheritdoc/>
    public LatestInvoice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        LatestInvoice.FromRawUnchecked(rawData);
}

/// <summary>
/// Invoice status
/// </summary>
[JsonConverter(typeof(LatestInvoiceStatusConverter))]
public enum LatestInvoiceStatus
{
    Open,
    Canceled,
    Paid,
}

sealed class LatestInvoiceStatusConverter : JsonConverter<LatestInvoiceStatus>
{
    public override LatestInvoiceStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "OPEN" => LatestInvoiceStatus.Open,
            "CANCELED" => LatestInvoiceStatus.Canceled,
            "PAID" => LatestInvoiceStatus.Paid,
            _ => (LatestInvoiceStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        LatestInvoiceStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                LatestInvoiceStatus.Open => "OPEN",
                LatestInvoiceStatus.Canceled => "CANCELED",
                LatestInvoiceStatus.Paid => "PAID",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Billing reason
/// </summary>
[JsonConverter(typeof(BillingReasonConverter))]
public enum BillingReason
{
    BillingCycle,
    SubscriptionCreation,
    SubscriptionUpdate,
    Manual,
    MinimumInvoiceAmountExceeded,
    Other,
}

sealed class BillingReasonConverter : JsonConverter<BillingReason>
{
    public override BillingReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "BILLING_CYCLE" => BillingReason.BillingCycle,
            "SUBSCRIPTION_CREATION" => BillingReason.SubscriptionCreation,
            "SUBSCRIPTION_UPDATE" => BillingReason.SubscriptionUpdate,
            "MANUAL" => BillingReason.Manual,
            "MINIMUM_INVOICE_AMOUNT_EXCEEDED" => BillingReason.MinimumInvoiceAmountExceeded,
            "OTHER" => BillingReason.Other,
            _ => (BillingReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BillingReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BillingReason.BillingCycle => "BILLING_CYCLE",
                BillingReason.SubscriptionCreation => "SUBSCRIPTION_CREATION",
                BillingReason.SubscriptionUpdate => "SUBSCRIPTION_UPDATE",
                BillingReason.Manual => "MANUAL",
                BillingReason.MinimumInvoiceAmountExceeded => "MINIMUM_INVOICE_AMOUNT_EXCEEDED",
                BillingReason.Other => "OTHER",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Minimum spend configuration
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DataMinimumSpend, DataMinimumSpendFromRaw>))]
public sealed record class DataMinimumSpend : JsonModel
{
    /// <summary>
    /// The price amount
    /// </summary>
    public double? Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("amount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("amount", value);
        }
    }

    /// <summary>
    /// The price currency
    /// </summary>
    public ApiEnum<string, DataMinimumSpendCurrency>? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, DataMinimumSpendCurrency>>(
                "currency"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("currency", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        this.Currency?.Validate();
    }

    public DataMinimumSpend() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DataMinimumSpend(DataMinimumSpend dataMinimumSpend)
        : base(dataMinimumSpend) { }
#pragma warning restore CS8618

    public DataMinimumSpend(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DataMinimumSpend(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataMinimumSpendFromRaw.FromRawUnchecked"/>
    public static DataMinimumSpend FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataMinimumSpendFromRaw : IFromRawJson<DataMinimumSpend>
{
    /// <inheritdoc/>
    public DataMinimumSpend FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DataMinimumSpend.FromRawUnchecked(rawData);
}

/// <summary>
/// The price currency
/// </summary>
[JsonConverter(typeof(DataMinimumSpendCurrencyConverter))]
public enum DataMinimumSpendCurrency
{
    Usd,
    Aed,
    All,
    Amd,
    Ang,
    Aud,
    Awg,
    Azn,
    Bam,
    Bbd,
    Bdt,
    Bgn,
    Bif,
    Bmd,
    Bnd,
    Bsd,
    Bwp,
    Byn,
    Bzd,
    Brl,
    Cad,
    Cdf,
    Chf,
    Cny,
    Czk,
    Dkk,
    Dop,
    Dzd,
    Egp,
    Etb,
    Eur,
    Fjd,
    Gbp,
    Gel,
    Gip,
    Gmd,
    Gyd,
    Hkd,
    Hrk,
    Htg,
    Idr,
    Ils,
    Inr,
    Isk,
    Jmd,
    Jpy,
    Kes,
    Kgs,
    Khr,
    Kmf,
    Krw,
    Kyd,
    Kzt,
    Lbp,
    Lkr,
    Lrd,
    Lsl,
    Mad,
    Mdl,
    Mga,
    Mkd,
    Mmk,
    Mnt,
    Mop,
    Mro,
    Mvr,
    Mwk,
    Mxn,
    Myr,
    Mzn,
    Nad,
    Ngn,
    Nok,
    Npr,
    Nzd,
    Pgk,
    Php,
    Pkr,
    Pln,
    Qar,
    Ron,
    Rsd,
    Rub,
    Rwf,
    Sar,
    Sbd,
    Scr,
    Sek,
    Sgd,
    Sle,
    Sll,
    Sos,
    Szl,
    Thb,
    Tjs,
    Top,
    Try,
    Ttd,
    Tzs,
    Uah,
    Uzs,
    Vnd,
    Vuv,
    Wst,
    Xaf,
    Xcd,
    Yer,
    Zar,
    Zmw,
    Clp,
    Djf,
    Gnf,
    Ugx,
    Pyg,
    Xof,
    Xpf,
}

sealed class DataMinimumSpendCurrencyConverter : JsonConverter<DataMinimumSpendCurrency>
{
    public override DataMinimumSpendCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => DataMinimumSpendCurrency.Usd,
            "aed" => DataMinimumSpendCurrency.Aed,
            "all" => DataMinimumSpendCurrency.All,
            "amd" => DataMinimumSpendCurrency.Amd,
            "ang" => DataMinimumSpendCurrency.Ang,
            "aud" => DataMinimumSpendCurrency.Aud,
            "awg" => DataMinimumSpendCurrency.Awg,
            "azn" => DataMinimumSpendCurrency.Azn,
            "bam" => DataMinimumSpendCurrency.Bam,
            "bbd" => DataMinimumSpendCurrency.Bbd,
            "bdt" => DataMinimumSpendCurrency.Bdt,
            "bgn" => DataMinimumSpendCurrency.Bgn,
            "bif" => DataMinimumSpendCurrency.Bif,
            "bmd" => DataMinimumSpendCurrency.Bmd,
            "bnd" => DataMinimumSpendCurrency.Bnd,
            "bsd" => DataMinimumSpendCurrency.Bsd,
            "bwp" => DataMinimumSpendCurrency.Bwp,
            "byn" => DataMinimumSpendCurrency.Byn,
            "bzd" => DataMinimumSpendCurrency.Bzd,
            "brl" => DataMinimumSpendCurrency.Brl,
            "cad" => DataMinimumSpendCurrency.Cad,
            "cdf" => DataMinimumSpendCurrency.Cdf,
            "chf" => DataMinimumSpendCurrency.Chf,
            "cny" => DataMinimumSpendCurrency.Cny,
            "czk" => DataMinimumSpendCurrency.Czk,
            "dkk" => DataMinimumSpendCurrency.Dkk,
            "dop" => DataMinimumSpendCurrency.Dop,
            "dzd" => DataMinimumSpendCurrency.Dzd,
            "egp" => DataMinimumSpendCurrency.Egp,
            "etb" => DataMinimumSpendCurrency.Etb,
            "eur" => DataMinimumSpendCurrency.Eur,
            "fjd" => DataMinimumSpendCurrency.Fjd,
            "gbp" => DataMinimumSpendCurrency.Gbp,
            "gel" => DataMinimumSpendCurrency.Gel,
            "gip" => DataMinimumSpendCurrency.Gip,
            "gmd" => DataMinimumSpendCurrency.Gmd,
            "gyd" => DataMinimumSpendCurrency.Gyd,
            "hkd" => DataMinimumSpendCurrency.Hkd,
            "hrk" => DataMinimumSpendCurrency.Hrk,
            "htg" => DataMinimumSpendCurrency.Htg,
            "idr" => DataMinimumSpendCurrency.Idr,
            "ils" => DataMinimumSpendCurrency.Ils,
            "inr" => DataMinimumSpendCurrency.Inr,
            "isk" => DataMinimumSpendCurrency.Isk,
            "jmd" => DataMinimumSpendCurrency.Jmd,
            "jpy" => DataMinimumSpendCurrency.Jpy,
            "kes" => DataMinimumSpendCurrency.Kes,
            "kgs" => DataMinimumSpendCurrency.Kgs,
            "khr" => DataMinimumSpendCurrency.Khr,
            "kmf" => DataMinimumSpendCurrency.Kmf,
            "krw" => DataMinimumSpendCurrency.Krw,
            "kyd" => DataMinimumSpendCurrency.Kyd,
            "kzt" => DataMinimumSpendCurrency.Kzt,
            "lbp" => DataMinimumSpendCurrency.Lbp,
            "lkr" => DataMinimumSpendCurrency.Lkr,
            "lrd" => DataMinimumSpendCurrency.Lrd,
            "lsl" => DataMinimumSpendCurrency.Lsl,
            "mad" => DataMinimumSpendCurrency.Mad,
            "mdl" => DataMinimumSpendCurrency.Mdl,
            "mga" => DataMinimumSpendCurrency.Mga,
            "mkd" => DataMinimumSpendCurrency.Mkd,
            "mmk" => DataMinimumSpendCurrency.Mmk,
            "mnt" => DataMinimumSpendCurrency.Mnt,
            "mop" => DataMinimumSpendCurrency.Mop,
            "mro" => DataMinimumSpendCurrency.Mro,
            "mvr" => DataMinimumSpendCurrency.Mvr,
            "mwk" => DataMinimumSpendCurrency.Mwk,
            "mxn" => DataMinimumSpendCurrency.Mxn,
            "myr" => DataMinimumSpendCurrency.Myr,
            "mzn" => DataMinimumSpendCurrency.Mzn,
            "nad" => DataMinimumSpendCurrency.Nad,
            "ngn" => DataMinimumSpendCurrency.Ngn,
            "nok" => DataMinimumSpendCurrency.Nok,
            "npr" => DataMinimumSpendCurrency.Npr,
            "nzd" => DataMinimumSpendCurrency.Nzd,
            "pgk" => DataMinimumSpendCurrency.Pgk,
            "php" => DataMinimumSpendCurrency.Php,
            "pkr" => DataMinimumSpendCurrency.Pkr,
            "pln" => DataMinimumSpendCurrency.Pln,
            "qar" => DataMinimumSpendCurrency.Qar,
            "ron" => DataMinimumSpendCurrency.Ron,
            "rsd" => DataMinimumSpendCurrency.Rsd,
            "rub" => DataMinimumSpendCurrency.Rub,
            "rwf" => DataMinimumSpendCurrency.Rwf,
            "sar" => DataMinimumSpendCurrency.Sar,
            "sbd" => DataMinimumSpendCurrency.Sbd,
            "scr" => DataMinimumSpendCurrency.Scr,
            "sek" => DataMinimumSpendCurrency.Sek,
            "sgd" => DataMinimumSpendCurrency.Sgd,
            "sle" => DataMinimumSpendCurrency.Sle,
            "sll" => DataMinimumSpendCurrency.Sll,
            "sos" => DataMinimumSpendCurrency.Sos,
            "szl" => DataMinimumSpendCurrency.Szl,
            "thb" => DataMinimumSpendCurrency.Thb,
            "tjs" => DataMinimumSpendCurrency.Tjs,
            "top" => DataMinimumSpendCurrency.Top,
            "try" => DataMinimumSpendCurrency.Try,
            "ttd" => DataMinimumSpendCurrency.Ttd,
            "tzs" => DataMinimumSpendCurrency.Tzs,
            "uah" => DataMinimumSpendCurrency.Uah,
            "uzs" => DataMinimumSpendCurrency.Uzs,
            "vnd" => DataMinimumSpendCurrency.Vnd,
            "vuv" => DataMinimumSpendCurrency.Vuv,
            "wst" => DataMinimumSpendCurrency.Wst,
            "xaf" => DataMinimumSpendCurrency.Xaf,
            "xcd" => DataMinimumSpendCurrency.Xcd,
            "yer" => DataMinimumSpendCurrency.Yer,
            "zar" => DataMinimumSpendCurrency.Zar,
            "zmw" => DataMinimumSpendCurrency.Zmw,
            "clp" => DataMinimumSpendCurrency.Clp,
            "djf" => DataMinimumSpendCurrency.Djf,
            "gnf" => DataMinimumSpendCurrency.Gnf,
            "ugx" => DataMinimumSpendCurrency.Ugx,
            "pyg" => DataMinimumSpendCurrency.Pyg,
            "xof" => DataMinimumSpendCurrency.Xof,
            "xpf" => DataMinimumSpendCurrency.Xpf,
            _ => (DataMinimumSpendCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DataMinimumSpendCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DataMinimumSpendCurrency.Usd => "usd",
                DataMinimumSpendCurrency.Aed => "aed",
                DataMinimumSpendCurrency.All => "all",
                DataMinimumSpendCurrency.Amd => "amd",
                DataMinimumSpendCurrency.Ang => "ang",
                DataMinimumSpendCurrency.Aud => "aud",
                DataMinimumSpendCurrency.Awg => "awg",
                DataMinimumSpendCurrency.Azn => "azn",
                DataMinimumSpendCurrency.Bam => "bam",
                DataMinimumSpendCurrency.Bbd => "bbd",
                DataMinimumSpendCurrency.Bdt => "bdt",
                DataMinimumSpendCurrency.Bgn => "bgn",
                DataMinimumSpendCurrency.Bif => "bif",
                DataMinimumSpendCurrency.Bmd => "bmd",
                DataMinimumSpendCurrency.Bnd => "bnd",
                DataMinimumSpendCurrency.Bsd => "bsd",
                DataMinimumSpendCurrency.Bwp => "bwp",
                DataMinimumSpendCurrency.Byn => "byn",
                DataMinimumSpendCurrency.Bzd => "bzd",
                DataMinimumSpendCurrency.Brl => "brl",
                DataMinimumSpendCurrency.Cad => "cad",
                DataMinimumSpendCurrency.Cdf => "cdf",
                DataMinimumSpendCurrency.Chf => "chf",
                DataMinimumSpendCurrency.Cny => "cny",
                DataMinimumSpendCurrency.Czk => "czk",
                DataMinimumSpendCurrency.Dkk => "dkk",
                DataMinimumSpendCurrency.Dop => "dop",
                DataMinimumSpendCurrency.Dzd => "dzd",
                DataMinimumSpendCurrency.Egp => "egp",
                DataMinimumSpendCurrency.Etb => "etb",
                DataMinimumSpendCurrency.Eur => "eur",
                DataMinimumSpendCurrency.Fjd => "fjd",
                DataMinimumSpendCurrency.Gbp => "gbp",
                DataMinimumSpendCurrency.Gel => "gel",
                DataMinimumSpendCurrency.Gip => "gip",
                DataMinimumSpendCurrency.Gmd => "gmd",
                DataMinimumSpendCurrency.Gyd => "gyd",
                DataMinimumSpendCurrency.Hkd => "hkd",
                DataMinimumSpendCurrency.Hrk => "hrk",
                DataMinimumSpendCurrency.Htg => "htg",
                DataMinimumSpendCurrency.Idr => "idr",
                DataMinimumSpendCurrency.Ils => "ils",
                DataMinimumSpendCurrency.Inr => "inr",
                DataMinimumSpendCurrency.Isk => "isk",
                DataMinimumSpendCurrency.Jmd => "jmd",
                DataMinimumSpendCurrency.Jpy => "jpy",
                DataMinimumSpendCurrency.Kes => "kes",
                DataMinimumSpendCurrency.Kgs => "kgs",
                DataMinimumSpendCurrency.Khr => "khr",
                DataMinimumSpendCurrency.Kmf => "kmf",
                DataMinimumSpendCurrency.Krw => "krw",
                DataMinimumSpendCurrency.Kyd => "kyd",
                DataMinimumSpendCurrency.Kzt => "kzt",
                DataMinimumSpendCurrency.Lbp => "lbp",
                DataMinimumSpendCurrency.Lkr => "lkr",
                DataMinimumSpendCurrency.Lrd => "lrd",
                DataMinimumSpendCurrency.Lsl => "lsl",
                DataMinimumSpendCurrency.Mad => "mad",
                DataMinimumSpendCurrency.Mdl => "mdl",
                DataMinimumSpendCurrency.Mga => "mga",
                DataMinimumSpendCurrency.Mkd => "mkd",
                DataMinimumSpendCurrency.Mmk => "mmk",
                DataMinimumSpendCurrency.Mnt => "mnt",
                DataMinimumSpendCurrency.Mop => "mop",
                DataMinimumSpendCurrency.Mro => "mro",
                DataMinimumSpendCurrency.Mvr => "mvr",
                DataMinimumSpendCurrency.Mwk => "mwk",
                DataMinimumSpendCurrency.Mxn => "mxn",
                DataMinimumSpendCurrency.Myr => "myr",
                DataMinimumSpendCurrency.Mzn => "mzn",
                DataMinimumSpendCurrency.Nad => "nad",
                DataMinimumSpendCurrency.Ngn => "ngn",
                DataMinimumSpendCurrency.Nok => "nok",
                DataMinimumSpendCurrency.Npr => "npr",
                DataMinimumSpendCurrency.Nzd => "nzd",
                DataMinimumSpendCurrency.Pgk => "pgk",
                DataMinimumSpendCurrency.Php => "php",
                DataMinimumSpendCurrency.Pkr => "pkr",
                DataMinimumSpendCurrency.Pln => "pln",
                DataMinimumSpendCurrency.Qar => "qar",
                DataMinimumSpendCurrency.Ron => "ron",
                DataMinimumSpendCurrency.Rsd => "rsd",
                DataMinimumSpendCurrency.Rub => "rub",
                DataMinimumSpendCurrency.Rwf => "rwf",
                DataMinimumSpendCurrency.Sar => "sar",
                DataMinimumSpendCurrency.Sbd => "sbd",
                DataMinimumSpendCurrency.Scr => "scr",
                DataMinimumSpendCurrency.Sek => "sek",
                DataMinimumSpendCurrency.Sgd => "sgd",
                DataMinimumSpendCurrency.Sle => "sle",
                DataMinimumSpendCurrency.Sll => "sll",
                DataMinimumSpendCurrency.Sos => "sos",
                DataMinimumSpendCurrency.Szl => "szl",
                DataMinimumSpendCurrency.Thb => "thb",
                DataMinimumSpendCurrency.Tjs => "tjs",
                DataMinimumSpendCurrency.Top => "top",
                DataMinimumSpendCurrency.Try => "try",
                DataMinimumSpendCurrency.Ttd => "ttd",
                DataMinimumSpendCurrency.Tzs => "tzs",
                DataMinimumSpendCurrency.Uah => "uah",
                DataMinimumSpendCurrency.Uzs => "uzs",
                DataMinimumSpendCurrency.Vnd => "vnd",
                DataMinimumSpendCurrency.Vuv => "vuv",
                DataMinimumSpendCurrency.Wst => "wst",
                DataMinimumSpendCurrency.Xaf => "xaf",
                DataMinimumSpendCurrency.Xcd => "xcd",
                DataMinimumSpendCurrency.Yer => "yer",
                DataMinimumSpendCurrency.Zar => "zar",
                DataMinimumSpendCurrency.Zmw => "zmw",
                DataMinimumSpendCurrency.Clp => "clp",
                DataMinimumSpendCurrency.Djf => "djf",
                DataMinimumSpendCurrency.Gnf => "gnf",
                DataMinimumSpendCurrency.Ugx => "ugx",
                DataMinimumSpendCurrency.Pyg => "pyg",
                DataMinimumSpendCurrency.Xof => "xof",
                DataMinimumSpendCurrency.Xpf => "xpf",
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
[JsonConverter(typeof(DataPaymentCollectionMethodConverter))]
public enum DataPaymentCollectionMethod
{
    Charge,
    Invoice,
    None,
}

sealed class DataPaymentCollectionMethodConverter : JsonConverter<DataPaymentCollectionMethod>
{
    public override DataPaymentCollectionMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "CHARGE" => DataPaymentCollectionMethod.Charge,
            "INVOICE" => DataPaymentCollectionMethod.Invoice,
            "NONE" => DataPaymentCollectionMethod.None,
            _ => (DataPaymentCollectionMethod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DataPaymentCollectionMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DataPaymentCollectionMethod.Charge => "CHARGE",
                DataPaymentCollectionMethod.Invoice => "INVOICE",
                DataPaymentCollectionMethod.None => "NONE",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<Price, PriceFromRaw>))]
public sealed record class Price : JsonModel
{
    /// <summary>
    /// Addon identifier for the price override
    /// </summary>
    public string? AddonID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("addonId");
        }
        init { this._rawData.Set("addonId", value); }
    }

    /// <summary>
    /// The price amount
    /// </summary>
    public double? Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("amount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("amount", value);
        }
    }

    /// <summary>
    /// Whether this is a base charge override
    /// </summary>
    public bool? BaseCharge
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("baseCharge");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("baseCharge", value);
        }
    }

    /// <summary>
    /// The billing country code of the price
    /// </summary>
    public string? BillingCountryCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billingCountryCode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("billingCountryCode", value);
        }
    }

    /// <summary>
    /// Block size for pricing
    /// </summary>
    public double? BlockSize
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("blockSize");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("blockSize", value);
        }
    }

    /// <summary>
    /// The price currency
    /// </summary>
    public ApiEnum<string, PriceCurrency>? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PriceCurrency>>("currency");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("currency", value);
        }
    }

    /// <summary>
    /// Feature identifier for the price override
    /// </summary>
    public string? FeatureID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("featureId");
        }
        init { this._rawData.Set("featureId", value); }
    }

    /// <summary>
    /// Pricing tiers configuration
    /// </summary>
    public IReadOnlyList<PriceTier>? Tiers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<PriceTier>>("tiers");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<PriceTier>?>(
                "tiers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AddonID;
        _ = this.Amount;
        _ = this.BaseCharge;
        _ = this.BillingCountryCode;
        _ = this.BlockSize;
        this.Currency?.Validate();
        _ = this.FeatureID;
        foreach (var item in this.Tiers ?? [])
        {
            item.Validate();
        }
    }

    public Price() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Price(Price price)
        : base(price) { }
#pragma warning restore CS8618

    public Price(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Price(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PriceFromRaw.FromRawUnchecked"/>
    public static Price FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PriceFromRaw : IFromRawJson<Price>
{
    /// <inheritdoc/>
    public Price FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Price.FromRawUnchecked(rawData);
}

/// <summary>
/// The price currency
/// </summary>
[JsonConverter(typeof(PriceCurrencyConverter))]
public enum PriceCurrency
{
    Usd,
    Aed,
    All,
    Amd,
    Ang,
    Aud,
    Awg,
    Azn,
    Bam,
    Bbd,
    Bdt,
    Bgn,
    Bif,
    Bmd,
    Bnd,
    Bsd,
    Bwp,
    Byn,
    Bzd,
    Brl,
    Cad,
    Cdf,
    Chf,
    Cny,
    Czk,
    Dkk,
    Dop,
    Dzd,
    Egp,
    Etb,
    Eur,
    Fjd,
    Gbp,
    Gel,
    Gip,
    Gmd,
    Gyd,
    Hkd,
    Hrk,
    Htg,
    Idr,
    Ils,
    Inr,
    Isk,
    Jmd,
    Jpy,
    Kes,
    Kgs,
    Khr,
    Kmf,
    Krw,
    Kyd,
    Kzt,
    Lbp,
    Lkr,
    Lrd,
    Lsl,
    Mad,
    Mdl,
    Mga,
    Mkd,
    Mmk,
    Mnt,
    Mop,
    Mro,
    Mvr,
    Mwk,
    Mxn,
    Myr,
    Mzn,
    Nad,
    Ngn,
    Nok,
    Npr,
    Nzd,
    Pgk,
    Php,
    Pkr,
    Pln,
    Qar,
    Ron,
    Rsd,
    Rub,
    Rwf,
    Sar,
    Sbd,
    Scr,
    Sek,
    Sgd,
    Sle,
    Sll,
    Sos,
    Szl,
    Thb,
    Tjs,
    Top,
    Try,
    Ttd,
    Tzs,
    Uah,
    Uzs,
    Vnd,
    Vuv,
    Wst,
    Xaf,
    Xcd,
    Yer,
    Zar,
    Zmw,
    Clp,
    Djf,
    Gnf,
    Ugx,
    Pyg,
    Xof,
    Xpf,
}

sealed class PriceCurrencyConverter : JsonConverter<PriceCurrency>
{
    public override PriceCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => PriceCurrency.Usd,
            "aed" => PriceCurrency.Aed,
            "all" => PriceCurrency.All,
            "amd" => PriceCurrency.Amd,
            "ang" => PriceCurrency.Ang,
            "aud" => PriceCurrency.Aud,
            "awg" => PriceCurrency.Awg,
            "azn" => PriceCurrency.Azn,
            "bam" => PriceCurrency.Bam,
            "bbd" => PriceCurrency.Bbd,
            "bdt" => PriceCurrency.Bdt,
            "bgn" => PriceCurrency.Bgn,
            "bif" => PriceCurrency.Bif,
            "bmd" => PriceCurrency.Bmd,
            "bnd" => PriceCurrency.Bnd,
            "bsd" => PriceCurrency.Bsd,
            "bwp" => PriceCurrency.Bwp,
            "byn" => PriceCurrency.Byn,
            "bzd" => PriceCurrency.Bzd,
            "brl" => PriceCurrency.Brl,
            "cad" => PriceCurrency.Cad,
            "cdf" => PriceCurrency.Cdf,
            "chf" => PriceCurrency.Chf,
            "cny" => PriceCurrency.Cny,
            "czk" => PriceCurrency.Czk,
            "dkk" => PriceCurrency.Dkk,
            "dop" => PriceCurrency.Dop,
            "dzd" => PriceCurrency.Dzd,
            "egp" => PriceCurrency.Egp,
            "etb" => PriceCurrency.Etb,
            "eur" => PriceCurrency.Eur,
            "fjd" => PriceCurrency.Fjd,
            "gbp" => PriceCurrency.Gbp,
            "gel" => PriceCurrency.Gel,
            "gip" => PriceCurrency.Gip,
            "gmd" => PriceCurrency.Gmd,
            "gyd" => PriceCurrency.Gyd,
            "hkd" => PriceCurrency.Hkd,
            "hrk" => PriceCurrency.Hrk,
            "htg" => PriceCurrency.Htg,
            "idr" => PriceCurrency.Idr,
            "ils" => PriceCurrency.Ils,
            "inr" => PriceCurrency.Inr,
            "isk" => PriceCurrency.Isk,
            "jmd" => PriceCurrency.Jmd,
            "jpy" => PriceCurrency.Jpy,
            "kes" => PriceCurrency.Kes,
            "kgs" => PriceCurrency.Kgs,
            "khr" => PriceCurrency.Khr,
            "kmf" => PriceCurrency.Kmf,
            "krw" => PriceCurrency.Krw,
            "kyd" => PriceCurrency.Kyd,
            "kzt" => PriceCurrency.Kzt,
            "lbp" => PriceCurrency.Lbp,
            "lkr" => PriceCurrency.Lkr,
            "lrd" => PriceCurrency.Lrd,
            "lsl" => PriceCurrency.Lsl,
            "mad" => PriceCurrency.Mad,
            "mdl" => PriceCurrency.Mdl,
            "mga" => PriceCurrency.Mga,
            "mkd" => PriceCurrency.Mkd,
            "mmk" => PriceCurrency.Mmk,
            "mnt" => PriceCurrency.Mnt,
            "mop" => PriceCurrency.Mop,
            "mro" => PriceCurrency.Mro,
            "mvr" => PriceCurrency.Mvr,
            "mwk" => PriceCurrency.Mwk,
            "mxn" => PriceCurrency.Mxn,
            "myr" => PriceCurrency.Myr,
            "mzn" => PriceCurrency.Mzn,
            "nad" => PriceCurrency.Nad,
            "ngn" => PriceCurrency.Ngn,
            "nok" => PriceCurrency.Nok,
            "npr" => PriceCurrency.Npr,
            "nzd" => PriceCurrency.Nzd,
            "pgk" => PriceCurrency.Pgk,
            "php" => PriceCurrency.Php,
            "pkr" => PriceCurrency.Pkr,
            "pln" => PriceCurrency.Pln,
            "qar" => PriceCurrency.Qar,
            "ron" => PriceCurrency.Ron,
            "rsd" => PriceCurrency.Rsd,
            "rub" => PriceCurrency.Rub,
            "rwf" => PriceCurrency.Rwf,
            "sar" => PriceCurrency.Sar,
            "sbd" => PriceCurrency.Sbd,
            "scr" => PriceCurrency.Scr,
            "sek" => PriceCurrency.Sek,
            "sgd" => PriceCurrency.Sgd,
            "sle" => PriceCurrency.Sle,
            "sll" => PriceCurrency.Sll,
            "sos" => PriceCurrency.Sos,
            "szl" => PriceCurrency.Szl,
            "thb" => PriceCurrency.Thb,
            "tjs" => PriceCurrency.Tjs,
            "top" => PriceCurrency.Top,
            "try" => PriceCurrency.Try,
            "ttd" => PriceCurrency.Ttd,
            "tzs" => PriceCurrency.Tzs,
            "uah" => PriceCurrency.Uah,
            "uzs" => PriceCurrency.Uzs,
            "vnd" => PriceCurrency.Vnd,
            "vuv" => PriceCurrency.Vuv,
            "wst" => PriceCurrency.Wst,
            "xaf" => PriceCurrency.Xaf,
            "xcd" => PriceCurrency.Xcd,
            "yer" => PriceCurrency.Yer,
            "zar" => PriceCurrency.Zar,
            "zmw" => PriceCurrency.Zmw,
            "clp" => PriceCurrency.Clp,
            "djf" => PriceCurrency.Djf,
            "gnf" => PriceCurrency.Gnf,
            "ugx" => PriceCurrency.Ugx,
            "pyg" => PriceCurrency.Pyg,
            "xof" => PriceCurrency.Xof,
            "xpf" => PriceCurrency.Xpf,
            _ => (PriceCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PriceCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PriceCurrency.Usd => "usd",
                PriceCurrency.Aed => "aed",
                PriceCurrency.All => "all",
                PriceCurrency.Amd => "amd",
                PriceCurrency.Ang => "ang",
                PriceCurrency.Aud => "aud",
                PriceCurrency.Awg => "awg",
                PriceCurrency.Azn => "azn",
                PriceCurrency.Bam => "bam",
                PriceCurrency.Bbd => "bbd",
                PriceCurrency.Bdt => "bdt",
                PriceCurrency.Bgn => "bgn",
                PriceCurrency.Bif => "bif",
                PriceCurrency.Bmd => "bmd",
                PriceCurrency.Bnd => "bnd",
                PriceCurrency.Bsd => "bsd",
                PriceCurrency.Bwp => "bwp",
                PriceCurrency.Byn => "byn",
                PriceCurrency.Bzd => "bzd",
                PriceCurrency.Brl => "brl",
                PriceCurrency.Cad => "cad",
                PriceCurrency.Cdf => "cdf",
                PriceCurrency.Chf => "chf",
                PriceCurrency.Cny => "cny",
                PriceCurrency.Czk => "czk",
                PriceCurrency.Dkk => "dkk",
                PriceCurrency.Dop => "dop",
                PriceCurrency.Dzd => "dzd",
                PriceCurrency.Egp => "egp",
                PriceCurrency.Etb => "etb",
                PriceCurrency.Eur => "eur",
                PriceCurrency.Fjd => "fjd",
                PriceCurrency.Gbp => "gbp",
                PriceCurrency.Gel => "gel",
                PriceCurrency.Gip => "gip",
                PriceCurrency.Gmd => "gmd",
                PriceCurrency.Gyd => "gyd",
                PriceCurrency.Hkd => "hkd",
                PriceCurrency.Hrk => "hrk",
                PriceCurrency.Htg => "htg",
                PriceCurrency.Idr => "idr",
                PriceCurrency.Ils => "ils",
                PriceCurrency.Inr => "inr",
                PriceCurrency.Isk => "isk",
                PriceCurrency.Jmd => "jmd",
                PriceCurrency.Jpy => "jpy",
                PriceCurrency.Kes => "kes",
                PriceCurrency.Kgs => "kgs",
                PriceCurrency.Khr => "khr",
                PriceCurrency.Kmf => "kmf",
                PriceCurrency.Krw => "krw",
                PriceCurrency.Kyd => "kyd",
                PriceCurrency.Kzt => "kzt",
                PriceCurrency.Lbp => "lbp",
                PriceCurrency.Lkr => "lkr",
                PriceCurrency.Lrd => "lrd",
                PriceCurrency.Lsl => "lsl",
                PriceCurrency.Mad => "mad",
                PriceCurrency.Mdl => "mdl",
                PriceCurrency.Mga => "mga",
                PriceCurrency.Mkd => "mkd",
                PriceCurrency.Mmk => "mmk",
                PriceCurrency.Mnt => "mnt",
                PriceCurrency.Mop => "mop",
                PriceCurrency.Mro => "mro",
                PriceCurrency.Mvr => "mvr",
                PriceCurrency.Mwk => "mwk",
                PriceCurrency.Mxn => "mxn",
                PriceCurrency.Myr => "myr",
                PriceCurrency.Mzn => "mzn",
                PriceCurrency.Nad => "nad",
                PriceCurrency.Ngn => "ngn",
                PriceCurrency.Nok => "nok",
                PriceCurrency.Npr => "npr",
                PriceCurrency.Nzd => "nzd",
                PriceCurrency.Pgk => "pgk",
                PriceCurrency.Php => "php",
                PriceCurrency.Pkr => "pkr",
                PriceCurrency.Pln => "pln",
                PriceCurrency.Qar => "qar",
                PriceCurrency.Ron => "ron",
                PriceCurrency.Rsd => "rsd",
                PriceCurrency.Rub => "rub",
                PriceCurrency.Rwf => "rwf",
                PriceCurrency.Sar => "sar",
                PriceCurrency.Sbd => "sbd",
                PriceCurrency.Scr => "scr",
                PriceCurrency.Sek => "sek",
                PriceCurrency.Sgd => "sgd",
                PriceCurrency.Sle => "sle",
                PriceCurrency.Sll => "sll",
                PriceCurrency.Sos => "sos",
                PriceCurrency.Szl => "szl",
                PriceCurrency.Thb => "thb",
                PriceCurrency.Tjs => "tjs",
                PriceCurrency.Top => "top",
                PriceCurrency.Try => "try",
                PriceCurrency.Ttd => "ttd",
                PriceCurrency.Tzs => "tzs",
                PriceCurrency.Uah => "uah",
                PriceCurrency.Uzs => "uzs",
                PriceCurrency.Vnd => "vnd",
                PriceCurrency.Vuv => "vuv",
                PriceCurrency.Wst => "wst",
                PriceCurrency.Xaf => "xaf",
                PriceCurrency.Xcd => "xcd",
                PriceCurrency.Yer => "yer",
                PriceCurrency.Zar => "zar",
                PriceCurrency.Zmw => "zmw",
                PriceCurrency.Clp => "clp",
                PriceCurrency.Djf => "djf",
                PriceCurrency.Gnf => "gnf",
                PriceCurrency.Ugx => "ugx",
                PriceCurrency.Pyg => "pyg",
                PriceCurrency.Xof => "xof",
                PriceCurrency.Xpf => "xpf",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<PriceTier, PriceTierFromRaw>))]
public sealed record class PriceTier : JsonModel
{
    /// <summary>
    /// The flat fee price of the price tier
    /// </summary>
    public PriceTierFlatPrice? FlatPrice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PriceTierFlatPrice>("flatPrice");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("flatPrice", value);
        }
    }

    /// <summary>
    /// The unit price of the price tier
    /// </summary>
    public PriceTierUnitPrice? UnitPrice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PriceTierUnitPrice>("unitPrice");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("unitPrice", value);
        }
    }

    /// <summary>
    /// The up to quantity of the price tier
    /// </summary>
    public double? UpTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("upTo");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("upTo", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.FlatPrice?.Validate();
        this.UnitPrice?.Validate();
        _ = this.UpTo;
    }

    public PriceTier() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PriceTier(PriceTier priceTier)
        : base(priceTier) { }
#pragma warning restore CS8618

    public PriceTier(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PriceTier(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PriceTierFromRaw.FromRawUnchecked"/>
    public static PriceTier FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PriceTierFromRaw : IFromRawJson<PriceTier>
{
    /// <inheritdoc/>
    public PriceTier FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PriceTier.FromRawUnchecked(rawData);
}

/// <summary>
/// The flat fee price of the price tier
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PriceTierFlatPrice, PriceTierFlatPriceFromRaw>))]
public sealed record class PriceTierFlatPrice : JsonModel
{
    /// <summary>
    /// The price amount
    /// </summary>
    public required double Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    /// <summary>
    /// ISO 4217 currency code
    /// </summary>
    public required ApiEnum<string, PriceTierFlatPriceCurrency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, PriceTierFlatPriceCurrency>>(
                "currency"
            );
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        this.Currency.Validate();
    }

    public PriceTierFlatPrice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PriceTierFlatPrice(PriceTierFlatPrice priceTierFlatPrice)
        : base(priceTierFlatPrice) { }
#pragma warning restore CS8618

    public PriceTierFlatPrice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PriceTierFlatPrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PriceTierFlatPriceFromRaw.FromRawUnchecked"/>
    public static PriceTierFlatPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PriceTierFlatPriceFromRaw : IFromRawJson<PriceTierFlatPrice>
{
    /// <inheritdoc/>
    public PriceTierFlatPrice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PriceTierFlatPrice.FromRawUnchecked(rawData);
}

/// <summary>
/// ISO 4217 currency code
/// </summary>
[JsonConverter(typeof(PriceTierFlatPriceCurrencyConverter))]
public enum PriceTierFlatPriceCurrency
{
    Usd,
    Aed,
    All,
    Amd,
    Ang,
    Aud,
    Awg,
    Azn,
    Bam,
    Bbd,
    Bdt,
    Bgn,
    Bif,
    Bmd,
    Bnd,
    Bsd,
    Bwp,
    Byn,
    Bzd,
    Brl,
    Cad,
    Cdf,
    Chf,
    Cny,
    Czk,
    Dkk,
    Dop,
    Dzd,
    Egp,
    Etb,
    Eur,
    Fjd,
    Gbp,
    Gel,
    Gip,
    Gmd,
    Gyd,
    Hkd,
    Hrk,
    Htg,
    Idr,
    Ils,
    Inr,
    Isk,
    Jmd,
    Jpy,
    Kes,
    Kgs,
    Khr,
    Kmf,
    Krw,
    Kyd,
    Kzt,
    Lbp,
    Lkr,
    Lrd,
    Lsl,
    Mad,
    Mdl,
    Mga,
    Mkd,
    Mmk,
    Mnt,
    Mop,
    Mro,
    Mvr,
    Mwk,
    Mxn,
    Myr,
    Mzn,
    Nad,
    Ngn,
    Nok,
    Npr,
    Nzd,
    Pgk,
    Php,
    Pkr,
    Pln,
    Qar,
    Ron,
    Rsd,
    Rub,
    Rwf,
    Sar,
    Sbd,
    Scr,
    Sek,
    Sgd,
    Sle,
    Sll,
    Sos,
    Szl,
    Thb,
    Tjs,
    Top,
    Try,
    Ttd,
    Tzs,
    Uah,
    Uzs,
    Vnd,
    Vuv,
    Wst,
    Xaf,
    Xcd,
    Yer,
    Zar,
    Zmw,
    Clp,
    Djf,
    Gnf,
    Ugx,
    Pyg,
    Xof,
    Xpf,
}

sealed class PriceTierFlatPriceCurrencyConverter : JsonConverter<PriceTierFlatPriceCurrency>
{
    public override PriceTierFlatPriceCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => PriceTierFlatPriceCurrency.Usd,
            "aed" => PriceTierFlatPriceCurrency.Aed,
            "all" => PriceTierFlatPriceCurrency.All,
            "amd" => PriceTierFlatPriceCurrency.Amd,
            "ang" => PriceTierFlatPriceCurrency.Ang,
            "aud" => PriceTierFlatPriceCurrency.Aud,
            "awg" => PriceTierFlatPriceCurrency.Awg,
            "azn" => PriceTierFlatPriceCurrency.Azn,
            "bam" => PriceTierFlatPriceCurrency.Bam,
            "bbd" => PriceTierFlatPriceCurrency.Bbd,
            "bdt" => PriceTierFlatPriceCurrency.Bdt,
            "bgn" => PriceTierFlatPriceCurrency.Bgn,
            "bif" => PriceTierFlatPriceCurrency.Bif,
            "bmd" => PriceTierFlatPriceCurrency.Bmd,
            "bnd" => PriceTierFlatPriceCurrency.Bnd,
            "bsd" => PriceTierFlatPriceCurrency.Bsd,
            "bwp" => PriceTierFlatPriceCurrency.Bwp,
            "byn" => PriceTierFlatPriceCurrency.Byn,
            "bzd" => PriceTierFlatPriceCurrency.Bzd,
            "brl" => PriceTierFlatPriceCurrency.Brl,
            "cad" => PriceTierFlatPriceCurrency.Cad,
            "cdf" => PriceTierFlatPriceCurrency.Cdf,
            "chf" => PriceTierFlatPriceCurrency.Chf,
            "cny" => PriceTierFlatPriceCurrency.Cny,
            "czk" => PriceTierFlatPriceCurrency.Czk,
            "dkk" => PriceTierFlatPriceCurrency.Dkk,
            "dop" => PriceTierFlatPriceCurrency.Dop,
            "dzd" => PriceTierFlatPriceCurrency.Dzd,
            "egp" => PriceTierFlatPriceCurrency.Egp,
            "etb" => PriceTierFlatPriceCurrency.Etb,
            "eur" => PriceTierFlatPriceCurrency.Eur,
            "fjd" => PriceTierFlatPriceCurrency.Fjd,
            "gbp" => PriceTierFlatPriceCurrency.Gbp,
            "gel" => PriceTierFlatPriceCurrency.Gel,
            "gip" => PriceTierFlatPriceCurrency.Gip,
            "gmd" => PriceTierFlatPriceCurrency.Gmd,
            "gyd" => PriceTierFlatPriceCurrency.Gyd,
            "hkd" => PriceTierFlatPriceCurrency.Hkd,
            "hrk" => PriceTierFlatPriceCurrency.Hrk,
            "htg" => PriceTierFlatPriceCurrency.Htg,
            "idr" => PriceTierFlatPriceCurrency.Idr,
            "ils" => PriceTierFlatPriceCurrency.Ils,
            "inr" => PriceTierFlatPriceCurrency.Inr,
            "isk" => PriceTierFlatPriceCurrency.Isk,
            "jmd" => PriceTierFlatPriceCurrency.Jmd,
            "jpy" => PriceTierFlatPriceCurrency.Jpy,
            "kes" => PriceTierFlatPriceCurrency.Kes,
            "kgs" => PriceTierFlatPriceCurrency.Kgs,
            "khr" => PriceTierFlatPriceCurrency.Khr,
            "kmf" => PriceTierFlatPriceCurrency.Kmf,
            "krw" => PriceTierFlatPriceCurrency.Krw,
            "kyd" => PriceTierFlatPriceCurrency.Kyd,
            "kzt" => PriceTierFlatPriceCurrency.Kzt,
            "lbp" => PriceTierFlatPriceCurrency.Lbp,
            "lkr" => PriceTierFlatPriceCurrency.Lkr,
            "lrd" => PriceTierFlatPriceCurrency.Lrd,
            "lsl" => PriceTierFlatPriceCurrency.Lsl,
            "mad" => PriceTierFlatPriceCurrency.Mad,
            "mdl" => PriceTierFlatPriceCurrency.Mdl,
            "mga" => PriceTierFlatPriceCurrency.Mga,
            "mkd" => PriceTierFlatPriceCurrency.Mkd,
            "mmk" => PriceTierFlatPriceCurrency.Mmk,
            "mnt" => PriceTierFlatPriceCurrency.Mnt,
            "mop" => PriceTierFlatPriceCurrency.Mop,
            "mro" => PriceTierFlatPriceCurrency.Mro,
            "mvr" => PriceTierFlatPriceCurrency.Mvr,
            "mwk" => PriceTierFlatPriceCurrency.Mwk,
            "mxn" => PriceTierFlatPriceCurrency.Mxn,
            "myr" => PriceTierFlatPriceCurrency.Myr,
            "mzn" => PriceTierFlatPriceCurrency.Mzn,
            "nad" => PriceTierFlatPriceCurrency.Nad,
            "ngn" => PriceTierFlatPriceCurrency.Ngn,
            "nok" => PriceTierFlatPriceCurrency.Nok,
            "npr" => PriceTierFlatPriceCurrency.Npr,
            "nzd" => PriceTierFlatPriceCurrency.Nzd,
            "pgk" => PriceTierFlatPriceCurrency.Pgk,
            "php" => PriceTierFlatPriceCurrency.Php,
            "pkr" => PriceTierFlatPriceCurrency.Pkr,
            "pln" => PriceTierFlatPriceCurrency.Pln,
            "qar" => PriceTierFlatPriceCurrency.Qar,
            "ron" => PriceTierFlatPriceCurrency.Ron,
            "rsd" => PriceTierFlatPriceCurrency.Rsd,
            "rub" => PriceTierFlatPriceCurrency.Rub,
            "rwf" => PriceTierFlatPriceCurrency.Rwf,
            "sar" => PriceTierFlatPriceCurrency.Sar,
            "sbd" => PriceTierFlatPriceCurrency.Sbd,
            "scr" => PriceTierFlatPriceCurrency.Scr,
            "sek" => PriceTierFlatPriceCurrency.Sek,
            "sgd" => PriceTierFlatPriceCurrency.Sgd,
            "sle" => PriceTierFlatPriceCurrency.Sle,
            "sll" => PriceTierFlatPriceCurrency.Sll,
            "sos" => PriceTierFlatPriceCurrency.Sos,
            "szl" => PriceTierFlatPriceCurrency.Szl,
            "thb" => PriceTierFlatPriceCurrency.Thb,
            "tjs" => PriceTierFlatPriceCurrency.Tjs,
            "top" => PriceTierFlatPriceCurrency.Top,
            "try" => PriceTierFlatPriceCurrency.Try,
            "ttd" => PriceTierFlatPriceCurrency.Ttd,
            "tzs" => PriceTierFlatPriceCurrency.Tzs,
            "uah" => PriceTierFlatPriceCurrency.Uah,
            "uzs" => PriceTierFlatPriceCurrency.Uzs,
            "vnd" => PriceTierFlatPriceCurrency.Vnd,
            "vuv" => PriceTierFlatPriceCurrency.Vuv,
            "wst" => PriceTierFlatPriceCurrency.Wst,
            "xaf" => PriceTierFlatPriceCurrency.Xaf,
            "xcd" => PriceTierFlatPriceCurrency.Xcd,
            "yer" => PriceTierFlatPriceCurrency.Yer,
            "zar" => PriceTierFlatPriceCurrency.Zar,
            "zmw" => PriceTierFlatPriceCurrency.Zmw,
            "clp" => PriceTierFlatPriceCurrency.Clp,
            "djf" => PriceTierFlatPriceCurrency.Djf,
            "gnf" => PriceTierFlatPriceCurrency.Gnf,
            "ugx" => PriceTierFlatPriceCurrency.Ugx,
            "pyg" => PriceTierFlatPriceCurrency.Pyg,
            "xof" => PriceTierFlatPriceCurrency.Xof,
            "xpf" => PriceTierFlatPriceCurrency.Xpf,
            _ => (PriceTierFlatPriceCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PriceTierFlatPriceCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PriceTierFlatPriceCurrency.Usd => "usd",
                PriceTierFlatPriceCurrency.Aed => "aed",
                PriceTierFlatPriceCurrency.All => "all",
                PriceTierFlatPriceCurrency.Amd => "amd",
                PriceTierFlatPriceCurrency.Ang => "ang",
                PriceTierFlatPriceCurrency.Aud => "aud",
                PriceTierFlatPriceCurrency.Awg => "awg",
                PriceTierFlatPriceCurrency.Azn => "azn",
                PriceTierFlatPriceCurrency.Bam => "bam",
                PriceTierFlatPriceCurrency.Bbd => "bbd",
                PriceTierFlatPriceCurrency.Bdt => "bdt",
                PriceTierFlatPriceCurrency.Bgn => "bgn",
                PriceTierFlatPriceCurrency.Bif => "bif",
                PriceTierFlatPriceCurrency.Bmd => "bmd",
                PriceTierFlatPriceCurrency.Bnd => "bnd",
                PriceTierFlatPriceCurrency.Bsd => "bsd",
                PriceTierFlatPriceCurrency.Bwp => "bwp",
                PriceTierFlatPriceCurrency.Byn => "byn",
                PriceTierFlatPriceCurrency.Bzd => "bzd",
                PriceTierFlatPriceCurrency.Brl => "brl",
                PriceTierFlatPriceCurrency.Cad => "cad",
                PriceTierFlatPriceCurrency.Cdf => "cdf",
                PriceTierFlatPriceCurrency.Chf => "chf",
                PriceTierFlatPriceCurrency.Cny => "cny",
                PriceTierFlatPriceCurrency.Czk => "czk",
                PriceTierFlatPriceCurrency.Dkk => "dkk",
                PriceTierFlatPriceCurrency.Dop => "dop",
                PriceTierFlatPriceCurrency.Dzd => "dzd",
                PriceTierFlatPriceCurrency.Egp => "egp",
                PriceTierFlatPriceCurrency.Etb => "etb",
                PriceTierFlatPriceCurrency.Eur => "eur",
                PriceTierFlatPriceCurrency.Fjd => "fjd",
                PriceTierFlatPriceCurrency.Gbp => "gbp",
                PriceTierFlatPriceCurrency.Gel => "gel",
                PriceTierFlatPriceCurrency.Gip => "gip",
                PriceTierFlatPriceCurrency.Gmd => "gmd",
                PriceTierFlatPriceCurrency.Gyd => "gyd",
                PriceTierFlatPriceCurrency.Hkd => "hkd",
                PriceTierFlatPriceCurrency.Hrk => "hrk",
                PriceTierFlatPriceCurrency.Htg => "htg",
                PriceTierFlatPriceCurrency.Idr => "idr",
                PriceTierFlatPriceCurrency.Ils => "ils",
                PriceTierFlatPriceCurrency.Inr => "inr",
                PriceTierFlatPriceCurrency.Isk => "isk",
                PriceTierFlatPriceCurrency.Jmd => "jmd",
                PriceTierFlatPriceCurrency.Jpy => "jpy",
                PriceTierFlatPriceCurrency.Kes => "kes",
                PriceTierFlatPriceCurrency.Kgs => "kgs",
                PriceTierFlatPriceCurrency.Khr => "khr",
                PriceTierFlatPriceCurrency.Kmf => "kmf",
                PriceTierFlatPriceCurrency.Krw => "krw",
                PriceTierFlatPriceCurrency.Kyd => "kyd",
                PriceTierFlatPriceCurrency.Kzt => "kzt",
                PriceTierFlatPriceCurrency.Lbp => "lbp",
                PriceTierFlatPriceCurrency.Lkr => "lkr",
                PriceTierFlatPriceCurrency.Lrd => "lrd",
                PriceTierFlatPriceCurrency.Lsl => "lsl",
                PriceTierFlatPriceCurrency.Mad => "mad",
                PriceTierFlatPriceCurrency.Mdl => "mdl",
                PriceTierFlatPriceCurrency.Mga => "mga",
                PriceTierFlatPriceCurrency.Mkd => "mkd",
                PriceTierFlatPriceCurrency.Mmk => "mmk",
                PriceTierFlatPriceCurrency.Mnt => "mnt",
                PriceTierFlatPriceCurrency.Mop => "mop",
                PriceTierFlatPriceCurrency.Mro => "mro",
                PriceTierFlatPriceCurrency.Mvr => "mvr",
                PriceTierFlatPriceCurrency.Mwk => "mwk",
                PriceTierFlatPriceCurrency.Mxn => "mxn",
                PriceTierFlatPriceCurrency.Myr => "myr",
                PriceTierFlatPriceCurrency.Mzn => "mzn",
                PriceTierFlatPriceCurrency.Nad => "nad",
                PriceTierFlatPriceCurrency.Ngn => "ngn",
                PriceTierFlatPriceCurrency.Nok => "nok",
                PriceTierFlatPriceCurrency.Npr => "npr",
                PriceTierFlatPriceCurrency.Nzd => "nzd",
                PriceTierFlatPriceCurrency.Pgk => "pgk",
                PriceTierFlatPriceCurrency.Php => "php",
                PriceTierFlatPriceCurrency.Pkr => "pkr",
                PriceTierFlatPriceCurrency.Pln => "pln",
                PriceTierFlatPriceCurrency.Qar => "qar",
                PriceTierFlatPriceCurrency.Ron => "ron",
                PriceTierFlatPriceCurrency.Rsd => "rsd",
                PriceTierFlatPriceCurrency.Rub => "rub",
                PriceTierFlatPriceCurrency.Rwf => "rwf",
                PriceTierFlatPriceCurrency.Sar => "sar",
                PriceTierFlatPriceCurrency.Sbd => "sbd",
                PriceTierFlatPriceCurrency.Scr => "scr",
                PriceTierFlatPriceCurrency.Sek => "sek",
                PriceTierFlatPriceCurrency.Sgd => "sgd",
                PriceTierFlatPriceCurrency.Sle => "sle",
                PriceTierFlatPriceCurrency.Sll => "sll",
                PriceTierFlatPriceCurrency.Sos => "sos",
                PriceTierFlatPriceCurrency.Szl => "szl",
                PriceTierFlatPriceCurrency.Thb => "thb",
                PriceTierFlatPriceCurrency.Tjs => "tjs",
                PriceTierFlatPriceCurrency.Top => "top",
                PriceTierFlatPriceCurrency.Try => "try",
                PriceTierFlatPriceCurrency.Ttd => "ttd",
                PriceTierFlatPriceCurrency.Tzs => "tzs",
                PriceTierFlatPriceCurrency.Uah => "uah",
                PriceTierFlatPriceCurrency.Uzs => "uzs",
                PriceTierFlatPriceCurrency.Vnd => "vnd",
                PriceTierFlatPriceCurrency.Vuv => "vuv",
                PriceTierFlatPriceCurrency.Wst => "wst",
                PriceTierFlatPriceCurrency.Xaf => "xaf",
                PriceTierFlatPriceCurrency.Xcd => "xcd",
                PriceTierFlatPriceCurrency.Yer => "yer",
                PriceTierFlatPriceCurrency.Zar => "zar",
                PriceTierFlatPriceCurrency.Zmw => "zmw",
                PriceTierFlatPriceCurrency.Clp => "clp",
                PriceTierFlatPriceCurrency.Djf => "djf",
                PriceTierFlatPriceCurrency.Gnf => "gnf",
                PriceTierFlatPriceCurrency.Ugx => "ugx",
                PriceTierFlatPriceCurrency.Pyg => "pyg",
                PriceTierFlatPriceCurrency.Xof => "xof",
                PriceTierFlatPriceCurrency.Xpf => "xpf",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The unit price of the price tier
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PriceTierUnitPrice, PriceTierUnitPriceFromRaw>))]
public sealed record class PriceTierUnitPrice : JsonModel
{
    /// <summary>
    /// The price amount
    /// </summary>
    public required double Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    /// <summary>
    /// ISO 4217 currency code
    /// </summary>
    public required ApiEnum<string, PriceTierUnitPriceCurrency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, PriceTierUnitPriceCurrency>>(
                "currency"
            );
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        this.Currency.Validate();
    }

    public PriceTierUnitPrice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PriceTierUnitPrice(PriceTierUnitPrice priceTierUnitPrice)
        : base(priceTierUnitPrice) { }
#pragma warning restore CS8618

    public PriceTierUnitPrice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PriceTierUnitPrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PriceTierUnitPriceFromRaw.FromRawUnchecked"/>
    public static PriceTierUnitPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PriceTierUnitPriceFromRaw : IFromRawJson<PriceTierUnitPrice>
{
    /// <inheritdoc/>
    public PriceTierUnitPrice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PriceTierUnitPrice.FromRawUnchecked(rawData);
}

/// <summary>
/// ISO 4217 currency code
/// </summary>
[JsonConverter(typeof(PriceTierUnitPriceCurrencyConverter))]
public enum PriceTierUnitPriceCurrency
{
    Usd,
    Aed,
    All,
    Amd,
    Ang,
    Aud,
    Awg,
    Azn,
    Bam,
    Bbd,
    Bdt,
    Bgn,
    Bif,
    Bmd,
    Bnd,
    Bsd,
    Bwp,
    Byn,
    Bzd,
    Brl,
    Cad,
    Cdf,
    Chf,
    Cny,
    Czk,
    Dkk,
    Dop,
    Dzd,
    Egp,
    Etb,
    Eur,
    Fjd,
    Gbp,
    Gel,
    Gip,
    Gmd,
    Gyd,
    Hkd,
    Hrk,
    Htg,
    Idr,
    Ils,
    Inr,
    Isk,
    Jmd,
    Jpy,
    Kes,
    Kgs,
    Khr,
    Kmf,
    Krw,
    Kyd,
    Kzt,
    Lbp,
    Lkr,
    Lrd,
    Lsl,
    Mad,
    Mdl,
    Mga,
    Mkd,
    Mmk,
    Mnt,
    Mop,
    Mro,
    Mvr,
    Mwk,
    Mxn,
    Myr,
    Mzn,
    Nad,
    Ngn,
    Nok,
    Npr,
    Nzd,
    Pgk,
    Php,
    Pkr,
    Pln,
    Qar,
    Ron,
    Rsd,
    Rub,
    Rwf,
    Sar,
    Sbd,
    Scr,
    Sek,
    Sgd,
    Sle,
    Sll,
    Sos,
    Szl,
    Thb,
    Tjs,
    Top,
    Try,
    Ttd,
    Tzs,
    Uah,
    Uzs,
    Vnd,
    Vuv,
    Wst,
    Xaf,
    Xcd,
    Yer,
    Zar,
    Zmw,
    Clp,
    Djf,
    Gnf,
    Ugx,
    Pyg,
    Xof,
    Xpf,
}

sealed class PriceTierUnitPriceCurrencyConverter : JsonConverter<PriceTierUnitPriceCurrency>
{
    public override PriceTierUnitPriceCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => PriceTierUnitPriceCurrency.Usd,
            "aed" => PriceTierUnitPriceCurrency.Aed,
            "all" => PriceTierUnitPriceCurrency.All,
            "amd" => PriceTierUnitPriceCurrency.Amd,
            "ang" => PriceTierUnitPriceCurrency.Ang,
            "aud" => PriceTierUnitPriceCurrency.Aud,
            "awg" => PriceTierUnitPriceCurrency.Awg,
            "azn" => PriceTierUnitPriceCurrency.Azn,
            "bam" => PriceTierUnitPriceCurrency.Bam,
            "bbd" => PriceTierUnitPriceCurrency.Bbd,
            "bdt" => PriceTierUnitPriceCurrency.Bdt,
            "bgn" => PriceTierUnitPriceCurrency.Bgn,
            "bif" => PriceTierUnitPriceCurrency.Bif,
            "bmd" => PriceTierUnitPriceCurrency.Bmd,
            "bnd" => PriceTierUnitPriceCurrency.Bnd,
            "bsd" => PriceTierUnitPriceCurrency.Bsd,
            "bwp" => PriceTierUnitPriceCurrency.Bwp,
            "byn" => PriceTierUnitPriceCurrency.Byn,
            "bzd" => PriceTierUnitPriceCurrency.Bzd,
            "brl" => PriceTierUnitPriceCurrency.Brl,
            "cad" => PriceTierUnitPriceCurrency.Cad,
            "cdf" => PriceTierUnitPriceCurrency.Cdf,
            "chf" => PriceTierUnitPriceCurrency.Chf,
            "cny" => PriceTierUnitPriceCurrency.Cny,
            "czk" => PriceTierUnitPriceCurrency.Czk,
            "dkk" => PriceTierUnitPriceCurrency.Dkk,
            "dop" => PriceTierUnitPriceCurrency.Dop,
            "dzd" => PriceTierUnitPriceCurrency.Dzd,
            "egp" => PriceTierUnitPriceCurrency.Egp,
            "etb" => PriceTierUnitPriceCurrency.Etb,
            "eur" => PriceTierUnitPriceCurrency.Eur,
            "fjd" => PriceTierUnitPriceCurrency.Fjd,
            "gbp" => PriceTierUnitPriceCurrency.Gbp,
            "gel" => PriceTierUnitPriceCurrency.Gel,
            "gip" => PriceTierUnitPriceCurrency.Gip,
            "gmd" => PriceTierUnitPriceCurrency.Gmd,
            "gyd" => PriceTierUnitPriceCurrency.Gyd,
            "hkd" => PriceTierUnitPriceCurrency.Hkd,
            "hrk" => PriceTierUnitPriceCurrency.Hrk,
            "htg" => PriceTierUnitPriceCurrency.Htg,
            "idr" => PriceTierUnitPriceCurrency.Idr,
            "ils" => PriceTierUnitPriceCurrency.Ils,
            "inr" => PriceTierUnitPriceCurrency.Inr,
            "isk" => PriceTierUnitPriceCurrency.Isk,
            "jmd" => PriceTierUnitPriceCurrency.Jmd,
            "jpy" => PriceTierUnitPriceCurrency.Jpy,
            "kes" => PriceTierUnitPriceCurrency.Kes,
            "kgs" => PriceTierUnitPriceCurrency.Kgs,
            "khr" => PriceTierUnitPriceCurrency.Khr,
            "kmf" => PriceTierUnitPriceCurrency.Kmf,
            "krw" => PriceTierUnitPriceCurrency.Krw,
            "kyd" => PriceTierUnitPriceCurrency.Kyd,
            "kzt" => PriceTierUnitPriceCurrency.Kzt,
            "lbp" => PriceTierUnitPriceCurrency.Lbp,
            "lkr" => PriceTierUnitPriceCurrency.Lkr,
            "lrd" => PriceTierUnitPriceCurrency.Lrd,
            "lsl" => PriceTierUnitPriceCurrency.Lsl,
            "mad" => PriceTierUnitPriceCurrency.Mad,
            "mdl" => PriceTierUnitPriceCurrency.Mdl,
            "mga" => PriceTierUnitPriceCurrency.Mga,
            "mkd" => PriceTierUnitPriceCurrency.Mkd,
            "mmk" => PriceTierUnitPriceCurrency.Mmk,
            "mnt" => PriceTierUnitPriceCurrency.Mnt,
            "mop" => PriceTierUnitPriceCurrency.Mop,
            "mro" => PriceTierUnitPriceCurrency.Mro,
            "mvr" => PriceTierUnitPriceCurrency.Mvr,
            "mwk" => PriceTierUnitPriceCurrency.Mwk,
            "mxn" => PriceTierUnitPriceCurrency.Mxn,
            "myr" => PriceTierUnitPriceCurrency.Myr,
            "mzn" => PriceTierUnitPriceCurrency.Mzn,
            "nad" => PriceTierUnitPriceCurrency.Nad,
            "ngn" => PriceTierUnitPriceCurrency.Ngn,
            "nok" => PriceTierUnitPriceCurrency.Nok,
            "npr" => PriceTierUnitPriceCurrency.Npr,
            "nzd" => PriceTierUnitPriceCurrency.Nzd,
            "pgk" => PriceTierUnitPriceCurrency.Pgk,
            "php" => PriceTierUnitPriceCurrency.Php,
            "pkr" => PriceTierUnitPriceCurrency.Pkr,
            "pln" => PriceTierUnitPriceCurrency.Pln,
            "qar" => PriceTierUnitPriceCurrency.Qar,
            "ron" => PriceTierUnitPriceCurrency.Ron,
            "rsd" => PriceTierUnitPriceCurrency.Rsd,
            "rub" => PriceTierUnitPriceCurrency.Rub,
            "rwf" => PriceTierUnitPriceCurrency.Rwf,
            "sar" => PriceTierUnitPriceCurrency.Sar,
            "sbd" => PriceTierUnitPriceCurrency.Sbd,
            "scr" => PriceTierUnitPriceCurrency.Scr,
            "sek" => PriceTierUnitPriceCurrency.Sek,
            "sgd" => PriceTierUnitPriceCurrency.Sgd,
            "sle" => PriceTierUnitPriceCurrency.Sle,
            "sll" => PriceTierUnitPriceCurrency.Sll,
            "sos" => PriceTierUnitPriceCurrency.Sos,
            "szl" => PriceTierUnitPriceCurrency.Szl,
            "thb" => PriceTierUnitPriceCurrency.Thb,
            "tjs" => PriceTierUnitPriceCurrency.Tjs,
            "top" => PriceTierUnitPriceCurrency.Top,
            "try" => PriceTierUnitPriceCurrency.Try,
            "ttd" => PriceTierUnitPriceCurrency.Ttd,
            "tzs" => PriceTierUnitPriceCurrency.Tzs,
            "uah" => PriceTierUnitPriceCurrency.Uah,
            "uzs" => PriceTierUnitPriceCurrency.Uzs,
            "vnd" => PriceTierUnitPriceCurrency.Vnd,
            "vuv" => PriceTierUnitPriceCurrency.Vuv,
            "wst" => PriceTierUnitPriceCurrency.Wst,
            "xaf" => PriceTierUnitPriceCurrency.Xaf,
            "xcd" => PriceTierUnitPriceCurrency.Xcd,
            "yer" => PriceTierUnitPriceCurrency.Yer,
            "zar" => PriceTierUnitPriceCurrency.Zar,
            "zmw" => PriceTierUnitPriceCurrency.Zmw,
            "clp" => PriceTierUnitPriceCurrency.Clp,
            "djf" => PriceTierUnitPriceCurrency.Djf,
            "gnf" => PriceTierUnitPriceCurrency.Gnf,
            "ugx" => PriceTierUnitPriceCurrency.Ugx,
            "pyg" => PriceTierUnitPriceCurrency.Pyg,
            "xof" => PriceTierUnitPriceCurrency.Xof,
            "xpf" => PriceTierUnitPriceCurrency.Xpf,
            _ => (PriceTierUnitPriceCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PriceTierUnitPriceCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PriceTierUnitPriceCurrency.Usd => "usd",
                PriceTierUnitPriceCurrency.Aed => "aed",
                PriceTierUnitPriceCurrency.All => "all",
                PriceTierUnitPriceCurrency.Amd => "amd",
                PriceTierUnitPriceCurrency.Ang => "ang",
                PriceTierUnitPriceCurrency.Aud => "aud",
                PriceTierUnitPriceCurrency.Awg => "awg",
                PriceTierUnitPriceCurrency.Azn => "azn",
                PriceTierUnitPriceCurrency.Bam => "bam",
                PriceTierUnitPriceCurrency.Bbd => "bbd",
                PriceTierUnitPriceCurrency.Bdt => "bdt",
                PriceTierUnitPriceCurrency.Bgn => "bgn",
                PriceTierUnitPriceCurrency.Bif => "bif",
                PriceTierUnitPriceCurrency.Bmd => "bmd",
                PriceTierUnitPriceCurrency.Bnd => "bnd",
                PriceTierUnitPriceCurrency.Bsd => "bsd",
                PriceTierUnitPriceCurrency.Bwp => "bwp",
                PriceTierUnitPriceCurrency.Byn => "byn",
                PriceTierUnitPriceCurrency.Bzd => "bzd",
                PriceTierUnitPriceCurrency.Brl => "brl",
                PriceTierUnitPriceCurrency.Cad => "cad",
                PriceTierUnitPriceCurrency.Cdf => "cdf",
                PriceTierUnitPriceCurrency.Chf => "chf",
                PriceTierUnitPriceCurrency.Cny => "cny",
                PriceTierUnitPriceCurrency.Czk => "czk",
                PriceTierUnitPriceCurrency.Dkk => "dkk",
                PriceTierUnitPriceCurrency.Dop => "dop",
                PriceTierUnitPriceCurrency.Dzd => "dzd",
                PriceTierUnitPriceCurrency.Egp => "egp",
                PriceTierUnitPriceCurrency.Etb => "etb",
                PriceTierUnitPriceCurrency.Eur => "eur",
                PriceTierUnitPriceCurrency.Fjd => "fjd",
                PriceTierUnitPriceCurrency.Gbp => "gbp",
                PriceTierUnitPriceCurrency.Gel => "gel",
                PriceTierUnitPriceCurrency.Gip => "gip",
                PriceTierUnitPriceCurrency.Gmd => "gmd",
                PriceTierUnitPriceCurrency.Gyd => "gyd",
                PriceTierUnitPriceCurrency.Hkd => "hkd",
                PriceTierUnitPriceCurrency.Hrk => "hrk",
                PriceTierUnitPriceCurrency.Htg => "htg",
                PriceTierUnitPriceCurrency.Idr => "idr",
                PriceTierUnitPriceCurrency.Ils => "ils",
                PriceTierUnitPriceCurrency.Inr => "inr",
                PriceTierUnitPriceCurrency.Isk => "isk",
                PriceTierUnitPriceCurrency.Jmd => "jmd",
                PriceTierUnitPriceCurrency.Jpy => "jpy",
                PriceTierUnitPriceCurrency.Kes => "kes",
                PriceTierUnitPriceCurrency.Kgs => "kgs",
                PriceTierUnitPriceCurrency.Khr => "khr",
                PriceTierUnitPriceCurrency.Kmf => "kmf",
                PriceTierUnitPriceCurrency.Krw => "krw",
                PriceTierUnitPriceCurrency.Kyd => "kyd",
                PriceTierUnitPriceCurrency.Kzt => "kzt",
                PriceTierUnitPriceCurrency.Lbp => "lbp",
                PriceTierUnitPriceCurrency.Lkr => "lkr",
                PriceTierUnitPriceCurrency.Lrd => "lrd",
                PriceTierUnitPriceCurrency.Lsl => "lsl",
                PriceTierUnitPriceCurrency.Mad => "mad",
                PriceTierUnitPriceCurrency.Mdl => "mdl",
                PriceTierUnitPriceCurrency.Mga => "mga",
                PriceTierUnitPriceCurrency.Mkd => "mkd",
                PriceTierUnitPriceCurrency.Mmk => "mmk",
                PriceTierUnitPriceCurrency.Mnt => "mnt",
                PriceTierUnitPriceCurrency.Mop => "mop",
                PriceTierUnitPriceCurrency.Mro => "mro",
                PriceTierUnitPriceCurrency.Mvr => "mvr",
                PriceTierUnitPriceCurrency.Mwk => "mwk",
                PriceTierUnitPriceCurrency.Mxn => "mxn",
                PriceTierUnitPriceCurrency.Myr => "myr",
                PriceTierUnitPriceCurrency.Mzn => "mzn",
                PriceTierUnitPriceCurrency.Nad => "nad",
                PriceTierUnitPriceCurrency.Ngn => "ngn",
                PriceTierUnitPriceCurrency.Nok => "nok",
                PriceTierUnitPriceCurrency.Npr => "npr",
                PriceTierUnitPriceCurrency.Nzd => "nzd",
                PriceTierUnitPriceCurrency.Pgk => "pgk",
                PriceTierUnitPriceCurrency.Php => "php",
                PriceTierUnitPriceCurrency.Pkr => "pkr",
                PriceTierUnitPriceCurrency.Pln => "pln",
                PriceTierUnitPriceCurrency.Qar => "qar",
                PriceTierUnitPriceCurrency.Ron => "ron",
                PriceTierUnitPriceCurrency.Rsd => "rsd",
                PriceTierUnitPriceCurrency.Rub => "rub",
                PriceTierUnitPriceCurrency.Rwf => "rwf",
                PriceTierUnitPriceCurrency.Sar => "sar",
                PriceTierUnitPriceCurrency.Sbd => "sbd",
                PriceTierUnitPriceCurrency.Scr => "scr",
                PriceTierUnitPriceCurrency.Sek => "sek",
                PriceTierUnitPriceCurrency.Sgd => "sgd",
                PriceTierUnitPriceCurrency.Sle => "sle",
                PriceTierUnitPriceCurrency.Sll => "sll",
                PriceTierUnitPriceCurrency.Sos => "sos",
                PriceTierUnitPriceCurrency.Szl => "szl",
                PriceTierUnitPriceCurrency.Thb => "thb",
                PriceTierUnitPriceCurrency.Tjs => "tjs",
                PriceTierUnitPriceCurrency.Top => "top",
                PriceTierUnitPriceCurrency.Try => "try",
                PriceTierUnitPriceCurrency.Ttd => "ttd",
                PriceTierUnitPriceCurrency.Tzs => "tzs",
                PriceTierUnitPriceCurrency.Uah => "uah",
                PriceTierUnitPriceCurrency.Uzs => "uzs",
                PriceTierUnitPriceCurrency.Vnd => "vnd",
                PriceTierUnitPriceCurrency.Vuv => "vuv",
                PriceTierUnitPriceCurrency.Wst => "wst",
                PriceTierUnitPriceCurrency.Xaf => "xaf",
                PriceTierUnitPriceCurrency.Xcd => "xcd",
                PriceTierUnitPriceCurrency.Yer => "yer",
                PriceTierUnitPriceCurrency.Zar => "zar",
                PriceTierUnitPriceCurrency.Zmw => "zmw",
                PriceTierUnitPriceCurrency.Clp => "clp",
                PriceTierUnitPriceCurrency.Djf => "djf",
                PriceTierUnitPriceCurrency.Gnf => "gnf",
                PriceTierUnitPriceCurrency.Ugx => "ugx",
                PriceTierUnitPriceCurrency.Pyg => "pyg",
                PriceTierUnitPriceCurrency.Xof => "xof",
                PriceTierUnitPriceCurrency.Xpf => "xpf",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Subscription entitlement reference
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SubscriptionEntitlement, SubscriptionEntitlementFromRaw>))]
public sealed record class SubscriptionEntitlement : JsonModel
{
    /// <summary>
    /// Feature ID or currency ID
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
    /// Entitlement type (FEATURE or CREDIT)
    /// </summary>
    public required ApiEnum<string, SubscriptionEntitlementType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, SubscriptionEntitlementType>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Type.Validate();
    }

    public SubscriptionEntitlement() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionEntitlement(SubscriptionEntitlement subscriptionEntitlement)
        : base(subscriptionEntitlement) { }
#pragma warning restore CS8618

    public SubscriptionEntitlement(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionEntitlement(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionEntitlementFromRaw.FromRawUnchecked"/>
    public static SubscriptionEntitlement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionEntitlementFromRaw : IFromRawJson<SubscriptionEntitlement>
{
    /// <inheritdoc/>
    public SubscriptionEntitlement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionEntitlement.FromRawUnchecked(rawData);
}

/// <summary>
/// Entitlement type (FEATURE or CREDIT)
/// </summary>
[JsonConverter(typeof(SubscriptionEntitlementTypeConverter))]
public enum SubscriptionEntitlementType
{
    Feature,
    Credit,
}

sealed class SubscriptionEntitlementTypeConverter : JsonConverter<SubscriptionEntitlementType>
{
    public override SubscriptionEntitlementType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FEATURE" => SubscriptionEntitlementType.Feature,
            "CREDIT" => SubscriptionEntitlementType.Credit,
            _ => (SubscriptionEntitlementType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionEntitlementType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionEntitlementType.Feature => "FEATURE",
                SubscriptionEntitlementType.Credit => "CREDIT",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Trial configuration
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Trial, TrialFromRaw>))]
public sealed record class Trial : JsonModel
{
    /// <summary>
    /// Behavior when the trial ends
    /// </summary>
    public required ApiEnum<string, TrialTrialEndBehavior> TrialEndBehavior
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TrialTrialEndBehavior>>(
                "trialEndBehavior"
            );
        }
        init { this._rawData.Set("trialEndBehavior", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.TrialEndBehavior.Validate();
    }

    public Trial() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Trial(Trial trial)
        : base(trial) { }
#pragma warning restore CS8618

    public Trial(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Trial(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TrialFromRaw.FromRawUnchecked"/>
    public static Trial FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Trial(ApiEnum<string, TrialTrialEndBehavior> trialEndBehavior)
        : this()
    {
        this.TrialEndBehavior = trialEndBehavior;
    }
}

class TrialFromRaw : IFromRawJson<Trial>
{
    /// <inheritdoc/>
    public Trial FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Trial.FromRawUnchecked(rawData);
}

/// <summary>
/// Behavior when the trial ends
/// </summary>
[JsonConverter(typeof(TrialTrialEndBehaviorConverter))]
public enum TrialTrialEndBehavior
{
    ConvertToPaid,
    CancelSubscription,
}

sealed class TrialTrialEndBehaviorConverter : JsonConverter<TrialTrialEndBehavior>
{
    public override TrialTrialEndBehavior Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "CONVERT_TO_PAID" => TrialTrialEndBehavior.ConvertToPaid,
            "CANCEL_SUBSCRIPTION" => TrialTrialEndBehavior.CancelSubscription,
            _ => (TrialTrialEndBehavior)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TrialTrialEndBehavior value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TrialTrialEndBehavior.ConvertToPaid => "CONVERT_TO_PAID",
                TrialTrialEndBehavior.CancelSubscription => "CANCEL_SUBSCRIPTION",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
