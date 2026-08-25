using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;

namespace Stigg.Client.Models.V1.Features;

/// <summary>
/// Response object
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Feature, FeatureFromRaw>))]
public sealed record class Feature : JsonModel
{
    /// <summary>
    /// Feature configuration object
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

    public Feature() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Feature(Feature feature)
        : base(feature) { }
#pragma warning restore CS8618

    public Feature(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Feature(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FeatureFromRaw.FromRawUnchecked"/>
    public static Feature FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Feature(Data data)
        : this()
    {
        this.Data = data;
    }
}

class FeatureFromRaw : IFromRawJson<Feature>
{
    /// <inheritdoc/>
    public Feature FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Feature.FromRawUnchecked(rawData);
}

/// <summary>
/// Feature configuration object
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// The unique identifier for the feature
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Timestamp of when the record was created
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("createdAt");
        }
        init { this._rawData.Set("createdAt", value); }
    }

    /// <summary>
    /// The description for the feature
    /// </summary>
    public required string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// The display name for the feature
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
    /// The configuration data for the feature
    /// </summary>
    public required IReadOnlyList<DataEnumConfiguration>? EnumConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<DataEnumConfiguration>>(
                "enumConfiguration"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<DataEnumConfiguration>?>(
                "enumConfiguration",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The status of the feature
    /// </summary>
    public required ApiEnum<string, DataFeatureStatus> FeatureStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, DataFeatureStatus>>(
                "featureStatus"
            );
        }
        init { this._rawData.Set("featureStatus", value); }
    }

    /// <summary>
    /// The type of the feature
    /// </summary>
    public required ApiEnum<string, DataFeatureType> FeatureType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, DataFeatureType>>("featureType");
        }
        init { this._rawData.Set("featureType", value); }
    }

    /// <summary>
    /// The units for the feature
    /// </summary>
    public required string? FeatureUnits
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("featureUnits");
        }
        init { this._rawData.Set("featureUnits", value); }
    }

    /// <summary>
    /// The plural units for the feature
    /// </summary>
    public required string? FeatureUnitsPlural
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("featureUnitsPlural");
        }
        init { this._rawData.Set("featureUnitsPlural", value); }
    }

    /// <summary>
    /// The additional metadata for the feature
    /// </summary>
    public required IReadOnlyDictionary<string, string> Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string>>(
                "metadata",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Event meter that turns reported events into usage for a metered feature
    /// </summary>
    public required DataMeter? Meter
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<DataMeter>("meter");
        }
        init { this._rawData.Set("meter", value); }
    }

    /// <summary>
    /// The meter type for the feature
    /// </summary>
    public required ApiEnum<string, DataMeterType> MeterType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, DataMeterType>>("meterType");
        }
        init { this._rawData.Set("meterType", value); }
    }

    /// <summary>
    /// Unit transformation to be applied to the reported usage
    /// </summary>
    public required DataUnitTransformation? UnitTransformation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<DataUnitTransformation>("unitTransformation");
        }
        init { this._rawData.Set("unitTransformation", value); }
    }

    /// <summary>
    /// Timestamp of when the record was last updated
    /// </summary>
    public required DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("updatedAt");
        }
        init { this._rawData.Set("updatedAt", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.Description;
        _ = this.DisplayName;
        foreach (var item in this.EnumConfiguration ?? [])
        {
            item.Validate();
        }
        this.FeatureStatus.Validate();
        this.FeatureType.Validate();
        _ = this.FeatureUnits;
        _ = this.FeatureUnitsPlural;
        _ = this.Metadata;
        this.Meter?.Validate();
        this.MeterType.Validate();
        this.UnitTransformation?.Validate();
        _ = this.UpdatedAt;
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

[JsonConverter(typeof(JsonModelConverter<DataEnumConfiguration, DataEnumConfigurationFromRaw>))]
public sealed record class DataEnumConfiguration : JsonModel
{
    /// <summary>
    /// The display name for the enum configuration entity
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
    /// The unique value identifier for the enum configuration entity
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
        _ = this.DisplayName;
        _ = this.Value;
    }

    public DataEnumConfiguration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DataEnumConfiguration(DataEnumConfiguration dataEnumConfiguration)
        : base(dataEnumConfiguration) { }
#pragma warning restore CS8618

    public DataEnumConfiguration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DataEnumConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataEnumConfigurationFromRaw.FromRawUnchecked"/>
    public static DataEnumConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataEnumConfigurationFromRaw : IFromRawJson<DataEnumConfiguration>
{
    /// <inheritdoc/>
    public DataEnumConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DataEnumConfiguration.FromRawUnchecked(rawData);
}

/// <summary>
/// The status of the feature
/// </summary>
[JsonConverter(typeof(DataFeatureStatusConverter))]
public enum DataFeatureStatus
{
    New,
    Suspended,
    Active,
}

sealed class DataFeatureStatusConverter : JsonConverter<DataFeatureStatus>
{
    public override DataFeatureStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "NEW" => DataFeatureStatus.New,
            "SUSPENDED" => DataFeatureStatus.Suspended,
            "ACTIVE" => DataFeatureStatus.Active,
            _ => (DataFeatureStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DataFeatureStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DataFeatureStatus.New => "NEW",
                DataFeatureStatus.Suspended => "SUSPENDED",
                DataFeatureStatus.Active => "ACTIVE",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The type of the feature
/// </summary>
[JsonConverter(typeof(DataFeatureTypeConverter))]
public enum DataFeatureType
{
    Boolean,
    Number,
    Enum,
}

sealed class DataFeatureTypeConverter : JsonConverter<DataFeatureType>
{
    public override DataFeatureType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "BOOLEAN" => DataFeatureType.Boolean,
            "NUMBER" => DataFeatureType.Number,
            "ENUM" => DataFeatureType.Enum,
            _ => (DataFeatureType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DataFeatureType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DataFeatureType.Boolean => "BOOLEAN",
                DataFeatureType.Number => "NUMBER",
                DataFeatureType.Enum => "ENUM",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Event meter that turns reported events into usage for a metered feature
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DataMeter, DataMeterFromRaw>))]
public sealed record class DataMeter : JsonModel
{
    /// <summary>
    /// How the matching events are aggregated into a usage value
    /// </summary>
    public required DataMeterAggregation Aggregation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<DataMeterAggregation>("aggregation");
        }
        init { this._rawData.Set("aggregation", value); }
    }

    /// <summary>
    /// Event filters. Conditions within a filter are ANDed, and filters are ORed
    /// </summary>
    public required IReadOnlyList<DataMeterFilter> Filters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<DataMeterFilter>>("filters");
        }
        init
        {
            this._rawData.Set<ImmutableArray<DataMeterFilter>>(
                "filters",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Aggregation.Validate();
        foreach (var item in this.Filters)
        {
            item.Validate();
        }
    }

    public DataMeter() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DataMeter(DataMeter dataMeter)
        : base(dataMeter) { }
#pragma warning restore CS8618

    public DataMeter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DataMeter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataMeterFromRaw.FromRawUnchecked"/>
    public static DataMeter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataMeterFromRaw : IFromRawJson<DataMeter>
{
    /// <inheritdoc/>
    public DataMeter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DataMeter.FromRawUnchecked(rawData);
}

/// <summary>
/// How the matching events are aggregated into a usage value
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DataMeterAggregation, DataMeterAggregationFromRaw>))]
public sealed record class DataMeterAggregation : JsonModel
{
    /// <summary>
    /// Aggregation function applied to the matching events
    /// </summary>
    public required ApiEnum<string, DataMeterAggregationFunction> Function
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, DataMeterAggregationFunction>>(
                "function"
            );
        }
        init { this._rawData.Set("function", value); }
    }

    /// <summary>
    /// Aggregation field name
    /// </summary>
    public string? Field
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("field");
        }
        init { this._rawData.Set("field", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Function.Validate();
        _ = this.Field;
    }

    public DataMeterAggregation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DataMeterAggregation(DataMeterAggregation dataMeterAggregation)
        : base(dataMeterAggregation) { }
#pragma warning restore CS8618

    public DataMeterAggregation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DataMeterAggregation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataMeterAggregationFromRaw.FromRawUnchecked"/>
    public static DataMeterAggregation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public DataMeterAggregation(ApiEnum<string, DataMeterAggregationFunction> function)
        : this()
    {
        this.Function = function;
    }
}

