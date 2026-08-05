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
    typeof(JsonModelConverter<
        DestinationUpdateSelectionResponse,
        DestinationUpdateSelectionResponseFromRaw
    >)
)]
public sealed record class DestinationUpdateSelectionResponse : JsonModel
{
    /// <summary>
    /// Current destinations under the DATA_EXPORT integration.
    /// </summary>
    public required DestinationUpdateSelectionResponseData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<DestinationUpdateSelectionResponseData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public DestinationUpdateSelectionResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DestinationUpdateSelectionResponse(
        DestinationUpdateSelectionResponse destinationUpdateSelectionResponse
    )
        : base(destinationUpdateSelectionResponse) { }
#pragma warning restore CS8618

    public DestinationUpdateSelectionResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DestinationUpdateSelectionResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DestinationUpdateSelectionResponseFromRaw.FromRawUnchecked"/>
    public static DestinationUpdateSelectionResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public DestinationUpdateSelectionResponse(DestinationUpdateSelectionResponseData data)
        : this()
    {
        this.Data = data;
    }
}

class DestinationUpdateSelectionResponseFromRaw : IFromRawJson<DestinationUpdateSelectionResponse>
{
    /// <inheritdoc/>
    public DestinationUpdateSelectionResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DestinationUpdateSelectionResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Current destinations under the DATA_EXPORT integration.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        DestinationUpdateSelectionResponseData,
        DestinationUpdateSelectionResponseDataFromRaw
    >)
)]
public sealed record class DestinationUpdateSelectionResponseData : JsonModel
{
    /// <summary>
    /// Current destinations under the DATA_EXPORT integration
    /// </summary>
    public required IReadOnlyList<DestinationUpdateSelectionResponseDataDestination> Destinations
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<DestinationUpdateSelectionResponseDataDestination>
            >("destinations");
        }
        init
        {
            this._rawData.Set<ImmutableArray<DestinationUpdateSelectionResponseDataDestination>>(
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

    public DestinationUpdateSelectionResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DestinationUpdateSelectionResponseData(
        DestinationUpdateSelectionResponseData destinationUpdateSelectionResponseData
    )
        : base(destinationUpdateSelectionResponseData) { }
#pragma warning restore CS8618

    public DestinationUpdateSelectionResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DestinationUpdateSelectionResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DestinationUpdateSelectionResponseDataFromRaw.FromRawUnchecked"/>
    public static DestinationUpdateSelectionResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public DestinationUpdateSelectionResponseData(
        IReadOnlyList<DestinationUpdateSelectionResponseDataDestination> destinations
    )
        : this()
    {
        this.Destinations = destinations;
    }
}

class DestinationUpdateSelectionResponseDataFromRaw
    : IFromRawJson<DestinationUpdateSelectionResponseData>
{
    /// <inheritdoc/>
    public DestinationUpdateSelectionResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DestinationUpdateSelectionResponseData.FromRawUnchecked(rawData);
}

/// <summary>
/// A single destination entry under the DATA_EXPORT integration.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        DestinationUpdateSelectionResponseDataDestination,
        DestinationUpdateSelectionResponseDataDestinationFromRaw
    >)
)]
public sealed record class DestinationUpdateSelectionResponseDataDestination : JsonModel
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
    public DestinationUpdateSelectionResponseDataDestinationLastSyncStatus? LastSyncStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<DestinationUpdateSelectionResponseDataDestinationLastSyncStatus>(
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

    public DestinationUpdateSelectionResponseDataDestination() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DestinationUpdateSelectionResponseDataDestination(
        DestinationUpdateSelectionResponseDataDestination destinationUpdateSelectionResponseDataDestination
    )
        : base(destinationUpdateSelectionResponseDataDestination) { }
#pragma warning restore CS8618

    public DestinationUpdateSelectionResponseDataDestination(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DestinationUpdateSelectionResponseDataDestination(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DestinationUpdateSelectionResponseDataDestinationFromRaw.FromRawUnchecked"/>
    public static DestinationUpdateSelectionResponseDataDestination FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DestinationUpdateSelectionResponseDataDestinationFromRaw
    : IFromRawJson<DestinationUpdateSelectionResponseDataDestination>
{
    /// <inheritdoc/>
    public DestinationUpdateSelectionResponseDataDestination FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DestinationUpdateSelectionResponseDataDestination.FromRawUnchecked(rawData);
}

/// <summary>
/// Latest sync snapshot for the destination, refreshed by the provider webhook
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        DestinationUpdateSelectionResponseDataDestinationLastSyncStatus,
        DestinationUpdateSelectionResponseDataDestinationLastSyncStatusFromRaw
    >)
)]
public sealed record class DestinationUpdateSelectionResponseDataDestinationLastSyncStatus
    : JsonModel
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

    public DestinationUpdateSelectionResponseDataDestinationLastSyncStatus() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DestinationUpdateSelectionResponseDataDestinationLastSyncStatus(
        DestinationUpdateSelectionResponseDataDestinationLastSyncStatus destinationUpdateSelectionResponseDataDestinationLastSyncStatus
    )
        : base(destinationUpdateSelectionResponseDataDestinationLastSyncStatus) { }
#pragma warning restore CS8618

    public DestinationUpdateSelectionResponseDataDestinationLastSyncStatus(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DestinationUpdateSelectionResponseDataDestinationLastSyncStatus(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DestinationUpdateSelectionResponseDataDestinationLastSyncStatusFromRaw.FromRawUnchecked"/>
    public static DestinationUpdateSelectionResponseDataDestinationLastSyncStatus FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DestinationUpdateSelectionResponseDataDestinationLastSyncStatusFromRaw
    : IFromRawJson<DestinationUpdateSelectionResponseDataDestinationLastSyncStatus>
{
    /// <inheritdoc/>
    public DestinationUpdateSelectionResponseDataDestinationLastSyncStatus FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DestinationUpdateSelectionResponseDataDestinationLastSyncStatus.FromRawUnchecked(rawData);
}
