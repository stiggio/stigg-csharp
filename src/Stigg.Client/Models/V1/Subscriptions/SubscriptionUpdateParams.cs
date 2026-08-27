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
/// Updates an active subscription's properties including billing period, add-ons,
/// unit quantities, and discounts. This is a partial update — only the fields present
/// in the request body change. Object fields such as `metadata` are replaced wholesale
/// rather than merged, and list fields such as `addons` and `priceOverrides` must
/// be sent in full: any existing item that isn't included in the array is removed
/// from the subscription. Changes classified as a downgrade may be scheduled for
/// the end of the current billing period instead of applying immediately, depending
/// on your update scheduling configuration.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class SubscriptionUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

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
    /// Await payment confirmation
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

    public ApiEnum<string, BillingCycleAnchor>? BillingCycleAnchor
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, BillingCycleAnchor>>(
                "billingCycleAnchor"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("billingCycleAnchor", value);
        }
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

    /// <summary>
    /// Subscription cancellation date
    /// </summary>
    public System::DateTimeOffset? CancellationDate
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<System::DateTimeOffset>("cancellationDate");
        }
        init { this._rawBodyData.Set("cancellationDate", value); }
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

    public IReadOnlyList<Entitlement>? Entitlements
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<Entitlement>>("entitlements");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<Entitlement>?>(
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

    /// <summary>
    /// Minimum spend amount
    /// </summary>
    public MinimumSpend? MinimumSpend
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<MinimumSpend>("minimumSpend");
        }
        init { this._rawBodyData.Set("minimumSpend", value); }
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
    /// Promotion code
    /// </summary>
    public string? PromotionCode
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("promotionCode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("promotionCode", value);
        }
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
    /// Subscription trial end date
    /// </summary>
    public System::DateTimeOffset? TrialEndDate
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<System::DateTimeOffset>("trialEndDate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("trialEndDate", value);
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

    public SubscriptionUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionUpdateParams(SubscriptionUpdateParams subscriptionUpdateParams)
        : base(subscriptionUpdateParams)
    {
        this.ID = subscriptionUpdateParams.ID;

        this._rawBodyData = new(subscriptionUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public SubscriptionUpdateParams(
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
    SubscriptionUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string id
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.ID = id;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static SubscriptionUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string id
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            id
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["ID"] = JsonSerializer.SerializeToElement(this.ID),
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

    public virtual bool Equals(SubscriptionUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ID?.Equals(other.ID) ?? other.ID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/api/v1/subscriptions/{0}", this.ID)
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
        init { this._rawData.Set("promotionCode", value); }
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

/// <summary>
/// Monetary amount with currency
/// </summary>
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
    /// Physical address
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

    public string? ChargeOnBehalfOfAccount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("chargeOnBehalfOfAccount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("chargeOnBehalfOfAccount", value);
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

    public string? IntegrationID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("integrationId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("integrationId", value);
        }
    }

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
        _ = this.CouponID;
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
/// Physical address
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BillingAddress, BillingAddressFromRaw>))]
public sealed record class BillingAddress : JsonModel
{
    /// <summary>
    /// City name
    /// </summary>
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

    /// <summary>
    /// Country code or name
    /// </summary>
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

    /// <summary>
    /// Street address line 1
    /// </summary>
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

    /// <summary>
    /// Street address line 2
    /// </summary>
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

    /// <summary>
    /// Postal or ZIP code
    /// </summary>
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

    /// <summary>
    /// State or province
    /// </summary>
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
    public required string Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("type");
        }
        init { this._rawData.Set("type", value); }
    }

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

    public required double Quantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("quantity");
        }
        init { this._rawData.Set("quantity", value); }
    }

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

[JsonConverter(typeof(JsonModelConverter<PriceOverride, PriceOverrideFromRaw>))]
public sealed record class PriceOverride : JsonModel
{
    /// <summary>
    /// Addon ID
    /// </summary>
    public string? AddonID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("addonId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("addonId", value);
        }
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
    /// The corresponding custom currency id of the recurring credits price
    /// </summary>
    public string? CurrencyID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("currencyId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("currencyId", value);
        }
    }

    /// <summary>
    /// Feature ID
    /// </summary>
    public string? FeatureID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("featureId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("featureId", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AddonID;
        _ = this.Amount;
        _ = this.BaseCharge;
        this.Currency?.Validate();
        _ = this.CurrencyID;
        _ = this.FeatureID;
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
