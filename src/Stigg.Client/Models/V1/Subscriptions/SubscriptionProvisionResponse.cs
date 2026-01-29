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
    typeof(JsonModelConverter<SubscriptionProvisionResponse, SubscriptionProvisionResponseFromRaw>)
)]
public sealed record class SubscriptionProvisionResponse : JsonModel
{
    /// <summary>
    /// Provisioning result with status and subscription or checkout URL.
    /// </summary>
    public required SubscriptionProvisionResponseData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<SubscriptionProvisionResponseData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public SubscriptionProvisionResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionProvisionResponse(
        SubscriptionProvisionResponse subscriptionProvisionResponse
    )
        : base(subscriptionProvisionResponse) { }
#pragma warning restore CS8618

    public SubscriptionProvisionResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionProvisionResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionProvisionResponseFromRaw.FromRawUnchecked"/>
    public static SubscriptionProvisionResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SubscriptionProvisionResponse(SubscriptionProvisionResponseData data)
        : this()
    {
        this.Data = data;
    }
}

class SubscriptionProvisionResponseFromRaw : IFromRawJson<SubscriptionProvisionResponse>
{
    /// <inheritdoc/>
    public SubscriptionProvisionResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionProvisionResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Provisioning result with status and subscription or checkout URL.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionProvisionResponseData,
        SubscriptionProvisionResponseDataFromRaw
    >)
)]
public sealed record class SubscriptionProvisionResponseData : JsonModel
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
    public required ApiEnum<string, SubscriptionProvisionResponseDataStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, SubscriptionProvisionResponseDataStatus>
            >("status");
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

    /// <summary>
    /// Created subscription (when status is SUCCESS)
    /// </summary>
    public SubscriptionProvisionResponseDataSubscription? Subscription
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SubscriptionProvisionResponseDataSubscription>(
                "subscription"
            );
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

    public SubscriptionProvisionResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionProvisionResponseData(
        SubscriptionProvisionResponseData subscriptionProvisionResponseData
    )
        : base(subscriptionProvisionResponseData) { }
