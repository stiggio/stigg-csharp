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
[JsonConverter(
    typeof(JsonModelConverter<EntityIdsActionResponseDto, EntityIdsActionResponseDtoFromRaw>)
)]
public sealed record class EntityIdsActionResponseDto : JsonModel
{
    /// <summary>
    /// List of entity identifiers that were acted on
    /// </summary>
    public required Data Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Data>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public EntityIdsActionResponseDto() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityIdsActionResponseDto(EntityIdsActionResponseDto entityIdsActionResponseDto)
        : base(entityIdsActionResponseDto) { }
#pragma warning restore CS8618

    public EntityIdsActionResponseDto(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityIdsActionResponseDto(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityIdsActionResponseDtoFromRaw.FromRawUnchecked"/>
    public static EntityIdsActionResponseDto FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EntityIdsActionResponseDto(Data data)
        : this()
    {
        this.Data = data;
    }
}

class EntityIdsActionResponseDtoFromRaw : IFromRawJson<EntityIdsActionResponseDto>
{
    /// <inheritdoc/>
    public EntityIdsActionResponseDto FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntityIdsActionResponseDto.FromRawUnchecked(rawData);
}

/// <summary>
/// List of entity identifiers that were acted on
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
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

    public Data() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Data(Data data)
        : base(data) { }
#pragma warning restore CS8618

    public Data(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Data(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataFromRaw.FromRawUnchecked"/>
    public static Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Data(IReadOnlyList<string> ids)
        : this()
    {
        this.Ids = ids;
    }
}

class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Data.FromRawUnchecked(rawData);
}
