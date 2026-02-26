using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using System = System;

namespace Stigg.Client.Models.V1.Events.Addons.Entitlements;

/// <summary>
/// Response list object
/// </summary>
[JsonConverter(typeof(JsonModelConverter<EntitlementListResponse, EntitlementListResponseFromRaw>))]
public sealed record class EntitlementListResponse : JsonModel
{
    public required IReadOnlyList<EntitlementListResponseData> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<EntitlementListResponseData>>(
                "data"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<EntitlementListResponseData>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Pagination metadata including cursors for navigating through results
    /// </summary>
    public required Pagination Pagination
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Pagination>("pagination");
        }
        init { this._rawData.Set("pagination", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        this.Pagination.Validate();
    }

    public EntitlementListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementListResponse(EntitlementListResponse entitlementListResponse)
        : base(entitlementListResponse) { }
#pragma warning restore CS8618

    public EntitlementListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementListResponseFromRaw.FromRawUnchecked"/>
    public static EntitlementListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntitlementListResponseFromRaw : IFromRawJson<EntitlementListResponse>
{
    /// <inheritdoc/>
    public EntitlementListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementListResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Feature or credit entitlement on an addon
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<EntitlementListResponseData, EntitlementListResponseDataFromRaw>)
)]
public sealed record class EntitlementListResponseData : JsonModel
{
    /// <summary>
    /// Unique identifier of the entitlement
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
    /// Credit amount (for credit entitlements)
    /// </summary>
    public required double? Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    /// <summary>
    /// Entitlement behavior (Increment or Override)
    /// </summary>
    public required ApiEnum<string, EntitlementListResponseDataBehavior> Behavior
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, EntitlementListResponseDataBehavior>
            >("behavior");
        }
        init { this._rawData.Set("behavior", value); }
    }

    /// <summary>
    /// Credit grant cadence (for credit entitlements)
    /// </summary>
    public required ApiEnum<string, EntitlementListResponseDataCadence>? Cadence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, EntitlementListResponseDataCadence>
            >("cadence");
        }
        init { this._rawData.Set("cadence", value); }
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
    /// Custom currency ID (for credit entitlements)
    /// </summary>
    public required string? CustomCurrencyID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("customCurrencyId");
        }
        init { this._rawData.Set("customCurrencyId", value); }
    }

    /// <summary>
    /// Optional description of the entitlement
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
    /// Override display name for the entitlement
    /// </summary>
    public required string? DisplayNameOverride
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("displayNameOverride");
        }
        init { this._rawData.Set("displayNameOverride", value); }
    }

    /// <summary>
    /// Allowed enum values (for feature entitlements)
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
    /// Feature ID (for feature entitlements)
    /// </summary>
    public required string? FeatureID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("featureId");
        }
        init { this._rawData.Set("featureId", value); }
    }

    /// <summary>
    /// Whether the usage limit is a soft limit (for feature entitlements)
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
    /// Whether usage is unlimited (for feature entitlements)
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
    /// Widget types where this entitlement is hidden
    /// </summary>
    public required IReadOnlyList<
        ApiEnum<string, EntitlementListResponseDataHiddenFromWidget>
    > HiddenFromWidgets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<ApiEnum<string, EntitlementListResponseDataHiddenFromWidget>>
            >("hiddenFromWidgets");
        }
        init
        {
            this._rawData.Set<
                ImmutableArray<ApiEnum<string, EntitlementListResponseDataHiddenFromWidget>>
            >("hiddenFromWidgets", ImmutableArray.ToImmutableArray(value));
        }
    }

    /// <summary>
    /// Whether this is a custom entitlement
    /// </summary>
    public required bool? IsCustom
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isCustom");
        }
        init { this._rawData.Set("isCustom", value); }
    }

    /// <summary>
    /// Whether the entitlement is granted
    /// </summary>
    public required bool IsGranted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("isGranted");
        }
        init { this._rawData.Set("isGranted", value); }
    }

    /// <summary>
    /// Display order of the entitlement
    /// </summary>
    public required double? Order
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("order");
        }
        init { this._rawData.Set("order", value); }
    }

    /// <summary>
    /// Usage reset period (for feature entitlements)
    /// </summary>
    public required ApiEnum<string, EntitlementListResponseDataResetPeriod>? ResetPeriod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, EntitlementListResponseDataResetPeriod>
            >("resetPeriod");
        }
        init { this._rawData.Set("resetPeriod", value); }
    }

    /// <summary>
    /// Reset period configuration (for feature entitlements)
    /// </summary>
    public required EntitlementListResponseDataResetPeriodConfiguration? ResetPeriodConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EntitlementListResponseDataResetPeriodConfiguration>(
                "resetPeriodConfiguration"
            );
        }
        init { this._rawData.Set("resetPeriodConfiguration", value); }
    }

    /// <summary>
    /// Entitlement type (FEATURE or CREDIT)
    /// </summary>
    public required ApiEnum<string, EntitlementListResponseDataType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, EntitlementListResponseDataType>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
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
    /// Usage limit (for feature entitlements)
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
        _ = this.Amount;
        this.Behavior.Validate();
        this.Cadence?.Validate();
        _ = this.CreatedAt;
        _ = this.CustomCurrencyID;
        _ = this.Description;
        _ = this.DisplayNameOverride;
        _ = this.EnumValues;
        _ = this.FeatureID;
        _ = this.HasSoftLimit;
        _ = this.HasUnlimitedUsage;
        foreach (var item in this.HiddenFromWidgets)
        {
            item.Validate();
        }
        _ = this.IsCustom;
        _ = this.IsGranted;
        _ = this.Order;
        this.ResetPeriod?.Validate();
        this.ResetPeriodConfiguration?.Validate();
        this.Type.Validate();
        _ = this.UpdatedAt;
        _ = this.UsageLimit;
    }

    public EntitlementListResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementListResponseData(EntitlementListResponseData entitlementListResponseData)
        : base(entitlementListResponseData) { }
