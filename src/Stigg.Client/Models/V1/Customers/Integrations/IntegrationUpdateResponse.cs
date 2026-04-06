using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using System = System;

namespace Stigg.Client.Models.V1.Customers.Integrations;

/// <summary>
/// Response object
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<IntegrationUpdateResponse, IntegrationUpdateResponseFromRaw>)
)]
public sealed record class IntegrationUpdateResponse : JsonModel
{
    /// <summary>
    /// External billing or CRM integration link
    /// </summary>
    public required IntegrationUpdateResponseData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<IntegrationUpdateResponseData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public IntegrationUpdateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IntegrationUpdateResponse(IntegrationUpdateResponse integrationUpdateResponse)
        : base(integrationUpdateResponse) { }
#pragma warning restore CS8618

    public IntegrationUpdateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntegrationUpdateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IntegrationUpdateResponseFromRaw.FromRawUnchecked"/>
    public static IntegrationUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public IntegrationUpdateResponse(IntegrationUpdateResponseData data)
        : this()
    {
        this.Data = data;
    }
}

class IntegrationUpdateResponseFromRaw : IFromRawJson<IntegrationUpdateResponse>
{
    /// <inheritdoc/>
    public IntegrationUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => IntegrationUpdateResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// External billing or CRM integration link
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<IntegrationUpdateResponseData, IntegrationUpdateResponseDataFromRaw>)
)]
public sealed record class IntegrationUpdateResponseData : JsonModel
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
    public required ApiEnum<string, IntegrationUpdateResponseDataVendorIdentifier> VendorIdentifier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, IntegrationUpdateResponseDataVendorIdentifier>
            >("vendorIdentifier");
        }
        init { this._rawData.Set("vendorIdentifier", value); }
    }

    /// <summary>
    /// Price billing sync revision data containing billing ID, link URL, and price
    /// group package billing ID
    /// </summary>
    public IntegrationUpdateResponseDataSyncData? SyncData
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<IntegrationUpdateResponseDataSyncData>(
                "syncData"
            );
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

    public IntegrationUpdateResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IntegrationUpdateResponseData(
        IntegrationUpdateResponseData integrationUpdateResponseData
    )
        : base(integrationUpdateResponseData) { }
#pragma warning restore CS8618

    public IntegrationUpdateResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntegrationUpdateResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IntegrationUpdateResponseDataFromRaw.FromRawUnchecked"/>
    public static IntegrationUpdateResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IntegrationUpdateResponseDataFromRaw : IFromRawJson<IntegrationUpdateResponseData>
{
    /// <inheritdoc/>
    public IntegrationUpdateResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => IntegrationUpdateResponseData.FromRawUnchecked(rawData);
}

/// <summary>
/// The vendor identifier of integration
/// </summary>
[JsonConverter(typeof(IntegrationUpdateResponseDataVendorIdentifierConverter))]
public enum IntegrationUpdateResponseDataVendorIdentifier
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

