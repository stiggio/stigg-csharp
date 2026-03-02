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

namespace Stigg.Client.Models.V1.Subscriptions;

/// <summary>
/// Creates a new subscription for an existing customer. When payment is required
/// and no payment method exists, returns a checkout URL.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class SubscriptionProvisionParams : ParamsBase
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
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("id", value);
        }
    }

    public IReadOnlyList<SubscriptionProvisionParamsAddon>? Addons
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<
                ImmutableArray<SubscriptionProvisionParamsAddon>
            >("addons");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<SubscriptionProvisionParamsAddon>?>(
                "addons",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Coupon configuration
    /// </summary>
    public SubscriptionProvisionParamsAppliedCoupon? AppliedCoupon
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<SubscriptionProvisionParamsAppliedCoupon>(
                "appliedCoupon"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("appliedCoupon", value);
        }
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

    /// <summary>
    /// The ISO 3166-1 alpha-2 country code for billing
    /// </summary>
    public string? BillingCountryCode
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("billingCountryCode");
        }
        init { this._rawBodyData.Set("billingCountryCode", value); }
    }

    /// <summary>
    /// Billing cycle anchor behavior for the subscription
    /// </summary>
    public ApiEnum<string, SubscriptionProvisionParamsBillingCycleAnchor>? BillingCycleAnchor
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<
                ApiEnum<string, SubscriptionProvisionParamsBillingCycleAnchor>
            >("billingCycleAnchor");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("billingCycleAnchor", value);
        }
    }

    /// <summary>
    /// External billing system identifier
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

    public SubscriptionProvisionParamsBillingInformation? BillingInformation
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<SubscriptionProvisionParamsBillingInformation>(
                "billingInformation"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("billingInformation", value);
        }
    }

    /// <summary>
    /// Billing period (MONTHLY or ANNUALLY)
    /// </summary>
    public ApiEnum<string, SubscriptionProvisionParamsBillingPeriod>? BillingPeriod
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<
                ApiEnum<string, SubscriptionProvisionParamsBillingPeriod>
            >("billingPeriod");
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

    public SubscriptionProvisionParamsBudget? Budget
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<SubscriptionProvisionParamsBudget>("budget");
        }
        init { this._rawBodyData.Set("budget", value); }
    }

    public IReadOnlyList<SubscriptionProvisionParamsCharge>? Charges
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<
                ImmutableArray<SubscriptionProvisionParamsCharge>
            >("charges");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<SubscriptionProvisionParamsCharge>?>(
                "charges",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Checkout page configuration for payment collection
    /// </summary>
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

    public SubscriptionProvisionParamsMinimumSpend? MinimumSpend
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<SubscriptionProvisionParamsMinimumSpend>(
                "minimumSpend"
            );
        }
        init { this._rawBodyData.Set("minimumSpend", value); }
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
    /// How payments should be collected for this subscription
    /// </summary>
    public ApiEnum<string, PaymentCollectionMethod>? PaymentCollectionMethod
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, PaymentCollectionMethod>>(
                "paymentCollectionMethod"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("paymentCollectionMethod", value);
        }
    }

    public IReadOnlyList<SubscriptionProvisionParamsPriceOverride>? PriceOverrides
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<
                ImmutableArray<SubscriptionProvisionParamsPriceOverride>
            >("priceOverrides");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<SubscriptionProvisionParamsPriceOverride>?>(
                "priceOverrides",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
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

    /// <summary>
    /// Salesforce ID
    /// </summary>
    public string? SalesforceID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("salesforceId");
        }
        init { this._rawBodyData.Set("salesforceId", value); }
    }

    /// <summary>
    /// Strategy for scheduling subscription changes
    /// </summary>
    public ApiEnum<string, SubscriptionProvisionParamsScheduleStrategy>? ScheduleStrategy
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<
                ApiEnum<string, SubscriptionProvisionParamsScheduleStrategy>
            >("scheduleStrategy");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("scheduleStrategy", value);
        }
    }

    /// <summary>
    /// Subscription start date
    /// </summary>
    public System::DateTimeOffset? StartDate
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<System::DateTimeOffset>("startDate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("startDate", value);
        }
    }

    public IReadOnlyList<SubscriptionProvisionParamsSubscriptionEntitlement>? SubscriptionEntitlements
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<
                ImmutableArray<SubscriptionProvisionParamsSubscriptionEntitlement>
            >("subscriptionEntitlements");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<SubscriptionProvisionParamsSubscriptionEntitlement>?>(
                "subscriptionEntitlements",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Trial period override settings
    /// </summary>
    public SubscriptionProvisionParamsTrialOverrideConfiguration? TrialOverrideConfiguration
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<SubscriptionProvisionParamsTrialOverrideConfiguration>(
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

    public double? UnitQuantity
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<double>("unitQuantity");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("unitQuantity", value);
        }
    }

    public SubscriptionProvisionParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionProvisionParams(SubscriptionProvisionParams subscriptionProvisionParams)
        : base(subscriptionProvisionParams)
    {
        this._rawBodyData = new(subscriptionProvisionParams._rawBodyData);
    }
#pragma warning restore CS8618

    public SubscriptionProvisionParams(
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
    SubscriptionProvisionParams(
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
    public static SubscriptionProvisionParams FromRawUnchecked(
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

    public virtual bool Equals(SubscriptionProvisionParams? other)
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

/// <summary>
/// Addon configuration
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionProvisionParamsAddon,
        SubscriptionProvisionParamsAddonFromRaw
    >)
)]
public sealed record class SubscriptionProvisionParamsAddon : JsonModel
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

    public SubscriptionProvisionParamsAddon() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionProvisionParamsAddon(
        SubscriptionProvisionParamsAddon subscriptionProvisionParamsAddon
    )
        : base(subscriptionProvisionParamsAddon) { }
#pragma warning restore CS8618

    public SubscriptionProvisionParamsAddon(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionProvisionParamsAddon(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionProvisionParamsAddonFromRaw.FromRawUnchecked"/>
    public static SubscriptionProvisionParamsAddon FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionProvisionParamsAddonFromRaw : IFromRawJson<SubscriptionProvisionParamsAddon>
{
    /// <inheritdoc/>
    public SubscriptionProvisionParamsAddon FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionProvisionParamsAddon.FromRawUnchecked(rawData);
}

/// <summary>
/// Coupon configuration
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionProvisionParamsAppliedCoupon,
        SubscriptionProvisionParamsAppliedCouponFromRaw
    >)
)]
public sealed record class SubscriptionProvisionParamsAppliedCoupon : JsonModel
{
    /// <summary>
    /// Billing provider coupon ID
    /// </summary>
    public string? BillingCouponID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billingCouponId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("billingCouponId", value);
        }
    }

    /// <summary>
    /// Coupon timing configuration
    /// </summary>
    public SubscriptionProvisionParamsAppliedCouponConfiguration? Configuration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SubscriptionProvisionParamsAppliedCouponConfiguration>(
                "configuration"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("configuration", value);
        }
    }

    /// <summary>
    /// Stigg coupon ID
    /// </summary>
    public string? CouponID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("couponId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("couponId", value);
        }
    }

    /// <summary>
    /// Ad-hoc discount configuration
    /// </summary>
    public SubscriptionProvisionParamsAppliedCouponDiscount? Discount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SubscriptionProvisionParamsAppliedCouponDiscount>(
                "discount"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("discount", value);
        }
    }

    /// <summary>
    /// Promotion code to apply
    /// </summary>
    public string? PromotionCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("promotionCode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("promotionCode", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BillingCouponID;
        this.Configuration?.Validate();
        _ = this.CouponID;
        this.Discount?.Validate();
        _ = this.PromotionCode;
    }

    public SubscriptionProvisionParamsAppliedCoupon() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionProvisionParamsAppliedCoupon(
        SubscriptionProvisionParamsAppliedCoupon subscriptionProvisionParamsAppliedCoupon
    )
        : base(subscriptionProvisionParamsAppliedCoupon) { }
#pragma warning restore CS8618

    public SubscriptionProvisionParamsAppliedCoupon(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionProvisionParamsAppliedCoupon(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionProvisionParamsAppliedCouponFromRaw.FromRawUnchecked"/>
    public static SubscriptionProvisionParamsAppliedCoupon FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionProvisionParamsAppliedCouponFromRaw
    : IFromRawJson<SubscriptionProvisionParamsAppliedCoupon>
{
    /// <inheritdoc/>
    public SubscriptionProvisionParamsAppliedCoupon FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionProvisionParamsAppliedCoupon.FromRawUnchecked(rawData);
}

/// <summary>
/// Coupon timing configuration
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionProvisionParamsAppliedCouponConfiguration,
        SubscriptionProvisionParamsAppliedCouponConfigurationFromRaw
    >)
)]
public sealed record class SubscriptionProvisionParamsAppliedCouponConfiguration : JsonModel
{
    /// <summary>
    /// Coupon start date
    /// </summary>
    public System::DateTimeOffset? StartDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("startDate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("startDate", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.StartDate;
    }

    public SubscriptionProvisionParamsAppliedCouponConfiguration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionProvisionParamsAppliedCouponConfiguration(
        SubscriptionProvisionParamsAppliedCouponConfiguration subscriptionProvisionParamsAppliedCouponConfiguration
    )
        : base(subscriptionProvisionParamsAppliedCouponConfiguration) { }
#pragma warning restore CS8618

    public SubscriptionProvisionParamsAppliedCouponConfiguration(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionProvisionParamsAppliedCouponConfiguration(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionProvisionParamsAppliedCouponConfigurationFromRaw.FromRawUnchecked"/>
    public static SubscriptionProvisionParamsAppliedCouponConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionProvisionParamsAppliedCouponConfigurationFromRaw
    : IFromRawJson<SubscriptionProvisionParamsAppliedCouponConfiguration>
{
    /// <inheritdoc/>
    public SubscriptionProvisionParamsAppliedCouponConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionProvisionParamsAppliedCouponConfiguration.FromRawUnchecked(rawData);
}

/// <summary>
/// Ad-hoc discount configuration
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionProvisionParamsAppliedCouponDiscount,
        SubscriptionProvisionParamsAppliedCouponDiscountFromRaw
    >)
)]
public sealed record class SubscriptionProvisionParamsAppliedCouponDiscount : JsonModel
{
    /// <summary>
    /// Fixed amounts off by currency
    /// </summary>
    public IReadOnlyList<SubscriptionProvisionParamsAppliedCouponDiscountAmountsOff>? AmountsOff
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<SubscriptionProvisionParamsAppliedCouponDiscountAmountsOff>
            >("amountsOff");
        }
        init
        {
            this._rawData.Set<ImmutableArray<SubscriptionProvisionParamsAppliedCouponDiscountAmountsOff>?>(
                "amountsOff",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Ad-hoc discount
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
    /// Duration in months
    /// </summary>
    public double? DurationInMonths
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("durationInMonths");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("durationInMonths", value);
        }
    }

    /// <summary>
    /// Discount name
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
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
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("percentOff", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.AmountsOff ?? [])
        {
            item.Validate();
        }
        _ = this.Description;
        _ = this.DurationInMonths;
        _ = this.Name;
        _ = this.PercentOff;
    }

    public SubscriptionProvisionParamsAppliedCouponDiscount() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionProvisionParamsAppliedCouponDiscount(
        SubscriptionProvisionParamsAppliedCouponDiscount subscriptionProvisionParamsAppliedCouponDiscount
    )
        : base(subscriptionProvisionParamsAppliedCouponDiscount) { }
