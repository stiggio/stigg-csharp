using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;

namespace Stigg.Client.Models.V1Beta.Customers.Entities;

/// <summary>
/// Wrapped response echoing the ids that were acted on by an archive/unarchive call
/// </summary>
[JsonConverter(typeof(JsonModelConverter<EntityArchiveResponse, EntityArchiveResponseFromRaw>))]
public sealed record class EntityArchiveResponse : JsonModel
{
    /// <summary>
    /// List of entity identifiers that were acted on
    /// </summary>
    public required EntityArchiveResponseData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EntityArchiveResponseData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public EntityArchiveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityArchiveResponse(EntityArchiveResponse entityArchiveResponse)
        : base(entityArchiveResponse) { }
#pragma warning restore CS8618

    public EntityArchiveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityArchiveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityArchiveResponseFromRaw.FromRawUnchecked"/>
    public static EntityArchiveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EntityArchiveResponse(EntityArchiveResponseData data)
        : this()
    {
        this.Data = data;
    }
}

class EntityArchiveResponseFromRaw : IFromRawJson<EntityArchiveResponse>
{
    /// <inheritdoc/>
    public EntityArchiveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityArchiveResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// List of entity identifiers that were acted on
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<EntityArchiveResponseData, EntityArchiveResponseDataFromRaw>)
)]
public sealed record class EntityArchiveResponseData : JsonModel
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

    public EntityArchiveResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityArchiveResponseData(EntityArchiveResponseData entityArchiveResponseData)
        : base(entityArchiveResponseData) { }
#pragma warning restore CS8618

    public EntityArchiveResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityArchiveResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityArchiveResponseDataFromRaw.FromRawUnchecked"/>
    public static EntityArchiveResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EntityArchiveResponseData(IReadOnlyList<string> ids)
        : this()
    {
        this.Ids = ids;
    }
}

class EntityArchiveResponseDataFromRaw : IFromRawJson<EntityArchiveResponseData>
{
    /// <inheritdoc/>
    public EntityArchiveResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityArchiveResponseData.FromRawUnchecked(rawData);
}
