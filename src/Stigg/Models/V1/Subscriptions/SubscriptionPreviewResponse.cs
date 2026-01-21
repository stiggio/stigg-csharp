using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Core;

namespace Stigg.Models.V1.Subscriptions;

[JsonConverter(
    typeof(JsonModelConverter<SubscriptionPreviewResponse, SubscriptionPreviewResponseFromRaw>)
)]
public sealed record class SubscriptionPreviewResponse : JsonModel
{
    public required SubscriptionPreviewResponseData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<SubscriptionPreviewResponseData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public SubscriptionPreviewResponse() { }

    public SubscriptionPreviewResponse(SubscriptionPreviewResponse subscriptionPreviewResponse)
        : base(subscriptionPreviewResponse) { }

    public SubscriptionPreviewResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionPreviewResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionPreviewResponseFromRaw.FromRawUnchecked"/>
    public static SubscriptionPreviewResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SubscriptionPreviewResponse(SubscriptionPreviewResponseData data)
        : this()
    {
        this.Data = data;
    }
}

class SubscriptionPreviewResponseFromRaw : IFromRawJson<SubscriptionPreviewResponse>
{
    /// <inheritdoc/>
    public SubscriptionPreviewResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionPreviewResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionPreviewResponseData,
        SubscriptionPreviewResponseDataFromRaw
    >)
)]
public sealed record class SubscriptionPreviewResponseData : JsonModel
{
    public required ImmediateInvoice ImmediateInvoice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ImmediateInvoice>("immediateInvoice");
        }
        init { this._rawData.Set("immediateInvoice", value); }
    }

    public SubscriptionPreviewResponseDataBillingPeriodRange? BillingPeriodRange
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SubscriptionPreviewResponseDataBillingPeriodRange>(
                "billingPeriodRange"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("billingPeriodRange", value);
        }
    }

    public IReadOnlyList<FreeItem>? FreeItems
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<FreeItem>>("freeItems");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<FreeItem>?>(
                "freeItems",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public bool? HasScheduledUpdates
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("hasScheduledUpdates");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("hasScheduledUpdates", value);
        }
    }

    public bool? IsPlanDowngrade
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isPlanDowngrade");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isPlanDowngrade", value);
        }
    }

    public RecurringInvoice? RecurringInvoice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RecurringInvoice>("recurringInvoice");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("recurringInvoice", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ImmediateInvoice.Validate();
        this.BillingPeriodRange?.Validate();
        foreach (var item in this.FreeItems ?? [])
        {
            item.Validate();
        }
        _ = this.HasScheduledUpdates;
        _ = this.IsPlanDowngrade;
        this.RecurringInvoice?.Validate();
    }

    public SubscriptionPreviewResponseData() { }

    public SubscriptionPreviewResponseData(
        SubscriptionPreviewResponseData subscriptionPreviewResponseData
    )
        : base(subscriptionPreviewResponseData) { }

    public SubscriptionPreviewResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionPreviewResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionPreviewResponseDataFromRaw.FromRawUnchecked"/>
    public static SubscriptionPreviewResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SubscriptionPreviewResponseData(ImmediateInvoice immediateInvoice)
        : this()
    {
        this.ImmediateInvoice = immediateInvoice;
    }
}

class SubscriptionPreviewResponseDataFromRaw : IFromRawJson<SubscriptionPreviewResponseData>
{
    /// <inheritdoc/>
    public SubscriptionPreviewResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionPreviewResponseData.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<ImmediateInvoice, ImmediateInvoiceFromRaw>))]
