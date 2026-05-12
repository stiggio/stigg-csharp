using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;

namespace Stigg.Client.Models.V1.Credits.Grants;

/// <summary>
/// Credit grant object representing allocated credits for a customer
/// </summary>
[JsonConverter(typeof(JsonModelConverter<GrantListResponse, GrantListResponseFromRaw>))]
public sealed record class GrantListResponse : JsonModel
{
    /// <summary>
    /// The unique readable identifier of the credit grant
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
    /// The total credits granted
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
    /// An optional comment on the credit grant
    /// </summary>
    public required string? Comment
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("comment");
        }
        init { this._rawData.Set("comment", value); }
    }

    /// <summary>
    /// The total credits consumed from this grant
    /// </summary>
    public required double ConsumedAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("consumedAmount");
        }
        init { this._rawData.Set("consumedAmount", value); }
    }

    /// <summary>
    /// The monetary cost of the credit grant
    /// </summary>
    public required GrantListResponseCost Cost
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<GrantListResponseCost>("cost");
        }
        init { this._rawData.Set("cost", value); }
    }

    /// <summary>
    /// Timestamp of when the record was created
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("createdAt");
        }
        init { this._rawData.Set("createdAt", value); }
    }

    /// <summary>
    /// The currency identifier for this grant
    /// </summary>
    public required string CurrencyID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("currencyId");
        }
        init { this._rawData.Set("currencyId", value); }
    }

    /// <summary>
    /// The customer ID this grant belongs to
    /// </summary>
    public required string CustomerID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("customerId");
        }
        init { this._rawData.Set("customerId", value); }
    }

    /// <summary>
    /// The display name of the credit grant
    /// </summary>
    public required string DisplayName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("displayName");
        }
        init { this._rawData.Set("displayName", value); }
    }

    /// <summary>
    /// The date when the credit grant becomes effective
    /// </summary>
    public required DateTimeOffset EffectiveAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("effectiveAt");
        }
        init { this._rawData.Set("effectiveAt", value); }
    }

    /// <summary>
    /// The date when the credit grant expires
    /// </summary>
    public required DateTimeOffset? ExpireAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("expireAt");
        }
        init { this._rawData.Set("expireAt", value); }
    }

    /// <summary>
    /// The type of credit grant (PAID, PROMOTIONAL, RECURRING)
    /// </summary>
    public required ApiEnum<string, GrantListResponseGrantType> GrantType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, GrantListResponseGrantType>>(
                "grantType"
            );
        }
        init { this._rawData.Set("grantType", value); }
    }

    /// <summary>
    /// The billing invoice ID associated with this grant
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
    /// The latest invoice details for this grant
    /// </summary>
    public required GrantListResponseLatestInvoice? LatestInvoice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<GrantListResponseLatestInvoice>("latestInvoice");
        }
        init { this._rawData.Set("latestInvoice", value); }
    }

    /// <summary>
    /// Metadata associated with the entity
    /// </summary>
    public required IReadOnlyDictionary<string, string> Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string>>(
                "metadata",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// The payment collection status
    /// </summary>
    public required ApiEnum<string, GrantListResponsePaymentCollection> PaymentCollection
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, GrantListResponsePaymentCollection>
            >("paymentCollection");
        }
        init { this._rawData.Set("paymentCollection", value); }
    }

    /// <summary>
    /// The priority of the credit grant (lower number = higher priority)
    /// </summary>
    public required double Priority
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("priority");
        }
        init { this._rawData.Set("priority", value); }
    }

    /// <summary>
    /// The resource ID this grant is scoped to
    /// </summary>
    public required string? ResourceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("resourceId");
        }
        init { this._rawData.Set("resourceId", value); }
    }

    /// <summary>
    /// The source type of the grant (PRICE, PLAN_ENTITLEMENT, ADDON_ENTITLEMENT)
    /// </summary>
    public required ApiEnum<string, GrantListResponseSourceType>? SourceType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, GrantListResponseSourceType>>(
                "sourceType"
            );
        }
        init { this._rawData.Set("sourceType", value); }
    }

    /// <summary>
    /// The effective status of the credit grant
    /// </summary>
    public required ApiEnum<string, GrantListResponseStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, GrantListResponseStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Timestamp of when the record was last updated
    /// </summary>
    public required DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("updatedAt");
        }
        init { this._rawData.Set("updatedAt", value); }
    }

    /// <summary>
    /// The date when the credit grant was voided
    /// </summary>
    public required DateTimeOffset? VoidedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("voidedAt");
        }
        init { this._rawData.Set("voidedAt", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Amount;
        _ = this.Comment;
        _ = this.ConsumedAmount;
        this.Cost.Validate();
        _ = this.CreatedAt;
        _ = this.CurrencyID;
        _ = this.CustomerID;
        _ = this.DisplayName;
        _ = this.EffectiveAt;
        _ = this.ExpireAt;
        this.GrantType.Validate();
        _ = this.InvoiceID;
        this.LatestInvoice?.Validate();
        _ = this.Metadata;
        this.PaymentCollection.Validate();
        _ = this.Priority;
        _ = this.ResourceID;
        this.SourceType?.Validate();
        this.Status.Validate();
        _ = this.UpdatedAt;
        _ = this.VoidedAt;
    }

    public GrantListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GrantListResponse(GrantListResponse grantListResponse)
        : base(grantListResponse) { }
#pragma warning restore CS8618

    public GrantListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GrantListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GrantListResponseFromRaw.FromRawUnchecked"/>
    public static GrantListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GrantListResponseFromRaw : IFromRawJson<GrantListResponse>
{
    /// <inheritdoc/>
    public GrantListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        GrantListResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// The monetary cost of the credit grant
/// </summary>
[JsonConverter(typeof(JsonModelConverter<GrantListResponseCost, GrantListResponseCostFromRaw>))]
public sealed record class GrantListResponseCost : JsonModel
{
    /// <summary>
    /// The cost amount
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
    /// The currency code
    /// </summary>
    public required string Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.Currency;
    }

    public GrantListResponseCost() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GrantListResponseCost(GrantListResponseCost grantListResponseCost)
        : base(grantListResponseCost) { }
#pragma warning restore CS8618

    public GrantListResponseCost(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GrantListResponseCost(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GrantListResponseCostFromRaw.FromRawUnchecked"/>
    public static GrantListResponseCost FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GrantListResponseCostFromRaw : IFromRawJson<GrantListResponseCost>
{
    /// <inheritdoc/>
    public GrantListResponseCost FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => GrantListResponseCost.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of credit grant (PAID, PROMOTIONAL, RECURRING)
/// </summary>
[JsonConverter(typeof(GrantListResponseGrantTypeConverter))]
public enum GrantListResponseGrantType
{
    Paid,
    Promotional,
    Recurring,
    Overdraft,
}

sealed class GrantListResponseGrantTypeConverter : JsonConverter<GrantListResponseGrantType>
{
    public override GrantListResponseGrantType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PAID" => GrantListResponseGrantType.Paid,
            "PROMOTIONAL" => GrantListResponseGrantType.Promotional,
            "RECURRING" => GrantListResponseGrantType.Recurring,
            "OVERDRAFT" => GrantListResponseGrantType.Overdraft,
            _ => (GrantListResponseGrantType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        GrantListResponseGrantType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                GrantListResponseGrantType.Paid => "PAID",
                GrantListResponseGrantType.Promotional => "PROMOTIONAL",
                GrantListResponseGrantType.Recurring => "RECURRING",
                GrantListResponseGrantType.Overdraft => "OVERDRAFT",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The latest invoice details for this grant
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        GrantListResponseLatestInvoice,
        GrantListResponseLatestInvoiceFromRaw
    >)
)]
public sealed record class GrantListResponseLatestInvoice : JsonModel
{
    /// <summary>
    /// The billing provider invoice ID
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
    /// The billing reason for the invoice
    /// </summary>
    public required ApiEnum<string, GrantListResponseLatestInvoiceBillingReason>? BillingReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, GrantListResponseLatestInvoiceBillingReason>
            >("billingReason");
        }
        init { this._rawData.Set("billingReason", value); }
    }

    /// <summary>
    /// The invoice creation date
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("createdAt");
        }
        init { this._rawData.Set("createdAt", value); }
    }

    /// <summary>
    /// The invoice currency
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
    /// The invoice due date
    /// </summary>
    public required DateTimeOffset? DueDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("dueDate");
        }
        init { this._rawData.Set("dueDate", value); }
    }

    /// <summary>
    /// Error message if payment failed
    /// </summary>
    public required string? ErrorMessage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("errorMessage");
        }
        init { this._rawData.Set("errorMessage", value); }
    }

    /// <summary>
    /// The payment URL for settling the invoice
    /// </summary>
    public required string? PaymentUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("paymentUrl");
        }
        init { this._rawData.Set("paymentUrl", value); }
    }

    /// <summary>
    /// The PDF URL of the invoice
    /// </summary>
    public required string? PdfUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("pdfUrl");
        }
        init { this._rawData.Set("pdfUrl", value); }
    }

    /// <summary>
    /// Whether the invoice requires user action
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
    /// The invoice status
    /// </summary>
    public required ApiEnum<string, GrantListResponseLatestInvoiceStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, GrantListResponseLatestInvoiceStatus>
            >("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// The subtotal amount before tax
    /// </summary>
    public required double? SubTotal
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("subTotal");
        }
        init { this._rawData.Set("subTotal", value); }
    }

    /// <summary>
    /// The tax amount
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
    /// The total amount including tax
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

    /// <summary>
    /// The invoice last update date
    /// </summary>
    public required DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("updatedAt");
        }
        init { this._rawData.Set("updatedAt", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BillingID;
        this.BillingReason?.Validate();
        _ = this.CreatedAt;
        _ = this.Currency;
        _ = this.DueDate;
        _ = this.ErrorMessage;
        _ = this.PaymentUrl;
        _ = this.PdfUrl;
        _ = this.RequiresAction;
        this.Status.Validate();
        _ = this.SubTotal;
        _ = this.Tax;
        _ = this.Total;
        _ = this.UpdatedAt;
    }

    public GrantListResponseLatestInvoice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GrantListResponseLatestInvoice(
        GrantListResponseLatestInvoice grantListResponseLatestInvoice
    )
        : base(grantListResponseLatestInvoice) { }
#pragma warning restore CS8618

    public GrantListResponseLatestInvoice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GrantListResponseLatestInvoice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GrantListResponseLatestInvoiceFromRaw.FromRawUnchecked"/>
    public static GrantListResponseLatestInvoice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GrantListResponseLatestInvoiceFromRaw : IFromRawJson<GrantListResponseLatestInvoice>
{
    /// <inheritdoc/>
    public GrantListResponseLatestInvoice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => GrantListResponseLatestInvoice.FromRawUnchecked(rawData);
}

/// <summary>
/// The billing reason for the invoice
/// </summary>
[JsonConverter(typeof(GrantListResponseLatestInvoiceBillingReasonConverter))]
public enum GrantListResponseLatestInvoiceBillingReason
{
    Manual,
    Other,
}

sealed class GrantListResponseLatestInvoiceBillingReasonConverter
    : JsonConverter<GrantListResponseLatestInvoiceBillingReason>
{
    public override GrantListResponseLatestInvoiceBillingReason Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "MANUAL" => GrantListResponseLatestInvoiceBillingReason.Manual,
            "OTHER" => GrantListResponseLatestInvoiceBillingReason.Other,
            _ => (GrantListResponseLatestInvoiceBillingReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        GrantListResponseLatestInvoiceBillingReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                GrantListResponseLatestInvoiceBillingReason.Manual => "MANUAL",
                GrantListResponseLatestInvoiceBillingReason.Other => "OTHER",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The invoice status
/// </summary>
[JsonConverter(typeof(GrantListResponseLatestInvoiceStatusConverter))]
public enum GrantListResponseLatestInvoiceStatus
{
    Open,
    Paid,
    Canceled,
}

sealed class GrantListResponseLatestInvoiceStatusConverter
    : JsonConverter<GrantListResponseLatestInvoiceStatus>
{
    public override GrantListResponseLatestInvoiceStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "OPEN" => GrantListResponseLatestInvoiceStatus.Open,
            "PAID" => GrantListResponseLatestInvoiceStatus.Paid,
            "CANCELED" => GrantListResponseLatestInvoiceStatus.Canceled,
            _ => (GrantListResponseLatestInvoiceStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        GrantListResponseLatestInvoiceStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                GrantListResponseLatestInvoiceStatus.Open => "OPEN",
                GrantListResponseLatestInvoiceStatus.Paid => "PAID",
                GrantListResponseLatestInvoiceStatus.Canceled => "CANCELED",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The payment collection status
/// </summary>
[JsonConverter(typeof(GrantListResponsePaymentCollectionConverter))]
public enum GrantListResponsePaymentCollection
{
    NotRequired,
    Processing,
    Failed,
    ActionRequired,
}

sealed class GrantListResponsePaymentCollectionConverter
    : JsonConverter<GrantListResponsePaymentCollection>
{
    public override GrantListResponsePaymentCollection Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "NOT_REQUIRED" => GrantListResponsePaymentCollection.NotRequired,
            "PROCESSING" => GrantListResponsePaymentCollection.Processing,
            "FAILED" => GrantListResponsePaymentCollection.Failed,
            "ACTION_REQUIRED" => GrantListResponsePaymentCollection.ActionRequired,
            _ => (GrantListResponsePaymentCollection)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        GrantListResponsePaymentCollection value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                GrantListResponsePaymentCollection.NotRequired => "NOT_REQUIRED",
                GrantListResponsePaymentCollection.Processing => "PROCESSING",
                GrantListResponsePaymentCollection.Failed => "FAILED",
                GrantListResponsePaymentCollection.ActionRequired => "ACTION_REQUIRED",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The source type of the grant (PRICE, PLAN_ENTITLEMENT, ADDON_ENTITLEMENT)
/// </summary>
[JsonConverter(typeof(GrantListResponseSourceTypeConverter))]
public enum GrantListResponseSourceType
{
    Price,
    PlanEntitlement,
    AddonEntitlement,
}

sealed class GrantListResponseSourceTypeConverter : JsonConverter<GrantListResponseSourceType>
{
    public override GrantListResponseSourceType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PRICE" => GrantListResponseSourceType.Price,
            "PLAN_ENTITLEMENT" => GrantListResponseSourceType.PlanEntitlement,
            "ADDON_ENTITLEMENT" => GrantListResponseSourceType.AddonEntitlement,
            _ => (GrantListResponseSourceType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        GrantListResponseSourceType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                GrantListResponseSourceType.Price => "PRICE",
                GrantListResponseSourceType.PlanEntitlement => "PLAN_ENTITLEMENT",
                GrantListResponseSourceType.AddonEntitlement => "ADDON_ENTITLEMENT",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The effective status of the credit grant
/// </summary>
[JsonConverter(typeof(GrantListResponseStatusConverter))]
public enum GrantListResponseStatus
{
    PaymentPending,
    Active,
    Expired,
    Voided,
    Scheduled,
}

sealed class GrantListResponseStatusConverter : JsonConverter<GrantListResponseStatus>
{
    public override GrantListResponseStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PAYMENT_PENDING" => GrantListResponseStatus.PaymentPending,
            "ACTIVE" => GrantListResponseStatus.Active,
            "EXPIRED" => GrantListResponseStatus.Expired,
            "VOIDED" => GrantListResponseStatus.Voided,
            "SCHEDULED" => GrantListResponseStatus.Scheduled,
            _ => (GrantListResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        GrantListResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                GrantListResponseStatus.PaymentPending => "PAYMENT_PENDING",
                GrantListResponseStatus.Active => "ACTIVE",
                GrantListResponseStatus.Expired => "EXPIRED",
                GrantListResponseStatus.Voided => "VOIDED",
                GrantListResponseStatus.Scheduled => "SCHEDULED",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
