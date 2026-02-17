using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;

namespace Stigg.Client.Models.V1.Events.Addons.Draft;

/// <summary>
/// Response confirming the addon draft was removed.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<DraftRemoveAddonDraftResponse, DraftRemoveAddonDraftResponseFromRaw>)
)]
public sealed record class DraftRemoveAddonDraftResponse : JsonModel
{
    public required DraftRemoveAddonDraftResponseData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<DraftRemoveAddonDraftResponseData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public DraftRemoveAddonDraftResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DraftRemoveAddonDraftResponse(
        DraftRemoveAddonDraftResponse draftRemoveAddonDraftResponse
    )
        : base(draftRemoveAddonDraftResponse) { }
#pragma warning restore CS8618

    public DraftRemoveAddonDraftResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DraftRemoveAddonDraftResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DraftRemoveAddonDraftResponseFromRaw.FromRawUnchecked"/>
    public static DraftRemoveAddonDraftResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public DraftRemoveAddonDraftResponse(DraftRemoveAddonDraftResponseData data)
        : this()
    {
        this.Data = data;
    }
}

class DraftRemoveAddonDraftResponseFromRaw : IFromRawJson<DraftRemoveAddonDraftResponse>
{
    /// <inheritdoc/>
    public DraftRemoveAddonDraftResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DraftRemoveAddonDraftResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        DraftRemoveAddonDraftResponseData,
        DraftRemoveAddonDraftResponseDataFromRaw
    >)
)]
public sealed record class DraftRemoveAddonDraftResponseData : JsonModel
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

    public DraftRemoveAddonDraftResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DraftRemoveAddonDraftResponseData(
        DraftRemoveAddonDraftResponseData draftRemoveAddonDraftResponseData
    )
        : base(draftRemoveAddonDraftResponseData) { }
#pragma warning restore CS8618

    public DraftRemoveAddonDraftResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DraftRemoveAddonDraftResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DraftRemoveAddonDraftResponseDataFromRaw.FromRawUnchecked"/>
    public static DraftRemoveAddonDraftResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public DraftRemoveAddonDraftResponseData(string id)
        : this()
    {
        this.ID = id;
    }
}

class DraftRemoveAddonDraftResponseDataFromRaw : IFromRawJson<DraftRemoveAddonDraftResponseData>
{
    /// <inheritdoc/>
    public DraftRemoveAddonDraftResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DraftRemoveAddonDraftResponseData.FromRawUnchecked(rawData);
}
