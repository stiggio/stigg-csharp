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
    public CustomerResponse(Data data)
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
[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
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
    public ApiEnum<string, DataBillingCurrency>? BillingCurrency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, DataBillingCurrency>>(
                "billingCurrency"
            );
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
    public string? CouponID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("couponId");
        }
        init { this._rawData.Set("couponId", value); }
    }

    /// <summary>
    /// The default payment method details
    /// </summary>
    public DataDefaultPaymentMethod? DefaultPaymentMethod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<DataDefaultPaymentMethod>("defaultPaymentMethod");
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
    public IReadOnlyList<DataIntegration>? Integrations
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<DataIntegration>>("integrations");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<DataIntegration>?>(
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
    public DataPassthrough? Passthrough
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<DataPassthrough>("passthrough");
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
        _ = this.CouponID;
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
/// The billing currency of the customer
/// </summary>
[JsonConverter(typeof(DataBillingCurrencyConverter))]
public enum DataBillingCurrency
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

sealed class DataBillingCurrencyConverter : JsonConverter<DataBillingCurrency>
{
    public override DataBillingCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => DataBillingCurrency.Usd,
            "aed" => DataBillingCurrency.Aed,
            "all" => DataBillingCurrency.All,
            "amd" => DataBillingCurrency.Amd,
            "ang" => DataBillingCurrency.Ang,
            "aud" => DataBillingCurrency.Aud,
            "awg" => DataBillingCurrency.Awg,
            "azn" => DataBillingCurrency.Azn,
            "bam" => DataBillingCurrency.Bam,
            "bbd" => DataBillingCurrency.Bbd,
            "bdt" => DataBillingCurrency.Bdt,
            "bgn" => DataBillingCurrency.Bgn,
            "bif" => DataBillingCurrency.Bif,
            "bmd" => DataBillingCurrency.Bmd,
            "bnd" => DataBillingCurrency.Bnd,
            "bsd" => DataBillingCurrency.Bsd,
            "bwp" => DataBillingCurrency.Bwp,
            "byn" => DataBillingCurrency.Byn,
            "bzd" => DataBillingCurrency.Bzd,
            "brl" => DataBillingCurrency.Brl,
            "cad" => DataBillingCurrency.Cad,
            "cdf" => DataBillingCurrency.Cdf,
            "chf" => DataBillingCurrency.Chf,
            "cny" => DataBillingCurrency.Cny,
            "czk" => DataBillingCurrency.Czk,
            "dkk" => DataBillingCurrency.Dkk,
            "dop" => DataBillingCurrency.Dop,
            "dzd" => DataBillingCurrency.Dzd,
            "egp" => DataBillingCurrency.Egp,
            "etb" => DataBillingCurrency.Etb,
            "eur" => DataBillingCurrency.Eur,
            "fjd" => DataBillingCurrency.Fjd,
            "gbp" => DataBillingCurrency.Gbp,
            "gel" => DataBillingCurrency.Gel,
            "gip" => DataBillingCurrency.Gip,
            "gmd" => DataBillingCurrency.Gmd,
            "gyd" => DataBillingCurrency.Gyd,
            "hkd" => DataBillingCurrency.Hkd,
            "hrk" => DataBillingCurrency.Hrk,
            "htg" => DataBillingCurrency.Htg,
            "idr" => DataBillingCurrency.Idr,
            "ils" => DataBillingCurrency.Ils,
            "inr" => DataBillingCurrency.Inr,
            "isk" => DataBillingCurrency.Isk,
            "jmd" => DataBillingCurrency.Jmd,
            "jpy" => DataBillingCurrency.Jpy,
            "kes" => DataBillingCurrency.Kes,
            "kgs" => DataBillingCurrency.Kgs,
            "khr" => DataBillingCurrency.Khr,
            "kmf" => DataBillingCurrency.Kmf,
            "krw" => DataBillingCurrency.Krw,
            "kyd" => DataBillingCurrency.Kyd,
            "kzt" => DataBillingCurrency.Kzt,
            "lbp" => DataBillingCurrency.Lbp,
            "lkr" => DataBillingCurrency.Lkr,
            "lrd" => DataBillingCurrency.Lrd,
            "lsl" => DataBillingCurrency.Lsl,
            "mad" => DataBillingCurrency.Mad,
            "mdl" => DataBillingCurrency.Mdl,
            "mga" => DataBillingCurrency.Mga,
            "mkd" => DataBillingCurrency.Mkd,
            "mmk" => DataBillingCurrency.Mmk,
            "mnt" => DataBillingCurrency.Mnt,
            "mop" => DataBillingCurrency.Mop,
            "mro" => DataBillingCurrency.Mro,
            "mvr" => DataBillingCurrency.Mvr,
            "mwk" => DataBillingCurrency.Mwk,
            "mxn" => DataBillingCurrency.Mxn,
            "myr" => DataBillingCurrency.Myr,
            "mzn" => DataBillingCurrency.Mzn,
            "nad" => DataBillingCurrency.Nad,
            "ngn" => DataBillingCurrency.Ngn,
            "nok" => DataBillingCurrency.Nok,
            "npr" => DataBillingCurrency.Npr,
            "nzd" => DataBillingCurrency.Nzd,
            "pgk" => DataBillingCurrency.Pgk,
            "php" => DataBillingCurrency.Php,
            "pkr" => DataBillingCurrency.Pkr,
            "pln" => DataBillingCurrency.Pln,
            "qar" => DataBillingCurrency.Qar,
            "ron" => DataBillingCurrency.Ron,
            "rsd" => DataBillingCurrency.Rsd,
            "rub" => DataBillingCurrency.Rub,
            "rwf" => DataBillingCurrency.Rwf,
            "sar" => DataBillingCurrency.Sar,
            "sbd" => DataBillingCurrency.Sbd,
            "scr" => DataBillingCurrency.Scr,
            "sek" => DataBillingCurrency.Sek,
            "sgd" => DataBillingCurrency.Sgd,
            "sle" => DataBillingCurrency.Sle,
            "sll" => DataBillingCurrency.Sll,
            "sos" => DataBillingCurrency.Sos,
            "szl" => DataBillingCurrency.Szl,
            "thb" => DataBillingCurrency.Thb,
            "tjs" => DataBillingCurrency.Tjs,
            "top" => DataBillingCurrency.Top,
            "try" => DataBillingCurrency.Try,
            "ttd" => DataBillingCurrency.Ttd,
            "tzs" => DataBillingCurrency.Tzs,
            "uah" => DataBillingCurrency.Uah,
            "uzs" => DataBillingCurrency.Uzs,
            "vnd" => DataBillingCurrency.Vnd,
            "vuv" => DataBillingCurrency.Vuv,
            "wst" => DataBillingCurrency.Wst,
            "xaf" => DataBillingCurrency.Xaf,
            "xcd" => DataBillingCurrency.Xcd,
            "yer" => DataBillingCurrency.Yer,
            "zar" => DataBillingCurrency.Zar,
            "zmw" => DataBillingCurrency.Zmw,
            "clp" => DataBillingCurrency.Clp,
            "djf" => DataBillingCurrency.Djf,
            "gnf" => DataBillingCurrency.Gnf,
            "ugx" => DataBillingCurrency.Ugx,
            "pyg" => DataBillingCurrency.Pyg,
            "xof" => DataBillingCurrency.Xof,
            "xpf" => DataBillingCurrency.Xpf,
            _ => (DataBillingCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DataBillingCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DataBillingCurrency.Usd => "usd",
                DataBillingCurrency.Aed => "aed",
                DataBillingCurrency.All => "all",
                DataBillingCurrency.Amd => "amd",
                DataBillingCurrency.Ang => "ang",
                DataBillingCurrency.Aud => "aud",
                DataBillingCurrency.Awg => "awg",
                DataBillingCurrency.Azn => "azn",
                DataBillingCurrency.Bam => "bam",
                DataBillingCurrency.Bbd => "bbd",
                DataBillingCurrency.Bdt => "bdt",
                DataBillingCurrency.Bgn => "bgn",
                DataBillingCurrency.Bif => "bif",
                DataBillingCurrency.Bmd => "bmd",
                DataBillingCurrency.Bnd => "bnd",
                DataBillingCurrency.Bsd => "bsd",
                DataBillingCurrency.Bwp => "bwp",
                DataBillingCurrency.Byn => "byn",
                DataBillingCurrency.Bzd => "bzd",
                DataBillingCurrency.Brl => "brl",
                DataBillingCurrency.Cad => "cad",
                DataBillingCurrency.Cdf => "cdf",
                DataBillingCurrency.Chf => "chf",
                DataBillingCurrency.Cny => "cny",
                DataBillingCurrency.Czk => "czk",
                DataBillingCurrency.Dkk => "dkk",
                DataBillingCurrency.Dop => "dop",
                DataBillingCurrency.Dzd => "dzd",
                DataBillingCurrency.Egp => "egp",
                DataBillingCurrency.Etb => "etb",
                DataBillingCurrency.Eur => "eur",
                DataBillingCurrency.Fjd => "fjd",
                DataBillingCurrency.Gbp => "gbp",
                DataBillingCurrency.Gel => "gel",
                DataBillingCurrency.Gip => "gip",
                DataBillingCurrency.Gmd => "gmd",
                DataBillingCurrency.Gyd => "gyd",
                DataBillingCurrency.Hkd => "hkd",
                DataBillingCurrency.Hrk => "hrk",
                DataBillingCurrency.Htg => "htg",
                DataBillingCurrency.Idr => "idr",
                DataBillingCurrency.Ils => "ils",
                DataBillingCurrency.Inr => "inr",
                DataBillingCurrency.Isk => "isk",
                DataBillingCurrency.Jmd => "jmd",
                DataBillingCurrency.Jpy => "jpy",
                DataBillingCurrency.Kes => "kes",
                DataBillingCurrency.Kgs => "kgs",
                DataBillingCurrency.Khr => "khr",
                DataBillingCurrency.Kmf => "kmf",
                DataBillingCurrency.Krw => "krw",
                DataBillingCurrency.Kyd => "kyd",
                DataBillingCurrency.Kzt => "kzt",
                DataBillingCurrency.Lbp => "lbp",
                DataBillingCurrency.Lkr => "lkr",
                DataBillingCurrency.Lrd => "lrd",
                DataBillingCurrency.Lsl => "lsl",
                DataBillingCurrency.Mad => "mad",
                DataBillingCurrency.Mdl => "mdl",
                DataBillingCurrency.Mga => "mga",
                DataBillingCurrency.Mkd => "mkd",
                DataBillingCurrency.Mmk => "mmk",
                DataBillingCurrency.Mnt => "mnt",
                DataBillingCurrency.Mop => "mop",
                DataBillingCurrency.Mro => "mro",
                DataBillingCurrency.Mvr => "mvr",
                DataBillingCurrency.Mwk => "mwk",
                DataBillingCurrency.Mxn => "mxn",
                DataBillingCurrency.Myr => "myr",
                DataBillingCurrency.Mzn => "mzn",
                DataBillingCurrency.Nad => "nad",
                DataBillingCurrency.Ngn => "ngn",
                DataBillingCurrency.Nok => "nok",
                DataBillingCurrency.Npr => "npr",
                DataBillingCurrency.Nzd => "nzd",
                DataBillingCurrency.Pgk => "pgk",
                DataBillingCurrency.Php => "php",
                DataBillingCurrency.Pkr => "pkr",
                DataBillingCurrency.Pln => "pln",
                DataBillingCurrency.Qar => "qar",
                DataBillingCurrency.Ron => "ron",
                DataBillingCurrency.Rsd => "rsd",
                DataBillingCurrency.Rub => "rub",
                DataBillingCurrency.Rwf => "rwf",
                DataBillingCurrency.Sar => "sar",
                DataBillingCurrency.Sbd => "sbd",
                DataBillingCurrency.Scr => "scr",
                DataBillingCurrency.Sek => "sek",
                DataBillingCurrency.Sgd => "sgd",
                DataBillingCurrency.Sle => "sle",
                DataBillingCurrency.Sll => "sll",
                DataBillingCurrency.Sos => "sos",
                DataBillingCurrency.Szl => "szl",
                DataBillingCurrency.Thb => "thb",
                DataBillingCurrency.Tjs => "tjs",
                DataBillingCurrency.Top => "top",
                DataBillingCurrency.Try => "try",
                DataBillingCurrency.Ttd => "ttd",
                DataBillingCurrency.Tzs => "tzs",
                DataBillingCurrency.Uah => "uah",
                DataBillingCurrency.Uzs => "uzs",
                DataBillingCurrency.Vnd => "vnd",
                DataBillingCurrency.Vuv => "vuv",
                DataBillingCurrency.Wst => "wst",
                DataBillingCurrency.Xaf => "xaf",
                DataBillingCurrency.Xcd => "xcd",
                DataBillingCurrency.Yer => "yer",
                DataBillingCurrency.Zar => "zar",
                DataBillingCurrency.Zmw => "zmw",
                DataBillingCurrency.Clp => "clp",
                DataBillingCurrency.Djf => "djf",
                DataBillingCurrency.Gnf => "gnf",
                DataBillingCurrency.Ugx => "ugx",
                DataBillingCurrency.Pyg => "pyg",
                DataBillingCurrency.Xof => "xof",
                DataBillingCurrency.Xpf => "xpf",
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
    typeof(JsonModelConverter<DataDefaultPaymentMethod, DataDefaultPaymentMethodFromRaw>)
)]
public sealed record class DataDefaultPaymentMethod : JsonModel
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
    public required ApiEnum<string, DataDefaultPaymentMethodType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, DataDefaultPaymentMethodType>>(
                "type"
            );
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

    public DataDefaultPaymentMethod() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DataDefaultPaymentMethod(DataDefaultPaymentMethod dataDefaultPaymentMethod)
        : base(dataDefaultPaymentMethod) { }
#pragma warning restore CS8618

    public DataDefaultPaymentMethod(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DataDefaultPaymentMethod(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataDefaultPaymentMethodFromRaw.FromRawUnchecked"/>
    public static DataDefaultPaymentMethod FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataDefaultPaymentMethodFromRaw : IFromRawJson<DataDefaultPaymentMethod>
{
    /// <inheritdoc/>
    public DataDefaultPaymentMethod FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DataDefaultPaymentMethod.FromRawUnchecked(rawData);
}

/// <summary>
/// The default payment method type
/// </summary>
[JsonConverter(typeof(DataDefaultPaymentMethodTypeConverter))]
public enum DataDefaultPaymentMethodType
{
    Card,
    Bank,
    CashApp,
}

sealed class DataDefaultPaymentMethodTypeConverter : JsonConverter<DataDefaultPaymentMethodType>
{
    public override DataDefaultPaymentMethodType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "CARD" => DataDefaultPaymentMethodType.Card,
            "BANK" => DataDefaultPaymentMethodType.Bank,
            "CASH_APP" => DataDefaultPaymentMethodType.CashApp,
            _ => (DataDefaultPaymentMethodType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DataDefaultPaymentMethodType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DataDefaultPaymentMethodType.Card => "CARD",
                DataDefaultPaymentMethodType.Bank => "BANK",
                DataDefaultPaymentMethodType.CashApp => "CASH_APP",
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
[JsonConverter(typeof(JsonModelConverter<DataIntegration, DataIntegrationFromRaw>))]
public sealed record class DataIntegration : JsonModel
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
    public required ApiEnum<string, DataIntegrationVendorIdentifier> VendorIdentifier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, DataIntegrationVendorIdentifier>>(
                "vendorIdentifier"
            );
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

    public DataIntegration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DataIntegration(DataIntegration dataIntegration)
        : base(dataIntegration) { }
#pragma warning restore CS8618

    public DataIntegration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DataIntegration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataIntegrationFromRaw.FromRawUnchecked"/>
    public static DataIntegration FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataIntegrationFromRaw : IFromRawJson<DataIntegration>
{
    /// <inheritdoc/>
    public DataIntegration FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DataIntegration.FromRawUnchecked(rawData);
}

/// <summary>
/// The vendor identifier of integration
/// </summary>
[JsonConverter(typeof(DataIntegrationVendorIdentifierConverter))]
public enum DataIntegrationVendorIdentifier
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

sealed class DataIntegrationVendorIdentifierConverter
    : JsonConverter<DataIntegrationVendorIdentifier>
{
    public override DataIntegrationVendorIdentifier Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "AUTH0" => DataIntegrationVendorIdentifier.Auth0,
            "ZUORA" => DataIntegrationVendorIdentifier.Zuora,
            "STRIPE" => DataIntegrationVendorIdentifier.Stripe,
            "HUBSPOT" => DataIntegrationVendorIdentifier.Hubspot,
            "AWS_MARKETPLACE" => DataIntegrationVendorIdentifier.AwsMarketplace,
            "SNOWFLAKE" => DataIntegrationVendorIdentifier.Snowflake,
            "SALESFORCE" => DataIntegrationVendorIdentifier.Salesforce,
            "BIG_QUERY" => DataIntegrationVendorIdentifier.BigQuery,
            "OPEN_FGA" => DataIntegrationVendorIdentifier.OpenFga,
            "APP_STORE" => DataIntegrationVendorIdentifier.AppStore,
            _ => (DataIntegrationVendorIdentifier)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DataIntegrationVendorIdentifier value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DataIntegrationVendorIdentifier.Auth0 => "AUTH0",
                DataIntegrationVendorIdentifier.Zuora => "ZUORA",
                DataIntegrationVendorIdentifier.Stripe => "STRIPE",
                DataIntegrationVendorIdentifier.Hubspot => "HUBSPOT",
                DataIntegrationVendorIdentifier.AwsMarketplace => "AWS_MARKETPLACE",
                DataIntegrationVendorIdentifier.Snowflake => "SNOWFLAKE",
                DataIntegrationVendorIdentifier.Salesforce => "SALESFORCE",
                DataIntegrationVendorIdentifier.BigQuery => "BIG_QUERY",
                DataIntegrationVendorIdentifier.OpenFga => "OPEN_FGA",
                DataIntegrationVendorIdentifier.AppStore => "APP_STORE",
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
[JsonConverter(typeof(JsonModelConverter<DataPassthrough, DataPassthroughFromRaw>))]
public sealed record class DataPassthrough : JsonModel
{
    /// <summary>
    /// Stripe-specific billing fields for the customer.
    /// </summary>
    public DataPassthroughStripe? Stripe
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<DataPassthroughStripe>("stripe");
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
    public DataPassthroughZuora? Zuora
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<DataPassthroughZuora>("zuora");
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

    public DataPassthrough() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DataPassthrough(DataPassthrough dataPassthrough)
        : base(dataPassthrough) { }
#pragma warning restore CS8618

    public DataPassthrough(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DataPassthrough(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataPassthroughFromRaw.FromRawUnchecked"/>
    public static DataPassthrough FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataPassthroughFromRaw : IFromRawJson<DataPassthrough>
{
    /// <inheritdoc/>
    public DataPassthrough FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DataPassthrough.FromRawUnchecked(rawData);
}

/// <summary>
/// Stripe-specific billing fields for the customer.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DataPassthroughStripe, DataPassthroughStripeFromRaw>))]
public sealed record class DataPassthroughStripe : JsonModel
{
    /// <summary>
    /// Physical address
    /// </summary>
    public DataPassthroughStripeBillingAddress? BillingAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<DataPassthroughStripeBillingAddress>(
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
    public DataPassthroughStripeShippingAddress? ShippingAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<DataPassthroughStripeShippingAddress>(
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
    public IReadOnlyList<DataPassthroughStripeTaxID>? TaxIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<DataPassthroughStripeTaxID>>(
                "taxIds"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<DataPassthroughStripeTaxID>?>(
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

    public DataPassthroughStripe() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DataPassthroughStripe(DataPassthroughStripe dataPassthroughStripe)
        : base(dataPassthroughStripe) { }
#pragma warning restore CS8618

    public DataPassthroughStripe(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DataPassthroughStripe(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataPassthroughStripeFromRaw.FromRawUnchecked"/>
    public static DataPassthroughStripe FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataPassthroughStripeFromRaw : IFromRawJson<DataPassthroughStripe>
{
    /// <inheritdoc/>
    public DataPassthroughStripe FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DataPassthroughStripe.FromRawUnchecked(rawData);
}

/// <summary>
/// Physical address
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        DataPassthroughStripeBillingAddress,
        DataPassthroughStripeBillingAddressFromRaw
    >)
)]
public sealed record class DataPassthroughStripeBillingAddress : JsonModel
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

    public DataPassthroughStripeBillingAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DataPassthroughStripeBillingAddress(
        DataPassthroughStripeBillingAddress dataPassthroughStripeBillingAddress
    )
        : base(dataPassthroughStripeBillingAddress) { }
#pragma warning restore CS8618

    public DataPassthroughStripeBillingAddress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DataPassthroughStripeBillingAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataPassthroughStripeBillingAddressFromRaw.FromRawUnchecked"/>
    public static DataPassthroughStripeBillingAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataPassthroughStripeBillingAddressFromRaw : IFromRawJson<DataPassthroughStripeBillingAddress>
{
    /// <inheritdoc/>
    public DataPassthroughStripeBillingAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DataPassthroughStripeBillingAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// Physical address
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        DataPassthroughStripeShippingAddress,
        DataPassthroughStripeShippingAddressFromRaw
    >)
)]
public sealed record class DataPassthroughStripeShippingAddress : JsonModel
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

    public DataPassthroughStripeShippingAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DataPassthroughStripeShippingAddress(
        DataPassthroughStripeShippingAddress dataPassthroughStripeShippingAddress
    )
        : base(dataPassthroughStripeShippingAddress) { }
#pragma warning restore CS8618

    public DataPassthroughStripeShippingAddress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DataPassthroughStripeShippingAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataPassthroughStripeShippingAddressFromRaw.FromRawUnchecked"/>
    public static DataPassthroughStripeShippingAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataPassthroughStripeShippingAddressFromRaw
    : IFromRawJson<DataPassthroughStripeShippingAddress>
{
    /// <inheritdoc/>
    public DataPassthroughStripeShippingAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DataPassthroughStripeShippingAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// Tax identifier with type and value for customer tax exemptions.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<DataPassthroughStripeTaxID, DataPassthroughStripeTaxIDFromRaw>)
)]
public sealed record class DataPassthroughStripeTaxID : JsonModel
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

    public DataPassthroughStripeTaxID() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DataPassthroughStripeTaxID(DataPassthroughStripeTaxID dataPassthroughStripeTaxID)
        : base(dataPassthroughStripeTaxID) { }
#pragma warning restore CS8618

    public DataPassthroughStripeTaxID(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DataPassthroughStripeTaxID(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataPassthroughStripeTaxIDFromRaw.FromRawUnchecked"/>
    public static DataPassthroughStripeTaxID FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataPassthroughStripeTaxIDFromRaw : IFromRawJson<DataPassthroughStripeTaxID>
{
    /// <inheritdoc/>
    public DataPassthroughStripeTaxID FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DataPassthroughStripeTaxID.FromRawUnchecked(rawData);
}

/// <summary>
/// Zuora-specific billing fields for the customer.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DataPassthroughZuora, DataPassthroughZuoraFromRaw>))]
public sealed record class DataPassthroughZuora : JsonModel
{
    /// <summary>
    /// Physical address
    /// </summary>
    public DataPassthroughZuoraBillingAddress? BillingAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<DataPassthroughZuoraBillingAddress>(
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
    public ApiEnum<string, DataPassthroughZuoraCurrency>? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, DataPassthroughZuoraCurrency>>(
                "currency"
            );
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

    public DataPassthroughZuora() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DataPassthroughZuora(DataPassthroughZuora dataPassthroughZuora)
        : base(dataPassthroughZuora) { }
#pragma warning restore CS8618

    public DataPassthroughZuora(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DataPassthroughZuora(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataPassthroughZuoraFromRaw.FromRawUnchecked"/>
    public static DataPassthroughZuora FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataPassthroughZuoraFromRaw : IFromRawJson<DataPassthroughZuora>
{
    /// <inheritdoc/>
    public DataPassthroughZuora FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DataPassthroughZuora.FromRawUnchecked(rawData);
}

/// <summary>
/// Physical address
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        DataPassthroughZuoraBillingAddress,
        DataPassthroughZuoraBillingAddressFromRaw
    >)
)]
public sealed record class DataPassthroughZuoraBillingAddress : JsonModel
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

    public DataPassthroughZuoraBillingAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DataPassthroughZuoraBillingAddress(
        DataPassthroughZuoraBillingAddress dataPassthroughZuoraBillingAddress
    )
        : base(dataPassthroughZuoraBillingAddress) { }
#pragma warning restore CS8618

    public DataPassthroughZuoraBillingAddress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DataPassthroughZuoraBillingAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataPassthroughZuoraBillingAddressFromRaw.FromRawUnchecked"/>
    public static DataPassthroughZuoraBillingAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataPassthroughZuoraBillingAddressFromRaw : IFromRawJson<DataPassthroughZuoraBillingAddress>
{
    /// <inheritdoc/>
    public DataPassthroughZuoraBillingAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DataPassthroughZuoraBillingAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// Customers selected currency
/// </summary>
[JsonConverter(typeof(DataPassthroughZuoraCurrencyConverter))]
public enum DataPassthroughZuoraCurrency
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

sealed class DataPassthroughZuoraCurrencyConverter : JsonConverter<DataPassthroughZuoraCurrency>
{
    public override DataPassthroughZuoraCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => DataPassthroughZuoraCurrency.Usd,
            "aed" => DataPassthroughZuoraCurrency.Aed,
            "all" => DataPassthroughZuoraCurrency.All,
            "amd" => DataPassthroughZuoraCurrency.Amd,
            "ang" => DataPassthroughZuoraCurrency.Ang,
            "aud" => DataPassthroughZuoraCurrency.Aud,
            "awg" => DataPassthroughZuoraCurrency.Awg,
            "azn" => DataPassthroughZuoraCurrency.Azn,
            "bam" => DataPassthroughZuoraCurrency.Bam,
            "bbd" => DataPassthroughZuoraCurrency.Bbd,
            "bdt" => DataPassthroughZuoraCurrency.Bdt,
            "bgn" => DataPassthroughZuoraCurrency.Bgn,
            "bif" => DataPassthroughZuoraCurrency.Bif,
            "bmd" => DataPassthroughZuoraCurrency.Bmd,
            "bnd" => DataPassthroughZuoraCurrency.Bnd,
            "bsd" => DataPassthroughZuoraCurrency.Bsd,
            "bwp" => DataPassthroughZuoraCurrency.Bwp,
            "byn" => DataPassthroughZuoraCurrency.Byn,
            "bzd" => DataPassthroughZuoraCurrency.Bzd,
            "brl" => DataPassthroughZuoraCurrency.Brl,
            "cad" => DataPassthroughZuoraCurrency.Cad,
            "cdf" => DataPassthroughZuoraCurrency.Cdf,
            "chf" => DataPassthroughZuoraCurrency.Chf,
            "cny" => DataPassthroughZuoraCurrency.Cny,
            "czk" => DataPassthroughZuoraCurrency.Czk,
            "dkk" => DataPassthroughZuoraCurrency.Dkk,
            "dop" => DataPassthroughZuoraCurrency.Dop,
            "dzd" => DataPassthroughZuoraCurrency.Dzd,
            "egp" => DataPassthroughZuoraCurrency.Egp,
            "etb" => DataPassthroughZuoraCurrency.Etb,
            "eur" => DataPassthroughZuoraCurrency.Eur,
            "fjd" => DataPassthroughZuoraCurrency.Fjd,
            "gbp" => DataPassthroughZuoraCurrency.Gbp,
            "gel" => DataPassthroughZuoraCurrency.Gel,
            "gip" => DataPassthroughZuoraCurrency.Gip,
            "gmd" => DataPassthroughZuoraCurrency.Gmd,
            "gyd" => DataPassthroughZuoraCurrency.Gyd,
            "hkd" => DataPassthroughZuoraCurrency.Hkd,
            "hrk" => DataPassthroughZuoraCurrency.Hrk,
            "htg" => DataPassthroughZuoraCurrency.Htg,
            "idr" => DataPassthroughZuoraCurrency.Idr,
            "ils" => DataPassthroughZuoraCurrency.Ils,
            "inr" => DataPassthroughZuoraCurrency.Inr,
            "isk" => DataPassthroughZuoraCurrency.Isk,
            "jmd" => DataPassthroughZuoraCurrency.Jmd,
            "jpy" => DataPassthroughZuoraCurrency.Jpy,
            "kes" => DataPassthroughZuoraCurrency.Kes,
            "kgs" => DataPassthroughZuoraCurrency.Kgs,
            "khr" => DataPassthroughZuoraCurrency.Khr,
            "kmf" => DataPassthroughZuoraCurrency.Kmf,
            "krw" => DataPassthroughZuoraCurrency.Krw,
            "kyd" => DataPassthroughZuoraCurrency.Kyd,
            "kzt" => DataPassthroughZuoraCurrency.Kzt,
            "lbp" => DataPassthroughZuoraCurrency.Lbp,
            "lkr" => DataPassthroughZuoraCurrency.Lkr,
            "lrd" => DataPassthroughZuoraCurrency.Lrd,
            "lsl" => DataPassthroughZuoraCurrency.Lsl,
            "mad" => DataPassthroughZuoraCurrency.Mad,
            "mdl" => DataPassthroughZuoraCurrency.Mdl,
            "mga" => DataPassthroughZuoraCurrency.Mga,
            "mkd" => DataPassthroughZuoraCurrency.Mkd,
            "mmk" => DataPassthroughZuoraCurrency.Mmk,
            "mnt" => DataPassthroughZuoraCurrency.Mnt,
            "mop" => DataPassthroughZuoraCurrency.Mop,
            "mro" => DataPassthroughZuoraCurrency.Mro,
            "mvr" => DataPassthroughZuoraCurrency.Mvr,
            "mwk" => DataPassthroughZuoraCurrency.Mwk,
            "mxn" => DataPassthroughZuoraCurrency.Mxn,
            "myr" => DataPassthroughZuoraCurrency.Myr,
            "mzn" => DataPassthroughZuoraCurrency.Mzn,
            "nad" => DataPassthroughZuoraCurrency.Nad,
            "ngn" => DataPassthroughZuoraCurrency.Ngn,
            "nok" => DataPassthroughZuoraCurrency.Nok,
            "npr" => DataPassthroughZuoraCurrency.Npr,
            "nzd" => DataPassthroughZuoraCurrency.Nzd,
            "pgk" => DataPassthroughZuoraCurrency.Pgk,
            "php" => DataPassthroughZuoraCurrency.Php,
            "pkr" => DataPassthroughZuoraCurrency.Pkr,
            "pln" => DataPassthroughZuoraCurrency.Pln,
            "qar" => DataPassthroughZuoraCurrency.Qar,
            "ron" => DataPassthroughZuoraCurrency.Ron,
            "rsd" => DataPassthroughZuoraCurrency.Rsd,
            "rub" => DataPassthroughZuoraCurrency.Rub,
            "rwf" => DataPassthroughZuoraCurrency.Rwf,
            "sar" => DataPassthroughZuoraCurrency.Sar,
            "sbd" => DataPassthroughZuoraCurrency.Sbd,
            "scr" => DataPassthroughZuoraCurrency.Scr,
            "sek" => DataPassthroughZuoraCurrency.Sek,
            "sgd" => DataPassthroughZuoraCurrency.Sgd,
            "sle" => DataPassthroughZuoraCurrency.Sle,
            "sll" => DataPassthroughZuoraCurrency.Sll,
            "sos" => DataPassthroughZuoraCurrency.Sos,
            "szl" => DataPassthroughZuoraCurrency.Szl,
            "thb" => DataPassthroughZuoraCurrency.Thb,
            "tjs" => DataPassthroughZuoraCurrency.Tjs,
            "top" => DataPassthroughZuoraCurrency.Top,
            "try" => DataPassthroughZuoraCurrency.Try,
            "ttd" => DataPassthroughZuoraCurrency.Ttd,
            "tzs" => DataPassthroughZuoraCurrency.Tzs,
            "uah" => DataPassthroughZuoraCurrency.Uah,
            "uzs" => DataPassthroughZuoraCurrency.Uzs,
            "vnd" => DataPassthroughZuoraCurrency.Vnd,
            "vuv" => DataPassthroughZuoraCurrency.Vuv,
            "wst" => DataPassthroughZuoraCurrency.Wst,
            "xaf" => DataPassthroughZuoraCurrency.Xaf,
            "xcd" => DataPassthroughZuoraCurrency.Xcd,
            "yer" => DataPassthroughZuoraCurrency.Yer,
            "zar" => DataPassthroughZuoraCurrency.Zar,
            "zmw" => DataPassthroughZuoraCurrency.Zmw,
            "clp" => DataPassthroughZuoraCurrency.Clp,
            "djf" => DataPassthroughZuoraCurrency.Djf,
            "gnf" => DataPassthroughZuoraCurrency.Gnf,
            "ugx" => DataPassthroughZuoraCurrency.Ugx,
            "pyg" => DataPassthroughZuoraCurrency.Pyg,
            "xof" => DataPassthroughZuoraCurrency.Xof,
            "xpf" => DataPassthroughZuoraCurrency.Xpf,
            _ => (DataPassthroughZuoraCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DataPassthroughZuoraCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DataPassthroughZuoraCurrency.Usd => "usd",
                DataPassthroughZuoraCurrency.Aed => "aed",
                DataPassthroughZuoraCurrency.All => "all",
                DataPassthroughZuoraCurrency.Amd => "amd",
                DataPassthroughZuoraCurrency.Ang => "ang",
                DataPassthroughZuoraCurrency.Aud => "aud",
                DataPassthroughZuoraCurrency.Awg => "awg",
                DataPassthroughZuoraCurrency.Azn => "azn",
                DataPassthroughZuoraCurrency.Bam => "bam",
                DataPassthroughZuoraCurrency.Bbd => "bbd",
                DataPassthroughZuoraCurrency.Bdt => "bdt",
                DataPassthroughZuoraCurrency.Bgn => "bgn",
                DataPassthroughZuoraCurrency.Bif => "bif",
                DataPassthroughZuoraCurrency.Bmd => "bmd",
                DataPassthroughZuoraCurrency.Bnd => "bnd",
                DataPassthroughZuoraCurrency.Bsd => "bsd",
                DataPassthroughZuoraCurrency.Bwp => "bwp",
                DataPassthroughZuoraCurrency.Byn => "byn",
                DataPassthroughZuoraCurrency.Bzd => "bzd",
                DataPassthroughZuoraCurrency.Brl => "brl",
                DataPassthroughZuoraCurrency.Cad => "cad",
                DataPassthroughZuoraCurrency.Cdf => "cdf",
                DataPassthroughZuoraCurrency.Chf => "chf",
                DataPassthroughZuoraCurrency.Cny => "cny",
                DataPassthroughZuoraCurrency.Czk => "czk",
                DataPassthroughZuoraCurrency.Dkk => "dkk",
                DataPassthroughZuoraCurrency.Dop => "dop",
                DataPassthroughZuoraCurrency.Dzd => "dzd",
                DataPassthroughZuoraCurrency.Egp => "egp",
                DataPassthroughZuoraCurrency.Etb => "etb",
                DataPassthroughZuoraCurrency.Eur => "eur",
                DataPassthroughZuoraCurrency.Fjd => "fjd",
                DataPassthroughZuoraCurrency.Gbp => "gbp",
                DataPassthroughZuoraCurrency.Gel => "gel",
                DataPassthroughZuoraCurrency.Gip => "gip",
                DataPassthroughZuoraCurrency.Gmd => "gmd",
                DataPassthroughZuoraCurrency.Gyd => "gyd",
                DataPassthroughZuoraCurrency.Hkd => "hkd",
                DataPassthroughZuoraCurrency.Hrk => "hrk",
                DataPassthroughZuoraCurrency.Htg => "htg",
                DataPassthroughZuoraCurrency.Idr => "idr",
                DataPassthroughZuoraCurrency.Ils => "ils",
                DataPassthroughZuoraCurrency.Inr => "inr",
                DataPassthroughZuoraCurrency.Isk => "isk",
                DataPassthroughZuoraCurrency.Jmd => "jmd",
                DataPassthroughZuoraCurrency.Jpy => "jpy",
                DataPassthroughZuoraCurrency.Kes => "kes",
                DataPassthroughZuoraCurrency.Kgs => "kgs",
                DataPassthroughZuoraCurrency.Khr => "khr",
                DataPassthroughZuoraCurrency.Kmf => "kmf",
                DataPassthroughZuoraCurrency.Krw => "krw",
                DataPassthroughZuoraCurrency.Kyd => "kyd",
                DataPassthroughZuoraCurrency.Kzt => "kzt",
                DataPassthroughZuoraCurrency.Lbp => "lbp",
                DataPassthroughZuoraCurrency.Lkr => "lkr",
                DataPassthroughZuoraCurrency.Lrd => "lrd",
                DataPassthroughZuoraCurrency.Lsl => "lsl",
                DataPassthroughZuoraCurrency.Mad => "mad",
                DataPassthroughZuoraCurrency.Mdl => "mdl",
                DataPassthroughZuoraCurrency.Mga => "mga",
                DataPassthroughZuoraCurrency.Mkd => "mkd",
                DataPassthroughZuoraCurrency.Mmk => "mmk",
                DataPassthroughZuoraCurrency.Mnt => "mnt",
                DataPassthroughZuoraCurrency.Mop => "mop",
                DataPassthroughZuoraCurrency.Mro => "mro",
                DataPassthroughZuoraCurrency.Mvr => "mvr",
                DataPassthroughZuoraCurrency.Mwk => "mwk",
                DataPassthroughZuoraCurrency.Mxn => "mxn",
                DataPassthroughZuoraCurrency.Myr => "myr",
                DataPassthroughZuoraCurrency.Mzn => "mzn",
                DataPassthroughZuoraCurrency.Nad => "nad",
                DataPassthroughZuoraCurrency.Ngn => "ngn",
                DataPassthroughZuoraCurrency.Nok => "nok",
                DataPassthroughZuoraCurrency.Npr => "npr",
                DataPassthroughZuoraCurrency.Nzd => "nzd",
                DataPassthroughZuoraCurrency.Pgk => "pgk",
                DataPassthroughZuoraCurrency.Php => "php",
                DataPassthroughZuoraCurrency.Pkr => "pkr",
                DataPassthroughZuoraCurrency.Pln => "pln",
                DataPassthroughZuoraCurrency.Qar => "qar",
                DataPassthroughZuoraCurrency.Ron => "ron",
                DataPassthroughZuoraCurrency.Rsd => "rsd",
                DataPassthroughZuoraCurrency.Rub => "rub",
                DataPassthroughZuoraCurrency.Rwf => "rwf",
                DataPassthroughZuoraCurrency.Sar => "sar",
                DataPassthroughZuoraCurrency.Sbd => "sbd",
                DataPassthroughZuoraCurrency.Scr => "scr",
                DataPassthroughZuoraCurrency.Sek => "sek",
                DataPassthroughZuoraCurrency.Sgd => "sgd",
                DataPassthroughZuoraCurrency.Sle => "sle",
                DataPassthroughZuoraCurrency.Sll => "sll",
                DataPassthroughZuoraCurrency.Sos => "sos",
                DataPassthroughZuoraCurrency.Szl => "szl",
                DataPassthroughZuoraCurrency.Thb => "thb",
                DataPassthroughZuoraCurrency.Tjs => "tjs",
                DataPassthroughZuoraCurrency.Top => "top",
                DataPassthroughZuoraCurrency.Try => "try",
                DataPassthroughZuoraCurrency.Ttd => "ttd",
                DataPassthroughZuoraCurrency.Tzs => "tzs",
                DataPassthroughZuoraCurrency.Uah => "uah",
                DataPassthroughZuoraCurrency.Uzs => "uzs",
                DataPassthroughZuoraCurrency.Vnd => "vnd",
                DataPassthroughZuoraCurrency.Vuv => "vuv",
                DataPassthroughZuoraCurrency.Wst => "wst",
                DataPassthroughZuoraCurrency.Xaf => "xaf",
                DataPassthroughZuoraCurrency.Xcd => "xcd",
                DataPassthroughZuoraCurrency.Yer => "yer",
                DataPassthroughZuoraCurrency.Zar => "zar",
                DataPassthroughZuoraCurrency.Zmw => "zmw",
                DataPassthroughZuoraCurrency.Clp => "clp",
                DataPassthroughZuoraCurrency.Djf => "djf",
                DataPassthroughZuoraCurrency.Gnf => "gnf",
                DataPassthroughZuoraCurrency.Ugx => "ugx",
                DataPassthroughZuoraCurrency.Pyg => "pyg",
                DataPassthroughZuoraCurrency.Xof => "xof",
                DataPassthroughZuoraCurrency.Xpf => "xpf",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
