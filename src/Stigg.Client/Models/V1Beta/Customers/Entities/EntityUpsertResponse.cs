using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;

namespace Stigg.Client.Models.V1Beta.Customers.Entities;

/// <summary>
/// List of entities created or updated by an upsert request
/// </summary>
[JsonConverter(typeof(JsonModelConverter<EntityUpsertResponse, EntityUpsertResponseFromRaw>))]
public sealed record class EntityUpsertResponse : JsonModel
{
    public required IReadOnlyList<EntityUpsertResponseData> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<EntityUpsertResponseData>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<EntityUpsertResponseData>>(
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

    public EntityUpsertResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityUpsertResponse(EntityUpsertResponse entityUpsertResponse)
        : base(entityUpsertResponse) { }
#pragma warning restore CS8618

    public EntityUpsertResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityUpsertResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityUpsertResponseFromRaw.FromRawUnchecked"/>
    public static EntityUpsertResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EntityUpsertResponse(IReadOnlyList<EntityUpsertResponseData> data)
        : this()
    {
        this.Data = data;
    }
}

class EntityUpsertResponseFromRaw : IFromRawJson<EntityUpsertResponse>
{
    /// <inheritdoc/>
    public EntityUpsertResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityUpsertResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// A stored entity instance tracked by the governance service for a given customer
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<EntityUpsertResponseData, EntityUpsertResponseDataFromRaw>)
)]
public sealed record class EntityUpsertResponseData : JsonModel
{
    /// <summary>
    /// The unique identifier for the entity
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
    /// Free-form key/value metadata attached to the entity
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
    /// The entity type identifier this entity instantiates
    /// </summary>
    public required string TypeID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("typeId");
        }
        init { this._rawData.Set("typeId", value); }
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
        _ = this.Metadata;
        _ = this.TypeID;
        _ = this.UpdatedAt;
    }

    public EntityUpsertResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityUpsertResponseData(EntityUpsertResponseData entityUpsertResponseData)
        : base(entityUpsertResponseData) { }
#pragma warning restore CS8618

    public EntityUpsertResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityUpsertResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityUpsertResponseDataFromRaw.FromRawUnchecked"/>
    public static EntityUpsertResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityUpsertResponseDataFromRaw : IFromRawJson<EntityUpsertResponseData>
{
    /// <inheritdoc/>
    public EntityUpsertResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityUpsertResponseData.FromRawUnchecked(rawData);
}
