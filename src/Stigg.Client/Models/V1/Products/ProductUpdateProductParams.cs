using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;

namespace Stigg.Client.Models.V1.Products;

/// <summary>
/// Updates an existing product's properties such as display name, description, and metadata.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ProductUpdateProductParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

    /// <summary>
    /// Description of the product
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
    /// Display name of the product
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
    /// Additional metadata for the product
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
            this._rawBodyData.Set<FrozenDictionary<string, string>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Indicates if multiple subscriptions to this product are allowed
    /// </summary>
    public bool? MultipleSubscriptions
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("multipleSubscriptions");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("multipleSubscriptions", value);
        }
    }

    public ProductSettings? ProductSettings
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ProductSettings>("productSettings");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("productSettings", value);
        }
    }

    /// <summary>
    /// Rule defining when usage resets upon subscription update.
    /// </summary>
    public UsageResetCutoffRule? UsageResetCutoffRule
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<UsageResetCutoffRule>("usageResetCutoffRule");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("usageResetCutoffRule", value);
        }
    }

    public ProductUpdateProductParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProductUpdateProductParams(ProductUpdateProductParams productUpdateProductParams)
        : base(productUpdateProductParams)
    {
        this.ID = productUpdateProductParams.ID;

        this._rawBodyData = new(productUpdateProductParams._rawBodyData);
    }
