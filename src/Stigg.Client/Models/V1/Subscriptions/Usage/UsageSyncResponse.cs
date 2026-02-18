using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;

namespace Stigg.Client.Models.V1.Subscriptions.Usage;

/// <summary>
/// Response object
/// </summary>
[JsonConverter(typeof(JsonModelConverter<UsageSyncResponse, UsageSyncResponseFromRaw>))]
public sealed record class UsageSyncResponse : JsonModel
{
    /// <summary>
    /// Result of triggering a subscription usage sync.
    /// </summary>
    public required UsageSyncResponseData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<UsageSyncResponseData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public UsageSyncResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UsageSyncResponse(UsageSyncResponse usageSyncResponse)
        : base(usageSyncResponse) { }
#pragma warning restore CS8618

    public UsageSyncResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UsageSyncResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UsageSyncResponseFromRaw.FromRawUnchecked"/>
    public static UsageSyncResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UsageSyncResponse(UsageSyncResponseData data)
        : this()
    {
        this.Data = data;
    }
}

class UsageSyncResponseFromRaw : IFromRawJson<UsageSyncResponse>
{
    /// <inheritdoc/>
    public UsageSyncResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UsageSyncResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Result of triggering a subscription usage sync.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<UsageSyncResponseData, UsageSyncResponseDataFromRaw>))]
public sealed record class UsageSyncResponseData : JsonModel
{
    /// <summary>
    /// Whether usage was synced to the billing provider
    /// </summary>
    public required bool Triggered
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("triggered");
        }
        init { this._rawData.Set("triggered", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Triggered;
    }

    public UsageSyncResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UsageSyncResponseData(UsageSyncResponseData usageSyncResponseData)
        : base(usageSyncResponseData) { }
#pragma warning restore CS8618

    public UsageSyncResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UsageSyncResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UsageSyncResponseDataFromRaw.FromRawUnchecked"/>
    public static UsageSyncResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UsageSyncResponseData(bool triggered)
        : this()
    {
        this.Triggered = triggered;
    }
}

class UsageSyncResponseDataFromRaw : IFromRawJson<UsageSyncResponseData>
{
    /// <inheritdoc/>
    public UsageSyncResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UsageSyncResponseData.FromRawUnchecked(rawData);
}
