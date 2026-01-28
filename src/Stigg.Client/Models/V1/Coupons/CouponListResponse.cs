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
/// Discount instrument with percentage or fixed amount
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CouponListResponse, CouponListResponseFromRaw>))]
public sealed record class CouponListResponse : JsonModel
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
    public required IReadOnlyList<CouponListResponseAmountsOff>? AmountsOff
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<CouponListResponseAmountsOff>>(
                "amountsOff"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<CouponListResponseAmountsOff>?>(
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
    public required ApiEnum<string, CouponListResponseSource>? Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CouponListResponseSource>>(
                "source"
            );
        }
        init { this._rawData.Set("source", value); }
    }

    /// <summary>
    /// Current status of the coupon
    /// </summary>
    public required ApiEnum<string, CouponListResponseStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CouponListResponseStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Type of the coupon (percentage or fixed amount)
    /// </summary>
    public required ApiEnum<string, CouponListResponseType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CouponListResponseType>>("type");
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

    public CouponListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CouponListResponse(CouponListResponse couponListResponse)
        : base(couponListResponse) { }
#pragma warning restore CS8618

    public CouponListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CouponListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CouponListResponseFromRaw.FromRawUnchecked"/>
    public static CouponListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CouponListResponseFromRaw : IFromRawJson<CouponListResponse>
{
    /// <inheritdoc/>
    public CouponListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CouponListResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Monetary amount with currency
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<CouponListResponseAmountsOff, CouponListResponseAmountsOffFromRaw>)
)]
public sealed record class CouponListResponseAmountsOff : JsonModel
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
    public required ApiEnum<string, CouponListResponseAmountsOffCurrency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, CouponListResponseAmountsOffCurrency>
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

    public CouponListResponseAmountsOff() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CouponListResponseAmountsOff(CouponListResponseAmountsOff couponListResponseAmountsOff)
        : base(couponListResponseAmountsOff) { }
