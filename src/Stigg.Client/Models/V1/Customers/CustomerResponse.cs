using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using System = System;

namespace Stigg.Client.Models.V1.Customers;

/// <summary>
/// Response object
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CustomerResponse, CustomerResponseFromRaw>))]
public sealed record class CustomerResponse : JsonModel
{
    /// <summary>
    /// A customer can be either an organization or an individual
    /// </summary>
    public required CustomerResponseData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CustomerResponseData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public CustomerResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerResponse(CustomerResponse customerResponse)
        : base(customerResponse) { }
#pragma warning restore CS8618

    public CustomerResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerResponseFromRaw.FromRawUnchecked"/>
    public static CustomerResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CustomerResponse(CustomerResponseData data)
        : this()
    {
        this.Data = data;
    }
}

class CustomerResponseFromRaw : IFromRawJson<CustomerResponse>
{
    /// <inheritdoc/>
    public CustomerResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CustomerResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// A customer can be either an organization or an individual
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CustomerResponseData, CustomerResponseDataFromRaw>))]
public sealed record class CustomerResponseData : JsonModel
{
    /// <summary>
    /// Customer slug
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
    /// Timestamp of when the record was deleted
    /// </summary>
    public required System::DateTimeOffset? ArchivedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("archivedAt");
        }
        init { this._rawData.Set("archivedAt", value); }
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

    /// <summary>
    /// The billing currency of the customer
    /// </summary>
    public ApiEnum<string, CustomerResponseDataBillingCurrency>? BillingCurrency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, CustomerResponseDataBillingCurrency>
            >("billingCurrency");
        }
        init { this._rawData.Set("billingCurrency", value); }
    }

    /// <summary>
    /// The unique identifier for the entity in the billing provider
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
    /// Customer level coupon
    /// </summary>
    public ApiEnum<string, CustomerResponseDataCouponID>? CouponID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CustomerResponseDataCouponID>>(
                "couponId"
            );
        }
        init { this._rawData.Set("couponId", value); }
    }

    /// <summary>
    /// The default payment method details
    /// </summary>
    public CustomerResponseDataDefaultPaymentMethod? DefaultPaymentMethod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CustomerResponseDataDefaultPaymentMethod>(
                "defaultPaymentMethod"
            );
        }
        init { this._rawData.Set("defaultPaymentMethod", value); }
    }

    /// <summary>
    /// The email of the customer
    /// </summary>
    public string? Email
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("email");
        }
        init { this._rawData.Set("email", value); }
    }

    /// <summary>
    /// List of integrations
    /// </summary>
    public IReadOnlyList<CustomerResponseDataIntegration>? Integrations
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<CustomerResponseDataIntegration>>(
                "integrations"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<CustomerResponseDataIntegration>?>(
                "integrations",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Language to use for this customer
    /// </summary>
    public string? Language
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("language");
        }
        init { this._rawData.Set("language", value); }
    }

    /// <summary>
    /// Additional metadata
    /// </summary>
    public IReadOnlyDictionary<string, string>? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, string>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// The name of the customer
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Vendor-specific billing passthrough fields.
    /// </summary>
    public CustomerResponseDataPassthrough? Passthrough
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CustomerResponseDataPassthrough>("passthrough");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("passthrough", value);
        }
    }

    /// <summary>
    /// Timezone to use for this customer
    /// </summary>
    public string? Timezone
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("timezone");
        }
        init { this._rawData.Set("timezone", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ArchivedAt;
        _ = this.CreatedAt;
        _ = this.UpdatedAt;
        this.BillingCurrency?.Validate();
        _ = this.BillingID;
        this.CouponID?.Raw();
        this.DefaultPaymentMethod?.Validate();
        _ = this.Email;
        foreach (var item in this.Integrations ?? [])
        {
            item.Validate();
        }
        _ = this.Language;
        _ = this.Metadata;
        _ = this.Name;
        this.Passthrough?.Validate();
        _ = this.Timezone;
    }

    public CustomerResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerResponseData(CustomerResponseData customerResponseData)
        : base(customerResponseData) { }
#pragma warning restore CS8618

    public CustomerResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerResponseDataFromRaw.FromRawUnchecked"/>
    public static CustomerResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerResponseDataFromRaw : IFromRawJson<CustomerResponseData>
{
    /// <inheritdoc/>
    public CustomerResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerResponseData.FromRawUnchecked(rawData);
}

/// <summary>
/// The billing currency of the customer
/// </summary>
[JsonConverter(typeof(CustomerResponseDataBillingCurrencyConverter))]
public enum CustomerResponseDataBillingCurrency
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

sealed class CustomerResponseDataBillingCurrencyConverter
    : JsonConverter<CustomerResponseDataBillingCurrency>
{
    public override CustomerResponseDataBillingCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => CustomerResponseDataBillingCurrency.Usd,
            "aed" => CustomerResponseDataBillingCurrency.Aed,
            "all" => CustomerResponseDataBillingCurrency.All,
            "amd" => CustomerResponseDataBillingCurrency.Amd,
            "ang" => CustomerResponseDataBillingCurrency.Ang,
            "aud" => CustomerResponseDataBillingCurrency.Aud,
            "awg" => CustomerResponseDataBillingCurrency.Awg,
            "azn" => CustomerResponseDataBillingCurrency.Azn,
            "bam" => CustomerResponseDataBillingCurrency.Bam,
            "bbd" => CustomerResponseDataBillingCurrency.Bbd,
            "bdt" => CustomerResponseDataBillingCurrency.Bdt,
            "bgn" => CustomerResponseDataBillingCurrency.Bgn,
            "bif" => CustomerResponseDataBillingCurrency.Bif,
            "bmd" => CustomerResponseDataBillingCurrency.Bmd,
            "bnd" => CustomerResponseDataBillingCurrency.Bnd,
            "bsd" => CustomerResponseDataBillingCurrency.Bsd,
            "bwp" => CustomerResponseDataBillingCurrency.Bwp,
            "byn" => CustomerResponseDataBillingCurrency.Byn,
            "bzd" => CustomerResponseDataBillingCurrency.Bzd,
            "brl" => CustomerResponseDataBillingCurrency.Brl,
            "cad" => CustomerResponseDataBillingCurrency.Cad,
            "cdf" => CustomerResponseDataBillingCurrency.Cdf,
            "chf" => CustomerResponseDataBillingCurrency.Chf,
            "cny" => CustomerResponseDataBillingCurrency.Cny,
            "czk" => CustomerResponseDataBillingCurrency.Czk,
            "dkk" => CustomerResponseDataBillingCurrency.Dkk,
            "dop" => CustomerResponseDataBillingCurrency.Dop,
            "dzd" => CustomerResponseDataBillingCurrency.Dzd,
            "egp" => CustomerResponseDataBillingCurrency.Egp,
            "etb" => CustomerResponseDataBillingCurrency.Etb,
            "eur" => CustomerResponseDataBillingCurrency.Eur,
            "fjd" => CustomerResponseDataBillingCurrency.Fjd,
            "gbp" => CustomerResponseDataBillingCurrency.Gbp,
            "gel" => CustomerResponseDataBillingCurrency.Gel,
            "gip" => CustomerResponseDataBillingCurrency.Gip,
            "gmd" => CustomerResponseDataBillingCurrency.Gmd,
            "gyd" => CustomerResponseDataBillingCurrency.Gyd,
            "hkd" => CustomerResponseDataBillingCurrency.Hkd,
            "hrk" => CustomerResponseDataBillingCurrency.Hrk,
            "htg" => CustomerResponseDataBillingCurrency.Htg,
            "idr" => CustomerResponseDataBillingCurrency.Idr,
            "ils" => CustomerResponseDataBillingCurrency.Ils,
            "inr" => CustomerResponseDataBillingCurrency.Inr,
            "isk" => CustomerResponseDataBillingCurrency.Isk,
            "jmd" => CustomerResponseDataBillingCurrency.Jmd,
            "jpy" => CustomerResponseDataBillingCurrency.Jpy,
            "kes" => CustomerResponseDataBillingCurrency.Kes,
            "kgs" => CustomerResponseDataBillingCurrency.Kgs,
            "khr" => CustomerResponseDataBillingCurrency.Khr,
            "kmf" => CustomerResponseDataBillingCurrency.Kmf,
            "krw" => CustomerResponseDataBillingCurrency.Krw,
            "kyd" => CustomerResponseDataBillingCurrency.Kyd,
            "kzt" => CustomerResponseDataBillingCurrency.Kzt,
            "lbp" => CustomerResponseDataBillingCurrency.Lbp,
            "lkr" => CustomerResponseDataBillingCurrency.Lkr,
            "lrd" => CustomerResponseDataBillingCurrency.Lrd,
            "lsl" => CustomerResponseDataBillingCurrency.Lsl,
            "mad" => CustomerResponseDataBillingCurrency.Mad,
            "mdl" => CustomerResponseDataBillingCurrency.Mdl,
            "mga" => CustomerResponseDataBillingCurrency.Mga,
            "mkd" => CustomerResponseDataBillingCurrency.Mkd,
            "mmk" => CustomerResponseDataBillingCurrency.Mmk,
            "mnt" => CustomerResponseDataBillingCurrency.Mnt,
            "mop" => CustomerResponseDataBillingCurrency.Mop,
            "mro" => CustomerResponseDataBillingCurrency.Mro,
            "mvr" => CustomerResponseDataBillingCurrency.Mvr,
            "mwk" => CustomerResponseDataBillingCurrency.Mwk,
            "mxn" => CustomerResponseDataBillingCurrency.Mxn,
            "myr" => CustomerResponseDataBillingCurrency.Myr,
            "mzn" => CustomerResponseDataBillingCurrency.Mzn,
            "nad" => CustomerResponseDataBillingCurrency.Nad,
            "ngn" => CustomerResponseDataBillingCurrency.Ngn,
            "nok" => CustomerResponseDataBillingCurrency.Nok,
            "npr" => CustomerResponseDataBillingCurrency.Npr,
            "nzd" => CustomerResponseDataBillingCurrency.Nzd,
            "pgk" => CustomerResponseDataBillingCurrency.Pgk,
            "php" => CustomerResponseDataBillingCurrency.Php,
            "pkr" => CustomerResponseDataBillingCurrency.Pkr,
            "pln" => CustomerResponseDataBillingCurrency.Pln,
            "qar" => CustomerResponseDataBillingCurrency.Qar,
            "ron" => CustomerResponseDataBillingCurrency.Ron,
            "rsd" => CustomerResponseDataBillingCurrency.Rsd,
            "rub" => CustomerResponseDataBillingCurrency.Rub,
            "rwf" => CustomerResponseDataBillingCurrency.Rwf,
            "sar" => CustomerResponseDataBillingCurrency.Sar,
            "sbd" => CustomerResponseDataBillingCurrency.Sbd,
            "scr" => CustomerResponseDataBillingCurrency.Scr,
            "sek" => CustomerResponseDataBillingCurrency.Sek,
            "sgd" => CustomerResponseDataBillingCurrency.Sgd,
            "sle" => CustomerResponseDataBillingCurrency.Sle,
            "sll" => CustomerResponseDataBillingCurrency.Sll,
            "sos" => CustomerResponseDataBillingCurrency.Sos,
            "szl" => CustomerResponseDataBillingCurrency.Szl,
            "thb" => CustomerResponseDataBillingCurrency.Thb,
            "tjs" => CustomerResponseDataBillingCurrency.Tjs,
            "top" => CustomerResponseDataBillingCurrency.Top,
            "try" => CustomerResponseDataBillingCurrency.Try,
            "ttd" => CustomerResponseDataBillingCurrency.Ttd,
            "tzs" => CustomerResponseDataBillingCurrency.Tzs,
            "uah" => CustomerResponseDataBillingCurrency.Uah,
            "uzs" => CustomerResponseDataBillingCurrency.Uzs,
            "vnd" => CustomerResponseDataBillingCurrency.Vnd,
            "vuv" => CustomerResponseDataBillingCurrency.Vuv,
            "wst" => CustomerResponseDataBillingCurrency.Wst,
            "xaf" => CustomerResponseDataBillingCurrency.Xaf,
            "xcd" => CustomerResponseDataBillingCurrency.Xcd,
            "yer" => CustomerResponseDataBillingCurrency.Yer,
            "zar" => CustomerResponseDataBillingCurrency.Zar,
            "zmw" => CustomerResponseDataBillingCurrency.Zmw,
            "clp" => CustomerResponseDataBillingCurrency.Clp,
            "djf" => CustomerResponseDataBillingCurrency.Djf,
            "gnf" => CustomerResponseDataBillingCurrency.Gnf,
            "ugx" => CustomerResponseDataBillingCurrency.Ugx,
            "pyg" => CustomerResponseDataBillingCurrency.Pyg,
            "xof" => CustomerResponseDataBillingCurrency.Xof,
            "xpf" => CustomerResponseDataBillingCurrency.Xpf,
            _ => (CustomerResponseDataBillingCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CustomerResponseDataBillingCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CustomerResponseDataBillingCurrency.Usd => "usd",
                CustomerResponseDataBillingCurrency.Aed => "aed",
                CustomerResponseDataBillingCurrency.All => "all",
                CustomerResponseDataBillingCurrency.Amd => "amd",
                CustomerResponseDataBillingCurrency.Ang => "ang",
                CustomerResponseDataBillingCurrency.Aud => "aud",
                CustomerResponseDataBillingCurrency.Awg => "awg",
                CustomerResponseDataBillingCurrency.Azn => "azn",
                CustomerResponseDataBillingCurrency.Bam => "bam",
                CustomerResponseDataBillingCurrency.Bbd => "bbd",
                CustomerResponseDataBillingCurrency.Bdt => "bdt",
                CustomerResponseDataBillingCurrency.Bgn => "bgn",
                CustomerResponseDataBillingCurrency.Bif => "bif",
                CustomerResponseDataBillingCurrency.Bmd => "bmd",
                CustomerResponseDataBillingCurrency.Bnd => "bnd",
                CustomerResponseDataBillingCurrency.Bsd => "bsd",
                CustomerResponseDataBillingCurrency.Bwp => "bwp",
                CustomerResponseDataBillingCurrency.Byn => "byn",
                CustomerResponseDataBillingCurrency.Bzd => "bzd",
                CustomerResponseDataBillingCurrency.Brl => "brl",
                CustomerResponseDataBillingCurrency.Cad => "cad",
                CustomerResponseDataBillingCurrency.Cdf => "cdf",
                CustomerResponseDataBillingCurrency.Chf => "chf",
                CustomerResponseDataBillingCurrency.Cny => "cny",
                CustomerResponseDataBillingCurrency.Czk => "czk",
                CustomerResponseDataBillingCurrency.Dkk => "dkk",
                CustomerResponseDataBillingCurrency.Dop => "dop",
                CustomerResponseDataBillingCurrency.Dzd => "dzd",
                CustomerResponseDataBillingCurrency.Egp => "egp",
                CustomerResponseDataBillingCurrency.Etb => "etb",
                CustomerResponseDataBillingCurrency.Eur => "eur",
                CustomerResponseDataBillingCurrency.Fjd => "fjd",
                CustomerResponseDataBillingCurrency.Gbp => "gbp",
                CustomerResponseDataBillingCurrency.Gel => "gel",
                CustomerResponseDataBillingCurrency.Gip => "gip",
                CustomerResponseDataBillingCurrency.Gmd => "gmd",
                CustomerResponseDataBillingCurrency.Gyd => "gyd",
                CustomerResponseDataBillingCurrency.Hkd => "hkd",
                CustomerResponseDataBillingCurrency.Hrk => "hrk",
                CustomerResponseDataBillingCurrency.Htg => "htg",
                CustomerResponseDataBillingCurrency.Idr => "idr",
                CustomerResponseDataBillingCurrency.Ils => "ils",
                CustomerResponseDataBillingCurrency.Inr => "inr",
                CustomerResponseDataBillingCurrency.Isk => "isk",
                CustomerResponseDataBillingCurrency.Jmd => "jmd",
                CustomerResponseDataBillingCurrency.Jpy => "jpy",
                CustomerResponseDataBillingCurrency.Kes => "kes",
                CustomerResponseDataBillingCurrency.Kgs => "kgs",
                CustomerResponseDataBillingCurrency.Khr => "khr",
                CustomerResponseDataBillingCurrency.Kmf => "kmf",
                CustomerResponseDataBillingCurrency.Krw => "krw",
                CustomerResponseDataBillingCurrency.Kyd => "kyd",
                CustomerResponseDataBillingCurrency.Kzt => "kzt",
                CustomerResponseDataBillingCurrency.Lbp => "lbp",
                CustomerResponseDataBillingCurrency.Lkr => "lkr",
                CustomerResponseDataBillingCurrency.Lrd => "lrd",
                CustomerResponseDataBillingCurrency.Lsl => "lsl",
                CustomerResponseDataBillingCurrency.Mad => "mad",
                CustomerResponseDataBillingCurrency.Mdl => "mdl",
                CustomerResponseDataBillingCurrency.Mga => "mga",
                CustomerResponseDataBillingCurrency.Mkd => "mkd",
                CustomerResponseDataBillingCurrency.Mmk => "mmk",
                CustomerResponseDataBillingCurrency.Mnt => "mnt",
                CustomerResponseDataBillingCurrency.Mop => "mop",
                CustomerResponseDataBillingCurrency.Mro => "mro",
                CustomerResponseDataBillingCurrency.Mvr => "mvr",
                CustomerResponseDataBillingCurrency.Mwk => "mwk",
                CustomerResponseDataBillingCurrency.Mxn => "mxn",
                CustomerResponseDataBillingCurrency.Myr => "myr",
                CustomerResponseDataBillingCurrency.Mzn => "mzn",
                CustomerResponseDataBillingCurrency.Nad => "nad",
                CustomerResponseDataBillingCurrency.Ngn => "ngn",
                CustomerResponseDataBillingCurrency.Nok => "nok",
                CustomerResponseDataBillingCurrency.Npr => "npr",
                CustomerResponseDataBillingCurrency.Nzd => "nzd",
                CustomerResponseDataBillingCurrency.Pgk => "pgk",
                CustomerResponseDataBillingCurrency.Php => "php",
                CustomerResponseDataBillingCurrency.Pkr => "pkr",
                CustomerResponseDataBillingCurrency.Pln => "pln",
                CustomerResponseDataBillingCurrency.Qar => "qar",
                CustomerResponseDataBillingCurrency.Ron => "ron",
                CustomerResponseDataBillingCurrency.Rsd => "rsd",
                CustomerResponseDataBillingCurrency.Rub => "rub",
                CustomerResponseDataBillingCurrency.Rwf => "rwf",
                CustomerResponseDataBillingCurrency.Sar => "sar",
                CustomerResponseDataBillingCurrency.Sbd => "sbd",
                CustomerResponseDataBillingCurrency.Scr => "scr",
                CustomerResponseDataBillingCurrency.Sek => "sek",
                CustomerResponseDataBillingCurrency.Sgd => "sgd",
                CustomerResponseDataBillingCurrency.Sle => "sle",
                CustomerResponseDataBillingCurrency.Sll => "sll",
                CustomerResponseDataBillingCurrency.Sos => "sos",
                CustomerResponseDataBillingCurrency.Szl => "szl",
                CustomerResponseDataBillingCurrency.Thb => "thb",
                CustomerResponseDataBillingCurrency.Tjs => "tjs",
                CustomerResponseDataBillingCurrency.Top => "top",
                CustomerResponseDataBillingCurrency.Try => "try",
                CustomerResponseDataBillingCurrency.Ttd => "ttd",
                CustomerResponseDataBillingCurrency.Tzs => "tzs",
                CustomerResponseDataBillingCurrency.Uah => "uah",
                CustomerResponseDataBillingCurrency.Uzs => "uzs",
                CustomerResponseDataBillingCurrency.Vnd => "vnd",
                CustomerResponseDataBillingCurrency.Vuv => "vuv",
                CustomerResponseDataBillingCurrency.Wst => "wst",
                CustomerResponseDataBillingCurrency.Xaf => "xaf",
                CustomerResponseDataBillingCurrency.Xcd => "xcd",
                CustomerResponseDataBillingCurrency.Yer => "yer",
                CustomerResponseDataBillingCurrency.Zar => "zar",
                CustomerResponseDataBillingCurrency.Zmw => "zmw",
                CustomerResponseDataBillingCurrency.Clp => "clp",
                CustomerResponseDataBillingCurrency.Djf => "djf",
                CustomerResponseDataBillingCurrency.Gnf => "gnf",
                CustomerResponseDataBillingCurrency.Ugx => "ugx",
                CustomerResponseDataBillingCurrency.Pyg => "pyg",
                CustomerResponseDataBillingCurrency.Xof => "xof",
                CustomerResponseDataBillingCurrency.Xpf => "xpf",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Customer level coupon
/// </summary>
[JsonConverter(typeof(CustomerResponseDataCouponIDConverter))]
public enum CustomerResponseDataCouponID
{
    Undefined,
}

sealed class CustomerResponseDataCouponIDConverter : JsonConverter<CustomerResponseDataCouponID>
{
    public override CustomerResponseDataCouponID Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "" => CustomerResponseDataCouponID.Undefined,
            _ => (CustomerResponseDataCouponID)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CustomerResponseDataCouponID value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CustomerResponseDataCouponID.Undefined => "",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The default payment method details
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CustomerResponseDataDefaultPaymentMethod,
        CustomerResponseDataDefaultPaymentMethodFromRaw
    >)
)]
public sealed record class CustomerResponseDataDefaultPaymentMethod : JsonModel
{
    /// <summary>
    /// The default payment method id
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
    /// The expiration month of the default payment method
    /// </summary>
    public required double? CardExpiryMonth
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("cardExpiryMonth");
        }
        init { this._rawData.Set("cardExpiryMonth", value); }
    }

    /// <summary>
    /// The expiration year of the default payment method
    /// </summary>
    public required double? CardExpiryYear
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("cardExpiryYear");
        }
        init { this._rawData.Set("cardExpiryYear", value); }
    }

    /// <summary>
    /// The last 4 digits of the default payment method
    /// </summary>
    public required string? CardLast4Digits
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("cardLast4Digits");
        }
        init { this._rawData.Set("cardLast4Digits", value); }
    }

    /// <summary>
    /// The default payment method type
    /// </summary>
    public required ApiEnum<string, CustomerResponseDataDefaultPaymentMethodType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, CustomerResponseDataDefaultPaymentMethodType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BillingID;
        _ = this.CardExpiryMonth;
        _ = this.CardExpiryYear;
        _ = this.CardLast4Digits;
        this.Type.Validate();
    }

    public CustomerResponseDataDefaultPaymentMethod() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerResponseDataDefaultPaymentMethod(
        CustomerResponseDataDefaultPaymentMethod customerResponseDataDefaultPaymentMethod
    )
        : base(customerResponseDataDefaultPaymentMethod) { }
