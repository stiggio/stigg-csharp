using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;

namespace Stigg.Client.Models.V1Beta.Customers.Entities;

/// <summary>
/// List of entity identifiers to act on in bulk (1-100 entries)
/// </summary>
[JsonConverter(typeof(JsonModelConverter<EntityIdsRequestDto, EntityIdsRequestDtoFromRaw>))]
public sealed record class EntityIdsRequestDto : JsonModel
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

    public EntityIdsRequestDto() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityIdsRequestDto(EntityIdsRequestDto entityIdsRequestDto)
        : base(entityIdsRequestDto) { }
#pragma warning restore CS8618

    public EntityIdsRequestDto(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityIdsRequestDto(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityIdsRequestDtoFromRaw.FromRawUnchecked"/>
    public static EntityIdsRequestDto FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EntityIdsRequestDto(IReadOnlyList<string> ids)
        : this()
    {
        this.Ids = ids;
    }
}

class EntityIdsRequestDtoFromRaw : IFromRawJson<EntityIdsRequestDto>
{
    /// <inheritdoc/>
    public EntityIdsRequestDto FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        EntityIdsRequestDto.FromRawUnchecked(rawData);
}
