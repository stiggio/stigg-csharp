using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Core;
using Stigg.Exceptions;
using System = System;

namespace Stigg.Models.V1.Customers;

[JsonConverter(typeof(JsonModelConverter<CustomerListResponse, CustomerListResponseFromRaw>))]
public sealed record class CustomerListResponse : JsonModel
{
    public required IReadOnlyList<CustomerListResponseData> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<CustomerListResponseData>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<CustomerListResponseData>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Pagination information including cursors for navigation
    /// </summary>
    public required Pagination Pagination
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Pagination>("pagination");
        }
        init { this._rawData.Set("pagination", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        this.Pagination.Validate();
    }

    public CustomerListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerListResponse(CustomerListResponse customerListResponse)
        : base(customerListResponse) { }
#pragma warning restore CS8618

    public CustomerListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerListResponseFromRaw.FromRawUnchecked"/>
    public static CustomerListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerListResponseFromRaw : IFromRawJson<CustomerListResponse>
{
    /// <inheritdoc/>
    public CustomerListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerListResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<CustomerListResponseData, CustomerListResponseDataFromRaw>)
)]
public sealed record class CustomerListResponseData : JsonModel
{
    /// <summary>
    /// Customer slug
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
    /// Timestamp of when the record was deleted
    /// </summary>
    public required System::DateTimeOffset? ArchivedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("archivedAt");
        }
        init { this._rawData.Set("archivedAt", value); }
    }

    /// <summary>
    /// Timestamp of when the record was created
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
    /// Timestamp of when the record was last updated
    /// </summary>
    public required System::DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("updatedAt");
        }
        init { this._rawData.Set("updatedAt", value); }
    }

    /// <summary>
    /// Customer level coupon
    /// </summary>
    public string? CouponID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("couponId");
        }
        init { this._rawData.Set("couponId", value); }
    }

    /// <summary>
    /// The default payment method details
    /// </summary>
    public CustomerListResponseDataDefaultPaymentMethod? DefaultPaymentMethod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CustomerListResponseDataDefaultPaymentMethod>(
                "defaultPaymentMethod"
            );
        }
        init { this._rawData.Set("defaultPaymentMethod", value); }
    }

    /// <summary>
    /// The email of the customer
    /// </summary>
    public string? Email
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("email");
        }
        init { this._rawData.Set("email", value); }
    }

    /// <summary>
    /// List of integrations
    /// </summary>
    public IReadOnlyList<CustomerListResponseDataIntegration>? Integrations
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<CustomerListResponseDataIntegration>
            >("integrations");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<CustomerListResponseDataIntegration>?>(
                "integrations",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Additional metadata
    /// </summary>
    public IReadOnlyDictionary<string, string>? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, string>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// The name of the customer
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ArchivedAt;
        _ = this.CreatedAt;
        _ = this.UpdatedAt;
        _ = this.CouponID;
        this.DefaultPaymentMethod?.Validate();
        _ = this.Email;
        foreach (var item in this.Integrations ?? [])
        {
            item.Validate();
        }
        _ = this.Metadata;
        _ = this.Name;
    }

    public CustomerListResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerListResponseData(CustomerListResponseData customerListResponseData)
        : base(customerListResponseData) { }
#pragma warning restore CS8618

    public CustomerListResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerListResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerListResponseDataFromRaw.FromRawUnchecked"/>
    public static CustomerListResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerListResponseDataFromRaw : IFromRawJson<CustomerListResponseData>
{
    /// <inheritdoc/>
    public CustomerListResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerListResponseData.FromRawUnchecked(rawData);
}

