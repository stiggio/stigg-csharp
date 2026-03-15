using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using System = System;

namespace Stigg.Client.Models.V1.Customers;

/// <summary>
/// Creates a new customer and optionally provisions an initial subscription in a
/// single operation.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CustomerProvisionParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Customer slug
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("id");
        }
        init { this._rawBodyData.Set("id", value); }
    }

    /// <summary>
    /// The billing currency of the customer
    /// </summary>
    public ApiEnum<string, CustomerProvisionParamsBillingCurrency>? BillingCurrency
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<
                ApiEnum<string, CustomerProvisionParamsBillingCurrency>
            >("billingCurrency");
        }
        init { this._rawBodyData.Set("billingCurrency", value); }
    }

    /// <summary>
    /// The unique identifier for the entity in the billing provider
    /// </summary>
    public string? BillingID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("billingId");
        }
        init { this._rawBodyData.Set("billingId", value); }
    }

    /// <summary>
    /// Customer level coupon
    /// </summary>
    public string? CouponID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("couponId");
        }
        init { this._rawBodyData.Set("couponId", value); }
    }

    /// <summary>
    /// The default payment method details
    /// </summary>
    public DefaultPaymentMethod? DefaultPaymentMethod
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<DefaultPaymentMethod>("defaultPaymentMethod");
        }
        init { this._rawBodyData.Set("defaultPaymentMethod", value); }
    }

    /// <summary>
    /// The email of the customer
    /// </summary>
    public string? Email
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("email");
        }
        init { this._rawBodyData.Set("email", value); }
    }

    /// <summary>
    /// List of integrations
    /// </summary>
    public IReadOnlyList<CustomerProvisionParamsIntegration>? Integrations
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<
                ImmutableArray<CustomerProvisionParamsIntegration>
            >("integrations");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<CustomerProvisionParamsIntegration>?>(
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<FrozenDictionary<string, string>?>(
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("name");
        }
        init { this._rawBodyData.Set("name", value); }
    }

    public CustomerProvisionParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerProvisionParams(CustomerProvisionParams customerProvisionParams)
        : base(customerProvisionParams)
    {
        this._rawBodyData = new(customerProvisionParams._rawBodyData);
    }