#pragma warning restore CS8618

    public SubscriptionProvisionParamsAppliedCouponDiscount(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionProvisionParamsAppliedCouponDiscount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionProvisionParamsAppliedCouponDiscountFromRaw.FromRawUnchecked"/>
    public static SubscriptionProvisionParamsAppliedCouponDiscount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionProvisionParamsAppliedCouponDiscountFromRaw
    : IFromRawJson<SubscriptionProvisionParamsAppliedCouponDiscount>
{
    /// <inheritdoc/>
    public SubscriptionProvisionParamsAppliedCouponDiscount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionProvisionParamsAppliedCouponDiscount.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionProvisionParamsAppliedCouponDiscountAmountsOff,
        SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffFromRaw
    >)
)]
public sealed record class SubscriptionProvisionParamsAppliedCouponDiscountAmountsOff : JsonModel
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
    /// The price currency
    /// </summary>
    public required ApiEnum<
        string,
        SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency
    > Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency>
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

    public SubscriptionProvisionParamsAppliedCouponDiscountAmountsOff() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionProvisionParamsAppliedCouponDiscountAmountsOff(
        SubscriptionProvisionParamsAppliedCouponDiscountAmountsOff subscriptionProvisionParamsAppliedCouponDiscountAmountsOff
    )
        : base(subscriptionProvisionParamsAppliedCouponDiscountAmountsOff) { }
#pragma warning restore CS8618

    public SubscriptionProvisionParamsAppliedCouponDiscountAmountsOff(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionProvisionParamsAppliedCouponDiscountAmountsOff(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffFromRaw.FromRawUnchecked"/>
    public static SubscriptionProvisionParamsAppliedCouponDiscountAmountsOff FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffFromRaw
    : IFromRawJson<SubscriptionProvisionParamsAppliedCouponDiscountAmountsOff>
{
    /// <inheritdoc/>
    public SubscriptionProvisionParamsAppliedCouponDiscountAmountsOff FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOff.FromRawUnchecked(rawData);
}

/// <summary>
/// The price currency
/// </summary>
[JsonConverter(typeof(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrencyConverter))]
public enum SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency
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

sealed class SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrencyConverter
    : JsonConverter<SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency>
{
    public override SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Usd,
            "aed" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Aed,
            "all" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.All,
            "amd" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Amd,
            "ang" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Ang,
            "aud" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Aud,
            "awg" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Awg,
            "azn" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Azn,
            "bam" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Bam,
            "bbd" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Bbd,
            "bdt" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Bdt,
            "bgn" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Bgn,
            "bif" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Bif,
            "bmd" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Bmd,
            "bnd" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Bnd,
            "bsd" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Bsd,
            "bwp" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Bwp,
            "byn" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Byn,
            "bzd" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Bzd,
            "brl" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Brl,
            "cad" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Cad,
            "cdf" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Cdf,
            "chf" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Chf,
            "cny" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Cny,
            "czk" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Czk,
            "dkk" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Dkk,
            "dop" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Dop,
            "dzd" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Dzd,
            "egp" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Egp,
            "etb" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Etb,
            "eur" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Eur,
            "fjd" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Fjd,
            "gbp" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Gbp,
            "gel" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Gel,
            "gip" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Gip,
            "gmd" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Gmd,
            "gyd" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Gyd,
            "hkd" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Hkd,
            "hrk" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Hrk,
            "htg" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Htg,
            "idr" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Idr,
            "ils" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Ils,
            "inr" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Inr,
            "isk" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Isk,
            "jmd" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Jmd,
            "jpy" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Jpy,
            "kes" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Kes,
            "kgs" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Kgs,
            "khr" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Khr,
            "kmf" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Kmf,
            "krw" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Krw,
            "kyd" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Kyd,
            "kzt" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Kzt,
            "lbp" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Lbp,
            "lkr" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Lkr,
            "lrd" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Lrd,
            "lsl" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Lsl,
            "mad" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Mad,
            "mdl" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Mdl,
            "mga" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Mga,
            "mkd" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Mkd,
            "mmk" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Mmk,
            "mnt" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Mnt,
            "mop" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Mop,
            "mro" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Mro,
            "mvr" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Mvr,
            "mwk" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Mwk,
            "mxn" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Mxn,
            "myr" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Myr,
            "mzn" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Mzn,
            "nad" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Nad,
            "ngn" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Ngn,
            "nok" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Nok,
            "npr" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Npr,
            "nzd" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Nzd,
            "pgk" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Pgk,
            "php" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Php,
            "pkr" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Pkr,
            "pln" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Pln,
            "qar" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Qar,
            "ron" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Ron,
            "rsd" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Rsd,
            "rub" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Rub,
            "rwf" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Rwf,
            "sar" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Sar,
            "sbd" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Sbd,
            "scr" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Scr,
            "sek" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Sek,
            "sgd" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Sgd,
            "sle" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Sle,
            "sll" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Sll,
            "sos" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Sos,
            "szl" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Szl,
            "thb" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Thb,
            "tjs" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Tjs,
            "top" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Top,
            "try" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Try,
            "ttd" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Ttd,
            "tzs" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Tzs,
            "uah" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Uah,
            "uzs" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Uzs,
            "vnd" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Vnd,
            "vuv" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Vuv,
            "wst" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Wst,
            "xaf" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Xaf,
            "xcd" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Xcd,
            "yer" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Yer,
            "zar" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Zar,
            "zmw" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Zmw,
            "clp" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Clp,
            "djf" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Djf,
            "gnf" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Gnf,
            "ugx" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Ugx,
            "pyg" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Pyg,
            "xof" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Xof,
            "xpf" => SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Xpf,
            _ => (SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Usd => "usd",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Aed => "aed",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.All => "all",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Amd => "amd",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Ang => "ang",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Aud => "aud",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Awg => "awg",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Azn => "azn",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Bam => "bam",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Bbd => "bbd",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Bdt => "bdt",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Bgn => "bgn",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Bif => "bif",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Bmd => "bmd",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Bnd => "bnd",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Bsd => "bsd",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Bwp => "bwp",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Byn => "byn",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Bzd => "bzd",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Brl => "brl",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Cad => "cad",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Cdf => "cdf",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Chf => "chf",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Cny => "cny",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Czk => "czk",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Dkk => "dkk",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Dop => "dop",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Dzd => "dzd",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Egp => "egp",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Etb => "etb",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Eur => "eur",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Fjd => "fjd",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Gbp => "gbp",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Gel => "gel",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Gip => "gip",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Gmd => "gmd",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Gyd => "gyd",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Hkd => "hkd",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Hrk => "hrk",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Htg => "htg",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Idr => "idr",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Ils => "ils",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Inr => "inr",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Isk => "isk",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Jmd => "jmd",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Jpy => "jpy",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Kes => "kes",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Kgs => "kgs",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Khr => "khr",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Kmf => "kmf",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Krw => "krw",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Kyd => "kyd",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Kzt => "kzt",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Lbp => "lbp",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Lkr => "lkr",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Lrd => "lrd",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Lsl => "lsl",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Mad => "mad",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Mdl => "mdl",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Mga => "mga",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Mkd => "mkd",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Mmk => "mmk",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Mnt => "mnt",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Mop => "mop",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Mro => "mro",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Mvr => "mvr",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Mwk => "mwk",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Mxn => "mxn",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Myr => "myr",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Mzn => "mzn",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Nad => "nad",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Ngn => "ngn",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Nok => "nok",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Npr => "npr",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Nzd => "nzd",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Pgk => "pgk",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Php => "php",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Pkr => "pkr",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Pln => "pln",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Qar => "qar",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Ron => "ron",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Rsd => "rsd",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Rub => "rub",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Rwf => "rwf",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Sar => "sar",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Sbd => "sbd",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Scr => "scr",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Sek => "sek",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Sgd => "sgd",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Sle => "sle",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Sll => "sll",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Sos => "sos",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Szl => "szl",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Thb => "thb",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Tjs => "tjs",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Top => "top",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Try => "try",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Ttd => "ttd",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Tzs => "tzs",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Uah => "uah",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Uzs => "uzs",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Vnd => "vnd",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Vuv => "vuv",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Wst => "wst",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Xaf => "xaf",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Xcd => "xcd",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Yer => "yer",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Zar => "zar",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Zmw => "zmw",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Clp => "clp",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Djf => "djf",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Gnf => "gnf",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Ugx => "ugx",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Pyg => "pyg",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Xof => "xof",
                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Xpf => "xpf",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Billing cycle anchor behavior for the subscription
/// </summary>
[JsonConverter(typeof(SubscriptionProvisionParamsBillingCycleAnchorConverter))]
public enum SubscriptionProvisionParamsBillingCycleAnchor
{
    Unchanged,
    Now,
}

sealed class SubscriptionProvisionParamsBillingCycleAnchorConverter
    : JsonConverter<SubscriptionProvisionParamsBillingCycleAnchor>
{
    public override SubscriptionProvisionParamsBillingCycleAnchor Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "UNCHANGED" => SubscriptionProvisionParamsBillingCycleAnchor.Unchanged,
            "NOW" => SubscriptionProvisionParamsBillingCycleAnchor.Now,
            _ => (SubscriptionProvisionParamsBillingCycleAnchor)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionProvisionParamsBillingCycleAnchor value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionProvisionParamsBillingCycleAnchor.Unchanged => "UNCHANGED",
                SubscriptionProvisionParamsBillingCycleAnchor.Now => "NOW",
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
        SubscriptionProvisionParamsBillingInformation,
        SubscriptionProvisionParamsBillingInformationFromRaw
    >)
)]
public sealed record class SubscriptionProvisionParamsBillingInformation : JsonModel
{
    /// <summary>
    /// Billing address for the subscription
    /// </summary>
    public SubscriptionProvisionParamsBillingInformationBillingAddress? BillingAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SubscriptionProvisionParamsBillingInformationBillingAddress>(
                "billingAddress"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("billingAddress", value);
        }
    }

    /// <summary>
    /// Stripe Connect account to charge on behalf of
    /// </summary>
    public string? ChargeOnBehalfOfAccount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("chargeOnBehalfOfAccount");
        }
        init { this._rawData.Set("chargeOnBehalfOfAccount", value); }
    }

    /// <summary>
    /// Billing integration identifier
    /// </summary>
    public string? IntegrationID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("integrationId");
        }
        init { this._rawData.Set("integrationId", value); }
    }

    /// <summary>
    /// Number of days until invoice is due
    /// </summary>
    public double? InvoiceDaysUntilDue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("invoiceDaysUntilDue");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("invoiceDaysUntilDue", value);
        }
    }

    /// <summary>
    /// Whether the subscription is backdated
    /// </summary>
    public bool? IsBackdated
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isBackdated");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isBackdated", value);
        }
    }

    /// <summary>
    /// Whether the invoice is marked as paid
    /// </summary>
    public bool? IsInvoicePaid
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isInvoicePaid");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isInvoicePaid", value);
        }
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
    /// How to handle proration for billing changes
    /// </summary>
    public ApiEnum<
        string,
        SubscriptionProvisionParamsBillingInformationProrationBehavior
    >? ProrationBehavior
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, SubscriptionProvisionParamsBillingInformationProrationBehavior>
            >("prorationBehavior");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("prorationBehavior", value);
        }
    }

    /// <summary>
    /// Customer tax identification numbers
    /// </summary>
    public IReadOnlyList<SubscriptionProvisionParamsBillingInformationTaxID>? TaxIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<SubscriptionProvisionParamsBillingInformationTaxID>
            >("taxIds");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<SubscriptionProvisionParamsBillingInformationTaxID>?>(
                "taxIds",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Tax percentage (0-100)
    /// </summary>
    public double? TaxPercentage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("taxPercentage");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("taxPercentage", value);
        }
    }

    /// <summary>
    /// Tax rate identifiers to apply
    /// </summary>
    public IReadOnlyList<string>? TaxRateIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("taxRateIds");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "taxRateIds",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.BillingAddress?.Validate();
        _ = this.ChargeOnBehalfOfAccount;
        _ = this.IntegrationID;
        _ = this.InvoiceDaysUntilDue;
        _ = this.IsBackdated;
        _ = this.IsInvoicePaid;
        _ = this.Metadata;
        this.ProrationBehavior?.Validate();
        foreach (var item in this.TaxIds ?? [])
        {
            item.Validate();
        }
        _ = this.TaxPercentage;
        _ = this.TaxRateIds;
    }

    public SubscriptionProvisionParamsBillingInformation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionProvisionParamsBillingInformation(
        SubscriptionProvisionParamsBillingInformation subscriptionProvisionParamsBillingInformation
    )
        : base(subscriptionProvisionParamsBillingInformation) { }
