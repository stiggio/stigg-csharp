using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;

namespace Stigg.Client.Models.V1.Credits.Grants;

/// <summary>
/// Response object
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CreditGrantResponse, CreditGrantResponseFromRaw>))]
public sealed record class CreditGrantResponse : JsonModel
{
    /// <summary>
    /// Credit grant object representing allocated credits for a customer
    /// </summary>
    public required Data Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Data>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public CreditGrantResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreditGrantResponse(CreditGrantResponse creditGrantResponse)
        : base(creditGrantResponse) { }
#pragma warning restore CS8618

    public CreditGrantResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditGrantResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreditGrantResponseFromRaw.FromRawUnchecked"/>
    public static CreditGrantResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CreditGrantResponse(Data data)
        : this()
    {
        this.Data = data;
    }
}

class CreditGrantResponseFromRaw : IFromRawJson<CreditGrantResponse>
{
    /// <inheritdoc/>
    public CreditGrantResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CreditGrantResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Credit grant object representing allocated credits for a customer
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
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
    public required DataCost Cost
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<DataCost>("cost");
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
    public required ApiEnum<string, DataGrantType> GrantType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, DataGrantType>>("grantType");
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
    public required ApiEnum<string, PaymentCollection> PaymentCollection
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, PaymentCollection>>(
                "paymentCollection"
            );
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
    public required ApiEnum<string, SourceType>? SourceType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, SourceType>>("sourceType");
        }
        init { this._rawData.Set("sourceType", value); }
    }

    /// <summary>
    /// The effective status of the credit grant
    /// </summary>
    public required ApiEnum<string, DataStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, DataStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// The synchronization states of the entity with external systems
    /// </summary>
    public required IReadOnlyList<SyncState>? SyncStates
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<SyncState>>("syncStates");
        }
        init
        {
            this._rawData.Set<ImmutableArray<SyncState>?>(
                "syncStates",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
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
        foreach (var item in this.SyncStates ?? [])
        {
            item.Validate();
        }
        _ = this.UpdatedAt;
        _ = this.VoidedAt;
    }

    public Data() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Data(Data data)
        : base(data) { }
#pragma warning restore CS8618

    public Data(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Data(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataFromRaw.FromRawUnchecked"/>
    public static Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Data.FromRawUnchecked(rawData);
}

/// <summary>
/// The monetary cost of the credit grant
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DataCost, DataCostFromRaw>))]
public sealed record class DataCost : JsonModel
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

    public DataCost() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DataCost(DataCost dataCost)
        : base(dataCost) { }
