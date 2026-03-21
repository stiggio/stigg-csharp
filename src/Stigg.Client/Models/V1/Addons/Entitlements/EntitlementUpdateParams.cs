using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using System = System;

namespace Stigg.Client.Models.V1.Addons.Entitlements;

/// <summary>
/// Updates an existing entitlement on a draft addon.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class EntitlementUpdateParams : ParamsBase
{
    public JsonElement RawBodyData { get; private init; }

    public required string AddonID { get; init; }

    public string? ID { get; init; }

    /// <summary>
    /// Request to update an addon entitlement
    /// </summary>
    public required Body Body
    {
        get { return WrappedJsonSerializer.GetNotNullClass<Body>(this.RawBodyData, "RawBodyData"); }
        init { this.RawBodyData = JsonSerializer.SerializeToElement(value); }
    }

    public EntitlementUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementUpdateParams(EntitlementUpdateParams entitlementUpdateParams)
        : base(entitlementUpdateParams)
    {
        this.AddonID = entitlementUpdateParams.AddonID;
        this.ID = entitlementUpdateParams.ID;

        this.RawBodyData = entitlementUpdateParams.RawBodyData;
    }
#pragma warning restore CS8618

    public EntitlementUpdateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        JsonElement rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.RawBodyData = rawBodyData;
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        JsonElement rawBodyData,
        string addonID,
        string id
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.RawBodyData = rawBodyData;
        this.AddonID = addonID;
        this.ID = id;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static EntitlementUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        JsonElement rawBodyData,
        string addonID,
        string id
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            rawBodyData,
            addonID,
            id
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["AddonID"] = JsonSerializer.SerializeToElement(this.AddonID),
                    ["ID"] = JsonSerializer.SerializeToElement(this.ID),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this.RawBodyData),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(EntitlementUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.AddonID.Equals(other.AddonID)
            && (this.ID?.Equals(other.ID) ?? other.ID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this.RawBodyData.Equals(other.RawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/api/v1/addons/{0}/entitlements/{1}", this.AddonID, this.ID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

/// <summary>
/// Request to update an addon entitlement
/// </summary>
[JsonConverter(typeof(BodyConverter))]
public record class Body : ModelBase
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

    public JsonElement Type
    {
        get { return Match(feature: (x) => x.Type, credit: (x) => x.Type); }
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

    public bool? IsGranted
    {
        get { return Match<bool?>(feature: (x) => x.IsGranted, credit: (x) => x.IsGranted); }
    }

    public double? Order
    {
        get { return Match<double?>(feature: (x) => x.Order, credit: (x) => x.Order); }
    }

    public Body(BodyFeature value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Body(BodyCredit value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Body(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BodyFeature"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFeature(out var value)) {
    ///     // `value` is of type `BodyFeature`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFeature([NotNullWhen(true)] out BodyFeature? value)
    {
        value = this.Value as BodyFeature;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BodyCredit"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCredit(out var value)) {
    ///     // `value` is of type `BodyCredit`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCredit([NotNullWhen(true)] out BodyCredit? value)
    {
        value = this.Value as BodyCredit;
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
    ///     (BodyFeature value) =&gt; {...},
    ///     (BodyCredit value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(System::Action<BodyFeature> feature, System::Action<BodyCredit> credit)
    {
        switch (this.Value)
        {
            case BodyFeature value:
                feature(value);
                break;
            case BodyCredit value:
                credit(value);
                break;
            default:
                throw new StiggInvalidDataException("Data did not match any variant of Body");
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
    ///     (BodyFeature value) =&gt; {...},
    ///     (BodyCredit value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(System::Func<BodyFeature, T> feature, System::Func<BodyCredit, T> credit)
    {
        return this.Value switch
        {
            BodyFeature value => feature(value),
            BodyCredit value => credit(value),
            _ => throw new StiggInvalidDataException("Data did not match any variant of Body"),
        };
    }

    public static implicit operator Body(BodyFeature value) => new(value);

    public static implicit operator Body(BodyCredit value) => new(value);

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
            throw new StiggInvalidDataException("Data did not match any variant of Body");
        }
        this.Switch((feature) => feature.Validate(), (credit) => credit.Validate());
    }

    public virtual bool Equals(Body? other) =>
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
            BodyFeature _ => 0,
            BodyCredit _ => 1,
            _ => -1,
        };
    }
}

sealed class BodyConverter : JsonConverter<Body>
{
    public override Body? Read(
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
                    var deserialized = JsonSerializer.Deserialize<BodyFeature>(element, options);
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
                    var deserialized = JsonSerializer.Deserialize<BodyCredit>(element, options);
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
                return new Body(element);
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Body value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Fields to update on a feature entitlement
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BodyFeature, BodyFeatureFromRaw>))]
public sealed record class BodyFeature : JsonModel
{
    /// <summary>
    /// UpdateFeatureEntitlementRequest
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
    /// Entitlement behavior (Increment or Override)
    /// </summary>
    public ApiEnum<string, BodyFeatureBehavior>? Behavior
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, BodyFeatureBehavior>>("behavior");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("behavior", value);
        }
    }

    /// <summary>
    /// Description of the entitlement
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    /// <summary>
    /// Override display name for the entitlement
    /// </summary>
    public string? DisplayNameOverride
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("displayNameOverride");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("displayNameOverride", value);
        }
    }

    /// <summary>
    /// Allowed enum values for the feature entitlement
    /// </summary>
    public IReadOnlyList<string>? EnumValues
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("enumValues");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "enumValues",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Whether the usage limit is a soft limit
    /// </summary>
    public bool? HasSoftLimit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("hasSoftLimit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("hasSoftLimit", value);
        }
    }

    /// <summary>
    /// Whether usage is unlimited
    /// </summary>
    public bool? HasUnlimitedUsage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("hasUnlimitedUsage");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("hasUnlimitedUsage", value);
        }
    }

    /// <summary>
    /// Widget types where this entitlement is hidden
    /// </summary>
    public IReadOnlyList<ApiEnum<string, BodyFeatureHiddenFromWidget>>? HiddenFromWidgets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, BodyFeatureHiddenFromWidget>>
            >("hiddenFromWidgets");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ApiEnum<string, BodyFeatureHiddenFromWidget>>?>(
                "hiddenFromWidgets",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Whether this is a custom entitlement
    /// </summary>
    public bool? IsCustom
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isCustom");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isCustom", value);
        }
    }

    /// <summary>
    /// Whether the entitlement is granted
    /// </summary>
    public bool? IsGranted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isGranted");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isGranted", value);
        }
    }

    /// <summary>
    /// Configuration for monthly reset period
    /// </summary>
    public BodyFeatureMonthlyResetPeriodConfiguration? MonthlyResetPeriodConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BodyFeatureMonthlyResetPeriodConfiguration>(
                "monthlyResetPeriodConfiguration"
            );
        }
        init { this._rawData.Set("monthlyResetPeriodConfiguration", value); }
    }

    /// <summary>
    /// Display order of the entitlement
    /// </summary>
    public double? Order
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("order");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("order", value);
        }
    }

    /// <summary>
    /// Period at which usage resets
    /// </summary>
    public ApiEnum<string, BodyFeatureResetPeriod>? ResetPeriod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, BodyFeatureResetPeriod>>(
                "resetPeriod"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("resetPeriod", value);
        }
    }

    /// <summary>
    /// Maximum allowed usage for the feature
    /// </summary>
    public long? UsageLimit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("usageLimit");
        }
        init { this._rawData.Set("usageLimit", value); }
    }

    /// <summary>
    /// Configuration for weekly reset period
    /// </summary>
    public BodyFeatureWeeklyResetPeriodConfiguration? WeeklyResetPeriodConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BodyFeatureWeeklyResetPeriodConfiguration>(
                "weeklyResetPeriodConfiguration"
            );
        }
        init { this._rawData.Set("weeklyResetPeriodConfiguration", value); }
    }

    /// <summary>
    /// Configuration for yearly reset period
    /// </summary>
    public BodyFeatureYearlyResetPeriodConfiguration? YearlyResetPeriodConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BodyFeatureYearlyResetPeriodConfiguration>(
                "yearlyResetPeriodConfiguration"
            );
        }
        init { this._rawData.Set("yearlyResetPeriodConfiguration", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("FEATURE")))
        {
            throw new StiggInvalidDataException("Invalid value given for constant");
        }
        this.Behavior?.Validate();
        _ = this.Description;
        _ = this.DisplayNameOverride;
        _ = this.EnumValues;
        _ = this.HasSoftLimit;
        _ = this.HasUnlimitedUsage;
        foreach (var item in this.HiddenFromWidgets ?? [])
        {
            item.Validate();
        }
        _ = this.IsCustom;
        _ = this.IsGranted;
        this.MonthlyResetPeriodConfiguration?.Validate();
        _ = this.Order;
        this.ResetPeriod?.Validate();
        _ = this.UsageLimit;
        this.WeeklyResetPeriodConfiguration?.Validate();
        this.YearlyResetPeriodConfiguration?.Validate();
    }

    public BodyFeature()
    {
        this.Type = JsonSerializer.SerializeToElement("FEATURE");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BodyFeature(BodyFeature bodyFeature)
        : base(bodyFeature) { }
#pragma warning restore CS8618

    public BodyFeature(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("FEATURE");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BodyFeature(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BodyFeatureFromRaw.FromRawUnchecked"/>
    public static BodyFeature FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BodyFeatureFromRaw : IFromRawJson<BodyFeature>
{
    /// <inheritdoc/>
    public BodyFeature FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BodyFeature.FromRawUnchecked(rawData);
}

/// <summary>
/// Entitlement behavior (Increment or Override)
/// </summary>
[JsonConverter(typeof(BodyFeatureBehaviorConverter))]
public enum BodyFeatureBehavior
{
    Increment,
    Override,
}

sealed class BodyFeatureBehaviorConverter : JsonConverter<BodyFeatureBehavior>
{
    public override BodyFeatureBehavior Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Increment" => BodyFeatureBehavior.Increment,
            "Override" => BodyFeatureBehavior.Override,
            _ => (BodyFeatureBehavior)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BodyFeatureBehavior value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BodyFeatureBehavior.Increment => "Increment",
                BodyFeatureBehavior.Override => "Override",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(BodyFeatureHiddenFromWidgetConverter))]
public enum BodyFeatureHiddenFromWidget
{
    Paywall,
    CustomerPortal,
    Checkout,
}

sealed class BodyFeatureHiddenFromWidgetConverter : JsonConverter<BodyFeatureHiddenFromWidget>
{
    public override BodyFeatureHiddenFromWidget Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PAYWALL" => BodyFeatureHiddenFromWidget.Paywall,
            "CUSTOMER_PORTAL" => BodyFeatureHiddenFromWidget.CustomerPortal,
            "CHECKOUT" => BodyFeatureHiddenFromWidget.Checkout,
            _ => (BodyFeatureHiddenFromWidget)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BodyFeatureHiddenFromWidget value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BodyFeatureHiddenFromWidget.Paywall => "PAYWALL",
                BodyFeatureHiddenFromWidget.CustomerPortal => "CUSTOMER_PORTAL",
                BodyFeatureHiddenFromWidget.Checkout => "CHECKOUT",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Configuration for monthly reset period
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BodyFeatureMonthlyResetPeriodConfiguration,
        BodyFeatureMonthlyResetPeriodConfigurationFromRaw
    >)
)]
public sealed record class BodyFeatureMonthlyResetPeriodConfiguration : JsonModel
{
    /// <summary>
    /// Reset anchor (SubscriptionStart or StartOfTheMonth)
    /// </summary>
    public required ApiEnum<
        string,
        BodyFeatureMonthlyResetPeriodConfigurationAccordingTo
    > AccordingTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BodyFeatureMonthlyResetPeriodConfigurationAccordingTo>
            >("accordingTo");
        }
        init { this._rawData.Set("accordingTo", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.AccordingTo.Validate();
    }

    public BodyFeatureMonthlyResetPeriodConfiguration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BodyFeatureMonthlyResetPeriodConfiguration(
        BodyFeatureMonthlyResetPeriodConfiguration bodyFeatureMonthlyResetPeriodConfiguration
    )
        : base(bodyFeatureMonthlyResetPeriodConfiguration) { }
#pragma warning restore CS8618

    public BodyFeatureMonthlyResetPeriodConfiguration(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BodyFeatureMonthlyResetPeriodConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BodyFeatureMonthlyResetPeriodConfigurationFromRaw.FromRawUnchecked"/>
    public static BodyFeatureMonthlyResetPeriodConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BodyFeatureMonthlyResetPeriodConfiguration(
        ApiEnum<string, BodyFeatureMonthlyResetPeriodConfigurationAccordingTo> accordingTo
    )
        : this()
    {
        this.AccordingTo = accordingTo;
    }
}

class BodyFeatureMonthlyResetPeriodConfigurationFromRaw
    : IFromRawJson<BodyFeatureMonthlyResetPeriodConfiguration>
{
    /// <inheritdoc/>
    public BodyFeatureMonthlyResetPeriodConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BodyFeatureMonthlyResetPeriodConfiguration.FromRawUnchecked(rawData);
}

/// <summary>
/// Reset anchor (SubscriptionStart or StartOfTheMonth)
/// </summary>
[JsonConverter(typeof(BodyFeatureMonthlyResetPeriodConfigurationAccordingToConverter))]
public enum BodyFeatureMonthlyResetPeriodConfigurationAccordingTo
{
    SubscriptionStart,
    StartOfTheMonth,
}

sealed class BodyFeatureMonthlyResetPeriodConfigurationAccordingToConverter
    : JsonConverter<BodyFeatureMonthlyResetPeriodConfigurationAccordingTo>
{
    public override BodyFeatureMonthlyResetPeriodConfigurationAccordingTo Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SubscriptionStart" =>
                BodyFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
            "StartOfTheMonth" =>
                BodyFeatureMonthlyResetPeriodConfigurationAccordingTo.StartOfTheMonth,
            _ => (BodyFeatureMonthlyResetPeriodConfigurationAccordingTo)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BodyFeatureMonthlyResetPeriodConfigurationAccordingTo value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BodyFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart =>
                    "SubscriptionStart",
                BodyFeatureMonthlyResetPeriodConfigurationAccordingTo.StartOfTheMonth =>
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
/// Period at which usage resets
/// </summary>
[JsonConverter(typeof(BodyFeatureResetPeriodConverter))]
public enum BodyFeatureResetPeriod
{
    Year,
    Month,
    Week,
    Day,
    Hour,
}

sealed class BodyFeatureResetPeriodConverter : JsonConverter<BodyFeatureResetPeriod>
{
    public override BodyFeatureResetPeriod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "YEAR" => BodyFeatureResetPeriod.Year,
            "MONTH" => BodyFeatureResetPeriod.Month,
            "WEEK" => BodyFeatureResetPeriod.Week,
            "DAY" => BodyFeatureResetPeriod.Day,
            "HOUR" => BodyFeatureResetPeriod.Hour,
            _ => (BodyFeatureResetPeriod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BodyFeatureResetPeriod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BodyFeatureResetPeriod.Year => "YEAR",
                BodyFeatureResetPeriod.Month => "MONTH",
                BodyFeatureResetPeriod.Week => "WEEK",
                BodyFeatureResetPeriod.Day => "DAY",
                BodyFeatureResetPeriod.Hour => "HOUR",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Configuration for weekly reset period
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BodyFeatureWeeklyResetPeriodConfiguration,
        BodyFeatureWeeklyResetPeriodConfigurationFromRaw
    >)
)]
public sealed record class BodyFeatureWeeklyResetPeriodConfiguration : JsonModel
{
    /// <summary>
    /// Reset anchor (SubscriptionStart or specific day)
    /// </summary>
    public required ApiEnum<
        string,
        BodyFeatureWeeklyResetPeriodConfigurationAccordingTo
    > AccordingTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BodyFeatureWeeklyResetPeriodConfigurationAccordingTo>
            >("accordingTo");
        }
        init { this._rawData.Set("accordingTo", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.AccordingTo.Validate();
    }

    public BodyFeatureWeeklyResetPeriodConfiguration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BodyFeatureWeeklyResetPeriodConfiguration(
        BodyFeatureWeeklyResetPeriodConfiguration bodyFeatureWeeklyResetPeriodConfiguration
    )
        : base(bodyFeatureWeeklyResetPeriodConfiguration) { }
#pragma warning restore CS8618

    public BodyFeatureWeeklyResetPeriodConfiguration(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BodyFeatureWeeklyResetPeriodConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BodyFeatureWeeklyResetPeriodConfigurationFromRaw.FromRawUnchecked"/>
    public static BodyFeatureWeeklyResetPeriodConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BodyFeatureWeeklyResetPeriodConfiguration(
        ApiEnum<string, BodyFeatureWeeklyResetPeriodConfigurationAccordingTo> accordingTo
    )
        : this()
    {
        this.AccordingTo = accordingTo;
    }
}

class BodyFeatureWeeklyResetPeriodConfigurationFromRaw
    : IFromRawJson<BodyFeatureWeeklyResetPeriodConfiguration>
{
    /// <inheritdoc/>
    public BodyFeatureWeeklyResetPeriodConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BodyFeatureWeeklyResetPeriodConfiguration.FromRawUnchecked(rawData);
}

/// <summary>
/// Reset anchor (SubscriptionStart or specific day)
/// </summary>
[JsonConverter(typeof(BodyFeatureWeeklyResetPeriodConfigurationAccordingToConverter))]
public enum BodyFeatureWeeklyResetPeriodConfigurationAccordingTo
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

sealed class BodyFeatureWeeklyResetPeriodConfigurationAccordingToConverter
    : JsonConverter<BodyFeatureWeeklyResetPeriodConfigurationAccordingTo>
{
    public override BodyFeatureWeeklyResetPeriodConfigurationAccordingTo Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SubscriptionStart" =>
                BodyFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart,
            "EverySunday" => BodyFeatureWeeklyResetPeriodConfigurationAccordingTo.EverySunday,
            "EveryMonday" => BodyFeatureWeeklyResetPeriodConfigurationAccordingTo.EveryMonday,
            "EveryTuesday" => BodyFeatureWeeklyResetPeriodConfigurationAccordingTo.EveryTuesday,
            "EveryWednesday" => BodyFeatureWeeklyResetPeriodConfigurationAccordingTo.EveryWednesday,
            "EveryThursday" => BodyFeatureWeeklyResetPeriodConfigurationAccordingTo.EveryThursday,
            "EveryFriday" => BodyFeatureWeeklyResetPeriodConfigurationAccordingTo.EveryFriday,
            "EverySaturday" => BodyFeatureWeeklyResetPeriodConfigurationAccordingTo.EverySaturday,
            _ => (BodyFeatureWeeklyResetPeriodConfigurationAccordingTo)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BodyFeatureWeeklyResetPeriodConfigurationAccordingTo value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BodyFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart =>
                    "SubscriptionStart",
                BodyFeatureWeeklyResetPeriodConfigurationAccordingTo.EverySunday => "EverySunday",
                BodyFeatureWeeklyResetPeriodConfigurationAccordingTo.EveryMonday => "EveryMonday",
                BodyFeatureWeeklyResetPeriodConfigurationAccordingTo.EveryTuesday => "EveryTuesday",
                BodyFeatureWeeklyResetPeriodConfigurationAccordingTo.EveryWednesday =>
                    "EveryWednesday",
                BodyFeatureWeeklyResetPeriodConfigurationAccordingTo.EveryThursday =>
                    "EveryThursday",
                BodyFeatureWeeklyResetPeriodConfigurationAccordingTo.EveryFriday => "EveryFriday",
                BodyFeatureWeeklyResetPeriodConfigurationAccordingTo.EverySaturday =>
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
/// Configuration for yearly reset period
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BodyFeatureYearlyResetPeriodConfiguration,
        BodyFeatureYearlyResetPeriodConfigurationFromRaw
    >)
)]
public sealed record class BodyFeatureYearlyResetPeriodConfiguration : JsonModel
{
    /// <summary>
    /// Reset anchor (SubscriptionStart)
    /// </summary>
    public required ApiEnum<
        string,
        BodyFeatureYearlyResetPeriodConfigurationAccordingTo
    > AccordingTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BodyFeatureYearlyResetPeriodConfigurationAccordingTo>
            >("accordingTo");
        }
        init { this._rawData.Set("accordingTo", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.AccordingTo.Validate();
    }

    public BodyFeatureYearlyResetPeriodConfiguration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BodyFeatureYearlyResetPeriodConfiguration(
        BodyFeatureYearlyResetPeriodConfiguration bodyFeatureYearlyResetPeriodConfiguration
    )
        : base(bodyFeatureYearlyResetPeriodConfiguration) { }
#pragma warning restore CS8618

    public BodyFeatureYearlyResetPeriodConfiguration(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BodyFeatureYearlyResetPeriodConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BodyFeatureYearlyResetPeriodConfigurationFromRaw.FromRawUnchecked"/>
    public static BodyFeatureYearlyResetPeriodConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BodyFeatureYearlyResetPeriodConfiguration(
        ApiEnum<string, BodyFeatureYearlyResetPeriodConfigurationAccordingTo> accordingTo
    )
        : this()
    {
        this.AccordingTo = accordingTo;
    }
}

class BodyFeatureYearlyResetPeriodConfigurationFromRaw
    : IFromRawJson<BodyFeatureYearlyResetPeriodConfiguration>
{
    /// <inheritdoc/>
    public BodyFeatureYearlyResetPeriodConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BodyFeatureYearlyResetPeriodConfiguration.FromRawUnchecked(rawData);
}

/// <summary>
/// Reset anchor (SubscriptionStart)
/// </summary>
[JsonConverter(typeof(BodyFeatureYearlyResetPeriodConfigurationAccordingToConverter))]
public enum BodyFeatureYearlyResetPeriodConfigurationAccordingTo
{
    SubscriptionStart,
}

sealed class BodyFeatureYearlyResetPeriodConfigurationAccordingToConverter
    : JsonConverter<BodyFeatureYearlyResetPeriodConfigurationAccordingTo>
{
    public override BodyFeatureYearlyResetPeriodConfigurationAccordingTo Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SubscriptionStart" =>
                BodyFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
            _ => (BodyFeatureYearlyResetPeriodConfigurationAccordingTo)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BodyFeatureYearlyResetPeriodConfigurationAccordingTo value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BodyFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart =>
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
/// Fields to update on a credit entitlement
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BodyCredit, BodyCreditFromRaw>))]
public sealed record class BodyCredit : JsonModel
{
    /// <summary>
    /// UpdateCreditEntitlementRequest
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
    /// Credit grant amount
    /// </summary>
    public double? Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("amount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("amount", value);
        }
    }

    /// <summary>
    /// Entitlement behavior (Increment or Override)
    /// </summary>
    public ApiEnum<string, BodyCreditBehavior>? Behavior
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, BodyCreditBehavior>>("behavior");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("behavior", value);
        }
    }

    /// <summary>
    /// Credit grant cadence (MONTH or YEAR)
    /// </summary>
    public ApiEnum<string, BodyCreditCadence>? Cadence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, BodyCreditCadence>>("cadence");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("cadence", value);
        }
    }

    /// <summary>
    /// The feature ID this entitlement depends on. The entitlement value will be
    /// calculated as: base amount × dependency feature usage limit
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

    /// <summary>
    /// Description of the entitlement
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    /// <summary>
    /// Override display name for the entitlement
    /// </summary>
    public string? DisplayNameOverride
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("displayNameOverride");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("displayNameOverride", value);
        }
    }

    /// <summary>
    /// Widget types where this entitlement is hidden
    /// </summary>
    public IReadOnlyList<ApiEnum<string, BodyCreditHiddenFromWidget>>? HiddenFromWidgets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, BodyCreditHiddenFromWidget>>
            >("hiddenFromWidgets");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ApiEnum<string, BodyCreditHiddenFromWidget>>?>(
                "hiddenFromWidgets",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Whether this is a custom entitlement
    /// </summary>
    public bool? IsCustom
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isCustom");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isCustom", value);
        }
    }

    /// <summary>
    /// Whether the entitlement is granted
    /// </summary>
    public bool? IsGranted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isGranted");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isGranted", value);
        }
    }

    /// <summary>
    /// Display order of the entitlement
    /// </summary>
    public double? Order
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("order");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("order", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("CREDIT")))
        {
            throw new StiggInvalidDataException("Invalid value given for constant");
        }
        _ = this.Amount;
        this.Behavior?.Validate();
        this.Cadence?.Validate();
        _ = this.DependencyFeatureID;
        _ = this.Description;
        _ = this.DisplayNameOverride;
        foreach (var item in this.HiddenFromWidgets ?? [])
        {
            item.Validate();
        }
        _ = this.IsCustom;
        _ = this.IsGranted;
        _ = this.Order;
    }

    public BodyCredit()
    {
        this.Type = JsonSerializer.SerializeToElement("CREDIT");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BodyCredit(BodyCredit bodyCredit)
        : base(bodyCredit) { }
#pragma warning restore CS8618

    public BodyCredit(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("CREDIT");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BodyCredit(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BodyCreditFromRaw.FromRawUnchecked"/>
    public static BodyCredit FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BodyCreditFromRaw : IFromRawJson<BodyCredit>
{
    /// <inheritdoc/>
    public BodyCredit FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BodyCredit.FromRawUnchecked(rawData);
}

/// <summary>
/// Entitlement behavior (Increment or Override)
/// </summary>
[JsonConverter(typeof(BodyCreditBehaviorConverter))]
public enum BodyCreditBehavior
{
    Increment,
    Override,
}

sealed class BodyCreditBehaviorConverter : JsonConverter<BodyCreditBehavior>
{
    public override BodyCreditBehavior Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Increment" => BodyCreditBehavior.Increment,
            "Override" => BodyCreditBehavior.Override,
            _ => (BodyCreditBehavior)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BodyCreditBehavior value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BodyCreditBehavior.Increment => "Increment",
                BodyCreditBehavior.Override => "Override",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Credit grant cadence (MONTH or YEAR)
/// </summary>
[JsonConverter(typeof(BodyCreditCadenceConverter))]
public enum BodyCreditCadence
{
    Month,
    Year,
}

sealed class BodyCreditCadenceConverter : JsonConverter<BodyCreditCadence>
{
    public override BodyCreditCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "MONTH" => BodyCreditCadence.Month,
            "YEAR" => BodyCreditCadence.Year,
            _ => (BodyCreditCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BodyCreditCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BodyCreditCadence.Month => "MONTH",
                BodyCreditCadence.Year => "YEAR",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(BodyCreditHiddenFromWidgetConverter))]
public enum BodyCreditHiddenFromWidget
{
    Paywall,
    CustomerPortal,
    Checkout,
}

sealed class BodyCreditHiddenFromWidgetConverter : JsonConverter<BodyCreditHiddenFromWidget>
{
    public override BodyCreditHiddenFromWidget Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PAYWALL" => BodyCreditHiddenFromWidget.Paywall,
            "CUSTOMER_PORTAL" => BodyCreditHiddenFromWidget.CustomerPortal,
            "CHECKOUT" => BodyCreditHiddenFromWidget.Checkout,
            _ => (BodyCreditHiddenFromWidget)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BodyCreditHiddenFromWidget value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BodyCreditHiddenFromWidget.Paywall => "PAYWALL",
                BodyCreditHiddenFromWidget.CustomerPortal => "CUSTOMER_PORTAL",
                BodyCreditHiddenFromWidget.Checkout => "CHECKOUT",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
