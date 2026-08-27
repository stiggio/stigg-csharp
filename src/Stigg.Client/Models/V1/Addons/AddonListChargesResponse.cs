using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using System = System;

namespace Stigg.Client.Models.V1.Addons;

/// <summary>
/// A single pricing row on a plan or addon. Each charge encodes one (billingPeriod,
/// billingModel, billingCadence, billingCountryCode) combination. Plans and addons
/// own many of these — one per currency / billing period / feature.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<AddonListChargesResponse, AddonListChargesResponseFromRaw>)
)]
public sealed record class AddonListChargesResponse : JsonModel
{
    /// <summary>
    /// Unique identifier of the charge
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
    /// The billing cadence (RECURRING or ONE_OFF)
    /// </summary>
    public required ApiEnum<string, AddonListChargesResponseBillingCadence> BillingCadence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, AddonListChargesResponseBillingCadence>
            >("billingCadence");
        }
        init { this._rawData.Set("billingCadence", value); }
    }

    /// <summary>
    /// The billing model (FLAT_FEE, PER_UNIT, USAGE_BASED, CREDIT_BASED, MINIMUM_SPEND)
    /// </summary>
    public required ApiEnum<string, AddonListChargesResponseBillingModel> BillingModel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, AddonListChargesResponseBillingModel>
            >("billingModel");
        }
        init { this._rawData.Set("billingModel", value); }
    }

    /// <summary>
    /// The billing period (MONTHLY or ANNUALLY)
    /// </summary>
    public required ApiEnum<string, AddonListChargesResponseBillingPeriod> BillingPeriod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, AddonListChargesResponseBillingPeriod>
            >("billingPeriod");
        }
        init { this._rawData.Set("billingPeriod", value); }
    }

    /// <summary>
    /// Timestamp when the charge was created
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
    /// ISO country code (or "eu" for Eurozone) for localized pricing, if any
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
    /// Identifier in the external billing integration (e.g. Stripe price id), if any
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

    /// <summary>
    /// Block size for usage-based pricing
    /// </summary>
    public double? BlockSize
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("blockSize");
        }
        init { this._rawData.Set("blockSize", value); }
    }

    /// <summary>
    /// When credits are granted (for credit-based pricing)
    /// </summary>
    public ApiEnum<string, AddonListChargesResponseCreditGrantCadence>? CreditGrantCadence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, AddonListChargesResponseCreditGrantCadence>
            >("creditGrantCadence");
        }
        init { this._rawData.Set("creditGrantCadence", value); }
    }

    /// <summary>
    /// Credit rate configuration for credit-based pricing
    /// </summary>
    public AddonListChargesResponseCreditRate? CreditRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AddonListChargesResponseCreditRate>("creditRate");
        }
        init { this._rawData.Set("creditRate", value); }
    }

    /// <summary>
    /// Identifier in the linked CRM, if any
    /// </summary>
    public string? CrmID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("crmId");
        }
        init { this._rawData.Set("crmId", value); }
    }

    /// <summary>
    /// Deep link to the charge in the linked CRM, if any
    /// </summary>
    public string? CrmLinkUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("crmLinkUrl");
        }
        init { this._rawData.Set("crmLinkUrl", value); }
    }

    /// <summary>
    /// The feature this charge meters, if metered
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
    /// Maximum unit quantity that can be purchased
    /// </summary>
    public double? MaxUnitQuantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("maxUnitQuantity");
        }
        init { this._rawData.Set("maxUnitQuantity", value); }
    }

    /// <summary>
    /// Minimum unit quantity that can be purchased
    /// </summary>
    public double? MinUnitQuantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("minUnitQuantity");
        }
        init { this._rawData.Set("minUnitQuantity", value); }
    }

    /// <summary>
    /// The flat price amount and currency, when applicable
    /// </summary>
    public AddonListChargesResponsePrice? Price
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AddonListChargesResponsePrice>("price");
        }
        init { this._rawData.Set("price", value); }
    }

    /// <summary>
    /// Tiered pricing rows when the charge is tiered
    /// </summary>
    public IReadOnlyList<AddonListChargesResponseTier>? Tiers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<AddonListChargesResponseTier>>(
                "tiers"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<AddonListChargesResponseTier>?>(
                "tiers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Tiered pricing mode (VOLUME or GRADUATED) when the charge is tiered
    /// </summary>
    public ApiEnum<string, AddonListChargesResponseTiersMode>? TiersMode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, AddonListChargesResponseTiersMode>
            >("tiersMode");
        }
        init { this._rawData.Set("tiersMode", value); }
    }

    /// <summary>
    /// Custom currency identifier for top-up pricing, if any
    /// </summary>
    public string? TopUpCustomCurrencyID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("topUpCustomCurrencyId");
        }
        init { this._rawData.Set("topUpCustomCurrencyId", value); }
    }

    /// <summary>
    /// True if this charge is referenced by at least one subscription
    /// </summary>
    public bool? UsedInSubscriptions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("usedInSubscriptions");
        }
        init { this._rawData.Set("usedInSubscriptions", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.BillingCadence.Validate();
        this.BillingModel.Validate();
        this.BillingPeriod.Validate();
        _ = this.CreatedAt;
        _ = this.BillingCountryCode;
        _ = this.BillingID;
        _ = this.BlockSize;
        this.CreditGrantCadence?.Validate();
        this.CreditRate?.Validate();
        _ = this.CrmID;
        _ = this.CrmLinkUrl;
        _ = this.FeatureID;
        _ = this.MaxUnitQuantity;
        _ = this.MinUnitQuantity;
        this.Price?.Validate();
        foreach (var item in this.Tiers ?? [])
        {
            item.Validate();
        }
        this.TiersMode?.Validate();
        _ = this.TopUpCustomCurrencyID;
        _ = this.UsedInSubscriptions;
    }

    public AddonListChargesResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AddonListChargesResponse(AddonListChargesResponse addonListChargesResponse)
        : base(addonListChargesResponse) { }
#pragma warning restore CS8618

    public AddonListChargesResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddonListChargesResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AddonListChargesResponseFromRaw.FromRawUnchecked"/>
    public static AddonListChargesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AddonListChargesResponseFromRaw : IFromRawJson<AddonListChargesResponse>
{
    /// <inheritdoc/>
    public AddonListChargesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AddonListChargesResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// The billing cadence (RECURRING or ONE_OFF)
/// </summary>
[JsonConverter(typeof(AddonListChargesResponseBillingCadenceConverter))]
public enum AddonListChargesResponseBillingCadence
{
    Recurring,
    OneOff,
}

sealed class AddonListChargesResponseBillingCadenceConverter
    : JsonConverter<AddonListChargesResponseBillingCadence>
{
    public override AddonListChargesResponseBillingCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "RECURRING" => AddonListChargesResponseBillingCadence.Recurring,
            "ONE_OFF" => AddonListChargesResponseBillingCadence.OneOff,
            _ => (AddonListChargesResponseBillingCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AddonListChargesResponseBillingCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AddonListChargesResponseBillingCadence.Recurring => "RECURRING",
                AddonListChargesResponseBillingCadence.OneOff => "ONE_OFF",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The billing model (FLAT_FEE, PER_UNIT, USAGE_BASED, CREDIT_BASED, MINIMUM_SPEND)
/// </summary>
[JsonConverter(typeof(AddonListChargesResponseBillingModelConverter))]
public enum AddonListChargesResponseBillingModel
{
    FlatFee,
    MinimumSpend,
    PerUnit,
    UsageBased,
    CreditBased,
}

sealed class AddonListChargesResponseBillingModelConverter
    : JsonConverter<AddonListChargesResponseBillingModel>
{
    public override AddonListChargesResponseBillingModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FLAT_FEE" => AddonListChargesResponseBillingModel.FlatFee,
            "MINIMUM_SPEND" => AddonListChargesResponseBillingModel.MinimumSpend,
            "PER_UNIT" => AddonListChargesResponseBillingModel.PerUnit,
            "USAGE_BASED" => AddonListChargesResponseBillingModel.UsageBased,
            "CREDIT_BASED" => AddonListChargesResponseBillingModel.CreditBased,
            _ => (AddonListChargesResponseBillingModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AddonListChargesResponseBillingModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AddonListChargesResponseBillingModel.FlatFee => "FLAT_FEE",
                AddonListChargesResponseBillingModel.MinimumSpend => "MINIMUM_SPEND",
                AddonListChargesResponseBillingModel.PerUnit => "PER_UNIT",
                AddonListChargesResponseBillingModel.UsageBased => "USAGE_BASED",
                AddonListChargesResponseBillingModel.CreditBased => "CREDIT_BASED",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The billing period (MONTHLY or ANNUALLY)
/// </summary>
[JsonConverter(typeof(AddonListChargesResponseBillingPeriodConverter))]
public enum AddonListChargesResponseBillingPeriod
{
    Monthly,
    Annually,
}

sealed class AddonListChargesResponseBillingPeriodConverter
    : JsonConverter<AddonListChargesResponseBillingPeriod>
{
    public override AddonListChargesResponseBillingPeriod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "MONTHLY" => AddonListChargesResponseBillingPeriod.Monthly,
            "ANNUALLY" => AddonListChargesResponseBillingPeriod.Annually,
            _ => (AddonListChargesResponseBillingPeriod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AddonListChargesResponseBillingPeriod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AddonListChargesResponseBillingPeriod.Monthly => "MONTHLY",
                AddonListChargesResponseBillingPeriod.Annually => "ANNUALLY",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// When credits are granted (for credit-based pricing)
/// </summary>
[JsonConverter(typeof(AddonListChargesResponseCreditGrantCadenceConverter))]
public enum AddonListChargesResponseCreditGrantCadence
{
    BeginningOfBillingPeriod,
    Monthly,
}

sealed class AddonListChargesResponseCreditGrantCadenceConverter
    : JsonConverter<AddonListChargesResponseCreditGrantCadence>
{
    public override AddonListChargesResponseCreditGrantCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "BEGINNING_OF_BILLING_PERIOD" =>
                AddonListChargesResponseCreditGrantCadence.BeginningOfBillingPeriod,
            "MONTHLY" => AddonListChargesResponseCreditGrantCadence.Monthly,
            _ => (AddonListChargesResponseCreditGrantCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AddonListChargesResponseCreditGrantCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AddonListChargesResponseCreditGrantCadence.BeginningOfBillingPeriod =>
                    "BEGINNING_OF_BILLING_PERIOD",
                AddonListChargesResponseCreditGrantCadence.Monthly => "MONTHLY",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Credit rate configuration for credit-based pricing
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        AddonListChargesResponseCreditRate,
        AddonListChargesResponseCreditRateFromRaw
    >)
)]
public sealed record class AddonListChargesResponseCreditRate : JsonModel
{
    /// <summary>
    /// Credit rate amount
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
    /// Custom currency identifier
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
    /// Optional cost formula expression
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

    public AddonListChargesResponseCreditRate() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AddonListChargesResponseCreditRate(
        AddonListChargesResponseCreditRate addonListChargesResponseCreditRate
    )
        : base(addonListChargesResponseCreditRate) { }
#pragma warning restore CS8618

    public AddonListChargesResponseCreditRate(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddonListChargesResponseCreditRate(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AddonListChargesResponseCreditRateFromRaw.FromRawUnchecked"/>
    public static AddonListChargesResponseCreditRate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AddonListChargesResponseCreditRateFromRaw : IFromRawJson<AddonListChargesResponseCreditRate>
{
    /// <inheritdoc/>
    public AddonListChargesResponseCreditRate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AddonListChargesResponseCreditRate.FromRawUnchecked(rawData);
}

/// <summary>
/// The flat price amount and currency, when applicable
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<AddonListChargesResponsePrice, AddonListChargesResponsePriceFromRaw>)
)]
public sealed record class AddonListChargesResponsePrice : JsonModel
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
    public required ApiEnum<string, AddonListChargesResponsePriceCurrency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, AddonListChargesResponsePriceCurrency>
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

    public AddonListChargesResponsePrice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AddonListChargesResponsePrice(
        AddonListChargesResponsePrice addonListChargesResponsePrice
    )
        : base(addonListChargesResponsePrice) { }
#pragma warning restore CS8618

    public AddonListChargesResponsePrice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddonListChargesResponsePrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AddonListChargesResponsePriceFromRaw.FromRawUnchecked"/>
    public static AddonListChargesResponsePrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AddonListChargesResponsePriceFromRaw : IFromRawJson<AddonListChargesResponsePrice>
{
    /// <inheritdoc/>
    public AddonListChargesResponsePrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AddonListChargesResponsePrice.FromRawUnchecked(rawData);
}

/// <summary>
/// ISO 4217 currency code
/// </summary>
[JsonConverter(typeof(AddonListChargesResponsePriceCurrencyConverter))]
public enum AddonListChargesResponsePriceCurrency
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

sealed class AddonListChargesResponsePriceCurrencyConverter
    : JsonConverter<AddonListChargesResponsePriceCurrency>
{
    public override AddonListChargesResponsePriceCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => AddonListChargesResponsePriceCurrency.Usd,
            "aed" => AddonListChargesResponsePriceCurrency.Aed,
            "all" => AddonListChargesResponsePriceCurrency.All,
            "amd" => AddonListChargesResponsePriceCurrency.Amd,
            "ang" => AddonListChargesResponsePriceCurrency.Ang,
            "aud" => AddonListChargesResponsePriceCurrency.Aud,
            "awg" => AddonListChargesResponsePriceCurrency.Awg,
            "azn" => AddonListChargesResponsePriceCurrency.Azn,
            "bam" => AddonListChargesResponsePriceCurrency.Bam,
            "bbd" => AddonListChargesResponsePriceCurrency.Bbd,
            "bdt" => AddonListChargesResponsePriceCurrency.Bdt,
            "bgn" => AddonListChargesResponsePriceCurrency.Bgn,
            "bif" => AddonListChargesResponsePriceCurrency.Bif,
            "bmd" => AddonListChargesResponsePriceCurrency.Bmd,
            "bnd" => AddonListChargesResponsePriceCurrency.Bnd,
            "bsd" => AddonListChargesResponsePriceCurrency.Bsd,
            "bwp" => AddonListChargesResponsePriceCurrency.Bwp,
            "byn" => AddonListChargesResponsePriceCurrency.Byn,
            "bzd" => AddonListChargesResponsePriceCurrency.Bzd,
            "brl" => AddonListChargesResponsePriceCurrency.Brl,
            "cad" => AddonListChargesResponsePriceCurrency.Cad,
            "cdf" => AddonListChargesResponsePriceCurrency.Cdf,
            "chf" => AddonListChargesResponsePriceCurrency.Chf,
            "cny" => AddonListChargesResponsePriceCurrency.Cny,
            "czk" => AddonListChargesResponsePriceCurrency.Czk,
            "dkk" => AddonListChargesResponsePriceCurrency.Dkk,
            "dop" => AddonListChargesResponsePriceCurrency.Dop,
            "dzd" => AddonListChargesResponsePriceCurrency.Dzd,
            "egp" => AddonListChargesResponsePriceCurrency.Egp,
            "etb" => AddonListChargesResponsePriceCurrency.Etb,
            "eur" => AddonListChargesResponsePriceCurrency.Eur,
            "fjd" => AddonListChargesResponsePriceCurrency.Fjd,
            "gbp" => AddonListChargesResponsePriceCurrency.Gbp,
            "gel" => AddonListChargesResponsePriceCurrency.Gel,
            "gip" => AddonListChargesResponsePriceCurrency.Gip,
            "gmd" => AddonListChargesResponsePriceCurrency.Gmd,
            "gyd" => AddonListChargesResponsePriceCurrency.Gyd,
            "hkd" => AddonListChargesResponsePriceCurrency.Hkd,
            "hrk" => AddonListChargesResponsePriceCurrency.Hrk,
            "htg" => AddonListChargesResponsePriceCurrency.Htg,
            "idr" => AddonListChargesResponsePriceCurrency.Idr,
            "ils" => AddonListChargesResponsePriceCurrency.Ils,
            "inr" => AddonListChargesResponsePriceCurrency.Inr,
            "isk" => AddonListChargesResponsePriceCurrency.Isk,
            "jmd" => AddonListChargesResponsePriceCurrency.Jmd,
            "jpy" => AddonListChargesResponsePriceCurrency.Jpy,
            "kes" => AddonListChargesResponsePriceCurrency.Kes,
            "kgs" => AddonListChargesResponsePriceCurrency.Kgs,
            "khr" => AddonListChargesResponsePriceCurrency.Khr,
            "kmf" => AddonListChargesResponsePriceCurrency.Kmf,
            "krw" => AddonListChargesResponsePriceCurrency.Krw,
            "kyd" => AddonListChargesResponsePriceCurrency.Kyd,
            "kzt" => AddonListChargesResponsePriceCurrency.Kzt,
            "lbp" => AddonListChargesResponsePriceCurrency.Lbp,
            "lkr" => AddonListChargesResponsePriceCurrency.Lkr,
            "lrd" => AddonListChargesResponsePriceCurrency.Lrd,
            "lsl" => AddonListChargesResponsePriceCurrency.Lsl,
            "mad" => AddonListChargesResponsePriceCurrency.Mad,
            "mdl" => AddonListChargesResponsePriceCurrency.Mdl,
            "mga" => AddonListChargesResponsePriceCurrency.Mga,
            "mkd" => AddonListChargesResponsePriceCurrency.Mkd,
            "mmk" => AddonListChargesResponsePriceCurrency.Mmk,
            "mnt" => AddonListChargesResponsePriceCurrency.Mnt,
            "mop" => AddonListChargesResponsePriceCurrency.Mop,
            "mro" => AddonListChargesResponsePriceCurrency.Mro,
            "mvr" => AddonListChargesResponsePriceCurrency.Mvr,
            "mwk" => AddonListChargesResponsePriceCurrency.Mwk,
            "mxn" => AddonListChargesResponsePriceCurrency.Mxn,
            "myr" => AddonListChargesResponsePriceCurrency.Myr,
            "mzn" => AddonListChargesResponsePriceCurrency.Mzn,
            "nad" => AddonListChargesResponsePriceCurrency.Nad,
            "ngn" => AddonListChargesResponsePriceCurrency.Ngn,
            "nok" => AddonListChargesResponsePriceCurrency.Nok,
            "npr" => AddonListChargesResponsePriceCurrency.Npr,
            "nzd" => AddonListChargesResponsePriceCurrency.Nzd,
            "pgk" => AddonListChargesResponsePriceCurrency.Pgk,
            "php" => AddonListChargesResponsePriceCurrency.Php,
            "pkr" => AddonListChargesResponsePriceCurrency.Pkr,
            "pln" => AddonListChargesResponsePriceCurrency.Pln,
            "qar" => AddonListChargesResponsePriceCurrency.Qar,
            "ron" => AddonListChargesResponsePriceCurrency.Ron,
            "rsd" => AddonListChargesResponsePriceCurrency.Rsd,
            "rub" => AddonListChargesResponsePriceCurrency.Rub,
            "rwf" => AddonListChargesResponsePriceCurrency.Rwf,
            "sar" => AddonListChargesResponsePriceCurrency.Sar,
            "sbd" => AddonListChargesResponsePriceCurrency.Sbd,
            "scr" => AddonListChargesResponsePriceCurrency.Scr,
            "sek" => AddonListChargesResponsePriceCurrency.Sek,
            "sgd" => AddonListChargesResponsePriceCurrency.Sgd,
            "sle" => AddonListChargesResponsePriceCurrency.Sle,
            "sll" => AddonListChargesResponsePriceCurrency.Sll,
            "sos" => AddonListChargesResponsePriceCurrency.Sos,
            "szl" => AddonListChargesResponsePriceCurrency.Szl,
            "thb" => AddonListChargesResponsePriceCurrency.Thb,
            "tjs" => AddonListChargesResponsePriceCurrency.Tjs,
            "top" => AddonListChargesResponsePriceCurrency.Top,
            "try" => AddonListChargesResponsePriceCurrency.Try,
            "ttd" => AddonListChargesResponsePriceCurrency.Ttd,
            "tzs" => AddonListChargesResponsePriceCurrency.Tzs,
            "uah" => AddonListChargesResponsePriceCurrency.Uah,
            "uzs" => AddonListChargesResponsePriceCurrency.Uzs,
            "vnd" => AddonListChargesResponsePriceCurrency.Vnd,
            "vuv" => AddonListChargesResponsePriceCurrency.Vuv,
            "wst" => AddonListChargesResponsePriceCurrency.Wst,
            "xaf" => AddonListChargesResponsePriceCurrency.Xaf,
            "xcd" => AddonListChargesResponsePriceCurrency.Xcd,
            "yer" => AddonListChargesResponsePriceCurrency.Yer,
            "zar" => AddonListChargesResponsePriceCurrency.Zar,
            "zmw" => AddonListChargesResponsePriceCurrency.Zmw,
            "clp" => AddonListChargesResponsePriceCurrency.Clp,
            "djf" => AddonListChargesResponsePriceCurrency.Djf,
            "gnf" => AddonListChargesResponsePriceCurrency.Gnf,
            "ugx" => AddonListChargesResponsePriceCurrency.Ugx,
            "pyg" => AddonListChargesResponsePriceCurrency.Pyg,
            "xof" => AddonListChargesResponsePriceCurrency.Xof,
            "xpf" => AddonListChargesResponsePriceCurrency.Xpf,
            _ => (AddonListChargesResponsePriceCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AddonListChargesResponsePriceCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AddonListChargesResponsePriceCurrency.Usd => "usd",
                AddonListChargesResponsePriceCurrency.Aed => "aed",
                AddonListChargesResponsePriceCurrency.All => "all",
                AddonListChargesResponsePriceCurrency.Amd => "amd",
                AddonListChargesResponsePriceCurrency.Ang => "ang",
                AddonListChargesResponsePriceCurrency.Aud => "aud",
                AddonListChargesResponsePriceCurrency.Awg => "awg",
                AddonListChargesResponsePriceCurrency.Azn => "azn",
                AddonListChargesResponsePriceCurrency.Bam => "bam",
                AddonListChargesResponsePriceCurrency.Bbd => "bbd",
                AddonListChargesResponsePriceCurrency.Bdt => "bdt",
                AddonListChargesResponsePriceCurrency.Bgn => "bgn",
                AddonListChargesResponsePriceCurrency.Bif => "bif",
                AddonListChargesResponsePriceCurrency.Bmd => "bmd",
                AddonListChargesResponsePriceCurrency.Bnd => "bnd",
                AddonListChargesResponsePriceCurrency.Bsd => "bsd",
                AddonListChargesResponsePriceCurrency.Bwp => "bwp",
                AddonListChargesResponsePriceCurrency.Byn => "byn",
                AddonListChargesResponsePriceCurrency.Bzd => "bzd",
                AddonListChargesResponsePriceCurrency.Brl => "brl",
                AddonListChargesResponsePriceCurrency.Cad => "cad",
                AddonListChargesResponsePriceCurrency.Cdf => "cdf",
                AddonListChargesResponsePriceCurrency.Chf => "chf",
                AddonListChargesResponsePriceCurrency.Cny => "cny",
                AddonListChargesResponsePriceCurrency.Czk => "czk",
                AddonListChargesResponsePriceCurrency.Dkk => "dkk",
                AddonListChargesResponsePriceCurrency.Dop => "dop",
                AddonListChargesResponsePriceCurrency.Dzd => "dzd",
                AddonListChargesResponsePriceCurrency.Egp => "egp",
                AddonListChargesResponsePriceCurrency.Etb => "etb",
                AddonListChargesResponsePriceCurrency.Eur => "eur",
                AddonListChargesResponsePriceCurrency.Fjd => "fjd",
                AddonListChargesResponsePriceCurrency.Gbp => "gbp",
                AddonListChargesResponsePriceCurrency.Gel => "gel",
                AddonListChargesResponsePriceCurrency.Gip => "gip",
                AddonListChargesResponsePriceCurrency.Gmd => "gmd",
                AddonListChargesResponsePriceCurrency.Gyd => "gyd",
                AddonListChargesResponsePriceCurrency.Hkd => "hkd",
                AddonListChargesResponsePriceCurrency.Hrk => "hrk",
                AddonListChargesResponsePriceCurrency.Htg => "htg",
                AddonListChargesResponsePriceCurrency.Idr => "idr",
                AddonListChargesResponsePriceCurrency.Ils => "ils",
                AddonListChargesResponsePriceCurrency.Inr => "inr",
                AddonListChargesResponsePriceCurrency.Isk => "isk",
                AddonListChargesResponsePriceCurrency.Jmd => "jmd",
                AddonListChargesResponsePriceCurrency.Jpy => "jpy",
                AddonListChargesResponsePriceCurrency.Kes => "kes",
                AddonListChargesResponsePriceCurrency.Kgs => "kgs",
                AddonListChargesResponsePriceCurrency.Khr => "khr",
                AddonListChargesResponsePriceCurrency.Kmf => "kmf",
                AddonListChargesResponsePriceCurrency.Krw => "krw",
                AddonListChargesResponsePriceCurrency.Kyd => "kyd",
                AddonListChargesResponsePriceCurrency.Kzt => "kzt",
                AddonListChargesResponsePriceCurrency.Lbp => "lbp",
                AddonListChargesResponsePriceCurrency.Lkr => "lkr",
                AddonListChargesResponsePriceCurrency.Lrd => "lrd",
                AddonListChargesResponsePriceCurrency.Lsl => "lsl",
                AddonListChargesResponsePriceCurrency.Mad => "mad",
                AddonListChargesResponsePriceCurrency.Mdl => "mdl",
                AddonListChargesResponsePriceCurrency.Mga => "mga",
                AddonListChargesResponsePriceCurrency.Mkd => "mkd",
                AddonListChargesResponsePriceCurrency.Mmk => "mmk",
                AddonListChargesResponsePriceCurrency.Mnt => "mnt",
                AddonListChargesResponsePriceCurrency.Mop => "mop",
                AddonListChargesResponsePriceCurrency.Mro => "mro",
                AddonListChargesResponsePriceCurrency.Mvr => "mvr",
                AddonListChargesResponsePriceCurrency.Mwk => "mwk",
                AddonListChargesResponsePriceCurrency.Mxn => "mxn",
                AddonListChargesResponsePriceCurrency.Myr => "myr",
                AddonListChargesResponsePriceCurrency.Mzn => "mzn",
                AddonListChargesResponsePriceCurrency.Nad => "nad",
                AddonListChargesResponsePriceCurrency.Ngn => "ngn",
                AddonListChargesResponsePriceCurrency.Nok => "nok",
                AddonListChargesResponsePriceCurrency.Npr => "npr",
                AddonListChargesResponsePriceCurrency.Nzd => "nzd",
                AddonListChargesResponsePriceCurrency.Pgk => "pgk",
                AddonListChargesResponsePriceCurrency.Php => "php",
                AddonListChargesResponsePriceCurrency.Pkr => "pkr",
                AddonListChargesResponsePriceCurrency.Pln => "pln",
                AddonListChargesResponsePriceCurrency.Qar => "qar",
                AddonListChargesResponsePriceCurrency.Ron => "ron",
                AddonListChargesResponsePriceCurrency.Rsd => "rsd",
                AddonListChargesResponsePriceCurrency.Rub => "rub",
                AddonListChargesResponsePriceCurrency.Rwf => "rwf",
                AddonListChargesResponsePriceCurrency.Sar => "sar",
                AddonListChargesResponsePriceCurrency.Sbd => "sbd",
                AddonListChargesResponsePriceCurrency.Scr => "scr",
                AddonListChargesResponsePriceCurrency.Sek => "sek",
                AddonListChargesResponsePriceCurrency.Sgd => "sgd",
                AddonListChargesResponsePriceCurrency.Sle => "sle",
                AddonListChargesResponsePriceCurrency.Sll => "sll",
                AddonListChargesResponsePriceCurrency.Sos => "sos",
                AddonListChargesResponsePriceCurrency.Szl => "szl",
                AddonListChargesResponsePriceCurrency.Thb => "thb",
                AddonListChargesResponsePriceCurrency.Tjs => "tjs",
                AddonListChargesResponsePriceCurrency.Top => "top",
                AddonListChargesResponsePriceCurrency.Try => "try",
                AddonListChargesResponsePriceCurrency.Ttd => "ttd",
                AddonListChargesResponsePriceCurrency.Tzs => "tzs",
                AddonListChargesResponsePriceCurrency.Uah => "uah",
                AddonListChargesResponsePriceCurrency.Uzs => "uzs",
                AddonListChargesResponsePriceCurrency.Vnd => "vnd",
                AddonListChargesResponsePriceCurrency.Vuv => "vuv",
                AddonListChargesResponsePriceCurrency.Wst => "wst",
                AddonListChargesResponsePriceCurrency.Xaf => "xaf",
                AddonListChargesResponsePriceCurrency.Xcd => "xcd",
                AddonListChargesResponsePriceCurrency.Yer => "yer",
                AddonListChargesResponsePriceCurrency.Zar => "zar",
                AddonListChargesResponsePriceCurrency.Zmw => "zmw",
                AddonListChargesResponsePriceCurrency.Clp => "clp",
                AddonListChargesResponsePriceCurrency.Djf => "djf",
                AddonListChargesResponsePriceCurrency.Gnf => "gnf",
                AddonListChargesResponsePriceCurrency.Ugx => "ugx",
                AddonListChargesResponsePriceCurrency.Pyg => "pyg",
                AddonListChargesResponsePriceCurrency.Xof => "xof",
                AddonListChargesResponsePriceCurrency.Xpf => "xpf",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A single tier within a tiered charge
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<AddonListChargesResponseTier, AddonListChargesResponseTierFromRaw>)
)]
public sealed record class AddonListChargesResponseTier : JsonModel
{
    /// <summary>
    /// Flat price for this tier
    /// </summary>
    public AddonListChargesResponseTierFlatPrice? FlatPrice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AddonListChargesResponseTierFlatPrice>(
                "flatPrice"
            );
        }
        init { this._rawData.Set("flatPrice", value); }
    }

    /// <summary>
    /// Per-unit price in this tier
    /// </summary>
    public AddonListChargesResponseTierUnitPrice? UnitPrice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AddonListChargesResponseTierUnitPrice>(
                "unitPrice"
            );
        }
        init { this._rawData.Set("unitPrice", value); }
    }

    /// <summary>
    /// Upper bound of this tier (null for unlimited)
    /// </summary>
    public double? UpTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("upTo");
        }
        init { this._rawData.Set("upTo", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.FlatPrice?.Validate();
        this.UnitPrice?.Validate();
        _ = this.UpTo;
    }

    public AddonListChargesResponseTier() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AddonListChargesResponseTier(AddonListChargesResponseTier addonListChargesResponseTier)
        : base(addonListChargesResponseTier) { }
#pragma warning restore CS8618

    public AddonListChargesResponseTier(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddonListChargesResponseTier(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AddonListChargesResponseTierFromRaw.FromRawUnchecked"/>
    public static AddonListChargesResponseTier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AddonListChargesResponseTierFromRaw : IFromRawJson<AddonListChargesResponseTier>
{
    /// <inheritdoc/>
    public AddonListChargesResponseTier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AddonListChargesResponseTier.FromRawUnchecked(rawData);
}

/// <summary>
/// Flat price for this tier
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        AddonListChargesResponseTierFlatPrice,
        AddonListChargesResponseTierFlatPriceFromRaw
    >)
)]
public sealed record class AddonListChargesResponseTierFlatPrice : JsonModel
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
    public required ApiEnum<string, AddonListChargesResponseTierFlatPriceCurrency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, AddonListChargesResponseTierFlatPriceCurrency>
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

    public AddonListChargesResponseTierFlatPrice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AddonListChargesResponseTierFlatPrice(
        AddonListChargesResponseTierFlatPrice addonListChargesResponseTierFlatPrice
    )
        : base(addonListChargesResponseTierFlatPrice) { }
#pragma warning restore CS8618

    public AddonListChargesResponseTierFlatPrice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddonListChargesResponseTierFlatPrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AddonListChargesResponseTierFlatPriceFromRaw.FromRawUnchecked"/>
    public static AddonListChargesResponseTierFlatPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AddonListChargesResponseTierFlatPriceFromRaw
    : IFromRawJson<AddonListChargesResponseTierFlatPrice>
{
    /// <inheritdoc/>
    public AddonListChargesResponseTierFlatPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AddonListChargesResponseTierFlatPrice.FromRawUnchecked(rawData);
}

/// <summary>
/// ISO 4217 currency code
/// </summary>
[JsonConverter(typeof(AddonListChargesResponseTierFlatPriceCurrencyConverter))]
public enum AddonListChargesResponseTierFlatPriceCurrency
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

sealed class AddonListChargesResponseTierFlatPriceCurrencyConverter
    : JsonConverter<AddonListChargesResponseTierFlatPriceCurrency>
{
    public override AddonListChargesResponseTierFlatPriceCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => AddonListChargesResponseTierFlatPriceCurrency.Usd,
            "aed" => AddonListChargesResponseTierFlatPriceCurrency.Aed,
            "all" => AddonListChargesResponseTierFlatPriceCurrency.All,
            "amd" => AddonListChargesResponseTierFlatPriceCurrency.Amd,
            "ang" => AddonListChargesResponseTierFlatPriceCurrency.Ang,
            "aud" => AddonListChargesResponseTierFlatPriceCurrency.Aud,
            "awg" => AddonListChargesResponseTierFlatPriceCurrency.Awg,
            "azn" => AddonListChargesResponseTierFlatPriceCurrency.Azn,
            "bam" => AddonListChargesResponseTierFlatPriceCurrency.Bam,
            "bbd" => AddonListChargesResponseTierFlatPriceCurrency.Bbd,
            "bdt" => AddonListChargesResponseTierFlatPriceCurrency.Bdt,
            "bgn" => AddonListChargesResponseTierFlatPriceCurrency.Bgn,
            "bif" => AddonListChargesResponseTierFlatPriceCurrency.Bif,
            "bmd" => AddonListChargesResponseTierFlatPriceCurrency.Bmd,
            "bnd" => AddonListChargesResponseTierFlatPriceCurrency.Bnd,
            "bsd" => AddonListChargesResponseTierFlatPriceCurrency.Bsd,
            "bwp" => AddonListChargesResponseTierFlatPriceCurrency.Bwp,
            "byn" => AddonListChargesResponseTierFlatPriceCurrency.Byn,
            "bzd" => AddonListChargesResponseTierFlatPriceCurrency.Bzd,
            "brl" => AddonListChargesResponseTierFlatPriceCurrency.Brl,
            "cad" => AddonListChargesResponseTierFlatPriceCurrency.Cad,
            "cdf" => AddonListChargesResponseTierFlatPriceCurrency.Cdf,
            "chf" => AddonListChargesResponseTierFlatPriceCurrency.Chf,
            "cny" => AddonListChargesResponseTierFlatPriceCurrency.Cny,
            "czk" => AddonListChargesResponseTierFlatPriceCurrency.Czk,
            "dkk" => AddonListChargesResponseTierFlatPriceCurrency.Dkk,
            "dop" => AddonListChargesResponseTierFlatPriceCurrency.Dop,
            "dzd" => AddonListChargesResponseTierFlatPriceCurrency.Dzd,
            "egp" => AddonListChargesResponseTierFlatPriceCurrency.Egp,
            "etb" => AddonListChargesResponseTierFlatPriceCurrency.Etb,
            "eur" => AddonListChargesResponseTierFlatPriceCurrency.Eur,
            "fjd" => AddonListChargesResponseTierFlatPriceCurrency.Fjd,
            "gbp" => AddonListChargesResponseTierFlatPriceCurrency.Gbp,
            "gel" => AddonListChargesResponseTierFlatPriceCurrency.Gel,
            "gip" => AddonListChargesResponseTierFlatPriceCurrency.Gip,
            "gmd" => AddonListChargesResponseTierFlatPriceCurrency.Gmd,
            "gyd" => AddonListChargesResponseTierFlatPriceCurrency.Gyd,
            "hkd" => AddonListChargesResponseTierFlatPriceCurrency.Hkd,
            "hrk" => AddonListChargesResponseTierFlatPriceCurrency.Hrk,
            "htg" => AddonListChargesResponseTierFlatPriceCurrency.Htg,
            "idr" => AddonListChargesResponseTierFlatPriceCurrency.Idr,
            "ils" => AddonListChargesResponseTierFlatPriceCurrency.Ils,
            "inr" => AddonListChargesResponseTierFlatPriceCurrency.Inr,
            "isk" => AddonListChargesResponseTierFlatPriceCurrency.Isk,
            "jmd" => AddonListChargesResponseTierFlatPriceCurrency.Jmd,
            "jpy" => AddonListChargesResponseTierFlatPriceCurrency.Jpy,
            "kes" => AddonListChargesResponseTierFlatPriceCurrency.Kes,
            "kgs" => AddonListChargesResponseTierFlatPriceCurrency.Kgs,
            "khr" => AddonListChargesResponseTierFlatPriceCurrency.Khr,
            "kmf" => AddonListChargesResponseTierFlatPriceCurrency.Kmf,
            "krw" => AddonListChargesResponseTierFlatPriceCurrency.Krw,
            "kyd" => AddonListChargesResponseTierFlatPriceCurrency.Kyd,
            "kzt" => AddonListChargesResponseTierFlatPriceCurrency.Kzt,
            "lbp" => AddonListChargesResponseTierFlatPriceCurrency.Lbp,
            "lkr" => AddonListChargesResponseTierFlatPriceCurrency.Lkr,
            "lrd" => AddonListChargesResponseTierFlatPriceCurrency.Lrd,
            "lsl" => AddonListChargesResponseTierFlatPriceCurrency.Lsl,
            "mad" => AddonListChargesResponseTierFlatPriceCurrency.Mad,
            "mdl" => AddonListChargesResponseTierFlatPriceCurrency.Mdl,
            "mga" => AddonListChargesResponseTierFlatPriceCurrency.Mga,
            "mkd" => AddonListChargesResponseTierFlatPriceCurrency.Mkd,
            "mmk" => AddonListChargesResponseTierFlatPriceCurrency.Mmk,
            "mnt" => AddonListChargesResponseTierFlatPriceCurrency.Mnt,
            "mop" => AddonListChargesResponseTierFlatPriceCurrency.Mop,
            "mro" => AddonListChargesResponseTierFlatPriceCurrency.Mro,
            "mvr" => AddonListChargesResponseTierFlatPriceCurrency.Mvr,
            "mwk" => AddonListChargesResponseTierFlatPriceCurrency.Mwk,
            "mxn" => AddonListChargesResponseTierFlatPriceCurrency.Mxn,
            "myr" => AddonListChargesResponseTierFlatPriceCurrency.Myr,
            "mzn" => AddonListChargesResponseTierFlatPriceCurrency.Mzn,
            "nad" => AddonListChargesResponseTierFlatPriceCurrency.Nad,
            "ngn" => AddonListChargesResponseTierFlatPriceCurrency.Ngn,
            "nok" => AddonListChargesResponseTierFlatPriceCurrency.Nok,
            "npr" => AddonListChargesResponseTierFlatPriceCurrency.Npr,
            "nzd" => AddonListChargesResponseTierFlatPriceCurrency.Nzd,
            "pgk" => AddonListChargesResponseTierFlatPriceCurrency.Pgk,
            "php" => AddonListChargesResponseTierFlatPriceCurrency.Php,
            "pkr" => AddonListChargesResponseTierFlatPriceCurrency.Pkr,
            "pln" => AddonListChargesResponseTierFlatPriceCurrency.Pln,
            "qar" => AddonListChargesResponseTierFlatPriceCurrency.Qar,
            "ron" => AddonListChargesResponseTierFlatPriceCurrency.Ron,
            "rsd" => AddonListChargesResponseTierFlatPriceCurrency.Rsd,
            "rub" => AddonListChargesResponseTierFlatPriceCurrency.Rub,
            "rwf" => AddonListChargesResponseTierFlatPriceCurrency.Rwf,
            "sar" => AddonListChargesResponseTierFlatPriceCurrency.Sar,
            "sbd" => AddonListChargesResponseTierFlatPriceCurrency.Sbd,
            "scr" => AddonListChargesResponseTierFlatPriceCurrency.Scr,
            "sek" => AddonListChargesResponseTierFlatPriceCurrency.Sek,
            "sgd" => AddonListChargesResponseTierFlatPriceCurrency.Sgd,
            "sle" => AddonListChargesResponseTierFlatPriceCurrency.Sle,
            "sll" => AddonListChargesResponseTierFlatPriceCurrency.Sll,
            "sos" => AddonListChargesResponseTierFlatPriceCurrency.Sos,
            "szl" => AddonListChargesResponseTierFlatPriceCurrency.Szl,
            "thb" => AddonListChargesResponseTierFlatPriceCurrency.Thb,
            "tjs" => AddonListChargesResponseTierFlatPriceCurrency.Tjs,
            "top" => AddonListChargesResponseTierFlatPriceCurrency.Top,
            "try" => AddonListChargesResponseTierFlatPriceCurrency.Try,
            "ttd" => AddonListChargesResponseTierFlatPriceCurrency.Ttd,
            "tzs" => AddonListChargesResponseTierFlatPriceCurrency.Tzs,
            "uah" => AddonListChargesResponseTierFlatPriceCurrency.Uah,
            "uzs" => AddonListChargesResponseTierFlatPriceCurrency.Uzs,
            "vnd" => AddonListChargesResponseTierFlatPriceCurrency.Vnd,
            "vuv" => AddonListChargesResponseTierFlatPriceCurrency.Vuv,
            "wst" => AddonListChargesResponseTierFlatPriceCurrency.Wst,
            "xaf" => AddonListChargesResponseTierFlatPriceCurrency.Xaf,
            "xcd" => AddonListChargesResponseTierFlatPriceCurrency.Xcd,
            "yer" => AddonListChargesResponseTierFlatPriceCurrency.Yer,
            "zar" => AddonListChargesResponseTierFlatPriceCurrency.Zar,
            "zmw" => AddonListChargesResponseTierFlatPriceCurrency.Zmw,
            "clp" => AddonListChargesResponseTierFlatPriceCurrency.Clp,
            "djf" => AddonListChargesResponseTierFlatPriceCurrency.Djf,
            "gnf" => AddonListChargesResponseTierFlatPriceCurrency.Gnf,
            "ugx" => AddonListChargesResponseTierFlatPriceCurrency.Ugx,
            "pyg" => AddonListChargesResponseTierFlatPriceCurrency.Pyg,
            "xof" => AddonListChargesResponseTierFlatPriceCurrency.Xof,
            "xpf" => AddonListChargesResponseTierFlatPriceCurrency.Xpf,
            _ => (AddonListChargesResponseTierFlatPriceCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AddonListChargesResponseTierFlatPriceCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AddonListChargesResponseTierFlatPriceCurrency.Usd => "usd",
                AddonListChargesResponseTierFlatPriceCurrency.Aed => "aed",
                AddonListChargesResponseTierFlatPriceCurrency.All => "all",
                AddonListChargesResponseTierFlatPriceCurrency.Amd => "amd",
                AddonListChargesResponseTierFlatPriceCurrency.Ang => "ang",
                AddonListChargesResponseTierFlatPriceCurrency.Aud => "aud",
                AddonListChargesResponseTierFlatPriceCurrency.Awg => "awg",
                AddonListChargesResponseTierFlatPriceCurrency.Azn => "azn",
                AddonListChargesResponseTierFlatPriceCurrency.Bam => "bam",
                AddonListChargesResponseTierFlatPriceCurrency.Bbd => "bbd",
                AddonListChargesResponseTierFlatPriceCurrency.Bdt => "bdt",
                AddonListChargesResponseTierFlatPriceCurrency.Bgn => "bgn",
                AddonListChargesResponseTierFlatPriceCurrency.Bif => "bif",
                AddonListChargesResponseTierFlatPriceCurrency.Bmd => "bmd",
                AddonListChargesResponseTierFlatPriceCurrency.Bnd => "bnd",
                AddonListChargesResponseTierFlatPriceCurrency.Bsd => "bsd",
                AddonListChargesResponseTierFlatPriceCurrency.Bwp => "bwp",
                AddonListChargesResponseTierFlatPriceCurrency.Byn => "byn",
                AddonListChargesResponseTierFlatPriceCurrency.Bzd => "bzd",
                AddonListChargesResponseTierFlatPriceCurrency.Brl => "brl",
                AddonListChargesResponseTierFlatPriceCurrency.Cad => "cad",
                AddonListChargesResponseTierFlatPriceCurrency.Cdf => "cdf",
                AddonListChargesResponseTierFlatPriceCurrency.Chf => "chf",
                AddonListChargesResponseTierFlatPriceCurrency.Cny => "cny",
                AddonListChargesResponseTierFlatPriceCurrency.Czk => "czk",
                AddonListChargesResponseTierFlatPriceCurrency.Dkk => "dkk",
                AddonListChargesResponseTierFlatPriceCurrency.Dop => "dop",
                AddonListChargesResponseTierFlatPriceCurrency.Dzd => "dzd",
                AddonListChargesResponseTierFlatPriceCurrency.Egp => "egp",
                AddonListChargesResponseTierFlatPriceCurrency.Etb => "etb",
                AddonListChargesResponseTierFlatPriceCurrency.Eur => "eur",
                AddonListChargesResponseTierFlatPriceCurrency.Fjd => "fjd",
                AddonListChargesResponseTierFlatPriceCurrency.Gbp => "gbp",
                AddonListChargesResponseTierFlatPriceCurrency.Gel => "gel",
                AddonListChargesResponseTierFlatPriceCurrency.Gip => "gip",
                AddonListChargesResponseTierFlatPriceCurrency.Gmd => "gmd",
                AddonListChargesResponseTierFlatPriceCurrency.Gyd => "gyd",
                AddonListChargesResponseTierFlatPriceCurrency.Hkd => "hkd",
                AddonListChargesResponseTierFlatPriceCurrency.Hrk => "hrk",
                AddonListChargesResponseTierFlatPriceCurrency.Htg => "htg",
                AddonListChargesResponseTierFlatPriceCurrency.Idr => "idr",
                AddonListChargesResponseTierFlatPriceCurrency.Ils => "ils",
                AddonListChargesResponseTierFlatPriceCurrency.Inr => "inr",
                AddonListChargesResponseTierFlatPriceCurrency.Isk => "isk",
                AddonListChargesResponseTierFlatPriceCurrency.Jmd => "jmd",
                AddonListChargesResponseTierFlatPriceCurrency.Jpy => "jpy",
                AddonListChargesResponseTierFlatPriceCurrency.Kes => "kes",
                AddonListChargesResponseTierFlatPriceCurrency.Kgs => "kgs",
                AddonListChargesResponseTierFlatPriceCurrency.Khr => "khr",
                AddonListChargesResponseTierFlatPriceCurrency.Kmf => "kmf",
                AddonListChargesResponseTierFlatPriceCurrency.Krw => "krw",
                AddonListChargesResponseTierFlatPriceCurrency.Kyd => "kyd",
                AddonListChargesResponseTierFlatPriceCurrency.Kzt => "kzt",
                AddonListChargesResponseTierFlatPriceCurrency.Lbp => "lbp",
                AddonListChargesResponseTierFlatPriceCurrency.Lkr => "lkr",
                AddonListChargesResponseTierFlatPriceCurrency.Lrd => "lrd",
                AddonListChargesResponseTierFlatPriceCurrency.Lsl => "lsl",
                AddonListChargesResponseTierFlatPriceCurrency.Mad => "mad",
                AddonListChargesResponseTierFlatPriceCurrency.Mdl => "mdl",
                AddonListChargesResponseTierFlatPriceCurrency.Mga => "mga",
                AddonListChargesResponseTierFlatPriceCurrency.Mkd => "mkd",
                AddonListChargesResponseTierFlatPriceCurrency.Mmk => "mmk",
                AddonListChargesResponseTierFlatPriceCurrency.Mnt => "mnt",
                AddonListChargesResponseTierFlatPriceCurrency.Mop => "mop",
                AddonListChargesResponseTierFlatPriceCurrency.Mro => "mro",
                AddonListChargesResponseTierFlatPriceCurrency.Mvr => "mvr",
                AddonListChargesResponseTierFlatPriceCurrency.Mwk => "mwk",
                AddonListChargesResponseTierFlatPriceCurrency.Mxn => "mxn",
                AddonListChargesResponseTierFlatPriceCurrency.Myr => "myr",
                AddonListChargesResponseTierFlatPriceCurrency.Mzn => "mzn",
                AddonListChargesResponseTierFlatPriceCurrency.Nad => "nad",
                AddonListChargesResponseTierFlatPriceCurrency.Ngn => "ngn",
                AddonListChargesResponseTierFlatPriceCurrency.Nok => "nok",
                AddonListChargesResponseTierFlatPriceCurrency.Npr => "npr",
                AddonListChargesResponseTierFlatPriceCurrency.Nzd => "nzd",
                AddonListChargesResponseTierFlatPriceCurrency.Pgk => "pgk",
                AddonListChargesResponseTierFlatPriceCurrency.Php => "php",
                AddonListChargesResponseTierFlatPriceCurrency.Pkr => "pkr",
                AddonListChargesResponseTierFlatPriceCurrency.Pln => "pln",
                AddonListChargesResponseTierFlatPriceCurrency.Qar => "qar",
                AddonListChargesResponseTierFlatPriceCurrency.Ron => "ron",
                AddonListChargesResponseTierFlatPriceCurrency.Rsd => "rsd",
                AddonListChargesResponseTierFlatPriceCurrency.Rub => "rub",
                AddonListChargesResponseTierFlatPriceCurrency.Rwf => "rwf",
                AddonListChargesResponseTierFlatPriceCurrency.Sar => "sar",
                AddonListChargesResponseTierFlatPriceCurrency.Sbd => "sbd",
                AddonListChargesResponseTierFlatPriceCurrency.Scr => "scr",
                AddonListChargesResponseTierFlatPriceCurrency.Sek => "sek",
                AddonListChargesResponseTierFlatPriceCurrency.Sgd => "sgd",
                AddonListChargesResponseTierFlatPriceCurrency.Sle => "sle",
                AddonListChargesResponseTierFlatPriceCurrency.Sll => "sll",
                AddonListChargesResponseTierFlatPriceCurrency.Sos => "sos",
                AddonListChargesResponseTierFlatPriceCurrency.Szl => "szl",
                AddonListChargesResponseTierFlatPriceCurrency.Thb => "thb",
                AddonListChargesResponseTierFlatPriceCurrency.Tjs => "tjs",
                AddonListChargesResponseTierFlatPriceCurrency.Top => "top",
                AddonListChargesResponseTierFlatPriceCurrency.Try => "try",
                AddonListChargesResponseTierFlatPriceCurrency.Ttd => "ttd",
                AddonListChargesResponseTierFlatPriceCurrency.Tzs => "tzs",
                AddonListChargesResponseTierFlatPriceCurrency.Uah => "uah",
                AddonListChargesResponseTierFlatPriceCurrency.Uzs => "uzs",
                AddonListChargesResponseTierFlatPriceCurrency.Vnd => "vnd",
                AddonListChargesResponseTierFlatPriceCurrency.Vuv => "vuv",
                AddonListChargesResponseTierFlatPriceCurrency.Wst => "wst",
                AddonListChargesResponseTierFlatPriceCurrency.Xaf => "xaf",
                AddonListChargesResponseTierFlatPriceCurrency.Xcd => "xcd",
                AddonListChargesResponseTierFlatPriceCurrency.Yer => "yer",
                AddonListChargesResponseTierFlatPriceCurrency.Zar => "zar",
                AddonListChargesResponseTierFlatPriceCurrency.Zmw => "zmw",
                AddonListChargesResponseTierFlatPriceCurrency.Clp => "clp",
                AddonListChargesResponseTierFlatPriceCurrency.Djf => "djf",
                AddonListChargesResponseTierFlatPriceCurrency.Gnf => "gnf",
                AddonListChargesResponseTierFlatPriceCurrency.Ugx => "ugx",
                AddonListChargesResponseTierFlatPriceCurrency.Pyg => "pyg",
                AddonListChargesResponseTierFlatPriceCurrency.Xof => "xof",
                AddonListChargesResponseTierFlatPriceCurrency.Xpf => "xpf",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Per-unit price in this tier
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        AddonListChargesResponseTierUnitPrice,
        AddonListChargesResponseTierUnitPriceFromRaw
    >)
)]
public sealed record class AddonListChargesResponseTierUnitPrice : JsonModel
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
    public required ApiEnum<string, AddonListChargesResponseTierUnitPriceCurrency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, AddonListChargesResponseTierUnitPriceCurrency>
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

    public AddonListChargesResponseTierUnitPrice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AddonListChargesResponseTierUnitPrice(
        AddonListChargesResponseTierUnitPrice addonListChargesResponseTierUnitPrice
    )
        : base(addonListChargesResponseTierUnitPrice) { }
#pragma warning restore CS8618

    public AddonListChargesResponseTierUnitPrice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddonListChargesResponseTierUnitPrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AddonListChargesResponseTierUnitPriceFromRaw.FromRawUnchecked"/>
    public static AddonListChargesResponseTierUnitPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AddonListChargesResponseTierUnitPriceFromRaw
    : IFromRawJson<AddonListChargesResponseTierUnitPrice>
{
    /// <inheritdoc/>
    public AddonListChargesResponseTierUnitPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AddonListChargesResponseTierUnitPrice.FromRawUnchecked(rawData);
}

/// <summary>
/// ISO 4217 currency code
/// </summary>
[JsonConverter(typeof(AddonListChargesResponseTierUnitPriceCurrencyConverter))]
public enum AddonListChargesResponseTierUnitPriceCurrency
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

sealed class AddonListChargesResponseTierUnitPriceCurrencyConverter
    : JsonConverter<AddonListChargesResponseTierUnitPriceCurrency>
{
    public override AddonListChargesResponseTierUnitPriceCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => AddonListChargesResponseTierUnitPriceCurrency.Usd,
            "aed" => AddonListChargesResponseTierUnitPriceCurrency.Aed,
            "all" => AddonListChargesResponseTierUnitPriceCurrency.All,
            "amd" => AddonListChargesResponseTierUnitPriceCurrency.Amd,
            "ang" => AddonListChargesResponseTierUnitPriceCurrency.Ang,
            "aud" => AddonListChargesResponseTierUnitPriceCurrency.Aud,
            "awg" => AddonListChargesResponseTierUnitPriceCurrency.Awg,
            "azn" => AddonListChargesResponseTierUnitPriceCurrency.Azn,
            "bam" => AddonListChargesResponseTierUnitPriceCurrency.Bam,
            "bbd" => AddonListChargesResponseTierUnitPriceCurrency.Bbd,
            "bdt" => AddonListChargesResponseTierUnitPriceCurrency.Bdt,
            "bgn" => AddonListChargesResponseTierUnitPriceCurrency.Bgn,
            "bif" => AddonListChargesResponseTierUnitPriceCurrency.Bif,
            "bmd" => AddonListChargesResponseTierUnitPriceCurrency.Bmd,
            "bnd" => AddonListChargesResponseTierUnitPriceCurrency.Bnd,
            "bsd" => AddonListChargesResponseTierUnitPriceCurrency.Bsd,
            "bwp" => AddonListChargesResponseTierUnitPriceCurrency.Bwp,
            "byn" => AddonListChargesResponseTierUnitPriceCurrency.Byn,
            "bzd" => AddonListChargesResponseTierUnitPriceCurrency.Bzd,
            "brl" => AddonListChargesResponseTierUnitPriceCurrency.Brl,
            "cad" => AddonListChargesResponseTierUnitPriceCurrency.Cad,
            "cdf" => AddonListChargesResponseTierUnitPriceCurrency.Cdf,
            "chf" => AddonListChargesResponseTierUnitPriceCurrency.Chf,
            "cny" => AddonListChargesResponseTierUnitPriceCurrency.Cny,
            "czk" => AddonListChargesResponseTierUnitPriceCurrency.Czk,
            "dkk" => AddonListChargesResponseTierUnitPriceCurrency.Dkk,
            "dop" => AddonListChargesResponseTierUnitPriceCurrency.Dop,
            "dzd" => AddonListChargesResponseTierUnitPriceCurrency.Dzd,
            "egp" => AddonListChargesResponseTierUnitPriceCurrency.Egp,
            "etb" => AddonListChargesResponseTierUnitPriceCurrency.Etb,
            "eur" => AddonListChargesResponseTierUnitPriceCurrency.Eur,
            "fjd" => AddonListChargesResponseTierUnitPriceCurrency.Fjd,
            "gbp" => AddonListChargesResponseTierUnitPriceCurrency.Gbp,
            "gel" => AddonListChargesResponseTierUnitPriceCurrency.Gel,
            "gip" => AddonListChargesResponseTierUnitPriceCurrency.Gip,
            "gmd" => AddonListChargesResponseTierUnitPriceCurrency.Gmd,
            "gyd" => AddonListChargesResponseTierUnitPriceCurrency.Gyd,
            "hkd" => AddonListChargesResponseTierUnitPriceCurrency.Hkd,
            "hrk" => AddonListChargesResponseTierUnitPriceCurrency.Hrk,
            "htg" => AddonListChargesResponseTierUnitPriceCurrency.Htg,
            "idr" => AddonListChargesResponseTierUnitPriceCurrency.Idr,
            "ils" => AddonListChargesResponseTierUnitPriceCurrency.Ils,
            "inr" => AddonListChargesResponseTierUnitPriceCurrency.Inr,
            "isk" => AddonListChargesResponseTierUnitPriceCurrency.Isk,
            "jmd" => AddonListChargesResponseTierUnitPriceCurrency.Jmd,
            "jpy" => AddonListChargesResponseTierUnitPriceCurrency.Jpy,
            "kes" => AddonListChargesResponseTierUnitPriceCurrency.Kes,
            "kgs" => AddonListChargesResponseTierUnitPriceCurrency.Kgs,
            "khr" => AddonListChargesResponseTierUnitPriceCurrency.Khr,
            "kmf" => AddonListChargesResponseTierUnitPriceCurrency.Kmf,
            "krw" => AddonListChargesResponseTierUnitPriceCurrency.Krw,
            "kyd" => AddonListChargesResponseTierUnitPriceCurrency.Kyd,
            "kzt" => AddonListChargesResponseTierUnitPriceCurrency.Kzt,
            "lbp" => AddonListChargesResponseTierUnitPriceCurrency.Lbp,
            "lkr" => AddonListChargesResponseTierUnitPriceCurrency.Lkr,
            "lrd" => AddonListChargesResponseTierUnitPriceCurrency.Lrd,
            "lsl" => AddonListChargesResponseTierUnitPriceCurrency.Lsl,
            "mad" => AddonListChargesResponseTierUnitPriceCurrency.Mad,
            "mdl" => AddonListChargesResponseTierUnitPriceCurrency.Mdl,
            "mga" => AddonListChargesResponseTierUnitPriceCurrency.Mga,
            "mkd" => AddonListChargesResponseTierUnitPriceCurrency.Mkd,
            "mmk" => AddonListChargesResponseTierUnitPriceCurrency.Mmk,
            "mnt" => AddonListChargesResponseTierUnitPriceCurrency.Mnt,
            "mop" => AddonListChargesResponseTierUnitPriceCurrency.Mop,
            "mro" => AddonListChargesResponseTierUnitPriceCurrency.Mro,
            "mvr" => AddonListChargesResponseTierUnitPriceCurrency.Mvr,
            "mwk" => AddonListChargesResponseTierUnitPriceCurrency.Mwk,
            "mxn" => AddonListChargesResponseTierUnitPriceCurrency.Mxn,
            "myr" => AddonListChargesResponseTierUnitPriceCurrency.Myr,
            "mzn" => AddonListChargesResponseTierUnitPriceCurrency.Mzn,
            "nad" => AddonListChargesResponseTierUnitPriceCurrency.Nad,
            "ngn" => AddonListChargesResponseTierUnitPriceCurrency.Ngn,
            "nok" => AddonListChargesResponseTierUnitPriceCurrency.Nok,
            "npr" => AddonListChargesResponseTierUnitPriceCurrency.Npr,
            "nzd" => AddonListChargesResponseTierUnitPriceCurrency.Nzd,
            "pgk" => AddonListChargesResponseTierUnitPriceCurrency.Pgk,
            "php" => AddonListChargesResponseTierUnitPriceCurrency.Php,
            "pkr" => AddonListChargesResponseTierUnitPriceCurrency.Pkr,
            "pln" => AddonListChargesResponseTierUnitPriceCurrency.Pln,
            "qar" => AddonListChargesResponseTierUnitPriceCurrency.Qar,
            "ron" => AddonListChargesResponseTierUnitPriceCurrency.Ron,
            "rsd" => AddonListChargesResponseTierUnitPriceCurrency.Rsd,
            "rub" => AddonListChargesResponseTierUnitPriceCurrency.Rub,
            "rwf" => AddonListChargesResponseTierUnitPriceCurrency.Rwf,
            "sar" => AddonListChargesResponseTierUnitPriceCurrency.Sar,
            "sbd" => AddonListChargesResponseTierUnitPriceCurrency.Sbd,
            "scr" => AddonListChargesResponseTierUnitPriceCurrency.Scr,
            "sek" => AddonListChargesResponseTierUnitPriceCurrency.Sek,
            "sgd" => AddonListChargesResponseTierUnitPriceCurrency.Sgd,
            "sle" => AddonListChargesResponseTierUnitPriceCurrency.Sle,
            "sll" => AddonListChargesResponseTierUnitPriceCurrency.Sll,
            "sos" => AddonListChargesResponseTierUnitPriceCurrency.Sos,
            "szl" => AddonListChargesResponseTierUnitPriceCurrency.Szl,
            "thb" => AddonListChargesResponseTierUnitPriceCurrency.Thb,
            "tjs" => AddonListChargesResponseTierUnitPriceCurrency.Tjs,
            "top" => AddonListChargesResponseTierUnitPriceCurrency.Top,
            "try" => AddonListChargesResponseTierUnitPriceCurrency.Try,
            "ttd" => AddonListChargesResponseTierUnitPriceCurrency.Ttd,
            "tzs" => AddonListChargesResponseTierUnitPriceCurrency.Tzs,
            "uah" => AddonListChargesResponseTierUnitPriceCurrency.Uah,
            "uzs" => AddonListChargesResponseTierUnitPriceCurrency.Uzs,
            "vnd" => AddonListChargesResponseTierUnitPriceCurrency.Vnd,
            "vuv" => AddonListChargesResponseTierUnitPriceCurrency.Vuv,
            "wst" => AddonListChargesResponseTierUnitPriceCurrency.Wst,
            "xaf" => AddonListChargesResponseTierUnitPriceCurrency.Xaf,
            "xcd" => AddonListChargesResponseTierUnitPriceCurrency.Xcd,
            "yer" => AddonListChargesResponseTierUnitPriceCurrency.Yer,
            "zar" => AddonListChargesResponseTierUnitPriceCurrency.Zar,
            "zmw" => AddonListChargesResponseTierUnitPriceCurrency.Zmw,
            "clp" => AddonListChargesResponseTierUnitPriceCurrency.Clp,
            "djf" => AddonListChargesResponseTierUnitPriceCurrency.Djf,
            "gnf" => AddonListChargesResponseTierUnitPriceCurrency.Gnf,
            "ugx" => AddonListChargesResponseTierUnitPriceCurrency.Ugx,
            "pyg" => AddonListChargesResponseTierUnitPriceCurrency.Pyg,
            "xof" => AddonListChargesResponseTierUnitPriceCurrency.Xof,
            "xpf" => AddonListChargesResponseTierUnitPriceCurrency.Xpf,
            _ => (AddonListChargesResponseTierUnitPriceCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AddonListChargesResponseTierUnitPriceCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AddonListChargesResponseTierUnitPriceCurrency.Usd => "usd",
                AddonListChargesResponseTierUnitPriceCurrency.Aed => "aed",
                AddonListChargesResponseTierUnitPriceCurrency.All => "all",
                AddonListChargesResponseTierUnitPriceCurrency.Amd => "amd",
                AddonListChargesResponseTierUnitPriceCurrency.Ang => "ang",
                AddonListChargesResponseTierUnitPriceCurrency.Aud => "aud",
                AddonListChargesResponseTierUnitPriceCurrency.Awg => "awg",
                AddonListChargesResponseTierUnitPriceCurrency.Azn => "azn",
                AddonListChargesResponseTierUnitPriceCurrency.Bam => "bam",
                AddonListChargesResponseTierUnitPriceCurrency.Bbd => "bbd",
                AddonListChargesResponseTierUnitPriceCurrency.Bdt => "bdt",
                AddonListChargesResponseTierUnitPriceCurrency.Bgn => "bgn",
                AddonListChargesResponseTierUnitPriceCurrency.Bif => "bif",
                AddonListChargesResponseTierUnitPriceCurrency.Bmd => "bmd",
                AddonListChargesResponseTierUnitPriceCurrency.Bnd => "bnd",
                AddonListChargesResponseTierUnitPriceCurrency.Bsd => "bsd",
                AddonListChargesResponseTierUnitPriceCurrency.Bwp => "bwp",
                AddonListChargesResponseTierUnitPriceCurrency.Byn => "byn",
                AddonListChargesResponseTierUnitPriceCurrency.Bzd => "bzd",
                AddonListChargesResponseTierUnitPriceCurrency.Brl => "brl",
                AddonListChargesResponseTierUnitPriceCurrency.Cad => "cad",
                AddonListChargesResponseTierUnitPriceCurrency.Cdf => "cdf",
                AddonListChargesResponseTierUnitPriceCurrency.Chf => "chf",
                AddonListChargesResponseTierUnitPriceCurrency.Cny => "cny",
                AddonListChargesResponseTierUnitPriceCurrency.Czk => "czk",
                AddonListChargesResponseTierUnitPriceCurrency.Dkk => "dkk",
                AddonListChargesResponseTierUnitPriceCurrency.Dop => "dop",
                AddonListChargesResponseTierUnitPriceCurrency.Dzd => "dzd",
                AddonListChargesResponseTierUnitPriceCurrency.Egp => "egp",
                AddonListChargesResponseTierUnitPriceCurrency.Etb => "etb",
                AddonListChargesResponseTierUnitPriceCurrency.Eur => "eur",
                AddonListChargesResponseTierUnitPriceCurrency.Fjd => "fjd",
                AddonListChargesResponseTierUnitPriceCurrency.Gbp => "gbp",
                AddonListChargesResponseTierUnitPriceCurrency.Gel => "gel",
                AddonListChargesResponseTierUnitPriceCurrency.Gip => "gip",
                AddonListChargesResponseTierUnitPriceCurrency.Gmd => "gmd",
                AddonListChargesResponseTierUnitPriceCurrency.Gyd => "gyd",
                AddonListChargesResponseTierUnitPriceCurrency.Hkd => "hkd",
                AddonListChargesResponseTierUnitPriceCurrency.Hrk => "hrk",
                AddonListChargesResponseTierUnitPriceCurrency.Htg => "htg",
                AddonListChargesResponseTierUnitPriceCurrency.Idr => "idr",
                AddonListChargesResponseTierUnitPriceCurrency.Ils => "ils",
                AddonListChargesResponseTierUnitPriceCurrency.Inr => "inr",
                AddonListChargesResponseTierUnitPriceCurrency.Isk => "isk",
                AddonListChargesResponseTierUnitPriceCurrency.Jmd => "jmd",
                AddonListChargesResponseTierUnitPriceCurrency.Jpy => "jpy",
                AddonListChargesResponseTierUnitPriceCurrency.Kes => "kes",
                AddonListChargesResponseTierUnitPriceCurrency.Kgs => "kgs",
                AddonListChargesResponseTierUnitPriceCurrency.Khr => "khr",
                AddonListChargesResponseTierUnitPriceCurrency.Kmf => "kmf",
                AddonListChargesResponseTierUnitPriceCurrency.Krw => "krw",
                AddonListChargesResponseTierUnitPriceCurrency.Kyd => "kyd",
                AddonListChargesResponseTierUnitPriceCurrency.Kzt => "kzt",
                AddonListChargesResponseTierUnitPriceCurrency.Lbp => "lbp",
                AddonListChargesResponseTierUnitPriceCurrency.Lkr => "lkr",
                AddonListChargesResponseTierUnitPriceCurrency.Lrd => "lrd",
                AddonListChargesResponseTierUnitPriceCurrency.Lsl => "lsl",
                AddonListChargesResponseTierUnitPriceCurrency.Mad => "mad",
                AddonListChargesResponseTierUnitPriceCurrency.Mdl => "mdl",
                AddonListChargesResponseTierUnitPriceCurrency.Mga => "mga",
                AddonListChargesResponseTierUnitPriceCurrency.Mkd => "mkd",
                AddonListChargesResponseTierUnitPriceCurrency.Mmk => "mmk",
                AddonListChargesResponseTierUnitPriceCurrency.Mnt => "mnt",
                AddonListChargesResponseTierUnitPriceCurrency.Mop => "mop",
                AddonListChargesResponseTierUnitPriceCurrency.Mro => "mro",
                AddonListChargesResponseTierUnitPriceCurrency.Mvr => "mvr",
                AddonListChargesResponseTierUnitPriceCurrency.Mwk => "mwk",
                AddonListChargesResponseTierUnitPriceCurrency.Mxn => "mxn",
                AddonListChargesResponseTierUnitPriceCurrency.Myr => "myr",
                AddonListChargesResponseTierUnitPriceCurrency.Mzn => "mzn",
                AddonListChargesResponseTierUnitPriceCurrency.Nad => "nad",
                AddonListChargesResponseTierUnitPriceCurrency.Ngn => "ngn",
                AddonListChargesResponseTierUnitPriceCurrency.Nok => "nok",
                AddonListChargesResponseTierUnitPriceCurrency.Npr => "npr",
                AddonListChargesResponseTierUnitPriceCurrency.Nzd => "nzd",
                AddonListChargesResponseTierUnitPriceCurrency.Pgk => "pgk",
                AddonListChargesResponseTierUnitPriceCurrency.Php => "php",
                AddonListChargesResponseTierUnitPriceCurrency.Pkr => "pkr",
                AddonListChargesResponseTierUnitPriceCurrency.Pln => "pln",
                AddonListChargesResponseTierUnitPriceCurrency.Qar => "qar",
                AddonListChargesResponseTierUnitPriceCurrency.Ron => "ron",
                AddonListChargesResponseTierUnitPriceCurrency.Rsd => "rsd",
                AddonListChargesResponseTierUnitPriceCurrency.Rub => "rub",
                AddonListChargesResponseTierUnitPriceCurrency.Rwf => "rwf",
                AddonListChargesResponseTierUnitPriceCurrency.Sar => "sar",
                AddonListChargesResponseTierUnitPriceCurrency.Sbd => "sbd",
                AddonListChargesResponseTierUnitPriceCurrency.Scr => "scr",
                AddonListChargesResponseTierUnitPriceCurrency.Sek => "sek",
                AddonListChargesResponseTierUnitPriceCurrency.Sgd => "sgd",
                AddonListChargesResponseTierUnitPriceCurrency.Sle => "sle",
                AddonListChargesResponseTierUnitPriceCurrency.Sll => "sll",
                AddonListChargesResponseTierUnitPriceCurrency.Sos => "sos",
                AddonListChargesResponseTierUnitPriceCurrency.Szl => "szl",
                AddonListChargesResponseTierUnitPriceCurrency.Thb => "thb",
                AddonListChargesResponseTierUnitPriceCurrency.Tjs => "tjs",
                AddonListChargesResponseTierUnitPriceCurrency.Top => "top",
                AddonListChargesResponseTierUnitPriceCurrency.Try => "try",
                AddonListChargesResponseTierUnitPriceCurrency.Ttd => "ttd",
                AddonListChargesResponseTierUnitPriceCurrency.Tzs => "tzs",
                AddonListChargesResponseTierUnitPriceCurrency.Uah => "uah",
                AddonListChargesResponseTierUnitPriceCurrency.Uzs => "uzs",
                AddonListChargesResponseTierUnitPriceCurrency.Vnd => "vnd",
                AddonListChargesResponseTierUnitPriceCurrency.Vuv => "vuv",
                AddonListChargesResponseTierUnitPriceCurrency.Wst => "wst",
                AddonListChargesResponseTierUnitPriceCurrency.Xaf => "xaf",
                AddonListChargesResponseTierUnitPriceCurrency.Xcd => "xcd",
                AddonListChargesResponseTierUnitPriceCurrency.Yer => "yer",
                AddonListChargesResponseTierUnitPriceCurrency.Zar => "zar",
                AddonListChargesResponseTierUnitPriceCurrency.Zmw => "zmw",
                AddonListChargesResponseTierUnitPriceCurrency.Clp => "clp",
                AddonListChargesResponseTierUnitPriceCurrency.Djf => "djf",
                AddonListChargesResponseTierUnitPriceCurrency.Gnf => "gnf",
                AddonListChargesResponseTierUnitPriceCurrency.Ugx => "ugx",
                AddonListChargesResponseTierUnitPriceCurrency.Pyg => "pyg",
                AddonListChargesResponseTierUnitPriceCurrency.Xof => "xof",
                AddonListChargesResponseTierUnitPriceCurrency.Xpf => "xpf",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Tiered pricing mode (VOLUME or GRADUATED) when the charge is tiered
/// </summary>
[JsonConverter(typeof(AddonListChargesResponseTiersModeConverter))]
public enum AddonListChargesResponseTiersMode
{
    Volume,
    Graduated,
}

sealed class AddonListChargesResponseTiersModeConverter
    : JsonConverter<AddonListChargesResponseTiersMode>
{
    public override AddonListChargesResponseTiersMode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "VOLUME" => AddonListChargesResponseTiersMode.Volume,
            "GRADUATED" => AddonListChargesResponseTiersMode.Graduated,
            _ => (AddonListChargesResponseTiersMode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AddonListChargesResponseTiersMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AddonListChargesResponseTiersMode.Volume => "VOLUME",
                AddonListChargesResponseTiersMode.Graduated => "GRADUATED",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
