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
    public CustomerListResponsePassthrough? Passthrough
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CustomerListResponsePassthrough>("passthrough");
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

/// <summary>
/// Vendor-specific billing passthrough fields.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CustomerListResponsePassthrough,
        CustomerListResponsePassthroughFromRaw
    >)
)]
public sealed record class CustomerListResponsePassthrough : JsonModel
{
    /// <summary>
    /// Stripe-specific billing fields for the customer.
    /// </summary>
    public CustomerListResponsePassthroughStripe? Stripe
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CustomerListResponsePassthroughStripe>("stripe");
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
    public CustomerListResponsePassthroughZuora? Zuora
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CustomerListResponsePassthroughZuora>("zuora");
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

    public CustomerListResponsePassthrough() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerListResponsePassthrough(
        CustomerListResponsePassthrough customerListResponsePassthrough
    )
        : base(customerListResponsePassthrough) { }
#pragma warning restore CS8618

    public CustomerListResponsePassthrough(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerListResponsePassthrough(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerListResponsePassthroughFromRaw.FromRawUnchecked"/>
    public static CustomerListResponsePassthrough FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerListResponsePassthroughFromRaw : IFromRawJson<CustomerListResponsePassthrough>
{
    /// <inheritdoc/>
    public CustomerListResponsePassthrough FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerListResponsePassthrough.FromRawUnchecked(rawData);
}

/// <summary>
/// Stripe-specific billing fields for the customer.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CustomerListResponsePassthroughStripe,
        CustomerListResponsePassthroughStripeFromRaw
    >)
)]
public sealed record class CustomerListResponsePassthroughStripe : JsonModel
{
    /// <summary>
    /// Physical address
    /// </summary>
    public CustomerListResponsePassthroughStripeBillingAddress? BillingAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CustomerListResponsePassthroughStripeBillingAddress>(
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
    public CustomerListResponsePassthroughStripeShippingAddress? ShippingAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CustomerListResponsePassthroughStripeShippingAddress>(
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
    public IReadOnlyList<CustomerListResponsePassthroughStripeTaxID>? TaxIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<CustomerListResponsePassthroughStripeTaxID>
            >("taxIds");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<CustomerListResponsePassthroughStripeTaxID>?>(
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

    public CustomerListResponsePassthroughStripe() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerListResponsePassthroughStripe(
        CustomerListResponsePassthroughStripe customerListResponsePassthroughStripe
    )
        : base(customerListResponsePassthroughStripe) { }
#pragma warning restore CS8618

    public CustomerListResponsePassthroughStripe(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerListResponsePassthroughStripe(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerListResponsePassthroughStripeFromRaw.FromRawUnchecked"/>
    public static CustomerListResponsePassthroughStripe FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerListResponsePassthroughStripeFromRaw
    : IFromRawJson<CustomerListResponsePassthroughStripe>
{
    /// <inheritdoc/>
    public CustomerListResponsePassthroughStripe FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerListResponsePassthroughStripe.FromRawUnchecked(rawData);
}

/// <summary>
/// Physical address
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CustomerListResponsePassthroughStripeBillingAddress,
        CustomerListResponsePassthroughStripeBillingAddressFromRaw
    >)
)]
public sealed record class CustomerListResponsePassthroughStripeBillingAddress : JsonModel
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

    public CustomerListResponsePassthroughStripeBillingAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerListResponsePassthroughStripeBillingAddress(
        CustomerListResponsePassthroughStripeBillingAddress customerListResponsePassthroughStripeBillingAddress
    )
        : base(customerListResponsePassthroughStripeBillingAddress) { }
#pragma warning restore CS8618

    public CustomerListResponsePassthroughStripeBillingAddress(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerListResponsePassthroughStripeBillingAddress(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerListResponsePassthroughStripeBillingAddressFromRaw.FromRawUnchecked"/>
    public static CustomerListResponsePassthroughStripeBillingAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerListResponsePassthroughStripeBillingAddressFromRaw
    : IFromRawJson<CustomerListResponsePassthroughStripeBillingAddress>
{
    /// <inheritdoc/>
    public CustomerListResponsePassthroughStripeBillingAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerListResponsePassthroughStripeBillingAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// Physical address
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CustomerListResponsePassthroughStripeShippingAddress,
        CustomerListResponsePassthroughStripeShippingAddressFromRaw
    >)
)]
public sealed record class CustomerListResponsePassthroughStripeShippingAddress : JsonModel
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

    public CustomerListResponsePassthroughStripeShippingAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerListResponsePassthroughStripeShippingAddress(
        CustomerListResponsePassthroughStripeShippingAddress customerListResponsePassthroughStripeShippingAddress
    )
        : base(customerListResponsePassthroughStripeShippingAddress) { }
#pragma warning restore CS8618

    public CustomerListResponsePassthroughStripeShippingAddress(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerListResponsePassthroughStripeShippingAddress(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerListResponsePassthroughStripeShippingAddressFromRaw.FromRawUnchecked"/>
    public static CustomerListResponsePassthroughStripeShippingAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerListResponsePassthroughStripeShippingAddressFromRaw
    : IFromRawJson<CustomerListResponsePassthroughStripeShippingAddress>
{
    /// <inheritdoc/>
    public CustomerListResponsePassthroughStripeShippingAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerListResponsePassthroughStripeShippingAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// Tax identifier with type and value for customer tax exemptions.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CustomerListResponsePassthroughStripeTaxID,
        CustomerListResponsePassthroughStripeTaxIDFromRaw
    >)
)]
public sealed record class CustomerListResponsePassthroughStripeTaxID : JsonModel
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

    public CustomerListResponsePassthroughStripeTaxID() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerListResponsePassthroughStripeTaxID(
        CustomerListResponsePassthroughStripeTaxID customerListResponsePassthroughStripeTaxID
    )
        : base(customerListResponsePassthroughStripeTaxID) { }
#pragma warning restore CS8618

    public CustomerListResponsePassthroughStripeTaxID(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerListResponsePassthroughStripeTaxID(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerListResponsePassthroughStripeTaxIDFromRaw.FromRawUnchecked"/>
    public static CustomerListResponsePassthroughStripeTaxID FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerListResponsePassthroughStripeTaxIDFromRaw
    : IFromRawJson<CustomerListResponsePassthroughStripeTaxID>
{
    /// <inheritdoc/>
    public CustomerListResponsePassthroughStripeTaxID FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerListResponsePassthroughStripeTaxID.FromRawUnchecked(rawData);
}

/// <summary>
/// Zuora-specific billing fields for the customer.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CustomerListResponsePassthroughZuora,
        CustomerListResponsePassthroughZuoraFromRaw
    >)
)]
public sealed record class CustomerListResponsePassthroughZuora : JsonModel
{
    /// <summary>
    /// Physical address
    /// </summary>
    public CustomerListResponsePassthroughZuoraBillingAddress? BillingAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CustomerListResponsePassthroughZuoraBillingAddress>(
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
    public ApiEnum<string, CustomerListResponsePassthroughZuoraCurrency>? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, CustomerListResponsePassthroughZuoraCurrency>
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

    public CustomerListResponsePassthroughZuora() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerListResponsePassthroughZuora(
        CustomerListResponsePassthroughZuora customerListResponsePassthroughZuora
    )
        : base(customerListResponsePassthroughZuora) { }
#pragma warning restore CS8618

    public CustomerListResponsePassthroughZuora(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerListResponsePassthroughZuora(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerListResponsePassthroughZuoraFromRaw.FromRawUnchecked"/>
    public static CustomerListResponsePassthroughZuora FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerListResponsePassthroughZuoraFromRaw
    : IFromRawJson<CustomerListResponsePassthroughZuora>
{
    /// <inheritdoc/>
    public CustomerListResponsePassthroughZuora FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerListResponsePassthroughZuora.FromRawUnchecked(rawData);
}

/// <summary>
/// Physical address
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CustomerListResponsePassthroughZuoraBillingAddress,
        CustomerListResponsePassthroughZuoraBillingAddressFromRaw
    >)
)]
public sealed record class CustomerListResponsePassthroughZuoraBillingAddress : JsonModel
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

    public CustomerListResponsePassthroughZuoraBillingAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerListResponsePassthroughZuoraBillingAddress(
        CustomerListResponsePassthroughZuoraBillingAddress customerListResponsePassthroughZuoraBillingAddress
    )
        : base(customerListResponsePassthroughZuoraBillingAddress) { }
#pragma warning restore CS8618

    public CustomerListResponsePassthroughZuoraBillingAddress(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerListResponsePassthroughZuoraBillingAddress(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerListResponsePassthroughZuoraBillingAddressFromRaw.FromRawUnchecked"/>
    public static CustomerListResponsePassthroughZuoraBillingAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerListResponsePassthroughZuoraBillingAddressFromRaw
    : IFromRawJson<CustomerListResponsePassthroughZuoraBillingAddress>
{
    /// <inheritdoc/>
    public CustomerListResponsePassthroughZuoraBillingAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerListResponsePassthroughZuoraBillingAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// Customers selected currency
/// </summary>
[JsonConverter(typeof(CustomerListResponsePassthroughZuoraCurrencyConverter))]
public enum CustomerListResponsePassthroughZuoraCurrency
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

sealed class CustomerListResponsePassthroughZuoraCurrencyConverter
    : JsonConverter<CustomerListResponsePassthroughZuoraCurrency>
{
    public override CustomerListResponsePassthroughZuoraCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => CustomerListResponsePassthroughZuoraCurrency.Usd,
            "aed" => CustomerListResponsePassthroughZuoraCurrency.Aed,
            "all" => CustomerListResponsePassthroughZuoraCurrency.All,
            "amd" => CustomerListResponsePassthroughZuoraCurrency.Amd,
            "ang" => CustomerListResponsePassthroughZuoraCurrency.Ang,
            "aud" => CustomerListResponsePassthroughZuoraCurrency.Aud,
            "awg" => CustomerListResponsePassthroughZuoraCurrency.Awg,
            "azn" => CustomerListResponsePassthroughZuoraCurrency.Azn,
            "bam" => CustomerListResponsePassthroughZuoraCurrency.Bam,
            "bbd" => CustomerListResponsePassthroughZuoraCurrency.Bbd,
            "bdt" => CustomerListResponsePassthroughZuoraCurrency.Bdt,
            "bgn" => CustomerListResponsePassthroughZuoraCurrency.Bgn,
            "bif" => CustomerListResponsePassthroughZuoraCurrency.Bif,
            "bmd" => CustomerListResponsePassthroughZuoraCurrency.Bmd,
            "bnd" => CustomerListResponsePassthroughZuoraCurrency.Bnd,
            "bsd" => CustomerListResponsePassthroughZuoraCurrency.Bsd,
            "bwp" => CustomerListResponsePassthroughZuoraCurrency.Bwp,
            "byn" => CustomerListResponsePassthroughZuoraCurrency.Byn,
            "bzd" => CustomerListResponsePassthroughZuoraCurrency.Bzd,
            "brl" => CustomerListResponsePassthroughZuoraCurrency.Brl,
            "cad" => CustomerListResponsePassthroughZuoraCurrency.Cad,
            "cdf" => CustomerListResponsePassthroughZuoraCurrency.Cdf,
            "chf" => CustomerListResponsePassthroughZuoraCurrency.Chf,
            "cny" => CustomerListResponsePassthroughZuoraCurrency.Cny,
            "czk" => CustomerListResponsePassthroughZuoraCurrency.Czk,
            "dkk" => CustomerListResponsePassthroughZuoraCurrency.Dkk,
            "dop" => CustomerListResponsePassthroughZuoraCurrency.Dop,
            "dzd" => CustomerListResponsePassthroughZuoraCurrency.Dzd,
            "egp" => CustomerListResponsePassthroughZuoraCurrency.Egp,
            "etb" => CustomerListResponsePassthroughZuoraCurrency.Etb,
            "eur" => CustomerListResponsePassthroughZuoraCurrency.Eur,
            "fjd" => CustomerListResponsePassthroughZuoraCurrency.Fjd,
            "gbp" => CustomerListResponsePassthroughZuoraCurrency.Gbp,
            "gel" => CustomerListResponsePassthroughZuoraCurrency.Gel,
            "gip" => CustomerListResponsePassthroughZuoraCurrency.Gip,
            "gmd" => CustomerListResponsePassthroughZuoraCurrency.Gmd,
            "gyd" => CustomerListResponsePassthroughZuoraCurrency.Gyd,
            "hkd" => CustomerListResponsePassthroughZuoraCurrency.Hkd,
            "hrk" => CustomerListResponsePassthroughZuoraCurrency.Hrk,
            "htg" => CustomerListResponsePassthroughZuoraCurrency.Htg,
            "idr" => CustomerListResponsePassthroughZuoraCurrency.Idr,
            "ils" => CustomerListResponsePassthroughZuoraCurrency.Ils,
            "inr" => CustomerListResponsePassthroughZuoraCurrency.Inr,
            "isk" => CustomerListResponsePassthroughZuoraCurrency.Isk,
            "jmd" => CustomerListResponsePassthroughZuoraCurrency.Jmd,
            "jpy" => CustomerListResponsePassthroughZuoraCurrency.Jpy,
            "kes" => CustomerListResponsePassthroughZuoraCurrency.Kes,
            "kgs" => CustomerListResponsePassthroughZuoraCurrency.Kgs,
            "khr" => CustomerListResponsePassthroughZuoraCurrency.Khr,
            "kmf" => CustomerListResponsePassthroughZuoraCurrency.Kmf,
            "krw" => CustomerListResponsePassthroughZuoraCurrency.Krw,
            "kyd" => CustomerListResponsePassthroughZuoraCurrency.Kyd,
            "kzt" => CustomerListResponsePassthroughZuoraCurrency.Kzt,
            "lbp" => CustomerListResponsePassthroughZuoraCurrency.Lbp,
            "lkr" => CustomerListResponsePassthroughZuoraCurrency.Lkr,
            "lrd" => CustomerListResponsePassthroughZuoraCurrency.Lrd,
            "lsl" => CustomerListResponsePassthroughZuoraCurrency.Lsl,
            "mad" => CustomerListResponsePassthroughZuoraCurrency.Mad,
            "mdl" => CustomerListResponsePassthroughZuoraCurrency.Mdl,
            "mga" => CustomerListResponsePassthroughZuoraCurrency.Mga,
            "mkd" => CustomerListResponsePassthroughZuoraCurrency.Mkd,
            "mmk" => CustomerListResponsePassthroughZuoraCurrency.Mmk,
            "mnt" => CustomerListResponsePassthroughZuoraCurrency.Mnt,
            "mop" => CustomerListResponsePassthroughZuoraCurrency.Mop,
            "mro" => CustomerListResponsePassthroughZuoraCurrency.Mro,
            "mvr" => CustomerListResponsePassthroughZuoraCurrency.Mvr,
            "mwk" => CustomerListResponsePassthroughZuoraCurrency.Mwk,
            "mxn" => CustomerListResponsePassthroughZuoraCurrency.Mxn,
            "myr" => CustomerListResponsePassthroughZuoraCurrency.Myr,
            "mzn" => CustomerListResponsePassthroughZuoraCurrency.Mzn,
            "nad" => CustomerListResponsePassthroughZuoraCurrency.Nad,
            "ngn" => CustomerListResponsePassthroughZuoraCurrency.Ngn,
            "nok" => CustomerListResponsePassthroughZuoraCurrency.Nok,
            "npr" => CustomerListResponsePassthroughZuoraCurrency.Npr,
            "nzd" => CustomerListResponsePassthroughZuoraCurrency.Nzd,
            "pgk" => CustomerListResponsePassthroughZuoraCurrency.Pgk,
            "php" => CustomerListResponsePassthroughZuoraCurrency.Php,
            "pkr" => CustomerListResponsePassthroughZuoraCurrency.Pkr,
            "pln" => CustomerListResponsePassthroughZuoraCurrency.Pln,
            "qar" => CustomerListResponsePassthroughZuoraCurrency.Qar,
            "ron" => CustomerListResponsePassthroughZuoraCurrency.Ron,
            "rsd" => CustomerListResponsePassthroughZuoraCurrency.Rsd,
            "rub" => CustomerListResponsePassthroughZuoraCurrency.Rub,
            "rwf" => CustomerListResponsePassthroughZuoraCurrency.Rwf,
            "sar" => CustomerListResponsePassthroughZuoraCurrency.Sar,
            "sbd" => CustomerListResponsePassthroughZuoraCurrency.Sbd,
            "scr" => CustomerListResponsePassthroughZuoraCurrency.Scr,
            "sek" => CustomerListResponsePassthroughZuoraCurrency.Sek,
            "sgd" => CustomerListResponsePassthroughZuoraCurrency.Sgd,
            "sle" => CustomerListResponsePassthroughZuoraCurrency.Sle,
            "sll" => CustomerListResponsePassthroughZuoraCurrency.Sll,
            "sos" => CustomerListResponsePassthroughZuoraCurrency.Sos,
            "szl" => CustomerListResponsePassthroughZuoraCurrency.Szl,
            "thb" => CustomerListResponsePassthroughZuoraCurrency.Thb,
            "tjs" => CustomerListResponsePassthroughZuoraCurrency.Tjs,
            "top" => CustomerListResponsePassthroughZuoraCurrency.Top,
            "try" => CustomerListResponsePassthroughZuoraCurrency.Try,
            "ttd" => CustomerListResponsePassthroughZuoraCurrency.Ttd,
            "tzs" => CustomerListResponsePassthroughZuoraCurrency.Tzs,
            "uah" => CustomerListResponsePassthroughZuoraCurrency.Uah,
            "uzs" => CustomerListResponsePassthroughZuoraCurrency.Uzs,
            "vnd" => CustomerListResponsePassthroughZuoraCurrency.Vnd,
            "vuv" => CustomerListResponsePassthroughZuoraCurrency.Vuv,
            "wst" => CustomerListResponsePassthroughZuoraCurrency.Wst,
            "xaf" => CustomerListResponsePassthroughZuoraCurrency.Xaf,
            "xcd" => CustomerListResponsePassthroughZuoraCurrency.Xcd,
            "yer" => CustomerListResponsePassthroughZuoraCurrency.Yer,
            "zar" => CustomerListResponsePassthroughZuoraCurrency.Zar,
            "zmw" => CustomerListResponsePassthroughZuoraCurrency.Zmw,
            "clp" => CustomerListResponsePassthroughZuoraCurrency.Clp,
            "djf" => CustomerListResponsePassthroughZuoraCurrency.Djf,
            "gnf" => CustomerListResponsePassthroughZuoraCurrency.Gnf,
            "ugx" => CustomerListResponsePassthroughZuoraCurrency.Ugx,
            "pyg" => CustomerListResponsePassthroughZuoraCurrency.Pyg,
            "xof" => CustomerListResponsePassthroughZuoraCurrency.Xof,
            "xpf" => CustomerListResponsePassthroughZuoraCurrency.Xpf,
            _ => (CustomerListResponsePassthroughZuoraCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CustomerListResponsePassthroughZuoraCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CustomerListResponsePassthroughZuoraCurrency.Usd => "usd",
                CustomerListResponsePassthroughZuoraCurrency.Aed => "aed",
                CustomerListResponsePassthroughZuoraCurrency.All => "all",
                CustomerListResponsePassthroughZuoraCurrency.Amd => "amd",
                CustomerListResponsePassthroughZuoraCurrency.Ang => "ang",
                CustomerListResponsePassthroughZuoraCurrency.Aud => "aud",
                CustomerListResponsePassthroughZuoraCurrency.Awg => "awg",
                CustomerListResponsePassthroughZuoraCurrency.Azn => "azn",
                CustomerListResponsePassthroughZuoraCurrency.Bam => "bam",
                CustomerListResponsePassthroughZuoraCurrency.Bbd => "bbd",
                CustomerListResponsePassthroughZuoraCurrency.Bdt => "bdt",
                CustomerListResponsePassthroughZuoraCurrency.Bgn => "bgn",
                CustomerListResponsePassthroughZuoraCurrency.Bif => "bif",
                CustomerListResponsePassthroughZuoraCurrency.Bmd => "bmd",
                CustomerListResponsePassthroughZuoraCurrency.Bnd => "bnd",
                CustomerListResponsePassthroughZuoraCurrency.Bsd => "bsd",
                CustomerListResponsePassthroughZuoraCurrency.Bwp => "bwp",
                CustomerListResponsePassthroughZuoraCurrency.Byn => "byn",
                CustomerListResponsePassthroughZuoraCurrency.Bzd => "bzd",
                CustomerListResponsePassthroughZuoraCurrency.Brl => "brl",
                CustomerListResponsePassthroughZuoraCurrency.Cad => "cad",
                CustomerListResponsePassthroughZuoraCurrency.Cdf => "cdf",
                CustomerListResponsePassthroughZuoraCurrency.Chf => "chf",
                CustomerListResponsePassthroughZuoraCurrency.Cny => "cny",
                CustomerListResponsePassthroughZuoraCurrency.Czk => "czk",
                CustomerListResponsePassthroughZuoraCurrency.Dkk => "dkk",
                CustomerListResponsePassthroughZuoraCurrency.Dop => "dop",
                CustomerListResponsePassthroughZuoraCurrency.Dzd => "dzd",
                CustomerListResponsePassthroughZuoraCurrency.Egp => "egp",
                CustomerListResponsePassthroughZuoraCurrency.Etb => "etb",
                CustomerListResponsePassthroughZuoraCurrency.Eur => "eur",
                CustomerListResponsePassthroughZuoraCurrency.Fjd => "fjd",
                CustomerListResponsePassthroughZuoraCurrency.Gbp => "gbp",
                CustomerListResponsePassthroughZuoraCurrency.Gel => "gel",
                CustomerListResponsePassthroughZuoraCurrency.Gip => "gip",
                CustomerListResponsePassthroughZuoraCurrency.Gmd => "gmd",
                CustomerListResponsePassthroughZuoraCurrency.Gyd => "gyd",
                CustomerListResponsePassthroughZuoraCurrency.Hkd => "hkd",
                CustomerListResponsePassthroughZuoraCurrency.Hrk => "hrk",
                CustomerListResponsePassthroughZuoraCurrency.Htg => "htg",
                CustomerListResponsePassthroughZuoraCurrency.Idr => "idr",
                CustomerListResponsePassthroughZuoraCurrency.Ils => "ils",
                CustomerListResponsePassthroughZuoraCurrency.Inr => "inr",
                CustomerListResponsePassthroughZuoraCurrency.Isk => "isk",
                CustomerListResponsePassthroughZuoraCurrency.Jmd => "jmd",
                CustomerListResponsePassthroughZuoraCurrency.Jpy => "jpy",
                CustomerListResponsePassthroughZuoraCurrency.Kes => "kes",
                CustomerListResponsePassthroughZuoraCurrency.Kgs => "kgs",
                CustomerListResponsePassthroughZuoraCurrency.Khr => "khr",
                CustomerListResponsePassthroughZuoraCurrency.Kmf => "kmf",
                CustomerListResponsePassthroughZuoraCurrency.Krw => "krw",
                CustomerListResponsePassthroughZuoraCurrency.Kyd => "kyd",
                CustomerListResponsePassthroughZuoraCurrency.Kzt => "kzt",
                CustomerListResponsePassthroughZuoraCurrency.Lbp => "lbp",
                CustomerListResponsePassthroughZuoraCurrency.Lkr => "lkr",
                CustomerListResponsePassthroughZuoraCurrency.Lrd => "lrd",
                CustomerListResponsePassthroughZuoraCurrency.Lsl => "lsl",
                CustomerListResponsePassthroughZuoraCurrency.Mad => "mad",
                CustomerListResponsePassthroughZuoraCurrency.Mdl => "mdl",
                CustomerListResponsePassthroughZuoraCurrency.Mga => "mga",
                CustomerListResponsePassthroughZuoraCurrency.Mkd => "mkd",
                CustomerListResponsePassthroughZuoraCurrency.Mmk => "mmk",
                CustomerListResponsePassthroughZuoraCurrency.Mnt => "mnt",
                CustomerListResponsePassthroughZuoraCurrency.Mop => "mop",
                CustomerListResponsePassthroughZuoraCurrency.Mro => "mro",
                CustomerListResponsePassthroughZuoraCurrency.Mvr => "mvr",
                CustomerListResponsePassthroughZuoraCurrency.Mwk => "mwk",
                CustomerListResponsePassthroughZuoraCurrency.Mxn => "mxn",
                CustomerListResponsePassthroughZuoraCurrency.Myr => "myr",
                CustomerListResponsePassthroughZuoraCurrency.Mzn => "mzn",
                CustomerListResponsePassthroughZuoraCurrency.Nad => "nad",
                CustomerListResponsePassthroughZuoraCurrency.Ngn => "ngn",
                CustomerListResponsePassthroughZuoraCurrency.Nok => "nok",
                CustomerListResponsePassthroughZuoraCurrency.Npr => "npr",
                CustomerListResponsePassthroughZuoraCurrency.Nzd => "nzd",
                CustomerListResponsePassthroughZuoraCurrency.Pgk => "pgk",
                CustomerListResponsePassthroughZuoraCurrency.Php => "php",
                CustomerListResponsePassthroughZuoraCurrency.Pkr => "pkr",
                CustomerListResponsePassthroughZuoraCurrency.Pln => "pln",
                CustomerListResponsePassthroughZuoraCurrency.Qar => "qar",
                CustomerListResponsePassthroughZuoraCurrency.Ron => "ron",
                CustomerListResponsePassthroughZuoraCurrency.Rsd => "rsd",
                CustomerListResponsePassthroughZuoraCurrency.Rub => "rub",
                CustomerListResponsePassthroughZuoraCurrency.Rwf => "rwf",
                CustomerListResponsePassthroughZuoraCurrency.Sar => "sar",
                CustomerListResponsePassthroughZuoraCurrency.Sbd => "sbd",
                CustomerListResponsePassthroughZuoraCurrency.Scr => "scr",
                CustomerListResponsePassthroughZuoraCurrency.Sek => "sek",
                CustomerListResponsePassthroughZuoraCurrency.Sgd => "sgd",
                CustomerListResponsePassthroughZuoraCurrency.Sle => "sle",
                CustomerListResponsePassthroughZuoraCurrency.Sll => "sll",
                CustomerListResponsePassthroughZuoraCurrency.Sos => "sos",
                CustomerListResponsePassthroughZuoraCurrency.Szl => "szl",
                CustomerListResponsePassthroughZuoraCurrency.Thb => "thb",
                CustomerListResponsePassthroughZuoraCurrency.Tjs => "tjs",
                CustomerListResponsePassthroughZuoraCurrency.Top => "top",
                CustomerListResponsePassthroughZuoraCurrency.Try => "try",
                CustomerListResponsePassthroughZuoraCurrency.Ttd => "ttd",
                CustomerListResponsePassthroughZuoraCurrency.Tzs => "tzs",
                CustomerListResponsePassthroughZuoraCurrency.Uah => "uah",
                CustomerListResponsePassthroughZuoraCurrency.Uzs => "uzs",
                CustomerListResponsePassthroughZuoraCurrency.Vnd => "vnd",
                CustomerListResponsePassthroughZuoraCurrency.Vuv => "vuv",
                CustomerListResponsePassthroughZuoraCurrency.Wst => "wst",
                CustomerListResponsePassthroughZuoraCurrency.Xaf => "xaf",
                CustomerListResponsePassthroughZuoraCurrency.Xcd => "xcd",
                CustomerListResponsePassthroughZuoraCurrency.Yer => "yer",
                CustomerListResponsePassthroughZuoraCurrency.Zar => "zar",
                CustomerListResponsePassthroughZuoraCurrency.Zmw => "zmw",
                CustomerListResponsePassthroughZuoraCurrency.Clp => "clp",
                CustomerListResponsePassthroughZuoraCurrency.Djf => "djf",
                CustomerListResponsePassthroughZuoraCurrency.Gnf => "gnf",
                CustomerListResponsePassthroughZuoraCurrency.Ugx => "ugx",
                CustomerListResponsePassthroughZuoraCurrency.Pyg => "pyg",
                CustomerListResponsePassthroughZuoraCurrency.Xof => "xof",
                CustomerListResponsePassthroughZuoraCurrency.Xpf => "xpf",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
