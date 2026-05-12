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
    public CreditGetUsageResponse(Data data)
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
[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
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
        foreach (var item in this.Series)
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
}

class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Data.FromRawUnchecked(rawData);
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
/// Credit usage data for a single feature
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Series, SeriesFromRaw>))]
public sealed record class Series : JsonModel
{
    /// <summary>
    /// The feature ID
    /// </summary>
    public required string FeatureID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("featureId");
        }
        init { this._rawData.Set("featureId", value); }
    }

    /// <summary>
    /// The display name of the feature
    /// </summary>
    public required string FeatureName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("featureName");
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
