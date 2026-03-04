using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Subscriptions;

namespace Stigg.Client.Tests.Models.V1.Subscriptions;

public class SubscriptionListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionListResponse
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionListResponsePaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionListResponsePricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionListResponseStatus.PaymentPending,
            Addons = [new() { ID = "id", Quantity = 0 }],
            BillingCycleAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = SubscriptionListResponseCancelReason.UpgradeOrDowngrade,
            Coupons =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    Status = SubscriptionListResponseCouponStatus.Active,
                    AmountsOff =
                    [
                        new()
                        {
                            Amount = 0,
                            Currency = SubscriptionListResponseCouponAmountsOffCurrency.Usd,
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
                        SubscriptionListResponseFutureUpdateScheduleStatus.PendingPayment,
                    SubscriptionScheduleType =
                        SubscriptionListResponseFutureUpdateSubscriptionScheduleType.Downgrade,
                    TargetPackage = new("id"),
                },
            ],
            LatestInvoice = new()
            {
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RequiresAction = true,
                Status = SubscriptionListResponseLatestInvoiceStatus.Open,
                AmountDue = 0,
                BillingReason = SubscriptionListResponseLatestInvoiceBillingReason.BillingCycle,
                Currency = "currency",
                PdfUrl = "pdfUrl",
                Total = 0,
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MinimumSpend = new()
            {
                Amount = 0,
                Currency = SubscriptionListResponseMinimumSpendCurrency.Usd,
            },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod = SubscriptionListResponsePaymentCollectionMethod.Charge,
            Prices =
            [
                new()
                {
                    AddonID = "addonId",
                    Amount = 0,
                    BaseCharge = true,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    Currency = SubscriptionListResponsePriceCurrency.Usd,
                    FeatureID = "featureId",
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency = SubscriptionListResponsePriceTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency = SubscriptionListResponsePriceTierUnitPriceCurrency.Usd,
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
                    Type = SubscriptionListResponseSubscriptionEntitlementType.Feature,
                },
            ],
            Trial = new(SubscriptionListResponseTrialTrialEndBehavior.ConvertToPaid),
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        string expectedBillingID = "billingId";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomerID = "customerId";
        ApiEnum<string, SubscriptionListResponsePaymentCollection> expectedPaymentCollection =
            SubscriptionListResponsePaymentCollection.NotRequired;
        string expectedPlanID = "planId";
        ApiEnum<string, SubscriptionListResponsePricingType> expectedPricingType =
            SubscriptionListResponsePricingType.Free;
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, SubscriptionListResponseStatus> expectedStatus =
            SubscriptionListResponseStatus.PaymentPending;
        List<SubscriptionListResponseAddon> expectedAddons = [new() { ID = "id", Quantity = 0 }];
        DateTimeOffset expectedBillingCycleAnchor = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        SubscriptionListResponseBudget expectedBudget = new() { HasSoftLimit = true, Limit = 0 };
        DateTimeOffset expectedCancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, SubscriptionListResponseCancelReason> expectedCancelReason =
            SubscriptionListResponseCancelReason.UpgradeOrDowngrade;
        List<SubscriptionListResponseCoupon> expectedCoupons =
        [
            new()
            {
                ID = "id",
                Name = "name",
                Status = SubscriptionListResponseCouponStatus.Active,
                AmountsOff =
                [
                    new()
                    {
                        Amount = 0,
                        Currency = SubscriptionListResponseCouponAmountsOffCurrency.Usd,
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
        List<SubscriptionListResponseFutureUpdate> expectedFutureUpdates =
        [
            new()
            {
                ScheduledExecutionTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ScheduleStatus = SubscriptionListResponseFutureUpdateScheduleStatus.PendingPayment,
                SubscriptionScheduleType =
                    SubscriptionListResponseFutureUpdateSubscriptionScheduleType.Downgrade,
                TargetPackage = new("id"),
            },
        ];
        SubscriptionListResponseLatestInvoice expectedLatestInvoice = new()
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = SubscriptionListResponseLatestInvoiceStatus.Open,
            AmountDue = 0,
            BillingReason = SubscriptionListResponseLatestInvoiceBillingReason.BillingCycle,
            Currency = "currency",
            PdfUrl = "pdfUrl",
            Total = 0,
        };
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        SubscriptionListResponseMinimumSpend expectedMinimumSpend = new()
        {
            Amount = 0,
            Currency = SubscriptionListResponseMinimumSpendCurrency.Usd,
        };
        string expectedPayingCustomerID = "payingCustomerId";
        ApiEnum<
            string,
            SubscriptionListResponsePaymentCollectionMethod
        > expectedPaymentCollectionMethod = SubscriptionListResponsePaymentCollectionMethod.Charge;
        List<SubscriptionListResponsePrice> expectedPrices =
        [
            new()
            {
                AddonID = "addonId",
                Amount = 0,
                BaseCharge = true,
                BillingCountryCode = "billingCountryCode",
                BlockSize = 0,
                Currency = SubscriptionListResponsePriceCurrency.Usd,
                FeatureID = "featureId",
                Tiers =
                [
                    new()
                    {
                        FlatPrice = new()
                        {
                            Amount = 0,
                            Currency = SubscriptionListResponsePriceTierFlatPriceCurrency.Usd,
                        },
                        UnitPrice = new()
                        {
                            Amount = 0,
                            Currency = SubscriptionListResponsePriceTierUnitPriceCurrency.Usd,
                        },
                        UpTo = 0,
                    },
                ],
            },
        ];
        string expectedResourceID = "resourceId";
        List<SubscriptionListResponseSubscriptionEntitlement> expectedSubscriptionEntitlements =
        [
            new() { ID = "id", Type = SubscriptionListResponseSubscriptionEntitlementType.Feature },
        ];
        SubscriptionListResponseTrial expectedTrial = new(
            SubscriptionListResponseTrialTrialEndBehavior.ConvertToPaid
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
        var model = new SubscriptionListResponse
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionListResponsePaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionListResponsePricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionListResponseStatus.PaymentPending,
            Addons = [new() { ID = "id", Quantity = 0 }],
            BillingCycleAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = SubscriptionListResponseCancelReason.UpgradeOrDowngrade,
            Coupons =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    Status = SubscriptionListResponseCouponStatus.Active,
                    AmountsOff =
                    [
                        new()
                        {
                            Amount = 0,
                            Currency = SubscriptionListResponseCouponAmountsOffCurrency.Usd,
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
                        SubscriptionListResponseFutureUpdateScheduleStatus.PendingPayment,
                    SubscriptionScheduleType =
                        SubscriptionListResponseFutureUpdateSubscriptionScheduleType.Downgrade,
                    TargetPackage = new("id"),
                },
            ],
            LatestInvoice = new()
            {
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RequiresAction = true,
                Status = SubscriptionListResponseLatestInvoiceStatus.Open,
                AmountDue = 0,
                BillingReason = SubscriptionListResponseLatestInvoiceBillingReason.BillingCycle,
                Currency = "currency",
                PdfUrl = "pdfUrl",
                Total = 0,
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MinimumSpend = new()
            {
                Amount = 0,
                Currency = SubscriptionListResponseMinimumSpendCurrency.Usd,
            },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod = SubscriptionListResponsePaymentCollectionMethod.Charge,
            Prices =
            [
                new()
                {
                    AddonID = "addonId",
                    Amount = 0,
                    BaseCharge = true,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    Currency = SubscriptionListResponsePriceCurrency.Usd,
                    FeatureID = "featureId",
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency = SubscriptionListResponsePriceTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency = SubscriptionListResponsePriceTierUnitPriceCurrency.Usd,
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
                    Type = SubscriptionListResponseSubscriptionEntitlementType.Feature,
                },
            ],
            Trial = new(SubscriptionListResponseTrialTrialEndBehavior.ConvertToPaid),
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionListResponse
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionListResponsePaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionListResponsePricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionListResponseStatus.PaymentPending,
            Addons = [new() { ID = "id", Quantity = 0 }],
            BillingCycleAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = SubscriptionListResponseCancelReason.UpgradeOrDowngrade,
            Coupons =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    Status = SubscriptionListResponseCouponStatus.Active,
                    AmountsOff =
                    [
                        new()
                        {
                            Amount = 0,
                            Currency = SubscriptionListResponseCouponAmountsOffCurrency.Usd,
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
                        SubscriptionListResponseFutureUpdateScheduleStatus.PendingPayment,
                    SubscriptionScheduleType =
                        SubscriptionListResponseFutureUpdateSubscriptionScheduleType.Downgrade,
                    TargetPackage = new("id"),
                },
            ],
            LatestInvoice = new()
            {
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RequiresAction = true,
                Status = SubscriptionListResponseLatestInvoiceStatus.Open,
                AmountDue = 0,
                BillingReason = SubscriptionListResponseLatestInvoiceBillingReason.BillingCycle,
                Currency = "currency",
                PdfUrl = "pdfUrl",
                Total = 0,
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MinimumSpend = new()
            {
                Amount = 0,
                Currency = SubscriptionListResponseMinimumSpendCurrency.Usd,
            },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod = SubscriptionListResponsePaymentCollectionMethod.Charge,
            Prices =
            [
                new()
                {
                    AddonID = "addonId",
                    Amount = 0,
                    BaseCharge = true,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    Currency = SubscriptionListResponsePriceCurrency.Usd,
                    FeatureID = "featureId",
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency = SubscriptionListResponsePriceTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency = SubscriptionListResponsePriceTierUnitPriceCurrency.Usd,
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
                    Type = SubscriptionListResponseSubscriptionEntitlementType.Feature,
                },
            ],
            Trial = new(SubscriptionListResponseTrialTrialEndBehavior.ConvertToPaid),
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedBillingID = "billingId";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomerID = "customerId";
        ApiEnum<string, SubscriptionListResponsePaymentCollection> expectedPaymentCollection =
            SubscriptionListResponsePaymentCollection.NotRequired;
        string expectedPlanID = "planId";
        ApiEnum<string, SubscriptionListResponsePricingType> expectedPricingType =
            SubscriptionListResponsePricingType.Free;
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, SubscriptionListResponseStatus> expectedStatus =
            SubscriptionListResponseStatus.PaymentPending;
        List<SubscriptionListResponseAddon> expectedAddons = [new() { ID = "id", Quantity = 0 }];
        DateTimeOffset expectedBillingCycleAnchor = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        SubscriptionListResponseBudget expectedBudget = new() { HasSoftLimit = true, Limit = 0 };
        DateTimeOffset expectedCancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, SubscriptionListResponseCancelReason> expectedCancelReason =
            SubscriptionListResponseCancelReason.UpgradeOrDowngrade;
        List<SubscriptionListResponseCoupon> expectedCoupons =
        [
            new()
            {
                ID = "id",
                Name = "name",
                Status = SubscriptionListResponseCouponStatus.Active,
                AmountsOff =
                [
                    new()
                    {
                        Amount = 0,
                        Currency = SubscriptionListResponseCouponAmountsOffCurrency.Usd,
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
        List<SubscriptionListResponseFutureUpdate> expectedFutureUpdates =
        [
            new()
            {
                ScheduledExecutionTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ScheduleStatus = SubscriptionListResponseFutureUpdateScheduleStatus.PendingPayment,
                SubscriptionScheduleType =
                    SubscriptionListResponseFutureUpdateSubscriptionScheduleType.Downgrade,
                TargetPackage = new("id"),
            },
        ];
        SubscriptionListResponseLatestInvoice expectedLatestInvoice = new()
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = SubscriptionListResponseLatestInvoiceStatus.Open,
            AmountDue = 0,
            BillingReason = SubscriptionListResponseLatestInvoiceBillingReason.BillingCycle,
            Currency = "currency",
            PdfUrl = "pdfUrl",
            Total = 0,
        };
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        SubscriptionListResponseMinimumSpend expectedMinimumSpend = new()
        {
            Amount = 0,
            Currency = SubscriptionListResponseMinimumSpendCurrency.Usd,
        };
        string expectedPayingCustomerID = "payingCustomerId";
        ApiEnum<
            string,
            SubscriptionListResponsePaymentCollectionMethod
        > expectedPaymentCollectionMethod = SubscriptionListResponsePaymentCollectionMethod.Charge;
        List<SubscriptionListResponsePrice> expectedPrices =
        [
            new()
            {
                AddonID = "addonId",
                Amount = 0,
                BaseCharge = true,
                BillingCountryCode = "billingCountryCode",
                BlockSize = 0,
                Currency = SubscriptionListResponsePriceCurrency.Usd,
                FeatureID = "featureId",
                Tiers =
                [
                    new()
                    {
                        FlatPrice = new()
                        {
                            Amount = 0,
                            Currency = SubscriptionListResponsePriceTierFlatPriceCurrency.Usd,
                        },
                        UnitPrice = new()
                        {
                            Amount = 0,
                            Currency = SubscriptionListResponsePriceTierUnitPriceCurrency.Usd,
                        },
                        UpTo = 0,
                    },
                ],
            },
        ];
        string expectedResourceID = "resourceId";
        List<SubscriptionListResponseSubscriptionEntitlement> expectedSubscriptionEntitlements =
        [
            new() { ID = "id", Type = SubscriptionListResponseSubscriptionEntitlementType.Feature },
        ];
        SubscriptionListResponseTrial expectedTrial = new(
            SubscriptionListResponseTrialTrialEndBehavior.ConvertToPaid
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
        var model = new SubscriptionListResponse
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionListResponsePaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionListResponsePricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionListResponseStatus.PaymentPending,
            Addons = [new() { ID = "id", Quantity = 0 }],
            BillingCycleAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = SubscriptionListResponseCancelReason.UpgradeOrDowngrade,
            Coupons =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    Status = SubscriptionListResponseCouponStatus.Active,
                    AmountsOff =
                    [
                        new()
                        {
                            Amount = 0,
                            Currency = SubscriptionListResponseCouponAmountsOffCurrency.Usd,
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
                        SubscriptionListResponseFutureUpdateScheduleStatus.PendingPayment,
                    SubscriptionScheduleType =
                        SubscriptionListResponseFutureUpdateSubscriptionScheduleType.Downgrade,
                    TargetPackage = new("id"),
                },
            ],
            LatestInvoice = new()
            {
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RequiresAction = true,
                Status = SubscriptionListResponseLatestInvoiceStatus.Open,
                AmountDue = 0,
                BillingReason = SubscriptionListResponseLatestInvoiceBillingReason.BillingCycle,
                Currency = "currency",
                PdfUrl = "pdfUrl",
                Total = 0,
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MinimumSpend = new()
            {
                Amount = 0,
                Currency = SubscriptionListResponseMinimumSpendCurrency.Usd,
            },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod = SubscriptionListResponsePaymentCollectionMethod.Charge,
            Prices =
            [
                new()
                {
                    AddonID = "addonId",
                    Amount = 0,
                    BaseCharge = true,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    Currency = SubscriptionListResponsePriceCurrency.Usd,
                    FeatureID = "featureId",
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency = SubscriptionListResponsePriceTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency = SubscriptionListResponsePriceTierUnitPriceCurrency.Usd,
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
                    Type = SubscriptionListResponseSubscriptionEntitlementType.Feature,
                },
            ],
            Trial = new(SubscriptionListResponseTrialTrialEndBehavior.ConvertToPaid),
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubscriptionListResponse
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionListResponsePaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionListResponsePricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionListResponseStatus.PaymentPending,
            BillingCycleAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = SubscriptionListResponseCancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LatestInvoice = new()
            {
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RequiresAction = true,
                Status = SubscriptionListResponseLatestInvoiceStatus.Open,
                AmountDue = 0,
                BillingReason = SubscriptionListResponseLatestInvoiceBillingReason.BillingCycle,
                Currency = "currency",
                PdfUrl = "pdfUrl",
                Total = 0,
            },
            MinimumSpend = new()
            {
                Amount = 0,
                Currency = SubscriptionListResponseMinimumSpendCurrency.Usd,
            },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod = SubscriptionListResponsePaymentCollectionMethod.Charge,
            ResourceID = "resourceId",
            Trial = new(SubscriptionListResponseTrialTrialEndBehavior.ConvertToPaid),
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
        var model = new SubscriptionListResponse
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionListResponsePaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionListResponsePricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionListResponseStatus.PaymentPending,
            BillingCycleAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = SubscriptionListResponseCancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LatestInvoice = new()
            {
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RequiresAction = true,
                Status = SubscriptionListResponseLatestInvoiceStatus.Open,
                AmountDue = 0,
                BillingReason = SubscriptionListResponseLatestInvoiceBillingReason.BillingCycle,
                Currency = "currency",
                PdfUrl = "pdfUrl",
                Total = 0,
            },
            MinimumSpend = new()
            {
                Amount = 0,
                Currency = SubscriptionListResponseMinimumSpendCurrency.Usd,
            },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod = SubscriptionListResponsePaymentCollectionMethod.Charge,
            ResourceID = "resourceId",
            Trial = new(SubscriptionListResponseTrialTrialEndBehavior.ConvertToPaid),
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SubscriptionListResponse
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionListResponsePaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionListResponsePricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionListResponseStatus.PaymentPending,
            BillingCycleAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = SubscriptionListResponseCancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LatestInvoice = new()
            {
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RequiresAction = true,
                Status = SubscriptionListResponseLatestInvoiceStatus.Open,
                AmountDue = 0,
                BillingReason = SubscriptionListResponseLatestInvoiceBillingReason.BillingCycle,
                Currency = "currency",
                PdfUrl = "pdfUrl",
                Total = 0,
            },
            MinimumSpend = new()
            {
                Amount = 0,
                Currency = SubscriptionListResponseMinimumSpendCurrency.Usd,
            },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod = SubscriptionListResponsePaymentCollectionMethod.Charge,
            ResourceID = "resourceId",
            Trial = new(SubscriptionListResponseTrialTrialEndBehavior.ConvertToPaid),
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
        var model = new SubscriptionListResponse
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionListResponsePaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionListResponsePricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionListResponseStatus.PaymentPending,
            BillingCycleAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = SubscriptionListResponseCancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LatestInvoice = new()
            {
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RequiresAction = true,
                Status = SubscriptionListResponseLatestInvoiceStatus.Open,
                AmountDue = 0,
                BillingReason = SubscriptionListResponseLatestInvoiceBillingReason.BillingCycle,
                Currency = "currency",
                PdfUrl = "pdfUrl",
                Total = 0,
            },
            MinimumSpend = new()
            {
                Amount = 0,
                Currency = SubscriptionListResponseMinimumSpendCurrency.Usd,
            },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod = SubscriptionListResponsePaymentCollectionMethod.Charge,
            ResourceID = "resourceId",
            Trial = new(SubscriptionListResponseTrialTrialEndBehavior.ConvertToPaid),
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
        var model = new SubscriptionListResponse
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionListResponsePaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionListResponsePricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionListResponseStatus.PaymentPending,
            Addons = [new() { ID = "id", Quantity = 0 }],
            Coupons =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    Status = SubscriptionListResponseCouponStatus.Active,
                    AmountsOff =
                    [
                        new()
                        {
                            Amount = 0,
                            Currency = SubscriptionListResponseCouponAmountsOffCurrency.Usd,
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
                        SubscriptionListResponseFutureUpdateScheduleStatus.PendingPayment,
                    SubscriptionScheduleType =
                        SubscriptionListResponseFutureUpdateSubscriptionScheduleType.Downgrade,
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
                    Currency = SubscriptionListResponsePriceCurrency.Usd,
                    FeatureID = "featureId",
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency = SubscriptionListResponsePriceTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency = SubscriptionListResponsePriceTierUnitPriceCurrency.Usd,
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
                    Type = SubscriptionListResponseSubscriptionEntitlementType.Feature,
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
        var model = new SubscriptionListResponse
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionListResponsePaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionListResponsePricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionListResponseStatus.PaymentPending,
            Addons = [new() { ID = "id", Quantity = 0 }],
            Coupons =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    Status = SubscriptionListResponseCouponStatus.Active,
                    AmountsOff =
                    [
                        new()
                        {
                            Amount = 0,
                            Currency = SubscriptionListResponseCouponAmountsOffCurrency.Usd,
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
                        SubscriptionListResponseFutureUpdateScheduleStatus.PendingPayment,
                    SubscriptionScheduleType =
                        SubscriptionListResponseFutureUpdateSubscriptionScheduleType.Downgrade,
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
                    Currency = SubscriptionListResponsePriceCurrency.Usd,
                    FeatureID = "featureId",
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency = SubscriptionListResponsePriceTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency = SubscriptionListResponsePriceTierUnitPriceCurrency.Usd,
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
                    Type = SubscriptionListResponseSubscriptionEntitlementType.Feature,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SubscriptionListResponse
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionListResponsePaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionListResponsePricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionListResponseStatus.PaymentPending,
            Addons = [new() { ID = "id", Quantity = 0 }],
            Coupons =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    Status = SubscriptionListResponseCouponStatus.Active,
                    AmountsOff =
                    [
                        new()
                        {
                            Amount = 0,
                            Currency = SubscriptionListResponseCouponAmountsOffCurrency.Usd,
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
                        SubscriptionListResponseFutureUpdateScheduleStatus.PendingPayment,
                    SubscriptionScheduleType =
                        SubscriptionListResponseFutureUpdateSubscriptionScheduleType.Downgrade,
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
                    Currency = SubscriptionListResponsePriceCurrency.Usd,
                    FeatureID = "featureId",
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency = SubscriptionListResponsePriceTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency = SubscriptionListResponsePriceTierUnitPriceCurrency.Usd,
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
                    Type = SubscriptionListResponseSubscriptionEntitlementType.Feature,
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
        var model = new SubscriptionListResponse
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionListResponsePaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionListResponsePricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionListResponseStatus.PaymentPending,
            Addons = [new() { ID = "id", Quantity = 0 }],
            Coupons =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    Status = SubscriptionListResponseCouponStatus.Active,
                    AmountsOff =
                    [
                        new()
                        {
                            Amount = 0,
                            Currency = SubscriptionListResponseCouponAmountsOffCurrency.Usd,
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
                        SubscriptionListResponseFutureUpdateScheduleStatus.PendingPayment,
                    SubscriptionScheduleType =
                        SubscriptionListResponseFutureUpdateSubscriptionScheduleType.Downgrade,
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
                    Currency = SubscriptionListResponsePriceCurrency.Usd,
                    FeatureID = "featureId",
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency = SubscriptionListResponsePriceTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency = SubscriptionListResponsePriceTierUnitPriceCurrency.Usd,
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
                    Type = SubscriptionListResponseSubscriptionEntitlementType.Feature,
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
        var model = new SubscriptionListResponse
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionListResponsePaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionListResponsePricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionListResponseStatus.PaymentPending,
            Addons = [new() { ID = "id", Quantity = 0 }],
            BillingCycleAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = SubscriptionListResponseCancelReason.UpgradeOrDowngrade,
            Coupons =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    Status = SubscriptionListResponseCouponStatus.Active,
                    AmountsOff =
                    [
                        new()
                        {
                            Amount = 0,
                            Currency = SubscriptionListResponseCouponAmountsOffCurrency.Usd,
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
                        SubscriptionListResponseFutureUpdateScheduleStatus.PendingPayment,
                    SubscriptionScheduleType =
                        SubscriptionListResponseFutureUpdateSubscriptionScheduleType.Downgrade,
                    TargetPackage = new("id"),
                },
            ],
            LatestInvoice = new()
            {
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RequiresAction = true,
                Status = SubscriptionListResponseLatestInvoiceStatus.Open,
                AmountDue = 0,
                BillingReason = SubscriptionListResponseLatestInvoiceBillingReason.BillingCycle,
                Currency = "currency",
                PdfUrl = "pdfUrl",
                Total = 0,
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MinimumSpend = new()
            {
                Amount = 0,
                Currency = SubscriptionListResponseMinimumSpendCurrency.Usd,
            },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod = SubscriptionListResponsePaymentCollectionMethod.Charge,
            Prices =
            [
                new()
                {
                    AddonID = "addonId",
                    Amount = 0,
                    BaseCharge = true,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    Currency = SubscriptionListResponsePriceCurrency.Usd,
                    FeatureID = "featureId",
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency = SubscriptionListResponsePriceTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency = SubscriptionListResponsePriceTierUnitPriceCurrency.Usd,
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
                    Type = SubscriptionListResponseSubscriptionEntitlementType.Feature,
                },
            ],
            Trial = new(SubscriptionListResponseTrialTrialEndBehavior.ConvertToPaid),
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        SubscriptionListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionListResponsePaymentCollectionTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionListResponsePaymentCollection.NotRequired)]
    [InlineData(SubscriptionListResponsePaymentCollection.Processing)]
    [InlineData(SubscriptionListResponsePaymentCollection.Failed)]
    [InlineData(SubscriptionListResponsePaymentCollection.ActionRequired)]
    public void Validation_Works(SubscriptionListResponsePaymentCollection rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionListResponsePaymentCollection> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionListResponsePaymentCollection>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionListResponsePaymentCollection.NotRequired)]
    [InlineData(SubscriptionListResponsePaymentCollection.Processing)]
    [InlineData(SubscriptionListResponsePaymentCollection.Failed)]
    [InlineData(SubscriptionListResponsePaymentCollection.ActionRequired)]
    public void SerializationRoundtrip_Works(SubscriptionListResponsePaymentCollection rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionListResponsePaymentCollection> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionListResponsePaymentCollection>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionListResponsePaymentCollection>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionListResponsePaymentCollection>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionListResponsePricingTypeTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionListResponsePricingType.Free)]
    [InlineData(SubscriptionListResponsePricingType.Paid)]
    [InlineData(SubscriptionListResponsePricingType.Custom)]
    public void Validation_Works(SubscriptionListResponsePricingType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionListResponsePricingType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionListResponsePricingType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionListResponsePricingType.Free)]
    [InlineData(SubscriptionListResponsePricingType.Paid)]
    [InlineData(SubscriptionListResponsePricingType.Custom)]
    public void SerializationRoundtrip_Works(SubscriptionListResponsePricingType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionListResponsePricingType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionListResponsePricingType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionListResponsePricingType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionListResponsePricingType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionListResponseStatusTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionListResponseStatus.PaymentPending)]
    [InlineData(SubscriptionListResponseStatus.Active)]
    [InlineData(SubscriptionListResponseStatus.Expired)]
    [InlineData(SubscriptionListResponseStatus.InTrial)]
    [InlineData(SubscriptionListResponseStatus.Canceled)]
    [InlineData(SubscriptionListResponseStatus.NotStarted)]
    public void Validation_Works(SubscriptionListResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionListResponseStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SubscriptionListResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionListResponseStatus.PaymentPending)]
    [InlineData(SubscriptionListResponseStatus.Active)]
    [InlineData(SubscriptionListResponseStatus.Expired)]
    [InlineData(SubscriptionListResponseStatus.InTrial)]
    [InlineData(SubscriptionListResponseStatus.Canceled)]
    [InlineData(SubscriptionListResponseStatus.NotStarted)]
    public void SerializationRoundtrip_Works(SubscriptionListResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionListResponseStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionListResponseStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SubscriptionListResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionListResponseStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionListResponseAddonTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionListResponseAddon { ID = "id", Quantity = 0 };

        string expectedID = "id";
        long expectedQuantity = 0;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedQuantity, model.Quantity);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionListResponseAddon { ID = "id", Quantity = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionListResponseAddon>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionListResponseAddon { ID = "id", Quantity = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionListResponseAddon>(
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
        var model = new SubscriptionListResponseAddon { ID = "id", Quantity = 0 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionListResponseAddon { ID = "id", Quantity = 0 };

        SubscriptionListResponseAddon copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionListResponseBudgetTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionListResponseBudget { HasSoftLimit = true, Limit = 0 };

        bool expectedHasSoftLimit = true;
        double expectedLimit = 0;

        Assert.Equal(expectedHasSoftLimit, model.HasSoftLimit);
        Assert.Equal(expectedLimit, model.Limit);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionListResponseBudget { HasSoftLimit = true, Limit = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionListResponseBudget>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionListResponseBudget { HasSoftLimit = true, Limit = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionListResponseBudget>(
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
        var model = new SubscriptionListResponseBudget { HasSoftLimit = true, Limit = 0 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionListResponseBudget { HasSoftLimit = true, Limit = 0 };

        SubscriptionListResponseBudget copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionListResponseCancelReasonTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionListResponseCancelReason.UpgradeOrDowngrade)]
    [InlineData(SubscriptionListResponseCancelReason.CancelledByBilling)]
    [InlineData(SubscriptionListResponseCancelReason.Expired)]
    [InlineData(SubscriptionListResponseCancelReason.DetachBilling)]
    [InlineData(SubscriptionListResponseCancelReason.TrialEnded)]
    [InlineData(SubscriptionListResponseCancelReason.Immediate)]
    [InlineData(SubscriptionListResponseCancelReason.TrialConverted)]
    [InlineData(SubscriptionListResponseCancelReason.PendingPaymentExpired)]
    [InlineData(SubscriptionListResponseCancelReason.ScheduledCancellation)]
    [InlineData(SubscriptionListResponseCancelReason.CustomerArchived)]
    [InlineData(SubscriptionListResponseCancelReason.AutoCancellationRule)]
    public void Validation_Works(SubscriptionListResponseCancelReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionListResponseCancelReason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionListResponseCancelReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionListResponseCancelReason.UpgradeOrDowngrade)]
    [InlineData(SubscriptionListResponseCancelReason.CancelledByBilling)]
    [InlineData(SubscriptionListResponseCancelReason.Expired)]
    [InlineData(SubscriptionListResponseCancelReason.DetachBilling)]
    [InlineData(SubscriptionListResponseCancelReason.TrialEnded)]
    [InlineData(SubscriptionListResponseCancelReason.Immediate)]
    [InlineData(SubscriptionListResponseCancelReason.TrialConverted)]
    [InlineData(SubscriptionListResponseCancelReason.PendingPaymentExpired)]
    [InlineData(SubscriptionListResponseCancelReason.ScheduledCancellation)]
    [InlineData(SubscriptionListResponseCancelReason.CustomerArchived)]
    [InlineData(SubscriptionListResponseCancelReason.AutoCancellationRule)]
    public void SerializationRoundtrip_Works(SubscriptionListResponseCancelReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionListResponseCancelReason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionListResponseCancelReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionListResponseCancelReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionListResponseCancelReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionListResponseCouponTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionListResponseCoupon
        {
            ID = "id",
            Name = "name",
            Status = SubscriptionListResponseCouponStatus.Active,
            AmountsOff =
            [
                new()
                {
                    Amount = 0,
                    Currency = SubscriptionListResponseCouponAmountsOffCurrency.Usd,
                },
            ],
            PercentOff = 0,
        };

        string expectedID = "id";
        string expectedName = "name";
        ApiEnum<string, SubscriptionListResponseCouponStatus> expectedStatus =
            SubscriptionListResponseCouponStatus.Active;
        List<SubscriptionListResponseCouponAmountsOff> expectedAmountsOff =
        [
            new() { Amount = 0, Currency = SubscriptionListResponseCouponAmountsOffCurrency.Usd },
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
        var model = new SubscriptionListResponseCoupon
        {
            ID = "id",
            Name = "name",
            Status = SubscriptionListResponseCouponStatus.Active,
            AmountsOff =
            [
                new()
                {
                    Amount = 0,
                    Currency = SubscriptionListResponseCouponAmountsOffCurrency.Usd,
                },
            ],
            PercentOff = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionListResponseCoupon>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionListResponseCoupon
        {
            ID = "id",
            Name = "name",
            Status = SubscriptionListResponseCouponStatus.Active,
            AmountsOff =
            [
                new()
                {
                    Amount = 0,
                    Currency = SubscriptionListResponseCouponAmountsOffCurrency.Usd,
                },
            ],
            PercentOff = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionListResponseCoupon>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedName = "name";
        ApiEnum<string, SubscriptionListResponseCouponStatus> expectedStatus =
            SubscriptionListResponseCouponStatus.Active;
        List<SubscriptionListResponseCouponAmountsOff> expectedAmountsOff =
        [
            new() { Amount = 0, Currency = SubscriptionListResponseCouponAmountsOffCurrency.Usd },
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
        var model = new SubscriptionListResponseCoupon
        {
            ID = "id",
            Name = "name",
            Status = SubscriptionListResponseCouponStatus.Active,
            AmountsOff =
            [
                new()
                {
                    Amount = 0,
                    Currency = SubscriptionListResponseCouponAmountsOffCurrency.Usd,
                },
            ],
            PercentOff = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubscriptionListResponseCoupon
        {
            ID = "id",
            Name = "name",
            Status = SubscriptionListResponseCouponStatus.Active,
        };

        Assert.Null(model.AmountsOff);
        Assert.False(model.RawData.ContainsKey("amountsOff"));
        Assert.Null(model.PercentOff);
        Assert.False(model.RawData.ContainsKey("percentOff"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new SubscriptionListResponseCoupon
        {
            ID = "id",
            Name = "name",
            Status = SubscriptionListResponseCouponStatus.Active,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SubscriptionListResponseCoupon
        {
            ID = "id",
            Name = "name",
            Status = SubscriptionListResponseCouponStatus.Active,

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
        var model = new SubscriptionListResponseCoupon
        {
            ID = "id",
            Name = "name",
            Status = SubscriptionListResponseCouponStatus.Active,

            AmountsOff = null,
            PercentOff = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionListResponseCoupon
        {
            ID = "id",
            Name = "name",
            Status = SubscriptionListResponseCouponStatus.Active,
            AmountsOff =
            [
                new()
                {
                    Amount = 0,
                    Currency = SubscriptionListResponseCouponAmountsOffCurrency.Usd,
                },
            ],
            PercentOff = 0,
        };

        SubscriptionListResponseCoupon copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionListResponseCouponStatusTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionListResponseCouponStatus.Active)]
    [InlineData(SubscriptionListResponseCouponStatus.Expired)]
    [InlineData(SubscriptionListResponseCouponStatus.Removed)]
    public void Validation_Works(SubscriptionListResponseCouponStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionListResponseCouponStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionListResponseCouponStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionListResponseCouponStatus.Active)]
    [InlineData(SubscriptionListResponseCouponStatus.Expired)]
    [InlineData(SubscriptionListResponseCouponStatus.Removed)]
    public void SerializationRoundtrip_Works(SubscriptionListResponseCouponStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionListResponseCouponStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionListResponseCouponStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionListResponseCouponStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionListResponseCouponStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionListResponseCouponAmountsOffTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionListResponseCouponAmountsOff
        {
            Amount = 0,
            Currency = SubscriptionListResponseCouponAmountsOffCurrency.Usd,
        };

        double expectedAmount = 0;
        ApiEnum<string, SubscriptionListResponseCouponAmountsOffCurrency> expectedCurrency =
            SubscriptionListResponseCouponAmountsOffCurrency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionListResponseCouponAmountsOff
        {
            Amount = 0,
            Currency = SubscriptionListResponseCouponAmountsOffCurrency.Usd,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionListResponseCouponAmountsOff>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionListResponseCouponAmountsOff
        {
            Amount = 0,
            Currency = SubscriptionListResponseCouponAmountsOffCurrency.Usd,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionListResponseCouponAmountsOff>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        ApiEnum<string, SubscriptionListResponseCouponAmountsOffCurrency> expectedCurrency =
            SubscriptionListResponseCouponAmountsOffCurrency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionListResponseCouponAmountsOff
        {
            Amount = 0,
            Currency = SubscriptionListResponseCouponAmountsOffCurrency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubscriptionListResponseCouponAmountsOff { };

        Assert.Null(model.Amount);
        Assert.False(model.RawData.ContainsKey("amount"));
        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SubscriptionListResponseCouponAmountsOff { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SubscriptionListResponseCouponAmountsOff
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
        var model = new SubscriptionListResponseCouponAmountsOff
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
        var model = new SubscriptionListResponseCouponAmountsOff
        {
            Amount = 0,
            Currency = SubscriptionListResponseCouponAmountsOffCurrency.Usd,
        };

        SubscriptionListResponseCouponAmountsOff copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionListResponseCouponAmountsOffCurrencyTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Usd)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Aed)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.All)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Amd)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Ang)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Aud)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Awg)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Azn)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Bam)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Bbd)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Bdt)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Bgn)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Bif)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Bmd)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Bnd)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Bsd)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Bwp)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Byn)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Bzd)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Brl)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Cad)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Cdf)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Chf)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Cny)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Czk)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Dkk)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Dop)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Dzd)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Egp)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Etb)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Eur)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Fjd)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Gbp)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Gel)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Gip)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Gmd)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Gyd)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Hkd)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Hrk)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Htg)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Idr)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Ils)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Inr)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Isk)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Jmd)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Jpy)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Kes)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Kgs)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Khr)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Kmf)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Krw)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Kyd)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Kzt)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Lbp)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Lkr)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Lrd)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Lsl)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Mad)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Mdl)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Mga)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Mkd)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Mmk)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Mnt)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Mop)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Mro)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Mvr)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Mwk)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Mxn)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Myr)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Mzn)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Nad)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Ngn)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Nok)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Npr)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Nzd)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Pgk)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Php)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Pkr)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Pln)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Qar)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Ron)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Rsd)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Rub)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Rwf)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Sar)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Sbd)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Scr)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Sek)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Sgd)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Sle)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Sll)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Sos)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Szl)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Thb)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Tjs)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Top)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Try)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Ttd)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Tzs)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Uah)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Uzs)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Vnd)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Vuv)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Wst)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Xaf)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Xcd)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Yer)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Zar)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Zmw)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Clp)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Djf)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Gnf)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Ugx)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Pyg)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Xof)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Xpf)]
    public void Validation_Works(SubscriptionListResponseCouponAmountsOffCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionListResponseCouponAmountsOffCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionListResponseCouponAmountsOffCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Usd)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Aed)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.All)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Amd)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Ang)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Aud)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Awg)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Azn)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Bam)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Bbd)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Bdt)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Bgn)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Bif)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Bmd)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Bnd)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Bsd)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Bwp)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Byn)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Bzd)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Brl)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Cad)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Cdf)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Chf)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Cny)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Czk)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Dkk)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Dop)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Dzd)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Egp)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Etb)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Eur)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Fjd)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Gbp)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Gel)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Gip)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Gmd)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Gyd)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Hkd)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Hrk)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Htg)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Idr)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Ils)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Inr)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Isk)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Jmd)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Jpy)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Kes)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Kgs)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Khr)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Kmf)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Krw)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Kyd)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Kzt)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Lbp)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Lkr)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Lrd)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Lsl)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Mad)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Mdl)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Mga)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Mkd)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Mmk)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Mnt)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Mop)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Mro)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Mvr)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Mwk)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Mxn)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Myr)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Mzn)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Nad)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Ngn)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Nok)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Npr)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Nzd)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Pgk)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Php)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Pkr)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Pln)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Qar)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Ron)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Rsd)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Rub)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Rwf)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Sar)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Sbd)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Scr)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Sek)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Sgd)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Sle)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Sll)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Sos)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Szl)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Thb)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Tjs)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Top)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Try)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Ttd)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Tzs)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Uah)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Uzs)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Vnd)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Vuv)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Wst)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Xaf)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Xcd)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Yer)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Zar)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Zmw)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Clp)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Djf)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Gnf)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Ugx)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Pyg)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Xof)]
    [InlineData(SubscriptionListResponseCouponAmountsOffCurrency.Xpf)]
    public void SerializationRoundtrip_Works(
        SubscriptionListResponseCouponAmountsOffCurrency rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionListResponseCouponAmountsOffCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionListResponseCouponAmountsOffCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionListResponseCouponAmountsOffCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionListResponseCouponAmountsOffCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionListResponseFutureUpdateTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionListResponseFutureUpdate
        {
            ScheduledExecutionTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ScheduleStatus = SubscriptionListResponseFutureUpdateScheduleStatus.PendingPayment,
            SubscriptionScheduleType =
                SubscriptionListResponseFutureUpdateSubscriptionScheduleType.Downgrade,
            TargetPackage = new("id"),
        };

        DateTimeOffset expectedScheduledExecutionTime = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        ApiEnum<string, SubscriptionListResponseFutureUpdateScheduleStatus> expectedScheduleStatus =
            SubscriptionListResponseFutureUpdateScheduleStatus.PendingPayment;
        ApiEnum<
            string,
            SubscriptionListResponseFutureUpdateSubscriptionScheduleType
        > expectedSubscriptionScheduleType =
            SubscriptionListResponseFutureUpdateSubscriptionScheduleType.Downgrade;
        SubscriptionListResponseFutureUpdateTargetPackage expectedTargetPackage = new("id");

        Assert.Equal(expectedScheduledExecutionTime, model.ScheduledExecutionTime);
        Assert.Equal(expectedScheduleStatus, model.ScheduleStatus);
        Assert.Equal(expectedSubscriptionScheduleType, model.SubscriptionScheduleType);
        Assert.Equal(expectedTargetPackage, model.TargetPackage);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionListResponseFutureUpdate
        {
            ScheduledExecutionTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ScheduleStatus = SubscriptionListResponseFutureUpdateScheduleStatus.PendingPayment,
            SubscriptionScheduleType =
                SubscriptionListResponseFutureUpdateSubscriptionScheduleType.Downgrade,
            TargetPackage = new("id"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionListResponseFutureUpdate>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionListResponseFutureUpdate
        {
            ScheduledExecutionTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ScheduleStatus = SubscriptionListResponseFutureUpdateScheduleStatus.PendingPayment,
            SubscriptionScheduleType =
                SubscriptionListResponseFutureUpdateSubscriptionScheduleType.Downgrade,
            TargetPackage = new("id"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionListResponseFutureUpdate>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedScheduledExecutionTime = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        ApiEnum<string, SubscriptionListResponseFutureUpdateScheduleStatus> expectedScheduleStatus =
            SubscriptionListResponseFutureUpdateScheduleStatus.PendingPayment;
        ApiEnum<
            string,
            SubscriptionListResponseFutureUpdateSubscriptionScheduleType
        > expectedSubscriptionScheduleType =
            SubscriptionListResponseFutureUpdateSubscriptionScheduleType.Downgrade;
        SubscriptionListResponseFutureUpdateTargetPackage expectedTargetPackage = new("id");

        Assert.Equal(expectedScheduledExecutionTime, deserialized.ScheduledExecutionTime);
        Assert.Equal(expectedScheduleStatus, deserialized.ScheduleStatus);
        Assert.Equal(expectedSubscriptionScheduleType, deserialized.SubscriptionScheduleType);
        Assert.Equal(expectedTargetPackage, deserialized.TargetPackage);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionListResponseFutureUpdate
        {
            ScheduledExecutionTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ScheduleStatus = SubscriptionListResponseFutureUpdateScheduleStatus.PendingPayment,
            SubscriptionScheduleType =
                SubscriptionListResponseFutureUpdateSubscriptionScheduleType.Downgrade,
            TargetPackage = new("id"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubscriptionListResponseFutureUpdate
        {
            ScheduledExecutionTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ScheduleStatus = SubscriptionListResponseFutureUpdateScheduleStatus.PendingPayment,
            SubscriptionScheduleType =
                SubscriptionListResponseFutureUpdateSubscriptionScheduleType.Downgrade,
        };

        Assert.Null(model.TargetPackage);
        Assert.False(model.RawData.ContainsKey("targetPackage"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new SubscriptionListResponseFutureUpdate
        {
            ScheduledExecutionTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ScheduleStatus = SubscriptionListResponseFutureUpdateScheduleStatus.PendingPayment,
            SubscriptionScheduleType =
                SubscriptionListResponseFutureUpdateSubscriptionScheduleType.Downgrade,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SubscriptionListResponseFutureUpdate
        {
            ScheduledExecutionTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ScheduleStatus = SubscriptionListResponseFutureUpdateScheduleStatus.PendingPayment,
            SubscriptionScheduleType =
                SubscriptionListResponseFutureUpdateSubscriptionScheduleType.Downgrade,

            TargetPackage = null,
        };

        Assert.Null(model.TargetPackage);
        Assert.True(model.RawData.ContainsKey("targetPackage"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SubscriptionListResponseFutureUpdate
        {
            ScheduledExecutionTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ScheduleStatus = SubscriptionListResponseFutureUpdateScheduleStatus.PendingPayment,
            SubscriptionScheduleType =
                SubscriptionListResponseFutureUpdateSubscriptionScheduleType.Downgrade,

            TargetPackage = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionListResponseFutureUpdate
        {
            ScheduledExecutionTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ScheduleStatus = SubscriptionListResponseFutureUpdateScheduleStatus.PendingPayment,
            SubscriptionScheduleType =
                SubscriptionListResponseFutureUpdateSubscriptionScheduleType.Downgrade,
            TargetPackage = new("id"),
        };

        SubscriptionListResponseFutureUpdate copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionListResponseFutureUpdateScheduleStatusTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionListResponseFutureUpdateScheduleStatus.PendingPayment)]
    [InlineData(SubscriptionListResponseFutureUpdateScheduleStatus.Scheduled)]
    [InlineData(SubscriptionListResponseFutureUpdateScheduleStatus.Canceled)]
    [InlineData(SubscriptionListResponseFutureUpdateScheduleStatus.Done)]
    [InlineData(SubscriptionListResponseFutureUpdateScheduleStatus.Failed)]
    public void Validation_Works(SubscriptionListResponseFutureUpdateScheduleStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionListResponseFutureUpdateScheduleStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionListResponseFutureUpdateScheduleStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionListResponseFutureUpdateScheduleStatus.PendingPayment)]
    [InlineData(SubscriptionListResponseFutureUpdateScheduleStatus.Scheduled)]
    [InlineData(SubscriptionListResponseFutureUpdateScheduleStatus.Canceled)]
    [InlineData(SubscriptionListResponseFutureUpdateScheduleStatus.Done)]
    [InlineData(SubscriptionListResponseFutureUpdateScheduleStatus.Failed)]
    public void SerializationRoundtrip_Works(
        SubscriptionListResponseFutureUpdateScheduleStatus rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionListResponseFutureUpdateScheduleStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionListResponseFutureUpdateScheduleStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionListResponseFutureUpdateScheduleStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionListResponseFutureUpdateScheduleStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionListResponseFutureUpdateSubscriptionScheduleTypeTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionListResponseFutureUpdateSubscriptionScheduleType.Downgrade)]
    [InlineData(SubscriptionListResponseFutureUpdateSubscriptionScheduleType.Plan)]
    [InlineData(SubscriptionListResponseFutureUpdateSubscriptionScheduleType.BillingPeriod)]
    [InlineData(SubscriptionListResponseFutureUpdateSubscriptionScheduleType.UnitAmount)]
    [InlineData(SubscriptionListResponseFutureUpdateSubscriptionScheduleType.RecurringCredits)]
    [InlineData(SubscriptionListResponseFutureUpdateSubscriptionScheduleType.PriceOverride)]
    [InlineData(SubscriptionListResponseFutureUpdateSubscriptionScheduleType.Addon)]
    [InlineData(SubscriptionListResponseFutureUpdateSubscriptionScheduleType.Coupon)]
    [InlineData(SubscriptionListResponseFutureUpdateSubscriptionScheduleType.MigrateToLatest)]
    [InlineData(SubscriptionListResponseFutureUpdateSubscriptionScheduleType.AdditionalMetaData)]
    [InlineData(SubscriptionListResponseFutureUpdateSubscriptionScheduleType.BillingInfoMetadata)]
    public void Validation_Works(
        SubscriptionListResponseFutureUpdateSubscriptionScheduleType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionListResponseFutureUpdateSubscriptionScheduleType> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionListResponseFutureUpdateSubscriptionScheduleType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionListResponseFutureUpdateSubscriptionScheduleType.Downgrade)]
    [InlineData(SubscriptionListResponseFutureUpdateSubscriptionScheduleType.Plan)]
    [InlineData(SubscriptionListResponseFutureUpdateSubscriptionScheduleType.BillingPeriod)]
    [InlineData(SubscriptionListResponseFutureUpdateSubscriptionScheduleType.UnitAmount)]
    [InlineData(SubscriptionListResponseFutureUpdateSubscriptionScheduleType.RecurringCredits)]
    [InlineData(SubscriptionListResponseFutureUpdateSubscriptionScheduleType.PriceOverride)]
    [InlineData(SubscriptionListResponseFutureUpdateSubscriptionScheduleType.Addon)]
    [InlineData(SubscriptionListResponseFutureUpdateSubscriptionScheduleType.Coupon)]
    [InlineData(SubscriptionListResponseFutureUpdateSubscriptionScheduleType.MigrateToLatest)]
    [InlineData(SubscriptionListResponseFutureUpdateSubscriptionScheduleType.AdditionalMetaData)]
    [InlineData(SubscriptionListResponseFutureUpdateSubscriptionScheduleType.BillingInfoMetadata)]
    public void SerializationRoundtrip_Works(
        SubscriptionListResponseFutureUpdateSubscriptionScheduleType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionListResponseFutureUpdateSubscriptionScheduleType> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionListResponseFutureUpdateSubscriptionScheduleType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionListResponseFutureUpdateSubscriptionScheduleType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionListResponseFutureUpdateSubscriptionScheduleType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionListResponseFutureUpdateTargetPackageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionListResponseFutureUpdateTargetPackage { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, model.ID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionListResponseFutureUpdateTargetPackage { ID = "id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionListResponseFutureUpdateTargetPackage>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionListResponseFutureUpdateTargetPackage { ID = "id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionListResponseFutureUpdateTargetPackage>(
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
        var model = new SubscriptionListResponseFutureUpdateTargetPackage { ID = "id" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionListResponseFutureUpdateTargetPackage { ID = "id" };

        SubscriptionListResponseFutureUpdateTargetPackage copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionListResponseLatestInvoiceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionListResponseLatestInvoice
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = SubscriptionListResponseLatestInvoiceStatus.Open,
            AmountDue = 0,
            BillingReason = SubscriptionListResponseLatestInvoiceBillingReason.BillingCycle,
            Currency = "currency",
            PdfUrl = "pdfUrl",
            Total = 0,
        };

        string expectedBillingID = "billingId";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedRequiresAction = true;
        ApiEnum<string, SubscriptionListResponseLatestInvoiceStatus> expectedStatus =
            SubscriptionListResponseLatestInvoiceStatus.Open;
        double expectedAmountDue = 0;
        ApiEnum<string, SubscriptionListResponseLatestInvoiceBillingReason> expectedBillingReason =
            SubscriptionListResponseLatestInvoiceBillingReason.BillingCycle;
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
        var model = new SubscriptionListResponseLatestInvoice
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = SubscriptionListResponseLatestInvoiceStatus.Open,
            AmountDue = 0,
            BillingReason = SubscriptionListResponseLatestInvoiceBillingReason.BillingCycle,
            Currency = "currency",
            PdfUrl = "pdfUrl",
            Total = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionListResponseLatestInvoice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionListResponseLatestInvoice
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = SubscriptionListResponseLatestInvoiceStatus.Open,
            AmountDue = 0,
            BillingReason = SubscriptionListResponseLatestInvoiceBillingReason.BillingCycle,
            Currency = "currency",
            PdfUrl = "pdfUrl",
            Total = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionListResponseLatestInvoice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBillingID = "billingId";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedRequiresAction = true;
        ApiEnum<string, SubscriptionListResponseLatestInvoiceStatus> expectedStatus =
            SubscriptionListResponseLatestInvoiceStatus.Open;
        double expectedAmountDue = 0;
        ApiEnum<string, SubscriptionListResponseLatestInvoiceBillingReason> expectedBillingReason =
            SubscriptionListResponseLatestInvoiceBillingReason.BillingCycle;
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
        var model = new SubscriptionListResponseLatestInvoice
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = SubscriptionListResponseLatestInvoiceStatus.Open,
            AmountDue = 0,
            BillingReason = SubscriptionListResponseLatestInvoiceBillingReason.BillingCycle,
            Currency = "currency",
            PdfUrl = "pdfUrl",
            Total = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubscriptionListResponseLatestInvoice
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = SubscriptionListResponseLatestInvoiceStatus.Open,
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
        var model = new SubscriptionListResponseLatestInvoice
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = SubscriptionListResponseLatestInvoiceStatus.Open,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SubscriptionListResponseLatestInvoice
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = SubscriptionListResponseLatestInvoiceStatus.Open,

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
        var model = new SubscriptionListResponseLatestInvoice
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = SubscriptionListResponseLatestInvoiceStatus.Open,

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
        var model = new SubscriptionListResponseLatestInvoice
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = SubscriptionListResponseLatestInvoiceStatus.Open,
            AmountDue = 0,
            BillingReason = SubscriptionListResponseLatestInvoiceBillingReason.BillingCycle,
            Currency = "currency",
            PdfUrl = "pdfUrl",
            Total = 0,
        };

        SubscriptionListResponseLatestInvoice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionListResponseLatestInvoiceStatusTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionListResponseLatestInvoiceStatus.Open)]
    [InlineData(SubscriptionListResponseLatestInvoiceStatus.Canceled)]
    [InlineData(SubscriptionListResponseLatestInvoiceStatus.Paid)]
    public void Validation_Works(SubscriptionListResponseLatestInvoiceStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionListResponseLatestInvoiceStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionListResponseLatestInvoiceStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionListResponseLatestInvoiceStatus.Open)]
    [InlineData(SubscriptionListResponseLatestInvoiceStatus.Canceled)]
    [InlineData(SubscriptionListResponseLatestInvoiceStatus.Paid)]
    public void SerializationRoundtrip_Works(SubscriptionListResponseLatestInvoiceStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionListResponseLatestInvoiceStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionListResponseLatestInvoiceStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionListResponseLatestInvoiceStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionListResponseLatestInvoiceStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionListResponseLatestInvoiceBillingReasonTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionListResponseLatestInvoiceBillingReason.BillingCycle)]
    [InlineData(SubscriptionListResponseLatestInvoiceBillingReason.SubscriptionCreation)]
    [InlineData(SubscriptionListResponseLatestInvoiceBillingReason.SubscriptionUpdate)]
    [InlineData(SubscriptionListResponseLatestInvoiceBillingReason.Manual)]
    [InlineData(SubscriptionListResponseLatestInvoiceBillingReason.MinimumInvoiceAmountExceeded)]
    [InlineData(SubscriptionListResponseLatestInvoiceBillingReason.Other)]
    public void Validation_Works(SubscriptionListResponseLatestInvoiceBillingReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionListResponseLatestInvoiceBillingReason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionListResponseLatestInvoiceBillingReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionListResponseLatestInvoiceBillingReason.BillingCycle)]
    [InlineData(SubscriptionListResponseLatestInvoiceBillingReason.SubscriptionCreation)]
    [InlineData(SubscriptionListResponseLatestInvoiceBillingReason.SubscriptionUpdate)]
    [InlineData(SubscriptionListResponseLatestInvoiceBillingReason.Manual)]
    [InlineData(SubscriptionListResponseLatestInvoiceBillingReason.MinimumInvoiceAmountExceeded)]
    [InlineData(SubscriptionListResponseLatestInvoiceBillingReason.Other)]
    public void SerializationRoundtrip_Works(
        SubscriptionListResponseLatestInvoiceBillingReason rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionListResponseLatestInvoiceBillingReason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionListResponseLatestInvoiceBillingReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionListResponseLatestInvoiceBillingReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionListResponseLatestInvoiceBillingReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionListResponseMinimumSpendTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionListResponseMinimumSpend
        {
            Amount = 0,
            Currency = SubscriptionListResponseMinimumSpendCurrency.Usd,
        };

        double expectedAmount = 0;
        ApiEnum<string, SubscriptionListResponseMinimumSpendCurrency> expectedCurrency =
            SubscriptionListResponseMinimumSpendCurrency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionListResponseMinimumSpend
        {
            Amount = 0,
            Currency = SubscriptionListResponseMinimumSpendCurrency.Usd,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionListResponseMinimumSpend>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionListResponseMinimumSpend
        {
            Amount = 0,
            Currency = SubscriptionListResponseMinimumSpendCurrency.Usd,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionListResponseMinimumSpend>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        ApiEnum<string, SubscriptionListResponseMinimumSpendCurrency> expectedCurrency =
            SubscriptionListResponseMinimumSpendCurrency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionListResponseMinimumSpend
        {
            Amount = 0,
            Currency = SubscriptionListResponseMinimumSpendCurrency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubscriptionListResponseMinimumSpend { };

        Assert.Null(model.Amount);
        Assert.False(model.RawData.ContainsKey("amount"));
        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SubscriptionListResponseMinimumSpend { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SubscriptionListResponseMinimumSpend
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
        var model = new SubscriptionListResponseMinimumSpend
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
        var model = new SubscriptionListResponseMinimumSpend
        {
            Amount = 0,
            Currency = SubscriptionListResponseMinimumSpendCurrency.Usd,
        };

        SubscriptionListResponseMinimumSpend copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionListResponseMinimumSpendCurrencyTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Usd)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Aed)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.All)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Amd)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Ang)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Aud)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Awg)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Azn)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Bam)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Bbd)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Bdt)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Bgn)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Bif)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Bmd)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Bnd)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Bsd)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Bwp)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Byn)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Bzd)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Brl)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Cad)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Cdf)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Chf)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Cny)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Czk)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Dkk)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Dop)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Dzd)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Egp)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Etb)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Eur)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Fjd)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Gbp)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Gel)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Gip)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Gmd)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Gyd)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Hkd)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Hrk)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Htg)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Idr)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Ils)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Inr)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Isk)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Jmd)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Jpy)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Kes)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Kgs)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Khr)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Kmf)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Krw)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Kyd)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Kzt)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Lbp)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Lkr)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Lrd)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Lsl)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Mad)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Mdl)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Mga)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Mkd)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Mmk)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Mnt)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Mop)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Mro)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Mvr)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Mwk)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Mxn)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Myr)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Mzn)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Nad)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Ngn)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Nok)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Npr)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Nzd)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Pgk)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Php)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Pkr)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Pln)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Qar)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Ron)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Rsd)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Rub)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Rwf)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Sar)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Sbd)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Scr)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Sek)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Sgd)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Sle)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Sll)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Sos)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Szl)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Thb)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Tjs)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Top)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Try)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Ttd)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Tzs)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Uah)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Uzs)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Vnd)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Vuv)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Wst)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Xaf)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Xcd)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Yer)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Zar)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Zmw)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Clp)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Djf)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Gnf)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Ugx)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Pyg)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Xof)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Xpf)]
    public void Validation_Works(SubscriptionListResponseMinimumSpendCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionListResponseMinimumSpendCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionListResponseMinimumSpendCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Usd)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Aed)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.All)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Amd)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Ang)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Aud)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Awg)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Azn)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Bam)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Bbd)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Bdt)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Bgn)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Bif)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Bmd)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Bnd)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Bsd)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Bwp)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Byn)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Bzd)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Brl)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Cad)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Cdf)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Chf)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Cny)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Czk)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Dkk)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Dop)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Dzd)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Egp)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Etb)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Eur)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Fjd)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Gbp)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Gel)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Gip)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Gmd)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Gyd)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Hkd)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Hrk)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Htg)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Idr)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Ils)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Inr)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Isk)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Jmd)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Jpy)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Kes)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Kgs)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Khr)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Kmf)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Krw)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Kyd)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Kzt)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Lbp)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Lkr)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Lrd)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Lsl)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Mad)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Mdl)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Mga)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Mkd)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Mmk)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Mnt)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Mop)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Mro)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Mvr)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Mwk)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Mxn)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Myr)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Mzn)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Nad)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Ngn)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Nok)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Npr)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Nzd)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Pgk)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Php)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Pkr)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Pln)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Qar)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Ron)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Rsd)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Rub)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Rwf)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Sar)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Sbd)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Scr)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Sek)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Sgd)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Sle)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Sll)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Sos)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Szl)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Thb)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Tjs)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Top)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Try)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Ttd)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Tzs)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Uah)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Uzs)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Vnd)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Vuv)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Wst)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Xaf)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Xcd)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Yer)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Zar)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Zmw)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Clp)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Djf)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Gnf)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Ugx)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Pyg)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Xof)]
    [InlineData(SubscriptionListResponseMinimumSpendCurrency.Xpf)]
    public void SerializationRoundtrip_Works(SubscriptionListResponseMinimumSpendCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionListResponseMinimumSpendCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionListResponseMinimumSpendCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionListResponseMinimumSpendCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionListResponseMinimumSpendCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionListResponsePaymentCollectionMethodTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionListResponsePaymentCollectionMethod.Charge)]
    [InlineData(SubscriptionListResponsePaymentCollectionMethod.Invoice)]
    [InlineData(SubscriptionListResponsePaymentCollectionMethod.None)]
    public void Validation_Works(SubscriptionListResponsePaymentCollectionMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionListResponsePaymentCollectionMethod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionListResponsePaymentCollectionMethod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionListResponsePaymentCollectionMethod.Charge)]
    [InlineData(SubscriptionListResponsePaymentCollectionMethod.Invoice)]
    [InlineData(SubscriptionListResponsePaymentCollectionMethod.None)]
    public void SerializationRoundtrip_Works(
        SubscriptionListResponsePaymentCollectionMethod rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionListResponsePaymentCollectionMethod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionListResponsePaymentCollectionMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionListResponsePaymentCollectionMethod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionListResponsePaymentCollectionMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionListResponsePriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionListResponsePrice
        {
            AddonID = "addonId",
            Amount = 0,
            BaseCharge = true,
            BillingCountryCode = "billingCountryCode",
            BlockSize = 0,
            Currency = SubscriptionListResponsePriceCurrency.Usd,
            FeatureID = "featureId",
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        Currency = SubscriptionListResponsePriceTierFlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        Currency = SubscriptionListResponsePriceTierUnitPriceCurrency.Usd,
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
        ApiEnum<string, SubscriptionListResponsePriceCurrency> expectedCurrency =
            SubscriptionListResponsePriceCurrency.Usd;
        string expectedFeatureID = "featureId";
        List<SubscriptionListResponsePriceTier> expectedTiers =
        [
            new()
            {
                FlatPrice = new()
                {
                    Amount = 0,
                    Currency = SubscriptionListResponsePriceTierFlatPriceCurrency.Usd,
                },
                UnitPrice = new()
                {
                    Amount = 0,
                    Currency = SubscriptionListResponsePriceTierUnitPriceCurrency.Usd,
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
        var model = new SubscriptionListResponsePrice
        {
            AddonID = "addonId",
            Amount = 0,
            BaseCharge = true,
            BillingCountryCode = "billingCountryCode",
            BlockSize = 0,
            Currency = SubscriptionListResponsePriceCurrency.Usd,
            FeatureID = "featureId",
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        Currency = SubscriptionListResponsePriceTierFlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        Currency = SubscriptionListResponsePriceTierUnitPriceCurrency.Usd,
                    },
                    UpTo = 0,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionListResponsePrice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionListResponsePrice
        {
            AddonID = "addonId",
            Amount = 0,
            BaseCharge = true,
            BillingCountryCode = "billingCountryCode",
            BlockSize = 0,
            Currency = SubscriptionListResponsePriceCurrency.Usd,
            FeatureID = "featureId",
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        Currency = SubscriptionListResponsePriceTierFlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        Currency = SubscriptionListResponsePriceTierUnitPriceCurrency.Usd,
                    },
                    UpTo = 0,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionListResponsePrice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAddonID = "addonId";
        double expectedAmount = 0;
        bool expectedBaseCharge = true;
        string expectedBillingCountryCode = "billingCountryCode";
        double expectedBlockSize = 0;
        ApiEnum<string, SubscriptionListResponsePriceCurrency> expectedCurrency =
            SubscriptionListResponsePriceCurrency.Usd;
        string expectedFeatureID = "featureId";
        List<SubscriptionListResponsePriceTier> expectedTiers =
        [
            new()
            {
                FlatPrice = new()
                {
                    Amount = 0,
                    Currency = SubscriptionListResponsePriceTierFlatPriceCurrency.Usd,
                },
                UnitPrice = new()
                {
                    Amount = 0,
                    Currency = SubscriptionListResponsePriceTierUnitPriceCurrency.Usd,
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
        var model = new SubscriptionListResponsePrice
        {
            AddonID = "addonId",
            Amount = 0,
            BaseCharge = true,
            BillingCountryCode = "billingCountryCode",
            BlockSize = 0,
            Currency = SubscriptionListResponsePriceCurrency.Usd,
            FeatureID = "featureId",
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        Currency = SubscriptionListResponsePriceTierFlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        Currency = SubscriptionListResponsePriceTierUnitPriceCurrency.Usd,
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
        var model = new SubscriptionListResponsePrice
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
        var model = new SubscriptionListResponsePrice
        {
            AddonID = "addonId",
            FeatureID = "featureId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SubscriptionListResponsePrice
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
        var model = new SubscriptionListResponsePrice
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
        var model = new SubscriptionListResponsePrice
        {
            Amount = 0,
            BaseCharge = true,
            BillingCountryCode = "billingCountryCode",
            BlockSize = 0,
            Currency = SubscriptionListResponsePriceCurrency.Usd,
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        Currency = SubscriptionListResponsePriceTierFlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        Currency = SubscriptionListResponsePriceTierUnitPriceCurrency.Usd,
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
        var model = new SubscriptionListResponsePrice
        {
            Amount = 0,
            BaseCharge = true,
            BillingCountryCode = "billingCountryCode",
            BlockSize = 0,
            Currency = SubscriptionListResponsePriceCurrency.Usd,
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        Currency = SubscriptionListResponsePriceTierFlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        Currency = SubscriptionListResponsePriceTierUnitPriceCurrency.Usd,
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
        var model = new SubscriptionListResponsePrice
        {
            Amount = 0,
            BaseCharge = true,
            BillingCountryCode = "billingCountryCode",
            BlockSize = 0,
            Currency = SubscriptionListResponsePriceCurrency.Usd,
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        Currency = SubscriptionListResponsePriceTierFlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        Currency = SubscriptionListResponsePriceTierUnitPriceCurrency.Usd,
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
        var model = new SubscriptionListResponsePrice
        {
            Amount = 0,
            BaseCharge = true,
            BillingCountryCode = "billingCountryCode",
            BlockSize = 0,
            Currency = SubscriptionListResponsePriceCurrency.Usd,
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        Currency = SubscriptionListResponsePriceTierFlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        Currency = SubscriptionListResponsePriceTierUnitPriceCurrency.Usd,
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
        var model = new SubscriptionListResponsePrice
        {
            AddonID = "addonId",
            Amount = 0,
            BaseCharge = true,
            BillingCountryCode = "billingCountryCode",
            BlockSize = 0,
            Currency = SubscriptionListResponsePriceCurrency.Usd,
            FeatureID = "featureId",
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        Currency = SubscriptionListResponsePriceTierFlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        Currency = SubscriptionListResponsePriceTierUnitPriceCurrency.Usd,
                    },
                    UpTo = 0,
                },
            ],
        };

        SubscriptionListResponsePrice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionListResponsePriceCurrencyTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionListResponsePriceCurrency.Usd)]
    [InlineData(SubscriptionListResponsePriceCurrency.Aed)]
    [InlineData(SubscriptionListResponsePriceCurrency.All)]
    [InlineData(SubscriptionListResponsePriceCurrency.Amd)]
    [InlineData(SubscriptionListResponsePriceCurrency.Ang)]
    [InlineData(SubscriptionListResponsePriceCurrency.Aud)]
    [InlineData(SubscriptionListResponsePriceCurrency.Awg)]
    [InlineData(SubscriptionListResponsePriceCurrency.Azn)]
    [InlineData(SubscriptionListResponsePriceCurrency.Bam)]
    [InlineData(SubscriptionListResponsePriceCurrency.Bbd)]
    [InlineData(SubscriptionListResponsePriceCurrency.Bdt)]
    [InlineData(SubscriptionListResponsePriceCurrency.Bgn)]
    [InlineData(SubscriptionListResponsePriceCurrency.Bif)]
    [InlineData(SubscriptionListResponsePriceCurrency.Bmd)]
    [InlineData(SubscriptionListResponsePriceCurrency.Bnd)]
    [InlineData(SubscriptionListResponsePriceCurrency.Bsd)]
    [InlineData(SubscriptionListResponsePriceCurrency.Bwp)]
    [InlineData(SubscriptionListResponsePriceCurrency.Byn)]
    [InlineData(SubscriptionListResponsePriceCurrency.Bzd)]
    [InlineData(SubscriptionListResponsePriceCurrency.Brl)]
    [InlineData(SubscriptionListResponsePriceCurrency.Cad)]
    [InlineData(SubscriptionListResponsePriceCurrency.Cdf)]
    [InlineData(SubscriptionListResponsePriceCurrency.Chf)]
    [InlineData(SubscriptionListResponsePriceCurrency.Cny)]
    [InlineData(SubscriptionListResponsePriceCurrency.Czk)]
    [InlineData(SubscriptionListResponsePriceCurrency.Dkk)]
    [InlineData(SubscriptionListResponsePriceCurrency.Dop)]
    [InlineData(SubscriptionListResponsePriceCurrency.Dzd)]
    [InlineData(SubscriptionListResponsePriceCurrency.Egp)]
    [InlineData(SubscriptionListResponsePriceCurrency.Etb)]
    [InlineData(SubscriptionListResponsePriceCurrency.Eur)]
    [InlineData(SubscriptionListResponsePriceCurrency.Fjd)]
    [InlineData(SubscriptionListResponsePriceCurrency.Gbp)]
    [InlineData(SubscriptionListResponsePriceCurrency.Gel)]
    [InlineData(SubscriptionListResponsePriceCurrency.Gip)]
    [InlineData(SubscriptionListResponsePriceCurrency.Gmd)]
    [InlineData(SubscriptionListResponsePriceCurrency.Gyd)]
    [InlineData(SubscriptionListResponsePriceCurrency.Hkd)]
    [InlineData(SubscriptionListResponsePriceCurrency.Hrk)]
    [InlineData(SubscriptionListResponsePriceCurrency.Htg)]
    [InlineData(SubscriptionListResponsePriceCurrency.Idr)]
    [InlineData(SubscriptionListResponsePriceCurrency.Ils)]
    [InlineData(SubscriptionListResponsePriceCurrency.Inr)]
    [InlineData(SubscriptionListResponsePriceCurrency.Isk)]
    [InlineData(SubscriptionListResponsePriceCurrency.Jmd)]
    [InlineData(SubscriptionListResponsePriceCurrency.Jpy)]
    [InlineData(SubscriptionListResponsePriceCurrency.Kes)]
    [InlineData(SubscriptionListResponsePriceCurrency.Kgs)]
    [InlineData(SubscriptionListResponsePriceCurrency.Khr)]
    [InlineData(SubscriptionListResponsePriceCurrency.Kmf)]
    [InlineData(SubscriptionListResponsePriceCurrency.Krw)]
    [InlineData(SubscriptionListResponsePriceCurrency.Kyd)]
    [InlineData(SubscriptionListResponsePriceCurrency.Kzt)]
    [InlineData(SubscriptionListResponsePriceCurrency.Lbp)]
    [InlineData(SubscriptionListResponsePriceCurrency.Lkr)]
    [InlineData(SubscriptionListResponsePriceCurrency.Lrd)]
    [InlineData(SubscriptionListResponsePriceCurrency.Lsl)]
    [InlineData(SubscriptionListResponsePriceCurrency.Mad)]
    [InlineData(SubscriptionListResponsePriceCurrency.Mdl)]
    [InlineData(SubscriptionListResponsePriceCurrency.Mga)]
    [InlineData(SubscriptionListResponsePriceCurrency.Mkd)]
    [InlineData(SubscriptionListResponsePriceCurrency.Mmk)]
    [InlineData(SubscriptionListResponsePriceCurrency.Mnt)]
    [InlineData(SubscriptionListResponsePriceCurrency.Mop)]
    [InlineData(SubscriptionListResponsePriceCurrency.Mro)]
    [InlineData(SubscriptionListResponsePriceCurrency.Mvr)]
    [InlineData(SubscriptionListResponsePriceCurrency.Mwk)]
    [InlineData(SubscriptionListResponsePriceCurrency.Mxn)]
    [InlineData(SubscriptionListResponsePriceCurrency.Myr)]
    [InlineData(SubscriptionListResponsePriceCurrency.Mzn)]
    [InlineData(SubscriptionListResponsePriceCurrency.Nad)]
    [InlineData(SubscriptionListResponsePriceCurrency.Ngn)]
    [InlineData(SubscriptionListResponsePriceCurrency.Nok)]
    [InlineData(SubscriptionListResponsePriceCurrency.Npr)]
    [InlineData(SubscriptionListResponsePriceCurrency.Nzd)]
    [InlineData(SubscriptionListResponsePriceCurrency.Pgk)]
    [InlineData(SubscriptionListResponsePriceCurrency.Php)]
    [InlineData(SubscriptionListResponsePriceCurrency.Pkr)]
    [InlineData(SubscriptionListResponsePriceCurrency.Pln)]
    [InlineData(SubscriptionListResponsePriceCurrency.Qar)]
    [InlineData(SubscriptionListResponsePriceCurrency.Ron)]
    [InlineData(SubscriptionListResponsePriceCurrency.Rsd)]
    [InlineData(SubscriptionListResponsePriceCurrency.Rub)]
    [InlineData(SubscriptionListResponsePriceCurrency.Rwf)]
    [InlineData(SubscriptionListResponsePriceCurrency.Sar)]
    [InlineData(SubscriptionListResponsePriceCurrency.Sbd)]
    [InlineData(SubscriptionListResponsePriceCurrency.Scr)]
    [InlineData(SubscriptionListResponsePriceCurrency.Sek)]
    [InlineData(SubscriptionListResponsePriceCurrency.Sgd)]
    [InlineData(SubscriptionListResponsePriceCurrency.Sle)]
    [InlineData(SubscriptionListResponsePriceCurrency.Sll)]
    [InlineData(SubscriptionListResponsePriceCurrency.Sos)]
    [InlineData(SubscriptionListResponsePriceCurrency.Szl)]
    [InlineData(SubscriptionListResponsePriceCurrency.Thb)]
    [InlineData(SubscriptionListResponsePriceCurrency.Tjs)]
    [InlineData(SubscriptionListResponsePriceCurrency.Top)]
    [InlineData(SubscriptionListResponsePriceCurrency.Try)]
    [InlineData(SubscriptionListResponsePriceCurrency.Ttd)]
    [InlineData(SubscriptionListResponsePriceCurrency.Tzs)]
    [InlineData(SubscriptionListResponsePriceCurrency.Uah)]
    [InlineData(SubscriptionListResponsePriceCurrency.Uzs)]
    [InlineData(SubscriptionListResponsePriceCurrency.Vnd)]
    [InlineData(SubscriptionListResponsePriceCurrency.Vuv)]
    [InlineData(SubscriptionListResponsePriceCurrency.Wst)]
    [InlineData(SubscriptionListResponsePriceCurrency.Xaf)]
    [InlineData(SubscriptionListResponsePriceCurrency.Xcd)]
    [InlineData(SubscriptionListResponsePriceCurrency.Yer)]
    [InlineData(SubscriptionListResponsePriceCurrency.Zar)]
    [InlineData(SubscriptionListResponsePriceCurrency.Zmw)]
    [InlineData(SubscriptionListResponsePriceCurrency.Clp)]
    [InlineData(SubscriptionListResponsePriceCurrency.Djf)]
    [InlineData(SubscriptionListResponsePriceCurrency.Gnf)]
    [InlineData(SubscriptionListResponsePriceCurrency.Ugx)]
    [InlineData(SubscriptionListResponsePriceCurrency.Pyg)]
    [InlineData(SubscriptionListResponsePriceCurrency.Xof)]
    [InlineData(SubscriptionListResponsePriceCurrency.Xpf)]
    public void Validation_Works(SubscriptionListResponsePriceCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionListResponsePriceCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionListResponsePriceCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionListResponsePriceCurrency.Usd)]
    [InlineData(SubscriptionListResponsePriceCurrency.Aed)]
    [InlineData(SubscriptionListResponsePriceCurrency.All)]
    [InlineData(SubscriptionListResponsePriceCurrency.Amd)]
    [InlineData(SubscriptionListResponsePriceCurrency.Ang)]
    [InlineData(SubscriptionListResponsePriceCurrency.Aud)]
    [InlineData(SubscriptionListResponsePriceCurrency.Awg)]
    [InlineData(SubscriptionListResponsePriceCurrency.Azn)]
    [InlineData(SubscriptionListResponsePriceCurrency.Bam)]
    [InlineData(SubscriptionListResponsePriceCurrency.Bbd)]
    [InlineData(SubscriptionListResponsePriceCurrency.Bdt)]
    [InlineData(SubscriptionListResponsePriceCurrency.Bgn)]
    [InlineData(SubscriptionListResponsePriceCurrency.Bif)]
    [InlineData(SubscriptionListResponsePriceCurrency.Bmd)]
    [InlineData(SubscriptionListResponsePriceCurrency.Bnd)]
    [InlineData(SubscriptionListResponsePriceCurrency.Bsd)]
    [InlineData(SubscriptionListResponsePriceCurrency.Bwp)]
    [InlineData(SubscriptionListResponsePriceCurrency.Byn)]
    [InlineData(SubscriptionListResponsePriceCurrency.Bzd)]
    [InlineData(SubscriptionListResponsePriceCurrency.Brl)]
    [InlineData(SubscriptionListResponsePriceCurrency.Cad)]
    [InlineData(SubscriptionListResponsePriceCurrency.Cdf)]
    [InlineData(SubscriptionListResponsePriceCurrency.Chf)]
    [InlineData(SubscriptionListResponsePriceCurrency.Cny)]
    [InlineData(SubscriptionListResponsePriceCurrency.Czk)]
    [InlineData(SubscriptionListResponsePriceCurrency.Dkk)]
    [InlineData(SubscriptionListResponsePriceCurrency.Dop)]
    [InlineData(SubscriptionListResponsePriceCurrency.Dzd)]
    [InlineData(SubscriptionListResponsePriceCurrency.Egp)]
    [InlineData(SubscriptionListResponsePriceCurrency.Etb)]
    [InlineData(SubscriptionListResponsePriceCurrency.Eur)]
    [InlineData(SubscriptionListResponsePriceCurrency.Fjd)]
    [InlineData(SubscriptionListResponsePriceCurrency.Gbp)]
    [InlineData(SubscriptionListResponsePriceCurrency.Gel)]
    [InlineData(SubscriptionListResponsePriceCurrency.Gip)]
    [InlineData(SubscriptionListResponsePriceCurrency.Gmd)]
    [InlineData(SubscriptionListResponsePriceCurrency.Gyd)]
    [InlineData(SubscriptionListResponsePriceCurrency.Hkd)]
    [InlineData(SubscriptionListResponsePriceCurrency.Hrk)]
    [InlineData(SubscriptionListResponsePriceCurrency.Htg)]
    [InlineData(SubscriptionListResponsePriceCurrency.Idr)]
    [InlineData(SubscriptionListResponsePriceCurrency.Ils)]
    [InlineData(SubscriptionListResponsePriceCurrency.Inr)]
    [InlineData(SubscriptionListResponsePriceCurrency.Isk)]
    [InlineData(SubscriptionListResponsePriceCurrency.Jmd)]
    [InlineData(SubscriptionListResponsePriceCurrency.Jpy)]
    [InlineData(SubscriptionListResponsePriceCurrency.Kes)]
    [InlineData(SubscriptionListResponsePriceCurrency.Kgs)]
    [InlineData(SubscriptionListResponsePriceCurrency.Khr)]
    [InlineData(SubscriptionListResponsePriceCurrency.Kmf)]
    [InlineData(SubscriptionListResponsePriceCurrency.Krw)]
    [InlineData(SubscriptionListResponsePriceCurrency.Kyd)]
    [InlineData(SubscriptionListResponsePriceCurrency.Kzt)]
    [InlineData(SubscriptionListResponsePriceCurrency.Lbp)]
    [InlineData(SubscriptionListResponsePriceCurrency.Lkr)]
    [InlineData(SubscriptionListResponsePriceCurrency.Lrd)]
    [InlineData(SubscriptionListResponsePriceCurrency.Lsl)]
    [InlineData(SubscriptionListResponsePriceCurrency.Mad)]
    [InlineData(SubscriptionListResponsePriceCurrency.Mdl)]
    [InlineData(SubscriptionListResponsePriceCurrency.Mga)]
    [InlineData(SubscriptionListResponsePriceCurrency.Mkd)]
    [InlineData(SubscriptionListResponsePriceCurrency.Mmk)]
    [InlineData(SubscriptionListResponsePriceCurrency.Mnt)]
    [InlineData(SubscriptionListResponsePriceCurrency.Mop)]
    [InlineData(SubscriptionListResponsePriceCurrency.Mro)]
    [InlineData(SubscriptionListResponsePriceCurrency.Mvr)]
    [InlineData(SubscriptionListResponsePriceCurrency.Mwk)]
    [InlineData(SubscriptionListResponsePriceCurrency.Mxn)]
    [InlineData(SubscriptionListResponsePriceCurrency.Myr)]
    [InlineData(SubscriptionListResponsePriceCurrency.Mzn)]
    [InlineData(SubscriptionListResponsePriceCurrency.Nad)]
    [InlineData(SubscriptionListResponsePriceCurrency.Ngn)]
    [InlineData(SubscriptionListResponsePriceCurrency.Nok)]
    [InlineData(SubscriptionListResponsePriceCurrency.Npr)]
    [InlineData(SubscriptionListResponsePriceCurrency.Nzd)]
    [InlineData(SubscriptionListResponsePriceCurrency.Pgk)]
    [InlineData(SubscriptionListResponsePriceCurrency.Php)]
    [InlineData(SubscriptionListResponsePriceCurrency.Pkr)]
    [InlineData(SubscriptionListResponsePriceCurrency.Pln)]
    [InlineData(SubscriptionListResponsePriceCurrency.Qar)]
    [InlineData(SubscriptionListResponsePriceCurrency.Ron)]
    [InlineData(SubscriptionListResponsePriceCurrency.Rsd)]
    [InlineData(SubscriptionListResponsePriceCurrency.Rub)]
    [InlineData(SubscriptionListResponsePriceCurrency.Rwf)]
    [InlineData(SubscriptionListResponsePriceCurrency.Sar)]
    [InlineData(SubscriptionListResponsePriceCurrency.Sbd)]
    [InlineData(SubscriptionListResponsePriceCurrency.Scr)]
    [InlineData(SubscriptionListResponsePriceCurrency.Sek)]
    [InlineData(SubscriptionListResponsePriceCurrency.Sgd)]
    [InlineData(SubscriptionListResponsePriceCurrency.Sle)]
    [InlineData(SubscriptionListResponsePriceCurrency.Sll)]
    [InlineData(SubscriptionListResponsePriceCurrency.Sos)]
    [InlineData(SubscriptionListResponsePriceCurrency.Szl)]
    [InlineData(SubscriptionListResponsePriceCurrency.Thb)]
    [InlineData(SubscriptionListResponsePriceCurrency.Tjs)]
    [InlineData(SubscriptionListResponsePriceCurrency.Top)]
    [InlineData(SubscriptionListResponsePriceCurrency.Try)]
    [InlineData(SubscriptionListResponsePriceCurrency.Ttd)]
    [InlineData(SubscriptionListResponsePriceCurrency.Tzs)]
    [InlineData(SubscriptionListResponsePriceCurrency.Uah)]
    [InlineData(SubscriptionListResponsePriceCurrency.Uzs)]
    [InlineData(SubscriptionListResponsePriceCurrency.Vnd)]
    [InlineData(SubscriptionListResponsePriceCurrency.Vuv)]
    [InlineData(SubscriptionListResponsePriceCurrency.Wst)]
    [InlineData(SubscriptionListResponsePriceCurrency.Xaf)]
    [InlineData(SubscriptionListResponsePriceCurrency.Xcd)]
    [InlineData(SubscriptionListResponsePriceCurrency.Yer)]
    [InlineData(SubscriptionListResponsePriceCurrency.Zar)]
    [InlineData(SubscriptionListResponsePriceCurrency.Zmw)]
    [InlineData(SubscriptionListResponsePriceCurrency.Clp)]
    [InlineData(SubscriptionListResponsePriceCurrency.Djf)]
    [InlineData(SubscriptionListResponsePriceCurrency.Gnf)]
    [InlineData(SubscriptionListResponsePriceCurrency.Ugx)]
    [InlineData(SubscriptionListResponsePriceCurrency.Pyg)]
    [InlineData(SubscriptionListResponsePriceCurrency.Xof)]
    [InlineData(SubscriptionListResponsePriceCurrency.Xpf)]
    public void SerializationRoundtrip_Works(SubscriptionListResponsePriceCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionListResponsePriceCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionListResponsePriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionListResponsePriceCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionListResponsePriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionListResponsePriceTierTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionListResponsePriceTier
        {
            FlatPrice = new()
            {
                Amount = 0,
                Currency = SubscriptionListResponsePriceTierFlatPriceCurrency.Usd,
            },
            UnitPrice = new()
            {
                Amount = 0,
                Currency = SubscriptionListResponsePriceTierUnitPriceCurrency.Usd,
            },
            UpTo = 0,
        };

        SubscriptionListResponsePriceTierFlatPrice expectedFlatPrice = new()
        {
            Amount = 0,
            Currency = SubscriptionListResponsePriceTierFlatPriceCurrency.Usd,
        };
        SubscriptionListResponsePriceTierUnitPrice expectedUnitPrice = new()
        {
            Amount = 0,
            Currency = SubscriptionListResponsePriceTierUnitPriceCurrency.Usd,
        };
        double expectedUpTo = 0;

        Assert.Equal(expectedFlatPrice, model.FlatPrice);
        Assert.Equal(expectedUnitPrice, model.UnitPrice);
        Assert.Equal(expectedUpTo, model.UpTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionListResponsePriceTier
        {
            FlatPrice = new()
            {
                Amount = 0,
                Currency = SubscriptionListResponsePriceTierFlatPriceCurrency.Usd,
            },
            UnitPrice = new()
            {
                Amount = 0,
                Currency = SubscriptionListResponsePriceTierUnitPriceCurrency.Usd,
            },
            UpTo = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionListResponsePriceTier>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionListResponsePriceTier
        {
            FlatPrice = new()
            {
                Amount = 0,
                Currency = SubscriptionListResponsePriceTierFlatPriceCurrency.Usd,
            },
            UnitPrice = new()
            {
                Amount = 0,
                Currency = SubscriptionListResponsePriceTierUnitPriceCurrency.Usd,
            },
            UpTo = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionListResponsePriceTier>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        SubscriptionListResponsePriceTierFlatPrice expectedFlatPrice = new()
        {
            Amount = 0,
            Currency = SubscriptionListResponsePriceTierFlatPriceCurrency.Usd,
        };
        SubscriptionListResponsePriceTierUnitPrice expectedUnitPrice = new()
        {
            Amount = 0,
            Currency = SubscriptionListResponsePriceTierUnitPriceCurrency.Usd,
        };
        double expectedUpTo = 0;

        Assert.Equal(expectedFlatPrice, deserialized.FlatPrice);
        Assert.Equal(expectedUnitPrice, deserialized.UnitPrice);
        Assert.Equal(expectedUpTo, deserialized.UpTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionListResponsePriceTier
        {
            FlatPrice = new()
            {
                Amount = 0,
                Currency = SubscriptionListResponsePriceTierFlatPriceCurrency.Usd,
            },
            UnitPrice = new()
            {
                Amount = 0,
                Currency = SubscriptionListResponsePriceTierUnitPriceCurrency.Usd,
            },
            UpTo = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubscriptionListResponsePriceTier { };

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
        var model = new SubscriptionListResponsePriceTier { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SubscriptionListResponsePriceTier
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
        var model = new SubscriptionListResponsePriceTier
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
        var model = new SubscriptionListResponsePriceTier
        {
            FlatPrice = new()
            {
                Amount = 0,
                Currency = SubscriptionListResponsePriceTierFlatPriceCurrency.Usd,
            },
            UnitPrice = new()
            {
                Amount = 0,
                Currency = SubscriptionListResponsePriceTierUnitPriceCurrency.Usd,
            },
            UpTo = 0,
        };

        SubscriptionListResponsePriceTier copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionListResponsePriceTierFlatPriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionListResponsePriceTierFlatPrice
        {
            Amount = 0,
            Currency = SubscriptionListResponsePriceTierFlatPriceCurrency.Usd,
        };

        double expectedAmount = 0;
        ApiEnum<string, SubscriptionListResponsePriceTierFlatPriceCurrency> expectedCurrency =
            SubscriptionListResponsePriceTierFlatPriceCurrency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionListResponsePriceTierFlatPrice
        {
            Amount = 0,
            Currency = SubscriptionListResponsePriceTierFlatPriceCurrency.Usd,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionListResponsePriceTierFlatPrice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionListResponsePriceTierFlatPrice
        {
            Amount = 0,
            Currency = SubscriptionListResponsePriceTierFlatPriceCurrency.Usd,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionListResponsePriceTierFlatPrice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        ApiEnum<string, SubscriptionListResponsePriceTierFlatPriceCurrency> expectedCurrency =
            SubscriptionListResponsePriceTierFlatPriceCurrency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionListResponsePriceTierFlatPrice
        {
            Amount = 0,
            Currency = SubscriptionListResponsePriceTierFlatPriceCurrency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionListResponsePriceTierFlatPrice
        {
            Amount = 0,
            Currency = SubscriptionListResponsePriceTierFlatPriceCurrency.Usd,
        };

        SubscriptionListResponsePriceTierFlatPrice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionListResponsePriceTierFlatPriceCurrencyTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Usd)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Aed)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.All)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Amd)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Ang)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Aud)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Awg)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Azn)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Bam)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Bbd)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Bdt)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Bgn)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Bif)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Bmd)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Bnd)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Bsd)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Bwp)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Byn)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Bzd)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Brl)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Cad)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Cdf)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Chf)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Cny)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Czk)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Dkk)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Dop)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Dzd)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Egp)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Etb)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Eur)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Fjd)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Gbp)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Gel)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Gip)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Gmd)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Gyd)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Hkd)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Hrk)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Htg)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Idr)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Ils)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Inr)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Isk)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Jmd)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Jpy)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Kes)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Kgs)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Khr)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Kmf)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Krw)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Kyd)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Kzt)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Lbp)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Lkr)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Lrd)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Lsl)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Mad)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Mdl)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Mga)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Mkd)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Mmk)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Mnt)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Mop)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Mro)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Mvr)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Mwk)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Mxn)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Myr)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Mzn)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Nad)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Ngn)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Nok)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Npr)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Nzd)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Pgk)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Php)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Pkr)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Pln)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Qar)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Ron)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Rsd)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Rub)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Rwf)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Sar)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Sbd)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Scr)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Sek)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Sgd)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Sle)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Sll)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Sos)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Szl)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Thb)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Tjs)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Top)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Try)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Ttd)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Tzs)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Uah)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Uzs)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Vnd)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Vuv)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Wst)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Xaf)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Xcd)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Yer)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Zar)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Zmw)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Clp)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Djf)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Gnf)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Ugx)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Pyg)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Xof)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Xpf)]
    public void Validation_Works(SubscriptionListResponsePriceTierFlatPriceCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionListResponsePriceTierFlatPriceCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionListResponsePriceTierFlatPriceCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Usd)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Aed)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.All)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Amd)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Ang)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Aud)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Awg)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Azn)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Bam)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Bbd)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Bdt)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Bgn)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Bif)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Bmd)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Bnd)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Bsd)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Bwp)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Byn)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Bzd)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Brl)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Cad)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Cdf)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Chf)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Cny)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Czk)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Dkk)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Dop)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Dzd)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Egp)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Etb)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Eur)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Fjd)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Gbp)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Gel)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Gip)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Gmd)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Gyd)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Hkd)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Hrk)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Htg)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Idr)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Ils)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Inr)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Isk)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Jmd)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Jpy)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Kes)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Kgs)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Khr)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Kmf)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Krw)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Kyd)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Kzt)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Lbp)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Lkr)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Lrd)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Lsl)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Mad)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Mdl)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Mga)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Mkd)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Mmk)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Mnt)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Mop)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Mro)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Mvr)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Mwk)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Mxn)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Myr)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Mzn)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Nad)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Ngn)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Nok)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Npr)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Nzd)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Pgk)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Php)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Pkr)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Pln)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Qar)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Ron)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Rsd)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Rub)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Rwf)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Sar)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Sbd)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Scr)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Sek)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Sgd)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Sle)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Sll)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Sos)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Szl)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Thb)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Tjs)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Top)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Try)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Ttd)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Tzs)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Uah)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Uzs)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Vnd)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Vuv)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Wst)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Xaf)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Xcd)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Yer)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Zar)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Zmw)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Clp)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Djf)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Gnf)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Ugx)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Pyg)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Xof)]
    [InlineData(SubscriptionListResponsePriceTierFlatPriceCurrency.Xpf)]
    public void SerializationRoundtrip_Works(
        SubscriptionListResponsePriceTierFlatPriceCurrency rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionListResponsePriceTierFlatPriceCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionListResponsePriceTierFlatPriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionListResponsePriceTierFlatPriceCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionListResponsePriceTierFlatPriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionListResponsePriceTierUnitPriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionListResponsePriceTierUnitPrice
        {
            Amount = 0,
            Currency = SubscriptionListResponsePriceTierUnitPriceCurrency.Usd,
        };

        double expectedAmount = 0;
        ApiEnum<string, SubscriptionListResponsePriceTierUnitPriceCurrency> expectedCurrency =
            SubscriptionListResponsePriceTierUnitPriceCurrency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionListResponsePriceTierUnitPrice
        {
            Amount = 0,
            Currency = SubscriptionListResponsePriceTierUnitPriceCurrency.Usd,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionListResponsePriceTierUnitPrice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionListResponsePriceTierUnitPrice
        {
            Amount = 0,
            Currency = SubscriptionListResponsePriceTierUnitPriceCurrency.Usd,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionListResponsePriceTierUnitPrice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        ApiEnum<string, SubscriptionListResponsePriceTierUnitPriceCurrency> expectedCurrency =
            SubscriptionListResponsePriceTierUnitPriceCurrency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionListResponsePriceTierUnitPrice
        {
            Amount = 0,
            Currency = SubscriptionListResponsePriceTierUnitPriceCurrency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionListResponsePriceTierUnitPrice
        {
            Amount = 0,
            Currency = SubscriptionListResponsePriceTierUnitPriceCurrency.Usd,
        };

        SubscriptionListResponsePriceTierUnitPrice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionListResponsePriceTierUnitPriceCurrencyTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Usd)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Aed)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.All)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Amd)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Ang)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Aud)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Awg)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Azn)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Bam)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Bbd)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Bdt)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Bgn)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Bif)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Bmd)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Bnd)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Bsd)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Bwp)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Byn)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Bzd)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Brl)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Cad)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Cdf)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Chf)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Cny)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Czk)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Dkk)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Dop)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Dzd)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Egp)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Etb)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Eur)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Fjd)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Gbp)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Gel)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Gip)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Gmd)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Gyd)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Hkd)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Hrk)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Htg)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Idr)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Ils)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Inr)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Isk)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Jmd)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Jpy)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Kes)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Kgs)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Khr)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Kmf)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Krw)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Kyd)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Kzt)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Lbp)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Lkr)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Lrd)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Lsl)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Mad)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Mdl)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Mga)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Mkd)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Mmk)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Mnt)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Mop)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Mro)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Mvr)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Mwk)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Mxn)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Myr)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Mzn)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Nad)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Ngn)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Nok)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Npr)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Nzd)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Pgk)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Php)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Pkr)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Pln)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Qar)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Ron)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Rsd)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Rub)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Rwf)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Sar)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Sbd)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Scr)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Sek)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Sgd)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Sle)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Sll)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Sos)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Szl)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Thb)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Tjs)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Top)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Try)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Ttd)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Tzs)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Uah)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Uzs)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Vnd)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Vuv)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Wst)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Xaf)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Xcd)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Yer)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Zar)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Zmw)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Clp)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Djf)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Gnf)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Ugx)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Pyg)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Xof)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Xpf)]
    public void Validation_Works(SubscriptionListResponsePriceTierUnitPriceCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionListResponsePriceTierUnitPriceCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionListResponsePriceTierUnitPriceCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Usd)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Aed)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.All)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Amd)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Ang)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Aud)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Awg)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Azn)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Bam)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Bbd)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Bdt)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Bgn)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Bif)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Bmd)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Bnd)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Bsd)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Bwp)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Byn)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Bzd)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Brl)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Cad)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Cdf)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Chf)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Cny)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Czk)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Dkk)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Dop)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Dzd)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Egp)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Etb)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Eur)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Fjd)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Gbp)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Gel)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Gip)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Gmd)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Gyd)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Hkd)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Hrk)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Htg)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Idr)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Ils)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Inr)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Isk)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Jmd)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Jpy)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Kes)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Kgs)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Khr)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Kmf)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Krw)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Kyd)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Kzt)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Lbp)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Lkr)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Lrd)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Lsl)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Mad)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Mdl)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Mga)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Mkd)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Mmk)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Mnt)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Mop)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Mro)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Mvr)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Mwk)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Mxn)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Myr)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Mzn)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Nad)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Ngn)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Nok)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Npr)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Nzd)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Pgk)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Php)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Pkr)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Pln)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Qar)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Ron)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Rsd)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Rub)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Rwf)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Sar)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Sbd)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Scr)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Sek)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Sgd)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Sle)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Sll)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Sos)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Szl)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Thb)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Tjs)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Top)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Try)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Ttd)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Tzs)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Uah)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Uzs)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Vnd)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Vuv)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Wst)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Xaf)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Xcd)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Yer)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Zar)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Zmw)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Clp)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Djf)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Gnf)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Ugx)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Pyg)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Xof)]
    [InlineData(SubscriptionListResponsePriceTierUnitPriceCurrency.Xpf)]
    public void SerializationRoundtrip_Works(
        SubscriptionListResponsePriceTierUnitPriceCurrency rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionListResponsePriceTierUnitPriceCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionListResponsePriceTierUnitPriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionListResponsePriceTierUnitPriceCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionListResponsePriceTierUnitPriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionListResponseSubscriptionEntitlementTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionListResponseSubscriptionEntitlement
        {
            ID = "id",
            Type = SubscriptionListResponseSubscriptionEntitlementType.Feature,
        };

        string expectedID = "id";
        ApiEnum<string, SubscriptionListResponseSubscriptionEntitlementType> expectedType =
            SubscriptionListResponseSubscriptionEntitlementType.Feature;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionListResponseSubscriptionEntitlement
        {
            ID = "id",
            Type = SubscriptionListResponseSubscriptionEntitlementType.Feature,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionListResponseSubscriptionEntitlement>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionListResponseSubscriptionEntitlement
        {
            ID = "id",
            Type = SubscriptionListResponseSubscriptionEntitlementType.Feature,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionListResponseSubscriptionEntitlement>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        ApiEnum<string, SubscriptionListResponseSubscriptionEntitlementType> expectedType =
            SubscriptionListResponseSubscriptionEntitlementType.Feature;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionListResponseSubscriptionEntitlement
        {
            ID = "id",
            Type = SubscriptionListResponseSubscriptionEntitlementType.Feature,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionListResponseSubscriptionEntitlement
        {
            ID = "id",
            Type = SubscriptionListResponseSubscriptionEntitlementType.Feature,
        };

        SubscriptionListResponseSubscriptionEntitlement copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionListResponseSubscriptionEntitlementTypeTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionListResponseSubscriptionEntitlementType.Feature)]
    [InlineData(SubscriptionListResponseSubscriptionEntitlementType.Credit)]
    public void Validation_Works(SubscriptionListResponseSubscriptionEntitlementType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionListResponseSubscriptionEntitlementType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionListResponseSubscriptionEntitlementType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionListResponseSubscriptionEntitlementType.Feature)]
    [InlineData(SubscriptionListResponseSubscriptionEntitlementType.Credit)]
    public void SerializationRoundtrip_Works(
        SubscriptionListResponseSubscriptionEntitlementType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionListResponseSubscriptionEntitlementType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionListResponseSubscriptionEntitlementType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionListResponseSubscriptionEntitlementType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionListResponseSubscriptionEntitlementType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionListResponseTrialTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionListResponseTrial
        {
            TrialEndBehavior = SubscriptionListResponseTrialTrialEndBehavior.ConvertToPaid,
        };

        ApiEnum<string, SubscriptionListResponseTrialTrialEndBehavior> expectedTrialEndBehavior =
            SubscriptionListResponseTrialTrialEndBehavior.ConvertToPaid;

        Assert.Equal(expectedTrialEndBehavior, model.TrialEndBehavior);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionListResponseTrial
        {
            TrialEndBehavior = SubscriptionListResponseTrialTrialEndBehavior.ConvertToPaid,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionListResponseTrial>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionListResponseTrial
        {
            TrialEndBehavior = SubscriptionListResponseTrialTrialEndBehavior.ConvertToPaid,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionListResponseTrial>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, SubscriptionListResponseTrialTrialEndBehavior> expectedTrialEndBehavior =
            SubscriptionListResponseTrialTrialEndBehavior.ConvertToPaid;

        Assert.Equal(expectedTrialEndBehavior, deserialized.TrialEndBehavior);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionListResponseTrial
        {
            TrialEndBehavior = SubscriptionListResponseTrialTrialEndBehavior.ConvertToPaid,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionListResponseTrial
        {
            TrialEndBehavior = SubscriptionListResponseTrialTrialEndBehavior.ConvertToPaid,
        };

        SubscriptionListResponseTrial copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionListResponseTrialTrialEndBehaviorTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionListResponseTrialTrialEndBehavior.ConvertToPaid)]
    [InlineData(SubscriptionListResponseTrialTrialEndBehavior.CancelSubscription)]
    public void Validation_Works(SubscriptionListResponseTrialTrialEndBehavior rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionListResponseTrialTrialEndBehavior> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionListResponseTrialTrialEndBehavior>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionListResponseTrialTrialEndBehavior.ConvertToPaid)]
    [InlineData(SubscriptionListResponseTrialTrialEndBehavior.CancelSubscription)]
    public void SerializationRoundtrip_Works(SubscriptionListResponseTrialTrialEndBehavior rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionListResponseTrialTrialEndBehavior> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionListResponseTrialTrialEndBehavior>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionListResponseTrialTrialEndBehavior>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionListResponseTrialTrialEndBehavior>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
