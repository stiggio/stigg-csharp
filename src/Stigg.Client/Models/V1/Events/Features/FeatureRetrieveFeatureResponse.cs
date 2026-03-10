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
        FeatureRetrieveFeatureResponse,
        FeatureRetrieveFeatureResponseFromRaw
    >)
)]
public sealed record class FeatureRetrieveFeatureResponse : JsonModel
{
    /// <summary>
    /// Feature configuration object
    /// </summary>
    public required FeatureRetrieveFeatureResponseData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FeatureRetrieveFeatureResponseData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public FeatureRetrieveFeatureResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FeatureRetrieveFeatureResponse(
        FeatureRetrieveFeatureResponse featureRetrieveFeatureResponse
    )
        : base(featureRetrieveFeatureResponse) { }
#pragma warning restore CS8618

    public FeatureRetrieveFeatureResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FeatureRetrieveFeatureResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FeatureRetrieveFeatureResponseFromRaw.FromRawUnchecked"/>
    public static FeatureRetrieveFeatureResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FeatureRetrieveFeatureResponse(FeatureRetrieveFeatureResponseData data)
        : this()
    {
        this.Data = data;
    }
}

class FeatureRetrieveFeatureResponseFromRaw : IFromRawJson<FeatureRetrieveFeatureResponse>
{
    /// <inheritdoc/>
    public FeatureRetrieveFeatureResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FeatureRetrieveFeatureResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Feature configuration object
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        FeatureRetrieveFeatureResponseData,
        FeatureRetrieveFeatureResponseDataFromRaw
    >)
)]
public sealed record class FeatureRetrieveFeatureResponseData : JsonModel
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
    public required IReadOnlyList<FeatureRetrieveFeatureResponseDataEnumConfiguration>? EnumConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<FeatureRetrieveFeatureResponseDataEnumConfiguration>
            >("enumConfiguration");
        }
        init
        {
            this._rawData.Set<ImmutableArray<FeatureRetrieveFeatureResponseDataEnumConfiguration>?>(
                "enumConfiguration",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The status of the feature
    /// </summary>
    public required ApiEnum<string, FeatureRetrieveFeatureResponseDataFeatureStatus> FeatureStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, FeatureRetrieveFeatureResponseDataFeatureStatus>
            >("featureStatus");
        }
        init { this._rawData.Set("featureStatus", value); }
    }

    /// <summary>
    /// The type of the feature
    /// </summary>
    public required ApiEnum<string, FeatureRetrieveFeatureResponseDataFeatureType> FeatureType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, FeatureRetrieveFeatureResponseDataFeatureType>
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
    public required ApiEnum<string, FeatureRetrieveFeatureResponseDataMeterType> MeterType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, FeatureRetrieveFeatureResponseDataMeterType>
            >("meterType");
        }
        init { this._rawData.Set("meterType", value); }
    }

    /// <summary>
    /// Unit transformation to be applied to the reported usage
    /// </summary>
    public required FeatureRetrieveFeatureResponseDataUnitTransformation? UnitTransformation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FeatureRetrieveFeatureResponseDataUnitTransformation>(
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

    public FeatureRetrieveFeatureResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FeatureRetrieveFeatureResponseData(
        FeatureRetrieveFeatureResponseData featureRetrieveFeatureResponseData
    )
        : base(featureRetrieveFeatureResponseData) { }
#pragma warning restore CS8618

    public FeatureRetrieveFeatureResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FeatureRetrieveFeatureResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FeatureRetrieveFeatureResponseDataFromRaw.FromRawUnchecked"/>
    public static FeatureRetrieveFeatureResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FeatureRetrieveFeatureResponseDataFromRaw : IFromRawJson<FeatureRetrieveFeatureResponseData>
{
    /// <inheritdoc/>
    public FeatureRetrieveFeatureResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FeatureRetrieveFeatureResponseData.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        FeatureRetrieveFeatureResponseDataEnumConfiguration,
        FeatureRetrieveFeatureResponseDataEnumConfigurationFromRaw
    >)
)]
public sealed record class FeatureRetrieveFeatureResponseDataEnumConfiguration : JsonModel
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

    public FeatureRetrieveFeatureResponseDataEnumConfiguration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FeatureRetrieveFeatureResponseDataEnumConfiguration(
        FeatureRetrieveFeatureResponseDataEnumConfiguration featureRetrieveFeatureResponseDataEnumConfiguration
    )
        : base(featureRetrieveFeatureResponseDataEnumConfiguration) { }
