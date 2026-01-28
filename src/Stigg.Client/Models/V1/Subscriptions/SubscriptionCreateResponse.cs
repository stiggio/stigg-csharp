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

    public required IReadOnlyList<Entitlement> Entitlements
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Entitlement>>("entitlements");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Entitlement>>(
                "entitlements",
                ImmutableArray.ToImmutableArray(value)
            );
        }
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
        foreach (var item in this.Entitlements)
        {
            item.Validate();
        }
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

[JsonConverter(typeof(JsonModelConverter<Entitlement, EntitlementFromRaw>))]
public sealed record class Entitlement : JsonModel
{
    public string? AccessDeniedReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("accessDeniedReason");
        }
        init { this._rawData.Set("accessDeniedReason", value); }
    }

    public double? CurrentUsage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("currentUsage");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("currentUsage", value);
        }
    }

    /// <summary>
    /// entitlement updated at
    /// </summary>
    public System::DateTimeOffset? EntitlementUpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("entitlementUpdatedAt");
        }
        init { this._rawData.Set("entitlementUpdatedAt", value); }
    }

    public Feature? Feature
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Feature>("feature");
        }
        init { this._rawData.Set("feature", value); }
    }

    public bool? HasUnlimitedUsage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("hasUnlimitedUsage");
        }
        init { this._rawData.Set("hasUnlimitedUsage", value); }
    }

    public bool? IsGranted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isGranted");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isGranted", value);
        }
    }

    public ApiEnum<string, ResetPeriod>? ResetPeriod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ResetPeriod>>("resetPeriod");
        }
        init { this._rawData.Set("resetPeriod", value); }
    }

    public double? UsageLimit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("usageLimit");
        }
        init { this._rawData.Set("usageLimit", value); }
    }

    /// <summary>
    /// usage period anchor
    /// </summary>
    public System::DateTimeOffset? UsagePeriodAnchor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("usagePeriodAnchor");
        }
        init { this._rawData.Set("usagePeriodAnchor", value); }
    }

    /// <summary>
    /// usage period end
    /// </summary>
    public System::DateTimeOffset? UsagePeriodEnd
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("usagePeriodEnd");
        }
        init { this._rawData.Set("usagePeriodEnd", value); }
    }

    /// <summary>
    /// usage period start
    /// </summary>
    public System::DateTimeOffset? UsagePeriodStart
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("usagePeriodStart");
        }
        init { this._rawData.Set("usagePeriodStart", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AccessDeniedReason;
        _ = this.CurrentUsage;
        _ = this.EntitlementUpdatedAt;
        this.Feature?.Validate();
        _ = this.HasUnlimitedUsage;
        _ = this.IsGranted;
        this.ResetPeriod?.Validate();
        _ = this.UsageLimit;
        _ = this.UsagePeriodAnchor;
        _ = this.UsagePeriodEnd;
        _ = this.UsagePeriodStart;
    }

    public Entitlement() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Entitlement(Entitlement entitlement)
        : base(entitlement) { }
#pragma warning restore CS8618

    public Entitlement(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Entitlement(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementFromRaw.FromRawUnchecked"/>
    public static Entitlement FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntitlementFromRaw : IFromRawJson<Entitlement>
{
    /// <inheritdoc/>
    public Entitlement FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Entitlement.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Feature, FeatureFromRaw>))]
public sealed record class Feature : JsonModel
{
    public required string RefID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("refId");
        }
        init { this._rawData.Set("refId", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.RefID;
    }

    public Feature() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Feature(Feature feature)
        : base(feature) { }
#pragma warning restore CS8618

    public Feature(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Feature(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FeatureFromRaw.FromRawUnchecked"/>
    public static Feature FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Feature(string refID)
        : this()
    {
        this.RefID = refID;
    }
}

class FeatureFromRaw : IFromRawJson<Feature>
{
    /// <inheritdoc/>
    public Feature FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Feature.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ResetPeriodConverter))]
public enum ResetPeriod
{
    Year,
    Month,
    Week,
    Day,
    Hour,
}

sealed class ResetPeriodConverter : JsonConverter<ResetPeriod>
{
    public override ResetPeriod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "YEAR" => ResetPeriod.Year,
            "MONTH" => ResetPeriod.Month,
            "WEEK" => ResetPeriod.Week,
            "DAY" => ResetPeriod.Day,
            "HOUR" => ResetPeriod.Hour,
            _ => (ResetPeriod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ResetPeriod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ResetPeriod.Year => "YEAR",
                ResetPeriod.Month => "MONTH",
                ResetPeriod.Week => "WEEK",
                ResetPeriod.Day => "DAY",
                ResetPeriod.Hour => "HOUR",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
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
    public ApiEnum<string, SubscriptionPaymentCollectionMethod>? PaymentCollectionMethod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, SubscriptionPaymentCollectionMethod>
            >("paymentCollectionMethod");
        }
        init { this._rawData.Set("paymentCollectionMethod", value); }
    }

    public IReadOnlyList<SubscriptionPrice>? Prices
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<SubscriptionPrice>>("prices");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<SubscriptionPrice>?>(
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
[JsonConverter(typeof(SubscriptionPaymentCollectionMethodConverter))]
public enum SubscriptionPaymentCollectionMethod
{
    Charge,
    Invoice,
    None,
}

sealed class SubscriptionPaymentCollectionMethodConverter
    : JsonConverter<SubscriptionPaymentCollectionMethod>
{
    public override SubscriptionPaymentCollectionMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "CHARGE" => SubscriptionPaymentCollectionMethod.Charge,
            "INVOICE" => SubscriptionPaymentCollectionMethod.Invoice,
            "NONE" => SubscriptionPaymentCollectionMethod.None,
            _ => (SubscriptionPaymentCollectionMethod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionPaymentCollectionMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionPaymentCollectionMethod.Charge => "CHARGE",
                SubscriptionPaymentCollectionMethod.Invoice => "INVOICE",
                SubscriptionPaymentCollectionMethod.None => "NONE",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<SubscriptionPrice, SubscriptionPriceFromRaw>))]
public sealed record class SubscriptionPrice : JsonModel
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
    /// Override price amount
    /// </summary>
    public SubscriptionPricePrice? Price
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SubscriptionPricePrice>("price");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("price", value);
        }
    }

    /// <summary>
    /// Pricing tiers configuration
    /// </summary>
    public IReadOnlyList<SubscriptionPriceTier>? Tiers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<SubscriptionPriceTier>>("tiers");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<SubscriptionPriceTier>?>(
                "tiers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AddonID;
        _ = this.BaseCharge;
        _ = this.BlockSize;
        _ = this.FeatureID;
        this.Price?.Validate();
        foreach (var item in this.Tiers ?? [])
        {
            item.Validate();
        }
    }

    public SubscriptionPrice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionPrice(SubscriptionPrice subscriptionPrice)
        : base(subscriptionPrice) { }
#pragma warning restore CS8618

    public SubscriptionPrice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionPrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionPriceFromRaw.FromRawUnchecked"/>
    public static SubscriptionPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionPriceFromRaw : IFromRawJson<SubscriptionPrice>
{
    /// <inheritdoc/>
    public SubscriptionPrice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SubscriptionPrice.FromRawUnchecked(rawData);
}

/// <summary>
/// Override price amount
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SubscriptionPricePrice, SubscriptionPricePriceFromRaw>))]
public sealed record class SubscriptionPricePrice : JsonModel
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
    /// The billing country code of the price
    /// </summary>
    public string? BillingCountryCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billingCountryCode");
        }
        init { this._rawData.Set("billingCountryCode", value); }
    }

    /// <summary>
    /// The price currency
    /// </summary>
    public ApiEnum<string, SubscriptionPricePriceCurrency>? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, SubscriptionPricePriceCurrency>>(
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
        _ = this.BillingCountryCode;
        this.Currency?.Validate();
    }

    public SubscriptionPricePrice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionPricePrice(SubscriptionPricePrice subscriptionPricePrice)
        : base(subscriptionPricePrice) { }
#pragma warning restore CS8618

    public SubscriptionPricePrice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionPricePrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionPricePriceFromRaw.FromRawUnchecked"/>
    public static SubscriptionPricePrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionPricePriceFromRaw : IFromRawJson<SubscriptionPricePrice>
{
    /// <inheritdoc/>
    public SubscriptionPricePrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionPricePrice.FromRawUnchecked(rawData);
}

