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
/// A billing contract as reported by the connected billing provider.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ContractListResponse, ContractListResponseFromRaw>))]
public sealed record class ContractListResponse : JsonModel
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
    /// The current state of the contract
    /// </summary>
    public required ApiEnum<string, ContractListResponseBillingState>? BillingState
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, ContractListResponseBillingState>
            >("billingState");
        }
        init { this._rawData.Set("billingState", value); }
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
    public required ContractListResponseLatestInvoice? LatestInvoice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ContractListResponseLatestInvoice>(
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
    public required ContractListResponseNextInvoice? NextInvoice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ContractListResponseNextInvoice>("nextInvoice");
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
    public required ApiEnum<string, ContractListResponseState> State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ContractListResponseState>>(
                "state"
            );
        }
        init { this._rawData.Set("state", value); }
    }

    /// <summary>
    /// The custom subscriptions attached to this contract (empty when none)
    /// </summary>
    public required IReadOnlyList<ContractListResponseSubscription> Subscriptions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ContractListResponseSubscription>>(
                "subscriptions"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ContractListResponseSubscription>>(
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
        this.BillingState?.Validate();
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

    public ContractListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ContractListResponse(ContractListResponse contractListResponse)
        : base(contractListResponse) { }
#pragma warning restore CS8618

    public ContractListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContractListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ContractListResponseFromRaw.FromRawUnchecked"/>
    public static ContractListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ContractListResponseFromRaw : IFromRawJson<ContractListResponse>
{
    /// <inheritdoc/>
    public ContractListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ContractListResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// The current state of the contract
/// </summary>
[JsonConverter(typeof(ContractListResponseBillingStateConverter))]
public enum ContractListResponseBillingState
{
    Draft,
    Active,
    Canceled,
    EndBilling,
}

sealed class ContractListResponseBillingStateConverter
    : JsonConverter<ContractListResponseBillingState>
{
    public override ContractListResponseBillingState Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "DRAFT" => ContractListResponseBillingState.Draft,
            "ACTIVE" => ContractListResponseBillingState.Active,
            "CANCELED" => ContractListResponseBillingState.Canceled,
            "END_BILLING" => ContractListResponseBillingState.EndBilling,
            _ => (ContractListResponseBillingState)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ContractListResponseBillingState value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ContractListResponseBillingState.Draft => "DRAFT",
                ContractListResponseBillingState.Active => "ACTIVE",
                ContractListResponseBillingState.Canceled => "CANCELED",
                ContractListResponseBillingState.EndBilling => "END_BILLING",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The most recent non-draft invoice for this contract (open, paid, or canceled),
/// or null when none exists
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ContractListResponseLatestInvoice,
        ContractListResponseLatestInvoiceFromRaw
    >)
)]
public sealed record class ContractListResponseLatestInvoice : JsonModel
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
    public required ApiEnum<string, ContractListResponseLatestInvoiceStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ContractListResponseLatestInvoiceStatus>
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
    public ApiEnum<string, ContractListResponseLatestInvoiceBillingReason>? BillingReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, ContractListResponseLatestInvoiceBillingReason>
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

    public ContractListResponseLatestInvoice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ContractListResponseLatestInvoice(
        ContractListResponseLatestInvoice contractListResponseLatestInvoice
    )
        : base(contractListResponseLatestInvoice) { }
#pragma warning restore CS8618

    public ContractListResponseLatestInvoice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContractListResponseLatestInvoice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ContractListResponseLatestInvoiceFromRaw.FromRawUnchecked"/>
    public static ContractListResponseLatestInvoice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ContractListResponseLatestInvoiceFromRaw : IFromRawJson<ContractListResponseLatestInvoice>
{
    /// <inheritdoc/>
    public ContractListResponseLatestInvoice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ContractListResponseLatestInvoice.FromRawUnchecked(rawData);
}

/// <summary>
/// Invoice status
/// </summary>
[JsonConverter(typeof(ContractListResponseLatestInvoiceStatusConverter))]
public enum ContractListResponseLatestInvoiceStatus
{
    Open,
    Canceled,
    Paid,
}

sealed class ContractListResponseLatestInvoiceStatusConverter
    : JsonConverter<ContractListResponseLatestInvoiceStatus>
{
    public override ContractListResponseLatestInvoiceStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "OPEN" => ContractListResponseLatestInvoiceStatus.Open,
            "CANCELED" => ContractListResponseLatestInvoiceStatus.Canceled,
            "PAID" => ContractListResponseLatestInvoiceStatus.Paid,
            _ => (ContractListResponseLatestInvoiceStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ContractListResponseLatestInvoiceStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ContractListResponseLatestInvoiceStatus.Open => "OPEN",
                ContractListResponseLatestInvoiceStatus.Canceled => "CANCELED",
                ContractListResponseLatestInvoiceStatus.Paid => "PAID",
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
[JsonConverter(typeof(ContractListResponseLatestInvoiceBillingReasonConverter))]
public enum ContractListResponseLatestInvoiceBillingReason
{
    BillingCycle,
    SubscriptionCreation,
    SubscriptionUpdate,
    Manual,
    MinimumInvoiceAmountExceeded,
    Other,
}

sealed class ContractListResponseLatestInvoiceBillingReasonConverter
    : JsonConverter<ContractListResponseLatestInvoiceBillingReason>
{
    public override ContractListResponseLatestInvoiceBillingReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "BILLING_CYCLE" => ContractListResponseLatestInvoiceBillingReason.BillingCycle,
            "SUBSCRIPTION_CREATION" =>
                ContractListResponseLatestInvoiceBillingReason.SubscriptionCreation,
            "SUBSCRIPTION_UPDATE" =>
                ContractListResponseLatestInvoiceBillingReason.SubscriptionUpdate,
            "MANUAL" => ContractListResponseLatestInvoiceBillingReason.Manual,
            "MINIMUM_INVOICE_AMOUNT_EXCEEDED" =>
                ContractListResponseLatestInvoiceBillingReason.MinimumInvoiceAmountExceeded,
            "OTHER" => ContractListResponseLatestInvoiceBillingReason.Other,
            _ => (ContractListResponseLatestInvoiceBillingReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ContractListResponseLatestInvoiceBillingReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ContractListResponseLatestInvoiceBillingReason.BillingCycle => "BILLING_CYCLE",
                ContractListResponseLatestInvoiceBillingReason.SubscriptionCreation =>
                    "SUBSCRIPTION_CREATION",
                ContractListResponseLatestInvoiceBillingReason.SubscriptionUpdate =>
                    "SUBSCRIPTION_UPDATE",
                ContractListResponseLatestInvoiceBillingReason.Manual => "MANUAL",
                ContractListResponseLatestInvoiceBillingReason.MinimumInvoiceAmountExceeded =>
                    "MINIMUM_INVOICE_AMOUNT_EXCEEDED",
                ContractListResponseLatestInvoiceBillingReason.Other => "OTHER",
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
        ContractListResponseNextInvoice,
        ContractListResponseNextInvoiceFromRaw
    >)
)]
public sealed record class ContractListResponseNextInvoice : JsonModel
{
    /// <summary>
    /// The total amount of the upcoming invoice
    /// </summary>
    public required ContractListResponseNextInvoiceAmount Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ContractListResponseNextInvoiceAmount>("amount");
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

    public ContractListResponseNextInvoice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ContractListResponseNextInvoice(
        ContractListResponseNextInvoice contractListResponseNextInvoice
    )
        : base(contractListResponseNextInvoice) { }
#pragma warning restore CS8618

    public ContractListResponseNextInvoice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContractListResponseNextInvoice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ContractListResponseNextInvoiceFromRaw.FromRawUnchecked"/>
    public static ContractListResponseNextInvoice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ContractListResponseNextInvoiceFromRaw : IFromRawJson<ContractListResponseNextInvoice>
{
    /// <inheritdoc/>
    public ContractListResponseNextInvoice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ContractListResponseNextInvoice.FromRawUnchecked(rawData);
}

/// <summary>
/// The total amount of the upcoming invoice
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ContractListResponseNextInvoiceAmount,
        ContractListResponseNextInvoiceAmountFromRaw
    >)
)]
public sealed record class ContractListResponseNextInvoiceAmount : JsonModel
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
    public required ApiEnum<string, ContractListResponseNextInvoiceAmountCurrency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ContractListResponseNextInvoiceAmountCurrency>
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

    public ContractListResponseNextInvoiceAmount() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ContractListResponseNextInvoiceAmount(
        ContractListResponseNextInvoiceAmount contractListResponseNextInvoiceAmount
    )
        : base(contractListResponseNextInvoiceAmount) { }
