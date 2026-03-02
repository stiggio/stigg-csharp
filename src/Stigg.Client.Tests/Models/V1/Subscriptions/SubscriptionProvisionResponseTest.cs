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
                    CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CancelReason =
                        SubscriptionProvisionResponseDataSubscriptionCancelReason.UpgradeOrDowngrade,
                    CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PayingCustomerID = "payingCustomerId",
                    PaymentCollectionMethod =
                        SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.Charge,
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
                                Currency =
                                    SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Usd,
                            },
                            Tiers =
                            [
                                new()
                                {
                                    FlatPrice = new()
                                    {
                                        Amount = 0,
                                        BillingCountryCode = "billingCountryCode",
                                        Currency =
                                            SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                                    },
                                    UnitPrice = new()
                                    {
                                        Amount = 0,
                                        BillingCountryCode = "billingCountryCode",
                                        Currency =
                                            SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                                    },
                                    UpTo = 0,
                                },
                            ],
                        },
                    ],
                    ResourceID = "resourceId",
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
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason =
                    SubscriptionProvisionResponseDataSubscriptionCancelReason.UpgradeOrDowngrade,
                CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod =
                    SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.Charge,
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
                            Currency =
                                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Usd,
                        },
                        Tiers =
                        [
                            new()
                            {
                                FlatPrice = new()
                                {
                                    Amount = 0,
                                    BillingCountryCode = "billingCountryCode",
                                    Currency =
                                        SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                                },
                                UnitPrice = new()
                                {
                                    Amount = 0,
                                    BillingCountryCode = "billingCountryCode",
                                    Currency =
                                        SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                                },
                                UpTo = 0,
                            },
                        ],
                    },
                ],
                ResourceID = "resourceId",
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
                    CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CancelReason =
                        SubscriptionProvisionResponseDataSubscriptionCancelReason.UpgradeOrDowngrade,
                    CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PayingCustomerID = "payingCustomerId",
                    PaymentCollectionMethod =
                        SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.Charge,
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
                                Currency =
                                    SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Usd,
                            },
                            Tiers =
                            [
                                new()
                                {
                                    FlatPrice = new()
                                    {
                                        Amount = 0,
                                        BillingCountryCode = "billingCountryCode",
                                        Currency =
                                            SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                                    },
                                    UnitPrice = new()
                                    {
                                        Amount = 0,
                                        BillingCountryCode = "billingCountryCode",
                                        Currency =
                                            SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                                    },
                                    UpTo = 0,
                                },
                            ],
                        },
                    ],
                    ResourceID = "resourceId",
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
                    CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CancelReason =
                        SubscriptionProvisionResponseDataSubscriptionCancelReason.UpgradeOrDowngrade,
                    CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PayingCustomerID = "payingCustomerId",
                    PaymentCollectionMethod =
                        SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.Charge,
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
                                Currency =
                                    SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Usd,
                            },
                            Tiers =
                            [
                                new()
                                {
                                    FlatPrice = new()
                                    {
                                        Amount = 0,
                                        BillingCountryCode = "billingCountryCode",
                                        Currency =
                                            SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                                    },
                                    UnitPrice = new()
                                    {
                                        Amount = 0,
                                        BillingCountryCode = "billingCountryCode",
                                        Currency =
                                            SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                                    },
                                    UpTo = 0,
                                },
                            ],
                        },
                    ],
                    ResourceID = "resourceId",
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
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason =
                    SubscriptionProvisionResponseDataSubscriptionCancelReason.UpgradeOrDowngrade,
                CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod =
                    SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.Charge,
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
                            Currency =
                                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Usd,
                        },
                        Tiers =
                        [
                            new()
                            {
                                FlatPrice = new()
                                {
                                    Amount = 0,
                                    BillingCountryCode = "billingCountryCode",
                                    Currency =
                                        SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                                },
                                UnitPrice = new()
                                {
                                    Amount = 0,
                                    BillingCountryCode = "billingCountryCode",
                                    Currency =
                                        SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                                },
                                UpTo = 0,
                            },
                        ],
                    },
                ],
                ResourceID = "resourceId",
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
                    CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CancelReason =
                        SubscriptionProvisionResponseDataSubscriptionCancelReason.UpgradeOrDowngrade,
                    CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PayingCustomerID = "payingCustomerId",
                    PaymentCollectionMethod =
                        SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.Charge,
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
                                Currency =
                                    SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Usd,
                            },
                            Tiers =
                            [
                                new()
                                {
                                    FlatPrice = new()
                                    {
                                        Amount = 0,
                                        BillingCountryCode = "billingCountryCode",
                                        Currency =
                                            SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                                    },
                                    UnitPrice = new()
                                    {
                                        Amount = 0,
                                        BillingCountryCode = "billingCountryCode",
                                        Currency =
                                            SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                                    },
                                    UpTo = 0,
                                },
                            ],
                        },
                    ],
                    ResourceID = "resourceId",
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
                    CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CancelReason =
                        SubscriptionProvisionResponseDataSubscriptionCancelReason.UpgradeOrDowngrade,
                    CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PayingCustomerID = "payingCustomerId",
                    PaymentCollectionMethod =
                        SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.Charge,
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
                                Currency =
                                    SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Usd,
                            },
                            Tiers =
                            [
                                new()
                                {
                                    FlatPrice = new()
                                    {
                                        Amount = 0,
                                        BillingCountryCode = "billingCountryCode",
                                        Currency =
                                            SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                                    },
                                    UnitPrice = new()
                                    {
                                        Amount = 0,
                                        BillingCountryCode = "billingCountryCode",
                                        Currency =
                                            SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                                    },
                                    UpTo = 0,
                                },
                            ],
                        },
                    ],
                    ResourceID = "resourceId",
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
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason =
                    SubscriptionProvisionResponseDataSubscriptionCancelReason.UpgradeOrDowngrade,
                CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod =
                    SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.Charge,
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
                            Currency =
                                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Usd,
                        },
                        Tiers =
                        [
                            new()
                            {
                                FlatPrice = new()
                                {
                                    Amount = 0,
                                    BillingCountryCode = "billingCountryCode",
                                    Currency =
                                        SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                                },
                                UnitPrice = new()
                                {
                                    Amount = 0,
                                    BillingCountryCode = "billingCountryCode",
                                    Currency =
                                        SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                                },
                                UpTo = 0,
                            },
                        ],
                    },
                ],
                ResourceID = "resourceId",
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            CheckoutBillingID = "checkoutBillingId",
            CheckoutUrl = "checkoutUrl",
            IsScheduled = true,
        };

        string expectedID = "id";
        List<Entitlement> expectedEntitlements =
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
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason =
                SubscriptionProvisionResponseDataSubscriptionCancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod =
                SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.Charge,
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
                        Currency =
                            SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Usd,
                    },
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                BillingCountryCode = "billingCountryCode",
                                Currency =
                                    SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                BillingCountryCode = "billingCountryCode",
                                Currency =
                                    SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            ResourceID = "resourceId",
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
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason =
                    SubscriptionProvisionResponseDataSubscriptionCancelReason.UpgradeOrDowngrade,
                CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod =
                    SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.Charge,
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
                            Currency =
                                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Usd,
                        },
                        Tiers =
                        [
                            new()
                            {
                                FlatPrice = new()
                                {
                                    Amount = 0,
                                    BillingCountryCode = "billingCountryCode",
                                    Currency =
                                        SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                                },
                                UnitPrice = new()
                                {
                                    Amount = 0,
                                    BillingCountryCode = "billingCountryCode",
                                    Currency =
                                        SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                                },
                                UpTo = 0,
                            },
                        ],
                    },
                ],
                ResourceID = "resourceId",
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
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason =
                    SubscriptionProvisionResponseDataSubscriptionCancelReason.UpgradeOrDowngrade,
                CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod =
                    SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.Charge,
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
                            Currency =
                                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Usd,
                        },
                        Tiers =
                        [
                            new()
                            {
                                FlatPrice = new()
                                {
                                    Amount = 0,
                                    BillingCountryCode = "billingCountryCode",
                                    Currency =
                                        SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                                },
                                UnitPrice = new()
                                {
                                    Amount = 0,
                                    BillingCountryCode = "billingCountryCode",
                                    Currency =
                                        SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                                },
                                UpTo = 0,
                            },
                        ],
                    },
                ],
                ResourceID = "resourceId",
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
        List<Entitlement> expectedEntitlements =
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
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason =
                SubscriptionProvisionResponseDataSubscriptionCancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod =
                SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.Charge,
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
                        Currency =
                            SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Usd,
                    },
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                BillingCountryCode = "billingCountryCode",
                                Currency =
                                    SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                BillingCountryCode = "billingCountryCode",
                                Currency =
                                    SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            ResourceID = "resourceId",
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
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason =
                    SubscriptionProvisionResponseDataSubscriptionCancelReason.UpgradeOrDowngrade,
                CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod =
                    SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.Charge,
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
                            Currency =
                                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Usd,
                        },
                        Tiers =
                        [
                            new()
                            {
                                FlatPrice = new()
                                {
                                    Amount = 0,
                                    BillingCountryCode = "billingCountryCode",
                                    Currency =
                                        SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                                },
                                UnitPrice = new()
                                {
                                    Amount = 0,
                                    BillingCountryCode = "billingCountryCode",
                                    Currency =
                                        SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                                },
                                UpTo = 0,
                            },
                        ],
                    },
                ],
                ResourceID = "resourceId",
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
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason =
                    SubscriptionProvisionResponseDataSubscriptionCancelReason.UpgradeOrDowngrade,
                CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod =
                    SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.Charge,
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
                            Currency =
                                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Usd,
                        },
                        Tiers =
                        [
                            new()
                            {
                                FlatPrice = new()
                                {
                                    Amount = 0,
                                    BillingCountryCode = "billingCountryCode",
                                    Currency =
                                        SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                                },
                                UnitPrice = new()
                                {
                                    Amount = 0,
                                    BillingCountryCode = "billingCountryCode",
                                    Currency =
                                        SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                                },
                                UpTo = 0,
                            },
                        ],
                    },
                ],
                ResourceID = "resourceId",
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
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason =
                    SubscriptionProvisionResponseDataSubscriptionCancelReason.UpgradeOrDowngrade,
                CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod =
                    SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.Charge,
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
                            Currency =
                                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Usd,
                        },
                        Tiers =
                        [
                            new()
                            {
                                FlatPrice = new()
                                {
                                    Amount = 0,
                                    BillingCountryCode = "billingCountryCode",
                                    Currency =
                                        SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                                },
                                UnitPrice = new()
                                {
                                    Amount = 0,
                                    BillingCountryCode = "billingCountryCode",
                                    Currency =
                                        SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                                },
                                UpTo = 0,
                            },
                        ],
                    },
                ],
                ResourceID = "resourceId",
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
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason =
                    SubscriptionProvisionResponseDataSubscriptionCancelReason.UpgradeOrDowngrade,
                CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod =
                    SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.Charge,
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
                            Currency =
                                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Usd,
                        },
                        Tiers =
                        [
                            new()
                            {
                                FlatPrice = new()
                                {
                                    Amount = 0,
                                    BillingCountryCode = "billingCountryCode",
                                    Currency =
                                        SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                                },
                                UnitPrice = new()
                                {
                                    Amount = 0,
                                    BillingCountryCode = "billingCountryCode",
                                    Currency =
                                        SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                                },
                                UpTo = 0,
                            },
                        ],
                    },
                ],
                ResourceID = "resourceId",
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
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason =
                    SubscriptionProvisionResponseDataSubscriptionCancelReason.UpgradeOrDowngrade,
                CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod =
                    SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.Charge,
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
                            Currency =
                                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Usd,
                        },
                        Tiers =
                        [
                            new()
                            {
                                FlatPrice = new()
                                {
                                    Amount = 0,
                                    BillingCountryCode = "billingCountryCode",
                                    Currency =
                                        SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                                },
                                UnitPrice = new()
                                {
                                    Amount = 0,
                                    BillingCountryCode = "billingCountryCode",
                                    Currency =
                                        SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                                },
                                UpTo = 0,
                            },
                        ],
                    },
                ],
                ResourceID = "resourceId",
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
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason =
                    SubscriptionProvisionResponseDataSubscriptionCancelReason.UpgradeOrDowngrade,
                CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod =
                    SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.Charge,
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
                            Currency =
                                SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Usd,
                        },
                        Tiers =
                        [
                            new()
                            {
                                FlatPrice = new()
                                {
                                    Amount = 0,
                                    BillingCountryCode = "billingCountryCode",
                                    Currency =
                                        SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                                },
                                UnitPrice = new()
                                {
                                    Amount = 0,
                                    BillingCountryCode = "billingCountryCode",
                                    Currency =
                                        SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                                },
                                UpTo = 0,
                            },
                        ],
                    },
                ],
                ResourceID = "resourceId",
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

