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
    typeof(JsonModelConverter<
        FeatureUnarchiveFeatureResponse,
        FeatureUnarchiveFeatureResponseFromRaw
    >)
)]
public sealed record class FeatureUnarchiveFeatureResponse : JsonModel
{
    /// <summary>
    /// Feature configuration object
    /// </summary>
    public required FeatureUnarchiveFeatureResponseData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FeatureUnarchiveFeatureResponseData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public FeatureUnarchiveFeatureResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FeatureUnarchiveFeatureResponse(
        FeatureUnarchiveFeatureResponse featureUnarchiveFeatureResponse
    )
        : base(featureUnarchiveFeatureResponse) { }
#pragma warning restore CS8618

    public FeatureUnarchiveFeatureResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FeatureUnarchiveFeatureResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FeatureUnarchiveFeatureResponseFromRaw.FromRawUnchecked"/>
    public static FeatureUnarchiveFeatureResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FeatureUnarchiveFeatureResponse(FeatureUnarchiveFeatureResponseData data)
        : this()
    {
        this.Data = data;
    }
}

class FeatureUnarchiveFeatureResponseFromRaw : IFromRawJson<FeatureUnarchiveFeatureResponse>
{
    /// <inheritdoc/>
    public FeatureUnarchiveFeatureResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FeatureUnarchiveFeatureResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Feature configuration object
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        FeatureUnarchiveFeatureResponseData,
        FeatureUnarchiveFeatureResponseDataFromRaw
    >)
)]
public sealed record class FeatureUnarchiveFeatureResponseData : JsonModel
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
    public required IReadOnlyList<FeatureUnarchiveFeatureResponseDataEnumConfiguration>? EnumConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<FeatureUnarchiveFeatureResponseDataEnumConfiguration>
            >("enumConfiguration");
        }
        init
        {
            this._rawData.Set<ImmutableArray<FeatureUnarchiveFeatureResponseDataEnumConfiguration>?>(
                "enumConfiguration",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The status of the feature
    /// </summary>
    public required ApiEnum<string, FeatureUnarchiveFeatureResponseDataFeatureStatus> FeatureStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, FeatureUnarchiveFeatureResponseDataFeatureStatus>
            >("featureStatus");
        }
        init { this._rawData.Set("featureStatus", value); }
    }

    /// <summary>
    /// The type of the feature
    /// </summary>
    public required ApiEnum<string, FeatureUnarchiveFeatureResponseDataFeatureType> FeatureType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, FeatureUnarchiveFeatureResponseDataFeatureType>
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
    public required ApiEnum<string, FeatureUnarchiveFeatureResponseDataMeterType> MeterType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, FeatureUnarchiveFeatureResponseDataMeterType>
            >("meterType");
        }
        init { this._rawData.Set("meterType", value); }
    }

    /// <summary>
    /// Unit transformation to be applied to the reported usage
    /// </summary>
    public required FeatureUnarchiveFeatureResponseDataUnitTransformation? UnitTransformation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FeatureUnarchiveFeatureResponseDataUnitTransformation>(
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

    public FeatureUnarchiveFeatureResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FeatureUnarchiveFeatureResponseData(
        FeatureUnarchiveFeatureResponseData featureUnarchiveFeatureResponseData
    )
        : base(featureUnarchiveFeatureResponseData) { }
#pragma warning restore CS8618

    public FeatureUnarchiveFeatureResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FeatureUnarchiveFeatureResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FeatureUnarchiveFeatureResponseDataFromRaw.FromRawUnchecked"/>
    public static FeatureUnarchiveFeatureResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FeatureUnarchiveFeatureResponseDataFromRaw : IFromRawJson<FeatureUnarchiveFeatureResponseData>
{
    /// <inheritdoc/>
    public FeatureUnarchiveFeatureResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FeatureUnarchiveFeatureResponseData.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        FeatureUnarchiveFeatureResponseDataEnumConfiguration,
        FeatureUnarchiveFeatureResponseDataEnumConfigurationFromRaw
    >)
)]
public sealed record class FeatureUnarchiveFeatureResponseDataEnumConfiguration : JsonModel
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

    public FeatureUnarchiveFeatureResponseDataEnumConfiguration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FeatureUnarchiveFeatureResponseDataEnumConfiguration(
        FeatureUnarchiveFeatureResponseDataEnumConfiguration featureUnarchiveFeatureResponseDataEnumConfiguration
    )
        : base(featureUnarchiveFeatureResponseDataEnumConfiguration) { }