#pragma warning restore CS8618

    public DataCost(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DataCost(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataCostFromRaw.FromRawUnchecked"/>
    public static DataCost FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataCostFromRaw : IFromRawJson<DataCost>
{
    /// <inheritdoc/>
    public DataCost FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DataCost.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of credit grant (PAID, PROMOTIONAL, RECURRING)
/// </summary>
[JsonConverter(typeof(DataGrantTypeConverter))]
public enum DataGrantType
{
    Paid,
    Promotional,
    Recurring,
    Overdraft,
}

sealed class DataGrantTypeConverter : JsonConverter<DataGrantType>
{
    public override DataGrantType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PAID" => DataGrantType.Paid,
            "PROMOTIONAL" => DataGrantType.Promotional,
            "RECURRING" => DataGrantType.Recurring,
            "OVERDRAFT" => DataGrantType.Overdraft,
            _ => (DataGrantType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DataGrantType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DataGrantType.Paid => "PAID",
                DataGrantType.Promotional => "PROMOTIONAL",
                DataGrantType.Recurring => "RECURRING",
                DataGrantType.Overdraft => "OVERDRAFT",
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
[JsonConverter(typeof(JsonModelConverter<LatestInvoice, LatestInvoiceFromRaw>))]
public sealed record class LatestInvoice : JsonModel
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
    public required ApiEnum<string, BillingReason>? BillingReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, BillingReason>>("billingReason");
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
/// The billing reason for the invoice
/// </summary>
[JsonConverter(typeof(BillingReasonConverter))]
public enum BillingReason
{
    Manual,
    Other,
}

sealed class BillingReasonConverter : JsonConverter<BillingReason>
{
    public override BillingReason Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "MANUAL" => BillingReason.Manual,
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
                BillingReason.Manual => "MANUAL",
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
/// The invoice status
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Open,
    Paid,
    Canceled,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "OPEN" => Status.Open,
            "PAID" => Status.Paid,
            "CANCELED" => Status.Canceled,
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
                Status.Paid => "PAID",
                Status.Canceled => "CANCELED",
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
[JsonConverter(typeof(PaymentCollectionConverter))]
public enum PaymentCollection
{
    NotRequired,
    Processing,
    Failed,
    ActionRequired,
}

sealed class PaymentCollectionConverter : JsonConverter<PaymentCollection>
{
    public override PaymentCollection Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "NOT_REQUIRED" => PaymentCollection.NotRequired,
            "PROCESSING" => PaymentCollection.Processing,
            "FAILED" => PaymentCollection.Failed,
            "ACTION_REQUIRED" => PaymentCollection.ActionRequired,
            _ => (PaymentCollection)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PaymentCollection value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PaymentCollection.NotRequired => "NOT_REQUIRED",
                PaymentCollection.Processing => "PROCESSING",
                PaymentCollection.Failed => "FAILED",
                PaymentCollection.ActionRequired => "ACTION_REQUIRED",
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
[JsonConverter(typeof(SourceTypeConverter))]
public enum SourceType
{
    Price,
    PlanEntitlement,
    AddonEntitlement,
}

sealed class SourceTypeConverter : JsonConverter<SourceType>
{
    public override SourceType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PRICE" => SourceType.Price,
            "PLAN_ENTITLEMENT" => SourceType.PlanEntitlement,
            "ADDON_ENTITLEMENT" => SourceType.AddonEntitlement,
            _ => (SourceType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SourceType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SourceType.Price => "PRICE",
                SourceType.PlanEntitlement => "PLAN_ENTITLEMENT",
                SourceType.AddonEntitlement => "ADDON_ENTITLEMENT",
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
[JsonConverter(typeof(DataStatusConverter))]
public enum DataStatus
{
    PaymentPending,
    Active,
    Expired,
    Voided,
    Scheduled,
}

sealed class DataStatusConverter : JsonConverter<DataStatus>
{
    public override DataStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PAYMENT_PENDING" => DataStatus.PaymentPending,
            "ACTIVE" => DataStatus.Active,
            "EXPIRED" => DataStatus.Expired,
            "VOIDED" => DataStatus.Voided,
            "SCHEDULED" => DataStatus.Scheduled,
            _ => (DataStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DataStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DataStatus.PaymentPending => "PAYMENT_PENDING",
                DataStatus.Active => "ACTIVE",
                DataStatus.Expired => "EXPIRED",
                DataStatus.Voided => "VOIDED",
                DataStatus.Scheduled => "SCHEDULED",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<SyncState, SyncStateFromRaw>))]
public sealed record class SyncState : JsonModel
{
    /// <summary>
    /// Status of the integration sync
    /// </summary>
    public required ApiEnum<string, SyncStateStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, SyncStateStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
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
        this.Status.Validate();
        _ = this.SyncedEntityID;
        this.VendorIdentifier.Validate();
    }

    public SyncState() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SyncState(SyncState syncState)
        : base(syncState) { }
#pragma warning restore CS8618

    public SyncState(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SyncState(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SyncStateFromRaw.FromRawUnchecked"/>
    public static SyncState FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SyncStateFromRaw : IFromRawJson<SyncState>
{
    /// <inheritdoc/>
    public SyncState FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SyncState.FromRawUnchecked(rawData);
}

/// <summary>
/// Status of the integration sync
/// </summary>
[JsonConverter(typeof(SyncStateStatusConverter))]
public enum SyncStateStatus
{
    Pending,
    Error,
    Success,
    NoSyncRequired,
}

sealed class SyncStateStatusConverter : JsonConverter<SyncStateStatus>
{
    public override SyncStateStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PENDING" => SyncStateStatus.Pending,
            "ERROR" => SyncStateStatus.Error,
            "SUCCESS" => SyncStateStatus.Success,
            "NO_SYNC_REQUIRED" => SyncStateStatus.NoSyncRequired,
            _ => (SyncStateStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SyncStateStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SyncStateStatus.Pending => "PENDING",
                SyncStateStatus.Error => "ERROR",
                SyncStateStatus.Success => "SUCCESS",
                SyncStateStatus.NoSyncRequired => "NO_SYNC_REQUIRED",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
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
        Type typeToConvert,
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