#pragma warning restore CS8618

    public CustomerResponseDataDefaultPaymentMethod(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerResponseDataDefaultPaymentMethod(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerResponseDataDefaultPaymentMethodFromRaw.FromRawUnchecked"/>
    public static CustomerResponseDataDefaultPaymentMethod FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerResponseDataDefaultPaymentMethodFromRaw
    : IFromRawJson<CustomerResponseDataDefaultPaymentMethod>
{
    /// <inheritdoc/>
    public CustomerResponseDataDefaultPaymentMethod FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerResponseDataDefaultPaymentMethod.FromRawUnchecked(rawData);
}

/// <summary>
/// The default payment method type
/// </summary>
[JsonConverter(typeof(CustomerResponseDataDefaultPaymentMethodTypeConverter))]
public enum CustomerResponseDataDefaultPaymentMethodType
{
    Card,
    Bank,
    CashApp,
}

sealed class CustomerResponseDataDefaultPaymentMethodTypeConverter
    : JsonConverter<CustomerResponseDataDefaultPaymentMethodType>
{
    public override CustomerResponseDataDefaultPaymentMethodType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "CARD" => CustomerResponseDataDefaultPaymentMethodType.Card,
            "BANK" => CustomerResponseDataDefaultPaymentMethodType.Bank,
            "CASH_APP" => CustomerResponseDataDefaultPaymentMethodType.CashApp,
            _ => (CustomerResponseDataDefaultPaymentMethodType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CustomerResponseDataDefaultPaymentMethodType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CustomerResponseDataDefaultPaymentMethodType.Card => "CARD",
                CustomerResponseDataDefaultPaymentMethodType.Bank => "BANK",
                CustomerResponseDataDefaultPaymentMethodType.CashApp => "CASH_APP",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// External billing or CRM integration link
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CustomerResponseDataIntegration,
        CustomerResponseDataIntegrationFromRaw
    >)
)]
public sealed record class CustomerResponseDataIntegration : JsonModel
{
    /// <summary>
    /// Integration details
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
    /// Synced entity id
    /// </summary>
    public required string? SyncedEntityID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("syncedEntityId");
        }
        init { this._rawData.Set("syncedEntityId", value); }
    }

    /// <summary>
    /// The vendor identifier of integration
    /// </summary>
    public required ApiEnum<
        string,
        CustomerResponseDataIntegrationVendorIdentifier
    > VendorIdentifier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, CustomerResponseDataIntegrationVendorIdentifier>
            >("vendorIdentifier");
        }
        init { this._rawData.Set("vendorIdentifier", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.SyncedEntityID;
        this.VendorIdentifier.Validate();
    }

    public CustomerResponseDataIntegration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerResponseDataIntegration(
        CustomerResponseDataIntegration customerResponseDataIntegration
    )
        : base(customerResponseDataIntegration) { }
#pragma warning restore CS8618

    public CustomerResponseDataIntegration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerResponseDataIntegration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerResponseDataIntegrationFromRaw.FromRawUnchecked"/>
    public static CustomerResponseDataIntegration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerResponseDataIntegrationFromRaw : IFromRawJson<CustomerResponseDataIntegration>
{
    /// <inheritdoc/>
    public CustomerResponseDataIntegration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerResponseDataIntegration.FromRawUnchecked(rawData);
}

/// <summary>
/// The vendor identifier of integration
/// </summary>
[JsonConverter(typeof(CustomerResponseDataIntegrationVendorIdentifierConverter))]
public enum CustomerResponseDataIntegrationVendorIdentifier
{
    Auth0,
    Zuora,
    Stripe,
    Hubspot,
    AwsMarketplace,
    Snowflake,
    Salesforce,
    BigQuery,
    OpenFga,
    AppStore,
}

sealed class CustomerResponseDataIntegrationVendorIdentifierConverter
    : JsonConverter<CustomerResponseDataIntegrationVendorIdentifier>
{
    public override CustomerResponseDataIntegrationVendorIdentifier Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "AUTH0" => CustomerResponseDataIntegrationVendorIdentifier.Auth0,
            "ZUORA" => CustomerResponseDataIntegrationVendorIdentifier.Zuora,
            "STRIPE" => CustomerResponseDataIntegrationVendorIdentifier.Stripe,
            "HUBSPOT" => CustomerResponseDataIntegrationVendorIdentifier.Hubspot,
            "AWS_MARKETPLACE" => CustomerResponseDataIntegrationVendorIdentifier.AwsMarketplace,
            "SNOWFLAKE" => CustomerResponseDataIntegrationVendorIdentifier.Snowflake,
            "SALESFORCE" => CustomerResponseDataIntegrationVendorIdentifier.Salesforce,
            "BIG_QUERY" => CustomerResponseDataIntegrationVendorIdentifier.BigQuery,
            "OPEN_FGA" => CustomerResponseDataIntegrationVendorIdentifier.OpenFga,
            "APP_STORE" => CustomerResponseDataIntegrationVendorIdentifier.AppStore,
            _ => (CustomerResponseDataIntegrationVendorIdentifier)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CustomerResponseDataIntegrationVendorIdentifier value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CustomerResponseDataIntegrationVendorIdentifier.Auth0 => "AUTH0",
                CustomerResponseDataIntegrationVendorIdentifier.Zuora => "ZUORA",
                CustomerResponseDataIntegrationVendorIdentifier.Stripe => "STRIPE",
                CustomerResponseDataIntegrationVendorIdentifier.Hubspot => "HUBSPOT",
                CustomerResponseDataIntegrationVendorIdentifier.AwsMarketplace => "AWS_MARKETPLACE",
                CustomerResponseDataIntegrationVendorIdentifier.Snowflake => "SNOWFLAKE",
                CustomerResponseDataIntegrationVendorIdentifier.Salesforce => "SALESFORCE",
                CustomerResponseDataIntegrationVendorIdentifier.BigQuery => "BIG_QUERY",
                CustomerResponseDataIntegrationVendorIdentifier.OpenFga => "OPEN_FGA",
                CustomerResponseDataIntegrationVendorIdentifier.AppStore => "APP_STORE",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Vendor-specific billing passthrough fields.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CustomerResponseDataPassthrough,
        CustomerResponseDataPassthroughFromRaw
    >)
)]
public sealed record class CustomerResponseDataPassthrough : JsonModel
{
    /// <summary>
    /// Stripe-specific billing fields for the customer.
    /// </summary>
    public CustomerResponseDataPassthroughStripe? Stripe
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CustomerResponseDataPassthroughStripe>("stripe");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("stripe", value);
        }
    }

    /// <summary>
    /// Zuora-specific billing fields for the customer.
    /// </summary>
    public CustomerResponseDataPassthroughZuora? Zuora
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CustomerResponseDataPassthroughZuora>("zuora");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("zuora", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Stripe?.Validate();
        this.Zuora?.Validate();
    }

    public CustomerResponseDataPassthrough() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerResponseDataPassthrough(
        CustomerResponseDataPassthrough customerResponseDataPassthrough
    )
        : base(customerResponseDataPassthrough) { }
