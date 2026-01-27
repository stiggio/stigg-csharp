using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Core;
using Stigg.Exceptions;
using System = System;

namespace Stigg.Models.V1.Coupons;

[JsonConverter(typeof(JsonModelConverter<CouponListResponse, CouponListResponseFromRaw>))]
public sealed record class CouponListResponse : JsonModel
{
    public required IReadOnlyList<CouponListResponseData> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<CouponListResponseData>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<CouponListResponseData>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Pagination information including cursors for navigation
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

[JsonConverter(typeof(JsonModelConverter<CouponListResponseData, CouponListResponseDataFromRaw>))]
public sealed record class CouponListResponseData : JsonModel
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
    public required IReadOnlyList<CouponListResponseDataAmountsOff>? AmountsOff
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<CouponListResponseDataAmountsOff>
            >("amountsOff");
        }
        init
        {
            this._rawData.Set<ImmutableArray<CouponListResponseDataAmountsOff>?>(
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
    public required ApiEnum<string, CouponListResponseDataSource>? Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CouponListResponseDataSource>>(
                "source"
            );
        }
        init { this._rawData.Set("source", value); }
    }

    /// <summary>
    /// Current status of the coupon
    /// </summary>
    public required ApiEnum<string, CouponListResponseDataStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CouponListResponseDataStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Type of the coupon (percentage or fixed amount)
    /// </summary>
    public required ApiEnum<string, CouponListResponseDataType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CouponListResponseDataType>>(
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

    public CouponListResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CouponListResponseData(CouponListResponseData couponListResponseData)
        : base(couponListResponseData) { }
#pragma warning restore CS8618

    public CouponListResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CouponListResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CouponListResponseDataFromRaw.FromRawUnchecked"/>
    public static CouponListResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CouponListResponseDataFromRaw : IFromRawJson<CouponListResponseData>
{
    /// <inheritdoc/>
    public CouponListResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CouponListResponseData.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        CouponListResponseDataAmountsOff,
        CouponListResponseDataAmountsOffFromRaw
    >)
)]
public sealed record class CouponListResponseDataAmountsOff : JsonModel
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
    public required ApiEnum<string, CouponListResponseDataAmountsOffCurrency>? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, CouponListResponseDataAmountsOffCurrency>
            >("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        this.Currency?.Validate();
    }

    public CouponListResponseDataAmountsOff() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CouponListResponseDataAmountsOff(
        CouponListResponseDataAmountsOff couponListResponseDataAmountsOff
    )
        : base(couponListResponseDataAmountsOff) { }
