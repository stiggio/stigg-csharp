using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Plans;

namespace Stigg.Client.Tests.Models.V1.Plans;

public class PlanUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PlanUpdateParams
        {
            ID = "x",
            BillingID = "billingId",
            Charges = new()
            {
                PricingType = ChargesPricingType.Free,
                BillingID = "billingId",
                MinimumSpend =
                [
                    new()
                    {
                        BillingPeriod = BillingPeriod.Monthly,
                        Minimum = new() { Amount = 0, Currency = Currency.Usd },
                    },
                ],
                OverageBillingPeriod = OverageBillingPeriod.OnSubscriptionRenewal,
                OveragePricingModels =
                [
                    new()
                    {
                        BillingModel = BillingModel.FlatFee,
                        PricePeriods =
                        [
                            new()
                            {
                                BillingPeriod = PricePeriodBillingPeriod.Monthly,
                                BillingCountryCode = "billingCountryCode",
                                BlockSize = 0,
                                CreditGrantCadence = CreditGrantCadence.BeginningOfBillingPeriod,
                                CreditRate = new()
                                {
                                    Amount = 1,
                                    CurrencyID = "currencyId",
                                    CostFormula = "costFormula",
                                },
                                Price = new() { Amount = 0, Currency = PriceCurrency.Usd },
                                Tiers =
                                [
                                    new()
                                    {
                                        FlatPrice = new()
                                        {
                                            Amount = 0,
                                            Currency = FlatPriceCurrency.Usd,
                                        },
                                        UnitPrice = new()
                                        {
                                            Amount = 0,
                                            Currency = UnitPriceCurrency.Usd,
                                        },
                                        UpTo = 0,
                                    },
                                ],
                            },
                        ],
                        BillingCadence = BillingCadence.Recurring,
                        Entitlement = new()
                        {
                            FeatureID = "featureId",
                            HasSoftLimit = true,
                            HasUnlimitedUsage = true,
                            MonthlyResetPeriodConfiguration = new(AccordingTo.SubscriptionStart),
                            ResetPeriod = ResetPeriod.Year,
                            UsageLimit = 0,
                            WeeklyResetPeriodConfiguration = new(
                                WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                            ),
                            YearlyResetPeriodConfiguration = new(
                                YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                            ),
                        },
                        FeatureID = "featureId",
                        TopUpCustomCurrencyID = "topUpCustomCurrencyId",
                    },
                ],
                PricingModels =
                [
                    new()
                    {
                        BillingModel = PricingModelBillingModel.FlatFee,
                        PricePeriods =
                        [
                            new()
                            {
                                BillingPeriod = PricingModelPricePeriodBillingPeriod.Monthly,
                                BillingCountryCode = "billingCountryCode",
                                BlockSize = 0,
                                CreditGrantCadence =
                                    PricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                                CreditRate = new()
                                {
                                    Amount = 1,
                                    CurrencyID = "currencyId",
                                    CostFormula = "costFormula",
                                },
                                Price = new()
                                {
                                    Amount = 0,
                                    Currency = PricingModelPricePeriodPriceCurrency.Usd,
                                },
                                Tiers =
                                [
                                    new()
                                    {
                                        FlatPrice = new()
                                        {
                                            Amount = 0,
                                            Currency =
                                                PricingModelPricePeriodTierFlatPriceCurrency.Usd,
                                        },
                                        UnitPrice = new()
                                        {
                                            Amount = 0,
                                            Currency =
                                                PricingModelPricePeriodTierUnitPriceCurrency.Usd,
                                        },
                                        UpTo = 0,
                                    },
                                ],
                            },
                        ],
                        BillingCadence = PricingModelBillingCadence.Recurring,
                        FeatureID = "featureId",
                        MaxUnitQuantity = 1,
                        MinUnitQuantity = 1,
                        MonthlyResetPeriodConfiguration = new(
                            PricingModelMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                        ),
                        ResetPeriod = PricingModelResetPeriod.Year,
                        TiersMode = TiersMode.Volume,
                        TopUpCustomCurrencyID = "topUpCustomCurrencyId",
                        WeeklyResetPeriodConfiguration = new(
                            PricingModelWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                        ),
                        YearlyResetPeriodConfiguration = new(
                            PricingModelYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                        ),
                    },
                ],
            },
            CompatibleAddonIds = ["string"],
            DefaultTrialConfig = new()
            {
                Duration = 0,
                Units = PlanUpdateParamsDefaultTrialConfigUnits.Day,
                Budget = new() { HasSoftLimit = true, Limit = 0 },
                TrialEndBehavior = PlanUpdateParamsDefaultTrialConfigTrialEndBehavior.ConvertToPaid,
            },
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ParentPlanID = "parentPlanId",
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        string expectedID = "x";
        string expectedBillingID = "billingId";
        Charges expectedCharges = new()
        {
            PricingType = ChargesPricingType.Free,
            BillingID = "billingId",
            MinimumSpend =
            [
                new()
                {
                    BillingPeriod = BillingPeriod.Monthly,
                    Minimum = new() { Amount = 0, Currency = Currency.Usd },
                },
            ],
            OverageBillingPeriod = OverageBillingPeriod.OnSubscriptionRenewal,
            OveragePricingModels =
            [
                new()
                {
                    BillingModel = BillingModel.FlatFee,
                    PricePeriods =
                    [
                        new()
                        {
                            BillingPeriod = PricePeriodBillingPeriod.Monthly,
                            BillingCountryCode = "billingCountryCode",
                            BlockSize = 0,
                            CreditGrantCadence = CreditGrantCadence.BeginningOfBillingPeriod,
                            CreditRate = new()
                            {
                                Amount = 1,
                                CurrencyID = "currencyId",
                                CostFormula = "costFormula",
                            },
                            Price = new() { Amount = 0, Currency = PriceCurrency.Usd },
                            Tiers =
                            [
                                new()
                                {
                                    FlatPrice = new()
                                    {
                                        Amount = 0,
                                        Currency = FlatPriceCurrency.Usd,
                                    },
                                    UnitPrice = new()
                                    {
                                        Amount = 0,
                                        Currency = UnitPriceCurrency.Usd,
                                    },
                                    UpTo = 0,
                                },
                            ],
                        },
                    ],
                    BillingCadence = BillingCadence.Recurring,
                    Entitlement = new()
                    {
                        FeatureID = "featureId",
                        HasSoftLimit = true,
                        HasUnlimitedUsage = true,
                        MonthlyResetPeriodConfiguration = new(AccordingTo.SubscriptionStart),
                        ResetPeriod = ResetPeriod.Year,
                        UsageLimit = 0,
                        WeeklyResetPeriodConfiguration = new(
                            WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                        ),
                        YearlyResetPeriodConfiguration = new(
                            YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                        ),
                    },
                    FeatureID = "featureId",
                    TopUpCustomCurrencyID = "topUpCustomCurrencyId",
                },
            ],
            PricingModels =
            [
                new()
                {
                    BillingModel = PricingModelBillingModel.FlatFee,
                    PricePeriods =
                    [
                        new()
                        {
                            BillingPeriod = PricingModelPricePeriodBillingPeriod.Monthly,
                            BillingCountryCode = "billingCountryCode",
                            BlockSize = 0,
                            CreditGrantCadence =
                                PricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                            CreditRate = new()
                            {
                                Amount = 1,
                                CurrencyID = "currencyId",
                                CostFormula = "costFormula",
                            },
                            Price = new()
                            {
                                Amount = 0,
                                Currency = PricingModelPricePeriodPriceCurrency.Usd,
                            },
                            Tiers =
                            [
                                new()
                                {
                                    FlatPrice = new()
                                    {
                                        Amount = 0,
                                        Currency = PricingModelPricePeriodTierFlatPriceCurrency.Usd,
                                    },
                                    UnitPrice = new()
                                    {
                                        Amount = 0,
                                        Currency = PricingModelPricePeriodTierUnitPriceCurrency.Usd,
                                    },
                                    UpTo = 0,
                                },
                            ],
                        },
                    ],
                    BillingCadence = PricingModelBillingCadence.Recurring,
                    FeatureID = "featureId",
                    MaxUnitQuantity = 1,
                    MinUnitQuantity = 1,
                    MonthlyResetPeriodConfiguration = new(
                        PricingModelMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    ResetPeriod = PricingModelResetPeriod.Year,
                    TiersMode = TiersMode.Volume,
                    TopUpCustomCurrencyID = "topUpCustomCurrencyId",
                    WeeklyResetPeriodConfiguration = new(
                        PricingModelWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    YearlyResetPeriodConfiguration = new(
                        PricingModelYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                },
            ],
        };
        List<string> expectedCompatibleAddonIds = ["string"];
        PlanUpdateParamsDefaultTrialConfig expectedDefaultTrialConfig = new()
        {
            Duration = 0,
            Units = PlanUpdateParamsDefaultTrialConfigUnits.Day,
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            TrialEndBehavior = PlanUpdateParamsDefaultTrialConfigTrialEndBehavior.ConvertToPaid,
        };
        string expectedDescription = "description";
        string expectedDisplayName = "displayName";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedParentPlanID = "parentPlanId";
        string expectedXAccountID = "X-ACCOUNT-ID";
        string expectedXEnvironmentID = "X-ENVIRONMENT-ID";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedBillingID, parameters.BillingID);
        Assert.Equal(expectedCharges, parameters.Charges);
        Assert.NotNull(parameters.CompatibleAddonIds);
        Assert.Equal(expectedCompatibleAddonIds.Count, parameters.CompatibleAddonIds.Count);
        for (int i = 0; i < expectedCompatibleAddonIds.Count; i++)
        {
            Assert.Equal(expectedCompatibleAddonIds[i], parameters.CompatibleAddonIds[i]);
        }
        Assert.Equal(expectedDefaultTrialConfig, parameters.DefaultTrialConfig);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedDisplayName, parameters.DisplayName);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
        Assert.Equal(expectedParentPlanID, parameters.ParentPlanID);
        Assert.Equal(expectedXAccountID, parameters.XAccountID);
        Assert.Equal(expectedXEnvironmentID, parameters.XEnvironmentID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PlanUpdateParams
        {
            ID = "x",
            BillingID = "billingId",
            CompatibleAddonIds = ["string"],
            DefaultTrialConfig = new()
            {
                Duration = 0,
                Units = PlanUpdateParamsDefaultTrialConfigUnits.Day,
                Budget = new() { HasSoftLimit = true, Limit = 0 },
                TrialEndBehavior = PlanUpdateParamsDefaultTrialConfigTrialEndBehavior.ConvertToPaid,
            },
            Description = "description",
            ParentPlanID = "parentPlanId",
        };

        Assert.Null(parameters.Charges);
        Assert.False(parameters.RawBodyData.ContainsKey("charges"));
        Assert.Null(parameters.DisplayName);
        Assert.False(parameters.RawBodyData.ContainsKey("displayName"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.XAccountID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ACCOUNT-ID"));
        Assert.Null(parameters.XEnvironmentID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ENVIRONMENT-ID"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new PlanUpdateParams
        {
            ID = "x",
            BillingID = "billingId",
            CompatibleAddonIds = ["string"],
            DefaultTrialConfig = new()
            {
                Duration = 0,
                Units = PlanUpdateParamsDefaultTrialConfigUnits.Day,
                Budget = new() { HasSoftLimit = true, Limit = 0 },
                TrialEndBehavior = PlanUpdateParamsDefaultTrialConfigTrialEndBehavior.ConvertToPaid,
            },
            Description = "description",
            ParentPlanID = "parentPlanId",

            // Null should be interpreted as omitted for these properties
            Charges = null,
            DisplayName = null,
            Metadata = null,
            XAccountID = null,
            XEnvironmentID = null,
        };

        Assert.Null(parameters.Charges);
        Assert.False(parameters.RawBodyData.ContainsKey("charges"));
        Assert.Null(parameters.DisplayName);
        Assert.False(parameters.RawBodyData.ContainsKey("displayName"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.XAccountID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ACCOUNT-ID"));
        Assert.Null(parameters.XEnvironmentID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ENVIRONMENT-ID"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PlanUpdateParams
        {
            ID = "x",
            Charges = new()
            {
                PricingType = ChargesPricingType.Free,
                BillingID = "billingId",
                MinimumSpend =
                [
                    new()
                    {
                        BillingPeriod = BillingPeriod.Monthly,
                        Minimum = new() { Amount = 0, Currency = Currency.Usd },
                    },
                ],
                OverageBillingPeriod = OverageBillingPeriod.OnSubscriptionRenewal,
                OveragePricingModels =
                [
                    new()
                    {
                        BillingModel = BillingModel.FlatFee,
                        PricePeriods =
                        [
                            new()
                            {
                                BillingPeriod = PricePeriodBillingPeriod.Monthly,
                                BillingCountryCode = "billingCountryCode",
                                BlockSize = 0,
                                CreditGrantCadence = CreditGrantCadence.BeginningOfBillingPeriod,
                                CreditRate = new()
                                {
                                    Amount = 1,
                                    CurrencyID = "currencyId",
                                    CostFormula = "costFormula",
                                },
                                Price = new() { Amount = 0, Currency = PriceCurrency.Usd },
                                Tiers =
                                [
                                    new()
                                    {
                                        FlatPrice = new()
                                        {
                                            Amount = 0,
                                            Currency = FlatPriceCurrency.Usd,
                                        },
                                        UnitPrice = new()
                                        {
                                            Amount = 0,
                                            Currency = UnitPriceCurrency.Usd,
                                        },
                                        UpTo = 0,
                                    },
                                ],
                            },
                        ],
                        BillingCadence = BillingCadence.Recurring,
                        Entitlement = new()
                        {
                            FeatureID = "featureId",
                            HasSoftLimit = true,
                            HasUnlimitedUsage = true,
                            MonthlyResetPeriodConfiguration = new(AccordingTo.SubscriptionStart),
                            ResetPeriod = ResetPeriod.Year,
                            UsageLimit = 0,
                            WeeklyResetPeriodConfiguration = new(
                                WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                            ),
                            YearlyResetPeriodConfiguration = new(
                                YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                            ),
                        },
                        FeatureID = "featureId",
                        TopUpCustomCurrencyID = "topUpCustomCurrencyId",
                    },
                ],
                PricingModels =
                [
                    new()
                    {
                        BillingModel = PricingModelBillingModel.FlatFee,
                        PricePeriods =
                        [
                            new()
                            {
                                BillingPeriod = PricingModelPricePeriodBillingPeriod.Monthly,
                                BillingCountryCode = "billingCountryCode",
                                BlockSize = 0,
                                CreditGrantCadence =
                                    PricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                                CreditRate = new()
                                {
                                    Amount = 1,
                                    CurrencyID = "currencyId",
                                    CostFormula = "costFormula",
                                },
                                Price = new()
                                {
                                    Amount = 0,
                                    Currency = PricingModelPricePeriodPriceCurrency.Usd,
                                },
                                Tiers =
                                [
                                    new()
                                    {
                                        FlatPrice = new()
                                        {
                                            Amount = 0,
                                            Currency =
                                                PricingModelPricePeriodTierFlatPriceCurrency.Usd,
                                        },
                                        UnitPrice = new()
                                        {
                                            Amount = 0,
                                            Currency =
                                                PricingModelPricePeriodTierUnitPriceCurrency.Usd,
                                        },
                                        UpTo = 0,
                                    },
                                ],
                            },
                        ],
                        BillingCadence = PricingModelBillingCadence.Recurring,
                        FeatureID = "featureId",
                        MaxUnitQuantity = 1,
                        MinUnitQuantity = 1,
                        MonthlyResetPeriodConfiguration = new(
                            PricingModelMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                        ),
                        ResetPeriod = PricingModelResetPeriod.Year,
                        TiersMode = TiersMode.Volume,
                        TopUpCustomCurrencyID = "topUpCustomCurrencyId",
                        WeeklyResetPeriodConfiguration = new(
                            PricingModelWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                        ),
                        YearlyResetPeriodConfiguration = new(
                            PricingModelYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                        ),
                    },
                ],
            },
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        Assert.Null(parameters.BillingID);
        Assert.False(parameters.RawBodyData.ContainsKey("billingId"));
        Assert.Null(parameters.CompatibleAddonIds);
        Assert.False(parameters.RawBodyData.ContainsKey("compatibleAddonIds"));
        Assert.Null(parameters.DefaultTrialConfig);
        Assert.False(parameters.RawBodyData.ContainsKey("defaultTrialConfig"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.ParentPlanID);
        Assert.False(parameters.RawBodyData.ContainsKey("parentPlanId"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new PlanUpdateParams
        {
            ID = "x",
            Charges = new()
            {
                PricingType = ChargesPricingType.Free,
                BillingID = "billingId",
                MinimumSpend =
                [
                    new()
                    {
                        BillingPeriod = BillingPeriod.Monthly,
                        Minimum = new() { Amount = 0, Currency = Currency.Usd },
                    },
                ],
                OverageBillingPeriod = OverageBillingPeriod.OnSubscriptionRenewal,
                OveragePricingModels =
                [
                    new()
                    {
                        BillingModel = BillingModel.FlatFee,
                        PricePeriods =
                        [
                            new()
                            {
                                BillingPeriod = PricePeriodBillingPeriod.Monthly,
                                BillingCountryCode = "billingCountryCode",
                                BlockSize = 0,
                                CreditGrantCadence = CreditGrantCadence.BeginningOfBillingPeriod,
                                CreditRate = new()
                                {
                                    Amount = 1,
                                    CurrencyID = "currencyId",
                                    CostFormula = "costFormula",
                                },
                                Price = new() { Amount = 0, Currency = PriceCurrency.Usd },
                                Tiers =
                                [
                                    new()
                                    {
                                        FlatPrice = new()
                                        {
                                            Amount = 0,
                                            Currency = FlatPriceCurrency.Usd,
                                        },
                                        UnitPrice = new()
                                        {
                                            Amount = 0,
                                            Currency = UnitPriceCurrency.Usd,
                                        },
                                        UpTo = 0,
                                    },
                                ],
                            },
                        ],
                        BillingCadence = BillingCadence.Recurring,
                        Entitlement = new()
                        {
                            FeatureID = "featureId",
                            HasSoftLimit = true,
                            HasUnlimitedUsage = true,
                            MonthlyResetPeriodConfiguration = new(AccordingTo.SubscriptionStart),
                            ResetPeriod = ResetPeriod.Year,
                            UsageLimit = 0,
                            WeeklyResetPeriodConfiguration = new(
                                WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                            ),
                            YearlyResetPeriodConfiguration = new(
                                YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                            ),
                        },
                        FeatureID = "featureId",
                        TopUpCustomCurrencyID = "topUpCustomCurrencyId",
                    },
                ],
                PricingModels =
                [
                    new()
                    {
                        BillingModel = PricingModelBillingModel.FlatFee,
                        PricePeriods =
                        [
                            new()
                            {
                                BillingPeriod = PricingModelPricePeriodBillingPeriod.Monthly,
                                BillingCountryCode = "billingCountryCode",
                                BlockSize = 0,
                                CreditGrantCadence =
                                    PricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                                CreditRate = new()
                                {
                                    Amount = 1,
                                    CurrencyID = "currencyId",
                                    CostFormula = "costFormula",
                                },
                                Price = new()
                                {
                                    Amount = 0,
                                    Currency = PricingModelPricePeriodPriceCurrency.Usd,
                                },
                                Tiers =
                                [
                                    new()
                                    {
                                        FlatPrice = new()
                                        {
                                            Amount = 0,
                                            Currency =
                                                PricingModelPricePeriodTierFlatPriceCurrency.Usd,
                                        },
                                        UnitPrice = new()
                                        {
                                            Amount = 0,
                                            Currency =
                                                PricingModelPricePeriodTierUnitPriceCurrency.Usd,
                                        },
                                        UpTo = 0,
                                    },
                                ],
                            },
                        ],
                        BillingCadence = PricingModelBillingCadence.Recurring,
                        FeatureID = "featureId",
                        MaxUnitQuantity = 1,
                        MinUnitQuantity = 1,
                        MonthlyResetPeriodConfiguration = new(
                            PricingModelMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                        ),
                        ResetPeriod = PricingModelResetPeriod.Year,
                        TiersMode = TiersMode.Volume,
                        TopUpCustomCurrencyID = "topUpCustomCurrencyId",
                        WeeklyResetPeriodConfiguration = new(
                            PricingModelWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                        ),
                        YearlyResetPeriodConfiguration = new(
                            PricingModelYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                        ),
                    },
                ],
            },
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",

            BillingID = null,
            CompatibleAddonIds = null,
            DefaultTrialConfig = null,
            Description = null,
            ParentPlanID = null,
        };

        Assert.Null(parameters.BillingID);
        Assert.True(parameters.RawBodyData.ContainsKey("billingId"));
        Assert.Null(parameters.CompatibleAddonIds);
        Assert.True(parameters.RawBodyData.ContainsKey("compatibleAddonIds"));
        Assert.Null(parameters.DefaultTrialConfig);
        Assert.True(parameters.RawBodyData.ContainsKey("defaultTrialConfig"));
        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.ParentPlanID);
        Assert.True(parameters.RawBodyData.ContainsKey("parentPlanId"));
    }

    [Fact]
    public void Url_Works()
    {
        PlanUpdateParams parameters = new() { ID = "x" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.stigg.io/api/v1/plans/x"), url));
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        PlanUpdateParams parameters = new()
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
        var parameters = new PlanUpdateParams
        {
            ID = "x",
            BillingID = "billingId",
            Charges = new()
            {
                PricingType = ChargesPricingType.Free,
                BillingID = "billingId",
                MinimumSpend =
                [
                    new()
                    {
                        BillingPeriod = BillingPeriod.Monthly,
                        Minimum = new() { Amount = 0, Currency = Currency.Usd },
                    },
                ],
                OverageBillingPeriod = OverageBillingPeriod.OnSubscriptionRenewal,
                OveragePricingModels =
                [
                    new()
                    {
                        BillingModel = BillingModel.FlatFee,
                        PricePeriods =
                        [
                            new()
                            {
                                BillingPeriod = PricePeriodBillingPeriod.Monthly,
                                BillingCountryCode = "billingCountryCode",
                                BlockSize = 0,
                                CreditGrantCadence = CreditGrantCadence.BeginningOfBillingPeriod,
                                CreditRate = new()
                                {
                                    Amount = 1,
                                    CurrencyID = "currencyId",
                                    CostFormula = "costFormula",
                                },
                                Price = new() { Amount = 0, Currency = PriceCurrency.Usd },
                                Tiers =
                                [
                                    new()
                                    {
                                        FlatPrice = new()
                                        {
                                            Amount = 0,
                                            Currency = FlatPriceCurrency.Usd,
                                        },
                                        UnitPrice = new()
                                        {
                                            Amount = 0,
                                            Currency = UnitPriceCurrency.Usd,
                                        },
                                        UpTo = 0,
                                    },
                                ],
                            },
                        ],
                        BillingCadence = BillingCadence.Recurring,
                        Entitlement = new()
                        {
                            FeatureID = "featureId",
                            HasSoftLimit = true,
                            HasUnlimitedUsage = true,
                            MonthlyResetPeriodConfiguration = new(AccordingTo.SubscriptionStart),
                            ResetPeriod = ResetPeriod.Year,
                            UsageLimit = 0,
                            WeeklyResetPeriodConfiguration = new(
                                WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                            ),
                            YearlyResetPeriodConfiguration = new(
                                YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                            ),
                        },
                        FeatureID = "featureId",
                        TopUpCustomCurrencyID = "topUpCustomCurrencyId",
                    },
                ],
                PricingModels =
                [
                    new()
                    {
                        BillingModel = PricingModelBillingModel.FlatFee,
                        PricePeriods =
                        [
                            new()
                            {
                                BillingPeriod = PricingModelPricePeriodBillingPeriod.Monthly,
                                BillingCountryCode = "billingCountryCode",
                                BlockSize = 0,
                                CreditGrantCadence =
                                    PricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                                CreditRate = new()
                                {
                                    Amount = 1,
                                    CurrencyID = "currencyId",
                                    CostFormula = "costFormula",
                                },
                                Price = new()
                                {
                                    Amount = 0,
                                    Currency = PricingModelPricePeriodPriceCurrency.Usd,
                                },
                                Tiers =
                                [
                                    new()
                                    {
                                        FlatPrice = new()
                                        {
                                            Amount = 0,
                                            Currency =
                                                PricingModelPricePeriodTierFlatPriceCurrency.Usd,
                                        },
                                        UnitPrice = new()
                                        {
                                            Amount = 0,
                                            Currency =
                                                PricingModelPricePeriodTierUnitPriceCurrency.Usd,
                                        },
                                        UpTo = 0,
                                    },
                                ],
                            },
                        ],
                        BillingCadence = PricingModelBillingCadence.Recurring,
                        FeatureID = "featureId",
                        MaxUnitQuantity = 1,
                        MinUnitQuantity = 1,
                        MonthlyResetPeriodConfiguration = new(
                            PricingModelMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                        ),
                        ResetPeriod = PricingModelResetPeriod.Year,
                        TiersMode = TiersMode.Volume,
                        TopUpCustomCurrencyID = "topUpCustomCurrencyId",
                        WeeklyResetPeriodConfiguration = new(
                            PricingModelWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                        ),
                        YearlyResetPeriodConfiguration = new(
                            PricingModelYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                        ),
                    },
                ],
            },
            CompatibleAddonIds = ["string"],
            DefaultTrialConfig = new()
            {
                Duration = 0,
                Units = PlanUpdateParamsDefaultTrialConfigUnits.Day,
                Budget = new() { HasSoftLimit = true, Limit = 0 },
                TrialEndBehavior = PlanUpdateParamsDefaultTrialConfigTrialEndBehavior.ConvertToPaid,
            },
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ParentPlanID = "parentPlanId",
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        PlanUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ChargesTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Charges
        {
            PricingType = ChargesPricingType.Free,
            BillingID = "billingId",
            MinimumSpend =
            [
                new()
                {
                    BillingPeriod = BillingPeriod.Monthly,
                    Minimum = new() { Amount = 0, Currency = Currency.Usd },
                },
            ],
            OverageBillingPeriod = OverageBillingPeriod.OnSubscriptionRenewal,
            OveragePricingModels =
            [
                new()
                {
                    BillingModel = BillingModel.FlatFee,
                    PricePeriods =
                    [
                        new()
                        {
                            BillingPeriod = PricePeriodBillingPeriod.Monthly,
                            BillingCountryCode = "billingCountryCode",
                            BlockSize = 0,
                            CreditGrantCadence = CreditGrantCadence.BeginningOfBillingPeriod,
                            CreditRate = new()
                            {
                                Amount = 1,
                                CurrencyID = "currencyId",
                                CostFormula = "costFormula",
                            },
                            Price = new() { Amount = 0, Currency = PriceCurrency.Usd },
                            Tiers =
                            [
                                new()
                                {
                                    FlatPrice = new()
                                    {
                                        Amount = 0,
                                        Currency = FlatPriceCurrency.Usd,
                                    },
                                    UnitPrice = new()
                                    {
                                        Amount = 0,
                                        Currency = UnitPriceCurrency.Usd,
                                    },
                                    UpTo = 0,
                                },
                            ],
                        },
                    ],
                    BillingCadence = BillingCadence.Recurring,
                    Entitlement = new()
                    {
                        FeatureID = "featureId",
                        HasSoftLimit = true,
                        HasUnlimitedUsage = true,
                        MonthlyResetPeriodConfiguration = new(AccordingTo.SubscriptionStart),
                        ResetPeriod = ResetPeriod.Year,
                        UsageLimit = 0,
                        WeeklyResetPeriodConfiguration = new(
                            WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                        ),
                        YearlyResetPeriodConfiguration = new(
                            YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                        ),
                    },
                    FeatureID = "featureId",
                    TopUpCustomCurrencyID = "topUpCustomCurrencyId",
                },
            ],
            PricingModels =
            [
                new()
                {
                    BillingModel = PricingModelBillingModel.FlatFee,
                    PricePeriods =
                    [
                        new()
                        {
                            BillingPeriod = PricingModelPricePeriodBillingPeriod.Monthly,
                            BillingCountryCode = "billingCountryCode",
                            BlockSize = 0,
                            CreditGrantCadence =
                                PricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                            CreditRate = new()
                            {
                                Amount = 1,
                                CurrencyID = "currencyId",
                                CostFormula = "costFormula",
                            },
                            Price = new()
                            {
                                Amount = 0,
                                Currency = PricingModelPricePeriodPriceCurrency.Usd,
                            },
                            Tiers =
                            [
                                new()
                                {
                                    FlatPrice = new()
                                    {
                                        Amount = 0,
                                        Currency = PricingModelPricePeriodTierFlatPriceCurrency.Usd,
                                    },
                                    UnitPrice = new()
                                    {
                                        Amount = 0,
                                        Currency = PricingModelPricePeriodTierUnitPriceCurrency.Usd,
                                    },
                                    UpTo = 0,
                                },
                            ],
                        },
                    ],
                    BillingCadence = PricingModelBillingCadence.Recurring,
                    FeatureID = "featureId",
                    MaxUnitQuantity = 1,
                    MinUnitQuantity = 1,
                    MonthlyResetPeriodConfiguration = new(
                        PricingModelMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    ResetPeriod = PricingModelResetPeriod.Year,
                    TiersMode = TiersMode.Volume,
                    TopUpCustomCurrencyID = "topUpCustomCurrencyId",
                    WeeklyResetPeriodConfiguration = new(
                        PricingModelWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    YearlyResetPeriodConfiguration = new(
                        PricingModelYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                },
            ],
        };

        ApiEnum<string, ChargesPricingType> expectedPricingType = ChargesPricingType.Free;
        string expectedBillingID = "billingId";
        List<MinimumSpend> expectedMinimumSpend =
        [
            new()
            {
                BillingPeriod = BillingPeriod.Monthly,
                Minimum = new() { Amount = 0, Currency = Currency.Usd },
            },
        ];
        ApiEnum<string, OverageBillingPeriod> expectedOverageBillingPeriod =
            OverageBillingPeriod.OnSubscriptionRenewal;
        List<OveragePricingModel> expectedOveragePricingModels =
        [
            new()
            {
                BillingModel = BillingModel.FlatFee,
                PricePeriods =
                [
                    new()
                    {
                        BillingPeriod = PricePeriodBillingPeriod.Monthly,
                        BillingCountryCode = "billingCountryCode",
                        BlockSize = 0,
                        CreditGrantCadence = CreditGrantCadence.BeginningOfBillingPeriod,
                        CreditRate = new()
                        {
                            Amount = 1,
                            CurrencyID = "currencyId",
                            CostFormula = "costFormula",
                        },
                        Price = new() { Amount = 0, Currency = PriceCurrency.Usd },
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
                BillingCadence = BillingCadence.Recurring,
                Entitlement = new()
                {
                    FeatureID = "featureId",
                    HasSoftLimit = true,
                    HasUnlimitedUsage = true,
                    MonthlyResetPeriodConfiguration = new(AccordingTo.SubscriptionStart),
                    ResetPeriod = ResetPeriod.Year,
                    UsageLimit = 0,
                    WeeklyResetPeriodConfiguration = new(
                        WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    YearlyResetPeriodConfiguration = new(
                        YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                },
                FeatureID = "featureId",
                TopUpCustomCurrencyID = "topUpCustomCurrencyId",
            },
        ];
        List<PricingModel> expectedPricingModels =
        [
            new()
            {
                BillingModel = PricingModelBillingModel.FlatFee,
                PricePeriods =
                [
                    new()
                    {
                        BillingPeriod = PricingModelPricePeriodBillingPeriod.Monthly,
                        BillingCountryCode = "billingCountryCode",
                        BlockSize = 0,
                        CreditGrantCadence =
                            PricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                        CreditRate = new()
                        {
                            Amount = 1,
                            CurrencyID = "currencyId",
                            CostFormula = "costFormula",
                        },
                        Price = new()
                        {
                            Amount = 0,
                            Currency = PricingModelPricePeriodPriceCurrency.Usd,
                        },
                        Tiers =
                        [
                            new()
                            {
                                FlatPrice = new()
                                {
                                    Amount = 0,
                                    Currency = PricingModelPricePeriodTierFlatPriceCurrency.Usd,
                                },
                                UnitPrice = new()
                                {
                                    Amount = 0,
                                    Currency = PricingModelPricePeriodTierUnitPriceCurrency.Usd,
                                },
                                UpTo = 0,
                            },
                        ],
                    },
                ],
                BillingCadence = PricingModelBillingCadence.Recurring,
                FeatureID = "featureId",
                MaxUnitQuantity = 1,
                MinUnitQuantity = 1,
                MonthlyResetPeriodConfiguration = new(
                    PricingModelMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
                ResetPeriod = PricingModelResetPeriod.Year,
                TiersMode = TiersMode.Volume,
                TopUpCustomCurrencyID = "topUpCustomCurrencyId",
                WeeklyResetPeriodConfiguration = new(
                    PricingModelWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
                YearlyResetPeriodConfiguration = new(
                    PricingModelYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
            },
        ];

        Assert.Equal(expectedPricingType, model.PricingType);
        Assert.Equal(expectedBillingID, model.BillingID);
        Assert.NotNull(model.MinimumSpend);
        Assert.Equal(expectedMinimumSpend.Count, model.MinimumSpend.Count);
        for (int i = 0; i < expectedMinimumSpend.Count; i++)
        {
            Assert.Equal(expectedMinimumSpend[i], model.MinimumSpend[i]);
        }
        Assert.Equal(expectedOverageBillingPeriod, model.OverageBillingPeriod);
        Assert.NotNull(model.OveragePricingModels);
        Assert.Equal(expectedOveragePricingModels.Count, model.OveragePricingModels.Count);
        for (int i = 0; i < expectedOveragePricingModels.Count; i++)
        {
            Assert.Equal(expectedOveragePricingModels[i], model.OveragePricingModels[i]);
        }
        Assert.NotNull(model.PricingModels);
        Assert.Equal(expectedPricingModels.Count, model.PricingModels.Count);
        for (int i = 0; i < expectedPricingModels.Count; i++)
        {
            Assert.Equal(expectedPricingModels[i], model.PricingModels[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Charges
        {
            PricingType = ChargesPricingType.Free,
            BillingID = "billingId",
            MinimumSpend =
            [
                new()
                {
                    BillingPeriod = BillingPeriod.Monthly,
                    Minimum = new() { Amount = 0, Currency = Currency.Usd },
                },
            ],
            OverageBillingPeriod = OverageBillingPeriod.OnSubscriptionRenewal,
            OveragePricingModels =
            [
                new()
                {
                    BillingModel = BillingModel.FlatFee,
                    PricePeriods =
                    [
                        new()
                        {
                            BillingPeriod = PricePeriodBillingPeriod.Monthly,
                            BillingCountryCode = "billingCountryCode",
                            BlockSize = 0,
                            CreditGrantCadence = CreditGrantCadence.BeginningOfBillingPeriod,
                            CreditRate = new()
                            {
                                Amount = 1,
                                CurrencyID = "currencyId",
                                CostFormula = "costFormula",
                            },
                            Price = new() { Amount = 0, Currency = PriceCurrency.Usd },
                            Tiers =
                            [
                                new()
                                {
                                    FlatPrice = new()
                                    {
                                        Amount = 0,
                                        Currency = FlatPriceCurrency.Usd,
                                    },
                                    UnitPrice = new()
                                    {
                                        Amount = 0,
                                        Currency = UnitPriceCurrency.Usd,
                                    },
                                    UpTo = 0,
                                },
                            ],
                        },
                    ],
                    BillingCadence = BillingCadence.Recurring,
                    Entitlement = new()
                    {
                        FeatureID = "featureId",
                        HasSoftLimit = true,
                        HasUnlimitedUsage = true,
                        MonthlyResetPeriodConfiguration = new(AccordingTo.SubscriptionStart),
                        ResetPeriod = ResetPeriod.Year,
                        UsageLimit = 0,
                        WeeklyResetPeriodConfiguration = new(
                            WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                        ),
                        YearlyResetPeriodConfiguration = new(
                            YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                        ),
                    },
                    FeatureID = "featureId",
                    TopUpCustomCurrencyID = "topUpCustomCurrencyId",
                },
            ],
            PricingModels =
            [
                new()
                {
                    BillingModel = PricingModelBillingModel.FlatFee,
                    PricePeriods =
                    [
                        new()
                        {
                            BillingPeriod = PricingModelPricePeriodBillingPeriod.Monthly,
                            BillingCountryCode = "billingCountryCode",
                            BlockSize = 0,
                            CreditGrantCadence =
                                PricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                            CreditRate = new()
                            {
                                Amount = 1,
                                CurrencyID = "currencyId",
                                CostFormula = "costFormula",
                            },
                            Price = new()
                            {
                                Amount = 0,
                                Currency = PricingModelPricePeriodPriceCurrency.Usd,
                            },
                            Tiers =
                            [
                                new()
                                {
                                    FlatPrice = new()
                                    {
                                        Amount = 0,
                                        Currency = PricingModelPricePeriodTierFlatPriceCurrency.Usd,
                                    },
                                    UnitPrice = new()
                                    {
                                        Amount = 0,
                                        Currency = PricingModelPricePeriodTierUnitPriceCurrency.Usd,
                                    },
                                    UpTo = 0,
                                },
                            ],
                        },
                    ],
                    BillingCadence = PricingModelBillingCadence.Recurring,
                    FeatureID = "featureId",
                    MaxUnitQuantity = 1,
                    MinUnitQuantity = 1,
                    MonthlyResetPeriodConfiguration = new(
                        PricingModelMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    ResetPeriod = PricingModelResetPeriod.Year,
                    TiersMode = TiersMode.Volume,
                    TopUpCustomCurrencyID = "topUpCustomCurrencyId",
                    WeeklyResetPeriodConfiguration = new(
                        PricingModelWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    YearlyResetPeriodConfiguration = new(
                        PricingModelYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Charges>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Charges
        {
            PricingType = ChargesPricingType.Free,
            BillingID = "billingId",
            MinimumSpend =
            [
                new()
                {
                    BillingPeriod = BillingPeriod.Monthly,
                    Minimum = new() { Amount = 0, Currency = Currency.Usd },
                },
            ],
            OverageBillingPeriod = OverageBillingPeriod.OnSubscriptionRenewal,
            OveragePricingModels =
            [
                new()
                {
                    BillingModel = BillingModel.FlatFee,
                    PricePeriods =
                    [
                        new()
                        {
                            BillingPeriod = PricePeriodBillingPeriod.Monthly,
                            BillingCountryCode = "billingCountryCode",
                            BlockSize = 0,
                            CreditGrantCadence = CreditGrantCadence.BeginningOfBillingPeriod,
                            CreditRate = new()
                            {
                                Amount = 1,
                                CurrencyID = "currencyId",
                                CostFormula = "costFormula",
                            },
                            Price = new() { Amount = 0, Currency = PriceCurrency.Usd },
                            Tiers =
                            [
                                new()
                                {
                                    FlatPrice = new()
                                    {
                                        Amount = 0,
                                        Currency = FlatPriceCurrency.Usd,
                                    },
                                    UnitPrice = new()
                                    {
                                        Amount = 0,
                                        Currency = UnitPriceCurrency.Usd,
                                    },
                                    UpTo = 0,
                                },
                            ],
                        },
                    ],
                    BillingCadence = BillingCadence.Recurring,
                    Entitlement = new()
                    {
                        FeatureID = "featureId",
                        HasSoftLimit = true,
                        HasUnlimitedUsage = true,
                        MonthlyResetPeriodConfiguration = new(AccordingTo.SubscriptionStart),
                        ResetPeriod = ResetPeriod.Year,
                        UsageLimit = 0,
                        WeeklyResetPeriodConfiguration = new(
                            WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                        ),
                        YearlyResetPeriodConfiguration = new(
                            YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                        ),
                    },
                    FeatureID = "featureId",
                    TopUpCustomCurrencyID = "topUpCustomCurrencyId",
                },
            ],
            PricingModels =
            [
                new()
                {
                    BillingModel = PricingModelBillingModel.FlatFee,
                    PricePeriods =
                    [
                        new()
                        {
                            BillingPeriod = PricingModelPricePeriodBillingPeriod.Monthly,
                            BillingCountryCode = "billingCountryCode",
                            BlockSize = 0,
                            CreditGrantCadence =
                                PricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                            CreditRate = new()
                            {
                                Amount = 1,
                                CurrencyID = "currencyId",
                                CostFormula = "costFormula",
                            },
                            Price = new()
                            {
                                Amount = 0,
                                Currency = PricingModelPricePeriodPriceCurrency.Usd,
                            },
                            Tiers =
                            [
                                new()
                                {
                                    FlatPrice = new()
                                    {
                                        Amount = 0,
                                        Currency = PricingModelPricePeriodTierFlatPriceCurrency.Usd,
                                    },
                                    UnitPrice = new()
                                    {
                                        Amount = 0,
                                        Currency = PricingModelPricePeriodTierUnitPriceCurrency.Usd,
                                    },
                                    UpTo = 0,
                                },
                            ],
                        },
                    ],
                    BillingCadence = PricingModelBillingCadence.Recurring,
                    FeatureID = "featureId",
                    MaxUnitQuantity = 1,
                    MinUnitQuantity = 1,
                    MonthlyResetPeriodConfiguration = new(
                        PricingModelMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    ResetPeriod = PricingModelResetPeriod.Year,
                    TiersMode = TiersMode.Volume,
                    TopUpCustomCurrencyID = "topUpCustomCurrencyId",
                    WeeklyResetPeriodConfiguration = new(
                        PricingModelWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    YearlyResetPeriodConfiguration = new(
                        PricingModelYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Charges>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, ChargesPricingType> expectedPricingType = ChargesPricingType.Free;
        string expectedBillingID = "billingId";
        List<MinimumSpend> expectedMinimumSpend =
        [
            new()
            {
                BillingPeriod = BillingPeriod.Monthly,
                Minimum = new() { Amount = 0, Currency = Currency.Usd },
            },
        ];
        ApiEnum<string, OverageBillingPeriod> expectedOverageBillingPeriod =
            OverageBillingPeriod.OnSubscriptionRenewal;
        List<OveragePricingModel> expectedOveragePricingModels =
        [
            new()
            {
                BillingModel = BillingModel.FlatFee,
                PricePeriods =
                [
                    new()
                    {
                        BillingPeriod = PricePeriodBillingPeriod.Monthly,
                        BillingCountryCode = "billingCountryCode",
                        BlockSize = 0,
                        CreditGrantCadence = CreditGrantCadence.BeginningOfBillingPeriod,
                        CreditRate = new()
                        {
                            Amount = 1,
                            CurrencyID = "currencyId",
                            CostFormula = "costFormula",
                        },
                        Price = new() { Amount = 0, Currency = PriceCurrency.Usd },
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
                BillingCadence = BillingCadence.Recurring,
                Entitlement = new()
                {
                    FeatureID = "featureId",
                    HasSoftLimit = true,
                    HasUnlimitedUsage = true,
                    MonthlyResetPeriodConfiguration = new(AccordingTo.SubscriptionStart),
                    ResetPeriod = ResetPeriod.Year,
                    UsageLimit = 0,
                    WeeklyResetPeriodConfiguration = new(
                        WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    YearlyResetPeriodConfiguration = new(
                        YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                },
                FeatureID = "featureId",
                TopUpCustomCurrencyID = "topUpCustomCurrencyId",
            },
        ];
        List<PricingModel> expectedPricingModels =
        [
            new()
            {
                BillingModel = PricingModelBillingModel.FlatFee,
                PricePeriods =
                [
                    new()
                    {
                        BillingPeriod = PricingModelPricePeriodBillingPeriod.Monthly,
                        BillingCountryCode = "billingCountryCode",
                        BlockSize = 0,
                        CreditGrantCadence =
                            PricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                        CreditRate = new()
                        {
                            Amount = 1,
                            CurrencyID = "currencyId",
                            CostFormula = "costFormula",
                        },
                        Price = new()
                        {
                            Amount = 0,
                            Currency = PricingModelPricePeriodPriceCurrency.Usd,
                        },
                        Tiers =
                        [
                            new()
                            {
                                FlatPrice = new()
                                {
                                    Amount = 0,
                                    Currency = PricingModelPricePeriodTierFlatPriceCurrency.Usd,
                                },
                                UnitPrice = new()
                                {
                                    Amount = 0,
                                    Currency = PricingModelPricePeriodTierUnitPriceCurrency.Usd,
                                },
                                UpTo = 0,
                            },
                        ],
                    },
                ],
                BillingCadence = PricingModelBillingCadence.Recurring,
                FeatureID = "featureId",
                MaxUnitQuantity = 1,
                MinUnitQuantity = 1,
                MonthlyResetPeriodConfiguration = new(
                    PricingModelMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
                ResetPeriod = PricingModelResetPeriod.Year,
                TiersMode = TiersMode.Volume,
                TopUpCustomCurrencyID = "topUpCustomCurrencyId",
                WeeklyResetPeriodConfiguration = new(
                    PricingModelWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
                YearlyResetPeriodConfiguration = new(
                    PricingModelYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
            },
        ];

        Assert.Equal(expectedPricingType, deserialized.PricingType);
        Assert.Equal(expectedBillingID, deserialized.BillingID);
        Assert.NotNull(deserialized.MinimumSpend);
        Assert.Equal(expectedMinimumSpend.Count, deserialized.MinimumSpend.Count);
        for (int i = 0; i < expectedMinimumSpend.Count; i++)
        {
            Assert.Equal(expectedMinimumSpend[i], deserialized.MinimumSpend[i]);
        }
        Assert.Equal(expectedOverageBillingPeriod, deserialized.OverageBillingPeriod);
        Assert.NotNull(deserialized.OveragePricingModels);
        Assert.Equal(expectedOveragePricingModels.Count, deserialized.OveragePricingModels.Count);
        for (int i = 0; i < expectedOveragePricingModels.Count; i++)
        {
            Assert.Equal(expectedOveragePricingModels[i], deserialized.OveragePricingModels[i]);
        }
        Assert.NotNull(deserialized.PricingModels);
        Assert.Equal(expectedPricingModels.Count, deserialized.PricingModels.Count);
        for (int i = 0; i < expectedPricingModels.Count; i++)
        {
            Assert.Equal(expectedPricingModels[i], deserialized.PricingModels[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Charges
        {
            PricingType = ChargesPricingType.Free,
            BillingID = "billingId",
            MinimumSpend =
            [
                new()
                {
                    BillingPeriod = BillingPeriod.Monthly,
                    Minimum = new() { Amount = 0, Currency = Currency.Usd },
                },
            ],
            OverageBillingPeriod = OverageBillingPeriod.OnSubscriptionRenewal,
            OveragePricingModels =
            [
                new()
                {
                    BillingModel = BillingModel.FlatFee,
                    PricePeriods =
                    [
                        new()
                        {
                            BillingPeriod = PricePeriodBillingPeriod.Monthly,
                            BillingCountryCode = "billingCountryCode",
                            BlockSize = 0,
                            CreditGrantCadence = CreditGrantCadence.BeginningOfBillingPeriod,
                            CreditRate = new()
                            {
                                Amount = 1,
                                CurrencyID = "currencyId",
                                CostFormula = "costFormula",
                            },
                            Price = new() { Amount = 0, Currency = PriceCurrency.Usd },
                            Tiers =
                            [
                                new()
                                {
                                    FlatPrice = new()
                                    {
                                        Amount = 0,
                                        Currency = FlatPriceCurrency.Usd,
                                    },
                                    UnitPrice = new()
                                    {
                                        Amount = 0,
                                        Currency = UnitPriceCurrency.Usd,
                                    },
                                    UpTo = 0,
                                },
                            ],
                        },
                    ],
                    BillingCadence = BillingCadence.Recurring,
                    Entitlement = new()
                    {
                        FeatureID = "featureId",
                        HasSoftLimit = true,
                        HasUnlimitedUsage = true,
                        MonthlyResetPeriodConfiguration = new(AccordingTo.SubscriptionStart),
                        ResetPeriod = ResetPeriod.Year,
                        UsageLimit = 0,
                        WeeklyResetPeriodConfiguration = new(
                            WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                        ),
                        YearlyResetPeriodConfiguration = new(
                            YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                        ),
                    },
                    FeatureID = "featureId",
                    TopUpCustomCurrencyID = "topUpCustomCurrencyId",
                },
            ],
            PricingModels =
            [
                new()
                {
                    BillingModel = PricingModelBillingModel.FlatFee,
                    PricePeriods =
                    [
                        new()
                        {
                            BillingPeriod = PricingModelPricePeriodBillingPeriod.Monthly,
                            BillingCountryCode = "billingCountryCode",
                            BlockSize = 0,
                            CreditGrantCadence =
                                PricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                            CreditRate = new()
                            {
                                Amount = 1,
                                CurrencyID = "currencyId",
                                CostFormula = "costFormula",
                            },
                            Price = new()
                            {
                                Amount = 0,
                                Currency = PricingModelPricePeriodPriceCurrency.Usd,
                            },
                            Tiers =
                            [
                                new()
                                {
                                    FlatPrice = new()
                                    {
                                        Amount = 0,
                                        Currency = PricingModelPricePeriodTierFlatPriceCurrency.Usd,
                                    },
                                    UnitPrice = new()
                                    {
                                        Amount = 0,
                                        Currency = PricingModelPricePeriodTierUnitPriceCurrency.Usd,
                                    },
                                    UpTo = 0,
                                },
                            ],
                        },
                    ],
                    BillingCadence = PricingModelBillingCadence.Recurring,
                    FeatureID = "featureId",
                    MaxUnitQuantity = 1,
                    MinUnitQuantity = 1,
                    MonthlyResetPeriodConfiguration = new(
                        PricingModelMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    ResetPeriod = PricingModelResetPeriod.Year,
                    TiersMode = TiersMode.Volume,
                    TopUpCustomCurrencyID = "topUpCustomCurrencyId",
                    WeeklyResetPeriodConfiguration = new(
                        PricingModelWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    YearlyResetPeriodConfiguration = new(
                        PricingModelYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Charges
        {
            PricingType = ChargesPricingType.Free,
            MinimumSpend =
            [
                new()
                {
                    BillingPeriod = BillingPeriod.Monthly,
                    Minimum = new() { Amount = 0, Currency = Currency.Usd },
                },
            ],
        };

        Assert.Null(model.BillingID);
        Assert.False(model.RawData.ContainsKey("billingId"));
        Assert.Null(model.OverageBillingPeriod);
        Assert.False(model.RawData.ContainsKey("overageBillingPeriod"));
        Assert.Null(model.OveragePricingModels);
        Assert.False(model.RawData.ContainsKey("overagePricingModels"));
        Assert.Null(model.PricingModels);
        Assert.False(model.RawData.ContainsKey("pricingModels"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Charges
        {
            PricingType = ChargesPricingType.Free,
            MinimumSpend =
            [
                new()
                {
                    BillingPeriod = BillingPeriod.Monthly,
                    Minimum = new() { Amount = 0, Currency = Currency.Usd },
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Charges
        {
            PricingType = ChargesPricingType.Free,
            MinimumSpend =
            [
                new()
                {
                    BillingPeriod = BillingPeriod.Monthly,
                    Minimum = new() { Amount = 0, Currency = Currency.Usd },
                },
            ],

            // Null should be interpreted as omitted for these properties
            BillingID = null,
            OverageBillingPeriod = null,
            OveragePricingModels = null,
            PricingModels = null,
        };

        Assert.Null(model.BillingID);
        Assert.False(model.RawData.ContainsKey("billingId"));
        Assert.Null(model.OverageBillingPeriod);
        Assert.False(model.RawData.ContainsKey("overageBillingPeriod"));
        Assert.Null(model.OveragePricingModels);
        Assert.False(model.RawData.ContainsKey("overagePricingModels"));
        Assert.Null(model.PricingModels);
        Assert.False(model.RawData.ContainsKey("pricingModels"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Charges
        {
            PricingType = ChargesPricingType.Free,
            MinimumSpend =
            [
                new()
                {
                    BillingPeriod = BillingPeriod.Monthly,
                    Minimum = new() { Amount = 0, Currency = Currency.Usd },
                },
            ],

            // Null should be interpreted as omitted for these properties
            BillingID = null,
            OverageBillingPeriod = null,
            OveragePricingModels = null,
            PricingModels = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Charges
        {
            PricingType = ChargesPricingType.Free,
            BillingID = "billingId",
            OverageBillingPeriod = OverageBillingPeriod.OnSubscriptionRenewal,
            OveragePricingModels =
            [
                new()
                {
                    BillingModel = BillingModel.FlatFee,
                    PricePeriods =
                    [
                        new()
                        {
                            BillingPeriod = PricePeriodBillingPeriod.Monthly,
                            BillingCountryCode = "billingCountryCode",
                            BlockSize = 0,
                            CreditGrantCadence = CreditGrantCadence.BeginningOfBillingPeriod,
                            CreditRate = new()
                            {
                                Amount = 1,
                                CurrencyID = "currencyId",
                                CostFormula = "costFormula",
                            },
                            Price = new() { Amount = 0, Currency = PriceCurrency.Usd },
                            Tiers =
                            [
                                new()
                                {
                                    FlatPrice = new()
                                    {
                                        Amount = 0,
                                        Currency = FlatPriceCurrency.Usd,
                                    },
                                    UnitPrice = new()
                                    {
                                        Amount = 0,
                                        Currency = UnitPriceCurrency.Usd,
                                    },
                                    UpTo = 0,
                                },
                            ],
                        },
                    ],
                    BillingCadence = BillingCadence.Recurring,
                    Entitlement = new()
                    {
                        FeatureID = "featureId",
                        HasSoftLimit = true,
                        HasUnlimitedUsage = true,
                        MonthlyResetPeriodConfiguration = new(AccordingTo.SubscriptionStart),
                        ResetPeriod = ResetPeriod.Year,
                        UsageLimit = 0,
                        WeeklyResetPeriodConfiguration = new(
                            WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                        ),
                        YearlyResetPeriodConfiguration = new(
                            YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                        ),
                    },
                    FeatureID = "featureId",
                    TopUpCustomCurrencyID = "topUpCustomCurrencyId",
                },
            ],
            PricingModels =
            [
                new()
                {
                    BillingModel = PricingModelBillingModel.FlatFee,
                    PricePeriods =
                    [
                        new()
                        {
                            BillingPeriod = PricingModelPricePeriodBillingPeriod.Monthly,
                            BillingCountryCode = "billingCountryCode",
                            BlockSize = 0,
                            CreditGrantCadence =
                                PricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                            CreditRate = new()
                            {
                                Amount = 1,
                                CurrencyID = "currencyId",
                                CostFormula = "costFormula",
                            },
                            Price = new()
                            {
                                Amount = 0,
                                Currency = PricingModelPricePeriodPriceCurrency.Usd,
                            },
                            Tiers =
                            [
                                new()
                                {
                                    FlatPrice = new()
                                    {
                                        Amount = 0,
                                        Currency = PricingModelPricePeriodTierFlatPriceCurrency.Usd,
                                    },
                                    UnitPrice = new()
                                    {
                                        Amount = 0,
                                        Currency = PricingModelPricePeriodTierUnitPriceCurrency.Usd,
                                    },
                                    UpTo = 0,
                                },
                            ],
                        },
                    ],
                    BillingCadence = PricingModelBillingCadence.Recurring,
                    FeatureID = "featureId",
                    MaxUnitQuantity = 1,
                    MinUnitQuantity = 1,
                    MonthlyResetPeriodConfiguration = new(
                        PricingModelMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    ResetPeriod = PricingModelResetPeriod.Year,
                    TiersMode = TiersMode.Volume,
                    TopUpCustomCurrencyID = "topUpCustomCurrencyId",
                    WeeklyResetPeriodConfiguration = new(
                        PricingModelWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    YearlyResetPeriodConfiguration = new(
                        PricingModelYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                },
            ],
        };

        Assert.Null(model.MinimumSpend);
        Assert.False(model.RawData.ContainsKey("minimumSpend"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Charges
        {
            PricingType = ChargesPricingType.Free,
            BillingID = "billingId",
            OverageBillingPeriod = OverageBillingPeriod.OnSubscriptionRenewal,
            OveragePricingModels =
            [
                new()
                {
                    BillingModel = BillingModel.FlatFee,
                    PricePeriods =
                    [
                        new()
                        {
                            BillingPeriod = PricePeriodBillingPeriod.Monthly,
                            BillingCountryCode = "billingCountryCode",
                            BlockSize = 0,
                            CreditGrantCadence = CreditGrantCadence.BeginningOfBillingPeriod,
                            CreditRate = new()
                            {
                                Amount = 1,
                                CurrencyID = "currencyId",
                                CostFormula = "costFormula",
                            },
                            Price = new() { Amount = 0, Currency = PriceCurrency.Usd },
                            Tiers =
                            [
                                new()
                                {
                                    FlatPrice = new()
                                    {
                                        Amount = 0,
                                        Currency = FlatPriceCurrency.Usd,
                                    },
                                    UnitPrice = new()
                                    {
                                        Amount = 0,
                                        Currency = UnitPriceCurrency.Usd,
                                    },
                                    UpTo = 0,
                                },
                            ],
                        },
                    ],
                    BillingCadence = BillingCadence.Recurring,
                    Entitlement = new()
                    {
                        FeatureID = "featureId",
                        HasSoftLimit = true,
                        HasUnlimitedUsage = true,
                        MonthlyResetPeriodConfiguration = new(AccordingTo.SubscriptionStart),
                        ResetPeriod = ResetPeriod.Year,
                        UsageLimit = 0,
                        WeeklyResetPeriodConfiguration = new(
                            WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                        ),
                        YearlyResetPeriodConfiguration = new(
                            YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                        ),
                    },
                    FeatureID = "featureId",
                    TopUpCustomCurrencyID = "topUpCustomCurrencyId",
                },
            ],
            PricingModels =
            [
                new()
                {
                    BillingModel = PricingModelBillingModel.FlatFee,
                    PricePeriods =
                    [
                        new()
                        {
                            BillingPeriod = PricingModelPricePeriodBillingPeriod.Monthly,
                            BillingCountryCode = "billingCountryCode",
                            BlockSize = 0,
                            CreditGrantCadence =
                                PricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                            CreditRate = new()
                            {
                                Amount = 1,
                                CurrencyID = "currencyId",
                                CostFormula = "costFormula",
                            },
                            Price = new()
                            {
                                Amount = 0,
                                Currency = PricingModelPricePeriodPriceCurrency.Usd,
                            },
                            Tiers =
                            [
                                new()
                                {
                                    FlatPrice = new()
                                    {
                                        Amount = 0,
                                        Currency = PricingModelPricePeriodTierFlatPriceCurrency.Usd,
                                    },
                                    UnitPrice = new()
                                    {
                                        Amount = 0,
                                        Currency = PricingModelPricePeriodTierUnitPriceCurrency.Usd,
                                    },
                                    UpTo = 0,
                                },
                            ],
                        },
                    ],
                    BillingCadence = PricingModelBillingCadence.Recurring,
                    FeatureID = "featureId",
                    MaxUnitQuantity = 1,
                    MinUnitQuantity = 1,
                    MonthlyResetPeriodConfiguration = new(
                        PricingModelMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    ResetPeriod = PricingModelResetPeriod.Year,
                    TiersMode = TiersMode.Volume,
                    TopUpCustomCurrencyID = "topUpCustomCurrencyId",
                    WeeklyResetPeriodConfiguration = new(
                        PricingModelWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    YearlyResetPeriodConfiguration = new(
                        PricingModelYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Charges
        {
            PricingType = ChargesPricingType.Free,
            BillingID = "billingId",
            OverageBillingPeriod = OverageBillingPeriod.OnSubscriptionRenewal,
            OveragePricingModels =
            [
                new()
                {
                    BillingModel = BillingModel.FlatFee,
                    PricePeriods =
                    [
                        new()
                        {
                            BillingPeriod = PricePeriodBillingPeriod.Monthly,
                            BillingCountryCode = "billingCountryCode",
                            BlockSize = 0,
                            CreditGrantCadence = CreditGrantCadence.BeginningOfBillingPeriod,
                            CreditRate = new()
                            {
                                Amount = 1,
                                CurrencyID = "currencyId",
                                CostFormula = "costFormula",
                            },
                            Price = new() { Amount = 0, Currency = PriceCurrency.Usd },
                            Tiers =
                            [
                                new()
                                {
                                    FlatPrice = new()
                                    {
                                        Amount = 0,
                                        Currency = FlatPriceCurrency.Usd,
                                    },
                                    UnitPrice = new()
                                    {
                                        Amount = 0,
                                        Currency = UnitPriceCurrency.Usd,
                                    },
                                    UpTo = 0,
                                },
                            ],
                        },
                    ],
                    BillingCadence = BillingCadence.Recurring,
                    Entitlement = new()
                    {
                        FeatureID = "featureId",
                        HasSoftLimit = true,
                        HasUnlimitedUsage = true,
                        MonthlyResetPeriodConfiguration = new(AccordingTo.SubscriptionStart),
                        ResetPeriod = ResetPeriod.Year,
                        UsageLimit = 0,
                        WeeklyResetPeriodConfiguration = new(
                            WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                        ),
                        YearlyResetPeriodConfiguration = new(
                            YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                        ),
                    },
                    FeatureID = "featureId",
                    TopUpCustomCurrencyID = "topUpCustomCurrencyId",
                },
            ],
            PricingModels =
            [
                new()
                {
                    BillingModel = PricingModelBillingModel.FlatFee,
                    PricePeriods =
                    [
                        new()
                        {
                            BillingPeriod = PricingModelPricePeriodBillingPeriod.Monthly,
                            BillingCountryCode = "billingCountryCode",
                            BlockSize = 0,
                            CreditGrantCadence =
                                PricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                            CreditRate = new()
                            {
                                Amount = 1,
                                CurrencyID = "currencyId",
                                CostFormula = "costFormula",
                            },
                            Price = new()
                            {
                                Amount = 0,
                                Currency = PricingModelPricePeriodPriceCurrency.Usd,
                            },
                            Tiers =
                            [
                                new()
                                {
                                    FlatPrice = new()
                                    {
                                        Amount = 0,
                                        Currency = PricingModelPricePeriodTierFlatPriceCurrency.Usd,
                                    },
                                    UnitPrice = new()
                                    {
                                        Amount = 0,
                                        Currency = PricingModelPricePeriodTierUnitPriceCurrency.Usd,
                                    },
                                    UpTo = 0,
                                },
                            ],
                        },
                    ],
                    BillingCadence = PricingModelBillingCadence.Recurring,
                    FeatureID = "featureId",
                    MaxUnitQuantity = 1,
                    MinUnitQuantity = 1,
                    MonthlyResetPeriodConfiguration = new(
                        PricingModelMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    ResetPeriod = PricingModelResetPeriod.Year,
                    TiersMode = TiersMode.Volume,
                    TopUpCustomCurrencyID = "topUpCustomCurrencyId",
                    WeeklyResetPeriodConfiguration = new(
                        PricingModelWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    YearlyResetPeriodConfiguration = new(
                        PricingModelYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                },
            ],

            MinimumSpend = null,
        };

        Assert.Null(model.MinimumSpend);
        Assert.True(model.RawData.ContainsKey("minimumSpend"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Charges
        {
            PricingType = ChargesPricingType.Free,
            BillingID = "billingId",
            OverageBillingPeriod = OverageBillingPeriod.OnSubscriptionRenewal,
            OveragePricingModels =
            [
                new()
                {
                    BillingModel = BillingModel.FlatFee,
                    PricePeriods =
                    [
                        new()
                        {
                            BillingPeriod = PricePeriodBillingPeriod.Monthly,
                            BillingCountryCode = "billingCountryCode",
                            BlockSize = 0,
                            CreditGrantCadence = CreditGrantCadence.BeginningOfBillingPeriod,
                            CreditRate = new()
                            {
                                Amount = 1,
                                CurrencyID = "currencyId",
                                CostFormula = "costFormula",
                            },
                            Price = new() { Amount = 0, Currency = PriceCurrency.Usd },
                            Tiers =
                            [
                                new()
                                {
                                    FlatPrice = new()
                                    {
                                        Amount = 0,
                                        Currency = FlatPriceCurrency.Usd,
                                    },
                                    UnitPrice = new()
                                    {
                                        Amount = 0,
                                        Currency = UnitPriceCurrency.Usd,
                                    },
                                    UpTo = 0,
                                },
                            ],
                        },
                    ],
                    BillingCadence = BillingCadence.Recurring,
                    Entitlement = new()
                    {
                        FeatureID = "featureId",
                        HasSoftLimit = true,
                        HasUnlimitedUsage = true,
                        MonthlyResetPeriodConfiguration = new(AccordingTo.SubscriptionStart),
                        ResetPeriod = ResetPeriod.Year,
                        UsageLimit = 0,
                        WeeklyResetPeriodConfiguration = new(
                            WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                        ),
                        YearlyResetPeriodConfiguration = new(
                            YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                        ),
                    },
                    FeatureID = "featureId",
                    TopUpCustomCurrencyID = "topUpCustomCurrencyId",
                },
            ],
            PricingModels =
            [
                new()
                {
                    BillingModel = PricingModelBillingModel.FlatFee,
                    PricePeriods =
                    [
                        new()
                        {
                            BillingPeriod = PricingModelPricePeriodBillingPeriod.Monthly,
                            BillingCountryCode = "billingCountryCode",
                            BlockSize = 0,
                            CreditGrantCadence =
                                PricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                            CreditRate = new()
                            {
                                Amount = 1,
                                CurrencyID = "currencyId",
                                CostFormula = "costFormula",
                            },
                            Price = new()
                            {
                                Amount = 0,
                                Currency = PricingModelPricePeriodPriceCurrency.Usd,
                            },
                            Tiers =
                            [
                                new()
                                {
                                    FlatPrice = new()
                                    {
                                        Amount = 0,
                                        Currency = PricingModelPricePeriodTierFlatPriceCurrency.Usd,
                                    },
                                    UnitPrice = new()
                                    {
                                        Amount = 0,
                                        Currency = PricingModelPricePeriodTierUnitPriceCurrency.Usd,
                                    },
                                    UpTo = 0,
                                },
                            ],
                        },
                    ],
                    BillingCadence = PricingModelBillingCadence.Recurring,
                    FeatureID = "featureId",
                    MaxUnitQuantity = 1,
                    MinUnitQuantity = 1,
                    MonthlyResetPeriodConfiguration = new(
                        PricingModelMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    ResetPeriod = PricingModelResetPeriod.Year,
                    TiersMode = TiersMode.Volume,
                    TopUpCustomCurrencyID = "topUpCustomCurrencyId",
                    WeeklyResetPeriodConfiguration = new(
                        PricingModelWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    YearlyResetPeriodConfiguration = new(
                        PricingModelYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                },
            ],

            MinimumSpend = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Charges
        {
            PricingType = ChargesPricingType.Free,
            BillingID = "billingId",
            MinimumSpend =
            [
                new()
                {
                    BillingPeriod = BillingPeriod.Monthly,
                    Minimum = new() { Amount = 0, Currency = Currency.Usd },
                },
            ],
            OverageBillingPeriod = OverageBillingPeriod.OnSubscriptionRenewal,
            OveragePricingModels =
            [
                new()
                {
                    BillingModel = BillingModel.FlatFee,
                    PricePeriods =
                    [
                        new()
                        {
                            BillingPeriod = PricePeriodBillingPeriod.Monthly,
                            BillingCountryCode = "billingCountryCode",
                            BlockSize = 0,
                            CreditGrantCadence = CreditGrantCadence.BeginningOfBillingPeriod,
                            CreditRate = new()
                            {
                                Amount = 1,
                                CurrencyID = "currencyId",
                                CostFormula = "costFormula",
                            },
                            Price = new() { Amount = 0, Currency = PriceCurrency.Usd },
                            Tiers =
                            [
                                new()
                                {
                                    FlatPrice = new()
                                    {
                                        Amount = 0,
                                        Currency = FlatPriceCurrency.Usd,
                                    },
                                    UnitPrice = new()
                                    {
                                        Amount = 0,
                                        Currency = UnitPriceCurrency.Usd,
                                    },
                                    UpTo = 0,
                                },
                            ],
                        },
                    ],
                    BillingCadence = BillingCadence.Recurring,
                    Entitlement = new()
                    {
                        FeatureID = "featureId",
                        HasSoftLimit = true,
                        HasUnlimitedUsage = true,
                        MonthlyResetPeriodConfiguration = new(AccordingTo.SubscriptionStart),
                        ResetPeriod = ResetPeriod.Year,
                        UsageLimit = 0,
                        WeeklyResetPeriodConfiguration = new(
                            WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                        ),
                        YearlyResetPeriodConfiguration = new(
                            YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                        ),
                    },
                    FeatureID = "featureId",
                    TopUpCustomCurrencyID = "topUpCustomCurrencyId",
                },
            ],
            PricingModels =
            [
                new()
                {
                    BillingModel = PricingModelBillingModel.FlatFee,
                    PricePeriods =
                    [
                        new()
                        {
                            BillingPeriod = PricingModelPricePeriodBillingPeriod.Monthly,
                            BillingCountryCode = "billingCountryCode",
                            BlockSize = 0,
                            CreditGrantCadence =
                                PricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                            CreditRate = new()
                            {
                                Amount = 1,
                                CurrencyID = "currencyId",
                                CostFormula = "costFormula",
                            },
                            Price = new()
                            {
                                Amount = 0,
                                Currency = PricingModelPricePeriodPriceCurrency.Usd,
                            },
                            Tiers =
                            [
                                new()
                                {
                                    FlatPrice = new()
                                    {
                                        Amount = 0,
                                        Currency = PricingModelPricePeriodTierFlatPriceCurrency.Usd,
                                    },
                                    UnitPrice = new()
                                    {
                                        Amount = 0,
                                        Currency = PricingModelPricePeriodTierUnitPriceCurrency.Usd,
                                    },
                                    UpTo = 0,
                                },
                            ],
                        },
                    ],
                    BillingCadence = PricingModelBillingCadence.Recurring,
                    FeatureID = "featureId",
                    MaxUnitQuantity = 1,
                    MinUnitQuantity = 1,
                    MonthlyResetPeriodConfiguration = new(
                        PricingModelMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    ResetPeriod = PricingModelResetPeriod.Year,
                    TiersMode = TiersMode.Volume,
                    TopUpCustomCurrencyID = "topUpCustomCurrencyId",
                    WeeklyResetPeriodConfiguration = new(
                        PricingModelWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    YearlyResetPeriodConfiguration = new(
                        PricingModelYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                },
            ],
        };

        Charges copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargesPricingTypeTest : TestBase
{
    [Theory]
    [InlineData(ChargesPricingType.Free)]
    [InlineData(ChargesPricingType.Paid)]
    [InlineData(ChargesPricingType.Custom)]
    public void Validation_Works(ChargesPricingType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargesPricingType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ChargesPricingType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ChargesPricingType.Free)]
    [InlineData(ChargesPricingType.Paid)]
    [InlineData(ChargesPricingType.Custom)]
    public void SerializationRoundtrip_Works(ChargesPricingType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargesPricingType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ChargesPricingType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ChargesPricingType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ChargesPricingType>>(
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
        var model = new MinimumSpend
        {
            BillingPeriod = BillingPeriod.Monthly,
            Minimum = new() { Amount = 0, Currency = Currency.Usd },
        };

        ApiEnum<string, BillingPeriod> expectedBillingPeriod = BillingPeriod.Monthly;
        Minimum expectedMinimum = new() { Amount = 0, Currency = Currency.Usd };

        Assert.Equal(expectedBillingPeriod, model.BillingPeriod);
        Assert.Equal(expectedMinimum, model.Minimum);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MinimumSpend
        {
            BillingPeriod = BillingPeriod.Monthly,
            Minimum = new() { Amount = 0, Currency = Currency.Usd },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MinimumSpend>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MinimumSpend
        {
            BillingPeriod = BillingPeriod.Monthly,
            Minimum = new() { Amount = 0, Currency = Currency.Usd },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MinimumSpend>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, BillingPeriod> expectedBillingPeriod = BillingPeriod.Monthly;
        Minimum expectedMinimum = new() { Amount = 0, Currency = Currency.Usd };

        Assert.Equal(expectedBillingPeriod, deserialized.BillingPeriod);
        Assert.Equal(expectedMinimum, deserialized.Minimum);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MinimumSpend
        {
            BillingPeriod = BillingPeriod.Monthly,
            Minimum = new() { Amount = 0, Currency = Currency.Usd },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MinimumSpend
        {
            BillingPeriod = BillingPeriod.Monthly,
            Minimum = new() { Amount = 0, Currency = Currency.Usd },
        };

        MinimumSpend copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BillingPeriodTest : TestBase
{
    [Theory]
    [InlineData(BillingPeriod.Monthly)]
    [InlineData(BillingPeriod.Annually)]
    public void Validation_Works(BillingPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BillingPeriod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BillingPeriod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BillingPeriod.Monthly)]
    [InlineData(BillingPeriod.Annually)]
    public void SerializationRoundtrip_Works(BillingPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BillingPeriod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BillingPeriod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BillingPeriod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BillingPeriod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class MinimumTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Minimum { Amount = 0, Currency = Currency.Usd };

        double expectedAmount = 0;
        ApiEnum<string, Currency> expectedCurrency = Currency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Minimum { Amount = 0, Currency = Currency.Usd };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Minimum>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Minimum { Amount = 0, Currency = Currency.Usd };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Minimum>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        ApiEnum<string, Currency> expectedCurrency = Currency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Minimum { Amount = 0, Currency = Currency.Usd };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Minimum { Amount = 0 };

        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Minimum { Amount = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Minimum
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
        var model = new Minimum
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
        var model = new Minimum { Amount = 0, Currency = Currency.Usd };

        Minimum copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CurrencyTest : TestBase
{
    [Theory]
    [InlineData(Currency.Usd)]
    [InlineData(Currency.Aed)]
    [InlineData(Currency.All)]
    [InlineData(Currency.Amd)]
    [InlineData(Currency.Ang)]
    [InlineData(Currency.Aud)]
    [InlineData(Currency.Awg)]
    [InlineData(Currency.Azn)]
    [InlineData(Currency.Bam)]
    [InlineData(Currency.Bbd)]
    [InlineData(Currency.Bdt)]
    [InlineData(Currency.Bgn)]
    [InlineData(Currency.Bif)]
    [InlineData(Currency.Bmd)]
    [InlineData(Currency.Bnd)]
    [InlineData(Currency.Bsd)]
    [InlineData(Currency.Bwp)]
    [InlineData(Currency.Byn)]
    [InlineData(Currency.Bzd)]
    [InlineData(Currency.Brl)]
    [InlineData(Currency.Cad)]
    [InlineData(Currency.Cdf)]
    [InlineData(Currency.Chf)]
    [InlineData(Currency.Cny)]
    [InlineData(Currency.Czk)]
    [InlineData(Currency.Dkk)]
    [InlineData(Currency.Dop)]
    [InlineData(Currency.Dzd)]
    [InlineData(Currency.Egp)]
    [InlineData(Currency.Etb)]
    [InlineData(Currency.Eur)]
    [InlineData(Currency.Fjd)]
    [InlineData(Currency.Gbp)]
    [InlineData(Currency.Gel)]
    [InlineData(Currency.Gip)]
    [InlineData(Currency.Gmd)]
    [InlineData(Currency.Gyd)]
    [InlineData(Currency.Hkd)]
    [InlineData(Currency.Hrk)]
    [InlineData(Currency.Htg)]
    [InlineData(Currency.Idr)]
    [InlineData(Currency.Ils)]
    [InlineData(Currency.Inr)]
    [InlineData(Currency.Isk)]
    [InlineData(Currency.Jmd)]
    [InlineData(Currency.Jpy)]
    [InlineData(Currency.Kes)]
    [InlineData(Currency.Kgs)]
    [InlineData(Currency.Khr)]
    [InlineData(Currency.Kmf)]
    [InlineData(Currency.Krw)]
    [InlineData(Currency.Kyd)]
    [InlineData(Currency.Kzt)]
    [InlineData(Currency.Lbp)]
    [InlineData(Currency.Lkr)]
    [InlineData(Currency.Lrd)]
    [InlineData(Currency.Lsl)]
    [InlineData(Currency.Mad)]
    [InlineData(Currency.Mdl)]
    [InlineData(Currency.Mga)]
    [InlineData(Currency.Mkd)]
    [InlineData(Currency.Mmk)]
    [InlineData(Currency.Mnt)]
    [InlineData(Currency.Mop)]
    [InlineData(Currency.Mro)]
    [InlineData(Currency.Mvr)]
    [InlineData(Currency.Mwk)]
    [InlineData(Currency.Mxn)]
    [InlineData(Currency.Myr)]
    [InlineData(Currency.Mzn)]
    [InlineData(Currency.Nad)]
    [InlineData(Currency.Ngn)]
    [InlineData(Currency.Nok)]
    [InlineData(Currency.Npr)]
    [InlineData(Currency.Nzd)]
    [InlineData(Currency.Pgk)]
    [InlineData(Currency.Php)]
    [InlineData(Currency.Pkr)]
    [InlineData(Currency.Pln)]
    [InlineData(Currency.Qar)]
    [InlineData(Currency.Ron)]
    [InlineData(Currency.Rsd)]
    [InlineData(Currency.Rub)]
    [InlineData(Currency.Rwf)]
    [InlineData(Currency.Sar)]
    [InlineData(Currency.Sbd)]
    [InlineData(Currency.Scr)]
    [InlineData(Currency.Sek)]
    [InlineData(Currency.Sgd)]
    [InlineData(Currency.Sle)]
    [InlineData(Currency.Sll)]
    [InlineData(Currency.Sos)]
    [InlineData(Currency.Szl)]
    [InlineData(Currency.Thb)]
    [InlineData(Currency.Tjs)]
    [InlineData(Currency.Top)]
    [InlineData(Currency.Try)]
    [InlineData(Currency.Ttd)]
    [InlineData(Currency.Tzs)]
    [InlineData(Currency.Uah)]
    [InlineData(Currency.Uzs)]
    [InlineData(Currency.Vnd)]
    [InlineData(Currency.Vuv)]
    [InlineData(Currency.Wst)]
    [InlineData(Currency.Xaf)]
    [InlineData(Currency.Xcd)]
    [InlineData(Currency.Yer)]
    [InlineData(Currency.Zar)]
    [InlineData(Currency.Zmw)]
    [InlineData(Currency.Clp)]
    [InlineData(Currency.Djf)]
    [InlineData(Currency.Gnf)]
    [InlineData(Currency.Ugx)]
    [InlineData(Currency.Pyg)]
    [InlineData(Currency.Xof)]
    [InlineData(Currency.Xpf)]
    public void Validation_Works(Currency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Currency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Currency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Currency.Usd)]
    [InlineData(Currency.Aed)]
    [InlineData(Currency.All)]
    [InlineData(Currency.Amd)]
    [InlineData(Currency.Ang)]
    [InlineData(Currency.Aud)]
    [InlineData(Currency.Awg)]
    [InlineData(Currency.Azn)]
    [InlineData(Currency.Bam)]
    [InlineData(Currency.Bbd)]
    [InlineData(Currency.Bdt)]
    [InlineData(Currency.Bgn)]
    [InlineData(Currency.Bif)]
    [InlineData(Currency.Bmd)]
    [InlineData(Currency.Bnd)]
    [InlineData(Currency.Bsd)]
    [InlineData(Currency.Bwp)]
    [InlineData(Currency.Byn)]
    [InlineData(Currency.Bzd)]
    [InlineData(Currency.Brl)]
    [InlineData(Currency.Cad)]
    [InlineData(Currency.Cdf)]
    [InlineData(Currency.Chf)]
    [InlineData(Currency.Cny)]
    [InlineData(Currency.Czk)]
    [InlineData(Currency.Dkk)]
    [InlineData(Currency.Dop)]
    [InlineData(Currency.Dzd)]
    [InlineData(Currency.Egp)]
    [InlineData(Currency.Etb)]
    [InlineData(Currency.Eur)]
    [InlineData(Currency.Fjd)]
    [InlineData(Currency.Gbp)]
    [InlineData(Currency.Gel)]
    [InlineData(Currency.Gip)]
    [InlineData(Currency.Gmd)]
    [InlineData(Currency.Gyd)]
    [InlineData(Currency.Hkd)]
    [InlineData(Currency.Hrk)]
    [InlineData(Currency.Htg)]
    [InlineData(Currency.Idr)]
    [InlineData(Currency.Ils)]
    [InlineData(Currency.Inr)]
    [InlineData(Currency.Isk)]
    [InlineData(Currency.Jmd)]
    [InlineData(Currency.Jpy)]
    [InlineData(Currency.Kes)]
    [InlineData(Currency.Kgs)]
    [InlineData(Currency.Khr)]
    [InlineData(Currency.Kmf)]
    [InlineData(Currency.Krw)]
    [InlineData(Currency.Kyd)]
    [InlineData(Currency.Kzt)]
    [InlineData(Currency.Lbp)]
    [InlineData(Currency.Lkr)]
    [InlineData(Currency.Lrd)]
    [InlineData(Currency.Lsl)]
    [InlineData(Currency.Mad)]
    [InlineData(Currency.Mdl)]
    [InlineData(Currency.Mga)]
    [InlineData(Currency.Mkd)]
    [InlineData(Currency.Mmk)]
    [InlineData(Currency.Mnt)]
    [InlineData(Currency.Mop)]
    [InlineData(Currency.Mro)]
    [InlineData(Currency.Mvr)]
    [InlineData(Currency.Mwk)]
    [InlineData(Currency.Mxn)]
    [InlineData(Currency.Myr)]
    [InlineData(Currency.Mzn)]
    [InlineData(Currency.Nad)]
    [InlineData(Currency.Ngn)]
    [InlineData(Currency.Nok)]
    [InlineData(Currency.Npr)]
    [InlineData(Currency.Nzd)]
    [InlineData(Currency.Pgk)]
    [InlineData(Currency.Php)]
    [InlineData(Currency.Pkr)]
    [InlineData(Currency.Pln)]
    [InlineData(Currency.Qar)]
    [InlineData(Currency.Ron)]
    [InlineData(Currency.Rsd)]
    [InlineData(Currency.Rub)]
    [InlineData(Currency.Rwf)]
    [InlineData(Currency.Sar)]
    [InlineData(Currency.Sbd)]
    [InlineData(Currency.Scr)]
    [InlineData(Currency.Sek)]
    [InlineData(Currency.Sgd)]
    [InlineData(Currency.Sle)]
    [InlineData(Currency.Sll)]
    [InlineData(Currency.Sos)]
    [InlineData(Currency.Szl)]
    [InlineData(Currency.Thb)]
    [InlineData(Currency.Tjs)]
    [InlineData(Currency.Top)]
    [InlineData(Currency.Try)]
    [InlineData(Currency.Ttd)]
    [InlineData(Currency.Tzs)]
    [InlineData(Currency.Uah)]
    [InlineData(Currency.Uzs)]
    [InlineData(Currency.Vnd)]
    [InlineData(Currency.Vuv)]
    [InlineData(Currency.Wst)]
    [InlineData(Currency.Xaf)]
    [InlineData(Currency.Xcd)]
    [InlineData(Currency.Yer)]
    [InlineData(Currency.Zar)]
    [InlineData(Currency.Zmw)]
    [InlineData(Currency.Clp)]
    [InlineData(Currency.Djf)]
    [InlineData(Currency.Gnf)]
    [InlineData(Currency.Ugx)]
    [InlineData(Currency.Pyg)]
    [InlineData(Currency.Xof)]
    [InlineData(Currency.Xpf)]
    public void SerializationRoundtrip_Works(Currency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Currency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Currency>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Currency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Currency>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class OverageBillingPeriodTest : TestBase
{
    [Theory]
    [InlineData(OverageBillingPeriod.OnSubscriptionRenewal)]
    [InlineData(OverageBillingPeriod.Monthly)]
    public void Validation_Works(OverageBillingPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OverageBillingPeriod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OverageBillingPeriod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(OverageBillingPeriod.OnSubscriptionRenewal)]
    [InlineData(OverageBillingPeriod.Monthly)]
    public void SerializationRoundtrip_Works(OverageBillingPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OverageBillingPeriod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, OverageBillingPeriod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OverageBillingPeriod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, OverageBillingPeriod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class OveragePricingModelTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OveragePricingModel
        {
            BillingModel = BillingModel.FlatFee,
            PricePeriods =
            [
                new()
                {
                    BillingPeriod = PricePeriodBillingPeriod.Monthly,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    CreditGrantCadence = CreditGrantCadence.BeginningOfBillingPeriod,
                    CreditRate = new()
                    {
                        Amount = 1,
                        CurrencyID = "currencyId",
                        CostFormula = "costFormula",
                    },
                    Price = new() { Amount = 0, Currency = PriceCurrency.Usd },
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
            BillingCadence = BillingCadence.Recurring,
            Entitlement = new()
            {
                FeatureID = "featureId",
                HasSoftLimit = true,
                HasUnlimitedUsage = true,
                MonthlyResetPeriodConfiguration = new(AccordingTo.SubscriptionStart),
                ResetPeriod = ResetPeriod.Year,
                UsageLimit = 0,
                WeeklyResetPeriodConfiguration = new(
                    WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
                YearlyResetPeriodConfiguration = new(
                    YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
            },
            FeatureID = "featureId",
            TopUpCustomCurrencyID = "topUpCustomCurrencyId",
        };

        ApiEnum<string, BillingModel> expectedBillingModel = BillingModel.FlatFee;
        List<PricePeriod> expectedPricePeriods =
        [
            new()
            {
                BillingPeriod = PricePeriodBillingPeriod.Monthly,
                BillingCountryCode = "billingCountryCode",
                BlockSize = 0,
                CreditGrantCadence = CreditGrantCadence.BeginningOfBillingPeriod,
                CreditRate = new()
                {
                    Amount = 1,
                    CurrencyID = "currencyId",
                    CostFormula = "costFormula",
                },
                Price = new() { Amount = 0, Currency = PriceCurrency.Usd },
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
        ApiEnum<string, BillingCadence> expectedBillingCadence = BillingCadence.Recurring;
        Entitlement expectedEntitlement = new()
        {
            FeatureID = "featureId",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            MonthlyResetPeriodConfiguration = new(AccordingTo.SubscriptionStart),
            ResetPeriod = ResetPeriod.Year,
            UsageLimit = 0,
            WeeklyResetPeriodConfiguration = new(
                WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };
        string expectedFeatureID = "featureId";
        string expectedTopUpCustomCurrencyID = "topUpCustomCurrencyId";

        Assert.Equal(expectedBillingModel, model.BillingModel);
        Assert.Equal(expectedPricePeriods.Count, model.PricePeriods.Count);
        for (int i = 0; i < expectedPricePeriods.Count; i++)
        {
            Assert.Equal(expectedPricePeriods[i], model.PricePeriods[i]);
        }
        Assert.Equal(expectedBillingCadence, model.BillingCadence);
        Assert.Equal(expectedEntitlement, model.Entitlement);
        Assert.Equal(expectedFeatureID, model.FeatureID);
        Assert.Equal(expectedTopUpCustomCurrencyID, model.TopUpCustomCurrencyID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OveragePricingModel
        {
            BillingModel = BillingModel.FlatFee,
            PricePeriods =
            [
                new()
                {
                    BillingPeriod = PricePeriodBillingPeriod.Monthly,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    CreditGrantCadence = CreditGrantCadence.BeginningOfBillingPeriod,
                    CreditRate = new()
                    {
                        Amount = 1,
                        CurrencyID = "currencyId",
                        CostFormula = "costFormula",
                    },
                    Price = new() { Amount = 0, Currency = PriceCurrency.Usd },
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
            BillingCadence = BillingCadence.Recurring,
            Entitlement = new()
            {
                FeatureID = "featureId",
                HasSoftLimit = true,
                HasUnlimitedUsage = true,
                MonthlyResetPeriodConfiguration = new(AccordingTo.SubscriptionStart),
                ResetPeriod = ResetPeriod.Year,
                UsageLimit = 0,
                WeeklyResetPeriodConfiguration = new(
                    WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
                YearlyResetPeriodConfiguration = new(
                    YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
            },
            FeatureID = "featureId",
            TopUpCustomCurrencyID = "topUpCustomCurrencyId",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OveragePricingModel>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OveragePricingModel
        {
            BillingModel = BillingModel.FlatFee,
            PricePeriods =
            [
                new()
                {
                    BillingPeriod = PricePeriodBillingPeriod.Monthly,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    CreditGrantCadence = CreditGrantCadence.BeginningOfBillingPeriod,
                    CreditRate = new()
                    {
                        Amount = 1,
                        CurrencyID = "currencyId",
                        CostFormula = "costFormula",
                    },
                    Price = new() { Amount = 0, Currency = PriceCurrency.Usd },
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
            BillingCadence = BillingCadence.Recurring,
            Entitlement = new()
            {
                FeatureID = "featureId",
                HasSoftLimit = true,
                HasUnlimitedUsage = true,
                MonthlyResetPeriodConfiguration = new(AccordingTo.SubscriptionStart),
                ResetPeriod = ResetPeriod.Year,
                UsageLimit = 0,
                WeeklyResetPeriodConfiguration = new(
                    WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
                YearlyResetPeriodConfiguration = new(
                    YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
            },
            FeatureID = "featureId",
            TopUpCustomCurrencyID = "topUpCustomCurrencyId",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OveragePricingModel>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, BillingModel> expectedBillingModel = BillingModel.FlatFee;
        List<PricePeriod> expectedPricePeriods =
        [
            new()
            {
                BillingPeriod = PricePeriodBillingPeriod.Monthly,
                BillingCountryCode = "billingCountryCode",
                BlockSize = 0,
                CreditGrantCadence = CreditGrantCadence.BeginningOfBillingPeriod,
                CreditRate = new()
                {
                    Amount = 1,
                    CurrencyID = "currencyId",
                    CostFormula = "costFormula",
                },
                Price = new() { Amount = 0, Currency = PriceCurrency.Usd },
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
        ApiEnum<string, BillingCadence> expectedBillingCadence = BillingCadence.Recurring;
        Entitlement expectedEntitlement = new()
        {
            FeatureID = "featureId",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            MonthlyResetPeriodConfiguration = new(AccordingTo.SubscriptionStart),
            ResetPeriod = ResetPeriod.Year,
            UsageLimit = 0,
            WeeklyResetPeriodConfiguration = new(
                WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };
        string expectedFeatureID = "featureId";
        string expectedTopUpCustomCurrencyID = "topUpCustomCurrencyId";

        Assert.Equal(expectedBillingModel, deserialized.BillingModel);
        Assert.Equal(expectedPricePeriods.Count, deserialized.PricePeriods.Count);
        for (int i = 0; i < expectedPricePeriods.Count; i++)
        {
            Assert.Equal(expectedPricePeriods[i], deserialized.PricePeriods[i]);
        }
        Assert.Equal(expectedBillingCadence, deserialized.BillingCadence);
        Assert.Equal(expectedEntitlement, deserialized.Entitlement);
        Assert.Equal(expectedFeatureID, deserialized.FeatureID);
        Assert.Equal(expectedTopUpCustomCurrencyID, deserialized.TopUpCustomCurrencyID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new OveragePricingModel
        {
            BillingModel = BillingModel.FlatFee,
            PricePeriods =
            [
                new()
                {
                    BillingPeriod = PricePeriodBillingPeriod.Monthly,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    CreditGrantCadence = CreditGrantCadence.BeginningOfBillingPeriod,
                    CreditRate = new()
                    {
                        Amount = 1,
                        CurrencyID = "currencyId",
                        CostFormula = "costFormula",
                    },
                    Price = new() { Amount = 0, Currency = PriceCurrency.Usd },
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
            BillingCadence = BillingCadence.Recurring,
            Entitlement = new()
            {
                FeatureID = "featureId",
                HasSoftLimit = true,
                HasUnlimitedUsage = true,
                MonthlyResetPeriodConfiguration = new(AccordingTo.SubscriptionStart),
                ResetPeriod = ResetPeriod.Year,
                UsageLimit = 0,
                WeeklyResetPeriodConfiguration = new(
                    WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
                YearlyResetPeriodConfiguration = new(
                    YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
            },
            FeatureID = "featureId",
            TopUpCustomCurrencyID = "topUpCustomCurrencyId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new OveragePricingModel
        {
            BillingModel = BillingModel.FlatFee,
            PricePeriods =
            [
                new()
                {
                    BillingPeriod = PricePeriodBillingPeriod.Monthly,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    CreditGrantCadence = CreditGrantCadence.BeginningOfBillingPeriod,
                    CreditRate = new()
                    {
                        Amount = 1,
                        CurrencyID = "currencyId",
                        CostFormula = "costFormula",
                    },
                    Price = new() { Amount = 0, Currency = PriceCurrency.Usd },
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
        };

        Assert.Null(model.BillingCadence);
        Assert.False(model.RawData.ContainsKey("billingCadence"));
        Assert.Null(model.Entitlement);
        Assert.False(model.RawData.ContainsKey("entitlement"));
        Assert.Null(model.FeatureID);
        Assert.False(model.RawData.ContainsKey("featureId"));
        Assert.Null(model.TopUpCustomCurrencyID);
        Assert.False(model.RawData.ContainsKey("topUpCustomCurrencyId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new OveragePricingModel
        {
            BillingModel = BillingModel.FlatFee,
            PricePeriods =
            [
                new()
                {
                    BillingPeriod = PricePeriodBillingPeriod.Monthly,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    CreditGrantCadence = CreditGrantCadence.BeginningOfBillingPeriod,
                    CreditRate = new()
                    {
                        Amount = 1,
                        CurrencyID = "currencyId",
                        CostFormula = "costFormula",
                    },
                    Price = new() { Amount = 0, Currency = PriceCurrency.Usd },
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new OveragePricingModel
        {
            BillingModel = BillingModel.FlatFee,
            PricePeriods =
            [
                new()
                {
                    BillingPeriod = PricePeriodBillingPeriod.Monthly,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    CreditGrantCadence = CreditGrantCadence.BeginningOfBillingPeriod,
                    CreditRate = new()
                    {
                        Amount = 1,
                        CurrencyID = "currencyId",
                        CostFormula = "costFormula",
                    },
                    Price = new() { Amount = 0, Currency = PriceCurrency.Usd },
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

            // Null should be interpreted as omitted for these properties
            BillingCadence = null,
            Entitlement = null,
            FeatureID = null,
            TopUpCustomCurrencyID = null,
        };

        Assert.Null(model.BillingCadence);
        Assert.False(model.RawData.ContainsKey("billingCadence"));
        Assert.Null(model.Entitlement);
        Assert.False(model.RawData.ContainsKey("entitlement"));
        Assert.Null(model.FeatureID);
        Assert.False(model.RawData.ContainsKey("featureId"));
        Assert.Null(model.TopUpCustomCurrencyID);
        Assert.False(model.RawData.ContainsKey("topUpCustomCurrencyId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new OveragePricingModel
        {
            BillingModel = BillingModel.FlatFee,
            PricePeriods =
            [
                new()
                {
                    BillingPeriod = PricePeriodBillingPeriod.Monthly,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    CreditGrantCadence = CreditGrantCadence.BeginningOfBillingPeriod,
                    CreditRate = new()
                    {
                        Amount = 1,
                        CurrencyID = "currencyId",
                        CostFormula = "costFormula",
                    },
                    Price = new() { Amount = 0, Currency = PriceCurrency.Usd },
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

            // Null should be interpreted as omitted for these properties
            BillingCadence = null,
            Entitlement = null,
            FeatureID = null,
            TopUpCustomCurrencyID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OveragePricingModel
        {
            BillingModel = BillingModel.FlatFee,
            PricePeriods =
            [
                new()
                {
                    BillingPeriod = PricePeriodBillingPeriod.Monthly,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    CreditGrantCadence = CreditGrantCadence.BeginningOfBillingPeriod,
                    CreditRate = new()
                    {
                        Amount = 1,
                        CurrencyID = "currencyId",
                        CostFormula = "costFormula",
                    },
                    Price = new() { Amount = 0, Currency = PriceCurrency.Usd },
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
            BillingCadence = BillingCadence.Recurring,
            Entitlement = new()
            {
                FeatureID = "featureId",
                HasSoftLimit = true,
                HasUnlimitedUsage = true,
                MonthlyResetPeriodConfiguration = new(AccordingTo.SubscriptionStart),
                ResetPeriod = ResetPeriod.Year,
                UsageLimit = 0,
                WeeklyResetPeriodConfiguration = new(
                    WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
                YearlyResetPeriodConfiguration = new(
                    YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
            },
            FeatureID = "featureId",
            TopUpCustomCurrencyID = "topUpCustomCurrencyId",
        };

        OveragePricingModel copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BillingModelTest : TestBase
{
    [Theory]
    [InlineData(BillingModel.FlatFee)]
    [InlineData(BillingModel.MinimumSpend)]
    [InlineData(BillingModel.PerUnit)]
    [InlineData(BillingModel.UsageBased)]
    [InlineData(BillingModel.CreditBased)]
    public void Validation_Works(BillingModel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BillingModel> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BillingModel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BillingModel.FlatFee)]
    [InlineData(BillingModel.MinimumSpend)]
    [InlineData(BillingModel.PerUnit)]
    [InlineData(BillingModel.UsageBased)]
    [InlineData(BillingModel.CreditBased)]
    public void SerializationRoundtrip_Works(BillingModel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BillingModel> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BillingModel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BillingModel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BillingModel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PricePeriodTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PricePeriod
        {
            BillingPeriod = PricePeriodBillingPeriod.Monthly,
            BillingCountryCode = "billingCountryCode",
            BlockSize = 0,
            CreditGrantCadence = CreditGrantCadence.BeginningOfBillingPeriod,
            CreditRate = new()
            {
                Amount = 1,
                CurrencyID = "currencyId",
                CostFormula = "costFormula",
            },
            Price = new() { Amount = 0, Currency = PriceCurrency.Usd },
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

        ApiEnum<string, PricePeriodBillingPeriod> expectedBillingPeriod =
            PricePeriodBillingPeriod.Monthly;
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
        Price expectedPrice = new() { Amount = 0, Currency = PriceCurrency.Usd };
        List<Tier> expectedTiers =
        [
            new()
            {
                FlatPrice = new() { Amount = 0, Currency = FlatPriceCurrency.Usd },
                UnitPrice = new() { Amount = 0, Currency = UnitPriceCurrency.Usd },
                UpTo = 0,
            },
        ];

        Assert.Equal(expectedBillingPeriod, model.BillingPeriod);
        Assert.Equal(expectedBillingCountryCode, model.BillingCountryCode);
        Assert.Equal(expectedBlockSize, model.BlockSize);
        Assert.Equal(expectedCreditGrantCadence, model.CreditGrantCadence);
        Assert.Equal(expectedCreditRate, model.CreditRate);
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
        var model = new PricePeriod
        {
            BillingPeriod = PricePeriodBillingPeriod.Monthly,
            BillingCountryCode = "billingCountryCode",
            BlockSize = 0,
            CreditGrantCadence = CreditGrantCadence.BeginningOfBillingPeriod,
            CreditRate = new()
            {
                Amount = 1,
                CurrencyID = "currencyId",
                CostFormula = "costFormula",
            },
            Price = new() { Amount = 0, Currency = PriceCurrency.Usd },
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
        var deserialized = JsonSerializer.Deserialize<PricePeriod>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PricePeriod
        {
            BillingPeriod = PricePeriodBillingPeriod.Monthly,
            BillingCountryCode = "billingCountryCode",
            BlockSize = 0,
            CreditGrantCadence = CreditGrantCadence.BeginningOfBillingPeriod,
            CreditRate = new()
            {
                Amount = 1,
                CurrencyID = "currencyId",
                CostFormula = "costFormula",
            },
            Price = new() { Amount = 0, Currency = PriceCurrency.Usd },
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
        var deserialized = JsonSerializer.Deserialize<PricePeriod>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, PricePeriodBillingPeriod> expectedBillingPeriod =
            PricePeriodBillingPeriod.Monthly;
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
        Price expectedPrice = new() { Amount = 0, Currency = PriceCurrency.Usd };
        List<Tier> expectedTiers =
        [
            new()
            {
                FlatPrice = new() { Amount = 0, Currency = FlatPriceCurrency.Usd },
                UnitPrice = new() { Amount = 0, Currency = UnitPriceCurrency.Usd },
                UpTo = 0,
            },
        ];

        Assert.Equal(expectedBillingPeriod, deserialized.BillingPeriod);
        Assert.Equal(expectedBillingCountryCode, deserialized.BillingCountryCode);
        Assert.Equal(expectedBlockSize, deserialized.BlockSize);
        Assert.Equal(expectedCreditGrantCadence, deserialized.CreditGrantCadence);
        Assert.Equal(expectedCreditRate, deserialized.CreditRate);
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
        var model = new PricePeriod
        {
            BillingPeriod = PricePeriodBillingPeriod.Monthly,
            BillingCountryCode = "billingCountryCode",
            BlockSize = 0,
            CreditGrantCadence = CreditGrantCadence.BeginningOfBillingPeriod,
            CreditRate = new()
            {
                Amount = 1,
                CurrencyID = "currencyId",
                CostFormula = "costFormula",
            },
            Price = new() { Amount = 0, Currency = PriceCurrency.Usd },
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
        var model = new PricePeriod { BillingPeriod = PricePeriodBillingPeriod.Monthly };

        Assert.Null(model.BillingCountryCode);
        Assert.False(model.RawData.ContainsKey("billingCountryCode"));
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
        var model = new PricePeriod { BillingPeriod = PricePeriodBillingPeriod.Monthly };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PricePeriod
        {
            BillingPeriod = PricePeriodBillingPeriod.Monthly,

            // Null should be interpreted as omitted for these properties
            BillingCountryCode = null,
            BlockSize = null,
            CreditGrantCadence = null,
            CreditRate = null,
            Price = null,
            Tiers = null,
        };

        Assert.Null(model.BillingCountryCode);
        Assert.False(model.RawData.ContainsKey("billingCountryCode"));
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
        var model = new PricePeriod
        {
            BillingPeriod = PricePeriodBillingPeriod.Monthly,

            // Null should be interpreted as omitted for these properties
            BillingCountryCode = null,
            BlockSize = null,
            CreditGrantCadence = null,
            CreditRate = null,
            Price = null,
            Tiers = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PricePeriod
        {
            BillingPeriod = PricePeriodBillingPeriod.Monthly,
            BillingCountryCode = "billingCountryCode",
            BlockSize = 0,
            CreditGrantCadence = CreditGrantCadence.BeginningOfBillingPeriod,
            CreditRate = new()
            {
                Amount = 1,
                CurrencyID = "currencyId",
                CostFormula = "costFormula",
            },
            Price = new() { Amount = 0, Currency = PriceCurrency.Usd },
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

        PricePeriod copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PricePeriodBillingPeriodTest : TestBase
{
    [Theory]
    [InlineData(PricePeriodBillingPeriod.Monthly)]
    [InlineData(PricePeriodBillingPeriod.Annually)]
    public void Validation_Works(PricePeriodBillingPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PricePeriodBillingPeriod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PricePeriodBillingPeriod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PricePeriodBillingPeriod.Monthly)]
    [InlineData(PricePeriodBillingPeriod.Annually)]
    public void SerializationRoundtrip_Works(PricePeriodBillingPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PricePeriodBillingPeriod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PricePeriodBillingPeriod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PricePeriodBillingPeriod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PricePeriodBillingPeriod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
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
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CreditRate { Amount = 1, CurrencyID = "currencyId" };

        Assert.Null(model.CostFormula);
        Assert.False(model.RawData.ContainsKey("costFormula"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CreditRate { Amount = 1, CurrencyID = "currencyId" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CreditRate
        {
            Amount = 1,
            CurrencyID = "currencyId",

            // Null should be interpreted as omitted for these properties
            CostFormula = null,
        };

        Assert.Null(model.CostFormula);
        Assert.False(model.RawData.ContainsKey("costFormula"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CreditRate
        {
            Amount = 1,
            CurrencyID = "currencyId",

            // Null should be interpreted as omitted for these properties
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

public class PriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Price { Amount = 0, Currency = PriceCurrency.Usd };

        double expectedAmount = 0;
        ApiEnum<string, PriceCurrency> expectedCurrency = PriceCurrency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Price { Amount = 0, Currency = PriceCurrency.Usd };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Price>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Price { Amount = 0, Currency = PriceCurrency.Usd };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Price>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        ApiEnum<string, PriceCurrency> expectedCurrency = PriceCurrency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Price { Amount = 0, Currency = PriceCurrency.Usd };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Price { Amount = 0 };

        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Price { Amount = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Price
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
        var model = new Price
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
        var model = new Price { Amount = 0, Currency = PriceCurrency.Usd };

        Price copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PriceCurrencyTest : TestBase
{
    [Theory]
    [InlineData(PriceCurrency.Usd)]
    [InlineData(PriceCurrency.Aed)]
    [InlineData(PriceCurrency.All)]
    [InlineData(PriceCurrency.Amd)]
    [InlineData(PriceCurrency.Ang)]
    [InlineData(PriceCurrency.Aud)]
    [InlineData(PriceCurrency.Awg)]
    [InlineData(PriceCurrency.Azn)]
    [InlineData(PriceCurrency.Bam)]
    [InlineData(PriceCurrency.Bbd)]
    [InlineData(PriceCurrency.Bdt)]
    [InlineData(PriceCurrency.Bgn)]
    [InlineData(PriceCurrency.Bif)]
    [InlineData(PriceCurrency.Bmd)]
    [InlineData(PriceCurrency.Bnd)]
    [InlineData(PriceCurrency.Bsd)]
    [InlineData(PriceCurrency.Bwp)]
    [InlineData(PriceCurrency.Byn)]
    [InlineData(PriceCurrency.Bzd)]
    [InlineData(PriceCurrency.Brl)]
    [InlineData(PriceCurrency.Cad)]
    [InlineData(PriceCurrency.Cdf)]
    [InlineData(PriceCurrency.Chf)]
    [InlineData(PriceCurrency.Cny)]
    [InlineData(PriceCurrency.Czk)]
    [InlineData(PriceCurrency.Dkk)]
    [InlineData(PriceCurrency.Dop)]
    [InlineData(PriceCurrency.Dzd)]
    [InlineData(PriceCurrency.Egp)]
    [InlineData(PriceCurrency.Etb)]
    [InlineData(PriceCurrency.Eur)]
    [InlineData(PriceCurrency.Fjd)]
    [InlineData(PriceCurrency.Gbp)]
    [InlineData(PriceCurrency.Gel)]
    [InlineData(PriceCurrency.Gip)]
    [InlineData(PriceCurrency.Gmd)]
    [InlineData(PriceCurrency.Gyd)]
    [InlineData(PriceCurrency.Hkd)]
    [InlineData(PriceCurrency.Hrk)]
    [InlineData(PriceCurrency.Htg)]
    [InlineData(PriceCurrency.Idr)]
    [InlineData(PriceCurrency.Ils)]
    [InlineData(PriceCurrency.Inr)]
    [InlineData(PriceCurrency.Isk)]
    [InlineData(PriceCurrency.Jmd)]
    [InlineData(PriceCurrency.Jpy)]
    [InlineData(PriceCurrency.Kes)]
    [InlineData(PriceCurrency.Kgs)]
    [InlineData(PriceCurrency.Khr)]
    [InlineData(PriceCurrency.Kmf)]
    [InlineData(PriceCurrency.Krw)]
    [InlineData(PriceCurrency.Kyd)]
    [InlineData(PriceCurrency.Kzt)]
    [InlineData(PriceCurrency.Lbp)]
    [InlineData(PriceCurrency.Lkr)]
    [InlineData(PriceCurrency.Lrd)]
    [InlineData(PriceCurrency.Lsl)]
    [InlineData(PriceCurrency.Mad)]
    [InlineData(PriceCurrency.Mdl)]
    [InlineData(PriceCurrency.Mga)]
    [InlineData(PriceCurrency.Mkd)]
    [InlineData(PriceCurrency.Mmk)]
    [InlineData(PriceCurrency.Mnt)]
    [InlineData(PriceCurrency.Mop)]
    [InlineData(PriceCurrency.Mro)]
    [InlineData(PriceCurrency.Mvr)]
    [InlineData(PriceCurrency.Mwk)]
    [InlineData(PriceCurrency.Mxn)]
    [InlineData(PriceCurrency.Myr)]
    [InlineData(PriceCurrency.Mzn)]
    [InlineData(PriceCurrency.Nad)]
    [InlineData(PriceCurrency.Ngn)]
    [InlineData(PriceCurrency.Nok)]
    [InlineData(PriceCurrency.Npr)]
    [InlineData(PriceCurrency.Nzd)]
    [InlineData(PriceCurrency.Pgk)]
    [InlineData(PriceCurrency.Php)]
    [InlineData(PriceCurrency.Pkr)]
    [InlineData(PriceCurrency.Pln)]
    [InlineData(PriceCurrency.Qar)]
    [InlineData(PriceCurrency.Ron)]
    [InlineData(PriceCurrency.Rsd)]
    [InlineData(PriceCurrency.Rub)]
    [InlineData(PriceCurrency.Rwf)]
    [InlineData(PriceCurrency.Sar)]
    [InlineData(PriceCurrency.Sbd)]
    [InlineData(PriceCurrency.Scr)]
    [InlineData(PriceCurrency.Sek)]
    [InlineData(PriceCurrency.Sgd)]
    [InlineData(PriceCurrency.Sle)]
    [InlineData(PriceCurrency.Sll)]
    [InlineData(PriceCurrency.Sos)]
    [InlineData(PriceCurrency.Szl)]
    [InlineData(PriceCurrency.Thb)]
    [InlineData(PriceCurrency.Tjs)]
    [InlineData(PriceCurrency.Top)]
    [InlineData(PriceCurrency.Try)]
    [InlineData(PriceCurrency.Ttd)]
    [InlineData(PriceCurrency.Tzs)]
    [InlineData(PriceCurrency.Uah)]
    [InlineData(PriceCurrency.Uzs)]
    [InlineData(PriceCurrency.Vnd)]
    [InlineData(PriceCurrency.Vuv)]
    [InlineData(PriceCurrency.Wst)]
    [InlineData(PriceCurrency.Xaf)]
    [InlineData(PriceCurrency.Xcd)]
    [InlineData(PriceCurrency.Yer)]
    [InlineData(PriceCurrency.Zar)]
    [InlineData(PriceCurrency.Zmw)]
    [InlineData(PriceCurrency.Clp)]
    [InlineData(PriceCurrency.Djf)]
    [InlineData(PriceCurrency.Gnf)]
    [InlineData(PriceCurrency.Ugx)]
    [InlineData(PriceCurrency.Pyg)]
    [InlineData(PriceCurrency.Xof)]
    [InlineData(PriceCurrency.Xpf)]
    public void Validation_Works(PriceCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PriceCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PriceCurrency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PriceCurrency.Usd)]
    [InlineData(PriceCurrency.Aed)]
    [InlineData(PriceCurrency.All)]
    [InlineData(PriceCurrency.Amd)]
    [InlineData(PriceCurrency.Ang)]
    [InlineData(PriceCurrency.Aud)]
    [InlineData(PriceCurrency.Awg)]
    [InlineData(PriceCurrency.Azn)]
    [InlineData(PriceCurrency.Bam)]
    [InlineData(PriceCurrency.Bbd)]
    [InlineData(PriceCurrency.Bdt)]
    [InlineData(PriceCurrency.Bgn)]
    [InlineData(PriceCurrency.Bif)]
    [InlineData(PriceCurrency.Bmd)]
    [InlineData(PriceCurrency.Bnd)]
    [InlineData(PriceCurrency.Bsd)]
    [InlineData(PriceCurrency.Bwp)]
    [InlineData(PriceCurrency.Byn)]
    [InlineData(PriceCurrency.Bzd)]
    [InlineData(PriceCurrency.Brl)]
    [InlineData(PriceCurrency.Cad)]
    [InlineData(PriceCurrency.Cdf)]
    [InlineData(PriceCurrency.Chf)]
    [InlineData(PriceCurrency.Cny)]
    [InlineData(PriceCurrency.Czk)]
    [InlineData(PriceCurrency.Dkk)]
    [InlineData(PriceCurrency.Dop)]
    [InlineData(PriceCurrency.Dzd)]
    [InlineData(PriceCurrency.Egp)]
    [InlineData(PriceCurrency.Etb)]
    [InlineData(PriceCurrency.Eur)]
    [InlineData(PriceCurrency.Fjd)]
    [InlineData(PriceCurrency.Gbp)]
    [InlineData(PriceCurrency.Gel)]
    [InlineData(PriceCurrency.Gip)]
    [InlineData(PriceCurrency.Gmd)]
    [InlineData(PriceCurrency.Gyd)]
    [InlineData(PriceCurrency.Hkd)]
    [InlineData(PriceCurrency.Hrk)]
    [InlineData(PriceCurrency.Htg)]
    [InlineData(PriceCurrency.Idr)]
    [InlineData(PriceCurrency.Ils)]
    [InlineData(PriceCurrency.Inr)]
    [InlineData(PriceCurrency.Isk)]
    [InlineData(PriceCurrency.Jmd)]
    [InlineData(PriceCurrency.Jpy)]
    [InlineData(PriceCurrency.Kes)]
    [InlineData(PriceCurrency.Kgs)]
    [InlineData(PriceCurrency.Khr)]
    [InlineData(PriceCurrency.Kmf)]
    [InlineData(PriceCurrency.Krw)]
    [InlineData(PriceCurrency.Kyd)]
    [InlineData(PriceCurrency.Kzt)]
    [InlineData(PriceCurrency.Lbp)]
    [InlineData(PriceCurrency.Lkr)]
    [InlineData(PriceCurrency.Lrd)]
    [InlineData(PriceCurrency.Lsl)]
    [InlineData(PriceCurrency.Mad)]
    [InlineData(PriceCurrency.Mdl)]
    [InlineData(PriceCurrency.Mga)]
    [InlineData(PriceCurrency.Mkd)]
    [InlineData(PriceCurrency.Mmk)]
    [InlineData(PriceCurrency.Mnt)]
    [InlineData(PriceCurrency.Mop)]
    [InlineData(PriceCurrency.Mro)]
    [InlineData(PriceCurrency.Mvr)]
    [InlineData(PriceCurrency.Mwk)]
    [InlineData(PriceCurrency.Mxn)]
    [InlineData(PriceCurrency.Myr)]
    [InlineData(PriceCurrency.Mzn)]
    [InlineData(PriceCurrency.Nad)]
    [InlineData(PriceCurrency.Ngn)]
    [InlineData(PriceCurrency.Nok)]
    [InlineData(PriceCurrency.Npr)]
    [InlineData(PriceCurrency.Nzd)]
    [InlineData(PriceCurrency.Pgk)]
    [InlineData(PriceCurrency.Php)]
    [InlineData(PriceCurrency.Pkr)]
    [InlineData(PriceCurrency.Pln)]
    [InlineData(PriceCurrency.Qar)]
    [InlineData(PriceCurrency.Ron)]
    [InlineData(PriceCurrency.Rsd)]
    [InlineData(PriceCurrency.Rub)]
    [InlineData(PriceCurrency.Rwf)]
    [InlineData(PriceCurrency.Sar)]
    [InlineData(PriceCurrency.Sbd)]
    [InlineData(PriceCurrency.Scr)]
    [InlineData(PriceCurrency.Sek)]
    [InlineData(PriceCurrency.Sgd)]
    [InlineData(PriceCurrency.Sle)]
    [InlineData(PriceCurrency.Sll)]
    [InlineData(PriceCurrency.Sos)]
    [InlineData(PriceCurrency.Szl)]
    [InlineData(PriceCurrency.Thb)]
    [InlineData(PriceCurrency.Tjs)]
    [InlineData(PriceCurrency.Top)]
    [InlineData(PriceCurrency.Try)]
    [InlineData(PriceCurrency.Ttd)]
    [InlineData(PriceCurrency.Tzs)]
    [InlineData(PriceCurrency.Uah)]
    [InlineData(PriceCurrency.Uzs)]
    [InlineData(PriceCurrency.Vnd)]
    [InlineData(PriceCurrency.Vuv)]
    [InlineData(PriceCurrency.Wst)]
    [InlineData(PriceCurrency.Xaf)]
    [InlineData(PriceCurrency.Xcd)]
    [InlineData(PriceCurrency.Yer)]
    [InlineData(PriceCurrency.Zar)]
    [InlineData(PriceCurrency.Zmw)]
    [InlineData(PriceCurrency.Clp)]
    [InlineData(PriceCurrency.Djf)]
    [InlineData(PriceCurrency.Gnf)]
    [InlineData(PriceCurrency.Ugx)]
    [InlineData(PriceCurrency.Pyg)]
    [InlineData(PriceCurrency.Xof)]
    [InlineData(PriceCurrency.Xpf)]
    public void SerializationRoundtrip_Works(PriceCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PriceCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PriceCurrency>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PriceCurrency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PriceCurrency>>(
            json,
            ModelBase.SerializerOptions
        );

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
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FlatPrice { Amount = 0 };

        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new FlatPrice { Amount = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FlatPrice
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
        var model = new FlatPrice
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
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UnitPrice { Amount = 0 };

        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new UnitPrice { Amount = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UnitPrice
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
        var model = new UnitPrice
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

public class BillingCadenceTest : TestBase
{
    [Theory]
    [InlineData(BillingCadence.Recurring)]
    [InlineData(BillingCadence.OneOff)]
    public void Validation_Works(BillingCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BillingCadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BillingCadence>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BillingCadence.Recurring)]
    [InlineData(BillingCadence.OneOff)]
    public void SerializationRoundtrip_Works(BillingCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BillingCadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BillingCadence>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BillingCadence>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BillingCadence>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class EntitlementTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Entitlement
        {
            FeatureID = "featureId",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            MonthlyResetPeriodConfiguration = new(AccordingTo.SubscriptionStart),
            ResetPeriod = ResetPeriod.Year,
            UsageLimit = 0,
            WeeklyResetPeriodConfiguration = new(
                WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };

        string expectedFeatureID = "featureId";
        bool expectedHasSoftLimit = true;
        bool expectedHasUnlimitedUsage = true;
        MonthlyResetPeriodConfiguration expectedMonthlyResetPeriodConfiguration = new(
            AccordingTo.SubscriptionStart
        );
        ApiEnum<string, ResetPeriod> expectedResetPeriod = ResetPeriod.Year;
        double expectedUsageLimit = 0;
        WeeklyResetPeriodConfiguration expectedWeeklyResetPeriodConfiguration = new(
            WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
        );
        YearlyResetPeriodConfiguration expectedYearlyResetPeriodConfiguration = new(
            YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
        );

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
        var model = new Entitlement
        {
            FeatureID = "featureId",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            MonthlyResetPeriodConfiguration = new(AccordingTo.SubscriptionStart),
            ResetPeriod = ResetPeriod.Year,
            UsageLimit = 0,
            WeeklyResetPeriodConfiguration = new(
                WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
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
            FeatureID = "featureId",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            MonthlyResetPeriodConfiguration = new(AccordingTo.SubscriptionStart),
            ResetPeriod = ResetPeriod.Year,
            UsageLimit = 0,
            WeeklyResetPeriodConfiguration = new(
                WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entitlement>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedFeatureID = "featureId";
        bool expectedHasSoftLimit = true;
        bool expectedHasUnlimitedUsage = true;
        MonthlyResetPeriodConfiguration expectedMonthlyResetPeriodConfiguration = new(
            AccordingTo.SubscriptionStart
        );
        ApiEnum<string, ResetPeriod> expectedResetPeriod = ResetPeriod.Year;
        double expectedUsageLimit = 0;
        WeeklyResetPeriodConfiguration expectedWeeklyResetPeriodConfiguration = new(
            WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
        );
        YearlyResetPeriodConfiguration expectedYearlyResetPeriodConfiguration = new(
            YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
        );

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
        var model = new Entitlement
        {
            FeatureID = "featureId",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            MonthlyResetPeriodConfiguration = new(AccordingTo.SubscriptionStart),
            ResetPeriod = ResetPeriod.Year,
            UsageLimit = 0,
            WeeklyResetPeriodConfiguration = new(
                WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Entitlement { FeatureID = "featureId" };

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
        var model = new Entitlement { FeatureID = "featureId" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Entitlement
        {
            FeatureID = "featureId",

            // Null should be interpreted as omitted for these properties
            HasSoftLimit = null,
            HasUnlimitedUsage = null,
            MonthlyResetPeriodConfiguration = null,
            ResetPeriod = null,
            UsageLimit = null,
            WeeklyResetPeriodConfiguration = null,
            YearlyResetPeriodConfiguration = null,
        };

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
        var model = new Entitlement
        {
            FeatureID = "featureId",

            // Null should be interpreted as omitted for these properties
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
        var model = new Entitlement
        {
            FeatureID = "featureId",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            MonthlyResetPeriodConfiguration = new(AccordingTo.SubscriptionStart),
            ResetPeriod = ResetPeriod.Year,
            UsageLimit = 0,
            WeeklyResetPeriodConfiguration = new(
                WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };

        Entitlement copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MonthlyResetPeriodConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MonthlyResetPeriodConfiguration
        {
            AccordingTo = AccordingTo.SubscriptionStart,
        };

        ApiEnum<string, AccordingTo> expectedAccordingTo = AccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, model.AccordingTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MonthlyResetPeriodConfiguration
        {
            AccordingTo = AccordingTo.SubscriptionStart,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MonthlyResetPeriodConfiguration>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MonthlyResetPeriodConfiguration
        {
            AccordingTo = AccordingTo.SubscriptionStart,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MonthlyResetPeriodConfiguration>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, AccordingTo> expectedAccordingTo = AccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, deserialized.AccordingTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MonthlyResetPeriodConfiguration
        {
            AccordingTo = AccordingTo.SubscriptionStart,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MonthlyResetPeriodConfiguration
        {
            AccordingTo = AccordingTo.SubscriptionStart,
        };

        MonthlyResetPeriodConfiguration copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AccordingToTest : TestBase
{
    [Theory]
    [InlineData(AccordingTo.SubscriptionStart)]
    [InlineData(AccordingTo.StartOfTheMonth)]
    public void Validation_Works(AccordingTo rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccordingTo> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AccordingTo>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AccordingTo.SubscriptionStart)]
    [InlineData(AccordingTo.StartOfTheMonth)]
    public void SerializationRoundtrip_Works(AccordingTo rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccordingTo> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AccordingTo>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AccordingTo>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AccordingTo>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
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

public class WeeklyResetPeriodConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WeeklyResetPeriodConfiguration
        {
            AccordingTo = WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        ApiEnum<string, WeeklyResetPeriodConfigurationAccordingTo> expectedAccordingTo =
            WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, model.AccordingTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WeeklyResetPeriodConfiguration
        {
            AccordingTo = WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WeeklyResetPeriodConfiguration>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WeeklyResetPeriodConfiguration
        {
            AccordingTo = WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WeeklyResetPeriodConfiguration>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, WeeklyResetPeriodConfigurationAccordingTo> expectedAccordingTo =
            WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, deserialized.AccordingTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WeeklyResetPeriodConfiguration
        {
            AccordingTo = WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WeeklyResetPeriodConfiguration
        {
            AccordingTo = WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        WeeklyResetPeriodConfiguration copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WeeklyResetPeriodConfigurationAccordingToTest : TestBase
{
    [Theory]
    [InlineData(WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart)]
    [InlineData(WeeklyResetPeriodConfigurationAccordingTo.EverySunday)]
    [InlineData(WeeklyResetPeriodConfigurationAccordingTo.EveryMonday)]
    [InlineData(WeeklyResetPeriodConfigurationAccordingTo.EveryTuesday)]
    [InlineData(WeeklyResetPeriodConfigurationAccordingTo.EveryWednesday)]
    [InlineData(WeeklyResetPeriodConfigurationAccordingTo.EveryThursday)]
    [InlineData(WeeklyResetPeriodConfigurationAccordingTo.EveryFriday)]
    [InlineData(WeeklyResetPeriodConfigurationAccordingTo.EverySaturday)]
    public void Validation_Works(WeeklyResetPeriodConfigurationAccordingTo rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WeeklyResetPeriodConfigurationAccordingTo> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, WeeklyResetPeriodConfigurationAccordingTo>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart)]
    [InlineData(WeeklyResetPeriodConfigurationAccordingTo.EverySunday)]
    [InlineData(WeeklyResetPeriodConfigurationAccordingTo.EveryMonday)]
    [InlineData(WeeklyResetPeriodConfigurationAccordingTo.EveryTuesday)]
    [InlineData(WeeklyResetPeriodConfigurationAccordingTo.EveryWednesday)]
    [InlineData(WeeklyResetPeriodConfigurationAccordingTo.EveryThursday)]
    [InlineData(WeeklyResetPeriodConfigurationAccordingTo.EveryFriday)]
    [InlineData(WeeklyResetPeriodConfigurationAccordingTo.EverySaturday)]
    public void SerializationRoundtrip_Works(WeeklyResetPeriodConfigurationAccordingTo rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WeeklyResetPeriodConfigurationAccordingTo> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, WeeklyResetPeriodConfigurationAccordingTo>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, WeeklyResetPeriodConfigurationAccordingTo>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, WeeklyResetPeriodConfigurationAccordingTo>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class YearlyResetPeriodConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new YearlyResetPeriodConfiguration
        {
            AccordingTo = YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        ApiEnum<string, YearlyResetPeriodConfigurationAccordingTo> expectedAccordingTo =
            YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, model.AccordingTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new YearlyResetPeriodConfiguration
        {
            AccordingTo = YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<YearlyResetPeriodConfiguration>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new YearlyResetPeriodConfiguration
        {
            AccordingTo = YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<YearlyResetPeriodConfiguration>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, YearlyResetPeriodConfigurationAccordingTo> expectedAccordingTo =
            YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, deserialized.AccordingTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new YearlyResetPeriodConfiguration
        {
            AccordingTo = YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new YearlyResetPeriodConfiguration
        {
            AccordingTo = YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        YearlyResetPeriodConfiguration copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class YearlyResetPeriodConfigurationAccordingToTest : TestBase
{
    [Theory]
    [InlineData(YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart)]
    public void Validation_Works(YearlyResetPeriodConfigurationAccordingTo rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, YearlyResetPeriodConfigurationAccordingTo> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, YearlyResetPeriodConfigurationAccordingTo>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart)]
    public void SerializationRoundtrip_Works(YearlyResetPeriodConfigurationAccordingTo rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, YearlyResetPeriodConfigurationAccordingTo> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, YearlyResetPeriodConfigurationAccordingTo>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, YearlyResetPeriodConfigurationAccordingTo>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, YearlyResetPeriodConfigurationAccordingTo>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PricingModelTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PricingModel
        {
            BillingModel = PricingModelBillingModel.FlatFee,
            PricePeriods =
            [
                new()
                {
                    BillingPeriod = PricingModelPricePeriodBillingPeriod.Monthly,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    CreditGrantCadence =
                        PricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                    CreditRate = new()
                    {
                        Amount = 1,
                        CurrencyID = "currencyId",
                        CostFormula = "costFormula",
                    },
                    Price = new()
                    {
                        Amount = 0,
                        Currency = PricingModelPricePeriodPriceCurrency.Usd,
                    },
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency = PricingModelPricePeriodTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency = PricingModelPricePeriodTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            BillingCadence = PricingModelBillingCadence.Recurring,
            FeatureID = "featureId",
            MaxUnitQuantity = 1,
            MinUnitQuantity = 1,
            MonthlyResetPeriodConfiguration = new(
                PricingModelMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            ResetPeriod = PricingModelResetPeriod.Year,
            TiersMode = TiersMode.Volume,
            TopUpCustomCurrencyID = "topUpCustomCurrencyId",
            WeeklyResetPeriodConfiguration = new(
                PricingModelWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                PricingModelYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };

        ApiEnum<string, PricingModelBillingModel> expectedBillingModel =
            PricingModelBillingModel.FlatFee;
        List<PricingModelPricePeriod> expectedPricePeriods =
        [
            new()
            {
                BillingPeriod = PricingModelPricePeriodBillingPeriod.Monthly,
                BillingCountryCode = "billingCountryCode",
                BlockSize = 0,
                CreditGrantCadence =
                    PricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                CreditRate = new()
                {
                    Amount = 1,
                    CurrencyID = "currencyId",
                    CostFormula = "costFormula",
                },
                Price = new() { Amount = 0, Currency = PricingModelPricePeriodPriceCurrency.Usd },
                Tiers =
                [
                    new()
                    {
                        FlatPrice = new()
                        {
                            Amount = 0,
                            Currency = PricingModelPricePeriodTierFlatPriceCurrency.Usd,
                        },
                        UnitPrice = new()
                        {
                            Amount = 0,
                            Currency = PricingModelPricePeriodTierUnitPriceCurrency.Usd,
                        },
                        UpTo = 0,
                    },
                ],
            },
        ];
        ApiEnum<string, PricingModelBillingCadence> expectedBillingCadence =
            PricingModelBillingCadence.Recurring;
        string expectedFeatureID = "featureId";
        long expectedMaxUnitQuantity = 1;
        long expectedMinUnitQuantity = 1;
        PricingModelMonthlyResetPeriodConfiguration expectedMonthlyResetPeriodConfiguration = new(
            PricingModelMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
        );
        ApiEnum<string, PricingModelResetPeriod> expectedResetPeriod = PricingModelResetPeriod.Year;
        ApiEnum<string, TiersMode> expectedTiersMode = TiersMode.Volume;
        string expectedTopUpCustomCurrencyID = "topUpCustomCurrencyId";
        PricingModelWeeklyResetPeriodConfiguration expectedWeeklyResetPeriodConfiguration = new(
            PricingModelWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
        );
        PricingModelYearlyResetPeriodConfiguration expectedYearlyResetPeriodConfiguration = new(
            PricingModelYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
        );

        Assert.Equal(expectedBillingModel, model.BillingModel);
        Assert.Equal(expectedPricePeriods.Count, model.PricePeriods.Count);
        for (int i = 0; i < expectedPricePeriods.Count; i++)
        {
            Assert.Equal(expectedPricePeriods[i], model.PricePeriods[i]);
        }
        Assert.Equal(expectedBillingCadence, model.BillingCadence);
        Assert.Equal(expectedFeatureID, model.FeatureID);
        Assert.Equal(expectedMaxUnitQuantity, model.MaxUnitQuantity);
        Assert.Equal(expectedMinUnitQuantity, model.MinUnitQuantity);
        Assert.Equal(
            expectedMonthlyResetPeriodConfiguration,
            model.MonthlyResetPeriodConfiguration
        );
        Assert.Equal(expectedResetPeriod, model.ResetPeriod);
        Assert.Equal(expectedTiersMode, model.TiersMode);
        Assert.Equal(expectedTopUpCustomCurrencyID, model.TopUpCustomCurrencyID);
        Assert.Equal(expectedWeeklyResetPeriodConfiguration, model.WeeklyResetPeriodConfiguration);
        Assert.Equal(expectedYearlyResetPeriodConfiguration, model.YearlyResetPeriodConfiguration);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PricingModel
        {
            BillingModel = PricingModelBillingModel.FlatFee,
            PricePeriods =
            [
                new()
                {
                    BillingPeriod = PricingModelPricePeriodBillingPeriod.Monthly,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    CreditGrantCadence =
                        PricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                    CreditRate = new()
                    {
                        Amount = 1,
                        CurrencyID = "currencyId",
                        CostFormula = "costFormula",
                    },
                    Price = new()
                    {
                        Amount = 0,
                        Currency = PricingModelPricePeriodPriceCurrency.Usd,
                    },
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency = PricingModelPricePeriodTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency = PricingModelPricePeriodTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            BillingCadence = PricingModelBillingCadence.Recurring,
            FeatureID = "featureId",
            MaxUnitQuantity = 1,
            MinUnitQuantity = 1,
            MonthlyResetPeriodConfiguration = new(
                PricingModelMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            ResetPeriod = PricingModelResetPeriod.Year,
            TiersMode = TiersMode.Volume,
            TopUpCustomCurrencyID = "topUpCustomCurrencyId",
            WeeklyResetPeriodConfiguration = new(
                PricingModelWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                PricingModelYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PricingModel>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PricingModel
        {
            BillingModel = PricingModelBillingModel.FlatFee,
            PricePeriods =
            [
                new()
                {
                    BillingPeriod = PricingModelPricePeriodBillingPeriod.Monthly,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    CreditGrantCadence =
                        PricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                    CreditRate = new()
                    {
                        Amount = 1,
                        CurrencyID = "currencyId",
                        CostFormula = "costFormula",
                    },
                    Price = new()
                    {
                        Amount = 0,
                        Currency = PricingModelPricePeriodPriceCurrency.Usd,
                    },
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency = PricingModelPricePeriodTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency = PricingModelPricePeriodTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            BillingCadence = PricingModelBillingCadence.Recurring,
            FeatureID = "featureId",
            MaxUnitQuantity = 1,
            MinUnitQuantity = 1,
            MonthlyResetPeriodConfiguration = new(
                PricingModelMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            ResetPeriod = PricingModelResetPeriod.Year,
            TiersMode = TiersMode.Volume,
            TopUpCustomCurrencyID = "topUpCustomCurrencyId",
            WeeklyResetPeriodConfiguration = new(
                PricingModelWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                PricingModelYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PricingModel>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, PricingModelBillingModel> expectedBillingModel =
            PricingModelBillingModel.FlatFee;
        List<PricingModelPricePeriod> expectedPricePeriods =
        [
            new()
            {
                BillingPeriod = PricingModelPricePeriodBillingPeriod.Monthly,
                BillingCountryCode = "billingCountryCode",
                BlockSize = 0,
                CreditGrantCadence =
                    PricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                CreditRate = new()
                {
                    Amount = 1,
                    CurrencyID = "currencyId",
                    CostFormula = "costFormula",
                },
                Price = new() { Amount = 0, Currency = PricingModelPricePeriodPriceCurrency.Usd },
                Tiers =
                [
                    new()
                    {
                        FlatPrice = new()
                        {
                            Amount = 0,
                            Currency = PricingModelPricePeriodTierFlatPriceCurrency.Usd,
                        },
                        UnitPrice = new()
                        {
                            Amount = 0,
                            Currency = PricingModelPricePeriodTierUnitPriceCurrency.Usd,
                        },
                        UpTo = 0,
                    },
                ],
            },
        ];
        ApiEnum<string, PricingModelBillingCadence> expectedBillingCadence =
            PricingModelBillingCadence.Recurring;
        string expectedFeatureID = "featureId";
        long expectedMaxUnitQuantity = 1;
        long expectedMinUnitQuantity = 1;
        PricingModelMonthlyResetPeriodConfiguration expectedMonthlyResetPeriodConfiguration = new(
            PricingModelMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
        );
        ApiEnum<string, PricingModelResetPeriod> expectedResetPeriod = PricingModelResetPeriod.Year;
        ApiEnum<string, TiersMode> expectedTiersMode = TiersMode.Volume;
        string expectedTopUpCustomCurrencyID = "topUpCustomCurrencyId";
        PricingModelWeeklyResetPeriodConfiguration expectedWeeklyResetPeriodConfiguration = new(
            PricingModelWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
        );
        PricingModelYearlyResetPeriodConfiguration expectedYearlyResetPeriodConfiguration = new(
            PricingModelYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
        );

        Assert.Equal(expectedBillingModel, deserialized.BillingModel);
        Assert.Equal(expectedPricePeriods.Count, deserialized.PricePeriods.Count);
        for (int i = 0; i < expectedPricePeriods.Count; i++)
        {
            Assert.Equal(expectedPricePeriods[i], deserialized.PricePeriods[i]);
        }
        Assert.Equal(expectedBillingCadence, deserialized.BillingCadence);
        Assert.Equal(expectedFeatureID, deserialized.FeatureID);
        Assert.Equal(expectedMaxUnitQuantity, deserialized.MaxUnitQuantity);
        Assert.Equal(expectedMinUnitQuantity, deserialized.MinUnitQuantity);
        Assert.Equal(
            expectedMonthlyResetPeriodConfiguration,
            deserialized.MonthlyResetPeriodConfiguration
        );
        Assert.Equal(expectedResetPeriod, deserialized.ResetPeriod);
        Assert.Equal(expectedTiersMode, deserialized.TiersMode);
        Assert.Equal(expectedTopUpCustomCurrencyID, deserialized.TopUpCustomCurrencyID);
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
        var model = new PricingModel
        {
            BillingModel = PricingModelBillingModel.FlatFee,
            PricePeriods =
            [
                new()
                {
                    BillingPeriod = PricingModelPricePeriodBillingPeriod.Monthly,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    CreditGrantCadence =
                        PricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                    CreditRate = new()
                    {
                        Amount = 1,
                        CurrencyID = "currencyId",
                        CostFormula = "costFormula",
                    },
                    Price = new()
                    {
                        Amount = 0,
                        Currency = PricingModelPricePeriodPriceCurrency.Usd,
                    },
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency = PricingModelPricePeriodTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency = PricingModelPricePeriodTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            BillingCadence = PricingModelBillingCadence.Recurring,
            FeatureID = "featureId",
            MaxUnitQuantity = 1,
            MinUnitQuantity = 1,
            MonthlyResetPeriodConfiguration = new(
                PricingModelMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            ResetPeriod = PricingModelResetPeriod.Year,
            TiersMode = TiersMode.Volume,
            TopUpCustomCurrencyID = "topUpCustomCurrencyId",
            WeeklyResetPeriodConfiguration = new(
                PricingModelWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                PricingModelYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PricingModel
        {
            BillingModel = PricingModelBillingModel.FlatFee,
            PricePeriods =
            [
                new()
                {
                    BillingPeriod = PricingModelPricePeriodBillingPeriod.Monthly,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    CreditGrantCadence =
                        PricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                    CreditRate = new()
                    {
                        Amount = 1,
                        CurrencyID = "currencyId",
                        CostFormula = "costFormula",
                    },
                    Price = new()
                    {
                        Amount = 0,
                        Currency = PricingModelPricePeriodPriceCurrency.Usd,
                    },
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency = PricingModelPricePeriodTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency = PricingModelPricePeriodTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
        };

        Assert.Null(model.BillingCadence);
        Assert.False(model.RawData.ContainsKey("billingCadence"));
        Assert.Null(model.FeatureID);
        Assert.False(model.RawData.ContainsKey("featureId"));
        Assert.Null(model.MaxUnitQuantity);
        Assert.False(model.RawData.ContainsKey("maxUnitQuantity"));
        Assert.Null(model.MinUnitQuantity);
        Assert.False(model.RawData.ContainsKey("minUnitQuantity"));
        Assert.Null(model.MonthlyResetPeriodConfiguration);
        Assert.False(model.RawData.ContainsKey("monthlyResetPeriodConfiguration"));
        Assert.Null(model.ResetPeriod);
        Assert.False(model.RawData.ContainsKey("resetPeriod"));
        Assert.Null(model.TiersMode);
        Assert.False(model.RawData.ContainsKey("tiersMode"));
        Assert.Null(model.TopUpCustomCurrencyID);
        Assert.False(model.RawData.ContainsKey("topUpCustomCurrencyId"));
        Assert.Null(model.WeeklyResetPeriodConfiguration);
        Assert.False(model.RawData.ContainsKey("weeklyResetPeriodConfiguration"));
        Assert.Null(model.YearlyResetPeriodConfiguration);
        Assert.False(model.RawData.ContainsKey("yearlyResetPeriodConfiguration"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PricingModel
        {
            BillingModel = PricingModelBillingModel.FlatFee,
            PricePeriods =
            [
                new()
                {
                    BillingPeriod = PricingModelPricePeriodBillingPeriod.Monthly,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    CreditGrantCadence =
                        PricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                    CreditRate = new()
                    {
                        Amount = 1,
                        CurrencyID = "currencyId",
                        CostFormula = "costFormula",
                    },
                    Price = new()
                    {
                        Amount = 0,
                        Currency = PricingModelPricePeriodPriceCurrency.Usd,
                    },
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency = PricingModelPricePeriodTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency = PricingModelPricePeriodTierUnitPriceCurrency.Usd,
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
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PricingModel
        {
            BillingModel = PricingModelBillingModel.FlatFee,
            PricePeriods =
            [
                new()
                {
                    BillingPeriod = PricingModelPricePeriodBillingPeriod.Monthly,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    CreditGrantCadence =
                        PricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                    CreditRate = new()
                    {
                        Amount = 1,
                        CurrencyID = "currencyId",
                        CostFormula = "costFormula",
                    },
                    Price = new()
                    {
                        Amount = 0,
                        Currency = PricingModelPricePeriodPriceCurrency.Usd,
                    },
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency = PricingModelPricePeriodTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency = PricingModelPricePeriodTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],

            // Null should be interpreted as omitted for these properties
            BillingCadence = null,
            FeatureID = null,
            MaxUnitQuantity = null,
            MinUnitQuantity = null,
            MonthlyResetPeriodConfiguration = null,
            ResetPeriod = null,
            TiersMode = null,
            TopUpCustomCurrencyID = null,
            WeeklyResetPeriodConfiguration = null,
            YearlyResetPeriodConfiguration = null,
        };

        Assert.Null(model.BillingCadence);
        Assert.False(model.RawData.ContainsKey("billingCadence"));
        Assert.Null(model.FeatureID);
        Assert.False(model.RawData.ContainsKey("featureId"));
        Assert.Null(model.MaxUnitQuantity);
        Assert.False(model.RawData.ContainsKey("maxUnitQuantity"));
        Assert.Null(model.MinUnitQuantity);
        Assert.False(model.RawData.ContainsKey("minUnitQuantity"));
        Assert.Null(model.MonthlyResetPeriodConfiguration);
        Assert.False(model.RawData.ContainsKey("monthlyResetPeriodConfiguration"));
        Assert.Null(model.ResetPeriod);
        Assert.False(model.RawData.ContainsKey("resetPeriod"));
        Assert.Null(model.TiersMode);
        Assert.False(model.RawData.ContainsKey("tiersMode"));
        Assert.Null(model.TopUpCustomCurrencyID);
        Assert.False(model.RawData.ContainsKey("topUpCustomCurrencyId"));
        Assert.Null(model.WeeklyResetPeriodConfiguration);
        Assert.False(model.RawData.ContainsKey("weeklyResetPeriodConfiguration"));
        Assert.Null(model.YearlyResetPeriodConfiguration);
        Assert.False(model.RawData.ContainsKey("yearlyResetPeriodConfiguration"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PricingModel
        {
            BillingModel = PricingModelBillingModel.FlatFee,
            PricePeriods =
            [
                new()
                {
                    BillingPeriod = PricingModelPricePeriodBillingPeriod.Monthly,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    CreditGrantCadence =
                        PricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                    CreditRate = new()
                    {
                        Amount = 1,
                        CurrencyID = "currencyId",
                        CostFormula = "costFormula",
                    },
                    Price = new()
                    {
                        Amount = 0,
                        Currency = PricingModelPricePeriodPriceCurrency.Usd,
                    },
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency = PricingModelPricePeriodTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency = PricingModelPricePeriodTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],

            // Null should be interpreted as omitted for these properties
            BillingCadence = null,
            FeatureID = null,
            MaxUnitQuantity = null,
            MinUnitQuantity = null,
            MonthlyResetPeriodConfiguration = null,
            ResetPeriod = null,
            TiersMode = null,
            TopUpCustomCurrencyID = null,
            WeeklyResetPeriodConfiguration = null,
            YearlyResetPeriodConfiguration = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PricingModel
        {
            BillingModel = PricingModelBillingModel.FlatFee,
            PricePeriods =
            [
                new()
                {
                    BillingPeriod = PricingModelPricePeriodBillingPeriod.Monthly,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    CreditGrantCadence =
                        PricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                    CreditRate = new()
                    {
                        Amount = 1,
                        CurrencyID = "currencyId",
                        CostFormula = "costFormula",
                    },
                    Price = new()
                    {
                        Amount = 0,
                        Currency = PricingModelPricePeriodPriceCurrency.Usd,
                    },
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency = PricingModelPricePeriodTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency = PricingModelPricePeriodTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            BillingCadence = PricingModelBillingCadence.Recurring,
            FeatureID = "featureId",
            MaxUnitQuantity = 1,
            MinUnitQuantity = 1,
            MonthlyResetPeriodConfiguration = new(
                PricingModelMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            ResetPeriod = PricingModelResetPeriod.Year,
            TiersMode = TiersMode.Volume,
            TopUpCustomCurrencyID = "topUpCustomCurrencyId",
            WeeklyResetPeriodConfiguration = new(
                PricingModelWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                PricingModelYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };

        PricingModel copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PricingModelBillingModelTest : TestBase
{
    [Theory]
    [InlineData(PricingModelBillingModel.FlatFee)]
    [InlineData(PricingModelBillingModel.MinimumSpend)]
    [InlineData(PricingModelBillingModel.PerUnit)]
    [InlineData(PricingModelBillingModel.UsageBased)]
    [InlineData(PricingModelBillingModel.CreditBased)]
    public void Validation_Works(PricingModelBillingModel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PricingModelBillingModel> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PricingModelBillingModel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PricingModelBillingModel.FlatFee)]
    [InlineData(PricingModelBillingModel.MinimumSpend)]
    [InlineData(PricingModelBillingModel.PerUnit)]
    [InlineData(PricingModelBillingModel.UsageBased)]
    [InlineData(PricingModelBillingModel.CreditBased)]
    public void SerializationRoundtrip_Works(PricingModelBillingModel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PricingModelBillingModel> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PricingModelBillingModel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PricingModelBillingModel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PricingModelBillingModel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PricingModelPricePeriodTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PricingModelPricePeriod
        {
            BillingPeriod = PricingModelPricePeriodBillingPeriod.Monthly,
            BillingCountryCode = "billingCountryCode",
            BlockSize = 0,
            CreditGrantCadence = PricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
            CreditRate = new()
            {
                Amount = 1,
                CurrencyID = "currencyId",
                CostFormula = "costFormula",
            },
            Price = new() { Amount = 0, Currency = PricingModelPricePeriodPriceCurrency.Usd },
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        Currency = PricingModelPricePeriodTierFlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        Currency = PricingModelPricePeriodTierUnitPriceCurrency.Usd,
                    },
                    UpTo = 0,
                },
            ],
        };

        ApiEnum<string, PricingModelPricePeriodBillingPeriod> expectedBillingPeriod =
            PricingModelPricePeriodBillingPeriod.Monthly;
        string expectedBillingCountryCode = "billingCountryCode";
        double expectedBlockSize = 0;
        ApiEnum<string, PricingModelPricePeriodCreditGrantCadence> expectedCreditGrantCadence =
            PricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod;
        PricingModelPricePeriodCreditRate expectedCreditRate = new()
        {
            Amount = 1,
            CurrencyID = "currencyId",
            CostFormula = "costFormula",
        };
        PricingModelPricePeriodPrice expectedPrice = new()
        {
            Amount = 0,
            Currency = PricingModelPricePeriodPriceCurrency.Usd,
        };
        List<PricingModelPricePeriodTier> expectedTiers =
        [
            new()
            {
                FlatPrice = new()
                {
                    Amount = 0,
                    Currency = PricingModelPricePeriodTierFlatPriceCurrency.Usd,
                },
                UnitPrice = new()
                {
                    Amount = 0,
                    Currency = PricingModelPricePeriodTierUnitPriceCurrency.Usd,
                },
                UpTo = 0,
            },
        ];

        Assert.Equal(expectedBillingPeriod, model.BillingPeriod);
        Assert.Equal(expectedBillingCountryCode, model.BillingCountryCode);
        Assert.Equal(expectedBlockSize, model.BlockSize);
        Assert.Equal(expectedCreditGrantCadence, model.CreditGrantCadence);
        Assert.Equal(expectedCreditRate, model.CreditRate);
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
        var model = new PricingModelPricePeriod
        {
            BillingPeriod = PricingModelPricePeriodBillingPeriod.Monthly,
            BillingCountryCode = "billingCountryCode",
            BlockSize = 0,
            CreditGrantCadence = PricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
            CreditRate = new()
            {
                Amount = 1,
                CurrencyID = "currencyId",
                CostFormula = "costFormula",
            },
            Price = new() { Amount = 0, Currency = PricingModelPricePeriodPriceCurrency.Usd },
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        Currency = PricingModelPricePeriodTierFlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        Currency = PricingModelPricePeriodTierUnitPriceCurrency.Usd,
                    },
                    UpTo = 0,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PricingModelPricePeriod>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PricingModelPricePeriod
        {
            BillingPeriod = PricingModelPricePeriodBillingPeriod.Monthly,
            BillingCountryCode = "billingCountryCode",
            BlockSize = 0,
            CreditGrantCadence = PricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
            CreditRate = new()
            {
                Amount = 1,
                CurrencyID = "currencyId",
                CostFormula = "costFormula",
            },
            Price = new() { Amount = 0, Currency = PricingModelPricePeriodPriceCurrency.Usd },
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        Currency = PricingModelPricePeriodTierFlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        Currency = PricingModelPricePeriodTierUnitPriceCurrency.Usd,
                    },
                    UpTo = 0,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PricingModelPricePeriod>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, PricingModelPricePeriodBillingPeriod> expectedBillingPeriod =
            PricingModelPricePeriodBillingPeriod.Monthly;
        string expectedBillingCountryCode = "billingCountryCode";
        double expectedBlockSize = 0;
        ApiEnum<string, PricingModelPricePeriodCreditGrantCadence> expectedCreditGrantCadence =
            PricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod;
        PricingModelPricePeriodCreditRate expectedCreditRate = new()
        {
            Amount = 1,
            CurrencyID = "currencyId",
            CostFormula = "costFormula",
        };
        PricingModelPricePeriodPrice expectedPrice = new()
        {
            Amount = 0,
            Currency = PricingModelPricePeriodPriceCurrency.Usd,
        };
        List<PricingModelPricePeriodTier> expectedTiers =
        [
            new()
            {
                FlatPrice = new()
                {
                    Amount = 0,
                    Currency = PricingModelPricePeriodTierFlatPriceCurrency.Usd,
                },
                UnitPrice = new()
                {
                    Amount = 0,
                    Currency = PricingModelPricePeriodTierUnitPriceCurrency.Usd,
                },
                UpTo = 0,
            },
        ];

        Assert.Equal(expectedBillingPeriod, deserialized.BillingPeriod);
        Assert.Equal(expectedBillingCountryCode, deserialized.BillingCountryCode);
        Assert.Equal(expectedBlockSize, deserialized.BlockSize);
        Assert.Equal(expectedCreditGrantCadence, deserialized.CreditGrantCadence);
        Assert.Equal(expectedCreditRate, deserialized.CreditRate);
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
        var model = new PricingModelPricePeriod
        {
            BillingPeriod = PricingModelPricePeriodBillingPeriod.Monthly,
            BillingCountryCode = "billingCountryCode",
            BlockSize = 0,
            CreditGrantCadence = PricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
            CreditRate = new()
            {
                Amount = 1,
                CurrencyID = "currencyId",
                CostFormula = "costFormula",
            },
            Price = new() { Amount = 0, Currency = PricingModelPricePeriodPriceCurrency.Usd },
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        Currency = PricingModelPricePeriodTierFlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        Currency = PricingModelPricePeriodTierUnitPriceCurrency.Usd,
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
        var model = new PricingModelPricePeriod
        {
            BillingPeriod = PricingModelPricePeriodBillingPeriod.Monthly,
        };

        Assert.Null(model.BillingCountryCode);
        Assert.False(model.RawData.ContainsKey("billingCountryCode"));
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
        var model = new PricingModelPricePeriod
        {
            BillingPeriod = PricingModelPricePeriodBillingPeriod.Monthly,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PricingModelPricePeriod
        {
            BillingPeriod = PricingModelPricePeriodBillingPeriod.Monthly,

            // Null should be interpreted as omitted for these properties
            BillingCountryCode = null,
            BlockSize = null,
            CreditGrantCadence = null,
            CreditRate = null,
            Price = null,
            Tiers = null,
        };

        Assert.Null(model.BillingCountryCode);
        Assert.False(model.RawData.ContainsKey("billingCountryCode"));
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
        var model = new PricingModelPricePeriod
        {
            BillingPeriod = PricingModelPricePeriodBillingPeriod.Monthly,

            // Null should be interpreted as omitted for these properties
            BillingCountryCode = null,
            BlockSize = null,
            CreditGrantCadence = null,
            CreditRate = null,
            Price = null,
            Tiers = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PricingModelPricePeriod
        {
            BillingPeriod = PricingModelPricePeriodBillingPeriod.Monthly,
            BillingCountryCode = "billingCountryCode",
            BlockSize = 0,
            CreditGrantCadence = PricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
            CreditRate = new()
            {
                Amount = 1,
                CurrencyID = "currencyId",
                CostFormula = "costFormula",
            },
            Price = new() { Amount = 0, Currency = PricingModelPricePeriodPriceCurrency.Usd },
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        Currency = PricingModelPricePeriodTierFlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        Currency = PricingModelPricePeriodTierUnitPriceCurrency.Usd,
                    },
                    UpTo = 0,
                },
            ],
        };

        PricingModelPricePeriod copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PricingModelPricePeriodBillingPeriodTest : TestBase
{
    [Theory]
    [InlineData(PricingModelPricePeriodBillingPeriod.Monthly)]
    [InlineData(PricingModelPricePeriodBillingPeriod.Annually)]
    public void Validation_Works(PricingModelPricePeriodBillingPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PricingModelPricePeriodBillingPeriod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PricingModelPricePeriodBillingPeriod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PricingModelPricePeriodBillingPeriod.Monthly)]
    [InlineData(PricingModelPricePeriodBillingPeriod.Annually)]
    public void SerializationRoundtrip_Works(PricingModelPricePeriodBillingPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PricingModelPricePeriodBillingPeriod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PricingModelPricePeriodBillingPeriod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PricingModelPricePeriodBillingPeriod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PricingModelPricePeriodBillingPeriod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PricingModelPricePeriodCreditGrantCadenceTest : TestBase
{
    [Theory]
    [InlineData(PricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod)]
    [InlineData(PricingModelPricePeriodCreditGrantCadence.Monthly)]
    public void Validation_Works(PricingModelPricePeriodCreditGrantCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PricingModelPricePeriodCreditGrantCadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PricingModelPricePeriodCreditGrantCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod)]
    [InlineData(PricingModelPricePeriodCreditGrantCadence.Monthly)]
    public void SerializationRoundtrip_Works(PricingModelPricePeriodCreditGrantCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PricingModelPricePeriodCreditGrantCadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PricingModelPricePeriodCreditGrantCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PricingModelPricePeriodCreditGrantCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PricingModelPricePeriodCreditGrantCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PricingModelPricePeriodCreditRateTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PricingModelPricePeriodCreditRate
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
        var model = new PricingModelPricePeriodCreditRate
        {
            Amount = 1,
            CurrencyID = "currencyId",
            CostFormula = "costFormula",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PricingModelPricePeriodCreditRate>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PricingModelPricePeriodCreditRate
        {
            Amount = 1,
            CurrencyID = "currencyId",
            CostFormula = "costFormula",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PricingModelPricePeriodCreditRate>(
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
        var model = new PricingModelPricePeriodCreditRate
        {
            Amount = 1,
            CurrencyID = "currencyId",
            CostFormula = "costFormula",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PricingModelPricePeriodCreditRate { Amount = 1, CurrencyID = "currencyId" };

        Assert.Null(model.CostFormula);
        Assert.False(model.RawData.ContainsKey("costFormula"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PricingModelPricePeriodCreditRate { Amount = 1, CurrencyID = "currencyId" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PricingModelPricePeriodCreditRate
        {
            Amount = 1,
            CurrencyID = "currencyId",

            // Null should be interpreted as omitted for these properties
            CostFormula = null,
        };

        Assert.Null(model.CostFormula);
        Assert.False(model.RawData.ContainsKey("costFormula"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PricingModelPricePeriodCreditRate
        {
            Amount = 1,
            CurrencyID = "currencyId",

            // Null should be interpreted as omitted for these properties
            CostFormula = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PricingModelPricePeriodCreditRate
        {
            Amount = 1,
            CurrencyID = "currencyId",
            CostFormula = "costFormula",
        };

        PricingModelPricePeriodCreditRate copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PricingModelPricePeriodPriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PricingModelPricePeriodPrice
        {
            Amount = 0,
            Currency = PricingModelPricePeriodPriceCurrency.Usd,
        };

        double expectedAmount = 0;
        ApiEnum<string, PricingModelPricePeriodPriceCurrency> expectedCurrency =
            PricingModelPricePeriodPriceCurrency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PricingModelPricePeriodPrice
        {
            Amount = 0,
            Currency = PricingModelPricePeriodPriceCurrency.Usd,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PricingModelPricePeriodPrice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PricingModelPricePeriodPrice
        {
            Amount = 0,
            Currency = PricingModelPricePeriodPriceCurrency.Usd,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PricingModelPricePeriodPrice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        ApiEnum<string, PricingModelPricePeriodPriceCurrency> expectedCurrency =
            PricingModelPricePeriodPriceCurrency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PricingModelPricePeriodPrice
        {
            Amount = 0,
            Currency = PricingModelPricePeriodPriceCurrency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PricingModelPricePeriodPrice { Amount = 0 };

        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PricingModelPricePeriodPrice { Amount = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PricingModelPricePeriodPrice
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
        var model = new PricingModelPricePeriodPrice
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
        var model = new PricingModelPricePeriodPrice
        {
            Amount = 0,
            Currency = PricingModelPricePeriodPriceCurrency.Usd,
        };

        PricingModelPricePeriodPrice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PricingModelPricePeriodPriceCurrencyTest : TestBase
{
    [Theory]
    [InlineData(PricingModelPricePeriodPriceCurrency.Usd)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Aed)]
    [InlineData(PricingModelPricePeriodPriceCurrency.All)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Amd)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Ang)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Aud)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Awg)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Azn)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Bam)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Bbd)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Bdt)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Bgn)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Bif)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Bmd)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Bnd)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Bsd)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Bwp)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Byn)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Bzd)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Brl)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Cad)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Cdf)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Chf)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Cny)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Czk)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Dkk)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Dop)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Dzd)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Egp)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Etb)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Eur)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Fjd)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Gbp)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Gel)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Gip)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Gmd)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Gyd)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Hkd)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Hrk)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Htg)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Idr)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Ils)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Inr)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Isk)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Jmd)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Jpy)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Kes)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Kgs)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Khr)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Kmf)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Krw)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Kyd)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Kzt)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Lbp)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Lkr)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Lrd)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Lsl)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Mad)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Mdl)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Mga)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Mkd)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Mmk)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Mnt)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Mop)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Mro)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Mvr)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Mwk)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Mxn)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Myr)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Mzn)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Nad)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Ngn)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Nok)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Npr)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Nzd)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Pgk)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Php)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Pkr)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Pln)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Qar)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Ron)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Rsd)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Rub)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Rwf)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Sar)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Sbd)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Scr)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Sek)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Sgd)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Sle)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Sll)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Sos)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Szl)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Thb)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Tjs)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Top)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Try)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Ttd)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Tzs)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Uah)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Uzs)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Vnd)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Vuv)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Wst)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Xaf)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Xcd)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Yer)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Zar)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Zmw)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Clp)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Djf)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Gnf)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Ugx)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Pyg)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Xof)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Xpf)]
    public void Validation_Works(PricingModelPricePeriodPriceCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PricingModelPricePeriodPriceCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PricingModelPricePeriodPriceCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PricingModelPricePeriodPriceCurrency.Usd)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Aed)]
    [InlineData(PricingModelPricePeriodPriceCurrency.All)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Amd)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Ang)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Aud)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Awg)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Azn)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Bam)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Bbd)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Bdt)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Bgn)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Bif)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Bmd)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Bnd)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Bsd)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Bwp)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Byn)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Bzd)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Brl)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Cad)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Cdf)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Chf)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Cny)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Czk)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Dkk)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Dop)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Dzd)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Egp)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Etb)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Eur)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Fjd)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Gbp)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Gel)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Gip)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Gmd)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Gyd)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Hkd)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Hrk)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Htg)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Idr)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Ils)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Inr)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Isk)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Jmd)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Jpy)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Kes)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Kgs)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Khr)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Kmf)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Krw)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Kyd)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Kzt)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Lbp)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Lkr)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Lrd)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Lsl)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Mad)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Mdl)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Mga)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Mkd)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Mmk)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Mnt)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Mop)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Mro)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Mvr)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Mwk)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Mxn)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Myr)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Mzn)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Nad)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Ngn)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Nok)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Npr)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Nzd)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Pgk)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Php)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Pkr)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Pln)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Qar)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Ron)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Rsd)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Rub)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Rwf)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Sar)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Sbd)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Scr)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Sek)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Sgd)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Sle)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Sll)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Sos)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Szl)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Thb)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Tjs)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Top)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Try)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Ttd)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Tzs)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Uah)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Uzs)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Vnd)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Vuv)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Wst)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Xaf)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Xcd)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Yer)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Zar)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Zmw)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Clp)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Djf)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Gnf)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Ugx)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Pyg)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Xof)]
    [InlineData(PricingModelPricePeriodPriceCurrency.Xpf)]
    public void SerializationRoundtrip_Works(PricingModelPricePeriodPriceCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PricingModelPricePeriodPriceCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PricingModelPricePeriodPriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PricingModelPricePeriodPriceCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PricingModelPricePeriodPriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PricingModelPricePeriodTierTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PricingModelPricePeriodTier
        {
            FlatPrice = new()
            {
                Amount = 0,
                Currency = PricingModelPricePeriodTierFlatPriceCurrency.Usd,
            },
            UnitPrice = new()
            {
                Amount = 0,
                Currency = PricingModelPricePeriodTierUnitPriceCurrency.Usd,
            },
            UpTo = 0,
        };

        PricingModelPricePeriodTierFlatPrice expectedFlatPrice = new()
        {
            Amount = 0,
            Currency = PricingModelPricePeriodTierFlatPriceCurrency.Usd,
        };
        PricingModelPricePeriodTierUnitPrice expectedUnitPrice = new()
        {
            Amount = 0,
            Currency = PricingModelPricePeriodTierUnitPriceCurrency.Usd,
        };
        double expectedUpTo = 0;

        Assert.Equal(expectedFlatPrice, model.FlatPrice);
        Assert.Equal(expectedUnitPrice, model.UnitPrice);
        Assert.Equal(expectedUpTo, model.UpTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PricingModelPricePeriodTier
        {
            FlatPrice = new()
            {
                Amount = 0,
                Currency = PricingModelPricePeriodTierFlatPriceCurrency.Usd,
            },
            UnitPrice = new()
            {
                Amount = 0,
                Currency = PricingModelPricePeriodTierUnitPriceCurrency.Usd,
            },
            UpTo = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PricingModelPricePeriodTier>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PricingModelPricePeriodTier
        {
            FlatPrice = new()
            {
                Amount = 0,
                Currency = PricingModelPricePeriodTierFlatPriceCurrency.Usd,
            },
            UnitPrice = new()
            {
                Amount = 0,
                Currency = PricingModelPricePeriodTierUnitPriceCurrency.Usd,
            },
            UpTo = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PricingModelPricePeriodTier>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        PricingModelPricePeriodTierFlatPrice expectedFlatPrice = new()
        {
            Amount = 0,
            Currency = PricingModelPricePeriodTierFlatPriceCurrency.Usd,
        };
        PricingModelPricePeriodTierUnitPrice expectedUnitPrice = new()
        {
            Amount = 0,
            Currency = PricingModelPricePeriodTierUnitPriceCurrency.Usd,
        };
        double expectedUpTo = 0;

        Assert.Equal(expectedFlatPrice, deserialized.FlatPrice);
        Assert.Equal(expectedUnitPrice, deserialized.UnitPrice);
        Assert.Equal(expectedUpTo, deserialized.UpTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PricingModelPricePeriodTier
        {
            FlatPrice = new()
            {
                Amount = 0,
                Currency = PricingModelPricePeriodTierFlatPriceCurrency.Usd,
            },
            UnitPrice = new()
            {
                Amount = 0,
                Currency = PricingModelPricePeriodTierUnitPriceCurrency.Usd,
            },
            UpTo = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PricingModelPricePeriodTier { };

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
        var model = new PricingModelPricePeriodTier { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PricingModelPricePeriodTier
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
        var model = new PricingModelPricePeriodTier
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
        var model = new PricingModelPricePeriodTier
        {
            FlatPrice = new()
            {
                Amount = 0,
                Currency = PricingModelPricePeriodTierFlatPriceCurrency.Usd,
            },
            UnitPrice = new()
            {
                Amount = 0,
                Currency = PricingModelPricePeriodTierUnitPriceCurrency.Usd,
            },
            UpTo = 0,
        };

        PricingModelPricePeriodTier copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PricingModelPricePeriodTierFlatPriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PricingModelPricePeriodTierFlatPrice
        {
            Amount = 0,
            Currency = PricingModelPricePeriodTierFlatPriceCurrency.Usd,
        };

        double expectedAmount = 0;
        ApiEnum<string, PricingModelPricePeriodTierFlatPriceCurrency> expectedCurrency =
            PricingModelPricePeriodTierFlatPriceCurrency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PricingModelPricePeriodTierFlatPrice
        {
            Amount = 0,
            Currency = PricingModelPricePeriodTierFlatPriceCurrency.Usd,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PricingModelPricePeriodTierFlatPrice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PricingModelPricePeriodTierFlatPrice
        {
            Amount = 0,
            Currency = PricingModelPricePeriodTierFlatPriceCurrency.Usd,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PricingModelPricePeriodTierFlatPrice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        ApiEnum<string, PricingModelPricePeriodTierFlatPriceCurrency> expectedCurrency =
            PricingModelPricePeriodTierFlatPriceCurrency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PricingModelPricePeriodTierFlatPrice
        {
            Amount = 0,
            Currency = PricingModelPricePeriodTierFlatPriceCurrency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PricingModelPricePeriodTierFlatPrice { Amount = 0 };

        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PricingModelPricePeriodTierFlatPrice { Amount = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PricingModelPricePeriodTierFlatPrice
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
        var model = new PricingModelPricePeriodTierFlatPrice
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
        var model = new PricingModelPricePeriodTierFlatPrice
        {
            Amount = 0,
            Currency = PricingModelPricePeriodTierFlatPriceCurrency.Usd,
        };

        PricingModelPricePeriodTierFlatPrice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PricingModelPricePeriodTierFlatPriceCurrencyTest : TestBase
{
    [Theory]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Usd)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Aed)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.All)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Amd)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Ang)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Aud)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Awg)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Azn)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Bam)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Bbd)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Bdt)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Bgn)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Bif)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Bmd)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Bnd)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Bsd)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Bwp)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Byn)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Bzd)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Brl)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Cad)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Cdf)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Chf)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Cny)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Czk)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Dkk)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Dop)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Dzd)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Egp)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Etb)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Eur)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Fjd)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Gbp)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Gel)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Gip)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Gmd)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Gyd)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Hkd)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Hrk)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Htg)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Idr)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Ils)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Inr)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Isk)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Jmd)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Jpy)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Kes)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Kgs)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Khr)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Kmf)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Krw)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Kyd)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Kzt)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Lbp)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Lkr)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Lrd)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Lsl)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Mad)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Mdl)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Mga)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Mkd)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Mmk)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Mnt)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Mop)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Mro)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Mvr)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Mwk)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Mxn)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Myr)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Mzn)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Nad)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Ngn)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Nok)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Npr)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Nzd)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Pgk)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Php)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Pkr)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Pln)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Qar)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Ron)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Rsd)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Rub)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Rwf)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Sar)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Sbd)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Scr)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Sek)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Sgd)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Sle)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Sll)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Sos)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Szl)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Thb)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Tjs)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Top)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Try)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Ttd)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Tzs)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Uah)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Uzs)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Vnd)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Vuv)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Wst)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Xaf)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Xcd)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Yer)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Zar)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Zmw)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Clp)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Djf)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Gnf)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Ugx)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Pyg)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Xof)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Xpf)]
    public void Validation_Works(PricingModelPricePeriodTierFlatPriceCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PricingModelPricePeriodTierFlatPriceCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PricingModelPricePeriodTierFlatPriceCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Usd)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Aed)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.All)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Amd)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Ang)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Aud)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Awg)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Azn)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Bam)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Bbd)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Bdt)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Bgn)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Bif)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Bmd)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Bnd)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Bsd)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Bwp)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Byn)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Bzd)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Brl)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Cad)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Cdf)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Chf)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Cny)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Czk)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Dkk)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Dop)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Dzd)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Egp)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Etb)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Eur)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Fjd)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Gbp)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Gel)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Gip)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Gmd)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Gyd)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Hkd)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Hrk)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Htg)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Idr)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Ils)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Inr)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Isk)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Jmd)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Jpy)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Kes)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Kgs)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Khr)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Kmf)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Krw)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Kyd)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Kzt)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Lbp)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Lkr)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Lrd)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Lsl)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Mad)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Mdl)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Mga)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Mkd)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Mmk)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Mnt)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Mop)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Mro)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Mvr)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Mwk)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Mxn)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Myr)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Mzn)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Nad)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Ngn)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Nok)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Npr)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Nzd)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Pgk)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Php)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Pkr)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Pln)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Qar)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Ron)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Rsd)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Rub)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Rwf)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Sar)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Sbd)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Scr)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Sek)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Sgd)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Sle)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Sll)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Sos)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Szl)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Thb)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Tjs)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Top)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Try)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Ttd)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Tzs)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Uah)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Uzs)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Vnd)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Vuv)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Wst)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Xaf)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Xcd)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Yer)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Zar)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Zmw)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Clp)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Djf)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Gnf)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Ugx)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Pyg)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Xof)]
    [InlineData(PricingModelPricePeriodTierFlatPriceCurrency.Xpf)]
    public void SerializationRoundtrip_Works(PricingModelPricePeriodTierFlatPriceCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PricingModelPricePeriodTierFlatPriceCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PricingModelPricePeriodTierFlatPriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PricingModelPricePeriodTierFlatPriceCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PricingModelPricePeriodTierFlatPriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PricingModelPricePeriodTierUnitPriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PricingModelPricePeriodTierUnitPrice
        {
            Amount = 0,
            Currency = PricingModelPricePeriodTierUnitPriceCurrency.Usd,
        };

        double expectedAmount = 0;
        ApiEnum<string, PricingModelPricePeriodTierUnitPriceCurrency> expectedCurrency =
            PricingModelPricePeriodTierUnitPriceCurrency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PricingModelPricePeriodTierUnitPrice
        {
            Amount = 0,
            Currency = PricingModelPricePeriodTierUnitPriceCurrency.Usd,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PricingModelPricePeriodTierUnitPrice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PricingModelPricePeriodTierUnitPrice
        {
            Amount = 0,
            Currency = PricingModelPricePeriodTierUnitPriceCurrency.Usd,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PricingModelPricePeriodTierUnitPrice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        ApiEnum<string, PricingModelPricePeriodTierUnitPriceCurrency> expectedCurrency =
            PricingModelPricePeriodTierUnitPriceCurrency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PricingModelPricePeriodTierUnitPrice
        {
            Amount = 0,
            Currency = PricingModelPricePeriodTierUnitPriceCurrency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PricingModelPricePeriodTierUnitPrice { Amount = 0 };

        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PricingModelPricePeriodTierUnitPrice { Amount = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PricingModelPricePeriodTierUnitPrice
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
        var model = new PricingModelPricePeriodTierUnitPrice
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
        var model = new PricingModelPricePeriodTierUnitPrice
        {
            Amount = 0,
            Currency = PricingModelPricePeriodTierUnitPriceCurrency.Usd,
        };

        PricingModelPricePeriodTierUnitPrice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PricingModelPricePeriodTierUnitPriceCurrencyTest : TestBase
{
    [Theory]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Usd)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Aed)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.All)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Amd)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Ang)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Aud)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Awg)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Azn)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Bam)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Bbd)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Bdt)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Bgn)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Bif)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Bmd)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Bnd)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Bsd)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Bwp)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Byn)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Bzd)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Brl)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Cad)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Cdf)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Chf)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Cny)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Czk)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Dkk)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Dop)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Dzd)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Egp)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Etb)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Eur)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Fjd)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Gbp)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Gel)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Gip)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Gmd)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Gyd)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Hkd)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Hrk)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Htg)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Idr)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Ils)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Inr)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Isk)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Jmd)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Jpy)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Kes)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Kgs)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Khr)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Kmf)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Krw)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Kyd)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Kzt)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Lbp)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Lkr)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Lrd)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Lsl)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Mad)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Mdl)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Mga)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Mkd)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Mmk)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Mnt)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Mop)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Mro)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Mvr)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Mwk)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Mxn)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Myr)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Mzn)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Nad)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Ngn)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Nok)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Npr)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Nzd)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Pgk)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Php)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Pkr)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Pln)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Qar)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Ron)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Rsd)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Rub)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Rwf)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Sar)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Sbd)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Scr)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Sek)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Sgd)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Sle)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Sll)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Sos)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Szl)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Thb)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Tjs)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Top)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Try)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Ttd)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Tzs)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Uah)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Uzs)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Vnd)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Vuv)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Wst)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Xaf)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Xcd)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Yer)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Zar)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Zmw)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Clp)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Djf)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Gnf)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Ugx)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Pyg)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Xof)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Xpf)]
    public void Validation_Works(PricingModelPricePeriodTierUnitPriceCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PricingModelPricePeriodTierUnitPriceCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PricingModelPricePeriodTierUnitPriceCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Usd)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Aed)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.All)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Amd)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Ang)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Aud)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Awg)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Azn)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Bam)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Bbd)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Bdt)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Bgn)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Bif)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Bmd)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Bnd)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Bsd)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Bwp)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Byn)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Bzd)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Brl)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Cad)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Cdf)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Chf)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Cny)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Czk)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Dkk)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Dop)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Dzd)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Egp)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Etb)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Eur)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Fjd)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Gbp)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Gel)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Gip)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Gmd)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Gyd)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Hkd)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Hrk)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Htg)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Idr)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Ils)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Inr)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Isk)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Jmd)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Jpy)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Kes)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Kgs)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Khr)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Kmf)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Krw)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Kyd)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Kzt)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Lbp)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Lkr)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Lrd)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Lsl)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Mad)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Mdl)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Mga)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Mkd)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Mmk)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Mnt)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Mop)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Mro)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Mvr)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Mwk)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Mxn)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Myr)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Mzn)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Nad)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Ngn)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Nok)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Npr)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Nzd)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Pgk)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Php)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Pkr)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Pln)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Qar)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Ron)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Rsd)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Rub)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Rwf)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Sar)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Sbd)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Scr)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Sek)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Sgd)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Sle)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Sll)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Sos)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Szl)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Thb)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Tjs)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Top)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Try)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Ttd)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Tzs)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Uah)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Uzs)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Vnd)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Vuv)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Wst)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Xaf)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Xcd)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Yer)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Zar)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Zmw)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Clp)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Djf)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Gnf)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Ugx)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Pyg)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Xof)]
    [InlineData(PricingModelPricePeriodTierUnitPriceCurrency.Xpf)]
    public void SerializationRoundtrip_Works(PricingModelPricePeriodTierUnitPriceCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PricingModelPricePeriodTierUnitPriceCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PricingModelPricePeriodTierUnitPriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PricingModelPricePeriodTierUnitPriceCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PricingModelPricePeriodTierUnitPriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PricingModelBillingCadenceTest : TestBase
{
    [Theory]
    [InlineData(PricingModelBillingCadence.Recurring)]
    [InlineData(PricingModelBillingCadence.OneOff)]
    public void Validation_Works(PricingModelBillingCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PricingModelBillingCadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PricingModelBillingCadence>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PricingModelBillingCadence.Recurring)]
    [InlineData(PricingModelBillingCadence.OneOff)]
    public void SerializationRoundtrip_Works(PricingModelBillingCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PricingModelBillingCadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PricingModelBillingCadence>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PricingModelBillingCadence>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PricingModelBillingCadence>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PricingModelMonthlyResetPeriodConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PricingModelMonthlyResetPeriodConfiguration
        {
            AccordingTo = PricingModelMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        ApiEnum<
            string,
            PricingModelMonthlyResetPeriodConfigurationAccordingTo
        > expectedAccordingTo =
            PricingModelMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, model.AccordingTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PricingModelMonthlyResetPeriodConfiguration
        {
            AccordingTo = PricingModelMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PricingModelMonthlyResetPeriodConfiguration>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PricingModelMonthlyResetPeriodConfiguration
        {
            AccordingTo = PricingModelMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PricingModelMonthlyResetPeriodConfiguration>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            PricingModelMonthlyResetPeriodConfigurationAccordingTo
        > expectedAccordingTo =
            PricingModelMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, deserialized.AccordingTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PricingModelMonthlyResetPeriodConfiguration
        {
            AccordingTo = PricingModelMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PricingModelMonthlyResetPeriodConfiguration
        {
            AccordingTo = PricingModelMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        PricingModelMonthlyResetPeriodConfiguration copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PricingModelMonthlyResetPeriodConfigurationAccordingToTest : TestBase
{
    [Theory]
    [InlineData(PricingModelMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart)]
    [InlineData(PricingModelMonthlyResetPeriodConfigurationAccordingTo.StartOfTheMonth)]
    public void Validation_Works(PricingModelMonthlyResetPeriodConfigurationAccordingTo rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PricingModelMonthlyResetPeriodConfigurationAccordingTo> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PricingModelMonthlyResetPeriodConfigurationAccordingTo>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PricingModelMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart)]
    [InlineData(PricingModelMonthlyResetPeriodConfigurationAccordingTo.StartOfTheMonth)]
    public void SerializationRoundtrip_Works(
        PricingModelMonthlyResetPeriodConfigurationAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PricingModelMonthlyResetPeriodConfigurationAccordingTo> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PricingModelMonthlyResetPeriodConfigurationAccordingTo>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PricingModelMonthlyResetPeriodConfigurationAccordingTo>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PricingModelMonthlyResetPeriodConfigurationAccordingTo>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PricingModelResetPeriodTest : TestBase
{
    [Theory]
    [InlineData(PricingModelResetPeriod.Year)]
    [InlineData(PricingModelResetPeriod.Month)]
    [InlineData(PricingModelResetPeriod.Week)]
    [InlineData(PricingModelResetPeriod.Day)]
    [InlineData(PricingModelResetPeriod.Hour)]
    public void Validation_Works(PricingModelResetPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PricingModelResetPeriod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PricingModelResetPeriod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PricingModelResetPeriod.Year)]
    [InlineData(PricingModelResetPeriod.Month)]
    [InlineData(PricingModelResetPeriod.Week)]
    [InlineData(PricingModelResetPeriod.Day)]
    [InlineData(PricingModelResetPeriod.Hour)]
    public void SerializationRoundtrip_Works(PricingModelResetPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PricingModelResetPeriod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PricingModelResetPeriod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PricingModelResetPeriod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PricingModelResetPeriod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TiersModeTest : TestBase
{
    [Theory]
    [InlineData(TiersMode.Volume)]
    [InlineData(TiersMode.Graduated)]
    public void Validation_Works(TiersMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TiersMode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TiersMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TiersMode.Volume)]
    [InlineData(TiersMode.Graduated)]
    public void SerializationRoundtrip_Works(TiersMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TiersMode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TiersMode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TiersMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TiersMode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PricingModelWeeklyResetPeriodConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PricingModelWeeklyResetPeriodConfiguration
        {
            AccordingTo = PricingModelWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        ApiEnum<string, PricingModelWeeklyResetPeriodConfigurationAccordingTo> expectedAccordingTo =
            PricingModelWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, model.AccordingTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PricingModelWeeklyResetPeriodConfiguration
        {
            AccordingTo = PricingModelWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PricingModelWeeklyResetPeriodConfiguration>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PricingModelWeeklyResetPeriodConfiguration
        {
            AccordingTo = PricingModelWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PricingModelWeeklyResetPeriodConfiguration>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, PricingModelWeeklyResetPeriodConfigurationAccordingTo> expectedAccordingTo =
            PricingModelWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, deserialized.AccordingTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PricingModelWeeklyResetPeriodConfiguration
        {
            AccordingTo = PricingModelWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PricingModelWeeklyResetPeriodConfiguration
        {
            AccordingTo = PricingModelWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        PricingModelWeeklyResetPeriodConfiguration copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PricingModelWeeklyResetPeriodConfigurationAccordingToTest : TestBase
{
    [Theory]
    [InlineData(PricingModelWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart)]
    [InlineData(PricingModelWeeklyResetPeriodConfigurationAccordingTo.EverySunday)]
    [InlineData(PricingModelWeeklyResetPeriodConfigurationAccordingTo.EveryMonday)]
    [InlineData(PricingModelWeeklyResetPeriodConfigurationAccordingTo.EveryTuesday)]
    [InlineData(PricingModelWeeklyResetPeriodConfigurationAccordingTo.EveryWednesday)]
    [InlineData(PricingModelWeeklyResetPeriodConfigurationAccordingTo.EveryThursday)]
    [InlineData(PricingModelWeeklyResetPeriodConfigurationAccordingTo.EveryFriday)]
    [InlineData(PricingModelWeeklyResetPeriodConfigurationAccordingTo.EverySaturday)]
    public void Validation_Works(PricingModelWeeklyResetPeriodConfigurationAccordingTo rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PricingModelWeeklyResetPeriodConfigurationAccordingTo> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PricingModelWeeklyResetPeriodConfigurationAccordingTo>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PricingModelWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart)]
    [InlineData(PricingModelWeeklyResetPeriodConfigurationAccordingTo.EverySunday)]
    [InlineData(PricingModelWeeklyResetPeriodConfigurationAccordingTo.EveryMonday)]
    [InlineData(PricingModelWeeklyResetPeriodConfigurationAccordingTo.EveryTuesday)]
    [InlineData(PricingModelWeeklyResetPeriodConfigurationAccordingTo.EveryWednesday)]
    [InlineData(PricingModelWeeklyResetPeriodConfigurationAccordingTo.EveryThursday)]
    [InlineData(PricingModelWeeklyResetPeriodConfigurationAccordingTo.EveryFriday)]
    [InlineData(PricingModelWeeklyResetPeriodConfigurationAccordingTo.EverySaturday)]
    public void SerializationRoundtrip_Works(
        PricingModelWeeklyResetPeriodConfigurationAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PricingModelWeeklyResetPeriodConfigurationAccordingTo> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PricingModelWeeklyResetPeriodConfigurationAccordingTo>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PricingModelWeeklyResetPeriodConfigurationAccordingTo>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PricingModelWeeklyResetPeriodConfigurationAccordingTo>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PricingModelYearlyResetPeriodConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PricingModelYearlyResetPeriodConfiguration
        {
            AccordingTo = PricingModelYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        ApiEnum<string, PricingModelYearlyResetPeriodConfigurationAccordingTo> expectedAccordingTo =
            PricingModelYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, model.AccordingTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PricingModelYearlyResetPeriodConfiguration
        {
            AccordingTo = PricingModelYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PricingModelYearlyResetPeriodConfiguration>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PricingModelYearlyResetPeriodConfiguration
        {
            AccordingTo = PricingModelYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PricingModelYearlyResetPeriodConfiguration>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, PricingModelYearlyResetPeriodConfigurationAccordingTo> expectedAccordingTo =
            PricingModelYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, deserialized.AccordingTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PricingModelYearlyResetPeriodConfiguration
        {
            AccordingTo = PricingModelYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PricingModelYearlyResetPeriodConfiguration
        {
            AccordingTo = PricingModelYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        PricingModelYearlyResetPeriodConfiguration copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PricingModelYearlyResetPeriodConfigurationAccordingToTest : TestBase
{
    [Theory]
    [InlineData(PricingModelYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart)]
    public void Validation_Works(PricingModelYearlyResetPeriodConfigurationAccordingTo rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PricingModelYearlyResetPeriodConfigurationAccordingTo> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PricingModelYearlyResetPeriodConfigurationAccordingTo>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PricingModelYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart)]
    public void SerializationRoundtrip_Works(
        PricingModelYearlyResetPeriodConfigurationAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PricingModelYearlyResetPeriodConfigurationAccordingTo> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PricingModelYearlyResetPeriodConfigurationAccordingTo>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PricingModelYearlyResetPeriodConfigurationAccordingTo>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PricingModelYearlyResetPeriodConfigurationAccordingTo>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PlanUpdateParamsDefaultTrialConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PlanUpdateParamsDefaultTrialConfig
        {
            Duration = 0,
            Units = PlanUpdateParamsDefaultTrialConfigUnits.Day,
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            TrialEndBehavior = PlanUpdateParamsDefaultTrialConfigTrialEndBehavior.ConvertToPaid,
        };

        double expectedDuration = 0;
        ApiEnum<string, PlanUpdateParamsDefaultTrialConfigUnits> expectedUnits =
            PlanUpdateParamsDefaultTrialConfigUnits.Day;
        PlanUpdateParamsDefaultTrialConfigBudget expectedBudget = new()
        {
            HasSoftLimit = true,
            Limit = 0,
        };
        ApiEnum<
            string,
            PlanUpdateParamsDefaultTrialConfigTrialEndBehavior
        > expectedTrialEndBehavior =
            PlanUpdateParamsDefaultTrialConfigTrialEndBehavior.ConvertToPaid;

        Assert.Equal(expectedDuration, model.Duration);
        Assert.Equal(expectedUnits, model.Units);
        Assert.Equal(expectedBudget, model.Budget);
        Assert.Equal(expectedTrialEndBehavior, model.TrialEndBehavior);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PlanUpdateParamsDefaultTrialConfig
        {
            Duration = 0,
            Units = PlanUpdateParamsDefaultTrialConfigUnits.Day,
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            TrialEndBehavior = PlanUpdateParamsDefaultTrialConfigTrialEndBehavior.ConvertToPaid,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanUpdateParamsDefaultTrialConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PlanUpdateParamsDefaultTrialConfig
        {
            Duration = 0,
            Units = PlanUpdateParamsDefaultTrialConfigUnits.Day,
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            TrialEndBehavior = PlanUpdateParamsDefaultTrialConfigTrialEndBehavior.ConvertToPaid,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanUpdateParamsDefaultTrialConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedDuration = 0;
        ApiEnum<string, PlanUpdateParamsDefaultTrialConfigUnits> expectedUnits =
            PlanUpdateParamsDefaultTrialConfigUnits.Day;
        PlanUpdateParamsDefaultTrialConfigBudget expectedBudget = new()
        {
            HasSoftLimit = true,
            Limit = 0,
        };
        ApiEnum<
            string,
            PlanUpdateParamsDefaultTrialConfigTrialEndBehavior
        > expectedTrialEndBehavior =
            PlanUpdateParamsDefaultTrialConfigTrialEndBehavior.ConvertToPaid;

        Assert.Equal(expectedDuration, deserialized.Duration);
        Assert.Equal(expectedUnits, deserialized.Units);
        Assert.Equal(expectedBudget, deserialized.Budget);
        Assert.Equal(expectedTrialEndBehavior, deserialized.TrialEndBehavior);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PlanUpdateParamsDefaultTrialConfig
        {
            Duration = 0,
            Units = PlanUpdateParamsDefaultTrialConfigUnits.Day,
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            TrialEndBehavior = PlanUpdateParamsDefaultTrialConfigTrialEndBehavior.ConvertToPaid,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PlanUpdateParamsDefaultTrialConfig
        {
            Duration = 0,
            Units = PlanUpdateParamsDefaultTrialConfigUnits.Day,
        };

        Assert.Null(model.Budget);
        Assert.False(model.RawData.ContainsKey("budget"));
        Assert.Null(model.TrialEndBehavior);
        Assert.False(model.RawData.ContainsKey("trialEndBehavior"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new PlanUpdateParamsDefaultTrialConfig
        {
            Duration = 0,
            Units = PlanUpdateParamsDefaultTrialConfigUnits.Day,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new PlanUpdateParamsDefaultTrialConfig
        {
            Duration = 0,
            Units = PlanUpdateParamsDefaultTrialConfigUnits.Day,

            Budget = null,
            TrialEndBehavior = null,
        };

        Assert.Null(model.Budget);
        Assert.True(model.RawData.ContainsKey("budget"));
        Assert.Null(model.TrialEndBehavior);
        Assert.True(model.RawData.ContainsKey("trialEndBehavior"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PlanUpdateParamsDefaultTrialConfig
        {
            Duration = 0,
            Units = PlanUpdateParamsDefaultTrialConfigUnits.Day,

            Budget = null,
            TrialEndBehavior = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PlanUpdateParamsDefaultTrialConfig
        {
            Duration = 0,
            Units = PlanUpdateParamsDefaultTrialConfigUnits.Day,
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            TrialEndBehavior = PlanUpdateParamsDefaultTrialConfigTrialEndBehavior.ConvertToPaid,
        };

        PlanUpdateParamsDefaultTrialConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PlanUpdateParamsDefaultTrialConfigUnitsTest : TestBase
{
    [Theory]
    [InlineData(PlanUpdateParamsDefaultTrialConfigUnits.Day)]
    [InlineData(PlanUpdateParamsDefaultTrialConfigUnits.Month)]
    public void Validation_Works(PlanUpdateParamsDefaultTrialConfigUnits rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanUpdateParamsDefaultTrialConfigUnits> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanUpdateParamsDefaultTrialConfigUnits>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PlanUpdateParamsDefaultTrialConfigUnits.Day)]
    [InlineData(PlanUpdateParamsDefaultTrialConfigUnits.Month)]
    public void SerializationRoundtrip_Works(PlanUpdateParamsDefaultTrialConfigUnits rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanUpdateParamsDefaultTrialConfigUnits> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanUpdateParamsDefaultTrialConfigUnits>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanUpdateParamsDefaultTrialConfigUnits>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanUpdateParamsDefaultTrialConfigUnits>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PlanUpdateParamsDefaultTrialConfigBudgetTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PlanUpdateParamsDefaultTrialConfigBudget { HasSoftLimit = true, Limit = 0 };

        bool expectedHasSoftLimit = true;
        double expectedLimit = 0;

        Assert.Equal(expectedHasSoftLimit, model.HasSoftLimit);
        Assert.Equal(expectedLimit, model.Limit);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PlanUpdateParamsDefaultTrialConfigBudget { HasSoftLimit = true, Limit = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanUpdateParamsDefaultTrialConfigBudget>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PlanUpdateParamsDefaultTrialConfigBudget { HasSoftLimit = true, Limit = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanUpdateParamsDefaultTrialConfigBudget>(
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
        var model = new PlanUpdateParamsDefaultTrialConfigBudget { HasSoftLimit = true, Limit = 0 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PlanUpdateParamsDefaultTrialConfigBudget { HasSoftLimit = true, Limit = 0 };

        PlanUpdateParamsDefaultTrialConfigBudget copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PlanUpdateParamsDefaultTrialConfigTrialEndBehaviorTest : TestBase
{
    [Theory]
    [InlineData(PlanUpdateParamsDefaultTrialConfigTrialEndBehavior.ConvertToPaid)]
    [InlineData(PlanUpdateParamsDefaultTrialConfigTrialEndBehavior.CancelSubscription)]
    public void Validation_Works(PlanUpdateParamsDefaultTrialConfigTrialEndBehavior rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanUpdateParamsDefaultTrialConfigTrialEndBehavior> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanUpdateParamsDefaultTrialConfigTrialEndBehavior>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PlanUpdateParamsDefaultTrialConfigTrialEndBehavior.ConvertToPaid)]
    [InlineData(PlanUpdateParamsDefaultTrialConfigTrialEndBehavior.CancelSubscription)]
    public void SerializationRoundtrip_Works(
        PlanUpdateParamsDefaultTrialConfigTrialEndBehavior rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanUpdateParamsDefaultTrialConfigTrialEndBehavior> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanUpdateParamsDefaultTrialConfigTrialEndBehavior>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanUpdateParamsDefaultTrialConfigTrialEndBehavior>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanUpdateParamsDefaultTrialConfigTrialEndBehavior>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
