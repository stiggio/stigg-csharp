using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using System = System;

namespace Stigg.Client.Models.V1.Customers.Integrations;

/// <summary>
/// Links a customer to an external integration by specifying the vendor and external
/// entity ID.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class IntegrationLinkParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

    /// <summary>
    /// Integration details
    /// </summary>
    public required string IDValue
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("id");
        }
        init { this._rawBodyData.Set("id", value); }
    }

    /// <summary>
    /// Synced entity id
    /// </summary>
    public required string SyncedEntityID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("syncedEntityId");
        }
        init { this._rawBodyData.Set("syncedEntityId", value); }
    }

    /// <summary>
    /// The vendor identifier of integration
    /// </summary>
    public required ApiEnum<string, IntegrationLinkParamsVendorIdentifier> VendorIdentifier
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<
                ApiEnum<string, IntegrationLinkParamsVendorIdentifier>
            >("vendorIdentifier");
        }
        init { this._rawBodyData.Set("vendorIdentifier", value); }
    }

    public IntegrationLinkParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IntegrationLinkParams(IntegrationLinkParams integrationLinkParams)
        : base(integrationLinkParams)
    {
        this.ID = integrationLinkParams.ID;

        this._rawBodyData = new(integrationLinkParams._rawBodyData);
    }
#pragma warning restore CS8618

    public IntegrationLinkParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntegrationLinkParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string id
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.ID = id;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static IntegrationLinkParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string id
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            id
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["ID"] = JsonSerializer.SerializeToElement(this.ID),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(IntegrationLinkParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ID?.Equals(other.ID) ?? other.ID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/api/v1/customers/{0}/integrations", this.ID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

/// <summary>
/// The vendor identifier of integration
/// </summary>
[JsonConverter(typeof(IntegrationLinkParamsVendorIdentifierConverter))]
public enum IntegrationLinkParamsVendorIdentifier
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
}

sealed class IntegrationLinkParamsVendorIdentifierConverter
    : JsonConverter<IntegrationLinkParamsVendorIdentifier>
{
    public override IntegrationLinkParamsVendorIdentifier Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "AUTH0" => IntegrationLinkParamsVendorIdentifier.Auth0,
            "ZUORA" => IntegrationLinkParamsVendorIdentifier.Zuora,
            "STRIPE" => IntegrationLinkParamsVendorIdentifier.Stripe,
            "HUBSPOT" => IntegrationLinkParamsVendorIdentifier.Hubspot,
            "AWS_MARKETPLACE" => IntegrationLinkParamsVendorIdentifier.AwsMarketplace,
            "SNOWFLAKE" => IntegrationLinkParamsVendorIdentifier.Snowflake,
            "SALESFORCE" => IntegrationLinkParamsVendorIdentifier.Salesforce,
            "BIG_QUERY" => IntegrationLinkParamsVendorIdentifier.BigQuery,
            "OPEN_FGA" => IntegrationLinkParamsVendorIdentifier.OpenFga,
            "APP_STORE" => IntegrationLinkParamsVendorIdentifier.AppStore,
            "RECEIVED" => IntegrationLinkParamsVendorIdentifier.Received,
            "PREQUEL" => IntegrationLinkParamsVendorIdentifier.Prequel,
            _ => (IntegrationLinkParamsVendorIdentifier)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        IntegrationLinkParamsVendorIdentifier value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                IntegrationLinkParamsVendorIdentifier.Auth0 => "AUTH0",
                IntegrationLinkParamsVendorIdentifier.Zuora => "ZUORA",
                IntegrationLinkParamsVendorIdentifier.Stripe => "STRIPE",
                IntegrationLinkParamsVendorIdentifier.Hubspot => "HUBSPOT",
                IntegrationLinkParamsVendorIdentifier.AwsMarketplace => "AWS_MARKETPLACE",
                IntegrationLinkParamsVendorIdentifier.Snowflake => "SNOWFLAKE",
                IntegrationLinkParamsVendorIdentifier.Salesforce => "SALESFORCE",
                IntegrationLinkParamsVendorIdentifier.BigQuery => "BIG_QUERY",
                IntegrationLinkParamsVendorIdentifier.OpenFga => "OPEN_FGA",
                IntegrationLinkParamsVendorIdentifier.AppStore => "APP_STORE",
                IntegrationLinkParamsVendorIdentifier.Received => "RECEIVED",
                IntegrationLinkParamsVendorIdentifier.Prequel => "PREQUEL",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
