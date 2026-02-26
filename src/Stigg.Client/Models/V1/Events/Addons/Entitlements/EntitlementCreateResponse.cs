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
/// Response object
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<EntitlementCreateResponse, EntitlementCreateResponseFromRaw>)
)]
public sealed record class EntitlementCreateResponse : JsonModel
{
    public required IReadOnlyList<EntitlementCreateResponseData> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<EntitlementCreateResponseData>>(
                "data"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<EntitlementCreateResponseData>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
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

    public EntitlementCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementCreateResponse(EntitlementCreateResponse entitlementCreateResponse)
        : base(entitlementCreateResponse) { }
#pragma warning restore CS8618

    public EntitlementCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementCreateResponseFromRaw.FromRawUnchecked"/>
    public static EntitlementCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EntitlementCreateResponse(IReadOnlyList<EntitlementCreateResponseData> data)
        : this()
    {
        this.Data = data;
    }
}

class EntitlementCreateResponseFromRaw : IFromRawJson<EntitlementCreateResponse>
{
    /// <inheritdoc/>
    public EntitlementCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementCreateResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Feature or credit entitlement on an addon
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<EntitlementCreateResponseData, EntitlementCreateResponseDataFromRaw>)
)]
public sealed record class EntitlementCreateResponseData : JsonModel
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
    public required ApiEnum<string, EntitlementCreateResponseDataBehavior> Behavior
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, EntitlementCreateResponseDataBehavior>
            >("behavior");
        }
        init { this._rawData.Set("behavior", value); }
    }

    /// <summary>
    /// Credit grant cadence (for credit entitlements)
    /// </summary>
    public required ApiEnum<string, EntitlementCreateResponseDataCadence>? Cadence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, EntitlementCreateResponseDataCadence>
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
        ApiEnum<string, EntitlementCreateResponseDataHiddenFromWidget>
    > HiddenFromWidgets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<ApiEnum<string, EntitlementCreateResponseDataHiddenFromWidget>>
            >("hiddenFromWidgets");
        }
        init
        {
            this._rawData.Set<
                ImmutableArray<ApiEnum<string, EntitlementCreateResponseDataHiddenFromWidget>>
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
    public required ApiEnum<string, EntitlementCreateResponseDataResetPeriod>? ResetPeriod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, EntitlementCreateResponseDataResetPeriod>
            >("resetPeriod");
        }
        init { this._rawData.Set("resetPeriod", value); }
    }

    /// <summary>
    /// Reset period configuration (for feature entitlements)
    /// </summary>
    public required EntitlementCreateResponseDataResetPeriodConfiguration? ResetPeriodConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EntitlementCreateResponseDataResetPeriodConfiguration>(
                "resetPeriodConfiguration"
            );
        }
        init { this._rawData.Set("resetPeriodConfiguration", value); }
    }

    /// <summary>
    /// Entitlement type (FEATURE or CREDIT)
    /// </summary>
    public required ApiEnum<string, EntitlementCreateResponseDataType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, EntitlementCreateResponseDataType>
            >("type");
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

    public EntitlementCreateResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementCreateResponseData(
        EntitlementCreateResponseData entitlementCreateResponseData
    )
        : base(entitlementCreateResponseData) { }
#pragma warning restore CS8618

    public EntitlementCreateResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementCreateResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementCreateResponseDataFromRaw.FromRawUnchecked"/>
    public static EntitlementCreateResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntitlementCreateResponseDataFromRaw : IFromRawJson<EntitlementCreateResponseData>
{
    /// <inheritdoc/>
    public EntitlementCreateResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementCreateResponseData.FromRawUnchecked(rawData);
}

/// <summary>
/// Entitlement behavior (Increment or Override)
/// </summary>
[JsonConverter(typeof(EntitlementCreateResponseDataBehaviorConverter))]
public enum EntitlementCreateResponseDataBehavior
{
    Increment,
    Override,
}