#pragma warning restore CS8618

    public CustomerProvisionParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerProvisionParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static CustomerProvisionParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(CustomerProvisionParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/api/v1/customers")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

/// <summary>
/// The billing currency of the customer
/// </summary>
[JsonConverter(typeof(CustomerProvisionParamsBillingCurrencyConverter))]
public enum CustomerProvisionParamsBillingCurrency
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

sealed class CustomerProvisionParamsBillingCurrencyConverter
    : JsonConverter<CustomerProvisionParamsBillingCurrency>
{
    public override CustomerProvisionParamsBillingCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => CustomerProvisionParamsBillingCurrency.Usd,
            "aed" => CustomerProvisionParamsBillingCurrency.Aed,
            "all" => CustomerProvisionParamsBillingCurrency.All,
            "amd" => CustomerProvisionParamsBillingCurrency.Amd,
            "ang" => CustomerProvisionParamsBillingCurrency.Ang,
            "aud" => CustomerProvisionParamsBillingCurrency.Aud,
            "awg" => CustomerProvisionParamsBillingCurrency.Awg,
            "azn" => CustomerProvisionParamsBillingCurrency.Azn,
            "bam" => CustomerProvisionParamsBillingCurrency.Bam,
            "bbd" => CustomerProvisionParamsBillingCurrency.Bbd,
            "bdt" => CustomerProvisionParamsBillingCurrency.Bdt,
            "bgn" => CustomerProvisionParamsBillingCurrency.Bgn,
            "bif" => CustomerProvisionParamsBillingCurrency.Bif,
            "bmd" => CustomerProvisionParamsBillingCurrency.Bmd,
            "bnd" => CustomerProvisionParamsBillingCurrency.Bnd,
            "bsd" => CustomerProvisionParamsBillingCurrency.Bsd,
            "bwp" => CustomerProvisionParamsBillingCurrency.Bwp,
            "byn" => CustomerProvisionParamsBillingCurrency.Byn,
            "bzd" => CustomerProvisionParamsBillingCurrency.Bzd,
            "brl" => CustomerProvisionParamsBillingCurrency.Brl,
            "cad" => CustomerProvisionParamsBillingCurrency.Cad,
            "cdf" => CustomerProvisionParamsBillingCurrency.Cdf,
            "chf" => CustomerProvisionParamsBillingCurrency.Chf,
            "cny" => CustomerProvisionParamsBillingCurrency.Cny,
            "czk" => CustomerProvisionParamsBillingCurrency.Czk,
            "dkk" => CustomerProvisionParamsBillingCurrency.Dkk,
            "dop" => CustomerProvisionParamsBillingCurrency.Dop,
            "dzd" => CustomerProvisionParamsBillingCurrency.Dzd,
            "egp" => CustomerProvisionParamsBillingCurrency.Egp,
            "etb" => CustomerProvisionParamsBillingCurrency.Etb,
            "eur" => CustomerProvisionParamsBillingCurrency.Eur,
            "fjd" => CustomerProvisionParamsBillingCurrency.Fjd,
            "gbp" => CustomerProvisionParamsBillingCurrency.Gbp,
            "gel" => CustomerProvisionParamsBillingCurrency.Gel,
            "gip" => CustomerProvisionParamsBillingCurrency.Gip,
            "gmd" => CustomerProvisionParamsBillingCurrency.Gmd,
            "gyd" => CustomerProvisionParamsBillingCurrency.Gyd,
            "hkd" => CustomerProvisionParamsBillingCurrency.Hkd,
            "hrk" => CustomerProvisionParamsBillingCurrency.Hrk,
            "htg" => CustomerProvisionParamsBillingCurrency.Htg,
            "idr" => CustomerProvisionParamsBillingCurrency.Idr,
            "ils" => CustomerProvisionParamsBillingCurrency.Ils,
            "inr" => CustomerProvisionParamsBillingCurrency.Inr,
            "isk" => CustomerProvisionParamsBillingCurrency.Isk,
            "jmd" => CustomerProvisionParamsBillingCurrency.Jmd,
            "jpy" => CustomerProvisionParamsBillingCurrency.Jpy,
            "kes" => CustomerProvisionParamsBillingCurrency.Kes,
            "kgs" => CustomerProvisionParamsBillingCurrency.Kgs,
            "khr" => CustomerProvisionParamsBillingCurrency.Khr,
            "kmf" => CustomerProvisionParamsBillingCurrency.Kmf,
            "krw" => CustomerProvisionParamsBillingCurrency.Krw,
            "kyd" => CustomerProvisionParamsBillingCurrency.Kyd,
            "kzt" => CustomerProvisionParamsBillingCurrency.Kzt,
            "lbp" => CustomerProvisionParamsBillingCurrency.Lbp,
            "lkr" => CustomerProvisionParamsBillingCurrency.Lkr,
            "lrd" => CustomerProvisionParamsBillingCurrency.Lrd,
            "lsl" => CustomerProvisionParamsBillingCurrency.Lsl,
            "mad" => CustomerProvisionParamsBillingCurrency.Mad,
            "mdl" => CustomerProvisionParamsBillingCurrency.Mdl,
            "mga" => CustomerProvisionParamsBillingCurrency.Mga,
            "mkd" => CustomerProvisionParamsBillingCurrency.Mkd,
            "mmk" => CustomerProvisionParamsBillingCurrency.Mmk,
            "mnt" => CustomerProvisionParamsBillingCurrency.Mnt,
            "mop" => CustomerProvisionParamsBillingCurrency.Mop,
            "mro" => CustomerProvisionParamsBillingCurrency.Mro,
            "mvr" => CustomerProvisionParamsBillingCurrency.Mvr,
            "mwk" => CustomerProvisionParamsBillingCurrency.Mwk,
            "mxn" => CustomerProvisionParamsBillingCurrency.Mxn,
            "myr" => CustomerProvisionParamsBillingCurrency.Myr,
            "mzn" => CustomerProvisionParamsBillingCurrency.Mzn,
            "nad" => CustomerProvisionParamsBillingCurrency.Nad,
            "ngn" => CustomerProvisionParamsBillingCurrency.Ngn,
            "nok" => CustomerProvisionParamsBillingCurrency.Nok,
            "npr" => CustomerProvisionParamsBillingCurrency.Npr,
            "nzd" => CustomerProvisionParamsBillingCurrency.Nzd,
            "pgk" => CustomerProvisionParamsBillingCurrency.Pgk,
            "php" => CustomerProvisionParamsBillingCurrency.Php,
            "pkr" => CustomerProvisionParamsBillingCurrency.Pkr,
            "pln" => CustomerProvisionParamsBillingCurrency.Pln,
            "qar" => CustomerProvisionParamsBillingCurrency.Qar,
            "ron" => CustomerProvisionParamsBillingCurrency.Ron,
            "rsd" => CustomerProvisionParamsBillingCurrency.Rsd,
            "rub" => CustomerProvisionParamsBillingCurrency.Rub,
            "rwf" => CustomerProvisionParamsBillingCurrency.Rwf,
            "sar" => CustomerProvisionParamsBillingCurrency.Sar,
            "sbd" => CustomerProvisionParamsBillingCurrency.Sbd,
            "scr" => CustomerProvisionParamsBillingCurrency.Scr,
            "sek" => CustomerProvisionParamsBillingCurrency.Sek,
            "sgd" => CustomerProvisionParamsBillingCurrency.Sgd,
            "sle" => CustomerProvisionParamsBillingCurrency.Sle,
            "sll" => CustomerProvisionParamsBillingCurrency.Sll,
            "sos" => CustomerProvisionParamsBillingCurrency.Sos,
            "szl" => CustomerProvisionParamsBillingCurrency.Szl,
            "thb" => CustomerProvisionParamsBillingCurrency.Thb,
            "tjs" => CustomerProvisionParamsBillingCurrency.Tjs,
            "top" => CustomerProvisionParamsBillingCurrency.Top,
            "try" => CustomerProvisionParamsBillingCurrency.Try,
            "ttd" => CustomerProvisionParamsBillingCurrency.Ttd,
            "tzs" => CustomerProvisionParamsBillingCurrency.Tzs,
            "uah" => CustomerProvisionParamsBillingCurrency.Uah,
            "uzs" => CustomerProvisionParamsBillingCurrency.Uzs,
            "vnd" => CustomerProvisionParamsBillingCurrency.Vnd,
            "vuv" => CustomerProvisionParamsBillingCurrency.Vuv,
            "wst" => CustomerProvisionParamsBillingCurrency.Wst,
            "xaf" => CustomerProvisionParamsBillingCurrency.Xaf,
            "xcd" => CustomerProvisionParamsBillingCurrency.Xcd,
            "yer" => CustomerProvisionParamsBillingCurrency.Yer,
            "zar" => CustomerProvisionParamsBillingCurrency.Zar,
            "zmw" => CustomerProvisionParamsBillingCurrency.Zmw,
            "clp" => CustomerProvisionParamsBillingCurrency.Clp,
            "djf" => CustomerProvisionParamsBillingCurrency.Djf,
            "gnf" => CustomerProvisionParamsBillingCurrency.Gnf,
            "ugx" => CustomerProvisionParamsBillingCurrency.Ugx,
            "pyg" => CustomerProvisionParamsBillingCurrency.Pyg,
            "xof" => CustomerProvisionParamsBillingCurrency.Xof,
            "xpf" => CustomerProvisionParamsBillingCurrency.Xpf,
            _ => (CustomerProvisionParamsBillingCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CustomerProvisionParamsBillingCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CustomerProvisionParamsBillingCurrency.Usd => "usd",
                CustomerProvisionParamsBillingCurrency.Aed => "aed",
                CustomerProvisionParamsBillingCurrency.All => "all",
                CustomerProvisionParamsBillingCurrency.Amd => "amd",
                CustomerProvisionParamsBillingCurrency.Ang => "ang",
                CustomerProvisionParamsBillingCurrency.Aud => "aud",
                CustomerProvisionParamsBillingCurrency.Awg => "awg",
                CustomerProvisionParamsBillingCurrency.Azn => "azn",
                CustomerProvisionParamsBillingCurrency.Bam => "bam",
                CustomerProvisionParamsBillingCurrency.Bbd => "bbd",
                CustomerProvisionParamsBillingCurrency.Bdt => "bdt",
                CustomerProvisionParamsBillingCurrency.Bgn => "bgn",
                CustomerProvisionParamsBillingCurrency.Bif => "bif",
                CustomerProvisionParamsBillingCurrency.Bmd => "bmd",
                CustomerProvisionParamsBillingCurrency.Bnd => "bnd",
                CustomerProvisionParamsBillingCurrency.Bsd => "bsd",
                CustomerProvisionParamsBillingCurrency.Bwp => "bwp",
                CustomerProvisionParamsBillingCurrency.Byn => "byn",
                CustomerProvisionParamsBillingCurrency.Bzd => "bzd",
                CustomerProvisionParamsBillingCurrency.Brl => "brl",
                CustomerProvisionParamsBillingCurrency.Cad => "cad",
                CustomerProvisionParamsBillingCurrency.Cdf => "cdf",
                CustomerProvisionParamsBillingCurrency.Chf => "chf",
                CustomerProvisionParamsBillingCurrency.Cny => "cny",
                CustomerProvisionParamsBillingCurrency.Czk => "czk",
                CustomerProvisionParamsBillingCurrency.Dkk => "dkk",
                CustomerProvisionParamsBillingCurrency.Dop => "dop",
                CustomerProvisionParamsBillingCurrency.Dzd => "dzd",
                CustomerProvisionParamsBillingCurrency.Egp => "egp",
                CustomerProvisionParamsBillingCurrency.Etb => "etb",
                CustomerProvisionParamsBillingCurrency.Eur => "eur",
                CustomerProvisionParamsBillingCurrency.Fjd => "fjd",
                CustomerProvisionParamsBillingCurrency.Gbp => "gbp",
                CustomerProvisionParamsBillingCurrency.Gel => "gel",
                CustomerProvisionParamsBillingCurrency.Gip => "gip",
                CustomerProvisionParamsBillingCurrency.Gmd => "gmd",
                CustomerProvisionParamsBillingCurrency.Gyd => "gyd",
                CustomerProvisionParamsBillingCurrency.Hkd => "hkd",
                CustomerProvisionParamsBillingCurrency.Hrk => "hrk",
                CustomerProvisionParamsBillingCurrency.Htg => "htg",
                CustomerProvisionParamsBillingCurrency.Idr => "idr",
                CustomerProvisionParamsBillingCurrency.Ils => "ils",
                CustomerProvisionParamsBillingCurrency.Inr => "inr",
                CustomerProvisionParamsBillingCurrency.Isk => "isk",
                CustomerProvisionParamsBillingCurrency.Jmd => "jmd",
                CustomerProvisionParamsBillingCurrency.Jpy => "jpy",
                CustomerProvisionParamsBillingCurrency.Kes => "kes",
                CustomerProvisionParamsBillingCurrency.Kgs => "kgs",
                CustomerProvisionParamsBillingCurrency.Khr => "khr",
                CustomerProvisionParamsBillingCurrency.Kmf => "kmf",
                CustomerProvisionParamsBillingCurrency.Krw => "krw",
                CustomerProvisionParamsBillingCurrency.Kyd => "kyd",
                CustomerProvisionParamsBillingCurrency.Kzt => "kzt",
                CustomerProvisionParamsBillingCurrency.Lbp => "lbp",
                CustomerProvisionParamsBillingCurrency.Lkr => "lkr",
                CustomerProvisionParamsBillingCurrency.Lrd => "lrd",
                CustomerProvisionParamsBillingCurrency.Lsl => "lsl",
                CustomerProvisionParamsBillingCurrency.Mad => "mad",
                CustomerProvisionParamsBillingCurrency.Mdl => "mdl",
                CustomerProvisionParamsBillingCurrency.Mga => "mga",
                CustomerProvisionParamsBillingCurrency.Mkd => "mkd",
                CustomerProvisionParamsBillingCurrency.Mmk => "mmk",
                CustomerProvisionParamsBillingCurrency.Mnt => "mnt",
                CustomerProvisionParamsBillingCurrency.Mop => "mop",
                CustomerProvisionParamsBillingCurrency.Mro => "mro",
                CustomerProvisionParamsBillingCurrency.Mvr => "mvr",
                CustomerProvisionParamsBillingCurrency.Mwk => "mwk",
                CustomerProvisionParamsBillingCurrency.Mxn => "mxn",
                CustomerProvisionParamsBillingCurrency.Myr => "myr",
                CustomerProvisionParamsBillingCurrency.Mzn => "mzn",
                CustomerProvisionParamsBillingCurrency.Nad => "nad",
                CustomerProvisionParamsBillingCurrency.Ngn => "ngn",
                CustomerProvisionParamsBillingCurrency.Nok => "nok",
                CustomerProvisionParamsBillingCurrency.Npr => "npr",
                CustomerProvisionParamsBillingCurrency.Nzd => "nzd",
                CustomerProvisionParamsBillingCurrency.Pgk => "pgk",
                CustomerProvisionParamsBillingCurrency.Php => "php",
                CustomerProvisionParamsBillingCurrency.Pkr => "pkr",
                CustomerProvisionParamsBillingCurrency.Pln => "pln",
                CustomerProvisionParamsBillingCurrency.Qar => "qar",
                CustomerProvisionParamsBillingCurrency.Ron => "ron",
                CustomerProvisionParamsBillingCurrency.Rsd => "rsd",
                CustomerProvisionParamsBillingCurrency.Rub => "rub",
                CustomerProvisionParamsBillingCurrency.Rwf => "rwf",
                CustomerProvisionParamsBillingCurrency.Sar => "sar",
                CustomerProvisionParamsBillingCurrency.Sbd => "sbd",
                CustomerProvisionParamsBillingCurrency.Scr => "scr",
                CustomerProvisionParamsBillingCurrency.Sek => "sek",
                CustomerProvisionParamsBillingCurrency.Sgd => "sgd",
                CustomerProvisionParamsBillingCurrency.Sle => "sle",
                CustomerProvisionParamsBillingCurrency.Sll => "sll",
                CustomerProvisionParamsBillingCurrency.Sos => "sos",
                CustomerProvisionParamsBillingCurrency.Szl => "szl",
                CustomerProvisionParamsBillingCurrency.Thb => "thb",
                CustomerProvisionParamsBillingCurrency.Tjs => "tjs",
                CustomerProvisionParamsBillingCurrency.Top => "top",
                CustomerProvisionParamsBillingCurrency.Try => "try",
                CustomerProvisionParamsBillingCurrency.Ttd => "ttd",
                CustomerProvisionParamsBillingCurrency.Tzs => "tzs",
                CustomerProvisionParamsBillingCurrency.Uah => "uah",
                CustomerProvisionParamsBillingCurrency.Uzs => "uzs",
                CustomerProvisionParamsBillingCurrency.Vnd => "vnd",
                CustomerProvisionParamsBillingCurrency.Vuv => "vuv",
                CustomerProvisionParamsBillingCurrency.Wst => "wst",
                CustomerProvisionParamsBillingCurrency.Xaf => "xaf",
                CustomerProvisionParamsBillingCurrency.Xcd => "xcd",
                CustomerProvisionParamsBillingCurrency.Yer => "yer",
                CustomerProvisionParamsBillingCurrency.Zar => "zar",
                CustomerProvisionParamsBillingCurrency.Zmw => "zmw",
                CustomerProvisionParamsBillingCurrency.Clp => "clp",
                CustomerProvisionParamsBillingCurrency.Djf => "djf",
                CustomerProvisionParamsBillingCurrency.Gnf => "gnf",
                CustomerProvisionParamsBillingCurrency.Ugx => "ugx",
                CustomerProvisionParamsBillingCurrency.Pyg => "pyg",
                CustomerProvisionParamsBillingCurrency.Xof => "xof",
                CustomerProvisionParamsBillingCurrency.Xpf => "xpf",
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
[JsonConverter(typeof(JsonModelConverter<DefaultPaymentMethod, DefaultPaymentMethodFromRaw>))]
public sealed record class DefaultPaymentMethod : JsonModel
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
    public required ApiEnum<string, global::Stigg.Client.Models.V1.Customers.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Stigg.Client.Models.V1.Customers.Type>
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

    public DefaultPaymentMethod() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DefaultPaymentMethod(DefaultPaymentMethod defaultPaymentMethod)
        : base(defaultPaymentMethod) { }
#pragma warning restore CS8618

    public DefaultPaymentMethod(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DefaultPaymentMethod(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DefaultPaymentMethodFromRaw.FromRawUnchecked"/>
    public static DefaultPaymentMethod FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DefaultPaymentMethodFromRaw : IFromRawJson<DefaultPaymentMethod>
{
    /// <inheritdoc/>
    public DefaultPaymentMethod FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DefaultPaymentMethod.FromRawUnchecked(rawData);
}

/// <summary>
/// The default payment method type
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Card,
    Bank,
    CashApp,
}

sealed class TypeConverter : JsonConverter<global::Stigg.Client.Models.V1.Customers.Type>
{
    public override global::Stigg.Client.Models.V1.Customers.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "CARD" => global::Stigg.Client.Models.V1.Customers.Type.Card,
            "BANK" => global::Stigg.Client.Models.V1.Customers.Type.Bank,
            "CASH_APP" => global::Stigg.Client.Models.V1.Customers.Type.CashApp,
            _ => (global::Stigg.Client.Models.V1.Customers.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Stigg.Client.Models.V1.Customers.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Stigg.Client.Models.V1.Customers.Type.Card => "CARD",
                global::Stigg.Client.Models.V1.Customers.Type.Bank => "BANK",
                global::Stigg.Client.Models.V1.Customers.Type.CashApp => "CASH_APP",
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
        CustomerProvisionParamsIntegration,
        CustomerProvisionParamsIntegrationFromRaw
    >)
)]
public sealed record class CustomerProvisionParamsIntegration : JsonModel
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
        CustomerProvisionParamsIntegrationVendorIdentifier
    > VendorIdentifier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, CustomerProvisionParamsIntegrationVendorIdentifier>
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

    public CustomerProvisionParamsIntegration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerProvisionParamsIntegration(
        CustomerProvisionParamsIntegration customerProvisionParamsIntegration
    )
        : base(customerProvisionParamsIntegration) { }
#pragma warning restore CS8618

    public CustomerProvisionParamsIntegration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerProvisionParamsIntegration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerProvisionParamsIntegrationFromRaw.FromRawUnchecked"/>
    public static CustomerProvisionParamsIntegration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerProvisionParamsIntegrationFromRaw : IFromRawJson<CustomerProvisionParamsIntegration>
{
    /// <inheritdoc/>
    public CustomerProvisionParamsIntegration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerProvisionParamsIntegration.FromRawUnchecked(rawData);
}

/// <summary>
/// The vendor identifier of integration
/// </summary>
[JsonConverter(typeof(CustomerProvisionParamsIntegrationVendorIdentifierConverter))]
public enum CustomerProvisionParamsIntegrationVendorIdentifier
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

sealed class CustomerProvisionParamsIntegrationVendorIdentifierConverter
    : JsonConverter<CustomerProvisionParamsIntegrationVendorIdentifier>
{
    public override CustomerProvisionParamsIntegrationVendorIdentifier Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "AUTH0" => CustomerProvisionParamsIntegrationVendorIdentifier.Auth0,
            "ZUORA" => CustomerProvisionParamsIntegrationVendorIdentifier.Zuora,
            "STRIPE" => CustomerProvisionParamsIntegrationVendorIdentifier.Stripe,
            "HUBSPOT" => CustomerProvisionParamsIntegrationVendorIdentifier.Hubspot,
            "AWS_MARKETPLACE" => CustomerProvisionParamsIntegrationVendorIdentifier.AwsMarketplace,
            "SNOWFLAKE" => CustomerProvisionParamsIntegrationVendorIdentifier.Snowflake,
            "SALESFORCE" => CustomerProvisionParamsIntegrationVendorIdentifier.Salesforce,
            "BIG_QUERY" => CustomerProvisionParamsIntegrationVendorIdentifier.BigQuery,
            "OPEN_FGA" => CustomerProvisionParamsIntegrationVendorIdentifier.OpenFga,
            "APP_STORE" => CustomerProvisionParamsIntegrationVendorIdentifier.AppStore,
            _ => (CustomerProvisionParamsIntegrationVendorIdentifier)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CustomerProvisionParamsIntegrationVendorIdentifier value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CustomerProvisionParamsIntegrationVendorIdentifier.Auth0 => "AUTH0",
                CustomerProvisionParamsIntegrationVendorIdentifier.Zuora => "ZUORA",
                CustomerProvisionParamsIntegrationVendorIdentifier.Stripe => "STRIPE",
                CustomerProvisionParamsIntegrationVendorIdentifier.Hubspot => "HUBSPOT",
                CustomerProvisionParamsIntegrationVendorIdentifier.AwsMarketplace =>
                    "AWS_MARKETPLACE",
                CustomerProvisionParamsIntegrationVendorIdentifier.Snowflake => "SNOWFLAKE",
                CustomerProvisionParamsIntegrationVendorIdentifier.Salesforce => "SALESFORCE",
                CustomerProvisionParamsIntegrationVendorIdentifier.BigQuery => "BIG_QUERY",
                CustomerProvisionParamsIntegrationVendorIdentifier.OpenFga => "OPEN_FGA",
                CustomerProvisionParamsIntegrationVendorIdentifier.AppStore => "APP_STORE",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