#pragma warning restore CS8618

    public CustomerResponseDataPassthrough(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerResponseDataPassthrough(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerResponseDataPassthroughFromRaw.FromRawUnchecked"/>
    public static CustomerResponseDataPassthrough FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerResponseDataPassthroughFromRaw : IFromRawJson<CustomerResponseDataPassthrough>
{
    /// <inheritdoc/>
    public CustomerResponseDataPassthrough FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerResponseDataPassthrough.FromRawUnchecked(rawData);
}

/// <summary>
/// Stripe-specific billing fields for the customer.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CustomerResponseDataPassthroughStripe,
        CustomerResponseDataPassthroughStripeFromRaw
    >)
)]
public sealed record class CustomerResponseDataPassthroughStripe : JsonModel
{
    /// <summary>
    /// Physical address
    /// </summary>
    public CustomerResponseDataPassthroughStripeBillingAddress? BillingAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CustomerResponseDataPassthroughStripeBillingAddress>(
                "billingAddress"
            );
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

    /// <summary>
    /// Customer name
    /// </summary>
    public string? CustomerName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("customerName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("customerName", value);
        }
    }

    /// <summary>
    /// Invoice custom fields
    /// </summary>
    public IReadOnlyDictionary<string, string>? InvoiceCustomFields
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>(
                "invoiceCustomFields"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, string>?>(
                "invoiceCustomFields",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Additional metadata
    /// </summary>
    public IReadOnlyDictionary<string, string>? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, string>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Billing provider payment method id, attached to this customer
    /// </summary>
    public string? PaymentMethodID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("paymentMethodId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("paymentMethodId", value);
        }
    }

    /// <summary>
    /// Physical address
    /// </summary>
    public CustomerResponseDataPassthroughStripeShippingAddress? ShippingAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CustomerResponseDataPassthroughStripeShippingAddress>(
                "shippingAddress"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("shippingAddress", value);
        }
    }

    /// <summary>
    /// Tax IDs
    /// </summary>
    public IReadOnlyList<CustomerResponseDataPassthroughStripeTaxID>? TaxIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<CustomerResponseDataPassthroughStripeTaxID>
            >("taxIds");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<CustomerResponseDataPassthroughStripeTaxID>?>(
                "taxIds",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.BillingAddress?.Validate();
        _ = this.CustomerName;
        _ = this.InvoiceCustomFields;
        _ = this.Metadata;
        _ = this.PaymentMethodID;
        this.ShippingAddress?.Validate();
        foreach (var item in this.TaxIds ?? [])
        {
            item.Validate();
        }
    }

    public CustomerResponseDataPassthroughStripe() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerResponseDataPassthroughStripe(
        CustomerResponseDataPassthroughStripe customerResponseDataPassthroughStripe
    )
        : base(customerResponseDataPassthroughStripe) { }
