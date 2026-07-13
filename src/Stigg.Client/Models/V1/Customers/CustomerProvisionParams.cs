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
/// Creates a new customer.
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
    public ApiEnum<string, CustomerProvisionParamsCouponID>? CouponID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<
                ApiEnum<string, CustomerProvisionParamsCouponID>
            >("couponId");
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
    /// Language to use for this customer
    /// </summary>
    public string? Language
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("language");
        }
        init { this._rawBodyData.Set("language", value); }
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

    /// <summary>
    /// Vendor-specific billing passthrough fields.
    /// </summary>
    public CustomerProvisionParamsPassthrough? Passthrough
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<CustomerProvisionParamsPassthrough>(
                "passthrough"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("passthrough", value);
        }
    }

    /// <summary>
    /// Timezone to use for this customer
    /// </summary>
    public string? Timezone
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("timezone");
        }
        init { this._rawBodyData.Set("timezone", value); }
    }

    public string? XAccountID
    {
        get
        {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNullableClass<string>("X-ACCOUNT-ID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawHeaderData.Set("X-ACCOUNT-ID", value);
        }
    }

    public string? XEnvironmentID
    {
        get
        {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNullableClass<string>("X-ENVIRONMENT-ID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawHeaderData.Set("X-ENVIRONMENT-ID", value);
        }
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

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
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
/// Customer level coupon
/// </summary>
[JsonConverter(typeof(CustomerProvisionParamsCouponIDConverter))]
public enum CustomerProvisionParamsCouponID
{
    Undefined,
}

sealed class CustomerProvisionParamsCouponIDConverter
    : JsonConverter<CustomerProvisionParamsCouponID>
{
    public override CustomerProvisionParamsCouponID Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "" => CustomerProvisionParamsCouponID.Undefined,
            _ => (CustomerProvisionParamsCouponID)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CustomerProvisionParamsCouponID value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CustomerProvisionParamsCouponID.Undefined => "",
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
    Received,
    Prequel,
    Airwallex,
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
            "RECEIVED" => CustomerProvisionParamsIntegrationVendorIdentifier.Received,
            "PREQUEL" => CustomerProvisionParamsIntegrationVendorIdentifier.Prequel,
            "AIRWALLEX" => CustomerProvisionParamsIntegrationVendorIdentifier.Airwallex,
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
                CustomerProvisionParamsIntegrationVendorIdentifier.Received => "RECEIVED",
                CustomerProvisionParamsIntegrationVendorIdentifier.Prequel => "PREQUEL",
                CustomerProvisionParamsIntegrationVendorIdentifier.Airwallex => "AIRWALLEX",
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
        CustomerProvisionParamsPassthrough,
        CustomerProvisionParamsPassthroughFromRaw
    >)
)]
public sealed record class CustomerProvisionParamsPassthrough : JsonModel
{
    /// <summary>
    /// Stripe-specific billing fields for the customer.
    /// </summary>
    public CustomerProvisionParamsPassthroughStripe? Stripe
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CustomerProvisionParamsPassthroughStripe>(
                "stripe"
            );
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
    public CustomerProvisionParamsPassthroughZuora? Zuora
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CustomerProvisionParamsPassthroughZuora>("zuora");
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

    public CustomerProvisionParamsPassthrough() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerProvisionParamsPassthrough(
        CustomerProvisionParamsPassthrough customerProvisionParamsPassthrough
    )
        : base(customerProvisionParamsPassthrough) { }
#pragma warning restore CS8618

    public CustomerProvisionParamsPassthrough(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerProvisionParamsPassthrough(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerProvisionParamsPassthroughFromRaw.FromRawUnchecked"/>
    public static CustomerProvisionParamsPassthrough FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerProvisionParamsPassthroughFromRaw : IFromRawJson<CustomerProvisionParamsPassthrough>
{
    /// <inheritdoc/>
    public CustomerProvisionParamsPassthrough FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerProvisionParamsPassthrough.FromRawUnchecked(rawData);
}

/// <summary>
/// Stripe-specific billing fields for the customer.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CustomerProvisionParamsPassthroughStripe,
        CustomerProvisionParamsPassthroughStripeFromRaw
    >)
)]
public sealed record class CustomerProvisionParamsPassthroughStripe : JsonModel
{
    /// <summary>
    /// Physical address
    /// </summary>
    public CustomerProvisionParamsPassthroughStripeBillingAddress? BillingAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CustomerProvisionParamsPassthroughStripeBillingAddress>(
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
    public CustomerProvisionParamsPassthroughStripeShippingAddress? ShippingAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CustomerProvisionParamsPassthroughStripeShippingAddress>(
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
    public IReadOnlyList<CustomerProvisionParamsPassthroughStripeTaxID>? TaxIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<CustomerProvisionParamsPassthroughStripeTaxID>
            >("taxIds");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<CustomerProvisionParamsPassthroughStripeTaxID>?>(
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

    public CustomerProvisionParamsPassthroughStripe() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerProvisionParamsPassthroughStripe(
        CustomerProvisionParamsPassthroughStripe customerProvisionParamsPassthroughStripe
    )
        : base(customerProvisionParamsPassthroughStripe) { }
#pragma warning restore CS8618

    public CustomerProvisionParamsPassthroughStripe(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerProvisionParamsPassthroughStripe(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerProvisionParamsPassthroughStripeFromRaw.FromRawUnchecked"/>
    public static CustomerProvisionParamsPassthroughStripe FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerProvisionParamsPassthroughStripeFromRaw
    : IFromRawJson<CustomerProvisionParamsPassthroughStripe>
{
    /// <inheritdoc/>
    public CustomerProvisionParamsPassthroughStripe FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerProvisionParamsPassthroughStripe.FromRawUnchecked(rawData);
}

/// <summary>
/// Physical address
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CustomerProvisionParamsPassthroughStripeBillingAddress,
        CustomerProvisionParamsPassthroughStripeBillingAddressFromRaw
    >)
)]
public sealed record class CustomerProvisionParamsPassthroughStripeBillingAddress : JsonModel
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

    public CustomerProvisionParamsPassthroughStripeBillingAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerProvisionParamsPassthroughStripeBillingAddress(
        CustomerProvisionParamsPassthroughStripeBillingAddress customerProvisionParamsPassthroughStripeBillingAddress
    )
        : base(customerProvisionParamsPassthroughStripeBillingAddress) { }
#pragma warning restore CS8618

    public CustomerProvisionParamsPassthroughStripeBillingAddress(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerProvisionParamsPassthroughStripeBillingAddress(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerProvisionParamsPassthroughStripeBillingAddressFromRaw.FromRawUnchecked"/>
    public static CustomerProvisionParamsPassthroughStripeBillingAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerProvisionParamsPassthroughStripeBillingAddressFromRaw
    : IFromRawJson<CustomerProvisionParamsPassthroughStripeBillingAddress>
{
    /// <inheritdoc/>
    public CustomerProvisionParamsPassthroughStripeBillingAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerProvisionParamsPassthroughStripeBillingAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// Physical address
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CustomerProvisionParamsPassthroughStripeShippingAddress,
        CustomerProvisionParamsPassthroughStripeShippingAddressFromRaw
    >)
)]
public sealed record class CustomerProvisionParamsPassthroughStripeShippingAddress : JsonModel
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

    public CustomerProvisionParamsPassthroughStripeShippingAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerProvisionParamsPassthroughStripeShippingAddress(
        CustomerProvisionParamsPassthroughStripeShippingAddress customerProvisionParamsPassthroughStripeShippingAddress
    )
        : base(customerProvisionParamsPassthroughStripeShippingAddress) { }
#pragma warning restore CS8618

    public CustomerProvisionParamsPassthroughStripeShippingAddress(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerProvisionParamsPassthroughStripeShippingAddress(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerProvisionParamsPassthroughStripeShippingAddressFromRaw.FromRawUnchecked"/>
    public static CustomerProvisionParamsPassthroughStripeShippingAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerProvisionParamsPassthroughStripeShippingAddressFromRaw
    : IFromRawJson<CustomerProvisionParamsPassthroughStripeShippingAddress>
{
    /// <inheritdoc/>
    public CustomerProvisionParamsPassthroughStripeShippingAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerProvisionParamsPassthroughStripeShippingAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// Tax identifier with type and value for customer tax exemptions.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CustomerProvisionParamsPassthroughStripeTaxID,
        CustomerProvisionParamsPassthroughStripeTaxIDFromRaw
    >)
)]
public sealed record class CustomerProvisionParamsPassthroughStripeTaxID : JsonModel
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

    public CustomerProvisionParamsPassthroughStripeTaxID() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerProvisionParamsPassthroughStripeTaxID(
        CustomerProvisionParamsPassthroughStripeTaxID customerProvisionParamsPassthroughStripeTaxID
    )
        : base(customerProvisionParamsPassthroughStripeTaxID) { }
#pragma warning restore CS8618

    public CustomerProvisionParamsPassthroughStripeTaxID(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerProvisionParamsPassthroughStripeTaxID(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerProvisionParamsPassthroughStripeTaxIDFromRaw.FromRawUnchecked"/>
    public static CustomerProvisionParamsPassthroughStripeTaxID FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerProvisionParamsPassthroughStripeTaxIDFromRaw
    : IFromRawJson<CustomerProvisionParamsPassthroughStripeTaxID>
{
    /// <inheritdoc/>
    public CustomerProvisionParamsPassthroughStripeTaxID FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerProvisionParamsPassthroughStripeTaxID.FromRawUnchecked(rawData);
}

/// <summary>
/// Zuora-specific billing fields for the customer.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CustomerProvisionParamsPassthroughZuora,
        CustomerProvisionParamsPassthroughZuoraFromRaw
    >)
)]
public sealed record class CustomerProvisionParamsPassthroughZuora : JsonModel
{
    /// <summary>
    /// Physical address
    /// </summary>
    public CustomerProvisionParamsPassthroughZuoraBillingAddress? BillingAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CustomerProvisionParamsPassthroughZuoraBillingAddress>(
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
    public ApiEnum<string, CustomerProvisionParamsPassthroughZuoraCurrency>? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, CustomerProvisionParamsPassthroughZuoraCurrency>
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

    public CustomerProvisionParamsPassthroughZuora() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerProvisionParamsPassthroughZuora(
        CustomerProvisionParamsPassthroughZuora customerProvisionParamsPassthroughZuora
    )
        : base(customerProvisionParamsPassthroughZuora) { }
#pragma warning restore CS8618

    public CustomerProvisionParamsPassthroughZuora(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerProvisionParamsPassthroughZuora(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerProvisionParamsPassthroughZuoraFromRaw.FromRawUnchecked"/>
    public static CustomerProvisionParamsPassthroughZuora FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerProvisionParamsPassthroughZuoraFromRaw
    : IFromRawJson<CustomerProvisionParamsPassthroughZuora>
{
    /// <inheritdoc/>
    public CustomerProvisionParamsPassthroughZuora FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerProvisionParamsPassthroughZuora.FromRawUnchecked(rawData);
}

/// <summary>
/// Physical address
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CustomerProvisionParamsPassthroughZuoraBillingAddress,
        CustomerProvisionParamsPassthroughZuoraBillingAddressFromRaw
    >)
)]
public sealed record class CustomerProvisionParamsPassthroughZuoraBillingAddress : JsonModel
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

    public CustomerProvisionParamsPassthroughZuoraBillingAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerProvisionParamsPassthroughZuoraBillingAddress(
        CustomerProvisionParamsPassthroughZuoraBillingAddress customerProvisionParamsPassthroughZuoraBillingAddress
    )
        : base(customerProvisionParamsPassthroughZuoraBillingAddress) { }
#pragma warning restore CS8618

    public CustomerProvisionParamsPassthroughZuoraBillingAddress(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerProvisionParamsPassthroughZuoraBillingAddress(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerProvisionParamsPassthroughZuoraBillingAddressFromRaw.FromRawUnchecked"/>
    public static CustomerProvisionParamsPassthroughZuoraBillingAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerProvisionParamsPassthroughZuoraBillingAddressFromRaw
    : IFromRawJson<CustomerProvisionParamsPassthroughZuoraBillingAddress>
{
    /// <inheritdoc/>
    public CustomerProvisionParamsPassthroughZuoraBillingAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerProvisionParamsPassthroughZuoraBillingAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// Customers selected currency
/// </summary>
[JsonConverter(typeof(CustomerProvisionParamsPassthroughZuoraCurrencyConverter))]
public enum CustomerProvisionParamsPassthroughZuoraCurrency
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

sealed class CustomerProvisionParamsPassthroughZuoraCurrencyConverter
    : JsonConverter<CustomerProvisionParamsPassthroughZuoraCurrency>
{
    public override CustomerProvisionParamsPassthroughZuoraCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => CustomerProvisionParamsPassthroughZuoraCurrency.Usd,
            "aed" => CustomerProvisionParamsPassthroughZuoraCurrency.Aed,
            "all" => CustomerProvisionParamsPassthroughZuoraCurrency.All,
            "amd" => CustomerProvisionParamsPassthroughZuoraCurrency.Amd,
            "ang" => CustomerProvisionParamsPassthroughZuoraCurrency.Ang,
            "aud" => CustomerProvisionParamsPassthroughZuoraCurrency.Aud,
            "awg" => CustomerProvisionParamsPassthroughZuoraCurrency.Awg,
            "azn" => CustomerProvisionParamsPassthroughZuoraCurrency.Azn,
            "bam" => CustomerProvisionParamsPassthroughZuoraCurrency.Bam,
            "bbd" => CustomerProvisionParamsPassthroughZuoraCurrency.Bbd,
            "bdt" => CustomerProvisionParamsPassthroughZuoraCurrency.Bdt,
            "bgn" => CustomerProvisionParamsPassthroughZuoraCurrency.Bgn,
            "bif" => CustomerProvisionParamsPassthroughZuoraCurrency.Bif,
            "bmd" => CustomerProvisionParamsPassthroughZuoraCurrency.Bmd,
            "bnd" => CustomerProvisionParamsPassthroughZuoraCurrency.Bnd,
            "bsd" => CustomerProvisionParamsPassthroughZuoraCurrency.Bsd,
            "bwp" => CustomerProvisionParamsPassthroughZuoraCurrency.Bwp,
            "byn" => CustomerProvisionParamsPassthroughZuoraCurrency.Byn,
            "bzd" => CustomerProvisionParamsPassthroughZuoraCurrency.Bzd,
            "brl" => CustomerProvisionParamsPassthroughZuoraCurrency.Brl,
            "cad" => CustomerProvisionParamsPassthroughZuoraCurrency.Cad,
            "cdf" => CustomerProvisionParamsPassthroughZuoraCurrency.Cdf,
            "chf" => CustomerProvisionParamsPassthroughZuoraCurrency.Chf,
            "cny" => CustomerProvisionParamsPassthroughZuoraCurrency.Cny,
            "czk" => CustomerProvisionParamsPassthroughZuoraCurrency.Czk,
            "dkk" => CustomerProvisionParamsPassthroughZuoraCurrency.Dkk,
            "dop" => CustomerProvisionParamsPassthroughZuoraCurrency.Dop,
            "dzd" => CustomerProvisionParamsPassthroughZuoraCurrency.Dzd,
            "egp" => CustomerProvisionParamsPassthroughZuoraCurrency.Egp,
            "etb" => CustomerProvisionParamsPassthroughZuoraCurrency.Etb,
            "eur" => CustomerProvisionParamsPassthroughZuoraCurrency.Eur,
            "fjd" => CustomerProvisionParamsPassthroughZuoraCurrency.Fjd,
            "gbp" => CustomerProvisionParamsPassthroughZuoraCurrency.Gbp,
            "gel" => CustomerProvisionParamsPassthroughZuoraCurrency.Gel,
            "gip" => CustomerProvisionParamsPassthroughZuoraCurrency.Gip,
            "gmd" => CustomerProvisionParamsPassthroughZuoraCurrency.Gmd,
            "gyd" => CustomerProvisionParamsPassthroughZuoraCurrency.Gyd,
            "hkd" => CustomerProvisionParamsPassthroughZuoraCurrency.Hkd,
            "hrk" => CustomerProvisionParamsPassthroughZuoraCurrency.Hrk,
            "htg" => CustomerProvisionParamsPassthroughZuoraCurrency.Htg,
            "idr" => CustomerProvisionParamsPassthroughZuoraCurrency.Idr,
            "ils" => CustomerProvisionParamsPassthroughZuoraCurrency.Ils,
            "inr" => CustomerProvisionParamsPassthroughZuoraCurrency.Inr,
            "isk" => CustomerProvisionParamsPassthroughZuoraCurrency.Isk,
            "jmd" => CustomerProvisionParamsPassthroughZuoraCurrency.Jmd,
            "jpy" => CustomerProvisionParamsPassthroughZuoraCurrency.Jpy,
            "kes" => CustomerProvisionParamsPassthroughZuoraCurrency.Kes,
            "kgs" => CustomerProvisionParamsPassthroughZuoraCurrency.Kgs,
            "khr" => CustomerProvisionParamsPassthroughZuoraCurrency.Khr,
            "kmf" => CustomerProvisionParamsPassthroughZuoraCurrency.Kmf,
            "krw" => CustomerProvisionParamsPassthroughZuoraCurrency.Krw,
            "kyd" => CustomerProvisionParamsPassthroughZuoraCurrency.Kyd,
            "kzt" => CustomerProvisionParamsPassthroughZuoraCurrency.Kzt,
            "lbp" => CustomerProvisionParamsPassthroughZuoraCurrency.Lbp,
            "lkr" => CustomerProvisionParamsPassthroughZuoraCurrency.Lkr,
            "lrd" => CustomerProvisionParamsPassthroughZuoraCurrency.Lrd,
            "lsl" => CustomerProvisionParamsPassthroughZuoraCurrency.Lsl,
            "mad" => CustomerProvisionParamsPassthroughZuoraCurrency.Mad,
            "mdl" => CustomerProvisionParamsPassthroughZuoraCurrency.Mdl,
            "mga" => CustomerProvisionParamsPassthroughZuoraCurrency.Mga,
            "mkd" => CustomerProvisionParamsPassthroughZuoraCurrency.Mkd,
            "mmk" => CustomerProvisionParamsPassthroughZuoraCurrency.Mmk,
            "mnt" => CustomerProvisionParamsPassthroughZuoraCurrency.Mnt,
            "mop" => CustomerProvisionParamsPassthroughZuoraCurrency.Mop,
            "mro" => CustomerProvisionParamsPassthroughZuoraCurrency.Mro,
            "mvr" => CustomerProvisionParamsPassthroughZuoraCurrency.Mvr,
            "mwk" => CustomerProvisionParamsPassthroughZuoraCurrency.Mwk,
            "mxn" => CustomerProvisionParamsPassthroughZuoraCurrency.Mxn,
            "myr" => CustomerProvisionParamsPassthroughZuoraCurrency.Myr,
            "mzn" => CustomerProvisionParamsPassthroughZuoraCurrency.Mzn,
            "nad" => CustomerProvisionParamsPassthroughZuoraCurrency.Nad,
            "ngn" => CustomerProvisionParamsPassthroughZuoraCurrency.Ngn,
            "nok" => CustomerProvisionParamsPassthroughZuoraCurrency.Nok,
            "npr" => CustomerProvisionParamsPassthroughZuoraCurrency.Npr,
            "nzd" => CustomerProvisionParamsPassthroughZuoraCurrency.Nzd,
            "pgk" => CustomerProvisionParamsPassthroughZuoraCurrency.Pgk,
            "php" => CustomerProvisionParamsPassthroughZuoraCurrency.Php,
            "pkr" => CustomerProvisionParamsPassthroughZuoraCurrency.Pkr,
            "pln" => CustomerProvisionParamsPassthroughZuoraCurrency.Pln,
            "qar" => CustomerProvisionParamsPassthroughZuoraCurrency.Qar,
            "ron" => CustomerProvisionParamsPassthroughZuoraCurrency.Ron,
            "rsd" => CustomerProvisionParamsPassthroughZuoraCurrency.Rsd,
            "rub" => CustomerProvisionParamsPassthroughZuoraCurrency.Rub,
            "rwf" => CustomerProvisionParamsPassthroughZuoraCurrency.Rwf,
            "sar" => CustomerProvisionParamsPassthroughZuoraCurrency.Sar,
            "sbd" => CustomerProvisionParamsPassthroughZuoraCurrency.Sbd,
            "scr" => CustomerProvisionParamsPassthroughZuoraCurrency.Scr,
            "sek" => CustomerProvisionParamsPassthroughZuoraCurrency.Sek,
            "sgd" => CustomerProvisionParamsPassthroughZuoraCurrency.Sgd,
            "sle" => CustomerProvisionParamsPassthroughZuoraCurrency.Sle,
            "sll" => CustomerProvisionParamsPassthroughZuoraCurrency.Sll,
            "sos" => CustomerProvisionParamsPassthroughZuoraCurrency.Sos,
            "szl" => CustomerProvisionParamsPassthroughZuoraCurrency.Szl,
            "thb" => CustomerProvisionParamsPassthroughZuoraCurrency.Thb,
            "tjs" => CustomerProvisionParamsPassthroughZuoraCurrency.Tjs,
            "top" => CustomerProvisionParamsPassthroughZuoraCurrency.Top,
            "try" => CustomerProvisionParamsPassthroughZuoraCurrency.Try,
            "ttd" => CustomerProvisionParamsPassthroughZuoraCurrency.Ttd,
            "tzs" => CustomerProvisionParamsPassthroughZuoraCurrency.Tzs,
            "uah" => CustomerProvisionParamsPassthroughZuoraCurrency.Uah,
            "uzs" => CustomerProvisionParamsPassthroughZuoraCurrency.Uzs,
            "vnd" => CustomerProvisionParamsPassthroughZuoraCurrency.Vnd,
            "vuv" => CustomerProvisionParamsPassthroughZuoraCurrency.Vuv,
            "wst" => CustomerProvisionParamsPassthroughZuoraCurrency.Wst,
            "xaf" => CustomerProvisionParamsPassthroughZuoraCurrency.Xaf,
            "xcd" => CustomerProvisionParamsPassthroughZuoraCurrency.Xcd,
            "yer" => CustomerProvisionParamsPassthroughZuoraCurrency.Yer,
            "zar" => CustomerProvisionParamsPassthroughZuoraCurrency.Zar,
            "zmw" => CustomerProvisionParamsPassthroughZuoraCurrency.Zmw,
            "clp" => CustomerProvisionParamsPassthroughZuoraCurrency.Clp,
            "djf" => CustomerProvisionParamsPassthroughZuoraCurrency.Djf,
            "gnf" => CustomerProvisionParamsPassthroughZuoraCurrency.Gnf,
            "ugx" => CustomerProvisionParamsPassthroughZuoraCurrency.Ugx,
            "pyg" => CustomerProvisionParamsPassthroughZuoraCurrency.Pyg,
            "xof" => CustomerProvisionParamsPassthroughZuoraCurrency.Xof,
            "xpf" => CustomerProvisionParamsPassthroughZuoraCurrency.Xpf,
            _ => (CustomerProvisionParamsPassthroughZuoraCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CustomerProvisionParamsPassthroughZuoraCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CustomerProvisionParamsPassthroughZuoraCurrency.Usd => "usd",
                CustomerProvisionParamsPassthroughZuoraCurrency.Aed => "aed",
                CustomerProvisionParamsPassthroughZuoraCurrency.All => "all",
                CustomerProvisionParamsPassthroughZuoraCurrency.Amd => "amd",
                CustomerProvisionParamsPassthroughZuoraCurrency.Ang => "ang",
                CustomerProvisionParamsPassthroughZuoraCurrency.Aud => "aud",
                CustomerProvisionParamsPassthroughZuoraCurrency.Awg => "awg",
                CustomerProvisionParamsPassthroughZuoraCurrency.Azn => "azn",
                CustomerProvisionParamsPassthroughZuoraCurrency.Bam => "bam",
                CustomerProvisionParamsPassthroughZuoraCurrency.Bbd => "bbd",
                CustomerProvisionParamsPassthroughZuoraCurrency.Bdt => "bdt",
                CustomerProvisionParamsPassthroughZuoraCurrency.Bgn => "bgn",
                CustomerProvisionParamsPassthroughZuoraCurrency.Bif => "bif",
                CustomerProvisionParamsPassthroughZuoraCurrency.Bmd => "bmd",
                CustomerProvisionParamsPassthroughZuoraCurrency.Bnd => "bnd",
                CustomerProvisionParamsPassthroughZuoraCurrency.Bsd => "bsd",
                CustomerProvisionParamsPassthroughZuoraCurrency.Bwp => "bwp",
                CustomerProvisionParamsPassthroughZuoraCurrency.Byn => "byn",
                CustomerProvisionParamsPassthroughZuoraCurrency.Bzd => "bzd",
                CustomerProvisionParamsPassthroughZuoraCurrency.Brl => "brl",
                CustomerProvisionParamsPassthroughZuoraCurrency.Cad => "cad",
                CustomerProvisionParamsPassthroughZuoraCurrency.Cdf => "cdf",
                CustomerProvisionParamsPassthroughZuoraCurrency.Chf => "chf",
                CustomerProvisionParamsPassthroughZuoraCurrency.Cny => "cny",
                CustomerProvisionParamsPassthroughZuoraCurrency.Czk => "czk",
                CustomerProvisionParamsPassthroughZuoraCurrency.Dkk => "dkk",
                CustomerProvisionParamsPassthroughZuoraCurrency.Dop => "dop",
                CustomerProvisionParamsPassthroughZuoraCurrency.Dzd => "dzd",
                CustomerProvisionParamsPassthroughZuoraCurrency.Egp => "egp",
                CustomerProvisionParamsPassthroughZuoraCurrency.Etb => "etb",
                CustomerProvisionParamsPassthroughZuoraCurrency.Eur => "eur",
                CustomerProvisionParamsPassthroughZuoraCurrency.Fjd => "fjd",
                CustomerProvisionParamsPassthroughZuoraCurrency.Gbp => "gbp",
                CustomerProvisionParamsPassthroughZuoraCurrency.Gel => "gel",
                CustomerProvisionParamsPassthroughZuoraCurrency.Gip => "gip",
                CustomerProvisionParamsPassthroughZuoraCurrency.Gmd => "gmd",
                CustomerProvisionParamsPassthroughZuoraCurrency.Gyd => "gyd",
                CustomerProvisionParamsPassthroughZuoraCurrency.Hkd => "hkd",
                CustomerProvisionParamsPassthroughZuoraCurrency.Hrk => "hrk",
                CustomerProvisionParamsPassthroughZuoraCurrency.Htg => "htg",
                CustomerProvisionParamsPassthroughZuoraCurrency.Idr => "idr",
                CustomerProvisionParamsPassthroughZuoraCurrency.Ils => "ils",
                CustomerProvisionParamsPassthroughZuoraCurrency.Inr => "inr",
                CustomerProvisionParamsPassthroughZuoraCurrency.Isk => "isk",
                CustomerProvisionParamsPassthroughZuoraCurrency.Jmd => "jmd",
                CustomerProvisionParamsPassthroughZuoraCurrency.Jpy => "jpy",
                CustomerProvisionParamsPassthroughZuoraCurrency.Kes => "kes",
                CustomerProvisionParamsPassthroughZuoraCurrency.Kgs => "kgs",
                CustomerProvisionParamsPassthroughZuoraCurrency.Khr => "khr",
                CustomerProvisionParamsPassthroughZuoraCurrency.Kmf => "kmf",
                CustomerProvisionParamsPassthroughZuoraCurrency.Krw => "krw",
                CustomerProvisionParamsPassthroughZuoraCurrency.Kyd => "kyd",
                CustomerProvisionParamsPassthroughZuoraCurrency.Kzt => "kzt",
                CustomerProvisionParamsPassthroughZuoraCurrency.Lbp => "lbp",
                CustomerProvisionParamsPassthroughZuoraCurrency.Lkr => "lkr",
                CustomerProvisionParamsPassthroughZuoraCurrency.Lrd => "lrd",
                CustomerProvisionParamsPassthroughZuoraCurrency.Lsl => "lsl",
                CustomerProvisionParamsPassthroughZuoraCurrency.Mad => "mad",
                CustomerProvisionParamsPassthroughZuoraCurrency.Mdl => "mdl",
                CustomerProvisionParamsPassthroughZuoraCurrency.Mga => "mga",
                CustomerProvisionParamsPassthroughZuoraCurrency.Mkd => "mkd",
                CustomerProvisionParamsPassthroughZuoraCurrency.Mmk => "mmk",
                CustomerProvisionParamsPassthroughZuoraCurrency.Mnt => "mnt",
                CustomerProvisionParamsPassthroughZuoraCurrency.Mop => "mop",
                CustomerProvisionParamsPassthroughZuoraCurrency.Mro => "mro",
                CustomerProvisionParamsPassthroughZuoraCurrency.Mvr => "mvr",
                CustomerProvisionParamsPassthroughZuoraCurrency.Mwk => "mwk",
                CustomerProvisionParamsPassthroughZuoraCurrency.Mxn => "mxn",
                CustomerProvisionParamsPassthroughZuoraCurrency.Myr => "myr",
                CustomerProvisionParamsPassthroughZuoraCurrency.Mzn => "mzn",
                CustomerProvisionParamsPassthroughZuoraCurrency.Nad => "nad",
                CustomerProvisionParamsPassthroughZuoraCurrency.Ngn => "ngn",
                CustomerProvisionParamsPassthroughZuoraCurrency.Nok => "nok",
                CustomerProvisionParamsPassthroughZuoraCurrency.Npr => "npr",
                CustomerProvisionParamsPassthroughZuoraCurrency.Nzd => "nzd",
                CustomerProvisionParamsPassthroughZuoraCurrency.Pgk => "pgk",
                CustomerProvisionParamsPassthroughZuoraCurrency.Php => "php",
                CustomerProvisionParamsPassthroughZuoraCurrency.Pkr => "pkr",
                CustomerProvisionParamsPassthroughZuoraCurrency.Pln => "pln",
                CustomerProvisionParamsPassthroughZuoraCurrency.Qar => "qar",
                CustomerProvisionParamsPassthroughZuoraCurrency.Ron => "ron",
                CustomerProvisionParamsPassthroughZuoraCurrency.Rsd => "rsd",
                CustomerProvisionParamsPassthroughZuoraCurrency.Rub => "rub",
                CustomerProvisionParamsPassthroughZuoraCurrency.Rwf => "rwf",
                CustomerProvisionParamsPassthroughZuoraCurrency.Sar => "sar",
                CustomerProvisionParamsPassthroughZuoraCurrency.Sbd => "sbd",
                CustomerProvisionParamsPassthroughZuoraCurrency.Scr => "scr",
                CustomerProvisionParamsPassthroughZuoraCurrency.Sek => "sek",
                CustomerProvisionParamsPassthroughZuoraCurrency.Sgd => "sgd",
                CustomerProvisionParamsPassthroughZuoraCurrency.Sle => "sle",
                CustomerProvisionParamsPassthroughZuoraCurrency.Sll => "sll",
                CustomerProvisionParamsPassthroughZuoraCurrency.Sos => "sos",
                CustomerProvisionParamsPassthroughZuoraCurrency.Szl => "szl",
                CustomerProvisionParamsPassthroughZuoraCurrency.Thb => "thb",
                CustomerProvisionParamsPassthroughZuoraCurrency.Tjs => "tjs",
                CustomerProvisionParamsPassthroughZuoraCurrency.Top => "top",
                CustomerProvisionParamsPassthroughZuoraCurrency.Try => "try",
                CustomerProvisionParamsPassthroughZuoraCurrency.Ttd => "ttd",
                CustomerProvisionParamsPassthroughZuoraCurrency.Tzs => "tzs",
                CustomerProvisionParamsPassthroughZuoraCurrency.Uah => "uah",
                CustomerProvisionParamsPassthroughZuoraCurrency.Uzs => "uzs",
                CustomerProvisionParamsPassthroughZuoraCurrency.Vnd => "vnd",
                CustomerProvisionParamsPassthroughZuoraCurrency.Vuv => "vuv",
                CustomerProvisionParamsPassthroughZuoraCurrency.Wst => "wst",
                CustomerProvisionParamsPassthroughZuoraCurrency.Xaf => "xaf",
                CustomerProvisionParamsPassthroughZuoraCurrency.Xcd => "xcd",
                CustomerProvisionParamsPassthroughZuoraCurrency.Yer => "yer",
                CustomerProvisionParamsPassthroughZuoraCurrency.Zar => "zar",
                CustomerProvisionParamsPassthroughZuoraCurrency.Zmw => "zmw",
                CustomerProvisionParamsPassthroughZuoraCurrency.Clp => "clp",
                CustomerProvisionParamsPassthroughZuoraCurrency.Djf => "djf",
                CustomerProvisionParamsPassthroughZuoraCurrency.Gnf => "gnf",
                CustomerProvisionParamsPassthroughZuoraCurrency.Ugx => "ugx",
                CustomerProvisionParamsPassthroughZuoraCurrency.Pyg => "pyg",
                CustomerProvisionParamsPassthroughZuoraCurrency.Xof => "xof",
                CustomerProvisionParamsPassthroughZuoraCurrency.Xpf => "xpf",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
