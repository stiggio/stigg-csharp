using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;

namespace Stigg.Client.Models.V1.Features;

/// <summary>
/// Updates an existing feature's properties such as display name, description, and configuration.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class FeatureUpdateFeatureParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

    /// <summary>
    /// The description for the feature
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("description", value);
        }
    }

    /// <summary>
    /// The display name for the feature
    /// </summary>
    public string? DisplayName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("displayName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("displayName", value);
        }
    }

    /// <summary>
    /// The configuration data for the feature
    /// </summary>
    public IReadOnlyList<FeatureUpdateFeatureParamsEnumConfiguration>? EnumConfiguration
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<
                ImmutableArray<FeatureUpdateFeatureParamsEnumConfiguration>
            >("enumConfiguration");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<FeatureUpdateFeatureParamsEnumConfiguration>?>(
                "enumConfiguration",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The units for the feature
    /// </summary>
    public string? FeatureUnits
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("featureUnits");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("featureUnits", value);
        }
    }

    /// <summary>
    /// The plural units for the feature
    /// </summary>
    public string? FeatureUnitsPlural
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("featureUnitsPlural");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("featureUnitsPlural", value);
        }
    }

    /// <summary>
    /// The additional metadata for the feature
    /// </summary>
    public IReadOnlyDictionary<string, string>? Metadata
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<FrozenDictionary<string, string>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public Meter? Meter
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Meter>("meter");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("meter", value);
        }
    }

    /// <summary>
    /// Unit transformation to be applied to the reported usage
    /// </summary>
    public FeatureUpdateFeatureParamsUnitTransformation? UnitTransformation
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FeatureUpdateFeatureParamsUnitTransformation>(
                "unitTransformation"
            );
        }
        init { this._rawBodyData.Set("unitTransformation", value); }
    }

    public FeatureUpdateFeatureParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FeatureUpdateFeatureParams(FeatureUpdateFeatureParams featureUpdateFeatureParams)
        : base(featureUpdateFeatureParams)
    {
        this.ID = featureUpdateFeatureParams.ID;

        this._rawBodyData = new(featureUpdateFeatureParams._rawBodyData);
    }
#pragma warning restore CS8618

    public FeatureUpdateFeatureParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FeatureUpdateFeatureParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static FeatureUpdateFeatureParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["ID"] = JsonSerializer.SerializeToElement(this.ID),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(FeatureUpdateFeatureParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ID?.Equals(other.ID) ?? other.ID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/api/v1/features/{0}", this.ID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        FeatureUpdateFeatureParamsEnumConfiguration,
        FeatureUpdateFeatureParamsEnumConfigurationFromRaw
    >)
)]
public sealed record class FeatureUpdateFeatureParamsEnumConfiguration : JsonModel
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

    public FeatureUpdateFeatureParamsEnumConfiguration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FeatureUpdateFeatureParamsEnumConfiguration(
        FeatureUpdateFeatureParamsEnumConfiguration featureUpdateFeatureParamsEnumConfiguration
    )
        : base(featureUpdateFeatureParamsEnumConfiguration) { }
#pragma warning restore CS8618

    public FeatureUpdateFeatureParamsEnumConfiguration(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FeatureUpdateFeatureParamsEnumConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FeatureUpdateFeatureParamsEnumConfigurationFromRaw.FromRawUnchecked"/>
    public static FeatureUpdateFeatureParamsEnumConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FeatureUpdateFeatureParamsEnumConfigurationFromRaw
    : IFromRawJson<FeatureUpdateFeatureParamsEnumConfiguration>
{
    /// <inheritdoc/>
    public FeatureUpdateFeatureParamsEnumConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FeatureUpdateFeatureParamsEnumConfiguration.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Meter, MeterFromRaw>))]
