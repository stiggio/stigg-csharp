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
[JsonConverter(typeof(JsonModelConverter<UsageSyncUsageResponse, UsageSyncUsageResponseFromRaw>))]
public sealed record class UsageSyncUsageResponse : JsonModel
{
    /// <summary>
    /// Result of triggering a subscription usage sync.
    /// </summary>
    public required UsageSyncUsageResponseData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<UsageSyncUsageResponseData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public UsageSyncUsageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UsageSyncUsageResponse(UsageSyncUsageResponse usageSyncUsageResponse)
        : base(usageSyncUsageResponse) { }
#pragma warning restore CS8618

    public UsageSyncUsageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UsageSyncUsageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UsageSyncUsageResponseFromRaw.FromRawUnchecked"/>
    public static UsageSyncUsageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UsageSyncUsageResponse(UsageSyncUsageResponseData data)
        : this()
    {
        this.Data = data;
    }
}

class UsageSyncUsageResponseFromRaw : IFromRawJson<UsageSyncUsageResponse>
{
    /// <inheritdoc/>
    public UsageSyncUsageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UsageSyncUsageResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Result of triggering a subscription usage sync.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<UsageSyncUsageResponseData, UsageSyncUsageResponseDataFromRaw>)
)]
public sealed record class UsageSyncUsageResponseData : JsonModel
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

    public UsageSyncUsageResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UsageSyncUsageResponseData(UsageSyncUsageResponseData usageSyncUsageResponseData)
        : base(usageSyncUsageResponseData) { }
#pragma warning restore CS8618

    public UsageSyncUsageResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UsageSyncUsageResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UsageSyncUsageResponseDataFromRaw.FromRawUnchecked"/>
    public static UsageSyncUsageResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UsageSyncUsageResponseData(bool triggered)
        : this()
    {
        this.Triggered = triggered;
    }
}

class UsageSyncUsageResponseDataFromRaw : IFromRawJson<UsageSyncUsageResponseData>
{
    /// <inheritdoc/>
    public UsageSyncUsageResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UsageSyncUsageResponseData.FromRawUnchecked(rawData);
}
