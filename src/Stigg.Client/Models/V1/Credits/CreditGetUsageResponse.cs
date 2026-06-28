using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;

namespace Stigg.Client.Models.V1.Credits;

/// <summary>
/// Response object
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CreditGetUsageResponse, CreditGetUsageResponseFromRaw>))]
public sealed record class CreditGetUsageResponse : JsonModel
{
    /// <summary>
    /// Credit usage data grouped by feature with time-series points
    /// </summary>
    public required CreditGetUsageResponseData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CreditGetUsageResponseData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public CreditGetUsageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreditGetUsageResponse(CreditGetUsageResponse creditGetUsageResponse)
        : base(creditGetUsageResponse) { }
#pragma warning restore CS8618

    public CreditGetUsageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditGetUsageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreditGetUsageResponseFromRaw.FromRawUnchecked"/>
    public static CreditGetUsageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CreditGetUsageResponse(CreditGetUsageResponseData data)
        : this()
    {
        this.Data = data;
    }
}

class CreditGetUsageResponseFromRaw : IFromRawJson<CreditGetUsageResponse>
{
    /// <inheritdoc/>
    public CreditGetUsageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CreditGetUsageResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Credit usage data grouped by feature with time-series points
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<CreditGetUsageResponseData, CreditGetUsageResponseDataFromRaw>)
)]
public sealed record class CreditGetUsageResponseData : JsonModel
{
    /// <summary>
    /// The custom currency used for credit measurement
    /// </summary>
    public required Currency? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Currency>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// Cursor-based pagination for the returned series. `next`/`prev` are opaque
    /// cursors; pass them back as `after`/`before` to traverse pages. The series
    /// axis is `groupBy` when provided, otherwise `featureId`
    /// </summary>
    public required Pagination Pagination
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Pagination>("pagination");
        }
        init { this._rawData.Set("pagination", value); }
    }

    /// <summary>
    /// Credit usage series grouped by feature
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
        this.Currency?.Validate();
        this.Pagination.Validate();
        foreach (var item in this.Series)
        {
            item.Validate();
        }
    }

    public CreditGetUsageResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreditGetUsageResponseData(CreditGetUsageResponseData creditGetUsageResponseData)
        : base(creditGetUsageResponseData) { }
#pragma warning restore CS8618

    public CreditGetUsageResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditGetUsageResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreditGetUsageResponseDataFromRaw.FromRawUnchecked"/>
    public static CreditGetUsageResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreditGetUsageResponseDataFromRaw : IFromRawJson<CreditGetUsageResponseData>
{
    /// <inheritdoc/>
    public CreditGetUsageResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CreditGetUsageResponseData.FromRawUnchecked(rawData);
}

/// <summary>
/// The custom currency used for credit measurement
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Currency, CurrencyFromRaw>))]
public sealed record class Currency : JsonModel
{
    /// <summary>
    /// The currency identifier
    /// </summary>
    public required string CurrencyID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("currencyId");
        }
        init { this._rawData.Set("currencyId", value); }
    }

    /// <summary>
    /// The display name of the currency
    /// </summary>
    public required string DisplayName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("displayName");
        }
        init { this._rawData.Set("displayName", value); }
    }

    /// <summary>
    /// Plural unit label
    /// </summary>
    public required string? Plural
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("plural");
        }
        init { this._rawData.Set("plural", value); }
    }

    /// <summary>
    /// Singular unit label
    /// </summary>
    public required string? Singular
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("singular");
        }
        init { this._rawData.Set("singular", value); }
    }

    /// <summary>
    /// The currency symbol
    /// </summary>
    public required string? Symbol
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("symbol");
        }
        init { this._rawData.Set("symbol", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CurrencyID;
        _ = this.DisplayName;
        _ = this.Plural;
        _ = this.Singular;
        _ = this.Symbol;
    }

    public Currency() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Currency(Currency currency)
        : base(currency) { }
#pragma warning restore CS8618

    public Currency(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Currency(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CurrencyFromRaw.FromRawUnchecked"/>
    public static Currency FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CurrencyFromRaw : IFromRawJson<Currency>
{
    /// <inheritdoc/>
    public Currency FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Currency.FromRawUnchecked(rawData);
}

/// <summary>
/// Cursor-based pagination for the returned series. `next`/`prev` are opaque cursors;
/// pass them back as `after`/`before` to traverse pages. The series axis is `groupBy`
/// when provided, otherwise `featureId`
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Pagination, PaginationFromRaw>))]
public sealed record class Pagination : JsonModel
{
    /// <summary>
    /// Cursor for fetching the next page of results, or null if no additional pages exist
    /// </summary>
    public required string? Next
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("next");
        }
        init { this._rawData.Set("next", value); }
    }

    /// <summary>
    /// Cursor for fetching the previous page of results, or null if at the beginning
    /// </summary>
    public required string? Prev
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("prev");
        }
        init { this._rawData.Set("prev", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Next;
        _ = this.Prev;
    }

    public Pagination() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Pagination(Pagination pagination)
        : base(pagination) { }
#pragma warning restore CS8618

    public Pagination(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Pagination(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaginationFromRaw.FromRawUnchecked"/>
    public static Pagination FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaginationFromRaw : IFromRawJson<Pagination>
{
    /// <inheritdoc/>
    public Pagination FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Pagination.FromRawUnchecked(rawData);
}

/// <summary>
/// Credit usage data for a single feature
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Series, SeriesFromRaw>))]
public sealed record class Series : JsonModel
{
    /// <summary>
    /// The feature ID; null when grouping by dimensions only
    /// </summary>
    public required string? FeatureID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("featureId");
        }
        init { this._rawData.Set("featureId", value); }
    }

    /// <summary>
    /// The display name of the feature; null when grouping by dimensions only
    /// </summary>
    public required string? FeatureName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("featureName");
        }
        init { this._rawData.Set("featureName", value); }
    }

    /// <summary>
    /// Time-series data points for this feature
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
    /// Total credits consumed by this feature in the time range
    /// </summary>
    public required double TotalCredits
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("totalCredits");
        }
        init { this._rawData.Set("totalCredits", value); }
    }

    /// <summary>
    /// Dimension key/value pairs identifying this series when groupBy is applied
    /// </summary>
    public IReadOnlyList<Tag>? Tags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Tag>>("tags");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Tag>?>(
                "tags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FeatureID;
        _ = this.FeatureName;
        foreach (var item in this.Points)
        {
            item.Validate();
        }
        _ = this.TotalCredits;
        foreach (var item in this.Tags ?? [])
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
/// A single data point in the credit usage time series
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Point, PointFromRaw>))]
public sealed record class Point : JsonModel
{
    /// <summary>
    /// The timestamp of the data point
    /// </summary>
    public required DateTimeOffset Timestamp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("timestamp");
        }
        init { this._rawData.Set("timestamp", value); }
    }

    /// <summary>
    /// The credit usage value at this point
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
/// Dimension key/value pair identifying a credit usage series
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Tag, TagFromRaw>))]
public sealed record class Tag : JsonModel
{
    /// <summary>
    /// The dimension key
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
    /// The dimension value for this series
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
