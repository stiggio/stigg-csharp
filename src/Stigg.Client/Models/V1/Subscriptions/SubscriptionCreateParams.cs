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

namespace Stigg.Client.Models.V1.Subscriptions;

/// <summary>
/// Create a new Subscription
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class SubscriptionCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Customer ID to provision the subscription for
    /// </summary>
    public required string CustomerID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("customerId");
        }
        init { this._rawBodyData.Set("customerId", value); }
    }

    /// <summary>
    /// Plan ID to provision
    /// </summary>
    public required string PlanID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("planId");
        }
        init { this._rawBodyData.Set("planId", value); }
    }

    /// <summary>
    /// Unique identifier for the subscription
    /// </summary>
    public string? ID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("id");
        }
        init { this._rawBodyData.Set("id", value); }
    }

    /// <summary>
    /// Whether to wait for payment confirmation before returning the subscription
    /// </summary>
    public bool? AwaitPaymentConfirmation
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("awaitPaymentConfirmation");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("awaitPaymentConfirmation", value);
        }
    }

    public ApiEnum<string, BillingPeriod>? BillingPeriod
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, BillingPeriod>>(
                "billingPeriod"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("billingPeriod", value);
        }
    }

    public CheckoutOptions? CheckoutOptions
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<CheckoutOptions>("checkoutOptions");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("checkoutOptions", value);
        }
    }

    /// <summary>
    /// Additional metadata for the subscription
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
    /// Optional paying customer ID for split billing scenarios
    /// </summary>
    public string? PayingCustomerID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("payingCustomerId");
        }
        init { this._rawBodyData.Set("payingCustomerId", value); }
    }

    /// <summary>
    /// Optional resource ID for multi-instance subscriptions
    /// </summary>
    public string? ResourceID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("resourceId");
        }
        init { this._rawBodyData.Set("resourceId", value); }
    }

    public TrialOverrideConfiguration? TrialOverrideConfiguration
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<TrialOverrideConfiguration>(
                "trialOverrideConfiguration"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("trialOverrideConfiguration", value);
        }
    }

    public SubscriptionCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionCreateParams(SubscriptionCreateParams subscriptionCreateParams)
        : base(subscriptionCreateParams)
    {
        this._rawBodyData = new(subscriptionCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public SubscriptionCreateParams(
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
    SubscriptionCreateParams(
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
    public static SubscriptionCreateParams FromRawUnchecked(
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
            new Dictionary<string, object?>()
            {
                ["HeaderData"] = this._rawHeaderData.Freeze(),
                ["QueryData"] = this._rawQueryData.Freeze(),
                ["BodyData"] = this._rawBodyData.Freeze(),
            },
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(SubscriptionCreateParams? other)
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
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/api/v1/subscriptions"
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

[JsonConverter(typeof(BillingPeriodConverter))]
public enum BillingPeriod
{
    Monthly,
    Annually,
}

sealed class BillingPeriodConverter : JsonConverter<BillingPeriod>
{
    public override BillingPeriod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "MONTHLY" => BillingPeriod.Monthly,
            "ANNUALLY" => BillingPeriod.Annually,
            _ => (BillingPeriod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BillingPeriod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BillingPeriod.Monthly => "MONTHLY",
                BillingPeriod.Annually => "ANNUALLY",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<CheckoutOptions, CheckoutOptionsFromRaw>))]
public sealed record class CheckoutOptions : JsonModel
{
    /// <summary>
    /// URL to redirect to if checkout is canceled
    /// </summary>
    public required string CancelUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("cancelUrl");
        }
        init { this._rawData.Set("cancelUrl", value); }
    }

    /// <summary>
    /// URL to redirect to after successful checkout
    /// </summary>
    public required string SuccessUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("successUrl");
        }
        init { this._rawData.Set("successUrl", value); }
    }

    /// <summary>
    /// Allow promotional codes during checkout
    /// </summary>
    public bool? AllowPromoCodes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("allowPromoCodes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("allowPromoCodes", value);
        }
    }

    /// <summary>
    /// Allow tax ID collection during checkout
    /// </summary>
    public bool? AllowTaxIDCollection
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("allowTaxIdCollection");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("allowTaxIdCollection", value);
        }
    }

    /// <summary>
    /// Collect billing address during checkout
    /// </summary>
    public bool? CollectBillingAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("collectBillingAddress");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("collectBillingAddress", value);
        }
    }

    /// <summary>
    /// Collect phone number during checkout
    /// </summary>
    public bool? CollectPhoneNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("collectPhoneNumber");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("collectPhoneNumber", value);
        }
    }

    /// <summary>
    /// Optional reference ID for the checkout session
    /// </summary>
    public string? ReferenceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("referenceId");
        }
        init { this._rawData.Set("referenceId", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CancelUrl;
        _ = this.SuccessUrl;
        _ = this.AllowPromoCodes;
        _ = this.AllowTaxIDCollection;
        _ = this.CollectBillingAddress;
        _ = this.CollectPhoneNumber;
        _ = this.ReferenceID;
    }

    public CheckoutOptions() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CheckoutOptions(CheckoutOptions checkoutOptions)
        : base(checkoutOptions) { }
#pragma warning restore CS8618

    public CheckoutOptions(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CheckoutOptions(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CheckoutOptionsFromRaw.FromRawUnchecked"/>
    public static CheckoutOptions FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CheckoutOptionsFromRaw : IFromRawJson<CheckoutOptions>
{
    /// <inheritdoc/>
    public CheckoutOptions FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CheckoutOptions.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<TrialOverrideConfiguration, TrialOverrideConfigurationFromRaw>)
)]
public sealed record class TrialOverrideConfiguration : JsonModel
{
    /// <summary>
    /// Whether the subscription should start with a trial period
    /// </summary>
    public required bool IsTrial
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("isTrial");
        }
        init { this._rawData.Set("isTrial", value); }
    }

    /// <summary>
    /// Behavior when trial ends: CONVERT_TO_PAID or CANCEL_SUBSCRIPTION
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
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("trialEndBehavior", value);
        }
    }

    /// <summary>
    /// Custom trial end date
    /// </summary>
    public System::DateTimeOffset? TrialEndDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("trialEndDate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("trialEndDate", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.IsTrial;
        this.TrialEndBehavior?.Validate();
        _ = this.TrialEndDate;
    }

    public TrialOverrideConfiguration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TrialOverrideConfiguration(TrialOverrideConfiguration trialOverrideConfiguration)
        : base(trialOverrideConfiguration) { }
#pragma warning restore CS8618

    public TrialOverrideConfiguration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TrialOverrideConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TrialOverrideConfigurationFromRaw.FromRawUnchecked"/>
    public static TrialOverrideConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TrialOverrideConfiguration(bool isTrial)
        : this()
    {
        this.IsTrial = isTrial;
    }
}

class TrialOverrideConfigurationFromRaw : IFromRawJson<TrialOverrideConfiguration>
{
    /// <inheritdoc/>
    public TrialOverrideConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TrialOverrideConfiguration.FromRawUnchecked(rawData);
}

/// <summary>
/// Behavior when trial ends: CONVERT_TO_PAID or CANCEL_SUBSCRIPTION
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