/// <summary>
/// The default payment method details
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CustomerListResponseDataDefaultPaymentMethod,
        CustomerListResponseDataDefaultPaymentMethodFromRaw
    >)
)]
public sealed record class CustomerListResponseDataDefaultPaymentMethod : JsonModel
{
    /// <summary>
    /// The default payment method id
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
    /// The expiration month of the default payment method
    /// </summary>
    public required double? CardExpiryMonth
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("cardExpiryMonth");
        }
        init { this._rawData.Set("cardExpiryMonth", value); }
    }

    /// <summary>
    /// The expiration year of the default payment method
    /// </summary>
    public required double? CardExpiryYear
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("cardExpiryYear");
        }
        init { this._rawData.Set("cardExpiryYear", value); }
    }

    /// <summary>
    /// The last 4 digits of the default payment method
    /// </summary>
    public required string? CardLast4Digits
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("cardLast4Digits");
        }
        init { this._rawData.Set("cardLast4Digits", value); }
    }

    /// <summary>
    /// The default payment method type
    /// </summary>
    public required ApiEnum<string, CustomerListResponseDataDefaultPaymentMethodType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, CustomerListResponseDataDefaultPaymentMethodType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BillingID;
        _ = this.CardExpiryMonth;
        _ = this.CardExpiryYear;
        _ = this.CardLast4Digits;
        this.Type.Validate();
    }

    public CustomerListResponseDataDefaultPaymentMethod() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerListResponseDataDefaultPaymentMethod(
        CustomerListResponseDataDefaultPaymentMethod customerListResponseDataDefaultPaymentMethod
    )
        : base(customerListResponseDataDefaultPaymentMethod) { }
