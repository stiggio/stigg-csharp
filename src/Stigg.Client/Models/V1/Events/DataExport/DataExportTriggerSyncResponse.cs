using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;

namespace Stigg.Client.Models.V1.Events.DataExport;

/// <summary>
/// Response object
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<DataExportTriggerSyncResponse, DataExportTriggerSyncResponseFromRaw>)
)]
public sealed record class DataExportTriggerSyncResponse : JsonModel
{
    /// <summary>
    /// Per-destination trigger results across the batch.
    /// </summary>
    public required DataExportTriggerSyncResponseData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<DataExportTriggerSyncResponseData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public DataExportTriggerSyncResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DataExportTriggerSyncResponse(
        DataExportTriggerSyncResponse dataExportTriggerSyncResponse
    )
        : base(dataExportTriggerSyncResponse) { }
#pragma warning restore CS8618

    public DataExportTriggerSyncResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DataExportTriggerSyncResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataExportTriggerSyncResponseFromRaw.FromRawUnchecked"/>
    public static DataExportTriggerSyncResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public DataExportTriggerSyncResponse(DataExportTriggerSyncResponseData data)
        : this()
    {
        this.Data = data;
    }
}

class DataExportTriggerSyncResponseFromRaw : IFromRawJson<DataExportTriggerSyncResponse>
{
    /// <inheritdoc/>
    public DataExportTriggerSyncResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DataExportTriggerSyncResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Per-destination trigger results across the batch.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        DataExportTriggerSyncResponseData,
        DataExportTriggerSyncResponseDataFromRaw
    >)
)]
public sealed record class DataExportTriggerSyncResponseData : JsonModel
{
    /// <summary>
    /// Per-destination trigger results
    /// </summary>
    public required IReadOnlyList<Result> Results
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Result>>("results");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Result>>(
                "results",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Results)
        {
            item.Validate();
        }
    }

    public DataExportTriggerSyncResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DataExportTriggerSyncResponseData(
        DataExportTriggerSyncResponseData dataExportTriggerSyncResponseData
    )
        : base(dataExportTriggerSyncResponseData) { }
#pragma warning restore CS8618

    public DataExportTriggerSyncResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DataExportTriggerSyncResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataExportTriggerSyncResponseDataFromRaw.FromRawUnchecked"/>
    public static DataExportTriggerSyncResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public DataExportTriggerSyncResponseData(IReadOnlyList<Result> results)
        : this()
    {
        this.Results = results;
    }
}

class DataExportTriggerSyncResponseDataFromRaw : IFromRawJson<DataExportTriggerSyncResponseData>
{
    /// <inheritdoc/>
    public DataExportTriggerSyncResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DataExportTriggerSyncResponseData.FromRawUnchecked(rawData);
}

/// <summary>
/// Per-destination trigger results.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Result, ResultFromRaw>))]
public sealed record class Result : JsonModel
{
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
    /// True if a transfer was kicked
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

    /// <summary>
    /// Error message if triggered=false on a hard failure
    /// </summary>
    public string? ErrorMessage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("errorMessage");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("errorMessage", value);
        }
    }

    /// <summary>
    /// Provider-side transfer ID
    /// </summary>
    public string? TransferID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("transferId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("transferId", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DestinationID;
        _ = this.Triggered;
        _ = this.ErrorMessage;
        _ = this.TransferID;
    }

    public Result() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Result(Result result)
        : base(result) { }
#pragma warning restore CS8618

    public Result(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Result(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ResultFromRaw.FromRawUnchecked"/>
    public static Result FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ResultFromRaw : IFromRawJson<Result>
{
    /// <inheritdoc/>
    public Result FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Result.FromRawUnchecked(rawData);
}
