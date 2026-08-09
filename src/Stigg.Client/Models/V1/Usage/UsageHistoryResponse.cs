using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using System = System;

namespace Stigg.Client.Models.V1.Usage;

/// <summary>
/// Response object
/// </summary>
[JsonConverter(typeof(JsonModelConverter<UsageHistoryResponse, UsageHistoryResponseFromRaw>))]
public sealed record class UsageHistoryResponse : JsonModel
{
    /// <summary>
    /// Historical usage time series
    /// </summary>
    public required UsageHistoryResponseData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<UsageHistoryResponseData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public UsageHistoryResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UsageHistoryResponse(UsageHistoryResponse usageHistoryResponse)
        : base(usageHistoryResponse) { }
#pragma warning restore CS8618

    public UsageHistoryResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UsageHistoryResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UsageHistoryResponseFromRaw.FromRawUnchecked"/>
    public static UsageHistoryResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UsageHistoryResponse(UsageHistoryResponseData data)
        : this()
    {
        this.Data = data;
    }
}

class UsageHistoryResponseFromRaw : IFromRawJson<UsageHistoryResponse>
{
    /// <inheritdoc/>
    public UsageHistoryResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UsageHistoryResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Historical usage time series
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<UsageHistoryResponseData, UsageHistoryResponseDataFromRaw>)
)]
public sealed record class UsageHistoryResponseData : JsonModel
{
    /// <summary>
    /// Markers for events that affecting feature usage
    /// </summary>
    public required IReadOnlyList<Marker> Markers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Marker>>("markers");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Marker>>(
                "markers",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Series of usage history
    /// </summary>
    public required IReadOnlyList<Series> Series
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Series>>("series");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Series>>(
                "series",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Markers)
        {
            item.Validate();
        }
        foreach (var item in this.Series)
        {
            item.Validate();
        }
    }

    public UsageHistoryResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UsageHistoryResponseData(UsageHistoryResponseData usageHistoryResponseData)
        : base(usageHistoryResponseData) { }
#pragma warning restore CS8618

    public UsageHistoryResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UsageHistoryResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UsageHistoryResponseDataFromRaw.FromRawUnchecked"/>
    public static UsageHistoryResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UsageHistoryResponseDataFromRaw : IFromRawJson<UsageHistoryResponseData>
{
    /// <inheritdoc/>
    public UsageHistoryResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UsageHistoryResponseData.FromRawUnchecked(rawData);
}

/// <summary>
/// Usage reset or change marker
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Marker, MarkerFromRaw>))]
public sealed record class Marker : JsonModel
{
    /// <summary>
    /// Timestamp of the marker
    /// </summary>
    public required System::DateTimeOffset Timestamp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("timestamp");
        }
        init { this._rawData.Set("timestamp", value); }
    }

    /// <summary>
    /// Type of marker for a usage history point
    /// </summary>
    public required ApiEnum<string, global::Stigg.Client.Models.V1.Usage.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Stigg.Client.Models.V1.Usage.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Timestamp;
        this.Type.Validate();
    }

    public Marker() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Marker(Marker marker)
        : base(marker) { }
#pragma warning restore CS8618

    public Marker(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Marker(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MarkerFromRaw.FromRawUnchecked"/>
    public static Marker FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MarkerFromRaw : IFromRawJson<Marker>
{
    /// <inheritdoc/>
    public Marker FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Marker.FromRawUnchecked(rawData);
}

/// <summary>
/// Type of marker for a usage history point
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    PeriodicReset,
    SubscriptionChangeReset,
}

sealed class TypeConverter : JsonConverter<global::Stigg.Client.Models.V1.Usage.Type>
{
    public override global::Stigg.Client.Models.V1.Usage.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PERIODIC_RESET" => global::Stigg.Client.Models.V1.Usage.Type.PeriodicReset,
            "SUBSCRIPTION_CHANGE_RESET" => global::Stigg
                .Client
                .Models
                .V1
                .Usage
                .Type
                .SubscriptionChangeReset,
            _ => (global::Stigg.Client.Models.V1.Usage.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Stigg.Client.Models.V1.Usage.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Stigg.Client.Models.V1.Usage.Type.PeriodicReset => "PERIODIC_RESET",
                global::Stigg.Client.Models.V1.Usage.Type.SubscriptionChangeReset =>
                    "SUBSCRIPTION_CHANGE_RESET",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Usage data points with tags
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Series, SeriesFromRaw>))]
public sealed record class Series : JsonModel
{
    /// <summary>
    /// Points in the usage history series
    /// </summary>
    public required IReadOnlyList<Point> Points
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Point>>("points");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Point>>(
                "points",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Tags for the usage history series
    /// </summary>
    public required IReadOnlyList<Tag> Tags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Tag>>("tags");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Tag>>("tags", ImmutableArray.ToImmutableArray(value));
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Points)
        {
            item.Validate();
        }
        foreach (var item in this.Tags)
        {
            item.Validate();
        }
    }

    public Series() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Series(Series series)
        : base(series) { }
#pragma warning restore CS8618

    public Series(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Series(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SeriesFromRaw.FromRawUnchecked"/>
    public static Series FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SeriesFromRaw : IFromRawJson<Series>
{
    /// <inheritdoc/>
    public Series FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Series.FromRawUnchecked(rawData);
}

/// <summary>
/// Single usage data point
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Point, PointFromRaw>))]
public sealed record class Point : JsonModel
{
    /// <summary>
    /// Indicates whether there was usage reset in this point, see `markers` for details
    /// </summary>
    public required bool IsResetPoint
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("isResetPoint");
        }
        init { this._rawData.Set("isResetPoint", value); }
    }

    /// <summary>
    /// Timestamp of the usage history point
    /// </summary>
    public required System::DateTimeOffset Timestamp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("timestamp");
        }
        init { this._rawData.Set("timestamp", value); }
    }

    /// <summary>
    /// Value of the usage history point
    /// </summary>
    public required double Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("value");
        }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.IsResetPoint;
        _ = this.Timestamp;
        _ = this.Value;
    }

    public Point() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Point(Point point)
        : base(point) { }
#pragma warning restore CS8618

    public Point(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Point(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PointFromRaw.FromRawUnchecked"/>
    public static Point FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PointFromRaw : IFromRawJson<Point>
{
    /// <inheritdoc/>
    public Point FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Point.FromRawUnchecked(rawData);
}

/// <summary>
/// Grouping tag key-value
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Tag, TagFromRaw>))]
public sealed record class Tag : JsonModel
{
    /// <summary>
    /// Key of the tag
    /// </summary>
    public required string Key
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("key");
        }
        init { this._rawData.Set("key", value); }
    }

    /// <summary>
    /// Value of the tag
    /// </summary>
    public required string Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("value");
        }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Key;
        _ = this.Value;
    }

    public Tag() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Tag(Tag tag)
        : base(tag) { }
#pragma warning restore CS8618

    public Tag(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Tag(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TagFromRaw.FromRawUnchecked"/>
    public static Tag FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TagFromRaw : IFromRawJson<Tag>
{
    /// <inheritdoc/>
    public Tag FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Tag.FromRawUnchecked(rawData);
}
