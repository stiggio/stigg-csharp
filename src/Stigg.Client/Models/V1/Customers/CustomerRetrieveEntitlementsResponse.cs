using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using System = System;

namespace Stigg.Client.Models.V1.Customers;

/// <summary>
/// Response object
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CustomerRetrieveEntitlementsResponse,
        CustomerRetrieveEntitlementsResponseFromRaw
    >)
)]
public sealed record class CustomerRetrieveEntitlementsResponse : JsonModel
{
    /// <summary>
    /// The effective entitlements state for a customer or resource.
    /// </summary>
    public required CustomerRetrieveEntitlementsResponseData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CustomerRetrieveEntitlementsResponseData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public CustomerRetrieveEntitlementsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerRetrieveEntitlementsResponse(
        CustomerRetrieveEntitlementsResponse customerRetrieveEntitlementsResponse
    )
        : base(customerRetrieveEntitlementsResponse) { }
#pragma warning restore CS8618

    public CustomerRetrieveEntitlementsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerRetrieveEntitlementsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerRetrieveEntitlementsResponseFromRaw.FromRawUnchecked"/>
    public static CustomerRetrieveEntitlementsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CustomerRetrieveEntitlementsResponse(CustomerRetrieveEntitlementsResponseData data)
        : this()
    {
        this.Data = data;
    }
}

class CustomerRetrieveEntitlementsResponseFromRaw
    : IFromRawJson<CustomerRetrieveEntitlementsResponse>
{
    /// <inheritdoc/>
    public CustomerRetrieveEntitlementsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerRetrieveEntitlementsResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// The effective entitlements state for a customer or resource.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CustomerRetrieveEntitlementsResponseData,
        CustomerRetrieveEntitlementsResponseDataFromRaw
    >)
)]
public sealed record class CustomerRetrieveEntitlementsResponseData : JsonModel
{
    /// <summary>
    /// Reason why entitlements access was denied, if applicable
    /// </summary>
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

    /// <summary>
    /// List of effective feature and credit entitlements
    /// </summary>
    public required IReadOnlyList<Entitlement> Entitlements
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Entitlement>>("entitlements");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Entitlement>>(
                "entitlements",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.AccessDeniedReason?.Validate();
        foreach (var item in this.Entitlements)
        {
            item.Validate();
        }
    }

    public CustomerRetrieveEntitlementsResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerRetrieveEntitlementsResponseData(
        CustomerRetrieveEntitlementsResponseData customerRetrieveEntitlementsResponseData
    )
        : base(customerRetrieveEntitlementsResponseData) { }
#pragma warning restore CS8618

    public CustomerRetrieveEntitlementsResponseData(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerRetrieveEntitlementsResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerRetrieveEntitlementsResponseDataFromRaw.FromRawUnchecked"/>
    public static CustomerRetrieveEntitlementsResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerRetrieveEntitlementsResponseDataFromRaw
    : IFromRawJson<CustomerRetrieveEntitlementsResponseData>
{
    /// <inheritdoc/>
    public CustomerRetrieveEntitlementsResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerRetrieveEntitlementsResponseData.FromRawUnchecked(rawData);
}

/// <summary>
/// Reason why entitlements access was denied, if applicable
/// </summary>
[JsonConverter(typeof(AccessDeniedReasonConverter))]
public enum AccessDeniedReason
{
    CustomerNotFound,
    NoActiveSubscription,
    CustomerIsArchived,
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
            "CustomerNotFound" => AccessDeniedReason.CustomerNotFound,
            "NoActiveSubscription" => AccessDeniedReason.NoActiveSubscription,
            "CustomerIsArchived" => AccessDeniedReason.CustomerIsArchived,
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
                AccessDeniedReason.CustomerNotFound => "CustomerNotFound",
                AccessDeniedReason.NoActiveSubscription => "NoActiveSubscription",
                AccessDeniedReason.CustomerIsArchived => "CustomerIsArchived",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(EntitlementConverter))]
public record class Entitlement : ModelBase
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

    public System::DateTimeOffset? EntitlementUpdatedAt
    {
        get
        {
            return Match<System::DateTimeOffset?>(
                feature: (x) => x.EntitlementUpdatedAt,
                credit: (x) => x.EntitlementUpdatedAt
            );
        }
    }

    public double? UsageLimit
    {
        get { return Match<double?>(feature: (x) => x.UsageLimit, credit: (x) => x.UsageLimit); }
    }

    public System::DateTimeOffset? UsagePeriodEnd
    {
        get
        {
            return Match<System::DateTimeOffset?>(
                feature: (x) => x.UsagePeriodEnd,
                credit: (x) => x.UsagePeriodEnd
            );
        }
    }

    public System::DateTimeOffset? ValidUntil
    {
        get
        {
            return Match<System::DateTimeOffset?>(
                feature: (x) => x.ValidUntil,
                credit: (x) => x.ValidUntil
            );
        }
    }

