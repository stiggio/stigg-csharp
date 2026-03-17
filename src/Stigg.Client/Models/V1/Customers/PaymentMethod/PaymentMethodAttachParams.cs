using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using System = System;

namespace Stigg.Client.Models.V1.Customers.PaymentMethod;

/// <summary>
/// Attaches a payment method to a customer for billing. Required for paid subscriptions
/// when integrated with a billing provider.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class PaymentMethodAttachParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

    /// <summary>
    /// Integration details
    /// </summary>
    public required string IntegrationID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("integrationId");
        }
        init { this._rawBodyData.Set("integrationId", value); }
    }

    /// <summary>
    /// Billing provider payment method id
    /// </summary>
    public required string PaymentMethodID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("paymentMethodId");
        }
        init { this._rawBodyData.Set("paymentMethodId", value); }
    }

    /// <summary>
    /// The vendor identifier of integration
    /// </summary>
    public required ApiEnum<string, VendorIdentifier> VendorIdentifier
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, VendorIdentifier>>(
                "vendorIdentifier"
            );
        }
        init { this._rawBodyData.Set("vendorIdentifier", value); }
    }

    /// <summary>
    /// Customers selected currency
    /// </summary>
    public ApiEnum<string, BillingCurrency>? BillingCurrency
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, BillingCurrency>>(
                "billingCurrency"
            );
        }
        init { this._rawBodyData.Set("billingCurrency", value); }
    }

    public PaymentMethodAttachParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PaymentMethodAttachParams(PaymentMethodAttachParams paymentMethodAttachParams)
        : base(paymentMethodAttachParams)
    {
        this.ID = paymentMethodAttachParams.ID;

        this._rawBodyData = new(paymentMethodAttachParams._rawBodyData);
    }
