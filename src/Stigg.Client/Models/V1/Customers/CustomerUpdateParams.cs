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
/// Updates an existing customer's properties such as name, email, and billing information.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CustomerUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

    /// <summary>
    /// The billing currency of the customer
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
    public ApiEnum<string, CouponID>? CouponID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, CouponID>>("couponId");
        }
        init { this._rawBodyData.Set("couponId", value); }
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
    public IReadOnlyList<Integration>? Integrations
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<Integration>>("integrations");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<Integration>?>(
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
    public Passthrough? Passthrough
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Passthrough>("passthrough");
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

    public CustomerUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerUpdateParams(CustomerUpdateParams customerUpdateParams)
        : base(customerUpdateParams)
    {
        this.ID = customerUpdateParams.ID;

        this._rawBodyData = new(customerUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public CustomerUpdateParams(
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
    CustomerUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string id
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.ID = id;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static CustomerUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string id
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            id
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

    public virtual bool Equals(CustomerUpdateParams? other)
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
                + string.Format("/api/v1/customers/{0}", this.ID)
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
/// The billing currency of the customer
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

/// <summary>
/// Customer level coupon
/// </summary>
[JsonConverter(typeof(CouponIDConverter))]
public enum CouponID
{
    Undefined,
}

sealed class CouponIDConverter : JsonConverter<CouponID>
{
    public override CouponID Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "" => CouponID.Undefined,
            _ => (CouponID)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, CouponID value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CouponID.Undefined => "",
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
[JsonConverter(typeof(JsonModelConverter<Integration, IntegrationFromRaw>))]
public sealed record class Integration : JsonModel
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
    public required ApiEnum<string, VendorIdentifier> VendorIdentifier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, VendorIdentifier>>(
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

    public Integration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Integration(Integration integration)
        : base(integration) { }
#pragma warning restore CS8618

    public Integration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Integration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IntegrationFromRaw.FromRawUnchecked"/>
    public static Integration FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IntegrationFromRaw : IFromRawJson<Integration>
{
    /// <inheritdoc/>
    public Integration FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Integration.FromRawUnchecked(rawData);
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
    Received,
    Prequel,
    Airwallex,
    StripeInvoicing,
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
            "RECEIVED" => VendorIdentifier.Received,
            "PREQUEL" => VendorIdentifier.Prequel,
            "AIRWALLEX" => VendorIdentifier.Airwallex,
            "STRIPE_INVOICING" => VendorIdentifier.StripeInvoicing,
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
                VendorIdentifier.Received => "RECEIVED",
                VendorIdentifier.Prequel => "PREQUEL",
                VendorIdentifier.Airwallex => "AIRWALLEX",
                VendorIdentifier.StripeInvoicing => "STRIPE_INVOICING",
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
[JsonConverter(typeof(JsonModelConverter<Passthrough, PassthroughFromRaw>))]
public sealed record class Passthrough : JsonModel
{
    /// <summary>
    /// Stripe-specific billing fields for the customer.
    /// </summary>
    public Stripe? Stripe
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Stripe>("stripe");
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
    public Zuora? Zuora
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Zuora>("zuora");
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

    public Passthrough() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Passthrough(Passthrough passthrough)
        : base(passthrough) { }
#pragma warning restore CS8618

    public Passthrough(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Passthrough(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PassthroughFromRaw.FromRawUnchecked"/>
    public static Passthrough FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PassthroughFromRaw : IFromRawJson<Passthrough>
{
    /// <inheritdoc/>
    public Passthrough FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Passthrough.FromRawUnchecked(rawData);
}

/// <summary>
/// Stripe-specific billing fields for the customer.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Stripe, StripeFromRaw>))]
public sealed record class Stripe : JsonModel
{
    /// <summary>
    /// Physical address
    /// </summary>
    public BillingAddress? BillingAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BillingAddress>("billingAddress");
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
    public ShippingAddress? ShippingAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ShippingAddress>("shippingAddress");
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
    public IReadOnlyList<TaxID>? TaxIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<TaxID>>("taxIds");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<TaxID>?>(
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

    public Stripe() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Stripe(Stripe stripe)
        : base(stripe) { }
#pragma warning restore CS8618

    public Stripe(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Stripe(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StripeFromRaw.FromRawUnchecked"/>
    public static Stripe FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class StripeFromRaw : IFromRawJson<Stripe>
{
    /// <inheritdoc/>
    public Stripe FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Stripe.FromRawUnchecked(rawData);
}

/// <summary>
/// Physical address
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BillingAddress, BillingAddressFromRaw>))]
public sealed record class BillingAddress : JsonModel
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

    public BillingAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BillingAddress(BillingAddress billingAddress)
        : base(billingAddress) { }
#pragma warning restore CS8618

    public BillingAddress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BillingAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BillingAddressFromRaw.FromRawUnchecked"/>
    public static BillingAddress FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BillingAddressFromRaw : IFromRawJson<BillingAddress>
{
    /// <inheritdoc/>
    public BillingAddress FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BillingAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// Physical address
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ShippingAddress, ShippingAddressFromRaw>))]
public sealed record class ShippingAddress : JsonModel
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

    public ShippingAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ShippingAddress(ShippingAddress shippingAddress)
        : base(shippingAddress) { }
#pragma warning restore CS8618

    public ShippingAddress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ShippingAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ShippingAddressFromRaw.FromRawUnchecked"/>
    public static ShippingAddress FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ShippingAddressFromRaw : IFromRawJson<ShippingAddress>
{
    /// <inheritdoc/>
    public ShippingAddress FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ShippingAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// Tax identifier with type and value for customer tax exemptions.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TaxID, TaxIDFromRaw>))]
public sealed record class TaxID : JsonModel
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

    public TaxID() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TaxID(TaxID taxID)
        : base(taxID) { }
#pragma warning restore CS8618

    public TaxID(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TaxID(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TaxIDFromRaw.FromRawUnchecked"/>
    public static TaxID FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TaxIDFromRaw : IFromRawJson<TaxID>
{
    /// <inheritdoc/>
    public TaxID FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TaxID.FromRawUnchecked(rawData);
}

/// <summary>
/// Zuora-specific billing fields for the customer.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Zuora, ZuoraFromRaw>))]
public sealed record class Zuora : JsonModel
{
    /// <summary>
    /// Physical address
    /// </summary>
    public ZuoraBillingAddress? BillingAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ZuoraBillingAddress>("billingAddress");
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
    public ApiEnum<string, Currency>? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Currency>>("currency");
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

    public Zuora() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Zuora(Zuora zuora)
        : base(zuora) { }
#pragma warning restore CS8618

    public Zuora(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Zuora(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ZuoraFromRaw.FromRawUnchecked"/>
    public static Zuora FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ZuoraFromRaw : IFromRawJson<Zuora>
{
    /// <inheritdoc/>
    public Zuora FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Zuora.FromRawUnchecked(rawData);
}

/// <summary>
/// Physical address
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ZuoraBillingAddress, ZuoraBillingAddressFromRaw>))]
public sealed record class ZuoraBillingAddress : JsonModel
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

    public ZuoraBillingAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ZuoraBillingAddress(ZuoraBillingAddress zuoraBillingAddress)
        : base(zuoraBillingAddress) { }
#pragma warning restore CS8618

    public ZuoraBillingAddress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ZuoraBillingAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ZuoraBillingAddressFromRaw.FromRawUnchecked"/>
    public static ZuoraBillingAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ZuoraBillingAddressFromRaw : IFromRawJson<ZuoraBillingAddress>
{
    /// <inheritdoc/>
    public ZuoraBillingAddress FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ZuoraBillingAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// Customers selected currency
/// </summary>
[JsonConverter(typeof(CurrencyConverter))]
public enum Currency
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

sealed class CurrencyConverter : JsonConverter<Currency>
{
    public override Currency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => Currency.Usd,
            "aed" => Currency.Aed,
            "all" => Currency.All,
            "amd" => Currency.Amd,
            "ang" => Currency.Ang,
            "aud" => Currency.Aud,
            "awg" => Currency.Awg,
            "azn" => Currency.Azn,
            "bam" => Currency.Bam,
            "bbd" => Currency.Bbd,
            "bdt" => Currency.Bdt,
            "bgn" => Currency.Bgn,
            "bif" => Currency.Bif,
            "bmd" => Currency.Bmd,
            "bnd" => Currency.Bnd,
            "bsd" => Currency.Bsd,
            "bwp" => Currency.Bwp,
            "byn" => Currency.Byn,
            "bzd" => Currency.Bzd,
            "brl" => Currency.Brl,
            "cad" => Currency.Cad,
            "cdf" => Currency.Cdf,
            "chf" => Currency.Chf,
            "cny" => Currency.Cny,
            "czk" => Currency.Czk,
            "dkk" => Currency.Dkk,
            "dop" => Currency.Dop,
            "dzd" => Currency.Dzd,
            "egp" => Currency.Egp,
            "etb" => Currency.Etb,
            "eur" => Currency.Eur,
            "fjd" => Currency.Fjd,
            "gbp" => Currency.Gbp,
            "gel" => Currency.Gel,
            "gip" => Currency.Gip,
            "gmd" => Currency.Gmd,
            "gyd" => Currency.Gyd,
            "hkd" => Currency.Hkd,
            "hrk" => Currency.Hrk,
            "htg" => Currency.Htg,
            "idr" => Currency.Idr,
            "ils" => Currency.Ils,
            "inr" => Currency.Inr,
            "isk" => Currency.Isk,
            "jmd" => Currency.Jmd,
            "jpy" => Currency.Jpy,
            "kes" => Currency.Kes,
            "kgs" => Currency.Kgs,
            "khr" => Currency.Khr,
            "kmf" => Currency.Kmf,
            "krw" => Currency.Krw,
            "kyd" => Currency.Kyd,
            "kzt" => Currency.Kzt,
            "lbp" => Currency.Lbp,
            "lkr" => Currency.Lkr,
            "lrd" => Currency.Lrd,
            "lsl" => Currency.Lsl,
            "mad" => Currency.Mad,
            "mdl" => Currency.Mdl,
            "mga" => Currency.Mga,
            "mkd" => Currency.Mkd,
            "mmk" => Currency.Mmk,
            "mnt" => Currency.Mnt,
            "mop" => Currency.Mop,
            "mro" => Currency.Mro,
            "mvr" => Currency.Mvr,
            "mwk" => Currency.Mwk,
            "mxn" => Currency.Mxn,
            "myr" => Currency.Myr,
            "mzn" => Currency.Mzn,
            "nad" => Currency.Nad,
            "ngn" => Currency.Ngn,
            "nok" => Currency.Nok,
            "npr" => Currency.Npr,
            "nzd" => Currency.Nzd,
            "pgk" => Currency.Pgk,
            "php" => Currency.Php,
            "pkr" => Currency.Pkr,
            "pln" => Currency.Pln,
            "qar" => Currency.Qar,
            "ron" => Currency.Ron,
            "rsd" => Currency.Rsd,
            "rub" => Currency.Rub,
            "rwf" => Currency.Rwf,
            "sar" => Currency.Sar,
            "sbd" => Currency.Sbd,
            "scr" => Currency.Scr,
            "sek" => Currency.Sek,
            "sgd" => Currency.Sgd,
            "sle" => Currency.Sle,
            "sll" => Currency.Sll,
            "sos" => Currency.Sos,
            "szl" => Currency.Szl,
            "thb" => Currency.Thb,
            "tjs" => Currency.Tjs,
            "top" => Currency.Top,
            "try" => Currency.Try,
            "ttd" => Currency.Ttd,
            "tzs" => Currency.Tzs,
            "uah" => Currency.Uah,
            "uzs" => Currency.Uzs,
            "vnd" => Currency.Vnd,
            "vuv" => Currency.Vuv,
            "wst" => Currency.Wst,
            "xaf" => Currency.Xaf,
            "xcd" => Currency.Xcd,
            "yer" => Currency.Yer,
            "zar" => Currency.Zar,
            "zmw" => Currency.Zmw,
            "clp" => Currency.Clp,
            "djf" => Currency.Djf,
            "gnf" => Currency.Gnf,
            "ugx" => Currency.Ugx,
            "pyg" => Currency.Pyg,
            "xof" => Currency.Xof,
            "xpf" => Currency.Xpf,
            _ => (Currency)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Currency value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Currency.Usd => "usd",
                Currency.Aed => "aed",
                Currency.All => "all",
                Currency.Amd => "amd",
                Currency.Ang => "ang",
                Currency.Aud => "aud",
                Currency.Awg => "awg",
                Currency.Azn => "azn",
                Currency.Bam => "bam",
                Currency.Bbd => "bbd",
                Currency.Bdt => "bdt",
                Currency.Bgn => "bgn",
                Currency.Bif => "bif",
                Currency.Bmd => "bmd",
                Currency.Bnd => "bnd",
                Currency.Bsd => "bsd",
                Currency.Bwp => "bwp",
                Currency.Byn => "byn",
                Currency.Bzd => "bzd",
                Currency.Brl => "brl",
                Currency.Cad => "cad",
                Currency.Cdf => "cdf",
                Currency.Chf => "chf",
                Currency.Cny => "cny",
                Currency.Czk => "czk",
                Currency.Dkk => "dkk",
                Currency.Dop => "dop",
                Currency.Dzd => "dzd",
                Currency.Egp => "egp",
                Currency.Etb => "etb",
                Currency.Eur => "eur",
                Currency.Fjd => "fjd",
                Currency.Gbp => "gbp",
                Currency.Gel => "gel",
                Currency.Gip => "gip",
                Currency.Gmd => "gmd",
                Currency.Gyd => "gyd",
                Currency.Hkd => "hkd",
                Currency.Hrk => "hrk",
                Currency.Htg => "htg",
                Currency.Idr => "idr",
                Currency.Ils => "ils",
                Currency.Inr => "inr",
                Currency.Isk => "isk",
                Currency.Jmd => "jmd",
                Currency.Jpy => "jpy",
                Currency.Kes => "kes",
                Currency.Kgs => "kgs",
                Currency.Khr => "khr",
                Currency.Kmf => "kmf",
                Currency.Krw => "krw",
                Currency.Kyd => "kyd",
                Currency.Kzt => "kzt",
                Currency.Lbp => "lbp",
                Currency.Lkr => "lkr",
                Currency.Lrd => "lrd",
                Currency.Lsl => "lsl",
                Currency.Mad => "mad",
                Currency.Mdl => "mdl",
                Currency.Mga => "mga",
                Currency.Mkd => "mkd",
                Currency.Mmk => "mmk",
                Currency.Mnt => "mnt",
                Currency.Mop => "mop",
                Currency.Mro => "mro",
                Currency.Mvr => "mvr",
                Currency.Mwk => "mwk",
                Currency.Mxn => "mxn",
                Currency.Myr => "myr",
                Currency.Mzn => "mzn",
                Currency.Nad => "nad",
                Currency.Ngn => "ngn",
                Currency.Nok => "nok",
                Currency.Npr => "npr",
                Currency.Nzd => "nzd",
                Currency.Pgk => "pgk",
                Currency.Php => "php",
                Currency.Pkr => "pkr",
                Currency.Pln => "pln",
                Currency.Qar => "qar",
                Currency.Ron => "ron",
                Currency.Rsd => "rsd",
                Currency.Rub => "rub",
                Currency.Rwf => "rwf",
                Currency.Sar => "sar",
                Currency.Sbd => "sbd",
                Currency.Scr => "scr",
                Currency.Sek => "sek",
                Currency.Sgd => "sgd",
                Currency.Sle => "sle",
                Currency.Sll => "sll",
                Currency.Sos => "sos",
                Currency.Szl => "szl",
                Currency.Thb => "thb",
                Currency.Tjs => "tjs",
                Currency.Top => "top",
                Currency.Try => "try",
                Currency.Ttd => "ttd",
                Currency.Tzs => "tzs",
                Currency.Uah => "uah",
                Currency.Uzs => "uzs",
                Currency.Vnd => "vnd",
                Currency.Vuv => "vuv",
                Currency.Wst => "wst",
                Currency.Xaf => "xaf",
                Currency.Xcd => "xcd",
                Currency.Yer => "yer",
                Currency.Zar => "zar",
                Currency.Zmw => "zmw",
                Currency.Clp => "clp",
                Currency.Djf => "djf",
                Currency.Gnf => "gnf",
                Currency.Ugx => "ugx",
                Currency.Pyg => "pyg",
                Currency.Xof => "xof",
                Currency.Xpf => "xpf",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