/// <summary>
/// The price currency
/// </summary>
[JsonConverter(typeof(SubscriptionPricePriceCurrencyConverter))]
public enum SubscriptionPricePriceCurrency
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

sealed class SubscriptionPricePriceCurrencyConverter : JsonConverter<SubscriptionPricePriceCurrency>
{
    public override SubscriptionPricePriceCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => SubscriptionPricePriceCurrency.Usd,
            "aed" => SubscriptionPricePriceCurrency.Aed,
            "all" => SubscriptionPricePriceCurrency.All,
            "amd" => SubscriptionPricePriceCurrency.Amd,
            "ang" => SubscriptionPricePriceCurrency.Ang,
            "aud" => SubscriptionPricePriceCurrency.Aud,
            "awg" => SubscriptionPricePriceCurrency.Awg,
            "azn" => SubscriptionPricePriceCurrency.Azn,
            "bam" => SubscriptionPricePriceCurrency.Bam,
            "bbd" => SubscriptionPricePriceCurrency.Bbd,
            "bdt" => SubscriptionPricePriceCurrency.Bdt,
            "bgn" => SubscriptionPricePriceCurrency.Bgn,
            "bif" => SubscriptionPricePriceCurrency.Bif,
            "bmd" => SubscriptionPricePriceCurrency.Bmd,
            "bnd" => SubscriptionPricePriceCurrency.Bnd,
            "bsd" => SubscriptionPricePriceCurrency.Bsd,
            "bwp" => SubscriptionPricePriceCurrency.Bwp,
            "byn" => SubscriptionPricePriceCurrency.Byn,
            "bzd" => SubscriptionPricePriceCurrency.Bzd,
            "brl" => SubscriptionPricePriceCurrency.Brl,
            "cad" => SubscriptionPricePriceCurrency.Cad,
            "cdf" => SubscriptionPricePriceCurrency.Cdf,
            "chf" => SubscriptionPricePriceCurrency.Chf,
            "cny" => SubscriptionPricePriceCurrency.Cny,
            "czk" => SubscriptionPricePriceCurrency.Czk,
            "dkk" => SubscriptionPricePriceCurrency.Dkk,
            "dop" => SubscriptionPricePriceCurrency.Dop,
            "dzd" => SubscriptionPricePriceCurrency.Dzd,
            "egp" => SubscriptionPricePriceCurrency.Egp,
            "etb" => SubscriptionPricePriceCurrency.Etb,
            "eur" => SubscriptionPricePriceCurrency.Eur,
            "fjd" => SubscriptionPricePriceCurrency.Fjd,
            "gbp" => SubscriptionPricePriceCurrency.Gbp,
            "gel" => SubscriptionPricePriceCurrency.Gel,
            "gip" => SubscriptionPricePriceCurrency.Gip,
            "gmd" => SubscriptionPricePriceCurrency.Gmd,
            "gyd" => SubscriptionPricePriceCurrency.Gyd,
            "hkd" => SubscriptionPricePriceCurrency.Hkd,
            "hrk" => SubscriptionPricePriceCurrency.Hrk,
            "htg" => SubscriptionPricePriceCurrency.Htg,
            "idr" => SubscriptionPricePriceCurrency.Idr,
            "ils" => SubscriptionPricePriceCurrency.Ils,
            "inr" => SubscriptionPricePriceCurrency.Inr,
            "isk" => SubscriptionPricePriceCurrency.Isk,
            "jmd" => SubscriptionPricePriceCurrency.Jmd,
            "jpy" => SubscriptionPricePriceCurrency.Jpy,
            "kes" => SubscriptionPricePriceCurrency.Kes,
            "kgs" => SubscriptionPricePriceCurrency.Kgs,
            "khr" => SubscriptionPricePriceCurrency.Khr,
            "kmf" => SubscriptionPricePriceCurrency.Kmf,
            "krw" => SubscriptionPricePriceCurrency.Krw,
            "kyd" => SubscriptionPricePriceCurrency.Kyd,
            "kzt" => SubscriptionPricePriceCurrency.Kzt,
            "lbp" => SubscriptionPricePriceCurrency.Lbp,
            "lkr" => SubscriptionPricePriceCurrency.Lkr,
            "lrd" => SubscriptionPricePriceCurrency.Lrd,
            "lsl" => SubscriptionPricePriceCurrency.Lsl,
            "mad" => SubscriptionPricePriceCurrency.Mad,
            "mdl" => SubscriptionPricePriceCurrency.Mdl,
            "mga" => SubscriptionPricePriceCurrency.Mga,
            "mkd" => SubscriptionPricePriceCurrency.Mkd,
            "mmk" => SubscriptionPricePriceCurrency.Mmk,
            "mnt" => SubscriptionPricePriceCurrency.Mnt,
            "mop" => SubscriptionPricePriceCurrency.Mop,
            "mro" => SubscriptionPricePriceCurrency.Mro,
            "mvr" => SubscriptionPricePriceCurrency.Mvr,
            "mwk" => SubscriptionPricePriceCurrency.Mwk,
            "mxn" => SubscriptionPricePriceCurrency.Mxn,
            "myr" => SubscriptionPricePriceCurrency.Myr,
            "mzn" => SubscriptionPricePriceCurrency.Mzn,
            "nad" => SubscriptionPricePriceCurrency.Nad,
            "ngn" => SubscriptionPricePriceCurrency.Ngn,
            "nok" => SubscriptionPricePriceCurrency.Nok,
            "npr" => SubscriptionPricePriceCurrency.Npr,
            "nzd" => SubscriptionPricePriceCurrency.Nzd,
            "pgk" => SubscriptionPricePriceCurrency.Pgk,
            "php" => SubscriptionPricePriceCurrency.Php,
            "pkr" => SubscriptionPricePriceCurrency.Pkr,
            "pln" => SubscriptionPricePriceCurrency.Pln,
            "qar" => SubscriptionPricePriceCurrency.Qar,
            "ron" => SubscriptionPricePriceCurrency.Ron,
            "rsd" => SubscriptionPricePriceCurrency.Rsd,
            "rub" => SubscriptionPricePriceCurrency.Rub,
            "rwf" => SubscriptionPricePriceCurrency.Rwf,
            "sar" => SubscriptionPricePriceCurrency.Sar,
            "sbd" => SubscriptionPricePriceCurrency.Sbd,
            "scr" => SubscriptionPricePriceCurrency.Scr,
            "sek" => SubscriptionPricePriceCurrency.Sek,
            "sgd" => SubscriptionPricePriceCurrency.Sgd,
            "sle" => SubscriptionPricePriceCurrency.Sle,
            "sll" => SubscriptionPricePriceCurrency.Sll,
            "sos" => SubscriptionPricePriceCurrency.Sos,
            "szl" => SubscriptionPricePriceCurrency.Szl,
            "thb" => SubscriptionPricePriceCurrency.Thb,
            "tjs" => SubscriptionPricePriceCurrency.Tjs,
            "top" => SubscriptionPricePriceCurrency.Top,
            "try" => SubscriptionPricePriceCurrency.Try,
            "ttd" => SubscriptionPricePriceCurrency.Ttd,
            "tzs" => SubscriptionPricePriceCurrency.Tzs,
            "uah" => SubscriptionPricePriceCurrency.Uah,
            "uzs" => SubscriptionPricePriceCurrency.Uzs,
            "vnd" => SubscriptionPricePriceCurrency.Vnd,
            "vuv" => SubscriptionPricePriceCurrency.Vuv,
            "wst" => SubscriptionPricePriceCurrency.Wst,
            "xaf" => SubscriptionPricePriceCurrency.Xaf,
            "xcd" => SubscriptionPricePriceCurrency.Xcd,
            "yer" => SubscriptionPricePriceCurrency.Yer,
            "zar" => SubscriptionPricePriceCurrency.Zar,
            "zmw" => SubscriptionPricePriceCurrency.Zmw,
            "clp" => SubscriptionPricePriceCurrency.Clp,
            "djf" => SubscriptionPricePriceCurrency.Djf,
            "gnf" => SubscriptionPricePriceCurrency.Gnf,
            "ugx" => SubscriptionPricePriceCurrency.Ugx,
            "pyg" => SubscriptionPricePriceCurrency.Pyg,
            "xof" => SubscriptionPricePriceCurrency.Xof,
            "xpf" => SubscriptionPricePriceCurrency.Xpf,
            _ => (SubscriptionPricePriceCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionPricePriceCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionPricePriceCurrency.Usd => "usd",
                SubscriptionPricePriceCurrency.Aed => "aed",
                SubscriptionPricePriceCurrency.All => "all",
                SubscriptionPricePriceCurrency.Amd => "amd",
                SubscriptionPricePriceCurrency.Ang => "ang",
                SubscriptionPricePriceCurrency.Aud => "aud",
                SubscriptionPricePriceCurrency.Awg => "awg",
                SubscriptionPricePriceCurrency.Azn => "azn",
                SubscriptionPricePriceCurrency.Bam => "bam",
                SubscriptionPricePriceCurrency.Bbd => "bbd",
                SubscriptionPricePriceCurrency.Bdt => "bdt",
                SubscriptionPricePriceCurrency.Bgn => "bgn",
                SubscriptionPricePriceCurrency.Bif => "bif",
                SubscriptionPricePriceCurrency.Bmd => "bmd",
                SubscriptionPricePriceCurrency.Bnd => "bnd",
                SubscriptionPricePriceCurrency.Bsd => "bsd",
                SubscriptionPricePriceCurrency.Bwp => "bwp",
                SubscriptionPricePriceCurrency.Byn => "byn",
                SubscriptionPricePriceCurrency.Bzd => "bzd",
                SubscriptionPricePriceCurrency.Brl => "brl",
                SubscriptionPricePriceCurrency.Cad => "cad",
                SubscriptionPricePriceCurrency.Cdf => "cdf",
                SubscriptionPricePriceCurrency.Chf => "chf",
                SubscriptionPricePriceCurrency.Cny => "cny",
                SubscriptionPricePriceCurrency.Czk => "czk",
                SubscriptionPricePriceCurrency.Dkk => "dkk",
                SubscriptionPricePriceCurrency.Dop => "dop",
                SubscriptionPricePriceCurrency.Dzd => "dzd",
                SubscriptionPricePriceCurrency.Egp => "egp",
                SubscriptionPricePriceCurrency.Etb => "etb",
                SubscriptionPricePriceCurrency.Eur => "eur",
                SubscriptionPricePriceCurrency.Fjd => "fjd",
                SubscriptionPricePriceCurrency.Gbp => "gbp",
                SubscriptionPricePriceCurrency.Gel => "gel",
                SubscriptionPricePriceCurrency.Gip => "gip",
                SubscriptionPricePriceCurrency.Gmd => "gmd",
                SubscriptionPricePriceCurrency.Gyd => "gyd",
                SubscriptionPricePriceCurrency.Hkd => "hkd",
                SubscriptionPricePriceCurrency.Hrk => "hrk",
                SubscriptionPricePriceCurrency.Htg => "htg",
                SubscriptionPricePriceCurrency.Idr => "idr",
                SubscriptionPricePriceCurrency.Ils => "ils",
                SubscriptionPricePriceCurrency.Inr => "inr",
                SubscriptionPricePriceCurrency.Isk => "isk",
                SubscriptionPricePriceCurrency.Jmd => "jmd",
                SubscriptionPricePriceCurrency.Jpy => "jpy",
                SubscriptionPricePriceCurrency.Kes => "kes",
                SubscriptionPricePriceCurrency.Kgs => "kgs",
                SubscriptionPricePriceCurrency.Khr => "khr",
                SubscriptionPricePriceCurrency.Kmf => "kmf",
                SubscriptionPricePriceCurrency.Krw => "krw",
                SubscriptionPricePriceCurrency.Kyd => "kyd",
                SubscriptionPricePriceCurrency.Kzt => "kzt",
                SubscriptionPricePriceCurrency.Lbp => "lbp",
                SubscriptionPricePriceCurrency.Lkr => "lkr",
                SubscriptionPricePriceCurrency.Lrd => "lrd",
                SubscriptionPricePriceCurrency.Lsl => "lsl",
                SubscriptionPricePriceCurrency.Mad => "mad",
                SubscriptionPricePriceCurrency.Mdl => "mdl",
                SubscriptionPricePriceCurrency.Mga => "mga",
                SubscriptionPricePriceCurrency.Mkd => "mkd",
                SubscriptionPricePriceCurrency.Mmk => "mmk",
                SubscriptionPricePriceCurrency.Mnt => "mnt",
                SubscriptionPricePriceCurrency.Mop => "mop",
                SubscriptionPricePriceCurrency.Mro => "mro",
                SubscriptionPricePriceCurrency.Mvr => "mvr",
                SubscriptionPricePriceCurrency.Mwk => "mwk",
                SubscriptionPricePriceCurrency.Mxn => "mxn",
                SubscriptionPricePriceCurrency.Myr => "myr",
                SubscriptionPricePriceCurrency.Mzn => "mzn",
                SubscriptionPricePriceCurrency.Nad => "nad",
                SubscriptionPricePriceCurrency.Ngn => "ngn",
                SubscriptionPricePriceCurrency.Nok => "nok",
                SubscriptionPricePriceCurrency.Npr => "npr",
                SubscriptionPricePriceCurrency.Nzd => "nzd",
                SubscriptionPricePriceCurrency.Pgk => "pgk",
                SubscriptionPricePriceCurrency.Php => "php",
                SubscriptionPricePriceCurrency.Pkr => "pkr",
                SubscriptionPricePriceCurrency.Pln => "pln",
                SubscriptionPricePriceCurrency.Qar => "qar",
                SubscriptionPricePriceCurrency.Ron => "ron",
                SubscriptionPricePriceCurrency.Rsd => "rsd",
                SubscriptionPricePriceCurrency.Rub => "rub",
                SubscriptionPricePriceCurrency.Rwf => "rwf",
                SubscriptionPricePriceCurrency.Sar => "sar",
                SubscriptionPricePriceCurrency.Sbd => "sbd",
                SubscriptionPricePriceCurrency.Scr => "scr",
                SubscriptionPricePriceCurrency.Sek => "sek",
                SubscriptionPricePriceCurrency.Sgd => "sgd",
                SubscriptionPricePriceCurrency.Sle => "sle",
                SubscriptionPricePriceCurrency.Sll => "sll",
                SubscriptionPricePriceCurrency.Sos => "sos",
                SubscriptionPricePriceCurrency.Szl => "szl",
                SubscriptionPricePriceCurrency.Thb => "thb",
                SubscriptionPricePriceCurrency.Tjs => "tjs",
                SubscriptionPricePriceCurrency.Top => "top",
                SubscriptionPricePriceCurrency.Try => "try",
                SubscriptionPricePriceCurrency.Ttd => "ttd",
                SubscriptionPricePriceCurrency.Tzs => "tzs",
                SubscriptionPricePriceCurrency.Uah => "uah",
                SubscriptionPricePriceCurrency.Uzs => "uzs",
                SubscriptionPricePriceCurrency.Vnd => "vnd",
                SubscriptionPricePriceCurrency.Vuv => "vuv",
                SubscriptionPricePriceCurrency.Wst => "wst",
                SubscriptionPricePriceCurrency.Xaf => "xaf",
                SubscriptionPricePriceCurrency.Xcd => "xcd",
                SubscriptionPricePriceCurrency.Yer => "yer",
                SubscriptionPricePriceCurrency.Zar => "zar",
                SubscriptionPricePriceCurrency.Zmw => "zmw",
                SubscriptionPricePriceCurrency.Clp => "clp",
                SubscriptionPricePriceCurrency.Djf => "djf",
                SubscriptionPricePriceCurrency.Gnf => "gnf",
                SubscriptionPricePriceCurrency.Ugx => "ugx",
                SubscriptionPricePriceCurrency.Pyg => "pyg",
                SubscriptionPricePriceCurrency.Xof => "xof",
                SubscriptionPricePriceCurrency.Xpf => "xpf",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<SubscriptionPriceTier, SubscriptionPriceTierFromRaw>))]