sealed class IntegrationUpdateResponseDataVendorIdentifierConverter
    : JsonConverter<IntegrationUpdateResponseDataVendorIdentifier>
{
    public override IntegrationUpdateResponseDataVendorIdentifier Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "AUTH0" => IntegrationUpdateResponseDataVendorIdentifier.Auth0,
            "ZUORA" => IntegrationUpdateResponseDataVendorIdentifier.Zuora,
            "STRIPE" => IntegrationUpdateResponseDataVendorIdentifier.Stripe,
            "HUBSPOT" => IntegrationUpdateResponseDataVendorIdentifier.Hubspot,
            "AWS_MARKETPLACE" => IntegrationUpdateResponseDataVendorIdentifier.AwsMarketplace,
            "SNOWFLAKE" => IntegrationUpdateResponseDataVendorIdentifier.Snowflake,
            "SALESFORCE" => IntegrationUpdateResponseDataVendorIdentifier.Salesforce,
            "BIG_QUERY" => IntegrationUpdateResponseDataVendorIdentifier.BigQuery,
            "OPEN_FGA" => IntegrationUpdateResponseDataVendorIdentifier.OpenFga,
            "APP_STORE" => IntegrationUpdateResponseDataVendorIdentifier.AppStore,
            _ => (IntegrationUpdateResponseDataVendorIdentifier)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        IntegrationUpdateResponseDataVendorIdentifier value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                IntegrationUpdateResponseDataVendorIdentifier.Auth0 => "AUTH0",
                IntegrationUpdateResponseDataVendorIdentifier.Zuora => "ZUORA",
                IntegrationUpdateResponseDataVendorIdentifier.Stripe => "STRIPE",
                IntegrationUpdateResponseDataVendorIdentifier.Hubspot => "HUBSPOT",
                IntegrationUpdateResponseDataVendorIdentifier.AwsMarketplace => "AWS_MARKETPLACE",
                IntegrationUpdateResponseDataVendorIdentifier.Snowflake => "SNOWFLAKE",
                IntegrationUpdateResponseDataVendorIdentifier.Salesforce => "SALESFORCE",
                IntegrationUpdateResponseDataVendorIdentifier.BigQuery => "BIG_QUERY",
                IntegrationUpdateResponseDataVendorIdentifier.OpenFga => "OPEN_FGA",
                IntegrationUpdateResponseDataVendorIdentifier.AppStore => "APP_STORE",
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
[JsonConverter(typeof(IntegrationUpdateResponseDataSyncDataConverter))]
public record class IntegrationUpdateResponseDataSyncData : ModelBase
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

    public IntegrationUpdateResponseDataSyncData(
        IntegrationUpdateResponseDataSyncDataSyncRevisionPriceBillingData value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public IntegrationUpdateResponseDataSyncData(
        IntegrationUpdateResponseDataSyncDataSyncRevisionBillingData value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public IntegrationUpdateResponseDataSyncData(
        IntegrationUpdateResponseDataSyncDataSyncRevisionMarketplaceData value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public IntegrationUpdateResponseDataSyncData(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="IntegrationUpdateResponseDataSyncDataSyncRevisionPriceBillingData"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickRevisionPriceBilling(out var value)) {
    ///     // `value` is of type `IntegrationUpdateResponseDataSyncDataSyncRevisionPriceBillingData`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickRevisionPriceBilling(
        [NotNullWhen(true)]
            out IntegrationUpdateResponseDataSyncDataSyncRevisionPriceBillingData? value
    )
    {
        value = this.Value as IntegrationUpdateResponseDataSyncDataSyncRevisionPriceBillingData;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="IntegrationUpdateResponseDataSyncDataSyncRevisionBillingData"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickRevisionBilling(out var value)) {
    ///     // `value` is of type `IntegrationUpdateResponseDataSyncDataSyncRevisionBillingData`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickRevisionBilling(
        [NotNullWhen(true)] out IntegrationUpdateResponseDataSyncDataSyncRevisionBillingData? value
    )
    {
        value = this.Value as IntegrationUpdateResponseDataSyncDataSyncRevisionBillingData;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="IntegrationUpdateResponseDataSyncDataSyncRevisionMarketplaceData"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickRevisionMarketplace(out var value)) {
    ///     // `value` is of type `IntegrationUpdateResponseDataSyncDataSyncRevisionMarketplaceData`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickRevisionMarketplace(
        [NotNullWhen(true)]
            out IntegrationUpdateResponseDataSyncDataSyncRevisionMarketplaceData? value
    )
    {
        value = this.Value as IntegrationUpdateResponseDataSyncDataSyncRevisionMarketplaceData;
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
    ///     (IntegrationUpdateResponseDataSyncDataSyncRevisionPriceBillingData value) =&gt; {...},
    ///     (IntegrationUpdateResponseDataSyncDataSyncRevisionBillingData value) =&gt; {...},
    ///     (IntegrationUpdateResponseDataSyncDataSyncRevisionMarketplaceData value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<IntegrationUpdateResponseDataSyncDataSyncRevisionPriceBillingData> revisionPriceBilling,
        System::Action<IntegrationUpdateResponseDataSyncDataSyncRevisionBillingData> revisionBilling,
        System::Action<IntegrationUpdateResponseDataSyncDataSyncRevisionMarketplaceData> revisionMarketplace
    )
    {
        switch (this.Value)
        {
            case IntegrationUpdateResponseDataSyncDataSyncRevisionPriceBillingData value:
                revisionPriceBilling(value);
                break;
            case IntegrationUpdateResponseDataSyncDataSyncRevisionBillingData value:
                revisionBilling(value);
                break;
            case IntegrationUpdateResponseDataSyncDataSyncRevisionMarketplaceData value:
                revisionMarketplace(value);
                break;
            default:
                throw new StiggInvalidDataException(
                    "Data did not match any variant of IntegrationUpdateResponseDataSyncData"
                );
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
    ///     (IntegrationUpdateResponseDataSyncDataSyncRevisionPriceBillingData value) =&gt; {...},
    ///     (IntegrationUpdateResponseDataSyncDataSyncRevisionBillingData value) =&gt; {...},
    ///     (IntegrationUpdateResponseDataSyncDataSyncRevisionMarketplaceData value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<
            IntegrationUpdateResponseDataSyncDataSyncRevisionPriceBillingData,
            T
        > revisionPriceBilling,
        System::Func<
            IntegrationUpdateResponseDataSyncDataSyncRevisionBillingData,
            T
        > revisionBilling,
        System::Func<
            IntegrationUpdateResponseDataSyncDataSyncRevisionMarketplaceData,
            T
        > revisionMarketplace
    )
    {
        return this.Value switch
        {
            IntegrationUpdateResponseDataSyncDataSyncRevisionPriceBillingData value =>
                revisionPriceBilling(value),
            IntegrationUpdateResponseDataSyncDataSyncRevisionBillingData value => revisionBilling(
                value
            ),
            IntegrationUpdateResponseDataSyncDataSyncRevisionMarketplaceData value =>
                revisionMarketplace(value),
            _ => throw new StiggInvalidDataException(
                "Data did not match any variant of IntegrationUpdateResponseDataSyncData"
            ),
        };
    }

    public static implicit operator IntegrationUpdateResponseDataSyncData(
        IntegrationUpdateResponseDataSyncDataSyncRevisionPriceBillingData value
    ) => new(value);

    public static implicit operator IntegrationUpdateResponseDataSyncData(
        IntegrationUpdateResponseDataSyncDataSyncRevisionBillingData value
    ) => new(value);

    public static implicit operator IntegrationUpdateResponseDataSyncData(
        IntegrationUpdateResponseDataSyncDataSyncRevisionMarketplaceData value
    ) => new(value);

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
            throw new StiggInvalidDataException(
                "Data did not match any variant of IntegrationUpdateResponseDataSyncData"
            );
        }
        this.Switch(
            (revisionPriceBilling) => revisionPriceBilling.Validate(),
            (revisionBilling) => revisionBilling.Validate(),
            (revisionMarketplace) => revisionMarketplace.Validate()
        );
    }

    public virtual bool Equals(IntegrationUpdateResponseDataSyncData? other) =>
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
            IntegrationUpdateResponseDataSyncDataSyncRevisionPriceBillingData _ => 0,
            IntegrationUpdateResponseDataSyncDataSyncRevisionBillingData _ => 1,
            IntegrationUpdateResponseDataSyncDataSyncRevisionMarketplaceData _ => 2,
            _ => -1,
        };
    }
}

