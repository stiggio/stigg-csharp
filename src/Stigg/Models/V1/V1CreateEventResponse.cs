using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Core;

namespace Stigg.Models.V1;

[JsonConverter(typeof(JsonModelConverter<V1CreateEventResponse, V1CreateEventResponseFromRaw>))]
public sealed record class V1CreateEventResponse : JsonModel
{
    public required JsonElement Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Data;
    }

    public V1CreateEventResponse() { }

    public V1CreateEventResponse(V1CreateEventResponse v1CreateEventResponse)
        : base(v1CreateEventResponse) { }

    public V1CreateEventResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V1CreateEventResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="V1CreateEventResponseFromRaw.FromRawUnchecked"/>
    public static V1CreateEventResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public V1CreateEventResponse(JsonElement data)
        : this()
    {
        this.Data = data;
    }
}

class V1CreateEventResponseFromRaw : IFromRawJson<V1CreateEventResponse>
{
    /// <inheritdoc/>
    public V1CreateEventResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => V1CreateEventResponse.FromRawUnchecked(rawData);
}