#pragma warning restore CS8618

    public SubscriptionProvisionParamsBillingInformation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionProvisionParamsBillingInformation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionProvisionParamsBillingInformationFromRaw.FromRawUnchecked"/>
    public static SubscriptionProvisionParamsBillingInformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionProvisionParamsBillingInformationFromRaw
    : IFromRawJson<SubscriptionProvisionParamsBillingInformation>
{
    /// <inheritdoc/>
    public SubscriptionProvisionParamsBillingInformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionProvisionParamsBillingInformation.FromRawUnchecked(rawData);
}

/// <summary>
/// Billing address for the subscription
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionProvisionParamsBillingInformationBillingAddress,
        SubscriptionProvisionParamsBillingInformationBillingAddressFromRaw
    >)
)]
public sealed record class SubscriptionProvisionParamsBillingInformationBillingAddress : JsonModel
{
    public string? City
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("city");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("city", value);
        }
    }

    public string? Country
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("country");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("country", value);
        }
    }

    public string? Line1
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("line1");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("line1", value);
        }
    }

    public string? Line2
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("line2");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("line2", value);
        }
    }

    public string? PostalCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("postalCode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("postalCode", value);
        }
    }

    public string? State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("state");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("state", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.City;
        _ = this.Country;
        _ = this.Line1;
        _ = this.Line2;
        _ = this.PostalCode;
        _ = this.State;
    }

    public SubscriptionProvisionParamsBillingInformationBillingAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionProvisionParamsBillingInformationBillingAddress(
        SubscriptionProvisionParamsBillingInformationBillingAddress subscriptionProvisionParamsBillingInformationBillingAddress
    )
        : base(subscriptionProvisionParamsBillingInformationBillingAddress) { }
#pragma warning restore CS8618

    public SubscriptionProvisionParamsBillingInformationBillingAddress(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionProvisionParamsBillingInformationBillingAddress(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionProvisionParamsBillingInformationBillingAddressFromRaw.FromRawUnchecked"/>
    public static SubscriptionProvisionParamsBillingInformationBillingAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionProvisionParamsBillingInformationBillingAddressFromRaw
    : IFromRawJson<SubscriptionProvisionParamsBillingInformationBillingAddress>
{
    /// <inheritdoc/>
    public SubscriptionProvisionParamsBillingInformationBillingAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionProvisionParamsBillingInformationBillingAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// How to handle proration for billing changes
/// </summary>
[JsonConverter(typeof(SubscriptionProvisionParamsBillingInformationProrationBehaviorConverter))]
public enum SubscriptionProvisionParamsBillingInformationProrationBehavior
{
    InvoiceImmediately,
    CreateProrations,
    None,
}

sealed class SubscriptionProvisionParamsBillingInformationProrationBehaviorConverter
    : JsonConverter<SubscriptionProvisionParamsBillingInformationProrationBehavior>
{
    public override SubscriptionProvisionParamsBillingInformationProrationBehavior Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "INVOICE_IMMEDIATELY" =>
                SubscriptionProvisionParamsBillingInformationProrationBehavior.InvoiceImmediately,
            "CREATE_PRORATIONS" =>
                SubscriptionProvisionParamsBillingInformationProrationBehavior.CreateProrations,
            "NONE" => SubscriptionProvisionParamsBillingInformationProrationBehavior.None,
            _ => (SubscriptionProvisionParamsBillingInformationProrationBehavior)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionProvisionParamsBillingInformationProrationBehavior value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionProvisionParamsBillingInformationProrationBehavior.InvoiceImmediately =>
                    "INVOICE_IMMEDIATELY",
                SubscriptionProvisionParamsBillingInformationProrationBehavior.CreateProrations =>
                    "CREATE_PRORATIONS",
                SubscriptionProvisionParamsBillingInformationProrationBehavior.None => "NONE",
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
        SubscriptionProvisionParamsBillingInformationTaxID,
        SubscriptionProvisionParamsBillingInformationTaxIDFromRaw
    >)
)]
public sealed record class SubscriptionProvisionParamsBillingInformationTaxID : JsonModel
{
    /// <summary>
    /// The type of tax exemption identifier, such as VAT.
    /// </summary>
    public required string Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// The actual tax identifier value
    /// </summary>
    public required string Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("value");
        }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Type;
        _ = this.Value;
    }

    public SubscriptionProvisionParamsBillingInformationTaxID() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionProvisionParamsBillingInformationTaxID(
        SubscriptionProvisionParamsBillingInformationTaxID subscriptionProvisionParamsBillingInformationTaxID
    )
        : base(subscriptionProvisionParamsBillingInformationTaxID) { }
#pragma warning restore CS8618

    public SubscriptionProvisionParamsBillingInformationTaxID(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionProvisionParamsBillingInformationTaxID(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionProvisionParamsBillingInformationTaxIDFromRaw.FromRawUnchecked"/>
    public static SubscriptionProvisionParamsBillingInformationTaxID FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionProvisionParamsBillingInformationTaxIDFromRaw
    : IFromRawJson<SubscriptionProvisionParamsBillingInformationTaxID>
{
    /// <inheritdoc/>
    public SubscriptionProvisionParamsBillingInformationTaxID FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionProvisionParamsBillingInformationTaxID.FromRawUnchecked(rawData);
}

/// <summary>
/// Billing period (MONTHLY or ANNUALLY)
/// </summary>
[JsonConverter(typeof(SubscriptionProvisionParamsBillingPeriodConverter))]
public enum SubscriptionProvisionParamsBillingPeriod
{
    Monthly,
    Annually,
}

sealed class SubscriptionProvisionParamsBillingPeriodConverter
    : JsonConverter<SubscriptionProvisionParamsBillingPeriod>
{
    public override SubscriptionProvisionParamsBillingPeriod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "MONTHLY" => SubscriptionProvisionParamsBillingPeriod.Monthly,
            "ANNUALLY" => SubscriptionProvisionParamsBillingPeriod.Annually,
            _ => (SubscriptionProvisionParamsBillingPeriod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionProvisionParamsBillingPeriod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionProvisionParamsBillingPeriod.Monthly => "MONTHLY",
                SubscriptionProvisionParamsBillingPeriod.Annually => "ANNUALLY",
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
        SubscriptionProvisionParamsBudget,
        SubscriptionProvisionParamsBudgetFromRaw
    >)
)]
public sealed record class SubscriptionProvisionParamsBudget : JsonModel
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

    public SubscriptionProvisionParamsBudget() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionProvisionParamsBudget(
        SubscriptionProvisionParamsBudget subscriptionProvisionParamsBudget
    )
        : base(subscriptionProvisionParamsBudget) { }
#pragma warning restore CS8618

    public SubscriptionProvisionParamsBudget(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionProvisionParamsBudget(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionProvisionParamsBudgetFromRaw.FromRawUnchecked"/>
    public static SubscriptionProvisionParamsBudget FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionProvisionParamsBudgetFromRaw : IFromRawJson<SubscriptionProvisionParamsBudget>
{
    /// <inheritdoc/>
    public SubscriptionProvisionParamsBudget FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionProvisionParamsBudget.FromRawUnchecked(rawData);
}

/// <summary>
/// Charge item
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionProvisionParamsCharge,
        SubscriptionProvisionParamsChargeFromRaw
    >)
)]
public sealed record class SubscriptionProvisionParamsCharge : JsonModel
{
    /// <summary>
    /// Charge ID
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
    /// Charge quantity
    /// </summary>
    public required double Quantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("quantity");
        }
        init { this._rawData.Set("quantity", value); }
    }

    /// <summary>
    /// Charge type
    /// </summary>
    public required ApiEnum<string, SubscriptionProvisionParamsChargeType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, SubscriptionProvisionParamsChargeType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Quantity;
        this.Type.Validate();
    }

    public SubscriptionProvisionParamsCharge() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionProvisionParamsCharge(
        SubscriptionProvisionParamsCharge subscriptionProvisionParamsCharge
    )
        : base(subscriptionProvisionParamsCharge) { }
#pragma warning restore CS8618

    public SubscriptionProvisionParamsCharge(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionProvisionParamsCharge(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionProvisionParamsChargeFromRaw.FromRawUnchecked"/>
    public static SubscriptionProvisionParamsCharge FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionProvisionParamsChargeFromRaw : IFromRawJson<SubscriptionProvisionParamsCharge>
{
    /// <inheritdoc/>
    public SubscriptionProvisionParamsCharge FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionProvisionParamsCharge.FromRawUnchecked(rawData);
}

/// <summary>
/// Charge type
/// </summary>
[JsonConverter(typeof(SubscriptionProvisionParamsChargeTypeConverter))]
public enum SubscriptionProvisionParamsChargeType
{
    Feature,
    Credit,
}

sealed class SubscriptionProvisionParamsChargeTypeConverter
    : JsonConverter<SubscriptionProvisionParamsChargeType>
{
    public override SubscriptionProvisionParamsChargeType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FEATURE" => SubscriptionProvisionParamsChargeType.Feature,
            "CREDIT" => SubscriptionProvisionParamsChargeType.Credit,
            _ => (SubscriptionProvisionParamsChargeType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionProvisionParamsChargeType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionProvisionParamsChargeType.Feature => "FEATURE",
                SubscriptionProvisionParamsChargeType.Credit => "CREDIT",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Checkout page configuration for payment collection
/// </summary>
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
    typeof(JsonModelConverter<
        SubscriptionProvisionParamsMinimumSpend,
        SubscriptionProvisionParamsMinimumSpendFromRaw
    >)
)]
public sealed record class SubscriptionProvisionParamsMinimumSpend : JsonModel
{
    /// <summary>
    /// Minimum spend amount
    /// </summary>
    public SubscriptionProvisionParamsMinimumSpendMinimum? Minimum
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SubscriptionProvisionParamsMinimumSpendMinimum>(
                "minimum"
            );
        }
        init { this._rawData.Set("minimum", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Minimum?.Validate();
    }

    public SubscriptionProvisionParamsMinimumSpend() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionProvisionParamsMinimumSpend(
        SubscriptionProvisionParamsMinimumSpend subscriptionProvisionParamsMinimumSpend
    )
        : base(subscriptionProvisionParamsMinimumSpend) { }
#pragma warning restore CS8618

    public SubscriptionProvisionParamsMinimumSpend(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionProvisionParamsMinimumSpend(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionProvisionParamsMinimumSpendFromRaw.FromRawUnchecked"/>
    public static SubscriptionProvisionParamsMinimumSpend FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionProvisionParamsMinimumSpendFromRaw
    : IFromRawJson<SubscriptionProvisionParamsMinimumSpend>
{
    /// <inheritdoc/>
    public SubscriptionProvisionParamsMinimumSpend FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionProvisionParamsMinimumSpend.FromRawUnchecked(rawData);
}

/// <summary>
/// Minimum spend amount
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionProvisionParamsMinimumSpendMinimum,
        SubscriptionProvisionParamsMinimumSpendMinimumFromRaw
    >)
)]
public sealed record class SubscriptionProvisionParamsMinimumSpendMinimum : JsonModel
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
    /// The billing country code of the price
    /// </summary>
    public string? BillingCountryCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billingCountryCode");
        }
        init { this._rawData.Set("billingCountryCode", value); }
    }

    /// <summary>
    /// The price currency
    /// </summary>
    public ApiEnum<string, SubscriptionProvisionParamsMinimumSpendMinimumCurrency>? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, SubscriptionProvisionParamsMinimumSpendMinimumCurrency>
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
        _ = this.BillingCountryCode;
        this.Currency?.Validate();
    }

    public SubscriptionProvisionParamsMinimumSpendMinimum() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionProvisionParamsMinimumSpendMinimum(
        SubscriptionProvisionParamsMinimumSpendMinimum subscriptionProvisionParamsMinimumSpendMinimum
    )
        : base(subscriptionProvisionParamsMinimumSpendMinimum) { }
