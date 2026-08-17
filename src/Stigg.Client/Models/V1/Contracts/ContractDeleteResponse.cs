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
[JsonConverter(typeof(JsonModelConverter<ContractDeleteResponse, ContractDeleteResponseFromRaw>))]
public sealed record class ContractDeleteResponse : JsonModel
{
    /// <summary>
    /// A billing contract as reported by the connected billing provider.
    /// </summary>
    public required ContractDeleteResponseData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ContractDeleteResponseData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public ContractDeleteResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ContractDeleteResponse(ContractDeleteResponse contractDeleteResponse)
        : base(contractDeleteResponse) { }
#pragma warning restore CS8618

    public ContractDeleteResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContractDeleteResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ContractDeleteResponseFromRaw.FromRawUnchecked"/>
    public static ContractDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ContractDeleteResponse(ContractDeleteResponseData data)
        : this()
    {
        this.Data = data;
    }
}

class ContractDeleteResponseFromRaw : IFromRawJson<ContractDeleteResponse>
{
    /// <inheritdoc/>
    public ContractDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ContractDeleteResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// A billing contract as reported by the connected billing provider.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ContractDeleteResponseData, ContractDeleteResponseDataFromRaw>)
)]
public sealed record class ContractDeleteResponseData : JsonModel
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
    public required ApiEnum<string, ContractDeleteResponseDataBillingState>? BillingState
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, ContractDeleteResponseDataBillingState>
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
    public required ContractDeleteResponseDataLatestInvoice? LatestInvoice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ContractDeleteResponseDataLatestInvoice>(
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
    public required ContractDeleteResponseDataNextInvoice? NextInvoice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ContractDeleteResponseDataNextInvoice>(
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
    public required ApiEnum<string, ContractDeleteResponseDataState> State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ContractDeleteResponseDataState>>(
                "state"
            );
        }
        init { this._rawData.Set("state", value); }
    }

    /// <summary>
    /// The custom subscriptions attached to this contract (empty when none)
    /// </summary>
    public required IReadOnlyList<ContractDeleteResponseDataSubscription> Subscriptions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<ContractDeleteResponseDataSubscription>
            >("subscriptions");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ContractDeleteResponseDataSubscription>>(
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

    public ContractDeleteResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ContractDeleteResponseData(ContractDeleteResponseData contractDeleteResponseData)
        : base(contractDeleteResponseData) { }
#pragma warning restore CS8618

    public ContractDeleteResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContractDeleteResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ContractDeleteResponseDataFromRaw.FromRawUnchecked"/>
    public static ContractDeleteResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ContractDeleteResponseDataFromRaw : IFromRawJson<ContractDeleteResponseData>
{
    /// <inheritdoc/>
    public ContractDeleteResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ContractDeleteResponseData.FromRawUnchecked(rawData);
}

/// <summary>
/// The current state of the contract
/// </summary>
[JsonConverter(typeof(ContractDeleteResponseDataBillingStateConverter))]
public enum ContractDeleteResponseDataBillingState
{
    Draft,
    Active,
    Canceled,
    EndBilling,
}

sealed class ContractDeleteResponseDataBillingStateConverter
    : JsonConverter<ContractDeleteResponseDataBillingState>
{
    public override ContractDeleteResponseDataBillingState Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "DRAFT" => ContractDeleteResponseDataBillingState.Draft,
            "ACTIVE" => ContractDeleteResponseDataBillingState.Active,
            "CANCELED" => ContractDeleteResponseDataBillingState.Canceled,
            "END_BILLING" => ContractDeleteResponseDataBillingState.EndBilling,
            _ => (ContractDeleteResponseDataBillingState)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ContractDeleteResponseDataBillingState value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ContractDeleteResponseDataBillingState.Draft => "DRAFT",
                ContractDeleteResponseDataBillingState.Active => "ACTIVE",
                ContractDeleteResponseDataBillingState.Canceled => "CANCELED",
                ContractDeleteResponseDataBillingState.EndBilling => "END_BILLING",
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
        ContractDeleteResponseDataLatestInvoice,
        ContractDeleteResponseDataLatestInvoiceFromRaw
    >)
)]
public sealed record class ContractDeleteResponseDataLatestInvoice : JsonModel
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
    public required ApiEnum<string, ContractDeleteResponseDataLatestInvoiceStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ContractDeleteResponseDataLatestInvoiceStatus>
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
    public ApiEnum<string, ContractDeleteResponseDataLatestInvoiceBillingReason>? BillingReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, ContractDeleteResponseDataLatestInvoiceBillingReason>
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

    public ContractDeleteResponseDataLatestInvoice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ContractDeleteResponseDataLatestInvoice(
        ContractDeleteResponseDataLatestInvoice contractDeleteResponseDataLatestInvoice
    )
        : base(contractDeleteResponseDataLatestInvoice) { }
