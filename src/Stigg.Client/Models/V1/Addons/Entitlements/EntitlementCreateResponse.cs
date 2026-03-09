using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using System = System;

namespace Stigg.Client.Models.V1.Addons.Entitlements;

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
/// Feature entitlement response
/// </summary>
[JsonConverter(typeof(EntitlementCreateResponseDataConverter))]
public record class EntitlementCreateResponseData : ModelBase
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

    public EntitlementCreateResponseData(
        EntitlementCreateResponseDataFeature value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EntitlementCreateResponseData(
        EntitlementCreateResponseDataCredit value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EntitlementCreateResponseData(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EntitlementCreateResponseDataFeature"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFeature(out var value)) {
    ///     // `value` is of type `EntitlementCreateResponseDataFeature`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFeature([NotNullWhen(true)] out EntitlementCreateResponseDataFeature? value)
    {
        value = this.Value as EntitlementCreateResponseDataFeature;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EntitlementCreateResponseDataCredit"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCredit(out var value)) {
    ///     // `value` is of type `EntitlementCreateResponseDataCredit`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCredit([NotNullWhen(true)] out EntitlementCreateResponseDataCredit? value)
    {
        value = this.Value as EntitlementCreateResponseDataCredit;
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
    ///     (EntitlementCreateResponseDataFeature value) => {...},
    ///     (EntitlementCreateResponseDataCredit value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<EntitlementCreateResponseDataFeature> feature,
        System::Action<EntitlementCreateResponseDataCredit> credit
    )
    {
        switch (this.Value)
        {
            case EntitlementCreateResponseDataFeature value:
                feature(value);
                break;
            case EntitlementCreateResponseDataCredit value:
                credit(value);
                break;
            default:
                throw new StiggInvalidDataException(
                    "Data did not match any variant of EntitlementCreateResponseData"
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
    ///     (EntitlementCreateResponseDataFeature value) => {...},
    ///     (EntitlementCreateResponseDataCredit value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<EntitlementCreateResponseDataFeature, T> feature,
        System::Func<EntitlementCreateResponseDataCredit, T> credit
    )
    {
        return this.Value switch
        {
            EntitlementCreateResponseDataFeature value => feature(value),
            EntitlementCreateResponseDataCredit value => credit(value),
            _ => throw new StiggInvalidDataException(
                "Data did not match any variant of EntitlementCreateResponseData"
            ),
        };
    }

    public static implicit operator EntitlementCreateResponseData(
        EntitlementCreateResponseDataFeature value
    ) => new(value);

    public static implicit operator EntitlementCreateResponseData(
        EntitlementCreateResponseDataCredit value
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
                "Data did not match any variant of EntitlementCreateResponseData"
            );
        }
        this.Switch((feature) => feature.Validate(), (credit) => credit.Validate());
    }

    public virtual bool Equals(EntitlementCreateResponseData? other) =>
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
            EntitlementCreateResponseDataFeature _ => 0,
            EntitlementCreateResponseDataCredit _ => 1,
            _ => -1,
        };
    }
}

sealed class EntitlementCreateResponseDataConverter : JsonConverter<EntitlementCreateResponseData>
{
    public override EntitlementCreateResponseData? Read(
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
                    var deserialized =
                        JsonSerializer.Deserialize<EntitlementCreateResponseDataFeature>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is StiggInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "CREDIT":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<EntitlementCreateResponseDataCredit>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is StiggInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new EntitlementCreateResponseData(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntitlementCreateResponseData value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Feature entitlement response
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        EntitlementCreateResponseDataFeature,
        EntitlementCreateResponseDataFeatureFromRaw
    >)
)]
public sealed record class EntitlementCreateResponseDataFeature : JsonModel
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
    public required ApiEnum<string, EntitlementCreateResponseDataFeatureBehavior> Behavior
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, EntitlementCreateResponseDataFeatureBehavior>
            >("behavior");
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
    public required IReadOnlyList<
        ApiEnum<string, EntitlementCreateResponseDataFeatureHiddenFromWidget>
    > HiddenFromWidgets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<
                    ApiEnum<string, EntitlementCreateResponseDataFeatureHiddenFromWidget>
                >
            >("hiddenFromWidgets");
        }
        init
        {
            this._rawData.Set<
                ImmutableArray<
                    ApiEnum<string, EntitlementCreateResponseDataFeatureHiddenFromWidget>
                >
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
    public required ApiEnum<string, EntitlementCreateResponseDataFeatureResetPeriod>? ResetPeriod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, EntitlementCreateResponseDataFeatureResetPeriod>
            >("resetPeriod");
        }
        init { this._rawData.Set("resetPeriod", value); }
    }

    /// <summary>
    /// Reset period configuration (for feature entitlements)
    /// </summary>
    public required EntitlementCreateResponseDataFeatureResetPeriodConfiguration? ResetPeriodConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EntitlementCreateResponseDataFeatureResetPeriodConfiguration>(
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

    public EntitlementCreateResponseDataFeature()
    {
        this.Type = JsonSerializer.SerializeToElement("FEATURE");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementCreateResponseDataFeature(
        EntitlementCreateResponseDataFeature entitlementCreateResponseDataFeature
    )
        : base(entitlementCreateResponseDataFeature) { }
#pragma warning restore CS8618

    public EntitlementCreateResponseDataFeature(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("FEATURE");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementCreateResponseDataFeature(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementCreateResponseDataFeatureFromRaw.FromRawUnchecked"/>
    public static EntitlementCreateResponseDataFeature FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntitlementCreateResponseDataFeatureFromRaw
    : IFromRawJson<EntitlementCreateResponseDataFeature>
{
    /// <inheritdoc/>
    public EntitlementCreateResponseDataFeature FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementCreateResponseDataFeature.FromRawUnchecked(rawData);
}

/// <summary>
/// Entitlement behavior (Increment or Override)
/// </summary>
[JsonConverter(typeof(EntitlementCreateResponseDataFeatureBehaviorConverter))]
public enum EntitlementCreateResponseDataFeatureBehavior
{
    Increment,
    Override,
}

sealed class EntitlementCreateResponseDataFeatureBehaviorConverter
    : JsonConverter<EntitlementCreateResponseDataFeatureBehavior>
{
    public override EntitlementCreateResponseDataFeatureBehavior Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Increment" => EntitlementCreateResponseDataFeatureBehavior.Increment,
            "Override" => EntitlementCreateResponseDataFeatureBehavior.Override,
            _ => (EntitlementCreateResponseDataFeatureBehavior)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntitlementCreateResponseDataFeatureBehavior value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntitlementCreateResponseDataFeatureBehavior.Increment => "Increment",
                EntitlementCreateResponseDataFeatureBehavior.Override => "Override",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(EntitlementCreateResponseDataFeatureHiddenFromWidgetConverter))]
public enum EntitlementCreateResponseDataFeatureHiddenFromWidget
{
    Paywall,
    CustomerPortal,
    Checkout,
}

sealed class EntitlementCreateResponseDataFeatureHiddenFromWidgetConverter
    : JsonConverter<EntitlementCreateResponseDataFeatureHiddenFromWidget>
{
    public override EntitlementCreateResponseDataFeatureHiddenFromWidget Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PAYWALL" => EntitlementCreateResponseDataFeatureHiddenFromWidget.Paywall,
            "CUSTOMER_PORTAL" =>
                EntitlementCreateResponseDataFeatureHiddenFromWidget.CustomerPortal,
            "CHECKOUT" => EntitlementCreateResponseDataFeatureHiddenFromWidget.Checkout,
            _ => (EntitlementCreateResponseDataFeatureHiddenFromWidget)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntitlementCreateResponseDataFeatureHiddenFromWidget value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntitlementCreateResponseDataFeatureHiddenFromWidget.Paywall => "PAYWALL",
                EntitlementCreateResponseDataFeatureHiddenFromWidget.CustomerPortal =>
                    "CUSTOMER_PORTAL",
                EntitlementCreateResponseDataFeatureHiddenFromWidget.Checkout => "CHECKOUT",
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
[JsonConverter(typeof(EntitlementCreateResponseDataFeatureResetPeriodConverter))]
public enum EntitlementCreateResponseDataFeatureResetPeriod
{
    Year,
    Month,
    Week,
    Day,
    Hour,
}

sealed class EntitlementCreateResponseDataFeatureResetPeriodConverter
    : JsonConverter<EntitlementCreateResponseDataFeatureResetPeriod>
{
    public override EntitlementCreateResponseDataFeatureResetPeriod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "YEAR" => EntitlementCreateResponseDataFeatureResetPeriod.Year,
            "MONTH" => EntitlementCreateResponseDataFeatureResetPeriod.Month,
            "WEEK" => EntitlementCreateResponseDataFeatureResetPeriod.Week,
            "DAY" => EntitlementCreateResponseDataFeatureResetPeriod.Day,
            "HOUR" => EntitlementCreateResponseDataFeatureResetPeriod.Hour,
            _ => (EntitlementCreateResponseDataFeatureResetPeriod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntitlementCreateResponseDataFeatureResetPeriod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntitlementCreateResponseDataFeatureResetPeriod.Year => "YEAR",
                EntitlementCreateResponseDataFeatureResetPeriod.Month => "MONTH",
                EntitlementCreateResponseDataFeatureResetPeriod.Week => "WEEK",
                EntitlementCreateResponseDataFeatureResetPeriod.Day => "DAY",
                EntitlementCreateResponseDataFeatureResetPeriod.Hour => "HOUR",
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
[JsonConverter(typeof(EntitlementCreateResponseDataFeatureResetPeriodConfigurationConverter))]
public record class EntitlementCreateResponseDataFeatureResetPeriodConfiguration : ModelBase
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

    public EntitlementCreateResponseDataFeatureResetPeriodConfiguration(
        EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EntitlementCreateResponseDataFeatureResetPeriodConfiguration(
        EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EntitlementCreateResponseDataFeatureResetPeriodConfiguration(
        EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EntitlementCreateResponseDataFeatureResetPeriodConfiguration(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickYearlyResetPeriodConfig(out var value)) {
    ///     // `value` is of type `EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickYearlyResetPeriodConfig(
        [NotNullWhen(true)]
            out EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig? value
    )
    {
        value =
            this.Value
            as EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMonthlyResetPeriodConfig(out var value)) {
    ///     // `value` is of type `EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMonthlyResetPeriodConfig(
        [NotNullWhen(true)]
            out EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig? value
    )
    {
        value =
            this.Value
            as EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickWeeklyResetPeriodConfig(out var value)) {
    ///     // `value` is of type `EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickWeeklyResetPeriodConfig(
        [NotNullWhen(true)]
            out EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig? value
    )
    {
        value =
            this.Value
            as EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig;
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
    ///     (EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig value) => {...},
    ///     (EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig value) => {...},
    ///     (EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig> yearlyResetPeriodConfig,
        System::Action<EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig> monthlyResetPeriodConfig,
        System::Action<EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig> weeklyResetPeriodConfig
    )
    {
        switch (this.Value)
        {
            case EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig value:
                yearlyResetPeriodConfig(value);
                break;
            case EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig value:
                monthlyResetPeriodConfig(value);
                break;
            case EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig value:
                weeklyResetPeriodConfig(value);
                break;
            default:
                throw new StiggInvalidDataException(
                    "Data did not match any variant of EntitlementCreateResponseDataFeatureResetPeriodConfiguration"
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
    ///     (EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig value) => {...},
    ///     (EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig value) => {...},
    ///     (EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<
            EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig,
            T
        > yearlyResetPeriodConfig,
        System::Func<
            EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig,
            T
        > monthlyResetPeriodConfig,
        System::Func<
            EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig,
            T
        > weeklyResetPeriodConfig
    )
    {
        return this.Value switch
        {
            EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig value =>
                yearlyResetPeriodConfig(value),
            EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig value =>
                monthlyResetPeriodConfig(value),
            EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig value =>
                weeklyResetPeriodConfig(value),
            _ => throw new StiggInvalidDataException(
                "Data did not match any variant of EntitlementCreateResponseDataFeatureResetPeriodConfiguration"
            ),
        };
    }

    public static implicit operator EntitlementCreateResponseDataFeatureResetPeriodConfiguration(
        EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig value
    ) => new(value);

    public static implicit operator EntitlementCreateResponseDataFeatureResetPeriodConfiguration(
        EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig value
    ) => new(value);

    public static implicit operator EntitlementCreateResponseDataFeatureResetPeriodConfiguration(
        EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig value
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
                "Data did not match any variant of EntitlementCreateResponseDataFeatureResetPeriodConfiguration"
            );
        }
        this.Switch(
            (yearlyResetPeriodConfig) => yearlyResetPeriodConfig.Validate(),
            (monthlyResetPeriodConfig) => monthlyResetPeriodConfig.Validate(),
            (weeklyResetPeriodConfig) => weeklyResetPeriodConfig.Validate()
        );
    }

    public virtual bool Equals(
        EntitlementCreateResponseDataFeatureResetPeriodConfiguration? other
    ) =>
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
            EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig _ =>
                0,
            EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig _ =>
                1,
            EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig _ =>
                2,
            _ => -1,
        };
    }
}

sealed class EntitlementCreateResponseDataFeatureResetPeriodConfigurationConverter
    : JsonConverter<EntitlementCreateResponseDataFeatureResetPeriodConfiguration?>
{
    public override EntitlementCreateResponseDataFeatureResetPeriodConfiguration? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized =
                JsonSerializer.Deserialize<EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig>(
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
                JsonSerializer.Deserialize<EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig>(
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
                JsonSerializer.Deserialize<EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig>(
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
        EntitlementCreateResponseDataFeatureResetPeriodConfiguration? value,
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
        EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig,
        EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigFromRaw
    >)
)]
public sealed record class EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig
    : JsonModel
{
    /// <summary>
    /// Reset anchor (SubscriptionStart)
    /// </summary>
    public required ApiEnum<
        string,
        EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
    > AccordingTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
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

    public EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig(
        EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig entitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig
    )
        : base(entitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig)
    { }
#pragma warning restore CS8618

    public EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigFromRaw.FromRawUnchecked"/>
    public static EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig(
        ApiEnum<
            string,
            EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
        > accordingTo
    )
        : this()
    {
        this.AccordingTo = accordingTo;
    }
}

class EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigFromRaw
    : IFromRawJson<EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig>
{
    /// <inheritdoc/>
    public EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Reset anchor (SubscriptionStart)
/// </summary>
[JsonConverter(
    typeof(EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingToConverter)
)]
public enum EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
{
    SubscriptionStart,
}

sealed class EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingToConverter
    : JsonConverter<EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo>
{
    public override EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SubscriptionStart" =>
                EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart,
            _ =>
                (EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart =>
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
        EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig,
        EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigFromRaw
    >)
)]
public sealed record class EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig
    : JsonModel
{
    /// <summary>
    /// Reset anchor (SubscriptionStart or StartOfTheMonth)
    /// </summary>
    public required ApiEnum<
        string,
        EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
    > AccordingTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
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

    public EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig()
    { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig(
        EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig entitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig
    )
        : base(entitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig)
    { }
#pragma warning restore CS8618

    public EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigFromRaw.FromRawUnchecked"/>
    public static EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig(
        ApiEnum<
            string,
            EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
        > accordingTo
    )
        : this()
    {
        this.AccordingTo = accordingTo;
    }
}

class EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigFromRaw
    : IFromRawJson<EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig>
{
    /// <inheritdoc/>
    public EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Reset anchor (SubscriptionStart or StartOfTheMonth)
/// </summary>
[JsonConverter(
    typeof(EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingToConverter)
)]
public enum EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
{
    SubscriptionStart,
    StartOfTheMonth,
}

sealed class EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingToConverter
    : JsonConverter<EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo>
{
    public override EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SubscriptionStart" =>
                EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart,
            "StartOfTheMonth" =>
                EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.StartOfTheMonth,
            _ =>
                (EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart =>
                    "SubscriptionStart",
                EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.StartOfTheMonth =>
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
        EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig,
        EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigFromRaw
    >)
)]
public sealed record class EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig
    : JsonModel
{
    /// <summary>
    /// Reset anchor (SubscriptionStart or specific day)
    /// </summary>
    public required ApiEnum<
        string,
        EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
    > AccordingTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
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

    public EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig(
        EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig entitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig
    )
        : base(entitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig)
    { }
#pragma warning restore CS8618

    public EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigFromRaw.FromRawUnchecked"/>
    public static EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig(
        ApiEnum<
            string,
            EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
        > accordingTo
    )
        : this()
    {
        this.AccordingTo = accordingTo;
    }
}

class EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigFromRaw
    : IFromRawJson<EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig>
{
    /// <inheritdoc/>
    public EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Reset anchor (SubscriptionStart or specific day)
/// </summary>
[JsonConverter(
    typeof(EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingToConverter)
)]
public enum EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
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

sealed class EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingToConverter
    : JsonConverter<EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo>
{
    public override EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SubscriptionStart" =>
                EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart,
            "EverySunday" =>
                EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EverySunday,
            "EveryMonday" =>
                EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryMonday,
            "EveryTuesday" =>
                EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryTuesday,
            "EveryWednesday" =>
                EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryWednesday,
            "EveryThursday" =>
                EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryThursday,
            "EveryFriday" =>
                EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryFriday,
            "EverySaturday" =>
                EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EverySaturday,
            _ =>
                (EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart =>
                    "SubscriptionStart",
                EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EverySunday =>
                    "EverySunday",
                EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryMonday =>
                    "EveryMonday",
                EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryTuesday =>
                    "EveryTuesday",
                EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryWednesday =>
                    "EveryWednesday",
                EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryThursday =>
                    "EveryThursday",
                EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryFriday =>
                    "EveryFriday",
                EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EverySaturday =>
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
/// Credit entitlement response
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        EntitlementCreateResponseDataCredit,
        EntitlementCreateResponseDataCreditFromRaw
    >)
)]
public sealed record class EntitlementCreateResponseDataCredit : JsonModel
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
    public required ApiEnum<string, EntitlementCreateResponseDataCreditBehavior> Behavior
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, EntitlementCreateResponseDataCreditBehavior>
            >("behavior");
        }
        init { this._rawData.Set("behavior", value); }
    }

    /// <summary>
    /// Credit grant cadence (for credit entitlements)
    /// </summary>
    public required ApiEnum<string, EntitlementCreateResponseDataCreditCadence>? Cadence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, EntitlementCreateResponseDataCreditCadence>
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
    public required IReadOnlyList<
        ApiEnum<string, EntitlementCreateResponseDataCreditHiddenFromWidget>
    > HiddenFromWidgets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<ApiEnum<string, EntitlementCreateResponseDataCreditHiddenFromWidget>>
            >("hiddenFromWidgets");
        }
        init
        {
            this._rawData.Set<
                ImmutableArray<ApiEnum<string, EntitlementCreateResponseDataCreditHiddenFromWidget>>
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
    }

    public EntitlementCreateResponseDataCredit()
    {
        this.Type = JsonSerializer.SerializeToElement("CREDIT");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementCreateResponseDataCredit(
        EntitlementCreateResponseDataCredit entitlementCreateResponseDataCredit
    )
        : base(entitlementCreateResponseDataCredit) { }
#pragma warning restore CS8618

    public EntitlementCreateResponseDataCredit(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("CREDIT");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementCreateResponseDataCredit(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementCreateResponseDataCreditFromRaw.FromRawUnchecked"/>
    public static EntitlementCreateResponseDataCredit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntitlementCreateResponseDataCreditFromRaw : IFromRawJson<EntitlementCreateResponseDataCredit>
{
    /// <inheritdoc/>
    public EntitlementCreateResponseDataCredit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementCreateResponseDataCredit.FromRawUnchecked(rawData);
}

/// <summary>
/// Entitlement behavior (Increment or Override)
/// </summary>
[JsonConverter(typeof(EntitlementCreateResponseDataCreditBehaviorConverter))]
public enum EntitlementCreateResponseDataCreditBehavior
{
    Increment,
    Override,
}

sealed class EntitlementCreateResponseDataCreditBehaviorConverter
    : JsonConverter<EntitlementCreateResponseDataCreditBehavior>
{
    public override EntitlementCreateResponseDataCreditBehavior Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Increment" => EntitlementCreateResponseDataCreditBehavior.Increment,
            "Override" => EntitlementCreateResponseDataCreditBehavior.Override,
            _ => (EntitlementCreateResponseDataCreditBehavior)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntitlementCreateResponseDataCreditBehavior value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntitlementCreateResponseDataCreditBehavior.Increment => "Increment",
                EntitlementCreateResponseDataCreditBehavior.Override => "Override",
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
[JsonConverter(typeof(EntitlementCreateResponseDataCreditCadenceConverter))]
public enum EntitlementCreateResponseDataCreditCadence
{
    Month,
    Year,
}

sealed class EntitlementCreateResponseDataCreditCadenceConverter
    : JsonConverter<EntitlementCreateResponseDataCreditCadence>
{
    public override EntitlementCreateResponseDataCreditCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "MONTH" => EntitlementCreateResponseDataCreditCadence.Month,
            "YEAR" => EntitlementCreateResponseDataCreditCadence.Year,
            _ => (EntitlementCreateResponseDataCreditCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntitlementCreateResponseDataCreditCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntitlementCreateResponseDataCreditCadence.Month => "MONTH",
                EntitlementCreateResponseDataCreditCadence.Year => "YEAR",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(EntitlementCreateResponseDataCreditHiddenFromWidgetConverter))]
public enum EntitlementCreateResponseDataCreditHiddenFromWidget
{
    Paywall,
    CustomerPortal,
    Checkout,
}

sealed class EntitlementCreateResponseDataCreditHiddenFromWidgetConverter
    : JsonConverter<EntitlementCreateResponseDataCreditHiddenFromWidget>
{
    public override EntitlementCreateResponseDataCreditHiddenFromWidget Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PAYWALL" => EntitlementCreateResponseDataCreditHiddenFromWidget.Paywall,
            "CUSTOMER_PORTAL" => EntitlementCreateResponseDataCreditHiddenFromWidget.CustomerPortal,
            "CHECKOUT" => EntitlementCreateResponseDataCreditHiddenFromWidget.Checkout,
            _ => (EntitlementCreateResponseDataCreditHiddenFromWidget)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntitlementCreateResponseDataCreditHiddenFromWidget value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntitlementCreateResponseDataCreditHiddenFromWidget.Paywall => "PAYWALL",
                EntitlementCreateResponseDataCreditHiddenFromWidget.CustomerPortal =>
                    "CUSTOMER_PORTAL",
                EntitlementCreateResponseDataCreditHiddenFromWidget.Checkout => "CHECKOUT",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