#pragma warning restore CS8618

    public SubscriptionProvisionResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionProvisionResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionProvisionResponseDataFromRaw.FromRawUnchecked"/>
    public static SubscriptionProvisionResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionProvisionResponseDataFromRaw : IFromRawJson<SubscriptionProvisionResponseData>
{
    /// <inheritdoc/>
    public SubscriptionProvisionResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionProvisionResponseData.FromRawUnchecked(rawData);
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

    public ApiEnum<string, EntitlementResetPeriod>? ResetPeriod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, EntitlementResetPeriod>>(
                "resetPeriod"
            );
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
    /// <summary>
    /// Feature ID
    /// </summary>
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

[JsonConverter(typeof(EntitlementResetPeriodConverter))]
public enum EntitlementResetPeriod
{
    Year,
    Month,
    Week,
    Day,
    Hour,
}

sealed class EntitlementResetPeriodConverter : JsonConverter<EntitlementResetPeriod>
{
    public override EntitlementResetPeriod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "YEAR" => EntitlementResetPeriod.Year,
            "MONTH" => EntitlementResetPeriod.Month,
            "WEEK" => EntitlementResetPeriod.Week,
            "DAY" => EntitlementResetPeriod.Day,
            "HOUR" => EntitlementResetPeriod.Hour,
            _ => (EntitlementResetPeriod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntitlementResetPeriod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntitlementResetPeriod.Year => "YEAR",
                EntitlementResetPeriod.Month => "MONTH",
                EntitlementResetPeriod.Week => "WEEK",
                EntitlementResetPeriod.Day => "DAY",
                EntitlementResetPeriod.Hour => "HOUR",
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
[JsonConverter(typeof(SubscriptionProvisionResponseDataStatusConverter))]
public enum SubscriptionProvisionResponseDataStatus
{
    Success,
    PaymentRequired,
}

sealed class SubscriptionProvisionResponseDataStatusConverter
    : JsonConverter<SubscriptionProvisionResponseDataStatus>
{
    public override SubscriptionProvisionResponseDataStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SUCCESS" => SubscriptionProvisionResponseDataStatus.Success,
            "PAYMENT_REQUIRED" => SubscriptionProvisionResponseDataStatus.PaymentRequired,
            _ => (SubscriptionProvisionResponseDataStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionProvisionResponseDataStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionProvisionResponseDataStatus.Success => "SUCCESS",
                SubscriptionProvisionResponseDataStatus.PaymentRequired => "PAYMENT_REQUIRED",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Created subscription (when status is SUCCESS)
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionProvisionResponseDataSubscription,
        SubscriptionProvisionResponseDataSubscriptionFromRaw
    >)
)]
public sealed record class SubscriptionProvisionResponseDataSubscription : JsonModel
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
        SubscriptionProvisionResponseDataSubscriptionPaymentCollection
    > PaymentCollection
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionPaymentCollection>
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
    public required ApiEnum<
        string,
        SubscriptionProvisionResponseDataSubscriptionPricingType
    > PricingType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionPricingType>
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
    public required ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionStatus>
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
    public ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionCancelReason>? CancelReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionCancelReason>
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
        SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod
    >? PaymentCollectionMethod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<
                    string,
                    SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod
                >
            >("paymentCollectionMethod");
        }
        init { this._rawData.Set("paymentCollectionMethod", value); }
    }

    public IReadOnlyList<SubscriptionProvisionResponseDataSubscriptionPrice>? Prices
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<SubscriptionProvisionResponseDataSubscriptionPrice>
            >("prices");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<SubscriptionProvisionResponseDataSubscriptionPrice>?>(
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

    public SubscriptionProvisionResponseDataSubscription() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionProvisionResponseDataSubscription(
        SubscriptionProvisionResponseDataSubscription subscriptionProvisionResponseDataSubscription
    )
        : base(subscriptionProvisionResponseDataSubscription) { }
#pragma warning restore CS8618

    public SubscriptionProvisionResponseDataSubscription(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionProvisionResponseDataSubscription(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionProvisionResponseDataSubscriptionFromRaw.FromRawUnchecked"/>
    public static SubscriptionProvisionResponseDataSubscription FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionProvisionResponseDataSubscriptionFromRaw
    : IFromRawJson<SubscriptionProvisionResponseDataSubscription>
{
    /// <inheritdoc/>
    public SubscriptionProvisionResponseDataSubscription FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionProvisionResponseDataSubscription.FromRawUnchecked(rawData);
}

/// <summary>
/// Payment collection
/// </summary>
[JsonConverter(typeof(SubscriptionProvisionResponseDataSubscriptionPaymentCollectionConverter))]
public enum SubscriptionProvisionResponseDataSubscriptionPaymentCollection
{
    NotRequired,
    Processing,
    Failed,
    ActionRequired,
}

sealed class SubscriptionProvisionResponseDataSubscriptionPaymentCollectionConverter
    : JsonConverter<SubscriptionProvisionResponseDataSubscriptionPaymentCollection>
{
    public override SubscriptionProvisionResponseDataSubscriptionPaymentCollection Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "NOT_REQUIRED" =>
                SubscriptionProvisionResponseDataSubscriptionPaymentCollection.NotRequired,
            "PROCESSING" =>
                SubscriptionProvisionResponseDataSubscriptionPaymentCollection.Processing,
            "FAILED" => SubscriptionProvisionResponseDataSubscriptionPaymentCollection.Failed,
            "ACTION_REQUIRED" =>
                SubscriptionProvisionResponseDataSubscriptionPaymentCollection.ActionRequired,
            _ => (SubscriptionProvisionResponseDataSubscriptionPaymentCollection)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionProvisionResponseDataSubscriptionPaymentCollection value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionProvisionResponseDataSubscriptionPaymentCollection.NotRequired =>
                    "NOT_REQUIRED",
                SubscriptionProvisionResponseDataSubscriptionPaymentCollection.Processing =>
                    "PROCESSING",
                SubscriptionProvisionResponseDataSubscriptionPaymentCollection.Failed => "FAILED",
                SubscriptionProvisionResponseDataSubscriptionPaymentCollection.ActionRequired =>
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
[JsonConverter(typeof(SubscriptionProvisionResponseDataSubscriptionPricingTypeConverter))]
public enum SubscriptionProvisionResponseDataSubscriptionPricingType
{
    Free,
    Paid,
    Custom,
}

sealed class SubscriptionProvisionResponseDataSubscriptionPricingTypeConverter
    : JsonConverter<SubscriptionProvisionResponseDataSubscriptionPricingType>
{
    public override SubscriptionProvisionResponseDataSubscriptionPricingType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FREE" => SubscriptionProvisionResponseDataSubscriptionPricingType.Free,
            "PAID" => SubscriptionProvisionResponseDataSubscriptionPricingType.Paid,
            "CUSTOM" => SubscriptionProvisionResponseDataSubscriptionPricingType.Custom,
            _ => (SubscriptionProvisionResponseDataSubscriptionPricingType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionProvisionResponseDataSubscriptionPricingType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionProvisionResponseDataSubscriptionPricingType.Free => "FREE",
                SubscriptionProvisionResponseDataSubscriptionPricingType.Paid => "PAID",
                SubscriptionProvisionResponseDataSubscriptionPricingType.Custom => "CUSTOM",
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
[JsonConverter(typeof(SubscriptionProvisionResponseDataSubscriptionStatusConverter))]
public enum SubscriptionProvisionResponseDataSubscriptionStatus
{
    PaymentPending,
    Active,
    Expired,
    InTrial,
    Canceled,
    NotStarted,
}

sealed class SubscriptionProvisionResponseDataSubscriptionStatusConverter
    : JsonConverter<SubscriptionProvisionResponseDataSubscriptionStatus>
{
    public override SubscriptionProvisionResponseDataSubscriptionStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PAYMENT_PENDING" => SubscriptionProvisionResponseDataSubscriptionStatus.PaymentPending,
            "ACTIVE" => SubscriptionProvisionResponseDataSubscriptionStatus.Active,
            "EXPIRED" => SubscriptionProvisionResponseDataSubscriptionStatus.Expired,
            "IN_TRIAL" => SubscriptionProvisionResponseDataSubscriptionStatus.InTrial,
            "CANCELED" => SubscriptionProvisionResponseDataSubscriptionStatus.Canceled,
            "NOT_STARTED" => SubscriptionProvisionResponseDataSubscriptionStatus.NotStarted,
            _ => (SubscriptionProvisionResponseDataSubscriptionStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionProvisionResponseDataSubscriptionStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionProvisionResponseDataSubscriptionStatus.PaymentPending =>
                    "PAYMENT_PENDING",
                SubscriptionProvisionResponseDataSubscriptionStatus.Active => "ACTIVE",
                SubscriptionProvisionResponseDataSubscriptionStatus.Expired => "EXPIRED",
                SubscriptionProvisionResponseDataSubscriptionStatus.InTrial => "IN_TRIAL",
                SubscriptionProvisionResponseDataSubscriptionStatus.Canceled => "CANCELED",
                SubscriptionProvisionResponseDataSubscriptionStatus.NotStarted => "NOT_STARTED",
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
[JsonConverter(typeof(SubscriptionProvisionResponseDataSubscriptionCancelReasonConverter))]
public enum SubscriptionProvisionResponseDataSubscriptionCancelReason
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

sealed class SubscriptionProvisionResponseDataSubscriptionCancelReasonConverter
    : JsonConverter<SubscriptionProvisionResponseDataSubscriptionCancelReason>
{
    public override SubscriptionProvisionResponseDataSubscriptionCancelReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "UPGRADE_OR_DOWNGRADE" =>
                SubscriptionProvisionResponseDataSubscriptionCancelReason.UpgradeOrDowngrade,
            "CANCELLED_BY_BILLING" =>
                SubscriptionProvisionResponseDataSubscriptionCancelReason.CancelledByBilling,
            "EXPIRED" => SubscriptionProvisionResponseDataSubscriptionCancelReason.Expired,
            "DETACH_BILLING" =>
                SubscriptionProvisionResponseDataSubscriptionCancelReason.DetachBilling,
            "TRIAL_ENDED" => SubscriptionProvisionResponseDataSubscriptionCancelReason.TrialEnded,
            "Immediate" => SubscriptionProvisionResponseDataSubscriptionCancelReason.Immediate,
            "TRIAL_CONVERTED" =>
                SubscriptionProvisionResponseDataSubscriptionCancelReason.TrialConverted,
            "PENDING_PAYMENT_EXPIRED" =>
                SubscriptionProvisionResponseDataSubscriptionCancelReason.PendingPaymentExpired,
            "ScheduledCancellation" =>
                SubscriptionProvisionResponseDataSubscriptionCancelReason.ScheduledCancellation,
            "CustomerArchived" =>
                SubscriptionProvisionResponseDataSubscriptionCancelReason.CustomerArchived,
            "AutoCancellationRule" =>
                SubscriptionProvisionResponseDataSubscriptionCancelReason.AutoCancellationRule,
            _ => (SubscriptionProvisionResponseDataSubscriptionCancelReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionProvisionResponseDataSubscriptionCancelReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionProvisionResponseDataSubscriptionCancelReason.UpgradeOrDowngrade =>
                    "UPGRADE_OR_DOWNGRADE",
                SubscriptionProvisionResponseDataSubscriptionCancelReason.CancelledByBilling =>
                    "CANCELLED_BY_BILLING",
                SubscriptionProvisionResponseDataSubscriptionCancelReason.Expired => "EXPIRED",
                SubscriptionProvisionResponseDataSubscriptionCancelReason.DetachBilling =>
                    "DETACH_BILLING",
                SubscriptionProvisionResponseDataSubscriptionCancelReason.TrialEnded =>
                    "TRIAL_ENDED",
                SubscriptionProvisionResponseDataSubscriptionCancelReason.Immediate => "Immediate",
                SubscriptionProvisionResponseDataSubscriptionCancelReason.TrialConverted =>
                    "TRIAL_CONVERTED",
                SubscriptionProvisionResponseDataSubscriptionCancelReason.PendingPaymentExpired =>
                    "PENDING_PAYMENT_EXPIRED",
                SubscriptionProvisionResponseDataSubscriptionCancelReason.ScheduledCancellation =>
                    "ScheduledCancellation",
                SubscriptionProvisionResponseDataSubscriptionCancelReason.CustomerArchived =>
                    "CustomerArchived",
                SubscriptionProvisionResponseDataSubscriptionCancelReason.AutoCancellationRule =>
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
[JsonConverter(
    typeof(SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethodConverter)
)]
public enum SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod
{
    Charge,
    Invoice,
    None,
}

sealed class SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethodConverter
    : JsonConverter<SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod>
{
    public override SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "CHARGE" => SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.Charge,
            "INVOICE" =>
                SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.Invoice,
            "NONE" => SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.None,
            _ => (SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.Charge =>
                    "CHARGE",
                SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.Invoice =>
                    "INVOICE",
                SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.None => "NONE",
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
        SubscriptionProvisionResponseDataSubscriptionPrice,
        SubscriptionProvisionResponseDataSubscriptionPriceFromRaw
    >)
)]
public sealed record class SubscriptionProvisionResponseDataSubscriptionPrice : JsonModel
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
    public SubscriptionProvisionResponseDataSubscriptionPricePrice? Price
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SubscriptionProvisionResponseDataSubscriptionPricePrice>(
                "price"
            );
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
    public IReadOnlyList<SubscriptionProvisionResponseDataSubscriptionPriceTier>? Tiers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<SubscriptionProvisionResponseDataSubscriptionPriceTier>
            >("tiers");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<SubscriptionProvisionResponseDataSubscriptionPriceTier>?>(
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

    public SubscriptionProvisionResponseDataSubscriptionPrice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionProvisionResponseDataSubscriptionPrice(
        SubscriptionProvisionResponseDataSubscriptionPrice subscriptionProvisionResponseDataSubscriptionPrice
    )
        : base(subscriptionProvisionResponseDataSubscriptionPrice) { }
#pragma warning restore CS8618

    public SubscriptionProvisionResponseDataSubscriptionPrice(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionProvisionResponseDataSubscriptionPrice(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionProvisionResponseDataSubscriptionPriceFromRaw.FromRawUnchecked"/>
    public static SubscriptionProvisionResponseDataSubscriptionPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionProvisionResponseDataSubscriptionPriceFromRaw
    : IFromRawJson<SubscriptionProvisionResponseDataSubscriptionPrice>
{
    /// <inheritdoc/>
    public SubscriptionProvisionResponseDataSubscriptionPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionProvisionResponseDataSubscriptionPrice.FromRawUnchecked(rawData);
}

/// <summary>
/// Override price amount
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionProvisionResponseDataSubscriptionPricePrice,
        SubscriptionProvisionResponseDataSubscriptionPricePriceFromRaw
    >)
)]
public sealed record class SubscriptionProvisionResponseDataSubscriptionPricePrice : JsonModel
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
    public ApiEnum<
        string,
        SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency
    >? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency>
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

    public SubscriptionProvisionResponseDataSubscriptionPricePrice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionProvisionResponseDataSubscriptionPricePrice(
        SubscriptionProvisionResponseDataSubscriptionPricePrice subscriptionProvisionResponseDataSubscriptionPricePrice
    )
        : base(subscriptionProvisionResponseDataSubscriptionPricePrice) { }
#pragma warning restore CS8618

    public SubscriptionProvisionResponseDataSubscriptionPricePrice(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionProvisionResponseDataSubscriptionPricePrice(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionProvisionResponseDataSubscriptionPricePriceFromRaw.FromRawUnchecked"/>
    public static SubscriptionProvisionResponseDataSubscriptionPricePrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionProvisionResponseDataSubscriptionPricePriceFromRaw
    : IFromRawJson<SubscriptionProvisionResponseDataSubscriptionPricePrice>
{
    /// <inheritdoc/>
    public SubscriptionProvisionResponseDataSubscriptionPricePrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionProvisionResponseDataSubscriptionPricePrice.FromRawUnchecked(rawData);
}

/// <summary>
/// The price currency
/// </summary>
[JsonConverter(typeof(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrencyConverter))]
public enum SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency
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

sealed class SubscriptionProvisionResponseDataSubscriptionPricePriceCurrencyConverter
    : JsonConverter<SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency>
{
    public override SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Usd,
            "aed" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Aed,
            "all" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.All,
            "amd" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Amd,
            "ang" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Ang,
            "aud" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Aud,
            "awg" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Awg,
            "azn" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Azn,
            "bam" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Bam,
            "bbd" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Bbd,
            "bdt" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Bdt,
            "bgn" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Bgn,
            "bif" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Bif,
            "bmd" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Bmd,
            "bnd" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Bnd,
            "bsd" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Bsd,
            "bwp" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Bwp,
            "byn" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Byn,
            "bzd" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Bzd,
            "brl" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Brl,
            "cad" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Cad,
            "cdf" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Cdf,
            "chf" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Chf,
            "cny" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Cny,
            "czk" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Czk,
            "dkk" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Dkk,
            "dop" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Dop,
            "dzd" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Dzd,
            "egp" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Egp,
            "etb" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Etb,
            "eur" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Eur,
            "fjd" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Fjd,
            "gbp" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Gbp,
            "gel" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Gel,
            "gip" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Gip,
            "gmd" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Gmd,
            "gyd" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Gyd,
            "hkd" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Hkd,
            "hrk" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Hrk,
            "htg" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Htg,
            "idr" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Idr,
            "ils" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Ils,
            "inr" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Inr,
            "isk" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Isk,
            "jmd" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Jmd,
            "jpy" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Jpy,
            "kes" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Kes,
            "kgs" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Kgs,
            "khr" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Khr,
            "kmf" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Kmf,
            "krw" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Krw,
            "kyd" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Kyd,
            "kzt" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Kzt,
            "lbp" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Lbp,
            "lkr" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Lkr,
            "lrd" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Lrd,
            "lsl" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Lsl,
            "mad" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Mad,
            "mdl" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Mdl,
            "mga" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Mga,
            "mkd" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Mkd,
            "mmk" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Mmk,
            "mnt" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Mnt,
            "mop" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Mop,
            "mro" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Mro,
            "mvr" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Mvr,
            "mwk" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Mwk,
            "mxn" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Mxn,
            "myr" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Myr,
            "mzn" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Mzn,
            "nad" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Nad,
            "ngn" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Ngn,
            "nok" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Nok,
            "npr" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Npr,
            "nzd" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Nzd,
            "pgk" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Pgk,
            "php" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Php,
            "pkr" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Pkr,
            "pln" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Pln,
            "qar" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Qar,
            "ron" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Ron,
            "rsd" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Rsd,
            "rub" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Rub,
            "rwf" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Rwf,
            "sar" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Sar,
            "sbd" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Sbd,
            "scr" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Scr,
            "sek" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Sek,
            "sgd" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Sgd,
            "sle" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Sle,
            "sll" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Sll,
            "sos" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Sos,
            "szl" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Szl,
            "thb" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Thb,
            "tjs" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Tjs,
            "top" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Top,
            "try" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Try,
            "ttd" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Ttd,
            "tzs" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Tzs,
            "uah" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Uah,
            "uzs" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Uzs,
            "vnd" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Vnd,
            "vuv" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Vuv,
            "wst" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Wst,
            "xaf" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Xaf,
            "xcd" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Xcd,
            "yer" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Yer,
            "zar" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Zar,
            "zmw" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Zmw,
            "clp" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Clp,
            "djf" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Djf,
            "gnf" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Gnf,
            "ugx" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Ugx,
            "pyg" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Pyg,
            "xof" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Xof,
            "xpf" => SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Xpf,
            _ => (SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Usd => "usd",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Aed => "aed",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.All => "all",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Amd => "amd",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Ang => "ang",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Aud => "aud",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Awg => "awg",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Azn => "azn",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Bam => "bam",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Bbd => "bbd",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Bdt => "bdt",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Bgn => "bgn",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Bif => "bif",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Bmd => "bmd",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Bnd => "bnd",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Bsd => "bsd",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Bwp => "bwp",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Byn => "byn",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Bzd => "bzd",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Brl => "brl",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Cad => "cad",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Cdf => "cdf",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Chf => "chf",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Cny => "cny",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Czk => "czk",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Dkk => "dkk",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Dop => "dop",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Dzd => "dzd",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Egp => "egp",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Etb => "etb",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Eur => "eur",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Fjd => "fjd",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Gbp => "gbp",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Gel => "gel",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Gip => "gip",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Gmd => "gmd",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Gyd => "gyd",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Hkd => "hkd",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Hrk => "hrk",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Htg => "htg",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Idr => "idr",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Ils => "ils",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Inr => "inr",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Isk => "isk",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Jmd => "jmd",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Jpy => "jpy",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Kes => "kes",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Kgs => "kgs",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Khr => "khr",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Kmf => "kmf",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Krw => "krw",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Kyd => "kyd",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Kzt => "kzt",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Lbp => "lbp",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Lkr => "lkr",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Lrd => "lrd",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Lsl => "lsl",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Mad => "mad",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Mdl => "mdl",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Mga => "mga",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Mkd => "mkd",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Mmk => "mmk",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Mnt => "mnt",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Mop => "mop",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Mro => "mro",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Mvr => "mvr",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Mwk => "mwk",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Mxn => "mxn",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Myr => "myr",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Mzn => "mzn",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Nad => "nad",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Ngn => "ngn",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Nok => "nok",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Npr => "npr",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Nzd => "nzd",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Pgk => "pgk",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Php => "php",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Pkr => "pkr",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Pln => "pln",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Qar => "qar",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Ron => "ron",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Rsd => "rsd",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Rub => "rub",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Rwf => "rwf",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Sar => "sar",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Sbd => "sbd",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Scr => "scr",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Sek => "sek",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Sgd => "sgd",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Sle => "sle",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Sll => "sll",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Sos => "sos",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Szl => "szl",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Thb => "thb",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Tjs => "tjs",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Top => "top",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Try => "try",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Ttd => "ttd",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Tzs => "tzs",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Uah => "uah",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Uzs => "uzs",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Vnd => "vnd",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Vuv => "vuv",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Wst => "wst",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Xaf => "xaf",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Xcd => "xcd",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Yer => "yer",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Zar => "zar",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Zmw => "zmw",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Clp => "clp",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Djf => "djf",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Gnf => "gnf",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Ugx => "ugx",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Pyg => "pyg",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Xof => "xof",
                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Xpf => "xpf",
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
        SubscriptionProvisionResponseDataSubscriptionPriceTier,
        SubscriptionProvisionResponseDataSubscriptionPriceTierFromRaw
    >)
)]
public sealed record class SubscriptionProvisionResponseDataSubscriptionPriceTier : JsonModel
{
    /// <summary>
    /// The flat fee price of the price tier
    /// </summary>
    public SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPrice? FlatPrice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPrice>(
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
    public SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPrice? UnitPrice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPrice>(
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

    public SubscriptionProvisionResponseDataSubscriptionPriceTier() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionProvisionResponseDataSubscriptionPriceTier(
        SubscriptionProvisionResponseDataSubscriptionPriceTier subscriptionProvisionResponseDataSubscriptionPriceTier
    )
        : base(subscriptionProvisionResponseDataSubscriptionPriceTier) { }
#pragma warning restore CS8618

    public SubscriptionProvisionResponseDataSubscriptionPriceTier(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionProvisionResponseDataSubscriptionPriceTier(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionProvisionResponseDataSubscriptionPriceTierFromRaw.FromRawUnchecked"/>
    public static SubscriptionProvisionResponseDataSubscriptionPriceTier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionProvisionResponseDataSubscriptionPriceTierFromRaw
    : IFromRawJson<SubscriptionProvisionResponseDataSubscriptionPriceTier>
{
    /// <inheritdoc/>
    public SubscriptionProvisionResponseDataSubscriptionPriceTier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionProvisionResponseDataSubscriptionPriceTier.FromRawUnchecked(rawData);
}

/// <summary>
/// The flat fee price of the price tier
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPrice,
        SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceFromRaw
    >)
)]
public sealed record class SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPrice
    : JsonModel
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
    public ApiEnum<
        string,
        SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency
    >? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<
                    string,
                    SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency
                >
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

    public SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPrice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPrice(
        SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPrice subscriptionProvisionResponseDataSubscriptionPriceTierFlatPrice
    )
        : base(subscriptionProvisionResponseDataSubscriptionPriceTierFlatPrice) { }
#pragma warning restore CS8618

    public SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPrice(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPrice(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceFromRaw.FromRawUnchecked"/>
    public static SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceFromRaw
    : IFromRawJson<SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPrice>
{
    /// <inheritdoc/>
    public SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPrice.FromRawUnchecked(rawData);
}

/// <summary>
/// The price currency
/// </summary>
[JsonConverter(
    typeof(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrencyConverter)
)]
public enum SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency
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

sealed class SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrencyConverter
    : JsonConverter<SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency>
{
    public override SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
            "aed" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Aed,
            "all" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.All,
            "amd" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Amd,
            "ang" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Ang,
            "aud" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Aud,
            "awg" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Awg,
            "azn" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Azn,
            "bam" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Bam,
            "bbd" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Bbd,
            "bdt" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Bdt,
            "bgn" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Bgn,
            "bif" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Bif,
            "bmd" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Bmd,
            "bnd" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Bnd,
            "bsd" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Bsd,
            "bwp" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Bwp,
            "byn" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Byn,
            "bzd" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Bzd,
            "brl" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Brl,
            "cad" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Cad,
            "cdf" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Cdf,
            "chf" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Chf,
            "cny" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Cny,
            "czk" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Czk,
            "dkk" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Dkk,
            "dop" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Dop,
            "dzd" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Dzd,
            "egp" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Egp,
            "etb" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Etb,
            "eur" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Eur,
            "fjd" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Fjd,
            "gbp" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Gbp,
            "gel" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Gel,
            "gip" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Gip,
            "gmd" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Gmd,
            "gyd" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Gyd,
            "hkd" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Hkd,
            "hrk" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Hrk,
            "htg" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Htg,
            "idr" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Idr,
            "ils" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Ils,
            "inr" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Inr,
            "isk" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Isk,
            "jmd" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Jmd,
            "jpy" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Jpy,
            "kes" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Kes,
            "kgs" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Kgs,
            "khr" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Khr,
            "kmf" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Kmf,
            "krw" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Krw,
            "kyd" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Kyd,
            "kzt" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Kzt,
            "lbp" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Lbp,
            "lkr" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Lkr,
            "lrd" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Lrd,
            "lsl" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Lsl,
            "mad" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mad,
            "mdl" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mdl,
            "mga" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mga,
            "mkd" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mkd,
            "mmk" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mmk,
            "mnt" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mnt,
            "mop" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mop,
            "mro" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mro,
            "mvr" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mvr,
            "mwk" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mwk,
            "mxn" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mxn,
            "myr" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Myr,
            "mzn" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mzn,
            "nad" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Nad,
            "ngn" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Ngn,
            "nok" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Nok,
            "npr" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Npr,
            "nzd" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Nzd,
            "pgk" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Pgk,
            "php" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Php,
            "pkr" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Pkr,
            "pln" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Pln,
            "qar" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Qar,
            "ron" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Ron,
            "rsd" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Rsd,
            "rub" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Rub,
            "rwf" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Rwf,
            "sar" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Sar,
            "sbd" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Sbd,
            "scr" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Scr,
            "sek" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Sek,
            "sgd" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Sgd,
            "sle" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Sle,
            "sll" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Sll,
            "sos" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Sos,
            "szl" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Szl,
            "thb" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Thb,
            "tjs" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Tjs,
            "top" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Top,
            "try" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Try,
            "ttd" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Ttd,
            "tzs" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Tzs,
            "uah" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Uah,
            "uzs" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Uzs,
            "vnd" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Vnd,
            "vuv" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Vuv,
            "wst" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Wst,
            "xaf" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Xaf,
            "xcd" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Xcd,
            "yer" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Yer,
            "zar" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Zar,
            "zmw" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Zmw,
            "clp" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Clp,
            "djf" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Djf,
            "gnf" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Gnf,
            "ugx" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Ugx,
            "pyg" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Pyg,
            "xof" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Xof,
            "xpf" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Xpf,
            _ => (SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd =>
                    "usd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Aed =>
                    "aed",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.All =>
                    "all",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Amd =>
                    "amd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Ang =>
                    "ang",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Aud =>
                    "aud",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Awg =>
                    "awg",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Azn =>
                    "azn",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Bam =>
                    "bam",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Bbd =>
                    "bbd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Bdt =>
                    "bdt",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Bgn =>
                    "bgn",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Bif =>
                    "bif",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Bmd =>
                    "bmd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Bnd =>
                    "bnd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Bsd =>
                    "bsd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Bwp =>
                    "bwp",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Byn =>
                    "byn",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Bzd =>
                    "bzd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Brl =>
                    "brl",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Cad =>
                    "cad",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Cdf =>
                    "cdf",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Chf =>
                    "chf",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Cny =>
                    "cny",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Czk =>
                    "czk",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Dkk =>
                    "dkk",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Dop =>
                    "dop",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Dzd =>
                    "dzd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Egp =>
                    "egp",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Etb =>
                    "etb",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Eur =>
                    "eur",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Fjd =>
                    "fjd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Gbp =>
                    "gbp",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Gel =>
                    "gel",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Gip =>
                    "gip",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Gmd =>
                    "gmd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Gyd =>
                    "gyd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Hkd =>
                    "hkd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Hrk =>
                    "hrk",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Htg =>
                    "htg",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Idr =>
                    "idr",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Ils =>
                    "ils",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Inr =>
                    "inr",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Isk =>
                    "isk",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Jmd =>
                    "jmd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Jpy =>
                    "jpy",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Kes =>
                    "kes",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Kgs =>
                    "kgs",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Khr =>
                    "khr",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Kmf =>
                    "kmf",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Krw =>
                    "krw",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Kyd =>
                    "kyd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Kzt =>
                    "kzt",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Lbp =>
                    "lbp",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Lkr =>
                    "lkr",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Lrd =>
                    "lrd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Lsl =>
                    "lsl",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mad =>
                    "mad",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mdl =>
                    "mdl",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mga =>
                    "mga",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mkd =>
                    "mkd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mmk =>
                    "mmk",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mnt =>
                    "mnt",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mop =>
                    "mop",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mro =>
                    "mro",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mvr =>
                    "mvr",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mwk =>
                    "mwk",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mxn =>
                    "mxn",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Myr =>
                    "myr",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mzn =>
                    "mzn",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Nad =>
                    "nad",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Ngn =>
                    "ngn",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Nok =>
                    "nok",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Npr =>
                    "npr",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Nzd =>
                    "nzd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Pgk =>
                    "pgk",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Php =>
                    "php",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Pkr =>
                    "pkr",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Pln =>
                    "pln",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Qar =>
                    "qar",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Ron =>
                    "ron",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Rsd =>
                    "rsd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Rub =>
                    "rub",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Rwf =>
                    "rwf",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Sar =>
                    "sar",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Sbd =>
                    "sbd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Scr =>
                    "scr",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Sek =>
                    "sek",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Sgd =>
                    "sgd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Sle =>
                    "sle",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Sll =>
                    "sll",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Sos =>
                    "sos",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Szl =>
                    "szl",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Thb =>
                    "thb",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Tjs =>
                    "tjs",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Top =>
                    "top",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Try =>
                    "try",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Ttd =>
                    "ttd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Tzs =>
                    "tzs",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Uah =>
                    "uah",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Uzs =>
                    "uzs",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Vnd =>
                    "vnd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Vuv =>
                    "vuv",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Wst =>
                    "wst",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Xaf =>
                    "xaf",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Xcd =>
                    "xcd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Yer =>
                    "yer",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Zar =>
                    "zar",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Zmw =>
                    "zmw",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Clp =>
                    "clp",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Djf =>
                    "djf",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Gnf =>
                    "gnf",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Ugx =>
                    "ugx",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Pyg =>
                    "pyg",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Xof =>
                    "xof",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Xpf =>
                    "xpf",
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
        SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPrice,
        SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceFromRaw
    >)
)]
public sealed record class SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPrice
    : JsonModel
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
    public ApiEnum<
        string,
        SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency
    >? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<
                    string,
                    SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency
                >
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

    public SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPrice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPrice(
        SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPrice subscriptionProvisionResponseDataSubscriptionPriceTierUnitPrice
    )
        : base(subscriptionProvisionResponseDataSubscriptionPriceTierUnitPrice) { }
#pragma warning restore CS8618

    public SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPrice(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPrice(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceFromRaw.FromRawUnchecked"/>
    public static SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceFromRaw
    : IFromRawJson<SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPrice>
{
    /// <inheritdoc/>
    public SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPrice.FromRawUnchecked(rawData);
}

/// <summary>
/// The price currency
/// </summary>
[JsonConverter(
    typeof(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrencyConverter)
)]
public enum SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency
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

sealed class SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrencyConverter
    : JsonConverter<SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency>
{
    public override SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
            "aed" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Aed,
            "all" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.All,
            "amd" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Amd,
            "ang" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Ang,
            "aud" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Aud,
            "awg" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Awg,
            "azn" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Azn,
            "bam" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Bam,
            "bbd" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Bbd,
            "bdt" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Bdt,
            "bgn" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Bgn,
            "bif" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Bif,
            "bmd" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Bmd,
            "bnd" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Bnd,
            "bsd" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Bsd,
            "bwp" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Bwp,
            "byn" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Byn,
            "bzd" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Bzd,
            "brl" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Brl,
            "cad" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Cad,
            "cdf" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Cdf,
            "chf" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Chf,
            "cny" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Cny,
            "czk" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Czk,
            "dkk" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Dkk,
            "dop" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Dop,
            "dzd" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Dzd,
            "egp" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Egp,
            "etb" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Etb,
            "eur" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Eur,
            "fjd" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Fjd,
            "gbp" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Gbp,
            "gel" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Gel,
            "gip" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Gip,
            "gmd" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Gmd,
            "gyd" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Gyd,
            "hkd" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Hkd,
            "hrk" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Hrk,
            "htg" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Htg,
            "idr" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Idr,
            "ils" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Ils,
            "inr" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Inr,
            "isk" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Isk,
            "jmd" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Jmd,
            "jpy" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Jpy,
            "kes" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Kes,
            "kgs" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Kgs,
            "khr" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Khr,
            "kmf" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Kmf,
            "krw" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Krw,
            "kyd" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Kyd,
            "kzt" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Kzt,
            "lbp" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Lbp,
            "lkr" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Lkr,
            "lrd" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Lrd,
            "lsl" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Lsl,
            "mad" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mad,
            "mdl" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mdl,
            "mga" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mga,
            "mkd" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mkd,
            "mmk" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mmk,
            "mnt" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mnt,
            "mop" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mop,
            "mro" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mro,
            "mvr" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mvr,
            "mwk" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mwk,
            "mxn" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mxn,
            "myr" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Myr,
            "mzn" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mzn,
            "nad" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Nad,
            "ngn" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Ngn,
            "nok" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Nok,
            "npr" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Npr,
            "nzd" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Nzd,
            "pgk" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Pgk,
            "php" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Php,
            "pkr" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Pkr,
            "pln" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Pln,
            "qar" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Qar,
            "ron" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Ron,
            "rsd" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Rsd,
            "rub" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Rub,
            "rwf" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Rwf,
            "sar" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Sar,
            "sbd" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Sbd,
            "scr" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Scr,
            "sek" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Sek,
            "sgd" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Sgd,
            "sle" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Sle,
            "sll" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Sll,
            "sos" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Sos,
            "szl" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Szl,
            "thb" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Thb,
            "tjs" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Tjs,
            "top" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Top,
            "try" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Try,
            "ttd" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Ttd,
            "tzs" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Tzs,
            "uah" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Uah,
            "uzs" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Uzs,
            "vnd" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Vnd,
            "vuv" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Vuv,
            "wst" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Wst,
            "xaf" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Xaf,
            "xcd" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Xcd,
            "yer" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Yer,
            "zar" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Zar,
            "zmw" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Zmw,
            "clp" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Clp,
            "djf" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Djf,
            "gnf" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Gnf,
            "ugx" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Ugx,
            "pyg" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Pyg,
            "xof" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Xof,
            "xpf" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Xpf,
            _ => (SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd =>
                    "usd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Aed =>
                    "aed",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.All =>
                    "all",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Amd =>
                    "amd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Ang =>
                    "ang",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Aud =>
                    "aud",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Awg =>
                    "awg",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Azn =>
                    "azn",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Bam =>
                    "bam",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Bbd =>
                    "bbd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Bdt =>
                    "bdt",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Bgn =>
                    "bgn",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Bif =>
                    "bif",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Bmd =>
                    "bmd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Bnd =>
                    "bnd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Bsd =>
                    "bsd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Bwp =>
                    "bwp",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Byn =>
                    "byn",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Bzd =>
                    "bzd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Brl =>
                    "brl",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Cad =>
                    "cad",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Cdf =>
                    "cdf",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Chf =>
                    "chf",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Cny =>
                    "cny",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Czk =>
                    "czk",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Dkk =>
                    "dkk",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Dop =>
                    "dop",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Dzd =>
                    "dzd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Egp =>
                    "egp",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Etb =>
                    "etb",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Eur =>
                    "eur",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Fjd =>
                    "fjd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Gbp =>
                    "gbp",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Gel =>
                    "gel",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Gip =>
                    "gip",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Gmd =>
                    "gmd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Gyd =>
                    "gyd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Hkd =>
                    "hkd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Hrk =>
                    "hrk",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Htg =>
                    "htg",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Idr =>
                    "idr",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Ils =>
                    "ils",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Inr =>
                    "inr",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Isk =>
                    "isk",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Jmd =>
                    "jmd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Jpy =>
                    "jpy",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Kes =>
                    "kes",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Kgs =>
                    "kgs",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Khr =>
                    "khr",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Kmf =>
                    "kmf",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Krw =>
                    "krw",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Kyd =>
                    "kyd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Kzt =>
                    "kzt",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Lbp =>
                    "lbp",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Lkr =>
                    "lkr",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Lrd =>
                    "lrd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Lsl =>
                    "lsl",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mad =>
                    "mad",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mdl =>
                    "mdl",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mga =>
                    "mga",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mkd =>
                    "mkd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mmk =>
                    "mmk",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mnt =>
                    "mnt",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mop =>
                    "mop",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mro =>
                    "mro",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mvr =>
                    "mvr",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mwk =>
                    "mwk",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mxn =>
                    "mxn",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Myr =>
                    "myr",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mzn =>
                    "mzn",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Nad =>
                    "nad",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Ngn =>
                    "ngn",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Nok =>
                    "nok",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Npr =>
                    "npr",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Nzd =>
                    "nzd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Pgk =>
                    "pgk",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Php =>
                    "php",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Pkr =>
                    "pkr",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Pln =>
                    "pln",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Qar =>
                    "qar",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Ron =>
                    "ron",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Rsd =>
                    "rsd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Rub =>
                    "rub",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Rwf =>
                    "rwf",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Sar =>
                    "sar",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Sbd =>
                    "sbd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Scr =>
                    "scr",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Sek =>
                    "sek",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Sgd =>
                    "sgd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Sle =>
                    "sle",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Sll =>
                    "sll",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Sos =>
                    "sos",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Szl =>
                    "szl",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Thb =>
                    "thb",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Tjs =>
                    "tjs",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Top =>
                    "top",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Try =>
                    "try",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Ttd =>
                    "ttd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Tzs =>
                    "tzs",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Uah =>
                    "uah",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Uzs =>
                    "uzs",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Vnd =>
                    "vnd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Vuv =>
                    "vuv",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Wst =>
                    "wst",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Xaf =>
                    "xaf",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Xcd =>
                    "xcd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Yer =>
                    "yer",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Zar =>
                    "zar",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Zmw =>
                    "zmw",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Clp =>
                    "clp",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Djf =>
                    "djf",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Gnf =>
                    "gnf",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Ugx =>
                    "ugx",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Pyg =>
                    "pyg",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Xof =>
                    "xof",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Xpf =>
                    "xpf",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
