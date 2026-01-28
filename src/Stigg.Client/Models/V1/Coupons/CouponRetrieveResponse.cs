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
[JsonConverter(typeof(JsonModelConverter<CouponRetrieveResponse, CouponRetrieveResponseFromRaw>))]
public sealed record class CouponRetrieveResponse : JsonModel
{
    /// <summary>
    /// Discount instrument with percentage or fixed amount
    /// </summary>
    public required CouponRetrieveResponseData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CouponRetrieveResponseData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public CouponRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CouponRetrieveResponse(CouponRetrieveResponse couponRetrieveResponse)
        : base(couponRetrieveResponse) { }
#pragma warning restore CS8618

    public CouponRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CouponRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CouponRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static CouponRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CouponRetrieveResponse(CouponRetrieveResponseData data)
        : this()
    {
        this.Data = data;
    }
}

class CouponRetrieveResponseFromRaw : IFromRawJson<CouponRetrieveResponse>
{
    /// <inheritdoc/>
    public CouponRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CouponRetrieveResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Discount instrument with percentage or fixed amount
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<CouponRetrieveResponseData, CouponRetrieveResponseDataFromRaw>)
)]
public sealed record class CouponRetrieveResponseData : JsonModel
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
    public required IReadOnlyList<CouponRetrieveResponseDataAmountsOff>? AmountsOff
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<CouponRetrieveResponseDataAmountsOff>
            >("amountsOff");
        }
        init
        {
            this._rawData.Set<ImmutableArray<CouponRetrieveResponseDataAmountsOff>?>(
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
    public required ApiEnum<string, CouponRetrieveResponseDataSource>? Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, CouponRetrieveResponseDataSource>
            >("source");
        }
        init { this._rawData.Set("source", value); }
    }

    /// <summary>
    /// Current status of the coupon
    /// </summary>
    public required ApiEnum<string, CouponRetrieveResponseDataStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CouponRetrieveResponseDataStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Type of the coupon (percentage or fixed amount)
    /// </summary>
    public required ApiEnum<string, CouponRetrieveResponseDataType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CouponRetrieveResponseDataType>>(
                "type"
            );
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

    public CouponRetrieveResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CouponRetrieveResponseData(CouponRetrieveResponseData couponRetrieveResponseData)
        : base(couponRetrieveResponseData) { }
#pragma warning restore CS8618

    public CouponRetrieveResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CouponRetrieveResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CouponRetrieveResponseDataFromRaw.FromRawUnchecked"/>
    public static CouponRetrieveResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CouponRetrieveResponseDataFromRaw : IFromRawJson<CouponRetrieveResponseData>
{
    /// <inheritdoc/>
    public CouponRetrieveResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CouponRetrieveResponseData.FromRawUnchecked(rawData);
}

/// <summary>
/// Monetary amount with currency
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CouponRetrieveResponseDataAmountsOff,
        CouponRetrieveResponseDataAmountsOffFromRaw
    >)
)]
public sealed record class CouponRetrieveResponseDataAmountsOff : JsonModel
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
    public required ApiEnum<string, CouponRetrieveResponseDataAmountsOffCurrency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, CouponRetrieveResponseDataAmountsOffCurrency>
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

    public CouponRetrieveResponseDataAmountsOff() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CouponRetrieveResponseDataAmountsOff(
        CouponRetrieveResponseDataAmountsOff couponRetrieveResponseDataAmountsOff
    )
        : base(couponRetrieveResponseDataAmountsOff) { }