#pragma warning restore CS8618

    public FeatureUnarchiveFeatureResponseDataEnumConfiguration(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FeatureUnarchiveFeatureResponseDataEnumConfiguration(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FeatureUnarchiveFeatureResponseDataEnumConfigurationFromRaw.FromRawUnchecked"/>
    public static FeatureUnarchiveFeatureResponseDataEnumConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FeatureUnarchiveFeatureResponseDataEnumConfigurationFromRaw
    : IFromRawJson<FeatureUnarchiveFeatureResponseDataEnumConfiguration>
{
    /// <inheritdoc/>
    public FeatureUnarchiveFeatureResponseDataEnumConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FeatureUnarchiveFeatureResponseDataEnumConfiguration.FromRawUnchecked(rawData);
}

/// <summary>
/// The status of the feature
/// </summary>
[JsonConverter(typeof(FeatureUnarchiveFeatureResponseDataFeatureStatusConverter))]
public enum FeatureUnarchiveFeatureResponseDataFeatureStatus
{
    New,
    Suspended,
    Active,
}

sealed class FeatureUnarchiveFeatureResponseDataFeatureStatusConverter
    : JsonConverter<FeatureUnarchiveFeatureResponseDataFeatureStatus>
{
    public override FeatureUnarchiveFeatureResponseDataFeatureStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "NEW" => FeatureUnarchiveFeatureResponseDataFeatureStatus.New,
            "SUSPENDED" => FeatureUnarchiveFeatureResponseDataFeatureStatus.Suspended,
            "ACTIVE" => FeatureUnarchiveFeatureResponseDataFeatureStatus.Active,
            _ => (FeatureUnarchiveFeatureResponseDataFeatureStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FeatureUnarchiveFeatureResponseDataFeatureStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FeatureUnarchiveFeatureResponseDataFeatureStatus.New => "NEW",
                FeatureUnarchiveFeatureResponseDataFeatureStatus.Suspended => "SUSPENDED",
                FeatureUnarchiveFeatureResponseDataFeatureStatus.Active => "ACTIVE",
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
[JsonConverter(typeof(FeatureUnarchiveFeatureResponseDataFeatureTypeConverter))]
public enum FeatureUnarchiveFeatureResponseDataFeatureType
{
    Boolean,
    Number,
    Enum,
}

sealed class FeatureUnarchiveFeatureResponseDataFeatureTypeConverter
    : JsonConverter<FeatureUnarchiveFeatureResponseDataFeatureType>
{
    public override FeatureUnarchiveFeatureResponseDataFeatureType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "BOOLEAN" => FeatureUnarchiveFeatureResponseDataFeatureType.Boolean,
            "NUMBER" => FeatureUnarchiveFeatureResponseDataFeatureType.Number,
            "ENUM" => FeatureUnarchiveFeatureResponseDataFeatureType.Enum,
            _ => (FeatureUnarchiveFeatureResponseDataFeatureType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FeatureUnarchiveFeatureResponseDataFeatureType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FeatureUnarchiveFeatureResponseDataFeatureType.Boolean => "BOOLEAN",
                FeatureUnarchiveFeatureResponseDataFeatureType.Number => "NUMBER",
                FeatureUnarchiveFeatureResponseDataFeatureType.Enum => "ENUM",
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
[JsonConverter(typeof(FeatureUnarchiveFeatureResponseDataMeterTypeConverter))]
public enum FeatureUnarchiveFeatureResponseDataMeterType
{
    None,
    Fluctuating,
    Incremental,
}

sealed class FeatureUnarchiveFeatureResponseDataMeterTypeConverter
    : JsonConverter<FeatureUnarchiveFeatureResponseDataMeterType>
{
    public override FeatureUnarchiveFeatureResponseDataMeterType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "None" => FeatureUnarchiveFeatureResponseDataMeterType.None,
            "FLUCTUATING" => FeatureUnarchiveFeatureResponseDataMeterType.Fluctuating,
            "INCREMENTAL" => FeatureUnarchiveFeatureResponseDataMeterType.Incremental,
            _ => (FeatureUnarchiveFeatureResponseDataMeterType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FeatureUnarchiveFeatureResponseDataMeterType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FeatureUnarchiveFeatureResponseDataMeterType.None => "None",
                FeatureUnarchiveFeatureResponseDataMeterType.Fluctuating => "FLUCTUATING",
                FeatureUnarchiveFeatureResponseDataMeterType.Incremental => "INCREMENTAL",
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
        FeatureUnarchiveFeatureResponseDataUnitTransformation,
        FeatureUnarchiveFeatureResponseDataUnitTransformationFromRaw
    >)
)]
public sealed record class FeatureUnarchiveFeatureResponseDataUnitTransformation : JsonModel
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
    public required ApiEnum<
        string,
        FeatureUnarchiveFeatureResponseDataUnitTransformationRound
    > Round
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, FeatureUnarchiveFeatureResponseDataUnitTransformationRound>
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

    public FeatureUnarchiveFeatureResponseDataUnitTransformation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FeatureUnarchiveFeatureResponseDataUnitTransformation(
        FeatureUnarchiveFeatureResponseDataUnitTransformation featureUnarchiveFeatureResponseDataUnitTransformation
    )
        : base(featureUnarchiveFeatureResponseDataUnitTransformation) { }
#pragma warning restore CS8618

    public FeatureUnarchiveFeatureResponseDataUnitTransformation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FeatureUnarchiveFeatureResponseDataUnitTransformation(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FeatureUnarchiveFeatureResponseDataUnitTransformationFromRaw.FromRawUnchecked"/>
    public static FeatureUnarchiveFeatureResponseDataUnitTransformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FeatureUnarchiveFeatureResponseDataUnitTransformationFromRaw
    : IFromRawJson<FeatureUnarchiveFeatureResponseDataUnitTransformation>
{
    /// <inheritdoc/>
    public FeatureUnarchiveFeatureResponseDataUnitTransformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FeatureUnarchiveFeatureResponseDataUnitTransformation.FromRawUnchecked(rawData);
}

/// <summary>
/// After division, either round the result up or down
/// </summary>
[JsonConverter(typeof(FeatureUnarchiveFeatureResponseDataUnitTransformationRoundConverter))]
public enum FeatureUnarchiveFeatureResponseDataUnitTransformationRound
{
    Up,
    Down,
}

sealed class FeatureUnarchiveFeatureResponseDataUnitTransformationRoundConverter
    : JsonConverter<FeatureUnarchiveFeatureResponseDataUnitTransformationRound>
{
    public override FeatureUnarchiveFeatureResponseDataUnitTransformationRound Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "UP" => FeatureUnarchiveFeatureResponseDataUnitTransformationRound.Up,
            "DOWN" => FeatureUnarchiveFeatureResponseDataUnitTransformationRound.Down,
            _ => (FeatureUnarchiveFeatureResponseDataUnitTransformationRound)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FeatureUnarchiveFeatureResponseDataUnitTransformationRound value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FeatureUnarchiveFeatureResponseDataUnitTransformationRound.Up => "UP",
                FeatureUnarchiveFeatureResponseDataUnitTransformationRound.Down => "DOWN",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
