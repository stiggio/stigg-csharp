using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;

namespace Stigg.Client.Models.V1.Events.Features;

/// <summary>
/// Response object
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<FeatureCreateFeatureResponse, FeatureCreateFeatureResponseFromRaw>)
)]
public sealed record class FeatureCreateFeatureResponse : JsonModel
{
    /// <summary>
    /// Feature configuration object
    /// </summary>
    public required FeatureCreateFeatureResponseData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FeatureCreateFeatureResponseData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public FeatureCreateFeatureResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FeatureCreateFeatureResponse(FeatureCreateFeatureResponse featureCreateFeatureResponse)
        : base(featureCreateFeatureResponse) { }
#pragma warning restore CS8618

    public FeatureCreateFeatureResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FeatureCreateFeatureResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FeatureCreateFeatureResponseFromRaw.FromRawUnchecked"/>
    public static FeatureCreateFeatureResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FeatureCreateFeatureResponse(FeatureCreateFeatureResponseData data)
        : this()
    {
        this.Data = data;
    }
}

class FeatureCreateFeatureResponseFromRaw : IFromRawJson<FeatureCreateFeatureResponse>
{
    /// <inheritdoc/>
    public FeatureCreateFeatureResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FeatureCreateFeatureResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Feature configuration object
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        FeatureCreateFeatureResponseData,
        FeatureCreateFeatureResponseDataFromRaw
    >)
)]
public sealed record class FeatureCreateFeatureResponseData : JsonModel
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
    public required IReadOnlyList<FeatureCreateFeatureResponseDataEnumConfiguration>? EnumConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<FeatureCreateFeatureResponseDataEnumConfiguration>
            >("enumConfiguration");
        }
        init
        {
            this._rawData.Set<ImmutableArray<FeatureCreateFeatureResponseDataEnumConfiguration>?>(
                "enumConfiguration",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The status of the feature
    /// </summary>
    public required ApiEnum<string, FeatureCreateFeatureResponseDataFeatureStatus> FeatureStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, FeatureCreateFeatureResponseDataFeatureStatus>
            >("featureStatus");
        }
        init { this._rawData.Set("featureStatus", value); }
    }

    /// <summary>
    /// The type of the feature
    /// </summary>
    public required ApiEnum<string, FeatureCreateFeatureResponseDataFeatureType> FeatureType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, FeatureCreateFeatureResponseDataFeatureType>
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
    public required ApiEnum<string, FeatureCreateFeatureResponseDataMeterType> MeterType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, FeatureCreateFeatureResponseDataMeterType>
            >("meterType");
        }
        init { this._rawData.Set("meterType", value); }
    }

    /// <summary>
    /// Unit transformation to be applied to the reported usage
    /// </summary>
    public required FeatureCreateFeatureResponseDataUnitTransformation? UnitTransformation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FeatureCreateFeatureResponseDataUnitTransformation>(
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

    public FeatureCreateFeatureResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FeatureCreateFeatureResponseData(
        FeatureCreateFeatureResponseData featureCreateFeatureResponseData
    )
        : base(featureCreateFeatureResponseData) { }
#pragma warning restore CS8618

    public FeatureCreateFeatureResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FeatureCreateFeatureResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FeatureCreateFeatureResponseDataFromRaw.FromRawUnchecked"/>
    public static FeatureCreateFeatureResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FeatureCreateFeatureResponseDataFromRaw : IFromRawJson<FeatureCreateFeatureResponseData>
{
    /// <inheritdoc/>
    public FeatureCreateFeatureResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FeatureCreateFeatureResponseData.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        FeatureCreateFeatureResponseDataEnumConfiguration,
        FeatureCreateFeatureResponseDataEnumConfigurationFromRaw
    >)
)]
public sealed record class FeatureCreateFeatureResponseDataEnumConfiguration : JsonModel
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

    public FeatureCreateFeatureResponseDataEnumConfiguration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FeatureCreateFeatureResponseDataEnumConfiguration(
        FeatureCreateFeatureResponseDataEnumConfiguration featureCreateFeatureResponseDataEnumConfiguration
    )
        : base(featureCreateFeatureResponseDataEnumConfiguration) { }
