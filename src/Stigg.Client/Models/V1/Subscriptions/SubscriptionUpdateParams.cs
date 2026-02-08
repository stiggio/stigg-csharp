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
/// unit quantities, and discounts.
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
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static SubscriptionUpdateParams FromRawUnchecked(
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
                ["ID"] = this.ID,
                ["HeaderData"] = this._rawHeaderData.Freeze(),
                ["QueryData"] = this._rawQueryData.Freeze(),
                ["BodyData"] = this._rawBodyData.Freeze(),
            },
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

[JsonConverter(typeof(JsonModelConverter<Addon, AddonFromRaw>))]
public sealed record class Addon : JsonModel
{
    /// <summary>
    /// Addon ID
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

    public required double Quantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("quantity");
        }
        init { this._rawData.Set("quantity", value); }
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
    /// Additional metadata for the subscription
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "metadata"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
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
    public required bool HasSoftLimit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("hasSoftLimit");
        }
        init { this._rawData.Set("hasSoftLimit", value); }
    }

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

[JsonConverter(typeof(JsonModelConverter<MinimumSpend, MinimumSpendFromRaw>))]
public sealed record class MinimumSpend : JsonModel
{
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

[JsonConverter(typeof(JsonModelConverter<Minimum, MinimumFromRaw>))]
public sealed record class Minimum : JsonModel
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

    [SetsRequiredMembers]
    public Minimum(double amount)
        : this()
    {
        this.Amount = amount;
    }
}

class MinimumFromRaw : IFromRawJson<Minimum>
{
    /// <inheritdoc/>
    public Minimum FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Minimum.FromRawUnchecked(rawData);
}

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

[JsonConverter(typeof(JsonModelConverter<PriceOverride, PriceOverrideFromRaw>))]
public sealed record class PriceOverride : JsonModel
{
    /// <summary>
    /// Feature ID
    /// </summary>
    public required string FeatureID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("featureId");
        }
        init { this._rawData.Set("featureId", value); }
    }

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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FeatureID;
        this.Price?.Validate();
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

    [SetsRequiredMembers]
    public PriceOverride(string featureID)
        : this()
    {
        this.FeatureID = featureID;
    }
}

class PriceOverrideFromRaw : IFromRawJson<PriceOverride>
{
    /// <inheritdoc/>
    public PriceOverride FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PriceOverride.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Price, PriceFromRaw>))]
public sealed record class Price : JsonModel
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

    [SetsRequiredMembers]
    public Price(double amount)
        : this()
    {
        this.Amount = amount;
    }
}

class PriceFromRaw : IFromRawJson<Price>
{
    /// <inheritdoc/>
    public Price FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Price.FromRawUnchecked(rawData);
}

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

    public MonthlyResetPeriodConfiguration? MonthlyResetPeriodConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MonthlyResetPeriodConfiguration>(
                "monthlyResetPeriodConfiguration"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("monthlyResetPeriodConfiguration", value);
        }
    }

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

    public double? UsageLimit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("usageLimit");
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

    public WeeklyResetPeriodConfiguration? WeeklyResetPeriodConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WeeklyResetPeriodConfiguration>(
                "weeklyResetPeriodConfiguration"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("weeklyResetPeriodConfiguration", value);
        }
    }

    public YearlyResetPeriodConfiguration? YearlyResetPeriodConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<YearlyResetPeriodConfiguration>(
                "yearlyResetPeriodConfiguration"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("yearlyResetPeriodConfiguration", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.FeatureID;
        _ = this.HasSoftLimit;
        _ = this.HasUnlimitedUsage;
        this.MonthlyResetPeriodConfiguration?.Validate();
        this.ResetPeriod?.Validate();
        _ = this.UsageLimit;
        this.WeeklyResetPeriodConfiguration?.Validate();
        this.YearlyResetPeriodConfiguration?.Validate();
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
    typeof(JsonModelConverter<
        MonthlyResetPeriodConfiguration,
        MonthlyResetPeriodConfigurationFromRaw
    >)
)]
public sealed record class MonthlyResetPeriodConfiguration : JsonModel
{
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

[JsonConverter(
    typeof(JsonModelConverter<
        WeeklyResetPeriodConfiguration,
        WeeklyResetPeriodConfigurationFromRaw
    >)
)]
public sealed record class WeeklyResetPeriodConfiguration : JsonModel
{
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

[JsonConverter(
    typeof(JsonModelConverter<
        YearlyResetPeriodConfiguration,
        YearlyResetPeriodConfigurationFromRaw
    >)
)]
public sealed record class YearlyResetPeriodConfiguration : JsonModel
{
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
