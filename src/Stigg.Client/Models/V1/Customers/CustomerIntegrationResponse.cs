using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using System = System;

namespace Stigg.Client.Models.V1.Customers;

/// <summary>
/// Response object
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<CustomerIntegrationResponse, CustomerIntegrationResponseFromRaw>)
)]
public sealed record class CustomerIntegrationResponse : JsonModel
{
    /// <summary>
    /// External billing or CRM integration link
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

    public CustomerIntegrationResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerIntegrationResponse(CustomerIntegrationResponse customerIntegrationResponse)
        : base(customerIntegrationResponse) { }
#pragma warning restore CS8618

    public CustomerIntegrationResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerIntegrationResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerIntegrationResponseFromRaw.FromRawUnchecked"/>
    public static CustomerIntegrationResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CustomerIntegrationResponse(Data data)
        : this()
    {
        this.Data = data;
    }
}

class CustomerIntegrationResponseFromRaw : IFromRawJson<CustomerIntegrationResponse>
{
    /// <inheritdoc/>
    public CustomerIntegrationResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerIntegrationResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// External billing or CRM integration link
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
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
    public required ApiEnum<string, DataVendorIdentifier> VendorIdentifier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, DataVendorIdentifier>>(
                "vendorIdentifier"
            );
        }
        init { this._rawData.Set("vendorIdentifier", value); }
    }

    /// <summary>
    /// Price billing sync revision data containing billing ID, link URL, and price
    /// group package billing ID
    /// </summary>
    public SyncData? SyncData
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SyncData>("syncData");
        }
        init { this._rawData.Set("syncData", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.SyncedEntityID;
        this.VendorIdentifier.Validate();
        this.SyncData?.Validate();
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
/// The vendor identifier of integration
/// </summary>
[JsonConverter(typeof(DataVendorIdentifierConverter))]
public enum DataVendorIdentifier
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

sealed class DataVendorIdentifierConverter : JsonConverter<DataVendorIdentifier>
{
    public override DataVendorIdentifier Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "AUTH0" => DataVendorIdentifier.Auth0,
            "ZUORA" => DataVendorIdentifier.Zuora,
            "STRIPE" => DataVendorIdentifier.Stripe,
            "HUBSPOT" => DataVendorIdentifier.Hubspot,
            "AWS_MARKETPLACE" => DataVendorIdentifier.AwsMarketplace,
            "SNOWFLAKE" => DataVendorIdentifier.Snowflake,
            "SALESFORCE" => DataVendorIdentifier.Salesforce,
            "BIG_QUERY" => DataVendorIdentifier.BigQuery,
            "OPEN_FGA" => DataVendorIdentifier.OpenFga,
            "APP_STORE" => DataVendorIdentifier.AppStore,
            "RECEIVED" => DataVendorIdentifier.Received,
            "PREQUEL" => DataVendorIdentifier.Prequel,
            "AIRWALLEX" => DataVendorIdentifier.Airwallex,
            "STRIPE_INVOICING" => DataVendorIdentifier.StripeInvoicing,
            _ => (DataVendorIdentifier)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DataVendorIdentifier value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DataVendorIdentifier.Auth0 => "AUTH0",
                DataVendorIdentifier.Zuora => "ZUORA",
                DataVendorIdentifier.Stripe => "STRIPE",
                DataVendorIdentifier.Hubspot => "HUBSPOT",
                DataVendorIdentifier.AwsMarketplace => "AWS_MARKETPLACE",
                DataVendorIdentifier.Snowflake => "SNOWFLAKE",
                DataVendorIdentifier.Salesforce => "SALESFORCE",
                DataVendorIdentifier.BigQuery => "BIG_QUERY",
                DataVendorIdentifier.OpenFga => "OPEN_FGA",
                DataVendorIdentifier.AppStore => "APP_STORE",
                DataVendorIdentifier.Received => "RECEIVED",
                DataVendorIdentifier.Prequel => "PREQUEL",
                DataVendorIdentifier.Airwallex => "AIRWALLEX",
                DataVendorIdentifier.StripeInvoicing => "STRIPE_INVOICING",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Price billing sync revision data containing billing ID, link URL, and price group
/// package billing ID
/// </summary>
[JsonConverter(typeof(SyncDataConverter))]
public record class SyncData : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? BillingID
    {
        get
        {
            return Match<string?>(
                revisionPriceBilling: (x) => x.BillingID,
                revisionBilling: (x) => x.BillingID,
                revisionMarketplace: (_) => null
            );
        }
    }

    public string? BillingLinkUrl
    {
        get
        {
            return Match<string?>(
                revisionPriceBilling: (x) => x.BillingLinkUrl,
                revisionBilling: (x) => x.BillingLinkUrl,
                revisionMarketplace: (_) => null
            );
        }
    }

    public SyncData(SyncRevisionPriceBillingData value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public SyncData(SyncRevisionBillingData value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public SyncData(SyncRevisionMarketplaceData value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public SyncData(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SyncRevisionPriceBillingData"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickRevisionPriceBilling(out var value)) {
    ///     // `value` is of type `SyncRevisionPriceBillingData`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickRevisionPriceBilling(
        [NotNullWhen(true)] out SyncRevisionPriceBillingData? value
    )
    {
        value = this.Value as SyncRevisionPriceBillingData;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SyncRevisionBillingData"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickRevisionBilling(out var value)) {
    ///     // `value` is of type `SyncRevisionBillingData`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickRevisionBilling([NotNullWhen(true)] out SyncRevisionBillingData? value)
    {
        value = this.Value as SyncRevisionBillingData;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SyncRevisionMarketplaceData"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickRevisionMarketplace(out var value)) {
    ///     // `value` is of type `SyncRevisionMarketplaceData`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickRevisionMarketplace(
        [NotNullWhen(true)] out SyncRevisionMarketplaceData? value
    )
    {
        value = this.Value as SyncRevisionMarketplaceData;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="StiggInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (SyncRevisionPriceBillingData value) =&gt; {...},
    ///     (SyncRevisionBillingData value) =&gt; {...},
    ///     (SyncRevisionMarketplaceData value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<SyncRevisionPriceBillingData> revisionPriceBilling,
        System::Action<SyncRevisionBillingData> revisionBilling,
        System::Action<SyncRevisionMarketplaceData> revisionMarketplace
    )
    {
        switch (this.Value)
        {
            case SyncRevisionPriceBillingData value:
                revisionPriceBilling(value);
                break;
            case SyncRevisionBillingData value:
                revisionBilling(value);
                break;
            case SyncRevisionMarketplaceData value:
                revisionMarketplace(value);
                break;
            default:
                throw new StiggInvalidDataException("Data did not match any variant of SyncData");
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="StiggInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (SyncRevisionPriceBillingData value) =&gt; {...},
    ///     (SyncRevisionBillingData value) =&gt; {...},
    ///     (SyncRevisionMarketplaceData value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<SyncRevisionPriceBillingData, T> revisionPriceBilling,
        System::Func<SyncRevisionBillingData, T> revisionBilling,
        System::Func<SyncRevisionMarketplaceData, T> revisionMarketplace
    )
    {
        return this.Value switch
        {
            SyncRevisionPriceBillingData value => revisionPriceBilling(value),
            SyncRevisionBillingData value => revisionBilling(value),
            SyncRevisionMarketplaceData value => revisionMarketplace(value),
            _ => throw new StiggInvalidDataException("Data did not match any variant of SyncData"),
        };
    }

    public static implicit operator SyncData(SyncRevisionPriceBillingData value) => new(value);

    public static implicit operator SyncData(SyncRevisionBillingData value) => new(value);

    public static implicit operator SyncData(SyncRevisionMarketplaceData value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="StiggInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new StiggInvalidDataException("Data did not match any variant of SyncData");
        }
        this.Switch(
            (revisionPriceBilling) => revisionPriceBilling.Validate(),
            (revisionBilling) => revisionBilling.Validate(),
            (revisionMarketplace) => revisionMarketplace.Validate()
        );
    }

    public virtual bool Equals(SyncData? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            SyncRevisionPriceBillingData _ => 0,
            SyncRevisionBillingData _ => 1,
            SyncRevisionMarketplaceData _ => 2,
            _ => -1,
        };
    }
}

sealed class SyncDataConverter : JsonConverter<SyncData?>
{
    public override SyncData? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<SyncRevisionPriceBillingData>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is StiggInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<SyncRevisionBillingData>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is StiggInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<SyncRevisionMarketplaceData>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is StiggInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        SyncData? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

/// <summary>
/// Price billing sync revision data containing billing ID, link URL, and price group
/// package billing ID
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<SyncRevisionPriceBillingData, SyncRevisionPriceBillingDataFromRaw>)
)]
public sealed record class SyncRevisionPriceBillingData : JsonModel
{
    /// <summary>
    /// Billing integration id
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
    /// Billing integration url
    /// </summary>
    public required string BillingLinkUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("billingLinkUrl");
        }
        init { this._rawData.Set("billingLinkUrl", value); }
    }

    /// <summary>
    /// Price group package billing id
    /// </summary>
    public required string PriceGroupPackageBillingID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("priceGroupPackageBillingId");
        }
        init { this._rawData.Set("priceGroupPackageBillingId", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BillingID;
        _ = this.BillingLinkUrl;
        _ = this.PriceGroupPackageBillingID;
    }

    public SyncRevisionPriceBillingData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SyncRevisionPriceBillingData(SyncRevisionPriceBillingData syncRevisionPriceBillingData)
        : base(syncRevisionPriceBillingData) { }
#pragma warning restore CS8618

    public SyncRevisionPriceBillingData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SyncRevisionPriceBillingData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SyncRevisionPriceBillingDataFromRaw.FromRawUnchecked"/>
    public static SyncRevisionPriceBillingData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SyncRevisionPriceBillingDataFromRaw : IFromRawJson<SyncRevisionPriceBillingData>
{
    /// <inheritdoc/>
    public SyncRevisionPriceBillingData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SyncRevisionPriceBillingData.FromRawUnchecked(rawData);
}

/// <summary>
/// Billing sync revision data containing billing ID and link URL
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SyncRevisionBillingData, SyncRevisionBillingDataFromRaw>))]
public sealed record class SyncRevisionBillingData : JsonModel
{
    /// <summary>
    /// Billing integration id
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
    /// Billing integration url
    /// </summary>
    public required string BillingLinkUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("billingLinkUrl");
        }
        init { this._rawData.Set("billingLinkUrl", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BillingID;
        _ = this.BillingLinkUrl;
    }

    public SyncRevisionBillingData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SyncRevisionBillingData(SyncRevisionBillingData syncRevisionBillingData)
        : base(syncRevisionBillingData) { }
#pragma warning restore CS8618

    public SyncRevisionBillingData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SyncRevisionBillingData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SyncRevisionBillingDataFromRaw.FromRawUnchecked"/>
    public static SyncRevisionBillingData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SyncRevisionBillingDataFromRaw : IFromRawJson<SyncRevisionBillingData>
{
    /// <inheritdoc/>
    public SyncRevisionBillingData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SyncRevisionBillingData.FromRawUnchecked(rawData);
}

/// <summary>
/// Marketplace sync revision data containing dimensions
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<SyncRevisionMarketplaceData, SyncRevisionMarketplaceDataFromRaw>)
)]
public sealed record class SyncRevisionMarketplaceData : JsonModel
{
    /// <summary>
    /// Dimensions of the marketplace sync revision
    /// </summary>
    public required string Dimensions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("dimensions");
        }
        init { this._rawData.Set("dimensions", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Dimensions;
    }

    public SyncRevisionMarketplaceData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SyncRevisionMarketplaceData(SyncRevisionMarketplaceData syncRevisionMarketplaceData)
        : base(syncRevisionMarketplaceData) { }
#pragma warning restore CS8618

    public SyncRevisionMarketplaceData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SyncRevisionMarketplaceData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SyncRevisionMarketplaceDataFromRaw.FromRawUnchecked"/>
    public static SyncRevisionMarketplaceData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SyncRevisionMarketplaceData(string dimensions)
        : this()
    {
        this.Dimensions = dimensions;
    }
}

class SyncRevisionMarketplaceDataFromRaw : IFromRawJson<SyncRevisionMarketplaceData>
{
    /// <inheritdoc/>
    public SyncRevisionMarketplaceData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SyncRevisionMarketplaceData.FromRawUnchecked(rawData);
}
