using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using System = System;

namespace Stigg.Client.Models.V1.Contracts;

/// <summary>
/// Response object
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ContractUpdateResponse, ContractUpdateResponseFromRaw>))]
public sealed record class ContractUpdateResponse : JsonModel
{
    /// <summary>
    /// A billing contract as reported by the connected billing provider.
    /// </summary>
    public required ContractUpdateResponseData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ContractUpdateResponseData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public ContractUpdateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ContractUpdateResponse(ContractUpdateResponse contractUpdateResponse)
        : base(contractUpdateResponse) { }
#pragma warning restore CS8618

    public ContractUpdateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContractUpdateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ContractUpdateResponseFromRaw.FromRawUnchecked"/>
    public static ContractUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ContractUpdateResponse(ContractUpdateResponseData data)
        : this()
    {
        this.Data = data;
    }
}

class ContractUpdateResponseFromRaw : IFromRawJson<ContractUpdateResponse>
{
    /// <inheritdoc/>
    public ContractUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ContractUpdateResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// A billing contract as reported by the connected billing provider.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ContractUpdateResponseData, ContractUpdateResponseDataFromRaw>)
)]
public sealed record class ContractUpdateResponseData : JsonModel
{
    /// <summary>
    /// The persisted Stigg contract id (matches a subscription’s contractId; present
    /// for Stigg-managed contracts)
    /// </summary>
    public required string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// The date the contract activation ends
    /// </summary>
    public required System::DateTimeOffset? ActivationEndDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("activationEndDate");
        }
        init { this._rawData.Set("activationEndDate", value); }
    }

    /// <summary>
    /// The date the contract becomes active
    /// </summary>
    public required System::DateTimeOffset? ActivationStartDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("activationStartDate");
        }
        init { this._rawData.Set("activationStartDate", value); }
    }

    /// <summary>
    /// The billing provider (Received) contract ID; null until the contract has synced
    /// to the billing provider
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
    /// The Stigg contract ref ID (the key used to fetch/update/delete this contract)
    /// </summary>
    public required string ContractID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("contractId");
        }
        init { this._rawData.Set("contractId", value); }
    }

    /// <summary>
    /// The date the contract was created
    /// </summary>
    public required System::DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("createdAt");
        }
        init { this._rawData.Set("createdAt", value); }
    }

    /// <summary>
    /// The external identifier of the customer the contract belongs to
    /// </summary>
    public required string? CustomerExternalID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("customerExternalId");
        }
        init { this._rawData.Set("customerExternalId", value); }
    }

    /// <summary>
    /// The external identifier of the contract
    /// </summary>
    public required string ExternalID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("externalId");
        }
        init { this._rawData.Set("externalId", value); }
    }

    /// <summary>
    /// The most recent non-draft invoice for this contract (open, paid, or canceled),
    /// or null when none exists
    /// </summary>
    public required ContractUpdateResponseDataLatestInvoice? LatestInvoice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ContractUpdateResponseDataLatestInvoice>(
                "latestInvoice"
            );
        }
        init { this._rawData.Set("latestInvoice", value); }
    }

    /// <summary>
    /// The contract name (the purchase-order number when set, otherwise the contract/customer name)
    /// </summary>
    public required string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// A preview of the contract's upcoming invoice, or null when none is available
    /// </summary>
    public required ContractUpdateResponseDataNextInvoice? NextInvoice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ContractUpdateResponseDataNextInvoice>(
                "nextInvoice"
            );
        }
        init { this._rawData.Set("nextInvoice", value); }
    }

    /// <summary>
    /// Purchase-order number, when set on the contract
    /// </summary>
    public required string? PoNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("poNumber");
        }
        init { this._rawData.Set("poNumber", value); }
    }

    /// <summary>
    /// The Stigg contract ref ID (present for Stigg-managed contracts; the key used
    /// to update/delete)
    /// </summary>
    public required string? RefID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("refId");
        }
        init { this._rawData.Set("refId", value); }
    }

    /// <summary>
    /// The current state of the contract
    /// </summary>
    public required ApiEnum<string, ContractUpdateResponseDataState> State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ContractUpdateResponseDataState>>(
                "state"
            );
        }
        init { this._rawData.Set("state", value); }
    }

    /// <summary>
    /// The custom subscriptions attached to this contract (empty when none)
    /// </summary>
    public required IReadOnlyList<ContractUpdateResponseDataSubscription> Subscriptions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<ContractUpdateResponseDataSubscription>
            >("subscriptions");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ContractUpdateResponseDataSubscription>>(
                "subscriptions",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ActivationEndDate;
        _ = this.ActivationStartDate;
        _ = this.BillingID;
        _ = this.ContractID;
        _ = this.CreatedAt;
        _ = this.CustomerExternalID;
        _ = this.ExternalID;
        this.LatestInvoice?.Validate();
        _ = this.Name;
        this.NextInvoice?.Validate();
        _ = this.PoNumber;
        _ = this.RefID;
        this.State.Validate();
        foreach (var item in this.Subscriptions)
        {
            item.Validate();
        }
    }

    public ContractUpdateResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ContractUpdateResponseData(ContractUpdateResponseData contractUpdateResponseData)
        : base(contractUpdateResponseData) { }
