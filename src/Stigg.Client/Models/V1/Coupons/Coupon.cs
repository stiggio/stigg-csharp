using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using System = System;

namespace Stigg.Client.Models.V1.Coupons;

/// <summary>
/// Response object
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Coupon, CouponFromRaw>))]
public sealed record class Coupon : JsonModel
{
    /// <summary>
    /// Discount instrument with percentage or fixed amount
    /// </summary>
    public required Data Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Data>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public Coupon() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Coupon(Coupon coupon)
        : base(coupon) { }
#pragma warning restore CS8618

    public Coupon(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Coupon(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CouponFromRaw.FromRawUnchecked"/>
    public static Coupon FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Coupon(Data data)
        : this()
    {
        this.Data = data;
    }
}

class CouponFromRaw : IFromRawJson<Coupon>
{
    /// <inheritdoc/>
    public Coupon FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Coupon.FromRawUnchecked(rawData);
}

/// <summary>
/// Discount instrument with percentage or fixed amount
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// The unique identifier for the entity
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
    /// Fixed amount discounts in different currencies
    /// </summary>
    public required IReadOnlyList<DataAmountsOff>? AmountsOff
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<DataAmountsOff>>("amountsOff");
        }
        init
        {
            this._rawData.Set<ImmutableArray<DataAmountsOff>?>(
                "amountsOff",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The unique identifier for the entity in the billing provider
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
    /// The URL to the entity in the billing provider
    /// </summary>
    public required string? BillingLinkUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billingLinkUrl");
        }
        init { this._rawData.Set("billingLinkUrl", value); }
    }

