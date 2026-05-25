using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;

namespace Stigg.Client.Models.V1Beta.Entities;

/// <summary>
/// Wrapped response echoing the ids that were acted on by an archive/unarchive call
/// </summary>
[JsonConverter(typeof(JsonModelConverter<EntityUnarchiveResponse, EntityUnarchiveResponseFromRaw>))]
public sealed record class EntityUnarchiveResponse : JsonModel
{
    /// <summary>
    /// List of entity identifiers that were acted on
    /// </summary>
    public required EntityUnarchiveResponseData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EntityUnarchiveResponseData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public EntityUnarchiveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityUnarchiveResponse(EntityUnarchiveResponse entityUnarchiveResponse)
        : base(entityUnarchiveResponse) { }
#pragma warning restore CS8618

    public EntityUnarchiveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityUnarchiveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityUnarchiveResponseFromRaw.FromRawUnchecked"/>
    public static EntityUnarchiveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EntityUnarchiveResponse(EntityUnarchiveResponseData data)
        : this()
    {
        this.Data = data;
    }
}

class EntityUnarchiveResponseFromRaw : IFromRawJson<EntityUnarchiveResponse>
{
    /// <inheritdoc/>
    public EntityUnarchiveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityUnarchiveResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// List of entity identifiers that were acted on
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<EntityUnarchiveResponseData, EntityUnarchiveResponseDataFromRaw>)
)]
public sealed record class EntityUnarchiveResponseData : JsonModel
{
    /// <summary>
    /// Entity identifiers to act on
    /// </summary>
    public required IReadOnlyList<string> Ids
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("ids");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "ids",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Ids;
    }

    public EntityUnarchiveResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityUnarchiveResponseData(EntityUnarchiveResponseData entityUnarchiveResponseData)
        : base(entityUnarchiveResponseData) { }
#pragma warning restore CS8618

    public EntityUnarchiveResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityUnarchiveResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityUnarchiveResponseDataFromRaw.FromRawUnchecked"/>
    public static EntityUnarchiveResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EntityUnarchiveResponseData(IReadOnlyList<string> ids)
        : this()
    {
        this.Ids = ids;
    }
}

class EntityUnarchiveResponseDataFromRaw : IFromRawJson<EntityUnarchiveResponseData>
{
    /// <inheritdoc/>
    public EntityUnarchiveResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityUnarchiveResponseData.FromRawUnchecked(rawData);
}
