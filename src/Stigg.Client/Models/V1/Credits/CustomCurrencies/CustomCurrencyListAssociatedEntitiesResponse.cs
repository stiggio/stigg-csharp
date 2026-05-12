using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;

namespace Stigg.Client.Models.V1.Credits.CustomCurrencies;

/// <summary>
/// List of entities (plans or addons) that reference a custom currency
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CustomCurrencyListAssociatedEntitiesResponse,
        CustomCurrencyListAssociatedEntitiesResponseFromRaw
    >)
)]
public sealed record class CustomCurrencyListAssociatedEntitiesResponse : JsonModel
{
    public required IReadOnlyList<CustomCurrencyListAssociatedEntitiesResponseData> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<CustomCurrencyListAssociatedEntitiesResponseData>
            >("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<CustomCurrencyListAssociatedEntitiesResponseData>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
    }

    public CustomCurrencyListAssociatedEntitiesResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomCurrencyListAssociatedEntitiesResponse(
        CustomCurrencyListAssociatedEntitiesResponse customCurrencyListAssociatedEntitiesResponse
    )
        : base(customCurrencyListAssociatedEntitiesResponse) { }
#pragma warning restore CS8618

    public CustomCurrencyListAssociatedEntitiesResponse(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomCurrencyListAssociatedEntitiesResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomCurrencyListAssociatedEntitiesResponseFromRaw.FromRawUnchecked"/>
    public static CustomCurrencyListAssociatedEntitiesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CustomCurrencyListAssociatedEntitiesResponse(
        IReadOnlyList<CustomCurrencyListAssociatedEntitiesResponseData> data
    )
        : this()
    {
        this.Data = data;
    }
}

class CustomCurrencyListAssociatedEntitiesResponseFromRaw
    : IFromRawJson<CustomCurrencyListAssociatedEntitiesResponse>
{
    /// <inheritdoc/>
    public CustomCurrencyListAssociatedEntitiesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomCurrencyListAssociatedEntitiesResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// An entity (plan or addon) that references a custom currency
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CustomCurrencyListAssociatedEntitiesResponseData,
        CustomCurrencyListAssociatedEntitiesResponseDataFromRaw
    >)
)]
public sealed record class CustomCurrencyListAssociatedEntitiesResponseData : JsonModel
{
    /// <summary>
    /// The reference ID of the associated entity
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
    /// The display name of the associated entity
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
    /// The kind of entity referencing the currency (e.g., Plan)
    /// </summary>
    public required string Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.DisplayName;
        _ = this.Type;
    }

    public CustomCurrencyListAssociatedEntitiesResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomCurrencyListAssociatedEntitiesResponseData(
        CustomCurrencyListAssociatedEntitiesResponseData customCurrencyListAssociatedEntitiesResponseData
    )
        : base(customCurrencyListAssociatedEntitiesResponseData) { }
#pragma warning restore CS8618

    public CustomCurrencyListAssociatedEntitiesResponseData(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomCurrencyListAssociatedEntitiesResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomCurrencyListAssociatedEntitiesResponseDataFromRaw.FromRawUnchecked"/>
    public static CustomCurrencyListAssociatedEntitiesResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomCurrencyListAssociatedEntitiesResponseDataFromRaw
    : IFromRawJson<CustomCurrencyListAssociatedEntitiesResponseData>
{
    /// <inheritdoc/>
    public CustomCurrencyListAssociatedEntitiesResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomCurrencyListAssociatedEntitiesResponseData.FromRawUnchecked(rawData);
}
