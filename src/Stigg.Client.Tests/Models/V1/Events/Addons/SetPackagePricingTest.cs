using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Events.Addons;

namespace Stigg.Client.Tests.Models.V1.Events.Addons;

public class SetPackagePricingTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SetPackagePricing
        {
            PricingType = SetPackagePricingPricingType.Free,
            BillingID = "billingId",
            MinimumSpend =
            [
                new()
                {
                    BillingPeriod = SetPackagePricingMinimumSpendBillingPeriod.Monthly,
                    Minimum = new()
                    {
                        Amount = 0,
                        Currency = SetPackagePricingMinimumSpendMinimumCurrency.Usd,
                    },
                },
            ],
            OverageBillingPeriod = SetPackagePricingOverageBillingPeriod.OnSubscriptionRenewal,
            OveragePricingModels =
            [
                new()
                {
                    BillingModel = SetPackagePricingOveragePricingModelBillingModel.FlatFee,
                    PricePeriods =
                    [
                        new()
                        {
                            BillingPeriod =
                                SetPackagePricingOveragePricingModelPricePeriodBillingPeriod.Monthly,
                            BillingCountryCode = "billingCountryCode",
                            BlockSize = 0,
                            CreditGrantCadence =
                                SetPackagePricingOveragePricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                            CreditRate = new()
                            {
                                Amount = 1,
                                CurrencyID = "currencyId",
                                CostFormula = "costFormula",
                            },
                            Price = new()
                            {
                                Amount = 0,
                                Currency =
                                    SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Usd,
                            },
                            Tiers =
                            [
                                new()
                                {
                                    FlatPrice = new()
                                    {
                                        Amount = 0,
                                        Currency =
                                            SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Usd,
                                    },
                                    UnitPrice = new()
                                    {
                                        Amount = 0,
                                        Currency =
                                            SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Usd,
                                    },
                                    UpTo = 0,
                                },
                            ],
                        },
                    ],
                    BillingCadence = SetPackagePricingOveragePricingModelBillingCadence.Recurring,
                    Entitlement = new()
                    {
                        FeatureID = "featureId",
                        HasSoftLimit = true,
                        HasUnlimitedUsage = true,
                        MonthlyResetPeriodConfiguration = new(
                            SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                        ),
                        ResetPeriod =
                            SetPackagePricingOveragePricingModelEntitlementResetPeriod.Year,
                        UsageLimit = 0,
                        WeeklyResetPeriodConfiguration = new(
                            SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                        ),
                        YearlyResetPeriodConfiguration = new(
                            SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
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
                    BillingModel = SetPackagePricingPricingModelBillingModel.FlatFee,
                    PricePeriods =
                    [
                        new()
                        {
                            BillingPeriod =
                                SetPackagePricingPricingModelPricePeriodBillingPeriod.Monthly,
                            BillingCountryCode = "billingCountryCode",
                            BlockSize = 0,
                            CreditGrantCadence =
                                SetPackagePricingPricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                            CreditRate = new()
                            {
                                Amount = 1,
                                CurrencyID = "currencyId",
                                CostFormula = "costFormula",
                            },
                            Price = new()
                            {
                                Amount = 0,
                                Currency =
                                    SetPackagePricingPricingModelPricePeriodPriceCurrency.Usd,
                            },
                            Tiers =
                            [
                                new()
                                {
                                    FlatPrice = new()
                                    {
                                        Amount = 0,
                                        Currency =
                                            SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Usd,
                                    },
                                    UnitPrice = new()
                                    {
                                        Amount = 0,
                                        Currency =
                                            SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Usd,
                                    },
                                    UpTo = 0,
                                },
                            ],
                        },
                    ],
                    BillingCadence = SetPackagePricingPricingModelBillingCadence.Recurring,
                    FeatureID = "featureId",
                    MaxUnitQuantity = 1,
                    MinUnitQuantity = 1,
                    MonthlyResetPeriodConfiguration = new(
                        SetPackagePricingPricingModelMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    ResetPeriod = SetPackagePricingPricingModelResetPeriod.Year,
                    TiersMode = SetPackagePricingPricingModelTiersMode.Volume,
                    TopUpCustomCurrencyID = "topUpCustomCurrencyId",
                    WeeklyResetPeriodConfiguration = new(
                        SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    YearlyResetPeriodConfiguration = new(
                        SetPackagePricingPricingModelYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                },
            ],
        };

        ApiEnum<string, SetPackagePricingPricingType> expectedPricingType =
            SetPackagePricingPricingType.Free;
        string expectedBillingID = "billingId";
        List<SetPackagePricingMinimumSpend> expectedMinimumSpend =
        [
            new()
            {
                BillingPeriod = SetPackagePricingMinimumSpendBillingPeriod.Monthly,
                Minimum = new()
                {
                    Amount = 0,
                    Currency = SetPackagePricingMinimumSpendMinimumCurrency.Usd,
                },
            },
        ];
        ApiEnum<string, SetPackagePricingOverageBillingPeriod> expectedOverageBillingPeriod =
            SetPackagePricingOverageBillingPeriod.OnSubscriptionRenewal;
        List<SetPackagePricingOveragePricingModel> expectedOveragePricingModels =
        [
            new()
            {
                BillingModel = SetPackagePricingOveragePricingModelBillingModel.FlatFee,
                PricePeriods =
                [
                    new()
                    {
                        BillingPeriod =
                            SetPackagePricingOveragePricingModelPricePeriodBillingPeriod.Monthly,
                        BillingCountryCode = "billingCountryCode",
                        BlockSize = 0,
                        CreditGrantCadence =
                            SetPackagePricingOveragePricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                        CreditRate = new()
                        {
                            Amount = 1,
                            CurrencyID = "currencyId",
                            CostFormula = "costFormula",
                        },
                        Price = new()
                        {
                            Amount = 0,
                            Currency =
                                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Usd,
                        },
                        Tiers =
                        [
                            new()
                            {
                                FlatPrice = new()
                                {
                                    Amount = 0,
                                    Currency =
                                        SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Usd,
                                },
                                UnitPrice = new()
                                {
                                    Amount = 0,
                                    Currency =
                                        SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Usd,
                                },
                                UpTo = 0,
                            },
                        ],
                    },
                ],
                BillingCadence = SetPackagePricingOveragePricingModelBillingCadence.Recurring,
                Entitlement = new()
                {
                    FeatureID = "featureId",
                    HasSoftLimit = true,
                    HasUnlimitedUsage = true,
                    MonthlyResetPeriodConfiguration = new(
                        SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    ResetPeriod = SetPackagePricingOveragePricingModelEntitlementResetPeriod.Year,
                    UsageLimit = 0,
                    WeeklyResetPeriodConfiguration = new(
                        SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    YearlyResetPeriodConfiguration = new(
                        SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                },
                FeatureID = "featureId",
                TopUpCustomCurrencyID = "topUpCustomCurrencyId",
            },
        ];
        List<SetPackagePricingPricingModel> expectedPricingModels =
        [
            new()
            {
                BillingModel = SetPackagePricingPricingModelBillingModel.FlatFee,
                PricePeriods =
                [
                    new()
                    {
                        BillingPeriod =
                            SetPackagePricingPricingModelPricePeriodBillingPeriod.Monthly,
                        BillingCountryCode = "billingCountryCode",
                        BlockSize = 0,
                        CreditGrantCadence =
                            SetPackagePricingPricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                        CreditRate = new()
                        {
                            Amount = 1,
                            CurrencyID = "currencyId",
                            CostFormula = "costFormula",
                        },
                        Price = new()
                        {
                            Amount = 0,
                            Currency = SetPackagePricingPricingModelPricePeriodPriceCurrency.Usd,
                        },
                        Tiers =
                        [
                            new()
                            {
                                FlatPrice = new()
                                {
                                    Amount = 0,
                                    Currency =
                                        SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Usd,
                                },
                                UnitPrice = new()
                                {
                                    Amount = 0,
                                    Currency =
                                        SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Usd,
                                },
                                UpTo = 0,
                            },
                        ],
                    },
                ],
                BillingCadence = SetPackagePricingPricingModelBillingCadence.Recurring,
                FeatureID = "featureId",
                MaxUnitQuantity = 1,
                MinUnitQuantity = 1,
                MonthlyResetPeriodConfiguration = new(
                    SetPackagePricingPricingModelMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
                ResetPeriod = SetPackagePricingPricingModelResetPeriod.Year,
                TiersMode = SetPackagePricingPricingModelTiersMode.Volume,
                TopUpCustomCurrencyID = "topUpCustomCurrencyId",
                WeeklyResetPeriodConfiguration = new(
                    SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
                YearlyResetPeriodConfiguration = new(
                    SetPackagePricingPricingModelYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
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
        var model = new SetPackagePricing
        {
            PricingType = SetPackagePricingPricingType.Free,
            BillingID = "billingId",
            MinimumSpend =
            [
                new()
                {
                    BillingPeriod = SetPackagePricingMinimumSpendBillingPeriod.Monthly,
                    Minimum = new()
                    {
                        Amount = 0,
                        Currency = SetPackagePricingMinimumSpendMinimumCurrency.Usd,
                    },
                },
            ],
            OverageBillingPeriod = SetPackagePricingOverageBillingPeriod.OnSubscriptionRenewal,
            OveragePricingModels =
            [
                new()
                {
                    BillingModel = SetPackagePricingOveragePricingModelBillingModel.FlatFee,
                    PricePeriods =
                    [
                        new()
                        {
                            BillingPeriod =
                                SetPackagePricingOveragePricingModelPricePeriodBillingPeriod.Monthly,
                            BillingCountryCode = "billingCountryCode",
                            BlockSize = 0,
                            CreditGrantCadence =
                                SetPackagePricingOveragePricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                            CreditRate = new()
                            {
                                Amount = 1,
                                CurrencyID = "currencyId",
                                CostFormula = "costFormula",
                            },
                            Price = new()
                            {
                                Amount = 0,
                                Currency =
                                    SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Usd,
                            },
                            Tiers =
                            [
                                new()
                                {
                                    FlatPrice = new()
                                    {
                                        Amount = 0,
                                        Currency =
                                            SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Usd,
                                    },
                                    UnitPrice = new()
                                    {
                                        Amount = 0,
                                        Currency =
                                            SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Usd,
                                    },
                                    UpTo = 0,
                                },
                            ],
                        },
                    ],
                    BillingCadence = SetPackagePricingOveragePricingModelBillingCadence.Recurring,
                    Entitlement = new()
                    {
                        FeatureID = "featureId",
                        HasSoftLimit = true,
                        HasUnlimitedUsage = true,
                        MonthlyResetPeriodConfiguration = new(
                            SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                        ),
                        ResetPeriod =
                            SetPackagePricingOveragePricingModelEntitlementResetPeriod.Year,
                        UsageLimit = 0,
                        WeeklyResetPeriodConfiguration = new(
                            SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                        ),
                        YearlyResetPeriodConfiguration = new(
                            SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
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
                    BillingModel = SetPackagePricingPricingModelBillingModel.FlatFee,
                    PricePeriods =
                    [
                        new()
                        {
                            BillingPeriod =
                                SetPackagePricingPricingModelPricePeriodBillingPeriod.Monthly,
                            BillingCountryCode = "billingCountryCode",
                            BlockSize = 0,
                            CreditGrantCadence =
                                SetPackagePricingPricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                            CreditRate = new()
                            {
                                Amount = 1,
                                CurrencyID = "currencyId",
                                CostFormula = "costFormula",
                            },
                            Price = new()
                            {
                                Amount = 0,
                                Currency =
                                    SetPackagePricingPricingModelPricePeriodPriceCurrency.Usd,
                            },
                            Tiers =
                            [
                                new()
                                {
                                    FlatPrice = new()
                                    {
                                        Amount = 0,
                                        Currency =
                                            SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Usd,
                                    },
                                    UnitPrice = new()
                                    {
                                        Amount = 0,
                                        Currency =
                                            SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Usd,
                                    },
                                    UpTo = 0,
                                },
                            ],
                        },
                    ],
                    BillingCadence = SetPackagePricingPricingModelBillingCadence.Recurring,
                    FeatureID = "featureId",
                    MaxUnitQuantity = 1,
                    MinUnitQuantity = 1,
                    MonthlyResetPeriodConfiguration = new(
                        SetPackagePricingPricingModelMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    ResetPeriod = SetPackagePricingPricingModelResetPeriod.Year,
                    TiersMode = SetPackagePricingPricingModelTiersMode.Volume,
                    TopUpCustomCurrencyID = "topUpCustomCurrencyId",
                    WeeklyResetPeriodConfiguration = new(
                        SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    YearlyResetPeriodConfiguration = new(
                        SetPackagePricingPricingModelYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SetPackagePricing>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SetPackagePricing
        {
            PricingType = SetPackagePricingPricingType.Free,
            BillingID = "billingId",
            MinimumSpend =
            [
                new()
                {
                    BillingPeriod = SetPackagePricingMinimumSpendBillingPeriod.Monthly,
                    Minimum = new()
                    {
                        Amount = 0,
                        Currency = SetPackagePricingMinimumSpendMinimumCurrency.Usd,
                    },
                },
            ],
            OverageBillingPeriod = SetPackagePricingOverageBillingPeriod.OnSubscriptionRenewal,
            OveragePricingModels =
            [
                new()
                {
                    BillingModel = SetPackagePricingOveragePricingModelBillingModel.FlatFee,
                    PricePeriods =
                    [
                        new()
                        {
                            BillingPeriod =
                                SetPackagePricingOveragePricingModelPricePeriodBillingPeriod.Monthly,
                            BillingCountryCode = "billingCountryCode",
                            BlockSize = 0,
                            CreditGrantCadence =
                                SetPackagePricingOveragePricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                            CreditRate = new()
                            {
                                Amount = 1,
                                CurrencyID = "currencyId",
                                CostFormula = "costFormula",
                            },
                            Price = new()
                            {
                                Amount = 0,
                                Currency =
                                    SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Usd,
                            },
                            Tiers =
                            [
                                new()
                                {
                                    FlatPrice = new()
                                    {
                                        Amount = 0,
                                        Currency =
                                            SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Usd,
                                    },
                                    UnitPrice = new()
                                    {
                                        Amount = 0,
                                        Currency =
                                            SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Usd,
                                    },
                                    UpTo = 0,
                                },
                            ],
                        },
                    ],
                    BillingCadence = SetPackagePricingOveragePricingModelBillingCadence.Recurring,
                    Entitlement = new()
                    {
                        FeatureID = "featureId",
                        HasSoftLimit = true,
                        HasUnlimitedUsage = true,
                        MonthlyResetPeriodConfiguration = new(
                            SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                        ),
                        ResetPeriod =
                            SetPackagePricingOveragePricingModelEntitlementResetPeriod.Year,
                        UsageLimit = 0,
                        WeeklyResetPeriodConfiguration = new(
                            SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                        ),
                        YearlyResetPeriodConfiguration = new(
                            SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
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
                    BillingModel = SetPackagePricingPricingModelBillingModel.FlatFee,
                    PricePeriods =
                    [
                        new()
                        {
                            BillingPeriod =
                                SetPackagePricingPricingModelPricePeriodBillingPeriod.Monthly,
                            BillingCountryCode = "billingCountryCode",
                            BlockSize = 0,
                            CreditGrantCadence =
                                SetPackagePricingPricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                            CreditRate = new()
                            {
                                Amount = 1,
                                CurrencyID = "currencyId",
                                CostFormula = "costFormula",
                            },
                            Price = new()
                            {
                                Amount = 0,
                                Currency =
                                    SetPackagePricingPricingModelPricePeriodPriceCurrency.Usd,
                            },
                            Tiers =
                            [
                                new()
                                {
                                    FlatPrice = new()
                                    {
                                        Amount = 0,
                                        Currency =
                                            SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Usd,
                                    },
                                    UnitPrice = new()
                                    {
                                        Amount = 0,
                                        Currency =
                                            SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Usd,
                                    },
                                    UpTo = 0,
                                },
                            ],
                        },
                    ],
                    BillingCadence = SetPackagePricingPricingModelBillingCadence.Recurring,
                    FeatureID = "featureId",
                    MaxUnitQuantity = 1,
                    MinUnitQuantity = 1,
                    MonthlyResetPeriodConfiguration = new(
                        SetPackagePricingPricingModelMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    ResetPeriod = SetPackagePricingPricingModelResetPeriod.Year,
                    TiersMode = SetPackagePricingPricingModelTiersMode.Volume,
                    TopUpCustomCurrencyID = "topUpCustomCurrencyId",
                    WeeklyResetPeriodConfiguration = new(
                        SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    YearlyResetPeriodConfiguration = new(
                        SetPackagePricingPricingModelYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SetPackagePricing>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, SetPackagePricingPricingType> expectedPricingType =
            SetPackagePricingPricingType.Free;
        string expectedBillingID = "billingId";
        List<SetPackagePricingMinimumSpend> expectedMinimumSpend =
        [
            new()
            {
                BillingPeriod = SetPackagePricingMinimumSpendBillingPeriod.Monthly,
                Minimum = new()
                {
                    Amount = 0,
                    Currency = SetPackagePricingMinimumSpendMinimumCurrency.Usd,
                },
            },
        ];
        ApiEnum<string, SetPackagePricingOverageBillingPeriod> expectedOverageBillingPeriod =
            SetPackagePricingOverageBillingPeriod.OnSubscriptionRenewal;
        List<SetPackagePricingOveragePricingModel> expectedOveragePricingModels =
        [
            new()
            {
                BillingModel = SetPackagePricingOveragePricingModelBillingModel.FlatFee,
                PricePeriods =
                [
                    new()
                    {
                        BillingPeriod =
                            SetPackagePricingOveragePricingModelPricePeriodBillingPeriod.Monthly,
                        BillingCountryCode = "billingCountryCode",
                        BlockSize = 0,
                        CreditGrantCadence =
                            SetPackagePricingOveragePricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                        CreditRate = new()
                        {
                            Amount = 1,
                            CurrencyID = "currencyId",
                            CostFormula = "costFormula",
                        },
                        Price = new()
                        {
                            Amount = 0,
                            Currency =
                                SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Usd,
                        },
                        Tiers =
                        [
                            new()
                            {
                                FlatPrice = new()
                                {
                                    Amount = 0,
                                    Currency =
                                        SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Usd,
                                },
                                UnitPrice = new()
                                {
                                    Amount = 0,
                                    Currency =
                                        SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Usd,
                                },
                                UpTo = 0,
                            },
                        ],
                    },
                ],
                BillingCadence = SetPackagePricingOveragePricingModelBillingCadence.Recurring,
                Entitlement = new()
                {
                    FeatureID = "featureId",
                    HasSoftLimit = true,
                    HasUnlimitedUsage = true,
                    MonthlyResetPeriodConfiguration = new(
                        SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    ResetPeriod = SetPackagePricingOveragePricingModelEntitlementResetPeriod.Year,
                    UsageLimit = 0,
                    WeeklyResetPeriodConfiguration = new(
                        SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    YearlyResetPeriodConfiguration = new(
                        SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                },
                FeatureID = "featureId",
                TopUpCustomCurrencyID = "topUpCustomCurrencyId",
            },
        ];
        List<SetPackagePricingPricingModel> expectedPricingModels =
        [
            new()
            {
                BillingModel = SetPackagePricingPricingModelBillingModel.FlatFee,
                PricePeriods =
                [
                    new()
                    {
                        BillingPeriod =
                            SetPackagePricingPricingModelPricePeriodBillingPeriod.Monthly,
                        BillingCountryCode = "billingCountryCode",
                        BlockSize = 0,
                        CreditGrantCadence =
                            SetPackagePricingPricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                        CreditRate = new()
                        {
                            Amount = 1,
                            CurrencyID = "currencyId",
                            CostFormula = "costFormula",
                        },
                        Price = new()
                        {
                            Amount = 0,
                            Currency = SetPackagePricingPricingModelPricePeriodPriceCurrency.Usd,
                        },
                        Tiers =
                        [
                            new()
                            {
                                FlatPrice = new()
                                {
                                    Amount = 0,
                                    Currency =
                                        SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Usd,
                                },
                                UnitPrice = new()
                                {
                                    Amount = 0,
                                    Currency =
                                        SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Usd,
                                },
                                UpTo = 0,
                            },
                        ],
                    },
                ],
                BillingCadence = SetPackagePricingPricingModelBillingCadence.Recurring,
                FeatureID = "featureId",
                MaxUnitQuantity = 1,
                MinUnitQuantity = 1,
                MonthlyResetPeriodConfiguration = new(
                    SetPackagePricingPricingModelMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
                ResetPeriod = SetPackagePricingPricingModelResetPeriod.Year,
                TiersMode = SetPackagePricingPricingModelTiersMode.Volume,
                TopUpCustomCurrencyID = "topUpCustomCurrencyId",
                WeeklyResetPeriodConfiguration = new(
                    SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
                YearlyResetPeriodConfiguration = new(
                    SetPackagePricingPricingModelYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
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
        var model = new SetPackagePricing
        {
            PricingType = SetPackagePricingPricingType.Free,
            BillingID = "billingId",
            MinimumSpend =
            [
                new()
                {
                    BillingPeriod = SetPackagePricingMinimumSpendBillingPeriod.Monthly,
                    Minimum = new()
                    {
                        Amount = 0,
                        Currency = SetPackagePricingMinimumSpendMinimumCurrency.Usd,
                    },
                },
            ],
            OverageBillingPeriod = SetPackagePricingOverageBillingPeriod.OnSubscriptionRenewal,
            OveragePricingModels =
            [
                new()
                {
                    BillingModel = SetPackagePricingOveragePricingModelBillingModel.FlatFee,
                    PricePeriods =
                    [
                        new()
                        {
                            BillingPeriod =
                                SetPackagePricingOveragePricingModelPricePeriodBillingPeriod.Monthly,
                            BillingCountryCode = "billingCountryCode",
                            BlockSize = 0,
                            CreditGrantCadence =
                                SetPackagePricingOveragePricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                            CreditRate = new()
                            {
                                Amount = 1,
                                CurrencyID = "currencyId",
                                CostFormula = "costFormula",
                            },
                            Price = new()
                            {
                                Amount = 0,
                                Currency =
                                    SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Usd,
                            },
                            Tiers =
                            [
                                new()
                                {
                                    FlatPrice = new()
                                    {
                                        Amount = 0,
                                        Currency =
                                            SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Usd,
                                    },
                                    UnitPrice = new()
                                    {
                                        Amount = 0,
                                        Currency =
                                            SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Usd,
                                    },
                                    UpTo = 0,
                                },
                            ],
                        },
                    ],
                    BillingCadence = SetPackagePricingOveragePricingModelBillingCadence.Recurring,
                    Entitlement = new()
                    {
                        FeatureID = "featureId",
                        HasSoftLimit = true,
                        HasUnlimitedUsage = true,
                        MonthlyResetPeriodConfiguration = new(
                            SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                        ),
                        ResetPeriod =
                            SetPackagePricingOveragePricingModelEntitlementResetPeriod.Year,
                        UsageLimit = 0,
                        WeeklyResetPeriodConfiguration = new(
                            SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                        ),
                        YearlyResetPeriodConfiguration = new(
                            SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
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
                    BillingModel = SetPackagePricingPricingModelBillingModel.FlatFee,
                    PricePeriods =
                    [
                        new()
                        {
                            BillingPeriod =
                                SetPackagePricingPricingModelPricePeriodBillingPeriod.Monthly,
                            BillingCountryCode = "billingCountryCode",
                            BlockSize = 0,
                            CreditGrantCadence =
                                SetPackagePricingPricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                            CreditRate = new()
                            {
                                Amount = 1,
                                CurrencyID = "currencyId",
                                CostFormula = "costFormula",
                            },
                            Price = new()
                            {
                                Amount = 0,
                                Currency =
                                    SetPackagePricingPricingModelPricePeriodPriceCurrency.Usd,
                            },
                            Tiers =
                            [
                                new()
                                {
                                    FlatPrice = new()
                                    {
                                        Amount = 0,
                                        Currency =
                                            SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Usd,
                                    },
                                    UnitPrice = new()
                                    {
                                        Amount = 0,
                                        Currency =
                                            SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Usd,
                                    },
                                    UpTo = 0,
                                },
                            ],
                        },
                    ],
                    BillingCadence = SetPackagePricingPricingModelBillingCadence.Recurring,
                    FeatureID = "featureId",
                    MaxUnitQuantity = 1,
                    MinUnitQuantity = 1,
                    MonthlyResetPeriodConfiguration = new(
                        SetPackagePricingPricingModelMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    ResetPeriod = SetPackagePricingPricingModelResetPeriod.Year,
                    TiersMode = SetPackagePricingPricingModelTiersMode.Volume,
                    TopUpCustomCurrencyID = "topUpCustomCurrencyId",
                    WeeklyResetPeriodConfiguration = new(
                        SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    YearlyResetPeriodConfiguration = new(
                        SetPackagePricingPricingModelYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SetPackagePricing
        {
            PricingType = SetPackagePricingPricingType.Free,
            MinimumSpend =
            [
                new()
                {
                    BillingPeriod = SetPackagePricingMinimumSpendBillingPeriod.Monthly,
                    Minimum = new()
                    {
                        Amount = 0,
                        Currency = SetPackagePricingMinimumSpendMinimumCurrency.Usd,
                    },
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
        var model = new SetPackagePricing
        {
            PricingType = SetPackagePricingPricingType.Free,
            MinimumSpend =
            [
                new()
                {
                    BillingPeriod = SetPackagePricingMinimumSpendBillingPeriod.Monthly,
                    Minimum = new()
                    {
                        Amount = 0,
                        Currency = SetPackagePricingMinimumSpendMinimumCurrency.Usd,
                    },
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SetPackagePricing
        {
            PricingType = SetPackagePricingPricingType.Free,
            MinimumSpend =
            [
                new()
                {
                    BillingPeriod = SetPackagePricingMinimumSpendBillingPeriod.Monthly,
                    Minimum = new()
                    {
                        Amount = 0,
                        Currency = SetPackagePricingMinimumSpendMinimumCurrency.Usd,
                    },
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
        var model = new SetPackagePricing
        {
            PricingType = SetPackagePricingPricingType.Free,
            MinimumSpend =
            [
                new()
                {
                    BillingPeriod = SetPackagePricingMinimumSpendBillingPeriod.Monthly,
                    Minimum = new()
                    {
                        Amount = 0,
                        Currency = SetPackagePricingMinimumSpendMinimumCurrency.Usd,
                    },
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
        var model = new SetPackagePricing
        {
            PricingType = SetPackagePricingPricingType.Free,
            BillingID = "billingId",
            OverageBillingPeriod = SetPackagePricingOverageBillingPeriod.OnSubscriptionRenewal,
            OveragePricingModels =
            [
                new()
                {
                    BillingModel = SetPackagePricingOveragePricingModelBillingModel.FlatFee,
                    PricePeriods =
                    [
                        new()
                        {
                            BillingPeriod =
                                SetPackagePricingOveragePricingModelPricePeriodBillingPeriod.Monthly,
                            BillingCountryCode = "billingCountryCode",
                            BlockSize = 0,
                            CreditGrantCadence =
                                SetPackagePricingOveragePricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                            CreditRate = new()
                            {
                                Amount = 1,
                                CurrencyID = "currencyId",
                                CostFormula = "costFormula",
                            },
                            Price = new()
                            {
                                Amount = 0,
                                Currency =
                                    SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Usd,
                            },
                            Tiers =
                            [
                                new()
                                {
                                    FlatPrice = new()
                                    {
                                        Amount = 0,
                                        Currency =
                                            SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Usd,
                                    },
                                    UnitPrice = new()
                                    {
                                        Amount = 0,
                                        Currency =
                                            SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Usd,
                                    },
                                    UpTo = 0,
                                },
                            ],
                        },
                    ],
                    BillingCadence = SetPackagePricingOveragePricingModelBillingCadence.Recurring,
                    Entitlement = new()
                    {
                        FeatureID = "featureId",
                        HasSoftLimit = true,
                        HasUnlimitedUsage = true,
                        MonthlyResetPeriodConfiguration = new(
                            SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                        ),
                        ResetPeriod =
                            SetPackagePricingOveragePricingModelEntitlementResetPeriod.Year,
                        UsageLimit = 0,
                        WeeklyResetPeriodConfiguration = new(
                            SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                        ),
                        YearlyResetPeriodConfiguration = new(
                            SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
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
                    BillingModel = SetPackagePricingPricingModelBillingModel.FlatFee,
                    PricePeriods =
                    [
                        new()
                        {
                            BillingPeriod =
                                SetPackagePricingPricingModelPricePeriodBillingPeriod.Monthly,
                            BillingCountryCode = "billingCountryCode",
                            BlockSize = 0,
                            CreditGrantCadence =
                                SetPackagePricingPricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                            CreditRate = new()
                            {
                                Amount = 1,
                                CurrencyID = "currencyId",
                                CostFormula = "costFormula",
                            },
                            Price = new()
                            {
                                Amount = 0,
                                Currency =
                                    SetPackagePricingPricingModelPricePeriodPriceCurrency.Usd,
                            },
                            Tiers =
                            [
                                new()
                                {
                                    FlatPrice = new()
                                    {
                                        Amount = 0,
                                        Currency =
                                            SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Usd,
                                    },
                                    UnitPrice = new()
                                    {
                                        Amount = 0,
                                        Currency =
                                            SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Usd,
                                    },
                                    UpTo = 0,
                                },
                            ],
                        },
                    ],
                    BillingCadence = SetPackagePricingPricingModelBillingCadence.Recurring,
                    FeatureID = "featureId",
                    MaxUnitQuantity = 1,
                    MinUnitQuantity = 1,
                    MonthlyResetPeriodConfiguration = new(
                        SetPackagePricingPricingModelMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    ResetPeriod = SetPackagePricingPricingModelResetPeriod.Year,
                    TiersMode = SetPackagePricingPricingModelTiersMode.Volume,
                    TopUpCustomCurrencyID = "topUpCustomCurrencyId",
                    WeeklyResetPeriodConfiguration = new(
                        SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    YearlyResetPeriodConfiguration = new(
                        SetPackagePricingPricingModelYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
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
        var model = new SetPackagePricing
        {
            PricingType = SetPackagePricingPricingType.Free,
            BillingID = "billingId",
            OverageBillingPeriod = SetPackagePricingOverageBillingPeriod.OnSubscriptionRenewal,
            OveragePricingModels =
            [
                new()
                {
                    BillingModel = SetPackagePricingOveragePricingModelBillingModel.FlatFee,
                    PricePeriods =
                    [
                        new()
                        {
                            BillingPeriod =
                                SetPackagePricingOveragePricingModelPricePeriodBillingPeriod.Monthly,
                            BillingCountryCode = "billingCountryCode",
                            BlockSize = 0,
                            CreditGrantCadence =
                                SetPackagePricingOveragePricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                            CreditRate = new()
                            {
                                Amount = 1,
                                CurrencyID = "currencyId",
                                CostFormula = "costFormula",
                            },
                            Price = new()
                            {
                                Amount = 0,
                                Currency =
                                    SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Usd,
                            },
                            Tiers =
                            [
                                new()
                                {
                                    FlatPrice = new()
                                    {
                                        Amount = 0,
                                        Currency =
                                            SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Usd,
                                    },
                                    UnitPrice = new()
                                    {
                                        Amount = 0,
                                        Currency =
                                            SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Usd,
                                    },
                                    UpTo = 0,
                                },
                            ],
                        },
                    ],
                    BillingCadence = SetPackagePricingOveragePricingModelBillingCadence.Recurring,
                    Entitlement = new()
                    {
                        FeatureID = "featureId",
                        HasSoftLimit = true,
                        HasUnlimitedUsage = true,
                        MonthlyResetPeriodConfiguration = new(
                            SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                        ),
                        ResetPeriod =
                            SetPackagePricingOveragePricingModelEntitlementResetPeriod.Year,
                        UsageLimit = 0,
                        WeeklyResetPeriodConfiguration = new(
                            SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                        ),
                        YearlyResetPeriodConfiguration = new(
                            SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
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
                    BillingModel = SetPackagePricingPricingModelBillingModel.FlatFee,
                    PricePeriods =
                    [
                        new()
                        {
                            BillingPeriod =
                                SetPackagePricingPricingModelPricePeriodBillingPeriod.Monthly,
                            BillingCountryCode = "billingCountryCode",
                            BlockSize = 0,
                            CreditGrantCadence =
                                SetPackagePricingPricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                            CreditRate = new()
                            {
                                Amount = 1,
                                CurrencyID = "currencyId",
                                CostFormula = "costFormula",
                            },
                            Price = new()
                            {
                                Amount = 0,
                                Currency =
                                    SetPackagePricingPricingModelPricePeriodPriceCurrency.Usd,
                            },
                            Tiers =
                            [
                                new()
                                {
                                    FlatPrice = new()
                                    {
                                        Amount = 0,
                                        Currency =
                                            SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Usd,
                                    },
                                    UnitPrice = new()
                                    {
                                        Amount = 0,
                                        Currency =
                                            SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Usd,
                                    },
                                    UpTo = 0,
                                },
                            ],
                        },
                    ],
                    BillingCadence = SetPackagePricingPricingModelBillingCadence.Recurring,
                    FeatureID = "featureId",
                    MaxUnitQuantity = 1,
                    MinUnitQuantity = 1,
                    MonthlyResetPeriodConfiguration = new(
                        SetPackagePricingPricingModelMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    ResetPeriod = SetPackagePricingPricingModelResetPeriod.Year,
                    TiersMode = SetPackagePricingPricingModelTiersMode.Volume,
                    TopUpCustomCurrencyID = "topUpCustomCurrencyId",
                    WeeklyResetPeriodConfiguration = new(
                        SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    YearlyResetPeriodConfiguration = new(
                        SetPackagePricingPricingModelYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SetPackagePricing
        {
            PricingType = SetPackagePricingPricingType.Free,
            BillingID = "billingId",
            OverageBillingPeriod = SetPackagePricingOverageBillingPeriod.OnSubscriptionRenewal,
            OveragePricingModels =
            [
                new()
                {
                    BillingModel = SetPackagePricingOveragePricingModelBillingModel.FlatFee,
                    PricePeriods =
                    [
                        new()
                        {
                            BillingPeriod =
                                SetPackagePricingOveragePricingModelPricePeriodBillingPeriod.Monthly,
                            BillingCountryCode = "billingCountryCode",
                            BlockSize = 0,
                            CreditGrantCadence =
                                SetPackagePricingOveragePricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                            CreditRate = new()
                            {
                                Amount = 1,
                                CurrencyID = "currencyId",
                                CostFormula = "costFormula",
                            },
                            Price = new()
                            {
                                Amount = 0,
                                Currency =
                                    SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Usd,
                            },
                            Tiers =
                            [
                                new()
                                {
                                    FlatPrice = new()
                                    {
                                        Amount = 0,
                                        Currency =
                                            SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Usd,
                                    },
                                    UnitPrice = new()
                                    {
                                        Amount = 0,
                                        Currency =
                                            SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Usd,
                                    },
                                    UpTo = 0,
                                },
                            ],
                        },
                    ],
                    BillingCadence = SetPackagePricingOveragePricingModelBillingCadence.Recurring,
                    Entitlement = new()
                    {
                        FeatureID = "featureId",
                        HasSoftLimit = true,
                        HasUnlimitedUsage = true,
                        MonthlyResetPeriodConfiguration = new(
                            SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                        ),
                        ResetPeriod =
                            SetPackagePricingOveragePricingModelEntitlementResetPeriod.Year,
                        UsageLimit = 0,
                        WeeklyResetPeriodConfiguration = new(
                            SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                        ),
                        YearlyResetPeriodConfiguration = new(
                            SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
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
                    BillingModel = SetPackagePricingPricingModelBillingModel.FlatFee,
                    PricePeriods =
                    [
                        new()
                        {
                            BillingPeriod =
                                SetPackagePricingPricingModelPricePeriodBillingPeriod.Monthly,
                            BillingCountryCode = "billingCountryCode",
                            BlockSize = 0,
                            CreditGrantCadence =
                                SetPackagePricingPricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                            CreditRate = new()
                            {
                                Amount = 1,
                                CurrencyID = "currencyId",
                                CostFormula = "costFormula",
                            },
                            Price = new()
                            {
                                Amount = 0,
                                Currency =
                                    SetPackagePricingPricingModelPricePeriodPriceCurrency.Usd,
                            },
                            Tiers =
                            [
                                new()
                                {
                                    FlatPrice = new()
                                    {
                                        Amount = 0,
                                        Currency =
                                            SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Usd,
                                    },
                                    UnitPrice = new()
                                    {
                                        Amount = 0,
                                        Currency =
                                            SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Usd,
                                    },
                                    UpTo = 0,
                                },
                            ],
                        },
                    ],
                    BillingCadence = SetPackagePricingPricingModelBillingCadence.Recurring,
                    FeatureID = "featureId",
                    MaxUnitQuantity = 1,
                    MinUnitQuantity = 1,
                    MonthlyResetPeriodConfiguration = new(
                        SetPackagePricingPricingModelMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    ResetPeriod = SetPackagePricingPricingModelResetPeriod.Year,
                    TiersMode = SetPackagePricingPricingModelTiersMode.Volume,
                    TopUpCustomCurrencyID = "topUpCustomCurrencyId",
                    WeeklyResetPeriodConfiguration = new(
                        SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    YearlyResetPeriodConfiguration = new(
                        SetPackagePricingPricingModelYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
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
        var model = new SetPackagePricing
        {
            PricingType = SetPackagePricingPricingType.Free,
            BillingID = "billingId",
            OverageBillingPeriod = SetPackagePricingOverageBillingPeriod.OnSubscriptionRenewal,
            OveragePricingModels =
            [
                new()
                {
                    BillingModel = SetPackagePricingOveragePricingModelBillingModel.FlatFee,
                    PricePeriods =
                    [
                        new()
                        {
                            BillingPeriod =
                                SetPackagePricingOveragePricingModelPricePeriodBillingPeriod.Monthly,
                            BillingCountryCode = "billingCountryCode",
                            BlockSize = 0,
                            CreditGrantCadence =
                                SetPackagePricingOveragePricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                            CreditRate = new()
                            {
                                Amount = 1,
                                CurrencyID = "currencyId",
                                CostFormula = "costFormula",
                            },
                            Price = new()
                            {
                                Amount = 0,
                                Currency =
                                    SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Usd,
                            },
                            Tiers =
                            [
                                new()
                                {
                                    FlatPrice = new()
                                    {
                                        Amount = 0,
                                        Currency =
                                            SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Usd,
                                    },
                                    UnitPrice = new()
                                    {
                                        Amount = 0,
                                        Currency =
                                            SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Usd,
                                    },
                                    UpTo = 0,
                                },
                            ],
                        },
                    ],
                    BillingCadence = SetPackagePricingOveragePricingModelBillingCadence.Recurring,
                    Entitlement = new()
                    {
                        FeatureID = "featureId",
                        HasSoftLimit = true,
                        HasUnlimitedUsage = true,
                        MonthlyResetPeriodConfiguration = new(
                            SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                        ),
                        ResetPeriod =
                            SetPackagePricingOveragePricingModelEntitlementResetPeriod.Year,
                        UsageLimit = 0,
                        WeeklyResetPeriodConfiguration = new(
                            SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                        ),
                        YearlyResetPeriodConfiguration = new(
                            SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
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
                    BillingModel = SetPackagePricingPricingModelBillingModel.FlatFee,
                    PricePeriods =
                    [
                        new()
                        {
                            BillingPeriod =
                                SetPackagePricingPricingModelPricePeriodBillingPeriod.Monthly,
                            BillingCountryCode = "billingCountryCode",
                            BlockSize = 0,
                            CreditGrantCadence =
                                SetPackagePricingPricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                            CreditRate = new()
                            {
                                Amount = 1,
                                CurrencyID = "currencyId",
                                CostFormula = "costFormula",
                            },
                            Price = new()
                            {
                                Amount = 0,
                                Currency =
                                    SetPackagePricingPricingModelPricePeriodPriceCurrency.Usd,
                            },
                            Tiers =
                            [
                                new()
                                {
                                    FlatPrice = new()
                                    {
                                        Amount = 0,
                                        Currency =
                                            SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Usd,
                                    },
                                    UnitPrice = new()
                                    {
                                        Amount = 0,
                                        Currency =
                                            SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Usd,
                                    },
                                    UpTo = 0,
                                },
                            ],
                        },
                    ],
                    BillingCadence = SetPackagePricingPricingModelBillingCadence.Recurring,
                    FeatureID = "featureId",
                    MaxUnitQuantity = 1,
                    MinUnitQuantity = 1,
                    MonthlyResetPeriodConfiguration = new(
                        SetPackagePricingPricingModelMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    ResetPeriod = SetPackagePricingPricingModelResetPeriod.Year,
                    TiersMode = SetPackagePricingPricingModelTiersMode.Volume,
                    TopUpCustomCurrencyID = "topUpCustomCurrencyId",
                    WeeklyResetPeriodConfiguration = new(
                        SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    YearlyResetPeriodConfiguration = new(
                        SetPackagePricingPricingModelYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
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
        var model = new SetPackagePricing
        {
            PricingType = SetPackagePricingPricingType.Free,
            BillingID = "billingId",
            MinimumSpend =
            [
                new()
                {
                    BillingPeriod = SetPackagePricingMinimumSpendBillingPeriod.Monthly,
                    Minimum = new()
                    {
                        Amount = 0,
                        Currency = SetPackagePricingMinimumSpendMinimumCurrency.Usd,
                    },
                },
            ],
            OverageBillingPeriod = SetPackagePricingOverageBillingPeriod.OnSubscriptionRenewal,
            OveragePricingModels =
            [
                new()
                {
                    BillingModel = SetPackagePricingOveragePricingModelBillingModel.FlatFee,
                    PricePeriods =
                    [
                        new()
                        {
                            BillingPeriod =
                                SetPackagePricingOveragePricingModelPricePeriodBillingPeriod.Monthly,
                            BillingCountryCode = "billingCountryCode",
                            BlockSize = 0,
                            CreditGrantCadence =
                                SetPackagePricingOveragePricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                            CreditRate = new()
                            {
                                Amount = 1,
                                CurrencyID = "currencyId",
                                CostFormula = "costFormula",
                            },
                            Price = new()
                            {
                                Amount = 0,
                                Currency =
                                    SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Usd,
                            },
                            Tiers =
                            [
                                new()
                                {
                                    FlatPrice = new()
                                    {
                                        Amount = 0,
                                        Currency =
                                            SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Usd,
                                    },
                                    UnitPrice = new()
                                    {
                                        Amount = 0,
                                        Currency =
                                            SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Usd,
                                    },
                                    UpTo = 0,
                                },
                            ],
                        },
                    ],
                    BillingCadence = SetPackagePricingOveragePricingModelBillingCadence.Recurring,
                    Entitlement = new()
                    {
                        FeatureID = "featureId",
                        HasSoftLimit = true,
                        HasUnlimitedUsage = true,
                        MonthlyResetPeriodConfiguration = new(
                            SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                        ),
                        ResetPeriod =
                            SetPackagePricingOveragePricingModelEntitlementResetPeriod.Year,
                        UsageLimit = 0,
                        WeeklyResetPeriodConfiguration = new(
                            SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                        ),
                        YearlyResetPeriodConfiguration = new(
                            SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
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
                    BillingModel = SetPackagePricingPricingModelBillingModel.FlatFee,
                    PricePeriods =
                    [
                        new()
                        {
                            BillingPeriod =
                                SetPackagePricingPricingModelPricePeriodBillingPeriod.Monthly,
                            BillingCountryCode = "billingCountryCode",
                            BlockSize = 0,
                            CreditGrantCadence =
                                SetPackagePricingPricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                            CreditRate = new()
                            {
                                Amount = 1,
                                CurrencyID = "currencyId",
                                CostFormula = "costFormula",
                            },
                            Price = new()
                            {
                                Amount = 0,
                                Currency =
                                    SetPackagePricingPricingModelPricePeriodPriceCurrency.Usd,
                            },
                            Tiers =
                            [
                                new()
                                {
                                    FlatPrice = new()
                                    {
                                        Amount = 0,
                                        Currency =
                                            SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Usd,
                                    },
                                    UnitPrice = new()
                                    {
                                        Amount = 0,
                                        Currency =
                                            SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Usd,
                                    },
                                    UpTo = 0,
                                },
                            ],
                        },
                    ],
                    BillingCadence = SetPackagePricingPricingModelBillingCadence.Recurring,
                    FeatureID = "featureId",
                    MaxUnitQuantity = 1,
                    MinUnitQuantity = 1,
                    MonthlyResetPeriodConfiguration = new(
                        SetPackagePricingPricingModelMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    ResetPeriod = SetPackagePricingPricingModelResetPeriod.Year,
                    TiersMode = SetPackagePricingPricingModelTiersMode.Volume,
                    TopUpCustomCurrencyID = "topUpCustomCurrencyId",
                    WeeklyResetPeriodConfiguration = new(
                        SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    YearlyResetPeriodConfiguration = new(
                        SetPackagePricingPricingModelYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                },
            ],
        };

        SetPackagePricing copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SetPackagePricingPricingTypeTest : TestBase
{
    [Theory]
    [InlineData(SetPackagePricingPricingType.Free)]
    [InlineData(SetPackagePricingPricingType.Paid)]
    [InlineData(SetPackagePricingPricingType.Custom)]
    public void Validation_Works(SetPackagePricingPricingType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SetPackagePricingPricingType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SetPackagePricingPricingType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SetPackagePricingPricingType.Free)]
    [InlineData(SetPackagePricingPricingType.Paid)]
    [InlineData(SetPackagePricingPricingType.Custom)]
    public void SerializationRoundtrip_Works(SetPackagePricingPricingType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SetPackagePricingPricingType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingPricingType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SetPackagePricingPricingType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingPricingType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SetPackagePricingMinimumSpendTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SetPackagePricingMinimumSpend
        {
            BillingPeriod = SetPackagePricingMinimumSpendBillingPeriod.Monthly,
            Minimum = new()
            {
                Amount = 0,
                Currency = SetPackagePricingMinimumSpendMinimumCurrency.Usd,
            },
        };

        ApiEnum<string, SetPackagePricingMinimumSpendBillingPeriod> expectedBillingPeriod =
            SetPackagePricingMinimumSpendBillingPeriod.Monthly;
        SetPackagePricingMinimumSpendMinimum expectedMinimum = new()
        {
            Amount = 0,
            Currency = SetPackagePricingMinimumSpendMinimumCurrency.Usd,
        };

        Assert.Equal(expectedBillingPeriod, model.BillingPeriod);
        Assert.Equal(expectedMinimum, model.Minimum);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SetPackagePricingMinimumSpend
        {
            BillingPeriod = SetPackagePricingMinimumSpendBillingPeriod.Monthly,
            Minimum = new()
            {
                Amount = 0,
                Currency = SetPackagePricingMinimumSpendMinimumCurrency.Usd,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SetPackagePricingMinimumSpend>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SetPackagePricingMinimumSpend
        {
            BillingPeriod = SetPackagePricingMinimumSpendBillingPeriod.Monthly,
            Minimum = new()
            {
                Amount = 0,
                Currency = SetPackagePricingMinimumSpendMinimumCurrency.Usd,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SetPackagePricingMinimumSpend>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, SetPackagePricingMinimumSpendBillingPeriod> expectedBillingPeriod =
            SetPackagePricingMinimumSpendBillingPeriod.Monthly;
        SetPackagePricingMinimumSpendMinimum expectedMinimum = new()
        {
            Amount = 0,
            Currency = SetPackagePricingMinimumSpendMinimumCurrency.Usd,
        };

        Assert.Equal(expectedBillingPeriod, deserialized.BillingPeriod);
        Assert.Equal(expectedMinimum, deserialized.Minimum);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SetPackagePricingMinimumSpend
        {
            BillingPeriod = SetPackagePricingMinimumSpendBillingPeriod.Monthly,
            Minimum = new()
            {
                Amount = 0,
                Currency = SetPackagePricingMinimumSpendMinimumCurrency.Usd,
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SetPackagePricingMinimumSpend
        {
            BillingPeriod = SetPackagePricingMinimumSpendBillingPeriod.Monthly,
            Minimum = new()
            {
                Amount = 0,
                Currency = SetPackagePricingMinimumSpendMinimumCurrency.Usd,
            },
        };

        SetPackagePricingMinimumSpend copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SetPackagePricingMinimumSpendBillingPeriodTest : TestBase
{
    [Theory]
    [InlineData(SetPackagePricingMinimumSpendBillingPeriod.Monthly)]
    [InlineData(SetPackagePricingMinimumSpendBillingPeriod.Annually)]
    public void Validation_Works(SetPackagePricingMinimumSpendBillingPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SetPackagePricingMinimumSpendBillingPeriod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingMinimumSpendBillingPeriod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SetPackagePricingMinimumSpendBillingPeriod.Monthly)]
    [InlineData(SetPackagePricingMinimumSpendBillingPeriod.Annually)]
    public void SerializationRoundtrip_Works(SetPackagePricingMinimumSpendBillingPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SetPackagePricingMinimumSpendBillingPeriod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingMinimumSpendBillingPeriod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingMinimumSpendBillingPeriod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingMinimumSpendBillingPeriod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SetPackagePricingMinimumSpendMinimumTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SetPackagePricingMinimumSpendMinimum
        {
            Amount = 0,
            Currency = SetPackagePricingMinimumSpendMinimumCurrency.Usd,
        };

        double expectedAmount = 0;
        ApiEnum<string, SetPackagePricingMinimumSpendMinimumCurrency> expectedCurrency =
            SetPackagePricingMinimumSpendMinimumCurrency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SetPackagePricingMinimumSpendMinimum
        {
            Amount = 0,
            Currency = SetPackagePricingMinimumSpendMinimumCurrency.Usd,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SetPackagePricingMinimumSpendMinimum>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SetPackagePricingMinimumSpendMinimum
        {
            Amount = 0,
            Currency = SetPackagePricingMinimumSpendMinimumCurrency.Usd,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SetPackagePricingMinimumSpendMinimum>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        ApiEnum<string, SetPackagePricingMinimumSpendMinimumCurrency> expectedCurrency =
            SetPackagePricingMinimumSpendMinimumCurrency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SetPackagePricingMinimumSpendMinimum
        {
            Amount = 0,
            Currency = SetPackagePricingMinimumSpendMinimumCurrency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SetPackagePricingMinimumSpendMinimum { Amount = 0 };

        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SetPackagePricingMinimumSpendMinimum { Amount = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SetPackagePricingMinimumSpendMinimum
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
        var model = new SetPackagePricingMinimumSpendMinimum
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
        var model = new SetPackagePricingMinimumSpendMinimum
        {
            Amount = 0,
            Currency = SetPackagePricingMinimumSpendMinimumCurrency.Usd,
        };

        SetPackagePricingMinimumSpendMinimum copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SetPackagePricingMinimumSpendMinimumCurrencyTest : TestBase
{
    [Theory]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Usd)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Aed)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.All)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Amd)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Ang)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Aud)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Awg)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Azn)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Bam)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Bbd)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Bdt)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Bgn)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Bif)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Bmd)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Bnd)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Bsd)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Bwp)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Byn)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Bzd)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Brl)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Cad)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Cdf)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Chf)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Cny)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Czk)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Dkk)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Dop)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Dzd)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Egp)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Etb)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Eur)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Fjd)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Gbp)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Gel)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Gip)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Gmd)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Gyd)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Hkd)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Hrk)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Htg)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Idr)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Ils)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Inr)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Isk)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Jmd)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Jpy)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Kes)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Kgs)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Khr)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Kmf)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Krw)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Kyd)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Kzt)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Lbp)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Lkr)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Lrd)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Lsl)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Mad)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Mdl)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Mga)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Mkd)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Mmk)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Mnt)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Mop)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Mro)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Mvr)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Mwk)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Mxn)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Myr)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Mzn)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Nad)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Ngn)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Nok)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Npr)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Nzd)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Pgk)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Php)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Pkr)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Pln)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Qar)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Ron)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Rsd)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Rub)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Rwf)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Sar)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Sbd)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Scr)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Sek)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Sgd)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Sle)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Sll)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Sos)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Szl)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Thb)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Tjs)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Top)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Try)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Ttd)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Tzs)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Uah)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Uzs)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Vnd)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Vuv)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Wst)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Xaf)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Xcd)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Yer)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Zar)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Zmw)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Clp)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Djf)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Gnf)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Ugx)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Pyg)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Xof)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Xpf)]
    public void Validation_Works(SetPackagePricingMinimumSpendMinimumCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SetPackagePricingMinimumSpendMinimumCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingMinimumSpendMinimumCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Usd)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Aed)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.All)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Amd)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Ang)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Aud)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Awg)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Azn)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Bam)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Bbd)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Bdt)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Bgn)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Bif)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Bmd)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Bnd)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Bsd)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Bwp)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Byn)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Bzd)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Brl)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Cad)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Cdf)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Chf)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Cny)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Czk)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Dkk)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Dop)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Dzd)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Egp)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Etb)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Eur)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Fjd)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Gbp)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Gel)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Gip)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Gmd)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Gyd)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Hkd)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Hrk)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Htg)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Idr)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Ils)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Inr)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Isk)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Jmd)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Jpy)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Kes)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Kgs)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Khr)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Kmf)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Krw)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Kyd)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Kzt)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Lbp)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Lkr)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Lrd)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Lsl)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Mad)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Mdl)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Mga)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Mkd)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Mmk)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Mnt)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Mop)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Mro)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Mvr)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Mwk)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Mxn)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Myr)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Mzn)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Nad)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Ngn)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Nok)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Npr)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Nzd)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Pgk)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Php)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Pkr)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Pln)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Qar)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Ron)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Rsd)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Rub)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Rwf)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Sar)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Sbd)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Scr)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Sek)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Sgd)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Sle)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Sll)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Sos)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Szl)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Thb)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Tjs)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Top)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Try)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Ttd)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Tzs)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Uah)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Uzs)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Vnd)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Vuv)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Wst)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Xaf)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Xcd)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Yer)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Zar)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Zmw)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Clp)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Djf)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Gnf)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Ugx)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Pyg)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Xof)]
    [InlineData(SetPackagePricingMinimumSpendMinimumCurrency.Xpf)]
    public void SerializationRoundtrip_Works(SetPackagePricingMinimumSpendMinimumCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SetPackagePricingMinimumSpendMinimumCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingMinimumSpendMinimumCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingMinimumSpendMinimumCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingMinimumSpendMinimumCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SetPackagePricingOverageBillingPeriodTest : TestBase
{
    [Theory]
    [InlineData(SetPackagePricingOverageBillingPeriod.OnSubscriptionRenewal)]
    [InlineData(SetPackagePricingOverageBillingPeriod.Monthly)]
    public void Validation_Works(SetPackagePricingOverageBillingPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SetPackagePricingOverageBillingPeriod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingOverageBillingPeriod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SetPackagePricingOverageBillingPeriod.OnSubscriptionRenewal)]
    [InlineData(SetPackagePricingOverageBillingPeriod.Monthly)]
    public void SerializationRoundtrip_Works(SetPackagePricingOverageBillingPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SetPackagePricingOverageBillingPeriod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingOverageBillingPeriod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingOverageBillingPeriod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingOverageBillingPeriod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SetPackagePricingOveragePricingModelTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SetPackagePricingOveragePricingModel
        {
            BillingModel = SetPackagePricingOveragePricingModelBillingModel.FlatFee,
            PricePeriods =
            [
                new()
                {
                    BillingPeriod =
                        SetPackagePricingOveragePricingModelPricePeriodBillingPeriod.Monthly,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    CreditGrantCadence =
                        SetPackagePricingOveragePricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                    CreditRate = new()
                    {
                        Amount = 1,
                        CurrencyID = "currencyId",
                        CostFormula = "costFormula",
                    },
                    Price = new()
                    {
                        Amount = 0,
                        Currency = SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Usd,
                    },
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency =
                                    SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency =
                                    SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            BillingCadence = SetPackagePricingOveragePricingModelBillingCadence.Recurring,
            Entitlement = new()
            {
                FeatureID = "featureId",
                HasSoftLimit = true,
                HasUnlimitedUsage = true,
                MonthlyResetPeriodConfiguration = new(
                    SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
                ResetPeriod = SetPackagePricingOveragePricingModelEntitlementResetPeriod.Year,
                UsageLimit = 0,
                WeeklyResetPeriodConfiguration = new(
                    SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
                YearlyResetPeriodConfiguration = new(
                    SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
            },
            FeatureID = "featureId",
            TopUpCustomCurrencyID = "topUpCustomCurrencyId",
        };

        ApiEnum<string, SetPackagePricingOveragePricingModelBillingModel> expectedBillingModel =
            SetPackagePricingOveragePricingModelBillingModel.FlatFee;
        List<SetPackagePricingOveragePricingModelPricePeriod> expectedPricePeriods =
        [
            new()
            {
                BillingPeriod =
                    SetPackagePricingOveragePricingModelPricePeriodBillingPeriod.Monthly,
                BillingCountryCode = "billingCountryCode",
                BlockSize = 0,
                CreditGrantCadence =
                    SetPackagePricingOveragePricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                CreditRate = new()
                {
                    Amount = 1,
                    CurrencyID = "currencyId",
                    CostFormula = "costFormula",
                },
                Price = new()
                {
                    Amount = 0,
                    Currency = SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Usd,
                },
                Tiers =
                [
                    new()
                    {
                        FlatPrice = new()
                        {
                            Amount = 0,
                            Currency =
                                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Usd,
                        },
                        UnitPrice = new()
                        {
                            Amount = 0,
                            Currency =
                                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Usd,
                        },
                        UpTo = 0,
                    },
                ],
            },
        ];
        ApiEnum<string, SetPackagePricingOveragePricingModelBillingCadence> expectedBillingCadence =
            SetPackagePricingOveragePricingModelBillingCadence.Recurring;
        SetPackagePricingOveragePricingModelEntitlement expectedEntitlement = new()
        {
            FeatureID = "featureId",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            MonthlyResetPeriodConfiguration = new(
                SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            ResetPeriod = SetPackagePricingOveragePricingModelEntitlementResetPeriod.Year,
            UsageLimit = 0,
            WeeklyResetPeriodConfiguration = new(
                SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
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
        var model = new SetPackagePricingOveragePricingModel
        {
            BillingModel = SetPackagePricingOveragePricingModelBillingModel.FlatFee,
            PricePeriods =
            [
                new()
                {
                    BillingPeriod =
                        SetPackagePricingOveragePricingModelPricePeriodBillingPeriod.Monthly,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    CreditGrantCadence =
                        SetPackagePricingOveragePricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                    CreditRate = new()
                    {
                        Amount = 1,
                        CurrencyID = "currencyId",
                        CostFormula = "costFormula",
                    },
                    Price = new()
                    {
                        Amount = 0,
                        Currency = SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Usd,
                    },
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency =
                                    SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency =
                                    SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            BillingCadence = SetPackagePricingOveragePricingModelBillingCadence.Recurring,
            Entitlement = new()
            {
                FeatureID = "featureId",
                HasSoftLimit = true,
                HasUnlimitedUsage = true,
                MonthlyResetPeriodConfiguration = new(
                    SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
                ResetPeriod = SetPackagePricingOveragePricingModelEntitlementResetPeriod.Year,
                UsageLimit = 0,
                WeeklyResetPeriodConfiguration = new(
                    SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
                YearlyResetPeriodConfiguration = new(
                    SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
            },
            FeatureID = "featureId",
            TopUpCustomCurrencyID = "topUpCustomCurrencyId",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SetPackagePricingOveragePricingModel>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SetPackagePricingOveragePricingModel
        {
            BillingModel = SetPackagePricingOveragePricingModelBillingModel.FlatFee,
            PricePeriods =
            [
                new()
                {
                    BillingPeriod =
                        SetPackagePricingOveragePricingModelPricePeriodBillingPeriod.Monthly,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    CreditGrantCadence =
                        SetPackagePricingOveragePricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                    CreditRate = new()
                    {
                        Amount = 1,
                        CurrencyID = "currencyId",
                        CostFormula = "costFormula",
                    },
                    Price = new()
                    {
                        Amount = 0,
                        Currency = SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Usd,
                    },
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency =
                                    SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency =
                                    SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            BillingCadence = SetPackagePricingOveragePricingModelBillingCadence.Recurring,
            Entitlement = new()
            {
                FeatureID = "featureId",
                HasSoftLimit = true,
                HasUnlimitedUsage = true,
                MonthlyResetPeriodConfiguration = new(
                    SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
                ResetPeriod = SetPackagePricingOveragePricingModelEntitlementResetPeriod.Year,
                UsageLimit = 0,
                WeeklyResetPeriodConfiguration = new(
                    SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
                YearlyResetPeriodConfiguration = new(
                    SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
            },
            FeatureID = "featureId",
            TopUpCustomCurrencyID = "topUpCustomCurrencyId",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SetPackagePricingOveragePricingModel>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, SetPackagePricingOveragePricingModelBillingModel> expectedBillingModel =
            SetPackagePricingOveragePricingModelBillingModel.FlatFee;
        List<SetPackagePricingOveragePricingModelPricePeriod> expectedPricePeriods =
        [
            new()
            {
                BillingPeriod =
                    SetPackagePricingOveragePricingModelPricePeriodBillingPeriod.Monthly,
                BillingCountryCode = "billingCountryCode",
                BlockSize = 0,
                CreditGrantCadence =
                    SetPackagePricingOveragePricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                CreditRate = new()
                {
                    Amount = 1,
                    CurrencyID = "currencyId",
                    CostFormula = "costFormula",
                },
                Price = new()
                {
                    Amount = 0,
                    Currency = SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Usd,
                },
                Tiers =
                [
                    new()
                    {
                        FlatPrice = new()
                        {
                            Amount = 0,
                            Currency =
                                SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Usd,
                        },
                        UnitPrice = new()
                        {
                            Amount = 0,
                            Currency =
                                SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Usd,
                        },
                        UpTo = 0,
                    },
                ],
            },
        ];
        ApiEnum<string, SetPackagePricingOveragePricingModelBillingCadence> expectedBillingCadence =
            SetPackagePricingOveragePricingModelBillingCadence.Recurring;
        SetPackagePricingOveragePricingModelEntitlement expectedEntitlement = new()
        {
            FeatureID = "featureId",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            MonthlyResetPeriodConfiguration = new(
                SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            ResetPeriod = SetPackagePricingOveragePricingModelEntitlementResetPeriod.Year,
            UsageLimit = 0,
            WeeklyResetPeriodConfiguration = new(
                SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
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
        var model = new SetPackagePricingOveragePricingModel
        {
            BillingModel = SetPackagePricingOveragePricingModelBillingModel.FlatFee,
            PricePeriods =
            [
                new()
                {
                    BillingPeriod =
                        SetPackagePricingOveragePricingModelPricePeriodBillingPeriod.Monthly,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    CreditGrantCadence =
                        SetPackagePricingOveragePricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                    CreditRate = new()
                    {
                        Amount = 1,
                        CurrencyID = "currencyId",
                        CostFormula = "costFormula",
                    },
                    Price = new()
                    {
                        Amount = 0,
                        Currency = SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Usd,
                    },
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency =
                                    SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency =
                                    SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            BillingCadence = SetPackagePricingOveragePricingModelBillingCadence.Recurring,
            Entitlement = new()
            {
                FeatureID = "featureId",
                HasSoftLimit = true,
                HasUnlimitedUsage = true,
                MonthlyResetPeriodConfiguration = new(
                    SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
                ResetPeriod = SetPackagePricingOveragePricingModelEntitlementResetPeriod.Year,
                UsageLimit = 0,
                WeeklyResetPeriodConfiguration = new(
                    SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
                YearlyResetPeriodConfiguration = new(
                    SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
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
        var model = new SetPackagePricingOveragePricingModel
        {
            BillingModel = SetPackagePricingOveragePricingModelBillingModel.FlatFee,
            PricePeriods =
            [
                new()
                {
                    BillingPeriod =
                        SetPackagePricingOveragePricingModelPricePeriodBillingPeriod.Monthly,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    CreditGrantCadence =
                        SetPackagePricingOveragePricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                    CreditRate = new()
                    {
                        Amount = 1,
                        CurrencyID = "currencyId",
                        CostFormula = "costFormula",
                    },
                    Price = new()
                    {
                        Amount = 0,
                        Currency = SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Usd,
                    },
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency =
                                    SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency =
                                    SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Usd,
                            },
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
        var model = new SetPackagePricingOveragePricingModel
        {
            BillingModel = SetPackagePricingOveragePricingModelBillingModel.FlatFee,
            PricePeriods =
            [
                new()
                {
                    BillingPeriod =
                        SetPackagePricingOveragePricingModelPricePeriodBillingPeriod.Monthly,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    CreditGrantCadence =
                        SetPackagePricingOveragePricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                    CreditRate = new()
                    {
                        Amount = 1,
                        CurrencyID = "currencyId",
                        CostFormula = "costFormula",
                    },
                    Price = new()
                    {
                        Amount = 0,
                        Currency = SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Usd,
                    },
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency =
                                    SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency =
                                    SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Usd,
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
        var model = new SetPackagePricingOveragePricingModel
        {
            BillingModel = SetPackagePricingOveragePricingModelBillingModel.FlatFee,
            PricePeriods =
            [
                new()
                {
                    BillingPeriod =
                        SetPackagePricingOveragePricingModelPricePeriodBillingPeriod.Monthly,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    CreditGrantCadence =
                        SetPackagePricingOveragePricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                    CreditRate = new()
                    {
                        Amount = 1,
                        CurrencyID = "currencyId",
                        CostFormula = "costFormula",
                    },
                    Price = new()
                    {
                        Amount = 0,
                        Currency = SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Usd,
                    },
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency =
                                    SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency =
                                    SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Usd,
                            },
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
        var model = new SetPackagePricingOveragePricingModel
        {
            BillingModel = SetPackagePricingOveragePricingModelBillingModel.FlatFee,
            PricePeriods =
            [
                new()
                {
                    BillingPeriod =
                        SetPackagePricingOveragePricingModelPricePeriodBillingPeriod.Monthly,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    CreditGrantCadence =
                        SetPackagePricingOveragePricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                    CreditRate = new()
                    {
                        Amount = 1,
                        CurrencyID = "currencyId",
                        CostFormula = "costFormula",
                    },
                    Price = new()
                    {
                        Amount = 0,
                        Currency = SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Usd,
                    },
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency =
                                    SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency =
                                    SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Usd,
                            },
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
        var model = new SetPackagePricingOveragePricingModel
        {
            BillingModel = SetPackagePricingOveragePricingModelBillingModel.FlatFee,
            PricePeriods =
            [
                new()
                {
                    BillingPeriod =
                        SetPackagePricingOveragePricingModelPricePeriodBillingPeriod.Monthly,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    CreditGrantCadence =
                        SetPackagePricingOveragePricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                    CreditRate = new()
                    {
                        Amount = 1,
                        CurrencyID = "currencyId",
                        CostFormula = "costFormula",
                    },
                    Price = new()
                    {
                        Amount = 0,
                        Currency = SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Usd,
                    },
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency =
                                    SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency =
                                    SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            BillingCadence = SetPackagePricingOveragePricingModelBillingCadence.Recurring,
            Entitlement = new()
            {
                FeatureID = "featureId",
                HasSoftLimit = true,
                HasUnlimitedUsage = true,
                MonthlyResetPeriodConfiguration = new(
                    SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
                ResetPeriod = SetPackagePricingOveragePricingModelEntitlementResetPeriod.Year,
                UsageLimit = 0,
                WeeklyResetPeriodConfiguration = new(
                    SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
                YearlyResetPeriodConfiguration = new(
                    SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
            },
            FeatureID = "featureId",
            TopUpCustomCurrencyID = "topUpCustomCurrencyId",
        };

        SetPackagePricingOveragePricingModel copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SetPackagePricingOveragePricingModelBillingModelTest : TestBase
{
    [Theory]
    [InlineData(SetPackagePricingOveragePricingModelBillingModel.FlatFee)]
    [InlineData(SetPackagePricingOveragePricingModelBillingModel.MinimumSpend)]
    [InlineData(SetPackagePricingOveragePricingModelBillingModel.PerUnit)]
    [InlineData(SetPackagePricingOveragePricingModelBillingModel.UsageBased)]
    [InlineData(SetPackagePricingOveragePricingModelBillingModel.CreditBased)]
    public void Validation_Works(SetPackagePricingOveragePricingModelBillingModel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SetPackagePricingOveragePricingModelBillingModel> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingOveragePricingModelBillingModel>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SetPackagePricingOveragePricingModelBillingModel.FlatFee)]
    [InlineData(SetPackagePricingOveragePricingModelBillingModel.MinimumSpend)]
    [InlineData(SetPackagePricingOveragePricingModelBillingModel.PerUnit)]
    [InlineData(SetPackagePricingOveragePricingModelBillingModel.UsageBased)]
    [InlineData(SetPackagePricingOveragePricingModelBillingModel.CreditBased)]
    public void SerializationRoundtrip_Works(
        SetPackagePricingOveragePricingModelBillingModel rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SetPackagePricingOveragePricingModelBillingModel> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingOveragePricingModelBillingModel>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingOveragePricingModelBillingModel>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingOveragePricingModelBillingModel>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SetPackagePricingOveragePricingModelPricePeriodTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SetPackagePricingOveragePricingModelPricePeriod
        {
            BillingPeriod = SetPackagePricingOveragePricingModelPricePeriodBillingPeriod.Monthly,
            BillingCountryCode = "billingCountryCode",
            BlockSize = 0,
            CreditGrantCadence =
                SetPackagePricingOveragePricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
            CreditRate = new()
            {
                Amount = 1,
                CurrencyID = "currencyId",
                CostFormula = "costFormula",
            },
            Price = new()
            {
                Amount = 0,
                Currency = SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Usd,
            },
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        Currency =
                            SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        Currency =
                            SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Usd,
                    },
                    UpTo = 0,
                },
            ],
        };

        ApiEnum<
            string,
            SetPackagePricingOveragePricingModelPricePeriodBillingPeriod
        > expectedBillingPeriod =
            SetPackagePricingOveragePricingModelPricePeriodBillingPeriod.Monthly;
        string expectedBillingCountryCode = "billingCountryCode";
        double expectedBlockSize = 0;
        ApiEnum<
            string,
            SetPackagePricingOveragePricingModelPricePeriodCreditGrantCadence
        > expectedCreditGrantCadence =
            SetPackagePricingOveragePricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod;
        SetPackagePricingOveragePricingModelPricePeriodCreditRate expectedCreditRate = new()
        {
            Amount = 1,
            CurrencyID = "currencyId",
            CostFormula = "costFormula",
        };
        SetPackagePricingOveragePricingModelPricePeriodPrice expectedPrice = new()
        {
            Amount = 0,
            Currency = SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Usd,
        };
        List<SetPackagePricingOveragePricingModelPricePeriodTier> expectedTiers =
        [
            new()
            {
                FlatPrice = new()
                {
                    Amount = 0,
                    Currency =
                        SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Usd,
                },
                UnitPrice = new()
                {
                    Amount = 0,
                    Currency =
                        SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Usd,
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
        var model = new SetPackagePricingOveragePricingModelPricePeriod
        {
            BillingPeriod = SetPackagePricingOveragePricingModelPricePeriodBillingPeriod.Monthly,
            BillingCountryCode = "billingCountryCode",
            BlockSize = 0,
            CreditGrantCadence =
                SetPackagePricingOveragePricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
            CreditRate = new()
            {
                Amount = 1,
                CurrencyID = "currencyId",
                CostFormula = "costFormula",
            },
            Price = new()
            {
                Amount = 0,
                Currency = SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Usd,
            },
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        Currency =
                            SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        Currency =
                            SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Usd,
                    },
                    UpTo = 0,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SetPackagePricingOveragePricingModelPricePeriod>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SetPackagePricingOveragePricingModelPricePeriod
        {
            BillingPeriod = SetPackagePricingOveragePricingModelPricePeriodBillingPeriod.Monthly,
            BillingCountryCode = "billingCountryCode",
            BlockSize = 0,
            CreditGrantCadence =
                SetPackagePricingOveragePricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
            CreditRate = new()
            {
                Amount = 1,
                CurrencyID = "currencyId",
                CostFormula = "costFormula",
            },
            Price = new()
            {
                Amount = 0,
                Currency = SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Usd,
            },
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        Currency =
                            SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        Currency =
                            SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Usd,
                    },
                    UpTo = 0,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SetPackagePricingOveragePricingModelPricePeriod>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            SetPackagePricingOveragePricingModelPricePeriodBillingPeriod
        > expectedBillingPeriod =
            SetPackagePricingOveragePricingModelPricePeriodBillingPeriod.Monthly;
        string expectedBillingCountryCode = "billingCountryCode";
        double expectedBlockSize = 0;
        ApiEnum<
            string,
            SetPackagePricingOveragePricingModelPricePeriodCreditGrantCadence
        > expectedCreditGrantCadence =
            SetPackagePricingOveragePricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod;
        SetPackagePricingOveragePricingModelPricePeriodCreditRate expectedCreditRate = new()
        {
            Amount = 1,
            CurrencyID = "currencyId",
            CostFormula = "costFormula",
        };
        SetPackagePricingOveragePricingModelPricePeriodPrice expectedPrice = new()
        {
            Amount = 0,
            Currency = SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Usd,
        };
        List<SetPackagePricingOveragePricingModelPricePeriodTier> expectedTiers =
        [
            new()
            {
                FlatPrice = new()
                {
                    Amount = 0,
                    Currency =
                        SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Usd,
                },
                UnitPrice = new()
                {
                    Amount = 0,
                    Currency =
                        SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Usd,
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
        var model = new SetPackagePricingOveragePricingModelPricePeriod
        {
            BillingPeriod = SetPackagePricingOveragePricingModelPricePeriodBillingPeriod.Monthly,
            BillingCountryCode = "billingCountryCode",
            BlockSize = 0,
            CreditGrantCadence =
                SetPackagePricingOveragePricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
            CreditRate = new()
            {
                Amount = 1,
                CurrencyID = "currencyId",
                CostFormula = "costFormula",
            },
            Price = new()
            {
                Amount = 0,
                Currency = SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Usd,
            },
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        Currency =
                            SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        Currency =
                            SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Usd,
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
        var model = new SetPackagePricingOveragePricingModelPricePeriod
        {
            BillingPeriod = SetPackagePricingOveragePricingModelPricePeriodBillingPeriod.Monthly,
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
        var model = new SetPackagePricingOveragePricingModelPricePeriod
        {
            BillingPeriod = SetPackagePricingOveragePricingModelPricePeriodBillingPeriod.Monthly,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SetPackagePricingOveragePricingModelPricePeriod
        {
            BillingPeriod = SetPackagePricingOveragePricingModelPricePeriodBillingPeriod.Monthly,

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
        var model = new SetPackagePricingOveragePricingModelPricePeriod
        {
            BillingPeriod = SetPackagePricingOveragePricingModelPricePeriodBillingPeriod.Monthly,

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
        var model = new SetPackagePricingOveragePricingModelPricePeriod
        {
            BillingPeriod = SetPackagePricingOveragePricingModelPricePeriodBillingPeriod.Monthly,
            BillingCountryCode = "billingCountryCode",
            BlockSize = 0,
            CreditGrantCadence =
                SetPackagePricingOveragePricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
            CreditRate = new()
            {
                Amount = 1,
                CurrencyID = "currencyId",
                CostFormula = "costFormula",
            },
            Price = new()
            {
                Amount = 0,
                Currency = SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Usd,
            },
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        Currency =
                            SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        Currency =
                            SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Usd,
                    },
                    UpTo = 0,
                },
            ],
        };

        SetPackagePricingOveragePricingModelPricePeriod copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SetPackagePricingOveragePricingModelPricePeriodBillingPeriodTest : TestBase
{
    [Theory]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodBillingPeriod.Monthly)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodBillingPeriod.Annually)]
    public void Validation_Works(
        SetPackagePricingOveragePricingModelPricePeriodBillingPeriod rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SetPackagePricingOveragePricingModelPricePeriodBillingPeriod> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingOveragePricingModelPricePeriodBillingPeriod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodBillingPeriod.Monthly)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodBillingPeriod.Annually)]
    public void SerializationRoundtrip_Works(
        SetPackagePricingOveragePricingModelPricePeriodBillingPeriod rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SetPackagePricingOveragePricingModelPricePeriodBillingPeriod> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingOveragePricingModelPricePeriodBillingPeriod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingOveragePricingModelPricePeriodBillingPeriod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingOveragePricingModelPricePeriodBillingPeriod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SetPackagePricingOveragePricingModelPricePeriodCreditGrantCadenceTest : TestBase
{
    [Theory]
    [InlineData(
        SetPackagePricingOveragePricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod
    )]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodCreditGrantCadence.Monthly)]
    public void Validation_Works(
        SetPackagePricingOveragePricingModelPricePeriodCreditGrantCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SetPackagePricingOveragePricingModelPricePeriodCreditGrantCadence> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingOveragePricingModelPricePeriodCreditGrantCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        SetPackagePricingOveragePricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod
    )]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodCreditGrantCadence.Monthly)]
    public void SerializationRoundtrip_Works(
        SetPackagePricingOveragePricingModelPricePeriodCreditGrantCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SetPackagePricingOveragePricingModelPricePeriodCreditGrantCadence> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingOveragePricingModelPricePeriodCreditGrantCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingOveragePricingModelPricePeriodCreditGrantCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingOveragePricingModelPricePeriodCreditGrantCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SetPackagePricingOveragePricingModelPricePeriodCreditRateTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SetPackagePricingOveragePricingModelPricePeriodCreditRate
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
        var model = new SetPackagePricingOveragePricingModelPricePeriodCreditRate
        {
            Amount = 1,
            CurrencyID = "currencyId",
            CostFormula = "costFormula",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SetPackagePricingOveragePricingModelPricePeriodCreditRate>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SetPackagePricingOveragePricingModelPricePeriodCreditRate
        {
            Amount = 1,
            CurrencyID = "currencyId",
            CostFormula = "costFormula",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SetPackagePricingOveragePricingModelPricePeriodCreditRate>(
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
        var model = new SetPackagePricingOveragePricingModelPricePeriodCreditRate
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
        var model = new SetPackagePricingOveragePricingModelPricePeriodCreditRate
        {
            Amount = 1,
            CurrencyID = "currencyId",
        };

        Assert.Null(model.CostFormula);
        Assert.False(model.RawData.ContainsKey("costFormula"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SetPackagePricingOveragePricingModelPricePeriodCreditRate
        {
            Amount = 1,
            CurrencyID = "currencyId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SetPackagePricingOveragePricingModelPricePeriodCreditRate
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
        var model = new SetPackagePricingOveragePricingModelPricePeriodCreditRate
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
        var model = new SetPackagePricingOveragePricingModelPricePeriodCreditRate
        {
            Amount = 1,
            CurrencyID = "currencyId",
            CostFormula = "costFormula",
        };

        SetPackagePricingOveragePricingModelPricePeriodCreditRate copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SetPackagePricingOveragePricingModelPricePeriodPriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SetPackagePricingOveragePricingModelPricePeriodPrice
        {
            Amount = 0,
            Currency = SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Usd,
        };

        double expectedAmount = 0;
        ApiEnum<
            string,
            SetPackagePricingOveragePricingModelPricePeriodPriceCurrency
        > expectedCurrency = SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SetPackagePricingOveragePricingModelPricePeriodPrice
        {
            Amount = 0,
            Currency = SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Usd,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SetPackagePricingOveragePricingModelPricePeriodPrice>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SetPackagePricingOveragePricingModelPricePeriodPrice
        {
            Amount = 0,
            Currency = SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Usd,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SetPackagePricingOveragePricingModelPricePeriodPrice>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        ApiEnum<
            string,
            SetPackagePricingOveragePricingModelPricePeriodPriceCurrency
        > expectedCurrency = SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SetPackagePricingOveragePricingModelPricePeriodPrice
        {
            Amount = 0,
            Currency = SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SetPackagePricingOveragePricingModelPricePeriodPrice { Amount = 0 };

        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SetPackagePricingOveragePricingModelPricePeriodPrice { Amount = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SetPackagePricingOveragePricingModelPricePeriodPrice
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
        var model = new SetPackagePricingOveragePricingModelPricePeriodPrice
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
        var model = new SetPackagePricingOveragePricingModelPricePeriodPrice
        {
            Amount = 0,
            Currency = SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Usd,
        };

        SetPackagePricingOveragePricingModelPricePeriodPrice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SetPackagePricingOveragePricingModelPricePeriodPriceCurrencyTest : TestBase
{
    [Theory]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Usd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Aed)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.All)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Amd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Ang)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Aud)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Awg)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Azn)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Bam)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Bbd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Bdt)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Bgn)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Bif)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Bmd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Bnd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Bsd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Bwp)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Byn)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Bzd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Brl)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Cad)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Cdf)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Chf)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Cny)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Czk)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Dkk)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Dop)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Dzd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Egp)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Etb)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Eur)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Fjd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Gbp)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Gel)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Gip)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Gmd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Gyd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Hkd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Hrk)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Htg)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Idr)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Ils)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Inr)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Isk)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Jmd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Jpy)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Kes)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Kgs)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Khr)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Kmf)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Krw)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Kyd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Kzt)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Lbp)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Lkr)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Lrd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Lsl)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Mad)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Mdl)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Mga)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Mkd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Mmk)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Mnt)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Mop)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Mro)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Mvr)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Mwk)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Mxn)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Myr)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Mzn)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Nad)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Ngn)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Nok)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Npr)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Nzd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Pgk)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Php)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Pkr)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Pln)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Qar)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Ron)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Rsd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Rub)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Rwf)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Sar)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Sbd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Scr)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Sek)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Sgd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Sle)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Sll)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Sos)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Szl)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Thb)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Tjs)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Top)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Try)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Ttd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Tzs)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Uah)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Uzs)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Vnd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Vuv)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Wst)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Xaf)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Xcd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Yer)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Zar)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Zmw)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Clp)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Djf)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Gnf)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Ugx)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Pyg)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Xof)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Xpf)]
    public void Validation_Works(
        SetPackagePricingOveragePricingModelPricePeriodPriceCurrency rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SetPackagePricingOveragePricingModelPricePeriodPriceCurrency> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingOveragePricingModelPricePeriodPriceCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Usd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Aed)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.All)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Amd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Ang)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Aud)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Awg)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Azn)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Bam)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Bbd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Bdt)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Bgn)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Bif)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Bmd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Bnd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Bsd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Bwp)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Byn)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Bzd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Brl)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Cad)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Cdf)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Chf)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Cny)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Czk)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Dkk)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Dop)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Dzd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Egp)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Etb)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Eur)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Fjd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Gbp)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Gel)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Gip)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Gmd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Gyd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Hkd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Hrk)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Htg)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Idr)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Ils)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Inr)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Isk)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Jmd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Jpy)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Kes)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Kgs)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Khr)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Kmf)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Krw)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Kyd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Kzt)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Lbp)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Lkr)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Lrd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Lsl)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Mad)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Mdl)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Mga)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Mkd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Mmk)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Mnt)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Mop)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Mro)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Mvr)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Mwk)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Mxn)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Myr)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Mzn)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Nad)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Ngn)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Nok)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Npr)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Nzd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Pgk)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Php)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Pkr)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Pln)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Qar)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Ron)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Rsd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Rub)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Rwf)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Sar)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Sbd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Scr)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Sek)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Sgd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Sle)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Sll)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Sos)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Szl)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Thb)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Tjs)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Top)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Try)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Ttd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Tzs)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Uah)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Uzs)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Vnd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Vuv)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Wst)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Xaf)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Xcd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Yer)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Zar)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Zmw)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Clp)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Djf)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Gnf)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Ugx)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Pyg)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Xof)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodPriceCurrency.Xpf)]
    public void SerializationRoundtrip_Works(
        SetPackagePricingOveragePricingModelPricePeriodPriceCurrency rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SetPackagePricingOveragePricingModelPricePeriodPriceCurrency> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingOveragePricingModelPricePeriodPriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingOveragePricingModelPricePeriodPriceCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingOveragePricingModelPricePeriodPriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SetPackagePricingOveragePricingModelPricePeriodTierTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SetPackagePricingOveragePricingModelPricePeriodTier
        {
            FlatPrice = new()
            {
                Amount = 0,
                Currency = SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Usd,
            },
            UnitPrice = new()
            {
                Amount = 0,
                Currency = SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Usd,
            },
            UpTo = 0,
        };

        SetPackagePricingOveragePricingModelPricePeriodTierFlatPrice expectedFlatPrice = new()
        {
            Amount = 0,
            Currency = SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Usd,
        };
        SetPackagePricingOveragePricingModelPricePeriodTierUnitPrice expectedUnitPrice = new()
        {
            Amount = 0,
            Currency = SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Usd,
        };
        double expectedUpTo = 0;

        Assert.Equal(expectedFlatPrice, model.FlatPrice);
        Assert.Equal(expectedUnitPrice, model.UnitPrice);
        Assert.Equal(expectedUpTo, model.UpTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SetPackagePricingOveragePricingModelPricePeriodTier
        {
            FlatPrice = new()
            {
                Amount = 0,
                Currency = SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Usd,
            },
            UnitPrice = new()
            {
                Amount = 0,
                Currency = SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Usd,
            },
            UpTo = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SetPackagePricingOveragePricingModelPricePeriodTier>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SetPackagePricingOveragePricingModelPricePeriodTier
        {
            FlatPrice = new()
            {
                Amount = 0,
                Currency = SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Usd,
            },
            UnitPrice = new()
            {
                Amount = 0,
                Currency = SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Usd,
            },
            UpTo = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SetPackagePricingOveragePricingModelPricePeriodTier>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        SetPackagePricingOveragePricingModelPricePeriodTierFlatPrice expectedFlatPrice = new()
        {
            Amount = 0,
            Currency = SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Usd,
        };
        SetPackagePricingOveragePricingModelPricePeriodTierUnitPrice expectedUnitPrice = new()
        {
            Amount = 0,
            Currency = SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Usd,
        };
        double expectedUpTo = 0;

        Assert.Equal(expectedFlatPrice, deserialized.FlatPrice);
        Assert.Equal(expectedUnitPrice, deserialized.UnitPrice);
        Assert.Equal(expectedUpTo, deserialized.UpTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SetPackagePricingOveragePricingModelPricePeriodTier
        {
            FlatPrice = new()
            {
                Amount = 0,
                Currency = SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Usd,
            },
            UnitPrice = new()
            {
                Amount = 0,
                Currency = SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Usd,
            },
            UpTo = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SetPackagePricingOveragePricingModelPricePeriodTier { };

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
        var model = new SetPackagePricingOveragePricingModelPricePeriodTier { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SetPackagePricingOveragePricingModelPricePeriodTier
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
        var model = new SetPackagePricingOveragePricingModelPricePeriodTier
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
        var model = new SetPackagePricingOveragePricingModelPricePeriodTier
        {
            FlatPrice = new()
            {
                Amount = 0,
                Currency = SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Usd,
            },
            UnitPrice = new()
            {
                Amount = 0,
                Currency = SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Usd,
            },
            UpTo = 0,
        };

        SetPackagePricingOveragePricingModelPricePeriodTier copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SetPackagePricingOveragePricingModelPricePeriodTierFlatPrice
        {
            Amount = 0,
            Currency = SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Usd,
        };

        double expectedAmount = 0;
        ApiEnum<
            string,
            SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency
        > expectedCurrency =
            SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SetPackagePricingOveragePricingModelPricePeriodTierFlatPrice
        {
            Amount = 0,
            Currency = SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Usd,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SetPackagePricingOveragePricingModelPricePeriodTierFlatPrice>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SetPackagePricingOveragePricingModelPricePeriodTierFlatPrice
        {
            Amount = 0,
            Currency = SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Usd,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SetPackagePricingOveragePricingModelPricePeriodTierFlatPrice>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        ApiEnum<
            string,
            SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency
        > expectedCurrency =
            SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SetPackagePricingOveragePricingModelPricePeriodTierFlatPrice
        {
            Amount = 0,
            Currency = SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SetPackagePricingOveragePricingModelPricePeriodTierFlatPrice { Amount = 0 };

        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SetPackagePricingOveragePricingModelPricePeriodTierFlatPrice { Amount = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SetPackagePricingOveragePricingModelPricePeriodTierFlatPrice
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
        var model = new SetPackagePricingOveragePricingModelPricePeriodTierFlatPrice
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
        var model = new SetPackagePricingOveragePricingModelPricePeriodTierFlatPrice
        {
            Amount = 0,
            Currency = SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Usd,
        };

        SetPackagePricingOveragePricingModelPricePeriodTierFlatPrice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrencyTest : TestBase
{
    [Theory]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Usd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Aed)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.All)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Amd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Ang)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Aud)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Awg)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Azn)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Bam)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Bbd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Bdt)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Bgn)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Bif)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Bmd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Bnd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Bsd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Bwp)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Byn)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Bzd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Brl)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Cad)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Cdf)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Chf)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Cny)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Czk)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Dkk)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Dop)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Dzd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Egp)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Etb)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Eur)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Fjd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Gbp)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Gel)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Gip)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Gmd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Gyd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Hkd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Hrk)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Htg)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Idr)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Ils)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Inr)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Isk)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Jmd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Jpy)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Kes)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Kgs)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Khr)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Kmf)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Krw)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Kyd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Kzt)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Lbp)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Lkr)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Lrd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Lsl)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Mad)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Mdl)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Mga)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Mkd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Mmk)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Mnt)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Mop)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Mro)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Mvr)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Mwk)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Mxn)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Myr)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Mzn)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Nad)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Ngn)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Nok)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Npr)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Nzd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Pgk)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Php)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Pkr)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Pln)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Qar)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Ron)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Rsd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Rub)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Rwf)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Sar)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Sbd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Scr)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Sek)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Sgd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Sle)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Sll)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Sos)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Szl)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Thb)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Tjs)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Top)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Try)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Ttd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Tzs)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Uah)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Uzs)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Vnd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Vuv)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Wst)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Xaf)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Xcd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Yer)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Zar)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Zmw)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Clp)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Djf)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Gnf)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Ugx)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Pyg)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Xof)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Xpf)]
    public void Validation_Works(
        SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Usd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Aed)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.All)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Amd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Ang)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Aud)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Awg)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Azn)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Bam)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Bbd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Bdt)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Bgn)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Bif)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Bmd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Bnd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Bsd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Bwp)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Byn)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Bzd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Brl)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Cad)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Cdf)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Chf)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Cny)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Czk)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Dkk)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Dop)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Dzd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Egp)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Etb)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Eur)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Fjd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Gbp)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Gel)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Gip)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Gmd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Gyd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Hkd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Hrk)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Htg)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Idr)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Ils)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Inr)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Isk)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Jmd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Jpy)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Kes)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Kgs)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Khr)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Kmf)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Krw)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Kyd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Kzt)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Lbp)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Lkr)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Lrd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Lsl)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Mad)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Mdl)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Mga)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Mkd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Mmk)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Mnt)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Mop)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Mro)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Mvr)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Mwk)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Mxn)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Myr)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Mzn)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Nad)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Ngn)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Nok)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Npr)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Nzd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Pgk)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Php)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Pkr)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Pln)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Qar)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Ron)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Rsd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Rub)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Rwf)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Sar)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Sbd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Scr)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Sek)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Sgd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Sle)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Sll)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Sos)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Szl)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Thb)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Tjs)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Top)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Try)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Ttd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Tzs)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Uah)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Uzs)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Vnd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Vuv)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Wst)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Xaf)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Xcd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Yer)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Zar)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Zmw)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Clp)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Djf)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Gnf)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Ugx)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Pyg)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Xof)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency.Xpf)]
    public void SerializationRoundtrip_Works(
        SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SetPackagePricingOveragePricingModelPricePeriodTierUnitPrice
        {
            Amount = 0,
            Currency = SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Usd,
        };

        double expectedAmount = 0;
        ApiEnum<
            string,
            SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency
        > expectedCurrency =
            SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SetPackagePricingOveragePricingModelPricePeriodTierUnitPrice
        {
            Amount = 0,
            Currency = SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Usd,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SetPackagePricingOveragePricingModelPricePeriodTierUnitPrice>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SetPackagePricingOveragePricingModelPricePeriodTierUnitPrice
        {
            Amount = 0,
            Currency = SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Usd,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SetPackagePricingOveragePricingModelPricePeriodTierUnitPrice>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        ApiEnum<
            string,
            SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency
        > expectedCurrency =
            SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SetPackagePricingOveragePricingModelPricePeriodTierUnitPrice
        {
            Amount = 0,
            Currency = SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SetPackagePricingOveragePricingModelPricePeriodTierUnitPrice { Amount = 0 };

        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SetPackagePricingOveragePricingModelPricePeriodTierUnitPrice { Amount = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SetPackagePricingOveragePricingModelPricePeriodTierUnitPrice
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
        var model = new SetPackagePricingOveragePricingModelPricePeriodTierUnitPrice
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
        var model = new SetPackagePricingOveragePricingModelPricePeriodTierUnitPrice
        {
            Amount = 0,
            Currency = SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Usd,
        };

        SetPackagePricingOveragePricingModelPricePeriodTierUnitPrice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrencyTest : TestBase
{
    [Theory]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Usd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Aed)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.All)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Amd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Ang)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Aud)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Awg)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Azn)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Bam)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Bbd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Bdt)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Bgn)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Bif)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Bmd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Bnd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Bsd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Bwp)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Byn)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Bzd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Brl)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Cad)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Cdf)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Chf)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Cny)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Czk)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Dkk)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Dop)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Dzd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Egp)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Etb)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Eur)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Fjd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Gbp)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Gel)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Gip)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Gmd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Gyd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Hkd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Hrk)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Htg)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Idr)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Ils)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Inr)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Isk)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Jmd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Jpy)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Kes)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Kgs)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Khr)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Kmf)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Krw)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Kyd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Kzt)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Lbp)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Lkr)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Lrd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Lsl)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Mad)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Mdl)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Mga)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Mkd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Mmk)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Mnt)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Mop)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Mro)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Mvr)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Mwk)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Mxn)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Myr)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Mzn)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Nad)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Ngn)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Nok)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Npr)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Nzd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Pgk)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Php)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Pkr)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Pln)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Qar)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Ron)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Rsd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Rub)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Rwf)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Sar)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Sbd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Scr)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Sek)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Sgd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Sle)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Sll)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Sos)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Szl)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Thb)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Tjs)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Top)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Try)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Ttd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Tzs)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Uah)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Uzs)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Vnd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Vuv)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Wst)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Xaf)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Xcd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Yer)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Zar)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Zmw)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Clp)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Djf)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Gnf)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Ugx)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Pyg)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Xof)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Xpf)]
    public void Validation_Works(
        SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Usd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Aed)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.All)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Amd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Ang)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Aud)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Awg)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Azn)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Bam)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Bbd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Bdt)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Bgn)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Bif)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Bmd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Bnd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Bsd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Bwp)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Byn)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Bzd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Brl)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Cad)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Cdf)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Chf)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Cny)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Czk)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Dkk)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Dop)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Dzd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Egp)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Etb)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Eur)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Fjd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Gbp)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Gel)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Gip)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Gmd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Gyd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Hkd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Hrk)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Htg)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Idr)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Ils)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Inr)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Isk)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Jmd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Jpy)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Kes)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Kgs)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Khr)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Kmf)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Krw)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Kyd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Kzt)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Lbp)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Lkr)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Lrd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Lsl)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Mad)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Mdl)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Mga)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Mkd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Mmk)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Mnt)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Mop)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Mro)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Mvr)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Mwk)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Mxn)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Myr)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Mzn)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Nad)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Ngn)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Nok)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Npr)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Nzd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Pgk)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Php)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Pkr)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Pln)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Qar)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Ron)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Rsd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Rub)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Rwf)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Sar)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Sbd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Scr)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Sek)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Sgd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Sle)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Sll)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Sos)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Szl)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Thb)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Tjs)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Top)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Try)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Ttd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Tzs)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Uah)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Uzs)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Vnd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Vuv)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Wst)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Xaf)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Xcd)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Yer)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Zar)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Zmw)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Clp)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Djf)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Gnf)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Ugx)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Pyg)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Xof)]
    [InlineData(SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency.Xpf)]
    public void SerializationRoundtrip_Works(
        SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SetPackagePricingOveragePricingModelBillingCadenceTest : TestBase
{
    [Theory]
    [InlineData(SetPackagePricingOveragePricingModelBillingCadence.Recurring)]
    [InlineData(SetPackagePricingOveragePricingModelBillingCadence.OneOff)]
    public void Validation_Works(SetPackagePricingOveragePricingModelBillingCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SetPackagePricingOveragePricingModelBillingCadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingOveragePricingModelBillingCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SetPackagePricingOveragePricingModelBillingCadence.Recurring)]
    [InlineData(SetPackagePricingOveragePricingModelBillingCadence.OneOff)]
    public void SerializationRoundtrip_Works(
        SetPackagePricingOveragePricingModelBillingCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SetPackagePricingOveragePricingModelBillingCadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingOveragePricingModelBillingCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingOveragePricingModelBillingCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingOveragePricingModelBillingCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SetPackagePricingOveragePricingModelEntitlementTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SetPackagePricingOveragePricingModelEntitlement
        {
            FeatureID = "featureId",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            MonthlyResetPeriodConfiguration = new(
                SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            ResetPeriod = SetPackagePricingOveragePricingModelEntitlementResetPeriod.Year,
            UsageLimit = 0,
            WeeklyResetPeriodConfiguration = new(
                SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };

        string expectedFeatureID = "featureId";
        bool expectedHasSoftLimit = true;
        bool expectedHasUnlimitedUsage = true;
        SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfiguration expectedMonthlyResetPeriodConfiguration =
            new(
                SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            );
        ApiEnum<
            string,
            SetPackagePricingOveragePricingModelEntitlementResetPeriod
        > expectedResetPeriod = SetPackagePricingOveragePricingModelEntitlementResetPeriod.Year;
        double expectedUsageLimit = 0;
        SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfiguration expectedWeeklyResetPeriodConfiguration =
            new(
                SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            );
        SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfiguration expectedYearlyResetPeriodConfiguration =
            new(
                SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
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
        var model = new SetPackagePricingOveragePricingModelEntitlement
        {
            FeatureID = "featureId",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            MonthlyResetPeriodConfiguration = new(
                SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            ResetPeriod = SetPackagePricingOveragePricingModelEntitlementResetPeriod.Year,
            UsageLimit = 0,
            WeeklyResetPeriodConfiguration = new(
                SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SetPackagePricingOveragePricingModelEntitlement>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SetPackagePricingOveragePricingModelEntitlement
        {
            FeatureID = "featureId",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            MonthlyResetPeriodConfiguration = new(
                SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            ResetPeriod = SetPackagePricingOveragePricingModelEntitlementResetPeriod.Year,
            UsageLimit = 0,
            WeeklyResetPeriodConfiguration = new(
                SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SetPackagePricingOveragePricingModelEntitlement>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedFeatureID = "featureId";
        bool expectedHasSoftLimit = true;
        bool expectedHasUnlimitedUsage = true;
        SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfiguration expectedMonthlyResetPeriodConfiguration =
            new(
                SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            );
        ApiEnum<
            string,
            SetPackagePricingOveragePricingModelEntitlementResetPeriod
        > expectedResetPeriod = SetPackagePricingOveragePricingModelEntitlementResetPeriod.Year;
        double expectedUsageLimit = 0;
        SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfiguration expectedWeeklyResetPeriodConfiguration =
            new(
                SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            );
        SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfiguration expectedYearlyResetPeriodConfiguration =
            new(
                SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
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
        var model = new SetPackagePricingOveragePricingModelEntitlement
        {
            FeatureID = "featureId",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            MonthlyResetPeriodConfiguration = new(
                SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            ResetPeriod = SetPackagePricingOveragePricingModelEntitlementResetPeriod.Year,
            UsageLimit = 0,
            WeeklyResetPeriodConfiguration = new(
                SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SetPackagePricingOveragePricingModelEntitlement { FeatureID = "featureId" };

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
        var model = new SetPackagePricingOveragePricingModelEntitlement { FeatureID = "featureId" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SetPackagePricingOveragePricingModelEntitlement
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
        var model = new SetPackagePricingOveragePricingModelEntitlement
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
        var model = new SetPackagePricingOveragePricingModelEntitlement
        {
            FeatureID = "featureId",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            MonthlyResetPeriodConfiguration = new(
                SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            ResetPeriod = SetPackagePricingOveragePricingModelEntitlementResetPeriod.Year,
            UsageLimit = 0,
            WeeklyResetPeriodConfiguration = new(
                SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };

        SetPackagePricingOveragePricingModelEntitlement copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfigurationTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfiguration
            {
                AccordingTo =
                    SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
            };

        ApiEnum<
            string,
            SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfigurationAccordingTo
        > expectedAccordingTo =
            SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, model.AccordingTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model =
            new SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfiguration
            {
                AccordingTo =
                    SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
            };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfiguration>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfiguration
            {
                AccordingTo =
                    SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
            };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfiguration>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfigurationAccordingTo
        > expectedAccordingTo =
            SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, deserialized.AccordingTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model =
            new SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfiguration
            {
                AccordingTo =
                    SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
            };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model =
            new SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfiguration
            {
                AccordingTo =
                    SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
            };

        SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfiguration copied = new(
            model
        );

        Assert.Equal(model, copied);
    }
}

public class SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfigurationAccordingToTest
    : TestBase
{
    [Theory]
    [InlineData(
        SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
    )]
    [InlineData(
        SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfigurationAccordingTo.StartOfTheMonth
    )]
    public void Validation_Works(
        SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfigurationAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfigurationAccordingTo
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfigurationAccordingTo
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
    )]
    [InlineData(
        SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfigurationAccordingTo.StartOfTheMonth
    )]
    public void SerializationRoundtrip_Works(
        SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfigurationAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfigurationAccordingTo
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfigurationAccordingTo
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
                SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfigurationAccordingTo
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfigurationAccordingTo
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SetPackagePricingOveragePricingModelEntitlementResetPeriodTest : TestBase
{
    [Theory]
    [InlineData(SetPackagePricingOveragePricingModelEntitlementResetPeriod.Year)]
    [InlineData(SetPackagePricingOveragePricingModelEntitlementResetPeriod.Month)]
    [InlineData(SetPackagePricingOveragePricingModelEntitlementResetPeriod.Week)]
    [InlineData(SetPackagePricingOveragePricingModelEntitlementResetPeriod.Day)]
    [InlineData(SetPackagePricingOveragePricingModelEntitlementResetPeriod.Hour)]
    public void Validation_Works(
        SetPackagePricingOveragePricingModelEntitlementResetPeriod rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SetPackagePricingOveragePricingModelEntitlementResetPeriod> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingOveragePricingModelEntitlementResetPeriod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SetPackagePricingOveragePricingModelEntitlementResetPeriod.Year)]
    [InlineData(SetPackagePricingOveragePricingModelEntitlementResetPeriod.Month)]
    [InlineData(SetPackagePricingOveragePricingModelEntitlementResetPeriod.Week)]
    [InlineData(SetPackagePricingOveragePricingModelEntitlementResetPeriod.Day)]
    [InlineData(SetPackagePricingOveragePricingModelEntitlementResetPeriod.Hour)]
    public void SerializationRoundtrip_Works(
        SetPackagePricingOveragePricingModelEntitlementResetPeriod rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SetPackagePricingOveragePricingModelEntitlementResetPeriod> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingOveragePricingModelEntitlementResetPeriod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingOveragePricingModelEntitlementResetPeriod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingOveragePricingModelEntitlementResetPeriod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfiguration
            {
                AccordingTo =
                    SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart,
            };

        ApiEnum<
            string,
            SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo
        > expectedAccordingTo =
            SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, model.AccordingTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model =
            new SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfiguration
            {
                AccordingTo =
                    SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart,
            };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfiguration>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfiguration
            {
                AccordingTo =
                    SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart,
            };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfiguration>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo
        > expectedAccordingTo =
            SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, deserialized.AccordingTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model =
            new SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfiguration
            {
                AccordingTo =
                    SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart,
            };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model =
            new SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfiguration
            {
                AccordingTo =
                    SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart,
            };

        SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfiguration copied = new(
            model
        );

        Assert.Equal(model, copied);
    }
}

public class SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingToTest
    : TestBase
{
    [Theory]
    [InlineData(
        SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
    )]
    [InlineData(
        SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo.EverySunday
    )]
    [InlineData(
        SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo.EveryMonday
    )]
    [InlineData(
        SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo.EveryTuesday
    )]
    [InlineData(
        SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo.EveryWednesday
    )]
    [InlineData(
        SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo.EveryThursday
    )]
    [InlineData(
        SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo.EveryFriday
    )]
    [InlineData(
        SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo.EverySaturday
    )]
    public void Validation_Works(
        SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
    )]
    [InlineData(
        SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo.EverySunday
    )]
    [InlineData(
        SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo.EveryMonday
    )]
    [InlineData(
        SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo.EveryTuesday
    )]
    [InlineData(
        SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo.EveryWednesday
    )]
    [InlineData(
        SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo.EveryThursday
    )]
    [InlineData(
        SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo.EveryFriday
    )]
    [InlineData(
        SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo.EverySaturday
    )]
    public void SerializationRoundtrip_Works(
        SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo
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
                SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfigurationTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfiguration
            {
                AccordingTo =
                    SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
            };

        ApiEnum<
            string,
            SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfigurationAccordingTo
        > expectedAccordingTo =
            SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, model.AccordingTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model =
            new SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfiguration
            {
                AccordingTo =
                    SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
            };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfiguration>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfiguration
            {
                AccordingTo =
                    SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
            };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfiguration>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfigurationAccordingTo
        > expectedAccordingTo =
            SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, deserialized.AccordingTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model =
            new SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfiguration
            {
                AccordingTo =
                    SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
            };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model =
            new SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfiguration
            {
                AccordingTo =
                    SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
            };

        SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfiguration copied = new(
            model
        );

        Assert.Equal(model, copied);
    }
}

public class SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfigurationAccordingToTest
    : TestBase
{
    [Theory]
    [InlineData(
        SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
    )]
    public void Validation_Works(
        SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfigurationAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfigurationAccordingTo
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfigurationAccordingTo
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
    )]
    public void SerializationRoundtrip_Works(
        SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfigurationAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfigurationAccordingTo
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfigurationAccordingTo
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
                SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfigurationAccordingTo
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfigurationAccordingTo
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SetPackagePricingPricingModelTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SetPackagePricingPricingModel
        {
            BillingModel = SetPackagePricingPricingModelBillingModel.FlatFee,
            PricePeriods =
            [
                new()
                {
                    BillingPeriod = SetPackagePricingPricingModelPricePeriodBillingPeriod.Monthly,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    CreditGrantCadence =
                        SetPackagePricingPricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                    CreditRate = new()
                    {
                        Amount = 1,
                        CurrencyID = "currencyId",
                        CostFormula = "costFormula",
                    },
                    Price = new()
                    {
                        Amount = 0,
                        Currency = SetPackagePricingPricingModelPricePeriodPriceCurrency.Usd,
                    },
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency =
                                    SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency =
                                    SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            BillingCadence = SetPackagePricingPricingModelBillingCadence.Recurring,
            FeatureID = "featureId",
            MaxUnitQuantity = 1,
            MinUnitQuantity = 1,
            MonthlyResetPeriodConfiguration = new(
                SetPackagePricingPricingModelMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            ResetPeriod = SetPackagePricingPricingModelResetPeriod.Year,
            TiersMode = SetPackagePricingPricingModelTiersMode.Volume,
            TopUpCustomCurrencyID = "topUpCustomCurrencyId",
            WeeklyResetPeriodConfiguration = new(
                SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                SetPackagePricingPricingModelYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };

        ApiEnum<string, SetPackagePricingPricingModelBillingModel> expectedBillingModel =
            SetPackagePricingPricingModelBillingModel.FlatFee;
        List<SetPackagePricingPricingModelPricePeriod> expectedPricePeriods =
        [
            new()
            {
                BillingPeriod = SetPackagePricingPricingModelPricePeriodBillingPeriod.Monthly,
                BillingCountryCode = "billingCountryCode",
                BlockSize = 0,
                CreditGrantCadence =
                    SetPackagePricingPricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                CreditRate = new()
                {
                    Amount = 1,
                    CurrencyID = "currencyId",
                    CostFormula = "costFormula",
                },
                Price = new()
                {
                    Amount = 0,
                    Currency = SetPackagePricingPricingModelPricePeriodPriceCurrency.Usd,
                },
                Tiers =
                [
                    new()
                    {
                        FlatPrice = new()
                        {
                            Amount = 0,
                            Currency =
                                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Usd,
                        },
                        UnitPrice = new()
                        {
                            Amount = 0,
                            Currency =
                                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Usd,
                        },
                        UpTo = 0,
                    },
                ],
            },
        ];
        ApiEnum<string, SetPackagePricingPricingModelBillingCadence> expectedBillingCadence =
            SetPackagePricingPricingModelBillingCadence.Recurring;
        string expectedFeatureID = "featureId";
        long expectedMaxUnitQuantity = 1;
        long expectedMinUnitQuantity = 1;
        SetPackagePricingPricingModelMonthlyResetPeriodConfiguration expectedMonthlyResetPeriodConfiguration =
            new(
                SetPackagePricingPricingModelMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            );
        ApiEnum<string, SetPackagePricingPricingModelResetPeriod> expectedResetPeriod =
            SetPackagePricingPricingModelResetPeriod.Year;
        ApiEnum<string, SetPackagePricingPricingModelTiersMode> expectedTiersMode =
            SetPackagePricingPricingModelTiersMode.Volume;
        string expectedTopUpCustomCurrencyID = "topUpCustomCurrencyId";
        SetPackagePricingPricingModelWeeklyResetPeriodConfiguration expectedWeeklyResetPeriodConfiguration =
            new(
                SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            );
        SetPackagePricingPricingModelYearlyResetPeriodConfiguration expectedYearlyResetPeriodConfiguration =
            new(
                SetPackagePricingPricingModelYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
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
        var model = new SetPackagePricingPricingModel
        {
            BillingModel = SetPackagePricingPricingModelBillingModel.FlatFee,
            PricePeriods =
            [
                new()
                {
                    BillingPeriod = SetPackagePricingPricingModelPricePeriodBillingPeriod.Monthly,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    CreditGrantCadence =
                        SetPackagePricingPricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                    CreditRate = new()
                    {
                        Amount = 1,
                        CurrencyID = "currencyId",
                        CostFormula = "costFormula",
                    },
                    Price = new()
                    {
                        Amount = 0,
                        Currency = SetPackagePricingPricingModelPricePeriodPriceCurrency.Usd,
                    },
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency =
                                    SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency =
                                    SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            BillingCadence = SetPackagePricingPricingModelBillingCadence.Recurring,
            FeatureID = "featureId",
            MaxUnitQuantity = 1,
            MinUnitQuantity = 1,
            MonthlyResetPeriodConfiguration = new(
                SetPackagePricingPricingModelMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            ResetPeriod = SetPackagePricingPricingModelResetPeriod.Year,
            TiersMode = SetPackagePricingPricingModelTiersMode.Volume,
            TopUpCustomCurrencyID = "topUpCustomCurrencyId",
            WeeklyResetPeriodConfiguration = new(
                SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                SetPackagePricingPricingModelYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SetPackagePricingPricingModel>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SetPackagePricingPricingModel
        {
            BillingModel = SetPackagePricingPricingModelBillingModel.FlatFee,
            PricePeriods =
            [
                new()
                {
                    BillingPeriod = SetPackagePricingPricingModelPricePeriodBillingPeriod.Monthly,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    CreditGrantCadence =
                        SetPackagePricingPricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                    CreditRate = new()
                    {
                        Amount = 1,
                        CurrencyID = "currencyId",
                        CostFormula = "costFormula",
                    },
                    Price = new()
                    {
                        Amount = 0,
                        Currency = SetPackagePricingPricingModelPricePeriodPriceCurrency.Usd,
                    },
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency =
                                    SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency =
                                    SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            BillingCadence = SetPackagePricingPricingModelBillingCadence.Recurring,
            FeatureID = "featureId",
            MaxUnitQuantity = 1,
            MinUnitQuantity = 1,
            MonthlyResetPeriodConfiguration = new(
                SetPackagePricingPricingModelMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            ResetPeriod = SetPackagePricingPricingModelResetPeriod.Year,
            TiersMode = SetPackagePricingPricingModelTiersMode.Volume,
            TopUpCustomCurrencyID = "topUpCustomCurrencyId",
            WeeklyResetPeriodConfiguration = new(
                SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                SetPackagePricingPricingModelYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SetPackagePricingPricingModel>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, SetPackagePricingPricingModelBillingModel> expectedBillingModel =
            SetPackagePricingPricingModelBillingModel.FlatFee;
        List<SetPackagePricingPricingModelPricePeriod> expectedPricePeriods =
        [
            new()
            {
                BillingPeriod = SetPackagePricingPricingModelPricePeriodBillingPeriod.Monthly,
                BillingCountryCode = "billingCountryCode",
                BlockSize = 0,
                CreditGrantCadence =
                    SetPackagePricingPricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                CreditRate = new()
                {
                    Amount = 1,
                    CurrencyID = "currencyId",
                    CostFormula = "costFormula",
                },
                Price = new()
                {
                    Amount = 0,
                    Currency = SetPackagePricingPricingModelPricePeriodPriceCurrency.Usd,
                },
                Tiers =
                [
                    new()
                    {
                        FlatPrice = new()
                        {
                            Amount = 0,
                            Currency =
                                SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Usd,
                        },
                        UnitPrice = new()
                        {
                            Amount = 0,
                            Currency =
                                SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Usd,
                        },
                        UpTo = 0,
                    },
                ],
            },
        ];
        ApiEnum<string, SetPackagePricingPricingModelBillingCadence> expectedBillingCadence =
            SetPackagePricingPricingModelBillingCadence.Recurring;
        string expectedFeatureID = "featureId";
        long expectedMaxUnitQuantity = 1;
        long expectedMinUnitQuantity = 1;
        SetPackagePricingPricingModelMonthlyResetPeriodConfiguration expectedMonthlyResetPeriodConfiguration =
            new(
                SetPackagePricingPricingModelMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            );
        ApiEnum<string, SetPackagePricingPricingModelResetPeriod> expectedResetPeriod =
            SetPackagePricingPricingModelResetPeriod.Year;
        ApiEnum<string, SetPackagePricingPricingModelTiersMode> expectedTiersMode =
            SetPackagePricingPricingModelTiersMode.Volume;
        string expectedTopUpCustomCurrencyID = "topUpCustomCurrencyId";
        SetPackagePricingPricingModelWeeklyResetPeriodConfiguration expectedWeeklyResetPeriodConfiguration =
            new(
                SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            );
        SetPackagePricingPricingModelYearlyResetPeriodConfiguration expectedYearlyResetPeriodConfiguration =
            new(
                SetPackagePricingPricingModelYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
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
        var model = new SetPackagePricingPricingModel
        {
            BillingModel = SetPackagePricingPricingModelBillingModel.FlatFee,
            PricePeriods =
            [
                new()
                {
                    BillingPeriod = SetPackagePricingPricingModelPricePeriodBillingPeriod.Monthly,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    CreditGrantCadence =
                        SetPackagePricingPricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                    CreditRate = new()
                    {
                        Amount = 1,
                        CurrencyID = "currencyId",
                        CostFormula = "costFormula",
                    },
                    Price = new()
                    {
                        Amount = 0,
                        Currency = SetPackagePricingPricingModelPricePeriodPriceCurrency.Usd,
                    },
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency =
                                    SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency =
                                    SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            BillingCadence = SetPackagePricingPricingModelBillingCadence.Recurring,
            FeatureID = "featureId",
            MaxUnitQuantity = 1,
            MinUnitQuantity = 1,
            MonthlyResetPeriodConfiguration = new(
                SetPackagePricingPricingModelMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            ResetPeriod = SetPackagePricingPricingModelResetPeriod.Year,
            TiersMode = SetPackagePricingPricingModelTiersMode.Volume,
            TopUpCustomCurrencyID = "topUpCustomCurrencyId",
            WeeklyResetPeriodConfiguration = new(
                SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                SetPackagePricingPricingModelYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SetPackagePricingPricingModel
        {
            BillingModel = SetPackagePricingPricingModelBillingModel.FlatFee,
            PricePeriods =
            [
                new()
                {
                    BillingPeriod = SetPackagePricingPricingModelPricePeriodBillingPeriod.Monthly,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    CreditGrantCadence =
                        SetPackagePricingPricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                    CreditRate = new()
                    {
                        Amount = 1,
                        CurrencyID = "currencyId",
                        CostFormula = "costFormula",
                    },
                    Price = new()
                    {
                        Amount = 0,
                        Currency = SetPackagePricingPricingModelPricePeriodPriceCurrency.Usd,
                    },
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency =
                                    SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency =
                                    SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Usd,
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
        var model = new SetPackagePricingPricingModel
        {
            BillingModel = SetPackagePricingPricingModelBillingModel.FlatFee,
            PricePeriods =
            [
                new()
                {
                    BillingPeriod = SetPackagePricingPricingModelPricePeriodBillingPeriod.Monthly,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    CreditGrantCadence =
                        SetPackagePricingPricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                    CreditRate = new()
                    {
                        Amount = 1,
                        CurrencyID = "currencyId",
                        CostFormula = "costFormula",
                    },
                    Price = new()
                    {
                        Amount = 0,
                        Currency = SetPackagePricingPricingModelPricePeriodPriceCurrency.Usd,
                    },
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency =
                                    SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency =
                                    SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Usd,
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
        var model = new SetPackagePricingPricingModel
        {
            BillingModel = SetPackagePricingPricingModelBillingModel.FlatFee,
            PricePeriods =
            [
                new()
                {
                    BillingPeriod = SetPackagePricingPricingModelPricePeriodBillingPeriod.Monthly,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    CreditGrantCadence =
                        SetPackagePricingPricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                    CreditRate = new()
                    {
                        Amount = 1,
                        CurrencyID = "currencyId",
                        CostFormula = "costFormula",
                    },
                    Price = new()
                    {
                        Amount = 0,
                        Currency = SetPackagePricingPricingModelPricePeriodPriceCurrency.Usd,
                    },
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency =
                                    SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency =
                                    SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Usd,
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
        var model = new SetPackagePricingPricingModel
        {
            BillingModel = SetPackagePricingPricingModelBillingModel.FlatFee,
            PricePeriods =
            [
                new()
                {
                    BillingPeriod = SetPackagePricingPricingModelPricePeriodBillingPeriod.Monthly,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    CreditGrantCadence =
                        SetPackagePricingPricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                    CreditRate = new()
                    {
                        Amount = 1,
                        CurrencyID = "currencyId",
                        CostFormula = "costFormula",
                    },
                    Price = new()
                    {
                        Amount = 0,
                        Currency = SetPackagePricingPricingModelPricePeriodPriceCurrency.Usd,
                    },
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency =
                                    SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency =
                                    SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Usd,
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
        var model = new SetPackagePricingPricingModel
        {
            BillingModel = SetPackagePricingPricingModelBillingModel.FlatFee,
            PricePeriods =
            [
                new()
                {
                    BillingPeriod = SetPackagePricingPricingModelPricePeriodBillingPeriod.Monthly,
                    BillingCountryCode = "billingCountryCode",
                    BlockSize = 0,
                    CreditGrantCadence =
                        SetPackagePricingPricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
                    CreditRate = new()
                    {
                        Amount = 1,
                        CurrencyID = "currencyId",
                        CostFormula = "costFormula",
                    },
                    Price = new()
                    {
                        Amount = 0,
                        Currency = SetPackagePricingPricingModelPricePeriodPriceCurrency.Usd,
                    },
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency =
                                    SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency =
                                    SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                },
            ],
            BillingCadence = SetPackagePricingPricingModelBillingCadence.Recurring,
            FeatureID = "featureId",
            MaxUnitQuantity = 1,
            MinUnitQuantity = 1,
            MonthlyResetPeriodConfiguration = new(
                SetPackagePricingPricingModelMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            ResetPeriod = SetPackagePricingPricingModelResetPeriod.Year,
            TiersMode = SetPackagePricingPricingModelTiersMode.Volume,
            TopUpCustomCurrencyID = "topUpCustomCurrencyId",
            WeeklyResetPeriodConfiguration = new(
                SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                SetPackagePricingPricingModelYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };

        SetPackagePricingPricingModel copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SetPackagePricingPricingModelBillingModelTest : TestBase
{
    [Theory]
    [InlineData(SetPackagePricingPricingModelBillingModel.FlatFee)]
    [InlineData(SetPackagePricingPricingModelBillingModel.MinimumSpend)]
    [InlineData(SetPackagePricingPricingModelBillingModel.PerUnit)]
    [InlineData(SetPackagePricingPricingModelBillingModel.UsageBased)]
    [InlineData(SetPackagePricingPricingModelBillingModel.CreditBased)]
    public void Validation_Works(SetPackagePricingPricingModelBillingModel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SetPackagePricingPricingModelBillingModel> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingPricingModelBillingModel>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SetPackagePricingPricingModelBillingModel.FlatFee)]
    [InlineData(SetPackagePricingPricingModelBillingModel.MinimumSpend)]
    [InlineData(SetPackagePricingPricingModelBillingModel.PerUnit)]
    [InlineData(SetPackagePricingPricingModelBillingModel.UsageBased)]
    [InlineData(SetPackagePricingPricingModelBillingModel.CreditBased)]
    public void SerializationRoundtrip_Works(SetPackagePricingPricingModelBillingModel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SetPackagePricingPricingModelBillingModel> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingPricingModelBillingModel>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingPricingModelBillingModel>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingPricingModelBillingModel>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SetPackagePricingPricingModelPricePeriodTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SetPackagePricingPricingModelPricePeriod
        {
            BillingPeriod = SetPackagePricingPricingModelPricePeriodBillingPeriod.Monthly,
            BillingCountryCode = "billingCountryCode",
            BlockSize = 0,
            CreditGrantCadence =
                SetPackagePricingPricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
            CreditRate = new()
            {
                Amount = 1,
                CurrencyID = "currencyId",
                CostFormula = "costFormula",
            },
            Price = new()
            {
                Amount = 0,
                Currency = SetPackagePricingPricingModelPricePeriodPriceCurrency.Usd,
            },
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        Currency =
                            SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        Currency =
                            SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Usd,
                    },
                    UpTo = 0,
                },
            ],
        };

        ApiEnum<
            string,
            SetPackagePricingPricingModelPricePeriodBillingPeriod
        > expectedBillingPeriod = SetPackagePricingPricingModelPricePeriodBillingPeriod.Monthly;
        string expectedBillingCountryCode = "billingCountryCode";
        double expectedBlockSize = 0;
        ApiEnum<
            string,
            SetPackagePricingPricingModelPricePeriodCreditGrantCadence
        > expectedCreditGrantCadence =
            SetPackagePricingPricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod;
        SetPackagePricingPricingModelPricePeriodCreditRate expectedCreditRate = new()
        {
            Amount = 1,
            CurrencyID = "currencyId",
            CostFormula = "costFormula",
        };
        SetPackagePricingPricingModelPricePeriodPrice expectedPrice = new()
        {
            Amount = 0,
            Currency = SetPackagePricingPricingModelPricePeriodPriceCurrency.Usd,
        };
        List<SetPackagePricingPricingModelPricePeriodTier> expectedTiers =
        [
            new()
            {
                FlatPrice = new()
                {
                    Amount = 0,
                    Currency = SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Usd,
                },
                UnitPrice = new()
                {
                    Amount = 0,
                    Currency = SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Usd,
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
        var model = new SetPackagePricingPricingModelPricePeriod
        {
            BillingPeriod = SetPackagePricingPricingModelPricePeriodBillingPeriod.Monthly,
            BillingCountryCode = "billingCountryCode",
            BlockSize = 0,
            CreditGrantCadence =
                SetPackagePricingPricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
            CreditRate = new()
            {
                Amount = 1,
                CurrencyID = "currencyId",
                CostFormula = "costFormula",
            },
            Price = new()
            {
                Amount = 0,
                Currency = SetPackagePricingPricingModelPricePeriodPriceCurrency.Usd,
            },
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        Currency =
                            SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        Currency =
                            SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Usd,
                    },
                    UpTo = 0,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SetPackagePricingPricingModelPricePeriod>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SetPackagePricingPricingModelPricePeriod
        {
            BillingPeriod = SetPackagePricingPricingModelPricePeriodBillingPeriod.Monthly,
            BillingCountryCode = "billingCountryCode",
            BlockSize = 0,
            CreditGrantCadence =
                SetPackagePricingPricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
            CreditRate = new()
            {
                Amount = 1,
                CurrencyID = "currencyId",
                CostFormula = "costFormula",
            },
            Price = new()
            {
                Amount = 0,
                Currency = SetPackagePricingPricingModelPricePeriodPriceCurrency.Usd,
            },
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        Currency =
                            SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        Currency =
                            SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Usd,
                    },
                    UpTo = 0,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SetPackagePricingPricingModelPricePeriod>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            SetPackagePricingPricingModelPricePeriodBillingPeriod
        > expectedBillingPeriod = SetPackagePricingPricingModelPricePeriodBillingPeriod.Monthly;
        string expectedBillingCountryCode = "billingCountryCode";
        double expectedBlockSize = 0;
        ApiEnum<
            string,
            SetPackagePricingPricingModelPricePeriodCreditGrantCadence
        > expectedCreditGrantCadence =
            SetPackagePricingPricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod;
        SetPackagePricingPricingModelPricePeriodCreditRate expectedCreditRate = new()
        {
            Amount = 1,
            CurrencyID = "currencyId",
            CostFormula = "costFormula",
        };
        SetPackagePricingPricingModelPricePeriodPrice expectedPrice = new()
        {
            Amount = 0,
            Currency = SetPackagePricingPricingModelPricePeriodPriceCurrency.Usd,
        };
        List<SetPackagePricingPricingModelPricePeriodTier> expectedTiers =
        [
            new()
            {
                FlatPrice = new()
                {
                    Amount = 0,
                    Currency = SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Usd,
                },
                UnitPrice = new()
                {
                    Amount = 0,
                    Currency = SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Usd,
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
        var model = new SetPackagePricingPricingModelPricePeriod
        {
            BillingPeriod = SetPackagePricingPricingModelPricePeriodBillingPeriod.Monthly,
            BillingCountryCode = "billingCountryCode",
            BlockSize = 0,
            CreditGrantCadence =
                SetPackagePricingPricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
            CreditRate = new()
            {
                Amount = 1,
                CurrencyID = "currencyId",
                CostFormula = "costFormula",
            },
            Price = new()
            {
                Amount = 0,
                Currency = SetPackagePricingPricingModelPricePeriodPriceCurrency.Usd,
            },
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        Currency =
                            SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        Currency =
                            SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Usd,
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
        var model = new SetPackagePricingPricingModelPricePeriod
        {
            BillingPeriod = SetPackagePricingPricingModelPricePeriodBillingPeriod.Monthly,
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
        var model = new SetPackagePricingPricingModelPricePeriod
        {
            BillingPeriod = SetPackagePricingPricingModelPricePeriodBillingPeriod.Monthly,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SetPackagePricingPricingModelPricePeriod
        {
            BillingPeriod = SetPackagePricingPricingModelPricePeriodBillingPeriod.Monthly,

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
        var model = new SetPackagePricingPricingModelPricePeriod
        {
            BillingPeriod = SetPackagePricingPricingModelPricePeriodBillingPeriod.Monthly,

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
        var model = new SetPackagePricingPricingModelPricePeriod
        {
            BillingPeriod = SetPackagePricingPricingModelPricePeriodBillingPeriod.Monthly,
            BillingCountryCode = "billingCountryCode",
            BlockSize = 0,
            CreditGrantCadence =
                SetPackagePricingPricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
            CreditRate = new()
            {
                Amount = 1,
                CurrencyID = "currencyId",
                CostFormula = "costFormula",
            },
            Price = new()
            {
                Amount = 0,
                Currency = SetPackagePricingPricingModelPricePeriodPriceCurrency.Usd,
            },
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        Currency =
                            SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        Currency =
                            SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Usd,
                    },
                    UpTo = 0,
                },
            ],
        };

        SetPackagePricingPricingModelPricePeriod copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SetPackagePricingPricingModelPricePeriodBillingPeriodTest : TestBase
{
    [Theory]
    [InlineData(SetPackagePricingPricingModelPricePeriodBillingPeriod.Monthly)]
    [InlineData(SetPackagePricingPricingModelPricePeriodBillingPeriod.Annually)]
    public void Validation_Works(SetPackagePricingPricingModelPricePeriodBillingPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SetPackagePricingPricingModelPricePeriodBillingPeriod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingPricingModelPricePeriodBillingPeriod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SetPackagePricingPricingModelPricePeriodBillingPeriod.Monthly)]
    [InlineData(SetPackagePricingPricingModelPricePeriodBillingPeriod.Annually)]
    public void SerializationRoundtrip_Works(
        SetPackagePricingPricingModelPricePeriodBillingPeriod rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SetPackagePricingPricingModelPricePeriodBillingPeriod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingPricingModelPricePeriodBillingPeriod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingPricingModelPricePeriodBillingPeriod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingPricingModelPricePeriodBillingPeriod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SetPackagePricingPricingModelPricePeriodCreditGrantCadenceTest : TestBase
{
    [Theory]
    [InlineData(
        SetPackagePricingPricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod
    )]
    [InlineData(SetPackagePricingPricingModelPricePeriodCreditGrantCadence.Monthly)]
    public void Validation_Works(
        SetPackagePricingPricingModelPricePeriodCreditGrantCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SetPackagePricingPricingModelPricePeriodCreditGrantCadence> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingPricingModelPricePeriodCreditGrantCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        SetPackagePricingPricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod
    )]
    [InlineData(SetPackagePricingPricingModelPricePeriodCreditGrantCadence.Monthly)]
    public void SerializationRoundtrip_Works(
        SetPackagePricingPricingModelPricePeriodCreditGrantCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SetPackagePricingPricingModelPricePeriodCreditGrantCadence> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingPricingModelPricePeriodCreditGrantCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingPricingModelPricePeriodCreditGrantCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingPricingModelPricePeriodCreditGrantCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SetPackagePricingPricingModelPricePeriodCreditRateTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SetPackagePricingPricingModelPricePeriodCreditRate
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
        var model = new SetPackagePricingPricingModelPricePeriodCreditRate
        {
            Amount = 1,
            CurrencyID = "currencyId",
            CostFormula = "costFormula",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SetPackagePricingPricingModelPricePeriodCreditRate>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SetPackagePricingPricingModelPricePeriodCreditRate
        {
            Amount = 1,
            CurrencyID = "currencyId",
            CostFormula = "costFormula",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SetPackagePricingPricingModelPricePeriodCreditRate>(
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
        var model = new SetPackagePricingPricingModelPricePeriodCreditRate
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
        var model = new SetPackagePricingPricingModelPricePeriodCreditRate
        {
            Amount = 1,
            CurrencyID = "currencyId",
        };

        Assert.Null(model.CostFormula);
        Assert.False(model.RawData.ContainsKey("costFormula"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SetPackagePricingPricingModelPricePeriodCreditRate
        {
            Amount = 1,
            CurrencyID = "currencyId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SetPackagePricingPricingModelPricePeriodCreditRate
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
        var model = new SetPackagePricingPricingModelPricePeriodCreditRate
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
        var model = new SetPackagePricingPricingModelPricePeriodCreditRate
        {
            Amount = 1,
            CurrencyID = "currencyId",
            CostFormula = "costFormula",
        };

        SetPackagePricingPricingModelPricePeriodCreditRate copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SetPackagePricingPricingModelPricePeriodPriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SetPackagePricingPricingModelPricePeriodPrice
        {
            Amount = 0,
            Currency = SetPackagePricingPricingModelPricePeriodPriceCurrency.Usd,
        };

        double expectedAmount = 0;
        ApiEnum<string, SetPackagePricingPricingModelPricePeriodPriceCurrency> expectedCurrency =
            SetPackagePricingPricingModelPricePeriodPriceCurrency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SetPackagePricingPricingModelPricePeriodPrice
        {
            Amount = 0,
            Currency = SetPackagePricingPricingModelPricePeriodPriceCurrency.Usd,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SetPackagePricingPricingModelPricePeriodPrice>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SetPackagePricingPricingModelPricePeriodPrice
        {
            Amount = 0,
            Currency = SetPackagePricingPricingModelPricePeriodPriceCurrency.Usd,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SetPackagePricingPricingModelPricePeriodPrice>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        ApiEnum<string, SetPackagePricingPricingModelPricePeriodPriceCurrency> expectedCurrency =
            SetPackagePricingPricingModelPricePeriodPriceCurrency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SetPackagePricingPricingModelPricePeriodPrice
        {
            Amount = 0,
            Currency = SetPackagePricingPricingModelPricePeriodPriceCurrency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SetPackagePricingPricingModelPricePeriodPrice { Amount = 0 };

        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SetPackagePricingPricingModelPricePeriodPrice { Amount = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SetPackagePricingPricingModelPricePeriodPrice
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
        var model = new SetPackagePricingPricingModelPricePeriodPrice
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
        var model = new SetPackagePricingPricingModelPricePeriodPrice
        {
            Amount = 0,
            Currency = SetPackagePricingPricingModelPricePeriodPriceCurrency.Usd,
        };

        SetPackagePricingPricingModelPricePeriodPrice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SetPackagePricingPricingModelPricePeriodPriceCurrencyTest : TestBase
{
    [Theory]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Usd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Aed)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.All)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Amd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Ang)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Aud)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Awg)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Azn)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Bam)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Bbd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Bdt)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Bgn)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Bif)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Bmd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Bnd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Bsd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Bwp)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Byn)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Bzd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Brl)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Cad)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Cdf)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Chf)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Cny)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Czk)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Dkk)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Dop)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Dzd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Egp)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Etb)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Eur)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Fjd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Gbp)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Gel)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Gip)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Gmd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Gyd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Hkd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Hrk)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Htg)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Idr)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Ils)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Inr)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Isk)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Jmd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Jpy)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Kes)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Kgs)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Khr)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Kmf)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Krw)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Kyd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Kzt)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Lbp)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Lkr)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Lrd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Lsl)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Mad)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Mdl)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Mga)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Mkd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Mmk)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Mnt)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Mop)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Mro)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Mvr)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Mwk)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Mxn)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Myr)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Mzn)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Nad)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Ngn)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Nok)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Npr)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Nzd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Pgk)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Php)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Pkr)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Pln)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Qar)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Ron)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Rsd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Rub)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Rwf)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Sar)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Sbd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Scr)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Sek)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Sgd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Sle)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Sll)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Sos)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Szl)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Thb)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Tjs)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Top)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Try)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Ttd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Tzs)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Uah)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Uzs)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Vnd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Vuv)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Wst)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Xaf)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Xcd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Yer)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Zar)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Zmw)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Clp)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Djf)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Gnf)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Ugx)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Pyg)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Xof)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Xpf)]
    public void Validation_Works(SetPackagePricingPricingModelPricePeriodPriceCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SetPackagePricingPricingModelPricePeriodPriceCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingPricingModelPricePeriodPriceCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Usd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Aed)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.All)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Amd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Ang)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Aud)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Awg)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Azn)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Bam)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Bbd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Bdt)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Bgn)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Bif)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Bmd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Bnd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Bsd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Bwp)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Byn)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Bzd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Brl)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Cad)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Cdf)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Chf)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Cny)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Czk)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Dkk)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Dop)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Dzd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Egp)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Etb)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Eur)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Fjd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Gbp)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Gel)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Gip)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Gmd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Gyd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Hkd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Hrk)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Htg)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Idr)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Ils)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Inr)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Isk)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Jmd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Jpy)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Kes)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Kgs)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Khr)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Kmf)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Krw)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Kyd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Kzt)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Lbp)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Lkr)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Lrd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Lsl)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Mad)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Mdl)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Mga)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Mkd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Mmk)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Mnt)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Mop)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Mro)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Mvr)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Mwk)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Mxn)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Myr)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Mzn)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Nad)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Ngn)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Nok)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Npr)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Nzd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Pgk)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Php)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Pkr)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Pln)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Qar)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Ron)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Rsd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Rub)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Rwf)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Sar)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Sbd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Scr)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Sek)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Sgd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Sle)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Sll)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Sos)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Szl)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Thb)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Tjs)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Top)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Try)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Ttd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Tzs)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Uah)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Uzs)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Vnd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Vuv)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Wst)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Xaf)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Xcd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Yer)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Zar)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Zmw)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Clp)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Djf)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Gnf)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Ugx)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Pyg)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Xof)]
    [InlineData(SetPackagePricingPricingModelPricePeriodPriceCurrency.Xpf)]
    public void SerializationRoundtrip_Works(
        SetPackagePricingPricingModelPricePeriodPriceCurrency rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SetPackagePricingPricingModelPricePeriodPriceCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingPricingModelPricePeriodPriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingPricingModelPricePeriodPriceCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingPricingModelPricePeriodPriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SetPackagePricingPricingModelPricePeriodTierTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SetPackagePricingPricingModelPricePeriodTier
        {
            FlatPrice = new()
            {
                Amount = 0,
                Currency = SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Usd,
            },
            UnitPrice = new()
            {
                Amount = 0,
                Currency = SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Usd,
            },
            UpTo = 0,
        };

        SetPackagePricingPricingModelPricePeriodTierFlatPrice expectedFlatPrice = new()
        {
            Amount = 0,
            Currency = SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Usd,
        };
        SetPackagePricingPricingModelPricePeriodTierUnitPrice expectedUnitPrice = new()
        {
            Amount = 0,
            Currency = SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Usd,
        };
        double expectedUpTo = 0;

        Assert.Equal(expectedFlatPrice, model.FlatPrice);
        Assert.Equal(expectedUnitPrice, model.UnitPrice);
        Assert.Equal(expectedUpTo, model.UpTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SetPackagePricingPricingModelPricePeriodTier
        {
            FlatPrice = new()
            {
                Amount = 0,
                Currency = SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Usd,
            },
            UnitPrice = new()
            {
                Amount = 0,
                Currency = SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Usd,
            },
            UpTo = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SetPackagePricingPricingModelPricePeriodTier>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SetPackagePricingPricingModelPricePeriodTier
        {
            FlatPrice = new()
            {
                Amount = 0,
                Currency = SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Usd,
            },
            UnitPrice = new()
            {
                Amount = 0,
                Currency = SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Usd,
            },
            UpTo = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SetPackagePricingPricingModelPricePeriodTier>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        SetPackagePricingPricingModelPricePeriodTierFlatPrice expectedFlatPrice = new()
        {
            Amount = 0,
            Currency = SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Usd,
        };
        SetPackagePricingPricingModelPricePeriodTierUnitPrice expectedUnitPrice = new()
        {
            Amount = 0,
            Currency = SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Usd,
        };
        double expectedUpTo = 0;

        Assert.Equal(expectedFlatPrice, deserialized.FlatPrice);
        Assert.Equal(expectedUnitPrice, deserialized.UnitPrice);
        Assert.Equal(expectedUpTo, deserialized.UpTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SetPackagePricingPricingModelPricePeriodTier
        {
            FlatPrice = new()
            {
                Amount = 0,
                Currency = SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Usd,
            },
            UnitPrice = new()
            {
                Amount = 0,
                Currency = SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Usd,
            },
            UpTo = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SetPackagePricingPricingModelPricePeriodTier { };

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
        var model = new SetPackagePricingPricingModelPricePeriodTier { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SetPackagePricingPricingModelPricePeriodTier
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
        var model = new SetPackagePricingPricingModelPricePeriodTier
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
        var model = new SetPackagePricingPricingModelPricePeriodTier
        {
            FlatPrice = new()
            {
                Amount = 0,
                Currency = SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Usd,
            },
            UnitPrice = new()
            {
                Amount = 0,
                Currency = SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Usd,
            },
            UpTo = 0,
        };

        SetPackagePricingPricingModelPricePeriodTier copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SetPackagePricingPricingModelPricePeriodTierFlatPriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SetPackagePricingPricingModelPricePeriodTierFlatPrice
        {
            Amount = 0,
            Currency = SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Usd,
        };

        double expectedAmount = 0;
        ApiEnum<
            string,
            SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency
        > expectedCurrency = SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SetPackagePricingPricingModelPricePeriodTierFlatPrice
        {
            Amount = 0,
            Currency = SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Usd,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SetPackagePricingPricingModelPricePeriodTierFlatPrice>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SetPackagePricingPricingModelPricePeriodTierFlatPrice
        {
            Amount = 0,
            Currency = SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Usd,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SetPackagePricingPricingModelPricePeriodTierFlatPrice>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        ApiEnum<
            string,
            SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency
        > expectedCurrency = SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SetPackagePricingPricingModelPricePeriodTierFlatPrice
        {
            Amount = 0,
            Currency = SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SetPackagePricingPricingModelPricePeriodTierFlatPrice { Amount = 0 };

        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SetPackagePricingPricingModelPricePeriodTierFlatPrice { Amount = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SetPackagePricingPricingModelPricePeriodTierFlatPrice
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
        var model = new SetPackagePricingPricingModelPricePeriodTierFlatPrice
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
        var model = new SetPackagePricingPricingModelPricePeriodTierFlatPrice
        {
            Amount = 0,
            Currency = SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Usd,
        };

        SetPackagePricingPricingModelPricePeriodTierFlatPrice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrencyTest : TestBase
{
    [Theory]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Usd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Aed)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.All)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Amd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Ang)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Aud)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Awg)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Azn)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Bam)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Bbd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Bdt)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Bgn)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Bif)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Bmd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Bnd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Bsd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Bwp)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Byn)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Bzd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Brl)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Cad)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Cdf)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Chf)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Cny)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Czk)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Dkk)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Dop)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Dzd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Egp)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Etb)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Eur)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Fjd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Gbp)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Gel)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Gip)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Gmd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Gyd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Hkd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Hrk)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Htg)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Idr)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Ils)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Inr)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Isk)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Jmd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Jpy)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Kes)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Kgs)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Khr)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Kmf)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Krw)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Kyd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Kzt)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Lbp)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Lkr)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Lrd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Lsl)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Mad)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Mdl)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Mga)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Mkd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Mmk)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Mnt)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Mop)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Mro)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Mvr)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Mwk)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Mxn)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Myr)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Mzn)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Nad)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Ngn)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Nok)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Npr)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Nzd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Pgk)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Php)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Pkr)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Pln)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Qar)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Ron)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Rsd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Rub)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Rwf)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Sar)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Sbd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Scr)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Sek)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Sgd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Sle)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Sll)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Sos)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Szl)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Thb)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Tjs)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Top)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Try)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Ttd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Tzs)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Uah)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Uzs)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Vnd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Vuv)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Wst)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Xaf)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Xcd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Yer)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Zar)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Zmw)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Clp)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Djf)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Gnf)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Ugx)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Pyg)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Xof)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Xpf)]
    public void Validation_Works(
        SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Usd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Aed)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.All)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Amd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Ang)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Aud)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Awg)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Azn)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Bam)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Bbd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Bdt)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Bgn)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Bif)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Bmd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Bnd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Bsd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Bwp)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Byn)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Bzd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Brl)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Cad)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Cdf)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Chf)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Cny)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Czk)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Dkk)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Dop)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Dzd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Egp)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Etb)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Eur)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Fjd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Gbp)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Gel)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Gip)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Gmd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Gyd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Hkd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Hrk)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Htg)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Idr)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Ils)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Inr)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Isk)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Jmd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Jpy)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Kes)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Kgs)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Khr)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Kmf)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Krw)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Kyd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Kzt)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Lbp)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Lkr)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Lrd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Lsl)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Mad)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Mdl)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Mga)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Mkd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Mmk)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Mnt)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Mop)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Mro)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Mvr)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Mwk)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Mxn)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Myr)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Mzn)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Nad)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Ngn)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Nok)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Npr)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Nzd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Pgk)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Php)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Pkr)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Pln)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Qar)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Ron)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Rsd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Rub)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Rwf)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Sar)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Sbd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Scr)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Sek)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Sgd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Sle)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Sll)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Sos)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Szl)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Thb)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Tjs)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Top)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Try)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Ttd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Tzs)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Uah)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Uzs)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Vnd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Vuv)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Wst)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Xaf)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Xcd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Yer)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Zar)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Zmw)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Clp)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Djf)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Gnf)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Ugx)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Pyg)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Xof)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency.Xpf)]
    public void SerializationRoundtrip_Works(
        SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SetPackagePricingPricingModelPricePeriodTierUnitPriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SetPackagePricingPricingModelPricePeriodTierUnitPrice
        {
            Amount = 0,
            Currency = SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Usd,
        };

        double expectedAmount = 0;
        ApiEnum<
            string,
            SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency
        > expectedCurrency = SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SetPackagePricingPricingModelPricePeriodTierUnitPrice
        {
            Amount = 0,
            Currency = SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Usd,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SetPackagePricingPricingModelPricePeriodTierUnitPrice>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SetPackagePricingPricingModelPricePeriodTierUnitPrice
        {
            Amount = 0,
            Currency = SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Usd,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SetPackagePricingPricingModelPricePeriodTierUnitPrice>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        ApiEnum<
            string,
            SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency
        > expectedCurrency = SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SetPackagePricingPricingModelPricePeriodTierUnitPrice
        {
            Amount = 0,
            Currency = SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SetPackagePricingPricingModelPricePeriodTierUnitPrice { Amount = 0 };

        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SetPackagePricingPricingModelPricePeriodTierUnitPrice { Amount = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SetPackagePricingPricingModelPricePeriodTierUnitPrice
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
        var model = new SetPackagePricingPricingModelPricePeriodTierUnitPrice
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
        var model = new SetPackagePricingPricingModelPricePeriodTierUnitPrice
        {
            Amount = 0,
            Currency = SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Usd,
        };

        SetPackagePricingPricingModelPricePeriodTierUnitPrice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrencyTest : TestBase
{
    [Theory]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Usd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Aed)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.All)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Amd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Ang)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Aud)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Awg)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Azn)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Bam)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Bbd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Bdt)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Bgn)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Bif)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Bmd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Bnd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Bsd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Bwp)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Byn)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Bzd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Brl)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Cad)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Cdf)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Chf)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Cny)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Czk)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Dkk)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Dop)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Dzd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Egp)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Etb)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Eur)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Fjd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Gbp)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Gel)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Gip)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Gmd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Gyd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Hkd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Hrk)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Htg)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Idr)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Ils)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Inr)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Isk)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Jmd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Jpy)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Kes)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Kgs)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Khr)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Kmf)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Krw)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Kyd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Kzt)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Lbp)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Lkr)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Lrd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Lsl)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Mad)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Mdl)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Mga)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Mkd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Mmk)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Mnt)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Mop)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Mro)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Mvr)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Mwk)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Mxn)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Myr)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Mzn)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Nad)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Ngn)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Nok)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Npr)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Nzd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Pgk)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Php)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Pkr)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Pln)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Qar)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Ron)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Rsd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Rub)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Rwf)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Sar)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Sbd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Scr)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Sek)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Sgd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Sle)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Sll)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Sos)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Szl)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Thb)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Tjs)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Top)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Try)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Ttd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Tzs)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Uah)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Uzs)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Vnd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Vuv)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Wst)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Xaf)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Xcd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Yer)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Zar)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Zmw)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Clp)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Djf)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Gnf)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Ugx)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Pyg)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Xof)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Xpf)]
    public void Validation_Works(
        SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Usd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Aed)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.All)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Amd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Ang)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Aud)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Awg)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Azn)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Bam)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Bbd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Bdt)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Bgn)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Bif)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Bmd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Bnd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Bsd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Bwp)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Byn)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Bzd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Brl)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Cad)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Cdf)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Chf)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Cny)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Czk)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Dkk)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Dop)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Dzd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Egp)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Etb)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Eur)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Fjd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Gbp)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Gel)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Gip)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Gmd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Gyd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Hkd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Hrk)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Htg)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Idr)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Ils)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Inr)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Isk)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Jmd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Jpy)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Kes)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Kgs)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Khr)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Kmf)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Krw)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Kyd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Kzt)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Lbp)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Lkr)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Lrd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Lsl)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Mad)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Mdl)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Mga)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Mkd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Mmk)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Mnt)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Mop)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Mro)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Mvr)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Mwk)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Mxn)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Myr)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Mzn)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Nad)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Ngn)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Nok)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Npr)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Nzd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Pgk)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Php)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Pkr)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Pln)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Qar)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Ron)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Rsd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Rub)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Rwf)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Sar)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Sbd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Scr)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Sek)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Sgd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Sle)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Sll)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Sos)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Szl)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Thb)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Tjs)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Top)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Try)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Ttd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Tzs)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Uah)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Uzs)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Vnd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Vuv)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Wst)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Xaf)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Xcd)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Yer)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Zar)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Zmw)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Clp)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Djf)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Gnf)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Ugx)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Pyg)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Xof)]
    [InlineData(SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency.Xpf)]
    public void SerializationRoundtrip_Works(
        SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SetPackagePricingPricingModelBillingCadenceTest : TestBase
{
    [Theory]
    [InlineData(SetPackagePricingPricingModelBillingCadence.Recurring)]
    [InlineData(SetPackagePricingPricingModelBillingCadence.OneOff)]
    public void Validation_Works(SetPackagePricingPricingModelBillingCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SetPackagePricingPricingModelBillingCadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingPricingModelBillingCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SetPackagePricingPricingModelBillingCadence.Recurring)]
    [InlineData(SetPackagePricingPricingModelBillingCadence.OneOff)]
    public void SerializationRoundtrip_Works(SetPackagePricingPricingModelBillingCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SetPackagePricingPricingModelBillingCadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingPricingModelBillingCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingPricingModelBillingCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingPricingModelBillingCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SetPackagePricingPricingModelMonthlyResetPeriodConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SetPackagePricingPricingModelMonthlyResetPeriodConfiguration
        {
            AccordingTo =
                SetPackagePricingPricingModelMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        ApiEnum<
            string,
            SetPackagePricingPricingModelMonthlyResetPeriodConfigurationAccordingTo
        > expectedAccordingTo =
            SetPackagePricingPricingModelMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, model.AccordingTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SetPackagePricingPricingModelMonthlyResetPeriodConfiguration
        {
            AccordingTo =
                SetPackagePricingPricingModelMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SetPackagePricingPricingModelMonthlyResetPeriodConfiguration>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SetPackagePricingPricingModelMonthlyResetPeriodConfiguration
        {
            AccordingTo =
                SetPackagePricingPricingModelMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SetPackagePricingPricingModelMonthlyResetPeriodConfiguration>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            SetPackagePricingPricingModelMonthlyResetPeriodConfigurationAccordingTo
        > expectedAccordingTo =
            SetPackagePricingPricingModelMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, deserialized.AccordingTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SetPackagePricingPricingModelMonthlyResetPeriodConfiguration
        {
            AccordingTo =
                SetPackagePricingPricingModelMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SetPackagePricingPricingModelMonthlyResetPeriodConfiguration
        {
            AccordingTo =
                SetPackagePricingPricingModelMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        SetPackagePricingPricingModelMonthlyResetPeriodConfiguration copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SetPackagePricingPricingModelMonthlyResetPeriodConfigurationAccordingToTest : TestBase
{
    [Theory]
    [InlineData(
        SetPackagePricingPricingModelMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
    )]
    [InlineData(
        SetPackagePricingPricingModelMonthlyResetPeriodConfigurationAccordingTo.StartOfTheMonth
    )]
    public void Validation_Works(
        SetPackagePricingPricingModelMonthlyResetPeriodConfigurationAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            SetPackagePricingPricingModelMonthlyResetPeriodConfigurationAccordingTo
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingPricingModelMonthlyResetPeriodConfigurationAccordingTo>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        SetPackagePricingPricingModelMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
    )]
    [InlineData(
        SetPackagePricingPricingModelMonthlyResetPeriodConfigurationAccordingTo.StartOfTheMonth
    )]
    public void SerializationRoundtrip_Works(
        SetPackagePricingPricingModelMonthlyResetPeriodConfigurationAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            SetPackagePricingPricingModelMonthlyResetPeriodConfigurationAccordingTo
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingPricingModelMonthlyResetPeriodConfigurationAccordingTo>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingPricingModelMonthlyResetPeriodConfigurationAccordingTo>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingPricingModelMonthlyResetPeriodConfigurationAccordingTo>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SetPackagePricingPricingModelResetPeriodTest : TestBase
{
    [Theory]
    [InlineData(SetPackagePricingPricingModelResetPeriod.Year)]
    [InlineData(SetPackagePricingPricingModelResetPeriod.Month)]
    [InlineData(SetPackagePricingPricingModelResetPeriod.Week)]
    [InlineData(SetPackagePricingPricingModelResetPeriod.Day)]
    [InlineData(SetPackagePricingPricingModelResetPeriod.Hour)]
    public void Validation_Works(SetPackagePricingPricingModelResetPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SetPackagePricingPricingModelResetPeriod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingPricingModelResetPeriod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SetPackagePricingPricingModelResetPeriod.Year)]
    [InlineData(SetPackagePricingPricingModelResetPeriod.Month)]
    [InlineData(SetPackagePricingPricingModelResetPeriod.Week)]
    [InlineData(SetPackagePricingPricingModelResetPeriod.Day)]
    [InlineData(SetPackagePricingPricingModelResetPeriod.Hour)]
    public void SerializationRoundtrip_Works(SetPackagePricingPricingModelResetPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SetPackagePricingPricingModelResetPeriod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingPricingModelResetPeriod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingPricingModelResetPeriod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingPricingModelResetPeriod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SetPackagePricingPricingModelTiersModeTest : TestBase
{
    [Theory]
    [InlineData(SetPackagePricingPricingModelTiersMode.Volume)]
    [InlineData(SetPackagePricingPricingModelTiersMode.Graduated)]
    public void Validation_Works(SetPackagePricingPricingModelTiersMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SetPackagePricingPricingModelTiersMode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingPricingModelTiersMode>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SetPackagePricingPricingModelTiersMode.Volume)]
    [InlineData(SetPackagePricingPricingModelTiersMode.Graduated)]
    public void SerializationRoundtrip_Works(SetPackagePricingPricingModelTiersMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SetPackagePricingPricingModelTiersMode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingPricingModelTiersMode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingPricingModelTiersMode>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingPricingModelTiersMode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SetPackagePricingPricingModelWeeklyResetPeriodConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SetPackagePricingPricingModelWeeklyResetPeriodConfiguration
        {
            AccordingTo =
                SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        ApiEnum<
            string,
            SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo
        > expectedAccordingTo =
            SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, model.AccordingTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SetPackagePricingPricingModelWeeklyResetPeriodConfiguration
        {
            AccordingTo =
                SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SetPackagePricingPricingModelWeeklyResetPeriodConfiguration>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SetPackagePricingPricingModelWeeklyResetPeriodConfiguration
        {
            AccordingTo =
                SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SetPackagePricingPricingModelWeeklyResetPeriodConfiguration>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo
        > expectedAccordingTo =
            SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, deserialized.AccordingTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SetPackagePricingPricingModelWeeklyResetPeriodConfiguration
        {
            AccordingTo =
                SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SetPackagePricingPricingModelWeeklyResetPeriodConfiguration
        {
            AccordingTo =
                SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        SetPackagePricingPricingModelWeeklyResetPeriodConfiguration copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingToTest : TestBase
{
    [Theory]
    [InlineData(
        SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
    )]
    [InlineData(SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo.EverySunday)]
    [InlineData(SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo.EveryMonday)]
    [InlineData(
        SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo.EveryTuesday
    )]
    [InlineData(
        SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo.EveryWednesday
    )]
    [InlineData(
        SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo.EveryThursday
    )]
    [InlineData(SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo.EveryFriday)]
    [InlineData(
        SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo.EverySaturday
    )]
    public void Validation_Works(
        SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
    )]
    [InlineData(SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo.EverySunday)]
    [InlineData(SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo.EveryMonday)]
    [InlineData(
        SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo.EveryTuesday
    )]
    [InlineData(
        SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo.EveryWednesday
    )]
    [InlineData(
        SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo.EveryThursday
    )]
    [InlineData(SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo.EveryFriday)]
    [InlineData(
        SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo.EverySaturday
    )]
    public void SerializationRoundtrip_Works(
        SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SetPackagePricingPricingModelYearlyResetPeriodConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SetPackagePricingPricingModelYearlyResetPeriodConfiguration
        {
            AccordingTo =
                SetPackagePricingPricingModelYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        ApiEnum<
            string,
            SetPackagePricingPricingModelYearlyResetPeriodConfigurationAccordingTo
        > expectedAccordingTo =
            SetPackagePricingPricingModelYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, model.AccordingTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SetPackagePricingPricingModelYearlyResetPeriodConfiguration
        {
            AccordingTo =
                SetPackagePricingPricingModelYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SetPackagePricingPricingModelYearlyResetPeriodConfiguration>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SetPackagePricingPricingModelYearlyResetPeriodConfiguration
        {
            AccordingTo =
                SetPackagePricingPricingModelYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SetPackagePricingPricingModelYearlyResetPeriodConfiguration>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            SetPackagePricingPricingModelYearlyResetPeriodConfigurationAccordingTo
        > expectedAccordingTo =
            SetPackagePricingPricingModelYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, deserialized.AccordingTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SetPackagePricingPricingModelYearlyResetPeriodConfiguration
        {
            AccordingTo =
                SetPackagePricingPricingModelYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SetPackagePricingPricingModelYearlyResetPeriodConfiguration
        {
            AccordingTo =
                SetPackagePricingPricingModelYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        SetPackagePricingPricingModelYearlyResetPeriodConfiguration copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SetPackagePricingPricingModelYearlyResetPeriodConfigurationAccordingToTest : TestBase
{
    [Theory]
    [InlineData(
        SetPackagePricingPricingModelYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
    )]
    public void Validation_Works(
        SetPackagePricingPricingModelYearlyResetPeriodConfigurationAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            SetPackagePricingPricingModelYearlyResetPeriodConfigurationAccordingTo
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingPricingModelYearlyResetPeriodConfigurationAccordingTo>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        SetPackagePricingPricingModelYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
    )]
    public void SerializationRoundtrip_Works(
        SetPackagePricingPricingModelYearlyResetPeriodConfigurationAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            SetPackagePricingPricingModelYearlyResetPeriodConfigurationAccordingTo
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingPricingModelYearlyResetPeriodConfigurationAccordingTo>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingPricingModelYearlyResetPeriodConfigurationAccordingTo>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingPricingModelYearlyResetPeriodConfigurationAccordingTo>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
