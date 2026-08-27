using System.Collections.Frozen;
using System.Collections.Generic;
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
/// Creates a new plan in draft status.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class PlanCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The unique identifier for the entity
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("id");
        }
        init { this._rawBodyData.Set("id", value); }
    }

    /// <summary>
    /// The display name of the package
    /// </summary>
    public required string DisplayName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("displayName");
        }
        init { this._rawBodyData.Set("displayName", value); }
    }

    /// <summary>
    /// The product ID to associate the plan with
    /// </summary>
    public required string ProductID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("productId");
        }
        init { this._rawBodyData.Set("productId", value); }
    }

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

    /// <summary>
    /// Default trial configuration for the plan. When set, subscriptions provisioned
    /// on this plan without explicit trial settings automatically start in trial
    /// for the configured duration; leave unset for no automatic trial.
    /// </summary>
    public DefaultTrialConfig? DefaultTrialConfig
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<DefaultTrialConfig>("defaultTrialConfig");
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
    /// The ID of the parent plan, if this plan should inherit entitlements from another
    /// plan. Optional — omit to create a standalone plan with no inherited entitlements.
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

    /// <summary>
    /// The pricing type of the package
    /// </summary>
    public ApiEnum<string, PricingType>? PricingType
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, PricingType>>("pricingType");
        }
        init { this._rawBodyData.Set("pricingType", value); }
    }

    /// <summary>
    /// The status of the package
    /// </summary>
    public ApiEnum<string, Status>? Status
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, Status>>("status");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("status", value);
        }
    }

    public string? XAccountID
    {
        get
        {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNullableClass<string>("X-ACCOUNT-ID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawHeaderData.Set("X-ACCOUNT-ID", value);
        }
    }

    public string? XEnvironmentID
    {
        get
        {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNullableClass<string>("X-ENVIRONMENT-ID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawHeaderData.Set("X-ENVIRONMENT-ID", value);
        }
    }

    public PlanCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlanCreateParams(PlanCreateParams planCreateParams)
        : base(planCreateParams)
    {
        this._rawBodyData = new(planCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public PlanCreateParams(
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
    PlanCreateParams(
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

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static PlanCreateParams FromRawUnchecked(
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

    public virtual bool Equals(PlanCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/api/v1/plans")
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
/// Default trial configuration for the plan. When set, subscriptions provisioned
/// on this plan without explicit trial settings automatically start in trial for
/// the configured duration; leave unset for no automatic trial.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DefaultTrialConfig, DefaultTrialConfigFromRaw>))]
public sealed record class DefaultTrialConfig : JsonModel
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
    public required ApiEnum<string, Units> Units
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Units>>("units");
        }
        init { this._rawData.Set("units", value); }
    }

    /// <summary>
    /// Budget configuration for the trial
    /// </summary>
    public Budget? Budget
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Budget>("budget");
        }
        init { this._rawData.Set("budget", value); }
    }

    /// <summary>
    /// Behavior when the trial ends (CONVERT_TO_PAID or CANCEL_SUBSCRIPTION)
    /// </summary>
    public ApiEnum<string, TrialEndBehavior>? TrialEndBehavior
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TrialEndBehavior>>(
                "trialEndBehavior"
            );
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

    public DefaultTrialConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DefaultTrialConfig(DefaultTrialConfig defaultTrialConfig)
        : base(defaultTrialConfig) { }
#pragma warning restore CS8618

    public DefaultTrialConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DefaultTrialConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DefaultTrialConfigFromRaw.FromRawUnchecked"/>
    public static DefaultTrialConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DefaultTrialConfigFromRaw : IFromRawJson<DefaultTrialConfig>
{
    /// <inheritdoc/>
    public DefaultTrialConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DefaultTrialConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// The time unit for the trial duration (DAY or MONTH)
/// </summary>
[JsonConverter(typeof(UnitsConverter))]
public enum Units
{
    Day,
    Month,
}

sealed class UnitsConverter : JsonConverter<Units>
{
    public override Units Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "DAY" => Units.Day,
            "MONTH" => Units.Month,
            _ => (Units)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Units value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Units.Day => "DAY",
                Units.Month => "MONTH",
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
[JsonConverter(typeof(JsonModelConverter<Budget, BudgetFromRaw>))]
public sealed record class Budget : JsonModel
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

    public Budget() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Budget(Budget budget)
        : base(budget) { }
#pragma warning restore CS8618

    public Budget(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Budget(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BudgetFromRaw.FromRawUnchecked"/>
    public static Budget FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BudgetFromRaw : IFromRawJson<Budget>
{
    /// <inheritdoc/>
    public Budget FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Budget.FromRawUnchecked(rawData);
}

/// <summary>
/// Behavior when the trial ends (CONVERT_TO_PAID or CANCEL_SUBSCRIPTION)
/// </summary>
[JsonConverter(typeof(TrialEndBehaviorConverter))]
public enum TrialEndBehavior
{
    ConvertToPaid,
    CancelSubscription,
}

sealed class TrialEndBehaviorConverter : JsonConverter<TrialEndBehavior>
{
    public override TrialEndBehavior Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "CONVERT_TO_PAID" => TrialEndBehavior.ConvertToPaid,
            "CANCEL_SUBSCRIPTION" => TrialEndBehavior.CancelSubscription,
            _ => (TrialEndBehavior)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TrialEndBehavior value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TrialEndBehavior.ConvertToPaid => "CONVERT_TO_PAID",
                TrialEndBehavior.CancelSubscription => "CANCEL_SUBSCRIPTION",
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
[JsonConverter(typeof(PricingTypeConverter))]
public enum PricingType
{
    Free,
    Paid,
    Custom,
}

sealed class PricingTypeConverter : JsonConverter<PricingType>
{
    public override PricingType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FREE" => PricingType.Free,
            "PAID" => PricingType.Paid,
            "CUSTOM" => PricingType.Custom,
            _ => (PricingType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PricingType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PricingType.Free => "FREE",
                PricingType.Paid => "PAID",
                PricingType.Custom => "CUSTOM",
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
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Draft,
    Published,
    Archived,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "DRAFT" => Status.Draft,
            "PUBLISHED" => Status.Published,
            "ARCHIVED" => Status.Archived,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Draft => "DRAFT",
                Status.Published => "PUBLISHED",
                Status.Archived => "ARCHIVED",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