public sealed record class Meter : JsonModel
{
    public required Aggregation Aggregation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Aggregation>("aggregation");
        }
        init { this._rawData.Set("aggregation", value); }
    }

    public required IReadOnlyList<Filter> Filters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Filter>>("filters");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Filter>>(
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

    public Meter() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Meter(Meter meter)
        : base(meter) { }
#pragma warning restore CS8618

    public Meter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Meter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MeterFromRaw.FromRawUnchecked"/>
    public static Meter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MeterFromRaw : IFromRawJson<Meter>
{
    /// <inheritdoc/>
    public Meter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Meter.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Aggregation, AggregationFromRaw>))]
public sealed record class Aggregation : JsonModel
{
    public required ApiEnum<string, Function> Function
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Function>>("function");
        }
        init { this._rawData.Set("function", value); }
    }

    public string? Field
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("field");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("field", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Function.Validate();
        _ = this.Field;
    }

    public Aggregation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Aggregation(Aggregation aggregation)
        : base(aggregation) { }
#pragma warning restore CS8618

    public Aggregation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Aggregation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AggregationFromRaw.FromRawUnchecked"/>
    public static Aggregation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Aggregation(ApiEnum<string, Function> function)
        : this()
    {
        this.Function = function;
    }
}

class AggregationFromRaw : IFromRawJson<Aggregation>
{
    /// <inheritdoc/>
    public Aggregation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Aggregation.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(FunctionConverter))]
public enum Function
{
    Sum,
    Max,
    Min,
    Avg,
    Count,
    Unique,
}

sealed class FunctionConverter : JsonConverter<Function>
{
    public override Function Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SUM" => Function.Sum,
            "MAX" => Function.Max,
            "MIN" => Function.Min,
            "AVG" => Function.Avg,
            "COUNT" => Function.Count,
            "UNIQUE" => Function.Unique,
            _ => (Function)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Function value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Function.Sum => "SUM",
                Function.Max => "MAX",
                Function.Min => "MIN",
                Function.Avg => "AVG",
                Function.Count => "COUNT",
                Function.Unique => "UNIQUE",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<Filter, FilterFromRaw>))]
public sealed record class Filter : JsonModel
{
    public required IReadOnlyList<Condition> Conditions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Condition>>("conditions");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Condition>>(
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

    public Filter() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Filter(Filter filter)
        : base(filter) { }
#pragma warning restore CS8618

    public Filter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Filter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FilterFromRaw.FromRawUnchecked"/>
    public static Filter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Filter(IReadOnlyList<Condition> conditions)
        : this()
    {
        this.Conditions = conditions;
    }
}

class FilterFromRaw : IFromRawJson<Filter>
{
    /// <inheritdoc/>
    public Filter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Filter.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Condition, ConditionFromRaw>))]
public sealed record class Condition : JsonModel
{
    public required string Field
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("field");
        }
        init { this._rawData.Set("field", value); }
    }

    public required ApiEnum<string, Operation> Operation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Operation>>("operation");
        }
        init { this._rawData.Set("operation", value); }
    }

    public string? Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("value");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("value", value);
        }
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
            if (value == null)
            {
                return;
            }

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

    public Condition() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Condition(Condition condition)
        : base(condition) { }