#pragma warning restore CS8618

    public CustomerListResponseDataDefaultPaymentMethod(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerListResponseDataDefaultPaymentMethod(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerListResponseDataDefaultPaymentMethodFromRaw.FromRawUnchecked"/>
    public static CustomerListResponseDataDefaultPaymentMethod FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerListResponseDataDefaultPaymentMethodFromRaw
    : IFromRawJson<CustomerListResponseDataDefaultPaymentMethod>
{
    /// <inheritdoc/>
    public CustomerListResponseDataDefaultPaymentMethod FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerListResponseDataDefaultPaymentMethod.FromRawUnchecked(rawData);
}

/// <summary>
/// The default payment method type
/// </summary>
[JsonConverter(typeof(CustomerListResponseDataDefaultPaymentMethodTypeConverter))]
public enum CustomerListResponseDataDefaultPaymentMethodType
{
    Card,
    Bank,
    CashApp,
}

sealed class CustomerListResponseDataDefaultPaymentMethodTypeConverter
    : JsonConverter<CustomerListResponseDataDefaultPaymentMethodType>
{
    public override CustomerListResponseDataDefaultPaymentMethodType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "CARD" => CustomerListResponseDataDefaultPaymentMethodType.Card,
            "BANK" => CustomerListResponseDataDefaultPaymentMethodType.Bank,
            "CASH_APP" => CustomerListResponseDataDefaultPaymentMethodType.CashApp,
            _ => (CustomerListResponseDataDefaultPaymentMethodType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CustomerListResponseDataDefaultPaymentMethodType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CustomerListResponseDataDefaultPaymentMethodType.Card => "CARD",
                CustomerListResponseDataDefaultPaymentMethodType.Bank => "BANK",
                CustomerListResponseDataDefaultPaymentMethodType.CashApp => "CASH_APP",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        CustomerListResponseDataIntegration,
        CustomerListResponseDataIntegrationFromRaw
    >)
)]
public sealed record class CustomerListResponseDataIntegration : JsonModel
{
    /// <summary>
    /// Integration details
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
    public required ApiEnum<
        string,
        CustomerListResponseDataIntegrationVendorIdentifier
    > VendorIdentifier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, CustomerListResponseDataIntegrationVendorIdentifier>
            >("vendorIdentifier");
        }
        init { this._rawData.Set("vendorIdentifier", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.SyncedEntityID;
        this.VendorIdentifier.Validate();
    }

    public CustomerListResponseDataIntegration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerListResponseDataIntegration(
        CustomerListResponseDataIntegration customerListResponseDataIntegration
    )
        : base(customerListResponseDataIntegration) { }
#pragma warning restore CS8618

    public CustomerListResponseDataIntegration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerListResponseDataIntegration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerListResponseDataIntegrationFromRaw.FromRawUnchecked"/>
    public static CustomerListResponseDataIntegration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerListResponseDataIntegrationFromRaw : IFromRawJson<CustomerListResponseDataIntegration>
{
    /// <inheritdoc/>
    public CustomerListResponseDataIntegration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerListResponseDataIntegration.FromRawUnchecked(rawData);
}

/// <summary>
/// The vendor identifier of integration
/// </summary>
[JsonConverter(typeof(CustomerListResponseDataIntegrationVendorIdentifierConverter))]
public enum CustomerListResponseDataIntegrationVendorIdentifier
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
}

sealed class CustomerListResponseDataIntegrationVendorIdentifierConverter
    : JsonConverter<CustomerListResponseDataIntegrationVendorIdentifier>
{
    public override CustomerListResponseDataIntegrationVendorIdentifier Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "AUTH0" => CustomerListResponseDataIntegrationVendorIdentifier.Auth0,
            "ZUORA" => CustomerListResponseDataIntegrationVendorIdentifier.Zuora,
            "STRIPE" => CustomerListResponseDataIntegrationVendorIdentifier.Stripe,
            "HUBSPOT" => CustomerListResponseDataIntegrationVendorIdentifier.Hubspot,
            "AWS_MARKETPLACE" => CustomerListResponseDataIntegrationVendorIdentifier.AwsMarketplace,
            "SNOWFLAKE" => CustomerListResponseDataIntegrationVendorIdentifier.Snowflake,
            "SALESFORCE" => CustomerListResponseDataIntegrationVendorIdentifier.Salesforce,
            "BIG_QUERY" => CustomerListResponseDataIntegrationVendorIdentifier.BigQuery,
            "OPEN_FGA" => CustomerListResponseDataIntegrationVendorIdentifier.OpenFga,
            "APP_STORE" => CustomerListResponseDataIntegrationVendorIdentifier.AppStore,
            _ => (CustomerListResponseDataIntegrationVendorIdentifier)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CustomerListResponseDataIntegrationVendorIdentifier value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CustomerListResponseDataIntegrationVendorIdentifier.Auth0 => "AUTH0",
                CustomerListResponseDataIntegrationVendorIdentifier.Zuora => "ZUORA",
                CustomerListResponseDataIntegrationVendorIdentifier.Stripe => "STRIPE",
                CustomerListResponseDataIntegrationVendorIdentifier.Hubspot => "HUBSPOT",
                CustomerListResponseDataIntegrationVendorIdentifier.AwsMarketplace =>
                    "AWS_MARKETPLACE",
                CustomerListResponseDataIntegrationVendorIdentifier.Snowflake => "SNOWFLAKE",
                CustomerListResponseDataIntegrationVendorIdentifier.Salesforce => "SALESFORCE",
                CustomerListResponseDataIntegrationVendorIdentifier.BigQuery => "BIG_QUERY",
                CustomerListResponseDataIntegrationVendorIdentifier.OpenFga => "OPEN_FGA",
                CustomerListResponseDataIntegrationVendorIdentifier.AppStore => "APP_STORE",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Pagination information including cursors for navigation
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Pagination, PaginationFromRaw>))]
public sealed record class Pagination : JsonModel
{
    /// <summary>
    /// Cursor to fetch the next page (use with after parameter), null if no more pages
    /// </summary>
    public required string? Next
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("next");
        }
        init { this._rawData.Set("next", value); }
    }

    /// <summary>
    /// Cursor to fetch the previous page (use with before parameter), null if no
    /// previous pages
    /// </summary>
    public required string? Prev
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("prev");
        }
        init { this._rawData.Set("prev", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Next;
        _ = this.Prev;
    }

    public Pagination() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Pagination(Pagination pagination)
        : base(pagination) { }
#pragma warning restore CS8618

    public Pagination(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Pagination(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaginationFromRaw.FromRawUnchecked"/>
    public static Pagination FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaginationFromRaw : IFromRawJson<Pagination>
{
    /// <inheritdoc/>
    public Pagination FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Pagination.FromRawUnchecked(rawData);
}
