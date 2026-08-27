using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using System = System;

namespace Stigg.Client.Models.V1.Contracts;

/// <summary>
/// Creates a contract for a customer together with all of its (custom) subscriptions
/// in a single atomic operation. Every new subscription is created inside one transaction
/// — any validation or creation failure rolls the whole contract back. Each subscription
/// entry is either a new subscription to create or a reference to an existing custom
/// subscription. Returns the created contract.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ContractCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The customer ref ID the contract belongs to
    /// </summary>
    public required string CustomerID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("customerId");
        }
        init { this._rawBodyData.Set("customerId", value); }
    }

    /// <summary>
    /// The subscriptions to attach to the contract (must be non-empty). Each entry
    /// is either a new subscription to create or a reference to an existing custom subscription.
    /// </summary>
    public required IReadOnlyList<Subscription> Subscriptions
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<Subscription>>(
                "subscriptions"
            );
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<Subscription>>(
                "subscriptions",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Optional contract activation end date
    /// </summary>
    public System::DateTimeOffset? ActivationEndDate
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<System::DateTimeOffset>("activationEndDate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("activationEndDate", value);
        }
    }

    /// <summary>
    /// Optional contract activation start date
    /// </summary>
    public System::DateTimeOffset? ActivationStartDate
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<System::DateTimeOffset>(
                "activationStartDate"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("activationStartDate", value);
        }
    }

    /// <summary>
    /// Optional contract name
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("name");
        }
        init { this._rawBodyData.Set("name", value); }
    }

    /// <summary>
    /// Optional purchase-order number
    /// </summary>
    public string? PoNumber
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("poNumber");
        }
        init { this._rawBodyData.Set("poNumber", value); }
    }

    /// <summary>
    /// Whether to set up billing for the contract by creating a billing contract
    /// in the connected billing provider. When false, the contract only provisions
    /// access (grants entitlements) and no billing contract is created. Defaults
    /// to true.
    /// </summary>
    public bool? SetupBilling
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("setupBilling");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("setupBilling", value);
        }
    }

    public string? XAccountID
    {
        get
        {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNullableClass<string>("X-ACCOUNT-ID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawHeaderData.Set("X-ACCOUNT-ID", value);
        }
    }

    public string? XEnvironmentID
    {
        get
        {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNullableClass<string>("X-ENVIRONMENT-ID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawHeaderData.Set("X-ENVIRONMENT-ID", value);
        }
    }

    public ContractCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ContractCreateParams(ContractCreateParams contractCreateParams)
        : base(contractCreateParams)
    {
        this._rawBodyData = new(contractCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public ContractCreateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContractCreateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ContractCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(ContractCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/api/v1/contracts")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

/// <summary>
/// A single subscription on a contract: exactly one of newSubscription or existingSubscriptionId
/// must be set.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Subscription, SubscriptionFromRaw>))]
public sealed record class Subscription : JsonModel
{
    /// <summary>
    /// The subscription ref ID of an already-created custom subscription to link
    /// </summary>
    public string? ExistingSubscriptionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("existingSubscriptionId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("existingSubscriptionId", value);
        }
    }

    /// <summary>
    /// A new subscription to create, using the same body the provision-subscription
    /// endpoint accepts
    /// </summary>
    public NewSubscription? NewSubscription
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewSubscription>("newSubscription");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("newSubscription", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ExistingSubscriptionID;
        this.NewSubscription?.Validate();
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
/// A new subscription to create, using the same body the provision-subscription endpoint accepts
/// </summary>
[JsonConverter(typeof(JsonModelConverter<NewSubscription, NewSubscriptionFromRaw>))]
public sealed record class NewSubscription : JsonModel
{
    /// <summary>
    /// Customer ID to provision the subscription for
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
    /// Plan ID to provision
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
    /// Unique identifier for the subscription
    /// </summary>
    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    public IReadOnlyList<Addon>? Addons
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Addon>>("addons");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Addon>?>(
                "addons",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Coupon configuration
    /// </summary>
    public AppliedCoupon? AppliedCoupon
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AppliedCoupon>("appliedCoupon");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("appliedCoupon", value);
        }
    }

    /// <summary>
    /// Whether to wait for payment confirmation before returning the subscription
    /// </summary>
    public bool? AwaitPaymentConfirmation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("awaitPaymentConfirmation");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("awaitPaymentConfirmation", value);
        }
    }

    /// <summary>
    /// The ISO 3166-1 alpha-2 country code for billing
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
    /// Billing cycle anchor behavior for the subscription
    /// </summary>
    public ApiEnum<string, BillingCycleAnchor>? BillingCycleAnchor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, BillingCycleAnchor>>(
                "billingCycleAnchor"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("billingCycleAnchor", value);
        }
    }

    /// <summary>
    /// External billing system identifier
    /// </summary>
    public string? BillingID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billingId");
        }
        init { this._rawData.Set("billingId", value); }
    }

    public BillingInformation? BillingInformation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BillingInformation>("billingInformation");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("billingInformation", value);
        }
    }

    /// <summary>
    /// Billing period (MONTHLY or ANNUALLY)
    /// </summary>
    public ApiEnum<string, BillingPeriod>? BillingPeriod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, BillingPeriod>>("billingPeriod");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("billingPeriod", value);
        }
    }

    public Budget? Budget
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Budget>("budget");
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
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("cancellationDate", value);
        }
    }

    public IReadOnlyList<Charge>? Charges
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Charge>>("charges");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Charge>?>(
                "charges",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Checkout page configuration for payment collection
    /// </summary>
    public CheckoutOptions? CheckoutOptions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CheckoutOptions>("checkoutOptions");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("checkoutOptions", value);
        }
    }

    public IReadOnlyList<Entitlement>? Entitlements
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Entitlement>>("entitlements");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Entitlement>?>(
                "entitlements",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Additional metadata for the subscription, stored as an arbitrary flat key-value object.
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
    /// Minimum spend amount
    /// </summary>
    public MinimumSpend? MinimumSpend
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MinimumSpend>("minimumSpend");
        }
        init { this._rawData.Set("minimumSpend", value); }
    }

    /// <summary>
    /// Optional paying customer ID for split billing scenarios
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
    /// How payments should be collected for this subscription
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
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("paymentCollectionMethod", value);
        }
    }

    public IReadOnlyList<PriceOverride>? PriceOverrides
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<PriceOverride>>("priceOverrides");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<PriceOverride>?>(
                "priceOverrides",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Optional resource ID for multi-instance subscriptions
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
    /// Salesforce ID
    /// </summary>
    public string? SalesforceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("salesforceId");
        }
        init { this._rawData.Set("salesforceId", value); }
    }

    /// <summary>
    /// Strategy for scheduling subscription changes
    /// </summary>
    public ApiEnum<string, ScheduleStrategy>? ScheduleStrategy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ScheduleStrategy>>(
                "scheduleStrategy"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("scheduleStrategy", value);
        }
    }

    /// <summary>
    /// Subscription start date
    /// </summary>
    public System::DateTimeOffset? StartDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("startDate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("startDate", value);
        }
    }

    /// <summary>
    /// Trial period override settings
    /// </summary>
    public TrialOverrideConfiguration? TrialOverrideConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TrialOverrideConfiguration>(
                "trialOverrideConfiguration"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("trialOverrideConfiguration", value);
        }
    }

    /// <summary>
    /// Unit quantity for per-unit pricing. Minimum is 0 (zero is allowed).
    /// </summary>
    public long? UnitQuantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("unitQuantity");
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
        _ = this.CustomerID;
        _ = this.PlanID;
        _ = this.ID;
        foreach (var item in this.Addons ?? [])
        {
            item.Validate();
        }
        this.AppliedCoupon?.Validate();
        _ = this.AwaitPaymentConfirmation;
        _ = this.BillingCountryCode;
        this.BillingCycleAnchor?.Validate();
        _ = this.BillingID;
        this.BillingInformation?.Validate();
        this.BillingPeriod?.Validate();
        this.Budget?.Validate();
        _ = this.CancellationDate;
        foreach (var item in this.Charges ?? [])
        {
            item.Validate();
        }
        this.CheckoutOptions?.Validate();
        foreach (var item in this.Entitlements ?? [])
        {
            item.Validate();
        }
        _ = this.Metadata;
        this.MinimumSpend?.Validate();
        _ = this.PayingCustomerID;
        this.PaymentCollectionMethod?.Validate();
        foreach (var item in this.PriceOverrides ?? [])
        {
            item.Validate();
        }
        _ = this.ResourceID;
        _ = this.SalesforceID;
        this.ScheduleStrategy?.Validate();
        _ = this.StartDate;
        this.TrialOverrideConfiguration?.Validate();
        _ = this.UnitQuantity;
    }

    public NewSubscription() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NewSubscription(NewSubscription newSubscription)
        : base(newSubscription) { }
#pragma warning restore CS8618

    public NewSubscription(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewSubscription(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NewSubscriptionFromRaw.FromRawUnchecked"/>
    public static NewSubscription FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NewSubscriptionFromRaw : IFromRawJson<NewSubscription>
{
    /// <inheritdoc/>
    public NewSubscription FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        NewSubscription.FromRawUnchecked(rawData);
}

/// <summary>
/// Addon configuration
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Addon, AddonFromRaw>))]
public sealed record class Addon : JsonModel
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

    public Addon() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Addon(Addon addon)
        : base(addon) { }
#pragma warning restore CS8618

    public Addon(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Addon(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AddonFromRaw.FromRawUnchecked"/>
    public static Addon FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AddonFromRaw : IFromRawJson<Addon>
{
    /// <inheritdoc/>
    public Addon FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Addon.FromRawUnchecked(rawData);
}

/// <summary>
/// Coupon configuration
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AppliedCoupon, AppliedCouponFromRaw>))]
public sealed record class AppliedCoupon : JsonModel
{
    /// <summary>
    /// Billing provider coupon ID
    /// </summary>
    public string? BillingCouponID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billingCouponId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("billingCouponId", value);
        }
    }

    /// <summary>
    /// Coupon timing configuration
    /// </summary>
    public Configuration? Configuration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Configuration>("configuration");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("configuration", value);
        }
    }

    /// <summary>
    /// Stigg coupon ID
    /// </summary>
    public string? CouponID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("couponId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("couponId", value);
        }
    }

    /// <summary>
    /// Ad-hoc discount configuration
    /// </summary>
    public Discount? Discount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Discount>("discount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("discount", value);
        }
    }

    /// <summary>
    /// Promotion code to apply
    /// </summary>
    public string? PromotionCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("promotionCode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("promotionCode", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BillingCouponID;
        this.Configuration?.Validate();
        _ = this.CouponID;
        this.Discount?.Validate();
        _ = this.PromotionCode;
    }

    public AppliedCoupon() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AppliedCoupon(AppliedCoupon appliedCoupon)
        : base(appliedCoupon) { }
#pragma warning restore CS8618

    public AppliedCoupon(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AppliedCoupon(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AppliedCouponFromRaw.FromRawUnchecked"/>
    public static AppliedCoupon FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AppliedCouponFromRaw : IFromRawJson<AppliedCoupon>
{
    /// <inheritdoc/>
    public AppliedCoupon FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AppliedCoupon.FromRawUnchecked(rawData);
}

/// <summary>
/// Coupon timing configuration
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Configuration, ConfigurationFromRaw>))]
public sealed record class Configuration : JsonModel
{
    /// <summary>
    /// Coupon start date
    /// </summary>
    public System::DateTimeOffset? StartDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("startDate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("startDate", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.StartDate;
    }

    public Configuration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Configuration(Configuration configuration)
        : base(configuration) { }
#pragma warning restore CS8618

    public Configuration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Configuration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConfigurationFromRaw.FromRawUnchecked"/>
    public static Configuration FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConfigurationFromRaw : IFromRawJson<Configuration>
{
    /// <inheritdoc/>
    public Configuration FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Configuration.FromRawUnchecked(rawData);
}

/// <summary>
/// Ad-hoc discount configuration
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Discount, DiscountFromRaw>))]
public sealed record class Discount : JsonModel
{
    /// <summary>
    /// Fixed amounts off by currency
    /// </summary>
    public IReadOnlyList<AmountsOff>? AmountsOff
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<AmountsOff>>("amountsOff");
        }
        init
        {
            this._rawData.Set<ImmutableArray<AmountsOff>?>(
                "amountsOff",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Ad-hoc discount
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    /// <summary>
    /// Duration in months
    /// </summary>
    public double? DurationInMonths
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("durationInMonths");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("durationInMonths", value);
        }
    }

    /// <summary>
    /// Discount name
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
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
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("percentOff", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.AmountsOff ?? [])
        {
            item.Validate();
        }
        _ = this.Description;
        _ = this.DurationInMonths;
        _ = this.Name;
        _ = this.PercentOff;
    }

    public Discount() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Discount(Discount discount)
        : base(discount) { }
#pragma warning restore CS8618

    public Discount(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Discount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DiscountFromRaw.FromRawUnchecked"/>
    public static Discount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DiscountFromRaw : IFromRawJson<Discount>
{
    /// <inheritdoc/>
    public Discount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Discount.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<AmountsOff, AmountsOffFromRaw>))]
public sealed record class AmountsOff : JsonModel
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
    public required ApiEnum<string, Currency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Currency>>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        this.Currency.Validate();
    }

    public AmountsOff() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AmountsOff(AmountsOff amountsOff)
        : base(amountsOff) { }
