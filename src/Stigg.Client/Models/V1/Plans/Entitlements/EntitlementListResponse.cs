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
/// Feature entitlement response
/// </summary>
[JsonConverter(typeof(EntitlementListResponseDataConverter))]
public record class EntitlementListResponseData : ModelBase
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

    public EntitlementListResponseData(
        EntitlementListResponseDataFeature value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EntitlementListResponseData(
        EntitlementListResponseDataCredit value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EntitlementListResponseData(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EntitlementListResponseDataFeature"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFeature(out var value)) {
    ///     // `value` is of type `EntitlementListResponseDataFeature`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFeature([NotNullWhen(true)] out EntitlementListResponseDataFeature? value)
    {
        value = this.Value as EntitlementListResponseDataFeature;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EntitlementListResponseDataCredit"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCredit(out var value)) {
    ///     // `value` is of type `EntitlementListResponseDataCredit`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCredit([NotNullWhen(true)] out EntitlementListResponseDataCredit? value)
    {
        value = this.Value as EntitlementListResponseDataCredit;
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
    ///     (EntitlementListResponseDataFeature value) => {...},
    ///     (EntitlementListResponseDataCredit value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<EntitlementListResponseDataFeature> feature,
        System::Action<EntitlementListResponseDataCredit> credit
    )
    {
        switch (this.Value)
        {
            case EntitlementListResponseDataFeature value:
                feature(value);
                break;
            case EntitlementListResponseDataCredit value:
                credit(value);
                break;
            default:
                throw new StiggInvalidDataException(
                    "Data did not match any variant of EntitlementListResponseData"
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
    ///     (EntitlementListResponseDataFeature value) => {...},
    ///     (EntitlementListResponseDataCredit value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<EntitlementListResponseDataFeature, T> feature,
        System::Func<EntitlementListResponseDataCredit, T> credit
    )
    {
        return this.Value switch
        {
            EntitlementListResponseDataFeature value => feature(value),
            EntitlementListResponseDataCredit value => credit(value),
            _ => throw new StiggInvalidDataException(
                "Data did not match any variant of EntitlementListResponseData"
            ),
        };
    }

    public static implicit operator EntitlementListResponseData(
        EntitlementListResponseDataFeature value
    ) => new(value);

    public static implicit operator EntitlementListResponseData(
        EntitlementListResponseDataCredit value
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
                "Data did not match any variant of EntitlementListResponseData"
            );
        }
        this.Switch((feature) => feature.Validate(), (credit) => credit.Validate());
    }

    public virtual bool Equals(EntitlementListResponseData? other) =>
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
            EntitlementListResponseDataFeature _ => 0,
            EntitlementListResponseDataCredit _ => 1,
            _ => -1,
        };
    }
}

sealed class EntitlementListResponseDataConverter : JsonConverter<EntitlementListResponseData>
{
    public override EntitlementListResponseData? Read(
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
                        JsonSerializer.Deserialize<EntitlementListResponseDataFeature>(
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
                        JsonSerializer.Deserialize<EntitlementListResponseDataCredit>(
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
                return new EntitlementListResponseData(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntitlementListResponseData value,
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
        EntitlementListResponseDataFeature,
        EntitlementListResponseDataFeatureFromRaw
    >)
)]
public sealed record class EntitlementListResponseDataFeature : JsonModel
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
    public required ApiEnum<string, EntitlementListResponseDataFeatureBehavior> Behavior
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, EntitlementListResponseDataFeatureBehavior>
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
        ApiEnum<string, EntitlementListResponseDataFeatureHiddenFromWidget>
    > HiddenFromWidgets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<ApiEnum<string, EntitlementListResponseDataFeatureHiddenFromWidget>>
            >("hiddenFromWidgets");
        }
        init
        {
            this._rawData.Set<
                ImmutableArray<ApiEnum<string, EntitlementListResponseDataFeatureHiddenFromWidget>>
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
    public required ApiEnum<string, EntitlementListResponseDataFeatureResetPeriod>? ResetPeriod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, EntitlementListResponseDataFeatureResetPeriod>
            >("resetPeriod");
        }
        init { this._rawData.Set("resetPeriod", value); }
    }

    /// <summary>
    /// Reset period configuration (for feature entitlements)
    /// </summary>
    public required EntitlementListResponseDataFeatureResetPeriodConfiguration? ResetPeriodConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EntitlementListResponseDataFeatureResetPeriodConfiguration>(
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

    public EntitlementListResponseDataFeature()
    {
        this.Type = JsonSerializer.SerializeToElement("FEATURE");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementListResponseDataFeature(
        EntitlementListResponseDataFeature entitlementListResponseDataFeature
    )
        : base(entitlementListResponseDataFeature) { }
#pragma warning restore CS8618

    public EntitlementListResponseDataFeature(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("FEATURE");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementListResponseDataFeature(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementListResponseDataFeatureFromRaw.FromRawUnchecked"/>
    public static EntitlementListResponseDataFeature FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntitlementListResponseDataFeatureFromRaw : IFromRawJson<EntitlementListResponseDataFeature>
{
    /// <inheritdoc/>
    public EntitlementListResponseDataFeature FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementListResponseDataFeature.FromRawUnchecked(rawData);
}

/// <summary>
/// Entitlement behavior (Increment or Override)
/// </summary>
[JsonConverter(typeof(EntitlementListResponseDataFeatureBehaviorConverter))]
public enum EntitlementListResponseDataFeatureBehavior
{
    Increment,
    Override,
}

sealed class EntitlementListResponseDataFeatureBehaviorConverter
    : JsonConverter<EntitlementListResponseDataFeatureBehavior>
{
    public override EntitlementListResponseDataFeatureBehavior Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Increment" => EntitlementListResponseDataFeatureBehavior.Increment,
            "Override" => EntitlementListResponseDataFeatureBehavior.Override,
            _ => (EntitlementListResponseDataFeatureBehavior)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntitlementListResponseDataFeatureBehavior value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntitlementListResponseDataFeatureBehavior.Increment => "Increment",
                EntitlementListResponseDataFeatureBehavior.Override => "Override",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(EntitlementListResponseDataFeatureHiddenFromWidgetConverter))]
public enum EntitlementListResponseDataFeatureHiddenFromWidget
{
    Paywall,
    CustomerPortal,
    Checkout,
}

sealed class EntitlementListResponseDataFeatureHiddenFromWidgetConverter
    : JsonConverter<EntitlementListResponseDataFeatureHiddenFromWidget>
{
    public override EntitlementListResponseDataFeatureHiddenFromWidget Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PAYWALL" => EntitlementListResponseDataFeatureHiddenFromWidget.Paywall,
            "CUSTOMER_PORTAL" => EntitlementListResponseDataFeatureHiddenFromWidget.CustomerPortal,
            "CHECKOUT" => EntitlementListResponseDataFeatureHiddenFromWidget.Checkout,
            _ => (EntitlementListResponseDataFeatureHiddenFromWidget)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntitlementListResponseDataFeatureHiddenFromWidget value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntitlementListResponseDataFeatureHiddenFromWidget.Paywall => "PAYWALL",
                EntitlementListResponseDataFeatureHiddenFromWidget.CustomerPortal =>
                    "CUSTOMER_PORTAL",
                EntitlementListResponseDataFeatureHiddenFromWidget.Checkout => "CHECKOUT",
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
[JsonConverter(typeof(EntitlementListResponseDataFeatureResetPeriodConverter))]
public enum EntitlementListResponseDataFeatureResetPeriod
{
    Year,
    Month,
    Week,
    Day,
    Hour,
}

sealed class EntitlementListResponseDataFeatureResetPeriodConverter
    : JsonConverter<EntitlementListResponseDataFeatureResetPeriod>
{
    public override EntitlementListResponseDataFeatureResetPeriod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "YEAR" => EntitlementListResponseDataFeatureResetPeriod.Year,
            "MONTH" => EntitlementListResponseDataFeatureResetPeriod.Month,
            "WEEK" => EntitlementListResponseDataFeatureResetPeriod.Week,
            "DAY" => EntitlementListResponseDataFeatureResetPeriod.Day,
            "HOUR" => EntitlementListResponseDataFeatureResetPeriod.Hour,
            _ => (EntitlementListResponseDataFeatureResetPeriod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntitlementListResponseDataFeatureResetPeriod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntitlementListResponseDataFeatureResetPeriod.Year => "YEAR",
                EntitlementListResponseDataFeatureResetPeriod.Month => "MONTH",
                EntitlementListResponseDataFeatureResetPeriod.Week => "WEEK",
                EntitlementListResponseDataFeatureResetPeriod.Day => "DAY",
                EntitlementListResponseDataFeatureResetPeriod.Hour => "HOUR",
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
[JsonConverter(typeof(EntitlementListResponseDataFeatureResetPeriodConfigurationConverter))]
public record class EntitlementListResponseDataFeatureResetPeriodConfiguration : ModelBase
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

    public EntitlementListResponseDataFeatureResetPeriodConfiguration(
        EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EntitlementListResponseDataFeatureResetPeriodConfiguration(
        EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EntitlementListResponseDataFeatureResetPeriodConfiguration(
        EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EntitlementListResponseDataFeatureResetPeriodConfiguration(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickYearlyResetPeriodConfig(out var value)) {
    ///     // `value` is of type `EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickYearlyResetPeriodConfig(
        [NotNullWhen(true)]
            out EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig? value
    )
    {
        value =
            this.Value
            as EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMonthlyResetPeriodConfig(out var value)) {
    ///     // `value` is of type `EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMonthlyResetPeriodConfig(
        [NotNullWhen(true)]
            out EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig? value
    )
    {
        value =
            this.Value
            as EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickWeeklyResetPeriodConfig(out var value)) {
    ///     // `value` is of type `EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickWeeklyResetPeriodConfig(
        [NotNullWhen(true)]
            out EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig? value
    )
    {
        value =
            this.Value
            as EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig;
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
    ///     (EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig value) => {...},
    ///     (EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig value) => {...},
    ///     (EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig> yearlyResetPeriodConfig,
        System::Action<EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig> monthlyResetPeriodConfig,
        System::Action<EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig> weeklyResetPeriodConfig
    )
    {
        switch (this.Value)
        {
            case EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig value:
                yearlyResetPeriodConfig(value);
                break;
            case EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig value:
                monthlyResetPeriodConfig(value);
                break;
            case EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig value:
                weeklyResetPeriodConfig(value);
                break;
            default:
                throw new StiggInvalidDataException(
                    "Data did not match any variant of EntitlementListResponseDataFeatureResetPeriodConfiguration"
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
    ///     (EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig value) => {...},
    ///     (EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig value) => {...},
    ///     (EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<
            EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig,
            T
        > yearlyResetPeriodConfig,
        System::Func<
            EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig,
            T
        > monthlyResetPeriodConfig,
        System::Func<
            EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig,
            T
        > weeklyResetPeriodConfig
    )
    {
        return this.Value switch
        {
            EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig value =>
                yearlyResetPeriodConfig(value),
            EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig value =>
                monthlyResetPeriodConfig(value),
            EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig value =>
                weeklyResetPeriodConfig(value),
            _ => throw new StiggInvalidDataException(
                "Data did not match any variant of EntitlementListResponseDataFeatureResetPeriodConfiguration"
            ),
        };
    }

    public static implicit operator EntitlementListResponseDataFeatureResetPeriodConfiguration(
        EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig value
    ) => new(value);

    public static implicit operator EntitlementListResponseDataFeatureResetPeriodConfiguration(
        EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig value
    ) => new(value);

    public static implicit operator EntitlementListResponseDataFeatureResetPeriodConfiguration(
        EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig value
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
                "Data did not match any variant of EntitlementListResponseDataFeatureResetPeriodConfiguration"
            );
        }
        this.Switch(
            (yearlyResetPeriodConfig) => yearlyResetPeriodConfig.Validate(),
            (monthlyResetPeriodConfig) => monthlyResetPeriodConfig.Validate(),
            (weeklyResetPeriodConfig) => weeklyResetPeriodConfig.Validate()
        );
    }

    public virtual bool Equals(EntitlementListResponseDataFeatureResetPeriodConfiguration? other) =>
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
            EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig _ =>
                0,
            EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig _ =>
                1,
            EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig _ =>
                2,
            _ => -1,
        };
    }
}

sealed class EntitlementListResponseDataFeatureResetPeriodConfigurationConverter
    : JsonConverter<EntitlementListResponseDataFeatureResetPeriodConfiguration?>
{
    public override EntitlementListResponseDataFeatureResetPeriodConfiguration? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized =
                JsonSerializer.Deserialize<EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig>(
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
                JsonSerializer.Deserialize<EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig>(
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
                JsonSerializer.Deserialize<EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig>(
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
        EntitlementListResponseDataFeatureResetPeriodConfiguration? value,
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
        EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig,
        EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigFromRaw
    >)
)]
public sealed record class EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig
    : JsonModel
{
    /// <summary>
    /// Reset anchor (SubscriptionStart)
    /// </summary>
    public required ApiEnum<
        string,
        EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
    > AccordingTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
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

    public EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig(
        EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig entitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig
    )
        : base(entitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig)
    { }
#pragma warning restore CS8618

    public EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigFromRaw.FromRawUnchecked"/>
    public static EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig(
        ApiEnum<
            string,
            EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
        > accordingTo
    )
        : this()
    {
        this.AccordingTo = accordingTo;
    }
}

class EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigFromRaw
    : IFromRawJson<EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig>
{
    /// <inheritdoc/>
    public EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Reset anchor (SubscriptionStart)
/// </summary>
[JsonConverter(
    typeof(EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingToConverter)
)]
public enum EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
{
    SubscriptionStart,
}

sealed class EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingToConverter
    : JsonConverter<EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo>
{
    public override EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SubscriptionStart" =>
                EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart,
            _ =>
                (EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart =>
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
        EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig,
        EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigFromRaw
    >)
)]
public sealed record class EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig
    : JsonModel
{
    /// <summary>
    /// Reset anchor (SubscriptionStart or StartOfTheMonth)
    /// </summary>
    public required ApiEnum<
        string,
        EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
    > AccordingTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
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

    public EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig(
        EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig entitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig
    )
        : base(entitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig)
    { }
#pragma warning restore CS8618

    public EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigFromRaw.FromRawUnchecked"/>
    public static EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig(
        ApiEnum<
            string,
            EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
        > accordingTo
    )
        : this()
    {
        this.AccordingTo = accordingTo;
    }
}

class EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigFromRaw
    : IFromRawJson<EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig>
{
    /// <inheritdoc/>
    public EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Reset anchor (SubscriptionStart or StartOfTheMonth)
/// </summary>
[JsonConverter(
    typeof(EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingToConverter)
)]
public enum EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
{
    SubscriptionStart,
    StartOfTheMonth,
}

sealed class EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingToConverter
    : JsonConverter<EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo>
{
    public override EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SubscriptionStart" =>
                EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart,
            "StartOfTheMonth" =>
                EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.StartOfTheMonth,
            _ =>
                (EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart =>
                    "SubscriptionStart",
                EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.StartOfTheMonth =>
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
        EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig,
        EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigFromRaw
    >)
)]
public sealed record class EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig
    : JsonModel
{
    /// <summary>
    /// Reset anchor (SubscriptionStart or specific day)
    /// </summary>
    public required ApiEnum<
        string,
        EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
    > AccordingTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
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

    public EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig(
        EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig entitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig
    )
        : base(entitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig)
    { }
#pragma warning restore CS8618

    public EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigFromRaw.FromRawUnchecked"/>
    public static EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig(
        ApiEnum<
            string,
            EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
        > accordingTo
    )
        : this()
    {
        this.AccordingTo = accordingTo;
    }
}

class EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigFromRaw
    : IFromRawJson<EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig>
{
    /// <inheritdoc/>
    public EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Reset anchor (SubscriptionStart or specific day)
/// </summary>
[JsonConverter(
    typeof(EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingToConverter)
)]
public enum EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
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

sealed class EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingToConverter
    : JsonConverter<EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo>
{
    public override EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SubscriptionStart" =>
                EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart,
            "EverySunday" =>
                EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EverySunday,
            "EveryMonday" =>
                EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryMonday,
            "EveryTuesday" =>
                EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryTuesday,
            "EveryWednesday" =>
                EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryWednesday,
            "EveryThursday" =>
                EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryThursday,
            "EveryFriday" =>
                EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryFriday,
            "EverySaturday" =>
                EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EverySaturday,
            _ =>
                (EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart =>
                    "SubscriptionStart",
                EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EverySunday =>
                    "EverySunday",
                EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryMonday =>
                    "EveryMonday",
                EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryTuesday =>
                    "EveryTuesday",
                EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryWednesday =>
                    "EveryWednesday",
                EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryThursday =>
                    "EveryThursday",
                EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryFriday =>
                    "EveryFriday",
                EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EverySaturday =>
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
        EntitlementListResponseDataCredit,
        EntitlementListResponseDataCreditFromRaw
    >)
)]
public sealed record class EntitlementListResponseDataCredit : JsonModel
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
    public required ApiEnum<string, EntitlementListResponseDataCreditBehavior> Behavior
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, EntitlementListResponseDataCreditBehavior>
            >("behavior");
        }
        init { this._rawData.Set("behavior", value); }
    }

    /// <summary>
    /// Credit grant cadence (for credit entitlements)
    /// </summary>
    public required ApiEnum<string, EntitlementListResponseDataCreditCadence>? Cadence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, EntitlementListResponseDataCreditCadence>
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
        ApiEnum<string, EntitlementListResponseDataCreditHiddenFromWidget>
    > HiddenFromWidgets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<ApiEnum<string, EntitlementListResponseDataCreditHiddenFromWidget>>
            >("hiddenFromWidgets");
        }
        init
        {
            this._rawData.Set<
                ImmutableArray<ApiEnum<string, EntitlementListResponseDataCreditHiddenFromWidget>>
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

    public EntitlementListResponseDataCredit()
    {
        this.Type = JsonSerializer.SerializeToElement("CREDIT");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementListResponseDataCredit(
        EntitlementListResponseDataCredit entitlementListResponseDataCredit
    )
        : base(entitlementListResponseDataCredit) { }
#pragma warning restore CS8618

    public EntitlementListResponseDataCredit(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("CREDIT");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementListResponseDataCredit(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementListResponseDataCreditFromRaw.FromRawUnchecked"/>
    public static EntitlementListResponseDataCredit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntitlementListResponseDataCreditFromRaw : IFromRawJson<EntitlementListResponseDataCredit>
{
    /// <inheritdoc/>
    public EntitlementListResponseDataCredit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementListResponseDataCredit.FromRawUnchecked(rawData);
}

/// <summary>
/// Entitlement behavior (Increment or Override)
/// </summary>
[JsonConverter(typeof(EntitlementListResponseDataCreditBehaviorConverter))]
public enum EntitlementListResponseDataCreditBehavior
{
    Increment,
    Override,
}

sealed class EntitlementListResponseDataCreditBehaviorConverter
    : JsonConverter<EntitlementListResponseDataCreditBehavior>
{
    public override EntitlementListResponseDataCreditBehavior Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Increment" => EntitlementListResponseDataCreditBehavior.Increment,
            "Override" => EntitlementListResponseDataCreditBehavior.Override,
            _ => (EntitlementListResponseDataCreditBehavior)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntitlementListResponseDataCreditBehavior value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntitlementListResponseDataCreditBehavior.Increment => "Increment",
                EntitlementListResponseDataCreditBehavior.Override => "Override",
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
[JsonConverter(typeof(EntitlementListResponseDataCreditCadenceConverter))]
public enum EntitlementListResponseDataCreditCadence
{
    Month,
    Year,
}

sealed class EntitlementListResponseDataCreditCadenceConverter
    : JsonConverter<EntitlementListResponseDataCreditCadence>
{
    public override EntitlementListResponseDataCreditCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "MONTH" => EntitlementListResponseDataCreditCadence.Month,
            "YEAR" => EntitlementListResponseDataCreditCadence.Year,
            _ => (EntitlementListResponseDataCreditCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntitlementListResponseDataCreditCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntitlementListResponseDataCreditCadence.Month => "MONTH",
                EntitlementListResponseDataCreditCadence.Year => "YEAR",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(EntitlementListResponseDataCreditHiddenFromWidgetConverter))]
public enum EntitlementListResponseDataCreditHiddenFromWidget
{
    Paywall,
    CustomerPortal,
    Checkout,
}

sealed class EntitlementListResponseDataCreditHiddenFromWidgetConverter
    : JsonConverter<EntitlementListResponseDataCreditHiddenFromWidget>
{
    public override EntitlementListResponseDataCreditHiddenFromWidget Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PAYWALL" => EntitlementListResponseDataCreditHiddenFromWidget.Paywall,
            "CUSTOMER_PORTAL" => EntitlementListResponseDataCreditHiddenFromWidget.CustomerPortal,
            "CHECKOUT" => EntitlementListResponseDataCreditHiddenFromWidget.Checkout,
            _ => (EntitlementListResponseDataCreditHiddenFromWidget)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntitlementListResponseDataCreditHiddenFromWidget value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntitlementListResponseDataCreditHiddenFromWidget.Paywall => "PAYWALL",
                EntitlementListResponseDataCreditHiddenFromWidget.CustomerPortal =>
                    "CUSTOMER_PORTAL",
                EntitlementListResponseDataCreditHiddenFromWidget.Checkout => "CHECKOUT",
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