public sealed record class ImmediateInvoice : JsonModel
{
    public required double SubTotal
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("subTotal");
        }
        init { this._rawData.Set("subTotal", value); }
    }

    public required double Total
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("total");
        }
        init { this._rawData.Set("total", value); }
    }

    public BillingPeriodRange? BillingPeriodRange
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BillingPeriodRange>("billingPeriodRange");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("billingPeriodRange", value);
        }
    }

    public string? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    public double? Discount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("discount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("discount", value);
        }
    }

    public DiscountDetails? DiscountDetails
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<DiscountDetails>("discountDetails");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("discountDetails", value);
        }
    }

    public IReadOnlyList<ImmediateInvoiceDiscount>? Discounts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ImmediateInvoiceDiscount>>(
                "discounts"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ImmediateInvoiceDiscount>?>(
                "discounts",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyList<Line>? Lines
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Line>>("lines");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Line>?>(
                "lines",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public double? Tax
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("tax");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tax", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.SubTotal;
        _ = this.Total;
        this.BillingPeriodRange?.Validate();
        _ = this.Currency;
        _ = this.Discount;
        this.DiscountDetails?.Validate();
        foreach (var item in this.Discounts ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.Lines ?? [])
        {
            item.Validate();
        }
        _ = this.Tax;
    }

    public ImmediateInvoice() { }

    public ImmediateInvoice(ImmediateInvoice immediateInvoice)
        : base(immediateInvoice) { }

    public ImmediateInvoice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ImmediateInvoice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ImmediateInvoiceFromRaw.FromRawUnchecked"/>
    public static ImmediateInvoice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ImmediateInvoiceFromRaw : IFromRawJson<ImmediateInvoice>
{
    /// <inheritdoc/>
    public ImmediateInvoice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ImmediateInvoice.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<BillingPeriodRange, BillingPeriodRangeFromRaw>))]
public sealed record class BillingPeriodRange : JsonModel
{
    /// <summary>
    /// Billing period end date
    /// </summary>
    public required DateTimeOffset End
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("end");
        }
        init { this._rawData.Set("end", value); }
    }

    /// <summary>
    /// Billing period start date
    /// </summary>
    public required DateTimeOffset Start
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("start");
        }
        init { this._rawData.Set("start", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.End;
        _ = this.Start;
    }

    public BillingPeriodRange() { }

    public BillingPeriodRange(BillingPeriodRange billingPeriodRange)
        : base(billingPeriodRange) { }

    public BillingPeriodRange(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BillingPeriodRange(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BillingPeriodRangeFromRaw.FromRawUnchecked"/>
    public static BillingPeriodRange FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BillingPeriodRangeFromRaw : IFromRawJson<BillingPeriodRange>
{
    /// <inheritdoc/>
    public BillingPeriodRange FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BillingPeriodRange.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<DiscountDetails, DiscountDetailsFromRaw>))]
public sealed record class DiscountDetails : JsonModel
{
    public string? Code
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("code");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("code", value);
        }
    }

    public double? FixedAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("fixedAmount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("fixedAmount", value);
        }
    }

    public double? Percentage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("percentage");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("percentage", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Code;
        _ = this.FixedAmount;
        _ = this.Percentage;
    }

    public DiscountDetails() { }

    public DiscountDetails(DiscountDetails discountDetails)
        : base(discountDetails) { }

    public DiscountDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DiscountDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DiscountDetailsFromRaw.FromRawUnchecked"/>
    public static DiscountDetails FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DiscountDetailsFromRaw : IFromRawJson<DiscountDetails>
{
    /// <inheritdoc/>
    public DiscountDetails FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DiscountDetails.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<ImmediateInvoiceDiscount, ImmediateInvoiceDiscountFromRaw>)
)]
public sealed record class ImmediateInvoiceDiscount : JsonModel
{
    public required double Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    public required string Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    public required string Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.Currency;
        _ = this.Description;
    }

    public ImmediateInvoiceDiscount() { }

    public ImmediateInvoiceDiscount(ImmediateInvoiceDiscount immediateInvoiceDiscount)
        : base(immediateInvoiceDiscount) { }

    public ImmediateInvoiceDiscount(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ImmediateInvoiceDiscount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ImmediateInvoiceDiscountFromRaw.FromRawUnchecked"/>
    public static ImmediateInvoiceDiscount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ImmediateInvoiceDiscountFromRaw : IFromRawJson<ImmediateInvoiceDiscount>
{
    /// <inheritdoc/>
    public ImmediateInvoiceDiscount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ImmediateInvoiceDiscount.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Line, LineFromRaw>))]
