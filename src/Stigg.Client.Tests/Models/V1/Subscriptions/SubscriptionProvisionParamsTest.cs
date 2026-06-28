using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Subscriptions;

namespace Stigg.Client.Tests.Models.V1.Subscriptions;

public class SubscriptionProvisionParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SubscriptionProvisionParams
        {
            CustomerID = "customerId",
            PlanID = "planId",
            ID = "id",
            Addons = [new() { ID = "id", Quantity = 0 }],
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
                    AmountsOff =
                    [
                        new()
                        {
                            Amount = 0,
                            Currency =
                                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Usd,
                        },
                    ],
                    Description = "description",
                    DurationInMonths = 1,
                    Name = "name",
                    PercentOff = 1,
                },
                PromotionCode = "promotionCode",
            },
            AwaitPaymentConfirmation = true,
            BillingCountryCode = "billingCountryCode",
            BillingCycleAnchor = SubscriptionProvisionParamsBillingCycleAnchor.Unchanged,
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
                ProrationBehavior =
                    SubscriptionProvisionParamsBillingInformationProrationBehavior.InvoiceImmediately,
                TaxIds = [new() { Type = "type", Value = "value" }],
                TaxPercentage = 0,
                TaxRateIds = ["string"],
            },
            BillingPeriod = SubscriptionProvisionParamsBillingPeriod.Monthly,
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Charges =
            [
                new()
                {
                    ID = "id",
                    Quantity = 0,
                    Type = SubscriptionProvisionParamsChargeType.Feature,
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
            Entitlements =
            [
                new SubscriptionProvisionParamsEntitlementFeature()
                {
                    ID = "id",
                    HasSoftLimit = true,
                    HasUnlimitedUsage = true,
                    MonthlyResetPeriodConfiguration = new(
                        SubscriptionProvisionParamsEntitlementFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    ResetPeriod = SubscriptionProvisionParamsEntitlementFeatureResetPeriod.Year,
                    UsageLimit = 0,
                    WeeklyResetPeriodConfiguration = new(
                        SubscriptionProvisionParamsEntitlementFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    YearlyResetPeriodConfiguration = new(
                        SubscriptionProvisionParamsEntitlementFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MinimumSpend = new()
            {
                Amount = 0,
                Currency = SubscriptionProvisionParamsMinimumSpendCurrency.Usd,
            },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod = PaymentCollectionMethod.Charge,
            PriceOverrides =
            [
                new()
                {
                    AddonID = "addonId",
                    Amount = 0,
                    BaseCharge = true,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    CreditGrantCadence = CreditGrantCadence.BeginningOfBillingPeriod,
                    CreditRate = new()
                    {
                        Amount = 1,
                        CurrencyID = "currencyId",
                        CostFormula = "costFormula",
                    },
                    Currency = SubscriptionProvisionParamsPriceOverrideCurrency.Usd,
                    FeatureID = "featureId",
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new() { Amount = 0, Currency = FlatPriceCurrency.Usd },
                            UnitPrice = new() { Amount = 0, Currency = UnitPriceCurrency.Usd },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            ResourceID = "resourceId",
            SalesforceID = "salesforceId",
            ScheduleStrategy = SubscriptionProvisionParamsScheduleStrategy.EndOfBillingPeriod,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TrialOverrideConfiguration = new()
            {
                IsTrial = true,
                TrialEndBehavior =
                    SubscriptionProvisionParamsTrialOverrideConfigurationTrialEndBehavior.ConvertToPaid,
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            UnitQuantity = 0,
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        string expectedCustomerID = "customerId";
        string expectedPlanID = "planId";
        string expectedID = "id";
        List<SubscriptionProvisionParamsAddon> expectedAddons = [new() { ID = "id", Quantity = 0 }];
        SubscriptionProvisionParamsAppliedCoupon expectedAppliedCoupon = new()
        {
            BillingCouponID = "billingCouponId",
            Configuration = new() { StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z") },
            CouponID = "couponId",
            Discount = new()
            {
                AmountsOff =
                [
                    new()
                    {
                        Amount = 0,
                        Currency =
                            SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Usd,
                    },
                ],
                Description = "description",
                DurationInMonths = 1,
                Name = "name",
                PercentOff = 1,
            },
            PromotionCode = "promotionCode",
        };
        bool expectedAwaitPaymentConfirmation = true;
        string expectedBillingCountryCode = "billingCountryCode";
        ApiEnum<string, SubscriptionProvisionParamsBillingCycleAnchor> expectedBillingCycleAnchor =
            SubscriptionProvisionParamsBillingCycleAnchor.Unchanged;
        string expectedBillingID = "billingId";
        SubscriptionProvisionParamsBillingInformation expectedBillingInformation = new()
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
            ProrationBehavior =
                SubscriptionProvisionParamsBillingInformationProrationBehavior.InvoiceImmediately,
            TaxIds = [new() { Type = "type", Value = "value" }],
            TaxPercentage = 0,
            TaxRateIds = ["string"],
        };
        ApiEnum<string, SubscriptionProvisionParamsBillingPeriod> expectedBillingPeriod =
            SubscriptionProvisionParamsBillingPeriod.Monthly;
        SubscriptionProvisionParamsBudget expectedBudget = new() { HasSoftLimit = true, Limit = 0 };
        DateTimeOffset expectedCancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<SubscriptionProvisionParamsCharge> expectedCharges =
        [
            new()
            {
                ID = "id",
                Quantity = 0,
                Type = SubscriptionProvisionParamsChargeType.Feature,
            },
        ];
        CheckoutOptions expectedCheckoutOptions = new()
        {
            CancelUrl = "https://example.com",
            SuccessUrl = "https://example.com",
            AllowPromoCodes = true,
            AllowTaxIDCollection = true,
            CollectBillingAddress = true,
            CollectPhoneNumber = true,
            ReferenceID = "referenceId",
        };
        List<SubscriptionProvisionParamsEntitlement> expectedEntitlements =
        [
            new SubscriptionProvisionParamsEntitlementFeature()
            {
                ID = "id",
                HasSoftLimit = true,
                HasUnlimitedUsage = true,
                MonthlyResetPeriodConfiguration = new(
                    SubscriptionProvisionParamsEntitlementFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
                ResetPeriod = SubscriptionProvisionParamsEntitlementFeatureResetPeriod.Year,
                UsageLimit = 0,
                WeeklyResetPeriodConfiguration = new(
                    SubscriptionProvisionParamsEntitlementFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
                YearlyResetPeriodConfiguration = new(
                    SubscriptionProvisionParamsEntitlementFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
            },
        ];
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        SubscriptionProvisionParamsMinimumSpend expectedMinimumSpend = new()
        {
            Amount = 0,
            Currency = SubscriptionProvisionParamsMinimumSpendCurrency.Usd,
        };
        string expectedPayingCustomerID = "payingCustomerId";
        ApiEnum<string, PaymentCollectionMethod> expectedPaymentCollectionMethod =
            PaymentCollectionMethod.Charge;
        List<SubscriptionProvisionParamsPriceOverride> expectedPriceOverrides =
        [
            new()
            {
                AddonID = "addonId",
                Amount = 0,
                BaseCharge = true,
                BillingCountryCode = "billingCountryCode",
                BlockSize = 0,
                CreditGrantCadence = CreditGrantCadence.BeginningOfBillingPeriod,
                CreditRate = new()
                {
                    Amount = 1,
                    CurrencyID = "currencyId",
                    CostFormula = "costFormula",
                },
                Currency = SubscriptionProvisionParamsPriceOverrideCurrency.Usd,
                FeatureID = "featureId",
                Tiers =
                [
                    new()
                    {
                        FlatPrice = new() { Amount = 0, Currency = FlatPriceCurrency.Usd },
                        UnitPrice = new() { Amount = 0, Currency = UnitPriceCurrency.Usd },
                        UpTo = 0,
                    },
                ],
            },
        ];
        string expectedResourceID = "resourceId";
        string expectedSalesforceID = "salesforceId";
        ApiEnum<string, SubscriptionProvisionParamsScheduleStrategy> expectedScheduleStrategy =
            SubscriptionProvisionParamsScheduleStrategy.EndOfBillingPeriod;
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        SubscriptionProvisionParamsTrialOverrideConfiguration expectedTrialOverrideConfiguration =
            new()
            {
                IsTrial = true,
                TrialEndBehavior =
                    SubscriptionProvisionParamsTrialOverrideConfigurationTrialEndBehavior.ConvertToPaid,
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            };
        long expectedUnitQuantity = 0;
        string expectedXAccountID = "X-ACCOUNT-ID";
        string expectedXEnvironmentID = "X-ENVIRONMENT-ID";

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
        Assert.Equal(expectedBillingCycleAnchor, parameters.BillingCycleAnchor);
        Assert.Equal(expectedBillingID, parameters.BillingID);
        Assert.Equal(expectedBillingInformation, parameters.BillingInformation);
        Assert.Equal(expectedBillingPeriod, parameters.BillingPeriod);
        Assert.Equal(expectedBudget, parameters.Budget);
        Assert.Equal(expectedCancellationDate, parameters.CancellationDate);
        Assert.NotNull(parameters.Charges);
        Assert.Equal(expectedCharges.Count, parameters.Charges.Count);
        for (int i = 0; i < expectedCharges.Count; i++)
        {
            Assert.Equal(expectedCharges[i], parameters.Charges[i]);
        }
        Assert.Equal(expectedCheckoutOptions, parameters.CheckoutOptions);
        Assert.NotNull(parameters.Entitlements);
        Assert.Equal(expectedEntitlements.Count, parameters.Entitlements.Count);
        for (int i = 0; i < expectedEntitlements.Count; i++)
        {
            Assert.Equal(expectedEntitlements[i], parameters.Entitlements[i]);
        }
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
        Assert.Equal(expectedTrialOverrideConfiguration, parameters.TrialOverrideConfiguration);
        Assert.Equal(expectedUnitQuantity, parameters.UnitQuantity);
        Assert.Equal(expectedXAccountID, parameters.XAccountID);
        Assert.Equal(expectedXEnvironmentID, parameters.XEnvironmentID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SubscriptionProvisionParams
        {
            CustomerID = "customerId",
            PlanID = "planId",
            BillingCountryCode = "billingCountryCode",
            BillingID = "billingId",
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            MinimumSpend = new()
            {
                Amount = 0,
                Currency = SubscriptionProvisionParamsMinimumSpendCurrency.Usd,
            },
            PayingCustomerID = "payingCustomerId",
            ResourceID = "resourceId",
            SalesforceID = "salesforceId",
        };

        Assert.Null(parameters.ID);
        Assert.False(parameters.RawBodyData.ContainsKey("id"));
        Assert.Null(parameters.Addons);
        Assert.False(parameters.RawBodyData.ContainsKey("addons"));
        Assert.Null(parameters.AppliedCoupon);
        Assert.False(parameters.RawBodyData.ContainsKey("appliedCoupon"));
        Assert.Null(parameters.AwaitPaymentConfirmation);
        Assert.False(parameters.RawBodyData.ContainsKey("awaitPaymentConfirmation"));
        Assert.Null(parameters.BillingCycleAnchor);
        Assert.False(parameters.RawBodyData.ContainsKey("billingCycleAnchor"));
        Assert.Null(parameters.BillingInformation);
        Assert.False(parameters.RawBodyData.ContainsKey("billingInformation"));
        Assert.Null(parameters.BillingPeriod);
        Assert.False(parameters.RawBodyData.ContainsKey("billingPeriod"));
        Assert.Null(parameters.CancellationDate);
        Assert.False(parameters.RawBodyData.ContainsKey("cancellationDate"));
        Assert.Null(parameters.Charges);
        Assert.False(parameters.RawBodyData.ContainsKey("charges"));
        Assert.Null(parameters.CheckoutOptions);
        Assert.False(parameters.RawBodyData.ContainsKey("checkoutOptions"));
        Assert.Null(parameters.Entitlements);
        Assert.False(parameters.RawBodyData.ContainsKey("entitlements"));
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
        Assert.Null(parameters.TrialOverrideConfiguration);
        Assert.False(parameters.RawBodyData.ContainsKey("trialOverrideConfiguration"));
        Assert.Null(parameters.UnitQuantity);
        Assert.False(parameters.RawBodyData.ContainsKey("unitQuantity"));
        Assert.Null(parameters.XAccountID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ACCOUNT-ID"));
        Assert.Null(parameters.XEnvironmentID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ENVIRONMENT-ID"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SubscriptionProvisionParams
        {
            CustomerID = "customerId",
            PlanID = "planId",
            BillingCountryCode = "billingCountryCode",
            BillingID = "billingId",
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            MinimumSpend = new()
            {
                Amount = 0,
                Currency = SubscriptionProvisionParamsMinimumSpendCurrency.Usd,
            },
            PayingCustomerID = "payingCustomerId",
            ResourceID = "resourceId",
            SalesforceID = "salesforceId",

            // Null should be interpreted as omitted for these properties
            ID = null,
            Addons = null,
            AppliedCoupon = null,
            AwaitPaymentConfirmation = null,
            BillingCycleAnchor = null,
            BillingInformation = null,
            BillingPeriod = null,
            CancellationDate = null,
            Charges = null,
            CheckoutOptions = null,
            Entitlements = null,
            Metadata = null,
            PaymentCollectionMethod = null,
            PriceOverrides = null,
            ScheduleStrategy = null,
            StartDate = null,
            TrialOverrideConfiguration = null,
            UnitQuantity = null,
            XAccountID = null,
            XEnvironmentID = null,
        };

        Assert.Null(parameters.ID);
        Assert.False(parameters.RawBodyData.ContainsKey("id"));
        Assert.Null(parameters.Addons);
        Assert.False(parameters.RawBodyData.ContainsKey("addons"));
        Assert.Null(parameters.AppliedCoupon);
        Assert.False(parameters.RawBodyData.ContainsKey("appliedCoupon"));
        Assert.Null(parameters.AwaitPaymentConfirmation);
        Assert.False(parameters.RawBodyData.ContainsKey("awaitPaymentConfirmation"));
        Assert.Null(parameters.BillingCycleAnchor);
        Assert.False(parameters.RawBodyData.ContainsKey("billingCycleAnchor"));
        Assert.Null(parameters.BillingInformation);
        Assert.False(parameters.RawBodyData.ContainsKey("billingInformation"));
        Assert.Null(parameters.BillingPeriod);
        Assert.False(parameters.RawBodyData.ContainsKey("billingPeriod"));
        Assert.Null(parameters.CancellationDate);
        Assert.False(parameters.RawBodyData.ContainsKey("cancellationDate"));
        Assert.Null(parameters.Charges);
        Assert.False(parameters.RawBodyData.ContainsKey("charges"));
        Assert.Null(parameters.CheckoutOptions);
        Assert.False(parameters.RawBodyData.ContainsKey("checkoutOptions"));
        Assert.Null(parameters.Entitlements);
        Assert.False(parameters.RawBodyData.ContainsKey("entitlements"));
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
        Assert.Null(parameters.TrialOverrideConfiguration);
        Assert.False(parameters.RawBodyData.ContainsKey("trialOverrideConfiguration"));
        Assert.Null(parameters.UnitQuantity);
        Assert.False(parameters.RawBodyData.ContainsKey("unitQuantity"));
        Assert.Null(parameters.XAccountID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ACCOUNT-ID"));
        Assert.Null(parameters.XEnvironmentID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ENVIRONMENT-ID"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SubscriptionProvisionParams
        {
            CustomerID = "customerId",
            PlanID = "planId",
            ID = "id",
            Addons = [new() { ID = "id", Quantity = 0 }],
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
                    AmountsOff =
                    [
                        new()
                        {
                            Amount = 0,
                            Currency =
                                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Usd,
                        },
                    ],
                    Description = "description",
                    DurationInMonths = 1,
                    Name = "name",
                    PercentOff = 1,
                },
                PromotionCode = "promotionCode",
            },
            AwaitPaymentConfirmation = true,
            BillingCycleAnchor = SubscriptionProvisionParamsBillingCycleAnchor.Unchanged,
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
                ProrationBehavior =
                    SubscriptionProvisionParamsBillingInformationProrationBehavior.InvoiceImmediately,
                TaxIds = [new() { Type = "type", Value = "value" }],
                TaxPercentage = 0,
                TaxRateIds = ["string"],
            },
            BillingPeriod = SubscriptionProvisionParamsBillingPeriod.Monthly,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Charges =
            [
                new()
                {
                    ID = "id",
                    Quantity = 0,
                    Type = SubscriptionProvisionParamsChargeType.Feature,
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
            Entitlements =
            [
                new SubscriptionProvisionParamsEntitlementFeature()
                {
                    ID = "id",
                    HasSoftLimit = true,
                    HasUnlimitedUsage = true,
                    MonthlyResetPeriodConfiguration = new(
                        SubscriptionProvisionParamsEntitlementFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    ResetPeriod = SubscriptionProvisionParamsEntitlementFeatureResetPeriod.Year,
                    UsageLimit = 0,
                    WeeklyResetPeriodConfiguration = new(
                        SubscriptionProvisionParamsEntitlementFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    YearlyResetPeriodConfiguration = new(
                        SubscriptionProvisionParamsEntitlementFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentCollectionMethod = PaymentCollectionMethod.Charge,
            PriceOverrides =
            [
                new()
                {
                    AddonID = "addonId",
                    Amount = 0,
                    BaseCharge = true,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    CreditGrantCadence = CreditGrantCadence.BeginningOfBillingPeriod,
                    CreditRate = new()
                    {
                        Amount = 1,
                        CurrencyID = "currencyId",
                        CostFormula = "costFormula",
                    },
                    Currency = SubscriptionProvisionParamsPriceOverrideCurrency.Usd,
                    FeatureID = "featureId",
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new() { Amount = 0, Currency = FlatPriceCurrency.Usd },
                            UnitPrice = new() { Amount = 0, Currency = UnitPriceCurrency.Usd },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            ScheduleStrategy = SubscriptionProvisionParamsScheduleStrategy.EndOfBillingPeriod,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TrialOverrideConfiguration = new()
            {
                IsTrial = true,
                TrialEndBehavior =
                    SubscriptionProvisionParamsTrialOverrideConfigurationTrialEndBehavior.ConvertToPaid,
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            UnitQuantity = 0,
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

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
        var parameters = new SubscriptionProvisionParams
        {
            CustomerID = "customerId",
            PlanID = "planId",
            ID = "id",
            Addons = [new() { ID = "id", Quantity = 0 }],
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
                    AmountsOff =
                    [
                        new()
                        {
                            Amount = 0,
                            Currency =
                                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Usd,
                        },
                    ],
                    Description = "description",
                    DurationInMonths = 1,
                    Name = "name",
                    PercentOff = 1,
                },
                PromotionCode = "promotionCode",
            },
            AwaitPaymentConfirmation = true,
            BillingCycleAnchor = SubscriptionProvisionParamsBillingCycleAnchor.Unchanged,
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
                ProrationBehavior =
                    SubscriptionProvisionParamsBillingInformationProrationBehavior.InvoiceImmediately,
                TaxIds = [new() { Type = "type", Value = "value" }],
                TaxPercentage = 0,
                TaxRateIds = ["string"],
            },
            BillingPeriod = SubscriptionProvisionParamsBillingPeriod.Monthly,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Charges =
            [
                new()
                {
                    ID = "id",
                    Quantity = 0,
                    Type = SubscriptionProvisionParamsChargeType.Feature,
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
            Entitlements =
            [
                new SubscriptionProvisionParamsEntitlementFeature()
                {
                    ID = "id",
                    HasSoftLimit = true,
                    HasUnlimitedUsage = true,
                    MonthlyResetPeriodConfiguration = new(
                        SubscriptionProvisionParamsEntitlementFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    ResetPeriod = SubscriptionProvisionParamsEntitlementFeatureResetPeriod.Year,
                    UsageLimit = 0,
                    WeeklyResetPeriodConfiguration = new(
                        SubscriptionProvisionParamsEntitlementFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    YearlyResetPeriodConfiguration = new(
                        SubscriptionProvisionParamsEntitlementFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentCollectionMethod = PaymentCollectionMethod.Charge,
            PriceOverrides =
            [
                new()
                {
                    AddonID = "addonId",
                    Amount = 0,
                    BaseCharge = true,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    CreditGrantCadence = CreditGrantCadence.BeginningOfBillingPeriod,
                    CreditRate = new()
                    {
                        Amount = 1,
                        CurrencyID = "currencyId",
                        CostFormula = "costFormula",
                    },
                    Currency = SubscriptionProvisionParamsPriceOverrideCurrency.Usd,
                    FeatureID = "featureId",
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new() { Amount = 0, Currency = FlatPriceCurrency.Usd },
                            UnitPrice = new() { Amount = 0, Currency = UnitPriceCurrency.Usd },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            ScheduleStrategy = SubscriptionProvisionParamsScheduleStrategy.EndOfBillingPeriod,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TrialOverrideConfiguration = new()
            {
                IsTrial = true,
                TrialEndBehavior =
                    SubscriptionProvisionParamsTrialOverrideConfigurationTrialEndBehavior.ConvertToPaid,
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            UnitQuantity = 0,
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",

            BillingCountryCode = null,
            BillingID = null,
            Budget = null,
            MinimumSpend = null,
            PayingCustomerID = null,
            ResourceID = null,
            SalesforceID = null,
        };

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
        SubscriptionProvisionParams parameters = new()
        {
            CustomerID = "customerId",
            PlanID = "planId",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://edge.api.stigg.io/api/v1/subscriptions"), url)
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        SubscriptionProvisionParams parameters = new()
        {
            CustomerID = "customerId",
            PlanID = "planId",
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "My API Key" });

        Assert.Equal(["X-ACCOUNT-ID"], requestMessage.Headers.GetValues("X-ACCOUNT-ID"));
        Assert.Equal(["X-ENVIRONMENT-ID"], requestMessage.Headers.GetValues("X-ENVIRONMENT-ID"));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SubscriptionProvisionParams
        {
            CustomerID = "customerId",
            PlanID = "planId",
            ID = "id",
            Addons = [new() { ID = "id", Quantity = 0 }],
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
                    AmountsOff =
                    [
                        new()
                        {
                            Amount = 0,
                            Currency =
                                SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Usd,
                        },
                    ],
                    Description = "description",
                    DurationInMonths = 1,
                    Name = "name",
                    PercentOff = 1,
                },
                PromotionCode = "promotionCode",
            },
            AwaitPaymentConfirmation = true,
            BillingCountryCode = "billingCountryCode",
            BillingCycleAnchor = SubscriptionProvisionParamsBillingCycleAnchor.Unchanged,
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
                ProrationBehavior =
                    SubscriptionProvisionParamsBillingInformationProrationBehavior.InvoiceImmediately,
                TaxIds = [new() { Type = "type", Value = "value" }],
                TaxPercentage = 0,
                TaxRateIds = ["string"],
            },
            BillingPeriod = SubscriptionProvisionParamsBillingPeriod.Monthly,
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Charges =
            [
                new()
                {
                    ID = "id",
                    Quantity = 0,
                    Type = SubscriptionProvisionParamsChargeType.Feature,
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
            Entitlements =
            [
                new SubscriptionProvisionParamsEntitlementFeature()
                {
                    ID = "id",
                    HasSoftLimit = true,
                    HasUnlimitedUsage = true,
                    MonthlyResetPeriodConfiguration = new(
                        SubscriptionProvisionParamsEntitlementFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    ResetPeriod = SubscriptionProvisionParamsEntitlementFeatureResetPeriod.Year,
                    UsageLimit = 0,
                    WeeklyResetPeriodConfiguration = new(
                        SubscriptionProvisionParamsEntitlementFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    YearlyResetPeriodConfiguration = new(
                        SubscriptionProvisionParamsEntitlementFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MinimumSpend = new()
            {
                Amount = 0,
                Currency = SubscriptionProvisionParamsMinimumSpendCurrency.Usd,
            },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod = PaymentCollectionMethod.Charge,
            PriceOverrides =
            [
                new()
                {
                    AddonID = "addonId",
                    Amount = 0,
                    BaseCharge = true,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    CreditGrantCadence = CreditGrantCadence.BeginningOfBillingPeriod,
                    CreditRate = new()
                    {
                        Amount = 1,
                        CurrencyID = "currencyId",
                        CostFormula = "costFormula",
                    },
                    Currency = SubscriptionProvisionParamsPriceOverrideCurrency.Usd,
                    FeatureID = "featureId",
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new() { Amount = 0, Currency = FlatPriceCurrency.Usd },
                            UnitPrice = new() { Amount = 0, Currency = UnitPriceCurrency.Usd },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            ResourceID = "resourceId",
            SalesforceID = "salesforceId",
            ScheduleStrategy = SubscriptionProvisionParamsScheduleStrategy.EndOfBillingPeriod,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TrialOverrideConfiguration = new()
            {
                IsTrial = true,
                TrialEndBehavior =
                    SubscriptionProvisionParamsTrialOverrideConfigurationTrialEndBehavior.ConvertToPaid,
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            UnitQuantity = 0,
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        SubscriptionProvisionParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class SubscriptionProvisionParamsAddonTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionProvisionParamsAddon { ID = "id", Quantity = 0 };

        string expectedID = "id";
        long expectedQuantity = 0;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedQuantity, model.Quantity);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionProvisionParamsAddon { ID = "id", Quantity = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionProvisionParamsAddon>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionProvisionParamsAddon { ID = "id", Quantity = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionProvisionParamsAddon>(
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
        var model = new SubscriptionProvisionParamsAddon { ID = "id", Quantity = 0 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionProvisionParamsAddon { ID = "id", Quantity = 0 };

        SubscriptionProvisionParamsAddon copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionProvisionParamsAppliedCouponTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionProvisionParamsAppliedCoupon
        {
            BillingCouponID = "billingCouponId",
            Configuration = new() { StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z") },
            CouponID = "couponId",
            Discount = new()
            {
                AmountsOff =
                [
                    new()
                    {
                        Amount = 0,
                        Currency =
                            SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Usd,
                    },
                ],
                Description = "description",
                DurationInMonths = 1,
                Name = "name",
                PercentOff = 1,
            },
            PromotionCode = "promotionCode",
        };

        string expectedBillingCouponID = "billingCouponId";
        SubscriptionProvisionParamsAppliedCouponConfiguration expectedConfiguration = new()
        {
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string expectedCouponID = "couponId";
        SubscriptionProvisionParamsAppliedCouponDiscount expectedDiscount = new()
        {
            AmountsOff =
            [
                new()
                {
                    Amount = 0,
                    Currency =
                        SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Usd,
                },
            ],
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
        var model = new SubscriptionProvisionParamsAppliedCoupon
        {
            BillingCouponID = "billingCouponId",
            Configuration = new() { StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z") },
            CouponID = "couponId",
            Discount = new()
            {
                AmountsOff =
                [
                    new()
                    {
                        Amount = 0,
                        Currency =
                            SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Usd,
                    },
                ],
                Description = "description",
                DurationInMonths = 1,
                Name = "name",
                PercentOff = 1,
            },
            PromotionCode = "promotionCode",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionProvisionParamsAppliedCoupon>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionProvisionParamsAppliedCoupon
        {
            BillingCouponID = "billingCouponId",
            Configuration = new() { StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z") },
            CouponID = "couponId",
            Discount = new()
            {
                AmountsOff =
                [
                    new()
                    {
                        Amount = 0,
                        Currency =
                            SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Usd,
                    },
                ],
                Description = "description",
                DurationInMonths = 1,
                Name = "name",
                PercentOff = 1,
            },
            PromotionCode = "promotionCode",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionProvisionParamsAppliedCoupon>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBillingCouponID = "billingCouponId";
        SubscriptionProvisionParamsAppliedCouponConfiguration expectedConfiguration = new()
        {
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string expectedCouponID = "couponId";
        SubscriptionProvisionParamsAppliedCouponDiscount expectedDiscount = new()
        {
            AmountsOff =
            [
                new()
                {
                    Amount = 0,
                    Currency =
                        SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Usd,
                },
            ],
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
        var model = new SubscriptionProvisionParamsAppliedCoupon
        {
            BillingCouponID = "billingCouponId",
            Configuration = new() { StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z") },
            CouponID = "couponId",
            Discount = new()
            {
                AmountsOff =
                [
                    new()
                    {
                        Amount = 0,
                        Currency =
                            SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Usd,
                    },
                ],
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
        var model = new SubscriptionProvisionParamsAppliedCoupon { };

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
        var model = new SubscriptionProvisionParamsAppliedCoupon { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SubscriptionProvisionParamsAppliedCoupon
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
        var model = new SubscriptionProvisionParamsAppliedCoupon
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
        var model = new SubscriptionProvisionParamsAppliedCoupon
        {
            BillingCouponID = "billingCouponId",
            Configuration = new() { StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z") },
            CouponID = "couponId",
            Discount = new()
            {
                AmountsOff =
                [
                    new()
                    {
                        Amount = 0,
                        Currency =
                            SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Usd,
                    },
                ],
                Description = "description",
                DurationInMonths = 1,
                Name = "name",
                PercentOff = 1,
            },
            PromotionCode = "promotionCode",
        };

        SubscriptionProvisionParamsAppliedCoupon copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionProvisionParamsAppliedCouponConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionProvisionParamsAppliedCouponConfiguration
        {
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedStartDate, model.StartDate);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionProvisionParamsAppliedCouponConfiguration
        {
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionProvisionParamsAppliedCouponConfiguration>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionProvisionParamsAppliedCouponConfiguration
        {
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionProvisionParamsAppliedCouponConfiguration>(
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
        var model = new SubscriptionProvisionParamsAppliedCouponConfiguration
        {
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubscriptionProvisionParamsAppliedCouponConfiguration { };

        Assert.Null(model.StartDate);
        Assert.False(model.RawData.ContainsKey("startDate"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SubscriptionProvisionParamsAppliedCouponConfiguration { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SubscriptionProvisionParamsAppliedCouponConfiguration
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
        var model = new SubscriptionProvisionParamsAppliedCouponConfiguration
        {
            // Null should be interpreted as omitted for these properties
            StartDate = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionProvisionParamsAppliedCouponConfiguration
        {
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        SubscriptionProvisionParamsAppliedCouponConfiguration copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionProvisionParamsAppliedCouponDiscountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionProvisionParamsAppliedCouponDiscount
        {
            AmountsOff =
            [
                new()
                {
                    Amount = 0,
                    Currency =
                        SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Usd,
                },
            ],
            Description = "description",
            DurationInMonths = 1,
            Name = "name",
            PercentOff = 1,
        };

        List<SubscriptionProvisionParamsAppliedCouponDiscountAmountsOff> expectedAmountsOff =
        [
            new()
            {
                Amount = 0,
                Currency = SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Usd,
            },
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
        var model = new SubscriptionProvisionParamsAppliedCouponDiscount
        {
            AmountsOff =
            [
                new()
                {
                    Amount = 0,
                    Currency =
                        SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Usd,
                },
            ],
            Description = "description",
            DurationInMonths = 1,
            Name = "name",
            PercentOff = 1,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionProvisionParamsAppliedCouponDiscount>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionProvisionParamsAppliedCouponDiscount
        {
            AmountsOff =
            [
                new()
                {
                    Amount = 0,
                    Currency =
                        SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Usd,
                },
            ],
            Description = "description",
            DurationInMonths = 1,
            Name = "name",
            PercentOff = 1,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionProvisionParamsAppliedCouponDiscount>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<SubscriptionProvisionParamsAppliedCouponDiscountAmountsOff> expectedAmountsOff =
        [
            new()
            {
                Amount = 0,
                Currency = SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Usd,
            },
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
        var model = new SubscriptionProvisionParamsAppliedCouponDiscount
        {
            AmountsOff =
            [
                new()
                {
                    Amount = 0,
                    Currency =
                        SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Usd,
                },
            ],
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
        var model = new SubscriptionProvisionParamsAppliedCouponDiscount
        {
            AmountsOff =
            [
                new()
                {
                    Amount = 0,
                    Currency =
                        SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Usd,
                },
            ],
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
        var model = new SubscriptionProvisionParamsAppliedCouponDiscount
        {
            AmountsOff =
            [
                new()
                {
                    Amount = 0,
                    Currency =
                        SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Usd,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SubscriptionProvisionParamsAppliedCouponDiscount
        {
            AmountsOff =
            [
                new()
                {
                    Amount = 0,
                    Currency =
                        SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Usd,
                },
            ],

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
        var model = new SubscriptionProvisionParamsAppliedCouponDiscount
        {
            AmountsOff =
            [
                new()
                {
                    Amount = 0,
                    Currency =
                        SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Usd,
                },
            ],

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
        var model = new SubscriptionProvisionParamsAppliedCouponDiscount
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
        var model = new SubscriptionProvisionParamsAppliedCouponDiscount
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
        var model = new SubscriptionProvisionParamsAppliedCouponDiscount
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
        var model = new SubscriptionProvisionParamsAppliedCouponDiscount
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
        var model = new SubscriptionProvisionParamsAppliedCouponDiscount
        {
            AmountsOff =
            [
                new()
                {
                    Amount = 0,
                    Currency =
                        SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Usd,
                },
            ],
            Description = "description",
            DurationInMonths = 1,
            Name = "name",
            PercentOff = 1,
        };

        SubscriptionProvisionParamsAppliedCouponDiscount copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionProvisionParamsAppliedCouponDiscountAmountsOff
        {
            Amount = 0,
            Currency = SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Usd,
        };

        double expectedAmount = 0;
        ApiEnum<
            string,
            SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency
        > expectedCurrency = SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionProvisionParamsAppliedCouponDiscountAmountsOff
        {
            Amount = 0,
            Currency = SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Usd,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionProvisionParamsAppliedCouponDiscountAmountsOff>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionProvisionParamsAppliedCouponDiscountAmountsOff
        {
            Amount = 0,
            Currency = SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Usd,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionProvisionParamsAppliedCouponDiscountAmountsOff>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        ApiEnum<
            string,
            SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency
        > expectedCurrency = SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionProvisionParamsAppliedCouponDiscountAmountsOff
        {
            Amount = 0,
            Currency = SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionProvisionParamsAppliedCouponDiscountAmountsOff
        {
            Amount = 0,
            Currency = SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Usd,
        };

        SubscriptionProvisionParamsAppliedCouponDiscountAmountsOff copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrencyTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Usd)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Aed)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.All)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Amd)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Ang)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Aud)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Awg)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Azn)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Bam)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Bbd)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Bdt)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Bgn)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Bif)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Bmd)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Bnd)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Bsd)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Bwp)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Byn)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Bzd)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Brl)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Cad)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Cdf)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Chf)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Cny)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Czk)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Dkk)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Dop)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Dzd)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Egp)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Etb)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Eur)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Fjd)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Gbp)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Gel)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Gip)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Gmd)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Gyd)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Hkd)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Hrk)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Htg)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Idr)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Ils)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Inr)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Isk)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Jmd)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Jpy)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Kes)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Kgs)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Khr)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Kmf)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Krw)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Kyd)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Kzt)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Lbp)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Lkr)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Lrd)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Lsl)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Mad)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Mdl)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Mga)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Mkd)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Mmk)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Mnt)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Mop)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Mro)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Mvr)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Mwk)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Mxn)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Myr)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Mzn)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Nad)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Ngn)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Nok)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Npr)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Nzd)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Pgk)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Php)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Pkr)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Pln)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Qar)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Ron)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Rsd)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Rub)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Rwf)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Sar)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Sbd)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Scr)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Sek)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Sgd)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Sle)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Sll)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Sos)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Szl)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Thb)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Tjs)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Top)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Try)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Ttd)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Tzs)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Uah)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Uzs)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Vnd)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Vuv)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Wst)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Xaf)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Xcd)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Yer)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Zar)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Zmw)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Clp)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Djf)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Gnf)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Ugx)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Pyg)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Xof)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Xpf)]
    public void Validation_Works(
        SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Usd)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Aed)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.All)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Amd)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Ang)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Aud)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Awg)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Azn)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Bam)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Bbd)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Bdt)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Bgn)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Bif)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Bmd)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Bnd)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Bsd)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Bwp)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Byn)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Bzd)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Brl)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Cad)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Cdf)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Chf)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Cny)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Czk)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Dkk)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Dop)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Dzd)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Egp)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Etb)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Eur)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Fjd)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Gbp)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Gel)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Gip)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Gmd)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Gyd)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Hkd)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Hrk)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Htg)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Idr)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Ils)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Inr)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Isk)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Jmd)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Jpy)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Kes)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Kgs)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Khr)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Kmf)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Krw)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Kyd)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Kzt)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Lbp)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Lkr)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Lrd)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Lsl)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Mad)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Mdl)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Mga)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Mkd)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Mmk)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Mnt)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Mop)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Mro)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Mvr)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Mwk)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Mxn)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Myr)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Mzn)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Nad)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Ngn)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Nok)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Npr)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Nzd)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Pgk)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Php)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Pkr)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Pln)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Qar)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Ron)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Rsd)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Rub)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Rwf)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Sar)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Sbd)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Scr)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Sek)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Sgd)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Sle)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Sll)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Sos)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Szl)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Thb)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Tjs)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Top)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Try)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Ttd)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Tzs)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Uah)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Uzs)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Vnd)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Vuv)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Wst)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Xaf)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Xcd)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Yer)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Zar)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Zmw)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Clp)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Djf)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Gnf)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Ugx)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Pyg)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Xof)]
    [InlineData(SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency.Xpf)]
    public void SerializationRoundtrip_Works(
        SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionProvisionParamsBillingCycleAnchorTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionProvisionParamsBillingCycleAnchor.Unchanged)]
    [InlineData(SubscriptionProvisionParamsBillingCycleAnchor.Now)]
    public void Validation_Works(SubscriptionProvisionParamsBillingCycleAnchor rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionProvisionParamsBillingCycleAnchor> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionParamsBillingCycleAnchor>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionProvisionParamsBillingCycleAnchor.Unchanged)]
    [InlineData(SubscriptionProvisionParamsBillingCycleAnchor.Now)]
    public void SerializationRoundtrip_Works(SubscriptionProvisionParamsBillingCycleAnchor rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionProvisionParamsBillingCycleAnchor> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionParamsBillingCycleAnchor>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionParamsBillingCycleAnchor>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionParamsBillingCycleAnchor>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionProvisionParamsBillingInformationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionProvisionParamsBillingInformation
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
            ProrationBehavior =
                SubscriptionProvisionParamsBillingInformationProrationBehavior.InvoiceImmediately,
            TaxIds = [new() { Type = "type", Value = "value" }],
            TaxPercentage = 0,
            TaxRateIds = ["string"],
        };

        SubscriptionProvisionParamsBillingInformationBillingAddress expectedBillingAddress = new()
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
        ApiEnum<
            string,
            SubscriptionProvisionParamsBillingInformationProrationBehavior
        > expectedProrationBehavior =
            SubscriptionProvisionParamsBillingInformationProrationBehavior.InvoiceImmediately;
        List<SubscriptionProvisionParamsBillingInformationTaxID> expectedTaxIds =
        [
            new() { Type = "type", Value = "value" },
        ];
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
        var model = new SubscriptionProvisionParamsBillingInformation
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
            ProrationBehavior =
                SubscriptionProvisionParamsBillingInformationProrationBehavior.InvoiceImmediately,
            TaxIds = [new() { Type = "type", Value = "value" }],
            TaxPercentage = 0,
            TaxRateIds = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionProvisionParamsBillingInformation>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionProvisionParamsBillingInformation
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
            ProrationBehavior =
                SubscriptionProvisionParamsBillingInformationProrationBehavior.InvoiceImmediately,
            TaxIds = [new() { Type = "type", Value = "value" }],
            TaxPercentage = 0,
            TaxRateIds = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionProvisionParamsBillingInformation>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        SubscriptionProvisionParamsBillingInformationBillingAddress expectedBillingAddress = new()
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
        ApiEnum<
            string,
            SubscriptionProvisionParamsBillingInformationProrationBehavior
        > expectedProrationBehavior =
            SubscriptionProvisionParamsBillingInformationProrationBehavior.InvoiceImmediately;
        List<SubscriptionProvisionParamsBillingInformationTaxID> expectedTaxIds =
        [
            new() { Type = "type", Value = "value" },
        ];
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
        var model = new SubscriptionProvisionParamsBillingInformation
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
            ProrationBehavior =
                SubscriptionProvisionParamsBillingInformationProrationBehavior.InvoiceImmediately,
            TaxIds = [new() { Type = "type", Value = "value" }],
            TaxPercentage = 0,
            TaxRateIds = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubscriptionProvisionParamsBillingInformation
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
        var model = new SubscriptionProvisionParamsBillingInformation
        {
            ChargeOnBehalfOfAccount = "chargeOnBehalfOfAccount",
            IntegrationID = "integrationId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SubscriptionProvisionParamsBillingInformation
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
        var model = new SubscriptionProvisionParamsBillingInformation
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
        var model = new SubscriptionProvisionParamsBillingInformation
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
            ProrationBehavior =
                SubscriptionProvisionParamsBillingInformationProrationBehavior.InvoiceImmediately,
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
        var model = new SubscriptionProvisionParamsBillingInformation
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
            ProrationBehavior =
                SubscriptionProvisionParamsBillingInformationProrationBehavior.InvoiceImmediately,
            TaxIds = [new() { Type = "type", Value = "value" }],
            TaxPercentage = 0,
            TaxRateIds = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SubscriptionProvisionParamsBillingInformation
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
            ProrationBehavior =
                SubscriptionProvisionParamsBillingInformationProrationBehavior.InvoiceImmediately,
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
        var model = new SubscriptionProvisionParamsBillingInformation
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
            ProrationBehavior =
                SubscriptionProvisionParamsBillingInformationProrationBehavior.InvoiceImmediately,
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
        var model = new SubscriptionProvisionParamsBillingInformation
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
            ProrationBehavior =
                SubscriptionProvisionParamsBillingInformationProrationBehavior.InvoiceImmediately,
            TaxIds = [new() { Type = "type", Value = "value" }],
            TaxPercentage = 0,
            TaxRateIds = ["string"],
        };

        SubscriptionProvisionParamsBillingInformation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionProvisionParamsBillingInformationBillingAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionProvisionParamsBillingInformationBillingAddress
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
        var model = new SubscriptionProvisionParamsBillingInformationBillingAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionProvisionParamsBillingInformationBillingAddress>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionProvisionParamsBillingInformationBillingAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionProvisionParamsBillingInformationBillingAddress>(
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
        var model = new SubscriptionProvisionParamsBillingInformationBillingAddress
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
        var model = new SubscriptionProvisionParamsBillingInformationBillingAddress { };

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
        var model = new SubscriptionProvisionParamsBillingInformationBillingAddress { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SubscriptionProvisionParamsBillingInformationBillingAddress
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
        var model = new SubscriptionProvisionParamsBillingInformationBillingAddress
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
        var model = new SubscriptionProvisionParamsBillingInformationBillingAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };

        SubscriptionProvisionParamsBillingInformationBillingAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionProvisionParamsBillingInformationProrationBehaviorTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionProvisionParamsBillingInformationProrationBehavior.InvoiceImmediately)]
    [InlineData(SubscriptionProvisionParamsBillingInformationProrationBehavior.CreateProrations)]
    [InlineData(SubscriptionProvisionParamsBillingInformationProrationBehavior.None)]
    public void Validation_Works(
        SubscriptionProvisionParamsBillingInformationProrationBehavior rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionProvisionParamsBillingInformationProrationBehavior> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionParamsBillingInformationProrationBehavior>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionProvisionParamsBillingInformationProrationBehavior.InvoiceImmediately)]
    [InlineData(SubscriptionProvisionParamsBillingInformationProrationBehavior.CreateProrations)]
    [InlineData(SubscriptionProvisionParamsBillingInformationProrationBehavior.None)]
    public void SerializationRoundtrip_Works(
        SubscriptionProvisionParamsBillingInformationProrationBehavior rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionProvisionParamsBillingInformationProrationBehavior> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionParamsBillingInformationProrationBehavior>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionParamsBillingInformationProrationBehavior>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionParamsBillingInformationProrationBehavior>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionProvisionParamsBillingInformationTaxIDTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionProvisionParamsBillingInformationTaxID
        {
            Type = "type",
            Value = "value",
        };

        string expectedType = "type";
        string expectedValue = "value";

        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionProvisionParamsBillingInformationTaxID
        {
            Type = "type",
            Value = "value",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionProvisionParamsBillingInformationTaxID>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionProvisionParamsBillingInformationTaxID
        {
            Type = "type",
            Value = "value",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionProvisionParamsBillingInformationTaxID>(
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
        var model = new SubscriptionProvisionParamsBillingInformationTaxID
        {
            Type = "type",
            Value = "value",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionProvisionParamsBillingInformationTaxID
        {
            Type = "type",
            Value = "value",
        };

        SubscriptionProvisionParamsBillingInformationTaxID copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionProvisionParamsBillingPeriodTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionProvisionParamsBillingPeriod.Monthly)]
    [InlineData(SubscriptionProvisionParamsBillingPeriod.Annually)]
    public void Validation_Works(SubscriptionProvisionParamsBillingPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionProvisionParamsBillingPeriod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionParamsBillingPeriod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionProvisionParamsBillingPeriod.Monthly)]
    [InlineData(SubscriptionProvisionParamsBillingPeriod.Annually)]
    public void SerializationRoundtrip_Works(SubscriptionProvisionParamsBillingPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionProvisionParamsBillingPeriod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionParamsBillingPeriod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionParamsBillingPeriod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionParamsBillingPeriod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionProvisionParamsBudgetTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionProvisionParamsBudget { HasSoftLimit = true, Limit = 0 };

        bool expectedHasSoftLimit = true;
        double expectedLimit = 0;

        Assert.Equal(expectedHasSoftLimit, model.HasSoftLimit);
        Assert.Equal(expectedLimit, model.Limit);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionProvisionParamsBudget { HasSoftLimit = true, Limit = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionProvisionParamsBudget>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionProvisionParamsBudget { HasSoftLimit = true, Limit = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionProvisionParamsBudget>(
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
        var model = new SubscriptionProvisionParamsBudget { HasSoftLimit = true, Limit = 0 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionProvisionParamsBudget { HasSoftLimit = true, Limit = 0 };

        SubscriptionProvisionParamsBudget copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionProvisionParamsChargeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionProvisionParamsCharge
        {
            ID = "id",
            Quantity = 0,
            Type = SubscriptionProvisionParamsChargeType.Feature,
        };

        string expectedID = "id";
        double expectedQuantity = 0;
        ApiEnum<string, SubscriptionProvisionParamsChargeType> expectedType =
            SubscriptionProvisionParamsChargeType.Feature;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedQuantity, model.Quantity);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionProvisionParamsCharge
        {
            ID = "id",
            Quantity = 0,
            Type = SubscriptionProvisionParamsChargeType.Feature,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionProvisionParamsCharge>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionProvisionParamsCharge
        {
            ID = "id",
            Quantity = 0,
            Type = SubscriptionProvisionParamsChargeType.Feature,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionProvisionParamsCharge>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        double expectedQuantity = 0;
        ApiEnum<string, SubscriptionProvisionParamsChargeType> expectedType =
            SubscriptionProvisionParamsChargeType.Feature;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedQuantity, deserialized.Quantity);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionProvisionParamsCharge
        {
            ID = "id",
            Quantity = 0,
            Type = SubscriptionProvisionParamsChargeType.Feature,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionProvisionParamsCharge
        {
            ID = "id",
            Quantity = 0,
            Type = SubscriptionProvisionParamsChargeType.Feature,
        };

        SubscriptionProvisionParamsCharge copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionProvisionParamsChargeTypeTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionProvisionParamsChargeType.Feature)]
    [InlineData(SubscriptionProvisionParamsChargeType.Credit)]
    public void Validation_Works(SubscriptionProvisionParamsChargeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionProvisionParamsChargeType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionParamsChargeType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionProvisionParamsChargeType.Feature)]
    [InlineData(SubscriptionProvisionParamsChargeType.Credit)]
    public void SerializationRoundtrip_Works(SubscriptionProvisionParamsChargeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionProvisionParamsChargeType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionParamsChargeType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionParamsChargeType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionParamsChargeType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CheckoutOptionsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CheckoutOptions
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
        var model = new CheckoutOptions
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
        var deserialized = JsonSerializer.Deserialize<CheckoutOptions>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CheckoutOptions
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
        var deserialized = JsonSerializer.Deserialize<CheckoutOptions>(
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
        var model = new CheckoutOptions
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
        var model = new CheckoutOptions
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
        var model = new CheckoutOptions
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
        var model = new CheckoutOptions
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
        var model = new CheckoutOptions
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
        var model = new CheckoutOptions
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
        var model = new CheckoutOptions
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
        var model = new CheckoutOptions
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
        var model = new CheckoutOptions
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
        var model = new CheckoutOptions
        {
            CancelUrl = "https://example.com",
            SuccessUrl = "https://example.com",
            AllowPromoCodes = true,
            AllowTaxIDCollection = true,
            CollectBillingAddress = true,
            CollectPhoneNumber = true,
            ReferenceID = "referenceId",
        };

        CheckoutOptions copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionProvisionParamsEntitlementTest : TestBase
{
    [Fact]
    public void FeatureValidationWorks()
    {
        SubscriptionProvisionParamsEntitlement value =
            new SubscriptionProvisionParamsEntitlementFeature()
            {
                ID = "id",
                HasSoftLimit = true,
                HasUnlimitedUsage = true,
                MonthlyResetPeriodConfiguration = new(
                    SubscriptionProvisionParamsEntitlementFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
                ResetPeriod = SubscriptionProvisionParamsEntitlementFeatureResetPeriod.Year,
                UsageLimit = 0,
                WeeklyResetPeriodConfiguration = new(
                    SubscriptionProvisionParamsEntitlementFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
                YearlyResetPeriodConfiguration = new(
                    SubscriptionProvisionParamsEntitlementFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
            };
        value.Validate();
    }

    [Fact]
    public void CreditValidationWorks()
    {
        SubscriptionProvisionParamsEntitlement value =
            new SubscriptionProvisionParamsEntitlementCredit()
            {
                ID = "id",
                Amount = 1,
                Cadence = SubscriptionProvisionParamsEntitlementCreditCadence.Month,
            };
        value.Validate();
    }

    [Fact]
    public void FeatureSerializationRoundtripWorks()
    {
        SubscriptionProvisionParamsEntitlement value =
            new SubscriptionProvisionParamsEntitlementFeature()
            {
                ID = "id",
                HasSoftLimit = true,
                HasUnlimitedUsage = true,
                MonthlyResetPeriodConfiguration = new(
                    SubscriptionProvisionParamsEntitlementFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
                ResetPeriod = SubscriptionProvisionParamsEntitlementFeatureResetPeriod.Year,
                UsageLimit = 0,
                WeeklyResetPeriodConfiguration = new(
                    SubscriptionProvisionParamsEntitlementFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
                YearlyResetPeriodConfiguration = new(
                    SubscriptionProvisionParamsEntitlementFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionProvisionParamsEntitlement>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CreditSerializationRoundtripWorks()
    {
        SubscriptionProvisionParamsEntitlement value =
            new SubscriptionProvisionParamsEntitlementCredit()
            {
                ID = "id",
                Amount = 1,
                Cadence = SubscriptionProvisionParamsEntitlementCreditCadence.Month,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionProvisionParamsEntitlement>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionProvisionParamsEntitlementFeatureTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionProvisionParamsEntitlementFeature
        {
            ID = "id",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            MonthlyResetPeriodConfiguration = new(
                SubscriptionProvisionParamsEntitlementFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            ResetPeriod = SubscriptionProvisionParamsEntitlementFeatureResetPeriod.Year,
            UsageLimit = 0,
            WeeklyResetPeriodConfiguration = new(
                SubscriptionProvisionParamsEntitlementFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                SubscriptionProvisionParamsEntitlementFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };

        string expectedID = "id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("FEATURE");
        bool expectedHasSoftLimit = true;
        bool expectedHasUnlimitedUsage = true;
        SubscriptionProvisionParamsEntitlementFeatureMonthlyResetPeriodConfiguration expectedMonthlyResetPeriodConfiguration =
            new(
                SubscriptionProvisionParamsEntitlementFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            );
        ApiEnum<
            string,
            SubscriptionProvisionParamsEntitlementFeatureResetPeriod
        > expectedResetPeriod = SubscriptionProvisionParamsEntitlementFeatureResetPeriod.Year;
        long expectedUsageLimit = 0;
        SubscriptionProvisionParamsEntitlementFeatureWeeklyResetPeriodConfiguration expectedWeeklyResetPeriodConfiguration =
            new(
                SubscriptionProvisionParamsEntitlementFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            );
        SubscriptionProvisionParamsEntitlementFeatureYearlyResetPeriodConfiguration expectedYearlyResetPeriodConfiguration =
            new(
                SubscriptionProvisionParamsEntitlementFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            );

        Assert.Equal(expectedID, model.ID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedHasSoftLimit, model.HasSoftLimit);
        Assert.Equal(expectedHasUnlimitedUsage, model.HasUnlimitedUsage);
        Assert.Equal(
            expectedMonthlyResetPeriodConfiguration,
            model.MonthlyResetPeriodConfiguration
        );
        Assert.Equal(expectedResetPeriod, model.ResetPeriod);
        Assert.Equal(expectedUsageLimit, model.UsageLimit);
        Assert.Equal(expectedWeeklyResetPeriodConfiguration, model.WeeklyResetPeriodConfiguration);
        Assert.Equal(expectedYearlyResetPeriodConfiguration, model.YearlyResetPeriodConfiguration);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionProvisionParamsEntitlementFeature
        {
            ID = "id",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            MonthlyResetPeriodConfiguration = new(
                SubscriptionProvisionParamsEntitlementFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            ResetPeriod = SubscriptionProvisionParamsEntitlementFeatureResetPeriod.Year,
            UsageLimit = 0,
            WeeklyResetPeriodConfiguration = new(
                SubscriptionProvisionParamsEntitlementFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                SubscriptionProvisionParamsEntitlementFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionProvisionParamsEntitlementFeature>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionProvisionParamsEntitlementFeature
        {
            ID = "id",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            MonthlyResetPeriodConfiguration = new(
                SubscriptionProvisionParamsEntitlementFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            ResetPeriod = SubscriptionProvisionParamsEntitlementFeatureResetPeriod.Year,
            UsageLimit = 0,
            WeeklyResetPeriodConfiguration = new(
                SubscriptionProvisionParamsEntitlementFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                SubscriptionProvisionParamsEntitlementFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionProvisionParamsEntitlementFeature>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("FEATURE");
        bool expectedHasSoftLimit = true;
        bool expectedHasUnlimitedUsage = true;
        SubscriptionProvisionParamsEntitlementFeatureMonthlyResetPeriodConfiguration expectedMonthlyResetPeriodConfiguration =
            new(
                SubscriptionProvisionParamsEntitlementFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            );
        ApiEnum<
            string,
            SubscriptionProvisionParamsEntitlementFeatureResetPeriod
        > expectedResetPeriod = SubscriptionProvisionParamsEntitlementFeatureResetPeriod.Year;
        long expectedUsageLimit = 0;
        SubscriptionProvisionParamsEntitlementFeatureWeeklyResetPeriodConfiguration expectedWeeklyResetPeriodConfiguration =
            new(
                SubscriptionProvisionParamsEntitlementFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            );
        SubscriptionProvisionParamsEntitlementFeatureYearlyResetPeriodConfiguration expectedYearlyResetPeriodConfiguration =
            new(
                SubscriptionProvisionParamsEntitlementFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            );

        Assert.Equal(expectedID, deserialized.ID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedHasSoftLimit, deserialized.HasSoftLimit);
        Assert.Equal(expectedHasUnlimitedUsage, deserialized.HasUnlimitedUsage);
        Assert.Equal(
            expectedMonthlyResetPeriodConfiguration,
            deserialized.MonthlyResetPeriodConfiguration
        );
        Assert.Equal(expectedResetPeriod, deserialized.ResetPeriod);
        Assert.Equal(expectedUsageLimit, deserialized.UsageLimit);
        Assert.Equal(
            expectedWeeklyResetPeriodConfiguration,
            deserialized.WeeklyResetPeriodConfiguration
        );
        Assert.Equal(
            expectedYearlyResetPeriodConfiguration,
            deserialized.YearlyResetPeriodConfiguration
        );
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionProvisionParamsEntitlementFeature
        {
            ID = "id",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            MonthlyResetPeriodConfiguration = new(
                SubscriptionProvisionParamsEntitlementFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            ResetPeriod = SubscriptionProvisionParamsEntitlementFeatureResetPeriod.Year,
            UsageLimit = 0,
            WeeklyResetPeriodConfiguration = new(
                SubscriptionProvisionParamsEntitlementFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                SubscriptionProvisionParamsEntitlementFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubscriptionProvisionParamsEntitlementFeature
        {
            ID = "id",
            MonthlyResetPeriodConfiguration = new(
                SubscriptionProvisionParamsEntitlementFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            WeeklyResetPeriodConfiguration = new(
                SubscriptionProvisionParamsEntitlementFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                SubscriptionProvisionParamsEntitlementFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };

        Assert.Null(model.HasSoftLimit);
        Assert.False(model.RawData.ContainsKey("hasSoftLimit"));
        Assert.Null(model.HasUnlimitedUsage);
        Assert.False(model.RawData.ContainsKey("hasUnlimitedUsage"));
        Assert.Null(model.ResetPeriod);
        Assert.False(model.RawData.ContainsKey("resetPeriod"));
        Assert.Null(model.UsageLimit);
        Assert.False(model.RawData.ContainsKey("usageLimit"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SubscriptionProvisionParamsEntitlementFeature
        {
            ID = "id",
            MonthlyResetPeriodConfiguration = new(
                SubscriptionProvisionParamsEntitlementFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            WeeklyResetPeriodConfiguration = new(
                SubscriptionProvisionParamsEntitlementFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                SubscriptionProvisionParamsEntitlementFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SubscriptionProvisionParamsEntitlementFeature
        {
            ID = "id",
            MonthlyResetPeriodConfiguration = new(
                SubscriptionProvisionParamsEntitlementFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            WeeklyResetPeriodConfiguration = new(
                SubscriptionProvisionParamsEntitlementFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                SubscriptionProvisionParamsEntitlementFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),

            // Null should be interpreted as omitted for these properties
            HasSoftLimit = null,
            HasUnlimitedUsage = null,
            ResetPeriod = null,
            UsageLimit = null,
        };

        Assert.Null(model.HasSoftLimit);
        Assert.False(model.RawData.ContainsKey("hasSoftLimit"));
        Assert.Null(model.HasUnlimitedUsage);
        Assert.False(model.RawData.ContainsKey("hasUnlimitedUsage"));
        Assert.Null(model.ResetPeriod);
        Assert.False(model.RawData.ContainsKey("resetPeriod"));
        Assert.Null(model.UsageLimit);
        Assert.False(model.RawData.ContainsKey("usageLimit"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SubscriptionProvisionParamsEntitlementFeature
        {
            ID = "id",
            MonthlyResetPeriodConfiguration = new(
                SubscriptionProvisionParamsEntitlementFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            WeeklyResetPeriodConfiguration = new(
                SubscriptionProvisionParamsEntitlementFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                SubscriptionProvisionParamsEntitlementFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),

            // Null should be interpreted as omitted for these properties
            HasSoftLimit = null,
            HasUnlimitedUsage = null,
            ResetPeriod = null,
            UsageLimit = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubscriptionProvisionParamsEntitlementFeature
        {
            ID = "id",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            ResetPeriod = SubscriptionProvisionParamsEntitlementFeatureResetPeriod.Year,
            UsageLimit = 0,
        };

        Assert.Null(model.MonthlyResetPeriodConfiguration);
        Assert.False(model.RawData.ContainsKey("monthlyResetPeriodConfiguration"));
        Assert.Null(model.WeeklyResetPeriodConfiguration);
        Assert.False(model.RawData.ContainsKey("weeklyResetPeriodConfiguration"));
        Assert.Null(model.YearlyResetPeriodConfiguration);
        Assert.False(model.RawData.ContainsKey("yearlyResetPeriodConfiguration"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new SubscriptionProvisionParamsEntitlementFeature
        {
            ID = "id",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            ResetPeriod = SubscriptionProvisionParamsEntitlementFeatureResetPeriod.Year,
            UsageLimit = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SubscriptionProvisionParamsEntitlementFeature
        {
            ID = "id",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            ResetPeriod = SubscriptionProvisionParamsEntitlementFeatureResetPeriod.Year,
            UsageLimit = 0,

            MonthlyResetPeriodConfiguration = null,
            WeeklyResetPeriodConfiguration = null,
            YearlyResetPeriodConfiguration = null,
        };

        Assert.Null(model.MonthlyResetPeriodConfiguration);
        Assert.True(model.RawData.ContainsKey("monthlyResetPeriodConfiguration"));
        Assert.Null(model.WeeklyResetPeriodConfiguration);
        Assert.True(model.RawData.ContainsKey("weeklyResetPeriodConfiguration"));
        Assert.Null(model.YearlyResetPeriodConfiguration);
        Assert.True(model.RawData.ContainsKey("yearlyResetPeriodConfiguration"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SubscriptionProvisionParamsEntitlementFeature
        {
            ID = "id",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            ResetPeriod = SubscriptionProvisionParamsEntitlementFeatureResetPeriod.Year,
            UsageLimit = 0,

            MonthlyResetPeriodConfiguration = null,
            WeeklyResetPeriodConfiguration = null,
            YearlyResetPeriodConfiguration = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionProvisionParamsEntitlementFeature
        {
            ID = "id",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            MonthlyResetPeriodConfiguration = new(
                SubscriptionProvisionParamsEntitlementFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            ResetPeriod = SubscriptionProvisionParamsEntitlementFeatureResetPeriod.Year,
            UsageLimit = 0,
            WeeklyResetPeriodConfiguration = new(
                SubscriptionProvisionParamsEntitlementFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                SubscriptionProvisionParamsEntitlementFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };

        SubscriptionProvisionParamsEntitlementFeature copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionProvisionParamsEntitlementFeatureMonthlyResetPeriodConfigurationTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionProvisionParamsEntitlementFeatureMonthlyResetPeriodConfiguration
        {
            AccordingTo =
                SubscriptionProvisionParamsEntitlementFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        ApiEnum<
            string,
            SubscriptionProvisionParamsEntitlementFeatureMonthlyResetPeriodConfigurationAccordingTo
        > expectedAccordingTo =
            SubscriptionProvisionParamsEntitlementFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, model.AccordingTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionProvisionParamsEntitlementFeatureMonthlyResetPeriodConfiguration
        {
            AccordingTo =
                SubscriptionProvisionParamsEntitlementFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionProvisionParamsEntitlementFeatureMonthlyResetPeriodConfiguration>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionProvisionParamsEntitlementFeatureMonthlyResetPeriodConfiguration
        {
            AccordingTo =
                SubscriptionProvisionParamsEntitlementFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionProvisionParamsEntitlementFeatureMonthlyResetPeriodConfiguration>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            SubscriptionProvisionParamsEntitlementFeatureMonthlyResetPeriodConfigurationAccordingTo
        > expectedAccordingTo =
            SubscriptionProvisionParamsEntitlementFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, deserialized.AccordingTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionProvisionParamsEntitlementFeatureMonthlyResetPeriodConfiguration
        {
            AccordingTo =
                SubscriptionProvisionParamsEntitlementFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionProvisionParamsEntitlementFeatureMonthlyResetPeriodConfiguration
        {
            AccordingTo =
                SubscriptionProvisionParamsEntitlementFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        SubscriptionProvisionParamsEntitlementFeatureMonthlyResetPeriodConfiguration copied = new(
            model
        );

        Assert.Equal(model, copied);
    }
}

public class SubscriptionProvisionParamsEntitlementFeatureMonthlyResetPeriodConfigurationAccordingToTest
    : TestBase
{
    [Theory]
    [InlineData(
        SubscriptionProvisionParamsEntitlementFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
    )]
    [InlineData(
        SubscriptionProvisionParamsEntitlementFeatureMonthlyResetPeriodConfigurationAccordingTo.StartOfTheMonth
    )]
    public void Validation_Works(
        SubscriptionProvisionParamsEntitlementFeatureMonthlyResetPeriodConfigurationAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            SubscriptionProvisionParamsEntitlementFeatureMonthlyResetPeriodConfigurationAccordingTo
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                SubscriptionProvisionParamsEntitlementFeatureMonthlyResetPeriodConfigurationAccordingTo
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        SubscriptionProvisionParamsEntitlementFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
    )]
    [InlineData(
        SubscriptionProvisionParamsEntitlementFeatureMonthlyResetPeriodConfigurationAccordingTo.StartOfTheMonth
    )]
    public void SerializationRoundtrip_Works(
        SubscriptionProvisionParamsEntitlementFeatureMonthlyResetPeriodConfigurationAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            SubscriptionProvisionParamsEntitlementFeatureMonthlyResetPeriodConfigurationAccordingTo
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                SubscriptionProvisionParamsEntitlementFeatureMonthlyResetPeriodConfigurationAccordingTo
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
                SubscriptionProvisionParamsEntitlementFeatureMonthlyResetPeriodConfigurationAccordingTo
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                SubscriptionProvisionParamsEntitlementFeatureMonthlyResetPeriodConfigurationAccordingTo
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionProvisionParamsEntitlementFeatureResetPeriodTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionProvisionParamsEntitlementFeatureResetPeriod.Year)]
    [InlineData(SubscriptionProvisionParamsEntitlementFeatureResetPeriod.Month)]
    [InlineData(SubscriptionProvisionParamsEntitlementFeatureResetPeriod.Week)]
    [InlineData(SubscriptionProvisionParamsEntitlementFeatureResetPeriod.Day)]
    [InlineData(SubscriptionProvisionParamsEntitlementFeatureResetPeriod.Hour)]
    public void Validation_Works(SubscriptionProvisionParamsEntitlementFeatureResetPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionProvisionParamsEntitlementFeatureResetPeriod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionParamsEntitlementFeatureResetPeriod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionProvisionParamsEntitlementFeatureResetPeriod.Year)]
    [InlineData(SubscriptionProvisionParamsEntitlementFeatureResetPeriod.Month)]
    [InlineData(SubscriptionProvisionParamsEntitlementFeatureResetPeriod.Week)]
    [InlineData(SubscriptionProvisionParamsEntitlementFeatureResetPeriod.Day)]
    [InlineData(SubscriptionProvisionParamsEntitlementFeatureResetPeriod.Hour)]
    public void SerializationRoundtrip_Works(
        SubscriptionProvisionParamsEntitlementFeatureResetPeriod rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionProvisionParamsEntitlementFeatureResetPeriod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionParamsEntitlementFeatureResetPeriod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionParamsEntitlementFeatureResetPeriod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionParamsEntitlementFeatureResetPeriod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionProvisionParamsEntitlementFeatureWeeklyResetPeriodConfigurationTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionProvisionParamsEntitlementFeatureWeeklyResetPeriodConfiguration
        {
            AccordingTo =
                SubscriptionProvisionParamsEntitlementFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        ApiEnum<
            string,
            SubscriptionProvisionParamsEntitlementFeatureWeeklyResetPeriodConfigurationAccordingTo
        > expectedAccordingTo =
            SubscriptionProvisionParamsEntitlementFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, model.AccordingTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionProvisionParamsEntitlementFeatureWeeklyResetPeriodConfiguration
        {
            AccordingTo =
                SubscriptionProvisionParamsEntitlementFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionProvisionParamsEntitlementFeatureWeeklyResetPeriodConfiguration>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionProvisionParamsEntitlementFeatureWeeklyResetPeriodConfiguration
        {
            AccordingTo =
                SubscriptionProvisionParamsEntitlementFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionProvisionParamsEntitlementFeatureWeeklyResetPeriodConfiguration>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            SubscriptionProvisionParamsEntitlementFeatureWeeklyResetPeriodConfigurationAccordingTo
        > expectedAccordingTo =
            SubscriptionProvisionParamsEntitlementFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, deserialized.AccordingTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionProvisionParamsEntitlementFeatureWeeklyResetPeriodConfiguration
        {
            AccordingTo =
                SubscriptionProvisionParamsEntitlementFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionProvisionParamsEntitlementFeatureWeeklyResetPeriodConfiguration
        {
            AccordingTo =
                SubscriptionProvisionParamsEntitlementFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        SubscriptionProvisionParamsEntitlementFeatureWeeklyResetPeriodConfiguration copied = new(
            model
        );

        Assert.Equal(model, copied);
    }
}

public class SubscriptionProvisionParamsEntitlementFeatureWeeklyResetPeriodConfigurationAccordingToTest
    : TestBase
{
    [Theory]
    [InlineData(
        SubscriptionProvisionParamsEntitlementFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
    )]
    [InlineData(
        SubscriptionProvisionParamsEntitlementFeatureWeeklyResetPeriodConfigurationAccordingTo.EverySunday
    )]
    [InlineData(
        SubscriptionProvisionParamsEntitlementFeatureWeeklyResetPeriodConfigurationAccordingTo.EveryMonday
    )]
    [InlineData(
        SubscriptionProvisionParamsEntitlementFeatureWeeklyResetPeriodConfigurationAccordingTo.EveryTuesday
    )]
    [InlineData(
        SubscriptionProvisionParamsEntitlementFeatureWeeklyResetPeriodConfigurationAccordingTo.EveryWednesday
    )]
    [InlineData(
        SubscriptionProvisionParamsEntitlementFeatureWeeklyResetPeriodConfigurationAccordingTo.EveryThursday
    )]
    [InlineData(
        SubscriptionProvisionParamsEntitlementFeatureWeeklyResetPeriodConfigurationAccordingTo.EveryFriday
    )]
    [InlineData(
        SubscriptionProvisionParamsEntitlementFeatureWeeklyResetPeriodConfigurationAccordingTo.EverySaturday
    )]
    public void Validation_Works(
        SubscriptionProvisionParamsEntitlementFeatureWeeklyResetPeriodConfigurationAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            SubscriptionProvisionParamsEntitlementFeatureWeeklyResetPeriodConfigurationAccordingTo
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                SubscriptionProvisionParamsEntitlementFeatureWeeklyResetPeriodConfigurationAccordingTo
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        SubscriptionProvisionParamsEntitlementFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
    )]
    [InlineData(
        SubscriptionProvisionParamsEntitlementFeatureWeeklyResetPeriodConfigurationAccordingTo.EverySunday
    )]
    [InlineData(
        SubscriptionProvisionParamsEntitlementFeatureWeeklyResetPeriodConfigurationAccordingTo.EveryMonday
    )]
    [InlineData(
        SubscriptionProvisionParamsEntitlementFeatureWeeklyResetPeriodConfigurationAccordingTo.EveryTuesday
    )]
    [InlineData(
        SubscriptionProvisionParamsEntitlementFeatureWeeklyResetPeriodConfigurationAccordingTo.EveryWednesday
    )]
    [InlineData(
        SubscriptionProvisionParamsEntitlementFeatureWeeklyResetPeriodConfigurationAccordingTo.EveryThursday
    )]
    [InlineData(
        SubscriptionProvisionParamsEntitlementFeatureWeeklyResetPeriodConfigurationAccordingTo.EveryFriday
    )]
    [InlineData(
        SubscriptionProvisionParamsEntitlementFeatureWeeklyResetPeriodConfigurationAccordingTo.EverySaturday
    )]
    public void SerializationRoundtrip_Works(
        SubscriptionProvisionParamsEntitlementFeatureWeeklyResetPeriodConfigurationAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            SubscriptionProvisionParamsEntitlementFeatureWeeklyResetPeriodConfigurationAccordingTo
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                SubscriptionProvisionParamsEntitlementFeatureWeeklyResetPeriodConfigurationAccordingTo
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
                SubscriptionProvisionParamsEntitlementFeatureWeeklyResetPeriodConfigurationAccordingTo
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                SubscriptionProvisionParamsEntitlementFeatureWeeklyResetPeriodConfigurationAccordingTo
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionProvisionParamsEntitlementFeatureYearlyResetPeriodConfigurationTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionProvisionParamsEntitlementFeatureYearlyResetPeriodConfiguration
        {
            AccordingTo =
                SubscriptionProvisionParamsEntitlementFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        ApiEnum<
            string,
            SubscriptionProvisionParamsEntitlementFeatureYearlyResetPeriodConfigurationAccordingTo
        > expectedAccordingTo =
            SubscriptionProvisionParamsEntitlementFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, model.AccordingTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionProvisionParamsEntitlementFeatureYearlyResetPeriodConfiguration
        {
            AccordingTo =
                SubscriptionProvisionParamsEntitlementFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionProvisionParamsEntitlementFeatureYearlyResetPeriodConfiguration>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionProvisionParamsEntitlementFeatureYearlyResetPeriodConfiguration
        {
            AccordingTo =
                SubscriptionProvisionParamsEntitlementFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionProvisionParamsEntitlementFeatureYearlyResetPeriodConfiguration>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            SubscriptionProvisionParamsEntitlementFeatureYearlyResetPeriodConfigurationAccordingTo
        > expectedAccordingTo =
            SubscriptionProvisionParamsEntitlementFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, deserialized.AccordingTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionProvisionParamsEntitlementFeatureYearlyResetPeriodConfiguration
        {
            AccordingTo =
                SubscriptionProvisionParamsEntitlementFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionProvisionParamsEntitlementFeatureYearlyResetPeriodConfiguration
        {
            AccordingTo =
                SubscriptionProvisionParamsEntitlementFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        SubscriptionProvisionParamsEntitlementFeatureYearlyResetPeriodConfiguration copied = new(
            model
        );

        Assert.Equal(model, copied);
    }
}

public class SubscriptionProvisionParamsEntitlementFeatureYearlyResetPeriodConfigurationAccordingToTest
    : TestBase
{
    [Theory]
    [InlineData(
        SubscriptionProvisionParamsEntitlementFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
    )]
    public void Validation_Works(
        SubscriptionProvisionParamsEntitlementFeatureYearlyResetPeriodConfigurationAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            SubscriptionProvisionParamsEntitlementFeatureYearlyResetPeriodConfigurationAccordingTo
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                SubscriptionProvisionParamsEntitlementFeatureYearlyResetPeriodConfigurationAccordingTo
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        SubscriptionProvisionParamsEntitlementFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
    )]
    public void SerializationRoundtrip_Works(
        SubscriptionProvisionParamsEntitlementFeatureYearlyResetPeriodConfigurationAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            SubscriptionProvisionParamsEntitlementFeatureYearlyResetPeriodConfigurationAccordingTo
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                SubscriptionProvisionParamsEntitlementFeatureYearlyResetPeriodConfigurationAccordingTo
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
                SubscriptionProvisionParamsEntitlementFeatureYearlyResetPeriodConfigurationAccordingTo
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                SubscriptionProvisionParamsEntitlementFeatureYearlyResetPeriodConfigurationAccordingTo
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionProvisionParamsEntitlementCreditTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionProvisionParamsEntitlementCredit
        {
            ID = "id",
            Amount = 1,
            Cadence = SubscriptionProvisionParamsEntitlementCreditCadence.Month,
        };

        string expectedID = "id";
        double expectedAmount = 1;
        ApiEnum<string, SubscriptionProvisionParamsEntitlementCreditCadence> expectedCadence =
            SubscriptionProvisionParamsEntitlementCreditCadence.Month;
        JsonElement expectedType = JsonSerializer.SerializeToElement("CREDIT");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCadence, model.Cadence);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionProvisionParamsEntitlementCredit
        {
            ID = "id",
            Amount = 1,
            Cadence = SubscriptionProvisionParamsEntitlementCreditCadence.Month,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionProvisionParamsEntitlementCredit>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionProvisionParamsEntitlementCredit
        {
            ID = "id",
            Amount = 1,
            Cadence = SubscriptionProvisionParamsEntitlementCreditCadence.Month,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionProvisionParamsEntitlementCredit>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        double expectedAmount = 1;
        ApiEnum<string, SubscriptionProvisionParamsEntitlementCreditCadence> expectedCadence =
            SubscriptionProvisionParamsEntitlementCreditCadence.Month;
        JsonElement expectedType = JsonSerializer.SerializeToElement("CREDIT");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCadence, deserialized.Cadence);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionProvisionParamsEntitlementCredit
        {
            ID = "id",
            Amount = 1,
            Cadence = SubscriptionProvisionParamsEntitlementCreditCadence.Month,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionProvisionParamsEntitlementCredit
        {
            ID = "id",
            Amount = 1,
            Cadence = SubscriptionProvisionParamsEntitlementCreditCadence.Month,
        };

        SubscriptionProvisionParamsEntitlementCredit copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionProvisionParamsEntitlementCreditCadenceTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionProvisionParamsEntitlementCreditCadence.Month)]
    [InlineData(SubscriptionProvisionParamsEntitlementCreditCadence.Year)]
    public void Validation_Works(SubscriptionProvisionParamsEntitlementCreditCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionProvisionParamsEntitlementCreditCadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionParamsEntitlementCreditCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionProvisionParamsEntitlementCreditCadence.Month)]
    [InlineData(SubscriptionProvisionParamsEntitlementCreditCadence.Year)]
    public void SerializationRoundtrip_Works(
        SubscriptionProvisionParamsEntitlementCreditCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionProvisionParamsEntitlementCreditCadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionParamsEntitlementCreditCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionParamsEntitlementCreditCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionParamsEntitlementCreditCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionProvisionParamsMinimumSpendTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionProvisionParamsMinimumSpend
        {
            Amount = 0,
            Currency = SubscriptionProvisionParamsMinimumSpendCurrency.Usd,
        };

        double expectedAmount = 0;
        ApiEnum<string, SubscriptionProvisionParamsMinimumSpendCurrency> expectedCurrency =
            SubscriptionProvisionParamsMinimumSpendCurrency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionProvisionParamsMinimumSpend
        {
            Amount = 0,
            Currency = SubscriptionProvisionParamsMinimumSpendCurrency.Usd,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionProvisionParamsMinimumSpend>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionProvisionParamsMinimumSpend
        {
            Amount = 0,
            Currency = SubscriptionProvisionParamsMinimumSpendCurrency.Usd,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionProvisionParamsMinimumSpend>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        ApiEnum<string, SubscriptionProvisionParamsMinimumSpendCurrency> expectedCurrency =
            SubscriptionProvisionParamsMinimumSpendCurrency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionProvisionParamsMinimumSpend
        {
            Amount = 0,
            Currency = SubscriptionProvisionParamsMinimumSpendCurrency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubscriptionProvisionParamsMinimumSpend { };

        Assert.Null(model.Amount);
        Assert.False(model.RawData.ContainsKey("amount"));
        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SubscriptionProvisionParamsMinimumSpend { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SubscriptionProvisionParamsMinimumSpend
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
        var model = new SubscriptionProvisionParamsMinimumSpend
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
        var model = new SubscriptionProvisionParamsMinimumSpend
        {
            Amount = 0,
            Currency = SubscriptionProvisionParamsMinimumSpendCurrency.Usd,
        };

        SubscriptionProvisionParamsMinimumSpend copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionProvisionParamsMinimumSpendCurrencyTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Usd)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Aed)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.All)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Amd)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Ang)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Aud)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Awg)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Azn)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Bam)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Bbd)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Bdt)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Bgn)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Bif)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Bmd)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Bnd)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Bsd)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Bwp)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Byn)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Bzd)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Brl)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Cad)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Cdf)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Chf)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Cny)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Czk)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Dkk)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Dop)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Dzd)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Egp)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Etb)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Eur)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Fjd)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Gbp)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Gel)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Gip)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Gmd)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Gyd)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Hkd)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Hrk)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Htg)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Idr)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Ils)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Inr)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Isk)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Jmd)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Jpy)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Kes)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Kgs)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Khr)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Kmf)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Krw)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Kyd)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Kzt)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Lbp)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Lkr)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Lrd)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Lsl)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Mad)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Mdl)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Mga)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Mkd)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Mmk)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Mnt)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Mop)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Mro)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Mvr)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Mwk)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Mxn)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Myr)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Mzn)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Nad)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Ngn)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Nok)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Npr)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Nzd)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Pgk)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Php)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Pkr)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Pln)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Qar)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Ron)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Rsd)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Rub)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Rwf)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Sar)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Sbd)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Scr)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Sek)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Sgd)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Sle)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Sll)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Sos)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Szl)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Thb)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Tjs)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Top)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Try)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Ttd)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Tzs)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Uah)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Uzs)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Vnd)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Vuv)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Wst)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Xaf)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Xcd)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Yer)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Zar)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Zmw)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Clp)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Djf)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Gnf)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Ugx)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Pyg)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Xof)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Xpf)]
    public void Validation_Works(SubscriptionProvisionParamsMinimumSpendCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionProvisionParamsMinimumSpendCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionParamsMinimumSpendCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Usd)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Aed)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.All)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Amd)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Ang)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Aud)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Awg)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Azn)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Bam)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Bbd)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Bdt)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Bgn)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Bif)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Bmd)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Bnd)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Bsd)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Bwp)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Byn)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Bzd)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Brl)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Cad)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Cdf)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Chf)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Cny)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Czk)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Dkk)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Dop)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Dzd)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Egp)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Etb)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Eur)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Fjd)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Gbp)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Gel)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Gip)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Gmd)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Gyd)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Hkd)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Hrk)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Htg)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Idr)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Ils)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Inr)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Isk)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Jmd)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Jpy)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Kes)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Kgs)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Khr)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Kmf)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Krw)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Kyd)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Kzt)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Lbp)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Lkr)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Lrd)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Lsl)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Mad)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Mdl)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Mga)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Mkd)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Mmk)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Mnt)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Mop)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Mro)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Mvr)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Mwk)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Mxn)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Myr)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Mzn)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Nad)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Ngn)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Nok)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Npr)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Nzd)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Pgk)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Php)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Pkr)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Pln)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Qar)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Ron)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Rsd)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Rub)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Rwf)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Sar)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Sbd)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Scr)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Sek)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Sgd)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Sle)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Sll)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Sos)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Szl)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Thb)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Tjs)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Top)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Try)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Ttd)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Tzs)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Uah)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Uzs)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Vnd)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Vuv)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Wst)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Xaf)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Xcd)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Yer)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Zar)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Zmw)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Clp)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Djf)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Gnf)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Ugx)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Pyg)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Xof)]
    [InlineData(SubscriptionProvisionParamsMinimumSpendCurrency.Xpf)]
    public void SerializationRoundtrip_Works(
        SubscriptionProvisionParamsMinimumSpendCurrency rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionProvisionParamsMinimumSpendCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionParamsMinimumSpendCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionParamsMinimumSpendCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionParamsMinimumSpendCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PaymentCollectionMethodTest : TestBase
{
    [Theory]
    [InlineData(PaymentCollectionMethod.Charge)]
    [InlineData(PaymentCollectionMethod.Invoice)]
    [InlineData(PaymentCollectionMethod.None)]
    public void Validation_Works(PaymentCollectionMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PaymentCollectionMethod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PaymentCollectionMethod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PaymentCollectionMethod.Charge)]
    [InlineData(PaymentCollectionMethod.Invoice)]
    [InlineData(PaymentCollectionMethod.None)]
    public void SerializationRoundtrip_Works(PaymentCollectionMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PaymentCollectionMethod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PaymentCollectionMethod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PaymentCollectionMethod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PaymentCollectionMethod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionProvisionParamsPriceOverrideTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionProvisionParamsPriceOverride
        {
            AddonID = "addonId",
            Amount = 0,
            BaseCharge = true,
            BillingCountryCode = "billingCountryCode",
            BlockSize = 0,
            CreditGrantCadence = CreditGrantCadence.BeginningOfBillingPeriod,
            CreditRate = new()
            {
                Amount = 1,
                CurrencyID = "currencyId",
                CostFormula = "costFormula",
            },
            Currency = SubscriptionProvisionParamsPriceOverrideCurrency.Usd,
            FeatureID = "featureId",
            Tiers =
            [
                new()
                {
                    FlatPrice = new() { Amount = 0, Currency = FlatPriceCurrency.Usd },
                    UnitPrice = new() { Amount = 0, Currency = UnitPriceCurrency.Usd },
                    UpTo = 0,
                },
            ],
        };

        string expectedAddonID = "addonId";
        double expectedAmount = 0;
        bool expectedBaseCharge = true;
        string expectedBillingCountryCode = "billingCountryCode";
        double expectedBlockSize = 0;
        ApiEnum<string, CreditGrantCadence> expectedCreditGrantCadence =
            CreditGrantCadence.BeginningOfBillingPeriod;
        CreditRate expectedCreditRate = new()
        {
            Amount = 1,
            CurrencyID = "currencyId",
            CostFormula = "costFormula",
        };
        ApiEnum<string, SubscriptionProvisionParamsPriceOverrideCurrency> expectedCurrency =
            SubscriptionProvisionParamsPriceOverrideCurrency.Usd;
        string expectedFeatureID = "featureId";
        List<Tier> expectedTiers =
        [
            new()
            {
                FlatPrice = new() { Amount = 0, Currency = FlatPriceCurrency.Usd },
                UnitPrice = new() { Amount = 0, Currency = UnitPriceCurrency.Usd },
                UpTo = 0,
            },
        ];

        Assert.Equal(expectedAddonID, model.AddonID);
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedBaseCharge, model.BaseCharge);
        Assert.Equal(expectedBillingCountryCode, model.BillingCountryCode);
        Assert.Equal(expectedBlockSize, model.BlockSize);
        Assert.Equal(expectedCreditGrantCadence, model.CreditGrantCadence);
        Assert.Equal(expectedCreditRate, model.CreditRate);
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
        var model = new SubscriptionProvisionParamsPriceOverride
        {
            AddonID = "addonId",
            Amount = 0,
            BaseCharge = true,
            BillingCountryCode = "billingCountryCode",
            BlockSize = 0,
            CreditGrantCadence = CreditGrantCadence.BeginningOfBillingPeriod,
            CreditRate = new()
            {
                Amount = 1,
                CurrencyID = "currencyId",
                CostFormula = "costFormula",
            },
            Currency = SubscriptionProvisionParamsPriceOverrideCurrency.Usd,
            FeatureID = "featureId",
            Tiers =
            [
                new()
                {
                    FlatPrice = new() { Amount = 0, Currency = FlatPriceCurrency.Usd },
                    UnitPrice = new() { Amount = 0, Currency = UnitPriceCurrency.Usd },
                    UpTo = 0,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionProvisionParamsPriceOverride>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionProvisionParamsPriceOverride
        {
            AddonID = "addonId",
            Amount = 0,
            BaseCharge = true,
            BillingCountryCode = "billingCountryCode",
            BlockSize = 0,
            CreditGrantCadence = CreditGrantCadence.BeginningOfBillingPeriod,
            CreditRate = new()
            {
                Amount = 1,
                CurrencyID = "currencyId",
                CostFormula = "costFormula",
            },
            Currency = SubscriptionProvisionParamsPriceOverrideCurrency.Usd,
            FeatureID = "featureId",
            Tiers =
            [
                new()
                {
                    FlatPrice = new() { Amount = 0, Currency = FlatPriceCurrency.Usd },
                    UnitPrice = new() { Amount = 0, Currency = UnitPriceCurrency.Usd },
                    UpTo = 0,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionProvisionParamsPriceOverride>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAddonID = "addonId";
        double expectedAmount = 0;
        bool expectedBaseCharge = true;
        string expectedBillingCountryCode = "billingCountryCode";
        double expectedBlockSize = 0;
        ApiEnum<string, CreditGrantCadence> expectedCreditGrantCadence =
            CreditGrantCadence.BeginningOfBillingPeriod;
        CreditRate expectedCreditRate = new()
        {
            Amount = 1,
            CurrencyID = "currencyId",
            CostFormula = "costFormula",
        };
        ApiEnum<string, SubscriptionProvisionParamsPriceOverrideCurrency> expectedCurrency =
            SubscriptionProvisionParamsPriceOverrideCurrency.Usd;
        string expectedFeatureID = "featureId";
        List<Tier> expectedTiers =
        [
            new()
            {
                FlatPrice = new() { Amount = 0, Currency = FlatPriceCurrency.Usd },
                UnitPrice = new() { Amount = 0, Currency = UnitPriceCurrency.Usd },
                UpTo = 0,
            },
        ];

        Assert.Equal(expectedAddonID, deserialized.AddonID);
        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedBaseCharge, deserialized.BaseCharge);
        Assert.Equal(expectedBillingCountryCode, deserialized.BillingCountryCode);
        Assert.Equal(expectedBlockSize, deserialized.BlockSize);
        Assert.Equal(expectedCreditGrantCadence, deserialized.CreditGrantCadence);
        Assert.Equal(expectedCreditRate, deserialized.CreditRate);
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
        var model = new SubscriptionProvisionParamsPriceOverride
        {
            AddonID = "addonId",
            Amount = 0,
            BaseCharge = true,
            BillingCountryCode = "billingCountryCode",
            BlockSize = 0,
            CreditGrantCadence = CreditGrantCadence.BeginningOfBillingPeriod,
            CreditRate = new()
            {
                Amount = 1,
                CurrencyID = "currencyId",
                CostFormula = "costFormula",
            },
            Currency = SubscriptionProvisionParamsPriceOverrideCurrency.Usd,
            FeatureID = "featureId",
            Tiers =
            [
                new()
                {
                    FlatPrice = new() { Amount = 0, Currency = FlatPriceCurrency.Usd },
                    UnitPrice = new() { Amount = 0, Currency = UnitPriceCurrency.Usd },
                    UpTo = 0,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubscriptionProvisionParamsPriceOverride
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
        Assert.Null(model.CreditGrantCadence);
        Assert.False(model.RawData.ContainsKey("creditGrantCadence"));
        Assert.Null(model.CreditRate);
        Assert.False(model.RawData.ContainsKey("creditRate"));
        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
        Assert.Null(model.Tiers);
        Assert.False(model.RawData.ContainsKey("tiers"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SubscriptionProvisionParamsPriceOverride
        {
            AddonID = "addonId",
            FeatureID = "featureId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SubscriptionProvisionParamsPriceOverride
        {
            AddonID = "addonId",
            FeatureID = "featureId",

            // Null should be interpreted as omitted for these properties
            Amount = null,
            BaseCharge = null,
            BillingCountryCode = null,
            BlockSize = null,
            CreditGrantCadence = null,
            CreditRate = null,
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
        Assert.Null(model.CreditGrantCadence);
        Assert.False(model.RawData.ContainsKey("creditGrantCadence"));
        Assert.Null(model.CreditRate);
        Assert.False(model.RawData.ContainsKey("creditRate"));
        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
        Assert.Null(model.Tiers);
        Assert.False(model.RawData.ContainsKey("tiers"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SubscriptionProvisionParamsPriceOverride
        {
            AddonID = "addonId",
            FeatureID = "featureId",

            // Null should be interpreted as omitted for these properties
            Amount = null,
            BaseCharge = null,
            BillingCountryCode = null,
            BlockSize = null,
            CreditGrantCadence = null,
            CreditRate = null,
            Currency = null,
            Tiers = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubscriptionProvisionParamsPriceOverride
        {
            Amount = 0,
            BaseCharge = true,
            BillingCountryCode = "billingCountryCode",
            BlockSize = 0,
            CreditGrantCadence = CreditGrantCadence.BeginningOfBillingPeriod,
            CreditRate = new()
            {
                Amount = 1,
                CurrencyID = "currencyId",
                CostFormula = "costFormula",
            },
            Currency = SubscriptionProvisionParamsPriceOverrideCurrency.Usd,
            Tiers =
            [
                new()
                {
                    FlatPrice = new() { Amount = 0, Currency = FlatPriceCurrency.Usd },
                    UnitPrice = new() { Amount = 0, Currency = UnitPriceCurrency.Usd },
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
        var model = new SubscriptionProvisionParamsPriceOverride
        {
            Amount = 0,
            BaseCharge = true,
            BillingCountryCode = "billingCountryCode",
            BlockSize = 0,
            CreditGrantCadence = CreditGrantCadence.BeginningOfBillingPeriod,
            CreditRate = new()
            {
                Amount = 1,
                CurrencyID = "currencyId",
                CostFormula = "costFormula",
            },
            Currency = SubscriptionProvisionParamsPriceOverrideCurrency.Usd,
            Tiers =
            [
                new()
                {
                    FlatPrice = new() { Amount = 0, Currency = FlatPriceCurrency.Usd },
                    UnitPrice = new() { Amount = 0, Currency = UnitPriceCurrency.Usd },
                    UpTo = 0,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SubscriptionProvisionParamsPriceOverride
        {
            Amount = 0,
            BaseCharge = true,
            BillingCountryCode = "billingCountryCode",
            BlockSize = 0,
            CreditGrantCadence = CreditGrantCadence.BeginningOfBillingPeriod,
            CreditRate = new()
            {
                Amount = 1,
                CurrencyID = "currencyId",
                CostFormula = "costFormula",
            },
            Currency = SubscriptionProvisionParamsPriceOverrideCurrency.Usd,
            Tiers =
            [
                new()
                {
                    FlatPrice = new() { Amount = 0, Currency = FlatPriceCurrency.Usd },
                    UnitPrice = new() { Amount = 0, Currency = UnitPriceCurrency.Usd },
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
        var model = new SubscriptionProvisionParamsPriceOverride
        {
            Amount = 0,
            BaseCharge = true,
            BillingCountryCode = "billingCountryCode",
            BlockSize = 0,
            CreditGrantCadence = CreditGrantCadence.BeginningOfBillingPeriod,
            CreditRate = new()
            {
                Amount = 1,
                CurrencyID = "currencyId",
                CostFormula = "costFormula",
            },
            Currency = SubscriptionProvisionParamsPriceOverrideCurrency.Usd,
            Tiers =
            [
                new()
                {
                    FlatPrice = new() { Amount = 0, Currency = FlatPriceCurrency.Usd },
                    UnitPrice = new() { Amount = 0, Currency = UnitPriceCurrency.Usd },
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
        var model = new SubscriptionProvisionParamsPriceOverride
        {
            AddonID = "addonId",
            Amount = 0,
            BaseCharge = true,
            BillingCountryCode = "billingCountryCode",
            BlockSize = 0,
            CreditGrantCadence = CreditGrantCadence.BeginningOfBillingPeriod,
            CreditRate = new()
            {
                Amount = 1,
                CurrencyID = "currencyId",
                CostFormula = "costFormula",
            },
            Currency = SubscriptionProvisionParamsPriceOverrideCurrency.Usd,
            FeatureID = "featureId",
            Tiers =
            [
                new()
                {
                    FlatPrice = new() { Amount = 0, Currency = FlatPriceCurrency.Usd },
                    UnitPrice = new() { Amount = 0, Currency = UnitPriceCurrency.Usd },
                    UpTo = 0,
                },
            ],
        };

        SubscriptionProvisionParamsPriceOverride copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CreditGrantCadenceTest : TestBase
{
    [Theory]
    [InlineData(CreditGrantCadence.BeginningOfBillingPeriod)]
    [InlineData(CreditGrantCadence.Monthly)]
    public void Validation_Works(CreditGrantCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreditGrantCadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CreditGrantCadence>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CreditGrantCadence.BeginningOfBillingPeriod)]
    [InlineData(CreditGrantCadence.Monthly)]
    public void SerializationRoundtrip_Works(CreditGrantCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreditGrantCadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CreditGrantCadence>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CreditGrantCadence>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CreditGrantCadence>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CreditRateTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CreditRate
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
        var model = new CreditRate
        {
            Amount = 1,
            CurrencyID = "currencyId",
            CostFormula = "costFormula",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditRate>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CreditRate
        {
            Amount = 1,
            CurrencyID = "currencyId",
            CostFormula = "costFormula",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditRate>(
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
        var model = new CreditRate
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
        var model = new CreditRate { Amount = 1, CurrencyID = "currencyId" };

        Assert.Null(model.CostFormula);
        Assert.False(model.RawData.ContainsKey("costFormula"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CreditRate { Amount = 1, CurrencyID = "currencyId" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CreditRate
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
        var model = new CreditRate
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
        var model = new CreditRate
        {
            Amount = 1,
            CurrencyID = "currencyId",
            CostFormula = "costFormula",
        };

        CreditRate copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionProvisionParamsPriceOverrideCurrencyTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Usd)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Aed)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.All)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Amd)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Ang)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Aud)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Awg)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Azn)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Bam)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Bbd)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Bdt)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Bgn)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Bif)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Bmd)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Bnd)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Bsd)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Bwp)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Byn)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Bzd)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Brl)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Cad)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Cdf)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Chf)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Cny)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Czk)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Dkk)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Dop)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Dzd)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Egp)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Etb)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Eur)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Fjd)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Gbp)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Gel)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Gip)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Gmd)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Gyd)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Hkd)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Hrk)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Htg)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Idr)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Ils)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Inr)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Isk)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Jmd)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Jpy)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Kes)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Kgs)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Khr)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Kmf)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Krw)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Kyd)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Kzt)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Lbp)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Lkr)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Lrd)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Lsl)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Mad)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Mdl)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Mga)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Mkd)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Mmk)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Mnt)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Mop)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Mro)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Mvr)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Mwk)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Mxn)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Myr)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Mzn)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Nad)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Ngn)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Nok)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Npr)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Nzd)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Pgk)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Php)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Pkr)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Pln)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Qar)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Ron)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Rsd)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Rub)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Rwf)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Sar)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Sbd)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Scr)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Sek)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Sgd)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Sle)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Sll)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Sos)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Szl)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Thb)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Tjs)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Top)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Try)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Ttd)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Tzs)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Uah)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Uzs)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Vnd)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Vuv)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Wst)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Xaf)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Xcd)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Yer)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Zar)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Zmw)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Clp)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Djf)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Gnf)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Ugx)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Pyg)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Xof)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Xpf)]
    public void Validation_Works(SubscriptionProvisionParamsPriceOverrideCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionProvisionParamsPriceOverrideCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionParamsPriceOverrideCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Usd)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Aed)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.All)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Amd)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Ang)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Aud)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Awg)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Azn)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Bam)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Bbd)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Bdt)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Bgn)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Bif)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Bmd)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Bnd)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Bsd)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Bwp)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Byn)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Bzd)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Brl)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Cad)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Cdf)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Chf)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Cny)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Czk)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Dkk)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Dop)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Dzd)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Egp)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Etb)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Eur)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Fjd)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Gbp)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Gel)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Gip)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Gmd)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Gyd)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Hkd)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Hrk)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Htg)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Idr)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Ils)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Inr)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Isk)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Jmd)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Jpy)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Kes)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Kgs)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Khr)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Kmf)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Krw)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Kyd)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Kzt)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Lbp)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Lkr)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Lrd)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Lsl)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Mad)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Mdl)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Mga)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Mkd)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Mmk)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Mnt)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Mop)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Mro)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Mvr)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Mwk)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Mxn)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Myr)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Mzn)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Nad)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Ngn)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Nok)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Npr)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Nzd)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Pgk)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Php)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Pkr)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Pln)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Qar)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Ron)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Rsd)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Rub)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Rwf)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Sar)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Sbd)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Scr)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Sek)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Sgd)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Sle)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Sll)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Sos)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Szl)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Thb)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Tjs)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Top)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Try)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Ttd)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Tzs)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Uah)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Uzs)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Vnd)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Vuv)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Wst)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Xaf)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Xcd)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Yer)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Zar)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Zmw)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Clp)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Djf)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Gnf)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Ugx)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Pyg)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Xof)]
    [InlineData(SubscriptionProvisionParamsPriceOverrideCurrency.Xpf)]
    public void SerializationRoundtrip_Works(
        SubscriptionProvisionParamsPriceOverrideCurrency rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionProvisionParamsPriceOverrideCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionParamsPriceOverrideCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionParamsPriceOverrideCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionParamsPriceOverrideCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TierTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Tier
        {
            FlatPrice = new() { Amount = 0, Currency = FlatPriceCurrency.Usd },
            UnitPrice = new() { Amount = 0, Currency = UnitPriceCurrency.Usd },
            UpTo = 0,
        };

        FlatPrice expectedFlatPrice = new() { Amount = 0, Currency = FlatPriceCurrency.Usd };
        UnitPrice expectedUnitPrice = new() { Amount = 0, Currency = UnitPriceCurrency.Usd };
        double expectedUpTo = 0;

        Assert.Equal(expectedFlatPrice, model.FlatPrice);
        Assert.Equal(expectedUnitPrice, model.UnitPrice);
        Assert.Equal(expectedUpTo, model.UpTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Tier
        {
            FlatPrice = new() { Amount = 0, Currency = FlatPriceCurrency.Usd },
            UnitPrice = new() { Amount = 0, Currency = UnitPriceCurrency.Usd },
            UpTo = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tier>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Tier
        {
            FlatPrice = new() { Amount = 0, Currency = FlatPriceCurrency.Usd },
            UnitPrice = new() { Amount = 0, Currency = UnitPriceCurrency.Usd },
            UpTo = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tier>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        FlatPrice expectedFlatPrice = new() { Amount = 0, Currency = FlatPriceCurrency.Usd };
        UnitPrice expectedUnitPrice = new() { Amount = 0, Currency = UnitPriceCurrency.Usd };
        double expectedUpTo = 0;

        Assert.Equal(expectedFlatPrice, deserialized.FlatPrice);
        Assert.Equal(expectedUnitPrice, deserialized.UnitPrice);
        Assert.Equal(expectedUpTo, deserialized.UpTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Tier
        {
            FlatPrice = new() { Amount = 0, Currency = FlatPriceCurrency.Usd },
            UnitPrice = new() { Amount = 0, Currency = UnitPriceCurrency.Usd },
            UpTo = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Tier { };

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
        var model = new Tier { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Tier
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
        var model = new Tier
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
        var model = new Tier
        {
            FlatPrice = new() { Amount = 0, Currency = FlatPriceCurrency.Usd },
            UnitPrice = new() { Amount = 0, Currency = UnitPriceCurrency.Usd },
            UpTo = 0,
        };

        Tier copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FlatPriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FlatPrice { Amount = 0, Currency = FlatPriceCurrency.Usd };

        double expectedAmount = 0;
        ApiEnum<string, FlatPriceCurrency> expectedCurrency = FlatPriceCurrency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FlatPrice { Amount = 0, Currency = FlatPriceCurrency.Usd };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FlatPrice>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FlatPrice { Amount = 0, Currency = FlatPriceCurrency.Usd };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FlatPrice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        ApiEnum<string, FlatPriceCurrency> expectedCurrency = FlatPriceCurrency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FlatPrice { Amount = 0, Currency = FlatPriceCurrency.Usd };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FlatPrice { Amount = 0, Currency = FlatPriceCurrency.Usd };

        FlatPrice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FlatPriceCurrencyTest : TestBase
{
    [Theory]
    [InlineData(FlatPriceCurrency.Usd)]
    [InlineData(FlatPriceCurrency.Aed)]
    [InlineData(FlatPriceCurrency.All)]
    [InlineData(FlatPriceCurrency.Amd)]
    [InlineData(FlatPriceCurrency.Ang)]
    [InlineData(FlatPriceCurrency.Aud)]
    [InlineData(FlatPriceCurrency.Awg)]
    [InlineData(FlatPriceCurrency.Azn)]
    [InlineData(FlatPriceCurrency.Bam)]
    [InlineData(FlatPriceCurrency.Bbd)]
    [InlineData(FlatPriceCurrency.Bdt)]
    [InlineData(FlatPriceCurrency.Bgn)]
    [InlineData(FlatPriceCurrency.Bif)]
    [InlineData(FlatPriceCurrency.Bmd)]
    [InlineData(FlatPriceCurrency.Bnd)]
    [InlineData(FlatPriceCurrency.Bsd)]
    [InlineData(FlatPriceCurrency.Bwp)]
    [InlineData(FlatPriceCurrency.Byn)]
    [InlineData(FlatPriceCurrency.Bzd)]
    [InlineData(FlatPriceCurrency.Brl)]
    [InlineData(FlatPriceCurrency.Cad)]
    [InlineData(FlatPriceCurrency.Cdf)]
    [InlineData(FlatPriceCurrency.Chf)]
    [InlineData(FlatPriceCurrency.Cny)]
    [InlineData(FlatPriceCurrency.Czk)]
    [InlineData(FlatPriceCurrency.Dkk)]
    [InlineData(FlatPriceCurrency.Dop)]
    [InlineData(FlatPriceCurrency.Dzd)]
    [InlineData(FlatPriceCurrency.Egp)]
    [InlineData(FlatPriceCurrency.Etb)]
    [InlineData(FlatPriceCurrency.Eur)]
    [InlineData(FlatPriceCurrency.Fjd)]
    [InlineData(FlatPriceCurrency.Gbp)]
    [InlineData(FlatPriceCurrency.Gel)]
    [InlineData(FlatPriceCurrency.Gip)]
    [InlineData(FlatPriceCurrency.Gmd)]
    [InlineData(FlatPriceCurrency.Gyd)]
    [InlineData(FlatPriceCurrency.Hkd)]
    [InlineData(FlatPriceCurrency.Hrk)]
    [InlineData(FlatPriceCurrency.Htg)]
    [InlineData(FlatPriceCurrency.Idr)]
    [InlineData(FlatPriceCurrency.Ils)]
    [InlineData(FlatPriceCurrency.Inr)]
    [InlineData(FlatPriceCurrency.Isk)]
    [InlineData(FlatPriceCurrency.Jmd)]
    [InlineData(FlatPriceCurrency.Jpy)]
    [InlineData(FlatPriceCurrency.Kes)]
    [InlineData(FlatPriceCurrency.Kgs)]
    [InlineData(FlatPriceCurrency.Khr)]
    [InlineData(FlatPriceCurrency.Kmf)]
    [InlineData(FlatPriceCurrency.Krw)]
    [InlineData(FlatPriceCurrency.Kyd)]
    [InlineData(FlatPriceCurrency.Kzt)]
    [InlineData(FlatPriceCurrency.Lbp)]
    [InlineData(FlatPriceCurrency.Lkr)]
    [InlineData(FlatPriceCurrency.Lrd)]
    [InlineData(FlatPriceCurrency.Lsl)]
    [InlineData(FlatPriceCurrency.Mad)]
    [InlineData(FlatPriceCurrency.Mdl)]
    [InlineData(FlatPriceCurrency.Mga)]
    [InlineData(FlatPriceCurrency.Mkd)]
    [InlineData(FlatPriceCurrency.Mmk)]
    [InlineData(FlatPriceCurrency.Mnt)]
    [InlineData(FlatPriceCurrency.Mop)]
    [InlineData(FlatPriceCurrency.Mro)]
    [InlineData(FlatPriceCurrency.Mvr)]
    [InlineData(FlatPriceCurrency.Mwk)]
    [InlineData(FlatPriceCurrency.Mxn)]
    [InlineData(FlatPriceCurrency.Myr)]
    [InlineData(FlatPriceCurrency.Mzn)]
    [InlineData(FlatPriceCurrency.Nad)]
    [InlineData(FlatPriceCurrency.Ngn)]
    [InlineData(FlatPriceCurrency.Nok)]
    [InlineData(FlatPriceCurrency.Npr)]
    [InlineData(FlatPriceCurrency.Nzd)]
    [InlineData(FlatPriceCurrency.Pgk)]
    [InlineData(FlatPriceCurrency.Php)]
    [InlineData(FlatPriceCurrency.Pkr)]
    [InlineData(FlatPriceCurrency.Pln)]
    [InlineData(FlatPriceCurrency.Qar)]
    [InlineData(FlatPriceCurrency.Ron)]
    [InlineData(FlatPriceCurrency.Rsd)]
    [InlineData(FlatPriceCurrency.Rub)]
    [InlineData(FlatPriceCurrency.Rwf)]
    [InlineData(FlatPriceCurrency.Sar)]
    [InlineData(FlatPriceCurrency.Sbd)]
    [InlineData(FlatPriceCurrency.Scr)]
    [InlineData(FlatPriceCurrency.Sek)]
    [InlineData(FlatPriceCurrency.Sgd)]
    [InlineData(FlatPriceCurrency.Sle)]
    [InlineData(FlatPriceCurrency.Sll)]
    [InlineData(FlatPriceCurrency.Sos)]
    [InlineData(FlatPriceCurrency.Szl)]
    [InlineData(FlatPriceCurrency.Thb)]
    [InlineData(FlatPriceCurrency.Tjs)]
    [InlineData(FlatPriceCurrency.Top)]
    [InlineData(FlatPriceCurrency.Try)]
    [InlineData(FlatPriceCurrency.Ttd)]
    [InlineData(FlatPriceCurrency.Tzs)]
    [InlineData(FlatPriceCurrency.Uah)]
    [InlineData(FlatPriceCurrency.Uzs)]
    [InlineData(FlatPriceCurrency.Vnd)]
    [InlineData(FlatPriceCurrency.Vuv)]
    [InlineData(FlatPriceCurrency.Wst)]
    [InlineData(FlatPriceCurrency.Xaf)]
    [InlineData(FlatPriceCurrency.Xcd)]
    [InlineData(FlatPriceCurrency.Yer)]
    [InlineData(FlatPriceCurrency.Zar)]
    [InlineData(FlatPriceCurrency.Zmw)]
    [InlineData(FlatPriceCurrency.Clp)]
    [InlineData(FlatPriceCurrency.Djf)]
    [InlineData(FlatPriceCurrency.Gnf)]
    [InlineData(FlatPriceCurrency.Ugx)]
    [InlineData(FlatPriceCurrency.Pyg)]
    [InlineData(FlatPriceCurrency.Xof)]
    [InlineData(FlatPriceCurrency.Xpf)]
    public void Validation_Works(FlatPriceCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FlatPriceCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FlatPriceCurrency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FlatPriceCurrency.Usd)]
    [InlineData(FlatPriceCurrency.Aed)]
    [InlineData(FlatPriceCurrency.All)]
    [InlineData(FlatPriceCurrency.Amd)]
    [InlineData(FlatPriceCurrency.Ang)]
    [InlineData(FlatPriceCurrency.Aud)]
    [InlineData(FlatPriceCurrency.Awg)]
    [InlineData(FlatPriceCurrency.Azn)]
    [InlineData(FlatPriceCurrency.Bam)]
    [InlineData(FlatPriceCurrency.Bbd)]
    [InlineData(FlatPriceCurrency.Bdt)]
    [InlineData(FlatPriceCurrency.Bgn)]
    [InlineData(FlatPriceCurrency.Bif)]
    [InlineData(FlatPriceCurrency.Bmd)]
    [InlineData(FlatPriceCurrency.Bnd)]
    [InlineData(FlatPriceCurrency.Bsd)]
    [InlineData(FlatPriceCurrency.Bwp)]
    [InlineData(FlatPriceCurrency.Byn)]
    [InlineData(FlatPriceCurrency.Bzd)]
    [InlineData(FlatPriceCurrency.Brl)]
    [InlineData(FlatPriceCurrency.Cad)]
    [InlineData(FlatPriceCurrency.Cdf)]
    [InlineData(FlatPriceCurrency.Chf)]
    [InlineData(FlatPriceCurrency.Cny)]
    [InlineData(FlatPriceCurrency.Czk)]
    [InlineData(FlatPriceCurrency.Dkk)]
    [InlineData(FlatPriceCurrency.Dop)]
    [InlineData(FlatPriceCurrency.Dzd)]
    [InlineData(FlatPriceCurrency.Egp)]
    [InlineData(FlatPriceCurrency.Etb)]
    [InlineData(FlatPriceCurrency.Eur)]
    [InlineData(FlatPriceCurrency.Fjd)]
    [InlineData(FlatPriceCurrency.Gbp)]
    [InlineData(FlatPriceCurrency.Gel)]
    [InlineData(FlatPriceCurrency.Gip)]
    [InlineData(FlatPriceCurrency.Gmd)]
    [InlineData(FlatPriceCurrency.Gyd)]
    [InlineData(FlatPriceCurrency.Hkd)]
    [InlineData(FlatPriceCurrency.Hrk)]
    [InlineData(FlatPriceCurrency.Htg)]
    [InlineData(FlatPriceCurrency.Idr)]
    [InlineData(FlatPriceCurrency.Ils)]
    [InlineData(FlatPriceCurrency.Inr)]
    [InlineData(FlatPriceCurrency.Isk)]
    [InlineData(FlatPriceCurrency.Jmd)]
    [InlineData(FlatPriceCurrency.Jpy)]
    [InlineData(FlatPriceCurrency.Kes)]
    [InlineData(FlatPriceCurrency.Kgs)]
    [InlineData(FlatPriceCurrency.Khr)]
    [InlineData(FlatPriceCurrency.Kmf)]
    [InlineData(FlatPriceCurrency.Krw)]
    [InlineData(FlatPriceCurrency.Kyd)]
    [InlineData(FlatPriceCurrency.Kzt)]
    [InlineData(FlatPriceCurrency.Lbp)]
    [InlineData(FlatPriceCurrency.Lkr)]
    [InlineData(FlatPriceCurrency.Lrd)]
    [InlineData(FlatPriceCurrency.Lsl)]
    [InlineData(FlatPriceCurrency.Mad)]
    [InlineData(FlatPriceCurrency.Mdl)]
    [InlineData(FlatPriceCurrency.Mga)]
    [InlineData(FlatPriceCurrency.Mkd)]
    [InlineData(FlatPriceCurrency.Mmk)]
    [InlineData(FlatPriceCurrency.Mnt)]
    [InlineData(FlatPriceCurrency.Mop)]
    [InlineData(FlatPriceCurrency.Mro)]
    [InlineData(FlatPriceCurrency.Mvr)]
    [InlineData(FlatPriceCurrency.Mwk)]
    [InlineData(FlatPriceCurrency.Mxn)]
    [InlineData(FlatPriceCurrency.Myr)]
    [InlineData(FlatPriceCurrency.Mzn)]
    [InlineData(FlatPriceCurrency.Nad)]
    [InlineData(FlatPriceCurrency.Ngn)]
    [InlineData(FlatPriceCurrency.Nok)]
    [InlineData(FlatPriceCurrency.Npr)]
    [InlineData(FlatPriceCurrency.Nzd)]
    [InlineData(FlatPriceCurrency.Pgk)]
    [InlineData(FlatPriceCurrency.Php)]
    [InlineData(FlatPriceCurrency.Pkr)]
    [InlineData(FlatPriceCurrency.Pln)]
    [InlineData(FlatPriceCurrency.Qar)]
    [InlineData(FlatPriceCurrency.Ron)]
    [InlineData(FlatPriceCurrency.Rsd)]
    [InlineData(FlatPriceCurrency.Rub)]
    [InlineData(FlatPriceCurrency.Rwf)]
    [InlineData(FlatPriceCurrency.Sar)]
    [InlineData(FlatPriceCurrency.Sbd)]
    [InlineData(FlatPriceCurrency.Scr)]
    [InlineData(FlatPriceCurrency.Sek)]
    [InlineData(FlatPriceCurrency.Sgd)]
    [InlineData(FlatPriceCurrency.Sle)]
    [InlineData(FlatPriceCurrency.Sll)]
    [InlineData(FlatPriceCurrency.Sos)]
    [InlineData(FlatPriceCurrency.Szl)]
    [InlineData(FlatPriceCurrency.Thb)]
    [InlineData(FlatPriceCurrency.Tjs)]
    [InlineData(FlatPriceCurrency.Top)]
    [InlineData(FlatPriceCurrency.Try)]
    [InlineData(FlatPriceCurrency.Ttd)]
    [InlineData(FlatPriceCurrency.Tzs)]
    [InlineData(FlatPriceCurrency.Uah)]
    [InlineData(FlatPriceCurrency.Uzs)]
    [InlineData(FlatPriceCurrency.Vnd)]
    [InlineData(FlatPriceCurrency.Vuv)]
    [InlineData(FlatPriceCurrency.Wst)]
    [InlineData(FlatPriceCurrency.Xaf)]
    [InlineData(FlatPriceCurrency.Xcd)]
    [InlineData(FlatPriceCurrency.Yer)]
    [InlineData(FlatPriceCurrency.Zar)]
    [InlineData(FlatPriceCurrency.Zmw)]
    [InlineData(FlatPriceCurrency.Clp)]
    [InlineData(FlatPriceCurrency.Djf)]
    [InlineData(FlatPriceCurrency.Gnf)]
    [InlineData(FlatPriceCurrency.Ugx)]
    [InlineData(FlatPriceCurrency.Pyg)]
    [InlineData(FlatPriceCurrency.Xof)]
    [InlineData(FlatPriceCurrency.Xpf)]
    public void SerializationRoundtrip_Works(FlatPriceCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FlatPriceCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FlatPriceCurrency>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FlatPriceCurrency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FlatPriceCurrency>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class UnitPriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UnitPrice { Amount = 0, Currency = UnitPriceCurrency.Usd };

        double expectedAmount = 0;
        ApiEnum<string, UnitPriceCurrency> expectedCurrency = UnitPriceCurrency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UnitPrice { Amount = 0, Currency = UnitPriceCurrency.Usd };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnitPrice>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UnitPrice { Amount = 0, Currency = UnitPriceCurrency.Usd };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnitPrice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        ApiEnum<string, UnitPriceCurrency> expectedCurrency = UnitPriceCurrency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UnitPrice { Amount = 0, Currency = UnitPriceCurrency.Usd };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UnitPrice { Amount = 0, Currency = UnitPriceCurrency.Usd };

        UnitPrice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UnitPriceCurrencyTest : TestBase
{
    [Theory]
    [InlineData(UnitPriceCurrency.Usd)]
    [InlineData(UnitPriceCurrency.Aed)]
    [InlineData(UnitPriceCurrency.All)]
    [InlineData(UnitPriceCurrency.Amd)]
    [InlineData(UnitPriceCurrency.Ang)]
    [InlineData(UnitPriceCurrency.Aud)]
    [InlineData(UnitPriceCurrency.Awg)]
    [InlineData(UnitPriceCurrency.Azn)]
    [InlineData(UnitPriceCurrency.Bam)]
    [InlineData(UnitPriceCurrency.Bbd)]
    [InlineData(UnitPriceCurrency.Bdt)]
    [InlineData(UnitPriceCurrency.Bgn)]
    [InlineData(UnitPriceCurrency.Bif)]
    [InlineData(UnitPriceCurrency.Bmd)]
    [InlineData(UnitPriceCurrency.Bnd)]
    [InlineData(UnitPriceCurrency.Bsd)]
    [InlineData(UnitPriceCurrency.Bwp)]
    [InlineData(UnitPriceCurrency.Byn)]
    [InlineData(UnitPriceCurrency.Bzd)]
    [InlineData(UnitPriceCurrency.Brl)]
    [InlineData(UnitPriceCurrency.Cad)]
    [InlineData(UnitPriceCurrency.Cdf)]
    [InlineData(UnitPriceCurrency.Chf)]
    [InlineData(UnitPriceCurrency.Cny)]
    [InlineData(UnitPriceCurrency.Czk)]
    [InlineData(UnitPriceCurrency.Dkk)]
    [InlineData(UnitPriceCurrency.Dop)]
    [InlineData(UnitPriceCurrency.Dzd)]
    [InlineData(UnitPriceCurrency.Egp)]
    [InlineData(UnitPriceCurrency.Etb)]
    [InlineData(UnitPriceCurrency.Eur)]
    [InlineData(UnitPriceCurrency.Fjd)]
    [InlineData(UnitPriceCurrency.Gbp)]
    [InlineData(UnitPriceCurrency.Gel)]
    [InlineData(UnitPriceCurrency.Gip)]
    [InlineData(UnitPriceCurrency.Gmd)]
    [InlineData(UnitPriceCurrency.Gyd)]
    [InlineData(UnitPriceCurrency.Hkd)]
    [InlineData(UnitPriceCurrency.Hrk)]
    [InlineData(UnitPriceCurrency.Htg)]
    [InlineData(UnitPriceCurrency.Idr)]
    [InlineData(UnitPriceCurrency.Ils)]
    [InlineData(UnitPriceCurrency.Inr)]
    [InlineData(UnitPriceCurrency.Isk)]
    [InlineData(UnitPriceCurrency.Jmd)]
    [InlineData(UnitPriceCurrency.Jpy)]
    [InlineData(UnitPriceCurrency.Kes)]
    [InlineData(UnitPriceCurrency.Kgs)]
    [InlineData(UnitPriceCurrency.Khr)]
    [InlineData(UnitPriceCurrency.Kmf)]
    [InlineData(UnitPriceCurrency.Krw)]
    [InlineData(UnitPriceCurrency.Kyd)]
    [InlineData(UnitPriceCurrency.Kzt)]
    [InlineData(UnitPriceCurrency.Lbp)]
    [InlineData(UnitPriceCurrency.Lkr)]
    [InlineData(UnitPriceCurrency.Lrd)]
    [InlineData(UnitPriceCurrency.Lsl)]
    [InlineData(UnitPriceCurrency.Mad)]
    [InlineData(UnitPriceCurrency.Mdl)]
    [InlineData(UnitPriceCurrency.Mga)]
    [InlineData(UnitPriceCurrency.Mkd)]
    [InlineData(UnitPriceCurrency.Mmk)]
    [InlineData(UnitPriceCurrency.Mnt)]
    [InlineData(UnitPriceCurrency.Mop)]
    [InlineData(UnitPriceCurrency.Mro)]
    [InlineData(UnitPriceCurrency.Mvr)]
    [InlineData(UnitPriceCurrency.Mwk)]
    [InlineData(UnitPriceCurrency.Mxn)]
    [InlineData(UnitPriceCurrency.Myr)]
    [InlineData(UnitPriceCurrency.Mzn)]
    [InlineData(UnitPriceCurrency.Nad)]
    [InlineData(UnitPriceCurrency.Ngn)]
    [InlineData(UnitPriceCurrency.Nok)]
    [InlineData(UnitPriceCurrency.Npr)]
    [InlineData(UnitPriceCurrency.Nzd)]
    [InlineData(UnitPriceCurrency.Pgk)]
    [InlineData(UnitPriceCurrency.Php)]
    [InlineData(UnitPriceCurrency.Pkr)]
    [InlineData(UnitPriceCurrency.Pln)]
    [InlineData(UnitPriceCurrency.Qar)]
    [InlineData(UnitPriceCurrency.Ron)]
    [InlineData(UnitPriceCurrency.Rsd)]
    [InlineData(UnitPriceCurrency.Rub)]
    [InlineData(UnitPriceCurrency.Rwf)]
    [InlineData(UnitPriceCurrency.Sar)]
    [InlineData(UnitPriceCurrency.Sbd)]
    [InlineData(UnitPriceCurrency.Scr)]
    [InlineData(UnitPriceCurrency.Sek)]
    [InlineData(UnitPriceCurrency.Sgd)]
    [InlineData(UnitPriceCurrency.Sle)]
    [InlineData(UnitPriceCurrency.Sll)]
    [InlineData(UnitPriceCurrency.Sos)]
    [InlineData(UnitPriceCurrency.Szl)]
    [InlineData(UnitPriceCurrency.Thb)]
    [InlineData(UnitPriceCurrency.Tjs)]
    [InlineData(UnitPriceCurrency.Top)]
    [InlineData(UnitPriceCurrency.Try)]
    [InlineData(UnitPriceCurrency.Ttd)]
    [InlineData(UnitPriceCurrency.Tzs)]
    [InlineData(UnitPriceCurrency.Uah)]
    [InlineData(UnitPriceCurrency.Uzs)]
    [InlineData(UnitPriceCurrency.Vnd)]
    [InlineData(UnitPriceCurrency.Vuv)]
    [InlineData(UnitPriceCurrency.Wst)]
    [InlineData(UnitPriceCurrency.Xaf)]
    [InlineData(UnitPriceCurrency.Xcd)]
    [InlineData(UnitPriceCurrency.Yer)]
    [InlineData(UnitPriceCurrency.Zar)]
    [InlineData(UnitPriceCurrency.Zmw)]
    [InlineData(UnitPriceCurrency.Clp)]
    [InlineData(UnitPriceCurrency.Djf)]
    [InlineData(UnitPriceCurrency.Gnf)]
    [InlineData(UnitPriceCurrency.Ugx)]
    [InlineData(UnitPriceCurrency.Pyg)]
    [InlineData(UnitPriceCurrency.Xof)]
    [InlineData(UnitPriceCurrency.Xpf)]
    public void Validation_Works(UnitPriceCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UnitPriceCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UnitPriceCurrency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UnitPriceCurrency.Usd)]
    [InlineData(UnitPriceCurrency.Aed)]
    [InlineData(UnitPriceCurrency.All)]
    [InlineData(UnitPriceCurrency.Amd)]
    [InlineData(UnitPriceCurrency.Ang)]
    [InlineData(UnitPriceCurrency.Aud)]
    [InlineData(UnitPriceCurrency.Awg)]
    [InlineData(UnitPriceCurrency.Azn)]
    [InlineData(UnitPriceCurrency.Bam)]
    [InlineData(UnitPriceCurrency.Bbd)]
    [InlineData(UnitPriceCurrency.Bdt)]
    [InlineData(UnitPriceCurrency.Bgn)]
    [InlineData(UnitPriceCurrency.Bif)]
    [InlineData(UnitPriceCurrency.Bmd)]
    [InlineData(UnitPriceCurrency.Bnd)]
    [InlineData(UnitPriceCurrency.Bsd)]
    [InlineData(UnitPriceCurrency.Bwp)]
    [InlineData(UnitPriceCurrency.Byn)]
    [InlineData(UnitPriceCurrency.Bzd)]
    [InlineData(UnitPriceCurrency.Brl)]
    [InlineData(UnitPriceCurrency.Cad)]
    [InlineData(UnitPriceCurrency.Cdf)]
    [InlineData(UnitPriceCurrency.Chf)]
    [InlineData(UnitPriceCurrency.Cny)]
    [InlineData(UnitPriceCurrency.Czk)]
    [InlineData(UnitPriceCurrency.Dkk)]
    [InlineData(UnitPriceCurrency.Dop)]
    [InlineData(UnitPriceCurrency.Dzd)]
    [InlineData(UnitPriceCurrency.Egp)]
    [InlineData(UnitPriceCurrency.Etb)]
    [InlineData(UnitPriceCurrency.Eur)]
    [InlineData(UnitPriceCurrency.Fjd)]
    [InlineData(UnitPriceCurrency.Gbp)]
    [InlineData(UnitPriceCurrency.Gel)]
    [InlineData(UnitPriceCurrency.Gip)]
    [InlineData(UnitPriceCurrency.Gmd)]
    [InlineData(UnitPriceCurrency.Gyd)]
    [InlineData(UnitPriceCurrency.Hkd)]
    [InlineData(UnitPriceCurrency.Hrk)]
    [InlineData(UnitPriceCurrency.Htg)]
    [InlineData(UnitPriceCurrency.Idr)]
    [InlineData(UnitPriceCurrency.Ils)]
    [InlineData(UnitPriceCurrency.Inr)]
    [InlineData(UnitPriceCurrency.Isk)]
    [InlineData(UnitPriceCurrency.Jmd)]
    [InlineData(UnitPriceCurrency.Jpy)]
    [InlineData(UnitPriceCurrency.Kes)]
    [InlineData(UnitPriceCurrency.Kgs)]
    [InlineData(UnitPriceCurrency.Khr)]
    [InlineData(UnitPriceCurrency.Kmf)]
    [InlineData(UnitPriceCurrency.Krw)]
    [InlineData(UnitPriceCurrency.Kyd)]
    [InlineData(UnitPriceCurrency.Kzt)]
    [InlineData(UnitPriceCurrency.Lbp)]
    [InlineData(UnitPriceCurrency.Lkr)]
    [InlineData(UnitPriceCurrency.Lrd)]
    [InlineData(UnitPriceCurrency.Lsl)]
    [InlineData(UnitPriceCurrency.Mad)]
    [InlineData(UnitPriceCurrency.Mdl)]
    [InlineData(UnitPriceCurrency.Mga)]
    [InlineData(UnitPriceCurrency.Mkd)]
    [InlineData(UnitPriceCurrency.Mmk)]
    [InlineData(UnitPriceCurrency.Mnt)]
    [InlineData(UnitPriceCurrency.Mop)]
    [InlineData(UnitPriceCurrency.Mro)]
    [InlineData(UnitPriceCurrency.Mvr)]
    [InlineData(UnitPriceCurrency.Mwk)]
    [InlineData(UnitPriceCurrency.Mxn)]
    [InlineData(UnitPriceCurrency.Myr)]
    [InlineData(UnitPriceCurrency.Mzn)]
    [InlineData(UnitPriceCurrency.Nad)]
    [InlineData(UnitPriceCurrency.Ngn)]
    [InlineData(UnitPriceCurrency.Nok)]
    [InlineData(UnitPriceCurrency.Npr)]
    [InlineData(UnitPriceCurrency.Nzd)]
    [InlineData(UnitPriceCurrency.Pgk)]
    [InlineData(UnitPriceCurrency.Php)]
    [InlineData(UnitPriceCurrency.Pkr)]
    [InlineData(UnitPriceCurrency.Pln)]
    [InlineData(UnitPriceCurrency.Qar)]
    [InlineData(UnitPriceCurrency.Ron)]
    [InlineData(UnitPriceCurrency.Rsd)]
    [InlineData(UnitPriceCurrency.Rub)]
    [InlineData(UnitPriceCurrency.Rwf)]
    [InlineData(UnitPriceCurrency.Sar)]
    [InlineData(UnitPriceCurrency.Sbd)]
    [InlineData(UnitPriceCurrency.Scr)]
    [InlineData(UnitPriceCurrency.Sek)]
    [InlineData(UnitPriceCurrency.Sgd)]
    [InlineData(UnitPriceCurrency.Sle)]
    [InlineData(UnitPriceCurrency.Sll)]
    [InlineData(UnitPriceCurrency.Sos)]
    [InlineData(UnitPriceCurrency.Szl)]
    [InlineData(UnitPriceCurrency.Thb)]
    [InlineData(UnitPriceCurrency.Tjs)]
    [InlineData(UnitPriceCurrency.Top)]
    [InlineData(UnitPriceCurrency.Try)]
    [InlineData(UnitPriceCurrency.Ttd)]
    [InlineData(UnitPriceCurrency.Tzs)]
    [InlineData(UnitPriceCurrency.Uah)]
    [InlineData(UnitPriceCurrency.Uzs)]
    [InlineData(UnitPriceCurrency.Vnd)]
    [InlineData(UnitPriceCurrency.Vuv)]
    [InlineData(UnitPriceCurrency.Wst)]
    [InlineData(UnitPriceCurrency.Xaf)]
    [InlineData(UnitPriceCurrency.Xcd)]
    [InlineData(UnitPriceCurrency.Yer)]
    [InlineData(UnitPriceCurrency.Zar)]
    [InlineData(UnitPriceCurrency.Zmw)]
    [InlineData(UnitPriceCurrency.Clp)]
    [InlineData(UnitPriceCurrency.Djf)]
    [InlineData(UnitPriceCurrency.Gnf)]
    [InlineData(UnitPriceCurrency.Ugx)]
    [InlineData(UnitPriceCurrency.Pyg)]
    [InlineData(UnitPriceCurrency.Xof)]
    [InlineData(UnitPriceCurrency.Xpf)]
    public void SerializationRoundtrip_Works(UnitPriceCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UnitPriceCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UnitPriceCurrency>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UnitPriceCurrency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UnitPriceCurrency>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionProvisionParamsScheduleStrategyTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionProvisionParamsScheduleStrategy.EndOfBillingPeriod)]
    [InlineData(SubscriptionProvisionParamsScheduleStrategy.EndOfBillingMonth)]
    [InlineData(SubscriptionProvisionParamsScheduleStrategy.Immediate)]
    public void Validation_Works(SubscriptionProvisionParamsScheduleStrategy rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionProvisionParamsScheduleStrategy> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionParamsScheduleStrategy>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionProvisionParamsScheduleStrategy.EndOfBillingPeriod)]
    [InlineData(SubscriptionProvisionParamsScheduleStrategy.EndOfBillingMonth)]
    [InlineData(SubscriptionProvisionParamsScheduleStrategy.Immediate)]
    public void SerializationRoundtrip_Works(SubscriptionProvisionParamsScheduleStrategy rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionProvisionParamsScheduleStrategy> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionParamsScheduleStrategy>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionParamsScheduleStrategy>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionParamsScheduleStrategy>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionProvisionParamsTrialOverrideConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionProvisionParamsTrialOverrideConfiguration
        {
            IsTrial = true,
            TrialEndBehavior =
                SubscriptionProvisionParamsTrialOverrideConfigurationTrialEndBehavior.ConvertToPaid,
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        bool expectedIsTrial = true;
        ApiEnum<
            string,
            SubscriptionProvisionParamsTrialOverrideConfigurationTrialEndBehavior
        > expectedTrialEndBehavior =
            SubscriptionProvisionParamsTrialOverrideConfigurationTrialEndBehavior.ConvertToPaid;
        DateTimeOffset expectedTrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedIsTrial, model.IsTrial);
        Assert.Equal(expectedTrialEndBehavior, model.TrialEndBehavior);
        Assert.Equal(expectedTrialEndDate, model.TrialEndDate);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionProvisionParamsTrialOverrideConfiguration
        {
            IsTrial = true,
            TrialEndBehavior =
                SubscriptionProvisionParamsTrialOverrideConfigurationTrialEndBehavior.ConvertToPaid,
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionProvisionParamsTrialOverrideConfiguration>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionProvisionParamsTrialOverrideConfiguration
        {
            IsTrial = true,
            TrialEndBehavior =
                SubscriptionProvisionParamsTrialOverrideConfigurationTrialEndBehavior.ConvertToPaid,
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionProvisionParamsTrialOverrideConfiguration>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        bool expectedIsTrial = true;
        ApiEnum<
            string,
            SubscriptionProvisionParamsTrialOverrideConfigurationTrialEndBehavior
        > expectedTrialEndBehavior =
            SubscriptionProvisionParamsTrialOverrideConfigurationTrialEndBehavior.ConvertToPaid;
        DateTimeOffset expectedTrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedIsTrial, deserialized.IsTrial);
        Assert.Equal(expectedTrialEndBehavior, deserialized.TrialEndBehavior);
        Assert.Equal(expectedTrialEndDate, deserialized.TrialEndDate);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionProvisionParamsTrialOverrideConfiguration
        {
            IsTrial = true,
            TrialEndBehavior =
                SubscriptionProvisionParamsTrialOverrideConfigurationTrialEndBehavior.ConvertToPaid,
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubscriptionProvisionParamsTrialOverrideConfiguration { IsTrial = true };

        Assert.Null(model.TrialEndBehavior);
        Assert.False(model.RawData.ContainsKey("trialEndBehavior"));
        Assert.Null(model.TrialEndDate);
        Assert.False(model.RawData.ContainsKey("trialEndDate"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SubscriptionProvisionParamsTrialOverrideConfiguration { IsTrial = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SubscriptionProvisionParamsTrialOverrideConfiguration
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
        var model = new SubscriptionProvisionParamsTrialOverrideConfiguration
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
        var model = new SubscriptionProvisionParamsTrialOverrideConfiguration
        {
            IsTrial = true,
            TrialEndBehavior =
                SubscriptionProvisionParamsTrialOverrideConfigurationTrialEndBehavior.ConvertToPaid,
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        SubscriptionProvisionParamsTrialOverrideConfiguration copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionProvisionParamsTrialOverrideConfigurationTrialEndBehaviorTest : TestBase
{
    [Theory]
    [InlineData(
        SubscriptionProvisionParamsTrialOverrideConfigurationTrialEndBehavior.ConvertToPaid
    )]
    [InlineData(
        SubscriptionProvisionParamsTrialOverrideConfigurationTrialEndBehavior.CancelSubscription
    )]
    public void Validation_Works(
        SubscriptionProvisionParamsTrialOverrideConfigurationTrialEndBehavior rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            SubscriptionProvisionParamsTrialOverrideConfigurationTrialEndBehavior
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionParamsTrialOverrideConfigurationTrialEndBehavior>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        SubscriptionProvisionParamsTrialOverrideConfigurationTrialEndBehavior.ConvertToPaid
    )]
    [InlineData(
        SubscriptionProvisionParamsTrialOverrideConfigurationTrialEndBehavior.CancelSubscription
    )]
    public void SerializationRoundtrip_Works(
        SubscriptionProvisionParamsTrialOverrideConfigurationTrialEndBehavior rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            SubscriptionProvisionParamsTrialOverrideConfigurationTrialEndBehavior
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionParamsTrialOverrideConfigurationTrialEndBehavior>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionParamsTrialOverrideConfigurationTrialEndBehavior>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionProvisionParamsTrialOverrideConfigurationTrialEndBehavior>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
