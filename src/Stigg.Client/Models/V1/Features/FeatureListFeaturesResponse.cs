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
/// Feature configuration object
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<FeatureListFeaturesResponse, FeatureListFeaturesResponseFromRaw>)
)]
public sealed record class FeatureListFeaturesResponse : JsonModel
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
    public required IReadOnlyList<FeatureListFeaturesResponseEnumConfiguration>? EnumConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<FeatureListFeaturesResponseEnumConfiguration>
            >("enumConfiguration");
        }
        init
        {
            this._rawData.Set<ImmutableArray<FeatureListFeaturesResponseEnumConfiguration>?>(
                "enumConfiguration",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The status of the feature
    /// </summary>
    public required ApiEnum<string, FeatureListFeaturesResponseFeatureStatus> FeatureStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, FeatureListFeaturesResponseFeatureStatus>
            >("featureStatus");
        }
        init { this._rawData.Set("featureStatus", value); }
    }

    /// <summary>
    /// The type of the feature
    /// </summary>
    public required ApiEnum<string, FeatureListFeaturesResponseFeatureType> FeatureType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, FeatureListFeaturesResponseFeatureType>
            >("featureType");
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
    /// The meter type for the feature
    /// </summary>
    public required ApiEnum<string, FeatureListFeaturesResponseMeterType> MeterType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, FeatureListFeaturesResponseMeterType>
            >("meterType");
        }
        init { this._rawData.Set("meterType", value); }
    }

    /// <summary>
    /// Unit transformation to be applied to the reported usage
    /// </summary>
    public required FeatureListFeaturesResponseUnitTransformation? UnitTransformation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FeatureListFeaturesResponseUnitTransformation>(
                "unitTransformation"
            );
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
        this.MeterType.Validate();
        this.UnitTransformation?.Validate();
        _ = this.UpdatedAt;
    }

    public FeatureListFeaturesResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FeatureListFeaturesResponse(FeatureListFeaturesResponse featureListFeaturesResponse)
        : base(featureListFeaturesResponse) { }
#pragma warning restore CS8618

    public FeatureListFeaturesResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FeatureListFeaturesResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FeatureListFeaturesResponseFromRaw.FromRawUnchecked"/>
    public static FeatureListFeaturesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FeatureListFeaturesResponseFromRaw : IFromRawJson<FeatureListFeaturesResponse>
{
    /// <inheritdoc/>
    public FeatureListFeaturesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FeatureListFeaturesResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        FeatureListFeaturesResponseEnumConfiguration,
        FeatureListFeaturesResponseEnumConfigurationFromRaw
    >)
)]
public sealed record class FeatureListFeaturesResponseEnumConfiguration : JsonModel
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

    public FeatureListFeaturesResponseEnumConfiguration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FeatureListFeaturesResponseEnumConfiguration(
        FeatureListFeaturesResponseEnumConfiguration featureListFeaturesResponseEnumConfiguration
    )
        : base(featureListFeaturesResponseEnumConfiguration) { }