#pragma warning restore CS8618

    public CustomerResponseDataPassthroughStripe(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerResponseDataPassthroughStripe(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerResponseDataPassthroughStripeFromRaw.FromRawUnchecked"/>
    public static CustomerResponseDataPassthroughStripe FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerResponseDataPassthroughStripeFromRaw
    : IFromRawJson<CustomerResponseDataPassthroughStripe>
{
    /// <inheritdoc/>
    public CustomerResponseDataPassthroughStripe FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerResponseDataPassthroughStripe.FromRawUnchecked(rawData);
}

/// <summary>
/// Physical address
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CustomerResponseDataPassthroughStripeBillingAddress,
        CustomerResponseDataPassthroughStripeBillingAddressFromRaw
    >)
)]
public sealed record class CustomerResponseDataPassthroughStripeBillingAddress : JsonModel
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

    public CustomerResponseDataPassthroughStripeBillingAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerResponseDataPassthroughStripeBillingAddress(
        CustomerResponseDataPassthroughStripeBillingAddress customerResponseDataPassthroughStripeBillingAddress
    )
        : base(customerResponseDataPassthroughStripeBillingAddress) { }
#pragma warning restore CS8618

    public CustomerResponseDataPassthroughStripeBillingAddress(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerResponseDataPassthroughStripeBillingAddress(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerResponseDataPassthroughStripeBillingAddressFromRaw.FromRawUnchecked"/>
    public static CustomerResponseDataPassthroughStripeBillingAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerResponseDataPassthroughStripeBillingAddressFromRaw
    : IFromRawJson<CustomerResponseDataPassthroughStripeBillingAddress>
{
    /// <inheritdoc/>
    public CustomerResponseDataPassthroughStripeBillingAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerResponseDataPassthroughStripeBillingAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// Physical address
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CustomerResponseDataPassthroughStripeShippingAddress,
        CustomerResponseDataPassthroughStripeShippingAddressFromRaw
    >)
)]
public sealed record class CustomerResponseDataPassthroughStripeShippingAddress : JsonModel
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

    public CustomerResponseDataPassthroughStripeShippingAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerResponseDataPassthroughStripeShippingAddress(
        CustomerResponseDataPassthroughStripeShippingAddress customerResponseDataPassthroughStripeShippingAddress
    )
        : base(customerResponseDataPassthroughStripeShippingAddress) { }
