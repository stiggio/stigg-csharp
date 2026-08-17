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
[JsonConverter(
    typeof(JsonModelConverter<ContractRetrieveResponse, ContractRetrieveResponseFromRaw>)
)]
public sealed record class ContractRetrieveResponse : JsonModel
{
    /// <summary>
    /// A billing contract as reported by the connected billing provider.
    /// </summary>
    public required ContractRetrieveResponseData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ContractRetrieveResponseData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public ContractRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ContractRetrieveResponse(ContractRetrieveResponse contractRetrieveResponse)
        : base(contractRetrieveResponse) { }
#pragma warning restore CS8618

    public ContractRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContractRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ContractRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static ContractRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ContractRetrieveResponse(ContractRetrieveResponseData data)
        : this()
    {
        this.Data = data;
    }
}

class ContractRetrieveResponseFromRaw : IFromRawJson<ContractRetrieveResponse>
{
    /// <inheritdoc/>
    public ContractRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ContractRetrieveResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// A billing contract as reported by the connected billing provider.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ContractRetrieveResponseData, ContractRetrieveResponseDataFromRaw>)
)]
public sealed record class ContractRetrieveResponseData : JsonModel
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
    public required ApiEnum<string, ContractRetrieveResponseDataBillingState>? BillingState
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, ContractRetrieveResponseDataBillingState>
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
    public required ContractRetrieveResponseDataLatestInvoice? LatestInvoice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ContractRetrieveResponseDataLatestInvoice>(
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
    public required ContractRetrieveResponseDataNextInvoice? NextInvoice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ContractRetrieveResponseDataNextInvoice>(
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
    public required ApiEnum<string, ContractRetrieveResponseDataState> State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ContractRetrieveResponseDataState>
            >("state");
        }
        init { this._rawData.Set("state", value); }
    }

    /// <summary>
    /// The custom subscriptions attached to this contract (empty when none)
    /// </summary>
    public required IReadOnlyList<ContractRetrieveResponseDataSubscription> Subscriptions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<ContractRetrieveResponseDataSubscription>
            >("subscriptions");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ContractRetrieveResponseDataSubscription>>(
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

    public ContractRetrieveResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ContractRetrieveResponseData(ContractRetrieveResponseData contractRetrieveResponseData)
        : base(contractRetrieveResponseData) { }
#pragma warning restore CS8618

    public ContractRetrieveResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContractRetrieveResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ContractRetrieveResponseDataFromRaw.FromRawUnchecked"/>
    public static ContractRetrieveResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ContractRetrieveResponseDataFromRaw : IFromRawJson<ContractRetrieveResponseData>
{
    /// <inheritdoc/>
    public ContractRetrieveResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ContractRetrieveResponseData.FromRawUnchecked(rawData);
}

/// <summary>
/// The current state of the contract
/// </summary>
[JsonConverter(typeof(ContractRetrieveResponseDataBillingStateConverter))]
public enum ContractRetrieveResponseDataBillingState
{
    Draft,
    Active,
    Canceled,
    EndBilling,
}

sealed class ContractRetrieveResponseDataBillingStateConverter
    : JsonConverter<ContractRetrieveResponseDataBillingState>
{
    public override ContractRetrieveResponseDataBillingState Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "DRAFT" => ContractRetrieveResponseDataBillingState.Draft,
            "ACTIVE" => ContractRetrieveResponseDataBillingState.Active,
            "CANCELED" => ContractRetrieveResponseDataBillingState.Canceled,
            "END_BILLING" => ContractRetrieveResponseDataBillingState.EndBilling,
            _ => (ContractRetrieveResponseDataBillingState)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ContractRetrieveResponseDataBillingState value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ContractRetrieveResponseDataBillingState.Draft => "DRAFT",
                ContractRetrieveResponseDataBillingState.Active => "ACTIVE",
                ContractRetrieveResponseDataBillingState.Canceled => "CANCELED",
                ContractRetrieveResponseDataBillingState.EndBilling => "END_BILLING",
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
        ContractRetrieveResponseDataLatestInvoice,
        ContractRetrieveResponseDataLatestInvoiceFromRaw
    >)
)]
public sealed record class ContractRetrieveResponseDataLatestInvoice : JsonModel
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
    public required ApiEnum<string, ContractRetrieveResponseDataLatestInvoiceStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ContractRetrieveResponseDataLatestInvoiceStatus>
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
    public ApiEnum<string, ContractRetrieveResponseDataLatestInvoiceBillingReason>? BillingReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, ContractRetrieveResponseDataLatestInvoiceBillingReason>
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

    public ContractRetrieveResponseDataLatestInvoice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ContractRetrieveResponseDataLatestInvoice(
        ContractRetrieveResponseDataLatestInvoice contractRetrieveResponseDataLatestInvoice
    )
        : base(contractRetrieveResponseDataLatestInvoice) { }