#pragma warning restore CS8618

    public Condition(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Condition(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConditionFromRaw.FromRawUnchecked"/>
    public static Condition FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConditionFromRaw : IFromRawJson<Condition>
{
    /// <inheritdoc/>
    public Condition FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Condition.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(OperationConverter))]
public enum Operation
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

sealed class OperationConverter : JsonConverter<Operation>
{
    public override Operation Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "EQUALS" => Operation.Equals,
            "NOT_EQUALS" => Operation.NotEquals,
            "GREATER_THAN" => Operation.GreaterThan,
            "GREATER_THAN_OR_EQUAL" => Operation.GreaterThanOrEqual,
            "LESS_THAN" => Operation.LessThan,
            "LESS_THAN_OR_EQUAL" => Operation.LessThanOrEqual,
            "IS_NULL" => Operation.IsNull,
            "IS_NOT_NULL" => Operation.IsNotNull,
            "CONTAINS" => Operation.Contains,
            "STARTS_WITH" => Operation.StartsWith,
            "ENDS_WITH" => Operation.EndsWith,
            "IN" => Operation.In,
            _ => (Operation)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Operation value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Operation.Equals => "EQUALS",
                Operation.NotEquals => "NOT_EQUALS",
                Operation.GreaterThan => "GREATER_THAN",
                Operation.GreaterThanOrEqual => "GREATER_THAN_OR_EQUAL",
                Operation.LessThan => "LESS_THAN",
                Operation.LessThanOrEqual => "LESS_THAN_OR_EQUAL",
                Operation.IsNull => "IS_NULL",
                Operation.IsNotNull => "IS_NOT_NULL",
                Operation.Contains => "CONTAINS",
                Operation.StartsWith => "STARTS_WITH",
                Operation.EndsWith => "ENDS_WITH",
                Operation.In => "IN",
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
[JsonConverter(
    typeof(JsonModelConverter<
        FeatureUpdateFeatureParamsUnitTransformation,
        FeatureUpdateFeatureParamsUnitTransformationFromRaw
    >)
)]
public sealed record class FeatureUpdateFeatureParamsUnitTransformation : JsonModel
{
    /// <summary>
    /// Divide usage by this number
    /// </summary>
    public required long Divide
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("divide");
        }
        init { this._rawData.Set("divide", value); }
    }

    /// <summary>
    /// Singular feature units after the transformation
    /// </summary>
    public string? FeatureUnits
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("featureUnits");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("featureUnits", value);
        }
    }

    /// <summary>
    /// Plural feature units after the transformation
    /// </summary>
    public string? FeatureUnitsPlural
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("featureUnitsPlural");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("featureUnitsPlural", value);
        }
    }

    /// <summary>
    /// After division, either round the result up or down
    /// </summary>
    public ApiEnum<string, FeatureUpdateFeatureParamsUnitTransformationRound>? Round
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, FeatureUpdateFeatureParamsUnitTransformationRound>
            >("round");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("round", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Divide;
        _ = this.FeatureUnits;
        _ = this.FeatureUnitsPlural;
        this.Round?.Validate();
    }

    public FeatureUpdateFeatureParamsUnitTransformation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FeatureUpdateFeatureParamsUnitTransformation(
        FeatureUpdateFeatureParamsUnitTransformation featureUpdateFeatureParamsUnitTransformation
    )
        : base(featureUpdateFeatureParamsUnitTransformation) { }
#pragma warning restore CS8618

    public FeatureUpdateFeatureParamsUnitTransformation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FeatureUpdateFeatureParamsUnitTransformation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FeatureUpdateFeatureParamsUnitTransformationFromRaw.FromRawUnchecked"/>
    public static FeatureUpdateFeatureParamsUnitTransformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FeatureUpdateFeatureParamsUnitTransformation(long divide)
        : this()
    {
        this.Divide = divide;
    }
}

class FeatureUpdateFeatureParamsUnitTransformationFromRaw
    : IFromRawJson<FeatureUpdateFeatureParamsUnitTransformation>
{
    /// <inheritdoc/>
    public FeatureUpdateFeatureParamsUnitTransformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FeatureUpdateFeatureParamsUnitTransformation.FromRawUnchecked(rawData);
}

/// <summary>
/// After division, either round the result up or down
/// </summary>
[JsonConverter(typeof(FeatureUpdateFeatureParamsUnitTransformationRoundConverter))]
public enum FeatureUpdateFeatureParamsUnitTransformationRound
{
    Up,
    Down,
}

sealed class FeatureUpdateFeatureParamsUnitTransformationRoundConverter
    : JsonConverter<FeatureUpdateFeatureParamsUnitTransformationRound>
{
    public override FeatureUpdateFeatureParamsUnitTransformationRound Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "UP" => FeatureUpdateFeatureParamsUnitTransformationRound.Up,
            "DOWN" => FeatureUpdateFeatureParamsUnitTransformationRound.Down,
            _ => (FeatureUpdateFeatureParamsUnitTransformationRound)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FeatureUpdateFeatureParamsUnitTransformationRound value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FeatureUpdateFeatureParamsUnitTransformationRound.Up => "UP",
                FeatureUpdateFeatureParamsUnitTransformationRound.Down => "DOWN",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
