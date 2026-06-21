using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;

namespace Stigg.Client.Models.V1.Events.DataExport.Destinations;

/// <summary>
/// Response object
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<DestinationCreateResponse, DestinationCreateResponseFromRaw>)
)]
public sealed record class DestinationCreateResponse : JsonModel
{
    /// <summary>
    /// Current destinations under the DATA_EXPORT integration.
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

    public DestinationCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DestinationCreateResponse(DestinationCreateResponse destinationCreateResponse)
        : base(destinationCreateResponse) { }
#pragma warning restore CS8618

    public DestinationCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DestinationCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DestinationCreateResponseFromRaw.FromRawUnchecked"/>
    public static DestinationCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public DestinationCreateResponse(Data data)
        : this()
    {
        this.Data = data;
    }
}

class DestinationCreateResponseFromRaw : IFromRawJson<DestinationCreateResponse>
{
    /// <inheritdoc/>
    public DestinationCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DestinationCreateResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Current destinations under the DATA_EXPORT integration.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// Current destinations under the DATA_EXPORT integration
    /// </summary>
    public required IReadOnlyList<Destination> Destinations
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Destination>>("destinations");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Destination>>(
                "destinations",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Destinations)
        {
            item.Validate();
        }
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
    public Data(IReadOnlyList<Destination> destinations)
        : this()
    {
        this.Destinations = destinations;
    }
}

class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Data.FromRawUnchecked(rawData);
}

/// <summary>
/// A single destination entry under the DATA_EXPORT integration.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Destination, DestinationFromRaw>))]
public sealed record class Destination : JsonModel
{
    /// <summary>
    /// ISO8601 timestamp of when the destination was connected
    /// </summary>
    public required string ConnectedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("connectedAt");
        }
        init { this._rawData.Set("connectedAt", value); }
    }

    /// <summary>
    /// Provider destination ID
    /// </summary>
    public required string DestinationID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("destinationId");
        }
        init { this._rawData.Set("destinationId", value); }
    }

    /// <summary>
    /// Destination type (snowflake, bigquery, ...)
    /// </summary>
    public required string Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Connection status of the destination (connected, failed)
    /// </summary>
    public string? ConnectionStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("connectionStatus");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("connectionStatus", value);
        }
    }

    public IReadOnlyList<string>? EnabledModels
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("enabledModels");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "enabledModels",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Latest sync snapshot for the destination, refreshed by the provider webhook
    /// </summary>
    public LastSyncStatus? LastSyncStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<LastSyncStatus>("lastSyncStatus");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("lastSyncStatus", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ConnectedAt;
        _ = this.DestinationID;
        _ = this.Type;
        _ = this.ConnectionStatus;
        _ = this.EnabledModels;
        this.LastSyncStatus?.Validate();
    }

    public Destination() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Destination(Destination destination)
        : base(destination) { }
#pragma warning restore CS8618

    public Destination(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Destination(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DestinationFromRaw.FromRawUnchecked"/>
    public static Destination FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DestinationFromRaw : IFromRawJson<Destination>
{
    /// <inheritdoc/>
    public Destination FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Destination.FromRawUnchecked(rawData);
}

/// <summary>
/// Latest sync snapshot for the destination, refreshed by the provider webhook
/// </summary>
[JsonConverter(typeof(JsonModelConverter<LastSyncStatus, LastSyncStatusFromRaw>))]
public sealed record class LastSyncStatus : JsonModel
{
    /// <summary>
    /// ISO8601 timestamp of when the latest sync finished
    /// </summary>
    public required string FinishedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("finishedAt");
        }
        init { this._rawData.Set("finishedAt", value); }
    }

    /// <summary>
    /// Sync status (PENDING, RUNNING, INCOMPLETE, FAILED, SUCCEEDED, CANCELLED)
    /// </summary>
    public required string Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Provider transfer ID of the latest sync
    /// </summary>
    public required string TransferID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("transferId");
        }
        init { this._rawData.Set("transferId", value); }
    }

    /// <summary>
    /// Party responsible for a failed sync, as reported by the data-export provider
    /// </summary>
    public string? BlamedParty
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("blamedParty");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("blamedParty", value);
        }
    }

    /// <summary>
    /// Customer-friendly failure message, when the latest sync failed
    /// </summary>
    public string? FailureMessage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("failureMessage");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("failureMessage", value);
        }
    }

    /// <summary>
    /// Number of rows transferred in the latest sync
    /// </summary>
    public double? RowsTransferred
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("rowsTransferred");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("rowsTransferred", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FinishedAt;
        _ = this.Status;
        _ = this.TransferID;
        _ = this.BlamedParty;
        _ = this.FailureMessage;
        _ = this.RowsTransferred;
    }

    public LastSyncStatus() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LastSyncStatus(LastSyncStatus lastSyncStatus)
        : base(lastSyncStatus) { }
#pragma warning restore CS8618

    public LastSyncStatus(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LastSyncStatus(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LastSyncStatusFromRaw.FromRawUnchecked"/>
    public static LastSyncStatus FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LastSyncStatusFromRaw : IFromRawJson<LastSyncStatus>
{
    /// <inheritdoc/>
    public LastSyncStatus FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        LastSyncStatus.FromRawUnchecked(rawData);
}