sealed class IntegrationUpdateResponseDataSyncDataConverter
    : JsonConverter<IntegrationUpdateResponseDataSyncData?>
{
    public override IntegrationUpdateResponseDataSyncData? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized =
                JsonSerializer.Deserialize<IntegrationUpdateResponseDataSyncDataSyncRevisionPriceBillingData>(
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
            var deserialized =
                JsonSerializer.Deserialize<IntegrationUpdateResponseDataSyncDataSyncRevisionBillingData>(
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
            var deserialized =
                JsonSerializer.Deserialize<IntegrationUpdateResponseDataSyncDataSyncRevisionMarketplaceData>(
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
        IntegrationUpdateResponseDataSyncData? value,
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
    typeof(JsonModelConverter<
        IntegrationUpdateResponseDataSyncDataSyncRevisionPriceBillingData,
        IntegrationUpdateResponseDataSyncDataSyncRevisionPriceBillingDataFromRaw
    >)
)]
public sealed record class IntegrationUpdateResponseDataSyncDataSyncRevisionPriceBillingData
    : JsonModel
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

    public IntegrationUpdateResponseDataSyncDataSyncRevisionPriceBillingData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IntegrationUpdateResponseDataSyncDataSyncRevisionPriceBillingData(
        IntegrationUpdateResponseDataSyncDataSyncRevisionPriceBillingData integrationUpdateResponseDataSyncDataSyncRevisionPriceBillingData
    )
        : base(integrationUpdateResponseDataSyncDataSyncRevisionPriceBillingData) { }
#pragma warning restore CS8618

    public IntegrationUpdateResponseDataSyncDataSyncRevisionPriceBillingData(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntegrationUpdateResponseDataSyncDataSyncRevisionPriceBillingData(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IntegrationUpdateResponseDataSyncDataSyncRevisionPriceBillingDataFromRaw.FromRawUnchecked"/>
    public static IntegrationUpdateResponseDataSyncDataSyncRevisionPriceBillingData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IntegrationUpdateResponseDataSyncDataSyncRevisionPriceBillingDataFromRaw
    : IFromRawJson<IntegrationUpdateResponseDataSyncDataSyncRevisionPriceBillingData>
{
    /// <inheritdoc/>
    public IntegrationUpdateResponseDataSyncDataSyncRevisionPriceBillingData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        IntegrationUpdateResponseDataSyncDataSyncRevisionPriceBillingData.FromRawUnchecked(rawData);
}

/// <summary>
/// Billing sync revision data containing billing ID and link URL
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        IntegrationUpdateResponseDataSyncDataSyncRevisionBillingData,
        IntegrationUpdateResponseDataSyncDataSyncRevisionBillingDataFromRaw
    >)
)]
public sealed record class IntegrationUpdateResponseDataSyncDataSyncRevisionBillingData : JsonModel
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

    public IntegrationUpdateResponseDataSyncDataSyncRevisionBillingData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IntegrationUpdateResponseDataSyncDataSyncRevisionBillingData(
        IntegrationUpdateResponseDataSyncDataSyncRevisionBillingData integrationUpdateResponseDataSyncDataSyncRevisionBillingData
    )
        : base(integrationUpdateResponseDataSyncDataSyncRevisionBillingData) { }
#pragma warning restore CS8618

    public IntegrationUpdateResponseDataSyncDataSyncRevisionBillingData(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntegrationUpdateResponseDataSyncDataSyncRevisionBillingData(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IntegrationUpdateResponseDataSyncDataSyncRevisionBillingDataFromRaw.FromRawUnchecked"/>
    public static IntegrationUpdateResponseDataSyncDataSyncRevisionBillingData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IntegrationUpdateResponseDataSyncDataSyncRevisionBillingDataFromRaw
    : IFromRawJson<IntegrationUpdateResponseDataSyncDataSyncRevisionBillingData>
{
    /// <inheritdoc/>
    public IntegrationUpdateResponseDataSyncDataSyncRevisionBillingData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => IntegrationUpdateResponseDataSyncDataSyncRevisionBillingData.FromRawUnchecked(rawData);
}

/// <summary>
/// Marketplace sync revision data containing dimensions
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        IntegrationUpdateResponseDataSyncDataSyncRevisionMarketplaceData,
        IntegrationUpdateResponseDataSyncDataSyncRevisionMarketplaceDataFromRaw
    >)
)]
public sealed record class IntegrationUpdateResponseDataSyncDataSyncRevisionMarketplaceData
    : JsonModel
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

    public IntegrationUpdateResponseDataSyncDataSyncRevisionMarketplaceData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IntegrationUpdateResponseDataSyncDataSyncRevisionMarketplaceData(
        IntegrationUpdateResponseDataSyncDataSyncRevisionMarketplaceData integrationUpdateResponseDataSyncDataSyncRevisionMarketplaceData
    )
        : base(integrationUpdateResponseDataSyncDataSyncRevisionMarketplaceData) { }
#pragma warning restore CS8618

    public IntegrationUpdateResponseDataSyncDataSyncRevisionMarketplaceData(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntegrationUpdateResponseDataSyncDataSyncRevisionMarketplaceData(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IntegrationUpdateResponseDataSyncDataSyncRevisionMarketplaceDataFromRaw.FromRawUnchecked"/>
    public static IntegrationUpdateResponseDataSyncDataSyncRevisionMarketplaceData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public IntegrationUpdateResponseDataSyncDataSyncRevisionMarketplaceData(string dimensions)
        : this()
    {
        this.Dimensions = dimensions;
    }
}

class IntegrationUpdateResponseDataSyncDataSyncRevisionMarketplaceDataFromRaw
    : IFromRawJson<IntegrationUpdateResponseDataSyncDataSyncRevisionMarketplaceData>
{
    /// <inheritdoc/>
    public IntegrationUpdateResponseDataSyncDataSyncRevisionMarketplaceData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => IntegrationUpdateResponseDataSyncDataSyncRevisionMarketplaceData.FromRawUnchecked(rawData);
}
