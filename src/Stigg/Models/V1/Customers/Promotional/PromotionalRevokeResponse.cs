using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Core;
using Stigg.Exceptions;
using System = System;

namespace Stigg.Models.V1.Customers.Promotional;

[JsonConverter(
    typeof(JsonModelConverter<PromotionalRevokeResponse, PromotionalRevokeResponseFromRaw>)
)]
public sealed record class PromotionalRevokeResponse : JsonModel
{
    public required PromotionalRevokeResponseData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PromotionalRevokeResponseData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public PromotionalRevokeResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PromotionalRevokeResponse(PromotionalRevokeResponse promotionalRevokeResponse)
        : base(promotionalRevokeResponse) { }
#pragma warning restore CS8618

    public PromotionalRevokeResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PromotionalRevokeResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PromotionalRevokeResponseFromRaw.FromRawUnchecked"/>
    public static PromotionalRevokeResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PromotionalRevokeResponse(PromotionalRevokeResponseData data)
        : this()
    {
        this.Data = data;
    }
}

class PromotionalRevokeResponseFromRaw : IFromRawJson<PromotionalRevokeResponse>
{
    /// <inheritdoc/>
    public PromotionalRevokeResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PromotionalRevokeResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<PromotionalRevokeResponseData, PromotionalRevokeResponseDataFromRaw>)
)]
public sealed record class PromotionalRevokeResponseData : JsonModel
{
    /// <summary>
    /// Unique identifier for the entity
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
    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("createdAt");
        }
        init { this._rawData.Set("createdAt", value); }
    }

    /// <summary>
    /// The description of the entitlement
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
    /// The end date of the promotional entitlement
    /// </summary>
    public required System::DateTimeOffset? EndDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("endDate");
        }
        init { this._rawData.Set("endDate", value); }
    }

    /// <summary>
    /// The enum values of the entitlement
    /// </summary>
    public required IReadOnlyList<string>? EnumValues
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("enumValues");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "enumValues",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The unique identifier for the environment
    /// </summary>
    public required string EnvironmentID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("environmentId");
        }
        init { this._rawData.Set("environmentId", value); }
    }

    /// <summary>
    /// Feature group IDs associated with this entitlement
    /// </summary>
    public required IReadOnlyList<string>? FeatureGroupIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("featureGroupIds");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "featureGroupIds",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The unique identifier of the entitlement feature
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
    /// Whether the entitlement has a soft limit
    /// </summary>
    public required bool? HasSoftLimit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("hasSoftLimit");
        }
        init { this._rawData.Set("hasSoftLimit", value); }
    }

    /// <summary>
    /// Whether the entitlement has an unlimited usage
    /// </summary>
    public required bool? HasUnlimitedUsage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("hasUnlimitedUsage");
        }
        init { this._rawData.Set("hasUnlimitedUsage", value); }
    }

    /// <summary>
    /// Whether the entitlement is visible
    /// </summary>
    public required bool IsVisible
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("isVisible");
        }
        init { this._rawData.Set("isVisible", value); }
    }

    /// <summary>
    /// The grant period of the promotional entitlement
    /// </summary>
    public required ApiEnum<string, PromotionalRevokeResponseDataPeriod> Period
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, PromotionalRevokeResponseDataPeriod>
            >("period");
        }
        init { this._rawData.Set("period", value); }
    }

    /// <summary>
    /// The reset period of the entitlement
    /// </summary>
    public required ApiEnum<string, PromotionalRevokeResponseDataResetPeriod>? ResetPeriod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, PromotionalRevokeResponseDataResetPeriod>
            >("resetPeriod");
        }
        init { this._rawData.Set("resetPeriod", value); }
    }

    /// <summary>
    /// The reset period configuration of the entitlement
    /// </summary>
    public required PromotionalRevokeResponseDataResetPeriodConfiguration? ResetPeriodConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PromotionalRevokeResponseDataResetPeriodConfiguration>(
                "resetPeriodConfiguration"
            );
        }
        init { this._rawData.Set("resetPeriodConfiguration", value); }
    }

    /// <summary>
    /// The start date of the entitlement
    /// </summary>
    public required System::DateTimeOffset StartDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("startDate");
        }
        init { this._rawData.Set("startDate", value); }
    }

    /// <summary>
    /// The status of the entitlement
    /// </summary>
    public required ApiEnum<string, PromotionalRevokeResponseDataStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, PromotionalRevokeResponseDataStatus>
            >("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Timestamp of when the record was last updated
    /// </summary>
    public required System::DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("updatedAt");
        }
        init { this._rawData.Set("updatedAt", value); }
    }

    /// <summary>
    /// The usage limit of the entitlement
    /// </summary>
    public required double? UsageLimit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("usageLimit");
        }
        init { this._rawData.Set("usageLimit", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.Description;
        _ = this.EndDate;
        _ = this.EnumValues;
        _ = this.EnvironmentID;
        _ = this.FeatureGroupIds;
        _ = this.FeatureID;
        _ = this.HasSoftLimit;
        _ = this.HasUnlimitedUsage;
        _ = this.IsVisible;
        this.Period.Validate();
        this.ResetPeriod?.Validate();
        this.ResetPeriodConfiguration?.Validate();
        _ = this.StartDate;
        this.Status.Validate();
        _ = this.UpdatedAt;
        _ = this.UsageLimit;
    }

    public PromotionalRevokeResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PromotionalRevokeResponseData(
        PromotionalRevokeResponseData promotionalRevokeResponseData
    )
        : base(promotionalRevokeResponseData) { }
#pragma warning restore CS8618

    public PromotionalRevokeResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PromotionalRevokeResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PromotionalRevokeResponseDataFromRaw.FromRawUnchecked"/>
    public static PromotionalRevokeResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PromotionalRevokeResponseDataFromRaw : IFromRawJson<PromotionalRevokeResponseData>
{
    /// <inheritdoc/>
    public PromotionalRevokeResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PromotionalRevokeResponseData.FromRawUnchecked(rawData);
}

/// <summary>
/// The grant period of the promotional entitlement
/// </summary>
[JsonConverter(typeof(PromotionalRevokeResponseDataPeriodConverter))]
public enum PromotionalRevokeResponseDataPeriod
{
    V1Week,
    V1Month,
    V6Month,
    V1Year,
    Lifetime,
    Custom,
}

sealed class PromotionalRevokeResponseDataPeriodConverter
    : JsonConverter<PromotionalRevokeResponseDataPeriod>
{
    public override PromotionalRevokeResponseDataPeriod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "1 week" => PromotionalRevokeResponseDataPeriod.V1Week,
            "1 month" => PromotionalRevokeResponseDataPeriod.V1Month,
            "6 month" => PromotionalRevokeResponseDataPeriod.V6Month,
            "1 year" => PromotionalRevokeResponseDataPeriod.V1Year,
            "lifetime" => PromotionalRevokeResponseDataPeriod.Lifetime,
            "custom" => PromotionalRevokeResponseDataPeriod.Custom,
            _ => (PromotionalRevokeResponseDataPeriod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PromotionalRevokeResponseDataPeriod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PromotionalRevokeResponseDataPeriod.V1Week => "1 week",
                PromotionalRevokeResponseDataPeriod.V1Month => "1 month",
                PromotionalRevokeResponseDataPeriod.V6Month => "6 month",
                PromotionalRevokeResponseDataPeriod.V1Year => "1 year",
                PromotionalRevokeResponseDataPeriod.Lifetime => "lifetime",
                PromotionalRevokeResponseDataPeriod.Custom => "custom",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The reset period of the entitlement
/// </summary>
[JsonConverter(typeof(PromotionalRevokeResponseDataResetPeriodConverter))]
public enum PromotionalRevokeResponseDataResetPeriod
{
    Year,
    Month,
    Week,
    Day,
    Hour,
}

sealed class PromotionalRevokeResponseDataResetPeriodConverter
    : JsonConverter<PromotionalRevokeResponseDataResetPeriod>
{
    public override PromotionalRevokeResponseDataResetPeriod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "YEAR" => PromotionalRevokeResponseDataResetPeriod.Year,
            "MONTH" => PromotionalRevokeResponseDataResetPeriod.Month,
            "WEEK" => PromotionalRevokeResponseDataResetPeriod.Week,
            "DAY" => PromotionalRevokeResponseDataResetPeriod.Day,
            "HOUR" => PromotionalRevokeResponseDataResetPeriod.Hour,
            _ => (PromotionalRevokeResponseDataResetPeriod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PromotionalRevokeResponseDataResetPeriod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PromotionalRevokeResponseDataResetPeriod.Year => "YEAR",
                PromotionalRevokeResponseDataResetPeriod.Month => "MONTH",
                PromotionalRevokeResponseDataResetPeriod.Week => "WEEK",
                PromotionalRevokeResponseDataResetPeriod.Day => "DAY",
                PromotionalRevokeResponseDataResetPeriod.Hour => "HOUR",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The reset period configuration of the entitlement
/// </summary>
[JsonConverter(typeof(PromotionalRevokeResponseDataResetPeriodConfigurationConverter))]
public record class PromotionalRevokeResponseDataResetPeriodConfiguration : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public PromotionalRevokeResponseDataResetPeriodConfiguration(
        PromotionalRevokeResponseDataResetPeriodConfigurationAccordingTo value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PromotionalRevokeResponseDataResetPeriodConfiguration(
        AccordingTo2 value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PromotionalRevokeResponseDataResetPeriodConfiguration(
        AccordingTo3 value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PromotionalRevokeResponseDataResetPeriodConfiguration(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="PromotionalRevokeResponseDataResetPeriodConfigurationAccordingTo"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickPromotionalRevokeResponseDataResetPeriodConfigurationAccordingTo(out var value)) {
    ///     // `value` is of type `PromotionalRevokeResponseDataResetPeriodConfigurationAccordingTo`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickPromotionalRevokeResponseDataResetPeriodConfigurationAccordingTo(
        [NotNullWhen(true)]
            out PromotionalRevokeResponseDataResetPeriodConfigurationAccordingTo? value
    )
    {
        value = this.Value as PromotionalRevokeResponseDataResetPeriodConfigurationAccordingTo;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="AccordingTo2"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAccordingTo2(out var value)) {
    ///     // `value` is of type `AccordingTo2`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAccordingTo2([NotNullWhen(true)] out AccordingTo2? value)
    {
        value = this.Value as AccordingTo2;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="AccordingTo3"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAccordingTo3(out var value)) {
    ///     // `value` is of type `AccordingTo3`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAccordingTo3([NotNullWhen(true)] out AccordingTo3? value)
    {
        value = this.Value as AccordingTo3;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="StiggInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (PromotionalRevokeResponseDataResetPeriodConfigurationAccordingTo value) => {...},
    ///     (AccordingTo2 value) => {...},
    ///     (AccordingTo3 value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<PromotionalRevokeResponseDataResetPeriodConfigurationAccordingTo> promotionalRevokeResponseDataResetPeriodConfigurationAccordingTo,
        System::Action<AccordingTo2> accordingTo2,
        System::Action<AccordingTo3> accordingTo3
    )
    {
        switch (this.Value)
        {
            case PromotionalRevokeResponseDataResetPeriodConfigurationAccordingTo value:
                promotionalRevokeResponseDataResetPeriodConfigurationAccordingTo(value);
                break;
            case AccordingTo2 value:
                accordingTo2(value);
                break;
            case AccordingTo3 value:
                accordingTo3(value);
                break;
            default:
                throw new StiggInvalidDataException(
                    "Data did not match any variant of PromotionalRevokeResponseDataResetPeriodConfiguration"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="StiggInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (PromotionalRevokeResponseDataResetPeriodConfigurationAccordingTo value) => {...},
    ///     (AccordingTo2 value) => {...},
    ///     (AccordingTo3 value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<
            PromotionalRevokeResponseDataResetPeriodConfigurationAccordingTo,
            T
        > promotionalRevokeResponseDataResetPeriodConfigurationAccordingTo,
        System::Func<AccordingTo2, T> accordingTo2,
        System::Func<AccordingTo3, T> accordingTo3
    )
    {
        return this.Value switch
        {
            PromotionalRevokeResponseDataResetPeriodConfigurationAccordingTo value =>
                promotionalRevokeResponseDataResetPeriodConfigurationAccordingTo(value),
            AccordingTo2 value => accordingTo2(value),
            AccordingTo3 value => accordingTo3(value),
            _ => throw new StiggInvalidDataException(
                "Data did not match any variant of PromotionalRevokeResponseDataResetPeriodConfiguration"
            ),
        };
    }

    public static implicit operator PromotionalRevokeResponseDataResetPeriodConfiguration(
        PromotionalRevokeResponseDataResetPeriodConfigurationAccordingTo value
    ) => new(value);

    public static implicit operator PromotionalRevokeResponseDataResetPeriodConfiguration(
        AccordingTo2 value
    ) => new(value);

    public static implicit operator PromotionalRevokeResponseDataResetPeriodConfiguration(
        AccordingTo3 value
    ) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="StiggInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new StiggInvalidDataException(
                "Data did not match any variant of PromotionalRevokeResponseDataResetPeriodConfiguration"
            );
        }
        this.Switch(
            (promotionalRevokeResponseDataResetPeriodConfigurationAccordingTo) =>
                promotionalRevokeResponseDataResetPeriodConfigurationAccordingTo.Validate(),
            (accordingTo2) => accordingTo2.Validate(),
            (accordingTo3) => accordingTo3.Validate()
        );
    }

    public virtual bool Equals(PromotionalRevokeResponseDataResetPeriodConfiguration? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(this._element, ModelBase.ToStringSerializerOptions);
}

sealed class PromotionalRevokeResponseDataResetPeriodConfigurationConverter
    : JsonConverter<PromotionalRevokeResponseDataResetPeriodConfiguration?>
{
    public override PromotionalRevokeResponseDataResetPeriodConfiguration? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized =
                JsonSerializer.Deserialize<PromotionalRevokeResponseDataResetPeriodConfigurationAccordingTo>(
                    element,
                    options
                );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is StiggInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<AccordingTo2>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is StiggInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<AccordingTo3>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is StiggInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        PromotionalRevokeResponseDataResetPeriodConfiguration? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        PromotionalRevokeResponseDataResetPeriodConfigurationAccordingTo,
        PromotionalRevokeResponseDataResetPeriodConfigurationAccordingToFromRaw
    >)
)]
public sealed record class PromotionalRevokeResponseDataResetPeriodConfigurationAccordingTo
    : JsonModel
{
    /// <summary>
    /// Yearly reset period according to
    /// </summary>
    public required ApiEnum<
        string,
        PromotionalRevokeResponseDataResetPeriodConfigurationAccordingToAccordingTo
    > AccordingTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    PromotionalRevokeResponseDataResetPeriodConfigurationAccordingToAccordingTo
                >
            >("accordingTo");
        }
        init { this._rawData.Set("accordingTo", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.AccordingTo.Validate();
    }

    public PromotionalRevokeResponseDataResetPeriodConfigurationAccordingTo() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PromotionalRevokeResponseDataResetPeriodConfigurationAccordingTo(
        PromotionalRevokeResponseDataResetPeriodConfigurationAccordingTo promotionalRevokeResponseDataResetPeriodConfigurationAccordingTo
    )
        : base(promotionalRevokeResponseDataResetPeriodConfigurationAccordingTo) { }
#pragma warning restore CS8618

    public PromotionalRevokeResponseDataResetPeriodConfigurationAccordingTo(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PromotionalRevokeResponseDataResetPeriodConfigurationAccordingTo(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PromotionalRevokeResponseDataResetPeriodConfigurationAccordingToFromRaw.FromRawUnchecked"/>
    public static PromotionalRevokeResponseDataResetPeriodConfigurationAccordingTo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PromotionalRevokeResponseDataResetPeriodConfigurationAccordingTo(
        ApiEnum<
            string,
            PromotionalRevokeResponseDataResetPeriodConfigurationAccordingToAccordingTo
        > accordingTo
    )
        : this()
    {
        this.AccordingTo = accordingTo;
    }
}

class PromotionalRevokeResponseDataResetPeriodConfigurationAccordingToFromRaw
    : IFromRawJson<PromotionalRevokeResponseDataResetPeriodConfigurationAccordingTo>
{
    /// <inheritdoc/>
    public PromotionalRevokeResponseDataResetPeriodConfigurationAccordingTo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PromotionalRevokeResponseDataResetPeriodConfigurationAccordingTo.FromRawUnchecked(rawData);
}

/// <summary>
/// Yearly reset period according to
/// </summary>
[JsonConverter(
    typeof(PromotionalRevokeResponseDataResetPeriodConfigurationAccordingToAccordingToConverter)
)]
public enum PromotionalRevokeResponseDataResetPeriodConfigurationAccordingToAccordingTo
{
    SubscriptionStart,
}

sealed class PromotionalRevokeResponseDataResetPeriodConfigurationAccordingToAccordingToConverter
    : JsonConverter<PromotionalRevokeResponseDataResetPeriodConfigurationAccordingToAccordingTo>
{
    public override PromotionalRevokeResponseDataResetPeriodConfigurationAccordingToAccordingTo Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SubscriptionStart" =>
                PromotionalRevokeResponseDataResetPeriodConfigurationAccordingToAccordingTo.SubscriptionStart,
            _ => (PromotionalRevokeResponseDataResetPeriodConfigurationAccordingToAccordingTo)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PromotionalRevokeResponseDataResetPeriodConfigurationAccordingToAccordingTo value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PromotionalRevokeResponseDataResetPeriodConfigurationAccordingToAccordingTo.SubscriptionStart =>
                    "SubscriptionStart",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<AccordingTo2, AccordingTo2FromRaw>))]
public sealed record class AccordingTo2 : JsonModel
{
    /// <summary>
    /// Monthly reset period according to
    /// </summary>
    public required ApiEnum<string, AccordingTo2AccordingTo> AccordingTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AccordingTo2AccordingTo>>(
                "accordingTo"
            );
        }
        init { this._rawData.Set("accordingTo", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.AccordingTo.Validate();
    }

    public AccordingTo2() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccordingTo2(AccordingTo2 accordingTo2)
        : base(accordingTo2) { }
#pragma warning restore CS8618

    public AccordingTo2(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccordingTo2(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccordingTo2FromRaw.FromRawUnchecked"/>
    public static AccordingTo2 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AccordingTo2(ApiEnum<string, AccordingTo2AccordingTo> accordingTo)
        : this()
    {
        this.AccordingTo = accordingTo;
    }
}

class AccordingTo2FromRaw : IFromRawJson<AccordingTo2>
{
    /// <inheritdoc/>
    public AccordingTo2 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AccordingTo2.FromRawUnchecked(rawData);
}

/// <summary>
/// Monthly reset period according to
/// </summary>
[JsonConverter(typeof(AccordingTo2AccordingToConverter))]
public enum AccordingTo2AccordingTo
{
    SubscriptionStart,
    StartOfTheMonth,
}

sealed class AccordingTo2AccordingToConverter : JsonConverter<AccordingTo2AccordingTo>
{
    public override AccordingTo2AccordingTo Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SubscriptionStart" => AccordingTo2AccordingTo.SubscriptionStart,
            "StartOfTheMonth" => AccordingTo2AccordingTo.StartOfTheMonth,
            _ => (AccordingTo2AccordingTo)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AccordingTo2AccordingTo value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AccordingTo2AccordingTo.SubscriptionStart => "SubscriptionStart",
                AccordingTo2AccordingTo.StartOfTheMonth => "StartOfTheMonth",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<AccordingTo3, AccordingTo3FromRaw>))]
public sealed record class AccordingTo3 : JsonModel
{
    /// <summary>
    /// Weekly reset period according to
    /// </summary>
    public required ApiEnum<string, AccordingTo3AccordingTo> AccordingTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AccordingTo3AccordingTo>>(
                "accordingTo"
            );
        }
        init { this._rawData.Set("accordingTo", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.AccordingTo.Validate();
    }

    public AccordingTo3() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccordingTo3(AccordingTo3 accordingTo3)
        : base(accordingTo3) { }
#pragma warning restore CS8618

    public AccordingTo3(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccordingTo3(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccordingTo3FromRaw.FromRawUnchecked"/>
    public static AccordingTo3 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AccordingTo3(ApiEnum<string, AccordingTo3AccordingTo> accordingTo)
        : this()
    {
        this.AccordingTo = accordingTo;
    }
}

class AccordingTo3FromRaw : IFromRawJson<AccordingTo3>
{
    /// <inheritdoc/>
    public AccordingTo3 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AccordingTo3.FromRawUnchecked(rawData);
}

/// <summary>
/// Weekly reset period according to
/// </summary>
[JsonConverter(typeof(AccordingTo3AccordingToConverter))]
public enum AccordingTo3AccordingTo
{
    SubscriptionStart,
    EverySunday,
    EveryMonday,
    EveryTuesday,
    EveryWednesday,
    EveryThursday,
    EveryFriday,
    EverySaturday,
}

sealed class AccordingTo3AccordingToConverter : JsonConverter<AccordingTo3AccordingTo>
{
    public override AccordingTo3AccordingTo Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SubscriptionStart" => AccordingTo3AccordingTo.SubscriptionStart,
            "EverySunday" => AccordingTo3AccordingTo.EverySunday,
            "EveryMonday" => AccordingTo3AccordingTo.EveryMonday,
            "EveryTuesday" => AccordingTo3AccordingTo.EveryTuesday,
            "EveryWednesday" => AccordingTo3AccordingTo.EveryWednesday,
            "EveryThursday" => AccordingTo3AccordingTo.EveryThursday,
            "EveryFriday" => AccordingTo3AccordingTo.EveryFriday,
            "EverySaturday" => AccordingTo3AccordingTo.EverySaturday,
            _ => (AccordingTo3AccordingTo)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AccordingTo3AccordingTo value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AccordingTo3AccordingTo.SubscriptionStart => "SubscriptionStart",
                AccordingTo3AccordingTo.EverySunday => "EverySunday",
                AccordingTo3AccordingTo.EveryMonday => "EveryMonday",
                AccordingTo3AccordingTo.EveryTuesday => "EveryTuesday",
                AccordingTo3AccordingTo.EveryWednesday => "EveryWednesday",
                AccordingTo3AccordingTo.EveryThursday => "EveryThursday",
                AccordingTo3AccordingTo.EveryFriday => "EveryFriday",
                AccordingTo3AccordingTo.EverySaturday => "EverySaturday",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The status of the entitlement
/// </summary>
[JsonConverter(typeof(PromotionalRevokeResponseDataStatusConverter))]
public enum PromotionalRevokeResponseDataStatus
{
    Active,
    Expired,
    Paused,
}

sealed class PromotionalRevokeResponseDataStatusConverter
    : JsonConverter<PromotionalRevokeResponseDataStatus>
{
    public override PromotionalRevokeResponseDataStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Active" => PromotionalRevokeResponseDataStatus.Active,
            "Expired" => PromotionalRevokeResponseDataStatus.Expired,
            "Paused" => PromotionalRevokeResponseDataStatus.Paused,
            _ => (PromotionalRevokeResponseDataStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PromotionalRevokeResponseDataStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PromotionalRevokeResponseDataStatus.Active => "Active",
                PromotionalRevokeResponseDataStatus.Expired => "Expired",
                PromotionalRevokeResponseDataStatus.Paused => "Paused",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
