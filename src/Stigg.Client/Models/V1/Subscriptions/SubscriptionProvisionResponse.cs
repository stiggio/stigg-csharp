using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using System = System;

namespace Stigg.Client.Models.V1.Subscriptions;

/// <summary>
/// Response object
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<SubscriptionProvisionResponse, SubscriptionProvisionResponseFromRaw>)
)]
public sealed record class SubscriptionProvisionResponse : JsonModel
{
    /// <summary>
    /// Provisioning result with status and subscription or checkout URL.
    /// </summary>
    public required SubscriptionProvisionResponseData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<SubscriptionProvisionResponseData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public SubscriptionProvisionResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionProvisionResponse(
        SubscriptionProvisionResponse subscriptionProvisionResponse
    )
        : base(subscriptionProvisionResponse) { }
#pragma warning restore CS8618

    public SubscriptionProvisionResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionProvisionResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionProvisionResponseFromRaw.FromRawUnchecked"/>
    public static SubscriptionProvisionResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SubscriptionProvisionResponse(SubscriptionProvisionResponseData data)
        : this()
    {
        this.Data = data;
    }
}

class SubscriptionProvisionResponseFromRaw : IFromRawJson<SubscriptionProvisionResponse>
{
    /// <inheritdoc/>
    public SubscriptionProvisionResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionProvisionResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Provisioning result with status and subscription or checkout URL.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionProvisionResponseData,
        SubscriptionProvisionResponseDataFromRaw
    >)
)]
public sealed record class SubscriptionProvisionResponseData : JsonModel
{
    /// <summary>
    /// Unique identifier for the provisioned subscription
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

    public required IReadOnlyList<SubscriptionProvisionResponseDataEntitlement>? Entitlements
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<SubscriptionProvisionResponseDataEntitlement>
            >("entitlements");
        }
        init
        {
            this._rawData.Set<ImmutableArray<SubscriptionProvisionResponseDataEntitlement>?>(
                "entitlements",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Provision status: SUCCESS or PAYMENT_REQUIRED
    /// </summary>
    public required ApiEnum<string, SubscriptionProvisionResponseDataStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, SubscriptionProvisionResponseDataStatus>
            >("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Created subscription (when status is SUCCESS)
    /// </summary>
    public required SubscriptionProvisionResponseDataSubscription? Subscription
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SubscriptionProvisionResponseDataSubscription>(
                "subscription"
            );
        }
        init { this._rawData.Set("subscription", value); }
    }

    /// <summary>
    /// Checkout billing ID when payment is required
    /// </summary>
    public string? CheckoutBillingID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("checkoutBillingId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("checkoutBillingId", value);
        }
    }

    /// <summary>
    /// URL to complete payment when PAYMENT_REQUIRED
    /// </summary>
    public string? CheckoutUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("checkoutUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("checkoutUrl", value);
        }
    }

    /// <summary>
    /// Whether the subscription is scheduled for future activation
    /// </summary>
    public bool? IsScheduled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isScheduled");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isScheduled", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        foreach (var item in this.Entitlements ?? [])
        {
            item.Validate();
        }
        this.Status.Validate();
        this.Subscription?.Validate();
        _ = this.CheckoutBillingID;
        _ = this.CheckoutUrl;
        _ = this.IsScheduled;
    }

    public SubscriptionProvisionResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionProvisionResponseData(
        SubscriptionProvisionResponseData subscriptionProvisionResponseData
    )
        : base(subscriptionProvisionResponseData) { }
#pragma warning restore CS8618

    public SubscriptionProvisionResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionProvisionResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionProvisionResponseDataFromRaw.FromRawUnchecked"/>
    public static SubscriptionProvisionResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionProvisionResponseDataFromRaw : IFromRawJson<SubscriptionProvisionResponseData>
{
    /// <inheritdoc/>
    public SubscriptionProvisionResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionProvisionResponseData.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(SubscriptionProvisionResponseDataEntitlementConverter))]
public record class SubscriptionProvisionResponseDataEntitlement : ModelBase
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
        get
        {
            return Match(
                unionObjectVariant0: (x) => x.IsGranted,
                unionObjectVariant1: (x) => x.IsGranted
            );
        }
    }

    public double? CurrentUsage
    {
        get
        {
            return Match<double?>(
                unionObjectVariant0: (x) => x.CurrentUsage,
                unionObjectVariant1: (x) => x.CurrentUsage
            );
        }
    }

    public System::DateTimeOffset? EntitlementUpdatedAt
    {
        get
        {
            return Match<System::DateTimeOffset?>(
                unionObjectVariant0: (x) => x.EntitlementUpdatedAt,
                unionObjectVariant1: (x) => x.EntitlementUpdatedAt
            );
        }
    }

    public double? UsageLimit
    {
        get
        {
            return Match<double?>(
                unionObjectVariant0: (x) => x.UsageLimit,
                unionObjectVariant1: (x) => x.UsageLimit
            );
        }
    }

    public System::DateTimeOffset? UsagePeriodEnd
    {
        get
        {
            return Match<System::DateTimeOffset?>(
                unionObjectVariant0: (x) => x.UsagePeriodEnd,
                unionObjectVariant1: (x) => x.UsagePeriodEnd
            );
        }
    }

    public System::DateTimeOffset? ValidUntil
    {
        get
        {
            return Match<System::DateTimeOffset?>(
                unionObjectVariant0: (x) => x.ValidUntil,
                unionObjectVariant1: (x) => x.ValidUntil
            );
        }
    }

    public SubscriptionProvisionResponseDataEntitlement(
        UnionObjectVariant0 value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionProvisionResponseDataEntitlement(
        UnionObjectVariant1 value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionProvisionResponseDataEntitlement(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UnionObjectVariant0"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUnionObjectVariant0(out var value)) {
    ///     // `value` is of type `UnionObjectVariant0`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUnionObjectVariant0([NotNullWhen(true)] out UnionObjectVariant0? value)
    {
        value = this.Value as UnionObjectVariant0;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UnionObjectVariant1"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUnionObjectVariant1(out var value)) {
    ///     // `value` is of type `UnionObjectVariant1`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUnionObjectVariant1([NotNullWhen(true)] out UnionObjectVariant1? value)
    {
        value = this.Value as UnionObjectVariant1;
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
    ///     (UnionObjectVariant0 value) =&gt; {...},
    ///     (UnionObjectVariant1 value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<UnionObjectVariant0> unionObjectVariant0,
        System::Action<UnionObjectVariant1> unionObjectVariant1
    )
    {
        switch (this.Value)
        {
            case UnionObjectVariant0 value:
                unionObjectVariant0(value);
                break;
            case UnionObjectVariant1 value:
                unionObjectVariant1(value);
                break;
            default:
                throw new StiggInvalidDataException(
                    "Data did not match any variant of SubscriptionProvisionResponseDataEntitlement"
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
    ///     (UnionObjectVariant0 value) =&gt; {...},
    ///     (UnionObjectVariant1 value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<UnionObjectVariant0, T> unionObjectVariant0,
        System::Func<UnionObjectVariant1, T> unionObjectVariant1
    )
    {
        return this.Value switch
        {
            UnionObjectVariant0 value => unionObjectVariant0(value),
            UnionObjectVariant1 value => unionObjectVariant1(value),
            _ => throw new StiggInvalidDataException(
                "Data did not match any variant of SubscriptionProvisionResponseDataEntitlement"
            ),
        };
    }

    public static implicit operator SubscriptionProvisionResponseDataEntitlement(
        UnionObjectVariant0 value
    ) => new(value);

    public static implicit operator SubscriptionProvisionResponseDataEntitlement(
        UnionObjectVariant1 value
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
                "Data did not match any variant of SubscriptionProvisionResponseDataEntitlement"
            );
        }
        this.Switch(
            (unionObjectVariant0) => unionObjectVariant0.Validate(),
            (unionObjectVariant1) => unionObjectVariant1.Validate()
        );
    }

    public virtual bool Equals(SubscriptionProvisionResponseDataEntitlement? other) =>
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
            UnionObjectVariant0 _ => 0,
            UnionObjectVariant1 _ => 1,
            _ => -1,
        };
    }
}

sealed class SubscriptionProvisionResponseDataEntitlementConverter
    : JsonConverter<SubscriptionProvisionResponseDataEntitlement>
{
    public override SubscriptionProvisionResponseDataEntitlement? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<UnionObjectVariant0>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<UnionObjectVariant1>(element, options);
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
        SubscriptionProvisionResponseDataEntitlement value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<UnionObjectVariant0, UnionObjectVariant0FromRaw>))]
public sealed record class UnionObjectVariant0 : JsonModel
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

    public required ApiEnum<string, UnionObjectVariant0Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, UnionObjectVariant0Type>>("type");
        }
        init { this._rawData.Set("type", value); }
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
    public System::DateTimeOffset? EntitlementUpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("entitlementUpdatedAt");
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

    public UnionObjectVariant0Feature? Feature
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UnionObjectVariant0Feature>("feature");
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

    public ApiEnum<string, UnionObjectVariant0ResetPeriod>? ResetPeriod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, UnionObjectVariant0ResetPeriod>>(
                "resetPeriod"
            );
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
    public System::DateTimeOffset? UsagePeriodAnchor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("usagePeriodAnchor");
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
    public System::DateTimeOffset? UsagePeriodEnd
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("usagePeriodEnd");
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
    public System::DateTimeOffset? UsagePeriodStart
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("usagePeriodStart");
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
    public System::DateTimeOffset? ValidUntil
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("validUntil");
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
        this.Type.Validate();
        _ = this.CurrentUsage;
        _ = this.EntitlementUpdatedAt;
        this.Feature?.Validate();
        _ = this.HasUnlimitedUsage;
        this.ResetPeriod?.Validate();
        _ = this.UsageLimit;
        _ = this.UsagePeriodAnchor;
        _ = this.UsagePeriodEnd;
        _ = this.UsagePeriodStart;
        _ = this.ValidUntil;
    }

    public UnionObjectVariant0() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UnionObjectVariant0(UnionObjectVariant0 unionObjectVariant0)
        : base(unionObjectVariant0) { }
