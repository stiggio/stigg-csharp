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
    public required ApiEnum<
        string,
        CustomerRetrieveEntitlementsResponseDataAccessDeniedReason
    >? AccessDeniedReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, CustomerRetrieveEntitlementsResponseDataAccessDeniedReason>
            >("accessDeniedReason");
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
[JsonConverter(typeof(CustomerRetrieveEntitlementsResponseDataAccessDeniedReasonConverter))]
public enum CustomerRetrieveEntitlementsResponseDataAccessDeniedReason
{
    CustomerNotFound,
    NoActiveSubscription,
    CustomerIsArchived,
}

sealed class CustomerRetrieveEntitlementsResponseDataAccessDeniedReasonConverter
    : JsonConverter<CustomerRetrieveEntitlementsResponseDataAccessDeniedReason>
{
    public override CustomerRetrieveEntitlementsResponseDataAccessDeniedReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "CustomerNotFound" =>
                CustomerRetrieveEntitlementsResponseDataAccessDeniedReason.CustomerNotFound,
            "NoActiveSubscription" =>
                CustomerRetrieveEntitlementsResponseDataAccessDeniedReason.NoActiveSubscription,
            "CustomerIsArchived" =>
                CustomerRetrieveEntitlementsResponseDataAccessDeniedReason.CustomerIsArchived,
            _ => (CustomerRetrieveEntitlementsResponseDataAccessDeniedReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CustomerRetrieveEntitlementsResponseDataAccessDeniedReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CustomerRetrieveEntitlementsResponseDataAccessDeniedReason.CustomerNotFound =>
                    "CustomerNotFound",
                CustomerRetrieveEntitlementsResponseDataAccessDeniedReason.NoActiveSubscription =>
                    "NoActiveSubscription",
                CustomerRetrieveEntitlementsResponseDataAccessDeniedReason.CustomerIsArchived =>
                    "CustomerIsArchived",
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

    public Entitlement(EntitlementFeature value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Entitlement(EntitlementCredit value, JsonElement? element = null)
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
    /// type <see cref="EntitlementFeature"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFeature(out var value)) {
    ///     // `value` is of type `EntitlementFeature`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFeature([NotNullWhen(true)] out EntitlementFeature? value)
    {
        value = this.Value as EntitlementFeature;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EntitlementCredit"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCredit(out var value)) {
    ///     // `value` is of type `EntitlementCredit`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCredit([NotNullWhen(true)] out EntitlementCredit? value)
    {
        value = this.Value as EntitlementCredit;
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
    ///     (EntitlementFeature value) =&gt; {...},
    ///     (EntitlementCredit value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<EntitlementFeature> feature,
        System::Action<EntitlementCredit> credit
    )
    {
        switch (this.Value)
        {
            case EntitlementFeature value:
                feature(value);
                break;
            case EntitlementCredit value:
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
    ///     (EntitlementFeature value) =&gt; {...},
    ///     (EntitlementCredit value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<EntitlementFeature, T> feature,
        System::Func<EntitlementCredit, T> credit
    )
    {
        return this.Value switch
        {
            EntitlementFeature value => feature(value),
            EntitlementCredit value => credit(value),
            _ => throw new StiggInvalidDataException(
                "Data did not match any variant of Entitlement"
            ),
        };
    }

    public static implicit operator Entitlement(EntitlementFeature value) => new(value);

    public static implicit operator Entitlement(EntitlementCredit value) => new(value);

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
            EntitlementFeature _ => 0,
            EntitlementCredit _ => 1,
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
                    var deserialized = JsonSerializer.Deserialize<EntitlementFeature>(
                        element,
                        options
                    );
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
                    var deserialized = JsonSerializer.Deserialize<EntitlementCredit>(
                        element,
                        options
                    );
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

[JsonConverter(typeof(JsonModelConverter<EntitlementFeature, EntitlementFeatureFromRaw>))]
public sealed record class EntitlementFeature : JsonModel
{
    public required ApiEnum<string, EntitlementFeatureAccessDeniedReason>? AccessDeniedReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, EntitlementFeatureAccessDeniedReason>
            >("accessDeniedReason");
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

    public EntitlementFeatureFeature? Feature
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EntitlementFeatureFeature>("feature");
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

    public ApiEnum<string, EntitlementFeatureResetPeriod>? ResetPeriod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, EntitlementFeatureResetPeriod>>(
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("FEATURE")))
        {
            throw new StiggInvalidDataException("Invalid value given for constant");
        }
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

    public EntitlementFeature()
    {
        this.Type = JsonSerializer.SerializeToElement("FEATURE");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementFeature(EntitlementFeature entitlementFeature)
        : base(entitlementFeature) { }
#pragma warning restore CS8618

    public EntitlementFeature(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("FEATURE");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementFeature(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementFeatureFromRaw.FromRawUnchecked"/>
    public static EntitlementFeature FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntitlementFeatureFromRaw : IFromRawJson<EntitlementFeature>
{
    /// <inheritdoc/>
    public EntitlementFeature FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        EntitlementFeature.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(EntitlementFeatureAccessDeniedReasonConverter))]
public enum EntitlementFeatureAccessDeniedReason
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

sealed class EntitlementFeatureAccessDeniedReasonConverter
    : JsonConverter<EntitlementFeatureAccessDeniedReason>
{
    public override EntitlementFeatureAccessDeniedReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FeatureNotFound" => EntitlementFeatureAccessDeniedReason.FeatureNotFound,
            "CustomerNotFound" => EntitlementFeatureAccessDeniedReason.CustomerNotFound,
            "CustomerIsArchived" => EntitlementFeatureAccessDeniedReason.CustomerIsArchived,
            "CustomerResourceNotFound" =>
                EntitlementFeatureAccessDeniedReason.CustomerResourceNotFound,
            "NoActiveSubscription" => EntitlementFeatureAccessDeniedReason.NoActiveSubscription,
            "NoFeatureEntitlementInSubscription" =>
                EntitlementFeatureAccessDeniedReason.NoFeatureEntitlementInSubscription,
            "RequestedUsageExceedingLimit" =>
                EntitlementFeatureAccessDeniedReason.RequestedUsageExceedingLimit,
            "RequestedValuesMismatch" =>
                EntitlementFeatureAccessDeniedReason.RequestedValuesMismatch,
            "BudgetExceeded" => EntitlementFeatureAccessDeniedReason.BudgetExceeded,
            "Unknown" => EntitlementFeatureAccessDeniedReason.Unknown,
            "FeatureTypeMismatch" => EntitlementFeatureAccessDeniedReason.FeatureTypeMismatch,
            "Revoked" => EntitlementFeatureAccessDeniedReason.Revoked,
            "InsufficientCredits" => EntitlementFeatureAccessDeniedReason.InsufficientCredits,
            "EntitlementNotFound" => EntitlementFeatureAccessDeniedReason.EntitlementNotFound,
            _ => (EntitlementFeatureAccessDeniedReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntitlementFeatureAccessDeniedReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntitlementFeatureAccessDeniedReason.FeatureNotFound => "FeatureNotFound",
                EntitlementFeatureAccessDeniedReason.CustomerNotFound => "CustomerNotFound",
                EntitlementFeatureAccessDeniedReason.CustomerIsArchived => "CustomerIsArchived",
                EntitlementFeatureAccessDeniedReason.CustomerResourceNotFound =>
                    "CustomerResourceNotFound",
                EntitlementFeatureAccessDeniedReason.NoActiveSubscription => "NoActiveSubscription",
                EntitlementFeatureAccessDeniedReason.NoFeatureEntitlementInSubscription =>
                    "NoFeatureEntitlementInSubscription",
                EntitlementFeatureAccessDeniedReason.RequestedUsageExceedingLimit =>
                    "RequestedUsageExceedingLimit",
                EntitlementFeatureAccessDeniedReason.RequestedValuesMismatch =>
                    "RequestedValuesMismatch",
                EntitlementFeatureAccessDeniedReason.BudgetExceeded => "BudgetExceeded",
                EntitlementFeatureAccessDeniedReason.Unknown => "Unknown",
                EntitlementFeatureAccessDeniedReason.FeatureTypeMismatch => "FeatureTypeMismatch",
                EntitlementFeatureAccessDeniedReason.Revoked => "Revoked",
                EntitlementFeatureAccessDeniedReason.InsufficientCredits => "InsufficientCredits",
                EntitlementFeatureAccessDeniedReason.EntitlementNotFound => "EntitlementNotFound",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<EntitlementFeatureFeature, EntitlementFeatureFeatureFromRaw>)
)]
public sealed record class EntitlementFeatureFeature : JsonModel
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
    public required ApiEnum<string, EntitlementFeatureFeatureFeatureStatus> FeatureStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, EntitlementFeatureFeatureFeatureStatus>
            >("featureStatus");
        }
        init { this._rawData.Set("featureStatus", value); }
    }

    /// <summary>
    /// The type of feature associated with the entitlement.
    /// </summary>
    public required ApiEnum<string, EntitlementFeatureFeatureFeatureType> FeatureType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, EntitlementFeatureFeatureFeatureType>
            >("featureType");
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

    public EntitlementFeatureFeature() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementFeatureFeature(EntitlementFeatureFeature entitlementFeatureFeature)
        : base(entitlementFeatureFeature) { }
#pragma warning restore CS8618

    public EntitlementFeatureFeature(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementFeatureFeature(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementFeatureFeatureFromRaw.FromRawUnchecked"/>
    public static EntitlementFeatureFeature FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntitlementFeatureFeatureFromRaw : IFromRawJson<EntitlementFeatureFeature>
{
    /// <inheritdoc/>
    public EntitlementFeatureFeature FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementFeatureFeature.FromRawUnchecked(rawData);
}

/// <summary>
/// The current status of the feature.
/// </summary>
[JsonConverter(typeof(EntitlementFeatureFeatureFeatureStatusConverter))]
public enum EntitlementFeatureFeatureFeatureStatus
{
    New,
    Suspended,
    Active,
}

sealed class EntitlementFeatureFeatureFeatureStatusConverter
    : JsonConverter<EntitlementFeatureFeatureFeatureStatus>
{
    public override EntitlementFeatureFeatureFeatureStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "NEW" => EntitlementFeatureFeatureFeatureStatus.New,
            "SUSPENDED" => EntitlementFeatureFeatureFeatureStatus.Suspended,
            "ACTIVE" => EntitlementFeatureFeatureFeatureStatus.Active,
            _ => (EntitlementFeatureFeatureFeatureStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntitlementFeatureFeatureFeatureStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntitlementFeatureFeatureFeatureStatus.New => "NEW",
                EntitlementFeatureFeatureFeatureStatus.Suspended => "SUSPENDED",
                EntitlementFeatureFeatureFeatureStatus.Active => "ACTIVE",
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
[JsonConverter(typeof(EntitlementFeatureFeatureFeatureTypeConverter))]
public enum EntitlementFeatureFeatureFeatureType
{
    Boolean,
    Number,
    Enum,
}

sealed class EntitlementFeatureFeatureFeatureTypeConverter
    : JsonConverter<EntitlementFeatureFeatureFeatureType>
{
    public override EntitlementFeatureFeatureFeatureType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "BOOLEAN" => EntitlementFeatureFeatureFeatureType.Boolean,
            "NUMBER" => EntitlementFeatureFeatureFeatureType.Number,
            "ENUM" => EntitlementFeatureFeatureFeatureType.Enum,
            _ => (EntitlementFeatureFeatureFeatureType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntitlementFeatureFeatureFeatureType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntitlementFeatureFeatureFeatureType.Boolean => "BOOLEAN",
                EntitlementFeatureFeatureFeatureType.Number => "NUMBER",
                EntitlementFeatureFeatureFeatureType.Enum => "ENUM",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(EntitlementFeatureResetPeriodConverter))]
public enum EntitlementFeatureResetPeriod
{
    Year,
    Month,
    Week,
    Day,
    Hour,
}

sealed class EntitlementFeatureResetPeriodConverter : JsonConverter<EntitlementFeatureResetPeriod>
{
    public override EntitlementFeatureResetPeriod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "YEAR" => EntitlementFeatureResetPeriod.Year,
            "MONTH" => EntitlementFeatureResetPeriod.Month,
            "WEEK" => EntitlementFeatureResetPeriod.Week,
            "DAY" => EntitlementFeatureResetPeriod.Day,
            "HOUR" => EntitlementFeatureResetPeriod.Hour,
            _ => (EntitlementFeatureResetPeriod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntitlementFeatureResetPeriod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntitlementFeatureResetPeriod.Year => "YEAR",
                EntitlementFeatureResetPeriod.Month => "MONTH",
                EntitlementFeatureResetPeriod.Week => "WEEK",
                EntitlementFeatureResetPeriod.Day => "DAY",
                EntitlementFeatureResetPeriod.Hour => "HOUR",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<EntitlementCredit, EntitlementCreditFromRaw>))]
public sealed record class EntitlementCredit : JsonModel
{
    public required ApiEnum<string, EntitlementCreditAccessDeniedReason>? AccessDeniedReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, EntitlementCreditAccessDeniedReason>
            >("accessDeniedReason");
        }
        init { this._rawData.Set("accessDeniedReason", value); }
    }

    /// <summary>
    /// The currency associated with a credit entitlement.
    /// </summary>
    public required EntitlementCreditCurrency Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EntitlementCreditCurrency>("currency");
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

    public EntitlementCredit()
    {
        this.Type = JsonSerializer.SerializeToElement("CREDIT");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementCredit(EntitlementCredit entitlementCredit)
        : base(entitlementCredit) { }
#pragma warning restore CS8618

    public EntitlementCredit(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("CREDIT");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementCredit(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementCreditFromRaw.FromRawUnchecked"/>
    public static EntitlementCredit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntitlementCreditFromRaw : IFromRawJson<EntitlementCredit>
{
    /// <inheritdoc/>
    public EntitlementCredit FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        EntitlementCredit.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(EntitlementCreditAccessDeniedReasonConverter))]
public enum EntitlementCreditAccessDeniedReason
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

sealed class EntitlementCreditAccessDeniedReasonConverter
    : JsonConverter<EntitlementCreditAccessDeniedReason>
{
    public override EntitlementCreditAccessDeniedReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FeatureNotFound" => EntitlementCreditAccessDeniedReason.FeatureNotFound,
            "CustomerNotFound" => EntitlementCreditAccessDeniedReason.CustomerNotFound,
            "CustomerIsArchived" => EntitlementCreditAccessDeniedReason.CustomerIsArchived,
            "CustomerResourceNotFound" =>
                EntitlementCreditAccessDeniedReason.CustomerResourceNotFound,
            "NoActiveSubscription" => EntitlementCreditAccessDeniedReason.NoActiveSubscription,
            "NoFeatureEntitlementInSubscription" =>
                EntitlementCreditAccessDeniedReason.NoFeatureEntitlementInSubscription,
            "RequestedUsageExceedingLimit" =>
                EntitlementCreditAccessDeniedReason.RequestedUsageExceedingLimit,
            "RequestedValuesMismatch" =>
                EntitlementCreditAccessDeniedReason.RequestedValuesMismatch,
            "BudgetExceeded" => EntitlementCreditAccessDeniedReason.BudgetExceeded,
            "Unknown" => EntitlementCreditAccessDeniedReason.Unknown,
            "FeatureTypeMismatch" => EntitlementCreditAccessDeniedReason.FeatureTypeMismatch,
            "Revoked" => EntitlementCreditAccessDeniedReason.Revoked,
            "InsufficientCredits" => EntitlementCreditAccessDeniedReason.InsufficientCredits,
            "EntitlementNotFound" => EntitlementCreditAccessDeniedReason.EntitlementNotFound,
            _ => (EntitlementCreditAccessDeniedReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntitlementCreditAccessDeniedReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntitlementCreditAccessDeniedReason.FeatureNotFound => "FeatureNotFound",
                EntitlementCreditAccessDeniedReason.CustomerNotFound => "CustomerNotFound",
                EntitlementCreditAccessDeniedReason.CustomerIsArchived => "CustomerIsArchived",
                EntitlementCreditAccessDeniedReason.CustomerResourceNotFound =>
                    "CustomerResourceNotFound",
                EntitlementCreditAccessDeniedReason.NoActiveSubscription => "NoActiveSubscription",
                EntitlementCreditAccessDeniedReason.NoFeatureEntitlementInSubscription =>
                    "NoFeatureEntitlementInSubscription",
                EntitlementCreditAccessDeniedReason.RequestedUsageExceedingLimit =>
                    "RequestedUsageExceedingLimit",
                EntitlementCreditAccessDeniedReason.RequestedValuesMismatch =>
                    "RequestedValuesMismatch",
                EntitlementCreditAccessDeniedReason.BudgetExceeded => "BudgetExceeded",
                EntitlementCreditAccessDeniedReason.Unknown => "Unknown",
                EntitlementCreditAccessDeniedReason.FeatureTypeMismatch => "FeatureTypeMismatch",
                EntitlementCreditAccessDeniedReason.Revoked => "Revoked",
                EntitlementCreditAccessDeniedReason.InsufficientCredits => "InsufficientCredits",
                EntitlementCreditAccessDeniedReason.EntitlementNotFound => "EntitlementNotFound",
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
    typeof(JsonModelConverter<EntitlementCreditCurrency, EntitlementCreditCurrencyFromRaw>)
)]
public sealed record class EntitlementCreditCurrency : JsonModel
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

    public EntitlementCreditCurrency() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementCreditCurrency(EntitlementCreditCurrency entitlementCreditCurrency)
        : base(entitlementCreditCurrency) { }
#pragma warning restore CS8618

    public EntitlementCreditCurrency(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementCreditCurrency(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementCreditCurrencyFromRaw.FromRawUnchecked"/>
    public static EntitlementCreditCurrency FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntitlementCreditCurrencyFromRaw : IFromRawJson<EntitlementCreditCurrency>
{
    /// <inheritdoc/>
    public EntitlementCreditCurrency FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EntitlementCreditCurrency.FromRawUnchecked(rawData);
}