class DataMeterAggregationFromRaw : IFromRawJson<DataMeterAggregation>
{
    /// <inheritdoc/>
    public DataMeterAggregation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DataMeterAggregation.FromRawUnchecked(rawData);
}

/// <summary>
/// Aggregation function applied to the matching events
/// </summary>
[JsonConverter(typeof(DataMeterAggregationFunctionConverter))]
public enum DataMeterAggregationFunction
{
    Sum,
    Max,
    Min,
    Avg,
    Count,
    Unique,
}

sealed class DataMeterAggregationFunctionConverter : JsonConverter<DataMeterAggregationFunction>
{
    public override DataMeterAggregationFunction Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SUM" => DataMeterAggregationFunction.Sum,
            "MAX" => DataMeterAggregationFunction.Max,
            "MIN" => DataMeterAggregationFunction.Min,
            "AVG" => DataMeterAggregationFunction.Avg,
            "COUNT" => DataMeterAggregationFunction.Count,
            "UNIQUE" => DataMeterAggregationFunction.Unique,
            _ => (DataMeterAggregationFunction)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DataMeterAggregationFunction value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DataMeterAggregationFunction.Sum => "SUM",
                DataMeterAggregationFunction.Max => "MAX",
                DataMeterAggregationFunction.Min => "MIN",
                DataMeterAggregationFunction.Avg => "AVG",
                DataMeterAggregationFunction.Count => "COUNT",
                DataMeterAggregationFunction.Unique => "UNIQUE",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A set of conditions an event must all match
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DataMeterFilter, DataMeterFilterFromRaw>))]
public sealed record class DataMeterFilter : JsonModel
{
    /// <summary>
    /// Conditions the event must match
    /// </summary>
    public required IReadOnlyList<DataMeterFilterCondition> Conditions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<DataMeterFilterCondition>>(
                "conditions"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<DataMeterFilterCondition>>(
                "conditions",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Conditions)
        {
            item.Validate();
        }
    }

