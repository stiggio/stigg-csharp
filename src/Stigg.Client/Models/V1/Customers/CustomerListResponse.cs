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
/// A customer can be either an organization or an individual
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CustomerListResponse, CustomerListResponseFromRaw>))]
public sealed record class CustomerListResponse : JsonModel
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
    public CustomerListResponseDefaultPaymentMethod? DefaultPaymentMethod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CustomerListResponseDefaultPaymentMethod>(
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
    public IReadOnlyList<CustomerListResponseIntegration>? Integrations
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<CustomerListResponseIntegration>>(
                "integrations"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<CustomerListResponseIntegration>?>(
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

/// <summary>
/// The default payment method details
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CustomerListResponseDefaultPaymentMethod,
        CustomerListResponseDefaultPaymentMethodFromRaw
    >)
)]
public sealed record class CustomerListResponseDefaultPaymentMethod : JsonModel
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
    public required ApiEnum<string, CustomerListResponseDefaultPaymentMethodType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, CustomerListResponseDefaultPaymentMethodType>
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

    public CustomerListResponseDefaultPaymentMethod() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerListResponseDefaultPaymentMethod(
        CustomerListResponseDefaultPaymentMethod customerListResponseDefaultPaymentMethod
    )
        : base(customerListResponseDefaultPaymentMethod) { }
#pragma warning restore CS8618

    public CustomerListResponseDefaultPaymentMethod(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerListResponseDefaultPaymentMethod(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerListResponseDefaultPaymentMethodFromRaw.FromRawUnchecked"/>
    public static CustomerListResponseDefaultPaymentMethod FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerListResponseDefaultPaymentMethodFromRaw
    : IFromRawJson<CustomerListResponseDefaultPaymentMethod>
{
    /// <inheritdoc/>
    public CustomerListResponseDefaultPaymentMethod FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerListResponseDefaultPaymentMethod.FromRawUnchecked(rawData);
}

/// <summary>
/// The default payment method type
/// </summary>
[JsonConverter(typeof(CustomerListResponseDefaultPaymentMethodTypeConverter))]
public enum CustomerListResponseDefaultPaymentMethodType
{
    Card,
    Bank,
    CashApp,
}

sealed class CustomerListResponseDefaultPaymentMethodTypeConverter
    : JsonConverter<CustomerListResponseDefaultPaymentMethodType>
{
    public override CustomerListResponseDefaultPaymentMethodType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "CARD" => CustomerListResponseDefaultPaymentMethodType.Card,
            "BANK" => CustomerListResponseDefaultPaymentMethodType.Bank,
            "CASH_APP" => CustomerListResponseDefaultPaymentMethodType.CashApp,
            _ => (CustomerListResponseDefaultPaymentMethodType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CustomerListResponseDefaultPaymentMethodType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CustomerListResponseDefaultPaymentMethodType.Card => "CARD",
                CustomerListResponseDefaultPaymentMethodType.Bank => "BANK",
                CustomerListResponseDefaultPaymentMethodType.CashApp => "CASH_APP",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// External billing or CRM integration link
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CustomerListResponseIntegration,
        CustomerListResponseIntegrationFromRaw
    >)
)]
public sealed record class CustomerListResponseIntegration : JsonModel
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
        CustomerListResponseIntegrationVendorIdentifier
    > VendorIdentifier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, CustomerListResponseIntegrationVendorIdentifier>
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

    public CustomerListResponseIntegration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerListResponseIntegration(
        CustomerListResponseIntegration customerListResponseIntegration
    )
        : base(customerListResponseIntegration) { }
#pragma warning restore CS8618

    public CustomerListResponseIntegration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerListResponseIntegration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerListResponseIntegrationFromRaw.FromRawUnchecked"/>
    public static CustomerListResponseIntegration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerListResponseIntegrationFromRaw : IFromRawJson<CustomerListResponseIntegration>
{
    /// <inheritdoc/>
    public CustomerListResponseIntegration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerListResponseIntegration.FromRawUnchecked(rawData);
}

/// <summary>
/// The vendor identifier of integration
/// </summary>
[JsonConverter(typeof(CustomerListResponseIntegrationVendorIdentifierConverter))]
public enum CustomerListResponseIntegrationVendorIdentifier
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

sealed class CustomerListResponseIntegrationVendorIdentifierConverter
    : JsonConverter<CustomerListResponseIntegrationVendorIdentifier>
{
    public override CustomerListResponseIntegrationVendorIdentifier Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "AUTH0" => CustomerListResponseIntegrationVendorIdentifier.Auth0,
            "ZUORA" => CustomerListResponseIntegrationVendorIdentifier.Zuora,
            "STRIPE" => CustomerListResponseIntegrationVendorIdentifier.Stripe,
            "HUBSPOT" => CustomerListResponseIntegrationVendorIdentifier.Hubspot,
            "AWS_MARKETPLACE" => CustomerListResponseIntegrationVendorIdentifier.AwsMarketplace,
            "SNOWFLAKE" => CustomerListResponseIntegrationVendorIdentifier.Snowflake,
            "SALESFORCE" => CustomerListResponseIntegrationVendorIdentifier.Salesforce,
            "BIG_QUERY" => CustomerListResponseIntegrationVendorIdentifier.BigQuery,
            "OPEN_FGA" => CustomerListResponseIntegrationVendorIdentifier.OpenFga,
            "APP_STORE" => CustomerListResponseIntegrationVendorIdentifier.AppStore,
            _ => (CustomerListResponseIntegrationVendorIdentifier)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CustomerListResponseIntegrationVendorIdentifier value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CustomerListResponseIntegrationVendorIdentifier.Auth0 => "AUTH0",
                CustomerListResponseIntegrationVendorIdentifier.Zuora => "ZUORA",
                CustomerListResponseIntegrationVendorIdentifier.Stripe => "STRIPE",
                CustomerListResponseIntegrationVendorIdentifier.Hubspot => "HUBSPOT",
                CustomerListResponseIntegrationVendorIdentifier.AwsMarketplace => "AWS_MARKETPLACE",
                CustomerListResponseIntegrationVendorIdentifier.Snowflake => "SNOWFLAKE",
                CustomerListResponseIntegrationVendorIdentifier.Salesforce => "SALESFORCE",
                CustomerListResponseIntegrationVendorIdentifier.BigQuery => "BIG_QUERY",
                CustomerListResponseIntegrationVendorIdentifier.OpenFga => "OPEN_FGA",
                CustomerListResponseIntegrationVendorIdentifier.AppStore => "APP_STORE",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
