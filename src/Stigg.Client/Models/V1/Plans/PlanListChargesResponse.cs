using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using System = System;

namespace Stigg.Client.Models.V1.Plans;

/// <summary>
/// A single pricing row on a plan or addon. Each charge encodes one (billingPeriod,
/// billingModel, billingCadence, billingCountryCode) combination. Plans and addons
/// own many of these — one per currency / billing period / feature.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PlanListChargesResponse, PlanListChargesResponseFromRaw>))]
public sealed record class PlanListChargesResponse : JsonModel
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
    public required ApiEnum<string, PlanListChargesResponseBillingCadence> BillingCadence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, PlanListChargesResponseBillingCadence>
            >("billingCadence");
        }
        init { this._rawData.Set("billingCadence", value); }
    }

    /// <summary>
    /// The billing model (FLAT_FEE, PER_UNIT, USAGE_BASED, CREDIT_BASED, MINIMUM_SPEND)
    /// </summary>
    public required ApiEnum<string, PlanListChargesResponseBillingModel> BillingModel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, PlanListChargesResponseBillingModel>
            >("billingModel");
        }
        init { this._rawData.Set("billingModel", value); }
    }

    /// <summary>
    /// The billing period (MONTHLY or ANNUALLY)
    /// </summary>
    public required ApiEnum<string, PlanListChargesResponseBillingPeriod> BillingPeriod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, PlanListChargesResponseBillingPeriod>
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
    /// ISO country code for localized pricing, if any
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
    public ApiEnum<string, PlanListChargesResponseCreditGrantCadence>? CreditGrantCadence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, PlanListChargesResponseCreditGrantCadence>
            >("creditGrantCadence");
        }
        init { this._rawData.Set("creditGrantCadence", value); }
    }

    /// <summary>
    /// Credit rate configuration for credit-based pricing
    /// </summary>
    public PlanListChargesResponseCreditRate? CreditRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PlanListChargesResponseCreditRate>("creditRate");
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
    public PlanListChargesResponsePrice? Price
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PlanListChargesResponsePrice>("price");
        }
        init { this._rawData.Set("price", value); }
    }

    /// <summary>
    /// Tiered pricing rows when the charge is tiered
    /// </summary>
    public IReadOnlyList<PlanListChargesResponseTier>? Tiers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<PlanListChargesResponseTier>>(
                "tiers"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<PlanListChargesResponseTier>?>(
                "tiers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Tiered pricing mode (VOLUME or GRADUATED) when the charge is tiered
    /// </summary>
    public ApiEnum<string, PlanListChargesResponseTiersMode>? TiersMode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, PlanListChargesResponseTiersMode>
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

    public PlanListChargesResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlanListChargesResponse(PlanListChargesResponse planListChargesResponse)
        : base(planListChargesResponse) { }
#pragma warning restore CS8618

    public PlanListChargesResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlanListChargesResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlanListChargesResponseFromRaw.FromRawUnchecked"/>
    public static PlanListChargesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlanListChargesResponseFromRaw : IFromRawJson<PlanListChargesResponse>
{
    /// <inheritdoc/>
    public PlanListChargesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlanListChargesResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// The billing cadence (RECURRING or ONE_OFF)
/// </summary>
[JsonConverter(typeof(PlanListChargesResponseBillingCadenceConverter))]
public enum PlanListChargesResponseBillingCadence
{
    Recurring,
    OneOff,
}

sealed class PlanListChargesResponseBillingCadenceConverter
    : JsonConverter<PlanListChargesResponseBillingCadence>
{
    public override PlanListChargesResponseBillingCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "RECURRING" => PlanListChargesResponseBillingCadence.Recurring,
            "ONE_OFF" => PlanListChargesResponseBillingCadence.OneOff,
            _ => (PlanListChargesResponseBillingCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PlanListChargesResponseBillingCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PlanListChargesResponseBillingCadence.Recurring => "RECURRING",
                PlanListChargesResponseBillingCadence.OneOff => "ONE_OFF",
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
[JsonConverter(typeof(PlanListChargesResponseBillingModelConverter))]
public enum PlanListChargesResponseBillingModel
{
    FlatFee,
    MinimumSpend,
    PerUnit,
    UsageBased,
    CreditBased,
}

sealed class PlanListChargesResponseBillingModelConverter
    : JsonConverter<PlanListChargesResponseBillingModel>
{
    public override PlanListChargesResponseBillingModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FLAT_FEE" => PlanListChargesResponseBillingModel.FlatFee,
            "MINIMUM_SPEND" => PlanListChargesResponseBillingModel.MinimumSpend,
            "PER_UNIT" => PlanListChargesResponseBillingModel.PerUnit,
            "USAGE_BASED" => PlanListChargesResponseBillingModel.UsageBased,
            "CREDIT_BASED" => PlanListChargesResponseBillingModel.CreditBased,
            _ => (PlanListChargesResponseBillingModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PlanListChargesResponseBillingModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PlanListChargesResponseBillingModel.FlatFee => "FLAT_FEE",
                PlanListChargesResponseBillingModel.MinimumSpend => "MINIMUM_SPEND",
                PlanListChargesResponseBillingModel.PerUnit => "PER_UNIT",
                PlanListChargesResponseBillingModel.UsageBased => "USAGE_BASED",
                PlanListChargesResponseBillingModel.CreditBased => "CREDIT_BASED",
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
[JsonConverter(typeof(PlanListChargesResponseBillingPeriodConverter))]
public enum PlanListChargesResponseBillingPeriod
{
    Monthly,
    Annually,
}

sealed class PlanListChargesResponseBillingPeriodConverter
    : JsonConverter<PlanListChargesResponseBillingPeriod>
{
    public override PlanListChargesResponseBillingPeriod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "MONTHLY" => PlanListChargesResponseBillingPeriod.Monthly,
            "ANNUALLY" => PlanListChargesResponseBillingPeriod.Annually,
            _ => (PlanListChargesResponseBillingPeriod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PlanListChargesResponseBillingPeriod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PlanListChargesResponseBillingPeriod.Monthly => "MONTHLY",
                PlanListChargesResponseBillingPeriod.Annually => "ANNUALLY",
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
[JsonConverter(typeof(PlanListChargesResponseCreditGrantCadenceConverter))]
public enum PlanListChargesResponseCreditGrantCadence
{
    BeginningOfBillingPeriod,
    Monthly,
}

sealed class PlanListChargesResponseCreditGrantCadenceConverter
    : JsonConverter<PlanListChargesResponseCreditGrantCadence>
{
    public override PlanListChargesResponseCreditGrantCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "BEGINNING_OF_BILLING_PERIOD" =>
                PlanListChargesResponseCreditGrantCadence.BeginningOfBillingPeriod,
            "MONTHLY" => PlanListChargesResponseCreditGrantCadence.Monthly,
            _ => (PlanListChargesResponseCreditGrantCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PlanListChargesResponseCreditGrantCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PlanListChargesResponseCreditGrantCadence.BeginningOfBillingPeriod =>
                    "BEGINNING_OF_BILLING_PERIOD",
                PlanListChargesResponseCreditGrantCadence.Monthly => "MONTHLY",
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
        PlanListChargesResponseCreditRate,
        PlanListChargesResponseCreditRateFromRaw
    >)
)]
public sealed record class PlanListChargesResponseCreditRate : JsonModel
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

    public PlanListChargesResponseCreditRate() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlanListChargesResponseCreditRate(
        PlanListChargesResponseCreditRate planListChargesResponseCreditRate
    )
        : base(planListChargesResponseCreditRate) { }
#pragma warning restore CS8618

    public PlanListChargesResponseCreditRate(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlanListChargesResponseCreditRate(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlanListChargesResponseCreditRateFromRaw.FromRawUnchecked"/>
    public static PlanListChargesResponseCreditRate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlanListChargesResponseCreditRateFromRaw : IFromRawJson<PlanListChargesResponseCreditRate>
{
    /// <inheritdoc/>
    public PlanListChargesResponseCreditRate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlanListChargesResponseCreditRate.FromRawUnchecked(rawData);
}

/// <summary>
/// The flat price amount and currency, when applicable
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<PlanListChargesResponsePrice, PlanListChargesResponsePriceFromRaw>)
)]
public sealed record class PlanListChargesResponsePrice : JsonModel
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
    public required ApiEnum<string, PlanListChargesResponsePriceCurrency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, PlanListChargesResponsePriceCurrency>
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

    public PlanListChargesResponsePrice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlanListChargesResponsePrice(PlanListChargesResponsePrice planListChargesResponsePrice)
        : base(planListChargesResponsePrice) { }
#pragma warning restore CS8618

    public PlanListChargesResponsePrice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlanListChargesResponsePrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlanListChargesResponsePriceFromRaw.FromRawUnchecked"/>
    public static PlanListChargesResponsePrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlanListChargesResponsePriceFromRaw : IFromRawJson<PlanListChargesResponsePrice>
{
    /// <inheritdoc/>
    public PlanListChargesResponsePrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlanListChargesResponsePrice.FromRawUnchecked(rawData);
}

/// <summary>
/// ISO 4217 currency code
/// </summary>
[JsonConverter(typeof(PlanListChargesResponsePriceCurrencyConverter))]
public enum PlanListChargesResponsePriceCurrency
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

sealed class PlanListChargesResponsePriceCurrencyConverter
    : JsonConverter<PlanListChargesResponsePriceCurrency>
{
    public override PlanListChargesResponsePriceCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => PlanListChargesResponsePriceCurrency.Usd,
            "aed" => PlanListChargesResponsePriceCurrency.Aed,
            "all" => PlanListChargesResponsePriceCurrency.All,
            "amd" => PlanListChargesResponsePriceCurrency.Amd,
            "ang" => PlanListChargesResponsePriceCurrency.Ang,
            "aud" => PlanListChargesResponsePriceCurrency.Aud,
            "awg" => PlanListChargesResponsePriceCurrency.Awg,
            "azn" => PlanListChargesResponsePriceCurrency.Azn,
            "bam" => PlanListChargesResponsePriceCurrency.Bam,
            "bbd" => PlanListChargesResponsePriceCurrency.Bbd,
            "bdt" => PlanListChargesResponsePriceCurrency.Bdt,
            "bgn" => PlanListChargesResponsePriceCurrency.Bgn,
            "bif" => PlanListChargesResponsePriceCurrency.Bif,
            "bmd" => PlanListChargesResponsePriceCurrency.Bmd,
            "bnd" => PlanListChargesResponsePriceCurrency.Bnd,
            "bsd" => PlanListChargesResponsePriceCurrency.Bsd,
            "bwp" => PlanListChargesResponsePriceCurrency.Bwp,
            "byn" => PlanListChargesResponsePriceCurrency.Byn,
            "bzd" => PlanListChargesResponsePriceCurrency.Bzd,
            "brl" => PlanListChargesResponsePriceCurrency.Brl,
            "cad" => PlanListChargesResponsePriceCurrency.Cad,
            "cdf" => PlanListChargesResponsePriceCurrency.Cdf,
            "chf" => PlanListChargesResponsePriceCurrency.Chf,
            "cny" => PlanListChargesResponsePriceCurrency.Cny,
            "czk" => PlanListChargesResponsePriceCurrency.Czk,
            "dkk" => PlanListChargesResponsePriceCurrency.Dkk,
            "dop" => PlanListChargesResponsePriceCurrency.Dop,
            "dzd" => PlanListChargesResponsePriceCurrency.Dzd,
            "egp" => PlanListChargesResponsePriceCurrency.Egp,
            "etb" => PlanListChargesResponsePriceCurrency.Etb,
            "eur" => PlanListChargesResponsePriceCurrency.Eur,
            "fjd" => PlanListChargesResponsePriceCurrency.Fjd,
            "gbp" => PlanListChargesResponsePriceCurrency.Gbp,
            "gel" => PlanListChargesResponsePriceCurrency.Gel,
            "gip" => PlanListChargesResponsePriceCurrency.Gip,
            "gmd" => PlanListChargesResponsePriceCurrency.Gmd,
            "gyd" => PlanListChargesResponsePriceCurrency.Gyd,
            "hkd" => PlanListChargesResponsePriceCurrency.Hkd,
            "hrk" => PlanListChargesResponsePriceCurrency.Hrk,
            "htg" => PlanListChargesResponsePriceCurrency.Htg,
            "idr" => PlanListChargesResponsePriceCurrency.Idr,
            "ils" => PlanListChargesResponsePriceCurrency.Ils,
            "inr" => PlanListChargesResponsePriceCurrency.Inr,
            "isk" => PlanListChargesResponsePriceCurrency.Isk,
            "jmd" => PlanListChargesResponsePriceCurrency.Jmd,
            "jpy" => PlanListChargesResponsePriceCurrency.Jpy,
            "kes" => PlanListChargesResponsePriceCurrency.Kes,
            "kgs" => PlanListChargesResponsePriceCurrency.Kgs,
            "khr" => PlanListChargesResponsePriceCurrency.Khr,
            "kmf" => PlanListChargesResponsePriceCurrency.Kmf,
            "krw" => PlanListChargesResponsePriceCurrency.Krw,
            "kyd" => PlanListChargesResponsePriceCurrency.Kyd,
            "kzt" => PlanListChargesResponsePriceCurrency.Kzt,
            "lbp" => PlanListChargesResponsePriceCurrency.Lbp,
            "lkr" => PlanListChargesResponsePriceCurrency.Lkr,
            "lrd" => PlanListChargesResponsePriceCurrency.Lrd,
            "lsl" => PlanListChargesResponsePriceCurrency.Lsl,
            "mad" => PlanListChargesResponsePriceCurrency.Mad,
            "mdl" => PlanListChargesResponsePriceCurrency.Mdl,
            "mga" => PlanListChargesResponsePriceCurrency.Mga,
            "mkd" => PlanListChargesResponsePriceCurrency.Mkd,
            "mmk" => PlanListChargesResponsePriceCurrency.Mmk,
            "mnt" => PlanListChargesResponsePriceCurrency.Mnt,
            "mop" => PlanListChargesResponsePriceCurrency.Mop,
            "mro" => PlanListChargesResponsePriceCurrency.Mro,
            "mvr" => PlanListChargesResponsePriceCurrency.Mvr,
            "mwk" => PlanListChargesResponsePriceCurrency.Mwk,
            "mxn" => PlanListChargesResponsePriceCurrency.Mxn,
            "myr" => PlanListChargesResponsePriceCurrency.Myr,
            "mzn" => PlanListChargesResponsePriceCurrency.Mzn,
            "nad" => PlanListChargesResponsePriceCurrency.Nad,
            "ngn" => PlanListChargesResponsePriceCurrency.Ngn,
            "nok" => PlanListChargesResponsePriceCurrency.Nok,
            "npr" => PlanListChargesResponsePriceCurrency.Npr,
            "nzd" => PlanListChargesResponsePriceCurrency.Nzd,
            "pgk" => PlanListChargesResponsePriceCurrency.Pgk,
            "php" => PlanListChargesResponsePriceCurrency.Php,
            "pkr" => PlanListChargesResponsePriceCurrency.Pkr,
            "pln" => PlanListChargesResponsePriceCurrency.Pln,
            "qar" => PlanListChargesResponsePriceCurrency.Qar,
            "ron" => PlanListChargesResponsePriceCurrency.Ron,
            "rsd" => PlanListChargesResponsePriceCurrency.Rsd,
            "rub" => PlanListChargesResponsePriceCurrency.Rub,
            "rwf" => PlanListChargesResponsePriceCurrency.Rwf,
            "sar" => PlanListChargesResponsePriceCurrency.Sar,
            "sbd" => PlanListChargesResponsePriceCurrency.Sbd,
            "scr" => PlanListChargesResponsePriceCurrency.Scr,
            "sek" => PlanListChargesResponsePriceCurrency.Sek,
            "sgd" => PlanListChargesResponsePriceCurrency.Sgd,
            "sle" => PlanListChargesResponsePriceCurrency.Sle,
            "sll" => PlanListChargesResponsePriceCurrency.Sll,
            "sos" => PlanListChargesResponsePriceCurrency.Sos,
            "szl" => PlanListChargesResponsePriceCurrency.Szl,
            "thb" => PlanListChargesResponsePriceCurrency.Thb,
            "tjs" => PlanListChargesResponsePriceCurrency.Tjs,
            "top" => PlanListChargesResponsePriceCurrency.Top,
            "try" => PlanListChargesResponsePriceCurrency.Try,
            "ttd" => PlanListChargesResponsePriceCurrency.Ttd,
            "tzs" => PlanListChargesResponsePriceCurrency.Tzs,
            "uah" => PlanListChargesResponsePriceCurrency.Uah,
            "uzs" => PlanListChargesResponsePriceCurrency.Uzs,
            "vnd" => PlanListChargesResponsePriceCurrency.Vnd,
            "vuv" => PlanListChargesResponsePriceCurrency.Vuv,
            "wst" => PlanListChargesResponsePriceCurrency.Wst,
            "xaf" => PlanListChargesResponsePriceCurrency.Xaf,
            "xcd" => PlanListChargesResponsePriceCurrency.Xcd,
            "yer" => PlanListChargesResponsePriceCurrency.Yer,
            "zar" => PlanListChargesResponsePriceCurrency.Zar,
            "zmw" => PlanListChargesResponsePriceCurrency.Zmw,
            "clp" => PlanListChargesResponsePriceCurrency.Clp,
            "djf" => PlanListChargesResponsePriceCurrency.Djf,
            "gnf" => PlanListChargesResponsePriceCurrency.Gnf,
            "ugx" => PlanListChargesResponsePriceCurrency.Ugx,
            "pyg" => PlanListChargesResponsePriceCurrency.Pyg,
            "xof" => PlanListChargesResponsePriceCurrency.Xof,
            "xpf" => PlanListChargesResponsePriceCurrency.Xpf,
            _ => (PlanListChargesResponsePriceCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PlanListChargesResponsePriceCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PlanListChargesResponsePriceCurrency.Usd => "usd",
                PlanListChargesResponsePriceCurrency.Aed => "aed",
                PlanListChargesResponsePriceCurrency.All => "all",
                PlanListChargesResponsePriceCurrency.Amd => "amd",
                PlanListChargesResponsePriceCurrency.Ang => "ang",
                PlanListChargesResponsePriceCurrency.Aud => "aud",
                PlanListChargesResponsePriceCurrency.Awg => "awg",
                PlanListChargesResponsePriceCurrency.Azn => "azn",
                PlanListChargesResponsePriceCurrency.Bam => "bam",
                PlanListChargesResponsePriceCurrency.Bbd => "bbd",
                PlanListChargesResponsePriceCurrency.Bdt => "bdt",
                PlanListChargesResponsePriceCurrency.Bgn => "bgn",
                PlanListChargesResponsePriceCurrency.Bif => "bif",
                PlanListChargesResponsePriceCurrency.Bmd => "bmd",
                PlanListChargesResponsePriceCurrency.Bnd => "bnd",
                PlanListChargesResponsePriceCurrency.Bsd => "bsd",
                PlanListChargesResponsePriceCurrency.Bwp => "bwp",
                PlanListChargesResponsePriceCurrency.Byn => "byn",
                PlanListChargesResponsePriceCurrency.Bzd => "bzd",
                PlanListChargesResponsePriceCurrency.Brl => "brl",
                PlanListChargesResponsePriceCurrency.Cad => "cad",
                PlanListChargesResponsePriceCurrency.Cdf => "cdf",
                PlanListChargesResponsePriceCurrency.Chf => "chf",
                PlanListChargesResponsePriceCurrency.Cny => "cny",
                PlanListChargesResponsePriceCurrency.Czk => "czk",
                PlanListChargesResponsePriceCurrency.Dkk => "dkk",
                PlanListChargesResponsePriceCurrency.Dop => "dop",
                PlanListChargesResponsePriceCurrency.Dzd => "dzd",
                PlanListChargesResponsePriceCurrency.Egp => "egp",
                PlanListChargesResponsePriceCurrency.Etb => "etb",
                PlanListChargesResponsePriceCurrency.Eur => "eur",
                PlanListChargesResponsePriceCurrency.Fjd => "fjd",
                PlanListChargesResponsePriceCurrency.Gbp => "gbp",
                PlanListChargesResponsePriceCurrency.Gel => "gel",
                PlanListChargesResponsePriceCurrency.Gip => "gip",
                PlanListChargesResponsePriceCurrency.Gmd => "gmd",
                PlanListChargesResponsePriceCurrency.Gyd => "gyd",
                PlanListChargesResponsePriceCurrency.Hkd => "hkd",
                PlanListChargesResponsePriceCurrency.Hrk => "hrk",
                PlanListChargesResponsePriceCurrency.Htg => "htg",
                PlanListChargesResponsePriceCurrency.Idr => "idr",
                PlanListChargesResponsePriceCurrency.Ils => "ils",
                PlanListChargesResponsePriceCurrency.Inr => "inr",
                PlanListChargesResponsePriceCurrency.Isk => "isk",
                PlanListChargesResponsePriceCurrency.Jmd => "jmd",
                PlanListChargesResponsePriceCurrency.Jpy => "jpy",
                PlanListChargesResponsePriceCurrency.Kes => "kes",
                PlanListChargesResponsePriceCurrency.Kgs => "kgs",
                PlanListChargesResponsePriceCurrency.Khr => "khr",
                PlanListChargesResponsePriceCurrency.Kmf => "kmf",
                PlanListChargesResponsePriceCurrency.Krw => "krw",
                PlanListChargesResponsePriceCurrency.Kyd => "kyd",
                PlanListChargesResponsePriceCurrency.Kzt => "kzt",
                PlanListChargesResponsePriceCurrency.Lbp => "lbp",
                PlanListChargesResponsePriceCurrency.Lkr => "lkr",
                PlanListChargesResponsePriceCurrency.Lrd => "lrd",
                PlanListChargesResponsePriceCurrency.Lsl => "lsl",
                PlanListChargesResponsePriceCurrency.Mad => "mad",
                PlanListChargesResponsePriceCurrency.Mdl => "mdl",
                PlanListChargesResponsePriceCurrency.Mga => "mga",
                PlanListChargesResponsePriceCurrency.Mkd => "mkd",
                PlanListChargesResponsePriceCurrency.Mmk => "mmk",
                PlanListChargesResponsePriceCurrency.Mnt => "mnt",
                PlanListChargesResponsePriceCurrency.Mop => "mop",
                PlanListChargesResponsePriceCurrency.Mro => "mro",
                PlanListChargesResponsePriceCurrency.Mvr => "mvr",
                PlanListChargesResponsePriceCurrency.Mwk => "mwk",
                PlanListChargesResponsePriceCurrency.Mxn => "mxn",
                PlanListChargesResponsePriceCurrency.Myr => "myr",
                PlanListChargesResponsePriceCurrency.Mzn => "mzn",
                PlanListChargesResponsePriceCurrency.Nad => "nad",
                PlanListChargesResponsePriceCurrency.Ngn => "ngn",
                PlanListChargesResponsePriceCurrency.Nok => "nok",
                PlanListChargesResponsePriceCurrency.Npr => "npr",
                PlanListChargesResponsePriceCurrency.Nzd => "nzd",
                PlanListChargesResponsePriceCurrency.Pgk => "pgk",
                PlanListChargesResponsePriceCurrency.Php => "php",
                PlanListChargesResponsePriceCurrency.Pkr => "pkr",
                PlanListChargesResponsePriceCurrency.Pln => "pln",
                PlanListChargesResponsePriceCurrency.Qar => "qar",
                PlanListChargesResponsePriceCurrency.Ron => "ron",
                PlanListChargesResponsePriceCurrency.Rsd => "rsd",
                PlanListChargesResponsePriceCurrency.Rub => "rub",
                PlanListChargesResponsePriceCurrency.Rwf => "rwf",
                PlanListChargesResponsePriceCurrency.Sar => "sar",
                PlanListChargesResponsePriceCurrency.Sbd => "sbd",
                PlanListChargesResponsePriceCurrency.Scr => "scr",
                PlanListChargesResponsePriceCurrency.Sek => "sek",
                PlanListChargesResponsePriceCurrency.Sgd => "sgd",
                PlanListChargesResponsePriceCurrency.Sle => "sle",
                PlanListChargesResponsePriceCurrency.Sll => "sll",
                PlanListChargesResponsePriceCurrency.Sos => "sos",
                PlanListChargesResponsePriceCurrency.Szl => "szl",
                PlanListChargesResponsePriceCurrency.Thb => "thb",
                PlanListChargesResponsePriceCurrency.Tjs => "tjs",
                PlanListChargesResponsePriceCurrency.Top => "top",
                PlanListChargesResponsePriceCurrency.Try => "try",
                PlanListChargesResponsePriceCurrency.Ttd => "ttd",
                PlanListChargesResponsePriceCurrency.Tzs => "tzs",
                PlanListChargesResponsePriceCurrency.Uah => "uah",
                PlanListChargesResponsePriceCurrency.Uzs => "uzs",
                PlanListChargesResponsePriceCurrency.Vnd => "vnd",
                PlanListChargesResponsePriceCurrency.Vuv => "vuv",
                PlanListChargesResponsePriceCurrency.Wst => "wst",
                PlanListChargesResponsePriceCurrency.Xaf => "xaf",
                PlanListChargesResponsePriceCurrency.Xcd => "xcd",
                PlanListChargesResponsePriceCurrency.Yer => "yer",
                PlanListChargesResponsePriceCurrency.Zar => "zar",
                PlanListChargesResponsePriceCurrency.Zmw => "zmw",
                PlanListChargesResponsePriceCurrency.Clp => "clp",
                PlanListChargesResponsePriceCurrency.Djf => "djf",
                PlanListChargesResponsePriceCurrency.Gnf => "gnf",
                PlanListChargesResponsePriceCurrency.Ugx => "ugx",
                PlanListChargesResponsePriceCurrency.Pyg => "pyg",
                PlanListChargesResponsePriceCurrency.Xof => "xof",
                PlanListChargesResponsePriceCurrency.Xpf => "xpf",
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
    typeof(JsonModelConverter<PlanListChargesResponseTier, PlanListChargesResponseTierFromRaw>)
)]
public sealed record class PlanListChargesResponseTier : JsonModel
{
    /// <summary>
    /// Flat price for this tier
    /// </summary>
    public PlanListChargesResponseTierFlatPrice? FlatPrice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PlanListChargesResponseTierFlatPrice>(
                "flatPrice"
            );
        }
        init { this._rawData.Set("flatPrice", value); }
    }

    /// <summary>
    /// Per-unit price in this tier
    /// </summary>
    public PlanListChargesResponseTierUnitPrice? UnitPrice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PlanListChargesResponseTierUnitPrice>(
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

    public PlanListChargesResponseTier() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlanListChargesResponseTier(PlanListChargesResponseTier planListChargesResponseTier)
        : base(planListChargesResponseTier) { }
#pragma warning restore CS8618

    public PlanListChargesResponseTier(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlanListChargesResponseTier(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlanListChargesResponseTierFromRaw.FromRawUnchecked"/>
    public static PlanListChargesResponseTier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlanListChargesResponseTierFromRaw : IFromRawJson<PlanListChargesResponseTier>
{
    /// <inheritdoc/>
    public PlanListChargesResponseTier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlanListChargesResponseTier.FromRawUnchecked(rawData);
}

/// <summary>
/// Flat price for this tier
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        PlanListChargesResponseTierFlatPrice,
        PlanListChargesResponseTierFlatPriceFromRaw
    >)
)]
public sealed record class PlanListChargesResponseTierFlatPrice : JsonModel
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
    public required ApiEnum<string, PlanListChargesResponseTierFlatPriceCurrency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, PlanListChargesResponseTierFlatPriceCurrency>
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

    public PlanListChargesResponseTierFlatPrice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlanListChargesResponseTierFlatPrice(
        PlanListChargesResponseTierFlatPrice planListChargesResponseTierFlatPrice
    )
        : base(planListChargesResponseTierFlatPrice) { }
#pragma warning restore CS8618

    public PlanListChargesResponseTierFlatPrice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlanListChargesResponseTierFlatPrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlanListChargesResponseTierFlatPriceFromRaw.FromRawUnchecked"/>
    public static PlanListChargesResponseTierFlatPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlanListChargesResponseTierFlatPriceFromRaw
    : IFromRawJson<PlanListChargesResponseTierFlatPrice>
{
    /// <inheritdoc/>
    public PlanListChargesResponseTierFlatPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlanListChargesResponseTierFlatPrice.FromRawUnchecked(rawData);
}

/// <summary>
/// ISO 4217 currency code
/// </summary>
[JsonConverter(typeof(PlanListChargesResponseTierFlatPriceCurrencyConverter))]
public enum PlanListChargesResponseTierFlatPriceCurrency
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

sealed class PlanListChargesResponseTierFlatPriceCurrencyConverter
    : JsonConverter<PlanListChargesResponseTierFlatPriceCurrency>
{
    public override PlanListChargesResponseTierFlatPriceCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => PlanListChargesResponseTierFlatPriceCurrency.Usd,
            "aed" => PlanListChargesResponseTierFlatPriceCurrency.Aed,
            "all" => PlanListChargesResponseTierFlatPriceCurrency.All,
            "amd" => PlanListChargesResponseTierFlatPriceCurrency.Amd,
            "ang" => PlanListChargesResponseTierFlatPriceCurrency.Ang,
            "aud" => PlanListChargesResponseTierFlatPriceCurrency.Aud,
            "awg" => PlanListChargesResponseTierFlatPriceCurrency.Awg,
            "azn" => PlanListChargesResponseTierFlatPriceCurrency.Azn,
            "bam" => PlanListChargesResponseTierFlatPriceCurrency.Bam,
            "bbd" => PlanListChargesResponseTierFlatPriceCurrency.Bbd,
            "bdt" => PlanListChargesResponseTierFlatPriceCurrency.Bdt,
            "bgn" => PlanListChargesResponseTierFlatPriceCurrency.Bgn,
            "bif" => PlanListChargesResponseTierFlatPriceCurrency.Bif,
            "bmd" => PlanListChargesResponseTierFlatPriceCurrency.Bmd,
            "bnd" => PlanListChargesResponseTierFlatPriceCurrency.Bnd,
            "bsd" => PlanListChargesResponseTierFlatPriceCurrency.Bsd,
            "bwp" => PlanListChargesResponseTierFlatPriceCurrency.Bwp,
            "byn" => PlanListChargesResponseTierFlatPriceCurrency.Byn,
            "bzd" => PlanListChargesResponseTierFlatPriceCurrency.Bzd,
            "brl" => PlanListChargesResponseTierFlatPriceCurrency.Brl,
            "cad" => PlanListChargesResponseTierFlatPriceCurrency.Cad,
            "cdf" => PlanListChargesResponseTierFlatPriceCurrency.Cdf,
            "chf" => PlanListChargesResponseTierFlatPriceCurrency.Chf,
            "cny" => PlanListChargesResponseTierFlatPriceCurrency.Cny,
            "czk" => PlanListChargesResponseTierFlatPriceCurrency.Czk,
            "dkk" => PlanListChargesResponseTierFlatPriceCurrency.Dkk,
            "dop" => PlanListChargesResponseTierFlatPriceCurrency.Dop,
            "dzd" => PlanListChargesResponseTierFlatPriceCurrency.Dzd,
            "egp" => PlanListChargesResponseTierFlatPriceCurrency.Egp,
            "etb" => PlanListChargesResponseTierFlatPriceCurrency.Etb,
            "eur" => PlanListChargesResponseTierFlatPriceCurrency.Eur,
            "fjd" => PlanListChargesResponseTierFlatPriceCurrency.Fjd,
            "gbp" => PlanListChargesResponseTierFlatPriceCurrency.Gbp,
            "gel" => PlanListChargesResponseTierFlatPriceCurrency.Gel,
            "gip" => PlanListChargesResponseTierFlatPriceCurrency.Gip,
            "gmd" => PlanListChargesResponseTierFlatPriceCurrency.Gmd,
            "gyd" => PlanListChargesResponseTierFlatPriceCurrency.Gyd,
            "hkd" => PlanListChargesResponseTierFlatPriceCurrency.Hkd,
            "hrk" => PlanListChargesResponseTierFlatPriceCurrency.Hrk,
            "htg" => PlanListChargesResponseTierFlatPriceCurrency.Htg,
            "idr" => PlanListChargesResponseTierFlatPriceCurrency.Idr,
            "ils" => PlanListChargesResponseTierFlatPriceCurrency.Ils,
            "inr" => PlanListChargesResponseTierFlatPriceCurrency.Inr,
            "isk" => PlanListChargesResponseTierFlatPriceCurrency.Isk,
            "jmd" => PlanListChargesResponseTierFlatPriceCurrency.Jmd,
            "jpy" => PlanListChargesResponseTierFlatPriceCurrency.Jpy,
            "kes" => PlanListChargesResponseTierFlatPriceCurrency.Kes,
            "kgs" => PlanListChargesResponseTierFlatPriceCurrency.Kgs,
            "khr" => PlanListChargesResponseTierFlatPriceCurrency.Khr,
            "kmf" => PlanListChargesResponseTierFlatPriceCurrency.Kmf,
            "krw" => PlanListChargesResponseTierFlatPriceCurrency.Krw,
            "kyd" => PlanListChargesResponseTierFlatPriceCurrency.Kyd,
            "kzt" => PlanListChargesResponseTierFlatPriceCurrency.Kzt,
            "lbp" => PlanListChargesResponseTierFlatPriceCurrency.Lbp,
            "lkr" => PlanListChargesResponseTierFlatPriceCurrency.Lkr,
            "lrd" => PlanListChargesResponseTierFlatPriceCurrency.Lrd,
            "lsl" => PlanListChargesResponseTierFlatPriceCurrency.Lsl,
            "mad" => PlanListChargesResponseTierFlatPriceCurrency.Mad,
            "mdl" => PlanListChargesResponseTierFlatPriceCurrency.Mdl,
            "mga" => PlanListChargesResponseTierFlatPriceCurrency.Mga,
            "mkd" => PlanListChargesResponseTierFlatPriceCurrency.Mkd,
            "mmk" => PlanListChargesResponseTierFlatPriceCurrency.Mmk,
            "mnt" => PlanListChargesResponseTierFlatPriceCurrency.Mnt,
            "mop" => PlanListChargesResponseTierFlatPriceCurrency.Mop,
            "mro" => PlanListChargesResponseTierFlatPriceCurrency.Mro,
            "mvr" => PlanListChargesResponseTierFlatPriceCurrency.Mvr,
            "mwk" => PlanListChargesResponseTierFlatPriceCurrency.Mwk,
            "mxn" => PlanListChargesResponseTierFlatPriceCurrency.Mxn,
            "myr" => PlanListChargesResponseTierFlatPriceCurrency.Myr,
            "mzn" => PlanListChargesResponseTierFlatPriceCurrency.Mzn,
            "nad" => PlanListChargesResponseTierFlatPriceCurrency.Nad,
            "ngn" => PlanListChargesResponseTierFlatPriceCurrency.Ngn,
            "nok" => PlanListChargesResponseTierFlatPriceCurrency.Nok,
            "npr" => PlanListChargesResponseTierFlatPriceCurrency.Npr,
            "nzd" => PlanListChargesResponseTierFlatPriceCurrency.Nzd,
            "pgk" => PlanListChargesResponseTierFlatPriceCurrency.Pgk,
            "php" => PlanListChargesResponseTierFlatPriceCurrency.Php,
            "pkr" => PlanListChargesResponseTierFlatPriceCurrency.Pkr,
            "pln" => PlanListChargesResponseTierFlatPriceCurrency.Pln,
            "qar" => PlanListChargesResponseTierFlatPriceCurrency.Qar,
            "ron" => PlanListChargesResponseTierFlatPriceCurrency.Ron,
            "rsd" => PlanListChargesResponseTierFlatPriceCurrency.Rsd,
            "rub" => PlanListChargesResponseTierFlatPriceCurrency.Rub,
            "rwf" => PlanListChargesResponseTierFlatPriceCurrency.Rwf,
            "sar" => PlanListChargesResponseTierFlatPriceCurrency.Sar,
            "sbd" => PlanListChargesResponseTierFlatPriceCurrency.Sbd,
            "scr" => PlanListChargesResponseTierFlatPriceCurrency.Scr,
            "sek" => PlanListChargesResponseTierFlatPriceCurrency.Sek,
            "sgd" => PlanListChargesResponseTierFlatPriceCurrency.Sgd,
            "sle" => PlanListChargesResponseTierFlatPriceCurrency.Sle,
            "sll" => PlanListChargesResponseTierFlatPriceCurrency.Sll,
            "sos" => PlanListChargesResponseTierFlatPriceCurrency.Sos,
            "szl" => PlanListChargesResponseTierFlatPriceCurrency.Szl,
            "thb" => PlanListChargesResponseTierFlatPriceCurrency.Thb,
            "tjs" => PlanListChargesResponseTierFlatPriceCurrency.Tjs,
            "top" => PlanListChargesResponseTierFlatPriceCurrency.Top,
            "try" => PlanListChargesResponseTierFlatPriceCurrency.Try,
            "ttd" => PlanListChargesResponseTierFlatPriceCurrency.Ttd,
            "tzs" => PlanListChargesResponseTierFlatPriceCurrency.Tzs,
            "uah" => PlanListChargesResponseTierFlatPriceCurrency.Uah,
            "uzs" => PlanListChargesResponseTierFlatPriceCurrency.Uzs,
            "vnd" => PlanListChargesResponseTierFlatPriceCurrency.Vnd,
            "vuv" => PlanListChargesResponseTierFlatPriceCurrency.Vuv,
            "wst" => PlanListChargesResponseTierFlatPriceCurrency.Wst,
            "xaf" => PlanListChargesResponseTierFlatPriceCurrency.Xaf,
            "xcd" => PlanListChargesResponseTierFlatPriceCurrency.Xcd,
            "yer" => PlanListChargesResponseTierFlatPriceCurrency.Yer,
            "zar" => PlanListChargesResponseTierFlatPriceCurrency.Zar,
            "zmw" => PlanListChargesResponseTierFlatPriceCurrency.Zmw,
            "clp" => PlanListChargesResponseTierFlatPriceCurrency.Clp,
            "djf" => PlanListChargesResponseTierFlatPriceCurrency.Djf,
            "gnf" => PlanListChargesResponseTierFlatPriceCurrency.Gnf,
            "ugx" => PlanListChargesResponseTierFlatPriceCurrency.Ugx,
            "pyg" => PlanListChargesResponseTierFlatPriceCurrency.Pyg,
            "xof" => PlanListChargesResponseTierFlatPriceCurrency.Xof,
            "xpf" => PlanListChargesResponseTierFlatPriceCurrency.Xpf,
            _ => (PlanListChargesResponseTierFlatPriceCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PlanListChargesResponseTierFlatPriceCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PlanListChargesResponseTierFlatPriceCurrency.Usd => "usd",
                PlanListChargesResponseTierFlatPriceCurrency.Aed => "aed",
                PlanListChargesResponseTierFlatPriceCurrency.All => "all",
                PlanListChargesResponseTierFlatPriceCurrency.Amd => "amd",
                PlanListChargesResponseTierFlatPriceCurrency.Ang => "ang",
                PlanListChargesResponseTierFlatPriceCurrency.Aud => "aud",
                PlanListChargesResponseTierFlatPriceCurrency.Awg => "awg",
                PlanListChargesResponseTierFlatPriceCurrency.Azn => "azn",
                PlanListChargesResponseTierFlatPriceCurrency.Bam => "bam",
                PlanListChargesResponseTierFlatPriceCurrency.Bbd => "bbd",
                PlanListChargesResponseTierFlatPriceCurrency.Bdt => "bdt",
                PlanListChargesResponseTierFlatPriceCurrency.Bgn => "bgn",
                PlanListChargesResponseTierFlatPriceCurrency.Bif => "bif",
                PlanListChargesResponseTierFlatPriceCurrency.Bmd => "bmd",
                PlanListChargesResponseTierFlatPriceCurrency.Bnd => "bnd",
                PlanListChargesResponseTierFlatPriceCurrency.Bsd => "bsd",
                PlanListChargesResponseTierFlatPriceCurrency.Bwp => "bwp",
                PlanListChargesResponseTierFlatPriceCurrency.Byn => "byn",
                PlanListChargesResponseTierFlatPriceCurrency.Bzd => "bzd",
                PlanListChargesResponseTierFlatPriceCurrency.Brl => "brl",
                PlanListChargesResponseTierFlatPriceCurrency.Cad => "cad",
                PlanListChargesResponseTierFlatPriceCurrency.Cdf => "cdf",
                PlanListChargesResponseTierFlatPriceCurrency.Chf => "chf",
                PlanListChargesResponseTierFlatPriceCurrency.Cny => "cny",
                PlanListChargesResponseTierFlatPriceCurrency.Czk => "czk",
                PlanListChargesResponseTierFlatPriceCurrency.Dkk => "dkk",
                PlanListChargesResponseTierFlatPriceCurrency.Dop => "dop",
                PlanListChargesResponseTierFlatPriceCurrency.Dzd => "dzd",
                PlanListChargesResponseTierFlatPriceCurrency.Egp => "egp",
                PlanListChargesResponseTierFlatPriceCurrency.Etb => "etb",
                PlanListChargesResponseTierFlatPriceCurrency.Eur => "eur",
                PlanListChargesResponseTierFlatPriceCurrency.Fjd => "fjd",
                PlanListChargesResponseTierFlatPriceCurrency.Gbp => "gbp",
                PlanListChargesResponseTierFlatPriceCurrency.Gel => "gel",
                PlanListChargesResponseTierFlatPriceCurrency.Gip => "gip",
                PlanListChargesResponseTierFlatPriceCurrency.Gmd => "gmd",
                PlanListChargesResponseTierFlatPriceCurrency.Gyd => "gyd",
                PlanListChargesResponseTierFlatPriceCurrency.Hkd => "hkd",
                PlanListChargesResponseTierFlatPriceCurrency.Hrk => "hrk",
                PlanListChargesResponseTierFlatPriceCurrency.Htg => "htg",
                PlanListChargesResponseTierFlatPriceCurrency.Idr => "idr",
                PlanListChargesResponseTierFlatPriceCurrency.Ils => "ils",
                PlanListChargesResponseTierFlatPriceCurrency.Inr => "inr",
                PlanListChargesResponseTierFlatPriceCurrency.Isk => "isk",
                PlanListChargesResponseTierFlatPriceCurrency.Jmd => "jmd",
                PlanListChargesResponseTierFlatPriceCurrency.Jpy => "jpy",
                PlanListChargesResponseTierFlatPriceCurrency.Kes => "kes",
                PlanListChargesResponseTierFlatPriceCurrency.Kgs => "kgs",
                PlanListChargesResponseTierFlatPriceCurrency.Khr => "khr",
                PlanListChargesResponseTierFlatPriceCurrency.Kmf => "kmf",
                PlanListChargesResponseTierFlatPriceCurrency.Krw => "krw",
                PlanListChargesResponseTierFlatPriceCurrency.Kyd => "kyd",
                PlanListChargesResponseTierFlatPriceCurrency.Kzt => "kzt",
                PlanListChargesResponseTierFlatPriceCurrency.Lbp => "lbp",
                PlanListChargesResponseTierFlatPriceCurrency.Lkr => "lkr",
                PlanListChargesResponseTierFlatPriceCurrency.Lrd => "lrd",
                PlanListChargesResponseTierFlatPriceCurrency.Lsl => "lsl",
                PlanListChargesResponseTierFlatPriceCurrency.Mad => "mad",
                PlanListChargesResponseTierFlatPriceCurrency.Mdl => "mdl",
                PlanListChargesResponseTierFlatPriceCurrency.Mga => "mga",
                PlanListChargesResponseTierFlatPriceCurrency.Mkd => "mkd",
                PlanListChargesResponseTierFlatPriceCurrency.Mmk => "mmk",
                PlanListChargesResponseTierFlatPriceCurrency.Mnt => "mnt",
                PlanListChargesResponseTierFlatPriceCurrency.Mop => "mop",
                PlanListChargesResponseTierFlatPriceCurrency.Mro => "mro",
                PlanListChargesResponseTierFlatPriceCurrency.Mvr => "mvr",
                PlanListChargesResponseTierFlatPriceCurrency.Mwk => "mwk",
                PlanListChargesResponseTierFlatPriceCurrency.Mxn => "mxn",
                PlanListChargesResponseTierFlatPriceCurrency.Myr => "myr",
                PlanListChargesResponseTierFlatPriceCurrency.Mzn => "mzn",
                PlanListChargesResponseTierFlatPriceCurrency.Nad => "nad",
                PlanListChargesResponseTierFlatPriceCurrency.Ngn => "ngn",
                PlanListChargesResponseTierFlatPriceCurrency.Nok => "nok",
                PlanListChargesResponseTierFlatPriceCurrency.Npr => "npr",
                PlanListChargesResponseTierFlatPriceCurrency.Nzd => "nzd",
                PlanListChargesResponseTierFlatPriceCurrency.Pgk => "pgk",
                PlanListChargesResponseTierFlatPriceCurrency.Php => "php",
                PlanListChargesResponseTierFlatPriceCurrency.Pkr => "pkr",
                PlanListChargesResponseTierFlatPriceCurrency.Pln => "pln",
                PlanListChargesResponseTierFlatPriceCurrency.Qar => "qar",
                PlanListChargesResponseTierFlatPriceCurrency.Ron => "ron",
                PlanListChargesResponseTierFlatPriceCurrency.Rsd => "rsd",
                PlanListChargesResponseTierFlatPriceCurrency.Rub => "rub",
                PlanListChargesResponseTierFlatPriceCurrency.Rwf => "rwf",
                PlanListChargesResponseTierFlatPriceCurrency.Sar => "sar",
                PlanListChargesResponseTierFlatPriceCurrency.Sbd => "sbd",
                PlanListChargesResponseTierFlatPriceCurrency.Scr => "scr",
                PlanListChargesResponseTierFlatPriceCurrency.Sek => "sek",
                PlanListChargesResponseTierFlatPriceCurrency.Sgd => "sgd",
                PlanListChargesResponseTierFlatPriceCurrency.Sle => "sle",
                PlanListChargesResponseTierFlatPriceCurrency.Sll => "sll",
                PlanListChargesResponseTierFlatPriceCurrency.Sos => "sos",
                PlanListChargesResponseTierFlatPriceCurrency.Szl => "szl",
                PlanListChargesResponseTierFlatPriceCurrency.Thb => "thb",
                PlanListChargesResponseTierFlatPriceCurrency.Tjs => "tjs",
                PlanListChargesResponseTierFlatPriceCurrency.Top => "top",
                PlanListChargesResponseTierFlatPriceCurrency.Try => "try",
                PlanListChargesResponseTierFlatPriceCurrency.Ttd => "ttd",
                PlanListChargesResponseTierFlatPriceCurrency.Tzs => "tzs",
                PlanListChargesResponseTierFlatPriceCurrency.Uah => "uah",
                PlanListChargesResponseTierFlatPriceCurrency.Uzs => "uzs",
                PlanListChargesResponseTierFlatPriceCurrency.Vnd => "vnd",
                PlanListChargesResponseTierFlatPriceCurrency.Vuv => "vuv",
                PlanListChargesResponseTierFlatPriceCurrency.Wst => "wst",
                PlanListChargesResponseTierFlatPriceCurrency.Xaf => "xaf",
                PlanListChargesResponseTierFlatPriceCurrency.Xcd => "xcd",
                PlanListChargesResponseTierFlatPriceCurrency.Yer => "yer",
                PlanListChargesResponseTierFlatPriceCurrency.Zar => "zar",
                PlanListChargesResponseTierFlatPriceCurrency.Zmw => "zmw",
                PlanListChargesResponseTierFlatPriceCurrency.Clp => "clp",
                PlanListChargesResponseTierFlatPriceCurrency.Djf => "djf",
                PlanListChargesResponseTierFlatPriceCurrency.Gnf => "gnf",
                PlanListChargesResponseTierFlatPriceCurrency.Ugx => "ugx",
                PlanListChargesResponseTierFlatPriceCurrency.Pyg => "pyg",
                PlanListChargesResponseTierFlatPriceCurrency.Xof => "xof",
                PlanListChargesResponseTierFlatPriceCurrency.Xpf => "xpf",
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
        PlanListChargesResponseTierUnitPrice,
        PlanListChargesResponseTierUnitPriceFromRaw
    >)
)]
public sealed record class PlanListChargesResponseTierUnitPrice : JsonModel
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
    public required ApiEnum<string, PlanListChargesResponseTierUnitPriceCurrency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, PlanListChargesResponseTierUnitPriceCurrency>
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

    public PlanListChargesResponseTierUnitPrice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlanListChargesResponseTierUnitPrice(
        PlanListChargesResponseTierUnitPrice planListChargesResponseTierUnitPrice
    )
        : base(planListChargesResponseTierUnitPrice) { }
#pragma warning restore CS8618

    public PlanListChargesResponseTierUnitPrice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlanListChargesResponseTierUnitPrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlanListChargesResponseTierUnitPriceFromRaw.FromRawUnchecked"/>
    public static PlanListChargesResponseTierUnitPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlanListChargesResponseTierUnitPriceFromRaw
    : IFromRawJson<PlanListChargesResponseTierUnitPrice>
{
    /// <inheritdoc/>
    public PlanListChargesResponseTierUnitPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlanListChargesResponseTierUnitPrice.FromRawUnchecked(rawData);
}

/// <summary>
/// ISO 4217 currency code
/// </summary>
[JsonConverter(typeof(PlanListChargesResponseTierUnitPriceCurrencyConverter))]
public enum PlanListChargesResponseTierUnitPriceCurrency
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

sealed class PlanListChargesResponseTierUnitPriceCurrencyConverter
    : JsonConverter<PlanListChargesResponseTierUnitPriceCurrency>
{
    public override PlanListChargesResponseTierUnitPriceCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => PlanListChargesResponseTierUnitPriceCurrency.Usd,
            "aed" => PlanListChargesResponseTierUnitPriceCurrency.Aed,
            "all" => PlanListChargesResponseTierUnitPriceCurrency.All,
            "amd" => PlanListChargesResponseTierUnitPriceCurrency.Amd,
            "ang" => PlanListChargesResponseTierUnitPriceCurrency.Ang,
            "aud" => PlanListChargesResponseTierUnitPriceCurrency.Aud,
            "awg" => PlanListChargesResponseTierUnitPriceCurrency.Awg,
            "azn" => PlanListChargesResponseTierUnitPriceCurrency.Azn,
            "bam" => PlanListChargesResponseTierUnitPriceCurrency.Bam,
            "bbd" => PlanListChargesResponseTierUnitPriceCurrency.Bbd,
            "bdt" => PlanListChargesResponseTierUnitPriceCurrency.Bdt,
            "bgn" => PlanListChargesResponseTierUnitPriceCurrency.Bgn,
            "bif" => PlanListChargesResponseTierUnitPriceCurrency.Bif,
            "bmd" => PlanListChargesResponseTierUnitPriceCurrency.Bmd,
            "bnd" => PlanListChargesResponseTierUnitPriceCurrency.Bnd,
            "bsd" => PlanListChargesResponseTierUnitPriceCurrency.Bsd,
            "bwp" => PlanListChargesResponseTierUnitPriceCurrency.Bwp,
            "byn" => PlanListChargesResponseTierUnitPriceCurrency.Byn,
            "bzd" => PlanListChargesResponseTierUnitPriceCurrency.Bzd,
            "brl" => PlanListChargesResponseTierUnitPriceCurrency.Brl,
            "cad" => PlanListChargesResponseTierUnitPriceCurrency.Cad,
            "cdf" => PlanListChargesResponseTierUnitPriceCurrency.Cdf,
            "chf" => PlanListChargesResponseTierUnitPriceCurrency.Chf,
            "cny" => PlanListChargesResponseTierUnitPriceCurrency.Cny,
            "czk" => PlanListChargesResponseTierUnitPriceCurrency.Czk,
            "dkk" => PlanListChargesResponseTierUnitPriceCurrency.Dkk,
            "dop" => PlanListChargesResponseTierUnitPriceCurrency.Dop,
            "dzd" => PlanListChargesResponseTierUnitPriceCurrency.Dzd,
            "egp" => PlanListChargesResponseTierUnitPriceCurrency.Egp,
            "etb" => PlanListChargesResponseTierUnitPriceCurrency.Etb,
            "eur" => PlanListChargesResponseTierUnitPriceCurrency.Eur,
            "fjd" => PlanListChargesResponseTierUnitPriceCurrency.Fjd,
            "gbp" => PlanListChargesResponseTierUnitPriceCurrency.Gbp,
            "gel" => PlanListChargesResponseTierUnitPriceCurrency.Gel,
            "gip" => PlanListChargesResponseTierUnitPriceCurrency.Gip,
            "gmd" => PlanListChargesResponseTierUnitPriceCurrency.Gmd,
            "gyd" => PlanListChargesResponseTierUnitPriceCurrency.Gyd,
            "hkd" => PlanListChargesResponseTierUnitPriceCurrency.Hkd,
            "hrk" => PlanListChargesResponseTierUnitPriceCurrency.Hrk,
            "htg" => PlanListChargesResponseTierUnitPriceCurrency.Htg,
            "idr" => PlanListChargesResponseTierUnitPriceCurrency.Idr,
            "ils" => PlanListChargesResponseTierUnitPriceCurrency.Ils,
            "inr" => PlanListChargesResponseTierUnitPriceCurrency.Inr,
            "isk" => PlanListChargesResponseTierUnitPriceCurrency.Isk,
            "jmd" => PlanListChargesResponseTierUnitPriceCurrency.Jmd,
            "jpy" => PlanListChargesResponseTierUnitPriceCurrency.Jpy,
            "kes" => PlanListChargesResponseTierUnitPriceCurrency.Kes,
            "kgs" => PlanListChargesResponseTierUnitPriceCurrency.Kgs,
            "khr" => PlanListChargesResponseTierUnitPriceCurrency.Khr,
            "kmf" => PlanListChargesResponseTierUnitPriceCurrency.Kmf,
            "krw" => PlanListChargesResponseTierUnitPriceCurrency.Krw,
            "kyd" => PlanListChargesResponseTierUnitPriceCurrency.Kyd,
            "kzt" => PlanListChargesResponseTierUnitPriceCurrency.Kzt,
            "lbp" => PlanListChargesResponseTierUnitPriceCurrency.Lbp,
            "lkr" => PlanListChargesResponseTierUnitPriceCurrency.Lkr,
            "lrd" => PlanListChargesResponseTierUnitPriceCurrency.Lrd,
            "lsl" => PlanListChargesResponseTierUnitPriceCurrency.Lsl,
            "mad" => PlanListChargesResponseTierUnitPriceCurrency.Mad,
            "mdl" => PlanListChargesResponseTierUnitPriceCurrency.Mdl,
            "mga" => PlanListChargesResponseTierUnitPriceCurrency.Mga,
            "mkd" => PlanListChargesResponseTierUnitPriceCurrency.Mkd,
            "mmk" => PlanListChargesResponseTierUnitPriceCurrency.Mmk,
            "mnt" => PlanListChargesResponseTierUnitPriceCurrency.Mnt,
            "mop" => PlanListChargesResponseTierUnitPriceCurrency.Mop,
            "mro" => PlanListChargesResponseTierUnitPriceCurrency.Mro,
            "mvr" => PlanListChargesResponseTierUnitPriceCurrency.Mvr,
            "mwk" => PlanListChargesResponseTierUnitPriceCurrency.Mwk,
            "mxn" => PlanListChargesResponseTierUnitPriceCurrency.Mxn,
            "myr" => PlanListChargesResponseTierUnitPriceCurrency.Myr,
            "mzn" => PlanListChargesResponseTierUnitPriceCurrency.Mzn,
            "nad" => PlanListChargesResponseTierUnitPriceCurrency.Nad,
            "ngn" => PlanListChargesResponseTierUnitPriceCurrency.Ngn,
            "nok" => PlanListChargesResponseTierUnitPriceCurrency.Nok,
            "npr" => PlanListChargesResponseTierUnitPriceCurrency.Npr,
            "nzd" => PlanListChargesResponseTierUnitPriceCurrency.Nzd,
            "pgk" => PlanListChargesResponseTierUnitPriceCurrency.Pgk,
            "php" => PlanListChargesResponseTierUnitPriceCurrency.Php,
            "pkr" => PlanListChargesResponseTierUnitPriceCurrency.Pkr,
            "pln" => PlanListChargesResponseTierUnitPriceCurrency.Pln,
            "qar" => PlanListChargesResponseTierUnitPriceCurrency.Qar,
            "ron" => PlanListChargesResponseTierUnitPriceCurrency.Ron,
            "rsd" => PlanListChargesResponseTierUnitPriceCurrency.Rsd,
            "rub" => PlanListChargesResponseTierUnitPriceCurrency.Rub,
            "rwf" => PlanListChargesResponseTierUnitPriceCurrency.Rwf,
            "sar" => PlanListChargesResponseTierUnitPriceCurrency.Sar,
            "sbd" => PlanListChargesResponseTierUnitPriceCurrency.Sbd,
            "scr" => PlanListChargesResponseTierUnitPriceCurrency.Scr,
            "sek" => PlanListChargesResponseTierUnitPriceCurrency.Sek,
            "sgd" => PlanListChargesResponseTierUnitPriceCurrency.Sgd,
            "sle" => PlanListChargesResponseTierUnitPriceCurrency.Sle,
            "sll" => PlanListChargesResponseTierUnitPriceCurrency.Sll,
            "sos" => PlanListChargesResponseTierUnitPriceCurrency.Sos,
            "szl" => PlanListChargesResponseTierUnitPriceCurrency.Szl,
            "thb" => PlanListChargesResponseTierUnitPriceCurrency.Thb,
            "tjs" => PlanListChargesResponseTierUnitPriceCurrency.Tjs,
            "top" => PlanListChargesResponseTierUnitPriceCurrency.Top,
            "try" => PlanListChargesResponseTierUnitPriceCurrency.Try,
            "ttd" => PlanListChargesResponseTierUnitPriceCurrency.Ttd,
            "tzs" => PlanListChargesResponseTierUnitPriceCurrency.Tzs,
            "uah" => PlanListChargesResponseTierUnitPriceCurrency.Uah,
            "uzs" => PlanListChargesResponseTierUnitPriceCurrency.Uzs,
            "vnd" => PlanListChargesResponseTierUnitPriceCurrency.Vnd,
            "vuv" => PlanListChargesResponseTierUnitPriceCurrency.Vuv,
            "wst" => PlanListChargesResponseTierUnitPriceCurrency.Wst,
            "xaf" => PlanListChargesResponseTierUnitPriceCurrency.Xaf,
            "xcd" => PlanListChargesResponseTierUnitPriceCurrency.Xcd,
            "yer" => PlanListChargesResponseTierUnitPriceCurrency.Yer,
            "zar" => PlanListChargesResponseTierUnitPriceCurrency.Zar,
            "zmw" => PlanListChargesResponseTierUnitPriceCurrency.Zmw,
            "clp" => PlanListChargesResponseTierUnitPriceCurrency.Clp,
            "djf" => PlanListChargesResponseTierUnitPriceCurrency.Djf,
            "gnf" => PlanListChargesResponseTierUnitPriceCurrency.Gnf,
            "ugx" => PlanListChargesResponseTierUnitPriceCurrency.Ugx,
            "pyg" => PlanListChargesResponseTierUnitPriceCurrency.Pyg,
            "xof" => PlanListChargesResponseTierUnitPriceCurrency.Xof,
            "xpf" => PlanListChargesResponseTierUnitPriceCurrency.Xpf,
            _ => (PlanListChargesResponseTierUnitPriceCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PlanListChargesResponseTierUnitPriceCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PlanListChargesResponseTierUnitPriceCurrency.Usd => "usd",
                PlanListChargesResponseTierUnitPriceCurrency.Aed => "aed",
                PlanListChargesResponseTierUnitPriceCurrency.All => "all",
                PlanListChargesResponseTierUnitPriceCurrency.Amd => "amd",
                PlanListChargesResponseTierUnitPriceCurrency.Ang => "ang",
                PlanListChargesResponseTierUnitPriceCurrency.Aud => "aud",
                PlanListChargesResponseTierUnitPriceCurrency.Awg => "awg",
                PlanListChargesResponseTierUnitPriceCurrency.Azn => "azn",
                PlanListChargesResponseTierUnitPriceCurrency.Bam => "bam",
                PlanListChargesResponseTierUnitPriceCurrency.Bbd => "bbd",
                PlanListChargesResponseTierUnitPriceCurrency.Bdt => "bdt",
                PlanListChargesResponseTierUnitPriceCurrency.Bgn => "bgn",
                PlanListChargesResponseTierUnitPriceCurrency.Bif => "bif",
                PlanListChargesResponseTierUnitPriceCurrency.Bmd => "bmd",
                PlanListChargesResponseTierUnitPriceCurrency.Bnd => "bnd",
                PlanListChargesResponseTierUnitPriceCurrency.Bsd => "bsd",
                PlanListChargesResponseTierUnitPriceCurrency.Bwp => "bwp",
                PlanListChargesResponseTierUnitPriceCurrency.Byn => "byn",
                PlanListChargesResponseTierUnitPriceCurrency.Bzd => "bzd",
                PlanListChargesResponseTierUnitPriceCurrency.Brl => "brl",
                PlanListChargesResponseTierUnitPriceCurrency.Cad => "cad",
                PlanListChargesResponseTierUnitPriceCurrency.Cdf => "cdf",
                PlanListChargesResponseTierUnitPriceCurrency.Chf => "chf",
                PlanListChargesResponseTierUnitPriceCurrency.Cny => "cny",
                PlanListChargesResponseTierUnitPriceCurrency.Czk => "czk",
                PlanListChargesResponseTierUnitPriceCurrency.Dkk => "dkk",
                PlanListChargesResponseTierUnitPriceCurrency.Dop => "dop",
                PlanListChargesResponseTierUnitPriceCurrency.Dzd => "dzd",
                PlanListChargesResponseTierUnitPriceCurrency.Egp => "egp",
                PlanListChargesResponseTierUnitPriceCurrency.Etb => "etb",
                PlanListChargesResponseTierUnitPriceCurrency.Eur => "eur",
                PlanListChargesResponseTierUnitPriceCurrency.Fjd => "fjd",
                PlanListChargesResponseTierUnitPriceCurrency.Gbp => "gbp",
                PlanListChargesResponseTierUnitPriceCurrency.Gel => "gel",
                PlanListChargesResponseTierUnitPriceCurrency.Gip => "gip",
                PlanListChargesResponseTierUnitPriceCurrency.Gmd => "gmd",
                PlanListChargesResponseTierUnitPriceCurrency.Gyd => "gyd",
                PlanListChargesResponseTierUnitPriceCurrency.Hkd => "hkd",
                PlanListChargesResponseTierUnitPriceCurrency.Hrk => "hrk",
                PlanListChargesResponseTierUnitPriceCurrency.Htg => "htg",
                PlanListChargesResponseTierUnitPriceCurrency.Idr => "idr",
                PlanListChargesResponseTierUnitPriceCurrency.Ils => "ils",
                PlanListChargesResponseTierUnitPriceCurrency.Inr => "inr",
                PlanListChargesResponseTierUnitPriceCurrency.Isk => "isk",
                PlanListChargesResponseTierUnitPriceCurrency.Jmd => "jmd",
                PlanListChargesResponseTierUnitPriceCurrency.Jpy => "jpy",
                PlanListChargesResponseTierUnitPriceCurrency.Kes => "kes",
                PlanListChargesResponseTierUnitPriceCurrency.Kgs => "kgs",
                PlanListChargesResponseTierUnitPriceCurrency.Khr => "khr",
                PlanListChargesResponseTierUnitPriceCurrency.Kmf => "kmf",
                PlanListChargesResponseTierUnitPriceCurrency.Krw => "krw",
                PlanListChargesResponseTierUnitPriceCurrency.Kyd => "kyd",
                PlanListChargesResponseTierUnitPriceCurrency.Kzt => "kzt",
                PlanListChargesResponseTierUnitPriceCurrency.Lbp => "lbp",
                PlanListChargesResponseTierUnitPriceCurrency.Lkr => "lkr",
                PlanListChargesResponseTierUnitPriceCurrency.Lrd => "lrd",
                PlanListChargesResponseTierUnitPriceCurrency.Lsl => "lsl",
                PlanListChargesResponseTierUnitPriceCurrency.Mad => "mad",
                PlanListChargesResponseTierUnitPriceCurrency.Mdl => "mdl",
                PlanListChargesResponseTierUnitPriceCurrency.Mga => "mga",
                PlanListChargesResponseTierUnitPriceCurrency.Mkd => "mkd",
                PlanListChargesResponseTierUnitPriceCurrency.Mmk => "mmk",
                PlanListChargesResponseTierUnitPriceCurrency.Mnt => "mnt",
                PlanListChargesResponseTierUnitPriceCurrency.Mop => "mop",
                PlanListChargesResponseTierUnitPriceCurrency.Mro => "mro",
                PlanListChargesResponseTierUnitPriceCurrency.Mvr => "mvr",
                PlanListChargesResponseTierUnitPriceCurrency.Mwk => "mwk",
                PlanListChargesResponseTierUnitPriceCurrency.Mxn => "mxn",
                PlanListChargesResponseTierUnitPriceCurrency.Myr => "myr",
                PlanListChargesResponseTierUnitPriceCurrency.Mzn => "mzn",
                PlanListChargesResponseTierUnitPriceCurrency.Nad => "nad",
                PlanListChargesResponseTierUnitPriceCurrency.Ngn => "ngn",
                PlanListChargesResponseTierUnitPriceCurrency.Nok => "nok",
                PlanListChargesResponseTierUnitPriceCurrency.Npr => "npr",
                PlanListChargesResponseTierUnitPriceCurrency.Nzd => "nzd",
                PlanListChargesResponseTierUnitPriceCurrency.Pgk => "pgk",
                PlanListChargesResponseTierUnitPriceCurrency.Php => "php",
                PlanListChargesResponseTierUnitPriceCurrency.Pkr => "pkr",
                PlanListChargesResponseTierUnitPriceCurrency.Pln => "pln",
                PlanListChargesResponseTierUnitPriceCurrency.Qar => "qar",
                PlanListChargesResponseTierUnitPriceCurrency.Ron => "ron",
                PlanListChargesResponseTierUnitPriceCurrency.Rsd => "rsd",
                PlanListChargesResponseTierUnitPriceCurrency.Rub => "rub",
                PlanListChargesResponseTierUnitPriceCurrency.Rwf => "rwf",
                PlanListChargesResponseTierUnitPriceCurrency.Sar => "sar",
                PlanListChargesResponseTierUnitPriceCurrency.Sbd => "sbd",
                PlanListChargesResponseTierUnitPriceCurrency.Scr => "scr",
                PlanListChargesResponseTierUnitPriceCurrency.Sek => "sek",
                PlanListChargesResponseTierUnitPriceCurrency.Sgd => "sgd",
                PlanListChargesResponseTierUnitPriceCurrency.Sle => "sle",
                PlanListChargesResponseTierUnitPriceCurrency.Sll => "sll",
                PlanListChargesResponseTierUnitPriceCurrency.Sos => "sos",
                PlanListChargesResponseTierUnitPriceCurrency.Szl => "szl",
                PlanListChargesResponseTierUnitPriceCurrency.Thb => "thb",
                PlanListChargesResponseTierUnitPriceCurrency.Tjs => "tjs",
                PlanListChargesResponseTierUnitPriceCurrency.Top => "top",
                PlanListChargesResponseTierUnitPriceCurrency.Try => "try",
                PlanListChargesResponseTierUnitPriceCurrency.Ttd => "ttd",
                PlanListChargesResponseTierUnitPriceCurrency.Tzs => "tzs",
                PlanListChargesResponseTierUnitPriceCurrency.Uah => "uah",
                PlanListChargesResponseTierUnitPriceCurrency.Uzs => "uzs",
                PlanListChargesResponseTierUnitPriceCurrency.Vnd => "vnd",
                PlanListChargesResponseTierUnitPriceCurrency.Vuv => "vuv",
                PlanListChargesResponseTierUnitPriceCurrency.Wst => "wst",
                PlanListChargesResponseTierUnitPriceCurrency.Xaf => "xaf",
                PlanListChargesResponseTierUnitPriceCurrency.Xcd => "xcd",
                PlanListChargesResponseTierUnitPriceCurrency.Yer => "yer",
                PlanListChargesResponseTierUnitPriceCurrency.Zar => "zar",
                PlanListChargesResponseTierUnitPriceCurrency.Zmw => "zmw",
                PlanListChargesResponseTierUnitPriceCurrency.Clp => "clp",
                PlanListChargesResponseTierUnitPriceCurrency.Djf => "djf",
                PlanListChargesResponseTierUnitPriceCurrency.Gnf => "gnf",
                PlanListChargesResponseTierUnitPriceCurrency.Ugx => "ugx",
                PlanListChargesResponseTierUnitPriceCurrency.Pyg => "pyg",
                PlanListChargesResponseTierUnitPriceCurrency.Xof => "xof",
                PlanListChargesResponseTierUnitPriceCurrency.Xpf => "xpf",
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
[JsonConverter(typeof(PlanListChargesResponseTiersModeConverter))]
public enum PlanListChargesResponseTiersMode
{
    Volume,
    Graduated,
}

sealed class PlanListChargesResponseTiersModeConverter
    : JsonConverter<PlanListChargesResponseTiersMode>
{
    public override PlanListChargesResponseTiersMode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "VOLUME" => PlanListChargesResponseTiersMode.Volume,
            "GRADUATED" => PlanListChargesResponseTiersMode.Graduated,
            _ => (PlanListChargesResponseTiersMode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PlanListChargesResponseTiersMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PlanListChargesResponseTiersMode.Volume => "VOLUME",
                PlanListChargesResponseTiersMode.Graduated => "GRADUATED",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