public sealed record class Line : JsonModel
{
    public required string Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    public required string Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    public required double SubTotal
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("subTotal");
        }
        init { this._rawData.Set("subTotal", value); }
    }

    public required double UnitPrice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("unitPrice");
        }
        init { this._rawData.Set("unitPrice", value); }
    }

    public double? Quantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("quantity");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("quantity", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Currency;
        _ = this.Description;
        _ = this.SubTotal;
        _ = this.UnitPrice;
        _ = this.Quantity;
    }

    public Line() { }

    public Line(Line line)
        : base(line) { }

    public Line(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Line(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LineFromRaw.FromRawUnchecked"/>
    public static Line FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LineFromRaw : IFromRawJson<Line>
{
    /// <inheritdoc/>
    public Line FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Line.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionPreviewResponseDataBillingPeriodRange,
        SubscriptionPreviewResponseDataBillingPeriodRangeFromRaw
    >)
)]
public sealed record class SubscriptionPreviewResponseDataBillingPeriodRange : JsonModel
{
    /// <summary>
    /// Billing period end date
    /// </summary>
    public DateTimeOffset? End
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("end");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("end", value);
        }
    }

    /// <summary>
    /// Billing period start date
    /// </summary>
    public DateTimeOffset? Start
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("start");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("start", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.End;
        _ = this.Start;
    }

    public SubscriptionPreviewResponseDataBillingPeriodRange() { }

    public SubscriptionPreviewResponseDataBillingPeriodRange(
        SubscriptionPreviewResponseDataBillingPeriodRange subscriptionPreviewResponseDataBillingPeriodRange
    )
        : base(subscriptionPreviewResponseDataBillingPeriodRange) { }

    public SubscriptionPreviewResponseDataBillingPeriodRange(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionPreviewResponseDataBillingPeriodRange(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionPreviewResponseDataBillingPeriodRangeFromRaw.FromRawUnchecked"/>
    public static SubscriptionPreviewResponseDataBillingPeriodRange FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionPreviewResponseDataBillingPeriodRangeFromRaw
    : IFromRawJson<SubscriptionPreviewResponseDataBillingPeriodRange>
{
    /// <inheritdoc/>
    public SubscriptionPreviewResponseDataBillingPeriodRange FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionPreviewResponseDataBillingPeriodRange.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<FreeItem, FreeItemFromRaw>))]
public sealed record class FreeItem : JsonModel
{
    public required string AddonID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("addonId");
        }
        init { this._rawData.Set("addonId", value); }
    }

    public required double Quantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("quantity");
        }
        init { this._rawData.Set("quantity", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AddonID;
        _ = this.Quantity;
    }

    public FreeItem() { }

    public FreeItem(FreeItem freeItem)
        : base(freeItem) { }

    public FreeItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FreeItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FreeItemFromRaw.FromRawUnchecked"/>
    public static FreeItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FreeItemFromRaw : IFromRawJson<FreeItem>
{
    /// <inheritdoc/>
    public FreeItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FreeItem.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<RecurringInvoice, RecurringInvoiceFromRaw>))]