public sealed record class SubscriptionPriceTier : JsonModel
{
    /// <summary>
    /// The flat fee price of the price tier
    /// </summary>
    public SubscriptionPriceTierFlatPrice? FlatPrice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SubscriptionPriceTierFlatPrice>("flatPrice");
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
    public SubscriptionPriceTierUnitPrice? UnitPrice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SubscriptionPriceTierUnitPrice>("unitPrice");
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

    public SubscriptionPriceTier() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionPriceTier(SubscriptionPriceTier subscriptionPriceTier)
        : base(subscriptionPriceTier) { }
#pragma warning restore CS8618

    public SubscriptionPriceTier(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionPriceTier(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionPriceTierFromRaw.FromRawUnchecked"/>
    public static SubscriptionPriceTier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionPriceTierFromRaw : IFromRawJson<SubscriptionPriceTier>
{
    /// <inheritdoc/>
    public SubscriptionPriceTier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionPriceTier.FromRawUnchecked(rawData);
}

/// <summary>
/// The flat fee price of the price tier
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionPriceTierFlatPrice,
        SubscriptionPriceTierFlatPriceFromRaw
    >)
)]
public sealed record class SubscriptionPriceTierFlatPrice : JsonModel
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
    /// The billing country code of the price
    /// </summary>
    public string? BillingCountryCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billingCountryCode");
        }
        init { this._rawData.Set("billingCountryCode", value); }
    }

    /// <summary>
    /// The price currency
    /// </summary>
    public ApiEnum<string, SubscriptionPriceTierFlatPriceCurrency>? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, SubscriptionPriceTierFlatPriceCurrency>
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
        _ = this.BillingCountryCode;
        this.Currency?.Validate();
    }

    public SubscriptionPriceTierFlatPrice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionPriceTierFlatPrice(
        SubscriptionPriceTierFlatPrice subscriptionPriceTierFlatPrice
    )
        : base(subscriptionPriceTierFlatPrice) { }
