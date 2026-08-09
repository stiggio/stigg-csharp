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
/// Customer subscription to a plan
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<SubscriptionListResponse, SubscriptionListResponseFromRaw>)
)]
public sealed record class SubscriptionListResponse : JsonModel
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
    public required ApiEnum<string, SubscriptionListResponsePaymentCollection> PaymentCollection
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, SubscriptionListResponsePaymentCollection>
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
    public required ApiEnum<string, SubscriptionListResponsePricingType> PricingType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, SubscriptionListResponsePricingType>
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
    public required ApiEnum<string, SubscriptionListResponseStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, SubscriptionListResponseStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    public IReadOnlyList<SubscriptionListResponseAddon>? Addons
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<SubscriptionListResponseAddon>>(
                "addons"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<SubscriptionListResponseAddon>?>(
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
    public SubscriptionListResponseBudget? Budget
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SubscriptionListResponseBudget>("budget");
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
    public ApiEnum<string, SubscriptionListResponseCancelReason>? CancelReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, SubscriptionListResponseCancelReason>
            >("cancelReason");
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
    public IReadOnlyList<SubscriptionListResponseCoupon>? Coupons
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<SubscriptionListResponseCoupon>>(
                "coupons"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<SubscriptionListResponseCoupon>?>(
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
    public IReadOnlyList<SubscriptionListResponseFutureUpdate>? FutureUpdates
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<SubscriptionListResponseFutureUpdate>
            >("futureUpdates");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<SubscriptionListResponseFutureUpdate>?>(
                "futureUpdates",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Latest invoice for the subscription
    /// </summary>
    public SubscriptionListResponseLatestInvoice? LatestInvoice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SubscriptionListResponseLatestInvoice>(
                "latestInvoice"
            );
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
    public SubscriptionListResponseMinimumSpend? MinimumSpend
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SubscriptionListResponseMinimumSpend>(
                "minimumSpend"
            );
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
    public ApiEnum<string, SubscriptionListResponsePaymentCollectionMethod>? PaymentCollectionMethod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, SubscriptionListResponsePaymentCollectionMethod>
            >("paymentCollectionMethod");
        }
        init { this._rawData.Set("paymentCollectionMethod", value); }
    }

    public IReadOnlyList<SubscriptionListResponsePrice>? Prices
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<SubscriptionListResponsePrice>>(
                "prices"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<SubscriptionListResponsePrice>?>(
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
    public IReadOnlyList<SubscriptionListResponseSubscriptionEntitlement>? SubscriptionEntitlements
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<SubscriptionListResponseSubscriptionEntitlement>
            >("subscriptionEntitlements");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<SubscriptionListResponseSubscriptionEntitlement>?>(
                "subscriptionEntitlements",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Trial configuration
    /// </summary>
    public SubscriptionListResponseTrial? Trial
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SubscriptionListResponseTrial>("trial");
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

    public SubscriptionListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionListResponse(SubscriptionListResponse subscriptionListResponse)
        : base(subscriptionListResponse) { }
#pragma warning restore CS8618

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
}

class SubscriptionListResponseFromRaw : IFromRawJson<SubscriptionListResponse>
{
    /// <inheritdoc/>
    public SubscriptionListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionListResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Payment collection
/// </summary>
[JsonConverter(typeof(SubscriptionListResponsePaymentCollectionConverter))]
public enum SubscriptionListResponsePaymentCollection
{
    NotRequired,
    Processing,
    Failed,
    ActionRequired,
}

sealed class SubscriptionListResponsePaymentCollectionConverter
    : JsonConverter<SubscriptionListResponsePaymentCollection>
{
    public override SubscriptionListResponsePaymentCollection Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "NOT_REQUIRED" => SubscriptionListResponsePaymentCollection.NotRequired,
            "PROCESSING" => SubscriptionListResponsePaymentCollection.Processing,
            "FAILED" => SubscriptionListResponsePaymentCollection.Failed,
            "ACTION_REQUIRED" => SubscriptionListResponsePaymentCollection.ActionRequired,
            _ => (SubscriptionListResponsePaymentCollection)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionListResponsePaymentCollection value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionListResponsePaymentCollection.NotRequired => "NOT_REQUIRED",
                SubscriptionListResponsePaymentCollection.Processing => "PROCESSING",
                SubscriptionListResponsePaymentCollection.Failed => "FAILED",
                SubscriptionListResponsePaymentCollection.ActionRequired => "ACTION_REQUIRED",
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
[JsonConverter(typeof(SubscriptionListResponsePricingTypeConverter))]
public enum SubscriptionListResponsePricingType
{
    Free,
    Paid,
    Custom,
}

sealed class SubscriptionListResponsePricingTypeConverter
    : JsonConverter<SubscriptionListResponsePricingType>
{
    public override SubscriptionListResponsePricingType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FREE" => SubscriptionListResponsePricingType.Free,
            "PAID" => SubscriptionListResponsePricingType.Paid,
            "CUSTOM" => SubscriptionListResponsePricingType.Custom,
            _ => (SubscriptionListResponsePricingType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionListResponsePricingType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionListResponsePricingType.Free => "FREE",
                SubscriptionListResponsePricingType.Paid => "PAID",
                SubscriptionListResponsePricingType.Custom => "CUSTOM",
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
[JsonConverter(typeof(SubscriptionListResponseStatusConverter))]
public enum SubscriptionListResponseStatus
{
    PaymentPending,
    Active,
    Expired,
    InTrial,
    Canceled,
    NotStarted,
}

sealed class SubscriptionListResponseStatusConverter : JsonConverter<SubscriptionListResponseStatus>
{
    public override SubscriptionListResponseStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PAYMENT_PENDING" => SubscriptionListResponseStatus.PaymentPending,
            "ACTIVE" => SubscriptionListResponseStatus.Active,
            "EXPIRED" => SubscriptionListResponseStatus.Expired,
            "IN_TRIAL" => SubscriptionListResponseStatus.InTrial,
            "CANCELED" => SubscriptionListResponseStatus.Canceled,
            "NOT_STARTED" => SubscriptionListResponseStatus.NotStarted,
            _ => (SubscriptionListResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionListResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionListResponseStatus.PaymentPending => "PAYMENT_PENDING",
                SubscriptionListResponseStatus.Active => "ACTIVE",
                SubscriptionListResponseStatus.Expired => "EXPIRED",
                SubscriptionListResponseStatus.InTrial => "IN_TRIAL",
                SubscriptionListResponseStatus.Canceled => "CANCELED",
                SubscriptionListResponseStatus.NotStarted => "NOT_STARTED",
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
[JsonConverter(
    typeof(JsonModelConverter<SubscriptionListResponseAddon, SubscriptionListResponseAddonFromRaw>)
)]
public sealed record class SubscriptionListResponseAddon : JsonModel
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

    public SubscriptionListResponseAddon() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionListResponseAddon(
        SubscriptionListResponseAddon subscriptionListResponseAddon
    )
        : base(subscriptionListResponseAddon) { }
#pragma warning restore CS8618

    public SubscriptionListResponseAddon(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionListResponseAddon(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionListResponseAddonFromRaw.FromRawUnchecked"/>
    public static SubscriptionListResponseAddon FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionListResponseAddonFromRaw : IFromRawJson<SubscriptionListResponseAddon>
{
    /// <inheritdoc/>
    public SubscriptionListResponseAddon FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionListResponseAddon.FromRawUnchecked(rawData);
}

/// <summary>
/// Budget configuration
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionListResponseBudget,
        SubscriptionListResponseBudgetFromRaw
    >)
)]
public sealed record class SubscriptionListResponseBudget : JsonModel
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

    public SubscriptionListResponseBudget() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionListResponseBudget(
        SubscriptionListResponseBudget subscriptionListResponseBudget
    )
        : base(subscriptionListResponseBudget) { }
#pragma warning restore CS8618

    public SubscriptionListResponseBudget(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionListResponseBudget(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionListResponseBudgetFromRaw.FromRawUnchecked"/>
    public static SubscriptionListResponseBudget FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionListResponseBudgetFromRaw : IFromRawJson<SubscriptionListResponseBudget>
{
    /// <inheritdoc/>
    public SubscriptionListResponseBudget FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionListResponseBudget.FromRawUnchecked(rawData);
}

/// <summary>
/// Subscription cancel reason
/// </summary>
[JsonConverter(typeof(SubscriptionListResponseCancelReasonConverter))]
public enum SubscriptionListResponseCancelReason
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

sealed class SubscriptionListResponseCancelReasonConverter
    : JsonConverter<SubscriptionListResponseCancelReason>
{
    public override SubscriptionListResponseCancelReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "UPGRADE_OR_DOWNGRADE" => SubscriptionListResponseCancelReason.UpgradeOrDowngrade,
            "CANCELLED_BY_BILLING" => SubscriptionListResponseCancelReason.CancelledByBilling,
            "EXPIRED" => SubscriptionListResponseCancelReason.Expired,
            "DETACH_BILLING" => SubscriptionListResponseCancelReason.DetachBilling,
            "TRIAL_ENDED" => SubscriptionListResponseCancelReason.TrialEnded,
            "Immediate" => SubscriptionListResponseCancelReason.Immediate,
            "TRIAL_CONVERTED" => SubscriptionListResponseCancelReason.TrialConverted,
            "PENDING_PAYMENT_EXPIRED" => SubscriptionListResponseCancelReason.PendingPaymentExpired,
            "ScheduledCancellation" => SubscriptionListResponseCancelReason.ScheduledCancellation,
            "CustomerArchived" => SubscriptionListResponseCancelReason.CustomerArchived,
            "AutoCancellationRule" => SubscriptionListResponseCancelReason.AutoCancellationRule,
            _ => (SubscriptionListResponseCancelReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionListResponseCancelReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionListResponseCancelReason.UpgradeOrDowngrade => "UPGRADE_OR_DOWNGRADE",
                SubscriptionListResponseCancelReason.CancelledByBilling => "CANCELLED_BY_BILLING",
                SubscriptionListResponseCancelReason.Expired => "EXPIRED",
                SubscriptionListResponseCancelReason.DetachBilling => "DETACH_BILLING",
                SubscriptionListResponseCancelReason.TrialEnded => "TRIAL_ENDED",
                SubscriptionListResponseCancelReason.Immediate => "Immediate",
                SubscriptionListResponseCancelReason.TrialConverted => "TRIAL_CONVERTED",
                SubscriptionListResponseCancelReason.PendingPaymentExpired =>
                    "PENDING_PAYMENT_EXPIRED",
                SubscriptionListResponseCancelReason.ScheduledCancellation =>
                    "ScheduledCancellation",
                SubscriptionListResponseCancelReason.CustomerArchived => "CustomerArchived",
                SubscriptionListResponseCancelReason.AutoCancellationRule => "AutoCancellationRule",
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
[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionListResponseCoupon,
        SubscriptionListResponseCouponFromRaw
    >)
)]
public sealed record class SubscriptionListResponseCoupon : JsonModel
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
    public required ApiEnum<string, SubscriptionListResponseCouponStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, SubscriptionListResponseCouponStatus>
            >("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Fixed amount discounts by currency
    /// </summary>
    public IReadOnlyList<SubscriptionListResponseCouponAmountsOff>? AmountsOff
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<SubscriptionListResponseCouponAmountsOff>
            >("amountsOff");
        }
        init
        {
            this._rawData.Set<ImmutableArray<SubscriptionListResponseCouponAmountsOff>?>(
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

    public SubscriptionListResponseCoupon() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionListResponseCoupon(
        SubscriptionListResponseCoupon subscriptionListResponseCoupon
    )
        : base(subscriptionListResponseCoupon) { }
#pragma warning restore CS8618

    public SubscriptionListResponseCoupon(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionListResponseCoupon(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionListResponseCouponFromRaw.FromRawUnchecked"/>
    public static SubscriptionListResponseCoupon FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionListResponseCouponFromRaw : IFromRawJson<SubscriptionListResponseCoupon>
{
    /// <inheritdoc/>
    public SubscriptionListResponseCoupon FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionListResponseCoupon.FromRawUnchecked(rawData);
}

/// <summary>
/// Coupon status
/// </summary>
[JsonConverter(typeof(SubscriptionListResponseCouponStatusConverter))]
public enum SubscriptionListResponseCouponStatus
{
    Active,
    Expired,
    Removed,
}

sealed class SubscriptionListResponseCouponStatusConverter
    : JsonConverter<SubscriptionListResponseCouponStatus>
{
    public override SubscriptionListResponseCouponStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ACTIVE" => SubscriptionListResponseCouponStatus.Active,
            "EXPIRED" => SubscriptionListResponseCouponStatus.Expired,
            "REMOVED" => SubscriptionListResponseCouponStatus.Removed,
            _ => (SubscriptionListResponseCouponStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionListResponseCouponStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionListResponseCouponStatus.Active => "ACTIVE",
                SubscriptionListResponseCouponStatus.Expired => "EXPIRED",
                SubscriptionListResponseCouponStatus.Removed => "REMOVED",
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
        SubscriptionListResponseCouponAmountsOff,
        SubscriptionListResponseCouponAmountsOffFromRaw
    >)
)]
public sealed record class SubscriptionListResponseCouponAmountsOff : JsonModel
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
    public ApiEnum<string, SubscriptionListResponseCouponAmountsOffCurrency>? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, SubscriptionListResponseCouponAmountsOffCurrency>
            >("currency");
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

    public SubscriptionListResponseCouponAmountsOff() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionListResponseCouponAmountsOff(
        SubscriptionListResponseCouponAmountsOff subscriptionListResponseCouponAmountsOff
    )
        : base(subscriptionListResponseCouponAmountsOff) { }
#pragma warning restore CS8618

    public SubscriptionListResponseCouponAmountsOff(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionListResponseCouponAmountsOff(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionListResponseCouponAmountsOffFromRaw.FromRawUnchecked"/>
    public static SubscriptionListResponseCouponAmountsOff FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionListResponseCouponAmountsOffFromRaw
    : IFromRawJson<SubscriptionListResponseCouponAmountsOff>
{
    /// <inheritdoc/>
    public SubscriptionListResponseCouponAmountsOff FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionListResponseCouponAmountsOff.FromRawUnchecked(rawData);
}

/// <summary>
/// The price currency
/// </summary>
[JsonConverter(typeof(SubscriptionListResponseCouponAmountsOffCurrencyConverter))]
public enum SubscriptionListResponseCouponAmountsOffCurrency
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

sealed class SubscriptionListResponseCouponAmountsOffCurrencyConverter
    : JsonConverter<SubscriptionListResponseCouponAmountsOffCurrency>
{
    public override SubscriptionListResponseCouponAmountsOffCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => SubscriptionListResponseCouponAmountsOffCurrency.Usd,
            "aed" => SubscriptionListResponseCouponAmountsOffCurrency.Aed,
            "all" => SubscriptionListResponseCouponAmountsOffCurrency.All,
            "amd" => SubscriptionListResponseCouponAmountsOffCurrency.Amd,
            "ang" => SubscriptionListResponseCouponAmountsOffCurrency.Ang,
            "aud" => SubscriptionListResponseCouponAmountsOffCurrency.Aud,
            "awg" => SubscriptionListResponseCouponAmountsOffCurrency.Awg,
            "azn" => SubscriptionListResponseCouponAmountsOffCurrency.Azn,
            "bam" => SubscriptionListResponseCouponAmountsOffCurrency.Bam,
            "bbd" => SubscriptionListResponseCouponAmountsOffCurrency.Bbd,
            "bdt" => SubscriptionListResponseCouponAmountsOffCurrency.Bdt,
            "bgn" => SubscriptionListResponseCouponAmountsOffCurrency.Bgn,
            "bif" => SubscriptionListResponseCouponAmountsOffCurrency.Bif,
            "bmd" => SubscriptionListResponseCouponAmountsOffCurrency.Bmd,
            "bnd" => SubscriptionListResponseCouponAmountsOffCurrency.Bnd,
            "bsd" => SubscriptionListResponseCouponAmountsOffCurrency.Bsd,
            "bwp" => SubscriptionListResponseCouponAmountsOffCurrency.Bwp,
            "byn" => SubscriptionListResponseCouponAmountsOffCurrency.Byn,
            "bzd" => SubscriptionListResponseCouponAmountsOffCurrency.Bzd,
            "brl" => SubscriptionListResponseCouponAmountsOffCurrency.Brl,
            "cad" => SubscriptionListResponseCouponAmountsOffCurrency.Cad,
            "cdf" => SubscriptionListResponseCouponAmountsOffCurrency.Cdf,
            "chf" => SubscriptionListResponseCouponAmountsOffCurrency.Chf,
            "cny" => SubscriptionListResponseCouponAmountsOffCurrency.Cny,
            "czk" => SubscriptionListResponseCouponAmountsOffCurrency.Czk,
            "dkk" => SubscriptionListResponseCouponAmountsOffCurrency.Dkk,
            "dop" => SubscriptionListResponseCouponAmountsOffCurrency.Dop,
            "dzd" => SubscriptionListResponseCouponAmountsOffCurrency.Dzd,
            "egp" => SubscriptionListResponseCouponAmountsOffCurrency.Egp,
            "etb" => SubscriptionListResponseCouponAmountsOffCurrency.Etb,
            "eur" => SubscriptionListResponseCouponAmountsOffCurrency.Eur,
            "fjd" => SubscriptionListResponseCouponAmountsOffCurrency.Fjd,
            "gbp" => SubscriptionListResponseCouponAmountsOffCurrency.Gbp,
            "gel" => SubscriptionListResponseCouponAmountsOffCurrency.Gel,
            "gip" => SubscriptionListResponseCouponAmountsOffCurrency.Gip,
            "gmd" => SubscriptionListResponseCouponAmountsOffCurrency.Gmd,
            "gyd" => SubscriptionListResponseCouponAmountsOffCurrency.Gyd,
            "hkd" => SubscriptionListResponseCouponAmountsOffCurrency.Hkd,
            "hrk" => SubscriptionListResponseCouponAmountsOffCurrency.Hrk,
            "htg" => SubscriptionListResponseCouponAmountsOffCurrency.Htg,
            "idr" => SubscriptionListResponseCouponAmountsOffCurrency.Idr,
            "ils" => SubscriptionListResponseCouponAmountsOffCurrency.Ils,
            "inr" => SubscriptionListResponseCouponAmountsOffCurrency.Inr,
            "isk" => SubscriptionListResponseCouponAmountsOffCurrency.Isk,
            "jmd" => SubscriptionListResponseCouponAmountsOffCurrency.Jmd,
            "jpy" => SubscriptionListResponseCouponAmountsOffCurrency.Jpy,
            "kes" => SubscriptionListResponseCouponAmountsOffCurrency.Kes,
            "kgs" => SubscriptionListResponseCouponAmountsOffCurrency.Kgs,
            "khr" => SubscriptionListResponseCouponAmountsOffCurrency.Khr,
            "kmf" => SubscriptionListResponseCouponAmountsOffCurrency.Kmf,
            "krw" => SubscriptionListResponseCouponAmountsOffCurrency.Krw,
            "kyd" => SubscriptionListResponseCouponAmountsOffCurrency.Kyd,
            "kzt" => SubscriptionListResponseCouponAmountsOffCurrency.Kzt,
            "lbp" => SubscriptionListResponseCouponAmountsOffCurrency.Lbp,
            "lkr" => SubscriptionListResponseCouponAmountsOffCurrency.Lkr,
            "lrd" => SubscriptionListResponseCouponAmountsOffCurrency.Lrd,
            "lsl" => SubscriptionListResponseCouponAmountsOffCurrency.Lsl,
            "mad" => SubscriptionListResponseCouponAmountsOffCurrency.Mad,
            "mdl" => SubscriptionListResponseCouponAmountsOffCurrency.Mdl,
            "mga" => SubscriptionListResponseCouponAmountsOffCurrency.Mga,
            "mkd" => SubscriptionListResponseCouponAmountsOffCurrency.Mkd,
            "mmk" => SubscriptionListResponseCouponAmountsOffCurrency.Mmk,
            "mnt" => SubscriptionListResponseCouponAmountsOffCurrency.Mnt,
            "mop" => SubscriptionListResponseCouponAmountsOffCurrency.Mop,
            "mro" => SubscriptionListResponseCouponAmountsOffCurrency.Mro,
            "mvr" => SubscriptionListResponseCouponAmountsOffCurrency.Mvr,
            "mwk" => SubscriptionListResponseCouponAmountsOffCurrency.Mwk,
            "mxn" => SubscriptionListResponseCouponAmountsOffCurrency.Mxn,
            "myr" => SubscriptionListResponseCouponAmountsOffCurrency.Myr,
            "mzn" => SubscriptionListResponseCouponAmountsOffCurrency.Mzn,
            "nad" => SubscriptionListResponseCouponAmountsOffCurrency.Nad,
            "ngn" => SubscriptionListResponseCouponAmountsOffCurrency.Ngn,
            "nok" => SubscriptionListResponseCouponAmountsOffCurrency.Nok,
            "npr" => SubscriptionListResponseCouponAmountsOffCurrency.Npr,
            "nzd" => SubscriptionListResponseCouponAmountsOffCurrency.Nzd,
            "pgk" => SubscriptionListResponseCouponAmountsOffCurrency.Pgk,
            "php" => SubscriptionListResponseCouponAmountsOffCurrency.Php,
            "pkr" => SubscriptionListResponseCouponAmountsOffCurrency.Pkr,
            "pln" => SubscriptionListResponseCouponAmountsOffCurrency.Pln,
            "qar" => SubscriptionListResponseCouponAmountsOffCurrency.Qar,
            "ron" => SubscriptionListResponseCouponAmountsOffCurrency.Ron,
            "rsd" => SubscriptionListResponseCouponAmountsOffCurrency.Rsd,
            "rub" => SubscriptionListResponseCouponAmountsOffCurrency.Rub,
            "rwf" => SubscriptionListResponseCouponAmountsOffCurrency.Rwf,
            "sar" => SubscriptionListResponseCouponAmountsOffCurrency.Sar,
            "sbd" => SubscriptionListResponseCouponAmountsOffCurrency.Sbd,
            "scr" => SubscriptionListResponseCouponAmountsOffCurrency.Scr,
            "sek" => SubscriptionListResponseCouponAmountsOffCurrency.Sek,
            "sgd" => SubscriptionListResponseCouponAmountsOffCurrency.Sgd,
            "sle" => SubscriptionListResponseCouponAmountsOffCurrency.Sle,
            "sll" => SubscriptionListResponseCouponAmountsOffCurrency.Sll,
            "sos" => SubscriptionListResponseCouponAmountsOffCurrency.Sos,
            "szl" => SubscriptionListResponseCouponAmountsOffCurrency.Szl,
            "thb" => SubscriptionListResponseCouponAmountsOffCurrency.Thb,
            "tjs" => SubscriptionListResponseCouponAmountsOffCurrency.Tjs,
            "top" => SubscriptionListResponseCouponAmountsOffCurrency.Top,
            "try" => SubscriptionListResponseCouponAmountsOffCurrency.Try,
            "ttd" => SubscriptionListResponseCouponAmountsOffCurrency.Ttd,
            "tzs" => SubscriptionListResponseCouponAmountsOffCurrency.Tzs,
            "uah" => SubscriptionListResponseCouponAmountsOffCurrency.Uah,
            "uzs" => SubscriptionListResponseCouponAmountsOffCurrency.Uzs,
            "vnd" => SubscriptionListResponseCouponAmountsOffCurrency.Vnd,
            "vuv" => SubscriptionListResponseCouponAmountsOffCurrency.Vuv,
            "wst" => SubscriptionListResponseCouponAmountsOffCurrency.Wst,
            "xaf" => SubscriptionListResponseCouponAmountsOffCurrency.Xaf,
            "xcd" => SubscriptionListResponseCouponAmountsOffCurrency.Xcd,
            "yer" => SubscriptionListResponseCouponAmountsOffCurrency.Yer,
            "zar" => SubscriptionListResponseCouponAmountsOffCurrency.Zar,
            "zmw" => SubscriptionListResponseCouponAmountsOffCurrency.Zmw,
            "clp" => SubscriptionListResponseCouponAmountsOffCurrency.Clp,
            "djf" => SubscriptionListResponseCouponAmountsOffCurrency.Djf,
            "gnf" => SubscriptionListResponseCouponAmountsOffCurrency.Gnf,
            "ugx" => SubscriptionListResponseCouponAmountsOffCurrency.Ugx,
            "pyg" => SubscriptionListResponseCouponAmountsOffCurrency.Pyg,
            "xof" => SubscriptionListResponseCouponAmountsOffCurrency.Xof,
            "xpf" => SubscriptionListResponseCouponAmountsOffCurrency.Xpf,
            _ => (SubscriptionListResponseCouponAmountsOffCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionListResponseCouponAmountsOffCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionListResponseCouponAmountsOffCurrency.Usd => "usd",
                SubscriptionListResponseCouponAmountsOffCurrency.Aed => "aed",
                SubscriptionListResponseCouponAmountsOffCurrency.All => "all",
                SubscriptionListResponseCouponAmountsOffCurrency.Amd => "amd",
                SubscriptionListResponseCouponAmountsOffCurrency.Ang => "ang",
                SubscriptionListResponseCouponAmountsOffCurrency.Aud => "aud",
                SubscriptionListResponseCouponAmountsOffCurrency.Awg => "awg",
                SubscriptionListResponseCouponAmountsOffCurrency.Azn => "azn",
                SubscriptionListResponseCouponAmountsOffCurrency.Bam => "bam",
                SubscriptionListResponseCouponAmountsOffCurrency.Bbd => "bbd",
                SubscriptionListResponseCouponAmountsOffCurrency.Bdt => "bdt",
                SubscriptionListResponseCouponAmountsOffCurrency.Bgn => "bgn",
                SubscriptionListResponseCouponAmountsOffCurrency.Bif => "bif",
                SubscriptionListResponseCouponAmountsOffCurrency.Bmd => "bmd",
                SubscriptionListResponseCouponAmountsOffCurrency.Bnd => "bnd",
                SubscriptionListResponseCouponAmountsOffCurrency.Bsd => "bsd",
                SubscriptionListResponseCouponAmountsOffCurrency.Bwp => "bwp",
                SubscriptionListResponseCouponAmountsOffCurrency.Byn => "byn",
                SubscriptionListResponseCouponAmountsOffCurrency.Bzd => "bzd",
                SubscriptionListResponseCouponAmountsOffCurrency.Brl => "brl",
                SubscriptionListResponseCouponAmountsOffCurrency.Cad => "cad",
                SubscriptionListResponseCouponAmountsOffCurrency.Cdf => "cdf",
                SubscriptionListResponseCouponAmountsOffCurrency.Chf => "chf",
                SubscriptionListResponseCouponAmountsOffCurrency.Cny => "cny",
                SubscriptionListResponseCouponAmountsOffCurrency.Czk => "czk",
                SubscriptionListResponseCouponAmountsOffCurrency.Dkk => "dkk",
                SubscriptionListResponseCouponAmountsOffCurrency.Dop => "dop",
                SubscriptionListResponseCouponAmountsOffCurrency.Dzd => "dzd",
                SubscriptionListResponseCouponAmountsOffCurrency.Egp => "egp",
                SubscriptionListResponseCouponAmountsOffCurrency.Etb => "etb",
                SubscriptionListResponseCouponAmountsOffCurrency.Eur => "eur",
                SubscriptionListResponseCouponAmountsOffCurrency.Fjd => "fjd",
                SubscriptionListResponseCouponAmountsOffCurrency.Gbp => "gbp",
                SubscriptionListResponseCouponAmountsOffCurrency.Gel => "gel",
                SubscriptionListResponseCouponAmountsOffCurrency.Gip => "gip",
                SubscriptionListResponseCouponAmountsOffCurrency.Gmd => "gmd",
                SubscriptionListResponseCouponAmountsOffCurrency.Gyd => "gyd",
                SubscriptionListResponseCouponAmountsOffCurrency.Hkd => "hkd",
                SubscriptionListResponseCouponAmountsOffCurrency.Hrk => "hrk",
                SubscriptionListResponseCouponAmountsOffCurrency.Htg => "htg",
                SubscriptionListResponseCouponAmountsOffCurrency.Idr => "idr",
                SubscriptionListResponseCouponAmountsOffCurrency.Ils => "ils",
                SubscriptionListResponseCouponAmountsOffCurrency.Inr => "inr",
                SubscriptionListResponseCouponAmountsOffCurrency.Isk => "isk",
                SubscriptionListResponseCouponAmountsOffCurrency.Jmd => "jmd",
                SubscriptionListResponseCouponAmountsOffCurrency.Jpy => "jpy",
                SubscriptionListResponseCouponAmountsOffCurrency.Kes => "kes",
                SubscriptionListResponseCouponAmountsOffCurrency.Kgs => "kgs",
                SubscriptionListResponseCouponAmountsOffCurrency.Khr => "khr",
                SubscriptionListResponseCouponAmountsOffCurrency.Kmf => "kmf",
                SubscriptionListResponseCouponAmountsOffCurrency.Krw => "krw",
                SubscriptionListResponseCouponAmountsOffCurrency.Kyd => "kyd",
                SubscriptionListResponseCouponAmountsOffCurrency.Kzt => "kzt",
                SubscriptionListResponseCouponAmountsOffCurrency.Lbp => "lbp",
                SubscriptionListResponseCouponAmountsOffCurrency.Lkr => "lkr",
                SubscriptionListResponseCouponAmountsOffCurrency.Lrd => "lrd",
                SubscriptionListResponseCouponAmountsOffCurrency.Lsl => "lsl",
                SubscriptionListResponseCouponAmountsOffCurrency.Mad => "mad",
                SubscriptionListResponseCouponAmountsOffCurrency.Mdl => "mdl",
                SubscriptionListResponseCouponAmountsOffCurrency.Mga => "mga",
                SubscriptionListResponseCouponAmountsOffCurrency.Mkd => "mkd",
                SubscriptionListResponseCouponAmountsOffCurrency.Mmk => "mmk",
                SubscriptionListResponseCouponAmountsOffCurrency.Mnt => "mnt",
                SubscriptionListResponseCouponAmountsOffCurrency.Mop => "mop",
                SubscriptionListResponseCouponAmountsOffCurrency.Mro => "mro",
                SubscriptionListResponseCouponAmountsOffCurrency.Mvr => "mvr",
                SubscriptionListResponseCouponAmountsOffCurrency.Mwk => "mwk",
                SubscriptionListResponseCouponAmountsOffCurrency.Mxn => "mxn",
                SubscriptionListResponseCouponAmountsOffCurrency.Myr => "myr",
                SubscriptionListResponseCouponAmountsOffCurrency.Mzn => "mzn",
                SubscriptionListResponseCouponAmountsOffCurrency.Nad => "nad",
                SubscriptionListResponseCouponAmountsOffCurrency.Ngn => "ngn",
                SubscriptionListResponseCouponAmountsOffCurrency.Nok => "nok",
                SubscriptionListResponseCouponAmountsOffCurrency.Npr => "npr",
                SubscriptionListResponseCouponAmountsOffCurrency.Nzd => "nzd",
                SubscriptionListResponseCouponAmountsOffCurrency.Pgk => "pgk",
                SubscriptionListResponseCouponAmountsOffCurrency.Php => "php",
                SubscriptionListResponseCouponAmountsOffCurrency.Pkr => "pkr",
                SubscriptionListResponseCouponAmountsOffCurrency.Pln => "pln",
                SubscriptionListResponseCouponAmountsOffCurrency.Qar => "qar",
                SubscriptionListResponseCouponAmountsOffCurrency.Ron => "ron",
                SubscriptionListResponseCouponAmountsOffCurrency.Rsd => "rsd",
                SubscriptionListResponseCouponAmountsOffCurrency.Rub => "rub",
                SubscriptionListResponseCouponAmountsOffCurrency.Rwf => "rwf",
                SubscriptionListResponseCouponAmountsOffCurrency.Sar => "sar",
                SubscriptionListResponseCouponAmountsOffCurrency.Sbd => "sbd",
                SubscriptionListResponseCouponAmountsOffCurrency.Scr => "scr",
                SubscriptionListResponseCouponAmountsOffCurrency.Sek => "sek",
                SubscriptionListResponseCouponAmountsOffCurrency.Sgd => "sgd",
                SubscriptionListResponseCouponAmountsOffCurrency.Sle => "sle",
                SubscriptionListResponseCouponAmountsOffCurrency.Sll => "sll",
                SubscriptionListResponseCouponAmountsOffCurrency.Sos => "sos",
                SubscriptionListResponseCouponAmountsOffCurrency.Szl => "szl",
                SubscriptionListResponseCouponAmountsOffCurrency.Thb => "thb",
                SubscriptionListResponseCouponAmountsOffCurrency.Tjs => "tjs",
                SubscriptionListResponseCouponAmountsOffCurrency.Top => "top",
                SubscriptionListResponseCouponAmountsOffCurrency.Try => "try",
                SubscriptionListResponseCouponAmountsOffCurrency.Ttd => "ttd",
                SubscriptionListResponseCouponAmountsOffCurrency.Tzs => "tzs",
                SubscriptionListResponseCouponAmountsOffCurrency.Uah => "uah",
                SubscriptionListResponseCouponAmountsOffCurrency.Uzs => "uzs",
                SubscriptionListResponseCouponAmountsOffCurrency.Vnd => "vnd",
                SubscriptionListResponseCouponAmountsOffCurrency.Vuv => "vuv",
                SubscriptionListResponseCouponAmountsOffCurrency.Wst => "wst",
                SubscriptionListResponseCouponAmountsOffCurrency.Xaf => "xaf",
                SubscriptionListResponseCouponAmountsOffCurrency.Xcd => "xcd",
                SubscriptionListResponseCouponAmountsOffCurrency.Yer => "yer",
                SubscriptionListResponseCouponAmountsOffCurrency.Zar => "zar",
                SubscriptionListResponseCouponAmountsOffCurrency.Zmw => "zmw",
                SubscriptionListResponseCouponAmountsOffCurrency.Clp => "clp",
                SubscriptionListResponseCouponAmountsOffCurrency.Djf => "djf",
                SubscriptionListResponseCouponAmountsOffCurrency.Gnf => "gnf",
                SubscriptionListResponseCouponAmountsOffCurrency.Ugx => "ugx",
                SubscriptionListResponseCouponAmountsOffCurrency.Pyg => "pyg",
                SubscriptionListResponseCouponAmountsOffCurrency.Xof => "xof",
                SubscriptionListResponseCouponAmountsOffCurrency.Xpf => "xpf",
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
[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionListResponseFutureUpdate,
        SubscriptionListResponseFutureUpdateFromRaw
    >)
)]
public sealed record class SubscriptionListResponseFutureUpdate : JsonModel
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
    public required ApiEnum<
        string,
        SubscriptionListResponseFutureUpdateScheduleStatus
    > ScheduleStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, SubscriptionListResponseFutureUpdateScheduleStatus>
            >("scheduleStatus");
        }
        init { this._rawData.Set("scheduleStatus", value); }
    }

    /// <summary>
    /// Type of scheduled change
    /// </summary>
    public required ApiEnum<
        string,
        SubscriptionListResponseFutureUpdateSubscriptionScheduleType
    > SubscriptionScheduleType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, SubscriptionListResponseFutureUpdateSubscriptionScheduleType>
            >("subscriptionScheduleType");
        }
        init { this._rawData.Set("subscriptionScheduleType", value); }
    }

    /// <summary>
    /// Target package for the update
    /// </summary>
    public SubscriptionListResponseFutureUpdateTargetPackage? TargetPackage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SubscriptionListResponseFutureUpdateTargetPackage>(
                "targetPackage"
            );
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

    public SubscriptionListResponseFutureUpdate() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionListResponseFutureUpdate(
        SubscriptionListResponseFutureUpdate subscriptionListResponseFutureUpdate
    )
        : base(subscriptionListResponseFutureUpdate) { }
#pragma warning restore CS8618

    public SubscriptionListResponseFutureUpdate(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionListResponseFutureUpdate(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionListResponseFutureUpdateFromRaw.FromRawUnchecked"/>
    public static SubscriptionListResponseFutureUpdate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionListResponseFutureUpdateFromRaw
    : IFromRawJson<SubscriptionListResponseFutureUpdate>
{
    /// <inheritdoc/>
    public SubscriptionListResponseFutureUpdate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionListResponseFutureUpdate.FromRawUnchecked(rawData);
}

/// <summary>
/// Status of the scheduled update
/// </summary>
[JsonConverter(typeof(SubscriptionListResponseFutureUpdateScheduleStatusConverter))]
public enum SubscriptionListResponseFutureUpdateScheduleStatus
{
    PendingPayment,
    Scheduled,
    Canceled,
    Done,
    Failed,
}

sealed class SubscriptionListResponseFutureUpdateScheduleStatusConverter
    : JsonConverter<SubscriptionListResponseFutureUpdateScheduleStatus>
{
    public override SubscriptionListResponseFutureUpdateScheduleStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PENDING_PAYMENT" => SubscriptionListResponseFutureUpdateScheduleStatus.PendingPayment,
            "SCHEDULED" => SubscriptionListResponseFutureUpdateScheduleStatus.Scheduled,
            "CANCELED" => SubscriptionListResponseFutureUpdateScheduleStatus.Canceled,
            "DONE" => SubscriptionListResponseFutureUpdateScheduleStatus.Done,
            "FAILED" => SubscriptionListResponseFutureUpdateScheduleStatus.Failed,
            _ => (SubscriptionListResponseFutureUpdateScheduleStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionListResponseFutureUpdateScheduleStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionListResponseFutureUpdateScheduleStatus.PendingPayment =>
                    "PENDING_PAYMENT",
                SubscriptionListResponseFutureUpdateScheduleStatus.Scheduled => "SCHEDULED",
                SubscriptionListResponseFutureUpdateScheduleStatus.Canceled => "CANCELED",
                SubscriptionListResponseFutureUpdateScheduleStatus.Done => "DONE",
                SubscriptionListResponseFutureUpdateScheduleStatus.Failed => "FAILED",
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
[JsonConverter(typeof(SubscriptionListResponseFutureUpdateSubscriptionScheduleTypeConverter))]
public enum SubscriptionListResponseFutureUpdateSubscriptionScheduleType
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

sealed class SubscriptionListResponseFutureUpdateSubscriptionScheduleTypeConverter
    : JsonConverter<SubscriptionListResponseFutureUpdateSubscriptionScheduleType>
{
    public override SubscriptionListResponseFutureUpdateSubscriptionScheduleType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "DOWNGRADE" => SubscriptionListResponseFutureUpdateSubscriptionScheduleType.Downgrade,
            "PLAN" => SubscriptionListResponseFutureUpdateSubscriptionScheduleType.Plan,
            "BILLING_PERIOD" =>
                SubscriptionListResponseFutureUpdateSubscriptionScheduleType.BillingPeriod,
            "UNIT_AMOUNT" =>
                SubscriptionListResponseFutureUpdateSubscriptionScheduleType.UnitAmount,
            "RECURRING_CREDITS" =>
                SubscriptionListResponseFutureUpdateSubscriptionScheduleType.RecurringCredits,
            "PRICE_OVERRIDE" =>
                SubscriptionListResponseFutureUpdateSubscriptionScheduleType.PriceOverride,
            "ADDON" => SubscriptionListResponseFutureUpdateSubscriptionScheduleType.Addon,
            "COUPON" => SubscriptionListResponseFutureUpdateSubscriptionScheduleType.Coupon,
            "MIGRATE_TO_LATEST" =>
                SubscriptionListResponseFutureUpdateSubscriptionScheduleType.MigrateToLatest,
            "ADDITIONAL_META_DATA" =>
                SubscriptionListResponseFutureUpdateSubscriptionScheduleType.AdditionalMetaData,
            "BILLING_INFO_METADATA" =>
                SubscriptionListResponseFutureUpdateSubscriptionScheduleType.BillingInfoMetadata,
            _ => (SubscriptionListResponseFutureUpdateSubscriptionScheduleType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionListResponseFutureUpdateSubscriptionScheduleType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionListResponseFutureUpdateSubscriptionScheduleType.Downgrade =>
                    "DOWNGRADE",
                SubscriptionListResponseFutureUpdateSubscriptionScheduleType.Plan => "PLAN",
                SubscriptionListResponseFutureUpdateSubscriptionScheduleType.BillingPeriod =>
                    "BILLING_PERIOD",
                SubscriptionListResponseFutureUpdateSubscriptionScheduleType.UnitAmount =>
                    "UNIT_AMOUNT",
                SubscriptionListResponseFutureUpdateSubscriptionScheduleType.RecurringCredits =>
                    "RECURRING_CREDITS",
                SubscriptionListResponseFutureUpdateSubscriptionScheduleType.PriceOverride =>
                    "PRICE_OVERRIDE",
                SubscriptionListResponseFutureUpdateSubscriptionScheduleType.Addon => "ADDON",
                SubscriptionListResponseFutureUpdateSubscriptionScheduleType.Coupon => "COUPON",
                SubscriptionListResponseFutureUpdateSubscriptionScheduleType.MigrateToLatest =>
                    "MIGRATE_TO_LATEST",
                SubscriptionListResponseFutureUpdateSubscriptionScheduleType.AdditionalMetaData =>
                    "ADDITIONAL_META_DATA",
                SubscriptionListResponseFutureUpdateSubscriptionScheduleType.BillingInfoMetadata =>
                    "BILLING_INFO_METADATA",
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
[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionListResponseFutureUpdateTargetPackage,
        SubscriptionListResponseFutureUpdateTargetPackageFromRaw
    >)
)]
public sealed record class SubscriptionListResponseFutureUpdateTargetPackage : JsonModel
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

    public SubscriptionListResponseFutureUpdateTargetPackage() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionListResponseFutureUpdateTargetPackage(
        SubscriptionListResponseFutureUpdateTargetPackage subscriptionListResponseFutureUpdateTargetPackage
    )
        : base(subscriptionListResponseFutureUpdateTargetPackage) { }
#pragma warning restore CS8618

    public SubscriptionListResponseFutureUpdateTargetPackage(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionListResponseFutureUpdateTargetPackage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionListResponseFutureUpdateTargetPackageFromRaw.FromRawUnchecked"/>
    public static SubscriptionListResponseFutureUpdateTargetPackage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SubscriptionListResponseFutureUpdateTargetPackage(string id)
        : this()
    {
        this.ID = id;
    }
}

class SubscriptionListResponseFutureUpdateTargetPackageFromRaw
    : IFromRawJson<SubscriptionListResponseFutureUpdateTargetPackage>
{
    /// <inheritdoc/>
    public SubscriptionListResponseFutureUpdateTargetPackage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionListResponseFutureUpdateTargetPackage.FromRawUnchecked(rawData);
}

/// <summary>
/// Latest invoice for the subscription
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionListResponseLatestInvoice,
        SubscriptionListResponseLatestInvoiceFromRaw
    >)
)]
public sealed record class SubscriptionListResponseLatestInvoice : JsonModel
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
    public required ApiEnum<string, SubscriptionListResponseLatestInvoiceStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, SubscriptionListResponseLatestInvoiceStatus>
            >("status");
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
    public ApiEnum<string, SubscriptionListResponseLatestInvoiceBillingReason>? BillingReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, SubscriptionListResponseLatestInvoiceBillingReason>
            >("billingReason");
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

    public SubscriptionListResponseLatestInvoice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionListResponseLatestInvoice(
        SubscriptionListResponseLatestInvoice subscriptionListResponseLatestInvoice
    )
        : base(subscriptionListResponseLatestInvoice) { }
#pragma warning restore CS8618

    public SubscriptionListResponseLatestInvoice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionListResponseLatestInvoice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionListResponseLatestInvoiceFromRaw.FromRawUnchecked"/>
    public static SubscriptionListResponseLatestInvoice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionListResponseLatestInvoiceFromRaw
    : IFromRawJson<SubscriptionListResponseLatestInvoice>
{
    /// <inheritdoc/>
    public SubscriptionListResponseLatestInvoice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionListResponseLatestInvoice.FromRawUnchecked(rawData);
}

/// <summary>
/// Invoice status
/// </summary>
[JsonConverter(typeof(SubscriptionListResponseLatestInvoiceStatusConverter))]
public enum SubscriptionListResponseLatestInvoiceStatus
{
    Open,
    Canceled,
    Paid,
}

sealed class SubscriptionListResponseLatestInvoiceStatusConverter
    : JsonConverter<SubscriptionListResponseLatestInvoiceStatus>
{
    public override SubscriptionListResponseLatestInvoiceStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "OPEN" => SubscriptionListResponseLatestInvoiceStatus.Open,
            "CANCELED" => SubscriptionListResponseLatestInvoiceStatus.Canceled,
            "PAID" => SubscriptionListResponseLatestInvoiceStatus.Paid,
            _ => (SubscriptionListResponseLatestInvoiceStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionListResponseLatestInvoiceStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionListResponseLatestInvoiceStatus.Open => "OPEN",
                SubscriptionListResponseLatestInvoiceStatus.Canceled => "CANCELED",
                SubscriptionListResponseLatestInvoiceStatus.Paid => "PAID",
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
[JsonConverter(typeof(SubscriptionListResponseLatestInvoiceBillingReasonConverter))]
public enum SubscriptionListResponseLatestInvoiceBillingReason
{
    BillingCycle,
    SubscriptionCreation,
    SubscriptionUpdate,
    Manual,
    MinimumInvoiceAmountExceeded,
    Other,
}

sealed class SubscriptionListResponseLatestInvoiceBillingReasonConverter
    : JsonConverter<SubscriptionListResponseLatestInvoiceBillingReason>
{
    public override SubscriptionListResponseLatestInvoiceBillingReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "BILLING_CYCLE" => SubscriptionListResponseLatestInvoiceBillingReason.BillingCycle,
            "SUBSCRIPTION_CREATION" =>
                SubscriptionListResponseLatestInvoiceBillingReason.SubscriptionCreation,
            "SUBSCRIPTION_UPDATE" =>
                SubscriptionListResponseLatestInvoiceBillingReason.SubscriptionUpdate,
            "MANUAL" => SubscriptionListResponseLatestInvoiceBillingReason.Manual,
            "MINIMUM_INVOICE_AMOUNT_EXCEEDED" =>
                SubscriptionListResponseLatestInvoiceBillingReason.MinimumInvoiceAmountExceeded,
            "OTHER" => SubscriptionListResponseLatestInvoiceBillingReason.Other,
            _ => (SubscriptionListResponseLatestInvoiceBillingReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionListResponseLatestInvoiceBillingReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionListResponseLatestInvoiceBillingReason.BillingCycle => "BILLING_CYCLE",
                SubscriptionListResponseLatestInvoiceBillingReason.SubscriptionCreation =>
                    "SUBSCRIPTION_CREATION",
                SubscriptionListResponseLatestInvoiceBillingReason.SubscriptionUpdate =>
                    "SUBSCRIPTION_UPDATE",
                SubscriptionListResponseLatestInvoiceBillingReason.Manual => "MANUAL",
                SubscriptionListResponseLatestInvoiceBillingReason.MinimumInvoiceAmountExceeded =>
                    "MINIMUM_INVOICE_AMOUNT_EXCEEDED",
                SubscriptionListResponseLatestInvoiceBillingReason.Other => "OTHER",
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
[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionListResponseMinimumSpend,
        SubscriptionListResponseMinimumSpendFromRaw
    >)
)]
public sealed record class SubscriptionListResponseMinimumSpend : JsonModel
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
    public ApiEnum<string, SubscriptionListResponseMinimumSpendCurrency>? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, SubscriptionListResponseMinimumSpendCurrency>
            >("currency");
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

    public SubscriptionListResponseMinimumSpend() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionListResponseMinimumSpend(
        SubscriptionListResponseMinimumSpend subscriptionListResponseMinimumSpend
    )
        : base(subscriptionListResponseMinimumSpend) { }
#pragma warning restore CS8618

    public SubscriptionListResponseMinimumSpend(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionListResponseMinimumSpend(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionListResponseMinimumSpendFromRaw.FromRawUnchecked"/>
    public static SubscriptionListResponseMinimumSpend FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionListResponseMinimumSpendFromRaw
    : IFromRawJson<SubscriptionListResponseMinimumSpend>
{
    /// <inheritdoc/>
    public SubscriptionListResponseMinimumSpend FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionListResponseMinimumSpend.FromRawUnchecked(rawData);
}

/// <summary>
/// The price currency
/// </summary>
[JsonConverter(typeof(SubscriptionListResponseMinimumSpendCurrencyConverter))]
public enum SubscriptionListResponseMinimumSpendCurrency
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

sealed class SubscriptionListResponseMinimumSpendCurrencyConverter
    : JsonConverter<SubscriptionListResponseMinimumSpendCurrency>
{
    public override SubscriptionListResponseMinimumSpendCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => SubscriptionListResponseMinimumSpendCurrency.Usd,
            "aed" => SubscriptionListResponseMinimumSpendCurrency.Aed,
            "all" => SubscriptionListResponseMinimumSpendCurrency.All,
            "amd" => SubscriptionListResponseMinimumSpendCurrency.Amd,
            "ang" => SubscriptionListResponseMinimumSpendCurrency.Ang,
            "aud" => SubscriptionListResponseMinimumSpendCurrency.Aud,
            "awg" => SubscriptionListResponseMinimumSpendCurrency.Awg,
            "azn" => SubscriptionListResponseMinimumSpendCurrency.Azn,
            "bam" => SubscriptionListResponseMinimumSpendCurrency.Bam,
            "bbd" => SubscriptionListResponseMinimumSpendCurrency.Bbd,
            "bdt" => SubscriptionListResponseMinimumSpendCurrency.Bdt,
            "bgn" => SubscriptionListResponseMinimumSpendCurrency.Bgn,
            "bif" => SubscriptionListResponseMinimumSpendCurrency.Bif,
            "bmd" => SubscriptionListResponseMinimumSpendCurrency.Bmd,
            "bnd" => SubscriptionListResponseMinimumSpendCurrency.Bnd,
            "bsd" => SubscriptionListResponseMinimumSpendCurrency.Bsd,
            "bwp" => SubscriptionListResponseMinimumSpendCurrency.Bwp,
            "byn" => SubscriptionListResponseMinimumSpendCurrency.Byn,
            "bzd" => SubscriptionListResponseMinimumSpendCurrency.Bzd,
            "brl" => SubscriptionListResponseMinimumSpendCurrency.Brl,
            "cad" => SubscriptionListResponseMinimumSpendCurrency.Cad,
            "cdf" => SubscriptionListResponseMinimumSpendCurrency.Cdf,
            "chf" => SubscriptionListResponseMinimumSpendCurrency.Chf,
            "cny" => SubscriptionListResponseMinimumSpendCurrency.Cny,
            "czk" => SubscriptionListResponseMinimumSpendCurrency.Czk,
            "dkk" => SubscriptionListResponseMinimumSpendCurrency.Dkk,
            "dop" => SubscriptionListResponseMinimumSpendCurrency.Dop,
            "dzd" => SubscriptionListResponseMinimumSpendCurrency.Dzd,
            "egp" => SubscriptionListResponseMinimumSpendCurrency.Egp,
            "etb" => SubscriptionListResponseMinimumSpendCurrency.Etb,
            "eur" => SubscriptionListResponseMinimumSpendCurrency.Eur,
            "fjd" => SubscriptionListResponseMinimumSpendCurrency.Fjd,
            "gbp" => SubscriptionListResponseMinimumSpendCurrency.Gbp,
            "gel" => SubscriptionListResponseMinimumSpendCurrency.Gel,
            "gip" => SubscriptionListResponseMinimumSpendCurrency.Gip,
            "gmd" => SubscriptionListResponseMinimumSpendCurrency.Gmd,
            "gyd" => SubscriptionListResponseMinimumSpendCurrency.Gyd,
            "hkd" => SubscriptionListResponseMinimumSpendCurrency.Hkd,
            "hrk" => SubscriptionListResponseMinimumSpendCurrency.Hrk,
            "htg" => SubscriptionListResponseMinimumSpendCurrency.Htg,
            "idr" => SubscriptionListResponseMinimumSpendCurrency.Idr,
            "ils" => SubscriptionListResponseMinimumSpendCurrency.Ils,
            "inr" => SubscriptionListResponseMinimumSpendCurrency.Inr,
            "isk" => SubscriptionListResponseMinimumSpendCurrency.Isk,
            "jmd" => SubscriptionListResponseMinimumSpendCurrency.Jmd,
            "jpy" => SubscriptionListResponseMinimumSpendCurrency.Jpy,
            "kes" => SubscriptionListResponseMinimumSpendCurrency.Kes,
            "kgs" => SubscriptionListResponseMinimumSpendCurrency.Kgs,
            "khr" => SubscriptionListResponseMinimumSpendCurrency.Khr,
            "kmf" => SubscriptionListResponseMinimumSpendCurrency.Kmf,
            "krw" => SubscriptionListResponseMinimumSpendCurrency.Krw,
            "kyd" => SubscriptionListResponseMinimumSpendCurrency.Kyd,
            "kzt" => SubscriptionListResponseMinimumSpendCurrency.Kzt,
            "lbp" => SubscriptionListResponseMinimumSpendCurrency.Lbp,
            "lkr" => SubscriptionListResponseMinimumSpendCurrency.Lkr,
            "lrd" => SubscriptionListResponseMinimumSpendCurrency.Lrd,
            "lsl" => SubscriptionListResponseMinimumSpendCurrency.Lsl,
            "mad" => SubscriptionListResponseMinimumSpendCurrency.Mad,
            "mdl" => SubscriptionListResponseMinimumSpendCurrency.Mdl,
            "mga" => SubscriptionListResponseMinimumSpendCurrency.Mga,
            "mkd" => SubscriptionListResponseMinimumSpendCurrency.Mkd,
            "mmk" => SubscriptionListResponseMinimumSpendCurrency.Mmk,
            "mnt" => SubscriptionListResponseMinimumSpendCurrency.Mnt,
            "mop" => SubscriptionListResponseMinimumSpendCurrency.Mop,
            "mro" => SubscriptionListResponseMinimumSpendCurrency.Mro,
            "mvr" => SubscriptionListResponseMinimumSpendCurrency.Mvr,
            "mwk" => SubscriptionListResponseMinimumSpendCurrency.Mwk,
            "mxn" => SubscriptionListResponseMinimumSpendCurrency.Mxn,
            "myr" => SubscriptionListResponseMinimumSpendCurrency.Myr,
            "mzn" => SubscriptionListResponseMinimumSpendCurrency.Mzn,
            "nad" => SubscriptionListResponseMinimumSpendCurrency.Nad,
            "ngn" => SubscriptionListResponseMinimumSpendCurrency.Ngn,
            "nok" => SubscriptionListResponseMinimumSpendCurrency.Nok,
            "npr" => SubscriptionListResponseMinimumSpendCurrency.Npr,
            "nzd" => SubscriptionListResponseMinimumSpendCurrency.Nzd,
            "pgk" => SubscriptionListResponseMinimumSpendCurrency.Pgk,
            "php" => SubscriptionListResponseMinimumSpendCurrency.Php,
            "pkr" => SubscriptionListResponseMinimumSpendCurrency.Pkr,
            "pln" => SubscriptionListResponseMinimumSpendCurrency.Pln,
            "qar" => SubscriptionListResponseMinimumSpendCurrency.Qar,
            "ron" => SubscriptionListResponseMinimumSpendCurrency.Ron,
            "rsd" => SubscriptionListResponseMinimumSpendCurrency.Rsd,
            "rub" => SubscriptionListResponseMinimumSpendCurrency.Rub,
            "rwf" => SubscriptionListResponseMinimumSpendCurrency.Rwf,
            "sar" => SubscriptionListResponseMinimumSpendCurrency.Sar,
            "sbd" => SubscriptionListResponseMinimumSpendCurrency.Sbd,
            "scr" => SubscriptionListResponseMinimumSpendCurrency.Scr,
            "sek" => SubscriptionListResponseMinimumSpendCurrency.Sek,
            "sgd" => SubscriptionListResponseMinimumSpendCurrency.Sgd,
            "sle" => SubscriptionListResponseMinimumSpendCurrency.Sle,
            "sll" => SubscriptionListResponseMinimumSpendCurrency.Sll,
            "sos" => SubscriptionListResponseMinimumSpendCurrency.Sos,
            "szl" => SubscriptionListResponseMinimumSpendCurrency.Szl,
            "thb" => SubscriptionListResponseMinimumSpendCurrency.Thb,
            "tjs" => SubscriptionListResponseMinimumSpendCurrency.Tjs,
            "top" => SubscriptionListResponseMinimumSpendCurrency.Top,
            "try" => SubscriptionListResponseMinimumSpendCurrency.Try,
            "ttd" => SubscriptionListResponseMinimumSpendCurrency.Ttd,
            "tzs" => SubscriptionListResponseMinimumSpendCurrency.Tzs,
            "uah" => SubscriptionListResponseMinimumSpendCurrency.Uah,
            "uzs" => SubscriptionListResponseMinimumSpendCurrency.Uzs,
            "vnd" => SubscriptionListResponseMinimumSpendCurrency.Vnd,
            "vuv" => SubscriptionListResponseMinimumSpendCurrency.Vuv,
            "wst" => SubscriptionListResponseMinimumSpendCurrency.Wst,
            "xaf" => SubscriptionListResponseMinimumSpendCurrency.Xaf,
            "xcd" => SubscriptionListResponseMinimumSpendCurrency.Xcd,
            "yer" => SubscriptionListResponseMinimumSpendCurrency.Yer,
            "zar" => SubscriptionListResponseMinimumSpendCurrency.Zar,
            "zmw" => SubscriptionListResponseMinimumSpendCurrency.Zmw,
            "clp" => SubscriptionListResponseMinimumSpendCurrency.Clp,
            "djf" => SubscriptionListResponseMinimumSpendCurrency.Djf,
            "gnf" => SubscriptionListResponseMinimumSpendCurrency.Gnf,
            "ugx" => SubscriptionListResponseMinimumSpendCurrency.Ugx,
            "pyg" => SubscriptionListResponseMinimumSpendCurrency.Pyg,
            "xof" => SubscriptionListResponseMinimumSpendCurrency.Xof,
            "xpf" => SubscriptionListResponseMinimumSpendCurrency.Xpf,
            _ => (SubscriptionListResponseMinimumSpendCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionListResponseMinimumSpendCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionListResponseMinimumSpendCurrency.Usd => "usd",
                SubscriptionListResponseMinimumSpendCurrency.Aed => "aed",
                SubscriptionListResponseMinimumSpendCurrency.All => "all",
                SubscriptionListResponseMinimumSpendCurrency.Amd => "amd",
                SubscriptionListResponseMinimumSpendCurrency.Ang => "ang",
                SubscriptionListResponseMinimumSpendCurrency.Aud => "aud",
                SubscriptionListResponseMinimumSpendCurrency.Awg => "awg",
                SubscriptionListResponseMinimumSpendCurrency.Azn => "azn",
                SubscriptionListResponseMinimumSpendCurrency.Bam => "bam",
                SubscriptionListResponseMinimumSpendCurrency.Bbd => "bbd",
                SubscriptionListResponseMinimumSpendCurrency.Bdt => "bdt",
                SubscriptionListResponseMinimumSpendCurrency.Bgn => "bgn",
                SubscriptionListResponseMinimumSpendCurrency.Bif => "bif",
                SubscriptionListResponseMinimumSpendCurrency.Bmd => "bmd",
                SubscriptionListResponseMinimumSpendCurrency.Bnd => "bnd",
                SubscriptionListResponseMinimumSpendCurrency.Bsd => "bsd",
                SubscriptionListResponseMinimumSpendCurrency.Bwp => "bwp",
                SubscriptionListResponseMinimumSpendCurrency.Byn => "byn",
                SubscriptionListResponseMinimumSpendCurrency.Bzd => "bzd",
                SubscriptionListResponseMinimumSpendCurrency.Brl => "brl",
                SubscriptionListResponseMinimumSpendCurrency.Cad => "cad",
                SubscriptionListResponseMinimumSpendCurrency.Cdf => "cdf",
                SubscriptionListResponseMinimumSpendCurrency.Chf => "chf",
                SubscriptionListResponseMinimumSpendCurrency.Cny => "cny",
                SubscriptionListResponseMinimumSpendCurrency.Czk => "czk",
                SubscriptionListResponseMinimumSpendCurrency.Dkk => "dkk",
                SubscriptionListResponseMinimumSpendCurrency.Dop => "dop",
                SubscriptionListResponseMinimumSpendCurrency.Dzd => "dzd",
                SubscriptionListResponseMinimumSpendCurrency.Egp => "egp",
                SubscriptionListResponseMinimumSpendCurrency.Etb => "etb",
                SubscriptionListResponseMinimumSpendCurrency.Eur => "eur",
                SubscriptionListResponseMinimumSpendCurrency.Fjd => "fjd",
                SubscriptionListResponseMinimumSpendCurrency.Gbp => "gbp",
                SubscriptionListResponseMinimumSpendCurrency.Gel => "gel",
                SubscriptionListResponseMinimumSpendCurrency.Gip => "gip",
                SubscriptionListResponseMinimumSpendCurrency.Gmd => "gmd",
                SubscriptionListResponseMinimumSpendCurrency.Gyd => "gyd",
                SubscriptionListResponseMinimumSpendCurrency.Hkd => "hkd",
                SubscriptionListResponseMinimumSpendCurrency.Hrk => "hrk",
                SubscriptionListResponseMinimumSpendCurrency.Htg => "htg",
                SubscriptionListResponseMinimumSpendCurrency.Idr => "idr",
                SubscriptionListResponseMinimumSpendCurrency.Ils => "ils",
                SubscriptionListResponseMinimumSpendCurrency.Inr => "inr",
                SubscriptionListResponseMinimumSpendCurrency.Isk => "isk",
                SubscriptionListResponseMinimumSpendCurrency.Jmd => "jmd",
                SubscriptionListResponseMinimumSpendCurrency.Jpy => "jpy",
                SubscriptionListResponseMinimumSpendCurrency.Kes => "kes",
                SubscriptionListResponseMinimumSpendCurrency.Kgs => "kgs",
                SubscriptionListResponseMinimumSpendCurrency.Khr => "khr",
                SubscriptionListResponseMinimumSpendCurrency.Kmf => "kmf",
                SubscriptionListResponseMinimumSpendCurrency.Krw => "krw",
                SubscriptionListResponseMinimumSpendCurrency.Kyd => "kyd",
                SubscriptionListResponseMinimumSpendCurrency.Kzt => "kzt",
                SubscriptionListResponseMinimumSpendCurrency.Lbp => "lbp",
                SubscriptionListResponseMinimumSpendCurrency.Lkr => "lkr",
                SubscriptionListResponseMinimumSpendCurrency.Lrd => "lrd",
                SubscriptionListResponseMinimumSpendCurrency.Lsl => "lsl",
                SubscriptionListResponseMinimumSpendCurrency.Mad => "mad",
                SubscriptionListResponseMinimumSpendCurrency.Mdl => "mdl",
                SubscriptionListResponseMinimumSpendCurrency.Mga => "mga",
                SubscriptionListResponseMinimumSpendCurrency.Mkd => "mkd",
                SubscriptionListResponseMinimumSpendCurrency.Mmk => "mmk",
                SubscriptionListResponseMinimumSpendCurrency.Mnt => "mnt",
                SubscriptionListResponseMinimumSpendCurrency.Mop => "mop",
                SubscriptionListResponseMinimumSpendCurrency.Mro => "mro",
                SubscriptionListResponseMinimumSpendCurrency.Mvr => "mvr",
                SubscriptionListResponseMinimumSpendCurrency.Mwk => "mwk",
                SubscriptionListResponseMinimumSpendCurrency.Mxn => "mxn",
                SubscriptionListResponseMinimumSpendCurrency.Myr => "myr",
                SubscriptionListResponseMinimumSpendCurrency.Mzn => "mzn",
                SubscriptionListResponseMinimumSpendCurrency.Nad => "nad",
                SubscriptionListResponseMinimumSpendCurrency.Ngn => "ngn",
                SubscriptionListResponseMinimumSpendCurrency.Nok => "nok",
                SubscriptionListResponseMinimumSpendCurrency.Npr => "npr",
                SubscriptionListResponseMinimumSpendCurrency.Nzd => "nzd",
                SubscriptionListResponseMinimumSpendCurrency.Pgk => "pgk",
                SubscriptionListResponseMinimumSpendCurrency.Php => "php",
                SubscriptionListResponseMinimumSpendCurrency.Pkr => "pkr",
                SubscriptionListResponseMinimumSpendCurrency.Pln => "pln",
                SubscriptionListResponseMinimumSpendCurrency.Qar => "qar",
                SubscriptionListResponseMinimumSpendCurrency.Ron => "ron",
                SubscriptionListResponseMinimumSpendCurrency.Rsd => "rsd",
                SubscriptionListResponseMinimumSpendCurrency.Rub => "rub",
                SubscriptionListResponseMinimumSpendCurrency.Rwf => "rwf",
                SubscriptionListResponseMinimumSpendCurrency.Sar => "sar",
                SubscriptionListResponseMinimumSpendCurrency.Sbd => "sbd",
                SubscriptionListResponseMinimumSpendCurrency.Scr => "scr",
                SubscriptionListResponseMinimumSpendCurrency.Sek => "sek",
                SubscriptionListResponseMinimumSpendCurrency.Sgd => "sgd",
                SubscriptionListResponseMinimumSpendCurrency.Sle => "sle",
                SubscriptionListResponseMinimumSpendCurrency.Sll => "sll",
                SubscriptionListResponseMinimumSpendCurrency.Sos => "sos",
                SubscriptionListResponseMinimumSpendCurrency.Szl => "szl",
                SubscriptionListResponseMinimumSpendCurrency.Thb => "thb",
                SubscriptionListResponseMinimumSpendCurrency.Tjs => "tjs",
                SubscriptionListResponseMinimumSpendCurrency.Top => "top",
                SubscriptionListResponseMinimumSpendCurrency.Try => "try",
                SubscriptionListResponseMinimumSpendCurrency.Ttd => "ttd",
                SubscriptionListResponseMinimumSpendCurrency.Tzs => "tzs",
                SubscriptionListResponseMinimumSpendCurrency.Uah => "uah",
                SubscriptionListResponseMinimumSpendCurrency.Uzs => "uzs",
                SubscriptionListResponseMinimumSpendCurrency.Vnd => "vnd",
                SubscriptionListResponseMinimumSpendCurrency.Vuv => "vuv",
                SubscriptionListResponseMinimumSpendCurrency.Wst => "wst",
                SubscriptionListResponseMinimumSpendCurrency.Xaf => "xaf",
                SubscriptionListResponseMinimumSpendCurrency.Xcd => "xcd",
                SubscriptionListResponseMinimumSpendCurrency.Yer => "yer",
                SubscriptionListResponseMinimumSpendCurrency.Zar => "zar",
                SubscriptionListResponseMinimumSpendCurrency.Zmw => "zmw",
                SubscriptionListResponseMinimumSpendCurrency.Clp => "clp",
                SubscriptionListResponseMinimumSpendCurrency.Djf => "djf",
                SubscriptionListResponseMinimumSpendCurrency.Gnf => "gnf",
                SubscriptionListResponseMinimumSpendCurrency.Ugx => "ugx",
                SubscriptionListResponseMinimumSpendCurrency.Pyg => "pyg",
                SubscriptionListResponseMinimumSpendCurrency.Xof => "xof",
                SubscriptionListResponseMinimumSpendCurrency.Xpf => "xpf",
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
[JsonConverter(typeof(SubscriptionListResponsePaymentCollectionMethodConverter))]
public enum SubscriptionListResponsePaymentCollectionMethod
{
    Charge,
    Invoice,
    None,
}

sealed class SubscriptionListResponsePaymentCollectionMethodConverter
    : JsonConverter<SubscriptionListResponsePaymentCollectionMethod>
{
    public override SubscriptionListResponsePaymentCollectionMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "CHARGE" => SubscriptionListResponsePaymentCollectionMethod.Charge,
            "INVOICE" => SubscriptionListResponsePaymentCollectionMethod.Invoice,
            "NONE" => SubscriptionListResponsePaymentCollectionMethod.None,
            _ => (SubscriptionListResponsePaymentCollectionMethod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionListResponsePaymentCollectionMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionListResponsePaymentCollectionMethod.Charge => "CHARGE",
                SubscriptionListResponsePaymentCollectionMethod.Invoice => "INVOICE",
                SubscriptionListResponsePaymentCollectionMethod.None => "NONE",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<SubscriptionListResponsePrice, SubscriptionListResponsePriceFromRaw>)
)]
public sealed record class SubscriptionListResponsePrice : JsonModel
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
    public ApiEnum<string, SubscriptionListResponsePriceCurrency>? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, SubscriptionListResponsePriceCurrency>
            >("currency");
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
    public IReadOnlyList<SubscriptionListResponsePriceTier>? Tiers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<SubscriptionListResponsePriceTier>
            >("tiers");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<SubscriptionListResponsePriceTier>?>(
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

    public SubscriptionListResponsePrice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionListResponsePrice(
        SubscriptionListResponsePrice subscriptionListResponsePrice
    )
        : base(subscriptionListResponsePrice) { }
#pragma warning restore CS8618

    public SubscriptionListResponsePrice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionListResponsePrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionListResponsePriceFromRaw.FromRawUnchecked"/>
    public static SubscriptionListResponsePrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionListResponsePriceFromRaw : IFromRawJson<SubscriptionListResponsePrice>
{
    /// <inheritdoc/>
    public SubscriptionListResponsePrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionListResponsePrice.FromRawUnchecked(rawData);
}

/// <summary>
/// The price currency
/// </summary>
[JsonConverter(typeof(SubscriptionListResponsePriceCurrencyConverter))]
public enum SubscriptionListResponsePriceCurrency
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

sealed class SubscriptionListResponsePriceCurrencyConverter
    : JsonConverter<SubscriptionListResponsePriceCurrency>
{
    public override SubscriptionListResponsePriceCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => SubscriptionListResponsePriceCurrency.Usd,
            "aed" => SubscriptionListResponsePriceCurrency.Aed,
            "all" => SubscriptionListResponsePriceCurrency.All,
            "amd" => SubscriptionListResponsePriceCurrency.Amd,
            "ang" => SubscriptionListResponsePriceCurrency.Ang,
            "aud" => SubscriptionListResponsePriceCurrency.Aud,
            "awg" => SubscriptionListResponsePriceCurrency.Awg,
            "azn" => SubscriptionListResponsePriceCurrency.Azn,
            "bam" => SubscriptionListResponsePriceCurrency.Bam,
            "bbd" => SubscriptionListResponsePriceCurrency.Bbd,
            "bdt" => SubscriptionListResponsePriceCurrency.Bdt,
            "bgn" => SubscriptionListResponsePriceCurrency.Bgn,
            "bif" => SubscriptionListResponsePriceCurrency.Bif,
            "bmd" => SubscriptionListResponsePriceCurrency.Bmd,
            "bnd" => SubscriptionListResponsePriceCurrency.Bnd,
            "bsd" => SubscriptionListResponsePriceCurrency.Bsd,
            "bwp" => SubscriptionListResponsePriceCurrency.Bwp,
            "byn" => SubscriptionListResponsePriceCurrency.Byn,
            "bzd" => SubscriptionListResponsePriceCurrency.Bzd,
            "brl" => SubscriptionListResponsePriceCurrency.Brl,
            "cad" => SubscriptionListResponsePriceCurrency.Cad,
            "cdf" => SubscriptionListResponsePriceCurrency.Cdf,
            "chf" => SubscriptionListResponsePriceCurrency.Chf,
            "cny" => SubscriptionListResponsePriceCurrency.Cny,
            "czk" => SubscriptionListResponsePriceCurrency.Czk,
            "dkk" => SubscriptionListResponsePriceCurrency.Dkk,
            "dop" => SubscriptionListResponsePriceCurrency.Dop,
            "dzd" => SubscriptionListResponsePriceCurrency.Dzd,
            "egp" => SubscriptionListResponsePriceCurrency.Egp,
            "etb" => SubscriptionListResponsePriceCurrency.Etb,
            "eur" => SubscriptionListResponsePriceCurrency.Eur,
            "fjd" => SubscriptionListResponsePriceCurrency.Fjd,
            "gbp" => SubscriptionListResponsePriceCurrency.Gbp,
            "gel" => SubscriptionListResponsePriceCurrency.Gel,
            "gip" => SubscriptionListResponsePriceCurrency.Gip,
            "gmd" => SubscriptionListResponsePriceCurrency.Gmd,
            "gyd" => SubscriptionListResponsePriceCurrency.Gyd,
            "hkd" => SubscriptionListResponsePriceCurrency.Hkd,
            "hrk" => SubscriptionListResponsePriceCurrency.Hrk,
            "htg" => SubscriptionListResponsePriceCurrency.Htg,
            "idr" => SubscriptionListResponsePriceCurrency.Idr,
            "ils" => SubscriptionListResponsePriceCurrency.Ils,
            "inr" => SubscriptionListResponsePriceCurrency.Inr,
            "isk" => SubscriptionListResponsePriceCurrency.Isk,
            "jmd" => SubscriptionListResponsePriceCurrency.Jmd,
            "jpy" => SubscriptionListResponsePriceCurrency.Jpy,
            "kes" => SubscriptionListResponsePriceCurrency.Kes,
            "kgs" => SubscriptionListResponsePriceCurrency.Kgs,
            "khr" => SubscriptionListResponsePriceCurrency.Khr,
            "kmf" => SubscriptionListResponsePriceCurrency.Kmf,
            "krw" => SubscriptionListResponsePriceCurrency.Krw,
            "kyd" => SubscriptionListResponsePriceCurrency.Kyd,
            "kzt" => SubscriptionListResponsePriceCurrency.Kzt,
            "lbp" => SubscriptionListResponsePriceCurrency.Lbp,
            "lkr" => SubscriptionListResponsePriceCurrency.Lkr,
            "lrd" => SubscriptionListResponsePriceCurrency.Lrd,
            "lsl" => SubscriptionListResponsePriceCurrency.Lsl,
            "mad" => SubscriptionListResponsePriceCurrency.Mad,
            "mdl" => SubscriptionListResponsePriceCurrency.Mdl,
            "mga" => SubscriptionListResponsePriceCurrency.Mga,
            "mkd" => SubscriptionListResponsePriceCurrency.Mkd,
            "mmk" => SubscriptionListResponsePriceCurrency.Mmk,
            "mnt" => SubscriptionListResponsePriceCurrency.Mnt,
            "mop" => SubscriptionListResponsePriceCurrency.Mop,
            "mro" => SubscriptionListResponsePriceCurrency.Mro,
            "mvr" => SubscriptionListResponsePriceCurrency.Mvr,
            "mwk" => SubscriptionListResponsePriceCurrency.Mwk,
            "mxn" => SubscriptionListResponsePriceCurrency.Mxn,
            "myr" => SubscriptionListResponsePriceCurrency.Myr,
            "mzn" => SubscriptionListResponsePriceCurrency.Mzn,
            "nad" => SubscriptionListResponsePriceCurrency.Nad,
            "ngn" => SubscriptionListResponsePriceCurrency.Ngn,
            "nok" => SubscriptionListResponsePriceCurrency.Nok,
            "npr" => SubscriptionListResponsePriceCurrency.Npr,
            "nzd" => SubscriptionListResponsePriceCurrency.Nzd,
            "pgk" => SubscriptionListResponsePriceCurrency.Pgk,
            "php" => SubscriptionListResponsePriceCurrency.Php,
            "pkr" => SubscriptionListResponsePriceCurrency.Pkr,
            "pln" => SubscriptionListResponsePriceCurrency.Pln,
            "qar" => SubscriptionListResponsePriceCurrency.Qar,
            "ron" => SubscriptionListResponsePriceCurrency.Ron,
            "rsd" => SubscriptionListResponsePriceCurrency.Rsd,
            "rub" => SubscriptionListResponsePriceCurrency.Rub,
            "rwf" => SubscriptionListResponsePriceCurrency.Rwf,
            "sar" => SubscriptionListResponsePriceCurrency.Sar,
            "sbd" => SubscriptionListResponsePriceCurrency.Sbd,
            "scr" => SubscriptionListResponsePriceCurrency.Scr,
            "sek" => SubscriptionListResponsePriceCurrency.Sek,
            "sgd" => SubscriptionListResponsePriceCurrency.Sgd,
            "sle" => SubscriptionListResponsePriceCurrency.Sle,
            "sll" => SubscriptionListResponsePriceCurrency.Sll,
            "sos" => SubscriptionListResponsePriceCurrency.Sos,
            "szl" => SubscriptionListResponsePriceCurrency.Szl,
            "thb" => SubscriptionListResponsePriceCurrency.Thb,
            "tjs" => SubscriptionListResponsePriceCurrency.Tjs,
            "top" => SubscriptionListResponsePriceCurrency.Top,
            "try" => SubscriptionListResponsePriceCurrency.Try,
            "ttd" => SubscriptionListResponsePriceCurrency.Ttd,
            "tzs" => SubscriptionListResponsePriceCurrency.Tzs,
            "uah" => SubscriptionListResponsePriceCurrency.Uah,
            "uzs" => SubscriptionListResponsePriceCurrency.Uzs,
            "vnd" => SubscriptionListResponsePriceCurrency.Vnd,
            "vuv" => SubscriptionListResponsePriceCurrency.Vuv,
            "wst" => SubscriptionListResponsePriceCurrency.Wst,
            "xaf" => SubscriptionListResponsePriceCurrency.Xaf,
            "xcd" => SubscriptionListResponsePriceCurrency.Xcd,
            "yer" => SubscriptionListResponsePriceCurrency.Yer,
            "zar" => SubscriptionListResponsePriceCurrency.Zar,
            "zmw" => SubscriptionListResponsePriceCurrency.Zmw,
            "clp" => SubscriptionListResponsePriceCurrency.Clp,
            "djf" => SubscriptionListResponsePriceCurrency.Djf,
            "gnf" => SubscriptionListResponsePriceCurrency.Gnf,
            "ugx" => SubscriptionListResponsePriceCurrency.Ugx,
            "pyg" => SubscriptionListResponsePriceCurrency.Pyg,
            "xof" => SubscriptionListResponsePriceCurrency.Xof,
            "xpf" => SubscriptionListResponsePriceCurrency.Xpf,
            _ => (SubscriptionListResponsePriceCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionListResponsePriceCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionListResponsePriceCurrency.Usd => "usd",
                SubscriptionListResponsePriceCurrency.Aed => "aed",
                SubscriptionListResponsePriceCurrency.All => "all",
                SubscriptionListResponsePriceCurrency.Amd => "amd",
                SubscriptionListResponsePriceCurrency.Ang => "ang",
                SubscriptionListResponsePriceCurrency.Aud => "aud",
                SubscriptionListResponsePriceCurrency.Awg => "awg",
                SubscriptionListResponsePriceCurrency.Azn => "azn",
                SubscriptionListResponsePriceCurrency.Bam => "bam",
                SubscriptionListResponsePriceCurrency.Bbd => "bbd",
                SubscriptionListResponsePriceCurrency.Bdt => "bdt",
                SubscriptionListResponsePriceCurrency.Bgn => "bgn",
                SubscriptionListResponsePriceCurrency.Bif => "bif",
                SubscriptionListResponsePriceCurrency.Bmd => "bmd",
                SubscriptionListResponsePriceCurrency.Bnd => "bnd",
                SubscriptionListResponsePriceCurrency.Bsd => "bsd",
                SubscriptionListResponsePriceCurrency.Bwp => "bwp",
                SubscriptionListResponsePriceCurrency.Byn => "byn",
                SubscriptionListResponsePriceCurrency.Bzd => "bzd",
                SubscriptionListResponsePriceCurrency.Brl => "brl",
                SubscriptionListResponsePriceCurrency.Cad => "cad",
                SubscriptionListResponsePriceCurrency.Cdf => "cdf",
                SubscriptionListResponsePriceCurrency.Chf => "chf",
                SubscriptionListResponsePriceCurrency.Cny => "cny",
                SubscriptionListResponsePriceCurrency.Czk => "czk",
                SubscriptionListResponsePriceCurrency.Dkk => "dkk",
                SubscriptionListResponsePriceCurrency.Dop => "dop",
                SubscriptionListResponsePriceCurrency.Dzd => "dzd",
                SubscriptionListResponsePriceCurrency.Egp => "egp",
                SubscriptionListResponsePriceCurrency.Etb => "etb",
                SubscriptionListResponsePriceCurrency.Eur => "eur",
                SubscriptionListResponsePriceCurrency.Fjd => "fjd",
                SubscriptionListResponsePriceCurrency.Gbp => "gbp",
                SubscriptionListResponsePriceCurrency.Gel => "gel",
                SubscriptionListResponsePriceCurrency.Gip => "gip",
                SubscriptionListResponsePriceCurrency.Gmd => "gmd",
                SubscriptionListResponsePriceCurrency.Gyd => "gyd",
                SubscriptionListResponsePriceCurrency.Hkd => "hkd",
                SubscriptionListResponsePriceCurrency.Hrk => "hrk",
                SubscriptionListResponsePriceCurrency.Htg => "htg",
                SubscriptionListResponsePriceCurrency.Idr => "idr",
                SubscriptionListResponsePriceCurrency.Ils => "ils",
                SubscriptionListResponsePriceCurrency.Inr => "inr",
                SubscriptionListResponsePriceCurrency.Isk => "isk",
                SubscriptionListResponsePriceCurrency.Jmd => "jmd",
                SubscriptionListResponsePriceCurrency.Jpy => "jpy",
                SubscriptionListResponsePriceCurrency.Kes => "kes",
                SubscriptionListResponsePriceCurrency.Kgs => "kgs",
                SubscriptionListResponsePriceCurrency.Khr => "khr",
                SubscriptionListResponsePriceCurrency.Kmf => "kmf",
                SubscriptionListResponsePriceCurrency.Krw => "krw",
                SubscriptionListResponsePriceCurrency.Kyd => "kyd",
                SubscriptionListResponsePriceCurrency.Kzt => "kzt",
                SubscriptionListResponsePriceCurrency.Lbp => "lbp",
                SubscriptionListResponsePriceCurrency.Lkr => "lkr",
                SubscriptionListResponsePriceCurrency.Lrd => "lrd",
                SubscriptionListResponsePriceCurrency.Lsl => "lsl",
                SubscriptionListResponsePriceCurrency.Mad => "mad",
                SubscriptionListResponsePriceCurrency.Mdl => "mdl",
                SubscriptionListResponsePriceCurrency.Mga => "mga",
                SubscriptionListResponsePriceCurrency.Mkd => "mkd",
                SubscriptionListResponsePriceCurrency.Mmk => "mmk",
                SubscriptionListResponsePriceCurrency.Mnt => "mnt",
                SubscriptionListResponsePriceCurrency.Mop => "mop",
                SubscriptionListResponsePriceCurrency.Mro => "mro",
                SubscriptionListResponsePriceCurrency.Mvr => "mvr",
                SubscriptionListResponsePriceCurrency.Mwk => "mwk",
                SubscriptionListResponsePriceCurrency.Mxn => "mxn",
                SubscriptionListResponsePriceCurrency.Myr => "myr",
                SubscriptionListResponsePriceCurrency.Mzn => "mzn",
                SubscriptionListResponsePriceCurrency.Nad => "nad",
                SubscriptionListResponsePriceCurrency.Ngn => "ngn",
                SubscriptionListResponsePriceCurrency.Nok => "nok",
                SubscriptionListResponsePriceCurrency.Npr => "npr",
                SubscriptionListResponsePriceCurrency.Nzd => "nzd",
                SubscriptionListResponsePriceCurrency.Pgk => "pgk",
                SubscriptionListResponsePriceCurrency.Php => "php",
                SubscriptionListResponsePriceCurrency.Pkr => "pkr",
                SubscriptionListResponsePriceCurrency.Pln => "pln",
                SubscriptionListResponsePriceCurrency.Qar => "qar",
                SubscriptionListResponsePriceCurrency.Ron => "ron",
                SubscriptionListResponsePriceCurrency.Rsd => "rsd",
                SubscriptionListResponsePriceCurrency.Rub => "rub",
                SubscriptionListResponsePriceCurrency.Rwf => "rwf",
                SubscriptionListResponsePriceCurrency.Sar => "sar",
                SubscriptionListResponsePriceCurrency.Sbd => "sbd",
                SubscriptionListResponsePriceCurrency.Scr => "scr",
                SubscriptionListResponsePriceCurrency.Sek => "sek",
                SubscriptionListResponsePriceCurrency.Sgd => "sgd",
                SubscriptionListResponsePriceCurrency.Sle => "sle",
                SubscriptionListResponsePriceCurrency.Sll => "sll",
                SubscriptionListResponsePriceCurrency.Sos => "sos",
                SubscriptionListResponsePriceCurrency.Szl => "szl",
                SubscriptionListResponsePriceCurrency.Thb => "thb",
                SubscriptionListResponsePriceCurrency.Tjs => "tjs",
                SubscriptionListResponsePriceCurrency.Top => "top",
                SubscriptionListResponsePriceCurrency.Try => "try",
                SubscriptionListResponsePriceCurrency.Ttd => "ttd",
                SubscriptionListResponsePriceCurrency.Tzs => "tzs",
                SubscriptionListResponsePriceCurrency.Uah => "uah",
                SubscriptionListResponsePriceCurrency.Uzs => "uzs",
                SubscriptionListResponsePriceCurrency.Vnd => "vnd",
                SubscriptionListResponsePriceCurrency.Vuv => "vuv",
                SubscriptionListResponsePriceCurrency.Wst => "wst",
                SubscriptionListResponsePriceCurrency.Xaf => "xaf",
                SubscriptionListResponsePriceCurrency.Xcd => "xcd",
                SubscriptionListResponsePriceCurrency.Yer => "yer",
                SubscriptionListResponsePriceCurrency.Zar => "zar",
                SubscriptionListResponsePriceCurrency.Zmw => "zmw",
                SubscriptionListResponsePriceCurrency.Clp => "clp",
                SubscriptionListResponsePriceCurrency.Djf => "djf",
                SubscriptionListResponsePriceCurrency.Gnf => "gnf",
                SubscriptionListResponsePriceCurrency.Ugx => "ugx",
                SubscriptionListResponsePriceCurrency.Pyg => "pyg",
                SubscriptionListResponsePriceCurrency.Xof => "xof",
                SubscriptionListResponsePriceCurrency.Xpf => "xpf",
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
        SubscriptionListResponsePriceTier,
        SubscriptionListResponsePriceTierFromRaw
    >)
)]
public sealed record class SubscriptionListResponsePriceTier : JsonModel
{
    /// <summary>
    /// The flat fee price of the price tier
    /// </summary>
    public SubscriptionListResponsePriceTierFlatPrice? FlatPrice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SubscriptionListResponsePriceTierFlatPrice>(
                "flatPrice"
            );
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
    public SubscriptionListResponsePriceTierUnitPrice? UnitPrice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SubscriptionListResponsePriceTierUnitPrice>(
                "unitPrice"
            );
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

    public SubscriptionListResponsePriceTier() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionListResponsePriceTier(
        SubscriptionListResponsePriceTier subscriptionListResponsePriceTier
    )
        : base(subscriptionListResponsePriceTier) { }
#pragma warning restore CS8618

    public SubscriptionListResponsePriceTier(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionListResponsePriceTier(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionListResponsePriceTierFromRaw.FromRawUnchecked"/>
    public static SubscriptionListResponsePriceTier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionListResponsePriceTierFromRaw : IFromRawJson<SubscriptionListResponsePriceTier>
{
    /// <inheritdoc/>
    public SubscriptionListResponsePriceTier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionListResponsePriceTier.FromRawUnchecked(rawData);
}

/// <summary>
/// The flat fee price of the price tier
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionListResponsePriceTierFlatPrice,
        SubscriptionListResponsePriceTierFlatPriceFromRaw
    >)
)]
public sealed record class SubscriptionListResponsePriceTierFlatPrice : JsonModel
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
    public required ApiEnum<string, SubscriptionListResponsePriceTierFlatPriceCurrency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, SubscriptionListResponsePriceTierFlatPriceCurrency>
            >("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        this.Currency.Validate();
    }

    public SubscriptionListResponsePriceTierFlatPrice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionListResponsePriceTierFlatPrice(
        SubscriptionListResponsePriceTierFlatPrice subscriptionListResponsePriceTierFlatPrice
    )
        : base(subscriptionListResponsePriceTierFlatPrice) { }
#pragma warning restore CS8618

    public SubscriptionListResponsePriceTierFlatPrice(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionListResponsePriceTierFlatPrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionListResponsePriceTierFlatPriceFromRaw.FromRawUnchecked"/>
    public static SubscriptionListResponsePriceTierFlatPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionListResponsePriceTierFlatPriceFromRaw
    : IFromRawJson<SubscriptionListResponsePriceTierFlatPrice>
{
    /// <inheritdoc/>
    public SubscriptionListResponsePriceTierFlatPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionListResponsePriceTierFlatPrice.FromRawUnchecked(rawData);
}

/// <summary>
/// ISO 4217 currency code
/// </summary>
[JsonConverter(typeof(SubscriptionListResponsePriceTierFlatPriceCurrencyConverter))]
public enum SubscriptionListResponsePriceTierFlatPriceCurrency
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

sealed class SubscriptionListResponsePriceTierFlatPriceCurrencyConverter
    : JsonConverter<SubscriptionListResponsePriceTierFlatPriceCurrency>
{
    public override SubscriptionListResponsePriceTierFlatPriceCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => SubscriptionListResponsePriceTierFlatPriceCurrency.Usd,
            "aed" => SubscriptionListResponsePriceTierFlatPriceCurrency.Aed,
            "all" => SubscriptionListResponsePriceTierFlatPriceCurrency.All,
            "amd" => SubscriptionListResponsePriceTierFlatPriceCurrency.Amd,
            "ang" => SubscriptionListResponsePriceTierFlatPriceCurrency.Ang,
            "aud" => SubscriptionListResponsePriceTierFlatPriceCurrency.Aud,
            "awg" => SubscriptionListResponsePriceTierFlatPriceCurrency.Awg,
            "azn" => SubscriptionListResponsePriceTierFlatPriceCurrency.Azn,
            "bam" => SubscriptionListResponsePriceTierFlatPriceCurrency.Bam,
            "bbd" => SubscriptionListResponsePriceTierFlatPriceCurrency.Bbd,
            "bdt" => SubscriptionListResponsePriceTierFlatPriceCurrency.Bdt,
            "bgn" => SubscriptionListResponsePriceTierFlatPriceCurrency.Bgn,
            "bif" => SubscriptionListResponsePriceTierFlatPriceCurrency.Bif,
            "bmd" => SubscriptionListResponsePriceTierFlatPriceCurrency.Bmd,
            "bnd" => SubscriptionListResponsePriceTierFlatPriceCurrency.Bnd,
            "bsd" => SubscriptionListResponsePriceTierFlatPriceCurrency.Bsd,
            "bwp" => SubscriptionListResponsePriceTierFlatPriceCurrency.Bwp,
            "byn" => SubscriptionListResponsePriceTierFlatPriceCurrency.Byn,
            "bzd" => SubscriptionListResponsePriceTierFlatPriceCurrency.Bzd,
            "brl" => SubscriptionListResponsePriceTierFlatPriceCurrency.Brl,
            "cad" => SubscriptionListResponsePriceTierFlatPriceCurrency.Cad,
            "cdf" => SubscriptionListResponsePriceTierFlatPriceCurrency.Cdf,
            "chf" => SubscriptionListResponsePriceTierFlatPriceCurrency.Chf,
            "cny" => SubscriptionListResponsePriceTierFlatPriceCurrency.Cny,
            "czk" => SubscriptionListResponsePriceTierFlatPriceCurrency.Czk,
            "dkk" => SubscriptionListResponsePriceTierFlatPriceCurrency.Dkk,
            "dop" => SubscriptionListResponsePriceTierFlatPriceCurrency.Dop,
            "dzd" => SubscriptionListResponsePriceTierFlatPriceCurrency.Dzd,
            "egp" => SubscriptionListResponsePriceTierFlatPriceCurrency.Egp,
            "etb" => SubscriptionListResponsePriceTierFlatPriceCurrency.Etb,
            "eur" => SubscriptionListResponsePriceTierFlatPriceCurrency.Eur,
            "fjd" => SubscriptionListResponsePriceTierFlatPriceCurrency.Fjd,
            "gbp" => SubscriptionListResponsePriceTierFlatPriceCurrency.Gbp,
            "gel" => SubscriptionListResponsePriceTierFlatPriceCurrency.Gel,
            "gip" => SubscriptionListResponsePriceTierFlatPriceCurrency.Gip,
            "gmd" => SubscriptionListResponsePriceTierFlatPriceCurrency.Gmd,
            "gyd" => SubscriptionListResponsePriceTierFlatPriceCurrency.Gyd,
            "hkd" => SubscriptionListResponsePriceTierFlatPriceCurrency.Hkd,
            "hrk" => SubscriptionListResponsePriceTierFlatPriceCurrency.Hrk,
            "htg" => SubscriptionListResponsePriceTierFlatPriceCurrency.Htg,
            "idr" => SubscriptionListResponsePriceTierFlatPriceCurrency.Idr,
            "ils" => SubscriptionListResponsePriceTierFlatPriceCurrency.Ils,
            "inr" => SubscriptionListResponsePriceTierFlatPriceCurrency.Inr,
            "isk" => SubscriptionListResponsePriceTierFlatPriceCurrency.Isk,
            "jmd" => SubscriptionListResponsePriceTierFlatPriceCurrency.Jmd,
            "jpy" => SubscriptionListResponsePriceTierFlatPriceCurrency.Jpy,
            "kes" => SubscriptionListResponsePriceTierFlatPriceCurrency.Kes,
            "kgs" => SubscriptionListResponsePriceTierFlatPriceCurrency.Kgs,
            "khr" => SubscriptionListResponsePriceTierFlatPriceCurrency.Khr,
            "kmf" => SubscriptionListResponsePriceTierFlatPriceCurrency.Kmf,
            "krw" => SubscriptionListResponsePriceTierFlatPriceCurrency.Krw,
            "kyd" => SubscriptionListResponsePriceTierFlatPriceCurrency.Kyd,
            "kzt" => SubscriptionListResponsePriceTierFlatPriceCurrency.Kzt,
            "lbp" => SubscriptionListResponsePriceTierFlatPriceCurrency.Lbp,
            "lkr" => SubscriptionListResponsePriceTierFlatPriceCurrency.Lkr,
            "lrd" => SubscriptionListResponsePriceTierFlatPriceCurrency.Lrd,
            "lsl" => SubscriptionListResponsePriceTierFlatPriceCurrency.Lsl,
            "mad" => SubscriptionListResponsePriceTierFlatPriceCurrency.Mad,
            "mdl" => SubscriptionListResponsePriceTierFlatPriceCurrency.Mdl,
            "mga" => SubscriptionListResponsePriceTierFlatPriceCurrency.Mga,
            "mkd" => SubscriptionListResponsePriceTierFlatPriceCurrency.Mkd,
            "mmk" => SubscriptionListResponsePriceTierFlatPriceCurrency.Mmk,
            "mnt" => SubscriptionListResponsePriceTierFlatPriceCurrency.Mnt,
            "mop" => SubscriptionListResponsePriceTierFlatPriceCurrency.Mop,
            "mro" => SubscriptionListResponsePriceTierFlatPriceCurrency.Mro,
            "mvr" => SubscriptionListResponsePriceTierFlatPriceCurrency.Mvr,
            "mwk" => SubscriptionListResponsePriceTierFlatPriceCurrency.Mwk,
            "mxn" => SubscriptionListResponsePriceTierFlatPriceCurrency.Mxn,
            "myr" => SubscriptionListResponsePriceTierFlatPriceCurrency.Myr,
            "mzn" => SubscriptionListResponsePriceTierFlatPriceCurrency.Mzn,
            "nad" => SubscriptionListResponsePriceTierFlatPriceCurrency.Nad,
            "ngn" => SubscriptionListResponsePriceTierFlatPriceCurrency.Ngn,
            "nok" => SubscriptionListResponsePriceTierFlatPriceCurrency.Nok,
            "npr" => SubscriptionListResponsePriceTierFlatPriceCurrency.Npr,
            "nzd" => SubscriptionListResponsePriceTierFlatPriceCurrency.Nzd,
            "pgk" => SubscriptionListResponsePriceTierFlatPriceCurrency.Pgk,
            "php" => SubscriptionListResponsePriceTierFlatPriceCurrency.Php,
            "pkr" => SubscriptionListResponsePriceTierFlatPriceCurrency.Pkr,
            "pln" => SubscriptionListResponsePriceTierFlatPriceCurrency.Pln,
            "qar" => SubscriptionListResponsePriceTierFlatPriceCurrency.Qar,
            "ron" => SubscriptionListResponsePriceTierFlatPriceCurrency.Ron,
            "rsd" => SubscriptionListResponsePriceTierFlatPriceCurrency.Rsd,
            "rub" => SubscriptionListResponsePriceTierFlatPriceCurrency.Rub,
            "rwf" => SubscriptionListResponsePriceTierFlatPriceCurrency.Rwf,
            "sar" => SubscriptionListResponsePriceTierFlatPriceCurrency.Sar,
            "sbd" => SubscriptionListResponsePriceTierFlatPriceCurrency.Sbd,
            "scr" => SubscriptionListResponsePriceTierFlatPriceCurrency.Scr,
            "sek" => SubscriptionListResponsePriceTierFlatPriceCurrency.Sek,
            "sgd" => SubscriptionListResponsePriceTierFlatPriceCurrency.Sgd,
            "sle" => SubscriptionListResponsePriceTierFlatPriceCurrency.Sle,
            "sll" => SubscriptionListResponsePriceTierFlatPriceCurrency.Sll,
            "sos" => SubscriptionListResponsePriceTierFlatPriceCurrency.Sos,
            "szl" => SubscriptionListResponsePriceTierFlatPriceCurrency.Szl,
            "thb" => SubscriptionListResponsePriceTierFlatPriceCurrency.Thb,
            "tjs" => SubscriptionListResponsePriceTierFlatPriceCurrency.Tjs,
            "top" => SubscriptionListResponsePriceTierFlatPriceCurrency.Top,
            "try" => SubscriptionListResponsePriceTierFlatPriceCurrency.Try,
            "ttd" => SubscriptionListResponsePriceTierFlatPriceCurrency.Ttd,
            "tzs" => SubscriptionListResponsePriceTierFlatPriceCurrency.Tzs,
            "uah" => SubscriptionListResponsePriceTierFlatPriceCurrency.Uah,
            "uzs" => SubscriptionListResponsePriceTierFlatPriceCurrency.Uzs,
            "vnd" => SubscriptionListResponsePriceTierFlatPriceCurrency.Vnd,
            "vuv" => SubscriptionListResponsePriceTierFlatPriceCurrency.Vuv,
            "wst" => SubscriptionListResponsePriceTierFlatPriceCurrency.Wst,
            "xaf" => SubscriptionListResponsePriceTierFlatPriceCurrency.Xaf,
            "xcd" => SubscriptionListResponsePriceTierFlatPriceCurrency.Xcd,
            "yer" => SubscriptionListResponsePriceTierFlatPriceCurrency.Yer,
            "zar" => SubscriptionListResponsePriceTierFlatPriceCurrency.Zar,
            "zmw" => SubscriptionListResponsePriceTierFlatPriceCurrency.Zmw,
            "clp" => SubscriptionListResponsePriceTierFlatPriceCurrency.Clp,
            "djf" => SubscriptionListResponsePriceTierFlatPriceCurrency.Djf,
            "gnf" => SubscriptionListResponsePriceTierFlatPriceCurrency.Gnf,
            "ugx" => SubscriptionListResponsePriceTierFlatPriceCurrency.Ugx,
            "pyg" => SubscriptionListResponsePriceTierFlatPriceCurrency.Pyg,
            "xof" => SubscriptionListResponsePriceTierFlatPriceCurrency.Xof,
            "xpf" => SubscriptionListResponsePriceTierFlatPriceCurrency.Xpf,
            _ => (SubscriptionListResponsePriceTierFlatPriceCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionListResponsePriceTierFlatPriceCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionListResponsePriceTierFlatPriceCurrency.Usd => "usd",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Aed => "aed",
                SubscriptionListResponsePriceTierFlatPriceCurrency.All => "all",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Amd => "amd",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Ang => "ang",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Aud => "aud",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Awg => "awg",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Azn => "azn",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Bam => "bam",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Bbd => "bbd",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Bdt => "bdt",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Bgn => "bgn",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Bif => "bif",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Bmd => "bmd",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Bnd => "bnd",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Bsd => "bsd",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Bwp => "bwp",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Byn => "byn",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Bzd => "bzd",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Brl => "brl",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Cad => "cad",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Cdf => "cdf",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Chf => "chf",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Cny => "cny",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Czk => "czk",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Dkk => "dkk",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Dop => "dop",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Dzd => "dzd",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Egp => "egp",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Etb => "etb",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Eur => "eur",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Fjd => "fjd",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Gbp => "gbp",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Gel => "gel",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Gip => "gip",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Gmd => "gmd",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Gyd => "gyd",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Hkd => "hkd",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Hrk => "hrk",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Htg => "htg",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Idr => "idr",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Ils => "ils",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Inr => "inr",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Isk => "isk",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Jmd => "jmd",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Jpy => "jpy",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Kes => "kes",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Kgs => "kgs",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Khr => "khr",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Kmf => "kmf",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Krw => "krw",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Kyd => "kyd",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Kzt => "kzt",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Lbp => "lbp",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Lkr => "lkr",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Lrd => "lrd",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Lsl => "lsl",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Mad => "mad",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Mdl => "mdl",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Mga => "mga",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Mkd => "mkd",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Mmk => "mmk",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Mnt => "mnt",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Mop => "mop",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Mro => "mro",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Mvr => "mvr",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Mwk => "mwk",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Mxn => "mxn",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Myr => "myr",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Mzn => "mzn",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Nad => "nad",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Ngn => "ngn",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Nok => "nok",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Npr => "npr",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Nzd => "nzd",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Pgk => "pgk",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Php => "php",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Pkr => "pkr",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Pln => "pln",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Qar => "qar",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Ron => "ron",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Rsd => "rsd",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Rub => "rub",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Rwf => "rwf",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Sar => "sar",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Sbd => "sbd",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Scr => "scr",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Sek => "sek",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Sgd => "sgd",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Sle => "sle",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Sll => "sll",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Sos => "sos",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Szl => "szl",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Thb => "thb",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Tjs => "tjs",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Top => "top",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Try => "try",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Ttd => "ttd",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Tzs => "tzs",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Uah => "uah",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Uzs => "uzs",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Vnd => "vnd",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Vuv => "vuv",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Wst => "wst",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Xaf => "xaf",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Xcd => "xcd",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Yer => "yer",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Zar => "zar",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Zmw => "zmw",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Clp => "clp",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Djf => "djf",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Gnf => "gnf",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Ugx => "ugx",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Pyg => "pyg",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Xof => "xof",
                SubscriptionListResponsePriceTierFlatPriceCurrency.Xpf => "xpf",
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
[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionListResponsePriceTierUnitPrice,
        SubscriptionListResponsePriceTierUnitPriceFromRaw
    >)
)]
public sealed record class SubscriptionListResponsePriceTierUnitPrice : JsonModel
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
    public required ApiEnum<string, SubscriptionListResponsePriceTierUnitPriceCurrency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, SubscriptionListResponsePriceTierUnitPriceCurrency>
            >("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        this.Currency.Validate();
    }

    public SubscriptionListResponsePriceTierUnitPrice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionListResponsePriceTierUnitPrice(
        SubscriptionListResponsePriceTierUnitPrice subscriptionListResponsePriceTierUnitPrice
    )
        : base(subscriptionListResponsePriceTierUnitPrice) { }
#pragma warning restore CS8618

    public SubscriptionListResponsePriceTierUnitPrice(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionListResponsePriceTierUnitPrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionListResponsePriceTierUnitPriceFromRaw.FromRawUnchecked"/>
    public static SubscriptionListResponsePriceTierUnitPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionListResponsePriceTierUnitPriceFromRaw
    : IFromRawJson<SubscriptionListResponsePriceTierUnitPrice>
{
    /// <inheritdoc/>
    public SubscriptionListResponsePriceTierUnitPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionListResponsePriceTierUnitPrice.FromRawUnchecked(rawData);
}

/// <summary>
/// ISO 4217 currency code
/// </summary>
[JsonConverter(typeof(SubscriptionListResponsePriceTierUnitPriceCurrencyConverter))]
public enum SubscriptionListResponsePriceTierUnitPriceCurrency
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

sealed class SubscriptionListResponsePriceTierUnitPriceCurrencyConverter
    : JsonConverter<SubscriptionListResponsePriceTierUnitPriceCurrency>
{
    public override SubscriptionListResponsePriceTierUnitPriceCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => SubscriptionListResponsePriceTierUnitPriceCurrency.Usd,
            "aed" => SubscriptionListResponsePriceTierUnitPriceCurrency.Aed,
            "all" => SubscriptionListResponsePriceTierUnitPriceCurrency.All,
            "amd" => SubscriptionListResponsePriceTierUnitPriceCurrency.Amd,
            "ang" => SubscriptionListResponsePriceTierUnitPriceCurrency.Ang,
            "aud" => SubscriptionListResponsePriceTierUnitPriceCurrency.Aud,
            "awg" => SubscriptionListResponsePriceTierUnitPriceCurrency.Awg,
            "azn" => SubscriptionListResponsePriceTierUnitPriceCurrency.Azn,
            "bam" => SubscriptionListResponsePriceTierUnitPriceCurrency.Bam,
            "bbd" => SubscriptionListResponsePriceTierUnitPriceCurrency.Bbd,
            "bdt" => SubscriptionListResponsePriceTierUnitPriceCurrency.Bdt,
            "bgn" => SubscriptionListResponsePriceTierUnitPriceCurrency.Bgn,
            "bif" => SubscriptionListResponsePriceTierUnitPriceCurrency.Bif,
            "bmd" => SubscriptionListResponsePriceTierUnitPriceCurrency.Bmd,
            "bnd" => SubscriptionListResponsePriceTierUnitPriceCurrency.Bnd,
            "bsd" => SubscriptionListResponsePriceTierUnitPriceCurrency.Bsd,
            "bwp" => SubscriptionListResponsePriceTierUnitPriceCurrency.Bwp,
            "byn" => SubscriptionListResponsePriceTierUnitPriceCurrency.Byn,
            "bzd" => SubscriptionListResponsePriceTierUnitPriceCurrency.Bzd,
            "brl" => SubscriptionListResponsePriceTierUnitPriceCurrency.Brl,
            "cad" => SubscriptionListResponsePriceTierUnitPriceCurrency.Cad,
            "cdf" => SubscriptionListResponsePriceTierUnitPriceCurrency.Cdf,
            "chf" => SubscriptionListResponsePriceTierUnitPriceCurrency.Chf,
            "cny" => SubscriptionListResponsePriceTierUnitPriceCurrency.Cny,
            "czk" => SubscriptionListResponsePriceTierUnitPriceCurrency.Czk,
            "dkk" => SubscriptionListResponsePriceTierUnitPriceCurrency.Dkk,
            "dop" => SubscriptionListResponsePriceTierUnitPriceCurrency.Dop,
            "dzd" => SubscriptionListResponsePriceTierUnitPriceCurrency.Dzd,
            "egp" => SubscriptionListResponsePriceTierUnitPriceCurrency.Egp,
            "etb" => SubscriptionListResponsePriceTierUnitPriceCurrency.Etb,
            "eur" => SubscriptionListResponsePriceTierUnitPriceCurrency.Eur,
            "fjd" => SubscriptionListResponsePriceTierUnitPriceCurrency.Fjd,
            "gbp" => SubscriptionListResponsePriceTierUnitPriceCurrency.Gbp,
            "gel" => SubscriptionListResponsePriceTierUnitPriceCurrency.Gel,
            "gip" => SubscriptionListResponsePriceTierUnitPriceCurrency.Gip,
            "gmd" => SubscriptionListResponsePriceTierUnitPriceCurrency.Gmd,
            "gyd" => SubscriptionListResponsePriceTierUnitPriceCurrency.Gyd,
            "hkd" => SubscriptionListResponsePriceTierUnitPriceCurrency.Hkd,
            "hrk" => SubscriptionListResponsePriceTierUnitPriceCurrency.Hrk,
            "htg" => SubscriptionListResponsePriceTierUnitPriceCurrency.Htg,
            "idr" => SubscriptionListResponsePriceTierUnitPriceCurrency.Idr,
            "ils" => SubscriptionListResponsePriceTierUnitPriceCurrency.Ils,
            "inr" => SubscriptionListResponsePriceTierUnitPriceCurrency.Inr,
            "isk" => SubscriptionListResponsePriceTierUnitPriceCurrency.Isk,
            "jmd" => SubscriptionListResponsePriceTierUnitPriceCurrency.Jmd,
            "jpy" => SubscriptionListResponsePriceTierUnitPriceCurrency.Jpy,
            "kes" => SubscriptionListResponsePriceTierUnitPriceCurrency.Kes,
            "kgs" => SubscriptionListResponsePriceTierUnitPriceCurrency.Kgs,
            "khr" => SubscriptionListResponsePriceTierUnitPriceCurrency.Khr,
            "kmf" => SubscriptionListResponsePriceTierUnitPriceCurrency.Kmf,
            "krw" => SubscriptionListResponsePriceTierUnitPriceCurrency.Krw,
            "kyd" => SubscriptionListResponsePriceTierUnitPriceCurrency.Kyd,
            "kzt" => SubscriptionListResponsePriceTierUnitPriceCurrency.Kzt,
            "lbp" => SubscriptionListResponsePriceTierUnitPriceCurrency.Lbp,
            "lkr" => SubscriptionListResponsePriceTierUnitPriceCurrency.Lkr,
            "lrd" => SubscriptionListResponsePriceTierUnitPriceCurrency.Lrd,
            "lsl" => SubscriptionListResponsePriceTierUnitPriceCurrency.Lsl,
            "mad" => SubscriptionListResponsePriceTierUnitPriceCurrency.Mad,
            "mdl" => SubscriptionListResponsePriceTierUnitPriceCurrency.Mdl,
            "mga" => SubscriptionListResponsePriceTierUnitPriceCurrency.Mga,
            "mkd" => SubscriptionListResponsePriceTierUnitPriceCurrency.Mkd,
            "mmk" => SubscriptionListResponsePriceTierUnitPriceCurrency.Mmk,
            "mnt" => SubscriptionListResponsePriceTierUnitPriceCurrency.Mnt,
            "mop" => SubscriptionListResponsePriceTierUnitPriceCurrency.Mop,
            "mro" => SubscriptionListResponsePriceTierUnitPriceCurrency.Mro,
            "mvr" => SubscriptionListResponsePriceTierUnitPriceCurrency.Mvr,
            "mwk" => SubscriptionListResponsePriceTierUnitPriceCurrency.Mwk,
            "mxn" => SubscriptionListResponsePriceTierUnitPriceCurrency.Mxn,
            "myr" => SubscriptionListResponsePriceTierUnitPriceCurrency.Myr,
            "mzn" => SubscriptionListResponsePriceTierUnitPriceCurrency.Mzn,
            "nad" => SubscriptionListResponsePriceTierUnitPriceCurrency.Nad,
            "ngn" => SubscriptionListResponsePriceTierUnitPriceCurrency.Ngn,
            "nok" => SubscriptionListResponsePriceTierUnitPriceCurrency.Nok,
            "npr" => SubscriptionListResponsePriceTierUnitPriceCurrency.Npr,
            "nzd" => SubscriptionListResponsePriceTierUnitPriceCurrency.Nzd,
            "pgk" => SubscriptionListResponsePriceTierUnitPriceCurrency.Pgk,
            "php" => SubscriptionListResponsePriceTierUnitPriceCurrency.Php,
            "pkr" => SubscriptionListResponsePriceTierUnitPriceCurrency.Pkr,
            "pln" => SubscriptionListResponsePriceTierUnitPriceCurrency.Pln,
            "qar" => SubscriptionListResponsePriceTierUnitPriceCurrency.Qar,
            "ron" => SubscriptionListResponsePriceTierUnitPriceCurrency.Ron,
            "rsd" => SubscriptionListResponsePriceTierUnitPriceCurrency.Rsd,
            "rub" => SubscriptionListResponsePriceTierUnitPriceCurrency.Rub,
            "rwf" => SubscriptionListResponsePriceTierUnitPriceCurrency.Rwf,
            "sar" => SubscriptionListResponsePriceTierUnitPriceCurrency.Sar,
            "sbd" => SubscriptionListResponsePriceTierUnitPriceCurrency.Sbd,
            "scr" => SubscriptionListResponsePriceTierUnitPriceCurrency.Scr,
            "sek" => SubscriptionListResponsePriceTierUnitPriceCurrency.Sek,
            "sgd" => SubscriptionListResponsePriceTierUnitPriceCurrency.Sgd,
            "sle" => SubscriptionListResponsePriceTierUnitPriceCurrency.Sle,
            "sll" => SubscriptionListResponsePriceTierUnitPriceCurrency.Sll,
            "sos" => SubscriptionListResponsePriceTierUnitPriceCurrency.Sos,
            "szl" => SubscriptionListResponsePriceTierUnitPriceCurrency.Szl,
            "thb" => SubscriptionListResponsePriceTierUnitPriceCurrency.Thb,
            "tjs" => SubscriptionListResponsePriceTierUnitPriceCurrency.Tjs,
            "top" => SubscriptionListResponsePriceTierUnitPriceCurrency.Top,
            "try" => SubscriptionListResponsePriceTierUnitPriceCurrency.Try,
            "ttd" => SubscriptionListResponsePriceTierUnitPriceCurrency.Ttd,
            "tzs" => SubscriptionListResponsePriceTierUnitPriceCurrency.Tzs,
            "uah" => SubscriptionListResponsePriceTierUnitPriceCurrency.Uah,
            "uzs" => SubscriptionListResponsePriceTierUnitPriceCurrency.Uzs,
            "vnd" => SubscriptionListResponsePriceTierUnitPriceCurrency.Vnd,
            "vuv" => SubscriptionListResponsePriceTierUnitPriceCurrency.Vuv,
            "wst" => SubscriptionListResponsePriceTierUnitPriceCurrency.Wst,
            "xaf" => SubscriptionListResponsePriceTierUnitPriceCurrency.Xaf,
            "xcd" => SubscriptionListResponsePriceTierUnitPriceCurrency.Xcd,
            "yer" => SubscriptionListResponsePriceTierUnitPriceCurrency.Yer,
            "zar" => SubscriptionListResponsePriceTierUnitPriceCurrency.Zar,
            "zmw" => SubscriptionListResponsePriceTierUnitPriceCurrency.Zmw,
            "clp" => SubscriptionListResponsePriceTierUnitPriceCurrency.Clp,
            "djf" => SubscriptionListResponsePriceTierUnitPriceCurrency.Djf,
            "gnf" => SubscriptionListResponsePriceTierUnitPriceCurrency.Gnf,
            "ugx" => SubscriptionListResponsePriceTierUnitPriceCurrency.Ugx,
            "pyg" => SubscriptionListResponsePriceTierUnitPriceCurrency.Pyg,
            "xof" => SubscriptionListResponsePriceTierUnitPriceCurrency.Xof,
            "xpf" => SubscriptionListResponsePriceTierUnitPriceCurrency.Xpf,
            _ => (SubscriptionListResponsePriceTierUnitPriceCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionListResponsePriceTierUnitPriceCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionListResponsePriceTierUnitPriceCurrency.Usd => "usd",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Aed => "aed",
                SubscriptionListResponsePriceTierUnitPriceCurrency.All => "all",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Amd => "amd",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Ang => "ang",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Aud => "aud",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Awg => "awg",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Azn => "azn",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Bam => "bam",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Bbd => "bbd",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Bdt => "bdt",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Bgn => "bgn",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Bif => "bif",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Bmd => "bmd",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Bnd => "bnd",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Bsd => "bsd",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Bwp => "bwp",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Byn => "byn",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Bzd => "bzd",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Brl => "brl",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Cad => "cad",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Cdf => "cdf",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Chf => "chf",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Cny => "cny",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Czk => "czk",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Dkk => "dkk",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Dop => "dop",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Dzd => "dzd",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Egp => "egp",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Etb => "etb",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Eur => "eur",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Fjd => "fjd",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Gbp => "gbp",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Gel => "gel",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Gip => "gip",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Gmd => "gmd",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Gyd => "gyd",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Hkd => "hkd",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Hrk => "hrk",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Htg => "htg",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Idr => "idr",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Ils => "ils",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Inr => "inr",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Isk => "isk",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Jmd => "jmd",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Jpy => "jpy",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Kes => "kes",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Kgs => "kgs",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Khr => "khr",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Kmf => "kmf",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Krw => "krw",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Kyd => "kyd",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Kzt => "kzt",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Lbp => "lbp",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Lkr => "lkr",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Lrd => "lrd",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Lsl => "lsl",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Mad => "mad",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Mdl => "mdl",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Mga => "mga",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Mkd => "mkd",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Mmk => "mmk",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Mnt => "mnt",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Mop => "mop",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Mro => "mro",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Mvr => "mvr",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Mwk => "mwk",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Mxn => "mxn",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Myr => "myr",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Mzn => "mzn",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Nad => "nad",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Ngn => "ngn",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Nok => "nok",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Npr => "npr",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Nzd => "nzd",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Pgk => "pgk",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Php => "php",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Pkr => "pkr",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Pln => "pln",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Qar => "qar",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Ron => "ron",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Rsd => "rsd",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Rub => "rub",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Rwf => "rwf",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Sar => "sar",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Sbd => "sbd",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Scr => "scr",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Sek => "sek",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Sgd => "sgd",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Sle => "sle",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Sll => "sll",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Sos => "sos",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Szl => "szl",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Thb => "thb",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Tjs => "tjs",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Top => "top",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Try => "try",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Ttd => "ttd",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Tzs => "tzs",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Uah => "uah",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Uzs => "uzs",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Vnd => "vnd",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Vuv => "vuv",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Wst => "wst",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Xaf => "xaf",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Xcd => "xcd",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Yer => "yer",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Zar => "zar",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Zmw => "zmw",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Clp => "clp",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Djf => "djf",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Gnf => "gnf",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Ugx => "ugx",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Pyg => "pyg",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Xof => "xof",
                SubscriptionListResponsePriceTierUnitPriceCurrency.Xpf => "xpf",
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
[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionListResponseSubscriptionEntitlement,
        SubscriptionListResponseSubscriptionEntitlementFromRaw
    >)
)]
public sealed record class SubscriptionListResponseSubscriptionEntitlement : JsonModel
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
    public required ApiEnum<string, SubscriptionListResponseSubscriptionEntitlementType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, SubscriptionListResponseSubscriptionEntitlementType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Type.Validate();
    }

    public SubscriptionListResponseSubscriptionEntitlement() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionListResponseSubscriptionEntitlement(
        SubscriptionListResponseSubscriptionEntitlement subscriptionListResponseSubscriptionEntitlement
    )
        : base(subscriptionListResponseSubscriptionEntitlement) { }
#pragma warning restore CS8618

    public SubscriptionListResponseSubscriptionEntitlement(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionListResponseSubscriptionEntitlement(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionListResponseSubscriptionEntitlementFromRaw.FromRawUnchecked"/>
    public static SubscriptionListResponseSubscriptionEntitlement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionListResponseSubscriptionEntitlementFromRaw
    : IFromRawJson<SubscriptionListResponseSubscriptionEntitlement>
{
    /// <inheritdoc/>
    public SubscriptionListResponseSubscriptionEntitlement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionListResponseSubscriptionEntitlement.FromRawUnchecked(rawData);
}

/// <summary>
/// Entitlement type (FEATURE or CREDIT)
/// </summary>
[JsonConverter(typeof(SubscriptionListResponseSubscriptionEntitlementTypeConverter))]
public enum SubscriptionListResponseSubscriptionEntitlementType
{
    Feature,
    Credit,
}

sealed class SubscriptionListResponseSubscriptionEntitlementTypeConverter
    : JsonConverter<SubscriptionListResponseSubscriptionEntitlementType>
{
    public override SubscriptionListResponseSubscriptionEntitlementType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FEATURE" => SubscriptionListResponseSubscriptionEntitlementType.Feature,
            "CREDIT" => SubscriptionListResponseSubscriptionEntitlementType.Credit,
            _ => (SubscriptionListResponseSubscriptionEntitlementType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionListResponseSubscriptionEntitlementType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionListResponseSubscriptionEntitlementType.Feature => "FEATURE",
                SubscriptionListResponseSubscriptionEntitlementType.Credit => "CREDIT",
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
[JsonConverter(
    typeof(JsonModelConverter<SubscriptionListResponseTrial, SubscriptionListResponseTrialFromRaw>)
)]
public sealed record class SubscriptionListResponseTrial : JsonModel
{
    /// <summary>
    /// Behavior when the trial ends
    /// </summary>
    public required ApiEnum<string, SubscriptionListResponseTrialTrialEndBehavior> TrialEndBehavior
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, SubscriptionListResponseTrialTrialEndBehavior>
            >("trialEndBehavior");
        }
        init { this._rawData.Set("trialEndBehavior", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.TrialEndBehavior.Validate();
    }

    public SubscriptionListResponseTrial() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionListResponseTrial(
        SubscriptionListResponseTrial subscriptionListResponseTrial
    )
        : base(subscriptionListResponseTrial) { }
#pragma warning restore CS8618

    public SubscriptionListResponseTrial(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionListResponseTrial(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionListResponseTrialFromRaw.FromRawUnchecked"/>
    public static SubscriptionListResponseTrial FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SubscriptionListResponseTrial(
        ApiEnum<string, SubscriptionListResponseTrialTrialEndBehavior> trialEndBehavior
    )
        : this()
    {
        this.TrialEndBehavior = trialEndBehavior;
    }
}

class SubscriptionListResponseTrialFromRaw : IFromRawJson<SubscriptionListResponseTrial>
{
    /// <inheritdoc/>
    public SubscriptionListResponseTrial FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionListResponseTrial.FromRawUnchecked(rawData);
}

/// <summary>
/// Behavior when the trial ends
/// </summary>
[JsonConverter(typeof(SubscriptionListResponseTrialTrialEndBehaviorConverter))]
public enum SubscriptionListResponseTrialTrialEndBehavior
{
    ConvertToPaid,
    CancelSubscription,
}

sealed class SubscriptionListResponseTrialTrialEndBehaviorConverter
    : JsonConverter<SubscriptionListResponseTrialTrialEndBehavior>
{
    public override SubscriptionListResponseTrialTrialEndBehavior Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "CONVERT_TO_PAID" => SubscriptionListResponseTrialTrialEndBehavior.ConvertToPaid,
            "CANCEL_SUBSCRIPTION" =>
                SubscriptionListResponseTrialTrialEndBehavior.CancelSubscription,
            _ => (SubscriptionListResponseTrialTrialEndBehavior)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionListResponseTrialTrialEndBehavior value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionListResponseTrialTrialEndBehavior.ConvertToPaid => "CONVERT_TO_PAID",
                SubscriptionListResponseTrialTrialEndBehavior.CancelSubscription =>
                    "CANCEL_SUBSCRIPTION",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