#pragma warning restore CS8618

    public ContractDeleteResponseDataLatestInvoice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContractDeleteResponseDataLatestInvoice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ContractDeleteResponseDataLatestInvoiceFromRaw.FromRawUnchecked"/>
    public static ContractDeleteResponseDataLatestInvoice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ContractDeleteResponseDataLatestInvoiceFromRaw
    : IFromRawJson<ContractDeleteResponseDataLatestInvoice>
{
    /// <inheritdoc/>
    public ContractDeleteResponseDataLatestInvoice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ContractDeleteResponseDataLatestInvoice.FromRawUnchecked(rawData);
}

/// <summary>
/// Invoice status
/// </summary>
[JsonConverter(typeof(ContractDeleteResponseDataLatestInvoiceStatusConverter))]
public enum ContractDeleteResponseDataLatestInvoiceStatus
{
    Open,
    Canceled,
    Paid,
}

sealed class ContractDeleteResponseDataLatestInvoiceStatusConverter
    : JsonConverter<ContractDeleteResponseDataLatestInvoiceStatus>
{
    public override ContractDeleteResponseDataLatestInvoiceStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "OPEN" => ContractDeleteResponseDataLatestInvoiceStatus.Open,
            "CANCELED" => ContractDeleteResponseDataLatestInvoiceStatus.Canceled,
            "PAID" => ContractDeleteResponseDataLatestInvoiceStatus.Paid,
            _ => (ContractDeleteResponseDataLatestInvoiceStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ContractDeleteResponseDataLatestInvoiceStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ContractDeleteResponseDataLatestInvoiceStatus.Open => "OPEN",
                ContractDeleteResponseDataLatestInvoiceStatus.Canceled => "CANCELED",
                ContractDeleteResponseDataLatestInvoiceStatus.Paid => "PAID",
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
[JsonConverter(typeof(ContractDeleteResponseDataLatestInvoiceBillingReasonConverter))]
public enum ContractDeleteResponseDataLatestInvoiceBillingReason
{
    BillingCycle,
    SubscriptionCreation,
    SubscriptionUpdate,
    Manual,
    MinimumInvoiceAmountExceeded,
    Other,
}

sealed class ContractDeleteResponseDataLatestInvoiceBillingReasonConverter
    : JsonConverter<ContractDeleteResponseDataLatestInvoiceBillingReason>
{
    public override ContractDeleteResponseDataLatestInvoiceBillingReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "BILLING_CYCLE" => ContractDeleteResponseDataLatestInvoiceBillingReason.BillingCycle,
            "SUBSCRIPTION_CREATION" =>
                ContractDeleteResponseDataLatestInvoiceBillingReason.SubscriptionCreation,
            "SUBSCRIPTION_UPDATE" =>
                ContractDeleteResponseDataLatestInvoiceBillingReason.SubscriptionUpdate,
            "MANUAL" => ContractDeleteResponseDataLatestInvoiceBillingReason.Manual,
            "MINIMUM_INVOICE_AMOUNT_EXCEEDED" =>
                ContractDeleteResponseDataLatestInvoiceBillingReason.MinimumInvoiceAmountExceeded,
            "OTHER" => ContractDeleteResponseDataLatestInvoiceBillingReason.Other,
            _ => (ContractDeleteResponseDataLatestInvoiceBillingReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ContractDeleteResponseDataLatestInvoiceBillingReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ContractDeleteResponseDataLatestInvoiceBillingReason.BillingCycle =>
                    "BILLING_CYCLE",
                ContractDeleteResponseDataLatestInvoiceBillingReason.SubscriptionCreation =>
                    "SUBSCRIPTION_CREATION",
                ContractDeleteResponseDataLatestInvoiceBillingReason.SubscriptionUpdate =>
                    "SUBSCRIPTION_UPDATE",
                ContractDeleteResponseDataLatestInvoiceBillingReason.Manual => "MANUAL",
                ContractDeleteResponseDataLatestInvoiceBillingReason.MinimumInvoiceAmountExceeded =>
                    "MINIMUM_INVOICE_AMOUNT_EXCEEDED",
                ContractDeleteResponseDataLatestInvoiceBillingReason.Other => "OTHER",
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
        ContractDeleteResponseDataNextInvoice,
        ContractDeleteResponseDataNextInvoiceFromRaw
    >)
)]
public sealed record class ContractDeleteResponseDataNextInvoice : JsonModel
{
    /// <summary>
    /// The total amount of the upcoming invoice
    /// </summary>
    public required ContractDeleteResponseDataNextInvoiceAmount Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ContractDeleteResponseDataNextInvoiceAmount>(
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

    public ContractDeleteResponseDataNextInvoice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ContractDeleteResponseDataNextInvoice(
        ContractDeleteResponseDataNextInvoice contractDeleteResponseDataNextInvoice
    )
        : base(contractDeleteResponseDataNextInvoice) { }
#pragma warning restore CS8618

    public ContractDeleteResponseDataNextInvoice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContractDeleteResponseDataNextInvoice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ContractDeleteResponseDataNextInvoiceFromRaw.FromRawUnchecked"/>
    public static ContractDeleteResponseDataNextInvoice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ContractDeleteResponseDataNextInvoiceFromRaw
    : IFromRawJson<ContractDeleteResponseDataNextInvoice>
{
    /// <inheritdoc/>
    public ContractDeleteResponseDataNextInvoice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ContractDeleteResponseDataNextInvoice.FromRawUnchecked(rawData);
}

/// <summary>
/// The total amount of the upcoming invoice
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ContractDeleteResponseDataNextInvoiceAmount,
        ContractDeleteResponseDataNextInvoiceAmountFromRaw
    >)
)]
public sealed record class ContractDeleteResponseDataNextInvoiceAmount : JsonModel
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
    public required ApiEnum<string, ContractDeleteResponseDataNextInvoiceAmountCurrency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ContractDeleteResponseDataNextInvoiceAmountCurrency>
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

    public ContractDeleteResponseDataNextInvoiceAmount() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ContractDeleteResponseDataNextInvoiceAmount(
        ContractDeleteResponseDataNextInvoiceAmount contractDeleteResponseDataNextInvoiceAmount
    )
        : base(contractDeleteResponseDataNextInvoiceAmount) { }
