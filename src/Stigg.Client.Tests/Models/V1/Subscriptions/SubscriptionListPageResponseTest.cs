using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Subscriptions;

namespace Stigg.Client.Tests.Models.V1.Subscriptions;

public class SubscriptionListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionListPageResponse
        {
            Data =
            [
                new()
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
                            ScheduledExecutionTime = DateTimeOffset.Parse(
                                "2019-12-27T18:11:19.117Z"
                            ),
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
                        BillingReason =
                            SubscriptionListResponseLatestInvoiceBillingReason.BillingCycle,
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
                    PaymentCollectionMethod =
                        SubscriptionListResponsePaymentCollectionMethod.Charge,
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
                                        Currency =
                                            SubscriptionListResponsePriceTierFlatPriceCurrency.Usd,
                                    },
                                    UnitPrice = new()
                                    {
                                        Amount = 0,
                                        Currency =
                                            SubscriptionListResponsePriceTierUnitPriceCurrency.Usd,
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
                },
            ],
            Pagination = new()
            {
                Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            },
        };

        List<SubscriptionListResponse> expectedData =
        [
            new()
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
                                    Currency =
                                        SubscriptionListResponsePriceTierFlatPriceCurrency.Usd,
                                },
                                UnitPrice = new()
                                {
                                    Amount = 0,
                                    Currency =
                                        SubscriptionListResponsePriceTierUnitPriceCurrency.Usd,
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
            },
        ];
        Pagination expectedPagination = new()
        {
            Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedPagination, model.Pagination);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionListPageResponse
        {
            Data =
            [
                new()
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
                            ScheduledExecutionTime = DateTimeOffset.Parse(
                                "2019-12-27T18:11:19.117Z"
                            ),
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
                        BillingReason =
                            SubscriptionListResponseLatestInvoiceBillingReason.BillingCycle,
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
                    PaymentCollectionMethod =
                        SubscriptionListResponsePaymentCollectionMethod.Charge,
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
                                        Currency =
                                            SubscriptionListResponsePriceTierFlatPriceCurrency.Usd,
                                    },
                                    UnitPrice = new()
                                    {
                                        Amount = 0,
                                        Currency =
                                            SubscriptionListResponsePriceTierUnitPriceCurrency.Usd,
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
                },
            ],
            Pagination = new()
            {
                Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionListPageResponse
        {
            Data =
            [
                new()
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
                            ScheduledExecutionTime = DateTimeOffset.Parse(
                                "2019-12-27T18:11:19.117Z"
                            ),
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
                        BillingReason =
                            SubscriptionListResponseLatestInvoiceBillingReason.BillingCycle,
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
                    PaymentCollectionMethod =
                        SubscriptionListResponsePaymentCollectionMethod.Charge,
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
                                        Currency =
                                            SubscriptionListResponsePriceTierFlatPriceCurrency.Usd,
                                    },
                                    UnitPrice = new()
                                    {
                                        Amount = 0,
                                        Currency =
                                            SubscriptionListResponsePriceTierUnitPriceCurrency.Usd,
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
                },
            ],
            Pagination = new()
            {
                Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<SubscriptionListResponse> expectedData =
        [
            new()
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
                                    Currency =
                                        SubscriptionListResponsePriceTierFlatPriceCurrency.Usd,
                                },
                                UnitPrice = new()
                                {
                                    Amount = 0,
                                    Currency =
                                        SubscriptionListResponsePriceTierUnitPriceCurrency.Usd,
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
            },
        ];
        Pagination expectedPagination = new()
        {
            Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedPagination, deserialized.Pagination);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionListPageResponse
        {
            Data =
            [
                new()
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
                            ScheduledExecutionTime = DateTimeOffset.Parse(
                                "2019-12-27T18:11:19.117Z"
                            ),
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
                        BillingReason =
                            SubscriptionListResponseLatestInvoiceBillingReason.BillingCycle,
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
                    PaymentCollectionMethod =
                        SubscriptionListResponsePaymentCollectionMethod.Charge,
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
                                        Currency =
                                            SubscriptionListResponsePriceTierFlatPriceCurrency.Usd,
                                    },
                                    UnitPrice = new()
                                    {
                                        Amount = 0,
                                        Currency =
                                            SubscriptionListResponsePriceTierUnitPriceCurrency.Usd,
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
                },
            ],
            Pagination = new()
            {
                Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionListPageResponse
        {
            Data =
            [
                new()
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
                            ScheduledExecutionTime = DateTimeOffset.Parse(
                                "2019-12-27T18:11:19.117Z"
                            ),
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
                        BillingReason =
                            SubscriptionListResponseLatestInvoiceBillingReason.BillingCycle,
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
                    PaymentCollectionMethod =
                        SubscriptionListResponsePaymentCollectionMethod.Charge,
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
                                        Currency =
                                            SubscriptionListResponsePriceTierFlatPriceCurrency.Usd,
                                    },
                                    UnitPrice = new()
                                    {
                                        Amount = 0,
                                        Currency =
                                            SubscriptionListResponsePriceTierUnitPriceCurrency.Usd,
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
                },
            ],
            Pagination = new()
            {
                Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            },
        };

        SubscriptionListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PaginationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Pagination
        {
            Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string expectedNext = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedPrev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedNext, model.Next);
        Assert.Equal(expectedPrev, model.Prev);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Pagination
        {
            Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Pagination>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Pagination
        {
            Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Pagination>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedNext = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedPrev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedNext, deserialized.Next);
        Assert.Equal(expectedPrev, deserialized.Prev);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Pagination
        {
            Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Pagination
        {
            Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Pagination copied = new(model);

        Assert.Equal(model, copied);
    }
}
