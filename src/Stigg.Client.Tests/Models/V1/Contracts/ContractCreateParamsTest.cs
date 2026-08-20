using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Contracts = Stigg.Client.Models.V1.Contracts;

namespace Stigg.Client.Tests.Models.V1.Contracts;

public class ContractCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new Contracts::ContractCreateParams
        {
            CustomerID = "customerId",
            Subscriptions =
            [
                new()
                {
                    ExistingSubscriptionID = "existingSubscriptionId",
                    NewSubscription = new()
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
                                    new() { Amount = 0, Currency = Contracts::Currency.Usd },
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
                        BillingCycleAnchor = Contracts::BillingCycleAnchor.Unchanged,
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
                            ProrationBehavior = Contracts::ProrationBehavior.InvoiceImmediately,
                            TaxIds = [new() { Type = "type", Value = "value" }],
                            TaxPercentage = 0,
                            TaxRateIds = ["string"],
                        },
                        BillingPeriod = Contracts::BillingPeriod.Monthly,
                        Budget = new() { HasSoftLimit = true, Limit = 0 },
                        CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Charges =
                        [
                            new()
                            {
                                ID = "id",
                                Quantity = 0,
                                Type = Contracts::Type.Feature,
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
                            new Contracts::Feature()
                            {
                                ID = "id",
                                HasSoftLimit = true,
                                HasUnlimitedUsage = true,
                                MonthlyResetPeriodConfiguration = new(
                                    Contracts::AccordingTo.SubscriptionStart
                                ),
                                ResetPeriod = Contracts::ResetPeriod.Year,
                                UsageLimit = 0,
                                WeeklyResetPeriodConfiguration = new(
                                    Contracts::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                                ),
                                YearlyResetPeriodConfiguration = new(
                                    Contracts::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                                ),
                            },
                        ],
                        Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                        MinimumSpend = new()
                        {
                            Amount = 0,
                            Currency = Contracts::MinimumSpendCurrency.Usd,
                        },
                        PayingCustomerID = "payingCustomerId",
                        PaymentCollectionMethod = Contracts::PaymentCollectionMethod.Charge,
                        PriceOverrides =
                        [
                            new()
                            {
                                AddonID = "addonId",
                                Amount = 0,
                                BaseCharge = true,
                                BillingCountryCode = "billingCountryCode",
                                BlockSize = 0,
                                CreditGrantCadence =
                                    Contracts::CreditGrantCadence.BeginningOfBillingPeriod,
                                CreditRate = new()
                                {
                                    Amount = 1,
                                    CurrencyID = "currencyId",
                                    CostFormula = "costFormula",
                                },
                                Currency = Contracts::PriceOverrideCurrency.Usd,
                                FeatureID = "featureId",
                                Tiers =
                                [
                                    new()
                                    {
                                        FlatPrice = new()
                                        {
                                            Amount = 0,
                                            Currency = Contracts::FlatPriceCurrency.Usd,
                                        },
                                        UnitPrice = new()
                                        {
                                            Amount = 0,
                                            Currency = Contracts::UnitPriceCurrency.Usd,
                                        },
                                        UpTo = 0,
                                    },
                                ],
                            },
                        ],
                        ResourceID = "resourceId",
                        SalesforceID = "salesforceId",
                        ScheduleStrategy = Contracts::ScheduleStrategy.EndOfBillingPeriod,
                        StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        TrialOverrideConfiguration = new()
                        {
                            IsTrial = true,
                            TrialEndBehavior = Contracts::TrialEndBehavior.ConvertToPaid,
                            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        },
                        UnitQuantity = 0,
                    },
                },
            ],
            ActivationEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ActivationStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "name",
            PoNumber = "poNumber",
            SetupBilling = true,
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        string expectedCustomerID = "customerId";
        List<Contracts::Subscription> expectedSubscriptions =
        [
            new()
            {
                ExistingSubscriptionID = "existingSubscriptionId",
                NewSubscription = new()
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
                            AmountsOff = [new() { Amount = 0, Currency = Contracts::Currency.Usd }],
                            Description = "description",
                            DurationInMonths = 1,
                            Name = "name",
                            PercentOff = 1,
                        },
                        PromotionCode = "promotionCode",
                    },
                    AwaitPaymentConfirmation = true,
                    BillingCountryCode = "billingCountryCode",
                    BillingCycleAnchor = Contracts::BillingCycleAnchor.Unchanged,
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
                        ProrationBehavior = Contracts::ProrationBehavior.InvoiceImmediately,
                        TaxIds = [new() { Type = "type", Value = "value" }],
                        TaxPercentage = 0,
                        TaxRateIds = ["string"],
                    },
                    BillingPeriod = Contracts::BillingPeriod.Monthly,
                    Budget = new() { HasSoftLimit = true, Limit = 0 },
                    CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Charges =
                    [
                        new()
                        {
                            ID = "id",
                            Quantity = 0,
                            Type = Contracts::Type.Feature,
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
                        new Contracts::Feature()
                        {
                            ID = "id",
                            HasSoftLimit = true,
                            HasUnlimitedUsage = true,
                            MonthlyResetPeriodConfiguration = new(
                                Contracts::AccordingTo.SubscriptionStart
                            ),
                            ResetPeriod = Contracts::ResetPeriod.Year,
                            UsageLimit = 0,
                            WeeklyResetPeriodConfiguration = new(
                                Contracts::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                            ),
                            YearlyResetPeriodConfiguration = new(
                                Contracts::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                            ),
                        },
                    ],
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    MinimumSpend = new()
                    {
                        Amount = 0,
                        Currency = Contracts::MinimumSpendCurrency.Usd,
                    },
                    PayingCustomerID = "payingCustomerId",
                    PaymentCollectionMethod = Contracts::PaymentCollectionMethod.Charge,
                    PriceOverrides =
                    [
                        new()
                        {
                            AddonID = "addonId",
                            Amount = 0,
                            BaseCharge = true,
                            BillingCountryCode = "billingCountryCode",
                            BlockSize = 0,
                            CreditGrantCadence =
                                Contracts::CreditGrantCadence.BeginningOfBillingPeriod,
                            CreditRate = new()
                            {
                                Amount = 1,
                                CurrencyID = "currencyId",
                                CostFormula = "costFormula",
                            },
                            Currency = Contracts::PriceOverrideCurrency.Usd,
                            FeatureID = "featureId",
                            Tiers =
                            [
                                new()
                                {
                                    FlatPrice = new()
                                    {
                                        Amount = 0,
                                        Currency = Contracts::FlatPriceCurrency.Usd,
                                    },
                                    UnitPrice = new()
                                    {
                                        Amount = 0,
                                        Currency = Contracts::UnitPriceCurrency.Usd,
                                    },
                                    UpTo = 0,
                                },
                            ],
                        },
                    ],
                    ResourceID = "resourceId",
                    SalesforceID = "salesforceId",
                    ScheduleStrategy = Contracts::ScheduleStrategy.EndOfBillingPeriod,
                    StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    TrialOverrideConfiguration = new()
                    {
                        IsTrial = true,
                        TrialEndBehavior = Contracts::TrialEndBehavior.ConvertToPaid,
                        TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                    UnitQuantity = 0,
                },
            },
        ];
        DateTimeOffset expectedActivationEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedActivationStartDate = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        string expectedName = "name";
        string expectedPoNumber = "poNumber";
        bool expectedSetupBilling = true;
        string expectedXAccountID = "X-ACCOUNT-ID";
        string expectedXEnvironmentID = "X-ENVIRONMENT-ID";

        Assert.Equal(expectedCustomerID, parameters.CustomerID);
        Assert.Equal(expectedSubscriptions.Count, parameters.Subscriptions.Count);
        for (int i = 0; i < expectedSubscriptions.Count; i++)
        {
            Assert.Equal(expectedSubscriptions[i], parameters.Subscriptions[i]);
        }
        Assert.Equal(expectedActivationEndDate, parameters.ActivationEndDate);
        Assert.Equal(expectedActivationStartDate, parameters.ActivationStartDate);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedPoNumber, parameters.PoNumber);
        Assert.Equal(expectedSetupBilling, parameters.SetupBilling);
        Assert.Equal(expectedXAccountID, parameters.XAccountID);
        Assert.Equal(expectedXEnvironmentID, parameters.XEnvironmentID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Contracts::ContractCreateParams
        {
            CustomerID = "customerId",
            Subscriptions =
            [
                new()
                {
                    ExistingSubscriptionID = "existingSubscriptionId",
                    NewSubscription = new()
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
                                    new() { Amount = 0, Currency = Contracts::Currency.Usd },
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
                        BillingCycleAnchor = Contracts::BillingCycleAnchor.Unchanged,
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
                            ProrationBehavior = Contracts::ProrationBehavior.InvoiceImmediately,
                            TaxIds = [new() { Type = "type", Value = "value" }],
                            TaxPercentage = 0,
                            TaxRateIds = ["string"],
                        },
                        BillingPeriod = Contracts::BillingPeriod.Monthly,
                        Budget = new() { HasSoftLimit = true, Limit = 0 },
                        CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Charges =
                        [
                            new()
                            {
                                ID = "id",
                                Quantity = 0,
                                Type = Contracts::Type.Feature,
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
                            new Contracts::Feature()
                            {
                                ID = "id",
                                HasSoftLimit = true,
                                HasUnlimitedUsage = true,
                                MonthlyResetPeriodConfiguration = new(
                                    Contracts::AccordingTo.SubscriptionStart
                                ),
                                ResetPeriod = Contracts::ResetPeriod.Year,
                                UsageLimit = 0,
                                WeeklyResetPeriodConfiguration = new(
                                    Contracts::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                                ),
                                YearlyResetPeriodConfiguration = new(
                                    Contracts::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                                ),
                            },
                        ],
                        Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                        MinimumSpend = new()
                        {
                            Amount = 0,
                            Currency = Contracts::MinimumSpendCurrency.Usd,
                        },
                        PayingCustomerID = "payingCustomerId",
                        PaymentCollectionMethod = Contracts::PaymentCollectionMethod.Charge,
                        PriceOverrides =
                        [
                            new()
                            {
                                AddonID = "addonId",
                                Amount = 0,
                                BaseCharge = true,
                                BillingCountryCode = "billingCountryCode",
                                BlockSize = 0,
                                CreditGrantCadence =
                                    Contracts::CreditGrantCadence.BeginningOfBillingPeriod,
                                CreditRate = new()
                                {
                                    Amount = 1,
                                    CurrencyID = "currencyId",
                                    CostFormula = "costFormula",
                                },
                                Currency = Contracts::PriceOverrideCurrency.Usd,
                                FeatureID = "featureId",
                                Tiers =
                                [
                                    new()
                                    {
                                        FlatPrice = new()
                                        {
                                            Amount = 0,
                                            Currency = Contracts::FlatPriceCurrency.Usd,
                                        },
                                        UnitPrice = new()
                                        {
                                            Amount = 0,
                                            Currency = Contracts::UnitPriceCurrency.Usd,
                                        },
                                        UpTo = 0,
                                    },
                                ],
                            },
                        ],
                        ResourceID = "resourceId",
                        SalesforceID = "salesforceId",
                        ScheduleStrategy = Contracts::ScheduleStrategy.EndOfBillingPeriod,
                        StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        TrialOverrideConfiguration = new()
                        {
                            IsTrial = true,
                            TrialEndBehavior = Contracts::TrialEndBehavior.ConvertToPaid,
                            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        },
                        UnitQuantity = 0,
                    },
                },
            ],
            Name = "name",
            PoNumber = "poNumber",
        };

        Assert.Null(parameters.ActivationEndDate);
        Assert.False(parameters.RawBodyData.ContainsKey("activationEndDate"));
        Assert.Null(parameters.ActivationStartDate);
        Assert.False(parameters.RawBodyData.ContainsKey("activationStartDate"));
        Assert.Null(parameters.SetupBilling);
        Assert.False(parameters.RawBodyData.ContainsKey("setupBilling"));
        Assert.Null(parameters.XAccountID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ACCOUNT-ID"));
        Assert.Null(parameters.XEnvironmentID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ENVIRONMENT-ID"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new Contracts::ContractCreateParams
        {
            CustomerID = "customerId",
            Subscriptions =
            [
                new()
                {
                    ExistingSubscriptionID = "existingSubscriptionId",
                    NewSubscription = new()
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
                                    new() { Amount = 0, Currency = Contracts::Currency.Usd },
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
                        BillingCycleAnchor = Contracts::BillingCycleAnchor.Unchanged,
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
                            ProrationBehavior = Contracts::ProrationBehavior.InvoiceImmediately,
                            TaxIds = [new() { Type = "type", Value = "value" }],
                            TaxPercentage = 0,
                            TaxRateIds = ["string"],
                        },
                        BillingPeriod = Contracts::BillingPeriod.Monthly,
                        Budget = new() { HasSoftLimit = true, Limit = 0 },
                        CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Charges =
                        [
                            new()
                            {
                                ID = "id",
                                Quantity = 0,
                                Type = Contracts::Type.Feature,
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
                            new Contracts::Feature()
                            {
                                ID = "id",
                                HasSoftLimit = true,
                                HasUnlimitedUsage = true,
                                MonthlyResetPeriodConfiguration = new(
                                    Contracts::AccordingTo.SubscriptionStart
                                ),
                                ResetPeriod = Contracts::ResetPeriod.Year,
                                UsageLimit = 0,
                                WeeklyResetPeriodConfiguration = new(
                                    Contracts::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                                ),
                                YearlyResetPeriodConfiguration = new(
                                    Contracts::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                                ),
                            },
                        ],
                        Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                        MinimumSpend = new()
                        {
                            Amount = 0,
                            Currency = Contracts::MinimumSpendCurrency.Usd,
                        },
                        PayingCustomerID = "payingCustomerId",
                        PaymentCollectionMethod = Contracts::PaymentCollectionMethod.Charge,
                        PriceOverrides =
                        [
                            new()
                            {
                                AddonID = "addonId",
                                Amount = 0,
                                BaseCharge = true,
                                BillingCountryCode = "billingCountryCode",
                                BlockSize = 0,
                                CreditGrantCadence =
                                    Contracts::CreditGrantCadence.BeginningOfBillingPeriod,
                                CreditRate = new()
                                {
                                    Amount = 1,
                                    CurrencyID = "currencyId",
                                    CostFormula = "costFormula",
                                },
                                Currency = Contracts::PriceOverrideCurrency.Usd,
                                FeatureID = "featureId",
                                Tiers =
                                [
                                    new()
                                    {
                                        FlatPrice = new()
                                        {
                                            Amount = 0,
                                            Currency = Contracts::FlatPriceCurrency.Usd,
                                        },
                                        UnitPrice = new()
                                        {
                                            Amount = 0,
                                            Currency = Contracts::UnitPriceCurrency.Usd,
                                        },
                                        UpTo = 0,
                                    },
                                ],
                            },
                        ],
                        ResourceID = "resourceId",
                        SalesforceID = "salesforceId",
                        ScheduleStrategy = Contracts::ScheduleStrategy.EndOfBillingPeriod,
                        StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        TrialOverrideConfiguration = new()
                        {
                            IsTrial = true,
                            TrialEndBehavior = Contracts::TrialEndBehavior.ConvertToPaid,
                            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        },
                        UnitQuantity = 0,
                    },
                },
            ],
            Name = "name",
            PoNumber = "poNumber",

            // Null should be interpreted as omitted for these properties
            ActivationEndDate = null,
            ActivationStartDate = null,
            SetupBilling = null,
            XAccountID = null,
            XEnvironmentID = null,
        };

        Assert.Null(parameters.ActivationEndDate);
        Assert.False(parameters.RawBodyData.ContainsKey("activationEndDate"));
        Assert.Null(parameters.ActivationStartDate);
        Assert.False(parameters.RawBodyData.ContainsKey("activationStartDate"));
        Assert.Null(parameters.SetupBilling);
        Assert.False(parameters.RawBodyData.ContainsKey("setupBilling"));
        Assert.Null(parameters.XAccountID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ACCOUNT-ID"));
        Assert.Null(parameters.XEnvironmentID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ENVIRONMENT-ID"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Contracts::ContractCreateParams
        {
            CustomerID = "customerId",
            Subscriptions =
            [
                new()
                {
                    ExistingSubscriptionID = "existingSubscriptionId",
                    NewSubscription = new()
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
                                    new() { Amount = 0, Currency = Contracts::Currency.Usd },
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
                        BillingCycleAnchor = Contracts::BillingCycleAnchor.Unchanged,
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
                            ProrationBehavior = Contracts::ProrationBehavior.InvoiceImmediately,
                            TaxIds = [new() { Type = "type", Value = "value" }],
                            TaxPercentage = 0,
                            TaxRateIds = ["string"],
                        },
                        BillingPeriod = Contracts::BillingPeriod.Monthly,
                        Budget = new() { HasSoftLimit = true, Limit = 0 },
                        CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Charges =
                        [
                            new()
                            {
                                ID = "id",
                                Quantity = 0,
                                Type = Contracts::Type.Feature,
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
                            new Contracts::Feature()
                            {
                                ID = "id",
                                HasSoftLimit = true,
                                HasUnlimitedUsage = true,
                                MonthlyResetPeriodConfiguration = new(
                                    Contracts::AccordingTo.SubscriptionStart
                                ),
                                ResetPeriod = Contracts::ResetPeriod.Year,
                                UsageLimit = 0,
                                WeeklyResetPeriodConfiguration = new(
                                    Contracts::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                                ),
                                YearlyResetPeriodConfiguration = new(
                                    Contracts::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                                ),
                            },
                        ],
                        Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                        MinimumSpend = new()
                        {
                            Amount = 0,
                            Currency = Contracts::MinimumSpendCurrency.Usd,
                        },
                        PayingCustomerID = "payingCustomerId",
                        PaymentCollectionMethod = Contracts::PaymentCollectionMethod.Charge,
                        PriceOverrides =
                        [
                            new()
                            {
                                AddonID = "addonId",
                                Amount = 0,
                                BaseCharge = true,
                                BillingCountryCode = "billingCountryCode",
                                BlockSize = 0,
                                CreditGrantCadence =
                                    Contracts::CreditGrantCadence.BeginningOfBillingPeriod,
                                CreditRate = new()
                                {
                                    Amount = 1,
                                    CurrencyID = "currencyId",
                                    CostFormula = "costFormula",
                                },
                                Currency = Contracts::PriceOverrideCurrency.Usd,
                                FeatureID = "featureId",
                                Tiers =
                                [
                                    new()
                                    {
                                        FlatPrice = new()
                                        {
                                            Amount = 0,
                                            Currency = Contracts::FlatPriceCurrency.Usd,
                                        },
                                        UnitPrice = new()
                                        {
                                            Amount = 0,
                                            Currency = Contracts::UnitPriceCurrency.Usd,
                                        },
                                        UpTo = 0,
                                    },
                                ],
                            },
                        ],
                        ResourceID = "resourceId",
                        SalesforceID = "salesforceId",
                        ScheduleStrategy = Contracts::ScheduleStrategy.EndOfBillingPeriod,
                        StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        TrialOverrideConfiguration = new()
                        {
                            IsTrial = true,
                            TrialEndBehavior = Contracts::TrialEndBehavior.ConvertToPaid,
                            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        },
                        UnitQuantity = 0,
                    },
                },
            ],
            ActivationEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ActivationStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SetupBilling = true,
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.PoNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("poNumber"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new Contracts::ContractCreateParams
        {
            CustomerID = "customerId",
            Subscriptions =
            [
                new()
                {
                    ExistingSubscriptionID = "existingSubscriptionId",
                    NewSubscription = new()
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
                                    new() { Amount = 0, Currency = Contracts::Currency.Usd },
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
                        BillingCycleAnchor = Contracts::BillingCycleAnchor.Unchanged,
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
                            ProrationBehavior = Contracts::ProrationBehavior.InvoiceImmediately,
                            TaxIds = [new() { Type = "type", Value = "value" }],
                            TaxPercentage = 0,
                            TaxRateIds = ["string"],
                        },
                        BillingPeriod = Contracts::BillingPeriod.Monthly,
                        Budget = new() { HasSoftLimit = true, Limit = 0 },
                        CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Charges =
                        [
                            new()
                            {
                                ID = "id",
                                Quantity = 0,
                                Type = Contracts::Type.Feature,
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
                            new Contracts::Feature()
                            {
                                ID = "id",
                                HasSoftLimit = true,
                                HasUnlimitedUsage = true,
                                MonthlyResetPeriodConfiguration = new(
                                    Contracts::AccordingTo.SubscriptionStart
                                ),
                                ResetPeriod = Contracts::ResetPeriod.Year,
                                UsageLimit = 0,
                                WeeklyResetPeriodConfiguration = new(
                                    Contracts::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                                ),
                                YearlyResetPeriodConfiguration = new(
                                    Contracts::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                                ),
                            },
                        ],
                        Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                        MinimumSpend = new()
                        {
                            Amount = 0,
                            Currency = Contracts::MinimumSpendCurrency.Usd,
                        },
                        PayingCustomerID = "payingCustomerId",
                        PaymentCollectionMethod = Contracts::PaymentCollectionMethod.Charge,
                        PriceOverrides =
                        [
                            new()
                            {
                                AddonID = "addonId",
                                Amount = 0,
                                BaseCharge = true,
                                BillingCountryCode = "billingCountryCode",
                                BlockSize = 0,
                                CreditGrantCadence =
                                    Contracts::CreditGrantCadence.BeginningOfBillingPeriod,
                                CreditRate = new()
                                {
                                    Amount = 1,
                                    CurrencyID = "currencyId",
                                    CostFormula = "costFormula",
                                },
                                Currency = Contracts::PriceOverrideCurrency.Usd,
                                FeatureID = "featureId",
                                Tiers =
                                [
                                    new()
                                    {
                                        FlatPrice = new()
                                        {
                                            Amount = 0,
                                            Currency = Contracts::FlatPriceCurrency.Usd,
                                        },
                                        UnitPrice = new()
                                        {
                                            Amount = 0,
                                            Currency = Contracts::UnitPriceCurrency.Usd,
                                        },
                                        UpTo = 0,
                                    },
                                ],
                            },
                        ],
                        ResourceID = "resourceId",
                        SalesforceID = "salesforceId",
                        ScheduleStrategy = Contracts::ScheduleStrategy.EndOfBillingPeriod,
                        StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        TrialOverrideConfiguration = new()
                        {
                            IsTrial = true,
                            TrialEndBehavior = Contracts::TrialEndBehavior.ConvertToPaid,
                            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        },
                        UnitQuantity = 0,
                    },
                },
            ],
            ActivationEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ActivationStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SetupBilling = true,
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",

            Name = null,
            PoNumber = null,
        };

        Assert.Null(parameters.Name);
        Assert.True(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.PoNumber);
        Assert.True(parameters.RawBodyData.ContainsKey("poNumber"));
    }

    [Fact]
    public void Url_Works()
    {
        Contracts::ContractCreateParams parameters = new()
        {
            CustomerID = "customerId",
            Subscriptions =
            [
                new()
                {
                    ExistingSubscriptionID = "existingSubscriptionId",
                    NewSubscription = new()
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
                                    new() { Amount = 0, Currency = Contracts::Currency.Usd },
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
                        BillingCycleAnchor = Contracts::BillingCycleAnchor.Unchanged,
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
                            ProrationBehavior = Contracts::ProrationBehavior.InvoiceImmediately,
                            TaxIds = [new() { Type = "type", Value = "value" }],
                            TaxPercentage = 0,
                            TaxRateIds = ["string"],
                        },
                        BillingPeriod = Contracts::BillingPeriod.Monthly,
                        Budget = new() { HasSoftLimit = true, Limit = 0 },
                        CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Charges =
                        [
                            new()
                            {
                                ID = "id",
                                Quantity = 0,
                                Type = Contracts::Type.Feature,
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
                            new Contracts::Feature()
                            {
                                ID = "id",
                                HasSoftLimit = true,
                                HasUnlimitedUsage = true,
                                MonthlyResetPeriodConfiguration = new(
                                    Contracts::AccordingTo.SubscriptionStart
                                ),
                                ResetPeriod = Contracts::ResetPeriod.Year,
                                UsageLimit = 0,
                                WeeklyResetPeriodConfiguration = new(
                                    Contracts::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                                ),
                                YearlyResetPeriodConfiguration = new(
                                    Contracts::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                                ),
                            },
                        ],
                        Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                        MinimumSpend = new()
                        {
                            Amount = 0,
                            Currency = Contracts::MinimumSpendCurrency.Usd,
                        },
                        PayingCustomerID = "payingCustomerId",
                        PaymentCollectionMethod = Contracts::PaymentCollectionMethod.Charge,
                        PriceOverrides =
                        [
                            new()
                            {
                                AddonID = "addonId",
                                Amount = 0,
                                BaseCharge = true,
                                BillingCountryCode = "billingCountryCode",
                                BlockSize = 0,
                                CreditGrantCadence =
                                    Contracts::CreditGrantCadence.BeginningOfBillingPeriod,
                                CreditRate = new()
                                {
                                    Amount = 1,
                                    CurrencyID = "currencyId",
                                    CostFormula = "costFormula",
                                },
                                Currency = Contracts::PriceOverrideCurrency.Usd,
                                FeatureID = "featureId",
                                Tiers =
                                [
                                    new()
                                    {
                                        FlatPrice = new()
                                        {
                                            Amount = 0,
                                            Currency = Contracts::FlatPriceCurrency.Usd,
                                        },
                                        UnitPrice = new()
                                        {
                                            Amount = 0,
                                            Currency = Contracts::UnitPriceCurrency.Usd,
                                        },
                                        UpTo = 0,
                                    },
                                ],
                            },
                        ],
                        ResourceID = "resourceId",
                        SalesforceID = "salesforceId",
                        ScheduleStrategy = Contracts::ScheduleStrategy.EndOfBillingPeriod,
                        StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        TrialOverrideConfiguration = new()
                        {
                            IsTrial = true,
                            TrialEndBehavior = Contracts::TrialEndBehavior.ConvertToPaid,
                            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        },
                        UnitQuantity = 0,
                    },
                },
            ],
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.stigg.io/api/v1/contracts"), url));
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        Contracts::ContractCreateParams parameters = new()
        {
            CustomerID = "customerId",
            Subscriptions =
            [
                new()
                {
                    ExistingSubscriptionID = "existingSubscriptionId",
                    NewSubscription = new()
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
                                    new() { Amount = 0, Currency = Contracts::Currency.Usd },
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
                        BillingCycleAnchor = Contracts::BillingCycleAnchor.Unchanged,
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
                            ProrationBehavior = Contracts::ProrationBehavior.InvoiceImmediately,
                            TaxIds = [new() { Type = "type", Value = "value" }],
                            TaxPercentage = 0,
                            TaxRateIds = ["string"],
                        },
                        BillingPeriod = Contracts::BillingPeriod.Monthly,
                        Budget = new() { HasSoftLimit = true, Limit = 0 },
                        CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Charges =
                        [
                            new()
                            {
                                ID = "id",
                                Quantity = 0,
                                Type = Contracts::Type.Feature,
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
                            new Contracts::Feature()
                            {
                                ID = "id",
                                HasSoftLimit = true,
                                HasUnlimitedUsage = true,
                                MonthlyResetPeriodConfiguration = new(
                                    Contracts::AccordingTo.SubscriptionStart
                                ),
                                ResetPeriod = Contracts::ResetPeriod.Year,
                                UsageLimit = 0,
                                WeeklyResetPeriodConfiguration = new(
                                    Contracts::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                                ),
                                YearlyResetPeriodConfiguration = new(
                                    Contracts::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                                ),
                            },
                        ],
                        Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                        MinimumSpend = new()
                        {
                            Amount = 0,
                            Currency = Contracts::MinimumSpendCurrency.Usd,
                        },
                        PayingCustomerID = "payingCustomerId",
                        PaymentCollectionMethod = Contracts::PaymentCollectionMethod.Charge,
                        PriceOverrides =
                        [
                            new()
                            {
                                AddonID = "addonId",
                                Amount = 0,
                                BaseCharge = true,
                                BillingCountryCode = "billingCountryCode",
                                BlockSize = 0,
                                CreditGrantCadence =
                                    Contracts::CreditGrantCadence.BeginningOfBillingPeriod,
                                CreditRate = new()
                                {
                                    Amount = 1,
                                    CurrencyID = "currencyId",
                                    CostFormula = "costFormula",
                                },
                                Currency = Contracts::PriceOverrideCurrency.Usd,
                                FeatureID = "featureId",
                                Tiers =
                                [
                                    new()
                                    {
                                        FlatPrice = new()
                                        {
                                            Amount = 0,
                                            Currency = Contracts::FlatPriceCurrency.Usd,
                                        },
                                        UnitPrice = new()
                                        {
                                            Amount = 0,
                                            Currency = Contracts::UnitPriceCurrency.Usd,
                                        },
                                        UpTo = 0,
                                    },
                                ],
                            },
                        ],
                        ResourceID = "resourceId",
                        SalesforceID = "salesforceId",
                        ScheduleStrategy = Contracts::ScheduleStrategy.EndOfBillingPeriod,
                        StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        TrialOverrideConfiguration = new()
                        {
                            IsTrial = true,
                            TrialEndBehavior = Contracts::TrialEndBehavior.ConvertToPaid,
                            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        },
                        UnitQuantity = 0,
                    },
                },
            ],
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
        var parameters = new Contracts::ContractCreateParams
        {
            CustomerID = "customerId",
            Subscriptions =
            [
                new()
                {
                    ExistingSubscriptionID = "existingSubscriptionId",
                    NewSubscription = new()
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
                                    new() { Amount = 0, Currency = Contracts::Currency.Usd },
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
                        BillingCycleAnchor = Contracts::BillingCycleAnchor.Unchanged,
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
                            ProrationBehavior = Contracts::ProrationBehavior.InvoiceImmediately,
                            TaxIds = [new() { Type = "type", Value = "value" }],
                            TaxPercentage = 0,
                            TaxRateIds = ["string"],
                        },
                        BillingPeriod = Contracts::BillingPeriod.Monthly,
                        Budget = new() { HasSoftLimit = true, Limit = 0 },
                        CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Charges =
                        [
                            new()
                            {
                                ID = "id",
                                Quantity = 0,
                                Type = Contracts::Type.Feature,
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
                            new Contracts::Feature()
                            {
                                ID = "id",
                                HasSoftLimit = true,
                                HasUnlimitedUsage = true,
                                MonthlyResetPeriodConfiguration = new(
                                    Contracts::AccordingTo.SubscriptionStart
                                ),
                                ResetPeriod = Contracts::ResetPeriod.Year,
                                UsageLimit = 0,
                                WeeklyResetPeriodConfiguration = new(
                                    Contracts::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                                ),
                                YearlyResetPeriodConfiguration = new(
                                    Contracts::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                                ),
                            },
                        ],
                        Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                        MinimumSpend = new()
                        {
                            Amount = 0,
                            Currency = Contracts::MinimumSpendCurrency.Usd,
                        },
                        PayingCustomerID = "payingCustomerId",
                        PaymentCollectionMethod = Contracts::PaymentCollectionMethod.Charge,
                        PriceOverrides =
                        [
                            new()
                            {
                                AddonID = "addonId",
                                Amount = 0,
                                BaseCharge = true,
                                BillingCountryCode = "billingCountryCode",
                                BlockSize = 0,
                                CreditGrantCadence =
                                    Contracts::CreditGrantCadence.BeginningOfBillingPeriod,
                                CreditRate = new()
                                {
                                    Amount = 1,
                                    CurrencyID = "currencyId",
                                    CostFormula = "costFormula",
                                },
                                Currency = Contracts::PriceOverrideCurrency.Usd,
                                FeatureID = "featureId",
                                Tiers =
                                [
                                    new()
                                    {
                                        FlatPrice = new()
                                        {
                                            Amount = 0,
                                            Currency = Contracts::FlatPriceCurrency.Usd,
                                        },
                                        UnitPrice = new()
                                        {
                                            Amount = 0,
                                            Currency = Contracts::UnitPriceCurrency.Usd,
                                        },
                                        UpTo = 0,
                                    },
                                ],
                            },
                        ],
                        ResourceID = "resourceId",
                        SalesforceID = "salesforceId",
                        ScheduleStrategy = Contracts::ScheduleStrategy.EndOfBillingPeriod,
                        StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        TrialOverrideConfiguration = new()
                        {
                            IsTrial = true,
                            TrialEndBehavior = Contracts::TrialEndBehavior.ConvertToPaid,
                            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        },
                        UnitQuantity = 0,
                    },
                },
            ],
            ActivationEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ActivationStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "name",
            PoNumber = "poNumber",
            SetupBilling = true,
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        Contracts::ContractCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class SubscriptionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Contracts::Subscription
        {
            ExistingSubscriptionID = "existingSubscriptionId",
            NewSubscription = new()
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
                        AmountsOff = [new() { Amount = 0, Currency = Contracts::Currency.Usd }],
                        Description = "description",
                        DurationInMonths = 1,
                        Name = "name",
                        PercentOff = 1,
                    },
                    PromotionCode = "promotionCode",
                },
                AwaitPaymentConfirmation = true,
                BillingCountryCode = "billingCountryCode",
                BillingCycleAnchor = Contracts::BillingCycleAnchor.Unchanged,
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
                    ProrationBehavior = Contracts::ProrationBehavior.InvoiceImmediately,
                    TaxIds = [new() { Type = "type", Value = "value" }],
                    TaxPercentage = 0,
                    TaxRateIds = ["string"],
                },
                BillingPeriod = Contracts::BillingPeriod.Monthly,
                Budget = new() { HasSoftLimit = true, Limit = 0 },
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Charges =
                [
                    new()
                    {
                        ID = "id",
                        Quantity = 0,
                        Type = Contracts::Type.Feature,
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
                    new Contracts::Feature()
                    {
                        ID = "id",
                        HasSoftLimit = true,
                        HasUnlimitedUsage = true,
                        MonthlyResetPeriodConfiguration = new(
                            Contracts::AccordingTo.SubscriptionStart
                        ),
                        ResetPeriod = Contracts::ResetPeriod.Year,
                        UsageLimit = 0,
                        WeeklyResetPeriodConfiguration = new(
                            Contracts::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                        ),
                        YearlyResetPeriodConfiguration = new(
                            Contracts::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                        ),
                    },
                ],
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MinimumSpend = new() { Amount = 0, Currency = Contracts::MinimumSpendCurrency.Usd },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod = Contracts::PaymentCollectionMethod.Charge,
                PriceOverrides =
                [
                    new()
                    {
                        AddonID = "addonId",
                        Amount = 0,
                        BaseCharge = true,
                        BillingCountryCode = "billingCountryCode",
                        BlockSize = 0,
                        CreditGrantCadence = Contracts::CreditGrantCadence.BeginningOfBillingPeriod,
                        CreditRate = new()
                        {
                            Amount = 1,
                            CurrencyID = "currencyId",
                            CostFormula = "costFormula",
                        },
                        Currency = Contracts::PriceOverrideCurrency.Usd,
                        FeatureID = "featureId",
                        Tiers =
                        [
                            new()
                            {
                                FlatPrice = new()
                                {
                                    Amount = 0,
                                    Currency = Contracts::FlatPriceCurrency.Usd,
                                },
                                UnitPrice = new()
                                {
                                    Amount = 0,
                                    Currency = Contracts::UnitPriceCurrency.Usd,
                                },
                                UpTo = 0,
                            },
                        ],
                    },
                ],
                ResourceID = "resourceId",
                SalesforceID = "salesforceId",
                ScheduleStrategy = Contracts::ScheduleStrategy.EndOfBillingPeriod,
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                TrialOverrideConfiguration = new()
                {
                    IsTrial = true,
                    TrialEndBehavior = Contracts::TrialEndBehavior.ConvertToPaid,
                    TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                UnitQuantity = 0,
            },
        };

        string expectedExistingSubscriptionID = "existingSubscriptionId";
        Contracts::NewSubscription expectedNewSubscription = new()
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
                    AmountsOff = [new() { Amount = 0, Currency = Contracts::Currency.Usd }],
                    Description = "description",
                    DurationInMonths = 1,
                    Name = "name",
                    PercentOff = 1,
                },
                PromotionCode = "promotionCode",
            },
            AwaitPaymentConfirmation = true,
            BillingCountryCode = "billingCountryCode",
            BillingCycleAnchor = Contracts::BillingCycleAnchor.Unchanged,
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
                ProrationBehavior = Contracts::ProrationBehavior.InvoiceImmediately,
                TaxIds = [new() { Type = "type", Value = "value" }],
                TaxPercentage = 0,
                TaxRateIds = ["string"],
            },
            BillingPeriod = Contracts::BillingPeriod.Monthly,
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Charges =
            [
                new()
                {
                    ID = "id",
                    Quantity = 0,
                    Type = Contracts::Type.Feature,
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
                new Contracts::Feature()
                {
                    ID = "id",
                    HasSoftLimit = true,
                    HasUnlimitedUsage = true,
                    MonthlyResetPeriodConfiguration = new(Contracts::AccordingTo.SubscriptionStart),
                    ResetPeriod = Contracts::ResetPeriod.Year,
                    UsageLimit = 0,
                    WeeklyResetPeriodConfiguration = new(
                        Contracts::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    YearlyResetPeriodConfiguration = new(
                        Contracts::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MinimumSpend = new() { Amount = 0, Currency = Contracts::MinimumSpendCurrency.Usd },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod = Contracts::PaymentCollectionMethod.Charge,
            PriceOverrides =
            [
                new()
                {
                    AddonID = "addonId",
                    Amount = 0,
                    BaseCharge = true,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    CreditGrantCadence = Contracts::CreditGrantCadence.BeginningOfBillingPeriod,
                    CreditRate = new()
                    {
                        Amount = 1,
                        CurrencyID = "currencyId",
                        CostFormula = "costFormula",
                    },
                    Currency = Contracts::PriceOverrideCurrency.Usd,
                    FeatureID = "featureId",
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency = Contracts::FlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency = Contracts::UnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            ResourceID = "resourceId",
            SalesforceID = "salesforceId",
            ScheduleStrategy = Contracts::ScheduleStrategy.EndOfBillingPeriod,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TrialOverrideConfiguration = new()
            {
                IsTrial = true,
                TrialEndBehavior = Contracts::TrialEndBehavior.ConvertToPaid,
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            UnitQuantity = 0,
        };

        Assert.Equal(expectedExistingSubscriptionID, model.ExistingSubscriptionID);
        Assert.Equal(expectedNewSubscription, model.NewSubscription);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Contracts::Subscription
        {
            ExistingSubscriptionID = "existingSubscriptionId",
            NewSubscription = new()
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
                        AmountsOff = [new() { Amount = 0, Currency = Contracts::Currency.Usd }],
                        Description = "description",
                        DurationInMonths = 1,
                        Name = "name",
                        PercentOff = 1,
                    },
                    PromotionCode = "promotionCode",
                },
                AwaitPaymentConfirmation = true,
                BillingCountryCode = "billingCountryCode",
                BillingCycleAnchor = Contracts::BillingCycleAnchor.Unchanged,
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
                    ProrationBehavior = Contracts::ProrationBehavior.InvoiceImmediately,
                    TaxIds = [new() { Type = "type", Value = "value" }],
                    TaxPercentage = 0,
                    TaxRateIds = ["string"],
                },
                BillingPeriod = Contracts::BillingPeriod.Monthly,
                Budget = new() { HasSoftLimit = true, Limit = 0 },
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Charges =
                [
                    new()
                    {
                        ID = "id",
                        Quantity = 0,
                        Type = Contracts::Type.Feature,
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
                    new Contracts::Feature()
                    {
                        ID = "id",
                        HasSoftLimit = true,
                        HasUnlimitedUsage = true,
                        MonthlyResetPeriodConfiguration = new(
                            Contracts::AccordingTo.SubscriptionStart
                        ),
                        ResetPeriod = Contracts::ResetPeriod.Year,
                        UsageLimit = 0,
                        WeeklyResetPeriodConfiguration = new(
                            Contracts::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                        ),
                        YearlyResetPeriodConfiguration = new(
                            Contracts::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                        ),
                    },
                ],
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MinimumSpend = new() { Amount = 0, Currency = Contracts::MinimumSpendCurrency.Usd },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod = Contracts::PaymentCollectionMethod.Charge,
                PriceOverrides =
                [
                    new()
                    {
                        AddonID = "addonId",
                        Amount = 0,
                        BaseCharge = true,
                        BillingCountryCode = "billingCountryCode",
                        BlockSize = 0,
                        CreditGrantCadence = Contracts::CreditGrantCadence.BeginningOfBillingPeriod,
                        CreditRate = new()
                        {
                            Amount = 1,
                            CurrencyID = "currencyId",
                            CostFormula = "costFormula",
                        },
                        Currency = Contracts::PriceOverrideCurrency.Usd,
                        FeatureID = "featureId",
                        Tiers =
                        [
                            new()
                            {
                                FlatPrice = new()
                                {
                                    Amount = 0,
                                    Currency = Contracts::FlatPriceCurrency.Usd,
                                },
                                UnitPrice = new()
                                {
                                    Amount = 0,
                                    Currency = Contracts::UnitPriceCurrency.Usd,
                                },
                                UpTo = 0,
                            },
                        ],
                    },
                ],
                ResourceID = "resourceId",
                SalesforceID = "salesforceId",
                ScheduleStrategy = Contracts::ScheduleStrategy.EndOfBillingPeriod,
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                TrialOverrideConfiguration = new()
                {
                    IsTrial = true,
                    TrialEndBehavior = Contracts::TrialEndBehavior.ConvertToPaid,
                    TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                UnitQuantity = 0,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Contracts::Subscription>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Contracts::Subscription
        {
            ExistingSubscriptionID = "existingSubscriptionId",
            NewSubscription = new()
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
                        AmountsOff = [new() { Amount = 0, Currency = Contracts::Currency.Usd }],
                        Description = "description",
                        DurationInMonths = 1,
                        Name = "name",
                        PercentOff = 1,
                    },
                    PromotionCode = "promotionCode",
                },
                AwaitPaymentConfirmation = true,
                BillingCountryCode = "billingCountryCode",
                BillingCycleAnchor = Contracts::BillingCycleAnchor.Unchanged,
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
                    ProrationBehavior = Contracts::ProrationBehavior.InvoiceImmediately,
                    TaxIds = [new() { Type = "type", Value = "value" }],
                    TaxPercentage = 0,
                    TaxRateIds = ["string"],
                },
                BillingPeriod = Contracts::BillingPeriod.Monthly,
                Budget = new() { HasSoftLimit = true, Limit = 0 },
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Charges =
                [
                    new()
                    {
                        ID = "id",
                        Quantity = 0,
                        Type = Contracts::Type.Feature,
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
                    new Contracts::Feature()
                    {
                        ID = "id",
                        HasSoftLimit = true,
                        HasUnlimitedUsage = true,
                        MonthlyResetPeriodConfiguration = new(
                            Contracts::AccordingTo.SubscriptionStart
                        ),
                        ResetPeriod = Contracts::ResetPeriod.Year,
                        UsageLimit = 0,
                        WeeklyResetPeriodConfiguration = new(
                            Contracts::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                        ),
                        YearlyResetPeriodConfiguration = new(
                            Contracts::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                        ),
                    },
                ],
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MinimumSpend = new() { Amount = 0, Currency = Contracts::MinimumSpendCurrency.Usd },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod = Contracts::PaymentCollectionMethod.Charge,
                PriceOverrides =
                [
                    new()
                    {
                        AddonID = "addonId",
                        Amount = 0,
                        BaseCharge = true,
                        BillingCountryCode = "billingCountryCode",
                        BlockSize = 0,
                        CreditGrantCadence = Contracts::CreditGrantCadence.BeginningOfBillingPeriod,
                        CreditRate = new()
                        {
                            Amount = 1,
                            CurrencyID = "currencyId",
                            CostFormula = "costFormula",
                        },
                        Currency = Contracts::PriceOverrideCurrency.Usd,
                        FeatureID = "featureId",
                        Tiers =
                        [
                            new()
                            {
                                FlatPrice = new()
                                {
                                    Amount = 0,
                                    Currency = Contracts::FlatPriceCurrency.Usd,
                                },
                                UnitPrice = new()
                                {
                                    Amount = 0,
                                    Currency = Contracts::UnitPriceCurrency.Usd,
                                },
                                UpTo = 0,
                            },
                        ],
                    },
                ],
                ResourceID = "resourceId",
                SalesforceID = "salesforceId",
                ScheduleStrategy = Contracts::ScheduleStrategy.EndOfBillingPeriod,
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                TrialOverrideConfiguration = new()
                {
                    IsTrial = true,
                    TrialEndBehavior = Contracts::TrialEndBehavior.ConvertToPaid,
                    TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                UnitQuantity = 0,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Contracts::Subscription>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedExistingSubscriptionID = "existingSubscriptionId";
        Contracts::NewSubscription expectedNewSubscription = new()
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
                    AmountsOff = [new() { Amount = 0, Currency = Contracts::Currency.Usd }],
                    Description = "description",
                    DurationInMonths = 1,
                    Name = "name",
                    PercentOff = 1,
                },
                PromotionCode = "promotionCode",
            },
            AwaitPaymentConfirmation = true,
            BillingCountryCode = "billingCountryCode",
            BillingCycleAnchor = Contracts::BillingCycleAnchor.Unchanged,
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
                ProrationBehavior = Contracts::ProrationBehavior.InvoiceImmediately,
                TaxIds = [new() { Type = "type", Value = "value" }],
                TaxPercentage = 0,
                TaxRateIds = ["string"],
            },
            BillingPeriod = Contracts::BillingPeriod.Monthly,
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Charges =
            [
                new()
                {
                    ID = "id",
                    Quantity = 0,
                    Type = Contracts::Type.Feature,
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
                new Contracts::Feature()
                {
                    ID = "id",
                    HasSoftLimit = true,
                    HasUnlimitedUsage = true,
                    MonthlyResetPeriodConfiguration = new(Contracts::AccordingTo.SubscriptionStart),
                    ResetPeriod = Contracts::ResetPeriod.Year,
                    UsageLimit = 0,
                    WeeklyResetPeriodConfiguration = new(
                        Contracts::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    YearlyResetPeriodConfiguration = new(
                        Contracts::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MinimumSpend = new() { Amount = 0, Currency = Contracts::MinimumSpendCurrency.Usd },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod = Contracts::PaymentCollectionMethod.Charge,
            PriceOverrides =
            [
                new()
                {
                    AddonID = "addonId",
                    Amount = 0,
                    BaseCharge = true,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    CreditGrantCadence = Contracts::CreditGrantCadence.BeginningOfBillingPeriod,
                    CreditRate = new()
                    {
                        Amount = 1,
                        CurrencyID = "currencyId",
                        CostFormula = "costFormula",
                    },
                    Currency = Contracts::PriceOverrideCurrency.Usd,
                    FeatureID = "featureId",
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency = Contracts::FlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency = Contracts::UnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            ResourceID = "resourceId",
            SalesforceID = "salesforceId",
            ScheduleStrategy = Contracts::ScheduleStrategy.EndOfBillingPeriod,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TrialOverrideConfiguration = new()
            {
                IsTrial = true,
                TrialEndBehavior = Contracts::TrialEndBehavior.ConvertToPaid,
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            UnitQuantity = 0,
        };

        Assert.Equal(expectedExistingSubscriptionID, deserialized.ExistingSubscriptionID);
        Assert.Equal(expectedNewSubscription, deserialized.NewSubscription);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Contracts::Subscription
        {
            ExistingSubscriptionID = "existingSubscriptionId",
            NewSubscription = new()
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
                        AmountsOff = [new() { Amount = 0, Currency = Contracts::Currency.Usd }],
                        Description = "description",
                        DurationInMonths = 1,
                        Name = "name",
                        PercentOff = 1,
                    },
                    PromotionCode = "promotionCode",
                },
                AwaitPaymentConfirmation = true,
                BillingCountryCode = "billingCountryCode",
                BillingCycleAnchor = Contracts::BillingCycleAnchor.Unchanged,
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
                    ProrationBehavior = Contracts::ProrationBehavior.InvoiceImmediately,
                    TaxIds = [new() { Type = "type", Value = "value" }],
                    TaxPercentage = 0,
                    TaxRateIds = ["string"],
                },
                BillingPeriod = Contracts::BillingPeriod.Monthly,
                Budget = new() { HasSoftLimit = true, Limit = 0 },
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Charges =
                [
                    new()
                    {
                        ID = "id",
                        Quantity = 0,
                        Type = Contracts::Type.Feature,
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
                    new Contracts::Feature()
                    {
                        ID = "id",
                        HasSoftLimit = true,
                        HasUnlimitedUsage = true,
                        MonthlyResetPeriodConfiguration = new(
                            Contracts::AccordingTo.SubscriptionStart
                        ),
                        ResetPeriod = Contracts::ResetPeriod.Year,
                        UsageLimit = 0,
                        WeeklyResetPeriodConfiguration = new(
                            Contracts::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                        ),
                        YearlyResetPeriodConfiguration = new(
                            Contracts::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                        ),
                    },
                ],
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MinimumSpend = new() { Amount = 0, Currency = Contracts::MinimumSpendCurrency.Usd },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod = Contracts::PaymentCollectionMethod.Charge,
                PriceOverrides =
                [
                    new()
                    {
                        AddonID = "addonId",
                        Amount = 0,
                        BaseCharge = true,
                        BillingCountryCode = "billingCountryCode",
                        BlockSize = 0,
                        CreditGrantCadence = Contracts::CreditGrantCadence.BeginningOfBillingPeriod,
                        CreditRate = new()
                        {
                            Amount = 1,
                            CurrencyID = "currencyId",
                            CostFormula = "costFormula",
                        },
                        Currency = Contracts::PriceOverrideCurrency.Usd,
                        FeatureID = "featureId",
                        Tiers =
                        [
                            new()
                            {
                                FlatPrice = new()
                                {
                                    Amount = 0,
                                    Currency = Contracts::FlatPriceCurrency.Usd,
                                },
                                UnitPrice = new()
                                {
                                    Amount = 0,
                                    Currency = Contracts::UnitPriceCurrency.Usd,
                                },
                                UpTo = 0,
                            },
                        ],
                    },
                ],
                ResourceID = "resourceId",
                SalesforceID = "salesforceId",
                ScheduleStrategy = Contracts::ScheduleStrategy.EndOfBillingPeriod,
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                TrialOverrideConfiguration = new()
                {
                    IsTrial = true,
                    TrialEndBehavior = Contracts::TrialEndBehavior.ConvertToPaid,
                    TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                UnitQuantity = 0,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Contracts::Subscription { };

        Assert.Null(model.ExistingSubscriptionID);
        Assert.False(model.RawData.ContainsKey("existingSubscriptionId"));
        Assert.Null(model.NewSubscription);
        Assert.False(model.RawData.ContainsKey("newSubscription"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Contracts::Subscription { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Contracts::Subscription
        {
            // Null should be interpreted as omitted for these properties
            ExistingSubscriptionID = null,
            NewSubscription = null,
        };

        Assert.Null(model.ExistingSubscriptionID);
        Assert.False(model.RawData.ContainsKey("existingSubscriptionId"));
        Assert.Null(model.NewSubscription);
        Assert.False(model.RawData.ContainsKey("newSubscription"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Contracts::Subscription
        {
            // Null should be interpreted as omitted for these properties
            ExistingSubscriptionID = null,
            NewSubscription = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Contracts::Subscription
        {
            ExistingSubscriptionID = "existingSubscriptionId",
            NewSubscription = new()
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
                        AmountsOff = [new() { Amount = 0, Currency = Contracts::Currency.Usd }],
                        Description = "description",
                        DurationInMonths = 1,
                        Name = "name",
                        PercentOff = 1,
                    },
                    PromotionCode = "promotionCode",
                },
                AwaitPaymentConfirmation = true,
                BillingCountryCode = "billingCountryCode",
                BillingCycleAnchor = Contracts::BillingCycleAnchor.Unchanged,
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
                    ProrationBehavior = Contracts::ProrationBehavior.InvoiceImmediately,
                    TaxIds = [new() { Type = "type", Value = "value" }],
                    TaxPercentage = 0,
                    TaxRateIds = ["string"],
                },
                BillingPeriod = Contracts::BillingPeriod.Monthly,
                Budget = new() { HasSoftLimit = true, Limit = 0 },
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Charges =
                [
                    new()
                    {
                        ID = "id",
                        Quantity = 0,
                        Type = Contracts::Type.Feature,
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
                    new Contracts::Feature()
                    {
                        ID = "id",
                        HasSoftLimit = true,
                        HasUnlimitedUsage = true,
                        MonthlyResetPeriodConfiguration = new(
                            Contracts::AccordingTo.SubscriptionStart
                        ),
                        ResetPeriod = Contracts::ResetPeriod.Year,
                        UsageLimit = 0,
                        WeeklyResetPeriodConfiguration = new(
                            Contracts::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                        ),
                        YearlyResetPeriodConfiguration = new(
                            Contracts::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                        ),
                    },
                ],
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MinimumSpend = new() { Amount = 0, Currency = Contracts::MinimumSpendCurrency.Usd },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod = Contracts::PaymentCollectionMethod.Charge,
                PriceOverrides =
                [
                    new()
                    {
                        AddonID = "addonId",
                        Amount = 0,
                        BaseCharge = true,
                        BillingCountryCode = "billingCountryCode",
                        BlockSize = 0,
                        CreditGrantCadence = Contracts::CreditGrantCadence.BeginningOfBillingPeriod,
                        CreditRate = new()
                        {
                            Amount = 1,
                            CurrencyID = "currencyId",
                            CostFormula = "costFormula",
                        },
                        Currency = Contracts::PriceOverrideCurrency.Usd,
                        FeatureID = "featureId",
                        Tiers =
                        [
                            new()
                            {
                                FlatPrice = new()
                                {
                                    Amount = 0,
                                    Currency = Contracts::FlatPriceCurrency.Usd,
                                },
                                UnitPrice = new()
                                {
                                    Amount = 0,
                                    Currency = Contracts::UnitPriceCurrency.Usd,
                                },
                                UpTo = 0,
                            },
                        ],
                    },
                ],
                ResourceID = "resourceId",
                SalesforceID = "salesforceId",
                ScheduleStrategy = Contracts::ScheduleStrategy.EndOfBillingPeriod,
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                TrialOverrideConfiguration = new()
                {
                    IsTrial = true,
                    TrialEndBehavior = Contracts::TrialEndBehavior.ConvertToPaid,
                    TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                UnitQuantity = 0,
            },
        };

        Contracts::Subscription copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class NewSubscriptionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Contracts::NewSubscription
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
                    AmountsOff = [new() { Amount = 0, Currency = Contracts::Currency.Usd }],
                    Description = "description",
                    DurationInMonths = 1,
                    Name = "name",
                    PercentOff = 1,
                },
                PromotionCode = "promotionCode",
            },
            AwaitPaymentConfirmation = true,
            BillingCountryCode = "billingCountryCode",
            BillingCycleAnchor = Contracts::BillingCycleAnchor.Unchanged,
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
                ProrationBehavior = Contracts::ProrationBehavior.InvoiceImmediately,
                TaxIds = [new() { Type = "type", Value = "value" }],
                TaxPercentage = 0,
                TaxRateIds = ["string"],
            },
            BillingPeriod = Contracts::BillingPeriod.Monthly,
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Charges =
            [
                new()
                {
                    ID = "id",
                    Quantity = 0,
                    Type = Contracts::Type.Feature,
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
                new Contracts::Feature()
                {
                    ID = "id",
                    HasSoftLimit = true,
                    HasUnlimitedUsage = true,
                    MonthlyResetPeriodConfiguration = new(Contracts::AccordingTo.SubscriptionStart),
                    ResetPeriod = Contracts::ResetPeriod.Year,
                    UsageLimit = 0,
                    WeeklyResetPeriodConfiguration = new(
                        Contracts::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    YearlyResetPeriodConfiguration = new(
                        Contracts::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MinimumSpend = new() { Amount = 0, Currency = Contracts::MinimumSpendCurrency.Usd },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod = Contracts::PaymentCollectionMethod.Charge,
            PriceOverrides =
            [
                new()
                {
                    AddonID = "addonId",
                    Amount = 0,
                    BaseCharge = true,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    CreditGrantCadence = Contracts::CreditGrantCadence.BeginningOfBillingPeriod,
                    CreditRate = new()
                    {
                        Amount = 1,
                        CurrencyID = "currencyId",
                        CostFormula = "costFormula",
                    },
                    Currency = Contracts::PriceOverrideCurrency.Usd,
                    FeatureID = "featureId",
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency = Contracts::FlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency = Contracts::UnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            ResourceID = "resourceId",
            SalesforceID = "salesforceId",
            ScheduleStrategy = Contracts::ScheduleStrategy.EndOfBillingPeriod,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TrialOverrideConfiguration = new()
            {
                IsTrial = true,
                TrialEndBehavior = Contracts::TrialEndBehavior.ConvertToPaid,
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            UnitQuantity = 0,
        };

        string expectedCustomerID = "customerId";
        string expectedPlanID = "planId";
        string expectedID = "id";
        List<Contracts::Addon> expectedAddons = [new() { ID = "id", Quantity = 0 }];
        Contracts::AppliedCoupon expectedAppliedCoupon = new()
        {
            BillingCouponID = "billingCouponId",
            Configuration = new() { StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z") },
            CouponID = "couponId",
            Discount = new()
            {
                AmountsOff = [new() { Amount = 0, Currency = Contracts::Currency.Usd }],
                Description = "description",
                DurationInMonths = 1,
                Name = "name",
                PercentOff = 1,
            },
            PromotionCode = "promotionCode",
        };
        bool expectedAwaitPaymentConfirmation = true;
        string expectedBillingCountryCode = "billingCountryCode";
        ApiEnum<string, Contracts::BillingCycleAnchor> expectedBillingCycleAnchor =
            Contracts::BillingCycleAnchor.Unchanged;
        string expectedBillingID = "billingId";
        Contracts::BillingInformation expectedBillingInformation = new()
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
            ProrationBehavior = Contracts::ProrationBehavior.InvoiceImmediately,
            TaxIds = [new() { Type = "type", Value = "value" }],
            TaxPercentage = 0,
            TaxRateIds = ["string"],
        };
        ApiEnum<string, Contracts::BillingPeriod> expectedBillingPeriod =
            Contracts::BillingPeriod.Monthly;
        Contracts::Budget expectedBudget = new() { HasSoftLimit = true, Limit = 0 };
        DateTimeOffset expectedCancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<Contracts::Charge> expectedCharges =
        [
            new()
            {
                ID = "id",
                Quantity = 0,
                Type = Contracts::Type.Feature,
            },
        ];
        Contracts::CheckoutOptions expectedCheckoutOptions = new()
        {
            CancelUrl = "https://example.com",
            SuccessUrl = "https://example.com",
            AllowPromoCodes = true,
            AllowTaxIDCollection = true,
            CollectBillingAddress = true,
            CollectPhoneNumber = true,
            ReferenceID = "referenceId",
        };
        List<Contracts::Entitlement> expectedEntitlements =
        [
            new Contracts::Feature()
            {
                ID = "id",
                HasSoftLimit = true,
                HasUnlimitedUsage = true,
                MonthlyResetPeriodConfiguration = new(Contracts::AccordingTo.SubscriptionStart),
                ResetPeriod = Contracts::ResetPeriod.Year,
                UsageLimit = 0,
                WeeklyResetPeriodConfiguration = new(
                    Contracts::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
                YearlyResetPeriodConfiguration = new(
                    Contracts::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
            },
        ];
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        Contracts::MinimumSpend expectedMinimumSpend = new()
        {
            Amount = 0,
            Currency = Contracts::MinimumSpendCurrency.Usd,
        };
        string expectedPayingCustomerID = "payingCustomerId";
        ApiEnum<string, Contracts::PaymentCollectionMethod> expectedPaymentCollectionMethod =
            Contracts::PaymentCollectionMethod.Charge;
        List<Contracts::PriceOverride> expectedPriceOverrides =
        [
            new()
            {
                AddonID = "addonId",
                Amount = 0,
                BaseCharge = true,
                BillingCountryCode = "billingCountryCode",
                BlockSize = 0,
                CreditGrantCadence = Contracts::CreditGrantCadence.BeginningOfBillingPeriod,
                CreditRate = new()
                {
                    Amount = 1,
                    CurrencyID = "currencyId",
                    CostFormula = "costFormula",
                },
                Currency = Contracts::PriceOverrideCurrency.Usd,
                FeatureID = "featureId",
                Tiers =
                [
                    new()
                    {
                        FlatPrice = new()
                        {
                            Amount = 0,
                            Currency = Contracts::FlatPriceCurrency.Usd,
                        },
                        UnitPrice = new()
                        {
                            Amount = 0,
                            Currency = Contracts::UnitPriceCurrency.Usd,
                        },
                        UpTo = 0,
                    },
                ],
            },
        ];
        string expectedResourceID = "resourceId";
        string expectedSalesforceID = "salesforceId";
        ApiEnum<string, Contracts::ScheduleStrategy> expectedScheduleStrategy =
            Contracts::ScheduleStrategy.EndOfBillingPeriod;
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Contracts::TrialOverrideConfiguration expectedTrialOverrideConfiguration = new()
        {
            IsTrial = true,
            TrialEndBehavior = Contracts::TrialEndBehavior.ConvertToPaid,
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        long expectedUnitQuantity = 0;

        Assert.Equal(expectedCustomerID, model.CustomerID);
        Assert.Equal(expectedPlanID, model.PlanID);
        Assert.Equal(expectedID, model.ID);
        Assert.NotNull(model.Addons);
        Assert.Equal(expectedAddons.Count, model.Addons.Count);
        for (int i = 0; i < expectedAddons.Count; i++)
        {
            Assert.Equal(expectedAddons[i], model.Addons[i]);
        }
        Assert.Equal(expectedAppliedCoupon, model.AppliedCoupon);
        Assert.Equal(expectedAwaitPaymentConfirmation, model.AwaitPaymentConfirmation);
        Assert.Equal(expectedBillingCountryCode, model.BillingCountryCode);
        Assert.Equal(expectedBillingCycleAnchor, model.BillingCycleAnchor);
        Assert.Equal(expectedBillingID, model.BillingID);
        Assert.Equal(expectedBillingInformation, model.BillingInformation);
        Assert.Equal(expectedBillingPeriod, model.BillingPeriod);
        Assert.Equal(expectedBudget, model.Budget);
        Assert.Equal(expectedCancellationDate, model.CancellationDate);
        Assert.NotNull(model.Charges);
        Assert.Equal(expectedCharges.Count, model.Charges.Count);
        for (int i = 0; i < expectedCharges.Count; i++)
        {
            Assert.Equal(expectedCharges[i], model.Charges[i]);
        }
        Assert.Equal(expectedCheckoutOptions, model.CheckoutOptions);
        Assert.NotNull(model.Entitlements);
        Assert.Equal(expectedEntitlements.Count, model.Entitlements.Count);
        for (int i = 0; i < expectedEntitlements.Count; i++)
        {
            Assert.Equal(expectedEntitlements[i], model.Entitlements[i]);
        }
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
        Assert.NotNull(model.PriceOverrides);
        Assert.Equal(expectedPriceOverrides.Count, model.PriceOverrides.Count);
        for (int i = 0; i < expectedPriceOverrides.Count; i++)
        {
            Assert.Equal(expectedPriceOverrides[i], model.PriceOverrides[i]);
        }
        Assert.Equal(expectedResourceID, model.ResourceID);
        Assert.Equal(expectedSalesforceID, model.SalesforceID);
        Assert.Equal(expectedScheduleStrategy, model.ScheduleStrategy);
        Assert.Equal(expectedStartDate, model.StartDate);
        Assert.Equal(expectedTrialOverrideConfiguration, model.TrialOverrideConfiguration);
        Assert.Equal(expectedUnitQuantity, model.UnitQuantity);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Contracts::NewSubscription
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
                    AmountsOff = [new() { Amount = 0, Currency = Contracts::Currency.Usd }],
                    Description = "description",
                    DurationInMonths = 1,
                    Name = "name",
                    PercentOff = 1,
                },
                PromotionCode = "promotionCode",
            },
            AwaitPaymentConfirmation = true,
            BillingCountryCode = "billingCountryCode",
            BillingCycleAnchor = Contracts::BillingCycleAnchor.Unchanged,
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
                ProrationBehavior = Contracts::ProrationBehavior.InvoiceImmediately,
                TaxIds = [new() { Type = "type", Value = "value" }],
                TaxPercentage = 0,
                TaxRateIds = ["string"],
            },
            BillingPeriod = Contracts::BillingPeriod.Monthly,
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Charges =
            [
                new()
                {
                    ID = "id",
                    Quantity = 0,
                    Type = Contracts::Type.Feature,
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
                new Contracts::Feature()
                {
                    ID = "id",
                    HasSoftLimit = true,
                    HasUnlimitedUsage = true,
                    MonthlyResetPeriodConfiguration = new(Contracts::AccordingTo.SubscriptionStart),
                    ResetPeriod = Contracts::ResetPeriod.Year,
                    UsageLimit = 0,
                    WeeklyResetPeriodConfiguration = new(
                        Contracts::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    YearlyResetPeriodConfiguration = new(
                        Contracts::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MinimumSpend = new() { Amount = 0, Currency = Contracts::MinimumSpendCurrency.Usd },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod = Contracts::PaymentCollectionMethod.Charge,
            PriceOverrides =
            [
                new()
                {
                    AddonID = "addonId",
                    Amount = 0,
                    BaseCharge = true,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    CreditGrantCadence = Contracts::CreditGrantCadence.BeginningOfBillingPeriod,
                    CreditRate = new()
                    {
                        Amount = 1,
                        CurrencyID = "currencyId",
                        CostFormula = "costFormula",
                    },
                    Currency = Contracts::PriceOverrideCurrency.Usd,
                    FeatureID = "featureId",
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency = Contracts::FlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency = Contracts::UnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            ResourceID = "resourceId",
            SalesforceID = "salesforceId",
            ScheduleStrategy = Contracts::ScheduleStrategy.EndOfBillingPeriod,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TrialOverrideConfiguration = new()
            {
                IsTrial = true,
                TrialEndBehavior = Contracts::TrialEndBehavior.ConvertToPaid,
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            UnitQuantity = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Contracts::NewSubscription>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Contracts::NewSubscription
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
                    AmountsOff = [new() { Amount = 0, Currency = Contracts::Currency.Usd }],
                    Description = "description",
                    DurationInMonths = 1,
                    Name = "name",
                    PercentOff = 1,
                },
                PromotionCode = "promotionCode",
            },
            AwaitPaymentConfirmation = true,
            BillingCountryCode = "billingCountryCode",
            BillingCycleAnchor = Contracts::BillingCycleAnchor.Unchanged,
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
                ProrationBehavior = Contracts::ProrationBehavior.InvoiceImmediately,
                TaxIds = [new() { Type = "type", Value = "value" }],
                TaxPercentage = 0,
                TaxRateIds = ["string"],
            },
            BillingPeriod = Contracts::BillingPeriod.Monthly,
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Charges =
            [
                new()
                {
                    ID = "id",
                    Quantity = 0,
                    Type = Contracts::Type.Feature,
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
                new Contracts::Feature()
                {
                    ID = "id",
                    HasSoftLimit = true,
                    HasUnlimitedUsage = true,
                    MonthlyResetPeriodConfiguration = new(Contracts::AccordingTo.SubscriptionStart),
                    ResetPeriod = Contracts::ResetPeriod.Year,
                    UsageLimit = 0,
                    WeeklyResetPeriodConfiguration = new(
                        Contracts::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    YearlyResetPeriodConfiguration = new(
                        Contracts::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MinimumSpend = new() { Amount = 0, Currency = Contracts::MinimumSpendCurrency.Usd },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod = Contracts::PaymentCollectionMethod.Charge,
            PriceOverrides =
            [
                new()
                {
                    AddonID = "addonId",
                    Amount = 0,
                    BaseCharge = true,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    CreditGrantCadence = Contracts::CreditGrantCadence.BeginningOfBillingPeriod,
                    CreditRate = new()
                    {
                        Amount = 1,
                        CurrencyID = "currencyId",
                        CostFormula = "costFormula",
                    },
                    Currency = Contracts::PriceOverrideCurrency.Usd,
                    FeatureID = "featureId",
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency = Contracts::FlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency = Contracts::UnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            ResourceID = "resourceId",
            SalesforceID = "salesforceId",
            ScheduleStrategy = Contracts::ScheduleStrategy.EndOfBillingPeriod,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TrialOverrideConfiguration = new()
            {
                IsTrial = true,
                TrialEndBehavior = Contracts::TrialEndBehavior.ConvertToPaid,
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            UnitQuantity = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Contracts::NewSubscription>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCustomerID = "customerId";
        string expectedPlanID = "planId";
        string expectedID = "id";
        List<Contracts::Addon> expectedAddons = [new() { ID = "id", Quantity = 0 }];
        Contracts::AppliedCoupon expectedAppliedCoupon = new()
        {
            BillingCouponID = "billingCouponId",
            Configuration = new() { StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z") },
            CouponID = "couponId",
            Discount = new()
            {
                AmountsOff = [new() { Amount = 0, Currency = Contracts::Currency.Usd }],
                Description = "description",
                DurationInMonths = 1,
                Name = "name",
                PercentOff = 1,
            },
            PromotionCode = "promotionCode",
        };
        bool expectedAwaitPaymentConfirmation = true;
        string expectedBillingCountryCode = "billingCountryCode";
        ApiEnum<string, Contracts::BillingCycleAnchor> expectedBillingCycleAnchor =
            Contracts::BillingCycleAnchor.Unchanged;
        string expectedBillingID = "billingId";
        Contracts::BillingInformation expectedBillingInformation = new()
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
            ProrationBehavior = Contracts::ProrationBehavior.InvoiceImmediately,
            TaxIds = [new() { Type = "type", Value = "value" }],
            TaxPercentage = 0,
            TaxRateIds = ["string"],
        };
        ApiEnum<string, Contracts::BillingPeriod> expectedBillingPeriod =
            Contracts::BillingPeriod.Monthly;
        Contracts::Budget expectedBudget = new() { HasSoftLimit = true, Limit = 0 };
        DateTimeOffset expectedCancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<Contracts::Charge> expectedCharges =
        [
            new()
            {
                ID = "id",
                Quantity = 0,
                Type = Contracts::Type.Feature,
            },
        ];
        Contracts::CheckoutOptions expectedCheckoutOptions = new()
        {
            CancelUrl = "https://example.com",
            SuccessUrl = "https://example.com",
            AllowPromoCodes = true,
            AllowTaxIDCollection = true,
            CollectBillingAddress = true,
            CollectPhoneNumber = true,
            ReferenceID = "referenceId",
        };
        List<Contracts::Entitlement> expectedEntitlements =
        [
            new Contracts::Feature()
            {
                ID = "id",
                HasSoftLimit = true,
                HasUnlimitedUsage = true,
                MonthlyResetPeriodConfiguration = new(Contracts::AccordingTo.SubscriptionStart),
                ResetPeriod = Contracts::ResetPeriod.Year,
                UsageLimit = 0,
                WeeklyResetPeriodConfiguration = new(
                    Contracts::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
                YearlyResetPeriodConfiguration = new(
                    Contracts::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
            },
        ];
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        Contracts::MinimumSpend expectedMinimumSpend = new()
        {
            Amount = 0,
            Currency = Contracts::MinimumSpendCurrency.Usd,
        };
        string expectedPayingCustomerID = "payingCustomerId";
        ApiEnum<string, Contracts::PaymentCollectionMethod> expectedPaymentCollectionMethod =
            Contracts::PaymentCollectionMethod.Charge;
        List<Contracts::PriceOverride> expectedPriceOverrides =
        [
            new()
            {
                AddonID = "addonId",
                Amount = 0,
                BaseCharge = true,
                BillingCountryCode = "billingCountryCode",
                BlockSize = 0,
                CreditGrantCadence = Contracts::CreditGrantCadence.BeginningOfBillingPeriod,
                CreditRate = new()
                {
                    Amount = 1,
                    CurrencyID = "currencyId",
                    CostFormula = "costFormula",
                },
                Currency = Contracts::PriceOverrideCurrency.Usd,
                FeatureID = "featureId",
                Tiers =
                [
                    new()
                    {
                        FlatPrice = new()
                        {
                            Amount = 0,
                            Currency = Contracts::FlatPriceCurrency.Usd,
                        },
                        UnitPrice = new()
                        {
                            Amount = 0,
                            Currency = Contracts::UnitPriceCurrency.Usd,
                        },
                        UpTo = 0,
                    },
                ],
            },
        ];
        string expectedResourceID = "resourceId";
        string expectedSalesforceID = "salesforceId";
        ApiEnum<string, Contracts::ScheduleStrategy> expectedScheduleStrategy =
            Contracts::ScheduleStrategy.EndOfBillingPeriod;
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Contracts::TrialOverrideConfiguration expectedTrialOverrideConfiguration = new()
        {
            IsTrial = true,
            TrialEndBehavior = Contracts::TrialEndBehavior.ConvertToPaid,
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        long expectedUnitQuantity = 0;

        Assert.Equal(expectedCustomerID, deserialized.CustomerID);
        Assert.Equal(expectedPlanID, deserialized.PlanID);
        Assert.Equal(expectedID, deserialized.ID);
        Assert.NotNull(deserialized.Addons);
        Assert.Equal(expectedAddons.Count, deserialized.Addons.Count);
        for (int i = 0; i < expectedAddons.Count; i++)
        {
            Assert.Equal(expectedAddons[i], deserialized.Addons[i]);
        }
        Assert.Equal(expectedAppliedCoupon, deserialized.AppliedCoupon);
        Assert.Equal(expectedAwaitPaymentConfirmation, deserialized.AwaitPaymentConfirmation);
        Assert.Equal(expectedBillingCountryCode, deserialized.BillingCountryCode);
        Assert.Equal(expectedBillingCycleAnchor, deserialized.BillingCycleAnchor);
        Assert.Equal(expectedBillingID, deserialized.BillingID);
        Assert.Equal(expectedBillingInformation, deserialized.BillingInformation);
        Assert.Equal(expectedBillingPeriod, deserialized.BillingPeriod);
        Assert.Equal(expectedBudget, deserialized.Budget);
        Assert.Equal(expectedCancellationDate, deserialized.CancellationDate);
        Assert.NotNull(deserialized.Charges);
        Assert.Equal(expectedCharges.Count, deserialized.Charges.Count);
        for (int i = 0; i < expectedCharges.Count; i++)
        {
            Assert.Equal(expectedCharges[i], deserialized.Charges[i]);
        }
        Assert.Equal(expectedCheckoutOptions, deserialized.CheckoutOptions);
        Assert.NotNull(deserialized.Entitlements);
        Assert.Equal(expectedEntitlements.Count, deserialized.Entitlements.Count);
        for (int i = 0; i < expectedEntitlements.Count; i++)
        {
            Assert.Equal(expectedEntitlements[i], deserialized.Entitlements[i]);
        }
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
        Assert.NotNull(deserialized.PriceOverrides);
        Assert.Equal(expectedPriceOverrides.Count, deserialized.PriceOverrides.Count);
        for (int i = 0; i < expectedPriceOverrides.Count; i++)
        {
            Assert.Equal(expectedPriceOverrides[i], deserialized.PriceOverrides[i]);
        }
        Assert.Equal(expectedResourceID, deserialized.ResourceID);
        Assert.Equal(expectedSalesforceID, deserialized.SalesforceID);
        Assert.Equal(expectedScheduleStrategy, deserialized.ScheduleStrategy);
        Assert.Equal(expectedStartDate, deserialized.StartDate);
        Assert.Equal(expectedTrialOverrideConfiguration, deserialized.TrialOverrideConfiguration);
        Assert.Equal(expectedUnitQuantity, deserialized.UnitQuantity);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Contracts::NewSubscription
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
                    AmountsOff = [new() { Amount = 0, Currency = Contracts::Currency.Usd }],
                    Description = "description",
                    DurationInMonths = 1,
                    Name = "name",
                    PercentOff = 1,
                },
                PromotionCode = "promotionCode",
            },
            AwaitPaymentConfirmation = true,
            BillingCountryCode = "billingCountryCode",
            BillingCycleAnchor = Contracts::BillingCycleAnchor.Unchanged,
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
                ProrationBehavior = Contracts::ProrationBehavior.InvoiceImmediately,
                TaxIds = [new() { Type = "type", Value = "value" }],
                TaxPercentage = 0,
                TaxRateIds = ["string"],
            },
            BillingPeriod = Contracts::BillingPeriod.Monthly,
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Charges =
            [
                new()
                {
                    ID = "id",
                    Quantity = 0,
                    Type = Contracts::Type.Feature,
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
                new Contracts::Feature()
                {
                    ID = "id",
                    HasSoftLimit = true,
                    HasUnlimitedUsage = true,
                    MonthlyResetPeriodConfiguration = new(Contracts::AccordingTo.SubscriptionStart),
                    ResetPeriod = Contracts::ResetPeriod.Year,
                    UsageLimit = 0,
                    WeeklyResetPeriodConfiguration = new(
                        Contracts::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    YearlyResetPeriodConfiguration = new(
                        Contracts::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MinimumSpend = new() { Amount = 0, Currency = Contracts::MinimumSpendCurrency.Usd },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod = Contracts::PaymentCollectionMethod.Charge,
            PriceOverrides =
            [
                new()
                {
                    AddonID = "addonId",
                    Amount = 0,
                    BaseCharge = true,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    CreditGrantCadence = Contracts::CreditGrantCadence.BeginningOfBillingPeriod,
                    CreditRate = new()
                    {
                        Amount = 1,
                        CurrencyID = "currencyId",
                        CostFormula = "costFormula",
                    },
                    Currency = Contracts::PriceOverrideCurrency.Usd,
                    FeatureID = "featureId",
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency = Contracts::FlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency = Contracts::UnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            ResourceID = "resourceId",
            SalesforceID = "salesforceId",
            ScheduleStrategy = Contracts::ScheduleStrategy.EndOfBillingPeriod,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TrialOverrideConfiguration = new()
            {
                IsTrial = true,
                TrialEndBehavior = Contracts::TrialEndBehavior.ConvertToPaid,
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            UnitQuantity = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Contracts::NewSubscription
        {
            CustomerID = "customerId",
            PlanID = "planId",
            BillingCountryCode = "billingCountryCode",
            BillingID = "billingId",
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            MinimumSpend = new() { Amount = 0, Currency = Contracts::MinimumSpendCurrency.Usd },
            PayingCustomerID = "payingCustomerId",
            ResourceID = "resourceId",
            SalesforceID = "salesforceId",
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Addons);
        Assert.False(model.RawData.ContainsKey("addons"));
        Assert.Null(model.AppliedCoupon);
        Assert.False(model.RawData.ContainsKey("appliedCoupon"));
        Assert.Null(model.AwaitPaymentConfirmation);
        Assert.False(model.RawData.ContainsKey("awaitPaymentConfirmation"));
        Assert.Null(model.BillingCycleAnchor);
        Assert.False(model.RawData.ContainsKey("billingCycleAnchor"));
        Assert.Null(model.BillingInformation);
        Assert.False(model.RawData.ContainsKey("billingInformation"));
        Assert.Null(model.BillingPeriod);
        Assert.False(model.RawData.ContainsKey("billingPeriod"));
        Assert.Null(model.CancellationDate);
        Assert.False(model.RawData.ContainsKey("cancellationDate"));
        Assert.Null(model.Charges);
        Assert.False(model.RawData.ContainsKey("charges"));
        Assert.Null(model.CheckoutOptions);
        Assert.False(model.RawData.ContainsKey("checkoutOptions"));
        Assert.Null(model.Entitlements);
        Assert.False(model.RawData.ContainsKey("entitlements"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.PaymentCollectionMethod);
        Assert.False(model.RawData.ContainsKey("paymentCollectionMethod"));
        Assert.Null(model.PriceOverrides);
        Assert.False(model.RawData.ContainsKey("priceOverrides"));
        Assert.Null(model.ScheduleStrategy);
        Assert.False(model.RawData.ContainsKey("scheduleStrategy"));
        Assert.Null(model.StartDate);
        Assert.False(model.RawData.ContainsKey("startDate"));
        Assert.Null(model.TrialOverrideConfiguration);
        Assert.False(model.RawData.ContainsKey("trialOverrideConfiguration"));
        Assert.Null(model.UnitQuantity);
        Assert.False(model.RawData.ContainsKey("unitQuantity"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Contracts::NewSubscription
        {
            CustomerID = "customerId",
            PlanID = "planId",
            BillingCountryCode = "billingCountryCode",
            BillingID = "billingId",
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            MinimumSpend = new() { Amount = 0, Currency = Contracts::MinimumSpendCurrency.Usd },
            PayingCustomerID = "payingCustomerId",
            ResourceID = "resourceId",
            SalesforceID = "salesforceId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Contracts::NewSubscription
        {
            CustomerID = "customerId",
            PlanID = "planId",
            BillingCountryCode = "billingCountryCode",
            BillingID = "billingId",
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            MinimumSpend = new() { Amount = 0, Currency = Contracts::MinimumSpendCurrency.Usd },
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
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Addons);
        Assert.False(model.RawData.ContainsKey("addons"));
        Assert.Null(model.AppliedCoupon);
        Assert.False(model.RawData.ContainsKey("appliedCoupon"));
        Assert.Null(model.AwaitPaymentConfirmation);
        Assert.False(model.RawData.ContainsKey("awaitPaymentConfirmation"));
        Assert.Null(model.BillingCycleAnchor);
        Assert.False(model.RawData.ContainsKey("billingCycleAnchor"));
        Assert.Null(model.BillingInformation);
        Assert.False(model.RawData.ContainsKey("billingInformation"));
        Assert.Null(model.BillingPeriod);
        Assert.False(model.RawData.ContainsKey("billingPeriod"));
        Assert.Null(model.CancellationDate);
        Assert.False(model.RawData.ContainsKey("cancellationDate"));
        Assert.Null(model.Charges);
        Assert.False(model.RawData.ContainsKey("charges"));
        Assert.Null(model.CheckoutOptions);
        Assert.False(model.RawData.ContainsKey("checkoutOptions"));
        Assert.Null(model.Entitlements);
        Assert.False(model.RawData.ContainsKey("entitlements"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.PaymentCollectionMethod);
        Assert.False(model.RawData.ContainsKey("paymentCollectionMethod"));
        Assert.Null(model.PriceOverrides);
        Assert.False(model.RawData.ContainsKey("priceOverrides"));
        Assert.Null(model.ScheduleStrategy);
        Assert.False(model.RawData.ContainsKey("scheduleStrategy"));
        Assert.Null(model.StartDate);
        Assert.False(model.RawData.ContainsKey("startDate"));
        Assert.Null(model.TrialOverrideConfiguration);
        Assert.False(model.RawData.ContainsKey("trialOverrideConfiguration"));
        Assert.Null(model.UnitQuantity);
        Assert.False(model.RawData.ContainsKey("unitQuantity"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Contracts::NewSubscription
        {
            CustomerID = "customerId",
            PlanID = "planId",
            BillingCountryCode = "billingCountryCode",
            BillingID = "billingId",
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            MinimumSpend = new() { Amount = 0, Currency = Contracts::MinimumSpendCurrency.Usd },
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Contracts::NewSubscription
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
                    AmountsOff = [new() { Amount = 0, Currency = Contracts::Currency.Usd }],
                    Description = "description",
                    DurationInMonths = 1,
                    Name = "name",
                    PercentOff = 1,
                },
                PromotionCode = "promotionCode",
            },
            AwaitPaymentConfirmation = true,
            BillingCycleAnchor = Contracts::BillingCycleAnchor.Unchanged,
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
                ProrationBehavior = Contracts::ProrationBehavior.InvoiceImmediately,
                TaxIds = [new() { Type = "type", Value = "value" }],
                TaxPercentage = 0,
                TaxRateIds = ["string"],
            },
            BillingPeriod = Contracts::BillingPeriod.Monthly,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Charges =
            [
                new()
                {
                    ID = "id",
                    Quantity = 0,
                    Type = Contracts::Type.Feature,
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
                new Contracts::Feature()
                {
                    ID = "id",
                    HasSoftLimit = true,
                    HasUnlimitedUsage = true,
                    MonthlyResetPeriodConfiguration = new(Contracts::AccordingTo.SubscriptionStart),
                    ResetPeriod = Contracts::ResetPeriod.Year,
                    UsageLimit = 0,
                    WeeklyResetPeriodConfiguration = new(
                        Contracts::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    YearlyResetPeriodConfiguration = new(
                        Contracts::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentCollectionMethod = Contracts::PaymentCollectionMethod.Charge,
            PriceOverrides =
            [
                new()
                {
                    AddonID = "addonId",
                    Amount = 0,
                    BaseCharge = true,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    CreditGrantCadence = Contracts::CreditGrantCadence.BeginningOfBillingPeriod,
                    CreditRate = new()
                    {
                        Amount = 1,
                        CurrencyID = "currencyId",
                        CostFormula = "costFormula",
                    },
                    Currency = Contracts::PriceOverrideCurrency.Usd,
                    FeatureID = "featureId",
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency = Contracts::FlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency = Contracts::UnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            ScheduleStrategy = Contracts::ScheduleStrategy.EndOfBillingPeriod,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TrialOverrideConfiguration = new()
            {
                IsTrial = true,
                TrialEndBehavior = Contracts::TrialEndBehavior.ConvertToPaid,
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            UnitQuantity = 0,
        };

        Assert.Null(model.BillingCountryCode);
        Assert.False(model.RawData.ContainsKey("billingCountryCode"));
        Assert.Null(model.BillingID);
        Assert.False(model.RawData.ContainsKey("billingId"));
        Assert.Null(model.Budget);
        Assert.False(model.RawData.ContainsKey("budget"));
        Assert.Null(model.MinimumSpend);
        Assert.False(model.RawData.ContainsKey("minimumSpend"));
        Assert.Null(model.PayingCustomerID);
        Assert.False(model.RawData.ContainsKey("payingCustomerId"));
        Assert.Null(model.ResourceID);
        Assert.False(model.RawData.ContainsKey("resourceId"));
        Assert.Null(model.SalesforceID);
        Assert.False(model.RawData.ContainsKey("salesforceId"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Contracts::NewSubscription
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
                    AmountsOff = [new() { Amount = 0, Currency = Contracts::Currency.Usd }],
                    Description = "description",
                    DurationInMonths = 1,
                    Name = "name",
                    PercentOff = 1,
                },
                PromotionCode = "promotionCode",
            },
            AwaitPaymentConfirmation = true,
            BillingCycleAnchor = Contracts::BillingCycleAnchor.Unchanged,
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
                ProrationBehavior = Contracts::ProrationBehavior.InvoiceImmediately,
                TaxIds = [new() { Type = "type", Value = "value" }],
                TaxPercentage = 0,
                TaxRateIds = ["string"],
            },
            BillingPeriod = Contracts::BillingPeriod.Monthly,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Charges =
            [
                new()
                {
                    ID = "id",
                    Quantity = 0,
                    Type = Contracts::Type.Feature,
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
                new Contracts::Feature()
                {
                    ID = "id",
                    HasSoftLimit = true,
                    HasUnlimitedUsage = true,
                    MonthlyResetPeriodConfiguration = new(Contracts::AccordingTo.SubscriptionStart),
                    ResetPeriod = Contracts::ResetPeriod.Year,
                    UsageLimit = 0,
                    WeeklyResetPeriodConfiguration = new(
                        Contracts::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    YearlyResetPeriodConfiguration = new(
                        Contracts::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentCollectionMethod = Contracts::PaymentCollectionMethod.Charge,
            PriceOverrides =
            [
                new()
                {
                    AddonID = "addonId",
                    Amount = 0,
                    BaseCharge = true,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    CreditGrantCadence = Contracts::CreditGrantCadence.BeginningOfBillingPeriod,
                    CreditRate = new()
                    {
                        Amount = 1,
                        CurrencyID = "currencyId",
                        CostFormula = "costFormula",
                    },
                    Currency = Contracts::PriceOverrideCurrency.Usd,
                    FeatureID = "featureId",
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency = Contracts::FlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency = Contracts::UnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            ScheduleStrategy = Contracts::ScheduleStrategy.EndOfBillingPeriod,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TrialOverrideConfiguration = new()
            {
                IsTrial = true,
                TrialEndBehavior = Contracts::TrialEndBehavior.ConvertToPaid,
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            UnitQuantity = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Contracts::NewSubscription
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
                    AmountsOff = [new() { Amount = 0, Currency = Contracts::Currency.Usd }],
                    Description = "description",
                    DurationInMonths = 1,
                    Name = "name",
                    PercentOff = 1,
                },
                PromotionCode = "promotionCode",
            },
            AwaitPaymentConfirmation = true,
            BillingCycleAnchor = Contracts::BillingCycleAnchor.Unchanged,
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
                ProrationBehavior = Contracts::ProrationBehavior.InvoiceImmediately,
                TaxIds = [new() { Type = "type", Value = "value" }],
                TaxPercentage = 0,
                TaxRateIds = ["string"],
            },
            BillingPeriod = Contracts::BillingPeriod.Monthly,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Charges =
            [
                new()
                {
                    ID = "id",
                    Quantity = 0,
                    Type = Contracts::Type.Feature,
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
                new Contracts::Feature()
                {
                    ID = "id",
                    HasSoftLimit = true,
                    HasUnlimitedUsage = true,
                    MonthlyResetPeriodConfiguration = new(Contracts::AccordingTo.SubscriptionStart),
                    ResetPeriod = Contracts::ResetPeriod.Year,
                    UsageLimit = 0,
                    WeeklyResetPeriodConfiguration = new(
                        Contracts::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    YearlyResetPeriodConfiguration = new(
                        Contracts::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentCollectionMethod = Contracts::PaymentCollectionMethod.Charge,
            PriceOverrides =
            [
                new()
                {
                    AddonID = "addonId",
                    Amount = 0,
                    BaseCharge = true,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    CreditGrantCadence = Contracts::CreditGrantCadence.BeginningOfBillingPeriod,
                    CreditRate = new()
                    {
                        Amount = 1,
                        CurrencyID = "currencyId",
                        CostFormula = "costFormula",
                    },
                    Currency = Contracts::PriceOverrideCurrency.Usd,
                    FeatureID = "featureId",
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency = Contracts::FlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency = Contracts::UnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            ScheduleStrategy = Contracts::ScheduleStrategy.EndOfBillingPeriod,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TrialOverrideConfiguration = new()
            {
                IsTrial = true,
                TrialEndBehavior = Contracts::TrialEndBehavior.ConvertToPaid,
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            UnitQuantity = 0,

            BillingCountryCode = null,
            BillingID = null,
            Budget = null,
            MinimumSpend = null,
            PayingCustomerID = null,
            ResourceID = null,
            SalesforceID = null,
        };

        Assert.Null(model.BillingCountryCode);
        Assert.True(model.RawData.ContainsKey("billingCountryCode"));
        Assert.Null(model.BillingID);
        Assert.True(model.RawData.ContainsKey("billingId"));
        Assert.Null(model.Budget);
        Assert.True(model.RawData.ContainsKey("budget"));
        Assert.Null(model.MinimumSpend);
        Assert.True(model.RawData.ContainsKey("minimumSpend"));
        Assert.Null(model.PayingCustomerID);
        Assert.True(model.RawData.ContainsKey("payingCustomerId"));
        Assert.Null(model.ResourceID);
        Assert.True(model.RawData.ContainsKey("resourceId"));
        Assert.Null(model.SalesforceID);
        Assert.True(model.RawData.ContainsKey("salesforceId"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Contracts::NewSubscription
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
                    AmountsOff = [new() { Amount = 0, Currency = Contracts::Currency.Usd }],
                    Description = "description",
                    DurationInMonths = 1,
                    Name = "name",
                    PercentOff = 1,
                },
                PromotionCode = "promotionCode",
            },
            AwaitPaymentConfirmation = true,
            BillingCycleAnchor = Contracts::BillingCycleAnchor.Unchanged,
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
                ProrationBehavior = Contracts::ProrationBehavior.InvoiceImmediately,
                TaxIds = [new() { Type = "type", Value = "value" }],
                TaxPercentage = 0,
                TaxRateIds = ["string"],
            },
            BillingPeriod = Contracts::BillingPeriod.Monthly,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Charges =
            [
                new()
                {
                    ID = "id",
                    Quantity = 0,
                    Type = Contracts::Type.Feature,
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
                new Contracts::Feature()
                {
                    ID = "id",
                    HasSoftLimit = true,
                    HasUnlimitedUsage = true,
                    MonthlyResetPeriodConfiguration = new(Contracts::AccordingTo.SubscriptionStart),
                    ResetPeriod = Contracts::ResetPeriod.Year,
                    UsageLimit = 0,
                    WeeklyResetPeriodConfiguration = new(
                        Contracts::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    YearlyResetPeriodConfiguration = new(
                        Contracts::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentCollectionMethod = Contracts::PaymentCollectionMethod.Charge,
            PriceOverrides =
            [
                new()
                {
                    AddonID = "addonId",
                    Amount = 0,
                    BaseCharge = true,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    CreditGrantCadence = Contracts::CreditGrantCadence.BeginningOfBillingPeriod,
                    CreditRate = new()
                    {
                        Amount = 1,
                        CurrencyID = "currencyId",
                        CostFormula = "costFormula",
                    },
                    Currency = Contracts::PriceOverrideCurrency.Usd,
                    FeatureID = "featureId",
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency = Contracts::FlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency = Contracts::UnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            ScheduleStrategy = Contracts::ScheduleStrategy.EndOfBillingPeriod,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TrialOverrideConfiguration = new()
            {
                IsTrial = true,
                TrialEndBehavior = Contracts::TrialEndBehavior.ConvertToPaid,
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            UnitQuantity = 0,

            BillingCountryCode = null,
            BillingID = null,
            Budget = null,
            MinimumSpend = null,
            PayingCustomerID = null,
            ResourceID = null,
            SalesforceID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Contracts::NewSubscription
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
                    AmountsOff = [new() { Amount = 0, Currency = Contracts::Currency.Usd }],
                    Description = "description",
                    DurationInMonths = 1,
                    Name = "name",
                    PercentOff = 1,
                },
                PromotionCode = "promotionCode",
            },
            AwaitPaymentConfirmation = true,
            BillingCountryCode = "billingCountryCode",
            BillingCycleAnchor = Contracts::BillingCycleAnchor.Unchanged,
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
                ProrationBehavior = Contracts::ProrationBehavior.InvoiceImmediately,
                TaxIds = [new() { Type = "type", Value = "value" }],
                TaxPercentage = 0,
                TaxRateIds = ["string"],
            },
            BillingPeriod = Contracts::BillingPeriod.Monthly,
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Charges =
            [
                new()
                {
                    ID = "id",
                    Quantity = 0,
                    Type = Contracts::Type.Feature,
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
                new Contracts::Feature()
                {
                    ID = "id",
                    HasSoftLimit = true,
                    HasUnlimitedUsage = true,
                    MonthlyResetPeriodConfiguration = new(Contracts::AccordingTo.SubscriptionStart),
                    ResetPeriod = Contracts::ResetPeriod.Year,
                    UsageLimit = 0,
                    WeeklyResetPeriodConfiguration = new(
                        Contracts::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    YearlyResetPeriodConfiguration = new(
                        Contracts::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MinimumSpend = new() { Amount = 0, Currency = Contracts::MinimumSpendCurrency.Usd },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod = Contracts::PaymentCollectionMethod.Charge,
            PriceOverrides =
            [
                new()
                {
                    AddonID = "addonId",
                    Amount = 0,
                    BaseCharge = true,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    CreditGrantCadence = Contracts::CreditGrantCadence.BeginningOfBillingPeriod,
                    CreditRate = new()
                    {
                        Amount = 1,
                        CurrencyID = "currencyId",
                        CostFormula = "costFormula",
                    },
                    Currency = Contracts::PriceOverrideCurrency.Usd,
                    FeatureID = "featureId",
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency = Contracts::FlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency = Contracts::UnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            ResourceID = "resourceId",
            SalesforceID = "salesforceId",
            ScheduleStrategy = Contracts::ScheduleStrategy.EndOfBillingPeriod,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TrialOverrideConfiguration = new()
            {
                IsTrial = true,
                TrialEndBehavior = Contracts::TrialEndBehavior.ConvertToPaid,
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            UnitQuantity = 0,
        };

        Contracts::NewSubscription copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AddonTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Contracts::Addon { ID = "id", Quantity = 0 };

        string expectedID = "id";
        long expectedQuantity = 0;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedQuantity, model.Quantity);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Contracts::Addon { ID = "id", Quantity = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Contracts::Addon>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Contracts::Addon { ID = "id", Quantity = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Contracts::Addon>(
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
        var model = new Contracts::Addon { ID = "id", Quantity = 0 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Contracts::Addon { ID = "id", Quantity = 0 };

        Contracts::Addon copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AppliedCouponTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Contracts::AppliedCoupon
        {
            BillingCouponID = "billingCouponId",
            Configuration = new() { StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z") },
            CouponID = "couponId",
            Discount = new()
            {
                AmountsOff = [new() { Amount = 0, Currency = Contracts::Currency.Usd }],
                Description = "description",
                DurationInMonths = 1,
                Name = "name",
                PercentOff = 1,
            },
            PromotionCode = "promotionCode",
        };

        string expectedBillingCouponID = "billingCouponId";
        Contracts::Configuration expectedConfiguration = new()
        {
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string expectedCouponID = "couponId";
        Contracts::Discount expectedDiscount = new()
        {
            AmountsOff = [new() { Amount = 0, Currency = Contracts::Currency.Usd }],
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
        var model = new Contracts::AppliedCoupon
        {
            BillingCouponID = "billingCouponId",
            Configuration = new() { StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z") },
            CouponID = "couponId",
            Discount = new()
            {
                AmountsOff = [new() { Amount = 0, Currency = Contracts::Currency.Usd }],
                Description = "description",
                DurationInMonths = 1,
                Name = "name",
                PercentOff = 1,
            },
            PromotionCode = "promotionCode",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Contracts::AppliedCoupon>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Contracts::AppliedCoupon
        {
            BillingCouponID = "billingCouponId",
            Configuration = new() { StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z") },
            CouponID = "couponId",
            Discount = new()
            {
                AmountsOff = [new() { Amount = 0, Currency = Contracts::Currency.Usd }],
                Description = "description",
                DurationInMonths = 1,
                Name = "name",
                PercentOff = 1,
            },
            PromotionCode = "promotionCode",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Contracts::AppliedCoupon>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBillingCouponID = "billingCouponId";
        Contracts::Configuration expectedConfiguration = new()
        {
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string expectedCouponID = "couponId";
        Contracts::Discount expectedDiscount = new()
        {
            AmountsOff = [new() { Amount = 0, Currency = Contracts::Currency.Usd }],
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
        var model = new Contracts::AppliedCoupon
        {
            BillingCouponID = "billingCouponId",
            Configuration = new() { StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z") },
            CouponID = "couponId",
            Discount = new()
            {
                AmountsOff = [new() { Amount = 0, Currency = Contracts::Currency.Usd }],
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
        var model = new Contracts::AppliedCoupon { };

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
        var model = new Contracts::AppliedCoupon { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Contracts::AppliedCoupon
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
        var model = new Contracts::AppliedCoupon
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
        var model = new Contracts::AppliedCoupon
        {
            BillingCouponID = "billingCouponId",
            Configuration = new() { StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z") },
            CouponID = "couponId",
            Discount = new()
            {
                AmountsOff = [new() { Amount = 0, Currency = Contracts::Currency.Usd }],
                Description = "description",
                DurationInMonths = 1,
                Name = "name",
                PercentOff = 1,
            },
            PromotionCode = "promotionCode",
        };

        Contracts::AppliedCoupon copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Contracts::Configuration
        {
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedStartDate, model.StartDate);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Contracts::Configuration
        {
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Contracts::Configuration>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Contracts::Configuration
        {
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Contracts::Configuration>(
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
        var model = new Contracts::Configuration
        {
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Contracts::Configuration { };

        Assert.Null(model.StartDate);
        Assert.False(model.RawData.ContainsKey("startDate"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Contracts::Configuration { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Contracts::Configuration
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
        var model = new Contracts::Configuration
        {
            // Null should be interpreted as omitted for these properties
            StartDate = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Contracts::Configuration
        {
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Contracts::Configuration copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DiscountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Contracts::Discount
        {
            AmountsOff = [new() { Amount = 0, Currency = Contracts::Currency.Usd }],
            Description = "description",
            DurationInMonths = 1,
            Name = "name",
            PercentOff = 1,
        };

        List<Contracts::AmountsOff> expectedAmountsOff =
        [
            new() { Amount = 0, Currency = Contracts::Currency.Usd },
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
        var model = new Contracts::Discount
        {
            AmountsOff = [new() { Amount = 0, Currency = Contracts::Currency.Usd }],
            Description = "description",
            DurationInMonths = 1,
            Name = "name",
            PercentOff = 1,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Contracts::Discount>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Contracts::Discount
        {
            AmountsOff = [new() { Amount = 0, Currency = Contracts::Currency.Usd }],
            Description = "description",
            DurationInMonths = 1,
            Name = "name",
            PercentOff = 1,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Contracts::Discount>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Contracts::AmountsOff> expectedAmountsOff =
        [
            new() { Amount = 0, Currency = Contracts::Currency.Usd },
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
        var model = new Contracts::Discount
        {
            AmountsOff = [new() { Amount = 0, Currency = Contracts::Currency.Usd }],
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
        var model = new Contracts::Discount
        {
            AmountsOff = [new() { Amount = 0, Currency = Contracts::Currency.Usd }],
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
        var model = new Contracts::Discount
        {
            AmountsOff = [new() { Amount = 0, Currency = Contracts::Currency.Usd }],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Contracts::Discount
        {
            AmountsOff = [new() { Amount = 0, Currency = Contracts::Currency.Usd }],

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
        var model = new Contracts::Discount
        {
            AmountsOff = [new() { Amount = 0, Currency = Contracts::Currency.Usd }],

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
        var model = new Contracts::Discount
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
        var model = new Contracts::Discount
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
        var model = new Contracts::Discount
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
        var model = new Contracts::Discount
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
        var model = new Contracts::Discount
        {
            AmountsOff = [new() { Amount = 0, Currency = Contracts::Currency.Usd }],
            Description = "description",
            DurationInMonths = 1,
            Name = "name",
            PercentOff = 1,
        };

        Contracts::Discount copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AmountsOffTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Contracts::AmountsOff { Amount = 0, Currency = Contracts::Currency.Usd };

        double expectedAmount = 0;
        ApiEnum<string, Contracts::Currency> expectedCurrency = Contracts::Currency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Contracts::AmountsOff { Amount = 0, Currency = Contracts::Currency.Usd };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Contracts::AmountsOff>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Contracts::AmountsOff { Amount = 0, Currency = Contracts::Currency.Usd };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Contracts::AmountsOff>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        ApiEnum<string, Contracts::Currency> expectedCurrency = Contracts::Currency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Contracts::AmountsOff { Amount = 0, Currency = Contracts::Currency.Usd };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Contracts::AmountsOff { Amount = 0, Currency = Contracts::Currency.Usd };

        Contracts::AmountsOff copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CurrencyTest : TestBase
{
    [Theory]
    [InlineData(Contracts::Currency.Usd)]
    [InlineData(Contracts::Currency.Aed)]
    [InlineData(Contracts::Currency.All)]
    [InlineData(Contracts::Currency.Amd)]
    [InlineData(Contracts::Currency.Ang)]
    [InlineData(Contracts::Currency.Aud)]
    [InlineData(Contracts::Currency.Awg)]
    [InlineData(Contracts::Currency.Azn)]
    [InlineData(Contracts::Currency.Bam)]
    [InlineData(Contracts::Currency.Bbd)]
    [InlineData(Contracts::Currency.Bdt)]
    [InlineData(Contracts::Currency.Bgn)]
    [InlineData(Contracts::Currency.Bif)]
    [InlineData(Contracts::Currency.Bmd)]
    [InlineData(Contracts::Currency.Bnd)]
    [InlineData(Contracts::Currency.Bsd)]
    [InlineData(Contracts::Currency.Bwp)]
    [InlineData(Contracts::Currency.Byn)]
    [InlineData(Contracts::Currency.Bzd)]
    [InlineData(Contracts::Currency.Brl)]
    [InlineData(Contracts::Currency.Cad)]
    [InlineData(Contracts::Currency.Cdf)]
    [InlineData(Contracts::Currency.Chf)]
    [InlineData(Contracts::Currency.Cny)]
    [InlineData(Contracts::Currency.Czk)]
    [InlineData(Contracts::Currency.Dkk)]
    [InlineData(Contracts::Currency.Dop)]
    [InlineData(Contracts::Currency.Dzd)]
    [InlineData(Contracts::Currency.Egp)]
    [InlineData(Contracts::Currency.Etb)]
    [InlineData(Contracts::Currency.Eur)]
    [InlineData(Contracts::Currency.Fjd)]
    [InlineData(Contracts::Currency.Gbp)]
    [InlineData(Contracts::Currency.Gel)]
    [InlineData(Contracts::Currency.Gip)]
    [InlineData(Contracts::Currency.Gmd)]
    [InlineData(Contracts::Currency.Gyd)]
    [InlineData(Contracts::Currency.Hkd)]
    [InlineData(Contracts::Currency.Hrk)]
    [InlineData(Contracts::Currency.Htg)]
    [InlineData(Contracts::Currency.Idr)]
    [InlineData(Contracts::Currency.Ils)]
    [InlineData(Contracts::Currency.Inr)]
    [InlineData(Contracts::Currency.Isk)]
    [InlineData(Contracts::Currency.Jmd)]
    [InlineData(Contracts::Currency.Jpy)]
    [InlineData(Contracts::Currency.Kes)]
    [InlineData(Contracts::Currency.Kgs)]
    [InlineData(Contracts::Currency.Khr)]
    [InlineData(Contracts::Currency.Kmf)]
    [InlineData(Contracts::Currency.Krw)]
    [InlineData(Contracts::Currency.Kyd)]
    [InlineData(Contracts::Currency.Kzt)]
    [InlineData(Contracts::Currency.Lbp)]
    [InlineData(Contracts::Currency.Lkr)]
    [InlineData(Contracts::Currency.Lrd)]
    [InlineData(Contracts::Currency.Lsl)]
    [InlineData(Contracts::Currency.Mad)]
    [InlineData(Contracts::Currency.Mdl)]
    [InlineData(Contracts::Currency.Mga)]
    [InlineData(Contracts::Currency.Mkd)]
    [InlineData(Contracts::Currency.Mmk)]
    [InlineData(Contracts::Currency.Mnt)]
    [InlineData(Contracts::Currency.Mop)]
    [InlineData(Contracts::Currency.Mro)]
    [InlineData(Contracts::Currency.Mvr)]
    [InlineData(Contracts::Currency.Mwk)]
    [InlineData(Contracts::Currency.Mxn)]
    [InlineData(Contracts::Currency.Myr)]
    [InlineData(Contracts::Currency.Mzn)]
    [InlineData(Contracts::Currency.Nad)]
    [InlineData(Contracts::Currency.Ngn)]
    [InlineData(Contracts::Currency.Nok)]
    [InlineData(Contracts::Currency.Npr)]
    [InlineData(Contracts::Currency.Nzd)]
    [InlineData(Contracts::Currency.Pgk)]
    [InlineData(Contracts::Currency.Php)]
    [InlineData(Contracts::Currency.Pkr)]
    [InlineData(Contracts::Currency.Pln)]
    [InlineData(Contracts::Currency.Qar)]
    [InlineData(Contracts::Currency.Ron)]
    [InlineData(Contracts::Currency.Rsd)]
    [InlineData(Contracts::Currency.Rub)]
    [InlineData(Contracts::Currency.Rwf)]
    [InlineData(Contracts::Currency.Sar)]
    [InlineData(Contracts::Currency.Sbd)]
    [InlineData(Contracts::Currency.Scr)]
    [InlineData(Contracts::Currency.Sek)]
    [InlineData(Contracts::Currency.Sgd)]
    [InlineData(Contracts::Currency.Sle)]
    [InlineData(Contracts::Currency.Sll)]
    [InlineData(Contracts::Currency.Sos)]
    [InlineData(Contracts::Currency.Szl)]
    [InlineData(Contracts::Currency.Thb)]
    [InlineData(Contracts::Currency.Tjs)]
    [InlineData(Contracts::Currency.Top)]
    [InlineData(Contracts::Currency.Try)]
    [InlineData(Contracts::Currency.Ttd)]
    [InlineData(Contracts::Currency.Tzs)]
    [InlineData(Contracts::Currency.Uah)]
    [InlineData(Contracts::Currency.Uzs)]
    [InlineData(Contracts::Currency.Vnd)]
    [InlineData(Contracts::Currency.Vuv)]
    [InlineData(Contracts::Currency.Wst)]
    [InlineData(Contracts::Currency.Xaf)]
    [InlineData(Contracts::Currency.Xcd)]
    [InlineData(Contracts::Currency.Yer)]
    [InlineData(Contracts::Currency.Zar)]
    [InlineData(Contracts::Currency.Zmw)]
    [InlineData(Contracts::Currency.Clp)]
    [InlineData(Contracts::Currency.Djf)]
    [InlineData(Contracts::Currency.Gnf)]
    [InlineData(Contracts::Currency.Ugx)]
    [InlineData(Contracts::Currency.Pyg)]
    [InlineData(Contracts::Currency.Xof)]
    [InlineData(Contracts::Currency.Xpf)]
    public void Validation_Works(Contracts::Currency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Contracts::Currency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Contracts::Currency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Contracts::Currency.Usd)]
    [InlineData(Contracts::Currency.Aed)]
    [InlineData(Contracts::Currency.All)]
    [InlineData(Contracts::Currency.Amd)]
    [InlineData(Contracts::Currency.Ang)]
    [InlineData(Contracts::Currency.Aud)]
    [InlineData(Contracts::Currency.Awg)]
    [InlineData(Contracts::Currency.Azn)]
    [InlineData(Contracts::Currency.Bam)]
    [InlineData(Contracts::Currency.Bbd)]
    [InlineData(Contracts::Currency.Bdt)]
    [InlineData(Contracts::Currency.Bgn)]
    [InlineData(Contracts::Currency.Bif)]
    [InlineData(Contracts::Currency.Bmd)]
    [InlineData(Contracts::Currency.Bnd)]
    [InlineData(Contracts::Currency.Bsd)]
    [InlineData(Contracts::Currency.Bwp)]
    [InlineData(Contracts::Currency.Byn)]
    [InlineData(Contracts::Currency.Bzd)]
    [InlineData(Contracts::Currency.Brl)]
    [InlineData(Contracts::Currency.Cad)]
    [InlineData(Contracts::Currency.Cdf)]
    [InlineData(Contracts::Currency.Chf)]
    [InlineData(Contracts::Currency.Cny)]
    [InlineData(Contracts::Currency.Czk)]
    [InlineData(Contracts::Currency.Dkk)]
    [InlineData(Contracts::Currency.Dop)]
    [InlineData(Contracts::Currency.Dzd)]
    [InlineData(Contracts::Currency.Egp)]
    [InlineData(Contracts::Currency.Etb)]
    [InlineData(Contracts::Currency.Eur)]
    [InlineData(Contracts::Currency.Fjd)]
    [InlineData(Contracts::Currency.Gbp)]
    [InlineData(Contracts::Currency.Gel)]
    [InlineData(Contracts::Currency.Gip)]
    [InlineData(Contracts::Currency.Gmd)]
    [InlineData(Contracts::Currency.Gyd)]
    [InlineData(Contracts::Currency.Hkd)]
    [InlineData(Contracts::Currency.Hrk)]
    [InlineData(Contracts::Currency.Htg)]
    [InlineData(Contracts::Currency.Idr)]
    [InlineData(Contracts::Currency.Ils)]
    [InlineData(Contracts::Currency.Inr)]
    [InlineData(Contracts::Currency.Isk)]
    [InlineData(Contracts::Currency.Jmd)]
    [InlineData(Contracts::Currency.Jpy)]
    [InlineData(Contracts::Currency.Kes)]
    [InlineData(Contracts::Currency.Kgs)]
    [InlineData(Contracts::Currency.Khr)]
    [InlineData(Contracts::Currency.Kmf)]
    [InlineData(Contracts::Currency.Krw)]
    [InlineData(Contracts::Currency.Kyd)]
    [InlineData(Contracts::Currency.Kzt)]
    [InlineData(Contracts::Currency.Lbp)]
    [InlineData(Contracts::Currency.Lkr)]
    [InlineData(Contracts::Currency.Lrd)]
    [InlineData(Contracts::Currency.Lsl)]
    [InlineData(Contracts::Currency.Mad)]
    [InlineData(Contracts::Currency.Mdl)]
    [InlineData(Contracts::Currency.Mga)]
    [InlineData(Contracts::Currency.Mkd)]
    [InlineData(Contracts::Currency.Mmk)]
    [InlineData(Contracts::Currency.Mnt)]
    [InlineData(Contracts::Currency.Mop)]
    [InlineData(Contracts::Currency.Mro)]
    [InlineData(Contracts::Currency.Mvr)]
    [InlineData(Contracts::Currency.Mwk)]
    [InlineData(Contracts::Currency.Mxn)]
    [InlineData(Contracts::Currency.Myr)]
    [InlineData(Contracts::Currency.Mzn)]
    [InlineData(Contracts::Currency.Nad)]
    [InlineData(Contracts::Currency.Ngn)]
    [InlineData(Contracts::Currency.Nok)]
    [InlineData(Contracts::Currency.Npr)]
    [InlineData(Contracts::Currency.Nzd)]
    [InlineData(Contracts::Currency.Pgk)]
    [InlineData(Contracts::Currency.Php)]
    [InlineData(Contracts::Currency.Pkr)]
    [InlineData(Contracts::Currency.Pln)]
    [InlineData(Contracts::Currency.Qar)]
    [InlineData(Contracts::Currency.Ron)]
    [InlineData(Contracts::Currency.Rsd)]
    [InlineData(Contracts::Currency.Rub)]
    [InlineData(Contracts::Currency.Rwf)]
    [InlineData(Contracts::Currency.Sar)]
    [InlineData(Contracts::Currency.Sbd)]
    [InlineData(Contracts::Currency.Scr)]
    [InlineData(Contracts::Currency.Sek)]
    [InlineData(Contracts::Currency.Sgd)]
    [InlineData(Contracts::Currency.Sle)]
    [InlineData(Contracts::Currency.Sll)]
    [InlineData(Contracts::Currency.Sos)]
    [InlineData(Contracts::Currency.Szl)]
    [InlineData(Contracts::Currency.Thb)]
    [InlineData(Contracts::Currency.Tjs)]
    [InlineData(Contracts::Currency.Top)]
    [InlineData(Contracts::Currency.Try)]
    [InlineData(Contracts::Currency.Ttd)]
    [InlineData(Contracts::Currency.Tzs)]
    [InlineData(Contracts::Currency.Uah)]
    [InlineData(Contracts::Currency.Uzs)]
    [InlineData(Contracts::Currency.Vnd)]
    [InlineData(Contracts::Currency.Vuv)]
    [InlineData(Contracts::Currency.Wst)]
    [InlineData(Contracts::Currency.Xaf)]
    [InlineData(Contracts::Currency.Xcd)]
    [InlineData(Contracts::Currency.Yer)]
    [InlineData(Contracts::Currency.Zar)]
    [InlineData(Contracts::Currency.Zmw)]
    [InlineData(Contracts::Currency.Clp)]
    [InlineData(Contracts::Currency.Djf)]
    [InlineData(Contracts::Currency.Gnf)]
    [InlineData(Contracts::Currency.Ugx)]
    [InlineData(Contracts::Currency.Pyg)]
    [InlineData(Contracts::Currency.Xof)]
    [InlineData(Contracts::Currency.Xpf)]
    public void SerializationRoundtrip_Works(Contracts::Currency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Contracts::Currency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Contracts::Currency>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Contracts::Currency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Contracts::Currency>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class BillingCycleAnchorTest : TestBase
{
    [Theory]
    [InlineData(Contracts::BillingCycleAnchor.Unchanged)]
    [InlineData(Contracts::BillingCycleAnchor.Now)]
    public void Validation_Works(Contracts::BillingCycleAnchor rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Contracts::BillingCycleAnchor> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Contracts::BillingCycleAnchor>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Contracts::BillingCycleAnchor.Unchanged)]
    [InlineData(Contracts::BillingCycleAnchor.Now)]
    public void SerializationRoundtrip_Works(Contracts::BillingCycleAnchor rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Contracts::BillingCycleAnchor> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Contracts::BillingCycleAnchor>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Contracts::BillingCycleAnchor>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Contracts::BillingCycleAnchor>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class BillingInformationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Contracts::BillingInformation
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
            ProrationBehavior = Contracts::ProrationBehavior.InvoiceImmediately,
            TaxIds = [new() { Type = "type", Value = "value" }],
            TaxPercentage = 0,
            TaxRateIds = ["string"],
        };

        Contracts::BillingAddress expectedBillingAddress = new()
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
        ApiEnum<string, Contracts::ProrationBehavior> expectedProrationBehavior =
            Contracts::ProrationBehavior.InvoiceImmediately;
        List<Contracts::TaxID> expectedTaxIds = [new() { Type = "type", Value = "value" }];
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
        var model = new Contracts::BillingInformation
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
            ProrationBehavior = Contracts::ProrationBehavior.InvoiceImmediately,
            TaxIds = [new() { Type = "type", Value = "value" }],
            TaxPercentage = 0,
            TaxRateIds = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Contracts::BillingInformation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Contracts::BillingInformation
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
            ProrationBehavior = Contracts::ProrationBehavior.InvoiceImmediately,
            TaxIds = [new() { Type = "type", Value = "value" }],
            TaxPercentage = 0,
            TaxRateIds = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Contracts::BillingInformation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Contracts::BillingAddress expectedBillingAddress = new()
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
        ApiEnum<string, Contracts::ProrationBehavior> expectedProrationBehavior =
            Contracts::ProrationBehavior.InvoiceImmediately;
        List<Contracts::TaxID> expectedTaxIds = [new() { Type = "type", Value = "value" }];
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
        var model = new Contracts::BillingInformation
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
            ProrationBehavior = Contracts::ProrationBehavior.InvoiceImmediately,
            TaxIds = [new() { Type = "type", Value = "value" }],
            TaxPercentage = 0,
            TaxRateIds = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Contracts::BillingInformation
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
        var model = new Contracts::BillingInformation
        {
            ChargeOnBehalfOfAccount = "chargeOnBehalfOfAccount",
            IntegrationID = "integrationId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Contracts::BillingInformation
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
        var model = new Contracts::BillingInformation
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
        var model = new Contracts::BillingInformation
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
            ProrationBehavior = Contracts::ProrationBehavior.InvoiceImmediately,
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
        var model = new Contracts::BillingInformation
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
            ProrationBehavior = Contracts::ProrationBehavior.InvoiceImmediately,
            TaxIds = [new() { Type = "type", Value = "value" }],
            TaxPercentage = 0,
            TaxRateIds = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Contracts::BillingInformation
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
            ProrationBehavior = Contracts::ProrationBehavior.InvoiceImmediately,
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
        var model = new Contracts::BillingInformation
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
            ProrationBehavior = Contracts::ProrationBehavior.InvoiceImmediately,
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
        var model = new Contracts::BillingInformation
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
            ProrationBehavior = Contracts::ProrationBehavior.InvoiceImmediately,
            TaxIds = [new() { Type = "type", Value = "value" }],
            TaxPercentage = 0,
            TaxRateIds = ["string"],
        };

        Contracts::BillingInformation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BillingAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Contracts::BillingAddress
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
        var model = new Contracts::BillingAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Contracts::BillingAddress>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Contracts::BillingAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Contracts::BillingAddress>(
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
        var model = new Contracts::BillingAddress
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
        var model = new Contracts::BillingAddress { };

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
        var model = new Contracts::BillingAddress { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Contracts::BillingAddress
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
        var model = new Contracts::BillingAddress
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
        var model = new Contracts::BillingAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };

        Contracts::BillingAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ProrationBehaviorTest : TestBase
{
    [Theory]
    [InlineData(Contracts::ProrationBehavior.InvoiceImmediately)]
    [InlineData(Contracts::ProrationBehavior.CreateProrations)]
    [InlineData(Contracts::ProrationBehavior.None)]
    public void Validation_Works(Contracts::ProrationBehavior rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Contracts::ProrationBehavior> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Contracts::ProrationBehavior>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Contracts::ProrationBehavior.InvoiceImmediately)]
    [InlineData(Contracts::ProrationBehavior.CreateProrations)]
    [InlineData(Contracts::ProrationBehavior.None)]
    public void SerializationRoundtrip_Works(Contracts::ProrationBehavior rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Contracts::ProrationBehavior> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Contracts::ProrationBehavior>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Contracts::ProrationBehavior>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Contracts::ProrationBehavior>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TaxIDTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Contracts::TaxID { Type = "type", Value = "value" };

        string expectedType = "type";
        string expectedValue = "value";

        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Contracts::TaxID { Type = "type", Value = "value" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Contracts::TaxID>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Contracts::TaxID { Type = "type", Value = "value" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Contracts::TaxID>(
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
        var model = new Contracts::TaxID { Type = "type", Value = "value" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Contracts::TaxID { Type = "type", Value = "value" };

        Contracts::TaxID copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BillingPeriodTest : TestBase
{
    [Theory]
    [InlineData(Contracts::BillingPeriod.Monthly)]
    [InlineData(Contracts::BillingPeriod.Annually)]
    public void Validation_Works(Contracts::BillingPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Contracts::BillingPeriod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Contracts::BillingPeriod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Contracts::BillingPeriod.Monthly)]
    [InlineData(Contracts::BillingPeriod.Annually)]
    public void SerializationRoundtrip_Works(Contracts::BillingPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Contracts::BillingPeriod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Contracts::BillingPeriod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Contracts::BillingPeriod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Contracts::BillingPeriod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class BudgetTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Contracts::Budget { HasSoftLimit = true, Limit = 0 };

        bool expectedHasSoftLimit = true;
        double expectedLimit = 0;

        Assert.Equal(expectedHasSoftLimit, model.HasSoftLimit);
        Assert.Equal(expectedLimit, model.Limit);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Contracts::Budget { HasSoftLimit = true, Limit = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Contracts::Budget>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Contracts::Budget { HasSoftLimit = true, Limit = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Contracts::Budget>(
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
        var model = new Contracts::Budget { HasSoftLimit = true, Limit = 0 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Contracts::Budget { HasSoftLimit = true, Limit = 0 };

        Contracts::Budget copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Contracts::Charge
        {
            ID = "id",
            Quantity = 0,
            Type = Contracts::Type.Feature,
        };

        string expectedID = "id";
        double expectedQuantity = 0;
        ApiEnum<string, Contracts::Type> expectedType = Contracts::Type.Feature;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedQuantity, model.Quantity);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Contracts::Charge
        {
            ID = "id",
            Quantity = 0,
            Type = Contracts::Type.Feature,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Contracts::Charge>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Contracts::Charge
        {
            ID = "id",
            Quantity = 0,
            Type = Contracts::Type.Feature,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Contracts::Charge>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        double expectedQuantity = 0;
        ApiEnum<string, Contracts::Type> expectedType = Contracts::Type.Feature;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedQuantity, deserialized.Quantity);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Contracts::Charge
        {
            ID = "id",
            Quantity = 0,
            Type = Contracts::Type.Feature,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Contracts::Charge
        {
            ID = "id",
            Quantity = 0,
            Type = Contracts::Type.Feature,
        };

        Contracts::Charge copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Contracts::Type.Feature)]
    [InlineData(Contracts::Type.Credit)]
    public void Validation_Works(Contracts::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Contracts::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Contracts::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Contracts::Type.Feature)]
    [InlineData(Contracts::Type.Credit)]
    public void SerializationRoundtrip_Works(Contracts::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Contracts::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Contracts::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Contracts::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Contracts::Type>>(
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
        var model = new Contracts::CheckoutOptions
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
        var model = new Contracts::CheckoutOptions
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
        var deserialized = JsonSerializer.Deserialize<Contracts::CheckoutOptions>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Contracts::CheckoutOptions
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
        var deserialized = JsonSerializer.Deserialize<Contracts::CheckoutOptions>(
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
        var model = new Contracts::CheckoutOptions
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
        var model = new Contracts::CheckoutOptions
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
        var model = new Contracts::CheckoutOptions
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
        var model = new Contracts::CheckoutOptions
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
        var model = new Contracts::CheckoutOptions
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
        var model = new Contracts::CheckoutOptions
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
        var model = new Contracts::CheckoutOptions
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
        var model = new Contracts::CheckoutOptions
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
        var model = new Contracts::CheckoutOptions
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
        var model = new Contracts::CheckoutOptions
        {
            CancelUrl = "https://example.com",
            SuccessUrl = "https://example.com",
            AllowPromoCodes = true,
            AllowTaxIDCollection = true,
            CollectBillingAddress = true,
            CollectPhoneNumber = true,
            ReferenceID = "referenceId",
        };

        Contracts::CheckoutOptions copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntitlementTest : TestBase
{
    [Fact]
    public void FeatureValidationWorks()
    {
        Contracts::Entitlement value = new Contracts::Feature()
        {
            ID = "id",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            MonthlyResetPeriodConfiguration = new(Contracts::AccordingTo.SubscriptionStart),
            ResetPeriod = Contracts::ResetPeriod.Year,
            UsageLimit = 0,
            WeeklyResetPeriodConfiguration = new(
                Contracts::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                Contracts::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };
        value.Validate();
    }

    [Fact]
    public void CreditValidationWorks()
    {
        Contracts::Entitlement value = new Contracts::Credit()
        {
            ID = "id",
            Amount = 1,
            Cadence = Contracts::Cadence.Month,
            HasSoftLimit = true,
        };
        value.Validate();
    }

    [Fact]
    public void FeatureSerializationRoundtripWorks()
    {
        Contracts::Entitlement value = new Contracts::Feature()
        {
            ID = "id",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            MonthlyResetPeriodConfiguration = new(Contracts::AccordingTo.SubscriptionStart),
            ResetPeriod = Contracts::ResetPeriod.Year,
            UsageLimit = 0,
            WeeklyResetPeriodConfiguration = new(
                Contracts::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                Contracts::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Contracts::Entitlement>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CreditSerializationRoundtripWorks()
    {
        Contracts::Entitlement value = new Contracts::Credit()
        {
            ID = "id",
            Amount = 1,
            Cadence = Contracts::Cadence.Month,
            HasSoftLimit = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Contracts::Entitlement>(
            element,
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
        var model = new Contracts::Feature
        {
            ID = "id",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            MonthlyResetPeriodConfiguration = new(Contracts::AccordingTo.SubscriptionStart),
            ResetPeriod = Contracts::ResetPeriod.Year,
            UsageLimit = 0,
            WeeklyResetPeriodConfiguration = new(
                Contracts::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                Contracts::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };

        string expectedID = "id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("FEATURE");
        bool expectedHasSoftLimit = true;
        bool expectedHasUnlimitedUsage = true;
        Contracts::MonthlyResetPeriodConfiguration expectedMonthlyResetPeriodConfiguration = new(
            Contracts::AccordingTo.SubscriptionStart
        );
        ApiEnum<string, Contracts::ResetPeriod> expectedResetPeriod = Contracts::ResetPeriod.Year;
        long expectedUsageLimit = 0;
        Contracts::WeeklyResetPeriodConfiguration expectedWeeklyResetPeriodConfiguration = new(
            Contracts::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
        );
        Contracts::YearlyResetPeriodConfiguration expectedYearlyResetPeriodConfiguration = new(
            Contracts::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
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
        var model = new Contracts::Feature
        {
            ID = "id",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            MonthlyResetPeriodConfiguration = new(Contracts::AccordingTo.SubscriptionStart),
            ResetPeriod = Contracts::ResetPeriod.Year,
            UsageLimit = 0,
            WeeklyResetPeriodConfiguration = new(
                Contracts::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                Contracts::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Contracts::Feature>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Contracts::Feature
        {
            ID = "id",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            MonthlyResetPeriodConfiguration = new(Contracts::AccordingTo.SubscriptionStart),
            ResetPeriod = Contracts::ResetPeriod.Year,
            UsageLimit = 0,
            WeeklyResetPeriodConfiguration = new(
                Contracts::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                Contracts::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Contracts::Feature>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("FEATURE");
        bool expectedHasSoftLimit = true;
        bool expectedHasUnlimitedUsage = true;
        Contracts::MonthlyResetPeriodConfiguration expectedMonthlyResetPeriodConfiguration = new(
            Contracts::AccordingTo.SubscriptionStart
        );
        ApiEnum<string, Contracts::ResetPeriod> expectedResetPeriod = Contracts::ResetPeriod.Year;
        long expectedUsageLimit = 0;
        Contracts::WeeklyResetPeriodConfiguration expectedWeeklyResetPeriodConfiguration = new(
            Contracts::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
        );
        Contracts::YearlyResetPeriodConfiguration expectedYearlyResetPeriodConfiguration = new(
            Contracts::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
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
        var model = new Contracts::Feature
        {
            ID = "id",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            MonthlyResetPeriodConfiguration = new(Contracts::AccordingTo.SubscriptionStart),
            ResetPeriod = Contracts::ResetPeriod.Year,
            UsageLimit = 0,
            WeeklyResetPeriodConfiguration = new(
                Contracts::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                Contracts::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Contracts::Feature
        {
            ID = "id",
            MonthlyResetPeriodConfiguration = new(Contracts::AccordingTo.SubscriptionStart),
            WeeklyResetPeriodConfiguration = new(
                Contracts::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                Contracts::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
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
        var model = new Contracts::Feature
        {
            ID = "id",
            MonthlyResetPeriodConfiguration = new(Contracts::AccordingTo.SubscriptionStart),
            WeeklyResetPeriodConfiguration = new(
                Contracts::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                Contracts::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Contracts::Feature
        {
            ID = "id",
            MonthlyResetPeriodConfiguration = new(Contracts::AccordingTo.SubscriptionStart),
            WeeklyResetPeriodConfiguration = new(
                Contracts::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                Contracts::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
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
        var model = new Contracts::Feature
        {
            ID = "id",
            MonthlyResetPeriodConfiguration = new(Contracts::AccordingTo.SubscriptionStart),
            WeeklyResetPeriodConfiguration = new(
                Contracts::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                Contracts::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
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
        var model = new Contracts::Feature
        {
            ID = "id",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            ResetPeriod = Contracts::ResetPeriod.Year,
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
        var model = new Contracts::Feature
        {
            ID = "id",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            ResetPeriod = Contracts::ResetPeriod.Year,
            UsageLimit = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Contracts::Feature
        {
            ID = "id",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            ResetPeriod = Contracts::ResetPeriod.Year,
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
        var model = new Contracts::Feature
        {
            ID = "id",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            ResetPeriod = Contracts::ResetPeriod.Year,
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
        var model = new Contracts::Feature
        {
            ID = "id",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            MonthlyResetPeriodConfiguration = new(Contracts::AccordingTo.SubscriptionStart),
            ResetPeriod = Contracts::ResetPeriod.Year,
            UsageLimit = 0,
            WeeklyResetPeriodConfiguration = new(
                Contracts::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                Contracts::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };

        Contracts::Feature copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MonthlyResetPeriodConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Contracts::MonthlyResetPeriodConfiguration
        {
            AccordingTo = Contracts::AccordingTo.SubscriptionStart,
        };

        ApiEnum<string, Contracts::AccordingTo> expectedAccordingTo =
            Contracts::AccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, model.AccordingTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Contracts::MonthlyResetPeriodConfiguration
        {
            AccordingTo = Contracts::AccordingTo.SubscriptionStart,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Contracts::MonthlyResetPeriodConfiguration>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Contracts::MonthlyResetPeriodConfiguration
        {
            AccordingTo = Contracts::AccordingTo.SubscriptionStart,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Contracts::MonthlyResetPeriodConfiguration>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Contracts::AccordingTo> expectedAccordingTo =
            Contracts::AccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, deserialized.AccordingTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Contracts::MonthlyResetPeriodConfiguration
        {
            AccordingTo = Contracts::AccordingTo.SubscriptionStart,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Contracts::MonthlyResetPeriodConfiguration
        {
            AccordingTo = Contracts::AccordingTo.SubscriptionStart,
        };

        Contracts::MonthlyResetPeriodConfiguration copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AccordingToTest : TestBase
{
    [Theory]
    [InlineData(Contracts::AccordingTo.SubscriptionStart)]
    [InlineData(Contracts::AccordingTo.StartOfTheMonth)]
    public void Validation_Works(Contracts::AccordingTo rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Contracts::AccordingTo> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Contracts::AccordingTo>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Contracts::AccordingTo.SubscriptionStart)]
    [InlineData(Contracts::AccordingTo.StartOfTheMonth)]
    public void SerializationRoundtrip_Works(Contracts::AccordingTo rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Contracts::AccordingTo> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Contracts::AccordingTo>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Contracts::AccordingTo>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Contracts::AccordingTo>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ResetPeriodTest : TestBase
{
    [Theory]
    [InlineData(Contracts::ResetPeriod.Year)]
    [InlineData(Contracts::ResetPeriod.Month)]
    [InlineData(Contracts::ResetPeriod.Week)]
    [InlineData(Contracts::ResetPeriod.Day)]
    [InlineData(Contracts::ResetPeriod.Hour)]
    public void Validation_Works(Contracts::ResetPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Contracts::ResetPeriod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Contracts::ResetPeriod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Contracts::ResetPeriod.Year)]
    [InlineData(Contracts::ResetPeriod.Month)]
    [InlineData(Contracts::ResetPeriod.Week)]
    [InlineData(Contracts::ResetPeriod.Day)]
    [InlineData(Contracts::ResetPeriod.Hour)]
    public void SerializationRoundtrip_Works(Contracts::ResetPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Contracts::ResetPeriod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Contracts::ResetPeriod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Contracts::ResetPeriod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Contracts::ResetPeriod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class WeeklyResetPeriodConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Contracts::WeeklyResetPeriodConfiguration
        {
            AccordingTo = Contracts::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        ApiEnum<string, Contracts::WeeklyResetPeriodConfigurationAccordingTo> expectedAccordingTo =
            Contracts::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, model.AccordingTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Contracts::WeeklyResetPeriodConfiguration
        {
            AccordingTo = Contracts::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Contracts::WeeklyResetPeriodConfiguration>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Contracts::WeeklyResetPeriodConfiguration
        {
            AccordingTo = Contracts::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Contracts::WeeklyResetPeriodConfiguration>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Contracts::WeeklyResetPeriodConfigurationAccordingTo> expectedAccordingTo =
            Contracts::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, deserialized.AccordingTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Contracts::WeeklyResetPeriodConfiguration
        {
            AccordingTo = Contracts::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Contracts::WeeklyResetPeriodConfiguration
        {
            AccordingTo = Contracts::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        Contracts::WeeklyResetPeriodConfiguration copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WeeklyResetPeriodConfigurationAccordingToTest : TestBase
{
    [Theory]
    [InlineData(Contracts::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart)]
    [InlineData(Contracts::WeeklyResetPeriodConfigurationAccordingTo.EverySunday)]
    [InlineData(Contracts::WeeklyResetPeriodConfigurationAccordingTo.EveryMonday)]
    [InlineData(Contracts::WeeklyResetPeriodConfigurationAccordingTo.EveryTuesday)]
    [InlineData(Contracts::WeeklyResetPeriodConfigurationAccordingTo.EveryWednesday)]
    [InlineData(Contracts::WeeklyResetPeriodConfigurationAccordingTo.EveryThursday)]
    [InlineData(Contracts::WeeklyResetPeriodConfigurationAccordingTo.EveryFriday)]
    [InlineData(Contracts::WeeklyResetPeriodConfigurationAccordingTo.EverySaturday)]
    public void Validation_Works(Contracts::WeeklyResetPeriodConfigurationAccordingTo rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Contracts::WeeklyResetPeriodConfigurationAccordingTo> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Contracts::WeeklyResetPeriodConfigurationAccordingTo>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Contracts::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart)]
    [InlineData(Contracts::WeeklyResetPeriodConfigurationAccordingTo.EverySunday)]
    [InlineData(Contracts::WeeklyResetPeriodConfigurationAccordingTo.EveryMonday)]
    [InlineData(Contracts::WeeklyResetPeriodConfigurationAccordingTo.EveryTuesday)]
    [InlineData(Contracts::WeeklyResetPeriodConfigurationAccordingTo.EveryWednesday)]
    [InlineData(Contracts::WeeklyResetPeriodConfigurationAccordingTo.EveryThursday)]
    [InlineData(Contracts::WeeklyResetPeriodConfigurationAccordingTo.EveryFriday)]
    [InlineData(Contracts::WeeklyResetPeriodConfigurationAccordingTo.EverySaturday)]
    public void SerializationRoundtrip_Works(
        Contracts::WeeklyResetPeriodConfigurationAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Contracts::WeeklyResetPeriodConfigurationAccordingTo> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Contracts::WeeklyResetPeriodConfigurationAccordingTo>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Contracts::WeeklyResetPeriodConfigurationAccordingTo>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Contracts::WeeklyResetPeriodConfigurationAccordingTo>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class YearlyResetPeriodConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Contracts::YearlyResetPeriodConfiguration
        {
            AccordingTo = Contracts::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        ApiEnum<string, Contracts::YearlyResetPeriodConfigurationAccordingTo> expectedAccordingTo =
            Contracts::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, model.AccordingTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Contracts::YearlyResetPeriodConfiguration
        {
            AccordingTo = Contracts::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Contracts::YearlyResetPeriodConfiguration>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Contracts::YearlyResetPeriodConfiguration
        {
            AccordingTo = Contracts::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Contracts::YearlyResetPeriodConfiguration>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Contracts::YearlyResetPeriodConfigurationAccordingTo> expectedAccordingTo =
            Contracts::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, deserialized.AccordingTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Contracts::YearlyResetPeriodConfiguration
        {
            AccordingTo = Contracts::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Contracts::YearlyResetPeriodConfiguration
        {
            AccordingTo = Contracts::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        Contracts::YearlyResetPeriodConfiguration copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class YearlyResetPeriodConfigurationAccordingToTest : TestBase
{
    [Theory]
    [InlineData(Contracts::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart)]
    public void Validation_Works(Contracts::YearlyResetPeriodConfigurationAccordingTo rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Contracts::YearlyResetPeriodConfigurationAccordingTo> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Contracts::YearlyResetPeriodConfigurationAccordingTo>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Contracts::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart)]
    public void SerializationRoundtrip_Works(
        Contracts::YearlyResetPeriodConfigurationAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Contracts::YearlyResetPeriodConfigurationAccordingTo> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Contracts::YearlyResetPeriodConfigurationAccordingTo>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Contracts::YearlyResetPeriodConfigurationAccordingTo>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Contracts::YearlyResetPeriodConfigurationAccordingTo>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CreditTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Contracts::Credit
        {
            ID = "id",
            Amount = 1,
            Cadence = Contracts::Cadence.Month,
            HasSoftLimit = true,
        };

        string expectedID = "id";
        double expectedAmount = 1;
        ApiEnum<string, Contracts::Cadence> expectedCadence = Contracts::Cadence.Month;
        JsonElement expectedType = JsonSerializer.SerializeToElement("CREDIT");
        bool expectedHasSoftLimit = true;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCadence, model.Cadence);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedHasSoftLimit, model.HasSoftLimit);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Contracts::Credit
        {
            ID = "id",
            Amount = 1,
            Cadence = Contracts::Cadence.Month,
            HasSoftLimit = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Contracts::Credit>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Contracts::Credit
        {
            ID = "id",
            Amount = 1,
            Cadence = Contracts::Cadence.Month,
            HasSoftLimit = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Contracts::Credit>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        double expectedAmount = 1;
        ApiEnum<string, Contracts::Cadence> expectedCadence = Contracts::Cadence.Month;
        JsonElement expectedType = JsonSerializer.SerializeToElement("CREDIT");
        bool expectedHasSoftLimit = true;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCadence, deserialized.Cadence);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedHasSoftLimit, deserialized.HasSoftLimit);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Contracts::Credit
        {
            ID = "id",
            Amount = 1,
            Cadence = Contracts::Cadence.Month,
            HasSoftLimit = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Contracts::Credit
        {
            ID = "id",
            Amount = 1,
            Cadence = Contracts::Cadence.Month,
        };

        Assert.Null(model.HasSoftLimit);
        Assert.False(model.RawData.ContainsKey("hasSoftLimit"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Contracts::Credit
        {
            ID = "id",
            Amount = 1,
            Cadence = Contracts::Cadence.Month,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Contracts::Credit
        {
            ID = "id",
            Amount = 1,
            Cadence = Contracts::Cadence.Month,

            // Null should be interpreted as omitted for these properties
            HasSoftLimit = null,
        };

        Assert.Null(model.HasSoftLimit);
        Assert.False(model.RawData.ContainsKey("hasSoftLimit"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Contracts::Credit
        {
            ID = "id",
            Amount = 1,
            Cadence = Contracts::Cadence.Month,

            // Null should be interpreted as omitted for these properties
            HasSoftLimit = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Contracts::Credit
        {
            ID = "id",
            Amount = 1,
            Cadence = Contracts::Cadence.Month,
            HasSoftLimit = true,
        };

        Contracts::Credit copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CadenceTest : TestBase
{
    [Theory]
    [InlineData(Contracts::Cadence.Month)]
    [InlineData(Contracts::Cadence.Year)]
    public void Validation_Works(Contracts::Cadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Contracts::Cadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Contracts::Cadence>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Contracts::Cadence.Month)]
    [InlineData(Contracts::Cadence.Year)]
    public void SerializationRoundtrip_Works(Contracts::Cadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Contracts::Cadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Contracts::Cadence>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Contracts::Cadence>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Contracts::Cadence>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class MinimumSpendTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Contracts::MinimumSpend
        {
            Amount = 0,
            Currency = Contracts::MinimumSpendCurrency.Usd,
        };

        double expectedAmount = 0;
        ApiEnum<string, Contracts::MinimumSpendCurrency> expectedCurrency =
            Contracts::MinimumSpendCurrency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Contracts::MinimumSpend
        {
            Amount = 0,
            Currency = Contracts::MinimumSpendCurrency.Usd,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Contracts::MinimumSpend>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Contracts::MinimumSpend
        {
            Amount = 0,
            Currency = Contracts::MinimumSpendCurrency.Usd,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Contracts::MinimumSpend>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        ApiEnum<string, Contracts::MinimumSpendCurrency> expectedCurrency =
            Contracts::MinimumSpendCurrency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Contracts::MinimumSpend
        {
            Amount = 0,
            Currency = Contracts::MinimumSpendCurrency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Contracts::MinimumSpend { };

        Assert.Null(model.Amount);
        Assert.False(model.RawData.ContainsKey("amount"));
        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Contracts::MinimumSpend { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Contracts::MinimumSpend
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
        var model = new Contracts::MinimumSpend
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
        var model = new Contracts::MinimumSpend
        {
            Amount = 0,
            Currency = Contracts::MinimumSpendCurrency.Usd,
        };

        Contracts::MinimumSpend copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MinimumSpendCurrencyTest : TestBase
{
    [Theory]
    [InlineData(Contracts::MinimumSpendCurrency.Usd)]
    [InlineData(Contracts::MinimumSpendCurrency.Aed)]
    [InlineData(Contracts::MinimumSpendCurrency.All)]
    [InlineData(Contracts::MinimumSpendCurrency.Amd)]
    [InlineData(Contracts::MinimumSpendCurrency.Ang)]
    [InlineData(Contracts::MinimumSpendCurrency.Aud)]
    [InlineData(Contracts::MinimumSpendCurrency.Awg)]
    [InlineData(Contracts::MinimumSpendCurrency.Azn)]
    [InlineData(Contracts::MinimumSpendCurrency.Bam)]
    [InlineData(Contracts::MinimumSpendCurrency.Bbd)]
    [InlineData(Contracts::MinimumSpendCurrency.Bdt)]
    [InlineData(Contracts::MinimumSpendCurrency.Bgn)]
    [InlineData(Contracts::MinimumSpendCurrency.Bif)]
    [InlineData(Contracts::MinimumSpendCurrency.Bmd)]
    [InlineData(Contracts::MinimumSpendCurrency.Bnd)]
    [InlineData(Contracts::MinimumSpendCurrency.Bsd)]
    [InlineData(Contracts::MinimumSpendCurrency.Bwp)]
    [InlineData(Contracts::MinimumSpendCurrency.Byn)]
    [InlineData(Contracts::MinimumSpendCurrency.Bzd)]
    [InlineData(Contracts::MinimumSpendCurrency.Brl)]
    [InlineData(Contracts::MinimumSpendCurrency.Cad)]
    [InlineData(Contracts::MinimumSpendCurrency.Cdf)]
    [InlineData(Contracts::MinimumSpendCurrency.Chf)]
    [InlineData(Contracts::MinimumSpendCurrency.Cny)]
    [InlineData(Contracts::MinimumSpendCurrency.Czk)]
    [InlineData(Contracts::MinimumSpendCurrency.Dkk)]
    [InlineData(Contracts::MinimumSpendCurrency.Dop)]
    [InlineData(Contracts::MinimumSpendCurrency.Dzd)]
    [InlineData(Contracts::MinimumSpendCurrency.Egp)]
    [InlineData(Contracts::MinimumSpendCurrency.Etb)]
    [InlineData(Contracts::MinimumSpendCurrency.Eur)]
    [InlineData(Contracts::MinimumSpendCurrency.Fjd)]
    [InlineData(Contracts::MinimumSpendCurrency.Gbp)]
    [InlineData(Contracts::MinimumSpendCurrency.Gel)]
    [InlineData(Contracts::MinimumSpendCurrency.Gip)]
    [InlineData(Contracts::MinimumSpendCurrency.Gmd)]
    [InlineData(Contracts::MinimumSpendCurrency.Gyd)]
    [InlineData(Contracts::MinimumSpendCurrency.Hkd)]
    [InlineData(Contracts::MinimumSpendCurrency.Hrk)]
    [InlineData(Contracts::MinimumSpendCurrency.Htg)]
    [InlineData(Contracts::MinimumSpendCurrency.Idr)]
    [InlineData(Contracts::MinimumSpendCurrency.Ils)]
    [InlineData(Contracts::MinimumSpendCurrency.Inr)]
    [InlineData(Contracts::MinimumSpendCurrency.Isk)]
    [InlineData(Contracts::MinimumSpendCurrency.Jmd)]
    [InlineData(Contracts::MinimumSpendCurrency.Jpy)]
    [InlineData(Contracts::MinimumSpendCurrency.Kes)]
    [InlineData(Contracts::MinimumSpendCurrency.Kgs)]
    [InlineData(Contracts::MinimumSpendCurrency.Khr)]
    [InlineData(Contracts::MinimumSpendCurrency.Kmf)]
    [InlineData(Contracts::MinimumSpendCurrency.Krw)]
    [InlineData(Contracts::MinimumSpendCurrency.Kyd)]
    [InlineData(Contracts::MinimumSpendCurrency.Kzt)]
    [InlineData(Contracts::MinimumSpendCurrency.Lbp)]
    [InlineData(Contracts::MinimumSpendCurrency.Lkr)]
    [InlineData(Contracts::MinimumSpendCurrency.Lrd)]
    [InlineData(Contracts::MinimumSpendCurrency.Lsl)]
    [InlineData(Contracts::MinimumSpendCurrency.Mad)]
    [InlineData(Contracts::MinimumSpendCurrency.Mdl)]
    [InlineData(Contracts::MinimumSpendCurrency.Mga)]
    [InlineData(Contracts::MinimumSpendCurrency.Mkd)]
    [InlineData(Contracts::MinimumSpendCurrency.Mmk)]
    [InlineData(Contracts::MinimumSpendCurrency.Mnt)]
    [InlineData(Contracts::MinimumSpendCurrency.Mop)]
    [InlineData(Contracts::MinimumSpendCurrency.Mro)]
    [InlineData(Contracts::MinimumSpendCurrency.Mvr)]
    [InlineData(Contracts::MinimumSpendCurrency.Mwk)]
    [InlineData(Contracts::MinimumSpendCurrency.Mxn)]
    [InlineData(Contracts::MinimumSpendCurrency.Myr)]
    [InlineData(Contracts::MinimumSpendCurrency.Mzn)]
    [InlineData(Contracts::MinimumSpendCurrency.Nad)]
    [InlineData(Contracts::MinimumSpendCurrency.Ngn)]
    [InlineData(Contracts::MinimumSpendCurrency.Nok)]
    [InlineData(Contracts::MinimumSpendCurrency.Npr)]
    [InlineData(Contracts::MinimumSpendCurrency.Nzd)]
    [InlineData(Contracts::MinimumSpendCurrency.Pgk)]
    [InlineData(Contracts::MinimumSpendCurrency.Php)]
    [InlineData(Contracts::MinimumSpendCurrency.Pkr)]
    [InlineData(Contracts::MinimumSpendCurrency.Pln)]
    [InlineData(Contracts::MinimumSpendCurrency.Qar)]
    [InlineData(Contracts::MinimumSpendCurrency.Ron)]
    [InlineData(Contracts::MinimumSpendCurrency.Rsd)]
    [InlineData(Contracts::MinimumSpendCurrency.Rub)]
    [InlineData(Contracts::MinimumSpendCurrency.Rwf)]
    [InlineData(Contracts::MinimumSpendCurrency.Sar)]
    [InlineData(Contracts::MinimumSpendCurrency.Sbd)]
    [InlineData(Contracts::MinimumSpendCurrency.Scr)]
    [InlineData(Contracts::MinimumSpendCurrency.Sek)]
    [InlineData(Contracts::MinimumSpendCurrency.Sgd)]
    [InlineData(Contracts::MinimumSpendCurrency.Sle)]
    [InlineData(Contracts::MinimumSpendCurrency.Sll)]
    [InlineData(Contracts::MinimumSpendCurrency.Sos)]
    [InlineData(Contracts::MinimumSpendCurrency.Szl)]
    [InlineData(Contracts::MinimumSpendCurrency.Thb)]
    [InlineData(Contracts::MinimumSpendCurrency.Tjs)]
    [InlineData(Contracts::MinimumSpendCurrency.Top)]
    [InlineData(Contracts::MinimumSpendCurrency.Try)]
    [InlineData(Contracts::MinimumSpendCurrency.Ttd)]
    [InlineData(Contracts::MinimumSpendCurrency.Tzs)]
    [InlineData(Contracts::MinimumSpendCurrency.Uah)]
    [InlineData(Contracts::MinimumSpendCurrency.Uzs)]
    [InlineData(Contracts::MinimumSpendCurrency.Vnd)]
    [InlineData(Contracts::MinimumSpendCurrency.Vuv)]
    [InlineData(Contracts::MinimumSpendCurrency.Wst)]
    [InlineData(Contracts::MinimumSpendCurrency.Xaf)]
    [InlineData(Contracts::MinimumSpendCurrency.Xcd)]
    [InlineData(Contracts::MinimumSpendCurrency.Yer)]
    [InlineData(Contracts::MinimumSpendCurrency.Zar)]
    [InlineData(Contracts::MinimumSpendCurrency.Zmw)]
    [InlineData(Contracts::MinimumSpendCurrency.Clp)]
    [InlineData(Contracts::MinimumSpendCurrency.Djf)]
    [InlineData(Contracts::MinimumSpendCurrency.Gnf)]
    [InlineData(Contracts::MinimumSpendCurrency.Ugx)]
    [InlineData(Contracts::MinimumSpendCurrency.Pyg)]
    [InlineData(Contracts::MinimumSpendCurrency.Xof)]
    [InlineData(Contracts::MinimumSpendCurrency.Xpf)]
    public void Validation_Works(Contracts::MinimumSpendCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Contracts::MinimumSpendCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Contracts::MinimumSpendCurrency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Contracts::MinimumSpendCurrency.Usd)]
    [InlineData(Contracts::MinimumSpendCurrency.Aed)]
    [InlineData(Contracts::MinimumSpendCurrency.All)]
    [InlineData(Contracts::MinimumSpendCurrency.Amd)]
    [InlineData(Contracts::MinimumSpendCurrency.Ang)]
    [InlineData(Contracts::MinimumSpendCurrency.Aud)]
    [InlineData(Contracts::MinimumSpendCurrency.Awg)]
    [InlineData(Contracts::MinimumSpendCurrency.Azn)]
    [InlineData(Contracts::MinimumSpendCurrency.Bam)]
    [InlineData(Contracts::MinimumSpendCurrency.Bbd)]
    [InlineData(Contracts::MinimumSpendCurrency.Bdt)]
    [InlineData(Contracts::MinimumSpendCurrency.Bgn)]
    [InlineData(Contracts::MinimumSpendCurrency.Bif)]
    [InlineData(Contracts::MinimumSpendCurrency.Bmd)]
    [InlineData(Contracts::MinimumSpendCurrency.Bnd)]
    [InlineData(Contracts::MinimumSpendCurrency.Bsd)]
    [InlineData(Contracts::MinimumSpendCurrency.Bwp)]
    [InlineData(Contracts::MinimumSpendCurrency.Byn)]
    [InlineData(Contracts::MinimumSpendCurrency.Bzd)]
    [InlineData(Contracts::MinimumSpendCurrency.Brl)]
    [InlineData(Contracts::MinimumSpendCurrency.Cad)]
    [InlineData(Contracts::MinimumSpendCurrency.Cdf)]
    [InlineData(Contracts::MinimumSpendCurrency.Chf)]
    [InlineData(Contracts::MinimumSpendCurrency.Cny)]
    [InlineData(Contracts::MinimumSpendCurrency.Czk)]
    [InlineData(Contracts::MinimumSpendCurrency.Dkk)]
    [InlineData(Contracts::MinimumSpendCurrency.Dop)]
    [InlineData(Contracts::MinimumSpendCurrency.Dzd)]
    [InlineData(Contracts::MinimumSpendCurrency.Egp)]
    [InlineData(Contracts::MinimumSpendCurrency.Etb)]
    [InlineData(Contracts::MinimumSpendCurrency.Eur)]
    [InlineData(Contracts::MinimumSpendCurrency.Fjd)]
    [InlineData(Contracts::MinimumSpendCurrency.Gbp)]
    [InlineData(Contracts::MinimumSpendCurrency.Gel)]
    [InlineData(Contracts::MinimumSpendCurrency.Gip)]
    [InlineData(Contracts::MinimumSpendCurrency.Gmd)]
    [InlineData(Contracts::MinimumSpendCurrency.Gyd)]
    [InlineData(Contracts::MinimumSpendCurrency.Hkd)]
    [InlineData(Contracts::MinimumSpendCurrency.Hrk)]
    [InlineData(Contracts::MinimumSpendCurrency.Htg)]
    [InlineData(Contracts::MinimumSpendCurrency.Idr)]
    [InlineData(Contracts::MinimumSpendCurrency.Ils)]
    [InlineData(Contracts::MinimumSpendCurrency.Inr)]
    [InlineData(Contracts::MinimumSpendCurrency.Isk)]
    [InlineData(Contracts::MinimumSpendCurrency.Jmd)]
    [InlineData(Contracts::MinimumSpendCurrency.Jpy)]
    [InlineData(Contracts::MinimumSpendCurrency.Kes)]
    [InlineData(Contracts::MinimumSpendCurrency.Kgs)]
    [InlineData(Contracts::MinimumSpendCurrency.Khr)]
    [InlineData(Contracts::MinimumSpendCurrency.Kmf)]
    [InlineData(Contracts::MinimumSpendCurrency.Krw)]
    [InlineData(Contracts::MinimumSpendCurrency.Kyd)]
    [InlineData(Contracts::MinimumSpendCurrency.Kzt)]
    [InlineData(Contracts::MinimumSpendCurrency.Lbp)]
    [InlineData(Contracts::MinimumSpendCurrency.Lkr)]
    [InlineData(Contracts::MinimumSpendCurrency.Lrd)]
    [InlineData(Contracts::MinimumSpendCurrency.Lsl)]
    [InlineData(Contracts::MinimumSpendCurrency.Mad)]
    [InlineData(Contracts::MinimumSpendCurrency.Mdl)]
    [InlineData(Contracts::MinimumSpendCurrency.Mga)]
    [InlineData(Contracts::MinimumSpendCurrency.Mkd)]
    [InlineData(Contracts::MinimumSpendCurrency.Mmk)]
    [InlineData(Contracts::MinimumSpendCurrency.Mnt)]
    [InlineData(Contracts::MinimumSpendCurrency.Mop)]
    [InlineData(Contracts::MinimumSpendCurrency.Mro)]
    [InlineData(Contracts::MinimumSpendCurrency.Mvr)]
    [InlineData(Contracts::MinimumSpendCurrency.Mwk)]
    [InlineData(Contracts::MinimumSpendCurrency.Mxn)]
    [InlineData(Contracts::MinimumSpendCurrency.Myr)]
    [InlineData(Contracts::MinimumSpendCurrency.Mzn)]
    [InlineData(Contracts::MinimumSpendCurrency.Nad)]
    [InlineData(Contracts::MinimumSpendCurrency.Ngn)]
    [InlineData(Contracts::MinimumSpendCurrency.Nok)]
    [InlineData(Contracts::MinimumSpendCurrency.Npr)]
    [InlineData(Contracts::MinimumSpendCurrency.Nzd)]
    [InlineData(Contracts::MinimumSpendCurrency.Pgk)]
    [InlineData(Contracts::MinimumSpendCurrency.Php)]
    [InlineData(Contracts::MinimumSpendCurrency.Pkr)]
    [InlineData(Contracts::MinimumSpendCurrency.Pln)]
    [InlineData(Contracts::MinimumSpendCurrency.Qar)]
    [InlineData(Contracts::MinimumSpendCurrency.Ron)]
    [InlineData(Contracts::MinimumSpendCurrency.Rsd)]
    [InlineData(Contracts::MinimumSpendCurrency.Rub)]
    [InlineData(Contracts::MinimumSpendCurrency.Rwf)]
    [InlineData(Contracts::MinimumSpendCurrency.Sar)]
    [InlineData(Contracts::MinimumSpendCurrency.Sbd)]
    [InlineData(Contracts::MinimumSpendCurrency.Scr)]
    [InlineData(Contracts::MinimumSpendCurrency.Sek)]
    [InlineData(Contracts::MinimumSpendCurrency.Sgd)]
    [InlineData(Contracts::MinimumSpendCurrency.Sle)]
    [InlineData(Contracts::MinimumSpendCurrency.Sll)]
    [InlineData(Contracts::MinimumSpendCurrency.Sos)]
    [InlineData(Contracts::MinimumSpendCurrency.Szl)]
    [InlineData(Contracts::MinimumSpendCurrency.Thb)]
    [InlineData(Contracts::MinimumSpendCurrency.Tjs)]
    [InlineData(Contracts::MinimumSpendCurrency.Top)]
    [InlineData(Contracts::MinimumSpendCurrency.Try)]
    [InlineData(Contracts::MinimumSpendCurrency.Ttd)]
    [InlineData(Contracts::MinimumSpendCurrency.Tzs)]
    [InlineData(Contracts::MinimumSpendCurrency.Uah)]
    [InlineData(Contracts::MinimumSpendCurrency.Uzs)]
    [InlineData(Contracts::MinimumSpendCurrency.Vnd)]
    [InlineData(Contracts::MinimumSpendCurrency.Vuv)]
    [InlineData(Contracts::MinimumSpendCurrency.Wst)]
    [InlineData(Contracts::MinimumSpendCurrency.Xaf)]
    [InlineData(Contracts::MinimumSpendCurrency.Xcd)]
    [InlineData(Contracts::MinimumSpendCurrency.Yer)]
    [InlineData(Contracts::MinimumSpendCurrency.Zar)]
    [InlineData(Contracts::MinimumSpendCurrency.Zmw)]
    [InlineData(Contracts::MinimumSpendCurrency.Clp)]
    [InlineData(Contracts::MinimumSpendCurrency.Djf)]
    [InlineData(Contracts::MinimumSpendCurrency.Gnf)]
    [InlineData(Contracts::MinimumSpendCurrency.Ugx)]
    [InlineData(Contracts::MinimumSpendCurrency.Pyg)]
    [InlineData(Contracts::MinimumSpendCurrency.Xof)]
    [InlineData(Contracts::MinimumSpendCurrency.Xpf)]
    public void SerializationRoundtrip_Works(Contracts::MinimumSpendCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Contracts::MinimumSpendCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Contracts::MinimumSpendCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Contracts::MinimumSpendCurrency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Contracts::MinimumSpendCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PaymentCollectionMethodTest : TestBase
{
    [Theory]
    [InlineData(Contracts::PaymentCollectionMethod.Charge)]
    [InlineData(Contracts::PaymentCollectionMethod.Invoice)]
    [InlineData(Contracts::PaymentCollectionMethod.None)]
    public void Validation_Works(Contracts::PaymentCollectionMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Contracts::PaymentCollectionMethod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Contracts::PaymentCollectionMethod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Contracts::PaymentCollectionMethod.Charge)]
    [InlineData(Contracts::PaymentCollectionMethod.Invoice)]
    [InlineData(Contracts::PaymentCollectionMethod.None)]
    public void SerializationRoundtrip_Works(Contracts::PaymentCollectionMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Contracts::PaymentCollectionMethod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Contracts::PaymentCollectionMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Contracts::PaymentCollectionMethod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Contracts::PaymentCollectionMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PriceOverrideTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Contracts::PriceOverride
        {
            AddonID = "addonId",
            Amount = 0,
            BaseCharge = true,
            BillingCountryCode = "billingCountryCode",
            BlockSize = 0,
            CreditGrantCadence = Contracts::CreditGrantCadence.BeginningOfBillingPeriod,
            CreditRate = new()
            {
                Amount = 1,
                CurrencyID = "currencyId",
                CostFormula = "costFormula",
            },
            Currency = Contracts::PriceOverrideCurrency.Usd,
            FeatureID = "featureId",
            Tiers =
            [
                new()
                {
                    FlatPrice = new() { Amount = 0, Currency = Contracts::FlatPriceCurrency.Usd },
                    UnitPrice = new() { Amount = 0, Currency = Contracts::UnitPriceCurrency.Usd },
                    UpTo = 0,
                },
            ],
        };

        string expectedAddonID = "addonId";
        double expectedAmount = 0;
        bool expectedBaseCharge = true;
        string expectedBillingCountryCode = "billingCountryCode";
        double expectedBlockSize = 0;
        ApiEnum<string, Contracts::CreditGrantCadence> expectedCreditGrantCadence =
            Contracts::CreditGrantCadence.BeginningOfBillingPeriod;
        Contracts::CreditRate expectedCreditRate = new()
        {
            Amount = 1,
            CurrencyID = "currencyId",
            CostFormula = "costFormula",
        };
        ApiEnum<string, Contracts::PriceOverrideCurrency> expectedCurrency =
            Contracts::PriceOverrideCurrency.Usd;
        string expectedFeatureID = "featureId";
        List<Contracts::Tier> expectedTiers =
        [
            new()
            {
                FlatPrice = new() { Amount = 0, Currency = Contracts::FlatPriceCurrency.Usd },
                UnitPrice = new() { Amount = 0, Currency = Contracts::UnitPriceCurrency.Usd },
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
        var model = new Contracts::PriceOverride
        {
            AddonID = "addonId",
            Amount = 0,
            BaseCharge = true,
            BillingCountryCode = "billingCountryCode",
            BlockSize = 0,
            CreditGrantCadence = Contracts::CreditGrantCadence.BeginningOfBillingPeriod,
            CreditRate = new()
            {
                Amount = 1,
                CurrencyID = "currencyId",
                CostFormula = "costFormula",
            },
            Currency = Contracts::PriceOverrideCurrency.Usd,
            FeatureID = "featureId",
            Tiers =
            [
                new()
                {
                    FlatPrice = new() { Amount = 0, Currency = Contracts::FlatPriceCurrency.Usd },
                    UnitPrice = new() { Amount = 0, Currency = Contracts::UnitPriceCurrency.Usd },
                    UpTo = 0,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Contracts::PriceOverride>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Contracts::PriceOverride
        {
            AddonID = "addonId",
            Amount = 0,
            BaseCharge = true,
            BillingCountryCode = "billingCountryCode",
            BlockSize = 0,
            CreditGrantCadence = Contracts::CreditGrantCadence.BeginningOfBillingPeriod,
            CreditRate = new()
            {
                Amount = 1,
                CurrencyID = "currencyId",
                CostFormula = "costFormula",
            },
            Currency = Contracts::PriceOverrideCurrency.Usd,
            FeatureID = "featureId",
            Tiers =
            [
                new()
                {
                    FlatPrice = new() { Amount = 0, Currency = Contracts::FlatPriceCurrency.Usd },
                    UnitPrice = new() { Amount = 0, Currency = Contracts::UnitPriceCurrency.Usd },
                    UpTo = 0,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Contracts::PriceOverride>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAddonID = "addonId";
        double expectedAmount = 0;
        bool expectedBaseCharge = true;
        string expectedBillingCountryCode = "billingCountryCode";
        double expectedBlockSize = 0;
        ApiEnum<string, Contracts::CreditGrantCadence> expectedCreditGrantCadence =
            Contracts::CreditGrantCadence.BeginningOfBillingPeriod;
        Contracts::CreditRate expectedCreditRate = new()
        {
            Amount = 1,
            CurrencyID = "currencyId",
            CostFormula = "costFormula",
        };
        ApiEnum<string, Contracts::PriceOverrideCurrency> expectedCurrency =
            Contracts::PriceOverrideCurrency.Usd;
        string expectedFeatureID = "featureId";
        List<Contracts::Tier> expectedTiers =
        [
            new()
            {
                FlatPrice = new() { Amount = 0, Currency = Contracts::FlatPriceCurrency.Usd },
                UnitPrice = new() { Amount = 0, Currency = Contracts::UnitPriceCurrency.Usd },
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
        var model = new Contracts::PriceOverride
        {
            AddonID = "addonId",
            Amount = 0,
            BaseCharge = true,
            BillingCountryCode = "billingCountryCode",
            BlockSize = 0,
            CreditGrantCadence = Contracts::CreditGrantCadence.BeginningOfBillingPeriod,
            CreditRate = new()
            {
                Amount = 1,
                CurrencyID = "currencyId",
                CostFormula = "costFormula",
            },
            Currency = Contracts::PriceOverrideCurrency.Usd,
            FeatureID = "featureId",
            Tiers =
            [
                new()
                {
                    FlatPrice = new() { Amount = 0, Currency = Contracts::FlatPriceCurrency.Usd },
                    UnitPrice = new() { Amount = 0, Currency = Contracts::UnitPriceCurrency.Usd },
                    UpTo = 0,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Contracts::PriceOverride { AddonID = "addonId", FeatureID = "featureId" };

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
        var model = new Contracts::PriceOverride { AddonID = "addonId", FeatureID = "featureId" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Contracts::PriceOverride
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
        var model = new Contracts::PriceOverride
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
        var model = new Contracts::PriceOverride
        {
            Amount = 0,
            BaseCharge = true,
            BillingCountryCode = "billingCountryCode",
            BlockSize = 0,
            CreditGrantCadence = Contracts::CreditGrantCadence.BeginningOfBillingPeriod,
            CreditRate = new()
            {
                Amount = 1,
                CurrencyID = "currencyId",
                CostFormula = "costFormula",
            },
            Currency = Contracts::PriceOverrideCurrency.Usd,
            Tiers =
            [
                new()
                {
                    FlatPrice = new() { Amount = 0, Currency = Contracts::FlatPriceCurrency.Usd },
                    UnitPrice = new() { Amount = 0, Currency = Contracts::UnitPriceCurrency.Usd },
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
        var model = new Contracts::PriceOverride
        {
            Amount = 0,
            BaseCharge = true,
            BillingCountryCode = "billingCountryCode",
            BlockSize = 0,
            CreditGrantCadence = Contracts::CreditGrantCadence.BeginningOfBillingPeriod,
            CreditRate = new()
            {
                Amount = 1,
                CurrencyID = "currencyId",
                CostFormula = "costFormula",
            },
            Currency = Contracts::PriceOverrideCurrency.Usd,
            Tiers =
            [
                new()
                {
                    FlatPrice = new() { Amount = 0, Currency = Contracts::FlatPriceCurrency.Usd },
                    UnitPrice = new() { Amount = 0, Currency = Contracts::UnitPriceCurrency.Usd },
                    UpTo = 0,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Contracts::PriceOverride
        {
            Amount = 0,
            BaseCharge = true,
            BillingCountryCode = "billingCountryCode",
            BlockSize = 0,
            CreditGrantCadence = Contracts::CreditGrantCadence.BeginningOfBillingPeriod,
            CreditRate = new()
            {
                Amount = 1,
                CurrencyID = "currencyId",
                CostFormula = "costFormula",
            },
            Currency = Contracts::PriceOverrideCurrency.Usd,
            Tiers =
            [
                new()
                {
                    FlatPrice = new() { Amount = 0, Currency = Contracts::FlatPriceCurrency.Usd },
                    UnitPrice = new() { Amount = 0, Currency = Contracts::UnitPriceCurrency.Usd },
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
        var model = new Contracts::PriceOverride
        {
            Amount = 0,
            BaseCharge = true,
            BillingCountryCode = "billingCountryCode",
            BlockSize = 0,
            CreditGrantCadence = Contracts::CreditGrantCadence.BeginningOfBillingPeriod,
            CreditRate = new()
            {
                Amount = 1,
                CurrencyID = "currencyId",
                CostFormula = "costFormula",
            },
            Currency = Contracts::PriceOverrideCurrency.Usd,
            Tiers =
            [
                new()
                {
                    FlatPrice = new() { Amount = 0, Currency = Contracts::FlatPriceCurrency.Usd },
                    UnitPrice = new() { Amount = 0, Currency = Contracts::UnitPriceCurrency.Usd },
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
        var model = new Contracts::PriceOverride
        {
            AddonID = "addonId",
            Amount = 0,
            BaseCharge = true,
            BillingCountryCode = "billingCountryCode",
            BlockSize = 0,
            CreditGrantCadence = Contracts::CreditGrantCadence.BeginningOfBillingPeriod,
            CreditRate = new()
            {
                Amount = 1,
                CurrencyID = "currencyId",
                CostFormula = "costFormula",
            },
            Currency = Contracts::PriceOverrideCurrency.Usd,
            FeatureID = "featureId",
            Tiers =
            [
                new()
                {
                    FlatPrice = new() { Amount = 0, Currency = Contracts::FlatPriceCurrency.Usd },
                    UnitPrice = new() { Amount = 0, Currency = Contracts::UnitPriceCurrency.Usd },
                    UpTo = 0,
                },
            ],
        };

        Contracts::PriceOverride copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CreditGrantCadenceTest : TestBase
{
    [Theory]
    [InlineData(Contracts::CreditGrantCadence.BeginningOfBillingPeriod)]
    [InlineData(Contracts::CreditGrantCadence.Monthly)]
    public void Validation_Works(Contracts::CreditGrantCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Contracts::CreditGrantCadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Contracts::CreditGrantCadence>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Contracts::CreditGrantCadence.BeginningOfBillingPeriod)]
    [InlineData(Contracts::CreditGrantCadence.Monthly)]
    public void SerializationRoundtrip_Works(Contracts::CreditGrantCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Contracts::CreditGrantCadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Contracts::CreditGrantCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Contracts::CreditGrantCadence>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Contracts::CreditGrantCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CreditRateTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Contracts::CreditRate
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
        var model = new Contracts::CreditRate
        {
            Amount = 1,
            CurrencyID = "currencyId",
            CostFormula = "costFormula",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Contracts::CreditRate>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Contracts::CreditRate
        {
            Amount = 1,
            CurrencyID = "currencyId",
            CostFormula = "costFormula",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Contracts::CreditRate>(
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
        var model = new Contracts::CreditRate
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
        var model = new Contracts::CreditRate { Amount = 1, CurrencyID = "currencyId" };

        Assert.Null(model.CostFormula);
        Assert.False(model.RawData.ContainsKey("costFormula"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Contracts::CreditRate { Amount = 1, CurrencyID = "currencyId" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Contracts::CreditRate
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
        var model = new Contracts::CreditRate
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
        var model = new Contracts::CreditRate
        {
            Amount = 1,
            CurrencyID = "currencyId",
            CostFormula = "costFormula",
        };

        Contracts::CreditRate copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PriceOverrideCurrencyTest : TestBase
{
    [Theory]
    [InlineData(Contracts::PriceOverrideCurrency.Usd)]
    [InlineData(Contracts::PriceOverrideCurrency.Aed)]
    [InlineData(Contracts::PriceOverrideCurrency.All)]
    [InlineData(Contracts::PriceOverrideCurrency.Amd)]
    [InlineData(Contracts::PriceOverrideCurrency.Ang)]
    [InlineData(Contracts::PriceOverrideCurrency.Aud)]
    [InlineData(Contracts::PriceOverrideCurrency.Awg)]
    [InlineData(Contracts::PriceOverrideCurrency.Azn)]
    [InlineData(Contracts::PriceOverrideCurrency.Bam)]
    [InlineData(Contracts::PriceOverrideCurrency.Bbd)]
    [InlineData(Contracts::PriceOverrideCurrency.Bdt)]
    [InlineData(Contracts::PriceOverrideCurrency.Bgn)]
    [InlineData(Contracts::PriceOverrideCurrency.Bif)]
    [InlineData(Contracts::PriceOverrideCurrency.Bmd)]
    [InlineData(Contracts::PriceOverrideCurrency.Bnd)]
    [InlineData(Contracts::PriceOverrideCurrency.Bsd)]
    [InlineData(Contracts::PriceOverrideCurrency.Bwp)]
    [InlineData(Contracts::PriceOverrideCurrency.Byn)]
    [InlineData(Contracts::PriceOverrideCurrency.Bzd)]
    [InlineData(Contracts::PriceOverrideCurrency.Brl)]
    [InlineData(Contracts::PriceOverrideCurrency.Cad)]
    [InlineData(Contracts::PriceOverrideCurrency.Cdf)]
    [InlineData(Contracts::PriceOverrideCurrency.Chf)]
    [InlineData(Contracts::PriceOverrideCurrency.Cny)]
    [InlineData(Contracts::PriceOverrideCurrency.Czk)]
    [InlineData(Contracts::PriceOverrideCurrency.Dkk)]
    [InlineData(Contracts::PriceOverrideCurrency.Dop)]
    [InlineData(Contracts::PriceOverrideCurrency.Dzd)]
    [InlineData(Contracts::PriceOverrideCurrency.Egp)]
    [InlineData(Contracts::PriceOverrideCurrency.Etb)]
    [InlineData(Contracts::PriceOverrideCurrency.Eur)]
    [InlineData(Contracts::PriceOverrideCurrency.Fjd)]
    [InlineData(Contracts::PriceOverrideCurrency.Gbp)]
    [InlineData(Contracts::PriceOverrideCurrency.Gel)]
    [InlineData(Contracts::PriceOverrideCurrency.Gip)]
    [InlineData(Contracts::PriceOverrideCurrency.Gmd)]
    [InlineData(Contracts::PriceOverrideCurrency.Gyd)]
    [InlineData(Contracts::PriceOverrideCurrency.Hkd)]
    [InlineData(Contracts::PriceOverrideCurrency.Hrk)]
    [InlineData(Contracts::PriceOverrideCurrency.Htg)]
    [InlineData(Contracts::PriceOverrideCurrency.Idr)]
    [InlineData(Contracts::PriceOverrideCurrency.Ils)]
    [InlineData(Contracts::PriceOverrideCurrency.Inr)]
    [InlineData(Contracts::PriceOverrideCurrency.Isk)]
    [InlineData(Contracts::PriceOverrideCurrency.Jmd)]
    [InlineData(Contracts::PriceOverrideCurrency.Jpy)]
    [InlineData(Contracts::PriceOverrideCurrency.Kes)]
    [InlineData(Contracts::PriceOverrideCurrency.Kgs)]
    [InlineData(Contracts::PriceOverrideCurrency.Khr)]
    [InlineData(Contracts::PriceOverrideCurrency.Kmf)]
    [InlineData(Contracts::PriceOverrideCurrency.Krw)]
    [InlineData(Contracts::PriceOverrideCurrency.Kyd)]
    [InlineData(Contracts::PriceOverrideCurrency.Kzt)]
    [InlineData(Contracts::PriceOverrideCurrency.Lbp)]
    [InlineData(Contracts::PriceOverrideCurrency.Lkr)]
    [InlineData(Contracts::PriceOverrideCurrency.Lrd)]
    [InlineData(Contracts::PriceOverrideCurrency.Lsl)]
    [InlineData(Contracts::PriceOverrideCurrency.Mad)]
    [InlineData(Contracts::PriceOverrideCurrency.Mdl)]
    [InlineData(Contracts::PriceOverrideCurrency.Mga)]
    [InlineData(Contracts::PriceOverrideCurrency.Mkd)]
    [InlineData(Contracts::PriceOverrideCurrency.Mmk)]
    [InlineData(Contracts::PriceOverrideCurrency.Mnt)]
    [InlineData(Contracts::PriceOverrideCurrency.Mop)]
    [InlineData(Contracts::PriceOverrideCurrency.Mro)]
    [InlineData(Contracts::PriceOverrideCurrency.Mvr)]
    [InlineData(Contracts::PriceOverrideCurrency.Mwk)]
    [InlineData(Contracts::PriceOverrideCurrency.Mxn)]
    [InlineData(Contracts::PriceOverrideCurrency.Myr)]
    [InlineData(Contracts::PriceOverrideCurrency.Mzn)]
    [InlineData(Contracts::PriceOverrideCurrency.Nad)]
    [InlineData(Contracts::PriceOverrideCurrency.Ngn)]
    [InlineData(Contracts::PriceOverrideCurrency.Nok)]
    [InlineData(Contracts::PriceOverrideCurrency.Npr)]
    [InlineData(Contracts::PriceOverrideCurrency.Nzd)]
    [InlineData(Contracts::PriceOverrideCurrency.Pgk)]
    [InlineData(Contracts::PriceOverrideCurrency.Php)]
    [InlineData(Contracts::PriceOverrideCurrency.Pkr)]
    [InlineData(Contracts::PriceOverrideCurrency.Pln)]
    [InlineData(Contracts::PriceOverrideCurrency.Qar)]
    [InlineData(Contracts::PriceOverrideCurrency.Ron)]
    [InlineData(Contracts::PriceOverrideCurrency.Rsd)]
    [InlineData(Contracts::PriceOverrideCurrency.Rub)]
    [InlineData(Contracts::PriceOverrideCurrency.Rwf)]
    [InlineData(Contracts::PriceOverrideCurrency.Sar)]
    [InlineData(Contracts::PriceOverrideCurrency.Sbd)]
    [InlineData(Contracts::PriceOverrideCurrency.Scr)]
    [InlineData(Contracts::PriceOverrideCurrency.Sek)]
    [InlineData(Contracts::PriceOverrideCurrency.Sgd)]
    [InlineData(Contracts::PriceOverrideCurrency.Sle)]
    [InlineData(Contracts::PriceOverrideCurrency.Sll)]
    [InlineData(Contracts::PriceOverrideCurrency.Sos)]
    [InlineData(Contracts::PriceOverrideCurrency.Szl)]
    [InlineData(Contracts::PriceOverrideCurrency.Thb)]
    [InlineData(Contracts::PriceOverrideCurrency.Tjs)]
    [InlineData(Contracts::PriceOverrideCurrency.Top)]
    [InlineData(Contracts::PriceOverrideCurrency.Try)]
    [InlineData(Contracts::PriceOverrideCurrency.Ttd)]
    [InlineData(Contracts::PriceOverrideCurrency.Tzs)]
    [InlineData(Contracts::PriceOverrideCurrency.Uah)]
    [InlineData(Contracts::PriceOverrideCurrency.Uzs)]
    [InlineData(Contracts::PriceOverrideCurrency.Vnd)]
    [InlineData(Contracts::PriceOverrideCurrency.Vuv)]
    [InlineData(Contracts::PriceOverrideCurrency.Wst)]
    [InlineData(Contracts::PriceOverrideCurrency.Xaf)]
    [InlineData(Contracts::PriceOverrideCurrency.Xcd)]
    [InlineData(Contracts::PriceOverrideCurrency.Yer)]
    [InlineData(Contracts::PriceOverrideCurrency.Zar)]
    [InlineData(Contracts::PriceOverrideCurrency.Zmw)]
    [InlineData(Contracts::PriceOverrideCurrency.Clp)]
    [InlineData(Contracts::PriceOverrideCurrency.Djf)]
    [InlineData(Contracts::PriceOverrideCurrency.Gnf)]
    [InlineData(Contracts::PriceOverrideCurrency.Ugx)]
    [InlineData(Contracts::PriceOverrideCurrency.Pyg)]
    [InlineData(Contracts::PriceOverrideCurrency.Xof)]
    [InlineData(Contracts::PriceOverrideCurrency.Xpf)]
    public void Validation_Works(Contracts::PriceOverrideCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Contracts::PriceOverrideCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Contracts::PriceOverrideCurrency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Contracts::PriceOverrideCurrency.Usd)]
    [InlineData(Contracts::PriceOverrideCurrency.Aed)]
    [InlineData(Contracts::PriceOverrideCurrency.All)]
    [InlineData(Contracts::PriceOverrideCurrency.Amd)]
    [InlineData(Contracts::PriceOverrideCurrency.Ang)]
    [InlineData(Contracts::PriceOverrideCurrency.Aud)]
    [InlineData(Contracts::PriceOverrideCurrency.Awg)]
    [InlineData(Contracts::PriceOverrideCurrency.Azn)]
    [InlineData(Contracts::PriceOverrideCurrency.Bam)]
    [InlineData(Contracts::PriceOverrideCurrency.Bbd)]
    [InlineData(Contracts::PriceOverrideCurrency.Bdt)]
    [InlineData(Contracts::PriceOverrideCurrency.Bgn)]
    [InlineData(Contracts::PriceOverrideCurrency.Bif)]
    [InlineData(Contracts::PriceOverrideCurrency.Bmd)]
    [InlineData(Contracts::PriceOverrideCurrency.Bnd)]
    [InlineData(Contracts::PriceOverrideCurrency.Bsd)]
    [InlineData(Contracts::PriceOverrideCurrency.Bwp)]
    [InlineData(Contracts::PriceOverrideCurrency.Byn)]
    [InlineData(Contracts::PriceOverrideCurrency.Bzd)]
    [InlineData(Contracts::PriceOverrideCurrency.Brl)]
    [InlineData(Contracts::PriceOverrideCurrency.Cad)]
    [InlineData(Contracts::PriceOverrideCurrency.Cdf)]
    [InlineData(Contracts::PriceOverrideCurrency.Chf)]
    [InlineData(Contracts::PriceOverrideCurrency.Cny)]
    [InlineData(Contracts::PriceOverrideCurrency.Czk)]
    [InlineData(Contracts::PriceOverrideCurrency.Dkk)]
    [InlineData(Contracts::PriceOverrideCurrency.Dop)]
    [InlineData(Contracts::PriceOverrideCurrency.Dzd)]
    [InlineData(Contracts::PriceOverrideCurrency.Egp)]
    [InlineData(Contracts::PriceOverrideCurrency.Etb)]
    [InlineData(Contracts::PriceOverrideCurrency.Eur)]
    [InlineData(Contracts::PriceOverrideCurrency.Fjd)]
    [InlineData(Contracts::PriceOverrideCurrency.Gbp)]
    [InlineData(Contracts::PriceOverrideCurrency.Gel)]
    [InlineData(Contracts::PriceOverrideCurrency.Gip)]
    [InlineData(Contracts::PriceOverrideCurrency.Gmd)]
    [InlineData(Contracts::PriceOverrideCurrency.Gyd)]
    [InlineData(Contracts::PriceOverrideCurrency.Hkd)]
    [InlineData(Contracts::PriceOverrideCurrency.Hrk)]
    [InlineData(Contracts::PriceOverrideCurrency.Htg)]
    [InlineData(Contracts::PriceOverrideCurrency.Idr)]
    [InlineData(Contracts::PriceOverrideCurrency.Ils)]
    [InlineData(Contracts::PriceOverrideCurrency.Inr)]
    [InlineData(Contracts::PriceOverrideCurrency.Isk)]
    [InlineData(Contracts::PriceOverrideCurrency.Jmd)]
    [InlineData(Contracts::PriceOverrideCurrency.Jpy)]
    [InlineData(Contracts::PriceOverrideCurrency.Kes)]
    [InlineData(Contracts::PriceOverrideCurrency.Kgs)]
    [InlineData(Contracts::PriceOverrideCurrency.Khr)]
    [InlineData(Contracts::PriceOverrideCurrency.Kmf)]
    [InlineData(Contracts::PriceOverrideCurrency.Krw)]
    [InlineData(Contracts::PriceOverrideCurrency.Kyd)]
    [InlineData(Contracts::PriceOverrideCurrency.Kzt)]
    [InlineData(Contracts::PriceOverrideCurrency.Lbp)]
    [InlineData(Contracts::PriceOverrideCurrency.Lkr)]
    [InlineData(Contracts::PriceOverrideCurrency.Lrd)]
    [InlineData(Contracts::PriceOverrideCurrency.Lsl)]
    [InlineData(Contracts::PriceOverrideCurrency.Mad)]
    [InlineData(Contracts::PriceOverrideCurrency.Mdl)]
    [InlineData(Contracts::PriceOverrideCurrency.Mga)]
    [InlineData(Contracts::PriceOverrideCurrency.Mkd)]
    [InlineData(Contracts::PriceOverrideCurrency.Mmk)]
    [InlineData(Contracts::PriceOverrideCurrency.Mnt)]
    [InlineData(Contracts::PriceOverrideCurrency.Mop)]
    [InlineData(Contracts::PriceOverrideCurrency.Mro)]
    [InlineData(Contracts::PriceOverrideCurrency.Mvr)]
    [InlineData(Contracts::PriceOverrideCurrency.Mwk)]
    [InlineData(Contracts::PriceOverrideCurrency.Mxn)]
    [InlineData(Contracts::PriceOverrideCurrency.Myr)]
    [InlineData(Contracts::PriceOverrideCurrency.Mzn)]
    [InlineData(Contracts::PriceOverrideCurrency.Nad)]
    [InlineData(Contracts::PriceOverrideCurrency.Ngn)]
    [InlineData(Contracts::PriceOverrideCurrency.Nok)]
    [InlineData(Contracts::PriceOverrideCurrency.Npr)]
    [InlineData(Contracts::PriceOverrideCurrency.Nzd)]
    [InlineData(Contracts::PriceOverrideCurrency.Pgk)]
    [InlineData(Contracts::PriceOverrideCurrency.Php)]
    [InlineData(Contracts::PriceOverrideCurrency.Pkr)]
    [InlineData(Contracts::PriceOverrideCurrency.Pln)]
    [InlineData(Contracts::PriceOverrideCurrency.Qar)]
    [InlineData(Contracts::PriceOverrideCurrency.Ron)]
    [InlineData(Contracts::PriceOverrideCurrency.Rsd)]
    [InlineData(Contracts::PriceOverrideCurrency.Rub)]
    [InlineData(Contracts::PriceOverrideCurrency.Rwf)]
    [InlineData(Contracts::PriceOverrideCurrency.Sar)]
    [InlineData(Contracts::PriceOverrideCurrency.Sbd)]
    [InlineData(Contracts::PriceOverrideCurrency.Scr)]
    [InlineData(Contracts::PriceOverrideCurrency.Sek)]
    [InlineData(Contracts::PriceOverrideCurrency.Sgd)]
    [InlineData(Contracts::PriceOverrideCurrency.Sle)]
    [InlineData(Contracts::PriceOverrideCurrency.Sll)]
    [InlineData(Contracts::PriceOverrideCurrency.Sos)]
    [InlineData(Contracts::PriceOverrideCurrency.Szl)]
    [InlineData(Contracts::PriceOverrideCurrency.Thb)]
    [InlineData(Contracts::PriceOverrideCurrency.Tjs)]
    [InlineData(Contracts::PriceOverrideCurrency.Top)]
    [InlineData(Contracts::PriceOverrideCurrency.Try)]
    [InlineData(Contracts::PriceOverrideCurrency.Ttd)]
    [InlineData(Contracts::PriceOverrideCurrency.Tzs)]
    [InlineData(Contracts::PriceOverrideCurrency.Uah)]
    [InlineData(Contracts::PriceOverrideCurrency.Uzs)]
    [InlineData(Contracts::PriceOverrideCurrency.Vnd)]
    [InlineData(Contracts::PriceOverrideCurrency.Vuv)]
    [InlineData(Contracts::PriceOverrideCurrency.Wst)]
    [InlineData(Contracts::PriceOverrideCurrency.Xaf)]
    [InlineData(Contracts::PriceOverrideCurrency.Xcd)]
    [InlineData(Contracts::PriceOverrideCurrency.Yer)]
    [InlineData(Contracts::PriceOverrideCurrency.Zar)]
    [InlineData(Contracts::PriceOverrideCurrency.Zmw)]
    [InlineData(Contracts::PriceOverrideCurrency.Clp)]
    [InlineData(Contracts::PriceOverrideCurrency.Djf)]
    [InlineData(Contracts::PriceOverrideCurrency.Gnf)]
    [InlineData(Contracts::PriceOverrideCurrency.Ugx)]
    [InlineData(Contracts::PriceOverrideCurrency.Pyg)]
    [InlineData(Contracts::PriceOverrideCurrency.Xof)]
    [InlineData(Contracts::PriceOverrideCurrency.Xpf)]
    public void SerializationRoundtrip_Works(Contracts::PriceOverrideCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Contracts::PriceOverrideCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Contracts::PriceOverrideCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Contracts::PriceOverrideCurrency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Contracts::PriceOverrideCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TierTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Contracts::Tier
        {
            FlatPrice = new() { Amount = 0, Currency = Contracts::FlatPriceCurrency.Usd },
            UnitPrice = new() { Amount = 0, Currency = Contracts::UnitPriceCurrency.Usd },
            UpTo = 0,
        };

        Contracts::FlatPrice expectedFlatPrice = new()
        {
            Amount = 0,
            Currency = Contracts::FlatPriceCurrency.Usd,
        };
        Contracts::UnitPrice expectedUnitPrice = new()
        {
            Amount = 0,
            Currency = Contracts::UnitPriceCurrency.Usd,
        };
        double expectedUpTo = 0;

        Assert.Equal(expectedFlatPrice, model.FlatPrice);
        Assert.Equal(expectedUnitPrice, model.UnitPrice);
        Assert.Equal(expectedUpTo, model.UpTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Contracts::Tier
        {
            FlatPrice = new() { Amount = 0, Currency = Contracts::FlatPriceCurrency.Usd },
            UnitPrice = new() { Amount = 0, Currency = Contracts::UnitPriceCurrency.Usd },
            UpTo = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Contracts::Tier>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Contracts::Tier
        {
            FlatPrice = new() { Amount = 0, Currency = Contracts::FlatPriceCurrency.Usd },
            UnitPrice = new() { Amount = 0, Currency = Contracts::UnitPriceCurrency.Usd },
            UpTo = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Contracts::Tier>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Contracts::FlatPrice expectedFlatPrice = new()
        {
            Amount = 0,
            Currency = Contracts::FlatPriceCurrency.Usd,
        };
        Contracts::UnitPrice expectedUnitPrice = new()
        {
            Amount = 0,
            Currency = Contracts::UnitPriceCurrency.Usd,
        };
        double expectedUpTo = 0;

        Assert.Equal(expectedFlatPrice, deserialized.FlatPrice);
        Assert.Equal(expectedUnitPrice, deserialized.UnitPrice);
        Assert.Equal(expectedUpTo, deserialized.UpTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Contracts::Tier
        {
            FlatPrice = new() { Amount = 0, Currency = Contracts::FlatPriceCurrency.Usd },
            UnitPrice = new() { Amount = 0, Currency = Contracts::UnitPriceCurrency.Usd },
            UpTo = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Contracts::Tier { };

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
        var model = new Contracts::Tier { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Contracts::Tier
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
        var model = new Contracts::Tier
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
        var model = new Contracts::Tier
        {
            FlatPrice = new() { Amount = 0, Currency = Contracts::FlatPriceCurrency.Usd },
            UnitPrice = new() { Amount = 0, Currency = Contracts::UnitPriceCurrency.Usd },
            UpTo = 0,
        };

        Contracts::Tier copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FlatPriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Contracts::FlatPrice
        {
            Amount = 0,
            Currency = Contracts::FlatPriceCurrency.Usd,
        };

        double expectedAmount = 0;
        ApiEnum<string, Contracts::FlatPriceCurrency> expectedCurrency =
            Contracts::FlatPriceCurrency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Contracts::FlatPrice
        {
            Amount = 0,
            Currency = Contracts::FlatPriceCurrency.Usd,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Contracts::FlatPrice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Contracts::FlatPrice
        {
            Amount = 0,
            Currency = Contracts::FlatPriceCurrency.Usd,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Contracts::FlatPrice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        ApiEnum<string, Contracts::FlatPriceCurrency> expectedCurrency =
            Contracts::FlatPriceCurrency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Contracts::FlatPrice
        {
            Amount = 0,
            Currency = Contracts::FlatPriceCurrency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Contracts::FlatPrice
        {
            Amount = 0,
            Currency = Contracts::FlatPriceCurrency.Usd,
        };

        Contracts::FlatPrice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FlatPriceCurrencyTest : TestBase
{
    [Theory]
    [InlineData(Contracts::FlatPriceCurrency.Usd)]
    [InlineData(Contracts::FlatPriceCurrency.Aed)]
    [InlineData(Contracts::FlatPriceCurrency.All)]
    [InlineData(Contracts::FlatPriceCurrency.Amd)]
    [InlineData(Contracts::FlatPriceCurrency.Ang)]
    [InlineData(Contracts::FlatPriceCurrency.Aud)]
    [InlineData(Contracts::FlatPriceCurrency.Awg)]
    [InlineData(Contracts::FlatPriceCurrency.Azn)]
    [InlineData(Contracts::FlatPriceCurrency.Bam)]
    [InlineData(Contracts::FlatPriceCurrency.Bbd)]
    [InlineData(Contracts::FlatPriceCurrency.Bdt)]
    [InlineData(Contracts::FlatPriceCurrency.Bgn)]
    [InlineData(Contracts::FlatPriceCurrency.Bif)]
    [InlineData(Contracts::FlatPriceCurrency.Bmd)]
    [InlineData(Contracts::FlatPriceCurrency.Bnd)]
    [InlineData(Contracts::FlatPriceCurrency.Bsd)]
    [InlineData(Contracts::FlatPriceCurrency.Bwp)]
    [InlineData(Contracts::FlatPriceCurrency.Byn)]
    [InlineData(Contracts::FlatPriceCurrency.Bzd)]
    [InlineData(Contracts::FlatPriceCurrency.Brl)]
    [InlineData(Contracts::FlatPriceCurrency.Cad)]
    [InlineData(Contracts::FlatPriceCurrency.Cdf)]
    [InlineData(Contracts::FlatPriceCurrency.Chf)]
    [InlineData(Contracts::FlatPriceCurrency.Cny)]
    [InlineData(Contracts::FlatPriceCurrency.Czk)]
    [InlineData(Contracts::FlatPriceCurrency.Dkk)]
    [InlineData(Contracts::FlatPriceCurrency.Dop)]
    [InlineData(Contracts::FlatPriceCurrency.Dzd)]
    [InlineData(Contracts::FlatPriceCurrency.Egp)]
    [InlineData(Contracts::FlatPriceCurrency.Etb)]
    [InlineData(Contracts::FlatPriceCurrency.Eur)]
    [InlineData(Contracts::FlatPriceCurrency.Fjd)]
    [InlineData(Contracts::FlatPriceCurrency.Gbp)]
    [InlineData(Contracts::FlatPriceCurrency.Gel)]
    [InlineData(Contracts::FlatPriceCurrency.Gip)]
    [InlineData(Contracts::FlatPriceCurrency.Gmd)]
    [InlineData(Contracts::FlatPriceCurrency.Gyd)]
    [InlineData(Contracts::FlatPriceCurrency.Hkd)]
    [InlineData(Contracts::FlatPriceCurrency.Hrk)]
    [InlineData(Contracts::FlatPriceCurrency.Htg)]
    [InlineData(Contracts::FlatPriceCurrency.Idr)]
    [InlineData(Contracts::FlatPriceCurrency.Ils)]
    [InlineData(Contracts::FlatPriceCurrency.Inr)]
    [InlineData(Contracts::FlatPriceCurrency.Isk)]
    [InlineData(Contracts::FlatPriceCurrency.Jmd)]
    [InlineData(Contracts::FlatPriceCurrency.Jpy)]
    [InlineData(Contracts::FlatPriceCurrency.Kes)]
    [InlineData(Contracts::FlatPriceCurrency.Kgs)]
    [InlineData(Contracts::FlatPriceCurrency.Khr)]
    [InlineData(Contracts::FlatPriceCurrency.Kmf)]
    [InlineData(Contracts::FlatPriceCurrency.Krw)]
    [InlineData(Contracts::FlatPriceCurrency.Kyd)]
    [InlineData(Contracts::FlatPriceCurrency.Kzt)]
    [InlineData(Contracts::FlatPriceCurrency.Lbp)]
    [InlineData(Contracts::FlatPriceCurrency.Lkr)]
    [InlineData(Contracts::FlatPriceCurrency.Lrd)]
    [InlineData(Contracts::FlatPriceCurrency.Lsl)]
    [InlineData(Contracts::FlatPriceCurrency.Mad)]
    [InlineData(Contracts::FlatPriceCurrency.Mdl)]
    [InlineData(Contracts::FlatPriceCurrency.Mga)]
    [InlineData(Contracts::FlatPriceCurrency.Mkd)]
    [InlineData(Contracts::FlatPriceCurrency.Mmk)]
    [InlineData(Contracts::FlatPriceCurrency.Mnt)]
    [InlineData(Contracts::FlatPriceCurrency.Mop)]
    [InlineData(Contracts::FlatPriceCurrency.Mro)]
    [InlineData(Contracts::FlatPriceCurrency.Mvr)]
    [InlineData(Contracts::FlatPriceCurrency.Mwk)]
    [InlineData(Contracts::FlatPriceCurrency.Mxn)]
    [InlineData(Contracts::FlatPriceCurrency.Myr)]
    [InlineData(Contracts::FlatPriceCurrency.Mzn)]
    [InlineData(Contracts::FlatPriceCurrency.Nad)]
    [InlineData(Contracts::FlatPriceCurrency.Ngn)]
    [InlineData(Contracts::FlatPriceCurrency.Nok)]
    [InlineData(Contracts::FlatPriceCurrency.Npr)]
    [InlineData(Contracts::FlatPriceCurrency.Nzd)]
    [InlineData(Contracts::FlatPriceCurrency.Pgk)]
    [InlineData(Contracts::FlatPriceCurrency.Php)]
    [InlineData(Contracts::FlatPriceCurrency.Pkr)]
    [InlineData(Contracts::FlatPriceCurrency.Pln)]
    [InlineData(Contracts::FlatPriceCurrency.Qar)]
    [InlineData(Contracts::FlatPriceCurrency.Ron)]
    [InlineData(Contracts::FlatPriceCurrency.Rsd)]
    [InlineData(Contracts::FlatPriceCurrency.Rub)]
    [InlineData(Contracts::FlatPriceCurrency.Rwf)]
    [InlineData(Contracts::FlatPriceCurrency.Sar)]
    [InlineData(Contracts::FlatPriceCurrency.Sbd)]
    [InlineData(Contracts::FlatPriceCurrency.Scr)]
    [InlineData(Contracts::FlatPriceCurrency.Sek)]
    [InlineData(Contracts::FlatPriceCurrency.Sgd)]
    [InlineData(Contracts::FlatPriceCurrency.Sle)]
    [InlineData(Contracts::FlatPriceCurrency.Sll)]
    [InlineData(Contracts::FlatPriceCurrency.Sos)]
    [InlineData(Contracts::FlatPriceCurrency.Szl)]
    [InlineData(Contracts::FlatPriceCurrency.Thb)]
    [InlineData(Contracts::FlatPriceCurrency.Tjs)]
    [InlineData(Contracts::FlatPriceCurrency.Top)]
    [InlineData(Contracts::FlatPriceCurrency.Try)]
    [InlineData(Contracts::FlatPriceCurrency.Ttd)]
    [InlineData(Contracts::FlatPriceCurrency.Tzs)]
    [InlineData(Contracts::FlatPriceCurrency.Uah)]
    [InlineData(Contracts::FlatPriceCurrency.Uzs)]
    [InlineData(Contracts::FlatPriceCurrency.Vnd)]
    [InlineData(Contracts::FlatPriceCurrency.Vuv)]
    [InlineData(Contracts::FlatPriceCurrency.Wst)]
    [InlineData(Contracts::FlatPriceCurrency.Xaf)]
    [InlineData(Contracts::FlatPriceCurrency.Xcd)]
    [InlineData(Contracts::FlatPriceCurrency.Yer)]
    [InlineData(Contracts::FlatPriceCurrency.Zar)]
    [InlineData(Contracts::FlatPriceCurrency.Zmw)]
    [InlineData(Contracts::FlatPriceCurrency.Clp)]
    [InlineData(Contracts::FlatPriceCurrency.Djf)]
    [InlineData(Contracts::FlatPriceCurrency.Gnf)]
    [InlineData(Contracts::FlatPriceCurrency.Ugx)]
    [InlineData(Contracts::FlatPriceCurrency.Pyg)]
    [InlineData(Contracts::FlatPriceCurrency.Xof)]
    [InlineData(Contracts::FlatPriceCurrency.Xpf)]
    public void Validation_Works(Contracts::FlatPriceCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Contracts::FlatPriceCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Contracts::FlatPriceCurrency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Contracts::FlatPriceCurrency.Usd)]
    [InlineData(Contracts::FlatPriceCurrency.Aed)]
    [InlineData(Contracts::FlatPriceCurrency.All)]
    [InlineData(Contracts::FlatPriceCurrency.Amd)]
    [InlineData(Contracts::FlatPriceCurrency.Ang)]
    [InlineData(Contracts::FlatPriceCurrency.Aud)]
    [InlineData(Contracts::FlatPriceCurrency.Awg)]
    [InlineData(Contracts::FlatPriceCurrency.Azn)]
    [InlineData(Contracts::FlatPriceCurrency.Bam)]
    [InlineData(Contracts::FlatPriceCurrency.Bbd)]
    [InlineData(Contracts::FlatPriceCurrency.Bdt)]
    [InlineData(Contracts::FlatPriceCurrency.Bgn)]
    [InlineData(Contracts::FlatPriceCurrency.Bif)]
    [InlineData(Contracts::FlatPriceCurrency.Bmd)]
    [InlineData(Contracts::FlatPriceCurrency.Bnd)]
    [InlineData(Contracts::FlatPriceCurrency.Bsd)]
    [InlineData(Contracts::FlatPriceCurrency.Bwp)]
    [InlineData(Contracts::FlatPriceCurrency.Byn)]
    [InlineData(Contracts::FlatPriceCurrency.Bzd)]
    [InlineData(Contracts::FlatPriceCurrency.Brl)]
    [InlineData(Contracts::FlatPriceCurrency.Cad)]
    [InlineData(Contracts::FlatPriceCurrency.Cdf)]
    [InlineData(Contracts::FlatPriceCurrency.Chf)]
    [InlineData(Contracts::FlatPriceCurrency.Cny)]
    [InlineData(Contracts::FlatPriceCurrency.Czk)]
    [InlineData(Contracts::FlatPriceCurrency.Dkk)]
    [InlineData(Contracts::FlatPriceCurrency.Dop)]
    [InlineData(Contracts::FlatPriceCurrency.Dzd)]
    [InlineData(Contracts::FlatPriceCurrency.Egp)]
    [InlineData(Contracts::FlatPriceCurrency.Etb)]
    [InlineData(Contracts::FlatPriceCurrency.Eur)]
    [InlineData(Contracts::FlatPriceCurrency.Fjd)]
    [InlineData(Contracts::FlatPriceCurrency.Gbp)]
    [InlineData(Contracts::FlatPriceCurrency.Gel)]
    [InlineData(Contracts::FlatPriceCurrency.Gip)]
    [InlineData(Contracts::FlatPriceCurrency.Gmd)]
    [InlineData(Contracts::FlatPriceCurrency.Gyd)]
    [InlineData(Contracts::FlatPriceCurrency.Hkd)]
    [InlineData(Contracts::FlatPriceCurrency.Hrk)]
    [InlineData(Contracts::FlatPriceCurrency.Htg)]
    [InlineData(Contracts::FlatPriceCurrency.Idr)]
    [InlineData(Contracts::FlatPriceCurrency.Ils)]
    [InlineData(Contracts::FlatPriceCurrency.Inr)]
    [InlineData(Contracts::FlatPriceCurrency.Isk)]
    [InlineData(Contracts::FlatPriceCurrency.Jmd)]
    [InlineData(Contracts::FlatPriceCurrency.Jpy)]
    [InlineData(Contracts::FlatPriceCurrency.Kes)]
    [InlineData(Contracts::FlatPriceCurrency.Kgs)]
    [InlineData(Contracts::FlatPriceCurrency.Khr)]
    [InlineData(Contracts::FlatPriceCurrency.Kmf)]
    [InlineData(Contracts::FlatPriceCurrency.Krw)]
    [InlineData(Contracts::FlatPriceCurrency.Kyd)]
    [InlineData(Contracts::FlatPriceCurrency.Kzt)]
    [InlineData(Contracts::FlatPriceCurrency.Lbp)]
    [InlineData(Contracts::FlatPriceCurrency.Lkr)]
    [InlineData(Contracts::FlatPriceCurrency.Lrd)]
    [InlineData(Contracts::FlatPriceCurrency.Lsl)]
    [InlineData(Contracts::FlatPriceCurrency.Mad)]
    [InlineData(Contracts::FlatPriceCurrency.Mdl)]
    [InlineData(Contracts::FlatPriceCurrency.Mga)]
    [InlineData(Contracts::FlatPriceCurrency.Mkd)]
    [InlineData(Contracts::FlatPriceCurrency.Mmk)]
    [InlineData(Contracts::FlatPriceCurrency.Mnt)]
    [InlineData(Contracts::FlatPriceCurrency.Mop)]
    [InlineData(Contracts::FlatPriceCurrency.Mro)]
    [InlineData(Contracts::FlatPriceCurrency.Mvr)]
    [InlineData(Contracts::FlatPriceCurrency.Mwk)]
    [InlineData(Contracts::FlatPriceCurrency.Mxn)]
    [InlineData(Contracts::FlatPriceCurrency.Myr)]
    [InlineData(Contracts::FlatPriceCurrency.Mzn)]
    [InlineData(Contracts::FlatPriceCurrency.Nad)]
    [InlineData(Contracts::FlatPriceCurrency.Ngn)]
    [InlineData(Contracts::FlatPriceCurrency.Nok)]
    [InlineData(Contracts::FlatPriceCurrency.Npr)]
    [InlineData(Contracts::FlatPriceCurrency.Nzd)]
    [InlineData(Contracts::FlatPriceCurrency.Pgk)]
    [InlineData(Contracts::FlatPriceCurrency.Php)]
    [InlineData(Contracts::FlatPriceCurrency.Pkr)]
    [InlineData(Contracts::FlatPriceCurrency.Pln)]
    [InlineData(Contracts::FlatPriceCurrency.Qar)]
    [InlineData(Contracts::FlatPriceCurrency.Ron)]
    [InlineData(Contracts::FlatPriceCurrency.Rsd)]
    [InlineData(Contracts::FlatPriceCurrency.Rub)]
    [InlineData(Contracts::FlatPriceCurrency.Rwf)]
    [InlineData(Contracts::FlatPriceCurrency.Sar)]
    [InlineData(Contracts::FlatPriceCurrency.Sbd)]
    [InlineData(Contracts::FlatPriceCurrency.Scr)]
    [InlineData(Contracts::FlatPriceCurrency.Sek)]
    [InlineData(Contracts::FlatPriceCurrency.Sgd)]
    [InlineData(Contracts::FlatPriceCurrency.Sle)]
    [InlineData(Contracts::FlatPriceCurrency.Sll)]
    [InlineData(Contracts::FlatPriceCurrency.Sos)]
    [InlineData(Contracts::FlatPriceCurrency.Szl)]
    [InlineData(Contracts::FlatPriceCurrency.Thb)]
    [InlineData(Contracts::FlatPriceCurrency.Tjs)]
    [InlineData(Contracts::FlatPriceCurrency.Top)]
    [InlineData(Contracts::FlatPriceCurrency.Try)]
    [InlineData(Contracts::FlatPriceCurrency.Ttd)]
    [InlineData(Contracts::FlatPriceCurrency.Tzs)]
    [InlineData(Contracts::FlatPriceCurrency.Uah)]
    [InlineData(Contracts::FlatPriceCurrency.Uzs)]
    [InlineData(Contracts::FlatPriceCurrency.Vnd)]
    [InlineData(Contracts::FlatPriceCurrency.Vuv)]
    [InlineData(Contracts::FlatPriceCurrency.Wst)]
    [InlineData(Contracts::FlatPriceCurrency.Xaf)]
    [InlineData(Contracts::FlatPriceCurrency.Xcd)]
    [InlineData(Contracts::FlatPriceCurrency.Yer)]
    [InlineData(Contracts::FlatPriceCurrency.Zar)]
    [InlineData(Contracts::FlatPriceCurrency.Zmw)]
    [InlineData(Contracts::FlatPriceCurrency.Clp)]
    [InlineData(Contracts::FlatPriceCurrency.Djf)]
    [InlineData(Contracts::FlatPriceCurrency.Gnf)]
    [InlineData(Contracts::FlatPriceCurrency.Ugx)]
    [InlineData(Contracts::FlatPriceCurrency.Pyg)]
    [InlineData(Contracts::FlatPriceCurrency.Xof)]
    [InlineData(Contracts::FlatPriceCurrency.Xpf)]
    public void SerializationRoundtrip_Works(Contracts::FlatPriceCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Contracts::FlatPriceCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Contracts::FlatPriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Contracts::FlatPriceCurrency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Contracts::FlatPriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class UnitPriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Contracts::UnitPrice
        {
            Amount = 0,
            Currency = Contracts::UnitPriceCurrency.Usd,
        };

        double expectedAmount = 0;
        ApiEnum<string, Contracts::UnitPriceCurrency> expectedCurrency =
            Contracts::UnitPriceCurrency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Contracts::UnitPrice
        {
            Amount = 0,
            Currency = Contracts::UnitPriceCurrency.Usd,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Contracts::UnitPrice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Contracts::UnitPrice
        {
            Amount = 0,
            Currency = Contracts::UnitPriceCurrency.Usd,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Contracts::UnitPrice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        ApiEnum<string, Contracts::UnitPriceCurrency> expectedCurrency =
            Contracts::UnitPriceCurrency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Contracts::UnitPrice
        {
            Amount = 0,
            Currency = Contracts::UnitPriceCurrency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Contracts::UnitPrice
        {
            Amount = 0,
            Currency = Contracts::UnitPriceCurrency.Usd,
        };

        Contracts::UnitPrice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UnitPriceCurrencyTest : TestBase
{
    [Theory]
    [InlineData(Contracts::UnitPriceCurrency.Usd)]
    [InlineData(Contracts::UnitPriceCurrency.Aed)]
    [InlineData(Contracts::UnitPriceCurrency.All)]
    [InlineData(Contracts::UnitPriceCurrency.Amd)]
    [InlineData(Contracts::UnitPriceCurrency.Ang)]
    [InlineData(Contracts::UnitPriceCurrency.Aud)]
    [InlineData(Contracts::UnitPriceCurrency.Awg)]
    [InlineData(Contracts::UnitPriceCurrency.Azn)]
    [InlineData(Contracts::UnitPriceCurrency.Bam)]
    [InlineData(Contracts::UnitPriceCurrency.Bbd)]
    [InlineData(Contracts::UnitPriceCurrency.Bdt)]
    [InlineData(Contracts::UnitPriceCurrency.Bgn)]
    [InlineData(Contracts::UnitPriceCurrency.Bif)]
    [InlineData(Contracts::UnitPriceCurrency.Bmd)]
    [InlineData(Contracts::UnitPriceCurrency.Bnd)]
    [InlineData(Contracts::UnitPriceCurrency.Bsd)]
    [InlineData(Contracts::UnitPriceCurrency.Bwp)]
    [InlineData(Contracts::UnitPriceCurrency.Byn)]
    [InlineData(Contracts::UnitPriceCurrency.Bzd)]
    [InlineData(Contracts::UnitPriceCurrency.Brl)]
    [InlineData(Contracts::UnitPriceCurrency.Cad)]
    [InlineData(Contracts::UnitPriceCurrency.Cdf)]
    [InlineData(Contracts::UnitPriceCurrency.Chf)]
    [InlineData(Contracts::UnitPriceCurrency.Cny)]
    [InlineData(Contracts::UnitPriceCurrency.Czk)]
    [InlineData(Contracts::UnitPriceCurrency.Dkk)]
    [InlineData(Contracts::UnitPriceCurrency.Dop)]
    [InlineData(Contracts::UnitPriceCurrency.Dzd)]
    [InlineData(Contracts::UnitPriceCurrency.Egp)]
    [InlineData(Contracts::UnitPriceCurrency.Etb)]
    [InlineData(Contracts::UnitPriceCurrency.Eur)]
    [InlineData(Contracts::UnitPriceCurrency.Fjd)]
    [InlineData(Contracts::UnitPriceCurrency.Gbp)]
    [InlineData(Contracts::UnitPriceCurrency.Gel)]
    [InlineData(Contracts::UnitPriceCurrency.Gip)]
    [InlineData(Contracts::UnitPriceCurrency.Gmd)]
    [InlineData(Contracts::UnitPriceCurrency.Gyd)]
    [InlineData(Contracts::UnitPriceCurrency.Hkd)]
    [InlineData(Contracts::UnitPriceCurrency.Hrk)]
    [InlineData(Contracts::UnitPriceCurrency.Htg)]
    [InlineData(Contracts::UnitPriceCurrency.Idr)]
    [InlineData(Contracts::UnitPriceCurrency.Ils)]
    [InlineData(Contracts::UnitPriceCurrency.Inr)]
    [InlineData(Contracts::UnitPriceCurrency.Isk)]
    [InlineData(Contracts::UnitPriceCurrency.Jmd)]
    [InlineData(Contracts::UnitPriceCurrency.Jpy)]
    [InlineData(Contracts::UnitPriceCurrency.Kes)]
    [InlineData(Contracts::UnitPriceCurrency.Kgs)]
    [InlineData(Contracts::UnitPriceCurrency.Khr)]
    [InlineData(Contracts::UnitPriceCurrency.Kmf)]
    [InlineData(Contracts::UnitPriceCurrency.Krw)]
    [InlineData(Contracts::UnitPriceCurrency.Kyd)]
    [InlineData(Contracts::UnitPriceCurrency.Kzt)]
    [InlineData(Contracts::UnitPriceCurrency.Lbp)]
    [InlineData(Contracts::UnitPriceCurrency.Lkr)]
    [InlineData(Contracts::UnitPriceCurrency.Lrd)]
    [InlineData(Contracts::UnitPriceCurrency.Lsl)]
    [InlineData(Contracts::UnitPriceCurrency.Mad)]
    [InlineData(Contracts::UnitPriceCurrency.Mdl)]
    [InlineData(Contracts::UnitPriceCurrency.Mga)]
    [InlineData(Contracts::UnitPriceCurrency.Mkd)]
    [InlineData(Contracts::UnitPriceCurrency.Mmk)]
    [InlineData(Contracts::UnitPriceCurrency.Mnt)]
    [InlineData(Contracts::UnitPriceCurrency.Mop)]
    [InlineData(Contracts::UnitPriceCurrency.Mro)]
    [InlineData(Contracts::UnitPriceCurrency.Mvr)]
    [InlineData(Contracts::UnitPriceCurrency.Mwk)]
    [InlineData(Contracts::UnitPriceCurrency.Mxn)]
    [InlineData(Contracts::UnitPriceCurrency.Myr)]
    [InlineData(Contracts::UnitPriceCurrency.Mzn)]
    [InlineData(Contracts::UnitPriceCurrency.Nad)]
    [InlineData(Contracts::UnitPriceCurrency.Ngn)]
    [InlineData(Contracts::UnitPriceCurrency.Nok)]
    [InlineData(Contracts::UnitPriceCurrency.Npr)]
    [InlineData(Contracts::UnitPriceCurrency.Nzd)]
    [InlineData(Contracts::UnitPriceCurrency.Pgk)]
    [InlineData(Contracts::UnitPriceCurrency.Php)]
    [InlineData(Contracts::UnitPriceCurrency.Pkr)]
    [InlineData(Contracts::UnitPriceCurrency.Pln)]
    [InlineData(Contracts::UnitPriceCurrency.Qar)]
    [InlineData(Contracts::UnitPriceCurrency.Ron)]
    [InlineData(Contracts::UnitPriceCurrency.Rsd)]
    [InlineData(Contracts::UnitPriceCurrency.Rub)]
    [InlineData(Contracts::UnitPriceCurrency.Rwf)]
    [InlineData(Contracts::UnitPriceCurrency.Sar)]
    [InlineData(Contracts::UnitPriceCurrency.Sbd)]
    [InlineData(Contracts::UnitPriceCurrency.Scr)]
    [InlineData(Contracts::UnitPriceCurrency.Sek)]
    [InlineData(Contracts::UnitPriceCurrency.Sgd)]
    [InlineData(Contracts::UnitPriceCurrency.Sle)]
    [InlineData(Contracts::UnitPriceCurrency.Sll)]
    [InlineData(Contracts::UnitPriceCurrency.Sos)]
    [InlineData(Contracts::UnitPriceCurrency.Szl)]
    [InlineData(Contracts::UnitPriceCurrency.Thb)]
    [InlineData(Contracts::UnitPriceCurrency.Tjs)]
    [InlineData(Contracts::UnitPriceCurrency.Top)]
    [InlineData(Contracts::UnitPriceCurrency.Try)]
    [InlineData(Contracts::UnitPriceCurrency.Ttd)]
    [InlineData(Contracts::UnitPriceCurrency.Tzs)]
    [InlineData(Contracts::UnitPriceCurrency.Uah)]
    [InlineData(Contracts::UnitPriceCurrency.Uzs)]
    [InlineData(Contracts::UnitPriceCurrency.Vnd)]
    [InlineData(Contracts::UnitPriceCurrency.Vuv)]
    [InlineData(Contracts::UnitPriceCurrency.Wst)]
    [InlineData(Contracts::UnitPriceCurrency.Xaf)]
    [InlineData(Contracts::UnitPriceCurrency.Xcd)]
    [InlineData(Contracts::UnitPriceCurrency.Yer)]
    [InlineData(Contracts::UnitPriceCurrency.Zar)]
    [InlineData(Contracts::UnitPriceCurrency.Zmw)]
    [InlineData(Contracts::UnitPriceCurrency.Clp)]
    [InlineData(Contracts::UnitPriceCurrency.Djf)]
    [InlineData(Contracts::UnitPriceCurrency.Gnf)]
    [InlineData(Contracts::UnitPriceCurrency.Ugx)]
    [InlineData(Contracts::UnitPriceCurrency.Pyg)]
    [InlineData(Contracts::UnitPriceCurrency.Xof)]
    [InlineData(Contracts::UnitPriceCurrency.Xpf)]
    public void Validation_Works(Contracts::UnitPriceCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Contracts::UnitPriceCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Contracts::UnitPriceCurrency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Contracts::UnitPriceCurrency.Usd)]
    [InlineData(Contracts::UnitPriceCurrency.Aed)]
    [InlineData(Contracts::UnitPriceCurrency.All)]
    [InlineData(Contracts::UnitPriceCurrency.Amd)]
    [InlineData(Contracts::UnitPriceCurrency.Ang)]
    [InlineData(Contracts::UnitPriceCurrency.Aud)]
    [InlineData(Contracts::UnitPriceCurrency.Awg)]
    [InlineData(Contracts::UnitPriceCurrency.Azn)]
    [InlineData(Contracts::UnitPriceCurrency.Bam)]
    [InlineData(Contracts::UnitPriceCurrency.Bbd)]
    [InlineData(Contracts::UnitPriceCurrency.Bdt)]
    [InlineData(Contracts::UnitPriceCurrency.Bgn)]
    [InlineData(Contracts::UnitPriceCurrency.Bif)]
    [InlineData(Contracts::UnitPriceCurrency.Bmd)]
    [InlineData(Contracts::UnitPriceCurrency.Bnd)]
    [InlineData(Contracts::UnitPriceCurrency.Bsd)]
    [InlineData(Contracts::UnitPriceCurrency.Bwp)]
    [InlineData(Contracts::UnitPriceCurrency.Byn)]
    [InlineData(Contracts::UnitPriceCurrency.Bzd)]
    [InlineData(Contracts::UnitPriceCurrency.Brl)]
    [InlineData(Contracts::UnitPriceCurrency.Cad)]
    [InlineData(Contracts::UnitPriceCurrency.Cdf)]
    [InlineData(Contracts::UnitPriceCurrency.Chf)]
    [InlineData(Contracts::UnitPriceCurrency.Cny)]
    [InlineData(Contracts::UnitPriceCurrency.Czk)]
    [InlineData(Contracts::UnitPriceCurrency.Dkk)]
    [InlineData(Contracts::UnitPriceCurrency.Dop)]
    [InlineData(Contracts::UnitPriceCurrency.Dzd)]
    [InlineData(Contracts::UnitPriceCurrency.Egp)]
    [InlineData(Contracts::UnitPriceCurrency.Etb)]
    [InlineData(Contracts::UnitPriceCurrency.Eur)]
    [InlineData(Contracts::UnitPriceCurrency.Fjd)]
    [InlineData(Contracts::UnitPriceCurrency.Gbp)]
    [InlineData(Contracts::UnitPriceCurrency.Gel)]
    [InlineData(Contracts::UnitPriceCurrency.Gip)]
    [InlineData(Contracts::UnitPriceCurrency.Gmd)]
    [InlineData(Contracts::UnitPriceCurrency.Gyd)]
    [InlineData(Contracts::UnitPriceCurrency.Hkd)]
    [InlineData(Contracts::UnitPriceCurrency.Hrk)]
    [InlineData(Contracts::UnitPriceCurrency.Htg)]
    [InlineData(Contracts::UnitPriceCurrency.Idr)]
    [InlineData(Contracts::UnitPriceCurrency.Ils)]
    [InlineData(Contracts::UnitPriceCurrency.Inr)]
    [InlineData(Contracts::UnitPriceCurrency.Isk)]
    [InlineData(Contracts::UnitPriceCurrency.Jmd)]
    [InlineData(Contracts::UnitPriceCurrency.Jpy)]
    [InlineData(Contracts::UnitPriceCurrency.Kes)]
    [InlineData(Contracts::UnitPriceCurrency.Kgs)]
    [InlineData(Contracts::UnitPriceCurrency.Khr)]
    [InlineData(Contracts::UnitPriceCurrency.Kmf)]
    [InlineData(Contracts::UnitPriceCurrency.Krw)]
    [InlineData(Contracts::UnitPriceCurrency.Kyd)]
    [InlineData(Contracts::UnitPriceCurrency.Kzt)]
    [InlineData(Contracts::UnitPriceCurrency.Lbp)]
    [InlineData(Contracts::UnitPriceCurrency.Lkr)]
    [InlineData(Contracts::UnitPriceCurrency.Lrd)]
    [InlineData(Contracts::UnitPriceCurrency.Lsl)]
    [InlineData(Contracts::UnitPriceCurrency.Mad)]
    [InlineData(Contracts::UnitPriceCurrency.Mdl)]
    [InlineData(Contracts::UnitPriceCurrency.Mga)]
    [InlineData(Contracts::UnitPriceCurrency.Mkd)]
    [InlineData(Contracts::UnitPriceCurrency.Mmk)]
    [InlineData(Contracts::UnitPriceCurrency.Mnt)]
    [InlineData(Contracts::UnitPriceCurrency.Mop)]
    [InlineData(Contracts::UnitPriceCurrency.Mro)]
    [InlineData(Contracts::UnitPriceCurrency.Mvr)]
    [InlineData(Contracts::UnitPriceCurrency.Mwk)]
    [InlineData(Contracts::UnitPriceCurrency.Mxn)]
    [InlineData(Contracts::UnitPriceCurrency.Myr)]
    [InlineData(Contracts::UnitPriceCurrency.Mzn)]
    [InlineData(Contracts::UnitPriceCurrency.Nad)]
    [InlineData(Contracts::UnitPriceCurrency.Ngn)]
    [InlineData(Contracts::UnitPriceCurrency.Nok)]
    [InlineData(Contracts::UnitPriceCurrency.Npr)]
    [InlineData(Contracts::UnitPriceCurrency.Nzd)]
    [InlineData(Contracts::UnitPriceCurrency.Pgk)]
    [InlineData(Contracts::UnitPriceCurrency.Php)]
    [InlineData(Contracts::UnitPriceCurrency.Pkr)]
    [InlineData(Contracts::UnitPriceCurrency.Pln)]
    [InlineData(Contracts::UnitPriceCurrency.Qar)]
    [InlineData(Contracts::UnitPriceCurrency.Ron)]
    [InlineData(Contracts::UnitPriceCurrency.Rsd)]
    [InlineData(Contracts::UnitPriceCurrency.Rub)]
    [InlineData(Contracts::UnitPriceCurrency.Rwf)]
    [InlineData(Contracts::UnitPriceCurrency.Sar)]
    [InlineData(Contracts::UnitPriceCurrency.Sbd)]
    [InlineData(Contracts::UnitPriceCurrency.Scr)]
    [InlineData(Contracts::UnitPriceCurrency.Sek)]
    [InlineData(Contracts::UnitPriceCurrency.Sgd)]
    [InlineData(Contracts::UnitPriceCurrency.Sle)]
    [InlineData(Contracts::UnitPriceCurrency.Sll)]
    [InlineData(Contracts::UnitPriceCurrency.Sos)]
    [InlineData(Contracts::UnitPriceCurrency.Szl)]
    [InlineData(Contracts::UnitPriceCurrency.Thb)]
    [InlineData(Contracts::UnitPriceCurrency.Tjs)]
    [InlineData(Contracts::UnitPriceCurrency.Top)]
    [InlineData(Contracts::UnitPriceCurrency.Try)]
    [InlineData(Contracts::UnitPriceCurrency.Ttd)]
    [InlineData(Contracts::UnitPriceCurrency.Tzs)]
    [InlineData(Contracts::UnitPriceCurrency.Uah)]
    [InlineData(Contracts::UnitPriceCurrency.Uzs)]
    [InlineData(Contracts::UnitPriceCurrency.Vnd)]
    [InlineData(Contracts::UnitPriceCurrency.Vuv)]
    [InlineData(Contracts::UnitPriceCurrency.Wst)]
    [InlineData(Contracts::UnitPriceCurrency.Xaf)]
    [InlineData(Contracts::UnitPriceCurrency.Xcd)]
    [InlineData(Contracts::UnitPriceCurrency.Yer)]
    [InlineData(Contracts::UnitPriceCurrency.Zar)]
    [InlineData(Contracts::UnitPriceCurrency.Zmw)]
    [InlineData(Contracts::UnitPriceCurrency.Clp)]
    [InlineData(Contracts::UnitPriceCurrency.Djf)]
    [InlineData(Contracts::UnitPriceCurrency.Gnf)]
    [InlineData(Contracts::UnitPriceCurrency.Ugx)]
    [InlineData(Contracts::UnitPriceCurrency.Pyg)]
    [InlineData(Contracts::UnitPriceCurrency.Xof)]
    [InlineData(Contracts::UnitPriceCurrency.Xpf)]
    public void SerializationRoundtrip_Works(Contracts::UnitPriceCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Contracts::UnitPriceCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Contracts::UnitPriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Contracts::UnitPriceCurrency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Contracts::UnitPriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ScheduleStrategyTest : TestBase
{
    [Theory]
    [InlineData(Contracts::ScheduleStrategy.EndOfBillingPeriod)]
    [InlineData(Contracts::ScheduleStrategy.EndOfBillingMonth)]
    [InlineData(Contracts::ScheduleStrategy.Immediate)]
    public void Validation_Works(Contracts::ScheduleStrategy rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Contracts::ScheduleStrategy> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Contracts::ScheduleStrategy>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Contracts::ScheduleStrategy.EndOfBillingPeriod)]
    [InlineData(Contracts::ScheduleStrategy.EndOfBillingMonth)]
    [InlineData(Contracts::ScheduleStrategy.Immediate)]
    public void SerializationRoundtrip_Works(Contracts::ScheduleStrategy rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Contracts::ScheduleStrategy> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Contracts::ScheduleStrategy>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Contracts::ScheduleStrategy>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Contracts::ScheduleStrategy>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TrialOverrideConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Contracts::TrialOverrideConfiguration
        {
            IsTrial = true,
            TrialEndBehavior = Contracts::TrialEndBehavior.ConvertToPaid,
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        bool expectedIsTrial = true;
        ApiEnum<string, Contracts::TrialEndBehavior> expectedTrialEndBehavior =
            Contracts::TrialEndBehavior.ConvertToPaid;
        DateTimeOffset expectedTrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedIsTrial, model.IsTrial);
        Assert.Equal(expectedTrialEndBehavior, model.TrialEndBehavior);
        Assert.Equal(expectedTrialEndDate, model.TrialEndDate);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Contracts::TrialOverrideConfiguration
        {
            IsTrial = true,
            TrialEndBehavior = Contracts::TrialEndBehavior.ConvertToPaid,
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Contracts::TrialOverrideConfiguration>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Contracts::TrialOverrideConfiguration
        {
            IsTrial = true,
            TrialEndBehavior = Contracts::TrialEndBehavior.ConvertToPaid,
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Contracts::TrialOverrideConfiguration>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedIsTrial = true;
        ApiEnum<string, Contracts::TrialEndBehavior> expectedTrialEndBehavior =
            Contracts::TrialEndBehavior.ConvertToPaid;
        DateTimeOffset expectedTrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedIsTrial, deserialized.IsTrial);
        Assert.Equal(expectedTrialEndBehavior, deserialized.TrialEndBehavior);
        Assert.Equal(expectedTrialEndDate, deserialized.TrialEndDate);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Contracts::TrialOverrideConfiguration
        {
            IsTrial = true,
            TrialEndBehavior = Contracts::TrialEndBehavior.ConvertToPaid,
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Contracts::TrialOverrideConfiguration { IsTrial = true };

        Assert.Null(model.TrialEndBehavior);
        Assert.False(model.RawData.ContainsKey("trialEndBehavior"));
        Assert.Null(model.TrialEndDate);
        Assert.False(model.RawData.ContainsKey("trialEndDate"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Contracts::TrialOverrideConfiguration { IsTrial = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Contracts::TrialOverrideConfiguration
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
        var model = new Contracts::TrialOverrideConfiguration
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
        var model = new Contracts::TrialOverrideConfiguration
        {
            IsTrial = true,
            TrialEndBehavior = Contracts::TrialEndBehavior.ConvertToPaid,
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Contracts::TrialOverrideConfiguration copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TrialEndBehaviorTest : TestBase
{
    [Theory]
    [InlineData(Contracts::TrialEndBehavior.ConvertToPaid)]
    [InlineData(Contracts::TrialEndBehavior.CancelSubscription)]
    public void Validation_Works(Contracts::TrialEndBehavior rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Contracts::TrialEndBehavior> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Contracts::TrialEndBehavior>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Contracts::TrialEndBehavior.ConvertToPaid)]
    [InlineData(Contracts::TrialEndBehavior.CancelSubscription)]
    public void SerializationRoundtrip_Works(Contracts::TrialEndBehavior rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Contracts::TrialEndBehavior> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Contracts::TrialEndBehavior>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Contracts::TrialEndBehavior>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Contracts::TrialEndBehavior>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