#pragma warning restore CS8618

    public CustomerResponseDataPassthroughStripeShippingAddress(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerResponseDataPassthroughStripeShippingAddress(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerResponseDataPassthroughStripeShippingAddressFromRaw.FromRawUnchecked"/>
    public static CustomerResponseDataPassthroughStripeShippingAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerResponseDataPassthroughStripeShippingAddressFromRaw
    : IFromRawJson<CustomerResponseDataPassthroughStripeShippingAddress>
{
    /// <inheritdoc/>
    public CustomerResponseDataPassthroughStripeShippingAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerResponseDataPassthroughStripeShippingAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// Tax identifier with type and value for customer tax exemptions.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CustomerResponseDataPassthroughStripeTaxID,
        CustomerResponseDataPassthroughStripeTaxIDFromRaw
    >)
)]
public sealed record class CustomerResponseDataPassthroughStripeTaxID : JsonModel
{
    /// <summary>
    /// The type of tax exemption identifier, such as VAT.
    /// </summary>
    public required string Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// The actual tax identifier value
    /// </summary>
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

    public CustomerResponseDataPassthroughStripeTaxID() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerResponseDataPassthroughStripeTaxID(
        CustomerResponseDataPassthroughStripeTaxID customerResponseDataPassthroughStripeTaxID
    )
        : base(customerResponseDataPassthroughStripeTaxID) { }
#pragma warning restore CS8618

    public CustomerResponseDataPassthroughStripeTaxID(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerResponseDataPassthroughStripeTaxID(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerResponseDataPassthroughStripeTaxIDFromRaw.FromRawUnchecked"/>
    public static CustomerResponseDataPassthroughStripeTaxID FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerResponseDataPassthroughStripeTaxIDFromRaw
    : IFromRawJson<CustomerResponseDataPassthroughStripeTaxID>
{
    /// <inheritdoc/>
    public CustomerResponseDataPassthroughStripeTaxID FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerResponseDataPassthroughStripeTaxID.FromRawUnchecked(rawData);
}

/// <summary>
/// Zuora-specific billing fields for the customer.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CustomerResponseDataPassthroughZuora,
        CustomerResponseDataPassthroughZuoraFromRaw
    >)
)]
public sealed record class CustomerResponseDataPassthroughZuora : JsonModel
{
    /// <summary>
    /// Physical address
    /// </summary>
    public CustomerResponseDataPassthroughZuoraBillingAddress? BillingAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CustomerResponseDataPassthroughZuoraBillingAddress>(
                "billingAddress"
            );
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

    /// <summary>
    /// Customers selected currency
    /// </summary>
    public ApiEnum<string, CustomerResponseDataPassthroughZuoraCurrency>? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, CustomerResponseDataPassthroughZuoraCurrency>
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

