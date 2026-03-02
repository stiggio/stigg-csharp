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
/// Previews the pricing impact of creating or updating a subscription without making
/// changes. Returns estimated costs, taxes, and proration details.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class SubscriptionPreviewParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Customer ID
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
    /// Plan ID
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
    /// Addons to include
    /// </summary>
    public IReadOnlyList<SubscriptionPreviewParamsAddon>? Addons
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<
                ImmutableArray<SubscriptionPreviewParamsAddon>
            >("addons");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<SubscriptionPreviewParamsAddon>?>(
                "addons",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Coupon or discount to apply
    /// </summary>
    public SubscriptionPreviewParamsAppliedCoupon? AppliedCoupon
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<SubscriptionPreviewParamsAppliedCoupon>(
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
    /// Billable features with quantities
    /// </summary>
    public IReadOnlyList<BillableFeature>? BillableFeatures
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<BillableFeature>>(
                "billableFeatures"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<BillableFeature>?>(
                "billableFeatures",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// ISO 3166-1 country code for localization
    /// </summary>
    public string? BillingCountryCode
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("billingCountryCode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("billingCountryCode", value);
        }
    }

    /// <summary>
    /// Billing and tax configuration
    /// </summary>
    public SubscriptionPreviewParamsBillingInformation? BillingInformation
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<SubscriptionPreviewParamsBillingInformation>(
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
    public ApiEnum<string, SubscriptionPreviewParamsBillingPeriod>? BillingPeriod
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<
                ApiEnum<string, SubscriptionPreviewParamsBillingPeriod>
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

    /// <summary>
    /// One-time or recurring charges
    /// </summary>
    public IReadOnlyList<SubscriptionPreviewParamsCharge>? Charges
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<
                ImmutableArray<SubscriptionPreviewParamsCharge>
            >("charges");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<SubscriptionPreviewParamsCharge>?>(
                "charges",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Paying customer ID for delegated billing
    /// </summary>
    public string? PayingCustomerID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("payingCustomerId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("payingCustomerId", value);
        }
    }

    /// <summary>
    /// Resource ID for multi-instance subscriptions
    /// </summary>
    public string? ResourceID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("resourceId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("resourceId", value);
        }
    }

    /// <summary>
    /// When to apply subscription changes
    /// </summary>
    public ApiEnum<string, SubscriptionPreviewParamsScheduleStrategy>? ScheduleStrategy
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<
                ApiEnum<string, SubscriptionPreviewParamsScheduleStrategy>
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

    /// <summary>
    /// Trial period override settings
    /// </summary>
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

    /// <summary>
    /// Unit quantity for per-unit pricing
    /// </summary>
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

    public SubscriptionPreviewParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionPreviewParams(SubscriptionPreviewParams subscriptionPreviewParams)
        : base(subscriptionPreviewParams)
    {
        this._rawBodyData = new(subscriptionPreviewParams._rawBodyData);
    }
#pragma warning restore CS8618

    public SubscriptionPreviewParams(
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
    SubscriptionPreviewParams(
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
    public static SubscriptionPreviewParams FromRawUnchecked(
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

    public virtual bool Equals(SubscriptionPreviewParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/api/v1/subscriptions/preview"
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
        SubscriptionPreviewParamsAddon,
        SubscriptionPreviewParamsAddonFromRaw
    >)
)]
public sealed record class SubscriptionPreviewParamsAddon : JsonModel
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

    public SubscriptionPreviewParamsAddon() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionPreviewParamsAddon(
        SubscriptionPreviewParamsAddon subscriptionPreviewParamsAddon
    )
        : base(subscriptionPreviewParamsAddon) { }
#pragma warning restore CS8618

    public SubscriptionPreviewParamsAddon(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionPreviewParamsAddon(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionPreviewParamsAddonFromRaw.FromRawUnchecked"/>
    public static SubscriptionPreviewParamsAddon FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionPreviewParamsAddonFromRaw : IFromRawJson<SubscriptionPreviewParamsAddon>
{
    /// <inheritdoc/>
    public SubscriptionPreviewParamsAddon FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionPreviewParamsAddon.FromRawUnchecked(rawData);
}

/// <summary>
/// Coupon or discount to apply
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionPreviewParamsAppliedCoupon,
        SubscriptionPreviewParamsAppliedCouponFromRaw
    >)
)]
public sealed record class SubscriptionPreviewParamsAppliedCoupon : JsonModel
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
    public SubscriptionPreviewParamsAppliedCouponConfiguration? Configuration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SubscriptionPreviewParamsAppliedCouponConfiguration>(
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
    public SubscriptionPreviewParamsAppliedCouponDiscount? Discount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SubscriptionPreviewParamsAppliedCouponDiscount>(
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

    public SubscriptionPreviewParamsAppliedCoupon() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionPreviewParamsAppliedCoupon(
        SubscriptionPreviewParamsAppliedCoupon subscriptionPreviewParamsAppliedCoupon
    )
        : base(subscriptionPreviewParamsAppliedCoupon) { }
#pragma warning restore CS8618

    public SubscriptionPreviewParamsAppliedCoupon(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionPreviewParamsAppliedCoupon(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionPreviewParamsAppliedCouponFromRaw.FromRawUnchecked"/>
    public static SubscriptionPreviewParamsAppliedCoupon FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionPreviewParamsAppliedCouponFromRaw
    : IFromRawJson<SubscriptionPreviewParamsAppliedCoupon>
{
    /// <inheritdoc/>
    public SubscriptionPreviewParamsAppliedCoupon FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionPreviewParamsAppliedCoupon.FromRawUnchecked(rawData);
}

/// <summary>
/// Coupon timing configuration
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionPreviewParamsAppliedCouponConfiguration,
        SubscriptionPreviewParamsAppliedCouponConfigurationFromRaw
    >)
)]
public sealed record class SubscriptionPreviewParamsAppliedCouponConfiguration : JsonModel
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

    public SubscriptionPreviewParamsAppliedCouponConfiguration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionPreviewParamsAppliedCouponConfiguration(
        SubscriptionPreviewParamsAppliedCouponConfiguration subscriptionPreviewParamsAppliedCouponConfiguration
    )
        : base(subscriptionPreviewParamsAppliedCouponConfiguration) { }
#pragma warning restore CS8618

    public SubscriptionPreviewParamsAppliedCouponConfiguration(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionPreviewParamsAppliedCouponConfiguration(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionPreviewParamsAppliedCouponConfigurationFromRaw.FromRawUnchecked"/>
    public static SubscriptionPreviewParamsAppliedCouponConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionPreviewParamsAppliedCouponConfigurationFromRaw
    : IFromRawJson<SubscriptionPreviewParamsAppliedCouponConfiguration>
{
    /// <inheritdoc/>
    public SubscriptionPreviewParamsAppliedCouponConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionPreviewParamsAppliedCouponConfiguration.FromRawUnchecked(rawData);
}

/// <summary>
/// Ad-hoc discount configuration
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionPreviewParamsAppliedCouponDiscount,
        SubscriptionPreviewParamsAppliedCouponDiscountFromRaw
    >)
)]
public sealed record class SubscriptionPreviewParamsAppliedCouponDiscount : JsonModel
{
    /// <summary>
    /// Fixed amounts off by currency
    /// </summary>
    public IReadOnlyList<SubscriptionPreviewParamsAppliedCouponDiscountAmountsOff>? AmountsOff
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<SubscriptionPreviewParamsAppliedCouponDiscountAmountsOff>
            >("amountsOff");
        }
        init
        {
            this._rawData.Set<ImmutableArray<SubscriptionPreviewParamsAppliedCouponDiscountAmountsOff>?>(
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

    public SubscriptionPreviewParamsAppliedCouponDiscount() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionPreviewParamsAppliedCouponDiscount(
        SubscriptionPreviewParamsAppliedCouponDiscount subscriptionPreviewParamsAppliedCouponDiscount
    )
        : base(subscriptionPreviewParamsAppliedCouponDiscount) { }
#pragma warning restore CS8618

    public SubscriptionPreviewParamsAppliedCouponDiscount(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionPreviewParamsAppliedCouponDiscount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionPreviewParamsAppliedCouponDiscountFromRaw.FromRawUnchecked"/>
    public static SubscriptionPreviewParamsAppliedCouponDiscount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionPreviewParamsAppliedCouponDiscountFromRaw
    : IFromRawJson<SubscriptionPreviewParamsAppliedCouponDiscount>
{
    /// <inheritdoc/>
    public SubscriptionPreviewParamsAppliedCouponDiscount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionPreviewParamsAppliedCouponDiscount.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionPreviewParamsAppliedCouponDiscountAmountsOff,
        SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffFromRaw
    >)
)]
public sealed record class SubscriptionPreviewParamsAppliedCouponDiscountAmountsOff : JsonModel
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
        SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency
    > Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency>
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

    public SubscriptionPreviewParamsAppliedCouponDiscountAmountsOff() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionPreviewParamsAppliedCouponDiscountAmountsOff(
        SubscriptionPreviewParamsAppliedCouponDiscountAmountsOff subscriptionPreviewParamsAppliedCouponDiscountAmountsOff
    )
        : base(subscriptionPreviewParamsAppliedCouponDiscountAmountsOff) { }
#pragma warning restore CS8618

    public SubscriptionPreviewParamsAppliedCouponDiscountAmountsOff(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionPreviewParamsAppliedCouponDiscountAmountsOff(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffFromRaw.FromRawUnchecked"/>
    public static SubscriptionPreviewParamsAppliedCouponDiscountAmountsOff FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffFromRaw
    : IFromRawJson<SubscriptionPreviewParamsAppliedCouponDiscountAmountsOff>
{
    /// <inheritdoc/>
    public SubscriptionPreviewParamsAppliedCouponDiscountAmountsOff FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOff.FromRawUnchecked(rawData);
}

/// <summary>
/// The price currency
/// </summary>
[JsonConverter(typeof(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrencyConverter))]
public enum SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency
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

sealed class SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrencyConverter
    : JsonConverter<SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency>
{
    public override SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Usd,
            "aed" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Aed,
            "all" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.All,
            "amd" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Amd,
            "ang" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Ang,
            "aud" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Aud,
            "awg" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Awg,
            "azn" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Azn,
            "bam" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Bam,
            "bbd" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Bbd,
            "bdt" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Bdt,
            "bgn" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Bgn,
            "bif" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Bif,
            "bmd" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Bmd,
            "bnd" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Bnd,
            "bsd" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Bsd,
            "bwp" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Bwp,
            "byn" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Byn,
            "bzd" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Bzd,
            "brl" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Brl,
            "cad" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Cad,
            "cdf" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Cdf,
            "chf" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Chf,
            "cny" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Cny,
            "czk" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Czk,
            "dkk" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Dkk,
            "dop" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Dop,
            "dzd" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Dzd,
            "egp" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Egp,
            "etb" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Etb,
            "eur" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Eur,
            "fjd" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Fjd,
            "gbp" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Gbp,
            "gel" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Gel,
            "gip" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Gip,
            "gmd" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Gmd,
            "gyd" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Gyd,
            "hkd" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Hkd,
            "hrk" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Hrk,
            "htg" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Htg,
            "idr" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Idr,
            "ils" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Ils,
            "inr" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Inr,
            "isk" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Isk,
            "jmd" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Jmd,
            "jpy" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Jpy,
            "kes" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Kes,
            "kgs" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Kgs,
            "khr" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Khr,
            "kmf" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Kmf,
            "krw" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Krw,
            "kyd" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Kyd,
            "kzt" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Kzt,
            "lbp" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Lbp,
            "lkr" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Lkr,
            "lrd" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Lrd,
            "lsl" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Lsl,
            "mad" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Mad,
            "mdl" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Mdl,
            "mga" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Mga,
            "mkd" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Mkd,
            "mmk" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Mmk,
            "mnt" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Mnt,
            "mop" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Mop,
            "mro" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Mro,
            "mvr" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Mvr,
            "mwk" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Mwk,
            "mxn" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Mxn,
            "myr" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Myr,
            "mzn" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Mzn,
            "nad" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Nad,
            "ngn" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Ngn,
            "nok" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Nok,
            "npr" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Npr,
            "nzd" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Nzd,
            "pgk" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Pgk,
            "php" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Php,
            "pkr" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Pkr,
            "pln" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Pln,
            "qar" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Qar,
            "ron" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Ron,
            "rsd" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Rsd,
            "rub" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Rub,
            "rwf" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Rwf,
            "sar" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Sar,
            "sbd" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Sbd,
            "scr" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Scr,
            "sek" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Sek,
            "sgd" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Sgd,
            "sle" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Sle,
            "sll" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Sll,
            "sos" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Sos,
            "szl" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Szl,
            "thb" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Thb,
            "tjs" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Tjs,
            "top" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Top,
            "try" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Try,
            "ttd" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Ttd,
            "tzs" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Tzs,
            "uah" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Uah,
            "uzs" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Uzs,
            "vnd" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Vnd,
            "vuv" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Vuv,
            "wst" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Wst,
            "xaf" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Xaf,
            "xcd" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Xcd,
            "yer" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Yer,
            "zar" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Zar,
            "zmw" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Zmw,
            "clp" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Clp,
            "djf" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Djf,
            "gnf" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Gnf,
            "ugx" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Ugx,
            "pyg" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Pyg,
            "xof" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Xof,
            "xpf" => SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Xpf,
            _ => (SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Usd => "usd",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Aed => "aed",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.All => "all",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Amd => "amd",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Ang => "ang",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Aud => "aud",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Awg => "awg",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Azn => "azn",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Bam => "bam",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Bbd => "bbd",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Bdt => "bdt",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Bgn => "bgn",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Bif => "bif",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Bmd => "bmd",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Bnd => "bnd",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Bsd => "bsd",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Bwp => "bwp",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Byn => "byn",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Bzd => "bzd",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Brl => "brl",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Cad => "cad",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Cdf => "cdf",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Chf => "chf",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Cny => "cny",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Czk => "czk",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Dkk => "dkk",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Dop => "dop",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Dzd => "dzd",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Egp => "egp",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Etb => "etb",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Eur => "eur",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Fjd => "fjd",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Gbp => "gbp",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Gel => "gel",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Gip => "gip",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Gmd => "gmd",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Gyd => "gyd",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Hkd => "hkd",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Hrk => "hrk",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Htg => "htg",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Idr => "idr",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Ils => "ils",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Inr => "inr",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Isk => "isk",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Jmd => "jmd",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Jpy => "jpy",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Kes => "kes",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Kgs => "kgs",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Khr => "khr",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Kmf => "kmf",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Krw => "krw",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Kyd => "kyd",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Kzt => "kzt",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Lbp => "lbp",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Lkr => "lkr",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Lrd => "lrd",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Lsl => "lsl",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Mad => "mad",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Mdl => "mdl",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Mga => "mga",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Mkd => "mkd",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Mmk => "mmk",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Mnt => "mnt",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Mop => "mop",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Mro => "mro",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Mvr => "mvr",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Mwk => "mwk",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Mxn => "mxn",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Myr => "myr",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Mzn => "mzn",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Nad => "nad",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Ngn => "ngn",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Nok => "nok",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Npr => "npr",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Nzd => "nzd",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Pgk => "pgk",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Php => "php",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Pkr => "pkr",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Pln => "pln",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Qar => "qar",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Ron => "ron",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Rsd => "rsd",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Rub => "rub",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Rwf => "rwf",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Sar => "sar",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Sbd => "sbd",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Scr => "scr",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Sek => "sek",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Sgd => "sgd",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Sle => "sle",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Sll => "sll",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Sos => "sos",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Szl => "szl",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Thb => "thb",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Tjs => "tjs",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Top => "top",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Try => "try",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Ttd => "ttd",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Tzs => "tzs",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Uah => "uah",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Uzs => "uzs",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Vnd => "vnd",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Vuv => "vuv",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Wst => "wst",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Xaf => "xaf",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Xcd => "xcd",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Yer => "yer",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Zar => "zar",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Zmw => "zmw",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Clp => "clp",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Djf => "djf",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Gnf => "gnf",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Ugx => "ugx",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Pyg => "pyg",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Xof => "xof",
                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Xpf => "xpf",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Feature with quantity
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BillableFeature, BillableFeatureFromRaw>))]
public sealed record class BillableFeature : JsonModel
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

    /// <summary>
    /// Quantity of feature units
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FeatureID;
        _ = this.Quantity;
    }

    public BillableFeature() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BillableFeature(BillableFeature billableFeature)
        : base(billableFeature) { }
#pragma warning restore CS8618

    public BillableFeature(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BillableFeature(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BillableFeatureFromRaw.FromRawUnchecked"/>
    public static BillableFeature FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BillableFeatureFromRaw : IFromRawJson<BillableFeature>
{
    /// <inheritdoc/>
    public BillableFeature FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BillableFeature.FromRawUnchecked(rawData);
}

/// <summary>
/// Billing and tax configuration
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionPreviewParamsBillingInformation,
        SubscriptionPreviewParamsBillingInformationFromRaw
    >)
)]
public sealed record class SubscriptionPreviewParamsBillingInformation : JsonModel
{
    /// <summary>
    /// Billing address
    /// </summary>
    public SubscriptionPreviewParamsBillingInformationBillingAddress? BillingAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SubscriptionPreviewParamsBillingInformationBillingAddress>(
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
    /// Connected account ID for platform billing
    /// </summary>
    public string? ChargeOnBehalfOfAccount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("chargeOnBehalfOfAccount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("chargeOnBehalfOfAccount", value);
        }
    }

    /// <summary>
    /// Billing integration ID
    /// </summary>
    public string? IntegrationID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("integrationId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("integrationId", value);
        }
    }

    /// <summary>
    /// Days until invoice is due
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
    /// Whether subscription is backdated
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
    /// Whether invoice is already paid
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
    /// Additional billing metadata
    /// </summary>
    public JsonElement? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("metadata", value);
        }
    }

    /// <summary>
    /// Proration behavior
    /// </summary>
    public ApiEnum<
        string,
        SubscriptionPreviewParamsBillingInformationProrationBehavior
    >? ProrationBehavior
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, SubscriptionPreviewParamsBillingInformationProrationBehavior>
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
    /// Customer tax IDs
    /// </summary>
    public IReadOnlyList<SubscriptionPreviewParamsBillingInformationTaxID>? TaxIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<SubscriptionPreviewParamsBillingInformationTaxID>
            >("taxIds");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<SubscriptionPreviewParamsBillingInformationTaxID>?>(
                "taxIds",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Tax percentage to apply
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
    /// Tax rate IDs from billing provider
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

    public SubscriptionPreviewParamsBillingInformation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionPreviewParamsBillingInformation(
        SubscriptionPreviewParamsBillingInformation subscriptionPreviewParamsBillingInformation
    )
        : base(subscriptionPreviewParamsBillingInformation) { }
#pragma warning restore CS8618

    public SubscriptionPreviewParamsBillingInformation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionPreviewParamsBillingInformation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionPreviewParamsBillingInformationFromRaw.FromRawUnchecked"/>
    public static SubscriptionPreviewParamsBillingInformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionPreviewParamsBillingInformationFromRaw
    : IFromRawJson<SubscriptionPreviewParamsBillingInformation>
{
    /// <inheritdoc/>
    public SubscriptionPreviewParamsBillingInformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionPreviewParamsBillingInformation.FromRawUnchecked(rawData);
}

/// <summary>
/// Billing address
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionPreviewParamsBillingInformationBillingAddress,
        SubscriptionPreviewParamsBillingInformationBillingAddressFromRaw
    >)
)]
public sealed record class SubscriptionPreviewParamsBillingInformationBillingAddress : JsonModel
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

    public SubscriptionPreviewParamsBillingInformationBillingAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionPreviewParamsBillingInformationBillingAddress(
        SubscriptionPreviewParamsBillingInformationBillingAddress subscriptionPreviewParamsBillingInformationBillingAddress
    )
        : base(subscriptionPreviewParamsBillingInformationBillingAddress) { }