#pragma warning restore CS8618

    public AmountsOff(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AmountsOff(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AmountsOffFromRaw.FromRawUnchecked"/>
    public static AmountsOff FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AmountsOffFromRaw : IFromRawJson<AmountsOff>
{
    /// <inheritdoc/>
    public AmountsOff FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AmountsOff.FromRawUnchecked(rawData);
}

/// <summary>
/// ISO 4217 currency code
/// </summary>
[JsonConverter(typeof(CurrencyConverter))]
public enum Currency
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

sealed class CurrencyConverter : JsonConverter<Currency>
{
    public override Currency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => Currency.Usd,
            "aed" => Currency.Aed,
            "all" => Currency.All,
            "amd" => Currency.Amd,
            "ang" => Currency.Ang,
            "aud" => Currency.Aud,
            "awg" => Currency.Awg,
            "azn" => Currency.Azn,
            "bam" => Currency.Bam,
            "bbd" => Currency.Bbd,
            "bdt" => Currency.Bdt,
            "bgn" => Currency.Bgn,
            "bif" => Currency.Bif,
            "bmd" => Currency.Bmd,
            "bnd" => Currency.Bnd,
            "bsd" => Currency.Bsd,
            "bwp" => Currency.Bwp,
            "byn" => Currency.Byn,
            "bzd" => Currency.Bzd,
            "brl" => Currency.Brl,
            "cad" => Currency.Cad,
            "cdf" => Currency.Cdf,
            "chf" => Currency.Chf,
            "cny" => Currency.Cny,
            "czk" => Currency.Czk,
            "dkk" => Currency.Dkk,
            "dop" => Currency.Dop,
            "dzd" => Currency.Dzd,
            "egp" => Currency.Egp,
            "etb" => Currency.Etb,
            "eur" => Currency.Eur,
            "fjd" => Currency.Fjd,
            "gbp" => Currency.Gbp,
            "gel" => Currency.Gel,
            "gip" => Currency.Gip,
            "gmd" => Currency.Gmd,
            "gyd" => Currency.Gyd,
            "hkd" => Currency.Hkd,
            "hrk" => Currency.Hrk,
            "htg" => Currency.Htg,
            "idr" => Currency.Idr,
            "ils" => Currency.Ils,
            "inr" => Currency.Inr,
            "isk" => Currency.Isk,
            "jmd" => Currency.Jmd,
            "jpy" => Currency.Jpy,
            "kes" => Currency.Kes,
            "kgs" => Currency.Kgs,
            "khr" => Currency.Khr,
            "kmf" => Currency.Kmf,
            "krw" => Currency.Krw,
            "kyd" => Currency.Kyd,
            "kzt" => Currency.Kzt,
            "lbp" => Currency.Lbp,
            "lkr" => Currency.Lkr,
            "lrd" => Currency.Lrd,
            "lsl" => Currency.Lsl,
            "mad" => Currency.Mad,
            "mdl" => Currency.Mdl,
            "mga" => Currency.Mga,
            "mkd" => Currency.Mkd,
            "mmk" => Currency.Mmk,
            "mnt" => Currency.Mnt,
            "mop" => Currency.Mop,
            "mro" => Currency.Mro,
            "mvr" => Currency.Mvr,
            "mwk" => Currency.Mwk,
            "mxn" => Currency.Mxn,
            "myr" => Currency.Myr,
            "mzn" => Currency.Mzn,
            "nad" => Currency.Nad,
            "ngn" => Currency.Ngn,
            "nok" => Currency.Nok,
            "npr" => Currency.Npr,
            "nzd" => Currency.Nzd,
            "pgk" => Currency.Pgk,
            "php" => Currency.Php,
            "pkr" => Currency.Pkr,
            "pln" => Currency.Pln,
            "qar" => Currency.Qar,
            "ron" => Currency.Ron,
            "rsd" => Currency.Rsd,
            "rub" => Currency.Rub,
            "rwf" => Currency.Rwf,
            "sar" => Currency.Sar,
            "sbd" => Currency.Sbd,
            "scr" => Currency.Scr,
            "sek" => Currency.Sek,
            "sgd" => Currency.Sgd,
            "sle" => Currency.Sle,
            "sll" => Currency.Sll,
            "sos" => Currency.Sos,
            "szl" => Currency.Szl,
            "thb" => Currency.Thb,
            "tjs" => Currency.Tjs,
            "top" => Currency.Top,
            "try" => Currency.Try,
            "ttd" => Currency.Ttd,
            "tzs" => Currency.Tzs,
            "uah" => Currency.Uah,
            "uzs" => Currency.Uzs,
            "vnd" => Currency.Vnd,
            "vuv" => Currency.Vuv,
            "wst" => Currency.Wst,
            "xaf" => Currency.Xaf,
            "xcd" => Currency.Xcd,
            "yer" => Currency.Yer,
            "zar" => Currency.Zar,
            "zmw" => Currency.Zmw,
            "clp" => Currency.Clp,
            "djf" => Currency.Djf,
            "gnf" => Currency.Gnf,
            "ugx" => Currency.Ugx,
            "pyg" => Currency.Pyg,
            "xof" => Currency.Xof,
            "xpf" => Currency.Xpf,
            _ => (Currency)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Currency value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Currency.Usd => "usd",
                Currency.Aed => "aed",
                Currency.All => "all",
                Currency.Amd => "amd",
                Currency.Ang => "ang",
                Currency.Aud => "aud",
                Currency.Awg => "awg",
                Currency.Azn => "azn",
                Currency.Bam => "bam",
                Currency.Bbd => "bbd",
                Currency.Bdt => "bdt",
                Currency.Bgn => "bgn",
                Currency.Bif => "bif",
                Currency.Bmd => "bmd",
                Currency.Bnd => "bnd",
                Currency.Bsd => "bsd",
                Currency.Bwp => "bwp",
                Currency.Byn => "byn",
                Currency.Bzd => "bzd",
                Currency.Brl => "brl",
                Currency.Cad => "cad",
                Currency.Cdf => "cdf",
                Currency.Chf => "chf",
                Currency.Cny => "cny",
                Currency.Czk => "czk",
                Currency.Dkk => "dkk",
                Currency.Dop => "dop",
                Currency.Dzd => "dzd",
                Currency.Egp => "egp",
                Currency.Etb => "etb",
                Currency.Eur => "eur",
                Currency.Fjd => "fjd",
                Currency.Gbp => "gbp",
                Currency.Gel => "gel",
                Currency.Gip => "gip",
                Currency.Gmd => "gmd",
                Currency.Gyd => "gyd",
                Currency.Hkd => "hkd",
                Currency.Hrk => "hrk",
                Currency.Htg => "htg",
                Currency.Idr => "idr",
                Currency.Ils => "ils",
                Currency.Inr => "inr",
                Currency.Isk => "isk",
                Currency.Jmd => "jmd",
                Currency.Jpy => "jpy",
                Currency.Kes => "kes",
                Currency.Kgs => "kgs",
                Currency.Khr => "khr",
                Currency.Kmf => "kmf",
                Currency.Krw => "krw",
                Currency.Kyd => "kyd",
                Currency.Kzt => "kzt",
                Currency.Lbp => "lbp",
                Currency.Lkr => "lkr",
                Currency.Lrd => "lrd",
                Currency.Lsl => "lsl",
                Currency.Mad => "mad",
                Currency.Mdl => "mdl",
                Currency.Mga => "mga",
                Currency.Mkd => "mkd",
                Currency.Mmk => "mmk",
                Currency.Mnt => "mnt",
                Currency.Mop => "mop",
                Currency.Mro => "mro",
                Currency.Mvr => "mvr",
                Currency.Mwk => "mwk",
                Currency.Mxn => "mxn",
                Currency.Myr => "myr",
                Currency.Mzn => "mzn",
                Currency.Nad => "nad",
                Currency.Ngn => "ngn",
                Currency.Nok => "nok",
                Currency.Npr => "npr",
                Currency.Nzd => "nzd",
                Currency.Pgk => "pgk",
                Currency.Php => "php",
                Currency.Pkr => "pkr",
                Currency.Pln => "pln",
                Currency.Qar => "qar",
                Currency.Ron => "ron",
                Currency.Rsd => "rsd",
                Currency.Rub => "rub",
                Currency.Rwf => "rwf",
                Currency.Sar => "sar",
                Currency.Sbd => "sbd",
                Currency.Scr => "scr",
                Currency.Sek => "sek",
                Currency.Sgd => "sgd",
                Currency.Sle => "sle",
                Currency.Sll => "sll",
                Currency.Sos => "sos",
                Currency.Szl => "szl",
                Currency.Thb => "thb",
                Currency.Tjs => "tjs",
                Currency.Top => "top",
                Currency.Try => "try",
                Currency.Ttd => "ttd",
                Currency.Tzs => "tzs",
                Currency.Uah => "uah",
                Currency.Uzs => "uzs",
                Currency.Vnd => "vnd",
                Currency.Vuv => "vuv",
                Currency.Wst => "wst",
                Currency.Xaf => "xaf",
                Currency.Xcd => "xcd",
                Currency.Yer => "yer",
                Currency.Zar => "zar",
                Currency.Zmw => "zmw",
                Currency.Clp => "clp",
                Currency.Djf => "djf",
                Currency.Gnf => "gnf",
                Currency.Ugx => "ugx",
                Currency.Pyg => "pyg",
                Currency.Xof => "xof",
                Currency.Xpf => "xpf",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Billing cycle anchor behavior for the subscription
/// </summary>
[JsonConverter(typeof(BillingCycleAnchorConverter))]
public enum BillingCycleAnchor
{
    Unchanged,
    Now,
}

sealed class BillingCycleAnchorConverter : JsonConverter<BillingCycleAnchor>
{
    public override BillingCycleAnchor Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "UNCHANGED" => BillingCycleAnchor.Unchanged,
            "NOW" => BillingCycleAnchor.Now,
            _ => (BillingCycleAnchor)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BillingCycleAnchor value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BillingCycleAnchor.Unchanged => "UNCHANGED",
                BillingCycleAnchor.Now => "NOW",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<BillingInformation, BillingInformationFromRaw>))]
public sealed record class BillingInformation : JsonModel
{
    /// <summary>
    /// Billing address for the subscription
    /// </summary>
    public BillingAddress? BillingAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BillingAddress>("billingAddress");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("billingAddress", value);
        }
    }

    /// <summary>
    /// Stripe Connect account to charge on behalf of
    /// </summary>
    public string? ChargeOnBehalfOfAccount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("chargeOnBehalfOfAccount");
        }
        init { this._rawData.Set("chargeOnBehalfOfAccount", value); }
    }

    /// <summary>
    /// Billing integration identifier
    /// </summary>
    public string? IntegrationID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("integrationId");
        }
        init { this._rawData.Set("integrationId", value); }
    }

    /// <summary>
    /// Number of days until invoice is due
    /// </summary>
    public double? InvoiceDaysUntilDue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("invoiceDaysUntilDue");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("invoiceDaysUntilDue", value);
        }
    }

    /// <summary>
    /// Whether the subscription is backdated
    /// </summary>
    public bool? IsBackdated
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isBackdated");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isBackdated", value);
        }
    }

    /// <summary>
    /// Whether the invoice is marked as paid
    /// </summary>
    public bool? IsInvoicePaid
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isInvoicePaid");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isInvoicePaid", value);
        }
    }

    /// <summary>
    /// Additional metadata for the subscription, stored as an arbitrary flat key-value object.
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
    /// How to handle proration for billing changes
    /// </summary>
    public ApiEnum<string, ProrationBehavior>? ProrationBehavior
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ProrationBehavior>>(
                "prorationBehavior"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("prorationBehavior", value);
        }
    }

    /// <summary>
    /// Customer tax identification numbers
    /// </summary>
    public IReadOnlyList<TaxID>? TaxIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<TaxID>>("taxIds");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<TaxID>?>(
                "taxIds",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Tax percentage (0-100)
    /// </summary>
    public double? TaxPercentage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("taxPercentage");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("taxPercentage", value);
        }
    }

    /// <summary>
    /// Tax rate identifiers to apply
    /// </summary>
    public IReadOnlyList<string>? TaxRateIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("taxRateIds");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "taxRateIds",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.BillingAddress?.Validate();
        _ = this.ChargeOnBehalfOfAccount;
        _ = this.IntegrationID;
        _ = this.InvoiceDaysUntilDue;
        _ = this.IsBackdated;
        _ = this.IsInvoicePaid;
        _ = this.Metadata;
        this.ProrationBehavior?.Validate();
        foreach (var item in this.TaxIds ?? [])
        {
            item.Validate();
        }
        _ = this.TaxPercentage;
        _ = this.TaxRateIds;
    }

    public BillingInformation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BillingInformation(BillingInformation billingInformation)
        : base(billingInformation) { }
#pragma warning restore CS8618

    public BillingInformation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BillingInformation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BillingInformationFromRaw.FromRawUnchecked"/>
    public static BillingInformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BillingInformationFromRaw : IFromRawJson<BillingInformation>
{
    /// <inheritdoc/>
    public BillingInformation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BillingInformation.FromRawUnchecked(rawData);
}

/// <summary>
/// Billing address for the subscription
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BillingAddress, BillingAddressFromRaw>))]
public sealed record class BillingAddress : JsonModel
{
    public string? City
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("city");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("city", value);
        }
    }

    public string? Country
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("country");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("country", value);
        }
    }

    public string? Line1
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("line1");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("line1", value);
        }
    }

    public string? Line2
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("line2");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("line2", value);
        }
    }

    public string? PostalCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("postalCode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("postalCode", value);
        }
    }

    public string? State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("state");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("state", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.City;
        _ = this.Country;
        _ = this.Line1;
        _ = this.Line2;
        _ = this.PostalCode;
        _ = this.State;
    }

    public BillingAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BillingAddress(BillingAddress billingAddress)
        : base(billingAddress) { }
#pragma warning restore CS8618

    public BillingAddress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BillingAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BillingAddressFromRaw.FromRawUnchecked"/>
    public static BillingAddress FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BillingAddressFromRaw : IFromRawJson<BillingAddress>
{
    /// <inheritdoc/>
    public BillingAddress FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BillingAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// How to handle proration for billing changes
/// </summary>
[JsonConverter(typeof(ProrationBehaviorConverter))]
public enum ProrationBehavior
{
    InvoiceImmediately,
    CreateProrations,
    None,
}

sealed class ProrationBehaviorConverter : JsonConverter<ProrationBehavior>
{
    public override ProrationBehavior Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "INVOICE_IMMEDIATELY" => ProrationBehavior.InvoiceImmediately,
            "CREATE_PRORATIONS" => ProrationBehavior.CreateProrations,
            "NONE" => ProrationBehavior.None,
            _ => (ProrationBehavior)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProrationBehavior value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProrationBehavior.InvoiceImmediately => "INVOICE_IMMEDIATELY",
                ProrationBehavior.CreateProrations => "CREATE_PRORATIONS",
                ProrationBehavior.None => "NONE",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Tax identifier with type and value for customer tax exemptions.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TaxID, TaxIDFromRaw>))]
