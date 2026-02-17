using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;

namespace Stigg.Client.Models.V1.Events.Addons;

/// <summary>
/// Response containing task ID for publish operation
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<AddonPublishAddonResponse, AddonPublishAddonResponseFromRaw>)
)]
public sealed record class AddonPublishAddonResponse : JsonModel
{
    public required AddonPublishAddonResponseData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AddonPublishAddonResponseData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public AddonPublishAddonResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AddonPublishAddonResponse(AddonPublishAddonResponse addonPublishAddonResponse)
        : base(addonPublishAddonResponse) { }
#pragma warning restore CS8618

    public AddonPublishAddonResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddonPublishAddonResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AddonPublishAddonResponseFromRaw.FromRawUnchecked"/>
    public static AddonPublishAddonResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AddonPublishAddonResponse(AddonPublishAddonResponseData data)
        : this()
    {
        this.Data = data;
    }
}

class AddonPublishAddonResponseFromRaw : IFromRawJson<AddonPublishAddonResponse>
{
    /// <inheritdoc/>
    public AddonPublishAddonResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AddonPublishAddonResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<AddonPublishAddonResponseData, AddonPublishAddonResponseDataFromRaw>)
)]
public sealed record class AddonPublishAddonResponseData : JsonModel
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

    public AddonPublishAddonResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AddonPublishAddonResponseData(
        AddonPublishAddonResponseData addonPublishAddonResponseData
    )
        : base(addonPublishAddonResponseData) { }
#pragma warning restore CS8618

    public AddonPublishAddonResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddonPublishAddonResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AddonPublishAddonResponseDataFromRaw.FromRawUnchecked"/>
    public static AddonPublishAddonResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AddonPublishAddonResponseData(string? taskID)
        : this()
    {
        this.TaskID = taskID;
    }
}

class AddonPublishAddonResponseDataFromRaw : IFromRawJson<AddonPublishAddonResponseData>
{
    /// <inheritdoc/>
    public AddonPublishAddonResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AddonPublishAddonResponseData.FromRawUnchecked(rawData);
}
