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

namespace Stigg.Client.Models.V1.Events.Plans.Entitlements;

/// <summary>
/// Updates an existing entitlement on a draft plan.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class EntitlementUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public required string PlanID { get; init; }

    public string? ID { get; init; }

    /// <summary>
    /// Credit entitlement fields to update
    /// </summary>
    public EntitlementUpdateParamsCredit? Credit
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<EntitlementUpdateParamsCredit>("credit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("credit", value);
        }
    }

    /// <summary>
    /// Feature entitlement fields to update
    /// </summary>
    public EntitlementUpdateParamsFeature? Feature
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<EntitlementUpdateParamsFeature>("feature");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("feature", value);
        }
    }

    public EntitlementUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementUpdateParams(EntitlementUpdateParams entitlementUpdateParams)
        : base(entitlementUpdateParams)
    {
        this.PlanID = entitlementUpdateParams.PlanID;
        this.ID = entitlementUpdateParams.ID;

        this._rawBodyData = new(entitlementUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public EntitlementUpdateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static EntitlementUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["PlanID"] = JsonSerializer.SerializeToElement(this.PlanID),
                    ["ID"] = JsonSerializer.SerializeToElement(this.ID),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
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
        return this.PlanID.Equals(other.PlanID)
            && (this.ID?.Equals(other.ID) ?? other.ID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/api/v1/plans/{0}/entitlements/{1}", this.PlanID, this.ID)
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
/// Credit entitlement fields to update
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<EntitlementUpdateParamsCredit, EntitlementUpdateParamsCreditFromRaw>)
)]
public sealed record class EntitlementUpdateParamsCredit : JsonModel
{
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
    public ApiEnum<string, EntitlementUpdateParamsCreditBehavior>? Behavior
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, EntitlementUpdateParamsCreditBehavior>
            >("behavior");
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
    public ApiEnum<string, EntitlementUpdateParamsCreditCadence>? Cadence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, EntitlementUpdateParamsCreditCadence>
            >("cadence");
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
    public IReadOnlyList<
        ApiEnum<string, EntitlementUpdateParamsCreditHiddenFromWidget>
    >? HiddenFromWidgets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, EntitlementUpdateParamsCreditHiddenFromWidget>>
            >("hiddenFromWidgets");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<
                ApiEnum<string, EntitlementUpdateParamsCreditHiddenFromWidget>
            >?>("hiddenFromWidgets", value == null ? null : ImmutableArray.ToImmutableArray(value));
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
        _ = this.Amount;
        this.Behavior?.Validate();
        this.Cadence?.Validate();
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

    public EntitlementUpdateParamsCredit() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementUpdateParamsCredit(
        EntitlementUpdateParamsCredit entitlementUpdateParamsCredit
    )
        : base(entitlementUpdateParamsCredit) { }
#pragma warning restore CS8618