public sealed record class TaxID : JsonModel
{
    /// <summary>
    /// The type of tax exemption identifier, such as VAT.
    /// </summary>
    public required string Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// The actual tax identifier value
    /// </summary>
    public required string Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("value");
        }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Type;
        _ = this.Value;
    }

    public TaxID() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TaxID(TaxID taxID)
        : base(taxID) { }
#pragma warning restore CS8618

    public TaxID(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TaxID(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TaxIDFromRaw.FromRawUnchecked"/>
    public static TaxID FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TaxIDFromRaw : IFromRawJson<TaxID>
{
    /// <inheritdoc/>
    public TaxID FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TaxID.FromRawUnchecked(rawData);
}

/// <summary>
/// Billing period (MONTHLY or ANNUALLY)
/// </summary>
[JsonConverter(typeof(BillingPeriodConverter))]
public enum BillingPeriod
{
    Monthly,
    Annually,
}

sealed class BillingPeriodConverter : JsonConverter<BillingPeriod>
{
    public override BillingPeriod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "MONTHLY" => BillingPeriod.Monthly,
            "ANNUALLY" => BillingPeriod.Annually,
            _ => (BillingPeriod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BillingPeriod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BillingPeriod.Monthly => "MONTHLY",
                BillingPeriod.Annually => "ANNUALLY",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<Budget, BudgetFromRaw>))]
public sealed record class Budget : JsonModel
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

    public Budget() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Budget(Budget budget)
        : base(budget) { }
#pragma warning restore CS8618

    public Budget(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Budget(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BudgetFromRaw.FromRawUnchecked"/>
    public static Budget FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BudgetFromRaw : IFromRawJson<Budget>
{
    /// <inheritdoc/>
    public Budget FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Budget.FromRawUnchecked(rawData);
}

/// <summary>
/// A charge selection for a subscription (references a catalog charge with a quantity).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Charge, ChargeFromRaw>))]
public sealed record class Charge : JsonModel
{
    /// <summary>
    /// Charge ID
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
    /// Charge quantity. Minimum is 0 (zero is allowed).
    /// </summary>
    public required double Quantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("quantity");
        }
        init { this._rawData.Set("quantity", value); }
    }

    /// <summary>
    /// Charge type
    /// </summary>
    public required ApiEnum<string, global::Stigg.Client.Models.V1.Contracts.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Stigg.Client.Models.V1.Contracts.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Quantity;
        this.Type.Validate();
    }

    public Charge() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Charge(Charge charge)
        : base(charge) { }
#pragma warning restore CS8618

    public Charge(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Charge(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargeFromRaw.FromRawUnchecked"/>
    public static Charge FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChargeFromRaw : IFromRawJson<Charge>
{
    /// <inheritdoc/>
    public Charge FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Charge.FromRawUnchecked(rawData);
}

/// <summary>
/// Charge type
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Feature,
    Credit,
}

sealed class TypeConverter : JsonConverter<global::Stigg.Client.Models.V1.Contracts.Type>
{
    public override global::Stigg.Client.Models.V1.Contracts.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FEATURE" => global::Stigg.Client.Models.V1.Contracts.Type.Feature,
            "CREDIT" => global::Stigg.Client.Models.V1.Contracts.Type.Credit,
            _ => (global::Stigg.Client.Models.V1.Contracts.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Stigg.Client.Models.V1.Contracts.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Stigg.Client.Models.V1.Contracts.Type.Feature => "FEATURE",
                global::Stigg.Client.Models.V1.Contracts.Type.Credit => "CREDIT",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Checkout page configuration for payment collection
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CheckoutOptions, CheckoutOptionsFromRaw>))]
public sealed record class CheckoutOptions : JsonModel
{
    /// <summary>
    /// URL to redirect to if checkout is canceled
    /// </summary>
    public required string CancelUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("cancelUrl");
        }
        init { this._rawData.Set("cancelUrl", value); }
    }

    /// <summary>
    /// URL to redirect to after successful checkout
    /// </summary>
    public required string SuccessUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("successUrl");
        }
        init { this._rawData.Set("successUrl", value); }
    }

    /// <summary>
    /// Allow promotional codes during checkout
    /// </summary>
    public bool? AllowPromoCodes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("allowPromoCodes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("allowPromoCodes", value);
        }
    }

    /// <summary>
    /// Allow tax ID collection during checkout
    /// </summary>
    public bool? AllowTaxIDCollection
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("allowTaxIdCollection");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("allowTaxIdCollection", value);
        }
    }

    /// <summary>
    /// Collect billing address during checkout
    /// </summary>
    public bool? CollectBillingAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("collectBillingAddress");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("collectBillingAddress", value);
        }
    }

    /// <summary>
    /// Collect phone number during checkout
    /// </summary>
    public bool? CollectPhoneNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("collectPhoneNumber");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("collectPhoneNumber", value);
        }
    }

    /// <summary>
    /// Optional reference ID for the checkout session
    /// </summary>
    public string? ReferenceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("referenceId");
        }
        init { this._rawData.Set("referenceId", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CancelUrl;
        _ = this.SuccessUrl;
        _ = this.AllowPromoCodes;
        _ = this.AllowTaxIDCollection;
        _ = this.CollectBillingAddress;
        _ = this.CollectPhoneNumber;
        _ = this.ReferenceID;
    }

    public CheckoutOptions() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CheckoutOptions(CheckoutOptions checkoutOptions)
        : base(checkoutOptions) { }
#pragma warning restore CS8618

    public CheckoutOptions(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CheckoutOptions(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CheckoutOptionsFromRaw.FromRawUnchecked"/>
    public static CheckoutOptions FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CheckoutOptionsFromRaw : IFromRawJson<CheckoutOptions>
{
    /// <inheritdoc/>
    public CheckoutOptions FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CheckoutOptions.FromRawUnchecked(rawData);
}

/// <summary>
/// Feature entitlement configuration for a subscription
/// </summary>
[JsonConverter(typeof(EntitlementConverter))]
public record class Entitlement : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string ID
    {
        get { return Match(feature: (x) => x.ID, credit: (x) => x.ID); }
    }

    public JsonElement Type
    {
        get { return Match(feature: (x) => x.Type, credit: (x) => x.Type); }
    }

    public bool? HasSoftLimit
    {
        get { return Match<bool?>(feature: (x) => x.HasSoftLimit, credit: (x) => x.HasSoftLimit); }
    }

    public Entitlement(Feature value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Entitlement(Credit value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Entitlement(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Feature"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFeature(out var value)) {
    ///     // `value` is of type `Feature`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFeature([NotNullWhen(true)] out Feature? value)
    {
        value = this.Value as Feature;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Credit"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCredit(out var value)) {
    ///     // `value` is of type `Credit`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCredit([NotNullWhen(true)] out Credit? value)
    {
        value = this.Value as Credit;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="StiggInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (Feature value) =&gt; {...},
    ///     (Credit value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(System::Action<Feature> feature, System::Action<Credit> credit)
    {
        switch (this.Value)
        {
            case Feature value:
                feature(value);
                break;
            case Credit value:
                credit(value);
                break;
            default:
                throw new StiggInvalidDataException(
                    "Data did not match any variant of Entitlement"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="StiggInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (Feature value) =&gt; {...},
    ///     (Credit value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(System::Func<Feature, T> feature, System::Func<Credit, T> credit)
    {
        return this.Value switch
        {
            Feature value => feature(value),
            Credit value => credit(value),
            _ => throw new StiggInvalidDataException(
                "Data did not match any variant of Entitlement"
            ),
        };
    }

    public static implicit operator Entitlement(Feature value) => new(value);

    public static implicit operator Entitlement(Credit value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="StiggInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new StiggInvalidDataException("Data did not match any variant of Entitlement");
        }
        this.Switch((feature) => feature.Validate(), (credit) => credit.Validate());
    }

    public virtual bool Equals(Entitlement? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            Feature _ => 0,
            Credit _ => 1,
            _ => -1,
        };
    }
}

sealed class EntitlementConverter : JsonConverter<Entitlement>
{
    public override Entitlement? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try
        {
            type = element.GetProperty("type").GetString();
        }
        catch
        {
            type = null;
        }

        switch (type)
        {
            case "FEATURE":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Feature>(element, options);
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "CREDIT":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Credit>(element, options);
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new Entitlement(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        Entitlement value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Feature entitlement configuration for a subscription
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Feature, FeatureFromRaw>))]
public sealed record class Feature : JsonModel
{
    /// <summary>
    /// The feature ID to attach the entitlement to
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
    /// SubscriptionFeatureEntitlementRequest
    /// </summary>
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Whether the usage limit is a soft limit
    /// </summary>
    public bool? HasSoftLimit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("hasSoftLimit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("hasSoftLimit", value);
        }
    }

    /// <summary>
    /// Whether usage is unlimited
    /// </summary>
    public bool? HasUnlimitedUsage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("hasUnlimitedUsage");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("hasUnlimitedUsage", value);
        }
    }

    /// <summary>
    /// Configuration for monthly reset period
    /// </summary>
    public MonthlyResetPeriodConfiguration? MonthlyResetPeriodConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MonthlyResetPeriodConfiguration>(
                "monthlyResetPeriodConfiguration"
            );
        }
        init { this._rawData.Set("monthlyResetPeriodConfiguration", value); }
    }

    /// <summary>
    /// Period at which usage resets
    /// </summary>
    public ApiEnum<string, ResetPeriod>? ResetPeriod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ResetPeriod>>("resetPeriod");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("resetPeriod", value);
        }
    }

    /// <summary>
    /// Maximum allowed usage for the feature
    /// </summary>
    public long? UsageLimit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("usageLimit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("usageLimit", value);
        }
    }

    /// <summary>
    /// Configuration for weekly reset period
    /// </summary>
    public WeeklyResetPeriodConfiguration? WeeklyResetPeriodConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WeeklyResetPeriodConfiguration>(
                "weeklyResetPeriodConfiguration"
            );
        }
        init { this._rawData.Set("weeklyResetPeriodConfiguration", value); }
    }

    /// <summary>
    /// Configuration for yearly reset period
    /// </summary>
    public YearlyResetPeriodConfiguration? YearlyResetPeriodConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<YearlyResetPeriodConfiguration>(
                "yearlyResetPeriodConfiguration"
            );
        }
        init { this._rawData.Set("yearlyResetPeriodConfiguration", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("FEATURE")))
        {
            throw new StiggInvalidDataException("Invalid value given for constant");
        }
        _ = this.HasSoftLimit;
        _ = this.HasUnlimitedUsage;
        this.MonthlyResetPeriodConfiguration?.Validate();
        this.ResetPeriod?.Validate();
        _ = this.UsageLimit;
        this.WeeklyResetPeriodConfiguration?.Validate();
        this.YearlyResetPeriodConfiguration?.Validate();
    }

    public Feature()
    {
        this.Type = JsonSerializer.SerializeToElement("FEATURE");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Feature(Feature feature)
        : base(feature) { }
#pragma warning restore CS8618

    public Feature(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("FEATURE");
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
    public Feature(string id)
        : this()
    {
        this.ID = id;
    }
}

class FeatureFromRaw : IFromRawJson<Feature>
{
    /// <inheritdoc/>
    public Feature FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Feature.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for monthly reset period
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        MonthlyResetPeriodConfiguration,
        MonthlyResetPeriodConfigurationFromRaw
    >)
)]
public sealed record class MonthlyResetPeriodConfiguration : JsonModel
{
    /// <summary>
    /// Reset anchor (SubscriptionStart or StartOfTheMonth)
    /// </summary>
    public required ApiEnum<string, AccordingTo> AccordingTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AccordingTo>>("accordingTo");
        }
        init { this._rawData.Set("accordingTo", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.AccordingTo.Validate();
    }

    public MonthlyResetPeriodConfiguration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MonthlyResetPeriodConfiguration(
        MonthlyResetPeriodConfiguration monthlyResetPeriodConfiguration
    )
        : base(monthlyResetPeriodConfiguration) { }
#pragma warning restore CS8618

    public MonthlyResetPeriodConfiguration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MonthlyResetPeriodConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MonthlyResetPeriodConfigurationFromRaw.FromRawUnchecked"/>
    public static MonthlyResetPeriodConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public MonthlyResetPeriodConfiguration(ApiEnum<string, AccordingTo> accordingTo)
        : this()
    {
        this.AccordingTo = accordingTo;
    }
}

class MonthlyResetPeriodConfigurationFromRaw : IFromRawJson<MonthlyResetPeriodConfiguration>
{
    /// <inheritdoc/>
    public MonthlyResetPeriodConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MonthlyResetPeriodConfiguration.FromRawUnchecked(rawData);
}

/// <summary>
/// Reset anchor (SubscriptionStart or StartOfTheMonth)
/// </summary>
[JsonConverter(typeof(AccordingToConverter))]
public enum AccordingTo
{
    SubscriptionStart,
    StartOfTheMonth,
}

sealed class AccordingToConverter : JsonConverter<AccordingTo>
{
    public override AccordingTo Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SubscriptionStart" => AccordingTo.SubscriptionStart,
            "StartOfTheMonth" => AccordingTo.StartOfTheMonth,
            _ => (AccordingTo)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AccordingTo value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AccordingTo.SubscriptionStart => "SubscriptionStart",
                AccordingTo.StartOfTheMonth => "StartOfTheMonth",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Period at which usage resets
/// </summary>
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
/// Configuration for weekly reset period
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        WeeklyResetPeriodConfiguration,
        WeeklyResetPeriodConfigurationFromRaw
    >)
)]
public sealed record class WeeklyResetPeriodConfiguration : JsonModel
{
    /// <summary>
    /// Reset anchor (SubscriptionStart or specific day)
    /// </summary>
    public required ApiEnum<string, WeeklyResetPeriodConfigurationAccordingTo> AccordingTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, WeeklyResetPeriodConfigurationAccordingTo>
            >("accordingTo");
        }
        init { this._rawData.Set("accordingTo", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.AccordingTo.Validate();
    }

    public WeeklyResetPeriodConfiguration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WeeklyResetPeriodConfiguration(
        WeeklyResetPeriodConfiguration weeklyResetPeriodConfiguration
    )
        : base(weeklyResetPeriodConfiguration) { }
#pragma warning restore CS8618

    public WeeklyResetPeriodConfiguration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WeeklyResetPeriodConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WeeklyResetPeriodConfigurationFromRaw.FromRawUnchecked"/>
    public static WeeklyResetPeriodConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public WeeklyResetPeriodConfiguration(
        ApiEnum<string, WeeklyResetPeriodConfigurationAccordingTo> accordingTo
    )
        : this()
    {
        this.AccordingTo = accordingTo;
    }
}

