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

namespace Stigg.Client.Models.V1.Subscriptions;

/// <summary>
/// Create a new Subscription
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class SubscriptionCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Customer ID to provision the subscription for
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
    /// Plan ID to provision
    /// </summary>
    public required string PlanID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("planId");
        }
        init { this._rawBodyData.Set("planId", value); }
    }

    /// <summary>
    /// Unique identifier for the subscription
    /// </summary>
    public string? ID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("id");
        }
        init { this._rawBodyData.Set("id", value); }
    }

    public IReadOnlyList<Addon>? Addons
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<Addon>>("addons");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<Addon>?>(
                "addons",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public AppliedCoupon? AppliedCoupon
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<AppliedCoupon>("appliedCoupon");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("appliedCoupon", value);
        }
    }

    /// <summary>
    /// Whether to wait for payment confirmation before returning the subscription
    /// </summary>
    public bool? AwaitPaymentConfirmation
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("awaitPaymentConfirmation");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("awaitPaymentConfirmation", value);
        }
    }

    /// <summary>
    /// The ISO 3166-1 alpha-2 country code for billing
    /// </summary>
    public string? BillingCountryCode
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("billingCountryCode");
        }
        init { this._rawBodyData.Set("billingCountryCode", value); }
    }

    /// <summary>
    /// External billing system identifier
    /// </summary>
    public string? BillingID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("billingId");
        }
        init { this._rawBodyData.Set("billingId", value); }
    }

    public BillingInformation? BillingInformation
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<BillingInformation>("billingInformation");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("billingInformation", value);
        }
    }

    public ApiEnum<string, BillingPeriod>? BillingPeriod
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, BillingPeriod>>(
                "billingPeriod"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("billingPeriod", value);
        }
    }

    public Budget? Budget
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Budget>("budget");
        }
        init { this._rawBodyData.Set("budget", value); }
    }

    public IReadOnlyList<Charge>? Charges
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<Charge>>("charges");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<Charge>?>(
                "charges",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public CheckoutOptions? CheckoutOptions
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<CheckoutOptions>("checkoutOptions");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("checkoutOptions", value);
        }
    }

    /// <summary>
    /// Additional metadata for the subscription
    /// </summary>
    public IReadOnlyDictionary<string, string>? Metadata
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<FrozenDictionary<string, string>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public MinimumSpend? MinimumSpend
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<MinimumSpend>("minimumSpend");
        }
        init { this._rawBodyData.Set("minimumSpend", value); }
    }

    /// <summary>
    /// Optional paying customer ID for split billing scenarios
    /// </summary>
    public string? PayingCustomerID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("payingCustomerId");
        }
        init { this._rawBodyData.Set("payingCustomerId", value); }
    }

    /// <summary>
    /// How payments should be collected for this subscription
    /// </summary>
    public ApiEnum<string, PaymentCollectionMethod>? PaymentCollectionMethod
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, PaymentCollectionMethod>>(
                "paymentCollectionMethod"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("paymentCollectionMethod", value);
        }
    }

    public IReadOnlyList<PriceOverride>? PriceOverrides
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<PriceOverride>>(
                "priceOverrides"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<PriceOverride>?>(
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("resourceId");
        }
        init { this._rawBodyData.Set("resourceId", value); }
    }

    /// <summary>
    /// Salesforce ID
    /// </summary>
    public string? SalesforceID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("salesforceId");
        }
        init { this._rawBodyData.Set("salesforceId", value); }
    }

    /// <summary>
    /// Strategy for scheduling subscription changes
    /// </summary>
    public ApiEnum<string, ScheduleStrategy>? ScheduleStrategy
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, ScheduleStrategy>>(
                "scheduleStrategy"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("scheduleStrategy", value);
        }
    }

    /// <summary>
    /// Subscription start date
    /// </summary>
    public System::DateTimeOffset? StartDate
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<System::DateTimeOffset>("startDate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("startDate", value);
        }
    }

    public IReadOnlyList<SubscriptionEntitlement>? SubscriptionEntitlements
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<SubscriptionEntitlement>>(
                "subscriptionEntitlements"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<SubscriptionEntitlement>?>(
                "subscriptionEntitlements",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public TrialOverrideConfiguration? TrialOverrideConfiguration
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<TrialOverrideConfiguration>(
                "trialOverrideConfiguration"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("trialOverrideConfiguration", value);
        }
    }

    public double? UnitQuantity
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<double>("unitQuantity");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("unitQuantity", value);
        }
    }

    public SubscriptionCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionCreateParams(SubscriptionCreateParams subscriptionCreateParams)
        : base(subscriptionCreateParams)
    {
        this._rawBodyData = new(subscriptionCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public SubscriptionCreateParams(
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
    SubscriptionCreateParams(
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

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static SubscriptionCreateParams FromRawUnchecked(
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
            new Dictionary<string, object?>()
            {
                ["HeaderData"] = this._rawHeaderData.Freeze(),
                ["QueryData"] = this._rawQueryData.Freeze(),
                ["BodyData"] = this._rawBodyData.Freeze(),
            },
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(SubscriptionCreateParams? other)
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
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/api/v1/subscriptions"
        )
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

[JsonConverter(typeof(JsonModelConverter<Addon, AddonFromRaw>))]
public sealed record class Addon : JsonModel
{
    /// <summary>
    /// Addon identifier
    /// </summary>
    public required string AddonID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("addonId");
        }
        init { this._rawData.Set("addonId", value); }
    }

    /// <summary>
    /// Number of addon units
    /// </summary>
    public long? Quantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("quantity");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("quantity", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AddonID;
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

    [SetsRequiredMembers]
    public Addon(string addonID)
        : this()
    {
        this.AddonID = addonID;
    }
}

class AddonFromRaw : IFromRawJson<Addon>
{
    /// <inheritdoc/>
    public Addon FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Addon.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<AppliedCoupon, AppliedCouponFromRaw>))]
public sealed record class AppliedCoupon : JsonModel
{
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

[JsonConverter(typeof(JsonModelConverter<Discount, DiscountFromRaw>))]
public sealed record class Discount : JsonModel
{
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
    public required double Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    public ApiEnum<string, Currency>? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Currency>>("currency");
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

    [SetsRequiredMembers]
    public AmountsOff(double amount)
        : this()
    {
        this.Amount = amount;
    }
}

class AmountsOffFromRaw : IFromRawJson<AmountsOff>
{
    /// <inheritdoc/>
    public AmountsOff FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AmountsOff.FromRawUnchecked(rawData);
}

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
    /// Charge quantity
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
    public required ApiEnum<string, global::Stigg.Client.Models.V1.Subscriptions.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Stigg.Client.Models.V1.Subscriptions.Type>
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

sealed class TypeConverter : JsonConverter<global::Stigg.Client.Models.V1.Subscriptions.Type>
{
    public override global::Stigg.Client.Models.V1.Subscriptions.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FEATURE" => global::Stigg.Client.Models.V1.Subscriptions.Type.Feature,
            "CREDIT" => global::Stigg.Client.Models.V1.Subscriptions.Type.Credit,
            _ => (global::Stigg.Client.Models.V1.Subscriptions.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Stigg.Client.Models.V1.Subscriptions.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Stigg.Client.Models.V1.Subscriptions.Type.Feature => "FEATURE",
                global::Stigg.Client.Models.V1.Subscriptions.Type.Credit => "CREDIT",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

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

[JsonConverter(typeof(JsonModelConverter<MinimumSpend, MinimumSpendFromRaw>))]
public sealed record class MinimumSpend : JsonModel
{
    /// <summary>
    /// Minimum spend amount
    /// </summary>
    public Minimum? Minimum
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Minimum>("minimum");
        }
        init { this._rawData.Set("minimum", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Minimum?.Validate();
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
/// Minimum spend amount
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Minimum, MinimumFromRaw>))]
public sealed record class Minimum : JsonModel
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
    public ApiEnum<string, MinimumCurrency>? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, MinimumCurrency>>("currency");
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

    public Minimum() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Minimum(Minimum minimum)
        : base(minimum) { }
#pragma warning restore CS8618

    public Minimum(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Minimum(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MinimumFromRaw.FromRawUnchecked"/>
    public static Minimum FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MinimumFromRaw : IFromRawJson<Minimum>
{
    /// <inheritdoc/>
    public Minimum FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Minimum.FromRawUnchecked(rawData);
}

/// <summary>
/// The price currency
/// </summary>
[JsonConverter(typeof(MinimumCurrencyConverter))]
public enum MinimumCurrency
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

sealed class MinimumCurrencyConverter : JsonConverter<MinimumCurrency>
{
    public override MinimumCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => MinimumCurrency.Usd,
            "aed" => MinimumCurrency.Aed,
            "all" => MinimumCurrency.All,
            "amd" => MinimumCurrency.Amd,
            "ang" => MinimumCurrency.Ang,
            "aud" => MinimumCurrency.Aud,
            "awg" => MinimumCurrency.Awg,
            "azn" => MinimumCurrency.Azn,
            "bam" => MinimumCurrency.Bam,
            "bbd" => MinimumCurrency.Bbd,
            "bdt" => MinimumCurrency.Bdt,
            "bgn" => MinimumCurrency.Bgn,
            "bif" => MinimumCurrency.Bif,
            "bmd" => MinimumCurrency.Bmd,
            "bnd" => MinimumCurrency.Bnd,
            "bsd" => MinimumCurrency.Bsd,
            "bwp" => MinimumCurrency.Bwp,
            "byn" => MinimumCurrency.Byn,
            "bzd" => MinimumCurrency.Bzd,
            "brl" => MinimumCurrency.Brl,
            "cad" => MinimumCurrency.Cad,
            "cdf" => MinimumCurrency.Cdf,
            "chf" => MinimumCurrency.Chf,
            "cny" => MinimumCurrency.Cny,
            "czk" => MinimumCurrency.Czk,
            "dkk" => MinimumCurrency.Dkk,
            "dop" => MinimumCurrency.Dop,
            "dzd" => MinimumCurrency.Dzd,
            "egp" => MinimumCurrency.Egp,
            "etb" => MinimumCurrency.Etb,
            "eur" => MinimumCurrency.Eur,
            "fjd" => MinimumCurrency.Fjd,
            "gbp" => MinimumCurrency.Gbp,
            "gel" => MinimumCurrency.Gel,
            "gip" => MinimumCurrency.Gip,
            "gmd" => MinimumCurrency.Gmd,
            "gyd" => MinimumCurrency.Gyd,
            "hkd" => MinimumCurrency.Hkd,
            "hrk" => MinimumCurrency.Hrk,
            "htg" => MinimumCurrency.Htg,
            "idr" => MinimumCurrency.Idr,
            "ils" => MinimumCurrency.Ils,
            "inr" => MinimumCurrency.Inr,
            "isk" => MinimumCurrency.Isk,
            "jmd" => MinimumCurrency.Jmd,
            "jpy" => MinimumCurrency.Jpy,
            "kes" => MinimumCurrency.Kes,
            "kgs" => MinimumCurrency.Kgs,
            "khr" => MinimumCurrency.Khr,
            "kmf" => MinimumCurrency.Kmf,
            "krw" => MinimumCurrency.Krw,
            "kyd" => MinimumCurrency.Kyd,
            "kzt" => MinimumCurrency.Kzt,
            "lbp" => MinimumCurrency.Lbp,
            "lkr" => MinimumCurrency.Lkr,
            "lrd" => MinimumCurrency.Lrd,
            "lsl" => MinimumCurrency.Lsl,
            "mad" => MinimumCurrency.Mad,
            "mdl" => MinimumCurrency.Mdl,
            "mga" => MinimumCurrency.Mga,
            "mkd" => MinimumCurrency.Mkd,
            "mmk" => MinimumCurrency.Mmk,
            "mnt" => MinimumCurrency.Mnt,
            "mop" => MinimumCurrency.Mop,
            "mro" => MinimumCurrency.Mro,
            "mvr" => MinimumCurrency.Mvr,
            "mwk" => MinimumCurrency.Mwk,
            "mxn" => MinimumCurrency.Mxn,
            "myr" => MinimumCurrency.Myr,
            "mzn" => MinimumCurrency.Mzn,
            "nad" => MinimumCurrency.Nad,
            "ngn" => MinimumCurrency.Ngn,
            "nok" => MinimumCurrency.Nok,
            "npr" => MinimumCurrency.Npr,
            "nzd" => MinimumCurrency.Nzd,
            "pgk" => MinimumCurrency.Pgk,
            "php" => MinimumCurrency.Php,
            "pkr" => MinimumCurrency.Pkr,
            "pln" => MinimumCurrency.Pln,
            "qar" => MinimumCurrency.Qar,
            "ron" => MinimumCurrency.Ron,
            "rsd" => MinimumCurrency.Rsd,
            "rub" => MinimumCurrency.Rub,
            "rwf" => MinimumCurrency.Rwf,
            "sar" => MinimumCurrency.Sar,
            "sbd" => MinimumCurrency.Sbd,
            "scr" => MinimumCurrency.Scr,
            "sek" => MinimumCurrency.Sek,
            "sgd" => MinimumCurrency.Sgd,
            "sle" => MinimumCurrency.Sle,
            "sll" => MinimumCurrency.Sll,
            "sos" => MinimumCurrency.Sos,
            "szl" => MinimumCurrency.Szl,
            "thb" => MinimumCurrency.Thb,
            "tjs" => MinimumCurrency.Tjs,
            "top" => MinimumCurrency.Top,
            "try" => MinimumCurrency.Try,
            "ttd" => MinimumCurrency.Ttd,
            "tzs" => MinimumCurrency.Tzs,
            "uah" => MinimumCurrency.Uah,
            "uzs" => MinimumCurrency.Uzs,
            "vnd" => MinimumCurrency.Vnd,
            "vuv" => MinimumCurrency.Vuv,
            "wst" => MinimumCurrency.Wst,
            "xaf" => MinimumCurrency.Xaf,
            "xcd" => MinimumCurrency.Xcd,
            "yer" => MinimumCurrency.Yer,
            "zar" => MinimumCurrency.Zar,
            "zmw" => MinimumCurrency.Zmw,
            "clp" => MinimumCurrency.Clp,
            "djf" => MinimumCurrency.Djf,
            "gnf" => MinimumCurrency.Gnf,
            "ugx" => MinimumCurrency.Ugx,
            "pyg" => MinimumCurrency.Pyg,
            "xof" => MinimumCurrency.Xof,
            "xpf" => MinimumCurrency.Xpf,
            _ => (MinimumCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MinimumCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MinimumCurrency.Usd => "usd",
                MinimumCurrency.Aed => "aed",
                MinimumCurrency.All => "all",
                MinimumCurrency.Amd => "amd",
                MinimumCurrency.Ang => "ang",
                MinimumCurrency.Aud => "aud",
                MinimumCurrency.Awg => "awg",
                MinimumCurrency.Azn => "azn",
                MinimumCurrency.Bam => "bam",
                MinimumCurrency.Bbd => "bbd",
                MinimumCurrency.Bdt => "bdt",
                MinimumCurrency.Bgn => "bgn",
                MinimumCurrency.Bif => "bif",
                MinimumCurrency.Bmd => "bmd",
                MinimumCurrency.Bnd => "bnd",
                MinimumCurrency.Bsd => "bsd",
                MinimumCurrency.Bwp => "bwp",
                MinimumCurrency.Byn => "byn",
                MinimumCurrency.Bzd => "bzd",
                MinimumCurrency.Brl => "brl",
                MinimumCurrency.Cad => "cad",
                MinimumCurrency.Cdf => "cdf",
                MinimumCurrency.Chf => "chf",
                MinimumCurrency.Cny => "cny",
                MinimumCurrency.Czk => "czk",
                MinimumCurrency.Dkk => "dkk",
                MinimumCurrency.Dop => "dop",
                MinimumCurrency.Dzd => "dzd",
                MinimumCurrency.Egp => "egp",
                MinimumCurrency.Etb => "etb",
                MinimumCurrency.Eur => "eur",
                MinimumCurrency.Fjd => "fjd",
                MinimumCurrency.Gbp => "gbp",
                MinimumCurrency.Gel => "gel",
                MinimumCurrency.Gip => "gip",
                MinimumCurrency.Gmd => "gmd",
                MinimumCurrency.Gyd => "gyd",
                MinimumCurrency.Hkd => "hkd",
                MinimumCurrency.Hrk => "hrk",
                MinimumCurrency.Htg => "htg",
                MinimumCurrency.Idr => "idr",
                MinimumCurrency.Ils => "ils",
                MinimumCurrency.Inr => "inr",
                MinimumCurrency.Isk => "isk",
                MinimumCurrency.Jmd => "jmd",
                MinimumCurrency.Jpy => "jpy",
                MinimumCurrency.Kes => "kes",
                MinimumCurrency.Kgs => "kgs",
                MinimumCurrency.Khr => "khr",
                MinimumCurrency.Kmf => "kmf",
                MinimumCurrency.Krw => "krw",
                MinimumCurrency.Kyd => "kyd",
                MinimumCurrency.Kzt => "kzt",
                MinimumCurrency.Lbp => "lbp",
                MinimumCurrency.Lkr => "lkr",
                MinimumCurrency.Lrd => "lrd",
                MinimumCurrency.Lsl => "lsl",
                MinimumCurrency.Mad => "mad",
                MinimumCurrency.Mdl => "mdl",
                MinimumCurrency.Mga => "mga",
                MinimumCurrency.Mkd => "mkd",
                MinimumCurrency.Mmk => "mmk",
                MinimumCurrency.Mnt => "mnt",
                MinimumCurrency.Mop => "mop",
                MinimumCurrency.Mro => "mro",
                MinimumCurrency.Mvr => "mvr",
                MinimumCurrency.Mwk => "mwk",
                MinimumCurrency.Mxn => "mxn",
                MinimumCurrency.Myr => "myr",
                MinimumCurrency.Mzn => "mzn",
                MinimumCurrency.Nad => "nad",
                MinimumCurrency.Ngn => "ngn",
                MinimumCurrency.Nok => "nok",
                MinimumCurrency.Npr => "npr",
                MinimumCurrency.Nzd => "nzd",
                MinimumCurrency.Pgk => "pgk",
                MinimumCurrency.Php => "php",
                MinimumCurrency.Pkr => "pkr",
                MinimumCurrency.Pln => "pln",
                MinimumCurrency.Qar => "qar",
                MinimumCurrency.Ron => "ron",
                MinimumCurrency.Rsd => "rsd",
                MinimumCurrency.Rub => "rub",
                MinimumCurrency.Rwf => "rwf",
                MinimumCurrency.Sar => "sar",
                MinimumCurrency.Sbd => "sbd",
                MinimumCurrency.Scr => "scr",
                MinimumCurrency.Sek => "sek",
                MinimumCurrency.Sgd => "sgd",
                MinimumCurrency.Sle => "sle",
                MinimumCurrency.Sll => "sll",
                MinimumCurrency.Sos => "sos",
                MinimumCurrency.Szl => "szl",
                MinimumCurrency.Thb => "thb",
                MinimumCurrency.Tjs => "tjs",
                MinimumCurrency.Top => "top",
                MinimumCurrency.Try => "try",
                MinimumCurrency.Ttd => "ttd",
                MinimumCurrency.Tzs => "tzs",
                MinimumCurrency.Uah => "uah",
                MinimumCurrency.Uzs => "uzs",
                MinimumCurrency.Vnd => "vnd",
                MinimumCurrency.Vuv => "vuv",
                MinimumCurrency.Wst => "wst",
                MinimumCurrency.Xaf => "xaf",
                MinimumCurrency.Xcd => "xcd",
                MinimumCurrency.Yer => "yer",
                MinimumCurrency.Zar => "zar",
                MinimumCurrency.Zmw => "zmw",
                MinimumCurrency.Clp => "clp",
                MinimumCurrency.Djf => "djf",
                MinimumCurrency.Gnf => "gnf",
                MinimumCurrency.Ugx => "ugx",
                MinimumCurrency.Pyg => "pyg",
                MinimumCurrency.Xof => "xof",
                MinimumCurrency.Xpf => "xpf",
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
    public Price? Price
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Price>("price");
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
        _ = this.BaseCharge;
        _ = this.BlockSize;
        this.CreditGrantCadence?.Validate();
        this.CreditRate?.Validate();
        _ = this.FeatureID;
        this.Price?.Validate();
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
/// Override price amount
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Price, PriceFromRaw>))]
public sealed record class Price : JsonModel
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.BillingCountryCode;
        this.Currency?.Validate();
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
    public ApiEnum<string, FlatPriceCurrency>? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, FlatPriceCurrency>>("currency");
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
/// The price currency
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
    public ApiEnum<string, UnitPriceCurrency>? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, UnitPriceCurrency>>("currency");
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
/// The price currency
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

[JsonConverter(typeof(JsonModelConverter<SubscriptionEntitlement, SubscriptionEntitlementFromRaw>))]
public sealed record class SubscriptionEntitlement : JsonModel
{
    public required string FeatureID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("featureId");
        }
        init { this._rawData.Set("featureId", value); }
    }

    public required double UsageLimit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("usageLimit");
        }
        init { this._rawData.Set("usageLimit", value); }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FeatureID;
        _ = this.UsageLimit;
        _ = this.IsGranted;
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
