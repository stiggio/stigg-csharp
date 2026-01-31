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
        PromotionalEntitlementRevokeResponse,
        PromotionalEntitlementRevokeResponseFromRaw
    >)
)]
public sealed record class PromotionalEntitlementRevokeResponse : JsonModel
{
    /// <summary>
    /// Granted feature entitlement
    /// </summary>
    public required PromotionalEntitlementRevokeResponseData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PromotionalEntitlementRevokeResponseData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public PromotionalEntitlementRevokeResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PromotionalEntitlementRevokeResponse(
        PromotionalEntitlementRevokeResponse promotionalEntitlementRevokeResponse
    )
        : base(promotionalEntitlementRevokeResponse) { }
#pragma warning restore CS8618

    public PromotionalEntitlementRevokeResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PromotionalEntitlementRevokeResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PromotionalEntitlementRevokeResponseFromRaw.FromRawUnchecked"/>
    public static PromotionalEntitlementRevokeResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PromotionalEntitlementRevokeResponse(PromotionalEntitlementRevokeResponseData data)
        : this()
    {
        this.Data = data;
    }
}

class PromotionalEntitlementRevokeResponseFromRaw
    : IFromRawJson<PromotionalEntitlementRevokeResponse>
{
    /// <inheritdoc/>
    public PromotionalEntitlementRevokeResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PromotionalEntitlementRevokeResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Granted feature entitlement
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        PromotionalEntitlementRevokeResponseData,
        PromotionalEntitlementRevokeResponseDataFromRaw
    >)
)]
public sealed record class PromotionalEntitlementRevokeResponseData : JsonModel
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
    public required ApiEnum<string, PromotionalEntitlementRevokeResponseDataPeriod> Period
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, PromotionalEntitlementRevokeResponseDataPeriod>
            >("period");
        }
        init { this._rawData.Set("period", value); }
    }

    /// <summary>
    /// The reset period of the entitlement
    /// </summary>
    public required ApiEnum<
        string,
        PromotionalEntitlementRevokeResponseDataResetPeriod
    >? ResetPeriod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, PromotionalEntitlementRevokeResponseDataResetPeriod>
            >("resetPeriod");
        }
        init { this._rawData.Set("resetPeriod", value); }
    }

    /// <summary>
    /// The reset period configuration of the entitlement
    /// </summary>
    public required PromotionalEntitlementRevokeResponseDataResetPeriodConfiguration? ResetPeriodConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PromotionalEntitlementRevokeResponseDataResetPeriodConfiguration>(
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
    public required ApiEnum<string, PromotionalEntitlementRevokeResponseDataStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, PromotionalEntitlementRevokeResponseDataStatus>
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

    public PromotionalEntitlementRevokeResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PromotionalEntitlementRevokeResponseData(
        PromotionalEntitlementRevokeResponseData promotionalEntitlementRevokeResponseData
    )
        : base(promotionalEntitlementRevokeResponseData) { }
#pragma warning restore CS8618

    public PromotionalEntitlementRevokeResponseData(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PromotionalEntitlementRevokeResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PromotionalEntitlementRevokeResponseDataFromRaw.FromRawUnchecked"/>
    public static PromotionalEntitlementRevokeResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PromotionalEntitlementRevokeResponseDataFromRaw
    : IFromRawJson<PromotionalEntitlementRevokeResponseData>
{
    /// <inheritdoc/>
    public PromotionalEntitlementRevokeResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PromotionalEntitlementRevokeResponseData.FromRawUnchecked(rawData);
}

/// <summary>
/// The grant period of the promotional entitlement
/// </summary>
[JsonConverter(typeof(PromotionalEntitlementRevokeResponseDataPeriodConverter))]
public enum PromotionalEntitlementRevokeResponseDataPeriod
{
    V1Week,
    V1Month,
    V6Month,
    V1Year,
    Lifetime,
    Custom,
}

sealed class PromotionalEntitlementRevokeResponseDataPeriodConverter
    : JsonConverter<PromotionalEntitlementRevokeResponseDataPeriod>
{
    public override PromotionalEntitlementRevokeResponseDataPeriod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "1 week" => PromotionalEntitlementRevokeResponseDataPeriod.V1Week,
            "1 month" => PromotionalEntitlementRevokeResponseDataPeriod.V1Month,
            "6 month" => PromotionalEntitlementRevokeResponseDataPeriod.V6Month,
            "1 year" => PromotionalEntitlementRevokeResponseDataPeriod.V1Year,
            "lifetime" => PromotionalEntitlementRevokeResponseDataPeriod.Lifetime,
            "custom" => PromotionalEntitlementRevokeResponseDataPeriod.Custom,
            _ => (PromotionalEntitlementRevokeResponseDataPeriod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PromotionalEntitlementRevokeResponseDataPeriod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PromotionalEntitlementRevokeResponseDataPeriod.V1Week => "1 week",
                PromotionalEntitlementRevokeResponseDataPeriod.V1Month => "1 month",
                PromotionalEntitlementRevokeResponseDataPeriod.V6Month => "6 month",
                PromotionalEntitlementRevokeResponseDataPeriod.V1Year => "1 year",
                PromotionalEntitlementRevokeResponseDataPeriod.Lifetime => "lifetime",
                PromotionalEntitlementRevokeResponseDataPeriod.Custom => "custom",
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
[JsonConverter(typeof(PromotionalEntitlementRevokeResponseDataResetPeriodConverter))]
public enum PromotionalEntitlementRevokeResponseDataResetPeriod
{
    Year,
    Month,
    Week,
    Day,
    Hour,
}

sealed class PromotionalEntitlementRevokeResponseDataResetPeriodConverter
    : JsonConverter<PromotionalEntitlementRevokeResponseDataResetPeriod>
{
    public override PromotionalEntitlementRevokeResponseDataResetPeriod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "YEAR" => PromotionalEntitlementRevokeResponseDataResetPeriod.Year,
            "MONTH" => PromotionalEntitlementRevokeResponseDataResetPeriod.Month,
            "WEEK" => PromotionalEntitlementRevokeResponseDataResetPeriod.Week,
            "DAY" => PromotionalEntitlementRevokeResponseDataResetPeriod.Day,
            "HOUR" => PromotionalEntitlementRevokeResponseDataResetPeriod.Hour,
            _ => (PromotionalEntitlementRevokeResponseDataResetPeriod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PromotionalEntitlementRevokeResponseDataResetPeriod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PromotionalEntitlementRevokeResponseDataResetPeriod.Year => "YEAR",
                PromotionalEntitlementRevokeResponseDataResetPeriod.Month => "MONTH",
                PromotionalEntitlementRevokeResponseDataResetPeriod.Week => "WEEK",
                PromotionalEntitlementRevokeResponseDataResetPeriod.Day => "DAY",
                PromotionalEntitlementRevokeResponseDataResetPeriod.Hour => "HOUR",
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
[JsonConverter(typeof(PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationConverter))]
public record class PromotionalEntitlementRevokeResponseDataResetPeriodConfiguration : ModelBase
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

    public PromotionalEntitlementRevokeResponseDataResetPeriodConfiguration(
        PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PromotionalEntitlementRevokeResponseDataResetPeriodConfiguration(
        PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PromotionalEntitlementRevokeResponseDataResetPeriodConfiguration(
        PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PromotionalEntitlementRevokeResponseDataResetPeriodConfiguration(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickYearlyResetPeriodConfig(out var value)) {
    ///     // `value` is of type `PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickYearlyResetPeriodConfig(
        [NotNullWhen(true)]
            out PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfig? value
    )
    {
        value =
            this.Value
            as PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMonthlyResetPeriodConfig(out var value)) {
    ///     // `value` is of type `PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMonthlyResetPeriodConfig(
        [NotNullWhen(true)]
            out PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig? value
    )
    {
        value =
            this.Value
            as PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickWeeklyResetPeriodConfig(out var value)) {
    ///     // `value` is of type `PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickWeeklyResetPeriodConfig(
        [NotNullWhen(true)]
            out PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig? value
    )
    {
        value =
            this.Value
            as PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig;
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
    ///     (PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfig value) => {...},
    ///     (PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig value) => {...},
    ///     (PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfig> yearlyResetPeriodConfig,
        System::Action<PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig> monthlyResetPeriodConfig,
        System::Action<PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig> weeklyResetPeriodConfig
    )
    {
        switch (this.Value)
        {
            case PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfig value:
                yearlyResetPeriodConfig(value);
                break;
            case PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig value:
                monthlyResetPeriodConfig(value);
                break;
            case PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig value:
                weeklyResetPeriodConfig(value);
                break;
            default:
                throw new StiggInvalidDataException(
                    "Data did not match any variant of PromotionalEntitlementRevokeResponseDataResetPeriodConfiguration"
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
    ///     (PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfig value) => {...},
    ///     (PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig value) => {...},
    ///     (PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<
            PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfig,
            T
        > yearlyResetPeriodConfig,
        System::Func<
            PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig,
            T
        > monthlyResetPeriodConfig,
        System::Func<
            PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig,
            T
        > weeklyResetPeriodConfig
    )
    {
        return this.Value switch
        {
            PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfig value =>
                yearlyResetPeriodConfig(value),
            PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig value =>
                monthlyResetPeriodConfig(value),
            PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig value =>
                weeklyResetPeriodConfig(value),
            _ => throw new StiggInvalidDataException(
                "Data did not match any variant of PromotionalEntitlementRevokeResponseDataResetPeriodConfiguration"
            ),
        };
    }

    public static implicit operator PromotionalEntitlementRevokeResponseDataResetPeriodConfiguration(
        PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfig value
    ) => new(value);

    public static implicit operator PromotionalEntitlementRevokeResponseDataResetPeriodConfiguration(
        PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig value
    ) => new(value);

    public static implicit operator PromotionalEntitlementRevokeResponseDataResetPeriodConfiguration(
        PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig value
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
                "Data did not match any variant of PromotionalEntitlementRevokeResponseDataResetPeriodConfiguration"
            );
        }
        this.Switch(
            (yearlyResetPeriodConfig) => yearlyResetPeriodConfig.Validate(),
            (monthlyResetPeriodConfig) => monthlyResetPeriodConfig.Validate(),
            (weeklyResetPeriodConfig) => weeklyResetPeriodConfig.Validate()
        );
    }

    public virtual bool Equals(
        PromotionalEntitlementRevokeResponseDataResetPeriodConfiguration? other
    ) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(this._element, ModelBase.ToStringSerializerOptions);

    int VariantIndex()
    {
        return this.Value switch
        {
            PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfig _ =>
                0,
            PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig _ =>
                1,
            PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig _ =>
                2,
            _ => -1,
        };
    }
}

sealed class PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationConverter
    : JsonConverter<PromotionalEntitlementRevokeResponseDataResetPeriodConfiguration?>
{
    public override PromotionalEntitlementRevokeResponseDataResetPeriodConfiguration? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized =
                JsonSerializer.Deserialize<PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfig>(
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
                JsonSerializer.Deserialize<PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig>(
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
                JsonSerializer.Deserialize<PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig>(
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
        PromotionalEntitlementRevokeResponseDataResetPeriodConfiguration? value,
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
        PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfig,
        PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfigFromRaw
    >)
)]
public sealed record class PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfig
    : JsonModel
{
    /// <summary>
    /// Reset anchor (SubscriptionStart)
    /// </summary>
    public required ApiEnum<
        string,
        PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
    > AccordingTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
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

    public PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfig()
    { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfig(
        PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfig promotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfig
    )
        : base(
            promotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfig
        ) { }
#pragma warning restore CS8618

    public PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfigFromRaw.FromRawUnchecked"/>
    public static PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfig(
        ApiEnum<
            string,
            PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
        > accordingTo
    )
        : this()
    {
        this.AccordingTo = accordingTo;
    }
}

class PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfigFromRaw
    : IFromRawJson<PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfig>
{
    /// <inheritdoc/>
    public PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfig.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Reset anchor (SubscriptionStart)
/// </summary>
[JsonConverter(
    typeof(PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingToConverter)
)]
public enum PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
{
    SubscriptionStart,
}

sealed class PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingToConverter
    : JsonConverter<PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo>
{
    public override PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SubscriptionStart" =>
                PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart,
            _ =>
                (PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart =>
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
        PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig,
        PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigFromRaw
    >)
)]
public sealed record class PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig
    : JsonModel
{
    /// <summary>
    /// Reset anchor (SubscriptionStart or StartOfTheMonth)
    /// </summary>
    public required ApiEnum<
        string,
        PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
    > AccordingTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
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

    public PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig()
    { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig(
        PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig promotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig
    )
        : base(
            promotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig
        ) { }
#pragma warning restore CS8618

    public PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigFromRaw.FromRawUnchecked"/>
    public static PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig(
        ApiEnum<
            string,
            PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
        > accordingTo
    )
        : this()
    {
        this.AccordingTo = accordingTo;
    }
}

class PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigFromRaw
    : IFromRawJson<PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig>
{
    /// <inheritdoc/>
    public PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Reset anchor (SubscriptionStart or StartOfTheMonth)
/// </summary>
[JsonConverter(
    typeof(PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingToConverter)
)]
public enum PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
{
    SubscriptionStart,
    StartOfTheMonth,
}

sealed class PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingToConverter
    : JsonConverter<PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo>
{
    public override PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SubscriptionStart" =>
                PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart,
            "StartOfTheMonth" =>
                PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.StartOfTheMonth,
            _ =>
                (PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart =>
                    "SubscriptionStart",
                PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.StartOfTheMonth =>
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
        PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig,
        PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigFromRaw
    >)
)]
public sealed record class PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig
    : JsonModel
{
    /// <summary>
    /// Reset anchor (SubscriptionStart or specific day)
    /// </summary>
    public required ApiEnum<
        string,
        PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
    > AccordingTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
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

    public PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig()
    { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig(
        PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig promotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig
    )
        : base(
            promotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig
        ) { }
#pragma warning restore CS8618

    public PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigFromRaw.FromRawUnchecked"/>
    public static PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig(
        ApiEnum<
            string,
            PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
        > accordingTo
    )
        : this()
    {
        this.AccordingTo = accordingTo;
    }
}

class PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigFromRaw
    : IFromRawJson<PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig>
{
    /// <inheritdoc/>
    public PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Reset anchor (SubscriptionStart or specific day)
/// </summary>
[JsonConverter(
    typeof(PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingToConverter)
)]
public enum PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
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

sealed class PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingToConverter
    : JsonConverter<PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo>
{
    public override PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SubscriptionStart" =>
                PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart,
            "EverySunday" =>
                PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EverySunday,
            "EveryMonday" =>
                PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryMonday,
            "EveryTuesday" =>
                PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryTuesday,
            "EveryWednesday" =>
                PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryWednesday,
            "EveryThursday" =>
                PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryThursday,
            "EveryFriday" =>
                PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryFriday,
            "EverySaturday" =>
                PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EverySaturday,
            _ =>
                (PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart =>
                    "SubscriptionStart",
                PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EverySunday =>
                    "EverySunday",
                PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryMonday =>
                    "EveryMonday",
                PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryTuesday =>
                    "EveryTuesday",
                PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryWednesday =>
                    "EveryWednesday",
                PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryThursday =>
                    "EveryThursday",
                PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryFriday =>
                    "EveryFriday",
                PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EverySaturday =>
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
[JsonConverter(typeof(PromotionalEntitlementRevokeResponseDataStatusConverter))]
public enum PromotionalEntitlementRevokeResponseDataStatus
{
    Active,
    Expired,
    Paused,
}

sealed class PromotionalEntitlementRevokeResponseDataStatusConverter
    : JsonConverter<PromotionalEntitlementRevokeResponseDataStatus>
{
    public override PromotionalEntitlementRevokeResponseDataStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Active" => PromotionalEntitlementRevokeResponseDataStatus.Active,
            "Expired" => PromotionalEntitlementRevokeResponseDataStatus.Expired,
            "Paused" => PromotionalEntitlementRevokeResponseDataStatus.Paused,
            _ => (PromotionalEntitlementRevokeResponseDataStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PromotionalEntitlementRevokeResponseDataStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PromotionalEntitlementRevokeResponseDataStatus.Active => "Active",
                PromotionalEntitlementRevokeResponseDataStatus.Expired => "Expired",
                PromotionalEntitlementRevokeResponseDataStatus.Paused => "Paused",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