class WeeklyResetPeriodConfigurationFromRaw : IFromRawJson<WeeklyResetPeriodConfiguration>
{
    /// <inheritdoc/>
    public WeeklyResetPeriodConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WeeklyResetPeriodConfiguration.FromRawUnchecked(rawData);
}

/// <summary>
/// Reset anchor (SubscriptionStart or specific day)
/// </summary>
[JsonConverter(typeof(WeeklyResetPeriodConfigurationAccordingToConverter))]
public enum WeeklyResetPeriodConfigurationAccordingTo
{
    SubscriptionStart,
    EverySunday,
    EveryMonday,
    EveryTuesday,
    EveryWednesday,
    EveryThursday,
    EveryFriday,
    EverySaturday,
}

sealed class WeeklyResetPeriodConfigurationAccordingToConverter
    : JsonConverter<WeeklyResetPeriodConfigurationAccordingTo>
{
    public override WeeklyResetPeriodConfigurationAccordingTo Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SubscriptionStart" => WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart,
            "EverySunday" => WeeklyResetPeriodConfigurationAccordingTo.EverySunday,
            "EveryMonday" => WeeklyResetPeriodConfigurationAccordingTo.EveryMonday,
            "EveryTuesday" => WeeklyResetPeriodConfigurationAccordingTo.EveryTuesday,
            "EveryWednesday" => WeeklyResetPeriodConfigurationAccordingTo.EveryWednesday,
            "EveryThursday" => WeeklyResetPeriodConfigurationAccordingTo.EveryThursday,
            "EveryFriday" => WeeklyResetPeriodConfigurationAccordingTo.EveryFriday,
            "EverySaturday" => WeeklyResetPeriodConfigurationAccordingTo.EverySaturday,
            _ => (WeeklyResetPeriodConfigurationAccordingTo)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WeeklyResetPeriodConfigurationAccordingTo value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart => "SubscriptionStart",
                WeeklyResetPeriodConfigurationAccordingTo.EverySunday => "EverySunday",
                WeeklyResetPeriodConfigurationAccordingTo.EveryMonday => "EveryMonday",
                WeeklyResetPeriodConfigurationAccordingTo.EveryTuesday => "EveryTuesday",
                WeeklyResetPeriodConfigurationAccordingTo.EveryWednesday => "EveryWednesday",
                WeeklyResetPeriodConfigurationAccordingTo.EveryThursday => "EveryThursday",
                WeeklyResetPeriodConfigurationAccordingTo.EveryFriday => "EveryFriday",
                WeeklyResetPeriodConfigurationAccordingTo.EverySaturday => "EverySaturday",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Configuration for yearly reset period
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        YearlyResetPeriodConfiguration,
        YearlyResetPeriodConfigurationFromRaw
    >)
)]
public sealed record class YearlyResetPeriodConfiguration : JsonModel
{
    /// <summary>
    /// Reset anchor (SubscriptionStart)
    /// </summary>
    public required ApiEnum<string, YearlyResetPeriodConfigurationAccordingTo> AccordingTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, YearlyResetPeriodConfigurationAccordingTo>
            >("accordingTo");
        }
        init { this._rawData.Set("accordingTo", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.AccordingTo.Validate();
    }

    public YearlyResetPeriodConfiguration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public YearlyResetPeriodConfiguration(
        YearlyResetPeriodConfiguration yearlyResetPeriodConfiguration
    )
        : base(yearlyResetPeriodConfiguration) { }
#pragma warning restore CS8618

    public YearlyResetPeriodConfiguration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    YearlyResetPeriodConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="YearlyResetPeriodConfigurationFromRaw.FromRawUnchecked"/>
    public static YearlyResetPeriodConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public YearlyResetPeriodConfiguration(
        ApiEnum<string, YearlyResetPeriodConfigurationAccordingTo> accordingTo
    )
        : this()
    {
        this.AccordingTo = accordingTo;
    }
}

class YearlyResetPeriodConfigurationFromRaw : IFromRawJson<YearlyResetPeriodConfiguration>
{
    /// <inheritdoc/>
    public YearlyResetPeriodConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => YearlyResetPeriodConfiguration.FromRawUnchecked(rawData);
}

/// <summary>
/// Reset anchor (SubscriptionStart)
/// </summary>
[JsonConverter(typeof(YearlyResetPeriodConfigurationAccordingToConverter))]
public enum YearlyResetPeriodConfigurationAccordingTo
{
    SubscriptionStart,
}