#pragma warning restore CS8618

    public FeatureListFeaturesResponseEnumConfiguration(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FeatureListFeaturesResponseEnumConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FeatureListFeaturesResponseEnumConfigurationFromRaw.FromRawUnchecked"/>
    public static FeatureListFeaturesResponseEnumConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FeatureListFeaturesResponseEnumConfigurationFromRaw
    : IFromRawJson<FeatureListFeaturesResponseEnumConfiguration>
{
    /// <inheritdoc/>
    public FeatureListFeaturesResponseEnumConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FeatureListFeaturesResponseEnumConfiguration.FromRawUnchecked(rawData);
}

/// <summary>
/// The status of the feature
/// </summary>
[JsonConverter(typeof(FeatureListFeaturesResponseFeatureStatusConverter))]
public enum FeatureListFeaturesResponseFeatureStatus
{
    New,
    Suspended,
    Active,
}

sealed class FeatureListFeaturesResponseFeatureStatusConverter
    : JsonConverter<FeatureListFeaturesResponseFeatureStatus>
{
    public override FeatureListFeaturesResponseFeatureStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "NEW" => FeatureListFeaturesResponseFeatureStatus.New,
            "SUSPENDED" => FeatureListFeaturesResponseFeatureStatus.Suspended,
            "ACTIVE" => FeatureListFeaturesResponseFeatureStatus.Active,
            _ => (FeatureListFeaturesResponseFeatureStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FeatureListFeaturesResponseFeatureStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FeatureListFeaturesResponseFeatureStatus.New => "NEW",
                FeatureListFeaturesResponseFeatureStatus.Suspended => "SUSPENDED",
                FeatureListFeaturesResponseFeatureStatus.Active => "ACTIVE",
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
[JsonConverter(typeof(FeatureListFeaturesResponseFeatureTypeConverter))]
public enum FeatureListFeaturesResponseFeatureType
{
    Boolean,
    Number,
    Enum,
}

sealed class FeatureListFeaturesResponseFeatureTypeConverter
    : JsonConverter<FeatureListFeaturesResponseFeatureType>
{
    public override FeatureListFeaturesResponseFeatureType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "BOOLEAN" => FeatureListFeaturesResponseFeatureType.Boolean,
            "NUMBER" => FeatureListFeaturesResponseFeatureType.Number,
            "ENUM" => FeatureListFeaturesResponseFeatureType.Enum,
            _ => (FeatureListFeaturesResponseFeatureType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FeatureListFeaturesResponseFeatureType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FeatureListFeaturesResponseFeatureType.Boolean => "BOOLEAN",
                FeatureListFeaturesResponseFeatureType.Number => "NUMBER",
                FeatureListFeaturesResponseFeatureType.Enum => "ENUM",
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
[JsonConverter(typeof(FeatureListFeaturesResponseMeterTypeConverter))]
public enum FeatureListFeaturesResponseMeterType
{
    None,
    Fluctuating,
    Incremental,
}

sealed class FeatureListFeaturesResponseMeterTypeConverter
    : JsonConverter<FeatureListFeaturesResponseMeterType>
{
    public override FeatureListFeaturesResponseMeterType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "None" => FeatureListFeaturesResponseMeterType.None,
            "FLUCTUATING" => FeatureListFeaturesResponseMeterType.Fluctuating,
            "INCREMENTAL" => FeatureListFeaturesResponseMeterType.Incremental,
            _ => (FeatureListFeaturesResponseMeterType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FeatureListFeaturesResponseMeterType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FeatureListFeaturesResponseMeterType.None => "None",
                FeatureListFeaturesResponseMeterType.Fluctuating => "FLUCTUATING",
                FeatureListFeaturesResponseMeterType.Incremental => "INCREMENTAL",
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
        FeatureListFeaturesResponseUnitTransformation,
        FeatureListFeaturesResponseUnitTransformationFromRaw
    >)
)]
public sealed record class FeatureListFeaturesResponseUnitTransformation : JsonModel
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
    public required ApiEnum<string, FeatureListFeaturesResponseUnitTransformationRound> Round
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, FeatureListFeaturesResponseUnitTransformationRound>
            >("round");
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

    public FeatureListFeaturesResponseUnitTransformation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FeatureListFeaturesResponseUnitTransformation(
        FeatureListFeaturesResponseUnitTransformation featureListFeaturesResponseUnitTransformation
    )
        : base(featureListFeaturesResponseUnitTransformation) { }
#pragma warning restore CS8618

    public FeatureListFeaturesResponseUnitTransformation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FeatureListFeaturesResponseUnitTransformation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FeatureListFeaturesResponseUnitTransformationFromRaw.FromRawUnchecked"/>
    public static FeatureListFeaturesResponseUnitTransformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FeatureListFeaturesResponseUnitTransformationFromRaw
    : IFromRawJson<FeatureListFeaturesResponseUnitTransformation>
{
    /// <inheritdoc/>
    public FeatureListFeaturesResponseUnitTransformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FeatureListFeaturesResponseUnitTransformation.FromRawUnchecked(rawData);
}

/// <summary>
/// After division, either round the result up or down
/// </summary>
[JsonConverter(typeof(FeatureListFeaturesResponseUnitTransformationRoundConverter))]
public enum FeatureListFeaturesResponseUnitTransformationRound
{
    Up,
    Down,
}

sealed class FeatureListFeaturesResponseUnitTransformationRoundConverter
    : JsonConverter<FeatureListFeaturesResponseUnitTransformationRound>
{
    public override FeatureListFeaturesResponseUnitTransformationRound Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "UP" => FeatureListFeaturesResponseUnitTransformationRound.Up,
            "DOWN" => FeatureListFeaturesResponseUnitTransformationRound.Down,
            _ => (FeatureListFeaturesResponseUnitTransformationRound)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FeatureListFeaturesResponseUnitTransformationRound value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FeatureListFeaturesResponseUnitTransformationRound.Up => "UP",
                FeatureListFeaturesResponseUnitTransformationRound.Down => "DOWN",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
