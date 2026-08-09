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
/// A customer invoice as reported by the connected billing provider.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<CustomerListInvoicesResponse, CustomerListInvoicesResponseFromRaw>)
)]
public sealed record class CustomerListInvoicesResponse : JsonModel
{
    /// <summary>
    /// External ID of the contract the invoice belongs to: your contract ref when
    /// mapped, otherwise the Received contract ID
    /// </summary>
    public required string? ContractExternalID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("contractExternalId");
        }
        init { this._rawData.Set("contractExternalId", value); }
    }

    /// <summary>
    /// The ISO-4217 currency code of the invoice
    /// </summary>
    public required string? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// External ID of the customer the invoice belongs to: your customer ref when
    /// mapped, otherwise the Received customer ID
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
    /// The total discount amount
    /// </summary>
    public required double? Discount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("discount");
        }
        init { this._rawData.Set("discount", value); }
    }

    /// <summary>
    /// The date payment is due
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
    /// External ID for the invoice: the mapped external ID when one exists, otherwise
    /// the invoice ID
    /// </summary>
    public required string? InvoiceExternalID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("invoiceExternalId");
        }
        init { this._rawData.Set("invoiceExternalId", value); }
    }

    /// <summary>
    /// The billing provider (Received) invoice ID
    /// </summary>
    public required string InvoiceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("invoiceId");
        }
        init { this._rawData.Set("invoiceId", value); }
    }

    /// <summary>
    /// The invoice document number (or draft number while the invoice is unissued)
    /// </summary>
    public required string? InvoiceNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("invoiceNumber");
        }
        init { this._rawData.Set("invoiceNumber", value); }
    }

    /// <summary>
    /// The date the invoice was issued
    /// </summary>
    public required System::DateTimeOffset? IssueDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("issueDate");
        }
        init { this._rawData.Set("issueDate", value); }
    }

    /// <summary>
    /// The invoice line items
    /// </summary>
    public required IReadOnlyList<LineItem> LineItems
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<LineItem>>("lineItems");
        }
        init
        {
            this._rawData.Set<ImmutableArray<LineItem>>(
                "lineItems",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The date the invoice was reconciled as paid; present once reconciled
    /// </summary>
    public required System::DateTimeOffset? PaidDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("paidDate");
        }
        init { this._rawData.Set("paidDate", value); }
    }

    /// <summary>
    /// The invoice status (open, paid, or canceled)
    /// </summary>
    public required ApiEnum<string, CustomerListInvoicesResponseState> State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, CustomerListInvoicesResponseState>
            >("state");
        }
        init { this._rawData.Set("state", value); }
    }

    /// <summary>
    /// The pre-tax subtotal
    /// </summary>
    public required double? Subtotal
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("subtotal");
        }
        init { this._rawData.Set("subtotal", value); }
    }

    /// <summary>
    /// The total tax amount
    /// </summary>
    public required double? Tax
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("tax");
        }
        init { this._rawData.Set("tax", value); }
    }

    /// <summary>
    /// The total amount due
    /// </summary>
    public required double? Total
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
        _ = this.ContractExternalID;
        _ = this.Currency;
        _ = this.CustomerExternalID;
        _ = this.Discount;
        _ = this.DueDate;
        _ = this.InvoiceExternalID;
        _ = this.InvoiceID;
        _ = this.InvoiceNumber;
        _ = this.IssueDate;
        foreach (var item in this.LineItems)
        {
            item.Validate();
        }
        _ = this.PaidDate;
        this.State.Validate();
        _ = this.Subtotal;
        _ = this.Tax;
        _ = this.Total;
    }

    public CustomerListInvoicesResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerListInvoicesResponse(CustomerListInvoicesResponse customerListInvoicesResponse)
        : base(customerListInvoicesResponse) { }
#pragma warning restore CS8618

    public CustomerListInvoicesResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerListInvoicesResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerListInvoicesResponseFromRaw.FromRawUnchecked"/>
    public static CustomerListInvoicesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerListInvoicesResponseFromRaw : IFromRawJson<CustomerListInvoicesResponse>
{
    /// <inheritdoc/>
    public CustomerListInvoicesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerListInvoicesResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// A single line item on an invoice.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<LineItem, LineItemFromRaw>))]
public sealed record class LineItem : JsonModel
{
    /// <summary>
    /// Total amount for this line (unit price × quantity)
    /// </summary>
    public required double? Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    /// <summary>
    /// Human-readable description of the line item
    /// </summary>
    public required string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// External ID of the product this line item relates to, when one is mapped
    /// </summary>
    public required string? ProductExternalID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("productExternalId");
        }
        init { this._rawData.Set("productExternalId", value); }
    }

    /// <summary>
    /// Quantity billed on this line
    /// </summary>
    public required double? Quantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("quantity");
        }
        init { this._rawData.Set("quantity", value); }
    }

    /// <summary>
    /// Price per unit for this line
    /// </summary>
    public required double? UnitPrice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("unitPrice");
        }
        init { this._rawData.Set("unitPrice", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.Description;
        _ = this.ProductExternalID;
        _ = this.Quantity;
        _ = this.UnitPrice;
    }

    public LineItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LineItem(LineItem lineItem)
        : base(lineItem) { }
#pragma warning restore CS8618

    public LineItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LineItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LineItemFromRaw.FromRawUnchecked"/>
    public static LineItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LineItemFromRaw : IFromRawJson<LineItem>
{
    /// <inheritdoc/>
    public LineItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        LineItem.FromRawUnchecked(rawData);
}

/// <summary>
/// The invoice status (open, paid, or canceled)
/// </summary>
[JsonConverter(typeof(CustomerListInvoicesResponseStateConverter))]
public enum CustomerListInvoicesResponseState
{
    Open,
    Canceled,
    Paid,
}

sealed class CustomerListInvoicesResponseStateConverter
    : JsonConverter<CustomerListInvoicesResponseState>
{
    public override CustomerListInvoicesResponseState Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "OPEN" => CustomerListInvoicesResponseState.Open,
            "CANCELED" => CustomerListInvoicesResponseState.Canceled,
            "PAID" => CustomerListInvoicesResponseState.Paid,
            _ => (CustomerListInvoicesResponseState)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CustomerListInvoicesResponseState value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CustomerListInvoicesResponseState.Open => "OPEN",
                CustomerListInvoicesResponseState.Canceled => "CANCELED",
                CustomerListInvoicesResponseState.Paid => "PAID",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