#pragma warning restore CS8618

    public SubscriptionProvisionParamsMinimumSpendMinimum(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionProvisionParamsMinimumSpendMinimum(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionProvisionParamsMinimumSpendMinimumFromRaw.FromRawUnchecked"/>
    public static SubscriptionProvisionParamsMinimumSpendMinimum FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionProvisionParamsMinimumSpendMinimumFromRaw
    : IFromRawJson<SubscriptionProvisionParamsMinimumSpendMinimum>
{
    /// <inheritdoc/>
    public SubscriptionProvisionParamsMinimumSpendMinimum FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionProvisionParamsMinimumSpendMinimum.FromRawUnchecked(rawData);
}

/// <summary>
/// The price currency
/// </summary>
[JsonConverter(typeof(SubscriptionProvisionParamsMinimumSpendMinimumCurrencyConverter))]
public enum SubscriptionProvisionParamsMinimumSpendMinimumCurrency
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

sealed class SubscriptionProvisionParamsMinimumSpendMinimumCurrencyConverter
    : JsonConverter<SubscriptionProvisionParamsMinimumSpendMinimumCurrency>
{
    public override SubscriptionProvisionParamsMinimumSpendMinimumCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Usd,
            "aed" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Aed,
            "all" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.All,
            "amd" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Amd,
            "ang" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Ang,
            "aud" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Aud,
            "awg" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Awg,
            "azn" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Azn,
            "bam" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Bam,
            "bbd" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Bbd,
            "bdt" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Bdt,
            "bgn" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Bgn,
            "bif" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Bif,
            "bmd" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Bmd,
            "bnd" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Bnd,
            "bsd" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Bsd,
            "bwp" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Bwp,
            "byn" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Byn,
            "bzd" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Bzd,
            "brl" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Brl,
            "cad" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Cad,
            "cdf" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Cdf,
            "chf" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Chf,
            "cny" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Cny,
            "czk" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Czk,
            "dkk" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Dkk,
            "dop" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Dop,
            "dzd" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Dzd,
            "egp" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Egp,
            "etb" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Etb,
            "eur" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Eur,
            "fjd" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Fjd,
            "gbp" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Gbp,
            "gel" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Gel,
            "gip" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Gip,
            "gmd" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Gmd,
            "gyd" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Gyd,
            "hkd" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Hkd,
            "hrk" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Hrk,
            "htg" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Htg,
            "idr" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Idr,
            "ils" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Ils,
            "inr" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Inr,
            "isk" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Isk,
            "jmd" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Jmd,
            "jpy" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Jpy,
            "kes" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Kes,
            "kgs" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Kgs,
            "khr" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Khr,
            "kmf" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Kmf,
            "krw" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Krw,
            "kyd" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Kyd,
            "kzt" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Kzt,
            "lbp" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Lbp,
            "lkr" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Lkr,
            "lrd" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Lrd,
            "lsl" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Lsl,
            "mad" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Mad,
            "mdl" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Mdl,
            "mga" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Mga,
            "mkd" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Mkd,
            "mmk" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Mmk,
            "mnt" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Mnt,
            "mop" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Mop,
            "mro" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Mro,
            "mvr" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Mvr,
            "mwk" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Mwk,
            "mxn" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Mxn,
            "myr" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Myr,
            "mzn" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Mzn,
            "nad" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Nad,
            "ngn" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Ngn,
            "nok" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Nok,
            "npr" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Npr,
            "nzd" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Nzd,
            "pgk" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Pgk,
            "php" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Php,
            "pkr" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Pkr,
            "pln" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Pln,
            "qar" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Qar,
            "ron" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Ron,
            "rsd" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Rsd,
            "rub" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Rub,
            "rwf" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Rwf,
            "sar" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Sar,
            "sbd" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Sbd,
            "scr" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Scr,
            "sek" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Sek,
            "sgd" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Sgd,
            "sle" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Sle,
            "sll" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Sll,
            "sos" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Sos,
            "szl" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Szl,
            "thb" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Thb,
            "tjs" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Tjs,
            "top" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Top,
            "try" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Try,
            "ttd" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Ttd,
            "tzs" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Tzs,
            "uah" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Uah,
            "uzs" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Uzs,
            "vnd" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Vnd,
            "vuv" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Vuv,
            "wst" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Wst,
            "xaf" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Xaf,
            "xcd" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Xcd,
            "yer" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Yer,
            "zar" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Zar,
            "zmw" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Zmw,
            "clp" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Clp,
            "djf" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Djf,
            "gnf" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Gnf,
            "ugx" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Ugx,
            "pyg" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Pyg,
            "xof" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Xof,
            "xpf" => SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Xpf,
            _ => (SubscriptionProvisionParamsMinimumSpendMinimumCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionProvisionParamsMinimumSpendMinimumCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Usd => "usd",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Aed => "aed",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.All => "all",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Amd => "amd",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Ang => "ang",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Aud => "aud",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Awg => "awg",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Azn => "azn",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Bam => "bam",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Bbd => "bbd",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Bdt => "bdt",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Bgn => "bgn",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Bif => "bif",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Bmd => "bmd",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Bnd => "bnd",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Bsd => "bsd",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Bwp => "bwp",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Byn => "byn",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Bzd => "bzd",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Brl => "brl",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Cad => "cad",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Cdf => "cdf",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Chf => "chf",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Cny => "cny",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Czk => "czk",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Dkk => "dkk",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Dop => "dop",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Dzd => "dzd",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Egp => "egp",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Etb => "etb",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Eur => "eur",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Fjd => "fjd",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Gbp => "gbp",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Gel => "gel",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Gip => "gip",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Gmd => "gmd",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Gyd => "gyd",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Hkd => "hkd",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Hrk => "hrk",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Htg => "htg",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Idr => "idr",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Ils => "ils",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Inr => "inr",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Isk => "isk",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Jmd => "jmd",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Jpy => "jpy",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Kes => "kes",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Kgs => "kgs",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Khr => "khr",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Kmf => "kmf",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Krw => "krw",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Kyd => "kyd",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Kzt => "kzt",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Lbp => "lbp",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Lkr => "lkr",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Lrd => "lrd",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Lsl => "lsl",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Mad => "mad",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Mdl => "mdl",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Mga => "mga",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Mkd => "mkd",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Mmk => "mmk",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Mnt => "mnt",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Mop => "mop",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Mro => "mro",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Mvr => "mvr",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Mwk => "mwk",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Mxn => "mxn",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Myr => "myr",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Mzn => "mzn",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Nad => "nad",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Ngn => "ngn",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Nok => "nok",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Npr => "npr",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Nzd => "nzd",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Pgk => "pgk",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Php => "php",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Pkr => "pkr",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Pln => "pln",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Qar => "qar",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Ron => "ron",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Rsd => "rsd",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Rub => "rub",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Rwf => "rwf",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Sar => "sar",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Sbd => "sbd",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Scr => "scr",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Sek => "sek",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Sgd => "sgd",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Sle => "sle",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Sll => "sll",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Sos => "sos",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Szl => "szl",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Thb => "thb",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Tjs => "tjs",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Top => "top",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Try => "try",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Ttd => "ttd",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Tzs => "tzs",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Uah => "uah",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Uzs => "uzs",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Vnd => "vnd",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Vuv => "vuv",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Wst => "wst",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Xaf => "xaf",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Xcd => "xcd",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Yer => "yer",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Zar => "zar",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Zmw => "zmw",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Clp => "clp",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Djf => "djf",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Gnf => "gnf",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Ugx => "ugx",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Pyg => "pyg",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Xof => "xof",
                SubscriptionProvisionParamsMinimumSpendMinimumCurrency.Xpf => "xpf",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// How payments should be collected for this subscription
/// </summary>
[JsonConverter(typeof(PaymentCollectionMethodConverter))]
public enum PaymentCollectionMethod
{
    Charge,
    Invoice,
    None,
}

sealed class PaymentCollectionMethodConverter : JsonConverter<PaymentCollectionMethod>
{
    public override PaymentCollectionMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "CHARGE" => PaymentCollectionMethod.Charge,
            "INVOICE" => PaymentCollectionMethod.Invoice,
            "NONE" => PaymentCollectionMethod.None,
            _ => (PaymentCollectionMethod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PaymentCollectionMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PaymentCollectionMethod.Charge => "CHARGE",
                PaymentCollectionMethod.Invoice => "INVOICE",
                PaymentCollectionMethod.None => "NONE",
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
        SubscriptionProvisionParamsPriceOverride,
        SubscriptionProvisionParamsPriceOverrideFromRaw
    >)
)]
public sealed record class SubscriptionProvisionParamsPriceOverride : JsonModel
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

    public ApiEnum<string, CreditGrantCadence>? CreditGrantCadence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CreditGrantCadence>>(
                "creditGrantCadence"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("creditGrantCadence", value);
        }
    }

    public CreditRate? CreditRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CreditRate>("creditRate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("creditRate", value);
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
    /// Override price amount
    /// </summary>
    public SubscriptionProvisionParamsPriceOverridePrice? Price
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SubscriptionProvisionParamsPriceOverridePrice>(
                "price"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("price", value);
        }
    }

    /// <summary>
    /// Pricing tiers configuration
    /// </summary>
    public IReadOnlyList<Tier>? Tiers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Tier>>("tiers");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Tier>?>(
                "tiers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AddonID;
        _ = this.BaseCharge;
        _ = this.BlockSize;
        this.CreditGrantCadence?.Validate();
        this.CreditRate?.Validate();
        _ = this.FeatureID;
        this.Price?.Validate();
        foreach (var item in this.Tiers ?? [])
        {
            item.Validate();
        }
    }

    public SubscriptionProvisionParamsPriceOverride() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionProvisionParamsPriceOverride(
        SubscriptionProvisionParamsPriceOverride subscriptionProvisionParamsPriceOverride
    )
        : base(subscriptionProvisionParamsPriceOverride) { }
#pragma warning restore CS8618

    public SubscriptionProvisionParamsPriceOverride(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionProvisionParamsPriceOverride(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionProvisionParamsPriceOverrideFromRaw.FromRawUnchecked"/>
    public static SubscriptionProvisionParamsPriceOverride FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionProvisionParamsPriceOverrideFromRaw
    : IFromRawJson<SubscriptionProvisionParamsPriceOverride>
{
    /// <inheritdoc/>
    public SubscriptionProvisionParamsPriceOverride FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionProvisionParamsPriceOverride.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(CreditGrantCadenceConverter))]
public enum CreditGrantCadence
{
    BeginningOfBillingPeriod,
    Monthly,
}

sealed class CreditGrantCadenceConverter : JsonConverter<CreditGrantCadence>
{
    public override CreditGrantCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "BEGINNING_OF_BILLING_PERIOD" => CreditGrantCadence.BeginningOfBillingPeriod,
            "MONTHLY" => CreditGrantCadence.Monthly,
            _ => (CreditGrantCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CreditGrantCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CreditGrantCadence.BeginningOfBillingPeriod => "BEGINNING_OF_BILLING_PERIOD",
                CreditGrantCadence.Monthly => "MONTHLY",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<CreditRate, CreditRateFromRaw>))]
public sealed record class CreditRate : JsonModel
{
    /// <summary>
    /// The credit rate amount
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
    /// The custom currency refId for the credit rate
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
    /// A custom formula for calculating cost based on single event dimensions
    /// </summary>
    public string? CostFormula
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("costFormula");
        }
        init { this._rawData.Set("costFormula", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.CurrencyID;
        _ = this.CostFormula;
    }

    public CreditRate() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreditRate(CreditRate creditRate)
        : base(creditRate) { }
#pragma warning restore CS8618

    public CreditRate(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditRate(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreditRateFromRaw.FromRawUnchecked"/>
    public static CreditRate FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreditRateFromRaw : IFromRawJson<CreditRate>
{
    /// <inheritdoc/>
    public CreditRate FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CreditRate.FromRawUnchecked(rawData);
}

/// <summary>
/// Override price amount
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionProvisionParamsPriceOverridePrice,
        SubscriptionProvisionParamsPriceOverridePriceFromRaw
    >)
)]
public sealed record class SubscriptionProvisionParamsPriceOverridePrice : JsonModel
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
    /// The billing country code of the price
    /// </summary>
    public string? BillingCountryCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billingCountryCode");
        }
        init { this._rawData.Set("billingCountryCode", value); }
    }

    /// <summary>
    /// The price currency
    /// </summary>
    public ApiEnum<string, SubscriptionProvisionParamsPriceOverridePriceCurrency>? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, SubscriptionProvisionParamsPriceOverridePriceCurrency>
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
        _ = this.BillingCountryCode;
        this.Currency?.Validate();
    }

    public SubscriptionProvisionParamsPriceOverridePrice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionProvisionParamsPriceOverridePrice(
        SubscriptionProvisionParamsPriceOverridePrice subscriptionProvisionParamsPriceOverridePrice
    )
        : base(subscriptionProvisionParamsPriceOverridePrice) { }
