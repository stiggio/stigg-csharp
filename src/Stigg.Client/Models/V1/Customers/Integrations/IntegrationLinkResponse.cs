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
[JsonConverter(typeof(JsonModelConverter<IntegrationLinkResponse, IntegrationLinkResponseFromRaw>))]
public sealed record class IntegrationLinkResponse : JsonModel
{
    /// <summary>
    /// External billing or CRM integration link
    /// </summary>
    public required IntegrationLinkResponseData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<IntegrationLinkResponseData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public IntegrationLinkResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IntegrationLinkResponse(IntegrationLinkResponse integrationLinkResponse)
        : base(integrationLinkResponse) { }
#pragma warning restore CS8618

    public IntegrationLinkResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntegrationLinkResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IntegrationLinkResponseFromRaw.FromRawUnchecked"/>
    public static IntegrationLinkResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public IntegrationLinkResponse(IntegrationLinkResponseData data)
        : this()
    {
        this.Data = data;
    }
}

class IntegrationLinkResponseFromRaw : IFromRawJson<IntegrationLinkResponse>
{
    /// <inheritdoc/>
    public IntegrationLinkResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => IntegrationLinkResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// External billing or CRM integration link
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<IntegrationLinkResponseData, IntegrationLinkResponseDataFromRaw>)
)]
public sealed record class IntegrationLinkResponseData : JsonModel
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
    public required ApiEnum<string, IntegrationLinkResponseDataVendorIdentifier> VendorIdentifier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, IntegrationLinkResponseDataVendorIdentifier>
            >("vendorIdentifier");
        }
        init { this._rawData.Set("vendorIdentifier", value); }
    }

    /// <summary>
    /// Price billing sync revision data containing billing ID, link URL, and price
    /// group package billing ID
    /// </summary>
    public IntegrationLinkResponseDataSyncData? SyncData
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<IntegrationLinkResponseDataSyncData>("syncData");
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

    public IntegrationLinkResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IntegrationLinkResponseData(IntegrationLinkResponseData integrationLinkResponseData)
        : base(integrationLinkResponseData) { }
#pragma warning restore CS8618

    public IntegrationLinkResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntegrationLinkResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IntegrationLinkResponseDataFromRaw.FromRawUnchecked"/>
    public static IntegrationLinkResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IntegrationLinkResponseDataFromRaw : IFromRawJson<IntegrationLinkResponseData>
{
    /// <inheritdoc/>
    public IntegrationLinkResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => IntegrationLinkResponseData.FromRawUnchecked(rawData);
}

/// <summary>
/// The vendor identifier of integration
/// </summary>
[JsonConverter(typeof(IntegrationLinkResponseDataVendorIdentifierConverter))]
public enum IntegrationLinkResponseDataVendorIdentifier
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

