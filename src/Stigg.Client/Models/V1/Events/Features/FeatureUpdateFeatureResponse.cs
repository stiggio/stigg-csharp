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
    typeof(JsonModelConverter<FeatureUpdateFeatureResponse, FeatureUpdateFeatureResponseFromRaw>)
)]
public sealed record class FeatureUpdateFeatureResponse : JsonModel
{
    /// <summary>
    /// Feature configuration object
    /// </summary>
    public required FeatureUpdateFeatureResponseData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FeatureUpdateFeatureResponseData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public FeatureUpdateFeatureResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FeatureUpdateFeatureResponse(FeatureUpdateFeatureResponse featureUpdateFeatureResponse)
        : base(featureUpdateFeatureResponse) { }
#pragma warning restore CS8618

    public FeatureUpdateFeatureResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FeatureUpdateFeatureResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FeatureUpdateFeatureResponseFromRaw.FromRawUnchecked"/>
    public static FeatureUpdateFeatureResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FeatureUpdateFeatureResponse(FeatureUpdateFeatureResponseData data)
        : this()
    {
        this.Data = data;
    }
}

class FeatureUpdateFeatureResponseFromRaw : IFromRawJson<FeatureUpdateFeatureResponse>
{
    /// <inheritdoc/>
    public FeatureUpdateFeatureResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FeatureUpdateFeatureResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Feature configuration object
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        FeatureUpdateFeatureResponseData,
        FeatureUpdateFeatureResponseDataFromRaw
    >)
)]
public sealed record class FeatureUpdateFeatureResponseData : JsonModel
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
    public required IReadOnlyList<FeatureUpdateFeatureResponseDataEnumConfiguration>? EnumConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<FeatureUpdateFeatureResponseDataEnumConfiguration>
            >("enumConfiguration");
        }
        init
        {
            this._rawData.Set<ImmutableArray<FeatureUpdateFeatureResponseDataEnumConfiguration>?>(
                "enumConfiguration",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The status of the feature
    /// </summary>
    public required ApiEnum<string, FeatureUpdateFeatureResponseDataFeatureStatus> FeatureStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, FeatureUpdateFeatureResponseDataFeatureStatus>
            >("featureStatus");
        }
        init { this._rawData.Set("featureStatus", value); }
    }

    /// <summary>
    /// The type of the feature
    /// </summary>
    public required ApiEnum<string, FeatureUpdateFeatureResponseDataFeatureType> FeatureType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, FeatureUpdateFeatureResponseDataFeatureType>
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
    public required ApiEnum<string, FeatureUpdateFeatureResponseDataMeterType> MeterType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, FeatureUpdateFeatureResponseDataMeterType>
            >("meterType");
        }
        init { this._rawData.Set("meterType", value); }
    }

    /// <summary>
    /// Unit transformation to be applied to the reported usage
    /// </summary>
    public required FeatureUpdateFeatureResponseDataUnitTransformation? UnitTransformation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FeatureUpdateFeatureResponseDataUnitTransformation>(
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

    public FeatureUpdateFeatureResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FeatureUpdateFeatureResponseData(
        FeatureUpdateFeatureResponseData featureUpdateFeatureResponseData
    )
        : base(featureUpdateFeatureResponseData) { }
#pragma warning restore CS8618

    public FeatureUpdateFeatureResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FeatureUpdateFeatureResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FeatureUpdateFeatureResponseDataFromRaw.FromRawUnchecked"/>
    public static FeatureUpdateFeatureResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FeatureUpdateFeatureResponseDataFromRaw : IFromRawJson<FeatureUpdateFeatureResponseData>
{
    /// <inheritdoc/>
    public FeatureUpdateFeatureResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FeatureUpdateFeatureResponseData.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        FeatureUpdateFeatureResponseDataEnumConfiguration,
        FeatureUpdateFeatureResponseDataEnumConfigurationFromRaw
    >)
)]
public sealed record class FeatureUpdateFeatureResponseDataEnumConfiguration : JsonModel
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

    public FeatureUpdateFeatureResponseDataEnumConfiguration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FeatureUpdateFeatureResponseDataEnumConfiguration(
        FeatureUpdateFeatureResponseDataEnumConfiguration featureUpdateFeatureResponseDataEnumConfiguration
    )
        : base(featureUpdateFeatureResponseDataEnumConfiguration) { }
