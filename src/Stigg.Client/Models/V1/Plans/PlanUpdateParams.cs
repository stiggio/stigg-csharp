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

namespace Stigg.Client.Models.V1.Plans;

/// <summary>
/// Updates an existing plan's properties such as display name, description, and metadata.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class PlanUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

    /// <summary>
    /// The unique identifier for the entity in the billing provider
    /// </summary>
    public string? BillingID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("billingId");
        }
        init { this._rawBodyData.Set("billingId", value); }
    }

    public IReadOnlyList<string>? CompatibleAddonIds
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>(
                "compatibleAddonIds"
            );
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<string>?>(
                "compatibleAddonIds",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Default trial configuration for the plan
    /// </summary>
    public PlanUpdateParamsDefaultTrialConfig? DefaultTrialConfig
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<PlanUpdateParamsDefaultTrialConfig>(
                "defaultTrialConfig"
            );
        }
        init { this._rawBodyData.Set("defaultTrialConfig", value); }
    }

    /// <summary>
    /// The description of the package
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("description");
        }
        init { this._rawBodyData.Set("description", value); }
    }

    /// <summary>
    /// The display name of the package
    /// </summary>
    public string? DisplayName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("displayName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("displayName", value);
        }
    }

    /// <summary>
    /// Metadata associated with the entity
    /// </summary>
    public IReadOnlyDictionary<string, string>? Metadata
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<FrozenDictionary<string, string>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// The ID of the parent plan, if applicable
    /// </summary>
    public string? ParentPlanID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("parentPlanId");
        }
        init { this._rawBodyData.Set("parentPlanId", value); }
    }

    public PlanUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlanUpdateParams(PlanUpdateParams planUpdateParams)
        : base(planUpdateParams)
    {
        this.ID = planUpdateParams.ID;

        this._rawBodyData = new(planUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public PlanUpdateParams(
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
    PlanUpdateParams(
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
    public static PlanUpdateParams FromRawUnchecked(
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

    public virtual bool Equals(PlanUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ID?.Equals(other.ID) ?? other.ID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/api/v1/plans/{0}", this.ID)
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
/// Default trial configuration for the plan
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        PlanUpdateParamsDefaultTrialConfig,
        PlanUpdateParamsDefaultTrialConfigFromRaw
    >)
)]
public sealed record class PlanUpdateParamsDefaultTrialConfig : JsonModel
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
    public required ApiEnum<string, PlanUpdateParamsDefaultTrialConfigUnits> Units
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, PlanUpdateParamsDefaultTrialConfigUnits>
            >("units");
        }
        init { this._rawData.Set("units", value); }
    }

    /// <summary>
    /// Budget configuration for the trial
    /// </summary>
    public PlanUpdateParamsDefaultTrialConfigBudget? Budget
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PlanUpdateParamsDefaultTrialConfigBudget>(
                "budget"
            );
        }
        init { this._rawData.Set("budget", value); }
    }

    /// <summary>
    /// Behavior when the trial ends (CONVERT_TO_PAID or CANCEL_SUBSCRIPTION)
    /// </summary>
    public ApiEnum<string, PlanUpdateParamsDefaultTrialConfigTrialEndBehavior>? TrialEndBehavior
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, PlanUpdateParamsDefaultTrialConfigTrialEndBehavior>
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

    public PlanUpdateParamsDefaultTrialConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlanUpdateParamsDefaultTrialConfig(
        PlanUpdateParamsDefaultTrialConfig planUpdateParamsDefaultTrialConfig
    )
        : base(planUpdateParamsDefaultTrialConfig) { }