#pragma warning restore CS8618

    public CouponListResponseAmountsOff(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CouponListResponseAmountsOff(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CouponListResponseAmountsOffFromRaw.FromRawUnchecked"/>
    public static CouponListResponseAmountsOff FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CouponListResponseAmountsOffFromRaw : IFromRawJson<CouponListResponseAmountsOff>
{
    /// <inheritdoc/>
    public CouponListResponseAmountsOff FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CouponListResponseAmountsOff.FromRawUnchecked(rawData);
}

/// <summary>
/// The price currency
/// </summary>
[JsonConverter(typeof(CouponListResponseAmountsOffCurrencyConverter))]
public enum CouponListResponseAmountsOffCurrency
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

sealed class CouponListResponseAmountsOffCurrencyConverter
    : JsonConverter<CouponListResponseAmountsOffCurrency>
{
    public override CouponListResponseAmountsOffCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => CouponListResponseAmountsOffCurrency.Usd,
            "aed" => CouponListResponseAmountsOffCurrency.Aed,
            "all" => CouponListResponseAmountsOffCurrency.All,
            "amd" => CouponListResponseAmountsOffCurrency.Amd,
            "ang" => CouponListResponseAmountsOffCurrency.Ang,
            "aud" => CouponListResponseAmountsOffCurrency.Aud,
            "awg" => CouponListResponseAmountsOffCurrency.Awg,
            "azn" => CouponListResponseAmountsOffCurrency.Azn,
            "bam" => CouponListResponseAmountsOffCurrency.Bam,
            "bbd" => CouponListResponseAmountsOffCurrency.Bbd,
            "bdt" => CouponListResponseAmountsOffCurrency.Bdt,
            "bgn" => CouponListResponseAmountsOffCurrency.Bgn,
            "bif" => CouponListResponseAmountsOffCurrency.Bif,
            "bmd" => CouponListResponseAmountsOffCurrency.Bmd,
            "bnd" => CouponListResponseAmountsOffCurrency.Bnd,
            "bsd" => CouponListResponseAmountsOffCurrency.Bsd,
            "bwp" => CouponListResponseAmountsOffCurrency.Bwp,
            "byn" => CouponListResponseAmountsOffCurrency.Byn,
            "bzd" => CouponListResponseAmountsOffCurrency.Bzd,
            "brl" => CouponListResponseAmountsOffCurrency.Brl,
            "cad" => CouponListResponseAmountsOffCurrency.Cad,
            "cdf" => CouponListResponseAmountsOffCurrency.Cdf,
            "chf" => CouponListResponseAmountsOffCurrency.Chf,
            "cny" => CouponListResponseAmountsOffCurrency.Cny,
            "czk" => CouponListResponseAmountsOffCurrency.Czk,
            "dkk" => CouponListResponseAmountsOffCurrency.Dkk,
            "dop" => CouponListResponseAmountsOffCurrency.Dop,
            "dzd" => CouponListResponseAmountsOffCurrency.Dzd,
            "egp" => CouponListResponseAmountsOffCurrency.Egp,
            "etb" => CouponListResponseAmountsOffCurrency.Etb,
            "eur" => CouponListResponseAmountsOffCurrency.Eur,
            "fjd" => CouponListResponseAmountsOffCurrency.Fjd,
            "gbp" => CouponListResponseAmountsOffCurrency.Gbp,
            "gel" => CouponListResponseAmountsOffCurrency.Gel,
            "gip" => CouponListResponseAmountsOffCurrency.Gip,
            "gmd" => CouponListResponseAmountsOffCurrency.Gmd,
            "gyd" => CouponListResponseAmountsOffCurrency.Gyd,
            "hkd" => CouponListResponseAmountsOffCurrency.Hkd,
            "hrk" => CouponListResponseAmountsOffCurrency.Hrk,
            "htg" => CouponListResponseAmountsOffCurrency.Htg,
            "idr" => CouponListResponseAmountsOffCurrency.Idr,
            "ils" => CouponListResponseAmountsOffCurrency.Ils,
            "inr" => CouponListResponseAmountsOffCurrency.Inr,
            "isk" => CouponListResponseAmountsOffCurrency.Isk,
            "jmd" => CouponListResponseAmountsOffCurrency.Jmd,
            "jpy" => CouponListResponseAmountsOffCurrency.Jpy,
            "kes" => CouponListResponseAmountsOffCurrency.Kes,
            "kgs" => CouponListResponseAmountsOffCurrency.Kgs,
            "khr" => CouponListResponseAmountsOffCurrency.Khr,
            "kmf" => CouponListResponseAmountsOffCurrency.Kmf,
            "krw" => CouponListResponseAmountsOffCurrency.Krw,
            "kyd" => CouponListResponseAmountsOffCurrency.Kyd,
            "kzt" => CouponListResponseAmountsOffCurrency.Kzt,
            "lbp" => CouponListResponseAmountsOffCurrency.Lbp,
            "lkr" => CouponListResponseAmountsOffCurrency.Lkr,
            "lrd" => CouponListResponseAmountsOffCurrency.Lrd,
            "lsl" => CouponListResponseAmountsOffCurrency.Lsl,
            "mad" => CouponListResponseAmountsOffCurrency.Mad,
            "mdl" => CouponListResponseAmountsOffCurrency.Mdl,
            "mga" => CouponListResponseAmountsOffCurrency.Mga,
            "mkd" => CouponListResponseAmountsOffCurrency.Mkd,
            "mmk" => CouponListResponseAmountsOffCurrency.Mmk,
            "mnt" => CouponListResponseAmountsOffCurrency.Mnt,
            "mop" => CouponListResponseAmountsOffCurrency.Mop,
            "mro" => CouponListResponseAmountsOffCurrency.Mro,
            "mvr" => CouponListResponseAmountsOffCurrency.Mvr,
            "mwk" => CouponListResponseAmountsOffCurrency.Mwk,
            "mxn" => CouponListResponseAmountsOffCurrency.Mxn,
            "myr" => CouponListResponseAmountsOffCurrency.Myr,
            "mzn" => CouponListResponseAmountsOffCurrency.Mzn,
            "nad" => CouponListResponseAmountsOffCurrency.Nad,
            "ngn" => CouponListResponseAmountsOffCurrency.Ngn,
            "nok" => CouponListResponseAmountsOffCurrency.Nok,
            "npr" => CouponListResponseAmountsOffCurrency.Npr,
            "nzd" => CouponListResponseAmountsOffCurrency.Nzd,
            "pgk" => CouponListResponseAmountsOffCurrency.Pgk,
            "php" => CouponListResponseAmountsOffCurrency.Php,
            "pkr" => CouponListResponseAmountsOffCurrency.Pkr,
            "pln" => CouponListResponseAmountsOffCurrency.Pln,
            "qar" => CouponListResponseAmountsOffCurrency.Qar,
            "ron" => CouponListResponseAmountsOffCurrency.Ron,
            "rsd" => CouponListResponseAmountsOffCurrency.Rsd,
            "rub" => CouponListResponseAmountsOffCurrency.Rub,
            "rwf" => CouponListResponseAmountsOffCurrency.Rwf,
            "sar" => CouponListResponseAmountsOffCurrency.Sar,
            "sbd" => CouponListResponseAmountsOffCurrency.Sbd,
            "scr" => CouponListResponseAmountsOffCurrency.Scr,
            "sek" => CouponListResponseAmountsOffCurrency.Sek,
            "sgd" => CouponListResponseAmountsOffCurrency.Sgd,
            "sle" => CouponListResponseAmountsOffCurrency.Sle,
            "sll" => CouponListResponseAmountsOffCurrency.Sll,
            "sos" => CouponListResponseAmountsOffCurrency.Sos,
            "szl" => CouponListResponseAmountsOffCurrency.Szl,
            "thb" => CouponListResponseAmountsOffCurrency.Thb,
            "tjs" => CouponListResponseAmountsOffCurrency.Tjs,
            "top" => CouponListResponseAmountsOffCurrency.Top,
            "try" => CouponListResponseAmountsOffCurrency.Try,
            "ttd" => CouponListResponseAmountsOffCurrency.Ttd,
            "tzs" => CouponListResponseAmountsOffCurrency.Tzs,
            "uah" => CouponListResponseAmountsOffCurrency.Uah,
            "uzs" => CouponListResponseAmountsOffCurrency.Uzs,
            "vnd" => CouponListResponseAmountsOffCurrency.Vnd,
            "vuv" => CouponListResponseAmountsOffCurrency.Vuv,
            "wst" => CouponListResponseAmountsOffCurrency.Wst,
            "xaf" => CouponListResponseAmountsOffCurrency.Xaf,
            "xcd" => CouponListResponseAmountsOffCurrency.Xcd,
            "yer" => CouponListResponseAmountsOffCurrency.Yer,
            "zar" => CouponListResponseAmountsOffCurrency.Zar,
            "zmw" => CouponListResponseAmountsOffCurrency.Zmw,
            "clp" => CouponListResponseAmountsOffCurrency.Clp,
            "djf" => CouponListResponseAmountsOffCurrency.Djf,
            "gnf" => CouponListResponseAmountsOffCurrency.Gnf,
            "ugx" => CouponListResponseAmountsOffCurrency.Ugx,
            "pyg" => CouponListResponseAmountsOffCurrency.Pyg,
            "xof" => CouponListResponseAmountsOffCurrency.Xof,
            "xpf" => CouponListResponseAmountsOffCurrency.Xpf,
            _ => (CouponListResponseAmountsOffCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CouponListResponseAmountsOffCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CouponListResponseAmountsOffCurrency.Usd => "usd",
                CouponListResponseAmountsOffCurrency.Aed => "aed",
                CouponListResponseAmountsOffCurrency.All => "all",
                CouponListResponseAmountsOffCurrency.Amd => "amd",
                CouponListResponseAmountsOffCurrency.Ang => "ang",
                CouponListResponseAmountsOffCurrency.Aud => "aud",
                CouponListResponseAmountsOffCurrency.Awg => "awg",
                CouponListResponseAmountsOffCurrency.Azn => "azn",
                CouponListResponseAmountsOffCurrency.Bam => "bam",
                CouponListResponseAmountsOffCurrency.Bbd => "bbd",
                CouponListResponseAmountsOffCurrency.Bdt => "bdt",
                CouponListResponseAmountsOffCurrency.Bgn => "bgn",
                CouponListResponseAmountsOffCurrency.Bif => "bif",
                CouponListResponseAmountsOffCurrency.Bmd => "bmd",
                CouponListResponseAmountsOffCurrency.Bnd => "bnd",
                CouponListResponseAmountsOffCurrency.Bsd => "bsd",
                CouponListResponseAmountsOffCurrency.Bwp => "bwp",
                CouponListResponseAmountsOffCurrency.Byn => "byn",
                CouponListResponseAmountsOffCurrency.Bzd => "bzd",
                CouponListResponseAmountsOffCurrency.Brl => "brl",
                CouponListResponseAmountsOffCurrency.Cad => "cad",
                CouponListResponseAmountsOffCurrency.Cdf => "cdf",
                CouponListResponseAmountsOffCurrency.Chf => "chf",
                CouponListResponseAmountsOffCurrency.Cny => "cny",
                CouponListResponseAmountsOffCurrency.Czk => "czk",
                CouponListResponseAmountsOffCurrency.Dkk => "dkk",
                CouponListResponseAmountsOffCurrency.Dop => "dop",
                CouponListResponseAmountsOffCurrency.Dzd => "dzd",
                CouponListResponseAmountsOffCurrency.Egp => "egp",
                CouponListResponseAmountsOffCurrency.Etb => "etb",
                CouponListResponseAmountsOffCurrency.Eur => "eur",
                CouponListResponseAmountsOffCurrency.Fjd => "fjd",
                CouponListResponseAmountsOffCurrency.Gbp => "gbp",
                CouponListResponseAmountsOffCurrency.Gel => "gel",
                CouponListResponseAmountsOffCurrency.Gip => "gip",
                CouponListResponseAmountsOffCurrency.Gmd => "gmd",
                CouponListResponseAmountsOffCurrency.Gyd => "gyd",
                CouponListResponseAmountsOffCurrency.Hkd => "hkd",
                CouponListResponseAmountsOffCurrency.Hrk => "hrk",
                CouponListResponseAmountsOffCurrency.Htg => "htg",
                CouponListResponseAmountsOffCurrency.Idr => "idr",
                CouponListResponseAmountsOffCurrency.Ils => "ils",
                CouponListResponseAmountsOffCurrency.Inr => "inr",
                CouponListResponseAmountsOffCurrency.Isk => "isk",
                CouponListResponseAmountsOffCurrency.Jmd => "jmd",
                CouponListResponseAmountsOffCurrency.Jpy => "jpy",
                CouponListResponseAmountsOffCurrency.Kes => "kes",
                CouponListResponseAmountsOffCurrency.Kgs => "kgs",
                CouponListResponseAmountsOffCurrency.Khr => "khr",
                CouponListResponseAmountsOffCurrency.Kmf => "kmf",
                CouponListResponseAmountsOffCurrency.Krw => "krw",
                CouponListResponseAmountsOffCurrency.Kyd => "kyd",
                CouponListResponseAmountsOffCurrency.Kzt => "kzt",
                CouponListResponseAmountsOffCurrency.Lbp => "lbp",
                CouponListResponseAmountsOffCurrency.Lkr => "lkr",
                CouponListResponseAmountsOffCurrency.Lrd => "lrd",
                CouponListResponseAmountsOffCurrency.Lsl => "lsl",
                CouponListResponseAmountsOffCurrency.Mad => "mad",
                CouponListResponseAmountsOffCurrency.Mdl => "mdl",
                CouponListResponseAmountsOffCurrency.Mga => "mga",
                CouponListResponseAmountsOffCurrency.Mkd => "mkd",
                CouponListResponseAmountsOffCurrency.Mmk => "mmk",
                CouponListResponseAmountsOffCurrency.Mnt => "mnt",
                CouponListResponseAmountsOffCurrency.Mop => "mop",
                CouponListResponseAmountsOffCurrency.Mro => "mro",
                CouponListResponseAmountsOffCurrency.Mvr => "mvr",
                CouponListResponseAmountsOffCurrency.Mwk => "mwk",
                CouponListResponseAmountsOffCurrency.Mxn => "mxn",
                CouponListResponseAmountsOffCurrency.Myr => "myr",
                CouponListResponseAmountsOffCurrency.Mzn => "mzn",
                CouponListResponseAmountsOffCurrency.Nad => "nad",
                CouponListResponseAmountsOffCurrency.Ngn => "ngn",
                CouponListResponseAmountsOffCurrency.Nok => "nok",
                CouponListResponseAmountsOffCurrency.Npr => "npr",
                CouponListResponseAmountsOffCurrency.Nzd => "nzd",
                CouponListResponseAmountsOffCurrency.Pgk => "pgk",
                CouponListResponseAmountsOffCurrency.Php => "php",
                CouponListResponseAmountsOffCurrency.Pkr => "pkr",
                CouponListResponseAmountsOffCurrency.Pln => "pln",
                CouponListResponseAmountsOffCurrency.Qar => "qar",
                CouponListResponseAmountsOffCurrency.Ron => "ron",
                CouponListResponseAmountsOffCurrency.Rsd => "rsd",
                CouponListResponseAmountsOffCurrency.Rub => "rub",
                CouponListResponseAmountsOffCurrency.Rwf => "rwf",
                CouponListResponseAmountsOffCurrency.Sar => "sar",
                CouponListResponseAmountsOffCurrency.Sbd => "sbd",
                CouponListResponseAmountsOffCurrency.Scr => "scr",
                CouponListResponseAmountsOffCurrency.Sek => "sek",
                CouponListResponseAmountsOffCurrency.Sgd => "sgd",
                CouponListResponseAmountsOffCurrency.Sle => "sle",
                CouponListResponseAmountsOffCurrency.Sll => "sll",
                CouponListResponseAmountsOffCurrency.Sos => "sos",
                CouponListResponseAmountsOffCurrency.Szl => "szl",
                CouponListResponseAmountsOffCurrency.Thb => "thb",
                CouponListResponseAmountsOffCurrency.Tjs => "tjs",
                CouponListResponseAmountsOffCurrency.Top => "top",
                CouponListResponseAmountsOffCurrency.Try => "try",
                CouponListResponseAmountsOffCurrency.Ttd => "ttd",
                CouponListResponseAmountsOffCurrency.Tzs => "tzs",
                CouponListResponseAmountsOffCurrency.Uah => "uah",
                CouponListResponseAmountsOffCurrency.Uzs => "uzs",
                CouponListResponseAmountsOffCurrency.Vnd => "vnd",
                CouponListResponseAmountsOffCurrency.Vuv => "vuv",
                CouponListResponseAmountsOffCurrency.Wst => "wst",
                CouponListResponseAmountsOffCurrency.Xaf => "xaf",
                CouponListResponseAmountsOffCurrency.Xcd => "xcd",
                CouponListResponseAmountsOffCurrency.Yer => "yer",
                CouponListResponseAmountsOffCurrency.Zar => "zar",
                CouponListResponseAmountsOffCurrency.Zmw => "zmw",
                CouponListResponseAmountsOffCurrency.Clp => "clp",
                CouponListResponseAmountsOffCurrency.Djf => "djf",
                CouponListResponseAmountsOffCurrency.Gnf => "gnf",
                CouponListResponseAmountsOffCurrency.Ugx => "ugx",
                CouponListResponseAmountsOffCurrency.Pyg => "pyg",
                CouponListResponseAmountsOffCurrency.Xof => "xof",
                CouponListResponseAmountsOffCurrency.Xpf => "xpf",
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
[JsonConverter(typeof(CouponListResponseSourceConverter))]
public enum CouponListResponseSource
{
    Stigg,
    StiggAdhoc,
    Stripe,
}

sealed class CouponListResponseSourceConverter : JsonConverter<CouponListResponseSource>
{
    public override CouponListResponseSource Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "STIGG" => CouponListResponseSource.Stigg,
            "STIGG_ADHOC" => CouponListResponseSource.StiggAdhoc,
            "STRIPE" => CouponListResponseSource.Stripe,
            _ => (CouponListResponseSource)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CouponListResponseSource value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CouponListResponseSource.Stigg => "STIGG",
                CouponListResponseSource.StiggAdhoc => "STIGG_ADHOC",
                CouponListResponseSource.Stripe => "STRIPE",
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
[JsonConverter(typeof(CouponListResponseStatusConverter))]
public enum CouponListResponseStatus
{
    Active,
    Archived,
}

sealed class CouponListResponseStatusConverter : JsonConverter<CouponListResponseStatus>
{
    public override CouponListResponseStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ACTIVE" => CouponListResponseStatus.Active,
            "ARCHIVED" => CouponListResponseStatus.Archived,
            _ => (CouponListResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CouponListResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CouponListResponseStatus.Active => "ACTIVE",
                CouponListResponseStatus.Archived => "ARCHIVED",
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
[JsonConverter(typeof(CouponListResponseTypeConverter))]
public enum CouponListResponseType
{
    Fixed,
    Percentage,
}

sealed class CouponListResponseTypeConverter : JsonConverter<CouponListResponseType>
{
    public override CouponListResponseType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FIXED" => CouponListResponseType.Fixed,
            "PERCENTAGE" => CouponListResponseType.Percentage,
            _ => (CouponListResponseType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CouponListResponseType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CouponListResponseType.Fixed => "FIXED",
                CouponListResponseType.Percentage => "PERCENTAGE",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