#pragma warning restore CS8618

    public FeatureCreateFeatureResponseDataEnumConfiguration(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FeatureCreateFeatureResponseDataEnumConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FeatureCreateFeatureResponseDataEnumConfigurationFromRaw.FromRawUnchecked"/>
    public static FeatureCreateFeatureResponseDataEnumConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FeatureCreateFeatureResponseDataEnumConfigurationFromRaw
    : IFromRawJson<FeatureCreateFeatureResponseDataEnumConfiguration>
{
    /// <inheritdoc/>
    public FeatureCreateFeatureResponseDataEnumConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FeatureCreateFeatureResponseDataEnumConfiguration.FromRawUnchecked(rawData);
}

/// <summary>
/// The status of the feature
/// </summary>
[JsonConverter(typeof(FeatureCreateFeatureResponseDataFeatureStatusConverter))]
public enum FeatureCreateFeatureResponseDataFeatureStatus
{
    New,
    Suspended,
    Active,
}

sealed class FeatureCreateFeatureResponseDataFeatureStatusConverter
    : JsonConverter<FeatureCreateFeatureResponseDataFeatureStatus>
{
    public override FeatureCreateFeatureResponseDataFeatureStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "NEW" => FeatureCreateFeatureResponseDataFeatureStatus.New,
            "SUSPENDED" => FeatureCreateFeatureResponseDataFeatureStatus.Suspended,
            "ACTIVE" => FeatureCreateFeatureResponseDataFeatureStatus.Active,
            _ => (FeatureCreateFeatureResponseDataFeatureStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FeatureCreateFeatureResponseDataFeatureStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FeatureCreateFeatureResponseDataFeatureStatus.New => "NEW",
                FeatureCreateFeatureResponseDataFeatureStatus.Suspended => "SUSPENDED",
                FeatureCreateFeatureResponseDataFeatureStatus.Active => "ACTIVE",
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
[JsonConverter(typeof(FeatureCreateFeatureResponseDataFeatureTypeConverter))]
public enum FeatureCreateFeatureResponseDataFeatureType
{
    Boolean,
    Number,
    Enum,
}

sealed class FeatureCreateFeatureResponseDataFeatureTypeConverter
    : JsonConverter<FeatureCreateFeatureResponseDataFeatureType>
{
    public override FeatureCreateFeatureResponseDataFeatureType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "BOOLEAN" => FeatureCreateFeatureResponseDataFeatureType.Boolean,
            "NUMBER" => FeatureCreateFeatureResponseDataFeatureType.Number,
            "ENUM" => FeatureCreateFeatureResponseDataFeatureType.Enum,
            _ => (FeatureCreateFeatureResponseDataFeatureType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FeatureCreateFeatureResponseDataFeatureType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FeatureCreateFeatureResponseDataFeatureType.Boolean => "BOOLEAN",
                FeatureCreateFeatureResponseDataFeatureType.Number => "NUMBER",
                FeatureCreateFeatureResponseDataFeatureType.Enum => "ENUM",
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
[JsonConverter(typeof(FeatureCreateFeatureResponseDataMeterTypeConverter))]
public enum FeatureCreateFeatureResponseDataMeterType
{
    None,
    Fluctuating,
    Incremental,
}

sealed class FeatureCreateFeatureResponseDataMeterTypeConverter
    : JsonConverter<FeatureCreateFeatureResponseDataMeterType>
{
    public override FeatureCreateFeatureResponseDataMeterType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "None" => FeatureCreateFeatureResponseDataMeterType.None,
            "FLUCTUATING" => FeatureCreateFeatureResponseDataMeterType.Fluctuating,
            "INCREMENTAL" => FeatureCreateFeatureResponseDataMeterType.Incremental,
            _ => (FeatureCreateFeatureResponseDataMeterType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FeatureCreateFeatureResponseDataMeterType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FeatureCreateFeatureResponseDataMeterType.None => "None",
                FeatureCreateFeatureResponseDataMeterType.Fluctuating => "FLUCTUATING",
                FeatureCreateFeatureResponseDataMeterType.Incremental => "INCREMENTAL",
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
        FeatureCreateFeatureResponseDataUnitTransformation,
        FeatureCreateFeatureResponseDataUnitTransformationFromRaw
    >)
)]
public sealed record class FeatureCreateFeatureResponseDataUnitTransformation : JsonModel
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
    public required ApiEnum<string, FeatureCreateFeatureResponseDataUnitTransformationRound> Round
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, FeatureCreateFeatureResponseDataUnitTransformationRound>
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

    public FeatureCreateFeatureResponseDataUnitTransformation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FeatureCreateFeatureResponseDataUnitTransformation(
        FeatureCreateFeatureResponseDataUnitTransformation featureCreateFeatureResponseDataUnitTransformation
    )
        : base(featureCreateFeatureResponseDataUnitTransformation) { }
#pragma warning restore CS8618

    public FeatureCreateFeatureResponseDataUnitTransformation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FeatureCreateFeatureResponseDataUnitTransformation(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FeatureCreateFeatureResponseDataUnitTransformationFromRaw.FromRawUnchecked"/>
    public static FeatureCreateFeatureResponseDataUnitTransformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FeatureCreateFeatureResponseDataUnitTransformationFromRaw
    : IFromRawJson<FeatureCreateFeatureResponseDataUnitTransformation>
{
    /// <inheritdoc/>
    public FeatureCreateFeatureResponseDataUnitTransformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FeatureCreateFeatureResponseDataUnitTransformation.FromRawUnchecked(rawData);
}

/// <summary>
/// After division, either round the result up or down
/// </summary>
[JsonConverter(typeof(FeatureCreateFeatureResponseDataUnitTransformationRoundConverter))]
public enum FeatureCreateFeatureResponseDataUnitTransformationRound
{
    Up,
    Down,
}

sealed class FeatureCreateFeatureResponseDataUnitTransformationRoundConverter
    : JsonConverter<FeatureCreateFeatureResponseDataUnitTransformationRound>
{
    public override FeatureCreateFeatureResponseDataUnitTransformationRound Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "UP" => FeatureCreateFeatureResponseDataUnitTransformationRound.Up,
            "DOWN" => FeatureCreateFeatureResponseDataUnitTransformationRound.Down,
            _ => (FeatureCreateFeatureResponseDataUnitTransformationRound)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FeatureCreateFeatureResponseDataUnitTransformationRound value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FeatureCreateFeatureResponseDataUnitTransformationRound.Up => "UP",
                FeatureCreateFeatureResponseDataUnitTransformationRound.Down => "DOWN",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