#pragma warning restore CS8618

    public CouponListResponseDataAmountsOff(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CouponListResponseDataAmountsOff(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CouponListResponseDataAmountsOffFromRaw.FromRawUnchecked"/>
    public static CouponListResponseDataAmountsOff FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CouponListResponseDataAmountsOffFromRaw : IFromRawJson<CouponListResponseDataAmountsOff>
{
    /// <inheritdoc/>
    public CouponListResponseDataAmountsOff FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CouponListResponseDataAmountsOff.FromRawUnchecked(rawData);
}

/// <summary>
/// The price currency
/// </summary>
[JsonConverter(typeof(CouponListResponseDataAmountsOffCurrencyConverter))]
public enum CouponListResponseDataAmountsOffCurrency
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

sealed class CouponListResponseDataAmountsOffCurrencyConverter
    : JsonConverter<CouponListResponseDataAmountsOffCurrency>
{
    public override CouponListResponseDataAmountsOffCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => CouponListResponseDataAmountsOffCurrency.Usd,
            "aed" => CouponListResponseDataAmountsOffCurrency.Aed,
            "all" => CouponListResponseDataAmountsOffCurrency.All,
            "amd" => CouponListResponseDataAmountsOffCurrency.Amd,
            "ang" => CouponListResponseDataAmountsOffCurrency.Ang,
            "aud" => CouponListResponseDataAmountsOffCurrency.Aud,
            "awg" => CouponListResponseDataAmountsOffCurrency.Awg,
            "azn" => CouponListResponseDataAmountsOffCurrency.Azn,
            "bam" => CouponListResponseDataAmountsOffCurrency.Bam,
            "bbd" => CouponListResponseDataAmountsOffCurrency.Bbd,
            "bdt" => CouponListResponseDataAmountsOffCurrency.Bdt,
            "bgn" => CouponListResponseDataAmountsOffCurrency.Bgn,
            "bif" => CouponListResponseDataAmountsOffCurrency.Bif,
            "bmd" => CouponListResponseDataAmountsOffCurrency.Bmd,
            "bnd" => CouponListResponseDataAmountsOffCurrency.Bnd,
            "bsd" => CouponListResponseDataAmountsOffCurrency.Bsd,
            "bwp" => CouponListResponseDataAmountsOffCurrency.Bwp,
            "byn" => CouponListResponseDataAmountsOffCurrency.Byn,
            "bzd" => CouponListResponseDataAmountsOffCurrency.Bzd,
            "brl" => CouponListResponseDataAmountsOffCurrency.Brl,
            "cad" => CouponListResponseDataAmountsOffCurrency.Cad,
            "cdf" => CouponListResponseDataAmountsOffCurrency.Cdf,
            "chf" => CouponListResponseDataAmountsOffCurrency.Chf,
            "cny" => CouponListResponseDataAmountsOffCurrency.Cny,
            "czk" => CouponListResponseDataAmountsOffCurrency.Czk,
            "dkk" => CouponListResponseDataAmountsOffCurrency.Dkk,
            "dop" => CouponListResponseDataAmountsOffCurrency.Dop,
            "dzd" => CouponListResponseDataAmountsOffCurrency.Dzd,
            "egp" => CouponListResponseDataAmountsOffCurrency.Egp,
            "etb" => CouponListResponseDataAmountsOffCurrency.Etb,
            "eur" => CouponListResponseDataAmountsOffCurrency.Eur,
            "fjd" => CouponListResponseDataAmountsOffCurrency.Fjd,
            "gbp" => CouponListResponseDataAmountsOffCurrency.Gbp,
            "gel" => CouponListResponseDataAmountsOffCurrency.Gel,
            "gip" => CouponListResponseDataAmountsOffCurrency.Gip,
            "gmd" => CouponListResponseDataAmountsOffCurrency.Gmd,
            "gyd" => CouponListResponseDataAmountsOffCurrency.Gyd,
            "hkd" => CouponListResponseDataAmountsOffCurrency.Hkd,
            "hrk" => CouponListResponseDataAmountsOffCurrency.Hrk,
            "htg" => CouponListResponseDataAmountsOffCurrency.Htg,
            "idr" => CouponListResponseDataAmountsOffCurrency.Idr,
            "ils" => CouponListResponseDataAmountsOffCurrency.Ils,
            "inr" => CouponListResponseDataAmountsOffCurrency.Inr,
            "isk" => CouponListResponseDataAmountsOffCurrency.Isk,
            "jmd" => CouponListResponseDataAmountsOffCurrency.Jmd,
            "jpy" => CouponListResponseDataAmountsOffCurrency.Jpy,
            "kes" => CouponListResponseDataAmountsOffCurrency.Kes,
            "kgs" => CouponListResponseDataAmountsOffCurrency.Kgs,
            "khr" => CouponListResponseDataAmountsOffCurrency.Khr,
            "kmf" => CouponListResponseDataAmountsOffCurrency.Kmf,
            "krw" => CouponListResponseDataAmountsOffCurrency.Krw,
            "kyd" => CouponListResponseDataAmountsOffCurrency.Kyd,
            "kzt" => CouponListResponseDataAmountsOffCurrency.Kzt,
            "lbp" => CouponListResponseDataAmountsOffCurrency.Lbp,
            "lkr" => CouponListResponseDataAmountsOffCurrency.Lkr,
            "lrd" => CouponListResponseDataAmountsOffCurrency.Lrd,
            "lsl" => CouponListResponseDataAmountsOffCurrency.Lsl,
            "mad" => CouponListResponseDataAmountsOffCurrency.Mad,
            "mdl" => CouponListResponseDataAmountsOffCurrency.Mdl,
            "mga" => CouponListResponseDataAmountsOffCurrency.Mga,
            "mkd" => CouponListResponseDataAmountsOffCurrency.Mkd,
            "mmk" => CouponListResponseDataAmountsOffCurrency.Mmk,
            "mnt" => CouponListResponseDataAmountsOffCurrency.Mnt,
            "mop" => CouponListResponseDataAmountsOffCurrency.Mop,
            "mro" => CouponListResponseDataAmountsOffCurrency.Mro,
            "mvr" => CouponListResponseDataAmountsOffCurrency.Mvr,
            "mwk" => CouponListResponseDataAmountsOffCurrency.Mwk,
            "mxn" => CouponListResponseDataAmountsOffCurrency.Mxn,
            "myr" => CouponListResponseDataAmountsOffCurrency.Myr,
            "mzn" => CouponListResponseDataAmountsOffCurrency.Mzn,
            "nad" => CouponListResponseDataAmountsOffCurrency.Nad,
            "ngn" => CouponListResponseDataAmountsOffCurrency.Ngn,
            "nok" => CouponListResponseDataAmountsOffCurrency.Nok,
            "npr" => CouponListResponseDataAmountsOffCurrency.Npr,
            "nzd" => CouponListResponseDataAmountsOffCurrency.Nzd,
            "pgk" => CouponListResponseDataAmountsOffCurrency.Pgk,
            "php" => CouponListResponseDataAmountsOffCurrency.Php,
            "pkr" => CouponListResponseDataAmountsOffCurrency.Pkr,
            "pln" => CouponListResponseDataAmountsOffCurrency.Pln,
            "qar" => CouponListResponseDataAmountsOffCurrency.Qar,
            "ron" => CouponListResponseDataAmountsOffCurrency.Ron,
            "rsd" => CouponListResponseDataAmountsOffCurrency.Rsd,
            "rub" => CouponListResponseDataAmountsOffCurrency.Rub,
            "rwf" => CouponListResponseDataAmountsOffCurrency.Rwf,
            "sar" => CouponListResponseDataAmountsOffCurrency.Sar,
            "sbd" => CouponListResponseDataAmountsOffCurrency.Sbd,
            "scr" => CouponListResponseDataAmountsOffCurrency.Scr,
            "sek" => CouponListResponseDataAmountsOffCurrency.Sek,
            "sgd" => CouponListResponseDataAmountsOffCurrency.Sgd,
            "sle" => CouponListResponseDataAmountsOffCurrency.Sle,
            "sll" => CouponListResponseDataAmountsOffCurrency.Sll,
            "sos" => CouponListResponseDataAmountsOffCurrency.Sos,
            "szl" => CouponListResponseDataAmountsOffCurrency.Szl,
            "thb" => CouponListResponseDataAmountsOffCurrency.Thb,
            "tjs" => CouponListResponseDataAmountsOffCurrency.Tjs,
            "top" => CouponListResponseDataAmountsOffCurrency.Top,
            "try" => CouponListResponseDataAmountsOffCurrency.Try,
            "ttd" => CouponListResponseDataAmountsOffCurrency.Ttd,
            "tzs" => CouponListResponseDataAmountsOffCurrency.Tzs,
            "uah" => CouponListResponseDataAmountsOffCurrency.Uah,
            "uzs" => CouponListResponseDataAmountsOffCurrency.Uzs,
            "vnd" => CouponListResponseDataAmountsOffCurrency.Vnd,
            "vuv" => CouponListResponseDataAmountsOffCurrency.Vuv,
            "wst" => CouponListResponseDataAmountsOffCurrency.Wst,
            "xaf" => CouponListResponseDataAmountsOffCurrency.Xaf,
            "xcd" => CouponListResponseDataAmountsOffCurrency.Xcd,
            "yer" => CouponListResponseDataAmountsOffCurrency.Yer,
            "zar" => CouponListResponseDataAmountsOffCurrency.Zar,
            "zmw" => CouponListResponseDataAmountsOffCurrency.Zmw,
            "clp" => CouponListResponseDataAmountsOffCurrency.Clp,
            "djf" => CouponListResponseDataAmountsOffCurrency.Djf,
            "gnf" => CouponListResponseDataAmountsOffCurrency.Gnf,
            "ugx" => CouponListResponseDataAmountsOffCurrency.Ugx,
            "pyg" => CouponListResponseDataAmountsOffCurrency.Pyg,
            "xof" => CouponListResponseDataAmountsOffCurrency.Xof,
            "xpf" => CouponListResponseDataAmountsOffCurrency.Xpf,
            _ => (CouponListResponseDataAmountsOffCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CouponListResponseDataAmountsOffCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CouponListResponseDataAmountsOffCurrency.Usd => "usd",
                CouponListResponseDataAmountsOffCurrency.Aed => "aed",
                CouponListResponseDataAmountsOffCurrency.All => "all",
                CouponListResponseDataAmountsOffCurrency.Amd => "amd",
                CouponListResponseDataAmountsOffCurrency.Ang => "ang",
                CouponListResponseDataAmountsOffCurrency.Aud => "aud",
                CouponListResponseDataAmountsOffCurrency.Awg => "awg",
                CouponListResponseDataAmountsOffCurrency.Azn => "azn",
                CouponListResponseDataAmountsOffCurrency.Bam => "bam",
                CouponListResponseDataAmountsOffCurrency.Bbd => "bbd",
                CouponListResponseDataAmountsOffCurrency.Bdt => "bdt",
                CouponListResponseDataAmountsOffCurrency.Bgn => "bgn",
                CouponListResponseDataAmountsOffCurrency.Bif => "bif",
                CouponListResponseDataAmountsOffCurrency.Bmd => "bmd",
                CouponListResponseDataAmountsOffCurrency.Bnd => "bnd",
                CouponListResponseDataAmountsOffCurrency.Bsd => "bsd",
                CouponListResponseDataAmountsOffCurrency.Bwp => "bwp",
                CouponListResponseDataAmountsOffCurrency.Byn => "byn",
                CouponListResponseDataAmountsOffCurrency.Bzd => "bzd",
                CouponListResponseDataAmountsOffCurrency.Brl => "brl",
                CouponListResponseDataAmountsOffCurrency.Cad => "cad",
                CouponListResponseDataAmountsOffCurrency.Cdf => "cdf",
                CouponListResponseDataAmountsOffCurrency.Chf => "chf",
                CouponListResponseDataAmountsOffCurrency.Cny => "cny",
                CouponListResponseDataAmountsOffCurrency.Czk => "czk",
                CouponListResponseDataAmountsOffCurrency.Dkk => "dkk",
                CouponListResponseDataAmountsOffCurrency.Dop => "dop",
                CouponListResponseDataAmountsOffCurrency.Dzd => "dzd",
                CouponListResponseDataAmountsOffCurrency.Egp => "egp",
                CouponListResponseDataAmountsOffCurrency.Etb => "etb",
                CouponListResponseDataAmountsOffCurrency.Eur => "eur",
                CouponListResponseDataAmountsOffCurrency.Fjd => "fjd",
                CouponListResponseDataAmountsOffCurrency.Gbp => "gbp",
                CouponListResponseDataAmountsOffCurrency.Gel => "gel",
                CouponListResponseDataAmountsOffCurrency.Gip => "gip",
                CouponListResponseDataAmountsOffCurrency.Gmd => "gmd",
                CouponListResponseDataAmountsOffCurrency.Gyd => "gyd",
                CouponListResponseDataAmountsOffCurrency.Hkd => "hkd",
                CouponListResponseDataAmountsOffCurrency.Hrk => "hrk",
                CouponListResponseDataAmountsOffCurrency.Htg => "htg",
                CouponListResponseDataAmountsOffCurrency.Idr => "idr",
                CouponListResponseDataAmountsOffCurrency.Ils => "ils",
                CouponListResponseDataAmountsOffCurrency.Inr => "inr",
                CouponListResponseDataAmountsOffCurrency.Isk => "isk",
                CouponListResponseDataAmountsOffCurrency.Jmd => "jmd",
                CouponListResponseDataAmountsOffCurrency.Jpy => "jpy",
                CouponListResponseDataAmountsOffCurrency.Kes => "kes",
                CouponListResponseDataAmountsOffCurrency.Kgs => "kgs",
                CouponListResponseDataAmountsOffCurrency.Khr => "khr",
                CouponListResponseDataAmountsOffCurrency.Kmf => "kmf",
                CouponListResponseDataAmountsOffCurrency.Krw => "krw",
                CouponListResponseDataAmountsOffCurrency.Kyd => "kyd",
                CouponListResponseDataAmountsOffCurrency.Kzt => "kzt",
                CouponListResponseDataAmountsOffCurrency.Lbp => "lbp",
                CouponListResponseDataAmountsOffCurrency.Lkr => "lkr",
                CouponListResponseDataAmountsOffCurrency.Lrd => "lrd",
                CouponListResponseDataAmountsOffCurrency.Lsl => "lsl",
                CouponListResponseDataAmountsOffCurrency.Mad => "mad",
                CouponListResponseDataAmountsOffCurrency.Mdl => "mdl",
                CouponListResponseDataAmountsOffCurrency.Mga => "mga",
                CouponListResponseDataAmountsOffCurrency.Mkd => "mkd",
                CouponListResponseDataAmountsOffCurrency.Mmk => "mmk",
                CouponListResponseDataAmountsOffCurrency.Mnt => "mnt",
                CouponListResponseDataAmountsOffCurrency.Mop => "mop",
                CouponListResponseDataAmountsOffCurrency.Mro => "mro",
                CouponListResponseDataAmountsOffCurrency.Mvr => "mvr",
                CouponListResponseDataAmountsOffCurrency.Mwk => "mwk",
                CouponListResponseDataAmountsOffCurrency.Mxn => "mxn",
                CouponListResponseDataAmountsOffCurrency.Myr => "myr",
                CouponListResponseDataAmountsOffCurrency.Mzn => "mzn",
                CouponListResponseDataAmountsOffCurrency.Nad => "nad",
                CouponListResponseDataAmountsOffCurrency.Ngn => "ngn",
                CouponListResponseDataAmountsOffCurrency.Nok => "nok",
                CouponListResponseDataAmountsOffCurrency.Npr => "npr",
                CouponListResponseDataAmountsOffCurrency.Nzd => "nzd",
                CouponListResponseDataAmountsOffCurrency.Pgk => "pgk",
                CouponListResponseDataAmountsOffCurrency.Php => "php",
                CouponListResponseDataAmountsOffCurrency.Pkr => "pkr",
                CouponListResponseDataAmountsOffCurrency.Pln => "pln",
                CouponListResponseDataAmountsOffCurrency.Qar => "qar",
                CouponListResponseDataAmountsOffCurrency.Ron => "ron",
                CouponListResponseDataAmountsOffCurrency.Rsd => "rsd",
                CouponListResponseDataAmountsOffCurrency.Rub => "rub",
                CouponListResponseDataAmountsOffCurrency.Rwf => "rwf",
                CouponListResponseDataAmountsOffCurrency.Sar => "sar",
                CouponListResponseDataAmountsOffCurrency.Sbd => "sbd",
                CouponListResponseDataAmountsOffCurrency.Scr => "scr",
                CouponListResponseDataAmountsOffCurrency.Sek => "sek",
                CouponListResponseDataAmountsOffCurrency.Sgd => "sgd",
                CouponListResponseDataAmountsOffCurrency.Sle => "sle",
                CouponListResponseDataAmountsOffCurrency.Sll => "sll",
                CouponListResponseDataAmountsOffCurrency.Sos => "sos",
                CouponListResponseDataAmountsOffCurrency.Szl => "szl",
                CouponListResponseDataAmountsOffCurrency.Thb => "thb",
                CouponListResponseDataAmountsOffCurrency.Tjs => "tjs",
                CouponListResponseDataAmountsOffCurrency.Top => "top",
                CouponListResponseDataAmountsOffCurrency.Try => "try",
                CouponListResponseDataAmountsOffCurrency.Ttd => "ttd",
                CouponListResponseDataAmountsOffCurrency.Tzs => "tzs",
                CouponListResponseDataAmountsOffCurrency.Uah => "uah",
                CouponListResponseDataAmountsOffCurrency.Uzs => "uzs",
                CouponListResponseDataAmountsOffCurrency.Vnd => "vnd",
                CouponListResponseDataAmountsOffCurrency.Vuv => "vuv",
                CouponListResponseDataAmountsOffCurrency.Wst => "wst",
                CouponListResponseDataAmountsOffCurrency.Xaf => "xaf",
                CouponListResponseDataAmountsOffCurrency.Xcd => "xcd",
                CouponListResponseDataAmountsOffCurrency.Yer => "yer",
                CouponListResponseDataAmountsOffCurrency.Zar => "zar",
                CouponListResponseDataAmountsOffCurrency.Zmw => "zmw",
                CouponListResponseDataAmountsOffCurrency.Clp => "clp",
                CouponListResponseDataAmountsOffCurrency.Djf => "djf",
                CouponListResponseDataAmountsOffCurrency.Gnf => "gnf",
                CouponListResponseDataAmountsOffCurrency.Ugx => "ugx",
                CouponListResponseDataAmountsOffCurrency.Pyg => "pyg",
                CouponListResponseDataAmountsOffCurrency.Xof => "xof",
                CouponListResponseDataAmountsOffCurrency.Xpf => "xpf",
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
[JsonConverter(typeof(CouponListResponseDataSourceConverter))]
public enum CouponListResponseDataSource
{
    Stigg,
    StiggAdhoc,
    Stripe,
}

sealed class CouponListResponseDataSourceConverter : JsonConverter<CouponListResponseDataSource>
{
    public override CouponListResponseDataSource Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "STIGG" => CouponListResponseDataSource.Stigg,
            "STIGG_ADHOC" => CouponListResponseDataSource.StiggAdhoc,
            "STRIPE" => CouponListResponseDataSource.Stripe,
            _ => (CouponListResponseDataSource)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CouponListResponseDataSource value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CouponListResponseDataSource.Stigg => "STIGG",
                CouponListResponseDataSource.StiggAdhoc => "STIGG_ADHOC",
                CouponListResponseDataSource.Stripe => "STRIPE",
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
[JsonConverter(typeof(CouponListResponseDataStatusConverter))]
public enum CouponListResponseDataStatus
{
    Active,
    Archived,
}

sealed class CouponListResponseDataStatusConverter : JsonConverter<CouponListResponseDataStatus>
{
    public override CouponListResponseDataStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ACTIVE" => CouponListResponseDataStatus.Active,
            "ARCHIVED" => CouponListResponseDataStatus.Archived,
            _ => (CouponListResponseDataStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CouponListResponseDataStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CouponListResponseDataStatus.Active => "ACTIVE",
                CouponListResponseDataStatus.Archived => "ARCHIVED",
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
[JsonConverter(typeof(CouponListResponseDataTypeConverter))]
public enum CouponListResponseDataType
{
    Fixed,
    Percentage,
}

sealed class CouponListResponseDataTypeConverter : JsonConverter<CouponListResponseDataType>
{
    public override CouponListResponseDataType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FIXED" => CouponListResponseDataType.Fixed,
            "PERCENTAGE" => CouponListResponseDataType.Percentage,
            _ => (CouponListResponseDataType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CouponListResponseDataType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CouponListResponseDataType.Fixed => "FIXED",
                CouponListResponseDataType.Percentage => "PERCENTAGE",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Pagination information including cursors for navigation
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Pagination, PaginationFromRaw>))]
public sealed record class Pagination : JsonModel
{
    /// <summary>
    /// Cursor to fetch the next page (use with after parameter), null if no more pages
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
    /// Cursor to fetch the previous page (use with before parameter), null if no
    /// previous pages
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
