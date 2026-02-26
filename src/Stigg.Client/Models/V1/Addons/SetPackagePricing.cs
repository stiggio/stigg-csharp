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
/// Request to set the pricing configuration for a plan or addon.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SetPackagePricing, SetPackagePricingFromRaw>))]
public sealed record class SetPackagePricing : JsonModel
{
    /// <summary>
    /// The pricing type (FREE, PAID, or CUSTOM)
    /// </summary>
    public required ApiEnum<string, SetPackagePricingPricingType> PricingType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, SetPackagePricingPricingType>>(
                "pricingType"
            );
        }
        init { this._rawData.Set("pricingType", value); }
    }

    /// <summary>
    /// Deprecated: billing integration ID
    /// </summary>
    public string? BillingID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billingId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("billingId", value);
        }
    }

    /// <summary>
    /// Minimum spend configuration per billing period
    /// </summary>
    public IReadOnlyList<SetPackagePricingMinimumSpend>? MinimumSpend
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<SetPackagePricingMinimumSpend>>(
                "minimumSpend"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<SetPackagePricingMinimumSpend>?>(
                "minimumSpend",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// When overage charges are billed
    /// </summary>
    public ApiEnum<string, SetPackagePricingOverageBillingPeriod>? OverageBillingPeriod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, SetPackagePricingOverageBillingPeriod>
            >("overageBillingPeriod");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("overageBillingPeriod", value);
        }
    }

    /// <summary>
    /// Array of overage pricing model configurations
    /// </summary>
    public IReadOnlyList<SetPackagePricingOveragePricingModel>? OveragePricingModels
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<SetPackagePricingOveragePricingModel>
            >("overagePricingModels");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<SetPackagePricingOveragePricingModel>?>(
                "overagePricingModels",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Array of pricing model configurations
    /// </summary>
    public IReadOnlyList<SetPackagePricingPricingModel>? PricingModels
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<SetPackagePricingPricingModel>>(
                "pricingModels"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<SetPackagePricingPricingModel>?>(
                "pricingModels",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.PricingType.Validate();
        _ = this.BillingID;
        foreach (var item in this.MinimumSpend ?? [])
        {
            item.Validate();
        }
        this.OverageBillingPeriod?.Validate();
        foreach (var item in this.OveragePricingModels ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.PricingModels ?? [])
        {
            item.Validate();
        }
    }

    public SetPackagePricing() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SetPackagePricing(SetPackagePricing setPackagePricing)
        : base(setPackagePricing) { }
#pragma warning restore CS8618

    public SetPackagePricing(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SetPackagePricing(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SetPackagePricingFromRaw.FromRawUnchecked"/>
    public static SetPackagePricing FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SetPackagePricing(ApiEnum<string, SetPackagePricingPricingType> pricingType)
        : this()
    {
        this.PricingType = pricingType;
    }
}

class SetPackagePricingFromRaw : IFromRawJson<SetPackagePricing>
{
    /// <inheritdoc/>
    public SetPackagePricing FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SetPackagePricing.FromRawUnchecked(rawData);
}

/// <summary>
/// The pricing type (FREE, PAID, or CUSTOM)
/// </summary>
[JsonConverter(typeof(SetPackagePricingPricingTypeConverter))]
public enum SetPackagePricingPricingType
{
    Free,
    Paid,
    Custom,
}

sealed class SetPackagePricingPricingTypeConverter : JsonConverter<SetPackagePricingPricingType>
{
    public override SetPackagePricingPricingType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FREE" => SetPackagePricingPricingType.Free,
            "PAID" => SetPackagePricingPricingType.Paid,
            "CUSTOM" => SetPackagePricingPricingType.Custom,
            _ => (SetPackagePricingPricingType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SetPackagePricingPricingType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SetPackagePricingPricingType.Free => "FREE",
                SetPackagePricingPricingType.Paid => "PAID",
                SetPackagePricingPricingType.Custom => "CUSTOM",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Minimum spend configuration for a billing period.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<SetPackagePricingMinimumSpend, SetPackagePricingMinimumSpendFromRaw>)
)]
public sealed record class SetPackagePricingMinimumSpend : JsonModel
{
    /// <summary>
    /// The billing period
    /// </summary>
    public required ApiEnum<string, SetPackagePricingMinimumSpendBillingPeriod> BillingPeriod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, SetPackagePricingMinimumSpendBillingPeriod>
            >("billingPeriod");
        }
        init { this._rawData.Set("billingPeriod", value); }
    }

    /// <summary>
    /// The minimum spend amount
    /// </summary>
    public required SetPackagePricingMinimumSpendMinimum Minimum
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<SetPackagePricingMinimumSpendMinimum>("minimum");
        }
        init { this._rawData.Set("minimum", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.BillingPeriod.Validate();
        this.Minimum.Validate();
    }

    public SetPackagePricingMinimumSpend() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SetPackagePricingMinimumSpend(
        SetPackagePricingMinimumSpend setPackagePricingMinimumSpend
    )
        : base(setPackagePricingMinimumSpend) { }
#pragma warning restore CS8618

    public SetPackagePricingMinimumSpend(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SetPackagePricingMinimumSpend(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SetPackagePricingMinimumSpendFromRaw.FromRawUnchecked"/>
    public static SetPackagePricingMinimumSpend FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SetPackagePricingMinimumSpendFromRaw : IFromRawJson<SetPackagePricingMinimumSpend>
{
    /// <inheritdoc/>
    public SetPackagePricingMinimumSpend FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SetPackagePricingMinimumSpend.FromRawUnchecked(rawData);
}

/// <summary>
/// The billing period
/// </summary>
[JsonConverter(typeof(SetPackagePricingMinimumSpendBillingPeriodConverter))]
public enum SetPackagePricingMinimumSpendBillingPeriod
{
    Monthly,
    Annually,
}

sealed class SetPackagePricingMinimumSpendBillingPeriodConverter
    : JsonConverter<SetPackagePricingMinimumSpendBillingPeriod>
{
    public override SetPackagePricingMinimumSpendBillingPeriod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "MONTHLY" => SetPackagePricingMinimumSpendBillingPeriod.Monthly,
            "ANNUALLY" => SetPackagePricingMinimumSpendBillingPeriod.Annually,
            _ => (SetPackagePricingMinimumSpendBillingPeriod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SetPackagePricingMinimumSpendBillingPeriod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SetPackagePricingMinimumSpendBillingPeriod.Monthly => "MONTHLY",
                SetPackagePricingMinimumSpendBillingPeriod.Annually => "ANNUALLY",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The minimum spend amount
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SetPackagePricingMinimumSpendMinimum,
        SetPackagePricingMinimumSpendMinimumFromRaw
    >)
)]
public sealed record class SetPackagePricingMinimumSpendMinimum : JsonModel
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
    /// The price currency
    /// </summary>
    public ApiEnum<string, SetPackagePricingMinimumSpendMinimumCurrency>? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, SetPackagePricingMinimumSpendMinimumCurrency>
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
        this.Currency?.Validate();
    }

    public SetPackagePricingMinimumSpendMinimum() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SetPackagePricingMinimumSpendMinimum(
        SetPackagePricingMinimumSpendMinimum setPackagePricingMinimumSpendMinimum
    )
        : base(setPackagePricingMinimumSpendMinimum) { }
#pragma warning restore CS8618

    public SetPackagePricingMinimumSpendMinimum(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SetPackagePricingMinimumSpendMinimum(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SetPackagePricingMinimumSpendMinimumFromRaw.FromRawUnchecked"/>
    public static SetPackagePricingMinimumSpendMinimum FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SetPackagePricingMinimumSpendMinimum(double amount)
        : this()
    {
        this.Amount = amount;
    }
}

class SetPackagePricingMinimumSpendMinimumFromRaw
    : IFromRawJson<SetPackagePricingMinimumSpendMinimum>
{
    /// <inheritdoc/>
    public SetPackagePricingMinimumSpendMinimum FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SetPackagePricingMinimumSpendMinimum.FromRawUnchecked(rawData);
}

/// <summary>
/// The price currency
/// </summary>
[JsonConverter(typeof(SetPackagePricingMinimumSpendMinimumCurrencyConverter))]
public enum SetPackagePricingMinimumSpendMinimumCurrency
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

sealed class SetPackagePricingMinimumSpendMinimumCurrencyConverter
    : JsonConverter<SetPackagePricingMinimumSpendMinimumCurrency>
{
    public override SetPackagePricingMinimumSpendMinimumCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => SetPackagePricingMinimumSpendMinimumCurrency.Usd,
            "aed" => SetPackagePricingMinimumSpendMinimumCurrency.Aed,
            "all" => SetPackagePricingMinimumSpendMinimumCurrency.All,
            "amd" => SetPackagePricingMinimumSpendMinimumCurrency.Amd,
            "ang" => SetPackagePricingMinimumSpendMinimumCurrency.Ang,
            "aud" => SetPackagePricingMinimumSpendMinimumCurrency.Aud,
            "awg" => SetPackagePricingMinimumSpendMinimumCurrency.Awg,
            "azn" => SetPackagePricingMinimumSpendMinimumCurrency.Azn,
            "bam" => SetPackagePricingMinimumSpendMinimumCurrency.Bam,
            "bbd" => SetPackagePricingMinimumSpendMinimumCurrency.Bbd,
            "bdt" => SetPackagePricingMinimumSpendMinimumCurrency.Bdt,
            "bgn" => SetPackagePricingMinimumSpendMinimumCurrency.Bgn,
            "bif" => SetPackagePricingMinimumSpendMinimumCurrency.Bif,
            "bmd" => SetPackagePricingMinimumSpendMinimumCurrency.Bmd,
            "bnd" => SetPackagePricingMinimumSpendMinimumCurrency.Bnd,
            "bsd" => SetPackagePricingMinimumSpendMinimumCurrency.Bsd,
            "bwp" => SetPackagePricingMinimumSpendMinimumCurrency.Bwp,
            "byn" => SetPackagePricingMinimumSpendMinimumCurrency.Byn,
            "bzd" => SetPackagePricingMinimumSpendMinimumCurrency.Bzd,
            "brl" => SetPackagePricingMinimumSpendMinimumCurrency.Brl,
            "cad" => SetPackagePricingMinimumSpendMinimumCurrency.Cad,
            "cdf" => SetPackagePricingMinimumSpendMinimumCurrency.Cdf,
            "chf" => SetPackagePricingMinimumSpendMinimumCurrency.Chf,
            "cny" => SetPackagePricingMinimumSpendMinimumCurrency.Cny,
            "czk" => SetPackagePricingMinimumSpendMinimumCurrency.Czk,
            "dkk" => SetPackagePricingMinimumSpendMinimumCurrency.Dkk,
            "dop" => SetPackagePricingMinimumSpendMinimumCurrency.Dop,
            "dzd" => SetPackagePricingMinimumSpendMinimumCurrency.Dzd,
            "egp" => SetPackagePricingMinimumSpendMinimumCurrency.Egp,
            "etb" => SetPackagePricingMinimumSpendMinimumCurrency.Etb,
            "eur" => SetPackagePricingMinimumSpendMinimumCurrency.Eur,
            "fjd" => SetPackagePricingMinimumSpendMinimumCurrency.Fjd,
            "gbp" => SetPackagePricingMinimumSpendMinimumCurrency.Gbp,
            "gel" => SetPackagePricingMinimumSpendMinimumCurrency.Gel,
            "gip" => SetPackagePricingMinimumSpendMinimumCurrency.Gip,
            "gmd" => SetPackagePricingMinimumSpendMinimumCurrency.Gmd,
            "gyd" => SetPackagePricingMinimumSpendMinimumCurrency.Gyd,
            "hkd" => SetPackagePricingMinimumSpendMinimumCurrency.Hkd,
            "hrk" => SetPackagePricingMinimumSpendMinimumCurrency.Hrk,
            "htg" => SetPackagePricingMinimumSpendMinimumCurrency.Htg,
            "idr" => SetPackagePricingMinimumSpendMinimumCurrency.Idr,
            "ils" => SetPackagePricingMinimumSpendMinimumCurrency.Ils,
            "inr" => SetPackagePricingMinimumSpendMinimumCurrency.Inr,
            "isk" => SetPackagePricingMinimumSpendMinimumCurrency.Isk,
            "jmd" => SetPackagePricingMinimumSpendMinimumCurrency.Jmd,
            "jpy" => SetPackagePricingMinimumSpendMinimumCurrency.Jpy,
            "kes" => SetPackagePricingMinimumSpendMinimumCurrency.Kes,
            "kgs" => SetPackagePricingMinimumSpendMinimumCurrency.Kgs,
            "khr" => SetPackagePricingMinimumSpendMinimumCurrency.Khr,
            "kmf" => SetPackagePricingMinimumSpendMinimumCurrency.Kmf,
            "krw" => SetPackagePricingMinimumSpendMinimumCurrency.Krw,
            "kyd" => SetPackagePricingMinimumSpendMinimumCurrency.Kyd,
            "kzt" => SetPackagePricingMinimumSpendMinimumCurrency.Kzt,
            "lbp" => SetPackagePricingMinimumSpendMinimumCurrency.Lbp,
            "lkr" => SetPackagePricingMinimumSpendMinimumCurrency.Lkr,
            "lrd" => SetPackagePricingMinimumSpendMinimumCurrency.Lrd,
            "lsl" => SetPackagePricingMinimumSpendMinimumCurrency.Lsl,
            "mad" => SetPackagePricingMinimumSpendMinimumCurrency.Mad,
            "mdl" => SetPackagePricingMinimumSpendMinimumCurrency.Mdl,
            "mga" => SetPackagePricingMinimumSpendMinimumCurrency.Mga,
            "mkd" => SetPackagePricingMinimumSpendMinimumCurrency.Mkd,
            "mmk" => SetPackagePricingMinimumSpendMinimumCurrency.Mmk,
            "mnt" => SetPackagePricingMinimumSpendMinimumCurrency.Mnt,
            "mop" => SetPackagePricingMinimumSpendMinimumCurrency.Mop,
            "mro" => SetPackagePricingMinimumSpendMinimumCurrency.Mro,
            "mvr" => SetPackagePricingMinimumSpendMinimumCurrency.Mvr,
            "mwk" => SetPackagePricingMinimumSpendMinimumCurrency.Mwk,
            "mxn" => SetPackagePricingMinimumSpendMinimumCurrency.Mxn,
            "myr" => SetPackagePricingMinimumSpendMinimumCurrency.Myr,
            "mzn" => SetPackagePricingMinimumSpendMinimumCurrency.Mzn,
            "nad" => SetPackagePricingMinimumSpendMinimumCurrency.Nad,
            "ngn" => SetPackagePricingMinimumSpendMinimumCurrency.Ngn,
            "nok" => SetPackagePricingMinimumSpendMinimumCurrency.Nok,
            "npr" => SetPackagePricingMinimumSpendMinimumCurrency.Npr,
            "nzd" => SetPackagePricingMinimumSpendMinimumCurrency.Nzd,
            "pgk" => SetPackagePricingMinimumSpendMinimumCurrency.Pgk,
            "php" => SetPackagePricingMinimumSpendMinimumCurrency.Php,
            "pkr" => SetPackagePricingMinimumSpendMinimumCurrency.Pkr,
            "pln" => SetPackagePricingMinimumSpendMinimumCurrency.Pln,
            "qar" => SetPackagePricingMinimumSpendMinimumCurrency.Qar,
            "ron" => SetPackagePricingMinimumSpendMinimumCurrency.Ron,
            "rsd" => SetPackagePricingMinimumSpendMinimumCurrency.Rsd,
            "rub" => SetPackagePricingMinimumSpendMinimumCurrency.Rub,
            "rwf" => SetPackagePricingMinimumSpendMinimumCurrency.Rwf,
            "sar" => SetPackagePricingMinimumSpendMinimumCurrency.Sar,
            "sbd" => SetPackagePricingMinimumSpendMinimumCurrency.Sbd,
            "scr" => SetPackagePricingMinimumSpendMinimumCurrency.Scr,
            "sek" => SetPackagePricingMinimumSpendMinimumCurrency.Sek,
            "sgd" => SetPackagePricingMinimumSpendMinimumCurrency.Sgd,
            "sle" => SetPackagePricingMinimumSpendMinimumCurrency.Sle,
            "sll" => SetPackagePricingMinimumSpendMinimumCurrency.Sll,
            "sos" => SetPackagePricingMinimumSpendMinimumCurrency.Sos,
            "szl" => SetPackagePricingMinimumSpendMinimumCurrency.Szl,
            "thb" => SetPackagePricingMinimumSpendMinimumCurrency.Thb,
            "tjs" => SetPackagePricingMinimumSpendMinimumCurrency.Tjs,
            "top" => SetPackagePricingMinimumSpendMinimumCurrency.Top,
            "try" => SetPackagePricingMinimumSpendMinimumCurrency.Try,
            "ttd" => SetPackagePricingMinimumSpendMinimumCurrency.Ttd,
            "tzs" => SetPackagePricingMinimumSpendMinimumCurrency.Tzs,
            "uah" => SetPackagePricingMinimumSpendMinimumCurrency.Uah,
            "uzs" => SetPackagePricingMinimumSpendMinimumCurrency.Uzs,
            "vnd" => SetPackagePricingMinimumSpendMinimumCurrency.Vnd,
            "vuv" => SetPackagePricingMinimumSpendMinimumCurrency.Vuv,
            "wst" => SetPackagePricingMinimumSpendMinimumCurrency.Wst,
            "xaf" => SetPackagePricingMinimumSpendMinimumCurrency.Xaf,
            "xcd" => SetPackagePricingMinimumSpendMinimumCurrency.Xcd,
            "yer" => SetPackagePricingMinimumSpendMinimumCurrency.Yer,
            "zar" => SetPackagePricingMinimumSpendMinimumCurrency.Zar,
            "zmw" => SetPackagePricingMinimumSpendMinimumCurrency.Zmw,
            "clp" => SetPackagePricingMinimumSpendMinimumCurrency.Clp,
            "djf" => SetPackagePricingMinimumSpendMinimumCurrency.Djf,
            "gnf" => SetPackagePricingMinimumSpendMinimumCurrency.Gnf,
            "ugx" => SetPackagePricingMinimumSpendMinimumCurrency.Ugx,
            "pyg" => SetPackagePricingMinimumSpendMinimumCurrency.Pyg,
            "xof" => SetPackagePricingMinimumSpendMinimumCurrency.Xof,
            "xpf" => SetPackagePricingMinimumSpendMinimumCurrency.Xpf,
            _ => (SetPackagePricingMinimumSpendMinimumCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SetPackagePricingMinimumSpendMinimumCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SetPackagePricingMinimumSpendMinimumCurrency.Usd => "usd",
                SetPackagePricingMinimumSpendMinimumCurrency.Aed => "aed",
                SetPackagePricingMinimumSpendMinimumCurrency.All => "all",
                SetPackagePricingMinimumSpendMinimumCurrency.Amd => "amd",
                SetPackagePricingMinimumSpendMinimumCurrency.Ang => "ang",
                SetPackagePricingMinimumSpendMinimumCurrency.Aud => "aud",
                SetPackagePricingMinimumSpendMinimumCurrency.Awg => "awg",
                SetPackagePricingMinimumSpendMinimumCurrency.Azn => "azn",
                SetPackagePricingMinimumSpendMinimumCurrency.Bam => "bam",
                SetPackagePricingMinimumSpendMinimumCurrency.Bbd => "bbd",
                SetPackagePricingMinimumSpendMinimumCurrency.Bdt => "bdt",
                SetPackagePricingMinimumSpendMinimumCurrency.Bgn => "bgn",
                SetPackagePricingMinimumSpendMinimumCurrency.Bif => "bif",
                SetPackagePricingMinimumSpendMinimumCurrency.Bmd => "bmd",
                SetPackagePricingMinimumSpendMinimumCurrency.Bnd => "bnd",
                SetPackagePricingMinimumSpendMinimumCurrency.Bsd => "bsd",
                SetPackagePricingMinimumSpendMinimumCurrency.Bwp => "bwp",
                SetPackagePricingMinimumSpendMinimumCurrency.Byn => "byn",
                SetPackagePricingMinimumSpendMinimumCurrency.Bzd => "bzd",
                SetPackagePricingMinimumSpendMinimumCurrency.Brl => "brl",
                SetPackagePricingMinimumSpendMinimumCurrency.Cad => "cad",
                SetPackagePricingMinimumSpendMinimumCurrency.Cdf => "cdf",
                SetPackagePricingMinimumSpendMinimumCurrency.Chf => "chf",
                SetPackagePricingMinimumSpendMinimumCurrency.Cny => "cny",
                SetPackagePricingMinimumSpendMinimumCurrency.Czk => "czk",
                SetPackagePricingMinimumSpendMinimumCurrency.Dkk => "dkk",
                SetPackagePricingMinimumSpendMinimumCurrency.Dop => "dop",
                SetPackagePricingMinimumSpendMinimumCurrency.Dzd => "dzd",
                SetPackagePricingMinimumSpendMinimumCurrency.Egp => "egp",
                SetPackagePricingMinimumSpendMinimumCurrency.Etb => "etb",
                SetPackagePricingMinimumSpendMinimumCurrency.Eur => "eur",
                SetPackagePricingMinimumSpendMinimumCurrency.Fjd => "fjd",
                SetPackagePricingMinimumSpendMinimumCurrency.Gbp => "gbp",
                SetPackagePricingMinimumSpendMinimumCurrency.Gel => "gel",
                SetPackagePricingMinimumSpendMinimumCurrency.Gip => "gip",
                SetPackagePricingMinimumSpendMinimumCurrency.Gmd => "gmd",
                SetPackagePricingMinimumSpendMinimumCurrency.Gyd => "gyd",
                SetPackagePricingMinimumSpendMinimumCurrency.Hkd => "hkd",
                SetPackagePricingMinimumSpendMinimumCurrency.Hrk => "hrk",
                SetPackagePricingMinimumSpendMinimumCurrency.Htg => "htg",
                SetPackagePricingMinimumSpendMinimumCurrency.Idr => "idr",
                SetPackagePricingMinimumSpendMinimumCurrency.Ils => "ils",
                SetPackagePricingMinimumSpendMinimumCurrency.Inr => "inr",
                SetPackagePricingMinimumSpendMinimumCurrency.Isk => "isk",
                SetPackagePricingMinimumSpendMinimumCurrency.Jmd => "jmd",
                SetPackagePricingMinimumSpendMinimumCurrency.Jpy => "jpy",
                SetPackagePricingMinimumSpendMinimumCurrency.Kes => "kes",
                SetPackagePricingMinimumSpendMinimumCurrency.Kgs => "kgs",
                SetPackagePricingMinimumSpendMinimumCurrency.Khr => "khr",
                SetPackagePricingMinimumSpendMinimumCurrency.Kmf => "kmf",
                SetPackagePricingMinimumSpendMinimumCurrency.Krw => "krw",
                SetPackagePricingMinimumSpendMinimumCurrency.Kyd => "kyd",
                SetPackagePricingMinimumSpendMinimumCurrency.Kzt => "kzt",
                SetPackagePricingMinimumSpendMinimumCurrency.Lbp => "lbp",
                SetPackagePricingMinimumSpendMinimumCurrency.Lkr => "lkr",
                SetPackagePricingMinimumSpendMinimumCurrency.Lrd => "lrd",
                SetPackagePricingMinimumSpendMinimumCurrency.Lsl => "lsl",
                SetPackagePricingMinimumSpendMinimumCurrency.Mad => "mad",
                SetPackagePricingMinimumSpendMinimumCurrency.Mdl => "mdl",
                SetPackagePricingMinimumSpendMinimumCurrency.Mga => "mga",
                SetPackagePricingMinimumSpendMinimumCurrency.Mkd => "mkd",
                SetPackagePricingMinimumSpendMinimumCurrency.Mmk => "mmk",
                SetPackagePricingMinimumSpendMinimumCurrency.Mnt => "mnt",
                SetPackagePricingMinimumSpendMinimumCurrency.Mop => "mop",
                SetPackagePricingMinimumSpendMinimumCurrency.Mro => "mro",
                SetPackagePricingMinimumSpendMinimumCurrency.Mvr => "mvr",
                SetPackagePricingMinimumSpendMinimumCurrency.Mwk => "mwk",
                SetPackagePricingMinimumSpendMinimumCurrency.Mxn => "mxn",
                SetPackagePricingMinimumSpendMinimumCurrency.Myr => "myr",
                SetPackagePricingMinimumSpendMinimumCurrency.Mzn => "mzn",
                SetPackagePricingMinimumSpendMinimumCurrency.Nad => "nad",
                SetPackagePricingMinimumSpendMinimumCurrency.Ngn => "ngn",
                SetPackagePricingMinimumSpendMinimumCurrency.Nok => "nok",
                SetPackagePricingMinimumSpendMinimumCurrency.Npr => "npr",
                SetPackagePricingMinimumSpendMinimumCurrency.Nzd => "nzd",
                SetPackagePricingMinimumSpendMinimumCurrency.Pgk => "pgk",
                SetPackagePricingMinimumSpendMinimumCurrency.Php => "php",
                SetPackagePricingMinimumSpendMinimumCurrency.Pkr => "pkr",
                SetPackagePricingMinimumSpendMinimumCurrency.Pln => "pln",
                SetPackagePricingMinimumSpendMinimumCurrency.Qar => "qar",
                SetPackagePricingMinimumSpendMinimumCurrency.Ron => "ron",
                SetPackagePricingMinimumSpendMinimumCurrency.Rsd => "rsd",
                SetPackagePricingMinimumSpendMinimumCurrency.Rub => "rub",
                SetPackagePricingMinimumSpendMinimumCurrency.Rwf => "rwf",
                SetPackagePricingMinimumSpendMinimumCurrency.Sar => "sar",
                SetPackagePricingMinimumSpendMinimumCurrency.Sbd => "sbd",
                SetPackagePricingMinimumSpendMinimumCurrency.Scr => "scr",
                SetPackagePricingMinimumSpendMinimumCurrency.Sek => "sek",
                SetPackagePricingMinimumSpendMinimumCurrency.Sgd => "sgd",
                SetPackagePricingMinimumSpendMinimumCurrency.Sle => "sle",
                SetPackagePricingMinimumSpendMinimumCurrency.Sll => "sll",
                SetPackagePricingMinimumSpendMinimumCurrency.Sos => "sos",
                SetPackagePricingMinimumSpendMinimumCurrency.Szl => "szl",
                SetPackagePricingMinimumSpendMinimumCurrency.Thb => "thb",
                SetPackagePricingMinimumSpendMinimumCurrency.Tjs => "tjs",
                SetPackagePricingMinimumSpendMinimumCurrency.Top => "top",
                SetPackagePricingMinimumSpendMinimumCurrency.Try => "try",
                SetPackagePricingMinimumSpendMinimumCurrency.Ttd => "ttd",
                SetPackagePricingMinimumSpendMinimumCurrency.Tzs => "tzs",
                SetPackagePricingMinimumSpendMinimumCurrency.Uah => "uah",
                SetPackagePricingMinimumSpendMinimumCurrency.Uzs => "uzs",
                SetPackagePricingMinimumSpendMinimumCurrency.Vnd => "vnd",
                SetPackagePricingMinimumSpendMinimumCurrency.Vuv => "vuv",
                SetPackagePricingMinimumSpendMinimumCurrency.Wst => "wst",
                SetPackagePricingMinimumSpendMinimumCurrency.Xaf => "xaf",
                SetPackagePricingMinimumSpendMinimumCurrency.Xcd => "xcd",
                SetPackagePricingMinimumSpendMinimumCurrency.Yer => "yer",
                SetPackagePricingMinimumSpendMinimumCurrency.Zar => "zar",
                SetPackagePricingMinimumSpendMinimumCurrency.Zmw => "zmw",
                SetPackagePricingMinimumSpendMinimumCurrency.Clp => "clp",
                SetPackagePricingMinimumSpendMinimumCurrency.Djf => "djf",
                SetPackagePricingMinimumSpendMinimumCurrency.Gnf => "gnf",
                SetPackagePricingMinimumSpendMinimumCurrency.Ugx => "ugx",
                SetPackagePricingMinimumSpendMinimumCurrency.Pyg => "pyg",
                SetPackagePricingMinimumSpendMinimumCurrency.Xof => "xof",
                SetPackagePricingMinimumSpendMinimumCurrency.Xpf => "xpf",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// When overage charges are billed
/// </summary>
[JsonConverter(typeof(SetPackagePricingOverageBillingPeriodConverter))]
public enum SetPackagePricingOverageBillingPeriod
{
    OnSubscriptionRenewal,
    Monthly,
}

sealed class SetPackagePricingOverageBillingPeriodConverter
    : JsonConverter<SetPackagePricingOverageBillingPeriod>
{
    public override SetPackagePricingOverageBillingPeriod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ON_SUBSCRIPTION_RENEWAL" =>
                SetPackagePricingOverageBillingPeriod.OnSubscriptionRenewal,
            "MONTHLY" => SetPackagePricingOverageBillingPeriod.Monthly,
            _ => (SetPackagePricingOverageBillingPeriod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SetPackagePricingOverageBillingPeriod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SetPackagePricingOverageBillingPeriod.OnSubscriptionRenewal =>
                    "ON_SUBSCRIPTION_RENEWAL",
                SetPackagePricingOverageBillingPeriod.Monthly => "MONTHLY",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Overage pricing model configuration.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SetPackagePricingOveragePricingModel,
        SetPackagePricingOveragePricingModelFromRaw
    >)
)]
public sealed record class SetPackagePricingOveragePricingModel : JsonModel
{
    /// <summary>
    /// The billing model for overages
    /// </summary>
    public required ApiEnum<string, SetPackagePricingOveragePricingModelBillingModel> BillingModel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, SetPackagePricingOveragePricingModelBillingModel>
            >("billingModel");
        }
        init { this._rawData.Set("billingModel", value); }
    }

    /// <summary>
    /// Price periods for overage pricing
    /// </summary>
    public required IReadOnlyList<SetPackagePricingOveragePricingModelPricePeriod> PricePeriods
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<SetPackagePricingOveragePricingModelPricePeriod>
            >("pricePeriods");
        }
        init
        {
            this._rawData.Set<ImmutableArray<SetPackagePricingOveragePricingModelPricePeriod>>(
                "pricePeriods",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The billing cadence for overages
    /// </summary>
    public ApiEnum<string, SetPackagePricingOveragePricingModelBillingCadence>? BillingCadence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, SetPackagePricingOveragePricingModelBillingCadence>
            >("billingCadence");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("billingCadence", value);
        }
    }

    /// <summary>
    /// Entitlement configuration for the overage feature
    /// </summary>
    public SetPackagePricingOveragePricingModelEntitlement? Entitlement
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SetPackagePricingOveragePricingModelEntitlement>(
                "entitlement"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("entitlement", value);
        }
    }

    /// <summary>
    /// The feature ID for overage pricing
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

    /// <summary>
    /// Custom currency ID for overage top-up
    /// </summary>
    public string? TopUpCustomCurrencyID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("topUpCustomCurrencyId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("topUpCustomCurrencyId", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.BillingModel.Validate();
        foreach (var item in this.PricePeriods)
        {
            item.Validate();
        }
        this.BillingCadence?.Validate();
        this.Entitlement?.Validate();
        _ = this.FeatureID;
        _ = this.TopUpCustomCurrencyID;
    }

    public SetPackagePricingOveragePricingModel() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SetPackagePricingOveragePricingModel(
        SetPackagePricingOveragePricingModel setPackagePricingOveragePricingModel
    )
        : base(setPackagePricingOveragePricingModel) { }
