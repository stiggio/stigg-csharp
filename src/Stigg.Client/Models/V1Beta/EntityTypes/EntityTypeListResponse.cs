using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;

namespace Stigg.Client.Models.V1Beta.EntityTypes;

/// <summary>
/// A vendor-defined category of resource that can be governed (e.g. Org, Team, User).
/// Vendors define entity types once per environment; their customers create instances
/// (entities) of these types and the governance engine tracks usage and enforces
/// limits per instance.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<EntityTypeListResponse, EntityTypeListResponseFromRaw>))]
public sealed record class EntityTypeListResponse : JsonModel
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
    /// Dimension keys used to attribute usage events to instances of this type (e.g.
    /// ["orgId"]). Empty array means no attribution.
    /// </summary>
    public required IReadOnlyList<string> AttributionKeys
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("attributionKeys");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "attributionKeys",
                ImmutableArray.ToImmutableArray(value)
            );
        }
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
    /// What this entity type represents and what it is for governing, or null when
    /// none is set
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
    /// The display name for the entity type
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
        _ = this.AttributionKeys;
        _ = this.CreatedAt;
        _ = this.Description;
        _ = this.DisplayName;
        _ = this.UpdatedAt;
    }

    public EntityTypeListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityTypeListResponse(EntityTypeListResponse entityTypeListResponse)
        : base(entityTypeListResponse) { }
#pragma warning restore CS8618

    public EntityTypeListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityTypeListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityTypeListResponseFromRaw.FromRawUnchecked"/>
    public static EntityTypeListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityTypeListResponseFromRaw : IFromRawJson<EntityTypeListResponse>
{
    /// <inheritdoc/>
    public EntityTypeListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityTypeListResponse.FromRawUnchecked(rawData);
}