#pragma warning restore CS8618

    public FeatureUpdateFeatureResponseDataEnumConfiguration(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FeatureUpdateFeatureResponseDataEnumConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FeatureUpdateFeatureResponseDataEnumConfigurationFromRaw.FromRawUnchecked"/>
    public static FeatureUpdateFeatureResponseDataEnumConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FeatureUpdateFeatureResponseDataEnumConfigurationFromRaw
    : IFromRawJson<FeatureUpdateFeatureResponseDataEnumConfiguration>
{
    /// <inheritdoc/>
    public FeatureUpdateFeatureResponseDataEnumConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FeatureUpdateFeatureResponseDataEnumConfiguration.FromRawUnchecked(rawData);
}

/// <summary>
/// The status of the feature
/// </summary>
[JsonConverter(typeof(FeatureUpdateFeatureResponseDataFeatureStatusConverter))]
public enum FeatureUpdateFeatureResponseDataFeatureStatus
{
    New,
    Suspended,
    Active,
}

sealed class FeatureUpdateFeatureResponseDataFeatureStatusConverter
    : JsonConverter<FeatureUpdateFeatureResponseDataFeatureStatus>
{
    public override FeatureUpdateFeatureResponseDataFeatureStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "NEW" => FeatureUpdateFeatureResponseDataFeatureStatus.New,
            "SUSPENDED" => FeatureUpdateFeatureResponseDataFeatureStatus.Suspended,
            "ACTIVE" => FeatureUpdateFeatureResponseDataFeatureStatus.Active,
            _ => (FeatureUpdateFeatureResponseDataFeatureStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FeatureUpdateFeatureResponseDataFeatureStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FeatureUpdateFeatureResponseDataFeatureStatus.New => "NEW",
                FeatureUpdateFeatureResponseDataFeatureStatus.Suspended => "SUSPENDED",
                FeatureUpdateFeatureResponseDataFeatureStatus.Active => "ACTIVE",
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
[JsonConverter(typeof(FeatureUpdateFeatureResponseDataFeatureTypeConverter))]
public enum FeatureUpdateFeatureResponseDataFeatureType
{
    Boolean,
    Number,
    Enum,
}

sealed class FeatureUpdateFeatureResponseDataFeatureTypeConverter
    : JsonConverter<FeatureUpdateFeatureResponseDataFeatureType>
{
    public override FeatureUpdateFeatureResponseDataFeatureType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "BOOLEAN" => FeatureUpdateFeatureResponseDataFeatureType.Boolean,
            "NUMBER" => FeatureUpdateFeatureResponseDataFeatureType.Number,
            "ENUM" => FeatureUpdateFeatureResponseDataFeatureType.Enum,
            _ => (FeatureUpdateFeatureResponseDataFeatureType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FeatureUpdateFeatureResponseDataFeatureType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FeatureUpdateFeatureResponseDataFeatureType.Boolean => "BOOLEAN",
                FeatureUpdateFeatureResponseDataFeatureType.Number => "NUMBER",
                FeatureUpdateFeatureResponseDataFeatureType.Enum => "ENUM",
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
[JsonConverter(typeof(FeatureUpdateFeatureResponseDataMeterTypeConverter))]
public enum FeatureUpdateFeatureResponseDataMeterType
{
    None,
    Fluctuating,
    Incremental,
}

sealed class FeatureUpdateFeatureResponseDataMeterTypeConverter
    : JsonConverter<FeatureUpdateFeatureResponseDataMeterType>
{
    public override FeatureUpdateFeatureResponseDataMeterType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "None" => FeatureUpdateFeatureResponseDataMeterType.None,
            "FLUCTUATING" => FeatureUpdateFeatureResponseDataMeterType.Fluctuating,
            "INCREMENTAL" => FeatureUpdateFeatureResponseDataMeterType.Incremental,
            _ => (FeatureUpdateFeatureResponseDataMeterType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FeatureUpdateFeatureResponseDataMeterType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FeatureUpdateFeatureResponseDataMeterType.None => "None",
                FeatureUpdateFeatureResponseDataMeterType.Fluctuating => "FLUCTUATING",
                FeatureUpdateFeatureResponseDataMeterType.Incremental => "INCREMENTAL",
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
        FeatureUpdateFeatureResponseDataUnitTransformation,
        FeatureUpdateFeatureResponseDataUnitTransformationFromRaw
    >)
)]
public sealed record class FeatureUpdateFeatureResponseDataUnitTransformation : JsonModel
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
    public required ApiEnum<string, FeatureUpdateFeatureResponseDataUnitTransformationRound> Round
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, FeatureUpdateFeatureResponseDataUnitTransformationRound>
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

    public FeatureUpdateFeatureResponseDataUnitTransformation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FeatureUpdateFeatureResponseDataUnitTransformation(
        FeatureUpdateFeatureResponseDataUnitTransformation featureUpdateFeatureResponseDataUnitTransformation
    )
        : base(featureUpdateFeatureResponseDataUnitTransformation) { }
#pragma warning restore CS8618

    public FeatureUpdateFeatureResponseDataUnitTransformation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FeatureUpdateFeatureResponseDataUnitTransformation(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FeatureUpdateFeatureResponseDataUnitTransformationFromRaw.FromRawUnchecked"/>
    public static FeatureUpdateFeatureResponseDataUnitTransformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FeatureUpdateFeatureResponseDataUnitTransformationFromRaw
    : IFromRawJson<FeatureUpdateFeatureResponseDataUnitTransformation>
{
    /// <inheritdoc/>
    public FeatureUpdateFeatureResponseDataUnitTransformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FeatureUpdateFeatureResponseDataUnitTransformation.FromRawUnchecked(rawData);
}

/// <summary>
/// After division, either round the result up or down
/// </summary>
[JsonConverter(typeof(FeatureUpdateFeatureResponseDataUnitTransformationRoundConverter))]
public enum FeatureUpdateFeatureResponseDataUnitTransformationRound
{
    Up,
    Down,
}

sealed class FeatureUpdateFeatureResponseDataUnitTransformationRoundConverter
    : JsonConverter<FeatureUpdateFeatureResponseDataUnitTransformationRound>
{
    public override FeatureUpdateFeatureResponseDataUnitTransformationRound Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "UP" => FeatureUpdateFeatureResponseDataUnitTransformationRound.Up,
            "DOWN" => FeatureUpdateFeatureResponseDataUnitTransformationRound.Down,
            _ => (FeatureUpdateFeatureResponseDataUnitTransformationRound)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FeatureUpdateFeatureResponseDataUnitTransformationRound value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FeatureUpdateFeatureResponseDataUnitTransformationRound.Up => "UP",
                FeatureUpdateFeatureResponseDataUnitTransformationRound.Down => "DOWN",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