#pragma warning restore CS8618

    public SubscriptionPriceTierFlatPrice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionPriceTierFlatPrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionPriceTierFlatPriceFromRaw.FromRawUnchecked"/>
    public static SubscriptionPriceTierFlatPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionPriceTierFlatPriceFromRaw : IFromRawJson<SubscriptionPriceTierFlatPrice>
{
    /// <inheritdoc/>
    public SubscriptionPriceTierFlatPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionPriceTierFlatPrice.FromRawUnchecked(rawData);
}

/// <summary>
/// The price currency
/// </summary>
[JsonConverter(typeof(SubscriptionPriceTierFlatPriceCurrencyConverter))]
public enum SubscriptionPriceTierFlatPriceCurrency
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

sealed class SubscriptionPriceTierFlatPriceCurrencyConverter
    : JsonConverter<SubscriptionPriceTierFlatPriceCurrency>
{
    public override SubscriptionPriceTierFlatPriceCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => SubscriptionPriceTierFlatPriceCurrency.Usd,
            "aed" => SubscriptionPriceTierFlatPriceCurrency.Aed,
            "all" => SubscriptionPriceTierFlatPriceCurrency.All,
            "amd" => SubscriptionPriceTierFlatPriceCurrency.Amd,
            "ang" => SubscriptionPriceTierFlatPriceCurrency.Ang,
            "aud" => SubscriptionPriceTierFlatPriceCurrency.Aud,
            "awg" => SubscriptionPriceTierFlatPriceCurrency.Awg,
            "azn" => SubscriptionPriceTierFlatPriceCurrency.Azn,
            "bam" => SubscriptionPriceTierFlatPriceCurrency.Bam,
            "bbd" => SubscriptionPriceTierFlatPriceCurrency.Bbd,
            "bdt" => SubscriptionPriceTierFlatPriceCurrency.Bdt,
            "bgn" => SubscriptionPriceTierFlatPriceCurrency.Bgn,
            "bif" => SubscriptionPriceTierFlatPriceCurrency.Bif,
            "bmd" => SubscriptionPriceTierFlatPriceCurrency.Bmd,
            "bnd" => SubscriptionPriceTierFlatPriceCurrency.Bnd,
            "bsd" => SubscriptionPriceTierFlatPriceCurrency.Bsd,
            "bwp" => SubscriptionPriceTierFlatPriceCurrency.Bwp,
            "byn" => SubscriptionPriceTierFlatPriceCurrency.Byn,
            "bzd" => SubscriptionPriceTierFlatPriceCurrency.Bzd,
            "brl" => SubscriptionPriceTierFlatPriceCurrency.Brl,
            "cad" => SubscriptionPriceTierFlatPriceCurrency.Cad,
            "cdf" => SubscriptionPriceTierFlatPriceCurrency.Cdf,
            "chf" => SubscriptionPriceTierFlatPriceCurrency.Chf,
            "cny" => SubscriptionPriceTierFlatPriceCurrency.Cny,
            "czk" => SubscriptionPriceTierFlatPriceCurrency.Czk,
            "dkk" => SubscriptionPriceTierFlatPriceCurrency.Dkk,
            "dop" => SubscriptionPriceTierFlatPriceCurrency.Dop,
            "dzd" => SubscriptionPriceTierFlatPriceCurrency.Dzd,
            "egp" => SubscriptionPriceTierFlatPriceCurrency.Egp,
            "etb" => SubscriptionPriceTierFlatPriceCurrency.Etb,
            "eur" => SubscriptionPriceTierFlatPriceCurrency.Eur,
            "fjd" => SubscriptionPriceTierFlatPriceCurrency.Fjd,
            "gbp" => SubscriptionPriceTierFlatPriceCurrency.Gbp,
            "gel" => SubscriptionPriceTierFlatPriceCurrency.Gel,
            "gip" => SubscriptionPriceTierFlatPriceCurrency.Gip,
            "gmd" => SubscriptionPriceTierFlatPriceCurrency.Gmd,
            "gyd" => SubscriptionPriceTierFlatPriceCurrency.Gyd,
            "hkd" => SubscriptionPriceTierFlatPriceCurrency.Hkd,
            "hrk" => SubscriptionPriceTierFlatPriceCurrency.Hrk,
            "htg" => SubscriptionPriceTierFlatPriceCurrency.Htg,
            "idr" => SubscriptionPriceTierFlatPriceCurrency.Idr,
            "ils" => SubscriptionPriceTierFlatPriceCurrency.Ils,
            "inr" => SubscriptionPriceTierFlatPriceCurrency.Inr,
            "isk" => SubscriptionPriceTierFlatPriceCurrency.Isk,
            "jmd" => SubscriptionPriceTierFlatPriceCurrency.Jmd,
            "jpy" => SubscriptionPriceTierFlatPriceCurrency.Jpy,
            "kes" => SubscriptionPriceTierFlatPriceCurrency.Kes,
            "kgs" => SubscriptionPriceTierFlatPriceCurrency.Kgs,
            "khr" => SubscriptionPriceTierFlatPriceCurrency.Khr,
            "kmf" => SubscriptionPriceTierFlatPriceCurrency.Kmf,
            "krw" => SubscriptionPriceTierFlatPriceCurrency.Krw,
            "kyd" => SubscriptionPriceTierFlatPriceCurrency.Kyd,
            "kzt" => SubscriptionPriceTierFlatPriceCurrency.Kzt,
            "lbp" => SubscriptionPriceTierFlatPriceCurrency.Lbp,
            "lkr" => SubscriptionPriceTierFlatPriceCurrency.Lkr,
            "lrd" => SubscriptionPriceTierFlatPriceCurrency.Lrd,
            "lsl" => SubscriptionPriceTierFlatPriceCurrency.Lsl,
            "mad" => SubscriptionPriceTierFlatPriceCurrency.Mad,
            "mdl" => SubscriptionPriceTierFlatPriceCurrency.Mdl,
            "mga" => SubscriptionPriceTierFlatPriceCurrency.Mga,
            "mkd" => SubscriptionPriceTierFlatPriceCurrency.Mkd,
            "mmk" => SubscriptionPriceTierFlatPriceCurrency.Mmk,
            "mnt" => SubscriptionPriceTierFlatPriceCurrency.Mnt,
            "mop" => SubscriptionPriceTierFlatPriceCurrency.Mop,
            "mro" => SubscriptionPriceTierFlatPriceCurrency.Mro,
            "mvr" => SubscriptionPriceTierFlatPriceCurrency.Mvr,
            "mwk" => SubscriptionPriceTierFlatPriceCurrency.Mwk,
            "mxn" => SubscriptionPriceTierFlatPriceCurrency.Mxn,
            "myr" => SubscriptionPriceTierFlatPriceCurrency.Myr,
            "mzn" => SubscriptionPriceTierFlatPriceCurrency.Mzn,
            "nad" => SubscriptionPriceTierFlatPriceCurrency.Nad,
            "ngn" => SubscriptionPriceTierFlatPriceCurrency.Ngn,
            "nok" => SubscriptionPriceTierFlatPriceCurrency.Nok,
            "npr" => SubscriptionPriceTierFlatPriceCurrency.Npr,
            "nzd" => SubscriptionPriceTierFlatPriceCurrency.Nzd,
            "pgk" => SubscriptionPriceTierFlatPriceCurrency.Pgk,
            "php" => SubscriptionPriceTierFlatPriceCurrency.Php,
            "pkr" => SubscriptionPriceTierFlatPriceCurrency.Pkr,
            "pln" => SubscriptionPriceTierFlatPriceCurrency.Pln,
            "qar" => SubscriptionPriceTierFlatPriceCurrency.Qar,
            "ron" => SubscriptionPriceTierFlatPriceCurrency.Ron,
            "rsd" => SubscriptionPriceTierFlatPriceCurrency.Rsd,
            "rub" => SubscriptionPriceTierFlatPriceCurrency.Rub,
            "rwf" => SubscriptionPriceTierFlatPriceCurrency.Rwf,
            "sar" => SubscriptionPriceTierFlatPriceCurrency.Sar,
            "sbd" => SubscriptionPriceTierFlatPriceCurrency.Sbd,
            "scr" => SubscriptionPriceTierFlatPriceCurrency.Scr,
            "sek" => SubscriptionPriceTierFlatPriceCurrency.Sek,
            "sgd" => SubscriptionPriceTierFlatPriceCurrency.Sgd,
            "sle" => SubscriptionPriceTierFlatPriceCurrency.Sle,
            "sll" => SubscriptionPriceTierFlatPriceCurrency.Sll,
            "sos" => SubscriptionPriceTierFlatPriceCurrency.Sos,
            "szl" => SubscriptionPriceTierFlatPriceCurrency.Szl,
            "thb" => SubscriptionPriceTierFlatPriceCurrency.Thb,
            "tjs" => SubscriptionPriceTierFlatPriceCurrency.Tjs,
            "top" => SubscriptionPriceTierFlatPriceCurrency.Top,
            "try" => SubscriptionPriceTierFlatPriceCurrency.Try,
            "ttd" => SubscriptionPriceTierFlatPriceCurrency.Ttd,
            "tzs" => SubscriptionPriceTierFlatPriceCurrency.Tzs,
            "uah" => SubscriptionPriceTierFlatPriceCurrency.Uah,
            "uzs" => SubscriptionPriceTierFlatPriceCurrency.Uzs,
            "vnd" => SubscriptionPriceTierFlatPriceCurrency.Vnd,
            "vuv" => SubscriptionPriceTierFlatPriceCurrency.Vuv,
            "wst" => SubscriptionPriceTierFlatPriceCurrency.Wst,
            "xaf" => SubscriptionPriceTierFlatPriceCurrency.Xaf,
            "xcd" => SubscriptionPriceTierFlatPriceCurrency.Xcd,
            "yer" => SubscriptionPriceTierFlatPriceCurrency.Yer,
            "zar" => SubscriptionPriceTierFlatPriceCurrency.Zar,
            "zmw" => SubscriptionPriceTierFlatPriceCurrency.Zmw,
            "clp" => SubscriptionPriceTierFlatPriceCurrency.Clp,
            "djf" => SubscriptionPriceTierFlatPriceCurrency.Djf,
            "gnf" => SubscriptionPriceTierFlatPriceCurrency.Gnf,
            "ugx" => SubscriptionPriceTierFlatPriceCurrency.Ugx,
            "pyg" => SubscriptionPriceTierFlatPriceCurrency.Pyg,
            "xof" => SubscriptionPriceTierFlatPriceCurrency.Xof,
            "xpf" => SubscriptionPriceTierFlatPriceCurrency.Xpf,
            _ => (SubscriptionPriceTierFlatPriceCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionPriceTierFlatPriceCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionPriceTierFlatPriceCurrency.Usd => "usd",
                SubscriptionPriceTierFlatPriceCurrency.Aed => "aed",
                SubscriptionPriceTierFlatPriceCurrency.All => "all",
                SubscriptionPriceTierFlatPriceCurrency.Amd => "amd",
                SubscriptionPriceTierFlatPriceCurrency.Ang => "ang",
                SubscriptionPriceTierFlatPriceCurrency.Aud => "aud",
                SubscriptionPriceTierFlatPriceCurrency.Awg => "awg",
                SubscriptionPriceTierFlatPriceCurrency.Azn => "azn",
                SubscriptionPriceTierFlatPriceCurrency.Bam => "bam",
                SubscriptionPriceTierFlatPriceCurrency.Bbd => "bbd",
                SubscriptionPriceTierFlatPriceCurrency.Bdt => "bdt",
                SubscriptionPriceTierFlatPriceCurrency.Bgn => "bgn",
                SubscriptionPriceTierFlatPriceCurrency.Bif => "bif",
                SubscriptionPriceTierFlatPriceCurrency.Bmd => "bmd",
                SubscriptionPriceTierFlatPriceCurrency.Bnd => "bnd",
                SubscriptionPriceTierFlatPriceCurrency.Bsd => "bsd",
                SubscriptionPriceTierFlatPriceCurrency.Bwp => "bwp",
                SubscriptionPriceTierFlatPriceCurrency.Byn => "byn",
                SubscriptionPriceTierFlatPriceCurrency.Bzd => "bzd",
                SubscriptionPriceTierFlatPriceCurrency.Brl => "brl",
                SubscriptionPriceTierFlatPriceCurrency.Cad => "cad",
                SubscriptionPriceTierFlatPriceCurrency.Cdf => "cdf",
                SubscriptionPriceTierFlatPriceCurrency.Chf => "chf",
                SubscriptionPriceTierFlatPriceCurrency.Cny => "cny",
                SubscriptionPriceTierFlatPriceCurrency.Czk => "czk",
                SubscriptionPriceTierFlatPriceCurrency.Dkk => "dkk",
                SubscriptionPriceTierFlatPriceCurrency.Dop => "dop",
                SubscriptionPriceTierFlatPriceCurrency.Dzd => "dzd",
                SubscriptionPriceTierFlatPriceCurrency.Egp => "egp",
                SubscriptionPriceTierFlatPriceCurrency.Etb => "etb",
                SubscriptionPriceTierFlatPriceCurrency.Eur => "eur",
                SubscriptionPriceTierFlatPriceCurrency.Fjd => "fjd",
                SubscriptionPriceTierFlatPriceCurrency.Gbp => "gbp",
                SubscriptionPriceTierFlatPriceCurrency.Gel => "gel",
                SubscriptionPriceTierFlatPriceCurrency.Gip => "gip",
                SubscriptionPriceTierFlatPriceCurrency.Gmd => "gmd",
                SubscriptionPriceTierFlatPriceCurrency.Gyd => "gyd",
                SubscriptionPriceTierFlatPriceCurrency.Hkd => "hkd",
                SubscriptionPriceTierFlatPriceCurrency.Hrk => "hrk",
                SubscriptionPriceTierFlatPriceCurrency.Htg => "htg",
                SubscriptionPriceTierFlatPriceCurrency.Idr => "idr",
                SubscriptionPriceTierFlatPriceCurrency.Ils => "ils",
                SubscriptionPriceTierFlatPriceCurrency.Inr => "inr",
                SubscriptionPriceTierFlatPriceCurrency.Isk => "isk",
                SubscriptionPriceTierFlatPriceCurrency.Jmd => "jmd",
                SubscriptionPriceTierFlatPriceCurrency.Jpy => "jpy",
                SubscriptionPriceTierFlatPriceCurrency.Kes => "kes",
                SubscriptionPriceTierFlatPriceCurrency.Kgs => "kgs",
                SubscriptionPriceTierFlatPriceCurrency.Khr => "khr",
                SubscriptionPriceTierFlatPriceCurrency.Kmf => "kmf",
                SubscriptionPriceTierFlatPriceCurrency.Krw => "krw",
                SubscriptionPriceTierFlatPriceCurrency.Kyd => "kyd",
                SubscriptionPriceTierFlatPriceCurrency.Kzt => "kzt",
                SubscriptionPriceTierFlatPriceCurrency.Lbp => "lbp",
                SubscriptionPriceTierFlatPriceCurrency.Lkr => "lkr",
                SubscriptionPriceTierFlatPriceCurrency.Lrd => "lrd",
                SubscriptionPriceTierFlatPriceCurrency.Lsl => "lsl",
                SubscriptionPriceTierFlatPriceCurrency.Mad => "mad",
                SubscriptionPriceTierFlatPriceCurrency.Mdl => "mdl",
                SubscriptionPriceTierFlatPriceCurrency.Mga => "mga",
                SubscriptionPriceTierFlatPriceCurrency.Mkd => "mkd",
                SubscriptionPriceTierFlatPriceCurrency.Mmk => "mmk",
                SubscriptionPriceTierFlatPriceCurrency.Mnt => "mnt",
                SubscriptionPriceTierFlatPriceCurrency.Mop => "mop",
                SubscriptionPriceTierFlatPriceCurrency.Mro => "mro",
                SubscriptionPriceTierFlatPriceCurrency.Mvr => "mvr",
                SubscriptionPriceTierFlatPriceCurrency.Mwk => "mwk",
                SubscriptionPriceTierFlatPriceCurrency.Mxn => "mxn",
                SubscriptionPriceTierFlatPriceCurrency.Myr => "myr",
                SubscriptionPriceTierFlatPriceCurrency.Mzn => "mzn",
                SubscriptionPriceTierFlatPriceCurrency.Nad => "nad",
                SubscriptionPriceTierFlatPriceCurrency.Ngn => "ngn",
                SubscriptionPriceTierFlatPriceCurrency.Nok => "nok",
                SubscriptionPriceTierFlatPriceCurrency.Npr => "npr",
                SubscriptionPriceTierFlatPriceCurrency.Nzd => "nzd",
                SubscriptionPriceTierFlatPriceCurrency.Pgk => "pgk",
                SubscriptionPriceTierFlatPriceCurrency.Php => "php",
                SubscriptionPriceTierFlatPriceCurrency.Pkr => "pkr",
                SubscriptionPriceTierFlatPriceCurrency.Pln => "pln",
                SubscriptionPriceTierFlatPriceCurrency.Qar => "qar",
                SubscriptionPriceTierFlatPriceCurrency.Ron => "ron",
                SubscriptionPriceTierFlatPriceCurrency.Rsd => "rsd",
                SubscriptionPriceTierFlatPriceCurrency.Rub => "rub",
                SubscriptionPriceTierFlatPriceCurrency.Rwf => "rwf",
                SubscriptionPriceTierFlatPriceCurrency.Sar => "sar",
                SubscriptionPriceTierFlatPriceCurrency.Sbd => "sbd",
                SubscriptionPriceTierFlatPriceCurrency.Scr => "scr",
                SubscriptionPriceTierFlatPriceCurrency.Sek => "sek",
                SubscriptionPriceTierFlatPriceCurrency.Sgd => "sgd",
                SubscriptionPriceTierFlatPriceCurrency.Sle => "sle",
                SubscriptionPriceTierFlatPriceCurrency.Sll => "sll",
                SubscriptionPriceTierFlatPriceCurrency.Sos => "sos",
                SubscriptionPriceTierFlatPriceCurrency.Szl => "szl",
                SubscriptionPriceTierFlatPriceCurrency.Thb => "thb",
                SubscriptionPriceTierFlatPriceCurrency.Tjs => "tjs",
                SubscriptionPriceTierFlatPriceCurrency.Top => "top",
                SubscriptionPriceTierFlatPriceCurrency.Try => "try",
                SubscriptionPriceTierFlatPriceCurrency.Ttd => "ttd",
                SubscriptionPriceTierFlatPriceCurrency.Tzs => "tzs",
                SubscriptionPriceTierFlatPriceCurrency.Uah => "uah",
                SubscriptionPriceTierFlatPriceCurrency.Uzs => "uzs",
                SubscriptionPriceTierFlatPriceCurrency.Vnd => "vnd",
                SubscriptionPriceTierFlatPriceCurrency.Vuv => "vuv",
                SubscriptionPriceTierFlatPriceCurrency.Wst => "wst",
                SubscriptionPriceTierFlatPriceCurrency.Xaf => "xaf",
                SubscriptionPriceTierFlatPriceCurrency.Xcd => "xcd",
                SubscriptionPriceTierFlatPriceCurrency.Yer => "yer",
                SubscriptionPriceTierFlatPriceCurrency.Zar => "zar",
                SubscriptionPriceTierFlatPriceCurrency.Zmw => "zmw",
                SubscriptionPriceTierFlatPriceCurrency.Clp => "clp",
                SubscriptionPriceTierFlatPriceCurrency.Djf => "djf",
                SubscriptionPriceTierFlatPriceCurrency.Gnf => "gnf",
                SubscriptionPriceTierFlatPriceCurrency.Ugx => "ugx",
                SubscriptionPriceTierFlatPriceCurrency.Pyg => "pyg",
                SubscriptionPriceTierFlatPriceCurrency.Xof => "xof",
                SubscriptionPriceTierFlatPriceCurrency.Xpf => "xpf",
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
        SubscriptionPriceTierUnitPrice,
        SubscriptionPriceTierUnitPriceFromRaw
    >)
)]
public sealed record class SubscriptionPriceTierUnitPrice : JsonModel
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
    /// The billing country code of the price
    /// </summary>
    public string? BillingCountryCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billingCountryCode");
        }
        init { this._rawData.Set("billingCountryCode", value); }
    }

    /// <summary>
    /// The price currency
    /// </summary>
    public ApiEnum<string, SubscriptionPriceTierUnitPriceCurrency>? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, SubscriptionPriceTierUnitPriceCurrency>
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
        _ = this.BillingCountryCode;
        this.Currency?.Validate();
    }

    public SubscriptionPriceTierUnitPrice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionPriceTierUnitPrice(
        SubscriptionPriceTierUnitPrice subscriptionPriceTierUnitPrice
    )
        : base(subscriptionPriceTierUnitPrice) { }
