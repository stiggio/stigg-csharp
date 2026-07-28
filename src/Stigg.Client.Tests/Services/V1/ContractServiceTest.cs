using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts = Stigg.Client.Models.V1.Contracts;

namespace Stigg.Client.Tests.Services.V1;

public class ContractServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var contract = await this.client.V1.Contracts.Create(
            new()
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
            },
            TestContext.Current.CancellationToken
        );
        contract.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var contract = await this.client.V1.Contracts.Retrieve(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        contract.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var contract = await this.client.V1.Contracts.Update(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        contract.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.V1.Contracts.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        var contract = await this.client.V1.Contracts.Delete(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        contract.Validate();
    }
}
