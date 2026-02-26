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
/// Creates a new feature with the specified type, metering, and configuration.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class FeatureCreateFeatureParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The unique identifier for the feature
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("id");
        }
        init { this._rawBodyData.Set("id", value); }
    }

    /// <summary>
    /// The display name for the feature
    /// </summary>
    public required string DisplayName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("displayName");
        }
        init { this._rawBodyData.Set("displayName", value); }
    }

    /// <summary>
    /// The type of the feature
    /// </summary>
    public required ApiEnum<string, FeatureType> FeatureType
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, FeatureType>>("featureType");
        }
        init { this._rawBodyData.Set("featureType", value); }
    }

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
    /// The configuration data for the feature
    /// </summary>
    public IReadOnlyList<EnumConfiguration>? EnumConfiguration
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<EnumConfiguration>>(
                "enumConfiguration"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<EnumConfiguration>?>(
                "enumConfiguration",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The status of the feature
    /// </summary>
    public ApiEnum<string, FeatureStatus>? FeatureStatus
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, FeatureStatus>>(
                "featureStatus"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("featureStatus", value);
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
    /// The meter type for the feature
    /// </summary>
    public ApiEnum<string, MeterType>? MeterType
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, MeterType>>("meterType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("meterType", value);
        }
    }

    /// <summary>
    /// Unit transformation to be applied to the reported usage
    /// </summary>
    public UnitTransformation? UnitTransformation
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<UnitTransformation>("unitTransformation");
        }
        init { this._rawBodyData.Set("unitTransformation", value); }
    }

    public FeatureCreateFeatureParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FeatureCreateFeatureParams(FeatureCreateFeatureParams featureCreateFeatureParams)
        : base(featureCreateFeatureParams)
    {
        this._rawBodyData = new(featureCreateFeatureParams._rawBodyData);
    }
#pragma warning restore CS8618

    public FeatureCreateFeatureParams(
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
    FeatureCreateFeatureParams(
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
    public static FeatureCreateFeatureParams FromRawUnchecked(
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

    public virtual bool Equals(FeatureCreateFeatureParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/api/v1/features")
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

/// <summary>
/// The type of the feature
/// </summary>
[JsonConverter(typeof(FeatureTypeConverter))]
public enum FeatureType
{
    Boolean,
    Number,
    Enum,
}

sealed class FeatureTypeConverter : JsonConverter<FeatureType>
{
    public override FeatureType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "BOOLEAN" => FeatureType.Boolean,
            "NUMBER" => FeatureType.Number,
            "ENUM" => FeatureType.Enum,
            _ => (FeatureType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FeatureType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FeatureType.Boolean => "BOOLEAN",
                FeatureType.Number => "NUMBER",
                FeatureType.Enum => "ENUM",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<EnumConfiguration, EnumConfigurationFromRaw>))]
public sealed record class EnumConfiguration : JsonModel
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

    public EnumConfiguration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EnumConfiguration(EnumConfiguration enumConfiguration)
        : base(enumConfiguration) { }
#pragma warning restore CS8618

    public EnumConfiguration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EnumConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EnumConfigurationFromRaw.FromRawUnchecked"/>
    public static EnumConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EnumConfigurationFromRaw : IFromRawJson<EnumConfiguration>
{
    /// <inheritdoc/>
    public EnumConfiguration FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        EnumConfiguration.FromRawUnchecked(rawData);
}

/// <summary>
/// The status of the feature
/// </summary>
[JsonConverter(typeof(FeatureStatusConverter))]
public enum FeatureStatus
{
    New,
    Suspended,
    Active,
}

sealed class FeatureStatusConverter : JsonConverter<FeatureStatus>
{
    public override FeatureStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "NEW" => FeatureStatus.New,
            "SUSPENDED" => FeatureStatus.Suspended,
            "ACTIVE" => FeatureStatus.Active,
            _ => (FeatureStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FeatureStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FeatureStatus.New => "NEW",
                FeatureStatus.Suspended => "SUSPENDED",
                FeatureStatus.Active => "ACTIVE",
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
[JsonConverter(typeof(MeterTypeConverter))]
public enum MeterType
{
    None,
    Fluctuating,
    Incremental,
}

sealed class MeterTypeConverter : JsonConverter<MeterType>
{
    public override MeterType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "None" => MeterType.None,
            "FLUCTUATING" => MeterType.Fluctuating,
            "INCREMENTAL" => MeterType.Incremental,
            _ => (MeterType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MeterType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MeterType.None => "None",
                MeterType.Fluctuating => "FLUCTUATING",
                MeterType.Incremental => "INCREMENTAL",
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
[JsonConverter(typeof(JsonModelConverter<UnitTransformation, UnitTransformationFromRaw>))]
public sealed record class UnitTransformation : JsonModel
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
    public ApiEnum<string, Round>? Round
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Round>>("round");
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

    public UnitTransformation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UnitTransformation(UnitTransformation unitTransformation)
        : base(unitTransformation) { }
#pragma warning restore CS8618

    public UnitTransformation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnitTransformation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UnitTransformationFromRaw.FromRawUnchecked"/>
    public static UnitTransformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UnitTransformation(long divide)
        : this()
    {
        this.Divide = divide;
    }
}

class UnitTransformationFromRaw : IFromRawJson<UnitTransformation>
{
    /// <inheritdoc/>
    public UnitTransformation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UnitTransformation.FromRawUnchecked(rawData);
}

/// <summary>
/// After division, either round the result up or down
/// </summary>
[JsonConverter(typeof(RoundConverter))]
public enum Round
{
    Up,
    Down,
}

sealed class RoundConverter : JsonConverter<Round>
{
    public override Round Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "UP" => Round.Up,
            "DOWN" => Round.Down,
            _ => (Round)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Round value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Round.Up => "UP",
                Round.Down => "DOWN",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
