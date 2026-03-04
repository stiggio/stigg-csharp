using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Subscriptions;

namespace Stigg.Client.Tests.Models.V1.Subscriptions;

public class SubscriptionSubscriptionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionSubscription
        {
            Data = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customerId",
                PaymentCollection = PaymentCollection.NotRequired,
                PlanID = "planId",
                PricingType = PricingType.Free,
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = Status.PaymentPending,
                Addons = [new() { ID = "id", Quantity = 0 }],
                BillingCycleAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Budget = new() { HasSoftLimit = true, Limit = 0 },
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason = CancelReason.UpgradeOrDowngrade,
                Coupons =
                [
                    new()
                    {
                        ID = "id",
                        Name = "name",
                        Status = CouponStatus.Active,
                        AmountsOff =
                        [
                            new() { Amount = 0, Currency = CouponAmountsOffCurrency.Usd },
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
                        ScheduleStatus = ScheduleStatus.PendingPayment,
                        SubscriptionScheduleType = SubscriptionScheduleType.Downgrade,
                        TargetPackage = new("id"),
                    },
                ],
                LatestInvoice = new()
                {
                    BillingID = "billingId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    RequiresAction = true,
                    Status = LatestInvoiceStatus.Open,
                    AmountDue = 0,
                    BillingReason = BillingReason.BillingCycle,
                    Currency = "currency",
                    PdfUrl = "pdfUrl",
                    Total = 0,
                },
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MinimumSpend = new() { Amount = 0, Currency = DataMinimumSpendCurrency.Usd },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod = DataPaymentCollectionMethod.Charge,
                Prices =
                [
                    new()
                    {
                        AddonID = "addonId",
                        Amount = 0,
                        BaseCharge = true,
                        BillingCountryCode = "billingCountryCode",
                        BlockSize = 0,
                        Currency = PriceCurrency.Usd,
                        FeatureID = "featureId",
                        Tiers =
                        [
                            new()
                            {
                                FlatPrice = new()
                                {
                                    Amount = 0,
                                    Currency = PriceTierFlatPriceCurrency.Usd,
                                },
                                UnitPrice = new()
                                {
                                    Amount = 0,
                                    Currency = PriceTierUnitPriceCurrency.Usd,
                                },
                                UpTo = 0,
                            },
                        ],
                    },
                ],
                ResourceID = "resourceId",
                SubscriptionEntitlements =
                [
                    new() { ID = "id", Type = DataSubscriptionEntitlementType.Feature },
                ],
                Trial = new(TrialTrialEndBehavior.ConvertToPaid),
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        Data expectedData = new()
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = PaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = PricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = Status.PaymentPending,
            Addons = [new() { ID = "id", Quantity = 0 }],
            BillingCycleAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = CancelReason.UpgradeOrDowngrade,
            Coupons =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    Status = CouponStatus.Active,
                    AmountsOff = [new() { Amount = 0, Currency = CouponAmountsOffCurrency.Usd }],
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
                    ScheduleStatus = ScheduleStatus.PendingPayment,
                    SubscriptionScheduleType = SubscriptionScheduleType.Downgrade,
                    TargetPackage = new("id"),
                },
            ],
            LatestInvoice = new()
            {
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RequiresAction = true,
                Status = LatestInvoiceStatus.Open,
                AmountDue = 0,
                BillingReason = BillingReason.BillingCycle,
                Currency = "currency",
                PdfUrl = "pdfUrl",
                Total = 0,
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MinimumSpend = new() { Amount = 0, Currency = DataMinimumSpendCurrency.Usd },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod = DataPaymentCollectionMethod.Charge,
            Prices =
            [
                new()
                {
                    AddonID = "addonId",
                    Amount = 0,
                    BaseCharge = true,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    Currency = PriceCurrency.Usd,
                    FeatureID = "featureId",
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency = PriceTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency = PriceTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            ResourceID = "resourceId",
            SubscriptionEntitlements =
            [
                new() { ID = "id", Type = DataSubscriptionEntitlementType.Feature },
            ],
            Trial = new(TrialTrialEndBehavior.ConvertToPaid),
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionSubscription
        {
            Data = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customerId",
                PaymentCollection = PaymentCollection.NotRequired,
                PlanID = "planId",
                PricingType = PricingType.Free,
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = Status.PaymentPending,
                Addons = [new() { ID = "id", Quantity = 0 }],
                BillingCycleAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Budget = new() { HasSoftLimit = true, Limit = 0 },
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason = CancelReason.UpgradeOrDowngrade,
                Coupons =
                [
                    new()
                    {
                        ID = "id",
                        Name = "name",
                        Status = CouponStatus.Active,
                        AmountsOff =
                        [
                            new() { Amount = 0, Currency = CouponAmountsOffCurrency.Usd },
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
                        ScheduleStatus = ScheduleStatus.PendingPayment,
                        SubscriptionScheduleType = SubscriptionScheduleType.Downgrade,
                        TargetPackage = new("id"),
                    },
                ],
                LatestInvoice = new()
                {
                    BillingID = "billingId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    RequiresAction = true,
                    Status = LatestInvoiceStatus.Open,
                    AmountDue = 0,
                    BillingReason = BillingReason.BillingCycle,
                    Currency = "currency",
                    PdfUrl = "pdfUrl",
                    Total = 0,
                },
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MinimumSpend = new() { Amount = 0, Currency = DataMinimumSpendCurrency.Usd },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod = DataPaymentCollectionMethod.Charge,
                Prices =
                [
                    new()
                    {
                        AddonID = "addonId",
                        Amount = 0,
                        BaseCharge = true,
                        BillingCountryCode = "billingCountryCode",
                        BlockSize = 0,
                        Currency = PriceCurrency.Usd,
                        FeatureID = "featureId",
                        Tiers =
                        [
                            new()
                            {
                                FlatPrice = new()
                                {
                                    Amount = 0,
                                    Currency = PriceTierFlatPriceCurrency.Usd,
                                },
                                UnitPrice = new()
                                {
                                    Amount = 0,
                                    Currency = PriceTierUnitPriceCurrency.Usd,
                                },
                                UpTo = 0,
                            },
                        ],
                    },
                ],
                ResourceID = "resourceId",
                SubscriptionEntitlements =
                [
                    new() { ID = "id", Type = DataSubscriptionEntitlementType.Feature },
                ],
                Trial = new(TrialTrialEndBehavior.ConvertToPaid),
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionSubscription>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionSubscription
        {
            Data = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customerId",
                PaymentCollection = PaymentCollection.NotRequired,
                PlanID = "planId",
                PricingType = PricingType.Free,
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = Status.PaymentPending,
                Addons = [new() { ID = "id", Quantity = 0 }],
                BillingCycleAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Budget = new() { HasSoftLimit = true, Limit = 0 },
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason = CancelReason.UpgradeOrDowngrade,
                Coupons =
                [
                    new()
                    {
                        ID = "id",
                        Name = "name",
                        Status = CouponStatus.Active,
                        AmountsOff =
                        [
                            new() { Amount = 0, Currency = CouponAmountsOffCurrency.Usd },
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
                        ScheduleStatus = ScheduleStatus.PendingPayment,
                        SubscriptionScheduleType = SubscriptionScheduleType.Downgrade,
                        TargetPackage = new("id"),
                    },
                ],
                LatestInvoice = new()
                {
                    BillingID = "billingId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    RequiresAction = true,
                    Status = LatestInvoiceStatus.Open,
                    AmountDue = 0,
                    BillingReason = BillingReason.BillingCycle,
                    Currency = "currency",
                    PdfUrl = "pdfUrl",
                    Total = 0,
                },
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MinimumSpend = new() { Amount = 0, Currency = DataMinimumSpendCurrency.Usd },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod = DataPaymentCollectionMethod.Charge,
                Prices =
                [
                    new()
                    {
                        AddonID = "addonId",
                        Amount = 0,
                        BaseCharge = true,
                        BillingCountryCode = "billingCountryCode",
                        BlockSize = 0,
                        Currency = PriceCurrency.Usd,
                        FeatureID = "featureId",
                        Tiers =
                        [
                            new()
                            {
                                FlatPrice = new()
                                {
                                    Amount = 0,
                                    Currency = PriceTierFlatPriceCurrency.Usd,
                                },
                                UnitPrice = new()
                                {
                                    Amount = 0,
                                    Currency = PriceTierUnitPriceCurrency.Usd,
                                },
                                UpTo = 0,
                            },
                        ],
                    },
                ],
                ResourceID = "resourceId",
                SubscriptionEntitlements =
                [
                    new() { ID = "id", Type = DataSubscriptionEntitlementType.Feature },
                ],
                Trial = new(TrialTrialEndBehavior.ConvertToPaid),
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionSubscription>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Data expectedData = new()
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = PaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = PricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = Status.PaymentPending,
            Addons = [new() { ID = "id", Quantity = 0 }],
            BillingCycleAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = CancelReason.UpgradeOrDowngrade,
            Coupons =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    Status = CouponStatus.Active,
                    AmountsOff = [new() { Amount = 0, Currency = CouponAmountsOffCurrency.Usd }],
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
                    ScheduleStatus = ScheduleStatus.PendingPayment,
                    SubscriptionScheduleType = SubscriptionScheduleType.Downgrade,
                    TargetPackage = new("id"),
                },
            ],
            LatestInvoice = new()
            {
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RequiresAction = true,
                Status = LatestInvoiceStatus.Open,
                AmountDue = 0,
                BillingReason = BillingReason.BillingCycle,
                Currency = "currency",
                PdfUrl = "pdfUrl",
                Total = 0,
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MinimumSpend = new() { Amount = 0, Currency = DataMinimumSpendCurrency.Usd },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod = DataPaymentCollectionMethod.Charge,
            Prices =
            [
                new()
                {
                    AddonID = "addonId",
                    Amount = 0,
                    BaseCharge = true,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    Currency = PriceCurrency.Usd,
                    FeatureID = "featureId",
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency = PriceTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency = PriceTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            ResourceID = "resourceId",
            SubscriptionEntitlements =
            [
                new() { ID = "id", Type = DataSubscriptionEntitlementType.Feature },
            ],
            Trial = new(TrialTrialEndBehavior.ConvertToPaid),
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionSubscription
        {
            Data = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customerId",
                PaymentCollection = PaymentCollection.NotRequired,
                PlanID = "planId",
                PricingType = PricingType.Free,
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = Status.PaymentPending,
                Addons = [new() { ID = "id", Quantity = 0 }],
                BillingCycleAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Budget = new() { HasSoftLimit = true, Limit = 0 },
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason = CancelReason.UpgradeOrDowngrade,
                Coupons =
                [
                    new()
                    {
                        ID = "id",
                        Name = "name",
                        Status = CouponStatus.Active,
                        AmountsOff =
                        [
                            new() { Amount = 0, Currency = CouponAmountsOffCurrency.Usd },
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
                        ScheduleStatus = ScheduleStatus.PendingPayment,
                        SubscriptionScheduleType = SubscriptionScheduleType.Downgrade,
                        TargetPackage = new("id"),
                    },
                ],
                LatestInvoice = new()
                {
                    BillingID = "billingId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    RequiresAction = true,
                    Status = LatestInvoiceStatus.Open,
                    AmountDue = 0,
                    BillingReason = BillingReason.BillingCycle,
                    Currency = "currency",
                    PdfUrl = "pdfUrl",
                    Total = 0,
                },
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MinimumSpend = new() { Amount = 0, Currency = DataMinimumSpendCurrency.Usd },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod = DataPaymentCollectionMethod.Charge,
                Prices =
                [
                    new()
                    {
                        AddonID = "addonId",
                        Amount = 0,
                        BaseCharge = true,
                        BillingCountryCode = "billingCountryCode",
                        BlockSize = 0,
                        Currency = PriceCurrency.Usd,
                        FeatureID = "featureId",
                        Tiers =
                        [
                            new()
                            {
                                FlatPrice = new()
                                {
                                    Amount = 0,
                                    Currency = PriceTierFlatPriceCurrency.Usd,
                                },
                                UnitPrice = new()
                                {
                                    Amount = 0,
                                    Currency = PriceTierUnitPriceCurrency.Usd,
                                },
                                UpTo = 0,
                            },
                        ],
                    },
                ],
                ResourceID = "resourceId",
                SubscriptionEntitlements =
                [
                    new() { ID = "id", Type = DataSubscriptionEntitlementType.Feature },
                ],
                Trial = new(TrialTrialEndBehavior.ConvertToPaid),
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionSubscription
        {
            Data = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customerId",
                PaymentCollection = PaymentCollection.NotRequired,
                PlanID = "planId",
                PricingType = PricingType.Free,
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = Status.PaymentPending,
                Addons = [new() { ID = "id", Quantity = 0 }],
                BillingCycleAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Budget = new() { HasSoftLimit = true, Limit = 0 },
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason = CancelReason.UpgradeOrDowngrade,
                Coupons =
                [
                    new()
                    {
                        ID = "id",
                        Name = "name",
                        Status = CouponStatus.Active,
                        AmountsOff =
                        [
                            new() { Amount = 0, Currency = CouponAmountsOffCurrency.Usd },
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
                        ScheduleStatus = ScheduleStatus.PendingPayment,
                        SubscriptionScheduleType = SubscriptionScheduleType.Downgrade,
                        TargetPackage = new("id"),
                    },
                ],
                LatestInvoice = new()
                {
                    BillingID = "billingId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    RequiresAction = true,
                    Status = LatestInvoiceStatus.Open,
                    AmountDue = 0,
                    BillingReason = BillingReason.BillingCycle,
                    Currency = "currency",
                    PdfUrl = "pdfUrl",
                    Total = 0,
                },
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MinimumSpend = new() { Amount = 0, Currency = DataMinimumSpendCurrency.Usd },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod = DataPaymentCollectionMethod.Charge,
                Prices =
                [
                    new()
                    {
                        AddonID = "addonId",
                        Amount = 0,
                        BaseCharge = true,
                        BillingCountryCode = "billingCountryCode",
                        BlockSize = 0,
                        Currency = PriceCurrency.Usd,
                        FeatureID = "featureId",
                        Tiers =
                        [
                            new()
                            {
                                FlatPrice = new()
                                {
                                    Amount = 0,
                                    Currency = PriceTierFlatPriceCurrency.Usd,
                                },
                                UnitPrice = new()
                                {
                                    Amount = 0,
                                    Currency = PriceTierUnitPriceCurrency.Usd,
                                },
                                UpTo = 0,
                            },
                        ],
                    },
                ],
                ResourceID = "resourceId",
                SubscriptionEntitlements =
                [
                    new() { ID = "id", Type = DataSubscriptionEntitlementType.Feature },
                ],
                Trial = new(TrialTrialEndBehavior.ConvertToPaid),
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        SubscriptionSubscription copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Data
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = PaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = PricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = Status.PaymentPending,
            Addons = [new() { ID = "id", Quantity = 0 }],
            BillingCycleAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = CancelReason.UpgradeOrDowngrade,
            Coupons =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    Status = CouponStatus.Active,
                    AmountsOff = [new() { Amount = 0, Currency = CouponAmountsOffCurrency.Usd }],
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
                    ScheduleStatus = ScheduleStatus.PendingPayment,
                    SubscriptionScheduleType = SubscriptionScheduleType.Downgrade,
                    TargetPackage = new("id"),
                },
            ],
            LatestInvoice = new()
            {
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RequiresAction = true,
                Status = LatestInvoiceStatus.Open,
                AmountDue = 0,
                BillingReason = BillingReason.BillingCycle,
                Currency = "currency",
                PdfUrl = "pdfUrl",
                Total = 0,
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MinimumSpend = new() { Amount = 0, Currency = DataMinimumSpendCurrency.Usd },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod = DataPaymentCollectionMethod.Charge,
            Prices =
            [
                new()
                {
                    AddonID = "addonId",
                    Amount = 0,
                    BaseCharge = true,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    Currency = PriceCurrency.Usd,
                    FeatureID = "featureId",
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency = PriceTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency = PriceTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            ResourceID = "resourceId",
            SubscriptionEntitlements =
            [
                new() { ID = "id", Type = DataSubscriptionEntitlementType.Feature },
            ],
            Trial = new(TrialTrialEndBehavior.ConvertToPaid),
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        string expectedBillingID = "billingId";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomerID = "customerId";
        ApiEnum<string, PaymentCollection> expectedPaymentCollection =
            PaymentCollection.NotRequired;
        string expectedPlanID = "planId";
        ApiEnum<string, PricingType> expectedPricingType = PricingType.Free;
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, Status> expectedStatus = Status.PaymentPending;
        List<DataAddon> expectedAddons = [new() { ID = "id", Quantity = 0 }];
        DateTimeOffset expectedBillingCycleAnchor = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        DataBudget expectedBudget = new() { HasSoftLimit = true, Limit = 0 };
        DateTimeOffset expectedCancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, CancelReason> expectedCancelReason = CancelReason.UpgradeOrDowngrade;
        List<Coupon> expectedCoupons =
        [
            new()
            {
                ID = "id",
                Name = "name",
                Status = CouponStatus.Active,
                AmountsOff = [new() { Amount = 0, Currency = CouponAmountsOffCurrency.Usd }],
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
        List<DataFutureUpdate> expectedFutureUpdates =
        [
            new()
            {
                ScheduledExecutionTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ScheduleStatus = ScheduleStatus.PendingPayment,
                SubscriptionScheduleType = SubscriptionScheduleType.Downgrade,
                TargetPackage = new("id"),
            },
        ];
        LatestInvoice expectedLatestInvoice = new()
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = LatestInvoiceStatus.Open,
            AmountDue = 0,
            BillingReason = BillingReason.BillingCycle,
            Currency = "currency",
            PdfUrl = "pdfUrl",
            Total = 0,
        };
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        DataMinimumSpend expectedMinimumSpend = new()
        {
            Amount = 0,
            Currency = DataMinimumSpendCurrency.Usd,
        };
        string expectedPayingCustomerID = "payingCustomerId";
        ApiEnum<string, DataPaymentCollectionMethod> expectedPaymentCollectionMethod =
            DataPaymentCollectionMethod.Charge;
        List<Price> expectedPrices =
        [
            new()
            {
                AddonID = "addonId",
                Amount = 0,
                BaseCharge = true,
                BillingCountryCode = "billingCountryCode",
                BlockSize = 0,
                Currency = PriceCurrency.Usd,
                FeatureID = "featureId",
                Tiers =
                [
                    new()
                    {
                        FlatPrice = new() { Amount = 0, Currency = PriceTierFlatPriceCurrency.Usd },
                        UnitPrice = new() { Amount = 0, Currency = PriceTierUnitPriceCurrency.Usd },
                        UpTo = 0,
                    },
                ],
            },
        ];
        string expectedResourceID = "resourceId";
        List<DataSubscriptionEntitlement> expectedSubscriptionEntitlements =
        [
            new() { ID = "id", Type = DataSubscriptionEntitlementType.Feature },
        ];
        Trial expectedTrial = new(TrialTrialEndBehavior.ConvertToPaid);
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
        var model = new Data
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = PaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = PricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = Status.PaymentPending,
            Addons = [new() { ID = "id", Quantity = 0 }],
            BillingCycleAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = CancelReason.UpgradeOrDowngrade,
            Coupons =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    Status = CouponStatus.Active,
                    AmountsOff = [new() { Amount = 0, Currency = CouponAmountsOffCurrency.Usd }],
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
                    ScheduleStatus = ScheduleStatus.PendingPayment,
                    SubscriptionScheduleType = SubscriptionScheduleType.Downgrade,
                    TargetPackage = new("id"),
                },
            ],
            LatestInvoice = new()
            {
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RequiresAction = true,
                Status = LatestInvoiceStatus.Open,
                AmountDue = 0,
                BillingReason = BillingReason.BillingCycle,
                Currency = "currency",
                PdfUrl = "pdfUrl",
                Total = 0,
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MinimumSpend = new() { Amount = 0, Currency = DataMinimumSpendCurrency.Usd },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod = DataPaymentCollectionMethod.Charge,
            Prices =
            [
                new()
                {
                    AddonID = "addonId",
                    Amount = 0,
                    BaseCharge = true,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    Currency = PriceCurrency.Usd,
                    FeatureID = "featureId",
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency = PriceTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency = PriceTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            ResourceID = "resourceId",
            SubscriptionEntitlements =
            [
                new() { ID = "id", Type = DataSubscriptionEntitlementType.Feature },
            ],
            Trial = new(TrialTrialEndBehavior.ConvertToPaid),
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Data
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = PaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = PricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = Status.PaymentPending,
            Addons = [new() { ID = "id", Quantity = 0 }],
            BillingCycleAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = CancelReason.UpgradeOrDowngrade,
            Coupons =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    Status = CouponStatus.Active,
                    AmountsOff = [new() { Amount = 0, Currency = CouponAmountsOffCurrency.Usd }],
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
                    ScheduleStatus = ScheduleStatus.PendingPayment,
                    SubscriptionScheduleType = SubscriptionScheduleType.Downgrade,
                    TargetPackage = new("id"),
                },
            ],
            LatestInvoice = new()
            {
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RequiresAction = true,
                Status = LatestInvoiceStatus.Open,
                AmountDue = 0,
                BillingReason = BillingReason.BillingCycle,
                Currency = "currency",
                PdfUrl = "pdfUrl",
                Total = 0,
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MinimumSpend = new() { Amount = 0, Currency = DataMinimumSpendCurrency.Usd },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod = DataPaymentCollectionMethod.Charge,
            Prices =
            [
                new()
                {
                    AddonID = "addonId",
                    Amount = 0,
                    BaseCharge = true,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    Currency = PriceCurrency.Usd,
                    FeatureID = "featureId",
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency = PriceTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency = PriceTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            ResourceID = "resourceId",
            SubscriptionEntitlements =
            [
                new() { ID = "id", Type = DataSubscriptionEntitlementType.Feature },
            ],
            Trial = new(TrialTrialEndBehavior.ConvertToPaid),
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedBillingID = "billingId";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomerID = "customerId";
        ApiEnum<string, PaymentCollection> expectedPaymentCollection =
            PaymentCollection.NotRequired;
        string expectedPlanID = "planId";
        ApiEnum<string, PricingType> expectedPricingType = PricingType.Free;
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, Status> expectedStatus = Status.PaymentPending;
        List<DataAddon> expectedAddons = [new() { ID = "id", Quantity = 0 }];
        DateTimeOffset expectedBillingCycleAnchor = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        DataBudget expectedBudget = new() { HasSoftLimit = true, Limit = 0 };
        DateTimeOffset expectedCancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, CancelReason> expectedCancelReason = CancelReason.UpgradeOrDowngrade;
        List<Coupon> expectedCoupons =
        [
            new()
            {
                ID = "id",
                Name = "name",
                Status = CouponStatus.Active,
                AmountsOff = [new() { Amount = 0, Currency = CouponAmountsOffCurrency.Usd }],
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
        List<DataFutureUpdate> expectedFutureUpdates =
        [
            new()
            {
                ScheduledExecutionTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ScheduleStatus = ScheduleStatus.PendingPayment,
                SubscriptionScheduleType = SubscriptionScheduleType.Downgrade,
                TargetPackage = new("id"),
            },
        ];
        LatestInvoice expectedLatestInvoice = new()
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = LatestInvoiceStatus.Open,
            AmountDue = 0,
            BillingReason = BillingReason.BillingCycle,
            Currency = "currency",
            PdfUrl = "pdfUrl",
            Total = 0,
        };
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        DataMinimumSpend expectedMinimumSpend = new()
        {
            Amount = 0,
            Currency = DataMinimumSpendCurrency.Usd,
        };
        string expectedPayingCustomerID = "payingCustomerId";
        ApiEnum<string, DataPaymentCollectionMethod> expectedPaymentCollectionMethod =
            DataPaymentCollectionMethod.Charge;
        List<Price> expectedPrices =
        [
            new()
            {
                AddonID = "addonId",
                Amount = 0,
                BaseCharge = true,
                BillingCountryCode = "billingCountryCode",
                BlockSize = 0,
                Currency = PriceCurrency.Usd,
                FeatureID = "featureId",
                Tiers =
                [
                    new()
                    {
                        FlatPrice = new() { Amount = 0, Currency = PriceTierFlatPriceCurrency.Usd },
                        UnitPrice = new() { Amount = 0, Currency = PriceTierUnitPriceCurrency.Usd },
                        UpTo = 0,
                    },
                ],
            },
        ];
        string expectedResourceID = "resourceId";
        List<DataSubscriptionEntitlement> expectedSubscriptionEntitlements =
        [
            new() { ID = "id", Type = DataSubscriptionEntitlementType.Feature },
        ];
        Trial expectedTrial = new(TrialTrialEndBehavior.ConvertToPaid);
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
        var model = new Data
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = PaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = PricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = Status.PaymentPending,
            Addons = [new() { ID = "id", Quantity = 0 }],
            BillingCycleAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = CancelReason.UpgradeOrDowngrade,
            Coupons =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    Status = CouponStatus.Active,
                    AmountsOff = [new() { Amount = 0, Currency = CouponAmountsOffCurrency.Usd }],
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
                    ScheduleStatus = ScheduleStatus.PendingPayment,
                    SubscriptionScheduleType = SubscriptionScheduleType.Downgrade,
                    TargetPackage = new("id"),
                },
            ],
            LatestInvoice = new()
            {
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RequiresAction = true,
                Status = LatestInvoiceStatus.Open,
                AmountDue = 0,
                BillingReason = BillingReason.BillingCycle,
                Currency = "currency",
                PdfUrl = "pdfUrl",
                Total = 0,
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MinimumSpend = new() { Amount = 0, Currency = DataMinimumSpendCurrency.Usd },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod = DataPaymentCollectionMethod.Charge,
            Prices =
            [
                new()
                {
                    AddonID = "addonId",
                    Amount = 0,
                    BaseCharge = true,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    Currency = PriceCurrency.Usd,
                    FeatureID = "featureId",
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency = PriceTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency = PriceTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            ResourceID = "resourceId",
            SubscriptionEntitlements =
            [
                new() { ID = "id", Type = DataSubscriptionEntitlementType.Feature },
            ],
            Trial = new(TrialTrialEndBehavior.ConvertToPaid),
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Data
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = PaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = PricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = Status.PaymentPending,
            BillingCycleAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = CancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LatestInvoice = new()
            {
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RequiresAction = true,
                Status = LatestInvoiceStatus.Open,
                AmountDue = 0,
                BillingReason = BillingReason.BillingCycle,
                Currency = "currency",
                PdfUrl = "pdfUrl",
                Total = 0,
            },
            MinimumSpend = new() { Amount = 0, Currency = DataMinimumSpendCurrency.Usd },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod = DataPaymentCollectionMethod.Charge,
            ResourceID = "resourceId",
            Trial = new(TrialTrialEndBehavior.ConvertToPaid),
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
        var model = new Data
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = PaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = PricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = Status.PaymentPending,
            BillingCycleAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = CancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LatestInvoice = new()
            {
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RequiresAction = true,
                Status = LatestInvoiceStatus.Open,
                AmountDue = 0,
                BillingReason = BillingReason.BillingCycle,
                Currency = "currency",
                PdfUrl = "pdfUrl",
                Total = 0,
            },
            MinimumSpend = new() { Amount = 0, Currency = DataMinimumSpendCurrency.Usd },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod = DataPaymentCollectionMethod.Charge,
            ResourceID = "resourceId",
            Trial = new(TrialTrialEndBehavior.ConvertToPaid),
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Data
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = PaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = PricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = Status.PaymentPending,
            BillingCycleAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = CancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LatestInvoice = new()
            {
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RequiresAction = true,
                Status = LatestInvoiceStatus.Open,
                AmountDue = 0,
                BillingReason = BillingReason.BillingCycle,
                Currency = "currency",
                PdfUrl = "pdfUrl",
                Total = 0,
            },
            MinimumSpend = new() { Amount = 0, Currency = DataMinimumSpendCurrency.Usd },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod = DataPaymentCollectionMethod.Charge,
            ResourceID = "resourceId",
            Trial = new(TrialTrialEndBehavior.ConvertToPaid),
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
        var model = new Data
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = PaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = PricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = Status.PaymentPending,
            BillingCycleAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = CancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LatestInvoice = new()
            {
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RequiresAction = true,
                Status = LatestInvoiceStatus.Open,
                AmountDue = 0,
                BillingReason = BillingReason.BillingCycle,
                Currency = "currency",
                PdfUrl = "pdfUrl",
                Total = 0,
            },
            MinimumSpend = new() { Amount = 0, Currency = DataMinimumSpendCurrency.Usd },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod = DataPaymentCollectionMethod.Charge,
            ResourceID = "resourceId",
            Trial = new(TrialTrialEndBehavior.ConvertToPaid),
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
        var model = new Data
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = PaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = PricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = Status.PaymentPending,
            Addons = [new() { ID = "id", Quantity = 0 }],
            Coupons =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    Status = CouponStatus.Active,
                    AmountsOff = [new() { Amount = 0, Currency = CouponAmountsOffCurrency.Usd }],
                    PercentOff = 0,
                },
            ],
            FutureUpdates =
            [
                new()
                {
                    ScheduledExecutionTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ScheduleStatus = ScheduleStatus.PendingPayment,
                    SubscriptionScheduleType = SubscriptionScheduleType.Downgrade,
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
                    Currency = PriceCurrency.Usd,
                    FeatureID = "featureId",
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency = PriceTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency = PriceTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            SubscriptionEntitlements =
            [
                new() { ID = "id", Type = DataSubscriptionEntitlementType.Feature },
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
        var model = new Data
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = PaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = PricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = Status.PaymentPending,
            Addons = [new() { ID = "id", Quantity = 0 }],
            Coupons =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    Status = CouponStatus.Active,
                    AmountsOff = [new() { Amount = 0, Currency = CouponAmountsOffCurrency.Usd }],
                    PercentOff = 0,
                },
            ],
            FutureUpdates =
            [
                new()
                {
                    ScheduledExecutionTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ScheduleStatus = ScheduleStatus.PendingPayment,
                    SubscriptionScheduleType = SubscriptionScheduleType.Downgrade,
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
                    Currency = PriceCurrency.Usd,
                    FeatureID = "featureId",
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency = PriceTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency = PriceTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            SubscriptionEntitlements =
            [
                new() { ID = "id", Type = DataSubscriptionEntitlementType.Feature },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Data
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = PaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = PricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = Status.PaymentPending,
            Addons = [new() { ID = "id", Quantity = 0 }],
            Coupons =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    Status = CouponStatus.Active,
                    AmountsOff = [new() { Amount = 0, Currency = CouponAmountsOffCurrency.Usd }],
                    PercentOff = 0,
                },
            ],
            FutureUpdates =
            [
                new()
                {
                    ScheduledExecutionTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ScheduleStatus = ScheduleStatus.PendingPayment,
                    SubscriptionScheduleType = SubscriptionScheduleType.Downgrade,
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
                    Currency = PriceCurrency.Usd,
                    FeatureID = "featureId",
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency = PriceTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency = PriceTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            SubscriptionEntitlements =
            [
                new() { ID = "id", Type = DataSubscriptionEntitlementType.Feature },
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
        var model = new Data
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = PaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = PricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = Status.PaymentPending,
            Addons = [new() { ID = "id", Quantity = 0 }],
            Coupons =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    Status = CouponStatus.Active,
                    AmountsOff = [new() { Amount = 0, Currency = CouponAmountsOffCurrency.Usd }],
                    PercentOff = 0,
                },
            ],
            FutureUpdates =
            [
                new()
                {
                    ScheduledExecutionTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ScheduleStatus = ScheduleStatus.PendingPayment,
                    SubscriptionScheduleType = SubscriptionScheduleType.Downgrade,
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
                    Currency = PriceCurrency.Usd,
                    FeatureID = "featureId",
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency = PriceTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency = PriceTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            SubscriptionEntitlements =
            [
                new() { ID = "id", Type = DataSubscriptionEntitlementType.Feature },
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
        var model = new Data
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = PaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = PricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = Status.PaymentPending,
            Addons = [new() { ID = "id", Quantity = 0 }],
            BillingCycleAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = CancelReason.UpgradeOrDowngrade,
            Coupons =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    Status = CouponStatus.Active,
                    AmountsOff = [new() { Amount = 0, Currency = CouponAmountsOffCurrency.Usd }],
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
                    ScheduleStatus = ScheduleStatus.PendingPayment,
                    SubscriptionScheduleType = SubscriptionScheduleType.Downgrade,
                    TargetPackage = new("id"),
                },
            ],
            LatestInvoice = new()
            {
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RequiresAction = true,
                Status = LatestInvoiceStatus.Open,
                AmountDue = 0,
                BillingReason = BillingReason.BillingCycle,
                Currency = "currency",
                PdfUrl = "pdfUrl",
                Total = 0,
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MinimumSpend = new() { Amount = 0, Currency = DataMinimumSpendCurrency.Usd },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod = DataPaymentCollectionMethod.Charge,
            Prices =
            [
                new()
                {
                    AddonID = "addonId",
                    Amount = 0,
                    BaseCharge = true,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    Currency = PriceCurrency.Usd,
                    FeatureID = "featureId",
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency = PriceTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency = PriceTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            ResourceID = "resourceId",
            SubscriptionEntitlements =
            [
                new() { ID = "id", Type = DataSubscriptionEntitlementType.Feature },
            ],
            Trial = new(TrialTrialEndBehavior.ConvertToPaid),
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Data copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PaymentCollectionTest : TestBase
{
    [Theory]
    [InlineData(PaymentCollection.NotRequired)]
    [InlineData(PaymentCollection.Processing)]
    [InlineData(PaymentCollection.Failed)]
    [InlineData(PaymentCollection.ActionRequired)]
    public void Validation_Works(PaymentCollection rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PaymentCollection> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PaymentCollection>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PaymentCollection.NotRequired)]
    [InlineData(PaymentCollection.Processing)]
    [InlineData(PaymentCollection.Failed)]
    [InlineData(PaymentCollection.ActionRequired)]
    public void SerializationRoundtrip_Works(PaymentCollection rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PaymentCollection> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PaymentCollection>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PaymentCollection>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PaymentCollection>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PricingTypeTest : TestBase
{
    [Theory]
    [InlineData(PricingType.Free)]
    [InlineData(PricingType.Paid)]
    [InlineData(PricingType.Custom)]
    public void Validation_Works(PricingType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PricingType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PricingType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PricingType.Free)]
    [InlineData(PricingType.Paid)]
    [InlineData(PricingType.Custom)]
    public void SerializationRoundtrip_Works(PricingType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PricingType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PricingType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PricingType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PricingType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.PaymentPending)]
    [InlineData(Status.Active)]
    [InlineData(Status.Expired)]
    [InlineData(Status.InTrial)]
    [InlineData(Status.Canceled)]
    [InlineData(Status.NotStarted)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.PaymentPending)]
    [InlineData(Status.Active)]
    [InlineData(Status.Expired)]
    [InlineData(Status.InTrial)]
    [InlineData(Status.Canceled)]
    [InlineData(Status.NotStarted)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DataAddonTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DataAddon { ID = "id", Quantity = 0 };

        string expectedID = "id";
        long expectedQuantity = 0;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedQuantity, model.Quantity);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DataAddon { ID = "id", Quantity = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataAddon>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DataAddon { ID = "id", Quantity = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataAddon>(
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
        var model = new DataAddon { ID = "id", Quantity = 0 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DataAddon { ID = "id", Quantity = 0 };

        DataAddon copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataBudgetTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DataBudget { HasSoftLimit = true, Limit = 0 };

        bool expectedHasSoftLimit = true;
        double expectedLimit = 0;

        Assert.Equal(expectedHasSoftLimit, model.HasSoftLimit);
        Assert.Equal(expectedLimit, model.Limit);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DataBudget { HasSoftLimit = true, Limit = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataBudget>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DataBudget { HasSoftLimit = true, Limit = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataBudget>(
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
        var model = new DataBudget { HasSoftLimit = true, Limit = 0 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DataBudget { HasSoftLimit = true, Limit = 0 };

        DataBudget copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CancelReasonTest : TestBase
{
    [Theory]
    [InlineData(CancelReason.UpgradeOrDowngrade)]
    [InlineData(CancelReason.CancelledByBilling)]
    [InlineData(CancelReason.Expired)]
    [InlineData(CancelReason.DetachBilling)]
    [InlineData(CancelReason.TrialEnded)]
    [InlineData(CancelReason.Immediate)]
    [InlineData(CancelReason.TrialConverted)]
    [InlineData(CancelReason.PendingPaymentExpired)]
    [InlineData(CancelReason.ScheduledCancellation)]
    [InlineData(CancelReason.CustomerArchived)]
    [InlineData(CancelReason.AutoCancellationRule)]
    public void Validation_Works(CancelReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CancelReason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CancelReason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CancelReason.UpgradeOrDowngrade)]
    [InlineData(CancelReason.CancelledByBilling)]
    [InlineData(CancelReason.Expired)]
    [InlineData(CancelReason.DetachBilling)]
    [InlineData(CancelReason.TrialEnded)]
    [InlineData(CancelReason.Immediate)]
    [InlineData(CancelReason.TrialConverted)]
    [InlineData(CancelReason.PendingPaymentExpired)]
    [InlineData(CancelReason.ScheduledCancellation)]
    [InlineData(CancelReason.CustomerArchived)]
    [InlineData(CancelReason.AutoCancellationRule)]
    public void SerializationRoundtrip_Works(CancelReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CancelReason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CancelReason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CancelReason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CancelReason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CouponTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Coupon
        {
            ID = "id",
            Name = "name",
            Status = CouponStatus.Active,
            AmountsOff = [new() { Amount = 0, Currency = CouponAmountsOffCurrency.Usd }],
            PercentOff = 0,
        };

        string expectedID = "id";
        string expectedName = "name";
        ApiEnum<string, CouponStatus> expectedStatus = CouponStatus.Active;
        List<CouponAmountsOff> expectedAmountsOff =
        [
            new() { Amount = 0, Currency = CouponAmountsOffCurrency.Usd },
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
        var model = new Coupon
        {
            ID = "id",
            Name = "name",
            Status = CouponStatus.Active,
            AmountsOff = [new() { Amount = 0, Currency = CouponAmountsOffCurrency.Usd }],
            PercentOff = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Coupon>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Coupon
        {
            ID = "id",
            Name = "name",
            Status = CouponStatus.Active,
            AmountsOff = [new() { Amount = 0, Currency = CouponAmountsOffCurrency.Usd }],
            PercentOff = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Coupon>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedName = "name";
        ApiEnum<string, CouponStatus> expectedStatus = CouponStatus.Active;
        List<CouponAmountsOff> expectedAmountsOff =
        [
            new() { Amount = 0, Currency = CouponAmountsOffCurrency.Usd },
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
        var model = new Coupon
        {
            ID = "id",
            Name = "name",
            Status = CouponStatus.Active,
            AmountsOff = [new() { Amount = 0, Currency = CouponAmountsOffCurrency.Usd }],
            PercentOff = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Coupon
        {
            ID = "id",
            Name = "name",
            Status = CouponStatus.Active,
        };

        Assert.Null(model.AmountsOff);
        Assert.False(model.RawData.ContainsKey("amountsOff"));
        Assert.Null(model.PercentOff);
        Assert.False(model.RawData.ContainsKey("percentOff"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Coupon
        {
            ID = "id",
            Name = "name",
            Status = CouponStatus.Active,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Coupon
        {
            ID = "id",
            Name = "name",
            Status = CouponStatus.Active,

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
        var model = new Coupon
        {
            ID = "id",
            Name = "name",
            Status = CouponStatus.Active,

            AmountsOff = null,
            PercentOff = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Coupon
        {
            ID = "id",
            Name = "name",
            Status = CouponStatus.Active,
            AmountsOff = [new() { Amount = 0, Currency = CouponAmountsOffCurrency.Usd }],
            PercentOff = 0,
        };

        Coupon copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CouponStatusTest : TestBase
{
    [Theory]
    [InlineData(CouponStatus.Active)]
    [InlineData(CouponStatus.Expired)]
    [InlineData(CouponStatus.Removed)]
    public void Validation_Works(CouponStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CouponStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CouponStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CouponStatus.Active)]
    [InlineData(CouponStatus.Expired)]
    [InlineData(CouponStatus.Removed)]
    public void SerializationRoundtrip_Works(CouponStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CouponStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CouponStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CouponStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CouponStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CouponAmountsOffTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CouponAmountsOff { Amount = 0, Currency = CouponAmountsOffCurrency.Usd };

        double expectedAmount = 0;
        ApiEnum<string, CouponAmountsOffCurrency> expectedCurrency = CouponAmountsOffCurrency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CouponAmountsOff { Amount = 0, Currency = CouponAmountsOffCurrency.Usd };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CouponAmountsOff>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CouponAmountsOff { Amount = 0, Currency = CouponAmountsOffCurrency.Usd };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CouponAmountsOff>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        ApiEnum<string, CouponAmountsOffCurrency> expectedCurrency = CouponAmountsOffCurrency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CouponAmountsOff { Amount = 0, Currency = CouponAmountsOffCurrency.Usd };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CouponAmountsOff { };

        Assert.Null(model.Amount);
        Assert.False(model.RawData.ContainsKey("amount"));
        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CouponAmountsOff { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CouponAmountsOff
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
        var model = new CouponAmountsOff
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
        var model = new CouponAmountsOff { Amount = 0, Currency = CouponAmountsOffCurrency.Usd };

        CouponAmountsOff copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CouponAmountsOffCurrencyTest : TestBase
{
    [Theory]
    [InlineData(CouponAmountsOffCurrency.Usd)]
    [InlineData(CouponAmountsOffCurrency.Aed)]
    [InlineData(CouponAmountsOffCurrency.All)]
    [InlineData(CouponAmountsOffCurrency.Amd)]
    [InlineData(CouponAmountsOffCurrency.Ang)]
    [InlineData(CouponAmountsOffCurrency.Aud)]
    [InlineData(CouponAmountsOffCurrency.Awg)]
    [InlineData(CouponAmountsOffCurrency.Azn)]
    [InlineData(CouponAmountsOffCurrency.Bam)]
    [InlineData(CouponAmountsOffCurrency.Bbd)]
    [InlineData(CouponAmountsOffCurrency.Bdt)]
    [InlineData(CouponAmountsOffCurrency.Bgn)]
    [InlineData(CouponAmountsOffCurrency.Bif)]
    [InlineData(CouponAmountsOffCurrency.Bmd)]
    [InlineData(CouponAmountsOffCurrency.Bnd)]
    [InlineData(CouponAmountsOffCurrency.Bsd)]
    [InlineData(CouponAmountsOffCurrency.Bwp)]
    [InlineData(CouponAmountsOffCurrency.Byn)]
    [InlineData(CouponAmountsOffCurrency.Bzd)]
    [InlineData(CouponAmountsOffCurrency.Brl)]
    [InlineData(CouponAmountsOffCurrency.Cad)]
    [InlineData(CouponAmountsOffCurrency.Cdf)]
    [InlineData(CouponAmountsOffCurrency.Chf)]
    [InlineData(CouponAmountsOffCurrency.Cny)]
    [InlineData(CouponAmountsOffCurrency.Czk)]
    [InlineData(CouponAmountsOffCurrency.Dkk)]
    [InlineData(CouponAmountsOffCurrency.Dop)]
    [InlineData(CouponAmountsOffCurrency.Dzd)]
    [InlineData(CouponAmountsOffCurrency.Egp)]
    [InlineData(CouponAmountsOffCurrency.Etb)]
    [InlineData(CouponAmountsOffCurrency.Eur)]
    [InlineData(CouponAmountsOffCurrency.Fjd)]
    [InlineData(CouponAmountsOffCurrency.Gbp)]
    [InlineData(CouponAmountsOffCurrency.Gel)]
    [InlineData(CouponAmountsOffCurrency.Gip)]
    [InlineData(CouponAmountsOffCurrency.Gmd)]
    [InlineData(CouponAmountsOffCurrency.Gyd)]
    [InlineData(CouponAmountsOffCurrency.Hkd)]
    [InlineData(CouponAmountsOffCurrency.Hrk)]
    [InlineData(CouponAmountsOffCurrency.Htg)]
    [InlineData(CouponAmountsOffCurrency.Idr)]
    [InlineData(CouponAmountsOffCurrency.Ils)]
    [InlineData(CouponAmountsOffCurrency.Inr)]
    [InlineData(CouponAmountsOffCurrency.Isk)]
    [InlineData(CouponAmountsOffCurrency.Jmd)]
    [InlineData(CouponAmountsOffCurrency.Jpy)]
    [InlineData(CouponAmountsOffCurrency.Kes)]
    [InlineData(CouponAmountsOffCurrency.Kgs)]
    [InlineData(CouponAmountsOffCurrency.Khr)]
    [InlineData(CouponAmountsOffCurrency.Kmf)]
    [InlineData(CouponAmountsOffCurrency.Krw)]
    [InlineData(CouponAmountsOffCurrency.Kyd)]
    [InlineData(CouponAmountsOffCurrency.Kzt)]
    [InlineData(CouponAmountsOffCurrency.Lbp)]
    [InlineData(CouponAmountsOffCurrency.Lkr)]
    [InlineData(CouponAmountsOffCurrency.Lrd)]
    [InlineData(CouponAmountsOffCurrency.Lsl)]
    [InlineData(CouponAmountsOffCurrency.Mad)]
    [InlineData(CouponAmountsOffCurrency.Mdl)]
    [InlineData(CouponAmountsOffCurrency.Mga)]
    [InlineData(CouponAmountsOffCurrency.Mkd)]
    [InlineData(CouponAmountsOffCurrency.Mmk)]
    [InlineData(CouponAmountsOffCurrency.Mnt)]
    [InlineData(CouponAmountsOffCurrency.Mop)]
    [InlineData(CouponAmountsOffCurrency.Mro)]
    [InlineData(CouponAmountsOffCurrency.Mvr)]
    [InlineData(CouponAmountsOffCurrency.Mwk)]
    [InlineData(CouponAmountsOffCurrency.Mxn)]
    [InlineData(CouponAmountsOffCurrency.Myr)]
    [InlineData(CouponAmountsOffCurrency.Mzn)]
    [InlineData(CouponAmountsOffCurrency.Nad)]
    [InlineData(CouponAmountsOffCurrency.Ngn)]
    [InlineData(CouponAmountsOffCurrency.Nok)]
    [InlineData(CouponAmountsOffCurrency.Npr)]
    [InlineData(CouponAmountsOffCurrency.Nzd)]
    [InlineData(CouponAmountsOffCurrency.Pgk)]
    [InlineData(CouponAmountsOffCurrency.Php)]
    [InlineData(CouponAmountsOffCurrency.Pkr)]
    [InlineData(CouponAmountsOffCurrency.Pln)]
    [InlineData(CouponAmountsOffCurrency.Qar)]
    [InlineData(CouponAmountsOffCurrency.Ron)]
    [InlineData(CouponAmountsOffCurrency.Rsd)]
    [InlineData(CouponAmountsOffCurrency.Rub)]
    [InlineData(CouponAmountsOffCurrency.Rwf)]
    [InlineData(CouponAmountsOffCurrency.Sar)]
    [InlineData(CouponAmountsOffCurrency.Sbd)]
    [InlineData(CouponAmountsOffCurrency.Scr)]
    [InlineData(CouponAmountsOffCurrency.Sek)]
    [InlineData(CouponAmountsOffCurrency.Sgd)]
    [InlineData(CouponAmountsOffCurrency.Sle)]
    [InlineData(CouponAmountsOffCurrency.Sll)]
    [InlineData(CouponAmountsOffCurrency.Sos)]
    [InlineData(CouponAmountsOffCurrency.Szl)]
    [InlineData(CouponAmountsOffCurrency.Thb)]
    [InlineData(CouponAmountsOffCurrency.Tjs)]
    [InlineData(CouponAmountsOffCurrency.Top)]
    [InlineData(CouponAmountsOffCurrency.Try)]
    [InlineData(CouponAmountsOffCurrency.Ttd)]
    [InlineData(CouponAmountsOffCurrency.Tzs)]
    [InlineData(CouponAmountsOffCurrency.Uah)]
    [InlineData(CouponAmountsOffCurrency.Uzs)]
    [InlineData(CouponAmountsOffCurrency.Vnd)]
    [InlineData(CouponAmountsOffCurrency.Vuv)]
    [InlineData(CouponAmountsOffCurrency.Wst)]
    [InlineData(CouponAmountsOffCurrency.Xaf)]
    [InlineData(CouponAmountsOffCurrency.Xcd)]
    [InlineData(CouponAmountsOffCurrency.Yer)]
    [InlineData(CouponAmountsOffCurrency.Zar)]
    [InlineData(CouponAmountsOffCurrency.Zmw)]
    [InlineData(CouponAmountsOffCurrency.Clp)]
    [InlineData(CouponAmountsOffCurrency.Djf)]
    [InlineData(CouponAmountsOffCurrency.Gnf)]
    [InlineData(CouponAmountsOffCurrency.Ugx)]
    [InlineData(CouponAmountsOffCurrency.Pyg)]
    [InlineData(CouponAmountsOffCurrency.Xof)]
    [InlineData(CouponAmountsOffCurrency.Xpf)]
    public void Validation_Works(CouponAmountsOffCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CouponAmountsOffCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CouponAmountsOffCurrency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CouponAmountsOffCurrency.Usd)]
    [InlineData(CouponAmountsOffCurrency.Aed)]
    [InlineData(CouponAmountsOffCurrency.All)]
    [InlineData(CouponAmountsOffCurrency.Amd)]
    [InlineData(CouponAmountsOffCurrency.Ang)]
    [InlineData(CouponAmountsOffCurrency.Aud)]
    [InlineData(CouponAmountsOffCurrency.Awg)]
    [InlineData(CouponAmountsOffCurrency.Azn)]
    [InlineData(CouponAmountsOffCurrency.Bam)]
    [InlineData(CouponAmountsOffCurrency.Bbd)]
    [InlineData(CouponAmountsOffCurrency.Bdt)]
    [InlineData(CouponAmountsOffCurrency.Bgn)]
    [InlineData(CouponAmountsOffCurrency.Bif)]
    [InlineData(CouponAmountsOffCurrency.Bmd)]
    [InlineData(CouponAmountsOffCurrency.Bnd)]
    [InlineData(CouponAmountsOffCurrency.Bsd)]
    [InlineData(CouponAmountsOffCurrency.Bwp)]
    [InlineData(CouponAmountsOffCurrency.Byn)]
    [InlineData(CouponAmountsOffCurrency.Bzd)]
    [InlineData(CouponAmountsOffCurrency.Brl)]
    [InlineData(CouponAmountsOffCurrency.Cad)]
    [InlineData(CouponAmountsOffCurrency.Cdf)]
    [InlineData(CouponAmountsOffCurrency.Chf)]
    [InlineData(CouponAmountsOffCurrency.Cny)]
    [InlineData(CouponAmountsOffCurrency.Czk)]
    [InlineData(CouponAmountsOffCurrency.Dkk)]
    [InlineData(CouponAmountsOffCurrency.Dop)]
    [InlineData(CouponAmountsOffCurrency.Dzd)]
    [InlineData(CouponAmountsOffCurrency.Egp)]
    [InlineData(CouponAmountsOffCurrency.Etb)]
    [InlineData(CouponAmountsOffCurrency.Eur)]
    [InlineData(CouponAmountsOffCurrency.Fjd)]
    [InlineData(CouponAmountsOffCurrency.Gbp)]
    [InlineData(CouponAmountsOffCurrency.Gel)]
    [InlineData(CouponAmountsOffCurrency.Gip)]
    [InlineData(CouponAmountsOffCurrency.Gmd)]
    [InlineData(CouponAmountsOffCurrency.Gyd)]
    [InlineData(CouponAmountsOffCurrency.Hkd)]
    [InlineData(CouponAmountsOffCurrency.Hrk)]
    [InlineData(CouponAmountsOffCurrency.Htg)]
    [InlineData(CouponAmountsOffCurrency.Idr)]
    [InlineData(CouponAmountsOffCurrency.Ils)]
    [InlineData(CouponAmountsOffCurrency.Inr)]
    [InlineData(CouponAmountsOffCurrency.Isk)]
    [InlineData(CouponAmountsOffCurrency.Jmd)]
    [InlineData(CouponAmountsOffCurrency.Jpy)]
    [InlineData(CouponAmountsOffCurrency.Kes)]
    [InlineData(CouponAmountsOffCurrency.Kgs)]
    [InlineData(CouponAmountsOffCurrency.Khr)]
    [InlineData(CouponAmountsOffCurrency.Kmf)]
    [InlineData(CouponAmountsOffCurrency.Krw)]
    [InlineData(CouponAmountsOffCurrency.Kyd)]
    [InlineData(CouponAmountsOffCurrency.Kzt)]
    [InlineData(CouponAmountsOffCurrency.Lbp)]
    [InlineData(CouponAmountsOffCurrency.Lkr)]
    [InlineData(CouponAmountsOffCurrency.Lrd)]
    [InlineData(CouponAmountsOffCurrency.Lsl)]
    [InlineData(CouponAmountsOffCurrency.Mad)]
    [InlineData(CouponAmountsOffCurrency.Mdl)]
    [InlineData(CouponAmountsOffCurrency.Mga)]
    [InlineData(CouponAmountsOffCurrency.Mkd)]
    [InlineData(CouponAmountsOffCurrency.Mmk)]
    [InlineData(CouponAmountsOffCurrency.Mnt)]
    [InlineData(CouponAmountsOffCurrency.Mop)]
    [InlineData(CouponAmountsOffCurrency.Mro)]
    [InlineData(CouponAmountsOffCurrency.Mvr)]
    [InlineData(CouponAmountsOffCurrency.Mwk)]
    [InlineData(CouponAmountsOffCurrency.Mxn)]
    [InlineData(CouponAmountsOffCurrency.Myr)]
    [InlineData(CouponAmountsOffCurrency.Mzn)]
    [InlineData(CouponAmountsOffCurrency.Nad)]
    [InlineData(CouponAmountsOffCurrency.Ngn)]
    [InlineData(CouponAmountsOffCurrency.Nok)]
    [InlineData(CouponAmountsOffCurrency.Npr)]
    [InlineData(CouponAmountsOffCurrency.Nzd)]
    [InlineData(CouponAmountsOffCurrency.Pgk)]
    [InlineData(CouponAmountsOffCurrency.Php)]
    [InlineData(CouponAmountsOffCurrency.Pkr)]
    [InlineData(CouponAmountsOffCurrency.Pln)]
    [InlineData(CouponAmountsOffCurrency.Qar)]
    [InlineData(CouponAmountsOffCurrency.Ron)]
    [InlineData(CouponAmountsOffCurrency.Rsd)]
    [InlineData(CouponAmountsOffCurrency.Rub)]
    [InlineData(CouponAmountsOffCurrency.Rwf)]
    [InlineData(CouponAmountsOffCurrency.Sar)]
    [InlineData(CouponAmountsOffCurrency.Sbd)]
    [InlineData(CouponAmountsOffCurrency.Scr)]
    [InlineData(CouponAmountsOffCurrency.Sek)]
    [InlineData(CouponAmountsOffCurrency.Sgd)]
    [InlineData(CouponAmountsOffCurrency.Sle)]
    [InlineData(CouponAmountsOffCurrency.Sll)]
    [InlineData(CouponAmountsOffCurrency.Sos)]
    [InlineData(CouponAmountsOffCurrency.Szl)]
    [InlineData(CouponAmountsOffCurrency.Thb)]
    [InlineData(CouponAmountsOffCurrency.Tjs)]
    [InlineData(CouponAmountsOffCurrency.Top)]
    [InlineData(CouponAmountsOffCurrency.Try)]
    [InlineData(CouponAmountsOffCurrency.Ttd)]
    [InlineData(CouponAmountsOffCurrency.Tzs)]
    [InlineData(CouponAmountsOffCurrency.Uah)]
    [InlineData(CouponAmountsOffCurrency.Uzs)]
    [InlineData(CouponAmountsOffCurrency.Vnd)]
    [InlineData(CouponAmountsOffCurrency.Vuv)]
    [InlineData(CouponAmountsOffCurrency.Wst)]
    [InlineData(CouponAmountsOffCurrency.Xaf)]
    [InlineData(CouponAmountsOffCurrency.Xcd)]
    [InlineData(CouponAmountsOffCurrency.Yer)]
    [InlineData(CouponAmountsOffCurrency.Zar)]
    [InlineData(CouponAmountsOffCurrency.Zmw)]
    [InlineData(CouponAmountsOffCurrency.Clp)]
    [InlineData(CouponAmountsOffCurrency.Djf)]
    [InlineData(CouponAmountsOffCurrency.Gnf)]
    [InlineData(CouponAmountsOffCurrency.Ugx)]
    [InlineData(CouponAmountsOffCurrency.Pyg)]
    [InlineData(CouponAmountsOffCurrency.Xof)]
    [InlineData(CouponAmountsOffCurrency.Xpf)]
    public void SerializationRoundtrip_Works(CouponAmountsOffCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CouponAmountsOffCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CouponAmountsOffCurrency>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CouponAmountsOffCurrency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CouponAmountsOffCurrency>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DataFutureUpdateTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DataFutureUpdate
        {
            ScheduledExecutionTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ScheduleStatus = ScheduleStatus.PendingPayment,
            SubscriptionScheduleType = SubscriptionScheduleType.Downgrade,
            TargetPackage = new("id"),
        };

        DateTimeOffset expectedScheduledExecutionTime = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        ApiEnum<string, ScheduleStatus> expectedScheduleStatus = ScheduleStatus.PendingPayment;
        ApiEnum<string, SubscriptionScheduleType> expectedSubscriptionScheduleType =
            SubscriptionScheduleType.Downgrade;
        TargetPackage expectedTargetPackage = new("id");

        Assert.Equal(expectedScheduledExecutionTime, model.ScheduledExecutionTime);
        Assert.Equal(expectedScheduleStatus, model.ScheduleStatus);
        Assert.Equal(expectedSubscriptionScheduleType, model.SubscriptionScheduleType);
        Assert.Equal(expectedTargetPackage, model.TargetPackage);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DataFutureUpdate
        {
            ScheduledExecutionTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ScheduleStatus = ScheduleStatus.PendingPayment,
            SubscriptionScheduleType = SubscriptionScheduleType.Downgrade,
            TargetPackage = new("id"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataFutureUpdate>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DataFutureUpdate
        {
            ScheduledExecutionTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ScheduleStatus = ScheduleStatus.PendingPayment,
            SubscriptionScheduleType = SubscriptionScheduleType.Downgrade,
            TargetPackage = new("id"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataFutureUpdate>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedScheduledExecutionTime = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        ApiEnum<string, ScheduleStatus> expectedScheduleStatus = ScheduleStatus.PendingPayment;
        ApiEnum<string, SubscriptionScheduleType> expectedSubscriptionScheduleType =
            SubscriptionScheduleType.Downgrade;
        TargetPackage expectedTargetPackage = new("id");

        Assert.Equal(expectedScheduledExecutionTime, deserialized.ScheduledExecutionTime);
        Assert.Equal(expectedScheduleStatus, deserialized.ScheduleStatus);
        Assert.Equal(expectedSubscriptionScheduleType, deserialized.SubscriptionScheduleType);
        Assert.Equal(expectedTargetPackage, deserialized.TargetPackage);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DataFutureUpdate
        {
            ScheduledExecutionTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ScheduleStatus = ScheduleStatus.PendingPayment,
            SubscriptionScheduleType = SubscriptionScheduleType.Downgrade,
            TargetPackage = new("id"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DataFutureUpdate
        {
            ScheduledExecutionTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ScheduleStatus = ScheduleStatus.PendingPayment,
            SubscriptionScheduleType = SubscriptionScheduleType.Downgrade,
        };

        Assert.Null(model.TargetPackage);
        Assert.False(model.RawData.ContainsKey("targetPackage"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new DataFutureUpdate
        {
            ScheduledExecutionTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ScheduleStatus = ScheduleStatus.PendingPayment,
            SubscriptionScheduleType = SubscriptionScheduleType.Downgrade,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new DataFutureUpdate
        {
            ScheduledExecutionTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ScheduleStatus = ScheduleStatus.PendingPayment,
            SubscriptionScheduleType = SubscriptionScheduleType.Downgrade,

            TargetPackage = null,
        };

        Assert.Null(model.TargetPackage);
        Assert.True(model.RawData.ContainsKey("targetPackage"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DataFutureUpdate
        {
            ScheduledExecutionTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ScheduleStatus = ScheduleStatus.PendingPayment,
            SubscriptionScheduleType = SubscriptionScheduleType.Downgrade,

            TargetPackage = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DataFutureUpdate
        {
            ScheduledExecutionTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ScheduleStatus = ScheduleStatus.PendingPayment,
            SubscriptionScheduleType = SubscriptionScheduleType.Downgrade,
            TargetPackage = new("id"),
        };

        DataFutureUpdate copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ScheduleStatusTest : TestBase
{
    [Theory]
    [InlineData(ScheduleStatus.PendingPayment)]
    [InlineData(ScheduleStatus.Scheduled)]
    [InlineData(ScheduleStatus.Canceled)]
    [InlineData(ScheduleStatus.Done)]
    [InlineData(ScheduleStatus.Failed)]
    public void Validation_Works(ScheduleStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ScheduleStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ScheduleStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ScheduleStatus.PendingPayment)]
    [InlineData(ScheduleStatus.Scheduled)]
    [InlineData(ScheduleStatus.Canceled)]
    [InlineData(ScheduleStatus.Done)]
    [InlineData(ScheduleStatus.Failed)]
    public void SerializationRoundtrip_Works(ScheduleStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ScheduleStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ScheduleStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ScheduleStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ScheduleStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionScheduleTypeTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionScheduleType.Downgrade)]
    [InlineData(SubscriptionScheduleType.Plan)]
    [InlineData(SubscriptionScheduleType.BillingPeriod)]
    [InlineData(SubscriptionScheduleType.UnitAmount)]
    [InlineData(SubscriptionScheduleType.RecurringCredits)]
    [InlineData(SubscriptionScheduleType.PriceOverride)]
    [InlineData(SubscriptionScheduleType.Addon)]
    [InlineData(SubscriptionScheduleType.Coupon)]
    [InlineData(SubscriptionScheduleType.MigrateToLatest)]
    [InlineData(SubscriptionScheduleType.AdditionalMetaData)]
    [InlineData(SubscriptionScheduleType.BillingInfoMetadata)]
    public void Validation_Works(SubscriptionScheduleType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionScheduleType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SubscriptionScheduleType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionScheduleType.Downgrade)]
    [InlineData(SubscriptionScheduleType.Plan)]
    [InlineData(SubscriptionScheduleType.BillingPeriod)]
    [InlineData(SubscriptionScheduleType.UnitAmount)]
    [InlineData(SubscriptionScheduleType.RecurringCredits)]
    [InlineData(SubscriptionScheduleType.PriceOverride)]
    [InlineData(SubscriptionScheduleType.Addon)]
    [InlineData(SubscriptionScheduleType.Coupon)]
    [InlineData(SubscriptionScheduleType.MigrateToLatest)]
    [InlineData(SubscriptionScheduleType.AdditionalMetaData)]
    [InlineData(SubscriptionScheduleType.BillingInfoMetadata)]
    public void SerializationRoundtrip_Works(SubscriptionScheduleType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionScheduleType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SubscriptionScheduleType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SubscriptionScheduleType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SubscriptionScheduleType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TargetPackageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TargetPackage { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, model.ID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TargetPackage { ID = "id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TargetPackage>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TargetPackage { ID = "id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TargetPackage>(
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
        var model = new TargetPackage { ID = "id" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TargetPackage { ID = "id" };

        TargetPackage copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class LatestInvoiceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new LatestInvoice
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = LatestInvoiceStatus.Open,
            AmountDue = 0,
            BillingReason = BillingReason.BillingCycle,
            Currency = "currency",
            PdfUrl = "pdfUrl",
            Total = 0,
        };

        string expectedBillingID = "billingId";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedRequiresAction = true;
        ApiEnum<string, LatestInvoiceStatus> expectedStatus = LatestInvoiceStatus.Open;
        double expectedAmountDue = 0;
        ApiEnum<string, BillingReason> expectedBillingReason = BillingReason.BillingCycle;
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
        var model = new LatestInvoice
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = LatestInvoiceStatus.Open,
            AmountDue = 0,
            BillingReason = BillingReason.BillingCycle,
            Currency = "currency",
            PdfUrl = "pdfUrl",
            Total = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LatestInvoice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new LatestInvoice
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = LatestInvoiceStatus.Open,
            AmountDue = 0,
            BillingReason = BillingReason.BillingCycle,
            Currency = "currency",
            PdfUrl = "pdfUrl",
            Total = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LatestInvoice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBillingID = "billingId";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedRequiresAction = true;
        ApiEnum<string, LatestInvoiceStatus> expectedStatus = LatestInvoiceStatus.Open;
        double expectedAmountDue = 0;
        ApiEnum<string, BillingReason> expectedBillingReason = BillingReason.BillingCycle;
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
        var model = new LatestInvoice
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = LatestInvoiceStatus.Open,
            AmountDue = 0,
            BillingReason = BillingReason.BillingCycle,
            Currency = "currency",
            PdfUrl = "pdfUrl",
            Total = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new LatestInvoice
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = LatestInvoiceStatus.Open,
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
        var model = new LatestInvoice
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = LatestInvoiceStatus.Open,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new LatestInvoice
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = LatestInvoiceStatus.Open,

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
        var model = new LatestInvoice
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = LatestInvoiceStatus.Open,

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
        var model = new LatestInvoice
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = LatestInvoiceStatus.Open,
            AmountDue = 0,
            BillingReason = BillingReason.BillingCycle,
            Currency = "currency",
            PdfUrl = "pdfUrl",
            Total = 0,
        };

        LatestInvoice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class LatestInvoiceStatusTest : TestBase
{
    [Theory]
    [InlineData(LatestInvoiceStatus.Open)]
    [InlineData(LatestInvoiceStatus.Canceled)]
    [InlineData(LatestInvoiceStatus.Paid)]
    public void Validation_Works(LatestInvoiceStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, LatestInvoiceStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, LatestInvoiceStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(LatestInvoiceStatus.Open)]
    [InlineData(LatestInvoiceStatus.Canceled)]
    [InlineData(LatestInvoiceStatus.Paid)]
    public void SerializationRoundtrip_Works(LatestInvoiceStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, LatestInvoiceStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, LatestInvoiceStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, LatestInvoiceStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, LatestInvoiceStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class BillingReasonTest : TestBase
{
    [Theory]
    [InlineData(BillingReason.BillingCycle)]
    [InlineData(BillingReason.SubscriptionCreation)]
    [InlineData(BillingReason.SubscriptionUpdate)]
    [InlineData(BillingReason.Manual)]
    [InlineData(BillingReason.MinimumInvoiceAmountExceeded)]
    [InlineData(BillingReason.Other)]
    public void Validation_Works(BillingReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BillingReason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BillingReason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BillingReason.BillingCycle)]
    [InlineData(BillingReason.SubscriptionCreation)]
    [InlineData(BillingReason.SubscriptionUpdate)]
    [InlineData(BillingReason.Manual)]
    [InlineData(BillingReason.MinimumInvoiceAmountExceeded)]
    [InlineData(BillingReason.Other)]
    public void SerializationRoundtrip_Works(BillingReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BillingReason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BillingReason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BillingReason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BillingReason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DataMinimumSpendTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DataMinimumSpend { Amount = 0, Currency = DataMinimumSpendCurrency.Usd };

        double expectedAmount = 0;
        ApiEnum<string, DataMinimumSpendCurrency> expectedCurrency = DataMinimumSpendCurrency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DataMinimumSpend { Amount = 0, Currency = DataMinimumSpendCurrency.Usd };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataMinimumSpend>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DataMinimumSpend { Amount = 0, Currency = DataMinimumSpendCurrency.Usd };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataMinimumSpend>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        ApiEnum<string, DataMinimumSpendCurrency> expectedCurrency = DataMinimumSpendCurrency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DataMinimumSpend { Amount = 0, Currency = DataMinimumSpendCurrency.Usd };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DataMinimumSpend { };

        Assert.Null(model.Amount);
        Assert.False(model.RawData.ContainsKey("amount"));
        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new DataMinimumSpend { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new DataMinimumSpend
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
        var model = new DataMinimumSpend
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
        var model = new DataMinimumSpend { Amount = 0, Currency = DataMinimumSpendCurrency.Usd };

        DataMinimumSpend copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataMinimumSpendCurrencyTest : TestBase
{
    [Theory]
    [InlineData(DataMinimumSpendCurrency.Usd)]
    [InlineData(DataMinimumSpendCurrency.Aed)]
    [InlineData(DataMinimumSpendCurrency.All)]
    [InlineData(DataMinimumSpendCurrency.Amd)]
    [InlineData(DataMinimumSpendCurrency.Ang)]
    [InlineData(DataMinimumSpendCurrency.Aud)]
    [InlineData(DataMinimumSpendCurrency.Awg)]
    [InlineData(DataMinimumSpendCurrency.Azn)]
    [InlineData(DataMinimumSpendCurrency.Bam)]
    [InlineData(DataMinimumSpendCurrency.Bbd)]
    [InlineData(DataMinimumSpendCurrency.Bdt)]
    [InlineData(DataMinimumSpendCurrency.Bgn)]
    [InlineData(DataMinimumSpendCurrency.Bif)]
    [InlineData(DataMinimumSpendCurrency.Bmd)]
    [InlineData(DataMinimumSpendCurrency.Bnd)]
    [InlineData(DataMinimumSpendCurrency.Bsd)]
    [InlineData(DataMinimumSpendCurrency.Bwp)]
    [InlineData(DataMinimumSpendCurrency.Byn)]
    [InlineData(DataMinimumSpendCurrency.Bzd)]
    [InlineData(DataMinimumSpendCurrency.Brl)]
    [InlineData(DataMinimumSpendCurrency.Cad)]
    [InlineData(DataMinimumSpendCurrency.Cdf)]
    [InlineData(DataMinimumSpendCurrency.Chf)]
    [InlineData(DataMinimumSpendCurrency.Cny)]
    [InlineData(DataMinimumSpendCurrency.Czk)]
    [InlineData(DataMinimumSpendCurrency.Dkk)]
    [InlineData(DataMinimumSpendCurrency.Dop)]
    [InlineData(DataMinimumSpendCurrency.Dzd)]
    [InlineData(DataMinimumSpendCurrency.Egp)]
    [InlineData(DataMinimumSpendCurrency.Etb)]
    [InlineData(DataMinimumSpendCurrency.Eur)]
    [InlineData(DataMinimumSpendCurrency.Fjd)]
    [InlineData(DataMinimumSpendCurrency.Gbp)]
    [InlineData(DataMinimumSpendCurrency.Gel)]
    [InlineData(DataMinimumSpendCurrency.Gip)]
    [InlineData(DataMinimumSpendCurrency.Gmd)]
    [InlineData(DataMinimumSpendCurrency.Gyd)]
    [InlineData(DataMinimumSpendCurrency.Hkd)]
    [InlineData(DataMinimumSpendCurrency.Hrk)]
    [InlineData(DataMinimumSpendCurrency.Htg)]
    [InlineData(DataMinimumSpendCurrency.Idr)]
    [InlineData(DataMinimumSpendCurrency.Ils)]
    [InlineData(DataMinimumSpendCurrency.Inr)]
    [InlineData(DataMinimumSpendCurrency.Isk)]
    [InlineData(DataMinimumSpendCurrency.Jmd)]
    [InlineData(DataMinimumSpendCurrency.Jpy)]
    [InlineData(DataMinimumSpendCurrency.Kes)]
    [InlineData(DataMinimumSpendCurrency.Kgs)]
    [InlineData(DataMinimumSpendCurrency.Khr)]
    [InlineData(DataMinimumSpendCurrency.Kmf)]
    [InlineData(DataMinimumSpendCurrency.Krw)]
    [InlineData(DataMinimumSpendCurrency.Kyd)]
    [InlineData(DataMinimumSpendCurrency.Kzt)]
    [InlineData(DataMinimumSpendCurrency.Lbp)]
    [InlineData(DataMinimumSpendCurrency.Lkr)]
    [InlineData(DataMinimumSpendCurrency.Lrd)]
    [InlineData(DataMinimumSpendCurrency.Lsl)]
    [InlineData(DataMinimumSpendCurrency.Mad)]
    [InlineData(DataMinimumSpendCurrency.Mdl)]
    [InlineData(DataMinimumSpendCurrency.Mga)]
    [InlineData(DataMinimumSpendCurrency.Mkd)]
    [InlineData(DataMinimumSpendCurrency.Mmk)]
    [InlineData(DataMinimumSpendCurrency.Mnt)]
    [InlineData(DataMinimumSpendCurrency.Mop)]
    [InlineData(DataMinimumSpendCurrency.Mro)]
    [InlineData(DataMinimumSpendCurrency.Mvr)]
    [InlineData(DataMinimumSpendCurrency.Mwk)]
    [InlineData(DataMinimumSpendCurrency.Mxn)]
    [InlineData(DataMinimumSpendCurrency.Myr)]
    [InlineData(DataMinimumSpendCurrency.Mzn)]
    [InlineData(DataMinimumSpendCurrency.Nad)]
    [InlineData(DataMinimumSpendCurrency.Ngn)]
    [InlineData(DataMinimumSpendCurrency.Nok)]
    [InlineData(DataMinimumSpendCurrency.Npr)]
    [InlineData(DataMinimumSpendCurrency.Nzd)]
    [InlineData(DataMinimumSpendCurrency.Pgk)]
    [InlineData(DataMinimumSpendCurrency.Php)]
    [InlineData(DataMinimumSpendCurrency.Pkr)]
    [InlineData(DataMinimumSpendCurrency.Pln)]
    [InlineData(DataMinimumSpendCurrency.Qar)]
    [InlineData(DataMinimumSpendCurrency.Ron)]
    [InlineData(DataMinimumSpendCurrency.Rsd)]
    [InlineData(DataMinimumSpendCurrency.Rub)]
    [InlineData(DataMinimumSpendCurrency.Rwf)]
    [InlineData(DataMinimumSpendCurrency.Sar)]
    [InlineData(DataMinimumSpendCurrency.Sbd)]
    [InlineData(DataMinimumSpendCurrency.Scr)]
    [InlineData(DataMinimumSpendCurrency.Sek)]
    [InlineData(DataMinimumSpendCurrency.Sgd)]
    [InlineData(DataMinimumSpendCurrency.Sle)]
    [InlineData(DataMinimumSpendCurrency.Sll)]
    [InlineData(DataMinimumSpendCurrency.Sos)]
    [InlineData(DataMinimumSpendCurrency.Szl)]
    [InlineData(DataMinimumSpendCurrency.Thb)]
    [InlineData(DataMinimumSpendCurrency.Tjs)]
    [InlineData(DataMinimumSpendCurrency.Top)]
    [InlineData(DataMinimumSpendCurrency.Try)]
    [InlineData(DataMinimumSpendCurrency.Ttd)]
    [InlineData(DataMinimumSpendCurrency.Tzs)]
    [InlineData(DataMinimumSpendCurrency.Uah)]
    [InlineData(DataMinimumSpendCurrency.Uzs)]
    [InlineData(DataMinimumSpendCurrency.Vnd)]
    [InlineData(DataMinimumSpendCurrency.Vuv)]
    [InlineData(DataMinimumSpendCurrency.Wst)]
    [InlineData(DataMinimumSpendCurrency.Xaf)]
    [InlineData(DataMinimumSpendCurrency.Xcd)]
    [InlineData(DataMinimumSpendCurrency.Yer)]
    [InlineData(DataMinimumSpendCurrency.Zar)]
    [InlineData(DataMinimumSpendCurrency.Zmw)]
    [InlineData(DataMinimumSpendCurrency.Clp)]
    [InlineData(DataMinimumSpendCurrency.Djf)]
    [InlineData(DataMinimumSpendCurrency.Gnf)]
    [InlineData(DataMinimumSpendCurrency.Ugx)]
    [InlineData(DataMinimumSpendCurrency.Pyg)]
    [InlineData(DataMinimumSpendCurrency.Xof)]
    [InlineData(DataMinimumSpendCurrency.Xpf)]
    public void Validation_Works(DataMinimumSpendCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataMinimumSpendCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataMinimumSpendCurrency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DataMinimumSpendCurrency.Usd)]
    [InlineData(DataMinimumSpendCurrency.Aed)]
    [InlineData(DataMinimumSpendCurrency.All)]
    [InlineData(DataMinimumSpendCurrency.Amd)]
    [InlineData(DataMinimumSpendCurrency.Ang)]
    [InlineData(DataMinimumSpendCurrency.Aud)]
    [InlineData(DataMinimumSpendCurrency.Awg)]
    [InlineData(DataMinimumSpendCurrency.Azn)]
    [InlineData(DataMinimumSpendCurrency.Bam)]
    [InlineData(DataMinimumSpendCurrency.Bbd)]
    [InlineData(DataMinimumSpendCurrency.Bdt)]
    [InlineData(DataMinimumSpendCurrency.Bgn)]
    [InlineData(DataMinimumSpendCurrency.Bif)]
    [InlineData(DataMinimumSpendCurrency.Bmd)]
    [InlineData(DataMinimumSpendCurrency.Bnd)]
    [InlineData(DataMinimumSpendCurrency.Bsd)]
    [InlineData(DataMinimumSpendCurrency.Bwp)]
    [InlineData(DataMinimumSpendCurrency.Byn)]
    [InlineData(DataMinimumSpendCurrency.Bzd)]
    [InlineData(DataMinimumSpendCurrency.Brl)]
    [InlineData(DataMinimumSpendCurrency.Cad)]
    [InlineData(DataMinimumSpendCurrency.Cdf)]
    [InlineData(DataMinimumSpendCurrency.Chf)]
    [InlineData(DataMinimumSpendCurrency.Cny)]
    [InlineData(DataMinimumSpendCurrency.Czk)]
    [InlineData(DataMinimumSpendCurrency.Dkk)]
    [InlineData(DataMinimumSpendCurrency.Dop)]
    [InlineData(DataMinimumSpendCurrency.Dzd)]
    [InlineData(DataMinimumSpendCurrency.Egp)]
    [InlineData(DataMinimumSpendCurrency.Etb)]
    [InlineData(DataMinimumSpendCurrency.Eur)]
    [InlineData(DataMinimumSpendCurrency.Fjd)]
    [InlineData(DataMinimumSpendCurrency.Gbp)]
    [InlineData(DataMinimumSpendCurrency.Gel)]
    [InlineData(DataMinimumSpendCurrency.Gip)]
    [InlineData(DataMinimumSpendCurrency.Gmd)]
    [InlineData(DataMinimumSpendCurrency.Gyd)]
    [InlineData(DataMinimumSpendCurrency.Hkd)]
    [InlineData(DataMinimumSpendCurrency.Hrk)]
    [InlineData(DataMinimumSpendCurrency.Htg)]
    [InlineData(DataMinimumSpendCurrency.Idr)]
    [InlineData(DataMinimumSpendCurrency.Ils)]
    [InlineData(DataMinimumSpendCurrency.Inr)]
    [InlineData(DataMinimumSpendCurrency.Isk)]
    [InlineData(DataMinimumSpendCurrency.Jmd)]
    [InlineData(DataMinimumSpendCurrency.Jpy)]
    [InlineData(DataMinimumSpendCurrency.Kes)]
    [InlineData(DataMinimumSpendCurrency.Kgs)]
    [InlineData(DataMinimumSpendCurrency.Khr)]
    [InlineData(DataMinimumSpendCurrency.Kmf)]
    [InlineData(DataMinimumSpendCurrency.Krw)]
    [InlineData(DataMinimumSpendCurrency.Kyd)]
    [InlineData(DataMinimumSpendCurrency.Kzt)]
    [InlineData(DataMinimumSpendCurrency.Lbp)]
    [InlineData(DataMinimumSpendCurrency.Lkr)]
    [InlineData(DataMinimumSpendCurrency.Lrd)]
    [InlineData(DataMinimumSpendCurrency.Lsl)]
    [InlineData(DataMinimumSpendCurrency.Mad)]
    [InlineData(DataMinimumSpendCurrency.Mdl)]
    [InlineData(DataMinimumSpendCurrency.Mga)]
    [InlineData(DataMinimumSpendCurrency.Mkd)]
    [InlineData(DataMinimumSpendCurrency.Mmk)]
    [InlineData(DataMinimumSpendCurrency.Mnt)]
    [InlineData(DataMinimumSpendCurrency.Mop)]
    [InlineData(DataMinimumSpendCurrency.Mro)]
    [InlineData(DataMinimumSpendCurrency.Mvr)]
    [InlineData(DataMinimumSpendCurrency.Mwk)]
    [InlineData(DataMinimumSpendCurrency.Mxn)]
    [InlineData(DataMinimumSpendCurrency.Myr)]
    [InlineData(DataMinimumSpendCurrency.Mzn)]
    [InlineData(DataMinimumSpendCurrency.Nad)]
    [InlineData(DataMinimumSpendCurrency.Ngn)]
    [InlineData(DataMinimumSpendCurrency.Nok)]
    [InlineData(DataMinimumSpendCurrency.Npr)]
    [InlineData(DataMinimumSpendCurrency.Nzd)]
    [InlineData(DataMinimumSpendCurrency.Pgk)]
    [InlineData(DataMinimumSpendCurrency.Php)]
    [InlineData(DataMinimumSpendCurrency.Pkr)]
    [InlineData(DataMinimumSpendCurrency.Pln)]
    [InlineData(DataMinimumSpendCurrency.Qar)]
    [InlineData(DataMinimumSpendCurrency.Ron)]
    [InlineData(DataMinimumSpendCurrency.Rsd)]
    [InlineData(DataMinimumSpendCurrency.Rub)]
    [InlineData(DataMinimumSpendCurrency.Rwf)]
    [InlineData(DataMinimumSpendCurrency.Sar)]
    [InlineData(DataMinimumSpendCurrency.Sbd)]
    [InlineData(DataMinimumSpendCurrency.Scr)]
    [InlineData(DataMinimumSpendCurrency.Sek)]
    [InlineData(DataMinimumSpendCurrency.Sgd)]
    [InlineData(DataMinimumSpendCurrency.Sle)]
    [InlineData(DataMinimumSpendCurrency.Sll)]
    [InlineData(DataMinimumSpendCurrency.Sos)]
    [InlineData(DataMinimumSpendCurrency.Szl)]
    [InlineData(DataMinimumSpendCurrency.Thb)]
    [InlineData(DataMinimumSpendCurrency.Tjs)]
    [InlineData(DataMinimumSpendCurrency.Top)]
    [InlineData(DataMinimumSpendCurrency.Try)]
    [InlineData(DataMinimumSpendCurrency.Ttd)]
    [InlineData(DataMinimumSpendCurrency.Tzs)]
    [InlineData(DataMinimumSpendCurrency.Uah)]
    [InlineData(DataMinimumSpendCurrency.Uzs)]
    [InlineData(DataMinimumSpendCurrency.Vnd)]
    [InlineData(DataMinimumSpendCurrency.Vuv)]
    [InlineData(DataMinimumSpendCurrency.Wst)]
    [InlineData(DataMinimumSpendCurrency.Xaf)]
    [InlineData(DataMinimumSpendCurrency.Xcd)]
    [InlineData(DataMinimumSpendCurrency.Yer)]
    [InlineData(DataMinimumSpendCurrency.Zar)]
    [InlineData(DataMinimumSpendCurrency.Zmw)]
    [InlineData(DataMinimumSpendCurrency.Clp)]
    [InlineData(DataMinimumSpendCurrency.Djf)]
    [InlineData(DataMinimumSpendCurrency.Gnf)]
    [InlineData(DataMinimumSpendCurrency.Ugx)]
    [InlineData(DataMinimumSpendCurrency.Pyg)]
    [InlineData(DataMinimumSpendCurrency.Xof)]
    [InlineData(DataMinimumSpendCurrency.Xpf)]
    public void SerializationRoundtrip_Works(DataMinimumSpendCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataMinimumSpendCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DataMinimumSpendCurrency>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataMinimumSpendCurrency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DataMinimumSpendCurrency>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DataPaymentCollectionMethodTest : TestBase
{
    [Theory]
    [InlineData(DataPaymentCollectionMethod.Charge)]
    [InlineData(DataPaymentCollectionMethod.Invoice)]
    [InlineData(DataPaymentCollectionMethod.None)]
    public void Validation_Works(DataPaymentCollectionMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataPaymentCollectionMethod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataPaymentCollectionMethod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DataPaymentCollectionMethod.Charge)]
    [InlineData(DataPaymentCollectionMethod.Invoice)]
    [InlineData(DataPaymentCollectionMethod.None)]
    public void SerializationRoundtrip_Works(DataPaymentCollectionMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataPaymentCollectionMethod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DataPaymentCollectionMethod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataPaymentCollectionMethod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DataPaymentCollectionMethod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Price
        {
            AddonID = "addonId",
            Amount = 0,
            BaseCharge = true,
            BillingCountryCode = "billingCountryCode",
            BlockSize = 0,
            Currency = PriceCurrency.Usd,
            FeatureID = "featureId",
            Tiers =
            [
                new()
                {
                    FlatPrice = new() { Amount = 0, Currency = PriceTierFlatPriceCurrency.Usd },
                    UnitPrice = new() { Amount = 0, Currency = PriceTierUnitPriceCurrency.Usd },
                    UpTo = 0,
                },
            ],
        };

        string expectedAddonID = "addonId";
        double expectedAmount = 0;
        bool expectedBaseCharge = true;
        string expectedBillingCountryCode = "billingCountryCode";
        double expectedBlockSize = 0;
        ApiEnum<string, PriceCurrency> expectedCurrency = PriceCurrency.Usd;
        string expectedFeatureID = "featureId";
        List<PriceTier> expectedTiers =
        [
            new()
            {
                FlatPrice = new() { Amount = 0, Currency = PriceTierFlatPriceCurrency.Usd },
                UnitPrice = new() { Amount = 0, Currency = PriceTierUnitPriceCurrency.Usd },
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
        var model = new Price
        {
            AddonID = "addonId",
            Amount = 0,
            BaseCharge = true,
            BillingCountryCode = "billingCountryCode",
            BlockSize = 0,
            Currency = PriceCurrency.Usd,
            FeatureID = "featureId",
            Tiers =
            [
                new()
                {
                    FlatPrice = new() { Amount = 0, Currency = PriceTierFlatPriceCurrency.Usd },
                    UnitPrice = new() { Amount = 0, Currency = PriceTierUnitPriceCurrency.Usd },
                    UpTo = 0,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Price>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Price
        {
            AddonID = "addonId",
            Amount = 0,
            BaseCharge = true,
            BillingCountryCode = "billingCountryCode",
            BlockSize = 0,
            Currency = PriceCurrency.Usd,
            FeatureID = "featureId",
            Tiers =
            [
                new()
                {
                    FlatPrice = new() { Amount = 0, Currency = PriceTierFlatPriceCurrency.Usd },
                    UnitPrice = new() { Amount = 0, Currency = PriceTierUnitPriceCurrency.Usd },
                    UpTo = 0,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Price>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedAddonID = "addonId";
        double expectedAmount = 0;
        bool expectedBaseCharge = true;
        string expectedBillingCountryCode = "billingCountryCode";
        double expectedBlockSize = 0;
        ApiEnum<string, PriceCurrency> expectedCurrency = PriceCurrency.Usd;
        string expectedFeatureID = "featureId";
        List<PriceTier> expectedTiers =
        [
            new()
            {
                FlatPrice = new() { Amount = 0, Currency = PriceTierFlatPriceCurrency.Usd },
                UnitPrice = new() { Amount = 0, Currency = PriceTierUnitPriceCurrency.Usd },
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
        var model = new Price
        {
            AddonID = "addonId",
            Amount = 0,
            BaseCharge = true,
            BillingCountryCode = "billingCountryCode",
            BlockSize = 0,
            Currency = PriceCurrency.Usd,
            FeatureID = "featureId",
            Tiers =
            [
                new()
                {
                    FlatPrice = new() { Amount = 0, Currency = PriceTierFlatPriceCurrency.Usd },
                    UnitPrice = new() { Amount = 0, Currency = PriceTierUnitPriceCurrency.Usd },
                    UpTo = 0,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Price { AddonID = "addonId", FeatureID = "featureId" };

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
        var model = new Price { AddonID = "addonId", FeatureID = "featureId" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Price
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
        var model = new Price
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
        var model = new Price
        {
            Amount = 0,
            BaseCharge = true,
            BillingCountryCode = "billingCountryCode",
            BlockSize = 0,
            Currency = PriceCurrency.Usd,
            Tiers =
            [
                new()
                {
                    FlatPrice = new() { Amount = 0, Currency = PriceTierFlatPriceCurrency.Usd },
                    UnitPrice = new() { Amount = 0, Currency = PriceTierUnitPriceCurrency.Usd },
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
        var model = new Price
        {
            Amount = 0,
            BaseCharge = true,
            BillingCountryCode = "billingCountryCode",
            BlockSize = 0,
            Currency = PriceCurrency.Usd,
            Tiers =
            [
                new()
                {
                    FlatPrice = new() { Amount = 0, Currency = PriceTierFlatPriceCurrency.Usd },
                    UnitPrice = new() { Amount = 0, Currency = PriceTierUnitPriceCurrency.Usd },
                    UpTo = 0,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Price
        {
            Amount = 0,
            BaseCharge = true,
            BillingCountryCode = "billingCountryCode",
            BlockSize = 0,
            Currency = PriceCurrency.Usd,
            Tiers =
            [
                new()
                {
                    FlatPrice = new() { Amount = 0, Currency = PriceTierFlatPriceCurrency.Usd },
                    UnitPrice = new() { Amount = 0, Currency = PriceTierUnitPriceCurrency.Usd },
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
        var model = new Price
        {
            Amount = 0,
            BaseCharge = true,
            BillingCountryCode = "billingCountryCode",
            BlockSize = 0,
            Currency = PriceCurrency.Usd,
            Tiers =
            [
                new()
                {
                    FlatPrice = new() { Amount = 0, Currency = PriceTierFlatPriceCurrency.Usd },
                    UnitPrice = new() { Amount = 0, Currency = PriceTierUnitPriceCurrency.Usd },
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
        var model = new Price
        {
            AddonID = "addonId",
            Amount = 0,
            BaseCharge = true,
            BillingCountryCode = "billingCountryCode",
            BlockSize = 0,
            Currency = PriceCurrency.Usd,
            FeatureID = "featureId",
            Tiers =
            [
                new()
                {
                    FlatPrice = new() { Amount = 0, Currency = PriceTierFlatPriceCurrency.Usd },
                    UnitPrice = new() { Amount = 0, Currency = PriceTierUnitPriceCurrency.Usd },
                    UpTo = 0,
                },
            ],
        };

        Price copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PriceCurrencyTest : TestBase
{
    [Theory]
    [InlineData(PriceCurrency.Usd)]
    [InlineData(PriceCurrency.Aed)]
    [InlineData(PriceCurrency.All)]
    [InlineData(PriceCurrency.Amd)]
    [InlineData(PriceCurrency.Ang)]
    [InlineData(PriceCurrency.Aud)]
    [InlineData(PriceCurrency.Awg)]
    [InlineData(PriceCurrency.Azn)]
    [InlineData(PriceCurrency.Bam)]
    [InlineData(PriceCurrency.Bbd)]
    [InlineData(PriceCurrency.Bdt)]
    [InlineData(PriceCurrency.Bgn)]
    [InlineData(PriceCurrency.Bif)]
    [InlineData(PriceCurrency.Bmd)]
    [InlineData(PriceCurrency.Bnd)]
    [InlineData(PriceCurrency.Bsd)]
    [InlineData(PriceCurrency.Bwp)]
    [InlineData(PriceCurrency.Byn)]
    [InlineData(PriceCurrency.Bzd)]
    [InlineData(PriceCurrency.Brl)]
    [InlineData(PriceCurrency.Cad)]
    [InlineData(PriceCurrency.Cdf)]
    [InlineData(PriceCurrency.Chf)]
    [InlineData(PriceCurrency.Cny)]
    [InlineData(PriceCurrency.Czk)]
    [InlineData(PriceCurrency.Dkk)]
    [InlineData(PriceCurrency.Dop)]
    [InlineData(PriceCurrency.Dzd)]
    [InlineData(PriceCurrency.Egp)]
    [InlineData(PriceCurrency.Etb)]
    [InlineData(PriceCurrency.Eur)]
    [InlineData(PriceCurrency.Fjd)]
    [InlineData(PriceCurrency.Gbp)]
    [InlineData(PriceCurrency.Gel)]
    [InlineData(PriceCurrency.Gip)]
    [InlineData(PriceCurrency.Gmd)]
    [InlineData(PriceCurrency.Gyd)]
    [InlineData(PriceCurrency.Hkd)]
    [InlineData(PriceCurrency.Hrk)]
    [InlineData(PriceCurrency.Htg)]
    [InlineData(PriceCurrency.Idr)]
    [InlineData(PriceCurrency.Ils)]
    [InlineData(PriceCurrency.Inr)]
    [InlineData(PriceCurrency.Isk)]
    [InlineData(PriceCurrency.Jmd)]
    [InlineData(PriceCurrency.Jpy)]
    [InlineData(PriceCurrency.Kes)]
    [InlineData(PriceCurrency.Kgs)]
    [InlineData(PriceCurrency.Khr)]
    [InlineData(PriceCurrency.Kmf)]
    [InlineData(PriceCurrency.Krw)]
    [InlineData(PriceCurrency.Kyd)]
    [InlineData(PriceCurrency.Kzt)]
    [InlineData(PriceCurrency.Lbp)]
    [InlineData(PriceCurrency.Lkr)]
    [InlineData(PriceCurrency.Lrd)]
    [InlineData(PriceCurrency.Lsl)]
    [InlineData(PriceCurrency.Mad)]
    [InlineData(PriceCurrency.Mdl)]
    [InlineData(PriceCurrency.Mga)]
    [InlineData(PriceCurrency.Mkd)]
    [InlineData(PriceCurrency.Mmk)]
    [InlineData(PriceCurrency.Mnt)]
    [InlineData(PriceCurrency.Mop)]
    [InlineData(PriceCurrency.Mro)]
    [InlineData(PriceCurrency.Mvr)]
    [InlineData(PriceCurrency.Mwk)]
    [InlineData(PriceCurrency.Mxn)]
    [InlineData(PriceCurrency.Myr)]
    [InlineData(PriceCurrency.Mzn)]
    [InlineData(PriceCurrency.Nad)]
    [InlineData(PriceCurrency.Ngn)]
    [InlineData(PriceCurrency.Nok)]
    [InlineData(PriceCurrency.Npr)]
    [InlineData(PriceCurrency.Nzd)]
    [InlineData(PriceCurrency.Pgk)]
    [InlineData(PriceCurrency.Php)]
    [InlineData(PriceCurrency.Pkr)]
    [InlineData(PriceCurrency.Pln)]
    [InlineData(PriceCurrency.Qar)]
    [InlineData(PriceCurrency.Ron)]
    [InlineData(PriceCurrency.Rsd)]
    [InlineData(PriceCurrency.Rub)]
    [InlineData(PriceCurrency.Rwf)]
    [InlineData(PriceCurrency.Sar)]
    [InlineData(PriceCurrency.Sbd)]
    [InlineData(PriceCurrency.Scr)]
    [InlineData(PriceCurrency.Sek)]
    [InlineData(PriceCurrency.Sgd)]
    [InlineData(PriceCurrency.Sle)]
    [InlineData(PriceCurrency.Sll)]
    [InlineData(PriceCurrency.Sos)]
    [InlineData(PriceCurrency.Szl)]
    [InlineData(PriceCurrency.Thb)]
    [InlineData(PriceCurrency.Tjs)]
    [InlineData(PriceCurrency.Top)]
    [InlineData(PriceCurrency.Try)]
    [InlineData(PriceCurrency.Ttd)]
    [InlineData(PriceCurrency.Tzs)]
    [InlineData(PriceCurrency.Uah)]
    [InlineData(PriceCurrency.Uzs)]
    [InlineData(PriceCurrency.Vnd)]
    [InlineData(PriceCurrency.Vuv)]
    [InlineData(PriceCurrency.Wst)]
    [InlineData(PriceCurrency.Xaf)]
    [InlineData(PriceCurrency.Xcd)]
    [InlineData(PriceCurrency.Yer)]
    [InlineData(PriceCurrency.Zar)]
    [InlineData(PriceCurrency.Zmw)]
    [InlineData(PriceCurrency.Clp)]
    [InlineData(PriceCurrency.Djf)]
    [InlineData(PriceCurrency.Gnf)]
    [InlineData(PriceCurrency.Ugx)]
    [InlineData(PriceCurrency.Pyg)]
    [InlineData(PriceCurrency.Xof)]
    [InlineData(PriceCurrency.Xpf)]
    public void Validation_Works(PriceCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PriceCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PriceCurrency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PriceCurrency.Usd)]
    [InlineData(PriceCurrency.Aed)]
    [InlineData(PriceCurrency.All)]
    [InlineData(PriceCurrency.Amd)]
    [InlineData(PriceCurrency.Ang)]
    [InlineData(PriceCurrency.Aud)]
    [InlineData(PriceCurrency.Awg)]
    [InlineData(PriceCurrency.Azn)]
    [InlineData(PriceCurrency.Bam)]
    [InlineData(PriceCurrency.Bbd)]
    [InlineData(PriceCurrency.Bdt)]
    [InlineData(PriceCurrency.Bgn)]
    [InlineData(PriceCurrency.Bif)]
    [InlineData(PriceCurrency.Bmd)]
    [InlineData(PriceCurrency.Bnd)]
    [InlineData(PriceCurrency.Bsd)]
    [InlineData(PriceCurrency.Bwp)]
    [InlineData(PriceCurrency.Byn)]
    [InlineData(PriceCurrency.Bzd)]
    [InlineData(PriceCurrency.Brl)]
    [InlineData(PriceCurrency.Cad)]
    [InlineData(PriceCurrency.Cdf)]
    [InlineData(PriceCurrency.Chf)]
    [InlineData(PriceCurrency.Cny)]
    [InlineData(PriceCurrency.Czk)]
    [InlineData(PriceCurrency.Dkk)]
    [InlineData(PriceCurrency.Dop)]
    [InlineData(PriceCurrency.Dzd)]
    [InlineData(PriceCurrency.Egp)]
    [InlineData(PriceCurrency.Etb)]
    [InlineData(PriceCurrency.Eur)]
    [InlineData(PriceCurrency.Fjd)]
    [InlineData(PriceCurrency.Gbp)]
    [InlineData(PriceCurrency.Gel)]
    [InlineData(PriceCurrency.Gip)]
    [InlineData(PriceCurrency.Gmd)]
    [InlineData(PriceCurrency.Gyd)]
    [InlineData(PriceCurrency.Hkd)]
    [InlineData(PriceCurrency.Hrk)]
    [InlineData(PriceCurrency.Htg)]
    [InlineData(PriceCurrency.Idr)]
    [InlineData(PriceCurrency.Ils)]
    [InlineData(PriceCurrency.Inr)]
    [InlineData(PriceCurrency.Isk)]
    [InlineData(PriceCurrency.Jmd)]
    [InlineData(PriceCurrency.Jpy)]
    [InlineData(PriceCurrency.Kes)]
    [InlineData(PriceCurrency.Kgs)]
    [InlineData(PriceCurrency.Khr)]
    [InlineData(PriceCurrency.Kmf)]
    [InlineData(PriceCurrency.Krw)]
    [InlineData(PriceCurrency.Kyd)]
    [InlineData(PriceCurrency.Kzt)]
    [InlineData(PriceCurrency.Lbp)]
    [InlineData(PriceCurrency.Lkr)]
    [InlineData(PriceCurrency.Lrd)]
    [InlineData(PriceCurrency.Lsl)]
    [InlineData(PriceCurrency.Mad)]
    [InlineData(PriceCurrency.Mdl)]
    [InlineData(PriceCurrency.Mga)]
    [InlineData(PriceCurrency.Mkd)]
    [InlineData(PriceCurrency.Mmk)]
    [InlineData(PriceCurrency.Mnt)]
    [InlineData(PriceCurrency.Mop)]
    [InlineData(PriceCurrency.Mro)]
    [InlineData(PriceCurrency.Mvr)]
    [InlineData(PriceCurrency.Mwk)]
    [InlineData(PriceCurrency.Mxn)]
    [InlineData(PriceCurrency.Myr)]
    [InlineData(PriceCurrency.Mzn)]
    [InlineData(PriceCurrency.Nad)]
    [InlineData(PriceCurrency.Ngn)]
    [InlineData(PriceCurrency.Nok)]
    [InlineData(PriceCurrency.Npr)]
    [InlineData(PriceCurrency.Nzd)]
    [InlineData(PriceCurrency.Pgk)]
    [InlineData(PriceCurrency.Php)]
    [InlineData(PriceCurrency.Pkr)]
    [InlineData(PriceCurrency.Pln)]
    [InlineData(PriceCurrency.Qar)]
    [InlineData(PriceCurrency.Ron)]
    [InlineData(PriceCurrency.Rsd)]
    [InlineData(PriceCurrency.Rub)]
    [InlineData(PriceCurrency.Rwf)]
    [InlineData(PriceCurrency.Sar)]
    [InlineData(PriceCurrency.Sbd)]
    [InlineData(PriceCurrency.Scr)]
    [InlineData(PriceCurrency.Sek)]
    [InlineData(PriceCurrency.Sgd)]
    [InlineData(PriceCurrency.Sle)]
    [InlineData(PriceCurrency.Sll)]
    [InlineData(PriceCurrency.Sos)]
    [InlineData(PriceCurrency.Szl)]
    [InlineData(PriceCurrency.Thb)]
    [InlineData(PriceCurrency.Tjs)]
    [InlineData(PriceCurrency.Top)]
    [InlineData(PriceCurrency.Try)]
    [InlineData(PriceCurrency.Ttd)]
    [InlineData(PriceCurrency.Tzs)]
    [InlineData(PriceCurrency.Uah)]
    [InlineData(PriceCurrency.Uzs)]
    [InlineData(PriceCurrency.Vnd)]
    [InlineData(PriceCurrency.Vuv)]
    [InlineData(PriceCurrency.Wst)]
    [InlineData(PriceCurrency.Xaf)]
    [InlineData(PriceCurrency.Xcd)]
    [InlineData(PriceCurrency.Yer)]
    [InlineData(PriceCurrency.Zar)]
    [InlineData(PriceCurrency.Zmw)]
    [InlineData(PriceCurrency.Clp)]
    [InlineData(PriceCurrency.Djf)]
    [InlineData(PriceCurrency.Gnf)]
    [InlineData(PriceCurrency.Ugx)]
    [InlineData(PriceCurrency.Pyg)]
    [InlineData(PriceCurrency.Xof)]
    [InlineData(PriceCurrency.Xpf)]
    public void SerializationRoundtrip_Works(PriceCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PriceCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PriceCurrency>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PriceCurrency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PriceCurrency>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PriceTierTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PriceTier
        {
            FlatPrice = new() { Amount = 0, Currency = PriceTierFlatPriceCurrency.Usd },
            UnitPrice = new() { Amount = 0, Currency = PriceTierUnitPriceCurrency.Usd },
            UpTo = 0,
        };

        PriceTierFlatPrice expectedFlatPrice = new()
        {
            Amount = 0,
            Currency = PriceTierFlatPriceCurrency.Usd,
        };
        PriceTierUnitPrice expectedUnitPrice = new()
        {
            Amount = 0,
            Currency = PriceTierUnitPriceCurrency.Usd,
        };
        double expectedUpTo = 0;

        Assert.Equal(expectedFlatPrice, model.FlatPrice);
        Assert.Equal(expectedUnitPrice, model.UnitPrice);
        Assert.Equal(expectedUpTo, model.UpTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PriceTier
        {
            FlatPrice = new() { Amount = 0, Currency = PriceTierFlatPriceCurrency.Usd },
            UnitPrice = new() { Amount = 0, Currency = PriceTierUnitPriceCurrency.Usd },
            UpTo = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PriceTier>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PriceTier
        {
            FlatPrice = new() { Amount = 0, Currency = PriceTierFlatPriceCurrency.Usd },
            UnitPrice = new() { Amount = 0, Currency = PriceTierUnitPriceCurrency.Usd },
            UpTo = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PriceTier>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        PriceTierFlatPrice expectedFlatPrice = new()
        {
            Amount = 0,
            Currency = PriceTierFlatPriceCurrency.Usd,
        };
        PriceTierUnitPrice expectedUnitPrice = new()
        {
            Amount = 0,
            Currency = PriceTierUnitPriceCurrency.Usd,
        };
        double expectedUpTo = 0;

        Assert.Equal(expectedFlatPrice, deserialized.FlatPrice);
        Assert.Equal(expectedUnitPrice, deserialized.UnitPrice);
        Assert.Equal(expectedUpTo, deserialized.UpTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PriceTier
        {
            FlatPrice = new() { Amount = 0, Currency = PriceTierFlatPriceCurrency.Usd },
            UnitPrice = new() { Amount = 0, Currency = PriceTierUnitPriceCurrency.Usd },
            UpTo = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PriceTier { };

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
        var model = new PriceTier { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PriceTier
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
        var model = new PriceTier
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
        var model = new PriceTier
        {
            FlatPrice = new() { Amount = 0, Currency = PriceTierFlatPriceCurrency.Usd },
            UnitPrice = new() { Amount = 0, Currency = PriceTierUnitPriceCurrency.Usd },
            UpTo = 0,
        };

        PriceTier copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PriceTierFlatPriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PriceTierFlatPrice
        {
            Amount = 0,
            Currency = PriceTierFlatPriceCurrency.Usd,
        };

        double expectedAmount = 0;
        ApiEnum<string, PriceTierFlatPriceCurrency> expectedCurrency =
            PriceTierFlatPriceCurrency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PriceTierFlatPrice
        {
            Amount = 0,
            Currency = PriceTierFlatPriceCurrency.Usd,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PriceTierFlatPrice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PriceTierFlatPrice
        {
            Amount = 0,
            Currency = PriceTierFlatPriceCurrency.Usd,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PriceTierFlatPrice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        ApiEnum<string, PriceTierFlatPriceCurrency> expectedCurrency =
            PriceTierFlatPriceCurrency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PriceTierFlatPrice
        {
            Amount = 0,
            Currency = PriceTierFlatPriceCurrency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PriceTierFlatPrice
        {
            Amount = 0,
            Currency = PriceTierFlatPriceCurrency.Usd,
        };

        PriceTierFlatPrice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PriceTierFlatPriceCurrencyTest : TestBase
{
    [Theory]
    [InlineData(PriceTierFlatPriceCurrency.Usd)]
    [InlineData(PriceTierFlatPriceCurrency.Aed)]
    [InlineData(PriceTierFlatPriceCurrency.All)]
    [InlineData(PriceTierFlatPriceCurrency.Amd)]
    [InlineData(PriceTierFlatPriceCurrency.Ang)]
    [InlineData(PriceTierFlatPriceCurrency.Aud)]
    [InlineData(PriceTierFlatPriceCurrency.Awg)]
    [InlineData(PriceTierFlatPriceCurrency.Azn)]
    [InlineData(PriceTierFlatPriceCurrency.Bam)]
    [InlineData(PriceTierFlatPriceCurrency.Bbd)]
    [InlineData(PriceTierFlatPriceCurrency.Bdt)]
    [InlineData(PriceTierFlatPriceCurrency.Bgn)]
    [InlineData(PriceTierFlatPriceCurrency.Bif)]
    [InlineData(PriceTierFlatPriceCurrency.Bmd)]
    [InlineData(PriceTierFlatPriceCurrency.Bnd)]
    [InlineData(PriceTierFlatPriceCurrency.Bsd)]
    [InlineData(PriceTierFlatPriceCurrency.Bwp)]
    [InlineData(PriceTierFlatPriceCurrency.Byn)]
    [InlineData(PriceTierFlatPriceCurrency.Bzd)]
    [InlineData(PriceTierFlatPriceCurrency.Brl)]
    [InlineData(PriceTierFlatPriceCurrency.Cad)]
    [InlineData(PriceTierFlatPriceCurrency.Cdf)]
    [InlineData(PriceTierFlatPriceCurrency.Chf)]
    [InlineData(PriceTierFlatPriceCurrency.Cny)]
    [InlineData(PriceTierFlatPriceCurrency.Czk)]
    [InlineData(PriceTierFlatPriceCurrency.Dkk)]
    [InlineData(PriceTierFlatPriceCurrency.Dop)]
    [InlineData(PriceTierFlatPriceCurrency.Dzd)]
    [InlineData(PriceTierFlatPriceCurrency.Egp)]
    [InlineData(PriceTierFlatPriceCurrency.Etb)]
    [InlineData(PriceTierFlatPriceCurrency.Eur)]
    [InlineData(PriceTierFlatPriceCurrency.Fjd)]
    [InlineData(PriceTierFlatPriceCurrency.Gbp)]
    [InlineData(PriceTierFlatPriceCurrency.Gel)]
    [InlineData(PriceTierFlatPriceCurrency.Gip)]
    [InlineData(PriceTierFlatPriceCurrency.Gmd)]
    [InlineData(PriceTierFlatPriceCurrency.Gyd)]
    [InlineData(PriceTierFlatPriceCurrency.Hkd)]
    [InlineData(PriceTierFlatPriceCurrency.Hrk)]
    [InlineData(PriceTierFlatPriceCurrency.Htg)]
    [InlineData(PriceTierFlatPriceCurrency.Idr)]
    [InlineData(PriceTierFlatPriceCurrency.Ils)]
    [InlineData(PriceTierFlatPriceCurrency.Inr)]
    [InlineData(PriceTierFlatPriceCurrency.Isk)]
    [InlineData(PriceTierFlatPriceCurrency.Jmd)]
    [InlineData(PriceTierFlatPriceCurrency.Jpy)]
    [InlineData(PriceTierFlatPriceCurrency.Kes)]
    [InlineData(PriceTierFlatPriceCurrency.Kgs)]
    [InlineData(PriceTierFlatPriceCurrency.Khr)]
    [InlineData(PriceTierFlatPriceCurrency.Kmf)]
    [InlineData(PriceTierFlatPriceCurrency.Krw)]
    [InlineData(PriceTierFlatPriceCurrency.Kyd)]
    [InlineData(PriceTierFlatPriceCurrency.Kzt)]
    [InlineData(PriceTierFlatPriceCurrency.Lbp)]
    [InlineData(PriceTierFlatPriceCurrency.Lkr)]
    [InlineData(PriceTierFlatPriceCurrency.Lrd)]
    [InlineData(PriceTierFlatPriceCurrency.Lsl)]
    [InlineData(PriceTierFlatPriceCurrency.Mad)]
    [InlineData(PriceTierFlatPriceCurrency.Mdl)]
    [InlineData(PriceTierFlatPriceCurrency.Mga)]
    [InlineData(PriceTierFlatPriceCurrency.Mkd)]
    [InlineData(PriceTierFlatPriceCurrency.Mmk)]
    [InlineData(PriceTierFlatPriceCurrency.Mnt)]
    [InlineData(PriceTierFlatPriceCurrency.Mop)]
    [InlineData(PriceTierFlatPriceCurrency.Mro)]
    [InlineData(PriceTierFlatPriceCurrency.Mvr)]
    [InlineData(PriceTierFlatPriceCurrency.Mwk)]
    [InlineData(PriceTierFlatPriceCurrency.Mxn)]
    [InlineData(PriceTierFlatPriceCurrency.Myr)]
    [InlineData(PriceTierFlatPriceCurrency.Mzn)]
    [InlineData(PriceTierFlatPriceCurrency.Nad)]
    [InlineData(PriceTierFlatPriceCurrency.Ngn)]
    [InlineData(PriceTierFlatPriceCurrency.Nok)]
    [InlineData(PriceTierFlatPriceCurrency.Npr)]
    [InlineData(PriceTierFlatPriceCurrency.Nzd)]
    [InlineData(PriceTierFlatPriceCurrency.Pgk)]
    [InlineData(PriceTierFlatPriceCurrency.Php)]
    [InlineData(PriceTierFlatPriceCurrency.Pkr)]
    [InlineData(PriceTierFlatPriceCurrency.Pln)]
    [InlineData(PriceTierFlatPriceCurrency.Qar)]
    [InlineData(PriceTierFlatPriceCurrency.Ron)]
    [InlineData(PriceTierFlatPriceCurrency.Rsd)]
    [InlineData(PriceTierFlatPriceCurrency.Rub)]
    [InlineData(PriceTierFlatPriceCurrency.Rwf)]
    [InlineData(PriceTierFlatPriceCurrency.Sar)]
    [InlineData(PriceTierFlatPriceCurrency.Sbd)]
    [InlineData(PriceTierFlatPriceCurrency.Scr)]
    [InlineData(PriceTierFlatPriceCurrency.Sek)]
    [InlineData(PriceTierFlatPriceCurrency.Sgd)]
    [InlineData(PriceTierFlatPriceCurrency.Sle)]
    [InlineData(PriceTierFlatPriceCurrency.Sll)]
    [InlineData(PriceTierFlatPriceCurrency.Sos)]
    [InlineData(PriceTierFlatPriceCurrency.Szl)]
    [InlineData(PriceTierFlatPriceCurrency.Thb)]
    [InlineData(PriceTierFlatPriceCurrency.Tjs)]
    [InlineData(PriceTierFlatPriceCurrency.Top)]
    [InlineData(PriceTierFlatPriceCurrency.Try)]
    [InlineData(PriceTierFlatPriceCurrency.Ttd)]
    [InlineData(PriceTierFlatPriceCurrency.Tzs)]
    [InlineData(PriceTierFlatPriceCurrency.Uah)]
    [InlineData(PriceTierFlatPriceCurrency.Uzs)]
    [InlineData(PriceTierFlatPriceCurrency.Vnd)]
    [InlineData(PriceTierFlatPriceCurrency.Vuv)]
    [InlineData(PriceTierFlatPriceCurrency.Wst)]
    [InlineData(PriceTierFlatPriceCurrency.Xaf)]
    [InlineData(PriceTierFlatPriceCurrency.Xcd)]
    [InlineData(PriceTierFlatPriceCurrency.Yer)]
    [InlineData(PriceTierFlatPriceCurrency.Zar)]
    [InlineData(PriceTierFlatPriceCurrency.Zmw)]
    [InlineData(PriceTierFlatPriceCurrency.Clp)]
    [InlineData(PriceTierFlatPriceCurrency.Djf)]
    [InlineData(PriceTierFlatPriceCurrency.Gnf)]
    [InlineData(PriceTierFlatPriceCurrency.Ugx)]
    [InlineData(PriceTierFlatPriceCurrency.Pyg)]
    [InlineData(PriceTierFlatPriceCurrency.Xof)]
    [InlineData(PriceTierFlatPriceCurrency.Xpf)]
    public void Validation_Works(PriceTierFlatPriceCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PriceTierFlatPriceCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PriceTierFlatPriceCurrency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PriceTierFlatPriceCurrency.Usd)]
    [InlineData(PriceTierFlatPriceCurrency.Aed)]
    [InlineData(PriceTierFlatPriceCurrency.All)]
    [InlineData(PriceTierFlatPriceCurrency.Amd)]
    [InlineData(PriceTierFlatPriceCurrency.Ang)]
    [InlineData(PriceTierFlatPriceCurrency.Aud)]
    [InlineData(PriceTierFlatPriceCurrency.Awg)]
    [InlineData(PriceTierFlatPriceCurrency.Azn)]
    [InlineData(PriceTierFlatPriceCurrency.Bam)]
    [InlineData(PriceTierFlatPriceCurrency.Bbd)]
    [InlineData(PriceTierFlatPriceCurrency.Bdt)]
    [InlineData(PriceTierFlatPriceCurrency.Bgn)]
    [InlineData(PriceTierFlatPriceCurrency.Bif)]
    [InlineData(PriceTierFlatPriceCurrency.Bmd)]
    [InlineData(PriceTierFlatPriceCurrency.Bnd)]
    [InlineData(PriceTierFlatPriceCurrency.Bsd)]
    [InlineData(PriceTierFlatPriceCurrency.Bwp)]
    [InlineData(PriceTierFlatPriceCurrency.Byn)]
    [InlineData(PriceTierFlatPriceCurrency.Bzd)]
    [InlineData(PriceTierFlatPriceCurrency.Brl)]
    [InlineData(PriceTierFlatPriceCurrency.Cad)]
    [InlineData(PriceTierFlatPriceCurrency.Cdf)]
    [InlineData(PriceTierFlatPriceCurrency.Chf)]
    [InlineData(PriceTierFlatPriceCurrency.Cny)]
    [InlineData(PriceTierFlatPriceCurrency.Czk)]
    [InlineData(PriceTierFlatPriceCurrency.Dkk)]
    [InlineData(PriceTierFlatPriceCurrency.Dop)]
    [InlineData(PriceTierFlatPriceCurrency.Dzd)]
    [InlineData(PriceTierFlatPriceCurrency.Egp)]
    [InlineData(PriceTierFlatPriceCurrency.Etb)]
    [InlineData(PriceTierFlatPriceCurrency.Eur)]
    [InlineData(PriceTierFlatPriceCurrency.Fjd)]
    [InlineData(PriceTierFlatPriceCurrency.Gbp)]
    [InlineData(PriceTierFlatPriceCurrency.Gel)]
    [InlineData(PriceTierFlatPriceCurrency.Gip)]
    [InlineData(PriceTierFlatPriceCurrency.Gmd)]
    [InlineData(PriceTierFlatPriceCurrency.Gyd)]
    [InlineData(PriceTierFlatPriceCurrency.Hkd)]
    [InlineData(PriceTierFlatPriceCurrency.Hrk)]
    [InlineData(PriceTierFlatPriceCurrency.Htg)]
    [InlineData(PriceTierFlatPriceCurrency.Idr)]
    [InlineData(PriceTierFlatPriceCurrency.Ils)]
    [InlineData(PriceTierFlatPriceCurrency.Inr)]
    [InlineData(PriceTierFlatPriceCurrency.Isk)]
    [InlineData(PriceTierFlatPriceCurrency.Jmd)]
    [InlineData(PriceTierFlatPriceCurrency.Jpy)]
    [InlineData(PriceTierFlatPriceCurrency.Kes)]
    [InlineData(PriceTierFlatPriceCurrency.Kgs)]
    [InlineData(PriceTierFlatPriceCurrency.Khr)]
    [InlineData(PriceTierFlatPriceCurrency.Kmf)]
    [InlineData(PriceTierFlatPriceCurrency.Krw)]
    [InlineData(PriceTierFlatPriceCurrency.Kyd)]
    [InlineData(PriceTierFlatPriceCurrency.Kzt)]
    [InlineData(PriceTierFlatPriceCurrency.Lbp)]
    [InlineData(PriceTierFlatPriceCurrency.Lkr)]
    [InlineData(PriceTierFlatPriceCurrency.Lrd)]
    [InlineData(PriceTierFlatPriceCurrency.Lsl)]
    [InlineData(PriceTierFlatPriceCurrency.Mad)]
    [InlineData(PriceTierFlatPriceCurrency.Mdl)]
    [InlineData(PriceTierFlatPriceCurrency.Mga)]
    [InlineData(PriceTierFlatPriceCurrency.Mkd)]
    [InlineData(PriceTierFlatPriceCurrency.Mmk)]
    [InlineData(PriceTierFlatPriceCurrency.Mnt)]
    [InlineData(PriceTierFlatPriceCurrency.Mop)]
    [InlineData(PriceTierFlatPriceCurrency.Mro)]
    [InlineData(PriceTierFlatPriceCurrency.Mvr)]
    [InlineData(PriceTierFlatPriceCurrency.Mwk)]
    [InlineData(PriceTierFlatPriceCurrency.Mxn)]
    [InlineData(PriceTierFlatPriceCurrency.Myr)]
    [InlineData(PriceTierFlatPriceCurrency.Mzn)]
    [InlineData(PriceTierFlatPriceCurrency.Nad)]
    [InlineData(PriceTierFlatPriceCurrency.Ngn)]
    [InlineData(PriceTierFlatPriceCurrency.Nok)]
    [InlineData(PriceTierFlatPriceCurrency.Npr)]
    [InlineData(PriceTierFlatPriceCurrency.Nzd)]
    [InlineData(PriceTierFlatPriceCurrency.Pgk)]
    [InlineData(PriceTierFlatPriceCurrency.Php)]
    [InlineData(PriceTierFlatPriceCurrency.Pkr)]
    [InlineData(PriceTierFlatPriceCurrency.Pln)]
    [InlineData(PriceTierFlatPriceCurrency.Qar)]
    [InlineData(PriceTierFlatPriceCurrency.Ron)]
    [InlineData(PriceTierFlatPriceCurrency.Rsd)]
    [InlineData(PriceTierFlatPriceCurrency.Rub)]
    [InlineData(PriceTierFlatPriceCurrency.Rwf)]
    [InlineData(PriceTierFlatPriceCurrency.Sar)]
    [InlineData(PriceTierFlatPriceCurrency.Sbd)]
    [InlineData(PriceTierFlatPriceCurrency.Scr)]
    [InlineData(PriceTierFlatPriceCurrency.Sek)]
    [InlineData(PriceTierFlatPriceCurrency.Sgd)]
    [InlineData(PriceTierFlatPriceCurrency.Sle)]
    [InlineData(PriceTierFlatPriceCurrency.Sll)]
    [InlineData(PriceTierFlatPriceCurrency.Sos)]
    [InlineData(PriceTierFlatPriceCurrency.Szl)]
    [InlineData(PriceTierFlatPriceCurrency.Thb)]
    [InlineData(PriceTierFlatPriceCurrency.Tjs)]
    [InlineData(PriceTierFlatPriceCurrency.Top)]
    [InlineData(PriceTierFlatPriceCurrency.Try)]
    [InlineData(PriceTierFlatPriceCurrency.Ttd)]
    [InlineData(PriceTierFlatPriceCurrency.Tzs)]
    [InlineData(PriceTierFlatPriceCurrency.Uah)]
    [InlineData(PriceTierFlatPriceCurrency.Uzs)]
    [InlineData(PriceTierFlatPriceCurrency.Vnd)]
    [InlineData(PriceTierFlatPriceCurrency.Vuv)]
    [InlineData(PriceTierFlatPriceCurrency.Wst)]
    [InlineData(PriceTierFlatPriceCurrency.Xaf)]
    [InlineData(PriceTierFlatPriceCurrency.Xcd)]
    [InlineData(PriceTierFlatPriceCurrency.Yer)]
    [InlineData(PriceTierFlatPriceCurrency.Zar)]
    [InlineData(PriceTierFlatPriceCurrency.Zmw)]
    [InlineData(PriceTierFlatPriceCurrency.Clp)]
    [InlineData(PriceTierFlatPriceCurrency.Djf)]
    [InlineData(PriceTierFlatPriceCurrency.Gnf)]
    [InlineData(PriceTierFlatPriceCurrency.Ugx)]
    [InlineData(PriceTierFlatPriceCurrency.Pyg)]
    [InlineData(PriceTierFlatPriceCurrency.Xof)]
    [InlineData(PriceTierFlatPriceCurrency.Xpf)]
    public void SerializationRoundtrip_Works(PriceTierFlatPriceCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PriceTierFlatPriceCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PriceTierFlatPriceCurrency>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PriceTierFlatPriceCurrency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PriceTierFlatPriceCurrency>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PriceTierUnitPriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PriceTierUnitPrice
        {
            Amount = 0,
            Currency = PriceTierUnitPriceCurrency.Usd,
        };

        double expectedAmount = 0;
        ApiEnum<string, PriceTierUnitPriceCurrency> expectedCurrency =
            PriceTierUnitPriceCurrency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PriceTierUnitPrice
        {
            Amount = 0,
            Currency = PriceTierUnitPriceCurrency.Usd,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PriceTierUnitPrice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PriceTierUnitPrice
        {
            Amount = 0,
            Currency = PriceTierUnitPriceCurrency.Usd,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PriceTierUnitPrice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        ApiEnum<string, PriceTierUnitPriceCurrency> expectedCurrency =
            PriceTierUnitPriceCurrency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PriceTierUnitPrice
        {
            Amount = 0,
            Currency = PriceTierUnitPriceCurrency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PriceTierUnitPrice
        {
            Amount = 0,
            Currency = PriceTierUnitPriceCurrency.Usd,
        };

        PriceTierUnitPrice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PriceTierUnitPriceCurrencyTest : TestBase
{
    [Theory]
    [InlineData(PriceTierUnitPriceCurrency.Usd)]
    [InlineData(PriceTierUnitPriceCurrency.Aed)]
    [InlineData(PriceTierUnitPriceCurrency.All)]
    [InlineData(PriceTierUnitPriceCurrency.Amd)]
    [InlineData(PriceTierUnitPriceCurrency.Ang)]
    [InlineData(PriceTierUnitPriceCurrency.Aud)]
    [InlineData(PriceTierUnitPriceCurrency.Awg)]
    [InlineData(PriceTierUnitPriceCurrency.Azn)]
    [InlineData(PriceTierUnitPriceCurrency.Bam)]
    [InlineData(PriceTierUnitPriceCurrency.Bbd)]
    [InlineData(PriceTierUnitPriceCurrency.Bdt)]
    [InlineData(PriceTierUnitPriceCurrency.Bgn)]
    [InlineData(PriceTierUnitPriceCurrency.Bif)]
    [InlineData(PriceTierUnitPriceCurrency.Bmd)]
    [InlineData(PriceTierUnitPriceCurrency.Bnd)]
    [InlineData(PriceTierUnitPriceCurrency.Bsd)]
    [InlineData(PriceTierUnitPriceCurrency.Bwp)]
    [InlineData(PriceTierUnitPriceCurrency.Byn)]
    [InlineData(PriceTierUnitPriceCurrency.Bzd)]
    [InlineData(PriceTierUnitPriceCurrency.Brl)]
    [InlineData(PriceTierUnitPriceCurrency.Cad)]
    [InlineData(PriceTierUnitPriceCurrency.Cdf)]
    [InlineData(PriceTierUnitPriceCurrency.Chf)]
    [InlineData(PriceTierUnitPriceCurrency.Cny)]
    [InlineData(PriceTierUnitPriceCurrency.Czk)]
    [InlineData(PriceTierUnitPriceCurrency.Dkk)]
    [InlineData(PriceTierUnitPriceCurrency.Dop)]
    [InlineData(PriceTierUnitPriceCurrency.Dzd)]
    [InlineData(PriceTierUnitPriceCurrency.Egp)]
    [InlineData(PriceTierUnitPriceCurrency.Etb)]
    [InlineData(PriceTierUnitPriceCurrency.Eur)]
    [InlineData(PriceTierUnitPriceCurrency.Fjd)]
    [InlineData(PriceTierUnitPriceCurrency.Gbp)]
    [InlineData(PriceTierUnitPriceCurrency.Gel)]
    [InlineData(PriceTierUnitPriceCurrency.Gip)]
    [InlineData(PriceTierUnitPriceCurrency.Gmd)]
    [InlineData(PriceTierUnitPriceCurrency.Gyd)]
    [InlineData(PriceTierUnitPriceCurrency.Hkd)]
    [InlineData(PriceTierUnitPriceCurrency.Hrk)]
    [InlineData(PriceTierUnitPriceCurrency.Htg)]
    [InlineData(PriceTierUnitPriceCurrency.Idr)]
    [InlineData(PriceTierUnitPriceCurrency.Ils)]
    [InlineData(PriceTierUnitPriceCurrency.Inr)]
    [InlineData(PriceTierUnitPriceCurrency.Isk)]
    [InlineData(PriceTierUnitPriceCurrency.Jmd)]
    [InlineData(PriceTierUnitPriceCurrency.Jpy)]
    [InlineData(PriceTierUnitPriceCurrency.Kes)]
    [InlineData(PriceTierUnitPriceCurrency.Kgs)]
    [InlineData(PriceTierUnitPriceCurrency.Khr)]
    [InlineData(PriceTierUnitPriceCurrency.Kmf)]
    [InlineData(PriceTierUnitPriceCurrency.Krw)]
    [InlineData(PriceTierUnitPriceCurrency.Kyd)]
    [InlineData(PriceTierUnitPriceCurrency.Kzt)]
    [InlineData(PriceTierUnitPriceCurrency.Lbp)]
    [InlineData(PriceTierUnitPriceCurrency.Lkr)]
    [InlineData(PriceTierUnitPriceCurrency.Lrd)]
    [InlineData(PriceTierUnitPriceCurrency.Lsl)]
    [InlineData(PriceTierUnitPriceCurrency.Mad)]
    [InlineData(PriceTierUnitPriceCurrency.Mdl)]
    [InlineData(PriceTierUnitPriceCurrency.Mga)]
    [InlineData(PriceTierUnitPriceCurrency.Mkd)]
    [InlineData(PriceTierUnitPriceCurrency.Mmk)]
    [InlineData(PriceTierUnitPriceCurrency.Mnt)]
    [InlineData(PriceTierUnitPriceCurrency.Mop)]
    [InlineData(PriceTierUnitPriceCurrency.Mro)]
    [InlineData(PriceTierUnitPriceCurrency.Mvr)]
    [InlineData(PriceTierUnitPriceCurrency.Mwk)]
    [InlineData(PriceTierUnitPriceCurrency.Mxn)]
    [InlineData(PriceTierUnitPriceCurrency.Myr)]
    [InlineData(PriceTierUnitPriceCurrency.Mzn)]
    [InlineData(PriceTierUnitPriceCurrency.Nad)]
    [InlineData(PriceTierUnitPriceCurrency.Ngn)]
    [InlineData(PriceTierUnitPriceCurrency.Nok)]
    [InlineData(PriceTierUnitPriceCurrency.Npr)]
    [InlineData(PriceTierUnitPriceCurrency.Nzd)]
    [InlineData(PriceTierUnitPriceCurrency.Pgk)]
    [InlineData(PriceTierUnitPriceCurrency.Php)]
    [InlineData(PriceTierUnitPriceCurrency.Pkr)]
    [InlineData(PriceTierUnitPriceCurrency.Pln)]
    [InlineData(PriceTierUnitPriceCurrency.Qar)]
    [InlineData(PriceTierUnitPriceCurrency.Ron)]
    [InlineData(PriceTierUnitPriceCurrency.Rsd)]
    [InlineData(PriceTierUnitPriceCurrency.Rub)]
    [InlineData(PriceTierUnitPriceCurrency.Rwf)]
    [InlineData(PriceTierUnitPriceCurrency.Sar)]
    [InlineData(PriceTierUnitPriceCurrency.Sbd)]
    [InlineData(PriceTierUnitPriceCurrency.Scr)]
    [InlineData(PriceTierUnitPriceCurrency.Sek)]
    [InlineData(PriceTierUnitPriceCurrency.Sgd)]
    [InlineData(PriceTierUnitPriceCurrency.Sle)]
    [InlineData(PriceTierUnitPriceCurrency.Sll)]
    [InlineData(PriceTierUnitPriceCurrency.Sos)]
    [InlineData(PriceTierUnitPriceCurrency.Szl)]
    [InlineData(PriceTierUnitPriceCurrency.Thb)]
    [InlineData(PriceTierUnitPriceCurrency.Tjs)]
    [InlineData(PriceTierUnitPriceCurrency.Top)]
    [InlineData(PriceTierUnitPriceCurrency.Try)]
    [InlineData(PriceTierUnitPriceCurrency.Ttd)]
    [InlineData(PriceTierUnitPriceCurrency.Tzs)]
    [InlineData(PriceTierUnitPriceCurrency.Uah)]
    [InlineData(PriceTierUnitPriceCurrency.Uzs)]
    [InlineData(PriceTierUnitPriceCurrency.Vnd)]
    [InlineData(PriceTierUnitPriceCurrency.Vuv)]
    [InlineData(PriceTierUnitPriceCurrency.Wst)]
    [InlineData(PriceTierUnitPriceCurrency.Xaf)]
    [InlineData(PriceTierUnitPriceCurrency.Xcd)]
    [InlineData(PriceTierUnitPriceCurrency.Yer)]
    [InlineData(PriceTierUnitPriceCurrency.Zar)]
    [InlineData(PriceTierUnitPriceCurrency.Zmw)]
    [InlineData(PriceTierUnitPriceCurrency.Clp)]
    [InlineData(PriceTierUnitPriceCurrency.Djf)]
    [InlineData(PriceTierUnitPriceCurrency.Gnf)]
    [InlineData(PriceTierUnitPriceCurrency.Ugx)]
    [InlineData(PriceTierUnitPriceCurrency.Pyg)]
    [InlineData(PriceTierUnitPriceCurrency.Xof)]
    [InlineData(PriceTierUnitPriceCurrency.Xpf)]
    public void Validation_Works(PriceTierUnitPriceCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PriceTierUnitPriceCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PriceTierUnitPriceCurrency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PriceTierUnitPriceCurrency.Usd)]
    [InlineData(PriceTierUnitPriceCurrency.Aed)]
    [InlineData(PriceTierUnitPriceCurrency.All)]
    [InlineData(PriceTierUnitPriceCurrency.Amd)]
    [InlineData(PriceTierUnitPriceCurrency.Ang)]
    [InlineData(PriceTierUnitPriceCurrency.Aud)]
    [InlineData(PriceTierUnitPriceCurrency.Awg)]
    [InlineData(PriceTierUnitPriceCurrency.Azn)]
    [InlineData(PriceTierUnitPriceCurrency.Bam)]
    [InlineData(PriceTierUnitPriceCurrency.Bbd)]
    [InlineData(PriceTierUnitPriceCurrency.Bdt)]
    [InlineData(PriceTierUnitPriceCurrency.Bgn)]
    [InlineData(PriceTierUnitPriceCurrency.Bif)]
    [InlineData(PriceTierUnitPriceCurrency.Bmd)]
    [InlineData(PriceTierUnitPriceCurrency.Bnd)]
    [InlineData(PriceTierUnitPriceCurrency.Bsd)]
    [InlineData(PriceTierUnitPriceCurrency.Bwp)]
    [InlineData(PriceTierUnitPriceCurrency.Byn)]
    [InlineData(PriceTierUnitPriceCurrency.Bzd)]
    [InlineData(PriceTierUnitPriceCurrency.Brl)]
    [InlineData(PriceTierUnitPriceCurrency.Cad)]
    [InlineData(PriceTierUnitPriceCurrency.Cdf)]
    [InlineData(PriceTierUnitPriceCurrency.Chf)]
    [InlineData(PriceTierUnitPriceCurrency.Cny)]
    [InlineData(PriceTierUnitPriceCurrency.Czk)]
    [InlineData(PriceTierUnitPriceCurrency.Dkk)]
    [InlineData(PriceTierUnitPriceCurrency.Dop)]
    [InlineData(PriceTierUnitPriceCurrency.Dzd)]
    [InlineData(PriceTierUnitPriceCurrency.Egp)]
    [InlineData(PriceTierUnitPriceCurrency.Etb)]
    [InlineData(PriceTierUnitPriceCurrency.Eur)]
    [InlineData(PriceTierUnitPriceCurrency.Fjd)]
    [InlineData(PriceTierUnitPriceCurrency.Gbp)]
    [InlineData(PriceTierUnitPriceCurrency.Gel)]
    [InlineData(PriceTierUnitPriceCurrency.Gip)]
    [InlineData(PriceTierUnitPriceCurrency.Gmd)]
    [InlineData(PriceTierUnitPriceCurrency.Gyd)]
    [InlineData(PriceTierUnitPriceCurrency.Hkd)]
    [InlineData(PriceTierUnitPriceCurrency.Hrk)]
    [InlineData(PriceTierUnitPriceCurrency.Htg)]
    [InlineData(PriceTierUnitPriceCurrency.Idr)]
    [InlineData(PriceTierUnitPriceCurrency.Ils)]
    [InlineData(PriceTierUnitPriceCurrency.Inr)]
    [InlineData(PriceTierUnitPriceCurrency.Isk)]
    [InlineData(PriceTierUnitPriceCurrency.Jmd)]
    [InlineData(PriceTierUnitPriceCurrency.Jpy)]
    [InlineData(PriceTierUnitPriceCurrency.Kes)]
    [InlineData(PriceTierUnitPriceCurrency.Kgs)]
    [InlineData(PriceTierUnitPriceCurrency.Khr)]
    [InlineData(PriceTierUnitPriceCurrency.Kmf)]
    [InlineData(PriceTierUnitPriceCurrency.Krw)]
    [InlineData(PriceTierUnitPriceCurrency.Kyd)]
    [InlineData(PriceTierUnitPriceCurrency.Kzt)]
    [InlineData(PriceTierUnitPriceCurrency.Lbp)]
    [InlineData(PriceTierUnitPriceCurrency.Lkr)]
    [InlineData(PriceTierUnitPriceCurrency.Lrd)]
    [InlineData(PriceTierUnitPriceCurrency.Lsl)]
    [InlineData(PriceTierUnitPriceCurrency.Mad)]
    [InlineData(PriceTierUnitPriceCurrency.Mdl)]
    [InlineData(PriceTierUnitPriceCurrency.Mga)]
    [InlineData(PriceTierUnitPriceCurrency.Mkd)]
    [InlineData(PriceTierUnitPriceCurrency.Mmk)]
    [InlineData(PriceTierUnitPriceCurrency.Mnt)]
    [InlineData(PriceTierUnitPriceCurrency.Mop)]
    [InlineData(PriceTierUnitPriceCurrency.Mro)]
    [InlineData(PriceTierUnitPriceCurrency.Mvr)]
    [InlineData(PriceTierUnitPriceCurrency.Mwk)]
    [InlineData(PriceTierUnitPriceCurrency.Mxn)]
    [InlineData(PriceTierUnitPriceCurrency.Myr)]
    [InlineData(PriceTierUnitPriceCurrency.Mzn)]
    [InlineData(PriceTierUnitPriceCurrency.Nad)]
    [InlineData(PriceTierUnitPriceCurrency.Ngn)]
    [InlineData(PriceTierUnitPriceCurrency.Nok)]
    [InlineData(PriceTierUnitPriceCurrency.Npr)]
    [InlineData(PriceTierUnitPriceCurrency.Nzd)]
    [InlineData(PriceTierUnitPriceCurrency.Pgk)]
    [InlineData(PriceTierUnitPriceCurrency.Php)]
    [InlineData(PriceTierUnitPriceCurrency.Pkr)]
    [InlineData(PriceTierUnitPriceCurrency.Pln)]
    [InlineData(PriceTierUnitPriceCurrency.Qar)]
    [InlineData(PriceTierUnitPriceCurrency.Ron)]
    [InlineData(PriceTierUnitPriceCurrency.Rsd)]
    [InlineData(PriceTierUnitPriceCurrency.Rub)]
    [InlineData(PriceTierUnitPriceCurrency.Rwf)]
    [InlineData(PriceTierUnitPriceCurrency.Sar)]
    [InlineData(PriceTierUnitPriceCurrency.Sbd)]
    [InlineData(PriceTierUnitPriceCurrency.Scr)]
    [InlineData(PriceTierUnitPriceCurrency.Sek)]
    [InlineData(PriceTierUnitPriceCurrency.Sgd)]
    [InlineData(PriceTierUnitPriceCurrency.Sle)]
    [InlineData(PriceTierUnitPriceCurrency.Sll)]
    [InlineData(PriceTierUnitPriceCurrency.Sos)]
    [InlineData(PriceTierUnitPriceCurrency.Szl)]
    [InlineData(PriceTierUnitPriceCurrency.Thb)]
    [InlineData(PriceTierUnitPriceCurrency.Tjs)]
    [InlineData(PriceTierUnitPriceCurrency.Top)]
    [InlineData(PriceTierUnitPriceCurrency.Try)]
    [InlineData(PriceTierUnitPriceCurrency.Ttd)]
    [InlineData(PriceTierUnitPriceCurrency.Tzs)]
    [InlineData(PriceTierUnitPriceCurrency.Uah)]
    [InlineData(PriceTierUnitPriceCurrency.Uzs)]
    [InlineData(PriceTierUnitPriceCurrency.Vnd)]
    [InlineData(PriceTierUnitPriceCurrency.Vuv)]
    [InlineData(PriceTierUnitPriceCurrency.Wst)]
    [InlineData(PriceTierUnitPriceCurrency.Xaf)]
    [InlineData(PriceTierUnitPriceCurrency.Xcd)]
    [InlineData(PriceTierUnitPriceCurrency.Yer)]
    [InlineData(PriceTierUnitPriceCurrency.Zar)]
    [InlineData(PriceTierUnitPriceCurrency.Zmw)]
    [InlineData(PriceTierUnitPriceCurrency.Clp)]
    [InlineData(PriceTierUnitPriceCurrency.Djf)]
    [InlineData(PriceTierUnitPriceCurrency.Gnf)]
    [InlineData(PriceTierUnitPriceCurrency.Ugx)]
    [InlineData(PriceTierUnitPriceCurrency.Pyg)]
    [InlineData(PriceTierUnitPriceCurrency.Xof)]
    [InlineData(PriceTierUnitPriceCurrency.Xpf)]
    public void SerializationRoundtrip_Works(PriceTierUnitPriceCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PriceTierUnitPriceCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PriceTierUnitPriceCurrency>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PriceTierUnitPriceCurrency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PriceTierUnitPriceCurrency>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DataSubscriptionEntitlementTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DataSubscriptionEntitlement
        {
            ID = "id",
            Type = DataSubscriptionEntitlementType.Feature,
        };

        string expectedID = "id";
        ApiEnum<string, DataSubscriptionEntitlementType> expectedType =
            DataSubscriptionEntitlementType.Feature;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DataSubscriptionEntitlement
        {
            ID = "id",
            Type = DataSubscriptionEntitlementType.Feature,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataSubscriptionEntitlement>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DataSubscriptionEntitlement
        {
            ID = "id",
            Type = DataSubscriptionEntitlementType.Feature,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataSubscriptionEntitlement>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        ApiEnum<string, DataSubscriptionEntitlementType> expectedType =
            DataSubscriptionEntitlementType.Feature;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DataSubscriptionEntitlement
        {
            ID = "id",
            Type = DataSubscriptionEntitlementType.Feature,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DataSubscriptionEntitlement
        {
            ID = "id",
            Type = DataSubscriptionEntitlementType.Feature,
        };

        DataSubscriptionEntitlement copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataSubscriptionEntitlementTypeTest : TestBase
{
    [Theory]
    [InlineData(DataSubscriptionEntitlementType.Feature)]
    [InlineData(DataSubscriptionEntitlementType.Credit)]
    public void Validation_Works(DataSubscriptionEntitlementType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataSubscriptionEntitlementType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataSubscriptionEntitlementType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DataSubscriptionEntitlementType.Feature)]
    [InlineData(DataSubscriptionEntitlementType.Credit)]
    public void SerializationRoundtrip_Works(DataSubscriptionEntitlementType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataSubscriptionEntitlementType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DataSubscriptionEntitlementType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataSubscriptionEntitlementType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DataSubscriptionEntitlementType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TrialTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Trial { TrialEndBehavior = TrialTrialEndBehavior.ConvertToPaid };

        ApiEnum<string, TrialTrialEndBehavior> expectedTrialEndBehavior =
            TrialTrialEndBehavior.ConvertToPaid;

        Assert.Equal(expectedTrialEndBehavior, model.TrialEndBehavior);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Trial { TrialEndBehavior = TrialTrialEndBehavior.ConvertToPaid };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Trial>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Trial { TrialEndBehavior = TrialTrialEndBehavior.ConvertToPaid };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Trial>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        ApiEnum<string, TrialTrialEndBehavior> expectedTrialEndBehavior =
            TrialTrialEndBehavior.ConvertToPaid;

        Assert.Equal(expectedTrialEndBehavior, deserialized.TrialEndBehavior);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Trial { TrialEndBehavior = TrialTrialEndBehavior.ConvertToPaid };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Trial { TrialEndBehavior = TrialTrialEndBehavior.ConvertToPaid };

        Trial copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TrialTrialEndBehaviorTest : TestBase
{
    [Theory]
    [InlineData(TrialTrialEndBehavior.ConvertToPaid)]
    [InlineData(TrialTrialEndBehavior.CancelSubscription)]
    public void Validation_Works(TrialTrialEndBehavior rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TrialTrialEndBehavior> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TrialTrialEndBehavior>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TrialTrialEndBehavior.ConvertToPaid)]
    [InlineData(TrialTrialEndBehavior.CancelSubscription)]
    public void SerializationRoundtrip_Works(TrialTrialEndBehavior rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TrialTrialEndBehavior> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TrialTrialEndBehavior>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TrialTrialEndBehavior>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TrialTrialEndBehavior>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
