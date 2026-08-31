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
[JsonConverter(
    typeof(JsonModelConverter<
        PlanListOverageChargesResponse,
        PlanListOverageChargesResponseFromRaw
    >)
)]
public sealed record class PlanListOverageChargesResponse : JsonModel
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
    public required ApiEnum<string, PlanListOverageChargesResponseBillingCadence> BillingCadence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, PlanListOverageChargesResponseBillingCadence>
            >("billingCadence");
        }
        init { this._rawData.Set("billingCadence", value); }
    }

    /// <summary>
    /// The billing model (FLAT_FEE, PER_UNIT, USAGE_BASED, CREDIT_BASED, MINIMUM_SPEND)
    /// </summary>
    public required ApiEnum<string, PlanListOverageChargesResponseBillingModel> BillingModel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, PlanListOverageChargesResponseBillingModel>
            >("billingModel");
        }
        init { this._rawData.Set("billingModel", value); }
    }

    /// <summary>
    /// The billing period (MONTHLY or ANNUALLY)
    /// </summary>
    public required ApiEnum<string, PlanListOverageChargesResponseBillingPeriod> BillingPeriod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, PlanListOverageChargesResponseBillingPeriod>
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
    /// ISO country code for localized pricing, or "eu" for the European Union group
    /// you map countries into, if any
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
    public ApiEnum<string, PlanListOverageChargesResponseCreditGrantCadence>? CreditGrantCadence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, PlanListOverageChargesResponseCreditGrantCadence>
            >("creditGrantCadence");
        }
        init { this._rawData.Set("creditGrantCadence", value); }
    }

    /// <summary>
    /// Credit rate configuration for credit-based pricing
    /// </summary>
    public PlanListOverageChargesResponseCreditRate? CreditRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PlanListOverageChargesResponseCreditRate>(
                "creditRate"
            );
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
    public PlanListOverageChargesResponsePrice? Price
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PlanListOverageChargesResponsePrice>("price");
        }
        init { this._rawData.Set("price", value); }
    }

    /// <summary>
    /// Tiered pricing rows when the charge is tiered
    /// </summary>
    public IReadOnlyList<PlanListOverageChargesResponseTier>? Tiers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<PlanListOverageChargesResponseTier>
            >("tiers");
        }
        init
        {
            this._rawData.Set<ImmutableArray<PlanListOverageChargesResponseTier>?>(
                "tiers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Tiered pricing mode (VOLUME or GRADUATED) when the charge is tiered
    /// </summary>
    public ApiEnum<string, PlanListOverageChargesResponseTiersMode>? TiersMode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, PlanListOverageChargesResponseTiersMode>
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

    public PlanListOverageChargesResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlanListOverageChargesResponse(
        PlanListOverageChargesResponse planListOverageChargesResponse
    )
        : base(planListOverageChargesResponse) { }
#pragma warning restore CS8618

    public PlanListOverageChargesResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlanListOverageChargesResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlanListOverageChargesResponseFromRaw.FromRawUnchecked"/>
    public static PlanListOverageChargesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlanListOverageChargesResponseFromRaw : IFromRawJson<PlanListOverageChargesResponse>
{
    /// <inheritdoc/>
    public PlanListOverageChargesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlanListOverageChargesResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// The billing cadence (RECURRING or ONE_OFF)
/// </summary>
[JsonConverter(typeof(PlanListOverageChargesResponseBillingCadenceConverter))]
public enum PlanListOverageChargesResponseBillingCadence
{
    Recurring,
    OneOff,
}

sealed class PlanListOverageChargesResponseBillingCadenceConverter
    : JsonConverter<PlanListOverageChargesResponseBillingCadence>
{
    public override PlanListOverageChargesResponseBillingCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "RECURRING" => PlanListOverageChargesResponseBillingCadence.Recurring,
            "ONE_OFF" => PlanListOverageChargesResponseBillingCadence.OneOff,
            _ => (PlanListOverageChargesResponseBillingCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PlanListOverageChargesResponseBillingCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PlanListOverageChargesResponseBillingCadence.Recurring => "RECURRING",
                PlanListOverageChargesResponseBillingCadence.OneOff => "ONE_OFF",
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
[JsonConverter(typeof(PlanListOverageChargesResponseBillingModelConverter))]
public enum PlanListOverageChargesResponseBillingModel
{
    FlatFee,
    MinimumSpend,
    PerUnit,
    UsageBased,
    CreditBased,
}

sealed class PlanListOverageChargesResponseBillingModelConverter
    : JsonConverter<PlanListOverageChargesResponseBillingModel>
{
    public override PlanListOverageChargesResponseBillingModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FLAT_FEE" => PlanListOverageChargesResponseBillingModel.FlatFee,
            "MINIMUM_SPEND" => PlanListOverageChargesResponseBillingModel.MinimumSpend,
            "PER_UNIT" => PlanListOverageChargesResponseBillingModel.PerUnit,
            "USAGE_BASED" => PlanListOverageChargesResponseBillingModel.UsageBased,
            "CREDIT_BASED" => PlanListOverageChargesResponseBillingModel.CreditBased,
            _ => (PlanListOverageChargesResponseBillingModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PlanListOverageChargesResponseBillingModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PlanListOverageChargesResponseBillingModel.FlatFee => "FLAT_FEE",
                PlanListOverageChargesResponseBillingModel.MinimumSpend => "MINIMUM_SPEND",
                PlanListOverageChargesResponseBillingModel.PerUnit => "PER_UNIT",
                PlanListOverageChargesResponseBillingModel.UsageBased => "USAGE_BASED",
                PlanListOverageChargesResponseBillingModel.CreditBased => "CREDIT_BASED",
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
[JsonConverter(typeof(PlanListOverageChargesResponseBillingPeriodConverter))]
public enum PlanListOverageChargesResponseBillingPeriod
{
    Monthly,
    Annually,
}

sealed class PlanListOverageChargesResponseBillingPeriodConverter
    : JsonConverter<PlanListOverageChargesResponseBillingPeriod>
{
    public override PlanListOverageChargesResponseBillingPeriod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "MONTHLY" => PlanListOverageChargesResponseBillingPeriod.Monthly,
            "ANNUALLY" => PlanListOverageChargesResponseBillingPeriod.Annually,
            _ => (PlanListOverageChargesResponseBillingPeriod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PlanListOverageChargesResponseBillingPeriod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PlanListOverageChargesResponseBillingPeriod.Monthly => "MONTHLY",
                PlanListOverageChargesResponseBillingPeriod.Annually => "ANNUALLY",
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
[JsonConverter(typeof(PlanListOverageChargesResponseCreditGrantCadenceConverter))]
public enum PlanListOverageChargesResponseCreditGrantCadence
{
    BeginningOfBillingPeriod,
    Monthly,
}

sealed class PlanListOverageChargesResponseCreditGrantCadenceConverter
    : JsonConverter<PlanListOverageChargesResponseCreditGrantCadence>
{
    public override PlanListOverageChargesResponseCreditGrantCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "BEGINNING_OF_BILLING_PERIOD" =>
                PlanListOverageChargesResponseCreditGrantCadence.BeginningOfBillingPeriod,
            "MONTHLY" => PlanListOverageChargesResponseCreditGrantCadence.Monthly,
            _ => (PlanListOverageChargesResponseCreditGrantCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PlanListOverageChargesResponseCreditGrantCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PlanListOverageChargesResponseCreditGrantCadence.BeginningOfBillingPeriod =>
                    "BEGINNING_OF_BILLING_PERIOD",
                PlanListOverageChargesResponseCreditGrantCadence.Monthly => "MONTHLY",
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
        PlanListOverageChargesResponseCreditRate,
        PlanListOverageChargesResponseCreditRateFromRaw
    >)
)]
public sealed record class PlanListOverageChargesResponseCreditRate : JsonModel
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

    public PlanListOverageChargesResponseCreditRate() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlanListOverageChargesResponseCreditRate(
        PlanListOverageChargesResponseCreditRate planListOverageChargesResponseCreditRate
    )
        : base(planListOverageChargesResponseCreditRate) { }
#pragma warning restore CS8618

    public PlanListOverageChargesResponseCreditRate(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlanListOverageChargesResponseCreditRate(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlanListOverageChargesResponseCreditRateFromRaw.FromRawUnchecked"/>
    public static PlanListOverageChargesResponseCreditRate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlanListOverageChargesResponseCreditRateFromRaw
    : IFromRawJson<PlanListOverageChargesResponseCreditRate>
{
    /// <inheritdoc/>
    public PlanListOverageChargesResponseCreditRate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlanListOverageChargesResponseCreditRate.FromRawUnchecked(rawData);
}

/// <summary>
/// The flat price amount and currency, when applicable
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        PlanListOverageChargesResponsePrice,
        PlanListOverageChargesResponsePriceFromRaw
    >)
)]
public sealed record class PlanListOverageChargesResponsePrice : JsonModel
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
    public required ApiEnum<string, PlanListOverageChargesResponsePriceCurrency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, PlanListOverageChargesResponsePriceCurrency>
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

    public PlanListOverageChargesResponsePrice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlanListOverageChargesResponsePrice(
        PlanListOverageChargesResponsePrice planListOverageChargesResponsePrice
    )
        : base(planListOverageChargesResponsePrice) { }
#pragma warning restore CS8618

    public PlanListOverageChargesResponsePrice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlanListOverageChargesResponsePrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlanListOverageChargesResponsePriceFromRaw.FromRawUnchecked"/>
    public static PlanListOverageChargesResponsePrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlanListOverageChargesResponsePriceFromRaw : IFromRawJson<PlanListOverageChargesResponsePrice>
{
    /// <inheritdoc/>
    public PlanListOverageChargesResponsePrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlanListOverageChargesResponsePrice.FromRawUnchecked(rawData);
}

/// <summary>
/// ISO 4217 currency code
/// </summary>
[JsonConverter(typeof(PlanListOverageChargesResponsePriceCurrencyConverter))]
public enum PlanListOverageChargesResponsePriceCurrency
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

sealed class PlanListOverageChargesResponsePriceCurrencyConverter
    : JsonConverter<PlanListOverageChargesResponsePriceCurrency>
{
    public override PlanListOverageChargesResponsePriceCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => PlanListOverageChargesResponsePriceCurrency.Usd,
            "aed" => PlanListOverageChargesResponsePriceCurrency.Aed,
            "all" => PlanListOverageChargesResponsePriceCurrency.All,
            "amd" => PlanListOverageChargesResponsePriceCurrency.Amd,
            "ang" => PlanListOverageChargesResponsePriceCurrency.Ang,
            "aud" => PlanListOverageChargesResponsePriceCurrency.Aud,
            "awg" => PlanListOverageChargesResponsePriceCurrency.Awg,
            "azn" => PlanListOverageChargesResponsePriceCurrency.Azn,
            "bam" => PlanListOverageChargesResponsePriceCurrency.Bam,
            "bbd" => PlanListOverageChargesResponsePriceCurrency.Bbd,
            "bdt" => PlanListOverageChargesResponsePriceCurrency.Bdt,
            "bgn" => PlanListOverageChargesResponsePriceCurrency.Bgn,
            "bif" => PlanListOverageChargesResponsePriceCurrency.Bif,
            "bmd" => PlanListOverageChargesResponsePriceCurrency.Bmd,
            "bnd" => PlanListOverageChargesResponsePriceCurrency.Bnd,
            "bsd" => PlanListOverageChargesResponsePriceCurrency.Bsd,
            "bwp" => PlanListOverageChargesResponsePriceCurrency.Bwp,
            "byn" => PlanListOverageChargesResponsePriceCurrency.Byn,
            "bzd" => PlanListOverageChargesResponsePriceCurrency.Bzd,
            "brl" => PlanListOverageChargesResponsePriceCurrency.Brl,
            "cad" => PlanListOverageChargesResponsePriceCurrency.Cad,
            "cdf" => PlanListOverageChargesResponsePriceCurrency.Cdf,
            "chf" => PlanListOverageChargesResponsePriceCurrency.Chf,
            "cny" => PlanListOverageChargesResponsePriceCurrency.Cny,
            "czk" => PlanListOverageChargesResponsePriceCurrency.Czk,
            "dkk" => PlanListOverageChargesResponsePriceCurrency.Dkk,
            "dop" => PlanListOverageChargesResponsePriceCurrency.Dop,
            "dzd" => PlanListOverageChargesResponsePriceCurrency.Dzd,
            "egp" => PlanListOverageChargesResponsePriceCurrency.Egp,
            "etb" => PlanListOverageChargesResponsePriceCurrency.Etb,
            "eur" => PlanListOverageChargesResponsePriceCurrency.Eur,
            "fjd" => PlanListOverageChargesResponsePriceCurrency.Fjd,
            "gbp" => PlanListOverageChargesResponsePriceCurrency.Gbp,
            "gel" => PlanListOverageChargesResponsePriceCurrency.Gel,
            "gip" => PlanListOverageChargesResponsePriceCurrency.Gip,
            "gmd" => PlanListOverageChargesResponsePriceCurrency.Gmd,
            "gyd" => PlanListOverageChargesResponsePriceCurrency.Gyd,
            "hkd" => PlanListOverageChargesResponsePriceCurrency.Hkd,
            "hrk" => PlanListOverageChargesResponsePriceCurrency.Hrk,
            "htg" => PlanListOverageChargesResponsePriceCurrency.Htg,
            "idr" => PlanListOverageChargesResponsePriceCurrency.Idr,
            "ils" => PlanListOverageChargesResponsePriceCurrency.Ils,
            "inr" => PlanListOverageChargesResponsePriceCurrency.Inr,
            "isk" => PlanListOverageChargesResponsePriceCurrency.Isk,
            "jmd" => PlanListOverageChargesResponsePriceCurrency.Jmd,
            "jpy" => PlanListOverageChargesResponsePriceCurrency.Jpy,
            "kes" => PlanListOverageChargesResponsePriceCurrency.Kes,
            "kgs" => PlanListOverageChargesResponsePriceCurrency.Kgs,
            "khr" => PlanListOverageChargesResponsePriceCurrency.Khr,
            "kmf" => PlanListOverageChargesResponsePriceCurrency.Kmf,
            "krw" => PlanListOverageChargesResponsePriceCurrency.Krw,
            "kyd" => PlanListOverageChargesResponsePriceCurrency.Kyd,
            "kzt" => PlanListOverageChargesResponsePriceCurrency.Kzt,
            "lbp" => PlanListOverageChargesResponsePriceCurrency.Lbp,
            "lkr" => PlanListOverageChargesResponsePriceCurrency.Lkr,
            "lrd" => PlanListOverageChargesResponsePriceCurrency.Lrd,
            "lsl" => PlanListOverageChargesResponsePriceCurrency.Lsl,
            "mad" => PlanListOverageChargesResponsePriceCurrency.Mad,
            "mdl" => PlanListOverageChargesResponsePriceCurrency.Mdl,
            "mga" => PlanListOverageChargesResponsePriceCurrency.Mga,
            "mkd" => PlanListOverageChargesResponsePriceCurrency.Mkd,
            "mmk" => PlanListOverageChargesResponsePriceCurrency.Mmk,
            "mnt" => PlanListOverageChargesResponsePriceCurrency.Mnt,
            "mop" => PlanListOverageChargesResponsePriceCurrency.Mop,
            "mro" => PlanListOverageChargesResponsePriceCurrency.Mro,
            "mvr" => PlanListOverageChargesResponsePriceCurrency.Mvr,
            "mwk" => PlanListOverageChargesResponsePriceCurrency.Mwk,
            "mxn" => PlanListOverageChargesResponsePriceCurrency.Mxn,
            "myr" => PlanListOverageChargesResponsePriceCurrency.Myr,
            "mzn" => PlanListOverageChargesResponsePriceCurrency.Mzn,
            "nad" => PlanListOverageChargesResponsePriceCurrency.Nad,
            "ngn" => PlanListOverageChargesResponsePriceCurrency.Ngn,
            "nok" => PlanListOverageChargesResponsePriceCurrency.Nok,
            "npr" => PlanListOverageChargesResponsePriceCurrency.Npr,
            "nzd" => PlanListOverageChargesResponsePriceCurrency.Nzd,
            "pgk" => PlanListOverageChargesResponsePriceCurrency.Pgk,
            "php" => PlanListOverageChargesResponsePriceCurrency.Php,
            "pkr" => PlanListOverageChargesResponsePriceCurrency.Pkr,
            "pln" => PlanListOverageChargesResponsePriceCurrency.Pln,
            "qar" => PlanListOverageChargesResponsePriceCurrency.Qar,
            "ron" => PlanListOverageChargesResponsePriceCurrency.Ron,
            "rsd" => PlanListOverageChargesResponsePriceCurrency.Rsd,
            "rub" => PlanListOverageChargesResponsePriceCurrency.Rub,
            "rwf" => PlanListOverageChargesResponsePriceCurrency.Rwf,
            "sar" => PlanListOverageChargesResponsePriceCurrency.Sar,
            "sbd" => PlanListOverageChargesResponsePriceCurrency.Sbd,
            "scr" => PlanListOverageChargesResponsePriceCurrency.Scr,
            "sek" => PlanListOverageChargesResponsePriceCurrency.Sek,
            "sgd" => PlanListOverageChargesResponsePriceCurrency.Sgd,
            "sle" => PlanListOverageChargesResponsePriceCurrency.Sle,
            "sll" => PlanListOverageChargesResponsePriceCurrency.Sll,
            "sos" => PlanListOverageChargesResponsePriceCurrency.Sos,
            "szl" => PlanListOverageChargesResponsePriceCurrency.Szl,
            "thb" => PlanListOverageChargesResponsePriceCurrency.Thb,
            "tjs" => PlanListOverageChargesResponsePriceCurrency.Tjs,
            "top" => PlanListOverageChargesResponsePriceCurrency.Top,
            "try" => PlanListOverageChargesResponsePriceCurrency.Try,
            "ttd" => PlanListOverageChargesResponsePriceCurrency.Ttd,
            "tzs" => PlanListOverageChargesResponsePriceCurrency.Tzs,
            "uah" => PlanListOverageChargesResponsePriceCurrency.Uah,
            "uzs" => PlanListOverageChargesResponsePriceCurrency.Uzs,
            "vnd" => PlanListOverageChargesResponsePriceCurrency.Vnd,
            "vuv" => PlanListOverageChargesResponsePriceCurrency.Vuv,
            "wst" => PlanListOverageChargesResponsePriceCurrency.Wst,
            "xaf" => PlanListOverageChargesResponsePriceCurrency.Xaf,
            "xcd" => PlanListOverageChargesResponsePriceCurrency.Xcd,
            "yer" => PlanListOverageChargesResponsePriceCurrency.Yer,
            "zar" => PlanListOverageChargesResponsePriceCurrency.Zar,
            "zmw" => PlanListOverageChargesResponsePriceCurrency.Zmw,
            "clp" => PlanListOverageChargesResponsePriceCurrency.Clp,
            "djf" => PlanListOverageChargesResponsePriceCurrency.Djf,
            "gnf" => PlanListOverageChargesResponsePriceCurrency.Gnf,
            "ugx" => PlanListOverageChargesResponsePriceCurrency.Ugx,
            "pyg" => PlanListOverageChargesResponsePriceCurrency.Pyg,
            "xof" => PlanListOverageChargesResponsePriceCurrency.Xof,
            "xpf" => PlanListOverageChargesResponsePriceCurrency.Xpf,
            _ => (PlanListOverageChargesResponsePriceCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PlanListOverageChargesResponsePriceCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PlanListOverageChargesResponsePriceCurrency.Usd => "usd",
                PlanListOverageChargesResponsePriceCurrency.Aed => "aed",
                PlanListOverageChargesResponsePriceCurrency.All => "all",
                PlanListOverageChargesResponsePriceCurrency.Amd => "amd",
                PlanListOverageChargesResponsePriceCurrency.Ang => "ang",
                PlanListOverageChargesResponsePriceCurrency.Aud => "aud",
                PlanListOverageChargesResponsePriceCurrency.Awg => "awg",
                PlanListOverageChargesResponsePriceCurrency.Azn => "azn",
                PlanListOverageChargesResponsePriceCurrency.Bam => "bam",
                PlanListOverageChargesResponsePriceCurrency.Bbd => "bbd",
                PlanListOverageChargesResponsePriceCurrency.Bdt => "bdt",
                PlanListOverageChargesResponsePriceCurrency.Bgn => "bgn",
                PlanListOverageChargesResponsePriceCurrency.Bif => "bif",
                PlanListOverageChargesResponsePriceCurrency.Bmd => "bmd",
                PlanListOverageChargesResponsePriceCurrency.Bnd => "bnd",
                PlanListOverageChargesResponsePriceCurrency.Bsd => "bsd",
                PlanListOverageChargesResponsePriceCurrency.Bwp => "bwp",
                PlanListOverageChargesResponsePriceCurrency.Byn => "byn",
                PlanListOverageChargesResponsePriceCurrency.Bzd => "bzd",
                PlanListOverageChargesResponsePriceCurrency.Brl => "brl",
                PlanListOverageChargesResponsePriceCurrency.Cad => "cad",
                PlanListOverageChargesResponsePriceCurrency.Cdf => "cdf",
                PlanListOverageChargesResponsePriceCurrency.Chf => "chf",
                PlanListOverageChargesResponsePriceCurrency.Cny => "cny",
                PlanListOverageChargesResponsePriceCurrency.Czk => "czk",
                PlanListOverageChargesResponsePriceCurrency.Dkk => "dkk",
                PlanListOverageChargesResponsePriceCurrency.Dop => "dop",
                PlanListOverageChargesResponsePriceCurrency.Dzd => "dzd",
                PlanListOverageChargesResponsePriceCurrency.Egp => "egp",
                PlanListOverageChargesResponsePriceCurrency.Etb => "etb",
                PlanListOverageChargesResponsePriceCurrency.Eur => "eur",
                PlanListOverageChargesResponsePriceCurrency.Fjd => "fjd",
                PlanListOverageChargesResponsePriceCurrency.Gbp => "gbp",
                PlanListOverageChargesResponsePriceCurrency.Gel => "gel",
                PlanListOverageChargesResponsePriceCurrency.Gip => "gip",
                PlanListOverageChargesResponsePriceCurrency.Gmd => "gmd",
                PlanListOverageChargesResponsePriceCurrency.Gyd => "gyd",
                PlanListOverageChargesResponsePriceCurrency.Hkd => "hkd",
                PlanListOverageChargesResponsePriceCurrency.Hrk => "hrk",
                PlanListOverageChargesResponsePriceCurrency.Htg => "htg",
                PlanListOverageChargesResponsePriceCurrency.Idr => "idr",
                PlanListOverageChargesResponsePriceCurrency.Ils => "ils",
                PlanListOverageChargesResponsePriceCurrency.Inr => "inr",
                PlanListOverageChargesResponsePriceCurrency.Isk => "isk",
                PlanListOverageChargesResponsePriceCurrency.Jmd => "jmd",
                PlanListOverageChargesResponsePriceCurrency.Jpy => "jpy",
                PlanListOverageChargesResponsePriceCurrency.Kes => "kes",
                PlanListOverageChargesResponsePriceCurrency.Kgs => "kgs",
                PlanListOverageChargesResponsePriceCurrency.Khr => "khr",
                PlanListOverageChargesResponsePriceCurrency.Kmf => "kmf",
                PlanListOverageChargesResponsePriceCurrency.Krw => "krw",
                PlanListOverageChargesResponsePriceCurrency.Kyd => "kyd",
                PlanListOverageChargesResponsePriceCurrency.Kzt => "kzt",
                PlanListOverageChargesResponsePriceCurrency.Lbp => "lbp",
                PlanListOverageChargesResponsePriceCurrency.Lkr => "lkr",
                PlanListOverageChargesResponsePriceCurrency.Lrd => "lrd",
                PlanListOverageChargesResponsePriceCurrency.Lsl => "lsl",
                PlanListOverageChargesResponsePriceCurrency.Mad => "mad",
                PlanListOverageChargesResponsePriceCurrency.Mdl => "mdl",
                PlanListOverageChargesResponsePriceCurrency.Mga => "mga",
                PlanListOverageChargesResponsePriceCurrency.Mkd => "mkd",
                PlanListOverageChargesResponsePriceCurrency.Mmk => "mmk",
                PlanListOverageChargesResponsePriceCurrency.Mnt => "mnt",
                PlanListOverageChargesResponsePriceCurrency.Mop => "mop",
                PlanListOverageChargesResponsePriceCurrency.Mro => "mro",
                PlanListOverageChargesResponsePriceCurrency.Mvr => "mvr",
                PlanListOverageChargesResponsePriceCurrency.Mwk => "mwk",
                PlanListOverageChargesResponsePriceCurrency.Mxn => "mxn",
                PlanListOverageChargesResponsePriceCurrency.Myr => "myr",
                PlanListOverageChargesResponsePriceCurrency.Mzn => "mzn",
                PlanListOverageChargesResponsePriceCurrency.Nad => "nad",
                PlanListOverageChargesResponsePriceCurrency.Ngn => "ngn",
                PlanListOverageChargesResponsePriceCurrency.Nok => "nok",
                PlanListOverageChargesResponsePriceCurrency.Npr => "npr",
                PlanListOverageChargesResponsePriceCurrency.Nzd => "nzd",
                PlanListOverageChargesResponsePriceCurrency.Pgk => "pgk",
                PlanListOverageChargesResponsePriceCurrency.Php => "php",
                PlanListOverageChargesResponsePriceCurrency.Pkr => "pkr",
                PlanListOverageChargesResponsePriceCurrency.Pln => "pln",
                PlanListOverageChargesResponsePriceCurrency.Qar => "qar",
                PlanListOverageChargesResponsePriceCurrency.Ron => "ron",
                PlanListOverageChargesResponsePriceCurrency.Rsd => "rsd",
                PlanListOverageChargesResponsePriceCurrency.Rub => "rub",
                PlanListOverageChargesResponsePriceCurrency.Rwf => "rwf",
                PlanListOverageChargesResponsePriceCurrency.Sar => "sar",
                PlanListOverageChargesResponsePriceCurrency.Sbd => "sbd",
                PlanListOverageChargesResponsePriceCurrency.Scr => "scr",
                PlanListOverageChargesResponsePriceCurrency.Sek => "sek",
                PlanListOverageChargesResponsePriceCurrency.Sgd => "sgd",
                PlanListOverageChargesResponsePriceCurrency.Sle => "sle",
                PlanListOverageChargesResponsePriceCurrency.Sll => "sll",
                PlanListOverageChargesResponsePriceCurrency.Sos => "sos",
                PlanListOverageChargesResponsePriceCurrency.Szl => "szl",
                PlanListOverageChargesResponsePriceCurrency.Thb => "thb",
                PlanListOverageChargesResponsePriceCurrency.Tjs => "tjs",
                PlanListOverageChargesResponsePriceCurrency.Top => "top",
                PlanListOverageChargesResponsePriceCurrency.Try => "try",
                PlanListOverageChargesResponsePriceCurrency.Ttd => "ttd",
                PlanListOverageChargesResponsePriceCurrency.Tzs => "tzs",
                PlanListOverageChargesResponsePriceCurrency.Uah => "uah",
                PlanListOverageChargesResponsePriceCurrency.Uzs => "uzs",
                PlanListOverageChargesResponsePriceCurrency.Vnd => "vnd",
                PlanListOverageChargesResponsePriceCurrency.Vuv => "vuv",
                PlanListOverageChargesResponsePriceCurrency.Wst => "wst",
                PlanListOverageChargesResponsePriceCurrency.Xaf => "xaf",
                PlanListOverageChargesResponsePriceCurrency.Xcd => "xcd",
                PlanListOverageChargesResponsePriceCurrency.Yer => "yer",
                PlanListOverageChargesResponsePriceCurrency.Zar => "zar",
                PlanListOverageChargesResponsePriceCurrency.Zmw => "zmw",
                PlanListOverageChargesResponsePriceCurrency.Clp => "clp",
                PlanListOverageChargesResponsePriceCurrency.Djf => "djf",
                PlanListOverageChargesResponsePriceCurrency.Gnf => "gnf",
                PlanListOverageChargesResponsePriceCurrency.Ugx => "ugx",
                PlanListOverageChargesResponsePriceCurrency.Pyg => "pyg",
                PlanListOverageChargesResponsePriceCurrency.Xof => "xof",
                PlanListOverageChargesResponsePriceCurrency.Xpf => "xpf",
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
    typeof(JsonModelConverter<
        PlanListOverageChargesResponseTier,
        PlanListOverageChargesResponseTierFromRaw
    >)
)]
public sealed record class PlanListOverageChargesResponseTier : JsonModel
{
    /// <summary>
    /// Flat price for this tier
    /// </summary>
    public PlanListOverageChargesResponseTierFlatPrice? FlatPrice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PlanListOverageChargesResponseTierFlatPrice>(
                "flatPrice"
            );
        }
        init { this._rawData.Set("flatPrice", value); }
    }

    /// <summary>
    /// Per-unit price in this tier
    /// </summary>
    public PlanListOverageChargesResponseTierUnitPrice? UnitPrice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PlanListOverageChargesResponseTierUnitPrice>(
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

    public PlanListOverageChargesResponseTier() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlanListOverageChargesResponseTier(
        PlanListOverageChargesResponseTier planListOverageChargesResponseTier
    )
        : base(planListOverageChargesResponseTier) { }
#pragma warning restore CS8618

    public PlanListOverageChargesResponseTier(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlanListOverageChargesResponseTier(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlanListOverageChargesResponseTierFromRaw.FromRawUnchecked"/>
    public static PlanListOverageChargesResponseTier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlanListOverageChargesResponseTierFromRaw : IFromRawJson<PlanListOverageChargesResponseTier>
{
    /// <inheritdoc/>
    public PlanListOverageChargesResponseTier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlanListOverageChargesResponseTier.FromRawUnchecked(rawData);
}

/// <summary>
/// Flat price for this tier
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        PlanListOverageChargesResponseTierFlatPrice,
        PlanListOverageChargesResponseTierFlatPriceFromRaw
    >)
)]
public sealed record class PlanListOverageChargesResponseTierFlatPrice : JsonModel
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
    public required ApiEnum<string, PlanListOverageChargesResponseTierFlatPriceCurrency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, PlanListOverageChargesResponseTierFlatPriceCurrency>
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

    public PlanListOverageChargesResponseTierFlatPrice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlanListOverageChargesResponseTierFlatPrice(
        PlanListOverageChargesResponseTierFlatPrice planListOverageChargesResponseTierFlatPrice
    )
        : base(planListOverageChargesResponseTierFlatPrice) { }
#pragma warning restore CS8618

    public PlanListOverageChargesResponseTierFlatPrice(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlanListOverageChargesResponseTierFlatPrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlanListOverageChargesResponseTierFlatPriceFromRaw.FromRawUnchecked"/>
    public static PlanListOverageChargesResponseTierFlatPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlanListOverageChargesResponseTierFlatPriceFromRaw
    : IFromRawJson<PlanListOverageChargesResponseTierFlatPrice>
{
    /// <inheritdoc/>
    public PlanListOverageChargesResponseTierFlatPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlanListOverageChargesResponseTierFlatPrice.FromRawUnchecked(rawData);
}

/// <summary>
/// ISO 4217 currency code
/// </summary>
[JsonConverter(typeof(PlanListOverageChargesResponseTierFlatPriceCurrencyConverter))]
public enum PlanListOverageChargesResponseTierFlatPriceCurrency
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

sealed class PlanListOverageChargesResponseTierFlatPriceCurrencyConverter
    : JsonConverter<PlanListOverageChargesResponseTierFlatPriceCurrency>
{
    public override PlanListOverageChargesResponseTierFlatPriceCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => PlanListOverageChargesResponseTierFlatPriceCurrency.Usd,
            "aed" => PlanListOverageChargesResponseTierFlatPriceCurrency.Aed,
            "all" => PlanListOverageChargesResponseTierFlatPriceCurrency.All,
            "amd" => PlanListOverageChargesResponseTierFlatPriceCurrency.Amd,
            "ang" => PlanListOverageChargesResponseTierFlatPriceCurrency.Ang,
            "aud" => PlanListOverageChargesResponseTierFlatPriceCurrency.Aud,
            "awg" => PlanListOverageChargesResponseTierFlatPriceCurrency.Awg,
            "azn" => PlanListOverageChargesResponseTierFlatPriceCurrency.Azn,
            "bam" => PlanListOverageChargesResponseTierFlatPriceCurrency.Bam,
            "bbd" => PlanListOverageChargesResponseTierFlatPriceCurrency.Bbd,
            "bdt" => PlanListOverageChargesResponseTierFlatPriceCurrency.Bdt,
            "bgn" => PlanListOverageChargesResponseTierFlatPriceCurrency.Bgn,
            "bif" => PlanListOverageChargesResponseTierFlatPriceCurrency.Bif,
            "bmd" => PlanListOverageChargesResponseTierFlatPriceCurrency.Bmd,
            "bnd" => PlanListOverageChargesResponseTierFlatPriceCurrency.Bnd,
            "bsd" => PlanListOverageChargesResponseTierFlatPriceCurrency.Bsd,
            "bwp" => PlanListOverageChargesResponseTierFlatPriceCurrency.Bwp,
            "byn" => PlanListOverageChargesResponseTierFlatPriceCurrency.Byn,
            "bzd" => PlanListOverageChargesResponseTierFlatPriceCurrency.Bzd,
            "brl" => PlanListOverageChargesResponseTierFlatPriceCurrency.Brl,
            "cad" => PlanListOverageChargesResponseTierFlatPriceCurrency.Cad,
            "cdf" => PlanListOverageChargesResponseTierFlatPriceCurrency.Cdf,
            "chf" => PlanListOverageChargesResponseTierFlatPriceCurrency.Chf,
            "cny" => PlanListOverageChargesResponseTierFlatPriceCurrency.Cny,
            "czk" => PlanListOverageChargesResponseTierFlatPriceCurrency.Czk,
            "dkk" => PlanListOverageChargesResponseTierFlatPriceCurrency.Dkk,
            "dop" => PlanListOverageChargesResponseTierFlatPriceCurrency.Dop,
            "dzd" => PlanListOverageChargesResponseTierFlatPriceCurrency.Dzd,
            "egp" => PlanListOverageChargesResponseTierFlatPriceCurrency.Egp,
            "etb" => PlanListOverageChargesResponseTierFlatPriceCurrency.Etb,
            "eur" => PlanListOverageChargesResponseTierFlatPriceCurrency.Eur,
            "fjd" => PlanListOverageChargesResponseTierFlatPriceCurrency.Fjd,
            "gbp" => PlanListOverageChargesResponseTierFlatPriceCurrency.Gbp,
            "gel" => PlanListOverageChargesResponseTierFlatPriceCurrency.Gel,
            "gip" => PlanListOverageChargesResponseTierFlatPriceCurrency.Gip,
            "gmd" => PlanListOverageChargesResponseTierFlatPriceCurrency.Gmd,
            "gyd" => PlanListOverageChargesResponseTierFlatPriceCurrency.Gyd,
            "hkd" => PlanListOverageChargesResponseTierFlatPriceCurrency.Hkd,
            "hrk" => PlanListOverageChargesResponseTierFlatPriceCurrency.Hrk,
            "htg" => PlanListOverageChargesResponseTierFlatPriceCurrency.Htg,
            "idr" => PlanListOverageChargesResponseTierFlatPriceCurrency.Idr,
            "ils" => PlanListOverageChargesResponseTierFlatPriceCurrency.Ils,
            "inr" => PlanListOverageChargesResponseTierFlatPriceCurrency.Inr,
            "isk" => PlanListOverageChargesResponseTierFlatPriceCurrency.Isk,
            "jmd" => PlanListOverageChargesResponseTierFlatPriceCurrency.Jmd,
            "jpy" => PlanListOverageChargesResponseTierFlatPriceCurrency.Jpy,
            "kes" => PlanListOverageChargesResponseTierFlatPriceCurrency.Kes,
            "kgs" => PlanListOverageChargesResponseTierFlatPriceCurrency.Kgs,
            "khr" => PlanListOverageChargesResponseTierFlatPriceCurrency.Khr,
            "kmf" => PlanListOverageChargesResponseTierFlatPriceCurrency.Kmf,
            "krw" => PlanListOverageChargesResponseTierFlatPriceCurrency.Krw,
            "kyd" => PlanListOverageChargesResponseTierFlatPriceCurrency.Kyd,
            "kzt" => PlanListOverageChargesResponseTierFlatPriceCurrency.Kzt,
            "lbp" => PlanListOverageChargesResponseTierFlatPriceCurrency.Lbp,
            "lkr" => PlanListOverageChargesResponseTierFlatPriceCurrency.Lkr,
            "lrd" => PlanListOverageChargesResponseTierFlatPriceCurrency.Lrd,
            "lsl" => PlanListOverageChargesResponseTierFlatPriceCurrency.Lsl,
            "mad" => PlanListOverageChargesResponseTierFlatPriceCurrency.Mad,
            "mdl" => PlanListOverageChargesResponseTierFlatPriceCurrency.Mdl,
            "mga" => PlanListOverageChargesResponseTierFlatPriceCurrency.Mga,
            "mkd" => PlanListOverageChargesResponseTierFlatPriceCurrency.Mkd,
            "mmk" => PlanListOverageChargesResponseTierFlatPriceCurrency.Mmk,
            "mnt" => PlanListOverageChargesResponseTierFlatPriceCurrency.Mnt,
            "mop" => PlanListOverageChargesResponseTierFlatPriceCurrency.Mop,
            "mro" => PlanListOverageChargesResponseTierFlatPriceCurrency.Mro,
            "mvr" => PlanListOverageChargesResponseTierFlatPriceCurrency.Mvr,
            "mwk" => PlanListOverageChargesResponseTierFlatPriceCurrency.Mwk,
            "mxn" => PlanListOverageChargesResponseTierFlatPriceCurrency.Mxn,
            "myr" => PlanListOverageChargesResponseTierFlatPriceCurrency.Myr,
            "mzn" => PlanListOverageChargesResponseTierFlatPriceCurrency.Mzn,
            "nad" => PlanListOverageChargesResponseTierFlatPriceCurrency.Nad,
            "ngn" => PlanListOverageChargesResponseTierFlatPriceCurrency.Ngn,
            "nok" => PlanListOverageChargesResponseTierFlatPriceCurrency.Nok,
            "npr" => PlanListOverageChargesResponseTierFlatPriceCurrency.Npr,
            "nzd" => PlanListOverageChargesResponseTierFlatPriceCurrency.Nzd,
            "pgk" => PlanListOverageChargesResponseTierFlatPriceCurrency.Pgk,
            "php" => PlanListOverageChargesResponseTierFlatPriceCurrency.Php,
            "pkr" => PlanListOverageChargesResponseTierFlatPriceCurrency.Pkr,
            "pln" => PlanListOverageChargesResponseTierFlatPriceCurrency.Pln,
            "qar" => PlanListOverageChargesResponseTierFlatPriceCurrency.Qar,
            "ron" => PlanListOverageChargesResponseTierFlatPriceCurrency.Ron,
            "rsd" => PlanListOverageChargesResponseTierFlatPriceCurrency.Rsd,
            "rub" => PlanListOverageChargesResponseTierFlatPriceCurrency.Rub,
            "rwf" => PlanListOverageChargesResponseTierFlatPriceCurrency.Rwf,
            "sar" => PlanListOverageChargesResponseTierFlatPriceCurrency.Sar,
            "sbd" => PlanListOverageChargesResponseTierFlatPriceCurrency.Sbd,
            "scr" => PlanListOverageChargesResponseTierFlatPriceCurrency.Scr,
            "sek" => PlanListOverageChargesResponseTierFlatPriceCurrency.Sek,
            "sgd" => PlanListOverageChargesResponseTierFlatPriceCurrency.Sgd,
            "sle" => PlanListOverageChargesResponseTierFlatPriceCurrency.Sle,
            "sll" => PlanListOverageChargesResponseTierFlatPriceCurrency.Sll,
            "sos" => PlanListOverageChargesResponseTierFlatPriceCurrency.Sos,
            "szl" => PlanListOverageChargesResponseTierFlatPriceCurrency.Szl,
            "thb" => PlanListOverageChargesResponseTierFlatPriceCurrency.Thb,
            "tjs" => PlanListOverageChargesResponseTierFlatPriceCurrency.Tjs,
            "top" => PlanListOverageChargesResponseTierFlatPriceCurrency.Top,
            "try" => PlanListOverageChargesResponseTierFlatPriceCurrency.Try,
            "ttd" => PlanListOverageChargesResponseTierFlatPriceCurrency.Ttd,
            "tzs" => PlanListOverageChargesResponseTierFlatPriceCurrency.Tzs,
            "uah" => PlanListOverageChargesResponseTierFlatPriceCurrency.Uah,
            "uzs" => PlanListOverageChargesResponseTierFlatPriceCurrency.Uzs,
            "vnd" => PlanListOverageChargesResponseTierFlatPriceCurrency.Vnd,
            "vuv" => PlanListOverageChargesResponseTierFlatPriceCurrency.Vuv,
            "wst" => PlanListOverageChargesResponseTierFlatPriceCurrency.Wst,
            "xaf" => PlanListOverageChargesResponseTierFlatPriceCurrency.Xaf,
            "xcd" => PlanListOverageChargesResponseTierFlatPriceCurrency.Xcd,
            "yer" => PlanListOverageChargesResponseTierFlatPriceCurrency.Yer,
            "zar" => PlanListOverageChargesResponseTierFlatPriceCurrency.Zar,
            "zmw" => PlanListOverageChargesResponseTierFlatPriceCurrency.Zmw,
            "clp" => PlanListOverageChargesResponseTierFlatPriceCurrency.Clp,
            "djf" => PlanListOverageChargesResponseTierFlatPriceCurrency.Djf,
            "gnf" => PlanListOverageChargesResponseTierFlatPriceCurrency.Gnf,
            "ugx" => PlanListOverageChargesResponseTierFlatPriceCurrency.Ugx,
            "pyg" => PlanListOverageChargesResponseTierFlatPriceCurrency.Pyg,
            "xof" => PlanListOverageChargesResponseTierFlatPriceCurrency.Xof,
            "xpf" => PlanListOverageChargesResponseTierFlatPriceCurrency.Xpf,
            _ => (PlanListOverageChargesResponseTierFlatPriceCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PlanListOverageChargesResponseTierFlatPriceCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PlanListOverageChargesResponseTierFlatPriceCurrency.Usd => "usd",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Aed => "aed",
                PlanListOverageChargesResponseTierFlatPriceCurrency.All => "all",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Amd => "amd",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Ang => "ang",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Aud => "aud",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Awg => "awg",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Azn => "azn",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Bam => "bam",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Bbd => "bbd",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Bdt => "bdt",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Bgn => "bgn",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Bif => "bif",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Bmd => "bmd",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Bnd => "bnd",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Bsd => "bsd",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Bwp => "bwp",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Byn => "byn",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Bzd => "bzd",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Brl => "brl",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Cad => "cad",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Cdf => "cdf",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Chf => "chf",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Cny => "cny",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Czk => "czk",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Dkk => "dkk",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Dop => "dop",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Dzd => "dzd",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Egp => "egp",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Etb => "etb",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Eur => "eur",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Fjd => "fjd",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Gbp => "gbp",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Gel => "gel",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Gip => "gip",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Gmd => "gmd",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Gyd => "gyd",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Hkd => "hkd",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Hrk => "hrk",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Htg => "htg",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Idr => "idr",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Ils => "ils",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Inr => "inr",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Isk => "isk",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Jmd => "jmd",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Jpy => "jpy",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Kes => "kes",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Kgs => "kgs",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Khr => "khr",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Kmf => "kmf",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Krw => "krw",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Kyd => "kyd",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Kzt => "kzt",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Lbp => "lbp",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Lkr => "lkr",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Lrd => "lrd",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Lsl => "lsl",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Mad => "mad",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Mdl => "mdl",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Mga => "mga",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Mkd => "mkd",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Mmk => "mmk",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Mnt => "mnt",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Mop => "mop",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Mro => "mro",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Mvr => "mvr",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Mwk => "mwk",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Mxn => "mxn",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Myr => "myr",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Mzn => "mzn",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Nad => "nad",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Ngn => "ngn",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Nok => "nok",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Npr => "npr",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Nzd => "nzd",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Pgk => "pgk",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Php => "php",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Pkr => "pkr",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Pln => "pln",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Qar => "qar",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Ron => "ron",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Rsd => "rsd",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Rub => "rub",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Rwf => "rwf",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Sar => "sar",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Sbd => "sbd",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Scr => "scr",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Sek => "sek",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Sgd => "sgd",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Sle => "sle",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Sll => "sll",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Sos => "sos",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Szl => "szl",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Thb => "thb",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Tjs => "tjs",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Top => "top",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Try => "try",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Ttd => "ttd",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Tzs => "tzs",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Uah => "uah",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Uzs => "uzs",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Vnd => "vnd",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Vuv => "vuv",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Wst => "wst",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Xaf => "xaf",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Xcd => "xcd",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Yer => "yer",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Zar => "zar",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Zmw => "zmw",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Clp => "clp",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Djf => "djf",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Gnf => "gnf",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Ugx => "ugx",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Pyg => "pyg",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Xof => "xof",
                PlanListOverageChargesResponseTierFlatPriceCurrency.Xpf => "xpf",
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
        PlanListOverageChargesResponseTierUnitPrice,
        PlanListOverageChargesResponseTierUnitPriceFromRaw
    >)
)]
public sealed record class PlanListOverageChargesResponseTierUnitPrice : JsonModel
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
    public required ApiEnum<string, PlanListOverageChargesResponseTierUnitPriceCurrency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, PlanListOverageChargesResponseTierUnitPriceCurrency>
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

    public PlanListOverageChargesResponseTierUnitPrice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlanListOverageChargesResponseTierUnitPrice(
        PlanListOverageChargesResponseTierUnitPrice planListOverageChargesResponseTierUnitPrice
    )
        : base(planListOverageChargesResponseTierUnitPrice) { }
#pragma warning restore CS8618

    public PlanListOverageChargesResponseTierUnitPrice(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlanListOverageChargesResponseTierUnitPrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlanListOverageChargesResponseTierUnitPriceFromRaw.FromRawUnchecked"/>
    public static PlanListOverageChargesResponseTierUnitPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlanListOverageChargesResponseTierUnitPriceFromRaw
    : IFromRawJson<PlanListOverageChargesResponseTierUnitPrice>
{
    /// <inheritdoc/>
    public PlanListOverageChargesResponseTierUnitPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlanListOverageChargesResponseTierUnitPrice.FromRawUnchecked(rawData);
}

/// <summary>
/// ISO 4217 currency code
/// </summary>
[JsonConverter(typeof(PlanListOverageChargesResponseTierUnitPriceCurrencyConverter))]
public enum PlanListOverageChargesResponseTierUnitPriceCurrency
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

sealed class PlanListOverageChargesResponseTierUnitPriceCurrencyConverter
    : JsonConverter<PlanListOverageChargesResponseTierUnitPriceCurrency>
{
    public override PlanListOverageChargesResponseTierUnitPriceCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => PlanListOverageChargesResponseTierUnitPriceCurrency.Usd,
            "aed" => PlanListOverageChargesResponseTierUnitPriceCurrency.Aed,
            "all" => PlanListOverageChargesResponseTierUnitPriceCurrency.All,
            "amd" => PlanListOverageChargesResponseTierUnitPriceCurrency.Amd,
            "ang" => PlanListOverageChargesResponseTierUnitPriceCurrency.Ang,
            "aud" => PlanListOverageChargesResponseTierUnitPriceCurrency.Aud,
            "awg" => PlanListOverageChargesResponseTierUnitPriceCurrency.Awg,
            "azn" => PlanListOverageChargesResponseTierUnitPriceCurrency.Azn,
            "bam" => PlanListOverageChargesResponseTierUnitPriceCurrency.Bam,
            "bbd" => PlanListOverageChargesResponseTierUnitPriceCurrency.Bbd,
            "bdt" => PlanListOverageChargesResponseTierUnitPriceCurrency.Bdt,
            "bgn" => PlanListOverageChargesResponseTierUnitPriceCurrency.Bgn,
            "bif" => PlanListOverageChargesResponseTierUnitPriceCurrency.Bif,
            "bmd" => PlanListOverageChargesResponseTierUnitPriceCurrency.Bmd,
            "bnd" => PlanListOverageChargesResponseTierUnitPriceCurrency.Bnd,
            "bsd" => PlanListOverageChargesResponseTierUnitPriceCurrency.Bsd,
            "bwp" => PlanListOverageChargesResponseTierUnitPriceCurrency.Bwp,
            "byn" => PlanListOverageChargesResponseTierUnitPriceCurrency.Byn,
            "bzd" => PlanListOverageChargesResponseTierUnitPriceCurrency.Bzd,
            "brl" => PlanListOverageChargesResponseTierUnitPriceCurrency.Brl,
            "cad" => PlanListOverageChargesResponseTierUnitPriceCurrency.Cad,
            "cdf" => PlanListOverageChargesResponseTierUnitPriceCurrency.Cdf,
            "chf" => PlanListOverageChargesResponseTierUnitPriceCurrency.Chf,
            "cny" => PlanListOverageChargesResponseTierUnitPriceCurrency.Cny,
            "czk" => PlanListOverageChargesResponseTierUnitPriceCurrency.Czk,
            "dkk" => PlanListOverageChargesResponseTierUnitPriceCurrency.Dkk,
            "dop" => PlanListOverageChargesResponseTierUnitPriceCurrency.Dop,
            "dzd" => PlanListOverageChargesResponseTierUnitPriceCurrency.Dzd,
            "egp" => PlanListOverageChargesResponseTierUnitPriceCurrency.Egp,
            "etb" => PlanListOverageChargesResponseTierUnitPriceCurrency.Etb,
            "eur" => PlanListOverageChargesResponseTierUnitPriceCurrency.Eur,
            "fjd" => PlanListOverageChargesResponseTierUnitPriceCurrency.Fjd,
            "gbp" => PlanListOverageChargesResponseTierUnitPriceCurrency.Gbp,
            "gel" => PlanListOverageChargesResponseTierUnitPriceCurrency.Gel,
            "gip" => PlanListOverageChargesResponseTierUnitPriceCurrency.Gip,
            "gmd" => PlanListOverageChargesResponseTierUnitPriceCurrency.Gmd,
            "gyd" => PlanListOverageChargesResponseTierUnitPriceCurrency.Gyd,
            "hkd" => PlanListOverageChargesResponseTierUnitPriceCurrency.Hkd,
            "hrk" => PlanListOverageChargesResponseTierUnitPriceCurrency.Hrk,
            "htg" => PlanListOverageChargesResponseTierUnitPriceCurrency.Htg,
            "idr" => PlanListOverageChargesResponseTierUnitPriceCurrency.Idr,
            "ils" => PlanListOverageChargesResponseTierUnitPriceCurrency.Ils,
            "inr" => PlanListOverageChargesResponseTierUnitPriceCurrency.Inr,
            "isk" => PlanListOverageChargesResponseTierUnitPriceCurrency.Isk,
            "jmd" => PlanListOverageChargesResponseTierUnitPriceCurrency.Jmd,
            "jpy" => PlanListOverageChargesResponseTierUnitPriceCurrency.Jpy,
            "kes" => PlanListOverageChargesResponseTierUnitPriceCurrency.Kes,
            "kgs" => PlanListOverageChargesResponseTierUnitPriceCurrency.Kgs,
            "khr" => PlanListOverageChargesResponseTierUnitPriceCurrency.Khr,
            "kmf" => PlanListOverageChargesResponseTierUnitPriceCurrency.Kmf,
            "krw" => PlanListOverageChargesResponseTierUnitPriceCurrency.Krw,
            "kyd" => PlanListOverageChargesResponseTierUnitPriceCurrency.Kyd,
            "kzt" => PlanListOverageChargesResponseTierUnitPriceCurrency.Kzt,
            "lbp" => PlanListOverageChargesResponseTierUnitPriceCurrency.Lbp,
            "lkr" => PlanListOverageChargesResponseTierUnitPriceCurrency.Lkr,
            "lrd" => PlanListOverageChargesResponseTierUnitPriceCurrency.Lrd,
            "lsl" => PlanListOverageChargesResponseTierUnitPriceCurrency.Lsl,
            "mad" => PlanListOverageChargesResponseTierUnitPriceCurrency.Mad,
            "mdl" => PlanListOverageChargesResponseTierUnitPriceCurrency.Mdl,
            "mga" => PlanListOverageChargesResponseTierUnitPriceCurrency.Mga,
            "mkd" => PlanListOverageChargesResponseTierUnitPriceCurrency.Mkd,
            "mmk" => PlanListOverageChargesResponseTierUnitPriceCurrency.Mmk,
            "mnt" => PlanListOverageChargesResponseTierUnitPriceCurrency.Mnt,
            "mop" => PlanListOverageChargesResponseTierUnitPriceCurrency.Mop,
            "mro" => PlanListOverageChargesResponseTierUnitPriceCurrency.Mro,
            "mvr" => PlanListOverageChargesResponseTierUnitPriceCurrency.Mvr,
            "mwk" => PlanListOverageChargesResponseTierUnitPriceCurrency.Mwk,
            "mxn" => PlanListOverageChargesResponseTierUnitPriceCurrency.Mxn,
            "myr" => PlanListOverageChargesResponseTierUnitPriceCurrency.Myr,
            "mzn" => PlanListOverageChargesResponseTierUnitPriceCurrency.Mzn,
            "nad" => PlanListOverageChargesResponseTierUnitPriceCurrency.Nad,
            "ngn" => PlanListOverageChargesResponseTierUnitPriceCurrency.Ngn,
            "nok" => PlanListOverageChargesResponseTierUnitPriceCurrency.Nok,
            "npr" => PlanListOverageChargesResponseTierUnitPriceCurrency.Npr,
            "nzd" => PlanListOverageChargesResponseTierUnitPriceCurrency.Nzd,
            "pgk" => PlanListOverageChargesResponseTierUnitPriceCurrency.Pgk,
            "php" => PlanListOverageChargesResponseTierUnitPriceCurrency.Php,
            "pkr" => PlanListOverageChargesResponseTierUnitPriceCurrency.Pkr,
            "pln" => PlanListOverageChargesResponseTierUnitPriceCurrency.Pln,
            "qar" => PlanListOverageChargesResponseTierUnitPriceCurrency.Qar,
            "ron" => PlanListOverageChargesResponseTierUnitPriceCurrency.Ron,
            "rsd" => PlanListOverageChargesResponseTierUnitPriceCurrency.Rsd,
            "rub" => PlanListOverageChargesResponseTierUnitPriceCurrency.Rub,
            "rwf" => PlanListOverageChargesResponseTierUnitPriceCurrency.Rwf,
            "sar" => PlanListOverageChargesResponseTierUnitPriceCurrency.Sar,
            "sbd" => PlanListOverageChargesResponseTierUnitPriceCurrency.Sbd,
            "scr" => PlanListOverageChargesResponseTierUnitPriceCurrency.Scr,
            "sek" => PlanListOverageChargesResponseTierUnitPriceCurrency.Sek,
            "sgd" => PlanListOverageChargesResponseTierUnitPriceCurrency.Sgd,
            "sle" => PlanListOverageChargesResponseTierUnitPriceCurrency.Sle,
            "sll" => PlanListOverageChargesResponseTierUnitPriceCurrency.Sll,
            "sos" => PlanListOverageChargesResponseTierUnitPriceCurrency.Sos,
            "szl" => PlanListOverageChargesResponseTierUnitPriceCurrency.Szl,
            "thb" => PlanListOverageChargesResponseTierUnitPriceCurrency.Thb,
            "tjs" => PlanListOverageChargesResponseTierUnitPriceCurrency.Tjs,
            "top" => PlanListOverageChargesResponseTierUnitPriceCurrency.Top,
            "try" => PlanListOverageChargesResponseTierUnitPriceCurrency.Try,
            "ttd" => PlanListOverageChargesResponseTierUnitPriceCurrency.Ttd,
            "tzs" => PlanListOverageChargesResponseTierUnitPriceCurrency.Tzs,
            "uah" => PlanListOverageChargesResponseTierUnitPriceCurrency.Uah,
            "uzs" => PlanListOverageChargesResponseTierUnitPriceCurrency.Uzs,
            "vnd" => PlanListOverageChargesResponseTierUnitPriceCurrency.Vnd,
            "vuv" => PlanListOverageChargesResponseTierUnitPriceCurrency.Vuv,
            "wst" => PlanListOverageChargesResponseTierUnitPriceCurrency.Wst,
            "xaf" => PlanListOverageChargesResponseTierUnitPriceCurrency.Xaf,
            "xcd" => PlanListOverageChargesResponseTierUnitPriceCurrency.Xcd,
            "yer" => PlanListOverageChargesResponseTierUnitPriceCurrency.Yer,
            "zar" => PlanListOverageChargesResponseTierUnitPriceCurrency.Zar,
            "zmw" => PlanListOverageChargesResponseTierUnitPriceCurrency.Zmw,
            "clp" => PlanListOverageChargesResponseTierUnitPriceCurrency.Clp,
            "djf" => PlanListOverageChargesResponseTierUnitPriceCurrency.Djf,
            "gnf" => PlanListOverageChargesResponseTierUnitPriceCurrency.Gnf,
            "ugx" => PlanListOverageChargesResponseTierUnitPriceCurrency.Ugx,
            "pyg" => PlanListOverageChargesResponseTierUnitPriceCurrency.Pyg,
            "xof" => PlanListOverageChargesResponseTierUnitPriceCurrency.Xof,
            "xpf" => PlanListOverageChargesResponseTierUnitPriceCurrency.Xpf,
            _ => (PlanListOverageChargesResponseTierUnitPriceCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PlanListOverageChargesResponseTierUnitPriceCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PlanListOverageChargesResponseTierUnitPriceCurrency.Usd => "usd",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Aed => "aed",
                PlanListOverageChargesResponseTierUnitPriceCurrency.All => "all",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Amd => "amd",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Ang => "ang",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Aud => "aud",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Awg => "awg",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Azn => "azn",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Bam => "bam",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Bbd => "bbd",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Bdt => "bdt",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Bgn => "bgn",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Bif => "bif",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Bmd => "bmd",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Bnd => "bnd",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Bsd => "bsd",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Bwp => "bwp",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Byn => "byn",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Bzd => "bzd",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Brl => "brl",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Cad => "cad",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Cdf => "cdf",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Chf => "chf",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Cny => "cny",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Czk => "czk",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Dkk => "dkk",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Dop => "dop",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Dzd => "dzd",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Egp => "egp",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Etb => "etb",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Eur => "eur",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Fjd => "fjd",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Gbp => "gbp",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Gel => "gel",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Gip => "gip",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Gmd => "gmd",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Gyd => "gyd",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Hkd => "hkd",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Hrk => "hrk",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Htg => "htg",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Idr => "idr",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Ils => "ils",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Inr => "inr",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Isk => "isk",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Jmd => "jmd",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Jpy => "jpy",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Kes => "kes",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Kgs => "kgs",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Khr => "khr",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Kmf => "kmf",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Krw => "krw",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Kyd => "kyd",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Kzt => "kzt",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Lbp => "lbp",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Lkr => "lkr",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Lrd => "lrd",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Lsl => "lsl",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Mad => "mad",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Mdl => "mdl",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Mga => "mga",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Mkd => "mkd",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Mmk => "mmk",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Mnt => "mnt",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Mop => "mop",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Mro => "mro",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Mvr => "mvr",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Mwk => "mwk",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Mxn => "mxn",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Myr => "myr",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Mzn => "mzn",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Nad => "nad",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Ngn => "ngn",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Nok => "nok",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Npr => "npr",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Nzd => "nzd",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Pgk => "pgk",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Php => "php",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Pkr => "pkr",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Pln => "pln",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Qar => "qar",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Ron => "ron",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Rsd => "rsd",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Rub => "rub",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Rwf => "rwf",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Sar => "sar",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Sbd => "sbd",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Scr => "scr",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Sek => "sek",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Sgd => "sgd",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Sle => "sle",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Sll => "sll",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Sos => "sos",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Szl => "szl",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Thb => "thb",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Tjs => "tjs",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Top => "top",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Try => "try",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Ttd => "ttd",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Tzs => "tzs",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Uah => "uah",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Uzs => "uzs",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Vnd => "vnd",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Vuv => "vuv",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Wst => "wst",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Xaf => "xaf",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Xcd => "xcd",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Yer => "yer",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Zar => "zar",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Zmw => "zmw",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Clp => "clp",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Djf => "djf",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Gnf => "gnf",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Ugx => "ugx",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Pyg => "pyg",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Xof => "xof",
                PlanListOverageChargesResponseTierUnitPriceCurrency.Xpf => "xpf",
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
[JsonConverter(typeof(PlanListOverageChargesResponseTiersModeConverter))]
public enum PlanListOverageChargesResponseTiersMode
{
    Volume,
    Graduated,
}

sealed class PlanListOverageChargesResponseTiersModeConverter
    : JsonConverter<PlanListOverageChargesResponseTiersMode>
{
    public override PlanListOverageChargesResponseTiersMode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "VOLUME" => PlanListOverageChargesResponseTiersMode.Volume,
            "GRADUATED" => PlanListOverageChargesResponseTiersMode.Graduated,
            _ => (PlanListOverageChargesResponseTiersMode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PlanListOverageChargesResponseTiersMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PlanListOverageChargesResponseTiersMode.Volume => "VOLUME",
                PlanListOverageChargesResponseTiersMode.Graduated => "GRADUATED",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
