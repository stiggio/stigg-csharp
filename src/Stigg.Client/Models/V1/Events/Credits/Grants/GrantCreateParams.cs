using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;

namespace Stigg.Client.Models.V1.Events.Credits.Grants;

/// <summary>
/// Creates a new credit grant for a customer with specified amount, type, and optional
/// billing configuration.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class GrantCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The credit amount to grant
    /// </summary>
    public required double Amount
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<double>("amount");
        }
        init { this._rawBodyData.Set("amount", value); }
    }

    /// <summary>
    /// The credit currency ID (required)
    /// </summary>
    public required string CurrencyID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("currencyId");
        }
        init { this._rawBodyData.Set("currencyId", value); }
    }

    /// <summary>
    /// The customer ID to grant credits to (required)
    /// </summary>
    public required string CustomerID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("customerId");
        }
        init { this._rawBodyData.Set("customerId", value); }
    }

    /// <summary>
    /// The display name for the credit grant
    /// </summary>
    public required string DisplayName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("displayName");
        }
        init { this._rawBodyData.Set("displayName", value); }
    }

    /// <summary>
    /// The type of credit grant (PAID, PROMOTIONAL, RECURRING)
    /// </summary>
    public required ApiEnum<string, GrantType> GrantType
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, GrantType>>("grantType");
        }
        init { this._rawBodyData.Set("grantType", value); }
    }

    /// <summary>
    /// Whether to wait for payment confirmation before returning (default: true)
    /// </summary>
    public bool? AwaitPaymentConfirmation
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("awaitPaymentConfirmation");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("awaitPaymentConfirmation", value);
        }
    }

    /// <summary>
    /// Billing information for the credit grant
    /// </summary>
    public BillingInformation? BillingInformation
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<BillingInformation>("billingInformation");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("billingInformation", value);
        }
    }

    /// <summary>
    /// An optional comment on the credit grant
    /// </summary>
    public string? Comment
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("comment");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("comment", value);
        }
    }

    /// <summary>
    /// The monetary cost of the credit grant
    /// </summary>
    public Cost? Cost
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Cost>("cost");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("cost", value);
        }
    }

    /// <summary>
    /// The date when the credit grant becomes effective
    /// </summary>
    public DateTimeOffset? EffectiveAt
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<DateTimeOffset>("effectiveAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("effectiveAt", value);
        }
    }

    /// <summary>
    /// The date when the credit grant expires
    /// </summary>
    public DateTimeOffset? ExpireAt
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<DateTimeOffset>("expireAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("expireAt", value);
        }
    }

    /// <summary>
    /// Additional metadata for the credit grant
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
    /// The payment collection method (CHARGE, INVOICE, NONE)
    /// </summary>
    public ApiEnum<string, PaymentCollectionMethod>? PaymentCollectionMethod
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, PaymentCollectionMethod>>(
                "paymentCollectionMethod"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("paymentCollectionMethod", value);
        }
    }

    /// <summary>
    /// The priority of the credit grant (lower number = higher priority)
    /// </summary>
    public long? Priority
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("priority");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("priority", value);
        }
    }

    /// <summary>
    /// The resource ID to scope the grant to
    /// </summary>
    public string? ResourceID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("resourceId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("resourceId", value);
        }
    }

    public GrantCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GrantCreateParams(GrantCreateParams grantCreateParams)
        : base(grantCreateParams)
    {
        this._rawBodyData = new(grantCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public GrantCreateParams(
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
    GrantCreateParams(
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
    public static GrantCreateParams FromRawUnchecked(
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

    public virtual bool Equals(GrantCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/api/v1/credits/grants")
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
/// The type of credit grant (PAID, PROMOTIONAL, RECURRING)
/// </summary>
[JsonConverter(typeof(GrantTypeConverter))]
public enum GrantType
{
    Paid,
    Promotional,
    Recurring,
}

sealed class GrantTypeConverter : JsonConverter<GrantType>
{
    public override GrantType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PAID" => GrantType.Paid,
            "PROMOTIONAL" => GrantType.Promotional,
            "RECURRING" => GrantType.Recurring,
            _ => (GrantType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        GrantType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                GrantType.Paid => "PAID",
                GrantType.Promotional => "PROMOTIONAL",
                GrantType.Recurring => "RECURRING",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Billing information for the credit grant
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BillingInformation, BillingInformationFromRaw>))]
public sealed record class BillingInformation : JsonModel
{
    /// <summary>
    /// The billing address
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
    /// Days until the invoice is due
    /// </summary>
    public double? InvoiceDaysUntilDue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("invoiceDaysUntilDue");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("invoiceDaysUntilDue", value);
        }
    }

    /// <summary>
    /// Whether the invoice is already paid
    /// </summary>
    public bool? IsInvoicePaid
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isInvoicePaid");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isInvoicePaid", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.BillingAddress?.Validate();
        _ = this.InvoiceDaysUntilDue;
        _ = this.IsInvoicePaid;
    }

    public BillingInformation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BillingInformation(BillingInformation billingInformation)
        : base(billingInformation) { }
#pragma warning restore CS8618

    public BillingInformation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BillingInformation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BillingInformationFromRaw.FromRawUnchecked"/>
    public static BillingInformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BillingInformationFromRaw : IFromRawJson<BillingInformation>
{
    /// <inheritdoc/>
    public BillingInformation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BillingInformation.FromRawUnchecked(rawData);
}

/// <summary>
/// The billing address
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
/// The monetary cost of the credit grant
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Cost, CostFromRaw>))]
public sealed record class Cost : JsonModel
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
    /// ISO 4217 currency code
    /// </summary>
    public required ApiEnum<string, Currency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Currency>>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        this.Currency.Validate();
    }

    public Cost() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Cost(Cost cost)
        : base(cost) { }
#pragma warning restore CS8618

    public Cost(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Cost(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CostFromRaw.FromRawUnchecked"/>
    public static Cost FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CostFromRaw : IFromRawJson<Cost>
{
    /// <inheritdoc/>
    public Cost FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Cost.FromRawUnchecked(rawData);
}

/// <summary>
/// ISO 4217 currency code
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
        Type typeToConvert,
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

/// <summary>
/// The payment collection method (CHARGE, INVOICE, NONE)
/// </summary>
[JsonConverter(typeof(PaymentCollectionMethodConverter))]
public enum PaymentCollectionMethod
{
    Charge,
    Invoice,
    None,
}

sealed class PaymentCollectionMethodConverter : JsonConverter<PaymentCollectionMethod>
{
    public override PaymentCollectionMethod Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "CHARGE" => PaymentCollectionMethod.Charge,
            "INVOICE" => PaymentCollectionMethod.Invoice,
            "NONE" => PaymentCollectionMethod.None,
            _ => (PaymentCollectionMethod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PaymentCollectionMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PaymentCollectionMethod.Charge => "CHARGE",
                PaymentCollectionMethod.Invoice => "INVOICE",
                PaymentCollectionMethod.None => "NONE",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
