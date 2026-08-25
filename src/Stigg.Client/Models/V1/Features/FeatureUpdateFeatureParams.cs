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

    /// <summary>
    /// Event meter that turns reported events into usage for a metered feature
    /// </summary>
    public FeatureUpdateFeatureParamsMeter? Meter
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FeatureUpdateFeatureParamsMeter>("meter");
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

    public string? XAccountID
    {
        get
        {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNullableClass<string>("X-ACCOUNT-ID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawHeaderData.Set("X-ACCOUNT-ID", value);
        }
    }

    public string? XEnvironmentID
    {
        get
        {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNullableClass<string>("X-ENVIRONMENT-ID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawHeaderData.Set("X-ENVIRONMENT-ID", value);
        }
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
        FrozenDictionary<string, JsonElement> rawBodyData,
        string id
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.ID = id;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static FeatureUpdateFeatureParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string id
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            id
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

/// <summary>
/// Event meter that turns reported events into usage for a metered feature
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        FeatureUpdateFeatureParamsMeter,
        FeatureUpdateFeatureParamsMeterFromRaw
    >)
)]
public sealed record class FeatureUpdateFeatureParamsMeter : JsonModel
{
    /// <summary>
    /// How the matching events are aggregated into a usage value
    /// </summary>
    public required FeatureUpdateFeatureParamsMeterAggregation Aggregation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FeatureUpdateFeatureParamsMeterAggregation>(
                "aggregation"
            );
        }
        init { this._rawData.Set("aggregation", value); }
    }

    /// <summary>
    /// Event filters. Conditions within a filter are ANDed, and filters are ORed
    /// </summary>
    public required IReadOnlyList<FeatureUpdateFeatureParamsMeterFilter> Filters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<FeatureUpdateFeatureParamsMeterFilter>
            >("filters");
        }
        init
        {
            this._rawData.Set<ImmutableArray<FeatureUpdateFeatureParamsMeterFilter>>(
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

    public FeatureUpdateFeatureParamsMeter() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FeatureUpdateFeatureParamsMeter(
        FeatureUpdateFeatureParamsMeter featureUpdateFeatureParamsMeter
    )
        : base(featureUpdateFeatureParamsMeter) { }
#pragma warning restore CS8618

    public FeatureUpdateFeatureParamsMeter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FeatureUpdateFeatureParamsMeter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FeatureUpdateFeatureParamsMeterFromRaw.FromRawUnchecked"/>
    public static FeatureUpdateFeatureParamsMeter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FeatureUpdateFeatureParamsMeterFromRaw : IFromRawJson<FeatureUpdateFeatureParamsMeter>
{
    /// <inheritdoc/>
    public FeatureUpdateFeatureParamsMeter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FeatureUpdateFeatureParamsMeter.FromRawUnchecked(rawData);
}

/// <summary>
/// How the matching events are aggregated into a usage value
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        FeatureUpdateFeatureParamsMeterAggregation,
        FeatureUpdateFeatureParamsMeterAggregationFromRaw
    >)
)]
public sealed record class FeatureUpdateFeatureParamsMeterAggregation : JsonModel
{
    /// <summary>
    /// Aggregation function applied to the matching events
    /// </summary>
    public required ApiEnum<string, FeatureUpdateFeatureParamsMeterAggregationFunction> Function
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, FeatureUpdateFeatureParamsMeterAggregationFunction>
            >("function");
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

    public FeatureUpdateFeatureParamsMeterAggregation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FeatureUpdateFeatureParamsMeterAggregation(
        FeatureUpdateFeatureParamsMeterAggregation featureUpdateFeatureParamsMeterAggregation
    )
        : base(featureUpdateFeatureParamsMeterAggregation) { }
#pragma warning restore CS8618

    public FeatureUpdateFeatureParamsMeterAggregation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FeatureUpdateFeatureParamsMeterAggregation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FeatureUpdateFeatureParamsMeterAggregationFromRaw.FromRawUnchecked"/>
    public static FeatureUpdateFeatureParamsMeterAggregation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FeatureUpdateFeatureParamsMeterAggregation(
        ApiEnum<string, FeatureUpdateFeatureParamsMeterAggregationFunction> function
    )
        : this()
    {
        this.Function = function;
    }
}

class FeatureUpdateFeatureParamsMeterAggregationFromRaw
    : IFromRawJson<FeatureUpdateFeatureParamsMeterAggregation>
{
    /// <inheritdoc/>
    public FeatureUpdateFeatureParamsMeterAggregation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FeatureUpdateFeatureParamsMeterAggregation.FromRawUnchecked(rawData);
}

