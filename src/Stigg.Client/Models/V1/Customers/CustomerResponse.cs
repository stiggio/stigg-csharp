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
        _ = this.Metadata;
        _ = this.Name;
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
