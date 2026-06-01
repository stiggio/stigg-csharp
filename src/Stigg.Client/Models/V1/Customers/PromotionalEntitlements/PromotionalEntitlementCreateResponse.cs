using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using System = System;

namespace Stigg.Client.Models.V1.Customers.PromotionalEntitlements;

/// <summary>
/// Response object
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        PromotionalEntitlementCreateResponse,
        PromotionalEntitlementCreateResponseFromRaw
    >)
)]
public sealed record class PromotionalEntitlementCreateResponse : JsonModel
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

    public PromotionalEntitlementCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PromotionalEntitlementCreateResponse(
        PromotionalEntitlementCreateResponse promotionalEntitlementCreateResponse
    )
        : base(promotionalEntitlementCreateResponse) { }
#pragma warning restore CS8618

    public PromotionalEntitlementCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PromotionalEntitlementCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PromotionalEntitlementCreateResponseFromRaw.FromRawUnchecked"/>
    public static PromotionalEntitlementCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PromotionalEntitlementCreateResponse(IReadOnlyList<Data> data)
        : this()
    {
        this.Data = data;
    }
}

class PromotionalEntitlementCreateResponseFromRaw
    : IFromRawJson<PromotionalEntitlementCreateResponse>
{
    /// <inheritdoc/>
    public PromotionalEntitlementCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PromotionalEntitlementCreateResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Granted feature entitlement
/// </summary>
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
    public required ApiEnum<string, DataStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, DataStatus>>("status");
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Data(Data data)
        : base(data) { }
#pragma warning restore CS8618

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

    public ResetPeriodConfiguration(YearlyResetPeriodConfig value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ResetPeriodConfiguration(MonthlyResetPeriodConfig value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ResetPeriodConfiguration(WeeklyResetPeriodConfig value, JsonElement? element = null)
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
    /// type <see cref="YearlyResetPeriodConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickYearlyResetPeriodConfig(out var value)) {
    ///     // `value` is of type `YearlyResetPeriodConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickYearlyResetPeriodConfig(
        [NotNullWhen(true)] out YearlyResetPeriodConfig? value
    )
    {
        value = this.Value as YearlyResetPeriodConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="MonthlyResetPeriodConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMonthlyResetPeriodConfig(out var value)) {
    ///     // `value` is of type `MonthlyResetPeriodConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMonthlyResetPeriodConfig(
        [NotNullWhen(true)] out MonthlyResetPeriodConfig? value
    )
    {
        value = this.Value as MonthlyResetPeriodConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="WeeklyResetPeriodConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickWeeklyResetPeriodConfig(out var value)) {
    ///     // `value` is of type `WeeklyResetPeriodConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickWeeklyResetPeriodConfig(
        [NotNullWhen(true)] out WeeklyResetPeriodConfig? value
    )
    {
        value = this.Value as WeeklyResetPeriodConfig;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
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
    ///     (YearlyResetPeriodConfig value) =&gt; {...},
    ///     (MonthlyResetPeriodConfig value) =&gt; {...},
    ///     (WeeklyResetPeriodConfig value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<YearlyResetPeriodConfig> yearlyResetPeriodConfig,
        System::Action<MonthlyResetPeriodConfig> monthlyResetPeriodConfig,
        System::Action<WeeklyResetPeriodConfig> weeklyResetPeriodConfig
    )
    {
        switch (this.Value)
        {
            case YearlyResetPeriodConfig value:
                yearlyResetPeriodConfig(value);
                break;
            case MonthlyResetPeriodConfig value:
                monthlyResetPeriodConfig(value);
                break;
            case WeeklyResetPeriodConfig value:
                weeklyResetPeriodConfig(value);
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
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
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
    ///     (YearlyResetPeriodConfig value) =&gt; {...},
    ///     (MonthlyResetPeriodConfig value) =&gt; {...},
    ///     (WeeklyResetPeriodConfig value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<YearlyResetPeriodConfig, T> yearlyResetPeriodConfig,
        System::Func<MonthlyResetPeriodConfig, T> monthlyResetPeriodConfig,
        System::Func<WeeklyResetPeriodConfig, T> weeklyResetPeriodConfig
    )
    {
        return this.Value switch
        {
            YearlyResetPeriodConfig value => yearlyResetPeriodConfig(value),
            MonthlyResetPeriodConfig value => monthlyResetPeriodConfig(value),
            WeeklyResetPeriodConfig value => weeklyResetPeriodConfig(value),
            _ => throw new StiggInvalidDataException(
                "Data did not match any variant of ResetPeriodConfiguration"
            ),
        };
    }

    public static implicit operator ResetPeriodConfiguration(YearlyResetPeriodConfig value) =>
        new(value);

    public static implicit operator ResetPeriodConfiguration(MonthlyResetPeriodConfig value) =>
        new(value);

    public static implicit operator ResetPeriodConfiguration(WeeklyResetPeriodConfig value) =>
        new(value);

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
            (yearlyResetPeriodConfig) => yearlyResetPeriodConfig.Validate(),
            (monthlyResetPeriodConfig) => monthlyResetPeriodConfig.Validate(),
            (weeklyResetPeriodConfig) => weeklyResetPeriodConfig.Validate()
        );
    }

    public virtual bool Equals(ResetPeriodConfiguration? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            YearlyResetPeriodConfig _ => 0,
            MonthlyResetPeriodConfig _ => 1,
            WeeklyResetPeriodConfig _ => 2,
            _ => -1,
        };
    }
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
            var deserialized = JsonSerializer.Deserialize<YearlyResetPeriodConfig>(
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
            var deserialized = JsonSerializer.Deserialize<MonthlyResetPeriodConfig>(
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
            var deserialized = JsonSerializer.Deserialize<WeeklyResetPeriodConfig>(
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

/// <summary>
/// Yearly reset configuration
/// </summary>
[JsonConverter(typeof(JsonModelConverter<YearlyResetPeriodConfig, YearlyResetPeriodConfigFromRaw>))]
public sealed record class YearlyResetPeriodConfig : JsonModel
{
    /// <summary>
    /// Reset anchor (SubscriptionStart)
    /// </summary>
    public required ApiEnum<string, YearlyResetPeriodConfigAccordingTo> AccordingTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, YearlyResetPeriodConfigAccordingTo>
            >("accordingTo");
        }
        init { this._rawData.Set("accordingTo", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.AccordingTo.Validate();
    }

    public YearlyResetPeriodConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public YearlyResetPeriodConfig(YearlyResetPeriodConfig yearlyResetPeriodConfig)
        : base(yearlyResetPeriodConfig) { }
#pragma warning restore CS8618

    public YearlyResetPeriodConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    YearlyResetPeriodConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="YearlyResetPeriodConfigFromRaw.FromRawUnchecked"/>
    public static YearlyResetPeriodConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public YearlyResetPeriodConfig(ApiEnum<string, YearlyResetPeriodConfigAccordingTo> accordingTo)
        : this()
    {
        this.AccordingTo = accordingTo;
    }
}

class YearlyResetPeriodConfigFromRaw : IFromRawJson<YearlyResetPeriodConfig>
{
    /// <inheritdoc/>
    public YearlyResetPeriodConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => YearlyResetPeriodConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Reset anchor (SubscriptionStart)
/// </summary>
[JsonConverter(typeof(YearlyResetPeriodConfigAccordingToConverter))]
public enum YearlyResetPeriodConfigAccordingTo
{
    SubscriptionStart,
}

sealed class YearlyResetPeriodConfigAccordingToConverter
    : JsonConverter<YearlyResetPeriodConfigAccordingTo>
{
    public override YearlyResetPeriodConfigAccordingTo Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SubscriptionStart" => YearlyResetPeriodConfigAccordingTo.SubscriptionStart,
            _ => (YearlyResetPeriodConfigAccordingTo)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        YearlyResetPeriodConfigAccordingTo value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                YearlyResetPeriodConfigAccordingTo.SubscriptionStart => "SubscriptionStart",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Monthly reset configuration
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<MonthlyResetPeriodConfig, MonthlyResetPeriodConfigFromRaw>)
)]
public sealed record class MonthlyResetPeriodConfig : JsonModel
{
    /// <summary>
    /// Reset anchor (SubscriptionStart or StartOfTheMonth)
    /// </summary>
    public required ApiEnum<string, MonthlyResetPeriodConfigAccordingTo> AccordingTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, MonthlyResetPeriodConfigAccordingTo>
            >("accordingTo");
        }
        init { this._rawData.Set("accordingTo", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.AccordingTo.Validate();
    }

    public MonthlyResetPeriodConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MonthlyResetPeriodConfig(MonthlyResetPeriodConfig monthlyResetPeriodConfig)
        : base(monthlyResetPeriodConfig) { }
#pragma warning restore CS8618

    public MonthlyResetPeriodConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MonthlyResetPeriodConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MonthlyResetPeriodConfigFromRaw.FromRawUnchecked"/>
    public static MonthlyResetPeriodConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public MonthlyResetPeriodConfig(
        ApiEnum<string, MonthlyResetPeriodConfigAccordingTo> accordingTo
    )
        : this()
    {
        this.AccordingTo = accordingTo;
    }
}

class MonthlyResetPeriodConfigFromRaw : IFromRawJson<MonthlyResetPeriodConfig>
{
    /// <inheritdoc/>
    public MonthlyResetPeriodConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MonthlyResetPeriodConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Reset anchor (SubscriptionStart or StartOfTheMonth)
/// </summary>
[JsonConverter(typeof(MonthlyResetPeriodConfigAccordingToConverter))]
public enum MonthlyResetPeriodConfigAccordingTo
{
    SubscriptionStart,
    StartOfTheMonth,
}

sealed class MonthlyResetPeriodConfigAccordingToConverter
    : JsonConverter<MonthlyResetPeriodConfigAccordingTo>
{
    public override MonthlyResetPeriodConfigAccordingTo Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SubscriptionStart" => MonthlyResetPeriodConfigAccordingTo.SubscriptionStart,
            "StartOfTheMonth" => MonthlyResetPeriodConfigAccordingTo.StartOfTheMonth,
            _ => (MonthlyResetPeriodConfigAccordingTo)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MonthlyResetPeriodConfigAccordingTo value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MonthlyResetPeriodConfigAccordingTo.SubscriptionStart => "SubscriptionStart",
                MonthlyResetPeriodConfigAccordingTo.StartOfTheMonth => "StartOfTheMonth",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Weekly reset configuration
/// </summary>
[JsonConverter(typeof(JsonModelConverter<WeeklyResetPeriodConfig, WeeklyResetPeriodConfigFromRaw>))]
public sealed record class WeeklyResetPeriodConfig : JsonModel
{
    /// <summary>
    /// Reset anchor (SubscriptionStart or specific day)
    /// </summary>
    public required ApiEnum<string, WeeklyResetPeriodConfigAccordingTo> AccordingTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, WeeklyResetPeriodConfigAccordingTo>
            >("accordingTo");
        }
        init { this._rawData.Set("accordingTo", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.AccordingTo.Validate();
    }

    public WeeklyResetPeriodConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WeeklyResetPeriodConfig(WeeklyResetPeriodConfig weeklyResetPeriodConfig)
        : base(weeklyResetPeriodConfig) { }
#pragma warning restore CS8618

    public WeeklyResetPeriodConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WeeklyResetPeriodConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WeeklyResetPeriodConfigFromRaw.FromRawUnchecked"/>
    public static WeeklyResetPeriodConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public WeeklyResetPeriodConfig(ApiEnum<string, WeeklyResetPeriodConfigAccordingTo> accordingTo)
        : this()
    {
        this.AccordingTo = accordingTo;
    }
}

class WeeklyResetPeriodConfigFromRaw : IFromRawJson<WeeklyResetPeriodConfig>
{
    /// <inheritdoc/>
    public WeeklyResetPeriodConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WeeklyResetPeriodConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Reset anchor (SubscriptionStart or specific day)
/// </summary>
[JsonConverter(typeof(WeeklyResetPeriodConfigAccordingToConverter))]
public enum WeeklyResetPeriodConfigAccordingTo
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

sealed class WeeklyResetPeriodConfigAccordingToConverter
    : JsonConverter<WeeklyResetPeriodConfigAccordingTo>
{
    public override WeeklyResetPeriodConfigAccordingTo Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SubscriptionStart" => WeeklyResetPeriodConfigAccordingTo.SubscriptionStart,
            "EverySunday" => WeeklyResetPeriodConfigAccordingTo.EverySunday,
            "EveryMonday" => WeeklyResetPeriodConfigAccordingTo.EveryMonday,
            "EveryTuesday" => WeeklyResetPeriodConfigAccordingTo.EveryTuesday,
            "EveryWednesday" => WeeklyResetPeriodConfigAccordingTo.EveryWednesday,
            "EveryThursday" => WeeklyResetPeriodConfigAccordingTo.EveryThursday,
            "EveryFriday" => WeeklyResetPeriodConfigAccordingTo.EveryFriday,
            "EverySaturday" => WeeklyResetPeriodConfigAccordingTo.EverySaturday,
            _ => (WeeklyResetPeriodConfigAccordingTo)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WeeklyResetPeriodConfigAccordingTo value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                WeeklyResetPeriodConfigAccordingTo.SubscriptionStart => "SubscriptionStart",
                WeeklyResetPeriodConfigAccordingTo.EverySunday => "EverySunday",
                WeeklyResetPeriodConfigAccordingTo.EveryMonday => "EveryMonday",
                WeeklyResetPeriodConfigAccordingTo.EveryTuesday => "EveryTuesday",
                WeeklyResetPeriodConfigAccordingTo.EveryWednesday => "EveryWednesday",
                WeeklyResetPeriodConfigAccordingTo.EveryThursday => "EveryThursday",
                WeeklyResetPeriodConfigAccordingTo.EveryFriday => "EveryFriday",
                WeeklyResetPeriodConfigAccordingTo.EverySaturday => "EverySaturday",
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
[JsonConverter(typeof(DataStatusConverter))]
public enum DataStatus
{
    Active,
    Expired,
    Paused,
}

sealed class DataStatusConverter : JsonConverter<DataStatus>
{
    public override DataStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Active" => DataStatus.Active,
            "Expired" => DataStatus.Expired,
            "Paused" => DataStatus.Paused,
            _ => (DataStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DataStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DataStatus.Active => "Active",
                DataStatus.Expired => "Expired",
                DataStatus.Paused => "Paused",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
