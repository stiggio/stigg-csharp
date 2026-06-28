using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;

namespace Stigg.Client.Models.V1Beta.Customers.Entitlements;

/// <summary>
/// Response object
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<EntitlementCheckResponse, EntitlementCheckResponseFromRaw>)
)]
public sealed record class EntitlementCheckResponse : JsonModel
{
    /// <summary>
    /// Feature entitlement with optional governance chains attached.
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

    public EntitlementCheckResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementCheckResponse(EntitlementCheckResponse entitlementCheckResponse)
        : base(entitlementCheckResponse) { }
#pragma warning restore CS8618

    public EntitlementCheckResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementCheckResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementCheckResponseFromRaw.FromRawUnchecked"/>
    public static EntitlementCheckResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EntitlementCheckResponse(Data data)
        : this()
    {
        this.Data = data;
    }
}

class EntitlementCheckResponseFromRaw : IFromRawJson<EntitlementCheckResponse>
{
    /// <inheritdoc/>
    public EntitlementCheckResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementCheckResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Feature entitlement with optional governance chains attached.
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

    public bool IsGranted
    {
        get { return Match(feature: (x) => x.IsGranted, credit: (x) => x.IsGranted); }
    }

    public JsonElement Type
    {
        get { return Match(feature: (x) => x.Type, credit: (x) => x.Type); }
    }

    public double? CurrentUsage
    {
        get
        {
            return Match<double?>(feature: (x) => x.CurrentUsage, credit: (x) => x.CurrentUsage);
        }
    }

    public DateTimeOffset? EntitlementUpdatedAt
    {
        get
        {
            return Match<DateTimeOffset?>(
                feature: (x) => x.EntitlementUpdatedAt,
                credit: (x) => x.EntitlementUpdatedAt
            );
        }
    }

    public double? UsageLimit
    {
        get { return Match<double?>(feature: (x) => x.UsageLimit, credit: (x) => x.UsageLimit); }
    }

    public DateTimeOffset? UsagePeriodEnd
    {
        get
        {
            return Match<DateTimeOffset?>(
                feature: (x) => x.UsagePeriodEnd,
                credit: (x) => x.UsagePeriodEnd
            );
        }
    }

    public DateTimeOffset? ValidUntil
    {
        get
        {
            return Match<DateTimeOffset?>(
                feature: (x) => x.ValidUntil,
                credit: (x) => x.ValidUntil
            );
        }
    }

