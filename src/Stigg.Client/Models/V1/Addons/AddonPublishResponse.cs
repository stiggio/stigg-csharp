using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;

namespace Stigg.Client.Models.V1.Addons;

/// <summary>
/// Response containing task ID for publish operation
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AddonPublishResponse, AddonPublishResponseFromRaw>))]
public sealed record class AddonPublishResponse : JsonModel
{
    public required AddonPublishResponseData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AddonPublishResponseData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public AddonPublishResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AddonPublishResponse(AddonPublishResponse addonPublishResponse)
        : base(addonPublishResponse) { }
#pragma warning restore CS8618

    public AddonPublishResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddonPublishResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AddonPublishResponseFromRaw.FromRawUnchecked"/>
    public static AddonPublishResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AddonPublishResponse(AddonPublishResponseData data)
        : this()
    {
        this.Data = data;
    }
}

class AddonPublishResponseFromRaw : IFromRawJson<AddonPublishResponse>
{
    /// <inheritdoc/>
    public AddonPublishResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AddonPublishResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<AddonPublishResponseData, AddonPublishResponseDataFromRaw>)
)]
public sealed record class AddonPublishResponseData : JsonModel
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

    public AddonPublishResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AddonPublishResponseData(AddonPublishResponseData addonPublishResponseData)
        : base(addonPublishResponseData) { }
#pragma warning restore CS8618

    public AddonPublishResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddonPublishResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AddonPublishResponseDataFromRaw.FromRawUnchecked"/>
    public static AddonPublishResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AddonPublishResponseData(string? taskID)
        : this()
    {
        this.TaskID = taskID;
    }
}

class AddonPublishResponseDataFromRaw : IFromRawJson<AddonPublishResponseData>
{
    /// <inheritdoc/>
    public AddonPublishResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AddonPublishResponseData.FromRawUnchecked(rawData);
}
