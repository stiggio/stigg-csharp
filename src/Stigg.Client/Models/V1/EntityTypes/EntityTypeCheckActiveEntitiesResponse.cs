using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;

namespace Stigg.Client.Models.V1.EntityTypes;

/// <summary>
/// Wrapped response with whether an entity type has active entities
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        EntityTypeCheckActiveEntitiesResponse,
        EntityTypeCheckActiveEntitiesResponseFromRaw
    >)
)]
public sealed record class EntityTypeCheckActiveEntitiesResponse : JsonModel
{
    /// <summary>
    /// Whether an entity type has active entities
    /// </summary>
    public required EntityTypeCheckActiveEntitiesResponseData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EntityTypeCheckActiveEntitiesResponseData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public EntityTypeCheckActiveEntitiesResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityTypeCheckActiveEntitiesResponse(
        EntityTypeCheckActiveEntitiesResponse entityTypeCheckActiveEntitiesResponse
    )
        : base(entityTypeCheckActiveEntitiesResponse) { }
#pragma warning restore CS8618

    public EntityTypeCheckActiveEntitiesResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityTypeCheckActiveEntitiesResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityTypeCheckActiveEntitiesResponseFromRaw.FromRawUnchecked"/>
    public static EntityTypeCheckActiveEntitiesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EntityTypeCheckActiveEntitiesResponse(EntityTypeCheckActiveEntitiesResponseData data)
        : this()
    {
        this.Data = data;
    }
}

class EntityTypeCheckActiveEntitiesResponseFromRaw
    : IFromRawJson<EntityTypeCheckActiveEntitiesResponse>
{
    /// <inheritdoc/>
    public EntityTypeCheckActiveEntitiesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityTypeCheckActiveEntitiesResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Whether an entity type has active entities
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        EntityTypeCheckActiveEntitiesResponseData,
        EntityTypeCheckActiveEntitiesResponseDataFromRaw
    >)
)]
public sealed record class EntityTypeCheckActiveEntitiesResponseData : JsonModel
{
    /// <summary>
    /// Whether at least one active (non-archived) entity of the entity type exists,
    /// across every customer
    /// </summary>
    public required bool HasActiveEntities
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("hasActiveEntities");
        }
        init { this._rawData.Set("hasActiveEntities", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.HasActiveEntities;
    }

    public EntityTypeCheckActiveEntitiesResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityTypeCheckActiveEntitiesResponseData(
        EntityTypeCheckActiveEntitiesResponseData entityTypeCheckActiveEntitiesResponseData
    )
        : base(entityTypeCheckActiveEntitiesResponseData) { }
#pragma warning restore CS8618

    public EntityTypeCheckActiveEntitiesResponseData(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityTypeCheckActiveEntitiesResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityTypeCheckActiveEntitiesResponseDataFromRaw.FromRawUnchecked"/>
    public static EntityTypeCheckActiveEntitiesResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EntityTypeCheckActiveEntitiesResponseData(bool hasActiveEntities)
        : this()
    {
        this.HasActiveEntities = hasActiveEntities;
    }
}

class EntityTypeCheckActiveEntitiesResponseDataFromRaw
    : IFromRawJson<EntityTypeCheckActiveEntitiesResponseData>
{
    /// <inheritdoc/>
    public EntityTypeCheckActiveEntitiesResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityTypeCheckActiveEntitiesResponseData.FromRawUnchecked(rawData);
}