/// <summary>
/// Aggregation function applied to the matching events
/// </summary>
[JsonConverter(typeof(FeatureUpdateFeatureParamsMeterAggregationFunctionConverter))]
public enum FeatureUpdateFeatureParamsMeterAggregationFunction
{
    Sum,
    Max,
    Min,
    Avg,
    Count,
    Unique,
}

sealed class FeatureUpdateFeatureParamsMeterAggregationFunctionConverter
    : JsonConverter<FeatureUpdateFeatureParamsMeterAggregationFunction>
{
    public override FeatureUpdateFeatureParamsMeterAggregationFunction Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SUM" => FeatureUpdateFeatureParamsMeterAggregationFunction.Sum,
            "MAX" => FeatureUpdateFeatureParamsMeterAggregationFunction.Max,
            "MIN" => FeatureUpdateFeatureParamsMeterAggregationFunction.Min,
            "AVG" => FeatureUpdateFeatureParamsMeterAggregationFunction.Avg,
            "COUNT" => FeatureUpdateFeatureParamsMeterAggregationFunction.Count,
            "UNIQUE" => FeatureUpdateFeatureParamsMeterAggregationFunction.Unique,
            _ => (FeatureUpdateFeatureParamsMeterAggregationFunction)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FeatureUpdateFeatureParamsMeterAggregationFunction value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FeatureUpdateFeatureParamsMeterAggregationFunction.Sum => "SUM",
                FeatureUpdateFeatureParamsMeterAggregationFunction.Max => "MAX",
                FeatureUpdateFeatureParamsMeterAggregationFunction.Min => "MIN",
                FeatureUpdateFeatureParamsMeterAggregationFunction.Avg => "AVG",
                FeatureUpdateFeatureParamsMeterAggregationFunction.Count => "COUNT",
                FeatureUpdateFeatureParamsMeterAggregationFunction.Unique => "UNIQUE",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        FeatureUpdateFeatureParamsMeterFilter,
        FeatureUpdateFeatureParamsMeterFilterFromRaw
    >)
)]
public sealed record class FeatureUpdateFeatureParamsMeterFilter : JsonModel
{
    /// <summary>
    /// Conditions the event must match
    /// </summary>
    public required IReadOnlyList<FeatureUpdateFeatureParamsMeterFilterCondition> Conditions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<FeatureUpdateFeatureParamsMeterFilterCondition>
            >("conditions");
        }
        init
        {
            this._rawData.Set<ImmutableArray<FeatureUpdateFeatureParamsMeterFilterCondition>>(
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

    public FeatureUpdateFeatureParamsMeterFilter() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FeatureUpdateFeatureParamsMeterFilter(
        FeatureUpdateFeatureParamsMeterFilter featureUpdateFeatureParamsMeterFilter
    )
        : base(featureUpdateFeatureParamsMeterFilter) { }
#pragma warning restore CS8618

    public FeatureUpdateFeatureParamsMeterFilter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FeatureUpdateFeatureParamsMeterFilter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FeatureUpdateFeatureParamsMeterFilterFromRaw.FromRawUnchecked"/>
    public static FeatureUpdateFeatureParamsMeterFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FeatureUpdateFeatureParamsMeterFilter(
        IReadOnlyList<FeatureUpdateFeatureParamsMeterFilterCondition> conditions
    )
        : this()
    {
        this.Conditions = conditions;
    }
}

class FeatureUpdateFeatureParamsMeterFilterFromRaw
    : IFromRawJson<FeatureUpdateFeatureParamsMeterFilter>
{
    /// <inheritdoc/>
    public FeatureUpdateFeatureParamsMeterFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FeatureUpdateFeatureParamsMeterFilter.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        FeatureUpdateFeatureParamsMeterFilterCondition,
        FeatureUpdateFeatureParamsMeterFilterConditionFromRaw
    >)
)]
public sealed record class FeatureUpdateFeatureParamsMeterFilterCondition : JsonModel
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
    public required ApiEnum<
        string,
        FeatureUpdateFeatureParamsMeterFilterConditionOperation
    > Operation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, FeatureUpdateFeatureParamsMeterFilterConditionOperation>
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

    public FeatureUpdateFeatureParamsMeterFilterCondition() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FeatureUpdateFeatureParamsMeterFilterCondition(
        FeatureUpdateFeatureParamsMeterFilterCondition featureUpdateFeatureParamsMeterFilterCondition
    )
        : base(featureUpdateFeatureParamsMeterFilterCondition) { }
