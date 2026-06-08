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
    typeof(JsonModelConverter<DestinationDeleteResponse, DestinationDeleteResponseFromRaw>)
)]
public sealed record class DestinationDeleteResponse : JsonModel
{
    /// <summary>
    /// Current destinations under the DATA_EXPORT integration.
    /// </summary>
    public required DestinationDeleteResponseData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<DestinationDeleteResponseData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public DestinationDeleteResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DestinationDeleteResponse(DestinationDeleteResponse destinationDeleteResponse)
        : base(destinationDeleteResponse) { }
#pragma warning restore CS8618

    public DestinationDeleteResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DestinationDeleteResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DestinationDeleteResponseFromRaw.FromRawUnchecked"/>
    public static DestinationDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public DestinationDeleteResponse(DestinationDeleteResponseData data)
        : this()
    {
        this.Data = data;
    }
}

class DestinationDeleteResponseFromRaw : IFromRawJson<DestinationDeleteResponse>
{
    /// <inheritdoc/>
    public DestinationDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DestinationDeleteResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Current destinations under the DATA_EXPORT integration.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<DestinationDeleteResponseData, DestinationDeleteResponseDataFromRaw>)
)]
public sealed record class DestinationDeleteResponseData : JsonModel
{
    /// <summary>
    /// Current destinations under the DATA_EXPORT integration
    /// </summary>
    public required IReadOnlyList<DestinationDeleteResponseDataDestination> Destinations
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<DestinationDeleteResponseDataDestination>
            >("destinations");
        }
        init
        {
            this._rawData.Set<ImmutableArray<DestinationDeleteResponseDataDestination>>(
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

    public DestinationDeleteResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DestinationDeleteResponseData(
        DestinationDeleteResponseData destinationDeleteResponseData
    )
        : base(destinationDeleteResponseData) { }
#pragma warning restore CS8618

    public DestinationDeleteResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DestinationDeleteResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DestinationDeleteResponseDataFromRaw.FromRawUnchecked"/>
    public static DestinationDeleteResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public DestinationDeleteResponseData(
        IReadOnlyList<DestinationDeleteResponseDataDestination> destinations
    )
        : this()
    {
        this.Destinations = destinations;
    }
}

class DestinationDeleteResponseDataFromRaw : IFromRawJson<DestinationDeleteResponseData>
{
    /// <inheritdoc/>
    public DestinationDeleteResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DestinationDeleteResponseData.FromRawUnchecked(rawData);
}

/// <summary>
/// A single destination entry under the DATA_EXPORT integration.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        DestinationDeleteResponseDataDestination,
        DestinationDeleteResponseDataDestinationFromRaw
    >)
)]
public sealed record class DestinationDeleteResponseDataDestination : JsonModel
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

    /// <summary>
    /// Latest sync snapshot for the destination, refreshed by the provider webhook
    /// </summary>
    public DestinationDeleteResponseDataDestinationLastSyncStatus? LastSyncStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<DestinationDeleteResponseDataDestinationLastSyncStatus>(
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
        this.LastSyncStatus?.Validate();
    }

    public DestinationDeleteResponseDataDestination() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DestinationDeleteResponseDataDestination(
        DestinationDeleteResponseDataDestination destinationDeleteResponseDataDestination
    )
        : base(destinationDeleteResponseDataDestination) { }
#pragma warning restore CS8618

    public DestinationDeleteResponseDataDestination(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DestinationDeleteResponseDataDestination(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DestinationDeleteResponseDataDestinationFromRaw.FromRawUnchecked"/>
    public static DestinationDeleteResponseDataDestination FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DestinationDeleteResponseDataDestinationFromRaw
    : IFromRawJson<DestinationDeleteResponseDataDestination>
{
    /// <inheritdoc/>
    public DestinationDeleteResponseDataDestination FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DestinationDeleteResponseDataDestination.FromRawUnchecked(rawData);
}

/// <summary>
/// Latest sync snapshot for the destination, refreshed by the provider webhook
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        DestinationDeleteResponseDataDestinationLastSyncStatus,
        DestinationDeleteResponseDataDestinationLastSyncStatusFromRaw
    >)
)]
public sealed record class DestinationDeleteResponseDataDestinationLastSyncStatus : JsonModel
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

    public DestinationDeleteResponseDataDestinationLastSyncStatus() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DestinationDeleteResponseDataDestinationLastSyncStatus(
        DestinationDeleteResponseDataDestinationLastSyncStatus destinationDeleteResponseDataDestinationLastSyncStatus
    )
        : base(destinationDeleteResponseDataDestinationLastSyncStatus) { }
#pragma warning restore CS8618

    public DestinationDeleteResponseDataDestinationLastSyncStatus(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DestinationDeleteResponseDataDestinationLastSyncStatus(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DestinationDeleteResponseDataDestinationLastSyncStatusFromRaw.FromRawUnchecked"/>
    public static DestinationDeleteResponseDataDestinationLastSyncStatus FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DestinationDeleteResponseDataDestinationLastSyncStatusFromRaw
    : IFromRawJson<DestinationDeleteResponseDataDestinationLastSyncStatus>
{
    /// <inheritdoc/>
    public DestinationDeleteResponseDataDestinationLastSyncStatus FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DestinationDeleteResponseDataDestinationLastSyncStatus.FromRawUnchecked(rawData);
}