#pragma warning restore CS8618

    public UnionObjectVariant0(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnionObjectVariant0(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UnionObjectVariant0FromRaw.FromRawUnchecked"/>
    public static UnionObjectVariant0 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UnionObjectVariant0FromRaw : IFromRawJson<UnionObjectVariant0>
{
    /// <inheritdoc/>
    public UnionObjectVariant0 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UnionObjectVariant0.FromRawUnchecked(rawData);
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
        System::Type typeToConvert,
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

[JsonConverter(typeof(UnionObjectVariant0TypeConverter))]
public enum UnionObjectVariant0Type
{
    Feature,
}

sealed class UnionObjectVariant0TypeConverter : JsonConverter<UnionObjectVariant0Type>
{
    public override UnionObjectVariant0Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FEATURE" => UnionObjectVariant0Type.Feature,
            _ => (UnionObjectVariant0Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnionObjectVariant0Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UnionObjectVariant0Type.Feature => "FEATURE",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<UnionObjectVariant0Feature, UnionObjectVariant0FeatureFromRaw>)
)]
public sealed record class UnionObjectVariant0Feature : JsonModel
{
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

    /// <summary>
    /// The unique reference ID of the entitlement.
    /// </summary>
    public required string RefID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("refId");
        }
        init { this._rawData.Set("refId", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DisplayName;
        this.FeatureStatus.Validate();
        this.FeatureType.Validate();
        _ = this.RefID;
    }

    public UnionObjectVariant0Feature() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UnionObjectVariant0Feature(UnionObjectVariant0Feature unionObjectVariant0Feature)
        : base(unionObjectVariant0Feature) { }
#pragma warning restore CS8618

    public UnionObjectVariant0Feature(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnionObjectVariant0Feature(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UnionObjectVariant0FeatureFromRaw.FromRawUnchecked"/>
    public static UnionObjectVariant0Feature FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UnionObjectVariant0FeatureFromRaw : IFromRawJson<UnionObjectVariant0Feature>
{
    /// <inheritdoc/>
    public UnionObjectVariant0Feature FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UnionObjectVariant0Feature.FromRawUnchecked(rawData);
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
        System::Type typeToConvert,
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
        System::Type typeToConvert,
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

[JsonConverter(typeof(UnionObjectVariant0ResetPeriodConverter))]
public enum UnionObjectVariant0ResetPeriod
{
    Year,
    Month,
    Week,
    Day,
    Hour,
}

sealed class UnionObjectVariant0ResetPeriodConverter : JsonConverter<UnionObjectVariant0ResetPeriod>
{
    public override UnionObjectVariant0ResetPeriod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "YEAR" => UnionObjectVariant0ResetPeriod.Year,
            "MONTH" => UnionObjectVariant0ResetPeriod.Month,
            "WEEK" => UnionObjectVariant0ResetPeriod.Week,
            "DAY" => UnionObjectVariant0ResetPeriod.Day,
            "HOUR" => UnionObjectVariant0ResetPeriod.Hour,
            _ => (UnionObjectVariant0ResetPeriod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnionObjectVariant0ResetPeriod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UnionObjectVariant0ResetPeriod.Year => "YEAR",
                UnionObjectVariant0ResetPeriod.Month => "MONTH",
                UnionObjectVariant0ResetPeriod.Week => "WEEK",
                UnionObjectVariant0ResetPeriod.Day => "DAY",
                UnionObjectVariant0ResetPeriod.Hour => "HOUR",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<UnionObjectVariant1, UnionObjectVariant1FromRaw>))]
public sealed record class UnionObjectVariant1 : JsonModel
{
    public required ApiEnum<string, UnionObjectVariant1AccessDeniedReason>? AccessDeniedReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, UnionObjectVariant1AccessDeniedReason>
            >("accessDeniedReason");
        }
        init { this._rawData.Set("accessDeniedReason", value); }
    }

    /// <summary>
    /// The currency associated with a credit entitlement.
    /// </summary>
    public required UnionObjectVariant1Currency Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<UnionObjectVariant1Currency>("currency");
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

    public required ApiEnum<string, UnionObjectVariant1Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, UnionObjectVariant1Type>>("type");
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
    public required System::DateTimeOffset UsageUpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("usageUpdatedAt");
        }
        init { this._rawData.Set("usageUpdatedAt", value); }
    }

    /// <summary>
    /// Timestamp of the last update to the entitlement grant or configuration.
    /// </summary>
    public System::DateTimeOffset? EntitlementUpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("entitlementUpdatedAt");
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
    public System::DateTimeOffset? UsagePeriodEnd
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("usagePeriodEnd");
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
    public System::DateTimeOffset? ValidUntil
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("validUntil");
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
        this.Type.Validate();
        _ = this.UsageLimit;
        _ = this.UsageUpdatedAt;
        _ = this.EntitlementUpdatedAt;
        _ = this.UsagePeriodEnd;
        _ = this.ValidUntil;
    }

    public UnionObjectVariant1() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UnionObjectVariant1(UnionObjectVariant1 unionObjectVariant1)
        : base(unionObjectVariant1) { }
#pragma warning restore CS8618

    public UnionObjectVariant1(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnionObjectVariant1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UnionObjectVariant1FromRaw.FromRawUnchecked"/>
    public static UnionObjectVariant1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UnionObjectVariant1FromRaw : IFromRawJson<UnionObjectVariant1>
{
    /// <inheritdoc/>
    public UnionObjectVariant1 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UnionObjectVariant1.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(UnionObjectVariant1AccessDeniedReasonConverter))]
public enum UnionObjectVariant1AccessDeniedReason
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

sealed class UnionObjectVariant1AccessDeniedReasonConverter
    : JsonConverter<UnionObjectVariant1AccessDeniedReason>
{
    public override UnionObjectVariant1AccessDeniedReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FeatureNotFound" => UnionObjectVariant1AccessDeniedReason.FeatureNotFound,
            "CustomerNotFound" => UnionObjectVariant1AccessDeniedReason.CustomerNotFound,
            "CustomerIsArchived" => UnionObjectVariant1AccessDeniedReason.CustomerIsArchived,
            "CustomerResourceNotFound" =>
                UnionObjectVariant1AccessDeniedReason.CustomerResourceNotFound,
            "NoActiveSubscription" => UnionObjectVariant1AccessDeniedReason.NoActiveSubscription,
            "NoFeatureEntitlementInSubscription" =>
                UnionObjectVariant1AccessDeniedReason.NoFeatureEntitlementInSubscription,
            "RequestedUsageExceedingLimit" =>
                UnionObjectVariant1AccessDeniedReason.RequestedUsageExceedingLimit,
            "RequestedValuesMismatch" =>
                UnionObjectVariant1AccessDeniedReason.RequestedValuesMismatch,
            "BudgetExceeded" => UnionObjectVariant1AccessDeniedReason.BudgetExceeded,
            "Unknown" => UnionObjectVariant1AccessDeniedReason.Unknown,
            "FeatureTypeMismatch" => UnionObjectVariant1AccessDeniedReason.FeatureTypeMismatch,
            "Revoked" => UnionObjectVariant1AccessDeniedReason.Revoked,
            "InsufficientCredits" => UnionObjectVariant1AccessDeniedReason.InsufficientCredits,
            "EntitlementNotFound" => UnionObjectVariant1AccessDeniedReason.EntitlementNotFound,
            _ => (UnionObjectVariant1AccessDeniedReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnionObjectVariant1AccessDeniedReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UnionObjectVariant1AccessDeniedReason.FeatureNotFound => "FeatureNotFound",
                UnionObjectVariant1AccessDeniedReason.CustomerNotFound => "CustomerNotFound",
                UnionObjectVariant1AccessDeniedReason.CustomerIsArchived => "CustomerIsArchived",
                UnionObjectVariant1AccessDeniedReason.CustomerResourceNotFound =>
                    "CustomerResourceNotFound",
                UnionObjectVariant1AccessDeniedReason.NoActiveSubscription =>
                    "NoActiveSubscription",
                UnionObjectVariant1AccessDeniedReason.NoFeatureEntitlementInSubscription =>
                    "NoFeatureEntitlementInSubscription",
                UnionObjectVariant1AccessDeniedReason.RequestedUsageExceedingLimit =>
                    "RequestedUsageExceedingLimit",
                UnionObjectVariant1AccessDeniedReason.RequestedValuesMismatch =>
                    "RequestedValuesMismatch",
                UnionObjectVariant1AccessDeniedReason.BudgetExceeded => "BudgetExceeded",
                UnionObjectVariant1AccessDeniedReason.Unknown => "Unknown",
                UnionObjectVariant1AccessDeniedReason.FeatureTypeMismatch => "FeatureTypeMismatch",
                UnionObjectVariant1AccessDeniedReason.Revoked => "Revoked",
                UnionObjectVariant1AccessDeniedReason.InsufficientCredits => "InsufficientCredits",
                UnionObjectVariant1AccessDeniedReason.EntitlementNotFound => "EntitlementNotFound",
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
[JsonConverter(
    typeof(JsonModelConverter<UnionObjectVariant1Currency, UnionObjectVariant1CurrencyFromRaw>)
)]
public sealed record class UnionObjectVariant1Currency : JsonModel
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

    public UnionObjectVariant1Currency() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UnionObjectVariant1Currency(UnionObjectVariant1Currency unionObjectVariant1Currency)
        : base(unionObjectVariant1Currency) { }
#pragma warning restore CS8618

    public UnionObjectVariant1Currency(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnionObjectVariant1Currency(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UnionObjectVariant1CurrencyFromRaw.FromRawUnchecked"/>
    public static UnionObjectVariant1Currency FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UnionObjectVariant1CurrencyFromRaw : IFromRawJson<UnionObjectVariant1Currency>
{
    /// <inheritdoc/>
    public UnionObjectVariant1Currency FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UnionObjectVariant1Currency.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(UnionObjectVariant1TypeConverter))]
public enum UnionObjectVariant1Type
{
    Credit,
}

sealed class UnionObjectVariant1TypeConverter : JsonConverter<UnionObjectVariant1Type>
{
    public override UnionObjectVariant1Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "CREDIT" => UnionObjectVariant1Type.Credit,
            _ => (UnionObjectVariant1Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnionObjectVariant1Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UnionObjectVariant1Type.Credit => "CREDIT",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Provision status: SUCCESS or PAYMENT_REQUIRED
/// </summary>
[JsonConverter(typeof(SubscriptionProvisionResponseDataStatusConverter))]
public enum SubscriptionProvisionResponseDataStatus
{
    Success,
    PaymentRequired,
}

sealed class SubscriptionProvisionResponseDataStatusConverter
    : JsonConverter<SubscriptionProvisionResponseDataStatus>
{
    public override SubscriptionProvisionResponseDataStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SUCCESS" => SubscriptionProvisionResponseDataStatus.Success,
            "PAYMENT_REQUIRED" => SubscriptionProvisionResponseDataStatus.PaymentRequired,
            _ => (SubscriptionProvisionResponseDataStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionProvisionResponseDataStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionProvisionResponseDataStatus.Success => "SUCCESS",
                SubscriptionProvisionResponseDataStatus.PaymentRequired => "PAYMENT_REQUIRED",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Created subscription (when status is SUCCESS)
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionProvisionResponseDataSubscription,
        SubscriptionProvisionResponseDataSubscriptionFromRaw
    >)
)]
public sealed record class SubscriptionProvisionResponseDataSubscription : JsonModel
{
    /// <summary>
    /// Subscription ID
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
    /// Billing ID
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

    /// <summary>
    /// Created at
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
    /// Customer ID
    /// </summary>
    public required string CustomerID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("customerId");
        }
        init { this._rawData.Set("customerId", value); }
    }

    /// <summary>
    /// Payment collection
    /// </summary>
    public required ApiEnum<
        string,
        SubscriptionProvisionResponseDataSubscriptionPaymentCollection
    > PaymentCollection
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionPaymentCollection>
            >("paymentCollection");
        }
        init { this._rawData.Set("paymentCollection", value); }
    }

    /// <summary>
    /// Plan ID
    /// </summary>
    public required string PlanID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("planId");
        }
        init { this._rawData.Set("planId", value); }
    }

    /// <summary>
    /// Pricing type
    /// </summary>
    public required ApiEnum<
        string,
        SubscriptionProvisionResponseDataSubscriptionPricingType
    > PricingType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionPricingType>
            >("pricingType");
        }
        init { this._rawData.Set("pricingType", value); }
    }

    /// <summary>
    /// Subscription start date
    /// </summary>
    public required System::DateTimeOffset StartDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("startDate");
        }
        init { this._rawData.Set("startDate", value); }
    }

    /// <summary>
    /// Subscription status
    /// </summary>
    public required ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionStatus>
            >("status");
        }
        init { this._rawData.Set("status", value); }
    }

    public IReadOnlyList<SubscriptionProvisionResponseDataSubscriptionAddon>? Addons
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<SubscriptionProvisionResponseDataSubscriptionAddon>
            >("addons");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<SubscriptionProvisionResponseDataSubscriptionAddon>?>(
                "addons",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Billing cycle anchor date
    /// </summary>
    public System::DateTimeOffset? BillingCycleAnchor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("billingCycleAnchor");
        }
        init { this._rawData.Set("billingCycleAnchor", value); }
    }

    /// <summary>
    /// Budget configuration
    /// </summary>
    public SubscriptionProvisionResponseDataSubscriptionBudget? Budget
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SubscriptionProvisionResponseDataSubscriptionBudget>(
                "budget"
            );
        }
        init { this._rawData.Set("budget", value); }
    }

    /// <summary>
    /// Subscription cancellation date
    /// </summary>
    public System::DateTimeOffset? CancellationDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("cancellationDate");
        }
        init { this._rawData.Set("cancellationDate", value); }
    }

    /// <summary>
    /// Subscription cancel reason
    /// </summary>
    public ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionCancelReason>? CancelReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionCancelReason>
            >("cancelReason");
        }
        init { this._rawData.Set("cancelReason", value); }
    }

    /// <summary>
    /// Coupons applied to the subscription
    /// </summary>
    public IReadOnlyList<SubscriptionProvisionResponseDataSubscriptionCoupon>? Coupons
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<SubscriptionProvisionResponseDataSubscriptionCoupon>
            >("coupons");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<SubscriptionProvisionResponseDataSubscriptionCoupon>?>(
                "coupons",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// End of the current billing period
    /// </summary>
    public System::DateTimeOffset? CurrentBillingPeriodEnd
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "currentBillingPeriodEnd"
            );
        }
        init { this._rawData.Set("currentBillingPeriodEnd", value); }
    }

    /// <summary>
    /// Start of the current billing period
    /// </summary>
    public System::DateTimeOffset? CurrentBillingPeriodStart
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "currentBillingPeriodStart"
            );
        }
        init { this._rawData.Set("currentBillingPeriodStart", value); }
    }

    /// <summary>
    /// Subscription effective end date
    /// </summary>
    public System::DateTimeOffset? EffectiveEndDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("effectiveEndDate");
        }
        init { this._rawData.Set("effectiveEndDate", value); }
    }

    /// <summary>
    /// Subscription end date
    /// </summary>
    public System::DateTimeOffset? EndDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("endDate");
        }
        init { this._rawData.Set("endDate", value); }
    }

    /// <summary>
    /// Scheduled future updates for the subscription
    /// </summary>
    public IReadOnlyList<SubscriptionProvisionResponseDataSubscriptionFutureUpdate>? FutureUpdates
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<SubscriptionProvisionResponseDataSubscriptionFutureUpdate>
            >("futureUpdates");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<SubscriptionProvisionResponseDataSubscriptionFutureUpdate>?>(
                "futureUpdates",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Latest invoice for the subscription
    /// </summary>
    public SubscriptionProvisionResponseDataSubscriptionLatestInvoice? LatestInvoice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SubscriptionProvisionResponseDataSubscriptionLatestInvoice>(
                "latestInvoice"
            );
        }
        init { this._rawData.Set("latestInvoice", value); }
    }

    /// <summary>
    /// Additional metadata for the subscription
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
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, string>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Minimum spend configuration
    /// </summary>
    public SubscriptionProvisionResponseDataSubscriptionMinimumSpend? MinimumSpend
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SubscriptionProvisionResponseDataSubscriptionMinimumSpend>(
                "minimumSpend"
            );
        }
        init { this._rawData.Set("minimumSpend", value); }
    }

    /// <summary>
    /// Paying customer ID for delegated billing
    /// </summary>
    public string? PayingCustomerID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("payingCustomerId");
        }
        init { this._rawData.Set("payingCustomerId", value); }
    }

    /// <summary>
    /// The method used to collect payments for a subscription
    /// </summary>
    public ApiEnum<
        string,
        SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod
    >? PaymentCollectionMethod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<
                    string,
                    SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod
                >
            >("paymentCollectionMethod");
        }
        init { this._rawData.Set("paymentCollectionMethod", value); }
    }

    public IReadOnlyList<SubscriptionProvisionResponseDataSubscriptionPrice>? Prices
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<SubscriptionProvisionResponseDataSubscriptionPrice>
            >("prices");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<SubscriptionProvisionResponseDataSubscriptionPrice>?>(
                "prices",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Resource ID
    /// </summary>
    public string? ResourceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("resourceId");
        }
        init { this._rawData.Set("resourceId", value); }
    }

    /// <summary>
    /// Entitlements associated with the subscription
    /// </summary>
    public IReadOnlyList<SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlement>? SubscriptionEntitlements
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlement>
            >("subscriptionEntitlements");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlement>?>(
                "subscriptionEntitlements",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Trial configuration
    /// </summary>
    public SubscriptionProvisionResponseDataSubscriptionTrial? Trial
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SubscriptionProvisionResponseDataSubscriptionTrial>(
                "trial"
            );
        }
        init { this._rawData.Set("trial", value); }
    }

    /// <summary>
    /// Subscription trial end date
    /// </summary>
    public System::DateTimeOffset? TrialEndDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("trialEndDate");
        }
        init { this._rawData.Set("trialEndDate", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.BillingID;
        _ = this.CreatedAt;
        _ = this.CustomerID;
        this.PaymentCollection.Validate();
        _ = this.PlanID;
        this.PricingType.Validate();
        _ = this.StartDate;
        this.Status.Validate();
        foreach (var item in this.Addons ?? [])
        {
            item.Validate();
        }
        _ = this.BillingCycleAnchor;
        this.Budget?.Validate();
        _ = this.CancellationDate;
        this.CancelReason?.Validate();
        foreach (var item in this.Coupons ?? [])
        {
            item.Validate();
        }
        _ = this.CurrentBillingPeriodEnd;
        _ = this.CurrentBillingPeriodStart;
        _ = this.EffectiveEndDate;
        _ = this.EndDate;
        foreach (var item in this.FutureUpdates ?? [])
        {
            item.Validate();
        }
        this.LatestInvoice?.Validate();
        _ = this.Metadata;
        this.MinimumSpend?.Validate();
        _ = this.PayingCustomerID;
        this.PaymentCollectionMethod?.Validate();
        foreach (var item in this.Prices ?? [])
        {
            item.Validate();
        }
        _ = this.ResourceID;
        foreach (var item in this.SubscriptionEntitlements ?? [])
        {
            item.Validate();
        }
        this.Trial?.Validate();
        _ = this.TrialEndDate;
    }

    public SubscriptionProvisionResponseDataSubscription() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionProvisionResponseDataSubscription(
        SubscriptionProvisionResponseDataSubscription subscriptionProvisionResponseDataSubscription
    )
        : base(subscriptionProvisionResponseDataSubscription) { }
#pragma warning restore CS8618

    public SubscriptionProvisionResponseDataSubscription(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionProvisionResponseDataSubscription(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionProvisionResponseDataSubscriptionFromRaw.FromRawUnchecked"/>
    public static SubscriptionProvisionResponseDataSubscription FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionProvisionResponseDataSubscriptionFromRaw
    : IFromRawJson<SubscriptionProvisionResponseDataSubscription>
{
    /// <inheritdoc/>
    public SubscriptionProvisionResponseDataSubscription FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionProvisionResponseDataSubscription.FromRawUnchecked(rawData);
}

/// <summary>
/// Payment collection
/// </summary>
[JsonConverter(typeof(SubscriptionProvisionResponseDataSubscriptionPaymentCollectionConverter))]
public enum SubscriptionProvisionResponseDataSubscriptionPaymentCollection
{
    NotRequired,
    Processing,
    Failed,
    ActionRequired,
}

sealed class SubscriptionProvisionResponseDataSubscriptionPaymentCollectionConverter
    : JsonConverter<SubscriptionProvisionResponseDataSubscriptionPaymentCollection>
{
    public override SubscriptionProvisionResponseDataSubscriptionPaymentCollection Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "NOT_REQUIRED" =>
                SubscriptionProvisionResponseDataSubscriptionPaymentCollection.NotRequired,
            "PROCESSING" =>
                SubscriptionProvisionResponseDataSubscriptionPaymentCollection.Processing,
            "FAILED" => SubscriptionProvisionResponseDataSubscriptionPaymentCollection.Failed,
            "ACTION_REQUIRED" =>
                SubscriptionProvisionResponseDataSubscriptionPaymentCollection.ActionRequired,
            _ => (SubscriptionProvisionResponseDataSubscriptionPaymentCollection)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionProvisionResponseDataSubscriptionPaymentCollection value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionProvisionResponseDataSubscriptionPaymentCollection.NotRequired =>
                    "NOT_REQUIRED",
                SubscriptionProvisionResponseDataSubscriptionPaymentCollection.Processing =>
                    "PROCESSING",
                SubscriptionProvisionResponseDataSubscriptionPaymentCollection.Failed => "FAILED",
                SubscriptionProvisionResponseDataSubscriptionPaymentCollection.ActionRequired =>
                    "ACTION_REQUIRED",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Pricing type
/// </summary>
[JsonConverter(typeof(SubscriptionProvisionResponseDataSubscriptionPricingTypeConverter))]
public enum SubscriptionProvisionResponseDataSubscriptionPricingType
{
    Free,
    Paid,
    Custom,
}

sealed class SubscriptionProvisionResponseDataSubscriptionPricingTypeConverter
    : JsonConverter<SubscriptionProvisionResponseDataSubscriptionPricingType>
{
    public override SubscriptionProvisionResponseDataSubscriptionPricingType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FREE" => SubscriptionProvisionResponseDataSubscriptionPricingType.Free,
            "PAID" => SubscriptionProvisionResponseDataSubscriptionPricingType.Paid,
            "CUSTOM" => SubscriptionProvisionResponseDataSubscriptionPricingType.Custom,
            _ => (SubscriptionProvisionResponseDataSubscriptionPricingType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionProvisionResponseDataSubscriptionPricingType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionProvisionResponseDataSubscriptionPricingType.Free => "FREE",
                SubscriptionProvisionResponseDataSubscriptionPricingType.Paid => "PAID",
                SubscriptionProvisionResponseDataSubscriptionPricingType.Custom => "CUSTOM",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Subscription status
/// </summary>
[JsonConverter(typeof(SubscriptionProvisionResponseDataSubscriptionStatusConverter))]
public enum SubscriptionProvisionResponseDataSubscriptionStatus
{
    PaymentPending,
    Active,
    Expired,
    InTrial,
    Canceled,
    NotStarted,
}

sealed class SubscriptionProvisionResponseDataSubscriptionStatusConverter
    : JsonConverter<SubscriptionProvisionResponseDataSubscriptionStatus>
{
    public override SubscriptionProvisionResponseDataSubscriptionStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PAYMENT_PENDING" => SubscriptionProvisionResponseDataSubscriptionStatus.PaymentPending,
            "ACTIVE" => SubscriptionProvisionResponseDataSubscriptionStatus.Active,
            "EXPIRED" => SubscriptionProvisionResponseDataSubscriptionStatus.Expired,
            "IN_TRIAL" => SubscriptionProvisionResponseDataSubscriptionStatus.InTrial,
            "CANCELED" => SubscriptionProvisionResponseDataSubscriptionStatus.Canceled,
            "NOT_STARTED" => SubscriptionProvisionResponseDataSubscriptionStatus.NotStarted,
            _ => (SubscriptionProvisionResponseDataSubscriptionStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionProvisionResponseDataSubscriptionStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionProvisionResponseDataSubscriptionStatus.PaymentPending =>
                    "PAYMENT_PENDING",
                SubscriptionProvisionResponseDataSubscriptionStatus.Active => "ACTIVE",
                SubscriptionProvisionResponseDataSubscriptionStatus.Expired => "EXPIRED",
                SubscriptionProvisionResponseDataSubscriptionStatus.InTrial => "IN_TRIAL",
                SubscriptionProvisionResponseDataSubscriptionStatus.Canceled => "CANCELED",
                SubscriptionProvisionResponseDataSubscriptionStatus.NotStarted => "NOT_STARTED",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Addon configuration
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionProvisionResponseDataSubscriptionAddon,
        SubscriptionProvisionResponseDataSubscriptionAddonFromRaw
    >)
)]
public sealed record class SubscriptionProvisionResponseDataSubscriptionAddon : JsonModel
{
    /// <summary>
    /// Addon ID
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
    /// Number of addon instances
    /// </summary>
    public required long Quantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("quantity");
        }
        init { this._rawData.Set("quantity", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Quantity;
    }

    public SubscriptionProvisionResponseDataSubscriptionAddon() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionProvisionResponseDataSubscriptionAddon(
        SubscriptionProvisionResponseDataSubscriptionAddon subscriptionProvisionResponseDataSubscriptionAddon
    )
        : base(subscriptionProvisionResponseDataSubscriptionAddon) { }
#pragma warning restore CS8618

    public SubscriptionProvisionResponseDataSubscriptionAddon(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionProvisionResponseDataSubscriptionAddon(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionProvisionResponseDataSubscriptionAddonFromRaw.FromRawUnchecked"/>
    public static SubscriptionProvisionResponseDataSubscriptionAddon FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionProvisionResponseDataSubscriptionAddonFromRaw
    : IFromRawJson<SubscriptionProvisionResponseDataSubscriptionAddon>
{
    /// <inheritdoc/>
    public SubscriptionProvisionResponseDataSubscriptionAddon FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionProvisionResponseDataSubscriptionAddon.FromRawUnchecked(rawData);
}

/// <summary>
/// Budget configuration
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionProvisionResponseDataSubscriptionBudget,
        SubscriptionProvisionResponseDataSubscriptionBudgetFromRaw
    >)
)]
public sealed record class SubscriptionProvisionResponseDataSubscriptionBudget : JsonModel
{
    /// <summary>
    /// Whether the budget is a soft limit
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
    /// Maximum spending limit
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

    public SubscriptionProvisionResponseDataSubscriptionBudget() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionProvisionResponseDataSubscriptionBudget(
        SubscriptionProvisionResponseDataSubscriptionBudget subscriptionProvisionResponseDataSubscriptionBudget
    )
        : base(subscriptionProvisionResponseDataSubscriptionBudget) { }
#pragma warning restore CS8618

    public SubscriptionProvisionResponseDataSubscriptionBudget(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionProvisionResponseDataSubscriptionBudget(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionProvisionResponseDataSubscriptionBudgetFromRaw.FromRawUnchecked"/>
    public static SubscriptionProvisionResponseDataSubscriptionBudget FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionProvisionResponseDataSubscriptionBudgetFromRaw
    : IFromRawJson<SubscriptionProvisionResponseDataSubscriptionBudget>
{
    /// <inheritdoc/>
    public SubscriptionProvisionResponseDataSubscriptionBudget FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionProvisionResponseDataSubscriptionBudget.FromRawUnchecked(rawData);
}

/// <summary>
/// Subscription cancel reason
/// </summary>
[JsonConverter(typeof(SubscriptionProvisionResponseDataSubscriptionCancelReasonConverter))]
public enum SubscriptionProvisionResponseDataSubscriptionCancelReason
{
    UpgradeOrDowngrade,
    CancelledByBilling,
    Expired,
    DetachBilling,
    TrialEnded,
    Immediate,
    TrialConverted,
    PendingPaymentExpired,
    ScheduledCancellation,
    CustomerArchived,
    AutoCancellationRule,
}

sealed class SubscriptionProvisionResponseDataSubscriptionCancelReasonConverter
    : JsonConverter<SubscriptionProvisionResponseDataSubscriptionCancelReason>
{
    public override SubscriptionProvisionResponseDataSubscriptionCancelReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "UPGRADE_OR_DOWNGRADE" =>
                SubscriptionProvisionResponseDataSubscriptionCancelReason.UpgradeOrDowngrade,
            "CANCELLED_BY_BILLING" =>
                SubscriptionProvisionResponseDataSubscriptionCancelReason.CancelledByBilling,
            "EXPIRED" => SubscriptionProvisionResponseDataSubscriptionCancelReason.Expired,
            "DETACH_BILLING" =>
                SubscriptionProvisionResponseDataSubscriptionCancelReason.DetachBilling,
            "TRIAL_ENDED" => SubscriptionProvisionResponseDataSubscriptionCancelReason.TrialEnded,
            "Immediate" => SubscriptionProvisionResponseDataSubscriptionCancelReason.Immediate,
            "TRIAL_CONVERTED" =>
                SubscriptionProvisionResponseDataSubscriptionCancelReason.TrialConverted,
            "PENDING_PAYMENT_EXPIRED" =>
                SubscriptionProvisionResponseDataSubscriptionCancelReason.PendingPaymentExpired,
            "ScheduledCancellation" =>
                SubscriptionProvisionResponseDataSubscriptionCancelReason.ScheduledCancellation,
            "CustomerArchived" =>
                SubscriptionProvisionResponseDataSubscriptionCancelReason.CustomerArchived,
            "AutoCancellationRule" =>
                SubscriptionProvisionResponseDataSubscriptionCancelReason.AutoCancellationRule,
            _ => (SubscriptionProvisionResponseDataSubscriptionCancelReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionProvisionResponseDataSubscriptionCancelReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionProvisionResponseDataSubscriptionCancelReason.UpgradeOrDowngrade =>
                    "UPGRADE_OR_DOWNGRADE",
                SubscriptionProvisionResponseDataSubscriptionCancelReason.CancelledByBilling =>
                    "CANCELLED_BY_BILLING",
                SubscriptionProvisionResponseDataSubscriptionCancelReason.Expired => "EXPIRED",
                SubscriptionProvisionResponseDataSubscriptionCancelReason.DetachBilling =>
                    "DETACH_BILLING",
                SubscriptionProvisionResponseDataSubscriptionCancelReason.TrialEnded =>
                    "TRIAL_ENDED",
                SubscriptionProvisionResponseDataSubscriptionCancelReason.Immediate => "Immediate",
                SubscriptionProvisionResponseDataSubscriptionCancelReason.TrialConverted =>
                    "TRIAL_CONVERTED",
                SubscriptionProvisionResponseDataSubscriptionCancelReason.PendingPaymentExpired =>
                    "PENDING_PAYMENT_EXPIRED",
                SubscriptionProvisionResponseDataSubscriptionCancelReason.ScheduledCancellation =>
                    "ScheduledCancellation",
                SubscriptionProvisionResponseDataSubscriptionCancelReason.CustomerArchived =>
                    "CustomerArchived",
                SubscriptionProvisionResponseDataSubscriptionCancelReason.AutoCancellationRule =>
                    "AutoCancellationRule",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Coupon applied to a subscription
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionProvisionResponseDataSubscriptionCoupon,
        SubscriptionProvisionResponseDataSubscriptionCouponFromRaw
    >)
)]
public sealed record class SubscriptionProvisionResponseDataSubscriptionCoupon : JsonModel
{
    /// <summary>
    /// Coupon ID
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
    /// Coupon name
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Coupon status
    /// </summary>
    public required ApiEnum<
        string,
        SubscriptionProvisionResponseDataSubscriptionCouponStatus
    > Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionCouponStatus>
            >("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Fixed amount discounts by currency
    /// </summary>
    public IReadOnlyList<SubscriptionProvisionResponseDataSubscriptionCouponAmountsOff>? AmountsOff
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<SubscriptionProvisionResponseDataSubscriptionCouponAmountsOff>
            >("amountsOff");
        }
        init
        {
            this._rawData.Set<ImmutableArray<SubscriptionProvisionResponseDataSubscriptionCouponAmountsOff>?>(
                "amountsOff",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Percentage discount
    /// </summary>
    public double? PercentOff
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("percentOff");
        }
        init { this._rawData.Set("percentOff", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
        this.Status.Validate();
        foreach (var item in this.AmountsOff ?? [])
        {
            item.Validate();
        }
        _ = this.PercentOff;
    }

    public SubscriptionProvisionResponseDataSubscriptionCoupon() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionProvisionResponseDataSubscriptionCoupon(
        SubscriptionProvisionResponseDataSubscriptionCoupon subscriptionProvisionResponseDataSubscriptionCoupon
    )
        : base(subscriptionProvisionResponseDataSubscriptionCoupon) { }
#pragma warning restore CS8618

    public SubscriptionProvisionResponseDataSubscriptionCoupon(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionProvisionResponseDataSubscriptionCoupon(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionProvisionResponseDataSubscriptionCouponFromRaw.FromRawUnchecked"/>
    public static SubscriptionProvisionResponseDataSubscriptionCoupon FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionProvisionResponseDataSubscriptionCouponFromRaw
    : IFromRawJson<SubscriptionProvisionResponseDataSubscriptionCoupon>
{
    /// <inheritdoc/>
    public SubscriptionProvisionResponseDataSubscriptionCoupon FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionProvisionResponseDataSubscriptionCoupon.FromRawUnchecked(rawData);
}

/// <summary>
/// Coupon status
/// </summary>
[JsonConverter(typeof(SubscriptionProvisionResponseDataSubscriptionCouponStatusConverter))]
public enum SubscriptionProvisionResponseDataSubscriptionCouponStatus
{
    Active,
    Expired,
    Removed,
}

sealed class SubscriptionProvisionResponseDataSubscriptionCouponStatusConverter
    : JsonConverter<SubscriptionProvisionResponseDataSubscriptionCouponStatus>
{
    public override SubscriptionProvisionResponseDataSubscriptionCouponStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ACTIVE" => SubscriptionProvisionResponseDataSubscriptionCouponStatus.Active,
            "EXPIRED" => SubscriptionProvisionResponseDataSubscriptionCouponStatus.Expired,
            "REMOVED" => SubscriptionProvisionResponseDataSubscriptionCouponStatus.Removed,
            _ => (SubscriptionProvisionResponseDataSubscriptionCouponStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionProvisionResponseDataSubscriptionCouponStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionProvisionResponseDataSubscriptionCouponStatus.Active => "ACTIVE",
                SubscriptionProvisionResponseDataSubscriptionCouponStatus.Expired => "EXPIRED",
                SubscriptionProvisionResponseDataSubscriptionCouponStatus.Removed => "REMOVED",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionProvisionResponseDataSubscriptionCouponAmountsOff,
        SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffFromRaw
    >)
)]
public sealed record class SubscriptionProvisionResponseDataSubscriptionCouponAmountsOff : JsonModel
{
    /// <summary>
    /// The price amount
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
    /// The price currency
    /// </summary>
    public ApiEnum<
        string,
        SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency
    >? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<
                    string,
                    SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency
                >
            >("currency");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("currency", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        this.Currency?.Validate();
    }

    public SubscriptionProvisionResponseDataSubscriptionCouponAmountsOff() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionProvisionResponseDataSubscriptionCouponAmountsOff(
        SubscriptionProvisionResponseDataSubscriptionCouponAmountsOff subscriptionProvisionResponseDataSubscriptionCouponAmountsOff
    )
        : base(subscriptionProvisionResponseDataSubscriptionCouponAmountsOff) { }
#pragma warning restore CS8618

    public SubscriptionProvisionResponseDataSubscriptionCouponAmountsOff(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionProvisionResponseDataSubscriptionCouponAmountsOff(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffFromRaw.FromRawUnchecked"/>
    public static SubscriptionProvisionResponseDataSubscriptionCouponAmountsOff FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffFromRaw
    : IFromRawJson<SubscriptionProvisionResponseDataSubscriptionCouponAmountsOff>
{
    /// <inheritdoc/>
    public SubscriptionProvisionResponseDataSubscriptionCouponAmountsOff FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOff.FromRawUnchecked(rawData);
}

/// <summary>
/// The price currency
/// </summary>
[JsonConverter(
    typeof(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrencyConverter)
)]
public enum SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency
{
    Usd,
    Aed,
    All,
    Amd,
    Ang,
    Aud,
    Awg,
    Azn,
    Bam,
    Bbd,
    Bdt,
    Bgn,
    Bif,
    Bmd,
    Bnd,
    Bsd,
    Bwp,
    Byn,
    Bzd,
    Brl,
    Cad,
    Cdf,
    Chf,
    Cny,
    Czk,
    Dkk,
    Dop,
    Dzd,
    Egp,
    Etb,
    Eur,
    Fjd,
    Gbp,
    Gel,
    Gip,
    Gmd,
    Gyd,
    Hkd,
    Hrk,
    Htg,
    Idr,
    Ils,
    Inr,
    Isk,
    Jmd,
    Jpy,
    Kes,
    Kgs,
    Khr,
    Kmf,
    Krw,
    Kyd,
    Kzt,
    Lbp,
    Lkr,
    Lrd,
    Lsl,
    Mad,
    Mdl,
    Mga,
    Mkd,
    Mmk,
    Mnt,
    Mop,
    Mro,
    Mvr,
    Mwk,
    Mxn,
    Myr,
    Mzn,
    Nad,
    Ngn,
    Nok,
    Npr,
    Nzd,
    Pgk,
    Php,
    Pkr,
    Pln,
    Qar,
    Ron,
    Rsd,
    Rub,
    Rwf,
    Sar,
    Sbd,
    Scr,
    Sek,
    Sgd,
    Sle,
    Sll,
    Sos,
    Szl,
    Thb,
    Tjs,
    Top,
    Try,
    Ttd,
    Tzs,
    Uah,
    Uzs,
    Vnd,
    Vuv,
    Wst,
    Xaf,
    Xcd,
    Yer,
    Zar,
    Zmw,
    Clp,
    Djf,
    Gnf,
    Ugx,
    Pyg,
    Xof,
    Xpf,
}

sealed class SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrencyConverter
    : JsonConverter<SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency>
{
    public override SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Usd,
            "aed" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Aed,
            "all" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.All,
            "amd" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Amd,
            "ang" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Ang,
            "aud" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Aud,
            "awg" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Awg,
            "azn" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Azn,
            "bam" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Bam,
            "bbd" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Bbd,
            "bdt" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Bdt,
            "bgn" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Bgn,
            "bif" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Bif,
            "bmd" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Bmd,
            "bnd" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Bnd,
            "bsd" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Bsd,
            "bwp" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Bwp,
            "byn" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Byn,
            "bzd" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Bzd,
            "brl" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Brl,
            "cad" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Cad,
            "cdf" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Cdf,
            "chf" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Chf,
            "cny" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Cny,
            "czk" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Czk,
            "dkk" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Dkk,
            "dop" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Dop,
            "dzd" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Dzd,
            "egp" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Egp,
            "etb" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Etb,
            "eur" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Eur,
            "fjd" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Fjd,
            "gbp" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Gbp,
            "gel" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Gel,
            "gip" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Gip,
            "gmd" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Gmd,
            "gyd" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Gyd,
            "hkd" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Hkd,
            "hrk" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Hrk,
            "htg" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Htg,
            "idr" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Idr,
            "ils" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Ils,
            "inr" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Inr,
            "isk" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Isk,
            "jmd" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Jmd,
            "jpy" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Jpy,
            "kes" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Kes,
            "kgs" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Kgs,
            "khr" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Khr,
            "kmf" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Kmf,
            "krw" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Krw,
            "kyd" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Kyd,
            "kzt" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Kzt,
            "lbp" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Lbp,
            "lkr" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Lkr,
            "lrd" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Lrd,
            "lsl" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Lsl,
            "mad" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Mad,
            "mdl" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Mdl,
            "mga" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Mga,
            "mkd" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Mkd,
            "mmk" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Mmk,
            "mnt" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Mnt,
            "mop" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Mop,
            "mro" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Mro,
            "mvr" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Mvr,
            "mwk" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Mwk,
            "mxn" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Mxn,
            "myr" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Myr,
            "mzn" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Mzn,
            "nad" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Nad,
            "ngn" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Ngn,
            "nok" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Nok,
            "npr" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Npr,
            "nzd" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Nzd,
            "pgk" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Pgk,
            "php" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Php,
            "pkr" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Pkr,
            "pln" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Pln,
            "qar" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Qar,
            "ron" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Ron,
            "rsd" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Rsd,
            "rub" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Rub,
            "rwf" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Rwf,
            "sar" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Sar,
            "sbd" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Sbd,
            "scr" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Scr,
            "sek" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Sek,
            "sgd" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Sgd,
            "sle" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Sle,
            "sll" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Sll,
            "sos" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Sos,
            "szl" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Szl,
            "thb" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Thb,
            "tjs" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Tjs,
            "top" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Top,
            "try" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Try,
            "ttd" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Ttd,
            "tzs" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Tzs,
            "uah" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Uah,
            "uzs" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Uzs,
            "vnd" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Vnd,
            "vuv" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Vuv,
            "wst" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Wst,
            "xaf" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Xaf,
            "xcd" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Xcd,
            "yer" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Yer,
            "zar" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Zar,
            "zmw" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Zmw,
            "clp" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Clp,
            "djf" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Djf,
            "gnf" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Gnf,
            "ugx" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Ugx,
            "pyg" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Pyg,
            "xof" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Xof,
            "xpf" => SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Xpf,
            _ => (SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Usd => "usd",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Aed => "aed",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.All => "all",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Amd => "amd",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Ang => "ang",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Aud => "aud",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Awg => "awg",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Azn => "azn",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Bam => "bam",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Bbd => "bbd",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Bdt => "bdt",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Bgn => "bgn",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Bif => "bif",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Bmd => "bmd",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Bnd => "bnd",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Bsd => "bsd",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Bwp => "bwp",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Byn => "byn",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Bzd => "bzd",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Brl => "brl",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Cad => "cad",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Cdf => "cdf",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Chf => "chf",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Cny => "cny",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Czk => "czk",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Dkk => "dkk",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Dop => "dop",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Dzd => "dzd",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Egp => "egp",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Etb => "etb",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Eur => "eur",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Fjd => "fjd",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Gbp => "gbp",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Gel => "gel",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Gip => "gip",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Gmd => "gmd",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Gyd => "gyd",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Hkd => "hkd",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Hrk => "hrk",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Htg => "htg",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Idr => "idr",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Ils => "ils",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Inr => "inr",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Isk => "isk",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Jmd => "jmd",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Jpy => "jpy",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Kes => "kes",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Kgs => "kgs",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Khr => "khr",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Kmf => "kmf",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Krw => "krw",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Kyd => "kyd",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Kzt => "kzt",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Lbp => "lbp",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Lkr => "lkr",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Lrd => "lrd",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Lsl => "lsl",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Mad => "mad",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Mdl => "mdl",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Mga => "mga",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Mkd => "mkd",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Mmk => "mmk",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Mnt => "mnt",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Mop => "mop",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Mro => "mro",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Mvr => "mvr",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Mwk => "mwk",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Mxn => "mxn",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Myr => "myr",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Mzn => "mzn",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Nad => "nad",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Ngn => "ngn",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Nok => "nok",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Npr => "npr",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Nzd => "nzd",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Pgk => "pgk",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Php => "php",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Pkr => "pkr",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Pln => "pln",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Qar => "qar",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Ron => "ron",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Rsd => "rsd",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Rub => "rub",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Rwf => "rwf",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Sar => "sar",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Sbd => "sbd",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Scr => "scr",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Sek => "sek",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Sgd => "sgd",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Sle => "sle",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Sll => "sll",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Sos => "sos",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Szl => "szl",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Thb => "thb",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Tjs => "tjs",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Top => "top",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Try => "try",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Ttd => "ttd",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Tzs => "tzs",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Uah => "uah",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Uzs => "uzs",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Vnd => "vnd",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Vuv => "vuv",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Wst => "wst",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Xaf => "xaf",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Xcd => "xcd",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Yer => "yer",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Zar => "zar",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Zmw => "zmw",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Clp => "clp",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Djf => "djf",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Gnf => "gnf",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Ugx => "ugx",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Pyg => "pyg",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Xof => "xof",
                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Xpf => "xpf",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Scheduled subscription update
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionProvisionResponseDataSubscriptionFutureUpdate,
        SubscriptionProvisionResponseDataSubscriptionFutureUpdateFromRaw
    >)
)]
public sealed record class SubscriptionProvisionResponseDataSubscriptionFutureUpdate : JsonModel
{
    /// <summary>
    /// Scheduled execution time
    /// </summary>
    public required System::DateTimeOffset ScheduledExecutionTime
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("scheduledExecutionTime");
        }
        init { this._rawData.Set("scheduledExecutionTime", value); }
    }

    /// <summary>
    /// Status of the scheduled update
    /// </summary>
    public required ApiEnum<
        string,
        SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus
    > ScheduleStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus
                >
            >("scheduleStatus");
        }
        init { this._rawData.Set("scheduleStatus", value); }
    }

    /// <summary>
    /// Type of scheduled change
    /// </summary>
    public required ApiEnum<
        string,
        SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType
    > SubscriptionScheduleType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType
                >
            >("subscriptionScheduleType");
        }
        init { this._rawData.Set("subscriptionScheduleType", value); }
    }

    /// <summary>
    /// Target package for the update
    /// </summary>
    public SubscriptionProvisionResponseDataSubscriptionFutureUpdateTargetPackage? TargetPackage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SubscriptionProvisionResponseDataSubscriptionFutureUpdateTargetPackage>(
                "targetPackage"
            );
        }
        init { this._rawData.Set("targetPackage", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ScheduledExecutionTime;
        this.ScheduleStatus.Validate();
        this.SubscriptionScheduleType.Validate();
        this.TargetPackage?.Validate();
    }

    public SubscriptionProvisionResponseDataSubscriptionFutureUpdate() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionProvisionResponseDataSubscriptionFutureUpdate(
        SubscriptionProvisionResponseDataSubscriptionFutureUpdate subscriptionProvisionResponseDataSubscriptionFutureUpdate
    )
        : base(subscriptionProvisionResponseDataSubscriptionFutureUpdate) { }
#pragma warning restore CS8618

    public SubscriptionProvisionResponseDataSubscriptionFutureUpdate(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionProvisionResponseDataSubscriptionFutureUpdate(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionProvisionResponseDataSubscriptionFutureUpdateFromRaw.FromRawUnchecked"/>
    public static SubscriptionProvisionResponseDataSubscriptionFutureUpdate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionProvisionResponseDataSubscriptionFutureUpdateFromRaw
    : IFromRawJson<SubscriptionProvisionResponseDataSubscriptionFutureUpdate>
{
    /// <inheritdoc/>
    public SubscriptionProvisionResponseDataSubscriptionFutureUpdate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionProvisionResponseDataSubscriptionFutureUpdate.FromRawUnchecked(rawData);
}

/// <summary>
/// Status of the scheduled update
/// </summary>
[JsonConverter(
    typeof(SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatusConverter)
)]
public enum SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus
{
    PendingPayment,
    Scheduled,
    Canceled,
    Done,
    Failed,
}

sealed class SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatusConverter
    : JsonConverter<SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus>
{
    public override SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PENDING_PAYMENT" =>
                SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus.PendingPayment,
            "SCHEDULED" =>
                SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus.Scheduled,
            "CANCELED" =>
                SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus.Canceled,
            "DONE" => SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus.Done,
            "FAILED" =>
                SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus.Failed,
            _ => (SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus.PendingPayment =>
                    "PENDING_PAYMENT",
                SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus.Scheduled =>
                    "SCHEDULED",
                SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus.Canceled =>
                    "CANCELED",
                SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus.Done =>
                    "DONE",
                SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus.Failed =>
                    "FAILED",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Type of scheduled change
/// </summary>
[JsonConverter(
    typeof(SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleTypeConverter)
)]
public enum SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType
{
    Downgrade,
    Plan,
    BillingPeriod,
    UnitAmount,
    RecurringCredits,
    PriceOverride,
    Addon,
    Coupon,
    MigrateToLatest,
    AdditionalMetaData,
    BillingInfoMetadata,
}

sealed class SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleTypeConverter
    : JsonConverter<SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType>
{
    public override SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "DOWNGRADE" =>
                SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.Downgrade,
            "PLAN" =>
                SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.Plan,
            "BILLING_PERIOD" =>
                SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.BillingPeriod,
            "UNIT_AMOUNT" =>
                SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.UnitAmount,
            "RECURRING_CREDITS" =>
                SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.RecurringCredits,
            "PRICE_OVERRIDE" =>
                SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.PriceOverride,
            "ADDON" =>
                SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.Addon,
            "COUPON" =>
                SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.Coupon,
            "MIGRATE_TO_LATEST" =>
                SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.MigrateToLatest,
            "ADDITIONAL_META_DATA" =>
                SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.AdditionalMetaData,
            "BILLING_INFO_METADATA" =>
                SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.BillingInfoMetadata,
            _ =>
                (SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.Downgrade =>
                    "DOWNGRADE",
                SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.Plan =>
                    "PLAN",
                SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.BillingPeriod =>
                    "BILLING_PERIOD",
                SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.UnitAmount =>
                    "UNIT_AMOUNT",
                SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.RecurringCredits =>
                    "RECURRING_CREDITS",
                SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.PriceOverride =>
                    "PRICE_OVERRIDE",
                SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.Addon =>
                    "ADDON",
                SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.Coupon =>
                    "COUPON",
                SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.MigrateToLatest =>
                    "MIGRATE_TO_LATEST",
                SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.AdditionalMetaData =>
                    "ADDITIONAL_META_DATA",
                SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.BillingInfoMetadata =>
                    "BILLING_INFO_METADATA",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Target package for the update
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionProvisionResponseDataSubscriptionFutureUpdateTargetPackage,
        SubscriptionProvisionResponseDataSubscriptionFutureUpdateTargetPackageFromRaw
    >)
)]
public sealed record class SubscriptionProvisionResponseDataSubscriptionFutureUpdateTargetPackage
    : JsonModel
{
    /// <summary>
    /// Target package for the update
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
    }

    public SubscriptionProvisionResponseDataSubscriptionFutureUpdateTargetPackage() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionProvisionResponseDataSubscriptionFutureUpdateTargetPackage(
        SubscriptionProvisionResponseDataSubscriptionFutureUpdateTargetPackage subscriptionProvisionResponseDataSubscriptionFutureUpdateTargetPackage
    )
        : base(subscriptionProvisionResponseDataSubscriptionFutureUpdateTargetPackage) { }
#pragma warning restore CS8618

    public SubscriptionProvisionResponseDataSubscriptionFutureUpdateTargetPackage(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionProvisionResponseDataSubscriptionFutureUpdateTargetPackage(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionProvisionResponseDataSubscriptionFutureUpdateTargetPackageFromRaw.FromRawUnchecked"/>
    public static SubscriptionProvisionResponseDataSubscriptionFutureUpdateTargetPackage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SubscriptionProvisionResponseDataSubscriptionFutureUpdateTargetPackage(string id)
        : this()
    {
        this.ID = id;
    }
}

class SubscriptionProvisionResponseDataSubscriptionFutureUpdateTargetPackageFromRaw
    : IFromRawJson<SubscriptionProvisionResponseDataSubscriptionFutureUpdateTargetPackage>
{
    /// <inheritdoc/>
    public SubscriptionProvisionResponseDataSubscriptionFutureUpdateTargetPackage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        SubscriptionProvisionResponseDataSubscriptionFutureUpdateTargetPackage.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Latest invoice for the subscription
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionProvisionResponseDataSubscriptionLatestInvoice,
        SubscriptionProvisionResponseDataSubscriptionLatestInvoiceFromRaw
    >)
)]
public sealed record class SubscriptionProvisionResponseDataSubscriptionLatestInvoice : JsonModel
{
    /// <summary>
    /// Invoice billing ID
    /// </summary>
    public required string BillingID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("billingId");
        }
        init { this._rawData.Set("billingId", value); }
    }

    /// <summary>
    /// Invoice creation date
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
    /// Whether payment requires action
    /// </summary>
    public required bool RequiresAction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("requiresAction");
        }
        init { this._rawData.Set("requiresAction", value); }
    }

    /// <summary>
    /// Invoice status
    /// </summary>
    public required ApiEnum<
        string,
        SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus
    > Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus>
            >("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Amount due
    /// </summary>
    public double? AmountDue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("amountDue");
        }
        init { this._rawData.Set("amountDue", value); }
    }

    /// <summary>
    /// Billing reason
    /// </summary>
    public ApiEnum<
        string,
        SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason
    >? BillingReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<
                    string,
                    SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason
                >
            >("billingReason");
        }
        init { this._rawData.Set("billingReason", value); }
    }

    /// <summary>
    /// Invoice currency
    /// </summary>
    public string? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// Invoice PDF URL
    /// </summary>
    public string? PdfUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("pdfUrl");
        }
        init { this._rawData.Set("pdfUrl", value); }
    }

    /// <summary>
    /// Total amount
    /// </summary>
    public double? Total
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("total");
        }
        init { this._rawData.Set("total", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BillingID;
        _ = this.CreatedAt;
        _ = this.RequiresAction;
        this.Status.Validate();
        _ = this.AmountDue;
        this.BillingReason?.Validate();
        _ = this.Currency;
        _ = this.PdfUrl;
        _ = this.Total;
    }

    public SubscriptionProvisionResponseDataSubscriptionLatestInvoice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionProvisionResponseDataSubscriptionLatestInvoice(
        SubscriptionProvisionResponseDataSubscriptionLatestInvoice subscriptionProvisionResponseDataSubscriptionLatestInvoice
    )
        : base(subscriptionProvisionResponseDataSubscriptionLatestInvoice) { }
#pragma warning restore CS8618

    public SubscriptionProvisionResponseDataSubscriptionLatestInvoice(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionProvisionResponseDataSubscriptionLatestInvoice(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionProvisionResponseDataSubscriptionLatestInvoiceFromRaw.FromRawUnchecked"/>
    public static SubscriptionProvisionResponseDataSubscriptionLatestInvoice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionProvisionResponseDataSubscriptionLatestInvoiceFromRaw
    : IFromRawJson<SubscriptionProvisionResponseDataSubscriptionLatestInvoice>
{
    /// <inheritdoc/>
    public SubscriptionProvisionResponseDataSubscriptionLatestInvoice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionProvisionResponseDataSubscriptionLatestInvoice.FromRawUnchecked(rawData);
}

/// <summary>
/// Invoice status
/// </summary>
[JsonConverter(typeof(SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatusConverter))]
public enum SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus
{
    Open,
    Canceled,
    Paid,
}

sealed class SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatusConverter
    : JsonConverter<SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus>
{
    public override SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "OPEN" => SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus.Open,
            "CANCELED" => SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus.Canceled,
            "PAID" => SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus.Paid,
            _ => (SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus.Open => "OPEN",
                SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus.Canceled =>
                    "CANCELED",
                SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus.Paid => "PAID",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Billing reason
/// </summary>
[JsonConverter(
    typeof(SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReasonConverter)
)]
public enum SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason
{
    BillingCycle,
    SubscriptionCreation,
    SubscriptionUpdate,
    Manual,
    MinimumInvoiceAmountExceeded,
    Other,
}

sealed class SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReasonConverter
    : JsonConverter<SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason>
{
    public override SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "BILLING_CYCLE" =>
                SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason.BillingCycle,
            "SUBSCRIPTION_CREATION" =>
                SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason.SubscriptionCreation,
            "SUBSCRIPTION_UPDATE" =>
                SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason.SubscriptionUpdate,
            "MANUAL" =>
                SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason.Manual,
            "MINIMUM_INVOICE_AMOUNT_EXCEEDED" =>
                SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason.MinimumInvoiceAmountExceeded,
            "OTHER" =>
                SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason.Other,
            _ => (SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason.BillingCycle =>
                    "BILLING_CYCLE",
                SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason.SubscriptionCreation =>
                    "SUBSCRIPTION_CREATION",
                SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason.SubscriptionUpdate =>
                    "SUBSCRIPTION_UPDATE",
                SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason.Manual =>
                    "MANUAL",
                SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason.MinimumInvoiceAmountExceeded =>
                    "MINIMUM_INVOICE_AMOUNT_EXCEEDED",
                SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason.Other =>
                    "OTHER",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Minimum spend configuration
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionProvisionResponseDataSubscriptionMinimumSpend,
        SubscriptionProvisionResponseDataSubscriptionMinimumSpendFromRaw
    >)
)]
public sealed record class SubscriptionProvisionResponseDataSubscriptionMinimumSpend : JsonModel
{
    /// <summary>
    /// The price amount
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
    /// The price currency
    /// </summary>
    public ApiEnum<
        string,
        SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency
    >? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency>
            >("currency");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("currency", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        this.Currency?.Validate();
    }

    public SubscriptionProvisionResponseDataSubscriptionMinimumSpend() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionProvisionResponseDataSubscriptionMinimumSpend(
        SubscriptionProvisionResponseDataSubscriptionMinimumSpend subscriptionProvisionResponseDataSubscriptionMinimumSpend
    )
        : base(subscriptionProvisionResponseDataSubscriptionMinimumSpend) { }
#pragma warning restore CS8618

    public SubscriptionProvisionResponseDataSubscriptionMinimumSpend(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionProvisionResponseDataSubscriptionMinimumSpend(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionProvisionResponseDataSubscriptionMinimumSpendFromRaw.FromRawUnchecked"/>
    public static SubscriptionProvisionResponseDataSubscriptionMinimumSpend FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionProvisionResponseDataSubscriptionMinimumSpendFromRaw
    : IFromRawJson<SubscriptionProvisionResponseDataSubscriptionMinimumSpend>
{
    /// <inheritdoc/>
    public SubscriptionProvisionResponseDataSubscriptionMinimumSpend FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionProvisionResponseDataSubscriptionMinimumSpend.FromRawUnchecked(rawData);
}

/// <summary>
/// The price currency
/// </summary>
[JsonConverter(typeof(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrencyConverter))]
public enum SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency
{
    Usd,
    Aed,
    All,
    Amd,
    Ang,
    Aud,
    Awg,
    Azn,
    Bam,
    Bbd,
    Bdt,
    Bgn,
    Bif,
    Bmd,
    Bnd,
    Bsd,
    Bwp,
    Byn,
    Bzd,
    Brl,
    Cad,
    Cdf,
    Chf,
    Cny,
    Czk,
    Dkk,
    Dop,
    Dzd,
    Egp,
    Etb,
    Eur,
    Fjd,
    Gbp,
    Gel,
    Gip,
    Gmd,
    Gyd,
    Hkd,
    Hrk,
    Htg,
    Idr,
    Ils,
    Inr,
    Isk,
    Jmd,
    Jpy,
    Kes,
    Kgs,
    Khr,
    Kmf,
    Krw,
    Kyd,
    Kzt,
    Lbp,
    Lkr,
    Lrd,
    Lsl,
    Mad,
    Mdl,
    Mga,
    Mkd,
    Mmk,
    Mnt,
    Mop,
    Mro,
    Mvr,
    Mwk,
    Mxn,
    Myr,
    Mzn,
    Nad,
    Ngn,
    Nok,
    Npr,
    Nzd,
    Pgk,
    Php,
    Pkr,
    Pln,
    Qar,
    Ron,
    Rsd,
    Rub,
    Rwf,
    Sar,
    Sbd,
    Scr,
    Sek,
    Sgd,
    Sle,
    Sll,
    Sos,
    Szl,
    Thb,
    Tjs,
    Top,
    Try,
    Ttd,
    Tzs,
    Uah,
    Uzs,
    Vnd,
    Vuv,
    Wst,
    Xaf,
    Xcd,
    Yer,
    Zar,
    Zmw,
    Clp,
    Djf,
    Gnf,
    Ugx,
    Pyg,
    Xof,
    Xpf,
}

sealed class SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrencyConverter
    : JsonConverter<SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency>
{
    public override SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Usd,
            "aed" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Aed,
            "all" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.All,
            "amd" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Amd,
            "ang" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Ang,
            "aud" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Aud,
            "awg" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Awg,
            "azn" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Azn,
            "bam" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Bam,
            "bbd" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Bbd,
            "bdt" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Bdt,
            "bgn" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Bgn,
            "bif" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Bif,
            "bmd" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Bmd,
            "bnd" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Bnd,
            "bsd" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Bsd,
            "bwp" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Bwp,
            "byn" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Byn,
            "bzd" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Bzd,
            "brl" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Brl,
            "cad" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Cad,
            "cdf" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Cdf,
            "chf" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Chf,
            "cny" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Cny,
            "czk" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Czk,
            "dkk" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Dkk,
            "dop" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Dop,
            "dzd" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Dzd,
            "egp" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Egp,
            "etb" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Etb,
            "eur" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Eur,
            "fjd" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Fjd,
            "gbp" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Gbp,
            "gel" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Gel,
            "gip" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Gip,
            "gmd" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Gmd,
            "gyd" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Gyd,
            "hkd" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Hkd,
            "hrk" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Hrk,
            "htg" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Htg,
            "idr" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Idr,
            "ils" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Ils,
            "inr" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Inr,
            "isk" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Isk,
            "jmd" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Jmd,
            "jpy" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Jpy,
            "kes" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Kes,
            "kgs" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Kgs,
            "khr" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Khr,
            "kmf" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Kmf,
            "krw" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Krw,
            "kyd" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Kyd,
            "kzt" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Kzt,
            "lbp" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Lbp,
            "lkr" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Lkr,
            "lrd" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Lrd,
            "lsl" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Lsl,
            "mad" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Mad,
            "mdl" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Mdl,
            "mga" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Mga,
            "mkd" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Mkd,
            "mmk" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Mmk,
            "mnt" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Mnt,
            "mop" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Mop,
            "mro" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Mro,
            "mvr" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Mvr,
            "mwk" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Mwk,
            "mxn" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Mxn,
            "myr" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Myr,
            "mzn" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Mzn,
            "nad" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Nad,
            "ngn" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Ngn,
            "nok" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Nok,
            "npr" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Npr,
            "nzd" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Nzd,
            "pgk" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Pgk,
            "php" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Php,
            "pkr" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Pkr,
            "pln" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Pln,
            "qar" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Qar,
            "ron" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Ron,
            "rsd" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Rsd,
            "rub" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Rub,
            "rwf" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Rwf,
            "sar" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Sar,
            "sbd" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Sbd,
            "scr" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Scr,
            "sek" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Sek,
            "sgd" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Sgd,
            "sle" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Sle,
            "sll" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Sll,
            "sos" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Sos,
            "szl" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Szl,
            "thb" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Thb,
            "tjs" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Tjs,
            "top" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Top,
            "try" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Try,
            "ttd" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Ttd,
            "tzs" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Tzs,
            "uah" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Uah,
            "uzs" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Uzs,
            "vnd" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Vnd,
            "vuv" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Vuv,
            "wst" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Wst,
            "xaf" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Xaf,
            "xcd" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Xcd,
            "yer" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Yer,
            "zar" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Zar,
            "zmw" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Zmw,
            "clp" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Clp,
            "djf" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Djf,
            "gnf" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Gnf,
            "ugx" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Ugx,
            "pyg" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Pyg,
            "xof" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Xof,
            "xpf" => SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Xpf,
            _ => (SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Usd => "usd",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Aed => "aed",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.All => "all",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Amd => "amd",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Ang => "ang",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Aud => "aud",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Awg => "awg",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Azn => "azn",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Bam => "bam",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Bbd => "bbd",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Bdt => "bdt",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Bgn => "bgn",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Bif => "bif",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Bmd => "bmd",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Bnd => "bnd",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Bsd => "bsd",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Bwp => "bwp",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Byn => "byn",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Bzd => "bzd",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Brl => "brl",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Cad => "cad",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Cdf => "cdf",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Chf => "chf",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Cny => "cny",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Czk => "czk",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Dkk => "dkk",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Dop => "dop",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Dzd => "dzd",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Egp => "egp",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Etb => "etb",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Eur => "eur",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Fjd => "fjd",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Gbp => "gbp",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Gel => "gel",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Gip => "gip",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Gmd => "gmd",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Gyd => "gyd",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Hkd => "hkd",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Hrk => "hrk",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Htg => "htg",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Idr => "idr",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Ils => "ils",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Inr => "inr",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Isk => "isk",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Jmd => "jmd",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Jpy => "jpy",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Kes => "kes",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Kgs => "kgs",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Khr => "khr",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Kmf => "kmf",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Krw => "krw",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Kyd => "kyd",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Kzt => "kzt",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Lbp => "lbp",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Lkr => "lkr",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Lrd => "lrd",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Lsl => "lsl",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Mad => "mad",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Mdl => "mdl",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Mga => "mga",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Mkd => "mkd",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Mmk => "mmk",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Mnt => "mnt",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Mop => "mop",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Mro => "mro",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Mvr => "mvr",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Mwk => "mwk",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Mxn => "mxn",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Myr => "myr",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Mzn => "mzn",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Nad => "nad",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Ngn => "ngn",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Nok => "nok",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Npr => "npr",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Nzd => "nzd",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Pgk => "pgk",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Php => "php",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Pkr => "pkr",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Pln => "pln",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Qar => "qar",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Ron => "ron",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Rsd => "rsd",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Rub => "rub",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Rwf => "rwf",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Sar => "sar",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Sbd => "sbd",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Scr => "scr",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Sek => "sek",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Sgd => "sgd",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Sle => "sle",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Sll => "sll",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Sos => "sos",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Szl => "szl",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Thb => "thb",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Tjs => "tjs",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Top => "top",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Try => "try",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Ttd => "ttd",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Tzs => "tzs",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Uah => "uah",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Uzs => "uzs",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Vnd => "vnd",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Vuv => "vuv",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Wst => "wst",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Xaf => "xaf",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Xcd => "xcd",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Yer => "yer",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Zar => "zar",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Zmw => "zmw",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Clp => "clp",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Djf => "djf",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Gnf => "gnf",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Ugx => "ugx",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Pyg => "pyg",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Xof => "xof",
                SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Xpf => "xpf",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The method used to collect payments for a subscription
/// </summary>
[JsonConverter(
    typeof(SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethodConverter)
)]
public enum SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod
{
    Charge,
    Invoice,
    None,
}

sealed class SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethodConverter
    : JsonConverter<SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod>
{
    public override SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "CHARGE" => SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.Charge,
            "INVOICE" =>
                SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.Invoice,
            "NONE" => SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.None,
            _ => (SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.Charge =>
                    "CHARGE",
                SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.Invoice =>
                    "INVOICE",
                SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.None => "NONE",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionProvisionResponseDataSubscriptionPrice,
        SubscriptionProvisionResponseDataSubscriptionPriceFromRaw
    >)
)]
public sealed record class SubscriptionProvisionResponseDataSubscriptionPrice : JsonModel
{
    /// <summary>
    /// Addon identifier for the price override
    /// </summary>
    public string? AddonID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("addonId");
        }
        init { this._rawData.Set("addonId", value); }
    }

    /// <summary>
    /// The price amount
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
    /// Whether this is a base charge override
    /// </summary>
    public bool? BaseCharge
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("baseCharge");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("baseCharge", value);
        }
    }

    /// <summary>
    /// The billing country code of the price
    /// </summary>
    public string? BillingCountryCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billingCountryCode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("billingCountryCode", value);
        }
    }

    /// <summary>
    /// Block size for pricing
    /// </summary>
    public double? BlockSize
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("blockSize");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("blockSize", value);
        }
    }

    /// <summary>
    /// The price currency
    /// </summary>
    public ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionPriceCurrency>? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionPriceCurrency>
            >("currency");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("currency", value);
        }
    }

    /// <summary>
    /// Feature identifier for the price override
    /// </summary>
    public string? FeatureID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("featureId");
        }
        init { this._rawData.Set("featureId", value); }
    }

    /// <summary>
    /// Pricing tiers configuration
    /// </summary>
    public IReadOnlyList<SubscriptionProvisionResponseDataSubscriptionPriceTier>? Tiers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<SubscriptionProvisionResponseDataSubscriptionPriceTier>
            >("tiers");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<SubscriptionProvisionResponseDataSubscriptionPriceTier>?>(
                "tiers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AddonID;
        _ = this.Amount;
        _ = this.BaseCharge;
        _ = this.BillingCountryCode;
        _ = this.BlockSize;
        this.Currency?.Validate();
        _ = this.FeatureID;
        foreach (var item in this.Tiers ?? [])
        {
            item.Validate();
        }
    }

    public SubscriptionProvisionResponseDataSubscriptionPrice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionProvisionResponseDataSubscriptionPrice(
        SubscriptionProvisionResponseDataSubscriptionPrice subscriptionProvisionResponseDataSubscriptionPrice
    )
        : base(subscriptionProvisionResponseDataSubscriptionPrice) { }
