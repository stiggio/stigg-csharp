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
    typeof(JsonModelConverter<DestinationUpdateResponse, DestinationUpdateResponseFromRaw>)
)]
public sealed record class DestinationUpdateResponse : JsonModel
{
    /// <summary>
    /// Current destinations under the DATA_EXPORT integration.
    /// </summary>
    public required DestinationUpdateResponseData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<DestinationUpdateResponseData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public DestinationUpdateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DestinationUpdateResponse(DestinationUpdateResponse destinationUpdateResponse)
        : base(destinationUpdateResponse) { }
#pragma warning restore CS8618

    public DestinationUpdateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DestinationUpdateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DestinationUpdateResponseFromRaw.FromRawUnchecked"/>
    public static DestinationUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public DestinationUpdateResponse(DestinationUpdateResponseData data)
        : this()
    {
        this.Data = data;
    }
}

class DestinationUpdateResponseFromRaw : IFromRawJson<DestinationUpdateResponse>
{
    /// <inheritdoc/>
    public DestinationUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DestinationUpdateResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Current destinations under the DATA_EXPORT integration.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<DestinationUpdateResponseData, DestinationUpdateResponseDataFromRaw>)
)]
public sealed record class DestinationUpdateResponseData : JsonModel
{
    /// <summary>
    /// Current destinations under the DATA_EXPORT integration
    /// </summary>
    public required IReadOnlyList<DestinationUpdateResponseDataDestination> Destinations
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<DestinationUpdateResponseDataDestination>
            >("destinations");
        }
        init
        {
            this._rawData.Set<ImmutableArray<DestinationUpdateResponseDataDestination>>(
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

    public DestinationUpdateResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DestinationUpdateResponseData(
        DestinationUpdateResponseData destinationUpdateResponseData
    )
        : base(destinationUpdateResponseData) { }
#pragma warning restore CS8618

    public DestinationUpdateResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DestinationUpdateResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DestinationUpdateResponseDataFromRaw.FromRawUnchecked"/>
    public static DestinationUpdateResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public DestinationUpdateResponseData(
        IReadOnlyList<DestinationUpdateResponseDataDestination> destinations
    )
        : this()
    {
        this.Destinations = destinations;
    }
}

class DestinationUpdateResponseDataFromRaw : IFromRawJson<DestinationUpdateResponseData>
{
    /// <inheritdoc/>
    public DestinationUpdateResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DestinationUpdateResponseData.FromRawUnchecked(rawData);
}

/// <summary>
/// A single destination entry under the DATA_EXPORT integration.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        DestinationUpdateResponseDataDestination,
        DestinationUpdateResponseDataDestinationFromRaw
    >)
)]
public sealed record class DestinationUpdateResponseDataDestination : JsonModel
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
    public DestinationUpdateResponseDataDestinationLastSyncStatus? LastSyncStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<DestinationUpdateResponseDataDestinationLastSyncStatus>(
                "lastSyncStatus"
            );
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

    public DestinationUpdateResponseDataDestination() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DestinationUpdateResponseDataDestination(
        DestinationUpdateResponseDataDestination destinationUpdateResponseDataDestination
    )
        : base(destinationUpdateResponseDataDestination) { }
#pragma warning restore CS8618

    public DestinationUpdateResponseDataDestination(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DestinationUpdateResponseDataDestination(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DestinationUpdateResponseDataDestinationFromRaw.FromRawUnchecked"/>
    public static DestinationUpdateResponseDataDestination FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DestinationUpdateResponseDataDestinationFromRaw
    : IFromRawJson<DestinationUpdateResponseDataDestination>
{
    /// <inheritdoc/>
    public DestinationUpdateResponseDataDestination FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DestinationUpdateResponseDataDestination.FromRawUnchecked(rawData);
}

/// <summary>
/// Latest sync snapshot for the destination, refreshed by the provider webhook
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        DestinationUpdateResponseDataDestinationLastSyncStatus,
        DestinationUpdateResponseDataDestinationLastSyncStatusFromRaw
    >)
)]
public sealed record class DestinationUpdateResponseDataDestinationLastSyncStatus : JsonModel
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

    public DestinationUpdateResponseDataDestinationLastSyncStatus() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DestinationUpdateResponseDataDestinationLastSyncStatus(
        DestinationUpdateResponseDataDestinationLastSyncStatus destinationUpdateResponseDataDestinationLastSyncStatus
    )
        : base(destinationUpdateResponseDataDestinationLastSyncStatus) { }
#pragma warning restore CS8618

    public DestinationUpdateResponseDataDestinationLastSyncStatus(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DestinationUpdateResponseDataDestinationLastSyncStatus(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DestinationUpdateResponseDataDestinationLastSyncStatusFromRaw.FromRawUnchecked"/>
    public static DestinationUpdateResponseDataDestinationLastSyncStatus FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DestinationUpdateResponseDataDestinationLastSyncStatusFromRaw
    : IFromRawJson<DestinationUpdateResponseDataDestinationLastSyncStatus>
{
    /// <inheritdoc/>
    public DestinationUpdateResponseDataDestinationLastSyncStatus FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DestinationUpdateResponseDataDestinationLastSyncStatus.FromRawUnchecked(rawData);
}
