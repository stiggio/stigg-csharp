using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;

namespace Stigg.Client.Models.V1.Events.Credits.CustomCurrencies;

/// <summary>
/// Response object
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CustomCurrencyUnarchiveResponse,
        CustomCurrencyUnarchiveResponseFromRaw
    >)
)]
public sealed record class CustomCurrencyUnarchiveResponse : JsonModel
{
    /// <summary>
    /// A custom currency used to denominate credit-based entitlements and pricing
    /// </summary>
    public required CustomCurrencyUnarchiveResponseData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CustomCurrencyUnarchiveResponseData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public CustomCurrencyUnarchiveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomCurrencyUnarchiveResponse(
        CustomCurrencyUnarchiveResponse customCurrencyUnarchiveResponse
    )
        : base(customCurrencyUnarchiveResponse) { }
#pragma warning restore CS8618

    public CustomCurrencyUnarchiveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomCurrencyUnarchiveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomCurrencyUnarchiveResponseFromRaw.FromRawUnchecked"/>
    public static CustomCurrencyUnarchiveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CustomCurrencyUnarchiveResponse(CustomCurrencyUnarchiveResponseData data)
        : this()
    {
        this.Data = data;
    }
}

class CustomCurrencyUnarchiveResponseFromRaw : IFromRawJson<CustomCurrencyUnarchiveResponse>
{
    /// <inheritdoc/>
    public CustomCurrencyUnarchiveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomCurrencyUnarchiveResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// A custom currency used to denominate credit-based entitlements and pricing
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CustomCurrencyUnarchiveResponseData,
        CustomCurrencyUnarchiveResponseDataFromRaw
    >)
)]
public sealed record class CustomCurrencyUnarchiveResponseData : JsonModel
{
    /// <summary>
    /// The unique identifier for the custom currency
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
    public required DateTimeOffset? ArchivedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("archivedAt");
        }
        init { this._rawData.Set("archivedAt", value); }
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
    /// Description of the currency
    /// </summary>
    public required string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// The display name of the custom currency
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
    /// The symbol used to represent the custom currency
    /// </summary>
    public required string? Symbol
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("symbol");
        }
        init { this._rawData.Set("symbol", value); }
    }

    /// <summary>
    /// Singular and plural unit labels for a custom currency
    /// </summary>
    public required CustomCurrencyUnarchiveResponseDataUnits? Units
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CustomCurrencyUnarchiveResponseDataUnits>(
                "units"
            );
        }
        init { this._rawData.Set("units", value); }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ArchivedAt;
        _ = this.CreatedAt;
        _ = this.Description;
        _ = this.DisplayName;
        _ = this.Metadata;
        _ = this.Symbol;
        this.Units?.Validate();
        _ = this.UpdatedAt;
    }

    public CustomCurrencyUnarchiveResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomCurrencyUnarchiveResponseData(
        CustomCurrencyUnarchiveResponseData customCurrencyUnarchiveResponseData
    )
        : base(customCurrencyUnarchiveResponseData) { }
#pragma warning restore CS8618

    public CustomCurrencyUnarchiveResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomCurrencyUnarchiveResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomCurrencyUnarchiveResponseDataFromRaw.FromRawUnchecked"/>
    public static CustomCurrencyUnarchiveResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomCurrencyUnarchiveResponseDataFromRaw : IFromRawJson<CustomCurrencyUnarchiveResponseData>
{
    /// <inheritdoc/>
    public CustomCurrencyUnarchiveResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomCurrencyUnarchiveResponseData.FromRawUnchecked(rawData);
}

/// <summary>
/// Singular and plural unit labels for a custom currency
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CustomCurrencyUnarchiveResponseDataUnits,
        CustomCurrencyUnarchiveResponseDataUnitsFromRaw
    >)
)]
public sealed record class CustomCurrencyUnarchiveResponseDataUnits : JsonModel
{
    /// <summary>
    /// Plural form of the unit label
    /// </summary>
    public required string? Plural
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("plural");
        }
        init { this._rawData.Set("plural", value); }
    }

    /// <summary>
    /// Singular form of the unit label
    /// </summary>
    public required string? Singular
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("singular");
        }
        init { this._rawData.Set("singular", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Plural;
        _ = this.Singular;
    }

    public CustomCurrencyUnarchiveResponseDataUnits() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomCurrencyUnarchiveResponseDataUnits(
        CustomCurrencyUnarchiveResponseDataUnits customCurrencyUnarchiveResponseDataUnits
    )
        : base(customCurrencyUnarchiveResponseDataUnits) { }
#pragma warning restore CS8618

    public CustomCurrencyUnarchiveResponseDataUnits(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomCurrencyUnarchiveResponseDataUnits(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomCurrencyUnarchiveResponseDataUnitsFromRaw.FromRawUnchecked"/>
    public static CustomCurrencyUnarchiveResponseDataUnits FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomCurrencyUnarchiveResponseDataUnitsFromRaw
    : IFromRawJson<CustomCurrencyUnarchiveResponseDataUnits>
{
    /// <inheritdoc/>
    public CustomCurrencyUnarchiveResponseDataUnits FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomCurrencyUnarchiveResponseDataUnits.FromRawUnchecked(rawData);
}