#pragma warning restore CS8618

    public SubscriptionProvisionResponseDataSubscriptionPrice(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionProvisionResponseDataSubscriptionPrice(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionProvisionResponseDataSubscriptionPriceFromRaw.FromRawUnchecked"/>
    public static SubscriptionProvisionResponseDataSubscriptionPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionProvisionResponseDataSubscriptionPriceFromRaw
    : IFromRawJson<SubscriptionProvisionResponseDataSubscriptionPrice>
{
    /// <inheritdoc/>
    public SubscriptionProvisionResponseDataSubscriptionPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionProvisionResponseDataSubscriptionPrice.FromRawUnchecked(rawData);
}

/// <summary>
/// The price currency
/// </summary>
[JsonConverter(typeof(SubscriptionProvisionResponseDataSubscriptionPriceCurrencyConverter))]
public enum SubscriptionProvisionResponseDataSubscriptionPriceCurrency
{
    Usd,
    Aed,
    All,
    Amd,
    Ang,
    Aud,
    Awg,
    Azn,
    Bam,
    Bbd,
    Bdt,
    Bgn,
    Bif,
    Bmd,
    Bnd,
    Bsd,
    Bwp,
    Byn,
    Bzd,
    Brl,
    Cad,
    Cdf,
    Chf,
    Cny,
    Czk,
    Dkk,
    Dop,
    Dzd,
    Egp,
    Etb,
    Eur,
    Fjd,
    Gbp,
    Gel,
    Gip,
    Gmd,
    Gyd,
    Hkd,
    Hrk,
    Htg,
    Idr,
    Ils,
    Inr,
    Isk,
    Jmd,
    Jpy,
    Kes,
    Kgs,
    Khr,
    Kmf,
    Krw,
    Kyd,
    Kzt,
    Lbp,
    Lkr,
    Lrd,
    Lsl,
    Mad,
    Mdl,
    Mga,
    Mkd,
    Mmk,
    Mnt,
    Mop,
    Mro,
    Mvr,
    Mwk,
    Mxn,
    Myr,
    Mzn,
    Nad,
    Ngn,
    Nok,
    Npr,
    Nzd,
    Pgk,
    Php,
    Pkr,
    Pln,
    Qar,
    Ron,
    Rsd,
    Rub,
    Rwf,
    Sar,
    Sbd,
    Scr,
    Sek,
    Sgd,
    Sle,
    Sll,
    Sos,
    Szl,
    Thb,
    Tjs,
    Top,
    Try,
    Ttd,
    Tzs,
    Uah,
    Uzs,
    Vnd,
    Vuv,
    Wst,
    Xaf,
    Xcd,
    Yer,
    Zar,
    Zmw,
    Clp,
    Djf,
    Gnf,
    Ugx,
    Pyg,
    Xof,
    Xpf,
}

sealed class SubscriptionProvisionResponseDataSubscriptionPriceCurrencyConverter
    : JsonConverter<SubscriptionProvisionResponseDataSubscriptionPriceCurrency>
{
    public override SubscriptionProvisionResponseDataSubscriptionPriceCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Usd,
            "aed" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Aed,
            "all" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.All,
            "amd" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Amd,
            "ang" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Ang,
            "aud" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Aud,
            "awg" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Awg,
            "azn" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Azn,
            "bam" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Bam,
            "bbd" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Bbd,
            "bdt" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Bdt,
            "bgn" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Bgn,
            "bif" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Bif,
            "bmd" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Bmd,
            "bnd" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Bnd,
            "bsd" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Bsd,
            "bwp" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Bwp,
            "byn" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Byn,
            "bzd" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Bzd,
            "brl" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Brl,
            "cad" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Cad,
            "cdf" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Cdf,
            "chf" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Chf,
            "cny" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Cny,
            "czk" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Czk,
            "dkk" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Dkk,
            "dop" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Dop,
            "dzd" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Dzd,
            "egp" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Egp,
            "etb" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Etb,
            "eur" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Eur,
            "fjd" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Fjd,
            "gbp" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Gbp,
            "gel" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Gel,
            "gip" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Gip,
            "gmd" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Gmd,
            "gyd" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Gyd,
            "hkd" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Hkd,
            "hrk" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Hrk,
            "htg" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Htg,
            "idr" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Idr,
            "ils" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Ils,
            "inr" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Inr,
            "isk" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Isk,
            "jmd" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Jmd,
            "jpy" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Jpy,
            "kes" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Kes,
            "kgs" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Kgs,
            "khr" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Khr,
            "kmf" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Kmf,
            "krw" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Krw,
            "kyd" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Kyd,
            "kzt" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Kzt,
            "lbp" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Lbp,
            "lkr" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Lkr,
            "lrd" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Lrd,
            "lsl" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Lsl,
            "mad" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Mad,
            "mdl" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Mdl,
            "mga" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Mga,
            "mkd" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Mkd,
            "mmk" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Mmk,
            "mnt" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Mnt,
            "mop" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Mop,
            "mro" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Mro,
            "mvr" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Mvr,
            "mwk" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Mwk,
            "mxn" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Mxn,
            "myr" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Myr,
            "mzn" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Mzn,
            "nad" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Nad,
            "ngn" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Ngn,
            "nok" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Nok,
            "npr" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Npr,
            "nzd" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Nzd,
            "pgk" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Pgk,
            "php" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Php,
            "pkr" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Pkr,
            "pln" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Pln,
            "qar" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Qar,
            "ron" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Ron,
            "rsd" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Rsd,
            "rub" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Rub,
            "rwf" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Rwf,
            "sar" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Sar,
            "sbd" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Sbd,
            "scr" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Scr,
            "sek" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Sek,
            "sgd" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Sgd,
            "sle" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Sle,
            "sll" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Sll,
            "sos" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Sos,
            "szl" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Szl,
            "thb" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Thb,
            "tjs" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Tjs,
            "top" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Top,
            "try" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Try,
            "ttd" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Ttd,
            "tzs" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Tzs,
            "uah" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Uah,
            "uzs" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Uzs,
            "vnd" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Vnd,
            "vuv" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Vuv,
            "wst" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Wst,
            "xaf" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Xaf,
            "xcd" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Xcd,
            "yer" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Yer,
            "zar" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Zar,
            "zmw" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Zmw,
            "clp" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Clp,
            "djf" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Djf,
            "gnf" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Gnf,
            "ugx" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Ugx,
            "pyg" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Pyg,
            "xof" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Xof,
            "xpf" => SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Xpf,
            _ => (SubscriptionProvisionResponseDataSubscriptionPriceCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionProvisionResponseDataSubscriptionPriceCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Usd => "usd",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Aed => "aed",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.All => "all",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Amd => "amd",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Ang => "ang",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Aud => "aud",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Awg => "awg",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Azn => "azn",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Bam => "bam",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Bbd => "bbd",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Bdt => "bdt",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Bgn => "bgn",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Bif => "bif",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Bmd => "bmd",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Bnd => "bnd",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Bsd => "bsd",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Bwp => "bwp",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Byn => "byn",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Bzd => "bzd",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Brl => "brl",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Cad => "cad",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Cdf => "cdf",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Chf => "chf",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Cny => "cny",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Czk => "czk",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Dkk => "dkk",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Dop => "dop",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Dzd => "dzd",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Egp => "egp",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Etb => "etb",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Eur => "eur",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Fjd => "fjd",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Gbp => "gbp",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Gel => "gel",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Gip => "gip",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Gmd => "gmd",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Gyd => "gyd",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Hkd => "hkd",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Hrk => "hrk",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Htg => "htg",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Idr => "idr",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Ils => "ils",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Inr => "inr",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Isk => "isk",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Jmd => "jmd",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Jpy => "jpy",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Kes => "kes",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Kgs => "kgs",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Khr => "khr",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Kmf => "kmf",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Krw => "krw",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Kyd => "kyd",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Kzt => "kzt",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Lbp => "lbp",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Lkr => "lkr",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Lrd => "lrd",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Lsl => "lsl",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Mad => "mad",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Mdl => "mdl",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Mga => "mga",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Mkd => "mkd",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Mmk => "mmk",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Mnt => "mnt",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Mop => "mop",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Mro => "mro",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Mvr => "mvr",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Mwk => "mwk",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Mxn => "mxn",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Myr => "myr",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Mzn => "mzn",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Nad => "nad",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Ngn => "ngn",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Nok => "nok",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Npr => "npr",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Nzd => "nzd",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Pgk => "pgk",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Php => "php",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Pkr => "pkr",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Pln => "pln",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Qar => "qar",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Ron => "ron",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Rsd => "rsd",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Rub => "rub",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Rwf => "rwf",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Sar => "sar",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Sbd => "sbd",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Scr => "scr",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Sek => "sek",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Sgd => "sgd",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Sle => "sle",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Sll => "sll",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Sos => "sos",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Szl => "szl",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Thb => "thb",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Tjs => "tjs",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Top => "top",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Try => "try",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Ttd => "ttd",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Tzs => "tzs",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Uah => "uah",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Uzs => "uzs",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Vnd => "vnd",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Vuv => "vuv",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Wst => "wst",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Xaf => "xaf",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Xcd => "xcd",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Yer => "yer",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Zar => "zar",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Zmw => "zmw",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Clp => "clp",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Djf => "djf",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Gnf => "gnf",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Ugx => "ugx",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Pyg => "pyg",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Xof => "xof",
                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Xpf => "xpf",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionProvisionResponseDataSubscriptionPriceTier,
        SubscriptionProvisionResponseDataSubscriptionPriceTierFromRaw
    >)
)]
public sealed record class SubscriptionProvisionResponseDataSubscriptionPriceTier : JsonModel
{
    /// <summary>
    /// The flat fee price of the price tier
    /// </summary>
    public SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPrice? FlatPrice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPrice>(
                "flatPrice"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("flatPrice", value);
        }
    }

    /// <summary>
    /// The unit price of the price tier
    /// </summary>
    public SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPrice? UnitPrice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPrice>(
                "unitPrice"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("unitPrice", value);
        }
    }

    /// <summary>
    /// The up to quantity of the price tier
    /// </summary>
    public double? UpTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("upTo");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("upTo", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.FlatPrice?.Validate();
        this.UnitPrice?.Validate();
        _ = this.UpTo;
    }

    public SubscriptionProvisionResponseDataSubscriptionPriceTier() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionProvisionResponseDataSubscriptionPriceTier(
        SubscriptionProvisionResponseDataSubscriptionPriceTier subscriptionProvisionResponseDataSubscriptionPriceTier
    )
        : base(subscriptionProvisionResponseDataSubscriptionPriceTier) { }