#pragma warning restore CS8618

    public PlanUpdateParamsDefaultTrialConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlanUpdateParamsDefaultTrialConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlanUpdateParamsDefaultTrialConfigFromRaw.FromRawUnchecked"/>
    public static PlanUpdateParamsDefaultTrialConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlanUpdateParamsDefaultTrialConfigFromRaw : IFromRawJson<PlanUpdateParamsDefaultTrialConfig>
{
    /// <inheritdoc/>
    public PlanUpdateParamsDefaultTrialConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlanUpdateParamsDefaultTrialConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// The time unit for the trial duration (DAY or MONTH)
/// </summary>
[JsonConverter(typeof(PlanUpdateParamsDefaultTrialConfigUnitsConverter))]
public enum PlanUpdateParamsDefaultTrialConfigUnits
{
    Day,
    Month,
}

sealed class PlanUpdateParamsDefaultTrialConfigUnitsConverter
    : JsonConverter<PlanUpdateParamsDefaultTrialConfigUnits>
{
    public override PlanUpdateParamsDefaultTrialConfigUnits Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "DAY" => PlanUpdateParamsDefaultTrialConfigUnits.Day,
            "MONTH" => PlanUpdateParamsDefaultTrialConfigUnits.Month,
            _ => (PlanUpdateParamsDefaultTrialConfigUnits)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PlanUpdateParamsDefaultTrialConfigUnits value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PlanUpdateParamsDefaultTrialConfigUnits.Day => "DAY",
                PlanUpdateParamsDefaultTrialConfigUnits.Month => "MONTH",
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
    typeof(JsonModelConverter<
        PlanUpdateParamsDefaultTrialConfigBudget,
        PlanUpdateParamsDefaultTrialConfigBudgetFromRaw
    >)
)]
public sealed record class PlanUpdateParamsDefaultTrialConfigBudget : JsonModel
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

    public PlanUpdateParamsDefaultTrialConfigBudget() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlanUpdateParamsDefaultTrialConfigBudget(
        PlanUpdateParamsDefaultTrialConfigBudget planUpdateParamsDefaultTrialConfigBudget
    )
        : base(planUpdateParamsDefaultTrialConfigBudget) { }
#pragma warning restore CS8618

    public PlanUpdateParamsDefaultTrialConfigBudget(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlanUpdateParamsDefaultTrialConfigBudget(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlanUpdateParamsDefaultTrialConfigBudgetFromRaw.FromRawUnchecked"/>
    public static PlanUpdateParamsDefaultTrialConfigBudget FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlanUpdateParamsDefaultTrialConfigBudgetFromRaw
    : IFromRawJson<PlanUpdateParamsDefaultTrialConfigBudget>
{
    /// <inheritdoc/>
    public PlanUpdateParamsDefaultTrialConfigBudget FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlanUpdateParamsDefaultTrialConfigBudget.FromRawUnchecked(rawData);
}

/// <summary>
/// Behavior when the trial ends (CONVERT_TO_PAID or CANCEL_SUBSCRIPTION)
/// </summary>
[JsonConverter(typeof(PlanUpdateParamsDefaultTrialConfigTrialEndBehaviorConverter))]
public enum PlanUpdateParamsDefaultTrialConfigTrialEndBehavior
{
    ConvertToPaid,
    CancelSubscription,
}

sealed class PlanUpdateParamsDefaultTrialConfigTrialEndBehaviorConverter
    : JsonConverter<PlanUpdateParamsDefaultTrialConfigTrialEndBehavior>
{
    public override PlanUpdateParamsDefaultTrialConfigTrialEndBehavior Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "CONVERT_TO_PAID" => PlanUpdateParamsDefaultTrialConfigTrialEndBehavior.ConvertToPaid,
            "CANCEL_SUBSCRIPTION" =>
                PlanUpdateParamsDefaultTrialConfigTrialEndBehavior.CancelSubscription,
            _ => (PlanUpdateParamsDefaultTrialConfigTrialEndBehavior)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PlanUpdateParamsDefaultTrialConfigTrialEndBehavior value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PlanUpdateParamsDefaultTrialConfigTrialEndBehavior.ConvertToPaid =>
                    "CONVERT_TO_PAID",
                PlanUpdateParamsDefaultTrialConfigTrialEndBehavior.CancelSubscription =>
                    "CANCEL_SUBSCRIPTION",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
