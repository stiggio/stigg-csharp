using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;

namespace Stigg.Client.Models.V1.Events.Plans;

/// <summary>
/// Response containing task ID for publish operation
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PlanPublishResponse, PlanPublishResponseFromRaw>))]
public sealed record class PlanPublishResponse : JsonModel
{
    public required PlanPublishResponseData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PlanPublishResponseData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public PlanPublishResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlanPublishResponse(PlanPublishResponse planPublishResponse)
        : base(planPublishResponse) { }
#pragma warning restore CS8618

    public PlanPublishResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlanPublishResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlanPublishResponseFromRaw.FromRawUnchecked"/>
    public static PlanPublishResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PlanPublishResponse(PlanPublishResponseData data)
        : this()
    {
        this.Data = data;
    }
}

class PlanPublishResponseFromRaw : IFromRawJson<PlanPublishResponse>
{
    /// <inheritdoc/>
    public PlanPublishResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PlanPublishResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<PlanPublishResponseData, PlanPublishResponseDataFromRaw>))]
public sealed record class PlanPublishResponseData : JsonModel
{
    /// <summary>
    /// Task ID for tracking the async publish operation
    /// </summary>
    public required string? TaskID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("taskId");
        }
        init { this._rawData.Set("taskId", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.TaskID;
    }

    public PlanPublishResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlanPublishResponseData(PlanPublishResponseData planPublishResponseData)
        : base(planPublishResponseData) { }
#pragma warning restore CS8618

    public PlanPublishResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlanPublishResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlanPublishResponseDataFromRaw.FromRawUnchecked"/>
    public static PlanPublishResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PlanPublishResponseData(string? taskID)
        : this()
    {
        this.TaskID = taskID;
    }
}

class PlanPublishResponseDataFromRaw : IFromRawJson<PlanPublishResponseData>
{
    /// <inheritdoc/>
    public PlanPublishResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlanPublishResponseData.FromRawUnchecked(rawData);
}
