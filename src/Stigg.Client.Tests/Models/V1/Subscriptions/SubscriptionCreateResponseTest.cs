using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Subscriptions;

namespace Stigg.Client.Tests.Models.V1.Subscriptions;

public class SubscriptionCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionCreateResponse
        {
            Data = new()
            {
                ID = "id",
                Entitlements =
                [
                    new()
                    {
                        AccessDeniedReason = "accessDeniedReason",
                        CurrentUsage = 0,
                        EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Feature = new("refId"),
                        HasUnlimitedUsage = true,
                        IsGranted = true,
                        ResetPeriod = ResetPeriod.Year,
                        UsageLimit = 0,
                        UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
                Status = Status.Success,
                CheckoutBillingID = "checkoutBillingId",
                CheckoutUrl = "checkoutUrl",
                IsScheduled = true,
                Subscription = new()
                {
                    ID = "id",
                    BillingID = "billingId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "customerId",
                    PaymentCollection = PaymentCollection.NotRequired,
                    PlanID = "planId",
                    PricingType = PricingType.Free,
                    StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = SubscriptionStatus.PaymentPending,
                    CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CancelReason = CancelReason.UpgradeOrDowngrade,
                    CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PayingCustomerID = "payingCustomerId",
                    PaymentCollectionMethod = SubscriptionPaymentCollectionMethod.Charge,
                    Prices =
                    [
                        new()
                        {
                            AddonID = "addonId",
                            BaseCharge = true,
                            BlockSize = 0,
                            FeatureID = "featureId",
                            Price = new()
                            {
                                Amount = 0,
                                BillingCountryCode = "billingCountryCode",
                                Currency = SubscriptionPricePriceCurrency.Usd,
                            },
                            Tiers =
                            [
                                new()
                                {
                                    FlatPrice = new()
                                    {
                                        Amount = 0,
                                        BillingCountryCode = "billingCountryCode",
                                        Currency = SubscriptionPriceTierFlatPriceCurrency.Usd,
                                    },
                                    UnitPrice = new()
                                    {
                                        Amount = 0,
                                        BillingCountryCode = "billingCountryCode",
                                        Currency = SubscriptionPriceTierUnitPriceCurrency.Usd,
                                    },
                                    UpTo = 0,
                                },
                            ],
                        },
                    ],
                    ResourceID = "resourceId",
                    TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UnitQuantity = 1,
                },
            },
        };

        Data expectedData = new()
        {
            ID = "id",
            Entitlements =
            [
                new()
                {
                    AccessDeniedReason = "accessDeniedReason",
                    CurrentUsage = 0,
                    EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Feature = new("refId"),
                    HasUnlimitedUsage = true,
                    IsGranted = true,
                    ResetPeriod = ResetPeriod.Year,
                    UsageLimit = 0,
                    UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Status = Status.Success,
            CheckoutBillingID = "checkoutBillingId",
            CheckoutUrl = "checkoutUrl",
            IsScheduled = true,
            Subscription = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customerId",
                PaymentCollection = PaymentCollection.NotRequired,
                PlanID = "planId",
                PricingType = PricingType.Free,
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = SubscriptionStatus.PaymentPending,
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason = CancelReason.UpgradeOrDowngrade,
                CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod = SubscriptionPaymentCollectionMethod.Charge,
                Prices =
                [
                    new()
                    {
                        AddonID = "addonId",
                        BaseCharge = true,
                        BlockSize = 0,
                        FeatureID = "featureId",
                        Price = new()
                        {
                            Amount = 0,
                            BillingCountryCode = "billingCountryCode",
                            Currency = SubscriptionPricePriceCurrency.Usd,
                        },
                        Tiers =
                        [
                            new()
                            {
                                FlatPrice = new()
                                {
                                    Amount = 0,
                                    BillingCountryCode = "billingCountryCode",
                                    Currency = SubscriptionPriceTierFlatPriceCurrency.Usd,
                                },
                                UnitPrice = new()
                                {
                                    Amount = 0,
                                    BillingCountryCode = "billingCountryCode",
                                    Currency = SubscriptionPriceTierUnitPriceCurrency.Usd,
                                },
                                UpTo = 0,
                            },
                        ],
                    },
                ],
                ResourceID = "resourceId",
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UnitQuantity = 1,
            },
        };

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionCreateResponse
        {
            Data = new()
            {
                ID = "id",
                Entitlements =
                [
                    new()
                    {
                        AccessDeniedReason = "accessDeniedReason",
                        CurrentUsage = 0,
                        EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Feature = new("refId"),
                        HasUnlimitedUsage = true,
                        IsGranted = true,
                        ResetPeriod = ResetPeriod.Year,
                        UsageLimit = 0,
                        UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
                Status = Status.Success,
                CheckoutBillingID = "checkoutBillingId",
                CheckoutUrl = "checkoutUrl",
                IsScheduled = true,
                Subscription = new()
                {
                    ID = "id",
                    BillingID = "billingId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "customerId",
                    PaymentCollection = PaymentCollection.NotRequired,
                    PlanID = "planId",
                    PricingType = PricingType.Free,
                    StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = SubscriptionStatus.PaymentPending,
                    CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CancelReason = CancelReason.UpgradeOrDowngrade,
                    CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PayingCustomerID = "payingCustomerId",
                    PaymentCollectionMethod = SubscriptionPaymentCollectionMethod.Charge,
                    Prices =
                    [
                        new()
                        {
                            AddonID = "addonId",
                            BaseCharge = true,
                            BlockSize = 0,
                            FeatureID = "featureId",
                            Price = new()
                            {
                                Amount = 0,
                                BillingCountryCode = "billingCountryCode",
                                Currency = SubscriptionPricePriceCurrency.Usd,
                            },
                            Tiers =
                            [
                                new()
                                {
                                    FlatPrice = new()
                                    {
                                        Amount = 0,
                                        BillingCountryCode = "billingCountryCode",
                                        Currency = SubscriptionPriceTierFlatPriceCurrency.Usd,
                                    },
                                    UnitPrice = new()
                                    {
                                        Amount = 0,
                                        BillingCountryCode = "billingCountryCode",
                                        Currency = SubscriptionPriceTierUnitPriceCurrency.Usd,
                                    },
                                    UpTo = 0,
                                },
                            ],
                        },
                    ],
                    ResourceID = "resourceId",
                    TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UnitQuantity = 1,
                },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionCreateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionCreateResponse
        {
            Data = new()
            {
                ID = "id",
                Entitlements =
                [
                    new()
                    {
                        AccessDeniedReason = "accessDeniedReason",
                        CurrentUsage = 0,
                        EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Feature = new("refId"),
                        HasUnlimitedUsage = true,
                        IsGranted = true,
                        ResetPeriod = ResetPeriod.Year,
                        UsageLimit = 0,
                        UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
                Status = Status.Success,
                CheckoutBillingID = "checkoutBillingId",
                CheckoutUrl = "checkoutUrl",
                IsScheduled = true,
                Subscription = new()
                {
                    ID = "id",
                    BillingID = "billingId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "customerId",
                    PaymentCollection = PaymentCollection.NotRequired,
                    PlanID = "planId",
                    PricingType = PricingType.Free,
                    StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = SubscriptionStatus.PaymentPending,
                    CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CancelReason = CancelReason.UpgradeOrDowngrade,
                    CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PayingCustomerID = "payingCustomerId",
                    PaymentCollectionMethod = SubscriptionPaymentCollectionMethod.Charge,
                    Prices =
                    [
                        new()
                        {
                            AddonID = "addonId",
                            BaseCharge = true,
                            BlockSize = 0,
                            FeatureID = "featureId",
                            Price = new()
                            {
                                Amount = 0,
                                BillingCountryCode = "billingCountryCode",
                                Currency = SubscriptionPricePriceCurrency.Usd,
                            },
                            Tiers =
                            [
                                new()
                                {
                                    FlatPrice = new()
                                    {
                                        Amount = 0,
                                        BillingCountryCode = "billingCountryCode",
                                        Currency = SubscriptionPriceTierFlatPriceCurrency.Usd,
                                    },
                                    UnitPrice = new()
                                    {
                                        Amount = 0,
                                        BillingCountryCode = "billingCountryCode",
                                        Currency = SubscriptionPriceTierUnitPriceCurrency.Usd,
                                    },
                                    UpTo = 0,
                                },
                            ],
                        },
                    ],
                    ResourceID = "resourceId",
                    TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UnitQuantity = 1,
                },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Data expectedData = new()
        {
            ID = "id",
            Entitlements =
            [
                new()
                {
                    AccessDeniedReason = "accessDeniedReason",
                    CurrentUsage = 0,
                    EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Feature = new("refId"),
                    HasUnlimitedUsage = true,
                    IsGranted = true,
                    ResetPeriod = ResetPeriod.Year,
                    UsageLimit = 0,
                    UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Status = Status.Success,
            CheckoutBillingID = "checkoutBillingId",
            CheckoutUrl = "checkoutUrl",
            IsScheduled = true,
            Subscription = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customerId",
                PaymentCollection = PaymentCollection.NotRequired,
                PlanID = "planId",
                PricingType = PricingType.Free,
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = SubscriptionStatus.PaymentPending,
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason = CancelReason.UpgradeOrDowngrade,
                CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod = SubscriptionPaymentCollectionMethod.Charge,
                Prices =
                [
                    new()
                    {
                        AddonID = "addonId",
                        BaseCharge = true,
                        BlockSize = 0,
                        FeatureID = "featureId",
                        Price = new()
                        {
                            Amount = 0,
                            BillingCountryCode = "billingCountryCode",
                            Currency = SubscriptionPricePriceCurrency.Usd,
                        },
                        Tiers =
                        [
                            new()
                            {
                                FlatPrice = new()
                                {
                                    Amount = 0,
                                    BillingCountryCode = "billingCountryCode",
                                    Currency = SubscriptionPriceTierFlatPriceCurrency.Usd,
                                },
                                UnitPrice = new()
                                {
                                    Amount = 0,
                                    BillingCountryCode = "billingCountryCode",
                                    Currency = SubscriptionPriceTierUnitPriceCurrency.Usd,
                                },
                                UpTo = 0,
                            },
                        ],
                    },
                ],
                ResourceID = "resourceId",
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UnitQuantity = 1,
            },
        };

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionCreateResponse
        {
            Data = new()
            {
                ID = "id",
                Entitlements =
                [
                    new()
                    {
                        AccessDeniedReason = "accessDeniedReason",
                        CurrentUsage = 0,
                        EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Feature = new("refId"),
                        HasUnlimitedUsage = true,
                        IsGranted = true,
                        ResetPeriod = ResetPeriod.Year,
                        UsageLimit = 0,
                        UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
                Status = Status.Success,
                CheckoutBillingID = "checkoutBillingId",
                CheckoutUrl = "checkoutUrl",
                IsScheduled = true,
                Subscription = new()
                {
                    ID = "id",
                    BillingID = "billingId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "customerId",
                    PaymentCollection = PaymentCollection.NotRequired,
                    PlanID = "planId",
                    PricingType = PricingType.Free,
                    StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = SubscriptionStatus.PaymentPending,
                    CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CancelReason = CancelReason.UpgradeOrDowngrade,
                    CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PayingCustomerID = "payingCustomerId",
                    PaymentCollectionMethod = SubscriptionPaymentCollectionMethod.Charge,
                    Prices =
                    [
                        new()
                        {
                            AddonID = "addonId",
                            BaseCharge = true,
                            BlockSize = 0,
                            FeatureID = "featureId",
                            Price = new()
                            {
                                Amount = 0,
                                BillingCountryCode = "billingCountryCode",
                                Currency = SubscriptionPricePriceCurrency.Usd,
                            },
                            Tiers =
                            [
                                new()
                                {
                                    FlatPrice = new()
                                    {
                                        Amount = 0,
                                        BillingCountryCode = "billingCountryCode",
                                        Currency = SubscriptionPriceTierFlatPriceCurrency.Usd,
                                    },
                                    UnitPrice = new()
                                    {
                                        Amount = 0,
                                        BillingCountryCode = "billingCountryCode",
                                        Currency = SubscriptionPriceTierUnitPriceCurrency.Usd,
                                    },
                                    UpTo = 0,
                                },
                            ],
                        },
                    ],
                    ResourceID = "resourceId",
                    TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UnitQuantity = 1,
                },
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionCreateResponse
        {
            Data = new()
            {
                ID = "id",
                Entitlements =
                [
                    new()
                    {
                        AccessDeniedReason = "accessDeniedReason",
                        CurrentUsage = 0,
                        EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Feature = new("refId"),
                        HasUnlimitedUsage = true,
                        IsGranted = true,
                        ResetPeriod = ResetPeriod.Year,
                        UsageLimit = 0,
                        UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
                Status = Status.Success,
                CheckoutBillingID = "checkoutBillingId",
                CheckoutUrl = "checkoutUrl",
                IsScheduled = true,
                Subscription = new()
                {
                    ID = "id",
                    BillingID = "billingId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "customerId",
                    PaymentCollection = PaymentCollection.NotRequired,
                    PlanID = "planId",
                    PricingType = PricingType.Free,
                    StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = SubscriptionStatus.PaymentPending,
                    CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CancelReason = CancelReason.UpgradeOrDowngrade,
                    CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PayingCustomerID = "payingCustomerId",
                    PaymentCollectionMethod = SubscriptionPaymentCollectionMethod.Charge,
                    Prices =
                    [
                        new()
                        {
                            AddonID = "addonId",
                            BaseCharge = true,
                            BlockSize = 0,
                            FeatureID = "featureId",
                            Price = new()
                            {
                                Amount = 0,
                                BillingCountryCode = "billingCountryCode",
                                Currency = SubscriptionPricePriceCurrency.Usd,
                            },
                            Tiers =
                            [
                                new()
                                {
                                    FlatPrice = new()
                                    {
                                        Amount = 0,
                                        BillingCountryCode = "billingCountryCode",
                                        Currency = SubscriptionPriceTierFlatPriceCurrency.Usd,
                                    },
                                    UnitPrice = new()
                                    {
                                        Amount = 0,
                                        BillingCountryCode = "billingCountryCode",
                                        Currency = SubscriptionPriceTierUnitPriceCurrency.Usd,
                                    },
                                    UpTo = 0,
                                },
                            ],
                        },
                    ],
                    ResourceID = "resourceId",
                    TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UnitQuantity = 1,
                },
            },
        };

        SubscriptionCreateResponse copied = new(model);

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
            Entitlements =
            [
                new()
                {
                    AccessDeniedReason = "accessDeniedReason",
                    CurrentUsage = 0,
                    EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Feature = new("refId"),
                    HasUnlimitedUsage = true,
                    IsGranted = true,
                    ResetPeriod = ResetPeriod.Year,
                    UsageLimit = 0,
                    UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Status = Status.Success,
            CheckoutBillingID = "checkoutBillingId",
            CheckoutUrl = "checkoutUrl",
            IsScheduled = true,
            Subscription = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customerId",
                PaymentCollection = PaymentCollection.NotRequired,
                PlanID = "planId",
                PricingType = PricingType.Free,
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = SubscriptionStatus.PaymentPending,
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason = CancelReason.UpgradeOrDowngrade,
                CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod = SubscriptionPaymentCollectionMethod.Charge,
                Prices =
                [
                    new()
                    {
                        AddonID = "addonId",
                        BaseCharge = true,
                        BlockSize = 0,
                        FeatureID = "featureId",
                        Price = new()
                        {
                            Amount = 0,
                            BillingCountryCode = "billingCountryCode",
                            Currency = SubscriptionPricePriceCurrency.Usd,
                        },
                        Tiers =
                        [
                            new()
                            {
                                FlatPrice = new()
                                {
                                    Amount = 0,
                                    BillingCountryCode = "billingCountryCode",
                                    Currency = SubscriptionPriceTierFlatPriceCurrency.Usd,
                                },
                                UnitPrice = new()
                                {
                                    Amount = 0,
                                    BillingCountryCode = "billingCountryCode",
                                    Currency = SubscriptionPriceTierUnitPriceCurrency.Usd,
                                },
                                UpTo = 0,
                            },
                        ],
                    },
                ],
                ResourceID = "resourceId",
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UnitQuantity = 1,
            },
        };

        string expectedID = "id";
        List<Entitlement> expectedEntitlements =
        [
            new()
            {
                AccessDeniedReason = "accessDeniedReason",
                CurrentUsage = 0,
                EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Feature = new("refId"),
                HasUnlimitedUsage = true,
                IsGranted = true,
                ResetPeriod = ResetPeriod.Year,
                UsageLimit = 0,
                UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        ApiEnum<string, Status> expectedStatus = Status.Success;
        string expectedCheckoutBillingID = "checkoutBillingId";
        string expectedCheckoutUrl = "checkoutUrl";
        bool expectedIsScheduled = true;
        Subscription expectedSubscription = new()
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = PaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = PricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionStatus.PaymentPending,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = CancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod = SubscriptionPaymentCollectionMethod.Charge,
            Prices =
            [
                new()
                {
                    AddonID = "addonId",
                    BaseCharge = true,
                    BlockSize = 0,
                    FeatureID = "featureId",
                    Price = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
                        Currency = SubscriptionPricePriceCurrency.Usd,
                    },
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                BillingCountryCode = "billingCountryCode",
                                Currency = SubscriptionPriceTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                BillingCountryCode = "billingCountryCode",
                                Currency = SubscriptionPriceTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            ResourceID = "resourceId",
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UnitQuantity = 1,
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedEntitlements.Count, model.Entitlements.Count);
        for (int i = 0; i < expectedEntitlements.Count; i++)
        {
            Assert.Equal(expectedEntitlements[i], model.Entitlements[i]);
        }
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedCheckoutBillingID, model.CheckoutBillingID);
        Assert.Equal(expectedCheckoutUrl, model.CheckoutUrl);
        Assert.Equal(expectedIsScheduled, model.IsScheduled);
        Assert.Equal(expectedSubscription, model.Subscription);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Data
        {
            ID = "id",
            Entitlements =
            [
                new()
                {
                    AccessDeniedReason = "accessDeniedReason",
                    CurrentUsage = 0,
                    EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Feature = new("refId"),
                    HasUnlimitedUsage = true,
                    IsGranted = true,
                    ResetPeriod = ResetPeriod.Year,
                    UsageLimit = 0,
                    UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Status = Status.Success,
            CheckoutBillingID = "checkoutBillingId",
            CheckoutUrl = "checkoutUrl",
            IsScheduled = true,
            Subscription = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customerId",
                PaymentCollection = PaymentCollection.NotRequired,
                PlanID = "planId",
                PricingType = PricingType.Free,
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = SubscriptionStatus.PaymentPending,
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason = CancelReason.UpgradeOrDowngrade,
                CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod = SubscriptionPaymentCollectionMethod.Charge,
                Prices =
                [
                    new()
                    {
                        AddonID = "addonId",
                        BaseCharge = true,
                        BlockSize = 0,
                        FeatureID = "featureId",
                        Price = new()
                        {
                            Amount = 0,
                            BillingCountryCode = "billingCountryCode",
                            Currency = SubscriptionPricePriceCurrency.Usd,
                        },
                        Tiers =
                        [
                            new()
                            {
                                FlatPrice = new()
                                {
                                    Amount = 0,
                                    BillingCountryCode = "billingCountryCode",
                                    Currency = SubscriptionPriceTierFlatPriceCurrency.Usd,
                                },
                                UnitPrice = new()
                                {
                                    Amount = 0,
                                    BillingCountryCode = "billingCountryCode",
                                    Currency = SubscriptionPriceTierUnitPriceCurrency.Usd,
                                },
                                UpTo = 0,
                            },
                        ],
                    },
                ],
                ResourceID = "resourceId",
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UnitQuantity = 1,
            },
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
            Entitlements =
            [
                new()
                {
                    AccessDeniedReason = "accessDeniedReason",
                    CurrentUsage = 0,
                    EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Feature = new("refId"),
                    HasUnlimitedUsage = true,
                    IsGranted = true,
                    ResetPeriod = ResetPeriod.Year,
                    UsageLimit = 0,
                    UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Status = Status.Success,
            CheckoutBillingID = "checkoutBillingId",
            CheckoutUrl = "checkoutUrl",
            IsScheduled = true,
            Subscription = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customerId",
                PaymentCollection = PaymentCollection.NotRequired,
                PlanID = "planId",
                PricingType = PricingType.Free,
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = SubscriptionStatus.PaymentPending,
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason = CancelReason.UpgradeOrDowngrade,
                CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod = SubscriptionPaymentCollectionMethod.Charge,
                Prices =
                [
                    new()
                    {
                        AddonID = "addonId",
                        BaseCharge = true,
                        BlockSize = 0,
                        FeatureID = "featureId",
                        Price = new()
                        {
                            Amount = 0,
                            BillingCountryCode = "billingCountryCode",
                            Currency = SubscriptionPricePriceCurrency.Usd,
                        },
                        Tiers =
                        [
                            new()
                            {
                                FlatPrice = new()
                                {
                                    Amount = 0,
                                    BillingCountryCode = "billingCountryCode",
                                    Currency = SubscriptionPriceTierFlatPriceCurrency.Usd,
                                },
                                UnitPrice = new()
                                {
                                    Amount = 0,
                                    BillingCountryCode = "billingCountryCode",
                                    Currency = SubscriptionPriceTierUnitPriceCurrency.Usd,
                                },
                                UpTo = 0,
                            },
                        ],
                    },
                ],
                ResourceID = "resourceId",
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UnitQuantity = 1,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        List<Entitlement> expectedEntitlements =
        [
            new()
            {
                AccessDeniedReason = "accessDeniedReason",
                CurrentUsage = 0,
                EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Feature = new("refId"),
                HasUnlimitedUsage = true,
                IsGranted = true,
                ResetPeriod = ResetPeriod.Year,
                UsageLimit = 0,
                UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        ApiEnum<string, Status> expectedStatus = Status.Success;
        string expectedCheckoutBillingID = "checkoutBillingId";
        string expectedCheckoutUrl = "checkoutUrl";
        bool expectedIsScheduled = true;
        Subscription expectedSubscription = new()
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = PaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = PricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionStatus.PaymentPending,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = CancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod = SubscriptionPaymentCollectionMethod.Charge,
            Prices =
            [
                new()
                {
                    AddonID = "addonId",
                    BaseCharge = true,
                    BlockSize = 0,
                    FeatureID = "featureId",
                    Price = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
                        Currency = SubscriptionPricePriceCurrency.Usd,
                    },
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                BillingCountryCode = "billingCountryCode",
                                Currency = SubscriptionPriceTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                BillingCountryCode = "billingCountryCode",
                                Currency = SubscriptionPriceTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            ResourceID = "resourceId",
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UnitQuantity = 1,
        };

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedEntitlements.Count, deserialized.Entitlements.Count);
        for (int i = 0; i < expectedEntitlements.Count; i++)
        {
            Assert.Equal(expectedEntitlements[i], deserialized.Entitlements[i]);
        }
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedCheckoutBillingID, deserialized.CheckoutBillingID);
        Assert.Equal(expectedCheckoutUrl, deserialized.CheckoutUrl);
        Assert.Equal(expectedIsScheduled, deserialized.IsScheduled);
        Assert.Equal(expectedSubscription, deserialized.Subscription);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Data
        {
            ID = "id",
            Entitlements =
            [
                new()
                {
                    AccessDeniedReason = "accessDeniedReason",
                    CurrentUsage = 0,
                    EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Feature = new("refId"),
                    HasUnlimitedUsage = true,
                    IsGranted = true,
                    ResetPeriod = ResetPeriod.Year,
                    UsageLimit = 0,
                    UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Status = Status.Success,
            CheckoutBillingID = "checkoutBillingId",
            CheckoutUrl = "checkoutUrl",
            IsScheduled = true,
            Subscription = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customerId",
                PaymentCollection = PaymentCollection.NotRequired,
                PlanID = "planId",
                PricingType = PricingType.Free,
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = SubscriptionStatus.PaymentPending,
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason = CancelReason.UpgradeOrDowngrade,
                CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod = SubscriptionPaymentCollectionMethod.Charge,
                Prices =
                [
                    new()
                    {
                        AddonID = "addonId",
                        BaseCharge = true,
                        BlockSize = 0,
                        FeatureID = "featureId",
                        Price = new()
                        {
                            Amount = 0,
                            BillingCountryCode = "billingCountryCode",
                            Currency = SubscriptionPricePriceCurrency.Usd,
                        },
                        Tiers =
                        [
                            new()
                            {
                                FlatPrice = new()
                                {
                                    Amount = 0,
                                    BillingCountryCode = "billingCountryCode",
                                    Currency = SubscriptionPriceTierFlatPriceCurrency.Usd,
                                },
                                UnitPrice = new()
                                {
                                    Amount = 0,
                                    BillingCountryCode = "billingCountryCode",
                                    Currency = SubscriptionPriceTierUnitPriceCurrency.Usd,
                                },
                                UpTo = 0,
                            },
                        ],
                    },
                ],
                ResourceID = "resourceId",
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UnitQuantity = 1,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Data
        {
            ID = "id",
            Entitlements =
            [
                new()
                {
                    AccessDeniedReason = "accessDeniedReason",
                    CurrentUsage = 0,
                    EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Feature = new("refId"),
                    HasUnlimitedUsage = true,
                    IsGranted = true,
                    ResetPeriod = ResetPeriod.Year,
                    UsageLimit = 0,
                    UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Status = Status.Success,
            CheckoutBillingID = "checkoutBillingId",
            CheckoutUrl = "checkoutUrl",
        };

        Assert.Null(model.IsScheduled);
        Assert.False(model.RawData.ContainsKey("isScheduled"));
        Assert.Null(model.Subscription);
        Assert.False(model.RawData.ContainsKey("subscription"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Data
        {
            ID = "id",
            Entitlements =
            [
                new()
                {
                    AccessDeniedReason = "accessDeniedReason",
                    CurrentUsage = 0,
                    EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Feature = new("refId"),
                    HasUnlimitedUsage = true,
                    IsGranted = true,
                    ResetPeriod = ResetPeriod.Year,
                    UsageLimit = 0,
                    UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Status = Status.Success,
            CheckoutBillingID = "checkoutBillingId",
            CheckoutUrl = "checkoutUrl",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Data
        {
            ID = "id",
            Entitlements =
            [
                new()
                {
                    AccessDeniedReason = "accessDeniedReason",
                    CurrentUsage = 0,
                    EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Feature = new("refId"),
                    HasUnlimitedUsage = true,
                    IsGranted = true,
                    ResetPeriod = ResetPeriod.Year,
                    UsageLimit = 0,
                    UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Status = Status.Success,
            CheckoutBillingID = "checkoutBillingId",
            CheckoutUrl = "checkoutUrl",

            // Null should be interpreted as omitted for these properties
            IsScheduled = null,
            Subscription = null,
        };

        Assert.Null(model.IsScheduled);
        Assert.False(model.RawData.ContainsKey("isScheduled"));
        Assert.Null(model.Subscription);
        Assert.False(model.RawData.ContainsKey("subscription"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Data
        {
            ID = "id",
            Entitlements =
            [
                new()
                {
                    AccessDeniedReason = "accessDeniedReason",
                    CurrentUsage = 0,
                    EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Feature = new("refId"),
                    HasUnlimitedUsage = true,
                    IsGranted = true,
                    ResetPeriod = ResetPeriod.Year,
                    UsageLimit = 0,
                    UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Status = Status.Success,
            CheckoutBillingID = "checkoutBillingId",
            CheckoutUrl = "checkoutUrl",

            // Null should be interpreted as omitted for these properties
            IsScheduled = null,
            Subscription = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Data
        {
            ID = "id",
            Entitlements =
            [
                new()
                {
                    AccessDeniedReason = "accessDeniedReason",
                    CurrentUsage = 0,
                    EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Feature = new("refId"),
                    HasUnlimitedUsage = true,
                    IsGranted = true,
                    ResetPeriod = ResetPeriod.Year,
                    UsageLimit = 0,
                    UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Status = Status.Success,
            IsScheduled = true,
            Subscription = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customerId",
                PaymentCollection = PaymentCollection.NotRequired,
                PlanID = "planId",
                PricingType = PricingType.Free,
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = SubscriptionStatus.PaymentPending,
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason = CancelReason.UpgradeOrDowngrade,
                CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod = SubscriptionPaymentCollectionMethod.Charge,
                Prices =
                [
                    new()
                    {
                        AddonID = "addonId",
                        BaseCharge = true,
                        BlockSize = 0,
                        FeatureID = "featureId",
                        Price = new()
                        {
                            Amount = 0,
                            BillingCountryCode = "billingCountryCode",
                            Currency = SubscriptionPricePriceCurrency.Usd,
                        },
                        Tiers =
                        [
                            new()
                            {
                                FlatPrice = new()
                                {
                                    Amount = 0,
                                    BillingCountryCode = "billingCountryCode",
                                    Currency = SubscriptionPriceTierFlatPriceCurrency.Usd,
                                },
                                UnitPrice = new()
                                {
                                    Amount = 0,
                                    BillingCountryCode = "billingCountryCode",
                                    Currency = SubscriptionPriceTierUnitPriceCurrency.Usd,
                                },
                                UpTo = 0,
                            },
                        ],
                    },
                ],
                ResourceID = "resourceId",
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UnitQuantity = 1,
            },
        };

        Assert.Null(model.CheckoutBillingID);
        Assert.False(model.RawData.ContainsKey("checkoutBillingId"));
        Assert.Null(model.CheckoutUrl);
        Assert.False(model.RawData.ContainsKey("checkoutUrl"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Data
        {
            ID = "id",
            Entitlements =
            [
                new()
                {
                    AccessDeniedReason = "accessDeniedReason",
                    CurrentUsage = 0,
                    EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Feature = new("refId"),
                    HasUnlimitedUsage = true,
                    IsGranted = true,
                    ResetPeriod = ResetPeriod.Year,
                    UsageLimit = 0,
                    UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Status = Status.Success,
            IsScheduled = true,
            Subscription = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customerId",
                PaymentCollection = PaymentCollection.NotRequired,
                PlanID = "planId",
                PricingType = PricingType.Free,
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = SubscriptionStatus.PaymentPending,
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason = CancelReason.UpgradeOrDowngrade,
                CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod = SubscriptionPaymentCollectionMethod.Charge,
                Prices =
                [
                    new()
                    {
                        AddonID = "addonId",
                        BaseCharge = true,
                        BlockSize = 0,
                        FeatureID = "featureId",
                        Price = new()
                        {
                            Amount = 0,
                            BillingCountryCode = "billingCountryCode",
                            Currency = SubscriptionPricePriceCurrency.Usd,
                        },
                        Tiers =
                        [
                            new()
                            {
                                FlatPrice = new()
                                {
                                    Amount = 0,
                                    BillingCountryCode = "billingCountryCode",
                                    Currency = SubscriptionPriceTierFlatPriceCurrency.Usd,
                                },
                                UnitPrice = new()
                                {
                                    Amount = 0,
                                    BillingCountryCode = "billingCountryCode",
                                    Currency = SubscriptionPriceTierUnitPriceCurrency.Usd,
                                },
                                UpTo = 0,
                            },
                        ],
                    },
                ],
                ResourceID = "resourceId",
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UnitQuantity = 1,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Data
        {
            ID = "id",
            Entitlements =
            [
                new()
                {
                    AccessDeniedReason = "accessDeniedReason",
                    CurrentUsage = 0,
                    EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Feature = new("refId"),
                    HasUnlimitedUsage = true,
                    IsGranted = true,
                    ResetPeriod = ResetPeriod.Year,
                    UsageLimit = 0,
                    UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Status = Status.Success,
            IsScheduled = true,
            Subscription = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customerId",
                PaymentCollection = PaymentCollection.NotRequired,
                PlanID = "planId",
                PricingType = PricingType.Free,
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = SubscriptionStatus.PaymentPending,
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason = CancelReason.UpgradeOrDowngrade,
                CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod = SubscriptionPaymentCollectionMethod.Charge,
                Prices =
                [
                    new()
                    {
                        AddonID = "addonId",
                        BaseCharge = true,
                        BlockSize = 0,
                        FeatureID = "featureId",
                        Price = new()
                        {
                            Amount = 0,
                            BillingCountryCode = "billingCountryCode",
                            Currency = SubscriptionPricePriceCurrency.Usd,
                        },
                        Tiers =
                        [
                            new()
                            {
                                FlatPrice = new()
                                {
                                    Amount = 0,
                                    BillingCountryCode = "billingCountryCode",
                                    Currency = SubscriptionPriceTierFlatPriceCurrency.Usd,
                                },
                                UnitPrice = new()
                                {
                                    Amount = 0,
                                    BillingCountryCode = "billingCountryCode",
                                    Currency = SubscriptionPriceTierUnitPriceCurrency.Usd,
                                },
                                UpTo = 0,
                            },
                        ],
                    },
                ],
                ResourceID = "resourceId",
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UnitQuantity = 1,
            },

            CheckoutBillingID = null,
            CheckoutUrl = null,
        };

        Assert.Null(model.CheckoutBillingID);
        Assert.True(model.RawData.ContainsKey("checkoutBillingId"));
        Assert.Null(model.CheckoutUrl);
        Assert.True(model.RawData.ContainsKey("checkoutUrl"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Data
        {
            ID = "id",
            Entitlements =
            [
                new()
                {
                    AccessDeniedReason = "accessDeniedReason",
                    CurrentUsage = 0,
                    EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Feature = new("refId"),
                    HasUnlimitedUsage = true,
                    IsGranted = true,
                    ResetPeriod = ResetPeriod.Year,
                    UsageLimit = 0,
                    UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Status = Status.Success,
            IsScheduled = true,
            Subscription = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customerId",
                PaymentCollection = PaymentCollection.NotRequired,
                PlanID = "planId",
                PricingType = PricingType.Free,
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = SubscriptionStatus.PaymentPending,
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason = CancelReason.UpgradeOrDowngrade,
                CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod = SubscriptionPaymentCollectionMethod.Charge,
                Prices =
                [
                    new()
                    {
                        AddonID = "addonId",
                        BaseCharge = true,
                        BlockSize = 0,
                        FeatureID = "featureId",
                        Price = new()
                        {
                            Amount = 0,
                            BillingCountryCode = "billingCountryCode",
                            Currency = SubscriptionPricePriceCurrency.Usd,
                        },
                        Tiers =
                        [
                            new()
                            {
                                FlatPrice = new()
                                {
                                    Amount = 0,
                                    BillingCountryCode = "billingCountryCode",
                                    Currency = SubscriptionPriceTierFlatPriceCurrency.Usd,
                                },
                                UnitPrice = new()
                                {
                                    Amount = 0,
                                    BillingCountryCode = "billingCountryCode",
                                    Currency = SubscriptionPriceTierUnitPriceCurrency.Usd,
                                },
                                UpTo = 0,
                            },
                        ],
                    },
                ],
                ResourceID = "resourceId",
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UnitQuantity = 1,
            },

            CheckoutBillingID = null,
            CheckoutUrl = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Data
        {
            ID = "id",
            Entitlements =
            [
                new()
                {
                    AccessDeniedReason = "accessDeniedReason",
                    CurrentUsage = 0,
                    EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Feature = new("refId"),
                    HasUnlimitedUsage = true,
                    IsGranted = true,
                    ResetPeriod = ResetPeriod.Year,
                    UsageLimit = 0,
                    UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Status = Status.Success,
            CheckoutBillingID = "checkoutBillingId",
            CheckoutUrl = "checkoutUrl",
            IsScheduled = true,
            Subscription = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customerId",
                PaymentCollection = PaymentCollection.NotRequired,
                PlanID = "planId",
                PricingType = PricingType.Free,
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = SubscriptionStatus.PaymentPending,
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason = CancelReason.UpgradeOrDowngrade,
                CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod = SubscriptionPaymentCollectionMethod.Charge,
                Prices =
                [
                    new()
                    {
                        AddonID = "addonId",
                        BaseCharge = true,
                        BlockSize = 0,
                        FeatureID = "featureId",
                        Price = new()
                        {
                            Amount = 0,
                            BillingCountryCode = "billingCountryCode",
                            Currency = SubscriptionPricePriceCurrency.Usd,
                        },
                        Tiers =
                        [
                            new()
                            {
                                FlatPrice = new()
                                {
                                    Amount = 0,
                                    BillingCountryCode = "billingCountryCode",
                                    Currency = SubscriptionPriceTierFlatPriceCurrency.Usd,
                                },
                                UnitPrice = new()
                                {
                                    Amount = 0,
                                    BillingCountryCode = "billingCountryCode",
                                    Currency = SubscriptionPriceTierUnitPriceCurrency.Usd,
                                },
                                UpTo = 0,
                            },
                        ],
                    },
                ],
                ResourceID = "resourceId",
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UnitQuantity = 1,
            },
        };

        Data copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntitlementTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Entitlement
        {
            AccessDeniedReason = "accessDeniedReason",
            CurrentUsage = 0,
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Feature = new("refId"),
            HasUnlimitedUsage = true,
            IsGranted = true,
            ResetPeriod = ResetPeriod.Year,
            UsageLimit = 0,
            UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedAccessDeniedReason = "accessDeniedReason";
        double expectedCurrentUsage = 0;
        DateTimeOffset expectedEntitlementUpdatedAt = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        Feature expectedFeature = new("refId");
        bool expectedHasUnlimitedUsage = true;
        bool expectedIsGranted = true;
        ApiEnum<string, ResetPeriod> expectedResetPeriod = ResetPeriod.Year;
        double expectedUsageLimit = 0;
        DateTimeOffset expectedUsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedUsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedUsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedAccessDeniedReason, model.AccessDeniedReason);
        Assert.Equal(expectedCurrentUsage, model.CurrentUsage);
        Assert.Equal(expectedEntitlementUpdatedAt, model.EntitlementUpdatedAt);
        Assert.Equal(expectedFeature, model.Feature);
        Assert.Equal(expectedHasUnlimitedUsage, model.HasUnlimitedUsage);
        Assert.Equal(expectedIsGranted, model.IsGranted);
        Assert.Equal(expectedResetPeriod, model.ResetPeriod);
        Assert.Equal(expectedUsageLimit, model.UsageLimit);
        Assert.Equal(expectedUsagePeriodAnchor, model.UsagePeriodAnchor);
        Assert.Equal(expectedUsagePeriodEnd, model.UsagePeriodEnd);
        Assert.Equal(expectedUsagePeriodStart, model.UsagePeriodStart);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Entitlement
        {
            AccessDeniedReason = "accessDeniedReason",
            CurrentUsage = 0,
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Feature = new("refId"),
            HasUnlimitedUsage = true,
            IsGranted = true,
            ResetPeriod = ResetPeriod.Year,
            UsageLimit = 0,
            UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entitlement>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Entitlement
        {
            AccessDeniedReason = "accessDeniedReason",
            CurrentUsage = 0,
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Feature = new("refId"),
            HasUnlimitedUsage = true,
            IsGranted = true,
            ResetPeriod = ResetPeriod.Year,
            UsageLimit = 0,
            UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entitlement>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAccessDeniedReason = "accessDeniedReason";
        double expectedCurrentUsage = 0;
        DateTimeOffset expectedEntitlementUpdatedAt = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        Feature expectedFeature = new("refId");
        bool expectedHasUnlimitedUsage = true;
        bool expectedIsGranted = true;
        ApiEnum<string, ResetPeriod> expectedResetPeriod = ResetPeriod.Year;
        double expectedUsageLimit = 0;
        DateTimeOffset expectedUsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedUsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedUsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedAccessDeniedReason, deserialized.AccessDeniedReason);
        Assert.Equal(expectedCurrentUsage, deserialized.CurrentUsage);
        Assert.Equal(expectedEntitlementUpdatedAt, deserialized.EntitlementUpdatedAt);
        Assert.Equal(expectedFeature, deserialized.Feature);
        Assert.Equal(expectedHasUnlimitedUsage, deserialized.HasUnlimitedUsage);
        Assert.Equal(expectedIsGranted, deserialized.IsGranted);
        Assert.Equal(expectedResetPeriod, deserialized.ResetPeriod);
        Assert.Equal(expectedUsageLimit, deserialized.UsageLimit);
        Assert.Equal(expectedUsagePeriodAnchor, deserialized.UsagePeriodAnchor);
        Assert.Equal(expectedUsagePeriodEnd, deserialized.UsagePeriodEnd);
        Assert.Equal(expectedUsagePeriodStart, deserialized.UsagePeriodStart);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Entitlement
        {
            AccessDeniedReason = "accessDeniedReason",
            CurrentUsage = 0,
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Feature = new("refId"),
            HasUnlimitedUsage = true,
            IsGranted = true,
            ResetPeriod = ResetPeriod.Year,
            UsageLimit = 0,
            UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Entitlement
        {
            AccessDeniedReason = "accessDeniedReason",
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Feature = new("refId"),
            HasUnlimitedUsage = true,
            ResetPeriod = ResetPeriod.Year,
            UsageLimit = 0,
            UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.CurrentUsage);
        Assert.False(model.RawData.ContainsKey("currentUsage"));
        Assert.Null(model.IsGranted);
        Assert.False(model.RawData.ContainsKey("isGranted"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Entitlement
        {
            AccessDeniedReason = "accessDeniedReason",
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Feature = new("refId"),
            HasUnlimitedUsage = true,
            ResetPeriod = ResetPeriod.Year,
            UsageLimit = 0,
            UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Entitlement
        {
            AccessDeniedReason = "accessDeniedReason",
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Feature = new("refId"),
            HasUnlimitedUsage = true,
            ResetPeriod = ResetPeriod.Year,
            UsageLimit = 0,
            UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            CurrentUsage = null,
            IsGranted = null,
        };

        Assert.Null(model.CurrentUsage);
        Assert.False(model.RawData.ContainsKey("currentUsage"));
        Assert.Null(model.IsGranted);
        Assert.False(model.RawData.ContainsKey("isGranted"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Entitlement
        {
            AccessDeniedReason = "accessDeniedReason",
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Feature = new("refId"),
            HasUnlimitedUsage = true,
            ResetPeriod = ResetPeriod.Year,
            UsageLimit = 0,
            UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            CurrentUsage = null,
            IsGranted = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Entitlement { CurrentUsage = 0, IsGranted = true };

        Assert.Null(model.AccessDeniedReason);
        Assert.False(model.RawData.ContainsKey("accessDeniedReason"));
        Assert.Null(model.EntitlementUpdatedAt);
        Assert.False(model.RawData.ContainsKey("entitlementUpdatedAt"));
        Assert.Null(model.Feature);
        Assert.False(model.RawData.ContainsKey("feature"));
        Assert.Null(model.HasUnlimitedUsage);
        Assert.False(model.RawData.ContainsKey("hasUnlimitedUsage"));
        Assert.Null(model.ResetPeriod);
        Assert.False(model.RawData.ContainsKey("resetPeriod"));
        Assert.Null(model.UsageLimit);
        Assert.False(model.RawData.ContainsKey("usageLimit"));
        Assert.Null(model.UsagePeriodAnchor);
        Assert.False(model.RawData.ContainsKey("usagePeriodAnchor"));
        Assert.Null(model.UsagePeriodEnd);
        Assert.False(model.RawData.ContainsKey("usagePeriodEnd"));
        Assert.Null(model.UsagePeriodStart);
        Assert.False(model.RawData.ContainsKey("usagePeriodStart"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Entitlement { CurrentUsage = 0, IsGranted = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Entitlement
        {
            CurrentUsage = 0,
            IsGranted = true,

            AccessDeniedReason = null,
            EntitlementUpdatedAt = null,
            Feature = null,
            HasUnlimitedUsage = null,
            ResetPeriod = null,
            UsageLimit = null,
            UsagePeriodAnchor = null,
            UsagePeriodEnd = null,
            UsagePeriodStart = null,
        };

        Assert.Null(model.AccessDeniedReason);
        Assert.True(model.RawData.ContainsKey("accessDeniedReason"));
        Assert.Null(model.EntitlementUpdatedAt);
        Assert.True(model.RawData.ContainsKey("entitlementUpdatedAt"));
        Assert.Null(model.Feature);
        Assert.True(model.RawData.ContainsKey("feature"));
        Assert.Null(model.HasUnlimitedUsage);
        Assert.True(model.RawData.ContainsKey("hasUnlimitedUsage"));
        Assert.Null(model.ResetPeriod);
        Assert.True(model.RawData.ContainsKey("resetPeriod"));
        Assert.Null(model.UsageLimit);
        Assert.True(model.RawData.ContainsKey("usageLimit"));
        Assert.Null(model.UsagePeriodAnchor);
        Assert.True(model.RawData.ContainsKey("usagePeriodAnchor"));
        Assert.Null(model.UsagePeriodEnd);
        Assert.True(model.RawData.ContainsKey("usagePeriodEnd"));
        Assert.Null(model.UsagePeriodStart);
        Assert.True(model.RawData.ContainsKey("usagePeriodStart"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Entitlement
        {
            CurrentUsage = 0,
            IsGranted = true,

            AccessDeniedReason = null,
            EntitlementUpdatedAt = null,
            Feature = null,
            HasUnlimitedUsage = null,
            ResetPeriod = null,
            UsageLimit = null,
            UsagePeriodAnchor = null,
            UsagePeriodEnd = null,
            UsagePeriodStart = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Entitlement
        {
            AccessDeniedReason = "accessDeniedReason",
            CurrentUsage = 0,
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Feature = new("refId"),
            HasUnlimitedUsage = true,
            IsGranted = true,
            ResetPeriod = ResetPeriod.Year,
            UsageLimit = 0,
            UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Entitlement copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FeatureTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Feature { RefID = "refId" };

        string expectedRefID = "refId";

        Assert.Equal(expectedRefID, model.RefID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Feature { RefID = "refId" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Feature>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Feature { RefID = "refId" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Feature>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedRefID = "refId";

        Assert.Equal(expectedRefID, deserialized.RefID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Feature { RefID = "refId" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Feature { RefID = "refId" };

        Feature copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ResetPeriodTest : TestBase
{
    [Theory]
    [InlineData(ResetPeriod.Year)]
    [InlineData(ResetPeriod.Month)]
    [InlineData(ResetPeriod.Week)]
    [InlineData(ResetPeriod.Day)]
    [InlineData(ResetPeriod.Hour)]
    public void Validation_Works(ResetPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ResetPeriod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ResetPeriod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ResetPeriod.Year)]
    [InlineData(ResetPeriod.Month)]
    [InlineData(ResetPeriod.Week)]
    [InlineData(ResetPeriod.Day)]
    [InlineData(ResetPeriod.Hour)]
    public void SerializationRoundtrip_Works(ResetPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ResetPeriod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ResetPeriod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ResetPeriod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ResetPeriod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Success)]
    [InlineData(Status.PaymentRequired)]
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
    [InlineData(Status.Success)]
    [InlineData(Status.PaymentRequired)]
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

public class SubscriptionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscription
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = PaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = PricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionStatus.PaymentPending,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = CancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod = SubscriptionPaymentCollectionMethod.Charge,
            Prices =
            [
                new()
                {
                    AddonID = "addonId",
                    BaseCharge = true,
                    BlockSize = 0,
                    FeatureID = "featureId",
                    Price = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
                        Currency = SubscriptionPricePriceCurrency.Usd,
                    },
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                BillingCountryCode = "billingCountryCode",
                                Currency = SubscriptionPriceTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                BillingCountryCode = "billingCountryCode",
                                Currency = SubscriptionPriceTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            ResourceID = "resourceId",
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UnitQuantity = 1,
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
        ApiEnum<string, SubscriptionStatus> expectedStatus = SubscriptionStatus.PaymentPending;
        DateTimeOffset expectedCancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, CancelReason> expectedCancelReason = CancelReason.UpgradeOrDowngrade;
        DateTimeOffset expectedCurrentBillingPeriodEnd = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        DateTimeOffset expectedCurrentBillingPeriodStart = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        DateTimeOffset expectedEffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedPayingCustomerID = "payingCustomerId";
        ApiEnum<string, SubscriptionPaymentCollectionMethod> expectedPaymentCollectionMethod =
            SubscriptionPaymentCollectionMethod.Charge;
        List<SubscriptionPrice> expectedPrices =
        [
            new()
            {
                AddonID = "addonId",
                BaseCharge = true,
                BlockSize = 0,
                FeatureID = "featureId",
                Price = new()
                {
                    Amount = 0,
                    BillingCountryCode = "billingCountryCode",
                    Currency = SubscriptionPricePriceCurrency.Usd,
                },
                Tiers =
                [
                    new()
                    {
                        FlatPrice = new()
                        {
                            Amount = 0,
                            BillingCountryCode = "billingCountryCode",
                            Currency = SubscriptionPriceTierFlatPriceCurrency.Usd,
                        },
                        UnitPrice = new()
                        {
                            Amount = 0,
                            BillingCountryCode = "billingCountryCode",
                            Currency = SubscriptionPriceTierUnitPriceCurrency.Usd,
                        },
                        UpTo = 0,
                    },
                ],
            },
        ];
        string expectedResourceID = "resourceId";
        DateTimeOffset expectedTrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        double expectedUnitQuantity = 1;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBillingID, model.BillingID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCustomerID, model.CustomerID);
        Assert.Equal(expectedPaymentCollection, model.PaymentCollection);
        Assert.Equal(expectedPlanID, model.PlanID);
        Assert.Equal(expectedPricingType, model.PricingType);
        Assert.Equal(expectedStartDate, model.StartDate);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedCancellationDate, model.CancellationDate);
        Assert.Equal(expectedCancelReason, model.CancelReason);
        Assert.Equal(expectedCurrentBillingPeriodEnd, model.CurrentBillingPeriodEnd);
        Assert.Equal(expectedCurrentBillingPeriodStart, model.CurrentBillingPeriodStart);
        Assert.Equal(expectedEffectiveEndDate, model.EffectiveEndDate);
        Assert.Equal(expectedEndDate, model.EndDate);
        Assert.NotNull(model.Metadata);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedPayingCustomerID, model.PayingCustomerID);
        Assert.Equal(expectedPaymentCollectionMethod, model.PaymentCollectionMethod);
        Assert.NotNull(model.Prices);
        Assert.Equal(expectedPrices.Count, model.Prices.Count);
        for (int i = 0; i < expectedPrices.Count; i++)
        {
            Assert.Equal(expectedPrices[i], model.Prices[i]);
        }
        Assert.Equal(expectedResourceID, model.ResourceID);
        Assert.Equal(expectedTrialEndDate, model.TrialEndDate);
        Assert.Equal(expectedUnitQuantity, model.UnitQuantity);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscription
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = PaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = PricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionStatus.PaymentPending,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = CancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod = SubscriptionPaymentCollectionMethod.Charge,
            Prices =
            [
                new()
                {
                    AddonID = "addonId",
                    BaseCharge = true,
                    BlockSize = 0,
                    FeatureID = "featureId",
                    Price = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
                        Currency = SubscriptionPricePriceCurrency.Usd,
                    },
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                BillingCountryCode = "billingCountryCode",
                                Currency = SubscriptionPriceTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                BillingCountryCode = "billingCountryCode",
                                Currency = SubscriptionPriceTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            ResourceID = "resourceId",
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UnitQuantity = 1,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscription>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscription
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = PaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = PricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionStatus.PaymentPending,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = CancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod = SubscriptionPaymentCollectionMethod.Charge,
            Prices =
            [
                new()
                {
                    AddonID = "addonId",
                    BaseCharge = true,
                    BlockSize = 0,
                    FeatureID = "featureId",
                    Price = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
                        Currency = SubscriptionPricePriceCurrency.Usd,
                    },
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                BillingCountryCode = "billingCountryCode",
                                Currency = SubscriptionPriceTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                BillingCountryCode = "billingCountryCode",
                                Currency = SubscriptionPriceTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            ResourceID = "resourceId",
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UnitQuantity = 1,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscription>(
            element,
            ModelBase.SerializerOptions
        );
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
        ApiEnum<string, SubscriptionStatus> expectedStatus = SubscriptionStatus.PaymentPending;
        DateTimeOffset expectedCancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, CancelReason> expectedCancelReason = CancelReason.UpgradeOrDowngrade;
        DateTimeOffset expectedCurrentBillingPeriodEnd = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        DateTimeOffset expectedCurrentBillingPeriodStart = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        DateTimeOffset expectedEffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedPayingCustomerID = "payingCustomerId";
        ApiEnum<string, SubscriptionPaymentCollectionMethod> expectedPaymentCollectionMethod =
            SubscriptionPaymentCollectionMethod.Charge;
        List<SubscriptionPrice> expectedPrices =
        [
            new()
            {
                AddonID = "addonId",
                BaseCharge = true,
                BlockSize = 0,
                FeatureID = "featureId",
                Price = new()
                {
                    Amount = 0,
                    BillingCountryCode = "billingCountryCode",
                    Currency = SubscriptionPricePriceCurrency.Usd,
                },
                Tiers =
                [
                    new()
                    {
                        FlatPrice = new()
                        {
                            Amount = 0,
                            BillingCountryCode = "billingCountryCode",
                            Currency = SubscriptionPriceTierFlatPriceCurrency.Usd,
                        },
                        UnitPrice = new()
                        {
                            Amount = 0,
                            BillingCountryCode = "billingCountryCode",
                            Currency = SubscriptionPriceTierUnitPriceCurrency.Usd,
                        },
                        UpTo = 0,
                    },
                ],
            },
        ];
        string expectedResourceID = "resourceId";
        DateTimeOffset expectedTrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        double expectedUnitQuantity = 1;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedBillingID, deserialized.BillingID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCustomerID, deserialized.CustomerID);
        Assert.Equal(expectedPaymentCollection, deserialized.PaymentCollection);
        Assert.Equal(expectedPlanID, deserialized.PlanID);
        Assert.Equal(expectedPricingType, deserialized.PricingType);
        Assert.Equal(expectedStartDate, deserialized.StartDate);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedCancellationDate, deserialized.CancellationDate);
        Assert.Equal(expectedCancelReason, deserialized.CancelReason);
        Assert.Equal(expectedCurrentBillingPeriodEnd, deserialized.CurrentBillingPeriodEnd);
        Assert.Equal(expectedCurrentBillingPeriodStart, deserialized.CurrentBillingPeriodStart);
        Assert.Equal(expectedEffectiveEndDate, deserialized.EffectiveEndDate);
        Assert.Equal(expectedEndDate, deserialized.EndDate);
        Assert.NotNull(deserialized.Metadata);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedPayingCustomerID, deserialized.PayingCustomerID);
        Assert.Equal(expectedPaymentCollectionMethod, deserialized.PaymentCollectionMethod);
        Assert.NotNull(deserialized.Prices);
        Assert.Equal(expectedPrices.Count, deserialized.Prices.Count);
        for (int i = 0; i < expectedPrices.Count; i++)
        {
            Assert.Equal(expectedPrices[i], deserialized.Prices[i]);
        }
        Assert.Equal(expectedResourceID, deserialized.ResourceID);
        Assert.Equal(expectedTrialEndDate, deserialized.TrialEndDate);
        Assert.Equal(expectedUnitQuantity, deserialized.UnitQuantity);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Subscription
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = PaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = PricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionStatus.PaymentPending,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = CancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod = SubscriptionPaymentCollectionMethod.Charge,
            Prices =
            [
                new()
                {
                    AddonID = "addonId",
                    BaseCharge = true,
                    BlockSize = 0,
                    FeatureID = "featureId",
                    Price = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
                        Currency = SubscriptionPricePriceCurrency.Usd,
                    },
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                BillingCountryCode = "billingCountryCode",
                                Currency = SubscriptionPriceTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                BillingCountryCode = "billingCountryCode",
                                Currency = SubscriptionPriceTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            ResourceID = "resourceId",
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UnitQuantity = 1,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Subscription
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = PaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = PricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionStatus.PaymentPending,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = CancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod = SubscriptionPaymentCollectionMethod.Charge,
            ResourceID = "resourceId",
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.Prices);
        Assert.False(model.RawData.ContainsKey("prices"));
        Assert.Null(model.UnitQuantity);
        Assert.False(model.RawData.ContainsKey("unitQuantity"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Subscription
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = PaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = PricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionStatus.PaymentPending,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = CancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod = SubscriptionPaymentCollectionMethod.Charge,
            ResourceID = "resourceId",
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Subscription
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = PaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = PricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionStatus.PaymentPending,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = CancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod = SubscriptionPaymentCollectionMethod.Charge,
            ResourceID = "resourceId",
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            Metadata = null,
            Prices = null,
            UnitQuantity = null,
        };

        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.Prices);
        Assert.False(model.RawData.ContainsKey("prices"));
        Assert.Null(model.UnitQuantity);
        Assert.False(model.RawData.ContainsKey("unitQuantity"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Subscription
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = PaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = PricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionStatus.PaymentPending,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = CancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod = SubscriptionPaymentCollectionMethod.Charge,
            ResourceID = "resourceId",
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            Metadata = null,
            Prices = null,
            UnitQuantity = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Subscription
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = PaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = PricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionStatus.PaymentPending,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Prices =
            [
                new()
                {
                    AddonID = "addonId",
                    BaseCharge = true,
                    BlockSize = 0,
                    FeatureID = "featureId",
                    Price = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
                        Currency = SubscriptionPricePriceCurrency.Usd,
                    },
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                BillingCountryCode = "billingCountryCode",
                                Currency = SubscriptionPriceTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                BillingCountryCode = "billingCountryCode",
                                Currency = SubscriptionPriceTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            UnitQuantity = 1,
        };

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
        Assert.Null(model.PayingCustomerID);
        Assert.False(model.RawData.ContainsKey("payingCustomerId"));
        Assert.Null(model.PaymentCollectionMethod);
        Assert.False(model.RawData.ContainsKey("paymentCollectionMethod"));
        Assert.Null(model.ResourceID);
        Assert.False(model.RawData.ContainsKey("resourceId"));
        Assert.Null(model.TrialEndDate);
        Assert.False(model.RawData.ContainsKey("trialEndDate"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Subscription
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = PaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = PricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionStatus.PaymentPending,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Prices =
            [
                new()
                {
                    AddonID = "addonId",
                    BaseCharge = true,
                    BlockSize = 0,
                    FeatureID = "featureId",
                    Price = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
                        Currency = SubscriptionPricePriceCurrency.Usd,
                    },
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                BillingCountryCode = "billingCountryCode",
                                Currency = SubscriptionPriceTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                BillingCountryCode = "billingCountryCode",
                                Currency = SubscriptionPriceTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            UnitQuantity = 1,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Subscription
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = PaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = PricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionStatus.PaymentPending,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Prices =
            [
                new()
                {
                    AddonID = "addonId",
                    BaseCharge = true,
                    BlockSize = 0,
                    FeatureID = "featureId",
                    Price = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
                        Currency = SubscriptionPricePriceCurrency.Usd,
                    },
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                BillingCountryCode = "billingCountryCode",
                                Currency = SubscriptionPriceTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                BillingCountryCode = "billingCountryCode",
                                Currency = SubscriptionPriceTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            UnitQuantity = 1,

            CancellationDate = null,
            CancelReason = null,
            CurrentBillingPeriodEnd = null,
            CurrentBillingPeriodStart = null,
            EffectiveEndDate = null,
            EndDate = null,
            PayingCustomerID = null,
            PaymentCollectionMethod = null,
            ResourceID = null,
            TrialEndDate = null,
        };

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
        Assert.Null(model.PayingCustomerID);
        Assert.True(model.RawData.ContainsKey("payingCustomerId"));
        Assert.Null(model.PaymentCollectionMethod);
        Assert.True(model.RawData.ContainsKey("paymentCollectionMethod"));
        Assert.Null(model.ResourceID);
        Assert.True(model.RawData.ContainsKey("resourceId"));
        Assert.Null(model.TrialEndDate);
        Assert.True(model.RawData.ContainsKey("trialEndDate"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Subscription
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = PaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = PricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionStatus.PaymentPending,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Prices =
            [
                new()
                {
                    AddonID = "addonId",
                    BaseCharge = true,
                    BlockSize = 0,
                    FeatureID = "featureId",
                    Price = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
                        Currency = SubscriptionPricePriceCurrency.Usd,
                    },
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                BillingCountryCode = "billingCountryCode",
                                Currency = SubscriptionPriceTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                BillingCountryCode = "billingCountryCode",
                                Currency = SubscriptionPriceTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            UnitQuantity = 1,

            CancellationDate = null,
            CancelReason = null,
            CurrentBillingPeriodEnd = null,
            CurrentBillingPeriodStart = null,
            EffectiveEndDate = null,
            EndDate = null,
            PayingCustomerID = null,
            PaymentCollectionMethod = null,
            ResourceID = null,
            TrialEndDate = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Subscription
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = PaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = PricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionStatus.PaymentPending,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = CancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod = SubscriptionPaymentCollectionMethod.Charge,
            Prices =
            [
                new()
                {
                    AddonID = "addonId",
                    BaseCharge = true,
                    BlockSize = 0,
                    FeatureID = "featureId",
                    Price = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
                        Currency = SubscriptionPricePriceCurrency.Usd,
                    },
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                BillingCountryCode = "billingCountryCode",
                                Currency = SubscriptionPriceTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                BillingCountryCode = "billingCountryCode",
                                Currency = SubscriptionPriceTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            ResourceID = "resourceId",
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UnitQuantity = 1,
        };

        Subscription copied = new(model);

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

public class SubscriptionStatusTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionStatus.PaymentPending)]
    [InlineData(SubscriptionStatus.Active)]
    [InlineData(SubscriptionStatus.Expired)]
    [InlineData(SubscriptionStatus.InTrial)]
    [InlineData(SubscriptionStatus.Canceled)]
    [InlineData(SubscriptionStatus.NotStarted)]
    public void Validation_Works(SubscriptionStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SubscriptionStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionStatus.PaymentPending)]
    [InlineData(SubscriptionStatus.Active)]
    [InlineData(SubscriptionStatus.Expired)]
    [InlineData(SubscriptionStatus.InTrial)]
    [InlineData(SubscriptionStatus.Canceled)]
    [InlineData(SubscriptionStatus.NotStarted)]
    public void SerializationRoundtrip_Works(SubscriptionStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SubscriptionStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SubscriptionStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SubscriptionStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
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

public class SubscriptionPaymentCollectionMethodTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionPaymentCollectionMethod.Charge)]
    [InlineData(SubscriptionPaymentCollectionMethod.Invoice)]
    [InlineData(SubscriptionPaymentCollectionMethod.None)]
    public void Validation_Works(SubscriptionPaymentCollectionMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionPaymentCollectionMethod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionPaymentCollectionMethod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionPaymentCollectionMethod.Charge)]
    [InlineData(SubscriptionPaymentCollectionMethod.Invoice)]
    [InlineData(SubscriptionPaymentCollectionMethod.None)]
    public void SerializationRoundtrip_Works(SubscriptionPaymentCollectionMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionPaymentCollectionMethod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionPaymentCollectionMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionPaymentCollectionMethod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionPaymentCollectionMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionPriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionPrice
        {
            AddonID = "addonId",
            BaseCharge = true,
            BlockSize = 0,
            FeatureID = "featureId",
            Price = new()
            {
                Amount = 0,
                BillingCountryCode = "billingCountryCode",
                Currency = SubscriptionPricePriceCurrency.Usd,
            },
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
                        Currency = SubscriptionPriceTierFlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
                        Currency = SubscriptionPriceTierUnitPriceCurrency.Usd,
                    },
                    UpTo = 0,
                },
            ],
        };

        string expectedAddonID = "addonId";
        bool expectedBaseCharge = true;
        double expectedBlockSize = 0;
        string expectedFeatureID = "featureId";
        SubscriptionPricePrice expectedPrice = new()
        {
            Amount = 0,
            BillingCountryCode = "billingCountryCode",
            Currency = SubscriptionPricePriceCurrency.Usd,
        };
        List<SubscriptionPriceTier> expectedTiers =
        [
            new()
            {
                FlatPrice = new()
                {
                    Amount = 0,
                    BillingCountryCode = "billingCountryCode",
                    Currency = SubscriptionPriceTierFlatPriceCurrency.Usd,
                },
                UnitPrice = new()
                {
                    Amount = 0,
                    BillingCountryCode = "billingCountryCode",
                    Currency = SubscriptionPriceTierUnitPriceCurrency.Usd,
                },
                UpTo = 0,
            },
        ];

        Assert.Equal(expectedAddonID, model.AddonID);
        Assert.Equal(expectedBaseCharge, model.BaseCharge);
        Assert.Equal(expectedBlockSize, model.BlockSize);
        Assert.Equal(expectedFeatureID, model.FeatureID);
        Assert.Equal(expectedPrice, model.Price);
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
        var model = new SubscriptionPrice
        {
            AddonID = "addonId",
            BaseCharge = true,
            BlockSize = 0,
            FeatureID = "featureId",
            Price = new()
            {
                Amount = 0,
                BillingCountryCode = "billingCountryCode",
                Currency = SubscriptionPricePriceCurrency.Usd,
            },
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
                        Currency = SubscriptionPriceTierFlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
                        Currency = SubscriptionPriceTierUnitPriceCurrency.Usd,
                    },
                    UpTo = 0,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionPrice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionPrice
        {
            AddonID = "addonId",
            BaseCharge = true,
            BlockSize = 0,
            FeatureID = "featureId",
            Price = new()
            {
                Amount = 0,
                BillingCountryCode = "billingCountryCode",
                Currency = SubscriptionPricePriceCurrency.Usd,
            },
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
                        Currency = SubscriptionPriceTierFlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
                        Currency = SubscriptionPriceTierUnitPriceCurrency.Usd,
                    },
                    UpTo = 0,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionPrice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAddonID = "addonId";
        bool expectedBaseCharge = true;
        double expectedBlockSize = 0;
        string expectedFeatureID = "featureId";
        SubscriptionPricePrice expectedPrice = new()
        {
            Amount = 0,
            BillingCountryCode = "billingCountryCode",
            Currency = SubscriptionPricePriceCurrency.Usd,
        };
        List<SubscriptionPriceTier> expectedTiers =
        [
            new()
            {
                FlatPrice = new()
                {
                    Amount = 0,
                    BillingCountryCode = "billingCountryCode",
                    Currency = SubscriptionPriceTierFlatPriceCurrency.Usd,
                },
                UnitPrice = new()
                {
                    Amount = 0,
                    BillingCountryCode = "billingCountryCode",
                    Currency = SubscriptionPriceTierUnitPriceCurrency.Usd,
                },
                UpTo = 0,
            },
        ];

        Assert.Equal(expectedAddonID, deserialized.AddonID);
        Assert.Equal(expectedBaseCharge, deserialized.BaseCharge);
        Assert.Equal(expectedBlockSize, deserialized.BlockSize);
        Assert.Equal(expectedFeatureID, deserialized.FeatureID);
        Assert.Equal(expectedPrice, deserialized.Price);
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
        var model = new SubscriptionPrice
        {
            AddonID = "addonId",
            BaseCharge = true,
            BlockSize = 0,
            FeatureID = "featureId",
            Price = new()
            {
                Amount = 0,
                BillingCountryCode = "billingCountryCode",
                Currency = SubscriptionPricePriceCurrency.Usd,
            },
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
                        Currency = SubscriptionPriceTierFlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
                        Currency = SubscriptionPriceTierUnitPriceCurrency.Usd,
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
        var model = new SubscriptionPrice { AddonID = "addonId", FeatureID = "featureId" };

        Assert.Null(model.BaseCharge);
        Assert.False(model.RawData.ContainsKey("baseCharge"));
        Assert.Null(model.BlockSize);
        Assert.False(model.RawData.ContainsKey("blockSize"));
        Assert.Null(model.Price);
        Assert.False(model.RawData.ContainsKey("price"));
        Assert.Null(model.Tiers);
        Assert.False(model.RawData.ContainsKey("tiers"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SubscriptionPrice { AddonID = "addonId", FeatureID = "featureId" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SubscriptionPrice
        {
            AddonID = "addonId",
            FeatureID = "featureId",

            // Null should be interpreted as omitted for these properties
            BaseCharge = null,
            BlockSize = null,
            Price = null,
            Tiers = null,
        };

        Assert.Null(model.BaseCharge);
        Assert.False(model.RawData.ContainsKey("baseCharge"));
        Assert.Null(model.BlockSize);
        Assert.False(model.RawData.ContainsKey("blockSize"));
        Assert.Null(model.Price);
        Assert.False(model.RawData.ContainsKey("price"));
        Assert.Null(model.Tiers);
        Assert.False(model.RawData.ContainsKey("tiers"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SubscriptionPrice
        {
            AddonID = "addonId",
            FeatureID = "featureId",

            // Null should be interpreted as omitted for these properties
            BaseCharge = null,
            BlockSize = null,
            Price = null,
            Tiers = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubscriptionPrice
        {
            BaseCharge = true,
            BlockSize = 0,
            Price = new()
            {
                Amount = 0,
                BillingCountryCode = "billingCountryCode",
                Currency = SubscriptionPricePriceCurrency.Usd,
            },
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
                        Currency = SubscriptionPriceTierFlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
                        Currency = SubscriptionPriceTierUnitPriceCurrency.Usd,
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
        var model = new SubscriptionPrice
        {
            BaseCharge = true,
            BlockSize = 0,
            Price = new()
            {
                Amount = 0,
                BillingCountryCode = "billingCountryCode",
                Currency = SubscriptionPricePriceCurrency.Usd,
            },
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
                        Currency = SubscriptionPriceTierFlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
                        Currency = SubscriptionPriceTierUnitPriceCurrency.Usd,
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
        var model = new SubscriptionPrice
        {
            BaseCharge = true,
            BlockSize = 0,
            Price = new()
            {
                Amount = 0,
                BillingCountryCode = "billingCountryCode",
                Currency = SubscriptionPricePriceCurrency.Usd,
            },
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
                        Currency = SubscriptionPriceTierFlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
                        Currency = SubscriptionPriceTierUnitPriceCurrency.Usd,
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
        var model = new SubscriptionPrice
        {
            BaseCharge = true,
            BlockSize = 0,
            Price = new()
            {
                Amount = 0,
                BillingCountryCode = "billingCountryCode",
                Currency = SubscriptionPricePriceCurrency.Usd,
            },
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
                        Currency = SubscriptionPriceTierFlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
                        Currency = SubscriptionPriceTierUnitPriceCurrency.Usd,
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
        var model = new SubscriptionPrice
        {
            AddonID = "addonId",
            BaseCharge = true,
            BlockSize = 0,
            FeatureID = "featureId",
            Price = new()
            {
                Amount = 0,
                BillingCountryCode = "billingCountryCode",
                Currency = SubscriptionPricePriceCurrency.Usd,
            },
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
                        Currency = SubscriptionPriceTierFlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
                        Currency = SubscriptionPriceTierUnitPriceCurrency.Usd,
                    },
                    UpTo = 0,
                },
            ],
        };

        SubscriptionPrice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionPricePriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionPricePrice
        {
            Amount = 0,
            BillingCountryCode = "billingCountryCode",
            Currency = SubscriptionPricePriceCurrency.Usd,
        };

        double expectedAmount = 0;
        string expectedBillingCountryCode = "billingCountryCode";
        ApiEnum<string, SubscriptionPricePriceCurrency> expectedCurrency =
            SubscriptionPricePriceCurrency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedBillingCountryCode, model.BillingCountryCode);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionPricePrice
        {
            Amount = 0,
            BillingCountryCode = "billingCountryCode",
            Currency = SubscriptionPricePriceCurrency.Usd,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionPricePrice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionPricePrice
        {
            Amount = 0,
            BillingCountryCode = "billingCountryCode",
            Currency = SubscriptionPricePriceCurrency.Usd,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionPricePrice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        string expectedBillingCountryCode = "billingCountryCode";
        ApiEnum<string, SubscriptionPricePriceCurrency> expectedCurrency =
            SubscriptionPricePriceCurrency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedBillingCountryCode, deserialized.BillingCountryCode);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionPricePrice
        {
            Amount = 0,
            BillingCountryCode = "billingCountryCode",
            Currency = SubscriptionPricePriceCurrency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubscriptionPricePrice { BillingCountryCode = "billingCountryCode" };

        Assert.Null(model.Amount);
        Assert.False(model.RawData.ContainsKey("amount"));
        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SubscriptionPricePrice { BillingCountryCode = "billingCountryCode" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SubscriptionPricePrice
        {
            BillingCountryCode = "billingCountryCode",

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
        var model = new SubscriptionPricePrice
        {
            BillingCountryCode = "billingCountryCode",

            // Null should be interpreted as omitted for these properties
            Amount = null,
            Currency = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubscriptionPricePrice
        {
            Amount = 0,
            Currency = SubscriptionPricePriceCurrency.Usd,
        };

        Assert.Null(model.BillingCountryCode);
        Assert.False(model.RawData.ContainsKey("billingCountryCode"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new SubscriptionPricePrice
        {
            Amount = 0,
            Currency = SubscriptionPricePriceCurrency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SubscriptionPricePrice
        {
            Amount = 0,
            Currency = SubscriptionPricePriceCurrency.Usd,

            BillingCountryCode = null,
        };

        Assert.Null(model.BillingCountryCode);
        Assert.True(model.RawData.ContainsKey("billingCountryCode"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SubscriptionPricePrice
        {
            Amount = 0,
            Currency = SubscriptionPricePriceCurrency.Usd,

            BillingCountryCode = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionPricePrice
        {
            Amount = 0,
            BillingCountryCode = "billingCountryCode",
            Currency = SubscriptionPricePriceCurrency.Usd,
        };

        SubscriptionPricePrice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionPricePriceCurrencyTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionPricePriceCurrency.Usd)]
    [InlineData(SubscriptionPricePriceCurrency.Aed)]
    [InlineData(SubscriptionPricePriceCurrency.All)]
    [InlineData(SubscriptionPricePriceCurrency.Amd)]
    [InlineData(SubscriptionPricePriceCurrency.Ang)]
    [InlineData(SubscriptionPricePriceCurrency.Aud)]
    [InlineData(SubscriptionPricePriceCurrency.Awg)]
    [InlineData(SubscriptionPricePriceCurrency.Azn)]
    [InlineData(SubscriptionPricePriceCurrency.Bam)]
    [InlineData(SubscriptionPricePriceCurrency.Bbd)]
    [InlineData(SubscriptionPricePriceCurrency.Bdt)]
    [InlineData(SubscriptionPricePriceCurrency.Bgn)]
    [InlineData(SubscriptionPricePriceCurrency.Bif)]
    [InlineData(SubscriptionPricePriceCurrency.Bmd)]
    [InlineData(SubscriptionPricePriceCurrency.Bnd)]
    [InlineData(SubscriptionPricePriceCurrency.Bsd)]
    [InlineData(SubscriptionPricePriceCurrency.Bwp)]
    [InlineData(SubscriptionPricePriceCurrency.Byn)]
    [InlineData(SubscriptionPricePriceCurrency.Bzd)]
    [InlineData(SubscriptionPricePriceCurrency.Brl)]
    [InlineData(SubscriptionPricePriceCurrency.Cad)]
    [InlineData(SubscriptionPricePriceCurrency.Cdf)]
    [InlineData(SubscriptionPricePriceCurrency.Chf)]
    [InlineData(SubscriptionPricePriceCurrency.Cny)]
    [InlineData(SubscriptionPricePriceCurrency.Czk)]
    [InlineData(SubscriptionPricePriceCurrency.Dkk)]
    [InlineData(SubscriptionPricePriceCurrency.Dop)]
    [InlineData(SubscriptionPricePriceCurrency.Dzd)]
    [InlineData(SubscriptionPricePriceCurrency.Egp)]
    [InlineData(SubscriptionPricePriceCurrency.Etb)]
    [InlineData(SubscriptionPricePriceCurrency.Eur)]
    [InlineData(SubscriptionPricePriceCurrency.Fjd)]
    [InlineData(SubscriptionPricePriceCurrency.Gbp)]
    [InlineData(SubscriptionPricePriceCurrency.Gel)]
    [InlineData(SubscriptionPricePriceCurrency.Gip)]
    [InlineData(SubscriptionPricePriceCurrency.Gmd)]
    [InlineData(SubscriptionPricePriceCurrency.Gyd)]
    [InlineData(SubscriptionPricePriceCurrency.Hkd)]
    [InlineData(SubscriptionPricePriceCurrency.Hrk)]
    [InlineData(SubscriptionPricePriceCurrency.Htg)]
    [InlineData(SubscriptionPricePriceCurrency.Idr)]
    [InlineData(SubscriptionPricePriceCurrency.Ils)]
    [InlineData(SubscriptionPricePriceCurrency.Inr)]
    [InlineData(SubscriptionPricePriceCurrency.Isk)]
    [InlineData(SubscriptionPricePriceCurrency.Jmd)]
    [InlineData(SubscriptionPricePriceCurrency.Jpy)]
    [InlineData(SubscriptionPricePriceCurrency.Kes)]
    [InlineData(SubscriptionPricePriceCurrency.Kgs)]
    [InlineData(SubscriptionPricePriceCurrency.Khr)]
    [InlineData(SubscriptionPricePriceCurrency.Kmf)]
    [InlineData(SubscriptionPricePriceCurrency.Krw)]
    [InlineData(SubscriptionPricePriceCurrency.Kyd)]
    [InlineData(SubscriptionPricePriceCurrency.Kzt)]
    [InlineData(SubscriptionPricePriceCurrency.Lbp)]
    [InlineData(SubscriptionPricePriceCurrency.Lkr)]
    [InlineData(SubscriptionPricePriceCurrency.Lrd)]
    [InlineData(SubscriptionPricePriceCurrency.Lsl)]
    [InlineData(SubscriptionPricePriceCurrency.Mad)]
    [InlineData(SubscriptionPricePriceCurrency.Mdl)]
    [InlineData(SubscriptionPricePriceCurrency.Mga)]
    [InlineData(SubscriptionPricePriceCurrency.Mkd)]
    [InlineData(SubscriptionPricePriceCurrency.Mmk)]
    [InlineData(SubscriptionPricePriceCurrency.Mnt)]
    [InlineData(SubscriptionPricePriceCurrency.Mop)]
    [InlineData(SubscriptionPricePriceCurrency.Mro)]
    [InlineData(SubscriptionPricePriceCurrency.Mvr)]
    [InlineData(SubscriptionPricePriceCurrency.Mwk)]
    [InlineData(SubscriptionPricePriceCurrency.Mxn)]
    [InlineData(SubscriptionPricePriceCurrency.Myr)]
    [InlineData(SubscriptionPricePriceCurrency.Mzn)]
    [InlineData(SubscriptionPricePriceCurrency.Nad)]
    [InlineData(SubscriptionPricePriceCurrency.Ngn)]
    [InlineData(SubscriptionPricePriceCurrency.Nok)]
    [InlineData(SubscriptionPricePriceCurrency.Npr)]
    [InlineData(SubscriptionPricePriceCurrency.Nzd)]
    [InlineData(SubscriptionPricePriceCurrency.Pgk)]
    [InlineData(SubscriptionPricePriceCurrency.Php)]
    [InlineData(SubscriptionPricePriceCurrency.Pkr)]
    [InlineData(SubscriptionPricePriceCurrency.Pln)]
    [InlineData(SubscriptionPricePriceCurrency.Qar)]
    [InlineData(SubscriptionPricePriceCurrency.Ron)]
    [InlineData(SubscriptionPricePriceCurrency.Rsd)]
    [InlineData(SubscriptionPricePriceCurrency.Rub)]
    [InlineData(SubscriptionPricePriceCurrency.Rwf)]
    [InlineData(SubscriptionPricePriceCurrency.Sar)]
    [InlineData(SubscriptionPricePriceCurrency.Sbd)]
    [InlineData(SubscriptionPricePriceCurrency.Scr)]
    [InlineData(SubscriptionPricePriceCurrency.Sek)]
    [InlineData(SubscriptionPricePriceCurrency.Sgd)]
    [InlineData(SubscriptionPricePriceCurrency.Sle)]
    [InlineData(SubscriptionPricePriceCurrency.Sll)]
    [InlineData(SubscriptionPricePriceCurrency.Sos)]
    [InlineData(SubscriptionPricePriceCurrency.Szl)]
    [InlineData(SubscriptionPricePriceCurrency.Thb)]
    [InlineData(SubscriptionPricePriceCurrency.Tjs)]
    [InlineData(SubscriptionPricePriceCurrency.Top)]
    [InlineData(SubscriptionPricePriceCurrency.Try)]
    [InlineData(SubscriptionPricePriceCurrency.Ttd)]
    [InlineData(SubscriptionPricePriceCurrency.Tzs)]
    [InlineData(SubscriptionPricePriceCurrency.Uah)]
    [InlineData(SubscriptionPricePriceCurrency.Uzs)]
    [InlineData(SubscriptionPricePriceCurrency.Vnd)]
    [InlineData(SubscriptionPricePriceCurrency.Vuv)]
    [InlineData(SubscriptionPricePriceCurrency.Wst)]
    [InlineData(SubscriptionPricePriceCurrency.Xaf)]
    [InlineData(SubscriptionPricePriceCurrency.Xcd)]
    [InlineData(SubscriptionPricePriceCurrency.Yer)]
    [InlineData(SubscriptionPricePriceCurrency.Zar)]
    [InlineData(SubscriptionPricePriceCurrency.Zmw)]
    [InlineData(SubscriptionPricePriceCurrency.Clp)]
    [InlineData(SubscriptionPricePriceCurrency.Djf)]
    [InlineData(SubscriptionPricePriceCurrency.Gnf)]
    [InlineData(SubscriptionPricePriceCurrency.Ugx)]
    [InlineData(SubscriptionPricePriceCurrency.Pyg)]
    [InlineData(SubscriptionPricePriceCurrency.Xof)]
    [InlineData(SubscriptionPricePriceCurrency.Xpf)]
    public void Validation_Works(SubscriptionPricePriceCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionPricePriceCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SubscriptionPricePriceCurrency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionPricePriceCurrency.Usd)]
    [InlineData(SubscriptionPricePriceCurrency.Aed)]
    [InlineData(SubscriptionPricePriceCurrency.All)]
    [InlineData(SubscriptionPricePriceCurrency.Amd)]
    [InlineData(SubscriptionPricePriceCurrency.Ang)]
    [InlineData(SubscriptionPricePriceCurrency.Aud)]
    [InlineData(SubscriptionPricePriceCurrency.Awg)]
    [InlineData(SubscriptionPricePriceCurrency.Azn)]
    [InlineData(SubscriptionPricePriceCurrency.Bam)]
    [InlineData(SubscriptionPricePriceCurrency.Bbd)]
    [InlineData(SubscriptionPricePriceCurrency.Bdt)]
    [InlineData(SubscriptionPricePriceCurrency.Bgn)]
    [InlineData(SubscriptionPricePriceCurrency.Bif)]
    [InlineData(SubscriptionPricePriceCurrency.Bmd)]
    [InlineData(SubscriptionPricePriceCurrency.Bnd)]
    [InlineData(SubscriptionPricePriceCurrency.Bsd)]
    [InlineData(SubscriptionPricePriceCurrency.Bwp)]
    [InlineData(SubscriptionPricePriceCurrency.Byn)]
    [InlineData(SubscriptionPricePriceCurrency.Bzd)]
    [InlineData(SubscriptionPricePriceCurrency.Brl)]
    [InlineData(SubscriptionPricePriceCurrency.Cad)]
    [InlineData(SubscriptionPricePriceCurrency.Cdf)]
    [InlineData(SubscriptionPricePriceCurrency.Chf)]
    [InlineData(SubscriptionPricePriceCurrency.Cny)]
    [InlineData(SubscriptionPricePriceCurrency.Czk)]
    [InlineData(SubscriptionPricePriceCurrency.Dkk)]
    [InlineData(SubscriptionPricePriceCurrency.Dop)]
    [InlineData(SubscriptionPricePriceCurrency.Dzd)]
    [InlineData(SubscriptionPricePriceCurrency.Egp)]
    [InlineData(SubscriptionPricePriceCurrency.Etb)]
    [InlineData(SubscriptionPricePriceCurrency.Eur)]
    [InlineData(SubscriptionPricePriceCurrency.Fjd)]
    [InlineData(SubscriptionPricePriceCurrency.Gbp)]
    [InlineData(SubscriptionPricePriceCurrency.Gel)]
    [InlineData(SubscriptionPricePriceCurrency.Gip)]
    [InlineData(SubscriptionPricePriceCurrency.Gmd)]
    [InlineData(SubscriptionPricePriceCurrency.Gyd)]
    [InlineData(SubscriptionPricePriceCurrency.Hkd)]
    [InlineData(SubscriptionPricePriceCurrency.Hrk)]
    [InlineData(SubscriptionPricePriceCurrency.Htg)]
    [InlineData(SubscriptionPricePriceCurrency.Idr)]
    [InlineData(SubscriptionPricePriceCurrency.Ils)]
    [InlineData(SubscriptionPricePriceCurrency.Inr)]
    [InlineData(SubscriptionPricePriceCurrency.Isk)]
    [InlineData(SubscriptionPricePriceCurrency.Jmd)]
    [InlineData(SubscriptionPricePriceCurrency.Jpy)]
    [InlineData(SubscriptionPricePriceCurrency.Kes)]
    [InlineData(SubscriptionPricePriceCurrency.Kgs)]
    [InlineData(SubscriptionPricePriceCurrency.Khr)]
    [InlineData(SubscriptionPricePriceCurrency.Kmf)]
    [InlineData(SubscriptionPricePriceCurrency.Krw)]
    [InlineData(SubscriptionPricePriceCurrency.Kyd)]
    [InlineData(SubscriptionPricePriceCurrency.Kzt)]
    [InlineData(SubscriptionPricePriceCurrency.Lbp)]
    [InlineData(SubscriptionPricePriceCurrency.Lkr)]
    [InlineData(SubscriptionPricePriceCurrency.Lrd)]
    [InlineData(SubscriptionPricePriceCurrency.Lsl)]
    [InlineData(SubscriptionPricePriceCurrency.Mad)]
    [InlineData(SubscriptionPricePriceCurrency.Mdl)]
    [InlineData(SubscriptionPricePriceCurrency.Mga)]
    [InlineData(SubscriptionPricePriceCurrency.Mkd)]
    [InlineData(SubscriptionPricePriceCurrency.Mmk)]
    [InlineData(SubscriptionPricePriceCurrency.Mnt)]
    [InlineData(SubscriptionPricePriceCurrency.Mop)]
    [InlineData(SubscriptionPricePriceCurrency.Mro)]
    [InlineData(SubscriptionPricePriceCurrency.Mvr)]
    [InlineData(SubscriptionPricePriceCurrency.Mwk)]
    [InlineData(SubscriptionPricePriceCurrency.Mxn)]
    [InlineData(SubscriptionPricePriceCurrency.Myr)]
    [InlineData(SubscriptionPricePriceCurrency.Mzn)]
    [InlineData(SubscriptionPricePriceCurrency.Nad)]
    [InlineData(SubscriptionPricePriceCurrency.Ngn)]
    [InlineData(SubscriptionPricePriceCurrency.Nok)]
    [InlineData(SubscriptionPricePriceCurrency.Npr)]
    [InlineData(SubscriptionPricePriceCurrency.Nzd)]
    [InlineData(SubscriptionPricePriceCurrency.Pgk)]
    [InlineData(SubscriptionPricePriceCurrency.Php)]
    [InlineData(SubscriptionPricePriceCurrency.Pkr)]
    [InlineData(SubscriptionPricePriceCurrency.Pln)]
    [InlineData(SubscriptionPricePriceCurrency.Qar)]
    [InlineData(SubscriptionPricePriceCurrency.Ron)]
    [InlineData(SubscriptionPricePriceCurrency.Rsd)]
    [InlineData(SubscriptionPricePriceCurrency.Rub)]
    [InlineData(SubscriptionPricePriceCurrency.Rwf)]
    [InlineData(SubscriptionPricePriceCurrency.Sar)]
    [InlineData(SubscriptionPricePriceCurrency.Sbd)]
    [InlineData(SubscriptionPricePriceCurrency.Scr)]
    [InlineData(SubscriptionPricePriceCurrency.Sek)]
    [InlineData(SubscriptionPricePriceCurrency.Sgd)]
    [InlineData(SubscriptionPricePriceCurrency.Sle)]
    [InlineData(SubscriptionPricePriceCurrency.Sll)]
    [InlineData(SubscriptionPricePriceCurrency.Sos)]
    [InlineData(SubscriptionPricePriceCurrency.Szl)]
    [InlineData(SubscriptionPricePriceCurrency.Thb)]
    [InlineData(SubscriptionPricePriceCurrency.Tjs)]
    [InlineData(SubscriptionPricePriceCurrency.Top)]
    [InlineData(SubscriptionPricePriceCurrency.Try)]
    [InlineData(SubscriptionPricePriceCurrency.Ttd)]
    [InlineData(SubscriptionPricePriceCurrency.Tzs)]
    [InlineData(SubscriptionPricePriceCurrency.Uah)]
    [InlineData(SubscriptionPricePriceCurrency.Uzs)]
    [InlineData(SubscriptionPricePriceCurrency.Vnd)]
    [InlineData(SubscriptionPricePriceCurrency.Vuv)]
    [InlineData(SubscriptionPricePriceCurrency.Wst)]
    [InlineData(SubscriptionPricePriceCurrency.Xaf)]
    [InlineData(SubscriptionPricePriceCurrency.Xcd)]
    [InlineData(SubscriptionPricePriceCurrency.Yer)]
    [InlineData(SubscriptionPricePriceCurrency.Zar)]
    [InlineData(SubscriptionPricePriceCurrency.Zmw)]
    [InlineData(SubscriptionPricePriceCurrency.Clp)]
    [InlineData(SubscriptionPricePriceCurrency.Djf)]
    [InlineData(SubscriptionPricePriceCurrency.Gnf)]
    [InlineData(SubscriptionPricePriceCurrency.Ugx)]
    [InlineData(SubscriptionPricePriceCurrency.Pyg)]
    [InlineData(SubscriptionPricePriceCurrency.Xof)]
    [InlineData(SubscriptionPricePriceCurrency.Xpf)]
    public void SerializationRoundtrip_Works(SubscriptionPricePriceCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionPricePriceCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionPricePriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SubscriptionPricePriceCurrency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionPricePriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionPriceTierTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionPriceTier
        {
            FlatPrice = new()
            {
                Amount = 0,
                BillingCountryCode = "billingCountryCode",
                Currency = SubscriptionPriceTierFlatPriceCurrency.Usd,
            },
            UnitPrice = new()
            {
                Amount = 0,
                BillingCountryCode = "billingCountryCode",
                Currency = SubscriptionPriceTierUnitPriceCurrency.Usd,
            },
            UpTo = 0,
        };

        SubscriptionPriceTierFlatPrice expectedFlatPrice = new()
        {
            Amount = 0,
            BillingCountryCode = "billingCountryCode",
            Currency = SubscriptionPriceTierFlatPriceCurrency.Usd,
        };
        SubscriptionPriceTierUnitPrice expectedUnitPrice = new()
        {
            Amount = 0,
            BillingCountryCode = "billingCountryCode",
            Currency = SubscriptionPriceTierUnitPriceCurrency.Usd,
        };
        double expectedUpTo = 0;

        Assert.Equal(expectedFlatPrice, model.FlatPrice);
        Assert.Equal(expectedUnitPrice, model.UnitPrice);
        Assert.Equal(expectedUpTo, model.UpTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionPriceTier
        {
            FlatPrice = new()
            {
                Amount = 0,
                BillingCountryCode = "billingCountryCode",
                Currency = SubscriptionPriceTierFlatPriceCurrency.Usd,
            },
            UnitPrice = new()
            {
                Amount = 0,
                BillingCountryCode = "billingCountryCode",
                Currency = SubscriptionPriceTierUnitPriceCurrency.Usd,
            },
            UpTo = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionPriceTier>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionPriceTier
        {
            FlatPrice = new()
            {
                Amount = 0,
                BillingCountryCode = "billingCountryCode",
                Currency = SubscriptionPriceTierFlatPriceCurrency.Usd,
            },
            UnitPrice = new()
            {
                Amount = 0,
                BillingCountryCode = "billingCountryCode",
                Currency = SubscriptionPriceTierUnitPriceCurrency.Usd,
            },
            UpTo = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionPriceTier>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        SubscriptionPriceTierFlatPrice expectedFlatPrice = new()
        {
            Amount = 0,
            BillingCountryCode = "billingCountryCode",
            Currency = SubscriptionPriceTierFlatPriceCurrency.Usd,
        };
        SubscriptionPriceTierUnitPrice expectedUnitPrice = new()
        {
            Amount = 0,
            BillingCountryCode = "billingCountryCode",
            Currency = SubscriptionPriceTierUnitPriceCurrency.Usd,
        };
        double expectedUpTo = 0;

        Assert.Equal(expectedFlatPrice, deserialized.FlatPrice);
        Assert.Equal(expectedUnitPrice, deserialized.UnitPrice);
        Assert.Equal(expectedUpTo, deserialized.UpTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionPriceTier
        {
            FlatPrice = new()
            {
                Amount = 0,
                BillingCountryCode = "billingCountryCode",
                Currency = SubscriptionPriceTierFlatPriceCurrency.Usd,
            },
            UnitPrice = new()
            {
                Amount = 0,
                BillingCountryCode = "billingCountryCode",
                Currency = SubscriptionPriceTierUnitPriceCurrency.Usd,
            },
            UpTo = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubscriptionPriceTier { };

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
        var model = new SubscriptionPriceTier { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SubscriptionPriceTier
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
        var model = new SubscriptionPriceTier
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
        var model = new SubscriptionPriceTier
        {
            FlatPrice = new()
            {
                Amount = 0,
                BillingCountryCode = "billingCountryCode",
                Currency = SubscriptionPriceTierFlatPriceCurrency.Usd,
            },
            UnitPrice = new()
            {
                Amount = 0,
                BillingCountryCode = "billingCountryCode",
                Currency = SubscriptionPriceTierUnitPriceCurrency.Usd,
            },
            UpTo = 0,
        };

        SubscriptionPriceTier copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionPriceTierFlatPriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionPriceTierFlatPrice
        {
            Amount = 0,
            BillingCountryCode = "billingCountryCode",
            Currency = SubscriptionPriceTierFlatPriceCurrency.Usd,
        };

        double expectedAmount = 0;
        string expectedBillingCountryCode = "billingCountryCode";
        ApiEnum<string, SubscriptionPriceTierFlatPriceCurrency> expectedCurrency =
            SubscriptionPriceTierFlatPriceCurrency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedBillingCountryCode, model.BillingCountryCode);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionPriceTierFlatPrice
        {
            Amount = 0,
            BillingCountryCode = "billingCountryCode",
            Currency = SubscriptionPriceTierFlatPriceCurrency.Usd,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionPriceTierFlatPrice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionPriceTierFlatPrice
        {
            Amount = 0,
            BillingCountryCode = "billingCountryCode",
            Currency = SubscriptionPriceTierFlatPriceCurrency.Usd,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionPriceTierFlatPrice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        string expectedBillingCountryCode = "billingCountryCode";
        ApiEnum<string, SubscriptionPriceTierFlatPriceCurrency> expectedCurrency =
            SubscriptionPriceTierFlatPriceCurrency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedBillingCountryCode, deserialized.BillingCountryCode);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionPriceTierFlatPrice
        {
            Amount = 0,
            BillingCountryCode = "billingCountryCode",
            Currency = SubscriptionPriceTierFlatPriceCurrency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubscriptionPriceTierFlatPrice
        {
            BillingCountryCode = "billingCountryCode",
        };

        Assert.Null(model.Amount);
        Assert.False(model.RawData.ContainsKey("amount"));
        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SubscriptionPriceTierFlatPrice
        {
            BillingCountryCode = "billingCountryCode",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SubscriptionPriceTierFlatPrice
        {
            BillingCountryCode = "billingCountryCode",

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
        var model = new SubscriptionPriceTierFlatPrice
        {
            BillingCountryCode = "billingCountryCode",

            // Null should be interpreted as omitted for these properties
            Amount = null,
            Currency = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubscriptionPriceTierFlatPrice
        {
            Amount = 0,
            Currency = SubscriptionPriceTierFlatPriceCurrency.Usd,
        };

        Assert.Null(model.BillingCountryCode);
        Assert.False(model.RawData.ContainsKey("billingCountryCode"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new SubscriptionPriceTierFlatPrice
        {
            Amount = 0,
            Currency = SubscriptionPriceTierFlatPriceCurrency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SubscriptionPriceTierFlatPrice
        {
            Amount = 0,
            Currency = SubscriptionPriceTierFlatPriceCurrency.Usd,

            BillingCountryCode = null,
        };

        Assert.Null(model.BillingCountryCode);
        Assert.True(model.RawData.ContainsKey("billingCountryCode"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SubscriptionPriceTierFlatPrice
        {
            Amount = 0,
            Currency = SubscriptionPriceTierFlatPriceCurrency.Usd,

            BillingCountryCode = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionPriceTierFlatPrice
        {
            Amount = 0,
            BillingCountryCode = "billingCountryCode",
            Currency = SubscriptionPriceTierFlatPriceCurrency.Usd,
        };

        SubscriptionPriceTierFlatPrice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionPriceTierFlatPriceCurrencyTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Usd)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Aed)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.All)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Amd)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Ang)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Aud)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Awg)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Azn)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Bam)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Bbd)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Bdt)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Bgn)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Bif)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Bmd)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Bnd)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Bsd)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Bwp)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Byn)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Bzd)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Brl)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Cad)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Cdf)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Chf)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Cny)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Czk)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Dkk)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Dop)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Dzd)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Egp)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Etb)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Eur)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Fjd)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Gbp)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Gel)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Gip)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Gmd)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Gyd)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Hkd)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Hrk)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Htg)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Idr)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Ils)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Inr)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Isk)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Jmd)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Jpy)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Kes)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Kgs)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Khr)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Kmf)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Krw)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Kyd)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Kzt)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Lbp)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Lkr)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Lrd)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Lsl)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Mad)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Mdl)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Mga)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Mkd)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Mmk)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Mnt)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Mop)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Mro)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Mvr)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Mwk)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Mxn)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Myr)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Mzn)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Nad)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Ngn)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Nok)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Npr)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Nzd)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Pgk)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Php)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Pkr)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Pln)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Qar)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Ron)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Rsd)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Rub)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Rwf)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Sar)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Sbd)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Scr)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Sek)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Sgd)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Sle)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Sll)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Sos)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Szl)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Thb)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Tjs)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Top)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Try)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Ttd)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Tzs)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Uah)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Uzs)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Vnd)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Vuv)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Wst)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Xaf)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Xcd)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Yer)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Zar)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Zmw)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Clp)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Djf)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Gnf)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Ugx)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Pyg)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Xof)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Xpf)]
    public void Validation_Works(SubscriptionPriceTierFlatPriceCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionPriceTierFlatPriceCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionPriceTierFlatPriceCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Usd)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Aed)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.All)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Amd)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Ang)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Aud)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Awg)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Azn)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Bam)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Bbd)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Bdt)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Bgn)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Bif)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Bmd)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Bnd)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Bsd)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Bwp)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Byn)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Bzd)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Brl)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Cad)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Cdf)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Chf)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Cny)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Czk)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Dkk)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Dop)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Dzd)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Egp)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Etb)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Eur)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Fjd)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Gbp)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Gel)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Gip)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Gmd)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Gyd)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Hkd)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Hrk)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Htg)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Idr)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Ils)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Inr)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Isk)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Jmd)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Jpy)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Kes)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Kgs)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Khr)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Kmf)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Krw)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Kyd)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Kzt)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Lbp)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Lkr)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Lrd)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Lsl)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Mad)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Mdl)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Mga)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Mkd)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Mmk)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Mnt)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Mop)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Mro)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Mvr)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Mwk)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Mxn)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Myr)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Mzn)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Nad)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Ngn)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Nok)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Npr)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Nzd)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Pgk)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Php)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Pkr)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Pln)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Qar)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Ron)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Rsd)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Rub)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Rwf)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Sar)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Sbd)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Scr)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Sek)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Sgd)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Sle)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Sll)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Sos)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Szl)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Thb)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Tjs)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Top)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Try)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Ttd)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Tzs)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Uah)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Uzs)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Vnd)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Vuv)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Wst)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Xaf)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Xcd)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Yer)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Zar)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Zmw)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Clp)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Djf)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Gnf)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Ugx)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Pyg)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Xof)]
    [InlineData(SubscriptionPriceTierFlatPriceCurrency.Xpf)]
    public void SerializationRoundtrip_Works(SubscriptionPriceTierFlatPriceCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionPriceTierFlatPriceCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionPriceTierFlatPriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionPriceTierFlatPriceCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionPriceTierFlatPriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionPriceTierUnitPriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionPriceTierUnitPrice
        {
            Amount = 0,
            BillingCountryCode = "billingCountryCode",
            Currency = SubscriptionPriceTierUnitPriceCurrency.Usd,
        };

        double expectedAmount = 0;
        string expectedBillingCountryCode = "billingCountryCode";
        ApiEnum<string, SubscriptionPriceTierUnitPriceCurrency> expectedCurrency =
            SubscriptionPriceTierUnitPriceCurrency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedBillingCountryCode, model.BillingCountryCode);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionPriceTierUnitPrice
        {
            Amount = 0,
            BillingCountryCode = "billingCountryCode",
            Currency = SubscriptionPriceTierUnitPriceCurrency.Usd,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionPriceTierUnitPrice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionPriceTierUnitPrice
        {
            Amount = 0,
            BillingCountryCode = "billingCountryCode",
            Currency = SubscriptionPriceTierUnitPriceCurrency.Usd,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionPriceTierUnitPrice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        string expectedBillingCountryCode = "billingCountryCode";
        ApiEnum<string, SubscriptionPriceTierUnitPriceCurrency> expectedCurrency =
            SubscriptionPriceTierUnitPriceCurrency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedBillingCountryCode, deserialized.BillingCountryCode);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionPriceTierUnitPrice
        {
            Amount = 0,
            BillingCountryCode = "billingCountryCode",
            Currency = SubscriptionPriceTierUnitPriceCurrency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubscriptionPriceTierUnitPrice
        {
            BillingCountryCode = "billingCountryCode",
        };

        Assert.Null(model.Amount);
        Assert.False(model.RawData.ContainsKey("amount"));
        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SubscriptionPriceTierUnitPrice
        {
            BillingCountryCode = "billingCountryCode",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SubscriptionPriceTierUnitPrice
        {
            BillingCountryCode = "billingCountryCode",

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
        var model = new SubscriptionPriceTierUnitPrice
        {
            BillingCountryCode = "billingCountryCode",

            // Null should be interpreted as omitted for these properties
            Amount = null,
            Currency = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubscriptionPriceTierUnitPrice
        {
            Amount = 0,
            Currency = SubscriptionPriceTierUnitPriceCurrency.Usd,
        };

        Assert.Null(model.BillingCountryCode);
        Assert.False(model.RawData.ContainsKey("billingCountryCode"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new SubscriptionPriceTierUnitPrice
        {
            Amount = 0,
            Currency = SubscriptionPriceTierUnitPriceCurrency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SubscriptionPriceTierUnitPrice
        {
            Amount = 0,
            Currency = SubscriptionPriceTierUnitPriceCurrency.Usd,

            BillingCountryCode = null,
        };

        Assert.Null(model.BillingCountryCode);
        Assert.True(model.RawData.ContainsKey("billingCountryCode"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SubscriptionPriceTierUnitPrice
        {
            Amount = 0,
            Currency = SubscriptionPriceTierUnitPriceCurrency.Usd,

            BillingCountryCode = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionPriceTierUnitPrice
        {
            Amount = 0,
            BillingCountryCode = "billingCountryCode",
            Currency = SubscriptionPriceTierUnitPriceCurrency.Usd,
        };

        SubscriptionPriceTierUnitPrice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionPriceTierUnitPriceCurrencyTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Usd)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Aed)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.All)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Amd)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Ang)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Aud)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Awg)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Azn)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Bam)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Bbd)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Bdt)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Bgn)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Bif)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Bmd)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Bnd)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Bsd)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Bwp)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Byn)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Bzd)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Brl)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Cad)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Cdf)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Chf)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Cny)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Czk)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Dkk)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Dop)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Dzd)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Egp)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Etb)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Eur)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Fjd)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Gbp)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Gel)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Gip)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Gmd)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Gyd)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Hkd)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Hrk)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Htg)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Idr)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Ils)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Inr)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Isk)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Jmd)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Jpy)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Kes)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Kgs)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Khr)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Kmf)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Krw)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Kyd)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Kzt)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Lbp)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Lkr)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Lrd)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Lsl)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Mad)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Mdl)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Mga)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Mkd)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Mmk)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Mnt)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Mop)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Mro)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Mvr)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Mwk)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Mxn)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Myr)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Mzn)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Nad)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Ngn)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Nok)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Npr)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Nzd)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Pgk)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Php)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Pkr)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Pln)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Qar)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Ron)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Rsd)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Rub)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Rwf)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Sar)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Sbd)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Scr)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Sek)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Sgd)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Sle)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Sll)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Sos)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Szl)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Thb)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Tjs)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Top)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Try)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Ttd)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Tzs)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Uah)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Uzs)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Vnd)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Vuv)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Wst)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Xaf)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Xcd)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Yer)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Zar)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Zmw)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Clp)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Djf)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Gnf)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Ugx)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Pyg)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Xof)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Xpf)]
    public void Validation_Works(SubscriptionPriceTierUnitPriceCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionPriceTierUnitPriceCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionPriceTierUnitPriceCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Usd)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Aed)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.All)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Amd)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Ang)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Aud)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Awg)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Azn)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Bam)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Bbd)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Bdt)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Bgn)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Bif)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Bmd)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Bnd)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Bsd)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Bwp)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Byn)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Bzd)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Brl)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Cad)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Cdf)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Chf)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Cny)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Czk)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Dkk)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Dop)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Dzd)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Egp)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Etb)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Eur)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Fjd)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Gbp)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Gel)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Gip)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Gmd)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Gyd)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Hkd)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Hrk)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Htg)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Idr)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Ils)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Inr)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Isk)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Jmd)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Jpy)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Kes)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Kgs)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Khr)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Kmf)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Krw)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Kyd)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Kzt)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Lbp)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Lkr)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Lrd)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Lsl)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Mad)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Mdl)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Mga)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Mkd)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Mmk)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Mnt)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Mop)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Mro)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Mvr)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Mwk)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Mxn)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Myr)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Mzn)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Nad)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Ngn)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Nok)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Npr)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Nzd)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Pgk)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Php)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Pkr)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Pln)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Qar)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Ron)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Rsd)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Rub)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Rwf)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Sar)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Sbd)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Scr)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Sek)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Sgd)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Sle)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Sll)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Sos)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Szl)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Thb)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Tjs)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Top)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Try)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Ttd)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Tzs)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Uah)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Uzs)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Vnd)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Vuv)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Wst)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Xaf)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Xcd)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Yer)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Zar)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Zmw)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Clp)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Djf)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Gnf)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Ugx)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Pyg)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Xof)]
    [InlineData(SubscriptionPriceTierUnitPriceCurrency.Xpf)]
    public void SerializationRoundtrip_Works(SubscriptionPriceTierUnitPriceCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionPriceTierUnitPriceCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionPriceTierUnitPriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionPriceTierUnitPriceCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionPriceTierUnitPriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
