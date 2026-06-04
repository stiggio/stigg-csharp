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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ConnectedAt;
        _ = this.DestinationID;
        _ = this.Type;
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