#pragma warning restore CS8618

    public SubscriptionProvisionParamsPriceOverridePrice(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionProvisionParamsPriceOverridePrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionProvisionParamsPriceOverridePriceFromRaw.FromRawUnchecked"/>
    public static SubscriptionProvisionParamsPriceOverridePrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionProvisionParamsPriceOverridePriceFromRaw
    : IFromRawJson<SubscriptionProvisionParamsPriceOverridePrice>
{
    /// <inheritdoc/>
    public SubscriptionProvisionParamsPriceOverridePrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionProvisionParamsPriceOverridePrice.FromRawUnchecked(rawData);
}

/// <summary>
/// The price currency
/// </summary>
[JsonConverter(typeof(SubscriptionProvisionParamsPriceOverridePriceCurrencyConverter))]
public enum SubscriptionProvisionParamsPriceOverridePriceCurrency
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

sealed class SubscriptionProvisionParamsPriceOverridePriceCurrencyConverter
    : JsonConverter<SubscriptionProvisionParamsPriceOverridePriceCurrency>
{
    public override SubscriptionProvisionParamsPriceOverridePriceCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Usd,
            "aed" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Aed,
            "all" => SubscriptionProvisionParamsPriceOverridePriceCurrency.All,
            "amd" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Amd,
            "ang" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Ang,
            "aud" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Aud,
            "awg" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Awg,
            "azn" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Azn,
            "bam" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Bam,
            "bbd" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Bbd,
            "bdt" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Bdt,
            "bgn" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Bgn,
            "bif" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Bif,
            "bmd" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Bmd,
            "bnd" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Bnd,
            "bsd" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Bsd,
            "bwp" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Bwp,
            "byn" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Byn,
            "bzd" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Bzd,
            "brl" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Brl,
            "cad" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Cad,
            "cdf" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Cdf,
            "chf" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Chf,
            "cny" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Cny,
            "czk" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Czk,
            "dkk" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Dkk,
            "dop" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Dop,
            "dzd" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Dzd,
            "egp" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Egp,
            "etb" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Etb,
            "eur" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Eur,
            "fjd" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Fjd,
            "gbp" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Gbp,
            "gel" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Gel,
            "gip" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Gip,
            "gmd" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Gmd,
            "gyd" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Gyd,
            "hkd" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Hkd,
            "hrk" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Hrk,
            "htg" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Htg,
            "idr" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Idr,
            "ils" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Ils,
            "inr" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Inr,
            "isk" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Isk,
            "jmd" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Jmd,
            "jpy" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Jpy,
            "kes" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Kes,
            "kgs" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Kgs,
            "khr" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Khr,
            "kmf" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Kmf,
            "krw" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Krw,
            "kyd" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Kyd,
            "kzt" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Kzt,
            "lbp" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Lbp,
            "lkr" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Lkr,
            "lrd" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Lrd,
            "lsl" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Lsl,
            "mad" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Mad,
            "mdl" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Mdl,
            "mga" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Mga,
            "mkd" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Mkd,
            "mmk" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Mmk,
            "mnt" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Mnt,
            "mop" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Mop,
            "mro" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Mro,
            "mvr" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Mvr,
            "mwk" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Mwk,
            "mxn" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Mxn,
            "myr" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Myr,
            "mzn" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Mzn,
            "nad" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Nad,
            "ngn" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Ngn,
            "nok" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Nok,
            "npr" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Npr,
            "nzd" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Nzd,
            "pgk" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Pgk,
            "php" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Php,
            "pkr" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Pkr,
            "pln" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Pln,
            "qar" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Qar,
            "ron" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Ron,
            "rsd" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Rsd,
            "rub" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Rub,
            "rwf" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Rwf,
            "sar" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Sar,
            "sbd" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Sbd,
            "scr" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Scr,
            "sek" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Sek,
            "sgd" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Sgd,
            "sle" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Sle,
            "sll" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Sll,
            "sos" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Sos,
            "szl" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Szl,
            "thb" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Thb,
            "tjs" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Tjs,
            "top" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Top,
            "try" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Try,
            "ttd" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Ttd,
            "tzs" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Tzs,
            "uah" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Uah,
            "uzs" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Uzs,
            "vnd" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Vnd,
            "vuv" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Vuv,
            "wst" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Wst,
            "xaf" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Xaf,
            "xcd" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Xcd,
            "yer" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Yer,
            "zar" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Zar,
            "zmw" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Zmw,
            "clp" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Clp,
            "djf" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Djf,
            "gnf" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Gnf,
            "ugx" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Ugx,
            "pyg" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Pyg,
            "xof" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Xof,
            "xpf" => SubscriptionProvisionParamsPriceOverridePriceCurrency.Xpf,
            _ => (SubscriptionProvisionParamsPriceOverridePriceCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionProvisionParamsPriceOverridePriceCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Usd => "usd",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Aed => "aed",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.All => "all",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Amd => "amd",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Ang => "ang",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Aud => "aud",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Awg => "awg",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Azn => "azn",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Bam => "bam",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Bbd => "bbd",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Bdt => "bdt",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Bgn => "bgn",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Bif => "bif",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Bmd => "bmd",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Bnd => "bnd",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Bsd => "bsd",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Bwp => "bwp",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Byn => "byn",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Bzd => "bzd",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Brl => "brl",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Cad => "cad",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Cdf => "cdf",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Chf => "chf",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Cny => "cny",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Czk => "czk",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Dkk => "dkk",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Dop => "dop",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Dzd => "dzd",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Egp => "egp",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Etb => "etb",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Eur => "eur",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Fjd => "fjd",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Gbp => "gbp",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Gel => "gel",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Gip => "gip",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Gmd => "gmd",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Gyd => "gyd",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Hkd => "hkd",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Hrk => "hrk",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Htg => "htg",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Idr => "idr",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Ils => "ils",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Inr => "inr",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Isk => "isk",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Jmd => "jmd",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Jpy => "jpy",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Kes => "kes",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Kgs => "kgs",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Khr => "khr",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Kmf => "kmf",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Krw => "krw",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Kyd => "kyd",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Kzt => "kzt",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Lbp => "lbp",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Lkr => "lkr",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Lrd => "lrd",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Lsl => "lsl",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Mad => "mad",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Mdl => "mdl",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Mga => "mga",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Mkd => "mkd",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Mmk => "mmk",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Mnt => "mnt",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Mop => "mop",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Mro => "mro",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Mvr => "mvr",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Mwk => "mwk",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Mxn => "mxn",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Myr => "myr",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Mzn => "mzn",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Nad => "nad",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Ngn => "ngn",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Nok => "nok",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Npr => "npr",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Nzd => "nzd",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Pgk => "pgk",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Php => "php",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Pkr => "pkr",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Pln => "pln",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Qar => "qar",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Ron => "ron",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Rsd => "rsd",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Rub => "rub",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Rwf => "rwf",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Sar => "sar",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Sbd => "sbd",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Scr => "scr",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Sek => "sek",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Sgd => "sgd",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Sle => "sle",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Sll => "sll",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Sos => "sos",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Szl => "szl",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Thb => "thb",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Tjs => "tjs",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Top => "top",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Try => "try",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Ttd => "ttd",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Tzs => "tzs",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Uah => "uah",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Uzs => "uzs",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Vnd => "vnd",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Vuv => "vuv",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Wst => "wst",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Xaf => "xaf",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Xcd => "xcd",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Yer => "yer",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Zar => "zar",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Zmw => "zmw",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Clp => "clp",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Djf => "djf",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Gnf => "gnf",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Ugx => "ugx",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Pyg => "pyg",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Xof => "xof",
                SubscriptionProvisionParamsPriceOverridePriceCurrency.Xpf => "xpf",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<Tier, TierFromRaw>))]
public sealed record class Tier : JsonModel
{
    /// <summary>
    /// The flat fee price of the price tier
    /// </summary>
    public FlatPrice? FlatPrice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FlatPrice>("flatPrice");
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
    public UnitPrice? UnitPrice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UnitPrice>("unitPrice");
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

    public Tier() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Tier(Tier tier)
        : base(tier) { }
#pragma warning restore CS8618