#pragma warning restore CS8618

    public FeatureUpdateFeatureParamsMeterFilterCondition(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FeatureUpdateFeatureParamsMeterFilterCondition(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FeatureUpdateFeatureParamsMeterFilterConditionFromRaw.FromRawUnchecked"/>
    public static FeatureUpdateFeatureParamsMeterFilterCondition FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FeatureUpdateFeatureParamsMeterFilterConditionFromRaw
    : IFromRawJson<FeatureUpdateFeatureParamsMeterFilterCondition>
{
    /// <inheritdoc/>
    public FeatureUpdateFeatureParamsMeterFilterCondition FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FeatureUpdateFeatureParamsMeterFilterCondition.FromRawUnchecked(rawData);
}

/// <summary>
/// Comparison applied to the condition field
/// </summary>
[JsonConverter(typeof(FeatureUpdateFeatureParamsMeterFilterConditionOperationConverter))]
public enum FeatureUpdateFeatureParamsMeterFilterConditionOperation
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

sealed class FeatureUpdateFeatureParamsMeterFilterConditionOperationConverter
    : JsonConverter<FeatureUpdateFeatureParamsMeterFilterConditionOperation>
{
    public override FeatureUpdateFeatureParamsMeterFilterConditionOperation Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "EQUALS" => FeatureUpdateFeatureParamsMeterFilterConditionOperation.Equals,
            "NOT_EQUALS" => FeatureUpdateFeatureParamsMeterFilterConditionOperation.NotEquals,
            "GREATER_THAN" => FeatureUpdateFeatureParamsMeterFilterConditionOperation.GreaterThan,
            "GREATER_THAN_OR_EQUAL" =>
                FeatureUpdateFeatureParamsMeterFilterConditionOperation.GreaterThanOrEqual,
            "LESS_THAN" => FeatureUpdateFeatureParamsMeterFilterConditionOperation.LessThan,
            "LESS_THAN_OR_EQUAL" =>
                FeatureUpdateFeatureParamsMeterFilterConditionOperation.LessThanOrEqual,
            "IS_NULL" => FeatureUpdateFeatureParamsMeterFilterConditionOperation.IsNull,
            "IS_NOT_NULL" => FeatureUpdateFeatureParamsMeterFilterConditionOperation.IsNotNull,
            "CONTAINS" => FeatureUpdateFeatureParamsMeterFilterConditionOperation.Contains,
            "STARTS_WITH" => FeatureUpdateFeatureParamsMeterFilterConditionOperation.StartsWith,
            "ENDS_WITH" => FeatureUpdateFeatureParamsMeterFilterConditionOperation.EndsWith,
            "IN" => FeatureUpdateFeatureParamsMeterFilterConditionOperation.In,
            _ => (FeatureUpdateFeatureParamsMeterFilterConditionOperation)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FeatureUpdateFeatureParamsMeterFilterConditionOperation value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FeatureUpdateFeatureParamsMeterFilterConditionOperation.Equals => "EQUALS",
                FeatureUpdateFeatureParamsMeterFilterConditionOperation.NotEquals => "NOT_EQUALS",
                FeatureUpdateFeatureParamsMeterFilterConditionOperation.GreaterThan =>
                    "GREATER_THAN",
                FeatureUpdateFeatureParamsMeterFilterConditionOperation.GreaterThanOrEqual =>
                    "GREATER_THAN_OR_EQUAL",
                FeatureUpdateFeatureParamsMeterFilterConditionOperation.LessThan => "LESS_THAN",
                FeatureUpdateFeatureParamsMeterFilterConditionOperation.LessThanOrEqual =>
                    "LESS_THAN_OR_EQUAL",
                FeatureUpdateFeatureParamsMeterFilterConditionOperation.IsNull => "IS_NULL",
                FeatureUpdateFeatureParamsMeterFilterConditionOperation.IsNotNull => "IS_NOT_NULL",
                FeatureUpdateFeatureParamsMeterFilterConditionOperation.Contains => "CONTAINS",
                FeatureUpdateFeatureParamsMeterFilterConditionOperation.StartsWith => "STARTS_WITH",
                FeatureUpdateFeatureParamsMeterFilterConditionOperation.EndsWith => "ENDS_WITH",
                FeatureUpdateFeatureParamsMeterFilterConditionOperation.In => "IN",
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