#pragma warning restore CS8618

    public SetPackagePricingOveragePricingModel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SetPackagePricingOveragePricingModel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SetPackagePricingOveragePricingModelFromRaw.FromRawUnchecked"/>
    public static SetPackagePricingOveragePricingModel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SetPackagePricingOveragePricingModelFromRaw
    : IFromRawJson<SetPackagePricingOveragePricingModel>
{
    /// <inheritdoc/>
    public SetPackagePricingOveragePricingModel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SetPackagePricingOveragePricingModel.FromRawUnchecked(rawData);
}

/// <summary>
/// The billing model for overages
/// </summary>
[JsonConverter(typeof(SetPackagePricingOveragePricingModelBillingModelConverter))]
public enum SetPackagePricingOveragePricingModelBillingModel
{
    FlatFee,
    MinimumSpend,
    PerUnit,
    UsageBased,
    CreditBased,
}

sealed class SetPackagePricingOveragePricingModelBillingModelConverter
    : JsonConverter<SetPackagePricingOveragePricingModelBillingModel>
{
    public override SetPackagePricingOveragePricingModelBillingModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FLAT_FEE" => SetPackagePricingOveragePricingModelBillingModel.FlatFee,
            "MINIMUM_SPEND" => SetPackagePricingOveragePricingModelBillingModel.MinimumSpend,
            "PER_UNIT" => SetPackagePricingOveragePricingModelBillingModel.PerUnit,
            "USAGE_BASED" => SetPackagePricingOveragePricingModelBillingModel.UsageBased,
            "CREDIT_BASED" => SetPackagePricingOveragePricingModelBillingModel.CreditBased,
            _ => (SetPackagePricingOveragePricingModelBillingModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SetPackagePricingOveragePricingModelBillingModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SetPackagePricingOveragePricingModelBillingModel.FlatFee => "FLAT_FEE",
                SetPackagePricingOveragePricingModelBillingModel.MinimumSpend => "MINIMUM_SPEND",
                SetPackagePricingOveragePricingModelBillingModel.PerUnit => "PER_UNIT",
                SetPackagePricingOveragePricingModelBillingModel.UsageBased => "USAGE_BASED",
                SetPackagePricingOveragePricingModelBillingModel.CreditBased => "CREDIT_BASED",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Price configuration for a specific billing period.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SetPackagePricingOveragePricingModelPricePeriod,
        SetPackagePricingOveragePricingModelPricePeriodFromRaw
    >)
)]
public sealed record class SetPackagePricingOveragePricingModelPricePeriod : JsonModel
{
    /// <summary>
    /// The billing period (MONTHLY or ANNUALLY)
    /// </summary>
    public required ApiEnum<
        string,
        SetPackagePricingOveragePricingModelPricePeriodBillingPeriod
    > BillingPeriod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, SetPackagePricingOveragePricingModelPricePeriodBillingPeriod>
            >("billingPeriod");
        }
        init { this._rawData.Set("billingPeriod", value); }
    }

    /// <summary>
    /// ISO country code for localized pricing
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
    /// Block size for usage-based pricing
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
    /// When credits are granted
    /// </summary>
    public ApiEnum<
        string,
        SetPackagePricingOveragePricingModelPricePeriodCreditGrantCadence
    >? CreditGrantCadence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, SetPackagePricingOveragePricingModelPricePeriodCreditGrantCadence>
            >("creditGrantCadence");
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

    /// <summary>
    /// Credit rate configuration for credit-based pricing
    /// </summary>
    public SetPackagePricingOveragePricingModelPricePeriodCreditRate? CreditRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SetPackagePricingOveragePricingModelPricePeriodCreditRate>(
                "creditRate"
            );
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
    /// The price amount and currency
    /// </summary>
    public SetPackagePricingOveragePricingModelPricePeriodPrice? Price
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SetPackagePricingOveragePricingModelPricePeriodPrice>(
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
    /// Tiered pricing configuration
    /// </summary>
    public IReadOnlyList<SetPackagePricingOveragePricingModelPricePeriodTier>? Tiers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<SetPackagePricingOveragePricingModelPricePeriodTier>
            >("tiers");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<SetPackagePricingOveragePricingModelPricePeriodTier>?>(
                "tiers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.BillingPeriod.Validate();
        _ = this.BillingCountryCode;
        _ = this.BlockSize;
        this.CreditGrantCadence?.Validate();
        this.CreditRate?.Validate();
        this.Price?.Validate();
        foreach (var item in this.Tiers ?? [])
        {
            item.Validate();
        }
    }

    public SetPackagePricingOveragePricingModelPricePeriod() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SetPackagePricingOveragePricingModelPricePeriod(
        SetPackagePricingOveragePricingModelPricePeriod setPackagePricingOveragePricingModelPricePeriod
    )
        : base(setPackagePricingOveragePricingModelPricePeriod) { }
#pragma warning restore CS8618

    public SetPackagePricingOveragePricingModelPricePeriod(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SetPackagePricingOveragePricingModelPricePeriod(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SetPackagePricingOveragePricingModelPricePeriodFromRaw.FromRawUnchecked"/>
    public static SetPackagePricingOveragePricingModelPricePeriod FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SetPackagePricingOveragePricingModelPricePeriod(
        ApiEnum<string, SetPackagePricingOveragePricingModelPricePeriodBillingPeriod> billingPeriod
    )
        : this()
    {
        this.BillingPeriod = billingPeriod;
    }
}

class SetPackagePricingOveragePricingModelPricePeriodFromRaw
    : IFromRawJson<SetPackagePricingOveragePricingModelPricePeriod>
{
    /// <inheritdoc/>
    public SetPackagePricingOveragePricingModelPricePeriod FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SetPackagePricingOveragePricingModelPricePeriod.FromRawUnchecked(rawData);
}

/// <summary>
/// The billing period (MONTHLY or ANNUALLY)
/// </summary>
[JsonConverter(typeof(SetPackagePricingOveragePricingModelPricePeriodBillingPeriodConverter))]
public enum SetPackagePricingOveragePricingModelPricePeriodBillingPeriod
{
    Monthly,
    Annually,
}

sealed class SetPackagePricingOveragePricingModelPricePeriodBillingPeriodConverter
    : JsonConverter<SetPackagePricingOveragePricingModelPricePeriodBillingPeriod>
{
    public override SetPackagePricingOveragePricingModelPricePeriodBillingPeriod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "MONTHLY" => SetPackagePricingOveragePricingModelPricePeriodBillingPeriod.Monthly,
            "ANNUALLY" => SetPackagePricingOveragePricingModelPricePeriodBillingPeriod.Annually,
            _ => (SetPackagePricingOveragePricingModelPricePeriodBillingPeriod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SetPackagePricingOveragePricingModelPricePeriodBillingPeriod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SetPackagePricingOveragePricingModelPricePeriodBillingPeriod.Monthly => "MONTHLY",
                SetPackagePricingOveragePricingModelPricePeriodBillingPeriod.Annually => "ANNUALLY",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// When credits are granted
/// </summary>
[JsonConverter(typeof(SetPackagePricingOveragePricingModelPricePeriodCreditGrantCadenceConverter))]
public enum SetPackagePricingOveragePricingModelPricePeriodCreditGrantCadence
{
    BeginningOfBillingPeriod,
    Monthly,
}

sealed class SetPackagePricingOveragePricingModelPricePeriodCreditGrantCadenceConverter
    : JsonConverter<SetPackagePricingOveragePricingModelPricePeriodCreditGrantCadence>
{
    public override SetPackagePricingOveragePricingModelPricePeriodCreditGrantCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "BEGINNING_OF_BILLING_PERIOD" =>
                SetPackagePricingOveragePricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
            "MONTHLY" => SetPackagePricingOveragePricingModelPricePeriodCreditGrantCadence.Monthly,
            _ => (SetPackagePricingOveragePricingModelPricePeriodCreditGrantCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SetPackagePricingOveragePricingModelPricePeriodCreditGrantCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SetPackagePricingOveragePricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod =>
                    "BEGINNING_OF_BILLING_PERIOD",
                SetPackagePricingOveragePricingModelPricePeriodCreditGrantCadence.Monthly =>
                    "MONTHLY",
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
        SetPackagePricingOveragePricingModelPricePeriodCreditRate,
        SetPackagePricingOveragePricingModelPricePeriodCreditRateFromRaw
    >)
)]
public sealed record class SetPackagePricingOveragePricingModelPricePeriodCreditRate : JsonModel
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
    /// The custom currency ID
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
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("costFormula", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.CurrencyID;
        _ = this.CostFormula;
    }

    public SetPackagePricingOveragePricingModelPricePeriodCreditRate() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SetPackagePricingOveragePricingModelPricePeriodCreditRate(
        SetPackagePricingOveragePricingModelPricePeriodCreditRate setPackagePricingOveragePricingModelPricePeriodCreditRate
    )
        : base(setPackagePricingOveragePricingModelPricePeriodCreditRate) { }
#pragma warning restore CS8618

    public SetPackagePricingOveragePricingModelPricePeriodCreditRate(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SetPackagePricingOveragePricingModelPricePeriodCreditRate(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SetPackagePricingOveragePricingModelPricePeriodCreditRateFromRaw.FromRawUnchecked"/>
    public static SetPackagePricingOveragePricingModelPricePeriodCreditRate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SetPackagePricingOveragePricingModelPricePeriodCreditRateFromRaw
    : IFromRawJson<SetPackagePricingOveragePricingModelPricePeriodCreditRate>
{
    /// <inheritdoc/>
    public SetPackagePricingOveragePricingModelPricePeriodCreditRate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SetPackagePricingOveragePricingModelPricePeriodCreditRate.FromRawUnchecked(rawData);
}

/// <summary>
/// The price amount and currency
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SetPackagePricingOveragePricingModelPricePeriodPrice,
        SetPackagePricingOveragePricingModelPricePeriodPriceFromRaw
    >)
)]
public sealed record class SetPackagePricingOveragePricingModelPricePeriodPrice : JsonModel
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
    /// The price currency
    /// </summary>
    public ApiEnum<string, SetPackagePricingOveragePricingModelPricePeriodPriceCurrency>? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, SetPackagePricingOveragePricingModelPricePeriodPriceCurrency>
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
        this.Currency?.Validate();
    }

    public SetPackagePricingOveragePricingModelPricePeriodPrice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SetPackagePricingOveragePricingModelPricePeriodPrice(
        SetPackagePricingOveragePricingModelPricePeriodPrice setPackagePricingOveragePricingModelPricePeriodPrice
    )
        : base(setPackagePricingOveragePricingModelPricePeriodPrice) { }
#pragma warning restore CS8618

    public SetPackagePricingOveragePricingModelPricePeriodPrice(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SetPackagePricingOveragePricingModelPricePeriodPrice(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SetPackagePricingOveragePricingModelPricePeriodPriceFromRaw.FromRawUnchecked"/>
    public static SetPackagePricingOveragePricingModelPricePeriodPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SetPackagePricingOveragePricingModelPricePeriodPrice(double amount)
        : this()
    {
        this.Amount = amount;
    }
}

class SetPackagePricingOveragePricingModelPricePeriodPriceFromRaw
    : IFromRawJson<SetPackagePricingOveragePricingModelPricePeriodPrice>
{
    /// <inheritdoc/>
    public SetPackagePricingOveragePricingModelPricePeriodPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SetPackagePricingOveragePricingModelPricePeriodPrice.FromRawUnchecked(rawData);
}

/// <summary>
/// The price currency
/// </summary>
[JsonConverter(typeof(SetPackagePricingOveragePricingModelPricePeriodPriceCurrencyConverter))]
public enum SetPackagePricingOveragePricingModelPricePeriodPriceCurrency
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

sealed class SetPackagePricingOveragePricingModelPricePeriodPriceCurrencyConverter
    : JsonConverter<SetPackagePricingOveragePricingModelPricePeriodPriceCurrency>
{
    public override SetPackagePricingOveragePricingModelPricePeriodPriceCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Usd,
            "aed" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Aed,
            "all" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.All,
            "amd" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Amd,
            "ang" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Ang,
            "aud" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Aud,
            "awg" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Awg,
            "azn" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Azn,
            "bam" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Bam,
            "bbd" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Bbd,
            "bdt" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Bdt,
            "bgn" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Bgn,
            "bif" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Bif,
            "bmd" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Bmd,
            "bnd" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Bnd,
            "bsd" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Bsd,
            "bwp" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Bwp,
            "byn" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Byn,
            "bzd" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Bzd,
            "brl" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Brl,
            "cad" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Cad,
            "cdf" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Cdf,
            "chf" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Chf,
            "cny" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Cny,
            "czk" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Czk,
            "dkk" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Dkk,
            "dop" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Dop,
            "dzd" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Dzd,
            "egp" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Egp,
            "etb" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Etb,
            "eur" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Eur,
            "fjd" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Fjd,
            "gbp" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Gbp,
            "gel" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Gel,
            "gip" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Gip,
            "gmd" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Gmd,
            "gyd" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Gyd,
            "hkd" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Hkd,
            "hrk" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Hrk,
            "htg" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Htg,
            "idr" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Idr,
            "ils" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Ils,
            "inr" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Inr,
            "isk" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Isk,
            "jmd" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Jmd,
            "jpy" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Jpy,
            "kes" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Kes,
            "kgs" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Kgs,
            "khr" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Khr,
            "kmf" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Kmf,
            "krw" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Krw,
            "kyd" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Kyd,
            "kzt" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Kzt,
            "lbp" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Lbp,
            "lkr" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Lkr,
            "lrd" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Lrd,
            "lsl" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Lsl,
            "mad" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Mad,
            "mdl" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Mdl,
            "mga" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Mga,
            "mkd" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Mkd,
            "mmk" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Mmk,
            "mnt" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Mnt,
            "mop" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Mop,
            "mro" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Mro,
            "mvr" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Mvr,
            "mwk" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Mwk,
            "mxn" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Mxn,
            "myr" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Myr,
            "mzn" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Mzn,
            "nad" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Nad,
            "ngn" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Ngn,
            "nok" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Nok,
            "npr" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Npr,
            "nzd" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Nzd,
            "pgk" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Pgk,
            "php" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Php,
            "pkr" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Pkr,
            "pln" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Pln,
            "qar" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Qar,
            "ron" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Ron,
            "rsd" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Rsd,
            "rub" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Rub,
            "rwf" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Rwf,
            "sar" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Sar,
            "sbd" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Sbd,
            "scr" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Scr,
            "sek" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Sek,
            "sgd" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Sgd,
            "sle" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Sle,
            "sll" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Sll,
            "sos" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Sos,
            "szl" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Szl,
            "thb" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Thb,
            "tjs" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Tjs,
            "top" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Top,
            "try" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Try,
            "ttd" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Ttd,
            "tzs" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Tzs,
            "uah" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Uah,
            "uzs" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Uzs,
            "vnd" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Vnd,
            "vuv" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Vuv,
            "wst" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Wst,
            "xaf" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Xaf,
            "xcd" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Xcd,
            "yer" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Yer,
            "zar" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Zar,
            "zmw" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Zmw,
            "clp" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Clp,
            "djf" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Djf,
            "gnf" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Gnf,
            "ugx" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Ugx,
            "pyg" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Pyg,
            "xof" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Xof,
            "xpf" => SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Xpf,
            _ => (SetPackagePricingOveragePricingModelPricePeriodPriceCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SetPackagePricingOveragePricingModelPricePeriodPriceCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Usd => "usd",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Aed => "aed",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.All => "all",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Amd => "amd",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Ang => "ang",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Aud => "aud",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Awg => "awg",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Azn => "azn",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Bam => "bam",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Bbd => "bbd",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Bdt => "bdt",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Bgn => "bgn",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Bif => "bif",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Bmd => "bmd",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Bnd => "bnd",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Bsd => "bsd",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Bwp => "bwp",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Byn => "byn",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Bzd => "bzd",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Brl => "brl",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Cad => "cad",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Cdf => "cdf",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Chf => "chf",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Cny => "cny",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Czk => "czk",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Dkk => "dkk",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Dop => "dop",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Dzd => "dzd",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Egp => "egp",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Etb => "etb",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Eur => "eur",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Fjd => "fjd",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Gbp => "gbp",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Gel => "gel",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Gip => "gip",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Gmd => "gmd",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Gyd => "gyd",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Hkd => "hkd",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Hrk => "hrk",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Htg => "htg",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Idr => "idr",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Ils => "ils",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Inr => "inr",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Isk => "isk",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Jmd => "jmd",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Jpy => "jpy",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Kes => "kes",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Kgs => "kgs",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Khr => "khr",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Kmf => "kmf",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Krw => "krw",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Kyd => "kyd",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Kzt => "kzt",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Lbp => "lbp",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Lkr => "lkr",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Lrd => "lrd",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Lsl => "lsl",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Mad => "mad",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Mdl => "mdl",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Mga => "mga",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Mkd => "mkd",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Mmk => "mmk",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Mnt => "mnt",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Mop => "mop",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Mro => "mro",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Mvr => "mvr",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Mwk => "mwk",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Mxn => "mxn",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Myr => "myr",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Mzn => "mzn",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Nad => "nad",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Ngn => "ngn",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Nok => "nok",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Npr => "npr",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Nzd => "nzd",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Pgk => "pgk",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Php => "php",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Pkr => "pkr",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Pln => "pln",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Qar => "qar",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Ron => "ron",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Rsd => "rsd",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Rub => "rub",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Rwf => "rwf",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Sar => "sar",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Sbd => "sbd",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Scr => "scr",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Sek => "sek",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Sgd => "sgd",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Sle => "sle",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Sll => "sll",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Sos => "sos",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Szl => "szl",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Thb => "thb",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Tjs => "tjs",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Top => "top",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Try => "try",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Ttd => "ttd",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Tzs => "tzs",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Uah => "uah",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Uzs => "uzs",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Vnd => "vnd",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Vuv => "vuv",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Wst => "wst",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Xaf => "xaf",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Xcd => "xcd",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Yer => "yer",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Zar => "zar",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Zmw => "zmw",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Clp => "clp",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Djf => "djf",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Gnf => "gnf",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Ugx => "ugx",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Pyg => "pyg",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Xof => "xof",
                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Xpf => "xpf",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A tier in tiered pricing.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SetPackagePricingOveragePricingModelPricePeriodTier,
        SetPackagePricingOveragePricingModelPricePeriodTierFromRaw
    >)
)]
public sealed record class SetPackagePricingOveragePricingModelPricePeriodTier : JsonModel
{
    /// <summary>
    /// Flat price for this tier
    /// </summary>
    public SetPackagePricingOveragePricingModelPricePeriodTierFlatPrice? FlatPrice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SetPackagePricingOveragePricingModelPricePeriodTierFlatPrice>(
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
    /// Per-unit price in this tier
    /// </summary>
    public SetPackagePricingOveragePricingModelPricePeriodTierUnitPrice? UnitPrice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SetPackagePricingOveragePricingModelPricePeriodTierUnitPrice>(
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
    /// Upper bound of this tier (null for unlimited)
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

    public SetPackagePricingOveragePricingModelPricePeriodTier() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SetPackagePricingOveragePricingModelPricePeriodTier(
        SetPackagePricingOveragePricingModelPricePeriodTier setPackagePricingOveragePricingModelPricePeriodTier
    )
        : base(setPackagePricingOveragePricingModelPricePeriodTier) { }
#pragma warning restore CS8618

    public SetPackagePricingOveragePricingModelPricePeriodTier(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SetPackagePricingOveragePricingModelPricePeriodTier(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SetPackagePricingOveragePricingModelPricePeriodTierFromRaw.FromRawUnchecked"/>
    public static SetPackagePricingOveragePricingModelPricePeriodTier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SetPackagePricingOveragePricingModelPricePeriodTierFromRaw
    : IFromRawJson<SetPackagePricingOveragePricingModelPricePeriodTier>
{
    /// <inheritdoc/>
    public SetPackagePricingOveragePricingModelPricePeriodTier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SetPackagePricingOveragePricingModelPricePeriodTier.FromRawUnchecked(rawData);
}

/// <summary>
/// Flat price for this tier
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SetPackagePricingOveragePricingModelPricePeriodTierFlatPrice,
        SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceFromRaw
    >)
)]
public sealed record class SetPackagePricingOveragePricingModelPricePeriodTierFlatPrice : JsonModel
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
    /// The price currency
    /// </summary>
    public ApiEnum<
        string,
        SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency
    >? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<
                    string,
                    SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency
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
        this.Currency?.Validate();
    }

    public SetPackagePricingOveragePricingModelPricePeriodTierFlatPrice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SetPackagePricingOveragePricingModelPricePeriodTierFlatPrice(
        SetPackagePricingOveragePricingModelPricePeriodTierFlatPrice setPackagePricingOveragePricingModelPricePeriodTierFlatPrice
    )
        : base(setPackagePricingOveragePricingModelPricePeriodTierFlatPrice) { }
#pragma warning restore CS8618

    public SetPackagePricingOveragePricingModelPricePeriodTierFlatPrice(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SetPackagePricingOveragePricingModelPricePeriodTierFlatPrice(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceFromRaw.FromRawUnchecked"/>
    public static SetPackagePricingOveragePricingModelPricePeriodTierFlatPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SetPackagePricingOveragePricingModelPricePeriodTierFlatPrice(double amount)
        : this()
    {
        this.Amount = amount;
    }
}

class SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceFromRaw
    : IFromRawJson<SetPackagePricingOveragePricingModelPricePeriodTierFlatPrice>
{
    /// <inheritdoc/>
    public SetPackagePricingOveragePricingModelPricePeriodTierFlatPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SetPackagePricingOveragePricingModelPricePeriodTierFlatPrice.FromRawUnchecked(rawData);
}

/// <summary>
/// The price currency
/// </summary>
[JsonConverter(
    typeof(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrencyConverter)
)]
public enum SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency
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

sealed class SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrencyConverter
    : JsonConverter<SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency>
{
    public override SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Usd,
            "aed" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Aed,
            "all" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.All,
            "amd" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Amd,
            "ang" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Ang,
            "aud" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Aud,
            "awg" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Awg,
            "azn" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Azn,
            "bam" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Bam,
            "bbd" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Bbd,
            "bdt" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Bdt,
            "bgn" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Bgn,
            "bif" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Bif,
            "bmd" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Bmd,
            "bnd" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Bnd,
            "bsd" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Bsd,
            "bwp" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Bwp,
            "byn" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Byn,
            "bzd" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Bzd,
            "brl" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Brl,
            "cad" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Cad,
            "cdf" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Cdf,
            "chf" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Chf,
            "cny" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Cny,
            "czk" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Czk,
            "dkk" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Dkk,
            "dop" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Dop,
            "dzd" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Dzd,
            "egp" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Egp,
            "etb" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Etb,
            "eur" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Eur,
            "fjd" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Fjd,
            "gbp" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Gbp,
            "gel" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Gel,
            "gip" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Gip,
            "gmd" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Gmd,
            "gyd" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Gyd,
            "hkd" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Hkd,
            "hrk" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Hrk,
            "htg" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Htg,
            "idr" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Idr,
            "ils" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Ils,
            "inr" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Inr,
            "isk" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Isk,
            "jmd" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Jmd,
            "jpy" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Jpy,
            "kes" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Kes,
            "kgs" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Kgs,
            "khr" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Khr,
            "kmf" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Kmf,
            "krw" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Krw,
            "kyd" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Kyd,
            "kzt" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Kzt,
            "lbp" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Lbp,
            "lkr" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Lkr,
            "lrd" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Lrd,
            "lsl" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Lsl,
            "mad" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Mad,
            "mdl" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Mdl,
            "mga" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Mga,
            "mkd" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Mkd,
            "mmk" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Mmk,
            "mnt" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Mnt,
            "mop" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Mop,
            "mro" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Mro,
            "mvr" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Mvr,
            "mwk" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Mwk,
            "mxn" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Mxn,
            "myr" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Myr,
            "mzn" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Mzn,
            "nad" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Nad,
            "ngn" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Ngn,
            "nok" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Nok,
            "npr" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Npr,
            "nzd" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Nzd,
            "pgk" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Pgk,
            "php" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Php,
            "pkr" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Pkr,
            "pln" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Pln,
            "qar" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Qar,
            "ron" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Ron,
            "rsd" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Rsd,
            "rub" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Rub,
            "rwf" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Rwf,
            "sar" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Sar,
            "sbd" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Sbd,
            "scr" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Scr,
            "sek" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Sek,
            "sgd" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Sgd,
            "sle" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Sle,
            "sll" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Sll,
            "sos" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Sos,
            "szl" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Szl,
            "thb" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Thb,
            "tjs" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Tjs,
            "top" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Top,
            "try" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Try,
            "ttd" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Ttd,
            "tzs" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Tzs,
            "uah" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Uah,
            "uzs" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Uzs,
            "vnd" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Vnd,
            "vuv" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Vuv,
            "wst" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Wst,
            "xaf" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Xaf,
            "xcd" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Xcd,
            "yer" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Yer,
            "zar" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Zar,
            "zmw" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Zmw,
            "clp" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Clp,
            "djf" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Djf,
            "gnf" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Gnf,
            "ugx" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Ugx,
            "pyg" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Pyg,
            "xof" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Xof,
            "xpf" => SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Xpf,
            _ => (SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Usd => "usd",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Aed => "aed",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.All => "all",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Amd => "amd",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Ang => "ang",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Aud => "aud",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Awg => "awg",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Azn => "azn",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Bam => "bam",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Bbd => "bbd",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Bdt => "bdt",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Bgn => "bgn",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Bif => "bif",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Bmd => "bmd",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Bnd => "bnd",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Bsd => "bsd",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Bwp => "bwp",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Byn => "byn",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Bzd => "bzd",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Brl => "brl",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Cad => "cad",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Cdf => "cdf",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Chf => "chf",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Cny => "cny",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Czk => "czk",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Dkk => "dkk",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Dop => "dop",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Dzd => "dzd",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Egp => "egp",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Etb => "etb",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Eur => "eur",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Fjd => "fjd",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Gbp => "gbp",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Gel => "gel",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Gip => "gip",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Gmd => "gmd",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Gyd => "gyd",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Hkd => "hkd",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Hrk => "hrk",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Htg => "htg",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Idr => "idr",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Ils => "ils",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Inr => "inr",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Isk => "isk",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Jmd => "jmd",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Jpy => "jpy",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Kes => "kes",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Kgs => "kgs",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Khr => "khr",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Kmf => "kmf",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Krw => "krw",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Kyd => "kyd",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Kzt => "kzt",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Lbp => "lbp",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Lkr => "lkr",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Lrd => "lrd",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Lsl => "lsl",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Mad => "mad",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Mdl => "mdl",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Mga => "mga",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Mkd => "mkd",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Mmk => "mmk",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Mnt => "mnt",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Mop => "mop",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Mro => "mro",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Mvr => "mvr",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Mwk => "mwk",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Mxn => "mxn",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Myr => "myr",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Mzn => "mzn",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Nad => "nad",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Ngn => "ngn",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Nok => "nok",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Npr => "npr",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Nzd => "nzd",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Pgk => "pgk",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Php => "php",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Pkr => "pkr",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Pln => "pln",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Qar => "qar",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Ron => "ron",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Rsd => "rsd",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Rub => "rub",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Rwf => "rwf",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Sar => "sar",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Sbd => "sbd",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Scr => "scr",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Sek => "sek",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Sgd => "sgd",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Sle => "sle",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Sll => "sll",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Sos => "sos",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Szl => "szl",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Thb => "thb",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Tjs => "tjs",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Top => "top",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Try => "try",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Ttd => "ttd",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Tzs => "tzs",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Uah => "uah",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Uzs => "uzs",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Vnd => "vnd",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Vuv => "vuv",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Wst => "wst",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Xaf => "xaf",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Xcd => "xcd",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Yer => "yer",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Zar => "zar",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Zmw => "zmw",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Clp => "clp",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Djf => "djf",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Gnf => "gnf",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Ugx => "ugx",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Pyg => "pyg",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Xof => "xof",
                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Xpf => "xpf",
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
        SetPackagePricingOveragePricingModelPricePeriodTierUnitPrice,
        SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceFromRaw
    >)
)]
public sealed record class SetPackagePricingOveragePricingModelPricePeriodTierUnitPrice : JsonModel
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
    /// The price currency
    /// </summary>
    public ApiEnum<
        string,
        SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency
    >? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<
                    string,
                    SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency
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
        this.Currency?.Validate();
    }

    public SetPackagePricingOveragePricingModelPricePeriodTierUnitPrice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SetPackagePricingOveragePricingModelPricePeriodTierUnitPrice(
        SetPackagePricingOveragePricingModelPricePeriodTierUnitPrice setPackagePricingOveragePricingModelPricePeriodTierUnitPrice
    )
        : base(setPackagePricingOveragePricingModelPricePeriodTierUnitPrice) { }
#pragma warning restore CS8618

    public SetPackagePricingOveragePricingModelPricePeriodTierUnitPrice(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SetPackagePricingOveragePricingModelPricePeriodTierUnitPrice(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceFromRaw.FromRawUnchecked"/>
    public static SetPackagePricingOveragePricingModelPricePeriodTierUnitPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SetPackagePricingOveragePricingModelPricePeriodTierUnitPrice(double amount)
        : this()
    {
        this.Amount = amount;
    }
}

class SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceFromRaw
    : IFromRawJson<SetPackagePricingOveragePricingModelPricePeriodTierUnitPrice>
{
    /// <inheritdoc/>
    public SetPackagePricingOveragePricingModelPricePeriodTierUnitPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SetPackagePricingOveragePricingModelPricePeriodTierUnitPrice.FromRawUnchecked(rawData);
}

/// <summary>
/// The price currency
/// </summary>
[JsonConverter(
    typeof(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrencyConverter)
)]
public enum SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency
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

sealed class SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrencyConverter
    : JsonConverter<SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency>
{
    public override SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Usd,
            "aed" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Aed,
            "all" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.All,
            "amd" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Amd,
            "ang" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Ang,
            "aud" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Aud,
            "awg" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Awg,
            "azn" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Azn,
            "bam" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Bam,
            "bbd" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Bbd,
            "bdt" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Bdt,
            "bgn" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Bgn,
            "bif" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Bif,
            "bmd" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Bmd,
            "bnd" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Bnd,
            "bsd" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Bsd,
            "bwp" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Bwp,
            "byn" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Byn,
            "bzd" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Bzd,
            "brl" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Brl,
            "cad" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Cad,
            "cdf" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Cdf,
            "chf" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Chf,
            "cny" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Cny,
            "czk" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Czk,
            "dkk" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Dkk,
            "dop" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Dop,
            "dzd" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Dzd,
            "egp" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Egp,
            "etb" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Etb,
            "eur" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Eur,
            "fjd" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Fjd,
            "gbp" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Gbp,
            "gel" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Gel,
            "gip" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Gip,
            "gmd" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Gmd,
            "gyd" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Gyd,
            "hkd" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Hkd,
            "hrk" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Hrk,
            "htg" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Htg,
            "idr" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Idr,
            "ils" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Ils,
            "inr" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Inr,
            "isk" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Isk,
            "jmd" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Jmd,
            "jpy" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Jpy,
            "kes" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Kes,
            "kgs" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Kgs,
            "khr" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Khr,
            "kmf" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Kmf,
            "krw" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Krw,
            "kyd" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Kyd,
            "kzt" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Kzt,
            "lbp" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Lbp,
            "lkr" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Lkr,
            "lrd" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Lrd,
            "lsl" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Lsl,
            "mad" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Mad,
            "mdl" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Mdl,
            "mga" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Mga,
            "mkd" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Mkd,
            "mmk" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Mmk,
            "mnt" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Mnt,
            "mop" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Mop,
            "mro" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Mro,
            "mvr" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Mvr,
            "mwk" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Mwk,
            "mxn" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Mxn,
            "myr" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Myr,
            "mzn" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Mzn,
            "nad" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Nad,
            "ngn" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Ngn,
            "nok" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Nok,
            "npr" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Npr,
            "nzd" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Nzd,
            "pgk" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Pgk,
            "php" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Php,
            "pkr" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Pkr,
            "pln" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Pln,
            "qar" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Qar,
            "ron" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Ron,
            "rsd" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Rsd,
            "rub" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Rub,
            "rwf" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Rwf,
            "sar" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Sar,
            "sbd" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Sbd,
            "scr" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Scr,
            "sek" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Sek,
            "sgd" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Sgd,
            "sle" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Sle,
            "sll" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Sll,
            "sos" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Sos,
            "szl" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Szl,
            "thb" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Thb,
            "tjs" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Tjs,
            "top" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Top,
            "try" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Try,
            "ttd" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Ttd,
            "tzs" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Tzs,
            "uah" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Uah,
            "uzs" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Uzs,
            "vnd" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Vnd,
            "vuv" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Vuv,
            "wst" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Wst,
            "xaf" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Xaf,
            "xcd" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Xcd,
            "yer" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Yer,
            "zar" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Zar,
            "zmw" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Zmw,
            "clp" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Clp,
            "djf" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Djf,
            "gnf" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Gnf,
            "ugx" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Ugx,
            "pyg" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Pyg,
            "xof" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Xof,
            "xpf" => SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Xpf,
            _ => (SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Usd => "usd",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Aed => "aed",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.All => "all",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Amd => "amd",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Ang => "ang",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Aud => "aud",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Awg => "awg",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Azn => "azn",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Bam => "bam",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Bbd => "bbd",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Bdt => "bdt",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Bgn => "bgn",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Bif => "bif",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Bmd => "bmd",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Bnd => "bnd",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Bsd => "bsd",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Bwp => "bwp",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Byn => "byn",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Bzd => "bzd",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Brl => "brl",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Cad => "cad",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Cdf => "cdf",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Chf => "chf",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Cny => "cny",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Czk => "czk",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Dkk => "dkk",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Dop => "dop",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Dzd => "dzd",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Egp => "egp",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Etb => "etb",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Eur => "eur",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Fjd => "fjd",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Gbp => "gbp",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Gel => "gel",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Gip => "gip",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Gmd => "gmd",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Gyd => "gyd",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Hkd => "hkd",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Hrk => "hrk",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Htg => "htg",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Idr => "idr",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Ils => "ils",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Inr => "inr",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Isk => "isk",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Jmd => "jmd",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Jpy => "jpy",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Kes => "kes",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Kgs => "kgs",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Khr => "khr",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Kmf => "kmf",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Krw => "krw",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Kyd => "kyd",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Kzt => "kzt",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Lbp => "lbp",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Lkr => "lkr",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Lrd => "lrd",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Lsl => "lsl",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Mad => "mad",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Mdl => "mdl",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Mga => "mga",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Mkd => "mkd",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Mmk => "mmk",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Mnt => "mnt",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Mop => "mop",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Mro => "mro",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Mvr => "mvr",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Mwk => "mwk",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Mxn => "mxn",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Myr => "myr",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Mzn => "mzn",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Nad => "nad",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Ngn => "ngn",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Nok => "nok",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Npr => "npr",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Nzd => "nzd",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Pgk => "pgk",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Php => "php",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Pkr => "pkr",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Pln => "pln",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Qar => "qar",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Ron => "ron",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Rsd => "rsd",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Rub => "rub",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Rwf => "rwf",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Sar => "sar",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Sbd => "sbd",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Scr => "scr",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Sek => "sek",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Sgd => "sgd",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Sle => "sle",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Sll => "sll",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Sos => "sos",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Szl => "szl",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Thb => "thb",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Tjs => "tjs",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Top => "top",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Try => "try",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Ttd => "ttd",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Tzs => "tzs",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Uah => "uah",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Uzs => "uzs",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Vnd => "vnd",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Vuv => "vuv",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Wst => "wst",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Xaf => "xaf",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Xcd => "xcd",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Yer => "yer",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Zar => "zar",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Zmw => "zmw",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Clp => "clp",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Djf => "djf",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Gnf => "gnf",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Ugx => "ugx",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Pyg => "pyg",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Xof => "xof",
                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Xpf => "xpf",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The billing cadence for overages
/// </summary>
[JsonConverter(typeof(SetPackagePricingOveragePricingModelBillingCadenceConverter))]
public enum SetPackagePricingOveragePricingModelBillingCadence
{
    Recurring,
    OneOff,
}

sealed class SetPackagePricingOveragePricingModelBillingCadenceConverter
    : JsonConverter<SetPackagePricingOveragePricingModelBillingCadence>
{
    public override SetPackagePricingOveragePricingModelBillingCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "RECURRING" => SetPackagePricingOveragePricingModelBillingCadence.Recurring,
            "ONE_OFF" => SetPackagePricingOveragePricingModelBillingCadence.OneOff,
            _ => (SetPackagePricingOveragePricingModelBillingCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SetPackagePricingOveragePricingModelBillingCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SetPackagePricingOveragePricingModelBillingCadence.Recurring => "RECURRING",
                SetPackagePricingOveragePricingModelBillingCadence.OneOff => "ONE_OFF",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Entitlement configuration for the overage feature
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SetPackagePricingOveragePricingModelEntitlement,
        SetPackagePricingOveragePricingModelEntitlementFromRaw
    >)
)]
public sealed record class SetPackagePricingOveragePricingModelEntitlement : JsonModel
{
    /// <summary>
    /// The feature ID for the entitlement
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

    /// <summary>
    /// Whether the limit is soft (allows overage)
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
    /// Monthly reset configuration
    /// </summary>
    public SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfiguration? MonthlyResetPeriodConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfiguration>(
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

    /// <summary>
    /// The usage reset period
    /// </summary>
    public ApiEnum<string, SetPackagePricingOveragePricingModelEntitlementResetPeriod>? ResetPeriod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, SetPackagePricingOveragePricingModelEntitlementResetPeriod>
            >("resetPeriod");
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
    /// The usage limit before overage kicks in
    /// </summary>
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

    /// <summary>
    /// Weekly reset configuration
    /// </summary>
    public SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfiguration? WeeklyResetPeriodConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfiguration>(
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

    /// <summary>
    /// Yearly reset configuration
    /// </summary>
    public SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfiguration? YearlyResetPeriodConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfiguration>(
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
        _ = this.FeatureID;
        _ = this.HasSoftLimit;
        _ = this.HasUnlimitedUsage;
        this.MonthlyResetPeriodConfiguration?.Validate();
        this.ResetPeriod?.Validate();
        _ = this.UsageLimit;
        this.WeeklyResetPeriodConfiguration?.Validate();
        this.YearlyResetPeriodConfiguration?.Validate();
    }

    public SetPackagePricingOveragePricingModelEntitlement() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SetPackagePricingOveragePricingModelEntitlement(
        SetPackagePricingOveragePricingModelEntitlement setPackagePricingOveragePricingModelEntitlement
    )
        : base(setPackagePricingOveragePricingModelEntitlement) { }
#pragma warning restore CS8618

    public SetPackagePricingOveragePricingModelEntitlement(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SetPackagePricingOveragePricingModelEntitlement(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SetPackagePricingOveragePricingModelEntitlementFromRaw.FromRawUnchecked"/>
    public static SetPackagePricingOveragePricingModelEntitlement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SetPackagePricingOveragePricingModelEntitlement(string featureID)
        : this()
    {
        this.FeatureID = featureID;
    }
}

class SetPackagePricingOveragePricingModelEntitlementFromRaw
    : IFromRawJson<SetPackagePricingOveragePricingModelEntitlement>
{
    /// <inheritdoc/>
    public SetPackagePricingOveragePricingModelEntitlement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SetPackagePricingOveragePricingModelEntitlement.FromRawUnchecked(rawData);
}

/// <summary>
/// Monthly reset configuration
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfiguration,
        SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfigurationFromRaw
    >)
)]
public sealed record class SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfiguration
    : JsonModel
{
    /// <summary>
    /// Reset anchor (SubscriptionStart or StartOfTheMonth)
    /// </summary>
    public required ApiEnum<
        string,
        SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfigurationAccordingTo
    > AccordingTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfigurationAccordingTo
                >
            >("accordingTo");
        }
        init { this._rawData.Set("accordingTo", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.AccordingTo.Validate();
    }

    public SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfiguration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfiguration(
        SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfiguration setPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfiguration
    )
        : base(setPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfiguration) { }
#pragma warning restore CS8618

    public SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfiguration(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfiguration(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfigurationFromRaw.FromRawUnchecked"/>
    public static SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfiguration(
        ApiEnum<
            string,
            SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfigurationAccordingTo
        > accordingTo
    )
        : this()
    {
        this.AccordingTo = accordingTo;
    }
}

class SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfigurationFromRaw
    : IFromRawJson<SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfiguration>
{
    /// <inheritdoc/>
    public SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfiguration.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Reset anchor (SubscriptionStart or StartOfTheMonth)
/// </summary>
[JsonConverter(
    typeof(SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfigurationAccordingToConverter)
)]
public enum SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfigurationAccordingTo
{
    SubscriptionStart,
    StartOfTheMonth,
}

sealed class SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfigurationAccordingToConverter
    : JsonConverter<SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfigurationAccordingTo>
{
    public override SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfigurationAccordingTo Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SubscriptionStart" =>
                SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
            "StartOfTheMonth" =>
                SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfigurationAccordingTo.StartOfTheMonth,
            _ =>
                (SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfigurationAccordingTo)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfigurationAccordingTo value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart =>
                    "SubscriptionStart",
                SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfigurationAccordingTo.StartOfTheMonth =>
                    "StartOfTheMonth",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The usage reset period
/// </summary>
[JsonConverter(typeof(SetPackagePricingOveragePricingModelEntitlementResetPeriodConverter))]
public enum SetPackagePricingOveragePricingModelEntitlementResetPeriod
{
    Year,
    Month,
    Week,
    Day,
    Hour,
}

sealed class SetPackagePricingOveragePricingModelEntitlementResetPeriodConverter
    : JsonConverter<SetPackagePricingOveragePricingModelEntitlementResetPeriod>
{
    public override SetPackagePricingOveragePricingModelEntitlementResetPeriod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "YEAR" => SetPackagePricingOveragePricingModelEntitlementResetPeriod.Year,
            "MONTH" => SetPackagePricingOveragePricingModelEntitlementResetPeriod.Month,
            "WEEK" => SetPackagePricingOveragePricingModelEntitlementResetPeriod.Week,
            "DAY" => SetPackagePricingOveragePricingModelEntitlementResetPeriod.Day,
            "HOUR" => SetPackagePricingOveragePricingModelEntitlementResetPeriod.Hour,
            _ => (SetPackagePricingOveragePricingModelEntitlementResetPeriod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SetPackagePricingOveragePricingModelEntitlementResetPeriod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SetPackagePricingOveragePricingModelEntitlementResetPeriod.Year => "YEAR",
                SetPackagePricingOveragePricingModelEntitlementResetPeriod.Month => "MONTH",
                SetPackagePricingOveragePricingModelEntitlementResetPeriod.Week => "WEEK",
                SetPackagePricingOveragePricingModelEntitlementResetPeriod.Day => "DAY",
                SetPackagePricingOveragePricingModelEntitlementResetPeriod.Hour => "HOUR",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Weekly reset configuration
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfiguration,
        SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationFromRaw
    >)
)]
public sealed record class SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfiguration
    : JsonModel
{
    /// <summary>
    /// Reset anchor (SubscriptionStart or specific day)
    /// </summary>
    public required ApiEnum<
        string,
        SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo
    > AccordingTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo
                >
            >("accordingTo");
        }
        init { this._rawData.Set("accordingTo", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.AccordingTo.Validate();
    }

    public SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfiguration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfiguration(
        SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfiguration setPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfiguration
    )
        : base(setPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfiguration) { }
#pragma warning restore CS8618

    public SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfiguration(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfiguration(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationFromRaw.FromRawUnchecked"/>
    public static SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfiguration(
        ApiEnum<
            string,
            SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo
        > accordingTo
    )
        : this()
    {
        this.AccordingTo = accordingTo;
    }
}

class SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationFromRaw
    : IFromRawJson<SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfiguration>
{
    /// <inheritdoc/>
    public SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfiguration.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Reset anchor (SubscriptionStart or specific day)
/// </summary>
[JsonConverter(
    typeof(SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingToConverter)
)]
public enum SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo
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

sealed class SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingToConverter
    : JsonConverter<SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo>
{
    public override SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SubscriptionStart" =>
                SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart,
            "EverySunday" =>
                SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo.EverySunday,
            "EveryMonday" =>
                SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo.EveryMonday,
            "EveryTuesday" =>
                SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo.EveryTuesday,
            "EveryWednesday" =>
                SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo.EveryWednesday,
            "EveryThursday" =>
                SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo.EveryThursday,
            "EveryFriday" =>
                SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo.EveryFriday,
            "EverySaturday" =>
                SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo.EverySaturday,
            _ =>
                (SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart =>
                    "SubscriptionStart",
                SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo.EverySunday =>
                    "EverySunday",
                SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo.EveryMonday =>
                    "EveryMonday",
                SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo.EveryTuesday =>
                    "EveryTuesday",
                SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo.EveryWednesday =>
                    "EveryWednesday",
                SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo.EveryThursday =>
                    "EveryThursday",
                SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo.EveryFriday =>
                    "EveryFriday",
                SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo.EverySaturday =>
                    "EverySaturday",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Yearly reset configuration
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfiguration,
        SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfigurationFromRaw
    >)
)]
public sealed record class SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfiguration
    : JsonModel
{
    /// <summary>
    /// Reset anchor (SubscriptionStart)
    /// </summary>
    public required ApiEnum<
        string,
        SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfigurationAccordingTo
    > AccordingTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfigurationAccordingTo
                >
            >("accordingTo");
        }
        init { this._rawData.Set("accordingTo", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.AccordingTo.Validate();
    }

    public SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfiguration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfiguration(
        SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfiguration setPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfiguration
    )
        : base(setPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfiguration) { }
#pragma warning restore CS8618

    public SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfiguration(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfiguration(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfigurationFromRaw.FromRawUnchecked"/>
    public static SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfiguration(
        ApiEnum<
            string,
            SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfigurationAccordingTo
        > accordingTo
    )
        : this()
    {
        this.AccordingTo = accordingTo;
    }
}

class SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfigurationFromRaw
    : IFromRawJson<SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfiguration>
{
    /// <inheritdoc/>
    public SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfiguration.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Reset anchor (SubscriptionStart)
/// </summary>
[JsonConverter(
    typeof(SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfigurationAccordingToConverter)
)]
public enum SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfigurationAccordingTo
{
    SubscriptionStart,
}

sealed class SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfigurationAccordingToConverter
    : JsonConverter<SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfigurationAccordingTo>
{
    public override SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfigurationAccordingTo Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SubscriptionStart" =>
                SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
            _ =>
                (SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfigurationAccordingTo)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfigurationAccordingTo value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart =>
                    "SubscriptionStart",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A pricing model configuration with billing details and price periods.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<SetPackagePricingPricingModel, SetPackagePricingPricingModelFromRaw>)
)]
public sealed record class SetPackagePricingPricingModel : JsonModel
{
    /// <summary>
    /// The billing model (FLAT_FEE, PER_UNIT, USAGE_BASED, CREDIT_BASED)
    /// </summary>
    public required ApiEnum<string, SetPackagePricingPricingModelBillingModel> BillingModel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, SetPackagePricingPricingModelBillingModel>
            >("billingModel");
        }
        init { this._rawData.Set("billingModel", value); }
    }

    /// <summary>
    /// Array of price period configurations (at least one required)
    /// </summary>
    public required IReadOnlyList<SetPackagePricingPricingModelPricePeriod> PricePeriods
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<SetPackagePricingPricingModelPricePeriod>
            >("pricePeriods");
        }
        init
        {
            this._rawData.Set<ImmutableArray<SetPackagePricingPricingModelPricePeriod>>(
                "pricePeriods",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The billing cadence (RECURRING or ONE_OFF)
    /// </summary>
    public ApiEnum<string, SetPackagePricingPricingModelBillingCadence>? BillingCadence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, SetPackagePricingPricingModelBillingCadence>
            >("billingCadence");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("billingCadence", value);
        }
    }

    /// <summary>
    /// The feature ID this pricing model is associated with
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

    /// <summary>
    /// Maximum number of units (max 999999)
    /// </summary>
    public long? MaxUnitQuantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("maxUnitQuantity");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("maxUnitQuantity", value);
        }
    }

    /// <summary>
    /// Minimum number of units
    /// </summary>
    public long? MinUnitQuantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("minUnitQuantity");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("minUnitQuantity", value);
        }
    }

    /// <summary>
    /// Monthly reset period configuration
    /// </summary>
    public SetPackagePricingPricingModelMonthlyResetPeriodConfiguration? MonthlyResetPeriodConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SetPackagePricingPricingModelMonthlyResetPeriodConfiguration>(
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

    /// <summary>
    /// The usage reset period
    /// </summary>
    public ApiEnum<string, SetPackagePricingPricingModelResetPeriod>? ResetPeriod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, SetPackagePricingPricingModelResetPeriod>
            >("resetPeriod");
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
    /// The tiered pricing mode (VOLUME or GRADUATED)
    /// </summary>
    public ApiEnum<string, SetPackagePricingPricingModelTiersMode>? TiersMode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, SetPackagePricingPricingModelTiersMode>
            >("tiersMode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tiersMode", value);
        }
    }

    /// <summary>
    /// The custom currency ID for top-up pricing
    /// </summary>
    public string? TopUpCustomCurrencyID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("topUpCustomCurrencyId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("topUpCustomCurrencyId", value);
        }
    }

    /// <summary>
    /// Weekly reset period configuration
    /// </summary>
    public SetPackagePricingPricingModelWeeklyResetPeriodConfiguration? WeeklyResetPeriodConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SetPackagePricingPricingModelWeeklyResetPeriodConfiguration>(
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

    /// <summary>
    /// Yearly reset period configuration
    /// </summary>
    public SetPackagePricingPricingModelYearlyResetPeriodConfiguration? YearlyResetPeriodConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SetPackagePricingPricingModelYearlyResetPeriodConfiguration>(
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
        this.BillingModel.Validate();
        foreach (var item in this.PricePeriods)
        {
            item.Validate();
        }
        this.BillingCadence?.Validate();
        _ = this.FeatureID;
        _ = this.MaxUnitQuantity;
        _ = this.MinUnitQuantity;
        this.MonthlyResetPeriodConfiguration?.Validate();
        this.ResetPeriod?.Validate();
        this.TiersMode?.Validate();
        _ = this.TopUpCustomCurrencyID;
        this.WeeklyResetPeriodConfiguration?.Validate();
        this.YearlyResetPeriodConfiguration?.Validate();
    }

    public SetPackagePricingPricingModel() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SetPackagePricingPricingModel(
        SetPackagePricingPricingModel setPackagePricingPricingModel
    )
        : base(setPackagePricingPricingModel) { }
#pragma warning restore CS8618

    public SetPackagePricingPricingModel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SetPackagePricingPricingModel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SetPackagePricingPricingModelFromRaw.FromRawUnchecked"/>
    public static SetPackagePricingPricingModel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SetPackagePricingPricingModelFromRaw : IFromRawJson<SetPackagePricingPricingModel>
{
    /// <inheritdoc/>
    public SetPackagePricingPricingModel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SetPackagePricingPricingModel.FromRawUnchecked(rawData);
}

/// <summary>
/// The billing model (FLAT_FEE, PER_UNIT, USAGE_BASED, CREDIT_BASED)
/// </summary>
[JsonConverter(typeof(SetPackagePricingPricingModelBillingModelConverter))]
public enum SetPackagePricingPricingModelBillingModel
{
    FlatFee,
    MinimumSpend,
    PerUnit,
    UsageBased,
    CreditBased,
}

sealed class SetPackagePricingPricingModelBillingModelConverter
    : JsonConverter<SetPackagePricingPricingModelBillingModel>
{
    public override SetPackagePricingPricingModelBillingModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FLAT_FEE" => SetPackagePricingPricingModelBillingModel.FlatFee,
            "MINIMUM_SPEND" => SetPackagePricingPricingModelBillingModel.MinimumSpend,
            "PER_UNIT" => SetPackagePricingPricingModelBillingModel.PerUnit,
            "USAGE_BASED" => SetPackagePricingPricingModelBillingModel.UsageBased,
            "CREDIT_BASED" => SetPackagePricingPricingModelBillingModel.CreditBased,
            _ => (SetPackagePricingPricingModelBillingModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SetPackagePricingPricingModelBillingModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SetPackagePricingPricingModelBillingModel.FlatFee => "FLAT_FEE",
                SetPackagePricingPricingModelBillingModel.MinimumSpend => "MINIMUM_SPEND",
                SetPackagePricingPricingModelBillingModel.PerUnit => "PER_UNIT",
                SetPackagePricingPricingModelBillingModel.UsageBased => "USAGE_BASED",
                SetPackagePricingPricingModelBillingModel.CreditBased => "CREDIT_BASED",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Price configuration for a specific billing period.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SetPackagePricingPricingModelPricePeriod,
        SetPackagePricingPricingModelPricePeriodFromRaw
    >)
)]
public sealed record class SetPackagePricingPricingModelPricePeriod : JsonModel
{
    /// <summary>
    /// The billing period (MONTHLY or ANNUALLY)
    /// </summary>
    public required ApiEnum<
        string,
        SetPackagePricingPricingModelPricePeriodBillingPeriod
    > BillingPeriod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, SetPackagePricingPricingModelPricePeriodBillingPeriod>
            >("billingPeriod");
        }
        init { this._rawData.Set("billingPeriod", value); }
    }

    /// <summary>
    /// ISO country code for localized pricing
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
    /// Block size for usage-based pricing
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
    /// When credits are granted
    /// </summary>
    public ApiEnum<
        string,
        SetPackagePricingPricingModelPricePeriodCreditGrantCadence
    >? CreditGrantCadence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, SetPackagePricingPricingModelPricePeriodCreditGrantCadence>
            >("creditGrantCadence");
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

    /// <summary>
    /// Credit rate configuration for credit-based pricing
    /// </summary>
    public SetPackagePricingPricingModelPricePeriodCreditRate? CreditRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SetPackagePricingPricingModelPricePeriodCreditRate>(
                "creditRate"
            );
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
    /// The price amount and currency
    /// </summary>
    public SetPackagePricingPricingModelPricePeriodPrice? Price
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SetPackagePricingPricingModelPricePeriodPrice>(
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
    /// Tiered pricing configuration
    /// </summary>
    public IReadOnlyList<SetPackagePricingPricingModelPricePeriodTier>? Tiers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<SetPackagePricingPricingModelPricePeriodTier>
            >("tiers");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<SetPackagePricingPricingModelPricePeriodTier>?>(
                "tiers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.BillingPeriod.Validate();
        _ = this.BillingCountryCode;
        _ = this.BlockSize;
        this.CreditGrantCadence?.Validate();
        this.CreditRate?.Validate();
        this.Price?.Validate();
        foreach (var item in this.Tiers ?? [])
        {
            item.Validate();
        }
    }

    public SetPackagePricingPricingModelPricePeriod() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SetPackagePricingPricingModelPricePeriod(
        SetPackagePricingPricingModelPricePeriod setPackagePricingPricingModelPricePeriod
    )
        : base(setPackagePricingPricingModelPricePeriod) { }
#pragma warning restore CS8618

    public SetPackagePricingPricingModelPricePeriod(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SetPackagePricingPricingModelPricePeriod(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SetPackagePricingPricingModelPricePeriodFromRaw.FromRawUnchecked"/>
    public static SetPackagePricingPricingModelPricePeriod FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SetPackagePricingPricingModelPricePeriod(
        ApiEnum<string, SetPackagePricingPricingModelPricePeriodBillingPeriod> billingPeriod
    )
        : this()
    {
        this.BillingPeriod = billingPeriod;
    }
}

class SetPackagePricingPricingModelPricePeriodFromRaw
    : IFromRawJson<SetPackagePricingPricingModelPricePeriod>
{
    /// <inheritdoc/>
    public SetPackagePricingPricingModelPricePeriod FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SetPackagePricingPricingModelPricePeriod.FromRawUnchecked(rawData);
}

/// <summary>
/// The billing period (MONTHLY or ANNUALLY)
/// </summary>
[JsonConverter(typeof(SetPackagePricingPricingModelPricePeriodBillingPeriodConverter))]
public enum SetPackagePricingPricingModelPricePeriodBillingPeriod
{
    Monthly,
    Annually,
}

sealed class SetPackagePricingPricingModelPricePeriodBillingPeriodConverter
    : JsonConverter<SetPackagePricingPricingModelPricePeriodBillingPeriod>
{
    public override SetPackagePricingPricingModelPricePeriodBillingPeriod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "MONTHLY" => SetPackagePricingPricingModelPricePeriodBillingPeriod.Monthly,
            "ANNUALLY" => SetPackagePricingPricingModelPricePeriodBillingPeriod.Annually,
            _ => (SetPackagePricingPricingModelPricePeriodBillingPeriod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SetPackagePricingPricingModelPricePeriodBillingPeriod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SetPackagePricingPricingModelPricePeriodBillingPeriod.Monthly => "MONTHLY",
                SetPackagePricingPricingModelPricePeriodBillingPeriod.Annually => "ANNUALLY",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// When credits are granted
/// </summary>
[JsonConverter(typeof(SetPackagePricingPricingModelPricePeriodCreditGrantCadenceConverter))]
public enum SetPackagePricingPricingModelPricePeriodCreditGrantCadence
{
    BeginningOfBillingPeriod,
    Monthly,
}

sealed class SetPackagePricingPricingModelPricePeriodCreditGrantCadenceConverter
    : JsonConverter<SetPackagePricingPricingModelPricePeriodCreditGrantCadence>
{
    public override SetPackagePricingPricingModelPricePeriodCreditGrantCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "BEGINNING_OF_BILLING_PERIOD" =>
                SetPackagePricingPricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
            "MONTHLY" => SetPackagePricingPricingModelPricePeriodCreditGrantCadence.Monthly,
            _ => (SetPackagePricingPricingModelPricePeriodCreditGrantCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SetPackagePricingPricingModelPricePeriodCreditGrantCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SetPackagePricingPricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod =>
                    "BEGINNING_OF_BILLING_PERIOD",
                SetPackagePricingPricingModelPricePeriodCreditGrantCadence.Monthly => "MONTHLY",
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
        SetPackagePricingPricingModelPricePeriodCreditRate,
        SetPackagePricingPricingModelPricePeriodCreditRateFromRaw
    >)
)]
public sealed record class SetPackagePricingPricingModelPricePeriodCreditRate : JsonModel
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
    /// The custom currency ID
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
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("costFormula", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.CurrencyID;
        _ = this.CostFormula;
    }

    public SetPackagePricingPricingModelPricePeriodCreditRate() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SetPackagePricingPricingModelPricePeriodCreditRate(
        SetPackagePricingPricingModelPricePeriodCreditRate setPackagePricingPricingModelPricePeriodCreditRate
    )
        : base(setPackagePricingPricingModelPricePeriodCreditRate) { }
#pragma warning restore CS8618

    public SetPackagePricingPricingModelPricePeriodCreditRate(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SetPackagePricingPricingModelPricePeriodCreditRate(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SetPackagePricingPricingModelPricePeriodCreditRateFromRaw.FromRawUnchecked"/>
    public static SetPackagePricingPricingModelPricePeriodCreditRate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SetPackagePricingPricingModelPricePeriodCreditRateFromRaw
    : IFromRawJson<SetPackagePricingPricingModelPricePeriodCreditRate>
{
    /// <inheritdoc/>
    public SetPackagePricingPricingModelPricePeriodCreditRate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SetPackagePricingPricingModelPricePeriodCreditRate.FromRawUnchecked(rawData);
}

/// <summary>
/// The price amount and currency
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SetPackagePricingPricingModelPricePeriodPrice,
        SetPackagePricingPricingModelPricePeriodPriceFromRaw
    >)
)]
public sealed record class SetPackagePricingPricingModelPricePeriodPrice : JsonModel
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
    /// The price currency
    /// </summary>
    public ApiEnum<string, SetPackagePricingPricingModelPricePeriodPriceCurrency>? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, SetPackagePricingPricingModelPricePeriodPriceCurrency>
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
        this.Currency?.Validate();
    }

    public SetPackagePricingPricingModelPricePeriodPrice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SetPackagePricingPricingModelPricePeriodPrice(
        SetPackagePricingPricingModelPricePeriodPrice setPackagePricingPricingModelPricePeriodPrice
    )
        : base(setPackagePricingPricingModelPricePeriodPrice) { }
#pragma warning restore CS8618

    public SetPackagePricingPricingModelPricePeriodPrice(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SetPackagePricingPricingModelPricePeriodPrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SetPackagePricingPricingModelPricePeriodPriceFromRaw.FromRawUnchecked"/>
    public static SetPackagePricingPricingModelPricePeriodPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SetPackagePricingPricingModelPricePeriodPrice(double amount)
        : this()
    {
        this.Amount = amount;
    }
}

class SetPackagePricingPricingModelPricePeriodPriceFromRaw
    : IFromRawJson<SetPackagePricingPricingModelPricePeriodPrice>
{
    /// <inheritdoc/>
    public SetPackagePricingPricingModelPricePeriodPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SetPackagePricingPricingModelPricePeriodPrice.FromRawUnchecked(rawData);
}

/// <summary>
/// The price currency
/// </summary>
[JsonConverter(typeof(SetPackagePricingPricingModelPricePeriodPriceCurrencyConverter))]
public enum SetPackagePricingPricingModelPricePeriodPriceCurrency
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

sealed class SetPackagePricingPricingModelPricePeriodPriceCurrencyConverter
    : JsonConverter<SetPackagePricingPricingModelPricePeriodPriceCurrency>
{
    public override SetPackagePricingPricingModelPricePeriodPriceCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Usd,
            "aed" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Aed,
            "all" => SetPackagePricingPricingModelPricePeriodPriceCurrency.All,
            "amd" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Amd,
            "ang" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Ang,
            "aud" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Aud,
            "awg" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Awg,
            "azn" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Azn,
            "bam" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Bam,
            "bbd" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Bbd,
            "bdt" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Bdt,
            "bgn" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Bgn,
            "bif" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Bif,
            "bmd" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Bmd,
            "bnd" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Bnd,
            "bsd" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Bsd,
            "bwp" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Bwp,
            "byn" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Byn,
            "bzd" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Bzd,
            "brl" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Brl,
            "cad" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Cad,
            "cdf" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Cdf,
            "chf" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Chf,
            "cny" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Cny,
            "czk" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Czk,
            "dkk" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Dkk,
            "dop" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Dop,
            "dzd" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Dzd,
            "egp" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Egp,
            "etb" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Etb,
            "eur" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Eur,
            "fjd" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Fjd,
            "gbp" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Gbp,
            "gel" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Gel,
            "gip" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Gip,
            "gmd" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Gmd,
            "gyd" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Gyd,
            "hkd" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Hkd,
            "hrk" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Hrk,
            "htg" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Htg,
            "idr" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Idr,
            "ils" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Ils,
            "inr" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Inr,
            "isk" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Isk,
            "jmd" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Jmd,
            "jpy" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Jpy,
            "kes" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Kes,
            "kgs" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Kgs,
            "khr" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Khr,
            "kmf" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Kmf,
            "krw" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Krw,
            "kyd" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Kyd,
            "kzt" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Kzt,
            "lbp" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Lbp,
            "lkr" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Lkr,
            "lrd" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Lrd,
            "lsl" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Lsl,
            "mad" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Mad,
            "mdl" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Mdl,
            "mga" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Mga,
            "mkd" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Mkd,
            "mmk" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Mmk,
            "mnt" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Mnt,
            "mop" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Mop,
            "mro" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Mro,
            "mvr" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Mvr,
            "mwk" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Mwk,
            "mxn" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Mxn,
            "myr" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Myr,
            "mzn" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Mzn,
            "nad" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Nad,
            "ngn" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Ngn,
            "nok" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Nok,
            "npr" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Npr,
            "nzd" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Nzd,
            "pgk" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Pgk,
            "php" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Php,
            "pkr" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Pkr,
            "pln" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Pln,
            "qar" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Qar,
            "ron" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Ron,
            "rsd" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Rsd,
            "rub" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Rub,
            "rwf" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Rwf,
            "sar" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Sar,
            "sbd" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Sbd,
            "scr" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Scr,
            "sek" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Sek,
            "sgd" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Sgd,
            "sle" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Sle,
            "sll" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Sll,
            "sos" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Sos,
            "szl" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Szl,
            "thb" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Thb,
            "tjs" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Tjs,
            "top" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Top,
            "try" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Try,
            "ttd" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Ttd,
            "tzs" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Tzs,
            "uah" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Uah,
            "uzs" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Uzs,
            "vnd" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Vnd,
            "vuv" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Vuv,
            "wst" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Wst,
            "xaf" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Xaf,
            "xcd" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Xcd,
            "yer" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Yer,
            "zar" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Zar,
            "zmw" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Zmw,
            "clp" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Clp,
            "djf" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Djf,
            "gnf" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Gnf,
            "ugx" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Ugx,
            "pyg" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Pyg,
            "xof" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Xof,
            "xpf" => SetPackagePricingPricingModelPricePeriodPriceCurrency.Xpf,
            _ => (SetPackagePricingPricingModelPricePeriodPriceCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SetPackagePricingPricingModelPricePeriodPriceCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Usd => "usd",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Aed => "aed",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.All => "all",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Amd => "amd",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Ang => "ang",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Aud => "aud",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Awg => "awg",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Azn => "azn",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Bam => "bam",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Bbd => "bbd",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Bdt => "bdt",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Bgn => "bgn",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Bif => "bif",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Bmd => "bmd",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Bnd => "bnd",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Bsd => "bsd",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Bwp => "bwp",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Byn => "byn",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Bzd => "bzd",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Brl => "brl",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Cad => "cad",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Cdf => "cdf",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Chf => "chf",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Cny => "cny",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Czk => "czk",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Dkk => "dkk",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Dop => "dop",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Dzd => "dzd",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Egp => "egp",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Etb => "etb",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Eur => "eur",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Fjd => "fjd",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Gbp => "gbp",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Gel => "gel",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Gip => "gip",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Gmd => "gmd",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Gyd => "gyd",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Hkd => "hkd",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Hrk => "hrk",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Htg => "htg",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Idr => "idr",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Ils => "ils",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Inr => "inr",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Isk => "isk",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Jmd => "jmd",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Jpy => "jpy",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Kes => "kes",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Kgs => "kgs",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Khr => "khr",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Kmf => "kmf",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Krw => "krw",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Kyd => "kyd",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Kzt => "kzt",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Lbp => "lbp",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Lkr => "lkr",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Lrd => "lrd",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Lsl => "lsl",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Mad => "mad",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Mdl => "mdl",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Mga => "mga",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Mkd => "mkd",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Mmk => "mmk",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Mnt => "mnt",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Mop => "mop",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Mro => "mro",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Mvr => "mvr",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Mwk => "mwk",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Mxn => "mxn",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Myr => "myr",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Mzn => "mzn",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Nad => "nad",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Ngn => "ngn",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Nok => "nok",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Npr => "npr",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Nzd => "nzd",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Pgk => "pgk",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Php => "php",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Pkr => "pkr",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Pln => "pln",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Qar => "qar",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Ron => "ron",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Rsd => "rsd",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Rub => "rub",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Rwf => "rwf",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Sar => "sar",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Sbd => "sbd",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Scr => "scr",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Sek => "sek",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Sgd => "sgd",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Sle => "sle",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Sll => "sll",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Sos => "sos",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Szl => "szl",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Thb => "thb",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Tjs => "tjs",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Top => "top",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Try => "try",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Ttd => "ttd",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Tzs => "tzs",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Uah => "uah",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Uzs => "uzs",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Vnd => "vnd",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Vuv => "vuv",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Wst => "wst",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Xaf => "xaf",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Xcd => "xcd",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Yer => "yer",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Zar => "zar",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Zmw => "zmw",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Clp => "clp",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Djf => "djf",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Gnf => "gnf",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Ugx => "ugx",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Pyg => "pyg",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Xof => "xof",
                SetPackagePricingPricingModelPricePeriodPriceCurrency.Xpf => "xpf",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A tier in tiered pricing.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SetPackagePricingPricingModelPricePeriodTier,
        SetPackagePricingPricingModelPricePeriodTierFromRaw
    >)
)]
public sealed record class SetPackagePricingPricingModelPricePeriodTier : JsonModel
{
    /// <summary>
    /// Flat price for this tier
    /// </summary>
    public SetPackagePricingPricingModelPricePeriodTierFlatPrice? FlatPrice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SetPackagePricingPricingModelPricePeriodTierFlatPrice>(
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
    /// Per-unit price in this tier
    /// </summary>
    public SetPackagePricingPricingModelPricePeriodTierUnitPrice? UnitPrice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SetPackagePricingPricingModelPricePeriodTierUnitPrice>(
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
    /// Upper bound of this tier (null for unlimited)
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

    public SetPackagePricingPricingModelPricePeriodTier() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SetPackagePricingPricingModelPricePeriodTier(
        SetPackagePricingPricingModelPricePeriodTier setPackagePricingPricingModelPricePeriodTier
    )
        : base(setPackagePricingPricingModelPricePeriodTier) { }
#pragma warning restore CS8618

    public SetPackagePricingPricingModelPricePeriodTier(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SetPackagePricingPricingModelPricePeriodTier(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SetPackagePricingPricingModelPricePeriodTierFromRaw.FromRawUnchecked"/>
    public static SetPackagePricingPricingModelPricePeriodTier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SetPackagePricingPricingModelPricePeriodTierFromRaw
    : IFromRawJson<SetPackagePricingPricingModelPricePeriodTier>
{
    /// <inheritdoc/>
    public SetPackagePricingPricingModelPricePeriodTier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SetPackagePricingPricingModelPricePeriodTier.FromRawUnchecked(rawData);
}

/// <summary>
/// Flat price for this tier
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SetPackagePricingPricingModelPricePeriodTierFlatPrice,
        SetPackagePricingPricingModelPricePeriodTierFlatPriceFromRaw
    >)
)]
public sealed record class SetPackagePricingPricingModelPricePeriodTierFlatPrice : JsonModel
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
    /// The price currency
    /// </summary>
    public ApiEnum<string, SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency>? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency>
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
        this.Currency?.Validate();
    }

    public SetPackagePricingPricingModelPricePeriodTierFlatPrice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SetPackagePricingPricingModelPricePeriodTierFlatPrice(
        SetPackagePricingPricingModelPricePeriodTierFlatPrice setPackagePricingPricingModelPricePeriodTierFlatPrice
    )
        : base(setPackagePricingPricingModelPricePeriodTierFlatPrice) { }
#pragma warning restore CS8618

    public SetPackagePricingPricingModelPricePeriodTierFlatPrice(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SetPackagePricingPricingModelPricePeriodTierFlatPrice(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SetPackagePricingPricingModelPricePeriodTierFlatPriceFromRaw.FromRawUnchecked"/>
    public static SetPackagePricingPricingModelPricePeriodTierFlatPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SetPackagePricingPricingModelPricePeriodTierFlatPrice(double amount)
        : this()
    {
        this.Amount = amount;
    }
}

class SetPackagePricingPricingModelPricePeriodTierFlatPriceFromRaw
    : IFromRawJson<SetPackagePricingPricingModelPricePeriodTierFlatPrice>
{
    /// <inheritdoc/>
    public SetPackagePricingPricingModelPricePeriodTierFlatPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SetPackagePricingPricingModelPricePeriodTierFlatPrice.FromRawUnchecked(rawData);
}

/// <summary>
/// The price currency
/// </summary>
[JsonConverter(typeof(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrencyConverter))]
public enum SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency
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

sealed class SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrencyConverter
    : JsonConverter<SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency>
{
    public override SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Usd,
            "aed" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Aed,
            "all" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.All,
            "amd" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Amd,
            "ang" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Ang,
            "aud" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Aud,
            "awg" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Awg,
            "azn" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Azn,
            "bam" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Bam,
            "bbd" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Bbd,
            "bdt" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Bdt,
            "bgn" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Bgn,
            "bif" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Bif,
            "bmd" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Bmd,
            "bnd" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Bnd,
            "bsd" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Bsd,
            "bwp" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Bwp,
            "byn" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Byn,
            "bzd" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Bzd,
            "brl" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Brl,
            "cad" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Cad,
            "cdf" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Cdf,
            "chf" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Chf,
            "cny" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Cny,
            "czk" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Czk,
            "dkk" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Dkk,
            "dop" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Dop,
            "dzd" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Dzd,
            "egp" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Egp,
            "etb" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Etb,
            "eur" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Eur,
            "fjd" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Fjd,
            "gbp" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Gbp,
            "gel" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Gel,
            "gip" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Gip,
            "gmd" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Gmd,
            "gyd" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Gyd,
            "hkd" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Hkd,
            "hrk" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Hrk,
            "htg" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Htg,
            "idr" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Idr,
            "ils" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Ils,
            "inr" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Inr,
            "isk" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Isk,
            "jmd" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Jmd,
            "jpy" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Jpy,
            "kes" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Kes,
            "kgs" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Kgs,
            "khr" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Khr,
            "kmf" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Kmf,
            "krw" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Krw,
            "kyd" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Kyd,
            "kzt" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Kzt,
            "lbp" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Lbp,
            "lkr" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Lkr,
            "lrd" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Lrd,
            "lsl" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Lsl,
            "mad" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Mad,
            "mdl" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Mdl,
            "mga" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Mga,
            "mkd" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Mkd,
            "mmk" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Mmk,
            "mnt" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Mnt,
            "mop" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Mop,
            "mro" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Mro,
            "mvr" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Mvr,
            "mwk" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Mwk,
            "mxn" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Mxn,
            "myr" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Myr,
            "mzn" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Mzn,
            "nad" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Nad,
            "ngn" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Ngn,
            "nok" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Nok,
            "npr" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Npr,
            "nzd" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Nzd,
            "pgk" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Pgk,
            "php" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Php,
            "pkr" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Pkr,
            "pln" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Pln,
            "qar" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Qar,
            "ron" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Ron,
            "rsd" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Rsd,
            "rub" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Rub,
            "rwf" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Rwf,
            "sar" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Sar,
            "sbd" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Sbd,
            "scr" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Scr,
            "sek" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Sek,
            "sgd" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Sgd,
            "sle" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Sle,
            "sll" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Sll,
            "sos" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Sos,
            "szl" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Szl,
            "thb" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Thb,
            "tjs" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Tjs,
            "top" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Top,
            "try" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Try,
            "ttd" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Ttd,
            "tzs" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Tzs,
            "uah" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Uah,
            "uzs" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Uzs,
            "vnd" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Vnd,
            "vuv" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Vuv,
            "wst" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Wst,
            "xaf" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Xaf,
            "xcd" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Xcd,
            "yer" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Yer,
            "zar" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Zar,
            "zmw" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Zmw,
            "clp" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Clp,
            "djf" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Djf,
            "gnf" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Gnf,
            "ugx" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Ugx,
            "pyg" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Pyg,
            "xof" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Xof,
            "xpf" => SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Xpf,
            _ => (SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Usd => "usd",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Aed => "aed",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.All => "all",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Amd => "amd",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Ang => "ang",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Aud => "aud",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Awg => "awg",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Azn => "azn",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Bam => "bam",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Bbd => "bbd",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Bdt => "bdt",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Bgn => "bgn",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Bif => "bif",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Bmd => "bmd",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Bnd => "bnd",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Bsd => "bsd",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Bwp => "bwp",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Byn => "byn",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Bzd => "bzd",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Brl => "brl",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Cad => "cad",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Cdf => "cdf",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Chf => "chf",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Cny => "cny",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Czk => "czk",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Dkk => "dkk",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Dop => "dop",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Dzd => "dzd",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Egp => "egp",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Etb => "etb",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Eur => "eur",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Fjd => "fjd",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Gbp => "gbp",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Gel => "gel",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Gip => "gip",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Gmd => "gmd",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Gyd => "gyd",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Hkd => "hkd",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Hrk => "hrk",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Htg => "htg",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Idr => "idr",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Ils => "ils",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Inr => "inr",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Isk => "isk",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Jmd => "jmd",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Jpy => "jpy",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Kes => "kes",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Kgs => "kgs",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Khr => "khr",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Kmf => "kmf",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Krw => "krw",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Kyd => "kyd",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Kzt => "kzt",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Lbp => "lbp",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Lkr => "lkr",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Lrd => "lrd",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Lsl => "lsl",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Mad => "mad",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Mdl => "mdl",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Mga => "mga",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Mkd => "mkd",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Mmk => "mmk",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Mnt => "mnt",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Mop => "mop",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Mro => "mro",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Mvr => "mvr",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Mwk => "mwk",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Mxn => "mxn",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Myr => "myr",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Mzn => "mzn",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Nad => "nad",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Ngn => "ngn",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Nok => "nok",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Npr => "npr",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Nzd => "nzd",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Pgk => "pgk",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Php => "php",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Pkr => "pkr",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Pln => "pln",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Qar => "qar",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Ron => "ron",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Rsd => "rsd",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Rub => "rub",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Rwf => "rwf",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Sar => "sar",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Sbd => "sbd",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Scr => "scr",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Sek => "sek",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Sgd => "sgd",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Sle => "sle",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Sll => "sll",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Sos => "sos",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Szl => "szl",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Thb => "thb",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Tjs => "tjs",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Top => "top",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Try => "try",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Ttd => "ttd",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Tzs => "tzs",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Uah => "uah",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Uzs => "uzs",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Vnd => "vnd",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Vuv => "vuv",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Wst => "wst",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Xaf => "xaf",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Xcd => "xcd",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Yer => "yer",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Zar => "zar",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Zmw => "zmw",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Clp => "clp",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Djf => "djf",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Gnf => "gnf",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Ugx => "ugx",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Pyg => "pyg",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Xof => "xof",
                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Xpf => "xpf",
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
        SetPackagePricingPricingModelPricePeriodTierUnitPrice,
        SetPackagePricingPricingModelPricePeriodTierUnitPriceFromRaw
    >)
)]
public sealed record class SetPackagePricingPricingModelPricePeriodTierUnitPrice : JsonModel
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
    /// The price currency
    /// </summary>
    public ApiEnum<string, SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency>? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency>
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
        this.Currency?.Validate();
    }

    public SetPackagePricingPricingModelPricePeriodTierUnitPrice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SetPackagePricingPricingModelPricePeriodTierUnitPrice(
        SetPackagePricingPricingModelPricePeriodTierUnitPrice setPackagePricingPricingModelPricePeriodTierUnitPrice
    )
        : base(setPackagePricingPricingModelPricePeriodTierUnitPrice) { }
#pragma warning restore CS8618

    public SetPackagePricingPricingModelPricePeriodTierUnitPrice(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SetPackagePricingPricingModelPricePeriodTierUnitPrice(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SetPackagePricingPricingModelPricePeriodTierUnitPriceFromRaw.FromRawUnchecked"/>
    public static SetPackagePricingPricingModelPricePeriodTierUnitPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SetPackagePricingPricingModelPricePeriodTierUnitPrice(double amount)
        : this()
    {
        this.Amount = amount;
    }
}

class SetPackagePricingPricingModelPricePeriodTierUnitPriceFromRaw
    : IFromRawJson<SetPackagePricingPricingModelPricePeriodTierUnitPrice>
{
    /// <inheritdoc/>
    public SetPackagePricingPricingModelPricePeriodTierUnitPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SetPackagePricingPricingModelPricePeriodTierUnitPrice.FromRawUnchecked(rawData);
}

/// <summary>
/// The price currency
/// </summary>
[JsonConverter(typeof(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrencyConverter))]
public enum SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency
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

sealed class SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrencyConverter
    : JsonConverter<SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency>
{
    public override SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Usd,
            "aed" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Aed,
            "all" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.All,
            "amd" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Amd,
            "ang" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Ang,
            "aud" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Aud,
            "awg" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Awg,
            "azn" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Azn,
            "bam" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Bam,
            "bbd" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Bbd,
            "bdt" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Bdt,
            "bgn" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Bgn,
            "bif" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Bif,
            "bmd" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Bmd,
            "bnd" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Bnd,
            "bsd" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Bsd,
            "bwp" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Bwp,
            "byn" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Byn,
            "bzd" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Bzd,
            "brl" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Brl,
            "cad" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Cad,
            "cdf" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Cdf,
            "chf" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Chf,
            "cny" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Cny,
            "czk" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Czk,
            "dkk" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Dkk,
            "dop" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Dop,
            "dzd" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Dzd,
            "egp" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Egp,
            "etb" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Etb,
            "eur" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Eur,
            "fjd" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Fjd,
            "gbp" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Gbp,
            "gel" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Gel,
            "gip" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Gip,
            "gmd" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Gmd,
            "gyd" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Gyd,
            "hkd" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Hkd,
            "hrk" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Hrk,
            "htg" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Htg,
            "idr" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Idr,
            "ils" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Ils,
            "inr" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Inr,
            "isk" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Isk,
            "jmd" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Jmd,
            "jpy" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Jpy,
            "kes" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Kes,
            "kgs" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Kgs,
            "khr" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Khr,
            "kmf" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Kmf,
            "krw" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Krw,
            "kyd" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Kyd,
            "kzt" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Kzt,
            "lbp" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Lbp,
            "lkr" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Lkr,
            "lrd" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Lrd,
            "lsl" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Lsl,
            "mad" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Mad,
            "mdl" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Mdl,
            "mga" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Mga,
            "mkd" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Mkd,
            "mmk" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Mmk,
            "mnt" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Mnt,
            "mop" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Mop,
            "mro" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Mro,
            "mvr" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Mvr,
            "mwk" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Mwk,
            "mxn" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Mxn,
            "myr" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Myr,
            "mzn" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Mzn,
            "nad" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Nad,
            "ngn" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Ngn,
            "nok" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Nok,
            "npr" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Npr,
            "nzd" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Nzd,
            "pgk" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Pgk,
            "php" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Php,
            "pkr" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Pkr,
            "pln" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Pln,
            "qar" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Qar,
            "ron" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Ron,
            "rsd" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Rsd,
            "rub" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Rub,
            "rwf" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Rwf,
            "sar" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Sar,
            "sbd" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Sbd,
            "scr" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Scr,
            "sek" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Sek,
            "sgd" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Sgd,
            "sle" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Sle,
            "sll" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Sll,
            "sos" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Sos,
            "szl" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Szl,
            "thb" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Thb,
            "tjs" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Tjs,
            "top" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Top,
            "try" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Try,
            "ttd" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Ttd,
            "tzs" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Tzs,
            "uah" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Uah,
            "uzs" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Uzs,
            "vnd" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Vnd,
            "vuv" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Vuv,
            "wst" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Wst,
            "xaf" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Xaf,
            "xcd" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Xcd,
            "yer" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Yer,
            "zar" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Zar,
            "zmw" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Zmw,
            "clp" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Clp,
            "djf" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Djf,
            "gnf" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Gnf,
            "ugx" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Ugx,
            "pyg" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Pyg,
            "xof" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Xof,
            "xpf" => SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Xpf,
            _ => (SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Usd => "usd",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Aed => "aed",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.All => "all",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Amd => "amd",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Ang => "ang",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Aud => "aud",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Awg => "awg",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Azn => "azn",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Bam => "bam",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Bbd => "bbd",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Bdt => "bdt",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Bgn => "bgn",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Bif => "bif",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Bmd => "bmd",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Bnd => "bnd",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Bsd => "bsd",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Bwp => "bwp",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Byn => "byn",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Bzd => "bzd",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Brl => "brl",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Cad => "cad",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Cdf => "cdf",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Chf => "chf",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Cny => "cny",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Czk => "czk",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Dkk => "dkk",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Dop => "dop",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Dzd => "dzd",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Egp => "egp",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Etb => "etb",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Eur => "eur",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Fjd => "fjd",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Gbp => "gbp",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Gel => "gel",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Gip => "gip",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Gmd => "gmd",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Gyd => "gyd",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Hkd => "hkd",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Hrk => "hrk",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Htg => "htg",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Idr => "idr",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Ils => "ils",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Inr => "inr",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Isk => "isk",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Jmd => "jmd",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Jpy => "jpy",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Kes => "kes",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Kgs => "kgs",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Khr => "khr",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Kmf => "kmf",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Krw => "krw",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Kyd => "kyd",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Kzt => "kzt",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Lbp => "lbp",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Lkr => "lkr",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Lrd => "lrd",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Lsl => "lsl",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Mad => "mad",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Mdl => "mdl",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Mga => "mga",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Mkd => "mkd",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Mmk => "mmk",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Mnt => "mnt",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Mop => "mop",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Mro => "mro",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Mvr => "mvr",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Mwk => "mwk",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Mxn => "mxn",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Myr => "myr",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Mzn => "mzn",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Nad => "nad",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Ngn => "ngn",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Nok => "nok",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Npr => "npr",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Nzd => "nzd",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Pgk => "pgk",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Php => "php",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Pkr => "pkr",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Pln => "pln",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Qar => "qar",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Ron => "ron",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Rsd => "rsd",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Rub => "rub",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Rwf => "rwf",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Sar => "sar",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Sbd => "sbd",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Scr => "scr",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Sek => "sek",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Sgd => "sgd",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Sle => "sle",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Sll => "sll",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Sos => "sos",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Szl => "szl",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Thb => "thb",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Tjs => "tjs",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Top => "top",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Try => "try",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Ttd => "ttd",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Tzs => "tzs",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Uah => "uah",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Uzs => "uzs",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Vnd => "vnd",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Vuv => "vuv",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Wst => "wst",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Xaf => "xaf",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Xcd => "xcd",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Yer => "yer",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Zar => "zar",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Zmw => "zmw",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Clp => "clp",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Djf => "djf",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Gnf => "gnf",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Ugx => "ugx",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Pyg => "pyg",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Xof => "xof",
                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Xpf => "xpf",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The billing cadence (RECURRING or ONE_OFF)
/// </summary>
[JsonConverter(typeof(SetPackagePricingPricingModelBillingCadenceConverter))]
public enum SetPackagePricingPricingModelBillingCadence
{
    Recurring,
    OneOff,
}

sealed class SetPackagePricingPricingModelBillingCadenceConverter
    : JsonConverter<SetPackagePricingPricingModelBillingCadence>
{
    public override SetPackagePricingPricingModelBillingCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "RECURRING" => SetPackagePricingPricingModelBillingCadence.Recurring,
            "ONE_OFF" => SetPackagePricingPricingModelBillingCadence.OneOff,
            _ => (SetPackagePricingPricingModelBillingCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SetPackagePricingPricingModelBillingCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SetPackagePricingPricingModelBillingCadence.Recurring => "RECURRING",
                SetPackagePricingPricingModelBillingCadence.OneOff => "ONE_OFF",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Monthly reset period configuration
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SetPackagePricingPricingModelMonthlyResetPeriodConfiguration,
        SetPackagePricingPricingModelMonthlyResetPeriodConfigurationFromRaw
    >)
)]
public sealed record class SetPackagePricingPricingModelMonthlyResetPeriodConfiguration : JsonModel
{
    /// <summary>
    /// Reset anchor (SubscriptionStart or StartOfTheMonth)
    /// </summary>
    public required ApiEnum<
        string,
        SetPackagePricingPricingModelMonthlyResetPeriodConfigurationAccordingTo
    > AccordingTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    SetPackagePricingPricingModelMonthlyResetPeriodConfigurationAccordingTo
                >
            >("accordingTo");
        }
        init { this._rawData.Set("accordingTo", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.AccordingTo.Validate();
    }

    public SetPackagePricingPricingModelMonthlyResetPeriodConfiguration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SetPackagePricingPricingModelMonthlyResetPeriodConfiguration(
        SetPackagePricingPricingModelMonthlyResetPeriodConfiguration setPackagePricingPricingModelMonthlyResetPeriodConfiguration
    )
        : base(setPackagePricingPricingModelMonthlyResetPeriodConfiguration) { }
#pragma warning restore CS8618

    public SetPackagePricingPricingModelMonthlyResetPeriodConfiguration(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SetPackagePricingPricingModelMonthlyResetPeriodConfiguration(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SetPackagePricingPricingModelMonthlyResetPeriodConfigurationFromRaw.FromRawUnchecked"/>
    public static SetPackagePricingPricingModelMonthlyResetPeriodConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SetPackagePricingPricingModelMonthlyResetPeriodConfiguration(
        ApiEnum<
            string,
            SetPackagePricingPricingModelMonthlyResetPeriodConfigurationAccordingTo
        > accordingTo
    )
        : this()
    {
        this.AccordingTo = accordingTo;
    }
}

class SetPackagePricingPricingModelMonthlyResetPeriodConfigurationFromRaw
    : IFromRawJson<SetPackagePricingPricingModelMonthlyResetPeriodConfiguration>
{
    /// <inheritdoc/>
    public SetPackagePricingPricingModelMonthlyResetPeriodConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SetPackagePricingPricingModelMonthlyResetPeriodConfiguration.FromRawUnchecked(rawData);
}

/// <summary>
/// Reset anchor (SubscriptionStart or StartOfTheMonth)
/// </summary>
[JsonConverter(
    typeof(SetPackagePricingPricingModelMonthlyResetPeriodConfigurationAccordingToConverter)
)]
public enum SetPackagePricingPricingModelMonthlyResetPeriodConfigurationAccordingTo
{
    SubscriptionStart,
    StartOfTheMonth,
}

sealed class SetPackagePricingPricingModelMonthlyResetPeriodConfigurationAccordingToConverter
    : JsonConverter<SetPackagePricingPricingModelMonthlyResetPeriodConfigurationAccordingTo>
{
    public override SetPackagePricingPricingModelMonthlyResetPeriodConfigurationAccordingTo Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SubscriptionStart" =>
                SetPackagePricingPricingModelMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
            "StartOfTheMonth" =>
                SetPackagePricingPricingModelMonthlyResetPeriodConfigurationAccordingTo.StartOfTheMonth,
            _ => (SetPackagePricingPricingModelMonthlyResetPeriodConfigurationAccordingTo)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SetPackagePricingPricingModelMonthlyResetPeriodConfigurationAccordingTo value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SetPackagePricingPricingModelMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart =>
                    "SubscriptionStart",
                SetPackagePricingPricingModelMonthlyResetPeriodConfigurationAccordingTo.StartOfTheMonth =>
                    "StartOfTheMonth",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The usage reset period
/// </summary>
[JsonConverter(typeof(SetPackagePricingPricingModelResetPeriodConverter))]
public enum SetPackagePricingPricingModelResetPeriod
{
    Year,
    Month,
    Week,
    Day,
    Hour,
}

sealed class SetPackagePricingPricingModelResetPeriodConverter
    : JsonConverter<SetPackagePricingPricingModelResetPeriod>
{
    public override SetPackagePricingPricingModelResetPeriod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "YEAR" => SetPackagePricingPricingModelResetPeriod.Year,
            "MONTH" => SetPackagePricingPricingModelResetPeriod.Month,
            "WEEK" => SetPackagePricingPricingModelResetPeriod.Week,
            "DAY" => SetPackagePricingPricingModelResetPeriod.Day,
            "HOUR" => SetPackagePricingPricingModelResetPeriod.Hour,
            _ => (SetPackagePricingPricingModelResetPeriod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SetPackagePricingPricingModelResetPeriod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SetPackagePricingPricingModelResetPeriod.Year => "YEAR",
                SetPackagePricingPricingModelResetPeriod.Month => "MONTH",
                SetPackagePricingPricingModelResetPeriod.Week => "WEEK",
                SetPackagePricingPricingModelResetPeriod.Day => "DAY",
                SetPackagePricingPricingModelResetPeriod.Hour => "HOUR",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The tiered pricing mode (VOLUME or GRADUATED)
/// </summary>
[JsonConverter(typeof(SetPackagePricingPricingModelTiersModeConverter))]
public enum SetPackagePricingPricingModelTiersMode
{
    Volume,
    Graduated,
}

sealed class SetPackagePricingPricingModelTiersModeConverter
    : JsonConverter<SetPackagePricingPricingModelTiersMode>
{
    public override SetPackagePricingPricingModelTiersMode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "VOLUME" => SetPackagePricingPricingModelTiersMode.Volume,
            "GRADUATED" => SetPackagePricingPricingModelTiersMode.Graduated,
            _ => (SetPackagePricingPricingModelTiersMode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SetPackagePricingPricingModelTiersMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SetPackagePricingPricingModelTiersMode.Volume => "VOLUME",
                SetPackagePricingPricingModelTiersMode.Graduated => "GRADUATED",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Weekly reset period configuration
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SetPackagePricingPricingModelWeeklyResetPeriodConfiguration,
        SetPackagePricingPricingModelWeeklyResetPeriodConfigurationFromRaw
    >)
)]
public sealed record class SetPackagePricingPricingModelWeeklyResetPeriodConfiguration : JsonModel
{
    /// <summary>
    /// Reset anchor (SubscriptionStart or specific day)
    /// </summary>
    public required ApiEnum<
        string,
        SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo
    > AccordingTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo
                >
            >("accordingTo");
        }
        init { this._rawData.Set("accordingTo", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.AccordingTo.Validate();
    }

    public SetPackagePricingPricingModelWeeklyResetPeriodConfiguration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SetPackagePricingPricingModelWeeklyResetPeriodConfiguration(
        SetPackagePricingPricingModelWeeklyResetPeriodConfiguration setPackagePricingPricingModelWeeklyResetPeriodConfiguration
    )
        : base(setPackagePricingPricingModelWeeklyResetPeriodConfiguration) { }
#pragma warning restore CS8618

    public SetPackagePricingPricingModelWeeklyResetPeriodConfiguration(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SetPackagePricingPricingModelWeeklyResetPeriodConfiguration(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SetPackagePricingPricingModelWeeklyResetPeriodConfigurationFromRaw.FromRawUnchecked"/>
    public static SetPackagePricingPricingModelWeeklyResetPeriodConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SetPackagePricingPricingModelWeeklyResetPeriodConfiguration(
        ApiEnum<
            string,
            SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo
        > accordingTo
    )
        : this()
    {
        this.AccordingTo = accordingTo;
    }
}

class SetPackagePricingPricingModelWeeklyResetPeriodConfigurationFromRaw
    : IFromRawJson<SetPackagePricingPricingModelWeeklyResetPeriodConfiguration>
{
    /// <inheritdoc/>
    public SetPackagePricingPricingModelWeeklyResetPeriodConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SetPackagePricingPricingModelWeeklyResetPeriodConfiguration.FromRawUnchecked(rawData);
}

/// <summary>
/// Reset anchor (SubscriptionStart or specific day)
/// </summary>
[JsonConverter(
    typeof(SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingToConverter)
)]
public enum SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo
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

sealed class SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingToConverter
    : JsonConverter<SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo>
{
    public override SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SubscriptionStart" =>
                SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart,
            "EverySunday" =>
                SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo.EverySunday,
            "EveryMonday" =>
                SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo.EveryMonday,
            "EveryTuesday" =>
                SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo.EveryTuesday,
            "EveryWednesday" =>
                SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo.EveryWednesday,
            "EveryThursday" =>
                SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo.EveryThursday,
            "EveryFriday" =>
                SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo.EveryFriday,
            "EverySaturday" =>
                SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo.EverySaturday,
            _ => (SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart =>
                    "SubscriptionStart",
                SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo.EverySunday =>
                    "EverySunday",
                SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo.EveryMonday =>
                    "EveryMonday",
                SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo.EveryTuesday =>
                    "EveryTuesday",
                SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo.EveryWednesday =>
                    "EveryWednesday",
                SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo.EveryThursday =>
                    "EveryThursday",
                SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo.EveryFriday =>
                    "EveryFriday",
                SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo.EverySaturday =>
                    "EverySaturday",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Yearly reset period configuration
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SetPackagePricingPricingModelYearlyResetPeriodConfiguration,
        SetPackagePricingPricingModelYearlyResetPeriodConfigurationFromRaw
    >)
)]
public sealed record class SetPackagePricingPricingModelYearlyResetPeriodConfiguration : JsonModel
{
    /// <summary>
    /// Reset anchor (SubscriptionStart)
    /// </summary>
    public required ApiEnum<
        string,
        SetPackagePricingPricingModelYearlyResetPeriodConfigurationAccordingTo
    > AccordingTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    SetPackagePricingPricingModelYearlyResetPeriodConfigurationAccordingTo
                >
            >("accordingTo");
        }
        init { this._rawData.Set("accordingTo", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.AccordingTo.Validate();
    }

    public SetPackagePricingPricingModelYearlyResetPeriodConfiguration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SetPackagePricingPricingModelYearlyResetPeriodConfiguration(
        SetPackagePricingPricingModelYearlyResetPeriodConfiguration setPackagePricingPricingModelYearlyResetPeriodConfiguration
    )
        : base(setPackagePricingPricingModelYearlyResetPeriodConfiguration) { }
#pragma warning restore CS8618

    public SetPackagePricingPricingModelYearlyResetPeriodConfiguration(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SetPackagePricingPricingModelYearlyResetPeriodConfiguration(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SetPackagePricingPricingModelYearlyResetPeriodConfigurationFromRaw.FromRawUnchecked"/>
    public static SetPackagePricingPricingModelYearlyResetPeriodConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SetPackagePricingPricingModelYearlyResetPeriodConfiguration(
        ApiEnum<
            string,
            SetPackagePricingPricingModelYearlyResetPeriodConfigurationAccordingTo
        > accordingTo
    )
        : this()
    {
        this.AccordingTo = accordingTo;
    }
}

class SetPackagePricingPricingModelYearlyResetPeriodConfigurationFromRaw
    : IFromRawJson<SetPackagePricingPricingModelYearlyResetPeriodConfiguration>
{
    /// <inheritdoc/>
    public SetPackagePricingPricingModelYearlyResetPeriodConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SetPackagePricingPricingModelYearlyResetPeriodConfiguration.FromRawUnchecked(rawData);
}

/// <summary>
/// Reset anchor (SubscriptionStart)
/// </summary>
[JsonConverter(
    typeof(SetPackagePricingPricingModelYearlyResetPeriodConfigurationAccordingToConverter)
)]
public enum SetPackagePricingPricingModelYearlyResetPeriodConfigurationAccordingTo
{
    SubscriptionStart,
}

sealed class SetPackagePricingPricingModelYearlyResetPeriodConfigurationAccordingToConverter
    : JsonConverter<SetPackagePricingPricingModelYearlyResetPeriodConfigurationAccordingTo>
{
    public override SetPackagePricingPricingModelYearlyResetPeriodConfigurationAccordingTo Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SubscriptionStart" =>
                SetPackagePricingPricingModelYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
            _ => (SetPackagePricingPricingModelYearlyResetPeriodConfigurationAccordingTo)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SetPackagePricingPricingModelYearlyResetPeriodConfigurationAccordingTo value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SetPackagePricingPricingModelYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart =>
                    "SubscriptionStart",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