    public Data(Feature value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Data(Credit value, JsonElement? element = null)
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
    /// type <see cref="Feature"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFeature(out var value)) {
    ///     // `value` is of type `Feature`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFeature([NotNullWhen(true)] out Feature? value)
    {
        value = this.Value as Feature;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Credit"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCredit(out var value)) {
    ///     // `value` is of type `Credit`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCredit([NotNullWhen(true)] out Credit? value)
    {
        value = this.Value as Credit;
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
    ///     (Feature value) =&gt; {...},
    ///     (Credit value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(Action<Feature> feature, Action<Credit> credit)
    {
        switch (this.Value)
        {
            case Feature value:
                feature(value);
                break;
            case Credit value:
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
    ///     (Feature value) =&gt; {...},
    ///     (Credit value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(Func<Feature, T> feature, Func<Credit, T> credit)
    {
        return this.Value switch
        {
            Feature value => feature(value),
            Credit value => credit(value),
            _ => throw new StiggInvalidDataException("Data did not match any variant of Data"),
        };
    }

    public static implicit operator Data(Feature value) => new(value);

    public static implicit operator Data(Credit value) => new(value);

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
            Feature _ => 0,
            Credit _ => 1,
            _ => -1,
        };
    }
}

sealed class DataConverter : JsonConverter<Data>
{
    public override Data? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
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
                    var deserialized = JsonSerializer.Deserialize<Feature>(element, options);
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
                    var deserialized = JsonSerializer.Deserialize<Credit>(element, options);
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
/// Feature entitlement with optional governance chains attached.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Feature, FeatureFromRaw>))]
public sealed record class Feature : JsonModel
{
    public required ApiEnum<string, AccessDeniedReason>? AccessDeniedReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, AccessDeniedReason>>(
                "accessDeniedReason"
            );
        }
        init { this._rawData.Set("accessDeniedReason", value); }
    }

    public required bool IsGranted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("isGranted");
        }
        init { this._rawData.Set("isGranted", value); }
    }

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
    /// Per-entity rollups, one chain per resolved dimension. Omitted when dimensions
    /// was not provided.
    /// </summary>
    public IReadOnlyList<IReadOnlyList<BetaChainNode>>? Chains
    {
        get
        {
            this._rawData.Freeze();
            var value = this._rawData.GetNullableStruct<
                ImmutableArray<ImmutableArray<BetaChainNode>>
            >("chains");
            if (value == null)
            {
                return null;
            }

            return ImmutableArray.ToImmutableArray(
                Enumerable.Select(value.Value, (item) => (IReadOnlyList<BetaChainNode>)item)
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ImmutableArray<BetaChainNode>>?>(
                "chains",
                value == null
                    ? null
                    : ImmutableArray.ToImmutableArray(
                        Enumerable.Select(value, (item) => ImmutableArray.ToImmutableArray(item))
                    )
            );
        }
    }

    public double? CurrentUsage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("currentUsage");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("currentUsage", value);
        }
    }

    /// <summary>
    /// Timestamp of the last update to the entitlement grant or configuration.
    /// </summary>
    public DateTimeOffset? EntitlementUpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("entitlementUpdatedAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("entitlementUpdatedAt", value);
        }
    }

    public FeatureFeature? FeatureValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FeatureFeature>("feature");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("feature", value);
        }
    }

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

    public ApiEnum<string, ResetPeriod>? ResetPeriod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ResetPeriod>>("resetPeriod");
        }
        init { this._rawData.Set("resetPeriod", value); }
    }

    public double? UsageLimit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("usageLimit");
        }
        init { this._rawData.Set("usageLimit", value); }
    }

    /// <summary>
    /// The anchor for calculating the usage period for metered entitlements with
    /// a reset period configured
    /// </summary>
    public DateTimeOffset? UsagePeriodAnchor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("usagePeriodAnchor");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("usagePeriodAnchor", value);
        }
    }

    /// <summary>
    /// The end date of the usage period for metered entitlements with a reset period configured
    /// </summary>
    public DateTimeOffset? UsagePeriodEnd
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("usagePeriodEnd");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("usagePeriodEnd", value);
        }
    }

    /// <summary>
    /// The start date of the usage period for metered entitlements with a reset period configured
    /// </summary>
    public DateTimeOffset? UsagePeriodStart
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("usagePeriodStart");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("usagePeriodStart", value);
        }
    }

    /// <summary>
    /// The next time the entitlement should be recalculated
    /// </summary>
    public DateTimeOffset? ValidUntil
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("validUntil");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("validUntil", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.AccessDeniedReason?.Validate();
        _ = this.IsGranted;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("FEATURE")))
        {
            throw new StiggInvalidDataException("Invalid value given for constant");
        }
        foreach (var item in this.Chains ?? [])
        {
            foreach (var item1 in item)
            {
                item1.Validate();
            }
        }
        _ = this.CurrentUsage;
        _ = this.EntitlementUpdatedAt;
        this.FeatureValue?.Validate();
        _ = this.HasUnlimitedUsage;
        this.ResetPeriod?.Validate();
        _ = this.UsageLimit;
        _ = this.UsagePeriodAnchor;
        _ = this.UsagePeriodEnd;
        _ = this.UsagePeriodStart;
        _ = this.ValidUntil;
    }

    public Feature()
    {
        this.Type = JsonSerializer.SerializeToElement("FEATURE");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Feature(Feature feature)
        : base(feature) { }
#pragma warning restore CS8618

    public Feature(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("FEATURE");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Feature(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FeatureFromRaw.FromRawUnchecked"/>
    public static Feature FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FeatureFromRaw : IFromRawJson<Feature>
{
    /// <inheritdoc/>
    public Feature FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Feature.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(AccessDeniedReasonConverter))]
public enum AccessDeniedReason
{
    FeatureNotFound,
    CustomerNotFound,
    CustomerIsArchived,
    CustomerResourceNotFound,
    NoActiveSubscription,
    NoFeatureEntitlementInSubscription,
    RequestedUsageExceedingLimit,
    RequestedValuesMismatch,
    BudgetExceeded,
    Unknown,
    FeatureTypeMismatch,
    Revoked,
    InsufficientCredits,
    EntitlementNotFound,
}

sealed class AccessDeniedReasonConverter : JsonConverter<AccessDeniedReason>
{
    public override AccessDeniedReason Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FeatureNotFound" => AccessDeniedReason.FeatureNotFound,
            "CustomerNotFound" => AccessDeniedReason.CustomerNotFound,
            "CustomerIsArchived" => AccessDeniedReason.CustomerIsArchived,
            "CustomerResourceNotFound" => AccessDeniedReason.CustomerResourceNotFound,
            "NoActiveSubscription" => AccessDeniedReason.NoActiveSubscription,
            "NoFeatureEntitlementInSubscription" =>
                AccessDeniedReason.NoFeatureEntitlementInSubscription,
            "RequestedUsageExceedingLimit" => AccessDeniedReason.RequestedUsageExceedingLimit,
            "RequestedValuesMismatch" => AccessDeniedReason.RequestedValuesMismatch,
            "BudgetExceeded" => AccessDeniedReason.BudgetExceeded,
            "Unknown" => AccessDeniedReason.Unknown,
            "FeatureTypeMismatch" => AccessDeniedReason.FeatureTypeMismatch,
            "Revoked" => AccessDeniedReason.Revoked,
            "InsufficientCredits" => AccessDeniedReason.InsufficientCredits,
            "EntitlementNotFound" => AccessDeniedReason.EntitlementNotFound,
            _ => (AccessDeniedReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AccessDeniedReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AccessDeniedReason.FeatureNotFound => "FeatureNotFound",
                AccessDeniedReason.CustomerNotFound => "CustomerNotFound",
                AccessDeniedReason.CustomerIsArchived => "CustomerIsArchived",
                AccessDeniedReason.CustomerResourceNotFound => "CustomerResourceNotFound",
                AccessDeniedReason.NoActiveSubscription => "NoActiveSubscription",
                AccessDeniedReason.NoFeatureEntitlementInSubscription =>
                    "NoFeatureEntitlementInSubscription",
                AccessDeniedReason.RequestedUsageExceedingLimit => "RequestedUsageExceedingLimit",
                AccessDeniedReason.RequestedValuesMismatch => "RequestedValuesMismatch",
                AccessDeniedReason.BudgetExceeded => "BudgetExceeded",
                AccessDeniedReason.Unknown => "Unknown",
                AccessDeniedReason.FeatureTypeMismatch => "FeatureTypeMismatch",
                AccessDeniedReason.Revoked => "Revoked",
                AccessDeniedReason.InsufficientCredits => "InsufficientCredits",
                AccessDeniedReason.EntitlementNotFound => "EntitlementNotFound",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Per-entity governance node — limit and current usage for a single resolved entity.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaChainNode, BetaChainNodeFromRaw>))]
public sealed record class BetaChainNode : JsonModel
{
    /// <summary>
    /// Amount consumed by this entity in the current cadence period.
    /// </summary>
    public required double CurrentUsage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("currentUsage");
        }
        init { this._rawData.Set("currentUsage", value); }
    }

    /// <summary>
    /// External id of the entity within the customer.
    /// </summary>
    public required string EntityID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("entityId");
        }
        init { this._rawData.Set("entityId", value); }
    }

    /// <summary>
    /// Whether this node alone permits the requested usage.
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
    /// External ids of the entities this budget is scoped to. Empty (`[]`) is the
    /// node-wide budget; a non-empty set is the dimension-scoped budget that matched
    /// this request — use it to tell apart multiple budgets on the same entity.
    /// </summary>
    public required IReadOnlyList<string> ScopeEntityIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("scopeEntityIds");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "scopeEntityIds",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Hard usage limit for this node; null when no assignment is configured.
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
        _ = this.CurrentUsage;
        _ = this.EntityID;
        _ = this.IsGranted;
        _ = this.ScopeEntityIds;
        _ = this.UsageLimit;
    }

    public BetaChainNode() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaChainNode(BetaChainNode betaChainNode)
        : base(betaChainNode) { }