#pragma warning restore CS8618

    public ContractRetrieveResponseDataLatestInvoice(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContractRetrieveResponseDataLatestInvoice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ContractRetrieveResponseDataLatestInvoiceFromRaw.FromRawUnchecked"/>
    public static ContractRetrieveResponseDataLatestInvoice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ContractRetrieveResponseDataLatestInvoiceFromRaw
    : IFromRawJson<ContractRetrieveResponseDataLatestInvoice>
{
    /// <inheritdoc/>
    public ContractRetrieveResponseDataLatestInvoice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ContractRetrieveResponseDataLatestInvoice.FromRawUnchecked(rawData);
}

/// <summary>
/// Invoice status
/// </summary>
[JsonConverter(typeof(ContractRetrieveResponseDataLatestInvoiceStatusConverter))]
public enum ContractRetrieveResponseDataLatestInvoiceStatus
{
    Open,
    Canceled,
    Paid,
}

sealed class ContractRetrieveResponseDataLatestInvoiceStatusConverter
    : JsonConverter<ContractRetrieveResponseDataLatestInvoiceStatus>
{
    public override ContractRetrieveResponseDataLatestInvoiceStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "OPEN" => ContractRetrieveResponseDataLatestInvoiceStatus.Open,
            "CANCELED" => ContractRetrieveResponseDataLatestInvoiceStatus.Canceled,
            "PAID" => ContractRetrieveResponseDataLatestInvoiceStatus.Paid,
            _ => (ContractRetrieveResponseDataLatestInvoiceStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ContractRetrieveResponseDataLatestInvoiceStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ContractRetrieveResponseDataLatestInvoiceStatus.Open => "OPEN",
                ContractRetrieveResponseDataLatestInvoiceStatus.Canceled => "CANCELED",
                ContractRetrieveResponseDataLatestInvoiceStatus.Paid => "PAID",
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
[JsonConverter(typeof(ContractRetrieveResponseDataLatestInvoiceBillingReasonConverter))]
public enum ContractRetrieveResponseDataLatestInvoiceBillingReason
{
    BillingCycle,
    SubscriptionCreation,
    SubscriptionUpdate,
    Manual,
    MinimumInvoiceAmountExceeded,
    Other,
}

sealed class ContractRetrieveResponseDataLatestInvoiceBillingReasonConverter
    : JsonConverter<ContractRetrieveResponseDataLatestInvoiceBillingReason>
{
    public override ContractRetrieveResponseDataLatestInvoiceBillingReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "BILLING_CYCLE" => ContractRetrieveResponseDataLatestInvoiceBillingReason.BillingCycle,
            "SUBSCRIPTION_CREATION" =>
                ContractRetrieveResponseDataLatestInvoiceBillingReason.SubscriptionCreation,
            "SUBSCRIPTION_UPDATE" =>
                ContractRetrieveResponseDataLatestInvoiceBillingReason.SubscriptionUpdate,
            "MANUAL" => ContractRetrieveResponseDataLatestInvoiceBillingReason.Manual,
            "MINIMUM_INVOICE_AMOUNT_EXCEEDED" =>
                ContractRetrieveResponseDataLatestInvoiceBillingReason.MinimumInvoiceAmountExceeded,
            "OTHER" => ContractRetrieveResponseDataLatestInvoiceBillingReason.Other,
            _ => (ContractRetrieveResponseDataLatestInvoiceBillingReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ContractRetrieveResponseDataLatestInvoiceBillingReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ContractRetrieveResponseDataLatestInvoiceBillingReason.BillingCycle =>
                    "BILLING_CYCLE",
                ContractRetrieveResponseDataLatestInvoiceBillingReason.SubscriptionCreation =>
                    "SUBSCRIPTION_CREATION",
                ContractRetrieveResponseDataLatestInvoiceBillingReason.SubscriptionUpdate =>
                    "SUBSCRIPTION_UPDATE",
                ContractRetrieveResponseDataLatestInvoiceBillingReason.Manual => "MANUAL",
                ContractRetrieveResponseDataLatestInvoiceBillingReason.MinimumInvoiceAmountExceeded =>
                    "MINIMUM_INVOICE_AMOUNT_EXCEEDED",
                ContractRetrieveResponseDataLatestInvoiceBillingReason.Other => "OTHER",
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
        ContractRetrieveResponseDataNextInvoice,
        ContractRetrieveResponseDataNextInvoiceFromRaw
    >)
)]
public sealed record class ContractRetrieveResponseDataNextInvoice : JsonModel
{
    /// <summary>
    /// The total amount of the upcoming invoice
    /// </summary>
    public required ContractRetrieveResponseDataNextInvoiceAmount Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ContractRetrieveResponseDataNextInvoiceAmount>(
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
    /// The billing provider ID of the draft invoice this preview describes
    /// </summary>
    public required string? InvoiceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("invoiceId");
        }
        init { this._rawData.Set("invoiceId", value); }
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
        _ = this.InvoiceID;
        _ = this.PeriodEnd;
        _ = this.PeriodStart;
    }

    public ContractRetrieveResponseDataNextInvoice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ContractRetrieveResponseDataNextInvoice(
        ContractRetrieveResponseDataNextInvoice contractRetrieveResponseDataNextInvoice
    )
        : base(contractRetrieveResponseDataNextInvoice) { }
#pragma warning restore CS8618

    public ContractRetrieveResponseDataNextInvoice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContractRetrieveResponseDataNextInvoice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ContractRetrieveResponseDataNextInvoiceFromRaw.FromRawUnchecked"/>
    public static ContractRetrieveResponseDataNextInvoice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ContractRetrieveResponseDataNextInvoiceFromRaw
    : IFromRawJson<ContractRetrieveResponseDataNextInvoice>
{
    /// <inheritdoc/>
    public ContractRetrieveResponseDataNextInvoice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ContractRetrieveResponseDataNextInvoice.FromRawUnchecked(rawData);
}

/// <summary>
/// The total amount of the upcoming invoice
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ContractRetrieveResponseDataNextInvoiceAmount,
        ContractRetrieveResponseDataNextInvoiceAmountFromRaw
    >)
)]
public sealed record class ContractRetrieveResponseDataNextInvoiceAmount : JsonModel
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
    public required ApiEnum<string, ContractRetrieveResponseDataNextInvoiceAmountCurrency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ContractRetrieveResponseDataNextInvoiceAmountCurrency>
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

    public ContractRetrieveResponseDataNextInvoiceAmount() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ContractRetrieveResponseDataNextInvoiceAmount(
        ContractRetrieveResponseDataNextInvoiceAmount contractRetrieveResponseDataNextInvoiceAmount
    )
        : base(contractRetrieveResponseDataNextInvoiceAmount) { }