#pragma warning restore CS8618

    public SubscriptionPreviewParamsBillingInformationBillingAddress(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionPreviewParamsBillingInformationBillingAddress(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionPreviewParamsBillingInformationBillingAddressFromRaw.FromRawUnchecked"/>
    public static SubscriptionPreviewParamsBillingInformationBillingAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionPreviewParamsBillingInformationBillingAddressFromRaw
    : IFromRawJson<SubscriptionPreviewParamsBillingInformationBillingAddress>
{
    /// <inheritdoc/>
    public SubscriptionPreviewParamsBillingInformationBillingAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionPreviewParamsBillingInformationBillingAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// Proration behavior
/// </summary>
[JsonConverter(typeof(SubscriptionPreviewParamsBillingInformationProrationBehaviorConverter))]
public enum SubscriptionPreviewParamsBillingInformationProrationBehavior
{
    InvoiceImmediately,
    CreateProrations,
    None,
}

sealed class SubscriptionPreviewParamsBillingInformationProrationBehaviorConverter
    : JsonConverter<SubscriptionPreviewParamsBillingInformationProrationBehavior>
{
    public override SubscriptionPreviewParamsBillingInformationProrationBehavior Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "INVOICE_IMMEDIATELY" =>
                SubscriptionPreviewParamsBillingInformationProrationBehavior.InvoiceImmediately,
            "CREATE_PRORATIONS" =>
                SubscriptionPreviewParamsBillingInformationProrationBehavior.CreateProrations,
            "NONE" => SubscriptionPreviewParamsBillingInformationProrationBehavior.None,
            _ => (SubscriptionPreviewParamsBillingInformationProrationBehavior)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionPreviewParamsBillingInformationProrationBehavior value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionPreviewParamsBillingInformationProrationBehavior.InvoiceImmediately =>
                    "INVOICE_IMMEDIATELY",
                SubscriptionPreviewParamsBillingInformationProrationBehavior.CreateProrations =>
                    "CREATE_PRORATIONS",
                SubscriptionPreviewParamsBillingInformationProrationBehavior.None => "NONE",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Tax exemption identifier
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionPreviewParamsBillingInformationTaxID,
        SubscriptionPreviewParamsBillingInformationTaxIDFromRaw
    >)
)]
public sealed record class SubscriptionPreviewParamsBillingInformationTaxID : JsonModel
{
    /// <summary>
    /// Tax exemption type (e.g., vat, gst)
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
    /// Tax exemption identifier value
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

    public SubscriptionPreviewParamsBillingInformationTaxID() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionPreviewParamsBillingInformationTaxID(
        SubscriptionPreviewParamsBillingInformationTaxID subscriptionPreviewParamsBillingInformationTaxID
    )
        : base(subscriptionPreviewParamsBillingInformationTaxID) { }
#pragma warning restore CS8618

    public SubscriptionPreviewParamsBillingInformationTaxID(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionPreviewParamsBillingInformationTaxID(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionPreviewParamsBillingInformationTaxIDFromRaw.FromRawUnchecked"/>
    public static SubscriptionPreviewParamsBillingInformationTaxID FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionPreviewParamsBillingInformationTaxIDFromRaw
    : IFromRawJson<SubscriptionPreviewParamsBillingInformationTaxID>
{
    /// <inheritdoc/>
    public SubscriptionPreviewParamsBillingInformationTaxID FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionPreviewParamsBillingInformationTaxID.FromRawUnchecked(rawData);
}

/// <summary>
/// Billing period (MONTHLY or ANNUALLY)
/// </summary>
[JsonConverter(typeof(SubscriptionPreviewParamsBillingPeriodConverter))]
public enum SubscriptionPreviewParamsBillingPeriod
{
    Monthly,
    Annually,
}

sealed class SubscriptionPreviewParamsBillingPeriodConverter
    : JsonConverter<SubscriptionPreviewParamsBillingPeriod>
{
    public override SubscriptionPreviewParamsBillingPeriod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "MONTHLY" => SubscriptionPreviewParamsBillingPeriod.Monthly,
            "ANNUALLY" => SubscriptionPreviewParamsBillingPeriod.Annually,
            _ => (SubscriptionPreviewParamsBillingPeriod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionPreviewParamsBillingPeriod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionPreviewParamsBillingPeriod.Monthly => "MONTHLY",
                SubscriptionPreviewParamsBillingPeriod.Annually => "ANNUALLY",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Charge item
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionPreviewParamsCharge,
        SubscriptionPreviewParamsChargeFromRaw
    >)
)]
public sealed record class SubscriptionPreviewParamsCharge : JsonModel
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
    public required ApiEnum<string, SubscriptionPreviewParamsChargeType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, SubscriptionPreviewParamsChargeType>
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

    public SubscriptionPreviewParamsCharge() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionPreviewParamsCharge(
        SubscriptionPreviewParamsCharge subscriptionPreviewParamsCharge
    )
        : base(subscriptionPreviewParamsCharge) { }
#pragma warning restore CS8618

    public SubscriptionPreviewParamsCharge(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionPreviewParamsCharge(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionPreviewParamsChargeFromRaw.FromRawUnchecked"/>
    public static SubscriptionPreviewParamsCharge FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionPreviewParamsChargeFromRaw : IFromRawJson<SubscriptionPreviewParamsCharge>
{
    /// <inheritdoc/>
    public SubscriptionPreviewParamsCharge FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionPreviewParamsCharge.FromRawUnchecked(rawData);
}

/// <summary>
/// Charge type
/// </summary>
[JsonConverter(typeof(SubscriptionPreviewParamsChargeTypeConverter))]
public enum SubscriptionPreviewParamsChargeType
{
    Feature,
    Credit,
}

sealed class SubscriptionPreviewParamsChargeTypeConverter
    : JsonConverter<SubscriptionPreviewParamsChargeType>
{
    public override SubscriptionPreviewParamsChargeType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FEATURE" => SubscriptionPreviewParamsChargeType.Feature,
            "CREDIT" => SubscriptionPreviewParamsChargeType.Credit,
            _ => (SubscriptionPreviewParamsChargeType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionPreviewParamsChargeType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionPreviewParamsChargeType.Feature => "FEATURE",
                SubscriptionPreviewParamsChargeType.Credit => "CREDIT",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// When to apply subscription changes
/// </summary>
[JsonConverter(typeof(SubscriptionPreviewParamsScheduleStrategyConverter))]
public enum SubscriptionPreviewParamsScheduleStrategy
{
    EndOfBillingPeriod,
    EndOfBillingMonth,
    Immediate,
}

sealed class SubscriptionPreviewParamsScheduleStrategyConverter
    : JsonConverter<SubscriptionPreviewParamsScheduleStrategy>
{
    public override SubscriptionPreviewParamsScheduleStrategy Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "END_OF_BILLING_PERIOD" => SubscriptionPreviewParamsScheduleStrategy.EndOfBillingPeriod,
            "END_OF_BILLING_MONTH" => SubscriptionPreviewParamsScheduleStrategy.EndOfBillingMonth,
            "IMMEDIATE" => SubscriptionPreviewParamsScheduleStrategy.Immediate,
            _ => (SubscriptionPreviewParamsScheduleStrategy)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionPreviewParamsScheduleStrategy value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubscriptionPreviewParamsScheduleStrategy.EndOfBillingPeriod =>
                    "END_OF_BILLING_PERIOD",
                SubscriptionPreviewParamsScheduleStrategy.EndOfBillingMonth =>
                    "END_OF_BILLING_MONTH",
                SubscriptionPreviewParamsScheduleStrategy.Immediate => "IMMEDIATE",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Trial period override settings
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<TrialOverrideConfiguration, TrialOverrideConfigurationFromRaw>)
)]
public sealed record class TrialOverrideConfiguration : JsonModel
{
    /// <summary>
    /// Whether to start as trial
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
    /// Behavior when trial ends
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
    /// Trial end date
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
/// Behavior when trial ends
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
