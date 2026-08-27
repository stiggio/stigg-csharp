using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using System = System;

namespace Stigg.Client.Models.V1.Plans;

/// <summary>
/// Response object
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Plan, PlanFromRaw>))]
public sealed record class Plan : JsonModel
{
    /// <summary>
    /// Plan configuration object
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

    public Plan() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Plan(Plan plan)
        : base(plan) { }
#pragma warning restore CS8618

    public Plan(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Plan(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlanFromRaw.FromRawUnchecked"/>
    public static Plan FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Plan(Data data)
        : this()
    {
        this.Data = data;
    }
}

class PlanFromRaw : IFromRawJson<Plan>
{
    /// <inheritdoc/>
    public Plan FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Plan.FromRawUnchecked(rawData);
}

/// <summary>
/// Plan configuration object
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// The unique identifier for the entity
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
    /// The unique identifier for the entity in the billing provider
    /// </summary>
    public required string? BillingID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billingId");
        }
        init { this._rawData.Set("billingId", value); }
    }

    public required IReadOnlyList<string>? CompatibleAddonIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("compatibleAddonIds");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "compatibleAddonIds",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
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
    /// Default trial configuration for the plan. When set, subscriptions provisioned
    /// on this plan without explicit trial settings automatically start in trial
    /// for the configured duration; leave unset for no automatic trial.
    /// </summary>
    public required DataDefaultTrialConfig? DefaultTrialConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<DataDefaultTrialConfig>("defaultTrialConfig");
        }
        init { this._rawData.Set("defaultTrialConfig", value); }
    }

    /// <summary>
    /// The description of the package
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
    /// The display name of the package
    /// </summary>
    public required string DisplayName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("displayName");
        }
        init { this._rawData.Set("displayName", value); }
    }

    /// <summary>
    /// List of entitlements of the package
    /// </summary>
    public required IReadOnlyList<DataEntitlement> Entitlements
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<DataEntitlement>>("entitlements");
        }
        init
        {
            this._rawData.Set<ImmutableArray<DataEntitlement>>(
                "entitlements",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Indicates if the package is the latest version
    /// </summary>
    public required bool? IsLatest
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isLatest");
        }
        init { this._rawData.Set("isLatest", value); }
    }

    /// <summary>
    /// Metadata associated with the entity
    /// </summary>
    public required IReadOnlyDictionary<string, string> Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string>>(
                "metadata",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// The ID of the parent plan, if this plan should inherit entitlements from another
    /// plan. Optional — omit to create a standalone plan with no inherited entitlements.
    /// </summary>
    public required string? ParentPlanID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("parentPlanId");
        }
        init { this._rawData.Set("parentPlanId", value); }
    }

    /// <summary>
    /// The pricing type of the package
    /// </summary>
    public required ApiEnum<string, DataPricingType>? PricingType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, DataPricingType>>("pricingType");
        }
        init { this._rawData.Set("pricingType", value); }
    }

    /// <summary>
    /// The product id of the package
    /// </summary>
    public required string ProductID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("productId");
        }
        init { this._rawData.Set("productId", value); }
    }

    /// <summary>
    /// The status of the package
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
    /// The version number of the package
    /// </summary>
    public required long VersionNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("versionNumber");
        }
        init { this._rawData.Set("versionNumber", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.BillingID;
        _ = this.CompatibleAddonIds;
        _ = this.CreatedAt;
        this.DefaultTrialConfig?.Validate();
        _ = this.Description;
        _ = this.DisplayName;
        foreach (var item in this.Entitlements)
        {
            item.Validate();
        }
        _ = this.IsLatest;
        _ = this.Metadata;
        _ = this.ParentPlanID;
        this.PricingType?.Validate();
        _ = this.ProductID;
        this.Status.Validate();
        _ = this.UpdatedAt;
        _ = this.VersionNumber;
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
/// Default trial configuration for the plan. When set, subscriptions provisioned
/// on this plan without explicit trial settings automatically start in trial for
/// the configured duration; leave unset for no automatic trial.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DataDefaultTrialConfig, DataDefaultTrialConfigFromRaw>))]
public sealed record class DataDefaultTrialConfig : JsonModel
{
    /// <summary>
    /// The duration of the trial in the specified units
    /// </summary>
    public required double Duration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("duration");
        }
        init { this._rawData.Set("duration", value); }
    }

    /// <summary>
    /// The time unit for the trial duration (DAY or MONTH)
    /// </summary>
    public required ApiEnum<string, DataDefaultTrialConfigUnits> Units
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, DataDefaultTrialConfigUnits>>(
                "units"
            );
        }
        init { this._rawData.Set("units", value); }
    }

    /// <summary>
    /// Budget configuration for the trial
    /// </summary>
    public DataDefaultTrialConfigBudget? Budget
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<DataDefaultTrialConfigBudget>("budget");
        }
        init { this._rawData.Set("budget", value); }
    }

    /// <summary>
    /// Behavior when the trial ends (CONVERT_TO_PAID or CANCEL_SUBSCRIPTION)
    /// </summary>
    public ApiEnum<string, DataDefaultTrialConfigTrialEndBehavior>? TrialEndBehavior
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, DataDefaultTrialConfigTrialEndBehavior>
            >("trialEndBehavior");
        }
        init { this._rawData.Set("trialEndBehavior", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Duration;
        this.Units.Validate();
        this.Budget?.Validate();
        this.TrialEndBehavior?.Validate();
    }

    public DataDefaultTrialConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DataDefaultTrialConfig(DataDefaultTrialConfig dataDefaultTrialConfig)
        : base(dataDefaultTrialConfig) { }
#pragma warning restore CS8618

    public DataDefaultTrialConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DataDefaultTrialConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataDefaultTrialConfigFromRaw.FromRawUnchecked"/>
    public static DataDefaultTrialConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataDefaultTrialConfigFromRaw : IFromRawJson<DataDefaultTrialConfig>
{
    /// <inheritdoc/>
    public DataDefaultTrialConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DataDefaultTrialConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// The time unit for the trial duration (DAY or MONTH)
/// </summary>
[JsonConverter(typeof(DataDefaultTrialConfigUnitsConverter))]
public enum DataDefaultTrialConfigUnits
{
    Day,
    Month,
}

sealed class DataDefaultTrialConfigUnitsConverter : JsonConverter<DataDefaultTrialConfigUnits>
{
    public override DataDefaultTrialConfigUnits Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "DAY" => DataDefaultTrialConfigUnits.Day,
            "MONTH" => DataDefaultTrialConfigUnits.Month,
            _ => (DataDefaultTrialConfigUnits)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DataDefaultTrialConfigUnits value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DataDefaultTrialConfigUnits.Day => "DAY",
                DataDefaultTrialConfigUnits.Month => "MONTH",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Budget configuration for the trial
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<DataDefaultTrialConfigBudget, DataDefaultTrialConfigBudgetFromRaw>)
)]
public sealed record class DataDefaultTrialConfigBudget : JsonModel
{
    /// <summary>
    /// Whether the budget limit is a soft limit (allows overage) or hard limit
    /// </summary>
    public required bool HasSoftLimit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("hasSoftLimit");
        }
        init { this._rawData.Set("hasSoftLimit", value); }
    }

    /// <summary>
    /// The budget limit amount
    /// </summary>
    public required double Limit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("limit");
        }
        init { this._rawData.Set("limit", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.HasSoftLimit;
        _ = this.Limit;
    }

    public DataDefaultTrialConfigBudget() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DataDefaultTrialConfigBudget(DataDefaultTrialConfigBudget dataDefaultTrialConfigBudget)
        : base(dataDefaultTrialConfigBudget) { }
#pragma warning restore CS8618

    public DataDefaultTrialConfigBudget(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DataDefaultTrialConfigBudget(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataDefaultTrialConfigBudgetFromRaw.FromRawUnchecked"/>
    public static DataDefaultTrialConfigBudget FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataDefaultTrialConfigBudgetFromRaw : IFromRawJson<DataDefaultTrialConfigBudget>
{
    /// <inheritdoc/>
    public DataDefaultTrialConfigBudget FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DataDefaultTrialConfigBudget.FromRawUnchecked(rawData);
}

/// <summary>
/// Behavior when the trial ends (CONVERT_TO_PAID or CANCEL_SUBSCRIPTION)
/// </summary>
[JsonConverter(typeof(DataDefaultTrialConfigTrialEndBehaviorConverter))]
public enum DataDefaultTrialConfigTrialEndBehavior
{
    ConvertToPaid,
    CancelSubscription,
}

sealed class DataDefaultTrialConfigTrialEndBehaviorConverter
    : JsonConverter<DataDefaultTrialConfigTrialEndBehavior>
{
    public override DataDefaultTrialConfigTrialEndBehavior Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "CONVERT_TO_PAID" => DataDefaultTrialConfigTrialEndBehavior.ConvertToPaid,
            "CANCEL_SUBSCRIPTION" => DataDefaultTrialConfigTrialEndBehavior.CancelSubscription,
            _ => (DataDefaultTrialConfigTrialEndBehavior)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DataDefaultTrialConfigTrialEndBehavior value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DataDefaultTrialConfigTrialEndBehavior.ConvertToPaid => "CONVERT_TO_PAID",
                DataDefaultTrialConfigTrialEndBehavior.CancelSubscription => "CANCEL_SUBSCRIPTION",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Entitlement reference with type and identifier
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DataEntitlement, DataEntitlementFromRaw>))]
public sealed record class DataEntitlement : JsonModel
{
    /// <summary>
    /// The unique identifier for the entity
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

    public required ApiEnum<string, global::Stigg.Client.Models.V1.Plans.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Stigg.Client.Models.V1.Plans.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Type.Validate();
    }

    public DataEntitlement() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DataEntitlement(DataEntitlement dataEntitlement)
        : base(dataEntitlement) { }
#pragma warning restore CS8618

    public DataEntitlement(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DataEntitlement(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataEntitlementFromRaw.FromRawUnchecked"/>
    public static DataEntitlement FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataEntitlementFromRaw : IFromRawJson<DataEntitlement>
{
    /// <inheritdoc/>
    public DataEntitlement FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DataEntitlement.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Feature,
    Credit,
}

sealed class TypeConverter : JsonConverter<global::Stigg.Client.Models.V1.Plans.Type>
{
    public override global::Stigg.Client.Models.V1.Plans.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FEATURE" => global::Stigg.Client.Models.V1.Plans.Type.Feature,
            "CREDIT" => global::Stigg.Client.Models.V1.Plans.Type.Credit,
            _ => (global::Stigg.Client.Models.V1.Plans.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Stigg.Client.Models.V1.Plans.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Stigg.Client.Models.V1.Plans.Type.Feature => "FEATURE",
                global::Stigg.Client.Models.V1.Plans.Type.Credit => "CREDIT",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The pricing type of the package
/// </summary>
[JsonConverter(typeof(DataPricingTypeConverter))]
public enum DataPricingType
{
    Free,
    Paid,
    Custom,
}

sealed class DataPricingTypeConverter : JsonConverter<DataPricingType>
{
    public override DataPricingType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FREE" => DataPricingType.Free,
            "PAID" => DataPricingType.Paid,
            "CUSTOM" => DataPricingType.Custom,
            _ => (DataPricingType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DataPricingType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DataPricingType.Free => "FREE",
                DataPricingType.Paid => "PAID",
                DataPricingType.Custom => "CUSTOM",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The status of the package
/// </summary>
[JsonConverter(typeof(DataStatusConverter))]
public enum DataStatus
{
    Draft,
    Published,
    Archived,
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
            "DRAFT" => DataStatus.Draft,
            "PUBLISHED" => DataStatus.Published,
            "ARCHIVED" => DataStatus.Archived,
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
                DataStatus.Draft => "DRAFT",
                DataStatus.Published => "PUBLISHED",
                DataStatus.Archived => "ARCHIVED",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