#pragma warning restore CS8618

    public ContractRetrieveResponseDataNextInvoiceAmount(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContractRetrieveResponseDataNextInvoiceAmount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ContractRetrieveResponseDataNextInvoiceAmountFromRaw.FromRawUnchecked"/>
    public static ContractRetrieveResponseDataNextInvoiceAmount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ContractRetrieveResponseDataNextInvoiceAmountFromRaw
    : IFromRawJson<ContractRetrieveResponseDataNextInvoiceAmount>
{
    /// <inheritdoc/>
    public ContractRetrieveResponseDataNextInvoiceAmount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ContractRetrieveResponseDataNextInvoiceAmount.FromRawUnchecked(rawData);
}

/// <summary>
/// ISO 4217 currency code
/// </summary>
[JsonConverter(typeof(ContractRetrieveResponseDataNextInvoiceAmountCurrencyConverter))]
public enum ContractRetrieveResponseDataNextInvoiceAmountCurrency
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

sealed class ContractRetrieveResponseDataNextInvoiceAmountCurrencyConverter
    : JsonConverter<ContractRetrieveResponseDataNextInvoiceAmountCurrency>
{
    public override ContractRetrieveResponseDataNextInvoiceAmountCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Usd,
            "aed" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Aed,
            "all" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.All,
            "amd" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Amd,
            "ang" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Ang,
            "aud" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Aud,
            "awg" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Awg,
            "azn" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Azn,
            "bam" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Bam,
            "bbd" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Bbd,
            "bdt" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Bdt,
            "bgn" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Bgn,
            "bif" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Bif,
            "bmd" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Bmd,
            "bnd" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Bnd,
            "bsd" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Bsd,
            "bwp" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Bwp,
            "byn" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Byn,
            "bzd" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Bzd,
            "brl" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Brl,
            "cad" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Cad,
            "cdf" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Cdf,
            "chf" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Chf,
            "cny" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Cny,
            "czk" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Czk,
            "dkk" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Dkk,
            "dop" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Dop,
            "dzd" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Dzd,
            "egp" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Egp,
            "etb" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Etb,
            "eur" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Eur,
            "fjd" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Fjd,
            "gbp" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Gbp,
            "gel" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Gel,
            "gip" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Gip,
            "gmd" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Gmd,
            "gyd" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Gyd,
            "hkd" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Hkd,
            "hrk" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Hrk,
            "htg" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Htg,
            "idr" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Idr,
            "ils" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Ils,
            "inr" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Inr,
            "isk" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Isk,
            "jmd" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Jmd,
            "jpy" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Jpy,
            "kes" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Kes,
            "kgs" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Kgs,
            "khr" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Khr,
            "kmf" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Kmf,
            "krw" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Krw,
            "kyd" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Kyd,
            "kzt" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Kzt,
            "lbp" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Lbp,
            "lkr" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Lkr,
            "lrd" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Lrd,
            "lsl" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Lsl,
            "mad" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Mad,
            "mdl" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Mdl,
            "mga" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Mga,
            "mkd" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Mkd,
            "mmk" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Mmk,
            "mnt" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Mnt,
            "mop" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Mop,
            "mro" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Mro,
            "mvr" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Mvr,
            "mwk" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Mwk,
            "mxn" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Mxn,
            "myr" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Myr,
            "mzn" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Mzn,
            "nad" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Nad,
            "ngn" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Ngn,
            "nok" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Nok,
            "npr" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Npr,
            "nzd" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Nzd,
            "pgk" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Pgk,
            "php" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Php,
            "pkr" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Pkr,
            "pln" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Pln,
            "qar" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Qar,
            "ron" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Ron,
            "rsd" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Rsd,
            "rub" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Rub,
            "rwf" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Rwf,
            "sar" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Sar,
            "sbd" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Sbd,
            "scr" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Scr,
            "sek" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Sek,
            "sgd" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Sgd,
            "sle" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Sle,
            "sll" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Sll,
            "sos" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Sos,
            "szl" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Szl,
            "thb" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Thb,
            "tjs" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Tjs,
            "top" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Top,
            "try" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Try,
            "ttd" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Ttd,
            "tzs" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Tzs,
            "uah" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Uah,
            "uzs" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Uzs,
            "vnd" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Vnd,
            "vuv" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Vuv,
            "wst" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Wst,
            "xaf" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Xaf,
            "xcd" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Xcd,
            "yer" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Yer,
            "zar" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Zar,
            "zmw" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Zmw,
            "clp" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Clp,
            "djf" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Djf,
            "gnf" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Gnf,
            "ugx" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Ugx,
            "pyg" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Pyg,
            "xof" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Xof,
            "xpf" => ContractRetrieveResponseDataNextInvoiceAmountCurrency.Xpf,
            _ => (ContractRetrieveResponseDataNextInvoiceAmountCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ContractRetrieveResponseDataNextInvoiceAmountCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Usd => "usd",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Aed => "aed",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.All => "all",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Amd => "amd",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Ang => "ang",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Aud => "aud",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Awg => "awg",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Azn => "azn",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Bam => "bam",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Bbd => "bbd",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Bdt => "bdt",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Bgn => "bgn",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Bif => "bif",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Bmd => "bmd",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Bnd => "bnd",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Bsd => "bsd",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Bwp => "bwp",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Byn => "byn",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Bzd => "bzd",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Brl => "brl",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Cad => "cad",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Cdf => "cdf",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Chf => "chf",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Cny => "cny",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Czk => "czk",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Dkk => "dkk",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Dop => "dop",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Dzd => "dzd",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Egp => "egp",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Etb => "etb",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Eur => "eur",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Fjd => "fjd",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Gbp => "gbp",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Gel => "gel",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Gip => "gip",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Gmd => "gmd",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Gyd => "gyd",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Hkd => "hkd",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Hrk => "hrk",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Htg => "htg",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Idr => "idr",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Ils => "ils",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Inr => "inr",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Isk => "isk",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Jmd => "jmd",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Jpy => "jpy",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Kes => "kes",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Kgs => "kgs",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Khr => "khr",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Kmf => "kmf",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Krw => "krw",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Kyd => "kyd",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Kzt => "kzt",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Lbp => "lbp",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Lkr => "lkr",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Lrd => "lrd",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Lsl => "lsl",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Mad => "mad",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Mdl => "mdl",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Mga => "mga",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Mkd => "mkd",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Mmk => "mmk",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Mnt => "mnt",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Mop => "mop",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Mro => "mro",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Mvr => "mvr",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Mwk => "mwk",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Mxn => "mxn",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Myr => "myr",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Mzn => "mzn",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Nad => "nad",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Ngn => "ngn",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Nok => "nok",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Npr => "npr",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Nzd => "nzd",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Pgk => "pgk",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Php => "php",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Pkr => "pkr",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Pln => "pln",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Qar => "qar",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Ron => "ron",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Rsd => "rsd",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Rub => "rub",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Rwf => "rwf",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Sar => "sar",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Sbd => "sbd",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Scr => "scr",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Sek => "sek",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Sgd => "sgd",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Sle => "sle",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Sll => "sll",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Sos => "sos",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Szl => "szl",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Thb => "thb",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Tjs => "tjs",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Top => "top",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Try => "try",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Ttd => "ttd",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Tzs => "tzs",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Uah => "uah",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Uzs => "uzs",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Vnd => "vnd",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Vuv => "vuv",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Wst => "wst",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Xaf => "xaf",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Xcd => "xcd",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Yer => "yer",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Zar => "zar",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Zmw => "zmw",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Clp => "clp",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Djf => "djf",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Gnf => "gnf",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Ugx => "ugx",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Pyg => "pyg",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Xof => "xof",
                ContractRetrieveResponseDataNextInvoiceAmountCurrency.Xpf => "xpf",
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
[JsonConverter(typeof(ContractRetrieveResponseDataStateConverter))]
public enum ContractRetrieveResponseDataState
{
    Draft,
    Active,
    Canceled,
    EndBilling,
}

sealed class ContractRetrieveResponseDataStateConverter
    : JsonConverter<ContractRetrieveResponseDataState>
{
    public override ContractRetrieveResponseDataState Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "DRAFT" => ContractRetrieveResponseDataState.Draft,
            "ACTIVE" => ContractRetrieveResponseDataState.Active,
            "CANCELED" => ContractRetrieveResponseDataState.Canceled,
            "END_BILLING" => ContractRetrieveResponseDataState.EndBilling,
            _ => (ContractRetrieveResponseDataState)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ContractRetrieveResponseDataState value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ContractRetrieveResponseDataState.Draft => "DRAFT",
                ContractRetrieveResponseDataState.Active => "ACTIVE",
                ContractRetrieveResponseDataState.Canceled => "CANCELED",
                ContractRetrieveResponseDataState.EndBilling => "END_BILLING",
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
        ContractRetrieveResponseDataSubscription,
        ContractRetrieveResponseDataSubscriptionFromRaw
    >)
)]
public sealed record class ContractRetrieveResponseDataSubscription : JsonModel
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

    public ContractRetrieveResponseDataSubscription() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ContractRetrieveResponseDataSubscription(
        ContractRetrieveResponseDataSubscription contractRetrieveResponseDataSubscription
    )
        : base(contractRetrieveResponseDataSubscription) { }
#pragma warning restore CS8618

    public ContractRetrieveResponseDataSubscription(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContractRetrieveResponseDataSubscription(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ContractRetrieveResponseDataSubscriptionFromRaw.FromRawUnchecked"/>
    public static ContractRetrieveResponseDataSubscription FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ContractRetrieveResponseDataSubscriptionFromRaw
    : IFromRawJson<ContractRetrieveResponseDataSubscription>
{
    /// <inheritdoc/>
    public ContractRetrieveResponseDataSubscription FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ContractRetrieveResponseDataSubscription.FromRawUnchecked(rawData);
}
