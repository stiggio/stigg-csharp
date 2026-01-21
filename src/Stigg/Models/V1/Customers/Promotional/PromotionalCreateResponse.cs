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
    typeof(JsonModelConverter<PromotionalCreateResponse, PromotionalCreateResponseFromRaw>)
)]
public sealed record class PromotionalCreateResponse : JsonModel
{
    public required IReadOnlyList<Data> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Data>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Data>>("data", ImmutableArray.ToImmutableArray(value));
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
    }

    public PromotionalCreateResponse() { }

    public PromotionalCreateResponse(PromotionalCreateResponse promotionalCreateResponse)
        : base(promotionalCreateResponse) { }

    public PromotionalCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PromotionalCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PromotionalCreateResponseFromRaw.FromRawUnchecked"/>
    public static PromotionalCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PromotionalCreateResponse(IReadOnlyList<Data> data)
        : this()
    {
        this.Data = data;
    }
}

class PromotionalCreateResponseFromRaw : IFromRawJson<PromotionalCreateResponse>
{
    /// <inheritdoc/>
    public PromotionalCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PromotionalCreateResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
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
    public required ApiEnum<string, DataPeriod> Period
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, DataPeriod>>("period");
        }
        init { this._rawData.Set("period", value); }
    }

    /// <summary>
    /// The reset period of the entitlement
    /// </summary>
    public required ApiEnum<string, DataResetPeriod>? ResetPeriod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, DataResetPeriod>>("resetPeriod");
        }
        init { this._rawData.Set("resetPeriod", value); }
    }

    /// <summary>
    /// The reset period configuration of the entitlement
    /// </summary>
    public required ResetPeriodConfiguration? ResetPeriodConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ResetPeriodConfiguration>(
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
    public required ApiEnum<string, Status> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Status>>("status");
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

    public Data() { }

    public Data(Data data)
        : base(data) { }

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

/// <summary>
/// The grant period of the promotional entitlement
/// </summary>
[JsonConverter(typeof(DataPeriodConverter))]
public enum DataPeriod
{
    V1Week,
    V1Month,
    V6Month,
    V1Year,
    Lifetime,
    Custom,
}

sealed class DataPeriodConverter : JsonConverter<DataPeriod>
{
    public override DataPeriod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "1 week" => DataPeriod.V1Week,
            "1 month" => DataPeriod.V1Month,
            "6 month" => DataPeriod.V6Month,
            "1 year" => DataPeriod.V1Year,
            "lifetime" => DataPeriod.Lifetime,
            "custom" => DataPeriod.Custom,
            _ => (DataPeriod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DataPeriod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DataPeriod.V1Week => "1 week",
                DataPeriod.V1Month => "1 month",
                DataPeriod.V6Month => "6 month",
                DataPeriod.V1Year => "1 year",
                DataPeriod.Lifetime => "lifetime",
                DataPeriod.Custom => "custom",
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
[JsonConverter(typeof(DataResetPeriodConverter))]
public enum DataResetPeriod
{
    Year,
    Month,
    Week,
    Day,
    Hour,
}

sealed class DataResetPeriodConverter : JsonConverter<DataResetPeriod>
{
    public override DataResetPeriod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "YEAR" => DataResetPeriod.Year,
            "MONTH" => DataResetPeriod.Month,
            "WEEK" => DataResetPeriod.Week,
            "DAY" => DataResetPeriod.Day,
            "HOUR" => DataResetPeriod.Hour,
            _ => (DataResetPeriod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DataResetPeriod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DataResetPeriod.Year => "YEAR",
                DataResetPeriod.Month => "MONTH",
                DataResetPeriod.Week => "WEEK",
                DataResetPeriod.Day => "DAY",
                DataResetPeriod.Hour => "HOUR",
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
[JsonConverter(typeof(ResetPeriodConfigurationConverter))]
public record class ResetPeriodConfiguration : ModelBase
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

    public ResetPeriodConfiguration(
        ResetPeriodConfigurationAccordingTo value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ResetPeriodConfiguration(AccordingToModel value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ResetPeriodConfiguration(AccordingTo1 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ResetPeriodConfiguration(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ResetPeriodConfigurationAccordingTo"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickResetPeriodConfigurationAccordingTo(out var value)) {
    ///     // `value` is of type `ResetPeriodConfigurationAccordingTo`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickResetPeriodConfigurationAccordingTo(
        [NotNullWhen(true)] out ResetPeriodConfigurationAccordingTo? value
    )
    {
        value = this.Value as ResetPeriodConfigurationAccordingTo;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="AccordingToModel"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAccordingToModel(out var value)) {
    ///     // `value` is of type `AccordingToModel`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAccordingToModel([NotNullWhen(true)] out AccordingToModel? value)
    {
        value = this.Value as AccordingToModel;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="AccordingTo1"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAccordingTo1(out var value)) {
    ///     // `value` is of type `AccordingTo1`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAccordingTo1([NotNullWhen(true)] out AccordingTo1? value)
    {
        value = this.Value as AccordingTo1;
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
    ///     (ResetPeriodConfigurationAccordingTo value) => {...},
    ///     (AccordingToModel value) => {...},
    ///     (AccordingTo1 value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<ResetPeriodConfigurationAccordingTo> resetPeriodConfigurationAccordingTo,
        System::Action<AccordingToModel> accordingToModel,
        System::Action<AccordingTo1> accordingTo1
    )
    {
        switch (this.Value)
        {
            case ResetPeriodConfigurationAccordingTo value:
                resetPeriodConfigurationAccordingTo(value);
                break;
            case AccordingToModel value:
                accordingToModel(value);
                break;
            case AccordingTo1 value:
                accordingTo1(value);
                break;
            default:
                throw new StiggInvalidDataException(
                    "Data did not match any variant of ResetPeriodConfiguration"
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
    ///     (ResetPeriodConfigurationAccordingTo value) => {...},
    ///     (AccordingToModel value) => {...},
    ///     (AccordingTo1 value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<ResetPeriodConfigurationAccordingTo, T> resetPeriodConfigurationAccordingTo,
        System::Func<AccordingToModel, T> accordingToModel,
        System::Func<AccordingTo1, T> accordingTo1
    )
    {
        return this.Value switch
        {
            ResetPeriodConfigurationAccordingTo value => resetPeriodConfigurationAccordingTo(value),
            AccordingToModel value => accordingToModel(value),
            AccordingTo1 value => accordingTo1(value),
            _ => throw new StiggInvalidDataException(
                "Data did not match any variant of ResetPeriodConfiguration"
            ),
        };
    }

    public static implicit operator ResetPeriodConfiguration(
        ResetPeriodConfigurationAccordingTo value
    ) => new(value);

    public static implicit operator ResetPeriodConfiguration(AccordingToModel value) => new(value);

    public static implicit operator ResetPeriodConfiguration(AccordingTo1 value) => new(value);

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
                "Data did not match any variant of ResetPeriodConfiguration"
            );
        }
        this.Switch(
            (resetPeriodConfigurationAccordingTo) => resetPeriodConfigurationAccordingTo.Validate(),
            (accordingToModel) => accordingToModel.Validate(),
            (accordingTo1) => accordingTo1.Validate()
        );
    }

    public virtual bool Equals(ResetPeriodConfiguration? other)
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

sealed class ResetPeriodConfigurationConverter : JsonConverter<ResetPeriodConfiguration?>
{
    public override ResetPeriodConfiguration? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<ResetPeriodConfigurationAccordingTo>(
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
            var deserialized = JsonSerializer.Deserialize<AccordingToModel>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<AccordingTo1>(element, options);
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
        ResetPeriodConfiguration? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        ResetPeriodConfigurationAccordingTo,
        ResetPeriodConfigurationAccordingToFromRaw
    >)
)]
public sealed record class ResetPeriodConfigurationAccordingTo : JsonModel
{
    /// <summary>
    /// Yearly reset period according to
    /// </summary>
    public required ApiEnum<string, ResetPeriodConfigurationAccordingToAccordingTo> AccordingTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ResetPeriodConfigurationAccordingToAccordingTo>
            >("accordingTo");
        }
        init { this._rawData.Set("accordingTo", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.AccordingTo.Validate();
    }

    public ResetPeriodConfigurationAccordingTo() { }

    public ResetPeriodConfigurationAccordingTo(
        ResetPeriodConfigurationAccordingTo resetPeriodConfigurationAccordingTo
    )
        : base(resetPeriodConfigurationAccordingTo) { }

    public ResetPeriodConfigurationAccordingTo(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ResetPeriodConfigurationAccordingTo(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ResetPeriodConfigurationAccordingToFromRaw.FromRawUnchecked"/>
    public static ResetPeriodConfigurationAccordingTo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ResetPeriodConfigurationAccordingTo(
        ApiEnum<string, ResetPeriodConfigurationAccordingToAccordingTo> accordingTo
    )
        : this()
    {
        this.AccordingTo = accordingTo;
    }
}

class ResetPeriodConfigurationAccordingToFromRaw : IFromRawJson<ResetPeriodConfigurationAccordingTo>
{
    /// <inheritdoc/>
    public ResetPeriodConfigurationAccordingTo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ResetPeriodConfigurationAccordingTo.FromRawUnchecked(rawData);
}

/// <summary>
/// Yearly reset period according to
/// </summary>
[JsonConverter(typeof(ResetPeriodConfigurationAccordingToAccordingToConverter))]
public enum ResetPeriodConfigurationAccordingToAccordingTo
{
    SubscriptionStart,
}

sealed class ResetPeriodConfigurationAccordingToAccordingToConverter
    : JsonConverter<ResetPeriodConfigurationAccordingToAccordingTo>
{
    public override ResetPeriodConfigurationAccordingToAccordingTo Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SubscriptionStart" => ResetPeriodConfigurationAccordingToAccordingTo.SubscriptionStart,
            _ => (ResetPeriodConfigurationAccordingToAccordingTo)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ResetPeriodConfigurationAccordingToAccordingTo value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ResetPeriodConfigurationAccordingToAccordingTo.SubscriptionStart =>
                    "SubscriptionStart",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<AccordingToModel, AccordingToModelFromRaw>))]
public sealed record class AccordingToModel : JsonModel
{
    /// <summary>
    /// Monthly reset period according to
    /// </summary>
    public required ApiEnum<string, AccordingToModelAccordingTo> AccordingTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AccordingToModelAccordingTo>>(
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

    public AccordingToModel() { }

    public AccordingToModel(AccordingToModel accordingToModel)
        : base(accordingToModel) { }

    public AccordingToModel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccordingToModel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccordingToModelFromRaw.FromRawUnchecked"/>
    public static AccordingToModel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AccordingToModel(ApiEnum<string, AccordingToModelAccordingTo> accordingTo)
        : this()
    {
        this.AccordingTo = accordingTo;
    }
}

class AccordingToModelFromRaw : IFromRawJson<AccordingToModel>
{
    /// <inheritdoc/>
    public AccordingToModel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AccordingToModel.FromRawUnchecked(rawData);
}

/// <summary>
/// Monthly reset period according to
/// </summary>
[JsonConverter(typeof(AccordingToModelAccordingToConverter))]
public enum AccordingToModelAccordingTo
{
    SubscriptionStart,
    StartOfTheMonth,
}

sealed class AccordingToModelAccordingToConverter : JsonConverter<AccordingToModelAccordingTo>
{
    public override AccordingToModelAccordingTo Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SubscriptionStart" => AccordingToModelAccordingTo.SubscriptionStart,
            "StartOfTheMonth" => AccordingToModelAccordingTo.StartOfTheMonth,
            _ => (AccordingToModelAccordingTo)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AccordingToModelAccordingTo value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AccordingToModelAccordingTo.SubscriptionStart => "SubscriptionStart",
                AccordingToModelAccordingTo.StartOfTheMonth => "StartOfTheMonth",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<AccordingTo1, AccordingTo1FromRaw>))]
public sealed record class AccordingTo1 : JsonModel
{
    /// <summary>
    /// Weekly reset period according to
    /// </summary>
    public required ApiEnum<string, AccordingTo1AccordingTo> AccordingTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AccordingTo1AccordingTo>>(
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

    public AccordingTo1() { }

    public AccordingTo1(AccordingTo1 accordingTo1)
        : base(accordingTo1) { }

    public AccordingTo1(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccordingTo1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccordingTo1FromRaw.FromRawUnchecked"/>
    public static AccordingTo1 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AccordingTo1(ApiEnum<string, AccordingTo1AccordingTo> accordingTo)
        : this()
    {
        this.AccordingTo = accordingTo;
    }
}

class AccordingTo1FromRaw : IFromRawJson<AccordingTo1>
{
    /// <inheritdoc/>
    public AccordingTo1 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AccordingTo1.FromRawUnchecked(rawData);
}

/// <summary>
/// Weekly reset period according to
/// </summary>
[JsonConverter(typeof(AccordingTo1AccordingToConverter))]
public enum AccordingTo1AccordingTo
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

sealed class AccordingTo1AccordingToConverter : JsonConverter<AccordingTo1AccordingTo>
{
    public override AccordingTo1AccordingTo Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SubscriptionStart" => AccordingTo1AccordingTo.SubscriptionStart,
            "EverySunday" => AccordingTo1AccordingTo.EverySunday,
            "EveryMonday" => AccordingTo1AccordingTo.EveryMonday,
            "EveryTuesday" => AccordingTo1AccordingTo.EveryTuesday,
            "EveryWednesday" => AccordingTo1AccordingTo.EveryWednesday,
            "EveryThursday" => AccordingTo1AccordingTo.EveryThursday,
            "EveryFriday" => AccordingTo1AccordingTo.EveryFriday,
            "EverySaturday" => AccordingTo1AccordingTo.EverySaturday,
            _ => (AccordingTo1AccordingTo)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AccordingTo1AccordingTo value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AccordingTo1AccordingTo.SubscriptionStart => "SubscriptionStart",
                AccordingTo1AccordingTo.EverySunday => "EverySunday",
                AccordingTo1AccordingTo.EveryMonday => "EveryMonday",
                AccordingTo1AccordingTo.EveryTuesday => "EveryTuesday",
                AccordingTo1AccordingTo.EveryWednesday => "EveryWednesday",
                AccordingTo1AccordingTo.EveryThursday => "EveryThursday",
                AccordingTo1AccordingTo.EveryFriday => "EveryFriday",
                AccordingTo1AccordingTo.EverySaturday => "EverySaturday",
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
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Active,
    Expired,
    Paused,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Active" => Status.Active,
            "Expired" => Status.Expired,
            "Paused" => Status.Paused,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Active => "Active",
                Status.Expired => "Expired",
                Status.Paused => "Paused",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
