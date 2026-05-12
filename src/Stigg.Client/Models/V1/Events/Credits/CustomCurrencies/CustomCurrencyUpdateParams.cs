using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;

namespace Stigg.Client.Models.V1.Events.Credits.CustomCurrencies;

/// <summary>
/// Updates an existing custom currency. Only the supplied fields are modified.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CustomCurrencyUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? CurrencyID { get; init; }

    /// <summary>
    /// A human-readable description of the custom currency. Send an empty string
    /// to clear.
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("description");
        }
        init { this._rawBodyData.Set("description", value); }
    }

    /// <summary>
    /// The display name of the custom currency
    /// </summary>
    public string? DisplayName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("displayName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("displayName", value);
        }
    }

    /// <summary>
    /// Additional metadata to attach to the custom currency
    /// </summary>
    public IReadOnlyDictionary<string, string>? Metadata
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            this._rawBodyData.Set<FrozenDictionary<string, string>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// The symbol used to represent the custom currency. Send an empty string to clear.
    /// </summary>
    public string? Symbol
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("symbol");
        }
        init { this._rawBodyData.Set("symbol", value); }
    }

    /// <summary>
    /// Singular and plural unit labels for a custom currency. Both fields are required
    /// when supplied.
    /// </summary>
    public CustomCurrencyUpdateParamsUnits? Units
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<CustomCurrencyUpdateParamsUnits>("units");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("units", value);
        }
    }

    public CustomCurrencyUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomCurrencyUpdateParams(CustomCurrencyUpdateParams customCurrencyUpdateParams)
        : base(customCurrencyUpdateParams)
    {
        this.CurrencyID = customCurrencyUpdateParams.CurrencyID;

        this._rawBodyData = new(customCurrencyUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public CustomCurrencyUpdateParams(
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
    CustomCurrencyUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string currencyID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.CurrencyID = currencyID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static CustomCurrencyUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string currencyID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            currencyID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["CurrencyID"] = JsonSerializer.SerializeToElement(this.CurrencyID),
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

    public virtual bool Equals(CustomCurrencyUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.CurrencyID?.Equals(other.CurrencyID) ?? other.CurrencyID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/api/v1/credits/custom-currencies/{0}", this.CurrencyID)
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
/// Singular and plural unit labels for a custom currency. Both fields are required
/// when supplied.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CustomCurrencyUpdateParamsUnits,
        CustomCurrencyUpdateParamsUnitsFromRaw
    >)
)]
public sealed record class CustomCurrencyUpdateParamsUnits : JsonModel
{
    /// <summary>
    /// Plural form of the unit label
    /// </summary>
    public required string Plural
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("plural");
        }
        init { this._rawData.Set("plural", value); }
    }

    /// <summary>
    /// Singular form of the unit label
    /// </summary>
    public required string Singular
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("singular");
        }
        init { this._rawData.Set("singular", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Plural;
        _ = this.Singular;
    }

    public CustomCurrencyUpdateParamsUnits() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomCurrencyUpdateParamsUnits(
        CustomCurrencyUpdateParamsUnits customCurrencyUpdateParamsUnits
    )
        : base(customCurrencyUpdateParamsUnits) { }
#pragma warning restore CS8618

    public CustomCurrencyUpdateParamsUnits(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomCurrencyUpdateParamsUnits(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomCurrencyUpdateParamsUnitsFromRaw.FromRawUnchecked"/>
    public static CustomCurrencyUpdateParamsUnits FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomCurrencyUpdateParamsUnitsFromRaw : IFromRawJson<CustomCurrencyUpdateParamsUnits>
{
    /// <inheritdoc/>
    public CustomCurrencyUpdateParamsUnits FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomCurrencyUpdateParamsUnits.FromRawUnchecked(rawData);
}
