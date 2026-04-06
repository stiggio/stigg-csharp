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
    typeof(JsonModelConverter<IntegrationUnlinkResponse, IntegrationUnlinkResponseFromRaw>)
)]
public sealed record class IntegrationUnlinkResponse : JsonModel
{
    /// <summary>
    /// External billing or CRM integration link
    /// </summary>
    public required IntegrationUnlinkResponseData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<IntegrationUnlinkResponseData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public IntegrationUnlinkResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IntegrationUnlinkResponse(IntegrationUnlinkResponse integrationUnlinkResponse)
        : base(integrationUnlinkResponse) { }
#pragma warning restore CS8618

    public IntegrationUnlinkResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntegrationUnlinkResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IntegrationUnlinkResponseFromRaw.FromRawUnchecked"/>
    public static IntegrationUnlinkResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public IntegrationUnlinkResponse(IntegrationUnlinkResponseData data)
        : this()
    {
        this.Data = data;
    }
}

class IntegrationUnlinkResponseFromRaw : IFromRawJson<IntegrationUnlinkResponse>
{
    /// <inheritdoc/>
    public IntegrationUnlinkResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => IntegrationUnlinkResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// External billing or CRM integration link
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<IntegrationUnlinkResponseData, IntegrationUnlinkResponseDataFromRaw>)
)]
public sealed record class IntegrationUnlinkResponseData : JsonModel
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
    public required ApiEnum<string, IntegrationUnlinkResponseDataVendorIdentifier> VendorIdentifier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, IntegrationUnlinkResponseDataVendorIdentifier>
            >("vendorIdentifier");
        }
        init { this._rawData.Set("vendorIdentifier", value); }
    }

    /// <summary>
    /// Price billing sync revision data containing billing ID, link URL, and price
    /// group package billing ID
    /// </summary>
    public IntegrationUnlinkResponseDataSyncData? SyncData
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<IntegrationUnlinkResponseDataSyncData>(
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

    public IntegrationUnlinkResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IntegrationUnlinkResponseData(
        IntegrationUnlinkResponseData integrationUnlinkResponseData
    )
        : base(integrationUnlinkResponseData) { }
#pragma warning restore CS8618

    public IntegrationUnlinkResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntegrationUnlinkResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IntegrationUnlinkResponseDataFromRaw.FromRawUnchecked"/>
    public static IntegrationUnlinkResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IntegrationUnlinkResponseDataFromRaw : IFromRawJson<IntegrationUnlinkResponseData>
{
    /// <inheritdoc/>
    public IntegrationUnlinkResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => IntegrationUnlinkResponseData.FromRawUnchecked(rawData);
}

/// <summary>
/// The vendor identifier of integration
/// </summary>
[JsonConverter(typeof(IntegrationUnlinkResponseDataVendorIdentifierConverter))]
public enum IntegrationUnlinkResponseDataVendorIdentifier
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

sealed class IntegrationUnlinkResponseDataVendorIdentifierConverter
    : JsonConverter<IntegrationUnlinkResponseDataVendorIdentifier>
{
    public override IntegrationUnlinkResponseDataVendorIdentifier Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "AUTH0" => IntegrationUnlinkResponseDataVendorIdentifier.Auth0,
            "ZUORA" => IntegrationUnlinkResponseDataVendorIdentifier.Zuora,
            "STRIPE" => IntegrationUnlinkResponseDataVendorIdentifier.Stripe,
            "HUBSPOT" => IntegrationUnlinkResponseDataVendorIdentifier.Hubspot,
            "AWS_MARKETPLACE" => IntegrationUnlinkResponseDataVendorIdentifier.AwsMarketplace,
            "SNOWFLAKE" => IntegrationUnlinkResponseDataVendorIdentifier.Snowflake,
            "SALESFORCE" => IntegrationUnlinkResponseDataVendorIdentifier.Salesforce,
            "BIG_QUERY" => IntegrationUnlinkResponseDataVendorIdentifier.BigQuery,
            "OPEN_FGA" => IntegrationUnlinkResponseDataVendorIdentifier.OpenFga,
            "APP_STORE" => IntegrationUnlinkResponseDataVendorIdentifier.AppStore,
            _ => (IntegrationUnlinkResponseDataVendorIdentifier)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        IntegrationUnlinkResponseDataVendorIdentifier value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                IntegrationUnlinkResponseDataVendorIdentifier.Auth0 => "AUTH0",
                IntegrationUnlinkResponseDataVendorIdentifier.Zuora => "ZUORA",
                IntegrationUnlinkResponseDataVendorIdentifier.Stripe => "STRIPE",
                IntegrationUnlinkResponseDataVendorIdentifier.Hubspot => "HUBSPOT",
                IntegrationUnlinkResponseDataVendorIdentifier.AwsMarketplace => "AWS_MARKETPLACE",
                IntegrationUnlinkResponseDataVendorIdentifier.Snowflake => "SNOWFLAKE",
                IntegrationUnlinkResponseDataVendorIdentifier.Salesforce => "SALESFORCE",
                IntegrationUnlinkResponseDataVendorIdentifier.BigQuery => "BIG_QUERY",
                IntegrationUnlinkResponseDataVendorIdentifier.OpenFga => "OPEN_FGA",
                IntegrationUnlinkResponseDataVendorIdentifier.AppStore => "APP_STORE",
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
[JsonConverter(typeof(IntegrationUnlinkResponseDataSyncDataConverter))]
public record class IntegrationUnlinkResponseDataSyncData : ModelBase
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

    public IntegrationUnlinkResponseDataSyncData(
        IntegrationUnlinkResponseDataSyncDataSyncRevisionPriceBillingData value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public IntegrationUnlinkResponseDataSyncData(
        IntegrationUnlinkResponseDataSyncDataSyncRevisionBillingData value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public IntegrationUnlinkResponseDataSyncData(
        IntegrationUnlinkResponseDataSyncDataSyncRevisionMarketplaceData value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public IntegrationUnlinkResponseDataSyncData(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="IntegrationUnlinkResponseDataSyncDataSyncRevisionPriceBillingData"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickRevisionPriceBilling(out var value)) {
    ///     // `value` is of type `IntegrationUnlinkResponseDataSyncDataSyncRevisionPriceBillingData`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickRevisionPriceBilling(
        [NotNullWhen(true)]
            out IntegrationUnlinkResponseDataSyncDataSyncRevisionPriceBillingData? value
    )
    {
        value = this.Value as IntegrationUnlinkResponseDataSyncDataSyncRevisionPriceBillingData;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="IntegrationUnlinkResponseDataSyncDataSyncRevisionBillingData"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickRevisionBilling(out var value)) {
    ///     // `value` is of type `IntegrationUnlinkResponseDataSyncDataSyncRevisionBillingData`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickRevisionBilling(
        [NotNullWhen(true)] out IntegrationUnlinkResponseDataSyncDataSyncRevisionBillingData? value
    )
    {
        value = this.Value as IntegrationUnlinkResponseDataSyncDataSyncRevisionBillingData;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="IntegrationUnlinkResponseDataSyncDataSyncRevisionMarketplaceData"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickRevisionMarketplace(out var value)) {
    ///     // `value` is of type `IntegrationUnlinkResponseDataSyncDataSyncRevisionMarketplaceData`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickRevisionMarketplace(
        [NotNullWhen(true)]
            out IntegrationUnlinkResponseDataSyncDataSyncRevisionMarketplaceData? value
    )
    {
        value = this.Value as IntegrationUnlinkResponseDataSyncDataSyncRevisionMarketplaceData;
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
    ///     (IntegrationUnlinkResponseDataSyncDataSyncRevisionPriceBillingData value) =&gt; {...},
    ///     (IntegrationUnlinkResponseDataSyncDataSyncRevisionBillingData value) =&gt; {...},
    ///     (IntegrationUnlinkResponseDataSyncDataSyncRevisionMarketplaceData value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<IntegrationUnlinkResponseDataSyncDataSyncRevisionPriceBillingData> revisionPriceBilling,
        System::Action<IntegrationUnlinkResponseDataSyncDataSyncRevisionBillingData> revisionBilling,
        System::Action<IntegrationUnlinkResponseDataSyncDataSyncRevisionMarketplaceData> revisionMarketplace
    )
    {
        switch (this.Value)
        {
            case IntegrationUnlinkResponseDataSyncDataSyncRevisionPriceBillingData value:
                revisionPriceBilling(value);
                break;
            case IntegrationUnlinkResponseDataSyncDataSyncRevisionBillingData value:
                revisionBilling(value);
                break;
            case IntegrationUnlinkResponseDataSyncDataSyncRevisionMarketplaceData value:
                revisionMarketplace(value);
                break;
            default:
                throw new StiggInvalidDataException(
                    "Data did not match any variant of IntegrationUnlinkResponseDataSyncData"
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
    ///     (IntegrationUnlinkResponseDataSyncDataSyncRevisionPriceBillingData value) =&gt; {...},
    ///     (IntegrationUnlinkResponseDataSyncDataSyncRevisionBillingData value) =&gt; {...},
    ///     (IntegrationUnlinkResponseDataSyncDataSyncRevisionMarketplaceData value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<
            IntegrationUnlinkResponseDataSyncDataSyncRevisionPriceBillingData,
            T
        > revisionPriceBilling,
        System::Func<
            IntegrationUnlinkResponseDataSyncDataSyncRevisionBillingData,
            T
        > revisionBilling,
        System::Func<
            IntegrationUnlinkResponseDataSyncDataSyncRevisionMarketplaceData,
            T
        > revisionMarketplace
    )
    {
        return this.Value switch
        {
            IntegrationUnlinkResponseDataSyncDataSyncRevisionPriceBillingData value =>
                revisionPriceBilling(value),
            IntegrationUnlinkResponseDataSyncDataSyncRevisionBillingData value => revisionBilling(
                value
            ),
            IntegrationUnlinkResponseDataSyncDataSyncRevisionMarketplaceData value =>
                revisionMarketplace(value),
            _ => throw new StiggInvalidDataException(
                "Data did not match any variant of IntegrationUnlinkResponseDataSyncData"
            ),
        };
    }

    public static implicit operator IntegrationUnlinkResponseDataSyncData(
        IntegrationUnlinkResponseDataSyncDataSyncRevisionPriceBillingData value
    ) => new(value);

    public static implicit operator IntegrationUnlinkResponseDataSyncData(
        IntegrationUnlinkResponseDataSyncDataSyncRevisionBillingData value
    ) => new(value);

    public static implicit operator IntegrationUnlinkResponseDataSyncData(
        IntegrationUnlinkResponseDataSyncDataSyncRevisionMarketplaceData value
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
                "Data did not match any variant of IntegrationUnlinkResponseDataSyncData"
            );
        }
        this.Switch(
            (revisionPriceBilling) => revisionPriceBilling.Validate(),
            (revisionBilling) => revisionBilling.Validate(),
            (revisionMarketplace) => revisionMarketplace.Validate()
        );
    }

    public virtual bool Equals(IntegrationUnlinkResponseDataSyncData? other) =>
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
            IntegrationUnlinkResponseDataSyncDataSyncRevisionPriceBillingData _ => 0,
            IntegrationUnlinkResponseDataSyncDataSyncRevisionBillingData _ => 1,
            IntegrationUnlinkResponseDataSyncDataSyncRevisionMarketplaceData _ => 2,
            _ => -1,
        };
    }
}

sealed class IntegrationUnlinkResponseDataSyncDataConverter
    : JsonConverter<IntegrationUnlinkResponseDataSyncData?>
{
    public override IntegrationUnlinkResponseDataSyncData? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized =
                JsonSerializer.Deserialize<IntegrationUnlinkResponseDataSyncDataSyncRevisionPriceBillingData>(
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
                JsonSerializer.Deserialize<IntegrationUnlinkResponseDataSyncDataSyncRevisionBillingData>(
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
                JsonSerializer.Deserialize<IntegrationUnlinkResponseDataSyncDataSyncRevisionMarketplaceData>(
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
        IntegrationUnlinkResponseDataSyncData? value,
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
        IntegrationUnlinkResponseDataSyncDataSyncRevisionPriceBillingData,
        IntegrationUnlinkResponseDataSyncDataSyncRevisionPriceBillingDataFromRaw
    >)
)]
public sealed record class IntegrationUnlinkResponseDataSyncDataSyncRevisionPriceBillingData
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

    public IntegrationUnlinkResponseDataSyncDataSyncRevisionPriceBillingData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IntegrationUnlinkResponseDataSyncDataSyncRevisionPriceBillingData(
        IntegrationUnlinkResponseDataSyncDataSyncRevisionPriceBillingData integrationUnlinkResponseDataSyncDataSyncRevisionPriceBillingData
    )
        : base(integrationUnlinkResponseDataSyncDataSyncRevisionPriceBillingData) { }
#pragma warning restore CS8618

    public IntegrationUnlinkResponseDataSyncDataSyncRevisionPriceBillingData(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntegrationUnlinkResponseDataSyncDataSyncRevisionPriceBillingData(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IntegrationUnlinkResponseDataSyncDataSyncRevisionPriceBillingDataFromRaw.FromRawUnchecked"/>
    public static IntegrationUnlinkResponseDataSyncDataSyncRevisionPriceBillingData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IntegrationUnlinkResponseDataSyncDataSyncRevisionPriceBillingDataFromRaw
    : IFromRawJson<IntegrationUnlinkResponseDataSyncDataSyncRevisionPriceBillingData>
{
    /// <inheritdoc/>
    public IntegrationUnlinkResponseDataSyncDataSyncRevisionPriceBillingData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        IntegrationUnlinkResponseDataSyncDataSyncRevisionPriceBillingData.FromRawUnchecked(rawData);
}

/// <summary>
/// Billing sync revision data containing billing ID and link URL
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        IntegrationUnlinkResponseDataSyncDataSyncRevisionBillingData,
        IntegrationUnlinkResponseDataSyncDataSyncRevisionBillingDataFromRaw
    >)
)]
public sealed record class IntegrationUnlinkResponseDataSyncDataSyncRevisionBillingData : JsonModel
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

    public IntegrationUnlinkResponseDataSyncDataSyncRevisionBillingData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IntegrationUnlinkResponseDataSyncDataSyncRevisionBillingData(
        IntegrationUnlinkResponseDataSyncDataSyncRevisionBillingData integrationUnlinkResponseDataSyncDataSyncRevisionBillingData
    )
        : base(integrationUnlinkResponseDataSyncDataSyncRevisionBillingData) { }
#pragma warning restore CS8618

    public IntegrationUnlinkResponseDataSyncDataSyncRevisionBillingData(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntegrationUnlinkResponseDataSyncDataSyncRevisionBillingData(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IntegrationUnlinkResponseDataSyncDataSyncRevisionBillingDataFromRaw.FromRawUnchecked"/>
    public static IntegrationUnlinkResponseDataSyncDataSyncRevisionBillingData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IntegrationUnlinkResponseDataSyncDataSyncRevisionBillingDataFromRaw
    : IFromRawJson<IntegrationUnlinkResponseDataSyncDataSyncRevisionBillingData>
{
    /// <inheritdoc/>
    public IntegrationUnlinkResponseDataSyncDataSyncRevisionBillingData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => IntegrationUnlinkResponseDataSyncDataSyncRevisionBillingData.FromRawUnchecked(rawData);
}

/// <summary>
/// Marketplace sync revision data containing dimensions
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        IntegrationUnlinkResponseDataSyncDataSyncRevisionMarketplaceData,
        IntegrationUnlinkResponseDataSyncDataSyncRevisionMarketplaceDataFromRaw
    >)
)]
public sealed record class IntegrationUnlinkResponseDataSyncDataSyncRevisionMarketplaceData
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

    public IntegrationUnlinkResponseDataSyncDataSyncRevisionMarketplaceData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IntegrationUnlinkResponseDataSyncDataSyncRevisionMarketplaceData(
        IntegrationUnlinkResponseDataSyncDataSyncRevisionMarketplaceData integrationUnlinkResponseDataSyncDataSyncRevisionMarketplaceData
    )
        : base(integrationUnlinkResponseDataSyncDataSyncRevisionMarketplaceData) { }
#pragma warning restore CS8618

    public IntegrationUnlinkResponseDataSyncDataSyncRevisionMarketplaceData(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntegrationUnlinkResponseDataSyncDataSyncRevisionMarketplaceData(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IntegrationUnlinkResponseDataSyncDataSyncRevisionMarketplaceDataFromRaw.FromRawUnchecked"/>
    public static IntegrationUnlinkResponseDataSyncDataSyncRevisionMarketplaceData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public IntegrationUnlinkResponseDataSyncDataSyncRevisionMarketplaceData(string dimensions)
        : this()
    {
        this.Dimensions = dimensions;
    }
}

class IntegrationUnlinkResponseDataSyncDataSyncRevisionMarketplaceDataFromRaw
    : IFromRawJson<IntegrationUnlinkResponseDataSyncDataSyncRevisionMarketplaceData>
{
    /// <inheritdoc/>
    public IntegrationUnlinkResponseDataSyncDataSyncRevisionMarketplaceData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => IntegrationUnlinkResponseDataSyncDataSyncRevisionMarketplaceData.FromRawUnchecked(rawData);
}