sealed class IntegrationLinkResponseDataVendorIdentifierConverter
    : JsonConverter<IntegrationLinkResponseDataVendorIdentifier>
{
    public override IntegrationLinkResponseDataVendorIdentifier Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "AUTH0" => IntegrationLinkResponseDataVendorIdentifier.Auth0,
            "ZUORA" => IntegrationLinkResponseDataVendorIdentifier.Zuora,
            "STRIPE" => IntegrationLinkResponseDataVendorIdentifier.Stripe,
            "HUBSPOT" => IntegrationLinkResponseDataVendorIdentifier.Hubspot,
            "AWS_MARKETPLACE" => IntegrationLinkResponseDataVendorIdentifier.AwsMarketplace,
            "SNOWFLAKE" => IntegrationLinkResponseDataVendorIdentifier.Snowflake,
            "SALESFORCE" => IntegrationLinkResponseDataVendorIdentifier.Salesforce,
            "BIG_QUERY" => IntegrationLinkResponseDataVendorIdentifier.BigQuery,
            "OPEN_FGA" => IntegrationLinkResponseDataVendorIdentifier.OpenFga,
            "APP_STORE" => IntegrationLinkResponseDataVendorIdentifier.AppStore,
            _ => (IntegrationLinkResponseDataVendorIdentifier)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        IntegrationLinkResponseDataVendorIdentifier value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                IntegrationLinkResponseDataVendorIdentifier.Auth0 => "AUTH0",
                IntegrationLinkResponseDataVendorIdentifier.Zuora => "ZUORA",
                IntegrationLinkResponseDataVendorIdentifier.Stripe => "STRIPE",
                IntegrationLinkResponseDataVendorIdentifier.Hubspot => "HUBSPOT",
                IntegrationLinkResponseDataVendorIdentifier.AwsMarketplace => "AWS_MARKETPLACE",
                IntegrationLinkResponseDataVendorIdentifier.Snowflake => "SNOWFLAKE",
                IntegrationLinkResponseDataVendorIdentifier.Salesforce => "SALESFORCE",
                IntegrationLinkResponseDataVendorIdentifier.BigQuery => "BIG_QUERY",
                IntegrationLinkResponseDataVendorIdentifier.OpenFga => "OPEN_FGA",
                IntegrationLinkResponseDataVendorIdentifier.AppStore => "APP_STORE",
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
[JsonConverter(typeof(IntegrationLinkResponseDataSyncDataConverter))]
public record class IntegrationLinkResponseDataSyncData : ModelBase
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

    public IntegrationLinkResponseDataSyncData(
        IntegrationLinkResponseDataSyncDataSyncRevisionPriceBillingData value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public IntegrationLinkResponseDataSyncData(
        IntegrationLinkResponseDataSyncDataSyncRevisionBillingData value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public IntegrationLinkResponseDataSyncData(
        IntegrationLinkResponseDataSyncDataSyncRevisionMarketplaceData value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public IntegrationLinkResponseDataSyncData(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="IntegrationLinkResponseDataSyncDataSyncRevisionPriceBillingData"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickRevisionPriceBilling(out var value)) {
    ///     // `value` is of type `IntegrationLinkResponseDataSyncDataSyncRevisionPriceBillingData`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickRevisionPriceBilling(
        [NotNullWhen(true)]
            out IntegrationLinkResponseDataSyncDataSyncRevisionPriceBillingData? value
    )
    {
        value = this.Value as IntegrationLinkResponseDataSyncDataSyncRevisionPriceBillingData;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="IntegrationLinkResponseDataSyncDataSyncRevisionBillingData"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickRevisionBilling(out var value)) {
    ///     // `value` is of type `IntegrationLinkResponseDataSyncDataSyncRevisionBillingData`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickRevisionBilling(
        [NotNullWhen(true)] out IntegrationLinkResponseDataSyncDataSyncRevisionBillingData? value
    )
    {
        value = this.Value as IntegrationLinkResponseDataSyncDataSyncRevisionBillingData;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="IntegrationLinkResponseDataSyncDataSyncRevisionMarketplaceData"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickRevisionMarketplace(out var value)) {
    ///     // `value` is of type `IntegrationLinkResponseDataSyncDataSyncRevisionMarketplaceData`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickRevisionMarketplace(
        [NotNullWhen(true)]
            out IntegrationLinkResponseDataSyncDataSyncRevisionMarketplaceData? value
    )
    {
        value = this.Value as IntegrationLinkResponseDataSyncDataSyncRevisionMarketplaceData;
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
    ///     (IntegrationLinkResponseDataSyncDataSyncRevisionPriceBillingData value) =&gt; {...},
    ///     (IntegrationLinkResponseDataSyncDataSyncRevisionBillingData value) =&gt; {...},
    ///     (IntegrationLinkResponseDataSyncDataSyncRevisionMarketplaceData value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<IntegrationLinkResponseDataSyncDataSyncRevisionPriceBillingData> revisionPriceBilling,
        System::Action<IntegrationLinkResponseDataSyncDataSyncRevisionBillingData> revisionBilling,
        System::Action<IntegrationLinkResponseDataSyncDataSyncRevisionMarketplaceData> revisionMarketplace
    )
    {
        switch (this.Value)
        {
            case IntegrationLinkResponseDataSyncDataSyncRevisionPriceBillingData value:
                revisionPriceBilling(value);
                break;
            case IntegrationLinkResponseDataSyncDataSyncRevisionBillingData value:
                revisionBilling(value);
                break;
            case IntegrationLinkResponseDataSyncDataSyncRevisionMarketplaceData value:
                revisionMarketplace(value);
                break;
            default:
                throw new StiggInvalidDataException(
                    "Data did not match any variant of IntegrationLinkResponseDataSyncData"
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
    ///     (IntegrationLinkResponseDataSyncDataSyncRevisionPriceBillingData value) =&gt; {...},
    ///     (IntegrationLinkResponseDataSyncDataSyncRevisionBillingData value) =&gt; {...},
    ///     (IntegrationLinkResponseDataSyncDataSyncRevisionMarketplaceData value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<
            IntegrationLinkResponseDataSyncDataSyncRevisionPriceBillingData,
            T
        > revisionPriceBilling,
        System::Func<IntegrationLinkResponseDataSyncDataSyncRevisionBillingData, T> revisionBilling,
        System::Func<
            IntegrationLinkResponseDataSyncDataSyncRevisionMarketplaceData,
            T
        > revisionMarketplace
    )
    {
        return this.Value switch
        {
            IntegrationLinkResponseDataSyncDataSyncRevisionPriceBillingData value =>
                revisionPriceBilling(value),
            IntegrationLinkResponseDataSyncDataSyncRevisionBillingData value => revisionBilling(
                value
            ),
            IntegrationLinkResponseDataSyncDataSyncRevisionMarketplaceData value =>
                revisionMarketplace(value),
            _ => throw new StiggInvalidDataException(
                "Data did not match any variant of IntegrationLinkResponseDataSyncData"
            ),
        };
    }

    public static implicit operator IntegrationLinkResponseDataSyncData(
        IntegrationLinkResponseDataSyncDataSyncRevisionPriceBillingData value
    ) => new(value);

    public static implicit operator IntegrationLinkResponseDataSyncData(
        IntegrationLinkResponseDataSyncDataSyncRevisionBillingData value
    ) => new(value);

    public static implicit operator IntegrationLinkResponseDataSyncData(
        IntegrationLinkResponseDataSyncDataSyncRevisionMarketplaceData value
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
                "Data did not match any variant of IntegrationLinkResponseDataSyncData"
            );
        }
        this.Switch(
            (revisionPriceBilling) => revisionPriceBilling.Validate(),
            (revisionBilling) => revisionBilling.Validate(),
            (revisionMarketplace) => revisionMarketplace.Validate()
        );
    }

    public virtual bool Equals(IntegrationLinkResponseDataSyncData? other) =>
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
            IntegrationLinkResponseDataSyncDataSyncRevisionPriceBillingData _ => 0,
            IntegrationLinkResponseDataSyncDataSyncRevisionBillingData _ => 1,
            IntegrationLinkResponseDataSyncDataSyncRevisionMarketplaceData _ => 2,
            _ => -1,
        };
    }
}

sealed class IntegrationLinkResponseDataSyncDataConverter
    : JsonConverter<IntegrationLinkResponseDataSyncData?>
{
    public override IntegrationLinkResponseDataSyncData? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized =
                JsonSerializer.Deserialize<IntegrationLinkResponseDataSyncDataSyncRevisionPriceBillingData>(
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
                JsonSerializer.Deserialize<IntegrationLinkResponseDataSyncDataSyncRevisionBillingData>(
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
                JsonSerializer.Deserialize<IntegrationLinkResponseDataSyncDataSyncRevisionMarketplaceData>(
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
        IntegrationLinkResponseDataSyncData? value,
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
        IntegrationLinkResponseDataSyncDataSyncRevisionPriceBillingData,
        IntegrationLinkResponseDataSyncDataSyncRevisionPriceBillingDataFromRaw
    >)
)]
public sealed record class IntegrationLinkResponseDataSyncDataSyncRevisionPriceBillingData
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

    public IntegrationLinkResponseDataSyncDataSyncRevisionPriceBillingData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IntegrationLinkResponseDataSyncDataSyncRevisionPriceBillingData(
        IntegrationLinkResponseDataSyncDataSyncRevisionPriceBillingData integrationLinkResponseDataSyncDataSyncRevisionPriceBillingData
    )
        : base(integrationLinkResponseDataSyncDataSyncRevisionPriceBillingData) { }
#pragma warning restore CS8618

    public IntegrationLinkResponseDataSyncDataSyncRevisionPriceBillingData(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntegrationLinkResponseDataSyncDataSyncRevisionPriceBillingData(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IntegrationLinkResponseDataSyncDataSyncRevisionPriceBillingDataFromRaw.FromRawUnchecked"/>
    public static IntegrationLinkResponseDataSyncDataSyncRevisionPriceBillingData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IntegrationLinkResponseDataSyncDataSyncRevisionPriceBillingDataFromRaw
    : IFromRawJson<IntegrationLinkResponseDataSyncDataSyncRevisionPriceBillingData>
{
    /// <inheritdoc/>
    public IntegrationLinkResponseDataSyncDataSyncRevisionPriceBillingData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => IntegrationLinkResponseDataSyncDataSyncRevisionPriceBillingData.FromRawUnchecked(rawData);
}

/// <summary>
/// Billing sync revision data containing billing ID and link URL
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        IntegrationLinkResponseDataSyncDataSyncRevisionBillingData,
        IntegrationLinkResponseDataSyncDataSyncRevisionBillingDataFromRaw
    >)
)]
public sealed record class IntegrationLinkResponseDataSyncDataSyncRevisionBillingData : JsonModel
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

    public IntegrationLinkResponseDataSyncDataSyncRevisionBillingData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IntegrationLinkResponseDataSyncDataSyncRevisionBillingData(
        IntegrationLinkResponseDataSyncDataSyncRevisionBillingData integrationLinkResponseDataSyncDataSyncRevisionBillingData
    )
        : base(integrationLinkResponseDataSyncDataSyncRevisionBillingData) { }
#pragma warning restore CS8618

    public IntegrationLinkResponseDataSyncDataSyncRevisionBillingData(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntegrationLinkResponseDataSyncDataSyncRevisionBillingData(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IntegrationLinkResponseDataSyncDataSyncRevisionBillingDataFromRaw.FromRawUnchecked"/>
    public static IntegrationLinkResponseDataSyncDataSyncRevisionBillingData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IntegrationLinkResponseDataSyncDataSyncRevisionBillingDataFromRaw
    : IFromRawJson<IntegrationLinkResponseDataSyncDataSyncRevisionBillingData>
{
    /// <inheritdoc/>
    public IntegrationLinkResponseDataSyncDataSyncRevisionBillingData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => IntegrationLinkResponseDataSyncDataSyncRevisionBillingData.FromRawUnchecked(rawData);
}

/// <summary>
/// Marketplace sync revision data containing dimensions
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        IntegrationLinkResponseDataSyncDataSyncRevisionMarketplaceData,
        IntegrationLinkResponseDataSyncDataSyncRevisionMarketplaceDataFromRaw
    >)
)]
public sealed record class IntegrationLinkResponseDataSyncDataSyncRevisionMarketplaceData
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

    public IntegrationLinkResponseDataSyncDataSyncRevisionMarketplaceData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IntegrationLinkResponseDataSyncDataSyncRevisionMarketplaceData(
        IntegrationLinkResponseDataSyncDataSyncRevisionMarketplaceData integrationLinkResponseDataSyncDataSyncRevisionMarketplaceData
    )
        : base(integrationLinkResponseDataSyncDataSyncRevisionMarketplaceData) { }
#pragma warning restore CS8618

    public IntegrationLinkResponseDataSyncDataSyncRevisionMarketplaceData(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntegrationLinkResponseDataSyncDataSyncRevisionMarketplaceData(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IntegrationLinkResponseDataSyncDataSyncRevisionMarketplaceDataFromRaw.FromRawUnchecked"/>
    public static IntegrationLinkResponseDataSyncDataSyncRevisionMarketplaceData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public IntegrationLinkResponseDataSyncDataSyncRevisionMarketplaceData(string dimensions)
        : this()
    {
        this.Dimensions = dimensions;
    }
}

class IntegrationLinkResponseDataSyncDataSyncRevisionMarketplaceDataFromRaw
    : IFromRawJson<IntegrationLinkResponseDataSyncDataSyncRevisionMarketplaceData>
{
    /// <inheritdoc/>
    public IntegrationLinkResponseDataSyncDataSyncRevisionMarketplaceData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => IntegrationLinkResponseDataSyncDataSyncRevisionMarketplaceData.FromRawUnchecked(rawData);
}
