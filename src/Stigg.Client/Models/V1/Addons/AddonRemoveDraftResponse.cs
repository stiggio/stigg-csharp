using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;

namespace Stigg.Client.Models.V1.Addons;

/// <summary>
/// Response confirming the addon draft was removed.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<AddonRemoveDraftResponse, AddonRemoveDraftResponseFromRaw>)
)]
public sealed record class AddonRemoveDraftResponse : JsonModel
{
    public required AddonRemoveDraftResponseData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AddonRemoveDraftResponseData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public AddonRemoveDraftResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AddonRemoveDraftResponse(AddonRemoveDraftResponse addonRemoveDraftResponse)
        : base(addonRemoveDraftResponse) { }
#pragma warning restore CS8618

    public AddonRemoveDraftResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddonRemoveDraftResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AddonRemoveDraftResponseFromRaw.FromRawUnchecked"/>
    public static AddonRemoveDraftResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AddonRemoveDraftResponse(AddonRemoveDraftResponseData data)
        : this()
    {
        this.Data = data;
    }
}

class AddonRemoveDraftResponseFromRaw : IFromRawJson<AddonRemoveDraftResponse>
{
    /// <inheritdoc/>
    public AddonRemoveDraftResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AddonRemoveDraftResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<AddonRemoveDraftResponseData, AddonRemoveDraftResponseDataFromRaw>)
)]
public sealed record class AddonRemoveDraftResponseData : JsonModel
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

    public AddonRemoveDraftResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AddonRemoveDraftResponseData(AddonRemoveDraftResponseData addonRemoveDraftResponseData)
        : base(addonRemoveDraftResponseData) { }
#pragma warning restore CS8618

    public AddonRemoveDraftResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddonRemoveDraftResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AddonRemoveDraftResponseDataFromRaw.FromRawUnchecked"/>
    public static AddonRemoveDraftResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AddonRemoveDraftResponseData(string id)
        : this()
    {
        this.ID = id;
    }
}

class AddonRemoveDraftResponseDataFromRaw : IFromRawJson<AddonRemoveDraftResponseData>
{
    /// <inheritdoc/>
    public AddonRemoveDraftResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AddonRemoveDraftResponseData.FromRawUnchecked(rawData);
}
