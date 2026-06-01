using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;

namespace Stigg.Client.Models.V1.Plans;

/// <summary>
/// Response confirming the plan draft was removed.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PlanRemoveDraftResponse, PlanRemoveDraftResponseFromRaw>))]
public sealed record class PlanRemoveDraftResponse : JsonModel
{
    public required PlanRemoveDraftResponseData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PlanRemoveDraftResponseData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public PlanRemoveDraftResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlanRemoveDraftResponse(PlanRemoveDraftResponse planRemoveDraftResponse)
        : base(planRemoveDraftResponse) { }
#pragma warning restore CS8618

    public PlanRemoveDraftResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlanRemoveDraftResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlanRemoveDraftResponseFromRaw.FromRawUnchecked"/>
    public static PlanRemoveDraftResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PlanRemoveDraftResponse(PlanRemoveDraftResponseData data)
        : this()
    {
        this.Data = data;
    }
}

class PlanRemoveDraftResponseFromRaw : IFromRawJson<PlanRemoveDraftResponse>
{
    /// <inheritdoc/>
    public PlanRemoveDraftResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlanRemoveDraftResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<PlanRemoveDraftResponseData, PlanRemoveDraftResponseDataFromRaw>)
)]
public sealed record class PlanRemoveDraftResponseData : JsonModel
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
    }

    public PlanRemoveDraftResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlanRemoveDraftResponseData(PlanRemoveDraftResponseData planRemoveDraftResponseData)
        : base(planRemoveDraftResponseData) { }
#pragma warning restore CS8618

    public PlanRemoveDraftResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlanRemoveDraftResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlanRemoveDraftResponseDataFromRaw.FromRawUnchecked"/>
    public static PlanRemoveDraftResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PlanRemoveDraftResponseData(string id)
        : this()
    {
        this.ID = id;
    }
}

class PlanRemoveDraftResponseDataFromRaw : IFromRawJson<PlanRemoveDraftResponseData>
{
    /// <inheritdoc/>
    public PlanRemoveDraftResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlanRemoveDraftResponseData.FromRawUnchecked(rawData);
}
