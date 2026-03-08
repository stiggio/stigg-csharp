using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Subscriptions;

namespace Stigg.Client.Tests.Models.V1.Subscriptions;

public class SubscriptionProvisionResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionProvisionResponse
        {
            Data = new()
            {
                ID = "id",
                Entitlements =
                [
                    new UnionObjectVariant0()
                    {
                        AccessDeniedReason = AccessDeniedReason.FeatureNotFound,
                        IsGranted = true,
                        Type = UnionObjectVariant0Type.Feature,
                        CurrentUsage = 0,
                        EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Feature = new()
                        {
                            DisplayName = "displayName",
                            FeatureStatus = FeatureStatus.New,
                            FeatureType = FeatureType.Boolean,
                            RefID = "refId",
                        },
                        HasUnlimitedUsage = true,
                        ResetPeriod = UnionObjectVariant0ResetPeriod.Year,
                        UsageLimit = 0,
                        UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
                Status = SubscriptionProvisionResponseDataStatus.Success,
                Subscription = new()
                {
                    ID = "id",
                    BillingID = "billingId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "customerId",
                    PaymentCollection =
                        SubscriptionProvisionResponseDataSubscriptionPaymentCollection.NotRequired,
                    PlanID = "planId",
                    PricingType = SubscriptionProvisionResponseDataSubscriptionPricingType.Free,
                    StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = SubscriptionProvisionResponseDataSubscriptionStatus.PaymentPending,
                    Addons = [new() { ID = "id", Quantity = 0 }],
                    BillingCycleAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Budget = new() { HasSoftLimit = true, Limit = 0 },
                    CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CancelReason =
                        SubscriptionProvisionResponseDataSubscriptionCancelReason.UpgradeOrDowngrade,
                    Coupons =
                    [
                        new()
                        {
                            ID = "id",
                            Name = "name",
                            Status =
                                SubscriptionProvisionResponseDataSubscriptionCouponStatus.Active,
                            AmountsOff =
                            [
                                new()
                                {
                                    Amount = 0,
                                    Currency =
                                        SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Usd,
                                },
                            ],
                            PercentOff = 0,
                        },
                    ],
                    CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FutureUpdates =
                    [
                        new()
                        {
                            ScheduledExecutionTime = DateTimeOffset.Parse(
                                "2019-12-27T18:11:19.117Z"
                            ),
                            ScheduleStatus =
                                SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus.PendingPayment,
                            SubscriptionScheduleType =
                                SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.Downgrade,
                            TargetPackage = new("id"),
                        },
                    ],
                    LatestInvoice = new()
                    {
                        BillingID = "billingId",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        RequiresAction = true,
                        Status =
                            SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus.Open,
                        AmountDue = 0,
                        BillingReason =
                            SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason.BillingCycle,
                        Currency = "currency",
                        PdfUrl = "pdfUrl",
                        Total = 0,
                    },
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    MinimumSpend = new()
                    {
                        Amount = 0,
                        Currency =
                            SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Usd,
                    },
                    PayingCustomerID = "payingCustomerId",
                    PaymentCollectionMethod =
                        SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.Charge,
                    Prices =
                    [
                        new()
                        {
                            AddonID = "addonId",
                            Amount = 0,
                            BaseCharge = true,
                            BillingCountryCode = "billingCountryCode",
                            BlockSize = 0,
                            Currency =
                                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Usd,
                            FeatureID = "featureId",
                            Tiers =
                            [
                                new()
                                {
                                    FlatPrice = new()
                                    {
                                        Amount = 0,
                                        Currency =
                                            SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                                    },
                                    UnitPrice = new()
                                    {
                                        Amount = 0,
                                        Currency =
                                            SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                                    },
                                    UpTo = 0,
                                },
                            ],
                        },
                    ],
                    ResourceID = "resourceId",
                    SubscriptionEntitlements =
                    [
                        new()
                        {
                            ID = "id",
                            Type =
                                SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementType.Feature,
                        },
                    ],
                    Trial = new(
                        SubscriptionProvisionResponseDataSubscriptionTrialTrialEndBehavior.ConvertToPaid
                    ),
                    TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                CheckoutBillingID = "checkoutBillingId",
                CheckoutUrl = "checkoutUrl",
                IsScheduled = true,
            },
        };

        SubscriptionProvisionResponseData expectedData = new()
        {
            ID = "id",
            Entitlements =
            [
                new UnionObjectVariant0()
                {
                    AccessDeniedReason = AccessDeniedReason.FeatureNotFound,
                    IsGranted = true,
                    Type = UnionObjectVariant0Type.Feature,
                    CurrentUsage = 0,
                    EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Feature = new()
                    {
                        DisplayName = "displayName",
                        FeatureStatus = FeatureStatus.New,
                        FeatureType = FeatureType.Boolean,
                        RefID = "refId",
                    },
                    HasUnlimitedUsage = true,
                    ResetPeriod = UnionObjectVariant0ResetPeriod.Year,
                    UsageLimit = 0,
                    UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Status = SubscriptionProvisionResponseDataStatus.Success,
            Subscription = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customerId",
                PaymentCollection =
                    SubscriptionProvisionResponseDataSubscriptionPaymentCollection.NotRequired,
                PlanID = "planId",
                PricingType = SubscriptionProvisionResponseDataSubscriptionPricingType.Free,
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = SubscriptionProvisionResponseDataSubscriptionStatus.PaymentPending,
                Addons = [new() { ID = "id", Quantity = 0 }],
                BillingCycleAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Budget = new() { HasSoftLimit = true, Limit = 0 },
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason =
                    SubscriptionProvisionResponseDataSubscriptionCancelReason.UpgradeOrDowngrade,
                Coupons =
                [
                    new()
                    {
                        ID = "id",
                        Name = "name",
                        Status = SubscriptionProvisionResponseDataSubscriptionCouponStatus.Active,
                        AmountsOff =
                        [
                            new()
                            {
                                Amount = 0,
                                Currency =
                                    SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Usd,
                            },
                        ],
                        PercentOff = 0,
                    },
                ],
                CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FutureUpdates =
                [
                    new()
                    {
                        ScheduledExecutionTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ScheduleStatus =
                            SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus.PendingPayment,
                        SubscriptionScheduleType =
                            SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.Downgrade,
                        TargetPackage = new("id"),
                    },
                ],
                LatestInvoice = new()
                {
                    BillingID = "billingId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    RequiresAction = true,
                    Status = SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus.Open,
                    AmountDue = 0,
                    BillingReason =
                        SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason.BillingCycle,
                    Currency = "currency",
                    PdfUrl = "pdfUrl",
                    Total = 0,
                },
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MinimumSpend = new()
                {
                    Amount = 0,
                    Currency =
                        SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Usd,
                },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod =
                    SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.Charge,
                Prices =
                [
                    new()
                    {
                        AddonID = "addonId",
                        Amount = 0,
                        BaseCharge = true,
                        BillingCountryCode = "billingCountryCode",
                        BlockSize = 0,
                        Currency = SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Usd,
                        FeatureID = "featureId",
                        Tiers =
                        [
                            new()
                            {
                                FlatPrice = new()
                                {
                                    Amount = 0,
                                    Currency =
                                        SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                                },
                                UnitPrice = new()
                                {
                                    Amount = 0,
                                    Currency =
                                        SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                                },
                                UpTo = 0,
                            },
                        ],
                    },
                ],
                ResourceID = "resourceId",
                SubscriptionEntitlements =
                [
                    new()
                    {
                        ID = "id",
                        Type =
                            SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementType.Feature,
                    },
                ],
                Trial = new(
                    SubscriptionProvisionResponseDataSubscriptionTrialTrialEndBehavior.ConvertToPaid
                ),
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            CheckoutBillingID = "checkoutBillingId",
            CheckoutUrl = "checkoutUrl",
            IsScheduled = true,
        };

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionProvisionResponse
        {
            Data = new()
            {
                ID = "id",
                Entitlements =
                [
                    new UnionObjectVariant0()
                    {
                        AccessDeniedReason = AccessDeniedReason.FeatureNotFound,
                        IsGranted = true,
                        Type = UnionObjectVariant0Type.Feature,
                        CurrentUsage = 0,
                        EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Feature = new()
                        {
                            DisplayName = "displayName",
                            FeatureStatus = FeatureStatus.New,
                            FeatureType = FeatureType.Boolean,
                            RefID = "refId",
                        },
                        HasUnlimitedUsage = true,
                        ResetPeriod = UnionObjectVariant0ResetPeriod.Year,
                        UsageLimit = 0,
                        UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
                Status = SubscriptionProvisionResponseDataStatus.Success,
                Subscription = new()
                {
                    ID = "id",
                    BillingID = "billingId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "customerId",
                    PaymentCollection =
                        SubscriptionProvisionResponseDataSubscriptionPaymentCollection.NotRequired,
                    PlanID = "planId",
                    PricingType = SubscriptionProvisionResponseDataSubscriptionPricingType.Free,
                    StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = SubscriptionProvisionResponseDataSubscriptionStatus.PaymentPending,
                    Addons = [new() { ID = "id", Quantity = 0 }],
                    BillingCycleAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Budget = new() { HasSoftLimit = true, Limit = 0 },
                    CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CancelReason =
                        SubscriptionProvisionResponseDataSubscriptionCancelReason.UpgradeOrDowngrade,
                    Coupons =
                    [
                        new()
                        {
                            ID = "id",
                            Name = "name",
                            Status =
                                SubscriptionProvisionResponseDataSubscriptionCouponStatus.Active,
                            AmountsOff =
                            [
                                new()
                                {
                                    Amount = 0,
                                    Currency =
                                        SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Usd,
                                },
                            ],
                            PercentOff = 0,
                        },
                    ],
                    CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FutureUpdates =
                    [
                        new()
                        {
                            ScheduledExecutionTime = DateTimeOffset.Parse(
                                "2019-12-27T18:11:19.117Z"
                            ),
                            ScheduleStatus =
                                SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus.PendingPayment,
                            SubscriptionScheduleType =
                                SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.Downgrade,
                            TargetPackage = new("id"),
                        },
                    ],
                    LatestInvoice = new()
                    {
                        BillingID = "billingId",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        RequiresAction = true,
                        Status =
                            SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus.Open,
                        AmountDue = 0,
                        BillingReason =
                            SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason.BillingCycle,
                        Currency = "currency",
                        PdfUrl = "pdfUrl",
                        Total = 0,
                    },
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    MinimumSpend = new()
                    {
                        Amount = 0,
                        Currency =
                            SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Usd,
                    },
                    PayingCustomerID = "payingCustomerId",
                    PaymentCollectionMethod =
                        SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.Charge,
                    Prices =
                    [
                        new()
                        {
                            AddonID = "addonId",
                            Amount = 0,
                            BaseCharge = true,
                            BillingCountryCode = "billingCountryCode",
                            BlockSize = 0,
                            Currency =
                                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Usd,
                            FeatureID = "featureId",
                            Tiers =
                            [
                                new()
                                {
                                    FlatPrice = new()
                                    {
                                        Amount = 0,
                                        Currency =
                                            SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                                    },
                                    UnitPrice = new()
                                    {
                                        Amount = 0,
                                        Currency =
                                            SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                                    },
                                    UpTo = 0,
                                },
                            ],
                        },
                    ],
                    ResourceID = "resourceId",
                    SubscriptionEntitlements =
                    [
                        new()
                        {
                            ID = "id",
                            Type =
                                SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementType.Feature,
                        },
                    ],
                    Trial = new(
                        SubscriptionProvisionResponseDataSubscriptionTrialTrialEndBehavior.ConvertToPaid
                    ),
                    TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                CheckoutBillingID = "checkoutBillingId",
                CheckoutUrl = "checkoutUrl",
                IsScheduled = true,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionProvisionResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionProvisionResponse
        {
            Data = new()
            {
                ID = "id",
                Entitlements =
                [
                    new UnionObjectVariant0()
                    {
                        AccessDeniedReason = AccessDeniedReason.FeatureNotFound,
                        IsGranted = true,
                        Type = UnionObjectVariant0Type.Feature,
                        CurrentUsage = 0,
                        EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Feature = new()
                        {
                            DisplayName = "displayName",
                            FeatureStatus = FeatureStatus.New,
                            FeatureType = FeatureType.Boolean,
                            RefID = "refId",
                        },
                        HasUnlimitedUsage = true,
                        ResetPeriod = UnionObjectVariant0ResetPeriod.Year,
                        UsageLimit = 0,
                        UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
                Status = SubscriptionProvisionResponseDataStatus.Success,
                Subscription = new()
                {
                    ID = "id",
                    BillingID = "billingId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "customerId",
                    PaymentCollection =
                        SubscriptionProvisionResponseDataSubscriptionPaymentCollection.NotRequired,
                    PlanID = "planId",
                    PricingType = SubscriptionProvisionResponseDataSubscriptionPricingType.Free,
                    StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = SubscriptionProvisionResponseDataSubscriptionStatus.PaymentPending,
                    Addons = [new() { ID = "id", Quantity = 0 }],
                    BillingCycleAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Budget = new() { HasSoftLimit = true, Limit = 0 },
                    CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CancelReason =
                        SubscriptionProvisionResponseDataSubscriptionCancelReason.UpgradeOrDowngrade,
                    Coupons =
                    [
                        new()
                        {
                            ID = "id",
                            Name = "name",
                            Status =
                                SubscriptionProvisionResponseDataSubscriptionCouponStatus.Active,
                            AmountsOff =
                            [
                                new()
                                {
                                    Amount = 0,
                                    Currency =
                                        SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Usd,
                                },
                            ],
                            PercentOff = 0,
                        },
                    ],
                    CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FutureUpdates =
                    [
                        new()
                        {
                            ScheduledExecutionTime = DateTimeOffset.Parse(
                                "2019-12-27T18:11:19.117Z"
                            ),
                            ScheduleStatus =
                                SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus.PendingPayment,
                            SubscriptionScheduleType =
                                SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.Downgrade,
                            TargetPackage = new("id"),
                        },
                    ],
                    LatestInvoice = new()
                    {
                        BillingID = "billingId",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        RequiresAction = true,
                        Status =
                            SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus.Open,
                        AmountDue = 0,
                        BillingReason =
                            SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason.BillingCycle,
                        Currency = "currency",
                        PdfUrl = "pdfUrl",
                        Total = 0,
                    },
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    MinimumSpend = new()
                    {
                        Amount = 0,
                        Currency =
                            SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Usd,
                    },
                    PayingCustomerID = "payingCustomerId",
                    PaymentCollectionMethod =
                        SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.Charge,
                    Prices =
                    [
                        new()
                        {
                            AddonID = "addonId",
                            Amount = 0,
                            BaseCharge = true,
                            BillingCountryCode = "billingCountryCode",
                            BlockSize = 0,
                            Currency =
                                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Usd,
                            FeatureID = "featureId",
                            Tiers =
                            [
                                new()
                                {
                                    FlatPrice = new()
                                    {
                                        Amount = 0,
                                        Currency =
                                            SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                                    },
                                    UnitPrice = new()
                                    {
                                        Amount = 0,
                                        Currency =
                                            SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                                    },
                                    UpTo = 0,
                                },
                            ],
                        },
                    ],
                    ResourceID = "resourceId",
                    SubscriptionEntitlements =
                    [
                        new()
                        {
                            ID = "id",
                            Type =
                                SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementType.Feature,
                        },
                    ],
                    Trial = new(
                        SubscriptionProvisionResponseDataSubscriptionTrialTrialEndBehavior.ConvertToPaid
                    ),
                    TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                CheckoutBillingID = "checkoutBillingId",
                CheckoutUrl = "checkoutUrl",
                IsScheduled = true,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionProvisionResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        SubscriptionProvisionResponseData expectedData = new()
        {
            ID = "id",
            Entitlements =
            [
                new UnionObjectVariant0()
                {
                    AccessDeniedReason = AccessDeniedReason.FeatureNotFound,
                    IsGranted = true,
                    Type = UnionObjectVariant0Type.Feature,
                    CurrentUsage = 0,
                    EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Feature = new()
                    {
                        DisplayName = "displayName",
                        FeatureStatus = FeatureStatus.New,
                        FeatureType = FeatureType.Boolean,
                        RefID = "refId",
                    },
                    HasUnlimitedUsage = true,
                    ResetPeriod = UnionObjectVariant0ResetPeriod.Year,
                    UsageLimit = 0,
                    UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Status = SubscriptionProvisionResponseDataStatus.Success,
            Subscription = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customerId",
                PaymentCollection =
                    SubscriptionProvisionResponseDataSubscriptionPaymentCollection.NotRequired,
                PlanID = "planId",
                PricingType = SubscriptionProvisionResponseDataSubscriptionPricingType.Free,
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = SubscriptionProvisionResponseDataSubscriptionStatus.PaymentPending,
                Addons = [new() { ID = "id", Quantity = 0 }],
                BillingCycleAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Budget = new() { HasSoftLimit = true, Limit = 0 },
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason =
                    SubscriptionProvisionResponseDataSubscriptionCancelReason.UpgradeOrDowngrade,
                Coupons =
                [
                    new()
                    {
                        ID = "id",
                        Name = "name",
                        Status = SubscriptionProvisionResponseDataSubscriptionCouponStatus.Active,
                        AmountsOff =
                        [
                            new()
                            {
                                Amount = 0,
                                Currency =
                                    SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Usd,
                            },
                        ],
                        PercentOff = 0,
                    },
                ],
                CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FutureUpdates =
                [
                    new()
                    {
                        ScheduledExecutionTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ScheduleStatus =
                            SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus.PendingPayment,
                        SubscriptionScheduleType =
                            SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.Downgrade,
                        TargetPackage = new("id"),
                    },
                ],
                LatestInvoice = new()
                {
                    BillingID = "billingId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    RequiresAction = true,
                    Status = SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus.Open,
                    AmountDue = 0,
                    BillingReason =
                        SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason.BillingCycle,
                    Currency = "currency",
                    PdfUrl = "pdfUrl",
                    Total = 0,
                },
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MinimumSpend = new()
                {
                    Amount = 0,
                    Currency =
                        SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Usd,
                },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod =
                    SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.Charge,
                Prices =
                [
                    new()
                    {
                        AddonID = "addonId",
                        Amount = 0,
                        BaseCharge = true,
                        BillingCountryCode = "billingCountryCode",
                        BlockSize = 0,
                        Currency = SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Usd,
                        FeatureID = "featureId",
                        Tiers =
                        [
                            new()
                            {
                                FlatPrice = new()
                                {
                                    Amount = 0,
                                    Currency =
                                        SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                                },
                                UnitPrice = new()
                                {
                                    Amount = 0,
                                    Currency =
                                        SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                                },
                                UpTo = 0,
                            },
                        ],
                    },
                ],
                ResourceID = "resourceId",
                SubscriptionEntitlements =
                [
                    new()
                    {
                        ID = "id",
                        Type =
                            SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementType.Feature,
                    },
                ],
                Trial = new(
                    SubscriptionProvisionResponseDataSubscriptionTrialTrialEndBehavior.ConvertToPaid
                ),
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            CheckoutBillingID = "checkoutBillingId",
            CheckoutUrl = "checkoutUrl",
            IsScheduled = true,
        };

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionProvisionResponse
        {
            Data = new()
            {
                ID = "id",
                Entitlements =
                [
                    new UnionObjectVariant0()
                    {
                        AccessDeniedReason = AccessDeniedReason.FeatureNotFound,
                        IsGranted = true,
                        Type = UnionObjectVariant0Type.Feature,
                        CurrentUsage = 0,
                        EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Feature = new()
                        {
                            DisplayName = "displayName",
                            FeatureStatus = FeatureStatus.New,
                            FeatureType = FeatureType.Boolean,
                            RefID = "refId",
                        },
                        HasUnlimitedUsage = true,
                        ResetPeriod = UnionObjectVariant0ResetPeriod.Year,
                        UsageLimit = 0,
                        UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
                Status = SubscriptionProvisionResponseDataStatus.Success,
                Subscription = new()
                {
                    ID = "id",
                    BillingID = "billingId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "customerId",
                    PaymentCollection =
                        SubscriptionProvisionResponseDataSubscriptionPaymentCollection.NotRequired,
                    PlanID = "planId",
                    PricingType = SubscriptionProvisionResponseDataSubscriptionPricingType.Free,
                    StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = SubscriptionProvisionResponseDataSubscriptionStatus.PaymentPending,
                    Addons = [new() { ID = "id", Quantity = 0 }],
                    BillingCycleAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Budget = new() { HasSoftLimit = true, Limit = 0 },
                    CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CancelReason =
                        SubscriptionProvisionResponseDataSubscriptionCancelReason.UpgradeOrDowngrade,
                    Coupons =
                    [
                        new()
                        {
                            ID = "id",
                            Name = "name",
                            Status =
                                SubscriptionProvisionResponseDataSubscriptionCouponStatus.Active,
                            AmountsOff =
                            [
                                new()
                                {
                                    Amount = 0,
                                    Currency =
                                        SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Usd,
                                },
                            ],
                            PercentOff = 0,
                        },
                    ],
                    CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FutureUpdates =
                    [
                        new()
                        {
                            ScheduledExecutionTime = DateTimeOffset.Parse(
                                "2019-12-27T18:11:19.117Z"
                            ),
                            ScheduleStatus =
                                SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus.PendingPayment,
                            SubscriptionScheduleType =
                                SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.Downgrade,
                            TargetPackage = new("id"),
                        },
                    ],
                    LatestInvoice = new()
                    {
                        BillingID = "billingId",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        RequiresAction = true,
                        Status =
                            SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus.Open,
                        AmountDue = 0,
                        BillingReason =
                            SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason.BillingCycle,
                        Currency = "currency",
                        PdfUrl = "pdfUrl",
                        Total = 0,
                    },
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    MinimumSpend = new()
                    {
                        Amount = 0,
                        Currency =
                            SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Usd,
                    },
                    PayingCustomerID = "payingCustomerId",
                    PaymentCollectionMethod =
                        SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.Charge,
                    Prices =
                    [
                        new()
                        {
                            AddonID = "addonId",
                            Amount = 0,
                            BaseCharge = true,
                            BillingCountryCode = "billingCountryCode",
                            BlockSize = 0,
                            Currency =
                                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Usd,
                            FeatureID = "featureId",
                            Tiers =
                            [
                                new()
                                {
                                    FlatPrice = new()
                                    {
                                        Amount = 0,
                                        Currency =
                                            SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                                    },
                                    UnitPrice = new()
                                    {
                                        Amount = 0,
                                        Currency =
                                            SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                                    },
                                    UpTo = 0,
                                },
                            ],
                        },
                    ],
                    ResourceID = "resourceId",
                    SubscriptionEntitlements =
                    [
                        new()
                        {
                            ID = "id",
                            Type =
                                SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementType.Feature,
                        },
                    ],
                    Trial = new(
                        SubscriptionProvisionResponseDataSubscriptionTrialTrialEndBehavior.ConvertToPaid
                    ),
                    TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                CheckoutBillingID = "checkoutBillingId",
                CheckoutUrl = "checkoutUrl",
                IsScheduled = true,
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionProvisionResponse
        {
            Data = new()
            {
                ID = "id",
                Entitlements =
                [
                    new UnionObjectVariant0()
                    {
                        AccessDeniedReason = AccessDeniedReason.FeatureNotFound,
                        IsGranted = true,
                        Type = UnionObjectVariant0Type.Feature,
                        CurrentUsage = 0,
                        EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Feature = new()
                        {
                            DisplayName = "displayName",
                            FeatureStatus = FeatureStatus.New,
                            FeatureType = FeatureType.Boolean,
                            RefID = "refId",
                        },
                        HasUnlimitedUsage = true,
                        ResetPeriod = UnionObjectVariant0ResetPeriod.Year,
                        UsageLimit = 0,
                        UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
                Status = SubscriptionProvisionResponseDataStatus.Success,
                Subscription = new()
                {
                    ID = "id",
                    BillingID = "billingId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "customerId",
                    PaymentCollection =
                        SubscriptionProvisionResponseDataSubscriptionPaymentCollection.NotRequired,
                    PlanID = "planId",
                    PricingType = SubscriptionProvisionResponseDataSubscriptionPricingType.Free,
                    StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = SubscriptionProvisionResponseDataSubscriptionStatus.PaymentPending,
                    Addons = [new() { ID = "id", Quantity = 0 }],
                    BillingCycleAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Budget = new() { HasSoftLimit = true, Limit = 0 },
                    CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CancelReason =
                        SubscriptionProvisionResponseDataSubscriptionCancelReason.UpgradeOrDowngrade,
                    Coupons =
                    [
                        new()
                        {
                            ID = "id",
                            Name = "name",
                            Status =
                                SubscriptionProvisionResponseDataSubscriptionCouponStatus.Active,
                            AmountsOff =
                            [
                                new()
                                {
                                    Amount = 0,
                                    Currency =
                                        SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Usd,
                                },
                            ],
                            PercentOff = 0,
                        },
                    ],
                    CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FutureUpdates =
                    [
                        new()
                        {
                            ScheduledExecutionTime = DateTimeOffset.Parse(
                                "2019-12-27T18:11:19.117Z"
                            ),
                            ScheduleStatus =
                                SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus.PendingPayment,
                            SubscriptionScheduleType =
                                SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.Downgrade,
                            TargetPackage = new("id"),
                        },
                    ],
                    LatestInvoice = new()
                    {
                        BillingID = "billingId",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        RequiresAction = true,
                        Status =
                            SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus.Open,
                        AmountDue = 0,
                        BillingReason =
                            SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason.BillingCycle,
                        Currency = "currency",
                        PdfUrl = "pdfUrl",
                        Total = 0,
                    },
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    MinimumSpend = new()
                    {
                        Amount = 0,
                        Currency =
                            SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Usd,
                    },
                    PayingCustomerID = "payingCustomerId",
                    PaymentCollectionMethod =
                        SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.Charge,
                    Prices =
                    [
                        new()
                        {
                            AddonID = "addonId",
                            Amount = 0,
                            BaseCharge = true,
                            BillingCountryCode = "billingCountryCode",
                            BlockSize = 0,
                            Currency =
                                SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Usd,
                            FeatureID = "featureId",
                            Tiers =
                            [
                                new()
                                {
                                    FlatPrice = new()
                                    {
                                        Amount = 0,
                                        Currency =
                                            SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                                    },
                                    UnitPrice = new()
                                    {
                                        Amount = 0,
                                        Currency =
                                            SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                                    },
                                    UpTo = 0,
                                },
                            ],
                        },
                    ],
                    ResourceID = "resourceId",
                    SubscriptionEntitlements =
                    [
                        new()
                        {
                            ID = "id",
                            Type =
                                SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementType.Feature,
                        },
                    ],
                    Trial = new(
                        SubscriptionProvisionResponseDataSubscriptionTrialTrialEndBehavior.ConvertToPaid
                    ),
                    TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                CheckoutBillingID = "checkoutBillingId",
                CheckoutUrl = "checkoutUrl",
                IsScheduled = true,
            },
        };

        SubscriptionProvisionResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionProvisionResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionProvisionResponseData
        {
            ID = "id",
            Entitlements =
            [
                new UnionObjectVariant0()
                {
                    AccessDeniedReason = AccessDeniedReason.FeatureNotFound,
                    IsGranted = true,
                    Type = UnionObjectVariant0Type.Feature,
                    CurrentUsage = 0,
                    EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Feature = new()
                    {
                        DisplayName = "displayName",
                        FeatureStatus = FeatureStatus.New,
                        FeatureType = FeatureType.Boolean,
                        RefID = "refId",
                    },
                    HasUnlimitedUsage = true,
                    ResetPeriod = UnionObjectVariant0ResetPeriod.Year,
                    UsageLimit = 0,
                    UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Status = SubscriptionProvisionResponseDataStatus.Success,
            Subscription = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customerId",
                PaymentCollection =
                    SubscriptionProvisionResponseDataSubscriptionPaymentCollection.NotRequired,
                PlanID = "planId",
                PricingType = SubscriptionProvisionResponseDataSubscriptionPricingType.Free,
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = SubscriptionProvisionResponseDataSubscriptionStatus.PaymentPending,
                Addons = [new() { ID = "id", Quantity = 0 }],
                BillingCycleAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Budget = new() { HasSoftLimit = true, Limit = 0 },
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason =
                    SubscriptionProvisionResponseDataSubscriptionCancelReason.UpgradeOrDowngrade,
                Coupons =
                [
                    new()
                    {
                        ID = "id",
                        Name = "name",
                        Status = SubscriptionProvisionResponseDataSubscriptionCouponStatus.Active,
                        AmountsOff =
                        [
                            new()
                            {
                                Amount = 0,
                                Currency =
                                    SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Usd,
                            },
                        ],
                        PercentOff = 0,
                    },
                ],
                CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FutureUpdates =
                [
                    new()
                    {
                        ScheduledExecutionTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ScheduleStatus =
                            SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus.PendingPayment,
                        SubscriptionScheduleType =
                            SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.Downgrade,
                        TargetPackage = new("id"),
                    },
                ],
                LatestInvoice = new()
                {
                    BillingID = "billingId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    RequiresAction = true,
                    Status = SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus.Open,
                    AmountDue = 0,
                    BillingReason =
                        SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason.BillingCycle,
                    Currency = "currency",
                    PdfUrl = "pdfUrl",
                    Total = 0,
                },
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MinimumSpend = new()
                {
                    Amount = 0,
                    Currency =
                        SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Usd,
                },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod =
                    SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.Charge,
                Prices =
                [
                    new()
                    {
                        AddonID = "addonId",
                        Amount = 0,
                        BaseCharge = true,
                        BillingCountryCode = "billingCountryCode",
                        BlockSize = 0,
                        Currency = SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Usd,
                        FeatureID = "featureId",
                        Tiers =
                        [
                            new()
                            {
                                FlatPrice = new()
                                {
                                    Amount = 0,
                                    Currency =
                                        SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                                },
                                UnitPrice = new()
                                {
                                    Amount = 0,
                                    Currency =
                                        SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                                },
                                UpTo = 0,
                            },
                        ],
                    },
                ],
                ResourceID = "resourceId",
                SubscriptionEntitlements =
                [
                    new()
                    {
                        ID = "id",
                        Type =
                            SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementType.Feature,
                    },
                ],
                Trial = new(
                    SubscriptionProvisionResponseDataSubscriptionTrialTrialEndBehavior.ConvertToPaid
                ),
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            CheckoutBillingID = "checkoutBillingId",
            CheckoutUrl = "checkoutUrl",
            IsScheduled = true,
        };

        string expectedID = "id";
        List<SubscriptionProvisionResponseDataEntitlement> expectedEntitlements =
        [
            new UnionObjectVariant0()
            {
                AccessDeniedReason = AccessDeniedReason.FeatureNotFound,
                IsGranted = true,
                Type = UnionObjectVariant0Type.Feature,
                CurrentUsage = 0,
                EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Feature = new()
                {
                    DisplayName = "displayName",
                    FeatureStatus = FeatureStatus.New,
                    FeatureType = FeatureType.Boolean,
                    RefID = "refId",
                },
                HasUnlimitedUsage = true,
                ResetPeriod = UnionObjectVariant0ResetPeriod.Year,
                UsageLimit = 0,
                UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        ApiEnum<string, SubscriptionProvisionResponseDataStatus> expectedStatus =
            SubscriptionProvisionResponseDataStatus.Success;
        SubscriptionProvisionResponseDataSubscription expectedSubscription = new()
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection =
                SubscriptionProvisionResponseDataSubscriptionPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionProvisionResponseDataSubscriptionPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionProvisionResponseDataSubscriptionStatus.PaymentPending,
            Addons = [new() { ID = "id", Quantity = 0 }],
            BillingCycleAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason =
                SubscriptionProvisionResponseDataSubscriptionCancelReason.UpgradeOrDowngrade,
            Coupons =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    Status = SubscriptionProvisionResponseDataSubscriptionCouponStatus.Active,
                    AmountsOff =
                    [
                        new()
                        {
                            Amount = 0,
                            Currency =
                                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Usd,
                        },
                    ],
                    PercentOff = 0,
                },
            ],
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FutureUpdates =
            [
                new()
                {
                    ScheduledExecutionTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ScheduleStatus =
                        SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus.PendingPayment,
                    SubscriptionScheduleType =
                        SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.Downgrade,
                    TargetPackage = new("id"),
                },
            ],
            LatestInvoice = new()
            {
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RequiresAction = true,
                Status = SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus.Open,
                AmountDue = 0,
                BillingReason =
                    SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason.BillingCycle,
                Currency = "currency",
                PdfUrl = "pdfUrl",
                Total = 0,
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MinimumSpend = new()
            {
                Amount = 0,
                Currency = SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Usd,
            },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod =
                SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.Charge,
            Prices =
            [
                new()
                {
                    AddonID = "addonId",
                    Amount = 0,
                    BaseCharge = true,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    Currency = SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Usd,
                    FeatureID = "featureId",
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency =
                                    SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency =
                                    SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            ResourceID = "resourceId",
            SubscriptionEntitlements =
            [
                new()
                {
                    ID = "id",
                    Type =
                        SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementType.Feature,
                },
            ],
            Trial = new(
                SubscriptionProvisionResponseDataSubscriptionTrialTrialEndBehavior.ConvertToPaid
            ),
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string expectedCheckoutBillingID = "checkoutBillingId";
        string expectedCheckoutUrl = "checkoutUrl";
        bool expectedIsScheduled = true;

        Assert.Equal(expectedID, model.ID);
        Assert.NotNull(model.Entitlements);
        Assert.Equal(expectedEntitlements.Count, model.Entitlements.Count);
        for (int i = 0; i < expectedEntitlements.Count; i++)
        {
            Assert.Equal(expectedEntitlements[i], model.Entitlements[i]);
        }
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedSubscription, model.Subscription);
        Assert.Equal(expectedCheckoutBillingID, model.CheckoutBillingID);
        Assert.Equal(expectedCheckoutUrl, model.CheckoutUrl);
        Assert.Equal(expectedIsScheduled, model.IsScheduled);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionProvisionResponseData
        {
            ID = "id",
            Entitlements =
            [
                new UnionObjectVariant0()
                {
                    AccessDeniedReason = AccessDeniedReason.FeatureNotFound,
                    IsGranted = true,
                    Type = UnionObjectVariant0Type.Feature,
                    CurrentUsage = 0,
                    EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Feature = new()
                    {
                        DisplayName = "displayName",
                        FeatureStatus = FeatureStatus.New,
                        FeatureType = FeatureType.Boolean,
                        RefID = "refId",
                    },
                    HasUnlimitedUsage = true,
                    ResetPeriod = UnionObjectVariant0ResetPeriod.Year,
                    UsageLimit = 0,
                    UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Status = SubscriptionProvisionResponseDataStatus.Success,
            Subscription = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customerId",
                PaymentCollection =
                    SubscriptionProvisionResponseDataSubscriptionPaymentCollection.NotRequired,
                PlanID = "planId",
                PricingType = SubscriptionProvisionResponseDataSubscriptionPricingType.Free,
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = SubscriptionProvisionResponseDataSubscriptionStatus.PaymentPending,
                Addons = [new() { ID = "id", Quantity = 0 }],
                BillingCycleAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Budget = new() { HasSoftLimit = true, Limit = 0 },
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason =
                    SubscriptionProvisionResponseDataSubscriptionCancelReason.UpgradeOrDowngrade,
                Coupons =
                [
                    new()
                    {
                        ID = "id",
                        Name = "name",
                        Status = SubscriptionProvisionResponseDataSubscriptionCouponStatus.Active,
                        AmountsOff =
                        [
                            new()
                            {
                                Amount = 0,
                                Currency =
                                    SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Usd,
                            },
                        ],
                        PercentOff = 0,
                    },
                ],
                CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FutureUpdates =
                [
                    new()
                    {
                        ScheduledExecutionTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ScheduleStatus =
                            SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus.PendingPayment,
                        SubscriptionScheduleType =
                            SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.Downgrade,
                        TargetPackage = new("id"),
                    },
                ],
                LatestInvoice = new()
                {
                    BillingID = "billingId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    RequiresAction = true,
                    Status = SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus.Open,
                    AmountDue = 0,
                    BillingReason =
                        SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason.BillingCycle,
                    Currency = "currency",
                    PdfUrl = "pdfUrl",
                    Total = 0,
                },
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MinimumSpend = new()
                {
                    Amount = 0,
                    Currency =
                        SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Usd,
                },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod =
                    SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.Charge,
                Prices =
                [
                    new()
                    {
                        AddonID = "addonId",
                        Amount = 0,
                        BaseCharge = true,
                        BillingCountryCode = "billingCountryCode",
                        BlockSize = 0,
                        Currency = SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Usd,
                        FeatureID = "featureId",
                        Tiers =
                        [
                            new()
                            {
                                FlatPrice = new()
                                {
                                    Amount = 0,
                                    Currency =
                                        SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                                },
                                UnitPrice = new()
                                {
                                    Amount = 0,
                                    Currency =
                                        SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                                },
                                UpTo = 0,
                            },
                        ],
                    },
                ],
                ResourceID = "resourceId",
                SubscriptionEntitlements =
                [
                    new()
                    {
                        ID = "id",
                        Type =
                            SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementType.Feature,
                    },
                ],
                Trial = new(
                    SubscriptionProvisionResponseDataSubscriptionTrialTrialEndBehavior.ConvertToPaid
                ),
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            CheckoutBillingID = "checkoutBillingId",
            CheckoutUrl = "checkoutUrl",
            IsScheduled = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionProvisionResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionProvisionResponseData
        {
            ID = "id",
            Entitlements =
            [
                new UnionObjectVariant0()
                {
                    AccessDeniedReason = AccessDeniedReason.FeatureNotFound,
                    IsGranted = true,
                    Type = UnionObjectVariant0Type.Feature,
                    CurrentUsage = 0,
                    EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Feature = new()
                    {
                        DisplayName = "displayName",
                        FeatureStatus = FeatureStatus.New,
                        FeatureType = FeatureType.Boolean,
                        RefID = "refId",
                    },
                    HasUnlimitedUsage = true,
                    ResetPeriod = UnionObjectVariant0ResetPeriod.Year,
                    UsageLimit = 0,
                    UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Status = SubscriptionProvisionResponseDataStatus.Success,
            Subscription = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customerId",
                PaymentCollection =
                    SubscriptionProvisionResponseDataSubscriptionPaymentCollection.NotRequired,
                PlanID = "planId",
                PricingType = SubscriptionProvisionResponseDataSubscriptionPricingType.Free,
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = SubscriptionProvisionResponseDataSubscriptionStatus.PaymentPending,
                Addons = [new() { ID = "id", Quantity = 0 }],
                BillingCycleAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Budget = new() { HasSoftLimit = true, Limit = 0 },
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason =
                    SubscriptionProvisionResponseDataSubscriptionCancelReason.UpgradeOrDowngrade,
                Coupons =
                [
                    new()
                    {
                        ID = "id",
                        Name = "name",
                        Status = SubscriptionProvisionResponseDataSubscriptionCouponStatus.Active,
                        AmountsOff =
                        [
                            new()
                            {
                                Amount = 0,
                                Currency =
                                    SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Usd,
                            },
                        ],
                        PercentOff = 0,
                    },
                ],
                CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FutureUpdates =
                [
                    new()
                    {
                        ScheduledExecutionTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ScheduleStatus =
                            SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus.PendingPayment,
                        SubscriptionScheduleType =
                            SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.Downgrade,
                        TargetPackage = new("id"),
                    },
                ],
                LatestInvoice = new()
                {
                    BillingID = "billingId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    RequiresAction = true,
                    Status = SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus.Open,
                    AmountDue = 0,
                    BillingReason =
                        SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason.BillingCycle,
                    Currency = "currency",
                    PdfUrl = "pdfUrl",
                    Total = 0,
                },
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MinimumSpend = new()
                {
                    Amount = 0,
                    Currency =
                        SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Usd,
                },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod =
                    SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.Charge,
                Prices =
                [
                    new()
                    {
                        AddonID = "addonId",
                        Amount = 0,
                        BaseCharge = true,
                        BillingCountryCode = "billingCountryCode",
                        BlockSize = 0,
                        Currency = SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Usd,
                        FeatureID = "featureId",
                        Tiers =
                        [
                            new()
                            {
                                FlatPrice = new()
                                {
                                    Amount = 0,
                                    Currency =
                                        SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                                },
                                UnitPrice = new()
                                {
                                    Amount = 0,
                                    Currency =
                                        SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                                },
                                UpTo = 0,
                            },
                        ],
                    },
                ],
                ResourceID = "resourceId",
                SubscriptionEntitlements =
                [
                    new()
                    {
                        ID = "id",
                        Type =
                            SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementType.Feature,
                    },
                ],
                Trial = new(
                    SubscriptionProvisionResponseDataSubscriptionTrialTrialEndBehavior.ConvertToPaid
                ),
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            CheckoutBillingID = "checkoutBillingId",
            CheckoutUrl = "checkoutUrl",
            IsScheduled = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionProvisionResponseData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        List<SubscriptionProvisionResponseDataEntitlement> expectedEntitlements =
        [
            new UnionObjectVariant0()
            {
                AccessDeniedReason = AccessDeniedReason.FeatureNotFound,
                IsGranted = true,
                Type = UnionObjectVariant0Type.Feature,
                CurrentUsage = 0,
                EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Feature = new()
                {
                    DisplayName = "displayName",
                    FeatureStatus = FeatureStatus.New,
                    FeatureType = FeatureType.Boolean,
                    RefID = "refId",
                },
                HasUnlimitedUsage = true,
                ResetPeriod = UnionObjectVariant0ResetPeriod.Year,
                UsageLimit = 0,
                UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        ApiEnum<string, SubscriptionProvisionResponseDataStatus> expectedStatus =
            SubscriptionProvisionResponseDataStatus.Success;
        SubscriptionProvisionResponseDataSubscription expectedSubscription = new()
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection =
                SubscriptionProvisionResponseDataSubscriptionPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionProvisionResponseDataSubscriptionPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionProvisionResponseDataSubscriptionStatus.PaymentPending,
            Addons = [new() { ID = "id", Quantity = 0 }],
            BillingCycleAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason =
                SubscriptionProvisionResponseDataSubscriptionCancelReason.UpgradeOrDowngrade,
            Coupons =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    Status = SubscriptionProvisionResponseDataSubscriptionCouponStatus.Active,
                    AmountsOff =
                    [
                        new()
                        {
                            Amount = 0,
                            Currency =
                                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Usd,
                        },
                    ],
                    PercentOff = 0,
                },
            ],
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FutureUpdates =
            [
                new()
                {
                    ScheduledExecutionTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ScheduleStatus =
                        SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus.PendingPayment,
                    SubscriptionScheduleType =
                        SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.Downgrade,
                    TargetPackage = new("id"),
                },
            ],
            LatestInvoice = new()
            {
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RequiresAction = true,
                Status = SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus.Open,
                AmountDue = 0,
                BillingReason =
                    SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason.BillingCycle,
                Currency = "currency",
                PdfUrl = "pdfUrl",
                Total = 0,
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MinimumSpend = new()
            {
                Amount = 0,
                Currency = SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Usd,
            },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod =
                SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.Charge,
            Prices =
            [
                new()
                {
                    AddonID = "addonId",
                    Amount = 0,
                    BaseCharge = true,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    Currency = SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Usd,
                    FeatureID = "featureId",
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency =
                                    SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency =
                                    SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            ResourceID = "resourceId",
            SubscriptionEntitlements =
            [
                new()
                {
                    ID = "id",
                    Type =
                        SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementType.Feature,
                },
            ],
            Trial = new(
                SubscriptionProvisionResponseDataSubscriptionTrialTrialEndBehavior.ConvertToPaid
            ),
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string expectedCheckoutBillingID = "checkoutBillingId";
        string expectedCheckoutUrl = "checkoutUrl";
        bool expectedIsScheduled = true;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.NotNull(deserialized.Entitlements);
        Assert.Equal(expectedEntitlements.Count, deserialized.Entitlements.Count);
        for (int i = 0; i < expectedEntitlements.Count; i++)
        {
            Assert.Equal(expectedEntitlements[i], deserialized.Entitlements[i]);
        }
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedSubscription, deserialized.Subscription);
        Assert.Equal(expectedCheckoutBillingID, deserialized.CheckoutBillingID);
        Assert.Equal(expectedCheckoutUrl, deserialized.CheckoutUrl);
        Assert.Equal(expectedIsScheduled, deserialized.IsScheduled);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionProvisionResponseData
        {
            ID = "id",
            Entitlements =
            [
                new UnionObjectVariant0()
                {
                    AccessDeniedReason = AccessDeniedReason.FeatureNotFound,
                    IsGranted = true,
                    Type = UnionObjectVariant0Type.Feature,
                    CurrentUsage = 0,
                    EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Feature = new()
                    {
                        DisplayName = "displayName",
                        FeatureStatus = FeatureStatus.New,
                        FeatureType = FeatureType.Boolean,
                        RefID = "refId",
                    },
                    HasUnlimitedUsage = true,
                    ResetPeriod = UnionObjectVariant0ResetPeriod.Year,
                    UsageLimit = 0,
                    UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Status = SubscriptionProvisionResponseDataStatus.Success,
            Subscription = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customerId",
                PaymentCollection =
                    SubscriptionProvisionResponseDataSubscriptionPaymentCollection.NotRequired,
                PlanID = "planId",
                PricingType = SubscriptionProvisionResponseDataSubscriptionPricingType.Free,
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = SubscriptionProvisionResponseDataSubscriptionStatus.PaymentPending,
                Addons = [new() { ID = "id", Quantity = 0 }],
                BillingCycleAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Budget = new() { HasSoftLimit = true, Limit = 0 },
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason =
                    SubscriptionProvisionResponseDataSubscriptionCancelReason.UpgradeOrDowngrade,
                Coupons =
                [
                    new()
                    {
                        ID = "id",
                        Name = "name",
                        Status = SubscriptionProvisionResponseDataSubscriptionCouponStatus.Active,
                        AmountsOff =
                        [
                            new()
                            {
                                Amount = 0,
                                Currency =
                                    SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Usd,
                            },
                        ],
                        PercentOff = 0,
                    },
                ],
                CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FutureUpdates =
                [
                    new()
                    {
                        ScheduledExecutionTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ScheduleStatus =
                            SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus.PendingPayment,
                        SubscriptionScheduleType =
                            SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.Downgrade,
                        TargetPackage = new("id"),
                    },
                ],
                LatestInvoice = new()
                {
                    BillingID = "billingId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    RequiresAction = true,
                    Status = SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus.Open,
                    AmountDue = 0,
                    BillingReason =
                        SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason.BillingCycle,
                    Currency = "currency",
                    PdfUrl = "pdfUrl",
                    Total = 0,
                },
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MinimumSpend = new()
                {
                    Amount = 0,
                    Currency =
                        SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Usd,
                },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod =
                    SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.Charge,
                Prices =
                [
                    new()
                    {
                        AddonID = "addonId",
                        Amount = 0,
                        BaseCharge = true,
                        BillingCountryCode = "billingCountryCode",
                        BlockSize = 0,
                        Currency = SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Usd,
                        FeatureID = "featureId",
                        Tiers =
                        [
                            new()
                            {
                                FlatPrice = new()
                                {
                                    Amount = 0,
                                    Currency =
                                        SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                                },
                                UnitPrice = new()
                                {
                                    Amount = 0,
                                    Currency =
                                        SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                                },
                                UpTo = 0,
                            },
                        ],
                    },
                ],
                ResourceID = "resourceId",
                SubscriptionEntitlements =
                [
                    new()
                    {
                        ID = "id",
                        Type =
                            SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementType.Feature,
                    },
                ],
                Trial = new(
                    SubscriptionProvisionResponseDataSubscriptionTrialTrialEndBehavior.ConvertToPaid
                ),
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            CheckoutBillingID = "checkoutBillingId",
            CheckoutUrl = "checkoutUrl",
            IsScheduled = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubscriptionProvisionResponseData
        {
            ID = "id",
            Entitlements =
            [
                new UnionObjectVariant0()
                {
                    AccessDeniedReason = AccessDeniedReason.FeatureNotFound,
                    IsGranted = true,
                    Type = UnionObjectVariant0Type.Feature,
                    CurrentUsage = 0,
                    EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Feature = new()
                    {
                        DisplayName = "displayName",
                        FeatureStatus = FeatureStatus.New,
                        FeatureType = FeatureType.Boolean,
                        RefID = "refId",
                    },
                    HasUnlimitedUsage = true,
                    ResetPeriod = UnionObjectVariant0ResetPeriod.Year,
                    UsageLimit = 0,
                    UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Status = SubscriptionProvisionResponseDataStatus.Success,
            Subscription = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customerId",
                PaymentCollection =
                    SubscriptionProvisionResponseDataSubscriptionPaymentCollection.NotRequired,
                PlanID = "planId",
                PricingType = SubscriptionProvisionResponseDataSubscriptionPricingType.Free,
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = SubscriptionProvisionResponseDataSubscriptionStatus.PaymentPending,
                Addons = [new() { ID = "id", Quantity = 0 }],
                BillingCycleAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Budget = new() { HasSoftLimit = true, Limit = 0 },
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason =
                    SubscriptionProvisionResponseDataSubscriptionCancelReason.UpgradeOrDowngrade,
                Coupons =
                [
                    new()
                    {
                        ID = "id",
                        Name = "name",
                        Status = SubscriptionProvisionResponseDataSubscriptionCouponStatus.Active,
                        AmountsOff =
                        [
                            new()
                            {
                                Amount = 0,
                                Currency =
                                    SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Usd,
                            },
                        ],
                        PercentOff = 0,
                    },
                ],
                CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FutureUpdates =
                [
                    new()
                    {
                        ScheduledExecutionTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ScheduleStatus =
                            SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus.PendingPayment,
                        SubscriptionScheduleType =
                            SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.Downgrade,
                        TargetPackage = new("id"),
                    },
                ],
                LatestInvoice = new()
                {
                    BillingID = "billingId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    RequiresAction = true,
                    Status = SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus.Open,
                    AmountDue = 0,
                    BillingReason =
                        SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason.BillingCycle,
                    Currency = "currency",
                    PdfUrl = "pdfUrl",
                    Total = 0,
                },
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MinimumSpend = new()
                {
                    Amount = 0,
                    Currency =
                        SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Usd,
                },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod =
                    SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.Charge,
                Prices =
                [
                    new()
                    {
                        AddonID = "addonId",
                        Amount = 0,
                        BaseCharge = true,
                        BillingCountryCode = "billingCountryCode",
                        BlockSize = 0,
                        Currency = SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Usd,
                        FeatureID = "featureId",
                        Tiers =
                        [
                            new()
                            {
                                FlatPrice = new()
                                {
                                    Amount = 0,
                                    Currency =
                                        SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                                },
                                UnitPrice = new()
                                {
                                    Amount = 0,
                                    Currency =
                                        SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                                },
                                UpTo = 0,
                            },
                        ],
                    },
                ],
                ResourceID = "resourceId",
                SubscriptionEntitlements =
                [
                    new()
                    {
                        ID = "id",
                        Type =
                            SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementType.Feature,
                    },
                ],
                Trial = new(
                    SubscriptionProvisionResponseDataSubscriptionTrialTrialEndBehavior.ConvertToPaid
                ),
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        Assert.Null(model.CheckoutBillingID);
        Assert.False(model.RawData.ContainsKey("checkoutBillingId"));
        Assert.Null(model.CheckoutUrl);
        Assert.False(model.RawData.ContainsKey("checkoutUrl"));
        Assert.Null(model.IsScheduled);
        Assert.False(model.RawData.ContainsKey("isScheduled"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SubscriptionProvisionResponseData
        {
            ID = "id",
            Entitlements =
            [
                new UnionObjectVariant0()
                {
                    AccessDeniedReason = AccessDeniedReason.FeatureNotFound,
                    IsGranted = true,
                    Type = UnionObjectVariant0Type.Feature,
                    CurrentUsage = 0,
                    EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Feature = new()
                    {
                        DisplayName = "displayName",
                        FeatureStatus = FeatureStatus.New,
                        FeatureType = FeatureType.Boolean,
                        RefID = "refId",
                    },
                    HasUnlimitedUsage = true,
                    ResetPeriod = UnionObjectVariant0ResetPeriod.Year,
                    UsageLimit = 0,
                    UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Status = SubscriptionProvisionResponseDataStatus.Success,
            Subscription = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customerId",
                PaymentCollection =
                    SubscriptionProvisionResponseDataSubscriptionPaymentCollection.NotRequired,
                PlanID = "planId",
                PricingType = SubscriptionProvisionResponseDataSubscriptionPricingType.Free,
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = SubscriptionProvisionResponseDataSubscriptionStatus.PaymentPending,
                Addons = [new() { ID = "id", Quantity = 0 }],
                BillingCycleAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Budget = new() { HasSoftLimit = true, Limit = 0 },
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason =
                    SubscriptionProvisionResponseDataSubscriptionCancelReason.UpgradeOrDowngrade,
                Coupons =
                [
                    new()
                    {
                        ID = "id",
                        Name = "name",
                        Status = SubscriptionProvisionResponseDataSubscriptionCouponStatus.Active,
                        AmountsOff =
                        [
                            new()
                            {
                                Amount = 0,
                                Currency =
                                    SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Usd,
                            },
                        ],
                        PercentOff = 0,
                    },
                ],
                CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FutureUpdates =
                [
                    new()
                    {
                        ScheduledExecutionTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ScheduleStatus =
                            SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus.PendingPayment,
                        SubscriptionScheduleType =
                            SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.Downgrade,
                        TargetPackage = new("id"),
                    },
                ],
                LatestInvoice = new()
                {
                    BillingID = "billingId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    RequiresAction = true,
                    Status = SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus.Open,
                    AmountDue = 0,
                    BillingReason =
                        SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason.BillingCycle,
                    Currency = "currency",
                    PdfUrl = "pdfUrl",
                    Total = 0,
                },
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MinimumSpend = new()
                {
                    Amount = 0,
                    Currency =
                        SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Usd,
                },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod =
                    SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.Charge,
                Prices =
                [
                    new()
                    {
                        AddonID = "addonId",
                        Amount = 0,
                        BaseCharge = true,
                        BillingCountryCode = "billingCountryCode",
                        BlockSize = 0,
                        Currency = SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Usd,
                        FeatureID = "featureId",
                        Tiers =
                        [
                            new()
                            {
                                FlatPrice = new()
                                {
                                    Amount = 0,
                                    Currency =
                                        SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                                },
                                UnitPrice = new()
                                {
                                    Amount = 0,
                                    Currency =
                                        SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                                },
                                UpTo = 0,
                            },
                        ],
                    },
                ],
                ResourceID = "resourceId",
                SubscriptionEntitlements =
                [
                    new()
                    {
                        ID = "id",
                        Type =
                            SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementType.Feature,
                    },
                ],
                Trial = new(
                    SubscriptionProvisionResponseDataSubscriptionTrialTrialEndBehavior.ConvertToPaid
                ),
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SubscriptionProvisionResponseData
        {
            ID = "id",
            Entitlements =
            [
                new UnionObjectVariant0()
                {
                    AccessDeniedReason = AccessDeniedReason.FeatureNotFound,
                    IsGranted = true,
                    Type = UnionObjectVariant0Type.Feature,
                    CurrentUsage = 0,
                    EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Feature = new()
                    {
                        DisplayName = "displayName",
                        FeatureStatus = FeatureStatus.New,
                        FeatureType = FeatureType.Boolean,
                        RefID = "refId",
                    },
                    HasUnlimitedUsage = true,
                    ResetPeriod = UnionObjectVariant0ResetPeriod.Year,
                    UsageLimit = 0,
                    UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Status = SubscriptionProvisionResponseDataStatus.Success,
            Subscription = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customerId",
                PaymentCollection =
                    SubscriptionProvisionResponseDataSubscriptionPaymentCollection.NotRequired,
                PlanID = "planId",
                PricingType = SubscriptionProvisionResponseDataSubscriptionPricingType.Free,
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = SubscriptionProvisionResponseDataSubscriptionStatus.PaymentPending,
                Addons = [new() { ID = "id", Quantity = 0 }],
                BillingCycleAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Budget = new() { HasSoftLimit = true, Limit = 0 },
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason =
                    SubscriptionProvisionResponseDataSubscriptionCancelReason.UpgradeOrDowngrade,
                Coupons =
                [
                    new()
                    {
                        ID = "id",
                        Name = "name",
                        Status = SubscriptionProvisionResponseDataSubscriptionCouponStatus.Active,
                        AmountsOff =
                        [
                            new()
                            {
                                Amount = 0,
                                Currency =
                                    SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Usd,
                            },
                        ],
                        PercentOff = 0,
                    },
                ],
                CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FutureUpdates =
                [
                    new()
                    {
                        ScheduledExecutionTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ScheduleStatus =
                            SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus.PendingPayment,
                        SubscriptionScheduleType =
                            SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.Downgrade,
                        TargetPackage = new("id"),
                    },
                ],
                LatestInvoice = new()
                {
                    BillingID = "billingId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    RequiresAction = true,
                    Status = SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus.Open,
                    AmountDue = 0,
                    BillingReason =
                        SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason.BillingCycle,
                    Currency = "currency",
                    PdfUrl = "pdfUrl",
                    Total = 0,
                },
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MinimumSpend = new()
                {
                    Amount = 0,
                    Currency =
                        SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Usd,
                },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod =
                    SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.Charge,
                Prices =
                [
                    new()
                    {
                        AddonID = "addonId",
                        Amount = 0,
                        BaseCharge = true,
                        BillingCountryCode = "billingCountryCode",
                        BlockSize = 0,
                        Currency = SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Usd,
                        FeatureID = "featureId",
                        Tiers =
                        [
                            new()
                            {
                                FlatPrice = new()
                                {
                                    Amount = 0,
                                    Currency =
                                        SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                                },
                                UnitPrice = new()
                                {
                                    Amount = 0,
                                    Currency =
                                        SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                                },
                                UpTo = 0,
                            },
                        ],
                    },
                ],
                ResourceID = "resourceId",
                SubscriptionEntitlements =
                [
                    new()
                    {
                        ID = "id",
                        Type =
                            SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementType.Feature,
                    },
                ],
                Trial = new(
                    SubscriptionProvisionResponseDataSubscriptionTrialTrialEndBehavior.ConvertToPaid
                ),
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },

            // Null should be interpreted as omitted for these properties
            CheckoutBillingID = null,
            CheckoutUrl = null,
            IsScheduled = null,
        };

        Assert.Null(model.CheckoutBillingID);
        Assert.False(model.RawData.ContainsKey("checkoutBillingId"));
        Assert.Null(model.CheckoutUrl);
        Assert.False(model.RawData.ContainsKey("checkoutUrl"));
        Assert.Null(model.IsScheduled);
        Assert.False(model.RawData.ContainsKey("isScheduled"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SubscriptionProvisionResponseData
        {
            ID = "id",
            Entitlements =
            [
                new UnionObjectVariant0()
                {
                    AccessDeniedReason = AccessDeniedReason.FeatureNotFound,
                    IsGranted = true,
                    Type = UnionObjectVariant0Type.Feature,
                    CurrentUsage = 0,
                    EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Feature = new()
                    {
                        DisplayName = "displayName",
                        FeatureStatus = FeatureStatus.New,
                        FeatureType = FeatureType.Boolean,
                        RefID = "refId",
                    },
                    HasUnlimitedUsage = true,
                    ResetPeriod = UnionObjectVariant0ResetPeriod.Year,
                    UsageLimit = 0,
                    UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Status = SubscriptionProvisionResponseDataStatus.Success,
            Subscription = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customerId",
                PaymentCollection =
                    SubscriptionProvisionResponseDataSubscriptionPaymentCollection.NotRequired,
                PlanID = "planId",
                PricingType = SubscriptionProvisionResponseDataSubscriptionPricingType.Free,
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = SubscriptionProvisionResponseDataSubscriptionStatus.PaymentPending,
                Addons = [new() { ID = "id", Quantity = 0 }],
                BillingCycleAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Budget = new() { HasSoftLimit = true, Limit = 0 },
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason =
                    SubscriptionProvisionResponseDataSubscriptionCancelReason.UpgradeOrDowngrade,
                Coupons =
                [
                    new()
                    {
                        ID = "id",
                        Name = "name",
                        Status = SubscriptionProvisionResponseDataSubscriptionCouponStatus.Active,
                        AmountsOff =
                        [
                            new()
                            {
                                Amount = 0,
                                Currency =
                                    SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Usd,
                            },
                        ],
                        PercentOff = 0,
                    },
                ],
                CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FutureUpdates =
                [
                    new()
                    {
                        ScheduledExecutionTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ScheduleStatus =
                            SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus.PendingPayment,
                        SubscriptionScheduleType =
                            SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.Downgrade,
                        TargetPackage = new("id"),
                    },
                ],
                LatestInvoice = new()
                {
                    BillingID = "billingId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    RequiresAction = true,
                    Status = SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus.Open,
                    AmountDue = 0,
                    BillingReason =
                        SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason.BillingCycle,
                    Currency = "currency",
                    PdfUrl = "pdfUrl",
                    Total = 0,
                },
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MinimumSpend = new()
                {
                    Amount = 0,
                    Currency =
                        SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Usd,
                },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod =
                    SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.Charge,
                Prices =
                [
                    new()
                    {
                        AddonID = "addonId",
                        Amount = 0,
                        BaseCharge = true,
                        BillingCountryCode = "billingCountryCode",
                        BlockSize = 0,
                        Currency = SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Usd,
                        FeatureID = "featureId",
                        Tiers =
                        [
                            new()
                            {
                                FlatPrice = new()
                                {
                                    Amount = 0,
                                    Currency =
                                        SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                                },
                                UnitPrice = new()
                                {
                                    Amount = 0,
                                    Currency =
                                        SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                                },
                                UpTo = 0,
                            },
                        ],
                    },
                ],
                ResourceID = "resourceId",
                SubscriptionEntitlements =
                [
                    new()
                    {
                        ID = "id",
                        Type =
                            SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementType.Feature,
                    },
                ],
                Trial = new(
                    SubscriptionProvisionResponseDataSubscriptionTrialTrialEndBehavior.ConvertToPaid
                ),
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },

            // Null should be interpreted as omitted for these properties
            CheckoutBillingID = null,
            CheckoutUrl = null,
            IsScheduled = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionProvisionResponseData
        {
            ID = "id",
            Entitlements =
            [
                new UnionObjectVariant0()
                {
                    AccessDeniedReason = AccessDeniedReason.FeatureNotFound,
                    IsGranted = true,
                    Type = UnionObjectVariant0Type.Feature,
                    CurrentUsage = 0,
                    EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Feature = new()
                    {
                        DisplayName = "displayName",
                        FeatureStatus = FeatureStatus.New,
                        FeatureType = FeatureType.Boolean,
                        RefID = "refId",
                    },
                    HasUnlimitedUsage = true,
                    ResetPeriod = UnionObjectVariant0ResetPeriod.Year,
                    UsageLimit = 0,
                    UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Status = SubscriptionProvisionResponseDataStatus.Success,
            Subscription = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customerId",
                PaymentCollection =
                    SubscriptionProvisionResponseDataSubscriptionPaymentCollection.NotRequired,
                PlanID = "planId",
                PricingType = SubscriptionProvisionResponseDataSubscriptionPricingType.Free,
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = SubscriptionProvisionResponseDataSubscriptionStatus.PaymentPending,
                Addons = [new() { ID = "id", Quantity = 0 }],
                BillingCycleAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Budget = new() { HasSoftLimit = true, Limit = 0 },
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason =
                    SubscriptionProvisionResponseDataSubscriptionCancelReason.UpgradeOrDowngrade,
                Coupons =
                [
                    new()
                    {
                        ID = "id",
                        Name = "name",
                        Status = SubscriptionProvisionResponseDataSubscriptionCouponStatus.Active,
                        AmountsOff =
                        [
                            new()
                            {
                                Amount = 0,
                                Currency =
                                    SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Usd,
                            },
                        ],
                        PercentOff = 0,
                    },
                ],
                CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FutureUpdates =
                [
                    new()
                    {
                        ScheduledExecutionTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ScheduleStatus =
                            SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus.PendingPayment,
                        SubscriptionScheduleType =
                            SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.Downgrade,
                        TargetPackage = new("id"),
                    },
                ],
                LatestInvoice = new()
                {
                    BillingID = "billingId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    RequiresAction = true,
                    Status = SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus.Open,
                    AmountDue = 0,
                    BillingReason =
                        SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason.BillingCycle,
                    Currency = "currency",
                    PdfUrl = "pdfUrl",
                    Total = 0,
                },
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MinimumSpend = new()
                {
                    Amount = 0,
                    Currency =
                        SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Usd,
                },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod =
                    SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.Charge,
                Prices =
                [
                    new()
                    {
                        AddonID = "addonId",
                        Amount = 0,
                        BaseCharge = true,
                        BillingCountryCode = "billingCountryCode",
                        BlockSize = 0,
                        Currency = SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Usd,
                        FeatureID = "featureId",
                        Tiers =
                        [
                            new()
                            {
                                FlatPrice = new()
                                {
                                    Amount = 0,
                                    Currency =
                                        SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                                },
                                UnitPrice = new()
                                {
                                    Amount = 0,
                                    Currency =
                                        SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                                },
                                UpTo = 0,
                            },
                        ],
                    },
                ],
                ResourceID = "resourceId",
                SubscriptionEntitlements =
                [
                    new()
                    {
                        ID = "id",
                        Type =
                            SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementType.Feature,
                    },
                ],
                Trial = new(
                    SubscriptionProvisionResponseDataSubscriptionTrialTrialEndBehavior.ConvertToPaid
                ),
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            CheckoutBillingID = "checkoutBillingId",
            CheckoutUrl = "checkoutUrl",
            IsScheduled = true,
        };

        SubscriptionProvisionResponseData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionProvisionResponseDataEntitlementTest : TestBase
{
    [Fact]
    public void UnionObjectVariant0ValidationWorks()
    {
        SubscriptionProvisionResponseDataEntitlement value = new UnionObjectVariant0()
        {
            AccessDeniedReason = AccessDeniedReason.FeatureNotFound,
            IsGranted = true,
            Type = UnionObjectVariant0Type.Feature,
            CurrentUsage = 0,
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Feature = new()
            {
                DisplayName = "displayName",
                FeatureStatus = FeatureStatus.New,
                FeatureType = FeatureType.Boolean,
                RefID = "refId",
            },
            HasUnlimitedUsage = true,
            ResetPeriod = UnionObjectVariant0ResetPeriod.Year,
            UsageLimit = 0,
            UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        value.Validate();
    }

    [Fact]
    public void UnionObjectVariant1ValidationWorks()
    {
        SubscriptionProvisionResponseDataEntitlement value = new UnionObjectVariant1()
        {
            AccessDeniedReason = UnionObjectVariant1AccessDeniedReason.FeatureNotFound,
            Currency = new()
            {
                CurrencyID = "currencyId",
                DisplayName = "displayName",
                AdditionalMetaData = JsonSerializer.Deserialize<JsonElement>("{}"),
                Description = "description",
                UnitPlural = "unitPlural",
                UnitSingular = "unitSingular",
            },
            CurrentUsage = 0,
            IsGranted = true,
            Type = UnionObjectVariant1Type.Credit,
            UsageLimit = 0,
            UsageUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        value.Validate();
    }

    [Fact]
    public void UnionObjectVariant0SerializationRoundtripWorks()
    {
        SubscriptionProvisionResponseDataEntitlement value = new UnionObjectVariant0()
        {
            AccessDeniedReason = AccessDeniedReason.FeatureNotFound,
            IsGranted = true,
            Type = UnionObjectVariant0Type.Feature,
            CurrentUsage = 0,
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Feature = new()
            {
                DisplayName = "displayName",
                FeatureStatus = FeatureStatus.New,
                FeatureType = FeatureType.Boolean,
                RefID = "refId",
            },
            HasUnlimitedUsage = true,
            ResetPeriod = UnionObjectVariant0ResetPeriod.Year,
            UsageLimit = 0,
            UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionProvisionResponseDataEntitlement>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnionObjectVariant1SerializationRoundtripWorks()
    {
        SubscriptionProvisionResponseDataEntitlement value = new UnionObjectVariant1()
        {
            AccessDeniedReason = UnionObjectVariant1AccessDeniedReason.FeatureNotFound,
            Currency = new()
            {
                CurrencyID = "currencyId",
                DisplayName = "displayName",
                AdditionalMetaData = JsonSerializer.Deserialize<JsonElement>("{}"),
                Description = "description",
                UnitPlural = "unitPlural",
                UnitSingular = "unitSingular",
            },
            CurrentUsage = 0,
            IsGranted = true,
            Type = UnionObjectVariant1Type.Credit,
            UsageLimit = 0,
            UsageUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionProvisionResponseDataEntitlement>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class UnionObjectVariant0Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UnionObjectVariant0
        {
            AccessDeniedReason = AccessDeniedReason.FeatureNotFound,
            IsGranted = true,
            Type = UnionObjectVariant0Type.Feature,
            CurrentUsage = 0,
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Feature = new()
            {
                DisplayName = "displayName",
                FeatureStatus = FeatureStatus.New,
                FeatureType = FeatureType.Boolean,
                RefID = "refId",
            },
            HasUnlimitedUsage = true,
            ResetPeriod = UnionObjectVariant0ResetPeriod.Year,
            UsageLimit = 0,
            UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        ApiEnum<string, AccessDeniedReason> expectedAccessDeniedReason =
            AccessDeniedReason.FeatureNotFound;
        bool expectedIsGranted = true;
        ApiEnum<string, UnionObjectVariant0Type> expectedType = UnionObjectVariant0Type.Feature;
        double expectedCurrentUsage = 0;
        DateTimeOffset expectedEntitlementUpdatedAt = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        UnionObjectVariant0Feature expectedFeature = new()
        {
            DisplayName = "displayName",
            FeatureStatus = FeatureStatus.New,
            FeatureType = FeatureType.Boolean,
            RefID = "refId",
        };
        bool expectedHasUnlimitedUsage = true;
        ApiEnum<string, UnionObjectVariant0ResetPeriod> expectedResetPeriod =
            UnionObjectVariant0ResetPeriod.Year;
        double expectedUsageLimit = 0;
        DateTimeOffset expectedUsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedUsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedUsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedAccessDeniedReason, model.AccessDeniedReason);
        Assert.Equal(expectedIsGranted, model.IsGranted);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedCurrentUsage, model.CurrentUsage);
        Assert.Equal(expectedEntitlementUpdatedAt, model.EntitlementUpdatedAt);
        Assert.Equal(expectedFeature, model.Feature);
        Assert.Equal(expectedHasUnlimitedUsage, model.HasUnlimitedUsage);
        Assert.Equal(expectedResetPeriod, model.ResetPeriod);
        Assert.Equal(expectedUsageLimit, model.UsageLimit);
        Assert.Equal(expectedUsagePeriodAnchor, model.UsagePeriodAnchor);
        Assert.Equal(expectedUsagePeriodEnd, model.UsagePeriodEnd);
        Assert.Equal(expectedUsagePeriodStart, model.UsagePeriodStart);
        Assert.Equal(expectedValidUntil, model.ValidUntil);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UnionObjectVariant0
        {
            AccessDeniedReason = AccessDeniedReason.FeatureNotFound,
            IsGranted = true,
            Type = UnionObjectVariant0Type.Feature,
            CurrentUsage = 0,
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Feature = new()
            {
                DisplayName = "displayName",
                FeatureStatus = FeatureStatus.New,
                FeatureType = FeatureType.Boolean,
                RefID = "refId",
            },
            HasUnlimitedUsage = true,
            ResetPeriod = UnionObjectVariant0ResetPeriod.Year,
            UsageLimit = 0,
            UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnionObjectVariant0>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UnionObjectVariant0
        {
            AccessDeniedReason = AccessDeniedReason.FeatureNotFound,
            IsGranted = true,
            Type = UnionObjectVariant0Type.Feature,
            CurrentUsage = 0,
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Feature = new()
            {
                DisplayName = "displayName",
                FeatureStatus = FeatureStatus.New,
                FeatureType = FeatureType.Boolean,
                RefID = "refId",
            },
            HasUnlimitedUsage = true,
            ResetPeriod = UnionObjectVariant0ResetPeriod.Year,
            UsageLimit = 0,
            UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnionObjectVariant0>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, AccessDeniedReason> expectedAccessDeniedReason =
            AccessDeniedReason.FeatureNotFound;
        bool expectedIsGranted = true;
        ApiEnum<string, UnionObjectVariant0Type> expectedType = UnionObjectVariant0Type.Feature;
        double expectedCurrentUsage = 0;
        DateTimeOffset expectedEntitlementUpdatedAt = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        UnionObjectVariant0Feature expectedFeature = new()
        {
            DisplayName = "displayName",
            FeatureStatus = FeatureStatus.New,
            FeatureType = FeatureType.Boolean,
            RefID = "refId",
        };
        bool expectedHasUnlimitedUsage = true;
        ApiEnum<string, UnionObjectVariant0ResetPeriod> expectedResetPeriod =
            UnionObjectVariant0ResetPeriod.Year;
        double expectedUsageLimit = 0;
        DateTimeOffset expectedUsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedUsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedUsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedAccessDeniedReason, deserialized.AccessDeniedReason);
        Assert.Equal(expectedIsGranted, deserialized.IsGranted);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedCurrentUsage, deserialized.CurrentUsage);
        Assert.Equal(expectedEntitlementUpdatedAt, deserialized.EntitlementUpdatedAt);
        Assert.Equal(expectedFeature, deserialized.Feature);
        Assert.Equal(expectedHasUnlimitedUsage, deserialized.HasUnlimitedUsage);
        Assert.Equal(expectedResetPeriod, deserialized.ResetPeriod);
        Assert.Equal(expectedUsageLimit, deserialized.UsageLimit);
        Assert.Equal(expectedUsagePeriodAnchor, deserialized.UsagePeriodAnchor);
        Assert.Equal(expectedUsagePeriodEnd, deserialized.UsagePeriodEnd);
        Assert.Equal(expectedUsagePeriodStart, deserialized.UsagePeriodStart);
        Assert.Equal(expectedValidUntil, deserialized.ValidUntil);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UnionObjectVariant0
        {
            AccessDeniedReason = AccessDeniedReason.FeatureNotFound,
            IsGranted = true,
            Type = UnionObjectVariant0Type.Feature,
            CurrentUsage = 0,
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Feature = new()
            {
                DisplayName = "displayName",
                FeatureStatus = FeatureStatus.New,
                FeatureType = FeatureType.Boolean,
                RefID = "refId",
            },
            HasUnlimitedUsage = true,
            ResetPeriod = UnionObjectVariant0ResetPeriod.Year,
            UsageLimit = 0,
            UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UnionObjectVariant0
        {
            AccessDeniedReason = AccessDeniedReason.FeatureNotFound,
            IsGranted = true,
            Type = UnionObjectVariant0Type.Feature,
            ResetPeriod = UnionObjectVariant0ResetPeriod.Year,
            UsageLimit = 0,
        };

        Assert.Null(model.CurrentUsage);
        Assert.False(model.RawData.ContainsKey("currentUsage"));
        Assert.Null(model.EntitlementUpdatedAt);
        Assert.False(model.RawData.ContainsKey("entitlementUpdatedAt"));
        Assert.Null(model.Feature);
        Assert.False(model.RawData.ContainsKey("feature"));
        Assert.Null(model.HasUnlimitedUsage);
        Assert.False(model.RawData.ContainsKey("hasUnlimitedUsage"));
        Assert.Null(model.UsagePeriodAnchor);
        Assert.False(model.RawData.ContainsKey("usagePeriodAnchor"));
        Assert.Null(model.UsagePeriodEnd);
        Assert.False(model.RawData.ContainsKey("usagePeriodEnd"));
        Assert.Null(model.UsagePeriodStart);
        Assert.False(model.RawData.ContainsKey("usagePeriodStart"));
        Assert.Null(model.ValidUntil);
        Assert.False(model.RawData.ContainsKey("validUntil"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new UnionObjectVariant0
        {
            AccessDeniedReason = AccessDeniedReason.FeatureNotFound,
            IsGranted = true,
            Type = UnionObjectVariant0Type.Feature,
            ResetPeriod = UnionObjectVariant0ResetPeriod.Year,
            UsageLimit = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UnionObjectVariant0
        {
            AccessDeniedReason = AccessDeniedReason.FeatureNotFound,
            IsGranted = true,
            Type = UnionObjectVariant0Type.Feature,
            ResetPeriod = UnionObjectVariant0ResetPeriod.Year,
            UsageLimit = 0,

            // Null should be interpreted as omitted for these properties
            CurrentUsage = null,
            EntitlementUpdatedAt = null,
            Feature = null,
            HasUnlimitedUsage = null,
            UsagePeriodAnchor = null,
            UsagePeriodEnd = null,
            UsagePeriodStart = null,
            ValidUntil = null,
        };

        Assert.Null(model.CurrentUsage);
        Assert.False(model.RawData.ContainsKey("currentUsage"));
        Assert.Null(model.EntitlementUpdatedAt);
        Assert.False(model.RawData.ContainsKey("entitlementUpdatedAt"));
        Assert.Null(model.Feature);
        Assert.False(model.RawData.ContainsKey("feature"));
        Assert.Null(model.HasUnlimitedUsage);
        Assert.False(model.RawData.ContainsKey("hasUnlimitedUsage"));
        Assert.Null(model.UsagePeriodAnchor);
        Assert.False(model.RawData.ContainsKey("usagePeriodAnchor"));
        Assert.Null(model.UsagePeriodEnd);
        Assert.False(model.RawData.ContainsKey("usagePeriodEnd"));
        Assert.Null(model.UsagePeriodStart);
        Assert.False(model.RawData.ContainsKey("usagePeriodStart"));
        Assert.Null(model.ValidUntil);
        Assert.False(model.RawData.ContainsKey("validUntil"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UnionObjectVariant0
        {
            AccessDeniedReason = AccessDeniedReason.FeatureNotFound,
            IsGranted = true,
            Type = UnionObjectVariant0Type.Feature,
            ResetPeriod = UnionObjectVariant0ResetPeriod.Year,
            UsageLimit = 0,

            // Null should be interpreted as omitted for these properties
            CurrentUsage = null,
            EntitlementUpdatedAt = null,
            Feature = null,
            HasUnlimitedUsage = null,
            UsagePeriodAnchor = null,
            UsagePeriodEnd = null,
            UsagePeriodStart = null,
            ValidUntil = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UnionObjectVariant0
        {
            AccessDeniedReason = AccessDeniedReason.FeatureNotFound,
            IsGranted = true,
            Type = UnionObjectVariant0Type.Feature,
            CurrentUsage = 0,
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Feature = new()
            {
                DisplayName = "displayName",
                FeatureStatus = FeatureStatus.New,
                FeatureType = FeatureType.Boolean,
                RefID = "refId",
            },
            HasUnlimitedUsage = true,
            UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.ResetPeriod);
        Assert.False(model.RawData.ContainsKey("resetPeriod"));
        Assert.Null(model.UsageLimit);
        Assert.False(model.RawData.ContainsKey("usageLimit"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new UnionObjectVariant0
        {
            AccessDeniedReason = AccessDeniedReason.FeatureNotFound,
            IsGranted = true,
            Type = UnionObjectVariant0Type.Feature,
            CurrentUsage = 0,
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Feature = new()
            {
                DisplayName = "displayName",
                FeatureStatus = FeatureStatus.New,
                FeatureType = FeatureType.Boolean,
                RefID = "refId",
            },
            HasUnlimitedUsage = true,
            UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new UnionObjectVariant0
        {
            AccessDeniedReason = AccessDeniedReason.FeatureNotFound,
            IsGranted = true,
            Type = UnionObjectVariant0Type.Feature,
            CurrentUsage = 0,
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Feature = new()
            {
                DisplayName = "displayName",
                FeatureStatus = FeatureStatus.New,
                FeatureType = FeatureType.Boolean,
                RefID = "refId",
            },
            HasUnlimitedUsage = true,
            UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            ResetPeriod = null,
            UsageLimit = null,
        };

        Assert.Null(model.ResetPeriod);
        Assert.True(model.RawData.ContainsKey("resetPeriod"));
        Assert.Null(model.UsageLimit);
        Assert.True(model.RawData.ContainsKey("usageLimit"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UnionObjectVariant0
        {
            AccessDeniedReason = AccessDeniedReason.FeatureNotFound,
            IsGranted = true,
            Type = UnionObjectVariant0Type.Feature,
            CurrentUsage = 0,
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Feature = new()
            {
                DisplayName = "displayName",
                FeatureStatus = FeatureStatus.New,
                FeatureType = FeatureType.Boolean,
                RefID = "refId",
            },
            HasUnlimitedUsage = true,
            UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            ResetPeriod = null,
            UsageLimit = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UnionObjectVariant0
        {
            AccessDeniedReason = AccessDeniedReason.FeatureNotFound,
            IsGranted = true,
            Type = UnionObjectVariant0Type.Feature,
            CurrentUsage = 0,
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Feature = new()
            {
                DisplayName = "displayName",
                FeatureStatus = FeatureStatus.New,
                FeatureType = FeatureType.Boolean,
                RefID = "refId",
            },
            HasUnlimitedUsage = true,
            ResetPeriod = UnionObjectVariant0ResetPeriod.Year,
            UsageLimit = 0,
            UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        UnionObjectVariant0 copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AccessDeniedReasonTest : TestBase
{
    [Theory]
    [InlineData(AccessDeniedReason.FeatureNotFound)]
    [InlineData(AccessDeniedReason.CustomerNotFound)]
    [InlineData(AccessDeniedReason.CustomerIsArchived)]
    [InlineData(AccessDeniedReason.CustomerResourceNotFound)]
    [InlineData(AccessDeniedReason.NoActiveSubscription)]
    [InlineData(AccessDeniedReason.NoFeatureEntitlementInSubscription)]
    [InlineData(AccessDeniedReason.RequestedUsageExceedingLimit)]
    [InlineData(AccessDeniedReason.RequestedValuesMismatch)]
    [InlineData(AccessDeniedReason.BudgetExceeded)]
    [InlineData(AccessDeniedReason.Unknown)]
    [InlineData(AccessDeniedReason.FeatureTypeMismatch)]
    [InlineData(AccessDeniedReason.Revoked)]
    [InlineData(AccessDeniedReason.InsufficientCredits)]
    [InlineData(AccessDeniedReason.EntitlementNotFound)]
    public void Validation_Works(AccessDeniedReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccessDeniedReason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AccessDeniedReason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AccessDeniedReason.FeatureNotFound)]
    [InlineData(AccessDeniedReason.CustomerNotFound)]
    [InlineData(AccessDeniedReason.CustomerIsArchived)]
    [InlineData(AccessDeniedReason.CustomerResourceNotFound)]
    [InlineData(AccessDeniedReason.NoActiveSubscription)]
    [InlineData(AccessDeniedReason.NoFeatureEntitlementInSubscription)]
    [InlineData(AccessDeniedReason.RequestedUsageExceedingLimit)]
    [InlineData(AccessDeniedReason.RequestedValuesMismatch)]
    [InlineData(AccessDeniedReason.BudgetExceeded)]
    [InlineData(AccessDeniedReason.Unknown)]
    [InlineData(AccessDeniedReason.FeatureTypeMismatch)]
    [InlineData(AccessDeniedReason.Revoked)]
    [InlineData(AccessDeniedReason.InsufficientCredits)]
    [InlineData(AccessDeniedReason.EntitlementNotFound)]
    public void SerializationRoundtrip_Works(AccessDeniedReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccessDeniedReason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AccessDeniedReason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AccessDeniedReason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AccessDeniedReason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class UnionObjectVariant0TypeTest : TestBase
{
    [Theory]
    [InlineData(UnionObjectVariant0Type.Feature)]
    public void Validation_Works(UnionObjectVariant0Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UnionObjectVariant0Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UnionObjectVariant0Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UnionObjectVariant0Type.Feature)]
    public void SerializationRoundtrip_Works(UnionObjectVariant0Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UnionObjectVariant0Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UnionObjectVariant0Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UnionObjectVariant0Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UnionObjectVariant0Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class UnionObjectVariant0FeatureTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UnionObjectVariant0Feature
        {
            DisplayName = "displayName",
            FeatureStatus = FeatureStatus.New,
            FeatureType = FeatureType.Boolean,
            RefID = "refId",
        };

        string expectedDisplayName = "displayName";
        ApiEnum<string, FeatureStatus> expectedFeatureStatus = FeatureStatus.New;
        ApiEnum<string, FeatureType> expectedFeatureType = FeatureType.Boolean;
        string expectedRefID = "refId";

        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.Equal(expectedFeatureStatus, model.FeatureStatus);
        Assert.Equal(expectedFeatureType, model.FeatureType);
        Assert.Equal(expectedRefID, model.RefID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UnionObjectVariant0Feature
        {
            DisplayName = "displayName",
            FeatureStatus = FeatureStatus.New,
            FeatureType = FeatureType.Boolean,
            RefID = "refId",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnionObjectVariant0Feature>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UnionObjectVariant0Feature
        {
            DisplayName = "displayName",
            FeatureStatus = FeatureStatus.New,
            FeatureType = FeatureType.Boolean,
            RefID = "refId",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnionObjectVariant0Feature>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedDisplayName = "displayName";
        ApiEnum<string, FeatureStatus> expectedFeatureStatus = FeatureStatus.New;
        ApiEnum<string, FeatureType> expectedFeatureType = FeatureType.Boolean;
        string expectedRefID = "refId";

        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
        Assert.Equal(expectedFeatureStatus, deserialized.FeatureStatus);
        Assert.Equal(expectedFeatureType, deserialized.FeatureType);
        Assert.Equal(expectedRefID, deserialized.RefID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UnionObjectVariant0Feature
        {
            DisplayName = "displayName",
            FeatureStatus = FeatureStatus.New,
            FeatureType = FeatureType.Boolean,
            RefID = "refId",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UnionObjectVariant0Feature
        {
            DisplayName = "displayName",
            FeatureStatus = FeatureStatus.New,
            FeatureType = FeatureType.Boolean,
            RefID = "refId",
        };

        UnionObjectVariant0Feature copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FeatureStatusTest : TestBase
{
    [Theory]
    [InlineData(FeatureStatus.New)]
    [InlineData(FeatureStatus.Suspended)]
    [InlineData(FeatureStatus.Active)]
    public void Validation_Works(FeatureStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FeatureStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FeatureStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FeatureStatus.New)]
    [InlineData(FeatureStatus.Suspended)]
    [InlineData(FeatureStatus.Active)]
    public void SerializationRoundtrip_Works(FeatureStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FeatureStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FeatureStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FeatureStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FeatureStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class FeatureTypeTest : TestBase
{
    [Theory]
    [InlineData(FeatureType.Boolean)]
    [InlineData(FeatureType.Number)]
    [InlineData(FeatureType.Enum)]
    public void Validation_Works(FeatureType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FeatureType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FeatureType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FeatureType.Boolean)]
    [InlineData(FeatureType.Number)]
    [InlineData(FeatureType.Enum)]
    public void SerializationRoundtrip_Works(FeatureType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FeatureType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FeatureType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FeatureType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FeatureType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class UnionObjectVariant0ResetPeriodTest : TestBase
{
    [Theory]
    [InlineData(UnionObjectVariant0ResetPeriod.Year)]
    [InlineData(UnionObjectVariant0ResetPeriod.Month)]
    [InlineData(UnionObjectVariant0ResetPeriod.Week)]
    [InlineData(UnionObjectVariant0ResetPeriod.Day)]
    [InlineData(UnionObjectVariant0ResetPeriod.Hour)]
    public void Validation_Works(UnionObjectVariant0ResetPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UnionObjectVariant0ResetPeriod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UnionObjectVariant0ResetPeriod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UnionObjectVariant0ResetPeriod.Year)]
    [InlineData(UnionObjectVariant0ResetPeriod.Month)]
    [InlineData(UnionObjectVariant0ResetPeriod.Week)]
    [InlineData(UnionObjectVariant0ResetPeriod.Day)]
    [InlineData(UnionObjectVariant0ResetPeriod.Hour)]
    public void SerializationRoundtrip_Works(UnionObjectVariant0ResetPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UnionObjectVariant0ResetPeriod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, UnionObjectVariant0ResetPeriod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UnionObjectVariant0ResetPeriod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, UnionObjectVariant0ResetPeriod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class UnionObjectVariant1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UnionObjectVariant1
        {
            AccessDeniedReason = UnionObjectVariant1AccessDeniedReason.FeatureNotFound,
            Currency = new()
            {
                CurrencyID = "currencyId",
                DisplayName = "displayName",
                AdditionalMetaData = JsonSerializer.Deserialize<JsonElement>("{}"),
                Description = "description",
                UnitPlural = "unitPlural",
                UnitSingular = "unitSingular",
            },
            CurrentUsage = 0,
            IsGranted = true,
            Type = UnionObjectVariant1Type.Credit,
            UsageLimit = 0,
            UsageUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        ApiEnum<string, UnionObjectVariant1AccessDeniedReason> expectedAccessDeniedReason =
            UnionObjectVariant1AccessDeniedReason.FeatureNotFound;
        UnionObjectVariant1Currency expectedCurrency = new()
        {
            CurrencyID = "currencyId",
            DisplayName = "displayName",
            AdditionalMetaData = JsonSerializer.Deserialize<JsonElement>("{}"),
            Description = "description",
            UnitPlural = "unitPlural",
            UnitSingular = "unitSingular",
        };
        double expectedCurrentUsage = 0;
        bool expectedIsGranted = true;
        ApiEnum<string, UnionObjectVariant1Type> expectedType = UnionObjectVariant1Type.Credit;
        double expectedUsageLimit = 0;
        DateTimeOffset expectedUsageUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedEntitlementUpdatedAt = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        DateTimeOffset expectedUsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedAccessDeniedReason, model.AccessDeniedReason);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedCurrentUsage, model.CurrentUsage);
        Assert.Equal(expectedIsGranted, model.IsGranted);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUsageLimit, model.UsageLimit);
        Assert.Equal(expectedUsageUpdatedAt, model.UsageUpdatedAt);
        Assert.Equal(expectedEntitlementUpdatedAt, model.EntitlementUpdatedAt);
        Assert.Equal(expectedUsagePeriodEnd, model.UsagePeriodEnd);
        Assert.Equal(expectedValidUntil, model.ValidUntil);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UnionObjectVariant1
        {
            AccessDeniedReason = UnionObjectVariant1AccessDeniedReason.FeatureNotFound,
            Currency = new()
            {
                CurrencyID = "currencyId",
                DisplayName = "displayName",
                AdditionalMetaData = JsonSerializer.Deserialize<JsonElement>("{}"),
                Description = "description",
                UnitPlural = "unitPlural",
                UnitSingular = "unitSingular",
            },
            CurrentUsage = 0,
            IsGranted = true,
            Type = UnionObjectVariant1Type.Credit,
            UsageLimit = 0,
            UsageUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnionObjectVariant1>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UnionObjectVariant1
        {
            AccessDeniedReason = UnionObjectVariant1AccessDeniedReason.FeatureNotFound,
            Currency = new()
            {
                CurrencyID = "currencyId",
                DisplayName = "displayName",
                AdditionalMetaData = JsonSerializer.Deserialize<JsonElement>("{}"),
                Description = "description",
                UnitPlural = "unitPlural",
                UnitSingular = "unitSingular",
            },
            CurrentUsage = 0,
            IsGranted = true,
            Type = UnionObjectVariant1Type.Credit,
            UsageLimit = 0,
            UsageUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnionObjectVariant1>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, UnionObjectVariant1AccessDeniedReason> expectedAccessDeniedReason =
            UnionObjectVariant1AccessDeniedReason.FeatureNotFound;
        UnionObjectVariant1Currency expectedCurrency = new()
        {
            CurrencyID = "currencyId",
            DisplayName = "displayName",
            AdditionalMetaData = JsonSerializer.Deserialize<JsonElement>("{}"),
            Description = "description",
            UnitPlural = "unitPlural",
            UnitSingular = "unitSingular",
        };
        double expectedCurrentUsage = 0;
        bool expectedIsGranted = true;
        ApiEnum<string, UnionObjectVariant1Type> expectedType = UnionObjectVariant1Type.Credit;
        double expectedUsageLimit = 0;
        DateTimeOffset expectedUsageUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedEntitlementUpdatedAt = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        DateTimeOffset expectedUsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedAccessDeniedReason, deserialized.AccessDeniedReason);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedCurrentUsage, deserialized.CurrentUsage);
        Assert.Equal(expectedIsGranted, deserialized.IsGranted);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUsageLimit, deserialized.UsageLimit);
        Assert.Equal(expectedUsageUpdatedAt, deserialized.UsageUpdatedAt);
        Assert.Equal(expectedEntitlementUpdatedAt, deserialized.EntitlementUpdatedAt);
        Assert.Equal(expectedUsagePeriodEnd, deserialized.UsagePeriodEnd);
        Assert.Equal(expectedValidUntil, deserialized.ValidUntil);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UnionObjectVariant1
        {
            AccessDeniedReason = UnionObjectVariant1AccessDeniedReason.FeatureNotFound,
            Currency = new()
            {
                CurrencyID = "currencyId",
                DisplayName = "displayName",
                AdditionalMetaData = JsonSerializer.Deserialize<JsonElement>("{}"),
                Description = "description",
                UnitPlural = "unitPlural",
                UnitSingular = "unitSingular",
            },
            CurrentUsage = 0,
            IsGranted = true,
            Type = UnionObjectVariant1Type.Credit,
            UsageLimit = 0,
            UsageUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UnionObjectVariant1
        {
            AccessDeniedReason = UnionObjectVariant1AccessDeniedReason.FeatureNotFound,
            Currency = new()
            {
                CurrencyID = "currencyId",
                DisplayName = "displayName",
                AdditionalMetaData = JsonSerializer.Deserialize<JsonElement>("{}"),
                Description = "description",
                UnitPlural = "unitPlural",
                UnitSingular = "unitSingular",
            },
            CurrentUsage = 0,
            IsGranted = true,
            Type = UnionObjectVariant1Type.Credit,
            UsageLimit = 0,
            UsageUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.EntitlementUpdatedAt);
        Assert.False(model.RawData.ContainsKey("entitlementUpdatedAt"));
        Assert.Null(model.UsagePeriodEnd);
        Assert.False(model.RawData.ContainsKey("usagePeriodEnd"));
        Assert.Null(model.ValidUntil);
        Assert.False(model.RawData.ContainsKey("validUntil"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new UnionObjectVariant1
        {
            AccessDeniedReason = UnionObjectVariant1AccessDeniedReason.FeatureNotFound,
            Currency = new()
            {
                CurrencyID = "currencyId",
                DisplayName = "displayName",
                AdditionalMetaData = JsonSerializer.Deserialize<JsonElement>("{}"),
                Description = "description",
                UnitPlural = "unitPlural",
                UnitSingular = "unitSingular",
            },
            CurrentUsage = 0,
            IsGranted = true,
            Type = UnionObjectVariant1Type.Credit,
            UsageLimit = 0,
            UsageUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UnionObjectVariant1
        {
            AccessDeniedReason = UnionObjectVariant1AccessDeniedReason.FeatureNotFound,
            Currency = new()
            {
                CurrencyID = "currencyId",
                DisplayName = "displayName",
                AdditionalMetaData = JsonSerializer.Deserialize<JsonElement>("{}"),
                Description = "description",
                UnitPlural = "unitPlural",
                UnitSingular = "unitSingular",
            },
            CurrentUsage = 0,
            IsGranted = true,
            Type = UnionObjectVariant1Type.Credit,
            UsageLimit = 0,
            UsageUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            EntitlementUpdatedAt = null,
            UsagePeriodEnd = null,
            ValidUntil = null,
        };

        Assert.Null(model.EntitlementUpdatedAt);
        Assert.False(model.RawData.ContainsKey("entitlementUpdatedAt"));
        Assert.Null(model.UsagePeriodEnd);
        Assert.False(model.RawData.ContainsKey("usagePeriodEnd"));
        Assert.Null(model.ValidUntil);
        Assert.False(model.RawData.ContainsKey("validUntil"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UnionObjectVariant1
        {
            AccessDeniedReason = UnionObjectVariant1AccessDeniedReason.FeatureNotFound,
            Currency = new()
            {
                CurrencyID = "currencyId",
                DisplayName = "displayName",
                AdditionalMetaData = JsonSerializer.Deserialize<JsonElement>("{}"),
                Description = "description",
                UnitPlural = "unitPlural",
                UnitSingular = "unitSingular",
            },
            CurrentUsage = 0,
            IsGranted = true,
            Type = UnionObjectVariant1Type.Credit,
            UsageLimit = 0,
            UsageUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            EntitlementUpdatedAt = null,
            UsagePeriodEnd = null,
            ValidUntil = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UnionObjectVariant1
        {
            AccessDeniedReason = UnionObjectVariant1AccessDeniedReason.FeatureNotFound,
            Currency = new()
            {
                CurrencyID = "currencyId",
                DisplayName = "displayName",
                AdditionalMetaData = JsonSerializer.Deserialize<JsonElement>("{}"),
                Description = "description",
                UnitPlural = "unitPlural",
                UnitSingular = "unitSingular",
            },
            CurrentUsage = 0,
            IsGranted = true,
            Type = UnionObjectVariant1Type.Credit,
            UsageLimit = 0,
            UsageUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        UnionObjectVariant1 copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UnionObjectVariant1AccessDeniedReasonTest : TestBase
{
    [Theory]
    [InlineData(UnionObjectVariant1AccessDeniedReason.FeatureNotFound)]
    [InlineData(UnionObjectVariant1AccessDeniedReason.CustomerNotFound)]
    [InlineData(UnionObjectVariant1AccessDeniedReason.CustomerIsArchived)]
    [InlineData(UnionObjectVariant1AccessDeniedReason.CustomerResourceNotFound)]
    [InlineData(UnionObjectVariant1AccessDeniedReason.NoActiveSubscription)]
    [InlineData(UnionObjectVariant1AccessDeniedReason.NoFeatureEntitlementInSubscription)]
    [InlineData(UnionObjectVariant1AccessDeniedReason.RequestedUsageExceedingLimit)]
    [InlineData(UnionObjectVariant1AccessDeniedReason.RequestedValuesMismatch)]
    [InlineData(UnionObjectVariant1AccessDeniedReason.BudgetExceeded)]
    [InlineData(UnionObjectVariant1AccessDeniedReason.Unknown)]
    [InlineData(UnionObjectVariant1AccessDeniedReason.FeatureTypeMismatch)]
    [InlineData(UnionObjectVariant1AccessDeniedReason.Revoked)]
    [InlineData(UnionObjectVariant1AccessDeniedReason.InsufficientCredits)]
    [InlineData(UnionObjectVariant1AccessDeniedReason.EntitlementNotFound)]
    public void Validation_Works(UnionObjectVariant1AccessDeniedReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UnionObjectVariant1AccessDeniedReason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, UnionObjectVariant1AccessDeniedReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UnionObjectVariant1AccessDeniedReason.FeatureNotFound)]
    [InlineData(UnionObjectVariant1AccessDeniedReason.CustomerNotFound)]
    [InlineData(UnionObjectVariant1AccessDeniedReason.CustomerIsArchived)]
    [InlineData(UnionObjectVariant1AccessDeniedReason.CustomerResourceNotFound)]
    [InlineData(UnionObjectVariant1AccessDeniedReason.NoActiveSubscription)]
    [InlineData(UnionObjectVariant1AccessDeniedReason.NoFeatureEntitlementInSubscription)]
    [InlineData(UnionObjectVariant1AccessDeniedReason.RequestedUsageExceedingLimit)]
    [InlineData(UnionObjectVariant1AccessDeniedReason.RequestedValuesMismatch)]
    [InlineData(UnionObjectVariant1AccessDeniedReason.BudgetExceeded)]
    [InlineData(UnionObjectVariant1AccessDeniedReason.Unknown)]
    [InlineData(UnionObjectVariant1AccessDeniedReason.FeatureTypeMismatch)]
    [InlineData(UnionObjectVariant1AccessDeniedReason.Revoked)]
    [InlineData(UnionObjectVariant1AccessDeniedReason.InsufficientCredits)]
    [InlineData(UnionObjectVariant1AccessDeniedReason.EntitlementNotFound)]
    public void SerializationRoundtrip_Works(UnionObjectVariant1AccessDeniedReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UnionObjectVariant1AccessDeniedReason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, UnionObjectVariant1AccessDeniedReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, UnionObjectVariant1AccessDeniedReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, UnionObjectVariant1AccessDeniedReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class UnionObjectVariant1CurrencyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UnionObjectVariant1Currency
        {
            CurrencyID = "currencyId",
            DisplayName = "displayName",
            AdditionalMetaData = JsonSerializer.Deserialize<JsonElement>("{}"),
            Description = "description",
            UnitPlural = "unitPlural",
            UnitSingular = "unitSingular",
        };

        string expectedCurrencyID = "currencyId";
        string expectedDisplayName = "displayName";
        JsonElement expectedAdditionalMetaData = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedDescription = "description";
        string expectedUnitPlural = "unitPlural";
        string expectedUnitSingular = "unitSingular";

        Assert.Equal(expectedCurrencyID, model.CurrencyID);
        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.NotNull(model.AdditionalMetaData);
        Assert.True(
            JsonElement.DeepEquals(expectedAdditionalMetaData, model.AdditionalMetaData.Value)
        );
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedUnitPlural, model.UnitPlural);
        Assert.Equal(expectedUnitSingular, model.UnitSingular);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UnionObjectVariant1Currency
        {
            CurrencyID = "currencyId",
            DisplayName = "displayName",
            AdditionalMetaData = JsonSerializer.Deserialize<JsonElement>("{}"),
            Description = "description",
            UnitPlural = "unitPlural",
            UnitSingular = "unitSingular",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnionObjectVariant1Currency>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UnionObjectVariant1Currency
        {
            CurrencyID = "currencyId",
            DisplayName = "displayName",
            AdditionalMetaData = JsonSerializer.Deserialize<JsonElement>("{}"),
            Description = "description",
            UnitPlural = "unitPlural",
            UnitSingular = "unitSingular",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnionObjectVariant1Currency>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCurrencyID = "currencyId";
        string expectedDisplayName = "displayName";
        JsonElement expectedAdditionalMetaData = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedDescription = "description";
        string expectedUnitPlural = "unitPlural";
        string expectedUnitSingular = "unitSingular";

        Assert.Equal(expectedCurrencyID, deserialized.CurrencyID);
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
        Assert.NotNull(deserialized.AdditionalMetaData);
        Assert.True(
            JsonElement.DeepEquals(
                expectedAdditionalMetaData,
                deserialized.AdditionalMetaData.Value
            )
        );
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedUnitPlural, deserialized.UnitPlural);
        Assert.Equal(expectedUnitSingular, deserialized.UnitSingular);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UnionObjectVariant1Currency
        {
            CurrencyID = "currencyId",
            DisplayName = "displayName",
            AdditionalMetaData = JsonSerializer.Deserialize<JsonElement>("{}"),
            Description = "description",
            UnitPlural = "unitPlural",
            UnitSingular = "unitSingular",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UnionObjectVariant1Currency
        {
            CurrencyID = "currencyId",
            DisplayName = "displayName",
            Description = "description",
            UnitPlural = "unitPlural",
            UnitSingular = "unitSingular",
        };

        Assert.Null(model.AdditionalMetaData);
        Assert.False(model.RawData.ContainsKey("additionalMetaData"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new UnionObjectVariant1Currency
        {
            CurrencyID = "currencyId",
            DisplayName = "displayName",
            Description = "description",
            UnitPlural = "unitPlural",
            UnitSingular = "unitSingular",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UnionObjectVariant1Currency
        {
            CurrencyID = "currencyId",
            DisplayName = "displayName",
            Description = "description",
            UnitPlural = "unitPlural",
            UnitSingular = "unitSingular",

            // Null should be interpreted as omitted for these properties
            AdditionalMetaData = null,
        };

        Assert.Null(model.AdditionalMetaData);
        Assert.False(model.RawData.ContainsKey("additionalMetaData"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UnionObjectVariant1Currency
        {
            CurrencyID = "currencyId",
            DisplayName = "displayName",
            Description = "description",
            UnitPlural = "unitPlural",
            UnitSingular = "unitSingular",

            // Null should be interpreted as omitted for these properties
            AdditionalMetaData = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UnionObjectVariant1Currency
        {
            CurrencyID = "currencyId",
            DisplayName = "displayName",
            AdditionalMetaData = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.UnitPlural);
        Assert.False(model.RawData.ContainsKey("unitPlural"));
        Assert.Null(model.UnitSingular);
        Assert.False(model.RawData.ContainsKey("unitSingular"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new UnionObjectVariant1Currency
        {
            CurrencyID = "currencyId",
            DisplayName = "displayName",
            AdditionalMetaData = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new UnionObjectVariant1Currency
        {
            CurrencyID = "currencyId",
            DisplayName = "displayName",
            AdditionalMetaData = JsonSerializer.Deserialize<JsonElement>("{}"),

            Description = null,
            UnitPlural = null,
            UnitSingular = null,
        };

        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
        Assert.Null(model.UnitPlural);
        Assert.True(model.RawData.ContainsKey("unitPlural"));
        Assert.Null(model.UnitSingular);
        Assert.True(model.RawData.ContainsKey("unitSingular"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UnionObjectVariant1Currency
        {
            CurrencyID = "currencyId",
            DisplayName = "displayName",
            AdditionalMetaData = JsonSerializer.Deserialize<JsonElement>("{}"),

            Description = null,
            UnitPlural = null,
            UnitSingular = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UnionObjectVariant1Currency
        {
            CurrencyID = "currencyId",
            DisplayName = "displayName",
            AdditionalMetaData = JsonSerializer.Deserialize<JsonElement>("{}"),
            Description = "description",
            UnitPlural = "unitPlural",
            UnitSingular = "unitSingular",
        };

        UnionObjectVariant1Currency copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UnionObjectVariant1TypeTest : TestBase
{
    [Theory]
    [InlineData(UnionObjectVariant1Type.Credit)]
    public void Validation_Works(UnionObjectVariant1Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UnionObjectVariant1Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UnionObjectVariant1Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UnionObjectVariant1Type.Credit)]
    public void SerializationRoundtrip_Works(UnionObjectVariant1Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UnionObjectVariant1Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UnionObjectVariant1Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UnionObjectVariant1Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UnionObjectVariant1Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionProvisionResponseDataStatusTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionProvisionResponseDataStatus.Success)]
    [InlineData(SubscriptionProvisionResponseDataStatus.PaymentRequired)]
    public void Validation_Works(SubscriptionProvisionResponseDataStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionProvisionResponseDataStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionResponseDataStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionProvisionResponseDataStatus.Success)]
    [InlineData(SubscriptionProvisionResponseDataStatus.PaymentRequired)]
    public void SerializationRoundtrip_Works(SubscriptionProvisionResponseDataStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionProvisionResponseDataStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionResponseDataStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionResponseDataStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionResponseDataStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionProvisionResponseDataSubscriptionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscription
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection =
                SubscriptionProvisionResponseDataSubscriptionPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionProvisionResponseDataSubscriptionPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionProvisionResponseDataSubscriptionStatus.PaymentPending,
            Addons = [new() { ID = "id", Quantity = 0 }],
            BillingCycleAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason =
                SubscriptionProvisionResponseDataSubscriptionCancelReason.UpgradeOrDowngrade,
            Coupons =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    Status = SubscriptionProvisionResponseDataSubscriptionCouponStatus.Active,
                    AmountsOff =
                    [
                        new()
                        {
                            Amount = 0,
                            Currency =
                                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Usd,
                        },
                    ],
                    PercentOff = 0,
                },
            ],
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FutureUpdates =
            [
                new()
                {
                    ScheduledExecutionTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ScheduleStatus =
                        SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus.PendingPayment,
                    SubscriptionScheduleType =
                        SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.Downgrade,
                    TargetPackage = new("id"),
                },
            ],
            LatestInvoice = new()
            {
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RequiresAction = true,
                Status = SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus.Open,
                AmountDue = 0,
                BillingReason =
                    SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason.BillingCycle,
                Currency = "currency",
                PdfUrl = "pdfUrl",
                Total = 0,
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MinimumSpend = new()
            {
                Amount = 0,
                Currency = SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Usd,
            },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod =
                SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.Charge,
            Prices =
            [
                new()
                {
                    AddonID = "addonId",
                    Amount = 0,
                    BaseCharge = true,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    Currency = SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Usd,
                    FeatureID = "featureId",
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency =
                                    SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency =
                                    SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            ResourceID = "resourceId",
            SubscriptionEntitlements =
            [
                new()
                {
                    ID = "id",
                    Type =
                        SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementType.Feature,
                },
            ],
            Trial = new(
                SubscriptionProvisionResponseDataSubscriptionTrialTrialEndBehavior.ConvertToPaid
            ),
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        string expectedBillingID = "billingId";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomerID = "customerId";
        ApiEnum<
            string,
            SubscriptionProvisionResponseDataSubscriptionPaymentCollection
        > expectedPaymentCollection =
            SubscriptionProvisionResponseDataSubscriptionPaymentCollection.NotRequired;
        string expectedPlanID = "planId";
        ApiEnum<
            string,
            SubscriptionProvisionResponseDataSubscriptionPricingType
        > expectedPricingType = SubscriptionProvisionResponseDataSubscriptionPricingType.Free;
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionStatus> expectedStatus =
            SubscriptionProvisionResponseDataSubscriptionStatus.PaymentPending;
        List<SubscriptionProvisionResponseDataSubscriptionAddon> expectedAddons =
        [
            new() { ID = "id", Quantity = 0 },
        ];
        DateTimeOffset expectedBillingCycleAnchor = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        SubscriptionProvisionResponseDataSubscriptionBudget expectedBudget = new()
        {
            HasSoftLimit = true,
            Limit = 0,
        };
        DateTimeOffset expectedCancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<
            string,
            SubscriptionProvisionResponseDataSubscriptionCancelReason
        > expectedCancelReason =
            SubscriptionProvisionResponseDataSubscriptionCancelReason.UpgradeOrDowngrade;
        List<SubscriptionProvisionResponseDataSubscriptionCoupon> expectedCoupons =
        [
            new()
            {
                ID = "id",
                Name = "name",
                Status = SubscriptionProvisionResponseDataSubscriptionCouponStatus.Active,
                AmountsOff =
                [
                    new()
                    {
                        Amount = 0,
                        Currency =
                            SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Usd,
                    },
                ],
                PercentOff = 0,
            },
        ];
        DateTimeOffset expectedCurrentBillingPeriodEnd = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        DateTimeOffset expectedCurrentBillingPeriodStart = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        DateTimeOffset expectedEffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<SubscriptionProvisionResponseDataSubscriptionFutureUpdate> expectedFutureUpdates =
        [
            new()
            {
                ScheduledExecutionTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ScheduleStatus =
                    SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus.PendingPayment,
                SubscriptionScheduleType =
                    SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.Downgrade,
                TargetPackage = new("id"),
            },
        ];
        SubscriptionProvisionResponseDataSubscriptionLatestInvoice expectedLatestInvoice = new()
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus.Open,
            AmountDue = 0,
            BillingReason =
                SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason.BillingCycle,
            Currency = "currency",
            PdfUrl = "pdfUrl",
            Total = 0,
        };
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        SubscriptionProvisionResponseDataSubscriptionMinimumSpend expectedMinimumSpend = new()
        {
            Amount = 0,
            Currency = SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Usd,
        };
        string expectedPayingCustomerID = "payingCustomerId";
        ApiEnum<
            string,
            SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod
        > expectedPaymentCollectionMethod =
            SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.Charge;
        List<SubscriptionProvisionResponseDataSubscriptionPrice> expectedPrices =
        [
            new()
            {
                AddonID = "addonId",
                Amount = 0,
                BaseCharge = true,
                BillingCountryCode = "billingCountryCode",
                BlockSize = 0,
                Currency = SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Usd,
                FeatureID = "featureId",
                Tiers =
                [
                    new()
                    {
                        FlatPrice = new()
                        {
                            Amount = 0,
                            Currency =
                                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                        },
                        UnitPrice = new()
                        {
                            Amount = 0,
                            Currency =
                                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                        },
                        UpTo = 0,
                    },
                ],
            },
        ];
        string expectedResourceID = "resourceId";
        List<SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlement> expectedSubscriptionEntitlements =
        [
            new()
            {
                ID = "id",
                Type =
                    SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementType.Feature,
            },
        ];
        SubscriptionProvisionResponseDataSubscriptionTrial expectedTrial = new(
            SubscriptionProvisionResponseDataSubscriptionTrialTrialEndBehavior.ConvertToPaid
        );
        DateTimeOffset expectedTrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBillingID, model.BillingID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCustomerID, model.CustomerID);
        Assert.Equal(expectedPaymentCollection, model.PaymentCollection);
        Assert.Equal(expectedPlanID, model.PlanID);
        Assert.Equal(expectedPricingType, model.PricingType);
        Assert.Equal(expectedStartDate, model.StartDate);
        Assert.Equal(expectedStatus, model.Status);
        Assert.NotNull(model.Addons);
        Assert.Equal(expectedAddons.Count, model.Addons.Count);
        for (int i = 0; i < expectedAddons.Count; i++)
        {
            Assert.Equal(expectedAddons[i], model.Addons[i]);
        }
        Assert.Equal(expectedBillingCycleAnchor, model.BillingCycleAnchor);
        Assert.Equal(expectedBudget, model.Budget);
        Assert.Equal(expectedCancellationDate, model.CancellationDate);
        Assert.Equal(expectedCancelReason, model.CancelReason);
        Assert.NotNull(model.Coupons);
        Assert.Equal(expectedCoupons.Count, model.Coupons.Count);
        for (int i = 0; i < expectedCoupons.Count; i++)
        {
            Assert.Equal(expectedCoupons[i], model.Coupons[i]);
        }
        Assert.Equal(expectedCurrentBillingPeriodEnd, model.CurrentBillingPeriodEnd);
        Assert.Equal(expectedCurrentBillingPeriodStart, model.CurrentBillingPeriodStart);
        Assert.Equal(expectedEffectiveEndDate, model.EffectiveEndDate);
        Assert.Equal(expectedEndDate, model.EndDate);
        Assert.NotNull(model.FutureUpdates);
        Assert.Equal(expectedFutureUpdates.Count, model.FutureUpdates.Count);
        for (int i = 0; i < expectedFutureUpdates.Count; i++)
        {
            Assert.Equal(expectedFutureUpdates[i], model.FutureUpdates[i]);
        }
        Assert.Equal(expectedLatestInvoice, model.LatestInvoice);
        Assert.NotNull(model.Metadata);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedMinimumSpend, model.MinimumSpend);
        Assert.Equal(expectedPayingCustomerID, model.PayingCustomerID);
        Assert.Equal(expectedPaymentCollectionMethod, model.PaymentCollectionMethod);
        Assert.NotNull(model.Prices);
        Assert.Equal(expectedPrices.Count, model.Prices.Count);
        for (int i = 0; i < expectedPrices.Count; i++)
        {
            Assert.Equal(expectedPrices[i], model.Prices[i]);
        }
        Assert.Equal(expectedResourceID, model.ResourceID);
        Assert.NotNull(model.SubscriptionEntitlements);
        Assert.Equal(expectedSubscriptionEntitlements.Count, model.SubscriptionEntitlements.Count);
        for (int i = 0; i < expectedSubscriptionEntitlements.Count; i++)
        {
            Assert.Equal(expectedSubscriptionEntitlements[i], model.SubscriptionEntitlements[i]);
        }
        Assert.Equal(expectedTrial, model.Trial);
        Assert.Equal(expectedTrialEndDate, model.TrialEndDate);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscription
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection =
                SubscriptionProvisionResponseDataSubscriptionPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionProvisionResponseDataSubscriptionPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionProvisionResponseDataSubscriptionStatus.PaymentPending,
            Addons = [new() { ID = "id", Quantity = 0 }],
            BillingCycleAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason =
                SubscriptionProvisionResponseDataSubscriptionCancelReason.UpgradeOrDowngrade,
            Coupons =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    Status = SubscriptionProvisionResponseDataSubscriptionCouponStatus.Active,
                    AmountsOff =
                    [
                        new()
                        {
                            Amount = 0,
                            Currency =
                                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Usd,
                        },
                    ],
                    PercentOff = 0,
                },
            ],
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FutureUpdates =
            [
                new()
                {
                    ScheduledExecutionTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ScheduleStatus =
                        SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus.PendingPayment,
                    SubscriptionScheduleType =
                        SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.Downgrade,
                    TargetPackage = new("id"),
                },
            ],
            LatestInvoice = new()
            {
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RequiresAction = true,
                Status = SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus.Open,
                AmountDue = 0,
                BillingReason =
                    SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason.BillingCycle,
                Currency = "currency",
                PdfUrl = "pdfUrl",
                Total = 0,
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MinimumSpend = new()
            {
                Amount = 0,
                Currency = SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Usd,
            },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod =
                SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.Charge,
            Prices =
            [
                new()
                {
                    AddonID = "addonId",
                    Amount = 0,
                    BaseCharge = true,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    Currency = SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Usd,
                    FeatureID = "featureId",
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency =
                                    SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency =
                                    SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            ResourceID = "resourceId",
            SubscriptionEntitlements =
            [
                new()
                {
                    ID = "id",
                    Type =
                        SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementType.Feature,
                },
            ],
            Trial = new(
                SubscriptionProvisionResponseDataSubscriptionTrialTrialEndBehavior.ConvertToPaid
            ),
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionProvisionResponseDataSubscription>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscription
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection =
                SubscriptionProvisionResponseDataSubscriptionPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionProvisionResponseDataSubscriptionPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionProvisionResponseDataSubscriptionStatus.PaymentPending,
            Addons = [new() { ID = "id", Quantity = 0 }],
            BillingCycleAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason =
                SubscriptionProvisionResponseDataSubscriptionCancelReason.UpgradeOrDowngrade,
            Coupons =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    Status = SubscriptionProvisionResponseDataSubscriptionCouponStatus.Active,
                    AmountsOff =
                    [
                        new()
                        {
                            Amount = 0,
                            Currency =
                                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Usd,
                        },
                    ],
                    PercentOff = 0,
                },
            ],
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FutureUpdates =
            [
                new()
                {
                    ScheduledExecutionTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ScheduleStatus =
                        SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus.PendingPayment,
                    SubscriptionScheduleType =
                        SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.Downgrade,
                    TargetPackage = new("id"),
                },
            ],
            LatestInvoice = new()
            {
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RequiresAction = true,
                Status = SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus.Open,
                AmountDue = 0,
                BillingReason =
                    SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason.BillingCycle,
                Currency = "currency",
                PdfUrl = "pdfUrl",
                Total = 0,
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MinimumSpend = new()
            {
                Amount = 0,
                Currency = SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Usd,
            },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod =
                SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.Charge,
            Prices =
            [
                new()
                {
                    AddonID = "addonId",
                    Amount = 0,
                    BaseCharge = true,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    Currency = SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Usd,
                    FeatureID = "featureId",
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency =
                                    SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency =
                                    SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            ResourceID = "resourceId",
            SubscriptionEntitlements =
            [
                new()
                {
                    ID = "id",
                    Type =
                        SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementType.Feature,
                },
            ],
            Trial = new(
                SubscriptionProvisionResponseDataSubscriptionTrialTrialEndBehavior.ConvertToPaid
            ),
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionProvisionResponseDataSubscription>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedBillingID = "billingId";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomerID = "customerId";
        ApiEnum<
            string,
            SubscriptionProvisionResponseDataSubscriptionPaymentCollection
        > expectedPaymentCollection =
            SubscriptionProvisionResponseDataSubscriptionPaymentCollection.NotRequired;
        string expectedPlanID = "planId";
        ApiEnum<
            string,
            SubscriptionProvisionResponseDataSubscriptionPricingType
        > expectedPricingType = SubscriptionProvisionResponseDataSubscriptionPricingType.Free;
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionStatus> expectedStatus =
            SubscriptionProvisionResponseDataSubscriptionStatus.PaymentPending;
        List<SubscriptionProvisionResponseDataSubscriptionAddon> expectedAddons =
        [
            new() { ID = "id", Quantity = 0 },
        ];
        DateTimeOffset expectedBillingCycleAnchor = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        SubscriptionProvisionResponseDataSubscriptionBudget expectedBudget = new()
        {
            HasSoftLimit = true,
            Limit = 0,
        };
        DateTimeOffset expectedCancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<
            string,
            SubscriptionProvisionResponseDataSubscriptionCancelReason
        > expectedCancelReason =
            SubscriptionProvisionResponseDataSubscriptionCancelReason.UpgradeOrDowngrade;
        List<SubscriptionProvisionResponseDataSubscriptionCoupon> expectedCoupons =
        [
            new()
            {
                ID = "id",
                Name = "name",
                Status = SubscriptionProvisionResponseDataSubscriptionCouponStatus.Active,
                AmountsOff =
                [
                    new()
                    {
                        Amount = 0,
                        Currency =
                            SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Usd,
                    },
                ],
                PercentOff = 0,
            },
        ];
        DateTimeOffset expectedCurrentBillingPeriodEnd = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        DateTimeOffset expectedCurrentBillingPeriodStart = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        DateTimeOffset expectedEffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<SubscriptionProvisionResponseDataSubscriptionFutureUpdate> expectedFutureUpdates =
        [
            new()
            {
                ScheduledExecutionTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ScheduleStatus =
                    SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus.PendingPayment,
                SubscriptionScheduleType =
                    SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.Downgrade,
                TargetPackage = new("id"),
            },
        ];
        SubscriptionProvisionResponseDataSubscriptionLatestInvoice expectedLatestInvoice = new()
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus.Open,
            AmountDue = 0,
            BillingReason =
                SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason.BillingCycle,
            Currency = "currency",
            PdfUrl = "pdfUrl",
            Total = 0,
        };
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        SubscriptionProvisionResponseDataSubscriptionMinimumSpend expectedMinimumSpend = new()
        {
            Amount = 0,
            Currency = SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Usd,
        };
        string expectedPayingCustomerID = "payingCustomerId";
        ApiEnum<
            string,
            SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod
        > expectedPaymentCollectionMethod =
            SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.Charge;
        List<SubscriptionProvisionResponseDataSubscriptionPrice> expectedPrices =
        [
            new()
            {
                AddonID = "addonId",
                Amount = 0,
                BaseCharge = true,
                BillingCountryCode = "billingCountryCode",
                BlockSize = 0,
                Currency = SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Usd,
                FeatureID = "featureId",
                Tiers =
                [
                    new()
                    {
                        FlatPrice = new()
                        {
                            Amount = 0,
                            Currency =
                                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                        },
                        UnitPrice = new()
                        {
                            Amount = 0,
                            Currency =
                                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                        },
                        UpTo = 0,
                    },
                ],
            },
        ];
        string expectedResourceID = "resourceId";
        List<SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlement> expectedSubscriptionEntitlements =
        [
            new()
            {
                ID = "id",
                Type =
                    SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementType.Feature,
            },
        ];
        SubscriptionProvisionResponseDataSubscriptionTrial expectedTrial = new(
            SubscriptionProvisionResponseDataSubscriptionTrialTrialEndBehavior.ConvertToPaid
        );
        DateTimeOffset expectedTrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedBillingID, deserialized.BillingID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCustomerID, deserialized.CustomerID);
        Assert.Equal(expectedPaymentCollection, deserialized.PaymentCollection);
        Assert.Equal(expectedPlanID, deserialized.PlanID);
        Assert.Equal(expectedPricingType, deserialized.PricingType);
        Assert.Equal(expectedStartDate, deserialized.StartDate);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.NotNull(deserialized.Addons);
        Assert.Equal(expectedAddons.Count, deserialized.Addons.Count);
        for (int i = 0; i < expectedAddons.Count; i++)
        {
            Assert.Equal(expectedAddons[i], deserialized.Addons[i]);
        }
        Assert.Equal(expectedBillingCycleAnchor, deserialized.BillingCycleAnchor);
        Assert.Equal(expectedBudget, deserialized.Budget);
        Assert.Equal(expectedCancellationDate, deserialized.CancellationDate);
        Assert.Equal(expectedCancelReason, deserialized.CancelReason);
        Assert.NotNull(deserialized.Coupons);
        Assert.Equal(expectedCoupons.Count, deserialized.Coupons.Count);
        for (int i = 0; i < expectedCoupons.Count; i++)
        {
            Assert.Equal(expectedCoupons[i], deserialized.Coupons[i]);
        }
        Assert.Equal(expectedCurrentBillingPeriodEnd, deserialized.CurrentBillingPeriodEnd);
        Assert.Equal(expectedCurrentBillingPeriodStart, deserialized.CurrentBillingPeriodStart);
        Assert.Equal(expectedEffectiveEndDate, deserialized.EffectiveEndDate);
        Assert.Equal(expectedEndDate, deserialized.EndDate);
        Assert.NotNull(deserialized.FutureUpdates);
        Assert.Equal(expectedFutureUpdates.Count, deserialized.FutureUpdates.Count);
        for (int i = 0; i < expectedFutureUpdates.Count; i++)
        {
            Assert.Equal(expectedFutureUpdates[i], deserialized.FutureUpdates[i]);
        }
        Assert.Equal(expectedLatestInvoice, deserialized.LatestInvoice);
        Assert.NotNull(deserialized.Metadata);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedMinimumSpend, deserialized.MinimumSpend);
        Assert.Equal(expectedPayingCustomerID, deserialized.PayingCustomerID);
        Assert.Equal(expectedPaymentCollectionMethod, deserialized.PaymentCollectionMethod);
        Assert.NotNull(deserialized.Prices);
        Assert.Equal(expectedPrices.Count, deserialized.Prices.Count);
        for (int i = 0; i < expectedPrices.Count; i++)
        {
            Assert.Equal(expectedPrices[i], deserialized.Prices[i]);
        }
        Assert.Equal(expectedResourceID, deserialized.ResourceID);
        Assert.NotNull(deserialized.SubscriptionEntitlements);
        Assert.Equal(
            expectedSubscriptionEntitlements.Count,
            deserialized.SubscriptionEntitlements.Count
        );
        for (int i = 0; i < expectedSubscriptionEntitlements.Count; i++)
        {
            Assert.Equal(
                expectedSubscriptionEntitlements[i],
                deserialized.SubscriptionEntitlements[i]
            );
        }
        Assert.Equal(expectedTrial, deserialized.Trial);
        Assert.Equal(expectedTrialEndDate, deserialized.TrialEndDate);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscription
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection =
                SubscriptionProvisionResponseDataSubscriptionPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionProvisionResponseDataSubscriptionPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionProvisionResponseDataSubscriptionStatus.PaymentPending,
            Addons = [new() { ID = "id", Quantity = 0 }],
            BillingCycleAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason =
                SubscriptionProvisionResponseDataSubscriptionCancelReason.UpgradeOrDowngrade,
            Coupons =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    Status = SubscriptionProvisionResponseDataSubscriptionCouponStatus.Active,
                    AmountsOff =
                    [
                        new()
                        {
                            Amount = 0,
                            Currency =
                                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Usd,
                        },
                    ],
                    PercentOff = 0,
                },
            ],
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FutureUpdates =
            [
                new()
                {
                    ScheduledExecutionTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ScheduleStatus =
                        SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus.PendingPayment,
                    SubscriptionScheduleType =
                        SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.Downgrade,
                    TargetPackage = new("id"),
                },
            ],
            LatestInvoice = new()
            {
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RequiresAction = true,
                Status = SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus.Open,
                AmountDue = 0,
                BillingReason =
                    SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason.BillingCycle,
                Currency = "currency",
                PdfUrl = "pdfUrl",
                Total = 0,
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MinimumSpend = new()
            {
                Amount = 0,
                Currency = SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Usd,
            },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod =
                SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.Charge,
            Prices =
            [
                new()
                {
                    AddonID = "addonId",
                    Amount = 0,
                    BaseCharge = true,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    Currency = SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Usd,
                    FeatureID = "featureId",
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency =
                                    SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency =
                                    SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            ResourceID = "resourceId",
            SubscriptionEntitlements =
            [
                new()
                {
                    ID = "id",
                    Type =
                        SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementType.Feature,
                },
            ],
            Trial = new(
                SubscriptionProvisionResponseDataSubscriptionTrialTrialEndBehavior.ConvertToPaid
            ),
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscription
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection =
                SubscriptionProvisionResponseDataSubscriptionPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionProvisionResponseDataSubscriptionPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionProvisionResponseDataSubscriptionStatus.PaymentPending,
            BillingCycleAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason =
                SubscriptionProvisionResponseDataSubscriptionCancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LatestInvoice = new()
            {
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RequiresAction = true,
                Status = SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus.Open,
                AmountDue = 0,
                BillingReason =
                    SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason.BillingCycle,
                Currency = "currency",
                PdfUrl = "pdfUrl",
                Total = 0,
            },
            MinimumSpend = new()
            {
                Amount = 0,
                Currency = SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Usd,
            },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod =
                SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.Charge,
            ResourceID = "resourceId",
            Trial = new(
                SubscriptionProvisionResponseDataSubscriptionTrialTrialEndBehavior.ConvertToPaid
            ),
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.Addons);
        Assert.False(model.RawData.ContainsKey("addons"));
        Assert.Null(model.Coupons);
        Assert.False(model.RawData.ContainsKey("coupons"));
        Assert.Null(model.FutureUpdates);
        Assert.False(model.RawData.ContainsKey("futureUpdates"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.Prices);
        Assert.False(model.RawData.ContainsKey("prices"));
        Assert.Null(model.SubscriptionEntitlements);
        Assert.False(model.RawData.ContainsKey("subscriptionEntitlements"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscription
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection =
                SubscriptionProvisionResponseDataSubscriptionPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionProvisionResponseDataSubscriptionPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionProvisionResponseDataSubscriptionStatus.PaymentPending,
            BillingCycleAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason =
                SubscriptionProvisionResponseDataSubscriptionCancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LatestInvoice = new()
            {
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RequiresAction = true,
                Status = SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus.Open,
                AmountDue = 0,
                BillingReason =
                    SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason.BillingCycle,
                Currency = "currency",
                PdfUrl = "pdfUrl",
                Total = 0,
            },
            MinimumSpend = new()
            {
                Amount = 0,
                Currency = SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Usd,
            },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod =
                SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.Charge,
            ResourceID = "resourceId",
            Trial = new(
                SubscriptionProvisionResponseDataSubscriptionTrialTrialEndBehavior.ConvertToPaid
            ),
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscription
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection =
                SubscriptionProvisionResponseDataSubscriptionPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionProvisionResponseDataSubscriptionPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionProvisionResponseDataSubscriptionStatus.PaymentPending,
            BillingCycleAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason =
                SubscriptionProvisionResponseDataSubscriptionCancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LatestInvoice = new()
            {
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RequiresAction = true,
                Status = SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus.Open,
                AmountDue = 0,
                BillingReason =
                    SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason.BillingCycle,
                Currency = "currency",
                PdfUrl = "pdfUrl",
                Total = 0,
            },
            MinimumSpend = new()
            {
                Amount = 0,
                Currency = SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Usd,
            },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod =
                SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.Charge,
            ResourceID = "resourceId",
            Trial = new(
                SubscriptionProvisionResponseDataSubscriptionTrialTrialEndBehavior.ConvertToPaid
            ),
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            Addons = null,
            Coupons = null,
            FutureUpdates = null,
            Metadata = null,
            Prices = null,
            SubscriptionEntitlements = null,
        };

        Assert.Null(model.Addons);
        Assert.False(model.RawData.ContainsKey("addons"));
        Assert.Null(model.Coupons);
        Assert.False(model.RawData.ContainsKey("coupons"));
        Assert.Null(model.FutureUpdates);
        Assert.False(model.RawData.ContainsKey("futureUpdates"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.Prices);
        Assert.False(model.RawData.ContainsKey("prices"));
        Assert.Null(model.SubscriptionEntitlements);
        Assert.False(model.RawData.ContainsKey("subscriptionEntitlements"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscription
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection =
                SubscriptionProvisionResponseDataSubscriptionPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionProvisionResponseDataSubscriptionPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionProvisionResponseDataSubscriptionStatus.PaymentPending,
            BillingCycleAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason =
                SubscriptionProvisionResponseDataSubscriptionCancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LatestInvoice = new()
            {
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RequiresAction = true,
                Status = SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus.Open,
                AmountDue = 0,
                BillingReason =
                    SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason.BillingCycle,
                Currency = "currency",
                PdfUrl = "pdfUrl",
                Total = 0,
            },
            MinimumSpend = new()
            {
                Amount = 0,
                Currency = SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Usd,
            },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod =
                SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.Charge,
            ResourceID = "resourceId",
            Trial = new(
                SubscriptionProvisionResponseDataSubscriptionTrialTrialEndBehavior.ConvertToPaid
            ),
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            Addons = null,
            Coupons = null,
            FutureUpdates = null,
            Metadata = null,
            Prices = null,
            SubscriptionEntitlements = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscription
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection =
                SubscriptionProvisionResponseDataSubscriptionPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionProvisionResponseDataSubscriptionPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionProvisionResponseDataSubscriptionStatus.PaymentPending,
            Addons = [new() { ID = "id", Quantity = 0 }],
            Coupons =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    Status = SubscriptionProvisionResponseDataSubscriptionCouponStatus.Active,
                    AmountsOff =
                    [
                        new()
                        {
                            Amount = 0,
                            Currency =
                                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Usd,
                        },
                    ],
                    PercentOff = 0,
                },
            ],
            FutureUpdates =
            [
                new()
                {
                    ScheduledExecutionTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ScheduleStatus =
                        SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus.PendingPayment,
                    SubscriptionScheduleType =
                        SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.Downgrade,
                    TargetPackage = new("id"),
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Prices =
            [
                new()
                {
                    AddonID = "addonId",
                    Amount = 0,
                    BaseCharge = true,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    Currency = SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Usd,
                    FeatureID = "featureId",
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency =
                                    SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency =
                                    SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            SubscriptionEntitlements =
            [
                new()
                {
                    ID = "id",
                    Type =
                        SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementType.Feature,
                },
            ],
        };

        Assert.Null(model.BillingCycleAnchor);
        Assert.False(model.RawData.ContainsKey("billingCycleAnchor"));
        Assert.Null(model.Budget);
        Assert.False(model.RawData.ContainsKey("budget"));
        Assert.Null(model.CancellationDate);
        Assert.False(model.RawData.ContainsKey("cancellationDate"));
        Assert.Null(model.CancelReason);
        Assert.False(model.RawData.ContainsKey("cancelReason"));
        Assert.Null(model.CurrentBillingPeriodEnd);
        Assert.False(model.RawData.ContainsKey("currentBillingPeriodEnd"));
        Assert.Null(model.CurrentBillingPeriodStart);
        Assert.False(model.RawData.ContainsKey("currentBillingPeriodStart"));
        Assert.Null(model.EffectiveEndDate);
        Assert.False(model.RawData.ContainsKey("effectiveEndDate"));
        Assert.Null(model.EndDate);
        Assert.False(model.RawData.ContainsKey("endDate"));
        Assert.Null(model.LatestInvoice);
        Assert.False(model.RawData.ContainsKey("latestInvoice"));
        Assert.Null(model.MinimumSpend);
        Assert.False(model.RawData.ContainsKey("minimumSpend"));
        Assert.Null(model.PayingCustomerID);
        Assert.False(model.RawData.ContainsKey("payingCustomerId"));
        Assert.Null(model.PaymentCollectionMethod);
        Assert.False(model.RawData.ContainsKey("paymentCollectionMethod"));
        Assert.Null(model.ResourceID);
        Assert.False(model.RawData.ContainsKey("resourceId"));
        Assert.Null(model.Trial);
        Assert.False(model.RawData.ContainsKey("trial"));
        Assert.Null(model.TrialEndDate);
        Assert.False(model.RawData.ContainsKey("trialEndDate"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscription
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection =
                SubscriptionProvisionResponseDataSubscriptionPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionProvisionResponseDataSubscriptionPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionProvisionResponseDataSubscriptionStatus.PaymentPending,
            Addons = [new() { ID = "id", Quantity = 0 }],
            Coupons =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    Status = SubscriptionProvisionResponseDataSubscriptionCouponStatus.Active,
                    AmountsOff =
                    [
                        new()
                        {
                            Amount = 0,
                            Currency =
                                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Usd,
                        },
                    ],
                    PercentOff = 0,
                },
            ],
            FutureUpdates =
            [
                new()
                {
                    ScheduledExecutionTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ScheduleStatus =
                        SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus.PendingPayment,
                    SubscriptionScheduleType =
                        SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.Downgrade,
                    TargetPackage = new("id"),
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Prices =
            [
                new()
                {
                    AddonID = "addonId",
                    Amount = 0,
                    BaseCharge = true,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    Currency = SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Usd,
                    FeatureID = "featureId",
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency =
                                    SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency =
                                    SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            SubscriptionEntitlements =
            [
                new()
                {
                    ID = "id",
                    Type =
                        SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementType.Feature,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscription
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection =
                SubscriptionProvisionResponseDataSubscriptionPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionProvisionResponseDataSubscriptionPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionProvisionResponseDataSubscriptionStatus.PaymentPending,
            Addons = [new() { ID = "id", Quantity = 0 }],
            Coupons =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    Status = SubscriptionProvisionResponseDataSubscriptionCouponStatus.Active,
                    AmountsOff =
                    [
                        new()
                        {
                            Amount = 0,
                            Currency =
                                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Usd,
                        },
                    ],
                    PercentOff = 0,
                },
            ],
            FutureUpdates =
            [
                new()
                {
                    ScheduledExecutionTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ScheduleStatus =
                        SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus.PendingPayment,
                    SubscriptionScheduleType =
                        SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.Downgrade,
                    TargetPackage = new("id"),
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Prices =
            [
                new()
                {
                    AddonID = "addonId",
                    Amount = 0,
                    BaseCharge = true,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    Currency = SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Usd,
                    FeatureID = "featureId",
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency =
                                    SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency =
                                    SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            SubscriptionEntitlements =
            [
                new()
                {
                    ID = "id",
                    Type =
                        SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementType.Feature,
                },
            ],

            BillingCycleAnchor = null,
            Budget = null,
            CancellationDate = null,
            CancelReason = null,
            CurrentBillingPeriodEnd = null,
            CurrentBillingPeriodStart = null,
            EffectiveEndDate = null,
            EndDate = null,
            LatestInvoice = null,
            MinimumSpend = null,
            PayingCustomerID = null,
            PaymentCollectionMethod = null,
            ResourceID = null,
            Trial = null,
            TrialEndDate = null,
        };

        Assert.Null(model.BillingCycleAnchor);
        Assert.True(model.RawData.ContainsKey("billingCycleAnchor"));
        Assert.Null(model.Budget);
        Assert.True(model.RawData.ContainsKey("budget"));
        Assert.Null(model.CancellationDate);
        Assert.True(model.RawData.ContainsKey("cancellationDate"));
        Assert.Null(model.CancelReason);
        Assert.True(model.RawData.ContainsKey("cancelReason"));
        Assert.Null(model.CurrentBillingPeriodEnd);
        Assert.True(model.RawData.ContainsKey("currentBillingPeriodEnd"));
        Assert.Null(model.CurrentBillingPeriodStart);
        Assert.True(model.RawData.ContainsKey("currentBillingPeriodStart"));
        Assert.Null(model.EffectiveEndDate);
        Assert.True(model.RawData.ContainsKey("effectiveEndDate"));
        Assert.Null(model.EndDate);
        Assert.True(model.RawData.ContainsKey("endDate"));
        Assert.Null(model.LatestInvoice);
        Assert.True(model.RawData.ContainsKey("latestInvoice"));
        Assert.Null(model.MinimumSpend);
        Assert.True(model.RawData.ContainsKey("minimumSpend"));
        Assert.Null(model.PayingCustomerID);
        Assert.True(model.RawData.ContainsKey("payingCustomerId"));
        Assert.Null(model.PaymentCollectionMethod);
        Assert.True(model.RawData.ContainsKey("paymentCollectionMethod"));
        Assert.Null(model.ResourceID);
        Assert.True(model.RawData.ContainsKey("resourceId"));
        Assert.Null(model.Trial);
        Assert.True(model.RawData.ContainsKey("trial"));
        Assert.Null(model.TrialEndDate);
        Assert.True(model.RawData.ContainsKey("trialEndDate"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscription
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection =
                SubscriptionProvisionResponseDataSubscriptionPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionProvisionResponseDataSubscriptionPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionProvisionResponseDataSubscriptionStatus.PaymentPending,
            Addons = [new() { ID = "id", Quantity = 0 }],
            Coupons =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    Status = SubscriptionProvisionResponseDataSubscriptionCouponStatus.Active,
                    AmountsOff =
                    [
                        new()
                        {
                            Amount = 0,
                            Currency =
                                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Usd,
                        },
                    ],
                    PercentOff = 0,
                },
            ],
            FutureUpdates =
            [
                new()
                {
                    ScheduledExecutionTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ScheduleStatus =
                        SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus.PendingPayment,
                    SubscriptionScheduleType =
                        SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.Downgrade,
                    TargetPackage = new("id"),
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Prices =
            [
                new()
                {
                    AddonID = "addonId",
                    Amount = 0,
                    BaseCharge = true,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    Currency = SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Usd,
                    FeatureID = "featureId",
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency =
                                    SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency =
                                    SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            SubscriptionEntitlements =
            [
                new()
                {
                    ID = "id",
                    Type =
                        SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementType.Feature,
                },
            ],

            BillingCycleAnchor = null,
            Budget = null,
            CancellationDate = null,
            CancelReason = null,
            CurrentBillingPeriodEnd = null,
            CurrentBillingPeriodStart = null,
            EffectiveEndDate = null,
            EndDate = null,
            LatestInvoice = null,
            MinimumSpend = null,
            PayingCustomerID = null,
            PaymentCollectionMethod = null,
            ResourceID = null,
            Trial = null,
            TrialEndDate = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscription
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection =
                SubscriptionProvisionResponseDataSubscriptionPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionProvisionResponseDataSubscriptionPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionProvisionResponseDataSubscriptionStatus.PaymentPending,
            Addons = [new() { ID = "id", Quantity = 0 }],
            BillingCycleAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason =
                SubscriptionProvisionResponseDataSubscriptionCancelReason.UpgradeOrDowngrade,
            Coupons =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    Status = SubscriptionProvisionResponseDataSubscriptionCouponStatus.Active,
                    AmountsOff =
                    [
                        new()
                        {
                            Amount = 0,
                            Currency =
                                SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Usd,
                        },
                    ],
                    PercentOff = 0,
                },
            ],
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FutureUpdates =
            [
                new()
                {
                    ScheduledExecutionTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ScheduleStatus =
                        SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus.PendingPayment,
                    SubscriptionScheduleType =
                        SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.Downgrade,
                    TargetPackage = new("id"),
                },
            ],
            LatestInvoice = new()
            {
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RequiresAction = true,
                Status = SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus.Open,
                AmountDue = 0,
                BillingReason =
                    SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason.BillingCycle,
                Currency = "currency",
                PdfUrl = "pdfUrl",
                Total = 0,
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MinimumSpend = new()
            {
                Amount = 0,
                Currency = SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Usd,
            },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod =
                SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.Charge,
            Prices =
            [
                new()
                {
                    AddonID = "addonId",
                    Amount = 0,
                    BaseCharge = true,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    Currency = SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Usd,
                    FeatureID = "featureId",
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency =
                                    SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency =
                                    SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            ResourceID = "resourceId",
            SubscriptionEntitlements =
            [
                new()
                {
                    ID = "id",
                    Type =
                        SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementType.Feature,
                },
            ],
            Trial = new(
                SubscriptionProvisionResponseDataSubscriptionTrialTrialEndBehavior.ConvertToPaid
            ),
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        SubscriptionProvisionResponseDataSubscription copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionProvisionResponseDataSubscriptionPaymentCollectionTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPaymentCollection.NotRequired)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPaymentCollection.Processing)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPaymentCollection.Failed)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPaymentCollection.ActionRequired)]
    public void Validation_Works(
        SubscriptionProvisionResponseDataSubscriptionPaymentCollection rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionPaymentCollection> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionPaymentCollection>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPaymentCollection.NotRequired)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPaymentCollection.Processing)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPaymentCollection.Failed)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPaymentCollection.ActionRequired)]
    public void SerializationRoundtrip_Works(
        SubscriptionProvisionResponseDataSubscriptionPaymentCollection rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionPaymentCollection> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionPaymentCollection>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionPaymentCollection>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionPaymentCollection>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionProvisionResponseDataSubscriptionPricingTypeTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricingType.Free)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricingType.Paid)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricingType.Custom)]
    public void Validation_Works(SubscriptionProvisionResponseDataSubscriptionPricingType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionPricingType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionPricingType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricingType.Free)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricingType.Paid)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricingType.Custom)]
    public void SerializationRoundtrip_Works(
        SubscriptionProvisionResponseDataSubscriptionPricingType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionPricingType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionPricingType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionPricingType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionPricingType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionProvisionResponseDataSubscriptionStatusTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionStatus.PaymentPending)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionStatus.Active)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionStatus.Expired)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionStatus.InTrial)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionStatus.Canceled)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionStatus.NotStarted)]
    public void Validation_Works(SubscriptionProvisionResponseDataSubscriptionStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionStatus.PaymentPending)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionStatus.Active)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionStatus.Expired)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionStatus.InTrial)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionStatus.Canceled)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionStatus.NotStarted)]
    public void SerializationRoundtrip_Works(
        SubscriptionProvisionResponseDataSubscriptionStatus rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionProvisionResponseDataSubscriptionAddonTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionAddon
        {
            ID = "id",
            Quantity = 0,
        };

        string expectedID = "id";
        long expectedQuantity = 0;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedQuantity, model.Quantity);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionAddon
        {
            ID = "id",
            Quantity = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionProvisionResponseDataSubscriptionAddon>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionAddon
        {
            ID = "id",
            Quantity = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionProvisionResponseDataSubscriptionAddon>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        long expectedQuantity = 0;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedQuantity, deserialized.Quantity);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionAddon
        {
            ID = "id",
            Quantity = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionAddon
        {
            ID = "id",
            Quantity = 0,
        };

        SubscriptionProvisionResponseDataSubscriptionAddon copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionProvisionResponseDataSubscriptionBudgetTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionBudget
        {
            HasSoftLimit = true,
            Limit = 0,
        };

        bool expectedHasSoftLimit = true;
        double expectedLimit = 0;

        Assert.Equal(expectedHasSoftLimit, model.HasSoftLimit);
        Assert.Equal(expectedLimit, model.Limit);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionBudget
        {
            HasSoftLimit = true,
            Limit = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionProvisionResponseDataSubscriptionBudget>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionBudget
        {
            HasSoftLimit = true,
            Limit = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionProvisionResponseDataSubscriptionBudget>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        bool expectedHasSoftLimit = true;
        double expectedLimit = 0;

        Assert.Equal(expectedHasSoftLimit, deserialized.HasSoftLimit);
        Assert.Equal(expectedLimit, deserialized.Limit);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionBudget
        {
            HasSoftLimit = true,
            Limit = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionBudget
        {
            HasSoftLimit = true,
            Limit = 0,
        };

        SubscriptionProvisionResponseDataSubscriptionBudget copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionProvisionResponseDataSubscriptionCancelReasonTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCancelReason.UpgradeOrDowngrade)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCancelReason.CancelledByBilling)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCancelReason.Expired)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCancelReason.DetachBilling)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCancelReason.TrialEnded)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCancelReason.Immediate)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCancelReason.TrialConverted)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCancelReason.PendingPaymentExpired)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCancelReason.ScheduledCancellation)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCancelReason.CustomerArchived)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCancelReason.AutoCancellationRule)]
    public void Validation_Works(SubscriptionProvisionResponseDataSubscriptionCancelReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionCancelReason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionCancelReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCancelReason.UpgradeOrDowngrade)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCancelReason.CancelledByBilling)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCancelReason.Expired)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCancelReason.DetachBilling)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCancelReason.TrialEnded)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCancelReason.Immediate)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCancelReason.TrialConverted)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCancelReason.PendingPaymentExpired)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCancelReason.ScheduledCancellation)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCancelReason.CustomerArchived)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCancelReason.AutoCancellationRule)]
    public void SerializationRoundtrip_Works(
        SubscriptionProvisionResponseDataSubscriptionCancelReason rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionCancelReason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionCancelReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionCancelReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionCancelReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionProvisionResponseDataSubscriptionCouponTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionCoupon
        {
            ID = "id",
            Name = "name",
            Status = SubscriptionProvisionResponseDataSubscriptionCouponStatus.Active,
            AmountsOff =
            [
                new()
                {
                    Amount = 0,
                    Currency =
                        SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Usd,
                },
            ],
            PercentOff = 0,
        };

        string expectedID = "id";
        string expectedName = "name";
        ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionCouponStatus> expectedStatus =
            SubscriptionProvisionResponseDataSubscriptionCouponStatus.Active;
        List<SubscriptionProvisionResponseDataSubscriptionCouponAmountsOff> expectedAmountsOff =
        [
            new()
            {
                Amount = 0,
                Currency =
                    SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Usd,
            },
        ];
        double expectedPercentOff = 0;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedStatus, model.Status);
        Assert.NotNull(model.AmountsOff);
        Assert.Equal(expectedAmountsOff.Count, model.AmountsOff.Count);
        for (int i = 0; i < expectedAmountsOff.Count; i++)
        {
            Assert.Equal(expectedAmountsOff[i], model.AmountsOff[i]);
        }
        Assert.Equal(expectedPercentOff, model.PercentOff);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionCoupon
        {
            ID = "id",
            Name = "name",
            Status = SubscriptionProvisionResponseDataSubscriptionCouponStatus.Active,
            AmountsOff =
            [
                new()
                {
                    Amount = 0,
                    Currency =
                        SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Usd,
                },
            ],
            PercentOff = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionProvisionResponseDataSubscriptionCoupon>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionCoupon
        {
            ID = "id",
            Name = "name",
            Status = SubscriptionProvisionResponseDataSubscriptionCouponStatus.Active,
            AmountsOff =
            [
                new()
                {
                    Amount = 0,
                    Currency =
                        SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Usd,
                },
            ],
            PercentOff = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionProvisionResponseDataSubscriptionCoupon>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedName = "name";
        ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionCouponStatus> expectedStatus =
            SubscriptionProvisionResponseDataSubscriptionCouponStatus.Active;
        List<SubscriptionProvisionResponseDataSubscriptionCouponAmountsOff> expectedAmountsOff =
        [
            new()
            {
                Amount = 0,
                Currency =
                    SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Usd,
            },
        ];
        double expectedPercentOff = 0;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.NotNull(deserialized.AmountsOff);
        Assert.Equal(expectedAmountsOff.Count, deserialized.AmountsOff.Count);
        for (int i = 0; i < expectedAmountsOff.Count; i++)
        {
            Assert.Equal(expectedAmountsOff[i], deserialized.AmountsOff[i]);
        }
        Assert.Equal(expectedPercentOff, deserialized.PercentOff);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionCoupon
        {
            ID = "id",
            Name = "name",
            Status = SubscriptionProvisionResponseDataSubscriptionCouponStatus.Active,
            AmountsOff =
            [
                new()
                {
                    Amount = 0,
                    Currency =
                        SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Usd,
                },
            ],
            PercentOff = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionCoupon
        {
            ID = "id",
            Name = "name",
            Status = SubscriptionProvisionResponseDataSubscriptionCouponStatus.Active,
        };

        Assert.Null(model.AmountsOff);
        Assert.False(model.RawData.ContainsKey("amountsOff"));
        Assert.Null(model.PercentOff);
        Assert.False(model.RawData.ContainsKey("percentOff"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionCoupon
        {
            ID = "id",
            Name = "name",
            Status = SubscriptionProvisionResponseDataSubscriptionCouponStatus.Active,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionCoupon
        {
            ID = "id",
            Name = "name",
            Status = SubscriptionProvisionResponseDataSubscriptionCouponStatus.Active,

            AmountsOff = null,
            PercentOff = null,
        };

        Assert.Null(model.AmountsOff);
        Assert.True(model.RawData.ContainsKey("amountsOff"));
        Assert.Null(model.PercentOff);
        Assert.True(model.RawData.ContainsKey("percentOff"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionCoupon
        {
            ID = "id",
            Name = "name",
            Status = SubscriptionProvisionResponseDataSubscriptionCouponStatus.Active,

            AmountsOff = null,
            PercentOff = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionCoupon
        {
            ID = "id",
            Name = "name",
            Status = SubscriptionProvisionResponseDataSubscriptionCouponStatus.Active,
            AmountsOff =
            [
                new()
                {
                    Amount = 0,
                    Currency =
                        SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Usd,
                },
            ],
            PercentOff = 0,
        };

        SubscriptionProvisionResponseDataSubscriptionCoupon copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionProvisionResponseDataSubscriptionCouponStatusTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponStatus.Active)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponStatus.Expired)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponStatus.Removed)]
    public void Validation_Works(SubscriptionProvisionResponseDataSubscriptionCouponStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionCouponStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionCouponStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponStatus.Active)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponStatus.Expired)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponStatus.Removed)]
    public void SerializationRoundtrip_Works(
        SubscriptionProvisionResponseDataSubscriptionCouponStatus rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionCouponStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionCouponStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionCouponStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionCouponStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionCouponAmountsOff
        {
            Amount = 0,
            Currency = SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Usd,
        };

        double expectedAmount = 0;
        ApiEnum<
            string,
            SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency
        > expectedCurrency =
            SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionCouponAmountsOff
        {
            Amount = 0,
            Currency = SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Usd,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionProvisionResponseDataSubscriptionCouponAmountsOff>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionCouponAmountsOff
        {
            Amount = 0,
            Currency = SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Usd,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionProvisionResponseDataSubscriptionCouponAmountsOff>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        ApiEnum<
            string,
            SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency
        > expectedCurrency =
            SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionCouponAmountsOff
        {
            Amount = 0,
            Currency = SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionCouponAmountsOff { };

        Assert.Null(model.Amount);
        Assert.False(model.RawData.ContainsKey("amount"));
        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionCouponAmountsOff { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionCouponAmountsOff
        {
            // Null should be interpreted as omitted for these properties
            Amount = null,
            Currency = null,
        };

        Assert.Null(model.Amount);
        Assert.False(model.RawData.ContainsKey("amount"));
        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionCouponAmountsOff
        {
            // Null should be interpreted as omitted for these properties
            Amount = null,
            Currency = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionCouponAmountsOff
        {
            Amount = 0,
            Currency = SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Usd,
        };

        SubscriptionProvisionResponseDataSubscriptionCouponAmountsOff copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrencyTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Usd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Aed)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.All)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Amd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Ang)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Aud)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Awg)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Azn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Bam)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Bbd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Bdt)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Bgn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Bif)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Bmd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Bnd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Bsd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Bwp)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Byn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Bzd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Brl)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Cad)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Cdf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Chf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Cny)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Czk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Dkk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Dop)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Dzd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Egp)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Etb)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Eur)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Fjd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Gbp)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Gel)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Gip)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Gmd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Gyd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Hkd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Hrk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Htg)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Idr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Ils)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Inr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Isk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Jmd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Jpy)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Kes)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Kgs)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Khr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Kmf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Krw)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Kyd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Kzt)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Lbp)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Lkr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Lrd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Lsl)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Mad)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Mdl)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Mga)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Mkd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Mmk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Mnt)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Mop)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Mro)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Mvr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Mwk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Mxn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Myr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Mzn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Nad)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Ngn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Nok)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Npr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Nzd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Pgk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Php)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Pkr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Pln)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Qar)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Ron)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Rsd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Rub)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Rwf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Sar)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Sbd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Scr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Sek)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Sgd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Sle)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Sll)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Sos)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Szl)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Thb)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Tjs)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Top)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Try)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Ttd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Tzs)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Uah)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Uzs)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Vnd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Vuv)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Wst)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Xaf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Xcd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Yer)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Zar)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Zmw)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Clp)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Djf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Gnf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Ugx)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Pyg)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Xof)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Xpf)]
    public void Validation_Works(
        SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Usd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Aed)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.All)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Amd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Ang)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Aud)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Awg)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Azn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Bam)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Bbd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Bdt)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Bgn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Bif)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Bmd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Bnd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Bsd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Bwp)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Byn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Bzd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Brl)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Cad)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Cdf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Chf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Cny)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Czk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Dkk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Dop)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Dzd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Egp)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Etb)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Eur)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Fjd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Gbp)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Gel)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Gip)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Gmd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Gyd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Hkd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Hrk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Htg)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Idr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Ils)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Inr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Isk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Jmd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Jpy)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Kes)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Kgs)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Khr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Kmf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Krw)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Kyd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Kzt)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Lbp)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Lkr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Lrd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Lsl)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Mad)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Mdl)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Mga)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Mkd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Mmk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Mnt)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Mop)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Mro)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Mvr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Mwk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Mxn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Myr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Mzn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Nad)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Ngn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Nok)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Npr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Nzd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Pgk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Php)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Pkr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Pln)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Qar)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Ron)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Rsd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Rub)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Rwf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Sar)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Sbd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Scr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Sek)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Sgd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Sle)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Sll)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Sos)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Szl)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Thb)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Tjs)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Top)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Try)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Ttd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Tzs)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Uah)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Uzs)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Vnd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Vuv)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Wst)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Xaf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Xcd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Yer)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Zar)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Zmw)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Clp)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Djf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Gnf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Ugx)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Pyg)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Xof)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency.Xpf)]
    public void SerializationRoundtrip_Works(
        SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionProvisionResponseDataSubscriptionFutureUpdateTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionFutureUpdate
        {
            ScheduledExecutionTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ScheduleStatus =
                SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus.PendingPayment,
            SubscriptionScheduleType =
                SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.Downgrade,
            TargetPackage = new("id"),
        };

        DateTimeOffset expectedScheduledExecutionTime = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        ApiEnum<
            string,
            SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus
        > expectedScheduleStatus =
            SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus.PendingPayment;
        ApiEnum<
            string,
            SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType
        > expectedSubscriptionScheduleType =
            SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.Downgrade;
        SubscriptionProvisionResponseDataSubscriptionFutureUpdateTargetPackage expectedTargetPackage =
            new("id");

        Assert.Equal(expectedScheduledExecutionTime, model.ScheduledExecutionTime);
        Assert.Equal(expectedScheduleStatus, model.ScheduleStatus);
        Assert.Equal(expectedSubscriptionScheduleType, model.SubscriptionScheduleType);
        Assert.Equal(expectedTargetPackage, model.TargetPackage);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionFutureUpdate
        {
            ScheduledExecutionTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ScheduleStatus =
                SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus.PendingPayment,
            SubscriptionScheduleType =
                SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.Downgrade,
            TargetPackage = new("id"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionProvisionResponseDataSubscriptionFutureUpdate>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionFutureUpdate
        {
            ScheduledExecutionTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ScheduleStatus =
                SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus.PendingPayment,
            SubscriptionScheduleType =
                SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.Downgrade,
            TargetPackage = new("id"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionProvisionResponseDataSubscriptionFutureUpdate>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedScheduledExecutionTime = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        ApiEnum<
            string,
            SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus
        > expectedScheduleStatus =
            SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus.PendingPayment;
        ApiEnum<
            string,
            SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType
        > expectedSubscriptionScheduleType =
            SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.Downgrade;
        SubscriptionProvisionResponseDataSubscriptionFutureUpdateTargetPackage expectedTargetPackage =
            new("id");

        Assert.Equal(expectedScheduledExecutionTime, deserialized.ScheduledExecutionTime);
        Assert.Equal(expectedScheduleStatus, deserialized.ScheduleStatus);
        Assert.Equal(expectedSubscriptionScheduleType, deserialized.SubscriptionScheduleType);
        Assert.Equal(expectedTargetPackage, deserialized.TargetPackage);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionFutureUpdate
        {
            ScheduledExecutionTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ScheduleStatus =
                SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus.PendingPayment,
            SubscriptionScheduleType =
                SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.Downgrade,
            TargetPackage = new("id"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionFutureUpdate
        {
            ScheduledExecutionTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ScheduleStatus =
                SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus.PendingPayment,
            SubscriptionScheduleType =
                SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.Downgrade,
        };

        Assert.Null(model.TargetPackage);
        Assert.False(model.RawData.ContainsKey("targetPackage"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionFutureUpdate
        {
            ScheduledExecutionTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ScheduleStatus =
                SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus.PendingPayment,
            SubscriptionScheduleType =
                SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.Downgrade,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionFutureUpdate
        {
            ScheduledExecutionTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ScheduleStatus =
                SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus.PendingPayment,
            SubscriptionScheduleType =
                SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.Downgrade,

            TargetPackage = null,
        };

        Assert.Null(model.TargetPackage);
        Assert.True(model.RawData.ContainsKey("targetPackage"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionFutureUpdate
        {
            ScheduledExecutionTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ScheduleStatus =
                SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus.PendingPayment,
            SubscriptionScheduleType =
                SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.Downgrade,

            TargetPackage = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionFutureUpdate
        {
            ScheduledExecutionTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ScheduleStatus =
                SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus.PendingPayment,
            SubscriptionScheduleType =
                SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.Downgrade,
            TargetPackage = new("id"),
        };

        SubscriptionProvisionResponseDataSubscriptionFutureUpdate copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatusTest : TestBase
{
    [Theory]
    [InlineData(
        SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus.PendingPayment
    )]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus.Scheduled)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus.Canceled)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus.Done)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus.Failed)]
    public void Validation_Works(
        SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus.PendingPayment
    )]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus.Scheduled)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus.Canceled)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus.Done)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus.Failed)]
    public void SerializationRoundtrip_Works(
        SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleTypeTest
    : TestBase
{
    [Theory]
    [InlineData(
        SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.Downgrade
    )]
    [InlineData(
        SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.Plan
    )]
    [InlineData(
        SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.BillingPeriod
    )]
    [InlineData(
        SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.UnitAmount
    )]
    [InlineData(
        SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.RecurringCredits
    )]
    [InlineData(
        SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.PriceOverride
    )]
    [InlineData(
        SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.Addon
    )]
    [InlineData(
        SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.Coupon
    )]
    [InlineData(
        SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.MigrateToLatest
    )]
    [InlineData(
        SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.AdditionalMetaData
    )]
    [InlineData(
        SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.BillingInfoMetadata
    )]
    public void Validation_Works(
        SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.Downgrade
    )]
    [InlineData(
        SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.Plan
    )]
    [InlineData(
        SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.BillingPeriod
    )]
    [InlineData(
        SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.UnitAmount
    )]
    [InlineData(
        SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.RecurringCredits
    )]
    [InlineData(
        SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.PriceOverride
    )]
    [InlineData(
        SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.Addon
    )]
    [InlineData(
        SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.Coupon
    )]
    [InlineData(
        SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.MigrateToLatest
    )]
    [InlineData(
        SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.AdditionalMetaData
    )]
    [InlineData(
        SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType.BillingInfoMetadata
    )]
    public void SerializationRoundtrip_Works(
        SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionProvisionResponseDataSubscriptionFutureUpdateTargetPackageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionFutureUpdateTargetPackage
        {
            ID = "id",
        };

        string expectedID = "id";

        Assert.Equal(expectedID, model.ID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionFutureUpdateTargetPackage
        {
            ID = "id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionProvisionResponseDataSubscriptionFutureUpdateTargetPackage>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionFutureUpdateTargetPackage
        {
            ID = "id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionProvisionResponseDataSubscriptionFutureUpdateTargetPackage>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedID = "id";

        Assert.Equal(expectedID, deserialized.ID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionFutureUpdateTargetPackage
        {
            ID = "id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionFutureUpdateTargetPackage
        {
            ID = "id",
        };

        SubscriptionProvisionResponseDataSubscriptionFutureUpdateTargetPackage copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionProvisionResponseDataSubscriptionLatestInvoiceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionLatestInvoice
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus.Open,
            AmountDue = 0,
            BillingReason =
                SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason.BillingCycle,
            Currency = "currency",
            PdfUrl = "pdfUrl",
            Total = 0,
        };

        string expectedBillingID = "billingId";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedRequiresAction = true;
        ApiEnum<
            string,
            SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus
        > expectedStatus = SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus.Open;
        double expectedAmountDue = 0;
        ApiEnum<
            string,
            SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason
        > expectedBillingReason =
            SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason.BillingCycle;
        string expectedCurrency = "currency";
        string expectedPdfUrl = "pdfUrl";
        double expectedTotal = 0;

        Assert.Equal(expectedBillingID, model.BillingID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedRequiresAction, model.RequiresAction);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedAmountDue, model.AmountDue);
        Assert.Equal(expectedBillingReason, model.BillingReason);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedPdfUrl, model.PdfUrl);
        Assert.Equal(expectedTotal, model.Total);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionLatestInvoice
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus.Open,
            AmountDue = 0,
            BillingReason =
                SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason.BillingCycle,
            Currency = "currency",
            PdfUrl = "pdfUrl",
            Total = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionProvisionResponseDataSubscriptionLatestInvoice>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionLatestInvoice
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus.Open,
            AmountDue = 0,
            BillingReason =
                SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason.BillingCycle,
            Currency = "currency",
            PdfUrl = "pdfUrl",
            Total = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionProvisionResponseDataSubscriptionLatestInvoice>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedBillingID = "billingId";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedRequiresAction = true;
        ApiEnum<
            string,
            SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus
        > expectedStatus = SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus.Open;
        double expectedAmountDue = 0;
        ApiEnum<
            string,
            SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason
        > expectedBillingReason =
            SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason.BillingCycle;
        string expectedCurrency = "currency";
        string expectedPdfUrl = "pdfUrl";
        double expectedTotal = 0;

        Assert.Equal(expectedBillingID, deserialized.BillingID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedRequiresAction, deserialized.RequiresAction);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedAmountDue, deserialized.AmountDue);
        Assert.Equal(expectedBillingReason, deserialized.BillingReason);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedPdfUrl, deserialized.PdfUrl);
        Assert.Equal(expectedTotal, deserialized.Total);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionLatestInvoice
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus.Open,
            AmountDue = 0,
            BillingReason =
                SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason.BillingCycle,
            Currency = "currency",
            PdfUrl = "pdfUrl",
            Total = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionLatestInvoice
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus.Open,
        };

        Assert.Null(model.AmountDue);
        Assert.False(model.RawData.ContainsKey("amountDue"));
        Assert.Null(model.BillingReason);
        Assert.False(model.RawData.ContainsKey("billingReason"));
        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
        Assert.Null(model.PdfUrl);
        Assert.False(model.RawData.ContainsKey("pdfUrl"));
        Assert.Null(model.Total);
        Assert.False(model.RawData.ContainsKey("total"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionLatestInvoice
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus.Open,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionLatestInvoice
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus.Open,

            AmountDue = null,
            BillingReason = null,
            Currency = null,
            PdfUrl = null,
            Total = null,
        };

        Assert.Null(model.AmountDue);
        Assert.True(model.RawData.ContainsKey("amountDue"));
        Assert.Null(model.BillingReason);
        Assert.True(model.RawData.ContainsKey("billingReason"));
        Assert.Null(model.Currency);
        Assert.True(model.RawData.ContainsKey("currency"));
        Assert.Null(model.PdfUrl);
        Assert.True(model.RawData.ContainsKey("pdfUrl"));
        Assert.Null(model.Total);
        Assert.True(model.RawData.ContainsKey("total"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionLatestInvoice
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus.Open,

            AmountDue = null,
            BillingReason = null,
            Currency = null,
            PdfUrl = null,
            Total = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionLatestInvoice
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus.Open,
            AmountDue = 0,
            BillingReason =
                SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason.BillingCycle,
            Currency = "currency",
            PdfUrl = "pdfUrl",
            Total = 0,
        };

        SubscriptionProvisionResponseDataSubscriptionLatestInvoice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatusTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus.Open)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus.Canceled)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus.Paid)]
    public void Validation_Works(
        SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus.Open)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus.Canceled)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus.Paid)]
    public void SerializationRoundtrip_Works(
        SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReasonTest : TestBase
{
    [Theory]
    [InlineData(
        SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason.BillingCycle
    )]
    [InlineData(
        SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason.SubscriptionCreation
    )]
    [InlineData(
        SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason.SubscriptionUpdate
    )]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason.Manual)]
    [InlineData(
        SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason.MinimumInvoiceAmountExceeded
    )]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason.Other)]
    public void Validation_Works(
        SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason.BillingCycle
    )]
    [InlineData(
        SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason.SubscriptionCreation
    )]
    [InlineData(
        SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason.SubscriptionUpdate
    )]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason.Manual)]
    [InlineData(
        SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason.MinimumInvoiceAmountExceeded
    )]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason.Other)]
    public void SerializationRoundtrip_Works(
        SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionProvisionResponseDataSubscriptionMinimumSpendTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionMinimumSpend
        {
            Amount = 0,
            Currency = SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Usd,
        };

        double expectedAmount = 0;
        ApiEnum<
            string,
            SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency
        > expectedCurrency = SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionMinimumSpend
        {
            Amount = 0,
            Currency = SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Usd,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionProvisionResponseDataSubscriptionMinimumSpend>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionMinimumSpend
        {
            Amount = 0,
            Currency = SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Usd,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionProvisionResponseDataSubscriptionMinimumSpend>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        ApiEnum<
            string,
            SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency
        > expectedCurrency = SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionMinimumSpend
        {
            Amount = 0,
            Currency = SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionMinimumSpend { };

        Assert.Null(model.Amount);
        Assert.False(model.RawData.ContainsKey("amount"));
        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionMinimumSpend { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionMinimumSpend
        {
            // Null should be interpreted as omitted for these properties
            Amount = null,
            Currency = null,
        };

        Assert.Null(model.Amount);
        Assert.False(model.RawData.ContainsKey("amount"));
        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionMinimumSpend
        {
            // Null should be interpreted as omitted for these properties
            Amount = null,
            Currency = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionMinimumSpend
        {
            Amount = 0,
            Currency = SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Usd,
        };

        SubscriptionProvisionResponseDataSubscriptionMinimumSpend copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrencyTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Usd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Aed)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.All)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Amd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Ang)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Aud)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Awg)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Azn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Bam)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Bbd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Bdt)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Bgn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Bif)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Bmd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Bnd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Bsd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Bwp)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Byn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Bzd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Brl)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Cad)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Cdf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Chf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Cny)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Czk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Dkk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Dop)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Dzd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Egp)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Etb)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Eur)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Fjd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Gbp)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Gel)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Gip)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Gmd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Gyd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Hkd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Hrk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Htg)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Idr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Ils)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Inr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Isk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Jmd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Jpy)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Kes)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Kgs)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Khr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Kmf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Krw)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Kyd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Kzt)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Lbp)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Lkr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Lrd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Lsl)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Mad)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Mdl)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Mga)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Mkd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Mmk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Mnt)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Mop)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Mro)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Mvr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Mwk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Mxn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Myr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Mzn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Nad)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Ngn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Nok)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Npr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Nzd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Pgk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Php)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Pkr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Pln)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Qar)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Ron)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Rsd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Rub)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Rwf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Sar)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Sbd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Scr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Sek)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Sgd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Sle)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Sll)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Sos)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Szl)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Thb)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Tjs)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Top)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Try)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Ttd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Tzs)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Uah)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Uzs)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Vnd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Vuv)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Wst)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Xaf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Xcd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Yer)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Zar)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Zmw)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Clp)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Djf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Gnf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Ugx)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Pyg)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Xof)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Xpf)]
    public void Validation_Works(
        SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Usd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Aed)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.All)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Amd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Ang)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Aud)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Awg)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Azn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Bam)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Bbd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Bdt)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Bgn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Bif)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Bmd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Bnd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Bsd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Bwp)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Byn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Bzd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Brl)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Cad)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Cdf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Chf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Cny)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Czk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Dkk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Dop)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Dzd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Egp)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Etb)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Eur)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Fjd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Gbp)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Gel)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Gip)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Gmd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Gyd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Hkd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Hrk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Htg)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Idr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Ils)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Inr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Isk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Jmd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Jpy)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Kes)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Kgs)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Khr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Kmf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Krw)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Kyd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Kzt)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Lbp)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Lkr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Lrd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Lsl)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Mad)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Mdl)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Mga)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Mkd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Mmk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Mnt)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Mop)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Mro)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Mvr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Mwk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Mxn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Myr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Mzn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Nad)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Ngn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Nok)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Npr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Nzd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Pgk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Php)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Pkr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Pln)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Qar)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Ron)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Rsd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Rub)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Rwf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Sar)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Sbd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Scr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Sek)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Sgd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Sle)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Sll)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Sos)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Szl)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Thb)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Tjs)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Top)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Try)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Ttd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Tzs)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Uah)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Uzs)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Vnd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Vuv)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Wst)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Xaf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Xcd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Yer)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Zar)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Zmw)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Clp)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Djf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Gnf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Ugx)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Pyg)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Xof)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency.Xpf)]
    public void SerializationRoundtrip_Works(
        SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethodTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.Charge)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.Invoice)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.None)]
    public void Validation_Works(
        SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.Charge)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.Invoice)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.None)]
    public void SerializationRoundtrip_Works(
        SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionProvisionResponseDataSubscriptionPriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionPrice
        {
            AddonID = "addonId",
            Amount = 0,
            BaseCharge = true,
            BillingCountryCode = "billingCountryCode",
            BlockSize = 0,
            Currency = SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Usd,
            FeatureID = "featureId",
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        Currency =
                            SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        Currency =
                            SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                    },
                    UpTo = 0,
                },
            ],
        };

        string expectedAddonID = "addonId";
        double expectedAmount = 0;
        bool expectedBaseCharge = true;
        string expectedBillingCountryCode = "billingCountryCode";
        double expectedBlockSize = 0;
        ApiEnum<
            string,
            SubscriptionProvisionResponseDataSubscriptionPriceCurrency
        > expectedCurrency = SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Usd;
        string expectedFeatureID = "featureId";
        List<SubscriptionProvisionResponseDataSubscriptionPriceTier> expectedTiers =
        [
            new()
            {
                FlatPrice = new()
                {
                    Amount = 0,
                    Currency =
                        SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                },
                UnitPrice = new()
                {
                    Amount = 0,
                    Currency =
                        SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                },
                UpTo = 0,
            },
        ];

        Assert.Equal(expectedAddonID, model.AddonID);
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedBaseCharge, model.BaseCharge);
        Assert.Equal(expectedBillingCountryCode, model.BillingCountryCode);
        Assert.Equal(expectedBlockSize, model.BlockSize);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedFeatureID, model.FeatureID);
        Assert.NotNull(model.Tiers);
        Assert.Equal(expectedTiers.Count, model.Tiers.Count);
        for (int i = 0; i < expectedTiers.Count; i++)
        {
            Assert.Equal(expectedTiers[i], model.Tiers[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionPrice
        {
            AddonID = "addonId",
            Amount = 0,
            BaseCharge = true,
            BillingCountryCode = "billingCountryCode",
            BlockSize = 0,
            Currency = SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Usd,
            FeatureID = "featureId",
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        Currency =
                            SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        Currency =
                            SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                    },
                    UpTo = 0,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionProvisionResponseDataSubscriptionPrice>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionPrice
        {
            AddonID = "addonId",
            Amount = 0,
            BaseCharge = true,
            BillingCountryCode = "billingCountryCode",
            BlockSize = 0,
            Currency = SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Usd,
            FeatureID = "featureId",
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        Currency =
                            SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        Currency =
                            SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                    },
                    UpTo = 0,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionProvisionResponseDataSubscriptionPrice>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedAddonID = "addonId";
        double expectedAmount = 0;
        bool expectedBaseCharge = true;
        string expectedBillingCountryCode = "billingCountryCode";
        double expectedBlockSize = 0;
        ApiEnum<
            string,
            SubscriptionProvisionResponseDataSubscriptionPriceCurrency
        > expectedCurrency = SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Usd;
        string expectedFeatureID = "featureId";
        List<SubscriptionProvisionResponseDataSubscriptionPriceTier> expectedTiers =
        [
            new()
            {
                FlatPrice = new()
                {
                    Amount = 0,
                    Currency =
                        SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                },
                UnitPrice = new()
                {
                    Amount = 0,
                    Currency =
                        SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                },
                UpTo = 0,
            },
        ];

        Assert.Equal(expectedAddonID, deserialized.AddonID);
        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedBaseCharge, deserialized.BaseCharge);
        Assert.Equal(expectedBillingCountryCode, deserialized.BillingCountryCode);
        Assert.Equal(expectedBlockSize, deserialized.BlockSize);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedFeatureID, deserialized.FeatureID);
        Assert.NotNull(deserialized.Tiers);
        Assert.Equal(expectedTiers.Count, deserialized.Tiers.Count);
        for (int i = 0; i < expectedTiers.Count; i++)
        {
            Assert.Equal(expectedTiers[i], deserialized.Tiers[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionPrice
        {
            AddonID = "addonId",
            Amount = 0,
            BaseCharge = true,
            BillingCountryCode = "billingCountryCode",
            BlockSize = 0,
            Currency = SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Usd,
            FeatureID = "featureId",
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        Currency =
                            SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        Currency =
                            SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                    },
                    UpTo = 0,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionPrice
        {
            AddonID = "addonId",
            FeatureID = "featureId",
        };

        Assert.Null(model.Amount);
        Assert.False(model.RawData.ContainsKey("amount"));
        Assert.Null(model.BaseCharge);
        Assert.False(model.RawData.ContainsKey("baseCharge"));
        Assert.Null(model.BillingCountryCode);
        Assert.False(model.RawData.ContainsKey("billingCountryCode"));
        Assert.Null(model.BlockSize);
        Assert.False(model.RawData.ContainsKey("blockSize"));
        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
        Assert.Null(model.Tiers);
        Assert.False(model.RawData.ContainsKey("tiers"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionPrice
        {
            AddonID = "addonId",
            FeatureID = "featureId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionPrice
        {
            AddonID = "addonId",
            FeatureID = "featureId",

            // Null should be interpreted as omitted for these properties
            Amount = null,
            BaseCharge = null,
            BillingCountryCode = null,
            BlockSize = null,
            Currency = null,
            Tiers = null,
        };

        Assert.Null(model.Amount);
        Assert.False(model.RawData.ContainsKey("amount"));
        Assert.Null(model.BaseCharge);
        Assert.False(model.RawData.ContainsKey("baseCharge"));
        Assert.Null(model.BillingCountryCode);
        Assert.False(model.RawData.ContainsKey("billingCountryCode"));
        Assert.Null(model.BlockSize);
        Assert.False(model.RawData.ContainsKey("blockSize"));
        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
        Assert.Null(model.Tiers);
        Assert.False(model.RawData.ContainsKey("tiers"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionPrice
        {
            AddonID = "addonId",
            FeatureID = "featureId",

            // Null should be interpreted as omitted for these properties
            Amount = null,
            BaseCharge = null,
            BillingCountryCode = null,
            BlockSize = null,
            Currency = null,
            Tiers = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionPrice
        {
            Amount = 0,
            BaseCharge = true,
            BillingCountryCode = "billingCountryCode",
            BlockSize = 0,
            Currency = SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Usd,
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        Currency =
                            SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        Currency =
                            SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                    },
                    UpTo = 0,
                },
            ],
        };

        Assert.Null(model.AddonID);
        Assert.False(model.RawData.ContainsKey("addonId"));
        Assert.Null(model.FeatureID);
        Assert.False(model.RawData.ContainsKey("featureId"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionPrice
        {
            Amount = 0,
            BaseCharge = true,
            BillingCountryCode = "billingCountryCode",
            BlockSize = 0,
            Currency = SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Usd,
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        Currency =
                            SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        Currency =
                            SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                    },
                    UpTo = 0,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionPrice
        {
            Amount = 0,
            BaseCharge = true,
            BillingCountryCode = "billingCountryCode",
            BlockSize = 0,
            Currency = SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Usd,
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        Currency =
                            SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        Currency =
                            SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                    },
                    UpTo = 0,
                },
            ],

            AddonID = null,
            FeatureID = null,
        };

        Assert.Null(model.AddonID);
        Assert.True(model.RawData.ContainsKey("addonId"));
        Assert.Null(model.FeatureID);
        Assert.True(model.RawData.ContainsKey("featureId"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionPrice
        {
            Amount = 0,
            BaseCharge = true,
            BillingCountryCode = "billingCountryCode",
            BlockSize = 0,
            Currency = SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Usd,
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        Currency =
                            SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        Currency =
                            SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                    },
                    UpTo = 0,
                },
            ],

            AddonID = null,
            FeatureID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionPrice
        {
            AddonID = "addonId",
            Amount = 0,
            BaseCharge = true,
            BillingCountryCode = "billingCountryCode",
            BlockSize = 0,
            Currency = SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Usd,
            FeatureID = "featureId",
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        Currency =
                            SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        Currency =
                            SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                    },
                    UpTo = 0,
                },
            ],
        };

        SubscriptionProvisionResponseDataSubscriptionPrice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionProvisionResponseDataSubscriptionPriceCurrencyTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Usd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Aed)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.All)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Amd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Ang)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Aud)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Awg)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Azn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Bam)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Bbd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Bdt)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Bgn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Bif)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Bmd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Bnd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Bsd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Bwp)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Byn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Bzd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Brl)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Cad)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Cdf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Chf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Cny)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Czk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Dkk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Dop)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Dzd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Egp)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Etb)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Eur)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Fjd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Gbp)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Gel)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Gip)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Gmd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Gyd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Hkd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Hrk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Htg)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Idr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Ils)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Inr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Isk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Jmd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Jpy)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Kes)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Kgs)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Khr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Kmf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Krw)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Kyd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Kzt)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Lbp)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Lkr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Lrd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Lsl)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Mad)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Mdl)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Mga)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Mkd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Mmk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Mnt)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Mop)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Mro)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Mvr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Mwk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Mxn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Myr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Mzn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Nad)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Ngn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Nok)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Npr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Nzd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Pgk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Php)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Pkr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Pln)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Qar)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Ron)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Rsd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Rub)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Rwf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Sar)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Sbd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Scr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Sek)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Sgd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Sle)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Sll)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Sos)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Szl)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Thb)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Tjs)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Top)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Try)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Ttd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Tzs)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Uah)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Uzs)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Vnd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Vuv)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Wst)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Xaf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Xcd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Yer)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Zar)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Zmw)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Clp)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Djf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Gnf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Ugx)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Pyg)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Xof)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Xpf)]
    public void Validation_Works(
        SubscriptionProvisionResponseDataSubscriptionPriceCurrency rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionPriceCurrency> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionPriceCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Usd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Aed)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.All)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Amd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Ang)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Aud)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Awg)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Azn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Bam)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Bbd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Bdt)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Bgn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Bif)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Bmd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Bnd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Bsd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Bwp)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Byn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Bzd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Brl)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Cad)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Cdf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Chf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Cny)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Czk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Dkk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Dop)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Dzd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Egp)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Etb)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Eur)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Fjd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Gbp)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Gel)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Gip)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Gmd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Gyd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Hkd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Hrk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Htg)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Idr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Ils)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Inr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Isk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Jmd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Jpy)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Kes)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Kgs)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Khr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Kmf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Krw)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Kyd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Kzt)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Lbp)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Lkr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Lrd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Lsl)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Mad)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Mdl)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Mga)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Mkd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Mmk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Mnt)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Mop)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Mro)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Mvr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Mwk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Mxn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Myr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Mzn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Nad)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Ngn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Nok)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Npr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Nzd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Pgk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Php)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Pkr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Pln)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Qar)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Ron)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Rsd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Rub)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Rwf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Sar)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Sbd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Scr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Sek)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Sgd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Sle)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Sll)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Sos)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Szl)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Thb)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Tjs)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Top)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Try)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Ttd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Tzs)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Uah)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Uzs)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Vnd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Vuv)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Wst)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Xaf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Xcd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Yer)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Zar)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Zmw)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Clp)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Djf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Gnf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Ugx)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Pyg)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Xof)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceCurrency.Xpf)]
    public void SerializationRoundtrip_Works(
        SubscriptionProvisionResponseDataSubscriptionPriceCurrency rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionPriceCurrency> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionPriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionPriceCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionPriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionProvisionResponseDataSubscriptionPriceTierTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionPriceTier
        {
            FlatPrice = new()
            {
                Amount = 0,
                Currency =
                    SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
            },
            UnitPrice = new()
            {
                Amount = 0,
                Currency =
                    SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
            },
            UpTo = 0,
        };

        SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPrice expectedFlatPrice = new()
        {
            Amount = 0,
            Currency = SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
        };
        SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPrice expectedUnitPrice = new()
        {
            Amount = 0,
            Currency = SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
        };
        double expectedUpTo = 0;

        Assert.Equal(expectedFlatPrice, model.FlatPrice);
        Assert.Equal(expectedUnitPrice, model.UnitPrice);
        Assert.Equal(expectedUpTo, model.UpTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionPriceTier
        {
            FlatPrice = new()
            {
                Amount = 0,
                Currency =
                    SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
            },
            UnitPrice = new()
            {
                Amount = 0,
                Currency =
                    SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
            },
            UpTo = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionProvisionResponseDataSubscriptionPriceTier>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionPriceTier
        {
            FlatPrice = new()
            {
                Amount = 0,
                Currency =
                    SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
            },
            UnitPrice = new()
            {
                Amount = 0,
                Currency =
                    SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
            },
            UpTo = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionProvisionResponseDataSubscriptionPriceTier>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPrice expectedFlatPrice = new()
        {
            Amount = 0,
            Currency = SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
        };
        SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPrice expectedUnitPrice = new()
        {
            Amount = 0,
            Currency = SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
        };
        double expectedUpTo = 0;

        Assert.Equal(expectedFlatPrice, deserialized.FlatPrice);
        Assert.Equal(expectedUnitPrice, deserialized.UnitPrice);
        Assert.Equal(expectedUpTo, deserialized.UpTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionPriceTier
        {
            FlatPrice = new()
            {
                Amount = 0,
                Currency =
                    SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
            },
            UnitPrice = new()
            {
                Amount = 0,
                Currency =
                    SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
            },
            UpTo = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionPriceTier { };

        Assert.Null(model.FlatPrice);
        Assert.False(model.RawData.ContainsKey("flatPrice"));
        Assert.Null(model.UnitPrice);
        Assert.False(model.RawData.ContainsKey("unitPrice"));
        Assert.Null(model.UpTo);
        Assert.False(model.RawData.ContainsKey("upTo"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionPriceTier { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionPriceTier
        {
            // Null should be interpreted as omitted for these properties
            FlatPrice = null,
            UnitPrice = null,
            UpTo = null,
        };

        Assert.Null(model.FlatPrice);
        Assert.False(model.RawData.ContainsKey("flatPrice"));
        Assert.Null(model.UnitPrice);
        Assert.False(model.RawData.ContainsKey("unitPrice"));
        Assert.Null(model.UpTo);
        Assert.False(model.RawData.ContainsKey("upTo"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionPriceTier
        {
            // Null should be interpreted as omitted for these properties
            FlatPrice = null,
            UnitPrice = null,
            UpTo = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionPriceTier
        {
            FlatPrice = new()
            {
                Amount = 0,
                Currency =
                    SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
            },
            UnitPrice = new()
            {
                Amount = 0,
                Currency =
                    SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
            },
            UpTo = 0,
        };

        SubscriptionProvisionResponseDataSubscriptionPriceTier copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPrice
        {
            Amount = 0,
            Currency = SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
        };

        double expectedAmount = 0;
        ApiEnum<
            string,
            SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency
        > expectedCurrency =
            SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPrice
        {
            Amount = 0,
            Currency = SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPrice>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPrice
        {
            Amount = 0,
            Currency = SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPrice>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        ApiEnum<
            string,
            SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency
        > expectedCurrency =
            SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPrice
        {
            Amount = 0,
            Currency = SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPrice
        {
            Amount = 0,
            Currency = SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
        };

        SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPrice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrencyTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Aed)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.All)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Amd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Ang)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Aud)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Awg)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Azn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Bam)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Bbd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Bdt)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Bgn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Bif)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Bmd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Bnd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Bsd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Bwp)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Byn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Bzd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Brl)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Cad)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Cdf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Chf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Cny)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Czk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Dkk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Dop)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Dzd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Egp)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Etb)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Eur)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Fjd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Gbp)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Gel)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Gip)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Gmd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Gyd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Hkd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Hrk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Htg)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Idr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Ils)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Inr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Isk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Jmd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Jpy)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Kes)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Kgs)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Khr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Kmf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Krw)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Kyd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Kzt)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Lbp)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Lkr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Lrd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Lsl)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mad)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mdl)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mga)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mkd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mmk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mnt)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mop)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mro)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mvr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mwk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mxn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Myr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mzn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Nad)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Ngn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Nok)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Npr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Nzd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Pgk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Php)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Pkr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Pln)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Qar)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Ron)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Rsd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Rub)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Rwf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Sar)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Sbd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Scr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Sek)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Sgd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Sle)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Sll)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Sos)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Szl)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Thb)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Tjs)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Top)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Try)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Ttd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Tzs)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Uah)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Uzs)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Vnd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Vuv)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Wst)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Xaf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Xcd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Yer)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Zar)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Zmw)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Clp)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Djf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Gnf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Ugx)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Pyg)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Xof)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Xpf)]
    public void Validation_Works(
        SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Aed)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.All)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Amd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Ang)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Aud)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Awg)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Azn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Bam)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Bbd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Bdt)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Bgn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Bif)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Bmd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Bnd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Bsd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Bwp)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Byn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Bzd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Brl)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Cad)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Cdf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Chf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Cny)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Czk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Dkk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Dop)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Dzd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Egp)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Etb)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Eur)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Fjd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Gbp)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Gel)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Gip)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Gmd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Gyd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Hkd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Hrk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Htg)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Idr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Ils)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Inr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Isk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Jmd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Jpy)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Kes)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Kgs)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Khr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Kmf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Krw)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Kyd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Kzt)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Lbp)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Lkr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Lrd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Lsl)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mad)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mdl)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mga)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mkd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mmk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mnt)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mop)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mro)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mvr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mwk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mxn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Myr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Mzn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Nad)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Ngn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Nok)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Npr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Nzd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Pgk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Php)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Pkr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Pln)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Qar)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Ron)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Rsd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Rub)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Rwf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Sar)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Sbd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Scr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Sek)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Sgd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Sle)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Sll)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Sos)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Szl)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Thb)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Tjs)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Top)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Try)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Ttd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Tzs)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Uah)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Uzs)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Vnd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Vuv)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Wst)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Xaf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Xcd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Yer)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Zar)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Zmw)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Clp)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Djf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Gnf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Ugx)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Pyg)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Xof)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Xpf)]
    public void SerializationRoundtrip_Works(
        SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPrice
        {
            Amount = 0,
            Currency = SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
        };

        double expectedAmount = 0;
        ApiEnum<
            string,
            SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency
        > expectedCurrency =
            SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPrice
        {
            Amount = 0,
            Currency = SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPrice>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPrice
        {
            Amount = 0,
            Currency = SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPrice>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        ApiEnum<
            string,
            SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency
        > expectedCurrency =
            SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPrice
        {
            Amount = 0,
            Currency = SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPrice
        {
            Amount = 0,
            Currency = SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
        };

        SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPrice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrencyTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Aed)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.All)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Amd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Ang)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Aud)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Awg)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Azn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Bam)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Bbd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Bdt)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Bgn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Bif)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Bmd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Bnd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Bsd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Bwp)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Byn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Bzd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Brl)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Cad)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Cdf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Chf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Cny)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Czk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Dkk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Dop)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Dzd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Egp)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Etb)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Eur)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Fjd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Gbp)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Gel)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Gip)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Gmd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Gyd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Hkd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Hrk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Htg)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Idr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Ils)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Inr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Isk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Jmd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Jpy)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Kes)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Kgs)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Khr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Kmf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Krw)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Kyd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Kzt)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Lbp)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Lkr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Lrd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Lsl)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mad)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mdl)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mga)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mkd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mmk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mnt)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mop)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mro)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mvr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mwk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mxn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Myr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mzn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Nad)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Ngn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Nok)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Npr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Nzd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Pgk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Php)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Pkr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Pln)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Qar)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Ron)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Rsd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Rub)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Rwf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Sar)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Sbd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Scr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Sek)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Sgd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Sle)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Sll)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Sos)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Szl)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Thb)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Tjs)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Top)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Try)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Ttd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Tzs)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Uah)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Uzs)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Vnd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Vuv)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Wst)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Xaf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Xcd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Yer)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Zar)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Zmw)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Clp)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Djf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Gnf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Ugx)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Pyg)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Xof)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Xpf)]
    public void Validation_Works(
        SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Aed)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.All)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Amd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Ang)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Aud)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Awg)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Azn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Bam)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Bbd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Bdt)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Bgn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Bif)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Bmd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Bnd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Bsd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Bwp)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Byn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Bzd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Brl)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Cad)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Cdf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Chf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Cny)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Czk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Dkk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Dop)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Dzd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Egp)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Etb)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Eur)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Fjd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Gbp)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Gel)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Gip)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Gmd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Gyd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Hkd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Hrk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Htg)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Idr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Ils)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Inr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Isk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Jmd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Jpy)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Kes)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Kgs)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Khr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Kmf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Krw)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Kyd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Kzt)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Lbp)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Lkr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Lrd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Lsl)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mad)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mdl)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mga)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mkd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mmk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mnt)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mop)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mro)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mvr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mwk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mxn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Myr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Mzn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Nad)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Ngn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Nok)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Npr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Nzd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Pgk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Php)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Pkr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Pln)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Qar)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Ron)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Rsd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Rub)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Rwf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Sar)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Sbd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Scr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Sek)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Sgd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Sle)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Sll)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Sos)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Szl)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Thb)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Tjs)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Top)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Try)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Ttd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Tzs)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Uah)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Uzs)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Vnd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Vuv)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Wst)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Xaf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Xcd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Yer)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Zar)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Zmw)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Clp)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Djf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Gnf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Ugx)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Pyg)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Xof)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Xpf)]
    public void SerializationRoundtrip_Works(
        SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlement
        {
            ID = "id",
            Type = SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementType.Feature,
        };

        string expectedID = "id";
        ApiEnum<
            string,
            SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementType
        > expectedType =
            SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementType.Feature;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlement
        {
            ID = "id",
            Type = SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementType.Feature,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlement>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlement
        {
            ID = "id",
            Type = SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementType.Feature,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlement>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        ApiEnum<
            string,
            SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementType
        > expectedType =
            SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementType.Feature;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlement
        {
            ID = "id",
            Type = SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementType.Feature,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlement
        {
            ID = "id",
            Type = SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementType.Feature,
        };

        SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlement copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementTypeTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementType.Feature)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementType.Credit)]
    public void Validation_Works(
        SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementType
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementType
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementType.Feature)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementType.Credit)]
    public void SerializationRoundtrip_Works(
        SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementType
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementType
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementType
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementType
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionProvisionResponseDataSubscriptionTrialTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionTrial
        {
            TrialEndBehavior =
                SubscriptionProvisionResponseDataSubscriptionTrialTrialEndBehavior.ConvertToPaid,
        };

        ApiEnum<
            string,
            SubscriptionProvisionResponseDataSubscriptionTrialTrialEndBehavior
        > expectedTrialEndBehavior =
            SubscriptionProvisionResponseDataSubscriptionTrialTrialEndBehavior.ConvertToPaid;

        Assert.Equal(expectedTrialEndBehavior, model.TrialEndBehavior);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionTrial
        {
            TrialEndBehavior =
                SubscriptionProvisionResponseDataSubscriptionTrialTrialEndBehavior.ConvertToPaid,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionProvisionResponseDataSubscriptionTrial>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionTrial
        {
            TrialEndBehavior =
                SubscriptionProvisionResponseDataSubscriptionTrialTrialEndBehavior.ConvertToPaid,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionProvisionResponseDataSubscriptionTrial>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            SubscriptionProvisionResponseDataSubscriptionTrialTrialEndBehavior
        > expectedTrialEndBehavior =
            SubscriptionProvisionResponseDataSubscriptionTrialTrialEndBehavior.ConvertToPaid;

        Assert.Equal(expectedTrialEndBehavior, deserialized.TrialEndBehavior);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionTrial
        {
            TrialEndBehavior =
                SubscriptionProvisionResponseDataSubscriptionTrialTrialEndBehavior.ConvertToPaid,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionTrial
        {
            TrialEndBehavior =
                SubscriptionProvisionResponseDataSubscriptionTrialTrialEndBehavior.ConvertToPaid,
        };

        SubscriptionProvisionResponseDataSubscriptionTrial copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionProvisionResponseDataSubscriptionTrialTrialEndBehaviorTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionTrialTrialEndBehavior.ConvertToPaid)]
    [InlineData(
        SubscriptionProvisionResponseDataSubscriptionTrialTrialEndBehavior.CancelSubscription
    )]
    public void Validation_Works(
        SubscriptionProvisionResponseDataSubscriptionTrialTrialEndBehavior rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionTrialTrialEndBehavior> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionTrialTrialEndBehavior>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionTrialTrialEndBehavior.ConvertToPaid)]
    [InlineData(
        SubscriptionProvisionResponseDataSubscriptionTrialTrialEndBehavior.CancelSubscription
    )]
    public void SerializationRoundtrip_Works(
        SubscriptionProvisionResponseDataSubscriptionTrialTrialEndBehavior rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionTrialTrialEndBehavior> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionTrialTrialEndBehavior>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionTrialTrialEndBehavior>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionTrialTrialEndBehavior>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
