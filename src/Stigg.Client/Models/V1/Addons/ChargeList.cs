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
/// Response list object
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ChargeList, ChargeListFromRaw>))]
public sealed record class ChargeList : JsonModel
{
    public required IReadOnlyList<ChargeListData> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ChargeListData>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ChargeListData>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Pagination metadata including cursors for navigating through results
    /// </summary>
    public required Pagination Pagination
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Pagination>("pagination");
        }
        init { this._rawData.Set("pagination", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        this.Pagination.Validate();
    }

    public ChargeList() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargeList(ChargeList chargeList)
        : base(chargeList) { }
#pragma warning restore CS8618

    public ChargeList(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargeList(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargeListFromRaw.FromRawUnchecked"/>
    public static ChargeList FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChargeListFromRaw : IFromRawJson<ChargeList>
{
    /// <inheritdoc/>
    public ChargeList FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ChargeList.FromRawUnchecked(rawData);
}

/// <summary>
/// A single pricing row on a plan or addon. Each charge encodes one (billingPeriod,
/// billingModel, billingCadence, billingCountryCode) combination. Plans and addons
/// own many of these — one per currency / billing period / feature.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ChargeListData, ChargeListDataFromRaw>))]
public sealed record class ChargeListData : JsonModel
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
    public required ApiEnum<string, ChargeListDataBillingCadence> BillingCadence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ChargeListDataBillingCadence>>(
                "billingCadence"
            );
        }
        init { this._rawData.Set("billingCadence", value); }
    }

    /// <summary>
    /// The billing model (FLAT_FEE, PER_UNIT, USAGE_BASED, CREDIT_BASED, MINIMUM_SPEND)
    /// </summary>
    public required ApiEnum<string, ChargeListDataBillingModel> BillingModel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ChargeListDataBillingModel>>(
                "billingModel"
            );
        }
        init { this._rawData.Set("billingModel", value); }
    }

    /// <summary>
    /// The billing period (MONTHLY or ANNUALLY)
    /// </summary>
    public required ApiEnum<string, ChargeListDataBillingPeriod> BillingPeriod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ChargeListDataBillingPeriod>>(
                "billingPeriod"
            );
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
    public ApiEnum<string, ChargeListDataCreditGrantCadence>? CreditGrantCadence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, ChargeListDataCreditGrantCadence>
            >("creditGrantCadence");
        }
        init { this._rawData.Set("creditGrantCadence", value); }
    }

    /// <summary>
    /// Credit rate configuration for credit-based pricing
    /// </summary>
    public ChargeListDataCreditRate? CreditRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChargeListDataCreditRate>("creditRate");
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
    public ChargeListDataPrice? Price
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChargeListDataPrice>("price");
        }
        init { this._rawData.Set("price", value); }
    }

    /// <summary>
    /// Tiered pricing rows when the charge is tiered
    /// </summary>
    public IReadOnlyList<ChargeListDataTier>? Tiers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ChargeListDataTier>>("tiers");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ChargeListDataTier>?>(
                "tiers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Tiered pricing mode (VOLUME or GRADUATED) when the charge is tiered
    /// </summary>
    public ApiEnum<string, ChargeListDataTiersMode>? TiersMode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ChargeListDataTiersMode>>(
                "tiersMode"
            );
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

    public ChargeListData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargeListData(ChargeListData chargeListData)
        : base(chargeListData) { }
#pragma warning restore CS8618

    public ChargeListData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargeListData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargeListDataFromRaw.FromRawUnchecked"/>
    public static ChargeListData FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChargeListDataFromRaw : IFromRawJson<ChargeListData>
{
    /// <inheritdoc/>
    public ChargeListData FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ChargeListData.FromRawUnchecked(rawData);
}

/// <summary>
/// The billing cadence (RECURRING or ONE_OFF)
/// </summary>
[JsonConverter(typeof(ChargeListDataBillingCadenceConverter))]
public enum ChargeListDataBillingCadence
{
    Recurring,
    OneOff,
}

sealed class ChargeListDataBillingCadenceConverter : JsonConverter<ChargeListDataBillingCadence>
{
    public override ChargeListDataBillingCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "RECURRING" => ChargeListDataBillingCadence.Recurring,
            "ONE_OFF" => ChargeListDataBillingCadence.OneOff,
            _ => (ChargeListDataBillingCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChargeListDataBillingCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChargeListDataBillingCadence.Recurring => "RECURRING",
                ChargeListDataBillingCadence.OneOff => "ONE_OFF",
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
[JsonConverter(typeof(ChargeListDataBillingModelConverter))]
public enum ChargeListDataBillingModel
{
    FlatFee,
    MinimumSpend,
    PerUnit,
    UsageBased,
    CreditBased,
}

sealed class ChargeListDataBillingModelConverter : JsonConverter<ChargeListDataBillingModel>
{
    public override ChargeListDataBillingModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FLAT_FEE" => ChargeListDataBillingModel.FlatFee,
            "MINIMUM_SPEND" => ChargeListDataBillingModel.MinimumSpend,
            "PER_UNIT" => ChargeListDataBillingModel.PerUnit,
            "USAGE_BASED" => ChargeListDataBillingModel.UsageBased,
            "CREDIT_BASED" => ChargeListDataBillingModel.CreditBased,
            _ => (ChargeListDataBillingModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChargeListDataBillingModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChargeListDataBillingModel.FlatFee => "FLAT_FEE",
                ChargeListDataBillingModel.MinimumSpend => "MINIMUM_SPEND",
                ChargeListDataBillingModel.PerUnit => "PER_UNIT",
                ChargeListDataBillingModel.UsageBased => "USAGE_BASED",
                ChargeListDataBillingModel.CreditBased => "CREDIT_BASED",
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
[JsonConverter(typeof(ChargeListDataBillingPeriodConverter))]
public enum ChargeListDataBillingPeriod
{
    Monthly,
    Annually,
}

sealed class ChargeListDataBillingPeriodConverter : JsonConverter<ChargeListDataBillingPeriod>
{
    public override ChargeListDataBillingPeriod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "MONTHLY" => ChargeListDataBillingPeriod.Monthly,
            "ANNUALLY" => ChargeListDataBillingPeriod.Annually,
            _ => (ChargeListDataBillingPeriod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChargeListDataBillingPeriod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChargeListDataBillingPeriod.Monthly => "MONTHLY",
                ChargeListDataBillingPeriod.Annually => "ANNUALLY",
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
[JsonConverter(typeof(ChargeListDataCreditGrantCadenceConverter))]
public enum ChargeListDataCreditGrantCadence
{
    BeginningOfBillingPeriod,
    Monthly,
}

sealed class ChargeListDataCreditGrantCadenceConverter
    : JsonConverter<ChargeListDataCreditGrantCadence>
{
    public override ChargeListDataCreditGrantCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "BEGINNING_OF_BILLING_PERIOD" =>
                ChargeListDataCreditGrantCadence.BeginningOfBillingPeriod,
            "MONTHLY" => ChargeListDataCreditGrantCadence.Monthly,
            _ => (ChargeListDataCreditGrantCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChargeListDataCreditGrantCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChargeListDataCreditGrantCadence.BeginningOfBillingPeriod =>
                    "BEGINNING_OF_BILLING_PERIOD",
                ChargeListDataCreditGrantCadence.Monthly => "MONTHLY",
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
    typeof(JsonModelConverter<ChargeListDataCreditRate, ChargeListDataCreditRateFromRaw>)
)]
public sealed record class ChargeListDataCreditRate : JsonModel
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

    public ChargeListDataCreditRate() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargeListDataCreditRate(ChargeListDataCreditRate chargeListDataCreditRate)
        : base(chargeListDataCreditRate) { }
#pragma warning restore CS8618

    public ChargeListDataCreditRate(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargeListDataCreditRate(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargeListDataCreditRateFromRaw.FromRawUnchecked"/>
    public static ChargeListDataCreditRate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChargeListDataCreditRateFromRaw : IFromRawJson<ChargeListDataCreditRate>
{
    /// <inheritdoc/>
    public ChargeListDataCreditRate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChargeListDataCreditRate.FromRawUnchecked(rawData);
}

/// <summary>
/// The flat price amount and currency, when applicable
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ChargeListDataPrice, ChargeListDataPriceFromRaw>))]
public sealed record class ChargeListDataPrice : JsonModel
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
    public required ApiEnum<string, ChargeListDataPriceCurrency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ChargeListDataPriceCurrency>>(
                "currency"
            );
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        this.Currency.Validate();
    }

    public ChargeListDataPrice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargeListDataPrice(ChargeListDataPrice chargeListDataPrice)
        : base(chargeListDataPrice) { }
#pragma warning restore CS8618

    public ChargeListDataPrice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargeListDataPrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargeListDataPriceFromRaw.FromRawUnchecked"/>
    public static ChargeListDataPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChargeListDataPriceFromRaw : IFromRawJson<ChargeListDataPrice>
{
    /// <inheritdoc/>
    public ChargeListDataPrice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ChargeListDataPrice.FromRawUnchecked(rawData);
}

/// <summary>
/// ISO 4217 currency code
/// </summary>
[JsonConverter(typeof(ChargeListDataPriceCurrencyConverter))]
public enum ChargeListDataPriceCurrency
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

sealed class ChargeListDataPriceCurrencyConverter : JsonConverter<ChargeListDataPriceCurrency>
{
    public override ChargeListDataPriceCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => ChargeListDataPriceCurrency.Usd,
            "aed" => ChargeListDataPriceCurrency.Aed,
            "all" => ChargeListDataPriceCurrency.All,
            "amd" => ChargeListDataPriceCurrency.Amd,
            "ang" => ChargeListDataPriceCurrency.Ang,
            "aud" => ChargeListDataPriceCurrency.Aud,
            "awg" => ChargeListDataPriceCurrency.Awg,
            "azn" => ChargeListDataPriceCurrency.Azn,
            "bam" => ChargeListDataPriceCurrency.Bam,
            "bbd" => ChargeListDataPriceCurrency.Bbd,
            "bdt" => ChargeListDataPriceCurrency.Bdt,
            "bgn" => ChargeListDataPriceCurrency.Bgn,
            "bif" => ChargeListDataPriceCurrency.Bif,
            "bmd" => ChargeListDataPriceCurrency.Bmd,
            "bnd" => ChargeListDataPriceCurrency.Bnd,
            "bsd" => ChargeListDataPriceCurrency.Bsd,
            "bwp" => ChargeListDataPriceCurrency.Bwp,
            "byn" => ChargeListDataPriceCurrency.Byn,
            "bzd" => ChargeListDataPriceCurrency.Bzd,
            "brl" => ChargeListDataPriceCurrency.Brl,
            "cad" => ChargeListDataPriceCurrency.Cad,
            "cdf" => ChargeListDataPriceCurrency.Cdf,
            "chf" => ChargeListDataPriceCurrency.Chf,
            "cny" => ChargeListDataPriceCurrency.Cny,
            "czk" => ChargeListDataPriceCurrency.Czk,
            "dkk" => ChargeListDataPriceCurrency.Dkk,
            "dop" => ChargeListDataPriceCurrency.Dop,
            "dzd" => ChargeListDataPriceCurrency.Dzd,
            "egp" => ChargeListDataPriceCurrency.Egp,
            "etb" => ChargeListDataPriceCurrency.Etb,
            "eur" => ChargeListDataPriceCurrency.Eur,
            "fjd" => ChargeListDataPriceCurrency.Fjd,
            "gbp" => ChargeListDataPriceCurrency.Gbp,
            "gel" => ChargeListDataPriceCurrency.Gel,
            "gip" => ChargeListDataPriceCurrency.Gip,
            "gmd" => ChargeListDataPriceCurrency.Gmd,
            "gyd" => ChargeListDataPriceCurrency.Gyd,
            "hkd" => ChargeListDataPriceCurrency.Hkd,
            "hrk" => ChargeListDataPriceCurrency.Hrk,
            "htg" => ChargeListDataPriceCurrency.Htg,
            "idr" => ChargeListDataPriceCurrency.Idr,
            "ils" => ChargeListDataPriceCurrency.Ils,
            "inr" => ChargeListDataPriceCurrency.Inr,
            "isk" => ChargeListDataPriceCurrency.Isk,
            "jmd" => ChargeListDataPriceCurrency.Jmd,
            "jpy" => ChargeListDataPriceCurrency.Jpy,
            "kes" => ChargeListDataPriceCurrency.Kes,
            "kgs" => ChargeListDataPriceCurrency.Kgs,
            "khr" => ChargeListDataPriceCurrency.Khr,
            "kmf" => ChargeListDataPriceCurrency.Kmf,
            "krw" => ChargeListDataPriceCurrency.Krw,
            "kyd" => ChargeListDataPriceCurrency.Kyd,
            "kzt" => ChargeListDataPriceCurrency.Kzt,
            "lbp" => ChargeListDataPriceCurrency.Lbp,
            "lkr" => ChargeListDataPriceCurrency.Lkr,
            "lrd" => ChargeListDataPriceCurrency.Lrd,
            "lsl" => ChargeListDataPriceCurrency.Lsl,
            "mad" => ChargeListDataPriceCurrency.Mad,
            "mdl" => ChargeListDataPriceCurrency.Mdl,
            "mga" => ChargeListDataPriceCurrency.Mga,
            "mkd" => ChargeListDataPriceCurrency.Mkd,
            "mmk" => ChargeListDataPriceCurrency.Mmk,
            "mnt" => ChargeListDataPriceCurrency.Mnt,
            "mop" => ChargeListDataPriceCurrency.Mop,
            "mro" => ChargeListDataPriceCurrency.Mro,
            "mvr" => ChargeListDataPriceCurrency.Mvr,
            "mwk" => ChargeListDataPriceCurrency.Mwk,
            "mxn" => ChargeListDataPriceCurrency.Mxn,
            "myr" => ChargeListDataPriceCurrency.Myr,
            "mzn" => ChargeListDataPriceCurrency.Mzn,
            "nad" => ChargeListDataPriceCurrency.Nad,
            "ngn" => ChargeListDataPriceCurrency.Ngn,
            "nok" => ChargeListDataPriceCurrency.Nok,
            "npr" => ChargeListDataPriceCurrency.Npr,
            "nzd" => ChargeListDataPriceCurrency.Nzd,
            "pgk" => ChargeListDataPriceCurrency.Pgk,
            "php" => ChargeListDataPriceCurrency.Php,
            "pkr" => ChargeListDataPriceCurrency.Pkr,
            "pln" => ChargeListDataPriceCurrency.Pln,
            "qar" => ChargeListDataPriceCurrency.Qar,
            "ron" => ChargeListDataPriceCurrency.Ron,
            "rsd" => ChargeListDataPriceCurrency.Rsd,
            "rub" => ChargeListDataPriceCurrency.Rub,
            "rwf" => ChargeListDataPriceCurrency.Rwf,
            "sar" => ChargeListDataPriceCurrency.Sar,
            "sbd" => ChargeListDataPriceCurrency.Sbd,
            "scr" => ChargeListDataPriceCurrency.Scr,
            "sek" => ChargeListDataPriceCurrency.Sek,
            "sgd" => ChargeListDataPriceCurrency.Sgd,
            "sle" => ChargeListDataPriceCurrency.Sle,
            "sll" => ChargeListDataPriceCurrency.Sll,
            "sos" => ChargeListDataPriceCurrency.Sos,
            "szl" => ChargeListDataPriceCurrency.Szl,
            "thb" => ChargeListDataPriceCurrency.Thb,
            "tjs" => ChargeListDataPriceCurrency.Tjs,
            "top" => ChargeListDataPriceCurrency.Top,
            "try" => ChargeListDataPriceCurrency.Try,
            "ttd" => ChargeListDataPriceCurrency.Ttd,
            "tzs" => ChargeListDataPriceCurrency.Tzs,
            "uah" => ChargeListDataPriceCurrency.Uah,
            "uzs" => ChargeListDataPriceCurrency.Uzs,
            "vnd" => ChargeListDataPriceCurrency.Vnd,
            "vuv" => ChargeListDataPriceCurrency.Vuv,
            "wst" => ChargeListDataPriceCurrency.Wst,
            "xaf" => ChargeListDataPriceCurrency.Xaf,
            "xcd" => ChargeListDataPriceCurrency.Xcd,
            "yer" => ChargeListDataPriceCurrency.Yer,
            "zar" => ChargeListDataPriceCurrency.Zar,
            "zmw" => ChargeListDataPriceCurrency.Zmw,
            "clp" => ChargeListDataPriceCurrency.Clp,
            "djf" => ChargeListDataPriceCurrency.Djf,
            "gnf" => ChargeListDataPriceCurrency.Gnf,
            "ugx" => ChargeListDataPriceCurrency.Ugx,
            "pyg" => ChargeListDataPriceCurrency.Pyg,
            "xof" => ChargeListDataPriceCurrency.Xof,
            "xpf" => ChargeListDataPriceCurrency.Xpf,
            _ => (ChargeListDataPriceCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChargeListDataPriceCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChargeListDataPriceCurrency.Usd => "usd",
                ChargeListDataPriceCurrency.Aed => "aed",
                ChargeListDataPriceCurrency.All => "all",
                ChargeListDataPriceCurrency.Amd => "amd",
                ChargeListDataPriceCurrency.Ang => "ang",
                ChargeListDataPriceCurrency.Aud => "aud",
                ChargeListDataPriceCurrency.Awg => "awg",
                ChargeListDataPriceCurrency.Azn => "azn",
                ChargeListDataPriceCurrency.Bam => "bam",
                ChargeListDataPriceCurrency.Bbd => "bbd",
                ChargeListDataPriceCurrency.Bdt => "bdt",
                ChargeListDataPriceCurrency.Bgn => "bgn",
                ChargeListDataPriceCurrency.Bif => "bif",
                ChargeListDataPriceCurrency.Bmd => "bmd",
                ChargeListDataPriceCurrency.Bnd => "bnd",
                ChargeListDataPriceCurrency.Bsd => "bsd",
                ChargeListDataPriceCurrency.Bwp => "bwp",
                ChargeListDataPriceCurrency.Byn => "byn",
                ChargeListDataPriceCurrency.Bzd => "bzd",
                ChargeListDataPriceCurrency.Brl => "brl",
                ChargeListDataPriceCurrency.Cad => "cad",
                ChargeListDataPriceCurrency.Cdf => "cdf",
                ChargeListDataPriceCurrency.Chf => "chf",
                ChargeListDataPriceCurrency.Cny => "cny",
                ChargeListDataPriceCurrency.Czk => "czk",
                ChargeListDataPriceCurrency.Dkk => "dkk",
                ChargeListDataPriceCurrency.Dop => "dop",
                ChargeListDataPriceCurrency.Dzd => "dzd",
                ChargeListDataPriceCurrency.Egp => "egp",
                ChargeListDataPriceCurrency.Etb => "etb",
                ChargeListDataPriceCurrency.Eur => "eur",
                ChargeListDataPriceCurrency.Fjd => "fjd",
                ChargeListDataPriceCurrency.Gbp => "gbp",
                ChargeListDataPriceCurrency.Gel => "gel",
                ChargeListDataPriceCurrency.Gip => "gip",
                ChargeListDataPriceCurrency.Gmd => "gmd",
                ChargeListDataPriceCurrency.Gyd => "gyd",
                ChargeListDataPriceCurrency.Hkd => "hkd",
                ChargeListDataPriceCurrency.Hrk => "hrk",
                ChargeListDataPriceCurrency.Htg => "htg",
                ChargeListDataPriceCurrency.Idr => "idr",
                ChargeListDataPriceCurrency.Ils => "ils",
                ChargeListDataPriceCurrency.Inr => "inr",
                ChargeListDataPriceCurrency.Isk => "isk",
                ChargeListDataPriceCurrency.Jmd => "jmd",
                ChargeListDataPriceCurrency.Jpy => "jpy",
                ChargeListDataPriceCurrency.Kes => "kes",
                ChargeListDataPriceCurrency.Kgs => "kgs",
                ChargeListDataPriceCurrency.Khr => "khr",
                ChargeListDataPriceCurrency.Kmf => "kmf",
                ChargeListDataPriceCurrency.Krw => "krw",
                ChargeListDataPriceCurrency.Kyd => "kyd",
                ChargeListDataPriceCurrency.Kzt => "kzt",
                ChargeListDataPriceCurrency.Lbp => "lbp",
                ChargeListDataPriceCurrency.Lkr => "lkr",
                ChargeListDataPriceCurrency.Lrd => "lrd",
                ChargeListDataPriceCurrency.Lsl => "lsl",
                ChargeListDataPriceCurrency.Mad => "mad",
                ChargeListDataPriceCurrency.Mdl => "mdl",
                ChargeListDataPriceCurrency.Mga => "mga",
                ChargeListDataPriceCurrency.Mkd => "mkd",
                ChargeListDataPriceCurrency.Mmk => "mmk",
                ChargeListDataPriceCurrency.Mnt => "mnt",
                ChargeListDataPriceCurrency.Mop => "mop",
                ChargeListDataPriceCurrency.Mro => "mro",
                ChargeListDataPriceCurrency.Mvr => "mvr",
                ChargeListDataPriceCurrency.Mwk => "mwk",
                ChargeListDataPriceCurrency.Mxn => "mxn",
                ChargeListDataPriceCurrency.Myr => "myr",
                ChargeListDataPriceCurrency.Mzn => "mzn",
                ChargeListDataPriceCurrency.Nad => "nad",
                ChargeListDataPriceCurrency.Ngn => "ngn",
                ChargeListDataPriceCurrency.Nok => "nok",
                ChargeListDataPriceCurrency.Npr => "npr",
                ChargeListDataPriceCurrency.Nzd => "nzd",
                ChargeListDataPriceCurrency.Pgk => "pgk",
                ChargeListDataPriceCurrency.Php => "php",
                ChargeListDataPriceCurrency.Pkr => "pkr",
                ChargeListDataPriceCurrency.Pln => "pln",
                ChargeListDataPriceCurrency.Qar => "qar",
                ChargeListDataPriceCurrency.Ron => "ron",
                ChargeListDataPriceCurrency.Rsd => "rsd",
                ChargeListDataPriceCurrency.Rub => "rub",
                ChargeListDataPriceCurrency.Rwf => "rwf",
                ChargeListDataPriceCurrency.Sar => "sar",
                ChargeListDataPriceCurrency.Sbd => "sbd",
                ChargeListDataPriceCurrency.Scr => "scr",
                ChargeListDataPriceCurrency.Sek => "sek",
                ChargeListDataPriceCurrency.Sgd => "sgd",
                ChargeListDataPriceCurrency.Sle => "sle",
                ChargeListDataPriceCurrency.Sll => "sll",
                ChargeListDataPriceCurrency.Sos => "sos",
                ChargeListDataPriceCurrency.Szl => "szl",
                ChargeListDataPriceCurrency.Thb => "thb",
                ChargeListDataPriceCurrency.Tjs => "tjs",
                ChargeListDataPriceCurrency.Top => "top",
                ChargeListDataPriceCurrency.Try => "try",
                ChargeListDataPriceCurrency.Ttd => "ttd",
                ChargeListDataPriceCurrency.Tzs => "tzs",
                ChargeListDataPriceCurrency.Uah => "uah",
                ChargeListDataPriceCurrency.Uzs => "uzs",
                ChargeListDataPriceCurrency.Vnd => "vnd",
                ChargeListDataPriceCurrency.Vuv => "vuv",
                ChargeListDataPriceCurrency.Wst => "wst",
                ChargeListDataPriceCurrency.Xaf => "xaf",
                ChargeListDataPriceCurrency.Xcd => "xcd",
                ChargeListDataPriceCurrency.Yer => "yer",
                ChargeListDataPriceCurrency.Zar => "zar",
                ChargeListDataPriceCurrency.Zmw => "zmw",
                ChargeListDataPriceCurrency.Clp => "clp",
                ChargeListDataPriceCurrency.Djf => "djf",
                ChargeListDataPriceCurrency.Gnf => "gnf",
                ChargeListDataPriceCurrency.Ugx => "ugx",
                ChargeListDataPriceCurrency.Pyg => "pyg",
                ChargeListDataPriceCurrency.Xof => "xof",
                ChargeListDataPriceCurrency.Xpf => "xpf",
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
[JsonConverter(typeof(JsonModelConverter<ChargeListDataTier, ChargeListDataTierFromRaw>))]
public sealed record class ChargeListDataTier : JsonModel
{
    /// <summary>
    /// Flat price for this tier
    /// </summary>
    public ChargeListDataTierFlatPrice? FlatPrice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChargeListDataTierFlatPrice>("flatPrice");
        }
        init { this._rawData.Set("flatPrice", value); }
    }

    /// <summary>
    /// Per-unit price in this tier
    /// </summary>
    public ChargeListDataTierUnitPrice? UnitPrice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChargeListDataTierUnitPrice>("unitPrice");
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

    public ChargeListDataTier() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargeListDataTier(ChargeListDataTier chargeListDataTier)
        : base(chargeListDataTier) { }
#pragma warning restore CS8618

    public ChargeListDataTier(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargeListDataTier(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargeListDataTierFromRaw.FromRawUnchecked"/>
    public static ChargeListDataTier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChargeListDataTierFromRaw : IFromRawJson<ChargeListDataTier>
{
    /// <inheritdoc/>
    public ChargeListDataTier FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ChargeListDataTier.FromRawUnchecked(rawData);
}

/// <summary>
/// Flat price for this tier
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ChargeListDataTierFlatPrice, ChargeListDataTierFlatPriceFromRaw>)
)]
public sealed record class ChargeListDataTierFlatPrice : JsonModel
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
    public required ApiEnum<string, ChargeListDataTierFlatPriceCurrency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ChargeListDataTierFlatPriceCurrency>
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

    public ChargeListDataTierFlatPrice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargeListDataTierFlatPrice(ChargeListDataTierFlatPrice chargeListDataTierFlatPrice)
        : base(chargeListDataTierFlatPrice) { }
#pragma warning restore CS8618

    public ChargeListDataTierFlatPrice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargeListDataTierFlatPrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargeListDataTierFlatPriceFromRaw.FromRawUnchecked"/>
    public static ChargeListDataTierFlatPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChargeListDataTierFlatPriceFromRaw : IFromRawJson<ChargeListDataTierFlatPrice>
{
    /// <inheritdoc/>
    public ChargeListDataTierFlatPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChargeListDataTierFlatPrice.FromRawUnchecked(rawData);
}

/// <summary>
/// ISO 4217 currency code
/// </summary>
[JsonConverter(typeof(ChargeListDataTierFlatPriceCurrencyConverter))]
public enum ChargeListDataTierFlatPriceCurrency
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

sealed class ChargeListDataTierFlatPriceCurrencyConverter
    : JsonConverter<ChargeListDataTierFlatPriceCurrency>
{
    public override ChargeListDataTierFlatPriceCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => ChargeListDataTierFlatPriceCurrency.Usd,
            "aed" => ChargeListDataTierFlatPriceCurrency.Aed,
            "all" => ChargeListDataTierFlatPriceCurrency.All,
            "amd" => ChargeListDataTierFlatPriceCurrency.Amd,
            "ang" => ChargeListDataTierFlatPriceCurrency.Ang,
            "aud" => ChargeListDataTierFlatPriceCurrency.Aud,
            "awg" => ChargeListDataTierFlatPriceCurrency.Awg,
            "azn" => ChargeListDataTierFlatPriceCurrency.Azn,
            "bam" => ChargeListDataTierFlatPriceCurrency.Bam,
            "bbd" => ChargeListDataTierFlatPriceCurrency.Bbd,
            "bdt" => ChargeListDataTierFlatPriceCurrency.Bdt,
            "bgn" => ChargeListDataTierFlatPriceCurrency.Bgn,
            "bif" => ChargeListDataTierFlatPriceCurrency.Bif,
            "bmd" => ChargeListDataTierFlatPriceCurrency.Bmd,
            "bnd" => ChargeListDataTierFlatPriceCurrency.Bnd,
            "bsd" => ChargeListDataTierFlatPriceCurrency.Bsd,
            "bwp" => ChargeListDataTierFlatPriceCurrency.Bwp,
            "byn" => ChargeListDataTierFlatPriceCurrency.Byn,
            "bzd" => ChargeListDataTierFlatPriceCurrency.Bzd,
            "brl" => ChargeListDataTierFlatPriceCurrency.Brl,
            "cad" => ChargeListDataTierFlatPriceCurrency.Cad,
            "cdf" => ChargeListDataTierFlatPriceCurrency.Cdf,
            "chf" => ChargeListDataTierFlatPriceCurrency.Chf,
            "cny" => ChargeListDataTierFlatPriceCurrency.Cny,
            "czk" => ChargeListDataTierFlatPriceCurrency.Czk,
            "dkk" => ChargeListDataTierFlatPriceCurrency.Dkk,
            "dop" => ChargeListDataTierFlatPriceCurrency.Dop,
            "dzd" => ChargeListDataTierFlatPriceCurrency.Dzd,
            "egp" => ChargeListDataTierFlatPriceCurrency.Egp,
            "etb" => ChargeListDataTierFlatPriceCurrency.Etb,
            "eur" => ChargeListDataTierFlatPriceCurrency.Eur,
            "fjd" => ChargeListDataTierFlatPriceCurrency.Fjd,
            "gbp" => ChargeListDataTierFlatPriceCurrency.Gbp,
            "gel" => ChargeListDataTierFlatPriceCurrency.Gel,
            "gip" => ChargeListDataTierFlatPriceCurrency.Gip,
            "gmd" => ChargeListDataTierFlatPriceCurrency.Gmd,
            "gyd" => ChargeListDataTierFlatPriceCurrency.Gyd,
            "hkd" => ChargeListDataTierFlatPriceCurrency.Hkd,
            "hrk" => ChargeListDataTierFlatPriceCurrency.Hrk,
            "htg" => ChargeListDataTierFlatPriceCurrency.Htg,
            "idr" => ChargeListDataTierFlatPriceCurrency.Idr,
            "ils" => ChargeListDataTierFlatPriceCurrency.Ils,
            "inr" => ChargeListDataTierFlatPriceCurrency.Inr,
            "isk" => ChargeListDataTierFlatPriceCurrency.Isk,
            "jmd" => ChargeListDataTierFlatPriceCurrency.Jmd,
            "jpy" => ChargeListDataTierFlatPriceCurrency.Jpy,
            "kes" => ChargeListDataTierFlatPriceCurrency.Kes,
            "kgs" => ChargeListDataTierFlatPriceCurrency.Kgs,
            "khr" => ChargeListDataTierFlatPriceCurrency.Khr,
            "kmf" => ChargeListDataTierFlatPriceCurrency.Kmf,
            "krw" => ChargeListDataTierFlatPriceCurrency.Krw,
            "kyd" => ChargeListDataTierFlatPriceCurrency.Kyd,
            "kzt" => ChargeListDataTierFlatPriceCurrency.Kzt,
            "lbp" => ChargeListDataTierFlatPriceCurrency.Lbp,
            "lkr" => ChargeListDataTierFlatPriceCurrency.Lkr,
            "lrd" => ChargeListDataTierFlatPriceCurrency.Lrd,
            "lsl" => ChargeListDataTierFlatPriceCurrency.Lsl,
            "mad" => ChargeListDataTierFlatPriceCurrency.Mad,
            "mdl" => ChargeListDataTierFlatPriceCurrency.Mdl,
            "mga" => ChargeListDataTierFlatPriceCurrency.Mga,
            "mkd" => ChargeListDataTierFlatPriceCurrency.Mkd,
            "mmk" => ChargeListDataTierFlatPriceCurrency.Mmk,
            "mnt" => ChargeListDataTierFlatPriceCurrency.Mnt,
            "mop" => ChargeListDataTierFlatPriceCurrency.Mop,
            "mro" => ChargeListDataTierFlatPriceCurrency.Mro,
            "mvr" => ChargeListDataTierFlatPriceCurrency.Mvr,
            "mwk" => ChargeListDataTierFlatPriceCurrency.Mwk,
            "mxn" => ChargeListDataTierFlatPriceCurrency.Mxn,
            "myr" => ChargeListDataTierFlatPriceCurrency.Myr,
            "mzn" => ChargeListDataTierFlatPriceCurrency.Mzn,
            "nad" => ChargeListDataTierFlatPriceCurrency.Nad,
            "ngn" => ChargeListDataTierFlatPriceCurrency.Ngn,
            "nok" => ChargeListDataTierFlatPriceCurrency.Nok,
            "npr" => ChargeListDataTierFlatPriceCurrency.Npr,
            "nzd" => ChargeListDataTierFlatPriceCurrency.Nzd,
            "pgk" => ChargeListDataTierFlatPriceCurrency.Pgk,
            "php" => ChargeListDataTierFlatPriceCurrency.Php,
            "pkr" => ChargeListDataTierFlatPriceCurrency.Pkr,
            "pln" => ChargeListDataTierFlatPriceCurrency.Pln,
            "qar" => ChargeListDataTierFlatPriceCurrency.Qar,
            "ron" => ChargeListDataTierFlatPriceCurrency.Ron,
            "rsd" => ChargeListDataTierFlatPriceCurrency.Rsd,
            "rub" => ChargeListDataTierFlatPriceCurrency.Rub,
            "rwf" => ChargeListDataTierFlatPriceCurrency.Rwf,
            "sar" => ChargeListDataTierFlatPriceCurrency.Sar,
            "sbd" => ChargeListDataTierFlatPriceCurrency.Sbd,
            "scr" => ChargeListDataTierFlatPriceCurrency.Scr,
            "sek" => ChargeListDataTierFlatPriceCurrency.Sek,
            "sgd" => ChargeListDataTierFlatPriceCurrency.Sgd,
            "sle" => ChargeListDataTierFlatPriceCurrency.Sle,
            "sll" => ChargeListDataTierFlatPriceCurrency.Sll,
            "sos" => ChargeListDataTierFlatPriceCurrency.Sos,
            "szl" => ChargeListDataTierFlatPriceCurrency.Szl,
            "thb" => ChargeListDataTierFlatPriceCurrency.Thb,
            "tjs" => ChargeListDataTierFlatPriceCurrency.Tjs,
            "top" => ChargeListDataTierFlatPriceCurrency.Top,
            "try" => ChargeListDataTierFlatPriceCurrency.Try,
            "ttd" => ChargeListDataTierFlatPriceCurrency.Ttd,
            "tzs" => ChargeListDataTierFlatPriceCurrency.Tzs,
            "uah" => ChargeListDataTierFlatPriceCurrency.Uah,
            "uzs" => ChargeListDataTierFlatPriceCurrency.Uzs,
            "vnd" => ChargeListDataTierFlatPriceCurrency.Vnd,
            "vuv" => ChargeListDataTierFlatPriceCurrency.Vuv,
            "wst" => ChargeListDataTierFlatPriceCurrency.Wst,
            "xaf" => ChargeListDataTierFlatPriceCurrency.Xaf,
            "xcd" => ChargeListDataTierFlatPriceCurrency.Xcd,
            "yer" => ChargeListDataTierFlatPriceCurrency.Yer,
            "zar" => ChargeListDataTierFlatPriceCurrency.Zar,
            "zmw" => ChargeListDataTierFlatPriceCurrency.Zmw,
            "clp" => ChargeListDataTierFlatPriceCurrency.Clp,
            "djf" => ChargeListDataTierFlatPriceCurrency.Djf,
            "gnf" => ChargeListDataTierFlatPriceCurrency.Gnf,
            "ugx" => ChargeListDataTierFlatPriceCurrency.Ugx,
            "pyg" => ChargeListDataTierFlatPriceCurrency.Pyg,
            "xof" => ChargeListDataTierFlatPriceCurrency.Xof,
            "xpf" => ChargeListDataTierFlatPriceCurrency.Xpf,
            _ => (ChargeListDataTierFlatPriceCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChargeListDataTierFlatPriceCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChargeListDataTierFlatPriceCurrency.Usd => "usd",
                ChargeListDataTierFlatPriceCurrency.Aed => "aed",
                ChargeListDataTierFlatPriceCurrency.All => "all",
                ChargeListDataTierFlatPriceCurrency.Amd => "amd",
                ChargeListDataTierFlatPriceCurrency.Ang => "ang",
                ChargeListDataTierFlatPriceCurrency.Aud => "aud",
                ChargeListDataTierFlatPriceCurrency.Awg => "awg",
                ChargeListDataTierFlatPriceCurrency.Azn => "azn",
                ChargeListDataTierFlatPriceCurrency.Bam => "bam",
                ChargeListDataTierFlatPriceCurrency.Bbd => "bbd",
                ChargeListDataTierFlatPriceCurrency.Bdt => "bdt",
                ChargeListDataTierFlatPriceCurrency.Bgn => "bgn",
                ChargeListDataTierFlatPriceCurrency.Bif => "bif",
                ChargeListDataTierFlatPriceCurrency.Bmd => "bmd",
                ChargeListDataTierFlatPriceCurrency.Bnd => "bnd",
                ChargeListDataTierFlatPriceCurrency.Bsd => "bsd",
                ChargeListDataTierFlatPriceCurrency.Bwp => "bwp",
                ChargeListDataTierFlatPriceCurrency.Byn => "byn",
                ChargeListDataTierFlatPriceCurrency.Bzd => "bzd",
                ChargeListDataTierFlatPriceCurrency.Brl => "brl",
                ChargeListDataTierFlatPriceCurrency.Cad => "cad",
                ChargeListDataTierFlatPriceCurrency.Cdf => "cdf",
                ChargeListDataTierFlatPriceCurrency.Chf => "chf",
                ChargeListDataTierFlatPriceCurrency.Cny => "cny",
                ChargeListDataTierFlatPriceCurrency.Czk => "czk",
                ChargeListDataTierFlatPriceCurrency.Dkk => "dkk",
                ChargeListDataTierFlatPriceCurrency.Dop => "dop",
                ChargeListDataTierFlatPriceCurrency.Dzd => "dzd",
                ChargeListDataTierFlatPriceCurrency.Egp => "egp",
                ChargeListDataTierFlatPriceCurrency.Etb => "etb",
                ChargeListDataTierFlatPriceCurrency.Eur => "eur",
                ChargeListDataTierFlatPriceCurrency.Fjd => "fjd",
                ChargeListDataTierFlatPriceCurrency.Gbp => "gbp",
                ChargeListDataTierFlatPriceCurrency.Gel => "gel",
                ChargeListDataTierFlatPriceCurrency.Gip => "gip",
                ChargeListDataTierFlatPriceCurrency.Gmd => "gmd",
                ChargeListDataTierFlatPriceCurrency.Gyd => "gyd",
                ChargeListDataTierFlatPriceCurrency.Hkd => "hkd",
                ChargeListDataTierFlatPriceCurrency.Hrk => "hrk",
                ChargeListDataTierFlatPriceCurrency.Htg => "htg",
                ChargeListDataTierFlatPriceCurrency.Idr => "idr",
                ChargeListDataTierFlatPriceCurrency.Ils => "ils",
                ChargeListDataTierFlatPriceCurrency.Inr => "inr",
                ChargeListDataTierFlatPriceCurrency.Isk => "isk",
                ChargeListDataTierFlatPriceCurrency.Jmd => "jmd",
                ChargeListDataTierFlatPriceCurrency.Jpy => "jpy",
                ChargeListDataTierFlatPriceCurrency.Kes => "kes",
                ChargeListDataTierFlatPriceCurrency.Kgs => "kgs",
                ChargeListDataTierFlatPriceCurrency.Khr => "khr",
                ChargeListDataTierFlatPriceCurrency.Kmf => "kmf",
                ChargeListDataTierFlatPriceCurrency.Krw => "krw",
                ChargeListDataTierFlatPriceCurrency.Kyd => "kyd",
                ChargeListDataTierFlatPriceCurrency.Kzt => "kzt",
                ChargeListDataTierFlatPriceCurrency.Lbp => "lbp",
                ChargeListDataTierFlatPriceCurrency.Lkr => "lkr",
                ChargeListDataTierFlatPriceCurrency.Lrd => "lrd",
                ChargeListDataTierFlatPriceCurrency.Lsl => "lsl",
                ChargeListDataTierFlatPriceCurrency.Mad => "mad",
                ChargeListDataTierFlatPriceCurrency.Mdl => "mdl",
                ChargeListDataTierFlatPriceCurrency.Mga => "mga",
                ChargeListDataTierFlatPriceCurrency.Mkd => "mkd",
                ChargeListDataTierFlatPriceCurrency.Mmk => "mmk",
                ChargeListDataTierFlatPriceCurrency.Mnt => "mnt",
                ChargeListDataTierFlatPriceCurrency.Mop => "mop",
                ChargeListDataTierFlatPriceCurrency.Mro => "mro",
                ChargeListDataTierFlatPriceCurrency.Mvr => "mvr",
                ChargeListDataTierFlatPriceCurrency.Mwk => "mwk",
                ChargeListDataTierFlatPriceCurrency.Mxn => "mxn",
                ChargeListDataTierFlatPriceCurrency.Myr => "myr",
                ChargeListDataTierFlatPriceCurrency.Mzn => "mzn",
                ChargeListDataTierFlatPriceCurrency.Nad => "nad",
                ChargeListDataTierFlatPriceCurrency.Ngn => "ngn",
                ChargeListDataTierFlatPriceCurrency.Nok => "nok",
                ChargeListDataTierFlatPriceCurrency.Npr => "npr",
                ChargeListDataTierFlatPriceCurrency.Nzd => "nzd",
                ChargeListDataTierFlatPriceCurrency.Pgk => "pgk",
                ChargeListDataTierFlatPriceCurrency.Php => "php",
                ChargeListDataTierFlatPriceCurrency.Pkr => "pkr",
                ChargeListDataTierFlatPriceCurrency.Pln => "pln",
                ChargeListDataTierFlatPriceCurrency.Qar => "qar",
                ChargeListDataTierFlatPriceCurrency.Ron => "ron",
                ChargeListDataTierFlatPriceCurrency.Rsd => "rsd",
                ChargeListDataTierFlatPriceCurrency.Rub => "rub",
                ChargeListDataTierFlatPriceCurrency.Rwf => "rwf",
                ChargeListDataTierFlatPriceCurrency.Sar => "sar",
                ChargeListDataTierFlatPriceCurrency.Sbd => "sbd",
                ChargeListDataTierFlatPriceCurrency.Scr => "scr",
                ChargeListDataTierFlatPriceCurrency.Sek => "sek",
                ChargeListDataTierFlatPriceCurrency.Sgd => "sgd",
                ChargeListDataTierFlatPriceCurrency.Sle => "sle",
                ChargeListDataTierFlatPriceCurrency.Sll => "sll",
                ChargeListDataTierFlatPriceCurrency.Sos => "sos",
                ChargeListDataTierFlatPriceCurrency.Szl => "szl",
                ChargeListDataTierFlatPriceCurrency.Thb => "thb",
                ChargeListDataTierFlatPriceCurrency.Tjs => "tjs",
                ChargeListDataTierFlatPriceCurrency.Top => "top",
                ChargeListDataTierFlatPriceCurrency.Try => "try",
                ChargeListDataTierFlatPriceCurrency.Ttd => "ttd",
                ChargeListDataTierFlatPriceCurrency.Tzs => "tzs",
                ChargeListDataTierFlatPriceCurrency.Uah => "uah",
                ChargeListDataTierFlatPriceCurrency.Uzs => "uzs",
                ChargeListDataTierFlatPriceCurrency.Vnd => "vnd",
                ChargeListDataTierFlatPriceCurrency.Vuv => "vuv",
                ChargeListDataTierFlatPriceCurrency.Wst => "wst",
                ChargeListDataTierFlatPriceCurrency.Xaf => "xaf",
                ChargeListDataTierFlatPriceCurrency.Xcd => "xcd",
                ChargeListDataTierFlatPriceCurrency.Yer => "yer",
                ChargeListDataTierFlatPriceCurrency.Zar => "zar",
                ChargeListDataTierFlatPriceCurrency.Zmw => "zmw",
                ChargeListDataTierFlatPriceCurrency.Clp => "clp",
                ChargeListDataTierFlatPriceCurrency.Djf => "djf",
                ChargeListDataTierFlatPriceCurrency.Gnf => "gnf",
                ChargeListDataTierFlatPriceCurrency.Ugx => "ugx",
                ChargeListDataTierFlatPriceCurrency.Pyg => "pyg",
                ChargeListDataTierFlatPriceCurrency.Xof => "xof",
                ChargeListDataTierFlatPriceCurrency.Xpf => "xpf",
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
    typeof(JsonModelConverter<ChargeListDataTierUnitPrice, ChargeListDataTierUnitPriceFromRaw>)
)]
public sealed record class ChargeListDataTierUnitPrice : JsonModel
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
    public required ApiEnum<string, ChargeListDataTierUnitPriceCurrency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ChargeListDataTierUnitPriceCurrency>
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

    public ChargeListDataTierUnitPrice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargeListDataTierUnitPrice(ChargeListDataTierUnitPrice chargeListDataTierUnitPrice)
        : base(chargeListDataTierUnitPrice) { }
#pragma warning restore CS8618

    public ChargeListDataTierUnitPrice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargeListDataTierUnitPrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargeListDataTierUnitPriceFromRaw.FromRawUnchecked"/>
    public static ChargeListDataTierUnitPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChargeListDataTierUnitPriceFromRaw : IFromRawJson<ChargeListDataTierUnitPrice>
{
    /// <inheritdoc/>
    public ChargeListDataTierUnitPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChargeListDataTierUnitPrice.FromRawUnchecked(rawData);
}

/// <summary>
/// ISO 4217 currency code
/// </summary>
[JsonConverter(typeof(ChargeListDataTierUnitPriceCurrencyConverter))]
public enum ChargeListDataTierUnitPriceCurrency
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

sealed class ChargeListDataTierUnitPriceCurrencyConverter
    : JsonConverter<ChargeListDataTierUnitPriceCurrency>
{
    public override ChargeListDataTierUnitPriceCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => ChargeListDataTierUnitPriceCurrency.Usd,
            "aed" => ChargeListDataTierUnitPriceCurrency.Aed,
            "all" => ChargeListDataTierUnitPriceCurrency.All,
            "amd" => ChargeListDataTierUnitPriceCurrency.Amd,
            "ang" => ChargeListDataTierUnitPriceCurrency.Ang,
            "aud" => ChargeListDataTierUnitPriceCurrency.Aud,
            "awg" => ChargeListDataTierUnitPriceCurrency.Awg,
            "azn" => ChargeListDataTierUnitPriceCurrency.Azn,
            "bam" => ChargeListDataTierUnitPriceCurrency.Bam,
            "bbd" => ChargeListDataTierUnitPriceCurrency.Bbd,
            "bdt" => ChargeListDataTierUnitPriceCurrency.Bdt,
            "bgn" => ChargeListDataTierUnitPriceCurrency.Bgn,
            "bif" => ChargeListDataTierUnitPriceCurrency.Bif,
            "bmd" => ChargeListDataTierUnitPriceCurrency.Bmd,
            "bnd" => ChargeListDataTierUnitPriceCurrency.Bnd,
            "bsd" => ChargeListDataTierUnitPriceCurrency.Bsd,
            "bwp" => ChargeListDataTierUnitPriceCurrency.Bwp,
            "byn" => ChargeListDataTierUnitPriceCurrency.Byn,
            "bzd" => ChargeListDataTierUnitPriceCurrency.Bzd,
            "brl" => ChargeListDataTierUnitPriceCurrency.Brl,
            "cad" => ChargeListDataTierUnitPriceCurrency.Cad,
            "cdf" => ChargeListDataTierUnitPriceCurrency.Cdf,
            "chf" => ChargeListDataTierUnitPriceCurrency.Chf,
            "cny" => ChargeListDataTierUnitPriceCurrency.Cny,
            "czk" => ChargeListDataTierUnitPriceCurrency.Czk,
            "dkk" => ChargeListDataTierUnitPriceCurrency.Dkk,
            "dop" => ChargeListDataTierUnitPriceCurrency.Dop,
            "dzd" => ChargeListDataTierUnitPriceCurrency.Dzd,
            "egp" => ChargeListDataTierUnitPriceCurrency.Egp,
            "etb" => ChargeListDataTierUnitPriceCurrency.Etb,
            "eur" => ChargeListDataTierUnitPriceCurrency.Eur,
            "fjd" => ChargeListDataTierUnitPriceCurrency.Fjd,
            "gbp" => ChargeListDataTierUnitPriceCurrency.Gbp,
            "gel" => ChargeListDataTierUnitPriceCurrency.Gel,
            "gip" => ChargeListDataTierUnitPriceCurrency.Gip,
            "gmd" => ChargeListDataTierUnitPriceCurrency.Gmd,
            "gyd" => ChargeListDataTierUnitPriceCurrency.Gyd,
            "hkd" => ChargeListDataTierUnitPriceCurrency.Hkd,
            "hrk" => ChargeListDataTierUnitPriceCurrency.Hrk,
            "htg" => ChargeListDataTierUnitPriceCurrency.Htg,
            "idr" => ChargeListDataTierUnitPriceCurrency.Idr,
            "ils" => ChargeListDataTierUnitPriceCurrency.Ils,
            "inr" => ChargeListDataTierUnitPriceCurrency.Inr,
            "isk" => ChargeListDataTierUnitPriceCurrency.Isk,
            "jmd" => ChargeListDataTierUnitPriceCurrency.Jmd,
            "jpy" => ChargeListDataTierUnitPriceCurrency.Jpy,
            "kes" => ChargeListDataTierUnitPriceCurrency.Kes,
            "kgs" => ChargeListDataTierUnitPriceCurrency.Kgs,
            "khr" => ChargeListDataTierUnitPriceCurrency.Khr,
            "kmf" => ChargeListDataTierUnitPriceCurrency.Kmf,
            "krw" => ChargeListDataTierUnitPriceCurrency.Krw,
            "kyd" => ChargeListDataTierUnitPriceCurrency.Kyd,
            "kzt" => ChargeListDataTierUnitPriceCurrency.Kzt,
            "lbp" => ChargeListDataTierUnitPriceCurrency.Lbp,
            "lkr" => ChargeListDataTierUnitPriceCurrency.Lkr,
            "lrd" => ChargeListDataTierUnitPriceCurrency.Lrd,
            "lsl" => ChargeListDataTierUnitPriceCurrency.Lsl,
            "mad" => ChargeListDataTierUnitPriceCurrency.Mad,
            "mdl" => ChargeListDataTierUnitPriceCurrency.Mdl,
            "mga" => ChargeListDataTierUnitPriceCurrency.Mga,
            "mkd" => ChargeListDataTierUnitPriceCurrency.Mkd,
            "mmk" => ChargeListDataTierUnitPriceCurrency.Mmk,
            "mnt" => ChargeListDataTierUnitPriceCurrency.Mnt,
            "mop" => ChargeListDataTierUnitPriceCurrency.Mop,
            "mro" => ChargeListDataTierUnitPriceCurrency.Mro,
            "mvr" => ChargeListDataTierUnitPriceCurrency.Mvr,
            "mwk" => ChargeListDataTierUnitPriceCurrency.Mwk,
            "mxn" => ChargeListDataTierUnitPriceCurrency.Mxn,
            "myr" => ChargeListDataTierUnitPriceCurrency.Myr,
            "mzn" => ChargeListDataTierUnitPriceCurrency.Mzn,
            "nad" => ChargeListDataTierUnitPriceCurrency.Nad,
            "ngn" => ChargeListDataTierUnitPriceCurrency.Ngn,
            "nok" => ChargeListDataTierUnitPriceCurrency.Nok,
            "npr" => ChargeListDataTierUnitPriceCurrency.Npr,
            "nzd" => ChargeListDataTierUnitPriceCurrency.Nzd,
            "pgk" => ChargeListDataTierUnitPriceCurrency.Pgk,
            "php" => ChargeListDataTierUnitPriceCurrency.Php,
            "pkr" => ChargeListDataTierUnitPriceCurrency.Pkr,
            "pln" => ChargeListDataTierUnitPriceCurrency.Pln,
            "qar" => ChargeListDataTierUnitPriceCurrency.Qar,
            "ron" => ChargeListDataTierUnitPriceCurrency.Ron,
            "rsd" => ChargeListDataTierUnitPriceCurrency.Rsd,
            "rub" => ChargeListDataTierUnitPriceCurrency.Rub,
            "rwf" => ChargeListDataTierUnitPriceCurrency.Rwf,
            "sar" => ChargeListDataTierUnitPriceCurrency.Sar,
            "sbd" => ChargeListDataTierUnitPriceCurrency.Sbd,
            "scr" => ChargeListDataTierUnitPriceCurrency.Scr,
            "sek" => ChargeListDataTierUnitPriceCurrency.Sek,
            "sgd" => ChargeListDataTierUnitPriceCurrency.Sgd,
            "sle" => ChargeListDataTierUnitPriceCurrency.Sle,
            "sll" => ChargeListDataTierUnitPriceCurrency.Sll,
            "sos" => ChargeListDataTierUnitPriceCurrency.Sos,
            "szl" => ChargeListDataTierUnitPriceCurrency.Szl,
            "thb" => ChargeListDataTierUnitPriceCurrency.Thb,
            "tjs" => ChargeListDataTierUnitPriceCurrency.Tjs,
            "top" => ChargeListDataTierUnitPriceCurrency.Top,
            "try" => ChargeListDataTierUnitPriceCurrency.Try,
            "ttd" => ChargeListDataTierUnitPriceCurrency.Ttd,
            "tzs" => ChargeListDataTierUnitPriceCurrency.Tzs,
            "uah" => ChargeListDataTierUnitPriceCurrency.Uah,
            "uzs" => ChargeListDataTierUnitPriceCurrency.Uzs,
            "vnd" => ChargeListDataTierUnitPriceCurrency.Vnd,
            "vuv" => ChargeListDataTierUnitPriceCurrency.Vuv,
            "wst" => ChargeListDataTierUnitPriceCurrency.Wst,
            "xaf" => ChargeListDataTierUnitPriceCurrency.Xaf,
            "xcd" => ChargeListDataTierUnitPriceCurrency.Xcd,
            "yer" => ChargeListDataTierUnitPriceCurrency.Yer,
            "zar" => ChargeListDataTierUnitPriceCurrency.Zar,
            "zmw" => ChargeListDataTierUnitPriceCurrency.Zmw,
            "clp" => ChargeListDataTierUnitPriceCurrency.Clp,
            "djf" => ChargeListDataTierUnitPriceCurrency.Djf,
            "gnf" => ChargeListDataTierUnitPriceCurrency.Gnf,
            "ugx" => ChargeListDataTierUnitPriceCurrency.Ugx,
            "pyg" => ChargeListDataTierUnitPriceCurrency.Pyg,
            "xof" => ChargeListDataTierUnitPriceCurrency.Xof,
            "xpf" => ChargeListDataTierUnitPriceCurrency.Xpf,
            _ => (ChargeListDataTierUnitPriceCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChargeListDataTierUnitPriceCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChargeListDataTierUnitPriceCurrency.Usd => "usd",
                ChargeListDataTierUnitPriceCurrency.Aed => "aed",
                ChargeListDataTierUnitPriceCurrency.All => "all",
                ChargeListDataTierUnitPriceCurrency.Amd => "amd",
                ChargeListDataTierUnitPriceCurrency.Ang => "ang",
                ChargeListDataTierUnitPriceCurrency.Aud => "aud",
                ChargeListDataTierUnitPriceCurrency.Awg => "awg",
                ChargeListDataTierUnitPriceCurrency.Azn => "azn",
                ChargeListDataTierUnitPriceCurrency.Bam => "bam",
                ChargeListDataTierUnitPriceCurrency.Bbd => "bbd",
                ChargeListDataTierUnitPriceCurrency.Bdt => "bdt",
                ChargeListDataTierUnitPriceCurrency.Bgn => "bgn",
                ChargeListDataTierUnitPriceCurrency.Bif => "bif",
                ChargeListDataTierUnitPriceCurrency.Bmd => "bmd",
                ChargeListDataTierUnitPriceCurrency.Bnd => "bnd",
                ChargeListDataTierUnitPriceCurrency.Bsd => "bsd",
                ChargeListDataTierUnitPriceCurrency.Bwp => "bwp",
                ChargeListDataTierUnitPriceCurrency.Byn => "byn",
                ChargeListDataTierUnitPriceCurrency.Bzd => "bzd",
                ChargeListDataTierUnitPriceCurrency.Brl => "brl",
                ChargeListDataTierUnitPriceCurrency.Cad => "cad",
                ChargeListDataTierUnitPriceCurrency.Cdf => "cdf",
                ChargeListDataTierUnitPriceCurrency.Chf => "chf",
                ChargeListDataTierUnitPriceCurrency.Cny => "cny",
                ChargeListDataTierUnitPriceCurrency.Czk => "czk",
                ChargeListDataTierUnitPriceCurrency.Dkk => "dkk",
                ChargeListDataTierUnitPriceCurrency.Dop => "dop",
                ChargeListDataTierUnitPriceCurrency.Dzd => "dzd",
                ChargeListDataTierUnitPriceCurrency.Egp => "egp",
                ChargeListDataTierUnitPriceCurrency.Etb => "etb",
                ChargeListDataTierUnitPriceCurrency.Eur => "eur",
                ChargeListDataTierUnitPriceCurrency.Fjd => "fjd",
                ChargeListDataTierUnitPriceCurrency.Gbp => "gbp",
                ChargeListDataTierUnitPriceCurrency.Gel => "gel",
                ChargeListDataTierUnitPriceCurrency.Gip => "gip",
                ChargeListDataTierUnitPriceCurrency.Gmd => "gmd",
                ChargeListDataTierUnitPriceCurrency.Gyd => "gyd",
                ChargeListDataTierUnitPriceCurrency.Hkd => "hkd",
                ChargeListDataTierUnitPriceCurrency.Hrk => "hrk",
                ChargeListDataTierUnitPriceCurrency.Htg => "htg",
                ChargeListDataTierUnitPriceCurrency.Idr => "idr",
                ChargeListDataTierUnitPriceCurrency.Ils => "ils",
                ChargeListDataTierUnitPriceCurrency.Inr => "inr",
                ChargeListDataTierUnitPriceCurrency.Isk => "isk",
                ChargeListDataTierUnitPriceCurrency.Jmd => "jmd",
                ChargeListDataTierUnitPriceCurrency.Jpy => "jpy",
                ChargeListDataTierUnitPriceCurrency.Kes => "kes",
                ChargeListDataTierUnitPriceCurrency.Kgs => "kgs",
                ChargeListDataTierUnitPriceCurrency.Khr => "khr",
                ChargeListDataTierUnitPriceCurrency.Kmf => "kmf",
                ChargeListDataTierUnitPriceCurrency.Krw => "krw",
                ChargeListDataTierUnitPriceCurrency.Kyd => "kyd",
                ChargeListDataTierUnitPriceCurrency.Kzt => "kzt",
                ChargeListDataTierUnitPriceCurrency.Lbp => "lbp",
                ChargeListDataTierUnitPriceCurrency.Lkr => "lkr",
                ChargeListDataTierUnitPriceCurrency.Lrd => "lrd",
                ChargeListDataTierUnitPriceCurrency.Lsl => "lsl",
                ChargeListDataTierUnitPriceCurrency.Mad => "mad",
                ChargeListDataTierUnitPriceCurrency.Mdl => "mdl",
                ChargeListDataTierUnitPriceCurrency.Mga => "mga",
                ChargeListDataTierUnitPriceCurrency.Mkd => "mkd",
                ChargeListDataTierUnitPriceCurrency.Mmk => "mmk",
                ChargeListDataTierUnitPriceCurrency.Mnt => "mnt",
                ChargeListDataTierUnitPriceCurrency.Mop => "mop",
                ChargeListDataTierUnitPriceCurrency.Mro => "mro",
                ChargeListDataTierUnitPriceCurrency.Mvr => "mvr",
                ChargeListDataTierUnitPriceCurrency.Mwk => "mwk",
                ChargeListDataTierUnitPriceCurrency.Mxn => "mxn",
                ChargeListDataTierUnitPriceCurrency.Myr => "myr",
                ChargeListDataTierUnitPriceCurrency.Mzn => "mzn",
                ChargeListDataTierUnitPriceCurrency.Nad => "nad",
                ChargeListDataTierUnitPriceCurrency.Ngn => "ngn",
                ChargeListDataTierUnitPriceCurrency.Nok => "nok",
                ChargeListDataTierUnitPriceCurrency.Npr => "npr",
                ChargeListDataTierUnitPriceCurrency.Nzd => "nzd",
                ChargeListDataTierUnitPriceCurrency.Pgk => "pgk",
                ChargeListDataTierUnitPriceCurrency.Php => "php",
                ChargeListDataTierUnitPriceCurrency.Pkr => "pkr",
                ChargeListDataTierUnitPriceCurrency.Pln => "pln",
                ChargeListDataTierUnitPriceCurrency.Qar => "qar",
                ChargeListDataTierUnitPriceCurrency.Ron => "ron",
                ChargeListDataTierUnitPriceCurrency.Rsd => "rsd",
                ChargeListDataTierUnitPriceCurrency.Rub => "rub",
                ChargeListDataTierUnitPriceCurrency.Rwf => "rwf",
                ChargeListDataTierUnitPriceCurrency.Sar => "sar",
                ChargeListDataTierUnitPriceCurrency.Sbd => "sbd",
                ChargeListDataTierUnitPriceCurrency.Scr => "scr",
                ChargeListDataTierUnitPriceCurrency.Sek => "sek",
                ChargeListDataTierUnitPriceCurrency.Sgd => "sgd",
                ChargeListDataTierUnitPriceCurrency.Sle => "sle",
                ChargeListDataTierUnitPriceCurrency.Sll => "sll",
                ChargeListDataTierUnitPriceCurrency.Sos => "sos",
                ChargeListDataTierUnitPriceCurrency.Szl => "szl",
                ChargeListDataTierUnitPriceCurrency.Thb => "thb",
                ChargeListDataTierUnitPriceCurrency.Tjs => "tjs",
                ChargeListDataTierUnitPriceCurrency.Top => "top",
                ChargeListDataTierUnitPriceCurrency.Try => "try",
                ChargeListDataTierUnitPriceCurrency.Ttd => "ttd",
                ChargeListDataTierUnitPriceCurrency.Tzs => "tzs",
                ChargeListDataTierUnitPriceCurrency.Uah => "uah",
                ChargeListDataTierUnitPriceCurrency.Uzs => "uzs",
                ChargeListDataTierUnitPriceCurrency.Vnd => "vnd",
                ChargeListDataTierUnitPriceCurrency.Vuv => "vuv",
                ChargeListDataTierUnitPriceCurrency.Wst => "wst",
                ChargeListDataTierUnitPriceCurrency.Xaf => "xaf",
                ChargeListDataTierUnitPriceCurrency.Xcd => "xcd",
                ChargeListDataTierUnitPriceCurrency.Yer => "yer",
                ChargeListDataTierUnitPriceCurrency.Zar => "zar",
                ChargeListDataTierUnitPriceCurrency.Zmw => "zmw",
                ChargeListDataTierUnitPriceCurrency.Clp => "clp",
                ChargeListDataTierUnitPriceCurrency.Djf => "djf",
                ChargeListDataTierUnitPriceCurrency.Gnf => "gnf",
                ChargeListDataTierUnitPriceCurrency.Ugx => "ugx",
                ChargeListDataTierUnitPriceCurrency.Pyg => "pyg",
                ChargeListDataTierUnitPriceCurrency.Xof => "xof",
                ChargeListDataTierUnitPriceCurrency.Xpf => "xpf",
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
[JsonConverter(typeof(ChargeListDataTiersModeConverter))]
public enum ChargeListDataTiersMode
{
    Volume,
    Graduated,
}

sealed class ChargeListDataTiersModeConverter : JsonConverter<ChargeListDataTiersMode>
{
    public override ChargeListDataTiersMode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "VOLUME" => ChargeListDataTiersMode.Volume,
            "GRADUATED" => ChargeListDataTiersMode.Graduated,
            _ => (ChargeListDataTiersMode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChargeListDataTiersMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChargeListDataTiersMode.Volume => "VOLUME",
                ChargeListDataTiersMode.Graduated => "GRADUATED",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Pagination metadata including cursors for navigating through results
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Pagination, PaginationFromRaw>))]
public sealed record class Pagination : JsonModel
{
    /// <summary>
    /// Cursor for fetching the next page of results, or null if no additional pages exist
    /// </summary>
    public required string? Next
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("next");
        }
        init { this._rawData.Set("next", value); }
    }

    /// <summary>
    /// Cursor for fetching the previous page of results, or null if at the beginning
    /// </summary>
    public required string? Prev
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("prev");
        }
        init { this._rawData.Set("prev", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Next;
        _ = this.Prev;
    }

    public Pagination() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Pagination(Pagination pagination)
        : base(pagination) { }
#pragma warning restore CS8618

    public Pagination(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Pagination(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaginationFromRaw.FromRawUnchecked"/>
    public static Pagination FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaginationFromRaw : IFromRawJson<Pagination>
{
    /// <inheritdoc/>
    public Pagination FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Pagination.FromRawUnchecked(rawData);
}