    public EntitlementUpdateParamsCredit(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementUpdateParamsCredit(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementUpdateParamsCreditFromRaw.FromRawUnchecked"/>
    public static EntitlementUpdateParamsCredit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntitlementUpdateParamsCreditFromRaw : IFromRawJson<EntitlementUpdateParamsCredit>
{
    /// <inheritdoc/>
    public EntitlementUpdateParamsCredit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementUpdateParamsCredit.FromRawUnchecked(rawData);
}

/// <summary>
/// Entitlement behavior (Increment or Override)
/// </summary>
[JsonConverter(typeof(EntitlementUpdateParamsCreditBehaviorConverter))]
public enum EntitlementUpdateParamsCreditBehavior
{
    Increment,
    Override,
}

sealed class EntitlementUpdateParamsCreditBehaviorConverter
    : JsonConverter<EntitlementUpdateParamsCreditBehavior>
{
    public override EntitlementUpdateParamsCreditBehavior Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Increment" => EntitlementUpdateParamsCreditBehavior.Increment,
            "Override" => EntitlementUpdateParamsCreditBehavior.Override,
            _ => (EntitlementUpdateParamsCreditBehavior)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntitlementUpdateParamsCreditBehavior value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntitlementUpdateParamsCreditBehavior.Increment => "Increment",
                EntitlementUpdateParamsCreditBehavior.Override => "Override",
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
[JsonConverter(typeof(EntitlementUpdateParamsCreditCadenceConverter))]
public enum EntitlementUpdateParamsCreditCadence
{
    Month,
    Year,
}

sealed class EntitlementUpdateParamsCreditCadenceConverter
    : JsonConverter<EntitlementUpdateParamsCreditCadence>
{
    public override EntitlementUpdateParamsCreditCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "MONTH" => EntitlementUpdateParamsCreditCadence.Month,
            "YEAR" => EntitlementUpdateParamsCreditCadence.Year,
            _ => (EntitlementUpdateParamsCreditCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntitlementUpdateParamsCreditCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntitlementUpdateParamsCreditCadence.Month => "MONTH",
                EntitlementUpdateParamsCreditCadence.Year => "YEAR",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(EntitlementUpdateParamsCreditHiddenFromWidgetConverter))]
public enum EntitlementUpdateParamsCreditHiddenFromWidget
{
    Paywall,
    CustomerPortal,
    Checkout,
}

sealed class EntitlementUpdateParamsCreditHiddenFromWidgetConverter
    : JsonConverter<EntitlementUpdateParamsCreditHiddenFromWidget>
{
    public override EntitlementUpdateParamsCreditHiddenFromWidget Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PAYWALL" => EntitlementUpdateParamsCreditHiddenFromWidget.Paywall,
            "CUSTOMER_PORTAL" => EntitlementUpdateParamsCreditHiddenFromWidget.CustomerPortal,
            "CHECKOUT" => EntitlementUpdateParamsCreditHiddenFromWidget.Checkout,
            _ => (EntitlementUpdateParamsCreditHiddenFromWidget)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntitlementUpdateParamsCreditHiddenFromWidget value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntitlementUpdateParamsCreditHiddenFromWidget.Paywall => "PAYWALL",
                EntitlementUpdateParamsCreditHiddenFromWidget.CustomerPortal => "CUSTOMER_PORTAL",
                EntitlementUpdateParamsCreditHiddenFromWidget.Checkout => "CHECKOUT",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Feature entitlement fields to update
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        EntitlementUpdateParamsFeature,
        EntitlementUpdateParamsFeatureFromRaw
    >)
)]
public sealed record class EntitlementUpdateParamsFeature : JsonModel
{
    /// <summary>
    /// Entitlement behavior (Increment or Override)
    /// </summary>
    public ApiEnum<string, EntitlementUpdateParamsFeatureBehavior>? Behavior
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, EntitlementUpdateParamsFeatureBehavior>
            >("behavior");
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
    public IReadOnlyList<
        ApiEnum<string, EntitlementUpdateParamsFeatureHiddenFromWidget>
    >? HiddenFromWidgets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, EntitlementUpdateParamsFeatureHiddenFromWidget>>
            >("hiddenFromWidgets");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<
                ApiEnum<string, EntitlementUpdateParamsFeatureHiddenFromWidget>
            >?>("hiddenFromWidgets", value == null ? null : ImmutableArray.ToImmutableArray(value));
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
    public EntitlementUpdateParamsFeatureMonthlyResetPeriodConfiguration? MonthlyResetPeriodConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EntitlementUpdateParamsFeatureMonthlyResetPeriodConfiguration>(
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
    public ApiEnum<string, EntitlementUpdateParamsFeatureResetPeriod>? ResetPeriod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, EntitlementUpdateParamsFeatureResetPeriod>
            >("resetPeriod");
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
    public EntitlementUpdateParamsFeatureWeeklyResetPeriodConfiguration? WeeklyResetPeriodConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EntitlementUpdateParamsFeatureWeeklyResetPeriodConfiguration>(
                "weeklyResetPeriodConfiguration"
            );
        }
        init { this._rawData.Set("weeklyResetPeriodConfiguration", value); }
    }

    /// <summary>
    /// Configuration for yearly reset period
    /// </summary>
    public EntitlementUpdateParamsFeatureYearlyResetPeriodConfiguration? YearlyResetPeriodConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EntitlementUpdateParamsFeatureYearlyResetPeriodConfiguration>(
                "yearlyResetPeriodConfiguration"
            );
        }
        init { this._rawData.Set("yearlyResetPeriodConfiguration", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
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

    public EntitlementUpdateParamsFeature() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementUpdateParamsFeature(
        EntitlementUpdateParamsFeature entitlementUpdateParamsFeature
    )
        : base(entitlementUpdateParamsFeature) { }
#pragma warning restore CS8618

    public EntitlementUpdateParamsFeature(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementUpdateParamsFeature(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementUpdateParamsFeatureFromRaw.FromRawUnchecked"/>
    public static EntitlementUpdateParamsFeature FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntitlementUpdateParamsFeatureFromRaw : IFromRawJson<EntitlementUpdateParamsFeature>
{
    /// <inheritdoc/>
    public EntitlementUpdateParamsFeature FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementUpdateParamsFeature.FromRawUnchecked(rawData);
}

/// <summary>
/// Entitlement behavior (Increment or Override)
/// </summary>
[JsonConverter(typeof(EntitlementUpdateParamsFeatureBehaviorConverter))]
public enum EntitlementUpdateParamsFeatureBehavior
{
    Increment,
    Override,
}

sealed class EntitlementUpdateParamsFeatureBehaviorConverter
    : JsonConverter<EntitlementUpdateParamsFeatureBehavior>
{
    public override EntitlementUpdateParamsFeatureBehavior Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Increment" => EntitlementUpdateParamsFeatureBehavior.Increment,
            "Override" => EntitlementUpdateParamsFeatureBehavior.Override,
            _ => (EntitlementUpdateParamsFeatureBehavior)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntitlementUpdateParamsFeatureBehavior value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntitlementUpdateParamsFeatureBehavior.Increment => "Increment",
                EntitlementUpdateParamsFeatureBehavior.Override => "Override",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(EntitlementUpdateParamsFeatureHiddenFromWidgetConverter))]
public enum EntitlementUpdateParamsFeatureHiddenFromWidget
{
    Paywall,
    CustomerPortal,
    Checkout,
}

sealed class EntitlementUpdateParamsFeatureHiddenFromWidgetConverter
    : JsonConverter<EntitlementUpdateParamsFeatureHiddenFromWidget>
{
    public override EntitlementUpdateParamsFeatureHiddenFromWidget Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PAYWALL" => EntitlementUpdateParamsFeatureHiddenFromWidget.Paywall,
            "CUSTOMER_PORTAL" => EntitlementUpdateParamsFeatureHiddenFromWidget.CustomerPortal,
            "CHECKOUT" => EntitlementUpdateParamsFeatureHiddenFromWidget.Checkout,
            _ => (EntitlementUpdateParamsFeatureHiddenFromWidget)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntitlementUpdateParamsFeatureHiddenFromWidget value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntitlementUpdateParamsFeatureHiddenFromWidget.Paywall => "PAYWALL",
                EntitlementUpdateParamsFeatureHiddenFromWidget.CustomerPortal => "CUSTOMER_PORTAL",
                EntitlementUpdateParamsFeatureHiddenFromWidget.Checkout => "CHECKOUT",
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
        EntitlementUpdateParamsFeatureMonthlyResetPeriodConfiguration,
        EntitlementUpdateParamsFeatureMonthlyResetPeriodConfigurationFromRaw
    >)
)]
public sealed record class EntitlementUpdateParamsFeatureMonthlyResetPeriodConfiguration : JsonModel
{
    /// <summary>
    /// Reset anchor (SubscriptionStart or StartOfTheMonth)
    /// </summary>
    public required ApiEnum<
        string,
        EntitlementUpdateParamsFeatureMonthlyResetPeriodConfigurationAccordingTo
    > AccordingTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    EntitlementUpdateParamsFeatureMonthlyResetPeriodConfigurationAccordingTo
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

    public EntitlementUpdateParamsFeatureMonthlyResetPeriodConfiguration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementUpdateParamsFeatureMonthlyResetPeriodConfiguration(
        EntitlementUpdateParamsFeatureMonthlyResetPeriodConfiguration entitlementUpdateParamsFeatureMonthlyResetPeriodConfiguration
    )
        : base(entitlementUpdateParamsFeatureMonthlyResetPeriodConfiguration) { }
#pragma warning restore CS8618

    public EntitlementUpdateParamsFeatureMonthlyResetPeriodConfiguration(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementUpdateParamsFeatureMonthlyResetPeriodConfiguration(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementUpdateParamsFeatureMonthlyResetPeriodConfigurationFromRaw.FromRawUnchecked"/>
    public static EntitlementUpdateParamsFeatureMonthlyResetPeriodConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EntitlementUpdateParamsFeatureMonthlyResetPeriodConfiguration(
        ApiEnum<
            string,
            EntitlementUpdateParamsFeatureMonthlyResetPeriodConfigurationAccordingTo
        > accordingTo
    )
        : this()
    {
        this.AccordingTo = accordingTo;
    }
}

class EntitlementUpdateParamsFeatureMonthlyResetPeriodConfigurationFromRaw
    : IFromRawJson<EntitlementUpdateParamsFeatureMonthlyResetPeriodConfiguration>
{
    /// <inheritdoc/>
    public EntitlementUpdateParamsFeatureMonthlyResetPeriodConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementUpdateParamsFeatureMonthlyResetPeriodConfiguration.FromRawUnchecked(rawData);
}

/// <summary>
/// Reset anchor (SubscriptionStart or StartOfTheMonth)
/// </summary>
[JsonConverter(
    typeof(EntitlementUpdateParamsFeatureMonthlyResetPeriodConfigurationAccordingToConverter)
)]
public enum EntitlementUpdateParamsFeatureMonthlyResetPeriodConfigurationAccordingTo
{
    SubscriptionStart,
    StartOfTheMonth,
}

sealed class EntitlementUpdateParamsFeatureMonthlyResetPeriodConfigurationAccordingToConverter
    : JsonConverter<EntitlementUpdateParamsFeatureMonthlyResetPeriodConfigurationAccordingTo>
{
    public override EntitlementUpdateParamsFeatureMonthlyResetPeriodConfigurationAccordingTo Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SubscriptionStart" =>
                EntitlementUpdateParamsFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
            "StartOfTheMonth" =>
                EntitlementUpdateParamsFeatureMonthlyResetPeriodConfigurationAccordingTo.StartOfTheMonth,
            _ => (EntitlementUpdateParamsFeatureMonthlyResetPeriodConfigurationAccordingTo)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntitlementUpdateParamsFeatureMonthlyResetPeriodConfigurationAccordingTo value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntitlementUpdateParamsFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart =>
                    "SubscriptionStart",
                EntitlementUpdateParamsFeatureMonthlyResetPeriodConfigurationAccordingTo.StartOfTheMonth =>
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
[JsonConverter(typeof(EntitlementUpdateParamsFeatureResetPeriodConverter))]
public enum EntitlementUpdateParamsFeatureResetPeriod
{
    Year,
    Month,
    Week,
    Day,
    Hour,
}

sealed class EntitlementUpdateParamsFeatureResetPeriodConverter
    : JsonConverter<EntitlementUpdateParamsFeatureResetPeriod>
{
    public override EntitlementUpdateParamsFeatureResetPeriod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "YEAR" => EntitlementUpdateParamsFeatureResetPeriod.Year,
            "MONTH" => EntitlementUpdateParamsFeatureResetPeriod.Month,
            "WEEK" => EntitlementUpdateParamsFeatureResetPeriod.Week,
            "DAY" => EntitlementUpdateParamsFeatureResetPeriod.Day,
            "HOUR" => EntitlementUpdateParamsFeatureResetPeriod.Hour,
            _ => (EntitlementUpdateParamsFeatureResetPeriod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntitlementUpdateParamsFeatureResetPeriod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntitlementUpdateParamsFeatureResetPeriod.Year => "YEAR",
                EntitlementUpdateParamsFeatureResetPeriod.Month => "MONTH",
                EntitlementUpdateParamsFeatureResetPeriod.Week => "WEEK",
                EntitlementUpdateParamsFeatureResetPeriod.Day => "DAY",
                EntitlementUpdateParamsFeatureResetPeriod.Hour => "HOUR",
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
        EntitlementUpdateParamsFeatureWeeklyResetPeriodConfiguration,
        EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationFromRaw
    >)
)]
public sealed record class EntitlementUpdateParamsFeatureWeeklyResetPeriodConfiguration : JsonModel
{
    /// <summary>
    /// Reset anchor (SubscriptionStart or specific day)
    /// </summary>
    public required ApiEnum<
        string,
        EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo
    > AccordingTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo
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

    public EntitlementUpdateParamsFeatureWeeklyResetPeriodConfiguration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementUpdateParamsFeatureWeeklyResetPeriodConfiguration(
        EntitlementUpdateParamsFeatureWeeklyResetPeriodConfiguration entitlementUpdateParamsFeatureWeeklyResetPeriodConfiguration
    )
        : base(entitlementUpdateParamsFeatureWeeklyResetPeriodConfiguration) { }
#pragma warning restore CS8618

    public EntitlementUpdateParamsFeatureWeeklyResetPeriodConfiguration(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementUpdateParamsFeatureWeeklyResetPeriodConfiguration(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationFromRaw.FromRawUnchecked"/>
    public static EntitlementUpdateParamsFeatureWeeklyResetPeriodConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EntitlementUpdateParamsFeatureWeeklyResetPeriodConfiguration(
        ApiEnum<
            string,
            EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo
        > accordingTo
    )
        : this()
    {
        this.AccordingTo = accordingTo;
    }
}

class EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationFromRaw
    : IFromRawJson<EntitlementUpdateParamsFeatureWeeklyResetPeriodConfiguration>
{
    /// <inheritdoc/>
    public EntitlementUpdateParamsFeatureWeeklyResetPeriodConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementUpdateParamsFeatureWeeklyResetPeriodConfiguration.FromRawUnchecked(rawData);
}

/// <summary>
/// Reset anchor (SubscriptionStart or specific day)
/// </summary>
[JsonConverter(
    typeof(EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingToConverter)
)]
public enum EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo
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

sealed class EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingToConverter
    : JsonConverter<EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo>
{
    public override EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SubscriptionStart" =>
                EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart,
            "EverySunday" =>
                EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo.EverySunday,
            "EveryMonday" =>
                EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo.EveryMonday,
            "EveryTuesday" =>
                EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo.EveryTuesday,
            "EveryWednesday" =>
                EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo.EveryWednesday,
            "EveryThursday" =>
                EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo.EveryThursday,
            "EveryFriday" =>
                EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo.EveryFriday,
            "EverySaturday" =>
                EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo.EverySaturday,
            _ => (EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart =>
                    "SubscriptionStart",
                EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo.EverySunday =>
                    "EverySunday",
                EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo.EveryMonday =>
                    "EveryMonday",
                EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo.EveryTuesday =>
                    "EveryTuesday",
                EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo.EveryWednesday =>
                    "EveryWednesday",
                EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo.EveryThursday =>
                    "EveryThursday",
                EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo.EveryFriday =>
                    "EveryFriday",
                EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo.EverySaturday =>
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
        EntitlementUpdateParamsFeatureYearlyResetPeriodConfiguration,
        EntitlementUpdateParamsFeatureYearlyResetPeriodConfigurationFromRaw
    >)
)]
public sealed record class EntitlementUpdateParamsFeatureYearlyResetPeriodConfiguration : JsonModel
{
    /// <summary>
    /// Reset anchor (SubscriptionStart)
    /// </summary>
    public required ApiEnum<
        string,
        EntitlementUpdateParamsFeatureYearlyResetPeriodConfigurationAccordingTo
    > AccordingTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    EntitlementUpdateParamsFeatureYearlyResetPeriodConfigurationAccordingTo
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

    public EntitlementUpdateParamsFeatureYearlyResetPeriodConfiguration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementUpdateParamsFeatureYearlyResetPeriodConfiguration(
        EntitlementUpdateParamsFeatureYearlyResetPeriodConfiguration entitlementUpdateParamsFeatureYearlyResetPeriodConfiguration
    )
        : base(entitlementUpdateParamsFeatureYearlyResetPeriodConfiguration) { }
#pragma warning restore CS8618

    public EntitlementUpdateParamsFeatureYearlyResetPeriodConfiguration(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementUpdateParamsFeatureYearlyResetPeriodConfiguration(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementUpdateParamsFeatureYearlyResetPeriodConfigurationFromRaw.FromRawUnchecked"/>
    public static EntitlementUpdateParamsFeatureYearlyResetPeriodConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EntitlementUpdateParamsFeatureYearlyResetPeriodConfiguration(
        ApiEnum<
            string,
            EntitlementUpdateParamsFeatureYearlyResetPeriodConfigurationAccordingTo
        > accordingTo
    )
        : this()
    {
        this.AccordingTo = accordingTo;
    }
}

class EntitlementUpdateParamsFeatureYearlyResetPeriodConfigurationFromRaw
    : IFromRawJson<EntitlementUpdateParamsFeatureYearlyResetPeriodConfiguration>
{
    /// <inheritdoc/>
    public EntitlementUpdateParamsFeatureYearlyResetPeriodConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementUpdateParamsFeatureYearlyResetPeriodConfiguration.FromRawUnchecked(rawData);
}

/// <summary>
/// Reset anchor (SubscriptionStart)
/// </summary>
[JsonConverter(
    typeof(EntitlementUpdateParamsFeatureYearlyResetPeriodConfigurationAccordingToConverter)
)]
public enum EntitlementUpdateParamsFeatureYearlyResetPeriodConfigurationAccordingTo
{
    SubscriptionStart,
}

sealed class EntitlementUpdateParamsFeatureYearlyResetPeriodConfigurationAccordingToConverter
    : JsonConverter<EntitlementUpdateParamsFeatureYearlyResetPeriodConfigurationAccordingTo>
{
    public override EntitlementUpdateParamsFeatureYearlyResetPeriodConfigurationAccordingTo Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SubscriptionStart" =>
                EntitlementUpdateParamsFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
            _ => (EntitlementUpdateParamsFeatureYearlyResetPeriodConfigurationAccordingTo)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntitlementUpdateParamsFeatureYearlyResetPeriodConfigurationAccordingTo value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntitlementUpdateParamsFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart =>
                    "SubscriptionStart",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
