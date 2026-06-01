using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using System = System;

namespace Stigg.Client.Models.V1.Plans.Entitlements;

/// <summary>
/// Response object
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PlanEntitlement, PlanEntitlementFromRaw>))]
public sealed record class PlanEntitlement : JsonModel
{
    /// <summary>
    /// Feature entitlement response
    /// </summary>
    public required Data Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Data>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public PlanEntitlement() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlanEntitlement(PlanEntitlement planEntitlement)
        : base(planEntitlement) { }
#pragma warning restore CS8618

    public PlanEntitlement(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlanEntitlement(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlanEntitlementFromRaw.FromRawUnchecked"/>
    public static PlanEntitlement FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PlanEntitlement(Data data)
        : this()
    {
        this.Data = data;
    }
}

class PlanEntitlementFromRaw : IFromRawJson<PlanEntitlement>
{
    /// <inheritdoc/>
    public PlanEntitlement FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PlanEntitlement.FromRawUnchecked(rawData);
}

/// <summary>
/// Feature entitlement response
/// </summary>
[JsonConverter(typeof(DataConverter))]
public record class Data : ModelBase
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

    public string ID
    {
        get { return Match(feature: (x) => x.ID, credit: (x) => x.ID); }
    }

    public System::DateTimeOffset CreatedAt
    {
        get { return Match(feature: (x) => x.CreatedAt, credit: (x) => x.CreatedAt); }
    }

    public string? Description
    {
        get { return Match<string?>(feature: (x) => x.Description, credit: (x) => x.Description); }
    }

    public string? DisplayNameOverride
    {
        get
        {
            return Match<string?>(
                feature: (x) => x.DisplayNameOverride,
                credit: (x) => x.DisplayNameOverride
            );
        }
    }

    public bool? IsCustom
    {
        get { return Match<bool?>(feature: (x) => x.IsCustom, credit: (x) => x.IsCustom); }
    }

    public bool IsGranted
    {
        get { return Match(feature: (x) => x.IsGranted, credit: (x) => x.IsGranted); }
    }

    public double? Order
    {
        get { return Match<double?>(feature: (x) => x.Order, credit: (x) => x.Order); }
    }

    public JsonElement Type
    {
        get { return Match(feature: (x) => x.Type, credit: (x) => x.Type); }
    }

    public System::DateTimeOffset UpdatedAt
    {
        get { return Match(feature: (x) => x.UpdatedAt, credit: (x) => x.UpdatedAt); }
    }

    public Data(DataFeature value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Data(DataCredit value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Data(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="DataFeature"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFeature(out var value)) {
    ///     // `value` is of type `DataFeature`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFeature([NotNullWhen(true)] out DataFeature? value)
    {
        value = this.Value as DataFeature;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="DataCredit"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCredit(out var value)) {
    ///     // `value` is of type `DataCredit`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCredit([NotNullWhen(true)] out DataCredit? value)
    {
        value = this.Value as DataCredit;
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
    ///     (DataFeature value) =&gt; {...},
    ///     (DataCredit value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(System::Action<DataFeature> feature, System::Action<DataCredit> credit)
    {
        switch (this.Value)
        {
            case DataFeature value:
                feature(value);
                break;
            case DataCredit value:
                credit(value);
                break;
            default:
                throw new StiggInvalidDataException("Data did not match any variant of Data");
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
    ///     (DataFeature value) =&gt; {...},
    ///     (DataCredit value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(System::Func<DataFeature, T> feature, System::Func<DataCredit, T> credit)
    {
        return this.Value switch
        {
            DataFeature value => feature(value),
            DataCredit value => credit(value),
            _ => throw new StiggInvalidDataException("Data did not match any variant of Data"),
        };
    }

    public static implicit operator Data(DataFeature value) => new(value);

    public static implicit operator Data(DataCredit value) => new(value);

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
            throw new StiggInvalidDataException("Data did not match any variant of Data");
        }
        this.Switch((feature) => feature.Validate(), (credit) => credit.Validate());
    }

    public virtual bool Equals(Data? other) =>
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
            DataFeature _ => 0,
            DataCredit _ => 1,
            _ => -1,
        };
    }
}

sealed class DataConverter : JsonConverter<Data>
{
    public override Data? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try
        {
            type = element.GetProperty("type").GetString();
        }
        catch
        {
            type = null;
        }

        switch (type)
        {
            case "FEATURE":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<DataFeature>(element, options);
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "CREDIT":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<DataCredit>(element, options);
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new Data(element);
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Data value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Feature entitlement response
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DataFeature, DataFeatureFromRaw>))]
public sealed record class DataFeature : JsonModel
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
    /// Entitlement behavior (Increment or Override)
    /// </summary>
    public required ApiEnum<string, DataFeatureBehavior> Behavior
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, DataFeatureBehavior>>("behavior");
        }
        init { this._rawData.Set("behavior", value); }
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
    public required IReadOnlyList<ApiEnum<string, DataFeatureHiddenFromWidget>> HiddenFromWidgets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<ApiEnum<string, DataFeatureHiddenFromWidget>>
            >("hiddenFromWidgets");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ApiEnum<string, DataFeatureHiddenFromWidget>>>(
                "hiddenFromWidgets",
                ImmutableArray.ToImmutableArray(value)
            );
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
    public required ApiEnum<string, DataFeatureResetPeriod>? ResetPeriod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, DataFeatureResetPeriod>>(
                "resetPeriod"
            );
        }
        init { this._rawData.Set("resetPeriod", value); }
    }

    /// <summary>
    /// Reset period configuration (for feature entitlements)
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
    /// Entitlement type (FEATURE or CREDIT)
    /// </summary>
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
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
        this.Behavior.Validate();
        _ = this.CreatedAt;
        _ = this.Description;
        _ = this.DisplayNameOverride;
        _ = this.EnumValues;
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("FEATURE")))
        {
            throw new StiggInvalidDataException("Invalid value given for constant");
        }
        _ = this.UpdatedAt;
        _ = this.UsageLimit;
    }

    public DataFeature()
    {
        this.Type = JsonSerializer.SerializeToElement("FEATURE");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DataFeature(DataFeature dataFeature)
        : base(dataFeature) { }
#pragma warning restore CS8618

    public DataFeature(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("FEATURE");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DataFeature(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataFeatureFromRaw.FromRawUnchecked"/>
    public static DataFeature FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataFeatureFromRaw : IFromRawJson<DataFeature>
{
    /// <inheritdoc/>
    public DataFeature FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DataFeature.FromRawUnchecked(rawData);
}

/// <summary>
/// Entitlement behavior (Increment or Override)
/// </summary>
[JsonConverter(typeof(DataFeatureBehaviorConverter))]
public enum DataFeatureBehavior
{
    Increment,
    Override,
}

sealed class DataFeatureBehaviorConverter : JsonConverter<DataFeatureBehavior>
{
    public override DataFeatureBehavior Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Increment" => DataFeatureBehavior.Increment,
            "Override" => DataFeatureBehavior.Override,
            _ => (DataFeatureBehavior)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DataFeatureBehavior value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DataFeatureBehavior.Increment => "Increment",
                DataFeatureBehavior.Override => "Override",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(DataFeatureHiddenFromWidgetConverter))]
public enum DataFeatureHiddenFromWidget
{
    Paywall,
    CustomerPortal,
    Checkout,
}

sealed class DataFeatureHiddenFromWidgetConverter : JsonConverter<DataFeatureHiddenFromWidget>
{
    public override DataFeatureHiddenFromWidget Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PAYWALL" => DataFeatureHiddenFromWidget.Paywall,
            "CUSTOMER_PORTAL" => DataFeatureHiddenFromWidget.CustomerPortal,
            "CHECKOUT" => DataFeatureHiddenFromWidget.Checkout,
            _ => (DataFeatureHiddenFromWidget)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DataFeatureHiddenFromWidget value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DataFeatureHiddenFromWidget.Paywall => "PAYWALL",
                DataFeatureHiddenFromWidget.CustomerPortal => "CUSTOMER_PORTAL",
                DataFeatureHiddenFromWidget.Checkout => "CHECKOUT",
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
[JsonConverter(typeof(DataFeatureResetPeriodConverter))]
public enum DataFeatureResetPeriod
{
    Year,
    Month,
    Week,
    Day,
    Hour,
}

sealed class DataFeatureResetPeriodConverter : JsonConverter<DataFeatureResetPeriod>
{
    public override DataFeatureResetPeriod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "YEAR" => DataFeatureResetPeriod.Year,
            "MONTH" => DataFeatureResetPeriod.Month,
            "WEEK" => DataFeatureResetPeriod.Week,
            "DAY" => DataFeatureResetPeriod.Day,
            "HOUR" => DataFeatureResetPeriod.Hour,
            _ => (DataFeatureResetPeriod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DataFeatureResetPeriod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DataFeatureResetPeriod.Year => "YEAR",
                DataFeatureResetPeriod.Month => "MONTH",
                DataFeatureResetPeriod.Week => "WEEK",
                DataFeatureResetPeriod.Day => "DAY",
                DataFeatureResetPeriod.Hour => "HOUR",
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
/// Credit entitlement response
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DataCredit, DataCreditFromRaw>))]
public sealed record class DataCredit : JsonModel
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
    public required ApiEnum<string, DataCreditBehavior> Behavior
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, DataCreditBehavior>>("behavior");
        }
        init { this._rawData.Set("behavior", value); }
    }

    /// <summary>
    /// Credit grant cadence (for credit entitlements)
    /// </summary>
    public required ApiEnum<string, DataCreditCadence>? Cadence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, DataCreditCadence>>("cadence");
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
    /// Widget types where this entitlement is hidden
    /// </summary>
    public required IReadOnlyList<ApiEnum<string, DataCreditHiddenFromWidget>> HiddenFromWidgets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<ApiEnum<string, DataCreditHiddenFromWidget>>
            >("hiddenFromWidgets");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ApiEnum<string, DataCreditHiddenFromWidget>>>(
                "hiddenFromWidgets",
                ImmutableArray.ToImmutableArray(value)
            );
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
    /// Entitlement type (FEATURE or CREDIT)
    /// </summary>
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
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
    /// The feature ID this entitlement depends on (for credit entitlements). The
    /// entitlement value will be calculated as: base amount × dependency feature
    /// usage limit
    /// </summary>
    public string? DependencyFeatureID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("dependencyFeatureId");
        }
        init { this._rawData.Set("dependencyFeatureId", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Amount;
        this.Behavior.Validate();
        this.Cadence?.Validate();
        _ = this.CreatedAt;
        _ = this.Description;
        _ = this.DisplayNameOverride;
        foreach (var item in this.HiddenFromWidgets)
        {
            item.Validate();
        }
        _ = this.IsCustom;
        _ = this.IsGranted;
        _ = this.Order;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("CREDIT")))
        {
            throw new StiggInvalidDataException("Invalid value given for constant");
        }
        _ = this.UpdatedAt;
        _ = this.DependencyFeatureID;
    }

    public DataCredit()
    {
        this.Type = JsonSerializer.SerializeToElement("CREDIT");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DataCredit(DataCredit dataCredit)
        : base(dataCredit) { }
#pragma warning restore CS8618

    public DataCredit(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("CREDIT");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DataCredit(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataCreditFromRaw.FromRawUnchecked"/>
    public static DataCredit FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataCreditFromRaw : IFromRawJson<DataCredit>
{
    /// <inheritdoc/>
    public DataCredit FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DataCredit.FromRawUnchecked(rawData);
}

/// <summary>
/// Entitlement behavior (Increment or Override)
/// </summary>
[JsonConverter(typeof(DataCreditBehaviorConverter))]
public enum DataCreditBehavior
{
    Increment,
    Override,
}

sealed class DataCreditBehaviorConverter : JsonConverter<DataCreditBehavior>
{
    public override DataCreditBehavior Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Increment" => DataCreditBehavior.Increment,
            "Override" => DataCreditBehavior.Override,
            _ => (DataCreditBehavior)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DataCreditBehavior value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DataCreditBehavior.Increment => "Increment",
                DataCreditBehavior.Override => "Override",
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
[JsonConverter(typeof(DataCreditCadenceConverter))]
public enum DataCreditCadence
{
    Month,
    Year,
}

sealed class DataCreditCadenceConverter : JsonConverter<DataCreditCadence>
{
    public override DataCreditCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "MONTH" => DataCreditCadence.Month,
            "YEAR" => DataCreditCadence.Year,
            _ => (DataCreditCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DataCreditCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DataCreditCadence.Month => "MONTH",
                DataCreditCadence.Year => "YEAR",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(DataCreditHiddenFromWidgetConverter))]
public enum DataCreditHiddenFromWidget
{
    Paywall,
    CustomerPortal,
    Checkout,
}

sealed class DataCreditHiddenFromWidgetConverter : JsonConverter<DataCreditHiddenFromWidget>
{
    public override DataCreditHiddenFromWidget Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PAYWALL" => DataCreditHiddenFromWidget.Paywall,
            "CUSTOMER_PORTAL" => DataCreditHiddenFromWidget.CustomerPortal,
            "CHECKOUT" => DataCreditHiddenFromWidget.Checkout,
            _ => (DataCreditHiddenFromWidget)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DataCreditHiddenFromWidget value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DataCreditHiddenFromWidget.Paywall => "PAYWALL",
                DataCreditHiddenFromWidget.CustomerPortal => "CUSTOMER_PORTAL",
                DataCreditHiddenFromWidget.Checkout => "CHECKOUT",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