#pragma warning restore CS8618

    public SubscriptionProvisionResponseDataSubscriptionPriceTier(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionProvisionResponseDataSubscriptionPriceTier(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionProvisionResponseDataSubscriptionPriceTierFromRaw.FromRawUnchecked"/>
    public static SubscriptionProvisionResponseDataSubscriptionPriceTier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionProvisionResponseDataSubscriptionPriceTierFromRaw
    : IFromRawJson<SubscriptionProvisionResponseDataSubscriptionPriceTier>
{
    /// <inheritdoc/>
    public SubscriptionProvisionResponseDataSubscriptionPriceTier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionProvisionResponseDataSubscriptionPriceTier.FromRawUnchecked(rawData);
}

/// <summary>
/// The flat fee price of the price tier
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPrice,
        SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceFromRaw
    >)
)]
public sealed record class SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPrice
    : JsonModel
{
    /// <summary>
    /// The price amount
    /// </summary>
    public required double Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    /// <summary>
    /// ISO 4217 currency code
    /// </summary>
    public required ApiEnum<
        string,
        SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency
    > Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency
                >
            >("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        this.Currency.Validate();
    }

    public SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPrice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPrice(
        SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPrice subscriptionProvisionResponseDataSubscriptionPriceTierFlatPrice
    )
        : base(subscriptionProvisionResponseDataSubscriptionPriceTierFlatPrice) { }
#pragma warning restore CS8618

    public SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPrice(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPrice(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceFromRaw.FromRawUnchecked"/>
    public static SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceFromRaw
    : IFromRawJson<SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPrice>
{
    /// <inheritdoc/>
    public SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPrice.FromRawUnchecked(rawData);
}

/// <summary>
/// ISO 4217 currency code
/// </summary>
[JsonConverter(
    typeof(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrencyConverter)
)]
public enum SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency
{
    Usd,
    Aed,
    All,
    Amd,
    Ang,
    Aud,
    Awg,
    Azn,
    Bam,
    Bbd,
    Bdt,
    Bgn,
    Bif,
    Bmd,
    Bnd,
    Bsd,
    Bwp,
    Byn,
    Bzd,
    Brl,
    Cad,
    Cdf,
    Chf,
    Cny,
    Czk,
    Dkk,
    Dop,
    Dzd,
    Egp,
    Etb,
    Eur,
    Fjd,
    Gbp,
    Gel,
    Gip,
    Gmd,
    Gyd,
    Hkd,
    Hrk,
    Htg,
    Idr,
    Ils,
    Inr,
    Isk,
    Jmd,
    Jpy,
    Kes,
    Kgs,
    Khr,
    Kmf,
    Krw,
    Kyd,
    Kzt,
    Lbp,
    Lkr,
    Lrd,
    Lsl,
    Mad,
    Mdl,
    Mga,
    Mkd,
    Mmk,
    Mnt,
    Mop,
    Mro,
    Mvr,
    Mwk,
    Mxn,
    Myr,
    Mzn,
    Nad,
    Ngn,
    Nok,
    Npr,
    Nzd,
    Pgk,
    Php,
    Pkr,
    Pln,
    Qar,
    Ron,
    Rsd,
    Rub,
    Rwf,
    Sar,
    Sbd,
    Scr,
    Sek,
    Sgd,
    Sle,
    Sll,
    Sos,
    Szl,
    Thb,
    Tjs,
    Top,
    Try,
    Ttd,
    Tzs,
    Uah,
    Uzs,
    Vnd,
    Vuv,
    Wst,
    Xaf,
    Xcd,
    Yer,
    Zar,
    Zmw,
    Clp,
    Djf,
    Gnf,
    Ugx,
    Pyg,
    Xof,
    Xpf,
}

sealed class SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrencyConverter
    : JsonConverter<SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency>
{
    public override SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
            "aed" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Aed,
            "all" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.All,
            "amd" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Amd,
            "ang" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Ang,
            "aud" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Aud,
            "awg" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Awg,
            "azn" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Azn,
            "bam" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Bam,
            "bbd" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Bbd,
            "bdt" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Bdt,
            "bgn" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Bgn,
            "bif" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Bif,
            "bmd" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Bmd,
            "bnd" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Bnd,
            "bsd" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Bsd,
            "bwp" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Bwp,
            "byn" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Byn,
            "bzd" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Bzd,
            "brl" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Brl,
            "cad" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Cad,
            "cdf" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Cdf,
            "chf" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Chf,
            "cny" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Cny,
            "czk" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Czk,
            "dkk" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Dkk,
            "dop" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Dop,
            "dzd" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Dzd,
            "egp" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Egp,
            "etb" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Etb,
            "eur" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Eur,
            "fjd" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Fjd,
            "gbp" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Gbp,
            "gel" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Gel,
            "gip" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Gip,
            "gmd" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Gmd,
            "gyd" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Gyd,
            "hkd" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Hkd,
            "hrk" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Hrk,
            "htg" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Htg,
            "idr" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Idr,
            "ils" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Ils,
            "inr" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Inr,
            "isk" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Isk,
            "jmd" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Jmd,
            "jpy" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Jpy,
            "kes" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Kes,
            "kgs" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Kgs,
            "khr" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Khr,
            "kmf" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Kmf,
            "krw" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Krw,
            "kyd" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Kyd,
            "kzt" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Kzt,
            "lbp" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Lbp,
            "lkr" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Lkr,
            "lrd" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Lrd,
            "lsl" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Lsl,
            "mad" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mad,
            "mdl" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mdl,
            "mga" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mga,
            "mkd" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mkd,
            "mmk" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mmk,
            "mnt" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mnt,
            "mop" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mop,
            "mro" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mro,
            "mvr" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mvr,
            "mwk" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mwk,
            "mxn" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mxn,
            "myr" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Myr,
            "mzn" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mzn,
            "nad" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Nad,
            "ngn" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Ngn,
            "nok" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Nok,
            "npr" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Npr,
            "nzd" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Nzd,
            "pgk" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Pgk,
            "php" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Php,
            "pkr" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Pkr,
            "pln" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Pln,
            "qar" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Qar,
            "ron" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Ron,
            "rsd" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Rsd,
            "rub" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Rub,
            "rwf" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Rwf,
            "sar" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Sar,
            "sbd" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Sbd,
            "scr" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Scr,
            "sek" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Sek,
            "sgd" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Sgd,
            "sle" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Sle,
            "sll" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Sll,
            "sos" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Sos,
            "szl" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Szl,
            "thb" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Thb,
            "tjs" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Tjs,
            "top" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Top,
            "try" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Try,
            "ttd" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Ttd,
            "tzs" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Tzs,
            "uah" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Uah,
            "uzs" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Uzs,
            "vnd" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Vnd,
            "vuv" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Vuv,
            "wst" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Wst,
            "xaf" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Xaf,
            "xcd" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Xcd,
            "yer" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Yer,
            "zar" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Zar,
            "zmw" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Zmw,
            "clp" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Clp,
            "djf" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Djf,
            "gnf" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Gnf,
            "ugx" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Ugx,
            "pyg" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Pyg,
            "xof" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Xof,
            "xpf" => SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Xpf,
            _ => (SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd =>
                    "usd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Aed =>
                    "aed",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.All =>
                    "all",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Amd =>
                    "amd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Ang =>
                    "ang",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Aud =>
                    "aud",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Awg =>
                    "awg",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Azn =>
                    "azn",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Bam =>
                    "bam",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Bbd =>
                    "bbd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Bdt =>
                    "bdt",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Bgn =>
                    "bgn",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Bif =>
                    "bif",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Bmd =>
                    "bmd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Bnd =>
                    "bnd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Bsd =>
                    "bsd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Bwp =>
                    "bwp",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Byn =>
                    "byn",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Bzd =>
                    "bzd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Brl =>
                    "brl",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Cad =>
                    "cad",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Cdf =>
                    "cdf",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Chf =>
                    "chf",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Cny =>
                    "cny",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Czk =>
                    "czk",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Dkk =>
                    "dkk",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Dop =>
                    "dop",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Dzd =>
                    "dzd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Egp =>
                    "egp",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Etb =>
                    "etb",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Eur =>
                    "eur",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Fjd =>
                    "fjd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Gbp =>
                    "gbp",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Gel =>
                    "gel",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Gip =>
                    "gip",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Gmd =>
                    "gmd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Gyd =>
                    "gyd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Hkd =>
                    "hkd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Hrk =>
                    "hrk",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Htg =>
                    "htg",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Idr =>
                    "idr",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Ils =>
                    "ils",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Inr =>
                    "inr",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Isk =>
                    "isk",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Jmd =>
                    "jmd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Jpy =>
                    "jpy",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Kes =>
                    "kes",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Kgs =>
                    "kgs",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Khr =>
                    "khr",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Kmf =>
                    "kmf",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Krw =>
                    "krw",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Kyd =>
                    "kyd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Kzt =>
                    "kzt",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Lbp =>
                    "lbp",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Lkr =>
                    "lkr",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Lrd =>
                    "lrd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Lsl =>
                    "lsl",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mad =>
                    "mad",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mdl =>
                    "mdl",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mga =>
                    "mga",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mkd =>
                    "mkd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mmk =>
                    "mmk",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mnt =>
                    "mnt",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mop =>
                    "mop",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mro =>
                    "mro",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mvr =>
                    "mvr",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mwk =>
                    "mwk",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mxn =>
                    "mxn",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Myr =>
                    "myr",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mzn =>
                    "mzn",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Nad =>
                    "nad",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Ngn =>
                    "ngn",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Nok =>
                    "nok",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Npr =>
                    "npr",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Nzd =>
                    "nzd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Pgk =>
                    "pgk",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Php =>
                    "php",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Pkr =>
                    "pkr",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Pln =>
                    "pln",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Qar =>
                    "qar",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Ron =>
                    "ron",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Rsd =>
                    "rsd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Rub =>
                    "rub",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Rwf =>
                    "rwf",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Sar =>
                    "sar",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Sbd =>
                    "sbd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Scr =>
                    "scr",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Sek =>
                    "sek",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Sgd =>
                    "sgd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Sle =>
                    "sle",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Sll =>
                    "sll",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Sos =>
                    "sos",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Szl =>
                    "szl",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Thb =>
                    "thb",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Tjs =>
                    "tjs",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Top =>
                    "top",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Try =>
                    "try",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Ttd =>
                    "ttd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Tzs =>
                    "tzs",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Uah =>
                    "uah",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Uzs =>
                    "uzs",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Vnd =>
                    "vnd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Vuv =>
                    "vuv",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Wst =>
                    "wst",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Xaf =>
                    "xaf",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Xcd =>
                    "xcd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Yer =>
                    "yer",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Zar =>
                    "zar",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Zmw =>
                    "zmw",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Clp =>
                    "clp",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Djf =>
                    "djf",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Gnf =>
                    "gnf",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Ugx =>
                    "ugx",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Pyg =>
                    "pyg",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Xof =>
                    "xof",
                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Xpf =>
                    "xpf",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The unit price of the price tier
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPrice,
        SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceFromRaw
    >)
)]
public sealed record class SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPrice
    : JsonModel
{
    /// <summary>
    /// The price amount
    /// </summary>
    public required double Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    /// <summary>
    /// ISO 4217 currency code
    /// </summary>
    public required ApiEnum<
        string,
        SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency
    > Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency
                >
            >("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        this.Currency.Validate();
    }

    public SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPrice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPrice(
        SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPrice subscriptionProvisionResponseDataSubscriptionPriceTierUnitPrice
    )
        : base(subscriptionProvisionResponseDataSubscriptionPriceTierUnitPrice) { }
#pragma warning restore CS8618

    public SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPrice(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPrice(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceFromRaw.FromRawUnchecked"/>
    public static SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceFromRaw
    : IFromRawJson<SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPrice>
{
    /// <inheritdoc/>
    public SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPrice.FromRawUnchecked(rawData);
}

/// <summary>
/// ISO 4217 currency code
/// </summary>
[JsonConverter(
    typeof(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrencyConverter)
)]
public enum SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency
{
    Usd,
    Aed,
    All,
    Amd,
    Ang,
    Aud,
    Awg,
    Azn,
    Bam,
    Bbd,
    Bdt,
    Bgn,
    Bif,
    Bmd,
    Bnd,
    Bsd,
    Bwp,
    Byn,
    Bzd,
    Brl,
    Cad,
    Cdf,
    Chf,
    Cny,
    Czk,
    Dkk,
    Dop,
    Dzd,
    Egp,
    Etb,
    Eur,
    Fjd,
    Gbp,
    Gel,
    Gip,
    Gmd,
    Gyd,
    Hkd,
    Hrk,
    Htg,
    Idr,
    Ils,
    Inr,
    Isk,
    Jmd,
    Jpy,
    Kes,
    Kgs,
    Khr,
    Kmf,
    Krw,
    Kyd,
    Kzt,
    Lbp,
    Lkr,
    Lrd,
    Lsl,
    Mad,
    Mdl,
    Mga,
    Mkd,
    Mmk,
    Mnt,
    Mop,
    Mro,
    Mvr,
    Mwk,
    Mxn,
    Myr,
    Mzn,
    Nad,
    Ngn,
    Nok,
    Npr,
    Nzd,
    Pgk,
    Php,
    Pkr,
    Pln,
    Qar,
    Ron,
    Rsd,
    Rub,
    Rwf,
    Sar,
    Sbd,
    Scr,
    Sek,
    Sgd,
    Sle,
    Sll,
    Sos,
    Szl,
    Thb,
    Tjs,
    Top,
    Try,
    Ttd,
    Tzs,
    Uah,
    Uzs,
    Vnd,
    Vuv,
    Wst,
    Xaf,
    Xcd,
    Yer,
    Zar,
    Zmw,
    Clp,
    Djf,
    Gnf,
    Ugx,
    Pyg,
    Xof,
    Xpf,
}

sealed class SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrencyConverter
    : JsonConverter<SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency>
{
    public override SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
            "aed" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Aed,
            "all" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.All,
            "amd" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Amd,
            "ang" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Ang,
            "aud" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Aud,
            "awg" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Awg,
            "azn" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Azn,
            "bam" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Bam,
            "bbd" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Bbd,
            "bdt" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Bdt,
            "bgn" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Bgn,
            "bif" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Bif,
            "bmd" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Bmd,
            "bnd" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Bnd,
            "bsd" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Bsd,
            "bwp" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Bwp,
            "byn" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Byn,
            "bzd" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Bzd,
            "brl" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Brl,
            "cad" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Cad,
            "cdf" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Cdf,
            "chf" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Chf,
            "cny" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Cny,
            "czk" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Czk,
            "dkk" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Dkk,
            "dop" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Dop,
            "dzd" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Dzd,
            "egp" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Egp,
            "etb" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Etb,
            "eur" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Eur,
            "fjd" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Fjd,
            "gbp" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Gbp,
            "gel" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Gel,
            "gip" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Gip,
            "gmd" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Gmd,
            "gyd" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Gyd,
            "hkd" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Hkd,
            "hrk" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Hrk,
            "htg" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Htg,
            "idr" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Idr,
            "ils" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Ils,
            "inr" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Inr,
            "isk" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Isk,
            "jmd" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Jmd,
            "jpy" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Jpy,
            "kes" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Kes,
            "kgs" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Kgs,
            "khr" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Khr,
            "kmf" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Kmf,
            "krw" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Krw,
            "kyd" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Kyd,
            "kzt" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Kzt,
            "lbp" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Lbp,
            "lkr" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Lkr,
            "lrd" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Lrd,
            "lsl" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Lsl,
            "mad" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mad,
            "mdl" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mdl,
            "mga" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mga,
            "mkd" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mkd,
            "mmk" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mmk,
            "mnt" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mnt,
            "mop" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mop,
            "mro" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mro,
            "mvr" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mvr,
            "mwk" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mwk,
            "mxn" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mxn,
            "myr" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Myr,
            "mzn" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mzn,
            "nad" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Nad,
            "ngn" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Ngn,
            "nok" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Nok,
            "npr" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Npr,
            "nzd" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Nzd,
            "pgk" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Pgk,
            "php" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Php,
            "pkr" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Pkr,
            "pln" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Pln,
            "qar" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Qar,
            "ron" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Ron,
            "rsd" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Rsd,
            "rub" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Rub,
            "rwf" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Rwf,
            "sar" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Sar,
            "sbd" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Sbd,
            "scr" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Scr,
            "sek" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Sek,
            "sgd" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Sgd,
            "sle" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Sle,
            "sll" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Sll,
            "sos" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Sos,
            "szl" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Szl,
            "thb" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Thb,
            "tjs" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Tjs,
            "top" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Top,
            "try" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Try,
            "ttd" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Ttd,
            "tzs" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Tzs,
            "uah" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Uah,
            "uzs" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Uzs,
            "vnd" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Vnd,
            "vuv" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Vuv,
            "wst" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Wst,
            "xaf" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Xaf,
            "xcd" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Xcd,
            "yer" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Yer,
            "zar" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Zar,
            "zmw" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Zmw,
            "clp" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Clp,
            "djf" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Djf,
            "gnf" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Gnf,
            "ugx" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Ugx,
            "pyg" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Pyg,
            "xof" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Xof,
            "xpf" => SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Xpf,
            _ => (SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd =>
                    "usd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Aed =>
                    "aed",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.All =>
                    "all",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Amd =>
                    "amd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Ang =>
                    "ang",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Aud =>
                    "aud",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Awg =>
                    "awg",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Azn =>
                    "azn",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Bam =>
                    "bam",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Bbd =>
                    "bbd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Bdt =>
                    "bdt",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Bgn =>
                    "bgn",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Bif =>
                    "bif",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Bmd =>
                    "bmd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Bnd =>
                    "bnd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Bsd =>
                    "bsd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Bwp =>
                    "bwp",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Byn =>
                    "byn",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Bzd =>
                    "bzd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Brl =>
                    "brl",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Cad =>
                    "cad",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Cdf =>
                    "cdf",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Chf =>
                    "chf",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Cny =>
                    "cny",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Czk =>
                    "czk",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Dkk =>
                    "dkk",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Dop =>
                    "dop",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Dzd =>
                    "dzd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Egp =>
                    "egp",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Etb =>
                    "etb",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Eur =>
                    "eur",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Fjd =>
                    "fjd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Gbp =>
                    "gbp",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Gel =>
                    "gel",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Gip =>
                    "gip",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Gmd =>
                    "gmd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Gyd =>
                    "gyd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Hkd =>
                    "hkd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Hrk =>
                    "hrk",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Htg =>
                    "htg",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Idr =>
                    "idr",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Ils =>
                    "ils",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Inr =>
                    "inr",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Isk =>
                    "isk",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Jmd =>
                    "jmd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Jpy =>
                    "jpy",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Kes =>
                    "kes",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Kgs =>
                    "kgs",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Khr =>
                    "khr",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Kmf =>
                    "kmf",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Krw =>
                    "krw",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Kyd =>
                    "kyd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Kzt =>
                    "kzt",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Lbp =>
                    "lbp",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Lkr =>
                    "lkr",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Lrd =>
                    "lrd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Lsl =>
                    "lsl",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mad =>
                    "mad",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mdl =>
                    "mdl",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mga =>
                    "mga",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mkd =>
                    "mkd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mmk =>
                    "mmk",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mnt =>
                    "mnt",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mop =>
                    "mop",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mro =>
                    "mro",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mvr =>
                    "mvr",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mwk =>
                    "mwk",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mxn =>
                    "mxn",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Myr =>
                    "myr",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mzn =>
                    "mzn",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Nad =>
                    "nad",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Ngn =>
                    "ngn",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Nok =>
                    "nok",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Npr =>
                    "npr",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Nzd =>
                    "nzd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Pgk =>
                    "pgk",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Php =>
                    "php",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Pkr =>
                    "pkr",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Pln =>
                    "pln",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Qar =>
                    "qar",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Ron =>
                    "ron",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Rsd =>
                    "rsd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Rub =>
                    "rub",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Rwf =>
                    "rwf",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Sar =>
                    "sar",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Sbd =>
                    "sbd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Scr =>
                    "scr",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Sek =>
                    "sek",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Sgd =>
                    "sgd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Sle =>
                    "sle",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Sll =>
                    "sll",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Sos =>
                    "sos",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Szl =>
                    "szl",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Thb =>
                    "thb",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Tjs =>
                    "tjs",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Top =>
                    "top",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Try =>
                    "try",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Ttd =>
                    "ttd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Tzs =>
                    "tzs",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Uah =>
                    "uah",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Uzs =>
                    "uzs",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Vnd =>
                    "vnd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Vuv =>
                    "vuv",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Wst =>
                    "wst",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Xaf =>
                    "xaf",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Xcd =>
                    "xcd",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Yer =>
                    "yer",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Zar =>
                    "zar",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Zmw =>
                    "zmw",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Clp =>
                    "clp",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Djf =>
                    "djf",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Gnf =>
                    "gnf",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Ugx =>
                    "ugx",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Pyg =>
                    "pyg",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Xof =>
                    "xof",
                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Xpf =>
                    "xpf",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Subscription entitlement reference
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlement,
        SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementFromRaw
    >)
)]
public sealed record class SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlement
    : JsonModel
{
    /// <summary>
    /// Feature ID or currency ID
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
    /// Entitlement type (FEATURE or CREDIT)
    /// </summary>
    public required ApiEnum<
        string,
        SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementType
    > Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementType
                >
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

    public SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlement() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlement(
        SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlement subscriptionProvisionResponseDataSubscriptionSubscriptionEntitlement
    )
        : base(subscriptionProvisionResponseDataSubscriptionSubscriptionEntitlement) { }
#pragma warning restore CS8618

    public SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlement(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlement(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementFromRaw.FromRawUnchecked"/>
    public static SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementFromRaw
    : IFromRawJson<SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlement>
{
    /// <inheritdoc/>
    public SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlement.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Entitlement type (FEATURE or CREDIT)
/// </summary>
[JsonConverter(
    typeof(SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementTypeConverter)
)]
public enum SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementType
{
    Feature,
    Credit,
}

sealed class SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementTypeConverter
    : JsonConverter<SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementType>
{
    public override SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FEATURE" =>
                SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementType.Feature,
            "CREDIT" =>
                SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementType.Credit,
            _ => (SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementType.Feature =>
                    "FEATURE",
                SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementType.Credit =>
                    "CREDIT",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Trial configuration
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionProvisionResponseDataSubscriptionTrial,
        SubscriptionProvisionResponseDataSubscriptionTrialFromRaw
    >)
)]
public sealed record class SubscriptionProvisionResponseDataSubscriptionTrial : JsonModel
{
    /// <summary>
    /// Behavior when the trial ends
    /// </summary>
    public required ApiEnum<
        string,
        SubscriptionProvisionResponseDataSubscriptionTrialTrialEndBehavior
    > TrialEndBehavior
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionTrialTrialEndBehavior>
            >("trialEndBehavior");
        }
        init { this._rawData.Set("trialEndBehavior", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.TrialEndBehavior.Validate();
    }

    public SubscriptionProvisionResponseDataSubscriptionTrial() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionProvisionResponseDataSubscriptionTrial(
        SubscriptionProvisionResponseDataSubscriptionTrial subscriptionProvisionResponseDataSubscriptionTrial
    )
        : base(subscriptionProvisionResponseDataSubscriptionTrial) { }
#pragma warning restore CS8618

    public SubscriptionProvisionResponseDataSubscriptionTrial(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionProvisionResponseDataSubscriptionTrial(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionProvisionResponseDataSubscriptionTrialFromRaw.FromRawUnchecked"/>
    public static SubscriptionProvisionResponseDataSubscriptionTrial FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SubscriptionProvisionResponseDataSubscriptionTrial(
        ApiEnum<
            string,
            SubscriptionProvisionResponseDataSubscriptionTrialTrialEndBehavior
        > trialEndBehavior
    )
        : this()
    {
        this.TrialEndBehavior = trialEndBehavior;
    }
}

class SubscriptionProvisionResponseDataSubscriptionTrialFromRaw
    : IFromRawJson<SubscriptionProvisionResponseDataSubscriptionTrial>
{
    /// <inheritdoc/>
    public SubscriptionProvisionResponseDataSubscriptionTrial FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionProvisionResponseDataSubscriptionTrial.FromRawUnchecked(rawData);
}

/// <summary>
/// Behavior when the trial ends
/// </summary>
[JsonConverter(typeof(SubscriptionProvisionResponseDataSubscriptionTrialTrialEndBehaviorConverter))]
public enum SubscriptionProvisionResponseDataSubscriptionTrialTrialEndBehavior
{
    ConvertToPaid,
    CancelSubscription,
}

sealed class SubscriptionProvisionResponseDataSubscriptionTrialTrialEndBehaviorConverter
    : JsonConverter<SubscriptionProvisionResponseDataSubscriptionTrialTrialEndBehavior>
{
    public override SubscriptionProvisionResponseDataSubscriptionTrialTrialEndBehavior Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "CONVERT_TO_PAID" =>
                SubscriptionProvisionResponseDataSubscriptionTrialTrialEndBehavior.ConvertToPaid,
            "CANCEL_SUBSCRIPTION" =>
                SubscriptionProvisionResponseDataSubscriptionTrialTrialEndBehavior.CancelSubscription,
            _ => (SubscriptionProvisionResponseDataSubscriptionTrialTrialEndBehavior)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionProvisionResponseDataSubscriptionTrialTrialEndBehavior value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionProvisionResponseDataSubscriptionTrialTrialEndBehavior.ConvertToPaid =>
                    "CONVERT_TO_PAID",
                SubscriptionProvisionResponseDataSubscriptionTrialTrialEndBehavior.CancelSubscription =>
                    "CANCEL_SUBSCRIPTION",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