    /// <summary>
    /// Additional metadata
    /// </summary>
    public IReadOnlyDictionary<string, string>? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, string>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Billing provider payment method id, attached to this customer
    /// </summary>
    public string? PaymentMethodID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("paymentMethodId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("paymentMethodId", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.BillingAddress?.Validate();
        this.Currency?.Validate();
        _ = this.Metadata;
        _ = this.PaymentMethodID;
    }

    public CustomerResponseDataPassthroughZuora() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerResponseDataPassthroughZuora(
        CustomerResponseDataPassthroughZuora customerResponseDataPassthroughZuora
    )
        : base(customerResponseDataPassthroughZuora) { }
#pragma warning restore CS8618

    public CustomerResponseDataPassthroughZuora(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerResponseDataPassthroughZuora(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerResponseDataPassthroughZuoraFromRaw.FromRawUnchecked"/>
    public static CustomerResponseDataPassthroughZuora FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerResponseDataPassthroughZuoraFromRaw
    : IFromRawJson<CustomerResponseDataPassthroughZuora>
{
    /// <inheritdoc/>
    public CustomerResponseDataPassthroughZuora FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerResponseDataPassthroughZuora.FromRawUnchecked(rawData);
}

/// <summary>
/// Physical address
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CustomerResponseDataPassthroughZuoraBillingAddress,
        CustomerResponseDataPassthroughZuoraBillingAddressFromRaw
    >)
)]
public sealed record class CustomerResponseDataPassthroughZuoraBillingAddress : JsonModel
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

    public CustomerResponseDataPassthroughZuoraBillingAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerResponseDataPassthroughZuoraBillingAddress(
        CustomerResponseDataPassthroughZuoraBillingAddress customerResponseDataPassthroughZuoraBillingAddress
    )
        : base(customerResponseDataPassthroughZuoraBillingAddress) { }