#pragma warning restore CS8618

    public SubscriptionPriceTierUnitPrice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionPriceTierUnitPrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionPriceTierUnitPriceFromRaw.FromRawUnchecked"/>
    public static SubscriptionPriceTierUnitPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionPriceTierUnitPriceFromRaw : IFromRawJson<SubscriptionPriceTierUnitPrice>
{
    /// <inheritdoc/>
    public SubscriptionPriceTierUnitPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionPriceTierUnitPrice.FromRawUnchecked(rawData);
}

/// <summary>
/// The price currency
/// </summary>
[JsonConverter(typeof(SubscriptionPriceTierUnitPriceCurrencyConverter))]
public enum SubscriptionPriceTierUnitPriceCurrency
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

sealed class SubscriptionPriceTierUnitPriceCurrencyConverter
    : JsonConverter<SubscriptionPriceTierUnitPriceCurrency>
{
    public override SubscriptionPriceTierUnitPriceCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => SubscriptionPriceTierUnitPriceCurrency.Usd,
            "aed" => SubscriptionPriceTierUnitPriceCurrency.Aed,
            "all" => SubscriptionPriceTierUnitPriceCurrency.All,
            "amd" => SubscriptionPriceTierUnitPriceCurrency.Amd,
            "ang" => SubscriptionPriceTierUnitPriceCurrency.Ang,
            "aud" => SubscriptionPriceTierUnitPriceCurrency.Aud,
            "awg" => SubscriptionPriceTierUnitPriceCurrency.Awg,
            "azn" => SubscriptionPriceTierUnitPriceCurrency.Azn,
            "bam" => SubscriptionPriceTierUnitPriceCurrency.Bam,
            "bbd" => SubscriptionPriceTierUnitPriceCurrency.Bbd,
            "bdt" => SubscriptionPriceTierUnitPriceCurrency.Bdt,
            "bgn" => SubscriptionPriceTierUnitPriceCurrency.Bgn,
            "bif" => SubscriptionPriceTierUnitPriceCurrency.Bif,
            "bmd" => SubscriptionPriceTierUnitPriceCurrency.Bmd,
            "bnd" => SubscriptionPriceTierUnitPriceCurrency.Bnd,
            "bsd" => SubscriptionPriceTierUnitPriceCurrency.Bsd,
            "bwp" => SubscriptionPriceTierUnitPriceCurrency.Bwp,
            "byn" => SubscriptionPriceTierUnitPriceCurrency.Byn,
            "bzd" => SubscriptionPriceTierUnitPriceCurrency.Bzd,
            "brl" => SubscriptionPriceTierUnitPriceCurrency.Brl,
            "cad" => SubscriptionPriceTierUnitPriceCurrency.Cad,
            "cdf" => SubscriptionPriceTierUnitPriceCurrency.Cdf,
            "chf" => SubscriptionPriceTierUnitPriceCurrency.Chf,
            "cny" => SubscriptionPriceTierUnitPriceCurrency.Cny,
            "czk" => SubscriptionPriceTierUnitPriceCurrency.Czk,
            "dkk" => SubscriptionPriceTierUnitPriceCurrency.Dkk,
            "dop" => SubscriptionPriceTierUnitPriceCurrency.Dop,
            "dzd" => SubscriptionPriceTierUnitPriceCurrency.Dzd,
            "egp" => SubscriptionPriceTierUnitPriceCurrency.Egp,
            "etb" => SubscriptionPriceTierUnitPriceCurrency.Etb,
            "eur" => SubscriptionPriceTierUnitPriceCurrency.Eur,
            "fjd" => SubscriptionPriceTierUnitPriceCurrency.Fjd,
            "gbp" => SubscriptionPriceTierUnitPriceCurrency.Gbp,
            "gel" => SubscriptionPriceTierUnitPriceCurrency.Gel,
            "gip" => SubscriptionPriceTierUnitPriceCurrency.Gip,
            "gmd" => SubscriptionPriceTierUnitPriceCurrency.Gmd,
            "gyd" => SubscriptionPriceTierUnitPriceCurrency.Gyd,
            "hkd" => SubscriptionPriceTierUnitPriceCurrency.Hkd,
            "hrk" => SubscriptionPriceTierUnitPriceCurrency.Hrk,
            "htg" => SubscriptionPriceTierUnitPriceCurrency.Htg,
            "idr" => SubscriptionPriceTierUnitPriceCurrency.Idr,
            "ils" => SubscriptionPriceTierUnitPriceCurrency.Ils,
            "inr" => SubscriptionPriceTierUnitPriceCurrency.Inr,
            "isk" => SubscriptionPriceTierUnitPriceCurrency.Isk,
            "jmd" => SubscriptionPriceTierUnitPriceCurrency.Jmd,
            "jpy" => SubscriptionPriceTierUnitPriceCurrency.Jpy,
            "kes" => SubscriptionPriceTierUnitPriceCurrency.Kes,
            "kgs" => SubscriptionPriceTierUnitPriceCurrency.Kgs,
            "khr" => SubscriptionPriceTierUnitPriceCurrency.Khr,
            "kmf" => SubscriptionPriceTierUnitPriceCurrency.Kmf,
            "krw" => SubscriptionPriceTierUnitPriceCurrency.Krw,
            "kyd" => SubscriptionPriceTierUnitPriceCurrency.Kyd,
            "kzt" => SubscriptionPriceTierUnitPriceCurrency.Kzt,
            "lbp" => SubscriptionPriceTierUnitPriceCurrency.Lbp,
            "lkr" => SubscriptionPriceTierUnitPriceCurrency.Lkr,
            "lrd" => SubscriptionPriceTierUnitPriceCurrency.Lrd,
            "lsl" => SubscriptionPriceTierUnitPriceCurrency.Lsl,
            "mad" => SubscriptionPriceTierUnitPriceCurrency.Mad,
            "mdl" => SubscriptionPriceTierUnitPriceCurrency.Mdl,
            "mga" => SubscriptionPriceTierUnitPriceCurrency.Mga,
            "mkd" => SubscriptionPriceTierUnitPriceCurrency.Mkd,
            "mmk" => SubscriptionPriceTierUnitPriceCurrency.Mmk,
            "mnt" => SubscriptionPriceTierUnitPriceCurrency.Mnt,
            "mop" => SubscriptionPriceTierUnitPriceCurrency.Mop,
            "mro" => SubscriptionPriceTierUnitPriceCurrency.Mro,
            "mvr" => SubscriptionPriceTierUnitPriceCurrency.Mvr,
            "mwk" => SubscriptionPriceTierUnitPriceCurrency.Mwk,
            "mxn" => SubscriptionPriceTierUnitPriceCurrency.Mxn,
            "myr" => SubscriptionPriceTierUnitPriceCurrency.Myr,
            "mzn" => SubscriptionPriceTierUnitPriceCurrency.Mzn,
            "nad" => SubscriptionPriceTierUnitPriceCurrency.Nad,
            "ngn" => SubscriptionPriceTierUnitPriceCurrency.Ngn,
            "nok" => SubscriptionPriceTierUnitPriceCurrency.Nok,
            "npr" => SubscriptionPriceTierUnitPriceCurrency.Npr,
            "nzd" => SubscriptionPriceTierUnitPriceCurrency.Nzd,
            "pgk" => SubscriptionPriceTierUnitPriceCurrency.Pgk,
            "php" => SubscriptionPriceTierUnitPriceCurrency.Php,
            "pkr" => SubscriptionPriceTierUnitPriceCurrency.Pkr,
            "pln" => SubscriptionPriceTierUnitPriceCurrency.Pln,
            "qar" => SubscriptionPriceTierUnitPriceCurrency.Qar,
            "ron" => SubscriptionPriceTierUnitPriceCurrency.Ron,
            "rsd" => SubscriptionPriceTierUnitPriceCurrency.Rsd,
            "rub" => SubscriptionPriceTierUnitPriceCurrency.Rub,
            "rwf" => SubscriptionPriceTierUnitPriceCurrency.Rwf,
            "sar" => SubscriptionPriceTierUnitPriceCurrency.Sar,
            "sbd" => SubscriptionPriceTierUnitPriceCurrency.Sbd,
            "scr" => SubscriptionPriceTierUnitPriceCurrency.Scr,
            "sek" => SubscriptionPriceTierUnitPriceCurrency.Sek,
            "sgd" => SubscriptionPriceTierUnitPriceCurrency.Sgd,
            "sle" => SubscriptionPriceTierUnitPriceCurrency.Sle,
            "sll" => SubscriptionPriceTierUnitPriceCurrency.Sll,
            "sos" => SubscriptionPriceTierUnitPriceCurrency.Sos,
            "szl" => SubscriptionPriceTierUnitPriceCurrency.Szl,
            "thb" => SubscriptionPriceTierUnitPriceCurrency.Thb,
            "tjs" => SubscriptionPriceTierUnitPriceCurrency.Tjs,
            "top" => SubscriptionPriceTierUnitPriceCurrency.Top,
            "try" => SubscriptionPriceTierUnitPriceCurrency.Try,
            "ttd" => SubscriptionPriceTierUnitPriceCurrency.Ttd,
            "tzs" => SubscriptionPriceTierUnitPriceCurrency.Tzs,
            "uah" => SubscriptionPriceTierUnitPriceCurrency.Uah,
            "uzs" => SubscriptionPriceTierUnitPriceCurrency.Uzs,
            "vnd" => SubscriptionPriceTierUnitPriceCurrency.Vnd,
            "vuv" => SubscriptionPriceTierUnitPriceCurrency.Vuv,
            "wst" => SubscriptionPriceTierUnitPriceCurrency.Wst,
            "xaf" => SubscriptionPriceTierUnitPriceCurrency.Xaf,
            "xcd" => SubscriptionPriceTierUnitPriceCurrency.Xcd,
            "yer" => SubscriptionPriceTierUnitPriceCurrency.Yer,
            "zar" => SubscriptionPriceTierUnitPriceCurrency.Zar,
            "zmw" => SubscriptionPriceTierUnitPriceCurrency.Zmw,
            "clp" => SubscriptionPriceTierUnitPriceCurrency.Clp,
            "djf" => SubscriptionPriceTierUnitPriceCurrency.Djf,
            "gnf" => SubscriptionPriceTierUnitPriceCurrency.Gnf,
            "ugx" => SubscriptionPriceTierUnitPriceCurrency.Ugx,
            "pyg" => SubscriptionPriceTierUnitPriceCurrency.Pyg,
            "xof" => SubscriptionPriceTierUnitPriceCurrency.Xof,
            "xpf" => SubscriptionPriceTierUnitPriceCurrency.Xpf,
            _ => (SubscriptionPriceTierUnitPriceCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionPriceTierUnitPriceCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionPriceTierUnitPriceCurrency.Usd => "usd",
                SubscriptionPriceTierUnitPriceCurrency.Aed => "aed",
                SubscriptionPriceTierUnitPriceCurrency.All => "all",
                SubscriptionPriceTierUnitPriceCurrency.Amd => "amd",
                SubscriptionPriceTierUnitPriceCurrency.Ang => "ang",
                SubscriptionPriceTierUnitPriceCurrency.Aud => "aud",
                SubscriptionPriceTierUnitPriceCurrency.Awg => "awg",
                SubscriptionPriceTierUnitPriceCurrency.Azn => "azn",
                SubscriptionPriceTierUnitPriceCurrency.Bam => "bam",
                SubscriptionPriceTierUnitPriceCurrency.Bbd => "bbd",
                SubscriptionPriceTierUnitPriceCurrency.Bdt => "bdt",
                SubscriptionPriceTierUnitPriceCurrency.Bgn => "bgn",
                SubscriptionPriceTierUnitPriceCurrency.Bif => "bif",
                SubscriptionPriceTierUnitPriceCurrency.Bmd => "bmd",
                SubscriptionPriceTierUnitPriceCurrency.Bnd => "bnd",
                SubscriptionPriceTierUnitPriceCurrency.Bsd => "bsd",
                SubscriptionPriceTierUnitPriceCurrency.Bwp => "bwp",
                SubscriptionPriceTierUnitPriceCurrency.Byn => "byn",
                SubscriptionPriceTierUnitPriceCurrency.Bzd => "bzd",
                SubscriptionPriceTierUnitPriceCurrency.Brl => "brl",
                SubscriptionPriceTierUnitPriceCurrency.Cad => "cad",
                SubscriptionPriceTierUnitPriceCurrency.Cdf => "cdf",
                SubscriptionPriceTierUnitPriceCurrency.Chf => "chf",
                SubscriptionPriceTierUnitPriceCurrency.Cny => "cny",
                SubscriptionPriceTierUnitPriceCurrency.Czk => "czk",
                SubscriptionPriceTierUnitPriceCurrency.Dkk => "dkk",
                SubscriptionPriceTierUnitPriceCurrency.Dop => "dop",
                SubscriptionPriceTierUnitPriceCurrency.Dzd => "dzd",
                SubscriptionPriceTierUnitPriceCurrency.Egp => "egp",
                SubscriptionPriceTierUnitPriceCurrency.Etb => "etb",
                SubscriptionPriceTierUnitPriceCurrency.Eur => "eur",
                SubscriptionPriceTierUnitPriceCurrency.Fjd => "fjd",
                SubscriptionPriceTierUnitPriceCurrency.Gbp => "gbp",
                SubscriptionPriceTierUnitPriceCurrency.Gel => "gel",
                SubscriptionPriceTierUnitPriceCurrency.Gip => "gip",
                SubscriptionPriceTierUnitPriceCurrency.Gmd => "gmd",
                SubscriptionPriceTierUnitPriceCurrency.Gyd => "gyd",
                SubscriptionPriceTierUnitPriceCurrency.Hkd => "hkd",
                SubscriptionPriceTierUnitPriceCurrency.Hrk => "hrk",
                SubscriptionPriceTierUnitPriceCurrency.Htg => "htg",
                SubscriptionPriceTierUnitPriceCurrency.Idr => "idr",
                SubscriptionPriceTierUnitPriceCurrency.Ils => "ils",
                SubscriptionPriceTierUnitPriceCurrency.Inr => "inr",
                SubscriptionPriceTierUnitPriceCurrency.Isk => "isk",
                SubscriptionPriceTierUnitPriceCurrency.Jmd => "jmd",
                SubscriptionPriceTierUnitPriceCurrency.Jpy => "jpy",
                SubscriptionPriceTierUnitPriceCurrency.Kes => "kes",
                SubscriptionPriceTierUnitPriceCurrency.Kgs => "kgs",
                SubscriptionPriceTierUnitPriceCurrency.Khr => "khr",
                SubscriptionPriceTierUnitPriceCurrency.Kmf => "kmf",
                SubscriptionPriceTierUnitPriceCurrency.Krw => "krw",
                SubscriptionPriceTierUnitPriceCurrency.Kyd => "kyd",
                SubscriptionPriceTierUnitPriceCurrency.Kzt => "kzt",
                SubscriptionPriceTierUnitPriceCurrency.Lbp => "lbp",
                SubscriptionPriceTierUnitPriceCurrency.Lkr => "lkr",
                SubscriptionPriceTierUnitPriceCurrency.Lrd => "lrd",
                SubscriptionPriceTierUnitPriceCurrency.Lsl => "lsl",
                SubscriptionPriceTierUnitPriceCurrency.Mad => "mad",
                SubscriptionPriceTierUnitPriceCurrency.Mdl => "mdl",
                SubscriptionPriceTierUnitPriceCurrency.Mga => "mga",
                SubscriptionPriceTierUnitPriceCurrency.Mkd => "mkd",
                SubscriptionPriceTierUnitPriceCurrency.Mmk => "mmk",
                SubscriptionPriceTierUnitPriceCurrency.Mnt => "mnt",
                SubscriptionPriceTierUnitPriceCurrency.Mop => "mop",
                SubscriptionPriceTierUnitPriceCurrency.Mro => "mro",
                SubscriptionPriceTierUnitPriceCurrency.Mvr => "mvr",
                SubscriptionPriceTierUnitPriceCurrency.Mwk => "mwk",
                SubscriptionPriceTierUnitPriceCurrency.Mxn => "mxn",
                SubscriptionPriceTierUnitPriceCurrency.Myr => "myr",
                SubscriptionPriceTierUnitPriceCurrency.Mzn => "mzn",
                SubscriptionPriceTierUnitPriceCurrency.Nad => "nad",
                SubscriptionPriceTierUnitPriceCurrency.Ngn => "ngn",
                SubscriptionPriceTierUnitPriceCurrency.Nok => "nok",
                SubscriptionPriceTierUnitPriceCurrency.Npr => "npr",
                SubscriptionPriceTierUnitPriceCurrency.Nzd => "nzd",
                SubscriptionPriceTierUnitPriceCurrency.Pgk => "pgk",
                SubscriptionPriceTierUnitPriceCurrency.Php => "php",
                SubscriptionPriceTierUnitPriceCurrency.Pkr => "pkr",
                SubscriptionPriceTierUnitPriceCurrency.Pln => "pln",
                SubscriptionPriceTierUnitPriceCurrency.Qar => "qar",
                SubscriptionPriceTierUnitPriceCurrency.Ron => "ron",
                SubscriptionPriceTierUnitPriceCurrency.Rsd => "rsd",
                SubscriptionPriceTierUnitPriceCurrency.Rub => "rub",
                SubscriptionPriceTierUnitPriceCurrency.Rwf => "rwf",
                SubscriptionPriceTierUnitPriceCurrency.Sar => "sar",
                SubscriptionPriceTierUnitPriceCurrency.Sbd => "sbd",
                SubscriptionPriceTierUnitPriceCurrency.Scr => "scr",
                SubscriptionPriceTierUnitPriceCurrency.Sek => "sek",
                SubscriptionPriceTierUnitPriceCurrency.Sgd => "sgd",
                SubscriptionPriceTierUnitPriceCurrency.Sle => "sle",
                SubscriptionPriceTierUnitPriceCurrency.Sll => "sll",
                SubscriptionPriceTierUnitPriceCurrency.Sos => "sos",
                SubscriptionPriceTierUnitPriceCurrency.Szl => "szl",
                SubscriptionPriceTierUnitPriceCurrency.Thb => "thb",
                SubscriptionPriceTierUnitPriceCurrency.Tjs => "tjs",
                SubscriptionPriceTierUnitPriceCurrency.Top => "top",
                SubscriptionPriceTierUnitPriceCurrency.Try => "try",
                SubscriptionPriceTierUnitPriceCurrency.Ttd => "ttd",
                SubscriptionPriceTierUnitPriceCurrency.Tzs => "tzs",
                SubscriptionPriceTierUnitPriceCurrency.Uah => "uah",
                SubscriptionPriceTierUnitPriceCurrency.Uzs => "uzs",
                SubscriptionPriceTierUnitPriceCurrency.Vnd => "vnd",
                SubscriptionPriceTierUnitPriceCurrency.Vuv => "vuv",
                SubscriptionPriceTierUnitPriceCurrency.Wst => "wst",
                SubscriptionPriceTierUnitPriceCurrency.Xaf => "xaf",
                SubscriptionPriceTierUnitPriceCurrency.Xcd => "xcd",
                SubscriptionPriceTierUnitPriceCurrency.Yer => "yer",
                SubscriptionPriceTierUnitPriceCurrency.Zar => "zar",
                SubscriptionPriceTierUnitPriceCurrency.Zmw => "zmw",
                SubscriptionPriceTierUnitPriceCurrency.Clp => "clp",
                SubscriptionPriceTierUnitPriceCurrency.Djf => "djf",
                SubscriptionPriceTierUnitPriceCurrency.Gnf => "gnf",
                SubscriptionPriceTierUnitPriceCurrency.Ugx => "ugx",
                SubscriptionPriceTierUnitPriceCurrency.Pyg => "pyg",
                SubscriptionPriceTierUnitPriceCurrency.Xof => "xof",
                SubscriptionPriceTierUnitPriceCurrency.Xpf => "xpf",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