    public DataMeterFilter() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DataMeterFilter(DataMeterFilter dataMeterFilter)
        : base(dataMeterFilter) { }
#pragma warning restore CS8618

    public DataMeterFilter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DataMeterFilter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataMeterFilterFromRaw.FromRawUnchecked"/>
    public static DataMeterFilter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public DataMeterFilter(IReadOnlyList<DataMeterFilterCondition> conditions)
        : this()
    {
        this.Conditions = conditions;
    }
}

class DataMeterFilterFromRaw : IFromRawJson<DataMeterFilter>
{
    /// <inheritdoc/>
    public DataMeterFilter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DataMeterFilter.FromRawUnchecked(rawData);
}

/// <summary>
/// Meter filter condition
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<DataMeterFilterCondition, DataMeterFilterConditionFromRaw>)
)]
public sealed record class DataMeterFilterCondition : JsonModel
{
    /// <summary>
    /// Condition field name
    /// </summary>
    public required string Field
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("field");
        }
        init { this._rawData.Set("field", value); }
    }

    /// <summary>
    /// Comparison applied to the condition field
    /// </summary>
    public required ApiEnum<string, DataMeterFilterConditionOperation> Operation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, DataMeterFilterConditionOperation>
            >("operation");
        }
        init { this._rawData.Set("operation", value); }
    }

    /// <summary>
    /// Condition value
    /// </summary>
    public string? Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("value");
        }
        init { this._rawData.Set("value", value); }
    }

    public IReadOnlyList<string>? Values
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("values");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "values",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Field;
        this.Operation.Validate();
        _ = this.Value;
        _ = this.Values;
    }

    public DataMeterFilterCondition() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DataMeterFilterCondition(DataMeterFilterCondition dataMeterFilterCondition)
        : base(dataMeterFilterCondition) { }