sealed class EntitlementCreateResponseDataBehaviorConverter
    : JsonConverter<EntitlementCreateResponseDataBehavior>
{
    public override EntitlementCreateResponseDataBehavior Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Increment" => EntitlementCreateResponseDataBehavior.Increment,
            "Override" => EntitlementCreateResponseDataBehavior.Override,
            _ => (EntitlementCreateResponseDataBehavior)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntitlementCreateResponseDataBehavior value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntitlementCreateResponseDataBehavior.Increment => "Increment",
                EntitlementCreateResponseDataBehavior.Override => "Override",
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
[JsonConverter(typeof(EntitlementCreateResponseDataCadenceConverter))]
public enum EntitlementCreateResponseDataCadence
{
    Month,
    Year,
}

sealed class EntitlementCreateResponseDataCadenceConverter
    : JsonConverter<EntitlementCreateResponseDataCadence>
{
    public override EntitlementCreateResponseDataCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "MONTH" => EntitlementCreateResponseDataCadence.Month,
            "YEAR" => EntitlementCreateResponseDataCadence.Year,
            _ => (EntitlementCreateResponseDataCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntitlementCreateResponseDataCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntitlementCreateResponseDataCadence.Month => "MONTH",
                EntitlementCreateResponseDataCadence.Year => "YEAR",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(EntitlementCreateResponseDataHiddenFromWidgetConverter))]
public enum EntitlementCreateResponseDataHiddenFromWidget
{
    Paywall,
    CustomerPortal,
    Checkout,
}

sealed class EntitlementCreateResponseDataHiddenFromWidgetConverter
    : JsonConverter<EntitlementCreateResponseDataHiddenFromWidget>
{
    public override EntitlementCreateResponseDataHiddenFromWidget Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PAYWALL" => EntitlementCreateResponseDataHiddenFromWidget.Paywall,
            "CUSTOMER_PORTAL" => EntitlementCreateResponseDataHiddenFromWidget.CustomerPortal,
            "CHECKOUT" => EntitlementCreateResponseDataHiddenFromWidget.Checkout,
            _ => (EntitlementCreateResponseDataHiddenFromWidget)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntitlementCreateResponseDataHiddenFromWidget value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntitlementCreateResponseDataHiddenFromWidget.Paywall => "PAYWALL",
                EntitlementCreateResponseDataHiddenFromWidget.CustomerPortal => "CUSTOMER_PORTAL",
                EntitlementCreateResponseDataHiddenFromWidget.Checkout => "CHECKOUT",
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
[JsonConverter(typeof(EntitlementCreateResponseDataResetPeriodConverter))]
public enum EntitlementCreateResponseDataResetPeriod
{
    Year,
    Month,
    Week,
    Day,
    Hour,
}

sealed class EntitlementCreateResponseDataResetPeriodConverter
    : JsonConverter<EntitlementCreateResponseDataResetPeriod>
{
    public override EntitlementCreateResponseDataResetPeriod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "YEAR" => EntitlementCreateResponseDataResetPeriod.Year,
            "MONTH" => EntitlementCreateResponseDataResetPeriod.Month,
            "WEEK" => EntitlementCreateResponseDataResetPeriod.Week,
            "DAY" => EntitlementCreateResponseDataResetPeriod.Day,
            "HOUR" => EntitlementCreateResponseDataResetPeriod.Hour,
            _ => (EntitlementCreateResponseDataResetPeriod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntitlementCreateResponseDataResetPeriod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntitlementCreateResponseDataResetPeriod.Year => "YEAR",
                EntitlementCreateResponseDataResetPeriod.Month => "MONTH",
                EntitlementCreateResponseDataResetPeriod.Week => "WEEK",
                EntitlementCreateResponseDataResetPeriod.Day => "DAY",
                EntitlementCreateResponseDataResetPeriod.Hour => "HOUR",
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
[JsonConverter(typeof(EntitlementCreateResponseDataResetPeriodConfigurationConverter))]
public record class EntitlementCreateResponseDataResetPeriodConfiguration : ModelBase
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

    public EntitlementCreateResponseDataResetPeriodConfiguration(
        EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EntitlementCreateResponseDataResetPeriodConfiguration(
        EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EntitlementCreateResponseDataResetPeriodConfiguration(
        EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EntitlementCreateResponseDataResetPeriodConfiguration(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickYearlyResetPeriodConfig(out var value)) {
    ///     // `value` is of type `EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickYearlyResetPeriodConfig(
        [NotNullWhen(true)]
            out EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfig? value
    )
    {
        value =
            this.Value
            as EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMonthlyResetPeriodConfig(out var value)) {
    ///     // `value` is of type `EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMonthlyResetPeriodConfig(
        [NotNullWhen(true)]
            out EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig? value
    )
    {
        value =
            this.Value
            as EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickWeeklyResetPeriodConfig(out var value)) {
    ///     // `value` is of type `EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickWeeklyResetPeriodConfig(
        [NotNullWhen(true)]
            out EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig? value
    )
    {
        value =
            this.Value
            as EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig;
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
    ///     (EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfig value) => {...},
    ///     (EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig value) => {...},
    ///     (EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfig> yearlyResetPeriodConfig,
        System::Action<EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig> monthlyResetPeriodConfig,
        System::Action<EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig> weeklyResetPeriodConfig
    )
    {
        switch (this.Value)
        {
            case EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfig value:
                yearlyResetPeriodConfig(value);
                break;
            case EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig value:
                monthlyResetPeriodConfig(value);
                break;
            case EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig value:
                weeklyResetPeriodConfig(value);
                break;
            default:
                throw new StiggInvalidDataException(
                    "Data did not match any variant of EntitlementCreateResponseDataResetPeriodConfiguration"
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
    ///     (EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfig value) => {...},
    ///     (EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig value) => {...},
    ///     (EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<
            EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfig,
            T
        > yearlyResetPeriodConfig,
        System::Func<
            EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig,
            T
        > monthlyResetPeriodConfig,
        System::Func<
            EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig,
            T
        > weeklyResetPeriodConfig
    )
    {
        return this.Value switch
        {
            EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfig value =>
                yearlyResetPeriodConfig(value),
            EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig value =>
                monthlyResetPeriodConfig(value),
            EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig value =>
                weeklyResetPeriodConfig(value),
            _ => throw new StiggInvalidDataException(
                "Data did not match any variant of EntitlementCreateResponseDataResetPeriodConfiguration"
            ),
        };
    }

    public static implicit operator EntitlementCreateResponseDataResetPeriodConfiguration(
        EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfig value
    ) => new(value);

    public static implicit operator EntitlementCreateResponseDataResetPeriodConfiguration(
        EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig value
    ) => new(value);

    public static implicit operator EntitlementCreateResponseDataResetPeriodConfiguration(
        EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig value
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
                "Data did not match any variant of EntitlementCreateResponseDataResetPeriodConfiguration"
            );
        }
        this.Switch(
            (yearlyResetPeriodConfig) => yearlyResetPeriodConfig.Validate(),
            (monthlyResetPeriodConfig) => monthlyResetPeriodConfig.Validate(),
            (weeklyResetPeriodConfig) => weeklyResetPeriodConfig.Validate()
        );
    }

    public virtual bool Equals(EntitlementCreateResponseDataResetPeriodConfiguration? other) =>
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
            EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfig _ => 0,
            EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig _ => 1,
            EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig _ => 2,
            _ => -1,
        };
    }
}

sealed class EntitlementCreateResponseDataResetPeriodConfigurationConverter
    : JsonConverter<EntitlementCreateResponseDataResetPeriodConfiguration?>
{
    public override EntitlementCreateResponseDataResetPeriodConfiguration? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized =
                JsonSerializer.Deserialize<EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfig>(
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
                JsonSerializer.Deserialize<EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig>(
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
                JsonSerializer.Deserialize<EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig>(
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
        EntitlementCreateResponseDataResetPeriodConfiguration? value,
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
        EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfig,
        EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfigFromRaw
    >)
)]
public sealed record class EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfig
    : JsonModel
{
    /// <summary>
    /// Reset anchor (SubscriptionStart)
    /// </summary>
    public required ApiEnum<
        string,
        EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
    > AccordingTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
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

    public EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfig(
        EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfig entitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfig
    )
        : base(entitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfig) { }
#pragma warning restore CS8618

    public EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfigFromRaw.FromRawUnchecked"/>
    public static EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfig(
        ApiEnum<
            string,
            EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
        > accordingTo
    )
        : this()
    {
        this.AccordingTo = accordingTo;
    }
}

class EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfigFromRaw
    : IFromRawJson<EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfig>
{
    /// <inheritdoc/>
    public EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfig.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Reset anchor (SubscriptionStart)
/// </summary>
[JsonConverter(
    typeof(EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingToConverter)
)]
public enum EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
{
    SubscriptionStart,
}

sealed class EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingToConverter
    : JsonConverter<EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo>
{
    public override EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SubscriptionStart" =>
                EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart,
            _ =>
                (EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart =>
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
        EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig,
        EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigFromRaw
    >)
)]
public sealed record class EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig
    : JsonModel
{
    /// <summary>
    /// Reset anchor (SubscriptionStart or StartOfTheMonth)
    /// </summary>
    public required ApiEnum<
        string,
        EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
    > AccordingTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
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

    public EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig(
        EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig entitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig
    )
        : base(entitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig) { }
#pragma warning restore CS8618

    public EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigFromRaw.FromRawUnchecked"/>
    public static EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig(
        ApiEnum<
            string,
            EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
        > accordingTo
    )
        : this()
    {
        this.AccordingTo = accordingTo;
    }
}

class EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigFromRaw
    : IFromRawJson<EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig>
{
    /// <inheritdoc/>
    public EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Reset anchor (SubscriptionStart or StartOfTheMonth)
/// </summary>
[JsonConverter(
    typeof(EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingToConverter)
)]
public enum EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
{
    SubscriptionStart,
    StartOfTheMonth,
}

sealed class EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingToConverter
    : JsonConverter<EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo>
{
    public override EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SubscriptionStart" =>
                EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart,
            "StartOfTheMonth" =>
                EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.StartOfTheMonth,
            _ =>
                (EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart =>
                    "SubscriptionStart",
                EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.StartOfTheMonth =>
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
        EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig,
        EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigFromRaw
    >)
)]
public sealed record class EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig
    : JsonModel
{
    /// <summary>
    /// Reset anchor (SubscriptionStart or specific day)
    /// </summary>
    public required ApiEnum<
        string,
        EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
    > AccordingTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
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

    public EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig(
        EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig entitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig
    )
        : base(entitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig) { }
#pragma warning restore CS8618

    public EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigFromRaw.FromRawUnchecked"/>
    public static EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig(
        ApiEnum<
            string,
            EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
        > accordingTo
    )
        : this()
    {
        this.AccordingTo = accordingTo;
    }
}

class EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigFromRaw
    : IFromRawJson<EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig>
{
    /// <inheritdoc/>
    public EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Reset anchor (SubscriptionStart or specific day)
/// </summary>
[JsonConverter(
    typeof(EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingToConverter)
)]
public enum EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
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

sealed class EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingToConverter
    : JsonConverter<EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo>
{
    public override EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SubscriptionStart" =>
                EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart,
            "EverySunday" =>
                EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EverySunday,
            "EveryMonday" =>
                EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryMonday,
            "EveryTuesday" =>
                EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryTuesday,
            "EveryWednesday" =>
                EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryWednesday,
            "EveryThursday" =>
                EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryThursday,
            "EveryFriday" =>
                EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryFriday,
            "EverySaturday" =>
                EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EverySaturday,
            _ =>
                (EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart =>
                    "SubscriptionStart",
                EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EverySunday =>
                    "EverySunday",
                EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryMonday =>
                    "EveryMonday",
                EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryTuesday =>
                    "EveryTuesday",
                EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryWednesday =>
                    "EveryWednesday",
                EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryThursday =>
                    "EveryThursday",
                EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryFriday =>
                    "EveryFriday",
                EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EverySaturday =>
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
[JsonConverter(typeof(EntitlementCreateResponseDataTypeConverter))]
public enum EntitlementCreateResponseDataType
{
    Feature,
    Credit,
}

sealed class EntitlementCreateResponseDataTypeConverter
    : JsonConverter<EntitlementCreateResponseDataType>
{
    public override EntitlementCreateResponseDataType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FEATURE" => EntitlementCreateResponseDataType.Feature,
            "CREDIT" => EntitlementCreateResponseDataType.Credit,
            _ => (EntitlementCreateResponseDataType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntitlementCreateResponseDataType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntitlementCreateResponseDataType.Feature => "FEATURE",
                EntitlementCreateResponseDataType.Credit => "CREDIT",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
