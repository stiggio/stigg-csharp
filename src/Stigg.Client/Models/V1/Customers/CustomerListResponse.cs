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
/// A customer can be either an organization or an individual
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CustomerListResponse, CustomerListResponseFromRaw>))]
public sealed record class CustomerListResponse : JsonModel
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
    public ApiEnum<string, CustomerListResponseBillingCurrency>? BillingCurrency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, CustomerListResponseBillingCurrency>
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
    public CustomerListResponseDefaultPaymentMethod? DefaultPaymentMethod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CustomerListResponseDefaultPaymentMethod>(
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
    public IReadOnlyList<CustomerListResponseIntegration>? Integrations
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<CustomerListResponseIntegration>>(
                "integrations"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<CustomerListResponseIntegration>?>(
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

    public CustomerListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerListResponse(CustomerListResponse customerListResponse)
        : base(customerListResponse) { }
#pragma warning restore CS8618

    public CustomerListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerListResponseFromRaw.FromRawUnchecked"/>
    public static CustomerListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerListResponseFromRaw : IFromRawJson<CustomerListResponse>
{
    /// <inheritdoc/>
    public CustomerListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerListResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// The billing currency of the customer
/// </summary>
[JsonConverter(typeof(CustomerListResponseBillingCurrencyConverter))]
public enum CustomerListResponseBillingCurrency
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

sealed class CustomerListResponseBillingCurrencyConverter
    : JsonConverter<CustomerListResponseBillingCurrency>
{
    public override CustomerListResponseBillingCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => CustomerListResponseBillingCurrency.Usd,
            "aed" => CustomerListResponseBillingCurrency.Aed,
            "all" => CustomerListResponseBillingCurrency.All,
            "amd" => CustomerListResponseBillingCurrency.Amd,
            "ang" => CustomerListResponseBillingCurrency.Ang,
            "aud" => CustomerListResponseBillingCurrency.Aud,
            "awg" => CustomerListResponseBillingCurrency.Awg,
            "azn" => CustomerListResponseBillingCurrency.Azn,
            "bam" => CustomerListResponseBillingCurrency.Bam,
            "bbd" => CustomerListResponseBillingCurrency.Bbd,
            "bdt" => CustomerListResponseBillingCurrency.Bdt,
            "bgn" => CustomerListResponseBillingCurrency.Bgn,
            "bif" => CustomerListResponseBillingCurrency.Bif,
            "bmd" => CustomerListResponseBillingCurrency.Bmd,
            "bnd" => CustomerListResponseBillingCurrency.Bnd,
            "bsd" => CustomerListResponseBillingCurrency.Bsd,
            "bwp" => CustomerListResponseBillingCurrency.Bwp,
            "byn" => CustomerListResponseBillingCurrency.Byn,
            "bzd" => CustomerListResponseBillingCurrency.Bzd,
            "brl" => CustomerListResponseBillingCurrency.Brl,
            "cad" => CustomerListResponseBillingCurrency.Cad,
            "cdf" => CustomerListResponseBillingCurrency.Cdf,
            "chf" => CustomerListResponseBillingCurrency.Chf,
            "cny" => CustomerListResponseBillingCurrency.Cny,
            "czk" => CustomerListResponseBillingCurrency.Czk,
            "dkk" => CustomerListResponseBillingCurrency.Dkk,
            "dop" => CustomerListResponseBillingCurrency.Dop,
            "dzd" => CustomerListResponseBillingCurrency.Dzd,
            "egp" => CustomerListResponseBillingCurrency.Egp,
            "etb" => CustomerListResponseBillingCurrency.Etb,
            "eur" => CustomerListResponseBillingCurrency.Eur,
            "fjd" => CustomerListResponseBillingCurrency.Fjd,
            "gbp" => CustomerListResponseBillingCurrency.Gbp,
            "gel" => CustomerListResponseBillingCurrency.Gel,
            "gip" => CustomerListResponseBillingCurrency.Gip,
            "gmd" => CustomerListResponseBillingCurrency.Gmd,
            "gyd" => CustomerListResponseBillingCurrency.Gyd,
            "hkd" => CustomerListResponseBillingCurrency.Hkd,
            "hrk" => CustomerListResponseBillingCurrency.Hrk,
            "htg" => CustomerListResponseBillingCurrency.Htg,
            "idr" => CustomerListResponseBillingCurrency.Idr,
            "ils" => CustomerListResponseBillingCurrency.Ils,
            "inr" => CustomerListResponseBillingCurrency.Inr,
            "isk" => CustomerListResponseBillingCurrency.Isk,
            "jmd" => CustomerListResponseBillingCurrency.Jmd,
            "jpy" => CustomerListResponseBillingCurrency.Jpy,
            "kes" => CustomerListResponseBillingCurrency.Kes,
            "kgs" => CustomerListResponseBillingCurrency.Kgs,
            "khr" => CustomerListResponseBillingCurrency.Khr,
            "kmf" => CustomerListResponseBillingCurrency.Kmf,
            "krw" => CustomerListResponseBillingCurrency.Krw,
            "kyd" => CustomerListResponseBillingCurrency.Kyd,
            "kzt" => CustomerListResponseBillingCurrency.Kzt,
            "lbp" => CustomerListResponseBillingCurrency.Lbp,
            "lkr" => CustomerListResponseBillingCurrency.Lkr,
            "lrd" => CustomerListResponseBillingCurrency.Lrd,
            "lsl" => CustomerListResponseBillingCurrency.Lsl,
            "mad" => CustomerListResponseBillingCurrency.Mad,
            "mdl" => CustomerListResponseBillingCurrency.Mdl,
            "mga" => CustomerListResponseBillingCurrency.Mga,
            "mkd" => CustomerListResponseBillingCurrency.Mkd,
            "mmk" => CustomerListResponseBillingCurrency.Mmk,
            "mnt" => CustomerListResponseBillingCurrency.Mnt,
            "mop" => CustomerListResponseBillingCurrency.Mop,
            "mro" => CustomerListResponseBillingCurrency.Mro,
            "mvr" => CustomerListResponseBillingCurrency.Mvr,
            "mwk" => CustomerListResponseBillingCurrency.Mwk,
            "mxn" => CustomerListResponseBillingCurrency.Mxn,
            "myr" => CustomerListResponseBillingCurrency.Myr,
            "mzn" => CustomerListResponseBillingCurrency.Mzn,
            "nad" => CustomerListResponseBillingCurrency.Nad,
            "ngn" => CustomerListResponseBillingCurrency.Ngn,
            "nok" => CustomerListResponseBillingCurrency.Nok,
            "npr" => CustomerListResponseBillingCurrency.Npr,
            "nzd" => CustomerListResponseBillingCurrency.Nzd,
            "pgk" => CustomerListResponseBillingCurrency.Pgk,
            "php" => CustomerListResponseBillingCurrency.Php,
            "pkr" => CustomerListResponseBillingCurrency.Pkr,
            "pln" => CustomerListResponseBillingCurrency.Pln,
            "qar" => CustomerListResponseBillingCurrency.Qar,
            "ron" => CustomerListResponseBillingCurrency.Ron,
            "rsd" => CustomerListResponseBillingCurrency.Rsd,
            "rub" => CustomerListResponseBillingCurrency.Rub,
            "rwf" => CustomerListResponseBillingCurrency.Rwf,
            "sar" => CustomerListResponseBillingCurrency.Sar,
            "sbd" => CustomerListResponseBillingCurrency.Sbd,
            "scr" => CustomerListResponseBillingCurrency.Scr,
            "sek" => CustomerListResponseBillingCurrency.Sek,
            "sgd" => CustomerListResponseBillingCurrency.Sgd,
            "sle" => CustomerListResponseBillingCurrency.Sle,
            "sll" => CustomerListResponseBillingCurrency.Sll,
            "sos" => CustomerListResponseBillingCurrency.Sos,
            "szl" => CustomerListResponseBillingCurrency.Szl,
            "thb" => CustomerListResponseBillingCurrency.Thb,
            "tjs" => CustomerListResponseBillingCurrency.Tjs,
            "top" => CustomerListResponseBillingCurrency.Top,
            "try" => CustomerListResponseBillingCurrency.Try,
            "ttd" => CustomerListResponseBillingCurrency.Ttd,
            "tzs" => CustomerListResponseBillingCurrency.Tzs,
            "uah" => CustomerListResponseBillingCurrency.Uah,
            "uzs" => CustomerListResponseBillingCurrency.Uzs,
            "vnd" => CustomerListResponseBillingCurrency.Vnd,
            "vuv" => CustomerListResponseBillingCurrency.Vuv,
            "wst" => CustomerListResponseBillingCurrency.Wst,
            "xaf" => CustomerListResponseBillingCurrency.Xaf,
            "xcd" => CustomerListResponseBillingCurrency.Xcd,
            "yer" => CustomerListResponseBillingCurrency.Yer,
            "zar" => CustomerListResponseBillingCurrency.Zar,
            "zmw" => CustomerListResponseBillingCurrency.Zmw,
            "clp" => CustomerListResponseBillingCurrency.Clp,
            "djf" => CustomerListResponseBillingCurrency.Djf,
            "gnf" => CustomerListResponseBillingCurrency.Gnf,
            "ugx" => CustomerListResponseBillingCurrency.Ugx,
            "pyg" => CustomerListResponseBillingCurrency.Pyg,
            "xof" => CustomerListResponseBillingCurrency.Xof,
            "xpf" => CustomerListResponseBillingCurrency.Xpf,
            _ => (CustomerListResponseBillingCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CustomerListResponseBillingCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CustomerListResponseBillingCurrency.Usd => "usd",
                CustomerListResponseBillingCurrency.Aed => "aed",
                CustomerListResponseBillingCurrency.All => "all",
                CustomerListResponseBillingCurrency.Amd => "amd",
                CustomerListResponseBillingCurrency.Ang => "ang",
                CustomerListResponseBillingCurrency.Aud => "aud",
                CustomerListResponseBillingCurrency.Awg => "awg",
                CustomerListResponseBillingCurrency.Azn => "azn",
                CustomerListResponseBillingCurrency.Bam => "bam",
                CustomerListResponseBillingCurrency.Bbd => "bbd",
                CustomerListResponseBillingCurrency.Bdt => "bdt",
                CustomerListResponseBillingCurrency.Bgn => "bgn",
                CustomerListResponseBillingCurrency.Bif => "bif",
                CustomerListResponseBillingCurrency.Bmd => "bmd",
                CustomerListResponseBillingCurrency.Bnd => "bnd",
                CustomerListResponseBillingCurrency.Bsd => "bsd",
                CustomerListResponseBillingCurrency.Bwp => "bwp",
                CustomerListResponseBillingCurrency.Byn => "byn",
                CustomerListResponseBillingCurrency.Bzd => "bzd",
                CustomerListResponseBillingCurrency.Brl => "brl",
                CustomerListResponseBillingCurrency.Cad => "cad",
                CustomerListResponseBillingCurrency.Cdf => "cdf",
                CustomerListResponseBillingCurrency.Chf => "chf",
                CustomerListResponseBillingCurrency.Cny => "cny",
                CustomerListResponseBillingCurrency.Czk => "czk",
                CustomerListResponseBillingCurrency.Dkk => "dkk",
                CustomerListResponseBillingCurrency.Dop => "dop",
                CustomerListResponseBillingCurrency.Dzd => "dzd",
                CustomerListResponseBillingCurrency.Egp => "egp",
                CustomerListResponseBillingCurrency.Etb => "etb",
                CustomerListResponseBillingCurrency.Eur => "eur",
                CustomerListResponseBillingCurrency.Fjd => "fjd",
                CustomerListResponseBillingCurrency.Gbp => "gbp",
                CustomerListResponseBillingCurrency.Gel => "gel",
                CustomerListResponseBillingCurrency.Gip => "gip",
                CustomerListResponseBillingCurrency.Gmd => "gmd",
                CustomerListResponseBillingCurrency.Gyd => "gyd",
                CustomerListResponseBillingCurrency.Hkd => "hkd",
                CustomerListResponseBillingCurrency.Hrk => "hrk",
                CustomerListResponseBillingCurrency.Htg => "htg",
                CustomerListResponseBillingCurrency.Idr => "idr",
                CustomerListResponseBillingCurrency.Ils => "ils",
                CustomerListResponseBillingCurrency.Inr => "inr",
                CustomerListResponseBillingCurrency.Isk => "isk",
                CustomerListResponseBillingCurrency.Jmd => "jmd",
                CustomerListResponseBillingCurrency.Jpy => "jpy",
                CustomerListResponseBillingCurrency.Kes => "kes",
                CustomerListResponseBillingCurrency.Kgs => "kgs",
                CustomerListResponseBillingCurrency.Khr => "khr",
                CustomerListResponseBillingCurrency.Kmf => "kmf",
                CustomerListResponseBillingCurrency.Krw => "krw",
                CustomerListResponseBillingCurrency.Kyd => "kyd",
                CustomerListResponseBillingCurrency.Kzt => "kzt",
                CustomerListResponseBillingCurrency.Lbp => "lbp",
                CustomerListResponseBillingCurrency.Lkr => "lkr",
                CustomerListResponseBillingCurrency.Lrd => "lrd",
                CustomerListResponseBillingCurrency.Lsl => "lsl",
                CustomerListResponseBillingCurrency.Mad => "mad",
                CustomerListResponseBillingCurrency.Mdl => "mdl",
                CustomerListResponseBillingCurrency.Mga => "mga",
                CustomerListResponseBillingCurrency.Mkd => "mkd",
                CustomerListResponseBillingCurrency.Mmk => "mmk",
                CustomerListResponseBillingCurrency.Mnt => "mnt",
                CustomerListResponseBillingCurrency.Mop => "mop",
                CustomerListResponseBillingCurrency.Mro => "mro",
                CustomerListResponseBillingCurrency.Mvr => "mvr",
                CustomerListResponseBillingCurrency.Mwk => "mwk",
                CustomerListResponseBillingCurrency.Mxn => "mxn",
                CustomerListResponseBillingCurrency.Myr => "myr",
                CustomerListResponseBillingCurrency.Mzn => "mzn",
                CustomerListResponseBillingCurrency.Nad => "nad",
                CustomerListResponseBillingCurrency.Ngn => "ngn",
                CustomerListResponseBillingCurrency.Nok => "nok",
                CustomerListResponseBillingCurrency.Npr => "npr",
                CustomerListResponseBillingCurrency.Nzd => "nzd",
                CustomerListResponseBillingCurrency.Pgk => "pgk",
                CustomerListResponseBillingCurrency.Php => "php",
                CustomerListResponseBillingCurrency.Pkr => "pkr",
                CustomerListResponseBillingCurrency.Pln => "pln",
                CustomerListResponseBillingCurrency.Qar => "qar",
                CustomerListResponseBillingCurrency.Ron => "ron",
                CustomerListResponseBillingCurrency.Rsd => "rsd",
                CustomerListResponseBillingCurrency.Rub => "rub",
                CustomerListResponseBillingCurrency.Rwf => "rwf",
                CustomerListResponseBillingCurrency.Sar => "sar",
                CustomerListResponseBillingCurrency.Sbd => "sbd",
                CustomerListResponseBillingCurrency.Scr => "scr",
                CustomerListResponseBillingCurrency.Sek => "sek",
                CustomerListResponseBillingCurrency.Sgd => "sgd",
                CustomerListResponseBillingCurrency.Sle => "sle",
                CustomerListResponseBillingCurrency.Sll => "sll",
                CustomerListResponseBillingCurrency.Sos => "sos",
                CustomerListResponseBillingCurrency.Szl => "szl",
                CustomerListResponseBillingCurrency.Thb => "thb",
                CustomerListResponseBillingCurrency.Tjs => "tjs",
                CustomerListResponseBillingCurrency.Top => "top",
                CustomerListResponseBillingCurrency.Try => "try",
                CustomerListResponseBillingCurrency.Ttd => "ttd",
                CustomerListResponseBillingCurrency.Tzs => "tzs",
                CustomerListResponseBillingCurrency.Uah => "uah",
                CustomerListResponseBillingCurrency.Uzs => "uzs",
                CustomerListResponseBillingCurrency.Vnd => "vnd",
                CustomerListResponseBillingCurrency.Vuv => "vuv",
                CustomerListResponseBillingCurrency.Wst => "wst",
                CustomerListResponseBillingCurrency.Xaf => "xaf",
                CustomerListResponseBillingCurrency.Xcd => "xcd",
                CustomerListResponseBillingCurrency.Yer => "yer",
                CustomerListResponseBillingCurrency.Zar => "zar",
                CustomerListResponseBillingCurrency.Zmw => "zmw",
                CustomerListResponseBillingCurrency.Clp => "clp",
                CustomerListResponseBillingCurrency.Djf => "djf",
                CustomerListResponseBillingCurrency.Gnf => "gnf",
                CustomerListResponseBillingCurrency.Ugx => "ugx",
                CustomerListResponseBillingCurrency.Pyg => "pyg",
                CustomerListResponseBillingCurrency.Xof => "xof",
                CustomerListResponseBillingCurrency.Xpf => "xpf",
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
        CustomerListResponseDefaultPaymentMethod,
        CustomerListResponseDefaultPaymentMethodFromRaw
    >)
)]
public sealed record class CustomerListResponseDefaultPaymentMethod : JsonModel
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
    public required ApiEnum<string, CustomerListResponseDefaultPaymentMethodType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, CustomerListResponseDefaultPaymentMethodType>
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

    public CustomerListResponseDefaultPaymentMethod() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerListResponseDefaultPaymentMethod(
        CustomerListResponseDefaultPaymentMethod customerListResponseDefaultPaymentMethod
    )
        : base(customerListResponseDefaultPaymentMethod) { }
#pragma warning restore CS8618

    public CustomerListResponseDefaultPaymentMethod(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerListResponseDefaultPaymentMethod(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerListResponseDefaultPaymentMethodFromRaw.FromRawUnchecked"/>
    public static CustomerListResponseDefaultPaymentMethod FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerListResponseDefaultPaymentMethodFromRaw
    : IFromRawJson<CustomerListResponseDefaultPaymentMethod>
{
    /// <inheritdoc/>
    public CustomerListResponseDefaultPaymentMethod FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerListResponseDefaultPaymentMethod.FromRawUnchecked(rawData);
}

/// <summary>
/// The default payment method type
/// </summary>
[JsonConverter(typeof(CustomerListResponseDefaultPaymentMethodTypeConverter))]
public enum CustomerListResponseDefaultPaymentMethodType
{
    Card,
    Bank,
    CashApp,
}

sealed class CustomerListResponseDefaultPaymentMethodTypeConverter
    : JsonConverter<CustomerListResponseDefaultPaymentMethodType>
{
    public override CustomerListResponseDefaultPaymentMethodType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "CARD" => CustomerListResponseDefaultPaymentMethodType.Card,
            "BANK" => CustomerListResponseDefaultPaymentMethodType.Bank,
            "CASH_APP" => CustomerListResponseDefaultPaymentMethodType.CashApp,
            _ => (CustomerListResponseDefaultPaymentMethodType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CustomerListResponseDefaultPaymentMethodType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CustomerListResponseDefaultPaymentMethodType.Card => "CARD",
                CustomerListResponseDefaultPaymentMethodType.Bank => "BANK",
                CustomerListResponseDefaultPaymentMethodType.CashApp => "CASH_APP",
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
        CustomerListResponseIntegration,
        CustomerListResponseIntegrationFromRaw
    >)
)]
public sealed record class CustomerListResponseIntegration : JsonModel
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
        CustomerListResponseIntegrationVendorIdentifier
    > VendorIdentifier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, CustomerListResponseIntegrationVendorIdentifier>
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

    public CustomerListResponseIntegration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerListResponseIntegration(
        CustomerListResponseIntegration customerListResponseIntegration
    )
        : base(customerListResponseIntegration) { }
#pragma warning restore CS8618

    public CustomerListResponseIntegration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerListResponseIntegration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerListResponseIntegrationFromRaw.FromRawUnchecked"/>
    public static CustomerListResponseIntegration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerListResponseIntegrationFromRaw : IFromRawJson<CustomerListResponseIntegration>
{
    /// <inheritdoc/>
    public CustomerListResponseIntegration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerListResponseIntegration.FromRawUnchecked(rawData);
}

/// <summary>
/// The vendor identifier of integration
/// </summary>
[JsonConverter(typeof(CustomerListResponseIntegrationVendorIdentifierConverter))]
public enum CustomerListResponseIntegrationVendorIdentifier
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

sealed class CustomerListResponseIntegrationVendorIdentifierConverter
    : JsonConverter<CustomerListResponseIntegrationVendorIdentifier>
{
    public override CustomerListResponseIntegrationVendorIdentifier Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "AUTH0" => CustomerListResponseIntegrationVendorIdentifier.Auth0,
            "ZUORA" => CustomerListResponseIntegrationVendorIdentifier.Zuora,
            "STRIPE" => CustomerListResponseIntegrationVendorIdentifier.Stripe,
            "HUBSPOT" => CustomerListResponseIntegrationVendorIdentifier.Hubspot,
            "AWS_MARKETPLACE" => CustomerListResponseIntegrationVendorIdentifier.AwsMarketplace,
            "SNOWFLAKE" => CustomerListResponseIntegrationVendorIdentifier.Snowflake,
            "SALESFORCE" => CustomerListResponseIntegrationVendorIdentifier.Salesforce,
            "BIG_QUERY" => CustomerListResponseIntegrationVendorIdentifier.BigQuery,
            "OPEN_FGA" => CustomerListResponseIntegrationVendorIdentifier.OpenFga,
            "APP_STORE" => CustomerListResponseIntegrationVendorIdentifier.AppStore,
            _ => (CustomerListResponseIntegrationVendorIdentifier)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CustomerListResponseIntegrationVendorIdentifier value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CustomerListResponseIntegrationVendorIdentifier.Auth0 => "AUTH0",
                CustomerListResponseIntegrationVendorIdentifier.Zuora => "ZUORA",
                CustomerListResponseIntegrationVendorIdentifier.Stripe => "STRIPE",
                CustomerListResponseIntegrationVendorIdentifier.Hubspot => "HUBSPOT",
                CustomerListResponseIntegrationVendorIdentifier.AwsMarketplace => "AWS_MARKETPLACE",
                CustomerListResponseIntegrationVendorIdentifier.Snowflake => "SNOWFLAKE",
                CustomerListResponseIntegrationVendorIdentifier.Salesforce => "SALESFORCE",
                CustomerListResponseIntegrationVendorIdentifier.BigQuery => "BIG_QUERY",
                CustomerListResponseIntegrationVendorIdentifier.OpenFga => "OPEN_FGA",
                CustomerListResponseIntegrationVendorIdentifier.AppStore => "APP_STORE",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