#pragma warning restore CS8618

    public DataMeterFilterCondition(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DataMeterFilterCondition(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataMeterFilterConditionFromRaw.FromRawUnchecked"/>
    public static DataMeterFilterCondition FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataMeterFilterConditionFromRaw : IFromRawJson<DataMeterFilterCondition>
{
    /// <inheritdoc/>
    public DataMeterFilterCondition FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DataMeterFilterCondition.FromRawUnchecked(rawData);
}

/// <summary>
/// Comparison applied to the condition field
/// </summary>
[JsonConverter(typeof(DataMeterFilterConditionOperationConverter))]
public enum DataMeterFilterConditionOperation
{
    Equals,
    NotEquals,
    GreaterThan,
    GreaterThanOrEqual,
    LessThan,
    LessThanOrEqual,
    IsNull,
    IsNotNull,
    Contains,
    StartsWith,
    EndsWith,
    In,
}

sealed class DataMeterFilterConditionOperationConverter
    : JsonConverter<DataMeterFilterConditionOperation>
{
    public override DataMeterFilterConditionOperation Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "EQUALS" => DataMeterFilterConditionOperation.Equals,
            "NOT_EQUALS" => DataMeterFilterConditionOperation.NotEquals,
            "GREATER_THAN" => DataMeterFilterConditionOperation.GreaterThan,
            "GREATER_THAN_OR_EQUAL" => DataMeterFilterConditionOperation.GreaterThanOrEqual,
            "LESS_THAN" => DataMeterFilterConditionOperation.LessThan,
            "LESS_THAN_OR_EQUAL" => DataMeterFilterConditionOperation.LessThanOrEqual,
            "IS_NULL" => DataMeterFilterConditionOperation.IsNull,
            "IS_NOT_NULL" => DataMeterFilterConditionOperation.IsNotNull,
            "CONTAINS" => DataMeterFilterConditionOperation.Contains,
            "STARTS_WITH" => DataMeterFilterConditionOperation.StartsWith,
            "ENDS_WITH" => DataMeterFilterConditionOperation.EndsWith,
            "IN" => DataMeterFilterConditionOperation.In,
            _ => (DataMeterFilterConditionOperation)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DataMeterFilterConditionOperation value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DataMeterFilterConditionOperation.Equals => "EQUALS",
                DataMeterFilterConditionOperation.NotEquals => "NOT_EQUALS",
                DataMeterFilterConditionOperation.GreaterThan => "GREATER_THAN",
                DataMeterFilterConditionOperation.GreaterThanOrEqual => "GREATER_THAN_OR_EQUAL",
                DataMeterFilterConditionOperation.LessThan => "LESS_THAN",
                DataMeterFilterConditionOperation.LessThanOrEqual => "LESS_THAN_OR_EQUAL",
                DataMeterFilterConditionOperation.IsNull => "IS_NULL",
                DataMeterFilterConditionOperation.IsNotNull => "IS_NOT_NULL",
                DataMeterFilterConditionOperation.Contains => "CONTAINS",
                DataMeterFilterConditionOperation.StartsWith => "STARTS_WITH",
                DataMeterFilterConditionOperation.EndsWith => "ENDS_WITH",
                DataMeterFilterConditionOperation.In => "IN",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The meter type for the feature
/// </summary>
[JsonConverter(typeof(DataMeterTypeConverter))]
public enum DataMeterType
{
    None,
    Fluctuating,
    Incremental,
}

sealed class DataMeterTypeConverter : JsonConverter<DataMeterType>
{
    public override DataMeterType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "None" => DataMeterType.None,
            "FLUCTUATING" => DataMeterType.Fluctuating,
            "INCREMENTAL" => DataMeterType.Incremental,
            _ => (DataMeterType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DataMeterType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DataMeterType.None => "None",
                DataMeterType.Fluctuating => "FLUCTUATING",
                DataMeterType.Incremental => "INCREMENTAL",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Unit transformation to be applied to the reported usage
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DataUnitTransformation, DataUnitTransformationFromRaw>))]
public sealed record class DataUnitTransformation : JsonModel
{
    /// <summary>
    /// Divide usage by this number
    /// </summary>
    public required double Divide
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("divide");
        }
        init { this._rawData.Set("divide", value); }
    }

    /// <summary>
    /// Singular feature units after the transformation
    /// </summary>
    public required string? FeatureUnits
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("featureUnits");
        }
        init { this._rawData.Set("featureUnits", value); }
    }

    /// <summary>
    /// Plural feature units after the transformation
    /// </summary>
    public required string? FeatureUnitsPlural
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("featureUnitsPlural");
        }
        init { this._rawData.Set("featureUnitsPlural", value); }
    }

    /// <summary>
    /// After division, either round the result up or down
    /// </summary>
    public required ApiEnum<string, DataUnitTransformationRound> Round
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, DataUnitTransformationRound>>(
                "round"
            );
        }
        init { this._rawData.Set("round", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Divide;
        _ = this.FeatureUnits;
        _ = this.FeatureUnitsPlural;
        this.Round.Validate();
    }

    public DataUnitTransformation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DataUnitTransformation(DataUnitTransformation dataUnitTransformation)
        : base(dataUnitTransformation) { }
#pragma warning restore CS8618

    public DataUnitTransformation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DataUnitTransformation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataUnitTransformationFromRaw.FromRawUnchecked"/>
    public static DataUnitTransformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataUnitTransformationFromRaw : IFromRawJson<DataUnitTransformation>
{
    /// <inheritdoc/>
    public DataUnitTransformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DataUnitTransformation.FromRawUnchecked(rawData);
}

/// <summary>
/// After division, either round the result up or down
/// </summary>
[JsonConverter(typeof(DataUnitTransformationRoundConverter))]
public enum DataUnitTransformationRound
{
    Up,
    Down,
}

sealed class DataUnitTransformationRoundConverter : JsonConverter<DataUnitTransformationRound>
{
    public override DataUnitTransformationRound Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "UP" => DataUnitTransformationRound.Up,
            "DOWN" => DataUnitTransformationRound.Down,
            _ => (DataUnitTransformationRound)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DataUnitTransformationRound value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DataUnitTransformationRound.Up => "UP",
                DataUnitTransformationRound.Down => "DOWN",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