#pragma warning restore CS8618

    public CouponRetrieveResponseDataAmountsOff(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CouponRetrieveResponseDataAmountsOff(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CouponRetrieveResponseDataAmountsOffFromRaw.FromRawUnchecked"/>
    public static CouponRetrieveResponseDataAmountsOff FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CouponRetrieveResponseDataAmountsOffFromRaw
    : IFromRawJson<CouponRetrieveResponseDataAmountsOff>
{
    /// <inheritdoc/>
    public CouponRetrieveResponseDataAmountsOff FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CouponRetrieveResponseDataAmountsOff.FromRawUnchecked(rawData);
}

/// <summary>
/// The price currency
/// </summary>
[JsonConverter(typeof(CouponRetrieveResponseDataAmountsOffCurrencyConverter))]
public enum CouponRetrieveResponseDataAmountsOffCurrency
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

sealed class CouponRetrieveResponseDataAmountsOffCurrencyConverter
    : JsonConverter<CouponRetrieveResponseDataAmountsOffCurrency>
{
    public override CouponRetrieveResponseDataAmountsOffCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => CouponRetrieveResponseDataAmountsOffCurrency.Usd,
            "aed" => CouponRetrieveResponseDataAmountsOffCurrency.Aed,
            "all" => CouponRetrieveResponseDataAmountsOffCurrency.All,
            "amd" => CouponRetrieveResponseDataAmountsOffCurrency.Amd,
            "ang" => CouponRetrieveResponseDataAmountsOffCurrency.Ang,
            "aud" => CouponRetrieveResponseDataAmountsOffCurrency.Aud,
            "awg" => CouponRetrieveResponseDataAmountsOffCurrency.Awg,
            "azn" => CouponRetrieveResponseDataAmountsOffCurrency.Azn,
            "bam" => CouponRetrieveResponseDataAmountsOffCurrency.Bam,
            "bbd" => CouponRetrieveResponseDataAmountsOffCurrency.Bbd,
            "bdt" => CouponRetrieveResponseDataAmountsOffCurrency.Bdt,
            "bgn" => CouponRetrieveResponseDataAmountsOffCurrency.Bgn,
            "bif" => CouponRetrieveResponseDataAmountsOffCurrency.Bif,
            "bmd" => CouponRetrieveResponseDataAmountsOffCurrency.Bmd,
            "bnd" => CouponRetrieveResponseDataAmountsOffCurrency.Bnd,
            "bsd" => CouponRetrieveResponseDataAmountsOffCurrency.Bsd,
            "bwp" => CouponRetrieveResponseDataAmountsOffCurrency.Bwp,
            "byn" => CouponRetrieveResponseDataAmountsOffCurrency.Byn,
            "bzd" => CouponRetrieveResponseDataAmountsOffCurrency.Bzd,
            "brl" => CouponRetrieveResponseDataAmountsOffCurrency.Brl,
            "cad" => CouponRetrieveResponseDataAmountsOffCurrency.Cad,
            "cdf" => CouponRetrieveResponseDataAmountsOffCurrency.Cdf,
            "chf" => CouponRetrieveResponseDataAmountsOffCurrency.Chf,
            "cny" => CouponRetrieveResponseDataAmountsOffCurrency.Cny,
            "czk" => CouponRetrieveResponseDataAmountsOffCurrency.Czk,
            "dkk" => CouponRetrieveResponseDataAmountsOffCurrency.Dkk,
            "dop" => CouponRetrieveResponseDataAmountsOffCurrency.Dop,
            "dzd" => CouponRetrieveResponseDataAmountsOffCurrency.Dzd,
            "egp" => CouponRetrieveResponseDataAmountsOffCurrency.Egp,
            "etb" => CouponRetrieveResponseDataAmountsOffCurrency.Etb,
            "eur" => CouponRetrieveResponseDataAmountsOffCurrency.Eur,
            "fjd" => CouponRetrieveResponseDataAmountsOffCurrency.Fjd,
            "gbp" => CouponRetrieveResponseDataAmountsOffCurrency.Gbp,
            "gel" => CouponRetrieveResponseDataAmountsOffCurrency.Gel,
            "gip" => CouponRetrieveResponseDataAmountsOffCurrency.Gip,
            "gmd" => CouponRetrieveResponseDataAmountsOffCurrency.Gmd,
            "gyd" => CouponRetrieveResponseDataAmountsOffCurrency.Gyd,
            "hkd" => CouponRetrieveResponseDataAmountsOffCurrency.Hkd,
            "hrk" => CouponRetrieveResponseDataAmountsOffCurrency.Hrk,
            "htg" => CouponRetrieveResponseDataAmountsOffCurrency.Htg,
            "idr" => CouponRetrieveResponseDataAmountsOffCurrency.Idr,
            "ils" => CouponRetrieveResponseDataAmountsOffCurrency.Ils,
            "inr" => CouponRetrieveResponseDataAmountsOffCurrency.Inr,
            "isk" => CouponRetrieveResponseDataAmountsOffCurrency.Isk,
            "jmd" => CouponRetrieveResponseDataAmountsOffCurrency.Jmd,
            "jpy" => CouponRetrieveResponseDataAmountsOffCurrency.Jpy,
            "kes" => CouponRetrieveResponseDataAmountsOffCurrency.Kes,
            "kgs" => CouponRetrieveResponseDataAmountsOffCurrency.Kgs,
            "khr" => CouponRetrieveResponseDataAmountsOffCurrency.Khr,
            "kmf" => CouponRetrieveResponseDataAmountsOffCurrency.Kmf,
            "krw" => CouponRetrieveResponseDataAmountsOffCurrency.Krw,
            "kyd" => CouponRetrieveResponseDataAmountsOffCurrency.Kyd,
            "kzt" => CouponRetrieveResponseDataAmountsOffCurrency.Kzt,
            "lbp" => CouponRetrieveResponseDataAmountsOffCurrency.Lbp,
            "lkr" => CouponRetrieveResponseDataAmountsOffCurrency.Lkr,
            "lrd" => CouponRetrieveResponseDataAmountsOffCurrency.Lrd,
            "lsl" => CouponRetrieveResponseDataAmountsOffCurrency.Lsl,
            "mad" => CouponRetrieveResponseDataAmountsOffCurrency.Mad,
            "mdl" => CouponRetrieveResponseDataAmountsOffCurrency.Mdl,
            "mga" => CouponRetrieveResponseDataAmountsOffCurrency.Mga,
            "mkd" => CouponRetrieveResponseDataAmountsOffCurrency.Mkd,
            "mmk" => CouponRetrieveResponseDataAmountsOffCurrency.Mmk,
            "mnt" => CouponRetrieveResponseDataAmountsOffCurrency.Mnt,
            "mop" => CouponRetrieveResponseDataAmountsOffCurrency.Mop,
            "mro" => CouponRetrieveResponseDataAmountsOffCurrency.Mro,
            "mvr" => CouponRetrieveResponseDataAmountsOffCurrency.Mvr,
            "mwk" => CouponRetrieveResponseDataAmountsOffCurrency.Mwk,
            "mxn" => CouponRetrieveResponseDataAmountsOffCurrency.Mxn,
            "myr" => CouponRetrieveResponseDataAmountsOffCurrency.Myr,
            "mzn" => CouponRetrieveResponseDataAmountsOffCurrency.Mzn,
            "nad" => CouponRetrieveResponseDataAmountsOffCurrency.Nad,
            "ngn" => CouponRetrieveResponseDataAmountsOffCurrency.Ngn,
            "nok" => CouponRetrieveResponseDataAmountsOffCurrency.Nok,
            "npr" => CouponRetrieveResponseDataAmountsOffCurrency.Npr,
            "nzd" => CouponRetrieveResponseDataAmountsOffCurrency.Nzd,
            "pgk" => CouponRetrieveResponseDataAmountsOffCurrency.Pgk,
            "php" => CouponRetrieveResponseDataAmountsOffCurrency.Php,
            "pkr" => CouponRetrieveResponseDataAmountsOffCurrency.Pkr,
            "pln" => CouponRetrieveResponseDataAmountsOffCurrency.Pln,
            "qar" => CouponRetrieveResponseDataAmountsOffCurrency.Qar,
            "ron" => CouponRetrieveResponseDataAmountsOffCurrency.Ron,
            "rsd" => CouponRetrieveResponseDataAmountsOffCurrency.Rsd,
            "rub" => CouponRetrieveResponseDataAmountsOffCurrency.Rub,
            "rwf" => CouponRetrieveResponseDataAmountsOffCurrency.Rwf,
            "sar" => CouponRetrieveResponseDataAmountsOffCurrency.Sar,
            "sbd" => CouponRetrieveResponseDataAmountsOffCurrency.Sbd,
            "scr" => CouponRetrieveResponseDataAmountsOffCurrency.Scr,
            "sek" => CouponRetrieveResponseDataAmountsOffCurrency.Sek,
            "sgd" => CouponRetrieveResponseDataAmountsOffCurrency.Sgd,
            "sle" => CouponRetrieveResponseDataAmountsOffCurrency.Sle,
            "sll" => CouponRetrieveResponseDataAmountsOffCurrency.Sll,
            "sos" => CouponRetrieveResponseDataAmountsOffCurrency.Sos,
            "szl" => CouponRetrieveResponseDataAmountsOffCurrency.Szl,
            "thb" => CouponRetrieveResponseDataAmountsOffCurrency.Thb,
            "tjs" => CouponRetrieveResponseDataAmountsOffCurrency.Tjs,
            "top" => CouponRetrieveResponseDataAmountsOffCurrency.Top,
            "try" => CouponRetrieveResponseDataAmountsOffCurrency.Try,
            "ttd" => CouponRetrieveResponseDataAmountsOffCurrency.Ttd,
            "tzs" => CouponRetrieveResponseDataAmountsOffCurrency.Tzs,
            "uah" => CouponRetrieveResponseDataAmountsOffCurrency.Uah,
            "uzs" => CouponRetrieveResponseDataAmountsOffCurrency.Uzs,
            "vnd" => CouponRetrieveResponseDataAmountsOffCurrency.Vnd,
            "vuv" => CouponRetrieveResponseDataAmountsOffCurrency.Vuv,
            "wst" => CouponRetrieveResponseDataAmountsOffCurrency.Wst,
            "xaf" => CouponRetrieveResponseDataAmountsOffCurrency.Xaf,
            "xcd" => CouponRetrieveResponseDataAmountsOffCurrency.Xcd,
            "yer" => CouponRetrieveResponseDataAmountsOffCurrency.Yer,
            "zar" => CouponRetrieveResponseDataAmountsOffCurrency.Zar,
            "zmw" => CouponRetrieveResponseDataAmountsOffCurrency.Zmw,
            "clp" => CouponRetrieveResponseDataAmountsOffCurrency.Clp,
            "djf" => CouponRetrieveResponseDataAmountsOffCurrency.Djf,
            "gnf" => CouponRetrieveResponseDataAmountsOffCurrency.Gnf,
            "ugx" => CouponRetrieveResponseDataAmountsOffCurrency.Ugx,
            "pyg" => CouponRetrieveResponseDataAmountsOffCurrency.Pyg,
            "xof" => CouponRetrieveResponseDataAmountsOffCurrency.Xof,
            "xpf" => CouponRetrieveResponseDataAmountsOffCurrency.Xpf,
            _ => (CouponRetrieveResponseDataAmountsOffCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CouponRetrieveResponseDataAmountsOffCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CouponRetrieveResponseDataAmountsOffCurrency.Usd => "usd",
                CouponRetrieveResponseDataAmountsOffCurrency.Aed => "aed",
                CouponRetrieveResponseDataAmountsOffCurrency.All => "all",
                CouponRetrieveResponseDataAmountsOffCurrency.Amd => "amd",
                CouponRetrieveResponseDataAmountsOffCurrency.Ang => "ang",
                CouponRetrieveResponseDataAmountsOffCurrency.Aud => "aud",
                CouponRetrieveResponseDataAmountsOffCurrency.Awg => "awg",
                CouponRetrieveResponseDataAmountsOffCurrency.Azn => "azn",
                CouponRetrieveResponseDataAmountsOffCurrency.Bam => "bam",
                CouponRetrieveResponseDataAmountsOffCurrency.Bbd => "bbd",
                CouponRetrieveResponseDataAmountsOffCurrency.Bdt => "bdt",
                CouponRetrieveResponseDataAmountsOffCurrency.Bgn => "bgn",
                CouponRetrieveResponseDataAmountsOffCurrency.Bif => "bif",
                CouponRetrieveResponseDataAmountsOffCurrency.Bmd => "bmd",
                CouponRetrieveResponseDataAmountsOffCurrency.Bnd => "bnd",
                CouponRetrieveResponseDataAmountsOffCurrency.Bsd => "bsd",
                CouponRetrieveResponseDataAmountsOffCurrency.Bwp => "bwp",
                CouponRetrieveResponseDataAmountsOffCurrency.Byn => "byn",
                CouponRetrieveResponseDataAmountsOffCurrency.Bzd => "bzd",
                CouponRetrieveResponseDataAmountsOffCurrency.Brl => "brl",
                CouponRetrieveResponseDataAmountsOffCurrency.Cad => "cad",
                CouponRetrieveResponseDataAmountsOffCurrency.Cdf => "cdf",
                CouponRetrieveResponseDataAmountsOffCurrency.Chf => "chf",
                CouponRetrieveResponseDataAmountsOffCurrency.Cny => "cny",
                CouponRetrieveResponseDataAmountsOffCurrency.Czk => "czk",
                CouponRetrieveResponseDataAmountsOffCurrency.Dkk => "dkk",
                CouponRetrieveResponseDataAmountsOffCurrency.Dop => "dop",
                CouponRetrieveResponseDataAmountsOffCurrency.Dzd => "dzd",
                CouponRetrieveResponseDataAmountsOffCurrency.Egp => "egp",
                CouponRetrieveResponseDataAmountsOffCurrency.Etb => "etb",
                CouponRetrieveResponseDataAmountsOffCurrency.Eur => "eur",
                CouponRetrieveResponseDataAmountsOffCurrency.Fjd => "fjd",
                CouponRetrieveResponseDataAmountsOffCurrency.Gbp => "gbp",
                CouponRetrieveResponseDataAmountsOffCurrency.Gel => "gel",
                CouponRetrieveResponseDataAmountsOffCurrency.Gip => "gip",
                CouponRetrieveResponseDataAmountsOffCurrency.Gmd => "gmd",
                CouponRetrieveResponseDataAmountsOffCurrency.Gyd => "gyd",
                CouponRetrieveResponseDataAmountsOffCurrency.Hkd => "hkd",
                CouponRetrieveResponseDataAmountsOffCurrency.Hrk => "hrk",
                CouponRetrieveResponseDataAmountsOffCurrency.Htg => "htg",
                CouponRetrieveResponseDataAmountsOffCurrency.Idr => "idr",
                CouponRetrieveResponseDataAmountsOffCurrency.Ils => "ils",
                CouponRetrieveResponseDataAmountsOffCurrency.Inr => "inr",
                CouponRetrieveResponseDataAmountsOffCurrency.Isk => "isk",
                CouponRetrieveResponseDataAmountsOffCurrency.Jmd => "jmd",
                CouponRetrieveResponseDataAmountsOffCurrency.Jpy => "jpy",
                CouponRetrieveResponseDataAmountsOffCurrency.Kes => "kes",
                CouponRetrieveResponseDataAmountsOffCurrency.Kgs => "kgs",
                CouponRetrieveResponseDataAmountsOffCurrency.Khr => "khr",
                CouponRetrieveResponseDataAmountsOffCurrency.Kmf => "kmf",
                CouponRetrieveResponseDataAmountsOffCurrency.Krw => "krw",
                CouponRetrieveResponseDataAmountsOffCurrency.Kyd => "kyd",
                CouponRetrieveResponseDataAmountsOffCurrency.Kzt => "kzt",
                CouponRetrieveResponseDataAmountsOffCurrency.Lbp => "lbp",
                CouponRetrieveResponseDataAmountsOffCurrency.Lkr => "lkr",
                CouponRetrieveResponseDataAmountsOffCurrency.Lrd => "lrd",
                CouponRetrieveResponseDataAmountsOffCurrency.Lsl => "lsl",
                CouponRetrieveResponseDataAmountsOffCurrency.Mad => "mad",
                CouponRetrieveResponseDataAmountsOffCurrency.Mdl => "mdl",
                CouponRetrieveResponseDataAmountsOffCurrency.Mga => "mga",
                CouponRetrieveResponseDataAmountsOffCurrency.Mkd => "mkd",
                CouponRetrieveResponseDataAmountsOffCurrency.Mmk => "mmk",
                CouponRetrieveResponseDataAmountsOffCurrency.Mnt => "mnt",
                CouponRetrieveResponseDataAmountsOffCurrency.Mop => "mop",
                CouponRetrieveResponseDataAmountsOffCurrency.Mro => "mro",
                CouponRetrieveResponseDataAmountsOffCurrency.Mvr => "mvr",
                CouponRetrieveResponseDataAmountsOffCurrency.Mwk => "mwk",
                CouponRetrieveResponseDataAmountsOffCurrency.Mxn => "mxn",
                CouponRetrieveResponseDataAmountsOffCurrency.Myr => "myr",
                CouponRetrieveResponseDataAmountsOffCurrency.Mzn => "mzn",
                CouponRetrieveResponseDataAmountsOffCurrency.Nad => "nad",
                CouponRetrieveResponseDataAmountsOffCurrency.Ngn => "ngn",
                CouponRetrieveResponseDataAmountsOffCurrency.Nok => "nok",
                CouponRetrieveResponseDataAmountsOffCurrency.Npr => "npr",
                CouponRetrieveResponseDataAmountsOffCurrency.Nzd => "nzd",
                CouponRetrieveResponseDataAmountsOffCurrency.Pgk => "pgk",
                CouponRetrieveResponseDataAmountsOffCurrency.Php => "php",
                CouponRetrieveResponseDataAmountsOffCurrency.Pkr => "pkr",
                CouponRetrieveResponseDataAmountsOffCurrency.Pln => "pln",
                CouponRetrieveResponseDataAmountsOffCurrency.Qar => "qar",
                CouponRetrieveResponseDataAmountsOffCurrency.Ron => "ron",
                CouponRetrieveResponseDataAmountsOffCurrency.Rsd => "rsd",
                CouponRetrieveResponseDataAmountsOffCurrency.Rub => "rub",
                CouponRetrieveResponseDataAmountsOffCurrency.Rwf => "rwf",
                CouponRetrieveResponseDataAmountsOffCurrency.Sar => "sar",
                CouponRetrieveResponseDataAmountsOffCurrency.Sbd => "sbd",
                CouponRetrieveResponseDataAmountsOffCurrency.Scr => "scr",
                CouponRetrieveResponseDataAmountsOffCurrency.Sek => "sek",
                CouponRetrieveResponseDataAmountsOffCurrency.Sgd => "sgd",
                CouponRetrieveResponseDataAmountsOffCurrency.Sle => "sle",
                CouponRetrieveResponseDataAmountsOffCurrency.Sll => "sll",
                CouponRetrieveResponseDataAmountsOffCurrency.Sos => "sos",
                CouponRetrieveResponseDataAmountsOffCurrency.Szl => "szl",
                CouponRetrieveResponseDataAmountsOffCurrency.Thb => "thb",
                CouponRetrieveResponseDataAmountsOffCurrency.Tjs => "tjs",
                CouponRetrieveResponseDataAmountsOffCurrency.Top => "top",
                CouponRetrieveResponseDataAmountsOffCurrency.Try => "try",
                CouponRetrieveResponseDataAmountsOffCurrency.Ttd => "ttd",
                CouponRetrieveResponseDataAmountsOffCurrency.Tzs => "tzs",
                CouponRetrieveResponseDataAmountsOffCurrency.Uah => "uah",
                CouponRetrieveResponseDataAmountsOffCurrency.Uzs => "uzs",
                CouponRetrieveResponseDataAmountsOffCurrency.Vnd => "vnd",
                CouponRetrieveResponseDataAmountsOffCurrency.Vuv => "vuv",
                CouponRetrieveResponseDataAmountsOffCurrency.Wst => "wst",
                CouponRetrieveResponseDataAmountsOffCurrency.Xaf => "xaf",
                CouponRetrieveResponseDataAmountsOffCurrency.Xcd => "xcd",
                CouponRetrieveResponseDataAmountsOffCurrency.Yer => "yer",
                CouponRetrieveResponseDataAmountsOffCurrency.Zar => "zar",
                CouponRetrieveResponseDataAmountsOffCurrency.Zmw => "zmw",
                CouponRetrieveResponseDataAmountsOffCurrency.Clp => "clp",
                CouponRetrieveResponseDataAmountsOffCurrency.Djf => "djf",
                CouponRetrieveResponseDataAmountsOffCurrency.Gnf => "gnf",
                CouponRetrieveResponseDataAmountsOffCurrency.Ugx => "ugx",
                CouponRetrieveResponseDataAmountsOffCurrency.Pyg => "pyg",
                CouponRetrieveResponseDataAmountsOffCurrency.Xof => "xof",
                CouponRetrieveResponseDataAmountsOffCurrency.Xpf => "xpf",
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
[JsonConverter(typeof(CouponRetrieveResponseDataSourceConverter))]
public enum CouponRetrieveResponseDataSource
{
    Stigg,
    StiggAdhoc,
    Stripe,
}

sealed class CouponRetrieveResponseDataSourceConverter
    : JsonConverter<CouponRetrieveResponseDataSource>
{
    public override CouponRetrieveResponseDataSource Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "STIGG" => CouponRetrieveResponseDataSource.Stigg,
            "STIGG_ADHOC" => CouponRetrieveResponseDataSource.StiggAdhoc,
            "STRIPE" => CouponRetrieveResponseDataSource.Stripe,
            _ => (CouponRetrieveResponseDataSource)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CouponRetrieveResponseDataSource value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CouponRetrieveResponseDataSource.Stigg => "STIGG",
                CouponRetrieveResponseDataSource.StiggAdhoc => "STIGG_ADHOC",
                CouponRetrieveResponseDataSource.Stripe => "STRIPE",
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
[JsonConverter(typeof(CouponRetrieveResponseDataStatusConverter))]
public enum CouponRetrieveResponseDataStatus
{
    Active,
    Archived,
}

sealed class CouponRetrieveResponseDataStatusConverter
    : JsonConverter<CouponRetrieveResponseDataStatus>
{
    public override CouponRetrieveResponseDataStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ACTIVE" => CouponRetrieveResponseDataStatus.Active,
            "ARCHIVED" => CouponRetrieveResponseDataStatus.Archived,
            _ => (CouponRetrieveResponseDataStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CouponRetrieveResponseDataStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CouponRetrieveResponseDataStatus.Active => "ACTIVE",
                CouponRetrieveResponseDataStatus.Archived => "ARCHIVED",
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
[JsonConverter(typeof(CouponRetrieveResponseDataTypeConverter))]
public enum CouponRetrieveResponseDataType
{
    Fixed,
    Percentage,
}

sealed class CouponRetrieveResponseDataTypeConverter : JsonConverter<CouponRetrieveResponseDataType>
{
    public override CouponRetrieveResponseDataType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FIXED" => CouponRetrieveResponseDataType.Fixed,
            "PERCENTAGE" => CouponRetrieveResponseDataType.Percentage,
            _ => (CouponRetrieveResponseDataType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CouponRetrieveResponseDataType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CouponRetrieveResponseDataType.Fixed => "FIXED",
                CouponRetrieveResponseDataType.Percentage => "PERCENTAGE",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
