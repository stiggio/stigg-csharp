using System;
using System.Collections.Generic;
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
                Metadata = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
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
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MinimumSpend = new()
            {
                Minimum = new() { Amount = 0, Currency = Subscriptions::MinimumCurrency.Usd },
            },
            PriceOverrides =
            [
                new()
                {
                    AddonID = "addonId",
                    BaseCharge = true,
                    CurrencyID = "currencyId",
                    FeatureID = "featureId",
                    Price = new() { Amount = 0, Currency = Subscriptions::PriceCurrency.Usd },
                },
            ],
            PromotionCode = "promotionCode",
            ScheduleStrategy = Subscriptions::ScheduleStrategy.EndOfBillingPeriod,
            SubscriptionEntitlements =
            [
                new()
                {
                    ID = "id",
                    FeatureID = "featureId",
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
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
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
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        Subscriptions::MinimumSpend expectedMinimumSpend = new()
        {
            Minimum = new() { Amount = 0, Currency = Subscriptions::MinimumCurrency.Usd },
        };
        List<Subscriptions::PriceOverride> expectedPriceOverrides =
        [
            new()
            {
                AddonID = "addonId",
                BaseCharge = true,
                CurrencyID = "currencyId",
                FeatureID = "featureId",
                Price = new() { Amount = 0, Currency = Subscriptions::PriceCurrency.Usd },
            },
        ];
        string expectedPromotionCode = "promotionCode";
        ApiEnum<string, Subscriptions::ScheduleStrategy> expectedScheduleStrategy =
            Subscriptions::ScheduleStrategy.EndOfBillingPeriod;
        List<Subscriptions::SubscriptionEntitlement> expectedSubscriptionEntitlements =
        [
            new()
            {
                ID = "id",
                FeatureID = "featureId",
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
        DateTimeOffset expectedTrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

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
        Assert.NotNull(parameters.Charges);
        Assert.Equal(expectedCharges.Count, parameters.Charges.Count);
        for (int i = 0; i < expectedCharges.Count; i++)
        {
            Assert.Equal(expectedCharges[i], parameters.Charges[i]);
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
        Assert.Equal(expectedTrialEndDate, parameters.TrialEndDate);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Subscriptions::SubscriptionUpdateParams
        {
            ID = "x",
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            MinimumSpend = new()
            {
                Minimum = new() { Amount = 0, Currency = Subscriptions::MinimumCurrency.Usd },
            },
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
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.PriceOverrides);
        Assert.False(parameters.RawBodyData.ContainsKey("priceOverrides"));
        Assert.Null(parameters.PromotionCode);
        Assert.False(parameters.RawBodyData.ContainsKey("promotionCode"));
        Assert.Null(parameters.ScheduleStrategy);
        Assert.False(parameters.RawBodyData.ContainsKey("scheduleStrategy"));
        Assert.Null(parameters.SubscriptionEntitlements);
        Assert.False(parameters.RawBodyData.ContainsKey("subscriptionEntitlements"));
        Assert.Null(parameters.TrialEndDate);
        Assert.False(parameters.RawBodyData.ContainsKey("trialEndDate"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new Subscriptions::SubscriptionUpdateParams
        {
            ID = "x",
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            MinimumSpend = new()
            {
                Minimum = new() { Amount = 0, Currency = Subscriptions::MinimumCurrency.Usd },
            },

            // Null should be interpreted as omitted for these properties
            Addons = null,
            AppliedCoupon = null,
            AwaitPaymentConfirmation = null,
            BillingCycleAnchor = null,
            BillingInformation = null,
            BillingPeriod = null,
            Charges = null,
            Metadata = null,
            PriceOverrides = null,
            PromotionCode = null,
            ScheduleStrategy = null,
            SubscriptionEntitlements = null,
            TrialEndDate = null,
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
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.PriceOverrides);
        Assert.False(parameters.RawBodyData.ContainsKey("priceOverrides"));
        Assert.Null(parameters.PromotionCode);
        Assert.False(parameters.RawBodyData.ContainsKey("promotionCode"));
        Assert.Null(parameters.ScheduleStrategy);
        Assert.False(parameters.RawBodyData.ContainsKey("scheduleStrategy"));
        Assert.Null(parameters.SubscriptionEntitlements);
        Assert.False(parameters.RawBodyData.ContainsKey("subscriptionEntitlements"));
        Assert.Null(parameters.TrialEndDate);
        Assert.False(parameters.RawBodyData.ContainsKey("trialEndDate"));
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
                Metadata = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
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
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PriceOverrides =
            [
                new()
                {
                    AddonID = "addonId",
                    BaseCharge = true,
                    CurrencyID = "currencyId",
                    FeatureID = "featureId",
                    Price = new() { Amount = 0, Currency = Subscriptions::PriceCurrency.Usd },
                },
            ],
            PromotionCode = "promotionCode",
            ScheduleStrategy = Subscriptions::ScheduleStrategy.EndOfBillingPeriod,
            SubscriptionEntitlements =
            [
                new()
                {
                    ID = "id",
                    FeatureID = "featureId",
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
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(parameters.Budget);
        Assert.False(parameters.RawBodyData.ContainsKey("budget"));
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
                Metadata = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
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
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PriceOverrides =
            [
                new()
                {
                    AddonID = "addonId",
                    BaseCharge = true,
                    CurrencyID = "currencyId",
                    FeatureID = "featureId",
                    Price = new() { Amount = 0, Currency = Subscriptions::PriceCurrency.Usd },
                },
            ],
            PromotionCode = "promotionCode",
            ScheduleStrategy = Subscriptions::ScheduleStrategy.EndOfBillingPeriod,
            SubscriptionEntitlements =
            [
                new()
                {
                    ID = "id",
                    FeatureID = "featureId",
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
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            Budget = null,
            MinimumSpend = null,
        };

        Assert.Null(parameters.Budget);
        Assert.True(parameters.RawBodyData.ContainsKey("budget"));
        Assert.Null(parameters.MinimumSpend);
        Assert.True(parameters.RawBodyData.ContainsKey("minimumSpend"));
    }

    [Fact]
    public void Url_Works()
    {
        Subscriptions::SubscriptionUpdateParams parameters = new() { ID = "x" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.stigg.io/api/v1/subscriptions/x"), url);
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
                Metadata = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
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
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MinimumSpend = new()
            {
                Minimum = new() { Amount = 0, Currency = Subscriptions::MinimumCurrency.Usd },
            },
            PriceOverrides =
            [
                new()
                {
                    AddonID = "addonId",
                    BaseCharge = true,
                    CurrencyID = "currencyId",
                    FeatureID = "featureId",
                    Price = new() { Amount = 0, Currency = Subscriptions::PriceCurrency.Usd },
                },
            ],
            PromotionCode = "promotionCode",
            ScheduleStrategy = Subscriptions::ScheduleStrategy.EndOfBillingPeriod,
            SubscriptionEntitlements =
            [
                new()
                {
                    ID = "id",
                    FeatureID = "featureId",
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
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
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
        Dictionary<string, JsonElement> expectedMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
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

            Assert.True(JsonElement.DeepEquals(value, model.Metadata[item.Key]));
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
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
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
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
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
        Dictionary<string, JsonElement> expectedMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
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

            Assert.True(JsonElement.DeepEquals(value, deserialized.Metadata[item.Key]));
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
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
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
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
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

public class MinimumSpendTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::MinimumSpend
        {
            Minimum = new() { Amount = 0, Currency = Subscriptions::MinimumCurrency.Usd },
        };

        Subscriptions::Minimum expectedMinimum = new()
        {
            Amount = 0,
            Currency = Subscriptions::MinimumCurrency.Usd,
        };

        Assert.Equal(expectedMinimum, model.Minimum);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscriptions::MinimumSpend
        {
            Minimum = new() { Amount = 0, Currency = Subscriptions::MinimumCurrency.Usd },
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
            Minimum = new() { Amount = 0, Currency = Subscriptions::MinimumCurrency.Usd },
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
            Currency = Subscriptions::MinimumCurrency.Usd,
        };

        Assert.Equal(expectedMinimum, deserialized.Minimum);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Subscriptions::MinimumSpend
        {
            Minimum = new() { Amount = 0, Currency = Subscriptions::MinimumCurrency.Usd },
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
            Minimum = new() { Amount = 0, Currency = Subscriptions::MinimumCurrency.Usd },
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
            Currency = Subscriptions::MinimumCurrency.Usd,
        };

        double expectedAmount = 0;
        ApiEnum<string, Subscriptions::MinimumCurrency> expectedCurrency =
            Subscriptions::MinimumCurrency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscriptions::Minimum
        {
            Amount = 0,
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
            Currency = Subscriptions::MinimumCurrency.Usd,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Minimum>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        ApiEnum<string, Subscriptions::MinimumCurrency> expectedCurrency =
            Subscriptions::MinimumCurrency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Subscriptions::Minimum
        {
            Amount = 0,
            Currency = Subscriptions::MinimumCurrency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Subscriptions::Minimum { Amount = 0 };

        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Subscriptions::Minimum { Amount = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Subscriptions::Minimum
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
        var model = new Subscriptions::Minimum
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
        var model = new Subscriptions::Minimum
        {
            Amount = 0,
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

public class PriceOverrideTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::PriceOverride
        {
            AddonID = "addonId",
            BaseCharge = true,
            CurrencyID = "currencyId",
            FeatureID = "featureId",
            Price = new() { Amount = 0, Currency = Subscriptions::PriceCurrency.Usd },
        };

        string expectedAddonID = "addonId";
        bool expectedBaseCharge = true;
        string expectedCurrencyID = "currencyId";
        string expectedFeatureID = "featureId";
        Subscriptions::Price expectedPrice = new()
        {
            Amount = 0,
            Currency = Subscriptions::PriceCurrency.Usd,
        };

        Assert.Equal(expectedAddonID, model.AddonID);
        Assert.Equal(expectedBaseCharge, model.BaseCharge);
        Assert.Equal(expectedCurrencyID, model.CurrencyID);
        Assert.Equal(expectedFeatureID, model.FeatureID);
        Assert.Equal(expectedPrice, model.Price);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscriptions::PriceOverride
        {
            AddonID = "addonId",
            BaseCharge = true,
            CurrencyID = "currencyId",
            FeatureID = "featureId",
            Price = new() { Amount = 0, Currency = Subscriptions::PriceCurrency.Usd },
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
            CurrencyID = "currencyId",
            FeatureID = "featureId",
            Price = new() { Amount = 0, Currency = Subscriptions::PriceCurrency.Usd },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::PriceOverride>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAddonID = "addonId";
        bool expectedBaseCharge = true;
        string expectedCurrencyID = "currencyId";
        string expectedFeatureID = "featureId";
        Subscriptions::Price expectedPrice = new()
        {
            Amount = 0,
            Currency = Subscriptions::PriceCurrency.Usd,
        };

        Assert.Equal(expectedAddonID, deserialized.AddonID);
        Assert.Equal(expectedBaseCharge, deserialized.BaseCharge);
        Assert.Equal(expectedCurrencyID, deserialized.CurrencyID);
        Assert.Equal(expectedFeatureID, deserialized.FeatureID);
        Assert.Equal(expectedPrice, deserialized.Price);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Subscriptions::PriceOverride
        {
            AddonID = "addonId",
            BaseCharge = true,
            CurrencyID = "currencyId",
            FeatureID = "featureId",
            Price = new() { Amount = 0, Currency = Subscriptions::PriceCurrency.Usd },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Subscriptions::PriceOverride { };

        Assert.Null(model.AddonID);
        Assert.False(model.RawData.ContainsKey("addonId"));
        Assert.Null(model.BaseCharge);
        Assert.False(model.RawData.ContainsKey("baseCharge"));
        Assert.Null(model.CurrencyID);
        Assert.False(model.RawData.ContainsKey("currencyId"));
        Assert.Null(model.FeatureID);
        Assert.False(model.RawData.ContainsKey("featureId"));
        Assert.Null(model.Price);
        Assert.False(model.RawData.ContainsKey("price"));
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
            BaseCharge = null,
            CurrencyID = null,
            FeatureID = null,
            Price = null,
        };

        Assert.Null(model.AddonID);
        Assert.False(model.RawData.ContainsKey("addonId"));
        Assert.Null(model.BaseCharge);
        Assert.False(model.RawData.ContainsKey("baseCharge"));
        Assert.Null(model.CurrencyID);
        Assert.False(model.RawData.ContainsKey("currencyId"));
        Assert.Null(model.FeatureID);
        Assert.False(model.RawData.ContainsKey("featureId"));
        Assert.Null(model.Price);
        Assert.False(model.RawData.ContainsKey("price"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Subscriptions::PriceOverride
        {
            // Null should be interpreted as omitted for these properties
            AddonID = null,
            BaseCharge = null,
            CurrencyID = null,
            FeatureID = null,
            Price = null,
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
            CurrencyID = "currencyId",
            FeatureID = "featureId",
            Price = new() { Amount = 0, Currency = Subscriptions::PriceCurrency.Usd },
        };

        Subscriptions::PriceOverride copied = new(model);

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
            Currency = Subscriptions::PriceCurrency.Usd,
        };

        double expectedAmount = 0;
        ApiEnum<string, Subscriptions::PriceCurrency> expectedCurrency =
            Subscriptions::PriceCurrency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscriptions::Price
        {
            Amount = 0,
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
            Currency = Subscriptions::PriceCurrency.Usd,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Price>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        ApiEnum<string, Subscriptions::PriceCurrency> expectedCurrency =
            Subscriptions::PriceCurrency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Subscriptions::Price
        {
            Amount = 0,
            Currency = Subscriptions::PriceCurrency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Subscriptions::Price { Amount = 0 };

        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Subscriptions::Price { Amount = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Subscriptions::Price
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
        var model = new Subscriptions::Price
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
        var model = new Subscriptions::Price
        {
            Amount = 0,
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
            ID = "id",
            FeatureID = "featureId",
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
        string expectedFeatureID = "featureId";
        bool expectedHasSoftLimit = true;
        bool expectedHasUnlimitedUsage = true;
        Subscriptions::MonthlyResetPeriodConfiguration expectedMonthlyResetPeriodConfiguration =
            new(Subscriptions::AccordingTo.SubscriptionStart);
        ApiEnum<string, Subscriptions::ResetPeriod> expectedResetPeriod =
            Subscriptions::ResetPeriod.Year;
        double expectedUsageLimit = 0;
        Subscriptions::WeeklyResetPeriodConfiguration expectedWeeklyResetPeriodConfiguration = new(
            Subscriptions::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
        );
        Subscriptions::YearlyResetPeriodConfiguration expectedYearlyResetPeriodConfiguration = new(
            Subscriptions::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
        );

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedFeatureID, model.FeatureID);
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
        var model = new Subscriptions::SubscriptionEntitlement
        {
            ID = "id",
            FeatureID = "featureId",
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
            ID = "id",
            FeatureID = "featureId",
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::SubscriptionEntitlement>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedFeatureID = "featureId";
        bool expectedHasSoftLimit = true;
        bool expectedHasUnlimitedUsage = true;
        Subscriptions::MonthlyResetPeriodConfiguration expectedMonthlyResetPeriodConfiguration =
            new(Subscriptions::AccordingTo.SubscriptionStart);
        ApiEnum<string, Subscriptions::ResetPeriod> expectedResetPeriod =
            Subscriptions::ResetPeriod.Year;
        double expectedUsageLimit = 0;
        Subscriptions::WeeklyResetPeriodConfiguration expectedWeeklyResetPeriodConfiguration = new(
            Subscriptions::WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
        );
        Subscriptions::YearlyResetPeriodConfiguration expectedYearlyResetPeriodConfiguration = new(
            Subscriptions::YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
        );

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedFeatureID, deserialized.FeatureID);
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
        var model = new Subscriptions::SubscriptionEntitlement
        {
            ID = "id",
            FeatureID = "featureId",
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
        var model = new Subscriptions::SubscriptionEntitlement { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.FeatureID);
        Assert.False(model.RawData.ContainsKey("featureId"));
        Assert.Null(model.HasSoftLimit);
        Assert.False(model.RawData.ContainsKey("hasSoftLimit"));
        Assert.Null(model.HasUnlimitedUsage);
        Assert.False(model.RawData.ContainsKey("hasUnlimitedUsage"));
        Assert.Null(model.MonthlyResetPeriodConfiguration);
        Assert.False(model.RawData.ContainsKey("monthlyResetPeriodConfiguration"));
        Assert.Null(model.ResetPeriod);
        Assert.False(model.RawData.ContainsKey("resetPeriod"));
        Assert.Null(model.UsageLimit);
        Assert.False(model.RawData.ContainsKey("usageLimit"));
        Assert.Null(model.WeeklyResetPeriodConfiguration);
        Assert.False(model.RawData.ContainsKey("weeklyResetPeriodConfiguration"));
        Assert.Null(model.YearlyResetPeriodConfiguration);
        Assert.False(model.RawData.ContainsKey("yearlyResetPeriodConfiguration"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Subscriptions::SubscriptionEntitlement { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Subscriptions::SubscriptionEntitlement
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            FeatureID = null,
            HasSoftLimit = null,
            HasUnlimitedUsage = null,
            MonthlyResetPeriodConfiguration = null,
            ResetPeriod = null,
            UsageLimit = null,
            WeeklyResetPeriodConfiguration = null,
            YearlyResetPeriodConfiguration = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.FeatureID);
        Assert.False(model.RawData.ContainsKey("featureId"));
        Assert.Null(model.HasSoftLimit);
        Assert.False(model.RawData.ContainsKey("hasSoftLimit"));
        Assert.Null(model.HasUnlimitedUsage);
        Assert.False(model.RawData.ContainsKey("hasUnlimitedUsage"));
        Assert.Null(model.MonthlyResetPeriodConfiguration);
        Assert.False(model.RawData.ContainsKey("monthlyResetPeriodConfiguration"));
        Assert.Null(model.ResetPeriod);
        Assert.False(model.RawData.ContainsKey("resetPeriod"));
        Assert.Null(model.UsageLimit);
        Assert.False(model.RawData.ContainsKey("usageLimit"));
        Assert.Null(model.WeeklyResetPeriodConfiguration);
        Assert.False(model.RawData.ContainsKey("weeklyResetPeriodConfiguration"));
        Assert.Null(model.YearlyResetPeriodConfiguration);
        Assert.False(model.RawData.ContainsKey("yearlyResetPeriodConfiguration"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Subscriptions::SubscriptionEntitlement
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            FeatureID = null,
            HasSoftLimit = null,
            HasUnlimitedUsage = null,
            MonthlyResetPeriodConfiguration = null,
            ResetPeriod = null,
            UsageLimit = null,
            WeeklyResetPeriodConfiguration = null,
            YearlyResetPeriodConfiguration = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Subscriptions::SubscriptionEntitlement
        {
            ID = "id",
            FeatureID = "featureId",
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

        Subscriptions::SubscriptionEntitlement copied = new(model);

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
