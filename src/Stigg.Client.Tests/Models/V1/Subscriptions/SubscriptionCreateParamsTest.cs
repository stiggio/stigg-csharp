using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Subscriptions = Stigg.Client.Models.V1.Subscriptions;

namespace Stigg.Client.Tests.Models.V1.Subscriptions;

public class SubscriptionCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new Subscriptions::SubscriptionCreateParams
        {
            CustomerID = "customerId",
            PlanID = "planId",
            ID = "id",
            Addons = [new() { AddonID = "addonId", Quantity = 1 }],
            AppliedCoupon = new()
            {
                BillingCouponID = "billingCouponId",
                Configuration = new()
                {
                    StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                CouponID = "couponId",
                Discount = new()
                {
                    AmountsOff = [new() { Amount = 0, Currency = Subscriptions::Currency.Usd }],
                    Description = "description",
                    DurationInMonths = 1,
                    Name = "name",
                    PercentOff = 1,
                },
                PromotionCode = "promotionCode",
            },
            AwaitPaymentConfirmation = true,
            BillingCountryCode = "billingCountryCode",
            BillingID = "billingId",
            BillingInformation = new()
            {
                BillingAddress = new()
                {
                    City = "city",
                    Country = "country",
                    Line1 = "line1",
                    Line2 = "line2",
                    PostalCode = "postalCode",
                    State = "state",
                },
                ChargeOnBehalfOfAccount = "chargeOnBehalfOfAccount",
                IntegrationID = "integrationId",
                InvoiceDaysUntilDue = 0,
                IsBackdated = true,
                IsInvoicePaid = true,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                ProrationBehavior = Subscriptions::ProrationBehavior.InvoiceImmediately,
                TaxIds = [new() { Type = "type", Value = "value" }],
                TaxPercentage = 0,
                TaxRateIds = ["string"],
            },
            BillingPeriod = Subscriptions::BillingPeriod.Monthly,
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            Charges =
            [
                new()
                {
                    ID = "id",
                    Quantity = 1,
                    Type = Subscriptions::Type.Feature,
                },
            ],
            CheckoutOptions = new()
            {
                CancelUrl = "https://example.com",
                SuccessUrl = "https://example.com",
                AllowPromoCodes = true,
                AllowTaxIDCollection = true,
                CollectBillingAddress = true,
                CollectPhoneNumber = true,
                ReferenceID = "referenceId",
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MinimumSpend = new()
            {
                Minimum = new()
                {
                    Amount = 0,
                    BillingCountryCode = "billingCountryCode",
                    Currency = Subscriptions::MinimumCurrency.Usd,
                },
            },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod = Subscriptions::PaymentCollectionMethod.Charge,
            PriceOverrides =
            [
                new()
                {
                    AddonID = "addonId",
                    BaseCharge = true,
                    BlockSize = 0,
                    CreditGrantCadence = Subscriptions::CreditGrantCadence.BeginningOfBillingPeriod,
                    CreditRate = new()
                    {
                        Amount = 1,
                        CurrencyID = "currencyId",
                        CostFormula = "costFormula",
                    },
                    FeatureID = "featureId",
                    Price = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
                        Currency = Subscriptions::PriceCurrency.Usd,
                    },
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                BillingCountryCode = "billingCountryCode",
                                Currency = Subscriptions::FlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                BillingCountryCode = "billingCountryCode",
                                Currency = Subscriptions::UnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            ResourceID = "resourceId",
            SalesforceID = "salesforceId",
            ScheduleStrategy = Subscriptions::ScheduleStrategy.EndOfBillingPeriod,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SubscriptionEntitlements =
            [
                new()
                {
                    FeatureID = "featureId",
                    UsageLimit = 0,
                    IsGranted = true,
                },
            ],
            TrialOverrideConfiguration = new()
            {
                IsTrial = true,
                TrialEndBehavior = Subscriptions::TrialEndBehavior.ConvertToPaid,
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            UnitQuantity = 1,
        };

        string expectedCustomerID = "customerId";
        string expectedPlanID = "planId";
        string expectedID = "id";
        List<Subscriptions::Addon> expectedAddons = [new() { AddonID = "addonId", Quantity = 1 }];
        Subscriptions::AppliedCoupon expectedAppliedCoupon = new()
        {
            BillingCouponID = "billingCouponId",
            Configuration = new() { StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z") },
            CouponID = "couponId",
            Discount = new()
            {
                AmountsOff = [new() { Amount = 0, Currency = Subscriptions::Currency.Usd }],
                Description = "description",
                DurationInMonths = 1,
                Name = "name",
                PercentOff = 1,
            },
            PromotionCode = "promotionCode",
        };
        bool expectedAwaitPaymentConfirmation = true;
        string expectedBillingCountryCode = "billingCountryCode";
        string expectedBillingID = "billingId";
        Subscriptions::BillingInformation expectedBillingInformation = new()
        {
            BillingAddress = new()
            {
                City = "city",
                Country = "country",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postalCode",
                State = "state",
            },
            ChargeOnBehalfOfAccount = "chargeOnBehalfOfAccount",
            IntegrationID = "integrationId",
            InvoiceDaysUntilDue = 0,
            IsBackdated = true,
            IsInvoicePaid = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ProrationBehavior = Subscriptions::ProrationBehavior.InvoiceImmediately,
            TaxIds = [new() { Type = "type", Value = "value" }],
            TaxPercentage = 0,
            TaxRateIds = ["string"],
        };
        ApiEnum<string, Subscriptions::BillingPeriod> expectedBillingPeriod =
            Subscriptions::BillingPeriod.Monthly;
        Subscriptions::Budget expectedBudget = new() { HasSoftLimit = true, Limit = 0 };
        List<Subscriptions::Charge> expectedCharges =
        [
            new()
            {
                ID = "id",
                Quantity = 1,
                Type = Subscriptions::Type.Feature,
            },
        ];
        Subscriptions::CheckoutOptions expectedCheckoutOptions = new()
        {
            CancelUrl = "https://example.com",
            SuccessUrl = "https://example.com",
            AllowPromoCodes = true,
            AllowTaxIDCollection = true,
            CollectBillingAddress = true,
            CollectPhoneNumber = true,
            ReferenceID = "referenceId",
        };
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        Subscriptions::MinimumSpend expectedMinimumSpend = new()
        {
            Minimum = new()
            {
                Amount = 0,
                BillingCountryCode = "billingCountryCode",
                Currency = Subscriptions::MinimumCurrency.Usd,
            },
        };
        string expectedPayingCustomerID = "payingCustomerId";
        ApiEnum<string, Subscriptions::PaymentCollectionMethod> expectedPaymentCollectionMethod =
            Subscriptions::PaymentCollectionMethod.Charge;
        List<Subscriptions::PriceOverride> expectedPriceOverrides =
        [
            new()
            {
                AddonID = "addonId",
                BaseCharge = true,
                BlockSize = 0,
                CreditGrantCadence = Subscriptions::CreditGrantCadence.BeginningOfBillingPeriod,
                CreditRate = new()
                {
                    Amount = 1,
                    CurrencyID = "currencyId",
                    CostFormula = "costFormula",
                },
                FeatureID = "featureId",
                Price = new()
                {
                    Amount = 0,
                    BillingCountryCode = "billingCountryCode",
                    Currency = Subscriptions::PriceCurrency.Usd,
                },
                Tiers =
                [
                    new()
                    {
                        FlatPrice = new()
                        {
                            Amount = 0,
                            BillingCountryCode = "billingCountryCode",
                            Currency = Subscriptions::FlatPriceCurrency.Usd,
                        },
                        UnitPrice = new()
                        {
                            Amount = 0,
                            BillingCountryCode = "billingCountryCode",
                            Currency = Subscriptions::UnitPriceCurrency.Usd,
                        },
                        UpTo = 0,
                    },
                ],
            },
        ];
        string expectedResourceID = "resourceId";
        string expectedSalesforceID = "salesforceId";
        ApiEnum<string, Subscriptions::ScheduleStrategy> expectedScheduleStrategy =
            Subscriptions::ScheduleStrategy.EndOfBillingPeriod;
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<Subscriptions::SubscriptionEntitlement> expectedSubscriptionEntitlements =
        [
            new()
            {
                FeatureID = "featureId",
                UsageLimit = 0,
                IsGranted = true,
            },
        ];
        Subscriptions::TrialOverrideConfiguration expectedTrialOverrideConfiguration = new()
        {
            IsTrial = true,
            TrialEndBehavior = Subscriptions::TrialEndBehavior.ConvertToPaid,
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        double expectedUnitQuantity = 1;

        Assert.Equal(expectedCustomerID, parameters.CustomerID);
        Assert.Equal(expectedPlanID, parameters.PlanID);
        Assert.Equal(expectedID, parameters.ID);
        Assert.NotNull(parameters.Addons);
        Assert.Equal(expectedAddons.Count, parameters.Addons.Count);
        for (int i = 0; i < expectedAddons.Count; i++)
        {
            Assert.Equal(expectedAddons[i], parameters.Addons[i]);
        }
        Assert.Equal(expectedAppliedCoupon, parameters.AppliedCoupon);
        Assert.Equal(expectedAwaitPaymentConfirmation, parameters.AwaitPaymentConfirmation);
        Assert.Equal(expectedBillingCountryCode, parameters.BillingCountryCode);
        Assert.Equal(expectedBillingID, parameters.BillingID);
        Assert.Equal(expectedBillingInformation, parameters.BillingInformation);
        Assert.Equal(expectedBillingPeriod, parameters.BillingPeriod);
        Assert.Equal(expectedBudget, parameters.Budget);
        Assert.NotNull(parameters.Charges);
        Assert.Equal(expectedCharges.Count, parameters.Charges.Count);
        for (int i = 0; i < expectedCharges.Count; i++)
        {
            Assert.Equal(expectedCharges[i], parameters.Charges[i]);
        }
        Assert.Equal(expectedCheckoutOptions, parameters.CheckoutOptions);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
        Assert.Equal(expectedMinimumSpend, parameters.MinimumSpend);
        Assert.Equal(expectedPayingCustomerID, parameters.PayingCustomerID);
        Assert.Equal(expectedPaymentCollectionMethod, parameters.PaymentCollectionMethod);
        Assert.NotNull(parameters.PriceOverrides);
        Assert.Equal(expectedPriceOverrides.Count, parameters.PriceOverrides.Count);
        for (int i = 0; i < expectedPriceOverrides.Count; i++)
        {
            Assert.Equal(expectedPriceOverrides[i], parameters.PriceOverrides[i]);
        }
        Assert.Equal(expectedResourceID, parameters.ResourceID);
        Assert.Equal(expectedSalesforceID, parameters.SalesforceID);
        Assert.Equal(expectedScheduleStrategy, parameters.ScheduleStrategy);
        Assert.Equal(expectedStartDate, parameters.StartDate);
        Assert.NotNull(parameters.SubscriptionEntitlements);
        Assert.Equal(
            expectedSubscriptionEntitlements.Count,
            parameters.SubscriptionEntitlements.Count
        );
        for (int i = 0; i < expectedSubscriptionEntitlements.Count; i++)
        {
            Assert.Equal(
                expectedSubscriptionEntitlements[i],
                parameters.SubscriptionEntitlements[i]
            );
        }
        Assert.Equal(expectedTrialOverrideConfiguration, parameters.TrialOverrideConfiguration);
        Assert.Equal(expectedUnitQuantity, parameters.UnitQuantity);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Subscriptions::SubscriptionCreateParams
        {
            CustomerID = "customerId",
            PlanID = "planId",
            ID = "id",
            BillingCountryCode = "billingCountryCode",
            BillingID = "billingId",
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            MinimumSpend = new()
            {
                Minimum = new()
                {
                    Amount = 0,
                    BillingCountryCode = "billingCountryCode",
                    Currency = Subscriptions::MinimumCurrency.Usd,
                },
            },
            PayingCustomerID = "payingCustomerId",
            ResourceID = "resourceId",
            SalesforceID = "salesforceId",
        };

        Assert.Null(parameters.Addons);
        Assert.False(parameters.RawBodyData.ContainsKey("addons"));
        Assert.Null(parameters.AppliedCoupon);
        Assert.False(parameters.RawBodyData.ContainsKey("appliedCoupon"));
        Assert.Null(parameters.AwaitPaymentConfirmation);
        Assert.False(parameters.RawBodyData.ContainsKey("awaitPaymentConfirmation"));
        Assert.Null(parameters.BillingInformation);
        Assert.False(parameters.RawBodyData.ContainsKey("billingInformation"));
        Assert.Null(parameters.BillingPeriod);
        Assert.False(parameters.RawBodyData.ContainsKey("billingPeriod"));
        Assert.Null(parameters.Charges);
        Assert.False(parameters.RawBodyData.ContainsKey("charges"));
        Assert.Null(parameters.CheckoutOptions);
        Assert.False(parameters.RawBodyData.ContainsKey("checkoutOptions"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.PaymentCollectionMethod);
        Assert.False(parameters.RawBodyData.ContainsKey("paymentCollectionMethod"));
        Assert.Null(parameters.PriceOverrides);
        Assert.False(parameters.RawBodyData.ContainsKey("priceOverrides"));
        Assert.Null(parameters.ScheduleStrategy);
        Assert.False(parameters.RawBodyData.ContainsKey("scheduleStrategy"));
        Assert.Null(parameters.StartDate);
        Assert.False(parameters.RawBodyData.ContainsKey("startDate"));
        Assert.Null(parameters.SubscriptionEntitlements);
        Assert.False(parameters.RawBodyData.ContainsKey("subscriptionEntitlements"));
        Assert.Null(parameters.TrialOverrideConfiguration);
        Assert.False(parameters.RawBodyData.ContainsKey("trialOverrideConfiguration"));
        Assert.Null(parameters.UnitQuantity);
        Assert.False(parameters.RawBodyData.ContainsKey("unitQuantity"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new Subscriptions::SubscriptionCreateParams
        {
            CustomerID = "customerId",
            PlanID = "planId",
            ID = "id",
            BillingCountryCode = "billingCountryCode",
            BillingID = "billingId",
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            MinimumSpend = new()
            {
                Minimum = new()
                {
                    Amount = 0,
                    BillingCountryCode = "billingCountryCode",
                    Currency = Subscriptions::MinimumCurrency.Usd,
                },
            },
            PayingCustomerID = "payingCustomerId",
            ResourceID = "resourceId",
            SalesforceID = "salesforceId",

            // Null should be interpreted as omitted for these properties
            Addons = null,
            AppliedCoupon = null,
            AwaitPaymentConfirmation = null,
            BillingInformation = null,
            BillingPeriod = null,
            Charges = null,
            CheckoutOptions = null,
            Metadata = null,
            PaymentCollectionMethod = null,
            PriceOverrides = null,
            ScheduleStrategy = null,
            StartDate = null,
            SubscriptionEntitlements = null,
            TrialOverrideConfiguration = null,
            UnitQuantity = null,
        };

        Assert.Null(parameters.Addons);
        Assert.False(parameters.RawBodyData.ContainsKey("addons"));
        Assert.Null(parameters.AppliedCoupon);
        Assert.False(parameters.RawBodyData.ContainsKey("appliedCoupon"));
        Assert.Null(parameters.AwaitPaymentConfirmation);
        Assert.False(parameters.RawBodyData.ContainsKey("awaitPaymentConfirmation"));
        Assert.Null(parameters.BillingInformation);
        Assert.False(parameters.RawBodyData.ContainsKey("billingInformation"));
        Assert.Null(parameters.BillingPeriod);
        Assert.False(parameters.RawBodyData.ContainsKey("billingPeriod"));
        Assert.Null(parameters.Charges);
        Assert.False(parameters.RawBodyData.ContainsKey("charges"));
        Assert.Null(parameters.CheckoutOptions);
        Assert.False(parameters.RawBodyData.ContainsKey("checkoutOptions"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.PaymentCollectionMethod);
        Assert.False(parameters.RawBodyData.ContainsKey("paymentCollectionMethod"));
        Assert.Null(parameters.PriceOverrides);
        Assert.False(parameters.RawBodyData.ContainsKey("priceOverrides"));
        Assert.Null(parameters.ScheduleStrategy);
        Assert.False(parameters.RawBodyData.ContainsKey("scheduleStrategy"));
        Assert.Null(parameters.StartDate);
        Assert.False(parameters.RawBodyData.ContainsKey("startDate"));
        Assert.Null(parameters.SubscriptionEntitlements);
        Assert.False(parameters.RawBodyData.ContainsKey("subscriptionEntitlements"));
        Assert.Null(parameters.TrialOverrideConfiguration);
        Assert.False(parameters.RawBodyData.ContainsKey("trialOverrideConfiguration"));
        Assert.Null(parameters.UnitQuantity);
        Assert.False(parameters.RawBodyData.ContainsKey("unitQuantity"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Subscriptions::SubscriptionCreateParams
        {
            CustomerID = "customerId",
            PlanID = "planId",
            Addons = [new() { AddonID = "addonId", Quantity = 1 }],
            AppliedCoupon = new()
            {
                BillingCouponID = "billingCouponId",
                Configuration = new()
                {
                    StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                CouponID = "couponId",
                Discount = new()
                {
                    AmountsOff = [new() { Amount = 0, Currency = Subscriptions::Currency.Usd }],
                    Description = "description",
                    DurationInMonths = 1,
                    Name = "name",
                    PercentOff = 1,
                },
                PromotionCode = "promotionCode",
            },
            AwaitPaymentConfirmation = true,
            BillingInformation = new()
            {
                BillingAddress = new()
                {
                    City = "city",
                    Country = "country",
                    Line1 = "line1",
                    Line2 = "line2",
                    PostalCode = "postalCode",
                    State = "state",
                },
                ChargeOnBehalfOfAccount = "chargeOnBehalfOfAccount",
                IntegrationID = "integrationId",
                InvoiceDaysUntilDue = 0,
                IsBackdated = true,
                IsInvoicePaid = true,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                ProrationBehavior = Subscriptions::ProrationBehavior.InvoiceImmediately,
                TaxIds = [new() { Type = "type", Value = "value" }],
                TaxPercentage = 0,
                TaxRateIds = ["string"],
            },
            BillingPeriod = Subscriptions::BillingPeriod.Monthly,
            Charges =
            [
                new()
                {
                    ID = "id",
                    Quantity = 1,
                    Type = Subscriptions::Type.Feature,
                },
            ],
            CheckoutOptions = new()
            {
                CancelUrl = "https://example.com",
                SuccessUrl = "https://example.com",
                AllowPromoCodes = true,
                AllowTaxIDCollection = true,
                CollectBillingAddress = true,
                CollectPhoneNumber = true,
                ReferenceID = "referenceId",
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentCollectionMethod = Subscriptions::PaymentCollectionMethod.Charge,
            PriceOverrides =
            [
                new()
                {
                    AddonID = "addonId",
                    BaseCharge = true,
                    BlockSize = 0,
                    CreditGrantCadence = Subscriptions::CreditGrantCadence.BeginningOfBillingPeriod,
                    CreditRate = new()
                    {
                        Amount = 1,
                        CurrencyID = "currencyId",
                        CostFormula = "costFormula",
                    },
                    FeatureID = "featureId",
                    Price = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
                        Currency = Subscriptions::PriceCurrency.Usd,
                    },
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                BillingCountryCode = "billingCountryCode",
                                Currency = Subscriptions::FlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                BillingCountryCode = "billingCountryCode",
                                Currency = Subscriptions::UnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            ScheduleStrategy = Subscriptions::ScheduleStrategy.EndOfBillingPeriod,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SubscriptionEntitlements =
            [
                new()
                {
                    FeatureID = "featureId",
                    UsageLimit = 0,
                    IsGranted = true,
                },
            ],
            TrialOverrideConfiguration = new()
            {
                IsTrial = true,
                TrialEndBehavior = Subscriptions::TrialEndBehavior.ConvertToPaid,
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            UnitQuantity = 1,
        };

        Assert.Null(parameters.ID);
        Assert.False(parameters.RawBodyData.ContainsKey("id"));
        Assert.Null(parameters.BillingCountryCode);
        Assert.False(parameters.RawBodyData.ContainsKey("billingCountryCode"));
        Assert.Null(parameters.BillingID);
        Assert.False(parameters.RawBodyData.ContainsKey("billingId"));
        Assert.Null(parameters.Budget);
        Assert.False(parameters.RawBodyData.ContainsKey("budget"));
        Assert.Null(parameters.MinimumSpend);
        Assert.False(parameters.RawBodyData.ContainsKey("minimumSpend"));
        Assert.Null(parameters.PayingCustomerID);
        Assert.False(parameters.RawBodyData.ContainsKey("payingCustomerId"));
        Assert.Null(parameters.ResourceID);
        Assert.False(parameters.RawBodyData.ContainsKey("resourceId"));
        Assert.Null(parameters.SalesforceID);
        Assert.False(parameters.RawBodyData.ContainsKey("salesforceId"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new Subscriptions::SubscriptionCreateParams
        {
            CustomerID = "customerId",
            PlanID = "planId",
            Addons = [new() { AddonID = "addonId", Quantity = 1 }],
            AppliedCoupon = new()
            {
                BillingCouponID = "billingCouponId",
                Configuration = new()
                {
                    StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                CouponID = "couponId",
                Discount = new()
                {
                    AmountsOff = [new() { Amount = 0, Currency = Subscriptions::Currency.Usd }],
                    Description = "description",
                    DurationInMonths = 1,
                    Name = "name",
                    PercentOff = 1,
                },
                PromotionCode = "promotionCode",
            },
            AwaitPaymentConfirmation = true,
            BillingInformation = new()
            {
                BillingAddress = new()
                {
                    City = "city",
                    Country = "country",
                    Line1 = "line1",
                    Line2 = "line2",
                    PostalCode = "postalCode",
                    State = "state",
                },
                ChargeOnBehalfOfAccount = "chargeOnBehalfOfAccount",
                IntegrationID = "integrationId",
                InvoiceDaysUntilDue = 0,
                IsBackdated = true,
                IsInvoicePaid = true,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                ProrationBehavior = Subscriptions::ProrationBehavior.InvoiceImmediately,
                TaxIds = [new() { Type = "type", Value = "value" }],
                TaxPercentage = 0,
                TaxRateIds = ["string"],
            },
            BillingPeriod = Subscriptions::BillingPeriod.Monthly,
            Charges =
            [
                new()
                {
                    ID = "id",
                    Quantity = 1,
                    Type = Subscriptions::Type.Feature,
                },
            ],
            CheckoutOptions = new()
            {
                CancelUrl = "https://example.com",
                SuccessUrl = "https://example.com",
                AllowPromoCodes = true,
                AllowTaxIDCollection = true,
                CollectBillingAddress = true,
                CollectPhoneNumber = true,
                ReferenceID = "referenceId",
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentCollectionMethod = Subscriptions::PaymentCollectionMethod.Charge,
            PriceOverrides =
            [
                new()
                {
                    AddonID = "addonId",
                    BaseCharge = true,
                    BlockSize = 0,
                    CreditGrantCadence = Subscriptions::CreditGrantCadence.BeginningOfBillingPeriod,
                    CreditRate = new()
                    {
                        Amount = 1,
                        CurrencyID = "currencyId",
                        CostFormula = "costFormula",
                    },
                    FeatureID = "featureId",
                    Price = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
                        Currency = Subscriptions::PriceCurrency.Usd,
                    },
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                BillingCountryCode = "billingCountryCode",
                                Currency = Subscriptions::FlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                BillingCountryCode = "billingCountryCode",
                                Currency = Subscriptions::UnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            ScheduleStrategy = Subscriptions::ScheduleStrategy.EndOfBillingPeriod,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SubscriptionEntitlements =
            [
                new()
                {
                    FeatureID = "featureId",
                    UsageLimit = 0,
                    IsGranted = true,
                },
            ],
            TrialOverrideConfiguration = new()
            {
                IsTrial = true,
                TrialEndBehavior = Subscriptions::TrialEndBehavior.ConvertToPaid,
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            UnitQuantity = 1,

            ID = null,
            BillingCountryCode = null,
            BillingID = null,
            Budget = null,
            MinimumSpend = null,
            PayingCustomerID = null,
            ResourceID = null,
            SalesforceID = null,
        };

        Assert.Null(parameters.ID);
        Assert.True(parameters.RawBodyData.ContainsKey("id"));
        Assert.Null(parameters.BillingCountryCode);
        Assert.True(parameters.RawBodyData.ContainsKey("billingCountryCode"));
        Assert.Null(parameters.BillingID);
        Assert.True(parameters.RawBodyData.ContainsKey("billingId"));
        Assert.Null(parameters.Budget);
        Assert.True(parameters.RawBodyData.ContainsKey("budget"));
        Assert.Null(parameters.MinimumSpend);
        Assert.True(parameters.RawBodyData.ContainsKey("minimumSpend"));
        Assert.Null(parameters.PayingCustomerID);
        Assert.True(parameters.RawBodyData.ContainsKey("payingCustomerId"));
        Assert.Null(parameters.ResourceID);
        Assert.True(parameters.RawBodyData.ContainsKey("resourceId"));
        Assert.Null(parameters.SalesforceID);
        Assert.True(parameters.RawBodyData.ContainsKey("salesforceId"));
    }

    [Fact]
    public void Url_Works()
    {
        Subscriptions::SubscriptionCreateParams parameters = new()
        {
            CustomerID = "customerId",
            PlanID = "planId",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.example.com/api/v1/subscriptions"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new Subscriptions::SubscriptionCreateParams
        {
            CustomerID = "customerId",
            PlanID = "planId",
            ID = "id",
            Addons = [new() { AddonID = "addonId", Quantity = 1 }],
            AppliedCoupon = new()
            {
                BillingCouponID = "billingCouponId",
                Configuration = new()
                {
                    StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                CouponID = "couponId",
                Discount = new()
                {
                    AmountsOff = [new() { Amount = 0, Currency = Subscriptions::Currency.Usd }],
                    Description = "description",
                    DurationInMonths = 1,
                    Name = "name",
                    PercentOff = 1,
                },
                PromotionCode = "promotionCode",
            },
            AwaitPaymentConfirmation = true,
            BillingCountryCode = "billingCountryCode",
            BillingID = "billingId",
            BillingInformation = new()
            {
                BillingAddress = new()
                {
                    City = "city",
                    Country = "country",
                    Line1 = "line1",
                    Line2 = "line2",
                    PostalCode = "postalCode",
                    State = "state",
                },
                ChargeOnBehalfOfAccount = "chargeOnBehalfOfAccount",
                IntegrationID = "integrationId",
                InvoiceDaysUntilDue = 0,
                IsBackdated = true,
                IsInvoicePaid = true,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                ProrationBehavior = Subscriptions::ProrationBehavior.InvoiceImmediately,
                TaxIds = [new() { Type = "type", Value = "value" }],
                TaxPercentage = 0,
                TaxRateIds = ["string"],
            },
            BillingPeriod = Subscriptions::BillingPeriod.Monthly,
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            Charges =
            [
                new()
                {
                    ID = "id",
                    Quantity = 1,
                    Type = Subscriptions::Type.Feature,
                },
            ],
            CheckoutOptions = new()
            {
                CancelUrl = "https://example.com",
                SuccessUrl = "https://example.com",
                AllowPromoCodes = true,
                AllowTaxIDCollection = true,
                CollectBillingAddress = true,
                CollectPhoneNumber = true,
                ReferenceID = "referenceId",
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MinimumSpend = new()
            {
                Minimum = new()
                {
                    Amount = 0,
                    BillingCountryCode = "billingCountryCode",
                    Currency = Subscriptions::MinimumCurrency.Usd,
                },
            },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod = Subscriptions::PaymentCollectionMethod.Charge,
            PriceOverrides =
            [
                new()
                {
                    AddonID = "addonId",
                    BaseCharge = true,
                    BlockSize = 0,
                    CreditGrantCadence = Subscriptions::CreditGrantCadence.BeginningOfBillingPeriod,
                    CreditRate = new()
                    {
                        Amount = 1,
                        CurrencyID = "currencyId",
                        CostFormula = "costFormula",
                    },
                    FeatureID = "featureId",
                    Price = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
                        Currency = Subscriptions::PriceCurrency.Usd,
                    },
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                BillingCountryCode = "billingCountryCode",
                                Currency = Subscriptions::FlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                BillingCountryCode = "billingCountryCode",
                                Currency = Subscriptions::UnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            ResourceID = "resourceId",
            SalesforceID = "salesforceId",
            ScheduleStrategy = Subscriptions::ScheduleStrategy.EndOfBillingPeriod,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SubscriptionEntitlements =
            [
                new()
                {
                    FeatureID = "featureId",
                    UsageLimit = 0,
                    IsGranted = true,
                },
            ],
            TrialOverrideConfiguration = new()
            {
                IsTrial = true,
                TrialEndBehavior = Subscriptions::TrialEndBehavior.ConvertToPaid,
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            UnitQuantity = 1,
        };

        Subscriptions::SubscriptionCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class AddonTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::Addon { AddonID = "addonId", Quantity = 1 };

        string expectedAddonID = "addonId";
        long expectedQuantity = 1;

        Assert.Equal(expectedAddonID, model.AddonID);
        Assert.Equal(expectedQuantity, model.Quantity);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscriptions::Addon { AddonID = "addonId", Quantity = 1 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Addon>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::Addon { AddonID = "addonId", Quantity = 1 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Addon>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAddonID = "addonId";
        long expectedQuantity = 1;

        Assert.Equal(expectedAddonID, deserialized.AddonID);
        Assert.Equal(expectedQuantity, deserialized.Quantity);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Subscriptions::Addon { AddonID = "addonId", Quantity = 1 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Subscriptions::Addon { AddonID = "addonId" };

        Assert.Null(model.Quantity);
        Assert.False(model.RawData.ContainsKey("quantity"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Subscriptions::Addon { AddonID = "addonId" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Subscriptions::Addon
        {
            AddonID = "addonId",

            // Null should be interpreted as omitted for these properties
            Quantity = null,
        };

        Assert.Null(model.Quantity);
        Assert.False(model.RawData.ContainsKey("quantity"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Subscriptions::Addon
        {
            AddonID = "addonId",

            // Null should be interpreted as omitted for these properties
            Quantity = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Subscriptions::Addon { AddonID = "addonId", Quantity = 1 };

        Subscriptions::Addon copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AppliedCouponTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::AppliedCoupon
        {
            BillingCouponID = "billingCouponId",
            Configuration = new() { StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z") },
            CouponID = "couponId",
            Discount = new()
            {
                AmountsOff = [new() { Amount = 0, Currency = Subscriptions::Currency.Usd }],
                Description = "description",
                DurationInMonths = 1,
                Name = "name",
                PercentOff = 1,
            },
            PromotionCode = "promotionCode",
        };

        string expectedBillingCouponID = "billingCouponId";
        Subscriptions::Configuration expectedConfiguration = new()
        {
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string expectedCouponID = "couponId";
        Subscriptions::Discount expectedDiscount = new()
        {
            AmountsOff = [new() { Amount = 0, Currency = Subscriptions::Currency.Usd }],
            Description = "description",
            DurationInMonths = 1,
            Name = "name",
            PercentOff = 1,
        };
        string expectedPromotionCode = "promotionCode";

        Assert.Equal(expectedBillingCouponID, model.BillingCouponID);
        Assert.Equal(expectedConfiguration, model.Configuration);
        Assert.Equal(expectedCouponID, model.CouponID);
        Assert.Equal(expectedDiscount, model.Discount);
        Assert.Equal(expectedPromotionCode, model.PromotionCode);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscriptions::AppliedCoupon
        {
            BillingCouponID = "billingCouponId",
            Configuration = new() { StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z") },
            CouponID = "couponId",
            Discount = new()
            {
                AmountsOff = [new() { Amount = 0, Currency = Subscriptions::Currency.Usd }],
                Description = "description",
                DurationInMonths = 1,
                Name = "name",
                PercentOff = 1,
            },
            PromotionCode = "promotionCode",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::AppliedCoupon>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::AppliedCoupon
        {
            BillingCouponID = "billingCouponId",
            Configuration = new() { StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z") },
            CouponID = "couponId",
            Discount = new()
            {
                AmountsOff = [new() { Amount = 0, Currency = Subscriptions::Currency.Usd }],
                Description = "description",
                DurationInMonths = 1,
                Name = "name",
                PercentOff = 1,
            },
            PromotionCode = "promotionCode",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::AppliedCoupon>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBillingCouponID = "billingCouponId";
        Subscriptions::Configuration expectedConfiguration = new()
        {
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string expectedCouponID = "couponId";
        Subscriptions::Discount expectedDiscount = new()
        {
            AmountsOff = [new() { Amount = 0, Currency = Subscriptions::Currency.Usd }],
            Description = "description",
            DurationInMonths = 1,
            Name = "name",
            PercentOff = 1,
        };
        string expectedPromotionCode = "promotionCode";

        Assert.Equal(expectedBillingCouponID, deserialized.BillingCouponID);
        Assert.Equal(expectedConfiguration, deserialized.Configuration);
        Assert.Equal(expectedCouponID, deserialized.CouponID);
        Assert.Equal(expectedDiscount, deserialized.Discount);
        Assert.Equal(expectedPromotionCode, deserialized.PromotionCode);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Subscriptions::AppliedCoupon
        {
            BillingCouponID = "billingCouponId",
            Configuration = new() { StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z") },
            CouponID = "couponId",
            Discount = new()
            {
                AmountsOff = [new() { Amount = 0, Currency = Subscriptions::Currency.Usd }],
                Description = "description",
                DurationInMonths = 1,
                Name = "name",
                PercentOff = 1,
            },
            PromotionCode = "promotionCode",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Subscriptions::AppliedCoupon { };

        Assert.Null(model.BillingCouponID);
        Assert.False(model.RawData.ContainsKey("billingCouponId"));
        Assert.Null(model.Configuration);
        Assert.False(model.RawData.ContainsKey("configuration"));
        Assert.Null(model.CouponID);
        Assert.False(model.RawData.ContainsKey("couponId"));
        Assert.Null(model.Discount);
        Assert.False(model.RawData.ContainsKey("discount"));
        Assert.Null(model.PromotionCode);
        Assert.False(model.RawData.ContainsKey("promotionCode"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Subscriptions::AppliedCoupon { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Subscriptions::AppliedCoupon
        {
            // Null should be interpreted as omitted for these properties
            BillingCouponID = null,
            Configuration = null,
            CouponID = null,
            Discount = null,
            PromotionCode = null,
        };

        Assert.Null(model.BillingCouponID);
        Assert.False(model.RawData.ContainsKey("billingCouponId"));
        Assert.Null(model.Configuration);
        Assert.False(model.RawData.ContainsKey("configuration"));
        Assert.Null(model.CouponID);
        Assert.False(model.RawData.ContainsKey("couponId"));
        Assert.Null(model.Discount);
        Assert.False(model.RawData.ContainsKey("discount"));
        Assert.Null(model.PromotionCode);
        Assert.False(model.RawData.ContainsKey("promotionCode"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Subscriptions::AppliedCoupon
        {
            // Null should be interpreted as omitted for these properties
            BillingCouponID = null,
            Configuration = null,
            CouponID = null,
            Discount = null,
            PromotionCode = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Subscriptions::AppliedCoupon
        {
            BillingCouponID = "billingCouponId",
            Configuration = new() { StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z") },
            CouponID = "couponId",
            Discount = new()
            {
                AmountsOff = [new() { Amount = 0, Currency = Subscriptions::Currency.Usd }],
                Description = "description",
                DurationInMonths = 1,
                Name = "name",
                PercentOff = 1,
            },
            PromotionCode = "promotionCode",
        };

        Subscriptions::AppliedCoupon copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::Configuration
        {
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedStartDate, model.StartDate);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscriptions::Configuration
        {
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Configuration>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::Configuration
        {
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Configuration>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedStartDate, deserialized.StartDate);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Subscriptions::Configuration
        {
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Subscriptions::Configuration { };

        Assert.Null(model.StartDate);
        Assert.False(model.RawData.ContainsKey("startDate"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Subscriptions::Configuration { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Subscriptions::Configuration
        {
            // Null should be interpreted as omitted for these properties
            StartDate = null,
        };

        Assert.Null(model.StartDate);
        Assert.False(model.RawData.ContainsKey("startDate"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Subscriptions::Configuration
        {
            // Null should be interpreted as omitted for these properties
            StartDate = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Subscriptions::Configuration
        {
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Subscriptions::Configuration copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DiscountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::Discount
        {
            AmountsOff = [new() { Amount = 0, Currency = Subscriptions::Currency.Usd }],
            Description = "description",
            DurationInMonths = 1,
            Name = "name",
            PercentOff = 1,
        };

        List<Subscriptions::AmountsOff> expectedAmountsOff =
        [
            new() { Amount = 0, Currency = Subscriptions::Currency.Usd },
        ];
        string expectedDescription = "description";
        double expectedDurationInMonths = 1;
        string expectedName = "name";
        double expectedPercentOff = 1;

        Assert.NotNull(model.AmountsOff);
        Assert.Equal(expectedAmountsOff.Count, model.AmountsOff.Count);
        for (int i = 0; i < expectedAmountsOff.Count; i++)
        {
            Assert.Equal(expectedAmountsOff[i], model.AmountsOff[i]);
        }
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedDurationInMonths, model.DurationInMonths);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPercentOff, model.PercentOff);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscriptions::Discount
        {
            AmountsOff = [new() { Amount = 0, Currency = Subscriptions::Currency.Usd }],
            Description = "description",
            DurationInMonths = 1,
            Name = "name",
            PercentOff = 1,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Discount>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::Discount
        {
            AmountsOff = [new() { Amount = 0, Currency = Subscriptions::Currency.Usd }],
            Description = "description",
            DurationInMonths = 1,
            Name = "name",
            PercentOff = 1,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Discount>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Subscriptions::AmountsOff> expectedAmountsOff =
        [
            new() { Amount = 0, Currency = Subscriptions::Currency.Usd },
        ];
        string expectedDescription = "description";
        double expectedDurationInMonths = 1;
        string expectedName = "name";
        double expectedPercentOff = 1;

        Assert.NotNull(deserialized.AmountsOff);
        Assert.Equal(expectedAmountsOff.Count, deserialized.AmountsOff.Count);
        for (int i = 0; i < expectedAmountsOff.Count; i++)
        {
            Assert.Equal(expectedAmountsOff[i], deserialized.AmountsOff[i]);
        }
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedDurationInMonths, deserialized.DurationInMonths);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPercentOff, deserialized.PercentOff);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Subscriptions::Discount
        {
            AmountsOff = [new() { Amount = 0, Currency = Subscriptions::Currency.Usd }],
            Description = "description",
            DurationInMonths = 1,
            Name = "name",
            PercentOff = 1,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Subscriptions::Discount
        {
            AmountsOff = [new() { Amount = 0, Currency = Subscriptions::Currency.Usd }],
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.DurationInMonths);
        Assert.False(model.RawData.ContainsKey("durationInMonths"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.PercentOff);
        Assert.False(model.RawData.ContainsKey("percentOff"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Subscriptions::Discount
        {
            AmountsOff = [new() { Amount = 0, Currency = Subscriptions::Currency.Usd }],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Subscriptions::Discount
        {
            AmountsOff = [new() { Amount = 0, Currency = Subscriptions::Currency.Usd }],

            // Null should be interpreted as omitted for these properties
            Description = null,
            DurationInMonths = null,
            Name = null,
            PercentOff = null,
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.DurationInMonths);
        Assert.False(model.RawData.ContainsKey("durationInMonths"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.PercentOff);
        Assert.False(model.RawData.ContainsKey("percentOff"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Subscriptions::Discount
        {
            AmountsOff = [new() { Amount = 0, Currency = Subscriptions::Currency.Usd }],

            // Null should be interpreted as omitted for these properties
            Description = null,
            DurationInMonths = null,
            Name = null,
            PercentOff = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Subscriptions::Discount
        {
            Description = "description",
            DurationInMonths = 1,
            Name = "name",
            PercentOff = 1,
        };

        Assert.Null(model.AmountsOff);
        Assert.False(model.RawData.ContainsKey("amountsOff"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Subscriptions::Discount
        {
            Description = "description",
            DurationInMonths = 1,
            Name = "name",
            PercentOff = 1,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Subscriptions::Discount
        {
            Description = "description",
            DurationInMonths = 1,
            Name = "name",
            PercentOff = 1,

            AmountsOff = null,
        };

        Assert.Null(model.AmountsOff);
        Assert.True(model.RawData.ContainsKey("amountsOff"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Subscriptions::Discount
        {
            Description = "description",
            DurationInMonths = 1,
            Name = "name",
            PercentOff = 1,

            AmountsOff = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Subscriptions::Discount
        {
            AmountsOff = [new() { Amount = 0, Currency = Subscriptions::Currency.Usd }],
            Description = "description",
            DurationInMonths = 1,
            Name = "name",
            PercentOff = 1,
        };

        Subscriptions::Discount copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AmountsOffTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::AmountsOff
        {
            Amount = 0,
            Currency = Subscriptions::Currency.Usd,
        };

        double expectedAmount = 0;
        ApiEnum<string, Subscriptions::Currency> expectedCurrency = Subscriptions::Currency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscriptions::AmountsOff
        {
            Amount = 0,
            Currency = Subscriptions::Currency.Usd,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::AmountsOff>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::AmountsOff
        {
            Amount = 0,
            Currency = Subscriptions::Currency.Usd,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::AmountsOff>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        ApiEnum<string, Subscriptions::Currency> expectedCurrency = Subscriptions::Currency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Subscriptions::AmountsOff
        {
            Amount = 0,
            Currency = Subscriptions::Currency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Subscriptions::AmountsOff { Amount = 0 };

        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Subscriptions::AmountsOff { Amount = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Subscriptions::AmountsOff
        {
            Amount = 0,

            // Null should be interpreted as omitted for these properties
            Currency = null,
        };

        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Subscriptions::AmountsOff
        {
            Amount = 0,

            // Null should be interpreted as omitted for these properties
            Currency = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Subscriptions::AmountsOff
        {
            Amount = 0,
            Currency = Subscriptions::Currency.Usd,
        };

        Subscriptions::AmountsOff copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CurrencyTest : TestBase
{
    [Theory]
    [InlineData(Subscriptions::Currency.Usd)]
    [InlineData(Subscriptions::Currency.Aed)]
    [InlineData(Subscriptions::Currency.All)]
    [InlineData(Subscriptions::Currency.Amd)]
    [InlineData(Subscriptions::Currency.Ang)]
    [InlineData(Subscriptions::Currency.Aud)]
    [InlineData(Subscriptions::Currency.Awg)]
    [InlineData(Subscriptions::Currency.Azn)]
    [InlineData(Subscriptions::Currency.Bam)]
    [InlineData(Subscriptions::Currency.Bbd)]
    [InlineData(Subscriptions::Currency.Bdt)]
    [InlineData(Subscriptions::Currency.Bgn)]
    [InlineData(Subscriptions::Currency.Bif)]
    [InlineData(Subscriptions::Currency.Bmd)]
    [InlineData(Subscriptions::Currency.Bnd)]
    [InlineData(Subscriptions::Currency.Bsd)]
    [InlineData(Subscriptions::Currency.Bwp)]
    [InlineData(Subscriptions::Currency.Byn)]
    [InlineData(Subscriptions::Currency.Bzd)]
    [InlineData(Subscriptions::Currency.Brl)]
    [InlineData(Subscriptions::Currency.Cad)]
    [InlineData(Subscriptions::Currency.Cdf)]
    [InlineData(Subscriptions::Currency.Chf)]
    [InlineData(Subscriptions::Currency.Cny)]
    [InlineData(Subscriptions::Currency.Czk)]
    [InlineData(Subscriptions::Currency.Dkk)]
    [InlineData(Subscriptions::Currency.Dop)]
    [InlineData(Subscriptions::Currency.Dzd)]
    [InlineData(Subscriptions::Currency.Egp)]
    [InlineData(Subscriptions::Currency.Etb)]
    [InlineData(Subscriptions::Currency.Eur)]
    [InlineData(Subscriptions::Currency.Fjd)]
    [InlineData(Subscriptions::Currency.Gbp)]
    [InlineData(Subscriptions::Currency.Gel)]
    [InlineData(Subscriptions::Currency.Gip)]
    [InlineData(Subscriptions::Currency.Gmd)]
    [InlineData(Subscriptions::Currency.Gyd)]
    [InlineData(Subscriptions::Currency.Hkd)]
    [InlineData(Subscriptions::Currency.Hrk)]
    [InlineData(Subscriptions::Currency.Htg)]
    [InlineData(Subscriptions::Currency.Idr)]
    [InlineData(Subscriptions::Currency.Ils)]
    [InlineData(Subscriptions::Currency.Inr)]
    [InlineData(Subscriptions::Currency.Isk)]
    [InlineData(Subscriptions::Currency.Jmd)]
    [InlineData(Subscriptions::Currency.Jpy)]
    [InlineData(Subscriptions::Currency.Kes)]
    [InlineData(Subscriptions::Currency.Kgs)]
    [InlineData(Subscriptions::Currency.Khr)]
    [InlineData(Subscriptions::Currency.Kmf)]
    [InlineData(Subscriptions::Currency.Krw)]
    [InlineData(Subscriptions::Currency.Kyd)]
    [InlineData(Subscriptions::Currency.Kzt)]
    [InlineData(Subscriptions::Currency.Lbp)]
    [InlineData(Subscriptions::Currency.Lkr)]
    [InlineData(Subscriptions::Currency.Lrd)]
    [InlineData(Subscriptions::Currency.Lsl)]
    [InlineData(Subscriptions::Currency.Mad)]
    [InlineData(Subscriptions::Currency.Mdl)]
    [InlineData(Subscriptions::Currency.Mga)]
    [InlineData(Subscriptions::Currency.Mkd)]
    [InlineData(Subscriptions::Currency.Mmk)]
    [InlineData(Subscriptions::Currency.Mnt)]
    [InlineData(Subscriptions::Currency.Mop)]
    [InlineData(Subscriptions::Currency.Mro)]
    [InlineData(Subscriptions::Currency.Mvr)]
    [InlineData(Subscriptions::Currency.Mwk)]
    [InlineData(Subscriptions::Currency.Mxn)]
    [InlineData(Subscriptions::Currency.Myr)]
    [InlineData(Subscriptions::Currency.Mzn)]
    [InlineData(Subscriptions::Currency.Nad)]
    [InlineData(Subscriptions::Currency.Ngn)]
    [InlineData(Subscriptions::Currency.Nok)]
    [InlineData(Subscriptions::Currency.Npr)]
    [InlineData(Subscriptions::Currency.Nzd)]
    [InlineData(Subscriptions::Currency.Pgk)]
    [InlineData(Subscriptions::Currency.Php)]
    [InlineData(Subscriptions::Currency.Pkr)]
    [InlineData(Subscriptions::Currency.Pln)]
    [InlineData(Subscriptions::Currency.Qar)]
    [InlineData(Subscriptions::Currency.Ron)]
    [InlineData(Subscriptions::Currency.Rsd)]
    [InlineData(Subscriptions::Currency.Rub)]
    [InlineData(Subscriptions::Currency.Rwf)]
    [InlineData(Subscriptions::Currency.Sar)]
    [InlineData(Subscriptions::Currency.Sbd)]
    [InlineData(Subscriptions::Currency.Scr)]
    [InlineData(Subscriptions::Currency.Sek)]
    [InlineData(Subscriptions::Currency.Sgd)]
    [InlineData(Subscriptions::Currency.Sle)]
    [InlineData(Subscriptions::Currency.Sll)]
    [InlineData(Subscriptions::Currency.Sos)]
    [InlineData(Subscriptions::Currency.Szl)]
    [InlineData(Subscriptions::Currency.Thb)]
    [InlineData(Subscriptions::Currency.Tjs)]
    [InlineData(Subscriptions::Currency.Top)]
    [InlineData(Subscriptions::Currency.Try)]
    [InlineData(Subscriptions::Currency.Ttd)]
    [InlineData(Subscriptions::Currency.Tzs)]
    [InlineData(Subscriptions::Currency.Uah)]
    [InlineData(Subscriptions::Currency.Uzs)]
    [InlineData(Subscriptions::Currency.Vnd)]
    [InlineData(Subscriptions::Currency.Vuv)]
    [InlineData(Subscriptions::Currency.Wst)]
    [InlineData(Subscriptions::Currency.Xaf)]
    [InlineData(Subscriptions::Currency.Xcd)]
    [InlineData(Subscriptions::Currency.Yer)]
    [InlineData(Subscriptions::Currency.Zar)]
    [InlineData(Subscriptions::Currency.Zmw)]
    [InlineData(Subscriptions::Currency.Clp)]
    [InlineData(Subscriptions::Currency.Djf)]
    [InlineData(Subscriptions::Currency.Gnf)]
    [InlineData(Subscriptions::Currency.Ugx)]
    [InlineData(Subscriptions::Currency.Pyg)]
    [InlineData(Subscriptions::Currency.Xof)]
    [InlineData(Subscriptions::Currency.Xpf)]
    public void Validation_Works(Subscriptions::Currency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::Currency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::Currency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Subscriptions::Currency.Usd)]
    [InlineData(Subscriptions::Currency.Aed)]
    [InlineData(Subscriptions::Currency.All)]
    [InlineData(Subscriptions::Currency.Amd)]
    [InlineData(Subscriptions::Currency.Ang)]
    [InlineData(Subscriptions::Currency.Aud)]
    [InlineData(Subscriptions::Currency.Awg)]
    [InlineData(Subscriptions::Currency.Azn)]
    [InlineData(Subscriptions::Currency.Bam)]
    [InlineData(Subscriptions::Currency.Bbd)]
    [InlineData(Subscriptions::Currency.Bdt)]
    [InlineData(Subscriptions::Currency.Bgn)]
    [InlineData(Subscriptions::Currency.Bif)]
    [InlineData(Subscriptions::Currency.Bmd)]
    [InlineData(Subscriptions::Currency.Bnd)]
    [InlineData(Subscriptions::Currency.Bsd)]
    [InlineData(Subscriptions::Currency.Bwp)]
    [InlineData(Subscriptions::Currency.Byn)]
    [InlineData(Subscriptions::Currency.Bzd)]
    [InlineData(Subscriptions::Currency.Brl)]
    [InlineData(Subscriptions::Currency.Cad)]
    [InlineData(Subscriptions::Currency.Cdf)]
    [InlineData(Subscriptions::Currency.Chf)]
    [InlineData(Subscriptions::Currency.Cny)]
    [InlineData(Subscriptions::Currency.Czk)]
    [InlineData(Subscriptions::Currency.Dkk)]
    [InlineData(Subscriptions::Currency.Dop)]
    [InlineData(Subscriptions::Currency.Dzd)]
    [InlineData(Subscriptions::Currency.Egp)]
    [InlineData(Subscriptions::Currency.Etb)]
    [InlineData(Subscriptions::Currency.Eur)]
    [InlineData(Subscriptions::Currency.Fjd)]
    [InlineData(Subscriptions::Currency.Gbp)]
    [InlineData(Subscriptions::Currency.Gel)]
    [InlineData(Subscriptions::Currency.Gip)]
    [InlineData(Subscriptions::Currency.Gmd)]
    [InlineData(Subscriptions::Currency.Gyd)]
    [InlineData(Subscriptions::Currency.Hkd)]
    [InlineData(Subscriptions::Currency.Hrk)]
    [InlineData(Subscriptions::Currency.Htg)]
    [InlineData(Subscriptions::Currency.Idr)]
    [InlineData(Subscriptions::Currency.Ils)]
    [InlineData(Subscriptions::Currency.Inr)]
    [InlineData(Subscriptions::Currency.Isk)]
    [InlineData(Subscriptions::Currency.Jmd)]
    [InlineData(Subscriptions::Currency.Jpy)]
    [InlineData(Subscriptions::Currency.Kes)]
    [InlineData(Subscriptions::Currency.Kgs)]
    [InlineData(Subscriptions::Currency.Khr)]
    [InlineData(Subscriptions::Currency.Kmf)]
    [InlineData(Subscriptions::Currency.Krw)]
    [InlineData(Subscriptions::Currency.Kyd)]
    [InlineData(Subscriptions::Currency.Kzt)]
    [InlineData(Subscriptions::Currency.Lbp)]
    [InlineData(Subscriptions::Currency.Lkr)]
    [InlineData(Subscriptions::Currency.Lrd)]
    [InlineData(Subscriptions::Currency.Lsl)]
    [InlineData(Subscriptions::Currency.Mad)]
    [InlineData(Subscriptions::Currency.Mdl)]
    [InlineData(Subscriptions::Currency.Mga)]
    [InlineData(Subscriptions::Currency.Mkd)]
    [InlineData(Subscriptions::Currency.Mmk)]
    [InlineData(Subscriptions::Currency.Mnt)]
    [InlineData(Subscriptions::Currency.Mop)]
    [InlineData(Subscriptions::Currency.Mro)]
    [InlineData(Subscriptions::Currency.Mvr)]
    [InlineData(Subscriptions::Currency.Mwk)]
    [InlineData(Subscriptions::Currency.Mxn)]
    [InlineData(Subscriptions::Currency.Myr)]
    [InlineData(Subscriptions::Currency.Mzn)]
    [InlineData(Subscriptions::Currency.Nad)]
    [InlineData(Subscriptions::Currency.Ngn)]
    [InlineData(Subscriptions::Currency.Nok)]
    [InlineData(Subscriptions::Currency.Npr)]
    [InlineData(Subscriptions::Currency.Nzd)]
    [InlineData(Subscriptions::Currency.Pgk)]
    [InlineData(Subscriptions::Currency.Php)]
    [InlineData(Subscriptions::Currency.Pkr)]
    [InlineData(Subscriptions::Currency.Pln)]
    [InlineData(Subscriptions::Currency.Qar)]
    [InlineData(Subscriptions::Currency.Ron)]
    [InlineData(Subscriptions::Currency.Rsd)]
    [InlineData(Subscriptions::Currency.Rub)]
    [InlineData(Subscriptions::Currency.Rwf)]
    [InlineData(Subscriptions::Currency.Sar)]
    [InlineData(Subscriptions::Currency.Sbd)]
    [InlineData(Subscriptions::Currency.Scr)]
    [InlineData(Subscriptions::Currency.Sek)]
    [InlineData(Subscriptions::Currency.Sgd)]
    [InlineData(Subscriptions::Currency.Sle)]
    [InlineData(Subscriptions::Currency.Sll)]
    [InlineData(Subscriptions::Currency.Sos)]
    [InlineData(Subscriptions::Currency.Szl)]
    [InlineData(Subscriptions::Currency.Thb)]
    [InlineData(Subscriptions::Currency.Tjs)]
    [InlineData(Subscriptions::Currency.Top)]
    [InlineData(Subscriptions::Currency.Try)]
    [InlineData(Subscriptions::Currency.Ttd)]
    [InlineData(Subscriptions::Currency.Tzs)]
    [InlineData(Subscriptions::Currency.Uah)]
    [InlineData(Subscriptions::Currency.Uzs)]
    [InlineData(Subscriptions::Currency.Vnd)]
    [InlineData(Subscriptions::Currency.Vuv)]
    [InlineData(Subscriptions::Currency.Wst)]
    [InlineData(Subscriptions::Currency.Xaf)]
    [InlineData(Subscriptions::Currency.Xcd)]
    [InlineData(Subscriptions::Currency.Yer)]
    [InlineData(Subscriptions::Currency.Zar)]
    [InlineData(Subscriptions::Currency.Zmw)]
    [InlineData(Subscriptions::Currency.Clp)]
    [InlineData(Subscriptions::Currency.Djf)]
    [InlineData(Subscriptions::Currency.Gnf)]
    [InlineData(Subscriptions::Currency.Ugx)]
    [InlineData(Subscriptions::Currency.Pyg)]
    [InlineData(Subscriptions::Currency.Xof)]
    [InlineData(Subscriptions::Currency.Xpf)]
    public void SerializationRoundtrip_Works(Subscriptions::Currency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::Currency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::Currency>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::Currency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::Currency>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class BillingInformationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::BillingInformation
        {
            BillingAddress = new()
            {
                City = "city",
                Country = "country",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postalCode",
                State = "state",
            },
            ChargeOnBehalfOfAccount = "chargeOnBehalfOfAccount",
            IntegrationID = "integrationId",
            InvoiceDaysUntilDue = 0,
            IsBackdated = true,
            IsInvoicePaid = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ProrationBehavior = Subscriptions::ProrationBehavior.InvoiceImmediately,
            TaxIds = [new() { Type = "type", Value = "value" }],
            TaxPercentage = 0,
            TaxRateIds = ["string"],
        };

        Subscriptions::BillingAddress expectedBillingAddress = new()
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };
        string expectedChargeOnBehalfOfAccount = "chargeOnBehalfOfAccount";
        string expectedIntegrationID = "integrationId";
        double expectedInvoiceDaysUntilDue = 0;
        bool expectedIsBackdated = true;
        bool expectedIsInvoicePaid = true;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        ApiEnum<string, Subscriptions::ProrationBehavior> expectedProrationBehavior =
            Subscriptions::ProrationBehavior.InvoiceImmediately;
        List<Subscriptions::TaxID> expectedTaxIds = [new() { Type = "type", Value = "value" }];
        double expectedTaxPercentage = 0;
        List<string> expectedTaxRateIds = ["string"];

        Assert.Equal(expectedBillingAddress, model.BillingAddress);
        Assert.Equal(expectedChargeOnBehalfOfAccount, model.ChargeOnBehalfOfAccount);
        Assert.Equal(expectedIntegrationID, model.IntegrationID);
        Assert.Equal(expectedInvoiceDaysUntilDue, model.InvoiceDaysUntilDue);
        Assert.Equal(expectedIsBackdated, model.IsBackdated);
        Assert.Equal(expectedIsInvoicePaid, model.IsInvoicePaid);
        Assert.NotNull(model.Metadata);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedProrationBehavior, model.ProrationBehavior);
        Assert.NotNull(model.TaxIds);
        Assert.Equal(expectedTaxIds.Count, model.TaxIds.Count);
        for (int i = 0; i < expectedTaxIds.Count; i++)
        {
            Assert.Equal(expectedTaxIds[i], model.TaxIds[i]);
        }
        Assert.Equal(expectedTaxPercentage, model.TaxPercentage);
        Assert.NotNull(model.TaxRateIds);
        Assert.Equal(expectedTaxRateIds.Count, model.TaxRateIds.Count);
        for (int i = 0; i < expectedTaxRateIds.Count; i++)
        {
            Assert.Equal(expectedTaxRateIds[i], model.TaxRateIds[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscriptions::BillingInformation
        {
            BillingAddress = new()
            {
                City = "city",
                Country = "country",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postalCode",
                State = "state",
            },
            ChargeOnBehalfOfAccount = "chargeOnBehalfOfAccount",
            IntegrationID = "integrationId",
            InvoiceDaysUntilDue = 0,
            IsBackdated = true,
            IsInvoicePaid = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ProrationBehavior = Subscriptions::ProrationBehavior.InvoiceImmediately,
            TaxIds = [new() { Type = "type", Value = "value" }],
            TaxPercentage = 0,
            TaxRateIds = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::BillingInformation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::BillingInformation
        {
            BillingAddress = new()
            {
                City = "city",
                Country = "country",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postalCode",
                State = "state",
            },
            ChargeOnBehalfOfAccount = "chargeOnBehalfOfAccount",
            IntegrationID = "integrationId",
            InvoiceDaysUntilDue = 0,
            IsBackdated = true,
            IsInvoicePaid = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ProrationBehavior = Subscriptions::ProrationBehavior.InvoiceImmediately,
            TaxIds = [new() { Type = "type", Value = "value" }],
            TaxPercentage = 0,
            TaxRateIds = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::BillingInformation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Subscriptions::BillingAddress expectedBillingAddress = new()
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };
        string expectedChargeOnBehalfOfAccount = "chargeOnBehalfOfAccount";
        string expectedIntegrationID = "integrationId";
        double expectedInvoiceDaysUntilDue = 0;
        bool expectedIsBackdated = true;
        bool expectedIsInvoicePaid = true;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        ApiEnum<string, Subscriptions::ProrationBehavior> expectedProrationBehavior =
            Subscriptions::ProrationBehavior.InvoiceImmediately;
        List<Subscriptions::TaxID> expectedTaxIds = [new() { Type = "type", Value = "value" }];
        double expectedTaxPercentage = 0;
        List<string> expectedTaxRateIds = ["string"];

        Assert.Equal(expectedBillingAddress, deserialized.BillingAddress);
        Assert.Equal(expectedChargeOnBehalfOfAccount, deserialized.ChargeOnBehalfOfAccount);
        Assert.Equal(expectedIntegrationID, deserialized.IntegrationID);
        Assert.Equal(expectedInvoiceDaysUntilDue, deserialized.InvoiceDaysUntilDue);
        Assert.Equal(expectedIsBackdated, deserialized.IsBackdated);
        Assert.Equal(expectedIsInvoicePaid, deserialized.IsInvoicePaid);
        Assert.NotNull(deserialized.Metadata);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedProrationBehavior, deserialized.ProrationBehavior);
        Assert.NotNull(deserialized.TaxIds);
        Assert.Equal(expectedTaxIds.Count, deserialized.TaxIds.Count);
        for (int i = 0; i < expectedTaxIds.Count; i++)
        {
            Assert.Equal(expectedTaxIds[i], deserialized.TaxIds[i]);
        }
        Assert.Equal(expectedTaxPercentage, deserialized.TaxPercentage);
        Assert.NotNull(deserialized.TaxRateIds);
        Assert.Equal(expectedTaxRateIds.Count, deserialized.TaxRateIds.Count);
        for (int i = 0; i < expectedTaxRateIds.Count; i++)
        {
            Assert.Equal(expectedTaxRateIds[i], deserialized.TaxRateIds[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Subscriptions::BillingInformation
        {
            BillingAddress = new()
            {
                City = "city",
                Country = "country",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postalCode",
                State = "state",
            },
            ChargeOnBehalfOfAccount = "chargeOnBehalfOfAccount",
            IntegrationID = "integrationId",
            InvoiceDaysUntilDue = 0,
            IsBackdated = true,
            IsInvoicePaid = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ProrationBehavior = Subscriptions::ProrationBehavior.InvoiceImmediately,
            TaxIds = [new() { Type = "type", Value = "value" }],
            TaxPercentage = 0,
            TaxRateIds = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Subscriptions::BillingInformation
        {
            ChargeOnBehalfOfAccount = "chargeOnBehalfOfAccount",
            IntegrationID = "integrationId",
        };

        Assert.Null(model.BillingAddress);
        Assert.False(model.RawData.ContainsKey("billingAddress"));
        Assert.Null(model.InvoiceDaysUntilDue);
        Assert.False(model.RawData.ContainsKey("invoiceDaysUntilDue"));
        Assert.Null(model.IsBackdated);
        Assert.False(model.RawData.ContainsKey("isBackdated"));
        Assert.Null(model.IsInvoicePaid);
        Assert.False(model.RawData.ContainsKey("isInvoicePaid"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.ProrationBehavior);
        Assert.False(model.RawData.ContainsKey("prorationBehavior"));
        Assert.Null(model.TaxIds);
        Assert.False(model.RawData.ContainsKey("taxIds"));
        Assert.Null(model.TaxPercentage);
        Assert.False(model.RawData.ContainsKey("taxPercentage"));
        Assert.Null(model.TaxRateIds);
        Assert.False(model.RawData.ContainsKey("taxRateIds"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Subscriptions::BillingInformation
        {
            ChargeOnBehalfOfAccount = "chargeOnBehalfOfAccount",
            IntegrationID = "integrationId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Subscriptions::BillingInformation
        {
            ChargeOnBehalfOfAccount = "chargeOnBehalfOfAccount",
            IntegrationID = "integrationId",

            // Null should be interpreted as omitted for these properties
            BillingAddress = null,
            InvoiceDaysUntilDue = null,
            IsBackdated = null,
            IsInvoicePaid = null,
            Metadata = null,
            ProrationBehavior = null,
            TaxIds = null,
            TaxPercentage = null,
            TaxRateIds = null,
        };

        Assert.Null(model.BillingAddress);
        Assert.False(model.RawData.ContainsKey("billingAddress"));
        Assert.Null(model.InvoiceDaysUntilDue);
        Assert.False(model.RawData.ContainsKey("invoiceDaysUntilDue"));
        Assert.Null(model.IsBackdated);
        Assert.False(model.RawData.ContainsKey("isBackdated"));
        Assert.Null(model.IsInvoicePaid);
        Assert.False(model.RawData.ContainsKey("isInvoicePaid"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.ProrationBehavior);
        Assert.False(model.RawData.ContainsKey("prorationBehavior"));
        Assert.Null(model.TaxIds);
        Assert.False(model.RawData.ContainsKey("taxIds"));
        Assert.Null(model.TaxPercentage);
        Assert.False(model.RawData.ContainsKey("taxPercentage"));
        Assert.Null(model.TaxRateIds);
        Assert.False(model.RawData.ContainsKey("taxRateIds"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Subscriptions::BillingInformation
        {
            ChargeOnBehalfOfAccount = "chargeOnBehalfOfAccount",
            IntegrationID = "integrationId",

            // Null should be interpreted as omitted for these properties
            BillingAddress = null,
            InvoiceDaysUntilDue = null,
            IsBackdated = null,
            IsInvoicePaid = null,
            Metadata = null,
            ProrationBehavior = null,
            TaxIds = null,
            TaxPercentage = null,
            TaxRateIds = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Subscriptions::BillingInformation
        {
            BillingAddress = new()
            {
                City = "city",
                Country = "country",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postalCode",
                State = "state",
            },
            InvoiceDaysUntilDue = 0,
            IsBackdated = true,
            IsInvoicePaid = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ProrationBehavior = Subscriptions::ProrationBehavior.InvoiceImmediately,
            TaxIds = [new() { Type = "type", Value = "value" }],
            TaxPercentage = 0,
            TaxRateIds = ["string"],
        };

        Assert.Null(model.ChargeOnBehalfOfAccount);
        Assert.False(model.RawData.ContainsKey("chargeOnBehalfOfAccount"));
        Assert.Null(model.IntegrationID);
        Assert.False(model.RawData.ContainsKey("integrationId"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Subscriptions::BillingInformation
        {
            BillingAddress = new()
            {
                City = "city",
                Country = "country",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postalCode",
                State = "state",
            },
            InvoiceDaysUntilDue = 0,
            IsBackdated = true,
            IsInvoicePaid = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ProrationBehavior = Subscriptions::ProrationBehavior.InvoiceImmediately,
            TaxIds = [new() { Type = "type", Value = "value" }],
            TaxPercentage = 0,
            TaxRateIds = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Subscriptions::BillingInformation
        {
            BillingAddress = new()
            {
                City = "city",
                Country = "country",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postalCode",
                State = "state",
            },
            InvoiceDaysUntilDue = 0,
            IsBackdated = true,
            IsInvoicePaid = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ProrationBehavior = Subscriptions::ProrationBehavior.InvoiceImmediately,
            TaxIds = [new() { Type = "type", Value = "value" }],
            TaxPercentage = 0,
            TaxRateIds = ["string"],

            ChargeOnBehalfOfAccount = null,
            IntegrationID = null,
        };

        Assert.Null(model.ChargeOnBehalfOfAccount);
        Assert.True(model.RawData.ContainsKey("chargeOnBehalfOfAccount"));
        Assert.Null(model.IntegrationID);
        Assert.True(model.RawData.ContainsKey("integrationId"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Subscriptions::BillingInformation
        {
            BillingAddress = new()
            {
                City = "city",
                Country = "country",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postalCode",
                State = "state",
            },
            InvoiceDaysUntilDue = 0,
            IsBackdated = true,
            IsInvoicePaid = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ProrationBehavior = Subscriptions::ProrationBehavior.InvoiceImmediately,
            TaxIds = [new() { Type = "type", Value = "value" }],
            TaxPercentage = 0,
            TaxRateIds = ["string"],

            ChargeOnBehalfOfAccount = null,
            IntegrationID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Subscriptions::BillingInformation
        {
            BillingAddress = new()
            {
                City = "city",
                Country = "country",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postalCode",
                State = "state",
            },
            ChargeOnBehalfOfAccount = "chargeOnBehalfOfAccount",
            IntegrationID = "integrationId",
            InvoiceDaysUntilDue = 0,
            IsBackdated = true,
            IsInvoicePaid = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ProrationBehavior = Subscriptions::ProrationBehavior.InvoiceImmediately,
            TaxIds = [new() { Type = "type", Value = "value" }],
            TaxPercentage = 0,
            TaxRateIds = ["string"],
        };

        Subscriptions::BillingInformation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BillingAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::BillingAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };

        string expectedCity = "city";
        string expectedCountry = "country";
        string expectedLine1 = "line1";
        string expectedLine2 = "line2";
        string expectedPostalCode = "postalCode";
        string expectedState = "state";

        Assert.Equal(expectedCity, model.City);
        Assert.Equal(expectedCountry, model.Country);
        Assert.Equal(expectedLine1, model.Line1);
        Assert.Equal(expectedLine2, model.Line2);
        Assert.Equal(expectedPostalCode, model.PostalCode);
        Assert.Equal(expectedState, model.State);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscriptions::BillingAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::BillingAddress>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::BillingAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::BillingAddress>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCity = "city";
        string expectedCountry = "country";
        string expectedLine1 = "line1";
        string expectedLine2 = "line2";
        string expectedPostalCode = "postalCode";
        string expectedState = "state";

        Assert.Equal(expectedCity, deserialized.City);
        Assert.Equal(expectedCountry, deserialized.Country);
        Assert.Equal(expectedLine1, deserialized.Line1);
        Assert.Equal(expectedLine2, deserialized.Line2);
        Assert.Equal(expectedPostalCode, deserialized.PostalCode);
        Assert.Equal(expectedState, deserialized.State);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Subscriptions::BillingAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Subscriptions::BillingAddress { };

        Assert.Null(model.City);
        Assert.False(model.RawData.ContainsKey("city"));
        Assert.Null(model.Country);
        Assert.False(model.RawData.ContainsKey("country"));
        Assert.Null(model.Line1);
        Assert.False(model.RawData.ContainsKey("line1"));
        Assert.Null(model.Line2);
        Assert.False(model.RawData.ContainsKey("line2"));
        Assert.Null(model.PostalCode);
        Assert.False(model.RawData.ContainsKey("postalCode"));
        Assert.Null(model.State);
        Assert.False(model.RawData.ContainsKey("state"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Subscriptions::BillingAddress { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Subscriptions::BillingAddress
        {
            // Null should be interpreted as omitted for these properties
            City = null,
            Country = null,
            Line1 = null,
            Line2 = null,
            PostalCode = null,
            State = null,
        };

        Assert.Null(model.City);
        Assert.False(model.RawData.ContainsKey("city"));
        Assert.Null(model.Country);
        Assert.False(model.RawData.ContainsKey("country"));
        Assert.Null(model.Line1);
        Assert.False(model.RawData.ContainsKey("line1"));
        Assert.Null(model.Line2);
        Assert.False(model.RawData.ContainsKey("line2"));
        Assert.Null(model.PostalCode);
        Assert.False(model.RawData.ContainsKey("postalCode"));
        Assert.Null(model.State);
        Assert.False(model.RawData.ContainsKey("state"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Subscriptions::BillingAddress
        {
            // Null should be interpreted as omitted for these properties
            City = null,
            Country = null,
            Line1 = null,
            Line2 = null,
            PostalCode = null,
            State = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Subscriptions::BillingAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };

        Subscriptions::BillingAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ProrationBehaviorTest : TestBase
{
    [Theory]
    [InlineData(Subscriptions::ProrationBehavior.InvoiceImmediately)]
    [InlineData(Subscriptions::ProrationBehavior.CreateProrations)]
    [InlineData(Subscriptions::ProrationBehavior.None)]
    public void Validation_Works(Subscriptions::ProrationBehavior rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::ProrationBehavior> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::ProrationBehavior>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Subscriptions::ProrationBehavior.InvoiceImmediately)]
    [InlineData(Subscriptions::ProrationBehavior.CreateProrations)]
    [InlineData(Subscriptions::ProrationBehavior.None)]
    public void SerializationRoundtrip_Works(Subscriptions::ProrationBehavior rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::ProrationBehavior> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::ProrationBehavior>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::ProrationBehavior>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::ProrationBehavior>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TaxIDTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::TaxID { Type = "type", Value = "value" };

        string expectedType = "type";
        string expectedValue = "value";

        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscriptions::TaxID { Type = "type", Value = "value" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::TaxID>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::TaxID { Type = "type", Value = "value" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::TaxID>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedType = "type";
        string expectedValue = "value";

        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Subscriptions::TaxID { Type = "type", Value = "value" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Subscriptions::TaxID { Type = "type", Value = "value" };

        Subscriptions::TaxID copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BillingPeriodTest : TestBase
{
    [Theory]
    [InlineData(Subscriptions::BillingPeriod.Monthly)]
    [InlineData(Subscriptions::BillingPeriod.Annually)]
    public void Validation_Works(Subscriptions::BillingPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::BillingPeriod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::BillingPeriod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Subscriptions::BillingPeriod.Monthly)]
    [InlineData(Subscriptions::BillingPeriod.Annually)]
    public void SerializationRoundtrip_Works(Subscriptions::BillingPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::BillingPeriod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::BillingPeriod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::BillingPeriod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::BillingPeriod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class BudgetTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::Budget { HasSoftLimit = true, Limit = 0 };

        bool expectedHasSoftLimit = true;
        double expectedLimit = 0;

        Assert.Equal(expectedHasSoftLimit, model.HasSoftLimit);
        Assert.Equal(expectedLimit, model.Limit);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscriptions::Budget { HasSoftLimit = true, Limit = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Budget>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::Budget { HasSoftLimit = true, Limit = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Budget>(
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
        var model = new Subscriptions::Budget { HasSoftLimit = true, Limit = 0 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Subscriptions::Budget { HasSoftLimit = true, Limit = 0 };

        Subscriptions::Budget copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::Charge
        {
            ID = "id",
            Quantity = 1,
            Type = Subscriptions::Type.Feature,
        };

        string expectedID = "id";
        double expectedQuantity = 1;
        ApiEnum<string, Subscriptions::Type> expectedType = Subscriptions::Type.Feature;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedQuantity, model.Quantity);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscriptions::Charge
        {
            ID = "id",
            Quantity = 1,
            Type = Subscriptions::Type.Feature,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Charge>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::Charge
        {
            ID = "id",
            Quantity = 1,
            Type = Subscriptions::Type.Feature,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Charge>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        double expectedQuantity = 1;
        ApiEnum<string, Subscriptions::Type> expectedType = Subscriptions::Type.Feature;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedQuantity, deserialized.Quantity);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Subscriptions::Charge
        {
            ID = "id",
            Quantity = 1,
            Type = Subscriptions::Type.Feature,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Subscriptions::Charge
        {
            ID = "id",
            Quantity = 1,
            Type = Subscriptions::Type.Feature,
        };

        Subscriptions::Charge copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Subscriptions::Type.Feature)]
    [InlineData(Subscriptions::Type.Credit)]
    public void Validation_Works(Subscriptions::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Subscriptions::Type.Feature)]
    [InlineData(Subscriptions::Type.Credit)]
    public void SerializationRoundtrip_Works(Subscriptions::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CheckoutOptionsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::CheckoutOptions
        {
            CancelUrl = "https://example.com",
            SuccessUrl = "https://example.com",
            AllowPromoCodes = true,
            AllowTaxIDCollection = true,
            CollectBillingAddress = true,
            CollectPhoneNumber = true,
            ReferenceID = "referenceId",
        };

        string expectedCancelUrl = "https://example.com";
        string expectedSuccessUrl = "https://example.com";
        bool expectedAllowPromoCodes = true;
        bool expectedAllowTaxIDCollection = true;
        bool expectedCollectBillingAddress = true;
        bool expectedCollectPhoneNumber = true;
        string expectedReferenceID = "referenceId";

        Assert.Equal(expectedCancelUrl, model.CancelUrl);
        Assert.Equal(expectedSuccessUrl, model.SuccessUrl);
        Assert.Equal(expectedAllowPromoCodes, model.AllowPromoCodes);
        Assert.Equal(expectedAllowTaxIDCollection, model.AllowTaxIDCollection);
        Assert.Equal(expectedCollectBillingAddress, model.CollectBillingAddress);
        Assert.Equal(expectedCollectPhoneNumber, model.CollectPhoneNumber);
        Assert.Equal(expectedReferenceID, model.ReferenceID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscriptions::CheckoutOptions
        {
            CancelUrl = "https://example.com",
            SuccessUrl = "https://example.com",
            AllowPromoCodes = true,
            AllowTaxIDCollection = true,
            CollectBillingAddress = true,
            CollectPhoneNumber = true,
            ReferenceID = "referenceId",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::CheckoutOptions>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::CheckoutOptions
        {
            CancelUrl = "https://example.com",
            SuccessUrl = "https://example.com",
            AllowPromoCodes = true,
            AllowTaxIDCollection = true,
            CollectBillingAddress = true,
            CollectPhoneNumber = true,
            ReferenceID = "referenceId",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::CheckoutOptions>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCancelUrl = "https://example.com";
        string expectedSuccessUrl = "https://example.com";
        bool expectedAllowPromoCodes = true;
        bool expectedAllowTaxIDCollection = true;
        bool expectedCollectBillingAddress = true;
        bool expectedCollectPhoneNumber = true;
        string expectedReferenceID = "referenceId";

        Assert.Equal(expectedCancelUrl, deserialized.CancelUrl);
        Assert.Equal(expectedSuccessUrl, deserialized.SuccessUrl);
        Assert.Equal(expectedAllowPromoCodes, deserialized.AllowPromoCodes);
        Assert.Equal(expectedAllowTaxIDCollection, deserialized.AllowTaxIDCollection);
        Assert.Equal(expectedCollectBillingAddress, deserialized.CollectBillingAddress);
        Assert.Equal(expectedCollectPhoneNumber, deserialized.CollectPhoneNumber);
        Assert.Equal(expectedReferenceID, deserialized.ReferenceID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Subscriptions::CheckoutOptions
        {
            CancelUrl = "https://example.com",
            SuccessUrl = "https://example.com",
            AllowPromoCodes = true,
            AllowTaxIDCollection = true,
            CollectBillingAddress = true,
            CollectPhoneNumber = true,
            ReferenceID = "referenceId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Subscriptions::CheckoutOptions
        {
            CancelUrl = "https://example.com",
            SuccessUrl = "https://example.com",
            ReferenceID = "referenceId",
        };

        Assert.Null(model.AllowPromoCodes);
        Assert.False(model.RawData.ContainsKey("allowPromoCodes"));
        Assert.Null(model.AllowTaxIDCollection);
        Assert.False(model.RawData.ContainsKey("allowTaxIdCollection"));
        Assert.Null(model.CollectBillingAddress);
        Assert.False(model.RawData.ContainsKey("collectBillingAddress"));
        Assert.Null(model.CollectPhoneNumber);
        Assert.False(model.RawData.ContainsKey("collectPhoneNumber"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Subscriptions::CheckoutOptions
        {
            CancelUrl = "https://example.com",
            SuccessUrl = "https://example.com",
            ReferenceID = "referenceId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Subscriptions::CheckoutOptions
        {
            CancelUrl = "https://example.com",
            SuccessUrl = "https://example.com",
            ReferenceID = "referenceId",

            // Null should be interpreted as omitted for these properties
            AllowPromoCodes = null,
            AllowTaxIDCollection = null,
            CollectBillingAddress = null,
            CollectPhoneNumber = null,
        };

        Assert.Null(model.AllowPromoCodes);
        Assert.False(model.RawData.ContainsKey("allowPromoCodes"));
        Assert.Null(model.AllowTaxIDCollection);
        Assert.False(model.RawData.ContainsKey("allowTaxIdCollection"));
        Assert.Null(model.CollectBillingAddress);
        Assert.False(model.RawData.ContainsKey("collectBillingAddress"));
        Assert.Null(model.CollectPhoneNumber);
        Assert.False(model.RawData.ContainsKey("collectPhoneNumber"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Subscriptions::CheckoutOptions
        {
            CancelUrl = "https://example.com",
            SuccessUrl = "https://example.com",
            ReferenceID = "referenceId",

            // Null should be interpreted as omitted for these properties
            AllowPromoCodes = null,
            AllowTaxIDCollection = null,
            CollectBillingAddress = null,
            CollectPhoneNumber = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Subscriptions::CheckoutOptions
        {
            CancelUrl = "https://example.com",
            SuccessUrl = "https://example.com",
            AllowPromoCodes = true,
            AllowTaxIDCollection = true,
            CollectBillingAddress = true,
            CollectPhoneNumber = true,
        };

        Assert.Null(model.ReferenceID);
        Assert.False(model.RawData.ContainsKey("referenceId"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Subscriptions::CheckoutOptions
        {
            CancelUrl = "https://example.com",
            SuccessUrl = "https://example.com",
            AllowPromoCodes = true,
            AllowTaxIDCollection = true,
            CollectBillingAddress = true,
            CollectPhoneNumber = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Subscriptions::CheckoutOptions
        {
            CancelUrl = "https://example.com",
            SuccessUrl = "https://example.com",
            AllowPromoCodes = true,
            AllowTaxIDCollection = true,
            CollectBillingAddress = true,
            CollectPhoneNumber = true,

            ReferenceID = null,
        };

        Assert.Null(model.ReferenceID);
        Assert.True(model.RawData.ContainsKey("referenceId"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Subscriptions::CheckoutOptions
        {
            CancelUrl = "https://example.com",
            SuccessUrl = "https://example.com",
            AllowPromoCodes = true,
            AllowTaxIDCollection = true,
            CollectBillingAddress = true,
            CollectPhoneNumber = true,

            ReferenceID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Subscriptions::CheckoutOptions
        {
            CancelUrl = "https://example.com",
            SuccessUrl = "https://example.com",
            AllowPromoCodes = true,
            AllowTaxIDCollection = true,
            CollectBillingAddress = true,
            CollectPhoneNumber = true,
            ReferenceID = "referenceId",
        };

        Subscriptions::CheckoutOptions copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MinimumSpendTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::MinimumSpend
        {
            Minimum = new()
            {
                Amount = 0,
                BillingCountryCode = "billingCountryCode",
                Currency = Subscriptions::MinimumCurrency.Usd,
            },
        };

        Subscriptions::Minimum expectedMinimum = new()
        {
            Amount = 0,
            BillingCountryCode = "billingCountryCode",
            Currency = Subscriptions::MinimumCurrency.Usd,
        };

        Assert.Equal(expectedMinimum, model.Minimum);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscriptions::MinimumSpend
        {
            Minimum = new()
            {
                Amount = 0,
                BillingCountryCode = "billingCountryCode",
                Currency = Subscriptions::MinimumCurrency.Usd,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::MinimumSpend>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::MinimumSpend
        {
            Minimum = new()
            {
                Amount = 0,
                BillingCountryCode = "billingCountryCode",
                Currency = Subscriptions::MinimumCurrency.Usd,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::MinimumSpend>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Subscriptions::Minimum expectedMinimum = new()
        {
            Amount = 0,
            BillingCountryCode = "billingCountryCode",
            Currency = Subscriptions::MinimumCurrency.Usd,
        };

        Assert.Equal(expectedMinimum, deserialized.Minimum);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Subscriptions::MinimumSpend
        {
            Minimum = new()
            {
                Amount = 0,
                BillingCountryCode = "billingCountryCode",
                Currency = Subscriptions::MinimumCurrency.Usd,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Subscriptions::MinimumSpend { };

        Assert.Null(model.Minimum);
        Assert.False(model.RawData.ContainsKey("minimum"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Subscriptions::MinimumSpend { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Subscriptions::MinimumSpend { Minimum = null };

        Assert.Null(model.Minimum);
        Assert.True(model.RawData.ContainsKey("minimum"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Subscriptions::MinimumSpend { Minimum = null };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Subscriptions::MinimumSpend
        {
            Minimum = new()
            {
                Amount = 0,
                BillingCountryCode = "billingCountryCode",
                Currency = Subscriptions::MinimumCurrency.Usd,
            },
        };

        Subscriptions::MinimumSpend copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MinimumTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::Minimum
        {
            Amount = 0,
            BillingCountryCode = "billingCountryCode",
            Currency = Subscriptions::MinimumCurrency.Usd,
        };

        double expectedAmount = 0;
        string expectedBillingCountryCode = "billingCountryCode";
        ApiEnum<string, Subscriptions::MinimumCurrency> expectedCurrency =
            Subscriptions::MinimumCurrency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedBillingCountryCode, model.BillingCountryCode);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscriptions::Minimum
        {
            Amount = 0,
            BillingCountryCode = "billingCountryCode",
            Currency = Subscriptions::MinimumCurrency.Usd,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Minimum>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::Minimum
        {
            Amount = 0,
            BillingCountryCode = "billingCountryCode",
            Currency = Subscriptions::MinimumCurrency.Usd,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Minimum>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        string expectedBillingCountryCode = "billingCountryCode";
        ApiEnum<string, Subscriptions::MinimumCurrency> expectedCurrency =
            Subscriptions::MinimumCurrency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedBillingCountryCode, deserialized.BillingCountryCode);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Subscriptions::Minimum
        {
            Amount = 0,
            BillingCountryCode = "billingCountryCode",
            Currency = Subscriptions::MinimumCurrency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Subscriptions::Minimum { BillingCountryCode = "billingCountryCode" };

        Assert.Null(model.Amount);
        Assert.False(model.RawData.ContainsKey("amount"));
        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Subscriptions::Minimum { BillingCountryCode = "billingCountryCode" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Subscriptions::Minimum
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
        var model = new Subscriptions::Minimum
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
        var model = new Subscriptions::Minimum
        {
            Amount = 0,
            Currency = Subscriptions::MinimumCurrency.Usd,
        };

        Assert.Null(model.BillingCountryCode);
        Assert.False(model.RawData.ContainsKey("billingCountryCode"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Subscriptions::Minimum
        {
            Amount = 0,
            Currency = Subscriptions::MinimumCurrency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Subscriptions::Minimum
        {
            Amount = 0,
            Currency = Subscriptions::MinimumCurrency.Usd,

            BillingCountryCode = null,
        };

        Assert.Null(model.BillingCountryCode);
        Assert.True(model.RawData.ContainsKey("billingCountryCode"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Subscriptions::Minimum
        {
            Amount = 0,
            Currency = Subscriptions::MinimumCurrency.Usd,

            BillingCountryCode = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Subscriptions::Minimum
        {
            Amount = 0,
            BillingCountryCode = "billingCountryCode",
            Currency = Subscriptions::MinimumCurrency.Usd,
        };

        Subscriptions::Minimum copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MinimumCurrencyTest : TestBase
{
    [Theory]
    [InlineData(Subscriptions::MinimumCurrency.Usd)]
    [InlineData(Subscriptions::MinimumCurrency.Aed)]
    [InlineData(Subscriptions::MinimumCurrency.All)]
    [InlineData(Subscriptions::MinimumCurrency.Amd)]
    [InlineData(Subscriptions::MinimumCurrency.Ang)]
    [InlineData(Subscriptions::MinimumCurrency.Aud)]
    [InlineData(Subscriptions::MinimumCurrency.Awg)]
    [InlineData(Subscriptions::MinimumCurrency.Azn)]
    [InlineData(Subscriptions::MinimumCurrency.Bam)]
    [InlineData(Subscriptions::MinimumCurrency.Bbd)]
    [InlineData(Subscriptions::MinimumCurrency.Bdt)]
    [InlineData(Subscriptions::MinimumCurrency.Bgn)]
    [InlineData(Subscriptions::MinimumCurrency.Bif)]
    [InlineData(Subscriptions::MinimumCurrency.Bmd)]
    [InlineData(Subscriptions::MinimumCurrency.Bnd)]
    [InlineData(Subscriptions::MinimumCurrency.Bsd)]
    [InlineData(Subscriptions::MinimumCurrency.Bwp)]
    [InlineData(Subscriptions::MinimumCurrency.Byn)]
    [InlineData(Subscriptions::MinimumCurrency.Bzd)]
    [InlineData(Subscriptions::MinimumCurrency.Brl)]
    [InlineData(Subscriptions::MinimumCurrency.Cad)]
    [InlineData(Subscriptions::MinimumCurrency.Cdf)]
    [InlineData(Subscriptions::MinimumCurrency.Chf)]
    [InlineData(Subscriptions::MinimumCurrency.Cny)]
    [InlineData(Subscriptions::MinimumCurrency.Czk)]
    [InlineData(Subscriptions::MinimumCurrency.Dkk)]
    [InlineData(Subscriptions::MinimumCurrency.Dop)]
    [InlineData(Subscriptions::MinimumCurrency.Dzd)]
    [InlineData(Subscriptions::MinimumCurrency.Egp)]
    [InlineData(Subscriptions::MinimumCurrency.Etb)]
    [InlineData(Subscriptions::MinimumCurrency.Eur)]
    [InlineData(Subscriptions::MinimumCurrency.Fjd)]
    [InlineData(Subscriptions::MinimumCurrency.Gbp)]
    [InlineData(Subscriptions::MinimumCurrency.Gel)]
    [InlineData(Subscriptions::MinimumCurrency.Gip)]
    [InlineData(Subscriptions::MinimumCurrency.Gmd)]
    [InlineData(Subscriptions::MinimumCurrency.Gyd)]
    [InlineData(Subscriptions::MinimumCurrency.Hkd)]
    [InlineData(Subscriptions::MinimumCurrency.Hrk)]
    [InlineData(Subscriptions::MinimumCurrency.Htg)]
    [InlineData(Subscriptions::MinimumCurrency.Idr)]
    [InlineData(Subscriptions::MinimumCurrency.Ils)]
    [InlineData(Subscriptions::MinimumCurrency.Inr)]
    [InlineData(Subscriptions::MinimumCurrency.Isk)]
    [InlineData(Subscriptions::MinimumCurrency.Jmd)]
    [InlineData(Subscriptions::MinimumCurrency.Jpy)]
    [InlineData(Subscriptions::MinimumCurrency.Kes)]
    [InlineData(Subscriptions::MinimumCurrency.Kgs)]
    [InlineData(Subscriptions::MinimumCurrency.Khr)]
    [InlineData(Subscriptions::MinimumCurrency.Kmf)]
    [InlineData(Subscriptions::MinimumCurrency.Krw)]
    [InlineData(Subscriptions::MinimumCurrency.Kyd)]
    [InlineData(Subscriptions::MinimumCurrency.Kzt)]
    [InlineData(Subscriptions::MinimumCurrency.Lbp)]
    [InlineData(Subscriptions::MinimumCurrency.Lkr)]
    [InlineData(Subscriptions::MinimumCurrency.Lrd)]
    [InlineData(Subscriptions::MinimumCurrency.Lsl)]
    [InlineData(Subscriptions::MinimumCurrency.Mad)]
    [InlineData(Subscriptions::MinimumCurrency.Mdl)]
    [InlineData(Subscriptions::MinimumCurrency.Mga)]
    [InlineData(Subscriptions::MinimumCurrency.Mkd)]
    [InlineData(Subscriptions::MinimumCurrency.Mmk)]
    [InlineData(Subscriptions::MinimumCurrency.Mnt)]
    [InlineData(Subscriptions::MinimumCurrency.Mop)]
    [InlineData(Subscriptions::MinimumCurrency.Mro)]
    [InlineData(Subscriptions::MinimumCurrency.Mvr)]
    [InlineData(Subscriptions::MinimumCurrency.Mwk)]
    [InlineData(Subscriptions::MinimumCurrency.Mxn)]
    [InlineData(Subscriptions::MinimumCurrency.Myr)]
    [InlineData(Subscriptions::MinimumCurrency.Mzn)]
    [InlineData(Subscriptions::MinimumCurrency.Nad)]
    [InlineData(Subscriptions::MinimumCurrency.Ngn)]
    [InlineData(Subscriptions::MinimumCurrency.Nok)]
    [InlineData(Subscriptions::MinimumCurrency.Npr)]
    [InlineData(Subscriptions::MinimumCurrency.Nzd)]
    [InlineData(Subscriptions::MinimumCurrency.Pgk)]
    [InlineData(Subscriptions::MinimumCurrency.Php)]
    [InlineData(Subscriptions::MinimumCurrency.Pkr)]
    [InlineData(Subscriptions::MinimumCurrency.Pln)]
    [InlineData(Subscriptions::MinimumCurrency.Qar)]
    [InlineData(Subscriptions::MinimumCurrency.Ron)]
    [InlineData(Subscriptions::MinimumCurrency.Rsd)]
    [InlineData(Subscriptions::MinimumCurrency.Rub)]
    [InlineData(Subscriptions::MinimumCurrency.Rwf)]
    [InlineData(Subscriptions::MinimumCurrency.Sar)]
    [InlineData(Subscriptions::MinimumCurrency.Sbd)]
    [InlineData(Subscriptions::MinimumCurrency.Scr)]
    [InlineData(Subscriptions::MinimumCurrency.Sek)]
    [InlineData(Subscriptions::MinimumCurrency.Sgd)]
    [InlineData(Subscriptions::MinimumCurrency.Sle)]
    [InlineData(Subscriptions::MinimumCurrency.Sll)]
    [InlineData(Subscriptions::MinimumCurrency.Sos)]
    [InlineData(Subscriptions::MinimumCurrency.Szl)]
    [InlineData(Subscriptions::MinimumCurrency.Thb)]
    [InlineData(Subscriptions::MinimumCurrency.Tjs)]
    [InlineData(Subscriptions::MinimumCurrency.Top)]
    [InlineData(Subscriptions::MinimumCurrency.Try)]
    [InlineData(Subscriptions::MinimumCurrency.Ttd)]
    [InlineData(Subscriptions::MinimumCurrency.Tzs)]
    [InlineData(Subscriptions::MinimumCurrency.Uah)]
    [InlineData(Subscriptions::MinimumCurrency.Uzs)]
    [InlineData(Subscriptions::MinimumCurrency.Vnd)]
    [InlineData(Subscriptions::MinimumCurrency.Vuv)]
    [InlineData(Subscriptions::MinimumCurrency.Wst)]
    [InlineData(Subscriptions::MinimumCurrency.Xaf)]
    [InlineData(Subscriptions::MinimumCurrency.Xcd)]
    [InlineData(Subscriptions::MinimumCurrency.Yer)]
    [InlineData(Subscriptions::MinimumCurrency.Zar)]
    [InlineData(Subscriptions::MinimumCurrency.Zmw)]
    [InlineData(Subscriptions::MinimumCurrency.Clp)]
    [InlineData(Subscriptions::MinimumCurrency.Djf)]
    [InlineData(Subscriptions::MinimumCurrency.Gnf)]
    [InlineData(Subscriptions::MinimumCurrency.Ugx)]
    [InlineData(Subscriptions::MinimumCurrency.Pyg)]
    [InlineData(Subscriptions::MinimumCurrency.Xof)]
    [InlineData(Subscriptions::MinimumCurrency.Xpf)]
    public void Validation_Works(Subscriptions::MinimumCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::MinimumCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::MinimumCurrency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Subscriptions::MinimumCurrency.Usd)]
    [InlineData(Subscriptions::MinimumCurrency.Aed)]
    [InlineData(Subscriptions::MinimumCurrency.All)]
    [InlineData(Subscriptions::MinimumCurrency.Amd)]
    [InlineData(Subscriptions::MinimumCurrency.Ang)]
    [InlineData(Subscriptions::MinimumCurrency.Aud)]
    [InlineData(Subscriptions::MinimumCurrency.Awg)]
    [InlineData(Subscriptions::MinimumCurrency.Azn)]
    [InlineData(Subscriptions::MinimumCurrency.Bam)]
    [InlineData(Subscriptions::MinimumCurrency.Bbd)]
    [InlineData(Subscriptions::MinimumCurrency.Bdt)]
    [InlineData(Subscriptions::MinimumCurrency.Bgn)]
    [InlineData(Subscriptions::MinimumCurrency.Bif)]
    [InlineData(Subscriptions::MinimumCurrency.Bmd)]
    [InlineData(Subscriptions::MinimumCurrency.Bnd)]
    [InlineData(Subscriptions::MinimumCurrency.Bsd)]
    [InlineData(Subscriptions::MinimumCurrency.Bwp)]
    [InlineData(Subscriptions::MinimumCurrency.Byn)]
    [InlineData(Subscriptions::MinimumCurrency.Bzd)]
    [InlineData(Subscriptions::MinimumCurrency.Brl)]
    [InlineData(Subscriptions::MinimumCurrency.Cad)]
    [InlineData(Subscriptions::MinimumCurrency.Cdf)]
    [InlineData(Subscriptions::MinimumCurrency.Chf)]
    [InlineData(Subscriptions::MinimumCurrency.Cny)]
    [InlineData(Subscriptions::MinimumCurrency.Czk)]
    [InlineData(Subscriptions::MinimumCurrency.Dkk)]
    [InlineData(Subscriptions::MinimumCurrency.Dop)]
    [InlineData(Subscriptions::MinimumCurrency.Dzd)]
    [InlineData(Subscriptions::MinimumCurrency.Egp)]
    [InlineData(Subscriptions::MinimumCurrency.Etb)]
    [InlineData(Subscriptions::MinimumCurrency.Eur)]
    [InlineData(Subscriptions::MinimumCurrency.Fjd)]
    [InlineData(Subscriptions::MinimumCurrency.Gbp)]
    [InlineData(Subscriptions::MinimumCurrency.Gel)]
    [InlineData(Subscriptions::MinimumCurrency.Gip)]
    [InlineData(Subscriptions::MinimumCurrency.Gmd)]
    [InlineData(Subscriptions::MinimumCurrency.Gyd)]
    [InlineData(Subscriptions::MinimumCurrency.Hkd)]
    [InlineData(Subscriptions::MinimumCurrency.Hrk)]
    [InlineData(Subscriptions::MinimumCurrency.Htg)]
    [InlineData(Subscriptions::MinimumCurrency.Idr)]
    [InlineData(Subscriptions::MinimumCurrency.Ils)]
    [InlineData(Subscriptions::MinimumCurrency.Inr)]
    [InlineData(Subscriptions::MinimumCurrency.Isk)]
    [InlineData(Subscriptions::MinimumCurrency.Jmd)]
    [InlineData(Subscriptions::MinimumCurrency.Jpy)]
    [InlineData(Subscriptions::MinimumCurrency.Kes)]
    [InlineData(Subscriptions::MinimumCurrency.Kgs)]
    [InlineData(Subscriptions::MinimumCurrency.Khr)]
    [InlineData(Subscriptions::MinimumCurrency.Kmf)]
    [InlineData(Subscriptions::MinimumCurrency.Krw)]
    [InlineData(Subscriptions::MinimumCurrency.Kyd)]
    [InlineData(Subscriptions::MinimumCurrency.Kzt)]
    [InlineData(Subscriptions::MinimumCurrency.Lbp)]
    [InlineData(Subscriptions::MinimumCurrency.Lkr)]
    [InlineData(Subscriptions::MinimumCurrency.Lrd)]
    [InlineData(Subscriptions::MinimumCurrency.Lsl)]
    [InlineData(Subscriptions::MinimumCurrency.Mad)]
    [InlineData(Subscriptions::MinimumCurrency.Mdl)]
    [InlineData(Subscriptions::MinimumCurrency.Mga)]
    [InlineData(Subscriptions::MinimumCurrency.Mkd)]
    [InlineData(Subscriptions::MinimumCurrency.Mmk)]
    [InlineData(Subscriptions::MinimumCurrency.Mnt)]
    [InlineData(Subscriptions::MinimumCurrency.Mop)]
    [InlineData(Subscriptions::MinimumCurrency.Mro)]
    [InlineData(Subscriptions::MinimumCurrency.Mvr)]
    [InlineData(Subscriptions::MinimumCurrency.Mwk)]
    [InlineData(Subscriptions::MinimumCurrency.Mxn)]
    [InlineData(Subscriptions::MinimumCurrency.Myr)]
    [InlineData(Subscriptions::MinimumCurrency.Mzn)]
    [InlineData(Subscriptions::MinimumCurrency.Nad)]
    [InlineData(Subscriptions::MinimumCurrency.Ngn)]
    [InlineData(Subscriptions::MinimumCurrency.Nok)]
    [InlineData(Subscriptions::MinimumCurrency.Npr)]
    [InlineData(Subscriptions::MinimumCurrency.Nzd)]
    [InlineData(Subscriptions::MinimumCurrency.Pgk)]
    [InlineData(Subscriptions::MinimumCurrency.Php)]
    [InlineData(Subscriptions::MinimumCurrency.Pkr)]
    [InlineData(Subscriptions::MinimumCurrency.Pln)]
    [InlineData(Subscriptions::MinimumCurrency.Qar)]
    [InlineData(Subscriptions::MinimumCurrency.Ron)]
    [InlineData(Subscriptions::MinimumCurrency.Rsd)]
    [InlineData(Subscriptions::MinimumCurrency.Rub)]
    [InlineData(Subscriptions::MinimumCurrency.Rwf)]
    [InlineData(Subscriptions::MinimumCurrency.Sar)]
    [InlineData(Subscriptions::MinimumCurrency.Sbd)]
    [InlineData(Subscriptions::MinimumCurrency.Scr)]
    [InlineData(Subscriptions::MinimumCurrency.Sek)]
    [InlineData(Subscriptions::MinimumCurrency.Sgd)]
    [InlineData(Subscriptions::MinimumCurrency.Sle)]
    [InlineData(Subscriptions::MinimumCurrency.Sll)]
    [InlineData(Subscriptions::MinimumCurrency.Sos)]
    [InlineData(Subscriptions::MinimumCurrency.Szl)]
    [InlineData(Subscriptions::MinimumCurrency.Thb)]
    [InlineData(Subscriptions::MinimumCurrency.Tjs)]
    [InlineData(Subscriptions::MinimumCurrency.Top)]
    [InlineData(Subscriptions::MinimumCurrency.Try)]
    [InlineData(Subscriptions::MinimumCurrency.Ttd)]
    [InlineData(Subscriptions::MinimumCurrency.Tzs)]
    [InlineData(Subscriptions::MinimumCurrency.Uah)]
    [InlineData(Subscriptions::MinimumCurrency.Uzs)]
    [InlineData(Subscriptions::MinimumCurrency.Vnd)]
    [InlineData(Subscriptions::MinimumCurrency.Vuv)]
    [InlineData(Subscriptions::MinimumCurrency.Wst)]
    [InlineData(Subscriptions::MinimumCurrency.Xaf)]
    [InlineData(Subscriptions::MinimumCurrency.Xcd)]
    [InlineData(Subscriptions::MinimumCurrency.Yer)]
    [InlineData(Subscriptions::MinimumCurrency.Zar)]
    [InlineData(Subscriptions::MinimumCurrency.Zmw)]
    [InlineData(Subscriptions::MinimumCurrency.Clp)]
    [InlineData(Subscriptions::MinimumCurrency.Djf)]
    [InlineData(Subscriptions::MinimumCurrency.Gnf)]
    [InlineData(Subscriptions::MinimumCurrency.Ugx)]
    [InlineData(Subscriptions::MinimumCurrency.Pyg)]
    [InlineData(Subscriptions::MinimumCurrency.Xof)]
    [InlineData(Subscriptions::MinimumCurrency.Xpf)]
    public void SerializationRoundtrip_Works(Subscriptions::MinimumCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::MinimumCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::MinimumCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::MinimumCurrency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::MinimumCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PaymentCollectionMethodTest : TestBase
{
    [Theory]
    [InlineData(Subscriptions::PaymentCollectionMethod.Charge)]
    [InlineData(Subscriptions::PaymentCollectionMethod.Invoice)]
    [InlineData(Subscriptions::PaymentCollectionMethod.None)]
    public void Validation_Works(Subscriptions::PaymentCollectionMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::PaymentCollectionMethod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::PaymentCollectionMethod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Subscriptions::PaymentCollectionMethod.Charge)]
    [InlineData(Subscriptions::PaymentCollectionMethod.Invoice)]
    [InlineData(Subscriptions::PaymentCollectionMethod.None)]
    public void SerializationRoundtrip_Works(Subscriptions::PaymentCollectionMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::PaymentCollectionMethod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::PaymentCollectionMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::PaymentCollectionMethod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::PaymentCollectionMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PriceOverrideTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::PriceOverride
        {
            AddonID = "addonId",
            BaseCharge = true,
            BlockSize = 0,
            CreditGrantCadence = Subscriptions::CreditGrantCadence.BeginningOfBillingPeriod,
            CreditRate = new()
            {
                Amount = 1,
                CurrencyID = "currencyId",
                CostFormula = "costFormula",
            },
            FeatureID = "featureId",
            Price = new()
            {
                Amount = 0,
                BillingCountryCode = "billingCountryCode",
                Currency = Subscriptions::PriceCurrency.Usd,
            },
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
                        Currency = Subscriptions::FlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
                        Currency = Subscriptions::UnitPriceCurrency.Usd,
                    },
                    UpTo = 0,
                },
            ],
        };

        string expectedAddonID = "addonId";
        bool expectedBaseCharge = true;
        double expectedBlockSize = 0;
        ApiEnum<string, Subscriptions::CreditGrantCadence> expectedCreditGrantCadence =
            Subscriptions::CreditGrantCadence.BeginningOfBillingPeriod;
        Subscriptions::CreditRate expectedCreditRate = new()
        {
            Amount = 1,
            CurrencyID = "currencyId",
            CostFormula = "costFormula",
        };
        string expectedFeatureID = "featureId";
        Subscriptions::Price expectedPrice = new()
        {
            Amount = 0,
            BillingCountryCode = "billingCountryCode",
            Currency = Subscriptions::PriceCurrency.Usd,
        };
        List<Subscriptions::Tier> expectedTiers =
        [
            new()
            {
                FlatPrice = new()
                {
                    Amount = 0,
                    BillingCountryCode = "billingCountryCode",
                    Currency = Subscriptions::FlatPriceCurrency.Usd,
                },
                UnitPrice = new()
                {
                    Amount = 0,
                    BillingCountryCode = "billingCountryCode",
                    Currency = Subscriptions::UnitPriceCurrency.Usd,
                },
                UpTo = 0,
            },
        ];

        Assert.Equal(expectedAddonID, model.AddonID);
        Assert.Equal(expectedBaseCharge, model.BaseCharge);
        Assert.Equal(expectedBlockSize, model.BlockSize);
        Assert.Equal(expectedCreditGrantCadence, model.CreditGrantCadence);
        Assert.Equal(expectedCreditRate, model.CreditRate);
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
        var model = new Subscriptions::PriceOverride
        {
            AddonID = "addonId",
            BaseCharge = true,
            BlockSize = 0,
            CreditGrantCadence = Subscriptions::CreditGrantCadence.BeginningOfBillingPeriod,
            CreditRate = new()
            {
                Amount = 1,
                CurrencyID = "currencyId",
                CostFormula = "costFormula",
            },
            FeatureID = "featureId",
            Price = new()
            {
                Amount = 0,
                BillingCountryCode = "billingCountryCode",
                Currency = Subscriptions::PriceCurrency.Usd,
            },
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
                        Currency = Subscriptions::FlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
                        Currency = Subscriptions::UnitPriceCurrency.Usd,
                    },
                    UpTo = 0,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::PriceOverride>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::PriceOverride
        {
            AddonID = "addonId",
            BaseCharge = true,
            BlockSize = 0,
            CreditGrantCadence = Subscriptions::CreditGrantCadence.BeginningOfBillingPeriod,
            CreditRate = new()
            {
                Amount = 1,
                CurrencyID = "currencyId",
                CostFormula = "costFormula",
            },
            FeatureID = "featureId",
            Price = new()
            {
                Amount = 0,
                BillingCountryCode = "billingCountryCode",
                Currency = Subscriptions::PriceCurrency.Usd,
            },
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
                        Currency = Subscriptions::FlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
                        Currency = Subscriptions::UnitPriceCurrency.Usd,
                    },
                    UpTo = 0,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::PriceOverride>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAddonID = "addonId";
        bool expectedBaseCharge = true;
        double expectedBlockSize = 0;
        ApiEnum<string, Subscriptions::CreditGrantCadence> expectedCreditGrantCadence =
            Subscriptions::CreditGrantCadence.BeginningOfBillingPeriod;
        Subscriptions::CreditRate expectedCreditRate = new()
        {
            Amount = 1,
            CurrencyID = "currencyId",
            CostFormula = "costFormula",
        };
        string expectedFeatureID = "featureId";
        Subscriptions::Price expectedPrice = new()
        {
            Amount = 0,
            BillingCountryCode = "billingCountryCode",
            Currency = Subscriptions::PriceCurrency.Usd,
        };
        List<Subscriptions::Tier> expectedTiers =
        [
            new()
            {
                FlatPrice = new()
                {
                    Amount = 0,
                    BillingCountryCode = "billingCountryCode",
                    Currency = Subscriptions::FlatPriceCurrency.Usd,
                },
                UnitPrice = new()
                {
                    Amount = 0,
                    BillingCountryCode = "billingCountryCode",
                    Currency = Subscriptions::UnitPriceCurrency.Usd,
                },
                UpTo = 0,
            },
        ];

        Assert.Equal(expectedAddonID, deserialized.AddonID);
        Assert.Equal(expectedBaseCharge, deserialized.BaseCharge);
        Assert.Equal(expectedBlockSize, deserialized.BlockSize);
        Assert.Equal(expectedCreditGrantCadence, deserialized.CreditGrantCadence);
        Assert.Equal(expectedCreditRate, deserialized.CreditRate);
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
        var model = new Subscriptions::PriceOverride
        {
            AddonID = "addonId",
            BaseCharge = true,
            BlockSize = 0,
            CreditGrantCadence = Subscriptions::CreditGrantCadence.BeginningOfBillingPeriod,
            CreditRate = new()
            {
                Amount = 1,
                CurrencyID = "currencyId",
                CostFormula = "costFormula",
            },
            FeatureID = "featureId",
            Price = new()
            {
                Amount = 0,
                BillingCountryCode = "billingCountryCode",
                Currency = Subscriptions::PriceCurrency.Usd,
            },
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
                        Currency = Subscriptions::FlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
                        Currency = Subscriptions::UnitPriceCurrency.Usd,
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
        var model = new Subscriptions::PriceOverride
        {
            AddonID = "addonId",
            FeatureID = "featureId",
        };

        Assert.Null(model.BaseCharge);
        Assert.False(model.RawData.ContainsKey("baseCharge"));
        Assert.Null(model.BlockSize);
        Assert.False(model.RawData.ContainsKey("blockSize"));
        Assert.Null(model.CreditGrantCadence);
        Assert.False(model.RawData.ContainsKey("creditGrantCadence"));
        Assert.Null(model.CreditRate);
        Assert.False(model.RawData.ContainsKey("creditRate"));
        Assert.Null(model.Price);
        Assert.False(model.RawData.ContainsKey("price"));
        Assert.Null(model.Tiers);
        Assert.False(model.RawData.ContainsKey("tiers"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Subscriptions::PriceOverride
        {
            AddonID = "addonId",
            FeatureID = "featureId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Subscriptions::PriceOverride
        {
            AddonID = "addonId",
            FeatureID = "featureId",

            // Null should be interpreted as omitted for these properties
            BaseCharge = null,
            BlockSize = null,
            CreditGrantCadence = null,
            CreditRate = null,
            Price = null,
            Tiers = null,
        };

        Assert.Null(model.BaseCharge);
        Assert.False(model.RawData.ContainsKey("baseCharge"));
        Assert.Null(model.BlockSize);
        Assert.False(model.RawData.ContainsKey("blockSize"));
        Assert.Null(model.CreditGrantCadence);
        Assert.False(model.RawData.ContainsKey("creditGrantCadence"));
        Assert.Null(model.CreditRate);
        Assert.False(model.RawData.ContainsKey("creditRate"));
        Assert.Null(model.Price);
        Assert.False(model.RawData.ContainsKey("price"));
        Assert.Null(model.Tiers);
        Assert.False(model.RawData.ContainsKey("tiers"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Subscriptions::PriceOverride
        {
            AddonID = "addonId",
            FeatureID = "featureId",

            // Null should be interpreted as omitted for these properties
            BaseCharge = null,
            BlockSize = null,
            CreditGrantCadence = null,
            CreditRate = null,
            Price = null,
            Tiers = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Subscriptions::PriceOverride
        {
            BaseCharge = true,
            BlockSize = 0,
            CreditGrantCadence = Subscriptions::CreditGrantCadence.BeginningOfBillingPeriod,
            CreditRate = new()
            {
                Amount = 1,
                CurrencyID = "currencyId",
                CostFormula = "costFormula",
            },
            Price = new()
            {
                Amount = 0,
                BillingCountryCode = "billingCountryCode",
                Currency = Subscriptions::PriceCurrency.Usd,
            },
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
                        Currency = Subscriptions::FlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
                        Currency = Subscriptions::UnitPriceCurrency.Usd,
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
        var model = new Subscriptions::PriceOverride
        {
            BaseCharge = true,
            BlockSize = 0,
            CreditGrantCadence = Subscriptions::CreditGrantCadence.BeginningOfBillingPeriod,
            CreditRate = new()
            {
                Amount = 1,
                CurrencyID = "currencyId",
                CostFormula = "costFormula",
            },
            Price = new()
            {
                Amount = 0,
                BillingCountryCode = "billingCountryCode",
                Currency = Subscriptions::PriceCurrency.Usd,
            },
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
                        Currency = Subscriptions::FlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
                        Currency = Subscriptions::UnitPriceCurrency.Usd,
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
        var model = new Subscriptions::PriceOverride
        {
            BaseCharge = true,
            BlockSize = 0,
            CreditGrantCadence = Subscriptions::CreditGrantCadence.BeginningOfBillingPeriod,
            CreditRate = new()
            {
                Amount = 1,
                CurrencyID = "currencyId",
                CostFormula = "costFormula",
            },
            Price = new()
            {
                Amount = 0,
                BillingCountryCode = "billingCountryCode",
                Currency = Subscriptions::PriceCurrency.Usd,
            },
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
                        Currency = Subscriptions::FlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
                        Currency = Subscriptions::UnitPriceCurrency.Usd,
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
        var model = new Subscriptions::PriceOverride
        {
            BaseCharge = true,
            BlockSize = 0,
            CreditGrantCadence = Subscriptions::CreditGrantCadence.BeginningOfBillingPeriod,
            CreditRate = new()
            {
                Amount = 1,
                CurrencyID = "currencyId",
                CostFormula = "costFormula",
            },
            Price = new()
            {
                Amount = 0,
                BillingCountryCode = "billingCountryCode",
                Currency = Subscriptions::PriceCurrency.Usd,
            },
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
                        Currency = Subscriptions::FlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
                        Currency = Subscriptions::UnitPriceCurrency.Usd,
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
        var model = new Subscriptions::PriceOverride
        {
            AddonID = "addonId",
            BaseCharge = true,
            BlockSize = 0,
            CreditGrantCadence = Subscriptions::CreditGrantCadence.BeginningOfBillingPeriod,
            CreditRate = new()
            {
                Amount = 1,
                CurrencyID = "currencyId",
                CostFormula = "costFormula",
            },
            FeatureID = "featureId",
            Price = new()
            {
                Amount = 0,
                BillingCountryCode = "billingCountryCode",
                Currency = Subscriptions::PriceCurrency.Usd,
            },
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
                        Currency = Subscriptions::FlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        BillingCountryCode = "billingCountryCode",
                        Currency = Subscriptions::UnitPriceCurrency.Usd,
                    },
                    UpTo = 0,
                },
            ],
        };

        Subscriptions::PriceOverride copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CreditGrantCadenceTest : TestBase
{
    [Theory]
    [InlineData(Subscriptions::CreditGrantCadence.BeginningOfBillingPeriod)]
    [InlineData(Subscriptions::CreditGrantCadence.Monthly)]
    public void Validation_Works(Subscriptions::CreditGrantCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::CreditGrantCadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::CreditGrantCadence>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Subscriptions::CreditGrantCadence.BeginningOfBillingPeriod)]
    [InlineData(Subscriptions::CreditGrantCadence.Monthly)]
    public void SerializationRoundtrip_Works(Subscriptions::CreditGrantCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::CreditGrantCadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::CreditGrantCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::CreditGrantCadence>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::CreditGrantCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CreditRateTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::CreditRate
        {
            Amount = 1,
            CurrencyID = "currencyId",
            CostFormula = "costFormula",
        };

        double expectedAmount = 1;
        string expectedCurrencyID = "currencyId";
        string expectedCostFormula = "costFormula";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrencyID, model.CurrencyID);
        Assert.Equal(expectedCostFormula, model.CostFormula);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscriptions::CreditRate
        {
            Amount = 1,
            CurrencyID = "currencyId",
            CostFormula = "costFormula",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::CreditRate>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::CreditRate
        {
            Amount = 1,
            CurrencyID = "currencyId",
            CostFormula = "costFormula",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::CreditRate>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAmount = 1;
        string expectedCurrencyID = "currencyId";
        string expectedCostFormula = "costFormula";

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrencyID, deserialized.CurrencyID);
        Assert.Equal(expectedCostFormula, deserialized.CostFormula);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Subscriptions::CreditRate
        {
            Amount = 1,
            CurrencyID = "currencyId",
            CostFormula = "costFormula",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Subscriptions::CreditRate { Amount = 1, CurrencyID = "currencyId" };

        Assert.Null(model.CostFormula);
        Assert.False(model.RawData.ContainsKey("costFormula"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Subscriptions::CreditRate { Amount = 1, CurrencyID = "currencyId" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Subscriptions::CreditRate
        {
            Amount = 1,
            CurrencyID = "currencyId",

            CostFormula = null,
        };

        Assert.Null(model.CostFormula);
        Assert.True(model.RawData.ContainsKey("costFormula"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Subscriptions::CreditRate
        {
            Amount = 1,
            CurrencyID = "currencyId",

            CostFormula = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Subscriptions::CreditRate
        {
            Amount = 1,
            CurrencyID = "currencyId",
            CostFormula = "costFormula",
        };

        Subscriptions::CreditRate copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::Price
        {
            Amount = 0,
            BillingCountryCode = "billingCountryCode",
            Currency = Subscriptions::PriceCurrency.Usd,
        };

        double expectedAmount = 0;
        string expectedBillingCountryCode = "billingCountryCode";
        ApiEnum<string, Subscriptions::PriceCurrency> expectedCurrency =
            Subscriptions::PriceCurrency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedBillingCountryCode, model.BillingCountryCode);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscriptions::Price
        {
            Amount = 0,
            BillingCountryCode = "billingCountryCode",
            Currency = Subscriptions::PriceCurrency.Usd,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Price>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::Price
        {
            Amount = 0,
            BillingCountryCode = "billingCountryCode",
            Currency = Subscriptions::PriceCurrency.Usd,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Price>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        string expectedBillingCountryCode = "billingCountryCode";
        ApiEnum<string, Subscriptions::PriceCurrency> expectedCurrency =
            Subscriptions::PriceCurrency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedBillingCountryCode, deserialized.BillingCountryCode);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Subscriptions::Price
        {
            Amount = 0,
            BillingCountryCode = "billingCountryCode",
            Currency = Subscriptions::PriceCurrency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Subscriptions::Price { BillingCountryCode = "billingCountryCode" };

        Assert.Null(model.Amount);
        Assert.False(model.RawData.ContainsKey("amount"));
        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Subscriptions::Price { BillingCountryCode = "billingCountryCode" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Subscriptions::Price
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
        var model = new Subscriptions::Price
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
        var model = new Subscriptions::Price
        {
            Amount = 0,
            Currency = Subscriptions::PriceCurrency.Usd,
        };

        Assert.Null(model.BillingCountryCode);
        Assert.False(model.RawData.ContainsKey("billingCountryCode"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Subscriptions::Price
        {
            Amount = 0,
            Currency = Subscriptions::PriceCurrency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Subscriptions::Price
        {
            Amount = 0,
            Currency = Subscriptions::PriceCurrency.Usd,

            BillingCountryCode = null,
        };

        Assert.Null(model.BillingCountryCode);
        Assert.True(model.RawData.ContainsKey("billingCountryCode"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Subscriptions::Price
        {
            Amount = 0,
            Currency = Subscriptions::PriceCurrency.Usd,

            BillingCountryCode = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Subscriptions::Price
        {
            Amount = 0,
            BillingCountryCode = "billingCountryCode",
            Currency = Subscriptions::PriceCurrency.Usd,
        };

        Subscriptions::Price copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PriceCurrencyTest : TestBase
{
    [Theory]
    [InlineData(Subscriptions::PriceCurrency.Usd)]
    [InlineData(Subscriptions::PriceCurrency.Aed)]
    [InlineData(Subscriptions::PriceCurrency.All)]
    [InlineData(Subscriptions::PriceCurrency.Amd)]
    [InlineData(Subscriptions::PriceCurrency.Ang)]
    [InlineData(Subscriptions::PriceCurrency.Aud)]
    [InlineData(Subscriptions::PriceCurrency.Awg)]
    [InlineData(Subscriptions::PriceCurrency.Azn)]
    [InlineData(Subscriptions::PriceCurrency.Bam)]
    [InlineData(Subscriptions::PriceCurrency.Bbd)]
    [InlineData(Subscriptions::PriceCurrency.Bdt)]
    [InlineData(Subscriptions::PriceCurrency.Bgn)]
    [InlineData(Subscriptions::PriceCurrency.Bif)]
    [InlineData(Subscriptions::PriceCurrency.Bmd)]
    [InlineData(Subscriptions::PriceCurrency.Bnd)]
    [InlineData(Subscriptions::PriceCurrency.Bsd)]
    [InlineData(Subscriptions::PriceCurrency.Bwp)]
    [InlineData(Subscriptions::PriceCurrency.Byn)]
    [InlineData(Subscriptions::PriceCurrency.Bzd)]
    [InlineData(Subscriptions::PriceCurrency.Brl)]
    [InlineData(Subscriptions::PriceCurrency.Cad)]
    [InlineData(Subscriptions::PriceCurrency.Cdf)]
    [InlineData(Subscriptions::PriceCurrency.Chf)]
    [InlineData(Subscriptions::PriceCurrency.Cny)]
    [InlineData(Subscriptions::PriceCurrency.Czk)]
    [InlineData(Subscriptions::PriceCurrency.Dkk)]
    [InlineData(Subscriptions::PriceCurrency.Dop)]
    [InlineData(Subscriptions::PriceCurrency.Dzd)]
    [InlineData(Subscriptions::PriceCurrency.Egp)]
    [InlineData(Subscriptions::PriceCurrency.Etb)]
    [InlineData(Subscriptions::PriceCurrency.Eur)]
    [InlineData(Subscriptions::PriceCurrency.Fjd)]
    [InlineData(Subscriptions::PriceCurrency.Gbp)]
    [InlineData(Subscriptions::PriceCurrency.Gel)]
    [InlineData(Subscriptions::PriceCurrency.Gip)]
    [InlineData(Subscriptions::PriceCurrency.Gmd)]
    [InlineData(Subscriptions::PriceCurrency.Gyd)]
    [InlineData(Subscriptions::PriceCurrency.Hkd)]
    [InlineData(Subscriptions::PriceCurrency.Hrk)]
    [InlineData(Subscriptions::PriceCurrency.Htg)]
    [InlineData(Subscriptions::PriceCurrency.Idr)]
    [InlineData(Subscriptions::PriceCurrency.Ils)]
    [InlineData(Subscriptions::PriceCurrency.Inr)]
    [InlineData(Subscriptions::PriceCurrency.Isk)]
    [InlineData(Subscriptions::PriceCurrency.Jmd)]
    [InlineData(Subscriptions::PriceCurrency.Jpy)]
    [InlineData(Subscriptions::PriceCurrency.Kes)]
    [InlineData(Subscriptions::PriceCurrency.Kgs)]
    [InlineData(Subscriptions::PriceCurrency.Khr)]
    [InlineData(Subscriptions::PriceCurrency.Kmf)]
    [InlineData(Subscriptions::PriceCurrency.Krw)]
    [InlineData(Subscriptions::PriceCurrency.Kyd)]
    [InlineData(Subscriptions::PriceCurrency.Kzt)]
    [InlineData(Subscriptions::PriceCurrency.Lbp)]
    [InlineData(Subscriptions::PriceCurrency.Lkr)]
    [InlineData(Subscriptions::PriceCurrency.Lrd)]
    [InlineData(Subscriptions::PriceCurrency.Lsl)]
    [InlineData(Subscriptions::PriceCurrency.Mad)]
    [InlineData(Subscriptions::PriceCurrency.Mdl)]
    [InlineData(Subscriptions::PriceCurrency.Mga)]
    [InlineData(Subscriptions::PriceCurrency.Mkd)]
    [InlineData(Subscriptions::PriceCurrency.Mmk)]
    [InlineData(Subscriptions::PriceCurrency.Mnt)]
    [InlineData(Subscriptions::PriceCurrency.Mop)]
    [InlineData(Subscriptions::PriceCurrency.Mro)]
    [InlineData(Subscriptions::PriceCurrency.Mvr)]
    [InlineData(Subscriptions::PriceCurrency.Mwk)]
    [InlineData(Subscriptions::PriceCurrency.Mxn)]
    [InlineData(Subscriptions::PriceCurrency.Myr)]
    [InlineData(Subscriptions::PriceCurrency.Mzn)]
    [InlineData(Subscriptions::PriceCurrency.Nad)]
    [InlineData(Subscriptions::PriceCurrency.Ngn)]
    [InlineData(Subscriptions::PriceCurrency.Nok)]
    [InlineData(Subscriptions::PriceCurrency.Npr)]
    [InlineData(Subscriptions::PriceCurrency.Nzd)]
    [InlineData(Subscriptions::PriceCurrency.Pgk)]
    [InlineData(Subscriptions::PriceCurrency.Php)]
    [InlineData(Subscriptions::PriceCurrency.Pkr)]
    [InlineData(Subscriptions::PriceCurrency.Pln)]
    [InlineData(Subscriptions::PriceCurrency.Qar)]
    [InlineData(Subscriptions::PriceCurrency.Ron)]
    [InlineData(Subscriptions::PriceCurrency.Rsd)]
    [InlineData(Subscriptions::PriceCurrency.Rub)]
    [InlineData(Subscriptions::PriceCurrency.Rwf)]
    [InlineData(Subscriptions::PriceCurrency.Sar)]
    [InlineData(Subscriptions::PriceCurrency.Sbd)]
    [InlineData(Subscriptions::PriceCurrency.Scr)]
    [InlineData(Subscriptions::PriceCurrency.Sek)]
    [InlineData(Subscriptions::PriceCurrency.Sgd)]
    [InlineData(Subscriptions::PriceCurrency.Sle)]
    [InlineData(Subscriptions::PriceCurrency.Sll)]
    [InlineData(Subscriptions::PriceCurrency.Sos)]
    [InlineData(Subscriptions::PriceCurrency.Szl)]
    [InlineData(Subscriptions::PriceCurrency.Thb)]
    [InlineData(Subscriptions::PriceCurrency.Tjs)]
    [InlineData(Subscriptions::PriceCurrency.Top)]
    [InlineData(Subscriptions::PriceCurrency.Try)]
    [InlineData(Subscriptions::PriceCurrency.Ttd)]
    [InlineData(Subscriptions::PriceCurrency.Tzs)]
    [InlineData(Subscriptions::PriceCurrency.Uah)]
    [InlineData(Subscriptions::PriceCurrency.Uzs)]
    [InlineData(Subscriptions::PriceCurrency.Vnd)]
    [InlineData(Subscriptions::PriceCurrency.Vuv)]
    [InlineData(Subscriptions::PriceCurrency.Wst)]
    [InlineData(Subscriptions::PriceCurrency.Xaf)]
    [InlineData(Subscriptions::PriceCurrency.Xcd)]
    [InlineData(Subscriptions::PriceCurrency.Yer)]
    [InlineData(Subscriptions::PriceCurrency.Zar)]
    [InlineData(Subscriptions::PriceCurrency.Zmw)]
    [InlineData(Subscriptions::PriceCurrency.Clp)]
    [InlineData(Subscriptions::PriceCurrency.Djf)]
    [InlineData(Subscriptions::PriceCurrency.Gnf)]
    [InlineData(Subscriptions::PriceCurrency.Ugx)]
    [InlineData(Subscriptions::PriceCurrency.Pyg)]
    [InlineData(Subscriptions::PriceCurrency.Xof)]
    [InlineData(Subscriptions::PriceCurrency.Xpf)]
    public void Validation_Works(Subscriptions::PriceCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::PriceCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::PriceCurrency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Subscriptions::PriceCurrency.Usd)]
    [InlineData(Subscriptions::PriceCurrency.Aed)]
    [InlineData(Subscriptions::PriceCurrency.All)]
    [InlineData(Subscriptions::PriceCurrency.Amd)]
    [InlineData(Subscriptions::PriceCurrency.Ang)]
    [InlineData(Subscriptions::PriceCurrency.Aud)]
    [InlineData(Subscriptions::PriceCurrency.Awg)]
    [InlineData(Subscriptions::PriceCurrency.Azn)]
    [InlineData(Subscriptions::PriceCurrency.Bam)]
    [InlineData(Subscriptions::PriceCurrency.Bbd)]
    [InlineData(Subscriptions::PriceCurrency.Bdt)]
    [InlineData(Subscriptions::PriceCurrency.Bgn)]
    [InlineData(Subscriptions::PriceCurrency.Bif)]
    [InlineData(Subscriptions::PriceCurrency.Bmd)]
    [InlineData(Subscriptions::PriceCurrency.Bnd)]
    [InlineData(Subscriptions::PriceCurrency.Bsd)]
    [InlineData(Subscriptions::PriceCurrency.Bwp)]
    [InlineData(Subscriptions::PriceCurrency.Byn)]
    [InlineData(Subscriptions::PriceCurrency.Bzd)]
    [InlineData(Subscriptions::PriceCurrency.Brl)]
    [InlineData(Subscriptions::PriceCurrency.Cad)]
    [InlineData(Subscriptions::PriceCurrency.Cdf)]
    [InlineData(Subscriptions::PriceCurrency.Chf)]
    [InlineData(Subscriptions::PriceCurrency.Cny)]
    [InlineData(Subscriptions::PriceCurrency.Czk)]
    [InlineData(Subscriptions::PriceCurrency.Dkk)]
    [InlineData(Subscriptions::PriceCurrency.Dop)]
    [InlineData(Subscriptions::PriceCurrency.Dzd)]
    [InlineData(Subscriptions::PriceCurrency.Egp)]
    [InlineData(Subscriptions::PriceCurrency.Etb)]
    [InlineData(Subscriptions::PriceCurrency.Eur)]
    [InlineData(Subscriptions::PriceCurrency.Fjd)]
    [InlineData(Subscriptions::PriceCurrency.Gbp)]
    [InlineData(Subscriptions::PriceCurrency.Gel)]
    [InlineData(Subscriptions::PriceCurrency.Gip)]
    [InlineData(Subscriptions::PriceCurrency.Gmd)]
    [InlineData(Subscriptions::PriceCurrency.Gyd)]
    [InlineData(Subscriptions::PriceCurrency.Hkd)]
    [InlineData(Subscriptions::PriceCurrency.Hrk)]
    [InlineData(Subscriptions::PriceCurrency.Htg)]
    [InlineData(Subscriptions::PriceCurrency.Idr)]
    [InlineData(Subscriptions::PriceCurrency.Ils)]
    [InlineData(Subscriptions::PriceCurrency.Inr)]
    [InlineData(Subscriptions::PriceCurrency.Isk)]
    [InlineData(Subscriptions::PriceCurrency.Jmd)]
    [InlineData(Subscriptions::PriceCurrency.Jpy)]
    [InlineData(Subscriptions::PriceCurrency.Kes)]
    [InlineData(Subscriptions::PriceCurrency.Kgs)]
    [InlineData(Subscriptions::PriceCurrency.Khr)]
    [InlineData(Subscriptions::PriceCurrency.Kmf)]
    [InlineData(Subscriptions::PriceCurrency.Krw)]
    [InlineData(Subscriptions::PriceCurrency.Kyd)]
    [InlineData(Subscriptions::PriceCurrency.Kzt)]
    [InlineData(Subscriptions::PriceCurrency.Lbp)]
    [InlineData(Subscriptions::PriceCurrency.Lkr)]
    [InlineData(Subscriptions::PriceCurrency.Lrd)]
    [InlineData(Subscriptions::PriceCurrency.Lsl)]
    [InlineData(Subscriptions::PriceCurrency.Mad)]
    [InlineData(Subscriptions::PriceCurrency.Mdl)]
    [InlineData(Subscriptions::PriceCurrency.Mga)]
    [InlineData(Subscriptions::PriceCurrency.Mkd)]
    [InlineData(Subscriptions::PriceCurrency.Mmk)]
    [InlineData(Subscriptions::PriceCurrency.Mnt)]
    [InlineData(Subscriptions::PriceCurrency.Mop)]
    [InlineData(Subscriptions::PriceCurrency.Mro)]
    [InlineData(Subscriptions::PriceCurrency.Mvr)]
    [InlineData(Subscriptions::PriceCurrency.Mwk)]
    [InlineData(Subscriptions::PriceCurrency.Mxn)]
    [InlineData(Subscriptions::PriceCurrency.Myr)]
    [InlineData(Subscriptions::PriceCurrency.Mzn)]
    [InlineData(Subscriptions::PriceCurrency.Nad)]
    [InlineData(Subscriptions::PriceCurrency.Ngn)]
    [InlineData(Subscriptions::PriceCurrency.Nok)]
    [InlineData(Subscriptions::PriceCurrency.Npr)]
    [InlineData(Subscriptions::PriceCurrency.Nzd)]
    [InlineData(Subscriptions::PriceCurrency.Pgk)]
    [InlineData(Subscriptions::PriceCurrency.Php)]
    [InlineData(Subscriptions::PriceCurrency.Pkr)]
    [InlineData(Subscriptions::PriceCurrency.Pln)]
    [InlineData(Subscriptions::PriceCurrency.Qar)]
    [InlineData(Subscriptions::PriceCurrency.Ron)]
    [InlineData(Subscriptions::PriceCurrency.Rsd)]
    [InlineData(Subscriptions::PriceCurrency.Rub)]
    [InlineData(Subscriptions::PriceCurrency.Rwf)]
    [InlineData(Subscriptions::PriceCurrency.Sar)]
    [InlineData(Subscriptions::PriceCurrency.Sbd)]
    [InlineData(Subscriptions::PriceCurrency.Scr)]
    [InlineData(Subscriptions::PriceCurrency.Sek)]
    [InlineData(Subscriptions::PriceCurrency.Sgd)]
    [InlineData(Subscriptions::PriceCurrency.Sle)]
    [InlineData(Subscriptions::PriceCurrency.Sll)]
    [InlineData(Subscriptions::PriceCurrency.Sos)]
    [InlineData(Subscriptions::PriceCurrency.Szl)]
    [InlineData(Subscriptions::PriceCurrency.Thb)]
    [InlineData(Subscriptions::PriceCurrency.Tjs)]
    [InlineData(Subscriptions::PriceCurrency.Top)]
    [InlineData(Subscriptions::PriceCurrency.Try)]
    [InlineData(Subscriptions::PriceCurrency.Ttd)]
    [InlineData(Subscriptions::PriceCurrency.Tzs)]
    [InlineData(Subscriptions::PriceCurrency.Uah)]
    [InlineData(Subscriptions::PriceCurrency.Uzs)]
    [InlineData(Subscriptions::PriceCurrency.Vnd)]
    [InlineData(Subscriptions::PriceCurrency.Vuv)]
    [InlineData(Subscriptions::PriceCurrency.Wst)]
    [InlineData(Subscriptions::PriceCurrency.Xaf)]
    [InlineData(Subscriptions::PriceCurrency.Xcd)]
    [InlineData(Subscriptions::PriceCurrency.Yer)]
    [InlineData(Subscriptions::PriceCurrency.Zar)]
    [InlineData(Subscriptions::PriceCurrency.Zmw)]
    [InlineData(Subscriptions::PriceCurrency.Clp)]
    [InlineData(Subscriptions::PriceCurrency.Djf)]
    [InlineData(Subscriptions::PriceCurrency.Gnf)]
    [InlineData(Subscriptions::PriceCurrency.Ugx)]
    [InlineData(Subscriptions::PriceCurrency.Pyg)]
    [InlineData(Subscriptions::PriceCurrency.Xof)]
    [InlineData(Subscriptions::PriceCurrency.Xpf)]
    public void SerializationRoundtrip_Works(Subscriptions::PriceCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::PriceCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::PriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::PriceCurrency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::PriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TierTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::Tier
        {
            FlatPrice = new()
            {
                Amount = 0,
                BillingCountryCode = "billingCountryCode",
                Currency = Subscriptions::FlatPriceCurrency.Usd,
            },
            UnitPrice = new()
            {
                Amount = 0,
                BillingCountryCode = "billingCountryCode",
                Currency = Subscriptions::UnitPriceCurrency.Usd,
            },
            UpTo = 0,
        };

        Subscriptions::FlatPrice expectedFlatPrice = new()
        {
            Amount = 0,
            BillingCountryCode = "billingCountryCode",
            Currency = Subscriptions::FlatPriceCurrency.Usd,
        };
        Subscriptions::UnitPrice expectedUnitPrice = new()
        {
            Amount = 0,
            BillingCountryCode = "billingCountryCode",
            Currency = Subscriptions::UnitPriceCurrency.Usd,
        };
        double expectedUpTo = 0;

        Assert.Equal(expectedFlatPrice, model.FlatPrice);
        Assert.Equal(expectedUnitPrice, model.UnitPrice);
        Assert.Equal(expectedUpTo, model.UpTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscriptions::Tier
        {
            FlatPrice = new()
            {
                Amount = 0,
                BillingCountryCode = "billingCountryCode",
                Currency = Subscriptions::FlatPriceCurrency.Usd,
            },
            UnitPrice = new()
            {
                Amount = 0,
                BillingCountryCode = "billingCountryCode",
                Currency = Subscriptions::UnitPriceCurrency.Usd,
            },
            UpTo = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Tier>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::Tier
        {
            FlatPrice = new()
            {
                Amount = 0,
                BillingCountryCode = "billingCountryCode",
                Currency = Subscriptions::FlatPriceCurrency.Usd,
            },
            UnitPrice = new()
            {
                Amount = 0,
                BillingCountryCode = "billingCountryCode",
                Currency = Subscriptions::UnitPriceCurrency.Usd,
            },
            UpTo = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Tier>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Subscriptions::FlatPrice expectedFlatPrice = new()
        {
            Amount = 0,
            BillingCountryCode = "billingCountryCode",
            Currency = Subscriptions::FlatPriceCurrency.Usd,
        };
        Subscriptions::UnitPrice expectedUnitPrice = new()
        {
            Amount = 0,
            BillingCountryCode = "billingCountryCode",
            Currency = Subscriptions::UnitPriceCurrency.Usd,
        };
        double expectedUpTo = 0;

        Assert.Equal(expectedFlatPrice, deserialized.FlatPrice);
        Assert.Equal(expectedUnitPrice, deserialized.UnitPrice);
        Assert.Equal(expectedUpTo, deserialized.UpTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Subscriptions::Tier
        {
            FlatPrice = new()
            {
                Amount = 0,
                BillingCountryCode = "billingCountryCode",
                Currency = Subscriptions::FlatPriceCurrency.Usd,
            },
            UnitPrice = new()
            {
                Amount = 0,
                BillingCountryCode = "billingCountryCode",
                Currency = Subscriptions::UnitPriceCurrency.Usd,
            },
            UpTo = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Subscriptions::Tier { };

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
        var model = new Subscriptions::Tier { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Subscriptions::Tier
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
        var model = new Subscriptions::Tier
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
        var model = new Subscriptions::Tier
        {
            FlatPrice = new()
            {
                Amount = 0,
                BillingCountryCode = "billingCountryCode",
                Currency = Subscriptions::FlatPriceCurrency.Usd,
            },
            UnitPrice = new()
            {
                Amount = 0,
                BillingCountryCode = "billingCountryCode",
                Currency = Subscriptions::UnitPriceCurrency.Usd,
            },
            UpTo = 0,
        };

        Subscriptions::Tier copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FlatPriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::FlatPrice
        {
            Amount = 0,
            BillingCountryCode = "billingCountryCode",
            Currency = Subscriptions::FlatPriceCurrency.Usd,
        };

        double expectedAmount = 0;
        string expectedBillingCountryCode = "billingCountryCode";
        ApiEnum<string, Subscriptions::FlatPriceCurrency> expectedCurrency =
            Subscriptions::FlatPriceCurrency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedBillingCountryCode, model.BillingCountryCode);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscriptions::FlatPrice
        {
            Amount = 0,
            BillingCountryCode = "billingCountryCode",
            Currency = Subscriptions::FlatPriceCurrency.Usd,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::FlatPrice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::FlatPrice
        {
            Amount = 0,
            BillingCountryCode = "billingCountryCode",
            Currency = Subscriptions::FlatPriceCurrency.Usd,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::FlatPrice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        string expectedBillingCountryCode = "billingCountryCode";
        ApiEnum<string, Subscriptions::FlatPriceCurrency> expectedCurrency =
            Subscriptions::FlatPriceCurrency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedBillingCountryCode, deserialized.BillingCountryCode);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Subscriptions::FlatPrice
        {
            Amount = 0,
            BillingCountryCode = "billingCountryCode",
            Currency = Subscriptions::FlatPriceCurrency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Subscriptions::FlatPrice { BillingCountryCode = "billingCountryCode" };

        Assert.Null(model.Amount);
        Assert.False(model.RawData.ContainsKey("amount"));
        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Subscriptions::FlatPrice { BillingCountryCode = "billingCountryCode" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Subscriptions::FlatPrice
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
        var model = new Subscriptions::FlatPrice
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
        var model = new Subscriptions::FlatPrice
        {
            Amount = 0,
            Currency = Subscriptions::FlatPriceCurrency.Usd,
        };

        Assert.Null(model.BillingCountryCode);
        Assert.False(model.RawData.ContainsKey("billingCountryCode"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Subscriptions::FlatPrice
        {
            Amount = 0,
            Currency = Subscriptions::FlatPriceCurrency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Subscriptions::FlatPrice
        {
            Amount = 0,
            Currency = Subscriptions::FlatPriceCurrency.Usd,

            BillingCountryCode = null,
        };

        Assert.Null(model.BillingCountryCode);
        Assert.True(model.RawData.ContainsKey("billingCountryCode"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Subscriptions::FlatPrice
        {
            Amount = 0,
            Currency = Subscriptions::FlatPriceCurrency.Usd,

            BillingCountryCode = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Subscriptions::FlatPrice
        {
            Amount = 0,
            BillingCountryCode = "billingCountryCode",
            Currency = Subscriptions::FlatPriceCurrency.Usd,
        };

        Subscriptions::FlatPrice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FlatPriceCurrencyTest : TestBase
{
    [Theory]
    [InlineData(Subscriptions::FlatPriceCurrency.Usd)]
    [InlineData(Subscriptions::FlatPriceCurrency.Aed)]
    [InlineData(Subscriptions::FlatPriceCurrency.All)]
    [InlineData(Subscriptions::FlatPriceCurrency.Amd)]
    [InlineData(Subscriptions::FlatPriceCurrency.Ang)]
    [InlineData(Subscriptions::FlatPriceCurrency.Aud)]
    [InlineData(Subscriptions::FlatPriceCurrency.Awg)]
    [InlineData(Subscriptions::FlatPriceCurrency.Azn)]
    [InlineData(Subscriptions::FlatPriceCurrency.Bam)]
    [InlineData(Subscriptions::FlatPriceCurrency.Bbd)]
    [InlineData(Subscriptions::FlatPriceCurrency.Bdt)]
    [InlineData(Subscriptions::FlatPriceCurrency.Bgn)]
    [InlineData(Subscriptions::FlatPriceCurrency.Bif)]
    [InlineData(Subscriptions::FlatPriceCurrency.Bmd)]
    [InlineData(Subscriptions::FlatPriceCurrency.Bnd)]
    [InlineData(Subscriptions::FlatPriceCurrency.Bsd)]
    [InlineData(Subscriptions::FlatPriceCurrency.Bwp)]
    [InlineData(Subscriptions::FlatPriceCurrency.Byn)]
    [InlineData(Subscriptions::FlatPriceCurrency.Bzd)]
    [InlineData(Subscriptions::FlatPriceCurrency.Brl)]
    [InlineData(Subscriptions::FlatPriceCurrency.Cad)]
    [InlineData(Subscriptions::FlatPriceCurrency.Cdf)]
    [InlineData(Subscriptions::FlatPriceCurrency.Chf)]
    [InlineData(Subscriptions::FlatPriceCurrency.Cny)]
    [InlineData(Subscriptions::FlatPriceCurrency.Czk)]
    [InlineData(Subscriptions::FlatPriceCurrency.Dkk)]
    [InlineData(Subscriptions::FlatPriceCurrency.Dop)]
    [InlineData(Subscriptions::FlatPriceCurrency.Dzd)]
    [InlineData(Subscriptions::FlatPriceCurrency.Egp)]
    [InlineData(Subscriptions::FlatPriceCurrency.Etb)]
    [InlineData(Subscriptions::FlatPriceCurrency.Eur)]
    [InlineData(Subscriptions::FlatPriceCurrency.Fjd)]
    [InlineData(Subscriptions::FlatPriceCurrency.Gbp)]
    [InlineData(Subscriptions::FlatPriceCurrency.Gel)]
    [InlineData(Subscriptions::FlatPriceCurrency.Gip)]
    [InlineData(Subscriptions::FlatPriceCurrency.Gmd)]
    [InlineData(Subscriptions::FlatPriceCurrency.Gyd)]
    [InlineData(Subscriptions::FlatPriceCurrency.Hkd)]
    [InlineData(Subscriptions::FlatPriceCurrency.Hrk)]
    [InlineData(Subscriptions::FlatPriceCurrency.Htg)]
    [InlineData(Subscriptions::FlatPriceCurrency.Idr)]
    [InlineData(Subscriptions::FlatPriceCurrency.Ils)]
    [InlineData(Subscriptions::FlatPriceCurrency.Inr)]
    [InlineData(Subscriptions::FlatPriceCurrency.Isk)]
    [InlineData(Subscriptions::FlatPriceCurrency.Jmd)]
    [InlineData(Subscriptions::FlatPriceCurrency.Jpy)]
    [InlineData(Subscriptions::FlatPriceCurrency.Kes)]
    [InlineData(Subscriptions::FlatPriceCurrency.Kgs)]
    [InlineData(Subscriptions::FlatPriceCurrency.Khr)]
    [InlineData(Subscriptions::FlatPriceCurrency.Kmf)]
    [InlineData(Subscriptions::FlatPriceCurrency.Krw)]
    [InlineData(Subscriptions::FlatPriceCurrency.Kyd)]
    [InlineData(Subscriptions::FlatPriceCurrency.Kzt)]
    [InlineData(Subscriptions::FlatPriceCurrency.Lbp)]
    [InlineData(Subscriptions::FlatPriceCurrency.Lkr)]
    [InlineData(Subscriptions::FlatPriceCurrency.Lrd)]
    [InlineData(Subscriptions::FlatPriceCurrency.Lsl)]
    [InlineData(Subscriptions::FlatPriceCurrency.Mad)]
    [InlineData(Subscriptions::FlatPriceCurrency.Mdl)]
    [InlineData(Subscriptions::FlatPriceCurrency.Mga)]
    [InlineData(Subscriptions::FlatPriceCurrency.Mkd)]
    [InlineData(Subscriptions::FlatPriceCurrency.Mmk)]
    [InlineData(Subscriptions::FlatPriceCurrency.Mnt)]
    [InlineData(Subscriptions::FlatPriceCurrency.Mop)]
    [InlineData(Subscriptions::FlatPriceCurrency.Mro)]
    [InlineData(Subscriptions::FlatPriceCurrency.Mvr)]
    [InlineData(Subscriptions::FlatPriceCurrency.Mwk)]
    [InlineData(Subscriptions::FlatPriceCurrency.Mxn)]
    [InlineData(Subscriptions::FlatPriceCurrency.Myr)]
    [InlineData(Subscriptions::FlatPriceCurrency.Mzn)]
    [InlineData(Subscriptions::FlatPriceCurrency.Nad)]
    [InlineData(Subscriptions::FlatPriceCurrency.Ngn)]
    [InlineData(Subscriptions::FlatPriceCurrency.Nok)]
    [InlineData(Subscriptions::FlatPriceCurrency.Npr)]
    [InlineData(Subscriptions::FlatPriceCurrency.Nzd)]
    [InlineData(Subscriptions::FlatPriceCurrency.Pgk)]
    [InlineData(Subscriptions::FlatPriceCurrency.Php)]
    [InlineData(Subscriptions::FlatPriceCurrency.Pkr)]
    [InlineData(Subscriptions::FlatPriceCurrency.Pln)]
    [InlineData(Subscriptions::FlatPriceCurrency.Qar)]
    [InlineData(Subscriptions::FlatPriceCurrency.Ron)]
    [InlineData(Subscriptions::FlatPriceCurrency.Rsd)]
    [InlineData(Subscriptions::FlatPriceCurrency.Rub)]
    [InlineData(Subscriptions::FlatPriceCurrency.Rwf)]
    [InlineData(Subscriptions::FlatPriceCurrency.Sar)]
    [InlineData(Subscriptions::FlatPriceCurrency.Sbd)]
    [InlineData(Subscriptions::FlatPriceCurrency.Scr)]
    [InlineData(Subscriptions::FlatPriceCurrency.Sek)]
    [InlineData(Subscriptions::FlatPriceCurrency.Sgd)]
    [InlineData(Subscriptions::FlatPriceCurrency.Sle)]
    [InlineData(Subscriptions::FlatPriceCurrency.Sll)]
    [InlineData(Subscriptions::FlatPriceCurrency.Sos)]
    [InlineData(Subscriptions::FlatPriceCurrency.Szl)]
    [InlineData(Subscriptions::FlatPriceCurrency.Thb)]
    [InlineData(Subscriptions::FlatPriceCurrency.Tjs)]
    [InlineData(Subscriptions::FlatPriceCurrency.Top)]
    [InlineData(Subscriptions::FlatPriceCurrency.Try)]
    [InlineData(Subscriptions::FlatPriceCurrency.Ttd)]
    [InlineData(Subscriptions::FlatPriceCurrency.Tzs)]
    [InlineData(Subscriptions::FlatPriceCurrency.Uah)]
    [InlineData(Subscriptions::FlatPriceCurrency.Uzs)]
    [InlineData(Subscriptions::FlatPriceCurrency.Vnd)]
    [InlineData(Subscriptions::FlatPriceCurrency.Vuv)]
    [InlineData(Subscriptions::FlatPriceCurrency.Wst)]
    [InlineData(Subscriptions::FlatPriceCurrency.Xaf)]
    [InlineData(Subscriptions::FlatPriceCurrency.Xcd)]
    [InlineData(Subscriptions::FlatPriceCurrency.Yer)]
    [InlineData(Subscriptions::FlatPriceCurrency.Zar)]
    [InlineData(Subscriptions::FlatPriceCurrency.Zmw)]
    [InlineData(Subscriptions::FlatPriceCurrency.Clp)]
    [InlineData(Subscriptions::FlatPriceCurrency.Djf)]
    [InlineData(Subscriptions::FlatPriceCurrency.Gnf)]
    [InlineData(Subscriptions::FlatPriceCurrency.Ugx)]
    [InlineData(Subscriptions::FlatPriceCurrency.Pyg)]
    [InlineData(Subscriptions::FlatPriceCurrency.Xof)]
    [InlineData(Subscriptions::FlatPriceCurrency.Xpf)]
    public void Validation_Works(Subscriptions::FlatPriceCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::FlatPriceCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::FlatPriceCurrency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Subscriptions::FlatPriceCurrency.Usd)]
    [InlineData(Subscriptions::FlatPriceCurrency.Aed)]
    [InlineData(Subscriptions::FlatPriceCurrency.All)]
    [InlineData(Subscriptions::FlatPriceCurrency.Amd)]
    [InlineData(Subscriptions::FlatPriceCurrency.Ang)]
    [InlineData(Subscriptions::FlatPriceCurrency.Aud)]
    [InlineData(Subscriptions::FlatPriceCurrency.Awg)]
    [InlineData(Subscriptions::FlatPriceCurrency.Azn)]
    [InlineData(Subscriptions::FlatPriceCurrency.Bam)]
    [InlineData(Subscriptions::FlatPriceCurrency.Bbd)]
    [InlineData(Subscriptions::FlatPriceCurrency.Bdt)]
    [InlineData(Subscriptions::FlatPriceCurrency.Bgn)]
    [InlineData(Subscriptions::FlatPriceCurrency.Bif)]
    [InlineData(Subscriptions::FlatPriceCurrency.Bmd)]
    [InlineData(Subscriptions::FlatPriceCurrency.Bnd)]
    [InlineData(Subscriptions::FlatPriceCurrency.Bsd)]
    [InlineData(Subscriptions::FlatPriceCurrency.Bwp)]
    [InlineData(Subscriptions::FlatPriceCurrency.Byn)]
    [InlineData(Subscriptions::FlatPriceCurrency.Bzd)]
    [InlineData(Subscriptions::FlatPriceCurrency.Brl)]
    [InlineData(Subscriptions::FlatPriceCurrency.Cad)]
    [InlineData(Subscriptions::FlatPriceCurrency.Cdf)]
    [InlineData(Subscriptions::FlatPriceCurrency.Chf)]
    [InlineData(Subscriptions::FlatPriceCurrency.Cny)]
    [InlineData(Subscriptions::FlatPriceCurrency.Czk)]
    [InlineData(Subscriptions::FlatPriceCurrency.Dkk)]
    [InlineData(Subscriptions::FlatPriceCurrency.Dop)]
    [InlineData(Subscriptions::FlatPriceCurrency.Dzd)]
    [InlineData(Subscriptions::FlatPriceCurrency.Egp)]
    [InlineData(Subscriptions::FlatPriceCurrency.Etb)]
    [InlineData(Subscriptions::FlatPriceCurrency.Eur)]
    [InlineData(Subscriptions::FlatPriceCurrency.Fjd)]
    [InlineData(Subscriptions::FlatPriceCurrency.Gbp)]
    [InlineData(Subscriptions::FlatPriceCurrency.Gel)]
    [InlineData(Subscriptions::FlatPriceCurrency.Gip)]
    [InlineData(Subscriptions::FlatPriceCurrency.Gmd)]
    [InlineData(Subscriptions::FlatPriceCurrency.Gyd)]
    [InlineData(Subscriptions::FlatPriceCurrency.Hkd)]
    [InlineData(Subscriptions::FlatPriceCurrency.Hrk)]
    [InlineData(Subscriptions::FlatPriceCurrency.Htg)]
    [InlineData(Subscriptions::FlatPriceCurrency.Idr)]
    [InlineData(Subscriptions::FlatPriceCurrency.Ils)]
    [InlineData(Subscriptions::FlatPriceCurrency.Inr)]
    [InlineData(Subscriptions::FlatPriceCurrency.Isk)]
    [InlineData(Subscriptions::FlatPriceCurrency.Jmd)]
    [InlineData(Subscriptions::FlatPriceCurrency.Jpy)]
    [InlineData(Subscriptions::FlatPriceCurrency.Kes)]
    [InlineData(Subscriptions::FlatPriceCurrency.Kgs)]
    [InlineData(Subscriptions::FlatPriceCurrency.Khr)]
    [InlineData(Subscriptions::FlatPriceCurrency.Kmf)]
    [InlineData(Subscriptions::FlatPriceCurrency.Krw)]
    [InlineData(Subscriptions::FlatPriceCurrency.Kyd)]
    [InlineData(Subscriptions::FlatPriceCurrency.Kzt)]
    [InlineData(Subscriptions::FlatPriceCurrency.Lbp)]
    [InlineData(Subscriptions::FlatPriceCurrency.Lkr)]
    [InlineData(Subscriptions::FlatPriceCurrency.Lrd)]
    [InlineData(Subscriptions::FlatPriceCurrency.Lsl)]
    [InlineData(Subscriptions::FlatPriceCurrency.Mad)]
    [InlineData(Subscriptions::FlatPriceCurrency.Mdl)]
    [InlineData(Subscriptions::FlatPriceCurrency.Mga)]
    [InlineData(Subscriptions::FlatPriceCurrency.Mkd)]
    [InlineData(Subscriptions::FlatPriceCurrency.Mmk)]
    [InlineData(Subscriptions::FlatPriceCurrency.Mnt)]
    [InlineData(Subscriptions::FlatPriceCurrency.Mop)]
    [InlineData(Subscriptions::FlatPriceCurrency.Mro)]
    [InlineData(Subscriptions::FlatPriceCurrency.Mvr)]
    [InlineData(Subscriptions::FlatPriceCurrency.Mwk)]
    [InlineData(Subscriptions::FlatPriceCurrency.Mxn)]
    [InlineData(Subscriptions::FlatPriceCurrency.Myr)]
    [InlineData(Subscriptions::FlatPriceCurrency.Mzn)]
    [InlineData(Subscriptions::FlatPriceCurrency.Nad)]
    [InlineData(Subscriptions::FlatPriceCurrency.Ngn)]
    [InlineData(Subscriptions::FlatPriceCurrency.Nok)]
    [InlineData(Subscriptions::FlatPriceCurrency.Npr)]
    [InlineData(Subscriptions::FlatPriceCurrency.Nzd)]
    [InlineData(Subscriptions::FlatPriceCurrency.Pgk)]
    [InlineData(Subscriptions::FlatPriceCurrency.Php)]
    [InlineData(Subscriptions::FlatPriceCurrency.Pkr)]
    [InlineData(Subscriptions::FlatPriceCurrency.Pln)]
    [InlineData(Subscriptions::FlatPriceCurrency.Qar)]
    [InlineData(Subscriptions::FlatPriceCurrency.Ron)]
    [InlineData(Subscriptions::FlatPriceCurrency.Rsd)]
    [InlineData(Subscriptions::FlatPriceCurrency.Rub)]
    [InlineData(Subscriptions::FlatPriceCurrency.Rwf)]
    [InlineData(Subscriptions::FlatPriceCurrency.Sar)]
    [InlineData(Subscriptions::FlatPriceCurrency.Sbd)]
    [InlineData(Subscriptions::FlatPriceCurrency.Scr)]
    [InlineData(Subscriptions::FlatPriceCurrency.Sek)]
    [InlineData(Subscriptions::FlatPriceCurrency.Sgd)]
    [InlineData(Subscriptions::FlatPriceCurrency.Sle)]
    [InlineData(Subscriptions::FlatPriceCurrency.Sll)]
    [InlineData(Subscriptions::FlatPriceCurrency.Sos)]
    [InlineData(Subscriptions::FlatPriceCurrency.Szl)]
    [InlineData(Subscriptions::FlatPriceCurrency.Thb)]
    [InlineData(Subscriptions::FlatPriceCurrency.Tjs)]
    [InlineData(Subscriptions::FlatPriceCurrency.Top)]
    [InlineData(Subscriptions::FlatPriceCurrency.Try)]
    [InlineData(Subscriptions::FlatPriceCurrency.Ttd)]
    [InlineData(Subscriptions::FlatPriceCurrency.Tzs)]
    [InlineData(Subscriptions::FlatPriceCurrency.Uah)]
    [InlineData(Subscriptions::FlatPriceCurrency.Uzs)]
    [InlineData(Subscriptions::FlatPriceCurrency.Vnd)]
    [InlineData(Subscriptions::FlatPriceCurrency.Vuv)]
    [InlineData(Subscriptions::FlatPriceCurrency.Wst)]
    [InlineData(Subscriptions::FlatPriceCurrency.Xaf)]
    [InlineData(Subscriptions::FlatPriceCurrency.Xcd)]
    [InlineData(Subscriptions::FlatPriceCurrency.Yer)]
    [InlineData(Subscriptions::FlatPriceCurrency.Zar)]
    [InlineData(Subscriptions::FlatPriceCurrency.Zmw)]
    [InlineData(Subscriptions::FlatPriceCurrency.Clp)]
    [InlineData(Subscriptions::FlatPriceCurrency.Djf)]
    [InlineData(Subscriptions::FlatPriceCurrency.Gnf)]
    [InlineData(Subscriptions::FlatPriceCurrency.Ugx)]
    [InlineData(Subscriptions::FlatPriceCurrency.Pyg)]
    [InlineData(Subscriptions::FlatPriceCurrency.Xof)]
    [InlineData(Subscriptions::FlatPriceCurrency.Xpf)]
    public void SerializationRoundtrip_Works(Subscriptions::FlatPriceCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::FlatPriceCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::FlatPriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::FlatPriceCurrency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::FlatPriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class UnitPriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::UnitPrice
        {
            Amount = 0,
            BillingCountryCode = "billingCountryCode",
            Currency = Subscriptions::UnitPriceCurrency.Usd,
        };

        double expectedAmount = 0;
        string expectedBillingCountryCode = "billingCountryCode";
        ApiEnum<string, Subscriptions::UnitPriceCurrency> expectedCurrency =
            Subscriptions::UnitPriceCurrency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedBillingCountryCode, model.BillingCountryCode);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscriptions::UnitPrice
        {
            Amount = 0,
            BillingCountryCode = "billingCountryCode",
            Currency = Subscriptions::UnitPriceCurrency.Usd,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::UnitPrice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::UnitPrice
        {
            Amount = 0,
            BillingCountryCode = "billingCountryCode",
            Currency = Subscriptions::UnitPriceCurrency.Usd,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::UnitPrice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        string expectedBillingCountryCode = "billingCountryCode";
        ApiEnum<string, Subscriptions::UnitPriceCurrency> expectedCurrency =
            Subscriptions::UnitPriceCurrency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedBillingCountryCode, deserialized.BillingCountryCode);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Subscriptions::UnitPrice
        {
            Amount = 0,
            BillingCountryCode = "billingCountryCode",
            Currency = Subscriptions::UnitPriceCurrency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Subscriptions::UnitPrice { BillingCountryCode = "billingCountryCode" };

        Assert.Null(model.Amount);
        Assert.False(model.RawData.ContainsKey("amount"));
        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Subscriptions::UnitPrice { BillingCountryCode = "billingCountryCode" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Subscriptions::UnitPrice
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
        var model = new Subscriptions::UnitPrice
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
        var model = new Subscriptions::UnitPrice
        {
            Amount = 0,
            Currency = Subscriptions::UnitPriceCurrency.Usd,
        };

        Assert.Null(model.BillingCountryCode);
        Assert.False(model.RawData.ContainsKey("billingCountryCode"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Subscriptions::UnitPrice
        {
            Amount = 0,
            Currency = Subscriptions::UnitPriceCurrency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Subscriptions::UnitPrice
        {
            Amount = 0,
            Currency = Subscriptions::UnitPriceCurrency.Usd,

            BillingCountryCode = null,
        };

        Assert.Null(model.BillingCountryCode);
        Assert.True(model.RawData.ContainsKey("billingCountryCode"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Subscriptions::UnitPrice
        {
            Amount = 0,
            Currency = Subscriptions::UnitPriceCurrency.Usd,

            BillingCountryCode = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Subscriptions::UnitPrice
        {
            Amount = 0,
            BillingCountryCode = "billingCountryCode",
            Currency = Subscriptions::UnitPriceCurrency.Usd,
        };

        Subscriptions::UnitPrice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UnitPriceCurrencyTest : TestBase
{
    [Theory]
    [InlineData(Subscriptions::UnitPriceCurrency.Usd)]
    [InlineData(Subscriptions::UnitPriceCurrency.Aed)]
    [InlineData(Subscriptions::UnitPriceCurrency.All)]
    [InlineData(Subscriptions::UnitPriceCurrency.Amd)]
    [InlineData(Subscriptions::UnitPriceCurrency.Ang)]
    [InlineData(Subscriptions::UnitPriceCurrency.Aud)]
    [InlineData(Subscriptions::UnitPriceCurrency.Awg)]
    [InlineData(Subscriptions::UnitPriceCurrency.Azn)]
    [InlineData(Subscriptions::UnitPriceCurrency.Bam)]
    [InlineData(Subscriptions::UnitPriceCurrency.Bbd)]
    [InlineData(Subscriptions::UnitPriceCurrency.Bdt)]
    [InlineData(Subscriptions::UnitPriceCurrency.Bgn)]
    [InlineData(Subscriptions::UnitPriceCurrency.Bif)]
    [InlineData(Subscriptions::UnitPriceCurrency.Bmd)]
    [InlineData(Subscriptions::UnitPriceCurrency.Bnd)]
    [InlineData(Subscriptions::UnitPriceCurrency.Bsd)]
    [InlineData(Subscriptions::UnitPriceCurrency.Bwp)]
    [InlineData(Subscriptions::UnitPriceCurrency.Byn)]
    [InlineData(Subscriptions::UnitPriceCurrency.Bzd)]
    [InlineData(Subscriptions::UnitPriceCurrency.Brl)]
    [InlineData(Subscriptions::UnitPriceCurrency.Cad)]
    [InlineData(Subscriptions::UnitPriceCurrency.Cdf)]
    [InlineData(Subscriptions::UnitPriceCurrency.Chf)]
    [InlineData(Subscriptions::UnitPriceCurrency.Cny)]
    [InlineData(Subscriptions::UnitPriceCurrency.Czk)]
    [InlineData(Subscriptions::UnitPriceCurrency.Dkk)]
    [InlineData(Subscriptions::UnitPriceCurrency.Dop)]
    [InlineData(Subscriptions::UnitPriceCurrency.Dzd)]
    [InlineData(Subscriptions::UnitPriceCurrency.Egp)]
    [InlineData(Subscriptions::UnitPriceCurrency.Etb)]
    [InlineData(Subscriptions::UnitPriceCurrency.Eur)]
    [InlineData(Subscriptions::UnitPriceCurrency.Fjd)]
    [InlineData(Subscriptions::UnitPriceCurrency.Gbp)]
    [InlineData(Subscriptions::UnitPriceCurrency.Gel)]
    [InlineData(Subscriptions::UnitPriceCurrency.Gip)]
    [InlineData(Subscriptions::UnitPriceCurrency.Gmd)]
    [InlineData(Subscriptions::UnitPriceCurrency.Gyd)]
    [InlineData(Subscriptions::UnitPriceCurrency.Hkd)]
    [InlineData(Subscriptions::UnitPriceCurrency.Hrk)]
    [InlineData(Subscriptions::UnitPriceCurrency.Htg)]
    [InlineData(Subscriptions::UnitPriceCurrency.Idr)]
    [InlineData(Subscriptions::UnitPriceCurrency.Ils)]
    [InlineData(Subscriptions::UnitPriceCurrency.Inr)]
    [InlineData(Subscriptions::UnitPriceCurrency.Isk)]
    [InlineData(Subscriptions::UnitPriceCurrency.Jmd)]
    [InlineData(Subscriptions::UnitPriceCurrency.Jpy)]
    [InlineData(Subscriptions::UnitPriceCurrency.Kes)]
    [InlineData(Subscriptions::UnitPriceCurrency.Kgs)]
    [InlineData(Subscriptions::UnitPriceCurrency.Khr)]
    [InlineData(Subscriptions::UnitPriceCurrency.Kmf)]
    [InlineData(Subscriptions::UnitPriceCurrency.Krw)]
    [InlineData(Subscriptions::UnitPriceCurrency.Kyd)]
    [InlineData(Subscriptions::UnitPriceCurrency.Kzt)]
    [InlineData(Subscriptions::UnitPriceCurrency.Lbp)]
    [InlineData(Subscriptions::UnitPriceCurrency.Lkr)]
    [InlineData(Subscriptions::UnitPriceCurrency.Lrd)]
    [InlineData(Subscriptions::UnitPriceCurrency.Lsl)]
    [InlineData(Subscriptions::UnitPriceCurrency.Mad)]
    [InlineData(Subscriptions::UnitPriceCurrency.Mdl)]
    [InlineData(Subscriptions::UnitPriceCurrency.Mga)]
    [InlineData(Subscriptions::UnitPriceCurrency.Mkd)]
    [InlineData(Subscriptions::UnitPriceCurrency.Mmk)]
    [InlineData(Subscriptions::UnitPriceCurrency.Mnt)]
    [InlineData(Subscriptions::UnitPriceCurrency.Mop)]
    [InlineData(Subscriptions::UnitPriceCurrency.Mro)]
    [InlineData(Subscriptions::UnitPriceCurrency.Mvr)]
    [InlineData(Subscriptions::UnitPriceCurrency.Mwk)]
    [InlineData(Subscriptions::UnitPriceCurrency.Mxn)]
    [InlineData(Subscriptions::UnitPriceCurrency.Myr)]
    [InlineData(Subscriptions::UnitPriceCurrency.Mzn)]
    [InlineData(Subscriptions::UnitPriceCurrency.Nad)]
    [InlineData(Subscriptions::UnitPriceCurrency.Ngn)]
    [InlineData(Subscriptions::UnitPriceCurrency.Nok)]
    [InlineData(Subscriptions::UnitPriceCurrency.Npr)]
    [InlineData(Subscriptions::UnitPriceCurrency.Nzd)]
    [InlineData(Subscriptions::UnitPriceCurrency.Pgk)]
    [InlineData(Subscriptions::UnitPriceCurrency.Php)]
    [InlineData(Subscriptions::UnitPriceCurrency.Pkr)]
    [InlineData(Subscriptions::UnitPriceCurrency.Pln)]
    [InlineData(Subscriptions::UnitPriceCurrency.Qar)]
    [InlineData(Subscriptions::UnitPriceCurrency.Ron)]
    [InlineData(Subscriptions::UnitPriceCurrency.Rsd)]
    [InlineData(Subscriptions::UnitPriceCurrency.Rub)]
    [InlineData(Subscriptions::UnitPriceCurrency.Rwf)]
    [InlineData(Subscriptions::UnitPriceCurrency.Sar)]
    [InlineData(Subscriptions::UnitPriceCurrency.Sbd)]
    [InlineData(Subscriptions::UnitPriceCurrency.Scr)]
    [InlineData(Subscriptions::UnitPriceCurrency.Sek)]
    [InlineData(Subscriptions::UnitPriceCurrency.Sgd)]
    [InlineData(Subscriptions::UnitPriceCurrency.Sle)]
    [InlineData(Subscriptions::UnitPriceCurrency.Sll)]
    [InlineData(Subscriptions::UnitPriceCurrency.Sos)]
    [InlineData(Subscriptions::UnitPriceCurrency.Szl)]
    [InlineData(Subscriptions::UnitPriceCurrency.Thb)]
    [InlineData(Subscriptions::UnitPriceCurrency.Tjs)]
    [InlineData(Subscriptions::UnitPriceCurrency.Top)]
    [InlineData(Subscriptions::UnitPriceCurrency.Try)]
    [InlineData(Subscriptions::UnitPriceCurrency.Ttd)]
    [InlineData(Subscriptions::UnitPriceCurrency.Tzs)]
    [InlineData(Subscriptions::UnitPriceCurrency.Uah)]
    [InlineData(Subscriptions::UnitPriceCurrency.Uzs)]
    [InlineData(Subscriptions::UnitPriceCurrency.Vnd)]
    [InlineData(Subscriptions::UnitPriceCurrency.Vuv)]
    [InlineData(Subscriptions::UnitPriceCurrency.Wst)]
    [InlineData(Subscriptions::UnitPriceCurrency.Xaf)]
    [InlineData(Subscriptions::UnitPriceCurrency.Xcd)]
    [InlineData(Subscriptions::UnitPriceCurrency.Yer)]
    [InlineData(Subscriptions::UnitPriceCurrency.Zar)]
    [InlineData(Subscriptions::UnitPriceCurrency.Zmw)]
    [InlineData(Subscriptions::UnitPriceCurrency.Clp)]
    [InlineData(Subscriptions::UnitPriceCurrency.Djf)]
    [InlineData(Subscriptions::UnitPriceCurrency.Gnf)]
    [InlineData(Subscriptions::UnitPriceCurrency.Ugx)]
    [InlineData(Subscriptions::UnitPriceCurrency.Pyg)]
    [InlineData(Subscriptions::UnitPriceCurrency.Xof)]
    [InlineData(Subscriptions::UnitPriceCurrency.Xpf)]
    public void Validation_Works(Subscriptions::UnitPriceCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::UnitPriceCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::UnitPriceCurrency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Subscriptions::UnitPriceCurrency.Usd)]
    [InlineData(Subscriptions::UnitPriceCurrency.Aed)]
    [InlineData(Subscriptions::UnitPriceCurrency.All)]
    [InlineData(Subscriptions::UnitPriceCurrency.Amd)]
    [InlineData(Subscriptions::UnitPriceCurrency.Ang)]
    [InlineData(Subscriptions::UnitPriceCurrency.Aud)]
    [InlineData(Subscriptions::UnitPriceCurrency.Awg)]
    [InlineData(Subscriptions::UnitPriceCurrency.Azn)]
    [InlineData(Subscriptions::UnitPriceCurrency.Bam)]
    [InlineData(Subscriptions::UnitPriceCurrency.Bbd)]
    [InlineData(Subscriptions::UnitPriceCurrency.Bdt)]
    [InlineData(Subscriptions::UnitPriceCurrency.Bgn)]
    [InlineData(Subscriptions::UnitPriceCurrency.Bif)]
    [InlineData(Subscriptions::UnitPriceCurrency.Bmd)]
    [InlineData(Subscriptions::UnitPriceCurrency.Bnd)]
    [InlineData(Subscriptions::UnitPriceCurrency.Bsd)]
    [InlineData(Subscriptions::UnitPriceCurrency.Bwp)]
    [InlineData(Subscriptions::UnitPriceCurrency.Byn)]
    [InlineData(Subscriptions::UnitPriceCurrency.Bzd)]
    [InlineData(Subscriptions::UnitPriceCurrency.Brl)]
    [InlineData(Subscriptions::UnitPriceCurrency.Cad)]
    [InlineData(Subscriptions::UnitPriceCurrency.Cdf)]
    [InlineData(Subscriptions::UnitPriceCurrency.Chf)]
    [InlineData(Subscriptions::UnitPriceCurrency.Cny)]
    [InlineData(Subscriptions::UnitPriceCurrency.Czk)]
    [InlineData(Subscriptions::UnitPriceCurrency.Dkk)]
    [InlineData(Subscriptions::UnitPriceCurrency.Dop)]
    [InlineData(Subscriptions::UnitPriceCurrency.Dzd)]
    [InlineData(Subscriptions::UnitPriceCurrency.Egp)]
    [InlineData(Subscriptions::UnitPriceCurrency.Etb)]
    [InlineData(Subscriptions::UnitPriceCurrency.Eur)]
    [InlineData(Subscriptions::UnitPriceCurrency.Fjd)]
    [InlineData(Subscriptions::UnitPriceCurrency.Gbp)]
    [InlineData(Subscriptions::UnitPriceCurrency.Gel)]
    [InlineData(Subscriptions::UnitPriceCurrency.Gip)]
    [InlineData(Subscriptions::UnitPriceCurrency.Gmd)]
    [InlineData(Subscriptions::UnitPriceCurrency.Gyd)]
    [InlineData(Subscriptions::UnitPriceCurrency.Hkd)]
    [InlineData(Subscriptions::UnitPriceCurrency.Hrk)]
    [InlineData(Subscriptions::UnitPriceCurrency.Htg)]
    [InlineData(Subscriptions::UnitPriceCurrency.Idr)]
    [InlineData(Subscriptions::UnitPriceCurrency.Ils)]
    [InlineData(Subscriptions::UnitPriceCurrency.Inr)]
    [InlineData(Subscriptions::UnitPriceCurrency.Isk)]
    [InlineData(Subscriptions::UnitPriceCurrency.Jmd)]
    [InlineData(Subscriptions::UnitPriceCurrency.Jpy)]
    [InlineData(Subscriptions::UnitPriceCurrency.Kes)]
    [InlineData(Subscriptions::UnitPriceCurrency.Kgs)]
    [InlineData(Subscriptions::UnitPriceCurrency.Khr)]
    [InlineData(Subscriptions::UnitPriceCurrency.Kmf)]
    [InlineData(Subscriptions::UnitPriceCurrency.Krw)]
    [InlineData(Subscriptions::UnitPriceCurrency.Kyd)]
    [InlineData(Subscriptions::UnitPriceCurrency.Kzt)]
    [InlineData(Subscriptions::UnitPriceCurrency.Lbp)]
    [InlineData(Subscriptions::UnitPriceCurrency.Lkr)]
    [InlineData(Subscriptions::UnitPriceCurrency.Lrd)]
    [InlineData(Subscriptions::UnitPriceCurrency.Lsl)]
    [InlineData(Subscriptions::UnitPriceCurrency.Mad)]
    [InlineData(Subscriptions::UnitPriceCurrency.Mdl)]
    [InlineData(Subscriptions::UnitPriceCurrency.Mga)]
    [InlineData(Subscriptions::UnitPriceCurrency.Mkd)]
    [InlineData(Subscriptions::UnitPriceCurrency.Mmk)]
    [InlineData(Subscriptions::UnitPriceCurrency.Mnt)]
    [InlineData(Subscriptions::UnitPriceCurrency.Mop)]
    [InlineData(Subscriptions::UnitPriceCurrency.Mro)]
    [InlineData(Subscriptions::UnitPriceCurrency.Mvr)]
    [InlineData(Subscriptions::UnitPriceCurrency.Mwk)]
    [InlineData(Subscriptions::UnitPriceCurrency.Mxn)]
    [InlineData(Subscriptions::UnitPriceCurrency.Myr)]
    [InlineData(Subscriptions::UnitPriceCurrency.Mzn)]
    [InlineData(Subscriptions::UnitPriceCurrency.Nad)]
    [InlineData(Subscriptions::UnitPriceCurrency.Ngn)]
    [InlineData(Subscriptions::UnitPriceCurrency.Nok)]
    [InlineData(Subscriptions::UnitPriceCurrency.Npr)]
    [InlineData(Subscriptions::UnitPriceCurrency.Nzd)]
    [InlineData(Subscriptions::UnitPriceCurrency.Pgk)]
    [InlineData(Subscriptions::UnitPriceCurrency.Php)]
    [InlineData(Subscriptions::UnitPriceCurrency.Pkr)]
    [InlineData(Subscriptions::UnitPriceCurrency.Pln)]
    [InlineData(Subscriptions::UnitPriceCurrency.Qar)]
    [InlineData(Subscriptions::UnitPriceCurrency.Ron)]
    [InlineData(Subscriptions::UnitPriceCurrency.Rsd)]
    [InlineData(Subscriptions::UnitPriceCurrency.Rub)]
    [InlineData(Subscriptions::UnitPriceCurrency.Rwf)]
    [InlineData(Subscriptions::UnitPriceCurrency.Sar)]
    [InlineData(Subscriptions::UnitPriceCurrency.Sbd)]
    [InlineData(Subscriptions::UnitPriceCurrency.Scr)]
    [InlineData(Subscriptions::UnitPriceCurrency.Sek)]
    [InlineData(Subscriptions::UnitPriceCurrency.Sgd)]
    [InlineData(Subscriptions::UnitPriceCurrency.Sle)]
    [InlineData(Subscriptions::UnitPriceCurrency.Sll)]
    [InlineData(Subscriptions::UnitPriceCurrency.Sos)]
    [InlineData(Subscriptions::UnitPriceCurrency.Szl)]
    [InlineData(Subscriptions::UnitPriceCurrency.Thb)]
    [InlineData(Subscriptions::UnitPriceCurrency.Tjs)]
    [InlineData(Subscriptions::UnitPriceCurrency.Top)]
    [InlineData(Subscriptions::UnitPriceCurrency.Try)]
    [InlineData(Subscriptions::UnitPriceCurrency.Ttd)]
    [InlineData(Subscriptions::UnitPriceCurrency.Tzs)]
    [InlineData(Subscriptions::UnitPriceCurrency.Uah)]
    [InlineData(Subscriptions::UnitPriceCurrency.Uzs)]
    [InlineData(Subscriptions::UnitPriceCurrency.Vnd)]
    [InlineData(Subscriptions::UnitPriceCurrency.Vuv)]
    [InlineData(Subscriptions::UnitPriceCurrency.Wst)]
    [InlineData(Subscriptions::UnitPriceCurrency.Xaf)]
    [InlineData(Subscriptions::UnitPriceCurrency.Xcd)]
    [InlineData(Subscriptions::UnitPriceCurrency.Yer)]
    [InlineData(Subscriptions::UnitPriceCurrency.Zar)]
    [InlineData(Subscriptions::UnitPriceCurrency.Zmw)]
    [InlineData(Subscriptions::UnitPriceCurrency.Clp)]
    [InlineData(Subscriptions::UnitPriceCurrency.Djf)]
    [InlineData(Subscriptions::UnitPriceCurrency.Gnf)]
    [InlineData(Subscriptions::UnitPriceCurrency.Ugx)]
    [InlineData(Subscriptions::UnitPriceCurrency.Pyg)]
    [InlineData(Subscriptions::UnitPriceCurrency.Xof)]
    [InlineData(Subscriptions::UnitPriceCurrency.Xpf)]
    public void SerializationRoundtrip_Works(Subscriptions::UnitPriceCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::UnitPriceCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::UnitPriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::UnitPriceCurrency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::UnitPriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ScheduleStrategyTest : TestBase
{
    [Theory]
    [InlineData(Subscriptions::ScheduleStrategy.EndOfBillingPeriod)]
    [InlineData(Subscriptions::ScheduleStrategy.EndOfBillingMonth)]
    [InlineData(Subscriptions::ScheduleStrategy.Immediate)]
    public void Validation_Works(Subscriptions::ScheduleStrategy rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::ScheduleStrategy> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::ScheduleStrategy>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Subscriptions::ScheduleStrategy.EndOfBillingPeriod)]
    [InlineData(Subscriptions::ScheduleStrategy.EndOfBillingMonth)]
    [InlineData(Subscriptions::ScheduleStrategy.Immediate)]
    public void SerializationRoundtrip_Works(Subscriptions::ScheduleStrategy rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::ScheduleStrategy> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::ScheduleStrategy>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::ScheduleStrategy>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::ScheduleStrategy>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionEntitlementTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::SubscriptionEntitlement
        {
            FeatureID = "featureId",
            UsageLimit = 0,
            IsGranted = true,
        };

        string expectedFeatureID = "featureId";
        double expectedUsageLimit = 0;
        bool expectedIsGranted = true;

        Assert.Equal(expectedFeatureID, model.FeatureID);
        Assert.Equal(expectedUsageLimit, model.UsageLimit);
        Assert.Equal(expectedIsGranted, model.IsGranted);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscriptions::SubscriptionEntitlement
        {
            FeatureID = "featureId",
            UsageLimit = 0,
            IsGranted = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::SubscriptionEntitlement>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::SubscriptionEntitlement
        {
            FeatureID = "featureId",
            UsageLimit = 0,
            IsGranted = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::SubscriptionEntitlement>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedFeatureID = "featureId";
        double expectedUsageLimit = 0;
        bool expectedIsGranted = true;

        Assert.Equal(expectedFeatureID, deserialized.FeatureID);
        Assert.Equal(expectedUsageLimit, deserialized.UsageLimit);
        Assert.Equal(expectedIsGranted, deserialized.IsGranted);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Subscriptions::SubscriptionEntitlement
        {
            FeatureID = "featureId",
            UsageLimit = 0,
            IsGranted = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Subscriptions::SubscriptionEntitlement
        {
            FeatureID = "featureId",
            UsageLimit = 0,
        };

        Assert.Null(model.IsGranted);
        Assert.False(model.RawData.ContainsKey("isGranted"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Subscriptions::SubscriptionEntitlement
        {
            FeatureID = "featureId",
            UsageLimit = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Subscriptions::SubscriptionEntitlement
        {
            FeatureID = "featureId",
            UsageLimit = 0,

            // Null should be interpreted as omitted for these properties
            IsGranted = null,
        };

        Assert.Null(model.IsGranted);
        Assert.False(model.RawData.ContainsKey("isGranted"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Subscriptions::SubscriptionEntitlement
        {
            FeatureID = "featureId",
            UsageLimit = 0,

            // Null should be interpreted as omitted for these properties
            IsGranted = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Subscriptions::SubscriptionEntitlement
        {
            FeatureID = "featureId",
            UsageLimit = 0,
            IsGranted = true,
        };

        Subscriptions::SubscriptionEntitlement copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TrialOverrideConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::TrialOverrideConfiguration
        {
            IsTrial = true,
            TrialEndBehavior = Subscriptions::TrialEndBehavior.ConvertToPaid,
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        bool expectedIsTrial = true;
        ApiEnum<string, Subscriptions::TrialEndBehavior> expectedTrialEndBehavior =
            Subscriptions::TrialEndBehavior.ConvertToPaid;
        DateTimeOffset expectedTrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedIsTrial, model.IsTrial);
        Assert.Equal(expectedTrialEndBehavior, model.TrialEndBehavior);
        Assert.Equal(expectedTrialEndDate, model.TrialEndDate);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscriptions::TrialOverrideConfiguration
        {
            IsTrial = true,
            TrialEndBehavior = Subscriptions::TrialEndBehavior.ConvertToPaid,
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::TrialOverrideConfiguration>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::TrialOverrideConfiguration
        {
            IsTrial = true,
            TrialEndBehavior = Subscriptions::TrialEndBehavior.ConvertToPaid,
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::TrialOverrideConfiguration>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedIsTrial = true;
        ApiEnum<string, Subscriptions::TrialEndBehavior> expectedTrialEndBehavior =
            Subscriptions::TrialEndBehavior.ConvertToPaid;
        DateTimeOffset expectedTrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedIsTrial, deserialized.IsTrial);
        Assert.Equal(expectedTrialEndBehavior, deserialized.TrialEndBehavior);
        Assert.Equal(expectedTrialEndDate, deserialized.TrialEndDate);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Subscriptions::TrialOverrideConfiguration
        {
            IsTrial = true,
            TrialEndBehavior = Subscriptions::TrialEndBehavior.ConvertToPaid,
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Subscriptions::TrialOverrideConfiguration { IsTrial = true };

        Assert.Null(model.TrialEndBehavior);
        Assert.False(model.RawData.ContainsKey("trialEndBehavior"));
        Assert.Null(model.TrialEndDate);
        Assert.False(model.RawData.ContainsKey("trialEndDate"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Subscriptions::TrialOverrideConfiguration { IsTrial = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Subscriptions::TrialOverrideConfiguration
        {
            IsTrial = true,

            // Null should be interpreted as omitted for these properties
            TrialEndBehavior = null,
            TrialEndDate = null,
        };

        Assert.Null(model.TrialEndBehavior);
        Assert.False(model.RawData.ContainsKey("trialEndBehavior"));
        Assert.Null(model.TrialEndDate);
        Assert.False(model.RawData.ContainsKey("trialEndDate"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Subscriptions::TrialOverrideConfiguration
        {
            IsTrial = true,

            // Null should be interpreted as omitted for these properties
            TrialEndBehavior = null,
            TrialEndDate = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Subscriptions::TrialOverrideConfiguration
        {
            IsTrial = true,
            TrialEndBehavior = Subscriptions::TrialEndBehavior.ConvertToPaid,
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Subscriptions::TrialOverrideConfiguration copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TrialEndBehaviorTest : TestBase
{
    [Theory]
    [InlineData(Subscriptions::TrialEndBehavior.ConvertToPaid)]
    [InlineData(Subscriptions::TrialEndBehavior.CancelSubscription)]
    public void Validation_Works(Subscriptions::TrialEndBehavior rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::TrialEndBehavior> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::TrialEndBehavior>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Subscriptions::TrialEndBehavior.ConvertToPaid)]
    [InlineData(Subscriptions::TrialEndBehavior.CancelSubscription)]
    public void SerializationRoundtrip_Works(Subscriptions::TrialEndBehavior rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::TrialEndBehavior> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::TrialEndBehavior>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::TrialEndBehavior>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::TrialEndBehavior>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