    public Tier(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Tier(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TierFromRaw.FromRawUnchecked"/>
    public static Tier FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TierFromRaw : IFromRawJson<Tier>
{
    /// <inheritdoc/>
    public Tier FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Tier.FromRawUnchecked(rawData);
}

/// <summary>
/// The flat fee price of the price tier
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FlatPrice, FlatPriceFromRaw>))]
public sealed record class FlatPrice : JsonModel
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
    /// The billing country code of the price
    /// </summary>
    public string? BillingCountryCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billingCountryCode");
        }
        init { this._rawData.Set("billingCountryCode", value); }
    }

    /// <summary>
    /// The price currency
    /// </summary>
    public ApiEnum<string, FlatPriceCurrency>? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, FlatPriceCurrency>>("currency");
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
        _ = this.BillingCountryCode;
        this.Currency?.Validate();
    }

    public FlatPrice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FlatPrice(FlatPrice flatPrice)
        : base(flatPrice) { }
#pragma warning restore CS8618

    public FlatPrice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FlatPrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FlatPriceFromRaw.FromRawUnchecked"/>
    public static FlatPrice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FlatPriceFromRaw : IFromRawJson<FlatPrice>
{
    /// <inheritdoc/>
    public FlatPrice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FlatPrice.FromRawUnchecked(rawData);
}

/// <summary>
/// The price currency
/// </summary>
[JsonConverter(typeof(FlatPriceCurrencyConverter))]
public enum FlatPriceCurrency
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

sealed class FlatPriceCurrencyConverter : JsonConverter<FlatPriceCurrency>
{
    public override FlatPriceCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => FlatPriceCurrency.Usd,
            "aed" => FlatPriceCurrency.Aed,
            "all" => FlatPriceCurrency.All,
            "amd" => FlatPriceCurrency.Amd,
            "ang" => FlatPriceCurrency.Ang,
            "aud" => FlatPriceCurrency.Aud,
            "awg" => FlatPriceCurrency.Awg,
            "azn" => FlatPriceCurrency.Azn,
            "bam" => FlatPriceCurrency.Bam,
            "bbd" => FlatPriceCurrency.Bbd,
            "bdt" => FlatPriceCurrency.Bdt,
            "bgn" => FlatPriceCurrency.Bgn,
            "bif" => FlatPriceCurrency.Bif,
            "bmd" => FlatPriceCurrency.Bmd,
            "bnd" => FlatPriceCurrency.Bnd,
            "bsd" => FlatPriceCurrency.Bsd,
            "bwp" => FlatPriceCurrency.Bwp,
            "byn" => FlatPriceCurrency.Byn,
            "bzd" => FlatPriceCurrency.Bzd,
            "brl" => FlatPriceCurrency.Brl,
            "cad" => FlatPriceCurrency.Cad,
            "cdf" => FlatPriceCurrency.Cdf,
            "chf" => FlatPriceCurrency.Chf,
            "cny" => FlatPriceCurrency.Cny,
            "czk" => FlatPriceCurrency.Czk,
            "dkk" => FlatPriceCurrency.Dkk,
            "dop" => FlatPriceCurrency.Dop,
            "dzd" => FlatPriceCurrency.Dzd,
            "egp" => FlatPriceCurrency.Egp,
            "etb" => FlatPriceCurrency.Etb,
            "eur" => FlatPriceCurrency.Eur,
            "fjd" => FlatPriceCurrency.Fjd,
            "gbp" => FlatPriceCurrency.Gbp,
            "gel" => FlatPriceCurrency.Gel,
            "gip" => FlatPriceCurrency.Gip,
            "gmd" => FlatPriceCurrency.Gmd,
            "gyd" => FlatPriceCurrency.Gyd,
            "hkd" => FlatPriceCurrency.Hkd,
            "hrk" => FlatPriceCurrency.Hrk,
            "htg" => FlatPriceCurrency.Htg,
            "idr" => FlatPriceCurrency.Idr,
            "ils" => FlatPriceCurrency.Ils,
            "inr" => FlatPriceCurrency.Inr,
            "isk" => FlatPriceCurrency.Isk,
            "jmd" => FlatPriceCurrency.Jmd,
            "jpy" => FlatPriceCurrency.Jpy,
            "kes" => FlatPriceCurrency.Kes,
            "kgs" => FlatPriceCurrency.Kgs,
            "khr" => FlatPriceCurrency.Khr,
            "kmf" => FlatPriceCurrency.Kmf,
            "krw" => FlatPriceCurrency.Krw,
            "kyd" => FlatPriceCurrency.Kyd,
            "kzt" => FlatPriceCurrency.Kzt,
            "lbp" => FlatPriceCurrency.Lbp,
            "lkr" => FlatPriceCurrency.Lkr,
            "lrd" => FlatPriceCurrency.Lrd,
            "lsl" => FlatPriceCurrency.Lsl,
            "mad" => FlatPriceCurrency.Mad,
            "mdl" => FlatPriceCurrency.Mdl,
            "mga" => FlatPriceCurrency.Mga,
            "mkd" => FlatPriceCurrency.Mkd,
            "mmk" => FlatPriceCurrency.Mmk,
            "mnt" => FlatPriceCurrency.Mnt,
            "mop" => FlatPriceCurrency.Mop,
            "mro" => FlatPriceCurrency.Mro,
            "mvr" => FlatPriceCurrency.Mvr,
            "mwk" => FlatPriceCurrency.Mwk,
            "mxn" => FlatPriceCurrency.Mxn,
            "myr" => FlatPriceCurrency.Myr,
            "mzn" => FlatPriceCurrency.Mzn,
            "nad" => FlatPriceCurrency.Nad,
            "ngn" => FlatPriceCurrency.Ngn,
            "nok" => FlatPriceCurrency.Nok,
            "npr" => FlatPriceCurrency.Npr,
            "nzd" => FlatPriceCurrency.Nzd,
            "pgk" => FlatPriceCurrency.Pgk,
            "php" => FlatPriceCurrency.Php,
            "pkr" => FlatPriceCurrency.Pkr,
            "pln" => FlatPriceCurrency.Pln,
            "qar" => FlatPriceCurrency.Qar,
            "ron" => FlatPriceCurrency.Ron,
            "rsd" => FlatPriceCurrency.Rsd,
            "rub" => FlatPriceCurrency.Rub,
            "rwf" => FlatPriceCurrency.Rwf,
            "sar" => FlatPriceCurrency.Sar,
            "sbd" => FlatPriceCurrency.Sbd,
            "scr" => FlatPriceCurrency.Scr,
            "sek" => FlatPriceCurrency.Sek,
            "sgd" => FlatPriceCurrency.Sgd,
            "sle" => FlatPriceCurrency.Sle,
            "sll" => FlatPriceCurrency.Sll,
            "sos" => FlatPriceCurrency.Sos,
            "szl" => FlatPriceCurrency.Szl,
            "thb" => FlatPriceCurrency.Thb,
            "tjs" => FlatPriceCurrency.Tjs,
            "top" => FlatPriceCurrency.Top,
            "try" => FlatPriceCurrency.Try,
            "ttd" => FlatPriceCurrency.Ttd,
            "tzs" => FlatPriceCurrency.Tzs,
            "uah" => FlatPriceCurrency.Uah,
            "uzs" => FlatPriceCurrency.Uzs,
            "vnd" => FlatPriceCurrency.Vnd,
            "vuv" => FlatPriceCurrency.Vuv,
            "wst" => FlatPriceCurrency.Wst,
            "xaf" => FlatPriceCurrency.Xaf,
            "xcd" => FlatPriceCurrency.Xcd,
            "yer" => FlatPriceCurrency.Yer,
            "zar" => FlatPriceCurrency.Zar,
            "zmw" => FlatPriceCurrency.Zmw,
            "clp" => FlatPriceCurrency.Clp,
            "djf" => FlatPriceCurrency.Djf,
            "gnf" => FlatPriceCurrency.Gnf,
            "ugx" => FlatPriceCurrency.Ugx,
            "pyg" => FlatPriceCurrency.Pyg,
            "xof" => FlatPriceCurrency.Xof,
            "xpf" => FlatPriceCurrency.Xpf,
            _ => (FlatPriceCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FlatPriceCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FlatPriceCurrency.Usd => "usd",
                FlatPriceCurrency.Aed => "aed",
                FlatPriceCurrency.All => "all",
                FlatPriceCurrency.Amd => "amd",
                FlatPriceCurrency.Ang => "ang",
                FlatPriceCurrency.Aud => "aud",
                FlatPriceCurrency.Awg => "awg",
                FlatPriceCurrency.Azn => "azn",
                FlatPriceCurrency.Bam => "bam",
                FlatPriceCurrency.Bbd => "bbd",
                FlatPriceCurrency.Bdt => "bdt",
                FlatPriceCurrency.Bgn => "bgn",
                FlatPriceCurrency.Bif => "bif",
                FlatPriceCurrency.Bmd => "bmd",
                FlatPriceCurrency.Bnd => "bnd",
                FlatPriceCurrency.Bsd => "bsd",
                FlatPriceCurrency.Bwp => "bwp",
                FlatPriceCurrency.Byn => "byn",
                FlatPriceCurrency.Bzd => "bzd",
                FlatPriceCurrency.Brl => "brl",
                FlatPriceCurrency.Cad => "cad",
                FlatPriceCurrency.Cdf => "cdf",
                FlatPriceCurrency.Chf => "chf",
                FlatPriceCurrency.Cny => "cny",
                FlatPriceCurrency.Czk => "czk",
                FlatPriceCurrency.Dkk => "dkk",
                FlatPriceCurrency.Dop => "dop",
                FlatPriceCurrency.Dzd => "dzd",
                FlatPriceCurrency.Egp => "egp",
                FlatPriceCurrency.Etb => "etb",
                FlatPriceCurrency.Eur => "eur",
                FlatPriceCurrency.Fjd => "fjd",
                FlatPriceCurrency.Gbp => "gbp",
                FlatPriceCurrency.Gel => "gel",
                FlatPriceCurrency.Gip => "gip",
                FlatPriceCurrency.Gmd => "gmd",
                FlatPriceCurrency.Gyd => "gyd",
                FlatPriceCurrency.Hkd => "hkd",
                FlatPriceCurrency.Hrk => "hrk",
                FlatPriceCurrency.Htg => "htg",
                FlatPriceCurrency.Idr => "idr",
                FlatPriceCurrency.Ils => "ils",
                FlatPriceCurrency.Inr => "inr",
                FlatPriceCurrency.Isk => "isk",
                FlatPriceCurrency.Jmd => "jmd",
                FlatPriceCurrency.Jpy => "jpy",
                FlatPriceCurrency.Kes => "kes",
                FlatPriceCurrency.Kgs => "kgs",
                FlatPriceCurrency.Khr => "khr",
                FlatPriceCurrency.Kmf => "kmf",
                FlatPriceCurrency.Krw => "krw",
                FlatPriceCurrency.Kyd => "kyd",
                FlatPriceCurrency.Kzt => "kzt",
                FlatPriceCurrency.Lbp => "lbp",
                FlatPriceCurrency.Lkr => "lkr",
                FlatPriceCurrency.Lrd => "lrd",
                FlatPriceCurrency.Lsl => "lsl",
                FlatPriceCurrency.Mad => "mad",
                FlatPriceCurrency.Mdl => "mdl",
                FlatPriceCurrency.Mga => "mga",
                FlatPriceCurrency.Mkd => "mkd",
                FlatPriceCurrency.Mmk => "mmk",
                FlatPriceCurrency.Mnt => "mnt",
                FlatPriceCurrency.Mop => "mop",
                FlatPriceCurrency.Mro => "mro",
                FlatPriceCurrency.Mvr => "mvr",
                FlatPriceCurrency.Mwk => "mwk",
                FlatPriceCurrency.Mxn => "mxn",
                FlatPriceCurrency.Myr => "myr",
                FlatPriceCurrency.Mzn => "mzn",
                FlatPriceCurrency.Nad => "nad",
                FlatPriceCurrency.Ngn => "ngn",
                FlatPriceCurrency.Nok => "nok",
                FlatPriceCurrency.Npr => "npr",
                FlatPriceCurrency.Nzd => "nzd",
                FlatPriceCurrency.Pgk => "pgk",
                FlatPriceCurrency.Php => "php",
                FlatPriceCurrency.Pkr => "pkr",
                FlatPriceCurrency.Pln => "pln",
                FlatPriceCurrency.Qar => "qar",
                FlatPriceCurrency.Ron => "ron",
                FlatPriceCurrency.Rsd => "rsd",
                FlatPriceCurrency.Rub => "rub",
                FlatPriceCurrency.Rwf => "rwf",
                FlatPriceCurrency.Sar => "sar",
                FlatPriceCurrency.Sbd => "sbd",
                FlatPriceCurrency.Scr => "scr",
                FlatPriceCurrency.Sek => "sek",
                FlatPriceCurrency.Sgd => "sgd",
                FlatPriceCurrency.Sle => "sle",
                FlatPriceCurrency.Sll => "sll",
                FlatPriceCurrency.Sos => "sos",
                FlatPriceCurrency.Szl => "szl",
                FlatPriceCurrency.Thb => "thb",
                FlatPriceCurrency.Tjs => "tjs",
                FlatPriceCurrency.Top => "top",
                FlatPriceCurrency.Try => "try",
                FlatPriceCurrency.Ttd => "ttd",
                FlatPriceCurrency.Tzs => "tzs",
                FlatPriceCurrency.Uah => "uah",
                FlatPriceCurrency.Uzs => "uzs",
                FlatPriceCurrency.Vnd => "vnd",
                FlatPriceCurrency.Vuv => "vuv",
                FlatPriceCurrency.Wst => "wst",
                FlatPriceCurrency.Xaf => "xaf",
                FlatPriceCurrency.Xcd => "xcd",
                FlatPriceCurrency.Yer => "yer",
                FlatPriceCurrency.Zar => "zar",
                FlatPriceCurrency.Zmw => "zmw",
                FlatPriceCurrency.Clp => "clp",
                FlatPriceCurrency.Djf => "djf",
                FlatPriceCurrency.Gnf => "gnf",
                FlatPriceCurrency.Ugx => "ugx",
                FlatPriceCurrency.Pyg => "pyg",
                FlatPriceCurrency.Xof => "xof",
                FlatPriceCurrency.Xpf => "xpf",
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
[JsonConverter(typeof(JsonModelConverter<UnitPrice, UnitPriceFromRaw>))]
public sealed record class UnitPrice : JsonModel
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
    /// The billing country code of the price
    /// </summary>
    public string? BillingCountryCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billingCountryCode");
        }
        init { this._rawData.Set("billingCountryCode", value); }
    }

    /// <summary>
    /// The price currency
    /// </summary>
    public ApiEnum<string, UnitPriceCurrency>? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, UnitPriceCurrency>>("currency");
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
        _ = this.BillingCountryCode;
        this.Currency?.Validate();
    }

    public UnitPrice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UnitPrice(UnitPrice unitPrice)
        : base(unitPrice) { }