sealed class YearlyResetPeriodConfigurationAccordingToConverter
    : JsonConverter<YearlyResetPeriodConfigurationAccordingTo>
{
    public override YearlyResetPeriodConfigurationAccordingTo Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SubscriptionStart" => YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
            _ => (YearlyResetPeriodConfigurationAccordingTo)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        YearlyResetPeriodConfigurationAccordingTo value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart => "SubscriptionStart",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Credit entitlement configuration for a subscription
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Credit, CreditFromRaw>))]
public sealed record class Credit : JsonModel
{
    /// <summary>
    /// The custom currency ID for the credit entitlement
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
    /// Credit grant amount
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
    /// Credit grant cadence (MONTH or YEAR)
    /// </summary>
    public required ApiEnum<string, Cadence> Cadence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Cadence>>("cadence");
        }
        init { this._rawData.Set("cadence", value); }
    }

    /// <summary>
    /// SubscriptionCreditEntitlementRequest
    /// </summary>
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Whether the credit balance is a soft limit
    /// </summary>
    public bool? HasSoftLimit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("hasSoftLimit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("hasSoftLimit", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Amount;
        this.Cadence.Validate();
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("CREDIT")))
        {
            throw new StiggInvalidDataException("Invalid value given for constant");
        }
        _ = this.HasSoftLimit;
    }

    public Credit()
    {
        this.Type = JsonSerializer.SerializeToElement("CREDIT");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Credit(Credit credit)
        : base(credit) { }
#pragma warning restore CS8618

    public Credit(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("CREDIT");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Credit(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreditFromRaw.FromRawUnchecked"/>
    public static Credit FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreditFromRaw : IFromRawJson<Credit>
{
    /// <inheritdoc/>
    public Credit FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Credit.FromRawUnchecked(rawData);
}

/// <summary>
/// Credit grant cadence (MONTH or YEAR)
/// </summary>
[JsonConverter(typeof(CadenceConverter))]
public enum Cadence
{
    Month,
    Year,
}

sealed class CadenceConverter : JsonConverter<Cadence>
{
    public override Cadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "MONTH" => Cadence.Month,
            "YEAR" => Cadence.Year,
            _ => (Cadence)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Cadence value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Cadence.Month => "MONTH",
                Cadence.Year => "YEAR",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Minimum spend amount
/// </summary>
[JsonConverter(typeof(JsonModelConverter<MinimumSpend, MinimumSpendFromRaw>))]
public sealed record class MinimumSpend : JsonModel
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
    public ApiEnum<string, MinimumSpendCurrency>? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, MinimumSpendCurrency>>(
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

    public MinimumSpend() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MinimumSpend(MinimumSpend minimumSpend)
        : base(minimumSpend) { }
#pragma warning restore CS8618

    public MinimumSpend(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MinimumSpend(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MinimumSpendFromRaw.FromRawUnchecked"/>
    public static MinimumSpend FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MinimumSpendFromRaw : IFromRawJson<MinimumSpend>
{
    /// <inheritdoc/>
    public MinimumSpend FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MinimumSpend.FromRawUnchecked(rawData);
}

/// <summary>
/// The price currency
/// </summary>
[JsonConverter(typeof(MinimumSpendCurrencyConverter))]
public enum MinimumSpendCurrency
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

sealed class MinimumSpendCurrencyConverter : JsonConverter<MinimumSpendCurrency>
{
    public override MinimumSpendCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => MinimumSpendCurrency.Usd,
            "aed" => MinimumSpendCurrency.Aed,
            "all" => MinimumSpendCurrency.All,
            "amd" => MinimumSpendCurrency.Amd,
            "ang" => MinimumSpendCurrency.Ang,
            "aud" => MinimumSpendCurrency.Aud,
            "awg" => MinimumSpendCurrency.Awg,
            "azn" => MinimumSpendCurrency.Azn,
            "bam" => MinimumSpendCurrency.Bam,
            "bbd" => MinimumSpendCurrency.Bbd,
            "bdt" => MinimumSpendCurrency.Bdt,
            "bgn" => MinimumSpendCurrency.Bgn,
            "bif" => MinimumSpendCurrency.Bif,
            "bmd" => MinimumSpendCurrency.Bmd,
            "bnd" => MinimumSpendCurrency.Bnd,
            "bsd" => MinimumSpendCurrency.Bsd,
            "bwp" => MinimumSpendCurrency.Bwp,
            "byn" => MinimumSpendCurrency.Byn,
            "bzd" => MinimumSpendCurrency.Bzd,
            "brl" => MinimumSpendCurrency.Brl,
            "cad" => MinimumSpendCurrency.Cad,
            "cdf" => MinimumSpendCurrency.Cdf,
            "chf" => MinimumSpendCurrency.Chf,
            "cny" => MinimumSpendCurrency.Cny,
            "czk" => MinimumSpendCurrency.Czk,
            "dkk" => MinimumSpendCurrency.Dkk,
            "dop" => MinimumSpendCurrency.Dop,
            "dzd" => MinimumSpendCurrency.Dzd,
            "egp" => MinimumSpendCurrency.Egp,
            "etb" => MinimumSpendCurrency.Etb,
            "eur" => MinimumSpendCurrency.Eur,
            "fjd" => MinimumSpendCurrency.Fjd,
            "gbp" => MinimumSpendCurrency.Gbp,
            "gel" => MinimumSpendCurrency.Gel,
            "gip" => MinimumSpendCurrency.Gip,
            "gmd" => MinimumSpendCurrency.Gmd,
            "gyd" => MinimumSpendCurrency.Gyd,
            "hkd" => MinimumSpendCurrency.Hkd,
            "hrk" => MinimumSpendCurrency.Hrk,
            "htg" => MinimumSpendCurrency.Htg,
            "idr" => MinimumSpendCurrency.Idr,
            "ils" => MinimumSpendCurrency.Ils,
            "inr" => MinimumSpendCurrency.Inr,
            "isk" => MinimumSpendCurrency.Isk,
            "jmd" => MinimumSpendCurrency.Jmd,
            "jpy" => MinimumSpendCurrency.Jpy,
            "kes" => MinimumSpendCurrency.Kes,
            "kgs" => MinimumSpendCurrency.Kgs,
            "khr" => MinimumSpendCurrency.Khr,
            "kmf" => MinimumSpendCurrency.Kmf,
            "krw" => MinimumSpendCurrency.Krw,
            "kyd" => MinimumSpendCurrency.Kyd,
            "kzt" => MinimumSpendCurrency.Kzt,
            "lbp" => MinimumSpendCurrency.Lbp,
            "lkr" => MinimumSpendCurrency.Lkr,
            "lrd" => MinimumSpendCurrency.Lrd,
            "lsl" => MinimumSpendCurrency.Lsl,
            "mad" => MinimumSpendCurrency.Mad,
            "mdl" => MinimumSpendCurrency.Mdl,
            "mga" => MinimumSpendCurrency.Mga,
            "mkd" => MinimumSpendCurrency.Mkd,
            "mmk" => MinimumSpendCurrency.Mmk,
            "mnt" => MinimumSpendCurrency.Mnt,
            "mop" => MinimumSpendCurrency.Mop,
            "mro" => MinimumSpendCurrency.Mro,
            "mvr" => MinimumSpendCurrency.Mvr,
            "mwk" => MinimumSpendCurrency.Mwk,
            "mxn" => MinimumSpendCurrency.Mxn,
            "myr" => MinimumSpendCurrency.Myr,
            "mzn" => MinimumSpendCurrency.Mzn,
            "nad" => MinimumSpendCurrency.Nad,
            "ngn" => MinimumSpendCurrency.Ngn,
            "nok" => MinimumSpendCurrency.Nok,
            "npr" => MinimumSpendCurrency.Npr,
            "nzd" => MinimumSpendCurrency.Nzd,
            "pgk" => MinimumSpendCurrency.Pgk,
            "php" => MinimumSpendCurrency.Php,
            "pkr" => MinimumSpendCurrency.Pkr,
            "pln" => MinimumSpendCurrency.Pln,
            "qar" => MinimumSpendCurrency.Qar,
            "ron" => MinimumSpendCurrency.Ron,
            "rsd" => MinimumSpendCurrency.Rsd,
            "rub" => MinimumSpendCurrency.Rub,
            "rwf" => MinimumSpendCurrency.Rwf,
            "sar" => MinimumSpendCurrency.Sar,
            "sbd" => MinimumSpendCurrency.Sbd,
            "scr" => MinimumSpendCurrency.Scr,
            "sek" => MinimumSpendCurrency.Sek,
            "sgd" => MinimumSpendCurrency.Sgd,
            "sle" => MinimumSpendCurrency.Sle,
            "sll" => MinimumSpendCurrency.Sll,
            "sos" => MinimumSpendCurrency.Sos,
            "szl" => MinimumSpendCurrency.Szl,
            "thb" => MinimumSpendCurrency.Thb,
            "tjs" => MinimumSpendCurrency.Tjs,
            "top" => MinimumSpendCurrency.Top,
            "try" => MinimumSpendCurrency.Try,
            "ttd" => MinimumSpendCurrency.Ttd,
            "tzs" => MinimumSpendCurrency.Tzs,
            "uah" => MinimumSpendCurrency.Uah,
            "uzs" => MinimumSpendCurrency.Uzs,
            "vnd" => MinimumSpendCurrency.Vnd,
            "vuv" => MinimumSpendCurrency.Vuv,
            "wst" => MinimumSpendCurrency.Wst,
            "xaf" => MinimumSpendCurrency.Xaf,
            "xcd" => MinimumSpendCurrency.Xcd,
            "yer" => MinimumSpendCurrency.Yer,
            "zar" => MinimumSpendCurrency.Zar,
            "zmw" => MinimumSpendCurrency.Zmw,
            "clp" => MinimumSpendCurrency.Clp,
            "djf" => MinimumSpendCurrency.Djf,
            "gnf" => MinimumSpendCurrency.Gnf,
            "ugx" => MinimumSpendCurrency.Ugx,
            "pyg" => MinimumSpendCurrency.Pyg,
            "xof" => MinimumSpendCurrency.Xof,
            "xpf" => MinimumSpendCurrency.Xpf,
            _ => (MinimumSpendCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MinimumSpendCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MinimumSpendCurrency.Usd => "usd",
                MinimumSpendCurrency.Aed => "aed",
                MinimumSpendCurrency.All => "all",
                MinimumSpendCurrency.Amd => "amd",
                MinimumSpendCurrency.Ang => "ang",
                MinimumSpendCurrency.Aud => "aud",
                MinimumSpendCurrency.Awg => "awg",
                MinimumSpendCurrency.Azn => "azn",
                MinimumSpendCurrency.Bam => "bam",
                MinimumSpendCurrency.Bbd => "bbd",
                MinimumSpendCurrency.Bdt => "bdt",
                MinimumSpendCurrency.Bgn => "bgn",
                MinimumSpendCurrency.Bif => "bif",
                MinimumSpendCurrency.Bmd => "bmd",
                MinimumSpendCurrency.Bnd => "bnd",
                MinimumSpendCurrency.Bsd => "bsd",
                MinimumSpendCurrency.Bwp => "bwp",
                MinimumSpendCurrency.Byn => "byn",
                MinimumSpendCurrency.Bzd => "bzd",
                MinimumSpendCurrency.Brl => "brl",
                MinimumSpendCurrency.Cad => "cad",
                MinimumSpendCurrency.Cdf => "cdf",
                MinimumSpendCurrency.Chf => "chf",
                MinimumSpendCurrency.Cny => "cny",
                MinimumSpendCurrency.Czk => "czk",
                MinimumSpendCurrency.Dkk => "dkk",
                MinimumSpendCurrency.Dop => "dop",
                MinimumSpendCurrency.Dzd => "dzd",
                MinimumSpendCurrency.Egp => "egp",
                MinimumSpendCurrency.Etb => "etb",
                MinimumSpendCurrency.Eur => "eur",
                MinimumSpendCurrency.Fjd => "fjd",
                MinimumSpendCurrency.Gbp => "gbp",
                MinimumSpendCurrency.Gel => "gel",
                MinimumSpendCurrency.Gip => "gip",
                MinimumSpendCurrency.Gmd => "gmd",
                MinimumSpendCurrency.Gyd => "gyd",
                MinimumSpendCurrency.Hkd => "hkd",
                MinimumSpendCurrency.Hrk => "hrk",
                MinimumSpendCurrency.Htg => "htg",
                MinimumSpendCurrency.Idr => "idr",
                MinimumSpendCurrency.Ils => "ils",
                MinimumSpendCurrency.Inr => "inr",
                MinimumSpendCurrency.Isk => "isk",
                MinimumSpendCurrency.Jmd => "jmd",
                MinimumSpendCurrency.Jpy => "jpy",
                MinimumSpendCurrency.Kes => "kes",
                MinimumSpendCurrency.Kgs => "kgs",
                MinimumSpendCurrency.Khr => "khr",
                MinimumSpendCurrency.Kmf => "kmf",
                MinimumSpendCurrency.Krw => "krw",
                MinimumSpendCurrency.Kyd => "kyd",
                MinimumSpendCurrency.Kzt => "kzt",
                MinimumSpendCurrency.Lbp => "lbp",
                MinimumSpendCurrency.Lkr => "lkr",
                MinimumSpendCurrency.Lrd => "lrd",
                MinimumSpendCurrency.Lsl => "lsl",
                MinimumSpendCurrency.Mad => "mad",
                MinimumSpendCurrency.Mdl => "mdl",
                MinimumSpendCurrency.Mga => "mga",
                MinimumSpendCurrency.Mkd => "mkd",
                MinimumSpendCurrency.Mmk => "mmk",
                MinimumSpendCurrency.Mnt => "mnt",
                MinimumSpendCurrency.Mop => "mop",
                MinimumSpendCurrency.Mro => "mro",
                MinimumSpendCurrency.Mvr => "mvr",
                MinimumSpendCurrency.Mwk => "mwk",
                MinimumSpendCurrency.Mxn => "mxn",
                MinimumSpendCurrency.Myr => "myr",
                MinimumSpendCurrency.Mzn => "mzn",
                MinimumSpendCurrency.Nad => "nad",
                MinimumSpendCurrency.Ngn => "ngn",
                MinimumSpendCurrency.Nok => "nok",
                MinimumSpendCurrency.Npr => "npr",
                MinimumSpendCurrency.Nzd => "nzd",
                MinimumSpendCurrency.Pgk => "pgk",
                MinimumSpendCurrency.Php => "php",
                MinimumSpendCurrency.Pkr => "pkr",
                MinimumSpendCurrency.Pln => "pln",
                MinimumSpendCurrency.Qar => "qar",
                MinimumSpendCurrency.Ron => "ron",
                MinimumSpendCurrency.Rsd => "rsd",
                MinimumSpendCurrency.Rub => "rub",
                MinimumSpendCurrency.Rwf => "rwf",
                MinimumSpendCurrency.Sar => "sar",
                MinimumSpendCurrency.Sbd => "sbd",
                MinimumSpendCurrency.Scr => "scr",
                MinimumSpendCurrency.Sek => "sek",
                MinimumSpendCurrency.Sgd => "sgd",
                MinimumSpendCurrency.Sle => "sle",
                MinimumSpendCurrency.Sll => "sll",
                MinimumSpendCurrency.Sos => "sos",
                MinimumSpendCurrency.Szl => "szl",
                MinimumSpendCurrency.Thb => "thb",
                MinimumSpendCurrency.Tjs => "tjs",
                MinimumSpendCurrency.Top => "top",
                MinimumSpendCurrency.Try => "try",
                MinimumSpendCurrency.Ttd => "ttd",
                MinimumSpendCurrency.Tzs => "tzs",
                MinimumSpendCurrency.Uah => "uah",
                MinimumSpendCurrency.Uzs => "uzs",
                MinimumSpendCurrency.Vnd => "vnd",
                MinimumSpendCurrency.Vuv => "vuv",
                MinimumSpendCurrency.Wst => "wst",
                MinimumSpendCurrency.Xaf => "xaf",
                MinimumSpendCurrency.Xcd => "xcd",
                MinimumSpendCurrency.Yer => "yer",
                MinimumSpendCurrency.Zar => "zar",
                MinimumSpendCurrency.Zmw => "zmw",
                MinimumSpendCurrency.Clp => "clp",
                MinimumSpendCurrency.Djf => "djf",
                MinimumSpendCurrency.Gnf => "gnf",
                MinimumSpendCurrency.Ugx => "ugx",
                MinimumSpendCurrency.Pyg => "pyg",
                MinimumSpendCurrency.Xof => "xof",
                MinimumSpendCurrency.Xpf => "xpf",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// How payments should be collected for this subscription
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

[JsonConverter(typeof(JsonModelConverter<PriceOverride, PriceOverrideFromRaw>))]
public sealed record class PriceOverride : JsonModel
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
    /// ISO 3166-1 alpha-2 country code this price applies to. Omit for the default
    /// price shown to all countries; set one or more country-specific price periods
    /// on the same currency to localize the amount by billing country.
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

    public ApiEnum<string, CreditGrantCadence>? CreditGrantCadence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CreditGrantCadence>>(
                "creditGrantCadence"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("creditGrantCadence", value);
        }
    }

    public CreditRate? CreditRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CreditRate>("creditRate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("creditRate", value);
        }
    }

    /// <summary>
    /// The price currency
    /// </summary>
    public ApiEnum<string, PriceOverrideCurrency>? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PriceOverrideCurrency>>(
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
    public IReadOnlyList<Tier>? Tiers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Tier>>("tiers");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Tier>?>(
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
        this.CreditGrantCadence?.Validate();
        this.CreditRate?.Validate();
        this.Currency?.Validate();
        _ = this.FeatureID;
        foreach (var item in this.Tiers ?? [])
        {
            item.Validate();
        }
    }

    public PriceOverride() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PriceOverride(PriceOverride priceOverride)
        : base(priceOverride) { }
#pragma warning restore CS8618

    public PriceOverride(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PriceOverride(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PriceOverrideFromRaw.FromRawUnchecked"/>
    public static PriceOverride FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PriceOverrideFromRaw : IFromRawJson<PriceOverride>
{
    /// <inheritdoc/>
    public PriceOverride FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PriceOverride.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(CreditGrantCadenceConverter))]
public enum CreditGrantCadence
{
    BeginningOfBillingPeriod,
    Monthly,
}

sealed class CreditGrantCadenceConverter : JsonConverter<CreditGrantCadence>
{
    public override CreditGrantCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "BEGINNING_OF_BILLING_PERIOD" => CreditGrantCadence.BeginningOfBillingPeriod,
            "MONTHLY" => CreditGrantCadence.Monthly,
            _ => (CreditGrantCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CreditGrantCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CreditGrantCadence.BeginningOfBillingPeriod => "BEGINNING_OF_BILLING_PERIOD",
                CreditGrantCadence.Monthly => "MONTHLY",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<CreditRate, CreditRateFromRaw>))]
public sealed record class CreditRate : JsonModel
{
    /// <summary>
    /// The credit rate amount
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
    /// The custom currency refId for the credit rate
    /// </summary>
    public required string CurrencyID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("currencyId");
        }
        init { this._rawData.Set("currencyId", value); }
    }

    /// <summary>
    /// A custom formula for calculating cost based on single event dimensions
    /// </summary>
    public string? CostFormula
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("costFormula");
        }
        init { this._rawData.Set("costFormula", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.CurrencyID;
        _ = this.CostFormula;
    }

    public CreditRate() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreditRate(CreditRate creditRate)
        : base(creditRate) { }
#pragma warning restore CS8618

    public CreditRate(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditRate(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreditRateFromRaw.FromRawUnchecked"/>
    public static CreditRate FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreditRateFromRaw : IFromRawJson<CreditRate>
{
    /// <inheritdoc/>
    public CreditRate FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CreditRate.FromRawUnchecked(rawData);
}

/// <summary>
/// The price currency
/// </summary>
[JsonConverter(typeof(PriceOverrideCurrencyConverter))]
public enum PriceOverrideCurrency
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

sealed class PriceOverrideCurrencyConverter : JsonConverter<PriceOverrideCurrency>
{
    public override PriceOverrideCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => PriceOverrideCurrency.Usd,
            "aed" => PriceOverrideCurrency.Aed,
            "all" => PriceOverrideCurrency.All,
            "amd" => PriceOverrideCurrency.Amd,
            "ang" => PriceOverrideCurrency.Ang,
            "aud" => PriceOverrideCurrency.Aud,
            "awg" => PriceOverrideCurrency.Awg,
            "azn" => PriceOverrideCurrency.Azn,
            "bam" => PriceOverrideCurrency.Bam,
            "bbd" => PriceOverrideCurrency.Bbd,
            "bdt" => PriceOverrideCurrency.Bdt,
            "bgn" => PriceOverrideCurrency.Bgn,
            "bif" => PriceOverrideCurrency.Bif,
            "bmd" => PriceOverrideCurrency.Bmd,
            "bnd" => PriceOverrideCurrency.Bnd,
            "bsd" => PriceOverrideCurrency.Bsd,
            "bwp" => PriceOverrideCurrency.Bwp,
            "byn" => PriceOverrideCurrency.Byn,
            "bzd" => PriceOverrideCurrency.Bzd,
            "brl" => PriceOverrideCurrency.Brl,
            "cad" => PriceOverrideCurrency.Cad,
            "cdf" => PriceOverrideCurrency.Cdf,
            "chf" => PriceOverrideCurrency.Chf,
            "cny" => PriceOverrideCurrency.Cny,
            "czk" => PriceOverrideCurrency.Czk,
            "dkk" => PriceOverrideCurrency.Dkk,
            "dop" => PriceOverrideCurrency.Dop,
            "dzd" => PriceOverrideCurrency.Dzd,
            "egp" => PriceOverrideCurrency.Egp,
            "etb" => PriceOverrideCurrency.Etb,
            "eur" => PriceOverrideCurrency.Eur,
            "fjd" => PriceOverrideCurrency.Fjd,
            "gbp" => PriceOverrideCurrency.Gbp,
            "gel" => PriceOverrideCurrency.Gel,
            "gip" => PriceOverrideCurrency.Gip,
            "gmd" => PriceOverrideCurrency.Gmd,
            "gyd" => PriceOverrideCurrency.Gyd,
            "hkd" => PriceOverrideCurrency.Hkd,
            "hrk" => PriceOverrideCurrency.Hrk,
            "htg" => PriceOverrideCurrency.Htg,
            "idr" => PriceOverrideCurrency.Idr,
            "ils" => PriceOverrideCurrency.Ils,
            "inr" => PriceOverrideCurrency.Inr,
            "isk" => PriceOverrideCurrency.Isk,
            "jmd" => PriceOverrideCurrency.Jmd,
            "jpy" => PriceOverrideCurrency.Jpy,
            "kes" => PriceOverrideCurrency.Kes,
            "kgs" => PriceOverrideCurrency.Kgs,
            "khr" => PriceOverrideCurrency.Khr,
            "kmf" => PriceOverrideCurrency.Kmf,
            "krw" => PriceOverrideCurrency.Krw,
            "kyd" => PriceOverrideCurrency.Kyd,
            "kzt" => PriceOverrideCurrency.Kzt,
            "lbp" => PriceOverrideCurrency.Lbp,
            "lkr" => PriceOverrideCurrency.Lkr,
            "lrd" => PriceOverrideCurrency.Lrd,
            "lsl" => PriceOverrideCurrency.Lsl,
            "mad" => PriceOverrideCurrency.Mad,
            "mdl" => PriceOverrideCurrency.Mdl,
            "mga" => PriceOverrideCurrency.Mga,
            "mkd" => PriceOverrideCurrency.Mkd,
            "mmk" => PriceOverrideCurrency.Mmk,
            "mnt" => PriceOverrideCurrency.Mnt,
            "mop" => PriceOverrideCurrency.Mop,
            "mro" => PriceOverrideCurrency.Mro,
            "mvr" => PriceOverrideCurrency.Mvr,
            "mwk" => PriceOverrideCurrency.Mwk,
            "mxn" => PriceOverrideCurrency.Mxn,
            "myr" => PriceOverrideCurrency.Myr,
            "mzn" => PriceOverrideCurrency.Mzn,
            "nad" => PriceOverrideCurrency.Nad,
            "ngn" => PriceOverrideCurrency.Ngn,
            "nok" => PriceOverrideCurrency.Nok,
            "npr" => PriceOverrideCurrency.Npr,
            "nzd" => PriceOverrideCurrency.Nzd,
            "pgk" => PriceOverrideCurrency.Pgk,
            "php" => PriceOverrideCurrency.Php,
            "pkr" => PriceOverrideCurrency.Pkr,
            "pln" => PriceOverrideCurrency.Pln,
            "qar" => PriceOverrideCurrency.Qar,
            "ron" => PriceOverrideCurrency.Ron,
            "rsd" => PriceOverrideCurrency.Rsd,
            "rub" => PriceOverrideCurrency.Rub,
            "rwf" => PriceOverrideCurrency.Rwf,
            "sar" => PriceOverrideCurrency.Sar,
            "sbd" => PriceOverrideCurrency.Sbd,
            "scr" => PriceOverrideCurrency.Scr,
            "sek" => PriceOverrideCurrency.Sek,
            "sgd" => PriceOverrideCurrency.Sgd,
            "sle" => PriceOverrideCurrency.Sle,
            "sll" => PriceOverrideCurrency.Sll,
            "sos" => PriceOverrideCurrency.Sos,
            "szl" => PriceOverrideCurrency.Szl,
            "thb" => PriceOverrideCurrency.Thb,
            "tjs" => PriceOverrideCurrency.Tjs,
            "top" => PriceOverrideCurrency.Top,
            "try" => PriceOverrideCurrency.Try,
            "ttd" => PriceOverrideCurrency.Ttd,
            "tzs" => PriceOverrideCurrency.Tzs,
            "uah" => PriceOverrideCurrency.Uah,
            "uzs" => PriceOverrideCurrency.Uzs,
            "vnd" => PriceOverrideCurrency.Vnd,
            "vuv" => PriceOverrideCurrency.Vuv,
            "wst" => PriceOverrideCurrency.Wst,
            "xaf" => PriceOverrideCurrency.Xaf,
            "xcd" => PriceOverrideCurrency.Xcd,
            "yer" => PriceOverrideCurrency.Yer,
            "zar" => PriceOverrideCurrency.Zar,
            "zmw" => PriceOverrideCurrency.Zmw,
            "clp" => PriceOverrideCurrency.Clp,
            "djf" => PriceOverrideCurrency.Djf,
            "gnf" => PriceOverrideCurrency.Gnf,
            "ugx" => PriceOverrideCurrency.Ugx,
            "pyg" => PriceOverrideCurrency.Pyg,
            "xof" => PriceOverrideCurrency.Xof,
            "xpf" => PriceOverrideCurrency.Xpf,
            _ => (PriceOverrideCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PriceOverrideCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PriceOverrideCurrency.Usd => "usd",
                PriceOverrideCurrency.Aed => "aed",
                PriceOverrideCurrency.All => "all",
                PriceOverrideCurrency.Amd => "amd",
                PriceOverrideCurrency.Ang => "ang",
                PriceOverrideCurrency.Aud => "aud",
                PriceOverrideCurrency.Awg => "awg",
                PriceOverrideCurrency.Azn => "azn",
                PriceOverrideCurrency.Bam => "bam",
                PriceOverrideCurrency.Bbd => "bbd",
                PriceOverrideCurrency.Bdt => "bdt",
                PriceOverrideCurrency.Bgn => "bgn",
                PriceOverrideCurrency.Bif => "bif",
                PriceOverrideCurrency.Bmd => "bmd",
                PriceOverrideCurrency.Bnd => "bnd",
                PriceOverrideCurrency.Bsd => "bsd",
                PriceOverrideCurrency.Bwp => "bwp",
                PriceOverrideCurrency.Byn => "byn",
                PriceOverrideCurrency.Bzd => "bzd",
                PriceOverrideCurrency.Brl => "brl",
                PriceOverrideCurrency.Cad => "cad",
                PriceOverrideCurrency.Cdf => "cdf",
                PriceOverrideCurrency.Chf => "chf",
                PriceOverrideCurrency.Cny => "cny",
                PriceOverrideCurrency.Czk => "czk",
                PriceOverrideCurrency.Dkk => "dkk",
                PriceOverrideCurrency.Dop => "dop",
                PriceOverrideCurrency.Dzd => "dzd",
                PriceOverrideCurrency.Egp => "egp",
                PriceOverrideCurrency.Etb => "etb",
                PriceOverrideCurrency.Eur => "eur",
                PriceOverrideCurrency.Fjd => "fjd",
                PriceOverrideCurrency.Gbp => "gbp",
                PriceOverrideCurrency.Gel => "gel",
                PriceOverrideCurrency.Gip => "gip",
                PriceOverrideCurrency.Gmd => "gmd",
                PriceOverrideCurrency.Gyd => "gyd",
                PriceOverrideCurrency.Hkd => "hkd",
                PriceOverrideCurrency.Hrk => "hrk",
                PriceOverrideCurrency.Htg => "htg",
                PriceOverrideCurrency.Idr => "idr",
                PriceOverrideCurrency.Ils => "ils",
                PriceOverrideCurrency.Inr => "inr",
                PriceOverrideCurrency.Isk => "isk",
                PriceOverrideCurrency.Jmd => "jmd",
                PriceOverrideCurrency.Jpy => "jpy",
                PriceOverrideCurrency.Kes => "kes",
                PriceOverrideCurrency.Kgs => "kgs",
                PriceOverrideCurrency.Khr => "khr",
                PriceOverrideCurrency.Kmf => "kmf",
                PriceOverrideCurrency.Krw => "krw",
                PriceOverrideCurrency.Kyd => "kyd",
                PriceOverrideCurrency.Kzt => "kzt",
                PriceOverrideCurrency.Lbp => "lbp",
                PriceOverrideCurrency.Lkr => "lkr",
                PriceOverrideCurrency.Lrd => "lrd",
                PriceOverrideCurrency.Lsl => "lsl",
                PriceOverrideCurrency.Mad => "mad",
                PriceOverrideCurrency.Mdl => "mdl",
                PriceOverrideCurrency.Mga => "mga",
                PriceOverrideCurrency.Mkd => "mkd",
                PriceOverrideCurrency.Mmk => "mmk",
                PriceOverrideCurrency.Mnt => "mnt",
                PriceOverrideCurrency.Mop => "mop",
                PriceOverrideCurrency.Mro => "mro",
                PriceOverrideCurrency.Mvr => "mvr",
                PriceOverrideCurrency.Mwk => "mwk",
                PriceOverrideCurrency.Mxn => "mxn",
                PriceOverrideCurrency.Myr => "myr",
                PriceOverrideCurrency.Mzn => "mzn",
                PriceOverrideCurrency.Nad => "nad",
                PriceOverrideCurrency.Ngn => "ngn",
                PriceOverrideCurrency.Nok => "nok",
                PriceOverrideCurrency.Npr => "npr",
                PriceOverrideCurrency.Nzd => "nzd",
                PriceOverrideCurrency.Pgk => "pgk",
                PriceOverrideCurrency.Php => "php",
                PriceOverrideCurrency.Pkr => "pkr",
                PriceOverrideCurrency.Pln => "pln",
                PriceOverrideCurrency.Qar => "qar",
                PriceOverrideCurrency.Ron => "ron",
                PriceOverrideCurrency.Rsd => "rsd",
                PriceOverrideCurrency.Rub => "rub",
                PriceOverrideCurrency.Rwf => "rwf",
                PriceOverrideCurrency.Sar => "sar",
                PriceOverrideCurrency.Sbd => "sbd",
                PriceOverrideCurrency.Scr => "scr",
                PriceOverrideCurrency.Sek => "sek",
                PriceOverrideCurrency.Sgd => "sgd",
                PriceOverrideCurrency.Sle => "sle",
                PriceOverrideCurrency.Sll => "sll",
                PriceOverrideCurrency.Sos => "sos",
                PriceOverrideCurrency.Szl => "szl",
                PriceOverrideCurrency.Thb => "thb",
                PriceOverrideCurrency.Tjs => "tjs",
                PriceOverrideCurrency.Top => "top",
                PriceOverrideCurrency.Try => "try",
                PriceOverrideCurrency.Ttd => "ttd",
                PriceOverrideCurrency.Tzs => "tzs",
                PriceOverrideCurrency.Uah => "uah",
                PriceOverrideCurrency.Uzs => "uzs",
                PriceOverrideCurrency.Vnd => "vnd",
                PriceOverrideCurrency.Vuv => "vuv",
                PriceOverrideCurrency.Wst => "wst",
                PriceOverrideCurrency.Xaf => "xaf",
                PriceOverrideCurrency.Xcd => "xcd",
                PriceOverrideCurrency.Yer => "yer",
                PriceOverrideCurrency.Zar => "zar",
                PriceOverrideCurrency.Zmw => "zmw",
                PriceOverrideCurrency.Clp => "clp",
                PriceOverrideCurrency.Djf => "djf",
                PriceOverrideCurrency.Gnf => "gnf",
                PriceOverrideCurrency.Ugx => "ugx",
                PriceOverrideCurrency.Pyg => "pyg",
                PriceOverrideCurrency.Xof => "xof",
                PriceOverrideCurrency.Xpf => "xpf",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<Tier, TierFromRaw>))]
public sealed record class Tier : JsonModel
{
    /// <summary>
    /// The flat fee price of the price tier
    /// </summary>
    public FlatPrice? FlatPrice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FlatPrice>("flatPrice");
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
    public UnitPrice? UnitPrice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UnitPrice>("unitPrice");
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

    public Tier() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Tier(Tier tier)
        : base(tier) { }
#pragma warning restore CS8618

    public Tier(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Tier(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TierFromRaw.FromRawUnchecked"/>
    public static Tier FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TierFromRaw : IFromRawJson<Tier>
{
    /// <inheritdoc/>
    public Tier FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Tier.FromRawUnchecked(rawData);
}

/// <summary>
/// The flat fee price of the price tier
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FlatPrice, FlatPriceFromRaw>))]
public sealed record class FlatPrice : JsonModel
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
    public required ApiEnum<string, FlatPriceCurrency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, FlatPriceCurrency>>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        this.Currency.Validate();
    }

    public FlatPrice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FlatPrice(FlatPrice flatPrice)
        : base(flatPrice) { }
#pragma warning restore CS8618

    public FlatPrice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FlatPrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FlatPriceFromRaw.FromRawUnchecked"/>
    public static FlatPrice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FlatPriceFromRaw : IFromRawJson<FlatPrice>
{
    /// <inheritdoc/>
    public FlatPrice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FlatPrice.FromRawUnchecked(rawData);
}

/// <summary>
/// ISO 4217 currency code
/// </summary>
[JsonConverter(typeof(FlatPriceCurrencyConverter))]
public enum FlatPriceCurrency
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

sealed class FlatPriceCurrencyConverter : JsonConverter<FlatPriceCurrency>
{
    public override FlatPriceCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => FlatPriceCurrency.Usd,
            "aed" => FlatPriceCurrency.Aed,
            "all" => FlatPriceCurrency.All,
            "amd" => FlatPriceCurrency.Amd,
            "ang" => FlatPriceCurrency.Ang,
            "aud" => FlatPriceCurrency.Aud,
            "awg" => FlatPriceCurrency.Awg,
            "azn" => FlatPriceCurrency.Azn,
            "bam" => FlatPriceCurrency.Bam,
            "bbd" => FlatPriceCurrency.Bbd,
            "bdt" => FlatPriceCurrency.Bdt,
            "bgn" => FlatPriceCurrency.Bgn,
            "bif" => FlatPriceCurrency.Bif,
            "bmd" => FlatPriceCurrency.Bmd,
            "bnd" => FlatPriceCurrency.Bnd,
            "bsd" => FlatPriceCurrency.Bsd,
            "bwp" => FlatPriceCurrency.Bwp,
            "byn" => FlatPriceCurrency.Byn,
            "bzd" => FlatPriceCurrency.Bzd,
            "brl" => FlatPriceCurrency.Brl,
            "cad" => FlatPriceCurrency.Cad,
            "cdf" => FlatPriceCurrency.Cdf,
            "chf" => FlatPriceCurrency.Chf,
            "cny" => FlatPriceCurrency.Cny,
            "czk" => FlatPriceCurrency.Czk,
            "dkk" => FlatPriceCurrency.Dkk,
            "dop" => FlatPriceCurrency.Dop,
            "dzd" => FlatPriceCurrency.Dzd,
            "egp" => FlatPriceCurrency.Egp,
            "etb" => FlatPriceCurrency.Etb,
            "eur" => FlatPriceCurrency.Eur,
            "fjd" => FlatPriceCurrency.Fjd,
            "gbp" => FlatPriceCurrency.Gbp,
            "gel" => FlatPriceCurrency.Gel,
            "gip" => FlatPriceCurrency.Gip,
            "gmd" => FlatPriceCurrency.Gmd,
            "gyd" => FlatPriceCurrency.Gyd,
            "hkd" => FlatPriceCurrency.Hkd,
            "hrk" => FlatPriceCurrency.Hrk,
            "htg" => FlatPriceCurrency.Htg,
            "idr" => FlatPriceCurrency.Idr,
            "ils" => FlatPriceCurrency.Ils,
            "inr" => FlatPriceCurrency.Inr,
            "isk" => FlatPriceCurrency.Isk,
            "jmd" => FlatPriceCurrency.Jmd,
            "jpy" => FlatPriceCurrency.Jpy,
            "kes" => FlatPriceCurrency.Kes,
            "kgs" => FlatPriceCurrency.Kgs,
            "khr" => FlatPriceCurrency.Khr,
            "kmf" => FlatPriceCurrency.Kmf,
            "krw" => FlatPriceCurrency.Krw,
            "kyd" => FlatPriceCurrency.Kyd,
            "kzt" => FlatPriceCurrency.Kzt,
            "lbp" => FlatPriceCurrency.Lbp,
            "lkr" => FlatPriceCurrency.Lkr,
            "lrd" => FlatPriceCurrency.Lrd,
            "lsl" => FlatPriceCurrency.Lsl,
            "mad" => FlatPriceCurrency.Mad,
            "mdl" => FlatPriceCurrency.Mdl,
            "mga" => FlatPriceCurrency.Mga,
            "mkd" => FlatPriceCurrency.Mkd,
            "mmk" => FlatPriceCurrency.Mmk,
            "mnt" => FlatPriceCurrency.Mnt,
            "mop" => FlatPriceCurrency.Mop,
            "mro" => FlatPriceCurrency.Mro,
            "mvr" => FlatPriceCurrency.Mvr,
            "mwk" => FlatPriceCurrency.Mwk,
            "mxn" => FlatPriceCurrency.Mxn,
            "myr" => FlatPriceCurrency.Myr,
            "mzn" => FlatPriceCurrency.Mzn,
            "nad" => FlatPriceCurrency.Nad,
            "ngn" => FlatPriceCurrency.Ngn,
            "nok" => FlatPriceCurrency.Nok,
            "npr" => FlatPriceCurrency.Npr,
            "nzd" => FlatPriceCurrency.Nzd,
            "pgk" => FlatPriceCurrency.Pgk,
            "php" => FlatPriceCurrency.Php,
            "pkr" => FlatPriceCurrency.Pkr,
            "pln" => FlatPriceCurrency.Pln,
            "qar" => FlatPriceCurrency.Qar,
            "ron" => FlatPriceCurrency.Ron,
            "rsd" => FlatPriceCurrency.Rsd,
            "rub" => FlatPriceCurrency.Rub,
            "rwf" => FlatPriceCurrency.Rwf,
            "sar" => FlatPriceCurrency.Sar,
            "sbd" => FlatPriceCurrency.Sbd,
            "scr" => FlatPriceCurrency.Scr,
            "sek" => FlatPriceCurrency.Sek,
            "sgd" => FlatPriceCurrency.Sgd,
            "sle" => FlatPriceCurrency.Sle,
            "sll" => FlatPriceCurrency.Sll,
            "sos" => FlatPriceCurrency.Sos,
            "szl" => FlatPriceCurrency.Szl,
            "thb" => FlatPriceCurrency.Thb,
            "tjs" => FlatPriceCurrency.Tjs,
            "top" => FlatPriceCurrency.Top,
            "try" => FlatPriceCurrency.Try,
            "ttd" => FlatPriceCurrency.Ttd,
            "tzs" => FlatPriceCurrency.Tzs,
            "uah" => FlatPriceCurrency.Uah,
            "uzs" => FlatPriceCurrency.Uzs,
            "vnd" => FlatPriceCurrency.Vnd,
            "vuv" => FlatPriceCurrency.Vuv,
            "wst" => FlatPriceCurrency.Wst,
            "xaf" => FlatPriceCurrency.Xaf,
            "xcd" => FlatPriceCurrency.Xcd,
            "yer" => FlatPriceCurrency.Yer,
            "zar" => FlatPriceCurrency.Zar,
            "zmw" => FlatPriceCurrency.Zmw,
            "clp" => FlatPriceCurrency.Clp,
            "djf" => FlatPriceCurrency.Djf,
            "gnf" => FlatPriceCurrency.Gnf,
            "ugx" => FlatPriceCurrency.Ugx,
            "pyg" => FlatPriceCurrency.Pyg,
            "xof" => FlatPriceCurrency.Xof,
            "xpf" => FlatPriceCurrency.Xpf,
            _ => (FlatPriceCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FlatPriceCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FlatPriceCurrency.Usd => "usd",
                FlatPriceCurrency.Aed => "aed",
                FlatPriceCurrency.All => "all",
                FlatPriceCurrency.Amd => "amd",
                FlatPriceCurrency.Ang => "ang",
                FlatPriceCurrency.Aud => "aud",
                FlatPriceCurrency.Awg => "awg",
                FlatPriceCurrency.Azn => "azn",
                FlatPriceCurrency.Bam => "bam",
                FlatPriceCurrency.Bbd => "bbd",
                FlatPriceCurrency.Bdt => "bdt",
                FlatPriceCurrency.Bgn => "bgn",
                FlatPriceCurrency.Bif => "bif",
                FlatPriceCurrency.Bmd => "bmd",
                FlatPriceCurrency.Bnd => "bnd",
                FlatPriceCurrency.Bsd => "bsd",
                FlatPriceCurrency.Bwp => "bwp",
                FlatPriceCurrency.Byn => "byn",
                FlatPriceCurrency.Bzd => "bzd",
                FlatPriceCurrency.Brl => "brl",
                FlatPriceCurrency.Cad => "cad",
                FlatPriceCurrency.Cdf => "cdf",
                FlatPriceCurrency.Chf => "chf",
                FlatPriceCurrency.Cny => "cny",
                FlatPriceCurrency.Czk => "czk",
                FlatPriceCurrency.Dkk => "dkk",
                FlatPriceCurrency.Dop => "dop",
                FlatPriceCurrency.Dzd => "dzd",
                FlatPriceCurrency.Egp => "egp",
                FlatPriceCurrency.Etb => "etb",
                FlatPriceCurrency.Eur => "eur",
                FlatPriceCurrency.Fjd => "fjd",
                FlatPriceCurrency.Gbp => "gbp",
                FlatPriceCurrency.Gel => "gel",
                FlatPriceCurrency.Gip => "gip",
                FlatPriceCurrency.Gmd => "gmd",
                FlatPriceCurrency.Gyd => "gyd",
                FlatPriceCurrency.Hkd => "hkd",
                FlatPriceCurrency.Hrk => "hrk",
                FlatPriceCurrency.Htg => "htg",
                FlatPriceCurrency.Idr => "idr",
                FlatPriceCurrency.Ils => "ils",
                FlatPriceCurrency.Inr => "inr",
                FlatPriceCurrency.Isk => "isk",
                FlatPriceCurrency.Jmd => "jmd",
                FlatPriceCurrency.Jpy => "jpy",
                FlatPriceCurrency.Kes => "kes",
                FlatPriceCurrency.Kgs => "kgs",
                FlatPriceCurrency.Khr => "khr",
                FlatPriceCurrency.Kmf => "kmf",
                FlatPriceCurrency.Krw => "krw",
                FlatPriceCurrency.Kyd => "kyd",
                FlatPriceCurrency.Kzt => "kzt",
                FlatPriceCurrency.Lbp => "lbp",
                FlatPriceCurrency.Lkr => "lkr",
                FlatPriceCurrency.Lrd => "lrd",
                FlatPriceCurrency.Lsl => "lsl",
                FlatPriceCurrency.Mad => "mad",
                FlatPriceCurrency.Mdl => "mdl",
                FlatPriceCurrency.Mga => "mga",
                FlatPriceCurrency.Mkd => "mkd",
                FlatPriceCurrency.Mmk => "mmk",
                FlatPriceCurrency.Mnt => "mnt",
                FlatPriceCurrency.Mop => "mop",
                FlatPriceCurrency.Mro => "mro",
                FlatPriceCurrency.Mvr => "mvr",
                FlatPriceCurrency.Mwk => "mwk",
                FlatPriceCurrency.Mxn => "mxn",
                FlatPriceCurrency.Myr => "myr",
                FlatPriceCurrency.Mzn => "mzn",
                FlatPriceCurrency.Nad => "nad",
                FlatPriceCurrency.Ngn => "ngn",
                FlatPriceCurrency.Nok => "nok",
                FlatPriceCurrency.Npr => "npr",
                FlatPriceCurrency.Nzd => "nzd",
                FlatPriceCurrency.Pgk => "pgk",
                FlatPriceCurrency.Php => "php",
                FlatPriceCurrency.Pkr => "pkr",
                FlatPriceCurrency.Pln => "pln",
                FlatPriceCurrency.Qar => "qar",
                FlatPriceCurrency.Ron => "ron",
                FlatPriceCurrency.Rsd => "rsd",
                FlatPriceCurrency.Rub => "rub",
                FlatPriceCurrency.Rwf => "rwf",
                FlatPriceCurrency.Sar => "sar",
                FlatPriceCurrency.Sbd => "sbd",
                FlatPriceCurrency.Scr => "scr",
                FlatPriceCurrency.Sek => "sek",
                FlatPriceCurrency.Sgd => "sgd",
                FlatPriceCurrency.Sle => "sle",
                FlatPriceCurrency.Sll => "sll",
                FlatPriceCurrency.Sos => "sos",
                FlatPriceCurrency.Szl => "szl",
                FlatPriceCurrency.Thb => "thb",
                FlatPriceCurrency.Tjs => "tjs",
                FlatPriceCurrency.Top => "top",
                FlatPriceCurrency.Try => "try",
                FlatPriceCurrency.Ttd => "ttd",
                FlatPriceCurrency.Tzs => "tzs",
                FlatPriceCurrency.Uah => "uah",
                FlatPriceCurrency.Uzs => "uzs",
                FlatPriceCurrency.Vnd => "vnd",
                FlatPriceCurrency.Vuv => "vuv",
                FlatPriceCurrency.Wst => "wst",
                FlatPriceCurrency.Xaf => "xaf",
                FlatPriceCurrency.Xcd => "xcd",
                FlatPriceCurrency.Yer => "yer",
                FlatPriceCurrency.Zar => "zar",
                FlatPriceCurrency.Zmw => "zmw",
                FlatPriceCurrency.Clp => "clp",
                FlatPriceCurrency.Djf => "djf",
                FlatPriceCurrency.Gnf => "gnf",
                FlatPriceCurrency.Ugx => "ugx",
                FlatPriceCurrency.Pyg => "pyg",
                FlatPriceCurrency.Xof => "xof",
                FlatPriceCurrency.Xpf => "xpf",
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
[JsonConverter(typeof(JsonModelConverter<UnitPrice, UnitPriceFromRaw>))]
public sealed record class UnitPrice : JsonModel
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
    public required ApiEnum<string, UnitPriceCurrency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, UnitPriceCurrency>>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        this.Currency.Validate();
    }

    public UnitPrice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UnitPrice(UnitPrice unitPrice)
        : base(unitPrice) { }
#pragma warning restore CS8618

    public UnitPrice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnitPrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UnitPriceFromRaw.FromRawUnchecked"/>
    public static UnitPrice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UnitPriceFromRaw : IFromRawJson<UnitPrice>
{
    /// <inheritdoc/>
    public UnitPrice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UnitPrice.FromRawUnchecked(rawData);
}

/// <summary>
/// ISO 4217 currency code
/// </summary>
[JsonConverter(typeof(UnitPriceCurrencyConverter))]
public enum UnitPriceCurrency
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

sealed class UnitPriceCurrencyConverter : JsonConverter<UnitPriceCurrency>
{
    public override UnitPriceCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => UnitPriceCurrency.Usd,
            "aed" => UnitPriceCurrency.Aed,
            "all" => UnitPriceCurrency.All,
            "amd" => UnitPriceCurrency.Amd,
            "ang" => UnitPriceCurrency.Ang,
            "aud" => UnitPriceCurrency.Aud,
            "awg" => UnitPriceCurrency.Awg,
            "azn" => UnitPriceCurrency.Azn,
            "bam" => UnitPriceCurrency.Bam,
            "bbd" => UnitPriceCurrency.Bbd,
            "bdt" => UnitPriceCurrency.Bdt,
            "bgn" => UnitPriceCurrency.Bgn,
            "bif" => UnitPriceCurrency.Bif,
            "bmd" => UnitPriceCurrency.Bmd,
            "bnd" => UnitPriceCurrency.Bnd,
            "bsd" => UnitPriceCurrency.Bsd,
            "bwp" => UnitPriceCurrency.Bwp,
            "byn" => UnitPriceCurrency.Byn,
            "bzd" => UnitPriceCurrency.Bzd,
            "brl" => UnitPriceCurrency.Brl,
            "cad" => UnitPriceCurrency.Cad,
            "cdf" => UnitPriceCurrency.Cdf,
            "chf" => UnitPriceCurrency.Chf,
            "cny" => UnitPriceCurrency.Cny,
            "czk" => UnitPriceCurrency.Czk,
            "dkk" => UnitPriceCurrency.Dkk,
            "dop" => UnitPriceCurrency.Dop,
            "dzd" => UnitPriceCurrency.Dzd,
            "egp" => UnitPriceCurrency.Egp,
            "etb" => UnitPriceCurrency.Etb,
            "eur" => UnitPriceCurrency.Eur,
            "fjd" => UnitPriceCurrency.Fjd,
            "gbp" => UnitPriceCurrency.Gbp,
            "gel" => UnitPriceCurrency.Gel,
            "gip" => UnitPriceCurrency.Gip,
            "gmd" => UnitPriceCurrency.Gmd,
            "gyd" => UnitPriceCurrency.Gyd,
            "hkd" => UnitPriceCurrency.Hkd,
            "hrk" => UnitPriceCurrency.Hrk,
            "htg" => UnitPriceCurrency.Htg,
            "idr" => UnitPriceCurrency.Idr,
            "ils" => UnitPriceCurrency.Ils,
            "inr" => UnitPriceCurrency.Inr,
            "isk" => UnitPriceCurrency.Isk,
            "jmd" => UnitPriceCurrency.Jmd,
            "jpy" => UnitPriceCurrency.Jpy,
            "kes" => UnitPriceCurrency.Kes,
            "kgs" => UnitPriceCurrency.Kgs,
            "khr" => UnitPriceCurrency.Khr,
            "kmf" => UnitPriceCurrency.Kmf,
            "krw" => UnitPriceCurrency.Krw,
            "kyd" => UnitPriceCurrency.Kyd,
            "kzt" => UnitPriceCurrency.Kzt,
            "lbp" => UnitPriceCurrency.Lbp,
            "lkr" => UnitPriceCurrency.Lkr,
            "lrd" => UnitPriceCurrency.Lrd,
            "lsl" => UnitPriceCurrency.Lsl,
            "mad" => UnitPriceCurrency.Mad,
            "mdl" => UnitPriceCurrency.Mdl,
            "mga" => UnitPriceCurrency.Mga,
            "mkd" => UnitPriceCurrency.Mkd,
            "mmk" => UnitPriceCurrency.Mmk,
            "mnt" => UnitPriceCurrency.Mnt,
            "mop" => UnitPriceCurrency.Mop,
            "mro" => UnitPriceCurrency.Mro,
            "mvr" => UnitPriceCurrency.Mvr,
            "mwk" => UnitPriceCurrency.Mwk,
            "mxn" => UnitPriceCurrency.Mxn,
            "myr" => UnitPriceCurrency.Myr,
            "mzn" => UnitPriceCurrency.Mzn,
            "nad" => UnitPriceCurrency.Nad,
            "ngn" => UnitPriceCurrency.Ngn,
            "nok" => UnitPriceCurrency.Nok,
            "npr" => UnitPriceCurrency.Npr,
            "nzd" => UnitPriceCurrency.Nzd,
            "pgk" => UnitPriceCurrency.Pgk,
            "php" => UnitPriceCurrency.Php,
            "pkr" => UnitPriceCurrency.Pkr,
            "pln" => UnitPriceCurrency.Pln,
            "qar" => UnitPriceCurrency.Qar,
            "ron" => UnitPriceCurrency.Ron,
            "rsd" => UnitPriceCurrency.Rsd,
            "rub" => UnitPriceCurrency.Rub,
            "rwf" => UnitPriceCurrency.Rwf,
            "sar" => UnitPriceCurrency.Sar,
            "sbd" => UnitPriceCurrency.Sbd,
            "scr" => UnitPriceCurrency.Scr,
            "sek" => UnitPriceCurrency.Sek,
            "sgd" => UnitPriceCurrency.Sgd,
            "sle" => UnitPriceCurrency.Sle,
            "sll" => UnitPriceCurrency.Sll,
            "sos" => UnitPriceCurrency.Sos,
            "szl" => UnitPriceCurrency.Szl,
            "thb" => UnitPriceCurrency.Thb,
            "tjs" => UnitPriceCurrency.Tjs,
            "top" => UnitPriceCurrency.Top,
            "try" => UnitPriceCurrency.Try,
            "ttd" => UnitPriceCurrency.Ttd,
            "tzs" => UnitPriceCurrency.Tzs,
            "uah" => UnitPriceCurrency.Uah,
            "uzs" => UnitPriceCurrency.Uzs,
            "vnd" => UnitPriceCurrency.Vnd,
            "vuv" => UnitPriceCurrency.Vuv,
            "wst" => UnitPriceCurrency.Wst,
            "xaf" => UnitPriceCurrency.Xaf,
            "xcd" => UnitPriceCurrency.Xcd,
            "yer" => UnitPriceCurrency.Yer,
            "zar" => UnitPriceCurrency.Zar,
            "zmw" => UnitPriceCurrency.Zmw,
            "clp" => UnitPriceCurrency.Clp,
            "djf" => UnitPriceCurrency.Djf,
            "gnf" => UnitPriceCurrency.Gnf,
            "ugx" => UnitPriceCurrency.Ugx,
            "pyg" => UnitPriceCurrency.Pyg,
            "xof" => UnitPriceCurrency.Xof,
            "xpf" => UnitPriceCurrency.Xpf,
            _ => (UnitPriceCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnitPriceCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UnitPriceCurrency.Usd => "usd",
                UnitPriceCurrency.Aed => "aed",
                UnitPriceCurrency.All => "all",
                UnitPriceCurrency.Amd => "amd",
                UnitPriceCurrency.Ang => "ang",
                UnitPriceCurrency.Aud => "aud",
                UnitPriceCurrency.Awg => "awg",
                UnitPriceCurrency.Azn => "azn",
                UnitPriceCurrency.Bam => "bam",
                UnitPriceCurrency.Bbd => "bbd",
                UnitPriceCurrency.Bdt => "bdt",
                UnitPriceCurrency.Bgn => "bgn",
                UnitPriceCurrency.Bif => "bif",
                UnitPriceCurrency.Bmd => "bmd",
                UnitPriceCurrency.Bnd => "bnd",
                UnitPriceCurrency.Bsd => "bsd",
                UnitPriceCurrency.Bwp => "bwp",
                UnitPriceCurrency.Byn => "byn",
                UnitPriceCurrency.Bzd => "bzd",
                UnitPriceCurrency.Brl => "brl",
                UnitPriceCurrency.Cad => "cad",
                UnitPriceCurrency.Cdf => "cdf",
                UnitPriceCurrency.Chf => "chf",
                UnitPriceCurrency.Cny => "cny",
                UnitPriceCurrency.Czk => "czk",
                UnitPriceCurrency.Dkk => "dkk",
                UnitPriceCurrency.Dop => "dop",
                UnitPriceCurrency.Dzd => "dzd",
                UnitPriceCurrency.Egp => "egp",
                UnitPriceCurrency.Etb => "etb",
                UnitPriceCurrency.Eur => "eur",
                UnitPriceCurrency.Fjd => "fjd",
                UnitPriceCurrency.Gbp => "gbp",
                UnitPriceCurrency.Gel => "gel",
                UnitPriceCurrency.Gip => "gip",
                UnitPriceCurrency.Gmd => "gmd",
                UnitPriceCurrency.Gyd => "gyd",
                UnitPriceCurrency.Hkd => "hkd",
                UnitPriceCurrency.Hrk => "hrk",
                UnitPriceCurrency.Htg => "htg",
                UnitPriceCurrency.Idr => "idr",
                UnitPriceCurrency.Ils => "ils",
                UnitPriceCurrency.Inr => "inr",
                UnitPriceCurrency.Isk => "isk",
                UnitPriceCurrency.Jmd => "jmd",
                UnitPriceCurrency.Jpy => "jpy",
                UnitPriceCurrency.Kes => "kes",
                UnitPriceCurrency.Kgs => "kgs",
                UnitPriceCurrency.Khr => "khr",
                UnitPriceCurrency.Kmf => "kmf",
                UnitPriceCurrency.Krw => "krw",
                UnitPriceCurrency.Kyd => "kyd",
                UnitPriceCurrency.Kzt => "kzt",
                UnitPriceCurrency.Lbp => "lbp",
                UnitPriceCurrency.Lkr => "lkr",
                UnitPriceCurrency.Lrd => "lrd",
                UnitPriceCurrency.Lsl => "lsl",
                UnitPriceCurrency.Mad => "mad",
                UnitPriceCurrency.Mdl => "mdl",
                UnitPriceCurrency.Mga => "mga",
                UnitPriceCurrency.Mkd => "mkd",
                UnitPriceCurrency.Mmk => "mmk",
                UnitPriceCurrency.Mnt => "mnt",
                UnitPriceCurrency.Mop => "mop",
                UnitPriceCurrency.Mro => "mro",
                UnitPriceCurrency.Mvr => "mvr",
                UnitPriceCurrency.Mwk => "mwk",
                UnitPriceCurrency.Mxn => "mxn",
                UnitPriceCurrency.Myr => "myr",
                UnitPriceCurrency.Mzn => "mzn",
                UnitPriceCurrency.Nad => "nad",
                UnitPriceCurrency.Ngn => "ngn",
                UnitPriceCurrency.Nok => "nok",
                UnitPriceCurrency.Npr => "npr",
                UnitPriceCurrency.Nzd => "nzd",
                UnitPriceCurrency.Pgk => "pgk",
                UnitPriceCurrency.Php => "php",
                UnitPriceCurrency.Pkr => "pkr",
                UnitPriceCurrency.Pln => "pln",
                UnitPriceCurrency.Qar => "qar",
                UnitPriceCurrency.Ron => "ron",
                UnitPriceCurrency.Rsd => "rsd",
                UnitPriceCurrency.Rub => "rub",
                UnitPriceCurrency.Rwf => "rwf",
                UnitPriceCurrency.Sar => "sar",
                UnitPriceCurrency.Sbd => "sbd",
                UnitPriceCurrency.Scr => "scr",
                UnitPriceCurrency.Sek => "sek",
                UnitPriceCurrency.Sgd => "sgd",
                UnitPriceCurrency.Sle => "sle",
                UnitPriceCurrency.Sll => "sll",
                UnitPriceCurrency.Sos => "sos",
                UnitPriceCurrency.Szl => "szl",
                UnitPriceCurrency.Thb => "thb",
                UnitPriceCurrency.Tjs => "tjs",
                UnitPriceCurrency.Top => "top",
                UnitPriceCurrency.Try => "try",
                UnitPriceCurrency.Ttd => "ttd",
                UnitPriceCurrency.Tzs => "tzs",
                UnitPriceCurrency.Uah => "uah",
                UnitPriceCurrency.Uzs => "uzs",
                UnitPriceCurrency.Vnd => "vnd",
                UnitPriceCurrency.Vuv => "vuv",
                UnitPriceCurrency.Wst => "wst",
                UnitPriceCurrency.Xaf => "xaf",
                UnitPriceCurrency.Xcd => "xcd",
                UnitPriceCurrency.Yer => "yer",
                UnitPriceCurrency.Zar => "zar",
                UnitPriceCurrency.Zmw => "zmw",
                UnitPriceCurrency.Clp => "clp",
                UnitPriceCurrency.Djf => "djf",
                UnitPriceCurrency.Gnf => "gnf",
                UnitPriceCurrency.Ugx => "ugx",
                UnitPriceCurrency.Pyg => "pyg",
                UnitPriceCurrency.Xof => "xof",
                UnitPriceCurrency.Xpf => "xpf",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Strategy for scheduling subscription changes
/// </summary>
[JsonConverter(typeof(ScheduleStrategyConverter))]
public enum ScheduleStrategy
{
    EndOfBillingPeriod,
    EndOfBillingMonth,
    Immediate,
}

sealed class ScheduleStrategyConverter : JsonConverter<ScheduleStrategy>
{
    public override ScheduleStrategy Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "END_OF_BILLING_PERIOD" => ScheduleStrategy.EndOfBillingPeriod,
            "END_OF_BILLING_MONTH" => ScheduleStrategy.EndOfBillingMonth,
            "IMMEDIATE" => ScheduleStrategy.Immediate,
            _ => (ScheduleStrategy)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ScheduleStrategy value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ScheduleStrategy.EndOfBillingPeriod => "END_OF_BILLING_PERIOD",
                ScheduleStrategy.EndOfBillingMonth => "END_OF_BILLING_MONTH",
                ScheduleStrategy.Immediate => "IMMEDIATE",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Trial period override settings
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<TrialOverrideConfiguration, TrialOverrideConfigurationFromRaw>)
)]
public sealed record class TrialOverrideConfiguration : JsonModel
{
    /// <summary>
    /// Whether the subscription should start with a trial period
    /// </summary>
    public required bool IsTrial
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("isTrial");
        }
        init { this._rawData.Set("isTrial", value); }
    }

    /// <summary>
    /// Behavior when trial ends: CONVERT_TO_PAID or CANCEL_SUBSCRIPTION
    /// </summary>
    public ApiEnum<string, TrialEndBehavior>? TrialEndBehavior
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TrialEndBehavior>>(
                "trialEndBehavior"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("trialEndBehavior", value);
        }
    }

    /// <summary>
    /// Custom trial end date
    /// </summary>
    public System::DateTimeOffset? TrialEndDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("trialEndDate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("trialEndDate", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.IsTrial;
        this.TrialEndBehavior?.Validate();
        _ = this.TrialEndDate;
    }

    public TrialOverrideConfiguration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TrialOverrideConfiguration(TrialOverrideConfiguration trialOverrideConfiguration)
        : base(trialOverrideConfiguration) { }
#pragma warning restore CS8618

    public TrialOverrideConfiguration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TrialOverrideConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TrialOverrideConfigurationFromRaw.FromRawUnchecked"/>
    public static TrialOverrideConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TrialOverrideConfiguration(bool isTrial)
        : this()
    {
        this.IsTrial = isTrial;
    }
}

class TrialOverrideConfigurationFromRaw : IFromRawJson<TrialOverrideConfiguration>
{
    /// <inheritdoc/>
    public TrialOverrideConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TrialOverrideConfiguration.FromRawUnchecked(rawData);
}

/// <summary>
/// Behavior when trial ends: CONVERT_TO_PAID or CANCEL_SUBSCRIPTION
/// </summary>
[JsonConverter(typeof(TrialEndBehaviorConverter))]
public enum TrialEndBehavior
{
    ConvertToPaid,
    CancelSubscription,
}

sealed class TrialEndBehaviorConverter : JsonConverter<TrialEndBehavior>
{
    public override TrialEndBehavior Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "CONVERT_TO_PAID" => TrialEndBehavior.ConvertToPaid,
            "CANCEL_SUBSCRIPTION" => TrialEndBehavior.CancelSubscription,
            _ => (TrialEndBehavior)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TrialEndBehavior value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TrialEndBehavior.ConvertToPaid => "CONVERT_TO_PAID",
                TrialEndBehavior.CancelSubscription => "CANCEL_SUBSCRIPTION",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