public class EntitlementTest : TestBase
{
    [Fact]
    public void UnionObjectVariant0ValidationWorks()
    {
        Entitlement value = new UnionObjectVariant0()
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
        Entitlement value = new UnionObjectVariant1()
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
        Entitlement value = new UnionObjectVariant0()
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
        var deserialized = JsonSerializer.Deserialize<Entitlement>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnionObjectVariant1SerializationRoundtripWorks()
    {
        Entitlement value = new UnionObjectVariant1()
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
        var deserialized = JsonSerializer.Deserialize<Entitlement>(
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
        Feature expectedFeature = new()
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
        Feature expectedFeature = new()
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

public class FeatureTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Feature
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
        var model = new Feature
        {
            DisplayName = "displayName",
            FeatureStatus = FeatureStatus.New,
            FeatureType = FeatureType.Boolean,
            RefID = "refId",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Feature>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Feature
        {
            DisplayName = "displayName",
            FeatureStatus = FeatureStatus.New,
            FeatureType = FeatureType.Boolean,
            RefID = "refId",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Feature>(
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
        var model = new Feature
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
        var model = new Feature
        {
            DisplayName = "displayName",
            FeatureStatus = FeatureStatus.New,
            FeatureType = FeatureType.Boolean,
            RefID = "refId",
        };

        Feature copied = new(model);

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
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason =
                SubscriptionProvisionResponseDataSubscriptionCancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod =
                SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.Charge,
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
                        Currency =
                            SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Usd,
                    },
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                BillingCountryCode = "billingCountryCode",
                                Currency =
                                    SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                BillingCountryCode = "billingCountryCode",
                                Currency =
                                    SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            ResourceID = "resourceId",
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
        DateTimeOffset expectedCancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<
            string,
            SubscriptionProvisionResponseDataSubscriptionCancelReason
        > expectedCancelReason =
            SubscriptionProvisionResponseDataSubscriptionCancelReason.UpgradeOrDowngrade;
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
                BaseCharge = true,
                BlockSize = 0,
                FeatureID = "featureId",
                Price = new()
                {
                    Amount = 0,
                    BillingCountryCode = "billingCountryCode",
                    Currency = SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Usd,
                },
                Tiers =
                [
                    new()
                    {
                        FlatPrice = new()
                        {
                            Amount = 0,
                            BillingCountryCode = "billingCountryCode",
                            Currency =
                                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                        },
                        UnitPrice = new()
                        {
                            Amount = 0,
                            BillingCountryCode = "billingCountryCode",
                            Currency =
                                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                        },
                        UpTo = 0,
                    },
                ],
            },
        ];
        string expectedResourceID = "resourceId";
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
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason =
                SubscriptionProvisionResponseDataSubscriptionCancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod =
                SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.Charge,
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
                        Currency =
                            SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Usd,
                    },
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                BillingCountryCode = "billingCountryCode",
                                Currency =
                                    SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                BillingCountryCode = "billingCountryCode",
                                Currency =
                                    SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            ResourceID = "resourceId",
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
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason =
                SubscriptionProvisionResponseDataSubscriptionCancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod =
                SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.Charge,
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
                        Currency =
                            SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Usd,
                    },
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                BillingCountryCode = "billingCountryCode",
                                Currency =
                                    SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                BillingCountryCode = "billingCountryCode",
                                Currency =
                                    SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            ResourceID = "resourceId",
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
        DateTimeOffset expectedCancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<
            string,
            SubscriptionProvisionResponseDataSubscriptionCancelReason
        > expectedCancelReason =
            SubscriptionProvisionResponseDataSubscriptionCancelReason.UpgradeOrDowngrade;
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
                BaseCharge = true,
                BlockSize = 0,
                FeatureID = "featureId",
                Price = new()
                {
                    Amount = 0,
                    BillingCountryCode = "billingCountryCode",
                    Currency = SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Usd,
                },
                Tiers =
                [
                    new()
                    {
                        FlatPrice = new()
                        {
                            Amount = 0,
                            BillingCountryCode = "billingCountryCode",
                            Currency =
                                SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                        },
                        UnitPrice = new()
                        {
                            Amount = 0,
                            BillingCountryCode = "billingCountryCode",
                            Currency =
                                SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                        },
                        UpTo = 0,
                    },
                ],
            },
        ];
        string expectedResourceID = "resourceId";
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
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason =
                SubscriptionProvisionResponseDataSubscriptionCancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod =
                SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.Charge,
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
                        Currency =
                            SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Usd,
                    },
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                BillingCountryCode = "billingCountryCode",
                                Currency =
                                    SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                BillingCountryCode = "billingCountryCode",
                                Currency =
                                    SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            ResourceID = "resourceId",
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
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason =
                SubscriptionProvisionResponseDataSubscriptionCancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod =
                SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.Charge,
            ResourceID = "resourceId",
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.Addons);
        Assert.False(model.RawData.ContainsKey("addons"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.Prices);
        Assert.False(model.RawData.ContainsKey("prices"));
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
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason =
                SubscriptionProvisionResponseDataSubscriptionCancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod =
                SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.Charge,
            ResourceID = "resourceId",
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
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason =
                SubscriptionProvisionResponseDataSubscriptionCancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod =
                SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.Charge,
            ResourceID = "resourceId",
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            Addons = null,
            Metadata = null,
            Prices = null,
        };

        Assert.Null(model.Addons);
        Assert.False(model.RawData.ContainsKey("addons"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.Prices);
        Assert.False(model.RawData.ContainsKey("prices"));
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
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason =
                SubscriptionProvisionResponseDataSubscriptionCancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod =
                SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.Charge,
            ResourceID = "resourceId",
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            Addons = null,
            Metadata = null,
            Prices = null,
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
                        Currency =
                            SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Usd,
                    },
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                BillingCountryCode = "billingCountryCode",
                                Currency =
                                    SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                BillingCountryCode = "billingCountryCode",
                                Currency =
                                    SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
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
                        Currency =
                            SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Usd,
                    },
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                BillingCountryCode = "billingCountryCode",
                                Currency =
                                    SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                BillingCountryCode = "billingCountryCode",
                                Currency =
                                    SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
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
                        Currency =
                            SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Usd,
                    },
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                BillingCountryCode = "billingCountryCode",
                                Currency =
                                    SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                BillingCountryCode = "billingCountryCode",
                                Currency =
                                    SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],

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
                        Currency =
                            SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Usd,
                    },
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                BillingCountryCode = "billingCountryCode",
                                Currency =
                                    SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                BillingCountryCode = "billingCountryCode",
                                Currency =
                                    SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],

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
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason =
                SubscriptionProvisionResponseDataSubscriptionCancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod =
                SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod.Charge,
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
                        Currency =
                            SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Usd,
                    },
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                BillingCountryCode = "billingCountryCode",
                                Currency =
                                    SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                BillingCountryCode = "billingCountryCode",
                                Currency =
                                    SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            ResourceID = "resourceId",
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
            BaseCharge = true,
            BlockSize = 0,
            FeatureID = "featureId",
            Price = new()
            {
                Amount = 0,
                BillingCountryCode = "billingCountryCode",
                Currency = SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Usd,
            },
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
                        Currency =
                            SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
                        Currency =
                            SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
                    },
                    UpTo = 0,
                },
            ],
        };

        string expectedAddonID = "addonId";
        bool expectedBaseCharge = true;
        double expectedBlockSize = 0;
        string expectedFeatureID = "featureId";
        SubscriptionProvisionResponseDataSubscriptionPricePrice expectedPrice = new()
        {
            Amount = 0,
            BillingCountryCode = "billingCountryCode",
            Currency = SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Usd,
        };
        List<SubscriptionProvisionResponseDataSubscriptionPriceTier> expectedTiers =
        [
            new()
            {
                FlatPrice = new()
                {
                    Amount = 0,
                    BillingCountryCode = "billingCountryCode",
                    Currency =
                        SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                },
                UnitPrice = new()
                {
                    Amount = 0,
                    BillingCountryCode = "billingCountryCode",
                    Currency =
                        SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
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
        var model = new SubscriptionProvisionResponseDataSubscriptionPrice
        {
            AddonID = "addonId",
            BaseCharge = true,
            BlockSize = 0,
            FeatureID = "featureId",
            Price = new()
            {
                Amount = 0,
                BillingCountryCode = "billingCountryCode",
                Currency = SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Usd,
            },
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
                        Currency =
                            SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
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
            BaseCharge = true,
            BlockSize = 0,
            FeatureID = "featureId",
            Price = new()
            {
                Amount = 0,
                BillingCountryCode = "billingCountryCode",
                Currency = SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Usd,
            },
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
                        Currency =
                            SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
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
        bool expectedBaseCharge = true;
        double expectedBlockSize = 0;
        string expectedFeatureID = "featureId";
        SubscriptionProvisionResponseDataSubscriptionPricePrice expectedPrice = new()
        {
            Amount = 0,
            BillingCountryCode = "billingCountryCode",
            Currency = SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Usd,
        };
        List<SubscriptionProvisionResponseDataSubscriptionPriceTier> expectedTiers =
        [
            new()
            {
                FlatPrice = new()
                {
                    Amount = 0,
                    BillingCountryCode = "billingCountryCode",
                    Currency =
                        SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                },
                UnitPrice = new()
                {
                    Amount = 0,
                    BillingCountryCode = "billingCountryCode",
                    Currency =
                        SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
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
        var model = new SubscriptionProvisionResponseDataSubscriptionPrice
        {
            AddonID = "addonId",
            BaseCharge = true,
            BlockSize = 0,
            FeatureID = "featureId",
            Price = new()
            {
                Amount = 0,
                BillingCountryCode = "billingCountryCode",
                Currency = SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Usd,
            },
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
                        Currency =
                            SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
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
        var model = new SubscriptionProvisionResponseDataSubscriptionPrice
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
        var model = new SubscriptionProvisionResponseDataSubscriptionPrice
        {
            BaseCharge = true,
            BlockSize = 0,
            Price = new()
            {
                Amount = 0,
                BillingCountryCode = "billingCountryCode",
                Currency = SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Usd,
            },
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
                        Currency =
                            SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
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
            BaseCharge = true,
            BlockSize = 0,
            Price = new()
            {
                Amount = 0,
                BillingCountryCode = "billingCountryCode",
                Currency = SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Usd,
            },
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
                        Currency =
                            SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
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
            BaseCharge = true,
            BlockSize = 0,
            Price = new()
            {
                Amount = 0,
                BillingCountryCode = "billingCountryCode",
                Currency = SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Usd,
            },
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
                        Currency =
                            SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
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
            BaseCharge = true,
            BlockSize = 0,
            Price = new()
            {
                Amount = 0,
                BillingCountryCode = "billingCountryCode",
                Currency = SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Usd,
            },
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
                        Currency =
                            SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
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
            BaseCharge = true,
            BlockSize = 0,
            FeatureID = "featureId",
            Price = new()
            {
                Amount = 0,
                BillingCountryCode = "billingCountryCode",
                Currency = SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Usd,
            },
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
                        Currency =
                            SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
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

public class SubscriptionProvisionResponseDataSubscriptionPricePriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionPricePrice
        {
            Amount = 0,
            BillingCountryCode = "billingCountryCode",
            Currency = SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Usd,
        };

        double expectedAmount = 0;
        string expectedBillingCountryCode = "billingCountryCode";
        ApiEnum<
            string,
            SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency
        > expectedCurrency = SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedBillingCountryCode, model.BillingCountryCode);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionPricePrice
        {
            Amount = 0,
            BillingCountryCode = "billingCountryCode",
            Currency = SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Usd,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionProvisionResponseDataSubscriptionPricePrice>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionPricePrice
        {
            Amount = 0,
            BillingCountryCode = "billingCountryCode",
            Currency = SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Usd,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionProvisionResponseDataSubscriptionPricePrice>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        string expectedBillingCountryCode = "billingCountryCode";
        ApiEnum<
            string,
            SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency
        > expectedCurrency = SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedBillingCountryCode, deserialized.BillingCountryCode);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionPricePrice
        {
            Amount = 0,
            BillingCountryCode = "billingCountryCode",
            Currency = SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionPricePrice
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
        var model = new SubscriptionProvisionResponseDataSubscriptionPricePrice
        {
            BillingCountryCode = "billingCountryCode",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionPricePrice
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
        var model = new SubscriptionProvisionResponseDataSubscriptionPricePrice
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
        var model = new SubscriptionProvisionResponseDataSubscriptionPricePrice
        {
            Amount = 0,
            Currency = SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Usd,
        };

        Assert.Null(model.BillingCountryCode);
        Assert.False(model.RawData.ContainsKey("billingCountryCode"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionPricePrice
        {
            Amount = 0,
            Currency = SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionPricePrice
        {
            Amount = 0,
            Currency = SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Usd,

            BillingCountryCode = null,
        };

        Assert.Null(model.BillingCountryCode);
        Assert.True(model.RawData.ContainsKey("billingCountryCode"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionPricePrice
        {
            Amount = 0,
            Currency = SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Usd,

            BillingCountryCode = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionPricePrice
        {
            Amount = 0,
            BillingCountryCode = "billingCountryCode",
            Currency = SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Usd,
        };

        SubscriptionProvisionResponseDataSubscriptionPricePrice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionProvisionResponseDataSubscriptionPricePriceCurrencyTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Usd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Aed)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.All)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Amd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Ang)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Aud)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Awg)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Azn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Bam)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Bbd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Bdt)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Bgn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Bif)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Bmd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Bnd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Bsd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Bwp)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Byn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Bzd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Brl)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Cad)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Cdf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Chf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Cny)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Czk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Dkk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Dop)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Dzd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Egp)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Etb)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Eur)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Fjd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Gbp)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Gel)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Gip)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Gmd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Gyd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Hkd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Hrk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Htg)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Idr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Ils)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Inr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Isk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Jmd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Jpy)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Kes)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Kgs)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Khr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Kmf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Krw)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Kyd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Kzt)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Lbp)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Lkr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Lrd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Lsl)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Mad)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Mdl)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Mga)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Mkd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Mmk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Mnt)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Mop)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Mro)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Mvr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Mwk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Mxn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Myr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Mzn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Nad)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Ngn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Nok)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Npr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Nzd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Pgk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Php)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Pkr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Pln)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Qar)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Ron)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Rsd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Rub)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Rwf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Sar)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Sbd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Scr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Sek)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Sgd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Sle)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Sll)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Sos)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Szl)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Thb)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Tjs)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Top)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Try)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Ttd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Tzs)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Uah)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Uzs)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Vnd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Vuv)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Wst)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Xaf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Xcd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Yer)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Zar)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Zmw)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Clp)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Djf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Gnf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Ugx)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Pyg)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Xof)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Xpf)]
    public void Validation_Works(
        SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Usd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Aed)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.All)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Amd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Ang)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Aud)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Awg)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Azn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Bam)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Bbd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Bdt)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Bgn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Bif)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Bmd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Bnd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Bsd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Bwp)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Byn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Bzd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Brl)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Cad)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Cdf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Chf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Cny)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Czk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Dkk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Dop)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Dzd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Egp)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Etb)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Eur)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Fjd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Gbp)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Gel)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Gip)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Gmd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Gyd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Hkd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Hrk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Htg)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Idr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Ils)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Inr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Isk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Jmd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Jpy)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Kes)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Kgs)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Khr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Kmf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Krw)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Kyd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Kzt)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Lbp)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Lkr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Lrd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Lsl)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Mad)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Mdl)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Mga)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Mkd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Mmk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Mnt)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Mop)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Mro)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Mvr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Mwk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Mxn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Myr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Mzn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Nad)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Ngn)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Nok)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Npr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Nzd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Pgk)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Php)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Pkr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Pln)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Qar)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Ron)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Rsd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Rub)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Rwf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Sar)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Sbd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Scr)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Sek)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Sgd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Sle)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Sll)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Sos)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Szl)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Thb)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Tjs)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Top)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Try)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Ttd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Tzs)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Uah)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Uzs)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Vnd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Vuv)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Wst)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Xaf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Xcd)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Yer)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Zar)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Zmw)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Clp)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Djf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Gnf)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Ugx)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Pyg)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Xof)]
    [InlineData(SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency.Xpf)]
    public void SerializationRoundtrip_Works(
        SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency>
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
                BillingCountryCode = "billingCountryCode",
                Currency =
                    SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
            },
            UnitPrice = new()
            {
                Amount = 0,
                BillingCountryCode = "billingCountryCode",
                Currency =
                    SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
            },
            UpTo = 0,
        };

        SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPrice expectedFlatPrice = new()
        {
            Amount = 0,
            BillingCountryCode = "billingCountryCode",
            Currency = SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
        };
        SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPrice expectedUnitPrice = new()
        {
            Amount = 0,
            BillingCountryCode = "billingCountryCode",
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
                BillingCountryCode = "billingCountryCode",
                Currency =
                    SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
            },
            UnitPrice = new()
            {
                Amount = 0,
                BillingCountryCode = "billingCountryCode",
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
                BillingCountryCode = "billingCountryCode",
                Currency =
                    SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
            },
            UnitPrice = new()
            {
                Amount = 0,
                BillingCountryCode = "billingCountryCode",
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
            BillingCountryCode = "billingCountryCode",
            Currency = SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
        };
        SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPrice expectedUnitPrice = new()
        {
            Amount = 0,
            BillingCountryCode = "billingCountryCode",
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
                BillingCountryCode = "billingCountryCode",
                Currency =
                    SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
            },
            UnitPrice = new()
            {
                Amount = 0,
                BillingCountryCode = "billingCountryCode",
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
                BillingCountryCode = "billingCountryCode",
                Currency =
                    SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
            },
            UnitPrice = new()
            {
                Amount = 0,
                BillingCountryCode = "billingCountryCode",
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
            BillingCountryCode = "billingCountryCode",
            Currency = SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
        };

        double expectedAmount = 0;
        string expectedBillingCountryCode = "billingCountryCode";
        ApiEnum<
            string,
            SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency
        > expectedCurrency =
            SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedBillingCountryCode, model.BillingCountryCode);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPrice
        {
            Amount = 0,
            BillingCountryCode = "billingCountryCode",
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
            BillingCountryCode = "billingCountryCode",
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
        string expectedBillingCountryCode = "billingCountryCode";
        ApiEnum<
            string,
            SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency
        > expectedCurrency =
            SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedBillingCountryCode, deserialized.BillingCountryCode);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPrice
        {
            Amount = 0,
            BillingCountryCode = "billingCountryCode",
            Currency = SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPrice
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
        var model = new SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPrice
        {
            BillingCountryCode = "billingCountryCode",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPrice
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
        var model = new SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPrice
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
        var model = new SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPrice
        {
            Amount = 0,
            Currency = SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
        };

        Assert.Null(model.BillingCountryCode);
        Assert.False(model.RawData.ContainsKey("billingCountryCode"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPrice
        {
            Amount = 0,
            Currency = SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPrice
        {
            Amount = 0,
            Currency = SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,

            BillingCountryCode = null,
        };

        Assert.Null(model.BillingCountryCode);
        Assert.True(model.RawData.ContainsKey("billingCountryCode"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPrice
        {
            Amount = 0,
            Currency = SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency.Usd,

            BillingCountryCode = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPrice
        {
            Amount = 0,
            BillingCountryCode = "billingCountryCode",
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
            BillingCountryCode = "billingCountryCode",
            Currency = SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
        };

        double expectedAmount = 0;
        string expectedBillingCountryCode = "billingCountryCode";
        ApiEnum<
            string,
            SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency
        > expectedCurrency =
            SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedBillingCountryCode, model.BillingCountryCode);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPrice
        {
            Amount = 0,
            BillingCountryCode = "billingCountryCode",
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
            BillingCountryCode = "billingCountryCode",
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
        string expectedBillingCountryCode = "billingCountryCode";
        ApiEnum<
            string,
            SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency
        > expectedCurrency =
            SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedBillingCountryCode, deserialized.BillingCountryCode);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPrice
        {
            Amount = 0,
            BillingCountryCode = "billingCountryCode",
            Currency = SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPrice
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
        var model = new SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPrice
        {
            BillingCountryCode = "billingCountryCode",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPrice
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
        var model = new SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPrice
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
        var model = new SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPrice
        {
            Amount = 0,
            Currency = SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
        };

        Assert.Null(model.BillingCountryCode);
        Assert.False(model.RawData.ContainsKey("billingCountryCode"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPrice
        {
            Amount = 0,
            Currency = SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPrice
        {
            Amount = 0,
            Currency = SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,

            BillingCountryCode = null,
        };

        Assert.Null(model.BillingCountryCode);
        Assert.True(model.RawData.ContainsKey("billingCountryCode"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPrice
        {
            Amount = 0,
            Currency = SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency.Usd,

            BillingCountryCode = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPrice
        {
            Amount = 0,
            BillingCountryCode = "billingCountryCode",
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