#pragma warning restore CS8618

    public FeatureRetrieveFeatureResponseDataEnumConfiguration(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FeatureRetrieveFeatureResponseDataEnumConfiguration(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FeatureRetrieveFeatureResponseDataEnumConfigurationFromRaw.FromRawUnchecked"/>
    public static FeatureRetrieveFeatureResponseDataEnumConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FeatureRetrieveFeatureResponseDataEnumConfigurationFromRaw
    : IFromRawJson<FeatureRetrieveFeatureResponseDataEnumConfiguration>
{
    /// <inheritdoc/>
    public FeatureRetrieveFeatureResponseDataEnumConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FeatureRetrieveFeatureResponseDataEnumConfiguration.FromRawUnchecked(rawData);
}

/// <summary>
/// The status of the feature
/// </summary>
[JsonConverter(typeof(FeatureRetrieveFeatureResponseDataFeatureStatusConverter))]
public enum FeatureRetrieveFeatureResponseDataFeatureStatus
{
    New,
    Suspended,
    Active,
}

sealed class FeatureRetrieveFeatureResponseDataFeatureStatusConverter
    : JsonConverter<FeatureRetrieveFeatureResponseDataFeatureStatus>
{
    public override FeatureRetrieveFeatureResponseDataFeatureStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "NEW" => FeatureRetrieveFeatureResponseDataFeatureStatus.New,
            "SUSPENDED" => FeatureRetrieveFeatureResponseDataFeatureStatus.Suspended,
            "ACTIVE" => FeatureRetrieveFeatureResponseDataFeatureStatus.Active,
            _ => (FeatureRetrieveFeatureResponseDataFeatureStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FeatureRetrieveFeatureResponseDataFeatureStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FeatureRetrieveFeatureResponseDataFeatureStatus.New => "NEW",
                FeatureRetrieveFeatureResponseDataFeatureStatus.Suspended => "SUSPENDED",
                FeatureRetrieveFeatureResponseDataFeatureStatus.Active => "ACTIVE",
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
[JsonConverter(typeof(FeatureRetrieveFeatureResponseDataFeatureTypeConverter))]
public enum FeatureRetrieveFeatureResponseDataFeatureType
{
    Boolean,
    Number,
    Enum,
}

sealed class FeatureRetrieveFeatureResponseDataFeatureTypeConverter
    : JsonConverter<FeatureRetrieveFeatureResponseDataFeatureType>
{
    public override FeatureRetrieveFeatureResponseDataFeatureType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "BOOLEAN" => FeatureRetrieveFeatureResponseDataFeatureType.Boolean,
            "NUMBER" => FeatureRetrieveFeatureResponseDataFeatureType.Number,
            "ENUM" => FeatureRetrieveFeatureResponseDataFeatureType.Enum,
            _ => (FeatureRetrieveFeatureResponseDataFeatureType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FeatureRetrieveFeatureResponseDataFeatureType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FeatureRetrieveFeatureResponseDataFeatureType.Boolean => "BOOLEAN",
                FeatureRetrieveFeatureResponseDataFeatureType.Number => "NUMBER",
                FeatureRetrieveFeatureResponseDataFeatureType.Enum => "ENUM",
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
[JsonConverter(typeof(FeatureRetrieveFeatureResponseDataMeterTypeConverter))]
public enum FeatureRetrieveFeatureResponseDataMeterType
{
    None,
    Fluctuating,
    Incremental,
}

sealed class FeatureRetrieveFeatureResponseDataMeterTypeConverter
    : JsonConverter<FeatureRetrieveFeatureResponseDataMeterType>
{
    public override FeatureRetrieveFeatureResponseDataMeterType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "None" => FeatureRetrieveFeatureResponseDataMeterType.None,
            "FLUCTUATING" => FeatureRetrieveFeatureResponseDataMeterType.Fluctuating,
            "INCREMENTAL" => FeatureRetrieveFeatureResponseDataMeterType.Incremental,
            _ => (FeatureRetrieveFeatureResponseDataMeterType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FeatureRetrieveFeatureResponseDataMeterType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FeatureRetrieveFeatureResponseDataMeterType.None => "None",
                FeatureRetrieveFeatureResponseDataMeterType.Fluctuating => "FLUCTUATING",
                FeatureRetrieveFeatureResponseDataMeterType.Incremental => "INCREMENTAL",
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
        FeatureRetrieveFeatureResponseDataUnitTransformation,
        FeatureRetrieveFeatureResponseDataUnitTransformationFromRaw
    >)
)]
public sealed record class FeatureRetrieveFeatureResponseDataUnitTransformation : JsonModel
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
    public required ApiEnum<string, FeatureRetrieveFeatureResponseDataUnitTransformationRound> Round
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, FeatureRetrieveFeatureResponseDataUnitTransformationRound>
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

    public FeatureRetrieveFeatureResponseDataUnitTransformation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FeatureRetrieveFeatureResponseDataUnitTransformation(
        FeatureRetrieveFeatureResponseDataUnitTransformation featureRetrieveFeatureResponseDataUnitTransformation
    )
        : base(featureRetrieveFeatureResponseDataUnitTransformation) { }
#pragma warning restore CS8618

    public FeatureRetrieveFeatureResponseDataUnitTransformation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FeatureRetrieveFeatureResponseDataUnitTransformation(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FeatureRetrieveFeatureResponseDataUnitTransformationFromRaw.FromRawUnchecked"/>
    public static FeatureRetrieveFeatureResponseDataUnitTransformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FeatureRetrieveFeatureResponseDataUnitTransformationFromRaw
    : IFromRawJson<FeatureRetrieveFeatureResponseDataUnitTransformation>
{
    /// <inheritdoc/>
    public FeatureRetrieveFeatureResponseDataUnitTransformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FeatureRetrieveFeatureResponseDataUnitTransformation.FromRawUnchecked(rawData);
}

/// <summary>
/// After division, either round the result up or down
/// </summary>
[JsonConverter(typeof(FeatureRetrieveFeatureResponseDataUnitTransformationRoundConverter))]
public enum FeatureRetrieveFeatureResponseDataUnitTransformationRound
{
    Up,
    Down,
}

sealed class FeatureRetrieveFeatureResponseDataUnitTransformationRoundConverter
    : JsonConverter<FeatureRetrieveFeatureResponseDataUnitTransformationRound>
{
    public override FeatureRetrieveFeatureResponseDataUnitTransformationRound Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "UP" => FeatureRetrieveFeatureResponseDataUnitTransformationRound.Up,
            "DOWN" => FeatureRetrieveFeatureResponseDataUnitTransformationRound.Down,
            _ => (FeatureRetrieveFeatureResponseDataUnitTransformationRound)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FeatureRetrieveFeatureResponseDataUnitTransformationRound value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FeatureRetrieveFeatureResponseDataUnitTransformationRound.Up => "UP",
                FeatureRetrieveFeatureResponseDataUnitTransformationRound.Down => "DOWN",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