#pragma warning restore CS8618

    public UnitPrice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnitPrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UnitPriceFromRaw.FromRawUnchecked"/>
    public static UnitPrice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UnitPriceFromRaw : IFromRawJson<UnitPrice>
{
    /// <inheritdoc/>
    public UnitPrice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UnitPrice.FromRawUnchecked(rawData);
}

/// <summary>
/// The price currency
/// </summary>
[JsonConverter(typeof(UnitPriceCurrencyConverter))]
public enum UnitPriceCurrency
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

sealed class UnitPriceCurrencyConverter : JsonConverter<UnitPriceCurrency>
{
    public override UnitPriceCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => UnitPriceCurrency.Usd,
            "aed" => UnitPriceCurrency.Aed,
            "all" => UnitPriceCurrency.All,
            "amd" => UnitPriceCurrency.Amd,
            "ang" => UnitPriceCurrency.Ang,
            "aud" => UnitPriceCurrency.Aud,
            "awg" => UnitPriceCurrency.Awg,
            "azn" => UnitPriceCurrency.Azn,
            "bam" => UnitPriceCurrency.Bam,
            "bbd" => UnitPriceCurrency.Bbd,
            "bdt" => UnitPriceCurrency.Bdt,
            "bgn" => UnitPriceCurrency.Bgn,
            "bif" => UnitPriceCurrency.Bif,
            "bmd" => UnitPriceCurrency.Bmd,
            "bnd" => UnitPriceCurrency.Bnd,
            "bsd" => UnitPriceCurrency.Bsd,
            "bwp" => UnitPriceCurrency.Bwp,
            "byn" => UnitPriceCurrency.Byn,
            "bzd" => UnitPriceCurrency.Bzd,
            "brl" => UnitPriceCurrency.Brl,
            "cad" => UnitPriceCurrency.Cad,
            "cdf" => UnitPriceCurrency.Cdf,
            "chf" => UnitPriceCurrency.Chf,
            "cny" => UnitPriceCurrency.Cny,
            "czk" => UnitPriceCurrency.Czk,
            "dkk" => UnitPriceCurrency.Dkk,
            "dop" => UnitPriceCurrency.Dop,
            "dzd" => UnitPriceCurrency.Dzd,
            "egp" => UnitPriceCurrency.Egp,
            "etb" => UnitPriceCurrency.Etb,
            "eur" => UnitPriceCurrency.Eur,
            "fjd" => UnitPriceCurrency.Fjd,
            "gbp" => UnitPriceCurrency.Gbp,
            "gel" => UnitPriceCurrency.Gel,
            "gip" => UnitPriceCurrency.Gip,
            "gmd" => UnitPriceCurrency.Gmd,
            "gyd" => UnitPriceCurrency.Gyd,
            "hkd" => UnitPriceCurrency.Hkd,
            "hrk" => UnitPriceCurrency.Hrk,
            "htg" => UnitPriceCurrency.Htg,
            "idr" => UnitPriceCurrency.Idr,
            "ils" => UnitPriceCurrency.Ils,
            "inr" => UnitPriceCurrency.Inr,
            "isk" => UnitPriceCurrency.Isk,
            "jmd" => UnitPriceCurrency.Jmd,
            "jpy" => UnitPriceCurrency.Jpy,
            "kes" => UnitPriceCurrency.Kes,
            "kgs" => UnitPriceCurrency.Kgs,
            "khr" => UnitPriceCurrency.Khr,
            "kmf" => UnitPriceCurrency.Kmf,
            "krw" => UnitPriceCurrency.Krw,
            "kyd" => UnitPriceCurrency.Kyd,
            "kzt" => UnitPriceCurrency.Kzt,
            "lbp" => UnitPriceCurrency.Lbp,
            "lkr" => UnitPriceCurrency.Lkr,
            "lrd" => UnitPriceCurrency.Lrd,
            "lsl" => UnitPriceCurrency.Lsl,
            "mad" => UnitPriceCurrency.Mad,
            "mdl" => UnitPriceCurrency.Mdl,
            "mga" => UnitPriceCurrency.Mga,
            "mkd" => UnitPriceCurrency.Mkd,
            "mmk" => UnitPriceCurrency.Mmk,
            "mnt" => UnitPriceCurrency.Mnt,
            "mop" => UnitPriceCurrency.Mop,
            "mro" => UnitPriceCurrency.Mro,
            "mvr" => UnitPriceCurrency.Mvr,
            "mwk" => UnitPriceCurrency.Mwk,
            "mxn" => UnitPriceCurrency.Mxn,
            "myr" => UnitPriceCurrency.Myr,
            "mzn" => UnitPriceCurrency.Mzn,
            "nad" => UnitPriceCurrency.Nad,
            "ngn" => UnitPriceCurrency.Ngn,
            "nok" => UnitPriceCurrency.Nok,
            "npr" => UnitPriceCurrency.Npr,
            "nzd" => UnitPriceCurrency.Nzd,
            "pgk" => UnitPriceCurrency.Pgk,
            "php" => UnitPriceCurrency.Php,
            "pkr" => UnitPriceCurrency.Pkr,
            "pln" => UnitPriceCurrency.Pln,
            "qar" => UnitPriceCurrency.Qar,
            "ron" => UnitPriceCurrency.Ron,
            "rsd" => UnitPriceCurrency.Rsd,
            "rub" => UnitPriceCurrency.Rub,
            "rwf" => UnitPriceCurrency.Rwf,
            "sar" => UnitPriceCurrency.Sar,
            "sbd" => UnitPriceCurrency.Sbd,
            "scr" => UnitPriceCurrency.Scr,
            "sek" => UnitPriceCurrency.Sek,
            "sgd" => UnitPriceCurrency.Sgd,
            "sle" => UnitPriceCurrency.Sle,
            "sll" => UnitPriceCurrency.Sll,
            "sos" => UnitPriceCurrency.Sos,
            "szl" => UnitPriceCurrency.Szl,
            "thb" => UnitPriceCurrency.Thb,
            "tjs" => UnitPriceCurrency.Tjs,
            "top" => UnitPriceCurrency.Top,
            "try" => UnitPriceCurrency.Try,
            "ttd" => UnitPriceCurrency.Ttd,
            "tzs" => UnitPriceCurrency.Tzs,
            "uah" => UnitPriceCurrency.Uah,
            "uzs" => UnitPriceCurrency.Uzs,
            "vnd" => UnitPriceCurrency.Vnd,
            "vuv" => UnitPriceCurrency.Vuv,
            "wst" => UnitPriceCurrency.Wst,
            "xaf" => UnitPriceCurrency.Xaf,
            "xcd" => UnitPriceCurrency.Xcd,
            "yer" => UnitPriceCurrency.Yer,
            "zar" => UnitPriceCurrency.Zar,
            "zmw" => UnitPriceCurrency.Zmw,
            "clp" => UnitPriceCurrency.Clp,
            "djf" => UnitPriceCurrency.Djf,
            "gnf" => UnitPriceCurrency.Gnf,
            "ugx" => UnitPriceCurrency.Ugx,
            "pyg" => UnitPriceCurrency.Pyg,
            "xof" => UnitPriceCurrency.Xof,
            "xpf" => UnitPriceCurrency.Xpf,
            _ => (UnitPriceCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnitPriceCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UnitPriceCurrency.Usd => "usd",
                UnitPriceCurrency.Aed => "aed",
                UnitPriceCurrency.All => "all",
                UnitPriceCurrency.Amd => "amd",
                UnitPriceCurrency.Ang => "ang",
                UnitPriceCurrency.Aud => "aud",
                UnitPriceCurrency.Awg => "awg",
                UnitPriceCurrency.Azn => "azn",
                UnitPriceCurrency.Bam => "bam",
                UnitPriceCurrency.Bbd => "bbd",
                UnitPriceCurrency.Bdt => "bdt",
                UnitPriceCurrency.Bgn => "bgn",
                UnitPriceCurrency.Bif => "bif",
                UnitPriceCurrency.Bmd => "bmd",
                UnitPriceCurrency.Bnd => "bnd",
                UnitPriceCurrency.Bsd => "bsd",
                UnitPriceCurrency.Bwp => "bwp",
                UnitPriceCurrency.Byn => "byn",
                UnitPriceCurrency.Bzd => "bzd",
                UnitPriceCurrency.Brl => "brl",
                UnitPriceCurrency.Cad => "cad",
                UnitPriceCurrency.Cdf => "cdf",
                UnitPriceCurrency.Chf => "chf",
                UnitPriceCurrency.Cny => "cny",
                UnitPriceCurrency.Czk => "czk",
                UnitPriceCurrency.Dkk => "dkk",
                UnitPriceCurrency.Dop => "dop",
                UnitPriceCurrency.Dzd => "dzd",
                UnitPriceCurrency.Egp => "egp",
                UnitPriceCurrency.Etb => "etb",
                UnitPriceCurrency.Eur => "eur",
                UnitPriceCurrency.Fjd => "fjd",
                UnitPriceCurrency.Gbp => "gbp",
                UnitPriceCurrency.Gel => "gel",
                UnitPriceCurrency.Gip => "gip",
                UnitPriceCurrency.Gmd => "gmd",
                UnitPriceCurrency.Gyd => "gyd",
                UnitPriceCurrency.Hkd => "hkd",
                UnitPriceCurrency.Hrk => "hrk",
                UnitPriceCurrency.Htg => "htg",
                UnitPriceCurrency.Idr => "idr",
                UnitPriceCurrency.Ils => "ils",
                UnitPriceCurrency.Inr => "inr",
                UnitPriceCurrency.Isk => "isk",
                UnitPriceCurrency.Jmd => "jmd",
                UnitPriceCurrency.Jpy => "jpy",
                UnitPriceCurrency.Kes => "kes",
                UnitPriceCurrency.Kgs => "kgs",
                UnitPriceCurrency.Khr => "khr",
                UnitPriceCurrency.Kmf => "kmf",
                UnitPriceCurrency.Krw => "krw",
                UnitPriceCurrency.Kyd => "kyd",
                UnitPriceCurrency.Kzt => "kzt",
                UnitPriceCurrency.Lbp => "lbp",
                UnitPriceCurrency.Lkr => "lkr",
                UnitPriceCurrency.Lrd => "lrd",
                UnitPriceCurrency.Lsl => "lsl",
                UnitPriceCurrency.Mad => "mad",
                UnitPriceCurrency.Mdl => "mdl",
                UnitPriceCurrency.Mga => "mga",
                UnitPriceCurrency.Mkd => "mkd",
                UnitPriceCurrency.Mmk => "mmk",
                UnitPriceCurrency.Mnt => "mnt",
                UnitPriceCurrency.Mop => "mop",
                UnitPriceCurrency.Mro => "mro",
                UnitPriceCurrency.Mvr => "mvr",
                UnitPriceCurrency.Mwk => "mwk",
                UnitPriceCurrency.Mxn => "mxn",
                UnitPriceCurrency.Myr => "myr",
                UnitPriceCurrency.Mzn => "mzn",
                UnitPriceCurrency.Nad => "nad",
                UnitPriceCurrency.Ngn => "ngn",
                UnitPriceCurrency.Nok => "nok",
                UnitPriceCurrency.Npr => "npr",
                UnitPriceCurrency.Nzd => "nzd",
                UnitPriceCurrency.Pgk => "pgk",
                UnitPriceCurrency.Php => "php",
                UnitPriceCurrency.Pkr => "pkr",
                UnitPriceCurrency.Pln => "pln",
                UnitPriceCurrency.Qar => "qar",
                UnitPriceCurrency.Ron => "ron",
                UnitPriceCurrency.Rsd => "rsd",
                UnitPriceCurrency.Rub => "rub",
                UnitPriceCurrency.Rwf => "rwf",
                UnitPriceCurrency.Sar => "sar",
                UnitPriceCurrency.Sbd => "sbd",
                UnitPriceCurrency.Scr => "scr",
                UnitPriceCurrency.Sek => "sek",
                UnitPriceCurrency.Sgd => "sgd",
                UnitPriceCurrency.Sle => "sle",
                UnitPriceCurrency.Sll => "sll",
                UnitPriceCurrency.Sos => "sos",
                UnitPriceCurrency.Szl => "szl",
                UnitPriceCurrency.Thb => "thb",
                UnitPriceCurrency.Tjs => "tjs",
                UnitPriceCurrency.Top => "top",
                UnitPriceCurrency.Try => "try",
                UnitPriceCurrency.Ttd => "ttd",
                UnitPriceCurrency.Tzs => "tzs",
                UnitPriceCurrency.Uah => "uah",
                UnitPriceCurrency.Uzs => "uzs",
                UnitPriceCurrency.Vnd => "vnd",
                UnitPriceCurrency.Vuv => "vuv",
                UnitPriceCurrency.Wst => "wst",
                UnitPriceCurrency.Xaf => "xaf",
                UnitPriceCurrency.Xcd => "xcd",
                UnitPriceCurrency.Yer => "yer",
                UnitPriceCurrency.Zar => "zar",
                UnitPriceCurrency.Zmw => "zmw",
                UnitPriceCurrency.Clp => "clp",
                UnitPriceCurrency.Djf => "djf",
                UnitPriceCurrency.Gnf => "gnf",
                UnitPriceCurrency.Ugx => "ugx",
                UnitPriceCurrency.Pyg => "pyg",
                UnitPriceCurrency.Xof => "xof",
                UnitPriceCurrency.Xpf => "xpf",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Strategy for scheduling subscription changes
/// </summary>
[JsonConverter(typeof(SubscriptionProvisionParamsScheduleStrategyConverter))]
public enum SubscriptionProvisionParamsScheduleStrategy
{
    EndOfBillingPeriod,
    EndOfBillingMonth,
    Immediate,
}

sealed class SubscriptionProvisionParamsScheduleStrategyConverter
    : JsonConverter<SubscriptionProvisionParamsScheduleStrategy>
{
    public override SubscriptionProvisionParamsScheduleStrategy Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "END_OF_BILLING_PERIOD" =>
                SubscriptionProvisionParamsScheduleStrategy.EndOfBillingPeriod,
            "END_OF_BILLING_MONTH" => SubscriptionProvisionParamsScheduleStrategy.EndOfBillingMonth,
            "IMMEDIATE" => SubscriptionProvisionParamsScheduleStrategy.Immediate,
            _ => (SubscriptionProvisionParamsScheduleStrategy)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionProvisionParamsScheduleStrategy value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionProvisionParamsScheduleStrategy.EndOfBillingPeriod =>
                    "END_OF_BILLING_PERIOD",
                SubscriptionProvisionParamsScheduleStrategy.EndOfBillingMonth =>
                    "END_OF_BILLING_MONTH",
                SubscriptionProvisionParamsScheduleStrategy.Immediate => "IMMEDIATE",
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
        SubscriptionProvisionParamsSubscriptionEntitlement,
        SubscriptionProvisionParamsSubscriptionEntitlementFromRaw
    >)
)]
public sealed record class SubscriptionProvisionParamsSubscriptionEntitlement : JsonModel
{
    /// <summary>
    /// Feature ID
    /// </summary>
    public required string FeatureID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("featureId");
        }
        init { this._rawData.Set("featureId", value); }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FeatureID;
        _ = this.UsageLimit;
        _ = this.IsGranted;
    }

    public SubscriptionProvisionParamsSubscriptionEntitlement() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionProvisionParamsSubscriptionEntitlement(
        SubscriptionProvisionParamsSubscriptionEntitlement subscriptionProvisionParamsSubscriptionEntitlement
    )
        : base(subscriptionProvisionParamsSubscriptionEntitlement) { }
