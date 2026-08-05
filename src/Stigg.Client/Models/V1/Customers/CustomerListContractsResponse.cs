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
/// A list of a customer's contracts
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<CustomerListContractsResponse, CustomerListContractsResponseFromRaw>)
)]
public sealed record class CustomerListContractsResponse : JsonModel
{
    public required IReadOnlyList<CustomerListContractsResponseData> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<CustomerListContractsResponseData>
            >("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<CustomerListContractsResponseData>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
    }

    public CustomerListContractsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerListContractsResponse(
        CustomerListContractsResponse customerListContractsResponse
    )
        : base(customerListContractsResponse) { }
#pragma warning restore CS8618

    public CustomerListContractsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerListContractsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerListContractsResponseFromRaw.FromRawUnchecked"/>
    public static CustomerListContractsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CustomerListContractsResponse(IReadOnlyList<CustomerListContractsResponseData> data)
        : this()
    {
        this.Data = data;
    }
}

class CustomerListContractsResponseFromRaw : IFromRawJson<CustomerListContractsResponse>
{
    /// <inheritdoc/>
    public CustomerListContractsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerListContractsResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// A billing contract as reported by the connected billing provider.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CustomerListContractsResponseData,
        CustomerListContractsResponseDataFromRaw
    >)
)]
public sealed record class CustomerListContractsResponseData : JsonModel
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
    public required ApiEnum<string, BillingState>? BillingState
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, BillingState>>("billingState");
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
    public required LatestInvoice? LatestInvoice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<LatestInvoice>("latestInvoice");
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
    public required NextInvoice? NextInvoice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NextInvoice>("nextInvoice");
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
    public required ApiEnum<string, State> State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, State>>("state");
        }
        init { this._rawData.Set("state", value); }
    }

    /// <summary>
    /// The custom subscriptions attached to this contract (empty when none)
    /// </summary>
    public required IReadOnlyList<Subscription> Subscriptions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Subscription>>("subscriptions");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Subscription>>(
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

    public CustomerListContractsResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerListContractsResponseData(
        CustomerListContractsResponseData customerListContractsResponseData
    )
        : base(customerListContractsResponseData) { }
#pragma warning restore CS8618

    public CustomerListContractsResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerListContractsResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerListContractsResponseDataFromRaw.FromRawUnchecked"/>
    public static CustomerListContractsResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerListContractsResponseDataFromRaw : IFromRawJson<CustomerListContractsResponseData>
{
    /// <inheritdoc/>
    public CustomerListContractsResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerListContractsResponseData.FromRawUnchecked(rawData);
}

/// <summary>
/// The current state of the contract
/// </summary>
[JsonConverter(typeof(BillingStateConverter))]
public enum BillingState
{
    Draft,
    Active,
    Canceled,
    EndBilling,
}

sealed class BillingStateConverter : JsonConverter<BillingState>
{
    public override BillingState Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "DRAFT" => BillingState.Draft,
            "ACTIVE" => BillingState.Active,
            "CANCELED" => BillingState.Canceled,
            "END_BILLING" => BillingState.EndBilling,
            _ => (BillingState)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BillingState value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BillingState.Draft => "DRAFT",
                BillingState.Active => "ACTIVE",
                BillingState.Canceled => "CANCELED",
                BillingState.EndBilling => "END_BILLING",
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
[JsonConverter(typeof(JsonModelConverter<LatestInvoice, LatestInvoiceFromRaw>))]
public sealed record class LatestInvoice : JsonModel
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
    public required ApiEnum<string, Status> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Status>>("status");
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
    public ApiEnum<string, BillingReason>? BillingReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, BillingReason>>("billingReason");
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

    public LatestInvoice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LatestInvoice(LatestInvoice latestInvoice)
        : base(latestInvoice) { }
#pragma warning restore CS8618

    public LatestInvoice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LatestInvoice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LatestInvoiceFromRaw.FromRawUnchecked"/>
    public static LatestInvoice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LatestInvoiceFromRaw : IFromRawJson<LatestInvoice>
{
    /// <inheritdoc/>
    public LatestInvoice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        LatestInvoice.FromRawUnchecked(rawData);
}

/// <summary>
/// Invoice status
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Open,
    Canceled,
    Paid,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "OPEN" => Status.Open,
            "CANCELED" => Status.Canceled,
            "PAID" => Status.Paid,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Open => "OPEN",
                Status.Canceled => "CANCELED",
                Status.Paid => "PAID",
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
[JsonConverter(typeof(BillingReasonConverter))]
public enum BillingReason
{
    BillingCycle,
    SubscriptionCreation,
    SubscriptionUpdate,
    Manual,
    MinimumInvoiceAmountExceeded,
    Other,
}

sealed class BillingReasonConverter : JsonConverter<BillingReason>
{
    public override BillingReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "BILLING_CYCLE" => BillingReason.BillingCycle,
            "SUBSCRIPTION_CREATION" => BillingReason.SubscriptionCreation,
            "SUBSCRIPTION_UPDATE" => BillingReason.SubscriptionUpdate,
            "MANUAL" => BillingReason.Manual,
            "MINIMUM_INVOICE_AMOUNT_EXCEEDED" => BillingReason.MinimumInvoiceAmountExceeded,
            "OTHER" => BillingReason.Other,
            _ => (BillingReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BillingReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BillingReason.BillingCycle => "BILLING_CYCLE",
                BillingReason.SubscriptionCreation => "SUBSCRIPTION_CREATION",
                BillingReason.SubscriptionUpdate => "SUBSCRIPTION_UPDATE",
                BillingReason.Manual => "MANUAL",
                BillingReason.MinimumInvoiceAmountExceeded => "MINIMUM_INVOICE_AMOUNT_EXCEEDED",
                BillingReason.Other => "OTHER",
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
[JsonConverter(typeof(JsonModelConverter<NextInvoice, NextInvoiceFromRaw>))]
public sealed record class NextInvoice : JsonModel
{
    /// <summary>
    /// The total amount of the upcoming invoice
    /// </summary>
    public required Amount Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Amount>("amount");
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

    public NextInvoice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NextInvoice(NextInvoice nextInvoice)
        : base(nextInvoice) { }
#pragma warning restore CS8618

    public NextInvoice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NextInvoice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NextInvoiceFromRaw.FromRawUnchecked"/>
    public static NextInvoice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NextInvoiceFromRaw : IFromRawJson<NextInvoice>
{
    /// <inheritdoc/>
    public NextInvoice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        NextInvoice.FromRawUnchecked(rawData);
}

/// <summary>
/// The total amount of the upcoming invoice
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Amount, AmountFromRaw>))]
public sealed record class Amount : JsonModel
{
    /// <summary>
    /// The price amount
    /// </summary>
    public required double AmountValue
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
    public required ApiEnum<string, AmountCurrency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AmountCurrency>>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AmountValue;
        this.Currency.Validate();
    }

    public Amount() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Amount(Amount amount)
        : base(amount) { }
#pragma warning restore CS8618

    public Amount(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Amount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AmountFromRaw.FromRawUnchecked"/>
    public static Amount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AmountFromRaw : IFromRawJson<Amount>
{
    /// <inheritdoc/>
    public Amount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Amount.FromRawUnchecked(rawData);
}

/// <summary>
/// ISO 4217 currency code
/// </summary>
[JsonConverter(typeof(AmountCurrencyConverter))]
public enum AmountCurrency
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

sealed class AmountCurrencyConverter : JsonConverter<AmountCurrency>
{
    public override AmountCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => AmountCurrency.Usd,
            "aed" => AmountCurrency.Aed,
            "all" => AmountCurrency.All,
            "amd" => AmountCurrency.Amd,
            "ang" => AmountCurrency.Ang,
            "aud" => AmountCurrency.Aud,
            "awg" => AmountCurrency.Awg,
            "azn" => AmountCurrency.Azn,
            "bam" => AmountCurrency.Bam,
            "bbd" => AmountCurrency.Bbd,
            "bdt" => AmountCurrency.Bdt,
            "bgn" => AmountCurrency.Bgn,
            "bif" => AmountCurrency.Bif,
            "bmd" => AmountCurrency.Bmd,
            "bnd" => AmountCurrency.Bnd,
            "bsd" => AmountCurrency.Bsd,
            "bwp" => AmountCurrency.Bwp,
            "byn" => AmountCurrency.Byn,
            "bzd" => AmountCurrency.Bzd,
            "brl" => AmountCurrency.Brl,
            "cad" => AmountCurrency.Cad,
            "cdf" => AmountCurrency.Cdf,
            "chf" => AmountCurrency.Chf,
            "cny" => AmountCurrency.Cny,
            "czk" => AmountCurrency.Czk,
            "dkk" => AmountCurrency.Dkk,
            "dop" => AmountCurrency.Dop,
            "dzd" => AmountCurrency.Dzd,
            "egp" => AmountCurrency.Egp,
            "etb" => AmountCurrency.Etb,
            "eur" => AmountCurrency.Eur,
            "fjd" => AmountCurrency.Fjd,
            "gbp" => AmountCurrency.Gbp,
            "gel" => AmountCurrency.Gel,
            "gip" => AmountCurrency.Gip,
            "gmd" => AmountCurrency.Gmd,
            "gyd" => AmountCurrency.Gyd,
            "hkd" => AmountCurrency.Hkd,
            "hrk" => AmountCurrency.Hrk,
            "htg" => AmountCurrency.Htg,
            "idr" => AmountCurrency.Idr,
            "ils" => AmountCurrency.Ils,
            "inr" => AmountCurrency.Inr,
            "isk" => AmountCurrency.Isk,
            "jmd" => AmountCurrency.Jmd,
            "jpy" => AmountCurrency.Jpy,
            "kes" => AmountCurrency.Kes,
            "kgs" => AmountCurrency.Kgs,
            "khr" => AmountCurrency.Khr,
            "kmf" => AmountCurrency.Kmf,
            "krw" => AmountCurrency.Krw,
            "kyd" => AmountCurrency.Kyd,
            "kzt" => AmountCurrency.Kzt,
            "lbp" => AmountCurrency.Lbp,
            "lkr" => AmountCurrency.Lkr,
            "lrd" => AmountCurrency.Lrd,
            "lsl" => AmountCurrency.Lsl,
            "mad" => AmountCurrency.Mad,
            "mdl" => AmountCurrency.Mdl,
            "mga" => AmountCurrency.Mga,
            "mkd" => AmountCurrency.Mkd,
            "mmk" => AmountCurrency.Mmk,
            "mnt" => AmountCurrency.Mnt,
            "mop" => AmountCurrency.Mop,
            "mro" => AmountCurrency.Mro,
            "mvr" => AmountCurrency.Mvr,
            "mwk" => AmountCurrency.Mwk,
            "mxn" => AmountCurrency.Mxn,
            "myr" => AmountCurrency.Myr,
            "mzn" => AmountCurrency.Mzn,
            "nad" => AmountCurrency.Nad,
            "ngn" => AmountCurrency.Ngn,
            "nok" => AmountCurrency.Nok,
            "npr" => AmountCurrency.Npr,
            "nzd" => AmountCurrency.Nzd,
            "pgk" => AmountCurrency.Pgk,
            "php" => AmountCurrency.Php,
            "pkr" => AmountCurrency.Pkr,
            "pln" => AmountCurrency.Pln,
            "qar" => AmountCurrency.Qar,
            "ron" => AmountCurrency.Ron,
            "rsd" => AmountCurrency.Rsd,
            "rub" => AmountCurrency.Rub,
            "rwf" => AmountCurrency.Rwf,
            "sar" => AmountCurrency.Sar,
            "sbd" => AmountCurrency.Sbd,
            "scr" => AmountCurrency.Scr,
            "sek" => AmountCurrency.Sek,
            "sgd" => AmountCurrency.Sgd,
            "sle" => AmountCurrency.Sle,
            "sll" => AmountCurrency.Sll,
            "sos" => AmountCurrency.Sos,
            "szl" => AmountCurrency.Szl,
            "thb" => AmountCurrency.Thb,
            "tjs" => AmountCurrency.Tjs,
            "top" => AmountCurrency.Top,
            "try" => AmountCurrency.Try,
            "ttd" => AmountCurrency.Ttd,
            "tzs" => AmountCurrency.Tzs,
            "uah" => AmountCurrency.Uah,
            "uzs" => AmountCurrency.Uzs,
            "vnd" => AmountCurrency.Vnd,
            "vuv" => AmountCurrency.Vuv,
            "wst" => AmountCurrency.Wst,
            "xaf" => AmountCurrency.Xaf,
            "xcd" => AmountCurrency.Xcd,
            "yer" => AmountCurrency.Yer,
            "zar" => AmountCurrency.Zar,
            "zmw" => AmountCurrency.Zmw,
            "clp" => AmountCurrency.Clp,
            "djf" => AmountCurrency.Djf,
            "gnf" => AmountCurrency.Gnf,
            "ugx" => AmountCurrency.Ugx,
            "pyg" => AmountCurrency.Pyg,
            "xof" => AmountCurrency.Xof,
            "xpf" => AmountCurrency.Xpf,
            _ => (AmountCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AmountCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AmountCurrency.Usd => "usd",
                AmountCurrency.Aed => "aed",
                AmountCurrency.All => "all",
                AmountCurrency.Amd => "amd",
                AmountCurrency.Ang => "ang",
                AmountCurrency.Aud => "aud",
                AmountCurrency.Awg => "awg",
                AmountCurrency.Azn => "azn",
                AmountCurrency.Bam => "bam",
                AmountCurrency.Bbd => "bbd",
                AmountCurrency.Bdt => "bdt",
                AmountCurrency.Bgn => "bgn",
                AmountCurrency.Bif => "bif",
                AmountCurrency.Bmd => "bmd",
                AmountCurrency.Bnd => "bnd",
                AmountCurrency.Bsd => "bsd",
                AmountCurrency.Bwp => "bwp",
                AmountCurrency.Byn => "byn",
                AmountCurrency.Bzd => "bzd",
                AmountCurrency.Brl => "brl",
                AmountCurrency.Cad => "cad",
                AmountCurrency.Cdf => "cdf",
                AmountCurrency.Chf => "chf",
                AmountCurrency.Cny => "cny",
                AmountCurrency.Czk => "czk",
                AmountCurrency.Dkk => "dkk",
                AmountCurrency.Dop => "dop",
                AmountCurrency.Dzd => "dzd",
                AmountCurrency.Egp => "egp",
                AmountCurrency.Etb => "etb",
                AmountCurrency.Eur => "eur",
                AmountCurrency.Fjd => "fjd",
                AmountCurrency.Gbp => "gbp",
                AmountCurrency.Gel => "gel",
                AmountCurrency.Gip => "gip",
                AmountCurrency.Gmd => "gmd",
                AmountCurrency.Gyd => "gyd",
                AmountCurrency.Hkd => "hkd",
                AmountCurrency.Hrk => "hrk",
                AmountCurrency.Htg => "htg",
                AmountCurrency.Idr => "idr",
                AmountCurrency.Ils => "ils",
                AmountCurrency.Inr => "inr",
                AmountCurrency.Isk => "isk",
                AmountCurrency.Jmd => "jmd",
                AmountCurrency.Jpy => "jpy",
                AmountCurrency.Kes => "kes",
                AmountCurrency.Kgs => "kgs",
                AmountCurrency.Khr => "khr",
                AmountCurrency.Kmf => "kmf",
                AmountCurrency.Krw => "krw",
                AmountCurrency.Kyd => "kyd",
                AmountCurrency.Kzt => "kzt",
                AmountCurrency.Lbp => "lbp",
                AmountCurrency.Lkr => "lkr",
                AmountCurrency.Lrd => "lrd",
                AmountCurrency.Lsl => "lsl",
                AmountCurrency.Mad => "mad",
                AmountCurrency.Mdl => "mdl",
                AmountCurrency.Mga => "mga",
                AmountCurrency.Mkd => "mkd",
                AmountCurrency.Mmk => "mmk",
                AmountCurrency.Mnt => "mnt",
                AmountCurrency.Mop => "mop",
                AmountCurrency.Mro => "mro",
                AmountCurrency.Mvr => "mvr",
                AmountCurrency.Mwk => "mwk",
                AmountCurrency.Mxn => "mxn",
                AmountCurrency.Myr => "myr",
                AmountCurrency.Mzn => "mzn",
                AmountCurrency.Nad => "nad",
                AmountCurrency.Ngn => "ngn",
                AmountCurrency.Nok => "nok",
                AmountCurrency.Npr => "npr",
                AmountCurrency.Nzd => "nzd",
                AmountCurrency.Pgk => "pgk",
                AmountCurrency.Php => "php",
                AmountCurrency.Pkr => "pkr",
                AmountCurrency.Pln => "pln",
                AmountCurrency.Qar => "qar",
                AmountCurrency.Ron => "ron",
                AmountCurrency.Rsd => "rsd",
                AmountCurrency.Rub => "rub",
                AmountCurrency.Rwf => "rwf",
                AmountCurrency.Sar => "sar",
                AmountCurrency.Sbd => "sbd",
                AmountCurrency.Scr => "scr",
                AmountCurrency.Sek => "sek",
                AmountCurrency.Sgd => "sgd",
                AmountCurrency.Sle => "sle",
                AmountCurrency.Sll => "sll",
                AmountCurrency.Sos => "sos",
                AmountCurrency.Szl => "szl",
                AmountCurrency.Thb => "thb",
                AmountCurrency.Tjs => "tjs",
                AmountCurrency.Top => "top",
                AmountCurrency.Try => "try",
                AmountCurrency.Ttd => "ttd",
                AmountCurrency.Tzs => "tzs",
                AmountCurrency.Uah => "uah",
                AmountCurrency.Uzs => "uzs",
                AmountCurrency.Vnd => "vnd",
                AmountCurrency.Vuv => "vuv",
                AmountCurrency.Wst => "wst",
                AmountCurrency.Xaf => "xaf",
                AmountCurrency.Xcd => "xcd",
                AmountCurrency.Yer => "yer",
                AmountCurrency.Zar => "zar",
                AmountCurrency.Zmw => "zmw",
                AmountCurrency.Clp => "clp",
                AmountCurrency.Djf => "djf",
                AmountCurrency.Gnf => "gnf",
                AmountCurrency.Ugx => "ugx",
                AmountCurrency.Pyg => "pyg",
                AmountCurrency.Xof => "xof",
                AmountCurrency.Xpf => "xpf",
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
[JsonConverter(typeof(StateConverter))]
public enum State
{
    Draft,
    Active,
    Canceled,
    EndBilling,
}

sealed class StateConverter : JsonConverter<State>
{
    public override State Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "DRAFT" => State.Draft,
            "ACTIVE" => State.Active,
            "CANCELED" => State.Canceled,
            "END_BILLING" => State.EndBilling,
            _ => (State)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, State value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                State.Draft => "DRAFT",
                State.Active => "ACTIVE",
                State.Canceled => "CANCELED",
                State.EndBilling => "END_BILLING",
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
[JsonConverter(typeof(JsonModelConverter<Subscription, SubscriptionFromRaw>))]
public sealed record class Subscription : JsonModel
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

    public Subscription() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Subscription(Subscription subscription)
        : base(subscription) { }
#pragma warning restore CS8618

    public Subscription(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Subscription(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionFromRaw.FromRawUnchecked"/>
    public static Subscription FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionFromRaw : IFromRawJson<Subscription>
{
    /// <inheritdoc/>
    public Subscription FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Subscription.FromRawUnchecked(rawData);
}