#pragma warning restore CS8618

    public BetaChainNode(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaChainNode(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaChainNodeFromRaw.FromRawUnchecked"/>
    public static BetaChainNode FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaChainNodeFromRaw : IFromRawJson<BetaChainNode>
{
    /// <inheritdoc/>
    public BetaChainNode FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaChainNode.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<FeatureFeature, FeatureFeatureFromRaw>))]
public sealed record class FeatureFeature : JsonModel
{
    /// <summary>
    /// The unique reference ID of the entitlement.
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
    /// The human-readable name of the entitlement, shown in UI elements.
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
    /// The current status of the feature.
    /// </summary>
    public required ApiEnum<string, FeatureStatus> FeatureStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, FeatureStatus>>("featureStatus");
        }
        init { this._rawData.Set("featureStatus", value); }
    }

    /// <summary>
    /// The type of feature associated with the entitlement.
    /// </summary>
    public required ApiEnum<string, FeatureType> FeatureType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, FeatureType>>("featureType");
        }
        init { this._rawData.Set("featureType", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.DisplayName;
        this.FeatureStatus.Validate();
        this.FeatureType.Validate();
    }

    public FeatureFeature() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FeatureFeature(FeatureFeature featureFeature)
        : base(featureFeature) { }
#pragma warning restore CS8618

    public FeatureFeature(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FeatureFeature(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FeatureFeatureFromRaw.FromRawUnchecked"/>
    public static FeatureFeature FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FeatureFeatureFromRaw : IFromRawJson<FeatureFeature>
{
    /// <inheritdoc/>
    public FeatureFeature FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FeatureFeature.FromRawUnchecked(rawData);
}

/// <summary>
/// The current status of the feature.
/// </summary>
[JsonConverter(typeof(FeatureStatusConverter))]
public enum FeatureStatus
{
    New,
    Suspended,
    Active,
}

sealed class FeatureStatusConverter : JsonConverter<FeatureStatus>
{
    public override FeatureStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "NEW" => FeatureStatus.New,
            "SUSPENDED" => FeatureStatus.Suspended,
            "ACTIVE" => FeatureStatus.Active,
            _ => (FeatureStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FeatureStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FeatureStatus.New => "NEW",
                FeatureStatus.Suspended => "SUSPENDED",
                FeatureStatus.Active => "ACTIVE",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The type of feature associated with the entitlement.
/// </summary>
[JsonConverter(typeof(FeatureTypeConverter))]
public enum FeatureType
{
    Boolean,
    Number,
    Enum,
}

sealed class FeatureTypeConverter : JsonConverter<FeatureType>
{
    public override FeatureType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "BOOLEAN" => FeatureType.Boolean,
            "NUMBER" => FeatureType.Number,
            "ENUM" => FeatureType.Enum,
            _ => (FeatureType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FeatureType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FeatureType.Boolean => "BOOLEAN",
                FeatureType.Number => "NUMBER",
                FeatureType.Enum => "ENUM",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ResetPeriodConverter))]
public enum ResetPeriod
{
    Year,
    Month,
    Week,
    Day,
    Hour,
}

sealed class ResetPeriodConverter : JsonConverter<ResetPeriod>
{
    public override ResetPeriod Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "YEAR" => ResetPeriod.Year,
            "MONTH" => ResetPeriod.Month,
            "WEEK" => ResetPeriod.Week,
            "DAY" => ResetPeriod.Day,
            "HOUR" => ResetPeriod.Hour,
            _ => (ResetPeriod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ResetPeriod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ResetPeriod.Year => "YEAR",
                ResetPeriod.Month => "MONTH",
                ResetPeriod.Week => "WEEK",
                ResetPeriod.Day => "DAY",
                ResetPeriod.Hour => "HOUR",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Credit entitlement with optional governance chains attached.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Credit, CreditFromRaw>))]
public sealed record class Credit : JsonModel
{
    public required ApiEnum<string, CreditAccessDeniedReason>? AccessDeniedReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CreditAccessDeniedReason>>(
                "accessDeniedReason"
            );
        }
        init { this._rawData.Set("accessDeniedReason", value); }
    }

    /// <summary>
    /// The currency associated with a credit entitlement.
    /// </summary>
    public required Currency Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Currency>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    public required double CurrentUsage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("currentUsage");
        }
        init { this._rawData.Set("currentUsage", value); }
    }

    public required bool IsGranted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("isGranted");
        }
        init { this._rawData.Set("isGranted", value); }
    }

    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    public required double UsageLimit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("usageLimit");
        }
        init { this._rawData.Set("usageLimit", value); }
    }

    /// <summary>
    /// Timestamp of the last update to the credit usage.
    /// </summary>
    public required DateTimeOffset UsageUpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("usageUpdatedAt");
        }
        init { this._rawData.Set("usageUpdatedAt", value); }
    }

    /// <summary>
    /// Per-entity rollups, one chain per resolved dimension. Omitted when dimensions
    /// was not provided.
    /// </summary>
    public IReadOnlyList<IReadOnlyList<CreditBetaChainNode>>? Chains
    {
        get
        {
            this._rawData.Freeze();
            var value = this._rawData.GetNullableStruct<
                ImmutableArray<ImmutableArray<CreditBetaChainNode>>
            >("chains");
            if (value == null)
            {
                return null;
            }

            return ImmutableArray.ToImmutableArray(
                Enumerable.Select(value.Value, (item) => (IReadOnlyList<CreditBetaChainNode>)item)
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ImmutableArray<CreditBetaChainNode>>?>(
                "chains",
                value == null
                    ? null
                    : ImmutableArray.ToImmutableArray(
                        Enumerable.Select(value, (item) => ImmutableArray.ToImmutableArray(item))
                    )
            );
        }
    }

    /// <summary>
    /// Timestamp of the last update to the entitlement grant or configuration.
    /// </summary>
    public DateTimeOffset? EntitlementUpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("entitlementUpdatedAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("entitlementUpdatedAt", value);
        }
    }

    /// <summary>
    /// The end date of the current billing period for recurring credit grants.
    /// </summary>
    public DateTimeOffset? UsagePeriodEnd
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("usagePeriodEnd");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("usagePeriodEnd", value);
        }
    }

    /// <summary>
    /// The next time the entitlement should be recalculated
    /// </summary>
    public DateTimeOffset? ValidUntil
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("validUntil");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("validUntil", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.AccessDeniedReason?.Validate();
        this.Currency.Validate();
        _ = this.CurrentUsage;
        _ = this.IsGranted;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("CREDIT")))
        {
            throw new StiggInvalidDataException("Invalid value given for constant");
        }
        _ = this.UsageLimit;
        _ = this.UsageUpdatedAt;
        foreach (var item in this.Chains ?? [])
        {
            foreach (var item1 in item)
            {
                item1.Validate();
            }
        }
        _ = this.EntitlementUpdatedAt;
        _ = this.UsagePeriodEnd;
        _ = this.ValidUntil;
    }

    public Credit()
    {
        this.Type = JsonSerializer.SerializeToElement("CREDIT");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Credit(Credit credit)
        : base(credit) { }
#pragma warning restore CS8618

    public Credit(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("CREDIT");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Credit(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreditFromRaw.FromRawUnchecked"/>
    public static Credit FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreditFromRaw : IFromRawJson<Credit>
{
    /// <inheritdoc/>
    public Credit FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Credit.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(CreditAccessDeniedReasonConverter))]
public enum CreditAccessDeniedReason
{
    FeatureNotFound,
    CustomerNotFound,
    CustomerIsArchived,
    CustomerResourceNotFound,
    NoActiveSubscription,
    NoFeatureEntitlementInSubscription,
    RequestedUsageExceedingLimit,
    RequestedValuesMismatch,
    BudgetExceeded,
    Unknown,
    FeatureTypeMismatch,
    Revoked,
    InsufficientCredits,
    EntitlementNotFound,
}

sealed class CreditAccessDeniedReasonConverter : JsonConverter<CreditAccessDeniedReason>
{
    public override CreditAccessDeniedReason Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FeatureNotFound" => CreditAccessDeniedReason.FeatureNotFound,
            "CustomerNotFound" => CreditAccessDeniedReason.CustomerNotFound,
            "CustomerIsArchived" => CreditAccessDeniedReason.CustomerIsArchived,
            "CustomerResourceNotFound" => CreditAccessDeniedReason.CustomerResourceNotFound,
            "NoActiveSubscription" => CreditAccessDeniedReason.NoActiveSubscription,
            "NoFeatureEntitlementInSubscription" =>
                CreditAccessDeniedReason.NoFeatureEntitlementInSubscription,
            "RequestedUsageExceedingLimit" => CreditAccessDeniedReason.RequestedUsageExceedingLimit,
            "RequestedValuesMismatch" => CreditAccessDeniedReason.RequestedValuesMismatch,
            "BudgetExceeded" => CreditAccessDeniedReason.BudgetExceeded,
            "Unknown" => CreditAccessDeniedReason.Unknown,
            "FeatureTypeMismatch" => CreditAccessDeniedReason.FeatureTypeMismatch,
            "Revoked" => CreditAccessDeniedReason.Revoked,
            "InsufficientCredits" => CreditAccessDeniedReason.InsufficientCredits,
            "EntitlementNotFound" => CreditAccessDeniedReason.EntitlementNotFound,
            _ => (CreditAccessDeniedReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CreditAccessDeniedReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CreditAccessDeniedReason.FeatureNotFound => "FeatureNotFound",
                CreditAccessDeniedReason.CustomerNotFound => "CustomerNotFound",
                CreditAccessDeniedReason.CustomerIsArchived => "CustomerIsArchived",
                CreditAccessDeniedReason.CustomerResourceNotFound => "CustomerResourceNotFound",
                CreditAccessDeniedReason.NoActiveSubscription => "NoActiveSubscription",
                CreditAccessDeniedReason.NoFeatureEntitlementInSubscription =>
                    "NoFeatureEntitlementInSubscription",
                CreditAccessDeniedReason.RequestedUsageExceedingLimit =>
                    "RequestedUsageExceedingLimit",
                CreditAccessDeniedReason.RequestedValuesMismatch => "RequestedValuesMismatch",
                CreditAccessDeniedReason.BudgetExceeded => "BudgetExceeded",
                CreditAccessDeniedReason.Unknown => "Unknown",
                CreditAccessDeniedReason.FeatureTypeMismatch => "FeatureTypeMismatch",
                CreditAccessDeniedReason.Revoked => "Revoked",
                CreditAccessDeniedReason.InsufficientCredits => "InsufficientCredits",
                CreditAccessDeniedReason.EntitlementNotFound => "EntitlementNotFound",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The currency associated with a credit entitlement.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Currency, CurrencyFromRaw>))]
public sealed record class Currency : JsonModel
{
    /// <summary>
    /// The unique identifier of the custom currency.
    /// </summary>
    public required string CurrencyID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("currencyId");
        }
        init { this._rawData.Set("currencyId", value); }
    }

    /// <summary>
    /// The display name of the currency.
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
    /// A description of the currency.
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// Additional metadata associated with the currency.
    /// </summary>
    public IReadOnlyDictionary<string, string>? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// The plural form of the currency unit.
    /// </summary>
    public string? UnitPlural
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("unitPlural");
        }
        init { this._rawData.Set("unitPlural", value); }
    }

    /// <summary>
    /// The singular form of the currency unit.
    /// </summary>
    public string? UnitSingular
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("unitSingular");
        }
        init { this._rawData.Set("unitSingular", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CurrencyID;
        _ = this.DisplayName;
        _ = this.Description;
        _ = this.Metadata;
        _ = this.UnitPlural;
        _ = this.UnitSingular;
    }

    public Currency() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Currency(Currency currency)
        : base(currency) { }
#pragma warning restore CS8618

    public Currency(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Currency(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CurrencyFromRaw.FromRawUnchecked"/>
    public static Currency FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CurrencyFromRaw : IFromRawJson<Currency>
{
    /// <inheritdoc/>
    public Currency FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Currency.FromRawUnchecked(rawData);
}

/// <summary>
/// Per-entity governance node — limit and current usage for a single resolved entity.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CreditBetaChainNode, CreditBetaChainNodeFromRaw>))]
public sealed record class CreditBetaChainNode : JsonModel
{
    /// <summary>
    /// Amount consumed by this entity in the current cadence period.
    /// </summary>
    public required double CurrentUsage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("currentUsage");
        }
        init { this._rawData.Set("currentUsage", value); }
    }

    /// <summary>
    /// External id of the entity within the customer.
    /// </summary>
    public required string EntityID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("entityId");
        }
        init { this._rawData.Set("entityId", value); }
    }

    /// <summary>
    /// Whether this node alone permits the requested usage.
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
    /// External ids of the entities this budget is scoped to. Empty (`[]`) is the
    /// node-wide budget; a non-empty set is the dimension-scoped budget that matched
    /// this request — use it to tell apart multiple budgets on the same entity.
    /// </summary>
    public required IReadOnlyList<string> ScopeEntityIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("scopeEntityIds");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "scopeEntityIds",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Hard usage limit for this node; null when no assignment is configured.
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
        _ = this.CurrentUsage;
        _ = this.EntityID;
        _ = this.IsGranted;
        _ = this.ScopeEntityIds;
        _ = this.UsageLimit;
    }

    public CreditBetaChainNode() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreditBetaChainNode(CreditBetaChainNode creditBetaChainNode)
        : base(creditBetaChainNode) { }
#pragma warning restore CS8618

    public CreditBetaChainNode(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditBetaChainNode(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreditBetaChainNodeFromRaw.FromRawUnchecked"/>
    public static CreditBetaChainNode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreditBetaChainNodeFromRaw : IFromRawJson<CreditBetaChainNode>
{
    /// <inheritdoc/>
    public CreditBetaChainNode FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CreditBetaChainNode.FromRawUnchecked(rawData);
}