#pragma warning restore CS8618

    public SubscriptionProvisionParamsSubscriptionEntitlement(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionProvisionParamsSubscriptionEntitlement(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionProvisionParamsSubscriptionEntitlementFromRaw.FromRawUnchecked"/>
    public static SubscriptionProvisionParamsSubscriptionEntitlement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionProvisionParamsSubscriptionEntitlementFromRaw
    : IFromRawJson<SubscriptionProvisionParamsSubscriptionEntitlement>
{
    /// <inheritdoc/>
    public SubscriptionProvisionParamsSubscriptionEntitlement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionProvisionParamsSubscriptionEntitlement.FromRawUnchecked(rawData);
}

/// <summary>
/// Trial period override settings
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionProvisionParamsTrialOverrideConfiguration,
        SubscriptionProvisionParamsTrialOverrideConfigurationFromRaw
    >)
)]
public sealed record class SubscriptionProvisionParamsTrialOverrideConfiguration : JsonModel
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
    public ApiEnum<
        string,
        SubscriptionProvisionParamsTrialOverrideConfigurationTrialEndBehavior
    >? TrialEndBehavior
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<
                    string,
                    SubscriptionProvisionParamsTrialOverrideConfigurationTrialEndBehavior
                >
            >("trialEndBehavior");
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

    public SubscriptionProvisionParamsTrialOverrideConfiguration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionProvisionParamsTrialOverrideConfiguration(
        SubscriptionProvisionParamsTrialOverrideConfiguration subscriptionProvisionParamsTrialOverrideConfiguration
    )
        : base(subscriptionProvisionParamsTrialOverrideConfiguration) { }
#pragma warning restore CS8618

    public SubscriptionProvisionParamsTrialOverrideConfiguration(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionProvisionParamsTrialOverrideConfiguration(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionProvisionParamsTrialOverrideConfigurationFromRaw.FromRawUnchecked"/>
    public static SubscriptionProvisionParamsTrialOverrideConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SubscriptionProvisionParamsTrialOverrideConfiguration(bool isTrial)
        : this()
    {
        this.IsTrial = isTrial;
    }
}

class SubscriptionProvisionParamsTrialOverrideConfigurationFromRaw
    : IFromRawJson<SubscriptionProvisionParamsTrialOverrideConfiguration>
{
    /// <inheritdoc/>
    public SubscriptionProvisionParamsTrialOverrideConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionProvisionParamsTrialOverrideConfiguration.FromRawUnchecked(rawData);
}

/// <summary>
/// Behavior when trial ends: CONVERT_TO_PAID or CANCEL_SUBSCRIPTION
/// </summary>
[JsonConverter(
    typeof(SubscriptionProvisionParamsTrialOverrideConfigurationTrialEndBehaviorConverter)
)]
public enum SubscriptionProvisionParamsTrialOverrideConfigurationTrialEndBehavior
{
    ConvertToPaid,
    CancelSubscription,
}

sealed class SubscriptionProvisionParamsTrialOverrideConfigurationTrialEndBehaviorConverter
    : JsonConverter<SubscriptionProvisionParamsTrialOverrideConfigurationTrialEndBehavior>
{
    public override SubscriptionProvisionParamsTrialOverrideConfigurationTrialEndBehavior Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "CONVERT_TO_PAID" =>
                SubscriptionProvisionParamsTrialOverrideConfigurationTrialEndBehavior.ConvertToPaid,
            "CANCEL_SUBSCRIPTION" =>
                SubscriptionProvisionParamsTrialOverrideConfigurationTrialEndBehavior.CancelSubscription,
            _ => (SubscriptionProvisionParamsTrialOverrideConfigurationTrialEndBehavior)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionProvisionParamsTrialOverrideConfigurationTrialEndBehavior value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionProvisionParamsTrialOverrideConfigurationTrialEndBehavior.ConvertToPaid =>
                    "CONVERT_TO_PAID",
                SubscriptionProvisionParamsTrialOverrideConfigurationTrialEndBehavior.CancelSubscription =>
                    "CANCEL_SUBSCRIPTION",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