    /// <summary>
    /// Timestamp of when the record was created
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
    /// Description of the coupon
    /// </summary>
    public required string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// Duration of the coupon validity in months
    /// </summary>
    public required double? DurationInMonths
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("durationInMonths");
        }
        init { this._rawData.Set("durationInMonths", value); }
    }

    /// <summary>
    /// Name of the coupon
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Percentage discount off the original price
    /// </summary>
    public required double? PercentOff
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("percentOff");
        }
        init { this._rawData.Set("percentOff", value); }
    }

    /// <summary>
    /// The source of the coupon
    /// </summary>
    public required ApiEnum<string, Source>? Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Source>>("source");
        }
        init { this._rawData.Set("source", value); }
    }

    /// <summary>
    /// Current status of the coupon
    /// </summary>
    public required ApiEnum<string, Status> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Status>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Type of the coupon (percentage or fixed amount)
    /// </summary>
    public required ApiEnum<string, DataType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, DataType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Timestamp of when the record was last updated
    /// </summary>
    public required System::DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("updatedAt");
        }
        init { this._rawData.Set("updatedAt", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        foreach (var item in this.AmountsOff ?? [])
        {
            item.Validate();
        }
        _ = this.BillingID;
        _ = this.BillingLinkUrl;
        _ = this.CreatedAt;
        _ = this.Description;
        _ = this.DurationInMonths;
        _ = this.Name;
        _ = this.PercentOff;
        this.Source?.Validate();
        this.Status.Validate();
        this.Type.Validate();
        _ = this.UpdatedAt;
    }

    public Data() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Data(Data data)
        : base(data) { }
#pragma warning restore CS8618

    public Data(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Data(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataFromRaw.FromRawUnchecked"/>
    public static Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Data.FromRawUnchecked(rawData);
}

/// <summary>
/// Monetary amount with currency
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DataAmountsOff, DataAmountsOffFromRaw>))]
public sealed record class DataAmountsOff : JsonModel
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
    public required ApiEnum<string, DataAmountsOffCurrency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, DataAmountsOffCurrency>>(
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

    public DataAmountsOff() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DataAmountsOff(DataAmountsOff dataAmountsOff)
        : base(dataAmountsOff) { }
#pragma warning restore CS8618

    public DataAmountsOff(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DataAmountsOff(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataAmountsOffFromRaw.FromRawUnchecked"/>
    public static DataAmountsOff FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataAmountsOffFromRaw : IFromRawJson<DataAmountsOff>
{
    /// <inheritdoc/>
    public DataAmountsOff FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DataAmountsOff.FromRawUnchecked(rawData);
}

/// <summary>
/// The price currency
/// </summary>
[JsonConverter(typeof(DataAmountsOffCurrencyConverter))]
public enum DataAmountsOffCurrency
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

sealed class DataAmountsOffCurrencyConverter : JsonConverter<DataAmountsOffCurrency>
{
    public override DataAmountsOffCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => DataAmountsOffCurrency.Usd,
            "aed" => DataAmountsOffCurrency.Aed,
            "all" => DataAmountsOffCurrency.All,
            "amd" => DataAmountsOffCurrency.Amd,
            "ang" => DataAmountsOffCurrency.Ang,
            "aud" => DataAmountsOffCurrency.Aud,
            "awg" => DataAmountsOffCurrency.Awg,
            "azn" => DataAmountsOffCurrency.Azn,
            "bam" => DataAmountsOffCurrency.Bam,
            "bbd" => DataAmountsOffCurrency.Bbd,
            "bdt" => DataAmountsOffCurrency.Bdt,
            "bgn" => DataAmountsOffCurrency.Bgn,
            "bif" => DataAmountsOffCurrency.Bif,
            "bmd" => DataAmountsOffCurrency.Bmd,
            "bnd" => DataAmountsOffCurrency.Bnd,
            "bsd" => DataAmountsOffCurrency.Bsd,
            "bwp" => DataAmountsOffCurrency.Bwp,
            "byn" => DataAmountsOffCurrency.Byn,
            "bzd" => DataAmountsOffCurrency.Bzd,
            "brl" => DataAmountsOffCurrency.Brl,
            "cad" => DataAmountsOffCurrency.Cad,
            "cdf" => DataAmountsOffCurrency.Cdf,
            "chf" => DataAmountsOffCurrency.Chf,
            "cny" => DataAmountsOffCurrency.Cny,
            "czk" => DataAmountsOffCurrency.Czk,
            "dkk" => DataAmountsOffCurrency.Dkk,
            "dop" => DataAmountsOffCurrency.Dop,
            "dzd" => DataAmountsOffCurrency.Dzd,
            "egp" => DataAmountsOffCurrency.Egp,
            "etb" => DataAmountsOffCurrency.Etb,
            "eur" => DataAmountsOffCurrency.Eur,
            "fjd" => DataAmountsOffCurrency.Fjd,
            "gbp" => DataAmountsOffCurrency.Gbp,
            "gel" => DataAmountsOffCurrency.Gel,
            "gip" => DataAmountsOffCurrency.Gip,
            "gmd" => DataAmountsOffCurrency.Gmd,
            "gyd" => DataAmountsOffCurrency.Gyd,
            "hkd" => DataAmountsOffCurrency.Hkd,
            "hrk" => DataAmountsOffCurrency.Hrk,
            "htg" => DataAmountsOffCurrency.Htg,
            "idr" => DataAmountsOffCurrency.Idr,
            "ils" => DataAmountsOffCurrency.Ils,
            "inr" => DataAmountsOffCurrency.Inr,
            "isk" => DataAmountsOffCurrency.Isk,
            "jmd" => DataAmountsOffCurrency.Jmd,
            "jpy" => DataAmountsOffCurrency.Jpy,
            "kes" => DataAmountsOffCurrency.Kes,
            "kgs" => DataAmountsOffCurrency.Kgs,
            "khr" => DataAmountsOffCurrency.Khr,
            "kmf" => DataAmountsOffCurrency.Kmf,
            "krw" => DataAmountsOffCurrency.Krw,
            "kyd" => DataAmountsOffCurrency.Kyd,
            "kzt" => DataAmountsOffCurrency.Kzt,
            "lbp" => DataAmountsOffCurrency.Lbp,
            "lkr" => DataAmountsOffCurrency.Lkr,
            "lrd" => DataAmountsOffCurrency.Lrd,
            "lsl" => DataAmountsOffCurrency.Lsl,
            "mad" => DataAmountsOffCurrency.Mad,
            "mdl" => DataAmountsOffCurrency.Mdl,
            "mga" => DataAmountsOffCurrency.Mga,
            "mkd" => DataAmountsOffCurrency.Mkd,
            "mmk" => DataAmountsOffCurrency.Mmk,
            "mnt" => DataAmountsOffCurrency.Mnt,
            "mop" => DataAmountsOffCurrency.Mop,
            "mro" => DataAmountsOffCurrency.Mro,
            "mvr" => DataAmountsOffCurrency.Mvr,
            "mwk" => DataAmountsOffCurrency.Mwk,
            "mxn" => DataAmountsOffCurrency.Mxn,
            "myr" => DataAmountsOffCurrency.Myr,
            "mzn" => DataAmountsOffCurrency.Mzn,
            "nad" => DataAmountsOffCurrency.Nad,
            "ngn" => DataAmountsOffCurrency.Ngn,
            "nok" => DataAmountsOffCurrency.Nok,
            "npr" => DataAmountsOffCurrency.Npr,
            "nzd" => DataAmountsOffCurrency.Nzd,
            "pgk" => DataAmountsOffCurrency.Pgk,
            "php" => DataAmountsOffCurrency.Php,
            "pkr" => DataAmountsOffCurrency.Pkr,
            "pln" => DataAmountsOffCurrency.Pln,
            "qar" => DataAmountsOffCurrency.Qar,
            "ron" => DataAmountsOffCurrency.Ron,
            "rsd" => DataAmountsOffCurrency.Rsd,
            "rub" => DataAmountsOffCurrency.Rub,
            "rwf" => DataAmountsOffCurrency.Rwf,
            "sar" => DataAmountsOffCurrency.Sar,
            "sbd" => DataAmountsOffCurrency.Sbd,
            "scr" => DataAmountsOffCurrency.Scr,
            "sek" => DataAmountsOffCurrency.Sek,
            "sgd" => DataAmountsOffCurrency.Sgd,
            "sle" => DataAmountsOffCurrency.Sle,
            "sll" => DataAmountsOffCurrency.Sll,
            "sos" => DataAmountsOffCurrency.Sos,
            "szl" => DataAmountsOffCurrency.Szl,
            "thb" => DataAmountsOffCurrency.Thb,
            "tjs" => DataAmountsOffCurrency.Tjs,
            "top" => DataAmountsOffCurrency.Top,
            "try" => DataAmountsOffCurrency.Try,
            "ttd" => DataAmountsOffCurrency.Ttd,
            "tzs" => DataAmountsOffCurrency.Tzs,
            "uah" => DataAmountsOffCurrency.Uah,
            "uzs" => DataAmountsOffCurrency.Uzs,
            "vnd" => DataAmountsOffCurrency.Vnd,
            "vuv" => DataAmountsOffCurrency.Vuv,
            "wst" => DataAmountsOffCurrency.Wst,
            "xaf" => DataAmountsOffCurrency.Xaf,
            "xcd" => DataAmountsOffCurrency.Xcd,
            "yer" => DataAmountsOffCurrency.Yer,
            "zar" => DataAmountsOffCurrency.Zar,
            "zmw" => DataAmountsOffCurrency.Zmw,
            "clp" => DataAmountsOffCurrency.Clp,
            "djf" => DataAmountsOffCurrency.Djf,
            "gnf" => DataAmountsOffCurrency.Gnf,
            "ugx" => DataAmountsOffCurrency.Ugx,
            "pyg" => DataAmountsOffCurrency.Pyg,
            "xof" => DataAmountsOffCurrency.Xof,
            "xpf" => DataAmountsOffCurrency.Xpf,
            _ => (DataAmountsOffCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DataAmountsOffCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DataAmountsOffCurrency.Usd => "usd",
                DataAmountsOffCurrency.Aed => "aed",
                DataAmountsOffCurrency.All => "all",
                DataAmountsOffCurrency.Amd => "amd",
                DataAmountsOffCurrency.Ang => "ang",
                DataAmountsOffCurrency.Aud => "aud",
                DataAmountsOffCurrency.Awg => "awg",
                DataAmountsOffCurrency.Azn => "azn",
                DataAmountsOffCurrency.Bam => "bam",
                DataAmountsOffCurrency.Bbd => "bbd",
                DataAmountsOffCurrency.Bdt => "bdt",
                DataAmountsOffCurrency.Bgn => "bgn",
                DataAmountsOffCurrency.Bif => "bif",
                DataAmountsOffCurrency.Bmd => "bmd",
                DataAmountsOffCurrency.Bnd => "bnd",
                DataAmountsOffCurrency.Bsd => "bsd",
                DataAmountsOffCurrency.Bwp => "bwp",
                DataAmountsOffCurrency.Byn => "byn",
                DataAmountsOffCurrency.Bzd => "bzd",
                DataAmountsOffCurrency.Brl => "brl",
                DataAmountsOffCurrency.Cad => "cad",
                DataAmountsOffCurrency.Cdf => "cdf",
                DataAmountsOffCurrency.Chf => "chf",
                DataAmountsOffCurrency.Cny => "cny",
                DataAmountsOffCurrency.Czk => "czk",
                DataAmountsOffCurrency.Dkk => "dkk",
                DataAmountsOffCurrency.Dop => "dop",
                DataAmountsOffCurrency.Dzd => "dzd",
                DataAmountsOffCurrency.Egp => "egp",
                DataAmountsOffCurrency.Etb => "etb",
                DataAmountsOffCurrency.Eur => "eur",
                DataAmountsOffCurrency.Fjd => "fjd",
                DataAmountsOffCurrency.Gbp => "gbp",
                DataAmountsOffCurrency.Gel => "gel",
                DataAmountsOffCurrency.Gip => "gip",
                DataAmountsOffCurrency.Gmd => "gmd",
                DataAmountsOffCurrency.Gyd => "gyd",
                DataAmountsOffCurrency.Hkd => "hkd",
                DataAmountsOffCurrency.Hrk => "hrk",
                DataAmountsOffCurrency.Htg => "htg",
                DataAmountsOffCurrency.Idr => "idr",
                DataAmountsOffCurrency.Ils => "ils",
                DataAmountsOffCurrency.Inr => "inr",
                DataAmountsOffCurrency.Isk => "isk",
                DataAmountsOffCurrency.Jmd => "jmd",
                DataAmountsOffCurrency.Jpy => "jpy",
                DataAmountsOffCurrency.Kes => "kes",
                DataAmountsOffCurrency.Kgs => "kgs",
                DataAmountsOffCurrency.Khr => "khr",
                DataAmountsOffCurrency.Kmf => "kmf",
                DataAmountsOffCurrency.Krw => "krw",
                DataAmountsOffCurrency.Kyd => "kyd",
                DataAmountsOffCurrency.Kzt => "kzt",
                DataAmountsOffCurrency.Lbp => "lbp",
                DataAmountsOffCurrency.Lkr => "lkr",
                DataAmountsOffCurrency.Lrd => "lrd",
                DataAmountsOffCurrency.Lsl => "lsl",
                DataAmountsOffCurrency.Mad => "mad",
                DataAmountsOffCurrency.Mdl => "mdl",
                DataAmountsOffCurrency.Mga => "mga",
                DataAmountsOffCurrency.Mkd => "mkd",
                DataAmountsOffCurrency.Mmk => "mmk",
                DataAmountsOffCurrency.Mnt => "mnt",
                DataAmountsOffCurrency.Mop => "mop",
                DataAmountsOffCurrency.Mro => "mro",
                DataAmountsOffCurrency.Mvr => "mvr",
                DataAmountsOffCurrency.Mwk => "mwk",
                DataAmountsOffCurrency.Mxn => "mxn",
                DataAmountsOffCurrency.Myr => "myr",
                DataAmountsOffCurrency.Mzn => "mzn",
                DataAmountsOffCurrency.Nad => "nad",
                DataAmountsOffCurrency.Ngn => "ngn",
                DataAmountsOffCurrency.Nok => "nok",
                DataAmountsOffCurrency.Npr => "npr",
                DataAmountsOffCurrency.Nzd => "nzd",
                DataAmountsOffCurrency.Pgk => "pgk",
                DataAmountsOffCurrency.Php => "php",
                DataAmountsOffCurrency.Pkr => "pkr",
                DataAmountsOffCurrency.Pln => "pln",
                DataAmountsOffCurrency.Qar => "qar",
                DataAmountsOffCurrency.Ron => "ron",
                DataAmountsOffCurrency.Rsd => "rsd",
                DataAmountsOffCurrency.Rub => "rub",
                DataAmountsOffCurrency.Rwf => "rwf",
                DataAmountsOffCurrency.Sar => "sar",
                DataAmountsOffCurrency.Sbd => "sbd",
                DataAmountsOffCurrency.Scr => "scr",
                DataAmountsOffCurrency.Sek => "sek",
                DataAmountsOffCurrency.Sgd => "sgd",
                DataAmountsOffCurrency.Sle => "sle",
                DataAmountsOffCurrency.Sll => "sll",
                DataAmountsOffCurrency.Sos => "sos",
                DataAmountsOffCurrency.Szl => "szl",
                DataAmountsOffCurrency.Thb => "thb",
                DataAmountsOffCurrency.Tjs => "tjs",
                DataAmountsOffCurrency.Top => "top",
                DataAmountsOffCurrency.Try => "try",
                DataAmountsOffCurrency.Ttd => "ttd",
                DataAmountsOffCurrency.Tzs => "tzs",
                DataAmountsOffCurrency.Uah => "uah",
                DataAmountsOffCurrency.Uzs => "uzs",
                DataAmountsOffCurrency.Vnd => "vnd",
                DataAmountsOffCurrency.Vuv => "vuv",
                DataAmountsOffCurrency.Wst => "wst",
                DataAmountsOffCurrency.Xaf => "xaf",
                DataAmountsOffCurrency.Xcd => "xcd",
                DataAmountsOffCurrency.Yer => "yer",
                DataAmountsOffCurrency.Zar => "zar",
                DataAmountsOffCurrency.Zmw => "zmw",
                DataAmountsOffCurrency.Clp => "clp",
                DataAmountsOffCurrency.Djf => "djf",
                DataAmountsOffCurrency.Gnf => "gnf",
                DataAmountsOffCurrency.Ugx => "ugx",
                DataAmountsOffCurrency.Pyg => "pyg",
                DataAmountsOffCurrency.Xof => "xof",
                DataAmountsOffCurrency.Xpf => "xpf",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The source of the coupon
/// </summary>
[JsonConverter(typeof(SourceConverter))]
public enum Source
{
    Stigg,
    StiggAdhoc,
    Stripe,
}

sealed class SourceConverter : JsonConverter<Source>
{
    public override Source Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "STIGG" => Source.Stigg,
            "STIGG_ADHOC" => Source.StiggAdhoc,
            "STRIPE" => Source.Stripe,
            _ => (Source)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Source value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Source.Stigg => "STIGG",
                Source.StiggAdhoc => "STIGG_ADHOC",
                Source.Stripe => "STRIPE",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Current status of the coupon
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Active,
    Archived,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ACTIVE" => Status.Active,
            "ARCHIVED" => Status.Archived,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Active => "ACTIVE",
                Status.Archived => "ARCHIVED",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Type of the coupon (percentage or fixed amount)
/// </summary>
[JsonConverter(typeof(DataTypeConverter))]
public enum DataType
{
    Fixed,
    Percentage,
}

sealed class DataTypeConverter : JsonConverter<DataType>
{
    public override DataType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FIXED" => DataType.Fixed,
            "PERCENTAGE" => DataType.Percentage,
            _ => (DataType)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, DataType value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DataType.Fixed => "FIXED",
                DataType.Percentage => "PERCENTAGE",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