#pragma warning restore CS8618

    public ContractUpdateResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContractUpdateResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ContractUpdateResponseDataFromRaw.FromRawUnchecked"/>
    public static ContractUpdateResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ContractUpdateResponseDataFromRaw : IFromRawJson<ContractUpdateResponseData>
{
    /// <inheritdoc/>
    public ContractUpdateResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ContractUpdateResponseData.FromRawUnchecked(rawData);
}

/// <summary>
/// The most recent non-draft invoice for this contract (open, paid, or canceled),
/// or null when none exists
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ContractUpdateResponseDataLatestInvoice,
        ContractUpdateResponseDataLatestInvoiceFromRaw
    >)
)]
public sealed record class ContractUpdateResponseDataLatestInvoice : JsonModel
{
    /// <summary>
    /// Invoice billing ID
    /// </summary>
    public required string BillingID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("billingId");
        }
        init { this._rawData.Set("billingId", value); }
    }

    /// <summary>
    /// Invoice creation date
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
    /// Whether payment requires action
    /// </summary>
    public required bool RequiresAction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("requiresAction");
        }
        init { this._rawData.Set("requiresAction", value); }
    }

    /// <summary>
    /// Invoice status
    /// </summary>
    public required ApiEnum<string, ContractUpdateResponseDataLatestInvoiceStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ContractUpdateResponseDataLatestInvoiceStatus>
            >("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Amount due
    /// </summary>
    public double? AmountDue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("amountDue");
        }
        init { this._rawData.Set("amountDue", value); }
    }

    /// <summary>
    /// Billing reason
    /// </summary>
    public ApiEnum<string, ContractUpdateResponseDataLatestInvoiceBillingReason>? BillingReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, ContractUpdateResponseDataLatestInvoiceBillingReason>
            >("billingReason");
        }
        init { this._rawData.Set("billingReason", value); }
    }

    /// <summary>
    /// Invoice currency
    /// </summary>
    public string? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// Invoice PDF URL
    /// </summary>
    public string? PdfUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("pdfUrl");
        }
        init { this._rawData.Set("pdfUrl", value); }
    }

    /// <summary>
    /// Total amount
    /// </summary>
    public double? Total
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("total");
        }
        init { this._rawData.Set("total", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BillingID;
        _ = this.CreatedAt;
        _ = this.RequiresAction;
        this.Status.Validate();
        _ = this.AmountDue;
        this.BillingReason?.Validate();
        _ = this.Currency;
        _ = this.PdfUrl;
        _ = this.Total;
    }

    public ContractUpdateResponseDataLatestInvoice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ContractUpdateResponseDataLatestInvoice(
        ContractUpdateResponseDataLatestInvoice contractUpdateResponseDataLatestInvoice
    )
        : base(contractUpdateResponseDataLatestInvoice) { }
#pragma warning restore CS8618

    public ContractUpdateResponseDataLatestInvoice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContractUpdateResponseDataLatestInvoice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ContractUpdateResponseDataLatestInvoiceFromRaw.FromRawUnchecked"/>
    public static ContractUpdateResponseDataLatestInvoice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ContractUpdateResponseDataLatestInvoiceFromRaw
    : IFromRawJson<ContractUpdateResponseDataLatestInvoice>
{
    /// <inheritdoc/>
    public ContractUpdateResponseDataLatestInvoice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ContractUpdateResponseDataLatestInvoice.FromRawUnchecked(rawData);
}

/// <summary>
/// Invoice status
/// </summary>
[JsonConverter(typeof(ContractUpdateResponseDataLatestInvoiceStatusConverter))]
public enum ContractUpdateResponseDataLatestInvoiceStatus
{
    Open,
    Canceled,
    Paid,
}

sealed class ContractUpdateResponseDataLatestInvoiceStatusConverter
    : JsonConverter<ContractUpdateResponseDataLatestInvoiceStatus>
{
    public override ContractUpdateResponseDataLatestInvoiceStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "OPEN" => ContractUpdateResponseDataLatestInvoiceStatus.Open,
            "CANCELED" => ContractUpdateResponseDataLatestInvoiceStatus.Canceled,
            "PAID" => ContractUpdateResponseDataLatestInvoiceStatus.Paid,
            _ => (ContractUpdateResponseDataLatestInvoiceStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ContractUpdateResponseDataLatestInvoiceStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ContractUpdateResponseDataLatestInvoiceStatus.Open => "OPEN",
                ContractUpdateResponseDataLatestInvoiceStatus.Canceled => "CANCELED",
                ContractUpdateResponseDataLatestInvoiceStatus.Paid => "PAID",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Billing reason
/// </summary>
[JsonConverter(typeof(ContractUpdateResponseDataLatestInvoiceBillingReasonConverter))]
public enum ContractUpdateResponseDataLatestInvoiceBillingReason
{
    BillingCycle,
    SubscriptionCreation,
    SubscriptionUpdate,
    Manual,
    MinimumInvoiceAmountExceeded,
    Other,
}

sealed class ContractUpdateResponseDataLatestInvoiceBillingReasonConverter
    : JsonConverter<ContractUpdateResponseDataLatestInvoiceBillingReason>
{
    public override ContractUpdateResponseDataLatestInvoiceBillingReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "BILLING_CYCLE" => ContractUpdateResponseDataLatestInvoiceBillingReason.BillingCycle,
            "SUBSCRIPTION_CREATION" =>
                ContractUpdateResponseDataLatestInvoiceBillingReason.SubscriptionCreation,
            "SUBSCRIPTION_UPDATE" =>
                ContractUpdateResponseDataLatestInvoiceBillingReason.SubscriptionUpdate,
            "MANUAL" => ContractUpdateResponseDataLatestInvoiceBillingReason.Manual,
            "MINIMUM_INVOICE_AMOUNT_EXCEEDED" =>
                ContractUpdateResponseDataLatestInvoiceBillingReason.MinimumInvoiceAmountExceeded,
            "OTHER" => ContractUpdateResponseDataLatestInvoiceBillingReason.Other,
            _ => (ContractUpdateResponseDataLatestInvoiceBillingReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ContractUpdateResponseDataLatestInvoiceBillingReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ContractUpdateResponseDataLatestInvoiceBillingReason.BillingCycle =>
                    "BILLING_CYCLE",
                ContractUpdateResponseDataLatestInvoiceBillingReason.SubscriptionCreation =>
                    "SUBSCRIPTION_CREATION",
                ContractUpdateResponseDataLatestInvoiceBillingReason.SubscriptionUpdate =>
                    "SUBSCRIPTION_UPDATE",
                ContractUpdateResponseDataLatestInvoiceBillingReason.Manual => "MANUAL",
                ContractUpdateResponseDataLatestInvoiceBillingReason.MinimumInvoiceAmountExceeded =>
                    "MINIMUM_INVOICE_AMOUNT_EXCEEDED",
                ContractUpdateResponseDataLatestInvoiceBillingReason.Other => "OTHER",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A preview of the contract's upcoming invoice, or null when none is available
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ContractUpdateResponseDataNextInvoice,
        ContractUpdateResponseDataNextInvoiceFromRaw
    >)
)]
public sealed record class ContractUpdateResponseDataNextInvoice : JsonModel
{
    /// <summary>
    /// The total amount of the upcoming invoice
    /// </summary>
    public required ContractUpdateResponseDataNextInvoiceAmount Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ContractUpdateResponseDataNextInvoiceAmount>(
                "amount"
            );
        }
        init { this._rawData.Set("amount", value); }
    }

    /// <summary>
    /// The date the upcoming invoice is due
    /// </summary>
    public required System::DateTimeOffset? DueDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("dueDate");
        }
        init { this._rawData.Set("dueDate", value); }
    }

    /// <summary>
    /// The end of the billing period the upcoming invoice covers
    /// </summary>
    public required System::DateTimeOffset? PeriodEnd
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("periodEnd");
        }
        init { this._rawData.Set("periodEnd", value); }
    }

    /// <summary>
    /// The start of the billing period the upcoming invoice covers
    /// </summary>
    public required System::DateTimeOffset? PeriodStart
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("periodStart");
        }
        init { this._rawData.Set("periodStart", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Amount.Validate();
        _ = this.DueDate;
        _ = this.PeriodEnd;
        _ = this.PeriodStart;
    }

    public ContractUpdateResponseDataNextInvoice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ContractUpdateResponseDataNextInvoice(
        ContractUpdateResponseDataNextInvoice contractUpdateResponseDataNextInvoice
    )
        : base(contractUpdateResponseDataNextInvoice) { }
#pragma warning restore CS8618

    public ContractUpdateResponseDataNextInvoice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContractUpdateResponseDataNextInvoice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ContractUpdateResponseDataNextInvoiceFromRaw.FromRawUnchecked"/>
    public static ContractUpdateResponseDataNextInvoice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ContractUpdateResponseDataNextInvoiceFromRaw
    : IFromRawJson<ContractUpdateResponseDataNextInvoice>
{
    /// <inheritdoc/>
    public ContractUpdateResponseDataNextInvoice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ContractUpdateResponseDataNextInvoice.FromRawUnchecked(rawData);
}

/// <summary>
/// The total amount of the upcoming invoice
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ContractUpdateResponseDataNextInvoiceAmount,
        ContractUpdateResponseDataNextInvoiceAmountFromRaw
    >)
)]
public sealed record class ContractUpdateResponseDataNextInvoiceAmount : JsonModel
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
    public required ApiEnum<string, ContractUpdateResponseDataNextInvoiceAmountCurrency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ContractUpdateResponseDataNextInvoiceAmountCurrency>
            >("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        this.Currency.Validate();
    }

    public ContractUpdateResponseDataNextInvoiceAmount() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ContractUpdateResponseDataNextInvoiceAmount(
        ContractUpdateResponseDataNextInvoiceAmount contractUpdateResponseDataNextInvoiceAmount
    )
        : base(contractUpdateResponseDataNextInvoiceAmount) { }