#pragma warning restore CS8618

    public EntitlementListResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementListResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementListResponseDataFromRaw.FromRawUnchecked"/>
    public static EntitlementListResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntitlementListResponseDataFromRaw : IFromRawJson<EntitlementListResponseData>
{
    /// <inheritdoc/>
    public EntitlementListResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementListResponseData.FromRawUnchecked(rawData);
}

/// <summary>
/// Entitlement behavior (Increment or Override)
/// </summary>
[JsonConverter(typeof(EntitlementListResponseDataBehaviorConverter))]
public enum EntitlementListResponseDataBehavior
{
    Increment,
    Override,
}

sealed class EntitlementListResponseDataBehaviorConverter
    : JsonConverter<EntitlementListResponseDataBehavior>
{
    public override EntitlementListResponseDataBehavior Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Increment" => EntitlementListResponseDataBehavior.Increment,
            "Override" => EntitlementListResponseDataBehavior.Override,
            _ => (EntitlementListResponseDataBehavior)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntitlementListResponseDataBehavior value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntitlementListResponseDataBehavior.Increment => "Increment",
                EntitlementListResponseDataBehavior.Override => "Override",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Credit grant cadence (for credit entitlements)
/// </summary>
[JsonConverter(typeof(EntitlementListResponseDataCadenceConverter))]
public enum EntitlementListResponseDataCadence
{
    Month,
    Year,
}

sealed class EntitlementListResponseDataCadenceConverter
    : JsonConverter<EntitlementListResponseDataCadence>
{
    public override EntitlementListResponseDataCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "MONTH" => EntitlementListResponseDataCadence.Month,
            "YEAR" => EntitlementListResponseDataCadence.Year,
            _ => (EntitlementListResponseDataCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntitlementListResponseDataCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntitlementListResponseDataCadence.Month => "MONTH",
                EntitlementListResponseDataCadence.Year => "YEAR",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(EntitlementListResponseDataHiddenFromWidgetConverter))]
public enum EntitlementListResponseDataHiddenFromWidget
{
    Paywall,
    CustomerPortal,
    Checkout,
}

sealed class EntitlementListResponseDataHiddenFromWidgetConverter
    : JsonConverter<EntitlementListResponseDataHiddenFromWidget>
{
    public override EntitlementListResponseDataHiddenFromWidget Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PAYWALL" => EntitlementListResponseDataHiddenFromWidget.Paywall,
            "CUSTOMER_PORTAL" => EntitlementListResponseDataHiddenFromWidget.CustomerPortal,
            "CHECKOUT" => EntitlementListResponseDataHiddenFromWidget.Checkout,
            _ => (EntitlementListResponseDataHiddenFromWidget)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntitlementListResponseDataHiddenFromWidget value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntitlementListResponseDataHiddenFromWidget.Paywall => "PAYWALL",
                EntitlementListResponseDataHiddenFromWidget.CustomerPortal => "CUSTOMER_PORTAL",
                EntitlementListResponseDataHiddenFromWidget.Checkout => "CHECKOUT",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Usage reset period (for feature entitlements)
/// </summary>
[JsonConverter(typeof(EntitlementListResponseDataResetPeriodConverter))]
public enum EntitlementListResponseDataResetPeriod
{
    Year,
    Month,
    Week,
    Day,
    Hour,
}

sealed class EntitlementListResponseDataResetPeriodConverter
    : JsonConverter<EntitlementListResponseDataResetPeriod>
{
    public override EntitlementListResponseDataResetPeriod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "YEAR" => EntitlementListResponseDataResetPeriod.Year,
            "MONTH" => EntitlementListResponseDataResetPeriod.Month,
            "WEEK" => EntitlementListResponseDataResetPeriod.Week,
            "DAY" => EntitlementListResponseDataResetPeriod.Day,
            "HOUR" => EntitlementListResponseDataResetPeriod.Hour,
            _ => (EntitlementListResponseDataResetPeriod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntitlementListResponseDataResetPeriod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntitlementListResponseDataResetPeriod.Year => "YEAR",
                EntitlementListResponseDataResetPeriod.Month => "MONTH",
                EntitlementListResponseDataResetPeriod.Week => "WEEK",
                EntitlementListResponseDataResetPeriod.Day => "DAY",
                EntitlementListResponseDataResetPeriod.Hour => "HOUR",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Reset period configuration (for feature entitlements)
/// </summary>
[JsonConverter(typeof(EntitlementListResponseDataResetPeriodConfigurationConverter))]
public record class EntitlementListResponseDataResetPeriodConfiguration : ModelBase
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

    public EntitlementListResponseDataResetPeriodConfiguration(
        EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EntitlementListResponseDataResetPeriodConfiguration(
        EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EntitlementListResponseDataResetPeriodConfiguration(
        EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EntitlementListResponseDataResetPeriodConfiguration(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickYearlyResetPeriodConfig(out var value)) {
    ///     // `value` is of type `EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickYearlyResetPeriodConfig(
        [NotNullWhen(true)]
            out EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfig? value
    )
    {
        value =
            this.Value
            as EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMonthlyResetPeriodConfig(out var value)) {
    ///     // `value` is of type `EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMonthlyResetPeriodConfig(
        [NotNullWhen(true)]
            out EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig? value
    )
    {
        value =
            this.Value
            as EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickWeeklyResetPeriodConfig(out var value)) {
    ///     // `value` is of type `EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickWeeklyResetPeriodConfig(
        [NotNullWhen(true)]
            out EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig? value
    )
    {
        value =
            this.Value
            as EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig;
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
    ///     (EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfig value) => {...},
    ///     (EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig value) => {...},
    ///     (EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfig> yearlyResetPeriodConfig,
        System::Action<EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig> monthlyResetPeriodConfig,
        System::Action<EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig> weeklyResetPeriodConfig
    )
    {
        switch (this.Value)
        {
            case EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfig value:
                yearlyResetPeriodConfig(value);
                break;
            case EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig value:
                monthlyResetPeriodConfig(value);
                break;
            case EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig value:
                weeklyResetPeriodConfig(value);
                break;
            default:
                throw new StiggInvalidDataException(
                    "Data did not match any variant of EntitlementListResponseDataResetPeriodConfiguration"
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
    ///     (EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfig value) => {...},
    ///     (EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig value) => {...},
    ///     (EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<
            EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfig,
            T
        > yearlyResetPeriodConfig,
        System::Func<
            EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig,
            T
        > monthlyResetPeriodConfig,
        System::Func<
            EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig,
            T
        > weeklyResetPeriodConfig
    )
    {
        return this.Value switch
        {
            EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfig value =>
                yearlyResetPeriodConfig(value),
            EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig value =>
                monthlyResetPeriodConfig(value),
            EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig value =>
                weeklyResetPeriodConfig(value),
            _ => throw new StiggInvalidDataException(
                "Data did not match any variant of EntitlementListResponseDataResetPeriodConfiguration"
            ),
        };
    }

    public static implicit operator EntitlementListResponseDataResetPeriodConfiguration(
        EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfig value
    ) => new(value);

    public static implicit operator EntitlementListResponseDataResetPeriodConfiguration(
        EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig value
    ) => new(value);

    public static implicit operator EntitlementListResponseDataResetPeriodConfiguration(
        EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig value
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
                "Data did not match any variant of EntitlementListResponseDataResetPeriodConfiguration"
            );
        }
        this.Switch(
            (yearlyResetPeriodConfig) => yearlyResetPeriodConfig.Validate(),
            (monthlyResetPeriodConfig) => monthlyResetPeriodConfig.Validate(),
            (weeklyResetPeriodConfig) => weeklyResetPeriodConfig.Validate()
        );
    }

    public virtual bool Equals(EntitlementListResponseDataResetPeriodConfiguration? other) =>
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
            EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfig _ => 0,
            EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig _ => 1,
            EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig _ => 2,
            _ => -1,
        };
    }
}

sealed class EntitlementListResponseDataResetPeriodConfigurationConverter
    : JsonConverter<EntitlementListResponseDataResetPeriodConfiguration?>
{
    public override EntitlementListResponseDataResetPeriodConfiguration? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized =
                JsonSerializer.Deserialize<EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfig>(
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
                JsonSerializer.Deserialize<EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig>(
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
                JsonSerializer.Deserialize<EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig>(
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
        EntitlementListResponseDataResetPeriodConfiguration? value,
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
        EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfig,
        EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfigFromRaw
    >)
)]
public sealed record class EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfig
    : JsonModel
{
    /// <summary>
    /// Reset anchor (SubscriptionStart)
    /// </summary>
    public required ApiEnum<
        string,
        EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
    > AccordingTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
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

    public EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfig(
        EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfig entitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfig
    )
        : base(entitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfig) { }
#pragma warning restore CS8618

    public EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfigFromRaw.FromRawUnchecked"/>
    public static EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfig(
        ApiEnum<
            string,
            EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
        > accordingTo
    )
        : this()
    {
        this.AccordingTo = accordingTo;
    }
}

class EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfigFromRaw
    : IFromRawJson<EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfig>
{
    /// <inheritdoc/>
    public EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfig.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Reset anchor (SubscriptionStart)
/// </summary>
[JsonConverter(
    typeof(EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingToConverter)
)]
public enum EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
{
    SubscriptionStart,
}

sealed class EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingToConverter
    : JsonConverter<EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo>
{
    public override EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SubscriptionStart" =>
                EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart,
            _ =>
                (EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart =>
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
        EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig,
        EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigFromRaw
    >)
)]
public sealed record class EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig
    : JsonModel
{
    /// <summary>
    /// Reset anchor (SubscriptionStart or StartOfTheMonth)
    /// </summary>
    public required ApiEnum<
        string,
        EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
    > AccordingTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
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

    public EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig(
        EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig entitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig
    )
        : base(entitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig) { }
#pragma warning restore CS8618

    public EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigFromRaw.FromRawUnchecked"/>
    public static EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig(
        ApiEnum<
            string,
            EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
        > accordingTo
    )
        : this()
    {
        this.AccordingTo = accordingTo;
    }
}

class EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigFromRaw
    : IFromRawJson<EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig>
{
    /// <inheritdoc/>
    public EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Reset anchor (SubscriptionStart or StartOfTheMonth)
/// </summary>
[JsonConverter(
    typeof(EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingToConverter)
)]
public enum EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
{
    SubscriptionStart,
    StartOfTheMonth,
}

sealed class EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingToConverter
    : JsonConverter<EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo>
{
    public override EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SubscriptionStart" =>
                EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart,
            "StartOfTheMonth" =>
                EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.StartOfTheMonth,
            _ =>
                (EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart =>
                    "SubscriptionStart",
                EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.StartOfTheMonth =>
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
        EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig,
        EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigFromRaw
    >)
)]
public sealed record class EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig
    : JsonModel
{
    /// <summary>
    /// Reset anchor (SubscriptionStart or specific day)
    /// </summary>
    public required ApiEnum<
        string,
        EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
    > AccordingTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
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

    public EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig(
        EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig entitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig
    )
        : base(entitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig) { }
#pragma warning restore CS8618

    public EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigFromRaw.FromRawUnchecked"/>
    public static EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig(
        ApiEnum<
            string,
            EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
        > accordingTo
    )
        : this()
    {
        this.AccordingTo = accordingTo;
    }
}

class EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigFromRaw
    : IFromRawJson<EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig>
{
    /// <inheritdoc/>
    public EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Reset anchor (SubscriptionStart or specific day)
/// </summary>
[JsonConverter(
    typeof(EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingToConverter)
)]
public enum EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
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

sealed class EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingToConverter
    : JsonConverter<EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo>
{
    public override EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SubscriptionStart" =>
                EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart,
            "EverySunday" =>
                EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EverySunday,
            "EveryMonday" =>
                EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryMonday,
            "EveryTuesday" =>
                EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryTuesday,
            "EveryWednesday" =>
                EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryWednesday,
            "EveryThursday" =>
                EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryThursday,
            "EveryFriday" =>
                EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryFriday,
            "EverySaturday" =>
                EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EverySaturday,
            _ =>
                (EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart =>
                    "SubscriptionStart",
                EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EverySunday =>
                    "EverySunday",
                EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryMonday =>
                    "EveryMonday",
                EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryTuesday =>
                    "EveryTuesday",
                EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryWednesday =>
                    "EveryWednesday",
                EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryThursday =>
                    "EveryThursday",
                EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryFriday =>
                    "EveryFriday",
                EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EverySaturday =>
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
/// Entitlement type (FEATURE or CREDIT)
/// </summary>
[JsonConverter(typeof(EntitlementListResponseDataTypeConverter))]
public enum EntitlementListResponseDataType
{
    Feature,
    Credit,
}

sealed class EntitlementListResponseDataTypeConverter
    : JsonConverter<EntitlementListResponseDataType>
{
    public override EntitlementListResponseDataType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FEATURE" => EntitlementListResponseDataType.Feature,
            "CREDIT" => EntitlementListResponseDataType.Credit,
            _ => (EntitlementListResponseDataType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntitlementListResponseDataType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntitlementListResponseDataType.Feature => "FEATURE",
                EntitlementListResponseDataType.Credit => "CREDIT",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Pagination metadata including cursors for navigating through results
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Pagination, PaginationFromRaw>))]
public sealed record class Pagination : JsonModel
{
    /// <summary>
    /// Cursor for fetching the next page of results, or null if no additional pages exist
    /// </summary>
    public required string? Next
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("next");
        }
        init { this._rawData.Set("next", value); }
    }

    /// <summary>
    /// Cursor for fetching the previous page of results, or null if at the beginning
    /// </summary>
    public required string? Prev
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("prev");
        }
        init { this._rawData.Set("prev", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Next;
        _ = this.Prev;
    }

    public Pagination() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Pagination(Pagination pagination)
        : base(pagination) { }
#pragma warning restore CS8618

    public Pagination(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Pagination(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaginationFromRaw.FromRawUnchecked"/>
    public static Pagination FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaginationFromRaw : IFromRawJson<Pagination>
{
    /// <inheritdoc/>
    public Pagination FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Pagination.FromRawUnchecked(rawData);
}