#pragma warning restore CS8618

    public PaymentMethodAttachParams(
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
    PaymentMethodAttachParams(
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
    public static PaymentMethodAttachParams FromRawUnchecked(
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
                    ["ID"] = JsonSerializer.SerializeToElement(this.ID),
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

    public virtual bool Equals(PaymentMethodAttachParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ID?.Equals(other.ID) ?? other.ID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/api/v1/customers/{0}/payment-method", this.ID)
        )
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
/// The vendor identifier of integration
/// </summary>
[JsonConverter(typeof(VendorIdentifierConverter))]
public enum VendorIdentifier
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

sealed class VendorIdentifierConverter : JsonConverter<VendorIdentifier>
{
    public override VendorIdentifier Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "AUTH0" => VendorIdentifier.Auth0,
            "ZUORA" => VendorIdentifier.Zuora,
            "STRIPE" => VendorIdentifier.Stripe,
            "HUBSPOT" => VendorIdentifier.Hubspot,
            "AWS_MARKETPLACE" => VendorIdentifier.AwsMarketplace,
            "SNOWFLAKE" => VendorIdentifier.Snowflake,
            "SALESFORCE" => VendorIdentifier.Salesforce,
            "BIG_QUERY" => VendorIdentifier.BigQuery,
            "OPEN_FGA" => VendorIdentifier.OpenFga,
            "APP_STORE" => VendorIdentifier.AppStore,
            _ => (VendorIdentifier)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VendorIdentifier value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VendorIdentifier.Auth0 => "AUTH0",
                VendorIdentifier.Zuora => "ZUORA",
                VendorIdentifier.Stripe => "STRIPE",
                VendorIdentifier.Hubspot => "HUBSPOT",
                VendorIdentifier.AwsMarketplace => "AWS_MARKETPLACE",
                VendorIdentifier.Snowflake => "SNOWFLAKE",
                VendorIdentifier.Salesforce => "SALESFORCE",
                VendorIdentifier.BigQuery => "BIG_QUERY",
                VendorIdentifier.OpenFga => "OPEN_FGA",
                VendorIdentifier.AppStore => "APP_STORE",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Customers selected currency
/// </summary>
[JsonConverter(typeof(BillingCurrencyConverter))]
public enum BillingCurrency
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

sealed class BillingCurrencyConverter : JsonConverter<BillingCurrency>
{
    public override BillingCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => BillingCurrency.Usd,
            "aed" => BillingCurrency.Aed,
            "all" => BillingCurrency.All,
            "amd" => BillingCurrency.Amd,
            "ang" => BillingCurrency.Ang,
            "aud" => BillingCurrency.Aud,
            "awg" => BillingCurrency.Awg,
            "azn" => BillingCurrency.Azn,
            "bam" => BillingCurrency.Bam,
            "bbd" => BillingCurrency.Bbd,
            "bdt" => BillingCurrency.Bdt,
            "bgn" => BillingCurrency.Bgn,
            "bif" => BillingCurrency.Bif,
            "bmd" => BillingCurrency.Bmd,
            "bnd" => BillingCurrency.Bnd,
            "bsd" => BillingCurrency.Bsd,
            "bwp" => BillingCurrency.Bwp,
            "byn" => BillingCurrency.Byn,
            "bzd" => BillingCurrency.Bzd,
            "brl" => BillingCurrency.Brl,
            "cad" => BillingCurrency.Cad,
            "cdf" => BillingCurrency.Cdf,
            "chf" => BillingCurrency.Chf,
            "cny" => BillingCurrency.Cny,
            "czk" => BillingCurrency.Czk,
            "dkk" => BillingCurrency.Dkk,
            "dop" => BillingCurrency.Dop,
            "dzd" => BillingCurrency.Dzd,
            "egp" => BillingCurrency.Egp,
            "etb" => BillingCurrency.Etb,
            "eur" => BillingCurrency.Eur,
            "fjd" => BillingCurrency.Fjd,
            "gbp" => BillingCurrency.Gbp,
            "gel" => BillingCurrency.Gel,
            "gip" => BillingCurrency.Gip,
            "gmd" => BillingCurrency.Gmd,
            "gyd" => BillingCurrency.Gyd,
            "hkd" => BillingCurrency.Hkd,
            "hrk" => BillingCurrency.Hrk,
            "htg" => BillingCurrency.Htg,
            "idr" => BillingCurrency.Idr,
            "ils" => BillingCurrency.Ils,
            "inr" => BillingCurrency.Inr,
            "isk" => BillingCurrency.Isk,
            "jmd" => BillingCurrency.Jmd,
            "jpy" => BillingCurrency.Jpy,
            "kes" => BillingCurrency.Kes,
            "kgs" => BillingCurrency.Kgs,
            "khr" => BillingCurrency.Khr,
            "kmf" => BillingCurrency.Kmf,
            "krw" => BillingCurrency.Krw,
            "kyd" => BillingCurrency.Kyd,
            "kzt" => BillingCurrency.Kzt,
            "lbp" => BillingCurrency.Lbp,
            "lkr" => BillingCurrency.Lkr,
            "lrd" => BillingCurrency.Lrd,
            "lsl" => BillingCurrency.Lsl,
            "mad" => BillingCurrency.Mad,
            "mdl" => BillingCurrency.Mdl,
            "mga" => BillingCurrency.Mga,
            "mkd" => BillingCurrency.Mkd,
            "mmk" => BillingCurrency.Mmk,
            "mnt" => BillingCurrency.Mnt,
            "mop" => BillingCurrency.Mop,
            "mro" => BillingCurrency.Mro,
            "mvr" => BillingCurrency.Mvr,
            "mwk" => BillingCurrency.Mwk,
            "mxn" => BillingCurrency.Mxn,
            "myr" => BillingCurrency.Myr,
            "mzn" => BillingCurrency.Mzn,
            "nad" => BillingCurrency.Nad,
            "ngn" => BillingCurrency.Ngn,
            "nok" => BillingCurrency.Nok,
            "npr" => BillingCurrency.Npr,
            "nzd" => BillingCurrency.Nzd,
            "pgk" => BillingCurrency.Pgk,
            "php" => BillingCurrency.Php,
            "pkr" => BillingCurrency.Pkr,
            "pln" => BillingCurrency.Pln,
            "qar" => BillingCurrency.Qar,
            "ron" => BillingCurrency.Ron,
            "rsd" => BillingCurrency.Rsd,
            "rub" => BillingCurrency.Rub,
            "rwf" => BillingCurrency.Rwf,
            "sar" => BillingCurrency.Sar,
            "sbd" => BillingCurrency.Sbd,
            "scr" => BillingCurrency.Scr,
            "sek" => BillingCurrency.Sek,
            "sgd" => BillingCurrency.Sgd,
            "sle" => BillingCurrency.Sle,
            "sll" => BillingCurrency.Sll,
            "sos" => BillingCurrency.Sos,
            "szl" => BillingCurrency.Szl,
            "thb" => BillingCurrency.Thb,
            "tjs" => BillingCurrency.Tjs,
            "top" => BillingCurrency.Top,
            "try" => BillingCurrency.Try,
            "ttd" => BillingCurrency.Ttd,
            "tzs" => BillingCurrency.Tzs,
            "uah" => BillingCurrency.Uah,
            "uzs" => BillingCurrency.Uzs,
            "vnd" => BillingCurrency.Vnd,
            "vuv" => BillingCurrency.Vuv,
            "wst" => BillingCurrency.Wst,
            "xaf" => BillingCurrency.Xaf,
            "xcd" => BillingCurrency.Xcd,
            "yer" => BillingCurrency.Yer,
            "zar" => BillingCurrency.Zar,
            "zmw" => BillingCurrency.Zmw,
            "clp" => BillingCurrency.Clp,
            "djf" => BillingCurrency.Djf,
            "gnf" => BillingCurrency.Gnf,
            "ugx" => BillingCurrency.Ugx,
            "pyg" => BillingCurrency.Pyg,
            "xof" => BillingCurrency.Xof,
            "xpf" => BillingCurrency.Xpf,
            _ => (BillingCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BillingCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BillingCurrency.Usd => "usd",
                BillingCurrency.Aed => "aed",
                BillingCurrency.All => "all",
                BillingCurrency.Amd => "amd",
                BillingCurrency.Ang => "ang",
                BillingCurrency.Aud => "aud",
                BillingCurrency.Awg => "awg",
                BillingCurrency.Azn => "azn",
                BillingCurrency.Bam => "bam",
                BillingCurrency.Bbd => "bbd",
                BillingCurrency.Bdt => "bdt",
                BillingCurrency.Bgn => "bgn",
                BillingCurrency.Bif => "bif",
                BillingCurrency.Bmd => "bmd",
                BillingCurrency.Bnd => "bnd",
                BillingCurrency.Bsd => "bsd",
                BillingCurrency.Bwp => "bwp",
                BillingCurrency.Byn => "byn",
                BillingCurrency.Bzd => "bzd",
                BillingCurrency.Brl => "brl",
                BillingCurrency.Cad => "cad",
                BillingCurrency.Cdf => "cdf",
                BillingCurrency.Chf => "chf",
                BillingCurrency.Cny => "cny",
                BillingCurrency.Czk => "czk",
                BillingCurrency.Dkk => "dkk",
                BillingCurrency.Dop => "dop",
                BillingCurrency.Dzd => "dzd",
                BillingCurrency.Egp => "egp",
                BillingCurrency.Etb => "etb",
                BillingCurrency.Eur => "eur",
                BillingCurrency.Fjd => "fjd",
                BillingCurrency.Gbp => "gbp",
                BillingCurrency.Gel => "gel",
                BillingCurrency.Gip => "gip",
                BillingCurrency.Gmd => "gmd",
                BillingCurrency.Gyd => "gyd",
                BillingCurrency.Hkd => "hkd",
                BillingCurrency.Hrk => "hrk",
                BillingCurrency.Htg => "htg",
                BillingCurrency.Idr => "idr",
                BillingCurrency.Ils => "ils",
                BillingCurrency.Inr => "inr",
                BillingCurrency.Isk => "isk",
                BillingCurrency.Jmd => "jmd",
                BillingCurrency.Jpy => "jpy",
                BillingCurrency.Kes => "kes",
                BillingCurrency.Kgs => "kgs",
                BillingCurrency.Khr => "khr",
                BillingCurrency.Kmf => "kmf",
                BillingCurrency.Krw => "krw",
                BillingCurrency.Kyd => "kyd",
                BillingCurrency.Kzt => "kzt",
                BillingCurrency.Lbp => "lbp",
                BillingCurrency.Lkr => "lkr",
                BillingCurrency.Lrd => "lrd",
                BillingCurrency.Lsl => "lsl",
                BillingCurrency.Mad => "mad",
                BillingCurrency.Mdl => "mdl",
                BillingCurrency.Mga => "mga",
                BillingCurrency.Mkd => "mkd",
                BillingCurrency.Mmk => "mmk",
                BillingCurrency.Mnt => "mnt",
                BillingCurrency.Mop => "mop",
                BillingCurrency.Mro => "mro",
                BillingCurrency.Mvr => "mvr",
                BillingCurrency.Mwk => "mwk",
                BillingCurrency.Mxn => "mxn",
                BillingCurrency.Myr => "myr",
                BillingCurrency.Mzn => "mzn",
                BillingCurrency.Nad => "nad",
                BillingCurrency.Ngn => "ngn",
                BillingCurrency.Nok => "nok",
                BillingCurrency.Npr => "npr",
                BillingCurrency.Nzd => "nzd",
                BillingCurrency.Pgk => "pgk",
                BillingCurrency.Php => "php",
                BillingCurrency.Pkr => "pkr",
                BillingCurrency.Pln => "pln",
                BillingCurrency.Qar => "qar",
                BillingCurrency.Ron => "ron",
                BillingCurrency.Rsd => "rsd",
                BillingCurrency.Rub => "rub",
                BillingCurrency.Rwf => "rwf",
                BillingCurrency.Sar => "sar",
                BillingCurrency.Sbd => "sbd",
                BillingCurrency.Scr => "scr",
                BillingCurrency.Sek => "sek",
                BillingCurrency.Sgd => "sgd",
                BillingCurrency.Sle => "sle",
                BillingCurrency.Sll => "sll",
                BillingCurrency.Sos => "sos",
                BillingCurrency.Szl => "szl",
                BillingCurrency.Thb => "thb",
                BillingCurrency.Tjs => "tjs",
                BillingCurrency.Top => "top",
                BillingCurrency.Try => "try",
                BillingCurrency.Ttd => "ttd",
                BillingCurrency.Tzs => "tzs",
                BillingCurrency.Uah => "uah",
                BillingCurrency.Uzs => "uzs",
                BillingCurrency.Vnd => "vnd",
                BillingCurrency.Vuv => "vuv",
                BillingCurrency.Wst => "wst",
                BillingCurrency.Xaf => "xaf",
                BillingCurrency.Xcd => "xcd",
                BillingCurrency.Yer => "yer",
                BillingCurrency.Zar => "zar",
                BillingCurrency.Zmw => "zmw",
                BillingCurrency.Clp => "clp",
                BillingCurrency.Djf => "djf",
                BillingCurrency.Gnf => "gnf",
                BillingCurrency.Ugx => "ugx",
                BillingCurrency.Pyg => "pyg",
                BillingCurrency.Xof => "xof",
                BillingCurrency.Xpf => "xpf",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