#pragma warning restore CS8618

    public ProductUpdateProductParams(
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
    ProductUpdateProductParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string id
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.ID = id;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ProductUpdateProductParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string id
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            id
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

    public virtual bool Equals(ProductUpdateProductParams? other)
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

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/api/v1/products/{0}", this.ID)
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

[JsonConverter(typeof(JsonModelConverter<ProductSettings, ProductSettingsFromRaw>))]
public sealed record class ProductSettings : JsonModel
{
    /// <summary>
    /// Time when the subscription will be cancelled
    /// </summary>
    public required ApiEnum<string, SubscriptionCancellationTime> SubscriptionCancellationTime
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, SubscriptionCancellationTime>>(
                "subscriptionCancellationTime"
            );
        }
        init { this._rawData.Set("subscriptionCancellationTime", value); }
    }

    /// <summary>
    /// Setup for the end of the subscription
    /// </summary>
    public required ApiEnum<string, SubscriptionEndSetup> SubscriptionEndSetup
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, SubscriptionEndSetup>>(
                "subscriptionEndSetup"
            );
        }
        init { this._rawData.Set("subscriptionEndSetup", value); }
    }

    /// <summary>
    /// Setup for the start of the subscription
    /// </summary>
    public required ApiEnum<string, SubscriptionStartSetup> SubscriptionStartSetup
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, SubscriptionStartSetup>>(
                "subscriptionStartSetup"
            );
        }
        init { this._rawData.Set("subscriptionStartSetup", value); }
    }

    /// <summary>
    /// ID of the plan to downgrade to at the end of the billing period
    /// </summary>
    public string? DowngradePlanID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("downgradePlanId");
        }
        init { this._rawData.Set("downgradePlanId", value); }
    }

    /// <summary>
    /// Indicates if the subscription should be prorated at the end of the billing period
    /// </summary>
    public bool? ProrateAtEndOfBillingPeriod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("prorateAtEndOfBillingPeriod");
        }
        init { this._rawData.Set("prorateAtEndOfBillingPeriod", value); }
    }

    /// <summary>
    /// ID of the plan to start the subscription with
    /// </summary>
    public string? SubscriptionStartPlanID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("subscriptionStartPlanId");
        }
        init { this._rawData.Set("subscriptionStartPlanId", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.SubscriptionCancellationTime.Validate();
        this.SubscriptionEndSetup.Validate();
        this.SubscriptionStartSetup.Validate();
        _ = this.DowngradePlanID;
        _ = this.ProrateAtEndOfBillingPeriod;
        _ = this.SubscriptionStartPlanID;
    }

    public ProductSettings() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProductSettings(ProductSettings productSettings)
        : base(productSettings) { }
#pragma warning restore CS8618

    public ProductSettings(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProductSettings(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProductSettingsFromRaw.FromRawUnchecked"/>
    public static ProductSettings FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProductSettingsFromRaw : IFromRawJson<ProductSettings>
{
    /// <inheritdoc/>
    public ProductSettings FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ProductSettings.FromRawUnchecked(rawData);
}

/// <summary>
/// Time when the subscription will be cancelled
/// </summary>
[JsonConverter(typeof(SubscriptionCancellationTimeConverter))]
public enum SubscriptionCancellationTime
{
    EndOfBillingPeriod,
    Immediate,
    SpecificDate,
}

sealed class SubscriptionCancellationTimeConverter : JsonConverter<SubscriptionCancellationTime>
{
    public override SubscriptionCancellationTime Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "END_OF_BILLING_PERIOD" => SubscriptionCancellationTime.EndOfBillingPeriod,
            "IMMEDIATE" => SubscriptionCancellationTime.Immediate,
            "SPECIFIC_DATE" => SubscriptionCancellationTime.SpecificDate,
            _ => (SubscriptionCancellationTime)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionCancellationTime value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionCancellationTime.EndOfBillingPeriod => "END_OF_BILLING_PERIOD",
                SubscriptionCancellationTime.Immediate => "IMMEDIATE",
                SubscriptionCancellationTime.SpecificDate => "SPECIFIC_DATE",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Setup for the end of the subscription
/// </summary>
[JsonConverter(typeof(SubscriptionEndSetupConverter))]
public enum SubscriptionEndSetup
{
    DowngradeToFree,
    CancelSubscription,
}

sealed class SubscriptionEndSetupConverter : JsonConverter<SubscriptionEndSetup>
{
    public override SubscriptionEndSetup Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "DOWNGRADE_TO_FREE" => SubscriptionEndSetup.DowngradeToFree,
            "CANCEL_SUBSCRIPTION" => SubscriptionEndSetup.CancelSubscription,
            _ => (SubscriptionEndSetup)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionEndSetup value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionEndSetup.DowngradeToFree => "DOWNGRADE_TO_FREE",
                SubscriptionEndSetup.CancelSubscription => "CANCEL_SUBSCRIPTION",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Setup for the start of the subscription
/// </summary>
[JsonConverter(typeof(SubscriptionStartSetupConverter))]
public enum SubscriptionStartSetup
{
    PlanSelection,
    TrialPeriod,
    FreePlan,
}

sealed class SubscriptionStartSetupConverter : JsonConverter<SubscriptionStartSetup>
{
    public override SubscriptionStartSetup Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PLAN_SELECTION" => SubscriptionStartSetup.PlanSelection,
            "TRIAL_PERIOD" => SubscriptionStartSetup.TrialPeriod,
            "FREE_PLAN" => SubscriptionStartSetup.FreePlan,
            _ => (SubscriptionStartSetup)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionStartSetup value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionStartSetup.PlanSelection => "PLAN_SELECTION",
                SubscriptionStartSetup.TrialPeriod => "TRIAL_PERIOD",
                SubscriptionStartSetup.FreePlan => "FREE_PLAN",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Rule defining when usage resets upon subscription update.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<UsageResetCutoffRule, UsageResetCutoffRuleFromRaw>))]
public sealed record class UsageResetCutoffRule : JsonModel
{
    /// <summary>
    /// Behavior of the usage reset cutoff rule
    /// </summary>
    public required ApiEnum<string, Behavior> Behavior
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Behavior>>("behavior");
        }
        init { this._rawData.Set("behavior", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Behavior.Validate();
    }

    public UsageResetCutoffRule() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UsageResetCutoffRule(UsageResetCutoffRule usageResetCutoffRule)
        : base(usageResetCutoffRule) { }
#pragma warning restore CS8618

    public UsageResetCutoffRule(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UsageResetCutoffRule(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UsageResetCutoffRuleFromRaw.FromRawUnchecked"/>
    public static UsageResetCutoffRule FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UsageResetCutoffRule(ApiEnum<string, Behavior> behavior)
        : this()
    {
        this.Behavior = behavior;
    }
}

class UsageResetCutoffRuleFromRaw : IFromRawJson<UsageResetCutoffRule>
{
    /// <inheritdoc/>
    public UsageResetCutoffRule FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UsageResetCutoffRule.FromRawUnchecked(rawData);
}

/// <summary>
/// Behavior of the usage reset cutoff rule
/// </summary>
[JsonConverter(typeof(BehaviorConverter))]
public enum Behavior
{
    NeverReset,
    AlwaysReset,
    BillingPeriodChange,
}

sealed class BehaviorConverter : JsonConverter<Behavior>
{
    public override Behavior Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "NEVER_RESET" => Behavior.NeverReset,
            "ALWAYS_RESET" => Behavior.AlwaysReset,
            "BILLING_PERIOD_CHANGE" => Behavior.BillingPeriodChange,
            _ => (Behavior)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Behavior value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Behavior.NeverReset => "NEVER_RESET",
                Behavior.AlwaysReset => "ALWAYS_RESET",
                Behavior.BillingPeriodChange => "BILLING_PERIOD_CHANGE",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
