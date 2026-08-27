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
/// A feature entitlement granted to a customer outside of their subscription plan.
/// Promotional entitlements are applied on top of whatever the subscription already
/// grants and are not removed when a plan or subscription changes; once past their
/// end date they keep appearing in the customer's entitlement list with an Expired
/// status rather than disappearing.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        PromotionalEntitlementListResponse,
        PromotionalEntitlementListResponseFromRaw
    >)
)]
public sealed record class PromotionalEntitlementListResponse : JsonModel
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
    public required ApiEnum<string, PromotionalEntitlementListResponsePeriod> Period
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, PromotionalEntitlementListResponsePeriod>
            >("period");
        }
        init { this._rawData.Set("period", value); }
    }

    /// <summary>
    /// The reset period of the entitlement
    /// </summary>
    public required ApiEnum<string, PromotionalEntitlementListResponseResetPeriod>? ResetPeriod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, PromotionalEntitlementListResponseResetPeriod>
            >("resetPeriod");
        }
        init { this._rawData.Set("resetPeriod", value); }
    }

    /// <summary>
    /// The reset period configuration of the entitlement
    /// </summary>
    public required PromotionalEntitlementListResponseResetPeriodConfiguration? ResetPeriodConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PromotionalEntitlementListResponseResetPeriodConfiguration>(
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
    public required ApiEnum<string, PromotionalEntitlementListResponseStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, PromotionalEntitlementListResponseStatus>
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

    public PromotionalEntitlementListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PromotionalEntitlementListResponse(
        PromotionalEntitlementListResponse promotionalEntitlementListResponse
    )
        : base(promotionalEntitlementListResponse) { }
#pragma warning restore CS8618

    public PromotionalEntitlementListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PromotionalEntitlementListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PromotionalEntitlementListResponseFromRaw.FromRawUnchecked"/>
    public static PromotionalEntitlementListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PromotionalEntitlementListResponseFromRaw : IFromRawJson<PromotionalEntitlementListResponse>
{
    /// <inheritdoc/>
    public PromotionalEntitlementListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PromotionalEntitlementListResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// The grant period of the promotional entitlement
/// </summary>
[JsonConverter(typeof(PromotionalEntitlementListResponsePeriodConverter))]
public enum PromotionalEntitlementListResponsePeriod
{
    V1Week,
    V1Month,
    V6Month,
    V1Year,
    Lifetime,
    Custom,
}

sealed class PromotionalEntitlementListResponsePeriodConverter
    : JsonConverter<PromotionalEntitlementListResponsePeriod>
{
    public override PromotionalEntitlementListResponsePeriod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "1 week" => PromotionalEntitlementListResponsePeriod.V1Week,
            "1 month" => PromotionalEntitlementListResponsePeriod.V1Month,
            "6 month" => PromotionalEntitlementListResponsePeriod.V6Month,
            "1 year" => PromotionalEntitlementListResponsePeriod.V1Year,
            "lifetime" => PromotionalEntitlementListResponsePeriod.Lifetime,
            "custom" => PromotionalEntitlementListResponsePeriod.Custom,
            _ => (PromotionalEntitlementListResponsePeriod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PromotionalEntitlementListResponsePeriod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PromotionalEntitlementListResponsePeriod.V1Week => "1 week",
                PromotionalEntitlementListResponsePeriod.V1Month => "1 month",
                PromotionalEntitlementListResponsePeriod.V6Month => "6 month",
                PromotionalEntitlementListResponsePeriod.V1Year => "1 year",
                PromotionalEntitlementListResponsePeriod.Lifetime => "lifetime",
                PromotionalEntitlementListResponsePeriod.Custom => "custom",
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
[JsonConverter(typeof(PromotionalEntitlementListResponseResetPeriodConverter))]
public enum PromotionalEntitlementListResponseResetPeriod
{
    Year,
    Month,
    Week,
    Day,
    Hour,
}

sealed class PromotionalEntitlementListResponseResetPeriodConverter
    : JsonConverter<PromotionalEntitlementListResponseResetPeriod>
{
    public override PromotionalEntitlementListResponseResetPeriod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "YEAR" => PromotionalEntitlementListResponseResetPeriod.Year,
            "MONTH" => PromotionalEntitlementListResponseResetPeriod.Month,
            "WEEK" => PromotionalEntitlementListResponseResetPeriod.Week,
            "DAY" => PromotionalEntitlementListResponseResetPeriod.Day,
            "HOUR" => PromotionalEntitlementListResponseResetPeriod.Hour,
            _ => (PromotionalEntitlementListResponseResetPeriod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PromotionalEntitlementListResponseResetPeriod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PromotionalEntitlementListResponseResetPeriod.Year => "YEAR",
                PromotionalEntitlementListResponseResetPeriod.Month => "MONTH",
                PromotionalEntitlementListResponseResetPeriod.Week => "WEEK",
                PromotionalEntitlementListResponseResetPeriod.Day => "DAY",
                PromotionalEntitlementListResponseResetPeriod.Hour => "HOUR",
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
[JsonConverter(typeof(PromotionalEntitlementListResponseResetPeriodConfigurationConverter))]
public record class PromotionalEntitlementListResponseResetPeriodConfiguration : ModelBase
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

    public PromotionalEntitlementListResponseResetPeriodConfiguration(
        PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PromotionalEntitlementListResponseResetPeriodConfiguration(
        PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PromotionalEntitlementListResponseResetPeriodConfiguration(
        PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PromotionalEntitlementListResponseResetPeriodConfiguration(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickYearlyResetPeriodConfig(out var value)) {
    ///     // `value` is of type `PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickYearlyResetPeriodConfig(
        [NotNullWhen(true)]
            out PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfig? value
    )
    {
        value =
            this.Value
            as PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMonthlyResetPeriodConfig(out var value)) {
    ///     // `value` is of type `PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMonthlyResetPeriodConfig(
        [NotNullWhen(true)]
            out PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfig? value
    )
    {
        value =
            this.Value
            as PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickWeeklyResetPeriodConfig(out var value)) {
    ///     // `value` is of type `PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickWeeklyResetPeriodConfig(
        [NotNullWhen(true)]
            out PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfig? value
    )
    {
        value =
            this.Value
            as PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfig;
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
    ///     (PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfig value) =&gt; {...},
    ///     (PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfig value) =&gt; {...},
    ///     (PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfig value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfig> yearlyResetPeriodConfig,
        System::Action<PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfig> monthlyResetPeriodConfig,
        System::Action<PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfig> weeklyResetPeriodConfig
    )
    {
        switch (this.Value)
        {
            case PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfig value:
                yearlyResetPeriodConfig(value);
                break;
            case PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfig value:
                monthlyResetPeriodConfig(value);
                break;
            case PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfig value:
                weeklyResetPeriodConfig(value);
                break;
            default:
                throw new StiggInvalidDataException(
                    "Data did not match any variant of PromotionalEntitlementListResponseResetPeriodConfiguration"
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
    ///     (PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfig value) =&gt; {...},
    ///     (PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfig value) =&gt; {...},
    ///     (PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfig value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<
            PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfig,
            T
        > yearlyResetPeriodConfig,
        System::Func<
            PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfig,
            T
        > monthlyResetPeriodConfig,
        System::Func<
            PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfig,
            T
        > weeklyResetPeriodConfig
    )
    {
        return this.Value switch
        {
            PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfig value =>
                yearlyResetPeriodConfig(value),
            PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfig value =>
                monthlyResetPeriodConfig(value),
            PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfig value =>
                weeklyResetPeriodConfig(value),
            _ => throw new StiggInvalidDataException(
                "Data did not match any variant of PromotionalEntitlementListResponseResetPeriodConfiguration"
            ),
        };
    }

    public static implicit operator PromotionalEntitlementListResponseResetPeriodConfiguration(
        PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfig value
    ) => new(value);

    public static implicit operator PromotionalEntitlementListResponseResetPeriodConfiguration(
        PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfig value
    ) => new(value);

    public static implicit operator PromotionalEntitlementListResponseResetPeriodConfiguration(
        PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfig value
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
                "Data did not match any variant of PromotionalEntitlementListResponseResetPeriodConfiguration"
            );
        }
        this.Switch(
            (yearlyResetPeriodConfig) => yearlyResetPeriodConfig.Validate(),
            (monthlyResetPeriodConfig) => monthlyResetPeriodConfig.Validate(),
            (weeklyResetPeriodConfig) => weeklyResetPeriodConfig.Validate()
        );
    }

    public virtual bool Equals(PromotionalEntitlementListResponseResetPeriodConfiguration? other) =>
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
            PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfig _ =>
                0,
            PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfig _ =>
                1,
            PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfig _ =>
                2,
            _ => -1,
        };
    }
}

sealed class PromotionalEntitlementListResponseResetPeriodConfigurationConverter
    : JsonConverter<PromotionalEntitlementListResponseResetPeriodConfiguration?>
{
    public override PromotionalEntitlementListResponseResetPeriodConfiguration? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized =
                JsonSerializer.Deserialize<PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfig>(
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
            var deserialized =
                JsonSerializer.Deserialize<PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfig>(
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
            var deserialized =
                JsonSerializer.Deserialize<PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfig>(
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
        PromotionalEntitlementListResponseResetPeriodConfiguration? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

/// <summary>
/// Yearly reset configuration
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfig,
        PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfigFromRaw
    >)
)]
public sealed record class PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfig
    : JsonModel
{
    /// <summary>
    /// Reset anchor (SubscriptionStart)
    /// </summary>
    public required ApiEnum<
        string,
        PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
    > AccordingTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
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

    public PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfig(
        PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfig promotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfig
    )
        : base(promotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfig)
    { }
#pragma warning restore CS8618

    public PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfigFromRaw.FromRawUnchecked"/>
    public static PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfig(
        ApiEnum<
            string,
            PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
        > accordingTo
    )
        : this()
    {
        this.AccordingTo = accordingTo;
    }
}

class PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfigFromRaw
    : IFromRawJson<PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfig>
{
    /// <inheritdoc/>
    public PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfig.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Reset anchor (SubscriptionStart)
/// </summary>
[JsonConverter(
    typeof(PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfigAccordingToConverter)
)]
public enum PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
{
    SubscriptionStart,
}

sealed class PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfigAccordingToConverter
    : JsonConverter<PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo>
{
    public override PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SubscriptionStart" =>
                PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart,
            _ =>
                (PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart =>
                    "SubscriptionStart",
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
    typeof(JsonModelConverter<
        PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfig,
        PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfigFromRaw
    >)
)]
public sealed record class PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfig
    : JsonModel
{
    /// <summary>
    /// Reset anchor (SubscriptionStart or StartOfTheMonth)
    /// </summary>
    public required ApiEnum<
        string,
        PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
    > AccordingTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
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

    public PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfig(
        PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfig promotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfig
    )
        : base(promotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfig)
    { }
#pragma warning restore CS8618

    public PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfigFromRaw.FromRawUnchecked"/>
    public static PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfig(
        ApiEnum<
            string,
            PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
        > accordingTo
    )
        : this()
    {
        this.AccordingTo = accordingTo;
    }
}

class PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfigFromRaw
    : IFromRawJson<PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfig>
{
    /// <inheritdoc/>
    public PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfig.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Reset anchor (SubscriptionStart or StartOfTheMonth)
/// </summary>
[JsonConverter(
    typeof(PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfigAccordingToConverter)
)]
public enum PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
{
    SubscriptionStart,
    StartOfTheMonth,
}

sealed class PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfigAccordingToConverter
    : JsonConverter<PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo>
{
    public override PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SubscriptionStart" =>
                PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart,
            "StartOfTheMonth" =>
                PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.StartOfTheMonth,
            _ =>
                (PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart =>
                    "SubscriptionStart",
                PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.StartOfTheMonth =>
                    "StartOfTheMonth",
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
[JsonConverter(
    typeof(JsonModelConverter<
        PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfig,
        PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfigFromRaw
    >)
)]
public sealed record class PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfig
    : JsonModel
{
    /// <summary>
    /// Reset anchor (SubscriptionStart or specific day)
    /// </summary>
    public required ApiEnum<
        string,
        PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
    > AccordingTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
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

    public PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfig(
        PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfig promotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfig
    )
        : base(promotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfig)
    { }
#pragma warning restore CS8618

    public PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfigFromRaw.FromRawUnchecked"/>
    public static PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfig(
        ApiEnum<
            string,
            PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
        > accordingTo
    )
        : this()
    {
        this.AccordingTo = accordingTo;
    }
}

class PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfigFromRaw
    : IFromRawJson<PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfig>
{
    /// <inheritdoc/>
    public PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfig.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Reset anchor (SubscriptionStart or specific day)
/// </summary>
[JsonConverter(
    typeof(PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfigAccordingToConverter)
)]
public enum PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
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

sealed class PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfigAccordingToConverter
    : JsonConverter<PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo>
{
    public override PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SubscriptionStart" =>
                PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart,
            "EverySunday" =>
                PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EverySunday,
            "EveryMonday" =>
                PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryMonday,
            "EveryTuesday" =>
                PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryTuesday,
            "EveryWednesday" =>
                PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryWednesday,
            "EveryThursday" =>
                PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryThursday,
            "EveryFriday" =>
                PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryFriday,
            "EverySaturday" =>
                PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EverySaturday,
            _ =>
                (PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart =>
                    "SubscriptionStart",
                PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EverySunday =>
                    "EverySunday",
                PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryMonday =>
                    "EveryMonday",
                PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryTuesday =>
                    "EveryTuesday",
                PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryWednesday =>
                    "EveryWednesday",
                PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryThursday =>
                    "EveryThursday",
                PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryFriday =>
                    "EveryFriday",
                PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EverySaturday =>
                    "EverySaturday",
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
[JsonConverter(typeof(PromotionalEntitlementListResponseStatusConverter))]
public enum PromotionalEntitlementListResponseStatus
{
    Active,
    Expired,
    Paused,
}

sealed class PromotionalEntitlementListResponseStatusConverter
    : JsonConverter<PromotionalEntitlementListResponseStatus>
{
    public override PromotionalEntitlementListResponseStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Active" => PromotionalEntitlementListResponseStatus.Active,
            "Expired" => PromotionalEntitlementListResponseStatus.Expired,
            "Paused" => PromotionalEntitlementListResponseStatus.Paused,
            _ => (PromotionalEntitlementListResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PromotionalEntitlementListResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PromotionalEntitlementListResponseStatus.Active => "Active",
                PromotionalEntitlementListResponseStatus.Expired => "Expired",
                PromotionalEntitlementListResponseStatus.Paused => "Paused",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