#pragma warning restore CS8618

    public ContractListResponseNextInvoiceAmount(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContractListResponseNextInvoiceAmount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ContractListResponseNextInvoiceAmountFromRaw.FromRawUnchecked"/>
    public static ContractListResponseNextInvoiceAmount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ContractListResponseNextInvoiceAmountFromRaw
    : IFromRawJson<ContractListResponseNextInvoiceAmount>
{
    /// <inheritdoc/>
    public ContractListResponseNextInvoiceAmount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ContractListResponseNextInvoiceAmount.FromRawUnchecked(rawData);
}

/// <summary>
/// ISO 4217 currency code
/// </summary>
[JsonConverter(typeof(ContractListResponseNextInvoiceAmountCurrencyConverter))]
public enum ContractListResponseNextInvoiceAmountCurrency
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

sealed class ContractListResponseNextInvoiceAmountCurrencyConverter
    : JsonConverter<ContractListResponseNextInvoiceAmountCurrency>
{
    public override ContractListResponseNextInvoiceAmountCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => ContractListResponseNextInvoiceAmountCurrency.Usd,
            "aed" => ContractListResponseNextInvoiceAmountCurrency.Aed,
            "all" => ContractListResponseNextInvoiceAmountCurrency.All,
            "amd" => ContractListResponseNextInvoiceAmountCurrency.Amd,
            "ang" => ContractListResponseNextInvoiceAmountCurrency.Ang,
            "aud" => ContractListResponseNextInvoiceAmountCurrency.Aud,
            "awg" => ContractListResponseNextInvoiceAmountCurrency.Awg,
            "azn" => ContractListResponseNextInvoiceAmountCurrency.Azn,
            "bam" => ContractListResponseNextInvoiceAmountCurrency.Bam,
            "bbd" => ContractListResponseNextInvoiceAmountCurrency.Bbd,
            "bdt" => ContractListResponseNextInvoiceAmountCurrency.Bdt,
            "bgn" => ContractListResponseNextInvoiceAmountCurrency.Bgn,
            "bif" => ContractListResponseNextInvoiceAmountCurrency.Bif,
            "bmd" => ContractListResponseNextInvoiceAmountCurrency.Bmd,
            "bnd" => ContractListResponseNextInvoiceAmountCurrency.Bnd,
            "bsd" => ContractListResponseNextInvoiceAmountCurrency.Bsd,
            "bwp" => ContractListResponseNextInvoiceAmountCurrency.Bwp,
            "byn" => ContractListResponseNextInvoiceAmountCurrency.Byn,
            "bzd" => ContractListResponseNextInvoiceAmountCurrency.Bzd,
            "brl" => ContractListResponseNextInvoiceAmountCurrency.Brl,
            "cad" => ContractListResponseNextInvoiceAmountCurrency.Cad,
            "cdf" => ContractListResponseNextInvoiceAmountCurrency.Cdf,
            "chf" => ContractListResponseNextInvoiceAmountCurrency.Chf,
            "cny" => ContractListResponseNextInvoiceAmountCurrency.Cny,
            "czk" => ContractListResponseNextInvoiceAmountCurrency.Czk,
            "dkk" => ContractListResponseNextInvoiceAmountCurrency.Dkk,
            "dop" => ContractListResponseNextInvoiceAmountCurrency.Dop,
            "dzd" => ContractListResponseNextInvoiceAmountCurrency.Dzd,
            "egp" => ContractListResponseNextInvoiceAmountCurrency.Egp,
            "etb" => ContractListResponseNextInvoiceAmountCurrency.Etb,
            "eur" => ContractListResponseNextInvoiceAmountCurrency.Eur,
            "fjd" => ContractListResponseNextInvoiceAmountCurrency.Fjd,
            "gbp" => ContractListResponseNextInvoiceAmountCurrency.Gbp,
            "gel" => ContractListResponseNextInvoiceAmountCurrency.Gel,
            "gip" => ContractListResponseNextInvoiceAmountCurrency.Gip,
            "gmd" => ContractListResponseNextInvoiceAmountCurrency.Gmd,
            "gyd" => ContractListResponseNextInvoiceAmountCurrency.Gyd,
            "hkd" => ContractListResponseNextInvoiceAmountCurrency.Hkd,
            "hrk" => ContractListResponseNextInvoiceAmountCurrency.Hrk,
            "htg" => ContractListResponseNextInvoiceAmountCurrency.Htg,
            "idr" => ContractListResponseNextInvoiceAmountCurrency.Idr,
            "ils" => ContractListResponseNextInvoiceAmountCurrency.Ils,
            "inr" => ContractListResponseNextInvoiceAmountCurrency.Inr,
            "isk" => ContractListResponseNextInvoiceAmountCurrency.Isk,
            "jmd" => ContractListResponseNextInvoiceAmountCurrency.Jmd,
            "jpy" => ContractListResponseNextInvoiceAmountCurrency.Jpy,
            "kes" => ContractListResponseNextInvoiceAmountCurrency.Kes,
            "kgs" => ContractListResponseNextInvoiceAmountCurrency.Kgs,
            "khr" => ContractListResponseNextInvoiceAmountCurrency.Khr,
            "kmf" => ContractListResponseNextInvoiceAmountCurrency.Kmf,
            "krw" => ContractListResponseNextInvoiceAmountCurrency.Krw,
            "kyd" => ContractListResponseNextInvoiceAmountCurrency.Kyd,
            "kzt" => ContractListResponseNextInvoiceAmountCurrency.Kzt,
            "lbp" => ContractListResponseNextInvoiceAmountCurrency.Lbp,
            "lkr" => ContractListResponseNextInvoiceAmountCurrency.Lkr,
            "lrd" => ContractListResponseNextInvoiceAmountCurrency.Lrd,
            "lsl" => ContractListResponseNextInvoiceAmountCurrency.Lsl,
            "mad" => ContractListResponseNextInvoiceAmountCurrency.Mad,
            "mdl" => ContractListResponseNextInvoiceAmountCurrency.Mdl,
            "mga" => ContractListResponseNextInvoiceAmountCurrency.Mga,
            "mkd" => ContractListResponseNextInvoiceAmountCurrency.Mkd,
            "mmk" => ContractListResponseNextInvoiceAmountCurrency.Mmk,
            "mnt" => ContractListResponseNextInvoiceAmountCurrency.Mnt,
            "mop" => ContractListResponseNextInvoiceAmountCurrency.Mop,
            "mro" => ContractListResponseNextInvoiceAmountCurrency.Mro,
            "mvr" => ContractListResponseNextInvoiceAmountCurrency.Mvr,
            "mwk" => ContractListResponseNextInvoiceAmountCurrency.Mwk,
            "mxn" => ContractListResponseNextInvoiceAmountCurrency.Mxn,
            "myr" => ContractListResponseNextInvoiceAmountCurrency.Myr,
            "mzn" => ContractListResponseNextInvoiceAmountCurrency.Mzn,
            "nad" => ContractListResponseNextInvoiceAmountCurrency.Nad,
            "ngn" => ContractListResponseNextInvoiceAmountCurrency.Ngn,
            "nok" => ContractListResponseNextInvoiceAmountCurrency.Nok,
            "npr" => ContractListResponseNextInvoiceAmountCurrency.Npr,
            "nzd" => ContractListResponseNextInvoiceAmountCurrency.Nzd,
            "pgk" => ContractListResponseNextInvoiceAmountCurrency.Pgk,
            "php" => ContractListResponseNextInvoiceAmountCurrency.Php,
            "pkr" => ContractListResponseNextInvoiceAmountCurrency.Pkr,
            "pln" => ContractListResponseNextInvoiceAmountCurrency.Pln,
            "qar" => ContractListResponseNextInvoiceAmountCurrency.Qar,
            "ron" => ContractListResponseNextInvoiceAmountCurrency.Ron,
            "rsd" => ContractListResponseNextInvoiceAmountCurrency.Rsd,
            "rub" => ContractListResponseNextInvoiceAmountCurrency.Rub,
            "rwf" => ContractListResponseNextInvoiceAmountCurrency.Rwf,
            "sar" => ContractListResponseNextInvoiceAmountCurrency.Sar,
            "sbd" => ContractListResponseNextInvoiceAmountCurrency.Sbd,
            "scr" => ContractListResponseNextInvoiceAmountCurrency.Scr,
            "sek" => ContractListResponseNextInvoiceAmountCurrency.Sek,
            "sgd" => ContractListResponseNextInvoiceAmountCurrency.Sgd,
            "sle" => ContractListResponseNextInvoiceAmountCurrency.Sle,
            "sll" => ContractListResponseNextInvoiceAmountCurrency.Sll,
            "sos" => ContractListResponseNextInvoiceAmountCurrency.Sos,
            "szl" => ContractListResponseNextInvoiceAmountCurrency.Szl,
            "thb" => ContractListResponseNextInvoiceAmountCurrency.Thb,
            "tjs" => ContractListResponseNextInvoiceAmountCurrency.Tjs,
            "top" => ContractListResponseNextInvoiceAmountCurrency.Top,
            "try" => ContractListResponseNextInvoiceAmountCurrency.Try,
            "ttd" => ContractListResponseNextInvoiceAmountCurrency.Ttd,
            "tzs" => ContractListResponseNextInvoiceAmountCurrency.Tzs,
            "uah" => ContractListResponseNextInvoiceAmountCurrency.Uah,
            "uzs" => ContractListResponseNextInvoiceAmountCurrency.Uzs,
            "vnd" => ContractListResponseNextInvoiceAmountCurrency.Vnd,
            "vuv" => ContractListResponseNextInvoiceAmountCurrency.Vuv,
            "wst" => ContractListResponseNextInvoiceAmountCurrency.Wst,
            "xaf" => ContractListResponseNextInvoiceAmountCurrency.Xaf,
            "xcd" => ContractListResponseNextInvoiceAmountCurrency.Xcd,
            "yer" => ContractListResponseNextInvoiceAmountCurrency.Yer,
            "zar" => ContractListResponseNextInvoiceAmountCurrency.Zar,
            "zmw" => ContractListResponseNextInvoiceAmountCurrency.Zmw,
            "clp" => ContractListResponseNextInvoiceAmountCurrency.Clp,
            "djf" => ContractListResponseNextInvoiceAmountCurrency.Djf,
            "gnf" => ContractListResponseNextInvoiceAmountCurrency.Gnf,
            "ugx" => ContractListResponseNextInvoiceAmountCurrency.Ugx,
            "pyg" => ContractListResponseNextInvoiceAmountCurrency.Pyg,
            "xof" => ContractListResponseNextInvoiceAmountCurrency.Xof,
            "xpf" => ContractListResponseNextInvoiceAmountCurrency.Xpf,
            _ => (ContractListResponseNextInvoiceAmountCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ContractListResponseNextInvoiceAmountCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ContractListResponseNextInvoiceAmountCurrency.Usd => "usd",
                ContractListResponseNextInvoiceAmountCurrency.Aed => "aed",
                ContractListResponseNextInvoiceAmountCurrency.All => "all",
                ContractListResponseNextInvoiceAmountCurrency.Amd => "amd",
                ContractListResponseNextInvoiceAmountCurrency.Ang => "ang",
                ContractListResponseNextInvoiceAmountCurrency.Aud => "aud",
                ContractListResponseNextInvoiceAmountCurrency.Awg => "awg",
                ContractListResponseNextInvoiceAmountCurrency.Azn => "azn",
                ContractListResponseNextInvoiceAmountCurrency.Bam => "bam",
                ContractListResponseNextInvoiceAmountCurrency.Bbd => "bbd",
                ContractListResponseNextInvoiceAmountCurrency.Bdt => "bdt",
                ContractListResponseNextInvoiceAmountCurrency.Bgn => "bgn",
                ContractListResponseNextInvoiceAmountCurrency.Bif => "bif",
                ContractListResponseNextInvoiceAmountCurrency.Bmd => "bmd",
                ContractListResponseNextInvoiceAmountCurrency.Bnd => "bnd",
                ContractListResponseNextInvoiceAmountCurrency.Bsd => "bsd",
                ContractListResponseNextInvoiceAmountCurrency.Bwp => "bwp",
                ContractListResponseNextInvoiceAmountCurrency.Byn => "byn",
                ContractListResponseNextInvoiceAmountCurrency.Bzd => "bzd",
                ContractListResponseNextInvoiceAmountCurrency.Brl => "brl",
                ContractListResponseNextInvoiceAmountCurrency.Cad => "cad",
                ContractListResponseNextInvoiceAmountCurrency.Cdf => "cdf",
                ContractListResponseNextInvoiceAmountCurrency.Chf => "chf",
                ContractListResponseNextInvoiceAmountCurrency.Cny => "cny",
                ContractListResponseNextInvoiceAmountCurrency.Czk => "czk",
                ContractListResponseNextInvoiceAmountCurrency.Dkk => "dkk",
                ContractListResponseNextInvoiceAmountCurrency.Dop => "dop",
                ContractListResponseNextInvoiceAmountCurrency.Dzd => "dzd",
                ContractListResponseNextInvoiceAmountCurrency.Egp => "egp",
                ContractListResponseNextInvoiceAmountCurrency.Etb => "etb",
                ContractListResponseNextInvoiceAmountCurrency.Eur => "eur",
                ContractListResponseNextInvoiceAmountCurrency.Fjd => "fjd",
                ContractListResponseNextInvoiceAmountCurrency.Gbp => "gbp",
                ContractListResponseNextInvoiceAmountCurrency.Gel => "gel",
                ContractListResponseNextInvoiceAmountCurrency.Gip => "gip",
                ContractListResponseNextInvoiceAmountCurrency.Gmd => "gmd",
                ContractListResponseNextInvoiceAmountCurrency.Gyd => "gyd",
                ContractListResponseNextInvoiceAmountCurrency.Hkd => "hkd",
                ContractListResponseNextInvoiceAmountCurrency.Hrk => "hrk",
                ContractListResponseNextInvoiceAmountCurrency.Htg => "htg",
                ContractListResponseNextInvoiceAmountCurrency.Idr => "idr",
                ContractListResponseNextInvoiceAmountCurrency.Ils => "ils",
                ContractListResponseNextInvoiceAmountCurrency.Inr => "inr",
                ContractListResponseNextInvoiceAmountCurrency.Isk => "isk",
                ContractListResponseNextInvoiceAmountCurrency.Jmd => "jmd",
                ContractListResponseNextInvoiceAmountCurrency.Jpy => "jpy",
                ContractListResponseNextInvoiceAmountCurrency.Kes => "kes",
                ContractListResponseNextInvoiceAmountCurrency.Kgs => "kgs",
                ContractListResponseNextInvoiceAmountCurrency.Khr => "khr",
                ContractListResponseNextInvoiceAmountCurrency.Kmf => "kmf",
                ContractListResponseNextInvoiceAmountCurrency.Krw => "krw",
                ContractListResponseNextInvoiceAmountCurrency.Kyd => "kyd",
                ContractListResponseNextInvoiceAmountCurrency.Kzt => "kzt",
                ContractListResponseNextInvoiceAmountCurrency.Lbp => "lbp",
                ContractListResponseNextInvoiceAmountCurrency.Lkr => "lkr",
                ContractListResponseNextInvoiceAmountCurrency.Lrd => "lrd",
                ContractListResponseNextInvoiceAmountCurrency.Lsl => "lsl",
                ContractListResponseNextInvoiceAmountCurrency.Mad => "mad",
                ContractListResponseNextInvoiceAmountCurrency.Mdl => "mdl",
                ContractListResponseNextInvoiceAmountCurrency.Mga => "mga",
                ContractListResponseNextInvoiceAmountCurrency.Mkd => "mkd",
                ContractListResponseNextInvoiceAmountCurrency.Mmk => "mmk",
                ContractListResponseNextInvoiceAmountCurrency.Mnt => "mnt",
                ContractListResponseNextInvoiceAmountCurrency.Mop => "mop",
                ContractListResponseNextInvoiceAmountCurrency.Mro => "mro",
                ContractListResponseNextInvoiceAmountCurrency.Mvr => "mvr",
                ContractListResponseNextInvoiceAmountCurrency.Mwk => "mwk",
                ContractListResponseNextInvoiceAmountCurrency.Mxn => "mxn",
                ContractListResponseNextInvoiceAmountCurrency.Myr => "myr",
                ContractListResponseNextInvoiceAmountCurrency.Mzn => "mzn",
                ContractListResponseNextInvoiceAmountCurrency.Nad => "nad",
                ContractListResponseNextInvoiceAmountCurrency.Ngn => "ngn",
                ContractListResponseNextInvoiceAmountCurrency.Nok => "nok",
                ContractListResponseNextInvoiceAmountCurrency.Npr => "npr",
                ContractListResponseNextInvoiceAmountCurrency.Nzd => "nzd",
                ContractListResponseNextInvoiceAmountCurrency.Pgk => "pgk",
                ContractListResponseNextInvoiceAmountCurrency.Php => "php",
                ContractListResponseNextInvoiceAmountCurrency.Pkr => "pkr",
                ContractListResponseNextInvoiceAmountCurrency.Pln => "pln",
                ContractListResponseNextInvoiceAmountCurrency.Qar => "qar",
                ContractListResponseNextInvoiceAmountCurrency.Ron => "ron",
                ContractListResponseNextInvoiceAmountCurrency.Rsd => "rsd",
                ContractListResponseNextInvoiceAmountCurrency.Rub => "rub",
                ContractListResponseNextInvoiceAmountCurrency.Rwf => "rwf",
                ContractListResponseNextInvoiceAmountCurrency.Sar => "sar",
                ContractListResponseNextInvoiceAmountCurrency.Sbd => "sbd",
                ContractListResponseNextInvoiceAmountCurrency.Scr => "scr",
                ContractListResponseNextInvoiceAmountCurrency.Sek => "sek",
                ContractListResponseNextInvoiceAmountCurrency.Sgd => "sgd",
                ContractListResponseNextInvoiceAmountCurrency.Sle => "sle",
                ContractListResponseNextInvoiceAmountCurrency.Sll => "sll",
                ContractListResponseNextInvoiceAmountCurrency.Sos => "sos",
                ContractListResponseNextInvoiceAmountCurrency.Szl => "szl",
                ContractListResponseNextInvoiceAmountCurrency.Thb => "thb",
                ContractListResponseNextInvoiceAmountCurrency.Tjs => "tjs",
                ContractListResponseNextInvoiceAmountCurrency.Top => "top",
                ContractListResponseNextInvoiceAmountCurrency.Try => "try",
                ContractListResponseNextInvoiceAmountCurrency.Ttd => "ttd",
                ContractListResponseNextInvoiceAmountCurrency.Tzs => "tzs",
                ContractListResponseNextInvoiceAmountCurrency.Uah => "uah",
                ContractListResponseNextInvoiceAmountCurrency.Uzs => "uzs",
                ContractListResponseNextInvoiceAmountCurrency.Vnd => "vnd",
                ContractListResponseNextInvoiceAmountCurrency.Vuv => "vuv",
                ContractListResponseNextInvoiceAmountCurrency.Wst => "wst",
                ContractListResponseNextInvoiceAmountCurrency.Xaf => "xaf",
                ContractListResponseNextInvoiceAmountCurrency.Xcd => "xcd",
                ContractListResponseNextInvoiceAmountCurrency.Yer => "yer",
                ContractListResponseNextInvoiceAmountCurrency.Zar => "zar",
                ContractListResponseNextInvoiceAmountCurrency.Zmw => "zmw",
                ContractListResponseNextInvoiceAmountCurrency.Clp => "clp",
                ContractListResponseNextInvoiceAmountCurrency.Djf => "djf",
                ContractListResponseNextInvoiceAmountCurrency.Gnf => "gnf",
                ContractListResponseNextInvoiceAmountCurrency.Ugx => "ugx",
                ContractListResponseNextInvoiceAmountCurrency.Pyg => "pyg",
                ContractListResponseNextInvoiceAmountCurrency.Xof => "xof",
                ContractListResponseNextInvoiceAmountCurrency.Xpf => "xpf",
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
[JsonConverter(typeof(ContractListResponseStateConverter))]
public enum ContractListResponseState
{
    Draft,
    Active,
    Canceled,
    EndBilling,
}

sealed class ContractListResponseStateConverter : JsonConverter<ContractListResponseState>
{
    public override ContractListResponseState Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "DRAFT" => ContractListResponseState.Draft,
            "ACTIVE" => ContractListResponseState.Active,
            "CANCELED" => ContractListResponseState.Canceled,
            "END_BILLING" => ContractListResponseState.EndBilling,
            _ => (ContractListResponseState)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ContractListResponseState value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ContractListResponseState.Draft => "DRAFT",
                ContractListResponseState.Active => "ACTIVE",
                ContractListResponseState.Canceled => "CANCELED",
                ContractListResponseState.EndBilling => "END_BILLING",
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
        ContractListResponseSubscription,
        ContractListResponseSubscriptionFromRaw
    >)
)]
public sealed record class ContractListResponseSubscription : JsonModel
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

    public ContractListResponseSubscription() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ContractListResponseSubscription(
        ContractListResponseSubscription contractListResponseSubscription
    )
        : base(contractListResponseSubscription) { }
#pragma warning restore CS8618

    public ContractListResponseSubscription(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContractListResponseSubscription(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ContractListResponseSubscriptionFromRaw.FromRawUnchecked"/>
    public static ContractListResponseSubscription FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ContractListResponseSubscriptionFromRaw : IFromRawJson<ContractListResponseSubscription>
{
    /// <inheritdoc/>
    public ContractListResponseSubscription FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ContractListResponseSubscription.FromRawUnchecked(rawData);
}