public sealed record class RecurringInvoice : JsonModel
{
    public required double SubTotal
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("subTotal");
        }
        init { this._rawData.Set("subTotal", value); }
    }

    public required double Total
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("total");
        }
        init { this._rawData.Set("total", value); }
    }

    public RecurringInvoiceBillingPeriodRange? BillingPeriodRange
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RecurringInvoiceBillingPeriodRange>(
                "billingPeriodRange"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("billingPeriodRange", value);
        }
    }

    public string? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    public double? Discount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("discount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("discount", value);
        }
    }

    public RecurringInvoiceDiscountDetails? DiscountDetails
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RecurringInvoiceDiscountDetails>(
                "discountDetails"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("discountDetails", value);
        }
    }

    public IReadOnlyList<RecurringInvoiceDiscount>? Discounts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<RecurringInvoiceDiscount>>(
                "discounts"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<RecurringInvoiceDiscount>?>(
                "discounts",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyList<RecurringInvoiceLine>? Lines
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<RecurringInvoiceLine>>("lines");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<RecurringInvoiceLine>?>(
                "lines",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public double? Tax
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("tax");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tax", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.SubTotal;
        _ = this.Total;
        this.BillingPeriodRange?.Validate();
        _ = this.Currency;
        _ = this.Discount;
        this.DiscountDetails?.Validate();
        foreach (var item in this.Discounts ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.Lines ?? [])
        {
            item.Validate();
        }
        _ = this.Tax;
    }

    public RecurringInvoice() { }

    public RecurringInvoice(RecurringInvoice recurringInvoice)
        : base(recurringInvoice) { }

    public RecurringInvoice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RecurringInvoice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RecurringInvoiceFromRaw.FromRawUnchecked"/>
    public static RecurringInvoice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RecurringInvoiceFromRaw : IFromRawJson<RecurringInvoice>
{
    /// <inheritdoc/>
    public RecurringInvoice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        RecurringInvoice.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        RecurringInvoiceBillingPeriodRange,
        RecurringInvoiceBillingPeriodRangeFromRaw
    >)
)]
public sealed record class RecurringInvoiceBillingPeriodRange : JsonModel
{
    /// <summary>
    /// Billing period end date
    /// </summary>
    public required DateTimeOffset End
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("end");
        }
        init { this._rawData.Set("end", value); }
    }

    /// <summary>
    /// Billing period start date
    /// </summary>
    public required DateTimeOffset Start
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("start");
        }
        init { this._rawData.Set("start", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.End;
        _ = this.Start;
    }

    public RecurringInvoiceBillingPeriodRange() { }

    public RecurringInvoiceBillingPeriodRange(
        RecurringInvoiceBillingPeriodRange recurringInvoiceBillingPeriodRange
    )
        : base(recurringInvoiceBillingPeriodRange) { }

    public RecurringInvoiceBillingPeriodRange(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RecurringInvoiceBillingPeriodRange(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RecurringInvoiceBillingPeriodRangeFromRaw.FromRawUnchecked"/>
    public static RecurringInvoiceBillingPeriodRange FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RecurringInvoiceBillingPeriodRangeFromRaw : IFromRawJson<RecurringInvoiceBillingPeriodRange>
{
    /// <inheritdoc/>
    public RecurringInvoiceBillingPeriodRange FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RecurringInvoiceBillingPeriodRange.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        RecurringInvoiceDiscountDetails,
        RecurringInvoiceDiscountDetailsFromRaw
    >)
)]
public sealed record class RecurringInvoiceDiscountDetails : JsonModel
{
    public string? Code
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("code");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("code", value);
        }
    }

    public double? FixedAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("fixedAmount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("fixedAmount", value);
        }
    }

    public double? Percentage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("percentage");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("percentage", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Code;
        _ = this.FixedAmount;
        _ = this.Percentage;
    }

    public RecurringInvoiceDiscountDetails() { }

    public RecurringInvoiceDiscountDetails(
        RecurringInvoiceDiscountDetails recurringInvoiceDiscountDetails
    )
        : base(recurringInvoiceDiscountDetails) { }

    public RecurringInvoiceDiscountDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RecurringInvoiceDiscountDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RecurringInvoiceDiscountDetailsFromRaw.FromRawUnchecked"/>
    public static RecurringInvoiceDiscountDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RecurringInvoiceDiscountDetailsFromRaw : IFromRawJson<RecurringInvoiceDiscountDetails>
{
    /// <inheritdoc/>
    public RecurringInvoiceDiscountDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RecurringInvoiceDiscountDetails.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<RecurringInvoiceDiscount, RecurringInvoiceDiscountFromRaw>)
)]
public sealed record class RecurringInvoiceDiscount : JsonModel
{
    public required double Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    public required string Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    public required string Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.Currency;
        _ = this.Description;
    }

    public RecurringInvoiceDiscount() { }

    public RecurringInvoiceDiscount(RecurringInvoiceDiscount recurringInvoiceDiscount)
        : base(recurringInvoiceDiscount) { }

    public RecurringInvoiceDiscount(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RecurringInvoiceDiscount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RecurringInvoiceDiscountFromRaw.FromRawUnchecked"/>
    public static RecurringInvoiceDiscount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RecurringInvoiceDiscountFromRaw : IFromRawJson<RecurringInvoiceDiscount>
{
    /// <inheritdoc/>
    public RecurringInvoiceDiscount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RecurringInvoiceDiscount.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<RecurringInvoiceLine, RecurringInvoiceLineFromRaw>))]
public sealed record class RecurringInvoiceLine : JsonModel
{
    public required string Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    public required string Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    public required double SubTotal
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("subTotal");
        }
        init { this._rawData.Set("subTotal", value); }
    }

    public required double UnitPrice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("unitPrice");
        }
        init { this._rawData.Set("unitPrice", value); }
    }

    public double? Quantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("quantity");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("quantity", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Currency;
        _ = this.Description;
        _ = this.SubTotal;
        _ = this.UnitPrice;
        _ = this.Quantity;
    }

    public RecurringInvoiceLine() { }

    public RecurringInvoiceLine(RecurringInvoiceLine recurringInvoiceLine)
        : base(recurringInvoiceLine) { }

    public RecurringInvoiceLine(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RecurringInvoiceLine(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RecurringInvoiceLineFromRaw.FromRawUnchecked"/>
    public static RecurringInvoiceLine FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RecurringInvoiceLineFromRaw : IFromRawJson<RecurringInvoiceLine>
{
    /// <inheritdoc/>
    public RecurringInvoiceLine FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RecurringInvoiceLine.FromRawUnchecked(rawData);
}
