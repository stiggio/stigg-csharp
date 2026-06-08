using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Subscriptions = Stigg.Client.Models.V1.Subscriptions;

namespace Stigg.Client.Tests.Models.V1.Subscriptions;

public class SubscriptionUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new Subscriptions::SubscriptionUpdateParams
        {
            ID = "x",
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
                    AmountsOff = [new() { Amount = 0, Currency = Subscriptions::Currency.Usd }],
                    Description = "description",
                    DurationInMonths = 1,
                    Name = "name",
                    PercentOff = 1,
                },
                PromotionCode = "promotionCode",
            },
            AwaitPaymentConfirmation = true,
            BillingCycleAnchor = Subscriptions::BillingCycleAnchor.Unchanged,
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
                CouponID = "couponId",
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
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Charges =
            [
                new()
                {
                    ID = "id",
                    Quantity = 0,
                    Type = Subscriptions::Type.Feature,
                },
            ],
            Entitlements =
            [
                new Subscriptions::Feature()
                {
                    ID = "id",
                    HasSoftLimit = true,
                    HasUnlimitedUsage = true,
                    MonthlyResetPeriodConfiguration = new(
                        Subscriptions::AccordingTo.SubscriptionStart
                    ),
                    ResetPeriod = Subscriptions::ResetPeriod.Year,
                    UsageLimit = 0,
                    WeeklyResetPeriodConfiguration = new(
                        Subscriptions::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    YearlyResetPeriodConfiguration = new(
                        Subscriptions::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MinimumSpend = new() { Amount = 0, Currency = Subscriptions::MinimumSpendCurrency.Usd },
            PriceOverrides =
            [
                new()
                {
                    AddonID = "addonId",
                    Amount = 0,
                    BaseCharge = true,
                    Currency = Subscriptions::PriceOverrideCurrency.Usd,
                    CurrencyID = "currencyId",
                    FeatureID = "featureId",
                },
            ],
            PromotionCode = "promotionCode",
            ScheduleStrategy = Subscriptions::ScheduleStrategy.EndOfBillingPeriod,
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        string expectedID = "x";
        List<Subscriptions::Addon> expectedAddons = [new() { ID = "id", Quantity = 0 }];
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
        ApiEnum<string, Subscriptions::BillingCycleAnchor> expectedBillingCycleAnchor =
            Subscriptions::BillingCycleAnchor.Unchanged;
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
            CouponID = "couponId",
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
        DateTimeOffset expectedCancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<Subscriptions::Charge> expectedCharges =
        [
            new()
            {
                ID = "id",
                Quantity = 0,
                Type = Subscriptions::Type.Feature,
            },
        ];
        List<Subscriptions::Entitlement> expectedEntitlements =
        [
            new Subscriptions::Feature()
            {
                ID = "id",
                HasSoftLimit = true,
                HasUnlimitedUsage = true,
                MonthlyResetPeriodConfiguration = new(Subscriptions::AccordingTo.SubscriptionStart),
                ResetPeriod = Subscriptions::ResetPeriod.Year,
                UsageLimit = 0,
                WeeklyResetPeriodConfiguration = new(
                    Subscriptions::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
                YearlyResetPeriodConfiguration = new(
                    Subscriptions::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
            },
        ];
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        Subscriptions::MinimumSpend expectedMinimumSpend = new()
        {
            Amount = 0,
            Currency = Subscriptions::MinimumSpendCurrency.Usd,
        };
        List<Subscriptions::PriceOverride> expectedPriceOverrides =
        [
            new()
            {
                AddonID = "addonId",
                Amount = 0,
                BaseCharge = true,
                Currency = Subscriptions::PriceOverrideCurrency.Usd,
                CurrencyID = "currencyId",
                FeatureID = "featureId",
            },
        ];
        string expectedPromotionCode = "promotionCode";
        ApiEnum<string, Subscriptions::ScheduleStrategy> expectedScheduleStrategy =
            Subscriptions::ScheduleStrategy.EndOfBillingPeriod;
        DateTimeOffset expectedTrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedXAccountID = "X-ACCOUNT-ID";
        string expectedXEnvironmentID = "X-ENVIRONMENT-ID";

        Assert.Equal(expectedID, parameters.ID);
        Assert.NotNull(parameters.Addons);
        Assert.Equal(expectedAddons.Count, parameters.Addons.Count);
        for (int i = 0; i < expectedAddons.Count; i++)
        {
            Assert.Equal(expectedAddons[i], parameters.Addons[i]);
        }
        Assert.Equal(expectedAppliedCoupon, parameters.AppliedCoupon);
        Assert.Equal(expectedAwaitPaymentConfirmation, parameters.AwaitPaymentConfirmation);
        Assert.Equal(expectedBillingCycleAnchor, parameters.BillingCycleAnchor);
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
        Assert.NotNull(parameters.PriceOverrides);
        Assert.Equal(expectedPriceOverrides.Count, parameters.PriceOverrides.Count);
        for (int i = 0; i < expectedPriceOverrides.Count; i++)
        {
            Assert.Equal(expectedPriceOverrides[i], parameters.PriceOverrides[i]);
        }
        Assert.Equal(expectedPromotionCode, parameters.PromotionCode);
        Assert.Equal(expectedScheduleStrategy, parameters.ScheduleStrategy);
        Assert.Equal(expectedTrialEndDate, parameters.TrialEndDate);
        Assert.Equal(expectedXAccountID, parameters.XAccountID);
        Assert.Equal(expectedXEnvironmentID, parameters.XEnvironmentID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Subscriptions::SubscriptionUpdateParams
        {
            ID = "x",
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MinimumSpend = new() { Amount = 0, Currency = Subscriptions::MinimumSpendCurrency.Usd },
        };

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
        Assert.Null(parameters.Charges);
        Assert.False(parameters.RawBodyData.ContainsKey("charges"));
        Assert.Null(parameters.Entitlements);
        Assert.False(parameters.RawBodyData.ContainsKey("entitlements"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.PriceOverrides);
        Assert.False(parameters.RawBodyData.ContainsKey("priceOverrides"));
        Assert.Null(parameters.PromotionCode);
        Assert.False(parameters.RawBodyData.ContainsKey("promotionCode"));
        Assert.Null(parameters.ScheduleStrategy);
        Assert.False(parameters.RawBodyData.ContainsKey("scheduleStrategy"));
        Assert.Null(parameters.TrialEndDate);
        Assert.False(parameters.RawBodyData.ContainsKey("trialEndDate"));
        Assert.Null(parameters.XAccountID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ACCOUNT-ID"));
        Assert.Null(parameters.XEnvironmentID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ENVIRONMENT-ID"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new Subscriptions::SubscriptionUpdateParams
        {
            ID = "x",
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MinimumSpend = new() { Amount = 0, Currency = Subscriptions::MinimumSpendCurrency.Usd },

            // Null should be interpreted as omitted for these properties
            Addons = null,
            AppliedCoupon = null,
            AwaitPaymentConfirmation = null,
            BillingCycleAnchor = null,
            BillingInformation = null,
            BillingPeriod = null,
            Charges = null,
            Entitlements = null,
            Metadata = null,
            PriceOverrides = null,
            PromotionCode = null,
            ScheduleStrategy = null,
            TrialEndDate = null,
            XAccountID = null,
            XEnvironmentID = null,
        };

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
        Assert.Null(parameters.Charges);
        Assert.False(parameters.RawBodyData.ContainsKey("charges"));
        Assert.Null(parameters.Entitlements);
        Assert.False(parameters.RawBodyData.ContainsKey("entitlements"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.PriceOverrides);
        Assert.False(parameters.RawBodyData.ContainsKey("priceOverrides"));
        Assert.Null(parameters.PromotionCode);
        Assert.False(parameters.RawBodyData.ContainsKey("promotionCode"));
        Assert.Null(parameters.ScheduleStrategy);
        Assert.False(parameters.RawBodyData.ContainsKey("scheduleStrategy"));
        Assert.Null(parameters.TrialEndDate);
        Assert.False(parameters.RawBodyData.ContainsKey("trialEndDate"));
        Assert.Null(parameters.XAccountID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ACCOUNT-ID"));
        Assert.Null(parameters.XEnvironmentID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ENVIRONMENT-ID"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Subscriptions::SubscriptionUpdateParams
        {
            ID = "x",
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
                    AmountsOff = [new() { Amount = 0, Currency = Subscriptions::Currency.Usd }],
                    Description = "description",
                    DurationInMonths = 1,
                    Name = "name",
                    PercentOff = 1,
                },
                PromotionCode = "promotionCode",
            },
            AwaitPaymentConfirmation = true,
            BillingCycleAnchor = Subscriptions::BillingCycleAnchor.Unchanged,
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
                CouponID = "couponId",
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
                    Quantity = 0,
                    Type = Subscriptions::Type.Feature,
                },
            ],
            Entitlements =
            [
                new Subscriptions::Feature()
                {
                    ID = "id",
                    HasSoftLimit = true,
                    HasUnlimitedUsage = true,
                    MonthlyResetPeriodConfiguration = new(
                        Subscriptions::AccordingTo.SubscriptionStart
                    ),
                    ResetPeriod = Subscriptions::ResetPeriod.Year,
                    UsageLimit = 0,
                    WeeklyResetPeriodConfiguration = new(
                        Subscriptions::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    YearlyResetPeriodConfiguration = new(
                        Subscriptions::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PriceOverrides =
            [
                new()
                {
                    AddonID = "addonId",
                    Amount = 0,
                    BaseCharge = true,
                    Currency = Subscriptions::PriceOverrideCurrency.Usd,
                    CurrencyID = "currencyId",
                    FeatureID = "featureId",
                },
            ],
            PromotionCode = "promotionCode",
            ScheduleStrategy = Subscriptions::ScheduleStrategy.EndOfBillingPeriod,
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        Assert.Null(parameters.Budget);
        Assert.False(parameters.RawBodyData.ContainsKey("budget"));
        Assert.Null(parameters.CancellationDate);
        Assert.False(parameters.RawBodyData.ContainsKey("cancellationDate"));
        Assert.Null(parameters.MinimumSpend);
        Assert.False(parameters.RawBodyData.ContainsKey("minimumSpend"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new Subscriptions::SubscriptionUpdateParams
        {
            ID = "x",
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
                    AmountsOff = [new() { Amount = 0, Currency = Subscriptions::Currency.Usd }],
                    Description = "description",
                    DurationInMonths = 1,
                    Name = "name",
                    PercentOff = 1,
                },
                PromotionCode = "promotionCode",
            },
            AwaitPaymentConfirmation = true,
            BillingCycleAnchor = Subscriptions::BillingCycleAnchor.Unchanged,
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
                CouponID = "couponId",
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
                    Quantity = 0,
                    Type = Subscriptions::Type.Feature,
                },
            ],
            Entitlements =
            [
                new Subscriptions::Feature()
                {
                    ID = "id",
                    HasSoftLimit = true,
                    HasUnlimitedUsage = true,
                    MonthlyResetPeriodConfiguration = new(
                        Subscriptions::AccordingTo.SubscriptionStart
                    ),
                    ResetPeriod = Subscriptions::ResetPeriod.Year,
                    UsageLimit = 0,
                    WeeklyResetPeriodConfiguration = new(
                        Subscriptions::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    YearlyResetPeriodConfiguration = new(
                        Subscriptions::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PriceOverrides =
            [
                new()
                {
                    AddonID = "addonId",
                    Amount = 0,
                    BaseCharge = true,
                    Currency = Subscriptions::PriceOverrideCurrency.Usd,
                    CurrencyID = "currencyId",
                    FeatureID = "featureId",
                },
            ],
            PromotionCode = "promotionCode",
            ScheduleStrategy = Subscriptions::ScheduleStrategy.EndOfBillingPeriod,
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",

            Budget = null,
            CancellationDate = null,
            MinimumSpend = null,
        };

        Assert.Null(parameters.Budget);
        Assert.True(parameters.RawBodyData.ContainsKey("budget"));
        Assert.Null(parameters.CancellationDate);
        Assert.True(parameters.RawBodyData.ContainsKey("cancellationDate"));
        Assert.Null(parameters.MinimumSpend);
        Assert.True(parameters.RawBodyData.ContainsKey("minimumSpend"));
    }

    [Fact]
    public void Url_Works()
    {
        Subscriptions::SubscriptionUpdateParams parameters = new() { ID = "x" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.stigg.io/api/v1/subscriptions/x"), url)
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        Subscriptions::SubscriptionUpdateParams parameters = new()
        {
            ID = "x",
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
        var parameters = new Subscriptions::SubscriptionUpdateParams
        {
            ID = "x",
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
                    AmountsOff = [new() { Amount = 0, Currency = Subscriptions::Currency.Usd }],
                    Description = "description",
                    DurationInMonths = 1,
                    Name = "name",
                    PercentOff = 1,
                },
                PromotionCode = "promotionCode",
            },
            AwaitPaymentConfirmation = true,
            BillingCycleAnchor = Subscriptions::BillingCycleAnchor.Unchanged,
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
                CouponID = "couponId",
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
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Charges =
            [
                new()
                {
                    ID = "id",
                    Quantity = 0,
                    Type = Subscriptions::Type.Feature,
                },
            ],
            Entitlements =
            [
                new Subscriptions::Feature()
                {
                    ID = "id",
                    HasSoftLimit = true,
                    HasUnlimitedUsage = true,
                    MonthlyResetPeriodConfiguration = new(
                        Subscriptions::AccordingTo.SubscriptionStart
                    ),
                    ResetPeriod = Subscriptions::ResetPeriod.Year,
                    UsageLimit = 0,
                    WeeklyResetPeriodConfiguration = new(
                        Subscriptions::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    YearlyResetPeriodConfiguration = new(
                        Subscriptions::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MinimumSpend = new() { Amount = 0, Currency = Subscriptions::MinimumSpendCurrency.Usd },
            PriceOverrides =
            [
                new()
                {
                    AddonID = "addonId",
                    Amount = 0,
                    BaseCharge = true,
                    Currency = Subscriptions::PriceOverrideCurrency.Usd,
                    CurrencyID = "currencyId",
                    FeatureID = "featureId",
                },
            ],
            PromotionCode = "promotionCode",
            ScheduleStrategy = Subscriptions::ScheduleStrategy.EndOfBillingPeriod,
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        Subscriptions::SubscriptionUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class AddonTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::Addon { ID = "id", Quantity = 0 };

        string expectedID = "id";
        long expectedQuantity = 0;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedQuantity, model.Quantity);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscriptions::Addon { ID = "id", Quantity = 0 };

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
        var model = new Subscriptions::Addon { ID = "id", Quantity = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Addon>(
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
        var model = new Subscriptions::Addon { ID = "id", Quantity = 0 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Subscriptions::Addon { ID = "id", Quantity = 0 };

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
        var model = new Subscriptions::AppliedCoupon { PromotionCode = "promotionCode" };

        Assert.Null(model.BillingCouponID);
        Assert.False(model.RawData.ContainsKey("billingCouponId"));
        Assert.Null(model.Configuration);
        Assert.False(model.RawData.ContainsKey("configuration"));
        Assert.Null(model.CouponID);
        Assert.False(model.RawData.ContainsKey("couponId"));
        Assert.Null(model.Discount);
        Assert.False(model.RawData.ContainsKey("discount"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Subscriptions::AppliedCoupon { PromotionCode = "promotionCode" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Subscriptions::AppliedCoupon
        {
            PromotionCode = "promotionCode",

            // Null should be interpreted as omitted for these properties
            BillingCouponID = null,
            Configuration = null,
            CouponID = null,
            Discount = null,
        };

        Assert.Null(model.BillingCouponID);
        Assert.False(model.RawData.ContainsKey("billingCouponId"));
        Assert.Null(model.Configuration);
        Assert.False(model.RawData.ContainsKey("configuration"));
        Assert.Null(model.CouponID);
        Assert.False(model.RawData.ContainsKey("couponId"));
        Assert.Null(model.Discount);
        Assert.False(model.RawData.ContainsKey("discount"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Subscriptions::AppliedCoupon
        {
            PromotionCode = "promotionCode",

            // Null should be interpreted as omitted for these properties
            BillingCouponID = null,
            Configuration = null,
            CouponID = null,
            Discount = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
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
        };

        Assert.Null(model.PromotionCode);
        Assert.False(model.RawData.ContainsKey("promotionCode"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
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

            PromotionCode = null,
        };

        Assert.Null(model.PromotionCode);
        Assert.True(model.RawData.ContainsKey("promotionCode"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
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

public class BillingCycleAnchorTest : TestBase
{
    [Theory]
    [InlineData(Subscriptions::BillingCycleAnchor.Unchanged)]
    [InlineData(Subscriptions::BillingCycleAnchor.Now)]
    public void Validation_Works(Subscriptions::BillingCycleAnchor rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::BillingCycleAnchor> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::BillingCycleAnchor>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Subscriptions::BillingCycleAnchor.Unchanged)]
    [InlineData(Subscriptions::BillingCycleAnchor.Now)]
    public void SerializationRoundtrip_Works(Subscriptions::BillingCycleAnchor rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::BillingCycleAnchor> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::BillingCycleAnchor>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::BillingCycleAnchor>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::BillingCycleAnchor>
        >(json, ModelBase.SerializerOptions);

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
            CouponID = "couponId",
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
        string expectedCouponID = "couponId";
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
        Assert.Equal(expectedCouponID, model.CouponID);
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
            CouponID = "couponId",
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
            CouponID = "couponId",
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
        string expectedCouponID = "couponId";
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
        Assert.Equal(expectedCouponID, deserialized.CouponID);
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
            CouponID = "couponId",
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
        var model = new Subscriptions::BillingInformation { };

        Assert.Null(model.BillingAddress);
        Assert.False(model.RawData.ContainsKey("billingAddress"));
        Assert.Null(model.ChargeOnBehalfOfAccount);
        Assert.False(model.RawData.ContainsKey("chargeOnBehalfOfAccount"));
        Assert.Null(model.CouponID);
        Assert.False(model.RawData.ContainsKey("couponId"));
        Assert.Null(model.IntegrationID);
        Assert.False(model.RawData.ContainsKey("integrationId"));
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
        var model = new Subscriptions::BillingInformation { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Subscriptions::BillingInformation
        {
            // Null should be interpreted as omitted for these properties
            BillingAddress = null,
            ChargeOnBehalfOfAccount = null,
            CouponID = null,
            IntegrationID = null,
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
        Assert.Null(model.ChargeOnBehalfOfAccount);
        Assert.False(model.RawData.ContainsKey("chargeOnBehalfOfAccount"));
        Assert.Null(model.CouponID);
        Assert.False(model.RawData.ContainsKey("couponId"));
        Assert.Null(model.IntegrationID);
        Assert.False(model.RawData.ContainsKey("integrationId"));
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
            // Null should be interpreted as omitted for these properties
            BillingAddress = null,
            ChargeOnBehalfOfAccount = null,
            CouponID = null,
            IntegrationID = null,
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
            CouponID = "couponId",
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
            Quantity = 0,
            Type = Subscriptions::Type.Feature,
        };

        string expectedID = "id";
        double expectedQuantity = 0;
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
            Quantity = 0,
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
            Quantity = 0,
            Type = Subscriptions::Type.Feature,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Charge>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        double expectedQuantity = 0;
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
            Quantity = 0,
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
            Quantity = 0,
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

public class EntitlementTest : TestBase
{
    [Fact]
    public void FeatureValidationWorks()
    {
        Subscriptions::Entitlement value = new Subscriptions::Feature()
        {
            ID = "id",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            MonthlyResetPeriodConfiguration = new(Subscriptions::AccordingTo.SubscriptionStart),
            ResetPeriod = Subscriptions::ResetPeriod.Year,
            UsageLimit = 0,
            WeeklyResetPeriodConfiguration = new(
                Subscriptions::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                Subscriptions::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };
        value.Validate();
    }

    [Fact]
    public void CreditValidationWorks()
    {
        Subscriptions::Entitlement value = new Subscriptions::Credit()
        {
            ID = "id",
            Amount = 1,
            Cadence = Subscriptions::Cadence.Month,
        };
        value.Validate();
    }

    [Fact]
    public void FeatureSerializationRoundtripWorks()
    {
        Subscriptions::Entitlement value = new Subscriptions::Feature()
        {
            ID = "id",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            MonthlyResetPeriodConfiguration = new(Subscriptions::AccordingTo.SubscriptionStart),
            ResetPeriod = Subscriptions::ResetPeriod.Year,
            UsageLimit = 0,
            WeeklyResetPeriodConfiguration = new(
                Subscriptions::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                Subscriptions::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Entitlement>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CreditSerializationRoundtripWorks()
    {
        Subscriptions::Entitlement value = new Subscriptions::Credit()
        {
            ID = "id",
            Amount = 1,
            Cadence = Subscriptions::Cadence.Month,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Entitlement>(
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
        var model = new Subscriptions::Feature
        {
            ID = "id",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            MonthlyResetPeriodConfiguration = new(Subscriptions::AccordingTo.SubscriptionStart),
            ResetPeriod = Subscriptions::ResetPeriod.Year,
            UsageLimit = 0,
            WeeklyResetPeriodConfiguration = new(
                Subscriptions::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                Subscriptions::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };

        string expectedID = "id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("FEATURE");
        bool expectedHasSoftLimit = true;
        bool expectedHasUnlimitedUsage = true;
        Subscriptions::MonthlyResetPeriodConfiguration expectedMonthlyResetPeriodConfiguration =
            new(Subscriptions::AccordingTo.SubscriptionStart);
        ApiEnum<string, Subscriptions::ResetPeriod> expectedResetPeriod =
            Subscriptions::ResetPeriod.Year;
        long expectedUsageLimit = 0;
        Subscriptions::WeeklyResetPeriodConfiguration expectedWeeklyResetPeriodConfiguration = new(
            Subscriptions::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
        );
        Subscriptions::YearlyResetPeriodConfiguration expectedYearlyResetPeriodConfiguration = new(
            Subscriptions::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
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
        var model = new Subscriptions::Feature
        {
            ID = "id",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            MonthlyResetPeriodConfiguration = new(Subscriptions::AccordingTo.SubscriptionStart),
            ResetPeriod = Subscriptions::ResetPeriod.Year,
            UsageLimit = 0,
            WeeklyResetPeriodConfiguration = new(
                Subscriptions::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                Subscriptions::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Feature>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::Feature
        {
            ID = "id",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            MonthlyResetPeriodConfiguration = new(Subscriptions::AccordingTo.SubscriptionStart),
            ResetPeriod = Subscriptions::ResetPeriod.Year,
            UsageLimit = 0,
            WeeklyResetPeriodConfiguration = new(
                Subscriptions::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                Subscriptions::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Feature>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("FEATURE");
        bool expectedHasSoftLimit = true;
        bool expectedHasUnlimitedUsage = true;
        Subscriptions::MonthlyResetPeriodConfiguration expectedMonthlyResetPeriodConfiguration =
            new(Subscriptions::AccordingTo.SubscriptionStart);
        ApiEnum<string, Subscriptions::ResetPeriod> expectedResetPeriod =
            Subscriptions::ResetPeriod.Year;
        long expectedUsageLimit = 0;
        Subscriptions::WeeklyResetPeriodConfiguration expectedWeeklyResetPeriodConfiguration = new(
            Subscriptions::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
        );
        Subscriptions::YearlyResetPeriodConfiguration expectedYearlyResetPeriodConfiguration = new(
            Subscriptions::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
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
        var model = new Subscriptions::Feature
        {
            ID = "id",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            MonthlyResetPeriodConfiguration = new(Subscriptions::AccordingTo.SubscriptionStart),
            ResetPeriod = Subscriptions::ResetPeriod.Year,
            UsageLimit = 0,
            WeeklyResetPeriodConfiguration = new(
                Subscriptions::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                Subscriptions::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Subscriptions::Feature
        {
            ID = "id",
            MonthlyResetPeriodConfiguration = new(Subscriptions::AccordingTo.SubscriptionStart),
            WeeklyResetPeriodConfiguration = new(
                Subscriptions::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                Subscriptions::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
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
        var model = new Subscriptions::Feature
        {
            ID = "id",
            MonthlyResetPeriodConfiguration = new(Subscriptions::AccordingTo.SubscriptionStart),
            WeeklyResetPeriodConfiguration = new(
                Subscriptions::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                Subscriptions::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Subscriptions::Feature
        {
            ID = "id",
            MonthlyResetPeriodConfiguration = new(Subscriptions::AccordingTo.SubscriptionStart),
            WeeklyResetPeriodConfiguration = new(
                Subscriptions::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                Subscriptions::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
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
        var model = new Subscriptions::Feature
        {
            ID = "id",
            MonthlyResetPeriodConfiguration = new(Subscriptions::AccordingTo.SubscriptionStart),
            WeeklyResetPeriodConfiguration = new(
                Subscriptions::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                Subscriptions::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
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
        var model = new Subscriptions::Feature
        {
            ID = "id",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            ResetPeriod = Subscriptions::ResetPeriod.Year,
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
        var model = new Subscriptions::Feature
        {
            ID = "id",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            ResetPeriod = Subscriptions::ResetPeriod.Year,
            UsageLimit = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Subscriptions::Feature
        {
            ID = "id",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            ResetPeriod = Subscriptions::ResetPeriod.Year,
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
        var model = new Subscriptions::Feature
        {
            ID = "id",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            ResetPeriod = Subscriptions::ResetPeriod.Year,
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
        var model = new Subscriptions::Feature
        {
            ID = "id",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            MonthlyResetPeriodConfiguration = new(Subscriptions::AccordingTo.SubscriptionStart),
            ResetPeriod = Subscriptions::ResetPeriod.Year,
            UsageLimit = 0,
            WeeklyResetPeriodConfiguration = new(
                Subscriptions::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                Subscriptions::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };

        Subscriptions::Feature copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MonthlyResetPeriodConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::MonthlyResetPeriodConfiguration
        {
            AccordingTo = Subscriptions::AccordingTo.SubscriptionStart,
        };

        ApiEnum<string, Subscriptions::AccordingTo> expectedAccordingTo =
            Subscriptions::AccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, model.AccordingTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscriptions::MonthlyResetPeriodConfiguration
        {
            AccordingTo = Subscriptions::AccordingTo.SubscriptionStart,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::MonthlyResetPeriodConfiguration>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::MonthlyResetPeriodConfiguration
        {
            AccordingTo = Subscriptions::AccordingTo.SubscriptionStart,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::MonthlyResetPeriodConfiguration>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<string, Subscriptions::AccordingTo> expectedAccordingTo =
            Subscriptions::AccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, deserialized.AccordingTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Subscriptions::MonthlyResetPeriodConfiguration
        {
            AccordingTo = Subscriptions::AccordingTo.SubscriptionStart,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Subscriptions::MonthlyResetPeriodConfiguration
        {
            AccordingTo = Subscriptions::AccordingTo.SubscriptionStart,
        };

        Subscriptions::MonthlyResetPeriodConfiguration copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AccordingToTest : TestBase
{
    [Theory]
    [InlineData(Subscriptions::AccordingTo.SubscriptionStart)]
    [InlineData(Subscriptions::AccordingTo.StartOfTheMonth)]
    public void Validation_Works(Subscriptions::AccordingTo rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::AccordingTo> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::AccordingTo>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Subscriptions::AccordingTo.SubscriptionStart)]
    [InlineData(Subscriptions::AccordingTo.StartOfTheMonth)]
    public void SerializationRoundtrip_Works(Subscriptions::AccordingTo rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::AccordingTo> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::AccordingTo>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::AccordingTo>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::AccordingTo>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ResetPeriodTest : TestBase
{
    [Theory]
    [InlineData(Subscriptions::ResetPeriod.Year)]
    [InlineData(Subscriptions::ResetPeriod.Month)]
    [InlineData(Subscriptions::ResetPeriod.Week)]
    [InlineData(Subscriptions::ResetPeriod.Day)]
    [InlineData(Subscriptions::ResetPeriod.Hour)]
    public void Validation_Works(Subscriptions::ResetPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::ResetPeriod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::ResetPeriod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Subscriptions::ResetPeriod.Year)]
    [InlineData(Subscriptions::ResetPeriod.Month)]
    [InlineData(Subscriptions::ResetPeriod.Week)]
    [InlineData(Subscriptions::ResetPeriod.Day)]
    [InlineData(Subscriptions::ResetPeriod.Hour)]
    public void SerializationRoundtrip_Works(Subscriptions::ResetPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::ResetPeriod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::ResetPeriod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::ResetPeriod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::ResetPeriod>>(
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
        var model = new Subscriptions::WeeklyResetPeriodConfiguration
        {
            AccordingTo =
                Subscriptions::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        ApiEnum<
            string,
            Subscriptions::WeeklyResetPeriodConfigurationAccordingTo
        > expectedAccordingTo =
            Subscriptions::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, model.AccordingTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscriptions::WeeklyResetPeriodConfiguration
        {
            AccordingTo =
                Subscriptions::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::WeeklyResetPeriodConfiguration>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::WeeklyResetPeriodConfiguration
        {
            AccordingTo =
                Subscriptions::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::WeeklyResetPeriodConfiguration>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            Subscriptions::WeeklyResetPeriodConfigurationAccordingTo
        > expectedAccordingTo =
            Subscriptions::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, deserialized.AccordingTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Subscriptions::WeeklyResetPeriodConfiguration
        {
            AccordingTo =
                Subscriptions::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Subscriptions::WeeklyResetPeriodConfiguration
        {
            AccordingTo =
                Subscriptions::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        Subscriptions::WeeklyResetPeriodConfiguration copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WeeklyResetPeriodConfigurationAccordingToTest : TestBase
{
    [Theory]
    [InlineData(Subscriptions::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart)]
    [InlineData(Subscriptions::WeeklyResetPeriodConfigurationAccordingTo.EverySunday)]
    [InlineData(Subscriptions::WeeklyResetPeriodConfigurationAccordingTo.EveryMonday)]
    [InlineData(Subscriptions::WeeklyResetPeriodConfigurationAccordingTo.EveryTuesday)]
    [InlineData(Subscriptions::WeeklyResetPeriodConfigurationAccordingTo.EveryWednesday)]
    [InlineData(Subscriptions::WeeklyResetPeriodConfigurationAccordingTo.EveryThursday)]
    [InlineData(Subscriptions::WeeklyResetPeriodConfigurationAccordingTo.EveryFriday)]
    [InlineData(Subscriptions::WeeklyResetPeriodConfigurationAccordingTo.EverySaturday)]
    public void Validation_Works(Subscriptions::WeeklyResetPeriodConfigurationAccordingTo rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::WeeklyResetPeriodConfigurationAccordingTo> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::WeeklyResetPeriodConfigurationAccordingTo>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Subscriptions::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart)]
    [InlineData(Subscriptions::WeeklyResetPeriodConfigurationAccordingTo.EverySunday)]
    [InlineData(Subscriptions::WeeklyResetPeriodConfigurationAccordingTo.EveryMonday)]
    [InlineData(Subscriptions::WeeklyResetPeriodConfigurationAccordingTo.EveryTuesday)]
    [InlineData(Subscriptions::WeeklyResetPeriodConfigurationAccordingTo.EveryWednesday)]
    [InlineData(Subscriptions::WeeklyResetPeriodConfigurationAccordingTo.EveryThursday)]
    [InlineData(Subscriptions::WeeklyResetPeriodConfigurationAccordingTo.EveryFriday)]
    [InlineData(Subscriptions::WeeklyResetPeriodConfigurationAccordingTo.EverySaturday)]
    public void SerializationRoundtrip_Works(
        Subscriptions::WeeklyResetPeriodConfigurationAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::WeeklyResetPeriodConfigurationAccordingTo> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::WeeklyResetPeriodConfigurationAccordingTo>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::WeeklyResetPeriodConfigurationAccordingTo>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::WeeklyResetPeriodConfigurationAccordingTo>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class YearlyResetPeriodConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::YearlyResetPeriodConfiguration
        {
            AccordingTo =
                Subscriptions::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        ApiEnum<
            string,
            Subscriptions::YearlyResetPeriodConfigurationAccordingTo
        > expectedAccordingTo =
            Subscriptions::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, model.AccordingTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscriptions::YearlyResetPeriodConfiguration
        {
            AccordingTo =
                Subscriptions::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::YearlyResetPeriodConfiguration>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::YearlyResetPeriodConfiguration
        {
            AccordingTo =
                Subscriptions::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::YearlyResetPeriodConfiguration>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            Subscriptions::YearlyResetPeriodConfigurationAccordingTo
        > expectedAccordingTo =
            Subscriptions::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, deserialized.AccordingTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Subscriptions::YearlyResetPeriodConfiguration
        {
            AccordingTo =
                Subscriptions::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Subscriptions::YearlyResetPeriodConfiguration
        {
            AccordingTo =
                Subscriptions::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        Subscriptions::YearlyResetPeriodConfiguration copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class YearlyResetPeriodConfigurationAccordingToTest : TestBase
{
    [Theory]
    [InlineData(Subscriptions::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart)]
    public void Validation_Works(Subscriptions::YearlyResetPeriodConfigurationAccordingTo rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::YearlyResetPeriodConfigurationAccordingTo> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::YearlyResetPeriodConfigurationAccordingTo>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Subscriptions::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart)]
    public void SerializationRoundtrip_Works(
        Subscriptions::YearlyResetPeriodConfigurationAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::YearlyResetPeriodConfigurationAccordingTo> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::YearlyResetPeriodConfigurationAccordingTo>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::YearlyResetPeriodConfigurationAccordingTo>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::YearlyResetPeriodConfigurationAccordingTo>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CreditTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::Credit
        {
            ID = "id",
            Amount = 1,
            Cadence = Subscriptions::Cadence.Month,
        };

        string expectedID = "id";
        double expectedAmount = 1;
        ApiEnum<string, Subscriptions::Cadence> expectedCadence = Subscriptions::Cadence.Month;
        JsonElement expectedType = JsonSerializer.SerializeToElement("CREDIT");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCadence, model.Cadence);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscriptions::Credit
        {
            ID = "id",
            Amount = 1,
            Cadence = Subscriptions::Cadence.Month,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Credit>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::Credit
        {
            ID = "id",
            Amount = 1,
            Cadence = Subscriptions::Cadence.Month,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Credit>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        double expectedAmount = 1;
        ApiEnum<string, Subscriptions::Cadence> expectedCadence = Subscriptions::Cadence.Month;
        JsonElement expectedType = JsonSerializer.SerializeToElement("CREDIT");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCadence, deserialized.Cadence);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Subscriptions::Credit
        {
            ID = "id",
            Amount = 1,
            Cadence = Subscriptions::Cadence.Month,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Subscriptions::Credit
        {
            ID = "id",
            Amount = 1,
            Cadence = Subscriptions::Cadence.Month,
        };

        Subscriptions::Credit copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CadenceTest : TestBase
{
    [Theory]
    [InlineData(Subscriptions::Cadence.Month)]
    [InlineData(Subscriptions::Cadence.Year)]
    public void Validation_Works(Subscriptions::Cadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::Cadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::Cadence>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Subscriptions::Cadence.Month)]
    [InlineData(Subscriptions::Cadence.Year)]
    public void SerializationRoundtrip_Works(Subscriptions::Cadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::Cadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::Cadence>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::Cadence>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::Cadence>>(
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
        var model = new Subscriptions::MinimumSpend
        {
            Amount = 0,
            Currency = Subscriptions::MinimumSpendCurrency.Usd,
        };

        double expectedAmount = 0;
        ApiEnum<string, Subscriptions::MinimumSpendCurrency> expectedCurrency =
            Subscriptions::MinimumSpendCurrency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscriptions::MinimumSpend
        {
            Amount = 0,
            Currency = Subscriptions::MinimumSpendCurrency.Usd,
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
            Amount = 0,
            Currency = Subscriptions::MinimumSpendCurrency.Usd,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::MinimumSpend>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        ApiEnum<string, Subscriptions::MinimumSpendCurrency> expectedCurrency =
            Subscriptions::MinimumSpendCurrency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Subscriptions::MinimumSpend
        {
            Amount = 0,
            Currency = Subscriptions::MinimumSpendCurrency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Subscriptions::MinimumSpend { };

        Assert.Null(model.Amount);
        Assert.False(model.RawData.ContainsKey("amount"));
        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Subscriptions::MinimumSpend { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Subscriptions::MinimumSpend
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
        var model = new Subscriptions::MinimumSpend
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
        var model = new Subscriptions::MinimumSpend
        {
            Amount = 0,
            Currency = Subscriptions::MinimumSpendCurrency.Usd,
        };

        Subscriptions::MinimumSpend copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MinimumSpendCurrencyTest : TestBase
{
    [Theory]
    [InlineData(Subscriptions::MinimumSpendCurrency.Usd)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Aed)]
    [InlineData(Subscriptions::MinimumSpendCurrency.All)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Amd)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Ang)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Aud)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Awg)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Azn)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Bam)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Bbd)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Bdt)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Bgn)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Bif)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Bmd)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Bnd)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Bsd)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Bwp)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Byn)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Bzd)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Brl)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Cad)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Cdf)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Chf)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Cny)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Czk)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Dkk)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Dop)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Dzd)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Egp)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Etb)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Eur)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Fjd)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Gbp)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Gel)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Gip)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Gmd)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Gyd)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Hkd)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Hrk)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Htg)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Idr)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Ils)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Inr)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Isk)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Jmd)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Jpy)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Kes)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Kgs)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Khr)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Kmf)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Krw)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Kyd)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Kzt)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Lbp)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Lkr)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Lrd)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Lsl)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Mad)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Mdl)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Mga)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Mkd)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Mmk)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Mnt)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Mop)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Mro)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Mvr)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Mwk)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Mxn)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Myr)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Mzn)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Nad)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Ngn)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Nok)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Npr)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Nzd)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Pgk)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Php)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Pkr)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Pln)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Qar)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Ron)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Rsd)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Rub)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Rwf)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Sar)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Sbd)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Scr)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Sek)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Sgd)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Sle)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Sll)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Sos)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Szl)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Thb)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Tjs)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Top)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Try)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Ttd)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Tzs)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Uah)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Uzs)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Vnd)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Vuv)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Wst)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Xaf)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Xcd)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Yer)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Zar)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Zmw)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Clp)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Djf)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Gnf)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Ugx)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Pyg)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Xof)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Xpf)]
    public void Validation_Works(Subscriptions::MinimumSpendCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::MinimumSpendCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::MinimumSpendCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Subscriptions::MinimumSpendCurrency.Usd)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Aed)]
    [InlineData(Subscriptions::MinimumSpendCurrency.All)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Amd)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Ang)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Aud)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Awg)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Azn)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Bam)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Bbd)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Bdt)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Bgn)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Bif)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Bmd)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Bnd)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Bsd)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Bwp)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Byn)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Bzd)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Brl)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Cad)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Cdf)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Chf)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Cny)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Czk)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Dkk)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Dop)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Dzd)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Egp)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Etb)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Eur)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Fjd)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Gbp)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Gel)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Gip)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Gmd)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Gyd)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Hkd)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Hrk)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Htg)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Idr)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Ils)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Inr)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Isk)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Jmd)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Jpy)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Kes)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Kgs)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Khr)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Kmf)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Krw)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Kyd)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Kzt)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Lbp)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Lkr)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Lrd)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Lsl)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Mad)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Mdl)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Mga)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Mkd)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Mmk)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Mnt)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Mop)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Mro)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Mvr)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Mwk)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Mxn)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Myr)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Mzn)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Nad)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Ngn)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Nok)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Npr)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Nzd)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Pgk)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Php)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Pkr)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Pln)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Qar)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Ron)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Rsd)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Rub)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Rwf)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Sar)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Sbd)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Scr)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Sek)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Sgd)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Sle)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Sll)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Sos)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Szl)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Thb)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Tjs)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Top)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Try)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Ttd)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Tzs)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Uah)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Uzs)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Vnd)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Vuv)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Wst)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Xaf)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Xcd)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Yer)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Zar)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Zmw)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Clp)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Djf)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Gnf)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Ugx)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Pyg)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Xof)]
    [InlineData(Subscriptions::MinimumSpendCurrency.Xpf)]
    public void SerializationRoundtrip_Works(Subscriptions::MinimumSpendCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::MinimumSpendCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::MinimumSpendCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::MinimumSpendCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::MinimumSpendCurrency>
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
            Amount = 0,
            BaseCharge = true,
            Currency = Subscriptions::PriceOverrideCurrency.Usd,
            CurrencyID = "currencyId",
            FeatureID = "featureId",
        };

        string expectedAddonID = "addonId";
        double expectedAmount = 0;
        bool expectedBaseCharge = true;
        ApiEnum<string, Subscriptions::PriceOverrideCurrency> expectedCurrency =
            Subscriptions::PriceOverrideCurrency.Usd;
        string expectedCurrencyID = "currencyId";
        string expectedFeatureID = "featureId";

        Assert.Equal(expectedAddonID, model.AddonID);
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedBaseCharge, model.BaseCharge);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedCurrencyID, model.CurrencyID);
        Assert.Equal(expectedFeatureID, model.FeatureID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscriptions::PriceOverride
        {
            AddonID = "addonId",
            Amount = 0,
            BaseCharge = true,
            Currency = Subscriptions::PriceOverrideCurrency.Usd,
            CurrencyID = "currencyId",
            FeatureID = "featureId",
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
            Amount = 0,
            BaseCharge = true,
            Currency = Subscriptions::PriceOverrideCurrency.Usd,
            CurrencyID = "currencyId",
            FeatureID = "featureId",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::PriceOverride>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAddonID = "addonId";
        double expectedAmount = 0;
        bool expectedBaseCharge = true;
        ApiEnum<string, Subscriptions::PriceOverrideCurrency> expectedCurrency =
            Subscriptions::PriceOverrideCurrency.Usd;
        string expectedCurrencyID = "currencyId";
        string expectedFeatureID = "featureId";

        Assert.Equal(expectedAddonID, deserialized.AddonID);
        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedBaseCharge, deserialized.BaseCharge);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedCurrencyID, deserialized.CurrencyID);
        Assert.Equal(expectedFeatureID, deserialized.FeatureID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Subscriptions::PriceOverride
        {
            AddonID = "addonId",
            Amount = 0,
            BaseCharge = true,
            Currency = Subscriptions::PriceOverrideCurrency.Usd,
            CurrencyID = "currencyId",
            FeatureID = "featureId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Subscriptions::PriceOverride { };

        Assert.Null(model.AddonID);
        Assert.False(model.RawData.ContainsKey("addonId"));
        Assert.Null(model.Amount);
        Assert.False(model.RawData.ContainsKey("amount"));
        Assert.Null(model.BaseCharge);
        Assert.False(model.RawData.ContainsKey("baseCharge"));
        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
        Assert.Null(model.CurrencyID);
        Assert.False(model.RawData.ContainsKey("currencyId"));
        Assert.Null(model.FeatureID);
        Assert.False(model.RawData.ContainsKey("featureId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Subscriptions::PriceOverride { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Subscriptions::PriceOverride
        {
            // Null should be interpreted as omitted for these properties
            AddonID = null,
            Amount = null,
            BaseCharge = null,
            Currency = null,
            CurrencyID = null,
            FeatureID = null,
        };

        Assert.Null(model.AddonID);
        Assert.False(model.RawData.ContainsKey("addonId"));
        Assert.Null(model.Amount);
        Assert.False(model.RawData.ContainsKey("amount"));
        Assert.Null(model.BaseCharge);
        Assert.False(model.RawData.ContainsKey("baseCharge"));
        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
        Assert.Null(model.CurrencyID);
        Assert.False(model.RawData.ContainsKey("currencyId"));
        Assert.Null(model.FeatureID);
        Assert.False(model.RawData.ContainsKey("featureId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Subscriptions::PriceOverride
        {
            // Null should be interpreted as omitted for these properties
            AddonID = null,
            Amount = null,
            BaseCharge = null,
            Currency = null,
            CurrencyID = null,
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
            Amount = 0,
            BaseCharge = true,
            Currency = Subscriptions::PriceOverrideCurrency.Usd,
            CurrencyID = "currencyId",
            FeatureID = "featureId",
        };

        Subscriptions::PriceOverride copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PriceOverrideCurrencyTest : TestBase
{
    [Theory]
    [InlineData(Subscriptions::PriceOverrideCurrency.Usd)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Aed)]
    [InlineData(Subscriptions::PriceOverrideCurrency.All)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Amd)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Ang)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Aud)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Awg)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Azn)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Bam)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Bbd)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Bdt)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Bgn)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Bif)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Bmd)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Bnd)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Bsd)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Bwp)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Byn)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Bzd)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Brl)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Cad)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Cdf)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Chf)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Cny)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Czk)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Dkk)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Dop)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Dzd)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Egp)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Etb)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Eur)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Fjd)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Gbp)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Gel)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Gip)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Gmd)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Gyd)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Hkd)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Hrk)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Htg)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Idr)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Ils)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Inr)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Isk)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Jmd)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Jpy)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Kes)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Kgs)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Khr)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Kmf)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Krw)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Kyd)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Kzt)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Lbp)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Lkr)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Lrd)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Lsl)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Mad)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Mdl)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Mga)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Mkd)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Mmk)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Mnt)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Mop)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Mro)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Mvr)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Mwk)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Mxn)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Myr)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Mzn)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Nad)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Ngn)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Nok)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Npr)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Nzd)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Pgk)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Php)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Pkr)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Pln)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Qar)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Ron)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Rsd)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Rub)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Rwf)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Sar)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Sbd)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Scr)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Sek)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Sgd)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Sle)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Sll)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Sos)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Szl)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Thb)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Tjs)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Top)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Try)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Ttd)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Tzs)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Uah)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Uzs)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Vnd)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Vuv)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Wst)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Xaf)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Xcd)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Yer)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Zar)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Zmw)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Clp)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Djf)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Gnf)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Ugx)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Pyg)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Xof)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Xpf)]
    public void Validation_Works(Subscriptions::PriceOverrideCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::PriceOverrideCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::PriceOverrideCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Subscriptions::PriceOverrideCurrency.Usd)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Aed)]
    [InlineData(Subscriptions::PriceOverrideCurrency.All)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Amd)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Ang)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Aud)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Awg)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Azn)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Bam)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Bbd)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Bdt)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Bgn)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Bif)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Bmd)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Bnd)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Bsd)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Bwp)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Byn)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Bzd)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Brl)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Cad)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Cdf)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Chf)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Cny)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Czk)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Dkk)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Dop)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Dzd)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Egp)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Etb)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Eur)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Fjd)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Gbp)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Gel)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Gip)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Gmd)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Gyd)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Hkd)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Hrk)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Htg)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Idr)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Ils)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Inr)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Isk)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Jmd)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Jpy)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Kes)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Kgs)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Khr)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Kmf)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Krw)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Kyd)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Kzt)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Lbp)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Lkr)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Lrd)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Lsl)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Mad)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Mdl)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Mga)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Mkd)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Mmk)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Mnt)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Mop)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Mro)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Mvr)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Mwk)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Mxn)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Myr)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Mzn)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Nad)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Ngn)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Nok)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Npr)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Nzd)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Pgk)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Php)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Pkr)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Pln)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Qar)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Ron)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Rsd)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Rub)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Rwf)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Sar)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Sbd)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Scr)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Sek)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Sgd)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Sle)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Sll)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Sos)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Szl)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Thb)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Tjs)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Top)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Try)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Ttd)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Tzs)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Uah)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Uzs)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Vnd)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Vuv)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Wst)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Xaf)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Xcd)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Yer)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Zar)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Zmw)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Clp)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Djf)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Gnf)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Ugx)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Pyg)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Xof)]
    [InlineData(Subscriptions::PriceOverrideCurrency.Xpf)]
    public void SerializationRoundtrip_Works(Subscriptions::PriceOverrideCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::PriceOverrideCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::PriceOverrideCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::PriceOverrideCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::PriceOverrideCurrency>
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