#pragma warning restore CS8618

    public CustomerResponseDataPassthroughZuoraBillingAddress(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerResponseDataPassthroughZuoraBillingAddress(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerResponseDataPassthroughZuoraBillingAddressFromRaw.FromRawUnchecked"/>
    public static CustomerResponseDataPassthroughZuoraBillingAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerResponseDataPassthroughZuoraBillingAddressFromRaw
    : IFromRawJson<CustomerResponseDataPassthroughZuoraBillingAddress>
{
    /// <inheritdoc/>
    public CustomerResponseDataPassthroughZuoraBillingAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerResponseDataPassthroughZuoraBillingAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// Customers selected currency
/// </summary>
[JsonConverter(typeof(CustomerResponseDataPassthroughZuoraCurrencyConverter))]
public enum CustomerResponseDataPassthroughZuoraCurrency
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

sealed class CustomerResponseDataPassthroughZuoraCurrencyConverter
    : JsonConverter<CustomerResponseDataPassthroughZuoraCurrency>
{
    public override CustomerResponseDataPassthroughZuoraCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => CustomerResponseDataPassthroughZuoraCurrency.Usd,
            "aed" => CustomerResponseDataPassthroughZuoraCurrency.Aed,
            "all" => CustomerResponseDataPassthroughZuoraCurrency.All,
            "amd" => CustomerResponseDataPassthroughZuoraCurrency.Amd,
            "ang" => CustomerResponseDataPassthroughZuoraCurrency.Ang,
            "aud" => CustomerResponseDataPassthroughZuoraCurrency.Aud,
            "awg" => CustomerResponseDataPassthroughZuoraCurrency.Awg,
            "azn" => CustomerResponseDataPassthroughZuoraCurrency.Azn,
            "bam" => CustomerResponseDataPassthroughZuoraCurrency.Bam,
            "bbd" => CustomerResponseDataPassthroughZuoraCurrency.Bbd,
            "bdt" => CustomerResponseDataPassthroughZuoraCurrency.Bdt,
            "bgn" => CustomerResponseDataPassthroughZuoraCurrency.Bgn,
            "bif" => CustomerResponseDataPassthroughZuoraCurrency.Bif,
            "bmd" => CustomerResponseDataPassthroughZuoraCurrency.Bmd,
            "bnd" => CustomerResponseDataPassthroughZuoraCurrency.Bnd,
            "bsd" => CustomerResponseDataPassthroughZuoraCurrency.Bsd,
            "bwp" => CustomerResponseDataPassthroughZuoraCurrency.Bwp,
            "byn" => CustomerResponseDataPassthroughZuoraCurrency.Byn,
            "bzd" => CustomerResponseDataPassthroughZuoraCurrency.Bzd,
            "brl" => CustomerResponseDataPassthroughZuoraCurrency.Brl,
            "cad" => CustomerResponseDataPassthroughZuoraCurrency.Cad,
            "cdf" => CustomerResponseDataPassthroughZuoraCurrency.Cdf,
            "chf" => CustomerResponseDataPassthroughZuoraCurrency.Chf,
            "cny" => CustomerResponseDataPassthroughZuoraCurrency.Cny,
            "czk" => CustomerResponseDataPassthroughZuoraCurrency.Czk,
            "dkk" => CustomerResponseDataPassthroughZuoraCurrency.Dkk,
            "dop" => CustomerResponseDataPassthroughZuoraCurrency.Dop,
            "dzd" => CustomerResponseDataPassthroughZuoraCurrency.Dzd,
            "egp" => CustomerResponseDataPassthroughZuoraCurrency.Egp,
            "etb" => CustomerResponseDataPassthroughZuoraCurrency.Etb,
            "eur" => CustomerResponseDataPassthroughZuoraCurrency.Eur,
            "fjd" => CustomerResponseDataPassthroughZuoraCurrency.Fjd,
            "gbp" => CustomerResponseDataPassthroughZuoraCurrency.Gbp,
            "gel" => CustomerResponseDataPassthroughZuoraCurrency.Gel,
            "gip" => CustomerResponseDataPassthroughZuoraCurrency.Gip,
            "gmd" => CustomerResponseDataPassthroughZuoraCurrency.Gmd,
            "gyd" => CustomerResponseDataPassthroughZuoraCurrency.Gyd,
            "hkd" => CustomerResponseDataPassthroughZuoraCurrency.Hkd,
            "hrk" => CustomerResponseDataPassthroughZuoraCurrency.Hrk,
            "htg" => CustomerResponseDataPassthroughZuoraCurrency.Htg,
            "idr" => CustomerResponseDataPassthroughZuoraCurrency.Idr,
            "ils" => CustomerResponseDataPassthroughZuoraCurrency.Ils,
            "inr" => CustomerResponseDataPassthroughZuoraCurrency.Inr,
            "isk" => CustomerResponseDataPassthroughZuoraCurrency.Isk,
            "jmd" => CustomerResponseDataPassthroughZuoraCurrency.Jmd,
            "jpy" => CustomerResponseDataPassthroughZuoraCurrency.Jpy,
            "kes" => CustomerResponseDataPassthroughZuoraCurrency.Kes,
            "kgs" => CustomerResponseDataPassthroughZuoraCurrency.Kgs,
            "khr" => CustomerResponseDataPassthroughZuoraCurrency.Khr,
            "kmf" => CustomerResponseDataPassthroughZuoraCurrency.Kmf,
            "krw" => CustomerResponseDataPassthroughZuoraCurrency.Krw,
            "kyd" => CustomerResponseDataPassthroughZuoraCurrency.Kyd,
            "kzt" => CustomerResponseDataPassthroughZuoraCurrency.Kzt,
            "lbp" => CustomerResponseDataPassthroughZuoraCurrency.Lbp,
            "lkr" => CustomerResponseDataPassthroughZuoraCurrency.Lkr,
            "lrd" => CustomerResponseDataPassthroughZuoraCurrency.Lrd,
            "lsl" => CustomerResponseDataPassthroughZuoraCurrency.Lsl,
            "mad" => CustomerResponseDataPassthroughZuoraCurrency.Mad,
            "mdl" => CustomerResponseDataPassthroughZuoraCurrency.Mdl,
            "mga" => CustomerResponseDataPassthroughZuoraCurrency.Mga,
            "mkd" => CustomerResponseDataPassthroughZuoraCurrency.Mkd,
            "mmk" => CustomerResponseDataPassthroughZuoraCurrency.Mmk,
            "mnt" => CustomerResponseDataPassthroughZuoraCurrency.Mnt,
            "mop" => CustomerResponseDataPassthroughZuoraCurrency.Mop,
            "mro" => CustomerResponseDataPassthroughZuoraCurrency.Mro,
            "mvr" => CustomerResponseDataPassthroughZuoraCurrency.Mvr,
            "mwk" => CustomerResponseDataPassthroughZuoraCurrency.Mwk,
            "mxn" => CustomerResponseDataPassthroughZuoraCurrency.Mxn,
            "myr" => CustomerResponseDataPassthroughZuoraCurrency.Myr,
            "mzn" => CustomerResponseDataPassthroughZuoraCurrency.Mzn,
            "nad" => CustomerResponseDataPassthroughZuoraCurrency.Nad,
            "ngn" => CustomerResponseDataPassthroughZuoraCurrency.Ngn,
            "nok" => CustomerResponseDataPassthroughZuoraCurrency.Nok,
            "npr" => CustomerResponseDataPassthroughZuoraCurrency.Npr,
            "nzd" => CustomerResponseDataPassthroughZuoraCurrency.Nzd,
            "pgk" => CustomerResponseDataPassthroughZuoraCurrency.Pgk,
            "php" => CustomerResponseDataPassthroughZuoraCurrency.Php,
            "pkr" => CustomerResponseDataPassthroughZuoraCurrency.Pkr,
            "pln" => CustomerResponseDataPassthroughZuoraCurrency.Pln,
            "qar" => CustomerResponseDataPassthroughZuoraCurrency.Qar,
            "ron" => CustomerResponseDataPassthroughZuoraCurrency.Ron,
            "rsd" => CustomerResponseDataPassthroughZuoraCurrency.Rsd,
            "rub" => CustomerResponseDataPassthroughZuoraCurrency.Rub,
            "rwf" => CustomerResponseDataPassthroughZuoraCurrency.Rwf,
            "sar" => CustomerResponseDataPassthroughZuoraCurrency.Sar,
            "sbd" => CustomerResponseDataPassthroughZuoraCurrency.Sbd,
            "scr" => CustomerResponseDataPassthroughZuoraCurrency.Scr,
            "sek" => CustomerResponseDataPassthroughZuoraCurrency.Sek,
            "sgd" => CustomerResponseDataPassthroughZuoraCurrency.Sgd,
            "sle" => CustomerResponseDataPassthroughZuoraCurrency.Sle,
            "sll" => CustomerResponseDataPassthroughZuoraCurrency.Sll,
            "sos" => CustomerResponseDataPassthroughZuoraCurrency.Sos,
            "szl" => CustomerResponseDataPassthroughZuoraCurrency.Szl,
            "thb" => CustomerResponseDataPassthroughZuoraCurrency.Thb,
            "tjs" => CustomerResponseDataPassthroughZuoraCurrency.Tjs,
            "top" => CustomerResponseDataPassthroughZuoraCurrency.Top,
            "try" => CustomerResponseDataPassthroughZuoraCurrency.Try,
            "ttd" => CustomerResponseDataPassthroughZuoraCurrency.Ttd,
            "tzs" => CustomerResponseDataPassthroughZuoraCurrency.Tzs,
            "uah" => CustomerResponseDataPassthroughZuoraCurrency.Uah,
            "uzs" => CustomerResponseDataPassthroughZuoraCurrency.Uzs,
            "vnd" => CustomerResponseDataPassthroughZuoraCurrency.Vnd,
            "vuv" => CustomerResponseDataPassthroughZuoraCurrency.Vuv,
            "wst" => CustomerResponseDataPassthroughZuoraCurrency.Wst,
            "xaf" => CustomerResponseDataPassthroughZuoraCurrency.Xaf,
            "xcd" => CustomerResponseDataPassthroughZuoraCurrency.Xcd,
            "yer" => CustomerResponseDataPassthroughZuoraCurrency.Yer,
            "zar" => CustomerResponseDataPassthroughZuoraCurrency.Zar,
            "zmw" => CustomerResponseDataPassthroughZuoraCurrency.Zmw,
            "clp" => CustomerResponseDataPassthroughZuoraCurrency.Clp,
            "djf" => CustomerResponseDataPassthroughZuoraCurrency.Djf,
            "gnf" => CustomerResponseDataPassthroughZuoraCurrency.Gnf,
            "ugx" => CustomerResponseDataPassthroughZuoraCurrency.Ugx,
            "pyg" => CustomerResponseDataPassthroughZuoraCurrency.Pyg,
            "xof" => CustomerResponseDataPassthroughZuoraCurrency.Xof,
            "xpf" => CustomerResponseDataPassthroughZuoraCurrency.Xpf,
            _ => (CustomerResponseDataPassthroughZuoraCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CustomerResponseDataPassthroughZuoraCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CustomerResponseDataPassthroughZuoraCurrency.Usd => "usd",
                CustomerResponseDataPassthroughZuoraCurrency.Aed => "aed",
                CustomerResponseDataPassthroughZuoraCurrency.All => "all",
                CustomerResponseDataPassthroughZuoraCurrency.Amd => "amd",
                CustomerResponseDataPassthroughZuoraCurrency.Ang => "ang",
                CustomerResponseDataPassthroughZuoraCurrency.Aud => "aud",
                CustomerResponseDataPassthroughZuoraCurrency.Awg => "awg",
                CustomerResponseDataPassthroughZuoraCurrency.Azn => "azn",
                CustomerResponseDataPassthroughZuoraCurrency.Bam => "bam",
                CustomerResponseDataPassthroughZuoraCurrency.Bbd => "bbd",
                CustomerResponseDataPassthroughZuoraCurrency.Bdt => "bdt",
                CustomerResponseDataPassthroughZuoraCurrency.Bgn => "bgn",
                CustomerResponseDataPassthroughZuoraCurrency.Bif => "bif",
                CustomerResponseDataPassthroughZuoraCurrency.Bmd => "bmd",
                CustomerResponseDataPassthroughZuoraCurrency.Bnd => "bnd",
                CustomerResponseDataPassthroughZuoraCurrency.Bsd => "bsd",
                CustomerResponseDataPassthroughZuoraCurrency.Bwp => "bwp",
                CustomerResponseDataPassthroughZuoraCurrency.Byn => "byn",
                CustomerResponseDataPassthroughZuoraCurrency.Bzd => "bzd",
                CustomerResponseDataPassthroughZuoraCurrency.Brl => "brl",
                CustomerResponseDataPassthroughZuoraCurrency.Cad => "cad",
                CustomerResponseDataPassthroughZuoraCurrency.Cdf => "cdf",
                CustomerResponseDataPassthroughZuoraCurrency.Chf => "chf",
                CustomerResponseDataPassthroughZuoraCurrency.Cny => "cny",
                CustomerResponseDataPassthroughZuoraCurrency.Czk => "czk",
                CustomerResponseDataPassthroughZuoraCurrency.Dkk => "dkk",
                CustomerResponseDataPassthroughZuoraCurrency.Dop => "dop",
                CustomerResponseDataPassthroughZuoraCurrency.Dzd => "dzd",
                CustomerResponseDataPassthroughZuoraCurrency.Egp => "egp",
                CustomerResponseDataPassthroughZuoraCurrency.Etb => "etb",
                CustomerResponseDataPassthroughZuoraCurrency.Eur => "eur",
                CustomerResponseDataPassthroughZuoraCurrency.Fjd => "fjd",
                CustomerResponseDataPassthroughZuoraCurrency.Gbp => "gbp",
                CustomerResponseDataPassthroughZuoraCurrency.Gel => "gel",
                CustomerResponseDataPassthroughZuoraCurrency.Gip => "gip",
                CustomerResponseDataPassthroughZuoraCurrency.Gmd => "gmd",
                CustomerResponseDataPassthroughZuoraCurrency.Gyd => "gyd",
                CustomerResponseDataPassthroughZuoraCurrency.Hkd => "hkd",
                CustomerResponseDataPassthroughZuoraCurrency.Hrk => "hrk",
                CustomerResponseDataPassthroughZuoraCurrency.Htg => "htg",
                CustomerResponseDataPassthroughZuoraCurrency.Idr => "idr",
                CustomerResponseDataPassthroughZuoraCurrency.Ils => "ils",
                CustomerResponseDataPassthroughZuoraCurrency.Inr => "inr",
                CustomerResponseDataPassthroughZuoraCurrency.Isk => "isk",
                CustomerResponseDataPassthroughZuoraCurrency.Jmd => "jmd",
                CustomerResponseDataPassthroughZuoraCurrency.Jpy => "jpy",
                CustomerResponseDataPassthroughZuoraCurrency.Kes => "kes",
                CustomerResponseDataPassthroughZuoraCurrency.Kgs => "kgs",
                CustomerResponseDataPassthroughZuoraCurrency.Khr => "khr",
                CustomerResponseDataPassthroughZuoraCurrency.Kmf => "kmf",
                CustomerResponseDataPassthroughZuoraCurrency.Krw => "krw",
                CustomerResponseDataPassthroughZuoraCurrency.Kyd => "kyd",
                CustomerResponseDataPassthroughZuoraCurrency.Kzt => "kzt",
                CustomerResponseDataPassthroughZuoraCurrency.Lbp => "lbp",
                CustomerResponseDataPassthroughZuoraCurrency.Lkr => "lkr",
                CustomerResponseDataPassthroughZuoraCurrency.Lrd => "lrd",
                CustomerResponseDataPassthroughZuoraCurrency.Lsl => "lsl",
                CustomerResponseDataPassthroughZuoraCurrency.Mad => "mad",
                CustomerResponseDataPassthroughZuoraCurrency.Mdl => "mdl",
                CustomerResponseDataPassthroughZuoraCurrency.Mga => "mga",
                CustomerResponseDataPassthroughZuoraCurrency.Mkd => "mkd",
                CustomerResponseDataPassthroughZuoraCurrency.Mmk => "mmk",
                CustomerResponseDataPassthroughZuoraCurrency.Mnt => "mnt",
                CustomerResponseDataPassthroughZuoraCurrency.Mop => "mop",
                CustomerResponseDataPassthroughZuoraCurrency.Mro => "mro",
                CustomerResponseDataPassthroughZuoraCurrency.Mvr => "mvr",
                CustomerResponseDataPassthroughZuoraCurrency.Mwk => "mwk",
                CustomerResponseDataPassthroughZuoraCurrency.Mxn => "mxn",
                CustomerResponseDataPassthroughZuoraCurrency.Myr => "myr",
                CustomerResponseDataPassthroughZuoraCurrency.Mzn => "mzn",
                CustomerResponseDataPassthroughZuoraCurrency.Nad => "nad",
                CustomerResponseDataPassthroughZuoraCurrency.Ngn => "ngn",
                CustomerResponseDataPassthroughZuoraCurrency.Nok => "nok",
                CustomerResponseDataPassthroughZuoraCurrency.Npr => "npr",
                CustomerResponseDataPassthroughZuoraCurrency.Nzd => "nzd",
                CustomerResponseDataPassthroughZuoraCurrency.Pgk => "pgk",
                CustomerResponseDataPassthroughZuoraCurrency.Php => "php",
                CustomerResponseDataPassthroughZuoraCurrency.Pkr => "pkr",
                CustomerResponseDataPassthroughZuoraCurrency.Pln => "pln",
                CustomerResponseDataPassthroughZuoraCurrency.Qar => "qar",
                CustomerResponseDataPassthroughZuoraCurrency.Ron => "ron",
                CustomerResponseDataPassthroughZuoraCurrency.Rsd => "rsd",
                CustomerResponseDataPassthroughZuoraCurrency.Rub => "rub",
                CustomerResponseDataPassthroughZuoraCurrency.Rwf => "rwf",
                CustomerResponseDataPassthroughZuoraCurrency.Sar => "sar",
                CustomerResponseDataPassthroughZuoraCurrency.Sbd => "sbd",
                CustomerResponseDataPassthroughZuoraCurrency.Scr => "scr",
                CustomerResponseDataPassthroughZuoraCurrency.Sek => "sek",
                CustomerResponseDataPassthroughZuoraCurrency.Sgd => "sgd",
                CustomerResponseDataPassthroughZuoraCurrency.Sle => "sle",
                CustomerResponseDataPassthroughZuoraCurrency.Sll => "sll",
                CustomerResponseDataPassthroughZuoraCurrency.Sos => "sos",
                CustomerResponseDataPassthroughZuoraCurrency.Szl => "szl",
                CustomerResponseDataPassthroughZuoraCurrency.Thb => "thb",
                CustomerResponseDataPassthroughZuoraCurrency.Tjs => "tjs",
                CustomerResponseDataPassthroughZuoraCurrency.Top => "top",
                CustomerResponseDataPassthroughZuoraCurrency.Try => "try",
                CustomerResponseDataPassthroughZuoraCurrency.Ttd => "ttd",
                CustomerResponseDataPassthroughZuoraCurrency.Tzs => "tzs",
                CustomerResponseDataPassthroughZuoraCurrency.Uah => "uah",
                CustomerResponseDataPassthroughZuoraCurrency.Uzs => "uzs",
                CustomerResponseDataPassthroughZuoraCurrency.Vnd => "vnd",
                CustomerResponseDataPassthroughZuoraCurrency.Vuv => "vuv",
                CustomerResponseDataPassthroughZuoraCurrency.Wst => "wst",
                CustomerResponseDataPassthroughZuoraCurrency.Xaf => "xaf",
                CustomerResponseDataPassthroughZuoraCurrency.Xcd => "xcd",
                CustomerResponseDataPassthroughZuoraCurrency.Yer => "yer",
                CustomerResponseDataPassthroughZuoraCurrency.Zar => "zar",
                CustomerResponseDataPassthroughZuoraCurrency.Zmw => "zmw",
                CustomerResponseDataPassthroughZuoraCurrency.Clp => "clp",
                CustomerResponseDataPassthroughZuoraCurrency.Djf => "djf",
                CustomerResponseDataPassthroughZuoraCurrency.Gnf => "gnf",
                CustomerResponseDataPassthroughZuoraCurrency.Ugx => "ugx",
                CustomerResponseDataPassthroughZuoraCurrency.Pyg => "pyg",
                CustomerResponseDataPassthroughZuoraCurrency.Xof => "xof",
                CustomerResponseDataPassthroughZuoraCurrency.Xpf => "xpf",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