#pragma warning restore CS8618

    public ContractUpdateResponseDataNextInvoiceAmount(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContractUpdateResponseDataNextInvoiceAmount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ContractUpdateResponseDataNextInvoiceAmountFromRaw.FromRawUnchecked"/>
    public static ContractUpdateResponseDataNextInvoiceAmount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ContractUpdateResponseDataNextInvoiceAmountFromRaw
    : IFromRawJson<ContractUpdateResponseDataNextInvoiceAmount>
{
    /// <inheritdoc/>
    public ContractUpdateResponseDataNextInvoiceAmount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ContractUpdateResponseDataNextInvoiceAmount.FromRawUnchecked(rawData);
}

/// <summary>
/// ISO 4217 currency code
/// </summary>
[JsonConverter(typeof(ContractUpdateResponseDataNextInvoiceAmountCurrencyConverter))]
public enum ContractUpdateResponseDataNextInvoiceAmountCurrency
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

sealed class ContractUpdateResponseDataNextInvoiceAmountCurrencyConverter
    : JsonConverter<ContractUpdateResponseDataNextInvoiceAmountCurrency>
{
    public override ContractUpdateResponseDataNextInvoiceAmountCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Usd,
            "aed" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Aed,
            "all" => ContractUpdateResponseDataNextInvoiceAmountCurrency.All,
            "amd" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Amd,
            "ang" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Ang,
            "aud" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Aud,
            "awg" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Awg,
            "azn" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Azn,
            "bam" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Bam,
            "bbd" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Bbd,
            "bdt" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Bdt,
            "bgn" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Bgn,
            "bif" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Bif,
            "bmd" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Bmd,
            "bnd" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Bnd,
            "bsd" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Bsd,
            "bwp" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Bwp,
            "byn" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Byn,
            "bzd" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Bzd,
            "brl" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Brl,
            "cad" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Cad,
            "cdf" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Cdf,
            "chf" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Chf,
            "cny" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Cny,
            "czk" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Czk,
            "dkk" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Dkk,
            "dop" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Dop,
            "dzd" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Dzd,
            "egp" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Egp,
            "etb" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Etb,
            "eur" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Eur,
            "fjd" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Fjd,
            "gbp" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Gbp,
            "gel" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Gel,
            "gip" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Gip,
            "gmd" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Gmd,
            "gyd" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Gyd,
            "hkd" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Hkd,
            "hrk" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Hrk,
            "htg" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Htg,
            "idr" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Idr,
            "ils" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Ils,
            "inr" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Inr,
            "isk" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Isk,
            "jmd" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Jmd,
            "jpy" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Jpy,
            "kes" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Kes,
            "kgs" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Kgs,
            "khr" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Khr,
            "kmf" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Kmf,
            "krw" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Krw,
            "kyd" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Kyd,
            "kzt" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Kzt,
            "lbp" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Lbp,
            "lkr" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Lkr,
            "lrd" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Lrd,
            "lsl" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Lsl,
            "mad" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Mad,
            "mdl" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Mdl,
            "mga" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Mga,
            "mkd" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Mkd,
            "mmk" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Mmk,
            "mnt" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Mnt,
            "mop" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Mop,
            "mro" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Mro,
            "mvr" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Mvr,
            "mwk" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Mwk,
            "mxn" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Mxn,
            "myr" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Myr,
            "mzn" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Mzn,
            "nad" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Nad,
            "ngn" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Ngn,
            "nok" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Nok,
            "npr" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Npr,
            "nzd" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Nzd,
            "pgk" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Pgk,
            "php" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Php,
            "pkr" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Pkr,
            "pln" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Pln,
            "qar" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Qar,
            "ron" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Ron,
            "rsd" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Rsd,
            "rub" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Rub,
            "rwf" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Rwf,
            "sar" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Sar,
            "sbd" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Sbd,
            "scr" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Scr,
            "sek" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Sek,
            "sgd" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Sgd,
            "sle" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Sle,
            "sll" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Sll,
            "sos" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Sos,
            "szl" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Szl,
            "thb" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Thb,
            "tjs" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Tjs,
            "top" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Top,
            "try" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Try,
            "ttd" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Ttd,
            "tzs" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Tzs,
            "uah" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Uah,
            "uzs" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Uzs,
            "vnd" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Vnd,
            "vuv" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Vuv,
            "wst" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Wst,
            "xaf" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Xaf,
            "xcd" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Xcd,
            "yer" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Yer,
            "zar" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Zar,
            "zmw" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Zmw,
            "clp" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Clp,
            "djf" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Djf,
            "gnf" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Gnf,
            "ugx" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Ugx,
            "pyg" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Pyg,
            "xof" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Xof,
            "xpf" => ContractUpdateResponseDataNextInvoiceAmountCurrency.Xpf,
            _ => (ContractUpdateResponseDataNextInvoiceAmountCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ContractUpdateResponseDataNextInvoiceAmountCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Usd => "usd",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Aed => "aed",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.All => "all",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Amd => "amd",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Ang => "ang",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Aud => "aud",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Awg => "awg",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Azn => "azn",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Bam => "bam",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Bbd => "bbd",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Bdt => "bdt",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Bgn => "bgn",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Bif => "bif",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Bmd => "bmd",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Bnd => "bnd",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Bsd => "bsd",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Bwp => "bwp",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Byn => "byn",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Bzd => "bzd",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Brl => "brl",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Cad => "cad",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Cdf => "cdf",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Chf => "chf",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Cny => "cny",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Czk => "czk",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Dkk => "dkk",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Dop => "dop",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Dzd => "dzd",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Egp => "egp",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Etb => "etb",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Eur => "eur",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Fjd => "fjd",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Gbp => "gbp",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Gel => "gel",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Gip => "gip",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Gmd => "gmd",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Gyd => "gyd",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Hkd => "hkd",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Hrk => "hrk",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Htg => "htg",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Idr => "idr",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Ils => "ils",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Inr => "inr",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Isk => "isk",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Jmd => "jmd",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Jpy => "jpy",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Kes => "kes",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Kgs => "kgs",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Khr => "khr",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Kmf => "kmf",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Krw => "krw",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Kyd => "kyd",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Kzt => "kzt",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Lbp => "lbp",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Lkr => "lkr",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Lrd => "lrd",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Lsl => "lsl",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Mad => "mad",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Mdl => "mdl",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Mga => "mga",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Mkd => "mkd",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Mmk => "mmk",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Mnt => "mnt",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Mop => "mop",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Mro => "mro",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Mvr => "mvr",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Mwk => "mwk",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Mxn => "mxn",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Myr => "myr",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Mzn => "mzn",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Nad => "nad",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Ngn => "ngn",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Nok => "nok",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Npr => "npr",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Nzd => "nzd",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Pgk => "pgk",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Php => "php",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Pkr => "pkr",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Pln => "pln",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Qar => "qar",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Ron => "ron",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Rsd => "rsd",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Rub => "rub",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Rwf => "rwf",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Sar => "sar",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Sbd => "sbd",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Scr => "scr",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Sek => "sek",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Sgd => "sgd",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Sle => "sle",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Sll => "sll",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Sos => "sos",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Szl => "szl",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Thb => "thb",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Tjs => "tjs",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Top => "top",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Try => "try",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Ttd => "ttd",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Tzs => "tzs",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Uah => "uah",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Uzs => "uzs",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Vnd => "vnd",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Vuv => "vuv",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Wst => "wst",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Xaf => "xaf",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Xcd => "xcd",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Yer => "yer",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Zar => "zar",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Zmw => "zmw",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Clp => "clp",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Djf => "djf",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Gnf => "gnf",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Ugx => "ugx",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Pyg => "pyg",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Xof => "xof",
                ContractUpdateResponseDataNextInvoiceAmountCurrency.Xpf => "xpf",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The current state of the contract
/// </summary>
[JsonConverter(typeof(ContractUpdateResponseDataStateConverter))]
public enum ContractUpdateResponseDataState
{
    Draft,
    Active,
    Canceled,
    EndBilling,
}

sealed class ContractUpdateResponseDataStateConverter
    : JsonConverter<ContractUpdateResponseDataState>
{
    public override ContractUpdateResponseDataState Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "DRAFT" => ContractUpdateResponseDataState.Draft,
            "ACTIVE" => ContractUpdateResponseDataState.Active,
            "CANCELED" => ContractUpdateResponseDataState.Canceled,
            "END_BILLING" => ContractUpdateResponseDataState.EndBilling,
            _ => (ContractUpdateResponseDataState)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ContractUpdateResponseDataState value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ContractUpdateResponseDataState.Draft => "DRAFT",
                ContractUpdateResponseDataState.Active => "ACTIVE",
                ContractUpdateResponseDataState.Canceled => "CANCELED",
                ContractUpdateResponseDataState.EndBilling => "END_BILLING",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A custom subscription attached to a contract.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ContractUpdateResponseDataSubscription,
        ContractUpdateResponseDataSubscriptionFromRaw
    >)
)]
public sealed record class ContractUpdateResponseDataSubscription : JsonModel
{
    /// <summary>
    /// Display name of the subscription plan
    /// </summary>
    public required string? PlanDisplayName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("planDisplayName");
        }
        init { this._rawData.Set("planDisplayName", value); }
    }

    /// <summary>
    /// Display name of the product the subscription plan belongs to
    /// </summary>
    public required string? ProductDisplayName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("productDisplayName");
        }
        init { this._rawData.Set("productDisplayName", value); }
    }

    /// <summary>
    /// The subscription ref ID (use it to deep-link to the subscription)
    /// </summary>
    public required string SubscriptionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("subscriptionId");
        }
        init { this._rawData.Set("subscriptionId", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PlanDisplayName;
        _ = this.ProductDisplayName;
        _ = this.SubscriptionID;
    }

    public ContractUpdateResponseDataSubscription() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ContractUpdateResponseDataSubscription(
        ContractUpdateResponseDataSubscription contractUpdateResponseDataSubscription
    )
        : base(contractUpdateResponseDataSubscription) { }
#pragma warning restore CS8618

    public ContractUpdateResponseDataSubscription(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContractUpdateResponseDataSubscription(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ContractUpdateResponseDataSubscriptionFromRaw.FromRawUnchecked"/>
    public static ContractUpdateResponseDataSubscription FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ContractUpdateResponseDataSubscriptionFromRaw
    : IFromRawJson<ContractUpdateResponseDataSubscription>
{
    /// <inheritdoc/>
    public ContractUpdateResponseDataSubscription FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ContractUpdateResponseDataSubscription.FromRawUnchecked(rawData);
}