    public Entitlement(Feature value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Entitlement(Credit value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Entitlement(JsonElement element)
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
    public void Switch(System::Action<Feature> feature, System::Action<Credit> credit)
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
                throw new StiggInvalidDataException(
                    "Data did not match any variant of Entitlement"
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
    ///     (Feature value) =&gt; {...},
    ///     (Credit value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(System::Func<Feature, T> feature, System::Func<Credit, T> credit)
    {
        return this.Value switch
        {
            Feature value => feature(value),
            Credit value => credit(value),
            _ => throw new StiggInvalidDataException(
                "Data did not match any variant of Entitlement"
            ),
        };
    }

    public static implicit operator Entitlement(Feature value) => new(value);

    public static implicit operator Entitlement(Credit value) => new(value);

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
            throw new StiggInvalidDataException("Data did not match any variant of Entitlement");
        }
        this.Switch((feature) => feature.Validate(), (credit) => credit.Validate());
    }

    public virtual bool Equals(Entitlement? other) =>
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

sealed class EntitlementConverter : JsonConverter<Entitlement>
{
    public override Entitlement? Read(
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
                    var deserialized = JsonSerializer.Deserialize<Feature>(element, options);
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
                    var deserialized = JsonSerializer.Deserialize<Credit>(element, options);
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
                return new Entitlement(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        Entitlement value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<Feature, FeatureFromRaw>))]
public sealed record class Feature : JsonModel
{
    public required ApiEnum<string, FeatureAccessDeniedReason>? AccessDeniedReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, FeatureAccessDeniedReason>>(
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("FEATURE")))
        {
            throw new StiggInvalidDataException("Invalid value given for constant");
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

[JsonConverter(typeof(FeatureAccessDeniedReasonConverter))]
public enum FeatureAccessDeniedReason
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

sealed class FeatureAccessDeniedReasonConverter : JsonConverter<FeatureAccessDeniedReason>
{
    public override FeatureAccessDeniedReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FeatureNotFound" => FeatureAccessDeniedReason.FeatureNotFound,
            "CustomerNotFound" => FeatureAccessDeniedReason.CustomerNotFound,
            "CustomerIsArchived" => FeatureAccessDeniedReason.CustomerIsArchived,
            "CustomerResourceNotFound" => FeatureAccessDeniedReason.CustomerResourceNotFound,
            "NoActiveSubscription" => FeatureAccessDeniedReason.NoActiveSubscription,
            "NoFeatureEntitlementInSubscription" =>
                FeatureAccessDeniedReason.NoFeatureEntitlementInSubscription,
            "RequestedUsageExceedingLimit" =>
                FeatureAccessDeniedReason.RequestedUsageExceedingLimit,
            "RequestedValuesMismatch" => FeatureAccessDeniedReason.RequestedValuesMismatch,
            "BudgetExceeded" => FeatureAccessDeniedReason.BudgetExceeded,
            "Unknown" => FeatureAccessDeniedReason.Unknown,
            "FeatureTypeMismatch" => FeatureAccessDeniedReason.FeatureTypeMismatch,
            "Revoked" => FeatureAccessDeniedReason.Revoked,
            "InsufficientCredits" => FeatureAccessDeniedReason.InsufficientCredits,
            "EntitlementNotFound" => FeatureAccessDeniedReason.EntitlementNotFound,
            _ => (FeatureAccessDeniedReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FeatureAccessDeniedReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FeatureAccessDeniedReason.FeatureNotFound => "FeatureNotFound",
                FeatureAccessDeniedReason.CustomerNotFound => "CustomerNotFound",
                FeatureAccessDeniedReason.CustomerIsArchived => "CustomerIsArchived",
                FeatureAccessDeniedReason.CustomerResourceNotFound => "CustomerResourceNotFound",
                FeatureAccessDeniedReason.NoActiveSubscription => "NoActiveSubscription",
                FeatureAccessDeniedReason.NoFeatureEntitlementInSubscription =>
                    "NoFeatureEntitlementInSubscription",
                FeatureAccessDeniedReason.RequestedUsageExceedingLimit =>
                    "RequestedUsageExceedingLimit",
                FeatureAccessDeniedReason.RequestedValuesMismatch => "RequestedValuesMismatch",
                FeatureAccessDeniedReason.BudgetExceeded => "BudgetExceeded",
                FeatureAccessDeniedReason.Unknown => "Unknown",
                FeatureAccessDeniedReason.FeatureTypeMismatch => "FeatureTypeMismatch",
                FeatureAccessDeniedReason.Revoked => "Revoked",
                FeatureAccessDeniedReason.InsufficientCredits => "InsufficientCredits",
                FeatureAccessDeniedReason.EntitlementNotFound => "EntitlementNotFound",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
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
        System::Type typeToConvert,
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
    public required CreditCurrency Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CreditCurrency>("currency");
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("CREDIT")))
        {
            throw new StiggInvalidDataException("Invalid value given for constant");
        }
        _ = this.UsageLimit;
        _ = this.UsageUpdatedAt;
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
        System::Type typeToConvert,
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
[JsonConverter(typeof(JsonModelConverter<CreditCurrency, CreditCurrencyFromRaw>))]
public sealed record class CreditCurrency : JsonModel
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

    public CreditCurrency() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreditCurrency(CreditCurrency creditCurrency)
        : base(creditCurrency) { }
#pragma warning restore CS8618

    public CreditCurrency(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditCurrency(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreditCurrencyFromRaw.FromRawUnchecked"/>
    public static CreditCurrency FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreditCurrencyFromRaw : IFromRawJson<CreditCurrency>
{
    /// <inheritdoc/>
    public CreditCurrency FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CreditCurrency.FromRawUnchecked(rawData);
}