#pragma warning restore CS8618

    public ContractDeleteResponseDataNextInvoiceAmount(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContractDeleteResponseDataNextInvoiceAmount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ContractDeleteResponseDataNextInvoiceAmountFromRaw.FromRawUnchecked"/>
    public static ContractDeleteResponseDataNextInvoiceAmount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ContractDeleteResponseDataNextInvoiceAmountFromRaw
    : IFromRawJson<ContractDeleteResponseDataNextInvoiceAmount>
{
    /// <inheritdoc/>
    public ContractDeleteResponseDataNextInvoiceAmount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ContractDeleteResponseDataNextInvoiceAmount.FromRawUnchecked(rawData);
}

/// <summary>
/// ISO 4217 currency code
/// </summary>
[JsonConverter(typeof(ContractDeleteResponseDataNextInvoiceAmountCurrencyConverter))]
public enum ContractDeleteResponseDataNextInvoiceAmountCurrency
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

sealed class ContractDeleteResponseDataNextInvoiceAmountCurrencyConverter
    : JsonConverter<ContractDeleteResponseDataNextInvoiceAmountCurrency>
{
    public override ContractDeleteResponseDataNextInvoiceAmountCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Usd,
            "aed" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Aed,
            "all" => ContractDeleteResponseDataNextInvoiceAmountCurrency.All,
            "amd" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Amd,
            "ang" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Ang,
            "aud" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Aud,
            "awg" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Awg,
            "azn" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Azn,
            "bam" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Bam,
            "bbd" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Bbd,
            "bdt" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Bdt,
            "bgn" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Bgn,
            "bif" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Bif,
            "bmd" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Bmd,
            "bnd" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Bnd,
            "bsd" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Bsd,
            "bwp" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Bwp,
            "byn" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Byn,
            "bzd" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Bzd,
            "brl" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Brl,
            "cad" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Cad,
            "cdf" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Cdf,
            "chf" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Chf,
            "cny" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Cny,
            "czk" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Czk,
            "dkk" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Dkk,
            "dop" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Dop,
            "dzd" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Dzd,
            "egp" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Egp,
            "etb" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Etb,
            "eur" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Eur,
            "fjd" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Fjd,
            "gbp" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Gbp,
            "gel" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Gel,
            "gip" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Gip,
            "gmd" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Gmd,
            "gyd" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Gyd,
            "hkd" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Hkd,
            "hrk" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Hrk,
            "htg" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Htg,
            "idr" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Idr,
            "ils" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Ils,
            "inr" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Inr,
            "isk" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Isk,
            "jmd" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Jmd,
            "jpy" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Jpy,
            "kes" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Kes,
            "kgs" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Kgs,
            "khr" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Khr,
            "kmf" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Kmf,
            "krw" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Krw,
            "kyd" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Kyd,
            "kzt" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Kzt,
            "lbp" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Lbp,
            "lkr" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Lkr,
            "lrd" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Lrd,
            "lsl" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Lsl,
            "mad" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Mad,
            "mdl" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Mdl,
            "mga" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Mga,
            "mkd" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Mkd,
            "mmk" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Mmk,
            "mnt" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Mnt,
            "mop" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Mop,
            "mro" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Mro,
            "mvr" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Mvr,
            "mwk" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Mwk,
            "mxn" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Mxn,
            "myr" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Myr,
            "mzn" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Mzn,
            "nad" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Nad,
            "ngn" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Ngn,
            "nok" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Nok,
            "npr" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Npr,
            "nzd" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Nzd,
            "pgk" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Pgk,
            "php" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Php,
            "pkr" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Pkr,
            "pln" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Pln,
            "qar" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Qar,
            "ron" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Ron,
            "rsd" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Rsd,
            "rub" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Rub,
            "rwf" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Rwf,
            "sar" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Sar,
            "sbd" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Sbd,
            "scr" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Scr,
            "sek" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Sek,
            "sgd" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Sgd,
            "sle" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Sle,
            "sll" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Sll,
            "sos" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Sos,
            "szl" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Szl,
            "thb" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Thb,
            "tjs" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Tjs,
            "top" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Top,
            "try" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Try,
            "ttd" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Ttd,
            "tzs" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Tzs,
            "uah" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Uah,
            "uzs" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Uzs,
            "vnd" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Vnd,
            "vuv" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Vuv,
            "wst" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Wst,
            "xaf" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Xaf,
            "xcd" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Xcd,
            "yer" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Yer,
            "zar" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Zar,
            "zmw" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Zmw,
            "clp" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Clp,
            "djf" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Djf,
            "gnf" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Gnf,
            "ugx" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Ugx,
            "pyg" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Pyg,
            "xof" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Xof,
            "xpf" => ContractDeleteResponseDataNextInvoiceAmountCurrency.Xpf,
            _ => (ContractDeleteResponseDataNextInvoiceAmountCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ContractDeleteResponseDataNextInvoiceAmountCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Usd => "usd",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Aed => "aed",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.All => "all",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Amd => "amd",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Ang => "ang",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Aud => "aud",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Awg => "awg",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Azn => "azn",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Bam => "bam",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Bbd => "bbd",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Bdt => "bdt",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Bgn => "bgn",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Bif => "bif",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Bmd => "bmd",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Bnd => "bnd",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Bsd => "bsd",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Bwp => "bwp",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Byn => "byn",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Bzd => "bzd",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Brl => "brl",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Cad => "cad",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Cdf => "cdf",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Chf => "chf",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Cny => "cny",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Czk => "czk",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Dkk => "dkk",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Dop => "dop",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Dzd => "dzd",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Egp => "egp",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Etb => "etb",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Eur => "eur",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Fjd => "fjd",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Gbp => "gbp",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Gel => "gel",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Gip => "gip",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Gmd => "gmd",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Gyd => "gyd",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Hkd => "hkd",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Hrk => "hrk",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Htg => "htg",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Idr => "idr",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Ils => "ils",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Inr => "inr",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Isk => "isk",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Jmd => "jmd",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Jpy => "jpy",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Kes => "kes",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Kgs => "kgs",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Khr => "khr",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Kmf => "kmf",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Krw => "krw",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Kyd => "kyd",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Kzt => "kzt",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Lbp => "lbp",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Lkr => "lkr",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Lrd => "lrd",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Lsl => "lsl",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Mad => "mad",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Mdl => "mdl",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Mga => "mga",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Mkd => "mkd",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Mmk => "mmk",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Mnt => "mnt",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Mop => "mop",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Mro => "mro",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Mvr => "mvr",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Mwk => "mwk",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Mxn => "mxn",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Myr => "myr",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Mzn => "mzn",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Nad => "nad",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Ngn => "ngn",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Nok => "nok",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Npr => "npr",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Nzd => "nzd",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Pgk => "pgk",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Php => "php",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Pkr => "pkr",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Pln => "pln",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Qar => "qar",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Ron => "ron",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Rsd => "rsd",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Rub => "rub",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Rwf => "rwf",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Sar => "sar",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Sbd => "sbd",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Scr => "scr",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Sek => "sek",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Sgd => "sgd",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Sle => "sle",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Sll => "sll",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Sos => "sos",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Szl => "szl",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Thb => "thb",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Tjs => "tjs",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Top => "top",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Try => "try",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Ttd => "ttd",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Tzs => "tzs",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Uah => "uah",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Uzs => "uzs",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Vnd => "vnd",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Vuv => "vuv",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Wst => "wst",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Xaf => "xaf",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Xcd => "xcd",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Yer => "yer",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Zar => "zar",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Zmw => "zmw",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Clp => "clp",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Djf => "djf",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Gnf => "gnf",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Ugx => "ugx",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Pyg => "pyg",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Xof => "xof",
                ContractDeleteResponseDataNextInvoiceAmountCurrency.Xpf => "xpf",
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
[JsonConverter(typeof(ContractDeleteResponseDataStateConverter))]
public enum ContractDeleteResponseDataState
{
    Draft,
    Active,
    Canceled,
    EndBilling,
}

sealed class ContractDeleteResponseDataStateConverter
    : JsonConverter<ContractDeleteResponseDataState>
{
    public override ContractDeleteResponseDataState Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "DRAFT" => ContractDeleteResponseDataState.Draft,
            "ACTIVE" => ContractDeleteResponseDataState.Active,
            "CANCELED" => ContractDeleteResponseDataState.Canceled,
            "END_BILLING" => ContractDeleteResponseDataState.EndBilling,
            _ => (ContractDeleteResponseDataState)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ContractDeleteResponseDataState value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ContractDeleteResponseDataState.Draft => "DRAFT",
                ContractDeleteResponseDataState.Active => "ACTIVE",
                ContractDeleteResponseDataState.Canceled => "CANCELED",
                ContractDeleteResponseDataState.EndBilling => "END_BILLING",
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
        ContractDeleteResponseDataSubscription,
        ContractDeleteResponseDataSubscriptionFromRaw
    >)
)]
public sealed record class ContractDeleteResponseDataSubscription : JsonModel
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

    public ContractDeleteResponseDataSubscription() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ContractDeleteResponseDataSubscription(
        ContractDeleteResponseDataSubscription contractDeleteResponseDataSubscription
    )
        : base(contractDeleteResponseDataSubscription) { }
#pragma warning restore CS8618

    public ContractDeleteResponseDataSubscription(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContractDeleteResponseDataSubscription(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ContractDeleteResponseDataSubscriptionFromRaw.FromRawUnchecked"/>
    public static ContractDeleteResponseDataSubscription FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ContractDeleteResponseDataSubscriptionFromRaw
    : IFromRawJson<ContractDeleteResponseDataSubscription>
{
    /// <inheritdoc/>
    public ContractDeleteResponseDataSubscription FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ContractDeleteResponseDataSubscription.FromRawUnchecked(rawData);
}
